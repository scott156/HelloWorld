using System;
using XFramework.Soa.Abstractions.Contract;

namespace HelloWorld.Contract.Grade
{
    public class QueryGradeRequestType : SoaRequestType
    {
        public string GradeId { get; set; }
    }
}
