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
using net.silverfoxserver.core.model;
using net.silverfoxserver.core.logic;
using DdzServer.net.silverfoxserver.extmodel;
using DdzServer.net.silverfoxserver.extfactory;

namespace DdzServer.net.silverfoxserver.extmodel
{
    public class RuleModelByDdz : IRuleModel
    {
        /// <summary>
        /// һ�������������
        /// 3�˾��䶷����
        /// </summary>
        private readonly int _oneRoomChair = 3;

        /// <summary>
        /// һ��������Թ�����
        /// 
        /// ������ ����   ������
        /// �Թ��� �Թ��� �Թ���
        /// 
        /// ���� �Թ��� ������Ϊ3��
        /// </summary>
        private readonly int _oneRoomLookChair = 3;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getGameName()
        {
            return QiPaiName.Ddz;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getChairCount()
        {
            return _oneRoomChair;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getLookChairCount()
        {
            return _oneRoomLookChair;
        }



    }
}
