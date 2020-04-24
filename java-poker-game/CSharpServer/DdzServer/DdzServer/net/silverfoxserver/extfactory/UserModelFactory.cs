/*
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
using System.Text;
//
using net.silverfoxserver.core.logic;
using DdzServer.net.silverfoxserver.extlogic;
//
using net.silverfoxserver.core.model;
using DdzServer.net.silverfoxserver.extmodel;

namespace DdzServer.net.silverfoxserver.extfactory
{
    public static class UserModelFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns> 
        public static IUserModel Create(string strIpPort,string id, Int64 id_sql, string sex, string accountName, string nickName, string bbs, string headIco)
        {
            
            return new UserModelByDdz(strIpPort,id, id_sql, sex, accountName, nickName, bbs, headIco);
            
        }

        public static IUserModel Create()
        {

            return new UserModelByDdz();
           
        }
    }
}
