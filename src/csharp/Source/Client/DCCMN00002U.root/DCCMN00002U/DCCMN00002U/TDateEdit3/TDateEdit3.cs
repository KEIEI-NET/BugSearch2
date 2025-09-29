using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Library.Windows.Forms.TDateEdit3
{
    /// <summary>
    /// TDateEdit3
    /// </summary>
    /// <remarks>
    /// <br>Note       : 日付のコンポーネントクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.12.18</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.01.21 20056 對馬 大輔</br>
    /// <br>           : ・以下の対応を行う</br>
    /// <br>           : 　フレームで表示する場合、Createで一瞬リストが画面表示される。</br>
    /// </remarks>
    [ToolboxBitmap(typeof(TDateEdit3), "TDateEdit3.TDateEdit3.bmp")]
    public partial class TDateEdit3 : TDateEdit2
    {
        Dictionary<string, string> _genDic = new Dictionary<string, string>();  // <略号, 元号>
        Dictionary<string, int> _indexDic = new Dictionary<string, int>();      // <略号, 元号Index>
        ArrayList _rGList = new ArrayList();                                    // 元号リスト

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TDateEdit3()
        {
            InitializeComponent();

            // 2009.01.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            base.JpGenCombo2.DroppedDown = true;                                                    // 元号のDropDownなしへ
            // 2009.01.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            // 2009.01.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //base.JpGenCombo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;               // DropDownへ変更
            //base.JpGenCombo2.DroppedDown = true;                                                    // 元号のDropDownなしへ
            base.JpGenCombo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;               // DropDownへ変更
            // 2009.01.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            base.JpGenCombo2.KeyPress += new KeyPressEventHandler(JpGenCombo2_KeyPress);            // 元号コンボKeyPressイベント追加
            base.JpGenCombo2.AfterExitEditMode += new EventHandler(JpGenCombo2_AfterExitEditMode);  // 元号コンボAfterExitEditModeイベント追加

            #region 元号コンボのGotFocusイベント削除
            MethodInfo methodInfo;
            TDateEdit td = new TDateEdit();
            string fullName = td.GetType().FullName;
            string assemblyName = td.GetType().Assembly.GetName().Name;

            this.GetMethodInfo(assemblyName, fullName, new object[] { }, "JpGenCombo2_GotFocus", new object[] { }, out methodInfo);

            Type handlerType = typeof(EventHandler);
            TComboEditor tComboEditor = base.JpGenCombo2;
            Delegate eventMethod = Delegate.CreateDelegate(handlerType, this, methodInfo);
            base.JpGenCombo2.GetType().GetEvent("GotFocus").RemoveEventHandler(base.JpGenCombo2, eventMethod);
            #endregion

            #region 各種リスト取得
            string ryakGou = string.Empty;
            TDateTime.GetGengouList(out _rGList);
            for (int i = 0; i < _rGList.Count; i++)
            {
                ryakGou = TDateTime.GetRyakGou(_rGList[i].ToString());
                _genDic.Add(ryakGou, _rGList[i].ToString());
                _indexDic.Add(ryakGou, i);
            }
            #endregion

            base.OnCreateControl();
        }

        /// <summary>
        /// OnEnter
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            if (!_rGList.Contains(base.JpGenCombo2.Text.Trim())) base.JpGenCombo2.SelectedIndex = 0;
        }

        /// <summary>
        /// OnLeave
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            if ((base.GetDateYear() == 0) &&
                (base.GetDateMonth() == 0) &&
                (base.GetDateDay() == 0))
            {
                base.JpGenCombo2.ResetText();
                base.JpGenCombo2.SelectedIndex = -1;
            }
            base.OnLeave(e);
        }

        /// <summary>
        /// JpGenCombo2_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JpGenCombo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 対象略号以外はKeyクリア
            if (_genDic.ContainsKey(e.KeyChar.ToString().ToUpper()))
            {
                // 入力略号の対象となる元号Index設定
                base.JpGenCombo2.SelectedIndex = this._indexDic[e.KeyChar.ToString().ToUpper()];
            }
            e.Handled = false;
            e.KeyChar = Char.MinValue;
        }

        /// <summary>
        /// JpGenCombo2_AfterExitEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JpGenCombo2_AfterExitEditMode(object sender, EventArgs e)
        {
            // 元号以外の入力値が設定されている場合は、表示初期化
            if (!_rGList.Contains(base.JpGenCombo2.Text.Trim())) base.JpGenCombo2.SelectedIndex = 0;
        }

        /// <summary>
        /// メソッド情報取得処理
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="className"></param>
        /// <param name="createArgs"></param>
        /// <param name="methodName"></param>
        /// <param name="executeArgs"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        private bool GetMethodInfo(string assemblyName, string className, object[] createArgs, string methodName, object[] executeArgs, out MethodInfo methodInfo)
        {
            bool result = false;
            methodInfo = null;

            System.Reflection.Assembly asm = System.Reflection.Assembly.Load(assemblyName);
            Type objType = asm.GetType(className);
            if (objType != null)
            {
                object obj = Activator.CreateInstance(objType, createArgs);

                if (obj != null)
                {
                    methodInfo = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                    return (methodInfo != null);
                }
            }
            return result;
        }
    }
}