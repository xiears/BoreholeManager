using BoreholeData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeData.Entities
{
    public class CableBorehole : Borehole
    {
        public CableType CableType { get; set; }
        public string CableStrength { get; set; }
    }
}
