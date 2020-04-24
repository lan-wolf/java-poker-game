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
using System.Xml;
using System.Collections;
using System.Runtime.CompilerServices;
//
using net.silverfoxserver.core.model;
using net.silverfoxserver.core.util;
using DdzServer.net.silverfoxserver.extlogic;
using DdzServer.net.silverfoxserver.extmodel;
using DdzServer.net.silverfoxserver.extfactory;
using net.silverfoxserver.core.log;


namespace DdzServer.net.silverfoxserver.extmodel
{
    /// <summary>
    /// 
    /// </summary>
    public class RoomModelByDdz : IRoomModel
    {
        /// <summary>
        /// ����id
        /// ����䣬����Ҫvolatile 
        /// </summary>
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public int getId()
        {
                return this._id;
        }

        /// <summary>
        /// �������࣬����
        /// ��Ӧ�ͻ��˵�tab navigate ���
        /// </summary>
        private int _tab;

        public int Tab
        {
            get
            {
                return this._tab;
            }
        }

        public int getTab()
        {
            return this._tab;
        }
                

        /// <summary>
        /// �������Զ�ƥ�䷿��ģʽ
        /// </summary>
        private int _tabAutoMatchMode;

        /// <summary>
        /// ���ٳ�
        /// </summary>
        private int _tabQuickRoomMode;

        /// <summary>
        /// �׷�
        /// ����䣬����Ҫvolatile 
        /// </summary>
        private int _diG;

        /// <summary>
        /// ����Я��
        /// ����䣬����Ҫvolatile 
        /// </summary>
        private int _carryG;

        /// <summary>
        /// ÿ�ֻ��ѣ��ٷֱ�
        /// ����䣬����Ҫvolatile 
        /// </summary>
        private float _costG;

        /// <summary>
        /// ÿ�ֻ��ѵĴ����ʺ�
        /// </summary>
        private string _costU;
        private string _costUid;
                
        /// <summary>
        /// ��������
        /// </summary>
        private string _name;

        public string Name
        {

            get
            {
                return this._name;
            }

        }

        public void setName(string value)
        {
            _name = value;
        }

        /** 
         ��������
        */
        private String _pwd;

        
        public String getPwd()
        {
            return this._pwd;
        }

        
        public void setPwd(String value)
        {
             _pwd = value;
        }

        /**
         * ֻ����VIP����
         * 
         */
        private int _vip;
    
   
        public int getVip() {
       
            return _vip;
        }


        public void setVip(int value) {
        
            _vip = value;
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        private volatile string _roomStatus;

        public string Status
        {
            get
            {
                return this._roomStatus;
            }
        }

        /// <summary>
        /// �����������ʱ��
        /// </summary>
        private int _reconnectionTime;

        public void setReconnectionTime(int value)
        {
            _reconnectionTime = value;
        }

        /// <summary>
        /// ����������������ͣ
        /// </summary>
        private volatile bool _isWaitReconnection;
        public int MaxWaitReconnectionTime
        {
            get {

                return this._reconnectionTime * 1000;
            }
        
        }
        private volatile int _curWaitReconnectionTime;

        private volatile IUserModel _waitReconnectionUser;

        public bool isWaitReconnection
        {
            get
            {
                return this._isWaitReconnection;
            }
        }

        public int CurWaitReconnectionTime
        {
            get 
            {
                return this._curWaitReconnectionTime;
            }

            set 
            { 
                this._curWaitReconnectionTime = value; 
            }
        }

        public IUserModel WaitReconnectionUser
        {

            get 
            {
                return this._waitReconnectionUser; 
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        private int _everyDayLogin;

        public void setEveryDayLogin(int value)
        {
            _everyDayLogin = value;
        }

        public int getEveryDayLogin()
        {
            return _everyDayLogin;

        }

        /// <summary>
        /// �������
        /// </summary>
        private volatile string _matchResult;

        /// <summary>
        /// // The .NET Framework 2.0 way to create a list
        ///List<int> list1 = new List<int>();
        ///
        /// // No boxing, no casting:
        /// //list1.Add(3);
        ///
        /// // Compile-time error:
        /// // list1.Add("It is raining in Redmond.");
        ///
        /// ���Ñ��˳�ʽ�a���f�����^� ArrayList��List<T> Ψһ���ӵ��Z����������͈��Ђ��w���е��̈́e�������mȻ��ʽ�a׫��������΢�}�s����������������β����� ArrayList ��ȫ��ͬ�rҲ�����S�࣬�؄e������Ŀ�錍ֵ�̈́e�r��
        ///
        /// </summary>
        private List<IChairModel> _chair;

        //private List<IChairModel> _lookChair;

        /// <summary>
        /// ������Ϣ
        /// </summary>
        private PaiBoardByDdz _board;

        /// <summary>
        /// �׷֣��зֺ�ų��ֵ���
        /// </summary>
        private volatile string difen;

        /// <summary>
        /// �ܹ���ը���Ĵ���
        /// </summary>
        private volatile int bomb;

        private volatile int leaveBomb;

        private volatile string leaveUserId;

        /// <summary>
        /// ������userId
        /// 
        /// �൱��red
        /// </summary>
        private string _dizhu;

        public string dizhu
        {
            get
            {

                return _dizhu;

            }

            set
            {

                _dizhu = value;
            }
        }

        /// <summary>
        /// ũ���userId
        /// ��,�Ÿ���
        /// �൱��black
        /// </summary>
        private volatile string nongming;

        /// <summary>
        /// ��û�о���������ũ��ʱ����һ�����Ƶ�����Ȩ�Ƚе���
        /// �������ƣ���ϵͳ���ѡ��һ��
        /// 
        /// ����ָ���ǵ�һ�����Ƶ���
        /// </summary>
        private volatile string mingpai;

        /// <summary>
        /// 
        /// </summary>
        private string _turn;
        public string turn 
        {
            get {

                return _turn;

            }

            set {

                _turn = value;
            }
        }

        /// <summary>
        /// 3��ÿ������һ��
        /// 
        /// click������Ϣ��δ��һ�غ��е�һ�����ɸ��ฺ��
        /// �з���Ϣδ��һ�غ��е�һ�����ɸ��ฺ��
        /// </summary>
        private RoundModelByDdz _record;     

        /// <summary>
        /// �غ���Ϣ
        /// </summary>
        private List<RoundModelByDdz> _round;

        /// <summary>
        /// ������ö�����еĻغ�����
        /// </summary>
        public RoundTypeByDdz ROUND_TYPE = new RoundTypeByDdz();

        /// <summary>
        /// ������ö�����е�״̬
        /// </summary>

        /// <summary>
        /// ������ö�����е���Ϸ���
        /// </summary>
        public MatchResultByDdz MATCH_RESULT = new MatchResultByDdz();

        /// <summary>
        /// ������ö�����е�����
        /// </summary>
        public PaiName PAI_NAME = new PaiName();

        public PaiRule PAI_RULE = new PaiRule();

        /// <summary>
        /// �Ƿ�������
        /// ���Ŀǰ�����,����Ҫvolatile 
        /// </summary>
        private bool _allowPlayerGlessThanZeroOnGameOver;

        public void setAllowPlayerGlessThanZeroOnGameOver(bool value)
        {
            _allowPlayerGlessThanZeroOnGameOver = value;
        }

        /// <summary>
        /// ���ܿ۷ֱ���
        /// </summary>
        private int _runAwayMultiG;

        public void setRunAwayMultiG(int value)
        {
            _runAwayMultiG = value;
        }

        

        /// <summary>
        /// 
        /// </summary>
        private int _clock;

        public void setClockPlusPlus()
        {
            _clock++;
        }

        public int Clock
        {
            get
            {

                return _clock;
            }

        }

        public RoomModelByDdz(int id, IRuleModel rule, int tab, string gridXml)
        {
            
            this._id = id;

            this._tab = tab;

            if ("" == gridXml)
            {
                this._name = string.Empty;
            }
            else
            {
                XmlDocument gridDoc = new XmlDocument();
                gridDoc.LoadXml(gridXml);

                this._name = gridDoc.DocumentElement.Attributes["name"].Value;

            }

            this.setStatus(RoomStatusByDdz.GAME_WAIT_START);

            this._matchResult = MATCH_RESULT.EMPTY;

            this._chair = new List<IChairModel>();

            for (int i = 1; i <= rule.getChairCount(); i++)
            {
                this._chair.Add(ChairModelFactory.Create(i, rule));

            }//end for

            //red = "";
            //black = "";

            this.difen = "";
            this.bomb = 0; this.leaveBomb = 0; this.leaveUserId = "";
            this.dizhu = "";
            this.nongming = "";
            this.mingpai = "";
            this.turn = "";

            this._board = new PaiBoardByDdz();
            this._record = new RoundModelByDdz(ROUND_TYPE.JIAO_FEN);
            this._round = new List<RoundModelByDdz>();

            _runAwayMultiG = 1;

            _isWaitReconnection = false;
            _curWaitReconnectionTime = 0;

            _waitReconnectionUser = null;

        }

        
        
        

        public int getDig()
        {
            return this._diG;
        }

        /// <summary>
        /// ��ʼ��������ɺ��ڼ��뷿���б�ǰ���ô�ֵ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void setDig(int value)
        {
            this._diG = value;
        }

        public int getCarryg()
        {
            return this._carryG;
        }

        public void setCarryg(int value)
        {
            this._carryG = value;
        }
        
        public float getCostg()
        {
            return this._costG;
        }

        public string getCostU()
        {
            return this._costU;
        }

        public string getCostUid()
        {
            return this._costUid;
        }

        public void setCostg(float value,string value2,string value3)
        {
            this._costG = value;
            this._costU = value2;
            this._costUid = value3;
        }

        public bool isTabAutoMatchMode()
        {
            if (0 == this._tabAutoMatchMode)
            {
                return false;
            }

            return true;
        
        }

        public int getTabAutoMatchMode()
        {
            return this._tabAutoMatchMode;

        }


        public void setTabAutoMatchMode(int value)
        {
            this._tabAutoMatchMode = value;
        
        }

        public void setTabQuickRoomMode(int value)
        {
            this._tabQuickRoomMode = value;
        
        }
        

        /// <summary>
        /// value һ��Ϊfalse
        /// </summary>
        /// <param name="value"></param>
        
        public void setReadyForAllChair(bool value)
        {
            int len = this._chair.Count;

            //������Ҳ������Ŷ
            //���ֻ��ԭready
            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                chair.setReady(value);

            }
        }

        
        public void setReadyAddForAllChair(string value)
        {
            int len = this._chair.Count;

            //������Ҳ������Ŷ
            //���ֻ��ԭready
            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                chair.setReadyAdd(value);
            }        
        }


       



        public void reset()
        {
            this.setStatus(RoomStatusByDdz.GAME_WAIT_START);

            this._matchResult = MATCH_RESULT.EMPTY;

            //������Ҳ������Ŷ
            //���ֻ��ԭready
            setReadyForAllChair(false);

            setReadyAddForAllChair("");         

            //�췽�ͺڷ��������δ�뿪�����ø�

            this.difen = "";
            this.bomb = 0; this.leaveBomb = 0; this.leaveUserId = "";
            this.dizhu = "";
            this.nongming = "";
            this.mingpai = "";
            this.turn = "";

            //���� reset
            this._board = new PaiBoardByDdz();

            //�����ƶ� reset
            this._record = new RoundModelByDdz(ROUND_TYPE.JIAO_FEN);

            //�غ���Ϣ reset
            this._round = new List<RoundModelByDdz>();

            _isWaitReconnection = false;
            _curWaitReconnectionTime = 0;

            this.setWaitReconnection(null);
            //_waitReconnectionUser = null;
        }

        /// <summary>
        /// IChairModel���� User,���ṩ������Ϣ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<IChairModel> findUser(IUserModel value)
        {
            List<IChairModel> users = new List<IChairModel>();

            //loop use
            int i = 0;
            int len = this._chair.Count;

            //check
            for (i = 0; i < len; i++)
            {
                if ((this._chair[i] as IChairModel).getUser().Id == value.Id)
                {
                    break;
                }

                //�����ﻹû����ѭ����˵��û�ҵ�
                if (i == (len - 1))
                {
                    throw new ArgumentException("can not found user id:" + value.Id);
                }
            }

            //add
            for (i = 0; i < len; i++)
            {
                if ((this._chair[i] as IChairModel).getUser().Id != value.Id)
                {
                    users.Add((this._chair[i] as IChairModel));
                }

            }

            return users;
                
        
        }

        /// <summary>
        /// ������ userId
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<IChairModel> findUser(string value)
        {
            List<IChairModel> users = new List<IChairModel>();

            //loop use
            int i = 0;
            int len = this._chair.Count;

            //check
            for (i = 0; i < len; i++)
            {
                if ((this._chair[i] as IChairModel).getUser().Id == value)
                {
                    break;
                }

                //�����ﻹû����ѭ����˵��û�ҵ�
                if (i == (len - 1))
                {
                    throw new ArgumentException("can not found user id:" + value);
                }
            }

            //add
            for (i = 0; i < len; i++)
            {
                if ((this._chair[i] as IChairModel).getUser().Id != value)
                {
                    users.Add((this._chair[i] as IChairModel));
                }

            }

            return users;
        
        }

        /// <summary>
        /// string dizhu,string nongming
        /// �������ݣ�������ũ��1,ũ��2
        /// </summary>
        /// <returns></returns>
        public List<IChairModel> findUser()
        {
            List<IChairModel> users = new List<IChairModel>();

            //loop use
            int i = 0;
            int len = this._chair.Count;

            //add
            for (i = 0; i < len; i++)
            {
                if ((this._chair[i] as IChairModel).getUser().Id == this.dizhu)
                {
                    users.Add((this._chair[i] as IChairModel));
                }

            }

            //add
            for (i = 0; i < len; i++)
            {
                if ((this._chair[i] as IChairModel).getUser().Id != this.dizhu)
                {
                    users.Add((this._chair[i] as IChairModel));
                }

            }

            return users;

        }


        /// <summary>
        /// ���ñ�����ǰ,�ȵ���findUser�������ҵ�ũ���û��б�
        /// </summary>
        /// <param name="users"></param>
        public void setNongMing(List<IChairModel> users)
        {
            int len = users.Count;
            
            for (int i = 0; i < len; i++)
            {
                this.nongming += users[i].getUser().Id;
                this.nongming += ",";
            }

            if (this.nongming.EndsWith(","))
            {
                this.nongming.Remove(this.nongming.Length - 1, 1);
            }
        }


        /// <summary>
        /// �������ƣ������""���ͻ����÷���+id���
        /// ��ҪΪ�����������������Ż�
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return this._name;
        }

