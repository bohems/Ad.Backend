namespace Application.Common.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string entityName, string key)
            : base($"Access to entity {entityName} ({key}) is denied")
        {

        }
    }
}
