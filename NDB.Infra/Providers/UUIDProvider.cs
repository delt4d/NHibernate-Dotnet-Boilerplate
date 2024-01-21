namespace NDB.Infra.Providers
{
    public static class UUIDProvider
    {
        public static string GenerateUUID(string prefix)
        {
            Guid guid = Guid.NewGuid();
            return $"{prefix.ToUpper()}_{guid}";
        }
    }
}
