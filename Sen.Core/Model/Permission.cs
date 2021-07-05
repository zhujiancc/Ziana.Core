namespace Sen.Core
{
    public class Permission : SenAuditEntity
    {
        public string Name { get; set; }

        public string Level { get; set; }
    }
}