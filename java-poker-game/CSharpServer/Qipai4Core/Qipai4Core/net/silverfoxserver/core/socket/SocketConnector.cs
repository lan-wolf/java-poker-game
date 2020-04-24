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
using System.Threading;
//
using System.IO;
//
using System.Net;
using System.Net.Sockets;
//
using net.silverfoxserver.core.log;
using net.silverfoxserver.core.service;
using net.silverfoxserver.core.buffer;
using net.silverfoxserver.core.util;

namespace net.silverfoxserver.core.socket
{
    public class SocketConnector
    {
        /// <summary>
        /// 
        /// </summary>
        private TcpClient _tcpClient = new TcpClient();

        /// <summary>
        /// Ҫ���ӵķ�����ip
        /// </summary>
        private string _connect_serverIp = "127.0.0.1";

        /// <summary>
        ///  Ҫ���ӵķ������Ķ˿�
        /// </summary>
        private int _connect_serverPort = 9339;

        public string getRemoteEndPoint()
        {
            return _connect_serverIp + ":" + _connect_serverPort;
        }

        public Socket getSocket()
        {
            return _tcpClient.Client;            
        }


        /// <summary>
        /// ���ӷ�������֤��
        /// </summary>
        private string _connect_serverProof = "www.wdmir.net";

        public string getProof()
        {
            return this._connect_serverProof;
        }

        /// <summary>
        /// �����ݿ�����߳�
        /// </summary>
        private Thread _connectThread;

        /// <summary>
        /// �����ݿ�����������߳�
        /// </summary>
        //private Thread writeThread;

        /// <summary>
        /// �������ݿ�����͵����ݣ�д��ǰ��ת��Byte[]
        /// </summary>
        public volatile IList<byte[]> writeData = new List<byte[]>();

        /// <summary>
        /// ������յ�������
        /// �������ʼ������������Ҫ��ʼ��
        /// </summary>
        public ByteBuffer buf;

        /// <summary>
        /// 
        /// </summary>
        private IoHandler _handler;

        public IoHandler handler()
        {
            return _handler;
        }

        /// <summary>
        /// ���ջ�������С
        /// ��Ϸ������������С
        /// ���ݿ���Ҫ���һ��
        /// 
        /// ����ط��ǿ�ѡ�ģ�����ֱ��new ��
        /// </summary>
        private IoSessionConfig _sessionConfig = new SessionConfig();

        public IoSessionConfig getSessionConfig()
        {
            return _sessionConfig;
        }
                
        public SocketConnector()
        {
            
        }

