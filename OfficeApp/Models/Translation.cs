

using OfficeApp.Models.Providers;

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
