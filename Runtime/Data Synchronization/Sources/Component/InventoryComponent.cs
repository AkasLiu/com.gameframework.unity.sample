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
    /// 背包组件类
    /// </summary>
    [GameEngine.CComponentClass("InventoryComponent")]
    internal class InventoryComponent : GameEngine.CComponent
    {
        public class ItemInfo
        {
            public int id;
            public int pos;

            public int quantity;
            public int using_time;
            public int last_used_time;
        }

        public IList<ItemInfo> items;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"背包={");
            for (int n = 0; null != items && n < items.Count; ++n)
            {
                ItemInfo item = items[n];

                if (n > 0) sb.Append(",");
                sb.AppendFormat("[{0},{1},{2},{3},{4}]", item.id, item.pos, item.quantity, item.using_time, item.last_used_time);
            }
            sb.Append(@"}");
            return sb.ToString();
        }
    }
}
