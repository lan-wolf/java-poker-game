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
using net.silverfoxserver.core.util;
using DdzServer.net.silverfoxserver.extmodel;
using DdzServer.net.silverfoxserver.extfactory;

namespace DdzServer.net.silverfoxserver.extmodel
{
    public class UserModelByDdz : IUserModel
    {
        /// <summary>
        /// ���������У�������ϵsessionList��userList
        /// </summary>
        private string _strIpPort = "";

        public string strIpPort
        {
            get
            {

                return this._strIpPort;
            }
        }
        
        public string getStrIpPort()
        {
            return this._strIpPort;
        }

        public string getstrIpPort()
        {
            return this._strIpPort;
        }        

        /// <summary>
        /// ���ѵ�xml���ݿ���
        /// </summary>
        private string _id = "";

        /// <summary>
        /// ���ݿ���mssqlʱ��
        /// 
        /// getIdʱ��return  _id_sql����
        /// </summary>
        private Int64 _id_sql = 0;

        /// <summary>
        /// �ʻ���
        /// </summary>
        private string _accountName = "";

        /// <summary>
        /// �ǳ�
        /// </summary>
        private string _nickName = "";

        /// <summary>
        /// ҳ���ṩ��
        /// </summary>
        private string _bbs = "";

        /// <summary>
        /// ͷ��
        /// </summary>
        private string _headIco = "";

        /// <summary>
        /// 
        /// </summary>
        private string _sex = EUserSex.NoBody;

        /// <summary>
        /// �����������ʹ��volatile
        /// </summary>
        private volatile Int32 _g = 0;

        /// <summary>
        /// �����������ʹ��volatile
        /// ����
        /// </summary>
        private volatile int _heartTime = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Ĭ�Ͽ�Ϊ""</param>
        /// <param name="id_sql">Ĭ�Ͽ�Ϊ0</param>
        /// <param name="sex"></param>
        /// <param name="accountName"></param>
        /// <param name="nickName"></param>
        public UserModelByDdz(string strIpPort, string id, Int64 id_sql, string sex, string accountName, string nickName, string bbs, string headIco)
        {
            this._strIpPort = strIpPort;

            this._id = id;

            this._id_sql = id_sql;

            this._sex = sex;

            this._accountName = accountName;

            this._nickName = nickName;

            this._g = 0;

            this._bbs = bbs;

            if ("null" == headIco)
            {
                headIco = "";
            }

            this._headIco = headIco;

            this._heartTime = DateTime.Now.Minute;
        }

        /// <summary>
        /// �����յ�user��һ������������
        /// ��ֹ����ģ�͵Ĵ�����ɾ��
        /// </summary>
        public UserModelByDdz()
        {
            
        }

        

        public string getId()
        {
            return this._id;
        }

        public string Id 
        {
            get {

                return this._id;
            }
        }

        public void setId(string id_)
        {
            this._id = id_;
        }

        public Int64 getId_SQL()
        {
            return this._id_sql;
        }

        public void setId_SQL(Int64 id_sql)
        {
            this._id_sql = id_sql;
        }

        public Int32 getG()
        {
            return this._g;
        }

        public void setG(Int32 g)
        {
            this._g = g;
        }

        public int getHeartTime()
        {
            return this._heartTime;
        }

        public void setHeartTime(int value)
        {
            this._heartTime = value;
        }


        public string getAccountName()
        {
            return this._accountName;
        }

        public string getNickName()
        {
            return this._nickName;
        }

        public string NickName
        {
            get
            {
                return this._nickName;
            }
        }

        public string getSex()
        {
            return this._sex;
        }

        public string getBbs()
        {
            return this._bbs;
        }

        public string getHeadIco()
        {
            //
            if ("discuz" == this._bbs.ToLower())
            { 
                if("0" == this._id_sql.ToString())
				{
						//����
                    return "please use client QiPaiIco class, getHeadPhotoPath function";
				}

                //return "/uc_server/avatar.php?uid=" + this._id_sql.ToString() + "&size=middle";	

                //xmlת�������ַ�
                return "/uc_server/avatar.php?uid=" + this._id_sql.ToString() + "&amp;size=middle";
            }

            //
            if ("dvbbs" == this._bbs.ToLower())
            {
                return this._headIco;
            }

            //
            if ("phpwind" == this._bbs.ToLower())
            {
                return this._headIco;
            }

            return this._headIco;
        }

        public string toXMLString()
        {
            string s = "<u id='" + this._id.ToString() +
                                           "' id_sql='" + this._id_sql.ToString() +
                                           "' n='" + this._nickName.ToString() +
                                           "' s='" + this._sex.ToString() +
                                           "' g='" + this._g.ToString() +
                                           "' bbs='" + this._bbs.ToString() +
                                           "' hico='" + this._headIco.ToString() + 
                                           "' session='" + this._strIpPort + 
                                           "' ></u>";

            return s;
        }


        public IUserModel clone()
        {

            UserModelByDdz u =  new UserModelByDdz(_strIpPort, _id, _id_sql, _sex, _accountName, _nickName, _bbs, _headIco);

            u.setG(_g);

            return u;
        
        }

       
    }


}
