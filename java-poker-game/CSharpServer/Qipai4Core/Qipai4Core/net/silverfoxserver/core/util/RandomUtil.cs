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
using System.Security.Cryptography;

namespace net.silverfoxserver.core.util
{
    public class RandomUtil
    {
        /// <summary>
        /// ������ÿ����������,ֵ����һ��
        /// 
        /// ע�⵽MSDN�н���Random.NextBytes��������ʱ��
        /// ����һ�仰��Ҫ�����ʺ��ڴ����������ļ��ܰ�ȫ�������
        /// ��ʹ���� RNGCryptoServiceProvider.GetBytes �����ķ���������
        /// ��������������΢���Ѿ����ֳɵĶ���������������룬�����ǾͿ������������ˡ�
        /// ���Ǿ��������������ǵ�������ӡ�
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetRandSeed()
        {
            byte[] bytes = new byte[32];//int��32λ, 2��32�η�

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

    }


}
