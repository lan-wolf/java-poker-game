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
using net.silverfoxserver.core.service;

namespace net.silverfoxserver.core.socket
{
    public class SessionConfig:IoSessionConfig
    {
        /// <summary>
        /// 1024, 2048, 4096
        /// ���ڼ�������Ƶ��ͼ���ָ�Ϊ8192
        /// </summary>
        private int _readBufferSize = 4096;//2048;

        /// <summary>
        /// ��������ģ�����������������
        /// </summary>
        private int _receiveTimeout = 0;

        /// <summary>
        /// Ĭ��2000
        /// </summary>
        private int _sendTimeout = 2000;

        /// <summary>
        /// 
        /// </summary>
        public SessionConfig()
        { 
        }

        public int getReadBufferSize()
        {
            return _readBufferSize;
        }

        public void setReadBufferSize(int readBufferSize)
        {
            this._readBufferSize = readBufferSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getReceiveTimeout()
        {
            return _receiveTimeout;
        }

        public void setReceiveTimeout(int value)
        {
            this._receiveTimeout = value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getSendTimeout()
        {
            return _sendTimeout;
        }

        public void setSendTimeout(int value)
        {
            this._sendTimeout = value;
        }

    }
}
