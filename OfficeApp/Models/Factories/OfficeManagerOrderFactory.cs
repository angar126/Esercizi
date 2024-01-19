
namespace OfficeApp.Models.Factories
{
    public class OfficeManagerOrderFactory : AbstractFactoryServices
    {
        //public IOffice Office { get; set; }
        
        public override DeliveryOffice CreateFoodOffice()
        {
            return DeliveryOffice.GetInstance();
        }

        public override TranslationOffice CreateTranslateOffice()
        {
            return TranslationOffice.GetInstance();
        }
    }
}
