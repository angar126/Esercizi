using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public class Food : ServiceType
    {
        public TimeSpan ProcessingTime { get; }

        public Food(string name, TimeSpan processingTime)
        {
            Name = name;
            ProcessingTime = processingTime;
        }
    }
}
