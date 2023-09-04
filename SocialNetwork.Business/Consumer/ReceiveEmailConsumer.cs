using MassTransit;
using SocialNetwork.Core.Utilities.EmailHelper;
using SocialNetwork.Entities.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Consumer
{
    // ReceiveEmailConsumer
    public class ReceiveEmailConsumer : IConsumer<SendEmailCommand>
    {
        private readonly IMailHelper _mailHelper;

        public ReceiveEmailConsumer(IMailHelper mailHelper)
        {
            _mailHelper = mailHelper;
        }

        public async Task Consume(ConsumeContext<SendEmailCommand> context)
        {
            _mailHelper.SendEmail(context.Message.Email, context.Message.Token, true);
        }
    }
}
