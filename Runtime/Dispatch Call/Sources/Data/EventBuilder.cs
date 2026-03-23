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

namespace GameFramework.Sample.DispatchCall
{
    /// <summary>
    /// 事件构建类
    /// </summary>
    static class EventBuilder
    {
        [GameEngine.OnInputDispatchCall(GameEngine.VirtualKeyCode.Alpha1, GameEngine.InputOperationType.Released)]
        static void OnPlayerDisplayInfoEventSend(GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            GameEngine.GameApi.Send(EventNotify.PlayerDisplayInfo, "疯狂星期四", 8080);
        }

        [GameEngine.OnInputDispatchCall(GameEngine.VirtualKeyCode.Alpha2, GameEngine.InputOperationType.Released)]
        static void OnPlayerSearchAllEnemiesEventSend(GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            GameEngine.GameApi.Send(EventNotify.PlayerSearchAllEnemies);
        }

        [GameEngine.OnInputDispatchCall(GameEngine.VirtualKeyCode.Alpha3, GameEngine.InputOperationType.Released)]
        static void OnPlayerLockOneTargetEventSend(GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            int r = NovaEngine.Utility.Random.Next(2);
            int uid = 0;
            if (r > 0)
            {
                Monster monster = GameEngine.GameApi.GetCurrentSceneComponent<MainDataComponent>().GetRandomMonsterObject();
                if (null != monster)
                {
                    uid = monster.GetComponent<IdentityComponent>().objectID;
                }
            }
            GameEngine.GameApi.Send(EventNotify.PlayerLockOneTarget, uid);
        }

        [GameEngine.OnInputDispatchCall(GameEngine.VirtualKeyCode.Alpha4, GameEngine.InputOperationType.Released)]
        static void OnPlayerUpgradeEventSend(GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            int exp = NovaEngine.Utility.Random.Next(1000);

            GameEngine.GameApi.Send(EventNotify.PlayerUpgrade, exp);
        }

        [GameEngine.OnInputDispatchCall(GameEngine.VirtualKeyCode.Alpha5, GameEngine.InputOperationType.Released)]
        static void OnPlayerChaseTargetEventSend(GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            GameEngine.GameApi.Send(EventNotify.PlayerChaseTarget);
        }

        [GameEngine.OnInputDispatchCall(GameEngine.VirtualKeyCode.Alpha6, GameEngine.InputOperationType.Released)]
        static void OnActorAttributeDisplayEventSend(GameEngine.VirtualKeyCode keyCode, GameEngine.InputOperationType operationType)
        {
            GameEngine.GameApi.Send(EventNotify.DisplayAttribute);
        }
    }
}
