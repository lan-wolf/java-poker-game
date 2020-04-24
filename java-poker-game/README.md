银狐U3D游戏开发Java写的斗地主游戏源码
源码下载在最后我们的前年的课设要求做一个斗地主程序，当时正在愁如何做界面，当时刚好在学习C#，于是就用C#完成了这个程序。一方面，当时我C#功底还很差（其实现在也不怎么样），很多地方用了“笨办法”，实现的比较幼稚，程序效率很低，另一方面感觉很对不起老师，因为做这个程序的本意是研究斗地主程序的AI出牌等等算法相关的东西，而我却几乎忽略了这些内容。（我会好好学习算法的……^-^）最可怕的是，由于当时时间比较紧，只有几天的时间，所以我本着“能跑就行”的想法完成了这个程序。从程序本身来说，我觉得我的代码几乎没有任何参考价值，满篇的switch...case...，乱七八糟的结构，而且最可怕的是，所有代码几乎都集中在了一个mainform.xaml.cs文件里。。。太恐怖了。我一直为我会写出这样的代码感到羞耻……因此也就没敢发布这些源码。最近又在研究Java，做另外的项目，看了看以前的代码，觉得虽然代码很烂，但有些地方的处理还是有一定意义的，毕竟这也算是个中小游戏应用，于是又用JAVA重写了一遍，发上来和大家分享。如果能对你的学习或者工作起到任何作用，我都会非常高兴。此源码完全自由使用，你可以利用它做任何事情，包括商业应用，而不需要提前通知我。   这次采用的是JAVA8 ，最新发布的JAVA版本，IDE是netbeans，一共有80MB左右大小，体积不大，安装也容易  程序文件夹结构是从C#转过来的，期间使用一个叫C#转JAVA的工具，转换了一下语法，效果不是很理想，还是手工改了许多地方可以看到，程序是从Program.java启动（和VS的项目一样） 游戏是网页版联机的，因此分服务端和客户端二部分，服务端JAVA包括斗地主逻辑服务 和 记录服务（生成SQL语句发给数据库）  游戏客户端 -》 斗地主逻辑服务 - 》 记录服务 -》 数据库               《-                       《-             《- 客户端发消息到斗地主逻辑，斗地主逻辑转发到记录服务，再返回来，这样一个通信过程分成逻辑和记录二部分的好处是 可以并行运行提高效率，比如在SQL语句执行时，斗地主逻辑可以继续处理请求 
       现在开始构架游戏，为了不让代码那么难看，我们很有必要加入设计模式和面向对象思想。 　　首先，我们列出54张牌。       大家可以看到，扑克数字相同时，有4种花色，桃心梅方       利用这个特性，我们采用了数字间隔，0-3一组 ， 4-7一组，如果想得到花色，取模就可以了，是不是很方便？ 1 /** 2      * 背面牌都是负数 3      */ 4     public static final int BG_NORMAL = -3; 5     public static final int BG_NONGMING = -2; 6     public static final int BG_DIZHU = -1; 7 8     public static final int F_3 = 0; 9     public static final int M_3 = 1;10     public static final int X_3 = 2;11     public static final int T_3 = 3;1213     public static final int F_4 = 4;14     public static final int M_4 = 5;15     public static final int X_4 = 6;16     public static final int T_4 = 7;1718     public static final int F_5 = 8;19     public static final int M_5 = 9;20     public static final int X_5 = 10;21     public static final int T_5 = 11;2223     public static final int F_6 = 12;24     public static final int M_6 = 13;25     public static final int X_6 = 14;26     public static final int T_6 = 15;2728     public static final int F_7 = 16;29     public static final int M_7 = 17;30     public static final int X_7 = 18;31     public static final int T_7 = 19;3233     public static final int F_8 = 20;34     public static final int M_8 = 21;35     public static final int X_8 = 22;36     public static final int T_8 = 23;3738     public static final int F_9 = 24;39     public static final int M_9 = 25;40     public static final int X_9 = 26;41     public static final int T_9 = 27;4243     public static final int F_10 = 28;44     public static final int M_10 = 29;45     public static final int X_10 = 30;46     public static final int T_10 = 31;4748     public static final int F_J = 32;49     public static final int M_J = 33;50     public static final int X_J = 34;51     public static final int T_J = 35;5253     public static final int F_Q = 36;54     public static final int M_Q = 37;55     public static final int X_Q = 38;56     public static final int T_Q = 39;5758     public static final int F_K = 40;59     public static final int M_K = 41;60     public static final int X_K = 42;61     public static final int T_K = 43;6263     public static final int F_A = 44;64     public static final int M_A = 45;65     public static final int X_A = 46;66     public static final int T_A = 47;6768     public static final int F_2 = 56;69     public static final int M_2 = 57;70     public static final int X_2 = 58;71     public static final int T_2 = 59;7273     public static final int JOKER_XIAO = 60;74     public static final int JOKER_DA = 64; 在PaiBoardByDdz类中，负责生成新牌和洗牌操作。我的思想是这样的，先通过算法按顺序生成54张牌，然后随机抽取这些牌，被抽取的牌从原来集合中删除，直到所有的牌都被抽取完毕为止，从而达到洗牌的目的。参考如下代码：可以看出生成新牌的时候使用了增强的随机数。/**     洗牌    */    public final void xipai()    {            //            reset();            //            int i = 0;            int len = 0;            int n = 0;            //clone pai name            java.util.ArrayList<String> p = PAI_NAME.GetList();            //第一次发17张牌            len = 17;            //提高随机数不重复概率的种子生成方法:            //Millisecond 取值范围是 0 - 999            //DateTime.Now.Ticks是指从1970年1月1日（具体哪年忘了哈，好像是1970）开始到目前所经过的毫秒数——刻度数。            //54张牌的组合是 54!            //是一个非常大的数,结果是: 2.3e + 71            //因此我们的seed的取值范围也应该非常大,也就是0到上面的结果,            //Millisecond小了，导致只会出现999种牌的组合            //guid方法不可取,每回都是一样的            //直接以Random做为随机数生成器因为时钟精度问题，            //在一个小的时间段内会得到同样的伪随机数序列，            //你shuffle后会得到同一个结果。            //.net提供了RNGCryptoServiceProvider可以避免这种情况            //GetRandSeed后的取值范围是 0 - int32.MaxValue，虽然还差很远，但是999要好很多            java.util.Random r = new java.util.Random(RandomUtil.GetRandSeed());            for (i = 0; i < len; i++)            {                    n = r.nextInt(p.size());                    grid[0][i] = p.get(n);                    p.remove(n);            }            for (i = 0; i < len; i++)            {                    n = r.nextInt(p.size());                    grid[1][i] = p.get(n);                    p.remove(n);            }            for (i = 0; i < len; i++)            {                    n = r.nextInt(p.size());                    grid[2][i] = p.get(n);                    p.remove(n);            } //end for            //底牌            grid2[0] = p.get(0);            grid2[1] = p.get(1);            grid2[2] = p.get(2);            //distory            p.clear();    }  过Win7的纸牌游戏的朋友，一定对于游戏中的发牌动画记忆深刻，现在我们自己来实现这个动画过程。提到发牌动画，90%的程序员肯定会想到利用位置（Location）的变化来刷新界面，可能需要启用一些线程或者计时器之类的。但是Flash天生就是用来做动画的，用Tween缓动可以很容易实现。客户端采用了FLASH编写，IDE为Flash Builder，语言则换成了AS3，由于本篇主讲JAVA，因此这里略过。唯一需要注意的是，为保证程序代码的一致性，基本都是JAVA写好后，直接复制到客户端那边，这样省了建模字段不一样，或者名称不一致的问题 这个游戏采用了插件设计, 目前可以整合DISCUZ，自已不需要独立的数据库，共用DISCUZ的，需要使用的童鞋，先架设好DISCUZ和MYSQL数据库（可以用WAMP集成环境) 
成品下载地址http://pan.baidu.com/s/1gdjOIYZ 
 独立数据库，需要VPS或独立主机一台，有独立外网IP可与论坛放同一主机，或分开放也可（共用论坛的数据库）安装说明1.将斗地主客户端所有文件 拷贝到论坛根目录2.在服务器上安装好Java 8   修改DdzServer、RecordServer 目录里的run.bat，将里面路径修改为当前路RecordServer 参数还包括连接论坛MYSQL数据库的用户名，密码等 
   依次启动DdzServer，RecordServer 和SecurityServer安全策略服务支持win,Linux操作系统，Linux在terminal上输入 sudo java -jar 完整路径*需要服务器开放9300 ，843 TCP端口 3.在浏览器输入 http://你的网址/ddz.php 开始游戏可多人同时玩，有排行榜，可聊天 源码https://github.com/wdmir/521266750_qq_com.git好文要顶 关注我 收藏该文  
jiahuafu关注 - 56粉丝 - 162+加关注10« 上一篇： 近几日小学flare3d,» 下一篇： 什么是 A 轮融资？有 B轮 C轮么？posted on 2015-11-04 15:16  jiahuafu  阅读(63856)  评论(45)  编辑  收藏
评论#1楼 [楼主] 2015-12-03 15:02 jiahuafu

.Net和Java都做过不少项目，应该有权做个比较了。
从语法上讲，确实Java完败，简洁优雅高效这几点C#确实要做得更好。（注意是开发高效不是运行高效）。
近几年.net的发展远比java要快，这应该也是不争的事实，感觉sun被oracle收购后，java就进入了瓶颈期，直到1.8才算是让广大的java程序员看到了点希望，顺便吐槽一下java的lamda，真是实现得不怎么样，比C#差太多。
不过java胜在众多的第三方开源代码，这一点.net近期很难追上。另外Java强调规范性，程序员都遵守相同的规范也确实有助于协同工作，不过现在流行轻量级框架，老的那一套也逐渐被打破了。
未来不好说，.net也要跨平台了，java的优势又少了一块。
支持(0) 反对(3)
  #2楼 2017-01-08 09:21 羽修
付老师，请问下 各个项目间是怎么引用的？
支持(0) 反对(0)
  #3楼 [楼主] 2017-02-10 16:59 jiahuafu

@ 羽修
各个项目间都是独立的，引用需要的库即可
支持(0) 反对(0)
  #4楼 2017-02-20 14:30 heng123456

付老师您好，我是php LNMP的环境加java Tomcat7的环境，然后我做到了这一步的时候，Linux在terminal上输入 sudo java -jar 完整路径 ，发生以下问题，String index out of range: -1
不知道如何解决，希望能够得到您的解答，非常感谢
[root@xxx dist]# sudo `which java` -jar DdzServer.jar
wdmir.com 2003-2015
www.silverFoxServer.net 2009-2015
[OS] Linux
[LOG] /home/php/wwwroot/default/DiscuzX/upload/DdzServer/dist/logs
[Boot] Dou di zhu Server

[Failed] service failed to start the game, desc: String index out of range: -1

For assistance, please visit the author website: www.silverFoxServer.net
email:521266750@qq.com

，这是在linux服务器的测试，就出现了这样的问题，如果是在本地，是win系统的话好像就不会，但是由于win不是服务器无法开放端口进行测试
支持(0) 反对(0)
  #5楼 [楼主] 2017-02-22 09:54 jiahuafu

@ heng123456
因为本人一直在windows上面测试的，这个问题你要想解决的话，建议你看一下源码，String index out of range: -1 这个应该不是大问题，自已改下，
源码在github上
https://github.com/wdmir/521266750_qq_com.git
支持(0) 反对(0)
  #6楼 2017-03-03 20:11 飞刀飞呀飞
大神，麻烦问下www.silverFoxServer.net这个网址是做什么的啊。
支持(0) 反对(0)
  #7楼 [楼主] 2017-03-15 11:00 jiahuafu

@ 飞刀飞呀飞
斗地主游戏服务端，现已升级，为开发者提供更多的功能
易于搭建和二次开发的游戏服务端
支持(0) 反对(0)
  #8楼 2017-03-22 17:31 仰泳鱼
请问这个DZ论坛要求的版本是多少？
支持(0) 反对(0)
  #9楼 [楼主] 2017-03-28 17:46 jiahuafu

@ 仰泳鱼
DZ X1.5或以上
支持(0) 反对(0)
  #10楼 2017-04-04 15:31 ckmingyang

楼主，您好，感谢您的分享。
我在windows server 2008上安装，结果运行DdzServer的run.bat时提示如下错误：
异常：net.silverfoxserver.core.socket.SocketConnector 函数connect
原因：java.net.ConnectException:Connection refused: no further inforamtion:127.0.0.1:9500
支持(0) 反对(0)
  #11楼 2017-06-12 17:01 TZWX
这个项目包有点看不懂，
支持(0) 反对(0)
  #12楼 [楼主] 2017-07-03 09:14 jiahuafu

@ TZWX
哪里看不懂？
支持(0) 反对(0)
  #13楼 [楼主] 2017-07-03 09:15 jiahuafu

@ ckmingyang
RecordServer的run.bat没有运行
支持(0) 反对(0)
  #14楼 2017-07-03 11:46 TZWX

@ jiahuafu
这个项目包不是一个项目吧？
支持(0) 反对(0)
  #15楼 2017-07-03 11:47 TZWX

@ jiahuafu
我只想用其中的ddz部分，该怎么办？
支持(0) 反对(0)
  #16楼 2017-07-03 12:19 TZWX
netBeans写的ddzServer源码能放在eclipse上吗？
支持(0) 反对(0)
  #17楼 2017-07-03 15:55 TZWX
我想玩你做好的游戏， http://你的网址/ddz.php 开始游戏 。你的网址是多少？
支持(0) 反对(0)
  #18楼 2017-07-03 16:01 TZWX
如果我只想组建局域网，不需要联网，需要注意什么
支持(0) 反对(0)
  #19楼 [楼主] 2017-07-03 22:10 jiahuafu

@ TZWX
架个WEB服务器，确保几台机子能正常访问即可
支持(0) 反对(0)
  #20楼 2017-07-04 00:13 TZWX
你好，有没有服务端接口文档
支持(0) 反对(0)
  #21楼 2017-07-04 00:13 TZWX
看不太懂
支持(0) 反对(0)
  #22楼 2017-07-04 10:14 TZWX
如果，我想前端用h5写，直接和你这个服务端搭接，有没有问题
支持(0) 反对(0)
  #23楼 2017-07-07 09:30 TZWX
付老师，不好意思，之前我的废话多了些。想问一下，你的数据库的SQL语句能给我发一下吗
支持(0) 反对(0)
  #24楼 [楼主] 2017-07-28 09:57 jiahuafu

@ TZWX
建表的SQL语句都写在RecordServer里面了，
如果表不存在，它会自动创建表的
支持(0) 反对(0)
  #25楼 [楼主] 2017-07-28 09:59 jiahuafu

@ TZWX
得用新版，新版支持WEBSOCKET，新版还在开发中
这上面是老版， 只支持传统TCP/IP
支持(0) 反对(0)
  #26楼 [楼主] 2017-07-28 10:00 jiahuafu

@ TZWX
能
支持(0) 反对(0)
  #27楼 2017-07-28 10:12 TZWX

@ jiahuafu
谢谢
支持(0) 反对(0)
  #28楼 2017-09-23 10:41 chenming000
想问下付老师 这个如何运行的啊 我想看看
支持(0) 反对(0)
  #29楼 2017-09-23 11:17 chenming000

@ jiahuafu
请问下这个项目你启动了嘛 怎么启动的
支持(0) 反对(0)
  #30楼 2017-09-27 15:18 zhaojiatao
老师，那个记录服务开启后没有自动建表
支持(0) 反对(0)
  #31楼 [楼主] 2017-09-28 11:02 jiahuafu

@ coder.zjt
看一下窗口的输出
支持(0) 反对(0)
  #32楼 2017-10-25 00:47 请风徐来
求一个在线链接看看效果
支持(0) 反对(0)
  #33楼 2017-11-01 12:48 安清
不错。http://www.cnblogs.com/ansating/p/7761855.html 这个连接的斗地主全程都是java开发的，包括客户端，感觉也不错！
支持(0) 反对(0)
  #34楼 2017-12-13 11:21 至死不渝丶
付老师，可以把素材发给我吗，这是我的邮箱 aiyongyi@163.com
支持(0) 反对(0)
  #35楼 2017-12-22 14:31 悠斋互娱rx3167
悠斋互娱你明智的选择，H5平台搭建，RX3167
支持(0) 反对(0)
  #36楼 [楼主] 2018-01-07 10:11 jiahuafu

@ 至死不渝丶
这个发不了
支持(0) 反对(0)
  #37楼 2018-01-28 00:49 itfanszhao
为什么自动建表语句没有执行，我看源码了，也没有调用的地方，RCLogicC.createMsSqlTable 这个方法应该是建表语句吧，源码中没有调用，望指教，谢谢
支持(0) 反对(0)
  #38楼 2018-01-28 00:53 itfanszhao

忘了给你发错误了，补上：
[00:03:43,746000000] 异常:net.silverfoxserver.RCLogic 函数:testMySqlConnection 原因:Table 'ultrax.pre_common_member' doesn't exist
支持(0) 反对(0)
  #39楼 [楼主] 2018-03-05 09:20 jiahuafu

@ itfanszhao
因为时间精力的问题,MSSQL没写，只写了Mysql的
支持(0) 反对(0)
  #40楼 [楼主] 2018-03-05 09:21 jiahuafu

@ itfanszhao
检查一下数据库名和表前缀
支持(0) 反对(0)
  #41楼 2018-06-12 14:18 mingjone_sherman
我要怎么运行这个程序
支持(0) 反对(0)
  #42楼 2019-12-16 17:58 ahjinka
ddzserver和recordserver都起来了，用哪个地址访问呢，大神？项目不是web项目，怎么可以浏览器访问呢
支持(0) 反对(0)
  #43楼 [楼主] 2019-12-23 09:13 jiahuafu

@ ahjinka
是网页flash，需要自已建个WEB站点
支持(0) 反对(0)
  #44楼 2019-12-23 09:23 ahjinka
不明白，能详细说一下吗。。
支持(0) 反对(0)
  #45楼 2020-02-01 14:12 程序员成神之路

@ jiahuafu
您好老师，我最近在学JAVA，但是这代码根本看不懂，看了您发的帖子
感觉挺好的，您可以指点一下，让我如何看懂代码呢

我的微信号 是 chinesegushen
微信名字是 投资达人

