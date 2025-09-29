//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 履歴系画面の共通機能
// プログラム概要   : UIの共通処理を実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms.Items
{
    using DateTimeUIType        = Broadleaf.Library.Windows.Forms.TDateEdit;
    using EmployeeUIType        = Broadleaf.Library.Windows.Forms.TEdit;
    using LogDataKindUIType     = Broadleaf.Library.Windows.Forms.TComboEditor;
    using LogDataKindItemType   = CodeNamePair<int>;
    using GridType              = Infragistics.Win.UltraWinGrid.UltraGrid;
    using AutoFillToGridUIType  = Infragistics.Win.UltraWinEditors.UltraCheckEditor;
    using FontSizeUIType        = Broadleaf.Library.Windows.Forms.TComboEditor;

    /// <summary>
    /// UIユーティリティ
    /// </summary>
    internal static class UIUtil
    {
        #region <日時/>

        /// <summary>
        /// 日時UIを初期化します。
        /// </summary>
        /// <param name="from">開始日時</param>
        /// <param name="to">終了日時</param>
        public static void InitializeDateTimeUI(
            DateTimeUIType from,
            DateTimeUIType to
        )
        {
            DateTime now = DateTime.Now;

            from.SetDateTime(now);
            to.SetDateTime(now);
        }

        /// <summary>
        /// 入力日付をチェックします。(範囲チェックなし、未入力OK)
        /// </summary>
        /// <remarks>
        /// コピー元：仕入確認表::MAKON02240UA.CallCheckInputDateRange()
        /// </remarks>
        /// <param name="fromDateUI">開始日付のUI</param>
        /// <param name="toDateUI">終了日付のUI</param>
        /// <param name="message">メッセージ</param>
        /// <returns>
        /// <c>true</c> :OK<br/>
        /// <c>false</c>:NG
        /// </returns>
        public static bool IsOKThatInputDateRangeCheck(
            TDateEdit fromDateUI,
            TDateEdit toDateUI,
            out string message
        )
        {
            message = string.Empty;

            const int MAX_MONTH_SPAN= 3;            // 最大3ヶ月の範囲
            const string FROM_DATE  = "開始日{0}";  // LITERAL:
            const string TO_DATE    = "終了日{0}";  // LITERAL:
            const string DATE_TIME  = "日時{0}";    // LITERAL:
            const string INPUT_ERROR= "の入力が不正です";                   // LITERAL:
            const string RANGE_ERROR= "の範囲指定に誤りがあります";         // LITERAL:
            const string RANGE_OVER = "は３ヶ月の範囲内で入力して下さい";   // LITERAL:

            DateGetAcs.CheckDateRangeResult result = DateGetAcs.GetInstance().CheckDateRange(
                DateGetAcs.YmdType.YearMonth,
                MAX_MONTH_SPAN, // 範囲
                ref fromDateUI,
                ref toDateUI,
                true            // モード？
            );
            switch (result)
            {
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    return true;
                case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                {
                    message = string.Format(FROM_DATE, INPUT_ERROR);
                    fromDateUI.Focus();
                    break;
                }
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    return true;
                case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                {
                    message = string.Format(TO_DATE, INPUT_ERROR);
                    toDateUI.Focus();
                    break;
                }
                case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                {
                    message = string.Format(DATE_TIME, RANGE_ERROR);
                    fromDateUI.Focus();
                    break;
                }
                case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                {
                    message = string.Format(DATE_TIME, RANGE_OVER);
                    fromDateUI.Focus();
                    break;
                }
            }
            return result.Equals(DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// TDateEditコントロールを構成するアイテムのインデックス列挙体
        /// </summary>
        public enum TDateEditItemIndex : int
        {
            /// <summary>日アイテム</summary>
            Day = 3,
            /// <summary>月アイテム</summary>
            Month = 4,
            /// <summary>年アイテム</summary>
            Year = 5
        }

        /// <summary>
        /// TDateEditの日付アイテムを取得します。
        /// </summary>
        /// <param name="tDateEdit">TDateEditオブジェクト</param>
        /// <param name="itemIndex">TDateEditコントロールを構成するアイテムのインデックス</param>
        /// <returns>該当する日付アイテム</returns>
        public static TNedit GetDateItem(
            TDateEdit tDateEdit,
            TDateEditItemIndex itemIndex
        )
        {
            return (TNedit)tDateEdit.Controls[(int)itemIndex];
        }

        /// <summary>
        /// 矢印キーを押したときのイベントハンドラ
        /// </summary>
        /// <param name="e">キー押下時のイベントパラメータ</param>
        /// <param name="previousControl">前のコントロール</param>
        /// <param name="nextControl">次のコントロール</param>
        public static void OnArrowKeyDown(
            KeyEventArgs e,
            Control previousControl,
            Control nextControl
        )
        {
            if (!e.Shift) return;

            switch (e.KeyCode)
            {
                case Keys.Left: // ←キー
                    previousControl.Focus();
                    break;
                case Keys.Right:// →キー
                    nextControl.Focus();
                    break;
            }
        }

        #endregion  // <日時/>

        #region <従業員/>

        /// <summary>
        /// 従業員のコードと名前を入力しますします。
        /// </summary>
        /// <param name="uiCode">コードUIオブジェクト</param>
        /// <param name="uiName">名前UIオブジェクト</param>
        public static void InputEmployeeCodeAndName(
            EmployeeUIType uiCode,
            EmployeeUIType uiName
        )
        {
            Employee employee = null;
            int status = OperationHistoryAcs.Instance.EmployeeMasterDB.RealAccesser.ExecuteGuid(
                LoginInfoAcquisition.EnterpriseCode,
                true,
                out employee
            );
            if (status.Equals((int)DBAccessStatus.Normal))
            {
                uiCode.Text = employee.EmployeeCode;
                uiName.Text = employee.Name;
            }
        }

        /// <summary>
        /// 従業員名を取得します。
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名<br/>※該当する従業員コードがない場合、<c>string.Empty</c>を返します。</returns>
        public static string GetEmployeeName(string employeeCode)
        {
            string dbEmployeeCode = EmployeeAcsAgent.ConvertEmployeeCodeInDBFormat(employeeCode);
            if (OperationHistoryAcs.Instance.EmployeeMasterDB.RecordMap.ContainsKey(dbEmployeeCode))
            {
                return OperationHistoryAcs.Instance.EmployeeMasterDB.RecordMap[dbEmployeeCode].Name;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion  // <従業員/>

        #region <グリッド/>

        /// <summary>
        /// カラムサイズを調整します。
        /// </summary>
        /// <param name="grid">グリッド</param>
        public static void DoColumnPerformAutoResize(GridType grid)
        {
            // カラムサイズ調整
            for (int i = 0; i < grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(PerformAutoSizeType.VisibleRows, true);
            }
        }

        #endregion  // <グリッド/>

        #region <列サイズの自動調整/>

        /// <summary>
        /// 列サイズの自動調整を行います。
        /// </summary>
        /// <param name="autoFillUI">自動調整UI</param>
        /// <param name="grid">グリッド</param>
        public static void DoAutoFillToGridColumn(
            AutoFillToGridUIType autoFillUI,
            GridType grid
        )
        {
            if (autoFillUI.Checked)
            {
                // 列幅をオートに設定
                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                grid.Refresh();
            }

            // カラムサイズ調整
            DoColumnPerformAutoResize(grid);
        }

        #endregion  // <列サイズの自動調整/>

        #region <文字サイズ/>

        /// <summary>
        /// 文字サイズUIを初期化します。
        /// </summary>
        /// <remarks>
        /// デフォルトサイズは11
        /// </remarks>
        /// <param name="ui">文字サイズ設定UIオブジェクト</param>
        public static void InitializeFontSizeUI(FontSizeUIType ui)
        {
            int[] fontPitchSizes = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
            foreach (int iFontPitchSize in fontPitchSizes) ui.Items.Add(iFontPitchSize, iFontPitchSize.ToString());
        }

        /// <summary>
        /// グリッドの表示文字サイズを変更します。
        /// </summary>
        /// <param name="ui">文字サイズUIオブジェクト</param>
        /// <param name="grid">グリッド</param>
        public static void ChangeFontSize(
            FontSizeUIType ui,
            GridType grid
        )
        {
            float fontPoint = float.Parse(ui.Value.ToString());

            grid.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            grid.Refresh();

            DoColumnPerformAutoResize(grid);
        }

        #endregion  // <文字サイズ/>

        #region <UIの背景色/>

        /// <summary>
        /// UIの背景色ユーティリティ
        /// </summary>
        public static class UIColor
        {
            /// <summary>
            /// デフォルト背景色
            /// </summary>
            /// <value>デフォルト背景色</value>
            private static Color DefaultBackColor
            {
                get { return Color.FromName("Window"); }
            }

            /// <summary>
            /// フォーカス時の背景色
            /// </summary>
            private static Color FocusedBackColor
            {
                get { return Color.FromArgb(247, 227, 156); }
            }

            /// <summary>
            /// フォーカス遷移時のイベントハンドラ
            /// </summary>
            /// <param name="e">イベントパラメータ</param>
            public static void OnFocusChanged(Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
            {
                if (e.PrevCtrl is ComboBox || e.PrevCtrl is TextBox)
                {
                    e.PrevCtrl.BackColor = DefaultBackColor;
                }

                if (e.NextCtrl is ComboBox || e.NextCtrl is TextBox)
                {
                    e.NextCtrl.BackColor = FocusedBackColor;
                }
            }
        }

        #endregion  // <UIの背景色/>
    }
}
