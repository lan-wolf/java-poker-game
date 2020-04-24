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

namespace net.silverfoxserver.core.protocol
{
    public class RCClientAction
    {
        /// <summary>
        /// ֤����
        /// </summary>
        public static readonly string hasProof = "hasProof";

        /// <summary>
        /// ֤��
        /// ��config.xml�ļ�������
        /// </summary>
        public static string proof = "www.wdmir.net";

        /**
         * 
         */ 
        public static readonly String loadDBType = "loadDBType";

        /**
         * ע��
         */
        public static readonly String reg = "reg";
    
        /** 
         ��ѯ�Ƿ�ע���
        */
        public static readonly String hasReg = "hasReg";

        /** 
         ��½
        */
        public static readonly String login = "login";

        /// <summary>
        /// ��ȡ���
        /// </summary>
        public static readonly string loadG = "loadG";

        /// <summary>
        /// ���ֱ���
        /// </summary>
        public static readonly string loadChart = "loadChart";

        /// <summary>
        /// ����
        /// </summary>
        public static readonly String loadTopList = "loadTopList";

        /// <summary>
        /// �Խ�������ע���粻������עʧ��
        /// </summary>
        public static readonly string betG = "betG";

        /// <summary>
        /// ���½��
        /// </summary>
        public static readonly string updG = "updG";

        /// <summary>
        /// ��������
        /// </summary>
        public static readonly string updHonor = "updHonor";

        /// <summary>
        /// ���username��pwd(������������е�email�ֶ�ֵ�Ƿ���ƥ��
        /// </summary>
        public static readonly string chkUp = "chkUp";

        /// <summary>
        /// ���username��pwd(������������е�email�ֶ�ֵ�Ƿ���ƥ��
        /// ��ͨ����������DB��������ע��Э��
        /// </summary>
        public static readonly string chkUpAndGoDBReg = "chkUpAndGoDBReg";

        /// <summary>
        /// ���username��BBS�е�session�Ƿ�һ�£�
        /// ���䰲ȫ��̫�ͣ���ǿ��ȫ��
        /// </summary>
        public static readonly string chkUsAndGoDBLogin = "chkUsAndGoDBLogin";

        /// <summary>
        /// ÿ���һ����Ϸ����ͻ��ֶ�
        /// </summary>
        public static readonly string chkEveryDayLoginAndGet = "chkEveryDayLoginAndGet";

    }
}
