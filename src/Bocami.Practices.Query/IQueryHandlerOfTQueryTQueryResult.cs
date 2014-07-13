namespace Bocami.Practices.Query
{
    /// <summary>
    /// Handles a TQuery and returns a TQueryResult. 
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TQueryResult"></typeparam>
    public interface IQueryHandler<in TQuery, out TQueryResult> 
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
        TQueryResult Handle(TQuery query);
    }
}
