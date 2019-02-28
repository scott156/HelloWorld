using XFramework.Core.Abstractions.Error;
using XFramework.Soa.Abstractions.Error;

namespace HelloWorld.Service.Error
{
    public class GradeInfoServiceException : SoaServiceException
    {
        public GradeInfoServiceException(ErrorCode errorCode, string message) : base(errorCode, message)
        {
        }
    }
}
