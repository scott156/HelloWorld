using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWorld.Contract.Grade;
using HelloWorld.Dal.Entity;
using HelloWorld.Service.Error;
using XFramework.Core.Abstractions.Error;
using XFramework.Dal.Interface;
using XFramework.Soa.Abstractions;
using XFramework.Soa.Abstractions.Contract;
using XFramework.Soa.Abstractions.Data;

namespace HelloWorld.Service.Grade
{
    [Soa("helloworld", "queryallgrade")]
    public class QueryAllGrade : SoaService<SoaRequestType, QueryAllGradeResponseType>
    {
        public override string Description => "查询所有年级信息";

        public override Dictionary<string, string> LogTag(SoaRequestType request) => null;

        public IGenericDaoService DaoService { get; set; }

        public override async Task<QueryAllGradeResponseType> Process(SoaRequestType request)
        {
            // 根据条件进行查询
            var grade = await DaoService.QueryLike<BAGrade>(new BAGrade()
            {
                Enabled = 1
            });

            if (grade == null || grade.Count == 0)
            {
                throw new GradeInfoServiceException(ErrorCode.InternalError, "无有效的年级信息");
            }

            return new QueryAllGradeResponseType()
            {
                Grades = grade.ConvertAll(p => new GradeInfoType()
                {
                    Enabled = p.Enabled ?? 0,
                    Id = p.ID,
                    Name = p.Name
                })
            };
        }

        public override void Verify(SoaRequestType request)
        {
        }
    }
}
