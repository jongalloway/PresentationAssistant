using Microsoft.VisualStudio.Text.Editor;
using PresentationAssistant.ZoomEditorMargin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationAssistant.ZoomEditorMargin
{
    internal class ZoomViewModel : ViewModelBase
    {
        private IWpfTextView _view;
        private double _Zoom;
        public double Zoom
        {
            get
            {
                return this._Zoom;
            }
            set
            {
                if (this._Zoom != value)
                {
                    this._Zoom = value;
                    base.OnPropertyChanged("Zoom");
                }
            }
        }
        public double MaxZoom
        {
            get;
            private set;
        }
        public double MinZoom
        {
            get;
            private set;
        }
        public ICommand StretchCommand
        {
            get;
            private set;
        }
        public ZoomViewModel(IWpfTextView view)
        {
            this._view = view;
            this._view.ZoomLevelChanged += (delegate(object s, ZoomLevelChangedEventArgs e)
            {
                this.Zoom = e.NewZoomLevel;
            });
            base.PropertyChanged += delegate(object s, PropertyChangedEventArgs e)
            {
                if (this._view.ZoomLevel != this.Zoom)
                {
                    this._view.ZoomLevel = (this.Zoom);
                }
            };
            if(this.Zoom != _view.ZoomLevel) this.Zoom = _view.ZoomLevel;
            this.MinZoom = 20.0;
            this.MaxZoom = 400.0;
            this.StretchCommand = new DelegateCommand(new Action(this.Stretch));
        }
        private void Stretch()
        {
            this._view.ViewScroller.ScrollViewportHorizontallyByPixels(-this._view.MaxTextRightCoordinate);
            double num = (this._view.ViewportWidth - 100.0) / this._view.MaxTextRightCoordinate;
            Console.WriteLine("{0} / {1} = {2}", this._view.ViewportWidth, this._view.MaxTextRightCoordinate, num);
            this.Zoom = (double)((int)Math.Round(this.Zoom * num));
        }
    }
}
