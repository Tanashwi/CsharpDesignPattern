using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountFactory> {
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("US")
};

foreach (var factory in factories)
{
    var discount = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discount.DiscountPercentage} " + $"coming from {discount}");
}