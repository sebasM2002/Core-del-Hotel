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

        [Required]
        public int Id_Habitacion { get; set; }

        public bool? check_In { get; set; }
        [Required]
        public string Fecha_Entrada{ get; set; }

        [Required]
        public string Fecha_Salida { get; set; }

        [Required]
        public int Cantidad { get; set; }
        public bool? is_Deleted { get; set; }

        [Required]

        public string Created_at { get; set; }

        public string? Updated_at { get; set; }


    }
}
