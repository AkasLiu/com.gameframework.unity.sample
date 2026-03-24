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

namespace GameFramework.Sample.DispatchCall
{
    /// <summary>
    /// 主场景输入逻辑类
    /// </summary>
    static class MainSceneInputSystem
    {
        [OnInput(GameEngine.VirtualKeyCode.E, GameEngine.InputOperationType.Released)]
        static void OnEnterWorldMessageSend(GameEngine.VirtualKeyCode keycode, GameEngine.InputOperationType operationType)
        {
            MainScene main = GameEngine.SceneHandler.Instance.GetCurrentScene() as MainScene;
            Debugger.Assert(null != main, "Invalid activated scene.");

            GameEngine.GameApi.OnMessageSimulation(new EnterWorldResp()
            {
                Code = 1,
                Player = MessageBuilder.CreatePlayerInfo(),
            });
        }

        [OnInput(GameEngine.VirtualKeyCode.A, GameEngine.InputOperationType.Released)]
        static void OnLevelSpawnMessageSend(GameEngine.VirtualKeyCode keycode, GameEngine.InputOperationType operationType)
        {
            List<MonsterInfo> monsters = new List<MonsterInfo>();
            int total = NovaEngine.Utility.Random.Next(3) + 1;
            for (int n = 0; n < total; n++)
            {
                int r = NovaEngine.Utility.Random.Next(2);
                MonsterInfo monster = null;
                if (r > 0)
                {
                    monster = MessageBuilder.CreateGoblinMonsterInfo();
                }
                else
                {
                    monster = MessageBuilder.CreateSlimeMonsterInfo();
                }

                monsters.Add(monster);
            }

            GameEngine.GameApi.OnMessageSimulation(new LevelSpawnResp()
            {
                Code = total,
                MonsterList = monsters,
            });
        }

        [OnInput(GameEngine.VirtualKeyCode.Q, GameEngine.InputOperationType.Released)]
        static void OnLeaveWorldMessageSend(GameEngine.VirtualKeyCode keycode, GameEngine.InputOperationType operationType)
        {
            GameEngine.GameApi.OnMessageSimulation(new LeaveWorldResp()
            {
                Code = 0,
            });
        }
    }
}
