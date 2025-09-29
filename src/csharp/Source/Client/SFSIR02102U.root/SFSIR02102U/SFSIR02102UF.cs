//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払伝票入力
// プログラム概要   : 支払伝票入力の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/03/26  修正内容 : MANTIS【15200】0円支払保存時に｢金種画面｣を表示し、選択後に登録へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/04/30  修正内容 : MANTIS【15200】修正呼出時は登録金種をデフォルトで表示
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 修 正 日  2010/05/12  修正内容 : MANTIS【15200】入金0を修正呼出し、金種を変更すると、前回の金種が残る
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
using Broadleaf.Application.UIData;

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
    public partial class SFSIR02102UF : Form
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

        #region 支払伝票マスタレコード

        /// <summary>支払伝票マスタレコード</summary>
        private readonly PaymentSlp _paymentSlpRecord;
        /// <summary>支払伝票マスタレコード</summary>
        private PaymentSlp PaymentSlpRecord { get { return _paymentSlpRecord; } }
        
        // ADD 2010/04/30 MANTIS対応[15200]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
        /// <summary>
        /// 現在の金種名称のインデックスを取得します。
        /// </summary>
        private int CurrentKindNameIndex
        {
            get
            {
                string[] foundKindNames = Array.FindAll(
                    PaymentSlpRecord.MoneyKindNameDtl,
                delegate(string kindName)
                {
                    return !string.IsNullOrEmpty(kindName);
                });
                if (foundKindNames.Length > 1 || foundKindNames.Length.Equals(0)) return 0;

                int foundIndex = Array.FindIndex(
                    PaymentSlpRecord.MoneyKindNameDtl,
                delegate(string kindName)
                {
                    return !string.IsNullOrEmpty(kindName);
                });
                if (foundIndex >= 0) return foundIndex;

                return 0;
            }
        }
        // ADD 2010/04/30 MANTIS対応[15200]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<

        /// <summary>
        /// 支払伝票マスタレコードを設定します。
        /// </summary>
        /// <param name="selectedMoneyKind">選択された金種項目</param>
        private void SetPaymentSlpRecord(MoneyKindItem selectedMoneyKind)
        {
            // 金種コード
            int moneyKindCode = selectedMoneyKind.MoneyKindCode;
            // 金種名称
            string moneyKindName = selectedMoneyKind.MoneyKindName;
            // 金種区分
            int moneyKindDiv = selectedMoneyKind.MoneyKindDiv;
            // 支払行番号
            int paymentRowNo = selectedMoneyKind.RowNo;
            // 支払金額
            double payment = selectedMoneyKind.Amount;
            // 期日
            DateTime validityTerm = selectedMoneyKind.ValidityTerm;

            // ADD 2010/05/12 MANTIS対応[15200]：入金0を修正呼出し、金種を変更すると、前回の金種が残る ---------->>>>>
            // 初期化（全クリア）
            for (int i = 0; i < PaymentSlpRecord.PaymentRowNoDtl.Length; i++)
            {
                PaymentSlpRecord.PaymentRowNoDtl[i] = 0;
                PaymentSlpRecord.MoneyKindCodeDtl[i]= 0;
                PaymentSlpRecord.MoneyKindNameDtl[i]= string.Empty;
                PaymentSlpRecord.MoneyKindDivDtl[i] = 0;
                PaymentSlpRecord.PaymentDtl[i]      = 0;
                PaymentSlpRecord.ValidityTermDtl[i] = DateTime.MinValue;
            }
            // ADD 2010/05/12 MANTIS対応[15200]：入金0を修正呼出し、金種を変更すると、前回の金種が残る ----------<<<<<

            PaymentSlpRecord.PaymentRowNoDtl[paymentRowNo - 1] = paymentRowNo;
            PaymentSlpRecord.MoneyKindCodeDtl[paymentRowNo - 1] = moneyKindCode;
            PaymentSlpRecord.MoneyKindNameDtl[paymentRowNo - 1] = moneyKindName;
            PaymentSlpRecord.MoneyKindDivDtl[paymentRowNo - 1] = moneyKindDiv;
            PaymentSlpRecord.PaymentDtl[paymentRowNo - 1] = (long)payment;
            PaymentSlpRecord.ValidityTermDtl[paymentRowNo - 1] = validityTerm;
        }

        #endregion // 支払伝票マスタレコード

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="paymentKindGrid">支払内訳グリッド</param>
        /// <param name="paymentSlpRecord">支払伝票マスタレコード</param>
        public SFSIR02102UF(
            UltraGrid paymentKindGrid,
            PaymentSlp paymentSlpRecord
        )
        {
            #region DesignerCode

            InitializeComponent();

            #endregion // DesignerCode

            _moneyKindGrid  = paymentKindGrid;
            _paymentSlpRecord = paymentSlpRecord;
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
            this.tcboPaymentKind.Clear();

            if (MoneyKindGrid == null) return;

            int paymentRowNo = 0;
            for (int i = 0; i < MoneyKindGrid.Rows.Count; i++)
            {
                paymentRowNo++;

                DateTime validityTerm = DateTime.MinValue;
                TakeValidityTerm(i, out validityTerm);

                this.tcboPaymentKind.Items.Add(new MoneyKindItem(
                    0.0,            // 支払金額：0 円（固定）
                    validityTerm,   // 有効期限
                    paymentRowNo,
                    (int)MoneyKindGrid.Rows[i].Cells[SFSIR02102UA.ctMoneyKindCode].Value,
                    (int)MoneyKindGrid.Rows[i].Cells[SFSIR02102UA.ctMoneyKindDiv].Value,
                    MoneyKindGrid.Rows[i].Cells[SFSIR02102UA.ctMoneyKindName].Value.ToString()
                ));
            }

            if (this.tcboPaymentKind.Items.Count > 0)
            {
                this.tcboPaymentKind.Enabled = true;
                // DEL 2010/04/30 MANTIS対応[15200]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
                //this.tcboPaymentKind.SelectedIndex = 0; // 先頭を選択
                // DEL 2010/04/30 MANTIS対応[15200]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<
                // ADD 2010/04/30 MANTIS対応[15200]：修正呼出時は登録金種をデフォルトで表示 ---------->>>>>
                this.tcboPaymentKind.SelectedIndex = CurrentKindNameIndex;
                // ADD 2010/04/30 MANTIS対応[15200]：修正呼出時は登録金種をデフォルトで表示 ----------<<<<<
            }
            else
            {
                this.tcboPaymentKind.Enabled = false;
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
            MoneyKindItem selectedMoneyKind = (MoneyKindItem)this.tcboPaymentKind.Value;

            // 支払伝票マスタレコードを設定
            SetPaymentSlpRecord(selectedMoneyKind);

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