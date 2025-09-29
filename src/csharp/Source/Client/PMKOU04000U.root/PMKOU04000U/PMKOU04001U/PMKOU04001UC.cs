using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

using System.IO;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入先電子元帳残高一覧テキスト出力条件設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先電子元帳残高一覧テキスト出力設定UIクラスです。</br>
    /// <br>Programmer : chenyd</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>UpdateNote : 2010/09/21 曹文傑</br>
    /// <br>            ・redmine#14876</br>
    /// <br>Update Note: 2016/01/18 李侠</br>
    /// <br>管理番号   : 11200002-00 2016年2月配信分</br>
    /// <br>             Redmine#48327 仕入先電子元帳残高テキスト出力で対象年月の条件を修正する。</br>
    /// <br>Update Note: 2019/08/19 陳艶丹</br>
    /// <br>           : PMKOBETSU-1379 テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
    public partial class PMKOU04001UC : Form
    {
        #region コンストラクタ
        /// <summary>
        /// テキスト出力条件設定フォームクラスコンストラクタ
        /// </summary>
        /// <param name="excelFlg">出力形式フラグ</param>
        /// <param name="balanceDiv">残高種別</param>
        /// <remarks>
        /// <br>Note       : テキスト出力条件設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMKOU04001UC(bool excelFlg, int balanceDiv)
        {
            InitializeComponent();

            _imageList16 = IconResourceManagement.ImageList16;

            uButton_SectionCodeSt.ImageList = _imageList16;
            uButton_SectionCodeSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SectionCodeEd.ImageList = _imageList16;
            uButton_SectionCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SupplierCdSt.ImageList = _imageList16;
            uButton_SupplierCdSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SupplierCdEd.ImageList = _imageList16;
            uButton_SupplierCdEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_FileSelect.ImageList = _imageList16;
            uButton_FileSelect.Appearance.Image = (int)Size16_Index.STAR1;

            tComboEditor_BalanceDiv.Value = balanceDiv;

            _excelFlg = excelFlg;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccPay("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            // 締め日
            if (prevTotalDay == DateTime.MinValue)
            {
                // 画面へセット
                // 当月(年月度)取得
                DateTime thisYearMonth;
                DateGetAcs _dateGetAcs = DateGetAcs.GetInstance();
                _dateGetAcs.GetThisYearMonth(out thisYearMonth);
                tDateEdit_CheckDateSt.SetDateTime(thisYearMonth);
                tDateEdit_CheckDateEd.SetDateTime(thisYearMonth);
            }
            else
            {
                // 画面へセット
                tDateEdit_CheckDateSt.SetDateTime(prevTotalMonth); // 前回締処理月
                tDateEdit_CheckDateEd.SetDateTime(prevTotalMonth); // 前回締処理月
            }

            ChangeFileName();
        }
        #endregion // コンストラクタ

        #region プライベートメンバ
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        PrevInputValue _prevInputValue = new PrevInputValue();
        // **** ボタン用イメージリスト ****
        private ImageList _imageList16 = null;

        private bool _excelFlg;
        private SuppPrtPprBlnce _suppPrtPprBlnce = new SuppPrtPprBlnce();
        private int _balanceDiv = 0;
        private string _fileName;
        private DialogResult _dialogResult = DialogResult.Cancel;

        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        /// <summary>開始拠点コード</summary>
        private string SectionCdSt;
        /// <summary>終了拠点コード</summary>
        private string SectionCdEd;
        /// <summary>開始仕入先コード</summary>
        private string SuppPrtPprCdSt;
        /// <summary>終了仕入先コード</summary>
        private string SuppPrtPprCdEd;
        /// <summary>開始対象年月</summary>
        private string addUpYearMonthSt;
        /// <summary>終了対象年月</summary>
        private string addUpYearMonthEd;
        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        // --- ADD 2010/10/09 ---------->>>>>
        # region Delegate
        /// <summary>
        /// データを出力
        /// </summary>
        /// <returns>出力結果</returns>
        internal delegate bool OutputDataEvent();
        #endregion

        # region Event
        /// <summary>データを出力イベント</summary>
        internal event OutputDataEvent OutputData;
        #endregion
        // --- ADD 2010/10/09 ----------<<<<<

        #endregion // プライベートメンバ

        #region プロパティ

        // 抽出条件
        public SuppPrtPprBlnce SuppPrtPprBlnce
        {
            get { return _suppPrtPprBlnce; }
            set { _suppPrtPprBlnce = value; }
        }

        // 残高種別
        public int BalanceDiv
        {
            get { return _balanceDiv; }
            set { _balanceDiv = value; }
        }

        // 出力先ファイル名
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        // フォーム終了ステータス
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }

        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        /// <summary>開始拠点コード</summary>
        public string SectionCodeSt
        {
            get { return SectionCdSt; }
            set { SectionCdSt = value; }
        }

        /// <summary>終了拠点コード</summary>
        public string SectionCodeEd
        {
            get { return SectionCdEd; }
            set { SectionCdEd = value; }
        }

        /// <summary>開始仕入先コード</summary>
        public string SuppPrtPprCodeSt
        {
            get { return SuppPrtPprCdSt; }
            set { SuppPrtPprCdSt = value; }
        }

        /// <summary>終了仕入先コード</summary>
        public string SuppPrtPprCodeEd
        {
            get { return SuppPrtPprCdEd; }
            set { SuppPrtPprCdEd = value; }
        }

        /// <summary>開始対象年月</summary>
        public string AddUpYearMonthSt
        {
            get { return addUpYearMonthSt; }
            set { addUpYearMonthSt = value; }
        }

        /// <summary>終了対象年月</summary>
        public string AddUpYearMonthEd
        {
            get { return addUpYearMonthEd; }
            set { addUpYearMonthEd = value; }
        }
        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        #endregion // プロパティ

        #region イベント
        /// <summary>
        /// 開始仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 開始仕入先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド表示
            int status = 0;
            Supplier supplierInfo;
            string sectionCd = string.Empty;
            SupplierAcs _supplierAcs = new SupplierAcs();
            // ガイド表示
            status = _supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, sectionCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 画面上にセット
                this.tNedit_SupplierCd_St.SetInt(supplierInfo.SupplierCd);
                this._prevInputValue.SuppPrtPprCodeSt = this.tNedit_SupplierCd_St.DataText; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// 終了仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 終了仕入先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド表示
            int status = 0;
            Supplier supplierInfo;
            string sectionCd = string.Empty;
            SupplierAcs _supplierAcs = new SupplierAcs();
            // ガイド表示
            status = _supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, sectionCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 画面上にセット
                this.tNedit_SupplierCd_Ed.SetInt(supplierInfo.SupplierCd);
                this._prevInputValue.SuppPrtPprCodeEd = this.tNedit_SupplierCd_Ed.DataText; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// 開始拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 開始拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_SectionCodeSt_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeSt.Text = sectionInfo.SectionCode.Trim();
                this._prevInputValue.SectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// 終了拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 終了拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_SectionCodeEd_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                this._prevInputValue.SectionCodeEd = this.tNedit_SectionCodeEd.Text; // ADD 2010/09/15
            }
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                // 開始拠点コード
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, true);
                        if (status)
                        {
                            this.tNedit_SectionCodeSt.Text = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SectionCodeSt.Text.Trim() == "00")
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeEd;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始拠点コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SectionCodeSt.Text = code;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 終了拠点コード
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, false);
                        if (status)
                        {
                            this.tNedit_SectionCodeEd.Text = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tNedit_SectionCodeEd.Text.Trim() == "00")
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd_St;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "終了拠点コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SectionCodeEd.Text = code;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 開始仕入先コード
                case "tNedit_SupplierCd_St":
                    {
                        int inputValue = this.tNedit_SupplierCd_St.GetInt();
                        int code;
                        bool status = ReadSuppPrtPprName(out code, inputValue, true);
                        if (status)
                        {
                            this.tNedit_SupplierCd_St.SetInt(code);
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SupplierCdSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始仕入先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SupplierCd_St.Text = code.ToString();
                            this.tNedit_SupplierCd_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 終了仕入先コード
                case "tNedit_SupplierCd_Ed":
                    {
                        int inputValue = this.tNedit_SupplierCd_Ed.GetInt();
                        int code;
                        bool status = ReadSuppPrtPprName(out code, inputValue, false);
                        if (status)
                        {
                            this.tNedit_SupplierCd_Ed.SetInt(code);
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SupplierCdEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_CheckDateSt;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "終了仕入先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SupplierCd_Ed.Text = code.ToString();
                            this.tNedit_SupplierCd_Ed.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tEdit_SettingFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = uButton_OK;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : キャンセルボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer  : chenyd</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : OKボタンコントロールがクリックされた時に発生します。</br>
        /// <br>Programmer  : chenyd</br>
        /// <br>Date        : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             ・障害報告 #14643 テキスト出力対応</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            #region 入力チェック
            // 拠点
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                _prevInputValue.SectionCodeSt = "00";
            }
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                _prevInputValue.SectionCodeEd = "00";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd))
            if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始拠点コードの値が終了拠点コードの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text))
            {
                _prevInputValue.SuppPrtPprCodeSt = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text))
            {
                _prevInputValue.SuppPrtPprCodeEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SuppPrtPprCodeSt) > Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd))
            if (Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SuppPrtPprCodeSt) > Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始仕入先コードの値が終了仕入先コードの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            // 対象年月
            int sMonth = (this.tDateEdit_CheckDateSt.GetLongDate() / 100) % 100;
            int sYear = this.tDateEdit_CheckDateSt.GetLongDate() / 10000;
            int eMonth = (this.tDateEdit_CheckDateEd.GetLongDate() / 100) % 100;
            int eYear = this.tDateEdit_CheckDateEd.GetLongDate() / 10000;

            if (sMonth == 0 || sYear == 0)
            {
                TMsgDisp.Show(
              this,
              emErrorLevel.ERR_LEVEL_INFO,
              this.Name,
              "開始対象日付が不正です。",
              -1,
              MessageBoxButtons.OK);
                return;
            }

            if (eMonth == 0 || eYear == 0)
            {
                TMsgDisp.Show(
              this,
              emErrorLevel.ERR_LEVEL_INFO,
              this.Name,
              "終了対象日付が不正です。",
              -1,
              MessageBoxButtons.OK);
                return;
            }

            if (this.tDateEdit_CheckDateSt.GetLongDate() > this.tDateEdit_CheckDateEd.GetLongDate())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始対象日付が終了対象日付を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 出力ファイル名
            if (string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "出力ファイル名を設定してください。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            #endregion  // 入力チェック

            SetSuppPrtPprBlnce();

            this.DResult = DialogResult.OK;
            // --- UPD 2010/10/09 ---------->>>>>
            //this.Close();
            bool outputRslt = true;
            if (this.OutputData != null)
            {
                outputRslt = this.OutputData();
            }
            if (outputRslt)
            {
                this.Close();
            }
            // --- UPD 2010/10/09 ----------<<<<<
        }

        /// <summary>
        /// 残高種別ValueChangeedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 残高種別コントロールのテキストが変更された時に発生します。</br>
        /// <br>Programmer  : chenyd</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void tComboEditor_BalanceDiv_ValueChanged(object sender, EventArgs e)
        {
            ChangeFileName();
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ファイルダイアログコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excelファイル(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            }
            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // イベント

        #region プライベートメンバ
        /// <summary>
        /// 拠点取得処理
        /// </summary>
        /// <param name="code">検索取得拠点コード</param>
        /// <param name="inputValue">画面拠点コード</param>
        /// <param name="stFlg">画面拠点コード(開始)、拠点コード(終了)</param>
        /// <returns>true、false</returns>
        /// <remarks>
        /// <br>Note       : 拠点取得処理します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote : 2010/09/21 曹文傑</br>
        /// <br>            ・redmine#14876</br>
        /// </remarks>
        private bool ReadSectionCodeAllowZero(out string code, string inputValue, bool stFlg)
        {
            // 入力値を取得
            string sectionCode = inputValue.Trim().PadLeft(2, '0');
            code = sectionCode;

            if (stFlg)
            {
                if (_prevInputValue.SectionCodeSt == sectionCode)
                {
                    this.tNedit_SectionCodeSt.Text = sectionCode;
                    return true;
                }
            }
            else
            {
                if (_prevInputValue.SectionCodeEd == sectionCode)
                {
                    this.tNedit_SectionCodeEd.Text = sectionCode;
                    return true;
                }
            }

            // 00:全社
            if (sectionCode == "00")
            {
                sectionCode = "00";
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = sectionCode;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = sectionCode;
                }
                code = sectionCode;
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    code = sectionInfo.SectionCode.TrimEnd();
                    if (stFlg)
                    {
                        _prevInputValue.SectionCodeSt = code;
                    }
                    else
                    {
                        _prevInputValue.SectionCodeEd = code;
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = _prevInputValue.SectionCodeSt;
                    }
                    else
                    {
                        code = _prevInputValue.SectionCodeEd;
                    }
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = code;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = code;
                }
                return true;
            }
        }

        /// <summary>
        /// 仕入先取得
        /// </summary>
        /// <param name="code">検索取得仕入先コード</param>
        /// <param name="inputValue">画面仕入先コード</param>
        /// <param name="stFlg">画面仕入先コード(開始)、仕入先コード(終了)</param>
        /// <returns>true、false</returns>
        /// <remarks>
        /// <br>Note       : 仕入先取得処理します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote : 2010/09/21 曹文傑</br>
        /// <br>            ・redmine#14876</br>
        /// </remarks>
        private bool ReadSuppPrtPprName(out int code, int inputValue, bool stFlg)
        {
            int supplierCode = inputValue;
            code = supplierCode;
            
            if (stFlg)
            {
                if (_prevInputValue.SuppPrtPprCodeSt == supplierCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.SuppPrtPprCodeEd == supplierCode.ToString()) return true;
            }

            if (supplierCode > 0)
            {
                Supplier supplierInfo;
                SupplierAcs supplierAcs = new SupplierAcs();
                int status = supplierAcs.Read(out supplierInfo, this._enterpriseCode, inputValue);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    if (stFlg)
                    {
                        _prevInputValue.SuppPrtPprCodeSt = supplierCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.SuppPrtPprCodeEd = supplierCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = Convert.ToInt32(_prevInputValue.SuppPrtPprCodeSt);
                    }
                    else
                    {
                        code = Convert.ToInt32(_prevInputValue.SuppPrtPprCodeEd);
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.SuppPrtPprCodeSt = supplierCode.ToString();
                }
                else
                {
                    _prevInputValue.SuppPrtPprCodeEd = supplierCode.ToString();
                }
                return true;
            }
        }

        /// <summary>
        /// 前回値保持
        /// </summary>
        /// <remarks>
        /// <br>Note       : 前回値保持処理します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private struct PrevInputValue
        {
            /// <summary>開始拠点コード</summary>
            private string _sectionCodeSt;
            /// <summary>終了拠点コード</summary>
            private string _sectionCodeEd;
            /// <summary>開始仕入先コード</summary>
            private string _suppPrtPprCodeSt;
            /// <summary>終了仕入先コード</summary>
            private string _suppPrtPprCodeEd;

            /// <summary>開始拠点コード</summary>
            public string SectionCodeSt
            {
                get { return _sectionCodeSt; }
                set { _sectionCodeSt = value; }
            }

            /// <summary>終了拠点コード</summary>
            public string SectionCodeEd
            {
                get { return _sectionCodeEd; }
                set { _sectionCodeEd = value; }
            }

            /// <summary>開始仕入先コード</summary>
            public string SuppPrtPprCodeSt
            {
                get { return _suppPrtPprCodeSt; }
                set { _suppPrtPprCodeSt = value; }
            }

            /// <summary>終了仕入先コード</summary>
            public string SuppPrtPprCodeEd
            {
                get { return _suppPrtPprCodeEd; }
                set { _suppPrtPprCodeEd = value; }
            }
        }

        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件セット処理します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote : 2010/09/21 曹文傑</br>
        /// <br>            ・redmine#14876</br>
        /// <br>Update Note: 2016/01/18 李侠</br>
        /// <br>管理番号   : 11200002-00 2016年2月配信分</br>
        /// <br>             Redmine#48327 仕入先電子元帳残高テキスト出力で対象年月の条件を修正する。</br>
        /// <br>Update Note: 2019/08/19 陳艶丹</br>
        /// <br>           : PMKOBETSU-1379 テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// </remarks>
        private void SetSuppPrtPprBlnce()
        {
            // 対象拠点コード
            string[] sectionCode;
            int status = 0;
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt() || this.tNedit_SectionCodeEd.GetInt() == 0)
            {
                // ----------------- UPD 2010/09/19 --------------------------------------------->>>>>
                //if (this.tNedit_SectionCodeEd.GetInt() == 0)
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                // ----------------- UPD 2010/09/19 ---------------------------------------------<<<<<
                {
                    // 全社指定
                    ArrayList retList;
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    int all = 0;
                    status = secInfoSetAcs.Search(out retList, this._enterpriseCode);
                    sectionCode = new string[retList.Count];
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in retList)
                        {
                            // ---------------- UPD 2010/09/19 -------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0)
                            {
                                sectionCode[all] = sectionInfo.SectionCode;
                                all++;
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    sectionCode[all] = sectionInfo.SectionCode;
                                    all++;
                                }
                            }
                            //sectionCode[all] = sectionInfo.SectionCode;
                            //all++;
                            // ---------------- UPD 2010/09/19 --------------------<<<<<
                        }
                    }
                }
                else
                {
                    sectionCode = new string[] { this.tNedit_SectionCodeSt.Text };
                }
                this._suppPrtPprBlnce.SectionCode = sectionCode;
            }
            else
            {
                int i = this.tNedit_SectionCodeSt.GetInt();
                int addCnt = 0;
                string code;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                sectionCode = new string[(this.tNedit_SectionCodeEd.GetInt() - this.tNedit_SectionCodeSt.GetInt()) + 1];
                for (; i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                {
                    code = i.ToString();
                    code = code.Trim().PadLeft(2, '0');
                    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                    {
                        sectionCode[addCnt] = code;
                        addCnt++;
                    }
                }
                string[] retSecCode = new string[addCnt];
                for (i = 0; i < addCnt; i++)
                {
                    retSecCode[i] = sectionCode[i];
                }
                this._suppPrtPprBlnce.SectionCode = retSecCode;
            }

            int dts = this.tDateEdit_CheckDateSt.GetLongDate();
            int dte = this.tDateEdit_CheckDateEd.GetLongDate();
            // --- DEL 2016/01/18 李侠 Redmine#48327 仕入先電子元帳残高テキスト出力で対象年月の条件を修正する ----->>>>>
            //dts++;
            //dte++;
            // --- DEL 2016/01/18 李侠 Redmine#48327 仕入先電子元帳残高テキスト出力で対象年月の条件を修正する -----<<<<<
            // --- ADD 2016/01/18 李侠 Redmine#48327 仕入先電子元帳残高テキスト出力で対象年月の条件を修正する ----->>>>>
            // テキスト出力で対象年月の条件を修正する。画面からの年月+日(固定：01)
            dts = (dts / 100) * 100 + 1;
            dte = (dte / 100) * 100 + 1;
            // --- ADD 2016/01/18 李侠 Redmine#48327 仕入先電子元帳残高テキスト出力で対象年月の条件を修正する -----<<<<<
            this.tDateEdit_CheckDateSt.SetLongDate(dts);
            this.tDateEdit_CheckDateEd.SetLongDate(dte);

            // 開始対象年月
            this._suppPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime();
            // 終了対象年月
            this._suppPrtPprBlnce.Ed_AddUpYearMonth = this.tDateEdit_CheckDateEd.GetDateTime();

            //仕入先(開始)
            this._suppPrtPprBlnce.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
            //仕入先(終了)
            this._suppPrtPprBlnce.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();

            // 残高種別
            this.BalanceDiv = Convert.ToInt32(this.tComboEditor_BalanceDiv.Value);

            // 出力先ファイル名
            this.FileName = this.tEdit_SettingFileName.Text;

            // 企業コード
            this._suppPrtPprBlnce.EnterpriseCode = _enterpriseCode;
            //検索区分
            this._suppPrtPprBlnce.SearchDiv = 1;

            //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
            // 開始拠点コード
            this.SectionCdSt = this.tNedit_SectionCodeSt.Text;
            // 終了拠点コード
            this.SectionCdEd = this.tNedit_SectionCodeEd.Text;
            // 開始仕入先コード
            this.SuppPrtPprCdSt = this.tNedit_SupplierCd_St.Text;
            // 終了仕入先コード
            this.SuppPrtPprCdEd = this.tNedit_SupplierCd_Ed.Text;
            // 開始対象年月
            this.addUpYearMonthSt = this.tDateEdit_CheckDateSt.GetDateYear().ToString() + this.tDateEdit_CheckDateSt.GetDateMonth().ToString("00");
            // 終了対象年月
            this.addUpYearMonthEd = this.tDateEdit_CheckDateEd.GetDateYear().ToString() + this.tDateEdit_CheckDateEd.GetDateMonth().ToString("00");
            //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        }

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力ファイル名変更処理します。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void ChangeFileName()
        {
            PMKOU04004UA userSettingForm = new PMKOU04004UA();
            string fileName = string.Empty;
            string path = string.Empty;
            userSettingForm.Deserialize();
            if (Convert.ToInt32(tComboEditor_BalanceDiv.Value) == 0)
            {
                // 支払
                fileName = userSettingForm.UserSetting.SuplierFileName;
            }
            else
            {
                // 買掛
                fileName = userSettingForm.UserSetting.SuplAccFileName;
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (_excelFlg)
                {
                    // 拡張子をXLSにする
                    fileName += ".xls";
                }
                else
                {
                    // 拡張子をCSVにする
                    fileName += ".CSV";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }
        #endregion // プライベートメンバ
    }
}