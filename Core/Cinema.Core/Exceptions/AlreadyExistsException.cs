namespace Cinema.Core.Exceptions
{
    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException()
        {
        }

        public AlreadyExistsException(string message) : base(message)
        {
        }
    }
}