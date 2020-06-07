using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XF2028.Droid
{
    class StatusBarOnOff : IStatusBarOnOff
    {
        public void TurnOff()
        {
            Turn(false);
        }

        public void TurnOn()
        {
            Turn(true);
        }

        public void Turn(bool isShow)
        {
            var activity = (Activity)Xamarin.Forms.Forms.Context;
            if (isShow)
            {
                activity.Window.ClearFlags(WindowManagerFlags.Fullscreen);
            }
            else
            {
                activity.Window.AddFlags(WindowManagerFlags.Fullscreen);
            }
        }
    }
}