        public int getChairCount()
        {
            return this._chair.Count;
        }

        public int getLookChairCount()
        {
            return -1;
            //return this._lookChair.Count;
        }

        public List<IUserModel> getAllPeople()
        {

            List<IUserModel> peopleList = new List<IUserModel>();
            int jLen = this._chair.Count;

            for (int j = 0; j < jLen; j++)
            {
                IChairModel c = this._chair[j];

                if ("" != c.User.Id)
                {
                    peopleList.Add(c.User);
                }

            }

            return peopleList;
        
        }

        /// <summary>
        /// ���˵���λ����
        /// </summary>
        /// <returns></returns>
        public int getSomeBodyChairCount()
        {
            //loop use
            int len = this._chair.Count;

            int count = 0;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if ("" != chair.getUser().Id)
                {
                    count++;
                }

            }

            return count;
        }

        public int getSomeBodyLookChairCount()
        {
            return -1;

            //loop use
            /*
            int len = this._lookChair.Count;

            int count = 0;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._lookChair[i];

                if ("" != chair.getUser().Id)
                {
                    count++;
                }

            }

            return count;
             * */
        }

        /// <summary>
        /// �������Ƿ��������
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool hasPeople(IUserModel user)
        {
            for (int i = 0; i < this._chair.Count; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().Id == user.Id)
                {
                    return true;
                }

            }//end for        

