using BoreholeData.Entities;
using BoreholeData.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoreholeMVCUI.Models
{
    public class DrillViewModel : BoreholeViewModel
    {
        public DrillViewModel()
        {
            
        }
        public DrillViewModel(DrillBorehole borehole)
        {
            this.Id = borehole.ID;
            this.X = borehole.X;
            this.Y = borehole.Y;
            this.Depth = borehole.Depth;
            this.DrillType = borehole.DrillType;
            this.DrillStrength = borehole.DrillStrength;
        }

        [DisplayName("Drill Type")]
        [Required]
        public DrillType DrillType { get; set; }


        [DisplayName("Drill Strength")]
        [Required]
        public string DrillStrength { get; set; }
    }
}
