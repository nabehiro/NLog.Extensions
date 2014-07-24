using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Extensions.Targets
{
    /// <summary>
    /// HipChat API v1
    /// https://www.hipchat.com/docs/api/method/rooms/message
    /// </summary>
    [Target("HipChat")]
    public class HipChatTarget : TargetWithLayout
    {
        private const string EndPoint = "https://api.hipchat.com/v1/rooms/message?format=json&auth_token=";

        [RequiredParameter]
        public string AuthToken { get; set; }

        [RequiredParameter]
        public string RoomId { get; set; }
        
        [DefaultValue("Nlog.HipChat")]
        public string From { get; set; }

        [DefaultValue(true)]
        public bool Notify { get; set; }

        [DefaultValue("yellow")]
        public string Color { get; set; }

        [DefaultValue("text")]
        public string MessageFormat { get; set; }

        public HipChatTarget()
        {
            From = "Nlog.HipChat";
            Notify = true;
            Color = "yellow";
            MessageFormat = "text";
        }

        protected override void Write(LogEventInfo logEvent)
        {
            var message = Layout.Render(logEvent) ?? "";
            if (message.Length > 1000)
                message = message.Substring(0, 1000);
            if (From.Length > 15)
                From = From.Substring(0, 15);

            var client = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            var data = new NameValueCollection();
            data["room_id"] = RoomId;
            data["from"] = From;
            data["message_format"] = MessageFormat;
            data["message"] = message;

            var resByte = client.UploadValues(EndPoint + AuthToken, data);
            var resStr = Encoding.UTF8.GetString(resByte);
        }
    }
}
