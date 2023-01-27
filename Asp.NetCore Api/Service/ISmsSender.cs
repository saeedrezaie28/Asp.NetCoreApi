using Asp.NetCore_Api.Model;

namespace Api.Service
{
    public interface ISmsSender
    {
        void SendSms(SendSmsModel sendSms);
    }
}
