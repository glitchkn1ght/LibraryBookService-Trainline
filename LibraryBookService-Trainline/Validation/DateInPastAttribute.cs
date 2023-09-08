using System.ComponentModel.DataAnnotations;

namespace LibraryBookService_Trainline.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,AllowMultiple = false)]
    public class DateInPastAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must be earlier than the current date.";
        
        public DateInPastAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date, DateTime.Now) <0)
            {
                return true;
            }

            return false;    
        }
    }
}
