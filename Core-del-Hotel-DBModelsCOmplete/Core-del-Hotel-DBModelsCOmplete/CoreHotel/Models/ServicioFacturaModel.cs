using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class ServicioFacturaModel
    {
        [Required]
        public int Id_servicio { get; set; }

        [Required]
        public int Id_Factura{ get; set; }

    }
}
