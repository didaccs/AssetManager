namespace AssetManager.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string objectNotFound, string keyNotFound)
            : base($"Element \"{objectNotFound}\" ({keyNotFound}) not found.")
        {
        }
    }
}