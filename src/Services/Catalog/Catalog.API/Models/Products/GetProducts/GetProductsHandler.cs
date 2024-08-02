namespace Catalog.API.Models.Products.GetProducts
{
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10)
        : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler
        (IDocumentSession session)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                //.Where(x => x.Price < 500)
                .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
            
            return new GetProductsResult(products);
        }
    }
}
