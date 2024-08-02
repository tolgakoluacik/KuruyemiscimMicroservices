using Catalog.API.Models;
using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            session.Store<Product>(GetPreConfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("0190d713-bb25-4862-a695-4783c88befe3"),
                Name = "Özel Antep Fıstığı",
                Category = new List<string> { "Kavrulmuş Ürünler"},
                Description = "Antep Fıstık Gaziantep yöresine aittir,\r\nAntep Fıstığı Ana çıtlak cinsi fıstıkdır tamamı ile ağızları açıktır.Firmamızın özel ürünü olduğu için tamamı ile seçme bir fıstıktır iri tanelidir.\r\nBesin değeri protein olarak çok faydalıdır.\r\nÜrünlerimiz kendi imalthanemizde tek tek özenle seçilmektedir, memnun kalırsınız.",
                ImageFile = "ozel-antep-fistik.jpg",
                Price = 1050
            },
            new Product()
            {
                Id = new Guid("0190cd6f-96f3-471a-b1af-d30369fa0187"),
                Name = "Özel Antep Fıstığı",
                Category = new List<string> { "Kavrulmuş Ürünler"},
                Description = "Tuzlu Fıstık Osmaniye yöremize  aittir, \r\n\r\nYer Fıstık, vücudumuz için sağlığımıza faydalıdır. Bu özelliğinden dolayı alternatif tıp alanında hastalıkların tedavisinde kullanılmasını sağlamaktadır.\r\n\r\nYer Fıstığı protein ve karbonhidrat içerdiği için sporcular özellikle tüketmektedir.\r\n\r\nTuzlu Fıstık, Özel Taş Tabanlı Fırınımızda Kavrulduğu için çok lezzetlidir ve seçme bir fıstık olduğu için İri tanelidir.\r\n\r\nÜrünlerimiz kendi imalthanemizde tek tek özenle seçilmektedir, memnun kalırsınız.",
                ImageFile = "tuzlu-fistik-ici.jpg",
                Price = 350
            },
            new Product()
            {
                Id = new Guid("0190d7fe-4491-472e-928d-5971ec11e9e7"),
                Name = "Özel Kahramanmaraş Ceviz İçi",
                Category = new List<string> { "Doğal Ürünler"},
                Description = "Özel Kahramanmaraş Ceviz İçi\r\n\r\nÖzel Maraş Ceviz İçi, Kahramanmaraş Sütçü İmam Üniversitesi Ziraat Fakültesi tarafından çalışması yapılıp araştırması yapılan, dünyadaki en kaliteli ceviz olarak litaratüre giren tescilli bir üründür.\r\n\r\nCeviz tüketimi kandaki kolesterol seviyesini düşürüyor, kalp atışlarında düzensizliği önlüyor. Beyne benzeyen ceviz, kavrama ve anlamayı geliştiriyor.\r\n\r\nCevizin, antioksidan özelliği dolayısıyla sinir sistemine zarar veren parkinson ve alzheimer gibi çok kuvvetli hastalıkların gelişimini erteleyebileceği veya azaltabileceği ileri sürülüyor.\r\n\r\n \r\n\r\nÖNEMLİ TAVSİYE: Ceviz içi hassas doğal ürün olduğu için  uzun süre tazeliğini koruması için buzdolabında saklanmasını tavsiye ederiz. Rutubetli ortamlarda saklanması durumunda tazeliğinin kaybolmasının yanısıra bozulmasına sebep olabilir.\r\n\r\n ",
                ImageFile = "tuzlu-fistik-ici.jpg",
                Price = 350
            }
        };
    }
}
