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

namespace DdzServer.net.silverfoxserver.extmodel
{
    public class PaiRuleCompare
    {
        public static List<string> validate(List<int> pcArr)
		{  	
            //copy param
		  	List<int> valiArr =  new List<int>(pcArr);

            //loop use
            int valiArrLen = valiArr.Count;
		  	  	
		  	//����,Ԫ����1,Ԫ����2				
		  	List<string> valiPx = new List<string>();
		  	  			  	  	
		  	switch(valiArrLen)
		  	{
                case 2: 
                    valiPx = parse_px_2(valiArr); 
                    break;//���� or ˫��	  	
                case 4: 
                    valiPx = parse_px_4(valiArr); 
                    break;//����һ or ը��  	  		
		  	  		
		  	 }//end switch
		  	  			  				  		
		  	return valiPx;	  	  	
    
        
        }


        /// <summary>
        /// ֻ��֤�����ǲ���ը�����Ż�����
        /// �ָ����û�Ҫ�󣬻��ҲҪ�ж�
        /// </summary>
        /// <param name="pcArr"></param>
        /// <returns></returns>
        public static Boolean validate_bomb(List<int> pcArr)
		{
            //loop use
            int valiArrLen = pcArr.Count;

            PaiCode.sort(pcArr);//sort�Ӵ�С

            if (4 == valiArrLen)
            {
                if ("bomb" == parse_px_4(pcArr)[0])
                {
                    return true;
                }            
            }

            return false;
    
        }

        public static Boolean validate_huojian(List<int> pcArr)
        {
            //loop use
            int valiArrLen = pcArr.Count;

            PaiCode.sort(pcArr);//sort�Ӵ�С

            if (2 == valiArrLen)
            {
                if ("huojian" == parse_px_2(pcArr)[0])
                {
                    return true;
                }
            }

            return false;

        }

        //�������� 2
		  //2���ƵĵĿ�����
		  //��֤�ƵĺϷ��ԣ�ͬ����ȡԪ����
          private static List<string> parse_px_2(List<int> pcArr)
		  {	
		  		//
		  		List<string> px = new List<string>();
		  		
		  		//���
        
		  		if(
		  		
		  		(pcArr[0] == PaiCode.JOKER_XIAO && pcArr[1] == PaiCode.JOKER_DA) ||
		  		(pcArr[0] == PaiCode.JOKER_DA && pcArr[1] == PaiCode.JOKER_XIAO)
		  		
		  		)
		  		{
                    px.Add("huojian");
                    px.Add(PaiCode.JOKER_XIAO.ToString());
                    px.Add(PaiCode.JOKER_DA.ToString());
		  			
		  			return px;		  		
		  		}		  
		  		
		  		//����
		  		if(PaiCode.same(pcArr[0],pcArr[1]))
		  		{
                    px.Add("pair");
                    px.Add(pcArr[0].ToString());
		  		
		  			return px;	
		  		}
		  		
		  		//
                px.Add("miss");
		  		
		  		return px;		  			  		
		  }


        /// <summary>
		/// 4���ƵĵĿ�����
		/// ��֤�ƵĺϷ��ԣ�ͬ����ȡԪ����
		/// ��4�ſ�ʼ�𣬿����ԾͶ������ˣ��ر���ż�����������
        /// �ϲ㺯���������� PaiCode.sort(pcArr);//sort�Ӵ�С
		/// </summary>
        private static List<string> parse_px_4(List<int> pcArr)
		{
            List<string> px = new List<string>();		  	
           
			 //ը��
			if(PaiCode.same(pcArr[0],pcArr[1]) &&
			   PaiCode.same(pcArr[1],pcArr[2]) &&
			   PaiCode.same(pcArr[2],pcArr[3]))
			{
                px.Add("bomb");//PaiRule.BOMB);
                px.Add(pcArr[0].ToString());//meta data
			  	return px;		  		  
			}
		  		
		  	//����һ		  		
		  	//3332
		  	if(PaiCode.same(pcArr[0],pcArr[1]) &&
			   PaiCode.same(pcArr[1],pcArr[2]) )
			{
                px.Add("sanzhang_single");
                px.Add(pcArr[0].ToString());//meta data 		  
			  	return px;
			}
		  		
		  	//2333 
		  	if(PaiCode.same(pcArr[1],pcArr[2]) &&
			   PaiCode.same(pcArr[2],pcArr[3]) )
		    {
                px.Add("sanzhang_single");
                px.Add(pcArr[1].ToString());//meta data
			  	return px;
			}
		  		
		  	//mis rule
            px.Add("miss");
		  	return px;	 	
		}	
    }
}
