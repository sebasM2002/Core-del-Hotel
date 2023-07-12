using System.ComponentModel.DataAnnotations;

namespace CoreHotel.Models
{
    public class ServicioModel
    {
        [Key]   
        public int Id_servicio { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set;}

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }

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
