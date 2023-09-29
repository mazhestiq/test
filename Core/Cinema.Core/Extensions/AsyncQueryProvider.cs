using System.Linq.Expressions;

namespace Cinema.Core.Extensions
{
    internal class AsyncQueryProvider<T> : IQueryProvider
    {
        private readonly IQueryProvider _source;

        public AsyncQueryProvider(IQueryProvider source)
        {
            _source = source;
        }

        public IQueryable CreateQuery(Expression expression) =>
            _source.CreateQuery(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) =>
            new AsyncQueryable<TElement>(_source.CreateQuery<TElement>(expression));

        public object Execute(Expression expression) => Execute<T>(expression);

        public TResult Execute<TResult>(Expression expression) =>
            _source.Execute<TResult>(expression);
    }
}