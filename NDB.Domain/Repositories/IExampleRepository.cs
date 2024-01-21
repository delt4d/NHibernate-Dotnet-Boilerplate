using NDB.Domain.Entities;
using System.Collections.Generic;

namespace NDB.Domain.Repositories
{
    public interface IExampleRepository : IRepository<Example>
    {
        public IList<Example> FindAll();
        public void UpdateByUUID(string uuid, Dictionary<string, string> dataToUpdate);
        public Example Create(Example data);
    }
}
