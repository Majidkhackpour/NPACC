using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MihaZupan;
using Telegram.Bot;

namespace PacketParser.Services
{
   public class SendErrorToTelegram
    {
        public SendErrorToTelegram()
        {

        }
        private class NestedCallInfo
        {
            internal static SendErrorToTelegram _instence = new SendErrorToTelegram();

            public NestedCallInfo()
            {
            }
        }

        public static SendErrorToTelegram Send => NestedCallInfo._instence;
        private TelegramBotClient bot;
        public void StartSending(string message, string fileName)
        {
            var token = @"937505998:AAEio5mETihkBgLyERRb8KhJG8A1g8SCMXQ";
            var proxy = new HttpToSocks5Proxy("s2.10g2.cf", 8085, "p7", "341") { ResolveHostnamesLocally = false };
            bot = new TelegramBotClient(token, proxy);
            var ts = new Thread(new ThreadStart(async () => await Send_(message, fileName)));
            ts.Start();
        }
        private async Task Send_(string message, string fileName)
        {
            try
            {
                await SendMessageAsync(message, fileName);
            }
            catch
            {
            }
        }
        private string GetChatId()
        {
            var chatid = "@ErrorHandlerAdvertise";
            return chatid;
        }
        private async Task SendMessageAsync(string message, string fileName)
        {
            try
            {
                var picFile = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                await bot.SendPhotoAsync(GetChatId(), picFile, message);
            }
            catch (HttpRequestException) { }
            catch (Telegram.Bot.Exceptions.BadRequestException)
            {
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException)
            {
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
