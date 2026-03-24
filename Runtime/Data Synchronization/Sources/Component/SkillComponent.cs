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
    /// 技能组件类
    /// </summary>
    [UComponentClass("SkillComponent")]
    internal class SkillComponent : UComponent
    {
        public class SkillInfo
        {
            public int id;
            public string name;

            public int range;

            public bool is_coolingdown;
            public int cooling_time;
            public int last_used_time;

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"[{id},{name},{range},{is_coolingdown},{cooling_time},{last_used_time}]");
                return sb.ToString();
            }
        }

        public IList<SkillInfo> skills;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"技能={");
            for (int n = 0; null != this.skills && n < this.skills.Count; ++n)
            {
                SkillInfo skill = this.skills[n];

                if (n > 0) sb.Append(",");
                sb.Append(skill.ToString());
            }
            sb.Append(@"}");
            return sb.ToString();
        }
    }
}
