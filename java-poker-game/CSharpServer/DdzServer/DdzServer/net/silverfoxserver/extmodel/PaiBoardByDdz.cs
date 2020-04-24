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
using net.silverfoxserver.core.util;
using DdzServer.net.silverfoxserver.extlogic;

namespace DdzServer.net.silverfoxserver.extmodel
{
    public class PaiBoardByDdz
    {
        /// <summary>
        /// ö�����е��������ƣ��ַ�����
        /// </summary>
        private PaiName PAI_NAME = new PaiName();

        /// <summary>
        /// ����
        /// </summary>
        public volatile string[,] grid;

        /// <summary>
        /// ����
        /// </summary>
        public volatile string[] grid2;



        public PaiBoardByDdz()
        {
            //
            reset();
        }

         /// <summary>
        /// ��������
        /// </summary>
        private void reset()
        {
            grid = new string[,]{         
                                //20    
                              {"","","","","","","","","","","","","","","","","","","",""},
                              {"","","","","","","","","","","","","","","","","","","",""},
                              {"","","","","","","","","","","","","","","","","","","",""},                
             
                    };


            grid2 = new string[] { "", "", "" };

        }

        /// <summary>
        /// ϴ��ǰ������reset
        /// </summary>
        public void xipai()
        {
            //
            reset();

            //
            int i = 0;
            int len = 0;
            int n = 0;
                      
            //clone pai name
            List<string> p = PAI_NAME.GetList();

            //��һ�η�17����
            len = 17;

            //�����������ظ����ʵ��������ɷ���: 

            //Millisecond ȡֵ��Χ�� 0 - 999
            //DateTime.Now.Ticks��ָ��1970��1��1�գ������������˹���������1970����ʼ��Ŀǰ�������ĺ����������̶�����

            //54���Ƶ������ 54!
            //��һ���ǳ������,�����: 2.3e + 71
            //������ǵ�seed��ȡֵ��ΧҲӦ�÷ǳ���,Ҳ����0������Ľ��,
            //MillisecondС�ˣ�����ֻ�����999���Ƶ����
            //guid��������ȡ,ÿ�ض���һ����

            //ֱ����Random��Ϊ�������������Ϊʱ�Ӿ������⣬
            //��һ��С��ʱ����ڻ�õ�ͬ����α��������У�
            //��shuffle���õ�ͬһ�������
            //.net�ṩ��RNGCryptoServiceProvider���Ա����������

            //GetRandSeed���ȡֵ��Χ�� 0 - int32.MaxValue����Ȼ�����Զ������999Ҫ�úܶ�
            Random r = new Random(RandomUtil.GetRandSeed());

            
            for (i = 0; i < len; i++)
            {
                n = r.Next(p.Count);

                grid[0, i] = p[n];

                p.RemoveAt(n);
            }
            

            //test
            /*
            grid[0, 0] = PokerName.X_J; p.Remove(PokerName.X_J);

            grid[0, 1] = PokerName.F_A; p.Remove(PokerName.F_A);
            grid[0, 2] = PokerName.X_A; p.Remove(PokerName.X_A);
            grid[0, 3] = PokerName.T_A; p.Remove(PokerName.T_A);
            grid[0, 4] = PokerName.T_K; p.Remove(PokerName.T_K);

            grid[0, 5] = PokerName.F_K; p.Remove(PokerName.F_K);
            grid[0, 6] = PokerName.M_K; p.Remove(PokerName.M_K);
            grid[0, 7] = PokerName.T_8; p.Remove(PokerName.T_8);
            grid[0, 8] = PokerName.X_8; p.Remove(PokerName.X_8);

            grid[0, 9] = PokerName.X_3; p.Remove(PokerName.X_3);
            grid[0, 10] = PokerName.T_3; p.Remove(PokerName.T_3);
            grid[0, 11] = PokerName.X_2; p.Remove(PokerName.X_2);
            grid[0, 12] = PokerName.X_4; p.Remove(PokerName.X_4);

            grid[0, 13] = PokerName.X_5; p.Remove(PokerName.X_5);
            grid[0, 14] = PokerName.X_6; p.Remove(PokerName.X_6);
            grid[0, 15] = PokerName.X_10; p.Remove(PokerName.X_10);
            grid[0, 16] = PokerName.T_10; p.Remove(PokerName.T_10);
            */
            

            
            for (i = 0; i < len; i++)
            {
                n = r.Next(p.Count);

                grid[1, i] = p[n];

                p.RemoveAt(n);
            }
            

            //test
            /*
            grid[1, 0] = PokerName.M_J; p.Remove(PokerName.M_J);

            grid[1, 1] = PokerName.F_4; p.Remove(PokerName.F_4);
            grid[1, 2] = PokerName.X_4; p.Remove(PokerName.X_4);
            grid[1, 3] = PokerName.T_4; p.Remove(PokerName.T_4);
            grid[1, 4] = PokerName.T_5; p.Remove(PokerName.T_5);

            grid[1, 5] = PokerName.F_5; p.Remove(PokerName.F_5);
            grid[1, 6] = PokerName.M_5; p.Remove(PokerName.M_5);
            grid[1, 7] = PokerName.T_Q; p.Remove(PokerName.T_Q);
            grid[1, 8] = PokerName.X_Q; p.Remove(PokerName.X_Q);

            grid[1, 9] = PokerName.X_K; p.Remove(PokerName.X_K);
            grid[1, 10] = PokerName.M_K; p.Remove(PokerName.M_K);
            grid[1, 11] = PokerName.M_2; p.Remove(PokerName.M_2);
            grid[1, 12] = PokerName.M_4; p.Remove(PokerName.M_4);

            grid[1, 13] = PokerName.X_5; p.Remove(PokerName.X_5);
            grid[1, 14] = PokerName.X_6; p.Remove(PokerName.X_6);
            grid[1, 15] = PokerName.X_J; p.Remove(PokerName.X_J);
            grid[1, 16] = PokerName.T_10; p.Remove(PokerName.T_10);
            */
            

            for (i = 0; i < len; i++)
            {
                n = r.Next(p.Count);

                grid[2, i] = p[n];

                p.RemoveAt(n);
            }//end for


            //����
            grid2[0] = p[0];
            grid2[1] = p[1];
            grid2[2] = p[2];

            //distory
            p.Clear();
        
        }

