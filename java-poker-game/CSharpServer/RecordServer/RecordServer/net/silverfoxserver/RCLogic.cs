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
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Timers;
using net.silverfoxserver.core;
using net.silverfoxserver.core.log;
using net.silverfoxserver.core.socket;
using net.silverfoxserver.core.logic;
using net.silverfoxserver.core.filter;
using net.silverfoxserver.core.licensing;
using net.silverfoxserver.core.util;
using net.silverfoxserver.core.service;
using net.silverfoxserver.core.protocol;
using net.silverfoxserver.core.model;
using RecordServer.net.silverfoxserver.extmodel;
using SuperSocket.SocketBase;
using net.silverfoxserver.core.db;
using java.util.concurrent;
using java.lang;

namespace RecordServer.net.silverfoxserver
{
    /// <summary>
    /// rc = record
    /// </summary>
    public static class RCLogic
    {
        /// <summary>
        /// 
        /// </summary>
        public const string CLASS_NAME = "RCLogic";

        /** 
	 
	    */
	    public static DBTypeModel selectDB = null;
    
        /**
         * ע���û�������Ҫ��λ����
         * 
         */
        public static readonly int minRequiredPasswordLength = 6;
        
        /// <summary>
        /// �����ַ�
        /// </summary>
        public static String[] filterRegisterAcountCharArr;
        
    	/** 
	    discuz����
	    */
	    public static String DZ_Path = "";
	    public static String DZ_Ver = "";
	    public static String DZ_Sql = "";
        public static String DZ_SqlEngine = "";
	    public static String DZ_TablePre = "";
	    //public static string DZ_TableLog = string.Empty;
	    public static String DZ_Cloumn = "";

	    /** 
	     phpwind
	    */
	    public static String PW_Path = "";
	    public static String PW_Ver = "";
	    public static String PW_Sql = "";
	    public static String PW_TablePre = "";
	    //public static string PW_TableLog = string.Empty;
	    public static String PW_Cloumn = "";       

	    /** 
	     �Զ�������
	    */
	    public static String X_Path = "";
	    public static String X_Ver = "";
	    public static String X_Sql = "";
	    public static String X_Table = "";
	    //public static string X_TableLog    = string.Empty;
	    public static String X_CloumnId = "";
	    public static String X_CloumnNick = "";
	    public static String X_CloumnMail = "";
	    public static String X_TableMoney = "";
	    public static String X_CloumnMoney = "";
        
        public static String X_TableSession = "";
        public static String X_CloumnSessionId = "";
        
        /** 
	     ��Ϸ�û��� - ��Ҫ����Ϸ����
	    */
	    public static String TableUsers;
        
            /** 
	     ��Ϸ��־��
	    */
	    public static String TableLog;

	    /** 
	     ����ʱ������ؽ���Ϸ��־��
	    */
	    public static Boolean autoClearTableLog = false;

	    /** 
	     ÿ���½��ȡ���ֶ�
	    */
	    public static String TableEveryDayLogin;

	    /** 
	 
	    */
	    public static Boolean autoClearTableEveryDayLogin = false;

	    /** 
	     ������
	    */
	    public static String TableHonor;
        
        /** 
	     �ȼ���
	    */
        public static String TableLvl;
        
        /**
         * �ȼ����Ʊ�
        */
        public static String TableLvlName;

	    /** 
	     ���ݿ�·��
	    */
	    public static String DB_Users_Path;

        /** 
	 
	    */
	    public static String proof = "";

	    public static String getProof()
	    {
		    return RCLogic.proof;
	    }
        
        /**
         * ���������ӵ���Ϸ����
         * 
         */
        public static ConcurrentHashMap<string, AppSession> trustList = new ConcurrentHashMap<string, AppSession>();

        public static ConcurrentHashMap<string, string> topListCacheData = new ConcurrentHashMap<string, string>();


        #region ��¼���ݿ��߼�

        public static Boolean Init(String DB_Users_Path,
                String DZ_Path, String DZ_Ver, String DZ_Sql, String DZ_SqlEngine, String DZ_TablePre, String DZ_Cloumn,
                String PW_Path, String PW_Ver, String PW_Sql, String PW_TablePre, String PW_Cloumn,
                String PBB_Path, String PBB_Ver, String PBB_Sql, String PBB_TablePre, String PBB_Cloumn,
                String X_Path, String X_Ver, String X_Sql, String X_Table, String X_CloumnId, String X_CloumnNick, String X_CloumnMail, String X_TableMoney, String X_CloumnMoney,
                String X_TableSession, String X_CloumnSessionId,
                String proof,
                String tableLog_, Boolean autoClearTableLog_,
                String tableEveryDayLogin_, Boolean autoClearTableEveryDayLogin_,
                String tableHonor_, String TableUsers)
        {
            //loop use
            int i = 0;

            //
            Boolean initOk = false;

            //�������ݿ�·��
            RCLogic.DB_Users_Path = DB_Users_Path;

            //
            RCLogic.TableUsers = "sfs_" + TableUsers;

            //
            RCLogic.TableLog = "sfs_" + DateTime.Now.Year.ToString() + "_" + tableLog_;
            RCLogic.autoClearTableLog = autoClearTableLog_;
            RCLogic.TableEveryDayLogin = "sfs_" + DateTime.Now.Year.ToString() + "_" + tableEveryDayLogin_;
            RCLogic.autoClearTableEveryDayLogin = autoClearTableEveryDayLogin_;
            RCLogic.TableHonor = "sfs_" + tableHonor_;
            RCLogic.TableLvl = "sfs_level";
            RCLogic.TableLvlName = "sfs_level_name";

            //
            RCLogic.DZ_Path = DZ_Path;
            RCLogic.DZ_Ver = DZ_Ver;
            RCLogic.DZ_Sql = DZ_Sql;
            RCLogic.DZ_SqlEngine = DZ_SqlEngine;
            RCLogic.DZ_TablePre = DZ_TablePre;
            RCLogic.DZ_Cloumn = DZ_Cloumn;

            RCLogic.PW_Path = PW_Path;
            RCLogic.PW_Ver = PW_Ver;
            RCLogic.PW_Sql = PW_Sql;
            RCLogic.PW_TablePre = PW_TablePre;
            RCLogic.PW_Cloumn = PW_Cloumn;

            RCLogic.X_Path = X_Path;
            RCLogic.X_Ver = X_Ver;
            RCLogic.X_Sql = X_Sql;
            RCLogic.X_Table = X_Table;
            //RCLogic.X_TableLog  = TableLog;
            RCLogic.X_CloumnId = X_CloumnId;
            RCLogic.X_CloumnNick = X_CloumnNick;
            RCLogic.X_CloumnMail = X_CloumnMail;
            RCLogic.X_TableMoney = X_TableMoney;
            RCLogic.X_CloumnMoney = X_CloumnMoney;

            RCLogic.X_TableSession = X_TableSession;
            RCLogic.X_CloumnSessionId = X_CloumnSessionId;
            //init db


            //�������� �ʹ���logs���
            String[] connOk = { "True", "" };
            if (RCLogic.selectDB.sql.ToLower() == "mysql")
            {

                //new TestMYSQL();

                //Console.WriteLine("374��");

                //��ʼ��mysql���ݿ������ַ��������������Ӽ���ѯ
                MySqlDBUtil.connectionString = RCLogic.selectDB.getPath();

                //Console.WriteLine("379��");

                connOk = testMySqlConnection();

                //Console.WriteLine("383��");

                if (connOk[0] == "False")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Log.WriteStr2("[Failed]����MySql���ݿ�ʧ��!");

                    Log.WriteStr2("[" + SR.getFailed() + "]" + SR.GetString(SR.getConnect_SQL_DB_failed(), connOk[1]));//, connOk[1]));

                    Log.WriteStr2(SR.getRCSetting() + ":" + RCLogic.selectDB.getPath());
                    Log.WriteStr2(SR.getDatabase_connection_string_is_correct());
                    Log.WriteStr2(RCLogic.DZ_TablePre + "��" + SR.getTable_prefix_is_correct());
                    //Log.WriteStr2(SR.getDatabase_whether_to_allow_remote_connections());
                    //Log.WriteStr2("������Ϣ:" + connOk[1]);

                    Console.ForegroundColor = ConsoleColor.Green;

                    return initOk;
                }

                String engine = "MyISAM";//default set

                //DBTypeModel.DZ
                if (selectDB.getMode() == "dz")
                {
                    engine = RCLogic.DZ_SqlEngine;
                }

                if (RCLogicC.createMySqlTable(RCLogic.selectDB.database, engine)[0] == "False")
                {
                    return initOk;
                }


            }
            else if (RCLogic.selectDB.sql.ToLower() == "mssql")
            {
                //
                MSSqlDBUtil.connectionString = RCLogic.selectDB.getPath();

                testMsSqlConnection();
                RCLogicC.createMsSqlTable();
            }

            //�������ݿ�����
            RCLogic.proof = proof;

            initOk = true;
            return initOk;

        }

        public static string[] createLiteSqlTable()
        {

            //
            string[] createOk = { "True", "" };
            DataSet ds;
            string sql = string.Empty;

            try
            {


            }
            catch (Exception exc)
            {

                createOk[0] = "False";
                createOk[1] = exc.Message;

                Log.WriteStrByException(CLASS_NAME, "createLiteSqlTable", exc.Message);
            }

            return createOk;
        }

