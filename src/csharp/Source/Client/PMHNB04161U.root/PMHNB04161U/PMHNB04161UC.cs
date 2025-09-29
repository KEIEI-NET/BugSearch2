//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/07/20  修正内容 : テキスト出力
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/17  修正内容 : 障害ID:13038 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/09/15  修正内容 : 障害報告 #14643 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhume
// 修 正 日  2010/09/21  修正内容 : 障害報告 #14876 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/10/09  修正内容 : 障害ID:15880対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹
// 修 正 日  2024/11/29  修正内容 : PMKOBETSU-4368 2024年PKG格上のログ出力対応
//----------------------------------------------------------------------------//
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
    /// 担当者別実績照会テキスト出力条件設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者別実績照会覧テキスト出力設定UIクラスです。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010/07/20</br>
    /// <br>Update Note: 2010/08/17、 2010/08/20 chenyd</br>
    /// <br>            ・障害ID:13038 テキスト出力対応</br>
    /// <br>Update Note: 2024/11/29 陳艶丹</br>
    /// <br>            ・PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// </remarks>
    public partial class PMHNB04161UC : Form
    {
        #region プライベートメン

        /// <summary>従業員マスタアクセスクラス</summary>
        /// <remarks></remarks>
        private EmployeeAcs _employeeAcs;

        //日付取得部品
        private DateGetAcs _dateGet;

        private DialogResult _dialogResult = DialogResult.Cancel;

        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;                  

        /// <summary>企業コード</summary>
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        /// <summary>テキスト/エクセル区分</summary>
        private bool _excelFlg;

        /// <summary>参照区分</summary>
        private int _referDiv = 0;

        /// <summary>期間区分</summary>
        private int _duringDiv = 0;

        /// <summary>開始期間</summary>
        private DateTime _duringSt = new DateTime();

        /// <summary>終了期間</summary>
        private DateTime _duringEd = new DateTime();

        /// <summary>開始期間(年月)</summary>
        private int _duringYmSt = 0;

        /// <summary>終了期間(年月)</summary>
        private int _duringYmEd = 0;

        /// <summary>出力ファイル名</summary>
        private string _settingFileName = string.Empty;
        private string _settingFileNameSeller = string.Empty; // ADD 2010/10/09
        private string _settingFileNamePublisher = string.Empty; // ADD 2010/10/09

        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = string.Empty;

        /// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = string.Empty;

        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始拠点コード「ログオペレーションデータ」</summary>
        private string _sectionCodeLogSt = string.Empty;
        /// <summary>終了拠点コード「ログオペレーションデータ」</summary>
        private string _sectionCodeLogEd = string.Empty;
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

        /// <summary>開始担当者コード</summary>
        private string _employeeCodeSt = string.Empty;

        /// <summary>終了担当者コード</summary>
        private string _employeeCodeEd = string.Empty;

        /// <summary>開始拠点</summary>
        private string _prevInputSectionSt = null;

        /// <summary>終了拠点</summary>
        private string _prevInputSectionEd = null;

        /// <summary>開始仕入先</summary>
        private string _prevInputSupplierSt = null;

        /// <summary>終了仕入先</summary>
        private string _prevInputSupplierEd = null;

        /// <summary>拠点コードリスト</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();

        /// <summary>SelectionCodeリスト</summary>
        private List<string[]> _selectionCodeList = new List<string[]>();

        /// <summary>拠点名称</summary>
        private string _sectionName = string.Empty;

        /// <summary>SelectionName</summary>
        private string _selectionName = string.Empty;

        /// <summary>フォームクロスフラグ</summary>
        private bool _formcloseFlg = false;

        // --- ADD 2010/10/09 ---------->>>
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
        // --- ADD 2010/10/09 ----------<<<

        /// <summary> 名称 [担当者] </summary>
        private const string SALESINPUT_NAME = "担当者";
        /// <summary> 名称 [受注者] </summary>
        private const string FRONTEMPLOYEE_SECTION_NAME = "受注者";
        /// <summary> 名称 [発行者] </summary>
        private const string SALESEMPLOYEE_NAME = "発行者";

        //エラー条件メッセージ
        /// <summary> 必須入力チェック</summary>
        const string MESSAGE_NoInput = "を入力してください。";
        const string ct_InputError = "の指定に誤りがあります。";
        const string ct_NoInput = "を入力して下さい。";
        const string ct_RangeError = "の範囲指定に誤りがあります。";
        const string ct_RangeOverError = "は締日より１ヶ月の範囲内で入力して下さい。";

        const string ct_RangeYearMonthOverError = "は12か月以内で入力して下さい。";
        const string ct_NotOnYearError = "が同一年度内ではありません。";
        const string ct_NotOnMonthError = "が同一月内ではありません。";
        #endregion

        #region コンストラクタ
        /// <summary>
        /// テキスト出力条件設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力条件設定フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public PMHNB04161UC()
        {
            InitializeComponent();

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
        }
        #endregion

        #region プロパティ

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

        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        /// <summary>開始拠点コード「ログオペレーションデータ」</summary>
        public string SectionCodeLogSt
        {
            get { return _sectionCodeLogSt; }
            set { _sectionCodeLogSt = value; }
        }

        /// <summary>終了拠点コード「ログオペレーションデータ」</summary>
        public string SectionCodeLogEd
        {
            get { return _sectionCodeLogEd; }
            set { _sectionCodeLogEd = value; }
        }
        //--- ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<

        /// <summary>
        /// 参照区分
        /// </summary>
        public int ReferDiv
        {
            get { return this._referDiv; }
            set { this._referDiv = value; }
        }

        /// <summary>
        /// 期間区分
        /// </summary>
        public int DuringDiv
        {
            get { return this._duringDiv; }
            set { this._duringDiv = value; }
        }

        /// <summary>
        /// 開始期間
        /// </summary>
        public DateTime DuringSt
        {
            get { return this._duringSt; }
            set { this._duringSt = value; }
        }

        /// <summary>
        /// 終了期間
        /// </summary>
        public DateTime DuringEd
        {
            get { return this._duringEd; }
            set { this._duringEd = value; }
        }

        /// <summary>
        /// 開始期間(年月)
        /// </summary>
        public int DuringYmSt
        {
            get { return this._duringYmSt; }
            set { this._duringYmSt = value; }
        }

        /// <summary>
        /// 終了期間(年月)
        /// </summary>
        public int DuringYmEd
        {
            get { return this._duringYmEd; }
            set { this._duringYmEd = value; }
        }

        /// <summary>
        /// 開始担当者コード
        /// </summary>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { this._employeeCodeSt = value; }
        }

        /// <summary>
        /// 終了担当者コード
        /// </summary>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { this._employeeCodeEd = value; }
        }

        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string SettingFileName
        {
            get { return _settingFileName; }
            set { this._settingFileName = value; }
        }

        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>
        /// 出力ファイル名（受注者）
        /// </summary>
        public string SettingFileNameSeller
        {
            get { return _settingFileNameSeller; }
            set { this._settingFileNameSeller = value; }
        }

        /// <summary>
        /// 出力ファイル名（発行者）
        /// </summary>
        public string SettingFileNamePublisher
        {
            get { return _settingFileNamePublisher; }
            set { this._settingFileNamePublisher = value; }
        }
        // ---ADD 2010/10/09 ---------------------<<<

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

        /// <summary>
        /// フォームクロスフラグ
        /// </summary>
        public bool FormcloseFlg
        {
            get { return this._formcloseFlg; }
            set { this._formcloseFlg = value; }
        }
        #endregion

        #region イベント
        /// <summary>
        /// テキスト出力条件設定ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : テキスト出力条件設定ロードイベントです。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMHNB04161UC_Load(object sender, EventArgs e)
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeSt.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.ImageList = this._imageList16;
            this.uButton_St_EmployeeCode.ImageList = this._imageList16;
            this.ultraButton_Ed_EmployeeCode.ImageList = this._imageList16;
            this.uButton_FileSelect.ImageList = this._imageList16;
            this.uButton_SectionCodeEd.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SectionCodeSt.Appearance.Image = Size16_Index.STAR1;
            this.uButton_St_EmployeeCode.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_Ed_EmployeeCode.Appearance.Image = Size16_Index.STAR1;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1;

            // 開始拠点
            this.tNedit_SectionCodeSt.Text = this.SectionCodeSt;
            _prevInputSectionSt = this.SectionCodeSt; //  ADD 2010/08/17 障害ID:13038対応
            // 終了拠点
            this.tNedit_SectionCodeEd.Text = this.SectionCodeEd;
            _prevInputSectionEd = this.SectionCodeEd; //  ADD 2010/08/17 障害ID:13038対応

            //参照区分
            this.tComboEditor_Refer.Items.Clear();
            this.tComboEditor_Refer.Items.Add(1, SALESINPUT_NAME);
            this.tComboEditor_Refer.Items.Add(2, FRONTEMPLOYEE_SECTION_NAME);
            this.tComboEditor_Refer.Items.Add(3, SALESEMPLOYEE_NAME);
            this.tComboEditor_Refer.MaxDropDownItems = this.tComboEditor_Refer.Items.Count;

            //期間区分
            this.tComboEditor_During.Items.Clear();
            this.tComboEditor_During.Items.Add(1, "日計");
            this.tComboEditor_During.Items.Add(2, "月計");
            this.tComboEditor_During.Items.Add(3, "当期");
            this.tComboEditor_During.MaxDropDownItems = this.tComboEditor_During.Items.Count;


            // 参照区分の初期化の設定
            this.tComboEditor_Refer.SelectedIndex = this._referDiv;
            // 期間区分の初期化の設定
            this.tComboEditor_During.SelectedIndex = this._duringDiv;
            // 開始担当者
            this.tEdit_EmployeeCode_St.Text = this.EmployeeCodeSt;
            _prevInputSupplierSt = this.EmployeeCodeSt; //  ADD 2010/08/17 障害ID:13038対応
            // 終了担当者
            this.tEdit_EmployeeCode_Ed.Text = this.EmployeeCodeEd;
            _prevInputSupplierEd = this.EmployeeCodeEd; //  ADD 2010/08/17 障害ID:13038対応
            // 期間の初期化の設定
            this.tDateEdit_St_During.SetDateTime(this._duringSt);
            this.tDateEdit_Ed_During.SetDateTime(this._duringEd);
            this.tDateEdit_St_YearMonth.SetLongDate(this._duringYmSt);
            this.tDateEdit_Ed_YearMonth.SetLongDate(this._duringYmEd);
            this.ChangeFileName();
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void ultraButton_OK_Click(object sender, EventArgs e)
        {
            if (this.InputCheck())
            {
                this.SetExtratConst();
                this.DResult = DialogResult.OK;
                // --- UPD 2010/10/09 ---------->>>
                //FormcloseFlg = true;
                //this.Close();
                bool outputRslt = true;
                if (this.OutputData != null)
                {
                    outputRslt = this.OutputData();
                }
                if (outputRslt)
                {
                    FormcloseFlg = true;
                    this.Close();
                }
                // --- UPD 2010/10/09 ----------<<<
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 王開強</br>
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
        /// <br>Programmer : 王開強</br>
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
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // --- ADD 2010/09/09 ---------->>>>>
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excelファイル(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            }
            // --- ADD 2010/09/09 ----------<<<<<
            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = this.openFileDialog.FileName.ToUpper();
            }
        }


        /// <summary>
        /// 担当者(開始)ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者(開始)ガイドボタンクリックイベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void uButton_St_EmployeeCode_Click(object sender, EventArgs e)
        {
            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_St.Text = employee.EmployeeCode.Trim();
                _prevInputSupplierSt = employee.EmployeeCode.Trim();

                tEdit_EmployeeCode_Ed.Focus();
            }
        }

        /// <summary>
        /// 担当者(終了)ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 担当者(終了)ガイドボタンクリックイベントを行う。 </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ultraButton_Ed_EmployeeCode_Click(object sender, EventArgs e)
        {

            if (_employeeAcs == null)
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.Trim();
                _prevInputSupplierEd = employee.EmployeeCode.Trim();

                tComboEditor_During.Focus();
            }
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォーカスが変更された時ときに発生します。</br>
        /// <br>Programmer : 王開強</br>
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
                        bool status = this.ReadSectionCodeAllowZero(out code, inputValue, "st");
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
                            this.tNedit_SectionCodeSt.Text = _prevInputSectionSt;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
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
                                                e.NextCtrl = this.tEdit_EmployeeCode_St;
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
                            this.tNedit_SectionCodeEd.Text = _prevInputSectionEd;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                case "tEdit_EmployeeCode_St":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_St.DataText))
                        {
                            string code_St = tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                            string inputValue = this.tEdit_EmployeeCode_St.Text.Trim();
                            string code;
                            string name;
                            bool status = ReadEmployee(code_St, out code, out name);
                            if (!status)
                            {
                                // エラー時
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "担当者(開始) [" + inputValue + "] に該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_EmployeeCode_St.Text = _prevInputSupplierSt;
                                this.tEdit_EmployeeCode_St.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                                break; // ADD 2010/09/26
                            }
                            else
                            {
                                _prevInputSupplierSt = code;
                            }
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_EmployeeCode_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_St_EmployeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (!string.IsNullOrEmpty(tEdit_EmployeeCode_Ed.DataText))
                        {
                            string code_Ed = tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                            string inputValue = this.tEdit_EmployeeCode_Ed.Text.Trim();
                            string code;
                            string name;
                            bool status = ReadEmployee(code_Ed, out code, out name);
                            if (!status)
                            {
                                // エラー時
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "担当者(終了) [" + inputValue + "] に該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_EmployeeCode_Ed.Text = _prevInputSupplierEd;
                                this.tEdit_EmployeeCode_Ed.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                                break; // ADD 2010/09/26
                            }
                            else
                            {
                                _prevInputSupplierEd = code;
                            }
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.ultraButton_Ed_EmployeeCode;
                                            }
                                            else
                                            {
                                                int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
                                                if (2 == duringFlg)
                                                    e.NextCtrl = this.tDateEdit_St_YearMonth;
                                                else if (1 == duringFlg)
                                                    e.NextCtrl = this.tDateEdit_St_During;
                                                else
                                                    e.NextCtrl = this.tEdit_SettingFileName;
                                            }
                                        }
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
        #endregion

        #region Private Method
        /// <summary>
        /// 画面のクリア
        /// </summary>
        /// <br>Note       : 画面のクリア処理。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void Clear()
        {
            this.tNedit_SectionCodeSt.Clear();
            this.tNedit_SectionCodeEd.Clear();

            this.tEdit_EmployeeCode_St.Clear();
            this.tEdit_EmployeeCode_Ed.Clear();

            this._sectionName = string.Empty;
            this._selectionName = string.Empty;
        }

        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <br>Note       : 画面入力チェックです。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>UpdateNote  : 2010/09/15 tianjw</br>
        /// <br>             ・障害報告 #14643 テキスト出力対応</br>
        private bool InputCheck()
        {
            string errMessage = null;
            // 拠点
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            {
                this._sectionCodeSt = "00";
                _prevInputSectionSt = "00";
            }
            // --- ADD 2010/09/21 ---------->>>>>
            else
            {
                this._sectionCodeSt = this.tNedit_SectionCodeSt.Text;
                _prevInputSectionSt = this.tNedit_SectionCodeSt.Text;
            }
            // --- ADD 2010/09/21 ----------<<<<<
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            {
                this._sectionCodeEd = "00";
                _prevInputSectionEd = "00";
            }
            // --- ADD 2010/09/21 ---------->>>>>
            else
            {
                this._sectionCodeEd = this.tNedit_SectionCodeEd.Text;
                _prevInputSectionEd = this.tNedit_SectionCodeEd.Text;
            }
            // --- ADD 2010/09/21 ----------<<<<<

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
                this.tNedit_SectionCodeSt.Focus();
                return false;
            }

            //担当者コード（開始）＞　担当者コード（終了）のチェック
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierSt))
            if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_St.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                _prevInputSupplierSt = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputSupplierEd))
            if (string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.Text))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                _prevInputSupplierEd = "0";
            }
            // --------- UPD 2010/09/15 ---------------------------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd))
            if (Convert.ToInt32(_prevInputSupplierEd) != 0 && (Convert.ToInt32(_prevInputSupplierSt) > Convert.ToInt32(_prevInputSupplierEd)))
            // --------- UPD 2010/09/15 ----------------------------------------------------<<<<<
            {
                errMessage = "担当者範囲の指定に誤りがあります。";
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            errMessage,
                            0,
                            MessageBoxButtons.OK);
                tEdit_EmployeeCode_St.Focus();
                return false;
            }

            # region 必須入力チェック
            //期間区分
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);

            //日付
            DateGetAcs.CheckDateRangeResult cdrResult;
            PMHNB04161UA checkForm = new PMHNB04161UA();

            if (duringFlg == 1)
            {
                // 期間（開始～終了）
                if (checkForm.CallCheckDateForYearMonthDayRange(out cdrResult, ref tDateEdit_St_During, ref tDateEdit_Ed_During) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("期間(開始){0}", MESSAGE_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("期間(開始){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                            {
                                errMessage = string.Format("開始・終了日付{0}", ct_NotOnMonthError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeOverError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_During.Focus();
                                return false;
                            }
                    }
                }
            }
            else if (duringFlg == 2)
            {
                // 期間（開始～終了）
                if (checkForm.CallCheckDateForYearMonthRange(out cdrResult, ref tDateEdit_St_YearMonth, ref tDateEdit_Ed_YearMonth) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("期間(開始){0}", ct_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("期間(開始){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_NoInput);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("期間(終了){0}", ct_InputError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_Ed_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;

                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("期間{0}", ct_RangeYearMonthOverError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                            {
                                errMessage = string.Format("開始・終了年月{0}", ct_NotOnYearError);
                                TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            errMessage,
                                            0,
                                            MessageBoxButtons.OK);
                                tDateEdit_St_YearMonth.Focus();
                                return false;
                            }
                    }
                }
            }
            # endregion 必須入力チェック

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
        /// <param name="code">返り値</param>
        /// <param name="inputValue">入力値</param>
        /// <param name="startEnd">開始終了区分</param>
        /// <returns>bool</returns>
        /// <br>Note       : 拠点名称取得処理です。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
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
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    code = sectionInfo.SectionCode.Trim();
                    if ("st".Equals(startEnd))
                        _prevInputSectionSt = code;
                    else
                        _prevInputSectionEd = code;
                    this._sectionName = sectionInfo.SectionGuideNm;
                    return true;
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

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void ChangeFileName()
        {
            string fileName = string.Empty;
            string path = string.Empty;
            //PMHNB04161UD userSettingFrm = new PMHNB04161UD(); // DEL 2010/10/09
            PMHNB04161UD userSettingFrm = new PMHNB04161UD(this.ReferDiv); // ADD 2010/10/09
            userSettingFrm.AnalysisTextSettingAcs.Deserialize();

            // --- UPD 2010/10/09 ---------->>>
            //fileName = userSettingFrm.AnalysisTextSettingAcs.SalesEmployeeFileNameValue;
            //参照区分flg
            int duringFlg = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);

            if (duringFlg == 1)
            {
                fileName = userSettingFrm.AnalysisTextSettingAcs.SalesEmployeeFileNameValue;
            }
            else if (duringFlg == 2)
            {
                fileName = userSettingFrm.AnalysisTextSettingAcs.SalesSellerFileNameValue;
            }
            else
            {
                fileName = userSettingFrm.AnalysisTextSettingAcs.SalesPublisherFileNameValue;
            }
            // --- UPD 2010/10/09 ----------<<<
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

        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <br>Note       : 出力ファイル名変更処理を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        private void SetExtratConst()
        {
            // 対象拠点コード
            List<string[]> sectionCodeList = new List<string[]>();
            // SelectionCodeリスト
            List<string[]> selectionCodeList = new List<string[]>();

            // 拠点の取得
            // ---------------------- UPD 2010/09/19 ---------------------------------------->>>>>
            //if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt())
            if (this.tNedit_SectionCodeSt.GetInt() == this.tNedit_SectionCodeEd.GetInt() ||
                this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
            // ---------------------- UPD 2010/09/19 ----------------------------------------<<<<<
            {
                // ---------------------- UPD 2010/09/19 ---------------------------------------->>>>>
                //if (this.tNedit_SectionCodeSt.GetInt() == 0)
                if (this.tNedit_SectionCodeSt.GetInt() == 0 || this.tNedit_SectionCodeEd.GetInt() == 0)
                // ---------------------- UPD 2010/09/19 ----------------------------------------<<<<<
                {
                    // 全社指定
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    ArrayList relList = new ArrayList();
                    int status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (SecInfoSet sectionInfo in relList)
                        {
                            // --------------------------- UPD 2010/09/19 -------------------------------------->>>>>
                            if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() != 0)
                            {
                                //if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode)) // DEL 2010/09/21
                                if (this.tNedit_SectionCodeEd.GetInt() >= Convert.ToInt32(sectionInfo.SectionCode) && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            else if (this.tNedit_SectionCodeSt.GetInt() != 0 && this.tNedit_SectionCodeEd.GetInt() == 0)
                            {
                                //if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode)) // DEL 2010/09/21
                                if (this.tNedit_SectionCodeSt.GetInt() <= Convert.ToInt32(sectionInfo.SectionCode) && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                                {
                                    string[] sectionArr = new string[2];
                                    sectionArr[0] = sectionInfo.SectionCode;
                                    //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                    sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                    sectionCodeList.Add(sectionArr);
                                }
                            }
                            //else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0) // DEL 2010/09/21
                            else if (this.tNedit_SectionCodeSt.GetInt() == 0 && this.tNedit_SectionCodeEd.GetInt() == 0 && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                            {
                                string[] sectionArr = new string[2];
                                sectionArr[0] = sectionInfo.SectionCode;
                                //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                                sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                                sectionCodeList.Add(sectionArr);
                            }
                            //string[] sectionArr = new string[2];
                            //sectionArr[0] = sectionInfo.SectionCode;
                            //sectionArr[1] = sectionInfo.SectionGuideNm;
                            //sectionCodeList.Add(sectionArr);
                            // --------------------------- UPD 2010/09/19 --------------------------------------<<<<<
                        }
                    }
                }
                else
                {
                    string[] sectionArr = new string[2];
                    sectionArr[0] = this.tNedit_SectionCodeSt.Text;
                    if (!string.IsNullOrEmpty(this._sectionName)) //ADD 2010/08/20 障害ID:13038対応
                    {
                        sectionArr[1] = this._sectionName;
                    // --- ADD 2010/08/20 障害ID:13038対応-------------------------------->>>>>
                    }
                    else
                    {
                        // 拠点情報を取得
                        SecInfoSet sectionInfo;
                        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tNedit_SectionCodeSt.Text);
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                        {
                            //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                            sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09

                        }
                    }
                    // --- ADD 2010/08/20 障害ID:13038対応--------------------------------<<<<<
                    sectionCodeList.Add(sectionArr);
                }
            }
            else
            {
                string code;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = 0;

                for (int i = this.tNedit_SectionCodeSt.GetInt(); i <= this.tNedit_SectionCodeEd.GetInt(); i++)
                {
                    code = i.ToString();
                    code = code.Trim().PadLeft(2, '0');
                    status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2010/09/21
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/21
                    {
                        string[] sectionArr = new string[2];
                        sectionArr[0] = code;
                        //sectionArr[1] = sectionInfo.SectionGuideNm; // DEL 2010/10/09
                        sectionArr[1] = sectionInfo.SectionGuideSnm; // ADD 2010/10/09
                        sectionCodeList.Add(sectionArr);
                    }
                }
            }
            this._sectionCodeList = sectionCodeList;

            // 参照区分
            this._referDiv = Convert.ToInt16(this.tComboEditor_Refer.Value);
            // 期間区分
            this._duringDiv = Convert.ToInt16(this.tComboEditor_During.Value);
            // 対象年度
            this._duringSt = this.tDateEdit_St_During.GetDateTime();
            this._duringEd = this.tDateEdit_Ed_During.GetDateTime();
            // 対象年度(年月)
            this._duringYmSt = this.tDateEdit_St_YearMonth.GetLongDate();
            this._duringYmEd = this.tDateEdit_Ed_YearMonth.GetLongDate();
            // 担当者
            this._employeeCodeSt = this.tEdit_EmployeeCode_St.Text;
            this._employeeCodeEd = this.tEdit_EmployeeCode_Ed.Text;

            // 出力ファイル名
            // ---UPD 2010/10/09 --------------------->>>
            //this._settingFileName = this.tEdit_SettingFileName.Text;
            // 参照区分は受注者の場合
            if (this._referDiv == 2)
            {
                this._settingFileNameSeller = this.tEdit_SettingFileName.Text;
            }
            // 参照区分は発行者の場合
            else if (this._referDiv == 3)
            {
                this._settingFileNamePublisher = this.tEdit_SettingFileName.Text;
            }
            // そのほかの場合
            else
            {
                this._settingFileName = this.tEdit_SettingFileName.Text;
            }
            // ---UPD 2010/10/09 ---------------------<<<
            //this._sectionCodeSt = this.tNedit_SectionCodeSt.Text; // ADD 2010/08/20 // DEL 2010/09/21

            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // 開始拠点コード「ログオペレーションデータ」
            SectionCodeLogSt = this.tNedit_SectionCodeSt.Text.Trim();
            // 終了拠点コード「ログオペレーションデータ」
            SectionCodeLogEd = this.tNedit_SectionCodeEd.Text.Trim();
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        }
        #endregion


        #region 値変更後発生イベント
        /// <summary>
        /// 参照区分コンボボックス値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 参照区分コンボボックス値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tComboEditor_Refer_ValueChanged(object sender, EventArgs e)
        {
            //参照区分flg
            int duringFlg = Convert.ToInt32(tComboEditor_Refer.SelectedItem.DataValue);

            if (duringFlg == 1)
            {
                uLabel_EmployeeCode.Text = SALESINPUT_NAME;
            }
            else if (duringFlg == 2)
            {
                uLabel_EmployeeCode.Text = FRONTEMPLOYEE_SECTION_NAME;
            }
            else
            {
                uLabel_EmployeeCode.Text = SALESEMPLOYEE_NAME;
            }

            // ---ADD 2010/10/09 --------------------->>>
            this.ReferDiv = duringFlg;
            this.ChangeFileName();
            // ---ADD 2010/10/09 ---------------------<<<

        }

        /// <summary>
        /// 期間区分コンボボックス値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 期間区分コンボボックス値変更後発生イベントを行う。 </br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tComboEditor_During_ValueChanged(object sender, EventArgs e)
        {
            //期間区分flg
            int duringFlg = Convert.ToInt32(tComboEditor_During.SelectedItem.DataValue);
            if (duringFlg == 1)
            {
                uLabel_During_From_To.Visible = true;

                //期間(開始)YYYYMMDD
                tDateEdit_St_During.Visible = true;

                //期間(終了)YYYYMMDD
                tDateEdit_Ed_During.Visible = true;


                //期間(開始)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //期間(終了)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = true;

                // 売上日
                DateTime staratDate;
                DateTime endDate;
                this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

                if (tDateEdit_St_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //期間(開始)YYYYMMDD
                    this.tDateEdit_St_During.Visible = true;
                    this.tDateEdit_St_During.Clear();
                    this.tDateEdit_St_During.SetDateTime(staratDate);
                }

                if (tDateEdit_Ed_During.GetDateTime().Equals(DateTime.MinValue))
                {
                    //期間(終了)YYYYMMDD
                    this.tDateEdit_Ed_During.Visible = true;
                    this.tDateEdit_Ed_During.Clear();
                    this.tDateEdit_Ed_During.SetDateTime(endDate);
                }

            }
            else if (duringFlg == 2)
            {
                uLabel_During_From_To.Visible = true;

                //期間(開始)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //期間(終了)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //期間(開始)YYYYMM
                tDateEdit_St_YearMonth.Visible = true;

                //期間(終了)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = true;

                uLabel_To_OutputDay.Visible = true;


                // 当月を設定
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate);

                if (tDateEdit_St_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_St_YearMonth.SetDateTime(startMonthDate);
                }

                if (tDateEdit_Ed_YearMonth.GetDateTime().Equals(DateTime.MinValue))
                {
                    this.tDateEdit_Ed_YearMonth.SetDateTime(endMonthDate);
                }
            }
            else
            {

                uLabel_During_From_To.Visible = false;

                //期間(開始)YYYYMMDD
                tDateEdit_St_During.Visible = false;

                //期間(終了)YYYYMMDD
                tDateEdit_Ed_During.Visible = false;


                //期間(開始)YYYYMM
                tDateEdit_St_YearMonth.Visible = false;

                //期間(終了)YYYYMM
                tDateEdit_Ed_YearMonth.Visible = false;

                uLabel_To_OutputDay.Visible = false;

                //当期を設定
                DateTime nowYearMonth;
                DateTime startMonthDate;
                DateTime endMonthDate;
                DateTime startYearDate;
                DateTime endYearDate;
                int thisYear;

                this._dateGet.GetThisYearMonth(out nowYearMonth, out thisYear, out startMonthDate, out endMonthDate, out startYearDate, out endYearDate);

                this.tDateEdit_St_YearMonth.SetDateTime(startYearDate);
                this.tDateEdit_Ed_YearMonth.SetDateTime(endYearDate);

            }

        }
        #endregion

        /// <summary>
        /// 従業員Read
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="code">従業員コード</param>
        /// <param name="name">従業員名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 従業員Readを行う。 </br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/09/21 zhume</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        /// </remarks>
        private bool ReadEmployee(string employeeCode, out string code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (employeeCode != string.Empty)
            {
                // 読み込み
                if (_employeeAcs == null)
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

                //if (status == 0 && employee != null) // DEL 2010/09/21
                if (status == 0 && employee != null && employee.LogicalDeleteCode == 0) // ADD 2010/09/21
                {
                    // 該当あり→表示
                    code = employee.EmployeeCode.TrimEnd();
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// フォームクロースイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : フォームクロース時に発生します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        private void PMHNB04161UC_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_formcloseFlg)
                this._dialogResult = DialogResult.Cancel;

        }
    }
}