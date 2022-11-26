using System;
using System.ComponentModel.DataAnnotations;
using car_rentals_project.Validations;
using car_rentals_project.Models;
using System.ComponentModel.DataAnnotations.Schema;//Add this component to foreign keys


namespace car_rentals_project.Models
{
    public class Rental
    {
        public Rental() => CriadoEm = DateTime.Now;
        public int RentalId { get; set; }

        public int ClientId { get; set; } 
         [ForeignKey("ClientId")]// Foreign key
        public Client Client { get; set; } // Reference navigation

        public int AutomobileId { get; set; } 
        [ForeignKey("AutomobileId")]// Foreign key
        public Automobile Automobile { get; set; } // Reference navigation

        [Required(ErrorMessage = "O campo preço é obrigatório!")]
        public double Total_Price { get; set; }
      
        public double Total_Days { get; set; }

        public double Total_Days_Price { get; set; }

        public string Start_Date { get; set; }
 
        public string End_Date { get; set; }
 
        public DateTime CriadoEm { get; set; }
    }
}
