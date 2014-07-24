using NLog.LayoutRenderers;
using NLog.LayoutRenderers.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Extensions.LayoutRenderers.Wrappers
{
    [LayoutRenderer("truncate")]
    class TruncateLayoutRendererWrapper : WrapperLayoutRendererBase
    {
        public int Length { get; set; }

        [DefaultValue("...")]
        public string TruncateString { get; set; }

        public TruncateLayoutRendererWrapper()
        {
            TruncateString = "...";
        }

        protected override string Transform(string text)
        {
            text = text ?? "";
            return text.Length == 0 || (Length > 0 && text.Length <= Length) ?
                text : text.Substring(0, Length - TruncateString.Length) + TruncateString;
        }
    }
}