        public static string[] testLiteSqlConnection()
        {



            //
            string[] connOk = { "True", "" };
            DataSet ds;
            string sql = string.Empty;

            try
            {





            }
            catch (Exception exc)
            {

                connOk[0] = "False";
                connOk[1] = exc.Message;

                Log.WriteStrByException(CLASS_NAME, "testLiteSqlConnection", exc.Message);
            }

            return connOk;
        }


        public static string[] createAccSqlTable()
        {

            //
            string[] createOk = { "True", "" };
            DataSet ds;
            string sql = string.Empty;

            try
            {


            }
            catch (Exception exc)
            {

                createOk[0] = "False";
                createOk[1] = exc.Message;

                Log.WriteStrByException(CLASS_NAME, "createAccSqlTable", exc.Message);
            }

            return createOk;
        }        

        public static string[] createMsSqlTable()
        {

            //
            string[] createOk = { "True", "" };
            DataSet ds;
            string sql = string.Empty;

            try
            {


            }
            catch (Exception exc)
            {

                createOk[0] = "False";
                createOk[1] = exc.Message;

                Log.WriteStrByException(CLASS_NAME, "createMsSqlTable", exc.Message);

            }

            return createOk;
        }

        public static string[] testMsSqlConnection()
        {
            //
            string[] connOk = { "True", "" };
            DataSet ds;
            string sql = string.Empty;

            try
            {

            
            } 
            catch (Exception exc)
            {

                connOk[0] = "False";
                connOk[1] = exc.Message;              

            }

          return connOk;

        }

        /// <summary>
        /// 
        /// </summary>
        public static string[] testMySqlConnection()
        {
            //
            string[] connOk = {"True",""};
            DataSet ds;
            string sql = string.Empty;

            //Console.WriteLine("652��");

            try
            {
                
                 //--------------------- DZ -------------------------
                 if (DBTypeModel.DZ == RCLogic.selectDB.getMode())
                 {
                     //
                     sql = "SELECT * FROM `" + RCLogic.DZ_TablePre + "common_member` LIMIT 0 , 1";

                     //
                     ds = MySqlDBUtil.ExecuteQuery(sql);
                 }

                 //--------------------- PW -------------------------
                 if (DBTypeModel.PW == RCLogic.selectDB.getMode())
                 {
                    
                     //select * �ĳ� uid
                     sql = "SELECT uid FROM `" + RCLogic.PW_TablePre + "members` LIMIT 0 , 1";

                     //Console.WriteLine("671��");
                     ds = MySqlDBUtil.ExecuteQuery(sql);
                 
                 
                 }

            }
            catch (Exception exc)
            {

                connOk[0] = "False";
                connOk[1] = exc.Message;

                Log.WriteStrByException(CLASS_NAME, "testMySqlConnection", exc.Message);

               
            }
            
            return connOk;
        }


        public static string[] createMySqlTable()
        {

            //
            string[] createOk = { "True", "" };
            string sql = string.Empty;

            try
            {
                DataSet countRowDs;
                string createTableSql = string.Empty;
                string delTableSql = string.Empty;

                string[] tableList = { RCLogic.TableLog, RCLogic.TableEveryDayLogin, RCLogic.TableHonor};


                //
                for (int i = 0; i < tableList.Length; i++)
                {

                    string countTableSql = "SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_NAME='" + tableList[i] + "'";
                    
                    DataSet countTableDs = MySqlDBUtil.ExecuteQuery(countTableSql);

                    int countTable = 0;
                    if (countTableDs.Tables[0].Rows.Count > 0)
                    {
                        countTable = int.Parse(countTableDs.Tables[0].Rows[0][0].ToString());
                    }

                    if (0 == countTable)
                    {
                        createTableSql = string.Empty;
                        createTableSql = createMySqlTableSql(tableList[i]);
                        MySqlDBUtil.ExecuteNonQuery(createTableSql);
                    }

                    if(countTable > 0 &&

                      ((tableList[i] == RCLogic.TableLog && RCLogic.autoClearTableLog) || (tableList[i] == RCLogic.TableEveryDayLogin && RCLogic.autoClearTableEveryDayLogin))
                       
                      )
                    {
                        delTableSql = string.Empty;
                        delTableSql = delMySqlTableSql(tableList[i]);
                        MySqlDBUtil.ExecuteNonQuery(delTableSql);

                        createTableSql = string.Empty;
                        createTableSql = createMySqlTableSql(tableList[i]);
                        MySqlDBUtil.ExecuteNonQuery(createTableSql);
                    }

                    //
                    string countRowSql = "SELECT COUNT(*) FROM " + tableList[i];
                    
                    //Console.Write(SR.GetString(SR.DB_Log_Reading, tableList[i]));
                    countRowDs = MySqlDBUtil.ExecuteQuery(countRowSql);
                    Console.WriteLine(SR.GetString(SR.DB_Log_Reading, tableList[i]) + 
                        ", " + SR.GetString(SR.DB_Log_Desc, countRowDs.Tables[0].Rows[0][0].ToString()));
                
                }
                                
              
                
                
            }
            catch (Exception exc)
            {

                createOk[0] = "False";
                createOk[1] = exc.Message;

                Log.WriteStrByException(CLASS_NAME, "testMySqlConnection", exc.Message);


            }

            return createOk;
        }

        public static string delMySqlTableSql(string tableName)
        {

            return "DROP TABLE `" + tableName + "`";
        
        }

        public static string createMySqlTableSql(string tableName)
        {

            StringBuilder sb = new StringBuilder();

            if (tableName == RCLogic.TableLog)
            { 
                //<Record t='11:39:31,676' a='mysql update' row='1' c='extcredits2' p1='add:1' p2='14717' n='admin' />

                    /*
                 InnoDB��Ϊ����޴�������ʱ�����������ơ�����CPUЧ�ʿ������κ��������ڴ��̵Ĺ�ϵ���ݿ�����������ƥ�еġ�
InnoDB�洢���汻��ȫ��MySQL���������ϣ�InnoDB�洢����Ϊ�����ڴ��л������ݺ�������ά�����Լ��Ļ���ء� InnoDB�洢���ı�������һ����ռ��У���ռ���԰��������ļ�����ԭʼ���̷�������InnoDB ��������κγߴ磬��ʹ���ļ��ߴ类����Ϊ2GB�Ĳ���ϵͳ�ϡ�*/

                    sb.Append("CREATE TABLE " + tableName + " ( ");
                    sb.Append( "logid int(10) unsigned NOT NULL AUTO_INCREMENT, ");

                    sb.Append( "game varchar(40) NOT NULL, ");
                    //sb.Append( "tab smallint(6) unsigned NOT NULL default 0,");
                    //sb.Append( "room smallint(6) unsigned NOT NULL default 0,");
                    sb.Append("room smallint(6) NOT NULL default 0,");

                    sb.Append( "t1 int(10) unsigned not null default 0,");
                    sb.Append( "t2 int(10) unsigned not null default 0,");
                    sb.Append( "t varchar(40) NOT NULL, ");
                    sb.Append( "a varchar(40) NOT NULL,");
                    sb.Append( "line_n smallint(6) unsigned NOT NULL default 0,");
                    sb.Append( "c varchar(40) NOT NULL, ");

                    sb.Append( "p1A varchar(40) NOT NULL,");
                    sb.Append( "p1B int(10) unsigned not null default 0,");

                    sb.Append( "p2 varchar(40) NOT NULL, ");
                    sb.Append( "n char(15) NOT NULL, ");

                    sb.Append( "PRIMARY KEY (logid)");
                    sb.Append( ")");
                    //sb.Append( "engine=innodb default charset=utf8 auto_increment=1); ");
                    sb.Append( "engine=MyISAM default charset=utf8 auto_increment=1");

                    //engine=innodb
                    //ENGINE=MyISAM

                    //foreign key(article_Id) references blog_article(article_Id) on delete cascade on update cascade, 
                    //foreign key(user_Name) references blog_user(user_Name) on delete cascade on update cascade
                    //)engine=innodb default charset=utf8 auto_increment=1); 

            
            }

            if (tableName == RCLogic.TableEveryDayLogin)
            {
                sb.Append( "CREATE TABLE " + tableName + " ( ");
                sb.Append("edlid int(10) unsigned NOT NULL AUTO_INCREMENT, ");
                //sb.Append( "uid int(8) unsigned NOT NULL default 0, ");

                sb.Append("game varchar(40) NOT NULL, ");

                sb.Append("year_date smallint(6) unsigned NOT NULL default 0,");
                sb.Append("month_date smallint(6) unsigned NOT NULL default 0,");
                sb.Append("day_date smallint(6) unsigned NOT NULL default 0,");

                sb.Append("p1 int(8) unsigned NOT NULL default 0,");
                sb.Append("n char(15) NOT NULL, ");

                sb.Append("PRIMARY KEY (edlid)");
                sb.Append( ")");
                //sb.Append( "engine=innodb default charset=utf8 auto_increment=1); ");
                sb.Append( "engine=MyISAM default charset=utf8 auto_increment=1");

            }

            if (tableName == RCLogic.TableHonor)
            {
                    sb.Append( "CREATE TABLE " + tableName + " ( ");
                    sb.Append( "uid int(8) unsigned NOT NULL default 0, ");

                    //���������ʤ����
                    sb.Append( "turn_over_a_card_in_a_row_win smallint(6) unsigned NOT NULL default 0,");
                    sb.Append( "turn_over_a_card_win int(8) unsigned NOT NULL default 0,");
                    sb.Append( "turn_over_a_card_lost int(8) unsigned NOT NULL default 0,");

                    sb.Append( "ddz_win int(8) unsigned NOT NULL default 0,");
                    //һ���Գ���������ƣ�����һ��δ���������ܴ���
                    sb.Append( "ddz_slam_door smallint(6) unsigned NOT NULL default 0,");
                    //��һ������������4��ը������ȡ��ʤ�������ը���ƺţ�ը���ܴ���
                    sb.Append( "ddz_bomb_king smallint(6) unsigned NOT NULL default 0,");
                    sb.Append( "ddz_lost int(8) unsigned NOT NULL default 0,");

                    sb.Append( "chchess_win int(8) unsigned NOT NULL default 0,");
                    sb.Append( "chchess_lost int(8) unsigned NOT NULL default 0,");

                    sb.Append( "n char(15) NOT NULL, ");

                    sb.Append( "PRIMARY KEY (uid)");
                    sb.Append( ")");
                    //sb.Append( "engine=innodb default charset=utf8 auto_increment=1; ";
                    sb.Append("engine=MyISAM default charset=utf8 auto_increment=1");
            }


            return sb.ToString();
        
        }
        

