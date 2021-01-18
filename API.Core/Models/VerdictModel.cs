using Common.Enum;

namespace API.Core
{
    public class VerdictModel : BaseModel
    {
        public string Fio { get; set; }
        
        public int Age { get; set; }
        
        public VerdictEnum Verdict { get; set; }
    }
}