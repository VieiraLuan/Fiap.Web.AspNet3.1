using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet3.ViewModels
{
    public class RepresentanteViewModel
    {
        [Key]
        public int RepresentanteId { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeRepresentante { get; set; }
    }
}
