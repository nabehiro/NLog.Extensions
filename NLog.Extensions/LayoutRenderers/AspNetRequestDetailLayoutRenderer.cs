using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NLog.Extensions.LayoutRenderers
{
    [LayoutRenderer("aspnet-request-detail")]
    public class AspNetRequestDetailLayoutRenderer : LayoutRenderer
    {
        private const string _mask = "*****";

        [DefaultValue("password,pass")]
        public string MaskKeys { get; set; }
        private string[] _maskKeys;

        public AspNetRequestDetailLayoutRenderer()
        {
            MaskKeys = "password,pass";
        }

        protected override void Append(StringBuilder sb, LogEventInfo logEvent)
        {
            if (HttpContext.Current == null) return;
            var request = HttpContext.Current.Request;
            if (request == null) return;

            sb.AppendFormat("[URL] {0}\n", request.Url);
            sb.AppendFormat("[Raw URL] {0}\n", request.RawUrl);
            sb.AppendFormat("[Client IP] {0}\n", request.UserHostAddress);
            sb.AppendFormat("[HTTP Method] {0}\n", request.HttpMethod);
            
            sb.Append("[Form]\n");
            foreach (var key in request.Form.AllKeys)
                sb.AppendFormat("    [{0}] {1}\n", key, GetMasked(key, request.Form[key]));
            
            sb.Append("[Request Headers]\n");
            foreach (var key in request.Headers.AllKeys)
                sb.AppendFormat("    [{0}] {1}\n", key, GetMasked(key, request.Headers[key]));
        }

        protected override void InitializeLayoutRenderer()
        {
            base.InitializeLayoutRenderer();
            _maskKeys = (MaskKeys ?? "").ToLower().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }

        private string GetMasked(string key, string val)
        {
            return _maskKeys.Contains(key.ToLower()) ? _mask : val;
        }

        
    }
}
