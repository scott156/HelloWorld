using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWorld.Contract.Grade;
using HelloWorld.Dal.Entity;
using HelloWorld.Service.Error;
using XFramework.Core.Abstractions.Error;
using XFramework.Core.Abstractions.Logger;
using XFramework.Dal.Interface;
using XFramework.Soa.Abstractions;
using XFramework.Soa.Abstractions.Data;
using XFramework.Soa.Abstractions.Error;

namespace HelloWorld.Service.Grade
{
    [Soa("helloworld", "querygrade")]
    public class QueryGrade : SoaService<QueryGradeRequestType, QueryGradeResponseType>
    {
        public override string Description => "年级信息查询";

        public override Dictionary<string, string> LogTag(QueryGradeRequestType request) => 
            new Dictionary<string, string>()
            {
                { "grade", request.GradeId }
            };
        

        public IGenericDaoService DaoService { get; set; }

        public override async Task<QueryGradeResponseType> Process(QueryGradeRequestType request)
        {
            logger.Info($"年级Id : {request.GradeId}");

            var grade = await DaoService.QueryByPk<BAGrade>(request.GradeId);
            if (grade == null)
            {
                throw new GradeInfoServiceException(ErrorCode.InternalError, $"无法查询到有效的年级信息 : {request.GradeId}");
            }
            
            return new QueryGradeResponseType()
            {
                Grade = new GradeInfoType()
                {
                    Enabled = grade.Enabled ?? 0,
                    Id = grade.ID,
                    Name = grade.Name
                }
            };
        }

        public override void Verify(QueryGradeRequestType request)
        {
            if (string.IsNullOrWhiteSpace(request.GradeId))
            {
                throw new SoaServiceVerifyException(ErrorCode.InvalidRequest, "GradeId is empty");
            }
        }
    }
}
