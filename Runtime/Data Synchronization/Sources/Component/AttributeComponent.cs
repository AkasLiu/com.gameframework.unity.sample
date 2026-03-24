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
using System.Text;

namespace GameFramework.Sample.DataSynchronization
{
    /// <summary>
    /// 属性组件类
    /// </summary>
    [UComponentClass("AttributeComponent")]
    internal class AttributeComponent : UComponent
    {
        [GameEngine.OnReplicateField()]
        public int level;

        [GameEngine.OnReplicateField()]
        public int exp;

        [GameEngine.OnReplicateField()]
        public int health;

        [GameEngine.OnReplicateField()]
        public int energy;

        [GameEngine.OnReplicateField()]
        public int attack;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("等级={0},经验={1},生命={2},体力={3},攻击={4}",
                this.level, this.exp, this.health, this.energy, this.attack);

            return sb.ToString();
        }
    }
}
