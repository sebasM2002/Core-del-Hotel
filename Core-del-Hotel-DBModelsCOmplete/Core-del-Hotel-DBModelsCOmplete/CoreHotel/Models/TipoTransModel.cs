using System.ComponentModel.DataAnnotations;

namespace CoreHotel.Models
{
    public class TipoTransModel
    {
        [Key]
        public int Id_TipoTransaccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion  { get; set; }
    }
}
