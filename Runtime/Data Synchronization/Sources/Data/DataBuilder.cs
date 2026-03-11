/// -------------------------------------------------------------------------------
/// Copyright (C) 2024 - 2025, Hurley, Independent Studio.
/// Copyright (C) 2025 - 2026, Hainan Yuanyou Information Technology Co., Ltd. Guangzhou Branch
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// -------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;

namespace GameFramework.Sample.DataSynchronization
{
    /// <summary>
    /// 数据构造器对象类
    /// </summary>
    static class DataBuilder
    {
        static int _internalSequenceId = 10000;
        static readonly string[] PlayerNames =
        {
            "憨憨的胖头鱼", "忧郁的鮟鱇鱼", "腹黑的胖大橘", "害羞的灰刺猬", "暴躁的红鹦鹉",
            "梦幻的蓝灯笼", "智慧的萤火虫", "沉默的白企鹅", "焦虑的哈士奇", "开朗的猪鼻蛇",
        };
        static readonly string[] MonsterNames =
        {
            "爱因斯坦", "帕杰罗", "特斯拉", "达尔文", "亚历山大", "门捷列夫‌", "伽利略", "哥白尼‌", "达芬奇", "阿基米德",
        };

        public static Player CreatePlayer()
        {
            Player player = GameEngine.GameApi.CreateActor<Player>();
            player.uid = GenId();

            IdentityComponent identityComponent = player.GetComponent<IdentityComponent>();
            identityComponent.objectType = 11;
            identityComponent.objectName = GetRandomPlayerName();

            AttributeComponent attributeComponent = player.GetComponent<AttributeComponent>();
            attributeComponent.level = NovaEngine.Utility.Random.Next(100);
            attributeComponent.exp = NovaEngine.Utility.Random.Next(100 * attributeComponent.level);
            attributeComponent.health = 10 * attributeComponent.level;
            attributeComponent.energy = 5 * attributeComponent.level;
            attributeComponent.attack = 2 * attributeComponent.level;

            TransformComponent transformComponent = player.GetComponent<TransformComponent>();
            transformComponent.position = new UnityEngine.Vector3(NovaEngine.Utility.Random.Next(10), 0, NovaEngine.Utility.Random.Next(10));
            transformComponent.rotation = new UnityEngine.Vector3(0, 1, 0);

            SkillComponent skillComponent = player.GetComponent<SkillComponent>();
            skillComponent.skills = new List<SkillComponent.SkillInfo>();
            if (attributeComponent.level >= 5) skillComponent.skills.Add(new SkillComponent.SkillInfo() { id = 1001, name = "基础剑法", range = 1, cooling_time = 0, });
            if (attributeComponent.level >= 15) skillComponent.skills.Add(new SkillComponent.SkillInfo() { id = 1002, name = "刺杀剑法", range = 2, cooling_time = 0, });
            if (attributeComponent.level >= 30) skillComponent.skills.Add(new SkillComponent.SkillInfo() { id = 1003, name = "半月剑法", range = 3, cooling_time = 0, });
            if (attributeComponent.level >= 60) skillComponent.skills.Add(new SkillComponent.SkillInfo() { id = 1004, name = "烈火剑法", range = 1, cooling_time = 1000, });

            InventoryComponent inventoryComponent = player.GetComponent<InventoryComponent>();
            inventoryComponent.items = new List<InventoryComponent.ItemInfo>()
            {
                new InventoryComponent.ItemInfo() { id = 10101, pos = 1, quantity = 1, },
                new InventoryComponent.ItemInfo() { id = 10102, pos = 2, quantity = 1, },
                new InventoryComponent.ItemInfo() { id = 10103, pos = 3, quantity = 99, },
            };

            return player;
        }

        public static Monster CreateMonster()
        {
            Monster monster;
            int t = NovaEngine.Utility.Random.Next(2);

            if (t > 0)
                monster = GameEngine.GameApi.CreateActor<Slime>();
            else
                monster = GameEngine.GameApi.CreateActor<Goblin>();

            monster.uid = GenId();

            IdentityComponent identityComponent = monster.GetComponent<IdentityComponent>();
            identityComponent.objectType = 21 + t;
            identityComponent.objectName = GetRandomMonsterName();

            AttributeComponent attributeComponent = monster.GetComponent<AttributeComponent>();
            attributeComponent.level = NovaEngine.Utility.Random.Next(100);
            attributeComponent.exp = 0;
            attributeComponent.health = 10 * attributeComponent.level;
            attributeComponent.energy = 2 * attributeComponent.level;
            attributeComponent.attack = 1 * attributeComponent.level;

            TransformComponent transformComponent = monster.GetComponent<TransformComponent>();
            transformComponent.position = new UnityEngine.Vector3(NovaEngine.Utility.Random.Next(10), 0, NovaEngine.Utility.Random.Next(10));
            transformComponent.rotation = new UnityEngine.Vector3(0, 1, 0);

            SkillComponent skillComponent = monster.GetComponent<SkillComponent>();
            
            if (t > 0)
            {
                skillComponent.skills = new List<SkillComponent.SkillInfo>()
                {
                    new SkillComponent.SkillInfo() { id = 2001, name = "黏液喷吐", range = 2, cooling_time = 1000, },
                    new SkillComponent.SkillInfo() { id = 2002, name = "毒气弥漫", range = 3, cooling_time = 5000, },
                };
            }
            else
            {
                skillComponent.skills = new List<SkillComponent.SkillInfo>()
                {
                    new SkillComponent.SkillInfo() { id = 3001, name = "穿刺攻击", range = 1, cooling_time = 1000, },
                    new SkillComponent.SkillInfo() { id = 3002, name = "标枪投掷", range = 3, cooling_time = 5000, },
                };
            }

            SpawnComponent spawnComponent = monster.GetComponent<SpawnComponent>();
            spawnComponent.born_position = new UnityEngine.Vector3(1, 0, 1);

            return monster;
        }

        static int GenId()
        {
            return ++_internalSequenceId;
        }

        static string GetRandomPlayerName()
        {
            return PlayerNames[NovaEngine.Utility.Random.Next(PlayerNames.Length)];
        }

        static string GetRandomMonsterName()
        {
            return MonsterNames[NovaEngine.Utility.Random.Next(MonsterNames.Length)];
        }
    }
}
