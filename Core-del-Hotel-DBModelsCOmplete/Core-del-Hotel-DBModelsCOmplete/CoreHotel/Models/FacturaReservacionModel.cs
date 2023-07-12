using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class FacturaReservacionModel
    {
        [Key]
        public int Id_Transaccion { get; set; }

        [Required]
        public int Id_Reservacion { get; set; }
        [ForeignKey("Id_Reservacion")]
        public ReservacionesModel ReservacionesModel { get; set; }

        [Required]
        public int Id_TipoTransaccion { get; set; }
        [ForeignKey("Id_TipoTransaccion")]
        public TipoTransModel TipoTransModel{ get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal monto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


    }
}
