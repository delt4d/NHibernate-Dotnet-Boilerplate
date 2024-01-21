using AutoMapper;

namespace NDB.Infra.Persistence
{
    public class NHibernateExampleRepository(ISession session, IMapper mapper) : IExampleRepository
    {
        private readonly ISession _session = session;
        private readonly IMapper _mapper = mapper;

        public Example DeleteByUUID(string uuid)
        {
            var examples = _session.Query<NHibernateExample>()
                .Where(c => c.UUID.Equals(uuid))
                .ToList();

            if (examples.Count == 0)
                throw new Exception("Example with UUID " + uuid + " not found");

            IQuery q = _session.CreateQuery("delete from Example where uuid = :uuid");
            q.SetString("uuid", uuid);
            q.ExecuteUpdate();

            return _mapper.Map<Example>(examples.ElementAt(0));
        }

        public IList<Example> FindAll()
        {
            var q = _session.Query<NHibernateExample>();
            var list = q.ToList();

            return _mapper.Map<List<Example>>(list);
        }

        public Example FindByUUID(string uuid)
        {
            throw new NotImplementedException();
        }

        public void Save(ref Example data)
        {
            data.Validate();
            _session.Update(_mapper.Map<NHibernateExample>(data));
        }

        public Example Create(Example data)
        {
            using var transaction = _session.BeginTransaction();

            data.UUID = UUIDProvider.GenerateUUID("example");
            data.Validate();

            _session.Save(_mapper.Map<NHibernateExample>(data));

            transaction.Commit();

            return data;
        }

        public void UpdateByUUID(string uuid, Dictionary<string, string> dataToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
