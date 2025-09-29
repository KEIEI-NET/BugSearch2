//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金伝票入力（入金型）
// プログラム概要   : 入金伝票入力の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/03/25  修正内容 : MANTIS【15195】0円入金保存時に｢金種画面｣を表示し、選択後に登録へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/04/30  修正内容 : MANTIS【15195】修正呼出時は登録金種をデフォルトで表示
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/05/12  修正内容 : MANTIS【15195】入金0を修正呼出し、金種を変更すると、前回の金種が残る
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 有効期限を金種グリッドから取得するデリゲート
    /// </summary>
    /// <param name="index">グリッドのインデックス(0～)</param>
    /// <param name="validityTerm">有効期限</param>
    public delegate bool TakeValidityTerm(int index, out DateTime validityTerm);

    /// <summary>
    /// 金種選択画面フォーム
    /// </summary>
    public partial class SFUKK01403UC : Form
    {
        #region 金種項目

        /// <summary>
        /// 金種項目構造体
        /// </summary>
        private struct MoneyKindItem
        {
            #region 金額

            /// <summary>金額</summary>
            private double _amount;
            /// <summary>金額を取得または設定します。</summary>
            public double Amount
            {
                get { return _amount; }
                set { _amount = value; }
            }

            #endregion // 金額

            #region 有効期限

            /// <summary>有効期限</summary>
            private DateTime _validityTerm;
            /// <summary>有効期限を取得または設定します。</summary>
            public DateTime ValidityTerm
            {
                get { return _validityTerm; }
                set { _validityTerm = value; }
            }

            #endregion // 有効期限

            #region 行番号

            /// <summary>行番号</summary>
            private int _rowNo;
            /// <summary>行番号を取得または設定します。</summary>
            public int RowNo
            {
                get { return _rowNo; }
                set { _rowNo = value; }
            }

            #endregion // 行番号

            #region 金種コード

            /// <summary>金種コード</summary>
            private int _moneyKindCode;
            /// <summary>金種コードを取得または設定します。</summary>
            public int MoneyKindCode
            {
                get { return _moneyKindCode; }
                set { _moneyKindCode = value; }
            }

            #endregion // 金種コード

            #region 金種区分

            /// <summary>金種区分</summary>
            private int _moneyKindDiv;
            /// <summary>金種区分を取得または設定します。</summary>
            public int MoneyKindDiv
            {
                get { return _moneyKindDiv; }
                set { _moneyKindDiv = value; }
            }

            #endregion // 金種区分

            #region 金種名称

            /// <summary>金種名称</summary>
            private string _moneyKindName;
            /// <summary>金種名称を取得または設定します。</summary>
            public string MoneyKindName
            {
                get { return _moneyKindName; }
                set { _moneyKindName = value; }
            }

            #endregion // 金種名称

            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="amount">金額</param>
            /// <param name="validityTerm">有効期限</param>
            /// <param name="rowNo">行番号</param>
            /// <param name="moneyKindCode">金種コード</param>
            /// <param name="moneyKindDiv">金種区分</param>
            /// <param name="moneyKindName">金種名称</param>
            public MoneyKindItem(
                double amount,
                DateTime validityTerm,
                int rowNo,
                int moneyKindCode,
                int moneyKindDiv,
                string moneyKindName
            )
            {
                _amount = amount;
                _validityTerm = validityTerm;
                _rowNo = rowNo;
                _moneyKindCode = moneyKindCode;
                _moneyKindDiv = moneyKindDiv;
                _moneyKindName = moneyKindName;
            }

            #endregion // Constructor

            #region Override

            /// <summary>
            /// 文字列に変換します。
            /// </summary>
            /// <returns><c>DepositStKindCdNm</c></returns>
            public override string ToString()
            {
                return MoneyKindName;
            }

            #endregion // Override
        }

        #endregion // 金種項目

        #region 金種内訳グリッド

        /// <summary>金種内訳グリッド</summary>
        private readonly UltraGrid _moneyKindGrid;
        /// <summary>金種内訳グリッドを取得します。</summary>
        private UltraGrid MoneyKindGrid { get { return _moneyKindGrid; } }

        /// <summary>有効期限を金種グリッドから取得するイベント</summary>
        public event TakeValidityTerm TakeValidityTerm = new TakeValidityTerm(
            delegate(int indexer, out DateTime payTimeLimit)
            {
                // デフォルトの有効期限を金種グリッドから取得するデリゲート(何もしない)
                payTimeLimit = DateTime.MinValue;
                return true;
            }
        );

        #endregion // 金種内訳グリッド

        #region 入金グリッド選択行(入金情報更新内容)

        /// <summary>入金グリッド選択行(入金情報更新内容)</summary>
        private readonly DataRow _selectedDepositCopyRow;
        /// <summary>入金グリッド選択行(入金情報更新内容)を取得します。</summary>
        private DataRow SelectedDepositCopyRow { get { return _selectedDepositCopyRow; } }

        // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
        /// <summary>
        /// 現在の金種名称を取得します。
        /// </summary>
        private string CurrentKindName
        {
            get { return SelectedDepositCopyRow.ItemArray[12].ToString(); }
        }
        // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<

        /// <summary>
        /// 入金グリッド選択行(入金情報更新内容)を設定します。
        /// </summary>
        /// <param name="selectedMoneyKind">選択された金種項目</param>
        private void SetSelectedDepositCopyRow(MoneyKindItem selectedMoneyKind)
        {
            // ADD 2010/05/12 MANTIS対応[15195]：入金0を修正呼出し、金種を変更すると、前回の金種が残る ---------->>>>>
            #region 初期化（全クリア）
            
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit1]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm1]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo1]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode1]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv1]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName1]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit2]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm2]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo2]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode2]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv2]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName2]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit3]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm3]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo3]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode3]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv3]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName3]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit4]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm4]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo4]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode4]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv4]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName4]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit5]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm5]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo5]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode5]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv5]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName5]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit6]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm6]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo6]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode6]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv6]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName6]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit7]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm7]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo7]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode7]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv7]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName7]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit8]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm8]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo8]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode8]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv8]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName8]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit9]        = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm9]   = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo9]   = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode9]  = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv9]   = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName9]  = string.Empty;     // 金種名称

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit10]       = 0.0;              // 入金金額
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm10]  = DateTime.MinValue;// 有効期限
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo10]  = 0;                // 入金行番号
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode10] = 0;                // 金種コード
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv10]  = 0;                // 金種区分
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName10] = string.Empty;     // 金種名称

            #endregion // 初期化（全クリア）
            // ADD 2010/05/12 MANTIS対応[15195]：入金0を修正呼出し、金種を変更すると、前回の金種が残る ----------<<<<<

            switch (selectedMoneyKind.RowNo)
            {
                case 1:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit1] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm1] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo1] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode1] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv1] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName1] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 2:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit2] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm2] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo2] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode2] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv2] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName2] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 3:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit3] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm3] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo3] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode3] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv3] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName3] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 4:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit4] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm4] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo4] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode4] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv4] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName4] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 5:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit5] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm5] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo5] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode5] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv5] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName5] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 6:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit6] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm6] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo6] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode6] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv6] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName6] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 7:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit7] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm7] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo7] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode7] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv7] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName7] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 8:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit8] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm8] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo8] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode8] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv8] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName8] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 9:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit9] = selectedMoneyKind.Amount;                // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm9] = selectedMoneyKind.ValidityTerm;     // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo9] = selectedMoneyKind.RowNo;            // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode9] = selectedMoneyKind.MoneyKindCode;   // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv9] = selectedMoneyKind.MoneyKindDiv;     // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName9] = selectedMoneyKind.MoneyKindName;   // 金種名称
                }
                    break;
                case 10:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit10] = selectedMoneyKind.Amount;               // 入金金額
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm10] = selectedMoneyKind.ValidityTerm;    // 有効期限
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo10] = selectedMoneyKind.RowNo;           // 入金行番号
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode10] = selectedMoneyKind.MoneyKindCode;  // 金種コード
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv10] = selectedMoneyKind.MoneyKindDiv;    // 金種区分
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName10] = selectedMoneyKind.MoneyKindName;  // 金種名称
                }
                    break;
            }
        }

        #endregion // 入金グリッド選択行(入金情報更新内容)

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="depositKindGrid">入金内訳グリッド</param>
        /// <param name="selectedDepositCopyRow">入金グリッド選択行(入金情報更新内容)</param>
        public SFUKK01403UC(
            UltraGrid depositKindGrid,
            DataRow selectedDepositCopyRow
        )
        {
            #region DesignerCode

            InitializeComponent();

            #endregion // DesignerCode

            _moneyKindGrid = depositKindGrid;
            _selectedDepositCopyRow = selectedDepositCopyRow;
        }

        #endregion // Constructor

        #region フォーム

        /// <summary>
        /// 金種選択画面フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SFUKK01403UC_Load(object sender, EventArgs e)
        {
            // 金種プルダウンを初期化
            this.tcboDepositKind.Clear();

            if (MoneyKindGrid == null) return;

            // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
            List<string> kindNameList = new List<string>();
            // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<

            int depositRowNo = 0;
            for (int i = 0; i < MoneyKindGrid.Rows.Count; i++)
            {
                depositRowNo++;

                DateTime validityTerm = DateTime.MinValue;
                TakeValidityTerm(i, out validityTerm);

                this.tcboDepositKind.Items.Add(new MoneyKindItem(
                    0.0,            // 入金金額：0 円（固定）
                    validityTerm,   // 有効期限
                    depositRowNo,
                    (int)MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindCode].Value,
                    (int)MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindDiv].Value,
                    MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindName].Value.ToString()
                ));
                // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
                kindNameList.Add(MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindName].Value.ToString());
                // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<
            }

            if (this.tcboDepositKind.Items.Count > 0)
            {
                this.tcboDepositKind.Enabled = true;

                // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
                if (string.IsNullOrEmpty(CurrentKindName))
                {
                    this.tcboDepositKind.SelectedIndex = 0; // 先頭を選択
                    return;
                }
                
                int foundIndex = kindNameList.FindIndex(delegate(string kindName)
                {
                    return kindName.Equals(CurrentKindName);
                });
                if (foundIndex >= 0 && foundIndex < kindNameList.Count)
                {
                    this.tcboDepositKind.SelectedIndex = foundIndex;
                    return;
                }
                // ADD 2010/04/30 MANTIS対応[15195]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<

                this.tcboDepositKind.SelectedIndex = 0; // 先頭を選択
            }
            else
            {
                this.tcboDepositKind.Enabled = false;
            }
        }

        #endregion // フォーム

        /// <summary>
        /// [OK]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnOK_Click(object sender, EventArgs e)
        {
            MoneyKindItem selectedMoneyKind = (MoneyKindItem)this.tcboDepositKind.Value;

            // 入金グリッド選択行(入金情報更新内容)を設定
            SetSelectedDepositCopyRow(selectedMoneyKind);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// [キャンセル]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnCancel_Click(object sender, EventArgs e)
        {
            // 特にすることなし
        }
    }
}