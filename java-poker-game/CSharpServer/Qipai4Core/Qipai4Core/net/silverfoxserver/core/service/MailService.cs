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
using System.Xml;
using net.silverfoxserver.core.model;

namespace net.silverfoxserver.core.service
{
    public class MailService
    {
        private List<Mail> _pipe;

        public MailService()
        {
            _pipe = new List<Mail>();        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromUser">��ʹ�ÿ����Ĳ���</param>
        /// <param name="toUser">��ʹ�ÿ����Ĳ���</param>
        /// <param name="n">val Attributes["n"]</param>
        /// <param name="c">val InnerText</param>
        public void setMvars(IUserModel fromUser,IUserModel toUser,string n,string param)
        {
            Mail m = new Mail(fromUser, toUser, n, param);
           _pipe.Add(m);
        }

        public int Length()
        {
            return _pipe.Count;
        }

        public Mail GetMail(int ind)
        {
            return _pipe[ind]; 
        }

        /// <summary>
        /// ���ͳɹ����ִ��shift_step2
        /// ������ȷ������������logic�ĺ�����Ӧ���Ƕ�ʱ������ٵ�¼���û�
        /// �Ƿ��б�Ҫȷ�������Ժ�����û���������޸�
        /// </summary>
        public void DelMail(int ind)
        {
            _pipe.RemoveAt(ind);
        }

    }
}
