using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;
namespace PresentationAssistant.GlobalZoom
{
	[TextViewRole("DOCUMENT"), ContentType("text"), Export(typeof(IWpfTextViewCreationListener))]
	internal sealed class GlobalZoomFactory : IWpfTextViewCreationListener
	{
		public void TextViewCreated(IWpfTextView textView)
		{
			new GlobalZoom(textView);
		}
	}
}