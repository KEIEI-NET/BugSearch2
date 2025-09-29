using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 在庫組立・分解処理UIクラス    
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫組立・分解処理UIクラスの機能を実装する。</br>
    /// <br>Programmer : 980035 金沢 貞義</br>
	/// <br>Date       : 2008.11.05</br>
    /// <br>UpdateNote : 2009.01.26　金沢 貞義</br>
    /// <br>             不具合修正</br>
    /// <br>UpdateNote : 2009.02.03　金沢 貞義</br>
    /// <br>             子品番の在庫数-QTYチェック処理追加</br>
    /// <br>UpdateNote : 2009.02.12　上野 俊治</br>
    /// <br>             障害対応11064(速度アップ対応)</br>
    /// <br>UpdateNote : 2009.11.26　工藤 恵優</br>
    /// <br>             障害対応14684(月次更新後の在庫データの更新は不可)</br>
    /// </remarks>
	public partial class PMZAI04021UA : Form
	{
		# region Constructor
		/// <summary>
		/// 在庫組立・分解処理UIクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫組立・分解処理UIクラスのインスタンスを生成します</br>
        /// <br>Programmer : 980035 金沢 貞義</br>
        /// <br>Date       : 2008.11.05</br>
        /// </remarks>
		public PMZAI04021UA()
		{
            InitializeComponent();

            // 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;						
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //ログイン従業員コード
            this._employeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            //ログイン従業員名称
            //this._employeeName = employee.Name;
            this._employeeName = LoginInfoAcquisition.Employee.Name;
            //画面デザイン変更クラス
            this._controlScreenSkin = new ControlScreenSkin();

            //在庫組立・分解処理アクセスクラス
            if (this._stckAssemOvhulAcs == null)
            {
                this._stckAssemOvhulAcs = new StckAssemOvhulAcs();
            }                         

            this._secInfoAcs = new SecInfoAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();

            // 各種マスタ読込
            LoadSecInfoSet();
            LoadWarehouse();
            LoadMakerUMnt();

            // 画面初期設定処理
            SetInitialSetting();

            this._stckAssemOvhulAcs.SettingTaxRate(); // ADD 2009/02/12
        }
		# endregion

		# region Const
        /// <summary> PGID </summary>
        private const string ctPGID = "PMZAI04020U";
               
		# endregion    

		# region Private Members

        // 初回起動フラグ
		private bool _isFirstFlag = true;   
		// ログイン情報
		private string _enterpriseCode;		// 企業コード
        private string _loginSectionCode;   // ログイン拠点(自拠点)
        private string _employeeCode;
        private string _employeeName;
        private List<string> _sectWarehouseCd;

        //ツールバー関連
        //キー
        private const string ctFILE_POPUPMENUTOOLKEY        = "File_PopupMenuTool";         //ファイル
        private const string ctCLOSE_BUTTONTOOLKEY          = "Close_ButtonTool";           //閉じる
        private const string ctSAVE_BUTTONTOOLKEY           = "Save_ButtonTool";            //保存
        private const string ctWCHANGE_BUTTONTOOLKEY        = "WChange_ButtonTool";         //倉庫切替
        private const string ctPRINT_BUTTONTOOLKEY          = "Print_ButtonTool";           //印刷
        private const string ctLOGINNAMETITLE_LABELTOOLKEY  = "LoginNameTitle_LabelTool";   //ログイン担当者ラベル
        private const string ctLOGINNAME_LABELTOOLKEY       = "LoginName_LabelTool";        //ログイン担当者名

        // StatusBar関連
        private const string ctSTATUSBAR_TEXT = "StatusBarPanel_Text";
        private const string ctSTATUSBAR_PROGRESS = "StatusBarPanel_Progress";

        // 在庫組立・分解データセット
		private DataSet _prtStckAssemOvhul;
        // 親商品情報取得
        private ParentGoods _parentGoods;

        // 在庫組立・分解処理アクセスクラス
        private StckAssemOvhulAcs _stckAssemOvhulAcs = null;	    
				
        // メーカーマスタアクセスクラス
        private MakerAcs _makerAcs = null;

        // 倉庫アクセスクラス
        private WarehouseAcs _warehouseAcs = null;

        // 拠点アクセスクラス
        private SecInfoAcs _secInfoAcs = null;


        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;

        // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // 品番変更チェック用
        private string _searchCode = string.Empty;
        // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

		# endregion

        #region 画面初期設定処理
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// </remarks>
        private void SetInitialSetting()
		{
            //MessageBox.Show("");
            // 初回起動時のみ
            if ( this._isFirstFlag )
            {
                // ステータスバー進捗バー制御処理(完了)
                this.StatusBarProgressControlEnd();

                // ツールバー初期設定処理
                this.SetToolbar();

                // ツールバーにログイン担当者を表示する
                this.ShowToolbarSlip();

                // 初期フォーカス               
                this.ProcessDiv_tComboEditor.Focus();
            }

            //グリッド表示用履歴データ取得
            this._stckAssemOvhulAcs.Read(out this._prtStckAssemOvhul);

            // グリッド表示
            if (this.GoodsSet_Grid.DataSource == null)
            {
                this.GoodsSet_Grid.DataSource = this._prtStckAssemOvhul.Tables[StckAssemOvhulAcs.ctM_PrtStckAssemOvhul_Table];
            }
            else
            {
                this.UpdateGridSubGoodsList(this._prtStckAssemOvhul.Tables[StckAssemOvhulAcs.ctM_PrtStckAssemOvhul_Table]);
            }

            // グリッド設定
            this.PrepareHistoryGridDisp();
        }

        #region ステータスバー進捗処理

        /// <summary>
        /// ステータスバー進捗バー制御処理(開始)
        /// </summary>
        private void StatusBarProgressControlStart(int max, int min, int val, string message)
        {
            this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = message;
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].Visible = true;
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Maximum = max;
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Minimum = min;
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value = val;
            this.Main_StatusBar.Refresh();
        }

        /// <summary>
        /// ステータスバー進捗バー制御処理(経過)
        /// </summary>
        private void StatusBarProgressControl(string message)
        {
            this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = message;
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value++;
            this.Main_StatusBar.Refresh();
        }

        /// <summary>
        /// ステータスバー進捗バー制御処理(完了)
        /// </summary>
        private void StatusBarProgressControlEnd()
        {
            this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = "";
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value = this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Maximum;
            this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].Visible = false;
            this.Main_StatusBar.Refresh();
        }

        #endregion

        #region ツールバー初期設定処理

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        private void SetToolbar()
        {
            // イメージリストを設定する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = imageList16;

            // ログイン担当者へのアイコン設定
            LabelTool loginEmployeeLabel = (LabelTool)tToolbarsManager_MainMenu.Tools[ctLOGINNAMETITLE_LABELTOOLKEY];
            if (loginEmployeeLabel != null)
                loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 終了のアイコン設定
            ButtonTool closeButton = (ButtonTool)tToolbarsManager_MainMenu.Tools[ctCLOSE_BUTTONTOOLKEY];
            if (closeButton != null)
                closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // 保存のアイコン設定
            ButtonTool saveButton = (ButtonTool)tToolbarsManager_MainMenu.Tools[ctSAVE_BUTTONTOOLKEY];
            if (saveButton != null)
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            // 倉庫切替のアイコン設定
            ButtonTool wchangeButton = (ButtonTool)tToolbarsManager_MainMenu.Tools[ctWCHANGE_BUTTONTOOLKEY];
            if (wchangeButton != null)
                wchangeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
        }

        #endregion

        #region ログイン担当者表示処理
        /// <summary>
        /// ツールバーにログイン担当者を表示する
        /// </summary>
        private void ShowToolbarSlip()
        {
            //ログイン従業員名称
            if (LoginInfoAcquisition.Employee.Name != null)
            {
                this.tToolbarsManager_MainMenu.Tools[ctLOGINNAME_LABELTOOLKEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            LabelTool loginName = (LabelTool)tToolbarsManager_MainMenu.Tools[ctLOGINNAME_LABELTOOLKEY];
            if (loginName != null && _employeeName != null)
                loginName.SharedProps.Caption = this._employeeName;
        }
        #endregion

        /// <summary>
		/// //グリッド描画処理
		/// </summary>
		/// <param name="parameter">対象オブジェクト</param>
        private void SetUpGoodsSetGrid()
        {
            //処理区分が削除処理の履歴のForeColorをBlueに
            for (int ix = 0; ix < this.GoodsSet_Grid.DisplayLayout.Rows.Count; ix++)
            {
                if ((string)this.GoodsSet_Grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubWarehouseCd].Value == string.Empty)
                {
                    //在庫登録されていない場合、行の色を変更する
                    this.GoodsSet_Grid.DisplayLayout.Rows[ix].Appearance.BackColor = Color.Pink;
                    this.GoodsSet_Grid.DisplayLayout.Rows[ix].Appearance.BackColor2 = Color.Pink;
                }
                else if ((double)this.GoodsSet_Grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubSupplierStock].Value <= 0)
                {
                    //在庫数が無い場合、セルの色を変更する
                    this.GoodsSet_Grid.DisplayLayout.Rows[ix].Cells[StckAssemOvhulAcs.ctShipmentPosCnt].Appearance.BackColor = Color.Pink;
                    this.GoodsSet_Grid.DisplayLayout.Rows[ix].Cells[StckAssemOvhulAcs.ctShipmentPosCnt].Appearance.BackColor2 = Color.Pink;
                }
                // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                else if ((double)this.GoodsSet_Grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubSupplierStock].Value < (double)this.GoodsSet_Grid.Rows[ix].Cells[StckAssemOvhulAcs.ctCntFl].Value)
                {
                    //在庫数＜QTYの場合、セルの色を変更する
                    this.GoodsSet_Grid.DisplayLayout.Rows[ix].Cells[StckAssemOvhulAcs.ctShipmentPosCnt].Appearance.BackColor = Color.Pink;
                    this.GoodsSet_Grid.DisplayLayout.Rows[ix].Cells[StckAssemOvhulAcs.ctShipmentPosCnt].Appearance.BackColor2 = Color.Pink;
                }
                // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }
		#endregion

        #region 倉庫切替処理
        /// <summary>
        /// 倉庫切替処理
        /// </summary>
        /// <param name="sender">メインフレームインスタンス</param>
        /// <returns>Status</returns>
        private int WarehouseChange()
        {
            // 品番入力チェック
            if (this.tEdit_GoodsNo.DataText.Trim() == string.Empty)
                return -1;

            // ヘッダー倉庫情報更新処理
            int status = this.UpdateParentWarehouseData();

            if (status == 0)
            {
                string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();
                this._stckAssemOvhulAcs.ReadNext(warehouseCode, out this._prtStckAssemOvhul);

                // グリッド倉庫切替更新処理
                this.UpdateGridSubWarehouseList(warehouseCode, this._prtStckAssemOvhul.Tables[StckAssemOvhulAcs.ctM_PrtStckAssemOvhul_Table]);

                //グリッド描画処理
                this.SetUpGoodsSetGrid();

                //組立分解可能数取得処理
                this.GetShipmentMaxCnt();
                if ((int)ProcessDiv_tComboEditor.Value == 0)
                {
                    // 最大組立可能数
                    this.tNedit_InputCnt.SetValue(this.tNedit_ConstructionMaxCnt.GetValue());
                }
                else
                {
                    // 最大分解可能数
                    this.tNedit_InputCnt.SetValue(this.tNedit_AnalysisMaxCnt.GetValue());
                }
            }

            return status;
        }
        #endregion

        #region 更新処理
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender">メインフレームインスタンス</param>
        /// <returns>Status</returns>
        private int Save()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            string serverErrorMsg = "";

            // ADD 2009/11/26 MANTIS対応[14684]：月次更新後の在庫データの更新は不可 ---------->>>>>
            // TODO:月次更新後であれば在庫データの更新は行えない
            if (!MAKHN09280UA.CanWrite(DateTime.Now)) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // ADD 2009/11/26 MANTIS対応[14684]：月次更新後の在庫データの更新は不可 ----------<<<<<

            // 登録前チェック処理
            status = ShowErrorItems();
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            //時間がかかるので抽出中画面部品のインスタンスを作成する
            SFCMN00299CA form = new SFCMN00299CA();

            // 表示文字を設定
            form.Title = "在庫組立・分解処理中";
            form.Message = "現在、在庫組立・分解処理中です。";
            try
            {
                // ダイアログ表示
                form.Show();			

                string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim();
                int processDiv = (int)this.ProcessDiv_tComboEditor.Value;
                double inputCnt = this.tNedit_InputCnt.GetValue();

                // 在庫組立分解処理
                status = this._stckAssemOvhulAcs.WriteDB(warehouseCode, processDiv, inputCnt, out serverErrorMsg);
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 品番取得
                        string searchCode = tEdit_GoodsNo.DataText.Trim();

                        // 登録内容表示
                        if (searchCode != "")
                        {
                            PartsInfoDataSet partsInfoDataSet;
                            status = this._stckAssemOvhulAcs.SearchGoodsAndGoodsSet(this._enterpriseCode, this._loginSectionCode, 0, searchCode, out partsInfoDataSet);

                            if (status == 0)
                            {
                                status = this.GetSearchGoods(searchCode, partsInfoDataSet, 1);

                                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.InputCnt_Title.Text,
                                        "商品の読み込みに失敗しました。",
                                        -1,
                                        MessageBoxButtons.OK);
                                }
                                else
                                {
                                    // 完了メッセージ表示
                                    ShowMsgDisp(
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        "在庫マスタを更新しました。",
                                        status,
                                        "Save",
                                        MessageBoxButtons.OK);
                                    this.ProcessDiv_tComboEditor.Focus();
                                    // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    //組立分解可能数取得処理
                                    this.GetShipmentMaxCnt();
                                    if ((int)ProcessDiv_tComboEditor.Value == 0)
                                    {
                                        // 最大組立可能数
                                        this.tNedit_InputCnt.SetValue(this.tNedit_ConstructionMaxCnt.GetValue());
                                    }
                                    else
                                    {
                                        // 最大分解可能数
                                        this.tNedit_InputCnt.SetValue(this.tNedit_AnalysisMaxCnt.GetValue());
                                    }
                                    // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.InputCnt_Title.Text,
                                    "商品の読み込みに失敗しました。",
                                    -1,
                                    MessageBoxButtons.OK);
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    break;
                default:
                    {
                        // エラーステータスなのにメッセージが帰ってこなかったとき
                        if (serverErrorMsg.CompareTo("") == 0)
                        {
                            serverErrorMsg = "在庫組立・分解処理に失敗しました。";
                        }

                        // 失敗メッセージ表示(Nomal, Error以外のとき。リモートからメッセージが帰ってくる。)
                        ShowMsgDisp(
                            emErrorLevel.ERR_LEVEL_INFO,
                            serverErrorMsg,
                            status,
                            "Save",
                            MessageBoxButtons.OK
                        );
                        break;
                    }
            }

            return status;
        }
		#endregion

		#region 更新前エラーチェック処理
        /// <summary>
        /// 更新前エラーチェック処理
        /// </summary>
        /// <param name="sender">メインフレームインスタンス</param>
        /// <param name="ErrorItems">エラー発生コントロールリスト</param>
        /// <returns>Status</returns>
        private int ShowErrorItems()
        {
            int result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            Control errControl = null;

            try
            {
                // 明細非在庫品チェック
                if (this.GoodsSet_Grid.DisplayLayout.Rows.Count > 0)
                {
                    for (int ix = 0; ix < this.GoodsSet_Grid.DisplayLayout.Rows.Count; ix++)
                    {
                        if ((string)this.GoodsSet_Grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubWarehouseCd].Value == string.Empty)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.InputCnt_Title.Text,
                                "セット商品が在庫マスタに登録されていません。",
                                -1,
                                MessageBoxButtons.OK);
                            errControl = this.tNedit_InputCnt;
                            result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            return result;
                        }
                    }
                }

                // 入力個数チェック
                if ((this.tNedit_InputCnt.GetValue() == 0) ||
                    (this.ChkGridGoodsSet(this.tNedit_InputCnt.GetValue()) == false))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.InputCnt_Title.Text,
                        "入力した個数が不正です。",
                        -1,
                        MessageBoxButtons.OK);
                    errControl = this.tNedit_InputCnt;
                    result = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return result;
                }

            }
            finally
            {
                if (errControl != null)
                {
                    errControl.Focus();
                }
            }
            return result;
        }
        #endregion

        # region Private Methods

        #region 画面初期設定処理
        /// <summary>
		/// 画面初期設定処理
		/// </summary>
		private void InitialSetting()
		{
            // グリッドキーマッピング設定
            MakeKeyMappingForGrid(this.GoodsSet_Grid);

            // 処理区分初期値セット（組立）
            this.ProcessDiv_tComboEditor.Value = 0;

            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 処理区分初期値セット（組立）
            this.DecimalDiv_tComboEditor.Value = 1;
            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
		#endregion

        #region ヘッダー情報更新処理
        /// <summary>
        /// ヘッダー情報更新処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        private void UpdateParentGoodsData()
        {
            //親商品情報取得
            this._stckAssemOvhulAcs.Read(out this._parentGoods);

            this.tEdit_GoodsNo.DataText = this._parentGoods.ParentGoodsNo;                                  // 親商品番号	
            this.tEdit_GoodsName.DataText = this._parentGoods.ParentGoodsNameKana;                          // 親商品名称
            this.tNedit_GoodsMakerCd.SetInt(this._parentGoods.ParentGoodsMakerCd);                          // 親商品メーカーコード
            this.tEdit_GoodsMakerName.DataText = GetMakerName(this._parentGoods.ParentGoodsMakerCd);        // 親メーカー略称

            this.tEdit_WarehouseCode.DataText = this._parentGoods.ParentWarehouseCode;                      // 親倉庫コード
            this.tEdit_WarehouseName.DataText = GetWarehouseName(this._parentGoods.ParentWarehouseCode);    // 親倉庫名称
            this.tNedit_ShipmentPosCnt.SetValue((double)this._parentGoods.ShipmentPosCnt);                  // 親現在在庫数
            this.tNedit_MaximumStockCnt.SetValue((double)this._parentGoods.ParentMaximumStockCnt);          // 親最高在庫数
            this.tNedit_MinimumStockCnt.SetValue((double)this._parentGoods.ParentMinimumStockCnt);          // 親最低在庫数

            //在庫数背景色変更
            this.tNedit_ShipmentPosCnt.Appearance.ResetBackColorDisabled();
            if (this._parentGoods.ParentGoodsNo.Trim() != string.Empty)
            {
                if (this.tNedit_ShipmentPosCnt.GetValue() <= 0)
                {
                    this.tNedit_ShipmentPosCnt.Appearance.BackColorDisabled = Color.Pink;
                }
            }
            else
            {
                //this.tNedit_ShipmentPosCnt.Clear();   // 親現在在庫数
                this.tNedit_ShipmentPosCnt.Clear();     // 親現在在庫数
                this.tNedit_MaximumStockCnt.Clear();    // 親最高在庫数
                this.tNedit_MinimumStockCnt.Clear();    // 親最低在庫数
            }
        }

        /// <summary>
        /// ヘッダー倉庫情報更新処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        private int UpdateParentWarehouseData()
        {
            //親商品情報取得（次在庫取得）
            int status = this._stckAssemOvhulAcs.ReadNext(this.tEdit_WarehouseCode.DataText.Trim(), out this._parentGoods);

            if (status == 0)
            {
                this.tEdit_WarehouseCode.DataText = this._parentGoods.ParentWarehouseCode;                      // 親倉庫コード
                this.tEdit_WarehouseName.DataText = GetWarehouseName(this._parentGoods.ParentWarehouseCode);    // 親倉庫名称
                this.tNedit_ShipmentPosCnt.SetValue((double)this._parentGoods.ShipmentPosCnt);                  // 親現在在庫数
                this.tNedit_MaximumStockCnt.SetValue((double)this._parentGoods.ParentMaximumStockCnt);          // 親最高在庫数
                this.tNedit_MinimumStockCnt.SetValue((double)this._parentGoods.ParentMinimumStockCnt);          // 親最低在庫数

                //在庫数背景色変更
                if (this.tNedit_ShipmentPosCnt.GetValue() <= 0)
                {
                    this.tNedit_ShipmentPosCnt.Appearance.BackColorDisabled = Color.Pink;
                }
                else
                {
                    this.tNedit_ShipmentPosCnt.Appearance.ResetBackColorDisabled();
                }
            }

            return status;
        }
        #endregion

        #region グリッド更新処理
        /// <summary>
        /// グリッド更新処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        private void UpdateGridSubGoodsList(DataTable dataTable)
        {
            UltraGrid grid = this.GoodsSet_Grid;

            for (int ix = 0; ix < dataTable.Rows.Count; ix++)
            {
                DataRow dr = dataTable.Rows[ix];

                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctDisplayOrder].Value = dr[StckAssemOvhulAcs.ctDisplayOrder];	            // №
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubGoodsNo].Value = dr[StckAssemOvhulAcs.ctSubGoodsNo];	                // 子商品番号	
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubGoodsName].Value = dr[StckAssemOvhulAcs.ctSubGoodsName];             // 子商品名称
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubGoodsMakerCd].Value = dr[StckAssemOvhulAcs.ctSubGoodsMakerCd];       // 子商品メーカーコード
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctCntFlSt].Value = dr[StckAssemOvhulAcs.ctCntFlSt];                       // セットQTY（文字）
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctDivision].Value = dr[StckAssemOvhulAcs.ctDivision];                     // 提供区分
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctShipmentPosCnt].Value = dr[StckAssemOvhulAcs.ctShipmentPosCnt];         // 子現在在庫数（文字）
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctCntFl].Value = dr[StckAssemOvhulAcs.ctCntFl];                           // セットQTY
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubSupplierStock].Value = dr[StckAssemOvhulAcs.ctSubSupplierStock];     // 子現在在庫数
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubWarehouseCd].Value = dr[StckAssemOvhulAcs.ctSubWarehouseCd];         // 倉庫コード
            }

            grid.Refresh();
        }

        /// <summary>
        /// グリッド倉庫切替更新処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        private void UpdateGridSubWarehouseList(string warehouseCode, DataTable dataTable)
        {
            UltraGrid grid = this.GoodsSet_Grid;

            for (int ix = 0; ix < dataTable.Rows.Count; ix++)
            {
                DataRow dr = dataTable.Rows[ix];
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctShipmentPosCnt].Value = dr[StckAssemOvhulAcs.ctShipmentPosCnt];         // 子現在在庫数（文字）
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubSupplierStock].Value = dr[StckAssemOvhulAcs.ctSubSupplierStock];     // 子現在在庫数
                grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubWarehouseCd].Value = dr[StckAssemOvhulAcs.ctSubWarehouseCd];         // 倉庫コード
            }

            grid.Refresh();
        }

        #endregion

		#region グリッドキーマッピング設定
		/// <summary>
		/// グリッドキーマッピング設定
		/// </summary>
		/// <param name="grid">設定対象グリッド</param>
		private void MakeKeyMappingForGrid(UltraGrid grid)
		{
			GridKeyActionMapping enterMap;

			// Enterキー
			enterMap = new GridKeyActionMapping(Keys.Enter,
				UltraGridAction.NextCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// Shift + Enterキー
			enterMap = new GridKeyActionMapping(Keys.Enter,
				UltraGridAction.PrevCellByTab,
				0,
				UltraGridState.Cell,
				SpecialKeys.AltCtrl,
				SpecialKeys.Shift);
			grid.KeyActionMappings.Add(enterMap);

			// ↑キー
			enterMap = new GridKeyActionMapping(Keys.Up,
				UltraGridAction.AboveCell,
				UltraGridState.IsCheckbox,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// ↓キー
			enterMap  = new GridKeyActionMapping(Keys.Down,
				UltraGridAction.BelowCell,
				UltraGridState.IsCheckbox,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// 前頁キー
			enterMap  = new GridKeyActionMapping(Keys.Prior,
				UltraGridAction.PageUpCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);

			// 次頁キー
			enterMap  = new GridKeyActionMapping(Keys.Next,
				UltraGridAction.PageDownCell,
				0,
				UltraGridState.InEdit,
				SpecialKeys.All,
				0);
			grid.KeyActionMappings.Add(enterMap);
		}
		#endregion

		#region グリッド描画設定
		/// <summary>
		/// グリッド描画設定
		/// </summary>
		private void PrepareHistoryGridDisp()
		{
            #region ●表示幅設定
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].Width =  40;                   // No
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[1].Width = 200;                   // 品番
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[2].Width = 250;                   // 品名
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[3].Width =  60;                   // メーカー
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[4].Width =  70;                   // ＱＴＹ
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[5].Width =  75;                   // 提供区分
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[6].Width = 120;                   // 現在庫数
            #endregion

            #region ●セル内のデータ表示位置設定
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     // No
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;    // メーカー
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     // ＱＴＹ
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     // 現在庫数
            #endregion

            #region ●スタイル設定
            #endregion

            #region ●個別設定
            #region < No >
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.BackColor = this.GoodsSet_Grid.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.BackColor2 = this.GoodsSet_Grid.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.BackGradientStyle = this.GoodsSet_Grid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            //this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.ForeColor = this.GoodsSet_Grid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[0].CellAppearance.ForeColorDisabled = this.GoodsSet_Grid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion
            #endregion

            // 非表示項目
            for (int cnt = 7; cnt < this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns.Count; cnt++)
            {
                this.GoodsSet_Grid.DisplayLayout.Bands[0].Columns[cnt].Hidden = true;
            }
        }
		#endregion

        #region 在庫数チェック処理

        #region コメントアウト（旧ロジック）
        ///// <summary>
        ///// 入力可能最大件数取得処理
        ///// </summary>
        //private void GetShipmentMaxCnt()
        //{
        //    UltraGrid grid = this.GoodsSet_Grid;
        //    double maxCnt   = 999999.99;
        //    double wkQTY;
        //    double wkStck;
        //    double minCntCo = maxCnt;
        //    double minCntAn = maxCnt;
        //    double wkCnt = tNedit_ShipmentPosCnt.GetValue();

        //    // 明細存在チェック
        //    if (grid.Rows.Count == 0)
        //    {
        //        this.tNedit_ConstructionMaxCnt.Clear();
        //        this.tNedit_AnalysisMaxCnt.Clear();
        //        return;
        //    }
            
        //    // 子商品数量チェック
        //    for (int ix = 0; ix < grid.Rows.Count; ix++)
        //    {
        //        wkQTY = (double)grid.Rows[ix].Cells[StckAssemOvhulAcs.ctCntFl].Value;
        //        wkStck = (double)grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubSupplierStock].Value;

        //        // 対象外チェック
        //        if (wkQTY == 0)
        //        {
        //            minCntCo = 0.00;
        //            minCntAn = 0.00;
        //            break;
        //        }
        //        else
        //        {
        //            // 組立処理チェック
        //            if (wkStck <= 0)
        //            {
        //                minCntCo = 0.00;
        //            }
        //            else if ((wkStck / wkQTY) < minCntCo)
        //            {
        //                minCntCo = wkStck / wkQTY;
        //            }

        //            // 分解処理チェック
        //            if (wkStck > maxCnt)
        //            {
        //                minCntAn = 0.00;
        //            }
        //            else if (((maxCnt - wkStck) / wkQTY) < minCntAn)
        //            {
        //                minCntAn = (maxCnt - wkStck) / wkQTY;
        //            }
        //        }
        //    }

        //    // 親商品数量チェック
        //    // 組立処理チェック
        //    if ((wkCnt + minCntCo) > 999999.99)
        //    {
        //        minCntCo = 999999.99 - wkCnt;
        //    }
        //    // 分解処理チェック
        //    if (wkCnt <= 0)
        //    {
        //        minCntAn = 0.00;
        //    }
        //    else if (wkCnt < minCntAn)
        //    {
        //        minCntAn = wkCnt;
        //    }

        //    // 最大組立可能数
        //    this.tNedit_ConstructionMaxCnt.SetValue(minCntCo);
        //    // 最大分解可能数
        //    this.tNedit_AnalysisMaxCnt.SetValue(minCntAn);
        //    //Int64 longint;
        //    //Int64.TryParse(minCntAn.ToString(), out longint);
        //    //this.tNedit_AnalysisMaxCnt.SetValue(longint);
        //}
        #endregion

        /// <summary>
        /// 入力可能最大件数取得処理
        /// </summary>
        private void GetShipmentMaxCnt()
        {
            UltraGrid grid = this.GoodsSet_Grid;
            Int64 maxCnt = 99999999;
            Int64 wkCnt;
            Int64 wkQTY;
            Int64 wkStck;
            double wkQTYd;
            double wkStckd;

            Int64 minCntCo = maxCnt;
            Int64 minCntAn = maxCnt;

            // doubleのまま処理すると誤差が出る場合があるため100倍値のintで計算する
            Int64.TryParse((tNedit_ShipmentPosCnt.GetValue() * 100).ToString(), out wkCnt);

            // 明細存在チェック
            if (grid.Rows.Count == 0)
            {
                this.tNedit_ConstructionMaxCnt.Clear();
                this.tNedit_AnalysisMaxCnt.Clear();
                // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this.tNedit_MinCnt.SetValue(0.01);
                // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                return;
            }

            // 子商品数量チェック
            for (int ix = 0; ix < grid.Rows.Count; ix++)
            {
                wkQTYd = (double)grid.Rows[ix].Cells[StckAssemOvhulAcs.ctCntFl].Value;
                wkStckd = (double)grid.Rows[ix].Cells[StckAssemOvhulAcs.ctSubSupplierStock].Value;

                // 対象外チェック
                if (wkQTYd == 0)
                {
                    minCntCo = 0;
                    minCntAn = 0;
                    break;
                }
                else
                {
                    Int64.TryParse((wkQTYd * 100).ToString(), out wkQTY);
                    Int64.TryParse((wkStckd * 100).ToString(), out wkStck);

                    // 組立処理チェック
                    // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (wkStck <= 0)
                    //{
                    //    minCntCo = 0;
                    //}
                    //else if (((wkStck * 100) / wkQTY) < minCntCo)
                    //{
                    //    minCntCo = (wkStck * 100) / wkQTY;
                    //}
                    Int64 wkminCntCo;
                    if ((int)this.DecimalDiv_tComboEditor.Value == 0)
                    {
                        wkminCntCo = (wkStck * 100) / wkQTY;
                    }
                    else
                    {
                        wkminCntCo = (wkStck / wkQTY) * 100;
                    }
                    if (wkStck <= 0)
                    {
                        minCntCo = 0;
                    }
                    else if (wkminCntCo < minCntCo)
                    {
                        minCntCo = wkminCntCo;
                    }
                    // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 分解処理チェック
                    // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (wkStck > maxCnt)
                    //{
                    //    minCntAn = 0;
                    //}
                    //else if ((((maxCnt - wkStck) * 100) / wkQTY) < minCntAn)
                    //{
                    //    minCntAn = ((maxCnt - wkStck) * 100) / wkQTY;
                    //}
                    Int64 wkminCntAn;
                    if ((int)this.DecimalDiv_tComboEditor.Value == 0)
                    {
                        wkminCntAn = ((maxCnt - wkStck) * 100) / wkQTY;
                    }
                    else
                    {
                        wkminCntAn = ((maxCnt - wkStck) / wkQTY) * 100;
                    }
                    if (wkStck > maxCnt)
                    {
                        minCntAn = 0;
                    }
                    else if (wkminCntAn < minCntAn)
                    {
                        minCntAn = wkminCntAn;
                    }
                    // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            // 親商品数量チェック
            // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 組立処理チェック
            //if ((wkCnt + minCntCo) > 99999999)
            //{
            //    minCntCo = 99999999 - wkCnt;
            //}
            //// 分解処理チェック
            //if (wkCnt <= 0)
            //{
            //    minCntAn = 0;
            //}
            //else if (wkCnt < minCntAn)
            //{
            //    minCntAn = wkCnt;
            //}

            // 組立処理チェック
            if (wkCnt >= maxCnt)
            {
                minCntCo = 0;
            }
            else if ((wkCnt + minCntCo) > maxCnt)
            {
                minCntCo = maxCnt - wkCnt;
            }
            // 分解処理チェック
            Int64 wkCntAn = wkCnt;
            if ((int)this.DecimalDiv_tComboEditor.Value != 0)
            {
                wkCntAn = (wkCnt / 100) * 100;
            }
            if (wkCntAn <= 0)
            {
                minCntAn = 0;
            }
            else if (wkCntAn < minCntAn)
            {
                minCntAn = wkCntAn;
            }
            // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 最大組立可能数
            //this.tNedit_ConstructionMaxCnt.SetValue((double)minCntCo / 100);
            //// 最大分解可能数
            //this.tNedit_AnalysisMaxCnt.SetValue((double)minCntAn / 100);

            // 入力可能最小数取得
            GetShipmentMinCnt();

            if ((int)this.DecimalDiv_tComboEditor.Value == 0)
            {
                // 入力可能最小数チェック
                // doubleのまま処理すると誤差が出る場合があるため100倍値のintで計算する
                Int64 wkMinCnt;
                Int64.TryParse((tNedit_MinCnt.GetValue() * 100).ToString(), out wkMinCnt);
                if ((minCntCo % wkMinCnt) != 0)
                {
                    minCntCo = (minCntCo / wkMinCnt) * wkMinCnt;
                }
                if ((minCntAn % wkMinCnt) != 0)
                {
                    minCntAn = (minCntAn / wkMinCnt) * wkMinCnt;
                }

                // 最大組立可能数
                this.tNedit_ConstructionMaxCnt.SetValue((double)minCntCo / 100);
                // 最大分解可能数
                this.tNedit_AnalysisMaxCnt.SetValue((double)minCntAn / 100);
            }
            else
            {
                // 最大組立可能数
                this.tNedit_ConstructionMaxCnt.SetValue(minCntCo / 100);
                // 最大分解可能数
                this.tNedit_AnalysisMaxCnt.SetValue(minCntAn / 100);
            }
            // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 入力可能最小件数取得処理
        /// </summary>
        private void GetShipmentMinCnt()
        {
            UltraGrid grid = this.GoodsSet_Grid;
            Int64 wkQTY;
            double wkQTYd;
            double minCnt = 0.01;

            // 子商品数量チェック
            for (int ix = 0; ix < grid.Rows.Count; ix++)
            {
                wkQTYd = (double)grid.Rows[ix].Cells[StckAssemOvhulAcs.ctCntFl].Value;

                // 対象外チェック
                if (wkQTYd != 0)
                {
                    // doubleのまま処理すると誤差が出る場合があるため100倍値のintで計算する
                    Int64.TryParse((wkQTYd * 100).ToString(), out wkQTY);

                    if ((wkQTY % 10) != 0)
                    {
                        minCnt = 1;
                    }
                    else if ((wkQTY % 100) != 0)
                    {
                        if (minCnt != 1)
                        {
                            minCnt = 0.1;
                        }
                    }
                }
            }

            // 最小入力単位
            this.tNedit_MinCnt.SetValue(minCnt);
        }
        // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 在庫情報チェック処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        private bool ChkGridGoodsSet(double inputCnt)
        {
            bool chkFlg = true;

            // 親商品数量チェック
            if ((int)ProcessDiv_tComboEditor.Value == 0)
            {
                // 組立処理チェック
                if (((tNedit_ShipmentPosCnt.GetValue() + inputCnt) > 999999.99) ||
                    (tNedit_ConstructionMaxCnt.GetValue() < inputCnt))
                {
                    chkFlg = false;
                }
            }
            else
            {
                // 分解処理チェック
                if (((tNedit_ShipmentPosCnt.GetValue() - inputCnt) < 0) ||
                    (tNedit_AnalysisMaxCnt.GetValue() < inputCnt))
                {
                    chkFlg = false;
                }
            }

            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 最小入力値チェック
            if ((chkFlg != false) && ((int)DecimalDiv_tComboEditor.Value == 0))
            {
                Int64 wkCnt;
                Int64 wkMinCnt;

                // doubleのまま処理すると誤差が出る場合があるため100倍値のintで計算する
                Int64.TryParse((tNedit_InputCnt.GetValue() * 100).ToString(), out wkCnt);
                Int64.TryParse((tNedit_MinCnt.GetValue() * 100).ToString(), out wkMinCnt);

                if ((wkCnt % wkMinCnt) != 0)
                {
                    chkFlg = false;
                }
            }
            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return chkFlg;
        }
        #endregion

        #region Msg表示処理
        /// <summary>
		/// Msg表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="iMsg">表示メッセージ</param>
		/// <param name="iStatus">ステータス</param>
		/// <param name="iButton">ボタン</param>
		/// <param name="iDefButton">ボタン初期フォーカス</param>
		/// <returns></returns>
		private DialogResult ShowMsgDisp(emErrorLevel iLevel, string iMsg, int iStatus, string iProc, MessageBoxButtons iButton)
		{
			return TMsgDisp.Show(
				iLevel,						        //エラーレベル
				ctPGID,                             //UNIT　ID
				"在庫組立・分解処理",				//プログラム名称
				iProc,                              //プロセスID
				"",                                 //オペレーション
				iMsg,                               //メッセージ
				iStatus,                            //ステータス
				null,                               //オブジェクト
				iButton,				            //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);
		}
		#endregion
      
        #region 商品検索処理
        /// <summary>
        /// 商品検索処理
        /// </summary>
        private int GetSearchGoods(string searchCode, PartsInfoDataSet partsInfoDataSet, int mode)
        {
            //-------------------------------------------------------------------------
            // 優先倉庫設定
            //-------------------------------------------------------------------------
            // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //partsInfoDataSet.ListPriorWarehouse = this._sectWarehouseCd;
            if (mode == 1)
            {
                List<string> wkWarehouseCd = new List<string>();
                wkWarehouseCd.Add(this.tEdit_WarehouseCode.DataText.Trim());
                partsInfoDataSet.ListPriorWarehouse = wkWarehouseCd;
            }
            else
            {
                partsInfoDataSet.ListPriorWarehouse = this._sectWarehouseCd;
            }
            // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2009/02/12 -------------------------------->>>>>
            // 価格計算(同一品番選択ウィンドウ用)用のデリゲート追加
            if (partsInfoDataSet.CalculatePrice == null)
            {
                partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
            }

            partsInfoDataSet.PriceApplyDate = DateTime.Today;
            // --- ADD 2009/02/12 --------------------------------<<<<<

            //-------------------------------------------------------------------------
            // 同一品番検索選択UI
            //-------------------------------------------------------------------------
            // 2009.02.20 30413 犬飼 引数を修正 >>>>>>START
            //DialogResult retDialog = SelectionSamePartsNo.ShowDialog(partsInfoDataSet, 3);  // Mode 3:在庫組立・分解
            DialogResult retDialog = SelectionSamePartsNo.ShowDialog(this, partsInfoDataSet, 3);  // Mode 3:在庫組立・分解
            // 2009.02.20 30413 犬飼 引数を修正 <<<<<<END
            
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            switch (retDialog)
            {
                case DialogResult.Abort:
                case DialogResult.Cancel:
                    partsInfoDataSet.Clear();
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                case DialogResult.Yes:

                    // セット情報取得
                    status = this._stckAssemOvhulAcs.ReadStckAssemOvhul(this._enterpriseCode, this._loginSectionCode, 0, searchCode, partsInfoDataSet);

                    // グリッドクリア
                    if (status != 0)
                        this.GoodsSet_Grid.DataSource = null;

                    // グリッド情報取得
                    this.SetDispSearchGoods(searchCode);

                    // 組立分解可能数表示
                    bool chkFlg = true;
                    if (mode == 1)
                    {
                        // 更新時は情報を保持する
                        if (ChkGridGoodsSet(this.tNedit_InputCnt.GetValue()) == true) chkFlg = false;
                    }
                    if (chkFlg == true)
                    {
                        if (status != 0)
                        {
                            // 個数クリア
                            this.tNedit_InputCnt.Clear();
                        }
                        else if ((int)ProcessDiv_tComboEditor.Value == 0)
                        {
                            // 最大組立可能数
                            this.tNedit_InputCnt.SetValue(this.tNedit_ConstructionMaxCnt.GetValue());
                        }
                        else
                        {
                            // 最大分解可能数
                            this.tNedit_InputCnt.SetValue(this.tNedit_AnalysisMaxCnt.GetValue());
                        }
                    }

                    break;
                case DialogResult.Retry:
                    break;
            }        

            return status;
        }
        #endregion

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>
        /// 価格計算
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        private void CalcPrice(int taxationCode, double unitPrice, out double priceTaxExc, out double priceTaxInc)
        {
            // 総額表示しない 明細転嫁 
            this._stckAssemOvhulAcs.CalclatePrice(unitPrice, taxationCode, (int)StckAssemOvhulAcs.TotalAmountDispWayCd.NoTotalAmount, (int)StckAssemOvhulAcs.ConsTaxLayMethod.DetailLay, this._stckAssemOvhulAcs.TaxRate, out priceTaxExc, out priceTaxInc);
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<

        #region 商品表示処理
        /// <summary>
        /// 商品表示処理
        /// </summary>
        private void SetDispSearchGoods(string searchCode)
        {
            // グリッド表示用履歴データ取得
            this._stckAssemOvhulAcs.Read(searchCode, out this._prtStckAssemOvhul);

            // グリッド表示
            if (this.GoodsSet_Grid.DataSource == null)
            {
                this.GoodsSet_Grid.DataSource = this._prtStckAssemOvhul.Tables[StckAssemOvhulAcs.ctM_PrtStckAssemOvhul_Table];
            }
            else
            {
                this.UpdateGridSubGoodsList(this._prtStckAssemOvhul.Tables[StckAssemOvhulAcs.ctM_PrtStckAssemOvhul_Table]);
            }

            // グリッド描画処理
            this.SetUpGoodsSetGrid();

            // グリッド設定
            this.PrepareHistoryGridDisp();

            // ヘッダー情報処理
            this.UpdateParentGoodsData();

            // 組立分解可能数取得処理
            this.GetShipmentMaxCnt();
        }
        #endregion

        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        private void LoadSecInfoSet()
        {
            SecInfoSet secInfoSet;
            this._sectWarehouseCd = new List<string>();

            int status = this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

            if (status == 0)
            {
                if (secInfoSet.SectWarehouseCd1 != string.Empty) this._sectWarehouseCd.Add(secInfoSet.SectWarehouseCd1.Trim());
                if (secInfoSet.SectWarehouseCd2 != string.Empty) this._sectWarehouseCd.Add(secInfoSet.SectWarehouseCd2.Trim());
                if (secInfoSet.SectWarehouseCd3 != string.Empty) this._sectWarehouseCd.Add(secInfoSet.SectWarehouseCd3.Trim());
            }
        }

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        private void LoadWarehouse()
        {
            int status = 0;

            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;

                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        private void LoadMakerUMnt()
        {
            int status = 0;

            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim().PadLeft(4, '0')].WarehouseName.Trim();
            }

            return warehouseName;
        }
        
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        #endregion

        #region Control Events

        #region Form.Load イベント(PMZAI04020UA)
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMZAI04020UA_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
        }

        #endregion

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2008/11/05</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了ボタン
                case ctCLOSE_BUTTONTOOLKEY:
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                // 更新ボタン
                case ctSAVE_BUTTONTOOLKEY:
                    {
                        // 確定処理
                        Save();
                        break;
                    }
                // 倉庫切替ボタン
                case ctWCHANGE_BUTTONTOOLKEY:
                    {
                        // 倉庫切替処理
                        WarehouseChange();
                        break;
                    }
            }
        }

		#region Timer.Tick イベント(Initial_Timer)

		/// <summary>
		/// Timer.Tick イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
            this.Initial_Timer.Enabled = false;

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // 画面初期設定処理
            this.InitialSetting();
            this._isFirstFlag = false;
            // 初期フォーカス               
            this.ProcessDiv_tComboEditor.Focus();
        }

		#endregion

		#region フォーカスChangeイベント(tArrowKeyControl1, tRetKeyControl1)
		/// <summary>
		/// フォーカスChangeイベント(tArrowKeyControl1, tRetKeyControl1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
				return;
         
			// セット商品グリッドの時
			if (e.PrevCtrl == this.GoodsSet_Grid)
			{
				// リターンキー押下
				if (e.Key == Keys.Return)
				{
					e.NextCtrl = null;

					if (this.GoodsSet_Grid != null)
					{
						UltraGridCell activeCell = this.GoodsSet_Grid.ActiveCell;

						this.GoodsSet_Grid.PerformAction(UltraGridAction.NextCellByTab);
					}
				}
            }
            // 品番の時
            else if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                // 品番取得
                string searchCode = tEdit_GoodsNo.DataText.Trim();

                if (searchCode != "")
                {
                    // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 品番変更チェック
                    if (searchCode == this._searchCode) return;
                    // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    try
                    {
                        this.Cursor = Cursors.WaitCursor; // ADD 2009/02/12

                        PartsInfoDataSet partsInfoDataSet;
                        int status = this._stckAssemOvhulAcs.SearchGoodsAndGoodsSet(this._enterpriseCode, this._loginSectionCode, 0, searchCode, out partsInfoDataSet);

                        #region エラー表示
                        if (status == 0)
                        {
                            status = this.GetSearchGoods(searchCode, partsInfoDataSet, 0);

                            this.Cursor = Cursors.Default; // ADD 2009/02/12

                            if (status == 91)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.InputCnt_Title.Text,
                                    "在庫マスタに登録されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                e.NextCtrl = this.tEdit_GoodsNo;
                                // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                this._searchCode = string.Empty;
                                // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                return;
                            }
                            else if (status == 92)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.InputCnt_Title.Text,
                                    "商品セットマスタに登録されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                e.NextCtrl = this.tEdit_GoodsNo;
                                // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                this._searchCode = string.Empty;
                                // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                return;
                            }
                            else if (status == 93)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.InputCnt_Title.Text,
                                    "商品セットマスタに登録されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                e.NextCtrl = this.tEdit_GoodsNo;
                                // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                this._searchCode = string.Empty;
                                // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                return;
                            }
                            else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.InputCnt_Title.Text,
                                    "商品マスタに登録されていません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                e.NextCtrl = this.tEdit_GoodsNo;
                                // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                this._searchCode = string.Empty;
                                // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                return;
                            }

                            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // 品番保存
                            this._searchCode = searchCode;
                            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        else
                        {
                            this.Cursor = Cursors.Default; // ADD 2009/02/12

                            // 画面情報クリア
                            this.GoodsSet_Grid.DataSource = null;
                            this.SetDispSearchGoods(searchCode);
                            this.tNedit_InputCnt.Clear();

                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.InputCnt_Title.Text,
                                "商品マスタに登録されていません。",
                                -1,
                                MessageBoxButtons.OK);
                            e.NextCtrl = this.tEdit_GoodsNo;
                            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            this._searchCode = string.Empty;
                            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            return;
                        }
                    #endregion
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default; // ADD 2009/02/12
                    }
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        // フォーカス設定
                        if (this.tEdit_GoodsNo.DataText.Trim() == "")
                        {
                            e.NextCtrl = this.tEdit_GoodsNo;
                        }
                    }
                }
            }
            // 個数の時
            else if (e.PrevCtrl == this.tNedit_InputCnt)
            {
                // 個数取得
                double inputCnt = this.tNedit_InputCnt.GetValue();

                // 個数チェック
                if ((inputCnt != 0) &&
                    (this.ChkGridGoodsSet(inputCnt) == false))
                {
                    if ((int)ProcessDiv_tComboEditor.Value == 0)
                    {
                        // 最大組立可能数
                        this.tNedit_InputCnt.SetValue(this.tNedit_ConstructionMaxCnt.GetValue());
                    }
                    else
                    {
                        // 最大分解可能数
                        this.tNedit_InputCnt.SetValue(this.tNedit_AnalysisMaxCnt.GetValue());
                    }
                }
                // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                else if (tEdit_GoodsNo.Text.Trim() == string.Empty)
                {
                    this.tNedit_InputCnt.Clear();
                }
                // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                else
                {
                    this.tNedit_InputCnt.SetValue(inputCnt);
                }

                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        e.NextCtrl = this.tNedit_InputCnt;
                    }
                    // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    else if (e.Key == Keys.Down)
                    {
                        // フォーカス設定
                        if (this.tEdit_GoodsNo.DataText.Trim() == string.Empty)
                        {
                            e.NextCtrl = this.tNedit_InputCnt;
                        }
                    }
                    // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 小数点区分の時
            else if (e.PrevCtrl == this.DecimalDiv_tComboEditor)
            {
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Down)
                    {
                        // フォーカス設定
                        e.NextCtrl = this.tEdit_GoodsNo;
                    }
                }
            }
            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
		#endregion
		
        #region ガイドボタンクリックイベント
        #endregion

        #endregion

        #region 処理区分変更イベント
        /// <summary>
        /// 処理区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 処理区分が変更されると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2008/11/05</br>
        /// </remarks>
        private void ProcessDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (tEdit_GoodsNo.Text.Trim() != string.Empty)
            {
                if ((int)this.ProcessDiv_tComboEditor.Value == 0)
                {
                    // 処理区分＝組立
                    // 最大組立可能数
                    this.tNedit_InputCnt.SetValue(this.tNedit_ConstructionMaxCnt.GetValue());
                }
                else
                {
                    // 処理区分＝分解
                    // 最大分解可能数
                    this.tNedit_InputCnt.SetValue(this.tNedit_AnalysisMaxCnt.GetValue());
                }
            }
        }
        #endregion 処理区分変更イベント

        // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 小数点区分変更イベント
        /// <summary>
        /// 小数点区分変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 小数点区分が変更されると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2009/01/26</br>
        /// </remarks>
        private void DecimalDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.DecimalDiv_tComboEditor.Value == 0)
            {
                // 小数点処理する
                this.tNedit_InputCnt.NumEdit.DecLen = 2;
            }
            else
            {
                // 小数点処理しない
                this.tNedit_InputCnt.NumEdit.DecLen = 0;
            }

            if (tEdit_GoodsNo.Text.Trim() != string.Empty)
            {
                this.GetShipmentMaxCnt();
                if ((int)this.ProcessDiv_tComboEditor.Value == 0)
                {
                    // 処理区分＝組立
                    // 最大組立可能数
                    this.tNedit_InputCnt.SetValue(this.tNedit_ConstructionMaxCnt.GetValue());
                }
                else
                {
                    // 処理区分＝分解
                    // 最大分解可能数
                    this.tNedit_InputCnt.SetValue(this.tNedit_AnalysisMaxCnt.GetValue());
                }
            }
        }
        #endregion 小数点区分変更イベント
        // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
