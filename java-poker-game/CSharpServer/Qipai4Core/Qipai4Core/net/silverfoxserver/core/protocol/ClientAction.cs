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

namespace net.silverfoxserver.core.protocol
{
    /// <summary>
    /// ��ͻ���QiPaiClient ��Send�����ַ������Ӧ
    /// 
    /// const �൱���� static readonly
    /// </summary>
    public static class ClientAction
    {
        public static readonly string verChk = "verChk";

         /**
         *  ����ϵͳ�����ݿ����ͣ�ȫ��
         */
        public static readonly String loadDBType = "loadDBType";

        public static readonly String hasReg = "hasReg";

        public static readonly string reg = "reg";

        public static readonly string login = "login";
        
        public static readonly string listRoom = "listRoom";

        public static readonly string listModule = "listModule";

        public static readonly string pubMsg = "pubMsg";

        //��������
        public static readonly string pubAuMsg = "pubAuMsg";

        public static readonly string joinRoom = "joinRoom";

        public static readonly string joinReconnectionRoom = "joinReconnectionRoom";

        public static readonly string autoJoinRoom = "autoJoinRoom";

        public static readonly string autoMatchRoom = "autoMatchRoom";

        /// <summary>
        /// ���غ����б�
        /// </summary>
        public static readonly string loadB = "loadB";

        /// <summary>
        /// ���ؿ����û��б�
        /// </summary>
        public static readonly string loadD = "loadD";

        /// <summary>
        /// ˢ�½��
        /// </summary>
        public static readonly string loadG = "loadG";

        /// <summary>
        /// ��ע
        /// </summary>
        public static readonly string setBetVars = "setBetVars";

        //�����������
        //׼������Ϸ�����������
        public static readonly string setRvars = "setRvars";

        //���������Զ��򿪵��ʼ�ϵͳ
        public static readonly string setMvars = "setMvars";

        /// <summary>
        /// ģ��ϵͳ��������
        /// </summary>
        public static readonly string setModuleVars = "setModuleVars";

        /// <summary>
        /// �뿪���䣬�ص�����
        /// </summary>
        public static readonly string leaveRoom = "leaveRoom";

        /// <summary>
        /// �뿪���䣬ת������ƥ�����
        /// </summary>
        public static readonly string leaveRoomAndGoHallAutoMatch = "leaveRoomAndGoHallAutoMatch";

        /// <summary>
        /// �ر���ҳ��ģ��
        /// </summary>
        public static readonly string sessionClosed = "sessionClosed";

        /// <summary>
        /// ����Э��
        /// </summary>
        public static readonly string heartBeat = "heartBeat";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string loadChart = "loadChart";



    }
}
