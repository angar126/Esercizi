using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public class Translation : ServiceType
    {
        public TimeSpan ProcessingTime { get; }

        public Translation(string name, TimeSpan processingTime)
        {
            Name = name;
            ProcessingTime = processingTime;
        }
    }
    
}
