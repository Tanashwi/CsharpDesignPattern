namespace FactoryMethod
{
    //open/closed principle
    //single responsibility principle
   public abstract class DiscountService
   {
            public abstract int DiscountPercentage {get;}
            public override string ToString() => GetType().Name;
   }

   ///Concrete implementation
   public class CountryDiscountService: DiscountService
   {
        private readonly string _countryIdentifier;
        public CountryDiscountService(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    case "US":
                        return 10;
                    default:
                        return 20;
                }
            }
        }
}

    public class CodeDiscountService: DiscountService
    {
        private readonly Guid _code;

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscountPercentage
        {
            get => 15;
        }
    }

//Factory implementation = I could have created separate file, but keeping in same file for learning purpose

    //Creator
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();        
    }

    //Concreate implementation

    public class CountryDiscountFactory: DiscountFactory
    {
        private readonly string _countryIdentifier;

        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }

    public class CodeDiscountFactory: DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }
}