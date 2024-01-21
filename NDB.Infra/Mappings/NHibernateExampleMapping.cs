namespace NDB.Infra.Mappings
{
    public class NHibernateExampleMapping : ClassMap<NHibernateExample>
    {
        public NHibernateExampleMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Increment()
                .Column("Id");

            Map(c => c.UUID)
                .Unique()
                .Not.Nullable()
                .Column("UUID");

            Map(c => c.Title)
                .Not.Nullable()
                .Column("Title");

            Component(
                x => x.Content,
                c => c.Map(content => content.Value)
                    .Not.Nullable()
                    .Length(255)
                    .Column("Value")
            );

            Map(c => c.CreatedAt)
                .Not.Nullable()
                .Column("CreatedAt");

            Map(c => c.UpdatedAt)
                .Column("UpdatedAt");

            Table("Example");
        }
    }
}
