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
using System.IO;
using System.Diagnostics;
using net.silverfoxserver.core.model;
using net.silverfoxserver.core.util;

namespace net.silverfoxserver.core.log
{
    public static class Log
    {
        private static int _createdDayOfYear;

        /// <summary>
        /// �����ֹ�����logsĿ¼���������ɲ����ļ�
        /// </summary>
        public const string fileDir = "logs\\";        
        public const string fileExtName = ".txt";

        private static string _fileName;

        /// <summary>
        /// ��ӡ����
        /// </summary>
        private static LoggerLvl _lvl;
                
        /**
         * 
         * Logger����ͬ���������������·��
         */ 
        private static TextWriterTraceListener _write;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn">Ϊ���ַ������ʾ������</param>
        public static void init(string fn, LoggerLvl lvl)
        {
            _createdDayOfYear = -1;

            if ("" == fn)
            {
                WriteStr2("you need set fileName for WriteFile!");
            }

            _fileName = fn;

            _lvl = lvl;

            string fileFullDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + fileDir;

            if(fileIsExist(fileFullDir,FsoMethod.Folder))
            {
            
            }else
            {
                WriteStr2("[LOG] " + fileFullDir);
                Directory.CreateDirectory(fileFullDir);
            
            }

              
            //���ɵ���clear������ѱ��Ҳɾ��
            //Trace.Listeners.Clear();
            Trace.AutoFlush = true;

        }

        #region �����ļ���

        public static  bool fileIsExist(string file, FsoMethod method)
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
            File = 1,
            /// <summary>
            /// �ļ����ļ��ж����봦��
            /// </summary>
            All = 2
        }


        #endregion

        #region ��ȡʱ��
        public static string getYear()
        {
            string year = DateTime.Now.Year.ToString();

            return year;        
        }

        public static string getMonth()
        {
            string month = DateTime.Now.Month.ToString();

            if (1 == month.Length)
            {
                month = "0" + month;
            }

            return month;
        }

        public static string getDay()
        {
            string day = DateTime.Now.Day.ToString();

            if (1 == day.Length)
            {
                day = "0" + day;
            }

            return day;
        
        }

        public static string getHour()
        {
            string hour = DateTime.Now.Hour.ToString();

            if (1 == hour.Length)
            {
                hour = "0" + hour;
            }

            return hour;
        }

        public static string getMinute()
        {
            string minute = DateTime.Now.Minute.ToString();

            if (1 == minute.Length)
            {
                minute = "0" + minute;
            }

            return minute;
        }

        public static string getSecond()
        {
            string second = DateTime.Now.Second.ToString();

            if (1 == second.Length)
            {
                second = "0" + second;
            }

            return second;
        }

        public static string getMillisecond()
        {
            string millisecond = DateTime.Now.Millisecond.ToString();
           
            if (1 == millisecond.Length)
            {
                millisecond = "0" + "0" + millisecond;
            }
            else if (2 == millisecond.Length)
            {
                millisecond = "0" + millisecond;
            }
            
            return millisecond;
        }

        #endregion

