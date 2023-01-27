using Api.Service;
using Asp.NetCore_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace Asp.NetCore_Api.Controllers
{
    [Route("api/v1/[controller]/Send")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        [HttpPost(Name = "Send")]
        public async Task<OperationResult<string>> Send(SendSmsModel sendSmsModel)
        {
            var re = Request;
            var headers = re.Headers;

            ISmsSender smsSender;

            if (headers.ContainsKey("Sender"))
            {
                var sender = headers.TryGetValue("Sender", out StringValues va);
                string senderService = va.ToString();

                if (senderService == "Kavenegar")
                {
                    smsSender = new KavenegarService();
                }
                else if (senderService == "MohsenNegar")
                {
                    smsSender = new MohsenNegarService();
                }
                else
                {
                    return new OperationResult<string>()
                    {
                        Succeess = false,
                        Message = "سرویس ارسال کننده پیامک در سیستم یافت نشد"
                    };
                }

                smsSender.SendSms(sendSmsModel);
                return new OperationResult<string>()
                {
                    Succeess = true,
                    Message = "با موفقیت ارسال شد",
                    Data = " : سرویس ارسال پیامک" + senderService
                };
            }
            else
            {
                return new OperationResult<string>()
                {
                    Succeess = false,
                    Message = "سرویس ارسال کننده پیامک دریافت نشد"
                };
            }
        }
    }
}
