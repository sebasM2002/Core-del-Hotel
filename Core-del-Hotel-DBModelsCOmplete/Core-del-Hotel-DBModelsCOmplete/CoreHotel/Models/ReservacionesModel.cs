using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class ReservacionesModel
    {
        [Key]
        public int Id_Reservacion { get; set; }

        [Required]
        public int Id_Huesped { get; set; }
        [ForeignKey("Id_Huesped")]
        public HuespedModel HuespedModel { get; set; }

        [Required]
        public int Id_Habitacion { get; set; }
        [ForeignKey("Id_Habitacion")] 
        public HabitacionesModel HabitacionModel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Entrada{ get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Salida { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_at { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Updated_at { get; set; }


    }
}
