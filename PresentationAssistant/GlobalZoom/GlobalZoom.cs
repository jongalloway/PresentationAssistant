using Microsoft.VisualStudio.Text.Editor;
using PresentationAssistant.GlobalZoom.Properties;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
namespace PresentationAssistant.GlobalZoom
{
    public class GlobalZoom
    {
        private IWpfTextView _view;
        private string _zoomPropertyName;
        private bool _bFirst;
        public GlobalZoom(IWpfTextView view)
        {
            this._view = view;
            this._zoomPropertyName = GlobalZoom.GetPropertyName<double>(() => Settings.Default.LastZoomLevel);
            this._bFirst = true;
            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(this.Default_PropertyChanged);
            this._view.LayoutChanged += (new EventHandler<TextViewLayoutChangedEventArgs>(this.LayoutChanged));
            this._view.ZoomLevelChanged += (new EventHandler<ZoomLevelChangedEventArgs>(this.ZoomLevelChanged));
            this._view.Closed += (new EventHandler(this.ViewClosed));
        }
        private void ViewClosed(object sender, EventArgs e)
        {
            this._view.LayoutChanged -= (new EventHandler<TextViewLayoutChangedEventArgs>(this.LayoutChanged));
            this._view.ZoomLevelChanged -= (new EventHandler<ZoomLevelChangedEventArgs>(this.ZoomLevelChanged));
            this._view.Closed -= (new EventHandler(this.ViewClosed));
            Settings.Default.PropertyChanged -= new PropertyChangedEventHandler(this.Default_PropertyChanged);
            this._view = null;
        }
        private void LayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            if (this._bFirst)
            {
                this._bFirst = false;
                this.SetZoomLevel(this._view);
            }
        }
        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.SetZoomLevel(this._view);
        }
        private bool SetZoomLevel(IWpfTextView _view)
        {
            try
            {
                if (!_view.IsClosed && !this._bFirst && _view.ZoomLevel != Settings.Default.LastZoomLevel && Settings.Default.LastZoomLevel >= Settings.Default.MinZoomLevel && Settings.Default.LastZoomLevel <= Settings.Default.MaxZoomLevel)
                {
                    _view.ZoomLevel = (Settings.Default.LastZoomLevel);
                    return true;
                }
            }
            catch (NullReferenceException)
            {
            }
            return false;
        }
        private void ZoomLevelChanged(object sender, ZoomLevelChangedEventArgs e)
        {
            if (sender != this && Settings.Default.LastZoomLevel != e.NewZoomLevel)
            {
                Settings.Default.LastZoomLevel = e.NewZoomLevel;
                Settings.Default.Save();
            }
        }
        private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
    }
}
