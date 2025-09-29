//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号 PJTASDNO004  作成担当 : LDNS wangqx
// 作 成 日  2011/07/14  修正内容 : 仮導入データクリア対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/14 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// データ送信処理
    /// </summary>
    /// <remarks>
    /// Note       : データ送信処理です。<br />
    /// Programmer : 劉学智<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public partial class PMKHN01000UA : Form
    {
        #region ■ Const Memebers ■
        private const string ct_PGID = "PMKHN01000UA";
        private const string ct_PGName = "データクリア処理";
        #endregion ■ Const Memebers ■

        #region ■ private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _enterButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private DataClearDataSet.DataClearDataTable _dataClearDataTable;
        private DataClearAcs _dataClearAcs;
        private PMKHN01000UB _gridDetails;
        private string _enterpriseCode;
        private DateGetAcs _dateGetAcs;
        // -- ADD 2011/07/14 ------------------------------------------->>>
        private CompanyInfAcs _companyInfAcs;
        // -- ADD 2011/07/14 -------------------------------------------<<<
        #endregion ■ private field ■

        #region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN01000UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._enterButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Enter"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._dataClearAcs = DataClearAcs.GetInstance();
            this._dataClearDataTable = this._dataClearAcs.DataClearDataTable;
            this._gridDetails = new PMKHN01000UB();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._dateGetAcs = DateGetAcs.GetInstance();
            // -- ADD 2011/07/14 ------------------------------------------->>>
            this._companyInfAcs = new CompanyInfAcs();
            // -- ADD 2011/07/14 -------------------------------------------<<<
        }
        #endregion ■ コンストラクタ ■

        #region ■ Control Event
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 劉学智</br>	
        /// <br>Date		: 2009.06.16</br>
        /// </remarks>
        private void PMKHN01000UA_Load(object sender, EventArgs e)
        {
            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this.ButtonInitialSetting();

            this.panel_Detail.Controls.Add(this._gridDetails);
            this._gridDetails.Dock = DockStyle.Fill;
            this._gridDetails.InitialSettingGridCol();

            // 残高設定月の初期化設定
            this.InitClearYM();

            // グリッドの初期化処理
            this.InitialDataGridCol();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // タイム起動
            this.timer_Initial.Enabled = true;
        }

        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 劉学智</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Enter":
                    {
                        // 日付の未入力チェック
                        if (this.CheckDateNoInput(this.tDateEdit_DataClearYM))
                        {
                            this.tDateEdit_DataClearYM.Clear();
                        }
                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_PGID,
                            "データクリア処理を実行します。\r\nよろしいですか？", 0, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            string errMsg = string.Empty;
                            // チェック処理
                            if (this.ClearBeforeCheck(out errMsg))
                            {
                                // データクリア処理
                                this.DataClear();
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// 初期化後の処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 初期化後の処理です。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.06.18</br>
        /// </remarks>
        private void timer_Initial_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tDateEdit_DataClearYM.Select();
            this.timer_Initial.Enabled = false;
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 矢印キーでのフォーカス移動イベントです。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.06.18</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
			// ADD 2011.09.14 ------->>>>>
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				case "tEdit_SecCode":
					{
						// 拠点コード取得
						string sectionCode = this.tEdit_SecCode.DataText.Trim();
						if (!sectionCode.Trim().Equals(""))
						{
							this.tEdit_SecCode.DataText = sectionCode.PadLeft(2, '0');
						}
					}
					break;
			}
			// ADD 2011.09.14 -------<<<<<

            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tDateEdit_DataClearYM)
                    {
                        //e.NextCtrl = this._gridDetails.uGrid_Details;//DEL by Liangsd     2011/09/06
                        //this._gridDetails.uGrid_Details.Rows[0].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();//DEL by Liangsd     2011/09/06
						e.NextCtrl = this.tEdit_SecCode;//ADD by Liangsd    2011/09/06
                    }
                    //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
					else if (e.PrevCtrl == this.tEdit_SecCode)
                    {
                        e.NextCtrl = this._gridDetails.uGrid_Details;
                        this._gridDetails.uGrid_Details.Rows[0].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();
                    }
                    //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
                    else if (e.PrevCtrl == this._gridDetails.uGrid_Details)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:

                                if (this._gridDetails.uGrid_Details.ActiveCell != null)
                                {
                                    if (this._gridDetails.ReturnKeyDown(false))
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_DataClearYM;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tDateEdit_DataClearYM)
                    {
                        e.NextCtrl = this._gridDetails.uGrid_Details;
                        int rowCnt = this._gridDetails.uGrid_Details.Rows.Count;
                        this._gridDetails.uGrid_Details.Rows[rowCnt - 1].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();
                    }
                    //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
					else if (e.PrevCtrl == this.tEdit_SecCode)
                    {
                        e.NextCtrl = this.tDateEdit_DataClearYM;
                    }
                    //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
                    else if (e.PrevCtrl == this._gridDetails.uGrid_Details)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:

                                if (this._gridDetails.uGrid_Details.ActiveCell != null)
                                {
                                    if (this._gridDetails.ReturnKeyDown(true))
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else
                                    {
                                        //e.NextCtrl = this.tDateEdit_DataClearYM;//DEL by Liangsd     2011/09/06
										e.NextCtrl = this.tEdit_SecCode;//ADD by Liangsd    2011/09/06
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 日付のフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 日付のフォーカス移動イベントです。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.06.18</br>
        /// </remarks>
        private void tDateEdit_DataClearYM_Leave(object sender, EventArgs e)
        {
            // 日付の未入力チェック
            if (this.CheckDateNoInput(this.tDateEdit_DataClearYM))
            {
                this.tDateEdit_DataClearYM.Clear();
            }
        }
        #endregion ■ Control Event

        #region  ■ private method ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._enterButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }

        /// <summary>
        /// 残高設定月の初期化設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 残高設定月の初期化設定処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns></returns>
        private void InitClearYM()
        {
            string sectionCode = string.Empty;
            DateTime prevTotalDay = new DateTime();
            DateTime currentTotalDay = new DateTime();
            DateTime prevTotalMonth = new DateTime();
            DateTime currentTotalMonth = new DateTime();

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            // 前回月次更新日取得メソッド
            totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            this.tDateEdit_DataClearYM.SetDateTime(prevTotalMonth);
        }

        /// <summary>
        /// グリッドの初期化処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッドの初期化処理を行う。</br>
        /// <br>Programmer	: 劉学智</br>	
        /// <br>Date		: 2009.06.16</br>
        /// </remarks>
        private void InitialDataGridCol()
        {
            DataClear _dataClear = new DataClear();
            ArrayList dataClearList = _dataClear.GetDataClearList();
            // 送信対象データをグリッドへ設定する
            for (int i = 0; i < dataClearList.Count; i++)
            {
                DataClearWork dataClearWork = (DataClearWork)dataClearList[i];
                DataClearDataSet.DataClearRow row = this._dataClearDataTable.NewDataClearRow();
                row.RowNo = i + 1;
                row.TableId = dataClearWork.TableId;
                row.TableNm = dataClearWork.TableNm;
#if DEBUG
                row.IsChecked = false;
#else
                row.IsChecked = true;
#endif
                row.ClearCode = dataClearWork.ClearCode;
                row.FileId = dataClearWork.FileId;
                this._dataClearDataTable.AddDataClearRow(row);
            }
        }

        /// <summary>
        /// クリア前のチェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : クリア前のチェック処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private bool ClearBeforeCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // 日付の未入力チェック
            if (this.CheckDateNoInput(this.tDateEdit_DataClearYM))
            {
                errMsg = "残高設定月を入力して下さい。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                this.tDateEdit_DataClearYM.Select();
                return false;
            }

            // 日付の不正入力チェック
            if (this.CheckDateInvalid(this.tDateEdit_DataClearYM))
            {
                errMsg = "残高設定月が不正です。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                this.tDateEdit_DataClearYM.Select();
                return false;
            }

            // 処理対象の選択チェック
            if (!this._dataClearAcs.IsGridDetailSelected())
            {
                errMsg = "処理対象を選択して下さい。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                this._gridDetails.ActivateCheckBox(0);
                return false;
            }
			// DEL 2011.09.14 ------->>>>>
			//ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
			//拠点管理送受信データ選択判定
			//if (this._dataClearAcs.IsSelected() && this.tEdit_SecCode.Text == "")
			//{
			//    errMsg = "処理対象の拠点コードを入力して下さい。";
			//    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
			//    this._gridDetails.ActivateCheckBox(0);
			//    this.tEdit_SecCode.Focus();
			//    return false;
			//}
			//ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
			// DEL 2011.09.14 -------<<<<<
            // オフライン状態チェック
            if (!this._dataClearAcs.CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面クリア処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 日付の未入力チェック
        /// </summary>
        /// <param name="targetDateEdit">日付</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 日付の未入力チェックを行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private bool CheckDateNoInput(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfNoInput);
        }

        /// <summary>
        /// 日付の不正入力チェック
        /// </summary>
        /// <param name="targetDateEdit">日付</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 日付の不正入力チェックを行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private bool CheckDateInvalid(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfInvalid);
        }

        /// <summary>
        /// データクリア処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : データクリア処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        private void DataClear()
        {
            // 削除年月
            DateTime delYM = this.tDateEdit_DataClearYM.GetDateTime().AddMonths(1);
            Int32 intDelYM = Convert.ToInt32(delYM.ToString("yyyyMM"));

            // 削除年月開始日
            DateTime startMonthDate, endMonthDate;
            this._dateGetAcs.GetDaysFromMonth(delYM, out startMonthDate, out endMonthDate);
            Int32 intDelYMD = Convert.ToInt32(startMonthDate.ToString("yyyyMMdd"));

            // 処理中ダイアログ
            SFCMN00299CA form = new SFCMN00299CA();
            // 表示文字を設定
            form.Title = "データクリア処理";
            form.Message = "現在、データクリア処理中です。";
            // ダイアログ表示
            form.Show();

            // 実行処理
            string errMsg = string.Empty;
            //int status = this._dataClearAcs.DataClear(this._enterpriseCode, intDelYM, intDelYMD, out errMsg);//DEL by Liangsd     2011/09/06
			int status = this._dataClearAcs.DataClear(this.tEdit_SecCode.Text, this._enterpriseCode, intDelYM, intDelYMD, out errMsg);//ADD by Liangsd     2011/09/06
            // -- ADD 2011/07/14 ------------------------------------------->>>
            // 自社情報マスタに「データクリア処理実行年月日」、「データクリア処理実行時分秒ミリ秒」を設定する
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string errMsg2 = string.Empty;
                CompanyInf companyInf = new CompanyInf();
                System.DateTime currentTime = DateTime.Now;
                string DelYMD = currentTime.ToString("yyyyMMdd ");
                string DelHMSXXX = currentTime.ToString("HHmmssfff");
                companyInf.EnterpriseCode = this._enterpriseCode;
                int status2 = this._companyInfAcs.WriteClearTime(companyInf, DelYMD, DelHMSXXX, out errMsg2);
            }
            // -- ADD 2011/07/14 -------------------------------------------<<<
            // ダイアログを閉じる
            form.Close();

            System.Threading.Thread.Sleep(1);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "データクリア処理が完了しました。", status);
            }
            else
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
            }

        }

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_PGID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PGName,						    // プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージの表示を行います。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_PGID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PGName,						    // プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #endregion ■ private method ■
    }
}