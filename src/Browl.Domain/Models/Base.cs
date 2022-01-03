using Browl.Core.Base;
using System;
using System.Collections.Generic;

namespace Browl.Domain.Entities
{
    public abstract class Base : IDeleteEntity, IAuditEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}