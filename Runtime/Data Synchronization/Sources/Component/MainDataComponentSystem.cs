/// -------------------------------------------------------------------------------
/// Copyright (C) 2024 - 2025, Hurley, Independent Studio.
/// Copyright (C) 2025, Hainan Yuanyou Information Technology Co., Ltd. Guangzhou Branch
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

using System.Collections.Generic;

namespace GameFramework.Sample.DataSynchronization
{
    /// <summary>
    /// 主数据组件逻辑类
    /// </summary>
    static class MainDataComponentSystem
    {
        [GameEngine.OnAspectBeforeCall(GameEngine.AspectBehaviourType.Awake)]
        static void Awake(this MainDataComponent self)
        {
            self.players = new List<Player>();
            self.monsters = new List<Monster>();
        }

        [GameEngine.OnAspectBeforeCall(GameEngine.AspectBehaviourType.Start)]
        static void Start(this MainDataComponent self)
        {
        }

        [GameEngine.OnAspectAfterCall(GameEngine.AspectBehaviourType.Destroy)]
        static void Destroy(this MainDataComponent self)
        {
            for (int n = 0; n < self.players.Count; ++n)
            {
                GameEngine.GameApi.DestroyActor(self.players[n]);
            }

            for (int n = 0; n < self.monsters.Count; ++n)
            {
                GameEngine.GameApi.DestroyActor(self.monsters[n]);
            }

            self.players.Clear();
            self.monsters.Clear();

            self.players = null;
            self.monsters = null;
        }

        public static Soldier GetSoldierByUid(this MainDataComponent self, int uid)
        {
            for (int n = 0; null != self.players && n < self.players.Count; ++n)
            {
                Player player = self.players[n];

                if (player.uid == uid)
                {
                    return player;
                }
            }

            for (int n = 0; null != self.monsters && n < self.monsters.Count; ++n)
            {
                Monster monster = self.monsters[n];

                if (monster.uid == uid)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Player GetRandomPlayerObject(this MainDataComponent self)
        {
            if (null != self.players && self.players.Count > 0)
            {
                int c = self.players.Count;

                int r = NovaEngine.Utility.Random.Next(c);

                return self.players[r];
            }

            return null;
        }

        public static Monster GetRandomMonsterObject(this MainDataComponent self)
        {
            if (null != self.monsters && self.monsters.Count > 0)
            {
                int c = self.monsters.Count;

                int r = NovaEngine.Utility.Random.Next(c);

                return self.monsters[r];
            }

            return null;
        }
    }
}