        public SocketConnector(string proof)
        {
            this._connect_serverProof = proof;
        }

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="handler"></param>
        public void setHandler(IoHandler handler)
        {
            this._handler = handler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAdr"></param>
        /// <param name="port"></param>
        public void connect(string ipAdr, int port)
        {
            //
            this._connect_serverIp = ipAdr;
            this._connect_serverPort = port;

            //���캯�������ò��ã���ΪҪ��setReadBufferSize�����ȷ��
            buf = new ByteBuffer(getSessionConfig().getReadBufferSize());

            //
            _connectThread = new Thread(connectFunction);
            _connectThread.Name = _connect_serverIp + ":" + _connect_serverPort;
            _connectThread.Start();    
        }

        
        /// <summary>
        /// 
        /// </summary>
        private void connectFunction()
        {
            try
            {
                //SessionConfig
                _tcpClient.ReceiveTimeout = this.getSessionConfig().getReceiveTimeout();
                _tcpClient.SendTimeout = this.getSessionConfig().getSendTimeout();
                //����Ĳ��ȶ���,������Ҫ��2
                _tcpClient.ReceiveBufferSize = this.getSessionConfig().getReadBufferSize() * 2;

                //���������ṩ���򽫷�������ʵı��� IP ��ַ�Ͷ˿ںš�
                //TcpClient ��һֱ��ֹ��ֱ�����ӳɹ���ʧ�ܡ�
                //���ô˹��캯����ֻ��һ�����ɷ���س�ʼ�������� DNS ���������������ӡ�                
                _tcpClient.Connect(IPAddress.Parse(_connect_serverIp), _connect_serverPort);

                if (_tcpClient.Connected)
                {
                    //                    
                    //Log.WriteStr("���ӷ��� " + _connect_serverIp + ":" + _connect_serverPort + " �ɹ�!");

                    Log.WriteStr(
                        SR.GetString(SR.Connect_service_success, _connect_serverIp + ":" + _connect_serverPort)
                    );

                }

                while(_tcpClient.Connected)
                {
                    int b = _tcpClient.GetStream().ReadByte();//������while(Data����)cpu�ᵽ100%

                    //super socket�᷵��-1
                    //if (-1 == b)
                    //{
                       
                    //}
                    //else 
                    if (0x00 != b)
                    {
                        buf.put((Byte)b);
                    }
                    else
                    {
                        handler().messageReceived(_tcpClient.Client, buf.ToByteArray());                      
                        buf = new ByteBuffer(getSessionConfig().getReadBufferSize());
                    }//end if
                }//end while


                //
                Log.WriteStr("lost connect " + _connect_serverIp + ":" + _connect_serverPort);
                  

            }
            catch (System.IO.IOException exio)//�ڴ������ݹ�����ʧȥ����
            {
                //Log.WriteStr("�ڴ������ݹ�����ʧȥ���ӣ�Message:" + exio.Message);

                Log.WriteStrByException("SocketConnector", "connectFunction", exio.Message);

                //500�����ִ������
                Thread.Sleep(1000);

                //IO�����Ժ�Ҫ�ָ�  
                _tcpClient.Close();
                _tcpClient = new TcpClient();

                //�Զ�������ע�ⲻ����ʱ
                //connectFunction();
                TimeUtil.setTimeout(1000, connectFunction);
            }
            catch (Exception exd)
            {
                //Logger.WriteStrByConnect("���ӷ����� " + _connect_serverIp + ":" + _connect_serverPort + " ʧ�ܣ�ԭ��:" + exd.Message);

                Log.WriteStrByConnect(
                SR.GetString(SR.Connect_service_failed, _connect_serverIp + ":" + _connect_serverPort, exd.Message)
                );

                //500�����ִ������
                Thread.Sleep(500);

                //IO�����Ժ�Ҫ�ָ�
                _tcpClient.Close();
                _tcpClient = new TcpClient();

                //�Զ�������ע�ⲻ����ʱ��
                //�������ϼ��ɣ������ǽ������ݣ����ݿ��Ǳ�ҲҪ�����У�ȷ��ÿ��������
                //connectFunction();

                TimeUtil.setTimeout(1000, connectFunction);
            }        
        }

        /// <summary>
        /// http://msdn.microsoft.com/zh-cn/library/system.net.sockets.tcpclient(VS.80).aspx
        /// 
        /// Ҫ���ͺͽ������ݣ���ʹ�� GetStream ��������ȡһ�� NetworkStream��
        /// ���� NetworkStream �� Write �� Read ������Զ������֮�䷢�ͺͽ������ݡ�
        /// ʹ�� Close �����ͷ��� TcpClient ������������Դ��
        /// 
        /// Translate the passed message into ASCII and store it as a Byte array.
        /// Byte[] data = System.Text.Encoding.ASCII.GetBytes(writeMessage);
        /// </summary>
        public void Write(byte[] message)
        {
            //��������Ƿ���Ҫ��������𣬷������ݿ�����Ǳ߽��ջ����
            this.writeData.Add(message);

                      
            //
            if (_tcpClient.Connected)
            {
                //���ϴε�һ�鷢
                while (this.writeData.Count > 0)
                {
                    // Send the message to the connected TcpServer. 
                    _tcpClient.GetStream().Write(writeData[0], 0, writeData[0].Length);

                    //
                    writeData.RemoveAt(0);
                }//end while
            }//end if   
            else {

                Log.WriteStr("tcpClient not Connected, " + _connect_serverIp + ":" + _connect_serverPort);
                                         
            }
     
        }
    }
}
