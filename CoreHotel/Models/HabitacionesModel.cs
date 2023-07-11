using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class HabitacionesModel
    {
        [Key]
        public int Id_Habitacion { get; set; }
        [Required]
        public int Id_TipoHabitacion { get; set; }
        [ForeignKey("Id_TipoHabitacion")]
        public TipoHabitacionModel TipoHabitacionModel { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string descripcion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Precio { get; set; }

        public bool Is_deleted { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_at { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Updated_at { get; set; }
    }
}
