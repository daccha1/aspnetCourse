using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class PersonUpdateRequest
    {
   
            [Required(ErrorMessage = " ID MUST BE PROVIDED ")]
            public Guid? PersonId { get; set; }
            [Required(ErrorMessage = "Person name is a mandatory input.")]
            public string? PersonName { get; set; }
            [EmailAddress(ErrorMessage = "Email is mandatory input.")]
            public string? Email { get; set; }
            [Required]
            public string? Gender { get; set; }
            [Required]
            public DateTime? DOB { get; set; }
            [Required]
            public string? Adress { get; set; }
            [Required]
            public Guid? CountryId { get; set; }

    }

}

