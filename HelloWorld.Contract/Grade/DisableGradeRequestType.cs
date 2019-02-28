using XFramework.Soa.Abstractions.Contract;

namespace HelloWorld.Contract.Grade
{
    public class DisableGradeRequestType : SoaRequestType
    {
        public string GradeId { get; set; }

        public int GradeStatus { get; set; }
    }
}
