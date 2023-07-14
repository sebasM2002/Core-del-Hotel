using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class HabitacionesModel
    {
        [Key]
        public int Id_Habitacion { get; set; }
  

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string descripcion { get; set; }

        [Required]
        public int Limite { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Precio_por_noche { get; set; }

        public bool? Is_deleted { get; set; }

        public string Created_at { get; set; }

        public string? Updated_at { get; set; }
    }
}
