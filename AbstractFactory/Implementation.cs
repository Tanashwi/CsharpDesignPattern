namespace AbstractFactory
{
    //Interface
   public interface IShoppingCartPurchaseFactory
   {
    IDiscountService CreateDiscountService();
    IShippingCostsService CreateShippingCostsService();
   }

   public interface IDiscountService
   {
    int DiscountPercentage {get;}
   }

    //Concrete implementation
   public class BeligiumDiscountService: IDiscountService
   {
    public int DiscountPercentage => 20;
   }

    public class FranceDiscountService: IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    //Interface
   public interface IShippingCostsService
   {
    decimal ShippingCosts {get;} 
   }

   //Concrete Implementation

   public class BeligiumShippingCostsService: IShippingCostsService
   {
    public decimal ShippingCosts => 20;
   }

   public class FranceShippingCostsService: IShippingCostsService
   {
    public decimal ShippingCosts => 25;
   }

   //Concreate Implementation of AbstractFactory

   public class BelgiumShoppingCartPurchaseFactory: IShoppingCartPurchaseFactory
   {
        public IDiscountService CreateDiscountService()
        {
            return new BeligiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BeligiumShippingCostsService();
        }
   }

   public class FranceShoppingCartPurchaseFactory: IShoppingCartPurchaseFactory
   {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
   }

//Client Class

        public class ShoppingCart
        {
            private readonly IDiscountService _discountService;
            private readonly IShippingCostsService _shippingCostsService;
            private int _orderCosts;

            //Constructor
            public ShoppingCart(IShoppingCartPurchaseFactory factory)
            {
                _discountService = factory.CreateDiscountService();
                _shippingCostsService = factory.CreateShippingCostsService();
                _orderCosts = 200;
            }

            public void CalculateCosts()
            {
                Console.WriteLine($"Total costs=" + 
                $"{_orderCosts - (_orderCosts/100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
            }
        }

}



