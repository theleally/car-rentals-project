using System;
using System.ComponentModel.DataAnnotations;
using API_Folhas.Validations;

namespace API_Folhas.Models
{
    public class Client
    {
        public Client() => CriadoEm = DateTime.Now;
        public int ClientId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo cpf é obrigatório!")]
        [StringLength(
            11, //Máximo de caracteres
            MinimumLength = 11,
            ErrorMessage = "O cpf deve conter 11 caracteres!"
        )]
        [CpfEmUso]
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [StringLength(
            14,
            MinimumLength = 14,
            ErrorMessage = "O número de celular deve possuir 12 caracteres (DDD)999999999"
        )]
        public string Cellphone { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}