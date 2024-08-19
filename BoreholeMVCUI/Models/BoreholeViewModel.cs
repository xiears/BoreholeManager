using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoreholeMVCUI.Models
{
    public class BoreholeViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("X Position")]
        [Required]
        public int X { get; set; }

        [DisplayName("Y Position")]
        [Required]
        public int Y { get; set; }

        [DisplayName("Depth")]
        [Range(0, 500)]
        public decimal Depth { get; set; }
    }
}
