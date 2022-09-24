using System.ComponentModel.DataAnnotations;
using System.Linq;
using car_rentals_project.Models;

namespace car_rentals_project.Validations
{
    public class CpfEmUso : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;

            DataContext context =
                (DataContext)
                validationContext.
                GetService(typeof(DataContext));

            Client resultado =
                context.Client.FirstOrDefault
                (
                    f => f.Cpf.Equals(cpf)
                );
            return resultado == null ?
                ValidationResult.Success :
                new ValidationResult("Esse Cliente já existe!");
        }
    }
}