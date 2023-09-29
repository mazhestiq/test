namespace Cinema.Core.HttpContext
{
    public interface IRequestContextProvider
    {
        IRequestContext Context { get; }
    }
}
