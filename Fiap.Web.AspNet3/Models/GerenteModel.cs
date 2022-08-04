using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("Gerente")]
    public class GerenteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RepresentanteId")]
        public int GerenteId { get; set; }

        [Required(ErrorMessage = "Digite o nome do Gerente")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o sobrenome do Gerente")]
        [StringLength(100)]
        public string Sobrenome { get; set; }




    }
}
