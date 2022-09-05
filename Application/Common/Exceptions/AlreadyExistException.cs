namespace Application.Common.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string entityName, string key)
            : base($"Entity '{entityName}' ({key}) already exist") { }
    }
}
