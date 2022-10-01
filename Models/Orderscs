using System;
using System.ComponentModel.DataAnnotations;
using car_rentals_project.Validations;
using car_rentals_project.Models;
using System.ComponentModel.DataAnnotations.Schema;//Add this component to foreign keys


namespace car_rentals_project.Models
{
    public class Orders
    {
        public Orders() => CriadoEm = DateTime.Now;
        public int OrdersId { get; set; }

        public int ClientId { get; set; } 
         [ForeignKey("ClientId")]// Foreign key
        public Client Client { get; set; } // Reference navigation

        public int AutomobileId { get; set; } 
        [ForeignKey("AutomobileId")]// Foreign key
        public Automobile Automobile { get; set; } // Reference navigation

        [Required(ErrorMessage = "O campo preço é obrigatório!")]
        public float Total_Price { get; set; }
      
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