            return false;

        }

        public bool hasSameIpPeople(IUserModel user, bool isOnChair)
        {
            //test
            //return false;


            if (isOnChair)
            {
                for (int i = 0; i < this._chair.Count; i++)
                {
                    IChairModel chair = this._chair[i];

                    if ("" != chair.getUser().Id)
                    {
                        string[] compare_1 = chair.getUser().getStrIpPort().Split(':');
                        string[] compare_2 = user.getStrIpPort().Split(':');

                        if (compare_1[0] == compare_2[0])
                        {
                            return true;

                        }
                    }

                }//end for
            }

            return false;

        }

        /// <summary>
        /// ʹ�ø÷�����ʹ��  hasPeople
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IChairModel getChair(IUserModel user)
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().Id == user.Id)
                {
                    return chair;
                }

            }//end for   
                        
            //throw new ArgumentException("can not find user " + user.Id + " func:getChair");
            return null;
        }

        public IChairModel getChair(string userId)
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel c = this._chair[i];

                if (c.User.Id == userId)
                {
                    return c;
                }

            }//end for   

            //throw new ArgumentException("can not find user " + user + " func:getChair");
            return null;
        }

        public List<IChairModel> getOtherChair(string user)
        {
            //loop use
            int len = this._chair.Count;
            List<IChairModel> list = new List<IChairModel>();

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().Id != user)
                {
                    list.Add(chair);
                }

            }//end for   

            return list;
        }

        public IChairModel getChair(int id)
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.Id == id)
                {
                    return chair;
                }

            }//end for   

            //throw new ArgumentException("can not find chair " + id.ToString() + " func:getChair");
            return null;
        }

        public ILookChairModel getLookChair(IUserModel value)
        {
            return null;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        public bool setSitDown(IUserModel user)
        {
            //loop use
            int len = this._chair.Count;
            int i = 0;

            IChairModel c = null;

            //
            for (i = 0; i < len; i++) 
            {
                c = this._chair[i];

               if (user.Id == c.getUser().Id)
               {
                   //�Ѿ����ڱ��������һ����λ��
                   return true;
               }
            }

            //
            for (i = 0; i < len; i++)
            {
                c = this._chair[i];

                if ("" != c.getUser().Id)
                {
                    //���ˣ�������
                }
                else
                {
                    c.setUser(user);

                    //�������,����˭����
                    //�趨˭�Ƚе��������ﲻ��˭�����¾�����������ready���������

                    return true;
                }//end if

            }//end for        

            return false;
        }

        
        public void setReadyAdd(string userId,string info)
        {
            //loop use
            int len = this._chair.Count;

            //�ж��ǲ��ǵ�һ�����Ƶ���
            if ("" == this.mingpai)
            {
                this.mingpai = userId;            
            }

            //
            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().Id == userId)
                {
                    chair.setReadyAdd(info);
                    break;

                }//end if

            }//end for 
        
        }

        /// <summary>
        /// ׼��
        /// </summary>
        /// <param name="user"></param>
        
        public void setReady(string userId)
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel c = this._chair[i];

                if (c.User.Id == userId)
                {
                    if (!c.isReady)
                    {
                        c.setReady(true);

                        //ȫ��׼��ok�����ķ���״̬
                        //Ҫ��ʼ��Ϸֻ�ü�ⷿ��״̬�Ϳ�����
                        if (hasAllReady())
                        {
                            this.setStatus(RoomStatusByDdz.GAME_ALL_READY_WAIT_START);

                            //���е����ӵ�ready���Ա�����
                            setReadyForAllChair(false);
                        }

                        break;

                    }
                }

            }//end for 
        }

        /// <summary>
        /// round
        /// board
        /// </summary>
        /// <param name="value"></param>        
        public void setChuPai(string value)
        {
            //loop use
            int i = 0;

            string[] sp = value.Split(',');

            string userId = sp[0];

            //�����ը�����¼
            int spLen = sp.Length;

            if (5 == spLen || 
                3 == spLen)
            {
                //List<int> pcArr = new List<int>();
                List<int> pcArr = new List<int>(spLen-1);

                for (i = 1; i < spLen; i++)
                { 
                    pcArr.Add(PaiCode.convertToCode(sp[i]));
                }

                //��ը��������û�Ҫ��Ҳ��ը��
                if (PaiRuleCompare.validate_bomb(pcArr) ||
                    PaiRuleCompare.validate_huojian(pcArr))
                {
                    this.bomb++;
                }
            }

            //
            //�ж�һȦ����,save and new
            if (this._record.isFull())
            {
                this._round.Add(this._record);
                this._record = new RoundModelByDdz(ROUND_TYPE.CHU_PAI);
            }

            string pai = string.Empty;

            //
            spLen = sp.Length;

            for (i = 1; i < spLen; i++)
            {
                pai += sp[i];
                pai += ",";

            }

            this._record.setPai(pai, userId); // set player

           //board
            spLen = sp.Length;

            for (i = 1; i < spLen; i++)
            {
                this._board.update(sp[i],"del");
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        
        public void setJiaoFen(string value)
        {
            //
            string[] sp = value.Split(',');

            string userId = sp[0];
            int fen = Convert.ToInt32(sp[1]);

            //�׷����Ϊ3��
            if (fen > PAI_RULE.JF_MAXVALUE)
            {
                fen = PAI_RULE.JF_MAXVALUE;
            }

            //loop use
            int i = 0;
            int len = this._chair.Count;

            //save
            for (i = 0; i < len; i++)
            {
                if (this._chair[i].getUser().Id == userId)
                {
                    //�ж�һȦ����,save and new
                    if (this._record.isFull())
                    {
                        this._round.Add(this._record);
                        this._record = new RoundModelByDdz(ROUND_TYPE.JIAO_FEN);
                    }

                    this._record.setFen(fen, userId); // set player

                    //record�ں����ʹ��ʱע��Ҫ�ж�empty
                    //����ʱע��Ҫ���߼��ж�����ٱ���

                    //-------------------------------------------------------------------

                    if (RoomStatusByDdz.GAME_START == this.getStatus())
                    {
                        //3Ȧȫ������
                        if (2 == this._round.Count &&
                            false == this._record.isEmpty() &&
                            "" != this._record.clock_three)
                        {
                            //check
                            if (PAI_RULE.JF_MINVALUE == (this._round[0] as RoundModelByDdz).clock_one_jiaofen &&
                                PAI_RULE.JF_MINVALUE == (this._round[0] as RoundModelByDdz).clock_two_jiaofen &&
                                PAI_RULE.JF_MINVALUE == (this._round[0] as RoundModelByDdz).clock_three_jiaofen &&

                                PAI_RULE.JF_MINVALUE == (this._round[1] as RoundModelByDdz).clock_one_jiaofen &&
                                PAI_RULE.JF_MINVALUE == (this._round[1] as RoundModelByDdz).clock_two_jiaofen &&
                                PAI_RULE.JF_MINVALUE == (this._round[1] as RoundModelByDdz).clock_three_jiaofen &&

                                PAI_RULE.JF_MINVALUE == this._record.clock_one_jiaofen &&
                                PAI_RULE.JF_MINVALUE == this._record.clock_two_jiaofen &&
                                PAI_RULE.JF_MINVALUE == this._record.clock_three_jiaofen)
                            {
                                
                                this.setStatus( RoomStatusByDdz.GAMEOVER_ROOMCLEAR_WAIT_START);
                                this._round.Add(this._record);
                                //reset���new
                                return;
                            }
                        }//end if


                        //�ж�3��
                        //��3�ֵ�����������
                        if (PAI_RULE.JF_MAXVALUE == fen)
                        {
                            this.dizhu = userId;
                            this.difen = Convert.ToString(fen);

                            //nongming
                            List<IChairModel> users = this.findUser(this._chair[i].getUser());
                            
                            //
                            this.setNongMing(users);

                            //
                            this.setStatus(RoomStatusByDdz.GAME_START_CAN_GET_DIZHU);
                            this._round.Add(this._record);//������Ǹ��������ĵ�
                            this._record = new RoundModelByDdz(ROUND_TYPE.CHU_PAI);
                            
                            return;
                        }

                        if (PAI_RULE.JF_MAXVALUE > fen)//����3��
                        {
                            //����3��,�Ҳ������һ��������
                            if ("" == this._record.clock_three)
                            {
                                return;
                            }
                            else
                            {
                                //��Ȧ������
                                if (PAI_RULE.JF_MINVALUE == this._record.clock_one_jiaofen &&
                                   PAI_RULE.JF_MINVALUE == this._record.clock_two_jiaofen &&
                                   PAI_RULE.JF_MINVALUE == this._record.clock_three_jiaofen)
                                {
                                    return;

                                }
                                else
                                {
                                    //��Ȧ������һ���У����Ѿ���һȦ
                                    //��������                                   

                                    //һ����ϣ��нз֣��зֲ����ظ�
                                    int maxJf = MathUtil.selecMaxNumber(this._record.clock_one_jiaofen,
                                                         this._record.clock_two_jiaofen,
                                                         this._record.clock_three_jiaofen);

                                    if (maxJf == this._record.clock_one_jiaofen)
                                    {
                                        this.dizhu = this._record.clock_one;
                                        this.difen = Convert.ToString(maxJf);

                                        //nongming
                                        List<IChairModel> users = this.findUser(this._record.clock_one);
                                        this.setNongMing(users);

                                    }
                                    else if (maxJf == this._record.clock_two_jiaofen)
                                    {
                                        this.dizhu = this._record.clock_two;
                                        this.difen = Convert.ToString(maxJf);

                                        List<IChairModel> users = this.findUser(this._record.clock_two);
                                        this.setNongMing(users);
                                    }
                                    else if (maxJf == this._record.clock_three_jiaofen)
                                    {
                                        this.dizhu = this._record.clock_three;
                                        this.difen = Convert.ToString(maxJf);

                                        List<IChairModel> users = this.findUser(this._record.clock_three);
                                        this.setNongMing(users);
                                    }
                                    else
                                    {
                                        throw new ArgumentException("can not find max jiao fen");
                                    }

                                    //
                                    this.setStatus(RoomStatusByDdz.GAME_START_CAN_GET_DIZHU);
                                    //��������save����Ϊ�ϵ�
                                    this._round.Add(this._record);
                                    this._record = new RoundModelByDdz(ROUND_TYPE.CHU_PAI);
                                }

                            }
                        }


                    }//end if

                    break;

                }//end if

            }//end for 
        }

        /// <summary>
        /// �Ƿ�ȫ��׼����
        /// ����ʹ�ü�����ӵķ�������
        /// 
        /// �����ڲ����������ķ���״̬��,���е����ӵ�ready���Ա�����
        /// �ⲿ���ú��� hasAllReadyCanStart
        /// </summary>
        /// <returns></returns>
        private bool hasAllReady()
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel c = this._chair[i];

                if (c.isReady)
                {
                }
                else
                {
                    return false;//ֻҪ��һ��û׼���þ� return false
                }

            }//end for 

            return true;
        }

        public bool hasAllReadyCanStart()
        {
            if (RoomStatusByDdz.GAME_ALL_READY_WAIT_START == this.Status)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool chkVars(string n, string v, 
                            string userId, ref XmlNode nodeVars,int loop_i, 
                            out RvarsStatus sta)
        {
            int i = 0;
            int j = 0;
            int spLen = 0;
            sta = RvarsStatus.Success0;

            if ("chairReady" == n)
            {
                //׼��ֻ�����Ǳ������뱾�˵�
                if (v != userId)
                {
                    return false;
                }
            
            }else if ("tuoGuan" == n)
            {
                //�й�ֻ�����Ǳ������뱾�˵�
                if (v != userId)
                {
                    return false;
                }

            }
            else if ("jiaoFen" == n)
            {
                //�з�ֻ�����Ǳ������뱾�˵�
                if (!v.Contains(userId))
                {
                    return false;
                }

                //------------ ���޸İ��з� begin ------------
                string[] sp = v.Split(',');

                //string userId = sp[0];
                int fen = Convert.ToInt32(sp[1]);

                //�׷����Ϊ3��
                if (fen > PAI_RULE.JF_MAXVALUE)
                {
                    fen = PAI_RULE.JF_MAXVALUE;
                }

                nodeVars.ChildNodes[loop_i].InnerText = sp[0] + "," + fen.ToString();
                //------------ ���޸İ��з� end ------------

            
            }
            else if ("chuPai" == n)
            {
                //����ֻ�����Ǳ������뱾�˵�
                if (!v.Contains(userId))
                {
                    return false;
                }

                //���Ʊ���������ӵ�е���
                IChairModel c = this.getChair(userId);

                if (null == c)
                {
                    return false;
                }

                // int h0_pai = this._board.getPaiCountByGrid(0);
                List<string> h_paiList = this._board.getPaiByGrid(c.Id - 1);

                string[] sp = v.Split(',');

                spLen =  sp.Length;
                for (i = 1; i < spLen; i++)
                {
                    bool hasPai = false;

                    for (j = 0; j < h_paiList.Count; j++)
                    {
                        if (sp[i] == h_paiList[j])
                        {
                            hasPai = true;
                            break;
                        }
                    }

                    if (!hasPai)
                    {
                        return false;
                    }
                
                }

            }

            sta = RvarsStatus.Success0;
            return true;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="v"></param>      
        public void setVars(string n,string v)
        {
            
            if ("chairReady" == n)
            {
                 //userId
                 this.setReady(v);

            }
            else if ("chairMingReady" == n)
            {
                 this.setReady(v);
                 this.setReadyAdd(v, PAI_RULE.MING_PAI);
                
            }
            else if ("jiaoFen" == n && this.hasGamePlaying())
            {
                 this.setJiaoFen(v);// v.split(",");

                //
                 this.getTurn();
                    
            }
            else if ("chuPai" == n && this.hasGamePlaying(RoomStatusByDdz.GAME_START_CHUPAI))
            {

                 //selectPai��ʵ�ã���Ϊ�Ƕ����ƣ����ȥ��
                 this.setChuPai(v);
                 
                 //
                 setGameOver();

                 //
                 this.getTurn();

             }
             //else if ("renShu" == n)
             //{
             //    setGameOver(v, 0);

                 //
             //    this.getTurn();

             //}
       
        }        

        /// <summary>
        /// ��ʼ״̬����
        /// </summary>
        /// <param name="roomStatus"></param>        
        public void setGameStart(string value)
        {
            

            switch (value)
            {
                case "":
                case RoomStatusByDdz.GAME_START:

                     if (RoomStatusByDdz.GAME_ALL_READY_WAIT_START == this.Status)
                     {
                        this.setStatus(value);

                         //ϴ��
                        this._board.xipai();

                        //
                        this.getTurn();
                     }

                    break;

                case RoomStatusByDdz.GAME_START_CAN_GET_DIZHU:

                    if (RoomStatusByDdz.GAME_START_CAN_GET_DIZHU == this.Status)
                    {
                        //�����ŵ���
                        //-------------------------
                        //loop use
                       int len = this._chair.Count;

                       for (int i = 0; i < len; i++)
                       {
                            IChairModel chair = this._chair[i];

                             if (chair.getUser().Id == this.dizhu)
                             {
                                    //i����h
                                    this._board.addDiPaiToGrid(Convert.ToUInt32(i));

                                    break;
                              }//end if
                        }//end for
                    }

                    //
                    this.getTurn();

                    break;

                case RoomStatusByDdz.GAME_START_CHUPAI:

                    if (RoomStatusByDdz.GAME_START_CAN_GET_DIZHU == this.Status)
                    { 
                         //
                         this.setStatus(value);
                    }

                    break;
                
                default:

                    

                    break;
            }

            

           
            
            
        }


        /// <summary>
        /// �������ͷ�ʽ
        /// 0 - ����
        /// 1 - ���
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="category"></param>
        
        public void setGameOver(string userId, int category)
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().Id == userId)
                {
                    if (this.dizhu == userId)
                    {
                        this._matchResult = this.MATCH_RESULT.NONGMING_WIN;
                        this.setStatus(RoomStatusByDdz.GAMEOVER_WAIT_START);

                    }
                    else
                    {
                        this._matchResult = this.MATCH_RESULT.DIZHU_WIN;
                        this.setStatus(RoomStatusByDdz.GAMEOVER_WAIT_START);

                    }

                }//end if

            }//end for

        }

        /// <summary>
        /// setGameOver�������Ӻ���
        /// hΪ��grid��������Ϊ0���У�
        /// </summary>
        
        private void setWhoWin(int h)
        {
            IChairModel h_chair = this._chair[h];

            if (this.dizhu == h_chair.getUser().Id)
            {
                this._matchResult = MATCH_RESULT.DIZHU_WIN;
            }
            else if (this.nongming.Contains(h_chair.getUser().Id))
            {
                this._matchResult = MATCH_RESULT.NONGMING_WIN;
            }

            this.setStatus(RoomStatusByDdz.GAMEOVER_WAIT_START);
        
        }

        /// <summary>
        /// ͨ��˭��������Ϊ0�ж���Ӯ
        /// </summary>
        
        public void setGameOver()
        {
            int h0_pai = this._board.getPaiCountByGrid(0);
            int h1_pai = this._board.getPaiCountByGrid(1);
            int h2_pai = this._board.getPaiCountByGrid(2);

            if (0 == h0_pai)
            {
                setWhoWin(0);
            
            }else if (0 == h1_pai)
            {
                setWhoWin(1);

            }else if (0 == h2_pai)
            {
                setWhoWin(2);

            }
        }

        /// <summary>
        /// �˷�������
        /// </summary>
        /// <param name="viewName"></param>
        public void setGameOver(string viewName)
        {
            throw new ArgumentOutOfRangeException("�˷�������");
        }

        /// <summary>
        /// ͨ��ĳ�������ж���Ӯ
        /// �������ø���λ
        /// ǰ̨���÷� UserLeaveָ��
        /// 
        /// ע�������leaveUser�����Ի�Ҫ�������
        /// 
        /// ������Ϸ����ָ�����setLeaveUser
        /// </summary>
        /// <param name="leaveUser"></param>
        /// 
        public void setWaitReconnection(IUserModel waitUser)
        {
            if (null == waitUser)
            {
                this._isWaitReconnection = false;
            }
            else
            {
                this._isWaitReconnection = true;
            }

            this._waitReconnectionUser = waitUser;
        
        }
        
        public void setGameOver(IUserModel leaveUser)
        {

            //loop use            
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if ("" == chair.User.Id)
                {
                    chair.setUser(leaveUser);
                    break;
                }
            }

            //for (int i = 0; i < len; i++)
            //{
                //IChairModel chair = this._chair[i];

                //if (chair.User.Id == leaveUser.Id)
                //{
                    //�뿪�����ǵ���
                    //if (chair.User.Id == this.dizhu)
                    if (leaveUser.Id == this.dizhu)
                    {
                        //���ܳͷ�����������δ����ը��
                        this.leaveUserId = leaveUser.Id;//chair.getUser().Id;
                        this.leaveBomb = getAllHasBombCount();
                        this._matchResult = this.MATCH_RESULT.NONGMING_WIN;
                        this.setStatus(RoomStatusByDdz.GAMEOVER_WAIT_START);
                        //break;
                    }
                    //else if(this.nongming.IndexOf(chair.getUser().Id) >= 0)
                    else if (this.nongming.IndexOf(leaveUser.Id) >= 0)
                    {
                        //���ܳͷ�����������δ����ը��
                        this.leaveUserId = leaveUser.Id;
                        this.leaveBomb = getAllHasBombCount();
                        this._matchResult = this.MATCH_RESULT.DIZHU_WIN;
                        this.setStatus(RoomStatusByDdz.GAMEOVER_WAIT_START);
                       // break;
                    }
                    else
                    {
                        //δ�ֳ�������ũ���뿪����
                        //ǿ�������ũ��
                        this.dizhu = leaveUser.Id;//chair.getUser().Id;

                        List<IChairModel> list = this.getOtherChair(

                            leaveUser.Id
                            //chair.getUser().Id
                            
                            );

                        this.setNongMing(list);

                                               
                        //�ͷ��Կ۷�
                        //���߷���׷�
                        this._matchResult = this.MATCH_RESULT.NONGMING_WIN;
                        this.setStatus(RoomStatusByDdz.GAMEOVER_WAIT_START);
                        //break;
                    }


                //}

            //}//end for


            //leave �ϲ㺯������ָ�����ɺ��ٵ���
            //setLeaveUser(leaveUser);

        }

        /// <summary>
        /// ���Ŀǰӵ�е�ը���ܺ�
        /// </summary>
        public int getAllHasBombCount()
        {
            //�۷�̫�࣬��Ա���ܲ��ˣ��ĳ�1������
            //return 1;

            return _runAwayMultiG;

            /*
             * 
            int h0_bomb = 0;
            int h1_bomb = 0;
            int h2_bomb = 0;

            try
            {
                h0_bomb = this._board.getBombCountByGrid(0);
                h1_bomb = this._board.getBombCountByGrid(1);
                h2_bomb = this._board.getBombCountByGrid(2);

            }
            catch (Exception exd)
            {
                h0_bomb = 0;
                h1_bomb = 0;
                h2_bomb = 0;
            }

            return h0_bomb + h1_bomb + h2_bomb;
        
             */
        }
        
        public void setLeaveUser(IUserModel leaveUser)
        {
            //loop use
            int len = this._chair.Count;

            for (int i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().Id == leaveUser.Id)
                {

                    if (leaveUser.Id ==  this.dizhu)
                    {
                        //�������
                        if (!this.isWaitReconnection)
                        {
                            this.dizhu = "";
                        }

                    }else
                    {
                        //
                        if (!this.isWaitReconnection)
                        {
                            this.nongming = "";
                        }

                    }
                    //reset
                    chair.reset();

                }

            }//end for         
        }

        public string getStatus()
        {
            return this._roomStatus;
        }

        private void setStatus(string value)
        {
            
            this._roomStatus = value;

        }

        public bool hasGamePlaying()
        {
            if (RoomStatusByDdz.GAME_START               == this.Status ||
                RoomStatusByDdz.GAME_START_CAN_GET_DIZHU == this.Status ||
                RoomStatusByDdz.GAME_START_CHUPAI        == this.Status)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// ��Ϸ��ָ����һ��״̬
        /// </summary>
        /// <param name="roomStatus"></param>
        /// <returns></returns>
        public bool hasGamePlaying(string roomStatus)
        {
            if (hasGamePlaying())
            {
                if (this.getStatus() == roomStatus)
                {
                    return true;
                }
            }

            return false;
        }


        public bool hasGameOver_RoomClear()
        {
            if (RoomStatusByDdz.GAMEOVER_ROOMCLEAR_WAIT_START == this.getStatus())
            {
                return true;

            }

            return false;
        }

        public bool hasGameOver()
        {
            if (RoomStatusByDdz.GAMEOVER_WAIT_START == this.getStatus())
            {
                return true;

            }

            return false;
        }

        /// <summary>
        /// ���ؿ��ַ�������ʾ���䵱ǰ״̬��δ����
        /// Ӯ - �� or �� or ���� or ��δ����
        ///      red  black  he      ""
        /// </summary>
        /// <returns></returns>
        public string getWhoWin()
        {
            if (this._matchResult == this.MATCH_RESULT.DIZHU_WIN)
            {
                return "dizhu";
            }

            if (this._matchResult == this.MATCH_RESULT.NONGMING_WIN)
            {
                return "nongming";
            }

            if (this._matchResult == this.MATCH_RESULT.HE)
            {
                return "he";
            }

            if (this._matchResult == this.MATCH_RESULT.EMPTY)
            {
                return "";
            }

            throw new ArgumentOutOfRangeException("can not found " + this._matchResult + " in MATCH_RESULT");

        }

        /// <summary>
        /// ���������������˳ʱ��
        /// record��round����������һ����¼�������޷��ж���ʼ��
        /// </summary>
        /// <returns></returns>
        public IChairModel getClockNext()
        {
            IChairModel chair;

            if ("" != this._record.clock_three)
            {
                chair = this.getChair(this._record.clock_three);
            }
            else if ("" != this._record.clock_two)
            {
                chair = this.getChair(this._record.clock_two);
            }
            else if ("" != this._record.clock_one)
            {
                chair = this.getChair(this._record.clock_one);
            }
            else
            {
                chair = this.getChair(this._round[this._round.Count - 1].clock_three);
            }

            return getChairNext(chair);
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IChairModel getChairNext(IChairModel chair)
        {
            //loop use
            int i = 0;
            int len = this._chair.Count;

            for (i = 0; i < len; i++)
            {
                if (chair.Id == this._chair[i].Id)
                {
                    if (i == (len - 1))
                    {
                        return this._chair[0];
                    }
                    else
                    {
                        return this._chair[i + 1];
                    }
                }//end if

                //check
                if (i == (len - 1))
                {
                    throw new ArgumentException("can not find chair id:" + chair.Id + " func:getChairNext");
                }
            
            }//end for
            
            return this._chair[0];
        
        }


        

        /// <summary>
        /// trun���������е�һ�˵Ļ����������⣬��������˽е�����
        /// ֱ�����ѡһ��
        /// </summary>
        /// <returns></returns>
        public string getTurnByCheckTurnNoOK()
        {
            //���
            Random ran = new Random(DateTime.Now.Millisecond);

            int chairInd = ran.Next(this._chair.Count);

            turn = this._chair[chairInd].getUser().Id;

            return turn;
            
        }

        /// <summary>
        /// �ֵ�˭����
        /// </summary>
        /// <returns></returns>
        private string getTurn()
        {
            //��Ϸδ��ʼ
            
            if (RoomStatusByDdz.GAME_WAIT_START               == this.Status||
                RoomStatusByDdz.GAMEOVER_WAIT_START == this.Status ||
                RoomStatusByDdz.GAMEOVER_ROOMCLEAR_WAIT_START == this.Status)
            {
                turn = "";
                return turn;
            }
            

            //��Ϸ��ʼ
            //�зֽ׶�

            //0Ȧ,0ʱ��
            if (0 == this._round.Count && 
                "" == this._record.clock_one)
            {

                //�������ƣ�ϵͳ���ѡ һ���з�
                if ("" == this.mingpai)
                {
                    //���
                    Random ran = new Random(DateTime.Now.Millisecond);

                    int chairInd = ran.Next(this._chair.Count);

                    turn = this._chair[chairInd].User.Id;

                    return turn;

                 }
                 else {

                    turn = this.mingpai;

                    return turn; 
                
                
                }


            }
            else if (RoomStatusByDdz.GAME_START == this.Status)
            {
                turn = this.getClockNext().User.Id;
                return turn;

            }
            else if (RoomStatusByDdz.GAME_START_CAN_GET_DIZHU == this.Status)
            {
                turn = this.dizhu;
                return turn;

            }
            else if (RoomStatusByDdz.GAME_START_CHUPAI == this.Status)
            {
                turn = this.getClockNext().User.Id;
                return turn;
            }

            //return "";
            turn = this.getClockNext().User.Id;
            return turn;
        }


        /// <summary>
        /// �ⲿ���ã���toXMLStringһ�������ⲿǶ��room�ڵ�
        /// ��˲����ڲ�����,����ڵ���
        /// </summary>
        /// <returns></returns>
        /*
        public string getMatchXml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<room id='");

            sb.Append(this._id.ToString());

            sb.Append("' name='");

            sb.Append(this._name);

            sb.Append("'>");

            //
            sb.Append("<match dizhu='");

            sb.Append(this.dizhu);

            sb.Append("' nongming='");

            sb.Append(this.nongming);

            sb.Append("' round='");

            sb.Append(this._round.Count);

            sb.Append("' turn='");//��˭����

            sb.Append(this.turn);
            //sb.Append(this.getTurn());

            sb.Append("' difen='");

            sb.Append(this.difen);

            sb.Append("' bomb='");

            sb.Append(this.bomb);

            sb.Append("' win='");

            sb.Append(this.getWhoWin());

            sb.Append("'/>");

            //
            sb.Append("</room>");

            return sb.ToString();

        }
        */

        /// <summary>
        /// �Ź����˶��ƺ���
        /// </summary>
        /// <returns></returns>
        /// 
        /*
        public string getMatchStartXmlByRc()
        {

            StringBuilder sb = new StringBuilder();

            //
            sb.Append("<room id='");
            sb.Append(this.Id.ToString());
            sb.Append("' name='");
            sb.Append(this._name);
            //sb.Append("' tab='");
            //sb.Append(this.Tab.ToString());
            sb.Append("' gamename='");
            sb.Append("Ddz");
            sb.Append("'>");

            //
            sb.Append(getMatchStartXmlByRcContent());


            //
            sb.Append("</room>");

            return sb.ToString();
        
        
        
        }
        */

        /// <summary>
        /// �ύ����¼�����������½�����Ϸ��¼
        /// </summary>
        /// <returns></returns>
        public string getMatchResultXmlByRc()
        {
            StringBuilder sb = new StringBuilder();

            //
            sb.Append("<room id='");
            sb.Append(this.Id.ToString());
            sb.Append("' name='");
            sb.Append(this._name);
            //sb.Append("' tab='");
            //sb.Append(this.Tab.ToString());
            sb.Append("' gamename='");
            sb.Append("Ddz");
            sb.Append("'>");

            //
            sb.Append(getMatchResultXmlByRcContent());
            

            //
            sb.Append("</room>");

            return sb.ToString();
        
        }

        /// <summary>
        /// �Ź�����ר�ö��ƺ���
        /// �ƾֿ�ʼ�� ��ÿ���� ��һ��
        /// </summary>
        /// <returns></returns>
        /// 
        /*
        private string getMatchStartXmlByRcContent()
        {

            StringBuilder sb = new StringBuilder();

            //
            int len = this._chair.Count;

            for (int i = 0; i < len; i++) 
            {
                if ("" != this._chair[i].User.Id)
                {
                    sb.Append("<action type='sub' id='");
                    sb.Append(this._chair[i].User.Id);
                    sb.Append("' n='");
                    sb.Append(this._chair[i].User.NickName);
                    sb.Append("' g='");

                    //��һ��
                    sb.Append("1");

                    sb.Append("'/>");
                }            
            }

            return sb.ToString();

        }
        */

        private string getMatchResultXmlByRcContent()
        {
            StringBuilder sb = new StringBuilder();

            //ʤ������ ʤ 1 ����-1
            //���� = bomb x 2

            //ʤ������ x ���� x �׷� x ����

            string whoWin;

            Int64 winG;
            string winG_ = string.Empty;
            Int64 lostG;
            string lostG_ = string.Empty;
            Int64 costG;

            double tmpG;

            int bombG;
            int mingPaiG;

            string winId;
            string lostId;

            //ũ��
            //string lostId1;
            //string lostId2;

            string costId = this.getCostUid();

            string winNickName;
            string lostNickName;
            string costNickName = this.getCostU();
             

            List<IChairModel> users = this.findUser();

            if (0 == this.bomb && 0 == this.leaveBomb)
            {
                //�������� 0 x 0 = 0 
                bombG = 1;
            }
            else
            {
                //�������㷨
                //bombG = this.bomb * 2 + this.leaveBomb * 2;

                //�����㷨
                //Ϊ�����������,���16��
                if ((this.bomb + this.leaveBomb) > 16)
                {
                    bombG = Convert.ToInt32(Math.Pow(2, 16));
                }
                else
                {
                    bombG = Convert.ToInt32(Math.Pow(2, this.bomb + this.leaveBomb));
                }
            }

            //���Ƽӳ�
            if ("" == this.mingpai)
            {
                mingPaiG = 1;
            }
            else
            {
                //���Ʋ��ܼ���������ֻ��һ��
                mingPaiG = 2;   
            }

            //��һ��ʤ��
            whoWin = this.getWhoWin();


            //����ʤ��
            if ("dizhu" == whoWin)
            {
                if (""  != this.difen &&
                    "0" != this.difen)
                {
                    //2��ʾũ����2�ң���ȡ��2�ҵ�Ǯ
                    //ʤ������ = 1
                    winG = 2 * this.getDig() * Convert.ToInt32(this.difen) * bombG * mingPaiG;
                    lostG = this.getDig() * Convert.ToInt32(this.difen) * bombG * mingPaiG;

                    //
                    tmpG = Math.Floor(winG * this.getCostg());
                    costG = Int64.Parse(tmpG.ToString());
                    winG = winG - Int64.Parse(tmpG.ToString());
                    //lostG���䣬ֻ���Ӯ�ҿ�Ǯ

                }
                else
                {
                    //δ�е׷�(�򲻽�)��Ϸ�ѽ���
                    //�ͷ��Կ۷֣����׷ְ�2������,�ִ�ҷ�Ӧ�۵�̫�٣��ְ�3������
                    //winG = 2 * this.getDig() * 3�׷�;
                    //δ�е׷֣�������������ģʽ
                    winG = 2 * this.getDig() * 3 * mingPaiG;
                    lostG = this.getDig() * 3 * mingPaiG;
                    
                    //
                    tmpG = Math.Floor(winG * this.getCostg());
                    costG = Int64.Parse(tmpG.ToString());
                    winG = winG - Int64.Parse(tmpG.ToString());
                    //lostG���䣬ֻ���Ӯ�ҿ�Ǯ
                }

                //winId = this.dizhu;
                //lostId = this.nongming;
                winId  = users[0].getUser().Id;
                lostId = users[1].getUser().Id + "," + users[2].getUser().Id;

                winNickName = users[0].getUser().getNickName();
                lostNickName = users[1].getUser().getNickName() + "," + users[2].getUser().getNickName();

                //--------------------------------------------------
                //Ϊ���ٸ��Ӷȣ����һ��ֻ����ͬ������ֻ�ۻ�为����һ��
                //��ʱ���㹫ʽ����Ϊ win = 2 x �䷽(ĳһ��,Ǯ����,���ɸ���)���Ͻ��е�Ǯ
                if (!this._allowPlayerGlessThanZeroOnGameOver)
                {
                    if (users[1].getUser().getG() >= users[2].getUser().getG())
                    {
                        if (lostG >= users[2].getUser().getG())
                        {
                            lostG = users[2].getUser().getG();
                            winG = 2 * lostG;

                            //
                            tmpG = Math.Floor(winG * this.getCostg());
                            costG = Int64.Parse(tmpG.ToString());
                            winG = winG - Int64.Parse(tmpG.ToString());
                            //lostG���䣬ֻ���Ӯ�ҿ�Ǯ

                        }


                    }
                    else
                    {

                        if (lostG >= users[1].getUser().getG())
                        {
                            lostG = users[1].getUser().getG();
                            winG = 2 * lostG;

                            //
                            tmpG = Math.Floor(winG * this.getCostg());
                            costG = Int64.Parse(tmpG.ToString());
                            winG = winG - Int64.Parse(tmpG.ToString());
                            //lostG���䣬ֻ���Ӯ�ҿ�Ǯ
                        }


                    }
                }

                //
                if ("" != leaveUserId)
                {
                    //lostId = users[1].getUser().Id + "," + users[2].getUser().Id;

                    if (users[1].getUser().Id == leaveUserId)
                    {
                        lostG_ = (lostG * 2).ToString() + ",0";
                    }

                    if (users[2].getUser().Id == leaveUserId)
                    {
                        lostG_ = "0," + (lostG * 2).ToString();
                    }

                }
                else
                {
                    lostG_ = lostG + "," + lostG;
                }

                //--------------------------------------------------


            }
            else if ("nongming" == whoWin)//ũ��ʤ��
            {
                if (""  != this.difen &&
                    "0" != this.difen)
                {
                    //
                    //ʤ������ = 1
                    winG = this.getDig() * Convert.ToInt32(this.difen) * bombG * mingPaiG;
                    lostG = 2 * this.getDig() * Convert.ToInt32(this.difen) * bombG * mingPaiG;

                    //
                    tmpG = Math.Floor(winG * this.getCostg());
                    costG = Int64.Parse(tmpG.ToString());
                    winG = winG - Int64.Parse(tmpG.ToString());
                    //lostG���䣬ֻ���Ӯ�ҿ�Ǯ
                }
                else
                {
                    //δ�е׷�(�򲻽�)��Ϸ�ѽ���
                    //�ͷ��Կ۷֣����׷ְ�2������,�ִ�ҷ�Ӧ�۵�̫�٣��ְ�3������
                    //δ�е׷֣�������������ģʽ
                    winG = this.getDig() * 3 * mingPaiG;
                    lostG = 2 * this.getDig() * 3 * mingPaiG;

                    //
                    tmpG = Math.Floor(winG * this.getCostg());
                    costG = Int64.Parse(tmpG.ToString());
                    winG = winG - Int64.Parse(tmpG.ToString());
                    //lostG���䣬ֻ���Ӯ�ҿ�Ǯ

                }

                //winId = this.nongming;
                //lostId = this.dizhu;

                winId  = users[1].getUser().Id + "," + users[2].getUser().Id;
                lostId = users[0].getUser().Id;

                winNickName = users[1].getUser().getNickName() + "," + users[2].getUser().getNickName();
                lostNickName = users[0].getUser().getNickName();

                //--------------------------------------------------
                //
                if (!this._allowPlayerGlessThanZeroOnGameOver)
                {
                    if (lostG >= users[0].getUser().getG())
                    {
                        lostG = users[0].getUser().getG();
                        winG = lostG/2;

                        //
                        tmpG = Math.Floor(winG * this.getCostg());
                        costG = Int64.Parse(tmpG.ToString());
                        winG = winG - Int64.Parse(tmpG.ToString());
                        //lostG���䣬ֻ���Ӯ�ҿ�Ǯ

                    }
                }

                //��ͬ
                winG_ = winG.ToString() + "," + winG.ToString();

                //--------------------------------------------------

            }
            else
            {
                throw new ArgumentException("may be has one in getWhoWin");
            }
            
            //ÿ�ֻ��Ѵ���
            sb.Append("<action type='add' id='");
            sb.Append(costId);
            sb.Append("' n='");
            sb.Append(costNickName);
            sb.Append("' g='");
            sb.Append(costG.ToString());
            sb.Append("'/>");

            //������Ӯ
            sb.Append("<action type='add' id='");
            sb.Append(winId);
            sb.Append("' n='");
            sb.Append(winNickName);
            sb.Append("' g='");


            if (string.IsNullOrEmpty(winG_))
            {
                sb.Append(winG.ToString());

            }
            else
            {
                sb.Append(winG_.ToString());
            }

            sb.Append("'/>");

            sb.Append("<action type='sub' id='");
            sb.Append(lostId);
            sb.Append("' n='");
            sb.Append(lostNickName);
            sb.Append("' g='");

            if(string.IsNullOrEmpty(lostG_))
            {
                sb.Append(lostG.ToString());
            
            }else
            {
                sb.Append(lostG_.ToString());                
            }
            
            sb.Append("'/>");

            return sb.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string toXMLString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<room id='");

            sb.Append(this._id.ToString());

            sb.Append("' tab='");
            
            sb.Append(this._tab.ToString());

            sb.Append("' tabAutoMatchMode='");

            sb.Append(this._tabAutoMatchMode.ToString());

            sb.Append("' tabQuickRoomMode='");

            sb.Append(this._tabQuickRoomMode.ToString());

            sb.Append("' name='");

            sb.Append(this._name);

            sb.Append("'>");

            //matchInfo node
            sb.Append("<match dizhu='");

            sb.Append(this.dizhu);

            sb.Append("' nongming='");

            sb.Append(this.nongming);

            sb.Append("' round='");

            sb.Append(this._round.Count.ToString());

            sb.Append("' turn='");//��˭����

            //
            sb.Append(this.turn);
            //sb.Append(this.getTurn());

            sb.Append("' iswaitreconn='");

            sb.Append(AS3Util.convertBoolToAS3(this.isWaitReconnection));

            sb.Append("' difen='");

            sb.Append(this.difen);

            sb.Append("' bomb='");

            sb.Append(this.bomb);

            sb.Append("' win='");

            sb.Append(this.getWhoWin());

            sb.Append("'/>");

            //�����ʤ�������Ͻ��仯ֵ
            if ("" != this.getWhoWin())
            {
                sb.Append(getMatchResultXmlByRcContent());
            }

            //chair node
            for (int i = 0; i < this._chair.Count; i++)
            {
                IChairModel chair = this._chair[i];

                sb.Append(chair.toXMLString());
            }

            //item node
            sb.Append(this._board.toXMLString());

            //round node
            StringBuilder rb = new StringBuilder();
            Dictionary<string, string> rd = new Dictionary<string, string>();
            for (int j = 0; j < this._round.Count; j++)
            {
                this._round[j].Id = j + 1;

                //---- ����round�����̫����Ҫ���û�id̫������һ������Ż� begin ---
                string rj = ByRound(rd, j);

                //---- ����round�����̫����Ҫ���û�id̫������һ������Ż� end ---

                rb.Append(rj);               
            }
            

            _record.Id = _round.Count + 1;
            string rs = ByRecord(rd, _record); //this._record.toXMLSting();
            rb.Append(rs);

            //meta key ,rd.toXMLString()
            rb.Append("<roundMeta ");
            foreach (var vrd in rd)
            {
                rb.Append(vrd.Key + "='" + vrd.Value + "' ");
            }
            rb.Append("/>");

            //
            sb.Append(rb.ToString());

            //
            sb.Append("</room>");

            return sb.ToString();

        }

        private string ByRecord(Dictionary<string, string> rd, RoundModelByDdz _round_j)
        {

            if ("" != _round_j.clock_one)
            {
                if (!rd.ContainsValue(_round_j.clock_one) &&
                   !rd.ContainsKey("A"))
                {
                    rd.Add("A", _round_j.clock_one);
                }

                if (!rd.ContainsValue(_round_j.clock_one) &&
                    !rd.ContainsKey("B"))
                {
                    rd.Add("B", _round_j.clock_one);
                }

                if (!rd.ContainsValue(_round_j.clock_one) &&
                    !rd.ContainsKey("C"))
                {
                    rd.Add("C", _round_j.clock_one);
                }
            }

            if ("" != _round_j.clock_two)
            {
                if (!rd.ContainsValue(_round_j.clock_two) &&
                   !rd.ContainsKey("A"))
                {
                    rd.Add("A", _round_j.clock_two);
                }

                if (!rd.ContainsValue(_round_j.clock_two) &&
                    !rd.ContainsKey("B"))
                {
                    rd.Add("B", _round_j.clock_two);
                }

                if (!rd.ContainsValue(_round_j.clock_two) &&
                    !rd.ContainsKey("C"))
                {
                    rd.Add("C", _round_j.clock_two);
                }
            }

            if ("" != _round_j.clock_three)
            {
                if (!rd.ContainsValue(_round_j.clock_three) &&
                   !rd.ContainsKey("A"))
                {
                    rd.Add("A", _round_j.clock_three);
                }

                if (!rd.ContainsValue(_round_j.clock_three) &&
                    !rd.ContainsKey("B"))
                {
                    rd.Add("B", _round_j.clock_three);
                }

                if (!rd.ContainsValue(_round_j.clock_three) &&
                    !rd.ContainsKey("C"))
                {
                    rd.Add("C", _round_j.clock_three);
                }
            }

            string rj = _round_j.toXMLSting();

            //replace
            if(rd.ContainsKey("A"))
            {
                rj = rj.Replace(rd["A"], "A");
            }

            if(rd.ContainsKey("B"))
            {
                rj = rj.Replace(rd["B"], "B");
            }

            if (rd.ContainsKey("C"))
            {
                rj = rj.Replace(rd["C"], "C");
            }

            return rj;
        
        }

        private string ByRound(Dictionary<string, string> rd, int j)
        {

            if ("" != this._round[j].clock_one)
            {
                if (!rd.ContainsValue(this._round[j].clock_one) && 
                    !rd.ContainsKey("A"))
                {
                    rd.Add("A", this._round[j].clock_one);
                }

                if (!rd.ContainsValue(this._round[j].clock_one) && 
                    !rd.ContainsKey("B"))
                {
                    rd.Add("B", this._round[j].clock_one);
                }

                if (!rd.ContainsValue(this._round[j].clock_one) && 
                    !rd.ContainsKey("C"))
                {
                    rd.Add("C", this._round[j].clock_one);
                }
            }

            if ("" != this._round[j].clock_two)
            {
                if (!rd.ContainsValue(this._round[j].clock_two) &&
                   !rd.ContainsKey("A"))
                {
                    rd.Add("A", this._round[j].clock_two);
                }

                if (!rd.ContainsValue(this._round[j].clock_two) &&
                    !rd.ContainsKey("B"))
                {
                    rd.Add("B", this._round[j].clock_two);
                }

                if (!rd.ContainsValue(this._round[j].clock_two) &&
                    !rd.ContainsKey("C"))
                {
                    rd.Add("C", this._round[j].clock_two);
                }
            }

            if ("" != this._round[j].clock_three)
            {
                if (!rd.ContainsValue(this._round[j].clock_three) &&
                    !rd.ContainsKey("A"))
                {
                    rd.Add("A", this._round[j].clock_three);
                }

                if (!rd.ContainsValue(this._round[j].clock_three) &&
                    !rd.ContainsKey("B"))
                {
                    rd.Add("B", this._round[j].clock_three);
                }

                if (!rd.ContainsValue(this._round[j].clock_three) &&
                    !rd.ContainsKey("C"))
                {
                    rd.Add("C", this._round[j].clock_three);
                }
            }

            string rj = this._round[j].toXMLSting();

            //replace
            if(rd.ContainsKey("A"))
            {
                rj = rj.Replace(rd["A"], "A");
            }

            if(rd.ContainsKey("B"))
            {
                rj = rj.Replace(rd["B"], "B");
            }

            if (rd.ContainsKey("C"))
            {
                rj = rj.Replace(rd["C"], "C");
            }
            return rj;
        }


        /// <summary>
        /// ȥ�����滻contentXml�е�һЩ��Ϣ
        /// </summary>
        /// <param name="contentXml"></param>
        /// <returns></returns>
        public string getFilterContentXml(string strIpPort, string contentXml)
        {
            //loop use
            int i = 0;
            int j = 0;
            int h = 0;
            
            //
            int len = this._chair.Count;

            //
            int n0 = 0;
            int n1 = 0;
            int n2 = 0;
            XmlElement ele0;
            XmlElement ele1;
            XmlElement ele2;

            //
            string ming = string.Empty;

            for (i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getReadyAdd() == PAI_RULE.MING_PAI)
                {
                    ming += i.ToString();
                    ming += ",";//ming containsֻ�Ը�λ������
                }

            }//end for

            //
            //��������Ƶģ��䲿���㹫�����֣�
            //ɾ��δ���Ƶ�����
            //�Լҵ�����Ҳ��Ҫɾ
            XmlDocument doc = new XmlDocument();

            //�������ʧ�ܣ���ie�鿴xml����Ƿ��������ʾ
            doc.LoadXml(contentXml);

            XmlNodeList itemList = doc.SelectNodes("/room/item");

            //
            for (i = 0; i < len; i++)
            {
                IChairModel chair = this._chair[i];

                if (chair.getUser().getStrIpPort() == strIpPort)
                {
                    if (0 == i)
                    { 
                        //ɾ��1,2
                        //�ͻ����ж�Ϊ�գ������Ѵ���17�� pai_bg xml
                        for (j = 0; j < itemList.Count; j++)
                        {
                            XmlNode gridNode = itemList.Item(j);

                            h = Convert.ToInt32(gridNode.Attributes["h"].Value);

                            if (1 == h)
                            {
                                if (!ming.Contains(h.ToString()))
                                {
                                    //xmlNodeList.Item(1).ParentNode.RemoveChild( xmlNodeList.Item(1))
                                    gridNode.ParentNode.RemoveChild(gridNode);
                                    n1++;
                                }
                            
                            }//end if

                            if (2 == h)
                            {
                                if (!ming.Contains(h.ToString()))
                                {
                                    //xmlNodeList.Item(1).ParentNode.RemoveChild( xmlNodeList.Item(1))
                                    gridNode.ParentNode.RemoveChild(gridNode);
                                    n2++;
                                }
                            
                            }//end if


                        }//end for

                        //���治�����ƻ�ɾ����
                        //����ӱ���
                        /*
                        if (!ming.Contains("1"))
                        {
                            if (chair.getUser().Id == this.dizhu)
                            {
                                ele1 = doc.CreateElement("item");
                                ele1.SetAttribute("n", PokerName.BG_NONGMING);
                            }
                        }*/

                        if (!ming.Contains("1"))
                        {
                            ele1 = doc.CreateElement("item");

                            if (this._chair[1].getUser().Id == this.dizhu && 
                                "" != this.dizhu)
                            {
                                ele1.SetAttribute("n", PokerName.BG_DIZHU);//�Է�

                            }
                            else if (this.nongming.Contains(this._chair[1].getUser().Id) &&
                                "" != this.nongming)
                            {
                                ele1.SetAttribute("n", PokerName.BG_NONGMING);

                            }
                            else
                            {
                                ele1.SetAttribute("n", PokerName.BG_NORMAL);
                            }

                            ele1.SetAttribute("h", "1");
                            ele1.SetAttribute("v", n1.ToString());//v���count����˼

                            doc.DocumentElement.AppendChild(ele1);
                        }

                        if (!ming.Contains("2"))
                        {
                            ele2 = doc.CreateElement("item");

                            if (this._chair[2].getUser().Id == this.dizhu &&
                               "" != this.dizhu)
                            {
                                ele2.SetAttribute("n", PokerName.BG_DIZHU);//�Է�

                            }
                            else if (this.nongming.Contains(this._chair[2].getUser().Id) &&
                               "" != this.nongming)
                            {
                                ele2.SetAttribute("n", PokerName.BG_NONGMING);

                            }
                            else
                            {
                                ele2.SetAttribute("n", PokerName.BG_NORMAL);
                            }

                            ele2.SetAttribute("h", "2");
                            ele2.SetAttribute("v", n2.ToString());//v���count����˼

                            doc.DocumentElement.AppendChild(ele2);
                        }



                    }
                    else if (1 == i)
                    {

                        //ɾ��0,2
                        //�ͻ����ж�Ϊ�գ������Ѵ���17�� pai_bg xml
                        for (j = 0; j < itemList.Count; j++)
                        {
                            XmlNode gridNode = itemList.Item(j);

                            h = Convert.ToInt32(gridNode.Attributes["h"].Value);

                            if (0 == h)
                            {
                                if (!ming.Contains(h.ToString()))
                                {
                                    gridNode.ParentNode.RemoveChild(gridNode);
                                    n0++;
                                }
                            }

                            if (2 == h)
                            {
                                if (!ming.Contains(h.ToString()))
                                {
                                    gridNode.ParentNode.RemoveChild(gridNode);
                                    n2++;
                                }
                            
                            }

                        }//end for

                        //ɾ�����ټ�
                        if (!ming.Contains("0"))
                        {
                            ele0 = doc.CreateElement("item");

                            if (this._chair[0].getUser().Id == this.dizhu &&
                                "" != this.dizhu)
                            {
                                ele0.SetAttribute("n", PokerName.BG_DIZHU);//�Է�

                            }
                            else if (this.nongming.Contains(this._chair[0].getUser().Id) &&
                                "" != this.nongming)
                            {
                                ele0.SetAttribute("n", PokerName.BG_NONGMING);

                            }
                            else
                            {
                                ele0.SetAttribute("n", PokerName.BG_NORMAL);
                            }

                            ele0.SetAttribute("h", "0");
                            ele0.SetAttribute("v", n0.ToString());//v���count����˼

                            doc.DocumentElement.AppendChild(ele0);
                        }

                        if (!ming.Contains("2"))
                        {
                            ele2 = doc.CreateElement("item");

                            if (this._chair[2].getUser().Id == this.dizhu &&
                               "" != this.dizhu)
                            {
                                ele2.SetAttribute("n", PokerName.BG_DIZHU);//�Է�

                            }
                            else if (this.nongming.Contains(this._chair[2].getUser().Id) &&
                               "" != this.nongming)
                            {
                                ele2.SetAttribute("n", PokerName.BG_NONGMING);

                            }
                            else
                            {
                                ele2.SetAttribute("n", PokerName.BG_NORMAL);
                            }

                            ele2.SetAttribute("h", "2");
                            ele2.SetAttribute("v", n2.ToString());//v���count����˼

                            doc.DocumentElement.AppendChild(ele2);
                        }

                    }
                    else if (2 == i)
                    {

                        //ɾ��0,1
                        //�ͻ����ж�Ϊ�գ������Ѵ���17�� pai_bg xml
                        for (j = 0; j < itemList.Count; j++)
                        {
                            XmlNode gridNode = itemList.Item(j);

                            h = Convert.ToInt32(gridNode.Attributes["h"].Value);

                            if (0 == h)
                            {
                                if (!ming.Contains(h.ToString()))
                                {
                                    gridNode.ParentNode.RemoveChild(gridNode);
                                    n0++;
                                }
                            }

                            if (1 == h)
                            {
                                if (!ming.Contains(h.ToString()))
                                {
                                    gridNode.ParentNode.RemoveChild(gridNode);
                                    n1++;
                                }                            
                            }
                        }//end for

                        //ɾ�����ټ�
                        if (!ming.Contains("0"))
                        {
                            ele0 = doc.CreateElement("item");

                            if (this._chair[0].getUser().Id == this.dizhu &&
                                "" != this.dizhu)
                            {
                                ele0.SetAttribute("n", PokerName.BG_DIZHU);//�Է�

                            }
                            else if (this.nongming.Contains(this._chair[0].getUser().Id) &&
                                "" != this.nongming)
                            {
                                ele0.SetAttribute("n", PokerName.BG_NONGMING);

                            }
                            else
                            {
                                ele0.SetAttribute("n", PokerName.BG_NORMAL);
                            }

                            ele0.SetAttribute("h", "0");
                            ele0.SetAttribute("v", n0.ToString());//v���count����˼

                            doc.DocumentElement.AppendChild(ele0);
                        }

                        if (!ming.Contains("1"))
                        {
                            ele1 = doc.CreateElement("item");

                            if (this._chair[1].getUser().Id == this.dizhu &&
                               "" != this.dizhu)
                            {
                                ele1.SetAttribute("n", PokerName.BG_DIZHU);//�Է�

                            }
                            else if (this.nongming.Contains(this._chair[1].getUser().Id) &&
                               "" != this.nongming)
                            {
                                ele1.SetAttribute("n", PokerName.BG_NONGMING);

                            }
                            else
                            {
                                ele1.SetAttribute("n", PokerName.BG_NORMAL);
                            }                           

                            ele1.SetAttribute("h", "1");
                            ele1.SetAttribute("v", n1.ToString());//v���count����˼

                            doc.DocumentElement.AppendChild(ele1);
                        }
                    
                    
                    }

                    break;
                }//end if

            }//end for

            return doc.OuterXml;        
        }
    }
}
