//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換UIフォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinStatusBar;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PM.NS統合ツール　得意先マスタコード変換UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換UIフォームクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public partial class PMKHN05121UA : Form
    {
        #region -- Constant --

        /// <summary>プログラムIDを表す定数:PMKHN05121UA</summary>
        private readonly string pgId = "PMKHN05121U";
        /// <summary>グリッドのグループヘッダNoを表す定数</summary>
        private readonly string hdrGrpKeyNo = "NoGrp";
        /// <summary>グリッドのグループヘッダ変更前を表す定数</summary>
        private readonly string hdrGrpKeyBefore = "BeforeGrp";
        /// <summary>グリッドのグループヘッダ変更後を表す定数</summary>
        private readonly string hdrGrpKeyAfter = "AfterGrp";
        /// <summary>抽出条件、一括設定の縮小時のサイズ</summary>
        private readonly int egbGrpBoxCntrctSize = 25;
        /// <summary>得意先名称が登録されていないことを示す定数：未登録</summary>
        private readonly string noCustomerName = "未登録";
        /// <summary>先頭行を表す定位数</summary>
        private readonly int firstRow = 0;
        /// <summary>得意先コード変換対象ファイルに不正データが有ることを示す定数：997</summary>
        private const int ILLEGAL_DATA = 997;
        /// <summary>得意先コード変換対象ファイルにデータが無いことを示す定数：998</summary>
        private const int NO_DATA = 998;
        /// <summary>得意先コード変換対象ファイルが存在しないことを示す定数：999</summary>
        private const int NO_FILE = 999;
        /// <summary>数値チェック用の正規表現：^\d+$</summary>
        private readonly string regPttrnNum = @"^\d+$";

        #region -- ログ関連 --
        /// <summary>ログ出力先のディレクトリ名を表す定数：./LOG/PMKHN05120U</summary>
        private const string LOG_DIR_PATH = @"./LOG/PMKHN05120U";
        /// <summary>ログファイル名を表す定数：PMKHN05120U.log</summary>
        private const string LOG_FILE_NAME = @"PMKHN05120U_{0}.log";
        /// <summary>ログファイル名の日付部分のフォーマット：yyyyMMdd</summary>
        private const string LOG_FORMAT_DATE = "yyyyMMdd";
        /// <summary>ログフォーマット：HH:mm:ss</summary>
        private const string LOG_FORMAT_PROCESSING_TIME = "HH:mm:ss";
        /// <summary>ログフォーマット：[{0}] 得意先コード変換処理を開始します。</summary>
        private const string LOG_FORMAT_START = "[{0}] 得意先コード変換処理を開始します。";
        /// <summary>ログフォーマット：[{0}] 得意先コード変換処理が完了しました。</summary>
        private const string LOG_FORMAT_END = "[{0}] 得意先コード変換処理が完了しました。";
        /// <summary>ログフォーマット：[{0}],更新対象：{1},更新件数：{2}件,処理時間：{3}</summary>
        private const string LOG_FORMAT_CASE_BY_BASE = "[{0}],更新対象：{1},更新件数：{2}件,処理時間：{3}";
        /// <summary>ログフォーマット：[{0}],総処理時間：{1},総更新件数：{2}件</summary>
        private const string LOG_FORMAT_TOTAL = "[{0}],総処理時間：{1},総更新件数：{2}件";
        /// <summary>ログフォーマット：[{0}] {1}の変換中にエラーが発生しました。変換処理を中止します。</summary>
        private const string LOG_FORMAT_ERROR = "[{0}] {1}の変換中にエラーが発生しました。変換処理を中止します。";
        /// <summary>ログファイル内の日付フォーマット：yyyy/MM/dd HH:mm:ss</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd HH:mm:ss";
        #endregion

        /// <summary>得意先コードのフォーマット</summary>
        private static readonly string cdFormat = "{0:D8}";

        #endregion

        #region -- Member --

        /// <summary>
        /// ステータスバー更新処理デリゲート
        /// </summary>
        /// <param name="mes">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーを更新するためのデリゲート。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        delegate void UpdateStatusBarDelegate(string mes);

        /// <summary>
        /// ステータスバー初期化処理デリゲート
        /// </summary>
        /// <param name="mes">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーを初期化するためのデリゲート。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        delegate void InitStatusBarDelegate(int cnvTrgCount);

        // アクセスクラス関連
        /// <summary>得意先ガイド</summary>
        private CustomerInfoAcs customerAcs;
        /// <summary>得意先コード変換</summary>
        private CustomerConvertAcs customerCnvAcs;
        /// <summary>拠点マスタ</summary>
        private SecInfoAcs secInfoAcs;
        /// <summary>処理中ダイアログ</summary>
        private SFCMN00299CA procDlg = null;

        /// <summary>ログインユーザの所属拠点</summary>
        private string loginSecCd = String.Empty;
        /// <summary>企業コード</summary>
        private string enterPriseCd = String.Empty;
        /// <summary>抽出条件と一括設定のUltraExpandableGroupBoxの展開時の高さ情報を格納したマップ</summary>
        private IDictionary<EgbGrpBoxType, int> egbGrpBoxHeighMap = null;
        /// <summary>画面のスキン情報を格納</summary>
        private ControlScreenSkin ctrlScrnSkin;
        /// <summary>拠点情報情報格納マップ</summary>
        private Dictionary<string, String> secInfoMap;
        /// <summary>得意先情報格納マップ</summary>
        private Dictionary<string, String> customerInfoMap;
        /// <summary>更新フラグ(true:更新済み/false:未更新)</summary>
        private bool isUpdate = false;
        /// <summary>編集済み確認フラグ(true:編集済み/false:未編集)</summary>
        private bool isEdit = false;
        /// <summary>入力チェックの結果を格納する変数(true:チェックOK/false:チェックNG)</summary>
        private bool isCheckOK = false;
        /// <summary>コードの桁数</summary>
        private readonly int codeLength;
        /// <summary>スレッド実行時のエラーメッセージを保存</summary>
        private string cnvErrMes = String.Empty;
        /// <summary>FormCloingイベントで実施されたかを判定するフラグ(true:FormCloigから実施/false:FormCloing以外で実施)</summary>
        private bool isCallFormCloseingEvent = false;
        /// <summary>一括設定の各項目の入力値を保存するマップ</summary>
        private IDictionary<AllSettingType, int> allSttngPrevValMap = null;
        /// <summary>押下されたガイドボタンを保持する変数</summary>
        private GuidButtonType btnType;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　得意先マスタコード変換UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、得意先マスタコード変換UIフォームクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public PMKHN05121UA()
        {
            InitializeComponent();

            // 各種部品の初期化を行います。
            this.ctrlScrnSkin = new ControlScreenSkin();
            // 抽出条件と一括設定の展開時の高さ情報を保存します。
            this.egbGrpBoxHeighMap = new Dictionary<EgbGrpBoxType, int>(Enum.GetValues(typeof(EgbGrpBoxType)).Length);
            this.egbGrpBoxHeighMap[EgbGrpBoxType.CollectiveSetting] = this.ultrEgbCllctvSttng.Height;
            this.egbGrpBoxHeighMap[EgbGrpBoxType.Condition] = this.ultrEgbCondition.Height;

            // 一括設定の各小目の入力値を保存するマップを初期化します。
            this.InitAllSttngPrevValMap();

            // コードの桁数を設定します。
            this.codeLength = 8;
        }

        #endregion

        #region -- Protected Method --

        /// <summary>
        /// 画面の初期化処理
        /// </summary>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                // 基底クラスのロードを実行します。
                base.OnLoad(e);

                // 画面の描画を一時停止します。
                this.SuspendLayout();

                // 各コントロールの初期化を実行します。
                this.InitSetting();

                // 画面のスキンを設定します。
                this.InitSkin();

                // メニュー、及びボタンのアイコンを設定します。
                this.tToolBarMain.ImageListSmall = IconResourceManagement.ImageList16;
                this.ultrBtnCstmrStart.ImageList = IconResourceManagement.ImageList16;
                this.ultrBtnCstmrEnd.ImageList = IconResourceManagement.ImageList16;

                // 拠点マスタの初期化
                this.secInfoAcs = new SecInfoAcs();
                this.SaveSecInfoToMemory();

                // 企業コード
                this.enterPriseCd = LoginInfoAcquisition.EnterpriseCode;
                // ログイン拠点コード
                this.loginSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                // ログインユーザ情報を初期化
                this.SetUserInfo();

                // 得意先マスタの初期化
                this.customerAcs = new CustomerInfoAcs();

                // グリッドの初期設定を行います。
                this.InitGrid();

                // 得意先コード変換アクセスクラス
                this.customerCnvAcs = new CustomerConvertAcs();
                this.SaveCustomerInfoToMemory();

                // 数値入力欄の初期化
                this.SetTnEditMaxLength(this.pnlCllctvSttng);
                this.SetTnEditMaxLength(this.pnlCondtion);

                // 一括設定の入力欄を初期化します。
                this.SetAllSettingTypeOnTNEdit();

                // 画面の描画を再開します。
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                this.ShowError(String.Format(MessageMng.ERR_MES_012, ex.Message), 
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
        }

        #endregion

        #region -- Private Method --

        #region -- 初期設定関連 --

        /// <summary>
        /// 画面スキンファイル初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面スキンファイルの初期設定を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitSkin()
        {
            // スキン適用外のコントロールを保存します
            List<string> exclustionList = new List<string>();
            exclustionList.Add(this.ultrEgbCllctvSttng.Name);
            exclustionList.Add(this.ultrEgbCondition.Name);
            this.ctrlScrnSkin.SetExceptionCtrl(exclustionList);

            // 画面スキンファイルを設定します。
            this.ctrlScrnSkin.LoadSkin();
            this.ctrlScrnSkin.SettingScreenSkin(this);
        }

        /// <summary>
        /// 各コントロール初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 各コントロールの初期設定を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitSetting()
        {
            // UltraExpandableGroupBoxの初期化
            // 抽出条件
            this.ultrEgbCondition.Tag = EgbGrpBoxType.Condition;
            // 一括設定
            this.ultrEgbCllctvSttng.Tag = EgbGrpBoxType.CollectiveSetting;

            // 得意先ガイドボタンの初期化
            // 得意先ガイド開始
            this.ultrBtnCstmrStart.Tag = GuidButtonType.Start;
            // 得意先ガイド終了
            this.ultrBtnCstmrEnd.Tag = GuidButtonType.End;
        }

        /// <summary>
        /// ユーザ情報初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログインユーザ情報を元にユーザの表示情報を設定します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetUserInfo()
        {
            // ログイン情報が無い場合は、これ以降の処理を実行しません。
            if (LoginInfoAcquisition.Employee == null)
            {
                return;
            }

            // メニューバーの拠点名とログイン名に値をセットします。
            foreach (ToolBase tlBase in this.tToolBarMain.Tools)
            {
                switch (tlBase.Key)
                {
                    case ToolMenuType.LBL_TOOL_SECTION:
                        // 拠点名の場合
                        tlBase.SharedProps.Caption = this.GetSecName(LoginInfoAcquisition.Employee.BelongSectionCode);
                        break;
                    case ToolMenuType.LBL_TOOL_NAME:
                        // ログイン名の場合
                        tlBase.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
                        break;
                    default:
                        // 上記以外の場合は、何も処理しません。
                        break;
                }
            }
        }

        /// <summary>
        /// 数値入力欄初期化処理
        /// </summary>
        /// <param name="parent">コントロール</param>
        /// <remarks>
        /// <br>Note       : 数値入力欄の初期化を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetTnEditMaxLength(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                TNedit edit = child as TNedit;
                if (edit == null)
                {
                    // nullの場合は非TNEditなので、子コントロールにTNEditが無いか
                    // 再帰的に調べます。
                    this.SetTnEditMaxLength(child);
                }
                else
                {
                    // TNeditの場合は、最大桁数を設定します。
                    edit.MaxLength = this.codeLength +1; //マイナスを考慮
                }
            }
        }

        /// <summary>
        /// 一括設定入力欄初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括設定入力欄の初期化を行います。</br>
        /// <br>             Tagにそれぞれの入力欄がどの一括設定を表す列挙子を設定します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetAllSettingTypeOnTNEdit()
        {
            // 加算
            this.tNdtAdd.Tag = AllSettingType.ADD;
            // 乗算
            this.tNdtMul.Tag = AllSettingType.Multiplication;
            // 連番
            this.tNdtSerNum.Tag = AllSettingType.Sequence;
        }

        /// <summary>
        /// 一括設定入力欄設定値初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メモリに保持している一括設定で入力した各項目の値を初期化します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitAllSttngPrevValMap()
        {
            // インスタンスが生成されていない場合は、インスタンスの生成を行ったうえでMapの初期化を実行します。
            if (this.allSttngPrevValMap == null)
            {
                this.allSttngPrevValMap = new Dictionary<AllSettingType, int>(Enum.GetValues(typeof(AllSettingType)).Length - 1);
            }

            foreach (AllSettingType type in Enum.GetValues(typeof(AllSettingType)))
            {
                switch (type)
                {
                    case AllSettingType.Equivalence:
                        // 何も処理しません。
                        break;
                    default:
                        // 同値以外はkey：一括設定の種類(AllSettingType)、value：0で初期化します。
                        this.allSttngPrevValMap[type] = 0;
                        break;
                }
            }
        }

        #endregion

        #region -- コントロールの初期化 --

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件等の入力内容、及びグリッドの情報をクリアします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void Clear()
        {
            // 抽出条件のクリア
            this.InitControl(this.pnlCondtion);
            // 一括設定のクリア
            this.InitControl(this.pnlCllctvSttng);

            // グリッドのクリア
            ((DataView)this.ultrGrid.DataSource).Table.Clear();

            // ステータスバーを初期状態に戻します。
            this.InitStatusBar();

            // 更新済みフラグと編集済みフラグをoffにします。
            this.isUpdate = false;
            this.isEdit = false;

            // フォーカスを先頭に戻します。
            this.tNdtCstmrCdStart.Focus();
        }

        /// <summary>
        /// コントロール初期化処理
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : TEdit、TNedit、UltraOptionSetの内容を初期化します。</br>
        /// <br>             上記以外のコントロールの場合、配下のコントロールを再帰的に呼び出して</br>
        /// <br>             子コントロールが無くなるまで探します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void InitControl(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TEdit || child is TNedit)
                {
                    // エディット関連のコントロールは、入力内容をクリアします。
                    child.Text = String.Empty;
                }
                else if (child is UltraOptionSet)
                {
                    // ラジオボタンは同値を選択します。
                    UltraOptionSet optSet = child as UltraOptionSet;
                    optSet.FocusedIndex = (int)AllSettingType.Equivalence;
                    optSet.Value = (int)AllSettingType.Equivalence;
                }
                else
                {
                    // それ以外の場合は、再帰的にコントロールを呼び出します。
                    this.InitControl(child);
                }
            }
        }

        /// <summary>
        /// ステータスバー初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ステータスバーを初期状態に戻します。。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void InitStatusBar()
        {
            // ステータスバーからプログレスバーを非表示にします。
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].Visible = false;
            // ステータスバーに表示中のコード変換ステータスを空文字に変更します。
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = String.Empty;
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Black;
        }

        #endregion

        #region -- マスタ関連 --

        /// <summary>
        /// / 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタを読み込み、拠点名称をメモリに保持します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SaveSecInfoToMemory()
        {
            // 拠点マスタから拠点情報を取得します。
            this.secInfoAcs.ResetSectionInfo();
            if (this.secInfoAcs.SecInfoSetList != null && this.secInfoAcs.SecInfoSetList.Length != 0)
            {
                this.secInfoMap = new Dictionary<string, string>(this.secInfoAcs.SecInfoSetList.Length);
            }
            else
            {
                this.secInfoMap = new Dictionary<string, string>();
            }

            // 拠点情報をメモリにキャッシュします。
            foreach (SecInfoSet secInfoSet in this.secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this.secInfoMap[secInfoSet.SectionCode.Trim()] = secInfoSet.SectionGuideNm.Trim();
                }
            }
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードに該当する拠点名を取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GetSecName(string secCd)
        {
            string cd = secCd.Trim().PadLeft(2, '0');
            return this.secInfoMap.ContainsKey(cd) ? this.secInfoMap[cd] : String.Empty;
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタを読み込み、得意先名称をメモリに保持します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SaveCustomerInfoToMemory()
        {
            // ステータスを初期化します。
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {                
                // 得意先マスタからデータを取得します。
                CustomerSearchDispWork dispwk = new CustomerSearchDispWork();
                dispwk.EnterpriseCode = this.enterPriseCd;
                dispwk.CustomerCodeStart = 0;
                dispwk.CustomerCodeEnd = 0;
                List<CustomerDispInfo> customerInfoList = new List<CustomerDispInfo>();
                status = this.customerCnvAcs.SearchCustomer(dispwk, customerInfoList);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.customerInfoMap = new Dictionary<string, string>(customerInfoList.Count);
                    customerInfoList.ForEach(delegate(CustomerDispInfo wk)
                    {
                        this.customerInfoMap[String.Format(PMKHN05121UA.cdFormat, wk.CustomerCode)] = wk.CustomerName;
                    });
                }
                else
                {
                    this.customerInfoMap = new Dictionary<string, string>();
                }
            }
            catch
            {
                this.customerInfoMap = new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// 得意先名取得処理
        /// </summary>
        /// <param name="employeeCode">得意先コード</param>
        /// <returns>得意先名</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードに該当する得意先名を取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string GetCustomerName(string customerCode)
        {
            // 得意先コードが無い場合は、空文字を返却します。
            if (String.IsNullOrEmpty(customerCode))
            {
                return String.Empty;
            }

            // 得意先コードが入力されている場合で、該当するコードがある場合は紐付く得意先名を
            // 該当するコードが無い場合は、未登録を呼び出し元に返却します。
            string cd = customerCode.Trim().PadLeft(this.codeLength, '0');
            return this.customerInfoMap.ContainsKey(cd) ? this.customerInfoMap[cd] : this.noCustomerName;
        }

        #endregion

        #region -- グリッド関連のメソッド --

        /// <summary>
        /// グリッドコントロール初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドコントロールの初期設定を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitGrid()
        {
            // テーブルを作成し、グリッドにバインドします。
            this.ultrGrid.DataSource = new DataView(this.CreateDataTable());
            // 外観、各種設定を初期化します。
            this.InitGridLayout();
            // カラムの初期化
            this.InitGridColumns();
            // グリッドキーマッピング設定処理(↑←↓→、Shift + Enter等フォーカス遷移)
            this.MakeKeyMappingForGrid(this.ultrGrid);
        }

        /// <summary>
        /// グリッド外観初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの外観の初期設定を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23/br>
        /// </remarks>
        private void InitGridLayout()
        {
            #region -- 外観設定 --

            // グリッド全体の外観設定
            this.ultrGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.ultrGrid.DisplayLayout.Appearance.BackColor = Color.White;
            this.ultrGrid.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.ultrGrid.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // アクティブ行の外観設定
            this.ultrGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            this.ultrGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            this.ultrGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // タイトルの外観設定
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.ultrGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // 行セレクタの外観設定
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultrGrid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

            // アクティブセルの外観設定
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.White;
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor2 = Color.FromArgb(251, 230, 148);
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor = Color.Black;

            #endregion

            #region -- その他設定 --
            // 行複数選択設定
            this.ultrGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 行のサイズ変更設定
            this.ultrGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 列の複数選択設定
            this.ultrGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            // 行の追加設定
            this.ultrGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行の削除設定
            this.ultrGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // 列の移動設定
            this.ultrGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更設定
            this.ultrGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            // 列の交換設定
            this.ultrGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの利用可否の設定
            this.ultrGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // IMEの設定
            this.ultrGrid.ImeMode = ImeMode.Disable;
            // HeaderSortの設定
            this.ultrGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // 互い違いの行の背景色の設定
            this.ultrGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタの表示設定
            this.ultrGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            // クリック時のセルの選択範囲の設定
            this.ultrGrid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            // スクロールバーの表示設定
            this.ultrGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Automatic;
            this.ultrGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToLastItem;
            // 文字位置(縦)の設定
            this.ultrGrid.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultrGrid.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultrGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 行間の罫線色の設定
            this.ultrGrid.DisplayLayout.Override.RowAlternateAppearance.BorderColor = Color.FromArgb(1, 68, 208);
            // 編集中の色の設定
            this.ultrGrid.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            // マウスポインタのカーソル形状の設定
            this.ultrGrid.Cursor = Cursors.Arrow;
            #endregion

            #region -- グループヘッダの設定 --

            // ヘッダのグループ化設定
            this.ultrGrid.DisplayLayout.Bands[0].Groups.Add(this.hdrGrpKeyNo, String.Empty);
            this.ultrGrid.DisplayLayout.Bands[0].Groups.Add(this.hdrGrpKeyBefore, "変更前");
            this.ultrGrid.DisplayLayout.Bands[0].Groups.Add(this.hdrGrpKeyAfter, "変更後");
            // グループの列移動の設定
            this.ultrGrid.DisplayLayout.Override.AllowGroupMoving = AllowGroupMoving.NotAllowed;

            #endregion
        }

        /// <summary>
        /// グリッドカラム初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドカラムの初期設定を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitGridColumns()
        {
            ColumnsCollection columns = this.ultrGrid.DisplayLayout.Bands[0].Columns;
            // No.列
            UltraGridColumn column = columns[GridSettingInfo.COL_NO];
            this.SetColInfo(column, GridSettingInfo.COL_NO_WIDTH, GridSettingInfo.COL_NO_CAP,
                this.hdrGrpKeyNo, Infragistics.Win.HAlign.Right, false, null);
            // 列の固定化
            column.Header.Fixed = true;
            column.Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            column.CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            column.CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            column.CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            column.CellAppearance.ForeColor = Color.White;
            column.CellAppearance.ForeColorDisabled = Color.White;
            
            // 論理削除列
            column = columns[GridSettingInfo.COL_LDEL];
            this.SetColInfo(column, 0, GridSettingInfo.COL_LDEL_NM, this.hdrGrpKeyNo,
                Infragistics.Win.HAlign.Right, false, null);
            // 論理削除列は非表示にします
            column.Hidden = true;

            // 変更前得意先コード
            column = columns[GridSettingInfo.COL_BF_CD];
            this.SetColInfo(column, GridSettingInfo.COL_BF_CD_WIDTH, GridSettingInfo.COL_CD_CAP,
                this.hdrGrpKeyBefore, Infragistics.Win.HAlign.Right, false, "00000000");

            // 変更前得意先名称
            column = columns[GridSettingInfo.COL_BF_NM];
            this.SetColInfo(column, GridSettingInfo.COL_BF_NM_WIDTH, GridSettingInfo.COL_NM_CAP,
                this.hdrGrpKeyBefore, Infragistics.Win.HAlign.Left, false, null);

            // 変更後得意先コード
            column = columns[GridSettingInfo.COL_AF_CD];
            this.SetColInfo(column, GridSettingInfo.COL_AF_CD_WIDTH, GridSettingInfo.COL_CD_CAP,
                this.hdrGrpKeyAfter, Infragistics.Win.HAlign.Right, true, "00000000;0000000; ");
            column.NullText = String.Empty;
            column.MaxLength = 8;

            // 変更後得意先名称
            column = columns[GridSettingInfo.COL_AF_NM];
            this.SetColInfo(column, GridSettingInfo.COL_AF_NM_WIDTH, GridSettingInfo.COL_NM_CAP,
                this.hdrGrpKeyAfter, Infragistics.Win.HAlign.Left, false, null);
        }

        /// <summary>
        /// 列初期化処理
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="width">列幅</param>
        /// <param name="caption">列見出し</param>
        /// <param name="blngGrp">所属するグループ(変更前/変更後)</param>
        /// <param name="hAlign">テキストの水平位置</param>
        /// <param name="isAllowEdit">編集の可否(true:可/false:不可)</param>
        /// <param name="format">入力値の書式(コードのみ指定します)</param>        
        /// <remarks>
        /// <br>Note       : 列の初期設定を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetColInfo(UltraGridColumn col, int width, string caption,
            string blnGrp, Infragistics.Win.HAlign hAlign, Boolean isAllowEdit, string format)
        {
            // 列幅の設定
            col.Width = width;
            // 列見出しの設定
            col.Header.Caption = caption;
            // テキストの水平/垂直方向の設定
            col.CellAppearance.TextHAlign = hAlign;
            col.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 行フィルタの設定
            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 入力値の書式
            if (!String.IsNullOrEmpty(format))
            {
                col.Format = format;
            }
            // セルの編集可否と文字色の設定
            if (!isAllowEdit)
            {
                // セルの編集を許可しない場合は、セルの選択不可と選択不可時の文字色を変更します。
                col.CellActivation = Activation.Disabled;
                // 文字色の設定
                col.CellAppearance.ForeColorDisabled = Color.Black;
            }
            // SortIndicatorの設定
            col.SortIndicator = SortIndicator.Disabled;
            // グループの設定
            this.ultrGrid.DisplayLayout.Bands[0].Groups[blnGrp].Columns.Add(col);
        }

        /// <summary>
        /// データテーブル作成処理
        /// </summary>
        /// <remarks>
        /// <returns>テーブルオブジェクト</returns>
        /// <br>Note       : データテーブルの作成を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable(GridSettingInfo.TBL_NAME);
            // No.列
            table.Columns.Add(GridSettingInfo.COL_NO, typeof(int));
            // 論理削除列
            table.Columns.Add(GridSettingInfo.COL_LDEL, typeof(LogicalDeleteType));
            // 変換前得意先コード列
            table.Columns.Add(GridSettingInfo.COL_BF_CD, typeof(int));
            // 変換前得意先名称列
            table.Columns.Add(GridSettingInfo.COL_BF_NM, typeof(string));
            // 変換後得意先コード列
            table.Columns.Add(GridSettingInfo.COL_AF_CD, typeof(int));
            // 変換後得意先名称列
            table.Columns.Add(GridSettingInfo.COL_AF_NM, typeof(string));

            return table;
        }

        /// <summary>
        /// グリッド表示情報セット処理
        /// </summary>
        /// <param name="employeeList">担当者情報一覧</param>
        /// <returns>テーブルオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : グリッドに表示するデータをセットします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetDataToGrid(List<CustomerDispInfo> customerList)
        {
            // データテーブルにデータをセットします。
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            // 行データ
            DataRow row = null;
            int no = 1;
            customerList.ForEach(delegate(CustomerDispInfo wk) {
                // 行の追加
                row = table.NewRow();
                // No.列
                row[GridSettingInfo.COL_NO] = no++;
                // 論理削除列
                LogicalDeleteType delType = (LogicalDeleteType)Enum.ToObject(typeof(LogicalDeleteType), wk.LogicalDelete);
                row[GridSettingInfo.COL_LDEL] = delType;
                // 変換前の得意先コード
                row[GridSettingInfo.COL_BF_CD] = String.Format(PMKHN05121UA.cdFormat, wk.CustomerCode);
                // 変換前の得意先名称
                row[GridSettingInfo.COL_BF_NM] = wk.CustomerName;
                table.Rows.Add(row);
                // 論理削除済みであれば、文字色を赤に変更
                if (delType == LogicalDeleteType.Logical)
                {
                    this.ultrGrid.Rows[no - 2].CellAppearance.ForeColor = Color.Red;
                    this.ultrGrid.Rows[no - 2].CellAppearance.ForeColorDisabled = Color.Red;
                    this.ultrGrid.Rows[no - 2].Cells[GridSettingInfo.COL_NO].Appearance.ForeColorDisabled = Color.White;
                    this.ultrGrid.Rows[no - 2].ToolTipText = MessageMng.INFO_MES_007;
                }
                else
                {
                    this.ultrGrid.Rows[no - 2].CellAppearance.ForeColor = Color.Black;
                    this.ultrGrid.Rows[no - 2].Appearance.ForeColorDisabled = Color.Black;
                    this.ultrGrid.Rows[no - 2].ToolTipText = String.Empty;
                }
            });
        }

        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        /// <remarks>
        /// <br>Note       : ボタンの初期設定をします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.ultrGrid.KeyActionMappings.Add(enterMap);
        }

        #endregion

        #region -- メッセージダイアログ表示関連 --

        /// <summary>
        /// エラーメッセージダイアログ表示処理
        /// </summary>
        /// <param name="mes">表示するエラーメッセージ</param>
        /// <param name="status">ステータス</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>Note       : 画面にエラーメッセージを表示します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowError(string mes, int status)
        {
            // エラーメッセージを表示します
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_STOP, MessageBoxButtons.OK, mes, status);
        }

        /// <summary>
        /// 警告メッセージダイアログ表示処理
        /// </summary>
        /// <param name="mes">表示するエラーメッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>Note       : 画面に警告メッセージを表示します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowExclamation(string mes)
        {
            // 警告？
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_EXCLAMATION, MessageBoxButtons.OK, mes, 0);
        }

        /// <summary>
        /// インフォメッセージダイアログ表示処理
        /// </summary>
        /// <param name="mes">表示するインフォメッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>Note       : 画面にインフォメッセージを表示します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowInfo(string mes)
        {
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_INFO, MessageBoxButtons.OKCancel, mes, 0);
        }

        /// <summary>
        /// メッセージダイアログ表示処理
        /// </summary>
        /// <param name="errLevel">表示するアイコン</param>
        /// <param name="btn">表示するボタン種別</param>        
        /// <param name="mes">表示するメッセージ</param>
        /// <param name="status">ステータス</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>Note       : 画面にインフォメッセージを表示します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private DialogResult ShowMessage(emErrorLevel errLevel, MessageBoxButtons btn, string mes, int status)
        {
            return TMsgDisp.Show(errLevel, this.pgId, mes, status, btn);
        }

        #endregion

        #region -- 検索処理関連 --

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に検索を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void Search()
        {
            try
            {
                // 抽出条件に不正な値が入力されていないかチェックします。
                if (!this.IsAllowSearchCondition())
                {
                    return;
                }

                // ステータスバーを初期状態にします。
                this.InitStatusBar();

                // プログレスダイアログを表示します。
                this.ShowProgressDlg(MessageMng.INFO_MES_010, MessageMng.INFO_MES_011, true);

                // 抽出条件を元にDBからデータを取得します。
                List<CustomerDispInfo> searchResult = new List<CustomerDispInfo>();
                // 処理ステータスが成功、且つ検索結果が0件ではないときは取得結果を
                // グリッドに表示します。
                int status = this.customerCnvAcs.SearchCustomer(this.SetSearchCondition(), searchResult);
                this.SetDataToGrid(searchResult);

                // 更新済みフラグと編集済みフラグをoffにします。
                this.isUpdate = false;
                this.isEdit = false;

                // プログレスダイアログを閉じます。
                this.procDlg.Close();

                // 検索結果が無い場合は、メッセージを表示します。
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    this.ShowInfo(MessageMng.INFO_MES_013);
                }
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.ShowError(MessageMng.ERR_MES_011, status);
                }
            }
            catch (Exception ex)
            {
                // プログレスダイアログを終了後にエラーダイアログを表示します。
                this.procDlg.Close();
                this.ShowError(String.Format(MessageMng.ERR_MES_004, ex.Message),
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
        }

        /// <summary>
        /// 抽出条件セット処理
        /// </summary>
        /// <returns>抽出条件</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件をセットします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerSearchDispWork SetSearchCondition()
        {
            CustomerSearchDispWork dispWork = new CustomerSearchDispWork();
            // 企業コード
            dispWork.EnterpriseCode = this.enterPriseCd;
            // 得意先コード(開始)
            dispWork.CustomerCodeStart = Convert.ToInt32(this.tNdtCstmrCdStart.Value);
            // 得意先コード(終了)
            dispWork.CustomerCodeEnd = Convert.ToInt32(this.tNdtCstmrCdEnd.Value);

            return dispWork;
        }

        #endregion

        #region -- チェック処理関連 --

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns>判定結果(true:OK/false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件として指定した値が正しい値であるかをチェックします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool IsAllowSearchCondition()
        {
            // 入力された値が数値であるかをチェックします。
            if (this.IsNotNumber(this.tNdtCstmrCdStart) || this.IsNotNumber(this.tNdtCstmrCdEnd))
            {
                return false;
            }            

            // 抽出条件で開始と終了の値が逆転していないかをチェックします。
            if ((this.tNdtCstmrCdStart.GetInt() != 0 && this.tNdtCstmrCdEnd.GetInt() != 0)
                && (this.tNdtCstmrCdStart.GetInt() > this.tNdtCstmrCdEnd.GetInt()))
            {
                this.ShowExclamation(MessageMng.ERR_MES_010);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数値チェック処理
        /// </summary>
        /// <param name="tNEdit"></param>
        /// <returns>判定結果(true:非数値/false:数値)</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件指定した値が非数値であるかをチェックします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool IsNotNumber(TNedit tNEdit)
        {
            // 入力値がある場合のみチェックします。
            if (tNEdit.GetInt() == 0 && tNEdit.Text.Length != 0 && 
                !Regex.IsMatch(tNEdit.Text, this.regPttrnNum))
            {
                tNEdit.Focus();
                this.ShowExclamation(MessageMng.ERR_MES_016);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 変更後倉庫コード判定処理(0チェック)
        /// </summary>
        /// <param name="cell">セルデータ</param>
        /// <returns>true:0/false:非0</returns>
        /// <remarks>
        /// <br>Note       : 変換後の値が0であるか否かを判定します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10<</br>
        /// </remarks>
        private bool IsCodeZero(UltraGridCell cell)
        {
            return Convert.ToInt32(cell.Text.Trim()) == 0 ? true : false;
        }

        /// <summary>
        /// 変更前、変更後倉庫コード判定処理(同一値チェック)
        /// </summary>
        /// <param name="row">行データ</param>
        /// <returns>true:同一値/false:非同一値</returns>
        /// <remarks>
        /// <br>Note       : 変更前と変更後のコードが同一であるかどうかをチェックします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private bool IsBfCdAndAfCdSameValue(UltraGridRow row)
        {
            return Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value) ==
                Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) ? true : false;
        }

        #endregion

        #region -- コード変換関連 --

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ConvertCustomerCode()
        {
            try
            {
                // 既にコンバート済みかをチェックする
                if (this.isUpdate)
                {
                    this.ShowExclamation(MessageMng.INFO_MES_006);
                    return;
                }

                // コンバート処理を実行する前にコンバート処理を置こうなうか否かをユーザに
                // 問い合わせます。
                if (this.ShowInfo(MessageMng.INFO_MES_004) == DialogResult.Cancel)
                {
                    return;
                }

                // コンバート対象データが有るかどうかをチェックします。
                if (!this.HasConvertData())
                {
                    this.ShowExclamation(MessageMng.ERR_MES_009);
                    return;
                }

                // ログの保存先ディレクトリを作成します。
                this.CreateLogSaveDir();

                // 入力値チェック
                this.isCheckOK = this.IsAllowData();
                if (this.isCheckOK)
                {
                    // プログレスダイアログを表示します。
                    this.ShowProgressDlg(MessageMng.INFO_MES_008, MessageMng.INFO_MES_009, false);
                    // コード変換処理をバックグラウンドで実行します。
                    this.bgWrkr.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(String.Format(MessageMng.ERR_MES_005, ex.Message), 
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
        }

        /// <summary>
        /// コンバート対象コード存在チェック処理
        /// </summary>
        /// <returns>true:対象コード有/false:対象コード無し</returns>
        /// <remarks>
        /// <br>Note       : グリッド内にコンバート対象となる倉庫コードが存在するかチェックします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool HasConvertData()
        {
            // グリッドにコンバート対象となるデータが存在するか確認します。
            if (this.ultrGrid.Rows.Count != 0)
            {
                // グリッドにデータが有る場合、変換後の得意先コード列に入力値があるかどうかを確認します。
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    // 空ではないセル、又は変更前と変更後が一致しないセルを発見したら処理を抜けます。
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()) &&
                        !this.IsCodeZero(row.Cells[GridSettingInfo.COL_AF_CD]) && !this.IsBfCdAndAfCdSameValue(row))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 入力値チェック処理
        /// </summary>
        /// <returns>判定結果(true:OK/false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定したコード変換の入力値チェックを行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private bool IsAllowData()
        {
            // チェック済みのコードを保存する変数
            IDictionary<string, CustomerInputData> checkCodeMap = new Dictionary<string, CustomerInputData>();

            // 入力した変換後コードが4桁以内、又は入力した値内で重複した値が無いかチェックします。
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // セルからコードを取得します。
                string code = String.Format(PMKHN05121UA.cdFormat, row.Cells[GridSettingInfo.COL_AF_CD].Value);
                // 桁数チェック
                if (code.Length > this.codeLength)
                {
                    this.SetFocusToErrorCell(row, String.Format(MessageMng.ERR_MES_007, this.codeLength));
                    return false;
                }

                // 変更後得意先コードが未入力の場合、変更前の得意先コードが重複しないかチェックします。
                if (String.IsNullOrEmpty(code) || Convert.ToInt32(row.Cells[GridSettingInfo.COL_AF_CD].Value) == 0)
                {
                    code = String.Format(PMKHN05121UA.cdFormat, Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value));
                }

                // 重複チェック
                if (checkCodeMap.ContainsKey(code))
                {
                    // 重複していた場合は、メッセージを表示して処理を中止
                    this.SetFocusToErrorCell(row, MessageMng.ERR_MES_008);
                    return false;
                }
                else
                {
                    // チェック済みのコードを保存します
                    CustomerInputData inputData = new CustomerInputData();
                    inputData.BfCustomerCode = String.Format(PMKHN05121UA.cdFormat, Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value));
                    inputData.AfCustomerCode = code;
                    inputData.RowIndex = row.Index;
                    checkCodeMap[code] = inputData;

                    // チェック済みコードマップに変換前のコードがあるかを判定します。
                    if (inputData.IsEdit() && checkCodeMap.ContainsKey(inputData.BfCustomerCode))
                    {
                        // チェック済みコードマップに変換前コードがあった場合は、チェック済みコードとの
                        // 交換である為、コードの変換があったことを示すフラグをonにします。
                        checkCodeMap[inputData.BfCustomerCode].SetOtherCodeChange(inputData.BfCustomerCode, inputData.AfCustomerCode);
                        checkCodeMap[code].SetOtherCodeChange(checkCodeMap[inputData.BfCustomerCode].BfCustomerCode,
                            checkCodeMap[inputData.BfCustomerCode].AfCustomerCode);
                    }
                }
            }

            // グリッドの情報が得意先マスタのデータ件数と一致しない場合は、抽出条件で表示件数が
            // 絞られている為、表示されていないコードについても重複しないか判定します。
            // また、一度更新した場合も同様にチェックします。
            if ((this.isUpdate) || (this.ultrGrid.Rows.Count != this.customerInfoMap.Count))
            {
                foreach (string checkedCode in checkCodeMap.Keys)
                {
                    int index = checkCodeMap[checkedCode].RowIndex;
                    if (checkCodeMap[checkedCode].IsEdit() && !checkCodeMap[checkedCode].IsOtherCodeChange
                        && this.customerInfoMap.ContainsKey(checkedCode))
                    {
                        this.SetFocusToErrorCell(this.ultrGrid.Rows[index], MessageMng.ERR_MES_008);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ログ保存先ディレクトリ作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログを保存するディレクトリが存在しない場合、ディレクトリの作成を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void CreateLogSaveDir()
        {
            // ログ保存ディレクトリが存在するかを確認し、無い場合はディレクトリを作成します。
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05121UA.LOG_DIR_PATH);
            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(dirInfo.FullName);
            }
        }

        #endregion

        #region -- スレッド関連 --

        /// <summary>
        /// ステータスバー初期化処理
        /// </summary>
        /// <param name="cnvTrgTblCount">コード変換対象テーブルの件数</param>
        /// <remarks>
        /// <br>Note       : コンバート処理実行直前時にステータスバーの初期化を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void InitStatusBar(int cnvTrgTblCount)
        {
            // 画面の描画を一時停止します。
            this.SuspendLayout();

            // プログレスバーを初期化します。
            UltraStatusPanel pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS];
            // プログレスバーを表示します。
            pnl.Visible = true;
            // プログレスバーの最小値と最大値を設定します。
            pnl.ProgressBarInfo.Minimum = 0;
            pnl.ProgressBarInfo.Maximum = cnvTrgTblCount;
            pnl.ProgressBarInfo.Value = 0;
            pnl.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;

            // ステータス表示領域を初期化します。
            pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS];
            pnl.Text = MessageMng.INFO_MES_001;
            pnl.Appearance.ForeColor = Color.Black;

            // 画面の描画を再開します。
            this.ResumeLayout(false);
        }

        /// <summary>
        /// ステータスバー更新処理
        /// </summary>
        /// <param name="mes">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーを更新するためのデリゲート。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void UpdateStatusBar(string mes)
        {
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = mes;
        }

        /// <summary>
        /// コード変換対象データ取得処理
        /// </summary>
        /// <returns>コード変換対象のデータリスト</returns>
        /// <remarks>
        /// <br>Note       : コード変換他の対象となっているデータをグリッドから取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private IList<CustomerConvertData> GetConvertData()
        {
            // コード変換対象のデータをグリッドから取得します。
            IList<CustomerConvertData> cnvDataList = new List<CustomerConvertData>(this.ultrGrid.Rows.Count);
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // 変更後得意先コード列から値を取得し、値が無い場合は次の行へ
                UltraGridCell afCell = row.Cells[GridSettingInfo.COL_AF_CD];
                if (String.IsNullOrEmpty(afCell.Text.Trim()) || 
                    this.IsCodeZero(afCell) || this.IsBfCdAndAfCdSameValue(row))
                {
                    continue;
                }

                // 更新条件を保存します。
                CustomerConvertData cnvData = new CustomerConvertData();
                // 変更前得意先コード
                cnvData.BfCustomerCd = Convert.ToInt32(row.Cells[GridSettingInfo.COL_BF_CD].Value);
                // 変更後得意先コード
                cnvData.AfCustomerCd = Convert.ToInt32(afCell.Value);
                cnvDataList.Add(cnvData);
            }

            return cnvDataList;
        }

        #region -- ログ関連 --

        /// <summary>
        /// ログファイルパス作成処理
        /// </summary>
        /// <returns>ログファイルの絶対パス</returns>
        /// <remarks>
        /// <br>Note       : ログファイルの絶対パスを作成します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string CreateLogFilePath()
        {
            // ディレクトリ情報を作成
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05121UA.LOG_DIR_PATH);
            // ログファイル名を作成
            string fileName = String.Format(PMKHN05121UA.LOG_FILE_NAME, 
                DateTime.Now.ToString(PMKHN05121UA.LOG_FORMAT_DATE));

            return Path.Combine(dirInfo.FullName, fileName);
        }

        /// <summary>
        /// ログ出力形式生成処理
        /// </summary>
        /// <param name="format">ログに出力するフォーマット</param>
        /// <param name="prms">出力したい内容</param>
        /// <returns>ログのフォーマットに成形した文字列</returns>
        /// <remarks>
        /// <br>Note       : 引数で指定されたデータをログの出力形式に変換します。</br>
        /// <br>             ログフォーマットの第1引数は日付になっていますが、日付は本メソッド内で</br>
        /// <br>             取得する為、prmsに日付を指定する必要はありません。</br>
        /// <br>             また、ログフォーマットに第2引数以降が無い場合は、new String[0]を</br>
        /// <br>             prmsの引数に指定してください。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private string GenerateLogFormat(string format, string[] prms)
        {
            List<string> prmList = new List<string>();
            prmList.Add(DateTime.Now.ToString(PMKHN05121UA.DATE_FORMAT));
            foreach (string prm in prms)
            {
                prmList.Add(prm);
            }

            return String.Format(format, prmList.ToArray());
        }

        #endregion

        #endregion

        #region -- その他 --

        /// <summary>
        /// プログレスダイアログ表示処理
        /// </summary>
        /// <param name="mess">メッセージ</param>
        /// <param name="title">ダイアログタイトル</param>
        /// <param name="canCancel">キャンセルの可否(true:キャンセル可能/false:キャンセル不可)</param>
        /// <remarks>
        /// <br>Note       : プログレスダイアログを表示します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void ShowProgressDlg(string title, string mess, bool canCancel)
        {
            // プログレスダイアログを表示します
            if (this.procDlg == null)
            {
                this.procDlg = new SFCMN00299CA();
            }

            // ダイアログのタイトルを設定します。
            this.procDlg.Title = title;
            // ダイアログに表示するメッセージを設定します。
            this.procDlg.Message = mess;
            // キャンセルボタンの有無
            this.procDlg.DispCancelButton = canCancel;

            // プログレスダイアログを表示します。
            this.procDlg.Show(this);
        }

        /// <summary>
        /// コードゼロ埋め処理
        /// </summary>
        /// <param name="trgVal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : コードを「0001」のようにゼロ埋めします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private string ZeroPadding(string trgVal) 
        {
            return String.IsNullOrEmpty(trgVal) ? String.Empty :
                trgVal.Trim().PadLeft(this.codeLength, '0');
        }

        /// <summary>
        /// 名称セット処理
        /// </summary>
        /// <param name="tNEdit">コード入力欄</param>
        /// <param name="tEdit">名称欄</param>
        /// <remarks>
        /// <br>Note       : コード入力欄で入力したコードに対応する名称を名称欄にセットします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void SetName(TNedit tNEdit, TEdit tEdit)
        {
            string customerCd = tNEdit.Text.Trim();
            string customerNm = this.GetCustomerName(customerCd);
            tEdit.Text = customerNm == this.noCustomerName ? String.Empty : customerNm;
            if (!String.IsNullOrEmpty(customerCd))
            {
                tNEdit.Text = tNEdit.Text.Trim().PadLeft(this.codeLength, '0');
            }
        }

        #region -- フォーカスセット関連 --

        /// <summary>
        /// エラーセルフォーカスセット処理
        /// </summary>
        /// <param name="row">行データ</param>
        /// <param name="errMes">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 入力チェックでエラーが発生したセルにフォーカスをセットします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetFocusToErrorCell(UltraGridRow row, string errMs)
        {
            this.ultrGrid.Focus();
            row.Cells[GridSettingInfo.COL_AF_CD].Activate();
            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            this.ShowExclamation(errMs);
        }

        /// <summary>
        /// フォーカス遷移時のアクティブセルフォーカスセット処理
        /// </summary>
        /// <param name="rowIndex">アクティブにしたい行番号</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーカス遷移時でグリッドがアクティブコントロールになった場合、指定した行番号の</br>
        /// <br>             変更後コード列のセルをアクティブにします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void SetFocusEditCellFromNoUltraGrid(int rowIndex, ChangeFocusEventArgs e)
        {
            // 次のコントロールがUltraGridの時のみ実施します。
            if (e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
            {
                e.NextCtrl = null;
                // UltraGridにフォーカスを当て、rowIndexで指定した変更後セルをアクティブにします。
                this.ultrGrid.Focus();
                this.ultrGrid.Rows[rowIndex].Cells[GridSettingInfo.COL_AF_CD].Activate();
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// グリッド内のフォーカス遷移時のアクティブセルフォーカスセット処理
        /// </summary>
        /// <param name="cmpRowIndex">比較したい行の行番号(先頭の場合は0、末尾の場合は行数-1)</param>
        /// <param name="nextCtrl">次に遷移するコントロール(倉庫ガイドor一括設定ボタン)</param>
        /// <param name="gridAction">グリッドで実行したいアクション</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド内のフォーカス遷移時に次のセルをアクティブにします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetFocusEditCellInUltraGrid(int cmpRowIndex, Control nextCtrl,
            UltraGridAction gridAction, ChangeFocusEventArgs e)
        {
            // NextCtrlにnullをセットします。
            e.NextCtrl = null;
            if (this.ultrGrid.ActiveCell.Row.Index == cmpRowIndex)
            {
                // NextCtrlに次に移動したいコントロールをセットします。
                e.NextCtrl = nextCtrl;
            }
            else
            {
                // 次のセルに移動します。
                this.ultrGrid.PerformAction(gridAction);
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// グリッド内のフォーカス遷移時のアクティブセルフォーカスセット処理
        /// </summary>
        /// <param name="cmpRowIndex">比較したい行の行番号(先頭の場合は0、末尾の場合は行数-1)</param>
        /// <param name="nextCtrl">次に遷移するコントロール</param>
        /// <param name="gridAction">グリッドで実行したいアクション</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド内のフォーカス遷移時に次のセル、又はコントロールをアクティブにします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void SetFocusEditCellOnKeyDown(int cmpRowIndex, Control nextCtrl,
            UltraGridAction gridAction, KeyEventArgs e)
        {
            if (this.ultrGrid.ActiveCell.Row.Index == cmpRowIndex)
            {
                // 次のコントロールにフォーカスをセットします。
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                }
            }
            else
            {
                // 次のセルをアクティブセルにします。
                this.ultrGrid.PerformAction(gridAction);
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }

            e.Handled = true;
        }

        #endregion

        #endregion

        #endregion

        #region -- Event --

        #region -- UltraExpandableGroupBox関連のイベント --

        /// <summary>
        /// 抽出条件コントロールの展開・縮小イベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : コントロールの展開・縮小したときにコントロールのサイズを変更します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrEgbCllctvSttng_ExpandedStateChanged(object sender, EventArgs e)
        {
            // イベントソースをUltraExpandableGroupBoxに変換します。
            UltraExpandableGroupBox edgGrpBox = sender as UltraExpandableGroupBox;
            // UltraExpandableGroupBoxの時のみ処理を実施します。
            if (edgGrpBox != null)
            {
                // 展開・縮小に応じてパネルのサイズを変更します。
                Size pnlSize = new Size();
                pnlSize.Width = edgGrpBox.Parent.Size.Width;
                pnlSize.Height = edgGrpBox.Expanded ? 
                    (this.egbGrpBoxHeighMap[(EgbGrpBoxType)edgGrpBox.Tag]) : this.egbGrpBoxCntrctSize;
                edgGrpBox.Parent.Size = pnlSize;
            }
        }

        #endregion

        #region -- スレッド関連 --

        /// <summary>
        /// バックグランドのイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : バックグラウンドで処理を実行するときにイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void bgWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // XMLからコード変換の対象となるテーブルを取得します。
                IDictionary<string, TargetTableListResult> trgTblMap = new Dictionary<string, TargetTableListResult>();
                status = this.customerCnvAcs.GetConvertTableList(trgTblMap);
                // 正常以外の場合は対象データを格納したXMLが不正である為、処理を中止します。
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (status)
                    {
                        case PMKHN05121UA.ILLEGAL_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_014;
                            break;
                        case PMKHN05121UA.NO_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_013;
                            break;
                        case PMKHN05121UA.NO_FILE:
                            this.cnvErrMes = MessageMng.ERR_MES_015;
                            break;
                        default:
                            this.cnvErrMes = String.Empty;
                            break;
                    }
                    e.Cancel = true;
                    return;
                }

                // コード変換対象のデータをグリッドから取得します。
                IList<CustomerConvertData> cnvDataList = this.GetConvertData();

                // ステータスバーを初期化します。
                this.Invoke(new InitStatusBarDelegate(this.InitStatusBar), trgTblMap.Count);

                // テーブル単位でコード変換を実施します。
                // ステータスバーのステータス領域の処理件数を表示するためのカウンタ
                int index = 0;
                // 1テーブル内のコード変換を行ったレコード件数
                int prcssngCnt;
                // コード変換を行ったレコードの総件数(全テーブル分)
                int ttlPrcssngCnt = 0;
                // コンバート対象のテーブル件数
                int maxTbl = trgTblMap.Count;
                // 処理時間や処理したレコードの件数を記録する為、処理した内容をログに出力します。
                using (FileStream fs = new FileStream(this.CreateLogFilePath(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //操作履歴ログに同様の内容を出力していきます。
                        OperationHistoryLog opLog = new OperationHistoryLog();
                        string pgid = "PMKHN05120U";
                        string pgnm = "取引先コード変換";

                        // 総処理時間を計測するStopwatch
                        Stopwatch totalProcessingTime = new Stopwatch();
                        // 個別のテーブルの処理時間を計測するStopwatch
                        Stopwatch processingTime = new Stopwatch();

                        sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_START, new string[0]));
                        opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                            this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_START, new string[0]), "");

                        // 総処理時間の計測を開始します。
                        totalProcessingTime.Start();
                        foreach (string table in trgTblMap.Keys)
                        {
                            prcssngCnt = 0;
                            // コード変換前にステータスバーを更新します。
                            this.Invoke(new UpdateStatusBarDelegate(this.UpdateStatusBar),
                                String.Format(MessageMng.INFO_MES_005, trgTblMap[table].TargetTableName, index, maxTbl));
                            // 個別テーブルの処理時間を計測します。
                            processingTime.Start();

                            // コード変換処理を実行します。
                            status = this.customerCnvAcs.ConvertCustomer(trgTblMap[table], cnvDataList, this.enterPriseCd, ref prcssngCnt);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_ERROR, new string[] { trgTblMap[table].TargetTableName }));
                                opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                    this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_ERROR, new string[] { trgTblMap[table].TargetTableName }), "");
                                e.Cancel = true;
                                break;
                            }

                            processingTime.Stop();
                            ttlPrcssngCnt += prcssngCnt;
                            // 個々の処理件数、及び処理時間をログに出力します。
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] {trgTblMap[table].TargetTableName, prcssngCnt.ToString(),
                                    new DateTime(0).Add(processingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME) }));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] {trgTblMap[table].TargetTableName, prcssngCnt.ToString(),
                                    new DateTime(0).Add(processingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME) }), "");

                            // 変換処理後にステータスバーを更新します。
                            this.bgWrkr.ReportProgress(++index,
                                String.Format(MessageMng.INFO_MES_005, trgTblMap[table].TargetTableName, index, maxTbl));

                            // 個別テーブルの処理時間を計測するStopwatchをリセットします。
                            processingTime.Reset();
                        }
                        totalProcessingTime.Stop();
                        // 総処理件数と総処理時間をログに出力します。
                        if (!e.Cancel)
                        {
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME),
                                ttlPrcssngCnt.ToString() }));
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_END, new string[0]));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, 
                                this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05121UA.LOG_FORMAT_PROCESSING_TIME),
                                ttlPrcssngCnt.ToString() }), "");
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05121UA.LOG_FORMAT_END, new string[0]), "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーの場合は、例外メッセージをフィールド変数に保存し、イベントをキャンセルします。
                this.cnvErrMes = ex.Message;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ReportProgressイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ReportProgressメソッドをコールした時にイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void bgWrkr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value = e.ProgressPercentage;
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = e.UserState.ToString();
        }

        /// <summary>
        /// バックグラウンド処理終了時のイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : バックグラウンド処理が完了したときにイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>   
        private void bgWrkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 処理成功判定フラグ
            bool isSuccess = false;
            try
            {
                // プログレスダイアログを終了します。
                this.procDlg.Close();
                if (e.Cancelled)
                {
                    // ステータスバーを更新
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_003;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Red;
                    // エラーメッセージを表示
                    string errMs = String.IsNullOrEmpty(this.cnvErrMes) ? MessageMng.ERR_MES_006 : this.cnvErrMes;
                    this.ShowError(errMs, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    this.cnvErrMes = String.Empty;
                }
                else
                {
                    // ステータスバーを更新
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value =
                        this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Maximum;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_002;

                    // 成功時はメモリに格納している重複チェックに用いるマップデータを最新化します。
                    this.SaveCustomerInfoToMemory();

                    // 処理成功判定フラグをonにします。
                    isSuccess = true;

                    // 更新済みフラグをonにします。
                    this.isUpdate = true;
                    // 編集済みフラグをoffにします。
                    this.isEdit = false;
                }
            }
            catch (Exception ex)
            {
                // プログレスダイアログを終了します。
                this.procDlg.Close();
                this.ShowError(String.Format(MessageMng.ERR_MES_005, ex.Message), (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            finally
            {
                // 処理成功時は、登録完了ダイアログを表示します。
                if (isSuccess)
                {
                    // 登録完了ダイアログを表示します。
                    using (SaveCompletionDialog dlg = new SaveCompletionDialog())
                    {
                        dlg.ShowDialog(2);
                    }
                }

                // FormClosingイベントからコールされた場合は、フォームを閉じます。
                if (isSuccess && this.isCallFormCloseingEvent)
                {
                    // 終了時は親フォームから閉じます。
                    ((Form)this.Parent).Close();
                }
            }
        }

        #endregion

        #region -- グリッド関連 --

        /// <summary>
        /// セル編集モード終了前のイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : セル編集モードが終了する前にイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            UltraGrid grid = sender as UltraGrid;
            // セルの状態がnullの場合は、後続の処理を実行しません。
            if (grid.ActiveCell.Value == null) 
            {
                return;
            }

            // 数値が入力された場合は、ゼロパティングします。
            // 非数値の場合は、nullをセットします。
            string inputData = grid.ActiveCell.Text.Trim();
            int str2IntNum;
            if (Int32.TryParse(inputData, out str2IntNum))
            {
                grid.ActiveCell.Value = grid.ActiveCell.Text.PadLeft(this.codeLength, '0');
            }
            else
            {
                grid.ActiveCell.Value = 0;
            }
        }

        /// <summary>
        /// セル新規入力受付後のイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : セルが新規入力を受け付けた後にイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGridRow row = e.Cell.Row as UltraGridRow;
            // 変換後の値が空文字、又は非数値であれば得意先名を空白にします。
            if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_AF_CD].Text.Trim()))
            {
                row.Cells[GridSettingInfo.COL_AF_NM].Value = String.Empty;
            }
            else
            {
                // 入力された場合、該当する得意先名をセットします。存在しない場合は、未登録を表示します。
                row.Cells[GridSettingInfo.COL_AF_NM].Value = this.GetCustomerName(
                    row.Cells[GridSettingInfo.COL_AF_CD].Text);
                // 編集済みフラグをonにします。
                this.isEdit = true;
            }
        }

        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: Gridアクション処理後に発生するイベントです。</br>
        /// <br>Programmer	: 30365 宮津</br>
        /// <br>Date		: 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case UltraGridAction.ActivateCell:
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.PrevCell:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:
                    {
                        // アクティブなセルがあるか？又は編集可能セルか？
                        if ((this.ultrGrid.ActiveCell != null) &&
                            (this.ultrGrid.ActiveCell.Column.CellActivation == Activation.AllowEdit) &&
                            (this.ultrGrid.ActiveCell.Activation == Activation.AllowEdit))
                        {
                            // アクティブセルのスタイルを取得
                            switch (this.ultrGrid.ActiveCell.StyleResolved)
                            {
                                // エディット系スタイル
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                    {
                                        // 編集モードにあるか？
                                        if (this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode))
                                        {
                                            if (!(this.ultrGrid.ActiveCell.Value is DBNull))
                                            {
                                                // 全選択状態にする。
                                                this.ultrGrid.ActiveCell.SelStart = 0;
                                                this.ultrGrid.ActiveCell.SelLength = this.ultrGrid.ActiveCell.Text.Length;
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        // エディット系以外のスタイルであれば、編集状態にする。
                                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                            }
                        }
                    }
                    break;
            }
        }

        #endregion

        #region -- フォーカス制御関連 --

        /// <summary>
        /// フォーカスChangeイベント(tArrwKyCntrl, tRtKyCntrl)
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーカスChangeイベントが発生したときにフォーカスの制御を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10<</br>
        /// </remarks>
        private void tArrwKyCntrl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 直前、直後のコントロールが存在しない場合は、何も処理しません
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.ultrGrid)
            {
                if (this.ultrGrid.ActiveCell != null)
                {
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        if (!e.ShiftKey)
                        {
                            // 次のセルをアクティブセルにします。
                            this.SetFocusEditCellInUltraGrid(this.ultrGrid.Rows.Count - 1,
                                this.tNdtCstmrCdStart, UltraGridAction.NextCell, e);
                        }
                        else
                        {
                            // 前のセルをアクティブセルにします。
                            this.SetFocusEditCellInUltraGrid(this.firstRow, this.ultrBtnSttng,
                                UltraGridAction.PrevCell, e);
                        }
                    }
                }
                else if (this.ultrGrid.ActiveRow != null)
                {
                    // セルがアクティブではない場合
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = null;
                        // 1行目の変換後コードをアクティブにします。
                        this.ultrGrid.ActiveRow.Cells[GridSettingInfo.COL_AF_CD].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                else
                {
                    // 数値項目入力欄であれば、担当者コード(開始)入力欄にフォーカスをセット
                    if (e.NextCtrl is TNedit)
                    {
                        this.tNdtCstmrCdStart.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtCstmrCdStart)
            {
                // 担当者コードを取得し、値がある場合は担当者名をセットします
                this.SetName(this.tNdtCstmrCdStart, this.tEdtCstmrNmStart);

                // フォーカスを制御します
                if (e.ShiftKey && e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
                {
                    e.NextCtrl = null;
                    this.ultrGrid.Focus();
                    this.ultrGrid.Rows[this.ultrGrid.Rows.Count - 1].Cells[GridSettingInfo.COL_AF_CD].Activate();
                    this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (e.ShiftKey && (e.Key == Keys.Return || e.Key == Keys.Tab) &&
                        this.ultrGrid.Rows.Count == 0)
                    {
                        e.NextCtrl = null;
                        this.ultrBtnSttng.Focus();
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        this.ultrRbtnCllctvSttng.FocusedIndex = this.ultrRbtnCllctvSttng.CheckedIndex;
                        this.ultrRbtnCllctvSttng.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtCstmrCdEnd)
            {
                // 担当者コードを取得し、値がある場合は担当者名をセットします
                this.SetName(this.tNdtCstmrCdEnd, this.tEdtCstmrNmEnd);
                if (!e.ShiftKey && (e.Key == Keys.Return || e.Key == Keys.Tab))
                {
                    // ラジオボタンのフォーカスを現在チェックしている項目に変更します。
                    this.ultrRbtnCllctvSttng.FocusedIndex = this.ultrRbtnCllctvSttng.CheckedIndex;
                }
            }
            else if (e.PrevCtrl == this.ultrBtnSttng)
            {
                // グリッドの先頭行をアクティブなセルにします。
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    this.tNdtCstmrCdEnd.Focus();
                }
                else if (this.ultrGrid.Rows.Count != 0)
                {
                    this.SetFocusEditCellFromNoUltraGrid(this.firstRow, e);
                }
                else if (!e.ShiftKey)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        this.tNdtCstmrCdStart.Focus();
                    }
                    else if (e.Key == Keys.Left)
                    {
                        this.tNdtSerNum.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtCstmrCdStart)
            {
                // グリッドの最終行をアクティブなセルにします。
                this.SetFocusEditCellFromNoUltraGrid(this.ultrGrid.Rows.Count - 1, e);
            }
            else if (e.PrevCtrl == this.ultrRbtnCllctvSttng)
            {
                if (!e.ShiftKey)
                {
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tNdtAdd;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        switch (this.ultrRbtnCllctvSttng.FocusedIndex)
                        {
                            case 0:
                            case 1:
                                e.NextCtrl = this.tNdtAdd;
                                break;
                            case 2:
                                e.NextCtrl = this.tNdtMul;
                                break;
                            case 3:
                                e.NextCtrl = this.tNdtSerNum;
                                break;
                            default:
                                // 処理なし
                                break;
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        if (this.ultrGrid.Rows.Count != 0)
                        {
                            this.ultrGrid.Focus();
                            this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_AF_CD].Activate();
                            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtAdd)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.ADD);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Down)
                    {
                        this.tNdtMul.Focus();
                    }
                    else
                    {
                        this.tNdtCstmrCdStart.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtMul)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.Multiplication);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Down)
                    {
                        this.tNdtSerNum.Focus();
                    }
                    else
                    {
                        this.tNdtAdd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtSerNum)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.Sequence);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (e.Key == Keys.Up)
                    {
                        this.tNdtMul.Focus();
                    }
                    else if (this.ultrGrid.Rows.Count != 0)
                    {
                        this.ultrGrid.Focus();
                        this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_AF_CD].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
        }

        /// <summary>
        /// フォームのキーダウン時のイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note	   : フォームのキーダウン時に発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10<</br>
        /// </remarks>
        private void PMKHN05121UA_KeyDown(object sender, KeyEventArgs e)
        {
            // UltraOptionSetにフォーカスが当たっている状況で、
            // 且つカーソルキー(→)が押下された時
            if (this.ultrRbtnCllctvSttng.Focused && (e.KeyCode == Keys.Right))
            {
                switch (this.ultrRbtnCllctvSttng.FocusedIndex)
                {
                    case 0:
                    case 1:
                        this.tNdtAdd.Focus();
                        break;
                    case 2:
                        this.tNdtMul.Focus();
                        break;
                    case 3:
                        this.tNdtSerNum.Focus();
                        break;
                    default:
                        // 処理なし
                        break;
                }
            }
        }

        /// <summary>
        /// グリッドキーダウン時のイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note	   : グリッドおけるキーダウン時に発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrGrid_KeyDown(object sender, KeyEventArgs e)
        {
            // セルがアクティブ状態で、且つ編集モードの時のみ処理を行います。
            if (this.ultrGrid.ActiveCell != null && this.ultrGrid.ActiveCell.IsInEditMode)
            {
                int activeRowIndex = this.ultrGrid.ActiveCell.Row.Index;
                int activeColIndex = this.ultrGrid.ActiveCell.Column.Index;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        // 次のセル、又はコントロールにフォーカスをセットします。
                        this.SetFocusEditCellOnKeyDown(this.firstRow, this.ultrBtnSttng, UltraGridAction.AboveCell, e);
                        break;
                    case Keys.Down:
                        // 前のセル、又はコントロールにフォーカスをセットします。
                        this.SetFocusEditCellOnKeyDown(this.ultrGrid.Rows.Count - 1, null,
                            UltraGridAction.BelowCell, e);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region -- その他 --

        /// <summary>
        /// 画面終了時の処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面を終了するときにイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public void PMKHN05121UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 編集済みフラグがoffの場合、ここで処理を終了します。
            if (!this.isEdit)
            {
                return;
            }

            // フォーカスを先頭に戻します。
            this.tNdtCstmrCdStart.Focus();

            // 変換後の得意先コード列で入力されているセルの数を数えます。
            int editedCount = 0;
            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                UltraGridCell cell = row.Cells[GridSettingInfo.COL_AF_CD];
                if (!String.IsNullOrEmpty(cell.Text.Trim()) && Convert.ToInt32(cell.Value) != 0)
                {
                    editedCount++;
                }
            }

            // 変更後コードがある場合は、更新処理を実行するか否かを
            // ユーザに問い合わせます。
            if (editedCount != 0)
            {
                // 確認ダイアログを表示します。
                DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.pgId,
                    MessageMng.INFO_MES_012, 0, MessageBoxButtons.YesNoCancel);

                // DialogResultの結果に応じて処理を分岐させます。
                if (result == DialogResult.Yes)
                {
                    // closeインベントをキャンセルします。
                    e.Cancel = true;
                    // FormClosingイベントからコード変換を実行するのでフラグをonにします。
                    this.isCallFormCloseingEvent = true;
                    // OKを押下した時は、登録を実施してから終了します。
                    this.ConvertCustomerCode();
                }
                else if (result == DialogResult.Cancel)
                {
                    // キャンセルを押下した時は、終了処理をキャンセルします。
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// フォーム初回表示時のイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを初回表示したときにイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void PMKHN05121UA_Shown(object sender, EventArgs e)
        {
            // 得意先コード(開始)入力欄にフォーカスをセット
            this.tNdtCstmrCdStart.Focus();
        }

        /// <summary>
        /// 得意先ガイドボタンイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンをクリックするとイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void ultrBtnCstmrStart_Click(object sender, EventArgs e)
        {
            // 押下されたボタンを保存
            UltraButton btnCtrl = sender as UltraButton;
            this.btnType = (GuidButtonType)btnCtrl.Tag;

            // 得意先ガイドを起動 
            PMKHN04005UA customerSearchFrm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchFrm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchFrm_CustomerSelect);
            customerSearchFrm.Show(this);
        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="searchRet">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンをクリックするとイベントの処理。</br>
        /// <br>             得意先コード入力欄と得意先名称にガイドから取得したデータをセットします。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        void customerSearchFrm_CustomerSelect(object sender, CustomerSearchRet searchRet)
        {
            if (searchRet == null) return;

            CustomerInfo cstmrInf;
            int status = this.customerAcs.ReadDBData(ConstantManagement.LogicalMode.GetDataAll, searchRet.EnterpriseCode,
                searchRet.CustomerCode, true, out cstmrInf);
            if (status != 0) return;

            TNedit tNEdit = this.btnType == GuidButtonType.Start ? this.tNdtCstmrCdStart : this.tNdtCstmrCdEnd;
            tNEdit.Text = String.Format(PMKHN05121UA.cdFormat, cstmrInf.CustomerCode);
            TEdit tEdit = this.btnType == GuidButtonType.Start ? this.tEdtCstmrNmStart : this.tEdtCstmrNmEnd;
            tEdit.Text = cstmrInf.Name;
        }

        /// <summary>
        /// ツールメニュークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ツールメニューをクリックするとイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void tToolBarMain_ToolClick(object sender, ToolClickEventArgs e)
        {
            // フォーカスを先頭に戻します。
            tNdtCstmrCdStart.Focus();
            // クリックしたメニューによって処理を分岐
            switch (e.Tool.Key)
            {
                // 終了
                case ToolMenuType.BTN_TOOL_CLOSE:
                    // 終了時は親フォームから閉じます。
                    ((Form)this.Parent).Close();
                    break;
                // 実行
                case ToolMenuType.BTN_TOOL_EXEC:
                    this.ConvertCustomerCode();
                    break;
                // 検索
                case ToolMenuType.BTN_TOOL_SEARCH:
                    this.Search();
                    break;
                // クリア
                case ToolMenuType.BTN_TOOL_CLEAR:
                    this.Clear();
                    break;
                // それ以外
                default:
                    // 処理なし
                    break;
            }
        }

        /// <summary>
        /// 一括設定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 一括設定ボタンをクリックするとイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        private void ultrBtnSttng_Click(object sender, EventArgs e)
        {
            // 一括設定のタイプ
            AllSettingType type = (AllSettingType)Enum.ToObject(typeof(AllSettingType), Convert.ToInt32(this.ultrRbtnCllctvSttng.Value));
            // グリッドのデータ
            DataTable tbl = ((DataView)this.ultrGrid.DataSource).Table;
            // 変換の補正値を格納する変数
            int offset = 0;
            // 変換処理オブジェクト
            AllSetting convObj = null;

            switch (type)
            {
                case AllSettingType.Equivalence:
                    // 同値を選択時
                    convObj = new AllSettingEquivalence();
                    break;
                case AllSettingType.ADD:
                    // 加算を選択時
                    // 数値チェック
                    if (this.IsNotNumber(this.tNdtAdd))
                    {
                        return;
                    }
                    // 入力値をチェックします。
                    if (this.tNdtAdd.GetInt() == 0)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_001);
                        this.tNdtAdd.Focus();
                        return;
                    }

                    offset = this.tNdtAdd.GetInt();
                    convObj = new AllSettingAdd();
                    break;
                case AllSettingType.Multiplication:
                    // 乗算を選択時
                    // 数値チェック
                    if (this.IsNotNumber(this.tNdtMul))
                    {
                        return;
                    }
                    // 入力値をチェックします
                    if (this.tNdtMul.GetInt() == 0)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_002);
                        this.tNdtMul.Focus();
                        return;
                    }                    

                    offset = this.tNdtMul.GetInt();
                    convObj = new AllSettingMultiplication();
                    break;
                default:
                    // それ以外(連番)を選択時
                    // 数値チェック
                    if (this.IsNotNumber(this.tNdtSerNum))
                    {
                        return;
                    }
                    // 入力値をチェックします
                    if (this.tNdtSerNum.GetInt() == 0)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_003);
                        this.tNdtSerNum.Focus();
                        return;
                    }                    

                    offset = this.tNdtSerNum.GetInt();
                    convObj = new AllSettingSequence();
                    break;
            }

            // 変換を実行します。
            string cnvCode = String.Empty;
            foreach (DataRow row in tbl.Rows)
            {
                if (String.IsNullOrEmpty(row[GridSettingInfo.COL_AF_CD].ToString()) ||
                    Convert.ToInt32(row[GridSettingInfo.COL_AF_CD]) == 0)
                {
                    cnvCode = convObj.Convert(
                        Convert.ToInt32(row[GridSettingInfo.COL_BF_CD]), ref offset);

                    //設定値が0以下、またはMAXを超えていたら、設定しない。
                    if (Convert.ToInt32(cnvCode) <= 0 || Convert.ToInt32(cnvCode) > 99999999)
                    {
                        continue;
                    }

                    // 変換後得意先コード
                    row[GridSettingInfo.COL_AF_CD] = cnvCode;
                    // 変換後得意先名
                    row[GridSettingInfo.COL_AF_NM] = this.GetCustomerName(cnvCode);
                    // 編集済みフラグをonにします。
                    this.isEdit = true;
                }
            }
        }

        /// <summary>
        /// 一括設定入力欄編集モード終了後の処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 一括設定入力欄編集モード終了後にイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private void tNdtAdd_AfterExitEditMode(object sender, EventArgs e)
        {
            TNedit nEdit = sender as TNedit;
            if (nEdit != null)
            {
                //マイナスを許容する関係で5ケタ許容にしているが、絶対値が5ケタを超えたら修正。
                if (nEdit == this.tNdtAdd)
                {
                    int buf = Math.Abs(nEdit.GetInt());
                    if (buf > 99999999)
                    {
                        nEdit.SetValue(99999999);
                    }
                }

                if (nEdit.GetInt() != 0 && this.allSttngPrevValMap[(AllSettingType)nEdit.Tag] != nEdit.GetInt())
                {
                    this.ultrRbtnCllctvSttng.Value = (int)nEdit.Tag;
                    this.ultrRbtnCllctvSttng.FocusedIndex = (int)nEdit.Tag;
                }
                // メモリに保存した一括設定の情報を変更した上書きします。
                // 未入力 or 0の場合も0で上書きします。
                this.allSttngPrevValMap[(AllSettingType)nEdit.Tag] = nEdit.GetInt();
            }
        }

        #endregion

        #endregion

        #region -- Enumeration --

        /// <summary>
        /// UltraExpandableGroupBoxのタイプを表す列挙子
        /// </summary>
        private enum EgbGrpBoxType
        {
            // 抽出条件用
            Condition,
            // 一括設定用
            CollectiveSetting
        }

        /// <summary>
        /// 押下したガイドボタンの種別を表す列挙子
        /// </summary>
        private enum GuidButtonType
        {
            // 開始ボタン
            Start,
            // 終了ボタン
            End
        }

        /// <summary>
        /// 一括設定のタイプを表す列挙子
        /// </summary>
        private enum AllSettingType
        {
            /// <summary>同値</summary>
            Equivalence = 0,
            /// <summary>追加</summary>
            ADD,
            /// <summary>乗算</summary>
            Multiplication,
            /// <summary>連番</summary>
            Sequence
        }

        /// <summary>
        /// 論理削除の種別を表す列挙子
        /// </summary>
        private enum LogicalDeleteType
        {
            /// <summary>有効</summary>
            Valid = 0,
            /// <summary>論理削除</summary>
            Logical,
            /// <summary>保留/summary>
            Hold,
            /// <summary>完全削除</summary>
            Deleted
        }

        #endregion

        #region -- Inner Class --

        #region -- Constant Class --

        /// <summary>
        /// PM.NS統合ツール　メッセージ情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : メッセージ情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class MessageMng
        {
            #region -- エラーメッセージ --

            /// <summary>ERR_MES_001:加算値が未入力です。</summary>
            public const string ERR_MES_001 = "加算値が未入力です。";
            /// <summary>ERR_MES_002:乗算値が未入力です。</summary>
            public const string ERR_MES_002 = "乗算値が未入力です。";
            /// <summary>ERR_MES_003:開始番号が未入力です。</summary>
            public const string ERR_MES_003 = "開始番号が未入力です。";
            /// <summary>ERR_MES_004:データの取得に失敗しました。\r\n詳細\r\n{0}</summary>
            public const string ERR_MES_004 = "データの取得に失敗しました。\r\n詳細\r\n{0}";
            /// <summary>ERR_MES_005:得意先コードの変換に失敗しました。\r\n詳細\r\n{0}</summary>
            public const string ERR_MES_005 = "得意先コードの変換に失敗しました。\r\n詳細\r\n{0}";
            /// <summary>ERR_MES_006:得意先コードの変換に失敗しました。</summary>
            public const string ERR_MES_006 = "得意先コードの変換に失敗しました。";
            /// <summary>ERR_MES_007:変換後コードは4桁以内で登録してください。</summary>
            public const string ERR_MES_007 = "変換後コードは{0}桁以内で登録してください。";
            /// <summary>ERR_MES_008:変更後の得意先コードが重複しています。</summary>
            public const string ERR_MES_008 = "変更後の得意先コードが重複しています。";
            /// <summary>ERR_MES_009:変換対象のコードがありません。</summary>
            public const string ERR_MES_009 = "変換対象のコードがありません。";
            /// <summary>ERR_MES_010:得意先の範囲指定が不正です。</summary>
            public const string ERR_MES_010 = "得意先の範囲指定が不正です。";
            /// <summary>ERR_MES_011:データの取得に失敗しました。</summary>
            public const string ERR_MES_011 = "データの取得に失敗しました。";
            /// <summary>ERR_MES_012:画面起動時にエラーが発生しました。\r\n詳細：{0}</summary>
            public const string ERR_MES_012 = "画面起動時にエラーが発生しました。\r\n詳細：{0}";
            /// <summary>ERR_MES_013:得意先コード変換対象ファイルに対象となるテーブルがありません。\r\nファイル内容を見直してください。</summary>
            public const string ERR_MES_013 = "得意先コード変換対象ファイルに対象となるテーブルがありません。\r\nファイル内容を見直してください。";
            /// <summary>ERR_MES_014:得意先コード変換対象ファイルに不正なデータが有ります。\r\nファイルの内容を見直してください。</summary>
            public const string ERR_MES_014 = "得意先コード変換対象ファイルに不正なデータが有ります。\r\nファイルの内容を見直してください。";
            /// <summary>ERR_MES_015:得意先コード変換対象ファイルがありません。</summary>
            public const string ERR_MES_015 = "得意先コード変換対象ファイルがありません。";
            /// <summary>ERR_MES_016:数値ではない値が入力されています。</summary>
            public const string ERR_MES_016 = "数値ではない値が入力されています。";

            #endregion

            #region -- インフォメッセージ --

            /// <summary>INFO_MES_001:コード変換開始</summary>
            public const string INFO_MES_001 = "コード変換開始";
            /// <summary>INFO_MES_002:コード変換完了</summary>
            public const string INFO_MES_002 = "コード変換完了";
            /// <summary>INFO_MES_003:エラー</summary>
            public const string INFO_MES_003 = "エラー";
            /// <summary>INFO_MES_004:コンバートを実行しますが、よろしいですか？</summary>
            public const string INFO_MES_004 = "コンバートを実行しますが、よろしいですか？";
            /// <summary>INFO_MES_005:コード：コード：{0}を変換中... {1}/{2}件</summary>
            public const string INFO_MES_005 = "{0}を変換中... {1}/{2}件";
            /// <summary>INFO_MES_006:コード：コンバート処理を実行済みです。\r\n再度実行する場合は検索ボタンをクリックして\r\nデータを最新化してください。</summary>
            public const string INFO_MES_006 = "コンバート処理を実行済みです。\r\n再度実行する場合は検索ボタンをクリックして\r\nデータを最新化してください。";
            /// <summary>INFO_MES_007:削除済みのデータです。</summary>
            public const string INFO_MES_007 = "削除済みのデータです。";
            /// <summary>INFO_MES_008:得意先コード変換処理</summary>
            public const string INFO_MES_008 = "得意先コード変換処理";
            /// <summary>INFO_MES_009:得意先コード変換を変換中です…</summary>
            public const string INFO_MES_009 = "得意先コード変換を変換中です…";
            /// <summary>INFO_MES_010:得意先マスタ抽出処理</summary>
            public const string INFO_MES_010 = "得意先マスタ抽出処理";
            /// <summary>INFO_MES_011:得意先マスタを抽出中です…</summary>
            public const string INFO_MES_011 = "得意先マスタを抽出中です…";
            /// <summary>INFO_MES_012:編集中のデータ存在します。\r\nコード変換処理を実行しますか？</summary>
            public const string INFO_MES_012 = "編集中のデータ存在します。\r\nコード変換処理を実行しますか？";
            /// <summary>INFO_MES_013:検索条件に該当する得意先マスタは存在しません。</summary>
            public const string INFO_MES_013 = "検索条件に該当する得意先マスタは存在しません。";

            #endregion
        }

        /// <summary>
        /// PM.NS統合ツール　グリッドの固定設定情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの固定設定情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class GridSettingInfo
        {
            #region -- Constractor --

            /// <summary>
            /// PM.NS統合ツール　グリッドの固定設定情報を保存した内部クラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : PM.NS統合ツール、グリッドの固定設定情報を保存した内部クラスの初期処理を行います。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            private GridSettingInfo()
            {
                // 定数クラスの為、処理なし
            }

            #endregion

            #region -- 定数 --

            /// <summary>データテーブルのテーブル名</summary>
            public const string TBL_NAME = "cdCnvDt";

            #region -- 列名 --

            /// <summary>No.列の列名</summary>
            public const string COL_NO_CAP = "No.";
            /// <summary>No.列の識別子</summary>
            public const string COL_NO = "No";

            /// <summary>得意先コード列の列名</summary>
            public const string COL_CD_CAP = "得意先コード";
            /// <summary>変更前得意先コード列の識別子</summary>
            public const string COL_BF_CD = "BeforeCd";
            /// <summary>変更後得意先コード列の識別子</summary>
            public const string COL_AF_CD = "AeforeCd";

            /// <summary>得意先名列の列名</summary>
            public const string COL_NM_CAP = "得意先名";
            /// <summary>変更前得意先名列の識別子</summary>
            public const string COL_BF_NM = "BeforeNm";
            /// <summary>変更後得意先名列の識別子</summary>
            public const string COL_AF_NM = "AeforeNm";

            /// <summary>削除済み列の列名</summary>
            public const string COL_LDEL_NM = "削除済み";
            /// <summary>削除済み列の識別子</summary>
            public const string COL_LDEL = "LogicalDel";

            #endregion

            #region -- 列幅 --

            /// <summary>No.列の列幅:45</summary>
            public const int COL_NO_WIDTH = 45;
            /// <summary>変更前得意先コード列の列幅:150</summary>
            public const int COL_BF_CD_WIDTH = 150;
            /// <summary>変更後得意先コード列の列幅:150</summary>
            public const int COL_AF_CD_WIDTH = 150;
            /// <summary>変更前得意先名列の列幅:200</summary>
            public const int COL_BF_NM_WIDTH = 200;
            /// <summary>変更後得意先名列の列幅:200</summary>
            public const int COL_AF_NM_WIDTH = 200;

            #endregion

            #endregion
        }

        /// <summary>
        /// PM.NS統合ツール　ツールメニューの情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールメニューの情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class ToolMenuType
        {
            #region -- 定数 --

            /// <summary>終了ボタンを表す定数</summary>
            public const string BTN_TOOL_CLOSE = "btnToolClose";
            /// <summary>実行ボタンを表す定数</summary>
            public const string BTN_TOOL_EXEC = "btnToolExcec";
            /// <summary>検索ボタンを表す定数</summary>
            public const string BTN_TOOL_SEARCH = "btnToolSearch";
            /// <summary>クリアボタンを表す定数</summary>
            public const string BTN_TOOL_CLEAR = "btnToolClear";
            /// <summary>拠点名欄を表す定数</summary>
            public const string LBL_TOOL_SECTION = "lblSecName";
            /// <summary>ログインユーザ名欄を表す定数</summary>
            public const string LBL_TOOL_NAME = "lblLoginName";

            #endregion
        }

        /// <summary>
        /// PM.NS統合ツール　ステータスバーの情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ステータスバーの情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class StatusKeyType
        {
            #region -- 定数 --

            /// <summary>ステータスバーのステータス表示領域を示すキー:status</summary>
            public const string STTS_KEY_STATUS = "status";
            /// <summary>ステータスバーのプログレスバー表示領域を示すキー:status</summary>
            public const string STTS_KEY_PROGRESS = "progress";
            /// <summary>ステータスバーの日付表示領域を示すキー:date</summary>
            public const string STTS_KEY_DATE = "date";
            /// <summary>ステータスバーの時刻表示領域を示すキー:status</summary>
            public const string STTS_KEY_TIME = "time";

            /// <summary>ステータスバーのプログレスバーのインデックス:0</summary>
            public const int STTS_IDX_PROGRESS = 0;

            #endregion
        }

        #endregion

        #region -- 入力値チェック用に一時的に値を保存するクラス --

        /// <summary>
        /// 入力値チェック用に一時的に値を保存するクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力値チェック用に一時的に値を保存するクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private sealed class CustomerInputData
        {
            #region -- Member --

            /// <summary>得意先コード(変更前)</summary>
            private string bfCustomerCd = String.Empty;
            /// <summary>得意先コード(変更後)</summary>
            private string afCustomerCd = String.Empty;
            /// <summary>交換対象の得意先コード(変更前)</summary>
            private string chgBfCusCd = String.Empty;
            /// <summary>交換対象の得意先コード(変更後)</summary>
            private string chgAfCusCd = String.Empty;
            /// <summary>グリッド内の行番号</summary>
            private int rowIndex = 0;
            /// <summary>別の得意先コードとコードの変換があったことを表すフラグ</summary>
            private bool isOtherCodeChand = false;

            #endregion

            #region -- Property --

            /// <summary>得意先コード(変更前)プロパティ</summary>
            public String BfCustomerCode
            {
                get { return this.bfCustomerCd; }
                set { this.bfCustomerCd = value; }
            }

            /// <summary>得意先コード(変更後)プロパティ</summary>
            public String AfCustomerCode
            {
                get { return this.afCustomerCd; }
                set { this.afCustomerCd = value; }
            }

            /// <summary>グリッド内の行番号</summary>
            public int RowIndex
            {
                get { return this.rowIndex; }
                set { this.rowIndex = value; }
            }

            /// <summary>別得意先コードとコードの交換があったことを示すフラグのプロパティ</summary>
            public bool IsOtherCodeChange
            {
                get { return this.isOtherCodeChand; }
            }

            #endregion

            #region -- Method --

            /// <summary>
            /// 別得意先コード保存処理
            /// </summary>
            /// <param name="bfCode">交換対象の得意先コード(変換前)</param>
            /// <param name="afCode">交換対象の得意先コード(変換後)</param>
            /// <remarks>
            /// <br>Note       : 別の得意先コードとコードの交換があった場合は、交換したコードを保存します。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public void SetOtherCodeChange(string bfCode, string afCode)
            {
                this.chgBfCusCd = bfCode;
                this.chgAfCusCd = afCode;
                this.isOtherCodeChand = (this.bfCustomerCd == this.chgAfCusCd) &&
                    (this.afCustomerCd == this.chgBfCusCd);
            }

            /// <summary>
            /// 編集済み判定処理
            /// </summary>
            /// <returns>true:編集有り/false:編集無し</returns>
            /// <remarks>
            /// <br>Note       : 選択中の得意先コードが編集したデータか否かを判定します。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public bool IsEdit()
            {
                return this.bfCustomerCd != this.afCustomerCd;
            }

            #endregion
        }

        #endregion

        #region -- 計算用のクラス --

        /// <summary>
        /// PM.NS統合ツール　一括変換を行うクラスの基底クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括変換を行うクラスの基底クラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private abstract class AllSetting
        {
            /// <summary>
            /// 変換処理
            /// </summary>
            /// <param name="bfrVal">変換対象の値</param>
            /// <param name="offset">補正値</param>
            /// <returns>変換後の値</returns>
            /// <remarks>
            /// <br>Note       : 一括変換を行うクラスの基底クラスです。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            abstract public string Convert(int bfrVal, ref int offset);
        }

        /// <summary>
        /// PM.NS統合ツール　同値の一括変換を行うクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 同値の一括変換を行うクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class AllSettingEquivalence : AllSetting
        {
            /// <summary>
            /// 変換処理
            /// </summary>
            /// <param name="bfrVal">変換対象の値</param>
            /// <param name="offset">補正値</param>
            /// <returns>変換後の値</returns>
            /// <remarks>
            /// <br>Note       : 変換後の値を変換前と同じ値に変換します。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/02/18</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05121UA.cdFormat, bfrVal);
            }
        }

        /// <summary>
        /// PM.NS統合ツール　加算の一括変換を行うクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 加算の一括変換を行うクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class AllSettingAdd : AllSetting
        {
            /// <summary>
            /// 変換処理
            /// </summary>
            /// <param name="bfrVal">変換対象の値</param>
            /// <param name="offset">補正値</param>
            /// <returns>変換後の値</returns>
            /// <remarks>
            /// <br>Note       : 指定した値を変換前の値に加算した値を変換後の値にします。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05121UA.cdFormat, bfrVal + offset);
            }
        }

        /// <summary>
        /// PM.NS統合ツール　乗算の一括変換を行うクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 乗算の一括変換を行うクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private class AllSettingMultiplication : AllSetting
        {
            /// <summary>
            /// 変換処理
            /// </summary>
            /// <param name="bfrVal">変換対象の値</param>
            /// <param name="offset">補正値</param>
            /// <returns>変換後の値</returns>
            /// <remarks>
            /// <br>Note       : 指定した値を変換前の値に乗算した値を変換後の値にします。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                return String.Format(PMKHN05121UA.cdFormat, bfrVal * offset);
            }
        }

        /// <summary>
        /// PM.NS統合ツール　連番の一括変換を行うクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 連番の一括変換を行うクラスです。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private class AllSettingSequence : AllSetting
        {
            /// <summary>
            /// 変換処理
            /// </summary>
            /// <param name="bfrVal">変換対象の値</param>
            /// <param name="offset">補正値</param>
            /// <returns>変換後の値</returns>
            /// <remarks>
            /// <br>Note       : 変換後の値を指定した値の連番に変換します。</br>
            /// <br>Programmer : 30365 宮津</br>
            /// <br>Date       : 2016/03/23</br>
            /// </remarks>
            public override string Convert(int bfrVal, ref int offset)
            {
                string convVal = String.Format(PMKHN05121UA.cdFormat, offset);
                offset++;
                return convVal;
            }
        }

        #endregion                                               
      
        #endregion
    }
}