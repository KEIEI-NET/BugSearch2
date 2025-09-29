//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC-UOEメールメッセージ新規作成
// プログラム概要   : PCC-UOEメールメッセージ新規作成を行う
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
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC-UOEメールメッセージ新規作成フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC-UOEメールメッセージ新規作成のフォームクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.08</br>
    /// <br></br>
    /// </remarks>
    public partial class PMPCC01001UB : Form
    {
        # region ■Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMPCC01001UB()
        {
            InitializeComponent();
            //企業コード
            _erterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Cancel"];
            this._sendButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Send"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ログイン担当者
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._pccMailDtAcs = new PccMailDtAcs();
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        # region ■Private Members
        private PccMailDtAcs _pccMailDtAcs;
       
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // キャンセルボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _sendButton;            // 送信ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称
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
        /// PCC自社設定マスタメンテアクセスクラス
        /// </summary>
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        /// <summary>
        /// 得意先データの番号
        /// </summary>
        private int _customerDataIndex;
        // 得意先テープル
        private Hashtable _customerHTable;
        /// <summary>
        /// 初期化のリスト
        /// </summary>
        private List<PccMailDt> _pccMailDtListOld;
        #endregion

        #region ■Const Members
        private const string ASSEMBLY_ID = "PMPCC01001U";

        private const string BLSELECT_TITLE = "SELECT";
        private const string BLSELECT_NAME = "";
        private const string PCCCUSTOMERCODE_TITLE = "PCC得意先コード";
        private const string PCCCUSTOMERNAME_TITLE = "PCC得意先";
        //問合せ条件B
        private const string INQCONDITION_TITLEB = "GUID";
        private const string CUSTOMER_TABLE = "CUSTOMER_TABLE";
        private const string INF_NOT_FOUND = "該当するデータがありません。";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
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
        private void PMPCC01001UB_Load(object sender, EventArgs e)
        {
            // ボタン初期設定処理
            this.ButtonInitialSetting();
            //得意先グリッドの初期化
            InitCustomerDateSet();
            InitCustomerGrid();
            InitCustomerDate();
            // 初期化フォーカス設定
            this.uCheckEditor_SelectAll.Focus();
            this.tEdit_PccMailDocCnts.Value = string.Empty;
            this.tEdit_PccMailTitle.Value = string.Empty;
            DispToPccMailDt(out this._pccMailDtListOld);
            uCheckEditor_SelectAll.Focus();
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
                case "ButtonTool_Cancel":
                    {
                        this.CloseProc();
                        break;
                    }
                //次得意先ボタン
                case "ButtonTool_Send":
                    {
                        this.SendProc();
                        break;
                    }
            }
        }

        /// <summary>
        ///全てにチェック イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 全てにチェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void uCheckEditor_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uGrid_Customer == null || this.uGrid_Customer.Rows.Count == 0)
            {
                return;
            }
            int gridCount = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count;
            for (int i = 0; i < gridCount; i++)
            {
                DataRow dataRow = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[i];
                dataRow[BLSELECT_TITLE] = uCheckEditor_SelectAll.Checked;
            }
        }

        #endregion

        #region ■Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタンの初期化を行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._sendButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
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
            customerDt.Columns.Add(BLSELECT_TITLE, typeof(bool));
            customerDt.Columns.Add(PCCCUSTOMERCODE_TITLE, typeof(int));
            customerDt.Columns.Add(PCCCUSTOMERNAME_TITLE, typeof(string));
            customerDt.Columns.Add(INQCONDITION_TITLEB, typeof(string));
            this._customerDateSet.Tables.Add(customerDt);

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
                editBand.Columns[BLSELECT_TITLE].Header.Caption = BLSELECT_NAME;
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Header.Caption = PCCCUSTOMERCODE_TITLE;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].Header.Caption = PCCCUSTOMERNAME_TITLE;
                editBand.Columns[INQCONDITION_TITLEB].Header.Caption = INQCONDITION_TITLEB;

                //グリッドタイプ
                editBand.Columns[BLSELECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                editBand.Columns[BLSELECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                
                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Hidden = true;
                editBand.Columns[INQCONDITION_TITLEB].Hidden = true;

                //初期化値の設定
                editBand.Columns[BLSELECT_TITLE].DefaultCellValue = false;
                editBand.Columns[BLSELECT_TITLE].Width = 10;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].Width = 125;
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
                    if (string.IsNullOrEmpty(pccCmpnySt.InqOriginalEpCd.Trim()) || string.IsNullOrEmpty(pccCmpnySt.InqOriginalSecCd.TrimEnd())) //@@@@20230303
                    {
                        continue;
                    }
                    inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                        + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                    if (!this._customerHTable.ContainsKey(inqCondition))
                    {
                        PccCmpnyStToDataSet(pccCmpnySt.Clone(), index);
                        index++;
                    }
                    // クラスデータセット展開処理
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
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][BLSELECT_TITLE] = false;
            
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERCODE_TITLE] = pccCmpnySt.PccCompanyCode;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERNAME_TITLE] = pccCmpnySt.PccCompanyName;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][INQCONDITION_TITLEB] = inqCondition;

            if (this._customerHTable.ContainsKey(inqCondition))
            {
                this._customerHTable.Remove(inqCondition);
            }
            this._customerHTable.Add(inqCondition, pccCmpnySt);

        }

        /// <summary>
        ///キャンセルボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンセルボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        public void CloseProc()
        {
            List<PccMailDt> pccMailDtList = null;
            //画面情報メールメッセージ格納処理
            DispToPccMailDt(out pccMailDtList);
            if (pccMailDtList != null && this._pccMailDtListOld != null)
            {
                bool isEquals = ListCompare(pccMailDtList);
                 if (!isEquals)
               {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "編集中のデータがあります。" + "\r\n" + 
                        "廃棄してもよろしいですか？",	// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {   
                                break;
                            }
                        case DialogResult.No:
                            {                               
                                return;
                            }
                        default:
                            {
                                uCheckEditor_SelectAll.Focus();                                
                                return;
                            }
                    }
                }

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// 画面PCC品目グループクラス比較
        /// </summary>
        /// <param name="pccMailDtList">画面メールメッセージリスト</param>
        /// <remarks>
        /// <br>Note       : 画面PCC品目グループクラスを比較します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ListCompare(List<PccMailDt> pccMailDtList)
        {
            bool isEqualsValue = true;
            if (pccMailDtList.Count != this._pccMailDtListOld.Count)
            {
                isEqualsValue = false;
                return isEqualsValue;
            }
            for(int i = 0; i < pccMailDtList.Count; i++)
            {
                if(!pccMailDtList[i].Equals(this._pccMailDtListOld[i]))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
            }
            if (!string.IsNullOrEmpty(this.tEdit_PccMailTitle.DataText) || !string.IsNullOrEmpty(this.tEdit_PccMailDocCnts.DataText))
            {
                 isEqualsValue = false;
                    return isEqualsValue;
            }
            return isEqualsValue;
        }

        /// <summary>
        /// 画面情報メールメッセージ格納処理
        /// </summary>
        /// <param name="pccMailDtList">メールメッセージデータリスト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からメールメッセージ格納処理にデータを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08 </br>
        /// </remarks>
        private void DispToPccMailDt(out List<PccMailDt> pccMailDtList)
        {
            int gridCount = this.uGrid_Customer.Rows.Count;
            PccCmpnySt pccCmpnySt = null;            
            pccMailDtList = null;
            if (gridCount > 0)
            {
               pccMailDtList = new List<PccMailDt>();
               for (int i = 0; i < gridCount; i++)
               {
                   UltraGridRow dataRow = this.uGrid_Customer.Rows[i];
                   bool checkedFlag = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                   bool dataChecked = (bool)dataRow.Cells[BLSELECT_TITLE].DataChanged;

                   if (!checkedFlag && !dataChecked)
                   {
                       continue;
                   }
                   else
                   {
                       SetPccMailDt(pccCmpnySt, pccMailDtList, i);
                   }
               }
            }
        }

        /// <summary>
        ///画面情報メールメッセージ格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報からメールメッセージ格納処理にデータを格納します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void SetPccMailDt(PccCmpnySt pccCmpnySt, List<PccMailDt> pccMailDtList,int i)
        {           
            string inqConditionCus = string.Empty;
            string guid = (string)this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[i][INQCONDITION_TITLEB];
            pccCmpnySt = ((PccCmpnySt)this._customerHTable[guid]).Clone();
            inqConditionCus = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                   + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();

            PccMailDt pccMailDt = new PccMailDt();
            pccMailDt.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
            pccMailDt.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
            pccMailDt.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
            pccMailDt.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
            pccMailDt.UpdateDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            pccMailDt.UpdateTime = Convert.ToInt32(DateTime.Now.ToString("HHmmssfff"));
            pccMailDt.PccMailTitle = tEdit_PccMailTitle.Text.TrimEnd();
            pccMailDt.PccMailDocCnts = tEdit_PccMailDocCnts.Text.TrimEnd();
            pccMailDtList.Add(pccMailDt);
        }

        /// <summary>
        ///送信ボタン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信ボタンを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        public void SendProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //入力チェックを行う。
            string message = string.Empty;
            Control control = null;
            uCheckEditor_SelectAll.Focus();
            
            
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return ;
            }
            List<PccMailDt> pccMailDtList = null;
            DispToPccMailDt(out pccMailDtList);
            if (pccMailDtList != null && pccMailDtList.Count > 0)
            {
                status = this._pccMailDtAcs.Write(ref pccMailDtList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.DialogResult = DialogResult.OK;
                            //WebSyncの機能によりサーバーにメッセージを送信する。
                            WebSyncProc(pccMailDtList);
                            this.Close();
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        {
                            TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                ERR_DPR_MSG,						// 表示するメッセージ 
                                status,								// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン
                            this.uCheckEditor_SelectAll.Focus();
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccMailDtAcs);
                            break;
                            
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                this.Text,							// プログラム名称
                                "SendProc",							// 処理名称
                                TMsgDisp.OPE_UPDATE,				// オペレーション
                                ERR_UPDT_MSG,						// 表示するメッセージ 
                                status,								// ステータス値
                                this._pccMailDtAcs,					// エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// WebSyncの機能によりサーバーにメッセージ送信。
        /// </summary>
        /// <param name="pccMailDtList">メールメッセージデータリスト</param>
        /// <remarks>
        /// <br>Note       : WebSyncの機能によりサーバーにメッセージを送信する。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void WebSyncProc(List<PccMailDt> pccMailDtList)
        {
            if (pccMailDtList != null && pccMailDtList.Count > 0)
            {
                foreach (PccMailDt pccMailDt in pccMailDtList)
                {
                    SCMChecker.NotifyOtherSidePCCUOEMessage(pccMailDt.InqOriginalEpCd.Trim(), pccMailDt.InqOriginalSecCd, pccMailDt.InqOtherEpCd, pccMailDt.InqOtherSecCd, pccMailDt.UpdateDate, pccMailDt.UpdateTime, pccMailDt.PccMailTitle, pccMailDt.PccMailDocCnts);//@@@@20230303
                }
            }
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool exsitTrue = false;
            //グリッドのチェックボックスが全てOFFの場合エラーとする。
            int gridCount = this.uGrid_Customer.Rows.Count;
            for (int i = 0; i < gridCount; i++)
            {
                UltraGridRow dataRow = this.uGrid_Customer.Rows[i];
                bool selected = (bool)this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[i][BLSELECT_TITLE];
                if (selected)
                {
                    exsitTrue = true;
                    break;
                }
            }
            if (!exsitTrue)
            {
                // 得意先コード
                control = this.uGrid_Customer;
                message = "宛先が選択されていません。";
                return (false);
            }
            if (string.IsNullOrEmpty(this.tEdit_PccMailTitle.Text.TrimEnd()) && string.IsNullOrEmpty(this.tEdit_PccMailDocCnts.Text.TrimEnd()))
            {
                // 件名
                control = this.tEdit_PccMailTitle;
                message = "件名、本文が未入力です。";
                return (false);
            }
            else if (string.IsNullOrEmpty(this.tEdit_PccMailTitle.Text.TrimEnd()))
            {
                // 件名
                control = this.tEdit_PccMailTitle;
                message = "件名が未入力です。";
                return (false);
            }
            else if (string.IsNullOrEmpty(this.tEdit_PccMailDocCnts.Text.TrimEnd()))
            {
                // 得本文
                control = this.tEdit_PccMailDocCnts;
                message = "本文が未入力です。";
                return (false);
            }
            string pccMailDocCnts = this.tEdit_PccMailDocCnts.Text.TrimEnd();
            string[] pccMailDocCntsArr = pccMailDocCnts.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (pccMailDocCntsArr.Length > 10)
            {
                // 得意先コード
                control = this.tEdit_PccMailDocCnts;
                message = "本文は10行以内で入力して下さい。";
                return (false);
            }
            return true;
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
        #endregion

    }
}