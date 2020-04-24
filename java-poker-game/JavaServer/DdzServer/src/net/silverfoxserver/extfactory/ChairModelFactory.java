/*
 * SilverFoxServer: massive multiplayer game server for Flash, ...
 * VERSION:3.0
 * PUBLISH DATE:2015-9-2 
 * GITHUB:github.com/wdmir/521266750_qq_com
 * UPDATES AND DOCUMENTATION AT: http://www.silverfoxserver.net
 * COPYRIGHT 2009-2015 SilverFoxServer.NET. All rights reserved.
 * MAIL:521266750@qq.com
 */
package net.silverfoxserver.extfactory;

import net.silverfoxserver.core.model.IChairModel;
import net.silverfoxserver.core.model.IRuleModel;
import net.silverfoxserver.extmodel.ChairModelByDdz;

/**
 *
 * @author ACER-FX
 */
public class ChairModelFactory {
    
    public static IChairModel Create(int id, IRuleModel rule)
    {

            return new ChairModelByDdz(id, rule);


    }

}
