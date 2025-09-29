//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信履歴ログメンテ画面
// プログラム概要   : 送信履歴ログメンテ画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 作 成 日  2011/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/08/24  修正内容 : Redmine #23930 #23897 ソースレビュー結果対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/08/25  修正内容 : Redmine #23810 メセージ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/09/05  修正内容 : Redmine #24387 送信履歴ログメンテのUI改修依頼
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/09/14  修正内容 : Redmine #25051 #24952 送信履歴ログメンテ　データ表示の不正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 作 成 日  2011/11/01  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// 送信履歴ログメンテ画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : 送信履歴ログメンテ画面<br />
    /// Programmer : 丁建雄<br />
    /// Date       : 2011/08/01<br />
    /// Update     : <br />
    /// </remarks>
    public partial class PMKYO09401UA : Form
    {
        #region ■ Constructor ■
        public PMKYO09401UA()
        {
            InitializeComponent();
            InitialSetting();
        }
        #endregion ■ Constructor ■

        #region ■ Const Memebers ■
        private const String CHECK_BOX = "選択";
        private const String ENT_CODE_FROM = "送信元企業コード";
        private const String SECTION_FROM = "送信元拠点";
        private const String SEND_NO = "送信番号";
        private const String SEND_DATE = "送信日時";
        private const String DIV = "利用区分";
        private const String SEND_DIV = "送受信区分";
        private const String TYPE = "種別";
        private const String CONDITION_DIV = "抽出条件区分";
		// UPD 2011.09.05 ------->>>>>
		//private const String SECTION = "送信対象拠点";
		private const String SECTION = "抽出対象拠点";
		// UPD 2011.09.05 -------<<<<<
        private const String SECTION_TO = "送信先拠点";
        private const String ENT_CODE_TO = "送信先企業コード";
        private const String START_TIME = "送信対象開始日時";
        private const String END_TIME = "送信対象終了日時";
		private const String UPDATE_TIME = "更新日時";
		private const String CT_CLASSID = "PMKYO09401U";
        #endregion ■ Const Memebers ■ 

        #region ■ Private Field ■
        /// <summary>
        /// 送信履歴ログメンテ画面アクセスクラス
        /// </summary>
        private SndRcvHisAcs _SndRcvHisAcs;
        /// <summary>
        /// 抽出条件詳細画面
        /// </summary>
        private PMKYO09401UB _detailDialog;
        /// <summary>拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>
        /// 履歴グッリド
        /// </summary>
        private DataTable detailsTable;

        // 抽出情報LIST
        object searchResult;
        ArrayList sndRcvHisWorkList;    // 履歴情報
        ArrayList sndRcvEtrWorkList;    // 詳細履歴情報

        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _detailButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        #endregion ■ Private Field ■

        #region ■ Event ■
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 画面の終了
                case "ButtonTool_Close":
                    {
                        //画面閉じる。
                        this.Close();
                    }
                    break;

                // 画面の削除
                case "ButtonTool_Delete":
                    {
                        int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

                        object obj = this.GetCheckedRecord();

						// ADD 2011.08.24 ---------->>>>>
						ArrayList list = obj as ArrayList;
						if (0 == list.Count)
						{
							break;
						}						
						DialogResult result = TMsgDisp.Show(
			                      this, 								// 親ウィンドウフォーム
								  emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
								  //"PMKYO09401U",						// アセンブリＩＤまたはクラスＩＤ // DEL 2011.08.25
								  CT_CLASSID,// ADD 2011.08.25
								  "削除しますか？", 				// 表示するメッセージ
								  0, 									// ステータス値
								  MessageBoxButtons.YesNo,
								  MessageBoxDefaultButton.Button2);	// 表示するボタン

						if (result != DialogResult.Yes)
						{
							break;
						}

						// ADD 2011.08.24 ----------<<<<<
                        status = this._SndRcvHisAcs.Delete(ref obj);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
							//MessageBox.Show("削除中にエラーが発生しました。"); // DEL 2011.08.24
							// ADD 2011.08.24 --------->>>>>
							TMsgDisp.Show(this,                     // 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_STOP,     // エラーレベル
										//"PMKYO09401U",							// アセンブリID // DEL 2011.08.25
								        CT_CLASSID,// ADD 2011.08.25
										//"削除中にエラーが発生しました。",	    // 表示するメッセージ // DEL 2011.08.25
										"送信履歴データの削除に失敗しました。",  // ADD 2011.08.25
										status,									    // ステータス値
										MessageBoxButtons.OK);					// 表示するボタン
							// ADD 2011.08.24 ---------<<<<<

                        }
                        else
                        {
                            this.detailsTable.Clear();
                            this.RecordSearch();
                        }
                    }
                    break;

                //画面の検索
                case "ButtonTool_Search":
                    {
                        // チェックがエラーが発生しなっかた場合
                        if (this.DateCheck() == 0)
                        {
                            this.RecordSearch();
                        }
                    }
                    break;

                //抽出条件詳細
                case "ButtonTool_Detail":
                    {
                        if (this.searchResult != null)
                        {
                            this.SetDetailInfo();
                        }
                        else
                        {
							//MessageBox.Show("抽出条件詳細がない。"); // DEL 2011.08.24
							// ADD 2011.08.24 --------->>>>>
							TMsgDisp.Show(this,                     // 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
								        //"PMKYO09401U",							// アセンブリID // DEL 2011.08.25
								        CT_CLASSID,// ADD 2011.08.25
										//"抽出条件詳細がない。",	    // 表示するメッセージ  // DEL 2011.08.25
										"抽出条件詳細データが存在しません。",  // ADD 2011.08.25
										0,									    // ステータス値
										MessageBoxButtons.OK);					// 表示するボタン
							// ADD 2011.08.24 ---------<<<<<
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : 画面ロードイベント</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMKYO09401UA_Load(object sender, EventArgs e)
        {
            this.DataSetColumnConstruction();
            this.SetColumnStyle();
            this.ButtonInitialSetting();
        }

        /// <summary>
        /// レコードダブルクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoubleClickCellEventArgs</param>
        /// <remarks>
        /// <br>Note       : レコードダブルクリックイベント</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell != null && e.Cell.Column.Index != 0)
            {
                this.SetDetailInfo();
            }
        }

        /// <summary>
        /// レコードが活性になる使用するイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : レコードが活性になる使用するイベント</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = false;

            // 削除ボタンは活性にする。
            this.tToolbarsManager1.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

            SndRcvHisWork sndRcvHisWork = this.GetActiveRow();
            // 種別が「マスタ」、抽出条件データが「手動条件」の明細データを選択している場合
            if (sndRcvHisWork.Kind == 1 && sndRcvHisWork.SndLogExtraCondDiv == 1)
            {
                // 抽出条件詳細ボタンは活性にする。
                this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = true;
            }
        }
        #endregion ■ Event ■

        #region ■ Private Method ■
        /// <summary>
        /// 初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定処理です</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void InitialSetting()
        {
            // 送信履歴ログメンテ画面アクセスクラス
            _SndRcvHisAcs = new SndRcvHisAcs();

            _secInfoSetAcs = new SecInfoSetAcs();

            // 削除、抽出条件詳細ボタンは非活性。
            this.tToolbarsManager1.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = false;

            // 変数初期化
            //履歴グッリド
            detailsTable = new DataTable();
            this.tde_Start_Date.SetDateTime(DateTime.Now);
            this.tde_End_Date.SetDateTime(DateTime.Now);
            this._loginName = LoginInfoAcquisition.Employee.Name;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

			// 送受信区分
			this.tce_SendAndReceKubun.SelectedIndex = 0; // ADD 2011.09.02

            // ボタン変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Delete"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Search"];
            this._detailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Detail"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._detailButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager1.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット列情報構築処理です</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            this.detailsTable.Columns.Add(CHECK_BOX, typeof(bool));
			this.detailsTable.Columns.Add(ENT_CODE_FROM, typeof(string));
			this.detailsTable.Columns.Add(SECTION_FROM, typeof(string));			
			// ADD 2011.09.05 ------->>>>>
			this.detailsTable.Columns.Add(ENT_CODE_TO, typeof(string));
			this.detailsTable.Columns.Add(SECTION_TO, typeof(string));
			// ADD 2011.09.05 -------<<<<<
			
            this.detailsTable.Columns.Add(SEND_NO, typeof(string));
            this.detailsTable.Columns.Add(SEND_DATE, typeof(string));
            this.detailsTable.Columns.Add(DIV, typeof(string));
            this.detailsTable.Columns.Add(SEND_DIV, typeof(string));
            this.detailsTable.Columns.Add(TYPE, typeof(string));
            this.detailsTable.Columns.Add(CONDITION_DIV, typeof(string));
            this.detailsTable.Columns.Add(SECTION, typeof(string));
			// DEL 2011.09.05 ------->>>>>
			//this.detailsTable.Columns.Add(SECTION_TO, typeof(string));
			//this.detailsTable.Columns.Add(ENT_CODE_TO, typeof(string));
			// DEL 2011.09.05 -------<<<<<
            this.detailsTable.Columns.Add(START_TIME, typeof(string));
            this.detailsTable.Columns.Add(END_TIME, typeof(string));
            this.detailsTable.Columns.Add(UPDATE_TIME, typeof(string));

            this.uGrid_Details.DataSource = detailsTable;
        }

        /// <summary>
        /// レコードの列のスタイルの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レコードの列のスタイルの設定</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetColumnStyle()
        {
            
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 選択チェックボックス
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].Header.Fixed = true;

            // 固定列設定
            Columns[this.detailsTable.Columns[UPDATE_TIME].ColumnName].Hidden = true;
			// DEL 2011.09.14 ------->>>>>
			//// ADD 2011.09.05 ------->>>>>
			//Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Hidden = true;
			//Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Hidden = true;
			//// ADD 2011.09.05 -------<<<<<
			// DEL 2011.09.14 -------<<<<<

			// ADD 2011.09.14 ------->>>>>
			if ((int)this.tce_SendAndReceKubun.Value == 1)
			{
				Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].Hidden = false;
				Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].Hidden = false;
				Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Hidden = true;
				Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Hidden = true;
			}
			else
			{
				Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].Hidden = true;
				Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].Hidden = true;
				Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Hidden = false;
				Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Hidden = false;
			}
			// ADD 2011.09.14 -------<<<<<
            // 表示幅設定
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].Width = 50;
            Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SEND_DATE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[DIV].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SEND_DIV].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[TYPE].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[CONDITION_DIV].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[START_TIME].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[END_TIME].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[UPDATE_TIME].ColumnName].Width = 200;
          
            // 入力許可設定
			Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].CellClickAction = CellClickAction.CellSelect;
			Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_DATE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[CONDITION_DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[START_TIME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_TIME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[UPDATE_TIME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }

        /// <summary>
        /// 履歴情報を検索、画面で表示する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 履歴情報を検索、画面で表示する</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void RecordSearch()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this.detailsTable.Clear();
            SndRcvHisCondWork sndRcvHisCondWork = null;
            sndRcvHisWorkList = new ArrayList();
            sndRcvEtrWorkList = new ArrayList();
			SndRcvHisAcs sndRcvHisAcs = new SndRcvHisAcs(); // ADD 2011.08.24
            this.ScreenToSndRcvHisCondWork(out sndRcvHisCondWork);

            status = this._SndRcvHisAcs.Serch(sndRcvHisCondWork, out searchResult);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList resultList = searchResult as ArrayList;

                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i].GetType() == typeof(SndRcvHisWork))
                    {
                        DataRow row = this.detailsTable.NewRow();
                        SndRcvHisWork work = (SndRcvHisWork)resultList[i];
                        sndRcvHisWorkList.Add(work);    // 履歴情報LISTに追加する

                        row[detailsTable.Columns[CHECK_BOX].ColumnName] = false;
                        row[detailsTable.Columns[ENT_CODE_FROM].ColumnName] = work.EnterpriseCode;                   // 送信元企業コード
						//row[detailsTable.Columns[SECTION_FROM].ColumnName] = this.GetSetctionName(work.SectionCode);// 送信元拠点 // DEL 2011.08.24
						row[detailsTable.Columns[SECTION_FROM].ColumnName] = sndRcvHisAcs.GetSetctionName(work.SectionCode); // 送信元拠点  // ADD 2011.08.24
                        row[detailsTable.Columns[SEND_NO].ColumnName] = work.SndRcvHisConsNo.ToString().PadLeft(7, '0');           // 送信番号
                        row[detailsTable.Columns[SEND_DATE].ColumnName] = this.LongFormatToString(work.SendDateTime);            // 送信日時
                        row[detailsTable.Columns[DIV].ColumnName] = work.SndLogUseDiv == 0 ? "拠点管理" : "";                  // 利用区分
						//row[detailsTable.Columns[SEND_DIV].ColumnName] = work.SendOrReceiveDivCd == 0 ? "送信" : "受信";       // 送受信区分 // DEL 2011.09.14
						row[detailsTable.Columns[SEND_DIV].ColumnName] = work.SendOrReceiveDivCd == 0 ? "未受信" : "受信";       // 送受信区分 // ADD 2011.09.14
                        row[detailsTable.Columns[TYPE].ColumnName] = work.Kind == 0 ? "データ" : "マスタ";                         // 種別
                        //-----Add 2011/11/01 陳建明 for #26228 start----->>>>>
                        if (work.Kind != 0)
                        {
                        //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<    
                            //マスタの場合
                            row[detailsTable.Columns[CONDITION_DIV].ColumnName] = work.SndLogExtraCondDiv == 0 ? "差分" : "条件";  // 抽出条件区分
                        //-----Add 2011/11/01 陳建明 for #26228 start----->>>>>
                        }
                        else
                        {
                            //データの場合
                            row[detailsTable.Columns[CONDITION_DIV].ColumnName] = work.SndLogExtraCondDiv == 0 ? "差分" : "伝票日付";// 抽出条件区分
                        }
                        //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<
						//row[detailsTable.Columns[SECTION].ColumnName] = this.GetSetctionName(work.ExtraObjSecCode);             // 送信対象拠点 // DEL 2011.08.24
						//row[detailsTable.Columns[SECTION_TO].ColumnName] = this.GetSetctionName(work.SendDestSecCode);        // 送信先拠点 // DEL 2011.08.24
						row[detailsTable.Columns[SECTION].ColumnName] = sndRcvHisAcs.GetSetctionName(work.ExtraObjSecCode);             // 送信対象拠点 // ADD 2011.08.24
						row[detailsTable.Columns[SECTION_TO].ColumnName] = sndRcvHisAcs.GetSetctionName(work.SendDestSecCode);        // 送信先拠点 // ADD 2011.08.24
                        row[detailsTable.Columns[ENT_CODE_TO].ColumnName] = work.SendDestEpCode;        // 送信先企業コード

                        if (work.SndObjStartDate > DateTime.MinValue)
                        {
							//row[detailsTable.Columns[START_TIME].ColumnName] = this.DateTimeFormatToString(work.SndObjStartDate);        // 送信対象開始日時 // DEL 2011.08.24
							row[detailsTable.Columns[START_TIME].ColumnName] = sndRcvHisAcs.DateTimeFormatToString(work.SndObjStartDate);        // 送信対象開始日時 // ADD 2011.08.24
						}
                        else
                        {
                            row[detailsTable.Columns[START_TIME].ColumnName] = "";        // 送信対象開始日時
                        }
                        if (work.SndObjEndDate > DateTime.MinValue)
                        {
							//row[detailsTable.Columns[END_TIME].ColumnName] = this.DateTimeFormatToString(work.SndObjEndDate);            // 送信対象終了日時 // DEL 2011.08.24
							row[detailsTable.Columns[END_TIME].ColumnName] = sndRcvHisAcs.DateTimeFormatToString(work.SndObjEndDate);            // 送信対象終了日時 // ADD 2011.08.24
                        }
                        else
                        {
                            row[detailsTable.Columns[END_TIME].ColumnName] = "";        // 送信対象終了日時
                        }
                        if (work.UpdateDateTime > DateTime.MinValue)
                        {
							//row[detailsTable.Columns[UPDATE_TIME].ColumnName] = this.DateTimeFormatToString(work.UpdateDateTime);        // 更新日時 // DEL 2011.08.24
							row[detailsTable.Columns[UPDATE_TIME].ColumnName] = sndRcvHisAcs.DateTimeFormatToString(work.UpdateDateTime);        // 更新日時 // ADD 2011.08.24
                        }
                        else
                        {
                            row[detailsTable.Columns[UPDATE_TIME].ColumnName] = "";        // 更新日時
                        }
                        
                        this.detailsTable.Rows.Add(row);
                    }
                    else
                    {
                        sndRcvEtrWorkList.Add(resultList[i] as ArrayList);  // 詳細履歴情報lISTに追加する
                    }
                }

				// ADD 2011.09.14 ------->>>>>
				this.SetColumnStyle();
				// ADD 2011.09.14 -------<<<<<
            }
			// ADD 2011.08.25 --------->>>>>
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO,     // エラーレベル
					      //"PMKYO09401U",							// アセンブリID // DEL 2011.08.25
						    CT_CLASSID,// ADD 2011.08.25
							"該当するデータが見つかりませんでした。",	    // 表示するメッセージ
							0,									    // ステータス値
							MessageBoxButtons.OK);					// 表示するボタン
				this.tToolbarsManager1.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = false;				
			}
			// ADD 2011.08.25 ---------<<<<<
			else
			{
				//MessageBox.Show("検索がエラーが発生しました。エラー：" + status.ToString());// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP,     // エラーレベル
					        //"PMKYO09401U",							// アセンブリID // DEL 2011.08.25
						    CT_CLASSID,// ADD 2011.08.25
					        //"検索がエラーが発生しました。エラー：" + status.ToString(),	    // 表示するメッセージ  // DEL 2011.08.25
							"送信履歴データの検索に失敗しました。",   // ADD 2011.08.25
					        //0,									    // ステータス値  // DEL 2011.08.25
							status,  // ADD 2011.08.25
							MessageBoxButtons.OK);					// 表示するボタン
				// ADD 2011.08.24 ---------<<<<<
			}
        }

        /// <summary>
        /// 選択したレコードを取得する。
        /// </summary>
        /// <returns>レコードLIST</returns>
        /// <remarks>
        /// <br>Note       : 選択したレコードを取得する。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private object GetCheckedRecord()
        {
            CustomSerializeArrayList record = new CustomSerializeArrayList();
            CustomSerializeArrayList rowList = new CustomSerializeArrayList();
            uGrid_Details.UpdateData();
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if ((bool)row.Cells[CHECK_BOX].Value)
                {
                    DataRow dataRow = detailsTable.Rows[row.Index];
                    rowList.Add(dataRow);
                }
            }

            if (rowList != null)
            {
                if (rowList.Count == 0)
                {
					//MessageBox.Show("削除対象のデータを選択してください。");// DEL 2011.08.24
					// ADD 2011.08.24 --------->>>>>
					TMsgDisp.Show(this,                     // 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						        //"PMKYO09401U",							// アセンブリID// DEL 2011.08.25
							    CT_CLASSID,// ADD 2011.08.25
								"削除対象データを選択してください。",	    // 表示するメッセージ
								0,									    // ステータス値
								MessageBoxButtons.OK);					// 表示するボタン
					// ADD 2011.08.24 ---------<<<<<
                }
                else
                {
                    foreach (DataRow row in rowList)
                    {
                        SndRcvHisWork sndRcvHisWork = this.GetCheckedSndRcvHisWork(Convert.ToInt32(row[detailsTable.Columns[SEND_NO]].ToString()));

                        record.Add(sndRcvHisWork);
                    }
                }

            }

            return record;
        }

        /// <summary>
        /// 選択したSndRcvHisWorkレコードを取得する
        /// </summary>
        /// <param name="sndRcvHisConsNo">SndRcvHisWorkのsndRcvHisConsNo</param>
        /// <returns>SndRcvHisWorkレコード</returns>
        /// <remarks>
        /// <br>Note       : 選択したSndRcvHisWorkレコードを取得する</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private SndRcvHisWork GetCheckedSndRcvHisWork(int sndRcvHisConsNo)
        {
            SndRcvHisWork sndRcvHisWork = null;

            foreach (SndRcvHisWork work in sndRcvHisWorkList)
            {
                if (sndRcvHisConsNo == work.SndRcvHisConsNo)
                {
                    sndRcvHisWork = work;
                }
            }

            return sndRcvHisWork;
        }

        /// <summary>
        /// 抽出条件詳細をセットする。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件詳細をセットする。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetDetailInfo()
        {
            if (this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled == true)
            {
                SndRcvHisWork sndRcvHisWork = this.GetActiveRow();
                this._detailDialog = new PMKYO09401UB(sndRcvHisWork, this.searchResult);
                this._detailDialog.ShowDialog();
            }
        }

		// DEL 2011.08.24 -------->>>>>
		///// <summary>
		///// DateTimeの日時はStringにする
		///// </summary>
		///// <param name="dateTime">DateTimeの日時</param>
		///// <returns>Stringの日時</returns>
		///// <remarks>
		///// <br>Note       : DateTimeの日時はStringにする</br>
		///// <br>Programmer : 丁建雄</br>
		///// <br>Date       : 2011/08/01</br>
		///// </remarks>
		//private string DateTimeFormatToString(DateTime dateTime)
		//{
		//    string time = null;
		//    time += dateTime.Year + "年";
		//    time += dateTime.Month + "月";
		//    time += dateTime.Day + "日";
		//    time += dateTime.Hour + "時";
		//    time += dateTime.Minute + "分";
		//    time += dateTime.Second + "秒";

		//    return time;
		//}
		// DEL 2011.08.24 --------<<<<<

		/// <summary>
		/// longの日時はStringにする
		/// </summary>
		/// <param name="longTime">longの日時</param>
		/// <returns>Stringの日時</returns>
		/// <remarks>
		/// <br>Note       : longの日時はStringにする</br>
		/// <br>Programmer : 丁建雄</br>
		/// <br>Date       : 2011/08/01</br>
		/// </remarks>
		private string LongFormatToString(long longTime)
		{
			string time = null;

			time += Convert.ToInt32(longTime.ToString().Substring(0, 4)) + "年";
			time += Convert.ToInt32(longTime.ToString().Substring(4, 2)) + "月";
			time += Convert.ToInt32(longTime.ToString().Substring(6, 2)) + "日";
			time += Convert.ToInt32(longTime.ToString().Substring(8, 2)) + "時";
			time += Convert.ToInt32(longTime.ToString().Substring(10, 2)) + "分";

			return time;
		}

        /// <summary>
        /// 画面からの日付をチェックする
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 画面からの日付をチェックする</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private int DateCheck()
        {
            int status = -1;

            if (!TDateTime.IsAvailableDate(this.tde_Start_Date.GetDateTime()))
            {
				//MessageBox.Show("送信日開始日付の指定に誤りがあります。");// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
							//"PMKYO09401U",							// アセンブリID // DEL 2011.08.25
							CT_CLASSID,// ADD 2011.08.25
							//"送信日開始日付の指定に誤りがあります。",	    // 表示するメッセージ  // DEL 2011.08.25
							"開始送信日が不正です。",  // ADD 2011.08.25
							0,									    // ステータス値
							MessageBoxButtons.OK);					// 表示するボタン
				// ADD 2011.08.24 ---------<<<<<
                this.tde_Start_Date.Focus();
                return status;
            }
            if (!TDateTime.IsAvailableDate(this.tde_End_Date.GetDateTime()))
            {
				//MessageBox.Show("送信日終了日付の指定に誤りがあります。");// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
							//"PMKYO09401U",							// アセンブリID	// DEL 2011.08.25
							CT_CLASSID,// ADD 2011.08.25
							//"送信日終了日付の指定に誤りがあります。",	    // 表示するメッセージ // DEL 2011.08.25
							"終了送信日が不正です。",  // ADD 2011.08.25
							0,									    // ステータス値
							MessageBoxButtons.OK);					// 表示するボタン
				// ADD 2011.08.24 ---------<<<<<
                this.tde_End_Date.Focus();
                return status;
            }
            if (this.tde_Start_Date.GetDateTime().CompareTo(this.tde_End_Date.GetDateTime()) > 0)
            {
				//MessageBox.Show("送信日付の指定に誤りがあります。");// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
							//"PMKYO09401U",							// アセンブリID	// DEL 2011.08.25
							CT_CLASSID,// ADD 2011.08.25
					//"送信日付の指定に誤りがあります。",	    // 表示するメッセージ // DEL 2011.08.25
							"送信日付の範囲指定に誤りがあります。",  // ADD 2011.08.25
							0,									    // ステータス値
							MessageBoxButtons.OK);					// 表示するボタン
				// ADD 2011.08.24 ---------<<<<<
                this.tde_Start_Date.Focus();
                return status;
            }
            status = 0;

            return status;
        }

        /// <summary>
        /// 画面から条件を取得する
        /// </summary>
        /// <param name="sndRcvHisCondWork">取得する条件</param>
        /// <remarks>
        /// <br>Note       : 画面から条件を取得する</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ScreenToSndRcvHisCondWork(out SndRcvHisCondWork sndRcvHisCondWork)
        {
            sndRcvHisCondWork = new SndRcvHisCondWork();

            sndRcvHisCondWork.ParaEnterpriseCode = this._enterpriseCode;
            
            sndRcvHisCondWork.SendDateTimeStart = long.Parse(this.tde_Start_Date.GetLongDate() + "0000");
            sndRcvHisCondWork.SendDateTimeEnd = long.Parse(this.tde_End_Date.GetLongDate() + "2359");

			// ADD 2011.09.05
			if ((int)this.tce_SendAndReceKubun.Value == 1)
			{
				sndRcvHisCondWork.ParaSendOrReceiveDivCd = 0;
			}
			else
			{
				sndRcvHisCondWork.ParaSendOrReceiveDivCd = 1;
			}

			sndRcvHisCondWork.ParaSectionCode = this.tEdit_SectionCodeAllowZero.DataText; // ADD 2011.09.14
			
        }

        /// <summary>
        /// 活性レコードを取得する
        /// </summary>
        /// <returns>レコード</returns>
        /// <remarks>
        /// <br>Note       : 活性レコードを取得する</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private SndRcvHisWork GetActiveRow()
        {
            SndRcvHisWork sndRcvHisWork = null;

            int sndRcvHisConsNo = Convert.ToInt32(this.uGrid_Details.ActiveRow.Cells[detailsTable.Columns[SEND_NO].ColumnName].Value);  // 送信番号
            foreach (SndRcvHisWork work in this.sndRcvHisWorkList)
            {
                if (work.SndRcvHisConsNo == sndRcvHisConsNo)
                {
                    sndRcvHisWork = work;
                }
            }

            return sndRcvHisWork;
        }

		// DEL 2011.08.24 --------------->>>>>
		///// <summary>
		///// 拠点情報を取得
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <returns>拠点名前</returns>
		///// /// <remarks>
		///// <br>Note       : 拠点情報を取得</br>
		///// <br>Programmer : 丁建雄</br>
		///// <br>Date       : 2011/08/01</br>
		///// </remarks>
		//private string GetSetctionName(string sectionCode)
		//{
		//    string sectionName = null;

		//    SecInfoAcs secInfoAcs = new SecInfoAcs();
		//    try
		//    {
		//        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
		//        {
		//            if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
		//            {
		//                sectionName = secInfoSet.SectionGuideNm.Trim();
		//                break;
		//            }
		//        }
		//    }
		//    catch
		//    {
		//        sectionName = string.Empty;
		//    }

		//    return sectionName;
		//}
		// DEL 2011.08.24 ---------------<<<<<
       
		/// <summary>
		/// KeyDown処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 送信情報グリッドのマウス右クリック処理。</br>
		/// <br>Programmer  : 丁建雄</br>
		/// <br>Date        : 2011/08/01</br>
		/// </remarks>
		private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		{
			if (uGrid_Details.ActiveRow != null)
			{
				if (e.KeyCode == Keys.Space)
				{
					bool flag = (bool)this.uGrid_Details.ActiveRow.Cells[this.detailsTable.Columns[CHECK_BOX].ColumnName].Value;
					this.uGrid_Details.ActiveRow.Cells[this.detailsTable.Columns[CHECK_BOX].ColumnName].Value = !flag;
				}
			}
		}
		#endregion ■ Private Method ■

		private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
		{
			uGrid_Details.Selected.Rows.Clear();
			bool val = !((bool)e.Cell.Value);
			e.Cell.Value = val;

			if (uGrid_Details.Selected.Rows.Count == 0 || e.Cell.Row != uGrid_Details.Selected.Rows[0])
				e.Cell.Row.Selected = true;
			e.Cancel = true;
		}

		// ADD 2011.09.14 ---------->>>>>
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note		: フォームロードイベント処理発生します。</br>
		/// <br>Programmer	: 張莉莉</br>
		/// <br>Date		: 2011.09.14</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			 if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				case "tEdit_SectionCodeAllowZero":
					{
						// 拠点コード取得
						string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
						if (sectionCode.Trim().Equals(""))
						{
							this.tEdit_SectionCodeAllowZero.DataText = "00";
						}
						else
						{
							this.tEdit_SectionCodeAllowZero.DataText = sectionCode.PadLeft(2, '0');
						}
					}
					break;
			}
		}
		// ADD 2011.09.14 ----------<<<<<
	}
}