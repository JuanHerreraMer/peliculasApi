using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using peliculasApi.Validaciones;

namespace peliculasApi.Entidades
{
    public class Genero : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10)]
        // [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Range(18, 120)]
        public int Edad { get; set; }

        [CreditCard]
        public string TarjetaCredito { get; set; }

        [Url]
        public string URL { get; set; }


        /**
        *
        *   Las validaciones por Modelo (IValidatableObject) solo se activan cuando las validaciones por attributos estén todas 
        * sin errores.
        *
        **/

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                    // yield es para agregar un valor al IEnumerable
                    yield return new ValidationResult("La primera letra debe ser Mayúscula",
                    new string[] { nameof(Nombre) });
                }
            }
        }
    }
}