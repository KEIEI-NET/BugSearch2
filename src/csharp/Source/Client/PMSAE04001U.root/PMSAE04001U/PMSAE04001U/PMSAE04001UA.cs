//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示 
// プログラム概要   : 送信ログ表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhaimm
// 作 成 日  2013/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信ログ表示UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 送信ログ表示UIフォームクラス</br>
    /// <br>Programmer  : zhaimm</br>
    /// <br>Date        : 2013/06/26</br>
    /// </remarks>
    public partial class PMSAE04001UA : Form
    {
        #region ■ Private Members ■
        // 送信ログデータテーブル
        private SAndESalSndLogListResultDataSet.SAndESalSndLogListResultDataTable _sAndESalSndLogListResultDataTable;
        // 送信ログアクセスクラス
        private SAndESalSndLogListResultAcs _sAndESalSndLogListResultAcs;
        /// <summary>SFKTN09002A)拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        //日付取得部品
        private DateGetAcs _dateGet;
        /// <summary>列表示状態コレクションクラス</summary>
        private SAndESalSndLogListResultColDisplayStatusCollection _colDisplayStatusCollection = null;
        private ControlScreenSkin _controlScreenSkin;
        // エラー項目
        private Control _errCtrol = null;
        // 終了
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        // 検索			
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        // ログ初期化			
        private const string TOOLBAR_LOGRESETBUTTON_KEY = "ButtonTool_LogReset";
        // クリア			
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        // ログイン担当者タイトル
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";
        // ログイン担当者名称			
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";		     
        // アセンブリID
        private const string CT_PGID = "PMSAE04001U";
        // 列表示状態セッティングファイル名
        private const string CT_FILENAME_COLDISPLAYSTATUS = "PMSAE04001U_ColSetting.DAT";
        /// <summary>チェック時メッセージ「送信日(開始)の入力が不正です。」</summary>
        private const string MSG_ST_SENDDATETIME_ERROR = "送信日(開始)の入力が不正です。";
        /// <summary>チェック時メッセージ「送信日(終了)の入力が不正です。」</summary>
        private const string MSG_ED_SENDDATETIME_ERROR = "送信日(終了)の入力が不正です。";
        /// <summary>チェック時メッセージ「送信日の範囲がが不正です」</summary>
        private const string MSG_REVERSE_SENDDATETIME_ERROR = "送信日の入力範囲が不正です。";
        private const string CT_SANDEAUTOSENDDIV0AND1 = "全て";
        private const string CT_SANDEAUTOSENDDIV0 = "手動";
        private const string CT_SANDEAUTOSENDDIV1 = "自動";
        private const int CT_MAXSEARCHCT = 5000; //抽出最大件数設定(「0」は制限しない)
        #region < グリッド列用 >
        /// <summary>売上データ送信ログテーブル</summary>
        private const string CT_TBL_TITLE = "SAndESalSndLogListResult";
        /// <summary>拠点コード</summary>
        public const string CT_SECTIONCODE = "SectionCode";
        /// <summary>拠点名称</summary>
        public const string CT_SECTIONNAME = "SectionName";
        /// <summary>自動送信区分コード</summary>
        public const string CT_SANDEAUTOSENDDIV = "SAndEAutoSendDiv";
        /// <summary>自動送信区分名称</summary>
        public const string CT_SANDEAUTOSENDDIVNAME = "SAndEAutoSendDivName";
        /// <summary>送信日時（開始）</summary>
        public const string CT_SENDDATETIMESTART = "SendDateTimeStart";
        /// <summary>送信日時（終了）</summary>
        public const string CT_SENDDATETIMEEND = "SendDateTimeEnd";
        /// <summary>送信対象日付（開始）</summary>
        public const string CT_SENDOBJDATESTART = "SendObjDateStart";
        /// <summary>送信対象日付（終了）</summary>
        public const string CT_SENDOBJDATEEND = "SendObjDateEnd";
        /// <summary>送信対象得意先（開始）</summary>
        public const string CT_SENDOBJCUSTSTART = "SendObjCustStart";
        /// <summary>送信対象得意先（終了）</summary>
        public const string CT_SENDOBJCUSTEND = "SendObjCustEnd";
        /// <summary>送信対象区分</summary>
        public const string CT_SENDOBJDIV = "SendObjDiv";
        /// <summary>送信対象区分名称</summary>
        public const string CT_SENDOBJDIVNAME = "SendObjDivName";
        /// <summary>送信結果コード</summary>
        public const string CT_SENDRESULTS = "SendResults";
        /// <summary>送信結果名称</summary>
        public const string CT_SENDRESULTSNAME = "SendResultsName";
        /// <summary>送信伝票枚数</summary>
        public const string CT_SendSlipCount = "SendSlipCount";
        /// <summary>送信伝票明細数</summary>
        public const string CT_SendSlipDtlCnt = "SendSlipDtlCnt";
        /// <summary>送信伝票合計金額</summary>
        public const string CT_SendSlipTotalMny = "SendSlipTotalMny";
        /// <summary>送信エラー内容</summary>
        public const string CT_SendErrorContents = "SendErrorContents";
        #endregion
        // 企業コード
        private string _enterpriseCode;
        // 拠点コード
        private string _sectionCode;
        // 拠点名称
        private string _sectionName;
        // 前回拠点コード
        private string _prevSectionCode;
        // 拠点コードエラーフラグ
        private bool _sectionCodeErrorFlg;
        #endregion ■ Private Members ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信ログ表示の入力フォームクラスです。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public PMSAE04001UA()
        {
            InitializeComponent();

            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            this._controlScreenSkin = new ControlScreenSkin();
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.ultraExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // アクセスクラスを初期化
            this._sAndESalSndLogListResultAcs = SAndESalSndLogListResultAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._sAndESalSndLogListResultDataTable = this._sAndESalSndLogListResultAcs.SAndESalSndLogListResultDataTable;
            this._dateGet = DateGetAcs.GetInstance(); // 日付取得部品

            // 変数初期化
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // ログイン拠点情報を取得
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
            {
                this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
            else
            {
                this._sectionName = string.Empty;
            }

        }
        # endregion ■ コンストラクタ ■

        #region ■ イベント ■
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void PMSAE04001UA_Load(object sender, EventArgs e)
        {
            // アイコン設定
            SetIcon();

            this.SAndEAutoSendDiv_tComboEditor.Items.Add(new Infragistics.Win.ValueListItem(-1, CT_SANDEAUTOSENDDIV0AND1));
            this.SAndEAutoSendDiv_tComboEditor.Items.Add(new Infragistics.Win.ValueListItem(0, CT_SANDEAUTOSENDDIV0));
            this.SAndEAutoSendDiv_tComboEditor.Items.Add(new Infragistics.Win.ValueListItem(1, CT_SANDEAUTOSENDDIV1));

            this.ScreenClear();

            // 前回表示状態が保存されていれば上書き
            this.uiMemInput1.ReadMemInput(); 

            this.ultraGrid_SAndESalSndLogListResult.DataSource = this._sAndESalSndLogListResultDataTable;

            // グリッド列入力可否設定
            SetGrid();

            //-------------------------------------------------------------
            // 前回表示情報設定
            //-------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = SAndESalSndLogListResultColDisplayStatusCollection.Deserialize(CT_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusCollection = new SAndESalSndLogListResultColDisplayStatusCollection(colDisplayStatusList);

            ColumnsCollection columns = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns;

            foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusCollection.GetColDisplayStatusList())
            {
                if (columns.Exists(colDisplayStatus.Key) == true)
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ツールバー上のツールがクリックされた時に発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    this.Close();
                    break;
                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                    {
                        this.Search(ref this._errCtrol);
                    }

                    if (this._errCtrol != null)
                    {
                        this._errCtrol.Focus();
                        this._errCtrol = null;
                    }
                    break;
                // ログ初期化
                case TOOLBAR_LOGRESETBUTTON_KEY:
                    // 確認メッセージ
                    if (DialogResult.Yes ==
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, CT_PGID,
                                      "ログデータを初期化しますか？",
                                      0,
                                      MessageBoxButtons.YesNo))
                    {
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        string errMessage = string.Empty;
                        SFCMN00299CA processingDialog = new SFCMN00299CA();

                        try
                        {
                            processingDialog.Title = "初期化中";
                            processingDialog.Message = "S&&E売上データ送信ログの初期化中です。";
                            processingDialog.DispCancelButton = false;
                            processingDialog.Show((Form)this.Parent);
                            status = this._sAndESalSndLogListResultAcs.ResetSAndESalSndLog(out errMessage, this._enterpriseCode);
                        }
                        finally
                        {
                            processingDialog.Dispose();
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.ultraGrid_SAndESalSndLogListResult.Refresh();
                            this.ScreenClear();
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                CT_PGID,
                                "ログデータがありません。",
                                0,
                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOP,
                                CT_PGID,
                                "初期化処理でエラーが発生しました。",
                                0,
                                MessageBoxButtons.OK);
                        }
                    }
                    break;
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    this.ScreenClear();
                    break;
            }
        }

        /// <summary>
        /// ChangeFocusイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ChangeFocus時に発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 拠点コード
            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                this._sectionCodeErrorFlg = false;
                // 入力値を取得
                string inputValue = this.tEdit_SectionCodeAllowZero.Text;
                string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                bool validFlg = false;
                if (_prevSectionCode == sectionCode)
                {
                    this.tEdit_SectionCodeAllowZero.Text = sectionCode;
                    validFlg = true;
                }
                else
                {
                    // 00:全社
                    if (sectionCode == "00")
                    {
                        this.tEdit_SectionCodeAllowZero.Text = "00";
                        this.SectionName_uLabel.Text = "全社";
                        _prevSectionCode = "00";
                        validFlg = true;
                    }
                    else if (!String.IsNullOrEmpty(sectionCode.Trim()))
                    {
                        // 拠点情報を取得
                        SecInfoSet sectionInfo;
                        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                        // ステータスが正常の場合はUIにセット
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0');
                            this.SectionName_uLabel.Text = sectionInfo.SectionGuideNm.TrimEnd();
                            _prevSectionCode = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0');
                            validFlg = true;
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Text = uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", _prevSectionCode);
                            validFlg = false;
                        }
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero.Text = string.Empty;
                        this.SectionName_uLabel.Text = string.Empty;
                        _prevSectionCode = string.Empty;
                        validFlg = true;
                    }
                }

                if (validFlg)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Left:
                            case Keys.Up:
                                {
                                    e.NextCtrl = null;
                                }
                                break;
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                    {
                                        e.NextCtrl = this.SectionGuide_uButton;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.SAndEAutoSendDiv_tComboEditor;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.ultraGrid_SAndESalSndLogListResult;
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
                        CT_PGID,
                        "マスタに存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_SectionCodeAllowZero.SelectAll();
                    e.NextCtrl = e.PrevCtrl;
                    this._sectionCodeErrorFlg = true;
                }
            }

            #region ■フォーカス設定処理
            // 検索日
            if (e.PrevCtrl == SendDateTimeStart_tDateEdit)
            {
                if (e.Key == Keys.Down)
                {
                    if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count == 0)
                    {
                        e.NextCtrl = null;
                    }
                    else
                    {
                        e.NextCtrl = this.ultraGrid_SAndESalSndLogListResult;
                    }
                }
            }
            if (e.PrevCtrl == SendDateTimeEnd_tDateEdit)
            {
                if (e.Key == Keys.Right)
                {
                    e.NextCtrl = null;
                }
                else if (e.Key == Keys.Down)
                {
                    if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count == 0)
                    {
                        e.NextCtrl = null;
                    }
                    else
                    {
                        e.NextCtrl = this.ultraGrid_SAndESalSndLogListResult;
                    }
                }
            }

            // グリッド
            if (e.PrevCtrl == this.ultraGrid_SAndESalSndLogListResult)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count != 0)
                        {
                            if (this.ultraGrid_SAndESalSndLogListResult.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.ultraGrid_SAndESalSndLogListResult.Rows[0].Activate();
                                this.ultraGrid_SAndESalSndLogListResult.Rows[0].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Index;
                                if (rowIndex != this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1)
                                {
                                    e.NextCtrl = null;
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Activate();
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                    }
                    return;
                }
                else
                {
                    if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count != 0)
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (this.ultraGrid_SAndESalSndLogListResult.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Activate();
                                this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Index;
                                if (rowIndex != 0)
                                {
                                    e.NextCtrl = null;
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Activate();
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.SendDateTimeEnd_tDateEdit;
                                }
                            }
                        }
                        return;
                    }
                }
            }

            // グリッド
            if (e.NextCtrl == this.ultraGrid_SAndESalSndLogListResult)
            {
                if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count != 0)
                {
                    if (e.ShiftKey == false)
                    {
                        this.ultraGrid_SAndESalSndLogListResult.Rows[0].Activate();
                        this.ultraGrid_SAndESalSndLogListResult.Rows[0].Selected = true;
                        return;
                    }
                    else
                    {
                        this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Activate();
                        this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Selected = true;
                    }
                }
                else
                {
                    if (e.ShiftKey == false)
                    {
                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                    }
                    else
                    {
                        e.NextCtrl = this.SendDateTimeEnd_tDateEdit;
                    }
                }
            }
            #endregion ■フォーカス設定処理
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: フォームが閉じた時に発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void PMSAE04001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 終了前処理
            this.BeforeClosing();
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: グリッドがキー押下された時に発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ultraGrid_SAndESalSndLogListResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ultraGrid_SAndESalSndLogListResult.ActiveRow == null)
            {
                return;
            }

            int rowIndex = this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.SendDateTimeStart_tDateEdit.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Activate();
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Activate();
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        if (this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // グリッド表示を左にスクロール
                            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 先頭行に移動
                            this.ultraGrid_SAndESalSndLogListResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 最終行に移動
                            this.ultraGrid_SAndESalSndLogListResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }
        #endregion ■ イベント ■

        #region ■ Private method ■
        /// <summary>
        /// search
        /// </summary>
        /// <remarks>
        /// <br>Note		: 送信ログ表示を行う。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void Search(ref Control errCtrl)
        {
            // 検索条件オブジェクト
            SAndESalSndLogListCndtnWork sAndESalSndLogListCndtnWork = new SAndESalSndLogListCndtnWork();
            sAndESalSndLogListCndtnWork.EnterpriseCode = _enterpriseCode;
            string inputSecCode = this.tEdit_SectionCodeAllowZero.Text;
            if ((!string.IsNullOrEmpty(inputSecCode)) && (!string.IsNullOrEmpty(inputSecCode.Trim())) && (inputSecCode.TrimEnd().PadLeft(2, '0') != "00"))
            {
                sAndESalSndLogListCndtnWork.SectionCodes = new string[] { this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') };
            }
            else
            {
                sAndESalSndLogListCndtnWork.SectionCodes = null;
            }
            if (this.SAndEAutoSendDiv_tComboEditor.SelectedIndex >= 0)
            {
                sAndESalSndLogListCndtnWork.SAndEAutoSendDiv = int.Parse(this.SAndEAutoSendDiv_tComboEditor.SelectedItem.DataValue.ToString());
            }
            long stSendDateTimeLong = this.SendDateTimeStart_tDateEdit.GetLongDate();
            long edSendDateTimeLong = this.SendDateTimeEnd_tDateEdit.GetLongDate();
            if (stSendDateTimeLong != 0)
            {
                sAndESalSndLogListCndtnWork.SendDateTimeStart = stSendDateTimeLong * 1000000;
            }
            else
            {
                sAndESalSndLogListCndtnWork.SendDateTimeStart = 0;
            }
            if (edSendDateTimeLong != 0)
            {
                sAndESalSndLogListCndtnWork.SendDateTimeEnd = edSendDateTimeLong * 1000000 + 235959;
            }
            else
            {
                sAndESalSndLogListCndtnWork.SendDateTimeEnd = 0;
            }

            sAndESalSndLogListCndtnWork.MaxSearchCt = CT_MAXSEARCHCT; //抽出最大件数設定(「0」は制限しない)
            sAndESalSndLogListCndtnWork.SearchOverFlg = false; // 抽出件数超過フラグ

            object objPara = sAndESalSndLogListCndtnWork as object;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SFCMN00299CA processingDialog = new SFCMN00299CA();

            try
            {
                processingDialog.Title = "抽出処理";

                processingDialog.Message = "S&&E売上データ送信ログの抽出中です。";

                processingDialog.DispCancelButton = false;

                processingDialog.Show((Form)this.Parent);

                status = this._sAndESalSndLogListResultAcs.SearchSAndESalSndLog(ref objPara, ConstantManagement.LogicalMode.GetData0);
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ultraGrid_SAndESalSndLogListResult.Refresh();
                if (((SAndESalSndLogListCndtnWork)objPara).SearchOverFlg)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        CT_PGID,
                        string.Format("データ件数が{0}件を超えました。", ((SAndESalSndLogListCndtnWork)objPara).MaxSearchCt),
                        0,
                        MessageBoxButtons.OK);
                }
                this.ultraGrid_SAndESalSndLogListResult.Focus();
                this.ultraGrid_SAndESalSndLogListResult.Rows[0].Activate();
                this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Selected = true;
                this.ultraGrid_SAndESalSndLogListResult.PerformAction(UltraGridAction.FirstRowInGrid);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    CT_PGID,
                    "ログデータがありません。",
                    0,
                    MessageBoxButtons.OK);
                errCtrl = this.tEdit_SectionCodeAllowZero;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    CT_PGID,
                    "検索処理でエラーが発生しました。",
                    0,
                    MessageBoxButtons.OK);
                errCtrl = this.tEdit_SectionCodeAllowZero;
            }
        }

        /// <summary>
        /// CheckBeforeSearch
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力画面チェックを行う。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private int CheckBeforeSearch(ref Control errCtrl)
        {
            ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.None, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero);
            this.tArrowKeyControl1_ChangeFocus(this, eArgs);
            if (this._sectionCodeErrorFlg)
            {
                this._sectionCodeErrorFlg = false;
                return -1;;
            }

            // 入力日付（開始～終了）
            DateGetAcs.CheckDateRangeResult cdrResult;
            string errMessage = null;

            if (CallCheckDateRange(out cdrResult, ref this.SendDateTimeStart_tDateEdit, ref this.SendDateTimeEnd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("{0}", MSG_ST_SENDDATETIME_ERROR);
                            errCtrl = this.SendDateTimeStart_tDateEdit;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("{0}", MSG_ED_SENDDATETIME_ERROR);
                            errCtrl = this.SendDateTimeEnd_tDateEdit;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("{0}", MSG_REVERSE_SENDDATETIME_ERROR);
                            errCtrl = this.SendDateTimeStart_tDateEdit;
                            break;
                        }
                }

                if (errMessage != null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        CT_PGID,
                        errMessage,
                        0,
                        MessageBoxButtons.OK);
                    return -1;
                }
            }

            return 0;
        }

        /// <summary>
        /// アイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ツールバーのアイコンを設定します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;
            // -----------------------------
            // ツールバーアイコン設定
            // -----------------------------
            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            // 終了
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 検索
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // ログ初期化			
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGRESETBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // クリア
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            this.SectionGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            this.SectionGuide_uButton.Appearance.Image = Size16_Index.STAR1;
        }

        /// <summary>
        /// グリッド列入力可否設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド列入力可否を設定します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// <br>Update Note : 2013/06/26 zhaimm</br>
        /// </remarks>
        private void SetGrid()
        {
            // 列入力可否と詰め方設定
            /// <summary>拠点コード</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONCODE].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONCODE].Hidden = true;
            /// <summary>拠点名称</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>自動送信区分コード</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIV].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIV].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIV].Hidden = true;
            /// <summary>自動送信区分名称</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIVNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIVNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信日時（開始）</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMESTART].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMESTART].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信日時（終了）</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMEEND].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMEEND].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信対象日付（開始）</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATESTART].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATESTART].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信対象日付（終了）</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATEEND].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATEEND].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信対象得意先（開始）</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTSTART].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTSTART].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTSTART].Format = "#########";
            /// <summary>送信対象得意先（終了）</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTEND].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTEND].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTEND].Format = "#########";
            /// <summary>送信対象区分コード</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIV].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIV].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIV].Hidden = true;
            /// <summary>送信対象区分名称</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIVNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIVNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信結果コード</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTS].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTS].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTS].Hidden = true;
            /// <summary>送信結果名称</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTSNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTSNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>送信伝票枚数</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipCount].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipCount].Format = "###,###";
            /// <summary>送信伝票明細数</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipDtlCnt].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipDtlCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipDtlCnt].Format = "###,###";
            /// <summary>送信伝票合計金額</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipTotalMny].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipTotalMny].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipTotalMny].Format = "###,###,###,###";
            /// <summary>送信エラー内容</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendErrorContents].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendErrorContents].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ScreenClear()
        {
            // 画面クリア
            this.tEdit_SectionCodeAllowZero.Text = this._sectionCode.TrimEnd().PadLeft(2, '0');
            _prevSectionCode = this._sectionCode.TrimEnd().PadLeft(2, '0');
            this.SectionName_uLabel.Text = this._sectionName;
            this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 0;
            this.SendDateTimeStart_tDateEdit.Clear();
            this.SendDateTimeEnd_tDateEdit.SetDateTime(DateTime.Now);
            this._sAndESalSndLogListResultDataTable.Rows.Clear();

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // 表示状態を保存する
            this.uiMemInput1.WriteMemInput();

            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns);
            this._colDisplayStatusCollection.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            SAndESalSndLogListResultColDisplayStatusCollection.Serialize(this._colDisplayStatusCollection.GetColDisplayStatusList(), CT_FILENAME_COLDISPLAYSTATUS);
        }

        /// <summary>
        /// 終了前処理CALL
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理CALLを行う。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        public void CallBeforeClosing()
        {
            this.BeforeClosing();
        }

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期フォーカス設定を行う。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // グリッドから列表示状態クラスリストを構築
            // グループ内の各カラム
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();
                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        /// <summary>
        /// 拠点ガイドブタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionGuide_uButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.SectionName_uLabel.Text = sectionInfo.SectionGuideNm.Trim();
                _prevSectionCode = sectionInfo.SectionCode.Trim();
                // 次フォーカス
                this.SAndEAutoSendDiv_tComboEditor.Focus();
            }
        }

        /// <summary>
        /// 拠点コードEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionCode_tEdit_Enter(object sender, EventArgs e)
        {
            // ゼロ詰め解除
            this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", this.tEdit_SectionCodeAllowZero.Text.TrimEnd());
        }

        /// <summary>
        /// UI保存コンポーネント読込みイベント
        /// </summary>
        /// <param name="targetControls">対象コンポーネント</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	　 : UI保存コンポーネント読込みイベントを行う</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if ((customizeData != null) && (customizeData.Length == 1))
            {
                // 自動送信区分
                if (customizeData[0] == "-1")
                {
                    // 全て
                    this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 0;
                }
                else if (customizeData[0] == "0")
                {
                    // 手動
                    this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 1;
                }
                else if (customizeData[0] == "1")
                {
                    // 自動
                    this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 2;
                }
            }
        }

        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls">対象コンポーネント</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	　 : UI保存コンポーネント書込みイベントを行う</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[1];
            // 自動送信区分
            customizeData[0] = this.SAndEAutoSendDiv_tComboEditor.SelectedItem.DataValue.ToString(); 
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: グリッドを離れると発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ultraGrid_SAndESalSndLogListResult_Leave(object sender, EventArgs e)
        {
            this.ultraGrid_SAndESalSndLogListResult.ActiveCell = null;
            this.ultraGrid_SAndESalSndLogListResult.ActiveRow = null;

            for (int index = 0; index < this.ultraGrid_SAndESalSndLogListResult.Rows.Count; index++)
            {
                this.ultraGrid_SAndESalSndLogListResult.Rows[index].Selected = false;
            }
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: コントロールが展開または縮小した後に発生します。</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ultraExpandableGroupBox_Condition_ExpandedStateChanged(object sender, EventArgs e)
        {
            this.ultraExpandableGroupBox_Condition.TabStop = !this.ultraExpandableGroupBox_Condition.Expanded;
        }
        #endregion ■ Private method ■
    }
}