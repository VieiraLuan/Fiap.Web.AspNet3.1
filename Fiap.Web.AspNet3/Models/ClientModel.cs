using Microsoft.AspNetCore.Mvc; /*Biblioteca Padrão*/
using System.ComponentModel.DataAnnotations;/*Biblioteca das Annotations*/
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("ClientAsp")]
    public class ClientModel
    {
        [Display(Name = "Id do Cliente")]
        [HiddenInput] /*Aqui definimos se ele é visivel ou nao*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }


        [Display(Name = "Nome")]
        [MaxLength(70, ErrorMessage = "Tamanho máximo do nome é 70 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(2, ErrorMessage = "Digite um nome com mais de 2 caracteres")]
        public string Name { get; set; }


        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Digite o E-mail com @")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }


        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "O campo data é obrigatório")]
        public DateTime Birth { get; set; } /*Quando definimos DataType ou EmailAdrres
                                              automaticamente no Form os campos se tornar do mesmo type*/

        /*Utilizamos ? para permitir que no html seja null, mas que 
         no model qnd usado a anotation required seja solicitado e retornar  
        o erro da anotation não do padrão do html*/

        [Display(Name = "Observação")] /*Display name é o nome que iremos definir dentro do label
                                        no html*/

        public string? Observation { get; set; }




        public int RepresentanteId { get; set; }

        [ForeignKey("RepresentanteId")]
        public RepresentanteModel? Representante { get; set; }



    }
}
