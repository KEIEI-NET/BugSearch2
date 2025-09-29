//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入チェック処理
// プログラム概要   : 仕入チェック処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30418 徳永
// 修 正 日  2008/11/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2009/02/02  修正内容 : 排他制御処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2009/02/24  修正内容 : 障害ID:11877対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2009/02/25  修正内容 : 障害ID:7882対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2009/03/12  修正内容 : 障害ID:8975対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2009/03/24  修正内容 : 障害ID:12789対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野
// 修 正 日  2009/04/03  修正内容 : 障害ID:13068対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/29  修正内容 : MANTIS【13346】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2010/10/21  修正内容 : MANTIS：0016368、0016384対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 修 正 日  2011/12/05  修正内容 : Redmine#8416の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 修 正 日  2011/12/13  修正内容 : Redmine#26642の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 凌小青
// 修 正 日  2012/08/30  修正内容 : 2012/09/12配信分、Redmine#31879
//　　　　　　　　　　　　　　　　　No.1082、1157、1159　吉田商会　仕入チェック処理修正の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱 猛
// 修 正 日  2012/09/27  修正内容 : 2012/10/17配信分
//　　　　　　　　　　　　　　　　　UOE返品の場合は背景色を赤にする
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱 猛
// 修 正 日  2012/10/09  修正内容 : 2012/10/17配信分
//　　　　　　　　　　　　　　　　　赤伝の場合は背景色を赤にする
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Resources;
using System.IO;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 仕入チェック処理
    /// </summary>
    ///<remarks>
    /// <br>Note        : 仕入チェック処理UIフォームクラス</br>
    /// <br>Programmer  : 30418 徳永</br>
    /// <br>Date        : 2008/11/25</br>
    /// <br>Update Note : 2009/02/02 30414 忍 排他制御処理追加</br>
    /// <br>Update Note : 2009/02/24 30414 忍 障害ID:11877対応</br>
    /// <br>Update Note : 2009/02/25 30414 忍 障害ID:7882対応</br>
    /// <br>Update Note : 2009/03/12 30414 忍 障害ID:8975対応</br>
    /// <br>Update Note : 2009/03/24 30414 忍 障害ID:12789対応</br>
    /// <br>Update Note : 2009/04/03 30452 上野 障害ID:13068対応</br>
    /// <br>Update Note : 2010/10/21 李占川</br>
    /// <br>              MANTIS：0016368、0016384 金額、消費税表示内容の変更</br>
    /// <br>Update Note : 2011/12/05 葛中華</br>
    /// <br>              Redmine#8416の対応</br>
    /// <br>Update Note : 2011/12/13 葛中華</br>
    /// <br>              Redmine#26642の対応</br>
    /// <br>Update Note : 2012/08/30 凌小青</br>
    /// <br>管理番号  　: 10801804-00 2012/09/12配信分</br>
    /// <br>              Redmine#31879 No.1082、1157、1159　吉田商会　仕入チェック処理修正の対応</br>
    /// <br>Update Note : 2012/09/27 朱 猛</br>
    /// <br>管理番号  　: 10801804-00 2012/10/17配信分</br>
    /// <br>              UOE返品の場合は背景色を赤にする</br>
    /// <br>Update Note : 2012/10/09 朱 猛</br>
    /// <br>管理番号  　: 10801804-00 2012/10/17配信分</br>
    /// <br>              赤伝の場合は背景色を赤にする</br>
    /// </remarks>
    public partial class PMKOU01101UA : Form
    {

        #region プライベート変数

        #region ローカルクラス

        /// <summary>仕入チェック処理抽出条件クラス</summary>
        private SupplierCheckOrderCndtn _supplierCheckOrderCndtn = null;

        /// <summary>仕入チェック処理アクセスクラス</summary>
        private SupplierCheckAcs _supplierCheckAcs = null;
        //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>>
        // ユーザー設定
        private  SupplierCheckOrderSet _userSetting;
        //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<

        #endregion // ローカルクラス

        #region クラス

        /// <summary>SFKTN01210A)拠点アクセスクラス</summary>
        private SecInfoAcs _secInfoAcs;

        /// <summary>SFKTN09002A)拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>SFKTN09001E)拠点情報データクラス</summary>
        private SecInfoSet _sectionInfo;

        /// <summary>PMKHN09022A)仕入先</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>PMKHN09021E)仕入先情報データクラス</summary>
        private Supplier _supplier = null;

        /// <summary>自社情報アクセスクラス</summary>
        private DateGetAcs _dateGetAcs = null;

        /// <summary>MACMN00001C)UIスキン設定コントロール</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        #endregion // クラス

        #region データセット

        /// <summary>仕入チェック処理情報データセット</summary>
        SupplierCheckDataSet _dataSet = null;

        #endregion // データセット

        #region コード類

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>ログインユーザーコード</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>ログインユーザー名</summary>
        private string _loginUserName = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>ボタン用イメージリスト</summary>
        private ImageList _imageList16 = null;

        /// <summary>処理区分 日次:0/締次:1</summary>
        /// <remarks>処理区分コンボが変更されるたびにその値に修正される</remarks>
        private int _procDiv = 0;

        #endregion // コード類

        #region 締め日関連 

        /// <summary>PMCMN00102A)締め日取得用クラス</summary>
        TotalDayCalculator _tCalcAcs = null;

        /// <summary>今回締処理日</summary>
        private DateTime _currentTotalDay;

        /// <summary>今回締処理月</summary>
        private DateTime _currentTotalMonth;

        /// <summary>前回締処理日</summary>
        private DateTime _prevTotalDay;

        /// <summary>前回締処理月</summary>
        private DateTime _prevTotalMonth;

        #endregion // 締め日関連
        
        #endregion // プライベート変数

        #region 定数

        /// <summary>全社コード名称：初期値「全社」</summary>
        private const string CT_NAME_ALLSECCODE = "全社";

        /// <summary>全社コード：初期値「00」</summary>
        private const string CT_CODE_ALLSECCODE = "00";

        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>チェックボックス：チェックなし</summary>
        private const int CT_CHECKBOXSTATUS_UNCHECK = 0;

        /// <summary>チェックボックス：チェック</summary>
        private const int CT_CHECKBOXSTATUS_CHECK = 1;

        /// <summary>チェックボックス：不鮮明</summary>
        private const int CT_CHECKBOXSTATUS_UNCLEAR = 2;

        /// <summary>グリッド 不鮮明アルファレベル 128</summary>
        /// <remarks>0から255の間で設定、数字が大きいほど色が薄くなる</remarks>
        private const int CT_UNCLEAR_CHECKBOX_ALPHA = 128;

        #region メッセージ定数

        /// <summary>エラーメッセージ：「処理区分は必須項目です。」</summary>
        private const string CT_SLIP_DIV_NOT_SELECTED = "処理区分は必須項目です。";

        /// <summary>エラーメッセージ：「仕入日は必須項目です。」</summary>
        private const string CT_STOCKDATE_NOT_INPUT = "仕入日は必須項目です。";

        /// <summary>エラーメッセージ：「選択された売上日は同一月内ではありません。」</summary>
        private const string CT_DATE_NOT_IN_TERM = "選択された売上日は同一月内ではありません。";

        /// <summary>エラーメッセージ：「伝票番号は数字で入力してください。」</summary>
        private const string CT_SLIPNO_NOT_NUMERIC = "伝票番号は数字で入力してください。";

        /// <summary>エラーメッセージ：「に正しい日付を入力してください。」</summary>
        private const string CT_DATE_INVALID = "に正しい日付を入力してください。";

        /// <summary>エラーメッセージ：「日付(終了)は日付(開始)よりも後の日付を入力してください。」</summary>
        private const string CT_DATEED_MUSTBE_LATER = "日付(終了)は日付(開始)よりも後の日付を入力してください。";

        /// <summary>エラーメッセージ：「伝票番号(終了)は伝票番号(開始)よりも大きな数字を入力してください。」</summary>
        private const string CT_SLIPNOED_MUSTBE_LARGE = "伝票番号(終了)は伝票番号(開始)よりも大きな数字を入力してください。";

        /// <summary>エラーメッセージ：「仕入SEQ番号(終了)は仕入SEQ番号(開始)よりも大きな数字を入力してください。」</summary>
        private const string CT_SUPPSLIPNOED_MUSTBE_LARGE = "仕入SEQ番号(終了)は仕入SEQ番号(開始)よりも大きな数字を入力してください。";

        /// <summary>エラーメッセージ：「企業コードが取得されていません。」</summary>
        private const string CT_ENTERPRISE_CODE_NOT_QUALIFIED = "企業コードが取得されていません。";

        /// <summary>エラーメッセージ：「該当するデータが見つかりませんでした。」</summary>
        private const string CT_NOT_FOUND = "該当するデータが見つかりませんでした。";

        /// <summary>メッセージ：「 件のデータが見つかりました。」</summary>
        private const string CT_FOUND_RECORD = " 件のデータが見つかりました。";

        /// <summary>メッセージ：「自動更新の間隔を{0}分に設定しました。」</summary>
        private const string CT_AUTOUPDATE_SET_FOR = "自動更新の間隔を{0}分に設定しました。";

        /// <summary>メッセージ：「最終更新日時：{0}」</summary>
        private const string CT_LASTTIMEUPDATE = "最終更新日時：{0}";

        /// <summary>チェック時メッセージ「仕入月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAY_INITIALIZE_FAILED = "仕入月次締日取得の初期処理でエラーが発生しました。";

        /// <summary>メッセージ「更新された明細データはありません。」</summary>
        private const string MSG_NO_UPDATED_DATA = "更新された明細データはありません。";

        /// <summary>メッセージ「チェック状態更新でエラーが発生しました。」</summary>
        private const string MSG_ERROR_ON_UPDATE_CHECK = "チェック状態更新でエラーが発生しました。";

        /// <summary>メッセージ「 件のデータを更新しました。」</summary>
        private const string MSG_SUCCEED_UPDATE = " 件のデータを更新しました。";

        //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>>
        /// <summary>メッセージ「仕入日、あるいは入力日を入力して下さい。」</summary>
        private const string MSG_ALLDATE_NULL = "仕入日、あるいは入力日を入力して下さい。";
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMKOU01100U_Construction.XML";
        //----ADD BY 凌小青 on 2012/08/30 for Redmine#31879--------<<<<<<<<

        #endregion // メッセージ定数

        #region グリッド配色

        /// <summary>グリッド カラー1</summary>
        private readonly Color _rowFiscalColBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド カラー2</summary>
        private readonly Color _rowFiscalColBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _rowFiscalColForeColor1 = Color.FromArgb(255, 255, 255);

        /// <summary>グリッド ヘッダーカラー1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド ヘッダーカラー2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);


        // 返品伝票/行値引明細：ピンク
        /// <summary>グリッド カラー1</summary>
        private readonly Color _type03BackColor1 = Color.FromArgb(253, 235, 216);
        /// <summary>グリッド カラー2</summary>
        private readonly Color _type03BackColor2 = Color.FromArgb(7, 150, 59);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _type03ForeColor1 = Color.FromArgb(255, 0, 0);

        // 売仕入同時入力伝票：緑
        /// <summary>グリッド カラー1</summary>
        private readonly Color _type04BackColor1 = Color.FromArgb(150, 255, 150);
        /// <summary>グリッド カラー2</summary>
        private readonly Color _type04BackColor2 = Color.FromArgb(7, 150, 59);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _type04ForeColor1 = Color.FromArgb(0, 150, 0);

        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
        //U0E仕入伝票：青色
        /// <summary>グリッド カラー1</summary>
        private readonly Color _type05BackColor1 = Color.FromArgb(216, 235, 253);
        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<

        #endregion // グリッド配色

        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKOU01101UA()
        {
            InitializeComponent();
            
            // 初期設定
            InitializeVariable();
        }

        /// <summary>
        /// フォーム表示後イベント（初期フォーカス関連）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU01101UA_Shown(object sender, System.EventArgs e)
        {
            // 初期フォーカス（拠点）
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // コンストラクタ

        #region プライベート関数

        #region 初期配置

        /// <summary>
        /// コントロール類初期配置
        /// </summary>
        private void InitializeVariable()
        {
            int status = 0;

            // UIスキン設定コントロール初期化
            this._controlScreenSkin = new ControlScreenSkin();

            #region アクセスクラス初期化

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();          // 拠点
            this._supplierAcs = new SupplierAcs();              // 仕入先
            this._dateGetAcs = DateGetAcs.GetInstance();        // 自社設定取得
            this._userSetting = new SupplierCheckOrderSet();    //ユーザー設定//ADD BY 凌小青 on 2012/08/30

            #endregion // アクセスクラス初期化

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // 企業コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // 自拠点コード
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ログインユーザーコード
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ログインユーザー名

            #region 締め日取得

            _tCalcAcs = TotalDayCalculator.GetInstance();

            // 締日取得前初期処理
            status = _tCalcAcs.InitializeHisMonthlyAccPay();    // 仕入月次取得用初期処理

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の仕入締め日/月を取得(月と日は異なる場合がある)
                status = _tCalcAcs.GetHisTotalDayMonthlyAccPay(this._loginSectionCode, out this._prevTotalDay, out this._currentTotalDay, out this._prevTotalMonth, out this._currentTotalMonth);
            }
            else
            {
                // 初期処理失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_TOTALDAY_INITIALIZE_FAILED, -1, MessageBoxButtons.OK);
            }

            #endregion // 締め日取得

            #region ボタンイメージ設定

            // イメージリストを指定(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // ボタンイメージを設定
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SupplierGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // ツールバーアイコン
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 障害ID:8975対応------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            // --- CHG 2009/03/12 障害ID:8975対応------------------------------------------------------<<<<<
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SAVE;

            #endregion // ボタンイメージ設定

            #region 検索条件クラス作成

            this._supplierCheckOrderCndtn = new SupplierCheckOrderCndtn();
                        
            #endregion // 検索条件クラス作成

            #region コントロールスキン対応

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExpandableGroupBox_Condition.Name);
            controlNameList.Add(this.uExpandableGroupBox_Total.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // コントロールスキン対応

            #region グリッド設定

            // アクセスクラスを初期化し、データセットを取得
            this._supplierCheckAcs = new SupplierCheckAcs();
            this._dataSet = this._supplierCheckAcs.DataSet;

            // 企業コードをセットし、粗利マークを取得
            this._supplierCheckAcs.EnterpriseCode = this._enterpriseCode;
            this._supplierCheckAcs.SectionCode = this._loginSectionCode;
            this._supplierCheckAcs.GetProfitMark();

            // グリッドで表示に使用するデータビューを作成
            DataView dViewS = new DataView(this._dataSet.SlipList);
            DataView dViewD = new DataView(this._dataSet.DetailList);

            // データソースとしてデータビューを指定
            this.uGrid_Slip.DataSource = dViewS;
            this.uGrid_Detail.DataSource = dViewD;

            // グリッド列を設定
            InitializeGridColumns(0, this.uGrid_Slip.DisplayLayout.Bands[0].Columns);
            InitializeGridColumns(1, this.uGrid_Detail.DisplayLayout.Bands[0].Columns);

            

            #endregion // グリッド設定

            // 画面クリア
            InitializeScreen();

            // グリッドを調整しておく
            //this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            //this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = true;
            //for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            //{
            //    this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            //}
        }

        #endregion // 初期配置

        #region 名称取得

        #region 拠点

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCd">検索する拠点コード</param>
        /// <returns>拠点名</returns>
        private string GetSectionName(string sectionCd)
        {
            int status = this._secInfoSetAcs.Read(out _sectionInfo, this._enterpriseCode, sectionCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return _sectionInfo.SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion // 拠点

        #region 仕入先

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCd">検索する仕入先コード</param>
        /// <returns>仕入先名</returns>
        private string GetSupplierName(int supplierCd)
        {
            int status = this._supplierAcs.Read(out _supplier, this._enterpriseCode, supplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return _supplier.SupplierSnm;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion // 仕入先

        #endregion // 名称取得

        #region 画面の初期化

        /// <summary>
        /// 画面の初期化
        /// </summary>
        private void InitializeScreen()
        {
            // 全ての項目をクリア
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierSnm.Clear();
            this.tDateEdit_StockDateSt.Clear();
            this.tDateEdit_StockDateEd.Clear();
            this.tDateEdit_InputDaySt.Clear();
            this.tDateEdit_InputDayEd.Clear();
            this.tNedit_SupplierSlipNoSt.Clear();
            this.tNedit_SupplierSlipNoEd.Clear();
            this.tEdit_PartySalesSlipNumSt.Clear();
            this.tEdit_PartySalesSlipNumEd.Clear();

            // 合計欄のラベルをクリア
            this.uLabel_Total_Amount.Text = string.Empty;
            this.uLabel_Total_ConsumeTax.Text = string.Empty;
            this.uLabel_Total_AmountTaxInc.Text = string.Empty;
            this.uLabel_Total_AmountTaxIncAll.Text = string.Empty;
            this.uLabel_Total_Return.Text = string.Empty;
            this.uLabel_Total_ReturnConsumeTax.Text = string.Empty;
            this.uLabel_Total_ReturnTaxInc.Text = string.Empty;
            this.uLabel_Total_SlipCount.Text = string.Empty;
            this.uLabel_Total_DetailCount.Text = string.Empty;

            // 合計欄をクリア
            this.uLabel_DisplaySum.Text = string.Empty;
            this.uLabel_CheckSum.Text = string.Empty;
            this.uLabel_LackSum.Text = string.Empty;

            // データセットもクリア
            this._dataSet.SlipList.Clear();
            this._dataSet.DetailList.Clear();

            // 初期値を表示
            this.tEdit_SectionCodeAllowZero.Text = "00";    // 00
            this.tEdit_SectionName.Text = "全社";           // 全社
            this.tComboEditor_ProcDiv.SelectedIndex = 0;    // 日次
            this.tComboEditor_CheckDiv.SelectedIndex = 1;   // 未チェック
            this.tComboEditor_SlipDiv.SelectedIndex = 0;    // 全て

            //this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode.Trim().PadLeft(2, '0');
            //this.tEdit_SectionName.Text = GetSectionName(this._loginSectionCode);

            // 仕入日（開始：仕入現在処理月開始日(前回締日+1),終了：システム日付）
            // 入力日（開始：空白,終了：空白）// 2008.12.10 modify [8981]
            // 仕入現在処理月開始日が取得できなければシステム日付
            if (this._prevTotalDay == DateTime.MinValue)
            {
                this.tDateEdit_StockDateSt.SetDateTime(DateTime.Today);
            }
            else
            {
                this.tDateEdit_StockDateSt.SetDateTime(this._prevTotalDay.AddDays(1));
                
            }
            this.tDateEdit_StockDateEd.SetDateTime(DateTime.Today);
            this.tDateEdit_InputDaySt.Clear();
            this.tDateEdit_InputDayEd.Clear();
            
            // チェックボックス調整
            //this.tComboEditor_ProcDiv_ValueChanged(null, null);
            // データセットが空の場合はチェックボックスは無効
            if (this._dataSet.DetailList.Rows.Count == 0)
            {
                this.uCheckEditor_Slip_CheckAllDaily.Checked = false;
                this.uCheckEditor_Slip_CheckAllDaily.Enabled = false;
                this.uCheckEditor_Detail_CheckAllDaily.Checked = false;
                this.uCheckEditor_Detail_CheckAllDaily.Enabled = false;
                this.uCheckEditor_Slip_CheckAllCalc.Checked = false;
                this.uCheckEditor_Slip_CheckAllCalc.Enabled = false;
                this.uCheckEditor_Detail_CheckAllCalc.Checked = false;
                this.uCheckEditor_Detail_CheckAllCalc.Enabled = false;
            }

            // 合計表示は列がない場合は閉じておく
            if (this._dataSet.TotalList.Rows.Count == 0)
            {
                this.uExpandableGroupBox_Total.Expanded = false;
            }

            // ログインユーザー名表示
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;
        }

        #endregion // 画面の初期化

        #region グリッド列初期化

        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        /// <param name="tabNo">0:伝票 1:明細</param>
        /// <param name="Columns"></param>
        private void InitializeGridColumns(int tabNo, Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // 表示形式のある列で使用
            string formatCurrency = "#,##0;-#,##0;";
            string formatQuontity = "#,##0.00;-#,##0.00;";
            string formatPercentage = "##0.00;";

            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            switch (tabNo)
            {
                #region 伝票タブ
                case 0:
                    {
                        #region 共通項目

                        // 日次チェック
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Width = 25;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Caption = "日";
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 締次チェック
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Width = 35;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Caption = "締";
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 行番号
                        Columns[this._dataSet.SlipList.RowNoColumn.ColumnName].Hidden = true;
                        //Columns[this._dataSet.SlipList.RowNoColumn.ColumnName].Key = "Slip_RowNo";
                        Columns[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 仕入日
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Caption = "仕入日";
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 入力日
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Caption = "入力日";
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.InputDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 仕入SEQ番号
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                        //Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ番号";
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        // --- ADD 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                        Columns[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Format = "D9";
                        // --- ADD 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<

                        // 伝票番号
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Width = 130;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 税込金額
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Caption = "税込金額";
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 金額
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Caption = "金額";
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 消費税
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        #endregion // 共通項目

                        #region 固有項目

                        // 売上日
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Caption = "売上日";
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売上伝票番号
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Caption = "売上伝票番号";
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 得意先
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Caption = "得意先";
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 得意先名
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Width = 130;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売上金額
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "売上金額";
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売上担当者名
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Width = 80;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Caption = "売上担当者名";
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売上受注者名
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Width = 80;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Caption = "売上受注者名";
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売上発行者名
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Width = 80;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Caption = "売上発行者名";
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // リマーク1
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Width = 150;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Caption = "リマーク1";
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // リマーク2
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Width = 100;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Caption = "リマーク2";
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.UoeRemark2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 仕入先
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Caption = "仕入先";
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 仕入先名
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Width = 120;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先名";
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.SlipList.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 固有項目の列幅合計 1200

                        #endregion // 固有項目

                        #region グリッド本体の設定

                        // フィルタ不可
                        this.uGrid_Slip.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                        // 列の入れ替え不可
                        this.uGrid_Slip.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

                        // 列サイズ変更不可
                        //this.uGrid_Slip.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;//DEL BY 凌小青 on 2012/08/30
                        this.uGrid_Slip.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;//ADD BY 凌小青 on 2012/08/30

                        // 列移動不可
                        //this.uGrid_Slip.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;//DEL BY 凌小青 on 2012/08/30
                        this.uGrid_Slip.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;//ADD BY 凌小青 on 2012/08/30

                        #endregion // グリッド本体の設定

                        break;
                    }
                #endregion // 伝票タブ

                #region 明細タブ
                case 1:
                    {
                        #region 共通項目

                        // 日次チェック
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Width = 25;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Caption = "日";
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 締次チェック
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Width = 35;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Caption = "締";
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Fixed = true;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 行番号
                        Columns[this._dataSet.DetailList.RowNoColumn.ColumnName].Hidden = true;
                        //Columns[this._dataSet.DetailList.RowNoColumn.ColumnName].Key = "Detail_RowNo";
                        Columns[this._dataSet.DetailList.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 仕入日
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Caption = "仕入日";
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 入力日
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Caption = "入力日";
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.InputDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 仕入SEQ番号
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                        //Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ番号";
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        // --- ADD 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                        Columns[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName].Format = "D9";
                        // --- ADD 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<

                        // 伝票番号
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Width = 130;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 税込金額
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Caption = "税込金額";
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 金額
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Caption = "金額";
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 消費税
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        #endregion // 共通項目

                        #region 固有項目

                        // 品番
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Width = 180;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Caption = "品番";
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 数量
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Width = 100;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Format = formatQuontity;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Caption = "数量";
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // BLｺｰﾄﾞ
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Width = 60;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 品名
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Width = 200;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Caption = "品名";
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 原単価
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Width = 120;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Caption = "原単価"; // 2008.12.10 modify [9002]
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 標準価格
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Width = 90;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売単価
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Width = 110;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "売単価"; // 2008.12.10 modify [9002]
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 売上金額
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Width = 110;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "売上金額";
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 粗利マーク
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Width = 20;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Caption = "粗利ﾏｰｸ";
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ProfitMarkColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 粗利
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Width = 120;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Format = formatCurrency;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Caption = "粗利";
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        // 粗利率
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Hidden = false;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Width = 60;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Format = formatPercentage;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Caption = "粗利率";
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        Columns[this._dataSet.DetailList.ProfitRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                        #endregion // 固有項目

                        #region グリッド本体の設定

                        // フィルタ不可
                        this.uGrid_Detail.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                        // 列の入れ替え不可
                        this.uGrid_Detail.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

                        // 列サイズ変更不可
                        //this.uGrid_Detail.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;//DEL BY 凌小青 on 2012/08/30
                        this.uGrid_Detail.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;//ADD BY 凌小青 on 2012/08/30

                        // 列移動不可
                        //this.uGrid_Detail.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;//DEL BY 凌小青 on 2012/08/30
                        this.uGrid_Detail.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;//ADD BY 凌小青 on 2012/08/30

                        #endregion // グリッド本体の設定

                        break;
                    }
                #endregion // 明細タブ

                default: break;
            }
        }

        #endregion // グリッド列初期化

        #region 検索

        /// <summary>
        /// 検索
        /// </summary>
        private void Search()
        {
            // メッセージをクリア
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;

            // 画面から検索条件クラスを作成
            GetParameters();

            // パラメータチェック
            string errorMsg = string.Empty;
            Control checkControl = null;
            checkControl = CheckParameter(out errorMsg);
            if (checkControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                checkControl.Focus();
                return;
            }
            else
            {
                int recordCount = 0;

                // データセットをクリア
                this._dataSet.SlipList.Clear();
                this._dataSet.DetailList.Clear();
                this._dataSet.TotalList.Clear();
                // 2008.12.10 add start [9031]
                this._dataSet.Sum.Clear();
                // 2008.12.10 add end [9031]

                // 検索実行
                this._supplierCheckAcs.Search(this._supplierCheckOrderCndtn, out recordCount);

                if (recordCount > 0)
                {
                    // ソート順を作成
                    DataView dViewS = (DataView)this.uGrid_Slip.DataSource;
                    DataView dViewD = (DataView)this.uGrid_Detail.DataSource;
                    dViewS.Sort = "RowNo Asc";
                    dViewD.Sort = "RowNo Asc";

                    // 合計額を表示
                    if (this._dataSet.TotalList.Rows.Count > 0)
                    {
                        DataRow totalRow = this._dataSet.TotalList.Rows[0];

                        // 2008.12.10 modify start [9009]
                        this.uLabel_Total_Amount.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxIncAll.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncAllColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_Return.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");

                        this.uLabel_Total_SlipCount.Text = ((Int32)totalRow[this._dataSet.TotalList.SlipCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_DetailCount.Text = ((Int32)totalRow[this._dataSet.TotalList.DetailCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        // 2008.12.10 modify end [9009]

                        // 合計額が畳まれていれば展開
                        if (!this.uExpandableGroupBox_Total.Expanded)
                        {
                            this.uExpandableGroupBox_Total.Expanded = true;
                        }
                    }

                    // チェックボックスを調整
                    this.tComboEditor_ProcDiv_ValueChanged(null, null);

                    // 全ての行でチェックボックスを調整する
                    SetupCheckBox_Slip();

                    // 合計テーブルを作成
                    ResetTotal();

                    // 合計欄へ数字を表示
                    SetTotal();
                    //ResetTotal();

                    // 行の背景色変更
                    SetRowBackColor();

                    // 2008.12.10 add start [9015]
                    // 伝票グリッドの先頭行
                    this.uTabControl_Grid.SelectedTab = this.ultraTabPageControl1.Tab;
                    Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Slip.DisplayLayout.Rows[0];
                    Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_slip = this.uGrid_Slip.DisplayLayout.RowScrollRegions[0];
                    rsr_slip.FirstRow = row;
                    rsr_slip.ScrollRowIntoView(row);
                    this.uGrid_Slip.ActiveRow = row;
                    // 2008.12.10 add end [9015]
                }
                else
                {
                    // なければ合計額を折りたたむ
                    this.uExpandableGroupBox_Total.Expanded = false;

                    SetTotal();
                }
            }
        }

        /// <summary>
        /// 検索終了時に合計値を表示
        /// </summary>
        /// <remarks>検索時のみ使用 チェック更新による再計算はResetTotal()を使用する</remarks>
        private void SetTotal()
        {
            if (this._dataSet.Sum.Rows.Count > 0)
            {
                DataRow row = this._dataSet.Sum.Rows[0];

                this.uLabel_DisplaySum.Text = ((Int64)row[this._dataSet.Sum.DisplaySumColumn]).ToString("#,##0;-#,##0;");
                this.uLabel_CheckSum.Text = ((Int64)row[this._dataSet.Sum.CheckSumColumn]).ToString("#,##0;-#,##0;");
                this.uLabel_LackSum.Text = ((Int64)row[this._dataSet.Sum.LackSumColumn.ColumnName]).ToString("#,##0;-#,##0;");
            }
            else
            {
                // 2008.12.10 add start [9031]
                this.uLabel_DisplaySum.Text = string.Empty;
                this.uLabel_CheckSum.Text = string.Empty;
                this.uLabel_LackSum.Text = string.Empty;
                // 2008.12.10 add end [9031]
            }
        }

        #endregion // 検索

        #region 合計額更新

        /// <summary>
        /// 合計額更新
        /// </summary>
        private void ResetTotal()
        {
            // チェックされた行の合計値を取得
            Int64 consValue = 0;
            string condition = string.Empty;
            // --- UPD 2010/10/21 ---------->>>>>
            if (this._procDiv == 0)
            {
                //condition = "CheckBoxDaily = true";
                condition = "CheckBoxDaily = true AND (CheckBoxDailyStatus = 0 OR CheckBoxDailyStatus = 1)";
            }
            else
            {
                //condition = "CheckBoxCalc = true";
                condition = "CheckBoxCalc = true AND (CheckBoxCalcStatus = 0 OR CheckBoxCalcStatus = 1)";

            }

            //foreach (DataRow row in this._dataSet.DetailList.Select(condition))
            //{
            //    // --- CHG 2009/02/24 障害ID:11877対応------------------------------------------------------>>>>>
            //    //consValue += (Int64)row[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName];
            //    consValue += (Int64)row[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName];
            //    // --- CHG 2009/02/24 障害ID:11877対応------------------------------------------------------<<<<<
            //}

            foreach (DataRow row in this._dataSet.SlipList.Select(condition))
            {
                consValue += (Int64)row[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName];
            }
            // --- UPD 2010/10/21 ----------<<<<<

            // データセットを更新
            DataRow sumRow = this._dataSet.Sum.Rows[0];
            // 2008.12.10 modify start [9032]
            Int64 dispSum = (Int64)sumRow[this._dataSet.Sum.DisplaySumColumn.ColumnName];
            sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = consValue;
            sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = dispSum - consValue;
            // 2008.12.10 modify end [9032]

            // 表示更新
            SetTotal();
        }

        /// <summary>
        /// 合計額更新
        /// </summary>
        // --- UPD 2010/10/21 ---------->>>>>
        //private void ResetTotal(DataRow row, bool check)
        private void ResetTotal(DataRow row, bool check, int supplierSlipNo)
        {
            DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
            int count = 0;
            Int64 consValue = 0;
            bool allFlag = true;
            if (rows.Length >= 1)
            {
                foreach (DataRow row2 in rows)
                {
                    // 選択チェック
                    if (this._procDiv == 0)
                    {
                        if ((bool)row2[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] == false)
                        {
                            allFlag = false;
                            count++;
                        }
                    }
                    else
                    {
                        if ((bool)row2[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] == false)
                        {
                            allFlag = false;
                            count++;
                        }
                    }
                }

                if (!allFlag && check)
                {
                    return;
                }

                if (count > 1)
                {
                    return;
                }

                DataRow[] slipRows = this._dataSet.Tables["SlipList"].Select(String.Format("SupplierSlipNo = {0}", supplierSlipNo.ToString()));

                if (slipRows.Length == 1)
                {
                    DataRow slipRow = slipRows[0];
                    consValue = (Int64)slipRow[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName];
                }
            }
            // --- UPD 2010/10/21 ----------<<<<<

            // チェックされた行の値を取得
            //Int64 consValue = (Int64)row[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName]; // DEL 2010/10/21
            if (!check) consValue = consValue * -1;

            // データセットを更新
            DataRow sumRow = this._dataSet.Sum.Rows[0];
            Int64 checkSum = (Int64)sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName];
            Int64 lackSum = (Int64)sumRow[this._dataSet.Sum.LackSumColumn.ColumnName];
            sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = checkSum + consValue;
            sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = lackSum - consValue;

            // 表示更新
            SetTotal();
        }

        #endregion // 合計額更新

        #region 更新

        /// <summary>
        /// 更新処理
        /// </summary>
        private void UpdateCheck()
        {
            DataRow[] rows = null;
            // 更新対象となるのは、明細テーブルでチェック状態が更新されたもののみ
            if (this._procDiv == 0)
            {
                rows = this._dataSet.DetailList.Select(String.Format("{0} <> {1}", 
                                                            this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName,
                                                            this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName));
            }
            else
            {
                rows = this._dataSet.DetailList.Select(String.Format("{0} <> {1}",
                                            this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName,
                                            this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName));

            }

            // 更新データなし
            if (rows.Length == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_NO_UPDATED_DATA, -1, MessageBoxButtons.OK);
                return;
            }
            else
            {
                int count = 0;
                if (this._supplierCheckAcs == null)
                {
                    this._supplierCheckAcs = new SupplierCheckAcs();
                }
                this._supplierCheckAcs.EnterpriseCode = this._enterpriseCode;

                int status = this._supplierCheckAcs.Update(this._procDiv, out count);
                // --- CHG 2009/02/02 排他制御処理追加------------------------------------------------------>>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                //        MSG_ERROR_ON_UPDATE_CHECK, -1, MessageBoxButtons.OK);
                //    return;
                //}
                //else
                //{
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                //        count.ToString() + MSG_SUCCEED_UPDATE, -1, MessageBoxButtons.OK);
                //}
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                          count.ToString() + MSG_SUCCEED_UPDATE, -1, MessageBoxButtons.OK);
                            break;
                        }
                    // 企業ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "PMKOU01101U",
                                          "UpdateCheck",
                                          TMsgDisp.OPE_UPDATE,
                                          "シェアチェックエラー(企業ロック)です。" + "\r\n" +
                                          "月次更新か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          status,
                                          this._supplierCheckAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return;
                        }
                    // 拠点ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "PMKOU01101U",
                                          "UpdateCheck",
                                          TMsgDisp.OPE_UPDATE,
                                          "シェアチェックエラー(拠点ロック)です。" + "\r\n" +
                                          "締更新か、処理が込み合っているためタイムアウトしました。。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          status,
                                          this._supplierCheckAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return;
                        }
                    // 倉庫ロックタイムアウト
                    case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                          this.Name,
                                          "PMKOU01101U",
                                          "UpdateCheck",
                                          TMsgDisp.OPE_UPDATE,
                                          "シェアチェックエラー(倉庫ロック)です。" + "\r\n" +
                                          "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                          "再試行するか、しばらく待ってから再度処理を行ってください。",
                                          status,
                                          this._supplierCheckAcs,
                                          MessageBoxButtons.OK,
                                          MessageBoxDefaultButton.Button1);
                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                          MSG_ERROR_ON_UPDATE_CHECK, -1, MessageBoxButtons.OK);
                            return;
                        }
                }
                // --- CHG 2009/02/02 排他制御処理追加------------------------------------------------------<<<<<


                #region 検索再実行

                // 更新が成功したら検索を再実行(更新時間・旧チェック状態列を更新するため)

                // 画面から検索条件クラスを作成
                GetParameters();

                // データセットをクリア
                this._dataSet.SlipList.Clear();
                this._dataSet.DetailList.Clear();
                this._dataSet.TotalList.Clear();
                this._dataSet.Sum.Clear();

                // 検索実行
                int recordCount = 0;
                this._supplierCheckAcs.Search(this._supplierCheckOrderCndtn, out recordCount);

                if (recordCount > 0)
                {
                    // ソート順を作成
                    DataView dViewS = (DataView)this.uGrid_Slip.DataSource;
                    DataView dViewD = (DataView)this.uGrid_Detail.DataSource;
                    dViewS.Sort = "RowNo Asc";
                    dViewD.Sort = "RowNo Asc";

                    // 合計額を表示
                    if (this._dataSet.TotalList.Rows.Count > 0)
                    {
                        DataRow totalRow = this._dataSet.TotalList.Rows[0];

                        this.uLabel_Total_Amount.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_AmountTaxIncAll.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountTaxIncAllColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.AmountConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_Return.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnConsumeTax.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnConsumeTaxColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_ReturnTaxInc.Text = ((Int64)totalRow[this._dataSet.TotalList.ReturnTaxIncColumn.ColumnName]).ToString("#,##0;-#,##0;");

                        this.uLabel_Total_SlipCount.Text = ((Int32)totalRow[this._dataSet.TotalList.SlipCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                        this.uLabel_Total_DetailCount.Text = ((Int32)totalRow[this._dataSet.TotalList.DetailCountColumn.ColumnName]).ToString("#,##0;-#,##0;");

                        // 合計額が畳まれていれば展開
                        if (!this.uExpandableGroupBox_Total.Expanded)
                        {
                            this.uExpandableGroupBox_Total.Expanded = true;
                        }
                    }

                    // チェックボックスを調整
                    this.tComboEditor_ProcDiv_ValueChanged(null, null);

                    // 全ての行でチェックボックスを調整する
                    SetupCheckBox_Slip();

                    // 合計テーブルを作成
                    ResetTotal();

                    // 合計欄へ数字を表示
                    SetTotal();

                    // 行の背景色変更
                    SetRowBackColor();

                    // 伝票グリッドの先頭行
                    //this.uTabControl_Grid.SelectedTab = this.ultraTabPageControl1.Tab;
                    //Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Slip.DisplayLayout.Rows[0];
                    //Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_slip = this.uGrid_Slip.DisplayLayout.RowScrollRegions[0];
                    //rsr_slip.FirstRow = row;
                    //rsr_slip.ScrollRowIntoView(row);
                    //this.uGrid_Slip.ActiveRow = row;
                }

                #endregion // 検索再実行
            }

        }

        #endregion // 更新

        #region 画面→パラメータ作成

        /// <summary>
        /// 画面→パラメータ作成
        /// </summary>
        private void GetParameters()
        {
            this._supplierCheckOrderCndtn = new SupplierCheckOrderCndtn();

            // 企業コード
            this._supplierCheckOrderCndtn.EnterpriseCode = this._enterpriseCode;

            // 処理区分(Not Null)
            this._supplierCheckOrderCndtn.ProcDiv = (int)this.tComboEditor_ProcDiv.SelectedItem.DataValue;

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("0") ||
                this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("00"))
            {
                this._supplierCheckOrderCndtn.SectionCode = string.Empty;
            }
            else if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                this._supplierCheckOrderCndtn.SectionCode = string.Empty;
            }
            else
            {
                this._supplierCheckOrderCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            }

            // 仕入先コード
            this._supplierCheckOrderCndtn.SupplierCd = this.tNedit_SupplierCd.GetInt();

            // 伝票区分
            if (this.tComboEditor_SlipDiv.SelectedIndex > -1)
            {
                this._supplierCheckOrderCndtn.SlipDiv = (int)this.tComboEditor_SlipDiv.SelectedItem.DataValue;
            }

            // チェック区分
            if (this.tComboEditor_CheckDiv.SelectedIndex > -1)
            {
                this._supplierCheckOrderCndtn.CheckDiv = (int)this.tComboEditor_CheckDiv.SelectedItem.DataValue;
            }

            // 仕入日開始
            this._supplierCheckOrderCndtn.St_StockDate = this.tDateEdit_StockDateSt.GetLongDate();

            // 仕入日終了
            this._supplierCheckOrderCndtn.Ed_StockDate = this.tDateEdit_StockDateEd.GetLongDate();

            // 入力日開始
            this._supplierCheckOrderCndtn.St_InputDay = this.tDateEdit_InputDaySt.GetLongDate();

            // 入力日終了
            this._supplierCheckOrderCndtn.Ed_InputDay = this.tDateEdit_InputDayEd.GetLongDate();

            // 仕入SEQ番号開始
            this._supplierCheckOrderCndtn.St_SupplierSlipNo = this.tNedit_SupplierSlipNoSt.GetInt();

            // 仕入SEQ番号終了
            this._supplierCheckOrderCndtn.Ed_SupplierSlipNo = this.tNedit_SupplierSlipNoEd.GetInt();

            // 伝票番号開始
            if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumSt.Text.Trim()))
            {
                this._supplierCheckOrderCndtn.St_PartySaleSlipNum = this.tEdit_PartySalesSlipNumSt.Text.Trim();
            }
            else
            {
                this._supplierCheckOrderCndtn.St_PartySaleSlipNum = string.Empty;
            }

            // 伝票番号終了
            if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumEd.Text.Trim()))
            {
                this._supplierCheckOrderCndtn.Ed_PartySaleSlipNum = this.tEdit_PartySalesSlipNumEd.Text.Trim();
            }
            else
            {
                this._supplierCheckOrderCndtn.Ed_PartySaleSlipNum = string.Empty;
            }
        }

        #endregion // 画面→パラメータ作成

        #region パラメータチェック

        /// <summary>
        /// パラメータチェック関数
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private Control CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // パラメータが必須のものをチェック

            // 処理区分
            if (this._supplierCheckOrderCndtn.ProcDiv != 0 && this._supplierCheckOrderCndtn.ProcDiv != 1)
            {
                errorMsg = CT_SLIP_DIV_NOT_SELECTED;
                return this.tComboEditor_ProcDiv;
            }

            // 2008.12.10 add start [8986]
            // 仕入SEQ番号の大小チェック
            if (this.tNedit_SupplierSlipNoEd.GetInt() > 0)
            {
                if (this.tNedit_SupplierSlipNoSt.GetInt() > this.tNedit_SupplierSlipNoEd.GetInt())
                {
                    errorMsg = CT_SUPPSLIPNOED_MUSTBE_LARGE;
                    return this.tNedit_SupplierSlipNoEd;
                }
            }
            // 2008.12.10 add end [8986]

            //// 2008.12.10 add start [8987]
            //// 伝票番号の大小チェック
            //Double dSlipSt = 0;
            //Double dSlipEd = 0;
            //if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumSt.Text.Trim()))
            //{
            //    try
            //    {
            //        dSlipSt = Double.Parse(this.tEdit_PartySalesSlipNumSt.Text.Trim());
            //    }
            //    catch
            //    {
            //        errorMsg = CT_SLIPNO_NOT_NUMERIC;
            //        return this.tEdit_PartySalesSlipNumSt;
            //    }
            //}

            //if (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumEd.Text.Trim()))
            //{
            //    try
            //    {
            //        dSlipEd = Double.Parse(this.tEdit_PartySalesSlipNumEd.Text.Trim());
            //    }
            //    catch
            //    {
            //        errorMsg = CT_SLIPNO_NOT_NUMERIC;
            //        return this.tEdit_PartySalesSlipNumEd;
            //    }
            //}

            //// 両方入力されている場合のみ比較(片方のみ入力はOK)
            //if (dSlipEd > 0 && dSlipSt > 0 && dSlipEd - dSlipSt < 0)
            //{
            //    errorMsg = CT_SLIPNOED_MUSTBE_LARGE;
            //    return this.tEdit_PartySalesSlipNumEd;
            //}
            //// 2008.12.10 add end [8987]
            if ((!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumSt.Text.Trim())) &&
                (!String.IsNullOrEmpty(this.tEdit_PartySalesSlipNumEd.Text.Trim())))
            {
                string st = this.tEdit_PartySalesSlipNumSt.Text.Trim();
                string ed = this.tEdit_PartySalesSlipNumEd.Text.Trim();

                if (String.Compare(st, ed) > 0)
                {
                    errorMsg = "伝票番号の範囲指定が不正です。";
                    return this.tEdit_PartySalesSlipNumEd;
                }
            }

            //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>>
            if (this.tDateEdit_StockDateSt.GetLongDate() == 0
                && this.tDateEdit_StockDateEd.GetLongDate() == 0
                && this.tDateEdit_InputDaySt.GetLongDate() == 0
                && this.tDateEdit_InputDayEd.GetLongDate() == 0)
            {
                errorMsg = MSG_ALLDATE_NULL;
                return this.tDateEdit_StockDateSt;
            }
            //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<<

            // 2008.12.10 add start [8979]
            // 日付のチェック
            if (this.tDateEdit_StockDateSt.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_StockDateSt.GetDateTime()))
            {
                errorMsg = "仕入日(開始)" + CT_DATE_INVALID;
                return this.tDateEdit_StockDateSt;
            }

            if (this.tDateEdit_StockDateEd.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_StockDateEd.GetDateTime()))
            {
                errorMsg = "仕入日(終了)" + CT_DATE_INVALID;
                return this.tDateEdit_StockDateEd;
            }

            // --- CHG 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            //if (this.tDateEdit_InputDaySt.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_InputDaySt.GetDateTime()))
            //{
            //    errorMsg = "入力日(開始)" + CT_DATE_INVALID;
            //    return this.tDateEdit_InputDaySt;
            //}

            //if (this.tDateEdit_InputDayEd.GetLongDate() > 0 && !TDateTime.IsAvailableDate(this.tDateEdit_InputDayEd.GetDateTime()))
            //{
            //    errorMsg = "入力日(終了)" + CT_DATE_INVALID;
            //    return this.tDateEdit_InputDayEd;
            //}
            DateGetAcs.CheckDateResult cdResult;

            if (this.tDateEdit_InputDaySt.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_InputDaySt, true);
                //if (cdResult == DateGetAcs.CheckDateResult.ErrorOfNoInput) // DEL 2009/04/03
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid) // ADD 2009/04/03
                {
                    errorMsg = "入力日(開始)" + CT_DATE_INVALID;
                    return this.tDateEdit_InputDaySt;
                }
            }

            if (this.tDateEdit_InputDayEd.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_InputDayEd, true);
                //if (cdResult == DateGetAcs.CheckDateResult.ErrorOfNoInput) // DEL 2009/04/03
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid) // ADD 2009/04/03
                {
                    errorMsg = "入力日(終了)" + CT_DATE_INVALID;
                    return this.tDateEdit_InputDayEd;
                }
            }
            // --- CHG 2009/02/25 障害ID:7882対応------------------------------------------------------<<<<<
            // 2008.12.10 add end [8979]

            // 2008.12.16 add start [8987]

            // 両方入力されている場合のみ比較(片方のみ入力はOK)
            int startDate = this.tDateEdit_StockDateSt.GetLongDate();
            int endDate = this.tDateEdit_StockDateEd.GetLongDate();
            
            // --- DEL 2009/04/03 -------------------------------->>>>>
            //if (startDate == 0 && endDate == 0)
            //{
            //    errorMsg = CT_STOCKDATE_NOT_INPUT;
            //    return this.tDateEdit_StockDateSt;
            //}
            // --- DEL 2009/04/03 --------------------------------<<<<<

            // 日付の大小チェック
            if (startDate != 0 && endDate != 0) // ADD 2009/04/03
            {
                if (startDate - endDate > 0)
                {
                    errorMsg = CT_DATEED_MUSTBE_LATER;
                    return this.tDateEdit_StockDateSt;
                }
            }

            // --- ADD 2009/04/03 -------------------------------->>>>>
            // 入力日の大小チェック
            if (this.tDateEdit_InputDaySt.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_InputDayEd.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_InputDaySt.GetLongDate() > this.tDateEdit_InputDayEd.GetLongDate())
                {
                    errorMsg = CT_DATEED_MUSTBE_LATER;
                    return this.tDateEdit_InputDaySt;
                }
            }
            // --- ADD 2009/04/03 --------------------------------<<<<<

            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            //startDate = this.tDateEdit_InputDaySt.GetLongDate();
            //endDate = this.tDateEdit_InputDayEd.GetLongDate();
            //if (startDate - endDate > 0)
            //{
            //    errorMsg = CT_DATEED_MUSTBE_LATER;
            //    return this.tDateEdit_InputDaySt;
            //}
            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------<<<<<
            // 2008.12.16 add end [8987]


            return null;
        }

        #endregion // パラメータチェック

        #region 行の背景色変更処理

        /// <summary>
        /// 行の背景色変更処理
        /// </summary>
        private void SetRowBackColor()
        {
            int rowNo = 0;
            string salesDateString = string.Empty;
            int supplierSlipCd = 0;
            //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
            int wayToOrder = 0;
            string columnName_WayToOrder = string.Empty;
            //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
            string columnName_SalesDate = string.Empty;       // 売上日付を保持している列名
            string columnName_SupplierSlipCd = string.Empty;       // 仕入区分を保持している列名
            //------ADD BY 朱 猛 on 2012/10/09 for Redmine#31879------->>>>>>>
            int debitNoteDiv = 0;
            string columnName_DebitNoteDiv = string.Empty;
            //------ADD BY 朱 猛 on 2012/10/09 for Redmine#31879-------<<<<<<<

            // 伝票タブの全ての行を調整
            columnName_SalesDate = this._dataSet.SlipList.SalesDateStringColumn.ColumnName;
            columnName_SupplierSlipCd = this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName;
            columnName_WayToOrder = this._dataSet.SlipList.WayToOrderColumn.ColumnName;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            columnName_DebitNoteDiv = this._dataSet.SlipList.DebitNoteDivColumn.ColumnName;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
            {
                // UI行からデータセット行を特定し、各行のチェックボックス状態を取得
                rowNo = (int)(gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName]).Value;
                DataRow row = this._dataSet.Tables["SlipList"].Rows.Find(rowNo);
                if (row != null)
                {
                    // 売上日が存在すれば売仕入同時入力伝票
                    salesDateString = (string)row[columnName_SalesDate];
                    if (!String.IsNullOrEmpty(salesDateString))
                    {
                        gridRow.Appearance.BackColor = this._type04BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type04BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type04ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }

                    // 仕入区分が[20]であれば返品伝票(返品伝票が優先なので上書きされます)
                    supplierSlipCd = (int)row[columnName_SupplierSlipCd];
                    debitNoteDiv = (int)row[columnName_DebitNoteDiv];//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                    //if (supplierSlipCd == 20)//DEL BY 朱 猛 on 2012/10/09 for Redmine#31879
                    if (supplierSlipCd == 20 || debitNoteDiv == 1)//返品と赤伝の場合 ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                    {
                        gridRow.Appearance.BackColor = this._type03BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type03BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type03ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }
                    else // ADD BY 朱 猛 on 2012/09/27 for UOE返品の場合は背景色を赤にする
                    { // ADD BY 朱 猛 on 2012/09/27 for UOE返品の場合は背景色を赤にする
                        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
                        wayToOrder = Convert.ToInt32(row[columnName_WayToOrder]);
                        if (wayToOrder == 2)
                        {
                            gridRow.Appearance.BackColor = _type05BackColor1;
                        }
                        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
                    } // ADD BY 朱 猛 on 2012/09/27 for UOE返品の場合は背景色を赤にする
                }
            }

            // 明細タブの全ての行を調整
            columnName_SalesDate = this._dataSet.DetailList.SalesDateStringColumn.ColumnName;
            columnName_SupplierSlipCd = this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName;
            columnName_WayToOrder = this._dataSet.DetailList.WayToOrderColumn.ColumnName;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            columnName_DebitNoteDiv = this._dataSet.DetailList.DebitNoteDivColumn.ColumnName;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
            {
                // UI行からデータセット行を特定し、各行のチェックボックス状態を取得
                rowNo = (int)(gridRow.Cells[this._dataSet.DetailList.RowNoColumn.ColumnName]).Value;
                DataRow row = this._dataSet.Tables["DetailList"].Rows.Find(rowNo);
                if (row != null)
                {
                    // 売上日が存在すれば売仕入同時入力伝票
                    //if (row[columnName_SalesDate] != DBNull.Value)
                    //{
                    salesDateString = (string)row[columnName_SalesDate];
                    //}
                    if (!String.IsNullOrEmpty(salesDateString))
                    {
                        gridRow.Appearance.BackColor = this._type04BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type04BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type04ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }

                    // 仕入区分が[20]であれば返品伝票(返品伝票が優先なので上書きされます)
                    supplierSlipCd = (int)row[columnName_SupplierSlipCd];
                    debitNoteDiv = (int)row[columnName_DebitNoteDiv];//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                    //if (supplierSlipCd == 20)//DEL BY 朱 猛 on 2012/10/09 for Redmine#31879
                    if (supplierSlipCd == 20 || debitNoteDiv == 1)//返品と赤伝の場合 ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                    {
                        gridRow.Appearance.BackColor = this._type03BackColor1;
                        //gridRow.Appearance.BackColor2 = this._type03BackColor2;
                        //gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        //gridRow.Appearance.ForeColor = this._type03ForeColor1;  // DEL 2011/12/05 gezh redmine#8416
                    }
                    else // ADD BY 朱 猛 on 2012/09/27 for UOE返品の場合は背景色を赤にする
                    { // ADD BY 朱 猛 on 2012/09/27 for UOE返品の場合は背景色を赤にする
                        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
                        wayToOrder = Convert.ToInt32(row[columnName_WayToOrder]);
                        if (wayToOrder == 2)
                        {
                            gridRow.Appearance.BackColor = _type05BackColor1;
                        }
                        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
                    } // ADD BY 朱 猛 on 2012/09/27 for UOE返品の場合は背景色を赤にする
                }
            }
        }

        #endregion // 行の背景色変更処理

        #region チェックボックス操作

        #region データをもとにチェックボックスを調整

        /// <summary>
        /// データをもとにチェックボックスを調整
        /// </summary>
        private void SetupCheckBox_Slip()
        {
            int rowNo = 0;
            int checkBoxStatus = 0;
            string columnName_CheckBoxStatus = string.Empty;       // チェックボックス状態値を保持している列名
            string columnName_CheckBox = string.Empty;             // チェックボックスのある列名

            // 列名を取得
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
            }

            // 伝票タブの全ての行を調整
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
            {
                // UI行からデータセット行を特定し、各行のチェックボックス状態を取得
                rowNo = (int)(gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName]).Value;
                DataRow row = this._dataSet.Tables["SlipList"].Rows.Find(rowNo);
                if (row != null)
                {
                    checkBoxStatus = (int)row[columnName_CheckBoxStatus];

                    // チェックボックスのステータス値より、画面上の状態を計算
                    // ※チェックボックスステータスはクリック時に動的に変更される
                    switch (checkBoxStatus)
                    {
                        // チェックなし, チェックあり
                        case CT_CHECKBOXSTATUS_UNCHECK:
                        case CT_CHECKBOXSTATUS_CHECK:
                            {
                                // アルファレベルを変更(0:鮮明化)
                                gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = 0;
                                break;
                            }
                        // 不鮮明
                        case CT_CHECKBOXSTATUS_UNCLEAR:
                            {
                                // アルファレベルを変更(128:不鮮明化)
                                gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = CT_UNCLEAR_CHECKBOX_ALPHA;
                                break;
                            }

                        default: break;
                    }
                }
            }
        }

        /// <summary>
        /// データをもとにチェックボックスを調整(単行)
        /// </summary>
        /// <param name="row">行オブジェクト</param>
        private void SetupCheckBox_Slip(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            int rowNo = 0;
            int checkBoxStatus = 0;

            string columnName_CheckBoxStatus = string.Empty;       // チェックボックス状態値を保持している列名
            string columnName_CheckBox = string.Empty;             // チェックボックスのある列名

            // 列名を取得
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
            }

            // UI行からデータセット行を特定し、チェックボックス状態を取得
            rowNo = (int)(gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName]).Value;
            DataRow row = this._dataSet.Tables["SlipList"].Rows.Find(rowNo);
            if (row != null)
            {
                checkBoxStatus = (int)row[columnName_CheckBoxStatus];

                // チェックボックスのステータス値より、画面上の状態を計算
                // ※チェックボックスステータスはクリック時に動的に変更される
                switch (checkBoxStatus)
                {
                    // チェックなし, チェックあり
                    case CT_CHECKBOXSTATUS_UNCHECK:
                    case CT_CHECKBOXSTATUS_CHECK:
                        {
                            // アルファレベルを変更(0:鮮明化)
                            gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = 0;
                            break;
                        }
                    // 不鮮明
                    case CT_CHECKBOXSTATUS_UNCLEAR:
                        {
                            // アルファレベルを変更(128:不鮮明化)
                            gridRow.Cells[columnName_CheckBox].Appearance.AlphaLevel = CT_UNCLEAR_CHECKBOX_ALPHA;
                            break;
                        }

                    default: break;
                }
            }
        }

        #endregion // データをもとにチェックボックスを調整

        #region チェックボックスクリックイベント(伝票)

        /// <summary>
        /// チェックボックスクリックイベント(伝票)
        /// </summary>
        /// <param name="row"></param>
        private void OnClickSlipGridCheck(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            string columnName_CheckBoxStatus = string.Empty;       // チェックボックス状態値を保持している列名
            string columnName_CheckBox = string.Empty;             // チェックボックスのある列名

            // 列名を取得
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
            }

            // チェックボックスの状態を取得
            bool check;
            check = (bool)gridRow.Cells[columnName_CheckBox].Value;

            // 不鮮明ステータスの状態を取得
            int status;
            status = (int)gridRow.Cells[columnName_CheckBoxStatus].Value;

            // クリックされた行のチェックボックスを反転
            DataRow rowSlip = this._dataSet.Tables["SlipList"].Rows.Find((int)gridRow.Cells[this._dataSet.SlipList.RowNoColumn.ColumnName].Value);
            rowSlip[columnName_CheckBox] = !check;

            // ステータスを更新
            if (!check)
            {
                status = 0;
            }
            else
            {
                status = 1;
            }
            rowSlip[columnName_CheckBoxStatus] = status;

            // 仕入SEQ番号が同一の明細をチェック/チェック解除
            // 明細は仕入SEQ番号が同一だと表示されないので仕入SEQ番号(検索用)の列を検索する
            if (status != 2)
            {
                int supplierSlipNo = (int)gridRow.Cells[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Value;
                DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
                foreach (DataRow row in rows)
                {
                    row[columnName_CheckBox] = !check;
                }
            }
            else
            {
                // 不鮮明の場合はちょっと異なる
                int supplierSlipNo = (int)gridRow.Cells[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName].Value;
                DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
                foreach (DataRow row in rows)
                {
                    // チェックの状態および更新する/しない
                    // 伝票 ○ ○ × × (←クリックされた瞬間のチェック状態)
                    // 明細 ○ × ○ ×
                    // 更新 ○ × × ○
                    if ((bool)row[columnName_CheckBox] == check)
                    {
                        row[columnName_CheckBox] = !check;
                    }
                }
            }
            // チェックボックスの値を修正
            SetupCheckBox_Slip(gridRow);

            // 合計欄の更新
            ResetTotal();
        }

        #endregion // チェックボックスクリックイベント(伝票)

        #region チェックボックスクリックイベント(明細)

        /// <summary>
        /// チェックボックスクリックイベント(明細)
        /// </summary>
        /// <param name="row"></param>
        private void OnClickDetailGridCheck(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            string columnName_Detail_CheckBox = string.Empty;      // 明細)チェックボックスのある列名
            string columnName_CheckBoxStatus = string.Empty;       // 伝票)チェックボックス状態値を保持している列名
            string columnName_CheckBox = string.Empty;             // 伝票)チェックボックスのある列名

            // 列名を取得
            if (this._procDiv == 0)
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName;
            }
            else
            {
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName;
            }

            // チェックボックスの状態を取得
            bool check = (bool)gridRow.Cells[columnName_Detail_CheckBox].Value;

            // クリックされた行のチェックボックスを反転
            DataRow rowValue = this._dataSet.Tables["DetailList"].Rows.Find((int)gridRow.Cells[this._dataSet.DetailList.RowNoColumn.ColumnName].Value);
            rowValue[columnName_Detail_CheckBox] = !check;

            // --- UPD 2010/10/21 ---------->>>>>
            // 合計額更新
            //ResetTotal(rowValue, !check);
            ResetTotal(rowValue, !check, (int)gridRow.Cells[this._dataSet.DetailList.SupplierSlipNoKeyColumn.ColumnName].Value);
            // --- UPD 2010/10/21 ----------<<<<<

            // 仕入SEQ番号が同一の明細を全て取得し、伝票単位のチェック状態を計算
            // すべてチェック     →鮮明化,チェック
            // すべてチェックなし →鮮明化,未チェック
            // 一部チェック       →不鮮明化,チェック
            bool checkSlip;
            int status = 0;

            int supplierSlipNo = (int)gridRow.Cells[this._dataSet.DetailList.SupplierSlipNoKeyColumn.ColumnName].Value;
            DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("SupplierSlipNoKey = {0}", supplierSlipNo.ToString()));
            bool checkFirstRow = true;
            int count = 0;
            if (rows.Length > 1)
            {
                foreach (DataRow row in rows)
                {
                    // 一行目のチェックボックスが基準となる
                    if (count == 0)
                    {
                        checkFirstRow = (bool)row[columnName_Detail_CheckBox];

                        // チェックするに初期値を変更
                        if (checkFirstRow) status = 1;
                    }
                    else
                    {
                        // 一件でも異なれば不鮮明化
                        if ((bool)row[columnName_Detail_CheckBox] != checkFirstRow)
                        {
                            status = 2;
                            break;
                        }
                    }
                    count++;
                }

                // ステータスによりチェック状態が決定
                if (status == 0) // チェックされたものが一件もない
                {
                    checkSlip = false;
                }
                else
                {
                    checkSlip = true;
                }
            }
            else
            {
                // 1件しかない場合は明細のチェック状態=伝票のチェック状態
                checkSlip = !check;
                if (checkSlip)
                {
                    status = 1;
                }
            }

            // 伝票のチェックボックスを変更
            DataRow[] slipRows = this._dataSet.Tables["SlipList"].Select(String.Format("SupplierSlipNo = {0}", supplierSlipNo.ToString()));

            if (slipRows.Length == 1)
            {
                DataRow slipRow = slipRows[0];
                slipRow[columnName_CheckBox] = checkSlip;
                slipRow[columnName_CheckBoxStatus] = status;

                // チェックボックス色変更
                SetupCheckBox_Slip();
            }
        }

        #endregion // チェックボックスクリックイベント(明細)

        #region 全てチェッククリックイベント

        /// <summary>
        /// 日次(全)チェックボックスクリック(伝票)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Slip_CheckAllDaily_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(0);
        }

        /// <summary>
        /// 締次(全)チェックボックスクリック(伝票)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Slip_CheckAllCalc_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(1);
        }

        /// <summary>
        /// 日次(全)チェックボックスクリック(明細)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Detail_CheckAllDaily_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(2);
        }

        /// <summary>
        /// 締次(全)チェックボックスクリック(明細)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Detail_CheckAllCalc_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSlip(3);
        }

        /// <summary>
        /// 全チェック処理
        /// </summary>
        /// <param name="checkBoxFrom">どのチェックボックスから？</param>
        private void CheckAllSlip(int checkBoxFrom)
        {
            bool check = false;
            string columnName_CheckBox = string.Empty;
            string columnName_Detail_CheckBox = string.Empty;
            string columnName_CheckBoxStatus = string.Empty;
            string columnName_CheckBoxEx = string.Empty;
            string columnName_Detail_CheckBoxEx = string.Empty;
            string columnName_CheckBoxStatusEx = string.Empty;

            switch (checkBoxFrom)
            {
                case 0: // 伝票タブの日次(全)
                    {
                        check = this.uCheckEditor_Slip_CheckAllDaily.Checked;
                        this.uCheckEditor_Detail_CheckAllDaily.Checked = check;
                        break;
                    }
                case 1: // 伝票タブの締次(全)
                    {
                        check = this.uCheckEditor_Slip_CheckAllCalc.Checked;
                        this.uCheckEditor_Detail_CheckAllCalc.Checked = check;
                        break;
                    }
                case 2: // 明細タブの日次(全)
                    {
                        check = this.uCheckEditor_Detail_CheckAllDaily.Checked;
                        this.uCheckEditor_Slip_CheckAllDaily.Checked = check;
                        break;
                    }
                case 3: // 明細タブの締次(全)
                    {
                        check = this.uCheckEditor_Detail_CheckAllCalc.Checked;
                        this.uCheckEditor_Slip_CheckAllCalc.Checked = check;
                        break;
                    }
            }

            if (this._procDiv == 0)
            {
                // チェックボックスのある列名
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName;
                // チェックボックス状態値を保持している列名
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName;

                // 取得時の列名
                columnName_CheckBoxEx = this._dataSet.SlipList.CheckBoxDailyExColumn.ColumnName;
                columnName_Detail_CheckBoxEx = this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName;
                columnName_CheckBoxStatusEx = this._dataSet.SlipList.CheckBoxDailyStatusExColumn.ColumnName;
            }
            else
            {
                // チェックボックスのある列名
                columnName_CheckBox = this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName;
                columnName_Detail_CheckBox = this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName;
                // チェックボックス状態値を保持している列名
                columnName_CheckBoxStatus = this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName;

                // 取得時の列名
                columnName_CheckBoxEx = this._dataSet.SlipList.CheckBoxCalcExColumn.ColumnName;
                columnName_Detail_CheckBoxEx = this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName;
                columnName_CheckBoxStatusEx = this._dataSet.SlipList.CheckBoxCalcStatusExColumn.ColumnName;
            }


            foreach (DataRow row in this._dataSet.SlipList.Rows)
            {
                if (check)
                {
                    // 全てのチェックボックスをチェック
                    row[columnName_CheckBox] = true;
                    row[columnName_CheckBoxStatus] = 1; // チェック済
                }
                else
                {
                    // 全てのチェックボックスをクリア
                    row[columnName_CheckBox] = false;
                    row[columnName_CheckBoxStatus] = 0; // 未チェック

                    //// 取得時に戻す
                    //row[columnName_CheckBox] = (bool)row[columnName_CheckBoxEx];
                    //row[columnName_CheckBoxStatus] = (int)row[columnName_CheckBoxStatusEx];
                }
            }

            // 明細も全てチェック
            foreach (DataRow row in this._dataSet.DetailList.Rows)
            {
                if (check)
                {
                    // 全てのチェックボックスをチェック
                    row[columnName_Detail_CheckBox] = true;
                }
                else
                {
                    // 全てのチェックボックスをクリア
                    row[columnName_Detail_CheckBox] = false;

                    //// 取得時に戻す
                    //row[columnName_Detail_CheckBox] = (bool)row[columnName_Detail_CheckBoxEx];
                }
            }

            // 画面更新
            SetupCheckBox_Slip();

            // 2009.01.07 add [9858]
            ResetTotal();
            // 2009.01.07 add [9858]
        }

        #endregion

        #endregion // チェックボックス操作

        #endregion // プライベート関数

        #region コントロールメソッド

        #region ガイドボタン

        #region 拠点

        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out _sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = _sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = _sectionInfo.SectionGuideNm.Trim();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tEdit_SectionCodeAllowZero.Clear();
                this.tEdit_SectionName.Text = "";
            }
        }

        #endregion // 拠点

        #region 仕入先

        /// <summary>
        /// 仕入先ガイド表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド表示
            int status = 0;
            if (!String.IsNullOrEmpty(this._sectionCode))
            {
                status = this._supplierAcs.ExecuteGuid(out _supplier, this._enterpriseCode, _sectionCode);
            }
            else
            {
                status = this._supplierAcs.ExecuteGuid(out _supplier, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0'));
            }

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCd.SetInt(_supplier.SupplierCd);
                this.tEdit_SupplierSnm.Text = _supplier.SupplierSnm.Trim();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR ||
                status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierSnm.Text = "";
            }
        }

        #endregion // 仕入先

        #endregion // ガイドボタン

        #region ツールバー

        /// <summary>
        /// ツールバー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // 終了ボタン

                #region 確定ボタン
                case "ButtonTool_Decision":
                    {
                        Search();
                        break;
                    }
                #endregion // 確定ボタン

                #region クリアボタン
                case "ButtonTool_Clear":
                    {
                        InitializeScreen();
                        break;
                    }
                #endregion // クリアボタン

                #region 保存ボタン
                case "ButtonTool_Save":
                    {
                        UpdateCheck();
                        break;
                    }
                #endregion // 保存ボタン

                default: break;
            }
        }

        #endregion // ツールバー

        #region アローキーコントロール

        /// <summary>
        /// アローキーコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // フィールド間移動
                //---------------------------------------------------------------

                #region 処理区分
                case "tComboEditor_ProcDiv":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // 2008.12.10 modify start [8991]
                                    e.NextCtrl = null;
                                    // 2008.12.10 modify end [8991]
                                   
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 処理区分

                #region 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SectionGuide; // ガイドボタン
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCd;    // 仕入先コード
                                    }
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_ProcDiv; // 区分
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 拠点コード

                #region 拠点ガイド
                case "uButton_SectionGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_ProcDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 拠点ガイド

                #region 仕入先コード
                case "tNedit_SupplierCd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SupplierGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_SlipDiv; // 伝票区分
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入先コード

                #region 仕入先ガイド
                case "uButton_SupplierGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tComboEditor_SlipDiv;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入先ガイド

                #region 伝票区分
                case "tComboEditor_SlipDiv":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tComboEditor_CheckDiv;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 処理区分

                #region チェック区分
                case "tComboEditor_CheckDiv":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateSt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_SlipDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // チェック区分

                #region 仕入日(開始)
                case "tDateEdit_StockDateSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDaySt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_CheckDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入日(開始)

                #region 仕入日(終了)
                case "tDateEdit_StockDateEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDaySt;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDayEd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tComboEditor_CheckDiv;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入日(終了)

                #region 入力日(開始)
                case "tDateEdit_InputDaySt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDayEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoSt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateSt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 入力日(開始)

                #region 入力日(終了)
                case "tDateEdit_InputDayEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoSt;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoEd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_StockDateEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 入力日(終了)

                #region 仕入SEQ番号(開始)
                case "tNedit_SupplierSlipNoSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumSt;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDaySt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入SEQ番号(開始)

                #region 仕入SEQ番号(終了)
                case "tNedit_SupplierSlipNoEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumSt;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumEd;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tDateEdit_InputDayEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入SEQ番号(終了)

                #region 伝票番号(開始)
                case "tEdit_PartySalesSlipNumSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tEdit_PartySalesSlipNumEd;
                                    break;
                                }
                            case Keys.Down:
                                {
                                    if (this._dataSet.DetailList.Rows.Count > 0)
                                    {
                                        if (this.uTabControl_Grid.ActiveTab.Key == "Tab_Slip")
                                        {
                                            e.NextCtrl = this.uGrid_Slip;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uGrid_Detail;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_ProcDiv;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoSt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 伝票番号(開始)

                #region 伝票番号(終了)
                case "tEdit_PartySalesSlipNumEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (this._dataSet.DetailList.Rows.Count > 0)
                                    {
                                        if (this.uTabControl_Grid.ActiveTab.Key == "Tab_Slip")
                                        {
                                            e.NextCtrl = this.uGrid_Slip;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uGrid_Detail;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_ProcDiv;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    e.NextCtrl = this.tNedit_SupplierSlipNoEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入SEQ番号(終了)

                // ADD 2011/12/05 gezh redmine#8416 ----------------------------------->>>>>
                #region 伝票
                case "uGrid_Slip":
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Slip.ActiveRow;
                        switch (e.Key)
                        {
                            case Keys.Enter:
                                {
                                    if (ultraGridRow == null) return;
                                    OnClickSlipGridCheck(ultraGridRow);
                                    // 下のRowに移動
                                    // DEL 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    //bool performActionResult = this.uGrid_Slip.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    //if (performActionResult)
                                    //{
                                    //    e.NextCtrl = this.uGrid_Slip;
                                    //}
                                    // DEL 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    // ADD 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    this.uGrid_Slip.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    e.NextCtrl = this.uGrid_Slip;
                                    // ADD 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    break;
                                }
                        }
                        break;
                    }
                #endregion

                #region 明細
                case "uGrid_Detail":
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Detail.ActiveRow;
                        switch (e.Key)
                        {
                            case Keys.Enter:
                                {
                                    if (ultraGridRow == null) return;
                                    OnClickDetailGridCheck(ultraGridRow);
                                    // 下のセルに移動
                                    // DEL 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    //bool performActionResult = this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    //if (performActionResult)
                                    //{
                                    //    e.NextCtrl = this.uGrid_Detail;
                                    //}
                                    // DEL 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    // ADD 2011/12/13 gezh redmine#26642 ----------------------->>>>>
                                    this.uGrid_Detail.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowRow);
                                    e.NextCtrl = this.uGrid_Detail;
                                    // ADD 2011/12/13 gezh redmine#26642 -----------------------<<<<<
                                    break;
                                }
                        }
                        break;
                    }
                #endregion
                // ADD 2011/12/05 gezh redmine#8416 -----------------------------------<<<<<
                default: break;
            }
        }

        #endregion // アローキーコントロール

        #endregion // コントロールメソッド

        #region コントロールイベント

        #region 名称変換(Leaveイベント)

        #region 拠点コード

        /// <summary>
        /// 拠点コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // 名称変換
            this._sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // 全社対応処理
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // コードは規定の全体コードへ（検索時には規定の全体コードのとき空白にする）
                this._sectionCode = CT_CODE_ALLSECCODE;
                sectionName = CT_NAME_ALLSECCODE;
                this.tEdit_SectionName.Text = sectionName;
            }
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    this.tEdit_SectionName.Text = sectionName;
                }
                else
                {
                    // 2008.12.10 add start [9007]
                    // 未登録コードは00へ
                    this._sectionCode = CT_CODE_ALLSECCODE;
                    sectionName = CT_NAME_ALLSECCODE;
                    this.tEdit_SectionName.Text = sectionName;
                    this.tEdit_SectionCodeAllowZero.Text = "00";
                    // 2008.12.10 add end [9007]
                }
            }
        }

        #endregion // 拠点コード

        #region 仕入先コード

        /// <summary>
        /// 仕入先コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_SupplierCd_Leave(object sender, EventArgs e)
        {
            // 名称変換
            int supplierCd = this.tNedit_SupplierCd.GetInt();
            string supplierName = string.Empty;

            // 変換
            if (supplierCd > 0)
            {
                supplierName = GetSupplierName(supplierCd);
                //if (!String.IsNullOrEmpty(supplierName.Trim()))   // DEL 2009/06/29
                if ((this._supplier != null) && (this._supplier.SupplierCd != 0))   // ADD 2009/06/29
                {
                    this.tEdit_SupplierSnm.Text = supplierName;
                }
                else
                {
                    // 2008.12.10 add start [9005]
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierSnm.Clear();
                    // 2008.12.10 add end [9005]
                }
            }
            else
            {
                // 2008.12.10 add start [8976]
                this.tEdit_SupplierSnm.Clear();
                // 2008.12.10 add end [8976]
            }
        }

        #endregion // 仕入先コード

        #endregion // 名称変換(Leaveイベント)

        #region グリッドをクリック

        /// <summary>
        /// 伝票一覧グリッド クリックイベント
        /// </summary>
        /// <param name="sender">グリッドオブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void uGrid_Slip_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // 列ヘッダクリックかどうかを判定
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));
            if (objHeader != null) return;

            // 行クリックかどうかを判定
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
            
            // 選択チェック
            if (this._procDiv == 0 && objCell == objRow.Cells[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName])
            {
                OnClickSlipGridCheck(objRow);
            }

            // 選択チェック
            if (this._procDiv == 1 && objCell == objRow.Cells[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName])
            {
                OnClickSlipGridCheck(objRow);
            }
        }

        /// <summary>
        /// 明細一覧グリッド クリックイベント
        /// </summary>
        /// <param name="sender">グリッドオブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void uGrid_Detail_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // 列ヘッダクリックかどうかを判定
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));
            if (objHeader != null) return;

            // 行クリックかどうかを判定
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            // 選択チェック
            if (this._procDiv == 0 && objCell == objRow.Cells[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName])
            {
                OnClickDetailGridCheck(objRow);
            }

            // 選択チェック
            if (this._procDiv == 1 && objCell == objRow.Cells[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName])
            {
                OnClickDetailGridCheck(objRow);
            }
        }

        #endregion // グリッドをクリック

        #region 区分コンボボックス切替

        /// <summary>
        /// 区分コンボボックス切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ProcDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_ProcDiv.SelectedItem.DataValue == 0)
            {
                // ------
                //  日次
                // ------

                // 日次のチェックボックスを有効化
                this.uCheckEditor_Slip_CheckAllDaily.Enabled = true;
                this.uCheckEditor_Detail_CheckAllDaily.Enabled = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }


                // 締次のチェックボックスをすべて無効化
                this.uCheckEditor_Slip_CheckAllCalc.Enabled = false;
                this.uCheckEditor_Detail_CheckAllCalc.Enabled = false;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }
            }
            else
            {
                // ------
                //  締次
                // ------

                // 日次のチェックボックスをすべて無効化
                this.uCheckEditor_Slip_CheckAllDaily.Enabled = false;
                this.uCheckEditor_Detail_CheckAllDaily.Enabled = false;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                }


                // 締次のチェックボックスを有効化
                this.uCheckEditor_Detail_CheckAllCalc.Enabled = true;
                this.uCheckEditor_Slip_CheckAllCalc.Enabled = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Slip.Rows)
                {
                    gridRow.Cells[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Detail.Rows)
                {
                    gridRow.Cells[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
            }

            // 区分を保存
            this._procDiv = (int)this.tComboEditor_ProcDiv.SelectedItem.DataValue;

            // 合計額更新
            // 2009.01.07 add [9858]
            if (this._dataSet.DetailList.Rows.Count > 0)
            {
                ResetTotal();
            }
            // 2009.01.07 add [9858]
        }

        #endregion // 区分コンボボックス切替

        #region タブ切替

        /// <summary>
        /// タブ切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uTabControl_Grid_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            if (this.uTabControl_Grid.ActiveTab.Key == "Tab_Slip")
            {
                #region 伝票タブ
                // 明細グリッドの表示領域および先頭UI行オブジェクトを取得
                Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_detail = this.uGrid_Detail.DisplayLayout.RowScrollRegions[0];
                Infragistics.Win.UltraWinGrid.UltraGridRow fr_detail = rsr_detail.FirstRow;

                if (fr_detail != null)
                {
                    // UI行オブジェクトが存在するときのみ(未検索時は飛ばす)
                    int supplierSlipNo = (int)fr_detail.Cells["SupplierSlipNoKey"].Value;
                    DataRow[] rows = this._dataSet.Tables["SlipList"].Select(String.Format("{0} = {1}", "SupplierSlipNo", supplierSlipNo.ToString()));
                    if (rows.Length > 0)
                    {
                        // キーとなるRowNoの値を取得し、それを元に伝票タブのUI行オブジェクトを取得する
                        int rowNo = (int)rows[0]["RowNo"];
                        Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = this.uGrid_Slip.Rows[rowNo - 1];

                        // 行スクロール領域を取得、取得した行を表示領域に
                        this.uGrid_Slip.DisplayLayout.RowScrollRegions[0].FirstRow = gridRow;
                        
                        // 横スクロールバーの位置を合わせる（列単位での取得ができないため）
                        this.uGrid_Slip.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position;
                    }
                }
                #endregion // 伝票タブ
            }
            else
            {
                #region 明細タブ
                // 伝票グリッドの表示領域および先頭UI行オブジェクトを取得
                Infragistics.Win.UltraWinGrid.RowScrollRegion rsr_slip = this.uGrid_Slip.DisplayLayout.RowScrollRegions[0];
                Infragistics.Win.UltraWinGrid.UltraGridRow fr_slip = rsr_slip.FirstRow;

                if (fr_slip != null)
                {
                    // UI行オブジェクトが存在するときのみ(未検索時は飛ばす)
                    int supplierSlipNo = (int)fr_slip.Cells["SupplierSlipNo"].Value;
                    // 明細検索時は、[SupplierSlipNo]列を検索することで、明細の先頭行が得られる
                    DataRow[] rows = this._dataSet.Tables["DetailList"].Select(String.Format("{0} = {1}", "SupplierSlipNo", supplierSlipNo.ToString()));
                    if (rows.Length > 0)
                    {
                        // キーとなるRowNoの値を取得し、それを元に伝票タブのUI行オブジェクトを取得する
                        int rowNo = (int)rows[0]["RowNo"];
                        Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = this.uGrid_Detail.Rows[rowNo - 1];

                        // 行スクロール領域を取得、取得した行を表示領域に
                        this.uGrid_Detail.DisplayLayout.RowScrollRegions[0].FirstRow = gridRow;

                        // 横スクロールバーの位置を合わせる（列単位での取得ができないため）
                        this.uGrid_Detail.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Slip.DisplayLayout.ColScrollRegions[0].Position;
                    }
                }
                #endregion // 明細タブ
            }
        }

        #endregion // タブ切替
        // ADD 2011/12/05 gezh redmine#8416 -------------------------->>>>>
        /// <summary>
        /// Control.KeyDown イベント(伝票タブ)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void uGrid_Slip_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Slip.ActiveRow;
            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Slip.CurrentState;
            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            if (ultraGridRow == null) return;
                            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.uGrid_Slip, this.uGrid_Slip);
                            this.tArrowKeyControl_ChangeFocus(this.uGrid_Slip, evt);
                            this.uGrid_Slip.ActiveRow.Selected = false;
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// Control.KeyDown イベント(明細タブ)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void uGrid_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.uGrid_Detail.ActiveRow;
            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Detail.CurrentState;
            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            if (ultraGridRow == null) return;
                            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.uGrid_Detail, this.uGrid_Detail);
                            this.tArrowKeyControl_ChangeFocus(this.uGrid_Detail, evt);
                            this.uGrid_Detail.ActiveRow.Selected = false;
                            break;
                        }
                }
            }
        }
        // ADD 2011/12/05 gezh redmine#8416 --------------------------<<<<<
        #endregion // コントロールイベント

        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
        # region [グリッドカラム情報 保存・復元]
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid">targetGrid</param>
        /// <param name="settingList">settingList</param>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面のグリッドカラム情報の保存。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<DetailColumnInfo> settingList)
        {
            settingList = new List<DetailColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new DetailColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid">targetGrid</param>
        /// <param name="settingList">targetGrid</param>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面のリッドカラム情報の読み込み。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<DetailColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラム設定情報を表示順でソートする
            settingList.Sort(new ColumnInfoComparer());

            // 一度、全てのカラムのFixedを解除する
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (DetailColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// ColumnInfo比較クラス（ソート用）
        /// </summary>
        public class ColumnInfoComparer : IComparer<DetailColumnInfo>
        {
            /// <summary>
            /// ColumnInfo比較処理
            /// </summary>
            /// <param name="x">x</param>
            /// <param name="y">y</param>
            /// <returns>ステータス</returns>
            /// <remarks>
            /// <br>Note       : ColumnInfo比較クラス（ソート用）</br>
            /// <br>Programmer : 凌小青</br>
            /// <br>Date       : 2012/08/30</br>
            /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
            /// <br>                           No.1159のグリッドの仕様変更の対応</br>
            /// <br></br>
            /// </remarks>
            public int Compare(DetailColumnInfo x, DetailColumnInfo y)
            {
                // 列表示順で比較
                int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
                // 列表示順が一致する場合は列名で比較(通常は発生しない)
                if (result == 0)
                {
                    result = x.ColumnName.CompareTo(y.ColumnName);
                }
                return result;
            }
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面のグリッドカラム情報の読み込み。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        public void LoadSettings()
        {
            // 伝票グリッド
            this.LoadGridColumnsSetting(ref uGrid_Slip, this._userSetting.SlipColumnsList);
            // 明細グリッド
            this.LoadGridColumnsSetting(ref uGrid_Detail, this._userSetting.DetailColumnsList);
        }

        /// <summary>
        /// PMKAU04901UCA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面のグリッドカラム情報の読み込み。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        private void PMKOU01101UA_Load(object sender, EventArgs e)
        {
            // 設定読み込み
            Deserialize();
            //グリッドカラム情報の読み込み
            LoadSettings();
        }

        /// <summary>
        /// フォームクローズ前処理
        /// </summary>
        /// <remarks>FormClosingイベントだと×ボタン時に抜けてしまうので、Parentでウィンドウメッセージを扱う</remarks>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面のグリッドカラム情報の読み込み。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // フォームを閉じる時(×ボタンも含む)
            //-----------------------------------------
            // ユーザー設定保存(→XML書き込み)
            // 伝票グリッド
            List<DetailColumnInfo> slipColumnsList;
            this.SaveGridColumnsSetting(uGrid_Slip, out slipColumnsList);
            this._userSetting.SlipColumnsList = slipColumnsList;

            // 明細グリッド
            List<DetailColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Detail, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            //仕入チェック処理画面のシリアライズを行います。
            Serialize();
        }

        /// <summary>
        /// 仕入チェック処理画面グリッド設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面グリッド設定クラス</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        [Serializable]
        public class SupplierCheckOrderSet
        {
            // 出力形式
            private int _outputStyle;

            // 伝票グリッドカラムリスト
            private List<DetailColumnInfo> _slipColumnsList;

            // 明細グリッドカラムリスト
            private List<DetailColumnInfo> _detailColumnsList;

            // 明細グリッド自動サイズ調整
            private bool _autoAdjustDetail;

            # region コンストラクタ
            /// <summary>
            /// キャンペーン対象商品設定マスタ用グリッド設定クラス
            /// </summary>
            public SupplierCheckOrderSet()
            {

            }
            # endregion

            /// <summary>出力型式</summary>
            public int OutputStyle
            {
                get { return this._outputStyle; }
                set { this._outputStyle = value; }
            }

            /// <summary>伝票グリッドカラムリスト</summary>
            public List<DetailColumnInfo> SlipColumnsList
            {
                get { return this._slipColumnsList; }
                set { this._slipColumnsList = value; }
            }

            /// <summary>明細グリッドカラムリスト</summary>
            public List<DetailColumnInfo> DetailColumnsList
            {
                get { return this._detailColumnsList; }
                set { this._detailColumnsList = value; }
            }

            /// <summary>明細グリッド自動サイズ調整</summary>
            public bool AutoAdjustDetail
            {
                get { return _autoAdjustDetail; }
                set { _autoAdjustDetail = value; }
            }
        }


        # region [DetailColumnInfo]
        /// <summary>
        /// ColumnInfo
        /// </summary>
        [Serializable]
        public struct DetailColumnInfo
        {
            /// <summary>列名</summary>
            private string _columnName;
            /// <summary>並び順</summary>
            private int _visiblePosition;
            /// <summary>非表示フラグ</summary>
            private bool _hidden;
            /// <summary>幅</summary>
            private int _width;
            /// <summary>固定フラグ</summary>
            private bool _columnFixed;

            /// <summary>
            /// 列名
            /// </summary>
            public string ColumnName
            {
                get { return _columnName; }
                set { _columnName = value; }
            }
            /// <summary>
            /// 並び順
            /// </summary>
            public int VisiblePosition
            {
                get { return _visiblePosition; }
                set { _visiblePosition = value; }
            }
            /// <summary>
            /// 非表示フラグ
            /// </summary>
            public bool Hidden
            {
                get { return _hidden; }
                set { _hidden = value; }
            }
            /// <summary>
            /// 幅
            /// </summary>
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }
            /// <summary>
            /// 固定フラグ
            /// </summary>
            public bool ColumnFixed
            {
                get { return _columnFixed; }
                set { _columnFixed = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="columnName">列名</param>
            /// <param name="visiblePosition">並び順</param>
            /// <param name="hidden">非表示フラグ</param>
            /// <param name="width">幅</param>
            /// <param name="columnFixed">固定フラグ</param>
            /// <remarks>
            /// <br>Note       : コンストラクタ</br>
            /// <br>Programmer : 凌小青</br>
            /// <br>Date       : 2012/08/30</br>
            /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
            /// <br>                           No.1159のグリッドの仕様変更の対応</br>
            /// <br></br>
            /// </remarks>
            public DetailColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
            {
                _columnName = columnName;
                _visiblePosition = visiblePosition;
                _hidden = hidden;
                _width = width;
                _columnFixed = columnFixed;
            }
        }

        # endregion

        /// <summary>
        /// PMKOU01101UA_FormClosing 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : PMKOU01101UA_FormClosing </br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        private void PMKOU01101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // フォームを閉じる時(×ボタンも含む)
            //-----------------------------------------
            // ユーザー設定保存(→XML書き込み)
            // 伝票グリッド
            List<DetailColumnInfo> slipColumnsList;
            this.SaveGridColumnsSetting(uGrid_Slip, out slipColumnsList);
            this._userSetting.SlipColumnsList = slipColumnsList;
            // 明細グリッド
            List<DetailColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Detail, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            //仕入チェック処理画面のシリアライズを行います。
            Serialize();
        }

        /// <summary>
        /// 仕入チェック処理画面のシリアライズを行います。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面のシリアライズを行います。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// 仕入チェック処理画面をデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入チェック処理画面をデシリアライズします。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<SupplierCheckOrderSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new SupplierCheckOrderSet();
                }
            }
        }
        # endregion
        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
       
    }
}