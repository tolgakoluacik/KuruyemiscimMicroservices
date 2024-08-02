namespace Catalog.API.Models.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>; //Inherited from MediatR Library
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required!");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is Required!");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is Required!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is Required!");
        }
    }
    internal class CreateProductCommandHandler
        (IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
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

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //Return CreateProductResult result.
            return new CreateProductResult(product.Id);
        }
    }
}

