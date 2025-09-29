//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上全体設定マスタ
// プログラム概要   ：売上全体設定の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/05/14     修正内容：品名表示対応：品名表示区分の詳細設定を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：田建委
// 修正日    2010/12/03     修正内容：品名表示区分の詳細設定画面にＨＥＬＰボタンの追加
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 品名表示パターン設定画面フォーム
    /// </summary>
    public partial class DCKHN09210UB : Form
    {
        #region 売上全体設定フォームの品名表示区分

        /// <summary>売上全体設定フォームの品名表示区分</summary>
        private TComboEditor _ownerPartsNameDspDivCd;
        /// <summary>売上全体設定フォームの品名表示区分を取得または設定します。</summary>
        private TComboEditor OwnerPartsNameDspDivCd
        {
            get { return _ownerPartsNameDspDivCd; }
            set { _ownerPartsNameDspDivCd = value; }
        }

        #endregion // 売上全体設定フォームの品名表示区分

        #region 品名表示区分

        /// <summary>
        /// 品名表示区分が任意設定であるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :任意設定です。<br/>
        /// <c>false</c>:任意設定ではありません。
        /// </returns>
        private bool IsOptionSetting()
        {
            return this.tcboPartsNameDspDivCd.SelectedIndex.Equals((int)SalesTtlSt.PartsNameDspDivCdValue.Option);
        }

        /// <summary>
        /// [品名表示区分]プルダウンのValueChangeイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tcboPartsNameDspDivCd_ValueChanged(object sender, EventArgs e)
        {
            EnabledPatternControlsByPartsNameDspDivCd();
        }

        /// <summary>検索時の品名表示区分値</summary>
        private readonly int[] _prtsNmDspDivCdValues = new int[] {
            (int)SalesTtlSt.PrtsNmDspDivCdValue.None,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.GoodsMaster,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.PartsMaster,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.SearchedGoodsNameMaster,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.BLCodeMaster
        };
        /// <summary>検索時の品名表示区分値を取得します。</summary>
        private int[] PrtsNmDspDivCdValues { get { return _prtsNmDspDivCdValues; } }

        #endregion // 品名表示区分

        #region BLコード検索品名表示区分

        #region BLコード検索品名表示区分1

        /// <summary>BLコード検索品名表示区分1</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _blCdPrtsNmDspDivCd1;
        /// <summary>BLコード検索品名表示区分1を取得または設定します。</summary>
        public int BLCdPrtsNmDspDivCd1
        {
            get { return _blCdPrtsNmDspDivCd1; }
            private set { _blCdPrtsNmDspDivCd1 = value; }
        }

        #endregion // BLコード検索品名表示区分1

        #region BLコード検索品名表示区分2

        /// <summary>BLコード検索品名表示区分2</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _blCdPrtsNmDspDivCd2;
        /// <summary>BLコード検索品名表示区分2を取得または設定します。</summary>
        public int BLCdPrtsNmDspDivCd2
        {
            get { return _blCdPrtsNmDspDivCd2; }
            private set { _blCdPrtsNmDspDivCd2 = value; }
        }

        #endregion // BLコード検索品名表示区分2

        #region BLコード検索品名表示区分3

        /// <summary>BLコード検索品名表示区分3</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _blCdPrtsNmDspDivCd3;
        /// <summary>BLコード検索品名表示区分3を取得または設定します。</summary>
        public int BLCdPrtsNmDspDivCd3
        {
            get { return _blCdPrtsNmDspDivCd3; }
            private set { _blCdPrtsNmDspDivCd3 = value; }
        }

        #endregion // BLコード検索品名表示区分3

        #region BLコード検索品名表示区分4

        /// <summary>BLコード検索品名表示区分4</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _blCdPrtsNmDspDivCd4;
        /// <summary>BLコード検索品名表示区分4を取得または設定します。</summary>
        public int BLCdPrtsNmDspDivCd4
        {
            get { return _blCdPrtsNmDspDivCd4; }
            private set { _blCdPrtsNmDspDivCd4 = value; }
        }

        #endregion // BLコード検索品名表示区分4

        /// <summary>BLコード検索品名表示区分コントロールのリスト</summary>
        private readonly List<TComboEditor> _blPartsNameDspDivCdControlList = new List<TComboEditor>();
        /// <summary>BLコード検索品名表示区分コントロールのリストを取得します。</summary>
        private List<TComboEditor> BLPartsNameDspDivCdControlList { get { return _blPartsNameDspDivCdControlList; } }

        /// <summary>
        /// BLコード検索品名表示区分コントロールのリストを初期化します。
        /// </summary>
        private void InitializeBLPartsNameDspDivCdControlList()
        {
            BLPartsNameDspDivCdControlList.Clear();
            {
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd1);   // BLコード検索品名表示区分1
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd2);   // BLコード検索品名表示区分2
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd3);   // BLコード検索品名表示区分3
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd4);   // BLコード検索品名表示区分4
            }
        }

        #endregion // BLコード検索品名表示区分

        #region 品番検索品名表示区分

        #region 品番検索品名表示区分1

        /// <summary>品番検索品名表示区分1</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _gdNoPrtsNmDspDivCd1;
        /// <summary>品番検索品名表示区分1を取得または設定します。</summary>
        public int GdNoPrtsNmDspDivCd1
        {
            get { return _gdNoPrtsNmDspDivCd1; }
            private set { _gdNoPrtsNmDspDivCd1 = value; }
        }

        #endregion // 品番検索品名表示区分1

        #region 品番検索品名表示区分2

        /// <summary>品番検索品名表示区分2</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _gdNoPrtsNmDspDivCd2;
        /// <summary>品番検索品名表示区分2を取得または設定します。</summary>
        public int GdNoPrtsNmDspDivCd2
        {
            get { return _gdNoPrtsNmDspDivCd2; }
            private set { _gdNoPrtsNmDspDivCd2 = value; }
        }

        #endregion // 品番検索品名表示区分2

        #region 品番検索品名表示区分3

        /// <summary>品番検索品名表示区分3</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _gdNoPrtsNmDspDivCd3;
        /// <summary>品番検索品名表示区分3を取得または設定します。</summary>
        public int GdNoPrtsNmDspDivCd3
        {
            get { return _gdNoPrtsNmDspDivCd3; }
            private set { _gdNoPrtsNmDspDivCd3 = value; }
        }

        #endregion // 品番検索品名表示区分3

        #region 品番検索品名表示区分4

        /// <summary>品番検索品名表示区分4</summary>
        /// <remarks>0:無し/1:商品マスタ/2:部品マスタ/3:検索品名マスタ/4:BLコードマスタ</remarks>
        private int _gdNoPrtsNmDspDivCd4;
        /// <summary>品番検索品名表示区分4を取得または設定します。</summary>
        public int GdNoPrtsNmDspDivCd4
        {
            get { return _gdNoPrtsNmDspDivCd4; }
            private set { _gdNoPrtsNmDspDivCd4 = value; }
        }

        #endregion // 品番検索品名表示区分4

        /// <summary>品番検索品名表示区分コントロールのリスト</summary>
        private readonly List<TComboEditor> _gdNoPrtsNmDspDivCdControlList = new List<TComboEditor>();
        /// <summary>品番検索品名表示区分コントロールのリストを取得します。</summary>
        private List<TComboEditor> GdNoPrtsNmDspDivCdControlList { get { return _gdNoPrtsNmDspDivCdControlList; } }

        /// <summary>
        /// 品番検索品名表示区分コントロールのリストを初期化します。
        /// </summary>
        private void InitializeGdNoPrtsNmDspDivCdControlList()
        {
            GdNoPrtsNmDspDivCdControlList.Clear();
            {
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd1);    // 品番検索品名表示区分1
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd2);    // 品番検索品名表示区分2
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd3);    // 品番検索品名表示区分3
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd4);    // 品番検索品名表示区分4
            }
        }

        #endregion // 品番検索品名表示区分

        #region 優良部品検索品名使用区分

        /// <summary>優良部品検索品名使用区分</summary>
        /// <remarks>0:使用/1:未使用</remarks>
        private int _prmPrtsNmUseDivCd;
        /// <summary>優良部品検索品名使用区分</summary>
        public int PrmPrtsNmUseDivCd
        {
            get { return _prmPrtsNmUseDivCd; }
            private set { _prmPrtsNmUseDivCd = value; }
        }

        #endregion // 優良部品検索品名使用区分

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public DCKHN09210UB()
        {
            #region Designer Code

            InitializeComponent();

            #endregion // Designer Code
        }

        #endregion // Constructor

        #region 売上全体設定

        /// <summary>
        /// 品名表示パターン（BLコード検索品名表示区分、品番検索品名表示区分、優良部品検索品名区分）を設定します。
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定</param>
        public void SetPatterns(SalesTtlSt salesTtlSt)
        {
            #region Guard Phrase

            if (salesTtlSt == null) return;

            #endregion // Guard Phrase

            BLCdPrtsNmDspDivCd1 = salesTtlSt.BLCdPrtsNmDspDivCd1;   // BLコード検索品名表示区分1
            BLCdPrtsNmDspDivCd2 = salesTtlSt.BLCdPrtsNmDspDivCd2;   // BLコード検索品名表示区分2
            BLCdPrtsNmDspDivCd3 = salesTtlSt.BLCdPrtsNmDspDivCd3;   // BLコード検索品名表示区分3
            BLCdPrtsNmDspDivCd4 = salesTtlSt.BLCdPrtsNmDspDivCd4;   // BLコード検索品名表示区分4
            GdNoPrtsNmDspDivCd1 = salesTtlSt.GdNoPrtsNmDspDivCd1;   // 品番検索品名表示区分1
            GdNoPrtsNmDspDivCd2 = salesTtlSt.GdNoPrtsNmDspDivCd2;   // 品番検索品名表示区分2
            GdNoPrtsNmDspDivCd3 = salesTtlSt.GdNoPrtsNmDspDivCd3;   // 品番検索品名表示区分3
            GdNoPrtsNmDspDivCd4 = salesTtlSt.GdNoPrtsNmDspDivCd4;   // 品番検索品名表示区分4
            PrmPrtsNmUseDivCd = salesTtlSt.PrmPrtsNmUseDivCd;       // 優良部品検索品名使用区分
        }

        /// <summary>
        /// 売上全体設定へ品名表示パターンを設定します。
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定</param>
        public void SetToSalesTtlSt(SalesTtlSt salesTtlSt)
        {
            #region Guard Phrase

            if (salesTtlSt == null) return;

            #endregion // Guard Phrase

            salesTtlSt.BLCdPrtsNmDspDivCd1 = BLCdPrtsNmDspDivCd1;   // BLコード検索品名表示区分1
            salesTtlSt.BLCdPrtsNmDspDivCd2 = BLCdPrtsNmDspDivCd2;   // BLコード検索品名表示区分2
            salesTtlSt.BLCdPrtsNmDspDivCd3 = BLCdPrtsNmDspDivCd3;   // BLコード検索品名表示区分3
            salesTtlSt.BLCdPrtsNmDspDivCd4 = BLCdPrtsNmDspDivCd4;   // BLコード検索品名表示区分4
            salesTtlSt.GdNoPrtsNmDspDivCd1 = GdNoPrtsNmDspDivCd1;   // 品番検索品名表示区分1
            salesTtlSt.GdNoPrtsNmDspDivCd2 = GdNoPrtsNmDspDivCd2;   // 品番検索品名表示区分2
            salesTtlSt.GdNoPrtsNmDspDivCd3 = GdNoPrtsNmDspDivCd3;   // 品番検索品名表示区分3
            salesTtlSt.GdNoPrtsNmDspDivCd4 = GdNoPrtsNmDspDivCd4;   // 品番検索品名表示区分4
            salesTtlSt.PrmPrtsNmUseDivCd = PrmPrtsNmUseDivCd;       // 優良部品検索品名使用区分
        }

        #endregion // 売上全体設定

        #region Form

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <remarks>
        /// 品名表示パターン設定<c>SetPatterns()</c>を先に呼出す必要があります。
        /// </remarks>
        /// <param name="ownerPartsNameDspDivCd">売上全体設定フォームの品名表示区分</param>
        private void Initialize(TComboEditor ownerPartsNameDspDivCd)
        {
            // BLコード検索品名表示区分コントロールのリストを初期化
            InitializeBLPartsNameDspDivCdControlList();

            // 品番検索品名表示区分コントロールのリストを初期化
            InitializeGdNoPrtsNmDspDivCdControlList();

            // 売上全体設定の品名表示区分を保持
            if (ownerPartsNameDspDivCd != null)
            {
                OwnerPartsNameDspDivCd = ownerPartsNameDspDivCd;
                this.tcboPartsNameDspDivCd.SelectedIndex = OwnerPartsNameDspDivCd.SelectedIndex;
                EnabledPatternControlsByPartsNameDspDivCd();
            }

            // 画面を初期化
            this.tcboBLCdPrtsNmDspDivCd1.SelectedIndex = BLCdPrtsNmDspDivCd1;   // BLコード検索品名表示区分1
            this.tcboBLCdPrtsNmDspDivCd2.SelectedIndex = BLCdPrtsNmDspDivCd2;   // BLコード検索品名表示区分2
            this.tcboBLCdPrtsNmDspDivCd3.SelectedIndex = BLCdPrtsNmDspDivCd3;   // BLコード検索品名表示区分3
            this.tcboBLCdPrtsNmDspDivCd4.SelectedIndex = BLCdPrtsNmDspDivCd4;   // BLコード検索品名表示区分4
            this.tcboGdNoPrtsNmDspDivCd1.SelectedIndex = GdNoPrtsNmDspDivCd1;   // 品番検索品名表示区分1
            this.tcboGdNoPrtsNmDspDivCd2.SelectedIndex = GdNoPrtsNmDspDivCd2;   // 品番検索品名表示区分2
            this.tcboGdNoPrtsNmDspDivCd3.SelectedIndex = GdNoPrtsNmDspDivCd3;   // 品番検索品名表示区分3
            this.tcboGdNoPrtsNmDspDivCd4.SelectedIndex = GdNoPrtsNmDspDivCd4;   // 品番検索品名表示区分4
            this.tcboPrmPrtsNmUseDivCd.SelectedIndex = PrmPrtsNmUseDivCd;       // 優良部品検索品名使用区
        }

        /// <summary>
        /// ダイアログ表示します。
        /// </summary>
        /// <param name="ownerPartsNameDspDivCd">売上全体設定フォームの品名表示区分</param>
        /// <returns>操作結果</returns>
        public DialogResult ShowDialog(TComboEditor ownerPartsNameDspDivCd)
        {
            Initialize(ownerPartsNameDspDivCd);

            return ShowDialog();
        }

        /// <summary>
        /// 品名表示パターン設定画面フォームのShownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void DCKHN09210UB_Shown(object sender, EventArgs e)
        {
            // フォーカスの初期位置
            this.tcboPartsNameDspDivCd.Focus();
        }

        #endregion // Form

        /// <summary>
        /// 品名表示区分に応じて品名表示パターンの入力コントロールの有効フラグを設定します。
        /// </summary>
        private void EnabledPatternControlsByPartsNameDspDivCd()
        {
            // 品名表示パターンは任意設定にときに有効
            bool enabled = IsOptionSetting();

            // BLコード検索品名表示区分
            BLPartsNameDspDivCdControlList.ForEach(delegate(TComboEditor blPartsNameDspDivCdControl)
            {
                blPartsNameDspDivCdControl.Enabled = enabled;
            });

            // 品番検索品名表示区分
            GdNoPrtsNmDspDivCdControlList.ForEach(delegate(TComboEditor gdNoPrtsNmDspDivCdControl)
            {
                gdNoPrtsNmDspDivCdControl.Enabled = enabled;
            });

            // 優良部品検索品名使用区分
            this.tcboPrmPrtsNmUseDivCd.Enabled = enabled;
        }

        #region キャンセル

        /// <summary>
        /// [キャンセル]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnCancel_Click(object sender, EventArgs e)
        {
            // 表示した時と画面の区分値が変更されている場合は、確認メッセージを表示後、画面を閉じる
            SynchronizePartsNameDspDivCdIf();
            this.Close();
        }

        /// <summary>
        /// 表示した時と画面の品名表示区分値が変更されている場合は、確認メッセージを表示後、品名表示区分値の同期をとります。
        /// </summary>
        private void SynchronizePartsNameDspDivCdIf()
        {
            if (this.tcboPartsNameDspDivCd.SelectedIndex.Equals(OwnerPartsNameDspDivCd.SelectedIndex)) return;

            DialogResult result = MessageBox.Show(
                "品名表示区分の変更を売上全体設定に反映しますか？",
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result.Equals(DialogResult.Yes))
            {
                OwnerPartsNameDspDivCd.SelectedIndex = this.tcboPartsNameDspDivCd.SelectedIndex;
            }
        }

        #endregion // キャンセル

        #region OK

        /// <summary>
        /// [OK]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnOK_Click(object sender, EventArgs e)
        {
            // 品名表示区分が任意設定ではない場合、品名表示パターンは有効としないので、
            // 品名表示区分のみを同期させて終了
            if (!IsOptionSetting())
            {
                OwnerPartsNameDspDivCd.SelectedIndex = this.tcboPartsNameDspDivCd.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (ValidateInput())
            {
                // 品名表示パターンの設定を決定
                BLCdPrtsNmDspDivCd1 = this.tcboBLCdPrtsNmDspDivCd1.SelectedIndex;   // BLコード検索品名表示区分1
                BLCdPrtsNmDspDivCd2 = this.tcboBLCdPrtsNmDspDivCd2.SelectedIndex;   // BLコード検索品名表示区分2
                BLCdPrtsNmDspDivCd3 = this.tcboBLCdPrtsNmDspDivCd3.SelectedIndex;   // BLコード検索品名表示区分3
                BLCdPrtsNmDspDivCd4 = this.tcboBLCdPrtsNmDspDivCd4.SelectedIndex;   // BLコード検索品名表示区分4
                GdNoPrtsNmDspDivCd1 = this.tcboGdNoPrtsNmDspDivCd1.SelectedIndex;   // 品番検索品名表示区分1
                GdNoPrtsNmDspDivCd2 = this.tcboGdNoPrtsNmDspDivCd2.SelectedIndex;   // 品番検索品名表示区分2
                GdNoPrtsNmDspDivCd3 = this.tcboGdNoPrtsNmDspDivCd3.SelectedIndex;   // 品番検索品名表示区分3
                GdNoPrtsNmDspDivCd4 = this.tcboGdNoPrtsNmDspDivCd4.SelectedIndex;   // 品番検索品名表示区分4
                PrmPrtsNmUseDivCd = this.tcboPrmPrtsNmUseDivCd.SelectedIndex;       // 優良部品検索品名使用区分

                // 品名表示区分を同期させて終了
                OwnerPartsNameDspDivCd.SelectedIndex = this.tcboPartsNameDspDivCd.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // エラー処理
            MessageBox.Show("設定が重複しています。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 入力を検証します。
        /// </summary>
        /// <param name="ownerPartsNameDspDivCd">売上全体設定フォームの品名表示区分</param>
        /// <returns>
        /// <c>true</c> :正常です。<br/>
        /// <c>false</c>:異常があります。
        /// </returns>
        public bool ValidateInput(TComboEditor ownerPartsNameDspDivCd)
        {
            Initialize(ownerPartsNameDspDivCd);

            return ValidateInput();
        }

        /// <summary>
        /// 入力を検証します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :正常です。<br/>
        /// <c>false</c>:異常があります。
        /// </returns>
        private bool ValidateInput()
        {
            // 任意設定の場合のみ検証
            if (!IsOptionSetting()) return true;

            // 重複した設定はNG
            TComboEditor sameValueItem = FindFirstSameItem(BLPartsNameDspDivCdControlList);
            if (sameValueItem != null)
            {
                sameValueItem.Focus();
                return false;
            }
            sameValueItem = FindFirstSameItem(GdNoPrtsNmDspDivCdControlList);
            if (sameValueItem != null)
            {
                sameValueItem.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 全て「無し」であるか判断します。
        /// </summary>
        /// <param name="prtsNmDspDivCdList">検索時の品名表示区分コントロールのリスト</param>
        /// <returns>
        /// <c>true</c> :全て「無し」です。<br/>
        /// <c>false</c>:「無し」以外の設定が存在します。
        /// </returns>
        private static bool IsAllNone(List<TComboEditor> prtsNmDspDivCdList)
        {
            List<TComboEditor> foundPrtsNmDspDivCdList = prtsNmDspDivCdList.FindAll(delegate(TComboEditor item)
            {
                return item.SelectedIndex.Equals((int)SalesTtlSt.PrtsNmDspDivCdValue.None);
            });
            return foundPrtsNmDspDivCdList.Count.Equals(prtsNmDspDivCdList.Count);
        }

        /// <summary>
        /// 最初に検索された重複した設定値をもつ品名表示区分コントロールを取得します。
        /// </summary>
        /// <param name="prtsNmDspDivCdList">検索時の品名表示区分コントロールのリスト</param>
        /// <returns>
        /// 最初に検索された重複した設定値をもつ品名表示区分コントロール
        /// （重複していない場合、<c>null</c>を返します）
        /// </returns>
        private static TComboEditor FindFirstSameItem(List<TComboEditor> prtsNmDspDivCdList)
        {
            Dictionary<int, TComboEditor> checkedMap = new Dictionary<int, TComboEditor>();
            {
                foreach (TComboEditor checkingItem in prtsNmDspDivCdList)
                {
                    if (checkedMap.ContainsKey(checkingItem.SelectedIndex))
                    {
                        return checkingItem;
                    }
                    else
                    {
                        checkedMap.Add(checkingItem.SelectedIndex, checkingItem);
                    }
                }
            }
            return null;
        }

        #endregion // OK

        // ---------- ADD 2010/12/03 --------------------------->>>>>
        #region HELP
        /// <summary>品名表示パターン設定(HELP)画面</summary>
        private DCKHN09210UC _partsNameDspPatternHelpForm;
        /// <summary>品名表示パターン設定(HELP)画面を取得します。</summary>
        private DCKHN09210UC PartsNameDspPatternHelpForm
        {
            get
            {
                if (_partsNameDspPatternHelpForm == null) _partsNameDspPatternHelpForm = new DCKHN09210UC();
                return _partsNameDspPatternHelpForm;
            }
        }

        /// <summary>
        /// [HELP]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ubtnHelp_Click(object sender, EventArgs e)
        {
            PartsNameDspPatternHelpForm.ShowDialog();
        }
        #endregion //HELP
        // ---------- ADD 2010/12/03 ---------------------------<<<<<
    }
}