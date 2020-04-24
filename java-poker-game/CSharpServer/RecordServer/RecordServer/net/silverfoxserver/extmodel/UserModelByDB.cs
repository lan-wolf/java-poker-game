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

namespace RecordServer.net.silverfoxserver.extmodel
{
    public class UserModelByDB:IUserModelByDB
    {
        /// <summary>
        /// ���ѵ�xml���ݿ���
        /// </summary>
        private string _id;

        /// <summary>
        /// ���ݿ���mssqlʱ��
        /// </summary>
        private Int64 _id_sql;

        /// <summary>
        /// �ʻ���
        /// </summary>
        private string _accountName;

        /// <summary>
        /// �ǳ�
        /// </summary>
        private string _nickName;

        /// <summary>
        /// 
        /// </summary>
        private int _sex;

         /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Ĭ�Ͽ�Ϊ""</param>
        /// <param name="id_sql">Ĭ�Ͽ�Ϊ0</param>
        /// <param name="sex"></param>
        /// <param name="accountName"></param>
        /// <param name="nickName"></param>
        public UserModelByDB(string id, Int64 id_sql, int sex, string accountName, string nickName)
        {
            this._id = id;

            this._id_sql = id_sql;

            this._sex = sex;

            this._accountName = accountName;

            this._nickName = nickName;
        }

        public string getId()
        {
            return this._id;
        }

        public Int64 getId_SQL()
        {
            return this._id_sql;
        }

        public string getAccountName()
        {
            return this._accountName;
        }

        public string getNickName()
        {
            return this._nickName;    
        }

        public string getSex()
        {
            if (0 == this._sex)
            {
                return EUserSex.Boy;
            }

            if (1 == this._sex)
            {
                return EUserSex.Girl;
            }

            return EUserSex.NoBody;
        }

        public string getContentXml()
        {
            string s = "<u id='" + this._id.ToString() +
                                           "' id_sql='" + this._id_sql.ToString() +
                                           "' n='" + this._nickName.ToString() +
                                           "' s='" + this.getSex() + //this._sex.ToString() 
                                           "' ></u>";

            return s;        
        }

        public string toXMLString()
        {
            return getContentXml();
        
        }

    }
}
