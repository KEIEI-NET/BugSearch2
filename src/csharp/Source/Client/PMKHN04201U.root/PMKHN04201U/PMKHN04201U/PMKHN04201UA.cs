//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会 
// プログラム概要   : 他社部品検索履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/19  修正内容 : Redmine#17394
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/24  修正内容 : Redmine#17451,#17511,#17517,#17522
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/25  修正内容 : Redmine#17451
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData; // ADD 2010/11/19

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 他社部品検索履歴照会UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 他社部品検索履歴照会UIフォームクラス</br>
    /// <br>Programmer  : 朱 猛</br>
    /// <br>Date        : 2010/11/11</br>
    /// </remarks>
    public partial class PMKHN04201UA : Form
    {
        #region ■ Private Members ■
        // SCM問合せログデータテーブル
        private ScmInqLogInquiryDataSet.ScmInqLogInquiryDataTable _scmInqLogDataTable;
        // SCM問合せログアクセスクラス
        private ScmInqLogAcs _scmInqLogAcs;
        //日付取得部品
        private DateGetAcs _dateGet;
        /// <summary>列表示状態コレクションクラス</summary>
        private ScmInqLogColDisplayStatusCollection _colDisplayStatusCollection = null;
        private ControlScreenSkin _controlScreenSkin;
        private DateTime _preDateTimeStart;
        private DateTime _preDateTimeEnd;
        private int _preYear; // ADD 2010/11/19
        private int _preMonth; // ADD 2010/11/19
        private int _preDay; // ADD 2010/11/19
        // エラー項目
        private Control _errCtrol = null;

        // 終了
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        // クリア			
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        // 検索			
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        // ログイン担当者タイトル
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";
        // ログイン担当者名称			
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";		     
        // アセンブリID
        private const string CT_PGID = "PMKHN04201U";
        // 列表示状態セッティングファイル名
        private const string CT_FILENAME_COLDISPLAYSTATUS = "PMKHN04201U_ColSetting.DAT";
        //エラー条件メッセージ
        private const string ct_InputError = "の入力が不正です";
        private const string ct_NoInput = "を入力して下さい";
        #region < グリッド列用 >
        /// <summary>SCM問合せログテーブル</summary>
        private const string CT_TBL_TITLE = "ScmInqLogInquiry";

        /// <summary>RowNo</summary>
        public const string CT_RowNo = "RowNo";
        // ---UPD 2010/11/19 -------------------------->>>
        ///// <summary>作成日時</summary>
        //public const string CT_CreateDateTime = "CreateDateTime";
        /// <summary>作成日付</summary>
        public const string CT_CreateDate = "CreateDate";
        /// <summary>作成時刻</summary>
        public const string CT_CreateTime = "CreateTime";
        // ---UPD 2010/11/19 --------------------------<<<
        /// <summary>連絡元企業名称</summary>
        public const string CT_CnectOriginalEpNm = "CnectOriginalEpNm";
        /// <summary>入力システム</summary>
        public const string CT_UseSystem = "UseSystem";
        /// <summary>問合せ内容</summary>
        public const string CT_ScmInqContents = "ScmInqContents";
        #endregion
        // 企業コード
        private string _enterpriseCode;
        #endregion ■ Private Members ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 他社部品検索履歴照会の入力フォームクラスです。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public PMKHN04201UA()
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

            // 変数初期化
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._scmInqLogAcs = ScmInqLogAcs.GetInstance();
            this._scmInqLogDataTable = this._scmInqLogAcs.ScmInqLogDataTable;
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

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
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void PMKHN04201UA_Load(object sender, EventArgs e)
        {
            // アイコン設定
            SetIcon();

            this.tDateEdit_Start.SetDateTime(DateTime.Now);
            // ---UPD 2010/11/19 -------------------------->>>
            //this.tDateEdit_End.SetDateTime(DateTime.Now);
            this.StartHour_tNedit.Text = "00";
            this.StartMinute_tNedit.Text = "00";
            this.StartSecond_tNedit.Text = "00";
            this.EndHour_tNedit.Text = "23";
            this.EndMinute_tNedit.Text = "59";
            this.EndSecond_tNedit.Text = "59";
            // ---UPD 2010/11/19 --------------------------<<<
            //this.tDateEdit_Start.Focus(); // DEL 2010/11/19
            this.ultraGrid_ScmInqLog.DataSource = this._scmInqLogDataTable;

            // グリッド列入力可否設定
            SetGrid();

            //-------------------------------------------------------------
            // 前回表示情報設定
            //-------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = ScmInqLogColDisplayStatusCollection.Deserialize(CT_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusCollection = new ScmInqLogColDisplayStatusCollection(colDisplayStatusList);

            ColumnsCollection columns = this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns;

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
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    this.Close();
                    break;
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    this.ScreenClear();
                    break;
                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    // ---UPD 2010/11/19 -------------------------->>>
                    //if ((this._preDateTimeStart != null && this._preDateTimeStart != this.tDateEdit_Start.GetDateTime().Date) || (this._preDateTimeEnd != null && this._preDateTimeEnd != this.tDateEdit_End.GetDateTime().Date) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                    //{
                    //    if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                    //    {
                    //        this.Search(ref this._errCtrol);
                    //    }
                    //}
                    //else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                    //{
                    //    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                    //    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                    //}

                    //if (this._errCtrol != null)
                    //{
                    //    this._errCtrol.Focus();
                    //    this._errCtrol = null;
                    //}

                    if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                    {
                        // ---DEL 2010/11/24 -------------------------->>>
                        //DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text));
                        //DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text));
                        //if ((this._preDateTimeStart != null && this._preDateTimeStart != tmpStartDt) || (this._preDateTimeEnd != null && this._preDateTimeEnd != tmpEndDt) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                        //{
                        //    this.Search(ref this._errCtrol);
                        //}
                        //else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                        //{
                        //    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                        //    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                        //}
                        // ---DEL 2010/11/24 --------------------------<<<
                        this.Search(ref this._errCtrol); // ADD 2010/11/24
                    }

                    if (this._errCtrol != null)
                    {
                        this._errCtrol.Focus();
                        this._errCtrol = null;
                    }
                    // ---UPD 2010/11/19 --------------------------<<<
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
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ---UPD 2010/11/19 -------------------------->>>
            //// 検索日（終了）
            //if (e.PrevCtrl == this.tDateEdit_End)
            //{
            //    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
            //    {
            //        if ((this._preDateTimeStart != null && this._preDateTimeStart != this.tDateEdit_Start.GetDateTime().Date) || (this._preDateTimeEnd != null && this._preDateTimeEnd != this.tDateEdit_End.GetDateTime().Date) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
            //        {
            //            // 検索
            //            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
            //            {
            //                this.Search(ref this._errCtrol);
            //            }

            //            if (this._errCtrol != null)
            //            {
            //                this._errCtrol.Focus();
            //                this._errCtrol = null;
            //                e.NextCtrl = null;
            //            }
            //        }
            //        else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
            //        {
            //            this.ultraGrid_ScmInqLog.Rows[0].Activate();
            //            this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
            //        }
            //    }
            //}
            //// 検索日（開始）
            //else if (e.PrevCtrl == this.tDateEdit_Start)
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if ((this._preDateTimeStart != null && this._preDateTimeStart != this.tDateEdit_Start.GetDateTime().Date) || (this._preDateTimeEnd != null && this._preDateTimeEnd != this.tDateEdit_End.GetDateTime().Date) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
            //        {
            //            // 検索
            //            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
            //            {
            //                this.Search(ref this._errCtrol);
            //            }

            //            if (this._errCtrol != null)
            //            {
            //                this._errCtrol.Focus();
            //                this._errCtrol = null;
            //                e.NextCtrl = null;
            //            }
            //        }
            //        else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
            //        {
            //            this.ultraGrid_ScmInqLog.Rows[0].Activate();
            //            this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
            //        }
            //    }
            //}
            //// グリッド
            //else if (e.PrevCtrl == this.ultraGrid_ScmInqLog)
            //{
            //    if (this.ultraGrid_ScmInqLog.ActiveRow != null)
            //    {
            //        if (e.Key == Keys.Up && this.ultraGrid_ScmInqLog.ActiveRow != null)
            //        {
            //            if (this.ultraGrid_ScmInqLog.ActiveRow.Index == 0)
            //            {
            //                this.ultraGrid_ScmInqLog.ActiveRow.Selected = false;
            //                this.ultraGrid_ScmInqLog.ActiveRow = null;
            //                this.tDateEdit_Start.Focus();
            //            }
            //        }
            //        else if (e.Key == Keys.Down && this.ultraGrid_ScmInqLog.ActiveRow.Index == this.ultraGrid_ScmInqLog.Rows.Count - 1)
            //        {
            //            e.NextCtrl = null;
            //        }
            //        else if (e.Key == Keys.Return || e.Key == Keys.Tab)
            //        {
            //            e.NextCtrl = null;
            //        }
            //    }
            //}

            #region ■検索処理
            if (e.PrevCtrl != null && !e.ShiftKey)
            {
                switch (e.PrevCtrl.Name)
                {
                    // 検索時刻（終了秒以外）
                    case "StartHour_tNedit":
                    case "StartMinute_tNedit":
                    case "StartSecond_tNedit":
                    case "EndHour_tNedit":
                    case "EndMinute_tNedit":
                        if (e.Key == Keys.Down)
                        {
                            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                            {
                                //DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text)); // DEL 2010/11/25
                                //DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text)); // DEL 2010/11/25
                                DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt()); // ADD 2010/11/25
                                DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt()); // ADD 2010/11/25
                                if ((this._preDateTimeStart != null && this._preDateTimeStart != tmpStartDt) || (this._preDateTimeEnd != null && this._preDateTimeEnd != tmpEndDt) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                                {
                                    // 検索
                                    this.Search(ref this._errCtrol);
                                }
                                else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                                {
                                    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                                    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                                    this.ultraGrid_ScmInqLog.PerformAction(UltraGridAction.FirstRowInGrid); // ADD 2010/11/25
                                }
                            }
                            if (this._errCtrol != null)
                            {
                                this._errCtrol.Focus();
                                this._errCtrol = null;
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    // 検索時刻（終了秒）
                    case "EndSecond_tNedit":
                        if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                        {
                            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                            {
                                //DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text)); // DEL 2010/11/25
                                //DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text)); // DEL 2010/11/25
                                DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt()); // ADD 2010/11/25
                                DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt()); // ADD 2010/11/25
                                if ((this._preDateTimeStart != null && this._preDateTimeStart != tmpStartDt) || (this._preDateTimeEnd != null && this._preDateTimeEnd != tmpEndDt) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                                {
                                    // 検索
                                    this.Search(ref this._errCtrol);
                                }
                                else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                                {
                                    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                                    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                                    this.ultraGrid_ScmInqLog.PerformAction(UltraGridAction.FirstRowInGrid); // ADD 2010/11/25
                                }
                            }
                            if (this._errCtrol != null)
                            {
                                this._errCtrol.Focus();
                                this._errCtrol = null;
                                e.NextCtrl = null;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (e.PrevCtrl != null && e.PrevCtrl == this.tDateEdit_Start)
                {
                    e.NextCtrl = null;
                }
            }
            #endregion ■検索処理

            #region ■フォーカス設定処理
            if (e.PrevCtrl != null)
            {
                // 検索日
                if (e.PrevCtrl == this.tDateEdit_Start)
                {
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = null;
                    }
                }
                // グリッド
                if (e.PrevCtrl == this.ultraGrid_ScmInqLog)
                {
                    if (this.ultraGrid_ScmInqLog.ActiveRow != null)
                    {
                        if (e.Key == Keys.Up && this.ultraGrid_ScmInqLog.ActiveRow != null)
                        {
                            //if (this.ultraGrid_ScmInqLog.ActiveRow.Index == 0) // DEL 2010/11/25
                            if (this.ultraGrid_ScmInqLog.ActiveRow.Index == 0 && this.ultraExpandableGroupBox_Condition.Expanded) // ADD 2010/11/25
                            {
                                this.ultraGrid_ScmInqLog.ActiveRow.Selected = false;
                                this.ultraGrid_ScmInqLog.ActiveRow = null;
                                this.StartHour_tNedit.Focus();
                            }
                        }
                        else if (e.Key == Keys.Down && this.ultraGrid_ScmInqLog.ActiveRow.Index == this.ultraGrid_ScmInqLog.Rows.Count - 1)
                        {
                            e.NextCtrl = null;
                        }
                        else if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        {
                            e.NextCtrl = null;
                        }
                    }
                }

                // ---ADD 2010/11/24 -------------------------->>>
                if (e.ShiftKey)
                {
                    if ((e.Key == Keys.Return || e.Key == Keys.Tab) && e.PrevCtrl == this.ultraGrid_ScmInqLog)
                    {
                        this.EndSecond_tNedit.Focus();
                    }
                }
                // ---ADD 2010/11/24 --------------------------<<<
            }
            #endregion ■フォーカス設定処理
            // ---UPD 2010/11/19 --------------------------<<<
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: フォームが閉じた時に発生します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void PMKHN04201UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 終了前処理
            this.BeforeClosing();
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: グリッドがキー押下された時に発生します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void ultraGrid_ScmInqLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Up, this.ultraGrid_ScmInqLog, this.tDateEdit_Start);
                this.tArrowKeyControl1_ChangeFocus(this, evt);
            }
            else if (e.KeyCode == Keys.Down)
            {
                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.ultraGrid_ScmInqLog, this.ultraGrid_ScmInqLog);
                this.tArrowKeyControl1_ChangeFocus(this, evt);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            else if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を左にスクロール
                this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position - 40;
            }
        }

        // ---ADD 2010/11/19 -------------------------->>>
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 本日ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        private void uButton_Today_Click(object sender, EventArgs e)
        {
            DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
            this.tDateEdit_Start.SetDateTime(DateTime.Now);

            if (this._preYear != tmpDt.Year || this._preMonth != tmpDt.Month || this._preDay != tmpDt.Day)
            {
                this.StartHour_tNedit.Text = "00";
                this.StartMinute_tNedit.Text = "00";
                this.StartSecond_tNedit.Text = "00";
                this.EndHour_tNedit.Text = "23";
                this.EndMinute_tNedit.Text = "59";
                this.EndSecond_tNedit.Text = "59";
            }
            this.StartHour_tNedit.Focus();
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 前日ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        private void ultraButton_Yesterday_Click(object sender, EventArgs e)
        {
            // ---UPD 2010/11/24 -------------------------->>>
            //DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
            //DateTime tmpDateTime = this.tDateEdit_Start.GetDateTime().AddDays(-1);
            //this.tDateEdit_Start.SetDateTime(tmpDateTime);

            //if (this._preYear != tmpDt.Year || this._preMonth != tmpDt.Month || this._preDay != tmpDt.Day)
            //{
            //    this.StartHour_tNedit.Text = "00";
            //    this.StartMinute_tNedit.Text = "00";
            //    this.StartSecond_tNedit.Text = "00";
            //    this.EndHour_tNedit.Text = "23";
            //    this.EndMinute_tNedit.Text = "59";
            //    this.EndSecond_tNedit.Text = "59";
            //}
            //this.StartHour_tNedit.Focus();
            try
            {
                DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
                DateTime tmpDateTime = this.tDateEdit_Start.GetDateTime().AddDays(-1);
                this.tDateEdit_Start.SetDateTime(tmpDateTime);

                if (this._preYear != tmpDt.Year || this._preMonth != tmpDt.Month || this._preDay != tmpDt.Day)
                {
                    this.StartHour_tNedit.Text = "00";
                    this.StartMinute_tNedit.Text = "00";
                    this.StartSecond_tNedit.Text = "00";
                    this.EndHour_tNedit.Text = "23";
                    this.EndMinute_tNedit.Text = "59";
                    this.EndSecond_tNedit.Text = "59";
                }
                this.StartHour_tNedit.Focus();
            }
            catch
            {
                this.tDateEdit_Start.Focus();
            }
            // ---UPD 2010/11/24 --------------------------<<<
        }

        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 日付が変更された時に発生します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        private void tDateEdit_Start_ValueChanged(object sender, EventArgs e)
        {
            DateTime tmpDt = this.tDateEdit_Start.GetDateTime();

            this._preYear = tmpDt.Year;
            this._preMonth = tmpDt.Month;
            this._preDay = tmpDt.Day;
        }
        // ---ADD 2010/11/19 --------------------------<<<
        #endregion ■ イベント ■

        #region ■ Private method ■
        /// <summary>
        /// search
        /// </summary>
        /// <remarks>
        /// <br>Note		: 他社部品検索履歴照会を行う。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void Search(ref Control errCtrl)
        {
            // ---UPD 2010/11/19 -------------------------->>>
            //DateTime beginDt = this.tDateEdit_Start.GetDateTime();
            //DateTime endDt = this.tDateEdit_End.GetDateTime();
            //DateTime beginDt2 = new DateTime(beginDt.Year, beginDt.Month, beginDt.Day, 0, 0, 0, 0);
            //DateTime endDt2 = new DateTime(endDt.Year, endDt.Month, endDt.Day, 23, 59, 59, 999);
            //long beginDateTime = beginDt2.Ticks;
            //long endDateTime = endDt2.Ticks;

            // 検索条件オブジェクト
            ScmInqLogInquirySearchPara scmInqLogInquirySearchPara = new ScmInqLogInquirySearchPara();
            
            DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
            //DateTime beginDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text), 0); // DEL 2010/11/25
            //DateTime endDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text), 999); // DEL 2010/11/25
            DateTime beginDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt(), 0); // ADD 2010/11/25
            DateTime endDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt(), 999); // ADD 2010/11/25
            scmInqLogInquirySearchPara.BeginDateTime = beginDt.Ticks;
            scmInqLogInquirySearchPara.EndDateTime = endDt.Ticks;
            scmInqLogInquirySearchPara.CnectOtherEpCd = this._enterpriseCode;
            scmInqLogInquirySearchPara.LogicalDeleteCode = 0;
            //scmInqLogInquirySearchPara.MaxSearchCt = 5000; // DEL 2010/11/24
            scmInqLogInquirySearchPara.MaxSearchCt = 5000 + 1; // ADD 2010/11/24
            object objPara = scmInqLogInquirySearchPara as object;
            // ---UPD 2010/11/19 --------------------------<<<

            //int status = this._scmInqLogAcs.search(scmInqLogInquirySearchPara, 0); // DEL 2010/11/19
            //int status = this._scmInqLogAcs.search(ref objPara, 0); // ADD 2010/11/19
            // ---ADD 2010/11/24 -------------------------->>>
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SFCMN00299CA processingDialog = new SFCMN00299CA();

            try
            {
                processingDialog.Title = "抽出処理";

                processingDialog.Message = "現在、データ抽出中です。";

                processingDialog.DispCancelButton = false;

                processingDialog.Show((Form)this.Parent);

                status = this._scmInqLogAcs.search(ref objPara, 0);
            }
            finally
            {
                processingDialog.Dispose();
            }
            // ---ADD 2010/11/24 --------------------------<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ultraGrid_ScmInqLog.Refresh();
                // ---ADD 2010/11/19 -------------------------->>>
                if (((ScmInqLogInquirySearchPara)objPara).SearchOverFlg)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        CT_PGID,
                        "データ件数が5000件を超えました。",
                        0,
                        MessageBoxButtons.OK);
                }
                // ---ADD 2010/11/19 --------------------------<<<
                this.ultraGrid_ScmInqLog.Focus(); // ADD 2010/11/19
                this.ultraGrid_ScmInqLog.Rows[0].Activate();
                this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                this.ultraGrid_ScmInqLog.PerformAction(UltraGridAction.FirstRowInGrid); // ADD 2010/11/25
                //this._preDateTimeStart = this.tDateEdit_Start.GetDateTime().Date; // DEL 2010/11/19
                //this._preDateTimeEnd = this.tDateEdit_End.GetDateTime().Date; // DEL 2010/11/19
                // ---ADD 2010/11/19 -------------------------->>>
                //this._preDateTimeStart = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text)); // DEL 2010/11/25
                //this._preDateTimeEnd = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text)); // DEL 2010/11/25
                this._preDateTimeStart = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt()); // ADD 2010/11/25
                this._preDateTimeEnd = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt()); // ADD 2010/11/25
                // ---ADD 2010/11/19 --------------------------<<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    CT_PGID,
                    "検索条件に該当するデータが存在しません。",
                    0,
                    MessageBoxButtons.OK);
                errCtrl = this.tDateEdit_Start;
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
                errCtrl = this.tDateEdit_Start;
            }
        }

        /// <summary>
        /// CheckBeforeSearch
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力画面チェックを行う。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private int CheckBeforeSearch(ref Control errCtrl)
        {
            // 入力日付（開始～終了）
            DateGetAcs.CheckDateRangeResult cdrResult;
            string errMessage = null;
            // ---UPD 2010/11/19 -------------------------->>>
            //if (CallCheckDateRange(out cdrResult, ref this.tDateEdit_Start, ref this.tDateEdit_End) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("開始日{0}", ct_NoInput);
            //                errCtrl = this.tDateEdit_Start;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("開始日{0}", ct_InputError);
            //                errCtrl = this.tDateEdit_Start;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("終了日{0}", ct_NoInput);
            //                errCtrl = this.tDateEdit_End;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("終了日{0}", ct_InputError);
            //                errCtrl = this.tDateEdit_End;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = "開始日を終了日よりも後にすることはできません。";
            //                errCtrl = this.tDateEdit_Start;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = "日付は１ヶ月の範囲内で入力してください。";
            //                errCtrl = this.tDateEdit_End;
            //            }
            //            break;
            //    }
            //}
            //if (this.tDateEdit_Start.LongDate == 0 && this.tDateEdit_End.LongDate == 0)
            //{
            //    errMessage = string.Format("開始日{0}", ct_NoInput);
            //    errCtrl = this.tDateEdit_Start;
            //}

            if (CallCheckDateRange(out cdrResult, ref this.tDateEdit_Start, ref this.tDateEdit_Start) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("検索日{0}", ct_NoInput);
                            errCtrl = this.tDateEdit_Start;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("検索日{0}", ct_InputError);
                            errCtrl = this.tDateEdit_Start;
                        }
                        break;
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
            if (this.tDateEdit_Start.LongDate == 0)
            {
                errMessage = string.Format("検索日{0}", ct_NoInput);
                errCtrl = this.tDateEdit_Start;
            }
            // ---DEL 2010/11/25 --------------------------------->>>
            //else if (this.StartHour_tNedit.Text == "" || this.StartMinute_tNedit.Text == "" || this.StartSecond_tNedit.Text == "")
            //{
            //    errMessage = string.Format("開始時刻{0}", ct_NoInput);
            //    errCtrl = this.StartHour_tNedit;
            //}
            //else if (this.EndHour_tNedit.Text == "" || this.EndMinute_tNedit.Text == "" || this.EndSecond_tNedit.Text == "")
            //{
            //    errMessage = string.Format("終了時刻{0}", ct_NoInput);
            //    errCtrl = this.EndHour_tNedit;
            //}
            // ---DEL 2010/11/25 ---------------------------------<<<
            //else if (int.Parse(this.StartHour_tNedit.Text) < 0 || int.Parse(this.StartHour_tNedit.Text) > 23) // DEL 2010/11/25
            else if (this.StartHour_tNedit.GetInt() < 0 || this.StartHour_tNedit.GetInt() > 23) // ADD 2010/11/25
            {
                errMessage = string.Format("開始時刻{0}", ct_InputError);
                errCtrl = this.StartHour_tNedit;
            }
            //else if (int.Parse(this.StartMinute_tNedit.Text) < 0 || int.Parse(this.StartMinute_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.StartMinute_tNedit.GetInt() < 0 || this.StartMinute_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("開始時刻{0}", ct_InputError);
                errCtrl = this.StartMinute_tNedit;
            }
            //else if (int.Parse(this.StartSecond_tNedit.Text) < 0 || int.Parse(this.StartSecond_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.StartSecond_tNedit.GetInt() < 0 || this.StartSecond_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("開始時刻{0}", ct_InputError);
                errCtrl = this.StartSecond_tNedit;
            }
            //else if (int.Parse(this.EndHour_tNedit.Text) < 0 || int.Parse(this.EndHour_tNedit.Text) > 23) // DEL 2010/11/25
            else if (this.EndHour_tNedit.GetInt() < 0 || this.EndHour_tNedit.GetInt() > 23) // ADD 2010/11/25
            {
                errMessage = string.Format("終了時刻{0}", ct_InputError);
                errCtrl = this.EndHour_tNedit;
            }
            //else if (int.Parse(this.EndMinute_tNedit.Text) < 0 || int.Parse(this.EndMinute_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.EndMinute_tNedit.GetInt() < 0 || this.EndMinute_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("終了時刻{0}", ct_InputError);
                errCtrl = this.EndMinute_tNedit;
            }
            //else if (int.Parse(this.EndSecond_tNedit.Text) < 0 || int.Parse(this.EndSecond_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.EndSecond_tNedit.GetInt() < 0 || this.EndSecond_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("終了時刻{0}", ct_InputError);
                errCtrl = this.EndSecond_tNedit;
            }
            //else if (int.Parse(this.StartHour_tNedit.Text) > int.Parse(this.EndHour_tNedit.Text) // DEL 2010/11/25
            //    || int.Parse(this.StartHour_tNedit.Text) == int.Parse(this.EndHour_tNedit.Text) && int.Parse(this.StartMinute_tNedit.Text) > int.Parse(this.EndMinute_tNedit.Text) // DEL 2010/11/25
            //    || int.Parse(this.StartHour_tNedit.Text) == int.Parse(this.EndHour_tNedit.Text) && int.Parse(this.StartMinute_tNedit.Text) == int.Parse(this.EndMinute_tNedit.Text) && int.Parse(this.StartSecond_tNedit.Text) > int.Parse(this.EndSecond_tNedit.Text)) // DEL 2010/11/25
            else if (this.StartHour_tNedit.GetInt() > this.EndHour_tNedit.GetInt() // ADD 2010/11/25
                || this.StartHour_tNedit.GetInt() == this.EndHour_tNedit.GetInt() && this.StartMinute_tNedit.GetInt() > this.EndMinute_tNedit.GetInt() // ADD 2010/11/25
                || this.StartHour_tNedit.GetInt() == this.EndHour_tNedit.GetInt() && this.StartMinute_tNedit.GetInt() == this.EndMinute_tNedit.GetInt() && this.StartSecond_tNedit.GetInt() > this.EndSecond_tNedit.GetInt()) // ADD 2010/11/25
            {
                errMessage = "開始時刻を終了時刻よりも後にすることはできません。";
                errCtrl = this.StartHour_tNedit;
            }
            // ---UPD 2010/11/19 --------------------------<<<

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

            return 0;
        }

        /// <summary>
        /// アイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ツールバーのアイコンを設定します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// <br>Update Note : 2010/11/11 朱 猛</br>
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
            // クリア
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // 検索
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
        }

        /// <summary>
        /// グリッド列入力可否設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド列入力可否を設定します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// <br>Update Note : 2010/11/11 朱 猛</br>
        /// </remarks>
        private void SetGrid()
        {
            // 列入力可否と詰め方設定
            // RowNo
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_RowNo].CellActivation = Activation.NoEdit;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ---UPD 2010/11/19 -------------------------->>>
            //// 作成日時
            //this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDateTime].CellActivation = Activation.NoEdit;
            //this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDateTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDateTime].Format = "yyyy/MM/dd HH:mm:ss";

            // 日付
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDate].CellActivation = Activation.NoEdit;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDate].Format = "yyyy/MM/dd";

            // 時刻
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateTime].CellActivation = Activation.NoEdit;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateTime].Format = "HH:mm:ss";
            // ---UPD 2010/11/19 --------------------------<<<

            // 連絡元企業名称
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CnectOriginalEpNm].CellActivation = Activation.NoEdit;

            // 入力システム
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_UseSystem].CellActivation = Activation.NoEdit;

            // 問合せ内容
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_ScmInqContents].CellActivation = Activation.NoEdit;
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void ScreenClear()
        {
            this._scmInqLogDataTable.Rows.Clear();
            this.tDateEdit_Start.SetDateTime(DateTime.Now);
            //this.tDateEdit_End.SetDateTime(DateTime.Now); // DEL 2010/11/19

            // ---ADD 2010/11/19 -------------------------->>>
            this.StartHour_tNedit.DataText = "00";
            this.StartMinute_tNedit.DataText = "00";
            this.StartSecond_tNedit.DataText = "00";
            this.EndHour_tNedit.DataText = "23";
            this.EndMinute_tNedit.DataText = "59";
            this.EndSecond_tNedit.DataText = "59";
            // ---ADD 2010/11/19 --------------------------<<<

            // フォーカス設定
            this.tDateEdit_Start.Focus();
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns);
            this._colDisplayStatusCollection.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            ScmInqLogColDisplayStatusCollection.Serialize(this._colDisplayStatusCollection.GetColDisplayStatusList(), CT_FILENAME_COLDISPLAYSTATUS);
        }

        /// <summary>
        /// 終了前処理CALL
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理CALLを行う。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
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
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tDateEdit_Start.Focus();
        }

        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
        /// <br>Programmer	: 朱 猛</br>
        /// <br>Date		: 2010/11/11</br>
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

        #endregion ■ Private method ■
    }
}