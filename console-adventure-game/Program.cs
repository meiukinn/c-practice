namespace 入门实践
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 控制台基础设置
            //隐藏光标
            Console.CursorVisible = false;

            //通过两个变量来存储 舞台大小
            int w = 50;
            int h = 30;
            
            if (OperatingSystem.IsWindows())
            {
                //设置舞台（控制台窗口）大小
                Console.SetWindowSize(w, h);

                //设置画布大小
                Console.SetBufferSize(w, h);
            }
            #endregion


         
            //当前所在场景的编号
            int nowSceneID = 1;

            //结束场景显示的 文字提示内容
            string gameOverInfo = "";
            
            while(true)
            {
                //不同场景ID 进行不同的逻辑处理
                switch(nowSceneID)
                {
                    //开始界面
                    case 1:
                        Console.Clear();
                        #region 开始界面逻辑
                        Console.SetCursorPosition(w / 2 - 9, 5);
                        Console.Write("The Legend of Zelda");

                        //当前选项编号
                        int nowSelIndex = 0;
                        //输入 可以构造一个开始界面自己的死循环 专门处理开始界面相关的逻辑
                        while (true)
                        {
                            //用一个标识 来处理 想要再while循环内部的switch逻辑执行时 希望退出外层while循环时 改变标识即可
                            bool isQuitWhile = false;
                            //显示 内容
                            //先设置光标位置 再显示内容
                            Console.SetCursorPosition(w / 2 - 4, 9);

                            //三目运算符 直接替代if
                            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;

                            Console.Write("New Game");

                            Console.SetCursorPosition(w / 2 - 2, 11);

                            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;

                            Console.Write("Exit");

                            //检测 输入
                            //检测玩家 输入的一个键内容 并且不会在控制台上显示输入内容
                            char input = Console.ReadKey(true).KeyChar;
                            switch (input)
                            {
                                case 'W':
                                case 'w':
                                    --nowSelIndex;
                                    if (nowSelIndex < 0)
                                    {
                                        nowSelIndex = 1;
                                    }
                                    break;

                                case 'S':
                                case 's':
                                    ++nowSelIndex;
                                    if (nowSelIndex > 1)
                                    {
                                        nowSelIndex = 0;
                                    }
                                    break;

                                case 'J':
                                case 'j':
                                    if (nowSelIndex == 0)
                                    {
                                        //改变当前选择的场景ID
                                        nowSceneID = 2;

                                        //要退出 内层while循环
                                        isQuitWhile = true;
                                        
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }


                            if(isQuitWhile)
                            {
                                break;
                            }

                        }
                        #endregion
                        break;
                    
                    //游戏场景
                    case 2:
                        Console.Clear();
                        #region 游戏界面逻辑

                        #region 不变的红墙
                        Console.ForegroundColor = ConsoleColor.Red;
                        //画墙 横
                        for (int wall = 0; wall < w; wall += 2)
                        {
                            //上方墙
                            Console.SetCursorPosition(wall, 0);
                            Console.Write("■");

                            //下方墙
                            Console.SetCursorPosition(wall, h - 1);
                            Console.Write("■");

                            //中间墙
                            Console.SetCursorPosition(wall, h - 6);
                            Console.Write("■");
                        }

               
                        //竖墙
                        for (int wall = 0; wall < h - 1; wall++)
                        {
                            //左
                            Console.SetCursorPosition(0, wall);
                            Console.WriteLine("■");

                            //右边墙
                            Console.SetCursorPosition(w - 2, wall);
                            Console.WriteLine("■");
                        }
                        #endregion

                        #region boss属性相关
                        int bossX = w / 2 - 1;
                        int bossY = h / 2;

                        int bossAtkMin = 7;
                        int bossAtkMax = 13;

                        int bossHp = 100;

                        string bossIcon = "■";
                        //申明一个 颜色变量
                        ConsoleColor bossColor = ConsoleColor.Green;
                        #endregion

                        #region 主角属性
                        int linkX = 4;
                        int linkY = 2;

                        int linkAtkMin = 8;
                        int linkAtkMax = 12;

                        int linkHp = 100;

                        string linkIcon = "●";
                        ConsoleColor linkcolor = ConsoleColor.Yellow;

                        //玩家输入的内容 外面申明 节约性能
                        char player_input;

                        #endregion

                        #region 玩家战斗相关
                        //战斗状态
                        bool isFight = false;

                        //作用是 从while 循环内部的swich 改变标识 用来跳出外层的while循环
                        bool isOver = false;
                        #endregion

                        #region 公主相关
                        int princessX = 24;
                        int princessY = 5;
                        string princessIcon = "■";
                        ConsoleColor prioncessColor = ConsoleColor.Blue;
                        #endregion

                        //游戏场景的死循环 专门用来检测 玩家输入相关循环
                        while (true)
                        {
                            #region Boss绘制
                            if (bossHp > 0)
                            {
                                //绘制boss图标
                                Console.SetCursorPosition(bossX, bossY);
                                Console.ForegroundColor = bossColor;
                                Console.Write(bossIcon);
                            }
                            #endregion
                            else
                            {
                                #region 公主绘制
                                Console.SetCursorPosition(princessX, princessY);
                                Console.ForegroundColor = prioncessColor;
                                Console.Write(princessIcon);
                                #endregion
                            }

                            #region 主角绘制
                            //画出主角
                            Console.SetCursorPosition(linkX, linkY);
                            Console.ForegroundColor = linkcolor;
                            Console.Write(linkIcon);
                            #endregion

                            //得到玩家输入
                            player_input = Console.ReadKey(true).KeyChar;

                            //战斗状态处理申明逻辑
                            if (isFight)
                            {
                                //如果是战斗状态 做什么
                                if (player_input == 'J' || player_input == 'j')
                                {
                                    //在这判断 玩家或者boss 是否死亡 如果死亡了 继续之后的流程
                                    if (linkHp <= 0)
                                    {
                                        #region 玩家死亡后
                                        //游戏结束
                                        //输掉了 应该跳到结束页面
                                        nowSceneID = 3;
                                        gameOverInfo = "YOU DIED";
                                        break;
                                        #endregion

                                    }
                                    else if(bossHp <= 0)
                                    {
                                        #region boss 死亡后
                                        //营救公主
                                        //boss擦除
                                        Console.SetCursorPosition(bossX, bossY);
                                        Console.Write("  ");
                                        isFight = false;
                                        #endregion
                                    }
                                    else
                                    {
                                        #region 与boss战斗
                                        //处理按j键打架
                                        //玩家打怪物
                                        Random r = new Random();
                                        //得到随机攻击
                                        int atk = r.Next(linkAtkMin, linkAtkMax + 1);
                                        //血量减对应的攻击力
                                        bossHp -= atk;

                                        //打印信息
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        //先擦除这一行 上次显示的内容
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("                                       ");
                                        //再写新信息
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write($"Dealt {atk} damage; boss HP remaining {bossHp}.");

                                        //怪物打玩家
                                        if (bossHp > 0)
                                        {
                                            atk = r.Next(bossAtkMin, bossAtkMax + 1);
                                            linkHp -= atk;

                                            //打印信息
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            //先擦除这一行 上次显示的内容
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("                                       ");
                                            //boss把玩家打死了 做什么
                                            if (linkHp <= 0)
                                            {

                                                //再写新信息
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(2, h - 3);
                                                Console.Write($"Dead");
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, h - 3);
                                                Console.Write($"Dealt {atk} damage; Link HP remaining {linkHp}.");
                                            }
                                        }
                                        else
                                        {
                                            //擦除之前的战斗信息
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("                                           ");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("                                          ");
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("                                          ");

                                            //显示恭喜胜利的信息
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("Congratulations!");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("Press J to go to the princess.");
                                        }
                                        #endregion
                                    }

                                }
                            }
                            else
                            {
                                #region 移动逻辑
                                //擦除
                                Console.SetCursorPosition(linkX, linkY);
                                Console.Write("  ");

                                //改位置
                                switch (player_input)
                                {
                                    case 'W':
                                    case 'w':
                                        --linkY;

                                        if (linkY < 1)
                                        {
                                            linkY = 1;
                                        }
                                        //位置如果和boss重合了 并且boss没有死
                                        else if (linkX == bossX && linkY == bossY && bossHp > 0)
                                        {
                                            ++linkY;
                                        }
                                        else if (linkX == princessX && linkY == princessY && bossHp <= 0)
                                        {
                                            ++linkY;
                                        }
                                        break;
                                    case 'S':
                                    case 's':
                                        ++linkY;

                                        if (linkY > h - 7)
                                        {
                                            linkY = h - 7;
                                        }

                                        else if (linkX == bossX && linkY == bossY && bossHp > 0)
                                        {
                                            --linkY;
                                        }
                                        else if (linkX == princessX && linkY == princessY && bossHp <= 0)
                                        {
                                            --linkY;
                                        }
                                        break;
                                    case 'D':
                                    case 'd':
                                        linkX += 2;

                                        if (linkX > w - 4)
                                        {
                                            linkX = w - 4;
                                        }
                                        else if (linkX == bossX && linkY == bossY && bossHp > 0)
                                        {
                                            linkX -= 2;
                                        }
                                        else if (linkX == princessX && linkY == princessY && bossHp <= 0)
                                        {
                                            linkX -= 2;
                                        }
                                        break;
                                    case 'A':
                                    case 'a':
                                        linkX -= 2;

                                        if (linkX < 2)
                                        {
                                            linkX = 2;
                                        }
                                        else if (linkX == bossX && linkY == bossY && bossHp > 0)
                                        {
                                            linkX += 2;
                                        }
                                        else if (linkX == princessX && linkY == princessY && bossHp <= 0)
                                        {
                                            linkX += 2;
                                        }
                                        break;

                                    case 'J':
                                    case 'j':
                                        if ((linkX == bossX && linkY == bossY - 1 ||
                                        linkX == bossX && linkY == bossY + 1 ||
                                        linkX == bossX - 2 && linkY == bossY ||
                                        linkX == bossX + 2 && linkY == bossY) && bossHp > 0)
                                        {
                                            isFight = true;
                                            //可以开始战斗
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("battle with the boss, Press J continue.");

                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write($"Link's current HP is {linkHp}.");

                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write($"Boss's current HP is {bossHp}.");
                                        }
                                        //判断是否在公主身边
                                        else if ((linkX == princessX && linkY == princessY - 1 ||
                                        linkX == princessX && linkY == princessY + 1 ||
                                        linkX == princessX - 2 && linkY == princessY ||
                                        linkX == princessX + 2 && linkY == princessY) && bossHp <= 0)
                                        {
                                            //改变场景ID
                                            nowSceneID = 3;

                                            gameOverInfo = "YOU DID!";
                                            //跳出 游戏界面的while循环 回到主循环
                                            isOver = true;
                                            break;
                                        }
                                        break;
                                }
                                #endregion

                                #region 拯救公主后改变场景
                                //外层while循环逻辑
                                if (isOver)
                                {
                                    //配对的是while循环的break
                                    break;
                                }
                                #endregion

                            }


                        }
                        #endregion
                        break;


                    //结束界面
                    case 3:
                        Console.Clear();
                        #region 结束界面逻辑

                        //标题显示
                        Console.SetCursorPosition(w / 2 - 4, 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Game Over");

                        //可变内容显示 根据成功或失败显示的内容不一样
                        Console.SetCursorPosition(w / 2 - 4, 7);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(gameOverInfo);

                        int nowSelEndIndex = 0;
                        while (true)
                        {
                            bool isQuitEndWhile = false;

                            Console.SetCursorPosition(w / 2 - 7, 9);
                            Console.ForegroundColor = nowSelEndIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("Back to begin!");
                            Console.SetCursorPosition(w / 2 - 2, 11);
                            Console.ForegroundColor = nowSelEndIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("Exit");

                            char input = Console.ReadKey(true).KeyChar;

                            switch (input)
                            {
                                case 'W':
                                case 'w':
                                    --nowSelEndIndex;
                                    if (nowSelEndIndex < 0)
                                    {
                                        nowSelEndIndex = 1;
                                    }
                                    break;


                                case 'S':
                                case 's':
                                    ++nowSelEndIndex;
                                    if (nowSelEndIndex > 1)
                                    {
                                        nowSelEndIndex = 0;
                                    }
                                    break;

                                case 'J':
                                case 'j':
                                    if (nowSelEndIndex == 0)
                                    {
                                        nowSceneID = 1;
                                        isQuitEndWhile = true;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }

                                    break;
                            }
                            if (isQuitEndWhile)
                            {
                                break;
                            }

                        }
                        #endregion
                        break;
                }
            }

          
        }
    }
}