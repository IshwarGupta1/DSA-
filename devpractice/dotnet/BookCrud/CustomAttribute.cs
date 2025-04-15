using System.ComponentModel.DataAnnotations;

namespace BookCrud
{
    public class CustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is DateTime dateValue)
            {
                return dateValue < DateTime.Now;
            }
            return true;
        }
    }
}
