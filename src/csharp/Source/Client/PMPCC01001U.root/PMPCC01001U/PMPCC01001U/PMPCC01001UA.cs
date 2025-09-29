//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC-UOEメールメッセージ設定処理
// プログラム概要   : PCC-UOEメールメッセージ設定処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 作 成 日              修正内容 :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC-UOEメールメッセージ設定処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC-UOEメールメッセージ設定処理のフォームクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.08</br>
    /// <br></br>
    /// </remarks>
    public partial class PMPCC01001UA : Form
    {
        # region ■Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMPCC01001UA()
        {
            InitializeComponent();
            //企業コード
            _erterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._nextCustomerButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_NextCustomer"];
            this._preCustomerButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PreCustomer"];
            this._nextShowButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_NextShow"];
            this._preShowButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PreShow"];
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
            this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_New"];

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ログイン担当者
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._pccMailDtAcs = new PccMailDtAcs();
            //PCC自社設定マスタメンテアクセスクラス
            this._pccCmpnyStAcs = new PccCmpnyStAcs();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
            // 画面初期化グリッド
            //得意先データの番号
            _customerDataIndex = -1;
            //メール履歴一覧データの番号
            _messageDelDataIndex = -1;

            //得意先グリッド
            this.InitCustomerDateSet();
            this.InitCustomerGrid();
            // メール履歴一覧データセット
            this.InitMessageDelDateSet();
            this.InitMailNoDateSet();
            this.InitMessageDelGrid();
            this.uCheckEditor_DeleteShow.Checked = false;
        }
        # endregion
       
        # region ■Private Members
        private PccMailDtAcs _pccMailDtAcs;
        
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextCustomerButton;      // 次得意先ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _preCustomerButton;       // 前得意先ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _nextShowButton;          // 次表示ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _preShowButton;           // 前表示ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;            // 削除ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;               // 新規作成ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		   // ログイン担当者名称
        /// <summary>
        /// 企業コード
        /// </summary>
        private string _erterpriseCode = null;
        /// <summary>
        /// 拠点コード
        /// </summary>
        private string _sectionCode = null;
        /// <summary>
        /// 得意先グリッドデータセット
        /// </summary>
        private DataSet _customerDateSet = null;
        /// <summary>
        /// メール履歴一覧ALLデータセット
        /// </summary>
        private DataSet _messageDelAllDateSet = null;

        /// <summary>
        /// メール履歴一覧データセット
        /// </summary>
        private DataSet _messageDelDateSet = null;
        /// <summary>
        /// メール履歴一覧データセット
        /// </summary>
        private DataView _messageDataView = null;

        /// <summary>
        /// メールがないのデータセット
        /// </summary>
        private DataSet _messageNoFileDateSet = null;

        /// <summary>
        /// PCC自社設定マスタメンテアクセスクラス
        /// </summary>
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        /// <summary>
        /// 得意先データの番号
        /// </summary>
        private int _customerDataIndex;
        /// <summary>
        /// メール履歴一覧データの番号
        /// </summary>
        private int _messageDelDataIndex;
        // 得意先テープル
        private Hashtable _customerHTable;
        // メール履歴一覧テープル
        private Hashtable _messageDelHTable;
        //日付取得部品
        private DateGetAcs _dateGet;
        private Dictionary<string, Dictionary<string, PccMailDt>> _pccMailDtDic = null;
        //前対象日開始
        private int preDateSt = 0;
        //前対象日終了
        private int preDateEd = 0;
        //削除ボタン表示FLAG
        private bool _showDeleBtFlg = false;
        #endregion

        #region ■Const Members
        private const string ASSEMBLY_ID = "PMPCC01001U";
        private const string DELETE_DATE = "削除日";
        private const string PCCCUSTOMERCODE_TITLE = "PCC得意先コード";
        //private const string PCCCUSTOMERNAME_TITLE = "PCC得意先";  //DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
        private const string PCCCUSTOMERNAME_TITLE = "得意先";  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PCCMAILTITLE_TITLE = "件名";
        private const string UPDATEDATETIME_TITLE = "送信時刻";
        //問合せ条件A
        private const string INQCONDITION_TITLEA = "GUID";
        //問合せ条件B
        private const string INQCONDITION_TITLEB = "GUID";
        private const string CUSTOMER_TABLE = "CUSTOMER_TABLE";
        private const string MESSAGEDEL_TABLE = "MESSAGEDEL_TABLE";
        private const string INF_NOT_FOUND = "該当するデータがありません。";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
        //private const string MAIL_NOTEXSIT_MSG = "メールがありません。";　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
        private const string MAIL_NOTEXSIT_MSG = "メッセージがありません。";　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
        #endregion

        # region ■Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : PCC-UOEメールメッセージ設定を初期化します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void PMPCC01001UA_Load(object sender, EventArgs e)
        {
            // ボタン初期設定処理
            this.ButtonInitialSetting();
            //得意先グリッド初期設定処理
            this.InitCustomerDate();

           
            // 初期化フォーカス設定
            this.tDateEdit_UpdateDateSt.Focus();
            //対象日の初期値はシステム日付－７日～システム日付
            this.tDateEdit_UpdateDateSt.SetDateTime(DateTime.Now.AddDays(-7));
            this.tDateEdit_UpdateDateEd.SetDateTime(DateTime.Now);
            //前対象日開始
            preDateSt = this.tDateEdit_UpdateDateSt.GetLongDate();
            //前対象日終了
            preDateEd = this.tDateEdit_UpdateDateEd.GetLongDate();
            
            //メール履歴一覧グリッド初期設定処理
            this.GetPccMailDtDic();
           
            this.timer_Slide.Enabled = true;
        }

        /// <summary>
        ///Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void timer_Slide_Tick(object sender, EventArgs e)
        {
            this.timer_Slide.Enabled = false;
            //画面許可制御処理
            ScreenInputPermissionControl();
        }

        /// <summary>
        ///削除済みデータの表示 イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 削除済みデータの表示を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void uCheckEditor_DeleteShow_CheckedChanged(object sender, EventArgs e)
        {
            UltraGridBand editBand = this.uGrid_MessageDel.DisplayLayout.Bands[MESSAGEDEL_TABLE];
            if (this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView.Count == 0)
            {
                if (editBand.Columns[DELETE_DATE].Hidden)
                {
                    editBand.Columns[DELETE_DATE].Hidden = false;
                }
                else
                {
                    editBand.Columns[DELETE_DATE].Hidden = true;
                }
                return;
            }
            //選択したの行
            int avtiveIndex = 0;
            string infoCondtion = string.Empty;
            bool isDeleteShow = this.uCheckEditor_DeleteShow.Checked;
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0)
            {
                if (this.uGrid_MessageDel.ActiveRow != null)
                {
                    infoCondtion = (string)this.uGrid_MessageDel.ActiveRow.Cells[INQCONDITION_TITLEA].Value;
                }
            }         
            //削除済みデータの表示
            if (isDeleteShow)
            {
                editBand.Columns[DELETE_DATE].Hidden = false;
                this.uGrid_MessageDel.DataSource = this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                _showDeleBtFlg = true;
            }
            else
            {
                editBand.Columns[DELETE_DATE].Hidden = true;
                if (this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count > 0)
                {
                    this.uGrid_MessageDel.DataSource = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                    _showDeleBtFlg = true;
                }
                else
                {
                    this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                    this.tEdit_PccMailDocCnts.Text = string.Empty;
                    this.tEdit_PccMailTitle.Text = string.Empty;
                    _showDeleBtFlg = false;
                }
            }
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0)
            {
                for (int i = 0; i < this.uGrid_MessageDel.Rows.Count; i++)
                {
                    string infoCondtionNew = (string)this.uGrid_MessageDel.Rows[i].Cells[INQCONDITION_TITLEA].Value;
                    if (infoCondtionNew.Equals(infoCondtion))
                    {
                        avtiveIndex = i;
                        break;
                    }
                }
                this._messageDelDataIndex = avtiveIndex;
                this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
            }
            else
            {
                this.tEdit_PccMailDocCnts.Text = string.Empty;
                this.tEdit_PccMailTitle.Text = string.Empty;

            }
            //画面許可制御処理
            ScreenInputPermissionControl();
        }

        /// <summary>メインツールバーマネージャーToolClick</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// Note       : メインツールバーマネージャーのToolClick処理です。<br />
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //アクティブ状態になっているツールのフォーカスをクリアする
            e.Tool.IsActiveTool = false;
            switch (e.Tool.Key)
            {
                // 閉じるボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                //次得意先ボタン
                case "ButtonTool_NextCustomer":
                    {
                        this.NextCustomerProc();
                        break;
                    }
                //前得意先ボタン
                case "ButtonTool_PreCustomer":
                    {
                        this.PreCustomerProc();
                        break;
                    }
                //次表示ボタン
                case "ButtonTool_NextShow":
                    {
                        this.NextShowProc();
                        break;
                    }
                //前表示ボタン
                case "ButtonTool_PreShow":
                    {
                        this.PreShowProc();
                        break;
                    }
                //削除ボタン
                case "ButtonTool_Delete":
                    {
                        this.DeleteProc();
                        break;
                    }
                //新規作成ボタン
                case "ButtonTool_New":
                    {
                        this.NewProc();
                        break;
                    }
            }
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            string message = string.Empty;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
           
            switch (prevCtrl.Name)
            {
                //得意先グリッド
                case "uGrid_Customer":
                    {
                        
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = tDateEdit_UpdateDateSt;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = uCheckEditor_DeleteShow;
                            }
                        }
                        break;
                    }
                //メール履歴一覧グリッド
                case "uGrid_MessageDel":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = uCheckEditor_DeleteShow;
                            }
                        }
                        else
                        {
                            {
                                e.NextCtrl = tDateEdit_UpdateDateEd;
                            }
                        }
                        break;
                    }
                //対象日開始
                case "tDateEdit_UpdateDateSt":
                    {
                        if (!("tDateEdit_UpdateDateEd".Equals(e.NextCtrl.Name)))
                        {
                            Control errControl = null;

                            bool result = this.ScreenInputCheck(out message, ref errControl);
                            if (!result)
                            {
                                // メッセージを表示
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, message, -1, MessageBoxButtons.OK);
                                e.NextCtrl = errControl;
                                return;
                            }
                            else
                            {
                                PccMailDt parsePccMailDt = new PccMailDt();
                                parsePccMailDt.InqOtherEpCd = this._erterpriseCode;
                                parsePccMailDt.InqOtherSecCd = this._sectionCode;
                                parsePccMailDt.UpdateDateSt = tDateEdit_UpdateDateSt.GetLongDate();
                                parsePccMailDt.UpdateDateEd = tDateEdit_UpdateDateEd.GetLongDate();
                                if (preDateSt != this.tDateEdit_UpdateDateSt.GetLongDate() || preDateEd != this.tDateEdit_UpdateDateEd.GetLongDate())
                                {
                                    if (this._pccMailDtAcs == null)
                                    {
                                        _pccMailDtAcs = new PccMailDtAcs();
                                    }

                                    //前対象日開始
                                    preDateSt = this.tDateEdit_UpdateDateSt.GetLongDate();
                                    //前対象日終了
                                    preDateEd = this.tDateEdit_UpdateDateEd.GetLongDate();
                                    int status = this._pccMailDtAcs.Search(ref this._pccMailDtDic, parsePccMailDt, 0, ConstantManagement.LogicalMode.GetData01);
                                    // メール履歴一覧データセット
                                    this._messageDelDataIndex = -1;
                                    this.InitPccMailDtDate();
                                    this.timer_Slide.Enabled = true;
                                }

                            }

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = tDateEdit_UpdateDateEd;
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = uGrid_Customer;
                                }
                            }
                        }
                        break;
                    }
                //対象日終了
                case "tDateEdit_UpdateDateEd":
                    {
                        if (!("tDateEdit_UpdateDateSt".Equals(e.NextCtrl.Name)))
                        {
                            Control errControl = null;
                            bool result = this.ScreenInputCheck(out message, ref errControl);
                            if (!result)
                            {
                                // メッセージを表示
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, message, -1, MessageBoxButtons.OK);
                                e.NextCtrl = errControl;
                                return;
                            }
                            else
                            {
                                PccMailDt parsePccMailDt = new PccMailDt();
                                parsePccMailDt.InqOtherEpCd = this._erterpriseCode;
                                parsePccMailDt.InqOtherSecCd = this._sectionCode;
                                parsePccMailDt.UpdateDateSt = tDateEdit_UpdateDateSt.GetLongDate();
                                parsePccMailDt.UpdateDateEd = tDateEdit_UpdateDateEd.GetLongDate();
                                if (preDateSt != this.tDateEdit_UpdateDateSt.GetLongDate() || preDateEd != this.tDateEdit_UpdateDateEd.GetLongDate())
                                {
                                    if (this._pccMailDtAcs == null)
                                    {
                                        _pccMailDtAcs = new PccMailDtAcs();
                                    }

                                    //前対象日開始
                                    preDateSt = this.tDateEdit_UpdateDateSt.GetLongDate();
                                    //前対象日終了
                                    preDateEd = this.tDateEdit_UpdateDateEd.GetLongDate();
                                    int status = this._pccMailDtAcs.Search(ref this._pccMailDtDic, parsePccMailDt, 0, ConstantManagement.LogicalMode.GetData01);
                                    // メール履歴一覧データセット
                                    this._messageDelDataIndex = -1;
                                    this.InitPccMailDtDate();
                                    this.timer_Slide.Enabled = true;                                   
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = uGrid_MessageDel;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = tDateEdit_UpdateDateSt;
                            }
                        }
                        
                        break;
                    }
            }

            switch (e.NextCtrl.Name)
            {
                //メール履歴一覧グリッド
                case "uGrid_MessageDel":
                    {
                        if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this._showDeleBtFlg)
                        {
                            this._preShowButton.SharedProps.Enabled = true;
                            this._nextShowButton.SharedProps.Enabled = true;
                            this._deleteButton.SharedProps.Enabled = true;
                        }
                        else
                        {
                            this._preShowButton.SharedProps.Enabled = false;
                            this._nextShowButton.SharedProps.Enabled = false;
                            this._deleteButton.SharedProps.Enabled = false;
                        }
                        break;
                    }

            }
        }

        /// <summary>
        ///  得意先グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       :  得意先グリッドセルアップデート前イベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_Customer_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            int rowIndex = ultraGrid.ActiveRow.Index;
            this._customerDataIndex = rowIndex;
            _messageDelDataIndex = -1;
            this.InitPccMailDtDate();
            //画面許可制御処理
            ScreenInputPermissionControl();
        }

        /// <summary>
        ///  メール履歴一覧グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       :  メール履歴一覧グリッドセルアップデート前イベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_MessageDel_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            int rowIndex = ultraGrid.ActiveRow.Index;
            this._messageDelDataIndex = rowIndex;
            string inqCondition = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;
            if (!string.IsNullOrEmpty(inqCondition))
            {
                if (this._messageDelHTable.ContainsKey(inqCondition))
                {
                    PccMailDt pccMailDt = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                    this.tEdit_PccMailDocCnts.Text = pccMailDt.PccMailDocCnts;
                    this.tEdit_PccMailTitle.Text = pccMailDt.PccMailTitle;
                }
                else
                {
                    this.tEdit_PccMailDocCnts.Text = string.Empty;
                    this.tEdit_PccMailTitle.Text = string.Empty;
                }
            } 
            //画面許可制御処理
            ScreenInputPermissionControl();
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドキーダウン時に発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
             //アクティブセルが存在するとき
            if (ultraGrid.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                    this.uGrid_MessageDel.Focus();
                    if (this.uGrid_MessageDel.ActiveRow == null && this.uGrid_MessageDel.Rows.Count > 0)
                    {
                        this.uGrid_MessageDel.Rows[0].Activated = true;
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドキーダウン時に発生します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void uGrid_MessageDel_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if (ultraGrid == null)
            {
                return;
            }
            //アクティブセルが存在するとき
            if (ultraGrid.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Left)
                {
                    e.Handled = true;
                    this.uGrid_Customer.Focus();
                    if ( this.uGrid_Customer.ActiveRow == null && this.uGrid_Customer.Rows.Count > 0)
                    {
                        this.uGrid_Customer.Rows[0].Activated = true;
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }
            }
        }
        #endregion
        
        #region ■Private Methods
        
        /// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 黄海霞</br>
		/// <br>Date       : 2011.07.20</br>
		/// </remarks>
        private void ScreenInputPermissionControl()
        {
            if (this.uGrid_Customer != null && this.uGrid_Customer.Rows.Count > 0)
            {
                _nextCustomerButton.SharedProps.Enabled = true;
                _preCustomerButton.SharedProps.Enabled = true;
                _newButton.SharedProps.Enabled = true;
            }
            else
            {
                _nextCustomerButton.SharedProps.Enabled = false;
                _preCustomerButton.SharedProps.Enabled = false;

                _newButton.SharedProps.Enabled = false;
            }

            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && _showDeleBtFlg && this.uGrid_MessageDel.ActiveRow != null)
            {
                _preShowButton.SharedProps.Enabled = true;
                _nextShowButton.SharedProps.Enabled = true;
                _deleteButton.SharedProps.Enabled = true;
            }
            else
            {
                _preShowButton.SharedProps.Enabled = false;
                _nextShowButton.SharedProps.Enabled = false;
                _deleteButton.SharedProps.Enabled = false;
            }
           
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._nextCustomerButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
            this._preCustomerButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._nextShowButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT2;
            this._preShowButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE2;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// 得意先グリッドの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitCustomerDateSet()
        {
            _customerDateSet = new DataSet();
            
            // テーブルの定義
            DataTable customerDt = new DataTable(CUSTOMER_TABLE);
            customerDt.Columns.Add(PCCCUSTOMERCODE_TITLE, typeof(int));
            customerDt.Columns.Add(PCCCUSTOMERNAME_TITLE, typeof(string));
            customerDt.Columns.Add(INQCONDITION_TITLEB, typeof(string));
            this._customerDateSet.Tables.Add(customerDt);
               
        }

        /// <summary>
        /// メール履歴一覧グリッドの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール履歴一覧グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitMessageDelDateSet()
        {
            _messageDelAllDateSet = new DataSet();
            // テーブルの定義
            DataTable messageDelDt = new DataTable(MESSAGEDEL_TABLE);
            messageDelDt.Columns.Add(DELETE_DATE, typeof(string));
            messageDelDt.Columns.Add(PCCMAILTITLE_TITLE, typeof(string));
            messageDelDt.Columns.Add(UPDATEDATETIME_TITLE, typeof(string));
            messageDelDt.Columns.Add(INQCONDITION_TITLEA, typeof(string));
            this._messageDelAllDateSet.Tables.Add(messageDelDt);

        }

        /// <summary>
        /// メールがないのデータセットの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : メールがないのデータセットの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitMailNoDateSet()
        {
            this._messageNoFileDateSet = this._messageDelAllDateSet.Copy();
            PccMailDt pm = new PccMailDt();
            pm.PccMailTitle = MAIL_NOTEXSIT_MSG;
            pm.UpdateDate = 0;
            pm.UpdateTime = 0;
            PccMailDtToDataSet(this._messageNoFileDateSet, pm.Clone(), 0);
        }

        /// <summary>
        /// 得意先グリッドの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitCustomerGrid()
        {
            if (_customerDateSet.Tables[CUSTOMER_TABLE] != null)
            {
                this.uGrid_Customer.DataSource = _customerDateSet.Tables[CUSTOMER_TABLE].DefaultView;
                UltraGridBand editBand = this.uGrid_Customer.DisplayLayout.Bands[CUSTOMER_TABLE];
                this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //列の表示Style設定
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Header.Caption = PCCCUSTOMERCODE_TITLE;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].Header.Caption = PCCCUSTOMERNAME_TITLE;
                editBand.Columns[INQCONDITION_TITLEB].Header.Caption = INQCONDITION_TITLEB;

                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Hidden = true;
                editBand.Columns[INQCONDITION_TITLEB].Hidden = true;

               
            }
        }

        /// <summary>
        /// メール履歴一覧グリッドの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール履歴一覧グリッドの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitMessageDelGrid()
        {
            if (_messageDelAllDateSet.Tables[MESSAGEDEL_TABLE] != null)
            {
                this._messageDelDateSet = _messageDelAllDateSet.Copy();
                _messageDataView = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                _messageDataView.RowFilter = DELETE_DATE + "= ''";
                this.uGrid_MessageDel.DataSource = _messageDataView;
                UltraGridBand editBand = this.uGrid_MessageDel.DisplayLayout.Bands[MESSAGEDEL_TABLE];
                this.uGrid_MessageDel.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                this.uGrid_MessageDel.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //列の表示Style設定
                editBand.Columns[DELETE_DATE].Header.Caption = DELETE_DATE;
                editBand.Columns[PCCMAILTITLE_TITLE].Header.Caption = PCCMAILTITLE_TITLE;
                editBand.Columns[UPDATEDATETIME_TITLE].Header.Caption = UPDATEDATETIME_TITLE;
                editBand.Columns[INQCONDITION_TITLEA].Header.Caption = INQCONDITION_TITLEA;

                editBand.Columns[DELETE_DATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[DELETE_DATE].CellAppearance.ForeColor = System.Drawing.Color.Red;
                
                editBand.Columns[PCCMAILTITLE_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[UPDATEDATETIME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[PCCMAILTITLE_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[UPDATEDATETIME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[INQCONDITION_TITLEA].Hidden = true;
                editBand.Columns[DELETE_DATE].Hidden = true;
                
                
                editBand.Columns[DELETE_DATE].Width = 100;
                editBand.Columns[PCCMAILTITLE_TITLE].Width = 421;
                editBand.Columns[UPDATEDATETIME_TITLE].Width = 200;
            }
        }

        /// <summary>
        /// 得意先グリッドデータの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先グリッドデータの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitCustomerDate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._erterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._sectionCode;
            List<PccCmpnySt> pccCmpnyStList = null;
            int index = 0;
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._customerHTable == null)
                {
                    this._customerHTable = new Hashtable();
                }
                else
                {
                    this._customerHTable.Clear();
                }
                string inqCondition = string.Empty;
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    //ベース設定対象外
                    if(string.IsNullOrEmpty(pccCmpnySt.InqOriginalEpCd.Trim()) || string.IsNullOrEmpty(pccCmpnySt.InqOriginalSecCd.TrimEnd())) //@@@@20230303
                    {
                        continue;
                    }
                    inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                        + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                    if (!this._customerHTable.ContainsKey(inqCondition))
                    {
                        // クラスデータセット展開処理
                        PccCmpnyStToDataSet(pccCmpnySt.Clone(), index);
                        index++;
                    }
                    
                }
                this._customerDataIndex = 0;
                this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
            }
        }

        /// <summary>
        /// 得意先グリッドデータセット展開処理
        /// </summary>
        /// <param name="pccCmpnySt">PCC自社設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 得意先グリッドデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PccCmpnyStToDataSet(PccCmpnySt pccCmpnySt, int index)
        {
            string inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
            if ((index < 0) || (this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this._customerDateSet.Tables[CUSTOMER_TABLE].NewRow();
                this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count - 1;
            }

            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERCODE_TITLE] = pccCmpnySt.PccCompanyCode;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERNAME_TITLE] = pccCmpnySt.PccCompanyName;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][INQCONDITION_TITLEA] = inqCondition;

            if (this._customerHTable.ContainsKey(inqCondition))
            {
                this._customerHTable.Remove(inqCondition);
            }
            this._customerHTable.Add(inqCondition, pccCmpnySt);

        }

        /// <summary>
        /// メール履歴一覧グリッドデータの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール履歴一覧グリッドデータの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void GetPccMailDtDic()
        {
            PccMailDt parsePccMailDt = new PccMailDt();
            parsePccMailDt.InqOtherEpCd = this._erterpriseCode;
            parsePccMailDt.InqOtherSecCd = this._sectionCode;
            parsePccMailDt.UpdateDateSt = tDateEdit_UpdateDateSt.GetLongDate();
            parsePccMailDt.UpdateDateEd = tDateEdit_UpdateDateEd.GetLongDate();
            if (this._pccMailDtAcs == null)
            {
                _pccMailDtAcs = new PccMailDtAcs();
            }
            int status = this._pccMailDtAcs.Search(ref this._pccMailDtDic, parsePccMailDt, 0, ConstantManagement.LogicalMode.GetData01);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // メール履歴一覧データセット
                this._messageDelDataIndex = -1;
                this.InitPccMailDtDate();
                ScreenInputPermissionControl();
            }
            
        }

        /// <summary>
        /// メール履歴一覧グリッドデータの初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : メール履歴一覧グリッドデータの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitPccMailDtDate()
        {
           Dictionary<string, PccMailDt> pccMailDtDic = null;
            string inqConditionCus = string.Empty;
            int index = 0;
            this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Clear();
            this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Clear();
            
             PccCmpnySt pccCmpnySt = null;
            if (this._customerDataIndex >= 0)
            {
                string guid = (string)this.uGrid_Customer.Rows[this._customerDataIndex].Cells[INQCONDITION_TITLEB].Value;
                pccCmpnySt = ((PccCmpnySt)this._customerHTable[guid]).Clone();
                inqConditionCus = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                //PCCメールデータ
                if (this._pccMailDtDic != null && this._pccMailDtDic.ContainsKey(inqConditionCus))
                {
                    pccMailDtDic = this._pccMailDtDic[inqConditionCus];
                }
                
            }

            if (pccMailDtDic != null && pccMailDtDic.Count > 0)
            {
                if (this._messageDelHTable == null)
                {
                    this._messageDelHTable = new Hashtable();
                }
                else
                {
                    this._messageDelHTable.Clear();
                }

                string inqCondition = string.Empty;
                foreach (KeyValuePair<string, PccMailDt> pccMailDtPair in pccMailDtDic)
                {
                    PccMailDt pccMailDt = pccMailDtPair.Value;
                    inqCondition = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd() + pccMailDt.UpdateDate + pccMailDt.UpdateTime;
                    if (!this._messageDelHTable.ContainsKey(inqCondition))
                    {
                        PccMailDtToDataSet(this._messageDelAllDateSet, pccMailDt.Clone(), index);
                        if (pccMailDt.LogicalDeleteCode == 0)
                        {
                            PccMailDtToDataSet(this._messageDelDateSet, pccMailDt.Clone(), index);
                        }
                        index++;
                    }
                   
                    // クラスデータセット展開処理
                }
                bool messShowFlag = false;
                int messShowIndex = 0;
                //削除済みデータの表示しない
                if (uCheckEditor_DeleteShow.Checked == false)
                {
                    PccMailDt pccMailDtLog = null;
                    string guidLog = string.Empty;
                    for (int i = 0; i < this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count; i++)
                    { //論理削除区分=1:論理削除
                        guidLog = (string)this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[i][INQCONDITION_TITLEA];
                        pccMailDtLog = ((PccMailDt)this._messageDelHTable[guidLog]).Clone();

                        if (pccMailDtLog.LogicalDeleteCode == 0)
                        {
                            messShowFlag = true;
                            messShowIndex = i;
                            break;
                        }
                    }
                    if (messShowFlag)
                    {
                        this.uGrid_MessageDel.DataSource = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                        this._messageDelDataIndex = messShowIndex;
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                        guidLog = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;
                        pccMailDtLog = ((PccMailDt)this._messageDelHTable[guidLog]).Clone();

                        this.tEdit_PccMailDocCnts.Text = pccMailDtLog.PccMailDocCnts;
                        this.tEdit_PccMailTitle.Text = pccMailDtLog.PccMailTitle;
                        this._showDeleBtFlg = true;
                        
                    }
                    else
                    {
                        this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                        this.tEdit_PccMailDocCnts.Text = string.Empty;
                        this.tEdit_PccMailTitle.Text = string.Empty;
                        this._showDeleBtFlg = false;
                       
                    }
                }
                else
                {
                    this._messageDelDataIndex = 0;
                    if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0)
                    {
                        this.uGrid_MessageDel.DataSource = this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                        string guidLog2 = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;
                        PccMailDt pccMailDtFirst = ((PccMailDt)this._messageDelHTable[guidLog2]).Clone();

                        this.tEdit_PccMailDocCnts.Text = pccMailDtFirst.PccMailDocCnts;
                        this.tEdit_PccMailTitle.Text = pccMailDtFirst.PccMailTitle;
                        this._showDeleBtFlg = true;
                    }
                }

            }
            else
            {
                this.tEdit_PccMailDocCnts.Text = string.Empty;
                this.tEdit_PccMailTitle.Text = string.Empty;
                this._showDeleBtFlg = false;
                this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
            }
            
               
        }

        /// <summary>
        ///メール履歴一覧グリッドデータセット展開処理
        /// </summary>
        /// <param name="messageDelAllDateSet">データセット</param>
        /// <param name="pccMailDt">PCCメールデータ</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : メール履歴一覧グリッドデータセットに格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PccMailDtToDataSet(DataSet messageDelAllDateSet, PccMailDt pccMailDt, int index)
        {
            string inqCondition = string.Empty;
            if (!string.IsNullOrEmpty(pccMailDt.InqOriginalEpCd.Trim()))	//@@@@20230303
            {
                 inqCondition = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                           + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd() + pccMailDt.UpdateDate + pccMailDt.UpdateTime;

            }
            else
            {
                inqCondition = "";
            }
            if ((index < 0) || (messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].NewRow();
                messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count - 1;
            }
            if (pccMailDt.LogicalDeleteCode == 0)
            {
                messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][DELETE_DATE] = pccMailDt.UpdateDateTimeJpInFormal;
            }

            messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][PCCMAILTITLE_TITLE] = pccMailDt.PccMailTitle;
            string time1 = string.Empty;
            string time2 = string.Empty;
            if (!MAIL_NOTEXSIT_MSG.Equals(pccMailDt.PccMailTitle.TrimEnd()))
            {
                time1 = TDateTime.LongDateToString("yyyy年MM月dd日", pccMailDt.UpdateDate);
                time2 = TDateTime.LongDateToString("HHmmssfff", "HH:mm:ss:fff", pccMailDt.UpdateTime);
                string time2Temp = pccMailDt.UpdateTime.ToString().PadLeft(9, '0').Substring(0, 6);
                time2 = time2Temp.Insert(2, ":").Insert(5, ":");
            }
            messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][UPDATEDATETIME_TITLE] = time1 + " " + time2;
            messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[index][INQCONDITION_TITLEB] = inqCondition;
            if (!string.IsNullOrEmpty(inqCondition))
            {
                if (this._messageDelHTable.ContainsKey(inqCondition))
                {
                    this._messageDelHTable.Remove(inqCondition);
                }           
                this._messageDelHTable.Add(inqCondition, pccMailDt);
             }

        }

        /// <summary>
        ///次得意先ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 次得意先ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void NextCustomerProc()
        {
            //グリッドBのカーソルを1つ下に移動,メール履歴一覧を更新する。
            if (this.uGrid_Customer != null && this.uGrid_Customer.Rows.Count > 0 && this.uGrid_Customer.ActiveRow != null)
            {
                int rowIndex = this.uGrid_Customer.ActiveRow.Index;
                if (rowIndex != this.uGrid_Customer.Rows.Count - 1)
                {
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activated = false;
                    this.uGrid_Customer.Selected.Rows.Clear();
                    this._customerDataIndex = rowIndex + 1;
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                    this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
                    //画面許可制御処理
                    ScreenInputPermissionControl();
                }
            }
        }

        /// <summary>
        ///前得意先ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 前得意先ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PreCustomerProc()
        {
            //グリッドBのカーソルを1つ下に移動,メール履歴一覧を更新する。
            if (this.uGrid_Customer != null && this.uGrid_Customer.Rows.Count > 0 && this.uGrid_Customer.ActiveRow != null)
            {
                int rowIndex = this.uGrid_Customer.ActiveRow.Index;
                if (rowIndex > 0)
                {
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activated = false;
                    this.uGrid_Customer.Selected.Rows.Clear();
                    this._customerDataIndex = rowIndex -1;
                    this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                    this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
                    //画面許可制御処理
                    ScreenInputPermissionControl();
                }
            }
        }

        /// <summary>
        ///次表示ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 次表示ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void NextShowProc()
        {
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this.uGrid_MessageDel.ActiveRow != null)
            {
                int rowIndex = this.uGrid_MessageDel.ActiveRow.Index;
                string inqCondition = string.Empty;
                if (rowIndex != this.uGrid_MessageDel.Rows.Count - 1)
                {
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = false;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activated = false;
                    this._messageDelDataIndex = rowIndex;
                    if (uCheckEditor_DeleteShow.Checked == false)
                    {
                        for (int i = rowIndex + 1; i < this.uGrid_MessageDel.Rows.Count; i++)
                        {
                            inqCondition = (string)this.uGrid_MessageDel.Rows[i].Cells[INQCONDITION_TITLEA].Value;

                            PccMailDt pccMailDtDl = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                            if (pccMailDtDl.LogicalDeleteCode == 0)
                            {
                                this._messageDelDataIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this._messageDelDataIndex = rowIndex + 1;
                    }
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                }
            }
        }

        /// <summary>
        ///前表示ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 前表示ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PreShowProc()
        {
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this.uGrid_MessageDel.ActiveRow != null)
            {
                int rowIndex = this.uGrid_MessageDel.ActiveRow.Index;
                string inqCondition = string.Empty;
                if (rowIndex > 0)
                {
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = false;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activated = false;
                    this._messageDelDataIndex = rowIndex;
                    if (uCheckEditor_DeleteShow.Checked == false)
                    {
                        for (int i = rowIndex - 1; i >= 0; i--)
                        {
                            inqCondition = (string)this.uGrid_MessageDel.Rows[i].Cells[INQCONDITION_TITLEA].Value;

                            PccMailDt pccMailDtDl = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                            if (pccMailDtDl.LogicalDeleteCode == 0)
                            {
                                this._messageDelDataIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        this._messageDelDataIndex = rowIndex - 1;
                    }
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                    this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                }
            }
        }

        /// <summary>
        ///削除ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 削除ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void DeleteProc()
        {
            if (this.uGrid_MessageDel != null && this.uGrid_MessageDel.Rows.Count > 0 && this.uGrid_MessageDel.ActiveRow != null)
            {
                DialogResult result = TMsgDisp.Show(
               this, 								// 親ウィンドウフォーム
               emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
               ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
               "データを削除します。" + "\r\n" +
               "よろしいですか？", 				// 表示するメッセージ
               0, 									// ステータス値
               MessageBoxButtons.YesNo,
               MessageBoxDefaultButton.Button2);	// 表示するボタン

                if (result != DialogResult.Yes)
                {
                    return;
                }
                //選択したの行
                int rowIndex = this.uGrid_MessageDel.ActiveRow.Index;
                this._messageDelDataIndex = rowIndex;
                string inqCondition = string.Empty;
                inqCondition = (string)this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Cells[INQCONDITION_TITLEA].Value;

                PccMailDt pccMailDt = ((PccMailDt)this._messageDelHTable[inqCondition]).Clone();
                PccMailDt pccMailDtOld = pccMailDt;
                int status = 0;
                if (pccMailDt.LogicalDeleteCode == 0)
                {
                    //選択中のメールを論理削除
                    status = this._pccMailDtAcs.LogicalDelete(ref pccMailDt);
                }
                else
                {
                    //選択中のメールが論理削除分の場合、物理削除
                    status = this._pccMailDtAcs.Delete(ref pccMailDt);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            string inqConditionFather = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                                + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd();
                            if (this._pccMailDtDic != null && this._pccMailDtDic.ContainsKey(inqConditionFather))
                            {
                                //DataSet更新
                                Dictionary<string,  PccMailDt> pccMailDtDicOld = this._pccMailDtDic[inqConditionFather];
                                if (pccMailDtDicOld != null && pccMailDtDicOld.ContainsKey(inqCondition))
                                {
                                    pccMailDtDicOld.Remove(inqCondition);
                                }
                                if (pccMailDtOld.LogicalDeleteCode == 0)
                                {
                                    pccMailDtDicOld.Add(inqCondition, pccMailDt);
                                    this.PccMailDtToDataSet(this._messageDelAllDateSet, pccMailDt, rowIndex);
                                    if (!this.uCheckEditor_DeleteShow.Checked)
                                    {
                                        // DataSet更新
                                        this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndex].Delete();

                                        if (this._messageDelDataIndex > 0)
                                        {
                                            this._messageDelDataIndex = this._messageDelDataIndex - 1;
                                            this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                                            this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                                            this._showDeleBtFlg = true;
                                            this.uGrid_MessageDel.DataSource = this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                        }
                                        else
                                        {
                                            this._messageDelDataIndex = -1;
                                            //メール表示更新
                                            this.tEdit_PccMailDocCnts.Text = string.Empty;
                                            this.tEdit_PccMailTitle.Text = string.Empty;
                                        }
                                        if (this._messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count == 0)
                                        {
                                            this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                            //メール表示更新
                                            this.tEdit_PccMailDocCnts.Text = string.Empty;
                                            this.tEdit_PccMailTitle.Text = string.Empty;
                                            this._showDeleBtFlg = false;
                                        }
                                    }
                                    else
                                    {
                                        //_messageDelDateSet更新
                                        if (_messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count > 0)
                                        {
                                            for (int rowIndexDel = 0; rowIndexDel < _messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count; rowIndexDel++)
                                            {
                                                String guidInqCondition = (string)_messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndexDel][INQCONDITION_TITLEB];
                                                if (inqCondition.Equals(guidInqCondition))
                                                {
                                                    _messageDelDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndexDel].Delete();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // _messageDelAllDateSetDataSet更新
                                    this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows[rowIndex].Delete();
                                    // ハッシュテーブルから削除します
                                    if (this._messageDelHTable.ContainsKey(inqCondition) == true)
                                    {
                                        this._messageDelHTable.Remove(inqCondition);
                                    }
                                    
                                    if (this._messageDelDataIndex > 0)
                                    {
                                        _showDeleBtFlg = true;
                                        this._messageDelDataIndex = this._messageDelDataIndex - 1;
                                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Activate();
                                        this.uGrid_MessageDel.Rows[this._messageDelDataIndex].Selected = true;
                                        this.uGrid_MessageDel.DataSource = this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                    }
                                    else
                                    {
                                        this._messageDelDataIndex = -1;
                                        //メール表示更新
                                        this.tEdit_PccMailDocCnts.Text = string.Empty;
                                        this.tEdit_PccMailTitle.Text = string.Empty;
                                    }
                                    if (this._messageDelAllDateSet.Tables[MESSAGEDEL_TABLE].Rows.Count == 0)
                                    {
                                        _showDeleBtFlg = false;
                                        this._deleteButton.SharedProps.Enabled = _showDeleBtFlg;
                                        this._preShowButton.SharedProps.Enabled = _showDeleBtFlg;
                                        this._nextShowButton.SharedProps.Enabled = _showDeleBtFlg;
                                        this.uGrid_MessageDel.DataSource = this._messageNoFileDateSet.Tables[MESSAGEDEL_TABLE].DefaultView;
                                        //メール表示更新
                                        this.tEdit_PccMailDocCnts.Text = string.Empty;
                                        this.tEdit_PccMailTitle.Text = string.Empty;
                                    }
                                }
                                this._pccMailDtDic.Remove(inqConditionFather);
                                this._pccMailDtDic.Add(inqConditionFather, pccMailDtDicOld);
                            }

                           break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // 排他処理
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccMailDtAcs);
                            // クラスデータセット展開処理
                            break;
                        }
                    case -2:
                        {
                            //主作業設定で使用中
                            TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                ASSEMBLY_ID,
                                "このレコードは主作業設定で使用されているため削除できません",
                                status,
                                MessageBoxButtons.OK);
                            this.Hide();
                            break;
                        }

                    default:
                        {
                            TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                this.Text,							// プログラム名称
                                "Delete",							// 処理名称
                                TMsgDisp.OPE_HIDE,					// オペレーション
                                ERR_RDEL_MSG,						// 表示するメッセージ 
                                status,								// ステータス値
                                this._pccMailDtAcs,					// エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                            // クラスデータセット展開処理
                            break;
                            
                        }
                }
                ScreenInputPermissionControl();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_800_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_801_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        ///新規作成ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規作成ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void NewProc()
        {
            PMPCC01001UB pMPCC01001UB = new PMPCC01001UB();
            pMPCC01001UB.ShowDialog();
            DialogResult dialogResult = pMPCC01001UB.DialogResult;
            if (DialogResult.OK == dialogResult)
            {
                this.GetPccMailDtDic();
            }
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.10.14</br>
        /// </remarks>
        private bool ScreenInputCheck(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;
            //エラー条件メッセージ
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_InputPlease = "を入力してください。";
            //生産日付範囲チェック
            DateGetAcs.CheckDateRangeResult cdrResult;

            if (CallCheckDateRange(out cdrResult, ref tDateEdit_UpdateDateSt, ref tDateEdit_UpdateDateEd) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("開始日{0}", ct_InputError);
                            errControl = this.tDateEdit_UpdateDateSt;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("開始日{0}", ct_InputPlease);
                            errControl = this.tDateEdit_UpdateDateSt;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("終了日{0}", ct_InputError);
                            errControl = this.tDateEdit_UpdateDateEd;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("終了日{0}", ct_InputPlease);
                            errControl = this.tDateEdit_UpdateDateEd;
                            result = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("日付{0}", ct_RangeError);
                            errControl = this.tDateEdit_UpdateDateEd;
                            result = false;
                        }
                        break;
                }
                return result;
            }
            return true;
        }

        /// <summary>
        /// 日付チェック処理呼び出し（未入力対象外）
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_Date"></param>
        /// <param name="tde_Ed_Date"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_Date, ref TDateEdit tde_Ed_Date)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_Date, ref tde_Ed_Date, false);

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion
    }
}