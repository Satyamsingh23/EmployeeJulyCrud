using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee.RequestDto
{
    public class UpdateEmployeeDto
    {
        public int EmpId { get; set; }

        [Required]

        [DefaultValue("")]
        public string EmpName { get; set; } = null!;

        [Required]

        [DefaultValue("")]
        public string EmpEmail { get; set; } = null!;

        [Required]
        public DateTime? Dob { get; set; }

        [Required]

        [DefaultValue("")]
        public int? EmpPhone { get; set; }

        [Required]

        [DefaultValue("")]
        public string? City { get; set; }
    }
}
