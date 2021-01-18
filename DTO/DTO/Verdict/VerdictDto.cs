using System.ComponentModel.DataAnnotations;
using Common.Enum;

namespace DTO.Verdict
{
    public class VerdictDto : BaseDto
    {
        [Required]
        public string Fio { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        public VerdictEnum Verdict { get; set; }
    }
}