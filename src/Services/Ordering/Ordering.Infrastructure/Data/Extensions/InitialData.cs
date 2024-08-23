namespace Ordering.Infrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("b47ed515-0e92-4ef7-ab8d-9d24f140c37b")), "Tolga Koluaçık", "tolgakoluacik@outlook.com"),
                Customer.Create(CustomerId.Of(new Guid("5b5b4afd-ea01-4012-80c2-d0e601868e2e")), "Beyza Ural Koluaçık", "beyzaural.2642@gmail.com")
            };
        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("5ce51d2f-fd7a-4ac9-83a0-88ebd20f6263")), "Iphone X", 500),
                Product.Create(ProductId.Of(new Guid("94a4450a-7888-4ba1-accc-104780a94196")), "Samsung S24 Ultra", 299)
            };
        public static IEnumerable<Order> OrderWithItems
        {
            get
            {
                var address1 = Address.Of("Tolga", "Koluaçık", "tolgakoluacik@outlook.com", "Kepez Mah.", "Turkey", "Antalya", "07090");
                var address2 = Address.Of("Beyza", "Ural Koluaçık", "beyzaural.2642@gmail.com", "Kepez Mah.", "Turkey", "Antalya", "07090");

                var payment1 = Payment.Of("Tolga Koluaçık", "5555444433332222", "08/25", "444", 1);
                var payment2 = Payment.Of("Beyza Ural Koluaçık", "5555444433332222", "02/28", "123", 2);

                var order1 = Order.Create(
                        OrderId.Of(Guid.NewGuid()),
                        CustomerId.Of(new Guid("b47ed515-0e92-4ef7-ab8d-9d24f140c37b")),
                        OrderName.Of("Order 1"),
                        shippingAddress: address1,
                        billingAddress: address1,
                        payment1
                    );
                order1.Add(ProductId.Of(new Guid("5ce51d2f-fd7a-4ac9-83a0-88ebd20f6263")), 2, 500);
                order1.Add(ProductId.Of(new Guid("94a4450a-7888-4ba1-accc-104780a94196")), 1, 299);

                var order2 = Order.Create(
                        OrderId.Of(Guid.NewGuid()),
                        CustomerId.Of(new Guid("5b5b4afd-ea01-4012-80c2-d0e601868e2e")),
                        OrderName.Of("Order 2"),
                        shippingAddress: address2,
                        billingAddress: address2,
                        payment2
                    );
                order2.Add(ProductId.Of(new Guid("5ce51d2f-fd7a-4ac9-83a0-88ebd20f6263")), 1, 500);
                order2.Add(ProductId.Of(new Guid("94a4450a-7888-4ba1-accc-104780a94196")), 3, 299);

                return new List<Order> { order1, order2 };
            }
        }
    }
}