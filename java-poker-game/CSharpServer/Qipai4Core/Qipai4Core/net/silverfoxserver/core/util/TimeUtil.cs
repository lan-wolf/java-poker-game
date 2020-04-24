﻿/*
* SilverFoxServer: massive multiplayer game server for Flash, ...
* VERSION:3.0
* PUBLISH DATE:2015-9-2 
* GITHUB:github.com/wdmir/521266750_qq_com
* UPDATES AND DOCUMENTATION AT: http://www.silverfoxserver.net
* COPYRIGHT 2009-2015 SilverFoxServer.NET. All rights reserved.
* MAIL:521266750@qq.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.silverfoxserver.core.util
{
    public class TimeUtil
    {


        public static void setTimeout(double interval, Action action)
        {

            System.Timers.Timer timer = new System.Timers.Timer(interval);

            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
            {
                timer.Enabled = false;
                action();


            };

            timer.Enabled = true;
        }





    }
}
