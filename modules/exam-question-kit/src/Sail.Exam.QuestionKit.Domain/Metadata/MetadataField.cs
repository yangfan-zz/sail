using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sail.Exam.QuestionKit.Metadata
{
    public class MetadataField : FullAuditedAggregateRoot<Guid>
    {
        protected MetadataField()
        {
        }

        public MetadataField(
            Guid id,
            string name,
            string value) : base(id)
        {
            Name = Check.NotNullOrEmpty(name, nameof(name), MetadataFieldConsts.MaxNameLength);
            Value = Check.NotNullOrEmpty(value, nameof(value), MetadataFieldConsts.MaxValueLength);
        }

        public virtual string Name { get; set; }

        public virtual string Value { get; set; }
    }
}
