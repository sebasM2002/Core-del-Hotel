
using System.ComponentModel.DataAnnotations;

namespace CoreHotel.DTO
{
    public class RoleDTO
    {
        [Key]
        public int Rol_Id{ get; set; }
        public string Name { get; set; }
    }
}