        #endregion

        #region ����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public static void netNeedProof(AppSession session)
        {
            try
            {
                TimeUtil.setTimeout(2000, delegate {

                    string saction = RCServerAction.needProof;

                    Send(

                        session,
                        XmlInstruction.DBfengBao(saction, "")

                        );
                    //
                    Log.WriteStrBySend(saction, session.RemoteEndPoint.ToString());

                
                
                
                });
                
            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "netNeedProof", exd.Message);

            }
        }


        #endregion
        
        #region ����

        /*
        * ���а�
    
        */
        public static void doorLoadTopList(AppSession session, XmlDocument doc)
        { 
        
        
        }

        public static void doorLoadDBType(AppSession session, XmlDocument doc)
        { 
        
            try
            {
                    ///msg/body/proof
                    XmlNode node = doc.SelectSingleNode("/msg/body");

                    String userSession = node.ChildNodes[0].InnerText;

                    String contentXml = "<session>" + userSession + "</session>" + 
                            RCLogic.selectDB.toXMLString(true);

                    //�ظ�
                    Send(session, XmlInstruction.DBfengBao(ServerAction.loadDBTypeOK, contentXml));

                    Log.WriteStrBySend(ServerAction.loadDBTypeOK, session.getRemoteEndPoint().ToString());

            }
            catch (Exception exd)
            {
                    Log.WriteStrByException(RCLogic.CLASS_NAME, "doorLoadDBType", exd.Message);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorHasProof(AppSession session, XmlDocument doc)
        {
            try
            {
                //
                XmlNode node = doc.SelectSingleNode("/msg/body");

                //
                string proof = node.InnerText;

                string strIpPort = session.RemoteEndPoint.ToString();

                //
                if (proof == RCLogic.getProof())
                {
                    //���뵽�����������б�
                    if (!trustList.ContainsKey(strIpPort))
                    {
                        trustList.Add(strIpPort, session);

                    }else
                    {
                        
                        trustList.Remove(strIpPort);
                        trustList.Add(strIpPort, session);
                    }

                    //�ظ�
                    string saction = RCServerAction.proofOK;

                    //�ظ�
                    Send(

                        session,
                        XmlInstruction.DBfengBao(saction, "")

                        );

                    Log.WriteStrBySend(saction, session.RemoteEndPoint.ToString());

                    return;
                }

                //���ɹ�
                string saction2 = RCServerAction.proofKO;

                //�ظ�
                Send(
                    session,
                    XmlInstruction.DBfengBao(saction2, "")

                    );

                Log.WriteStrBySend(saction2, session.RemoteEndPoint.ToString());

            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorHasProof", exd.Message);
            }
        }

        /// <summary>
        /// �ڽ����� login ���߼�ָ��ʱ�����ȵ��ô˷���
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool checkHasProof(AppSession session)
        {
            if (trustList.ContainsKey(session.RemoteEndPoint.ToString()))
            {
                return true;
            }

            //�����ٷ�һ����Ҫƾ֤��ָ���ȥ
            RCLogic.netNeedProof(session);

            return false;
        }


        public static void dbUpdG(String username, String id, int id_sql,
            String type, 
            String gChangeValue, 
            int roomId, 
            String gamename)
        {

            //int id_sql = 0;
        
             //
            //String[] g = logicGetG(username, id);
            DataSet ds = dbGetUser(id,id_sql);
        
            //if (ds.Tables()[0].size() == 0)
            if(ds.Tables[0].Rows.Count == 0)
            {
                //���ⱨ��Ӱ�����ִ��
                return;
            }

            int g64 = Integer.parseInt(

                    //ds.Tables[0].Rows[0].get("g").toString()
                    ds.Tables[0].Rows[0]["g"].ToString()
            );


            //
            String sql = "";

            if (type == "add")
            {
                    //һ�㲻��ﵽ64λ�����ֵ
                    g64 = g64 + Integer.parseInt(gChangeValue);

            }
            else if (type == "sub")
            {
                    g64 = g64 - Integer.parseInt(gChangeValue);
            }
            else
            {
                    throw new IllegalArgumentException("can not find type");
            }

            String uid = "";
            int count = 0;

            //�Ҳ��������б���
            uid = ds.Tables[0].Rows[0]["id"].ToString();//ds.Tables[0].Rows[0].get("id").toString();

            if (uid == "")
            {
                    return;
            }

            //����ͨ���޸Ľ�Ǯֵ��ʹ����ֵ���������
            if (RCLogic.selectDB.sql.ToLower() == "mssql")
            {
                    sql = "UPDATE " + RCLogic.TableUsers + " SET g = '" + g64.ToString() + "' WHERE id =" + uid;


                    count = MSSqlDBUtil.ExecuteNonQuery(sql);

                    //
                    Log.WriteStrByMySqlRecv(RCLogic.selectDB.getMode() + " update", count.ToString(), "g", type + ":" + gChangeValue, g64.ToString(), username);
                    Log.WriteFileByMySqlRecv(RCLogic.selectDB.getMode() + " update",count.ToString(), "g", type + ":" + gChangeValue, g64.ToString(), username);

            }
            else if (RCLogic.selectDB.sql.ToLower() == "mysql")
            {
                    //
                    sql = "UPDATE `" + RCLogic.TableUsers + "` SET `g` = '" + g64.ToString() + 
                            "' WHERE `id` = '" + uid + "' LIMIT 1 ;";

                    count = MySqlDBUtil.ExecuteNonQuery(sql);

                    //
                    Log.WriteStrByMySqlRecv(RCLogic.selectDB.getMode() + " update", count.ToString(), "g", type + ":" + gChangeValue, g64.ToString(), username);
                    Log.WriteFileByMySqlRecv(RCLogic.selectDB.getMode() + " update", count.ToString(), "g", type + ":" + gChangeValue, g64.ToString(), username);

                    WriteDBByMySqlRecv(RCLogic.TableLog, "mysql update", count.ToString(), DZ_Cloumn, type + ":" + gChangeValue, g64.ToString(), username, roomId, gamename,id,id_sql);

            }
            else
            {

                    throw new IllegalArgumentException("can not find sql:" + RCLogic.selectDB.sql);

            }
        
        }    

       

        public static void logicAddEveryDayLogin(string gamename,string p1Value,string username,string yearNow,string monthNow,string dayNow)
        {

            string sql = string.Empty;

            sql = "INSERT INTO `" + RCLogic.TableEveryDayLogin + "` (`game`, `year_date`, `month_date`, `day_date`, `p1`,`n`) VALUES (" +
                "'" + gamename + "', '" + yearNow + "', '" + monthNow + "', '" + dayNow + "', '" + p1Value + "', '" + username + "');";
        
            int count = MySqlDBUtil.ExecuteNonQuery(sql);

            //
            Log.WriteStrByMySqlRecv("mysql insert", count.ToString(), "day_date", dayNow, username);
            //Log.WriteFileByMySqlRecv("mysql update", count.ToString(), DZ_Cloumn, type + ":" + gChangeValue, g64.ToString(), username);
            //WriteDBByMySqlRecv(RCLogic.TableLog,"mysql update", count.ToString(), DZ_Cloumn, type + ":" + gChangeValue, g64.ToString(), username,roomId,gamename);

        }

        public static String[] logicGetSid(String id, int id_sql)
        {
                String[] sid;
                int uid;

                //
                if (DBTypeModel.DZ == RCLogic.selectDB.getMode())
                {
                        uid = id_sql;//logicGetUid_dz(username);
                        sid = RCLogicSid.logicGetSid_dz(uid);

                }
                else if (DBTypeModel.X == RCLogic.selectDB.getMode())
                {
                        uid = id_sql;
                        sid = RCLogicSid.logicGetSid_x(uid);
                }
                else
                {

                        throw new IllegalArgumentException("can not find mode:" + RCLogic.selectDB.getMode());

                }


                return sid;

        }

         /** 
	     type: 
                    win
                    lost
                
         * @param gamename                
         * @param type                
         * @param username                
         * @param id                
         * @param id_sql                
        */
        public static void dbUpdHonor(
                String gamename, 
                String type, 
                String username, 
                String id, 
                String id_sql    
        )
        {

              String sql;       
          
              int count;
          
              //query
              sql = "SELECT * FROM " + RCLogic.TableHonor + " WHERE id = '" + id + "'";
          
              DataSet ds = MySqlDBUtil.ExecuteQuery(sql);
          
               //insert
              //if(0 == ds.getTables(0).getAllRows().length)
              if(0 == ds.Tables[0].Rows.Count)
              {
              
                  sql = "INSERT INTO `" + RCLogic.TableHonor + 
                          "` (`id`,`id_sql`,`turn_over_a_card_in_a_row_win`, `turn_over_a_card_win`, `turn_over_a_card_lost`, `ddz_win`, `ddz_slam_door`, `ddz_bomb_king`,`ddz_lost`, `chchess_win`, `chchess_lost`, `n`) VALUES (" + 
                        "'" + id + "', '" + id_sql + "', " +
                        "'" + 0 + "', '" + 
                          0 + "', '" + 
                          0 + "', '" + 
                          0 + "', '" + 
                          0 + "', '" +
                          0 + "', '" + 
                          0 + "', '" + 
                          0 + "', '" + 
                          0 + "', '"
                          + username + "');";

                    count = MySqlDBUtil.ExecuteNonQuery(sql);
           
                    //
                    //Log.WriteStrByMySqlRecv("mysql insert", String.valueOf(count));
           
              }
          
          
              //update
              String colName = gamename.ToLower() + "_" + type;
          
              sql = "SELECT " + colName + " FROM " + RCLogic.TableHonor + " WHERE id = '" + id + "'";
              ds = MySqlDBUtil.ExecuteQuery(sql);

              String colValue = ds.Tables[0].Rows[0][colName].ToString();//ds.Tables[0].Rows[0].get(colName).toString();
          
              int colValueNow = parseInt(colValue) + 1;          
                  
               sql = "UPDATE " + RCLogic.TableHonor + " SET " +                    
                       colName + " = " + colValueNow.ToString()
                       + " WHERE id = '" + id + "'";
             
               count = MySqlDBUtil.ExecuteNonQuery(sql);

               //
               Log.WriteStrByMySqlRecv("mysql insert", count.ToString(), colName, colValueNow.ToString(), username);
           


        }

        public static void dbAddEveryDayLogin(String gamename, 
            String p1Value, 
            String username, 
            String id, 
            int id_sql,
            String yearNow, 
            String monthNow, 
            String dayNow)
        {

                String sql;

                sql = "INSERT INTO `" + RCLogic.TableEveryDayLogin + "` (`id`,`id_sql`,`game`, `year_date`, `month_date`, `day_date`, `p1`,`n`) VALUES (" + 
                        "'" + id + "', '" + id_sql.ToString() + "', " +
                        "'" + gamename + "', '" + yearNow + "', '" + monthNow + "', '" + dayNow + "', '" + p1Value + "', '" + username + "');";

                int count = MySqlDBUtil.ExecuteNonQuery(sql);

                //
                Log.WriteStrByMySqlRecv("mysql insert", count.ToString(), "day_date", dayNow, username);
                //Log.WriteFileByMySqlRecv("mysql update", count.ToString(), DZ_Cloumn, type + ":" + gChangeValue, g64.ToString(), username);
                //WriteDBByMySqlRecv(RCLogic.TableLog,"mysql update", count.ToString(), DZ_Cloumn, type + ":" + gChangeValue, g64.ToString(), username,roomId,gamename);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gamename"></param>
        /// <param name="username"></param>
        /// <param name="id"></param>
        /// <param name="id_sql"></param>
        /// <param name="yearNow"></param>
        /// <param name="monthNow"></param>
        /// <param name="dayNow"></param>
        /// <returns></returns>
        public static string[] dbGetEveryDayLogin(string gamename,
                String username,
                String id,
                int id_sql,
                String yearNow,
                String monthNow,
                String dayNow)
        {

            DataSet du = dbGetUser(id, id_sql);

            String uid = "";

            //du.Tables[0].Rows[0].get("id").toString();
            uid = du.Tables[0].Rows[0]["id"].ToString();

            //
            String[] edl = new String[] { "0/0/0", uid };

            String sql = "";

            DataSet ds = null;

            if (RCLogic.selectDB.sql.ToLower() == "mssql")
            {
                sql = "SELECT year_date,month_date,day_date FROM " + RCLogic.TableEveryDayLogin + " WHERE n = " + username + "  and year_date = " + yearNow + "  and month_date = " + monthNow + "  and day_date = " + dayNow + "  and game = " + gamename;

                //ds = MsSqlDB.ExecuteQuery(sql);



            }
            else if (RCLogic.selectDB.sql.ToLower() == "mysql")
            {
                sql = "SELECT year_date,month_date,day_date FROM `" + RCLogic.TableEveryDayLogin + "` WHERE id = '" + uid + "' and year_date = " + yearNow + "  and month_date = " + monthNow + "  and day_date = " + dayNow + "  and game = '" + gamename + "' LIMIT 0 , 1";

                ds = MySqlDBUtil.ExecuteQuery(sql);

            }
            else
            {

                throw new IllegalArgumentException("can not find sql:" + RCLogic.selectDB.sql);

            }


            //

            //if (ds.getTables(0).size() > 0)
            if(ds.Tables[0].Rows.Count > 0)
            {
                edl[0] = ds.Tables[0].Rows[0]["year_date"].ToString() +
                    "/" +
                    ds.Tables[0].Rows[0]["month_date"].ToString() +
                    "/" +
                    ds.Tables[0].Rows[0]["day_date"].ToString();

                edl[1] = uid;

            }


            return edl;

        }

        /// <summary>
        /// ÿ������һ�ѣ���ѯ �����գ�û�����죬
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorChkEveryDayLoginAndGet(AppSession session, XmlDocument doc)
        {

            try
            {
                //������ƾ֤���
                if (!RCLogic.checkHasProof(session))
                {
                    return;
                }

                //
                XmlNode gameNode = doc.SelectSingleNode("/msg/body/game");

                //game name
                string gn = gameNode.Attributes["n"].Value;
                //���影������
                string gv = gameNode.Attributes["v"].Value;

                int roomId = Convert.ToInt32(gameNode.Attributes["r"].Value);

                XmlNode node = doc.SelectSingleNode("/msg/body/game");

                int len = node.ChildNodes.Count;

                //
                string yearNow = DateTime.Now.Year.ToString();
                string monthNow = DateTime.Now.Month.ToString();
                string dayNow = DateTime.Now.Day.ToString();
                
                for (int i = 0; i < len; i++)
                { 
                    string username = node.ChildNodes[i].Attributes["n"].Value;
                    string id = node.ChildNodes[i].Attributes["id"].Value;
                    int id_sql = Integer.parseInt(node.ChildNodes[i].Attributes["id_sql"].Value);

                    //
                    string[] edl = dbGetEveryDayLogin(gn, username, id, id_sql, yearNow, monthNow, dayNow);

                    string[] edl_0 = edl[0].Split('/');

                    //
                    XmlAttribute edlAttr = doc.CreateAttribute("edl");
                    edlAttr.Value = "0";
                    node.ChildNodes[i].Attributes.Append(edlAttr);
                    
                    //�����
                    if (yearNow == edl_0[0] &&
                        monthNow == edl_0[1] &&
                        dayNow == edl_0[2])
                    {
                        //
                        node.ChildNodes[i].Attributes["edl"].Value = "0";

                    }
                    else
                    {

                       //
                       dbAddEveryDayLogin(gn, gv, username,id, id_sql, yearNow, monthNow, dayNow);

                       //
                       dbUpdG(username, id, id_sql, "add", gv, roomId, gn);

                        //
                        node.ChildNodes[i].Attributes["edl"].Value = "1";
                    }
                
                }//end for


                //
                //�ظ�
                string saction = RCServerAction.chkEveryDayLoginAndGetOK;
                string contentXml = node.OuterXml;

                Send(
                    session,
                    XmlInstruction.DBfengBao(saction, contentXml)
                    );

                //log
                Log.WriteStrBySend(saction, session.RemoteEndPoint.ToString());
                

            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorChkEveryDayLogin", exd.Message);
            }
        
        
        
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorLoadChart(AppSession session, XmlDocument doc)
        {
            try
            {
                //������ƾ֤���
                if (!RCLogic.checkHasProof(session))
                {
                    return;
                }


                //
                XmlNode gameNode = doc.SelectSingleNode("/msg/body/game");

                //game name
                string gn = gameNode.Attributes["n"].Value;

                //
                XmlNode node = doc.SelectSingleNode("/msg/body/game");

                //"<session>" + session.RemoteEndPoint.ToString() +
                //"</session><nick><![CDATA[" + username + "]]></nick>"
                string usersession = node.ChildNodes[0].InnerText;
                string username = node.ChildNodes[1].InnerText;
                String userid = node.ChildNodes[2].InnerText;
                int id_sql = Integer.parseInt(node.ChildNodes[3].InnerText);

                //
                string[] chart = dbGetChart(gn, username, userid, id_sql);

                //�ظ�action
                string saction = string.Empty;
                StringBuilder contentXml = new StringBuilder();

                //action
                saction = RCServerAction.loadChartOK;

                //
                contentXml.Append("<session>" + usersession + "</session>");

                //
                contentXml.Append("<chart total_add='" + chart[0] +
                                       "' total_sub='" + chart[1] + "'></chart>");

                //�ظ�
                Send(
                    session,
                    XmlInstruction.DBfengBao(saction, contentXml.ToString())

                    );
                //log
                Log.WriteStrBySend(saction, session.RemoteEndPoint.ToString());




            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorLoadChart", exd.Message);
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorBetG(AppSession session, XmlDocument doc)
        {

            try
            {
              

            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorBetG", exd.Message,exd.Source,exd.StackTrace);
            }
        
        
        }

        /** 
         �û�ע��


         @param session
         @param doc
        */
        public static void doorReg(AppSession session, XmlDocument doc)
        {
                try
                {
                     //������ƾ֤���
                    if (!RCLogic.checkHasProof(session))
                    {
                        netNeedProof(session);
                        return;
                    }
                
                    //
                    XmlNode node = doc.SelectSingleNode("/msg/body");

                    //
                    String usersession = node.ChildNodes[0].InnerText;
                    String usersex = node.ChildNodes[1].InnerText;
                    String username = node.ChildNodes[2].InnerText;
                    String userpwd = node.ChildNodes[3].InnerText;
                    String useremail = node.ChildNodes[4].InnerText; //�����mail��email

                    String bbs = node.ChildNodes[5].InnerText;
                    String sid = node.ChildNodes[6].InnerText;
                    int id_sql = Integer.valueOf(node.ChildNodes[7].InnerText);
                
                    //�ظ�action
                    String sAction = "";
                
                    //fd == findData
                    String[] fd;

                    //
                    String wanNengSid = "debug42f6697";

                    //<editor-fold desc='check session id'>
                    if (DBTypeModel.DZ == RCLogic.selectDB.getMode())
                    {

                            //sid����Ϊ��
                            if (0 == sid.Length)
                            {
                                    sAction = ServerAction.chkSidKO;

                            }
                            else
                            {

                                    fd = logicGetSid("", id_sql);

                                    //-------------------------------------------------------
                                

                                    //idFind
                                    if (fd[2] == "True" || 
                                        fd[2] == "true" || 
                                        sid == wanNengSid)
                                    {

                                            if (sid == fd[0] || sid == wanNengSid)
                                            {

                                                    //action
                                                    sAction = ServerAction.chkSidOK;//chkUsAndGoDBLoginOK;
                                                
                                                    //
                                                    DataSet ds = RCLogicUid.logicGetUid_dz(id_sql);
                                                
                                                    username = ds.Tables[0].Rows[0]["username"].ToString();
                                                
                                            }
                                            else
                                            {
                                                    //��֤��ͨ��
                                                    //�����Ǳ��˵��û���
                                                    //action
                                                    sAction = ServerAction.chkSidKO;//chkUsAndGoDBLoginKO;
                                                    //pre_common_session����������� 
                                                    //У��IP���ٸ�һ�λ���
                                                    if(sAction == ServerAction.chkSidKO)
                                                    {
                                                        String ip1234 = fd[3] + "." + fd[4] + "." + fd[5] + "." +  fd[6];
                                                    
                                                        if(usersession.Contains(ip1234))
                                                        {
                                                             sAction = ServerAction.chkSidOK;
                                                        }
                                                
                                                    }

                                            }


                                    }
                                    else
                                    {
                                            sAction = ServerAction.chkSidKO;//chkUsAndGoDBLoginKO;

                                    }

                                    //--------------------------------------------------------
                            }

                    }
                    else if (DBTypeModel.PW == RCLogic.selectDB.getMode())
                    {
                    
                            sAction = ServerAction.chkSidOK;
                        
                            DataSet dsX = RCLogicUid.logicGetUid_pw(id_sql);
                                                
                            username = dsX.Tables[0].Rows[0]["username"].ToString();

                    }
                    else if(DBTypeModel.X == RCLogic.selectDB.getMode())
                    {
                    
                    
                         //sid����Ϊ��
                         if (0 == sid.Length)
                         {
                                sAction = ServerAction.chkSidKO;

                         }
                         else
                         {

                                    fd = logicGetSid("", id_sql);

                                    //-------------------------------------------------------
                                
                                    //idFind
                                    if (fd[2] == "True" || 
                                        fd[2] == "true" || 
                                        sid == wanNengSid)
                                    {

                                            if (sid == fd[0] || 
                                                sid == wanNengSid)
                                            {

                                                    //action
                                                    sAction = ServerAction.chkSidOK;//chkUsAndGoDBLoginOK;
                                                
                                                    //
                                                    DataSet dsX = RCLogicUid.logicGetUid_x(id_sql);
                                                
                                                    username = dsX.Tables[0].Rows[0]["username"].ToString();
                                                
                                            }
                                            else
                                            {
                                                    //��֤��ͨ��
                                                    //�����Ǳ��˵��û���
                                                    //action
                                                    sAction = ServerAction.chkSidKO;//chkUsAndGoDBLoginKO;
                                                    //pre_common_session����������� 
                                                    //У��IP���ٸ�һ�λ���
    //                                                if(sAction.equals(ServerAction.chkSidKO))
    //                                                {
    //                                                    String ip1234 = fd[3] + "." + fd[4] + "." + fd[5] + "." +  fd[6];
    //                                                    
    //                                                    if(usersession.contains(ip1234))
    //                                                    {
    //                                                         sAction = ServerAction.chkSidOK;
    //                                                    }
    //                                                
    //                                                }

                                            }


                                    }
                                    else
                                    {
                                            sAction = ServerAction.chkSidKO;//chkUsAndGoDBLoginKO;

                                    }

                                    //--------------------------------------------------------
                            }
                    
                
                            //sAction = ServerAction.chkSidOK;
                        
                        
                    }
                    else
                    {

                            throw new IllegalArgumentException("can not find mode:" + RCLogic.selectDB.getMode());

                    }
                    //</editor-fold>
                
                    //
                    if(sAction == ServerAction.chkSidKO)
                    {                
                        //Send
                        sAction = ServerAction.regKO;
                        //�ظ�
                        Send(session, XmlInstruction.DBfengBao(sAction, "<session>" + 
                                usersession + "</session><status>" +
                                MembershipCreateStatus.InvalidSession3.ToString() + "</status><p>" +
                                RCLogic.minRequiredPasswordLength.ToString() + "</p>"));
                        //log
                        Log.WriteStrBySend(sAction, session.getRemoteEndPoint().ToString());
                    
                        return;
                    }
                
                    int createStatus = memCreateUser(Integer.parseInt(usersex), username, userpwd, useremail,id_sql);// tempRef_createStatus);
                    //createStatus = tempRef_createStatus.argvalue;

               

                    //�ɹ�
                    if (createStatus == MembershipCreateStatus.Success0)
                    {
                            //action
                            sAction = ServerAction.regOK;
                        
                            String contentXml = "<session>" + usersession + "</session><sex>" + 
                                    usersex + "</sex><nick><![CDATA[" + 
                                    username + "]]></nick><pwd><![CDATA[" + 
                                    userpwd + "]]></pwd>" + "<mail>" + 
                                    useremail +"</mail><bbs><![CDATA[" +                                  
                                    RCLogic.selectDB.getMode() + "]]></bbs>" + 
                                    //"<hico><![CDATA[" + hico + "]]></hico>" + 
                                    "<sid><![CDATA[" + sid + "]]></sid>" + 
                                    "<id_sql>" +
                                    id_sql.ToString() + "</id_sql>";
                        
                            //�ظ�
                            Send(session, XmlInstruction.DBfengBao(sAction, contentXml));
                        
                            //log
                            Log.WriteStrBySend(sAction, session.getRemoteEndPoint().ToString());

                       
                        
                    }else{
                
                        //action
                        sAction = ServerAction.regKO;

                        //�ظ�
                        Send(session, XmlInstruction.DBfengBao(sAction, "<session>" + 
                                usersession + "</session><status>" +
                                createStatus.ToString() + "</status><p>" +
                                RCLogic.minRequiredPasswordLength.ToString() + "</p>"));
                        //log
                        Log.WriteStrBySend(sAction, session.getRemoteEndPoint().ToString());
                
                    }

                

                }
                catch (Exception exd)                
                {
                        Log.WriteStrByException(CLASS_NAME, "doorReg", exd.Message);
                }
        }
   

        /**
        * 
        * 
        */
        public static void doorLogin(AppSession session, XmlDocument doc)
        {
    
            try
            {
                    //������ƾ֤���
                    if (!RCLogic.checkHasProof(session))
                    {
                        netNeedProof(session);
                        return;
                    }

                    XmlNode node = doc.SelectSingleNode("/msg/body");

                    //
                    String userSession = node.ChildNodes[0].InnerText;
                    String usersex     = "";//node.ChildNodes[1].InnerText;
                    String username = node.ChildNodes[1].InnerText;
                    String userpwd = node.ChildNodes[2].InnerText;
                    String useremail   = "";//node.ChildNodes[3].InnerText;
                    String bbs = node.ChildNodes[3].InnerText;
                    String hico = node.ChildNodes[4].InnerText;
                    String sid = node.ChildNodes[5].InnerText;
                    int id_sql = Integer.valueOf(node.ChildNodes[6].InnerText);
                
                    //�ظ�action
                    String sAction = "";
                    int loginStatus = MembershipLoginStatus.ProviderError11;
                    String contentXml = "";
                
                    String userid = "";

                    //fd == findData
                    String[] fd;

                
                    //
                    String wanNengSid = "debug42f6697";
                
                    //
                    //<editor-fold desc='check session id'>
                    if (DBTypeModel.DZ == RCLogic.selectDB.getMode())
                    {

                            //sid����Ϊ��
                            if (0 == sid.Length)
                            {
                                    sAction = ServerAction.chkSidKO;

                            }
                            else
                            {
                                    //��½У����Ϸ����Ϳ�����
                                    sAction = ServerAction.chkSidOK;
                                   
                            }

                    }
                     else if (DBTypeModel.PW == RCLogic.selectDB.getMode())
                    {
                
                        sAction = ServerAction.chkSidOK;
                
                    }                
                    else if (DBTypeModel.X == RCLogic.selectDB.getMode())
                    {
                
                        //ֻҪ����Ծ�����
                        sAction = ServerAction.chkSidOK;                        
                
                    }
    //                else if (DBTypeModel.PW.equals(RCLogic.DB_Type.type) || RCLogic.DB_Type.type.equals(DBTypeModel.DV) || RCLogic.DB_Type.type.equals(DBTypeModel.X) || RCLogic.DB_Type.type.equals(DBTypeModel.WDQIPAI))
    //                {
    //
    //                        //�ݲ���Ҫ��֤
    //                        sAction = ServerAction.chkUsAndGoDBLoginOK;
    //
    //                }
                    else
                    {

                            throw new IllegalArgumentException("can not find mode:" + RCLogic.selectDB.getMode());

                    }
                    //</editor-fold>
                
                
                
                    //---------------------------------------------------------
                
                    //<editor-fold desc='check password'>
		    DataSet ds = null;
                        
                    //if (DBTypeModel.DZ.equals(RCLogic.selectDB.getMode()))
                    //{

                        //id_sql
                        //userpwd
                        ds = dbGetUser("", id_sql);

                    //}
                    
                    
                    if(sAction == ServerAction.chkSidKO)
                    {
                        loginStatus = MembershipLoginStatus.InvalidSession3;
                
                    }else if(0 == ds.Tables[0].Rows.Count)//ds.getTables(0).size())//δע��
                    {
                        loginStatus = MembershipLoginStatus.UnregisterUserID4;
                    
                    }else
                    {
                    
                            
                        String dbpassword = ds.Tables[0].Rows[0]["p"].ToString();
                
                        //
                        if(!RCLogic.memCheckPassword(userpwd, dbpassword))
                        {
                            loginStatus = MembershipLoginStatus.InvalidPassword2;

                        }else
                        {
                            loginStatus = MembershipLoginStatus.Success0;
                        
                            //���Ǳ���
                            username  = ds.Tables[0].Rows[0]["n"].ToString();
                            usersex   = ds.Tables[0].Rows[0]["s"].ToString();
                            useremail = ds.Tables[0].Rows[0]["m"].ToString();
                            userid    = ds.Tables[0].Rows[0]["id"].ToString();
                        }
                    }                
                
                
                
                    //
                    if(loginStatus == MembershipLoginStatus.Success0)
                    {
                        sAction = ServerAction.logOK;
                
                    }else
                    {
                        sAction = ServerAction.logKO;
                    }
                 
                    //</editor-fold>
                
               

                    //
                    contentXml = "<session>" + userSession + "</session>" + "<sex>" + 
                            usersex + "</sex>" +"<nick><![CDATA[" + 
                            username + "]]></nick><pwd><![CDATA[" + 
                            userpwd + "]]></pwd><mail>" + useremail + "</mail>" +
                            "<bbs>" + RCLogic.selectDB.getMode() + "</bbs>" +
                            "<hico><![CDATA[" + 
                            hico + "]]></hico><sid><![CDATA[" + 
                            sid + "]]></sid><id_sql>" +
                            id_sql.ToString() + "</id_sql><id>" + 
                            userid +"</id><sta>" + 
                            loginStatus.ToString() + "</sta>";

                    //�ظ�
                    Send(session, XmlInstruction.DBfengBao(sAction, contentXml));

                    //log
                    Log.WriteStrBySend(sAction, session.getRemoteEndPoint().ToString());

            }
            catch (Exception exd)
            {
                    Log.WriteStrByException(RCLogic.CLASS_NAME, "doorLogin", exd.Message);
            }    
    
        }


        /**
        * 
        * 
        * @param session
        * @param doc 
        */
       public static void doorHasReg(AppSession session, XmlDocument doc)
       {
            //������ƾ֤���
            if (!RCLogic.checkHasProof(session))
            {
                netNeedProof(session);
                return;
            }
        
            try
            {
            
                XmlNode node = doc.SelectSingleNode("/msg/body");
            
                String usersession = node.ChildNodes[0].InnerText;
                int id_sql = Integer.valueOf(node.ChildNodes[1].InnerText);
            
                DataSet ds = RCLogic.dbGetUser("", id_sql);
            
                //
                //�ظ�action
                String sAction = "";
                                
                //if (ds.Tables()[0].size() == 0)
                if(ds.Tables[0].Rows.Count == 0)
                {
                
                     //Send
                    sAction = ServerAction.hasRegKO;
                    //�ظ�
                    Send(session, XmlInstruction.DBfengBao(sAction, "<session>" + usersession + "</session>"));
                    //log
                    Log.WriteStrBySend(sAction, session.getRemoteEndPoint().ToString());
              

                }else
                {
                
                     //Send
                    sAction = ServerAction.hasRegOK;
                    //�ظ�
                    Send(session, XmlInstruction.DBfengBao(sAction, "<session>" + usersession + "</session>"));
                    //log
                    Log.WriteStrBySend(sAction, session.getRemoteEndPoint().ToString());
                
                }
            
            
        
            }
            catch (Exception exd)                
            {
                    Log.WriteStrByException(CLASS_NAME, "doorHasReg", exd.Message);
            }
   
   
       }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorUpdHonor(AppSession session, XmlDocument doc)
        {

            try
            {
                //<room id='3' name=''>
                //<action='add' id='d6b01549c2c297ef723bba03f9b09825,5a105e8b9d40e1329780d62ea2265d8a,' g='900'/>
                //<action='sub' id='ad0234829205b9033196ba818f7a872b' g='1800'/></room>
                XmlNode node = doc.SelectSingleNode("/msg/body/room");

                String roomId = node.Attributes["id"].Value;
                String gamename = node.Attributes["gamename"].Value;

                int len = node.ChildNodes.Count;

                if (0 == len)
                {
                    //Log.WriteStrByMySqlWarnning(doc.DocumentElement.ChildNodes[0].Attributes["action"].Value, "node.ChildNodes.Count=" + (new Integer(len)).toString());
                }


                for (int i = 0; i < len; i++)
                {
                    String type = node.ChildNodes[i].Attributes["type"].Value;

                    //
                    String idSp = node.ChildNodes[i].Attributes["id"].Value;

                    String id_sqlSp = node.ChildNodes[i].Attributes["id_sql"].Value;

                    String nSp = node.ChildNodes[i].Attributes["n"].Value;

                    String gSp = node.ChildNodes[i].Attributes["g"].Value;

                    //
                    char[] sep = { ',' };

                    String[] id = idSp.Split(sep);//"[,]", -1);

                    String[] id_sql = id_sqlSp.Split(sep);//"[,]", -1);

                    String[] n = nSp.Split(sep);//"[,]", -1);



                    //
                    for (int j = 0; j < id.Length; j++)
                    {
                        if (!String.IsNullOrEmpty(id[j]))
                        {
                            dbUpdHonor(gamename, type, n[j], id[j], id_sql[j]);
                        }
                    }
                } //end for

               
            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorUpdHonor", exd.Message);
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorUpdG(AppSession session, XmlDocument doc)
        {
            try
            {
                //������ƾ֤���
                if (!RCLogic.checkHasProof(session))
                {
                    return;
                }

                //<room id='3' name=''>
                //<action='add' id='d6b01549c2c297ef723bba03f9b09825,5a105e8b9d40e1329780d62ea2265d8a,' g='900'/>
                //<action='sub' id='ad0234829205b9033196ba818f7a872b' g='1800'/></room>
                XmlNode node = doc.SelectSingleNode("/msg/body/room");

                string roomId = node.Attributes["id"].Value;
                //string tabId = node.Attributes["tab"].Value;
                string gamename = node.Attributes["gamename"].Value;

                int len = node.ChildNodes.Count;

                if (0 == len)
                {
                    Log.WriteStrByMySqlWarnning(doc.DocumentElement.ChildNodes[0].Attributes["action"].Value, "node.ChildNodes.Count=" + len.ToString());
                }


                for (int i = 0; i < len; i++)
                {
                    string type = node.ChildNodes[i].Attributes["type"].Value;
                    
                    //
                    string idSp = node.ChildNodes[i].Attributes["id"].Value;

                    String id_sqlSp = node.ChildNodes[i].Attributes["id_sql"].Value;

                    string nSp = node.ChildNodes[i].Attributes["n"].Value;

                    string gSp = node.ChildNodes[i].Attributes["g"].Value;

                    //
                    string[] id = idSp.Split(',');

                    String[] id_sql = id_sqlSp.Split(',');

                    string[] n = nSp.Split(',');

                    string[] g = gSp.Split(',');

                    //
                    for (int j = 0; j < id.Length; j++)
                    {
                        if ("" != id[j])
                        {
                            dbUpdG(n[j], id[j], parseInt(id_sql[j]), type, g[j], Integer.parseInt(roomId), gamename);
                        }
                    }
                }//end for
            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorUpdG", exd.Message);
            }
        
        }


        /// <summary>
        /// ��ѯ��㣬���û���¼�������򴴽���¼�����ͽ��
        /// </summary>
        /// <param name="session"></param>
        /// <param name="doc"></param>
        public static void doorLoadG(AppSession session, XmlDocument doc)
        {
            try
            {
                //������ƾ֤���
                if (!RCLogic.checkHasProof(session))
                {
                    return;
                }

                //
                XmlNode node = doc.SelectSingleNode("/msg/body");

                //"<session>" + session.RemoteEndPoint.ToString() +
                //"</session><nick><![CDATA[" + username + "]]></nick>"
                string usersession = node.ChildNodes[0].InnerText;
                string username = node.ChildNodes[1].InnerText;

                //
                //string[] g = logicGetG(username, "");
                DataSet ds = dbGetUser(MD5ByDotNET.hash(username), 0);

                //�ظ�action
                string saction = string.Empty;
                StringBuilder contentXml = new StringBuilder();

                //action
                saction = RCServerAction.loadGOK;

                //
                contentXml.Append("<session>").Append(usersession).Append("</session>");

                String id_sql = ds.Tables[0].Rows[0]["id_sql"].ToString();
                String g = ds.Tables[0].Rows[0]["g"].ToString();

                //
                contentXml.Append("<g id_sql='").Append(id_sql).Append("'>").Append(g).Append("</g>");


                //�ظ�
                Send(
                    session,
                    XmlInstruction.DBfengBao(saction, contentXml.ToString())
                    
                    );
                //log
                Log.WriteStrBySend(saction, session.RemoteEndPoint.ToString());


            }
            catch (Exception exd)
            {
                Log.WriteStrByException(CLASS_NAME, "doorLoadG", exd.Message);
            }
        }

        #endregion

        #region ��Ϸ�ײ�ͨѸ��Ϊ

        public static void Send(AppSession session, byte[] message)
        {
            //
            if (null == session)
            {
                return;
            }
            
            session.Send(message, 0, message.Length);

        }
        
        #endregion

        #region ���ݿ����

        /**
         * 
         * 
         * @return
         * @throws SQLException
         * @throws ClassNotFoundException 
         */
        public static DataSet dbGetUser(String id,int id_sql)
        {
            //8���ֶΣ���idFind
            //String[] u = new String[8+1];
        
            //boolean idFind = false;

            //
            String sql = "";        
        
            DataSet ds = null;
        
            if(id == "")
            {
            
                sql = "SELECT " +
                        "id," +
                        "id_sql," +
                        "n," +
                        "p," +
                        "g," +
                        "s," +
                        "m," +
                        "cd," +
                        "ld" + " " +
                        "FROM `" + 
                        RCLogic.TableUsers + "` WHERE id_sql = '" + id_sql + "' LIMIT 0 , 1";

        
            }else
            {
        
             sql = "SELECT " +
                        "id," +
                        "id_sql," +
                        "n," +
                        "p," +
                        "g," +
                        "s," +
                        "m," +
                        "cd," +
                        "ld" + " " +
                        "FROM `" + 
                        RCLogic.TableUsers + "` WHERE id = '" + id + "' LIMIT 0 , 1";
        
            }
        
            //
            ds = MySqlDBUtil.ExecuteQuery(sql);
        
            //
            //if (ds.Tables()[0].size() == 0)
            if(ds.Tables[0].Rows.Count == 0)
            {
                Log.WriteStrByMySqlWarnning("SELECT", "0",sql);
            
            }
          
            return ds;
       }

        public static int dbGetG(String id,int id_sql)
        {   
        
            DataSet ds = dbGetUser(id,id_sql);
                    
            return Integer.parseInt(ds.Tables[0].Rows[0]["g"].ToString());
       
        }

        /** 
         У������ Compares password values based on the MembershipPasswordFormat.

         @param password �û����봫����������(δ����)��
         @param dbpassword ���ݿ��������(δ����)
         @return 
        */
        private static Boolean memCheckPassword(String password, String dbpassword)
        {
            String pass1 = password;
            String pass2 = dbpassword;

            return pass1 == pass2;
        }

        /** 

         mem = Membership and Memory�ڴ����

         �û�����󳤶�:128      
         ������󳤶�:128 

         @param userSex
         @param userName
         @param userPwd
         @param userEmail
        */
        public static int memCreateUser(int userSex, String userName, String userPwd, String userEmail,int id_sql)
        {
    //C# TO JAVA CONVERTER TODO TASK: There is no preprocessor in Java:
                        ///#region �û���������������ȼ��

                if (userSex > 1)
                {
                        //status.argvalue = MembershipCreateStatus.UserRejected8;
                        return MembershipCreateStatus.UserRejected8;
                }

                if (userName.Length > 128)
                {
                        //status.argvalue = MembershipCreateStatus.UserRejected8;
                        return MembershipCreateStatus.UserRejected8;
                }

                if (userPwd.Length > 128)
                {
                        //status.argvalue = MembershipCreateStatus.UserRejected8;
                        return MembershipCreateStatus.UserRejected8;
                }

                //�������ٳ��ȼ��
                if (userPwd.Length < RCLogic.minRequiredPasswordLength)
                {
                        //status.argvalue = MembershipCreateStatus.ShortagePassword12;
                        return MembershipCreateStatus.ShortagePassword12; 
                }

                //�����ַ����
                if(RCLogic.selectDB.getMode() == DBTypeModel.WDQIPAI){

                    int len = RCLogic.filterRegisterAcountCharArr.Length;

                    for (int i = 0; i < len; i++)
                    {
                            //��contains������culture����indexOf��Ķ�
                            if (userName.Contains(RCLogic.filterRegisterAcountCharArr[i]))
                            //if (userName.IndexOf(DBLogic.filterRegisterAcountCharArr[i]) > -1)
                            {
                                    //status.argvalue = MembershipCreateStatus.FilterUserName13;
                                    return MembershipCreateStatus.FilterUserName13;
                            }
                    }
                
                }

    //C# TO JAVA CONVERTER TODO TASK: There is no preprocessor in Java:
                        ///#endregion

                //try
                //{
    //C# TO JAVA CONVERTER TODO TASK: There is no preprocessor in Java:
                                ///#region  �û����ظ����

                        Boolean isDuplicateUserName = false;

                        //11 = 6512bd43d9caa6e02c990b0a82652dca
                        String userNameMD5 = MD5ByDotNET.hash(userName);
                        DataSet ds = null;
                    
                        if(!(RCLogic.selectDB.getMode() == DBTypeModel.WDQIPAI))
                        {
                            ds = RCLogic.dbGetUser("", id_sql);
                        
                            if(ds.Tables[0].Rows.Count > 0)
                            {
                                isDuplicateUserName = true;
                            }
                    
                        }else{
                    
                            //WDQIPAI
                    
                    
                        }
                    

                        //String blockName = userNameMD5.substring(0, 1) + XFile.BLOCK_EXTENDED_NAME;

    //			XFile f = (XFile)BL_T_User_List.get(blockName);
    //
    //			for (int i = 0; i < f.doc.DocumentElement.ChildNodes.size(); i++)
    //			{
    //				XmlNode xn = f.doc.DocumentElement.ChildNodes[i];
    //
    //				if (userNameMD5.equals(xn.Attributes["id"].Value))
    //				{
    //                                    isDuplicateUserName = true;
                                        //break;
    //				}
    //
    //			} //end for

                        if (isDuplicateUserName)
                        {
                                //status.argvalue = MembershipCreateStatus.DuplicateUserName6;

                                return MembershipCreateStatus.DuplicateUserName6;
                        }

    //C# TO JAVA CONVERTER TODO TASK: There is no preprocessor in Java:
                                ///#endregion

    //C# TO JAVA CONVERTER TODO TASK: There is no preprocessor in Java:
                                ///#region �����û�

                        //�޸��ڴ�xml����δд���ļ�����ʱ��д�����
                    
                    
                        //XmlElement elem = f.doc.CreateElement("u");

                        //<u id=\"@id\" n=\"@n\" p=\"@p\" s=\"@s\" m=\"@m\" cd=\"@cd\" ld=\"@ld\" />
                        //XFile.setT_USER_LIST_ROW_ATT(elem, userNameMD5, userName, userPwd, (new Integer(userSex)).toString(), userEmail, new java.util.Date().toString(), new java.util.Date().toString());

                        //Add the node to the document.
                        //f.doc.DocumentElement.AppendChild(elem);

                        //
                        int rowsEffect = RCLogic.dbCreateUser(userNameMD5, userName,userPwd, 0, userSex,userEmail,
                                DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(),
                                DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(),
                                id_sql);
                    
                        Log.WriteStrByMySqlRecv("mysql insert", rowsEffect.ToString());
                    
                        //
                        //status.argvalue = MembershipCreateStatus.Success0;
                        return MembershipCreateStatus.Success0;

    //C# TO JAVA CONVERTER TODO TASK: There is no preprocessor in Java:
                                ///#endregion
    //            }
    //            catch (RuntimeException e)
    //            {
    //                    Log.WriteStrByException(CLASS_NAME, "memCreateUser", e.getMessage());
    //            }

                //return MembershipCreateStatus.ProviderError11;
        }

        public static int dbCreateUser(String id,String n,String p,int g, int s,String m,String cd,String ld,int id_sql)
        {
        
            String sql = "";  
        
            //�������û�ʱ, g�ֶ�Ĭ�ϲ���, ʹ�����ݿ�Ĭ������
            sql = "INSERT INTO `" + 
                    RCLogic.TableUsers + 
                    //"` (`id`, `id_sql`, `n`, `p`, `g`, `s`,`m`,`cd`,`ld`) VALUES (" + "'" + 
                    "` (`id`, `id_sql`, `n`, `p`, `s`,`m`,`cd`,`ld`) VALUES (" + "'" + 
                    id + "', '" + 
                    id_sql.ToString() + "', '" + 
                    n + "', '" + 
                    p + "', '" + 
                    //String.valueOf(g) + "', '" + 
                    s.ToString() + "', '" + 
                    m + "', '" + 
                    cd + "', '" + 
                    ld + "');";

            //String sql2 = "\u200E" + sql;
            return MySqlDBUtil.ExecuteNonQuery(sql);
    
        }

        /** 


         @param gamename
         @param username
         @param id
         @return 
        */
        public static String[] dbGetChart(String gamename, String username, String id, int id_sql)
        {
        
            DataSet du = dbGetUser(id,id_sql);

            String uid = "";

            uid = du.Tables[0].Rows[0]["id"].ToString();//du.Tables[0].Rows[0].get("id").toString();

            //
            String[] chart = new String[] {"0", "0","0", "0",uid};
            String[] pA = new String[]{"add","sub","add","sub"};//��һ���ܵģ��ڶ����ǽ����
            String total_p1B = "";

            String sql;
        
            int i = 0;

            DataSet ds;

            if (RCLogic.selectDB.sql.ToLower() == "mssql")
            {

                    for (i = 0; i < pA.Length; i++)
                    {
                            sql = "SELECT sum(p1B) AS total_p1B " + "FROM " + RCLogic.TableLog + " " + "WHERE n = '" + username + "' " + "AND p1A = '" + pA[i] + "' " + "AND line_n = 1 " + "AND game = '" + gamename + "'";

                            //ds = MsSqlDB.ExecuteQuery(sql);

                            //
    //                            if (ds.getTables(0).Rows.size() > 0)
    //                            {
    //                                    total_p1B = ds.Tables[0].Rows[0]["total_p1B"].toString();
    //
    //                                    if (!total_p1B.equals(""))
    //                                    {
    //                                            chart[i] = total_p1B;
    //                                    }
    //                            }
                    }

            }
            else if (RCLogic.selectDB.sql.ToLower() == "mysql")
            {

                    for (i = 0; i < pA.Length; i++)
                    {
                        if(i < 2)
                        {
                        
                            sql = "SELECT sum( p1B ) AS total_p1B " + "FROM `" + RCLogic.TableLog + "` " + "WHERE n = '" + username + "' " + "AND p1A = '" + pA[i] + "' " + "AND line_n = 1 " + "AND game = '" + gamename + "'";
                        }
                        else{
                             sql = "SELECT sum( p1B ) AS total_p1B " + "FROM `" + RCLogic.TableLog + "` " + "WHERE n = '" + username + "' " + "AND p1A = '" + pA[i] + "' " + 
                                     "AND t1 = '" + Log.getYear() + Log.getMonth() + Log.getDay() + "' " +
                                     "AND line_n = 1 " + "AND game = '" + gamename + "'";
                   
                        }
                        
                        ds = MySqlDBUtil.ExecuteQuery(sql);

                        //
                        //if (ds.getTables(0).size() > 0)
                        if(ds.Tables[0].Rows.Count > 0)
                        {
                                total_p1B = ds.Tables[0].Rows[0]["total_p1B"].ToString();

                                if (!String.IsNullOrEmpty(total_p1B))
                                {
                                        chart[i] = total_p1B;
                                }
                        }
                    }

            }
            else
            {

                    throw new IllegalArgumentException("can not find sql:" + RCLogic.selectDB.sql);

            }


            //
            return chart;

        }

       public static void WriteDBByMySqlRecv(String tbl_name, String actionStr, String rowCount, String cloumn, String param1, String param2, 
            String username, int roomId, String gamename,
            String id,int id_sql)
        {
            try
            {
                    String t = String.Format("%1$s:%2$s:%3$s,%4$s", Log.getHour(), Log.getMinute(), Log.getSecond(), Log.getMillisecond());

                    int t1 = Integer.parseInt(Log.getYear() + Log.getMonth() + Log.getDay());
                    //��������Ҫ�ˣ��뿴ȥ��t�ֶ�
                    int t2 = Integer.parseInt(Log.getHour() + Log.getMinute() + Log.getSecond());
                                   

                    String[] param1Arr = param1.Split(':');//param1.Split("[:]");//, -1);

                    String param11 = param1Arr[0];

                    int param12 = Integer.parseInt(param1Arr[1]);

                    //
                    StringBuilder insertSql = new StringBuilder();

                    insertSql.Append("insert into ");
                    insertSql.Append(tbl_name);
                    //��row,rows��mysql�﷨�ؼ��ֳ�ͻ���ָ���line_n
                    insertSql.Append(" (game,id,id_sql,n,room,t1,t2,t,a,line_n,c,p1A,p1B,p2) ");
                    insertSql.Append("values(");

                    insertSql.Append("'").Append(gamename).Append("',");
                                
                    insertSql.Append("'").Append(id).Append("',");
                    insertSql.Append("'").Append(id_sql).Append("',");
                    insertSql.Append("'").Append(username).Append("',");
                
                    insertSql.Append("'").Append(roomId).Append("',");

                    insertSql.Append("'").Append(t1).Append("',");
                    insertSql.Append("'").Append(t2).Append("',");
                    insertSql.Append("'").Append(t).Append("',");

                    insertSql.Append("'").Append(actionStr).Append("',");
                    insertSql.Append("'").Append(rowCount).Append("',");
                    insertSql.Append("'").Append(cloumn).Append("',");
                    //insertSql.Append("'" + param1 + "',");
                    insertSql.Append("'").Append(param11).Append("',");
                    insertSql.Append("'").Append(param12.ToString()).Append("',");

                    insertSql.Append("'").Append(param2).Append("'");
                

                    insertSql.Append(")");

                    //
                    MySqlDBUtil.ExecuteNonQuery(insertSql.ToString());
            }
            catch (Exception exd)
            {

                    Log.WriteStrByException(RCLogic.CLASS_NAME, "WriteDBByMySqlRecv", exd.Message);

            }
        }

        #endregion

        #region �����ļ�����

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string[] getDirs(string dir)
        {
            return Directory.GetDirectories(dir);
        }

        private static string[] getFiles(string dir)
        {
            return Directory.GetFiles(dir);
        }

        /// <summary>
        /// (RCLogic.DB_Users_Path + RCLogic.T_User_List + "\\" + XFile.block[i]
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool fileIsBlockExist(string dbPath, string tablePath, string blockFileName)
        {
            try
            {
                string file = dbPath + tablePath + "\\" + blockFileName;
                bool res = File.Exists(file);
                return res;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.ToString());
            }
        }

        public static bool fileIsExist(string file, FsoMethod method)
        {
            try
            {
                if (method == FsoMethod.File)
                {
                    return File.Exists(file);
                }
                else if (method == FsoMethod.Folder)
                {
                    return Directory.Exists(file);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.ToString());
            }
        }

        # region "�½�"

        /// <summary>
        /// �½��ļ����ļ���
        /// RCLogic.DB_Users_Path + RCLogic.T_User_List + "\\" + XFile.block[i], XFile.block_template, FsoMethod.File
        /// </summary>
        /// <param name="file">�ļ����ļ��м���·��</param>
        /// <param name="method">�½���ʽ</param>
        public static void fileCreateBlock(string dbPath, string tablePath, string blockFileName, string blockfileDefaultContent)
        {
            try
            {
                //
                string file = dbPath + tablePath + "\\" + blockFileName;
                string fileContent = blockfileDefaultContent;
                //
                WriteFile(file, fileContent);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.ToString());
            }
        }


        # endregion

        /// <summary>
        /// ���ļ�������ʽ������д�뵽ָ���ļ��У�������ļ����ļ��в������򴴽���
        /// </summary>
        /// <param name="file">�ļ�����ָ��·��</param>
        /// <param name="fileContent">�ļ�����</param>
        /// <returns>���ز���ֵ</returns>
        public static bool WriteFile(string file, string fileContent)
        {
            bool wsuccess = false;

            FileInfo f = new FileInfo(file);
            // ����ļ����ڵ��ļ��в������򴴽��ļ���
            if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);

            FileStream fStream = new FileStream(file, FileMode.Create, FileAccess.Write);
            //�����������utf-8
            StreamWriter sWriter = new StreamWriter(fStream, Encoding.GetEncoding("utf-8"));

            try
            {
                sWriter.Write(fileContent);
                wsuccess = true;
                return wsuccess;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.ToString());
            }
            finally
            {
                sWriter.Flush();
                fStream.Flush();
                sWriter.Close();
                fStream.Close();
            }
        }

        /// <summary>
        /// �ļ�ϵͳ�Ĵ������
        /// </summary>
        public enum FsoMethod
        {
            /// <summary>
            /// �����ڴ����ļ���
            /// </summary>
            Folder = 0,
            /// <summary>
            /// �����ڴ����ļ�
            /// </summary>
            File,
            /// <summary>
            /// �ļ����ļ��ж����봦��
            /// </summary>
            All
        }
        
        #endregion


        public static int parseInt(String value)
        {
            return Integer.parseInt(value);
        }
    
    }
}
