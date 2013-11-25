using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationAssistant.ZoomEditorMargin
{
    [MarginContainer("BottomControl")]
    [TextViewRole("ZOOMABLE")]
    [ContentType("any")]
    [Name("ZoomMargin")]
    [Order(After = PredefinedMarginNames.HorizontalScrollBar)]
    [Export(typeof(IWpfTextViewMarginProvider))]
    internal sealed class ZoomMarginFactory : IWpfTextViewMarginProvider
    {
        public IWpfTextViewMargin CreateMargin(IWpfTextViewHost host, IWpfTextViewMargin margin)
        {
            return new ZoomMargin(host.TextView);
        }
    }
}
