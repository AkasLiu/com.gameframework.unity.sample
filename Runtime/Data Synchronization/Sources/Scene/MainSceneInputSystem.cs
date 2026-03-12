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

using System.Collections.Generic;

namespace GameFramework.Sample.DataSynchronization
{
    /// <summary>
    /// 主场景输入逻辑类
    /// </summary>
    static class MainSceneInputSystem
    {
        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.A, GameEngine.InputOperationType.Released)]
        static void OnDisplayAllObjects(int keycode, int operationType)
        {
            MainDataComponent mainDataComponent = GameEngine.GameApi.GetCurrentSceneComponent<MainDataComponent>();
            for (int n = 0; n < mainDataComponent.players.Count; ++n)
            {
                Debugger.Info(mainDataComponent.players[n].ToString());
            }
            for (int n = 0; n < mainDataComponent.monsters.Count; ++n)
            {
                Debugger.Info(mainDataComponent.monsters[n].ToString());
            }

            (GameEngine.GameApi.GetCurrentScene() as MainScene).PrintUsage();
        }

        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.Z, GameEngine.InputOperationType.Released)]
        static void TestReplicateTags_1(int keycode, int operationType)
        {
            GameEngine.GameApi.Push("player.inventory.item", GameEngine.ReplicateAnnounceType.Changed);
        }

        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.X, GameEngine.InputOperationType.Released)]
        static void TestReplicateTags_2(int keycode, int operationType)
        {
            GameEngine.GameApi.Push("player.skill", GameEngine.ReplicateAnnounceType.Changed);
        }

        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.Alpha1, GameEngine.InputOperationType.Released)]
        static void OnCreatePlayerObject(int keycode, int operationType)
        {
            Player player = DataBuilder.CreatePlayer();

            MainDataComponent mainDataComponent = GameEngine.GameApi.GetCurrentSceneComponent<MainDataComponent>();
            mainDataComponent.players.Add(player);
        }

        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.Alpha2, GameEngine.InputOperationType.Released)]
        static void OnDestroyPlayerObject(int keycode, int operationType)
        {
            MainDataComponent mainDataComponent = GameEngine.GameApi.GetCurrentSceneComponent<MainDataComponent>();
            if (mainDataComponent.players.Count > 0)
            {
                GameEngine.GameApi.DestroyActor(mainDataComponent.players[0]);
                mainDataComponent.players.RemoveAt(0);
            }
        }

        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.Alpha3, GameEngine.InputOperationType.Released)]
        static void OnCreateMonsterObject(int keycode, int operationType)
        {
            Monster monster = DataBuilder.CreateMonster();

            MainDataComponent mainDataComponent = GameEngine.GameApi.GetCurrentSceneComponent<MainDataComponent>();
            mainDataComponent.monsters.Add(monster);
        }

        [GameEngine.OnInputDispatchCall((int) UnityEngine.KeyCode.Alpha4, GameEngine.InputOperationType.Released)]
        static void OnDestroyMonsterObject(int keycode, int operationType)
        {
            MainDataComponent mainDataComponent = GameEngine.GameApi.GetCurrentSceneComponent<MainDataComponent>();
            if (mainDataComponent.monsters.Count > 0)
            {
                GameEngine.GameApi.DestroyActor(mainDataComponent.monsters[0]);
                mainDataComponent.monsters.RemoveAt(0);
            }
        }
    }
}
