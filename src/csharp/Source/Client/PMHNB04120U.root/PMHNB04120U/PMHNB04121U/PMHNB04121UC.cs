using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先過年度実績照会テキスト出力条件設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先過年度実績照会テキスト出力設定UIクラスです。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/10/09 yangmj</br>
    /// <br>            ・テキスト出力対応 不具合対応#15879</br>
    /// <br>Update Note: 2024/11/22 陳艶丹</br>
    /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// </remarks>
    public partial class PMHNB04121UC : Form
    {
        #region プライベートメン

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;                  

        /// <summary>企業コード</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>出力形式</summary>
        private bool _excelFlg;

        /// <summary>出力ファイル名</summary>
        private string _settingFileName = string.Empty;

        /// <summary>拠点コードリスト</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>SelectionCodeリスト</summary>
        private List<string[]> _selectionCodeList = new List<string[]>();

        /// <summary>拠点名称</summary>
        private string _sectionName = string.Empty;

        /// <summary>SelectionName</summary>
        private string _selectionName = string.Empty;

        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始拠点コード「ログオペレーションデータ」</summary>
        private string _sectionCodeSt = string.Empty;
        /// <summary>終了拠点コード「ログオペレーションデータ」</summary>
        private string _sectionCodeEd = string.Empty;
        /// <summary>開始得意先コード「ログオペレーションデータ」</summary>
        private string _customerCodeSt = string.Empty;
        /// <summary>終了得意先コード「ログオペレーションデータ」</summary>
        private string _customerCodeEd = string.Empty;
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

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

        PrevInputValue _prevInputValue = new PrevInputValue();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// テキスト出力条件設定フォームクラスコンストラクタ
        /// </summary>
        /// <param name="excelFlg">出力形式フラグ</param>
        /// <remarks>
        /// <br>Note       : テキスト出力条件設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMHNB04121UC()
        {
            InitializeComponent();
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

        /// <summary>
        /// フォーム終了ステータス
        /// </summary>
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { this._dialogResult = value; }
        }

        /// <summary>
        /// 出力形式
        /// </summary>
        public bool ExcelFlg
        {
            get { return _excelFlg; }
            set { this._excelFlg = value; }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }

        /// <summary>
        /// SelectionCodeリスト
        /// </summary>
        public List<string[]> SelectionCodeList
        {
            get { return this._selectionCodeList; }
            set { this._selectionCodeList = value; }
        }

        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始拠点コード「ログオペレーションデータ」</summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// <summary>終了拠点コード「ログオペレーションデータ」</summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// <summary>開始得意先コード「ログオペレーションデータ」</summary>
        public string CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// <summary>終了得意先コード「ログオペレーションデータ」</summary>
        public string CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        #endregion

        #region イベント
        /// <summary>
        /// テキスト出力条件設定ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : テキスト出力条件設定ロードイベントです。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void DCHNB04180UE_Load(object sender, EventArgs e)
        {
            this._dialogResult = DialogResult.Cancel;
            this._imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeSt.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.ImageList = this._imageList16;
            this.uButton_SelectionCodeSt.ImageList = this._imageList16;
            this.uButton_SelectionCodeEd.ImageList = this._imageList16;
            this.uButton_FileSelect.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SelectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1;
            // 出力ファイル名の初期化の設定
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();
            this.tNedit_SelectionCode_St.Clear();
            this.tNedit_SelectionCode_Ed.Clear();
            this.tEdit_SettingFileName.Text = this._settingFileName;
            this.ChangeFileName();
        }

        /// <summary>
        /// 選択が変更されたイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : 選択が変更された場合に発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void tComboEditor_TotalDiv_SelectionChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Height = this.tNedit_SectionCodeSt.Size.Height;

            this.uLabel_SelectionCode.Visible = true;
            this.tNedit_SelectionCode_St.Visible = true;
            this.tNedit_SelectionCode_St.ExtEdit.Column = 8;
            this.tNedit_SelectionCode_Ed.Visible = true;
            this.tNedit_SelectionCode_Ed.ExtEdit.Column = 8;
            this.ultraLabel11.Visible = true;
            this.uButton_SelectionCodeSt.Visible = true;
            this.uButton_SelectionCodeEd.Visible = true;

            this.tNedit_SelectionCode_St.NumEdit.ZeroDisp = false;
            this.tNedit_SelectionCode_Ed.NumEdit.ZeroDisp = false;
            // 出力ファイル名の設定
            this.ChangeFileName();
            this.Clear();
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
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
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();   
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SectionCode_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((Control)sender).Name.EndsWith("St"))
                {
                    this.tNedit_SectionCodeSt.Text = sectionInfo.SectionCode.Trim();
                    this._sectionName = sectionInfo.SectionGuideNm;
                    this._prevInputValue.SectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/09/15
                }
                else
                {
                    this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                    this._prevInputValue.SectionCodeEd = this.tNedit_SectionCodeEd.Text; // ADD 2010/09/15
                }
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SelectionCode_Click(object sender, EventArgs e)
        {

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            if (((Control)sender).Name.EndsWith("St"))
            {
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerStSelect);
            }
            else
            {
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerEdSelect);
            }
            customerSearchForm.ShowDialog(this);

        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
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
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <br>Note       : 得意先が選択された時ときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void CustomerSearchForm_CustomerStSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            this.tNedit_SelectionCode_St.SetInt(customerInfo.CustomerCode);
            this._selectionName = customerInfo.Name;
            this._prevInputValue.CustomerCodeSt = this.tNedit_SelectionCode_St.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <br>Note       : 得意先が選択された時ときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void CustomerSearchForm_CustomerEdSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            this.tNedit_SelectionCode_Ed.SetInt(customerInfo.CustomerCode);
            this._selectionName = customerInfo.Name;
            this._prevInputValue.CustomerCodeEd = this.tNedit_SelectionCode_Ed.DataText; // ADD 2010/09/15
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォーカスが変更された時ときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            string errMessage = string.Empty;
            switch (prevCtrl.Name)
            {
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, true);
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
                            this.tNedit_SectionCodeSt.Text = code;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, false);
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
                                                e.NextCtrl = this.tNedit_SelectionCode_St;
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
                            this.tNedit_SectionCodeEd.Text = code;
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SelectionCode_St":
                    {
                        int inputValue = this.tNedit_SelectionCode_St.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, true);
                        if (status)
                        {
                            this.tNedit_SelectionCode_St.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SelectionCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SelectionCode_Ed;
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
                                "開始得意先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SelectionCode_St.Text = code.ToString();
                            this.tNedit_SelectionCode_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tNedit_SelectionCode_Ed":
                    {
                        int inputValue = this.tNedit_SelectionCode_Ed.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, false);
                        if (status)
                        {
                            this.tNedit_SelectionCode_Ed.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SelectionCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SettingFileName;
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
                                "終了得意先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SelectionCode_Ed.Text = code.ToString();
                            this.tNedit_SelectionCode_Ed.SelectAll();
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
                                            e.NextCtrl = ultraButton_OK;
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
        /// フォム閉じるイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォムが閉じる時ときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMHNB04121UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this._dialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 画面のクリア
        /// </summary>
        /// <br>Note       : 画面のクリア処理。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void Clear()
        {
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();

            this.tNedit_SelectionCode_St.Clear();
            this.tNedit_SelectionCode_Ed.Clear();

            this._sectionName = string.Empty;
            this._selectionName = string.Empty;
        }

        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <br>Note       : 画面入力チェックです。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             ・障害報告 #14643 テキスト出力対応</br>
        private bool InputCheck()
        {
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
                return false;
            }

            // 得意先
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text))
            {
                _prevInputValue.CustomerCodeSt = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text))
            {
                _prevInputValue.CustomerCodeEd = "0";
            }
            // 得意先
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd))
            if (Convert.ToInt32(_prevInputValue.CustomerCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                string errMessage = string.Empty;

                errMessage = "開始得意先コードの値が終了得意先コードの値を上回っています。";

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    -1,
                    MessageBoxButtons.OK);
                return false;
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
                return false;
            }
            return true;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code">検索取得拠点コード</param>
        /// <param name="inputValue">画面拠点コード</param>
        /// <param name="stFlg">画面拠点コード(開始)、拠点コード(終了)</param>
        /// <returns>true、false</returns>
        /// <br>Note       : 拠点名称取得処理です。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
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
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ------- UPD 2010/09/21 ----------------------------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    if (sectionInfo.LogicalDeleteCode == 0)
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
                    //if (stFlg)
                    //{
                    //    _prevInputValue.SectionCodeSt = code;
                    //}
                    //else
                    //{
                    //    _prevInputValue.SectionCodeEd = code;
                    //}
                    //return true;
                    // ------- UPD 2010/09/21 -----------------------------<<<<<
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
        /// 得意先名称取得
        /// </summary>
        /// <param name="code">検索取得得意先コード</param>
        /// <param name="inputValue">画面得意先コード</param>
        /// <param name="stFlg">画面得意先コード(開始)、得意先コード(終了)</param>
        /// <returns>true、false</returns>
        /// <br>Note       : 得意先名称取得処理です。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private bool ReadCustomerName(out int code, int inputValue, bool stFlg)
        {
            int customerCode = inputValue;
            code = customerCode;

            if (stFlg)
            {
                if (_prevInputValue.CustomerCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.CustomerCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                {
                    if (stFlg)
                    {
                        _prevInputValue.CustomerCodeSt = customerCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.CustomerCodeEd = customerCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = Convert.ToInt32(_prevInputValue.CustomerCodeSt);
                    }
                    else
                    {
                        code = Convert.ToInt32(_prevInputValue.CustomerCodeEd);
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.CustomerCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.CustomerCodeEd = customerCode.ToString();
                }
                return true;
            }
        }

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            PMHNB04121UB userSettingFrm = new PMHNB04121UB();
            userSettingFrm.AnalysisChartSettingAcs.Deserialize();

            fileName = userSettingFrm.AnalysisChartSettingAcs.CustomInqFileNameValue;

            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (this._excelFlg)
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

        /// <summary>
        /// 前回値保持
        /// </summary>
        /// <br>Note       : 前回値保持処理を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        private struct PrevInputValue
        {
            /// <summary>開始拠点コード</summary>
            private string _sectionCodeSt;
            /// <summary>終了拠点コード</summary>
            private string _sectionCodeEd;
            /// <summary>開始得意先コード</summary>
            private string _customerCodeSt;
            /// <summary>終了得意先コード</summary>
            private string _customerCodeEd;

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

            /// <summary>開始得意先コード</summary>
            public string CustomerCodeSt
            {
                get { return _customerCodeSt; }
                set { _customerCodeSt = value; }
            }

            /// <summary>終了得意先コード</summary>
            public string CustomerCodeEd
            {
                get { return _customerCodeEd; }
                set { _customerCodeEd = value; }
            }
        }

        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        /// <br>Update Note :2024/11/22 陳艶丹</br>
        /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private void SetExtratConst()
        {
            // 対象拠点コード
            List<string[]> sectionCodeList = new List<string[]>();
            // SelectionCodeリスト
            List<string[]> selectionCodeList = new List<string[]>();

            // 拠点の取得
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt()
                || this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
            {
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                {
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    ArrayList relList = new ArrayList();
                    int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in relList)
                        {
                            // --------------------- UPD 2010/09/21 --------------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    sectionArr[1] = sectionInfo.SectionGuideNm;
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeEd.GetInt() == 0 && this.tNedit_SectionCodeSt.GetInt() != 0)
                            {
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode))
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    sectionArr[1] = sectionInfo.SectionGuideNm;
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0)
                            {
                                // 全社指定
                                string[] sectionArr = new string[2];
                                sectionArr[0] = sectionInfo.SectionCode;
                                sectionArr[1] = sectionInfo.SectionGuideNm;
                                sectionCodeList.Add(sectionArr);
                            }
                            //string[] sectionArr = new string[2];
                            //sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm;
                            //sectionCodeList.Add(sectionArr);
                            // --------------------- UPD 2010/09/21 ---------------------------<<<<<
                        }
                    }
                }
                else
                {
                    string[] sectionArr = new string[2];
                    sectionArr[0] = this.tNedit_SectionCodeSt.Text;
                    if (!string.IsNullOrEmpty(this._sectionName))
                    {
                        sectionArr[1] = this._sectionName;
                    }
                    else
                    {
                        // 拠点情報を取得
                        SecInfoSet sectionInfo;
                        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tNedit_SectionCodeSt.Text);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sectionArr[1] = sectionInfo.SectionGuideNm;

                        }
                    }

                    sectionCodeList.Add(sectionArr);
                }
            }
            else
            {
                // --- UPD 2010/09/21 ---------->>>>>
                //string code;
                //SecInfoSet sectionInfo;
                //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                //int status = 0;

                //for (int i = this.tNedit_SectionCodeSt.GetInt(); i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                //{
                //    code = i.ToString();
                //    code = code.Trim().PadLeft(2, '0');
                //    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                //    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEl 2010/09/20
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/20
                //    {
                //        string[] sectionArr = new string[2];
                //        sectionArr[0] = code;
                //        sectionArr[1] = sectionInfo.SectionGuideNm;
                //        sectionCodeList.Add(sectionArr);
                //    }
                //}

                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                ArrayList relList = new ArrayList();
                int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) 
                {
                    foreach (SecInfoSet sectionInfo in relList)
                    {
                        if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode) && this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode) && sectionInfo.LogicalDeleteCode == 0)
                        {
                            string[] sectionArr = new string[2];
                            sectionArr[0] = sectionInfo.SectionCode;
                            sectionArr[1] = sectionInfo.SectionGuideNm;
                            sectionCodeList.Add(sectionArr);
                        }
                    }
                }
                // --- UPD 2010/09/21 ----------<<<<<
            }
            this._sectionCodeList = sectionCodeList;

                // SelectionCodeの取得
            if (this.tNedit_SelectionCode_St.GetInt() == this.tNedit_SelectionCode_Ed.GetInt())
            {
                if (this.tNedit_SelectionCode_St.GetInt() == 0)
                {
                    // SelectionCode全取得
                    this.GetALLSelectionCodeList(out selectionCodeList);
                }
                else
                {
                    string[] selectionArray = new string[2];
                    selectionArray[0] = this.tNedit_SelectionCode_St.Text;
                    if (!string.IsNullOrEmpty(this._selectionName))
                    {
                        selectionArray[1] = this._selectionName;
                    }
                    else
                    {
                        // 得意先
                        CustomerSearchRet[] customerSearchRet;
                        CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                        CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                        customerSearchPara.EnterpriseCode = this._enterpriseCode;
                        customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                        foreach (CustomerSearchRet ret in customerSearchRet)
                        {
                            if (ret.CustomerCode == this.tNedit_SelectionCode_St.GetInt())
                            {
                                selectionArray[1] = ret.Name;
                                break;

                            }
                        }
                    }
                    selectionCodeList.Add(selectionArray);
                }
            }
            else
            {
                this.GetSelectionCodeList(out selectionCodeList, this.tNedit_SelectionCode_St.Text, this.tNedit_SelectionCode_Ed.Text);
            }
            this._selectionCodeList = selectionCodeList;
            // 出力ファイル名
            this._settingFileName = this.tEdit_SettingFileName.Text;

            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // 開始拠点コード「ログオペレーションデータ」
            SectionCodeSt = this.tNedit_SectionCodeSt.Text.Trim();
            // 終了拠点コード「ログオペレーションデータ」
            SectionCodeEd = this.tNedit_SectionCodeEd.Text.Trim();
            // 開始得意先コード「ログオペレーションデータ」
            CustomerCodeSt = this.tNedit_SelectionCode_St.Text.Trim();
            // 終了得意先コード「ログオペレーションデータ」
            CustomerCodeEd = this.tNedit_SelectionCode_Ed.Text.Trim();
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        }

        /// <summary>
        /// SelectionCode全取得
        /// </summary>
        /// <param name="selectionCodeList">SelectionCodeリスト</param>
        /// <br>Note       : SelectionCode全取得処理を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        private void GetALLSelectionCodeList(out List<string[]> selectionCodeList)
        {
            selectionCodeList = new List<string[]>();
            // 得意先
            CustomerSearchRet[] customerSearchRet;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;
            customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

            foreach (CustomerSearchRet ret in customerSearchRet)
            {
                // --------- ADD 2010/09/21 -------------------->>>>>
                if (ret.LogicalDeleteCode == 0) { 
                    string[] customerArray = new string[2];
                    customerArray[0] = ret.CustomerCode.ToString();
                    customerArray[1] = ret.Name;
                    selectionCodeList.Add(customerArray);
                }
                // --------- ADD 2010/09/21 --------------------<<<<<
            }
              
        }

        /// <summary>
        /// SelectionCode全取得
        /// </summary>
        /// <param name="selectionCodeList">SelectionCodeリスト</param>
        /// <param name="selectionCodeSt">SelectionCodeSt</param>
        /// <param name="selectionCodeEd">SelectionCodeEd</param>
        /// <returns>bool</returns>
        /// <br>Note       : SelectionCode全取得処理を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>              Redmine#14876 テキスト出力対応</br>
        private void GetSelectionCodeList(out List<string[]> selectionCodeList, string selectionCodeSt, string selectionCodeEd)
        {
            selectionCodeList = new List<string[]>();
            // 得意先
            CustomerSearchRet[] customerSearchRet;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;
            customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

            foreach (CustomerSearchRet ret in customerSearchRet)
            {
                // ------------UPD 2010/09/21 -------------------------------------->>>>>
                if (string.IsNullOrEmpty(selectionCodeSt))
                {
                    // ---------------------- UPD 2010/09/21 -------------------------------->>>>>
                    //if (ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                    if (ret.CustomerCode <= Convert.ToInt32(selectionCodeEd) && ret.LogicalDeleteCode == 0)
                    // ---------------------- UPD 2010/09/21 --------------------------------<<<<<
                    {
                        string[] customerAyyary = new string[2];
                        customerAyyary[0] = ret.CustomerCode.ToString();
                        customerAyyary[1] = ret.Name;
                        selectionCodeList.Add(customerAyyary);
                    } 
                }
                else if (string.IsNullOrEmpty(selectionCodeEd))
                {
                    // ---------------------- UPD 2010/09/21 -------------------------------->>>>>
                    //if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt))
                    if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.LogicalDeleteCode == 0)
                    // ---------------------- UPD 2010/09/21 --------------------------------<<<<<
                    {
                        string[] customerAyyary = new string[2];
                        customerAyyary[0] = ret.CustomerCode.ToString();
                        customerAyyary[1] = ret.Name;
                        selectionCodeList.Add(customerAyyary);
                    } 
                }
                else
                {
                    // ---------------------- UPD 2010/09/21 -------------------------------->>>>>
                    //if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                    if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd) && ret.LogicalDeleteCode == 0)
                    // ---------------------- UPD 2010/09/21 --------------------------------<<<<<
                    {
                        string[] customerAyyary = new string[2];
                        customerAyyary[0] = ret.CustomerCode.ToString();
                        customerAyyary[1] = ret.Name;
                        selectionCodeList.Add(customerAyyary);
                    } 
                }
                //if (ret.CustomerCode >= Convert.ToInt32(selectionCodeSt) && ret.CustomerCode <= Convert.ToInt32(selectionCodeEd))
                //{
                //    string[] customerAyyary = new string[2];
                //    customerAyyary[0] = ret.CustomerCode.ToString();
                //    customerAyyary[1] = ret.Name;
                //    selectionCodeList.Add(customerAyyary);
                //} 
                // ------------UPD 2010/09/21 --------------------------------------<<<<<
            }
        }
        #endregion

    }
}