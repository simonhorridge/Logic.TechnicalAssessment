using Logic.TechnicalAssement.App.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Logic.TechnicalAssement.App.Models
{
    public class LeaveViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Leave Type")]
        public LeaveTypeEnum LeaveType { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Start Date")]
        [HalfDayValidation] 
        public DateTime? StartDate { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("End Date")]
        [HalfDayValidation]
        public DateTime? EndDate { get; set; }

        [HalfDayValidation]
        [DisplayName("Is Half Day")]
        public bool IsHalfDay {  get; set; }
    }
    public enum LeaveTypeEnum
    {
        [Display(Name = "Annual Leave")]
        AnnualLeave,
        [Display(Name = "Sick Leave")]
        SickLeave,
        [Display(Name = "Compassionate Leave")]
        CompassionateLeave,
        [Display(Name = "Unpaid Leave")]
        UnpaidLeave,
    }
}
