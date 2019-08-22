// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.BotBuilderSamples;
using Microsoft.Extensions.Logging;
using QnAPrompting.Dialogs;
using QnAPrompting.Helpers;


namespace QnAPrompting.Bots
{
    // This IBot implementation can run any type of Dialog. The use of type parameterization is to allows multiple different bots
    // to be run at different endpoints within the same project. This can be achieved by defining distinct Controller types
    // each with dependency on distinct IBot types, this way ASP Dependency Injection can glue everything together without ambiguity.
    // The ConversationState is used by the Dialog system. The UserState isn't, however, it might have been used in a Dialog implementation,
    // and the requirement is that all BotState objects are saved at the end of a turn.
    public class QnABot : DialogBot<QnADialog>
    {
        public QnABot(ConversationState conversationState, UserState userState, IQnAService qnaService, ILogger<QnABot> logger)
             : base(conversationState, userState, new QnADialog(qnaService), logger)
        {
        }


        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                // Greet anyone that was not the target (recipient) of this message.
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hola, soy el asesor virtual Finesa"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Puedo asesorarlo con los siguientes temas:"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Saldo total"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Pago a través de nuestro portal web"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Levantamiento de prenda"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Paz y salvo"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Estado de cuenta / Factura"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Endoso de póliza"), cancellationToken);
                   
                }
            }
        }
    }
}
