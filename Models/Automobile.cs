using System;
using System.ComponentModel.DataAnnotations;
using API_Folhas.Validations;

namespace API_Folhas.Models
{
    public class Automobile
    {
        public Automobile() => CriadoEm = DateTime.Now;
        public int AutomobileId { get; set; }

        public enum Type { car, motorcycle, van };
        public Type Type { get; set; }

        [Required(ErrorMessage = "O campo preço por dia é obrigatório!")]
        public float Price_per_day { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório!")]
        public string Year { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}