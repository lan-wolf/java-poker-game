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

namespace net.silverfoxserver.core.licensing
{
    public class LicenseManager
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<LicenseModel> _licensedArr = new List<LicenseModel>();

        
        /// <summary>
        /// ԭ����50���ָĳ�100
        /// 2014��4�£��־���ȥ���������ƣ��ĳɹ�������
        /// �����ĳ�1000
        /// �ָĳɺ�JAVA��ͬ2000
        /// </summary>
        public const int FREE_PEOPLE = 2000;

        private static List<LicenseModel> licensedArr
        {
            get {

                if (0 == _licensedArr.Count)
                {

                    LicenseModel free = new LicenseModel("QQ:521266750", 0, 20121222, "Ddz", FREE_PEOPLE, "", "free version");
                    _licensedArr.Add(free);                                        

                }

                return _licensedArr;
            
            }
        
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payUserName"></param>
        /// <returns></returns>
        public static int getMaxOnlinePeople(string payUser,string payGame)
        {           
        
            //
            int jLen = licensedArr.Count;

            for (int j = 0; j < jLen; j++)
            {
                if (licensedArr[j].payUser == payUser &&
                    (licensedArr[j].payGame == payGame || "Security" == payGame)
                    )
                {
                    return licensedArr[j].maxOnlinePeople;
                }
            
            }

            //free
            return licensedArr[0].maxOnlinePeople;
        
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string getPayUserNickName(string value)
        { 
           int len = licensedArr.Count;

           for (int i = 0; i < len; i++)
           {
               if (licensedArr[i].payUser == value)
               {
                   return licensedArr[i].payUserNickName;
               }
           }

           return "";
        
        }



    }



}
