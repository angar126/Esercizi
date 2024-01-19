using OfficeApp.Models.Providers;

namespace OfficeApp.Models.Factories
{
    public class OfficeManager
    {
        private AbstractFactoryServices _orderFactory;

        public OfficeManager(OfficeManagerOrderFactory orderFactory)
        {
            _orderFactory = orderFactory;
        }
        public FoodProvider ProcessFood()
        {
            var foodOffice = _orderFactory.CreateFoodOffice();
            var foodProvider = foodOffice.GetProvider();
            return foodProvider;
        }
        public TranslationProvider ProcessTranslate()
        {
            var translationOffice = _orderFactory.CreateTranslateOffice();
            var translationProvider = translationOffice.GetProvider();
            return translationProvider;
        }
    }
}