        public int getBombCountByGrid(int h)
        {
            int count = 0;

            if (0 != h &&
                1 != h &&
                2 != h)
            {
                throw new ArgumentOutOfRangeException("h out grid index");
            }


            List<int> pcArr = new List<int>();

            for (int i = 0; i < 3; i++)//3��
            {
                if (i == h)
                {
                    for (int j = 0; j < 20; j++)//20��
                    {
                        if ("" != grid[i, j])
                        {
                           
                            pcArr.Add(PaiCode.convertToCode(grid[i, j]));
                           
                        }
                    }
                }//end if
            }

            //
            PaiCode.sort(pcArr);//sort�Ӵ�С

            List<PaiUnit> pickArr = PaiRuleTip.pick(pcArr);

            for (int j = 0; j < pickArr.Count; j++)
            {
                if("bomb" == pickArr[j].Rule())
                {
                    count++;
                }

                if("huojian" == pickArr[j].Rule())
                {
                    count++;
                }
            
            }

            return count;  


        }

        public List<string> getPaiByGrid(int h)
        {
            if (0 != h &&
                1 != h &&
                2 != h)
            {
                throw new ArgumentOutOfRangeException("h out grid index");
            }

            //
            List<string> paiList = new List<string>();

            //
            for (int i = 0; i < 3; i++)//3��
            {
                if (i == h)
                {
                    for (int j = 0; j < 20; j++)//20��
                    {
                        if ("" != grid[i, j])
                        {
                            //count++;
                            paiList.Add(grid[i, j]);
                        }
                    }
                }//end if
            }

            return paiList;
        }

        /// <summary>
        /// ��ȡgrid ��ĳ�е�������
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public int getPaiCountByGrid(int h)
        {
            int count = 0;

            if (0 != h && 
                1 != h && 
                2 != h)
            {
                throw new ArgumentOutOfRangeException("h out grid index");
            }

            for (int i = 0; i < 3; i++)//3��
            {
                if (i == h)
                {
                    for (int j = 0; j < 20; j++)//20��
                    {
                        if ("" != grid[i, j])
                        {
                            count++;
                        }
                    }
                }//end if
            }

            return count;        
        
        }

        /// <summary>
        /// ��grid2�ĵ������ӵ�grid
        /// </summary>
        /// <param name="h"></param>
        public void addDiPaiToGrid(uint h)
        {
            grid[h, 17] = grid2[0];
            grid[h, 18] = grid2[1];
            grid[h, 19] = grid2[2];
        }
        
        /// <summary>
        /// ���ڲ����ƶ���update��ʵ��ɾ����
        /// ���汳���ǿͻ���������
        /// �ϲ�Room���xml����һ�¾���
        /// </summary>
        /// <param name="itemName"></param>
        public void update(string itemName,string action)
        {
            if ("del" == action)
            {
                for (int i = 0; i < 3; i++)//3��
                {
                    for (int j = 0; j < 20; j++)//20��
                    {
                        if (itemName == grid[i, j])
                        {
                            grid[i, j] = "";
                            return;
                        }
                    }
                }

                throw new ArgumentOutOfRangeException("del pai can not find:" + itemName);

            }
            else
            {

                throw new ArgumentOutOfRangeException("action can not find:" + action);
            }

            
        }

        public string toXMLString()
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            int j = 0;

            //chessboard�����item�ڵ�
            for (i = 0; i < 3; i++)//3��
            {
                for (j = 0; j < 20; j++)//20��
                {
                    if ("" != grid[i, j])
                    {
                        //qizi�����item
                        sb.Append("<item n='");

                        sb.Append(grid[i, j]);

                        sb.Append("' h='");

                        sb.Append(i.ToString());

                        sb.Append("' v='");

                        sb.Append(j.ToString());

                        sb.Append("'/>");

                    }

                }

            }//end for

            //����
            //ע�⣬grid2�Ǹ�һά����
            for (j = 0; j < 3; j++)
            {
                if ("" != grid2[j])
                {
                   //qizi�����item
                   sb.Append("<item n='");

                   sb.Append(grid2[j]);

                   sb.Append("' h='");

                   sb.Append("3' v='");//ǰ��h�ù�012������Ϊ3

                   sb.Append(j.ToString());

                   sb.Append("'/>");

                } 
            }

            return sb.ToString();
        
        }



    }
}
