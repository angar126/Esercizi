using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public class DinnerProvider : FoodProvider
    {
        public override TimeSpan OpenTime => new(14, 00, 00);
        public override TimeSpan CloseTime => new(24, 00, 00);

        public DinnerProvider()
        {
            ListOfItems = new List<Food>{
             new Food("Arrosto", TimeSpan.FromSeconds(10)){ Price = 1},
             new Food("Spaghetti", TimeSpan.FromSeconds(10)){ Price = 1},
             new Food("Torta", TimeSpan.FromSeconds(2)){ Price = 1},
            };
        }
    }
}
