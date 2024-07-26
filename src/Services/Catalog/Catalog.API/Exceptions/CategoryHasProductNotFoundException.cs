namespace Catalog.API.Exceptions
{
    public class CategoryHasProductNotFoundException : Exception
    {
        public CategoryHasProductNotFoundException() : base("Category Has Product Not Found!")
        { 
        }
    }
}
