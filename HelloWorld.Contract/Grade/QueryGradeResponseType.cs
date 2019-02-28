using XFramework.Soa.Abstractions.Contract;

namespace HelloWorld.Contract.Grade
{
    public class QueryGradeResponseType : SoaResponseType
    {
        public GradeInfoType Grade { get; set; }
    }
}
