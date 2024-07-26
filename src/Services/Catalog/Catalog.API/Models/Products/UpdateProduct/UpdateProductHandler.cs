
namespace Catalog.API.Models.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsUpdated);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("ID is required!");
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required!")
                .Length(2, 250).WithMessage("Name's length has to be in 2, 250");
            RuleFor(command => command.Price)
                .NotEmpty().WithMessage("Price is required!")
                .GreaterThan(0).WithMessage("Price has to be greater than 0");
        }
    }
    internal class UpdateProductCommandHandler
        (IDocumentSession session, ILogger<UpdateProductResult> logger)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null) 
            {
                throw new ProductNotFoundException(command.Id);
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
