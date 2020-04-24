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
using System.Xml;

namespace net.silverfoxserver.core.model
{
    /// <summary>
    /// RoomModel�ڿͻ��˱���ΪHallRoomModel��RoomModel
    /// </summary>
    public interface IRoomModel
    {
        int Id{get;}

        int getId();

        int Tab { get; }

        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void setName(string value);

        /// <summary>
        /// �Ƿ�Ϊ�������Զ�ƥ�䷿��
        /// </summary>
        /// <returns></returns>
        bool isTabAutoMatchMode();

        /// <summary>
        /// �������Զ�ƥ�䷿��
        /// </summary>
        /// <param name="value"></param>
        void setTabAutoMatchMode(int value);

        /// <summary>
        /// ���ٳ�
        /// </summary>
        /// <param name="value"></param>
        void setTabQuickRoomMode(int value);

        /// <summary>
        /// ���ֵ����׼������ܻ���ݹ�ʽ�����㣬
        /// �ó�������õ���ʧȥ������
        /// </summary>
        /// <returns></returns>
        int getDig();
        
        void setDig(int roomG);

        /// <summary>
        /// ����Я�� 
        /// </summary>
        /// <returns></returns>
        int getCarryg();

        void setCarryg(int roomCarryG);

        /// <summary>
        /// ÿ�ֿ۷ѣ��ٷֱ�
        /// </summary>
        /// <returns></returns>
        float getCostg();

        void setCostg(float roomCostG,string roomCostU,string roomCoustUid);

        /**
         * �������� 
         * @return 
         */
        String getPwd();

        void setPwd(String roomPwd);

        /// <summary>
        /// ���ܿ۷ֳͷ�����
        /// </summary>
        /// <param name="value"></param>
        void setRunAwayMultiG(int value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void setReconnectionTime(int value);

        /// <summary>
        /// �ճ�� - ÿ�յ�½����
        /// </summary>
        /// <param name="value"></param>
        void setEveryDayLogin(int value);

        int getEveryDayLogin();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getName();

        int getChairCount();

        int getLookChairCount();

        /// <summary>
        /// somebody = �����λ����
        /// </summary>
        /// <returns></returns>
        int getSomeBodyChairCount();

        /// <summary>
        /// somebody = �����λ����
        /// </summary>
        /// <returns></returns>
        int getSomeBodyLookChairCount();        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IChairModel getChair(IUserModel user);
        IChairModel getChair(int id);
        IChairModel getChair(string userId);

        ILookChairModel getLookChair(IUserModel user);

        List<IChairModel> findUser();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<IUserModel> getAllPeople();

        string getWhoWin();

        /// <summary>
        /// �÷����Ƿ��������
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool hasPeople(IUserModel user);

        /// <summary>
        /// ��ѯ�����Ƿ�����ͬip���û�
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isOnChair"></param>
        /// <returns></returns>
        bool hasSameIpPeople(IUserModel user, bool isOnChair);

        bool hasGamePlaying();

        bool hasGamePlaying(string roomStatus);      

        bool hasGameOver();

        /// <summary>
        /// room�����ڲ�������ͨ����ⷿ��״̬��ʵ��
        /// </summary>
        /// <returns></returns>
        bool hasAllReadyCanStart();

        /// <summary>
        /// �Զ�������λ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool setSitDown(IUserModel user);               

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void setReady(string userId);

        void setVars(string n,string v);

        bool chkVars(string n, string v, string userId, ref XmlNode nodeVars, int loop_i, out RvarsStatus sta);        
        

        void setGameStart(string roomStatus);

        void setGameOver(string qiziName);

        void setGameOver(IUserModel leaveUser);

        /// <summary>
        /// �����е�����ΪsetGameOver���Ӻ���
        /// ��Ϸδ��ʼ������Ϊ��������
        /// </summary>
        /// <param name="leaveUser"></param>
        void setLeaveUser(IUserModel leaveUser);

        void setAllowPlayerGlessThanZeroOnGameOver(bool value);

        void setClockPlusPlus();

        string Status { get; }

        /// <summary>
        /// ��������
        /// </summary>
        bool isWaitReconnection { get; }
        void setWaitReconnection(IUserModel waitUser);
        int CurWaitReconnectionTime { get; set; }
        int MaxWaitReconnectionTime { get; }
        IUserModel WaitReconnectionUser { get; }

        int Clock { get; }
        
        void reset();

        /// <summary>
        /// ������Ϣ��xml���
        /// </summary>
        /// <returns></returns>
        //string getMatchXml();

        /// <summary>
        /// �����xml���
        /// </summary>
        /// <returns></returns>
        string toXMLString();

        //string ContentXml { get; }

        /// <summary>
        /// ���ļ���
        /// </summary>
        /// <returns></returns>
        string getMatchResultXmlByRc();

        /// <summary>
        /// �õ����˵ķ����xml���
        /// </summary>
        /// <returns></returns>
        string getFilterContentXml(string strIpPort,string contentXml);

    }
}
