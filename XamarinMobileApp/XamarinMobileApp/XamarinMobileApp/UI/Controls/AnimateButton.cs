using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace XamarinMobileApp.UI.Controls
{
    class AnimateButton : Button
    {
        public AnimateButton()
        {
            const int animationTime = 75;
            Clicked += async (sender, e) =>
            {
                try
                {
                    var btn = (AnimateButton)sender;
                    await btn.ScaleTo(1.2, animationTime);
                    await btn.ScaleTo(1, animationTime);
                    //await Task.Delay(400);
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                }
            };
        }
    }
}
