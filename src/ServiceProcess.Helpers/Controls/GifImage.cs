using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ServiceProcess.Helpers.Controls
{
    //Adapted from: http://stackoverflow.com/questions/210922/how-do-i-get-an-animated-gif-to-work-in-wpf/1134340#1134340
    internal class GifImage : Image
    {

        public int FrameIndex
        {
            get { return (int)GetValue(FrameIndexProperty); }
            set { SetValue(FrameIndexProperty, value); }
        }

        public static readonly DependencyProperty FrameIndexProperty =
            DependencyProperty.Register("FrameIndex", typeof(int), typeof(GifImage), new UIPropertyMetadata(0, new PropertyChangedCallback(ChangingFrameIndex)));



        public Uri AnimationSource
        {
            get { return (Uri)GetValue(AnimationSourceProperty); }
            set { SetValue(AnimationSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnimationSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationSourceProperty =
            DependencyProperty.Register("AnimationSource", typeof(Uri), typeof(GifImage), new UIPropertyMetadata(null, (o, e) => LoadSource(o as GifImage, e.NewValue as Uri)));



        static void LoadSource(GifImage control, Uri source)
        {
            
            if (source == null)
            {
                control.Source = null;
            }
            else
            {
                control.gf = new GifBitmapDecoder(source, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                control.anim = new Int32Animation(0, control.gf.Frames.Count - 1, new Duration(new TimeSpan(0, 0, 0, control.gf.Frames.Count / 10, (int)((control.gf.Frames.Count / 10.0 - control.gf.Frames.Count / 10) * 1000))));
                control.anim.RepeatBehavior = RepeatBehavior.Forever;
                control.Source = control.gf.Frames[0];
            }
        }
        

        static void ChangingFrameIndex(DependencyObject obj, DependencyPropertyChangedEventArgs ev)
        {
            GifImage ob = obj as GifImage;
            ob.Source = ob.gf.Frames[(int)ev.NewValue];
            ob.InvalidateVisual();
        }
        internal GifBitmapDecoder gf;
        internal Int32Animation anim;

        bool animationIsWorking = false;
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            if (!animationIsWorking)
            {
                BeginAnimation(FrameIndexProperty, anim);
                animationIsWorking = true;
            }
        }
    }
}
