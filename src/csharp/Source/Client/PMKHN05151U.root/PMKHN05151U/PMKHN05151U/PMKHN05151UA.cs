//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール 伝票番号変換　UIフォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//****************************************************************************//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 倉内
// 修 正 日  2018/09/27  修正内容 : NS集計ツールPG組み込み
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 井上
// 修 正 日  2018/10/02  修正内容 : 受注ステータスコードの設定不備の修正
//****************************************************************************//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PM.NS統合ツール 伝票番号変換　UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール 伝票番号変換　UIフォームクラスす。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/04</br>
    /// </remarks>
    public partial class PMKHN05151UA : Form
    {
        #region -- 定数 --

        /// <summary>プログラムIDを表す定数:PMKHN05151UA</summary>
        private readonly string pgId = "PMKHN05151UA";
        /// <summary>抽出条件、一括設定の縮小時のサイズ</summary>
        private readonly int egbGrpBoxCntrctSize = 25;
        
        /// <summary>UOE発注データ番号の番号コード</summary>
        private const int uoeNo = 3300;

        /// <summary>全社共通の拠点コード</summary>
        private const string allSectionCd = "000000";
        
        ///// <summary>拠点名称が登録されていないことを示す定数：未登録</summary>
        private readonly string noSectionName = "未登録";
        ///// <summary>全社共通</summary>
        private readonly string allSectionName = "全社共通";

        ///// <summary>先頭行を表す定位数</summary>
        private readonly int firstRow = 0;
        /// <summary>伝票番号変換対象ファイルに不正データが有ることを示す定数：997</summary>
        private const int ILLEGAL_DATA = 997;
        /// <summary>伝票番号変換対象ファイルにデータが無いことを示す定数：998</summary>
        private const int NO_DATA = 998;
        /// <summary>伝票番号変換対象ファイルが存在しないことを示す定数：999</summary>
        private const int NO_FILE = 999;
        /// <summary>数値チェック用の正規表現：^\d+$</summary>
        private readonly string regPttrnNum = @"^\d+$";

        #region -- ログ関連 --
        /// <summary>ログ出力先のディレクトリ名を表す定数：./LOG/PMKHN05130U</summary>
        private const string LOG_DIR_PATH = @"./LOG/PMKHN05150U";
        /// <summary>ログファイル名を表す定数：PMKHN05130U.log</summary>
        private const string LOG_FILE_NAME = @"PMKHN05150U_{0}.log";
        /// <summary>ログファイル名の日付部分のフォーマット：yyyyMMdd</summary>
        private const string LOG_FORMAT_DATE = "yyyyMMdd";
        /// <summary>ログフォーマット：HH:mm:ss</summary>
        private const string LOG_FORMAT_PROCESSING_TIME = "HH:mm:ss";
        /// <summary>ログフォーマット：[{0}] 伝票番号変換処理を開始します。</summary>
        private const string LOG_FORMAT_START = "[{0}],伝票番号変換処理を開始します。";
        /// <summary>ログフォーマット：[{0}] 伝票番号変換処理が完了しました。</summary>
        private const string LOG_FORMAT_END = "[{0}],伝票番号変換処理が完了しました。";
        /// <summary>ログフォーマット：[{0}],更新対象：{1},更新件数：{2}件,処理時間：{3}</summary>
        private const string LOG_FORMAT_CASE_BY_BASE = "[{0}],更新対象：{1},更新件数：{2}件,処理時間：{3}";
        /// <summary>ログフォーマット：[{0}],総処理時間：{1},総更新件数：{2}件</summary>
        private const string LOG_FORMAT_TOTAL = "[{0}],総処理時間：{1},総更新件数：{2}件";
        /// <summary>ログフォーマット：[{0}] {1}の変換中にエラーが発生しました。変換処理を中止します。</summary>
        private const string LOG_FORMAT_ERROR = "[{0}],{1}の変換中にエラーが発生しました。変換処理を中止します。";
        /// <summary>ログファイル内の日付フォーマット：yyyy/MM/dd HH:mm:ss</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd HH:mm:ss";
        #endregion

        #endregion

        #region -- Member --

        /// <summary>
        /// ステータスバー更新処理デリゲート
        /// </summary>
        /// <param name="mes">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーを更新するためのデリゲート。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04<</br>
        /// </remarks>
        delegate void UpdateStatusBarDelegate(string mes);

        /// <summary>
        /// ステータスバー初期化処理デリゲート
        /// </summary>
        /// <param name="mes">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーを初期化するためのデリゲート。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04
        /// </remarks>
        delegate void InitStatusBarDelegate(int cnvTrgTblCount);


        // アクセスクラス関連
        /// <summary>拠点マスタ</summary>
        private SecInfoAcs secInfoAcs;
        ///// <summary>伝票番号変換</summary>
        private SlipNoConvertAcs slipNoConvertAcs;
        /// <summary>処理中ダイアログ</summary>
        private SFCMN00299CA procDlg = null;
        /// <summary>ログインユーザの所属拠点</summary>
        private string loginSecCd = String.Empty;
        /// <summary>企業コード</summary>
        private string enterPriseCd = String.Empty;
        /// <summary>変換対象拠点コード</summary>
        private string tgsectionCd = String.Empty;
        /// <summary>抽出条件と一括設定のUltraExpandableGroupBoxの展開時の高さ情報を格納したマップ</summary>
        private IDictionary<EgbGrpBoxType, int> egbGrpBoxHeighMap = null;
        /// <summary>画面のスキン情報を格納</summary>
        private ControlScreenSkin ctrlScrnSkin;        
        /// <summary>拠点情報情報格納マップ</summary>
        private Dictionary<string, String> secInfoMap;
        /// <summary>番号タイプ管理マスタ情報格納マップ</summary>
        private Dictionary<Int32, String> noTypeMngMap;
        /// <summary>更新フラグ(true:更新済み/false:未更新)</summary>
        private bool isUpdate = false;
        /// <summary>編集済み確認フラグ(true:編集済み/false:未編集)</summary>
        private bool isEdit = false;
        /// <summary>入力チェックの結果を格納する変数(true:チェックOK/false:チェックNG)</summary>
        private bool isCheckOK = false;
        ///// <summary>コードの桁数</summary>
        private int codeLength = 0;
        ///// <summary>コードの桁数</summary>
        private int secCodeLength = 0;
        /// <summary>スレッド実行時のエラーメッセージを保存</summary>
        private string cnvErrMes = String.Empty;
        /// <summary>FormCloingイベントで実施されたかを判定するフラグ(true:FormCloigから実施/false:FormCloing以外で実施)</summary>
        private bool isCallFormCloseingEvent = false;
        /// <summary>伝票番号　変換データを格納</summary>
        private IList<SlpNoConvertData> slipConvertDtList;
        /// <summary>番号管理マスタデータを格納</summary>
        private ArrayList noMgSetWork;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS伝票番号変換処理ツール　UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS伝票番号変換処理ツールUIフォームクラスの初期処理を行います。</br>
        /// <br>Programmer : 30175 倉内
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        public PMKHN05151UA()
        {
            InitializeComponent();
            // 各種部品の初期化を行います。
            this.ctrlScrnSkin = new ControlScreenSkin();
            // 抽出条件と一括設定の展開時の高さ情報を保存
            this.egbGrpBoxHeighMap = new Dictionary<EgbGrpBoxType, int>();
            this.egbGrpBoxHeighMap[EgbGrpBoxType.Conditon] = this.ultrEgbCondition.Height;
            this.egbGrpBoxHeighMap[EgbGrpBoxType.CollectiveSetting] = this.ultrEgbCllctvSttng.Height;

            // コードの桁数を設定します。
            this.codeLength = 9;
            this.secCodeLength = 2;
        }

        #endregion

        #region -- Protected Method --

        /// <summary>
        /// 画面の初期化処理
        /// </summary>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            // 基底クラスのロードを実行します。
            base.OnLoad(e);

            // 画面の描画を一時停止します。
            this.SuspendLayout();

            // 各コントロールの初期化を行います
            this.InitSetting();

            // 画面のスキンを設定します。
            this.InitSkin();

            // メニュー、及びボタンのアイコンを設定します。
            this.tTooBarMain.ImageListSmall = IconResourceManagement.ImageList16;
            this.ultrBtnWrhs.ImageList = IconResourceManagement.ImageList16;

            // 拠点マスタの初期化
            this.secInfoAcs = new SecInfoAcs();
            this.GetSecInfoSet();

            // 企業コード
            this.enterPriseCd = LoginInfoAcquisition.EnterpriseCode;
            // ログイン拠点コード
            this.loginSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ログインユーザ情報の初期化
            this.SetUserInfo();

            // グリッドの初期設定を設定します。
            this.InitGrid();

            // 処理中ダイアログ
            this.procDlg = new SFCMN00299CA();

            //アクセスクラス
            this.slipNoConvertAcs = new SlipNoConvertAcs();

            // 数値入力欄の初期化
            this.SetTnEditMaxLength(this.pnlCllctvSttng);
            this.SetTnEditMaxLength(this.pnlCondtion);

            // 一括設定の入力欄を初期化します。            
            this.SetAllSettingTypeOnTNEdit();
            this.tNdtSub.Enabled = false;


            // 画面の描画を再開します。
            this.ResumeLayout(false);
        }

        #endregion

        #region -- Private Method --

        #region -- 初期設定関連 --

        /// <summary>
        /// 画面スキンファイル初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面スキンファイルの初期設定を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private void InitSkin()
        {
            // スキン適用外のコントロールを保存します。
            List<string> exclustionList = new List<string>();
            exclustionList.Add(this.ultrEgbCondition.Name);
            exclustionList.Add(this.ultrEgbCllctvSttng.Name);
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void InitSetting()
        {
            /// UltraExpandableGroupBoxの初期化
            // 抽出条件
            this.ultrEgbCondition.Tag = EgbGrpBoxType.Conditon;
            // 一括設定
            this.ultrEgbCllctvSttng.Tag = EgbGrpBoxType.CollectiveSetting;

        }

        /// <summary>
        /// ユーザ情報初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログインユーザ情報を元にユーザの表示情報を設定します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void SetUserInfo()
        {
            // 拠点名
            ToolBase secNm = tTooBarMain.Tools[ToolMenuType.LBL_TOOL_SECTION];
            if (secNm != null && LoginInfoAcquisition.Employee != null)
            {
                secNm.SharedProps.Caption = this.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }
            // ログイン名
            ToolBase loginNm = tTooBarMain.Tools[ToolMenuType.LBL_TOOL_NAME];
            if (loginNm != null && LoginInfoAcquisition.Employee != null)
            {
                loginNm.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }
        }

        /// <summary>
        /// 数値入力欄初期化処理
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : 数値入力欄の初期化を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void SetTnEditMaxLength(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TNedit)
                {
                    TNedit edit = child as TNedit;
                    edit.MaxLength = this.codeLength;
                }
                else
                {
                    SetTnEditMaxLength(child);
                }
            }
        }

        /// <summary>
        /// / 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタを読み込み、拠点名称をメモリに保持します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void GetSecInfoSet()
        {
            // 拠点マスタから拠点情報を取得します
            this.secInfoMap = new Dictionary<string, string>();
            this.secInfoAcs.ResetSectionInfo();

            // 拠点情報をメモリにキャッシュします
            foreach (SecInfoSet secInfoSet in this.secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this.secInfoMap[secInfoSet.SectionCode.Trim()] = secInfoSet.SectionGuideNm.Trim();
                }
            }
        }

        /// <summary>
        /// 番号タイプ管理マスタ情報取得処理
        /// </summary>
        /// <param name="noTypeMngArry"></param>
        /// <remarks>
        /// <br>Note       : 番号タイプ管理マスタを読み込み、番号名称をメモリに保持します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void GetNoTypeSet(ArrayList noTypeMngArry)
        {
            //番号タイプ管理マスタから番号名称を取得します。
            this.noTypeMngMap = new Dictionary<int, string>();

            //番号タイプ管理マスタをメモリにキャッシュします
            foreach(NoTypeMng noTypeMag in noTypeMngArry)
            {
                if(noTypeMag.LogicalDeleteCode == 0)
                {
                    this.noTypeMngMap[noTypeMag.NoCode] = noTypeMag.NoName.Trim();
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCd)
        {
            // 拠点コードが入力されている場合は、該当するコードがある場合は紐付く拠点名称を
            // 該当コードが無い場合は未登録を呼び出し元に返却する
            string cd = sectionCd.Trim().PadLeft(this.secCodeLength, '0');

            if(!this.secInfoMap.ContainsKey(cd))
            {
                if (cd == "00")
                {
                    return this.allSectionName;
                }
                else
                {
                    return this.noSectionName;
                }
            }

            return this.secInfoMap[cd];
        }

        #endregion

        #region -- コントロールの初期化 --

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件等の入力内容、及びグリッドの情報をクリアします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06<</br>
        /// </remarks>
        private void Clear()
        {
            // 抽出条件のクリア
            this.InitControl(this.pnlCondtion);

            // 一括設定のクリア
            this.InitControl(this.pnlCllctvSttng);

            // グリッドのクリア
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            // ステータスバーを初期状態に戻します。
            this.InitStatusBar();

            // 更新済みフラグをoffにします。
            this.isUpdate = false;
            // 編集済みフラグをoffにします。
            this.isEdit = false;

            //メモリに保存している伝票変換データをクリア
            if (this.slipConvertDtList != null)
            {
                this.slipConvertDtList.Clear();
            }

            //メモリに保存している伝票管理データのクリア
            if(this.noMgSetWork != null)
            {
                this.noMgSetWork.Clear();
            }

            // フォーカスを先頭に戻します
            this.tNdtWrHsCd.Focus();
        }

        /// <summary>
        /// コントロール初期化処理
        /// </summary>
        /// <param name="parent"></param>
        /// <remarks>
        /// <br>Note       : TEdit、TNedit、UltraOptionSet、UltraWinGridの内容を初期化します。</br>
        /// <br>             上記以外のコントロールの場合、配下のコントロールを再帰的に呼び出して</br>
        /// <br>             子コントロールが無くなるまで探します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/15<</br>
        /// </remarks>
        private void InitControl(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TEdit || child is TNedit)
                {
                    // エディット関係のコントロールは内容をクリアします
                    child.Text = String.Empty;
                }
                else if (child is UltraOptionSet)
                {
                    // ラジオボタンは加算を選択します
                    UltraOptionSet optSet = child as UltraOptionSet;
                    optSet.FocusedIndex = (int)AllSettingType.ADD;
                    optSet.Value = (int)AllSettingType.ADD;
                }
                else
                {
                    // それ以外の場合は再帰的にコントロールを呼び出します
                    this.InitControl(child);
                }
            }
        }

        /// <summary>
        /// ステータスバー初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ステータスバーを初期状態に戻します。。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
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

        #region -- grid関連のメソッド --

        /// <summary>
        /// グリッドコントロール初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドコントロールの初期設定を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void InitGrid()
        {
            // テーブルの作成し、グリッドにバインドします。
            this.ultrGrid.DataSource = new DataView(this.CreateDataTable());
            // 外観、各種設定の初期化
            this.InitGridLayout();
            // カラムの初期化
            this.InitGridColumns();
            // グリッドキーマッピング設定処理(↑←↓→、　Shift + Enter等フォーカス遷移)
            this.MakeKeyMappingForGrid(this.ultrGrid);
        }

        /// <summary>
        /// グリッド外観初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの外観の初期設定を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
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

        }

        /// <summary>
        /// グリッドカラム初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドカラムの初期設定を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private void InitGridColumns()
        {
            ColumnsCollection columns = this.ultrGrid.DisplayLayout.Bands[0].Columns;

            //番号
            UltraGridColumn column = columns[GridSettingInfo.COL_NO];
            this.SetColInfo(column, 0, GridSettingInfo.COL_NO, Infragistics.Win.HAlign.Right, false, null);
            //非表示にします
            column.Hidden = true;

            // 番号名
            column = columns[GridSettingInfo.COL_NO_NM];
            this.SetColInfo(column, GridSettingInfo.COL_NO_NM_WIDTH, GridSettingInfo.COL_NO_NM,
                Infragistics.Win.HAlign.Left,false,null);

            // 番号現在値
            column = columns[GridSettingInfo.COL_NO_PT];
            this.SetColInfo(column, GridSettingInfo.COL_NO_IDV_WIDTH, GridSettingInfo.COL_NO_PT,
                Infragistics.Win.HAlign.Right, false,"0");

            // 設定開始番号
            column = columns[GridSettingInfo.COL_NO_ST];
            this.SetColInfo(column, GridSettingInfo.COL_NO_ST_WIDTH, GridSettingInfo.COL_NO_ST,
                Infragistics.Win.HAlign.Right, false, "0");

            // 設定終了番号
            column = columns[GridSettingInfo.COL_NO_ED];
            this.SetColInfo(column, GridSettingInfo.COL_NO_ED_WIDTH, GridSettingInfo.COL_NO_ED,
                Infragistics.Win.HAlign.Right, false, "0");

            // 番号増減値
            column = columns[GridSettingInfo.COL_NO_IDV];
            this.SetColInfo(column, GridSettingInfo.COL_NO_IDV_WIDTH, GridSettingInfo.COL_NO_IDV,
                Infragistics.Win.HAlign.Right, true , "0");
            //入力文字数を制限する
            column.MaxLength = codeLength;

            // 番号増減幅
            column = columns[GridSettingInfo.COL_NO_IDW];
            this.SetColInfo(column, 0, GridSettingInfo.COL_NO_IDW, Infragistics.Win.HAlign.Right, false, null);
            //非表示にします
            column.Hidden = true;

        }

        /// <summary>
        /// 列初期化処理
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="width">列幅</param>
        /// <param name="caption">列見出し</param>
        /// <param name="hAlign">テキストの水平位置</param>
        /// <param name="isAllowEdit">編集の可否(true:可/false:不可)</param>
        /// <param name="format">入力値の書式(コードのみ指定します)</param>        
        /// <remarks>
        /// <br>Note       : 列の初期設定を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void SetColInfo(UltraGridColumn col, int width, string caption,
            Infragistics.Win.HAlign hAlign, Boolean isAllowEdit, string format)
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

        }

        /// <summary>
        /// データテーブル作成処理
        /// </summary>
        /// <remarks>
        /// <returns>テーブルオブジェクト</returns>
        /// <br>Note       : データテーブルの作成を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable(GridSettingInfo.TBL_NAME);
            //番号
            table.Columns.Add(GridSettingInfo.COL_NO, typeof(Int32));
            // 番号名
            table.Columns.Add(GridSettingInfo.COL_NO_NM, typeof(string));
            // 番号現在値
            table.Columns.Add(GridSettingInfo.COL_NO_PT, typeof(Int64));
            // 設定開始番号
            table.Columns.Add(GridSettingInfo.COL_NO_ST, typeof(Int64));
            // 設定終了番号
            table.Columns.Add(GridSettingInfo.COL_NO_ED, typeof(Int64));
            // 番号増減値
            table.Columns.Add(GridSettingInfo.COL_NO_IDV, typeof(Int64));
            // 番号増減幅
            table.Columns.Add(GridSettingInfo.COL_NO_IDW, typeof(Int32));


            return table;
        }

        ///// <summary>
        ///// グリッド表示情報セット処理
        ///// </summary>
        ///// <param name="sectionList">拠点情報一覧</param>
        ///// <returns>テーブルオブジェクト</returns>
        ///// <remarks>
        ///// <br>Note       : グリッドに表示するデータをセットします。</br>
        ///// <br>Programmer : 30175 倉内</br>
        ///// <br>Date       : 2018/09/05</br>
        ///// </remarks>
        /// <summary>
        /// グリッド表示情報セット処理
        /// </summary>
        /// <param name="noMngList">番号管理マスタデータ</param>
        private void SetDataToGrid(ArrayList noMngList,string sectionCode)
        {
            //データテーブルにデータをセットします
            DataTable table = ((DataView)this.ultrGrid.DataSource).Table;
            table.Clear();

            //データをクリアする
            if (this.noMgSetWork == null)
            {
                this.noMgSetWork = new ArrayList();
            }
            noMgSetWork.Clear();

            //行データ
            DataRow dr = null;

            foreach (NoMngSet wk in noMngList)
            {
                if (wk.SectionCode.Trim() == sectionCode || wk.SectionCode == allSectionCd)
                {
                    if (wk.SectionCode == allSectionCd && sectionCode != "00")
                    {
                        //何もしない。

                    }
                    else
                    {
                        //行の追加
                        dr = table.NewRow();
                        //番号
                        dr[GridSettingInfo.COL_NO] = wk.NoCode;
                        // 番号名
                        dr[GridSettingInfo.COL_NO_NM] = noTypeMngMap[wk.NoCode];
                        // 番号現在値
                        dr[GridSettingInfo.COL_NO_PT] = wk.NoPresentVal;
                        // 設定開始番号
                        dr[GridSettingInfo.COL_NO_ST] = wk.SettingStartNo;
                        // 設定終了番号
                        dr[GridSettingInfo.COL_NO_ED] = wk.SettingEndNo;
                        // 番号増減値
                        dr[GridSettingInfo.COL_NO_IDV] = 0;
                        // 番号増減幅
                        dr[GridSettingInfo.COL_NO_IDW] = wk.NoIncDecWidth;
                        //データテーブルへ追加
                        table.Rows.Add(dr);

                        //番号管理マスタ情報を格納します。
                        this.noMgSetWork.Add(wk);
                    }
                }

            }

        }

        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        /// <remarks>
        /// <br>Note       : ボタンの初期設定をします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
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

        #region -- 検索関連 --

        ///// <summary>
        ///// 検索処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 画面で指定した条件を元に番号管理設定データの検索を行います。</br>
        ///// <br>Programmer : 30175 倉内</br>
        ///// <br>Date       : 2018/09/05</br>
        ///// </remarks>
        private void Search()
        {
            //拠点コードが入力されているかチェックを行います。
            if (tNdtWrHsCd != null) 
            {
                //拠点が登録拠点か確認する
                if(tNdtWrHsCd.Text == this.noSectionName)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_001);
                    return;
                }

                //番号管理マスタデータを取得する
                NoMngSetAcs noMngSetAcs = new NoMngSetAcs();

                try
                {
                    ArrayList retNoMngSetList = new ArrayList();
                    ArrayList retNoTypeMngList = new ArrayList();
                    
                    int status = noMngSetAcs.Search(out retNoMngSetList, out retNoTypeMngList, enterPriseCd);

                    if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && retNoMngSetList == null)
                    {
                        this.ShowExclamation(MessageMng.ERR_MES_015 + status);
                        return;
                    }

                    //番号タイプ管理マスタの情報を格納します。
                    GetNoTypeSet(retNoTypeMngList);

                    //値をGuridにセットします。
                    this.SetDataToGrid(retNoMngSetList, tNdtWrHsCd.Text.Trim().PadLeft(secCodeLength,'0'));

                    //次のコントロールにフォーカスを遷移します。
                    tNdtAdd.Focus();
                    

                }
                catch(Exception ex)
                {
                    // エラーダイアログを表示します。
                    this.ShowError(String.Format(MessageMng.ERR_MES_004, ex.Message),
                                (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                }

            }
            else
            {
                //エラーメッセージを表示する
                this.ShowExclamation(MessageMng.ERR_MES_001);
                //フォーカスを拠点コードに戻す
                this.tNdtWrHsCd.Focus();
                
                return;
            }

        }


        /// <summary>
        /// 数値チェック処理
        /// </summary>
        /// <param name="tNEdit"></param>
        /// <returns>判定結果(true:非数値/false:数値)</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件指定した値が非数値であるかをチェックします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private bool IsNotNumber(TNedit tNEdit)
        {
            // 入力値がある場合のみチェックします。
            if (tNEdit.GetInt() == 0 && tNEdit.Text.Length == 0 &&
                !Regex.IsMatch(tNEdit.Text, this.regPttrnNum))
            {
                tNEdit.Focus();

                if(tNEdit == tNdtAdd)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_009);
                }
                else if(tNEdit == tNdtSub)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_010);
                }
                else
                {
                    this.ShowExclamation(MessageMng.ERR_MES_011);
                }

                return true;
            }

            return false;
        }

        #endregion

        #region -- コード変換関連 --

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に伝票番号を変換します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private void SlpNoConvert()
        {
            try
            {
                int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                //【番号増減値が指定されているかチェックをする】
                this.isCheckOK = this.CheckNoIncDec();

                //指定されていない場合は処理を終了する
                if (!isCheckOK)
                {
                    this.ShowExclamation(MessageMng.ERR_MES_003);
                    return;
                }
                
                //対象の拠点コードをセットする
                this.tgsectionCd = this.tNdtWrHsCd.Text.Trim().PadLeft(this.secCodeLength, '0');

                //指定されている場合は処理を続ける
                //処理開始前の確認メッセージを表示する
                //キャンセル：処理終了
                if (this.ShowInfo(MessageMng.INFO_MES_001) == DialogResult.Cancel)
                {
                    return;
                }

                #region【番号増減値の指定が正しいかチェックを行う】

                this.isCheckOK = false;
                
                this.isCheckOK = this.CheckSettingNo();
                //チェックの結果不正
                if(!isCheckOK)
                {
                    return;
                }

                #endregion

                #region【XMLからコード変換の対象となるテーブルを取得します】

                IDictionary<int, IList<SlpNoTargetTableListResult>> trgTblMap = new Dictionary<int, IList<SlpNoTargetTableListResult>>();
                int secDiv = 0;
                //拠点が指定されている場合
                if(this.tgsectionCd != "00" || this.tgsectionCd == "")
                {
                    secDiv = 1;
                }
                status = this.slipNoConvertAcs.GetTargetTableList(secDiv,trgTblMap);

                if(status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (status)
                    {
                        //不正データがある場合
                        case PMKHN05151UA.ILLEGAL_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_018;
                            break;

                        //データがない場合
                        case PMKHN05151UA.NO_DATA:
                            this.cnvErrMes = MessageMng.ERR_MES_017;
                            break;

                        //ファイルが存在しない場合
                        case PMKHN05151UA.NO_FILE:
                            this.cnvErrMes = MessageMng.ERR_MES_019;
                            break;

                    }

                    return;
                }

                #endregion

                //コード変換対象のデータをグリッドがら取得します
                IList<SlipNOConvertDispInfo> dispDataList = this.GetConvertDispData();

                #region【コード変換対象のデータのチェック処理を行います】

                bool check = false;
                //変換データList
                this.slipConvertDtList = new List<SlpNoConvertData>();
                //チェックエラーメッセ時用List
                IList <string> errList = new List<string>();

                foreach(SlipNOConvertDispInfo displist in dispDataList)
                {
                    //XMLデータの取得
                    IList<SlpNoTargetTableListResult> targetList = this.GetTargetTableList(displist.NoCode, trgTblMap);

                    //XMLリストがない場合は次の処理番号へ
                    if (targetList.Count != 0)
                    {
                        //変換データを作成・チェックを行う
                        foreach (SlpNoTargetTableListResult list in targetList)
                        {
                            SlpNoConvertData slipdtWork = new SlpNoConvertData();

                            #region//値をセットする

                            //番号コード(処理対象番号)
                            slipdtWork.NoCode = displist.NoCode;
                            //テーブルID(物理名)
                            slipdtWork.Table = list.TargetTable;
                            //テーブル名(論理名)
                            slipdtWork.TableName = list.TargetTableName;
                            //カラム名(物理名)
                            slipdtWork.Colum = list.TargetColum;
                            //カラム名(論理名)
                            slipdtWork.ColumName = list.TargetColumName;
                            //受注ステータスID
                            slipdtWork.AcptStatusId = list.TargetAcptStatusId;
                            //受注ステータスコード
//                            slipdtWork.AcptStatusId = list.TargetAcptStatusId;     2018/10/02
                            slipdtWork.AcptStatus = list.TargetAcptStatus;         //2018/10/02
                            //番号現在値
                            slipdtWork.NoPresentVal = displist.NoPresentVal;
                            //設定開始番号
                            slipdtWork.SettingStartNo = displist.SettingStartNo;
                            //設定終了番号
                            slipdtWork.SettingEndNo = displist.SettingEndNo;
                            //番号増減値
                            slipdtWork.NoIncDecWidth = displist.NoIncDecWidth;

                            #endregion

                            //変換の際、問題ないかチェック処理を行う
                            check = false;
                            status = slipNoConvertAcs.CheckCOnvertSlipNo(this.enterPriseCd, slipdtWork, out check);

                            //DBエラー処理
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.ShowExclamation(MessageMng.ERR_MES_020);
                                return;
                            }

                            //チェックに引っかかった場合
                            if (!check)
                            {
                                //リストに含まれているか確認する
                                if (!errList.Contains(Convert.ToString(noTypeMngMap[displist.NoCode])))
                                {
                                    //リストにAdd
                                    errList.Add(Convert.ToString(noTypeMngMap[displist.NoCode]));
                                }
                            }
                            else
                            {
                                //変更するデータを保持する
                                this.slipConvertDtList.Add(slipdtWork);
                            }
                        }
                    }
                }

                //チェック結果を確認
                if(errList.Count != 0)
                {
                    string errMg = "";

                    foreach(string st in errList)
                    {
                        if (errMg == "")
                        {
                            errMg = st;
                        }
                        else
                        {
                            errMg += "\r\n" + st;
                        }
                    }

                    this.ShowExclamation(MessageMng.ERR_MES_013 + errMg);
                    return;
                }

                #endregion

                // ログの保存先ディレクトリを作成します。
                this.CreateLogSaveDir();

                //変換処理を実施
                // プログレスダイアログを表示します。
                this.ShowProgressDlg(MessageMng.INFO_MES_002, MessageMng.INFO_MES_003, false);
                // コード変換処理をバックグラウンドで実行します。
                this.bgWrkr.RunWorkerAsync();

            }
             catch (Exception ex)
            {
                this.ShowError(String.Format(MessageMng.ERR_MES_021, ex.Message),
                    (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }

        }

        /// <summary>
        /// コンバート対象データ有無チェック処理
        /// </summary>
        /// <returns>true:対象有/false:対象無し</returns>
        /// <remarks>
        /// <br>Note       : グリッド内にコンバート対象となるデータが存在するかチェックします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private bool CheckNoIncDec()
        {
            // グリッドにデータが存在するか確認します。
            if (this.ultrGrid.Rows.Count != 0)
            {
                // グリッドにデータが有る場合、番号増減値列に入力値があるかどうかを確認します。
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    // 空ではないセルを発見したら処理を抜けます
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) && !this.IsCodeZero(row))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// コンバートNoの入力値チェック処理
        /// </summary>
        /// <returns>true:正常/false:問題あり</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象となるデータに設定されている番号減算値が問題ないかチェックします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private bool CheckSettingNo()
        {
            // グリッドにデータが存在するか確認します。
            if (this.ultrGrid.Rows.Count != 0)
            {
                //設定値確認処理
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) && !this.IsCodeZero(row))
                    {

                        //設定されている設定終了番号が最大値を超えないかチェックする
                        if (999999999 <= Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Text.Trim())
                            + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()))
                        {
                            this.SetFocusErrorCell(row, row.Cells[GridSettingInfo.COL_NO_NM].Text.Trim() + MessageMng.ERR_MES_006);
                            return false;
                        }

                        //UOE発注データの場合
                        if (Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO].Text.Trim()) == uoeNo &&
                            999999 <= Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Text.Trim()) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()))
                        {
                            this.SetFocusErrorCell(row, row.Cells[GridSettingInfo.COL_NO_NM].Text.Trim() + MessageMng.ERR_MES_007);
                            return false;
                        }

                        //設定されている設定開始番号がマイナス値にならないかチェックする
                        if (0 > Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ST].Text.Trim()) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()))
                        {
                            this.SetFocusErrorCell(row, row.Cells[GridSettingInfo.COL_NO_NM].Text.Trim() + MessageMng.ERR_MES_005);
                            return false;
                        }
                    }
                }

                return true;

            }
            //グリッドにデータが存在しない場合
            else
            {
                this.ShowExclamation(MessageMng.ERR_MES_003 + MessageMng.ERR_MES_012);
                return false;
            }
            
        }


        /// <summary>
        /// ステータスバー初期化処理
        /// </summary>
        /// <param name="cnvTrgTblCount">コード変換対象テーブルの件数</param>
        /// <remarks>
        /// <br>Note       : コンバート処理実行直前時にステータスバーの初期化を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/19</br>
        /// </remarks>
        private void InitStatusBar(int cnvTrgTblCount)
        {            
            // 画面の描画を一時停止します。
            this.SuspendLayout();

            // プログレスバーの初期化します。
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].Visible = true;
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS];
            // プログレスバーの最小値と最大値を設定します。
            pnl.ProgressBarInfo.Minimum = 0;
            pnl.ProgressBarInfo.Maximum = cnvTrgTblCount;
            pnl.ProgressBarInfo.Value = 0;
            pnl.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;

            // ステータス領域を初期化します。
            pnl = this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS];
            pnl.Text = MessageMng.INFO_MES_001;
            pnl.Appearance.ForeColor = Color.Black;

            // 画面の描画を再開します。
            this.ResumeLayout(false);
        }

        /// <summary>
        /// エラーセルフォーカスセット処理
        /// </summary>
        /// <param name="row">行データ</param>
        /// <param name="errMes">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 入力チェックでエラーが発生したセルにフォーカスをセットします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private void SetFocusErrorCell(UltraGridRow row, string errMes)
        {
            this.ultrGrid.Focus();
            row.Cells[GridSettingInfo.COL_NO_IDV].Activate();
            this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            this.ShowExclamation(errMes);
        }

        /// <summary>
        /// ログ保存先ディレクトリ作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログを保存するディレクトリが存在しない場合、ディレクトリの作成を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private void CreateLogSaveDir()
        {
            // ログ保存ディレクトリが存在するか確認し、無い場合はディレクトリを作成します。
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05151UA.LOG_DIR_PATH);
            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(dirInfo.FullName);
            }
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private DialogResult ShowExclamation(string mes)
        {
            // 警告メッセージを表示します
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_EXCLAMATION, MessageBoxButtons.OK, mes, 0);
        }

        /// <summary>
        /// インフォメッセージダイアログ表示処理(OK/Cancel)
        /// </summary>
        /// <param name="mes">表示するインフォメッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>Note       : 画面にインフォメッセージを表示します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06</br>
        /// </remarks>
        private DialogResult ShowInfo(string mes)
        {
            // インフォメッセージを表示します。
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_INFO, MessageBoxButtons.OKCancel, mes, 0);
        }

        /// <summary>
        /// インフォメッセージダイアログ表示処理(Yes/No/Cancel)
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        private DialogResult ShowInfo2(string mes)
        {
            // インフォメッセージを表示します。
            return this.ShowMessage(emErrorLevel.ERR_LEVEL_INFO, MessageBoxButtons.YesNoCancel, mes, 0);
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/12/15</br>
        /// </remarks>
        private DialogResult ShowMessage(emErrorLevel errLevel, MessageBoxButtons btn, string mes, int status)
        {
            return TMsgDisp.Show(errLevel, this.pgId, mes, status, btn);
        }

        #endregion

        #region -- その他 --

        /// <summary>
        /// 名称セット処理
        /// </summary>
        /// <param name="tNEdit">コード入力欄</param>
        /// <param name="tEdit">名称欄</param>
        /// <remarks>
        /// <br>Note       : コード入力欄で入力したコードに対応する名称を名称欄にセットします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void SetName(TNedit tNEdit, TEdit tEdit)
        {
            string sectionCd = tNEdit.Text.Trim();
            string sectionNm = this.GetSectionName(sectionCd);
            tEdit.Text = sectionNm;
            if (!String.IsNullOrEmpty(sectionCd))
            {
                tNEdit.Text = tNEdit.Text.Trim().PadLeft(this.secCodeLength, '0');
            }
        }

        /// <summary>
        /// フォーカス遷移時のアクティブセルフォーカスセット処理
        /// </summary>
        /// <param name="rowIndex">アクティブにしたい行番号</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーカス遷移時でグリッドがアクティブコントロールになった場合、指定した行番号の</br>
        /// <br>             変更後コード列のセルをアクティブにします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void SetFocusEditCellFromNoUltraGrid(int rowIndex, ChangeFocusEventArgs e)
        {
            // 次のコントロールがUltraGridの時のみ実施します。
            if (e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
            {
                e.NextCtrl = null;
                // UltraGridにフォーカスを当て、rowIndexで指定した行の変更後セルを
                // アクティブにします。
                this.ultrGrid.Focus();
                this.ultrGrid.Rows[rowIndex].Cells[GridSettingInfo.COL_NO_IDV].Activate();
                this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// グリッド内のフォーカス遷移時のアクティブセルフォーカスセット処理
        /// </summary>
        /// <param name="cmpRowIndex">比較したい行の行番号(先頭の場合は0、末尾の場合は行数-1)</param>
        /// <param name="nextCtrl">次に遷移するコントロール(拠点ガイドor一括設定ボタン)</param>
        /// <param name="gridAction">グリッドで実行したいアクション</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド内のフォーカス遷移時に次のセルをアクティブにします。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void SetFocusEeditCellInUltraGrid(int cmpRowIndex, Control nextCtrl,
            UltraGridAction gridAction, ChangeFocusEventArgs e)
        {
            // NextCtrlにnullをセットします
            e.NextCtrl = null;
            if (this.ultrGrid.ActiveCell.Row.Index == cmpRowIndex)
            {
                // NextCtrlに次に遷移したいコントロールをセットします
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10<</br>
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

        /// <summary>
        /// 一括設定入力欄初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 一括設定入力欄の初期化を行います。</br>
        /// <br>             Tagにそれぞれの入力欄がどの一括設定を表す列挙子を設定します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private void SetAllSettingTypeOnTNEdit()
        {

            // 加算
            this.tNdtAdd.Tag = AllSettingType.ADD;
            // 減算
            this.tNdtSub.Tag = AllSettingType.Multiplication;
            
        }

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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06<</br>
        /// </remarks>
        private void ultrEgbCllctvSttng_ExpandedStateChanged(object sender, EventArgs e)
        {
            // イベントソースをUltraExpandableGroupBoxに変換します
            UltraExpandableGroupBox edgGrpBox = sender as UltraExpandableGroupBox;
            // UltraExpandableGroupBoxの時のみ処理を実施します。
            if (edgGrpBox != null)
            {
                // 展開・縮小に応じてパネルのサイズを変更します
                Size pnlSize = new Size();
                pnlSize.Width = edgGrpBox.Parent.Size.Width;
                pnlSize.Height = edgGrpBox.Expanded ?
                    (this.egbGrpBoxHeighMap[(EgbGrpBoxType)edgGrpBox.Tag]) : this.egbGrpBoxCntrctSize;
                edgGrpBox.Parent.Size = pnlSize;
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void tArrwKyCntrl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
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
                            this.SetFocusEeditCellInUltraGrid(this.ultrGrid.Rows.Count - 1,
                                this.tNdtWrHsCd, UltraGridAction.NextCell, e);
                        }
                        else
                        {
                            // 前のセルをアクティブセルにします。
                            this.SetFocusEeditCellInUltraGrid(this.firstRow, this.ultrBtnSttng,
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
                        // 1行目の番号増減値をアクティブにします
                        this.ultrGrid.ActiveRow.Cells[GridSettingInfo.COL_NO_IDV].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
                else
                {
                    // 数値項目入力欄であれば、拠点コード入力欄にフォーカスをセット
                    if (e.NextCtrl is TNedit)
                    {
                        this.tNdtWrHsCd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtWrHsCd)
            {
                // 拠点コードを取得し値がある場合は、拠点名称をセットする
                this.SetName(this.tNdtWrHsCd, this.tEdtWrHsNm);

                //データ検索がされていなかったら検索する
                if (this.ultrGrid.Rows.Count == 0)
                {
                    //データを検索する
                    this.Search();
                }

                // フォーカスを制御します。
                if (e.ShiftKey && e.NextCtrl is UltraGrid && this.ultrGrid.Rows.Count != 0)
                {
                    e.NextCtrl = null;
                    this.ultrGrid.Focus();
                    this.ultrGrid.Rows[this.ultrGrid.Rows.Count - 1].Cells[GridSettingInfo.COL_NO_IDV].Activate();
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
            else if (e.PrevCtrl == this.ultrBtnSttng)
            {
                // グリッドの先頭行をアクティブなセルにします。
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    this.tNdtWrHsCd.Focus();
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
                        this.tNdtWrHsCd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtWrHsCd)
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
                                e.NextCtrl = this.tNdtSub;
                                break;
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        if (this.ultrGrid.Rows.Count != 0)
                        {
                            this.ultrGrid.Focus();
                            this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_NO_IDV].Activate();
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
                        this.tNdtSub.Focus();
                    }
                    else
                    {
                        this.tNdtWrHsCd.Focus();
                    }
                }
            }
            else if (e.PrevCtrl == this.tNdtSub)
            {
                if (!e.ShiftKey && e.Key == Keys.Left)
                {
                    e.NextCtrl = this.ultrRbtnCllctvSttng;
                    this.ultrRbtnCllctvSttng.FocusedIndex = Convert.ToInt32(AllSettingType.Multiplication);
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Up)
                {
                    e.NextCtrl = null;
                    if (this.ultrGrid.Rows.Count != 0)
                    {
                        this.ultrGrid.Focus();
                        this.ultrGrid.Rows[0].Cells[GridSettingInfo.COL_NO_IDV].Activate();
                        this.ultrGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.tNdtAdd.Focus();
                    }
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06<</br>
        /// </remarks>
        private void ultrGrid_KeyDown(object sender, KeyEventArgs e)
        {
            // セルがアクティブ状態で、且つ編集モードのときにのみ処理を行います
            if (this.ultrGrid.ActiveCell != null && this.ultrGrid.ActiveCell.IsInEditMode)
            {
                int activeRowIndex = this.ultrGrid.ActiveCell.Row.Index;
                int activeColIndex = this.ultrGrid.ActiveCell.Column.Index;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        // 次のセル、またはコントロールにフォーカスをセットします。
                        this.SetFocusEditCellOnKeyDown(this.firstRow, this.ultrBtnSttng, UltraGridAction.AboveCell, e);
                        break;
                    case Keys.Down:
                        // 前のセル、またはコントロールにフォーカスをセットします。
                        this.SetFocusEditCellOnKeyDown(this.ultrGrid.Rows.Count - 1, null,
                            UltraGridAction.BelowCell, e);
                        break;
                    default:
                        break;
                }
            }
        }        

        #endregion

        #region -- グリッド関連 --

        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: Gridアクション処理後に発生するイベントです。</br>
        /// <br>Programmer	: 39175  倉内</br>
        /// <br>Date		: 2018/09/15</br>
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

        #region  -- スレッド関連 --

        /// <summary>
        /// バックグランドのイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : バックグラウンドで処理を実行するときにイベントが発生します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void bgWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                //【変換処理を行う】

                // ステータスバーを初期化します。
                this.Invoke(new InitStatusBarDelegate(this.InitStatusBar), this.slipConvertDtList.Count);

                // テーブル単位でコードの変換を実施します。
                int index = 0;
                long prcssngCnt;
                long ttlPrcssngCnt = 0;
                int maxlist = slipConvertDtList.Count;

                // ログを出力します。
                using (FileStream fs = new FileStream(this.CreateLogFilePath(), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //操作履歴ログに同様の内容を出力していきます。
                        OperationHistoryLog opLog = new OperationHistoryLog();
                        string pgid = "PMKHN05150U";
                        string pgnm = "伝票番号変換";

                        // 総処理時間を計測するStopwatch
                        Stopwatch totalProcessingTime = new Stopwatch();
                        // 個別のテーブルの処理時間を計測するStopwatch
                        Stopwatch processingTime = new Stopwatch();

                        sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_START, new string[0]));
                        opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_START + "【" + tEdtWrHsNm.Text.ToString() + "】", new String[0]), "");

                        // 総合処理時間の計測開始します。
                        totalProcessingTime.Start();

                        foreach (SlpNoConvertData target in this.slipConvertDtList)
                        {
                            prcssngCnt = 0;
                            //コード変換前にステータスバーを更新します
                            Invoke(new UpdateStatusBarDelegate(this.UpdateStatusBar),
                                String.Format(MessageMng.INFO_MES_004, this.noTypeMngMap[target.NoCode], index, maxlist));

                            //個別の時間を計測
                            processingTime.Start();

                            //コード変換処理を実施します
                            status = this.slipNoConvertAcs.SlipNoConvert(this.enterPriseCd, target, ref prcssngCnt);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_ERROR, new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName + ",増減値：" + target.NoIncDecWidth }));
                                opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0, this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_ERROR, new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName }), "");
                                e.Cancel = true;
                                break;
                            }

                            processingTime.Stop();
                            ttlPrcssngCnt += prcssngCnt;

                            // 個々の処理件数、処理時間をログに出力します。
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName + ",増減値：" + target.NoIncDecWidth, prcssngCnt.ToString(), 
                                    new DateTime (0).Add(processingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME) }));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_CASE_BY_BASE,
                                new string[] { this.noTypeMngMap[target.NoCode] + " " + target.TableName + ",増減値：" + target.NoIncDecWidth, prcssngCnt.ToString(), 
                                    new DateTime (0).Add(processingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME) }), "");

                            // 変換終了後もステータスバーを更新します。
                            this.bgWrkr.ReportProgress(++index,
                                String.Format(MessageMng.INFO_MES_004, target.TableName, index, maxlist));

                            // 個別テーブルの処理時間を計測するStopwatchをリセットします。
                            processingTime.Reset();

                        }
                        totalProcessingTime.Stop();

                        //【総処理件数をログに出力】
                        if (!e.Cancel)
                        {
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME),
                                    ttlPrcssngCnt.ToString() }));
                            sw.WriteLine(this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_END, new String[0]));
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_TOTAL,
                                new string[] { new DateTime(0).Add(totalProcessingTime.Elapsed).ToString(PMKHN05151UA.LOG_FORMAT_PROCESSING_TIME),
                                    ttlPrcssngCnt.ToString() }), "");
                            opLog.WriteOperationLog(this, LogDataKind.OperationLog, pgid, pgnm, "", 0, 0,
                                this.GenerateLogFormat(PMKHN05151UA.LOG_FORMAT_END, new String[0]), "");



                            //【番号管理設定マスタの更新処理】
                            NoMngSetAcs noMgSetAcs = new NoMngSetAcs();
                            ArrayList noMgArryList = new ArrayList();

                            //登録するデータをセットする
                            foreach (UltraGridRow row in this.ultrGrid.Rows)
                            {
                                // 番号増減値から値を取得し、値が無い場合は次の行へ
                                if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) ||
                                        this.IsCodeZero(row))
                                {
                                    continue;
                                }

                                NoMngSet noMgWork = GetnoMgWork(row);                              

                                noMgArryList.Add(noMgWork);
                            }

                            status = noMgSetAcs.Write(ref noMgArryList);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.ShowExclamation(MessageMng.ERR_MES_014 + status);
                                return;
                            }

                            //【画面を初期化し、番号管理情報を表示する】
                            ArrayList retNoMngSetList = new ArrayList();
                            ArrayList retNoTypeMngList = new ArrayList();

                            status = noMgSetAcs.Search(out retNoMngSetList, out retNoTypeMngList, enterPriseCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && retNoMngSetList == null)
                            {
                                this.ShowExclamation(MessageMng.ERR_MES_015 + status);
                                return;
                            }

                            //値をGuridにセットします。
                            this.SetDataToGrid(retNoMngSetList, tNdtWrHsCd.Text.Trim().PadLeft(secCodeLength,'0'));
                            //次のコントロールにフォーカスを遷移します。
                            tNdtAdd.Focus();
                        }
                    }

                }


            }
            catch(Exception ex)
            {
                this.cnvErrMes = ex.Message;
                e.Cancel = true;
            }

        }

        /// <summary>
        /// NS集計ツール起動
        /// </summary>
        /// <param name="exeName">PG名称</param>
        /// <remarks>
        /// <br>Note       : 利用されたことをお知らせするNS集計プログラムを起動します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/27<</br>
        /// </remarks>
        private void NsToolLogLoad(string exeName)
        {
            try
            {
                // 起動するPG名を指定します。
                string wkPg = ".\\" + "NsToologUploader.exe";

                // PGを起動します。
                // ただし、PGが存在しなかったら何もしないで、ここの処理は中断します。
                if (System.IO.File.Exists(wkPg.ToString()))
                {
                    // ありました。
                    // このまま続けましょう。
                }
                else
                {
                    // PG起動はあきらめます。
                    return;
                }

                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                // 起動するPGをセットします。
                startInfo.FileName = wkPg.ToString();

                // 引数をセットします。
                startInfo.Arguments = exeName.ToString();

                // PGを別プロセスとして起動
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(startInfo);

            }
            catch
            {
                //エラーがでてもスルーする
                return;
            }
            
        }

        /// <summary>
        /// 番号管理マスタの更新内容を設定します
        /// </summary>
        /// <param name="row">画面DataGridの明細データ</param>
        /// <returns>番号管理マスタ更新データ</returns>
        /// <remarks>
        /// <br>Note       : 番号管理マスタの更新内容を設定します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/9<</br>
        /// </remarks>
        private NoMngSet GetnoMgWork(UltraGridRow row)
        {
            NoMngSet noMgSet = new NoMngSet();

            foreach (NoMngSet noMgWork in this.noMgSetWork)
            {
                if (noMgWork.NoCode == Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO].Value))
                {
                    //番号現在値
                    noMgWork.NoPresentVal = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);
                    //設定開始番号
                    noMgWork.SettingStartNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ST].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);

                    //設定終了番号
                    switch (noMgWork.NoCode)
                    {

                        case uoeNo:
                            if (999999 == Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value))
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value);
                            }
                            else
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);
                            }
                            break;

                        default:
                            if (999999999 == Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value))
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value);
                            }
                            else
                            {
                                noMgWork.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value) + Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);
                            }
                            break;
                    }

                    noMgSet = noMgWork;
                    break;
                }
            }

            return noMgSet;
 
        }


        /// <summary>
        /// コード変換対象データ取得処理
        /// </summary>
        /// <returns>コード変換対象のデータのリスト</returns>
        /// <remarks>
        /// <br>Note       : コード変換の対象となっているデータをグリッドから取得します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/11<</br>
        /// </remarks>
        private IList<SlipNOConvertDispInfo> GetConvertDispData()
        {
            //コード変換対象のデータをグリッドから取得します
            IList<SlipNOConvertDispInfo> dispDataList = new List<SlipNOConvertDispInfo>(this.ultrGrid.Rows.Count);

            foreach (UltraGridRow row in this.ultrGrid.Rows)
            {
                // 番号増減値から値を取得し、値が無い場合は次の行へ
                if (String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) ||
                        this.IsCodeZero(row))
                {
                    continue;
                }
                
                //更新条件を保存します。
                SlipNOConvertDispInfo dispData = new SlipNOConvertDispInfo();

                //番号コード(処理対象番号)
                dispData.NoCode = Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO].Value);
                //番号コード名称(処理対象番号)
                dispData.NoCodeName = Convert.ToString(row.Cells[GridSettingInfo.COL_NO_NM].Value);
                //番号現在値
                dispData.NoPresentVal = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_PT].Value);
                //設定開始番号
                dispData.SettingStartNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ST].Value);
                //設定終了番号
                dispData.SettingEndNo = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_ED].Value);
                //番号増減値
                dispData.NoIncDecWidth = Convert.ToInt64(row.Cells[GridSettingInfo.COL_NO_IDV].Value);

                dispDataList.Add(dispData);
            }

            return dispDataList;
        }

        /// <summary>
        /// 変換テーブル情報取得処理
        /// </summary>
        /// <param name="no">番号コード(処理対象番号)</param>
        /// <returns>変換テーブル情報のリスト</returns>
        /// <remarks>
        /// <br>Note       : 変換対象のテーブル情報を保持しているXMLデータから取得します</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/11<</br>
        /// </remarks>
        private IList<SlpNoTargetTableListResult> GetTargetTableList(int no,IDictionary<int, IList<SlpNoTargetTableListResult>> trgTblMap)
        {
            //初期化
            IList<SlpNoTargetTableListResult> targetList = new List<SlpNoTargetTableListResult>();

            //XMLデータに番号コードのデータがあるかチェックする
            if(!trgTblMap.ContainsKey(no))
            {
                return targetList;
            }

            //取得した番号コード（処理対象番号）のリストを作成する
            foreach(SlpNoTargetTableListResult work in trgTblMap[no])
            {
                targetList.Add (work);
            }

            return targetList;
        }

        /// <summary>
        /// ログファイルパス作成処理
        /// </summary>
        /// <returns>ログファイルの絶対パス</returns>
        /// <remarks>
        /// <br>Note       : ログファイルの絶対パスを作成します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14<</br>
        /// </remarks>
        private string CreateLogFilePath()
        {
            // ディレクトリ情報を作成
            DirectoryInfo dirInfo = new DirectoryInfo(PMKHN05151UA.LOG_DIR_PATH);
            // ログファイル名を作成
            string fileName = String.Format(PMKHN05151UA.LOG_FILE_NAME, 
                DateTime.Now.ToString(PMKHN05151UA.LOG_FORMAT_DATE));

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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/15<</br>
        /// </remarks>
        private string GenerateLogFormat(string format, string[] prms)
        {
            List<string> prmList = new List<string>();
            prmList.Add(DateTime.Now.ToString(PMKHN05151UA.DATE_FORMAT));
            foreach (string prm in prms)
            {
                prmList.Add(prm);
            }

            return String.Format(format, prmList.ToArray());
        }
        /// <summary>
        /// 番号増減値判定処理(0チェック)
        /// </summary>
        /// <param name="row">行データ</param>
        /// <returns>true:0/false:非0</returns>
        /// <remarks>
        /// <br>Note       : 番号増減値が0であるか否かを判定します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/06<</br>
        /// </remarks>
        private bool IsCodeZero(UltraGridRow row)
        {
            return Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO_IDV].Text.Trim()) == 0 ?
                true : false;
        }

        /// <summary>
        /// ステータスバー更新処理
        /// </summary>
        /// <param name="mes">メッセージ</param>
        /// <remarks>
        /// <br>Note       : ステータスバーを更新するためのデリゲート。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14<</br>
        /// </remarks>
        private void UpdateStatusBar(string mes)
        {
            this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = mes;
        }

        /// <summary>
        /// ReportProgressイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ReportProgressメソッドをコールした時にイベントが発生します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14<</br>
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
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14<</br>
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
                    // ステータスバーの更新
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_007;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Appearance.ForeColor = Color.Red;
                    // エラーメッセージを表示
                    string errMes = String.IsNullOrEmpty(this.cnvErrMes) ? MessageMng.ERR_MES_016: this.cnvErrMes;
                    this.ShowError(errMes, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    this.cnvErrMes = String.Empty;
                }
                else
                {
                    // ステータスバーを更新
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Value =
                        this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_PROGRESS].ProgressBarInfo.Maximum;
                    this.ultrSttsBar.Panels[StatusKeyType.STTS_KEY_STATUS].Text = MessageMng.INFO_MES_006;

                    // 成功時はメモリに格納している更新データをクリアします
                    this.slipConvertDtList.Clear();

                    // 処理成功判定フラグをonにします。
                    isSuccess = true;

                    // 更新済みフラグをonにします
                    this.isUpdate = true;

                    // 編集済みフラグをoffにします
                    this.isEdit = false;
                }
            }
            catch (Exception ex)
            {
                // プログレスダイアログを終了します。
                this.procDlg.Close();
                this.ShowError(String.Format(MessageMng.ERR_MES_022, ex.Message), (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            }
            finally
            {                
                // 処理成功時は、登録完了ダイアログを表示します。
                if (isSuccess)
                {
                    // 登録完了ダイアログを表示します
                    using (SaveCompletionDialog dlg = new SaveCompletionDialog())
                    {
                        dlg.ShowDialog(2);
                    }

                    //-------2018.09.27 NSツール集計プログラム追加　倉内　Start---------------------------------------------------------------------//

                    string exeName = "PMKHN05150U.exe";
                    this.NsToolLogLoad(exeName);

                    //-------2018.09.27 NSツール集計プログラム追加　倉内　End-----------------------------------------------------------------------//

                }

                // FormCloingイベントからコールされた場合は、フォームを閉じます
                if (isSuccess && this.isCallFormCloseingEvent)
                {
                    ((Form)this.Parent).Close();
                }


            }
        }

        /// <summary>
        /// プログレスダイアログ表示処理
        /// </summary>
        /// <param name="mess">メッセージ</param>
        /// <param name="title">ダイアログタイトル</param>
        /// <param name="canCancel">キャンセルの可否(true:キャンセル可能/false:キャンセル不可)</param>
        /// <remarks>
        /// <br>Note       : プログレスダイアログを表示します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/14<</br>
        /// </remarks>
        private void ShowProgressDlg(string title, string mess, bool canCancel)
        {
            // プログレスダイアログを表示します。
            if (this.procDlg == null)
            {
                this.procDlg = new SFCMN00299CA();
            }
            // ダイアログのタイトルを設定します
            this.procDlg.Title = title;
            // ダイアログに表示するメッセージを設定します。
            this.procDlg.Message = mess;
            // キャンセルボタンの有無
            this.procDlg.DispCancelButton = canCancel;

            // プログレスダイアログを表示します。            
            this.procDlg.Show(this);
        }

        #endregion

        #region -- その他 --

        /// <summary>
        /// フォーム初回表示時のイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを初回表示したときにイベントが発生します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void PMKHN05131UA_Shown(object sender, EventArgs e)
        {
            // 拠点ガイド入力にフォーカスをセット
            this.tNdtWrHsCd.Focus();
        }

        /// <summary>
        /// 拠点ガイドボタンイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンをクリックするとイベントが発生します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            // 拠点ガイドを起動
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            bool isMainOffice = false;
            int status = secInfoSetAcs.ExecuteGuid(this.enterPriseCd, isMainOffice, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSet != null)
            {
                // 値を入力欄にセットします。
                this.tNdtWrHsCd.DataText = secInfoSet.SectionCode.Trim().PadLeft(secCodeLength,'0');
                this.tEdtWrHsNm.DataText = secInfoSet.SectionGuideNm.Trim();
                // 次のコントロールにフォーカスを遷移します。
                tNdtAdd.Focus();

                //データを検索しセットする
                this.Search();
            }
        }

        /// <summary>
        /// ツールメニュークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ツールメニューをクリックするとイベントが発生します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void tTooBarMain_ToolClick(object sender, ToolClickEventArgs e)
        {
            // フォーカスを先頭に戻します。
            this.tNdtWrHsCd.Focus();

            // クリックしたメニューによって処理を分岐
            switch (e.Tool.Key)
            {
                // 終了
                case ToolMenuType.BTN_TOOL_CLOSE:
                　　//更新データがあるか確認しある場合はメッセージを出す！
                    //【番号増減値が指定されているかチェックをする】
                    this.isCheckOK = this.CheckNoIncDec();
                    if (isCheckOK)
                    {
                        DialogResult dlr = this.ShowInfo2(MessageMng.INFO_MES_008);

                        if(dlr == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (dlr == DialogResult.Yes)
                        {
                            this.SlpNoConvert();
                            return;
                        }
                        else
                        {
                            ((Form)this.Parent).Close();
                            break;
                        }

                    }
                    else
                    {
                        ((Form)this.Parent).Close();
                        break;
                    }

                // 実行
                case ToolMenuType.BTN_TOOL_EXEC:
                    this.SlpNoConvert();
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
        /// 一括設定区分を変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 一括設定区分を変更時の処理です。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/11</br>
        /// </remarks>
        private void ultrRbtnCllctvSttng_ValueChanged(object sender, EventArgs e)
        {
            AllSettingType type = (AllSettingType)Enum.ToObject(typeof(AllSettingType), Convert.ToInt32(this.ultrRbtnCllctvSttng.Value));

            switch (type)
            {
                //加算
                case AllSettingType.ADD:
                    tNdtSub.Text = "";
                    tNdtSub.Enabled = false;
                    tNdtAdd.Enabled = true;
                    break;

                //減算
                case AllSettingType.Multiplication:
                    tNdtAdd.Text = "";
                    tNdtSub.Enabled = true;
                    tNdtAdd.Enabled = false;

                    break;
            }

        }

        /// <summary>
        /// 拠点コードが変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 拠点コードが変更された際の処理</br>
        /// <br>Programmer : 30175 倉内/br>
        /// <br>Date       : 2018/09/20</br>
        /// </remarks>
        private void tNdtWrHsCd_ValueChanged(object sender, EventArgs e)
        {
            // 拠点コードを取得し値がある場合は、拠点名称をセットする
            this.SetName(this.tNdtWrHsCd, this.tEdtWrHsNm);

            //データを検索しセットする
            this.Search();

            // ステータスバーを初期状態に戻します。
            this.InitStatusBar();


        }

        /// <summary>
        /// 一括設定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 一括設定ボタンをクリックするとイベントが発生します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/10<</br>
        /// </remarks>
        private void ultrBtnSttng_Click(object sender, EventArgs e)
        {

            // 一括設定のタイプ
            AllSettingType type = (AllSettingType)Enum.ToObject(typeof(AllSettingType), Convert.ToInt32(this.ultrRbtnCllctvSttng.Value));
            bool bl = false;
            
            // グリッドのデータ
            DataTable tbl = ((DataView)this.ultrGrid.DataSource).Table;

            //値が入力されているかチェックを行う
            switch(type)
            {
                //【加算を選択時】
                case AllSettingType.ADD:

                    //チェックを行う
                    bl = this.IsNotNumber(tNdtAdd);

                    //値が入力されていない場合
                    if(bl)
                    {
                        break;
                    }

                    //各行に値をセットする
                    foreach(DataRow row in tbl.Rows)
                    {
                        row[GridSettingInfo.COL_NO_IDV] = Convert.ToInt64(tNdtAdd.Text);
                    }
                    
                    break;


                //【減算を選択時】
                case AllSettingType.Multiplication:

                    //チェックを行う
                    bl = this.IsNotNumber(tNdtSub);
                    
                　　//値が入力されていない場合
                    if(bl)
                    {
                        break;
                    }

                    //各行に値をセットする
                    foreach(DataRow row in tbl.Rows)
                    {
                        row[GridSettingInfo.COL_NO_IDV] = Convert.ToInt64(tNdtSub.Text) * -1;
                    }
                    
                    break;

            }
            
        }

        /// <summary>
        /// 画面終了時の処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面を終了するときにイベントが発生します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15<</br>
        /// </remarks>
        public void PMKHN05151UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 編集済みフラグがonの時のみ処理を行います。
            if (this.isEdit)
            {
                // フォーカスを先頭に戻します。
                this.tNdtWrHsCd.Focus();

                // 変更後の番号増減列で入力されているセルの数を数えます
                int editedCount = 0;
                foreach (UltraGridRow row in this.ultrGrid.Rows)
                {
                    if (!String.IsNullOrEmpty(row.Cells[GridSettingInfo.COL_NO_IDV].Text) &&
                        Convert.ToInt32(row.Cells[GridSettingInfo.COL_NO_IDV].Value) != 0)
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
                        MessageMng.INFO_MES_005, 0, MessageBoxButtons.YesNoCancel);

                    // DialogResultの結果に応じて処理を分岐させます
                    if (result == DialogResult.Yes)
                    {
                        // closeイベントをキャンセルします
                        e.Cancel = true;
                        // FormCloseingイベントからコード変換を実行するのでフラグをonにします。
                        this.isCallFormCloseingEvent = true;
                        // OKを押下した時は、登録を実施してから終了します。
                        this.SlpNoConvert();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // キャンセルを押下した時は、終了処理をキャンセルします。
                        e.Cancel = true;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region -- 列挙体 --

        /// <summary>
        /// UltraExpandableGroupBoxのタイプを表す列挙子
        /// </summary>
        private enum EgbGrpBoxType
        {
            // 抽出条件用
            Conditon,
            // 一括設定用
            CollectiveSetting
        }


        /// <summary>
        /// 一括設定のタイプを表す列挙子
        /// </summary>
        private enum AllSettingType
        {
            /// <summary>加算</summary>
            ADD,
            /// <summary>減算</summary>
            Multiplication,
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

        /// <summary>
        /// PM.NS伝票番号変換処理ツール　グリッドの固定設定情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの固定設定情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/04</br>
        /// </remarks>
        private class GridSettingInfo
        {
            #region -- Constractor --

            /// <summary>
            /// PM.NS伝票番号変換処理ツール　グリッドの固定設定情報を保存した内部クラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : PM.NS伝票番号変換処理ツール、グリッドの固定設定情報を保存した内部クラスの初期処理を行います。</br>
            /// <br>Programmer : 30175 倉内</br>
            /// <br>Date       : 2018/09/04</br>
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

            /// <summary>番号</summary>
            public const string COL_NO = "番号";
            /// <summary>番号名</summary>
            public const string COL_NO_NM = "番号名";
            /// <summary>番号現在値</summary>
            public const string COL_NO_PT = "番号現在値";
            /// <summary>設定開始番号</summary>
            public const string COL_NO_ST = "設定開始番号";
            /// <summary>設定終了番号</summary>
            public const string COL_NO_ED = "設定終了番号";
            /// <summary>番号増減値</summary>
            public const string COL_NO_IDV = "番号増減値";
            /// <summary>番号増減幅</summary>
            public const string COL_NO_IDW = "番号増減幅";

            #endregion

            #region -- 列幅 --

            /// <summary>番号名列の列幅</summary>
            public const int COL_NO_NM_WIDTH = 350;
            /// <summary>番号現在値列の列幅</summary>
            public const int COL_NO_PT_WIDTH = 110;
            /// <summary>設定開始番号列の列幅</summary>
            public const int COL_NO_ST_WIDTH = 110;
            /// <summary>設定終了番号列の列幅</summary>
            public const int COL_NO_ED_WIDTH = 110;
            /// <summary>番号増減値列の列幅</summary>
            public const int COL_NO_IDV_WIDTH = 110;

            #endregion

            #endregion
        }

        /// <summary>
        /// PM.NS伝票番号変換処理ツール　メニューの情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールメニューの情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
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
        ///  PM.NS伝票番号変換処理ツール　ステータスバーの情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ステータスバーの情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
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

        /// <summary>
        /// PM.NS伝票番号変換処理ツール　メッセージ情報を保存した内部クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : メッセージ情報を保存した内部クラスです。</br>
        /// <br>Programmer : 30175 倉内/br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        private class MessageMng
        {
            #region -- エラーメッセージ --

            /// <summary>ERR_MES_001:拠点コードが指定されていません。</summary>
            public const string ERR_MES_001 = "拠点コードが指定されていません。";
            /// <summary>ERR_MES_002:データの取得に失敗しました。\r\n詳細\r\n{0}</summary>
            public const string ERR_MES_002= "データの取得に失敗しました。\r\n詳細\r\n{0}";
            /// <summary>ERR_MES_003:番号増減値が指定されていません。</summary>
            public const string ERR_MES_003 = "番号増減値が指定されていません。";
            /// <summary>ERR_MES_004:検索処理に失敗しました。\r\n詳細\r\n{0}</summary>
            public const string ERR_MES_004 = "検索処理に失敗しました。\r\n詳細\r\n{0}";
            /// <summary>ERR_MES_005:がマイナス値になってしまいます。</summary>
            public const string ERR_MES_005 = "がマイナス値になってしまいます。";
            /// <summary>ERR_MES_006:が最大値「999999999」を超えています。</summary>
            public const string ERR_MES_006 = "が最大値「999999999」を超えています。";
            /// <summary>ERR_MES_007:が最大値「999999」を超えています。</summary>
            public const string ERR_MES_007 = "が最大値「999999」を超えています。";
            /// <summary>ERR_MES_008:が最大値「99999999」を超えています。</summary>
            public const string ERR_MES_008 = "が最大値「99999999」を超えています。";
            /// <summary>ERR_MES_009:加算する数値が指定されていません。</summary>
            public const string ERR_MES_009 = "加算する数値が指定されていません。";
            /// <summary>ERR_MES_010:減算する数値が指定されていません。</summary>
            public const string ERR_MES_010 = "減算する数値が指定されていません。";
            /// <summary>ERR_MES_011:数値が指定されていません。</summary>
            public const string ERR_MES_011 = "数値ではない値が入力されています。";
            /// <summary>ERR_MES_012:「検索」を実施し再度処理を行ってください。</summary>
            public const string ERR_MES_012 = "\r\n「検索」を実施し再度処理を行ってください。";
            /// <summary>ERR_MES_013:既に、再設定後の番号が存在します。</summary>
            public const string ERR_MES_013 = "既に、再設定後の番号が存在します。\r\n";
            /// <summary>ERR_MES_014:番号管理マスタの登録に失敗しました。st="</summary>
            public const string ERR_MES_014 = "番号管理マスタの登録に失敗しました。st=";
            /// <summary>ERR_MES_015:番号管理マスタの取得に失敗しました。st=</summary>
            public const string ERR_MES_015 = "番号管理マスタの取得に失敗しました。st=";
            /// <summary>ERR_MES_016:伝票番号変換処理に失敗しました。</summary>
            public const string ERR_MES_016 = "伝票番号変換処理に失敗しました。";
            /// <summary>ERR_MES_017:伝票番号変換対象ファイルに対象となるテーブルがありません。\r\nファイル内容を見直してください。</summary>
            public const string ERR_MES_017 = "伝票番号変換対象ファイルに対象となるテーブルがありません。\r\nファイル内容を見直してください。";
            /// <summary>ERR_MES_018:伝票番号変換対象ファイルに不正なデータが有ります。\r\nファイルの内容を見直してください。</summary>
            public const string ERR_MES_018 = "伝票番号変換対象ファイルに不正なデータが有ります。\r\nファイルの内容を見直してください。";
            /// <summary>ERR_MES_019:伝票番号変換対象ファイルがありません。</summary>
            public const string ERR_MES_019 = "伝票番号変換対象ファイルがありません。";
            /// <summary>ERR_MES_020:伝票番号変換 チェック処理に失敗しました。</summary>
            public const string ERR_MES_020 = "伝票番号変換 チェック処理に失敗しました。";
            /// <summary>ERR_MES_021:伝票番号変換 チェック処理に失敗しました。\r\n詳細\r\n{0}</summary>
            public const string ERR_MES_021 = "伝票番号変換 チェック処理に失敗しました。\r\n詳細\r\n{0}";
            /// <summary>ERR_MES_022:伝票番号変換処理に失敗しました。\r\n詳細\r\n{0}</summary>
            public const string ERR_MES_022 = "伝票番号変換処理に失敗しました。\r\n詳細\r\n{0}";
            /// <summary>ERR_MES_023:の変換対象ファイルがありません。\r\n番号管理設定のみ更新を行います。</summary>
            public const string ERR_MES_023 = "の変換対象ファイルがありません。\r\n番号管理設定のみ更新を行います。";

            #endregion

            #region -- インフォメッセージ --

            /// <summary>INFO_MES_001:処理を開始してもよろしいですか？</summary>
            public const string INFO_MES_001 = "処理を開始してもよろしいですか？";
            /// <summary>INFO_MES_002:伝票番号変換処理</summary>
            public const string INFO_MES_002 = "伝票番号変換処理";
            /// <summary>INFO_MES_003:現在、番号変換処理中です。\r\nしばらくお待ちください</summary>
            public const string INFO_MES_003 = "現在、番号変換処理中です。\r\nしばらくお待ちください";
            /// <summary>INFO_MES_004:コード：コード：{0}を変換中... {1}/{2}件</summary>
            public const string INFO_MES_004 = "{0}を変換中... {1}/{2}件";
            /// <summary>INFO_MES_005:編集中のデータ存在します。\r\nコード変換処理を実行しますか？</summary>
            public const string INFO_MES_005 = "編集中のデータ存在します。\r\n伝票番号変換処理を実行しますか？";
            /// <summary>INFO_MES_006:コード変換完了</summary>
            public const string INFO_MES_006 = "コード変換完了";
            /// <summary>INFO_MES_007:エラー</summary>
            public const string INFO_MES_007 = "エラー";
            /// <summary>INFO_MES_008:編集中のデータが存在します。伝票番号換処理を実行しますか？</summary>
            public const string INFO_MES_008 = "編集中のデータが存在します。伝票番号換処理を実行しますか？";
            
            #endregion
        }

        #endregion

        
       
    }
}