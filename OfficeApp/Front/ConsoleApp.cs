using OfficeApp.Models;
using OfficeApp.Models.Factories;
using OfficeApp.Models.Providers;

namespace OfficeApp.Front
{
    public class ConsoleApp
    {
        OfficeManager _officeManager;

        public ConsoleApp()
        {
           
        }
        public async void GetService()
        {
            bool input = true;
            while (input)
            {
                Console.Clear();
                _officeManager = new OfficeManager(new OfficeManagerOrderFactory());
                Console.WriteLine("Menu Principale:");
                Console.WriteLine("--------------------------------------------------------");
                string[] servicesString = { "Traduttore", "FoodDelivery", "Exit" };

                int scelta = Menu.CreateMenu(servicesString);
                
                Log.Show();
                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        TranslationProvider tp = _officeManager.ProcessTranslate();
                        Order<Translation> tordine = GetOrder<Translation>(tp);
                        Log.Show();
                        break;

                    case 2:
                        Console.Clear();
                        FoodProvider fp = _officeManager.ProcessFood();
                        Order<Food> fordine = GetOrder<Food>(fp);
                        Log.Show();
                        break;
                    case 3: input = false; break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

            }
        }
        
        public Order<T> GetOrder<T>(Provider<T> selectedProvider) where T : ServiceType
        {
            Order<T> orderItems = new Order<T>();
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Ordine numero: {orderItems.Id}");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Seleziona un elemento (premi o per confermare l'ordine):");
                Console.WriteLine("--------------------------------------------------------");

                for (int i = 0; i < selectedProvider.ListOfItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedProvider.ListOfItems[i].Name}".PadRight(20) + $"{selectedProvider.ListOfItems[i].Price} $");
                }

                if (orderItems != null && orderItems.List != null && orderItems.List.Count > 0)
                {
                    VisualizzaOrdine<T>(orderItems.List);
                }
                Console.WriteLine("--------------------------------------------------------");
                Log.Show();

                char scelta = Console.ReadKey().KeyChar;

                switch (scelta)
                {
                    case var c when char.IsDigit(c):
                        
                        int selectedItemIndex = int.Parse(scelta.ToString()) - 1;

                        if (selectedItemIndex >= 0 && selectedItemIndex < selectedProvider.ListOfItems.Count)
                        {
                            
                            T selectedItem = selectedProvider.ListOfItems[selectedItemIndex];
                            orderItems.List.Add(selectedItem);
                            Console.WriteLine($"Elemento '{selectedItem.Name}' aggiunto all'ordine.");
                        }
                        else
                        {
                            Console.WriteLine("Scelta non valida. Riprova.");
                        }
                        break;

                    case 'o':
                    case 'O':
                        Console.WriteLine("Ordine confermato.");
                        selectedProvider.EnqueueOrder(orderItems);
                        return orderItems;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }
        private void VisualizzaOrdine<T>(List<T> orderItems) where T : ServiceType
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Ordine corrente:");

            Dictionary<T, int> keyValuePairs = new Dictionary<T, int>();
            foreach (var item in orderItems)
            {
                if (keyValuePairs.ContainsKey(item))
                    keyValuePairs[item]++;
                else
                    keyValuePairs.Add(item, 1);
            }
            var values = keyValuePairs.OrderByDescending(x => x.Key.Price * x.Value);

            foreach (var item in values)
            {
                Console.WriteLine($"{item.Key.Name} x{item.Value}".PadRight(20) + $"{item.Key.Price * item.Value} $");
            }
        }

    }

}
