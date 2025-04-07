using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person
    {
        
        public string? PersonName { get; set; }
        public string? Email {  get; set; }
        public string? Phone { get; set; }
        public string? Password {  get; set; }
        public string? ConfirmPassword {  get; set; }
        public double? Price { get; set;}

        public override string ToString()
        {
            return $"{PersonName}-{Email}-{Phone}-{Password}-{ConfirmPassword}-{Price}";
        }



    }
}
