using System;
using System.Collections.Generic;
using System.Text;

namespace SelfWashSystem.Abstractions.Models
{
    public class Configuration
    {
        public string CompanyName { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
