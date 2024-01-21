namespace NDB.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        public void Save(ref T data);
        public T DeleteByUUID(string uuid);
        public T FindByUUID(string uuid);
    }
}
