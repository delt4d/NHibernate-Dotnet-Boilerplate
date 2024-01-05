namespace NDB.Infra.Providers
{
    public class UUIDProvider
    {
        public static string GenerateUUID(string prefix)
        {
            Guid guid = Guid.NewGuid();
            return $"{prefix.ToUpper()}_{guid}";
        }
    }
}
