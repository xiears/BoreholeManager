using BoreholeData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeData.Entities
{
    public class DrillBorehole : Borehole
    {
        public DrillType DrillType { get; set; }
        public string DrillStrength { get; set; }
    }
}
