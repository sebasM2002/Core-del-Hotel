using System.ComponentModel.DataAnnotations;

namespace CoreHotel.Models
{
    public class TipoHabitacionModel
    {
        [Key]
        public int Id_TipoHabitacion { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string descripcion { get; set; }
    }
}
