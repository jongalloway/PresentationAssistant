using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationAssistant.ZoomEditorMargin
{
    internal class ZoomMargin : IWpfTextViewMargin, ITextViewMargin, IDisposable
    {
        public const string MarginName = "ZoomMargin";
        private PresentationAssistant.ZoomEditorMargin.ZoomControl.ZoomControl zoomControl = new PresentationAssistant.ZoomEditorMargin.ZoomControl.ZoomControl();
        FrameworkElement IWpfTextViewMargin.VisualElement
        {
            get
            {
                return this.zoomControl;
            }
        }
        bool ITextViewMargin.Enabled
        {
            get
            {
                return true;
            }
        }
        double ITextViewMargin.MarginSize
        {
            get
            {
                return this.zoomControl.RenderSize.Height;
            }
        }
        public ZoomMargin(IWpfTextView textView)
        {
            this.zoomControl.DataContext = new ZoomViewModel(textView);
        }
        ITextViewMargin ITextViewMargin.GetTextViewMargin(string marginName)
        {
            if (!(marginName == "ZoomMargin"))
            {
                return null;
            }
            return this;
        }
        void IDisposable.Dispose()
        {
        }
    }
}
