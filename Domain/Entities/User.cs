
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities
{
    public abstract class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; }
        public bool Activo { get; set; } = true;

        /*
        [Column(TypeName = "nvarchar(20)")]
        public string UserType { get; set; }*/
    }

}
