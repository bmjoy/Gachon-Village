﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SQL_Library;
namespace MainServer
{
    static partial class Function
    {
        public static void Init_Load()
        {
            MysqlNode node = new MysqlNode(private_data.mysqlOption, "SELECT * FROM npc");
            using (node.ExecuteReader())
            {
                while (node.Read())
                {
                    NPC npc = new NPC();
                    npc.skin = node.GetString("skin");
                    npc.name = node.GetString("name");
                    npc.position = new Vector4(node.GetFloat("x"), node.GetFloat("y"), node.GetFloat("z"), node.GetFloat("q"));

                    MysqlNode messagenode = new MysqlNode(private_data.mysqlOption, "SELECT * FROM npc_message WHERE npc_no=?no");
                    messagenode["no"] = node.GetInt("npc_no");
                    using (messagenode.ExecuteReader())
                    {
                        while (messagenode.Read())
                        {
                            npc.AddMessage(messagenode.GetString("message"));
                            Console.WriteLine("NPC " + npc.name + " 메세지 입력 -> " + messagenode.GetString("message"));
                        }
                    }
                    npc.Start();
                    Console.WriteLine("NPC " + npc.name + " 추가");
                }
            }
        }
    }
}
