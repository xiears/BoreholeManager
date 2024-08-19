using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoreholeMVCUI.Models
{
    public class BoreholeViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("X Position")]
        [Required(ErrorMessage = "This field is required")]
        public int X { get; set; }

        [DisplayName("Y Position")]
        [Required(ErrorMessage = "This field is required")]
        public int Y { get; set; }

        [DisplayName("Depth")]
        [Range(0, 500)]
        [Required(ErrorMessage = "This field is required")]
        public decimal Depth { get; set; }
    }
}