        #region Console ��ӡ

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="funcName"></param>
        /// <param name="cause"></param>
        /// <param name="source"></param>
        /// <param name="stack"></param>
        public static void WriteStrByExceptionByNoWriteFile(string className, string funcName, string cause, string source, string stack)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9} {10}:{11} {12}:{13}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 

                SR.Exce_p_tion,
                className, 
                SR.Func_tion,
                funcName, 
                SR.Casue,
                cause, 

                SR.Source,
                source, 
                SR.Stack,
                stack)
            );

            //�˺�����Write File��ֻ��ӡ
        }

        /// <summary>
        /// try-catch������쳣����
        /// </summary>
        /// <param name="ipAndPort"></param>
        /// <param name="errCode"></param>
        /// <param name="cause"></param>
        public static void WriteStrByException(string className, string funcName, string cause)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9}", 
                getHour(), 
                getMinute(),
                getSecond(),
                getMillisecond(),

                SR.Exce_p_tion,
                className, 
                SR.Func_tion,
                funcName, 
                SR.Casue,
                cause)
            );

            //
            WriteFileByException(className, funcName, cause);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="funcName"></param>
        /// <param name="cause"></param>
        /// <param name="source"></param>
        public static void WriteStrByException(string className, string funcName, string cause, string source)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9} {10}:{11}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 
                
                SR.Exce_p_tion,
                className, 
                SR.Func_tion,
                funcName, 
                SR.Casue,
                cause, 

                SR.Source,
                source)
            );

            //
            WriteFileByException(className, funcName, cause, source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="funcName"></param>
        /// <param name="cause"></param>
        /// <param name="stack"></param>
        public static void WriteStrByException(string className, string funcName, string cause, string source,string stack)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9} {10}:{11} {12}:{13}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(),

                SR.Exce_p_tion,
                className,
                SR.Func_tion,
                funcName,
                SR.Casue,
                cause,

                SR.Source,
                source,
                SR.Stack,
                stack)
            );

            //
            WriteFileByException(className, funcName, cause, source, stack);
        }

        /// <summary>
        /// �������쳣����
        /// </summary>
        /// <param name="ipAndPort"></param>
        /// <param name="errCode"></param>
        /// <param name="cause"></param>
        public static void WriteStrByArgument(string className, string funcName, string arguName, string cause)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9} {10}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(),

                SR.Clas_s_Name,
                className, 
                SR.Func_tion,
                funcName, 
                SR.Param,
                arguName, 
                cause)
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errCode"></param>
        /// <param name="ipAndPort"></param>
        /// <param name="cause">�ر�ԭ��</param>
        /// <returns></returns>
        public static void WriteStrByExceptionClose(string ipAndPort, string errCode, string cause)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(),
 
                SR.Disconnect_the_server_exception,
                ipAndPort, 
                SR.Desc,
                errCode, 
                SR.Casue,
                cause)
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAndPort"></param>
        /// <param name="cause">�ر�ԭ��</param>
        /// <returns></returns>
        public static void WriteStrByClose(string ipAndPort, string cause)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
              string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7}", 
              getHour(), 
              getMinute(), 
              getSecond(), 
              getMillisecond(), 

              SR.Disconnect,
              ipAndPort, 
              SR.Casue,
              cause)


            );
        }

        /// <summary>
        /// 
        /// </summary>
        public static void WriteStrByVcNoValue(string actionStr, string ipAndPort)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                    LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6}", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 

               SR.VcNoValue,
               actionStr, 
               ipAndPort)
            );
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionStr"></param>
        /// <param name="ipAndPort"></param>
        /// <param name="vc_client"></param>
        /// <param name="vc_server"></param>
        /// <param name="doc_OuterXml"></param>
        public static void WriteStrByVcNoMatch(string actionStr,string ipAndPort,
                                               string vc_client,string vc_server,
                                               string vc_XmlMsg)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} \n\tC:{7} \n\tS:{8} \n\tXmlMsg:{9}",
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 
               
               SR.VcErr,
               actionStr, 
               ipAndPort, 
               vc_client, 
               vc_server, 
               vc_XmlMsg)
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="actionStr"></param>
        /// <param name="ipAndPort"></param>
        public static void WriteStrByRecv(string actionStr, string ipAndPort)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            //

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} ", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 

               SR.Recv,
               actionStr, 
               ipAndPort)
            );
        }

        /// <summary>
        /// ת��
        /// </summary>
        /// <param name="target">ת����Ŀ��</param>
        /// <param name="actionStr"></param>
        /// <param name="ipAndPort"></param>
        public static void WriteStrByTurn(string target, string ipAndPort, string actionStr)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
                   string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6} IP:{7} ", 
                   getHour(), 
                   getMinute(), 
                   getSecond(), 
                   getMillisecond(), 

                   SR.Turn,
                   actionStr,
                   target, 
                   ipAndPort)
               );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="ipAndPort"></param>
        /// <param name="actionStr"></param>
        public static void WriteStrByTurn(string target, string ipAndPort, string actionStr,string n,string v)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
                   string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6} IP:{7} n:{8} v:{9}",
                   getHour(),
                   getMinute(),
                   getSecond(),
                   getMillisecond(),

                   SR.Turn,
                   actionStr,
                   target,
                   ipAndPort,
                   n,
                   v)
               );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionStr"></param>
        public static void WriteStrByServerRecv(string actionStr,string serverName)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            //

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4} {5} {6}:{7} ", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(),

               SR.From,
               serverName,

               SR.Recv,               
               actionStr)
            );
        }

         public static void WriteStrByMySqlWarnning(String actionStr, String rowCount,String sql)
	    {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

                //����:SELECT Warnning ԭ��:0 

            Console.WriteLine(String.Format("[%1$s:%2$s:%3$s,%4$s] %5$s:%6$s %7$s:%8$s %9$s:%10$s",
                            getHour(), getMinute(), getSecond(), getMillisecond(), 
                            SR.getWarning(), actionStr,
                            SR.getAffectedRows(), rowCount,
                            SR.getSqlStatement(), sql
                    ));
	    }

        public static void WriteStrByMySqlRecv(string actionStr, string rowCount)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} ", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 
               
               SR.Recv,
               actionStr, 

               SR.AffectedRows,
               rowCount)
            );
        }

        public static void WriteStrByMySqlRecv(string actionStr, string rowCount, string cloumn, string param1, string username)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9} {10} {11}",
               getHour(),
               getMinute(),
               getSecond(),
               getMillisecond(),

               SR.Recv,
               actionStr,
               SR.AffectedRows,
               rowCount,
               SR.Cloumn,
               cloumn,
               param1,
               username)
            );
        }
         

        public static void WriteStrByMySqlRecv(string actionStr, string rowCount, string cloumn, string param1, string param2, string username)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} {8}:{9} {10} {11} {12}", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 
               
               SR.Recv,
               actionStr, 
               SR.AffectedRows,
               rowCount, 
               SR.Cloumn,
               cloumn, 
               param1, 
               param2, 
               username)
            );
        }



        public static void WriteStrByMySqlWarnning(string actionStr, string rowCount)
        {
            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6}:{7} ", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 
               
               SR.Warning,
               actionStr, 
               SR.Casue,
               rowCount)
            );
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionStr"></param>
        /// <param name="ipAndPort"></param>
        public static void WriteStrBySend(string actionStr, string ipAndPort)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} ", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 
                
                SR.Respond,
                actionStr, 
                ipAndPort)
            );
        }

        public static void WriteStrBySend(string actionStr, string ipAndPort,string cause)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} {7}:{8}",
                getHour(),
                getMinute(),
                getSecond(),
                getMillisecond(),

                SR.Respond,
                actionStr,
                ipAndPort,
                SR.Casue,
                cause)
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public static void WriteStrByConnect(string content)
        {
           //�����ӡ

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}", getHour(), getMinute(), getSecond(), getMillisecond(), content)
           );
        }

        public static void WriteStrBySendFailed(string actionStr, string ipAndPort)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} {7}", 
               getHour(), 
               getMinute(), 
               getSecond(), 
               getMillisecond(), 
               
               SR.Respond_failed,
               actionStr, 
               ipAndPort,
               SR.Disconnected)
           );
        }

        public static void WriteStrByMultiSend(string actionStr, List<IUserModel> ipAndPort)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            string ipAndPortStr = string.Empty;

            for(int i=1;i<=ipAndPort.Count;i++)
            {
                ipAndPortStr += ipAndPort[i-1].getNickName();

                if (i == ipAndPort.Count)
                {
                    //nothing
                }
                else
                {
                    ipAndPortStr += ",";
                }
            }

            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} ", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 
                
                SR.TurnGroup,
                actionStr, 
                ipAndPortStr)
            );
        }

        public static void WriteStrByMultiSend(string actionStr, string ipAndPort)
        {
            if (LoggerLvl.CLOSE0 == _lvl ||
                LoggerLvl.NORMAL1 == _lvl)
            {
                return;
            }

            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} IP:{6} ", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 
                
                SR.TurnGroup,
                actionStr, 
                ipAndPort)
            );
        }

        public static void WriteStrByWarn(string content)
        {
            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} ", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 

                SR.Warning,
                content)
            );
        }


        /// <summary>
        /// ͨ��
        /// </summary>
        public static void WriteStr(string content)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            Console.WriteLine(
               string.Format("[{0}:{1}:{2},{3}] {4}", getHour(), getMinute(), getSecond(), getMillisecond(), content)
           );

            //
            WriteFile(content);
        }

        /// <summary>
        /// ͨ�ã�ǰ����ʱ����ʾ
        /// </summary>
        /// <param name="messageStr"></param>
        public static void WriteStr2(string messageStr)
        {
            Console.WriteLine(
               string.Format("{0}", messageStr)
           );
        }
        #endregion

        #region File ��ӡ

        private static void checkFile()
        {
            if ("" == _fileName)
            {
                WriteStr2("you need set fileName for WriteFile!");
                return;
            }

            //�����������ļ�����Ӧ
            //���������ǰ���md5����ļ�,��:b7253c9b-b9bc-4fbe-90bf-e9a102338dc9DdzLogic_2012_4_15.txt
            //int nowDayOfYear = DateTime.Now.DayOfYear;

            //if (_createdDayOfYear != nowDayOfYear)
            if (_createdDayOfYear != DateTime.Now.DayOfYear)
            {
                if (null != _write)
                {
                    Trace.Listeners.Remove(_write);
                }

                //
                _createdDayOfYear = DateTime.Now.DayOfYear;

                //
                string fileFullPath = getFileFullPath();

                _write = new TextWriterTraceListener(fileFullPath);

                Trace.Listeners.Add(_write);
                Trace.AutoFlush = true;

                
            }
            
            

        }

        /// <summary>
        /// ����ҪСʱ������ƿ�������ˬЩ
        /// 
        /// writeÿСʱ����һ��
        /// </summary>
        /// <returns></returns>
        public static string getFileFullPath()
        {
            return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + fileDir +
                   _fileName + "_" +
                   DateTime.Now.Year + "_" +
                   DateTime.Now.Month + "_" +
                   DateTime.Now.Day +                   
                   fileExtName;
        }



        /**
         * �����������txt��ʽ��
         * xml��ʽ��Ϊ��ͷ��β��㣬����޷����
         * ���������.txt�ļ������Բ鿴
         * xml���ʽ������ͳ��
         * 
         */ 
        public static void WriteFileByMySqlRecv(string actionStr, string rowCount, string cloumn, string param1, string param2, string username) 
        {
            //�����ӡ������logLvl����

            //
            checkFile();

            //[18:59:41,953] �յ�:mysql update Ӱ������:1 extcredits1,add:3,1026,iui2004
            Trace.WriteLine(

                 //string.Format("[{0}:{1}:{2},{3}] �յ�:{4} Ӱ������:{5} {6},{7},{8},{9}", getHour(), getMinute(), getSecond(), getMillisecond(), actionStr, rowCount, cloumn, param1, param2, username)

                 string.Format("<{0} t='{1}:{2}:{3},{4}' a='{5}' row='{6}' c='{7}' p1='{8}' p2='{9}' n='{10}' />", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), actionStr, rowCount, cloumn, param1, param2, username)
                );
        }

        /// <summary>
        /// try-catch������쳣����
        /// ����Ҫtrace��WriteStrByException����ñ�����
        /// </summary>
        /// <param name="ipAndPort"></param>
        /// <param name="errCode"></param>
        /// <param name="cause"></param>
        private static void WriteFileByException(string className, string funcName, string cause)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            //
            checkFile();

            //����Ҫtrace��WriteStrByException����ñ�����

            Trace.WriteLine(
               string.Format("<{0} t='{1}:{2}:{3},{4}' content='�쳣:��:{5} ����:{6} ԭ��:{7}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), className, funcName, cause)
           );
        }


        private static void WriteFileByException(string className, string funcName, string cause,string source)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            //
            checkFile();

            //����Ҫtrace��WriteStrByException����ñ�����

            Trace.WriteLine(
               string.Format("<{0} t='{1}:{2}:{3},{4}' content='�쳣:��:{5} ����:{6} ԭ��:{7} Դ:{8}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), className, funcName, cause, source)
           );
        }

        private static void WriteFileByException(string className, string funcName, string cause, string source, string stack)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            //
            checkFile();

            //����Ҫtrace��WriteStrByException����ñ�����

            Trace.WriteLine(
               string.Format("<{0} t='{1}:{2}:{3},{4}' content='�쳣:��:{5} ����:{6} ԭ��:{7} Դ:{8} ջ{9}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), className, funcName, cause, source, stack)
           );
        }

        public static void WriteFileByLoginSuccess(string accountName, string fromIp)
        {

            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            //
            checkFile();

            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5} {6} IP:{7}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 
                
                SR.User,
                accountName, 
                SR.LoginSuccess,
                fromIp)
                );

            //Console.WriteLine(
            //   string.Format("<{0} t='{1}:{2}:{3},{4}' online='{5}' logined='{6}' ip='{7}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), count.ToString(), accountName, fromIp)
            //   );

            Trace.WriteLine(
                string.Format("<{0} t='{1}:{2}:{3},{4}' logined='{5}' ip='{6}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), accountName, fromIp)
            );
        }

        public static void WriteFileByOnlineUserCount(int count)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            //
            checkFile();

            Console.WriteLine(
                string.Format("[{0}:{1}:{2},{3}] {4}:{5}", 
                getHour(), 
                getMinute(), 
                getSecond(), 
                getMillisecond(), 
                
                SR.Online,
                count.ToString())
                );

            //Console.WriteLine(
            //   string.Format("<{0} t='{1}:{2}:{3},{4}' online='{5}' logined='{6}' ip='{7}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), count.ToString(), accountName, fromIp)
            //   );

            Trace.WriteLine(
                string.Format("<{0} t='{1}:{2}:{3},{4}' online='{5}'/>", _fileName, getHour(), getMinute(), getSecond(), getMillisecond(), count.ToString())
            );
        }

        /// <summary>
        /// ͨ��
        /// </summary>
        public static void WriteFile(string content)
        {
            if (LoggerLvl.CLOSE0 == _lvl)
            {
                return;
            }

            //
            checkFile();

            Trace.WriteLine(
               string.Format("<{0} t='{1}:{2}:{3},{4}' content='{5}' />", _fileName,getHour(), getMinute(), getSecond(), getMillisecond(), content)
           );
        }

        #endregion
    }
}
