using System.Collections.Generic;
using XFramework.Soa.Abstractions.Contract;

namespace HelloWorld.Contract.Grade
{
    public class QueryAllGradeResponseType : SoaResponseType
    {
        public List<GradeInfoType> Grades { get; set; }
    }
}
