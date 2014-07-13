namespace Bocami.Practices.Query
{
    /// <summary>
    /// Handles a TQuery by returning the default of TQueryResult
    /// </summary>
    /// <typeparam name="TQuery">The type of Query</typeparam>
    /// <typeparam name="TQueryResult">The type of QueryResult</typeparam>
    public sealed class NullQueryHandler<TQuery, TQueryResult> : IQueryHandler<TQuery, TQueryResult>
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
        public TQueryResult Handle(TQuery query)
        {
            return default(TQueryResult);
        }
    }
}
