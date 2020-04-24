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
using net.silverfoxserver.core.logic;

namespace net.silverfoxserver.core.protocol
{
    /// <summary>
    /// const �൱���� static readonly
    /// </summary>
    public class DBServerAction
    {
        /// <summary>
        /// ֤����
        /// </summary>
        public readonly string needProof = "needProof";

        public readonly string proofOK = "proofOK";
        public readonly string proofKO = "proofKO";

        public readonly string regOK = "regOK";
        public readonly string regKO = "regKO";

        public readonly string logOK = "logOK";
        public readonly string logKO = "logKO";


        public DBServerAction()
        {


        }

        
    }
}
