using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入年間実績照会テキスト出力条件設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入年間実績照会一覧テキスト出力設定UIクラスです。</br>
    /// <br>Programmer : 杜志剛</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/08/19 chenyd</br>
    /// <br>            ・テキスト出力対応13279</br>
    /// <br>Update Note: 2010/09/21 liyp</br>
    /// <br>            ・テキスト出力対応14867</br>
    /// <br>Update Note: 2010/10/09 tianjw</br>
    /// <br>           : #15881 テキスト出力対応</br>
    /// <br>Update Note: 2024/11/22 陳艶丹</br>
    /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// </remarks>
    public partial class PMKOU04110UE : Form
    {
        #region プライベートメン

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>対象年度</summary>
        private int _financialYear = 0;

        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;    

        /// <summary>出力ファイル名</summary>
        private string _settingFileName = string.Empty;

        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = string.Empty;

        /// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = string.Empty;

        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCodeSt = 0;

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCodeEd = 0;

        /// <summary>出力区分</summary>
        private bool _excelFlg;

        /// <summary>企業コード</summary>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;

        /// <summary>フォームクロスフラグ</summary>
        private bool _formcloseFlg = false;

        /// <summary>開始拠点</summary>
        private string _prevInputSectionSt = null;

        /// <summary>終了拠点</summary>
        private string _prevInputSectionEd = null;

        /// <summary>開始仕入先</summary>
        private string _prevInputSupplierSt = null;

        /// <summary>終了仕入先</summary>
        private string _prevInputSupplierEd = null;

        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始仕入先コード「ログオペレーションデータ」</summary>
        private string _suppPrtPprCdSt;
        /// <summary>終了仕入先コード「ログオペレーションデータ」</summary>
        private string _suppPrtPprCdEd;
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

        /// <summary>現会計年度</summary>
        /// <remarks>開始時に自社設定から取得し、変更されません</remarks>
        private int _currentFinancialYear = 0;

        /// <summary>年度開始月</summary>
        private int _companyBeginMonth;

        /// <summary>エラーメッセージ：「翌年度は入力出来ません。」</summary>
        private const string CT_CANNOT_INPUT_FOLLOWING = "翌年度は入力出来ません。";

        /// <summary>エラーメッセージ：「本年度または昨年度のみ入力可能です。」</summary>
        private const string CT_CAN_INPUT_ONLY_TWICE = "本年度または昨年度のみ入力可能です。";

        const int WM_COPYDATA = 0x004A;

        public IntPtr parentHanPtr;

        /// <summary>仕入先年間実績照会 アクセスクラス</summary>
        private SuppYearResultAcs _suppYearResultAcs = null;

        #endregion
        public PMKOU04110UE()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;

            // 初期化時：空白
            this.tNedit_SectionCodeSt.Text = string.Empty;
            this.tNedit_SectionCodeEd.Text = string.Empty;
            
        }

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            PMKOU04110UC userSettingFrm = new PMKOU04110UC();
            userSettingFrm._textFileSettingAcs.Deserialize();
            fileName = userSettingFrm._textFileSettingAcs.SupplierFileName;
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
                    fileName += ".csv";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }

        #region イベント
        /// <summary>
        /// テキスト出力条件設定ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : テキスト出力条件設定ロードイベントです。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMKOU04110UE_Load(object sender, EventArgs e)
        {
            this.ultraButton_OK.ImageList = this._imageList16;
            this.ultraButton_Cancel.ImageList = this._imageList16;

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

            // 対象年月の初期化の設定
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);

            // 仕入年間実績照会アクセスクラス初期化、結果データセット取得
            this._suppYearResultAcs = new SuppYearResultAcs();
            // 会計年度取得
            this._suppYearResultAcs.GetCompanyInf(this._enterpriseCode, out this._currentFinancialYear, out this._companyBeginMonth);
            this._financialYear = this._currentFinancialYear;

            ChangeFileName();
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 杜志剛</br>
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
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 テキスト出力対応</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
                this.DResult = DialogResult.OK;
                FormcloseFlg = true;
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
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14443 テキスト出力対応</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // --------ADD 2010/09/08--------->>>>>
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excelファイル(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            }
            // --------ADD 2010/09/08---------<<<<<
            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 杜志剛</br>
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
                    _prevInputSectionSt = sectionInfo.SectionCode.Trim();
                }
                else
                {
                    this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                    _prevInputSectionEd = sectionInfo.SectionCode.Trim();
                }
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_SelectionCode_Click(object sender, EventArgs e)
        {
            // ガイド起動
            Supplier supplierInfo;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, "0");

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((Control)sender).Name.EndsWith("St"))
                {
                    this.tNedit_SelectionCode_St.SetInt(supplierInfo.SupplierCd);
                    _prevInputSupplierSt = supplierInfo.SupplierCd.ToString();
                }
                else
                {
                    this.tNedit_SelectionCode_Ed.SetInt(supplierInfo.SupplierCd);
                    _prevInputSupplierEd = supplierInfo.SupplierCd.ToString();
                }
            }
        }


        #region 年度変更時
        // --- DEL 2010/08/19 -------------------------------->>>>>
        ///// <summary>
        ///// 年度変更時
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tDateEdit_FinancialYear_Leave(object sender, EventArgs e)
        //{
        //    SendMessage(this.parentHanPtr, WM_COPYDATA, 0, this.tDateEdit_FinancialYear.GetDateYear());

        //}
        // --- DEL 2010/08/19 --------------------------------<<<<<
        #endregion // 年度変更時

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォーカスが変更された時ときに発生します。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 liyp</br>
        /// <br>            ・テキスト出力対応14876</br>
        /// <br>Update Note : 2010/09/26 tianjw</br>
        /// <br>            : Redmine#14876対応</br>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
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
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, "st");
                        if (status)
                        {
                            this.tNedit_SectionCodeSt.Text = code;
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
                            this.tNedit_SectionCodeSt.Text = _prevInputSectionSt;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SectionCodeSt.Text.Trim() == "00")
                                        {
                                            e.NextCtrl = this.uButton_SectionCodeSt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SectionCodeEd;
                                        }
                                        if (!status)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, "ed");
                        if (status)
                        {
                            this.tNedit_SectionCodeEd.Text = code;
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
                            this.tNedit_SectionCodeEd.Text = _prevInputSectionEd;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_SectionCodeEd.Text.Trim() == "00")
                                        {
                                            e.NextCtrl = this.uButton_SectionCodeEd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SelectionCode_St;
                                        }
                                        if (!status)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_SelectionCode_St":
                    {
                        int code = this.tNedit_SelectionCode_St.GetInt();
                        int status = 0;
                        if (code != 0)
                        {
                            // 仕入先
                            Supplier supplierInfo;
                            SupplierAcs supplierAcs = new SupplierAcs();
                            status = supplierAcs.Read(out supplierInfo, this._enterpriseCode, code);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // エラー時
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "開始仕入先コード [" + code + "] に該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_SelectionCode_St.Text = _prevInputSupplierSt;
                                this.tNedit_SelectionCode_St.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // --------UPD 2010/09/21-------->>>>>

                                if (supplierInfo.LogicalDeleteCode == 1)
                                {
                                    // エラー時
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "開始仕入先コード [" + code + "] に該当するデータが存在しません。", -1, MessageBoxButtons.OK);

                                    // コード戻す
                                    this.tNedit_SelectionCode_St.Text = this._prevInputSupplierSt;
                                    this.tNedit_SelectionCode_St.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // --------UPD 2010/09/21--------<<<<<

                                _prevInputSupplierSt = supplierInfo.SupplierCd.ToString();
                            }
                        }
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_SelectionCode_St.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_SelectionCodeSt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SelectionCode_Ed;
                                        }
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_SelectionCode_Ed":
                    {
                        int code = this.tNedit_SelectionCode_Ed.GetInt();
                        int status = 0;
                        if (code != 0)
                        {
                            // 仕入先
                            Supplier supplierInfo;
                            SupplierAcs supplierAcs = new SupplierAcs();
                            status = supplierAcs.Read(out supplierInfo, this._enterpriseCode, code);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // エラー時
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "終了仕入先コード [" + code + "] に該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_SelectionCode_Ed.Text = _prevInputSupplierEd;
                                this.tNedit_SelectionCode_Ed.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                // --------UPD 2010/09/21-------->>>>>

                                if (supplierInfo.LogicalDeleteCode == 1)
                                {
                                    // エラー時
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "終了仕入先コード [" + code + "] に該当するデータが存在しません。", -1, MessageBoxButtons.OK);

                                    // コード戻す
                                    // --------- UPD 2010/09/26 ----------------------------------->>>>>
                                    //this.tNedit_SelectionCode_St.Text = this._prevInputSupplierSt;
                                    //this.tNedit_SelectionCode_St.SelectAll();
                                    this.tNedit_SelectionCode_Ed.Text = this._prevInputSupplierEd;
                                    this.tNedit_SelectionCode_Ed.SelectAll();
                                    // --------- UPD 2010/09/26 -----------------------------------<<<<<
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                                // --------UPD 2010/09/21--------<<<<<

                                _prevInputSupplierEd = supplierInfo.SupplierCd.ToString();
                            }
                        }
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_SelectionCode_Ed.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_SelectionCodeEd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_FinancialYear;
                                        }
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                            }
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
                                default:
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// フォームクロースイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォームクロース時に発生します。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMKOU04110UE_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_formcloseFlg)
                this._dialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <br>Note       : 画面入力チェックです。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/19 chenyd</br>
        /// <br>            ・テキスト出力対応13279</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             ・障害報告 #14643 テキスト出力対応</br>
        private bool InputCheck()
        {
            // 拠点
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                this._sectionCodeSt = "00";
                _prevInputSectionSt = "00";
            }
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                this._sectionCodeEd = "00";
                _prevInputSectionEd = "00";
            }

            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputSectionSt) > Convert.ToInt32(_prevInputSectionEd))
            if (Convert.ToInt32(_prevInputSectionEd) != 0 && (Convert.ToInt32(_prevInputSectionSt) > Convert.ToInt32(_prevInputSectionEd)))
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
            // SelectionCode
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierSt))
            if (string.IsNullOrEmpty(tNedit_SelectionCode_St.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                this._supplierCodeSt = 0; // ADD 2010/09/15
                _prevInputSupplierSt = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierEd))
            if (string.IsNullOrEmpty(tNedit_SelectionCode_Ed.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                this._supplierCodeEd = 0; // ADD 2010/09/15
                _prevInputSupplierEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd))
            if (Convert.ToInt32(_prevInputSupplierEd) != 0 && (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始仕入先コードの値が終了仕入先コードの値を上回っています。",
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
            // --- ADD 2010/08/19 -------------------------------->>>>>
            // 会計年度計算
            if (this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear ||
                this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear - 1)
            {
                this._financialYear = this.tDateEdit_FinancialYear.GetDateYear();
            }
            else if (this.tDateEdit_FinancialYear.GetDateYear() > this._currentFinancialYear)
            {
                // 現年度へ修正
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // 現年度へ修正
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK);

                return false;
            }
            // --- ADD 2010/08/19 --------------------------------<<<<<
            return true;
        }

        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2024/11/22 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private void SetExtratConst()
        {
            // 開始拠点コード
            this.SectionCodeSt = this.tNedit_SectionCodeSt.Text.Trim();
            // 終了拠点コード
            this.SectionCodeEd = this.tNedit_SectionCodeEd.Text.Trim();
            // 開始仕入先コード
            this.SupplierCodeSt = this.tNedit_SelectionCode_St.GetInt();
            // 終了仕入先コード
            this.SupplierCodeEd = this.tNedit_SelectionCode_Ed.GetInt();
            // 対象年度
            this.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();
            // 出力ファイル名
            this.SettingFileName = this.tEdit_SettingFileName.Text.Trim();
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // 開始仕入先コード「ログオペレーションデータ」
            this.SuppPrtPprCodeSt = this.tNedit_SelectionCode_St.Text.Trim();
            // 終了仕入先コード「ログオペレーションデータ」
            this.SuppPrtPprCodeEd = this.tNedit_SelectionCode_Ed.Text.Trim();
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code">返り値</param>
        /// <param name="inputValue">入力値</param>
        /// <param name="startEnd">開始終了区分</param>
        /// <returns>bool</returns>
        /// <br>Note       : 拠点名称取得処理です。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 liyp</br>
        /// <br>            ・テキスト出力対応14876</br>
        private bool ReadSectionCodeAllowZero(out string code, string inputValue, string startEnd)
        {
            // 入力値を取得
            string sectionCode = inputValue.Trim().PadLeft(2, '0');
            code = sectionCode;

            if ("st".Equals(startEnd))
            {
                if (_prevInputSectionSt == sectionCode)
                {
                    this.tNedit_SectionCodeSt.Text = sectionCode;
                    return true;
                }
            }
            else
            {
                if (_prevInputSectionEd == sectionCode)
                {
                    this.tNedit_SectionCodeEd.Text = sectionCode;
                    return true;
                }
 
            }

            // 00:全社
            if (sectionCode == "00")
            {
                sectionCode = "00";
                if ("st".Equals(startEnd))
                    _prevInputSectionSt = sectionCode;
                else
                    _prevInputSectionEd = sectionCode;
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
                    // --------UPD 2010/09/21-------->>>>>
                    //code = sectionInfo.SectionCode.TrimEnd();
                    //name = sectionInfo.SectionGuideSnm.TrimEnd();
                    //return true;

                    if (sectionInfo.LogicalDeleteCode == 1)
                    {
                        if ("st".Equals(startEnd))
                            code = _prevInputSectionSt;
                        else
                            code = _prevInputSectionEd;
                        return false;
                    }
                    else
                    {
                        // --------UPD 2010/09/21--------<<<<<
                        code = sectionInfo.SectionCode.Trim();
                        if ("st".Equals(startEnd))
                            _prevInputSectionSt = code;
                        else
                            _prevInputSectionEd = code;
                        return true;
                    }
                    
                }
                else
                {
                    code = string.Empty;
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                return true;
            }
        }

        #endregion
        #region　プロパティ
        /// <summary>
        /// 対象年月
        /// </summary>
        public int FinancialYear
        {
            get { return this._financialYear; }
            set { this._financialYear = value; }
        }

        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
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
        /// フォーム終了ステータス
        /// </summary>
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { this._dialogResult = value; }
        }

        /// <summary>
        /// 開始拠点コード
        /// </summary>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { this._sectionCodeSt = value; }
        }

        /// <summary>
        /// 終了拠点コード
        /// </summary>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { this._sectionCodeEd = value; }
        }

        /// <summary>
        /// 開始仕入先コード
        /// </summary>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { this._supplierCodeSt = value; }
        }

        /// <summary>
        /// 終了仕入先コード
        /// </summary>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { this._supplierCodeEd = value; }
        }

        /// <summary>
        /// テキスト出力オプション情報
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }

        /// <summary>
        /// フォームクロスフラグ
        /// </summary>
        public bool FormcloseFlg
        {
            get { return this._formcloseFlg; }
            set { this._formcloseFlg = value; }
        }

        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始仕入先コード「ログオペレーションデータ」</summary>
        public string SuppPrtPprCodeSt
        {
            get { return _suppPrtPprCdSt; }
            set { _suppPrtPprCdSt = value; }
        }

        /// <summary>終了仕入先コード「ログオペレーションデータ」</summary>
        public string SuppPrtPprCodeEd
        {
            get { return _suppPrtPprCdEd; }
            set { _suppPrtPprCdEd = value; }
        }
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        #endregion

        /// <summary>
        /// ポップアップ画面から照会画面までのパラメーターの送信
        /// </summary>
        /// <param name="hWnd">hWnd</param>
        /// <param name="Msg">Msg</param>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        /// <returns>int</returns>
        /// <br>Note       : ポップアップ画面から照会画面までのパラメーターの送信を行う</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
               IntPtr hWnd,　　　// handle to destination window
               int Msg,　　　 // message
               int wParam,　// first message parameter
               int lParam // second message parameter
         );
    }
}
