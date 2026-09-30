namespace project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 游戏画面搭建
            //光标隐藏
            Console.CursorVisible = false;

            //设置游戏画面的宽度和高度
            int game_width = 70;
            int game_height = 50;

            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(game_width, game_height);

                Console.SetBufferSize(game_width, game_height);
            }

            #endregion


            //角色属性
            int yafan_hp = 100;
            int yafan_basis_atk = 6;
            int sword_wood_atkmin = 2;
            int sword_wood_atkmax = 4;

            int yafan_basis_def = 3;

            int playerX = 0;
            int playerY = 1;

            #region 骑士之剑属性
            string sword_knight = "▲";
            int sword_knight_atkmin = 7;
            int sword_knight_atkmiax = 11;

            bool have_sword_knight = false;
            #endregion



            int game_index = 1;
            int option_start = 0;

            while (true)
            {

                bool is_end_while = false;
                switch (game_index)
                {
                    case 1:
                        #region 开始页面搭建
                        Console.Clear();
                        //设置标题
                        Console.SetCursorPosition(game_width / 2 - 8, 10);
                        Console.Write("Sword of the Hero");

                        while(true)
                        {
                            //设置副标题
                            Console.SetCursorPosition(game_width / 2 - 5, 14);
                            Console.ForegroundColor = option_start == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("Start Game");

                            Console.SetCursorPosition(game_width / 2 - 2, 16);
                            Console.ForegroundColor = option_start == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("Exit");

                            char player_input = Console.ReadKey(true).KeyChar;

                            switch (player_input)
                            {
                                case 'W':
                                case 'w':
                                    --option_start;
                                    if (option_start < 0)
                                    {
                                        option_start = 1;
                                    }
                                    break;

                                case 'S':
                                case 's':
                                    ++option_start;
                                    if (option_start > 1)
                                    {
                                        option_start = 0;
                                    }
                                    break;

                                case 'J':
                                case 'j':
                                    if (option_start == 0)
                                    {
                                        game_index = 2;
                                        is_end_while = true;

                                        yafan_hp = 100;
                                        have_sword_knight = false;

                                        playerX = 0;
                                        playerY = 1;
                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (is_end_while)
                            {
                                break;
                            }
                       
                        }
                        #endregion
                        break;

                    case 2:
                        Console.Clear();

                        int gateX = 38;
                        int gateY = 39;

                        #region 绘制地图
                        #region 四周森林
                        //搭建迷宫森林
                        ConsoleColor gate_color = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int map = 0; map < game_width; map += 2)
                        {
                            //上方范围
                            Console.SetCursorPosition(map, 0);
                            Console.Write("■");

                            //下方范围
                            Console.SetCursorPosition(map, game_height - 1);
                            Console.Write("■");

                            //文本框范围
                            Console.SetCursorPosition(map, game_height - 6);
                            Console.Write("■");
                        }

                        for (int map = 0; map < game_height; map++)
                        {
                            if (map == 1)
                            {
                                //森林入口
                                Console.SetCursorPosition(0, map);
                                Console.Write("  ");
                            }
                            else
                            {
                                //左侧墙
                                Console.SetCursorPosition(0, map);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("■");
                            }

                            
                            if (map == gateX || map == gateY)
                            {
                                Console.SetCursorPosition(game_width - 2, map);
                                Console.ForegroundColor = gate_color;
                                Console.Write("■");
                            }
                            else
                            {
                                Console.SetCursorPosition(game_width - 2, map);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("■");
                            }
                        }
                        #endregion

                        #region 左侧树遮挡
                        for (int map = 1; map < game_height - 6; map++)
                        {
                            if (map == 1 || map == 2 || map == 3)
                            {
                                Console.SetCursorPosition(16, map);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("■");
                            }
                            else if (map == 23 || map == 24 || map == 25)
                            {
                                Console.SetCursorPosition(8, map);
                                Console.Write("  ");
                            }
                            else
                            {
                                Console.SetCursorPosition(8, map);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("■");

                            }
                          
                        }

                        for (int map = 10; map < game_width - 52; map += 2)
                        {
                            Console.SetCursorPosition(map, 4);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }
                        #endregion

                        #region 中央闸道
                        for (int map = 10; map < game_width - 22; map += 2)
                        {
                            Console.SetCursorPosition(map, 22);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");

                            Console.SetCursorPosition(map, 26);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }

                        #endregion

                        #region 右侧上方侧道
                        for (int map = 8; map <= game_height - 29; map++)
                        {
                            Console.SetCursorPosition(46, map);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }

                        #endregion



                        #region 右侧下方侧道
                        for (int map = 26; map <= game_height - 8; map++)
                        {
                            Console.SetCursorPosition(46, map);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }

                        #endregion

                        #region 右侧上下外侧横道
                        for (int map = 46; map <= game_width - 4; map += 2)
                        {
                            Console.SetCursorPosition(map, 8);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");

                            Console.SetCursorPosition(map, 42);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }

                        #endregion


                        #region 右侧上下内侧横道
                        for (int map = 54; map <= game_width - 4; map += 2)
                        {
                            Console.SetCursorPosition(map, 14);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");

                            Console.SetCursorPosition(map, 35);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }

                        #endregion


                        #region 右侧竖闸道
                        for (int map = 15; map <= game_height - 15; map++)
                        {
                            Console.SetCursorPosition(game_width - 16, map);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }

                        #endregion
                        #endregion



                        #region 怪物属性
                        //怪物属性

                        //第一只怪物
                        int first_monster_hp = 15;
                        int first_monster_atkmin = 3;
                        int first_monster_atkmax = 7;

                        //第一只怪物位置
                        int first_monsterX = 4;
                        int first_monsterY = 41;


                        //第二只
                        int second_monster_hp = 25;
                        int second_monster_atkmin = 4;
                        int second_monster_atkmax = 8;
                        //第二只怪物位置
                        int second_monsterX = game_width - 10;
                        int second_monsterY = 11;


                        //第三只
                        int third_monster_hp = 40;
                        int third_monster_atkmin = 10;
                        int third_monster_atkmax = 14;
                        //第三只怪物位置
                        int third_monsterX = game_width - 20;
                        int third_monsterY = 39;


                        #endregion

                        #region 战斗状态
                        int monster_fight = 0;

                        bool is_gate_open = false;
                        #endregion

                        int damage;

                        //角色移动
                        while (true)
                        {

                            Console.SetCursorPosition(playerX, playerY);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("●");

                            char player_input = Console.ReadKey(true).KeyChar;

                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write("  ");

                            //如果怪物血量大于0就会显示在地图上，如果小于或等于0就会被擦除
                            if (first_monster_hp > 0)
                            {
                                Console.SetCursorPosition(first_monsterX, first_monsterY);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▲");
                            }
                            else
                            {
                                Console.SetCursorPosition(first_monsterX, first_monsterY);
                                Console.Write("  ");
                            }

                            if (first_monster_hp <= 0 && second_monster_hp > 0)
                            {
                                Console.SetCursorPosition(second_monsterX, second_monsterY);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▲");
                            }
                            else
                            {
                                Console.SetCursorPosition(second_monsterX, second_monsterY);
                                Console.Write("  ");

                            }

                            if (first_monster_hp <= 0 && second_monster_hp <= 0 && third_monster_hp > 0)
                            {
                                Console.SetCursorPosition(third_monsterX, third_monsterY);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("▲");
                            }
                            else
                            {
                                Console.SetCursorPosition(game_width - 20, 39);
                                Console.Write("  ");
                            }

                            if(second_monster_hp <= 0 && have_sword_knight == false)
                            {
                                Console.SetCursorPosition(second_monsterX + 2, second_monsterY);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(sword_knight);

                            }
                            else
                            {
                                Console.SetCursorPosition(second_monsterX + 2, second_monsterY);
                                Console.Write("  ");
                            }

                            if (first_monster_hp <= 0 && second_monster_hp <= 0 && third_monster_hp <= 0)
                            {
                                is_gate_open = true;

                                for (int map = 0; map < game_height; map++)
                                {
                                    if (map == gateX || map == gateY)
                                    {
                                        Console.SetCursorPosition(game_width - 2, map);
                                        Console.Write("  ");
                                    }
                                }
                            }

                            if (is_gate_open)
                            {
                                if ((playerX == game_width - 4 && playerY == 38) || (playerX == game_width - 4 && playerY == 39))
                                {
                                    game_index = 3;
                                    break;

                                }
                            }

                            if (monster_fight == 1)
                            {
                                if (player_input == 'J' || player_input == 'j')
                                {
                                    if (yafan_hp <= 0)
                                    {
                                        game_index = 3;
                                        break;
                                    }
                                    else
                                    {
                                        //战斗
                                        Random r = new Random();

                                        int next_wood_sword_atk = r.Next(sword_wood_atkmin, sword_wood_atkmax + 1);
                                        int next_sword_knight_atk = r.Next(sword_knight_atkmin, sword_knight_atkmiax + 1);
                                        int next_atk;

                                        if (have_sword_knight)
                                        {
                                            next_atk = yafan_basis_atk + next_sword_knight_atk;
                                        }
                                        else
                                        {
                                            next_atk = yafan_basis_atk + next_wood_sword_atk;
                                        }

                                        first_monster_hp -= next_atk;

                                        //打印信息
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        //先擦除这一行 上次显示的内容
                                        Console.SetCursorPosition(2, game_height - 5);
                                        Console.Write("                                            ");
                                        //再写新信息
                                        Console.SetCursorPosition(2, game_height - 5);


                                        Console.Write($"Dealt {next_atk} damage; monster HP remaining {first_monster_hp}.");




                                        //怪物打玩家
                                        if (first_monster_hp > 0)
                                        {
                                            int first_monster_atk = r.Next(first_monster_atkmin, first_monster_atkmax + 1);
                                            damage = first_monster_atk - yafan_basis_def;
                                            if (first_monster_atk < yafan_basis_def)
                                            {
                                                damage = 0;
                                            }
                                            yafan_hp -= damage;

                                            //打印信息
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            //先擦除这一行 上次显示的内容
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                                        ");
                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write("                                         ");
                                            Console.SetCursorPosition(2, game_height - 2);
                                            Console.Write("                                          ");
                                            //monster把玩家打死了 做什么
                                            if (yafan_hp <= 0)
                                            {

                                                //再写新信息
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dead");
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dealt {damage} damage; Yafan HP remaining {yafan_hp}.");
                                            }
                                        }
                                        else
                                        {
                                            //擦除之前的战斗信息
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("                                                  ");
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                                                  ");
                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write("                                                  ");

                                            //显示恭喜胜利的信息
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("Go to next monster");
                                            monster_fight = 0;

                                        }


                                    }

                                }
                            }
                            else if (monster_fight == 2)
                            {
                                if (player_input == 'J' || player_input == 'j')
                                {
                                    if (yafan_hp <= 0)
                                    {
                                        game_index = 3;
                                        break;
                                    }
                                    else
                                    {
                                        //战斗
                                        Random r = new Random();

                                        int next_wood_sword_atk = r.Next(sword_wood_atkmin, sword_wood_atkmax + 1);
                                        int next_sword_knight_atk = r.Next(sword_knight_atkmin, sword_knight_atkmiax + 1);
                                        int next_atk;

                                        if (have_sword_knight)
                                        {
                                            next_atk = yafan_basis_atk + next_sword_knight_atk;
                                        }
                                        else
                                        {
                                            next_atk = yafan_basis_atk + next_wood_sword_atk;
                                        }

                                        second_monster_hp -= next_atk;

                                        //打印信息
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        //先擦除这一行 上次显示的内容
                                        Console.SetCursorPosition(2, game_height - 5);
                                        Console.Write("                                  ");
                                        //再写新信息
                                        Console.SetCursorPosition(2, game_height - 5);


                                        Console.Write($"Dealt {next_atk} damage; monster HP remaining {second_monster_hp}.");




                                        //怪物打玩家
                                        if (second_monster_hp > 0)
                                        {
                                            int second_monster_atk = r.Next(second_monster_atkmin, second_monster_atkmax + 1);
                                            damage = second_monster_atk - yafan_basis_def;
                                            if (second_monster_atk < yafan_basis_def)
                                            {
                                                damage = 0;
                                            }
                                            yafan_hp -= damage;

                                            //打印信息
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            //先擦除这一行 上次显示的内容
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                                  ");
                                            //monster把玩家打死了 做什么
                                            if (yafan_hp <= 0)
                                            {

                                                //再写新信息
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dead");
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dealt {damage} damage; Yafan HP remaining {yafan_hp}.");
                                            }
                                        }
                                        else
                                        {
                                            //擦除之前的战斗信息
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("                                           ");
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                                           ");
                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write("                                           ");

                                            //显示恭喜胜利的信息
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("Congratulations!");
                                            monster_fight = 0;


                                        }


                                    }

                                }
                            }

                            else if (monster_fight == 3)
                            {
                                if (player_input == 'J' || player_input == 'j')
                                {
                                    if (yafan_hp <= 0)
                                    {
                                        game_index = 3;
                                        break;
                                    }
                                    else
                                    {
                                        //战斗
                                        Random r = new Random();

                                        int next_wood_sword_atk = r.Next(sword_wood_atkmin, sword_wood_atkmax + 1);
                                        int next_sword_knight_atk = r.Next(sword_knight_atkmin, sword_knight_atkmiax + 1);
                                        int next_atk;

                                        if (have_sword_knight)
                                        {
                                            next_atk = yafan_basis_atk + next_sword_knight_atk;
                                        }
                                        else
                                        {
                                            next_atk = yafan_basis_atk + next_wood_sword_atk;
                                        }

                                        third_monster_hp -= next_atk;

                                        //打印信息
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        //先擦除这一行 上次显示的内容
                                        Console.SetCursorPosition(2, game_height - 5);
                                        Console.Write("                               ");
                                        //再写新信息
                                        Console.SetCursorPosition(2, game_height - 5);


                                        Console.Write($"Dealt {next_atk} damage; monster HP remaining {third_monster_hp}.");




                                        //怪物打玩家
                                        if (third_monster_hp > 0)
                                        {
                                            int third_monster_atk = r.Next(third_monster_atkmin, third_monster_atkmax + 1);
                                            damage = third_monster_atk - yafan_basis_def;
                                            if (third_monster_atk < yafan_basis_def)
                                            {
                                                damage = 0;
                                            }
                                            yafan_hp -= damage;

                                            //打印信息
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            //先擦除这一行 上次显示的内容
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                             ");
                                            //monster把玩家打死了 做什么
                                            if (yafan_hp <= 0)
                                            {

                                                //再写新信息
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dead");
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dealt {damage} damage; Yafan HP remaining {yafan_hp}.");
                                            }
                                        }
                                        else
                                        {
                                            //擦除之前的战斗信息
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("                                              ");
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                                               ");
                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write("                                               ");

                                            //显示恭喜胜利的信息
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("Congratulations!");
                                            monster_fight = 0;
                                        }


                                    }

                                }
                            }
                            else if (monster_fight == 4)
                            {
                                have_sword_knight = true;

                                Console.SetCursorPosition(2, game_height - 5);
                                Console.Write("                                              ");
                                monster_fight = 0;
                            }

                            else
                            {
                                #region 左上部分移动
                                if (playerY <= 4 && playerX <= 16)
                                {
                                    switch (player_input)
                                    {
                                        case 'W':
                                        case 'w':
                                            --playerY;
                                            if (playerY < 1)
                                            {
                                                playerY = 1;
                                            }

                                            break;

                                        case 'S':
                                        case 's':
                                            ++playerY;
                                            if (playerX == 0 && playerY > 1)
                                            {
                                                playerY = 1;
                                            }
                                            else if (playerX >= 8 && playerY > 3)
                                            {
                                                playerY = 3;
                                            }

                                            break;

                                        case 'A':
                                        case 'a':
                                            playerX -= 2;
                                            if (playerY <= 1 && playerX < 2)
                                            {
                                                playerX = 0;
                                            }
                                            else if (playerX < 2)
                                            {
                                                playerX = 2;
                                            }

                                            break;

                                        case 'D':
                                        case 'd':
                                            playerX += 2;
                                            if (playerX > 14)
                                            {
                                                playerX = 14;
                                            }
                                            else if (playerY == 4 && playerX > 6)
                                            {
                                                playerX = 6;
                                            }

                                            break;

                                        case 'J':
                                        case 'j':
                                            break;
                                    }
                                }
                                #endregion

                                #region 左下部分移动
                                else if (playerY > 4 && playerY <= game_height - 6 && playerX < 8)
                                {
                                    switch (player_input)
                                    {
                                        case 'W':
                                        case 'w':
                                            --playerY;

                                            if (playerY == first_monsterY && playerX == first_monsterX && first_monster_hp > 0)
                                            {
                                                ++playerY;
                                            }

                                            break;

                                        case 'S':
                                        case 's':
                                            ++playerY;
                                            if (playerY > game_height - 7)
                                            {
                                                playerY = game_height - 7;
                                            }
                                            else if (playerY == first_monsterY && playerX == first_monsterX && first_monster_hp > 0)
                                            {
                                                --playerY;
                                            }

                                            break;

                                        case 'A':
                                        case 'a':
                                            playerX -= 2;
                                            if (playerX < 2)
                                            {
                                                playerX = 2;
                                            }
                                            else if (playerY == first_monsterY && playerX == first_monsterX && first_monster_hp > 0)
                                            {
                                                playerX += 2;
                                            }
                                            break;

                                        case 'D':
                                        case 'd':
                                            playerX += 2;
                                            if (playerX > 6 && (playerY < 23 || playerY > 25))
                                            {
                                                playerX = 6;
                                            }
                                            else if (playerY == first_monsterY && playerX == first_monsterX && first_monster_hp > 0)
                                            {
                                                playerX -= 2;
                                            }

                                            break;

                                        case 'J':
                                        case 'j':
                                            if ((playerX == first_monsterX - 2 ||
                                                playerX == first_monsterX + 2 ||
                                                playerY == first_monsterY - 1 ||
                                                playerY == first_monsterY + 1) && first_monster_hp > 0)
                                            {
                                                monster_fight = 1;
                                                have_sword_knight = false;
                                                //可以开始战斗
                                                Console.SetCursorPosition(2, game_height - 5);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write("battle with monster, Press J continue.");

                                                Console.SetCursorPosition(2, game_height - 4);
                                                Console.Write($"Yafan's current HP is {yafan_hp}.");

                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Monster's current HP is {first_monster_hp}.");
                                            }

                                            break;
                                    }
                                }
                                #endregion

                                #region 中间闸道
                                else if (playerY >= 23 && playerY <= 26 && playerX >= 8 && playerX < game_width - 22)
                                {
                                    switch (player_input)
                                    {
                                        case 'W':
                                        case 'w':
                                            --playerY;
                                            if (playerY < 23)
                                            {
                                                playerY = 23;

                                            }
                                            break;

                                        case 'S':
                                        case 's':
                                            ++playerY;
                                            if (playerY > 25)
                                            {
                                                playerY = 25;
                                            }

                                            break;

                                        case 'A':
                                        case 'a':
                                            playerX -= 2;

                                            break;

                                        case 'D':
                                        case 'd':
                                            playerX += 2;

                                            break;

                                        case 'J':
                                        case 'j':
                                            break;
                                    }
                                }
                                #endregion

                                #region 右侧垂直通道
                                else if (playerY > 8 && playerY < 44 && playerX >= game_width - 22 && playerX < game_width - 16)
                                {
                                    switch (player_input)
                                    {
                                        case 'W':
                                        case 'w':
                                            --playerY;
                                            if (playerY < 9)
                                            {
                                                playerY = 9;
                                            }
                                            else if (playerY == third_monsterY && playerX == third_monsterX && third_monster_hp > 0)
                                            {
                                                ++playerY;
                                            }
                                            break;

                                        case 'S':
                                        case 's':
                                            ++playerY;
                                            if (playerY > 41)
                                            {
                                                playerY = 41;
                                            }
                                            else if (playerY == third_monsterY && playerX == third_monsterX && third_monster_hp > 0)
                                            {
                                                --playerY;
                                            }
                                            break;

                                        case 'A':
                                        case 'a':
                                            playerX -= 2;

                                            if (playerX < game_width - 22 && (playerY < 23 || playerY > 25))
                                            {
                                                playerX = game_width - 22;
                                            }
                                            else if (playerY == third_monsterY && playerX == third_monsterX && third_monster_hp > 0)
                                            {
                                                playerX += 2;
                                            }

                                            break;

                                        case 'D':
                                        case 'd':
                                            playerX += 2;

                                            if (playerY > 13 && playerY < 37)
                                            {
                                                if (playerX > game_width - 18)
                                                {
                                                    playerX = game_width - 18;
                                                }
                                            }
                                            else if (playerY == third_monsterY && playerX == third_monsterX && third_monster_hp > 0)
                                            {
                                                playerX -= 2;
                                            }

                                            break;

                                        case 'J':
                                        case 'j':
                                            if ((playerX == third_monsterX - 2 ||
                                                playerX == third_monsterX + 2 ||
                                                playerY == third_monsterY - 1 ||
                                                playerY == third_monsterY + 1) && third_monster_hp > 0)
                                            {
                                                monster_fight = 3;
                                                //可以开始战斗

                                                Console.SetCursorPosition(2, game_height - 5);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write("battle with monster, Press J continue");

                                                Console.SetCursorPosition(2, game_height - 4);
                                                Console.Write($"Yafan's current HP is {yafan_hp}.");

                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Monster's current HP is {third_monster_hp}.");
                                            }
                                            break;
                                    }
                                }

                                #endregion


                                #region 右侧上方通道
                                else if (playerY > 8 && playerY < 15 && playerX >= game_width - 16)
                                {
                                    switch (player_input)
                                    {
                                        case 'W':
                                        case 'w':
                                            --playerY;
                                            if (playerY < 9)
                                            {
                                                playerY = 9;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX && second_monster_hp > 0)
                                            {
                                                ++playerY;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX + 2 && second_monster_hp < 0)
                                            {
                                                ++playerY;
                                            }
                                            break;

                                        case 'S':
                                        case 's':
                                            ++playerY;
                                            if (playerY > 13)
                                            {
                                                playerY = 13;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX && second_monster_hp > 0)
                                            {
                                                --playerY;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX + 2 && second_monster_hp < 0)
                                            {
                                                --playerY;
                                            }
                                            break;

                                        case 'A':
                                        case 'a':
                                            playerX -= 2;

                                            if (playerY == second_monsterY && playerX == second_monsterX && second_monster_hp > 0)
                                            {
                                                playerX += 2;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX + 2 && second_monster_hp < 0)
                                            {
                                                playerX += 2;
                                            }
                                            break;

                                        case 'D':
                                        case 'd':
                                            playerX += 2;

                                            if (playerX > game_width - 4)
                                            {
                                                playerX = game_width - 4;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX && second_monster_hp > 0)
                                            {
                                                playerX -= 2;
                                            }
                                            else if (playerY == second_monsterY && playerX == second_monsterX + 2 && second_monster_hp < 0)
                                            {
                                                playerX -= 2;
                                            }

                                            break;

                                        case 'J':
                                        case 'j':
                                            if ((playerX == second_monsterX - 2 ||
                                                playerX == second_monsterX + 2 ||
                                                playerY == second_monsterY - 1 ||
                                                playerY == second_monsterY + 1) && second_monster_hp > 0)
                                            {
                                                monster_fight = 2;
                                                //可以开始战斗
                                                Console.SetCursorPosition(2, game_height - 5);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write("battle with monster, Press J continue.");

                                                Console.SetCursorPosition(2, game_height - 4);
                                                Console.Write($"Yafan's current HP is {yafan_hp}.");

                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Monster's current HP is {second_monster_hp}.");
                                            }

                                            if ((playerX == (second_monsterX + 2) - 2 ||
                                                playerX == (second_monsterX + 2) + 2 ||
                                                playerY == second_monsterY - 1 ||
                                                playerY == second_monsterY + 1) && second_monster_hp < 0)
                                            {
                                                monster_fight = 4;
                                                Console.SetCursorPosition(2, game_height - 5);
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.Write("Obtain the Knight's Sword");
                                            }
                                            break;
                                    }
                                }

                                #endregion

                                #region 右侧下方通道
                                else if (playerY > 35 && playerY < 44 && playerX >= game_width - 16)
                                {
                                    switch (player_input)
                                    {
                                        case 'W':
                                        case 'w':
                                            --playerY;
                                            if (playerY < 36)
                                            {
                                                playerY = 36;
                                            }
                                            break;

                                        case 'S':
                                        case 's':
                                            ++playerY;
                                            if (playerY > 41)
                                            {
                                                playerY = 41;
                                            }
                                            break;

                                        case 'A':
                                        case 'a':
                                            playerX -= 2;

                                            break;

                                        case 'D':
                                        case 'd':
                                            playerX += 2;

                                            if (playerX > game_width - 4)
                                            {
                                                playerX = game_width - 4;
                                            }
                                            else if (is_gate_open)
                                            {
                                                if (playerX > game_width - 2)
                                                {
                                                    playerX = game_width - 2;
                                                }
                                            }

                                            break;

                                        case 'J':
                                        case 'j':
                                            break;
                                    }
                                }

                                #endregion
                            }





                        }

                        break;

                    case 3:
                        Console.Clear();

                        #region 地图
                        gateX = 38;
                         gateY = 39;

                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int map = 0; map < game_width; map += 2)
                        {
                            //上方范围
                            Console.SetCursorPosition(map, 0);
                            Console.Write("■");

                            //下方范围
                            Console.SetCursorPosition(map, game_height - 1);
                            Console.Write("■");

                            //文本框范围
                            Console.SetCursorPosition(map, game_height - 6);
                            Console.Write("■");
                        }

                        for (int map = 0; map < game_height; map++)
                        {
                            
                            //左侧墙
                            Console.SetCursorPosition(game_width - 2, map);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("■");

                            if (map == gateX || map == gateY)
                            {
                                Console.SetCursorPosition(0, map);
                                Console.Write("  ");
                            }
                            else
                            {
                                Console.SetCursorPosition(0, map);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("■");
                            }
                        }
                        #endregion

                        playerX = 0;
                        playerY = 38;

                        #region boss属性
                        int boss_hp = 100;
                        int boss_atkmin = 10;
                        int boss_atkmax = 13;

                        int bossX = game_width / 2 - 1;
                        int bossY = 15;

                        string bossIcon = "■";
                        //申明一个 颜色变量
                        ConsoleColor bossColor = ConsoleColor.Red;

                        #endregion

                        bool isFight = false;

                        //作用是 从while 循环内部的swich 改变标识 用来跳出外层的while循环
                        bool isOver = false;

                        #region 勇者之剑
                        int swordX = game_width / 2 - 1;
                        int swordY = 10;

                        string swordIcon = "▲";
                        ConsoleColor swordColor = ConsoleColor.Green;


                        #endregion

                        while (true)
                        {
                            #region Boss绘制
                            if (boss_hp > 0)
                            {
                                //绘制boss图标
                                Console.SetCursorPosition(bossX, bossY);
                                Console.ForegroundColor = bossColor;
                                Console.Write(bossIcon);
                            }
                            #endregion
                            else
                            {
                                #region 
                                Console.SetCursorPosition(swordX, swordY);
                                Console.ForegroundColor = swordColor;
                                Console.Write(swordIcon);
                                #endregion
                            }

                            #region 主角绘制
                            //画出主角
                            Console.SetCursorPosition(playerX, playerY);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("●");

                            char player_input = Console.ReadKey(true).KeyChar;

                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write("  ");
                            #endregion

                            //得到玩家输入
                            
                            //战斗状态处理申明逻辑
                            if (isFight)
                            {
                                //如果是战斗状态 做什么
                                if (player_input == 'J' || player_input == 'j')
                                {
                                    //在这判断 玩家或者boss 是否死亡 如果死亡了 继续之后的流程
                                    if (yafan_hp <= 0)
                                    {
                                        #region 玩家死亡后
                                        //游戏结束
                                        //输掉了 应该跳到结束页面
                                        game_index = 4;
                                        break;
                                        #endregion

                                    }
                                    else if (boss_hp <= 0)
                                    {
                                        #region boss 死亡后
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
                                        int next_wood_sword_atk = r.Next(sword_wood_atkmin, sword_wood_atkmax + 1);
                                        int next_sword_knight_atk = r.Next(sword_knight_atkmin, sword_knight_atkmiax + 1);
                                        int next_atk;

                                        if (have_sword_knight)
                                        {
                                            next_atk = yafan_basis_atk + next_sword_knight_atk;
                                        }
                                        else
                                        {
                                            next_atk = yafan_basis_atk + next_wood_sword_atk;
                                        }

                                        boss_hp -= next_atk;

                                        //打印信息
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        //先擦除这一行 上次显示的内容
                                        Console.SetCursorPosition(2, game_height - 4);
                                        Console.Write("                                       ");
                                        //再写新信息
                                        Console.SetCursorPosition(2, game_height - 4);
                                        Console.Write($"Dealt {next_atk} damage; boss HP remaining {boss_hp}.");

                                        //怪物打玩家
                                        if (boss_hp > 0)
                                        {
                                            next_atk = r.Next(boss_atkmin, boss_atkmax + 1);
                                            yafan_hp -= next_atk;

                                            //打印信息
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            //先擦除这一行 上次显示的内容
                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write("                                       ");
                                            //boss把玩家打死了 做什么
                                            if (yafan_hp <= 0)
                                            {

                                                //再写新信息
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Died");
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, game_height - 3);
                                                Console.Write($"Dealt {next_atk} damage; Yafan HP remaining {yafan_hp}.");
                                            }
                                        }
                                        else
                                        {
                                            //擦除之前的战斗信息
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("                                           ");
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("                                          ");
                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write("                                          ");

                                            //显示恭喜胜利的信息
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.Write("Congratulations!");
                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write("Press J to obtain the Hero's Sword.");
                                        }
                                        #endregion
                                    }

                                }
                            }
                            else
                            {
                                
                                //擦除
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("  ");

                                //改位置
                                switch (player_input)
                                {
                                    case 'W':
                                    case 'w':
                                        --playerY;

                                        if (playerY < 1)
                                        {
                                            playerY = 1;
                                        }
                                        //位置如果和boss重合了 并且boss没有死
                                        else if (playerX == bossX && playerY == bossY && boss_hp > 0)
                                        {
                                            ++playerY;
                                        }
                                        else if (playerX == swordX && playerY == swordY && boss_hp <= 0)
                                        {
                                            ++playerY;
                                        }
                                        break;
                                    case 'S':
                                    case 's':
                                        ++playerY;

                                        if (playerY > game_height - 7)
                                        {
                                            playerY = game_height - 7;
                                        }

                                        else if (playerX == bossX && playerY == bossY && boss_hp > 0)
                                        {
                                            --playerY;
                                        }
                                        else if (playerX == swordX && playerY == swordY && boss_hp <= 0)
                                        {
                                            --playerY;
                                        }
                                        break;
                                    case 'D':
                                    case 'd':
                                        playerX += 2;

                                        if (playerX > game_width - 4)
                                        {
                                            playerX = game_width - 4;
                                        }
                                        else if (playerX == bossX && playerY == bossY && boss_hp > 0)
                                        {
                                            playerX -= 2;
                                        }
                                        else if (playerX == swordX && playerY == swordY && boss_hp <= 0)
                                        {
                                            playerX -= 2;
                                        }
                                        break;
                                    case 'A':
                                    case 'a':
                                        playerX -= 2;

                                        if (playerX < 2)
                                        {
                                            playerX = 2;
                                        }
                                        else if (playerX == bossX && playerY == bossY && boss_hp > 0)
                                        {
                                            playerX += 2;
                                        }
                                        else if (playerX == swordX && playerY == swordY && boss_hp <= 0)
                                        {
                                            playerX += 2;
                                        }
                                        break;

                                    case 'J':
                                    case 'j':
                                        if ((playerX == bossX && playerY == bossY - 1 ||
                                        playerX == bossX && playerY == bossY + 1 ||
                                        playerX == bossX - 2 && playerY == bossY ||
                                        playerX == bossX + 2 && playerY == bossY) && boss_hp > 0)
                                        {
                                            isFight = true;
                                            //可以开始战斗
                                            Console.SetCursorPosition(2, game_height - 5);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("battle with the boss, Press J continue.");

                                            Console.SetCursorPosition(2, game_height - 4);
                                            Console.Write($"Fanya's current HP is {yafan_hp}.");

                                            Console.SetCursorPosition(2, game_height - 3);
                                            Console.Write($"Boss's current HP is {boss_hp}.");
                                        }
                                        //判断是否在勇者之剑身边
                                        else if ((playerX == (bossX + 2) - 2 ||
                                                playerX == (bossX + 2) + 2 ||
                                                playerY == bossY - 1 ||
                                                playerY == bossY + 1) && boss_hp <= 0)
                                        {
                                            //改变场景ID
                                            game_index = 4;

                                            //跳出 游戏界面的while循环 回到主循环
                                            isOver = true;
                                            break;
                                        }
                                        break;
                                }
                                //外层while循环逻辑
                                if (isOver)
                                {
                                    //配对的是while循环的break
                                    break;
                                }
                            }


                        }
                    break;

                    case 4:
                        Console.Clear();

                        //标题显示
                        Console.SetCursorPosition(game_width / 2 - 4, 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Game Over");

                        //可变内容显示 根据成功或失败显示的内容不一样
                        Console.SetCursorPosition(game_width / 2 - 4, 7);
                        Console.ForegroundColor = ConsoleColor.Green;

                        int nowSelEndIndex = 0;
                        while (true)
                        {
                            bool isQuitEndWhile = false;

                            Console.SetCursorPosition(game_width / 2 - 7, 9);
                            Console.ForegroundColor = nowSelEndIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("Back to begin!");
                            Console.SetCursorPosition(game_width / 2 - 2, 11);
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
                                        game_index = 1;
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
                        break;
                }
            }
        }
    }
}