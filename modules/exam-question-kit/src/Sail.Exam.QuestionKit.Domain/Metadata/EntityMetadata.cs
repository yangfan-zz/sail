using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Sail.Exam.QuestionKit.Metadata
{
    public class EntityMetadata : Entity, IMultiTenant
    {
        public virtual Guid MetadataId { get; set; }

        public virtual string EntityId { get; set; }

        public virtual Guid? TenantId { get; set; }

        protected EntityMetadata()
        {
        }

        internal EntityMetadata(Guid metadataId, string entityId, Guid? tenantId = null)
        {
            MetadataId = metadataId;
            EntityId = Check.NotNullOrEmpty(entityId, nameof(entityId));
            TenantId = tenantId;
        }

        public override object[] GetKeys()
        {
            return [MetadataId, EntityId];
        }
    }
}
