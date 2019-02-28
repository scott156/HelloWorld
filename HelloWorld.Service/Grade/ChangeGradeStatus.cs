using HelloWorld.Contract.Grade;
using HelloWorld.Dal.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using XFramework.Configuration.Client;
using XFramework.Core.Abstractions.Error;
using XFramework.Core.Abstractions.Logger;
using XFramework.Dal.Interface;
using XFramework.Soa.Abstractions;
using XFramework.Soa.Abstractions.Contract;
using XFramework.Soa.Abstractions.Data;
using XFramework.Soa.Abstractions.Error;

namespace HelloWorld.Service.Grade
{
    [Soa("helloworld", "changegradestatus")]
    public class ChangeGradeStatus : SoaService<DisableGradeRequestType, SoaResponseType>
    {
        public override string Description => "修改年级的状态（是否启用）";

        public override Dictionary<string, string> LogTag(DisableGradeRequestType request) => null;

        /// <summary>
        /// 数据库访问服务
        /// </summary>
        public IGenericDaoService DaoService { get; set; }

        /// <summary>
        /// 配置中心
        /// </summary>
        public IDynamicConfigProvider configProvider = DynamicConfigFactory.GetInstance("10001.properties");

        /// <summary>
        /// 修改年级的状态
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override async Task<SoaResponseType> Process(DisableGradeRequestType request)
        {
            logger.Info($"Grade Id : {request.GradeId}, status : {request.GradeStatus}");

            // 读取配置中心的数据
            if (configProvider.GetBooleanProperty("DisableGradeSwitch") == false)
            {
                logger.Info("开关处于关闭状态, 不进行数据库更新");
                return new SoaResponseType();
            }

            // 更新数据库 + 事务处理
            using (var scope = new TransactionScope())
            {
                await DaoService.Update(new BAGrade()
                {
                    ID = request.GradeId,
                    Enabled = request.GradeStatus
                });

                scope.Complete();
            }
            
            return new SoaResponseType();
        }

        public override void Verify(DisableGradeRequestType request)
        {
            if (string.IsNullOrWhiteSpace(request.GradeId))
            {
                throw new SoaServiceVerifyException(ErrorCode.InvalidRequest, "Grade id is empty");
            }
        }
    }
}
