using BuildingBlocks.CQRS;
using MediatR;

namespace Catalog.API.Models.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>; //Inherited from MediatR Library
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create product.
            //Create Product Entity from Command Object

            var product = new Product { 
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,    
                ImageFile = command.ImageFile,  
                Price = command.Price
             };

            //Save the database.

            //Return CreateProductResult result.
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}

