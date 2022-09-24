using System;
using System.ComponentModel.DataAnnotations;
using car_rentals_project.Validations;
using car_rentals_project.Models;


namespace car_rentals_project.Models
{
    public class Order
    {
        public Order() => CriadoEm = DateTime.Now;
        public int OrderId { get; set; }

        public int? ClientId { get; set; } // Foreign key
        public Client Client { get; set; } // Reference navigation

        public int? AutomobilelId { get; set; } // Foreign key
        public Automobile Automobile { get; set; } // Reference navigation

        [Required(ErrorMessage = "O campo preço é obrigatório!")]
        public float Total_Price { get; set; }

        [Required(ErrorMessage = "O campo cpf é obrigatório!")]
        [StringLength(
            11, //Máximo de caracteres
            MinimumLength = 11,
            ErrorMessage = "O cpf deve conter 11 caracteres!"
        )]
        [CpfEmUso]
        public string Total_Days { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Start_Date { get; set; }

        [StringLength(
            14,
            MinimumLength = 14,
            ErrorMessage = "O número de celular deve possuir 12 caracteres (DDD)999999999"
        )]
        public string End_Date { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}