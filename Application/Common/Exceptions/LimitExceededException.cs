namespace Application.Common.Exceptions
{
    public class LimitExceededException : Exception
    {
        public LimitExceededException(string entityType, string userId) 
            : base($"'{entityType}' creation limit for user ({userId}) exceeded")
        {

        }
    }
}
