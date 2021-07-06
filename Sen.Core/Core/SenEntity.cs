using System;

namespace Sen.Core
{
    public interface ISenEntity { }

    public class SenEntity<T> : ISenEntity where T : struct
    {
        public int Id { get; set; }

        public string Code { get; set; } = Guid.NewGuid().ToString("N");

    }

    public class SenAuditEntity<T> : SenEntity<T> where T : struct
    {
        public DateTime CreatedWhen { get; set; }

        public T CreatedBy { get; set; }

        public DateTime? UpdatedWhen { get; set; }

        public T UpdatedBy { get; set; }
    }

    public class SenFullEntity<T> : SenAuditEntity<T> where T : struct
    {
        public DateTime? DeletedWhen { get; set; }

        public T DeletedBy { get; set; }

        public bool IsDelete { get; set; }
    }

    public class SenEntity : SenEntity<int> { }
    public class SenAuditEntity : SenAuditEntity<int> { }
    public class SenFullEntity : SenFullEntity<int> { }
}