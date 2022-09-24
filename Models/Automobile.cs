using System;
using System.ComponentModel.DataAnnotations;


namespace car_rentals_project.Models
{
    public class Automobile
    {
        public Automobile() => CriadoEm = DateTime.Now;
        
        public int AutomobileId { get; set; }

        public string Type { get; set; }

        public string models { get; set; }

        public string brand { get; set; }

        [Required(ErrorMessage = "O campo preço por dia é obrigatório!")]
        public float Price_per_day { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório!")]
        [StringLength(
            4,
            MinimumLength = 4,
            ErrorMessage = "O ano deve ter 4 dígitos!"
        )]

        public string Year { get; set; }

        public DateTime CriadoEm { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória!")]
        [StringLength(
            8,
            MinimumLength = 7,
            ErrorMessage = "A placa deve conter de 7 a 8 dígitos!"
        )]
        public string placa { get; set; }
    }
}