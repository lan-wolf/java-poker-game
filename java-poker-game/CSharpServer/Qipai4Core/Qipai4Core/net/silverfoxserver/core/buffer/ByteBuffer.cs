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

namespace net.silverfoxserver.core.buffer
{
    /// <summary>
    /// ԭ���ǿ����������е�һ����
    /// </summary>
    public class ByteBuffer
    {
        /// <summary>
        /// ָ�����ȵ��м�����
        /// </summary>
        private Byte[] _content;
        
        //��ǰ���鳤��
        private int _current_length = 0;

        //��󷵻�����
        private Byte[] _return_array;

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// ע��sizeֵ�������4096,�������Ϊ4096
        /// ����������ڴ治�ܴ���4096
        /// </summary>
        public ByteBuffer(int size)
        {
            if (size > 4096)
            {
                size = 4096;
            }

            //
            _content = new Byte[size];
            
            //
            _current_length = 0;
        }

        /// <summary>
        /// ��ByteBufferѹ��һ���ֽ�
        /// </summary>
        /// <param name="by">һλ�ֽ�</param>
        public void put(Byte b)
        {
            if (_current_length >= (_content.Length-1))
            {
                //new һ����1����
                Byte [] tmp_array = new Byte[_current_length*2];
                //����
                Array.Copy(_content, 0, tmp_array, 0, _content.Length);
                //
                _content = tmp_array;
            }

            _content[_current_length++] = b;
        }

         /// <summary>
        /// ��ȡ��ǰByteBuffer�ĳ���
        /// </summary>
        public int Length
        {
            get
            {
                return _current_length;
            }
        }
       
        /// <summary>
        /// ��ȡByteBuffer�����ɵ�����
        /// ���ȱ���С�� [MAXSIZE]
        /// </summary>
        /// <returns>Byte[]</returns>
        public Byte[] ToByteArray()
       {
            //�����С
            _return_array = new Byte[_current_length];
            //����ָ��
            Array.Copy(_content, 0, _return_array, 0, _current_length);
            return _return_array;
        }


    }
}
