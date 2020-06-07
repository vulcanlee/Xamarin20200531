using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace XF2028.iOS
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

        void Turn(bool isShow)
        {
            if (isShow)
            {
                UIApplication.SharedApplication.StatusBarHidden = false;
            }
            else
            {
                UIApplication.SharedApplication.StatusBarHidden = true;
            }

        }
    }
}