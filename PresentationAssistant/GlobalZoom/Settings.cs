using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PresentationAssistant.GlobalZoom.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0"), CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}
		[DefaultSettingValue("100"), UserScopedSetting, DebuggerNonUserCode]
		public double LastZoomLevel
		{
			get
			{
				return (double)this["LastZoomLevel"];
			}
			set
			{
				this["LastZoomLevel"] = value;
			}
		}
		[DefaultSettingValue("20"), UserScopedSetting, DebuggerNonUserCode]
		public double MinZoomLevel
		{
			get
			{
				return (double)this["MinZoomLevel"];
			}
			set
			{
				this["MinZoomLevel"] = value;
			}
		}
		[DefaultSettingValue("400"), UserScopedSetting, DebuggerNonUserCode]
		public double MaxZoomLevel
		{
			get
			{
				return (double)this["MaxZoomLevel"];
			}
			set
			{
				this["MaxZoomLevel"] = value;
			}
		}
	}
}
