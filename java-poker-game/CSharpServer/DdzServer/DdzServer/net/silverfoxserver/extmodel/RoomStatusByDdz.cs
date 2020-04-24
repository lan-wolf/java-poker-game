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

namespace DdzServer.net.silverfoxserver.extmodel
{
    /// <summary>
    /// ����״̬
    /// 
    /// wait  -> can start     -> start(jiao fen)
    /// start -> can get dizhu -> start chu pai
    /// 
    /// start chu pai -> over
    /// 
    /// </summary>
    public class RoomStatusByDdz
    {
        /// <summary>
        /// �ȴ���ʼ
        /// </summary>
        public static bool isWaitStart(string value)
        {
            if (value.IndexOf("wait_start") > -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// �ȴ���ʼ
        /// </summary>
        public const String GAME_WAIT_START = "game_wait_start";

        /// <summary>
        /// ���Կ�ʼ
        /// </summary>
        public const String GAME_ALL_READY_WAIT_START = "game_all_ready_wait_start";

        /// <summary>
        /// �������ֶ�����,������Աȫ���߳�
        /// </summary>
        public const string GAMEOVER_ROOMCLEAR_WAIT_START = "gameover_roomclear_wait_start";

        /// <summary>
        /// ��Ϸ�������ȴ���ʼ
        /// </summary>
        public const String GAMEOVER_WAIT_START = "gameover_wait_start";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool isStart(string value)
        {
            if (value.IndexOf("game_start") > -1)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// ��ʼ
        /// ÿ�˷�17���ƣ�����ʼ�з�
        /// </summary>
        public const String GAME_START = "game_start";

        /// <summary>
        /// ��ʼ��ĵ�һ���յ�,
        /// �����з֣���������
        /// </summary>
        public const string GAME_START_CAN_GET_DIZHU = "game_start_can_get_dizhu";

        /// <summary>
        /// ����
        /// </summary>
        public const string GAME_START_CHUPAI = "game_start_chupai";
        
        
    }
}
