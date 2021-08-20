using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace xamarinFormsApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

          
        }
        double WidthPercent=1;
        double HeightPercent = 1;
        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            Color ff = Color.FromRgb(249, 249, 249);
            SKPaint paint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = ff.ToSKColor(),
            };
            float x = (float)(info.Width*WidthPercent);
            float y = (float)(info.Height*HeightPercent);

            paint.ImageFilter = SKImageFilter.CreateDropShadow(0, 15, 20, 20, SKColors.Black.WithAlpha(0x40));
            canvas.DrawRoundRect(info.Width / 2 - (x/2), info.Height / 2 - (y/2), x, y, 20, 20, paint);

        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            WidthPercent = grid2.WidthRequest / Width;
            HeightPercent = grid2.HeightRequest / Height;
        }


        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var myButton = sender as Button;
            if (myButton.ClassId=="ok")
            {
                label1.Text = "OK";
            }
            else
            {
                label1.Text = "Canceled";
            }
            var parentAnimation = new Animation();
            var Animation1 = new Animation(v => myPopUp.Scale = v, 1, 1.3, Easing.CubicOut);
            var Animation2 = new Animation(v => myPopUp.Opacity = v, 1, 0, Easing.CubicOut);
            var Animation3 = new Animation(v => labelTitle.TranslationX = v, 0, 80, Easing.CubicOut);
            var Animation4 = new Animation(v => OkButton.TranslationY = CancelButton.TranslationY =rect.TranslationY = v, 0, 30, Easing.CubicOut);
            parentAnimation.Add(0, 0.7, Animation1);
            parentAnimation.Add(0, 0.7, Animation2);
            parentAnimation.Add(0, 0.7, Animation3);
            parentAnimation.Add(0, 0.7, Animation4);
            parentAnimation.Commit(this, "ChildAnimations", 16, 700, null, null);
            myPopUp.InputTransparent = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var parentAnimation = new Animation();
            var Animation1 = new Animation(v => myPopUp.Scale = v, 1.3, 1, Easing.CubicOut);
            var Animation2 = new Animation(v => myPopUp.Opacity = v, 0, 1, Easing.CubicOut);
            var Animation3 = new Animation(v => labelTitle.TranslationX = v, 80, 0, Easing.CubicOut);
            var Animation4 = new Animation(v => OkButton.TranslationY = CancelButton.TranslationY = rect.TranslationY = v, 30, 0, Easing.CubicOut);
            parentAnimation.Add(0, 0.7, Animation1);
            parentAnimation.Add(0, 0.7, Animation2);
            parentAnimation.Add(0, 0.7, Animation3);
            parentAnimation.Add(0, 0.7, Animation4);
            parentAnimation.Commit(this, "ChildAnimations", 16, 700, null, null);
            myPopUp.InputTransparent = false;
        }
    }
}
