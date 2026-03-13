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

using UnityEditor;

namespace GameFramework.Editor.Sample
{
    /// <summary>
    /// 演示案例的菜单项
    /// </summary>
    static class SampleMenus
    {
        const string MenuName_TutorialEnabled = @"Game Framework/Tutorial/Tutorial Enable";
        const string MenuName_TutorialInstalled = @"Game Framework/Tutorial/Tutorial Install";

        [InitializeOnLoadMethod]
        static void InitializeOnLoad()
        {
            // 在编辑器启动时调用
            EditorApplication.delayCall += InitMenuState;
        }

        static void InitMenuState()
        {
            bool isTutorialEnabled = TutorialConfigure.IsTutorialEnabled;
            Menu.SetChecked(MenuName_TutorialEnabled, isTutorialEnabled);
        }

        [MenuItem(MenuName_TutorialEnabled)]
        static void OnTutorialEnabled()
        {
            bool isEnabled = TutorialConfigure.IsTutorialEnabled;
            isEnabled = !isEnabled;
            TutorialConfigure.IsTutorialEnabled = isEnabled;
            Menu.SetChecked(MenuName_TutorialEnabled, isEnabled);
        }

        [MenuItem(MenuName_TutorialInstalled)]
        static void OnTutorialInstalled()
        {
            SettingsExportStep step = new SettingsExportStep();
            step.Install(() => { }, () => { }, () => { }, (msg) => { });
        }
    }
}
