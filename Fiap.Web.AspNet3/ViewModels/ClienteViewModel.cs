using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet3.ViewModels
{


    public class ClienteViewModel
    {
        [Display(Name = "Id do Cliente")]
        [HiddenInput]
        [Key]
        public int ClientId { get; set; }
        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo do nome é de 70 caracteres!")]
        [MinLength(2, ErrorMessage = "Digite um nome com mais de dois caracteres")]
        public string Name { get; set; }
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "Digite corretamente o e-mail")]
        [Required(ErrorMessage = "Digite o e-mail do cliente")]
        public string Email { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Selecione a data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        public DateTime? Birth { get; set; }
        [Display(Name = "Observação")]
        public string? Observation { get; set; }
        public int RepresentanteId { get; set; }
        public RepresentanteViewModel? Representante { get; set; }
    }

}
