using NDB.Domain.Values;

namespace NDB.Infra.Entities
{
    public class NHibernateExample : IExample
    {
        public virtual int Id { get; set; }
        public virtual string UUID { get; set; }
        public virtual string Title { get; set; }
        public virtual ExampleContent Content { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual string Search { get; set; }
    }
}
