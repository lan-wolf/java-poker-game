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

namespace net.silverfoxserver.core.service
{
    /// <summary>
    /// ���������ã�����Ҫר�ŵ�Adapter
    /// </summary>
    public interface IoSessionConfig
    {
        /**
         * Returns the size of the read buffer that I/O processor allocates
         * per each read.  It's unusual to adjust this property because
         * it's often adjusted automatically by the I/O processor.
         */
        int getReadBufferSize();

        /**
         * Sets the size of the read buffer that I/O processor allocates
         * per each read.  It's unusual to adjust this property because
         * it's often adjusted automatically by the I/O processor.
         * 
         * Ŀǰ�������Զ�������С
         */
        void setReadBufferSize(int readBufferSize);

        /**
         * ����������������
         * ��������Ӧ�ã��˲����ǳ���Ҫ
         */
        int getReceiveTimeout();
        void setReceiveTimeout(int value);

        /**
         * ����������������
         * ��������Ӧ�ã��˲����ǳ���Ҫ
         */
        int getSendTimeout();
        void setSendTimeout(int value);

    }
}
