// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Sail.Wpf.Extensions.Hosting
{
    internal sealed class ConfigurationProviderSource(IConfigurationProvider configurationProvider)
        : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new IgnoreFirstLoadConfigurationProvider(configurationProvider);
        }

        // These providers have already been loaded, so no need to reload initially.
        // Otherwise, providers that cannot be reloaded like StreamConfigurationProviders will fail.
        private sealed class IgnoreFirstLoadConfigurationProvider(IConfigurationProvider provider)
            : IConfigurationProvider, IEnumerable<IConfigurationProvider>, IDisposable
        {
            private bool _hasIgnoredFirstLoad;

            public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
            {
                return provider.GetChildKeys(earlierKeys, parentPath);
            }

            public IChangeToken GetReloadToken()
            {
                return provider.GetReloadToken();
            }

            public void Load()
            {
                if (!_hasIgnoredFirstLoad)
                {
                    _hasIgnoredFirstLoad = true;
                    return;
                }

                provider.Load();
            }

            public void Set(string key, string value)
            {
                provider.Set(key, value);
            }

            public bool TryGet(string key, out string value)
            {
                return provider.TryGet(key, out value);
            }

            // Provide access to the original IConfigurationProvider via a single-element IEnumerable to code that goes out of its way to look for it.
            public IEnumerator<IConfigurationProvider> GetEnumerator() => GetUnwrappedEnumerable().GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetUnwrappedEnumerable().GetEnumerator();

            public override bool Equals(object? obj)
            {
                return provider.Equals(obj);
            }

            public override int GetHashCode()
            {
                return provider.GetHashCode();
            }

            public override string? ToString()
            {
                return provider.ToString();
            }

            public void Dispose()
            {
                (provider as IDisposable)?.Dispose();
            }

            private IEnumerable<IConfigurationProvider> GetUnwrappedEnumerable()
            {
                yield return provider;
            }
        }
    }
}
