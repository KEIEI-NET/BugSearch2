//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸過不足更新
// プログラム概要   : 棚卸過不足更新フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 妻鳥　謙一郎
// 作 成 日  2007.06.13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007.09.20  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008.02.26  修正内容 : 仕様変更対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/10  修正内容 : 仕様変更対応（Partsman対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/02  修正内容 : 排他制御処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応13105
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/22  修正内容 : 不具合対応[13263]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/14  修正内容 : 不具合対応[13920]
//                                  棚番EditのAutoWidthをTrueに変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/24  修正内容 : 不具合対応[14320]
//                                  棚番更新区分が逆になっている不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 楊明俊
// 修 正 日  2010/03/12  修正内容 : PM1005ＰＭ．ＮＳ５次改良
//                                  Redmine#3772の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/03/15  修正内容 : PM1005不具合対応
//                                  Redmine#3827の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/03/16  修正内容 : PM1005不具合対応
//                                  Redmine#3827の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日  2010/12/03  修正内容 : 過不足更新ボタンの制御変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 陳嘯
// 修 正 日  K2015/08/21  修正内容 : redmine#46790  棚卸過不足更新　メモリアウトの修正
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;
using System.Threading; // ADD 20011/01/11

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸過不足更新フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸過不足更新のフォームクラスです。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2007.06.13</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2007.06.13 men 新規作成</br>
    /// <br>Update Note: 2007.09.20 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.26 980035 金沢 貞義</br>
    /// <br>			 ・仕様変更対応（DC.NS対応）</br>
    /// <br>Update Note: 2008/09/10 30414 忍 幸史</br>
    /// <br>			 ・仕様変更対応（Partsman対応）</br>
    /// <br>Update Note: 2009/02/02 30452 上野 俊治</br>
    /// <br>			 ・排他制御処理追加</br>
    /// <br>Update Note: 2009/04/13 30452 上野 俊治</br>
    /// <br>			 ・障害対応13105</br>
    /// <br>Update Note: 2009/05/22       照田 貴志</br>
    /// <br>			 ・不具合対応[13263]</br>
    /// <br>Update Note: 2010/03/12 楊明俊 PM1005ＰＭ．ＮＳ５次改良</br>
    /// <br>              Redmine#3772の対応</br>
    /// <br>Update Note: 2010/03/15 楊明俊 不具合対応</br>
    /// <br>              Redmine#3827の対応</br>
    /// <br>Update Note: 2010/03/16 楊明俊 不具合対応</br>
    /// <br>              Redmine#3827の対応</br>
    /// <br>Update Note: 2010/12/03 田建委</br>
    /// <br>             過不足更新ボタンの制御変更</br>
    /// <br>Update Note: 2011/01/11 高峰</br>
    /// <br>             棚卸障害対応</br>
    /// </remarks>
	public partial class MAZAI05160UA : Form
	{
		# region Inner Class
		/// <summary>
		/// セル結合条件クラス（IMergedCellEvaluator インタフェースをインプリメント）
		/// </summary>
		private class CustomMergedCellEvaluatorGoodsCode : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
		{
			/// <summary>
			/// セル結合条件判定処理
			/// </summary>
			/// <param name="row1">行１</param>
			/// <param name="row2">行２</param>
			/// <param name="column">列</param>
			/// <returns>列に関連付けられたrow1とrow2のセルが結合される場合、Trueを返します</returns>
			public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
			{
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
				//int makerCode1 = Convert.ToInt32(row1.Cells["MakerCode"].Value);
				//int makerCode2 = Convert.ToInt32(row2.Cells["MakerCode"].Value);

                //string goodsCode1 = row1.Cells["GoodsCode"].Value.ToString();
				//string goodsCode2 = row2.Cells["GoodsCode"].Value.ToString();
                int makerCode1 = Convert.ToInt32(row1.Cells["GoodsMakerCd"].Value);
                int makerCode2 = Convert.ToInt32(row2.Cells["GoodsMakerCd"].Value);

                string goodsCode1 = row1.Cells["GoodsNo"].Value.ToString();
				string goodsCode2 = row2.Cells["GoodsNo"].Value.ToString();
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

				if ((goodsCode1.Trim() == "") || (goodsCode2.Trim() == "")) return false;
				return ((makerCode1 == makerCode2) && (goodsCode1 == goodsCode2));
			}
		}

		/// <summary>
		/// セル結合条件クラス（IMergedCellEvaluator インタフェースをインプリメント）
		/// </summary>
		private class CustomMergedCellEvaluatorWarehouseCode : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
		{
			/// <summary>
			/// セル結合条件判定処理
			/// </summary>
			/// <param name="row1">行１</param>
			/// <param name="row2">行２</param>
			/// <param name="column">列</param>
			/// <returns>列に関連付けられたrow1とrow2のセルが結合される場合、Trueを返します</returns>
			public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
			{
				string sectionCode1 = row1.Cells["SectionCode"].Value.ToString();
				string sectionCode2 = row2.Cells["SectionCode"].Value.ToString();

				string warehouseCode1 = row1.Cells["WarehouseCode"].Value.ToString();
				string warehouseCode2 = row2.Cells["WarehouseCode"].Value.ToString();

				if ((warehouseCode1.Trim() == "") || (warehouseCode2.Trim() == "")) return false;
				return ((sectionCode1 == sectionCode2) && (warehouseCode1 == warehouseCode2));
			}
		}
		# endregion

		# region コンストラクタ
		/// <summary>
		/// 棚卸過不足更新のコンストラクタです。
		/// </summary>
		public MAZAI05160UA()
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			this._loginEmployeeLabel = (LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			this._loginNameLabel = (LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
			this._closeButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._saveButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			this._clearButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
			this._searchButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			this._showErrorButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ShowError"];
			this._printButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
			   --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            
            this._controlScreenSkin = new ControlScreenSkin();
			this._inventoryUpdateAcs = new InventoryUpdateAcs();
			this._dataSet = this._inventoryUpdateAcs.DataSet;

            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //棚卸準備処理アクセスクラス
            this._inventoryPrepareAcs = new InventoryPrepareAcs();
            // 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<

            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseGuide = new WarehouseAcs();
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

            // ---------- ADD 20011/01/11 ---------->>>>>
            // グリッド設定ロード
            this._gridStateController = new GridStateController();
            this._gridStateController.LoadGridState(ctFILENAME_COLDISPLAYSTATUS);
            // ---------- ADD 20011/01/11 ----------<<<<<
        }
		# endregion

		# region プライベート変数
		private InventoryUpdateAcs _inventoryUpdateAcs;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private DateTime _baseDate = DateTime.MinValue;
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private ImageList _imageList16 = null;
		private ControlScreenSkin _controlScreenSkin;
		private InventoryUpdateDataSet _dataSet;
		private ColDisplayStatusList _colDisplayStatusList;						// 列表示状態コレクションクラス
		private Image _guideButtonImage;
        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
        private WarehouseAcs _warehouseGuide = null;                            //倉庫ガイド
        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
        // 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
        private InventoryPrepareAcs _inventoryPrepareAcs = null;                // 棚卸準備処理アクセスクラス
        // 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        private SecInfoSetAcs _secInfoSetAcs;
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        private ButtonTool _closeButton;				// 終了ボタン
        private ButtonTool _saveButton;					// 保存ボタン
        private ButtonTool _clearButton;				// 選択解除ボタン
        private ButtonTool _searchButton;				// 検索ボタン
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private ButtonTool _showErrorButton;			// エラー表示ボタン
		private ButtonTool _printButton;				// エラー情報印刷ボタン
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private LabelTool _loginEmployeeLabel;			// ログイン担当者タイトル
		private LabelTool _loginNameLabel;				// ログイン担当者名称

		private const string ctFILENAME_COLDISPLAYSTATUS = "MAZAI05150U_ColSetting.DAT";	// 列表示状態セッティングXMLファイル名

        // グリッドコントロールクラス                    
        private GridStateController _gridStateController = null; // ADD 2011/01/11

        # endregion

		# region プライベートメソッド

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 棚卸データの検索を行います。
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="inventoryDay">実施日</param>
		/// <param name="difCntExtraDiv">0:全て表示 1:過不足発生分のみ表示</param>
		/// <returns>STATUS</returns>
        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
		//private int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv)
        // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
        //private int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv, string warehouseCdSta, string warehouseCdEnd, string shelfNoSta, string shelfNoEnd)
        private int Search(string sectionCode, DateTime inventoryDay, int difCntExtraDiv, string warehouseCdSta, string warehouseCdEnd, string shelfNoSta, string shelfNoEnd)
        // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<
        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
		{
            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            //if ((inventoryDayEnd != DateTime.MinValue) && (inventoryDaySta > inventoryDayEnd))
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_INFO,
            //        this.Name,
            //        "棚卸日の範囲指定が不正です。",
            //        -1,
            //        MessageBoxButtons.OK);

            //    this.tDateEdit_InventoryDayEnd.Focus();
            //}
            if (inventoryDay == DateTime.MinValue)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "棚卸日の指定が不正です。",
                    -1,
                    MessageBoxButtons.OK);

                this.tDateEdit_InventoryDay.Focus();
                return -1;
            }
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //倉庫コード
            else if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != "") &&
                (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "倉庫コードの範囲指定が不正です。",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_WarehouseCode_Ed.Focus();
                return -1;
            }
            //棚番
            else if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != "") &&
                (this.tEdit_WarehouseShelfNo_St.DataText.CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText) > 0))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "棚番の範囲指定が不正です。",
                    -1,
                    MessageBoxButtons.OK);

                this.tEdit_WarehouseCode_Ed.Focus();
                return -1;
            }
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

            this.ErrorListVisibleControl(false);

			int status = -1;

			SFCMN00299CA msgForm = new SFCMN00299CA();
			msgForm.Title  = "抽出中";
			msgForm.Message = "棚卸データの抽出中です。";
			try
			{
				msgForm.Show();	// ダイアログ表示

                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //status = this._inventoryUpdateAcs.Search(sectionCode, inventoryDaySta, inventoryDayEnd, difCntExtraDiv);
                // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
                //status = this._inventoryUpdateAcs.Search(sectionCode, inventoryDaySta, inventoryDayEnd, difCntExtraDiv, warehouseCdSta, warehouseCdEnd, shelfNoSta, shelfNoEnd);
                status = this._inventoryUpdateAcs.Search(sectionCode, inventoryDay, DateTime.MaxValue, difCntExtraDiv, warehouseCdSta, warehouseCdEnd, shelfNoSta, shelfNoEnd);
                // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            }
			catch (Exception ex)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					ex.Message,
					-1,
					MessageBoxButtons.OK);

				return -1;
			}
			finally
			{
				msgForm.Close();
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 棚卸データグリッドの行、セル毎の設定を行う。
				this.SettingGridRow();

				if (this.uGrid_Result.Rows.Count > 0)
				{
					this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
					this.uGrid_Result.ActiveRow.Selected = true;
				}

				this.ultraOptionSet_DifCntExtraDiv_ValueChanged(this.ultraOptionSet_DifCntExtraDiv, EventArgs.Empty);
			}
            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            //else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
            //            (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            else
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<
            {
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"該当データが存在しません。",
					-1,
					MessageBoxButtons.OK);

				this.timer_InitFocusSetting.Enabled = true;
			}
            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            //else
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_STOPDISP,
            //        this.Name,
            //        "売上データの取得に失敗しました。",
            //        status,
            //        MessageBoxButtons.OK);

            //    this.timer_InitFocusSetting.Enabled = true;
            //}
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<
		
			this.SettingGridRow();

			// ツールバーボタンEnabled設定処理
			this.SettingToolBarButtonEnabled();

			// 行番号を採番します。
			this.NumberingRowNo();
			
			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸データ検索処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データの検索を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2010/03/12 楊明俊 PM1005ＰＭ．ＮＳ５次改良</br>
        /// <br>              Redmine#3772の対応</br>
        /// <br>Update Note: 2010/03/15 楊明俊 不具合対応</br>
        /// <br>              Redmine#3827の対応</br>
        /// <br>Update Note: 2010/03/16 楊明俊 不具合対応</br>
        /// <br>              Redmine#3827の対応</br>
        /// <br>Update Note: 2010/12/03 田建委</br>
        /// <br>             過不足更新ボタンの制御変更</br>
        /// <br>Update Note: K2015/08/21 陳嘯 棚卸過不足更新　メモリアウトの修正</br>
        /// <br>             Redmine#46790の対応</br>
        /// </remarks>
        private int Search()
        {
            // 抽出条件チェック
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return (-1);
            }

            // エラー非表示
            ErrorListVisibleControl(false);

            // 画面情報格納
            InventInputSearchCndtn inventInputSearchCndtn = new InventInputSearchCndtn();
            SetInventInputSearchCndtn(ref inventInputSearchCndtn);

            int status = -1;
            
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "棚卸データの抽出中です。";
            
            try
            {
                // ダイアログ表示
                msgForm.Show();	

                // 検索
                status = this._inventoryUpdateAcs.Search(inventInputSearchCndtn);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_STOPDISP,
                              this.Name,
                              ex.Message,
                              -1,
                              MessageBoxButtons.OK);

                return -1;
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 棚卸データグリッドの行、セル毎の設定を行う。
                        this.SettingGridRow();

                        if (this.uGrid_Result.Rows.Count > 0)
                        {
                            this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                            this.uGrid_Result.ActiveRow.Selected = true;
                        }
                        // -- DEL 2010/03/15 ----------------------------------->>>>>
                        // -- UPD 2010/03/12 ----------------------------------->>>>>
                        //else
                        //{
                        //    TMsgDisp.Show(this,
                        //                  emErrorLevel.ERR_LEVEL_INFO,
                        //                  this.Name,
                        //                  "該当データが存在しません。",
                        //                  -1,
                        //                  MessageBoxButtons.OK);

                        //    this.timer_InitFocusSetting.Enabled = true;
                        //}
                        // -- UPD 2010/03/12 -----------------------------------<<<<<
                        // -- DEL 2010/03/15 -----------------------------------<<<<<
                        this.ultraOptionSet_DifCntExtraDiv_ValueChanged(this.ultraOptionSet_DifCntExtraDiv, EventArgs.Empty);
                        // -- ADD 2010/03/16 ----------------------------------->>>>>
                        if (this.uGrid_Result.Rows.Count <= 0)
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "該当データが存在しません。",
                                          -1,
                                          MessageBoxButtons.OK);

                            this.timer_InitFocusSetting.Enabled = true;
                        }
                        // -- ADD 2010/03/16 ----------------------------------->>>>>
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        //this._saveButton.SharedProps.Enabled = false; // ADD 2010/12/03 // DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
                        this._saveButton.SharedProps.Enabled = true;  // ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "該当データが存在しません。",
                                      -1,
                                      MessageBoxButtons.OK);

                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "棚卸データの検索に失敗しました。",
                                      -1,
                                      MessageBoxButtons.OK);

                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
            }
            
            // グリッド設定
            SettingGridRow();

            // 行番号を採番します。
            NumberingRowNo();

            if (status == 0)
            {
                this.uGrid_Result.Focus();
                if (this.uGrid_Result.Rows.Count > 0)       //ADD 2009/05/22 不具合対応[13263]
                {                                           //ADD 2009/05/22 不具合対応[13263]
                    this.uGrid_Result.Rows[0].Activate();
                }                                           //ADD 2009/05/22 不具合対応[13263]
            }
            else
            {
                //this.tEdit_SectionCode.Focus();       //DEL 2009/05/22 不具合対応[13263]
                this.tDateEdit_InventoryDay.Focus();    //ADD 2009/05/22 不具合対応[13263]
            }

            return (status);
        }

        /// <summary>
        /// 棚卸データ検索条件設定処理
        /// </summary>
        /// <param name="inventInputSearchCndtn">棚卸データ検索条件クラス</param>
        /// <remarks>
        /// <br>Note       : 棚卸データ検索条件クラスを設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void SetInventInputSearchCndtn(ref InventInputSearchCndtn inventInputSearchCndtn)
        {
            // 企業コード
            inventInputSearchCndtn.EnterpriseCode = this._enterpriseCode;
            // 差異分抽出区分(数入力分のみ)   
            inventInputSearchCndtn.DifCntExtraDiv = 2;
            // ---DEL 2009/05/22 不具合対応[13263] ------------------------------------------------------>>>>>
            // 拠点コード
            //inventInputSearchCndtn.St_SectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            //inventInputSearchCndtn.Ed_SectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // ---DEL 2009/05/22 不具合対応[13263] ------------------------------------------------------<<<<<
            // 倉庫コード
            if (this.tEdit_WarehouseCode_St.DataText.Trim() == "")
            {
                inventInputSearchCndtn.St_WarehouseCode = "";
            }
            else
            {
                inventInputSearchCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText.Trim().PadLeft(4, '0');
            }
            if (this.tEdit_WarehouseCode_Ed.DataText.Trim() == "")
            {
                inventInputSearchCndtn.Ed_WarehouseCode = "";
            }
            else
            {
                inventInputSearchCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText.Trim().PadLeft(4, '0');
            }
            // 棚番
            inventInputSearchCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText.Trim();
            inventInputSearchCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText.Trim();
            // 仕入先コード
            inventInputSearchCndtn.St_SupplierCd = 0;
            inventInputSearchCndtn.Ed_SupplierCd = 999999;
            // BLコード
            inventInputSearchCndtn.St_BLGoodsCode = 0;
            inventInputSearchCndtn.Ed_BLGoodsCode = 99999;
            // グループコード
            inventInputSearchCndtn.St_BLGroupCode = 0;
            inventInputSearchCndtn.Ed_BLGroupCode = 99999;
            // メーカーコード
            inventInputSearchCndtn.St_MakerCode = 0;
            inventInputSearchCndtn.Ed_MakerCode = 9999;
            // 通番
            inventInputSearchCndtn.St_InventorySeqNo = 0;
            inventInputSearchCndtn.Ed_InventorySeqNo = 999999;
            // 棚卸日
            inventInputSearchCndtn.InventoryDate = this.tDateEdit_InventoryDay.GetDateTime();
        }

        /// <summary>
        /// 抽出条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件をチェックします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";
            try
            {
                // ---DEL 2009/05/22 不具合対応[13263] --------------------------------->>>>>
                //// 拠点コード
                //if (this.tEdit_SectionCode.DataText.Trim() == "")
                //{
                //    errMsg = "拠点コードが未入力です。";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}

                //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                //if (this._inventoryUpdateAcs.GetSectionName(sectionCode) == "")
                //{
                //    errMsg = "マスタに登録されていません。";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}
                // ---DEL 2009/05/22 不具合対応[13263] ---------------------------------<<<<<

                // 棚卸日
                if (this.tDateEdit_InventoryDay.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "棚卸日の指定が不正です。";
                    this.tDateEdit_InventoryDay.Focus();
                    return (false);
                }

                //倉庫コード
                if ((this.tEdit_WarehouseCode_St.DataText.Trim() != "") && (this.tEdit_WarehouseCode_Ed.DataText.Trim() != ""))
                {
                    if (this.tEdit_WarehouseCode_St.DataText.CompareTo(this.tEdit_WarehouseCode_Ed.DataText) > 0)
                    {
                        errMsg = "倉庫コードの範囲指定が不正です。";
                        this.tEdit_WarehouseCode_Ed.Focus();
                        return (false);
                    }
                }

                //棚番
                if ((this.tEdit_WarehouseShelfNo_St.DataText.Trim() != "") && (this.tEdit_WarehouseShelfNo_Ed.DataText.Trim() != ""))
                {
                    if (this.tEdit_WarehouseShelfNo_St.DataText.CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText) > 0)
                    {
                        errMsg = "棚番の範囲指定が不正です。";
                        this.tEdit_WarehouseCode_Ed.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  -1,
                                  MessageBoxButtons.OK);
                }
            }

            return (true);
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 棚卸売上データを保存します。
		/// </summary>
		/// <param name="isShowSaveCompletionDialog">保存完了ダイアログ表示フラグ</param>
		/// <returns>true:保存完了 false:未保存</returns>
		private bool Save(bool isShowSaveCompletionDialog)
		{
			string message;
			bool isSaved;
            int shelfNoDiv;
            if (this.ultraOptionSet_ShelfNoDiv.CheckedIndex == 0)
            {
                shelfNoDiv = 1;
            }
            else
            {
                shelfNoDiv = 0;
            }
            int status = this._inventoryUpdateAcs.Save(out isSaved, out message, shelfNoDiv);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (isShowSaveCompletionDialog)
				{
					SaveCompletionDialog dialog = new SaveCompletionDialog();
					dialog.ShowDialog(2);
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"更新対象データが存在しません。",
					-1,
					MessageBoxButtons.OK);

			}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
			//{
			//}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)					// 警告
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"過不足更新に失敗しました。" + "\r\n" + "\r\n" +
					"エラー情報を表示します。",
					-1,
					MessageBoxButtons.OK);

				this.ErrorListVisibleControl(true);
			}
			else if (status == -1)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"更新対象データが存在しません。",
					status,
					MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"過不足更新に失敗しました。" + "\r\n" + "\r\n" +
					message,
					status,
					MessageBoxButtons.OK);
			}

			this.SettingGridRow();

			// ツールバーボタンEnabled設定処理
			this.SettingToolBarButtonEnabled();

			return isSaved;
		}

		/// <summary>
		/// 棚卸売上データ過不足更新のチェックを行います。
		/// </summary>
		private bool ErrorCheck(bool showOkMessage)
		{
			bool isError = false;
			int status = this._inventoryUpdateAcs.ErrorCheck();

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (showOkMessage)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"過不足更新のエラーチェックが正常に完了しました。" + "\r\n" + "\r\n" +
						"エラーが発生する棚卸データは存在しません。",
						-1,
						MessageBoxButtons.OK);
				}

				this.ErrorListVisibleControl(false);
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"エラーチェック対象データが存在しません。",
					-1,
					MessageBoxButtons.OK);

				isError = true;
			}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
			//{
			//}
			//else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
			//{
			//}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)					// 警告
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"エラーが発生する棚卸データが存在します。" + "\r\n" + "\r\n" +
					"エラー情報を表示します。",
					-1,
					MessageBoxButtons.OK);

				this.ErrorListVisibleControl(true);
				isError = true;
			}
			else if (status == -1)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"エラーチェック対象データが存在しません。",
					status,
					MessageBoxButtons.OK);
				isError = true;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"エラーチェックに失敗しました。",
					status,
					MessageBoxButtons.OK);
				isError = true;
			}

			if (isError)
			{
				this.SettingGridRow();

				// ツールバーボタンEnabled設定処理
				this.SettingToolBarButtonEnabled();
			}

			if (isError)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸売上保存処理
        /// </summary>
        /// <returns>true:保存完了 false:未保存</returns>
        /// <remarks>
        /// <br>Note       : 棚卸売上データを保存します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2010/03/12 楊明俊 PM1005ＰＭ．ＮＳ５次改良</br>
        /// <br>              Redmine#3772の対応</br>
        /// <br>Update Note: K2015/08/21 陳嘯 棚卸過不足更新　メモリアウトの修正</br>
        /// <br>             Redmine#46790の対応</br>
        /// </remarks>
        private bool Save()
        {
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            this.Name,
                                            "登録してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
            {
                return (false);
            }

            string message;
            bool isSaved;
            int shelfNoDiv;

            // -- UPD 2009/09/24 ----------------------------------->>>
            //if (this.ultraOptionSet_ShelfNoDiv.CheckedIndex == 0)
            //{
            //    shelfNoDiv = 1;
            //}
            //else
            //{
            //    shelfNoDiv = 0;
            //}
            shelfNoDiv = this.ultraOptionSet_ShelfNoDiv.CheckedIndex;
            // -- UPD 2009/09/24 -----------------------------------<<<
            // -- UPD 2010/03/12 ----------------------------------->>>>>
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "棚卸過不足更新";
            msgForm.Message = "現在、棚卸過不足更新処理中です。";
            int status = -1;
            try
            {
                // ダイアログ表示
                msgForm.Show();
                this.Cursor = Cursors.WaitCursor;

                // 保存処理
                status = this._inventoryUpdateAcs.Save(out isSaved, out message, shelfNoDiv);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                msgForm.Close();
            }

            //// 保存処理
            //int status = this._inventoryUpdateAcs.Save(out isSaved, out message, shelfNoDiv);
            // -- UPD 2010/03/12 -----------------------------------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // -- UPD 2010/03/12 ----------------------------------->>>>>
                        // 完了メッセージ表示
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "更新しました",
                                      status,
                                      MessageBoxButtons.OK);
                        //SaveCompletionDialog dialog = new SaveCompletionDialog();
                        //dialog.ShowDialog(2);
                        // -- UPD 2010/03/12 -----------------------------------<<<<<
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "更新対象データが存在しません。",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WARNING:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "過不足更新に失敗しました。" + "\r\n" + "\r\n" +
                                      "エラー情報を表示します。",
                                      status,
                                      MessageBoxButtons.OK);

                        // エラー表示
                        ErrorListVisibleControl(true);
                        break;
                    }
                // --- ADD 2009/02/02 -------------------------------->>>>>
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "シェアチェックエラー(企業ロック)です。" + "\r\n"
                            + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                            + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                            + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                // --- ADD 2009/02/02 --------------------------------<<<<<
                // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
                case (-100): // メモリアウト対応
                    {
                        // 過不足更新失敗メッセージ表示
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "過不足更新に失敗しました。\n再度過不足更新を実行して下さい。\n※抽出を実行することでメモリ使用量が増加しますので、\n　在庫登録が多い場合は、抽出せずに実行して下さい。",
                                      status,
                                      MessageBoxButtons.OK);
                        this.Clear();
                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
                // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "過不足更新に失敗しました。" + "\r\n" + "\r\n" +
                                      message,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
            }

            // グリッド設定
            SettingGridRow();

            return isSaved;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        /// <summary>
        /// 過不足更新処理
        /// </summary>
        /// <returns>true:保存完了 false:未保存</returns>
        /// <remarks>
        /// <br>Note       : データを0件取得した場合は、過不足更新処理を行う。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private bool TolerancUpdate()
        {
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            this.Name,
                                            "過不足更新前に内容を確認したい場合は、一度抽出を実行して下さい。\n※但し、抽出を実行することでメモリ使用量が増加しますので、\n　在庫登録が多い場合は、抽出せずに実行して下さい。\n\n過不足更新を続行しますか？",
                                            0,
                                            MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return (false);
            }
            // 抽出条件チェック
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return (false);
            }

            // エラー非表示
            ErrorListVisibleControl(false);
            // 画面情報格納
            InventInputSearchCndtn inventInputSearchCndtn = new InventInputSearchCndtn();
            SetInventInputSearchCndtn(ref inventInputSearchCndtn);
            
            string message = string.Empty;
            bool isSaved = false;
            int shelfNoDiv;
            shelfNoDiv = this.ultraOptionSet_ShelfNoDiv.CheckedIndex;
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "棚卸過不足更新";
            msgForm.Message = "現在、棚卸過不足更新処理中です。";
            int status = -1;
            try
            {
                // ダイアログ表示
                msgForm.Show();
                this.Cursor = Cursors.WaitCursor;
                // 検索
                status = this._inventoryUpdateAcs.SearchAndUpdate(inventInputSearchCndtn, shelfNoDiv, out isSaved, out message);
                
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // ダイアログを閉じる
                msgForm.Close();
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 完了メッセージ表示
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "更新しました",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "更新対象データが存在しません。",
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WARNING:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                      this.Name,
                                      "過不足更新に失敗しました。" + "\r\n" + "\r\n" +
                                      "エラー情報を表示します。",
                                      status,
                                      MessageBoxButtons.OK);

                        // エラー表示
                        ErrorListVisibleControl(true);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "シェアチェックエラー(企業ロック)です。" + "\r\n"
                            + "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "シェアチェックエラー(拠点ロック)です。" + "\r\n"
                            + "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "シェアチェックエラー(倉庫ロック)です。" + "\r\n"
                            + "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。",
                            status,
                            MessageBoxButtons.OK);

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_STOPDISP,
                                      this.Name,
                                      "過不足更新に失敗しました。" + "\r\n" + "\r\n" +
                                      message,
                                      status,
                                      MessageBoxButtons.OK);
                        break;
                    }
            }

            return isSaved;
        }
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private void Print()
		{
			SFCMN06002C printInfo = new SFCMN06002C();						// 印刷情報パラメータ
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;	// 企業コード
			printInfo.kidopgid = "MAZAI05150U";								// 起動ＰＧＩＤ
			printInfo.printmode = 1;										// 印刷モード(1:通常印刷,2:PDF,3:両方)
			printInfo.prevkbn = 0;											// 印刷

            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryUpdateAcs.SettingErrorDataHeaderInfo(this.tComboEditor_SectionCode.Value.ToString(), this.tComboEditor_SectionCode.Text, this.tDateEdit_InventoryDay.GetDateTime(), this.tDateEdit_InventoryDayEnd.GetDateTime());
            // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            //this._inventoryUpdateAcs.SettingErrorDataHeaderInfo(this.tComboEditor_SectionCode.Value.ToString(), this.tComboEditor_SectionCode.Text, this.tDateEdit_InventoryDay.GetDateTime(), DateTime.MaxValue);

            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
            string sectionName = this._inventoryUpdateAcs.GetSectionName(sectionCode);
            DateTime inventoryDay = this.tDateEdit_InventoryDay.GetDateTime();

            this._inventoryUpdateAcs.SettingErrorDataHeaderInfo(sectionCode, sectionName, inventoryDay, DateTime.MaxValue);
            // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<
            
            printInfo.rdData = this._inventoryUpdateAcs.DataSet.ErrorData;

			SFCMN06001U printDialog = new SFCMN06001U();
			printDialog.PrintInfo = printInfo;

			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

			if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"該当するデータがありません",
					0,
					MessageBoxButtons.OK);
			}
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 画面を初期化します。
		/// </summary>
		private void Clear()
		{
			this._inventoryUpdateAcs.Clear();
			this.tDateEdit_InventoryDay.Clear();
            // 2008.02.26 削除 >>>>>>>>>>>>>>>>>>>>
            //this.tDateEdit_InventoryDayEnd.SetDateTime(DateTime.Today);
            // 2008.02.26 削除 <<<<<<<<<<<<<<<<<<<<

            this.tComboEditor_SectionCode.Value = LoginInfoAcquisition.Employee.BelongSectionCode;
            
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            this.tEdit_WarehouseCode_St.Clear();
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseShelfNo_St.Clear();
            this.tEdit_WarehouseShelfNo_Ed.Clear();
            this.ultraOptionSet_ShelfNoDiv.CheckedIndex = 0;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

			// エラー表示／非表示コントロール処理
			this.ErrorListVisibleControl(false);

			// ツールバーボタンEnabled設定処理
			this.SettingToolBarButtonEnabled();
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2010/12/03 田建委</br>
        /// <br>             過不足更新ボタンの制御変更</br>
        /// <br>Update Note: K2015/08/21 陳嘯 棚卸過不足更新　メモリアウトの修正</br>
        /// <br>             Redmine#46790の対応</br>
        /// </remarks>
        private void Clear()
        {
            this._inventoryUpdateAcs.Clear();
            this.tDateEdit_InventoryDay.Clear();
            //this._saveButton.SharedProps.Enabled = false; // DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
            // ---DEL 2009/05/22 不具合対応[13263] ------------------------------------------------------------------------------------->>>>>
            //this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this.tEdit_SectionName.DataText = this._inventoryUpdateAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // ---DEL 2009/05/22 不具合対応[13263] -------------------------------------------------------------------------------------<<<<<
            this.tEdit_WarehouseCode_St.Clear();
            this.tEdit_WarehouseCode_Ed.Clear();
            this.tEdit_WarehouseShelfNo_St.Clear();
            this.tEdit_WarehouseShelfNo_Ed.Clear();
            this.ultraOptionSet_ShelfNoDiv.CheckedIndex = 1;

            // エラー表示／非表示コントロール処理
            this.ErrorListVisibleControl(false);
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 売上データグリッドの行、セル毎の設定を行います。
		/// </summary>
		private void SettingGridRow()
		{
			try
			{
				// 描画を一時停止
				this.uGrid_Result.BeginUpdate();

				// 描画が必要な明細件数を取得する。
				int cnt = this.uGrid_Result.Rows.Count;

				// 各行ごとの設定
				for (int i = 0; i < cnt; i++)
				{
					this.SettingGridRow(i);
				}
			}
			finally
			{
				// 描画を開始
				this.uGrid_Result.EndUpdate();
			}
		}

		/// <summary>
		/// 明細グリッド・行単位でのセル設定
		/// </summary>
		/// <param name="rowIndex">対象行インデックス</param>
		private void SettingGridRow(int rowIndex)
		{
			UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
			if (editBand == null) return;

			// 行番号を取得
			int rowNo = Convert.ToInt32(this.uGrid_Result.Rows[rowIndex].Cells[this._dataSet.Inventory.RowNoColumn.ColumnName].Value);

			// 指定行の全ての列に対して設定を行う。
			foreach (UltraGridColumn col in editBand.Columns)
			{
				// セル情報を取得
				UltraGridCell cell = this.uGrid_Result.Rows[rowIndex].Cells[col];
				if (cell == null) continue;
			}
		}

		/// <summary>
		/// 列表示状態クラスリストを構築します。
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <returns>列表示状態クラスリスト</returns>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction(ColumnsCollection columns)
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// グリッドから列表示状態クラスリストを構築
			foreach (UltraGridColumn column in columns)
			{
				if (column.Hidden) continue;

				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;

				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
        }

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// コントロール有効無効設定処理
		/// </summary>
		private void SettingEnabledControl()
		{
			//
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// 行番号を採番します。
		/// </summary>
		private void NumberingRowNo()
		{
			int rowNo = 1;
			foreach (UltraGridRow row in this.uGrid_Result.Rows)
			{
				row.Cells[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].Value = rowNo;
				rowNo++;
			}

			this.uGrid_Result.UpdateData();
        }

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ツールバーボタンEnabled設定処理
		/// </summary>
		private void SettingToolBarButtonEnabled()
		{
			if (this._inventoryUpdateAcs.DataSet.ErrorData.Rows.Count > 0)
			{
				this._printButton.SharedProps.Enabled = true;
			}
			else
			{
				this._printButton.SharedProps.Enabled = false;
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// エラー表示／非表示コントロール処理
		/// </summary>
		/// <param name="visible">true:表示 false:非表示</param>
		private void ErrorListVisibleControl(bool visible)
		{
			this.panel_ErrorListContainer.Visible = visible;
			this.splitter_ErrorSplitter.Visible = visible;
		}

		# endregion

		# region 各種コントロールイベント処理
		/// <summary>
		/// 棚卸過不足更新ロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAZAI05150UA_Load(object sender, EventArgs e)
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			this._showErrorButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NOTPRINTOUT;
			this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

			// スキンロード
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			List<string> controlNameList = new List<string>();
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            //this._controlScreenSkin.LoadSkin();
            //this._controlScreenSkin.SettingScreenSkin(this);

			this.uGrid_Result.DataSource = this._inventoryUpdateAcs.DataView;
			this.uGrid_ErrorList.DataSource = this._inventoryUpdateAcs.ErrorDataView;

            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			// 拠点コンボボックスのアイテムを設定する
			this._inventoryUpdateAcs.SetSectionComboEditor(ref this.tComboEditor_SectionCode, false);
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/

            // 本社機能チェック
            // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            //if (this._inventoryUpdateAcs.IsMainOfficeFunc())
            //{
            //    this.tComboEditor_SectionCode.Enabled = true;
            //}
            //else
            //{
            //    this.tComboEditor_SectionCode.Enabled = false;
            //}

            // 2008.12.25 [9572]
            //if (this._inventoryUpdateAcs.IsMainOfficeFunc())
            //{
                // ---DEL 2009/05/22 不具合対応[13263] ------------->>>>>
                //this.tEdit_SectionCode.Enabled = true;
                //this.SectionGuide_Button.Enabled = true;
                // ---DEL 2009/05/22 不具合対応[13263] -------------<<<<<
            //}
            //else
            //{
            //    this.tEdit_SectionCode.Enabled = false;
            //    this.SectionGuide_Button.Enabled = false;
            //}
            // 2008.12.25 [9572]
            // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

			/// 画面を初期化する。
			this.Clear();

			this.timer_InitFocusSetting.Enabled = true;
        }

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				// 棚卸日
				case "tDateEdit_InventoryDay":
				{
					break;
				}
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// 検索結果グリッドレイアウト初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in this.uGrid_Result.DisplayLayout.Bands[0].Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;
				col.CellAppearance.TextHAlign = HAlign.Left;
				col.CellAppearance.ImageHAlign = HAlign.Left;
				col.CellAppearance.ImageVAlign = VAlign.Middle;
			}

			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockUnitPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockTotalColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            // 2008.02.26 追加 >>>>>>>>>>>>>>>>>>>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockTotalColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            // 2008.02.26 追加 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;

			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.FontData.Bold = DefaultableBoolean.True;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.RowNoDisplayColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            //string moneyFormat = "#,##0;-#,##0;0";
            string moneyFormat = "#,##0.00;-#,##0.00;0.00";
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockUnitPriceColumn.ColumnName].Format = moneyFormat;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.StockTotalColumn.ColumnName].Format = moneyFormat;
            // 2008.02.26 追加 >>>>>>>>>>>>>>>>>>>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockTotalColumn.ColumnName].Format = moneyFormat;
            // 2008.02.26 追加 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryStockCntColumn.ColumnName].Format = moneyFormat;
			this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName].Format = moneyFormat;

			// 列表示状態クラスリストXMLファイルをデシリアライズ
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.Inventory);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Result.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Hidden = false;
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
					this.uGrid_Result.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
				}
			}

			// セルの結合
			List<string> mergedColumnList = new List<string>();
			mergedColumnList.Add(this._dataSet.Inventory.GoodsNoColumn.ColumnName);
			mergedColumnList.Add(this._dataSet.Inventory.GoodsNameColumn.ColumnName);

			foreach (string key in mergedColumnList)
			{
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorGoodsCode();
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}

			List<string> mergedColumnListWarehouseCode = new List<string>();
			mergedColumnListWarehouseCode.Add(this._dataSet.Inventory.WarehouseNameColumn.ColumnName);

			foreach (string key in mergedColumnListWarehouseCode)
			{
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorWarehouseCode();
				this.uGrid_Result.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}

            //グリッド設定
            this.ResultGridDisp(); // ADD 2011/01/11
        }

		/// <summary>
		/// エラー表示グリッドレイアウト初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_ErrorList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns)
			{
				// 全ての列をいったん非表示にする。
				col.Hidden = true;
				col.CellAppearance.TextHAlign = HAlign.Left;
				col.CellAppearance.ImageHAlign = HAlign.Left;
				col.CellAppearance.ImageVAlign = VAlign.Middle;
			}

			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].Hidden = false;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].Hidden = false;
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].Hidden = false;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].Hidden = false;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].Hidden = false;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].Hidden = false;

			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].Width = 150;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].Width = 220;
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].Width = 170;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].Width = 170;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].Width = 100;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].Width = 345;

			int visiblePosition = 0;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].Header.VisiblePosition = ++visiblePosition;

			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ProductNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.InventorySeqNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;
			this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[this._dataSet.ErrorData.ErrorColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;

			// セルの結合
			List<string> mergedColumnListErrorGoodsCode = new List<string>();
			mergedColumnListErrorGoodsCode.Add(this._dataSet.ErrorData.GoodsNoColumn.ColumnName);
			mergedColumnListErrorGoodsCode.Add(this._dataSet.ErrorData.GoodsNameColumn.ColumnName);

			foreach (string key in mergedColumnListErrorGoodsCode)
			{
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorGoodsCode();
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}

			List<string> mergedColumnListWarehouseCode = new List<string>();
			mergedColumnListWarehouseCode.Add(this._dataSet.ErrorData.WarehouseNameColumn.ColumnName);

			foreach (string key in mergedColumnListWarehouseCode)
			{
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellStyle = MergedCellStyle.Always;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellContentArea = MergedCellContentArea.VisibleRect;
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellEvaluator = new CustomMergedCellEvaluatorWarehouseCode();
				this.uGrid_ErrorList.DisplayLayout.Bands[0].Columns[key].MergedCellAppearance.BackGradientStyle = GradientStyle.None;
			}
        }

		/// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
                // 終了ボタン
				case "ButtonTool_Close":
				{
					this.Close();
					break;
				}
                // 過不足更新ボタン
				case "ButtonTool_Save":
				{
                    // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
                    //if (this.ErrorCheck(false))
                    //{
                    //    if (this.Save(true))
                    //    {
                    //        this.Clear();
                    //        this.timer_InitFocusSetting.Enabled = true;
                    //    }
                    //}
                    // --- DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
                    //if (Save())
                    //{
                    //    Clear();
                    //    this.timer_InitFocusSetting.Enabled = true;
                    //}
                    // --- DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<
                    // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
                    //「抽出」ボタンにより、データを１件以上取得した場合は、既存の流れに従い、画面抽出データを元に過不足更新処理を行う。
                    if (this.uGrid_Result.Rows.Count != 0)
                    {
                        if (Save())
                        {
                            Clear();
                            this.timer_InitFocusSetting.Enabled = true;
                        }
                    }
                    // データを0件取得した場合は、過不足更新処理を行う。
                    else 
                    {
                        if (TolerancUpdate())
                        {
                            Clear();
                            this.timer_InitFocusSetting.Enabled = true;
                        }
                    }
                    // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<
                    // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

					break;
				}
                // クリアボタン
				case "ButtonTool_Clear":
				{
					this.Clear();
					this.timer_InitFocusSetting.Enabled = true;
					break;
				}
                // 抽出ボタン
				case "ButtonTool_Search":
				{
                    // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
                    //// 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    ////this.Search(this.tComboEditor_SectionCode.Value.ToString(), this.tDateEdit_InventoryDay.GetDateTime(), this.tDateEdit_InventoryDayEnd.GetDateTime(), Convert.ToInt32(this.ultraOptionSet_DifCntExtraDiv.Value));
                    //this.Search(this.tComboEditor_SectionCode.Value.ToString(),
                    //            this.tDateEdit_InventoryDay.GetDateTime(),
                    //            // 2008.02.26 削除 >>>>>>>>>>>>>>>>>>>>
                    //            //this.tDateEdit_InventoryDayEnd.GetDateTime(),
                    //            // 2008.02.26 削除 <<<<<<<<<<<<<<<<<<<<
                    //            Convert.ToInt32(this.ultraOptionSet_DifCntExtraDiv.Value),
                    //            this.tEdit_WarehouseCode_St.DataText,
                    //            this.tEdit_WarehouseCode_Ed.DataText,
                    //            this.tEdit_WarehouseShelfNo_St.DataText,
                    //            this.tEdit_WarehouseShelfNo_Ed.DataText);
                    //// 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

                    Search();
                    // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

					break;
				}
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // エラーチェックボタン
            case "ButtonTool_ShowError":
            {
                this.ErrorCheck(true);
                break;
            }
            // エラー情報印刷ボタン
            case "ButtonTool_Print":
            {
                this.Print();
                break;
            }
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        }
		}

		/// <summary>
		/// 初期フォーカス設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸日の初期表示方法の変更</br>
		private void timer_InitFocusSetting_Tick(object sender, EventArgs e)
		{
			this.timer_InitFocusSetting.Enabled = false;

            // ---DEL 2009/05/22 不具合対応[13263] --------------------------------------------------------->>>>>
            //// --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
            ////this.tDateEdit_InventoryDay.Focus();
            //this.tEdit_SectionCode.Focus();
            //// --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<
            // ---DEL 2009/05/22 不具合対応[13263] ---------------------------------------------------------<<<<<
            this.tDateEdit_InventoryDay.Focus();        //ADD 2009/05/22 不具合対応[13263]

            // 2007.09.20 追加 >>>>>>>>>>>>>>>>>>>>
            // 画面初期設定処理
            //アイコン(☆) 
            ImageList imageList16 = IconResourceManagement.ImageList16;
            //倉庫ガイド
            this.WarehouseGuideSt_Button.ImageList = imageList16;
            this.WarehouseGuideEd_Button.ImageList = imageList16;
            this.WarehouseGuideSt_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuideEd_Button.Appearance.Image = Size16_Index.STAR1;
            // ---DEL 2009/05/22 不具合対応[13263] --------------------------------------------------------->>>>>
            //// --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            //this.SectionGuide_Button.ImageList = imageList16;
            //this.SectionGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //// --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<
            // ---DEL 2009/05/22 不具合対応[13263] ---------------------------------------------------------<<<<<
            // 2007.09.20 追加 <<<<<<<<<<<<<<<<<<<<

            // コントロールサイズ設定
            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            //this.tEdit_SectionCode.Size = new Size(28, 24);               //DEL 2009/05/22 不具合対応[13263]
            //this.tEdit_SectionName.Size = new Size(131, 24);              //DEL 2009/05/22 不具合対応[13263]
            this.tEdit_WarehouseCode_St.Size = new Size(52, 24);
            this.tEdit_WarehouseCode_Ed.Size = new Size(52, 24);
            this.tEdit_WarehouseShelfNo_St.Size = new Size(76, 24);
            this.tEdit_WarehouseShelfNo_Ed.Size = new Size(76, 24);
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

            // 2008.02.26 追加 >>>>>>>>>>>>>>>>>>>>
            //対象年月日に最終棚卸準備処理日付をセット
            //履歴データ取得
            DataSet prtIvntHisDataSet;
            DataView dv = new DataView();
            DataView dvSection = new DataView(); // ADD 2009/12/03
            this._inventoryPrepareAcs.Read(out prtIvntHisDataSet);
            dv.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table];
            dvSection.Table = prtIvntHisDataSet.Tables[InventoryPrepareAcs.ctM_PrtIvntHis_Table]; // ADD 2009/12/03

            // --- DEL 2009/12/03 ---------->>>>>
            //for (int ix = 0; ix < dv.Count; ix++)
            //{
            //    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
            //    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
            //        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
            //    {
            //        this.tDateEdit_InventoryDay.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
            //        break;
            //    }
            //}
            // --- DEL 2009/12/03 ----------<<<<<

            // --- ADD 2009/12/03 ---------->>>>>
            // ログイン拠点
            dvSection.RowFilter = String.Format("{0}={1}", InventoryPrepareAcs.ctSectionCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            // ソート順：更新日付
            dvSection.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";
            // ログイン拠点に該当するデータ有り：ログイン拠点に該当する最新データから棚卸日を取得
            if (dvSection.Count > 0)
            {
                foreach (DataRowView drv in dvSection)
                {
                    // 削除した履歴データは対象外
                    if ((int)drv[InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((drv[InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)drv[InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.tDateEdit_InventoryDay.SetLongDate((int)drv[InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // ログイン拠点に該当するデータ無し：拠点に関係なく最新データから棚卸日を取得
            else
            {
                // ソート順：更新日付
                dv.Sort = InventoryPrepareAcs.ctInventoryPreprDate + " DESC, " + InventoryPrepareAcs.ctInventoryPreprTime + " DESC ";

                for (int ix = 0; ix < dv.Count; ix++)
                {
                    if ((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryProcDiv_Hidden] == 3) continue;
                    if ((dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate] != null) &&
                        ((string)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate].ToString().Trim() != string.Empty))
                    {
                        this.tDateEdit_InventoryDay.SetLongDate((int)dv.Table.Rows[ix][InventoryPrepareAcs.ctInventoryDate_Int]);
                        break;
                    }
                }
            }
            // 2008.02.26 追加 <<<<<<<<<<<<<<<<<<<<
            // --- ADD 2009/12/03 ----------<<<<<
        }

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 売上データグリッドセルアクティブ後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
		{
			//
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// 売上データグリッドエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_Enter(object sender, EventArgs e)
		{
			UltraGridRow row = this.uGrid_Result.ActiveRow;

			//if (row != null)
			{
				if (this.uGrid_Result.Rows.Count > 0)
				{
					this.uGrid_Result.Selected.Rows.Clear();
					this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
					this.uGrid_Result.ActiveRow.Selected = true;
				}
			}
        }

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 売上データグリッドリーブイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_Leave(object sender, EventArgs e)
		{
			this.uStatusBar_Main.Text = "";
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// フォーム終了前イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/01/11 高峰</br>
        /// <br>             棚卸障害対応</br>
		private void MAHNB04110UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// 列表示状態クラスリストをXMLにシリアライズする
			//ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);		// 仮

            // グリッド設定保存
            this.SaveGridState(); // ADD 2011/01/11
		}

        // ---------- ADD 2011/01/11 ---------->>>>>
        /// <summary>
        /// グリッド設定保存
        /// </summary>
        public void SaveGridState()
        {
            // グリッド設定保存
            if (this._gridStateController != null)
            {
                this._gridStateController.GetGridStateFromGrid(ref this.uGrid_Result);
                this._gridStateController.SaveGridState(ctFILENAME_COLDISPLAYSTATUS);
            }
        }
        // ---------- ADD 2011/01/11 ----------<<<<<

		/// <summary>
		/// 売上データグリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				{
					if (this.uGrid_Result.ActiveRow != null)
					{
						if (this.uGrid_Result.ActiveRow.Index == 0)
						{
							this.tDateEdit_InventoryDay.Focus();
						}
					}

					break;
				}
			}
		}

		/// <summary>
		/// グリッドソート変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_AfterSortChange(object sender, BandEventArgs e)
		{
			this.NumberingRowNo();
			this.SettingGridRow();
		}

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// グリッドマウスエンターエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(UltraGridCell));

			if (oContextCell != null)
			{
			}
        }
        
		/// <summary>
		/// グリッドマウスリーヴエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Result_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// 表示区分オプションセット選択値変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/12/03 田建委</br>
        /// <br>             過不足更新ボタンの制御変更</br>
        /// <br>Update Note: K2015/08/21 陳嘯 棚卸過不足更新　メモリアウトの修正</br>
        /// <br>             Redmine#46790の対応</br>
        private void ultraOptionSet_DifCntExtraDiv_ValueChanged(object sender, EventArgs e)
        {
            //this.ultraOptionSet_DifCntExtraDiv.ValueChanged -= new System.EventHandler(this.ultraOptionSet_DifCntExtraDiv_ValueChanged);

            // ---------- UPD 2010/12/03 ------------------------>>>>>
            //if (this._inventoryUpdateAcs.GetRowCount() == 0) return;
            if (this._inventoryUpdateAcs.GetRowCount() == 0)
            {
               // this._saveButton.SharedProps.Enabled = false;// DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
                this._saveButton.SharedProps.Enabled = true; // ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
                return;
            }
            else 
            {
                this._saveButton.SharedProps.Enabled = true;
            }
            // ---------- UPD 2010/12/03 ------------------------<<<<<

			int difCntExtraDiv = Convert.ToInt32(this.ultraOptionSet_DifCntExtraDiv.Value);
			this._inventoryUpdateAcs.Filtering(difCntExtraDiv);
			this.NumberingRowNo();

			if ((difCntExtraDiv == 1) && (this._inventoryUpdateAcs.GetViewRowCount() == 0))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"過不足が発生している棚卸データは存在しません。",
					0,
					MessageBoxButtons.OK);
			}

			//this.ultraOptionSet_DifCntExtraDiv.ValueChanged -= new System.EventHandler(this.ultraOptionSet_DifCntExtraDiv_ValueChanged);
		}

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
		# endregion

        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
        #region ガイドボタンクリックイベント

        #region 倉庫ガイド
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.20</br>
        /// </remarks>    
        private void WarehouseGuideButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouseData = null;

                // --- CHG 2008/09/10 --------------------------------------------------------------------->>>>>
                //if (this._warehouseGuide == null)
                //{
                //    this._warehouseGuide = new WarehouseAcs();
                //}

                //int status = this._warehouseGuide.ExecuteGuid(out warehouseData, this._enterpriseCode, this.tComboEditor_SectionCode.Value.ToString());
                int status = this._warehouseGuide.ExecuteGuid(out warehouseData, this._enterpriseCode);
                // --- CHG 2008/09/10 ---------------------------------------------------------------------<<<<<

                if (status == 0)
                {
                    if (warehouseData != null)
                    {
                        //開始、終了どちらのボタンが押されたか？
                        if ((UltraButton)sender == this.WarehouseGuideSt_Button)
                        {
                            //開始
                            this.tEdit_WarehouseCode_St.DataText = warehouseData.WarehouseCode.TrimEnd();
                            this.tEdit_WarehouseCode_Ed.Focus();
                        }
                        else
                        {
                            //終了
                            this.tEdit_WarehouseCode_Ed.DataText = warehouseData.WarehouseCode.TrimEnd();
                            this.tEdit_WarehouseShelfNo_St.Focus();
                        }
                    }
                }
                else
                {
                    //キャンセルなのでなにもしない
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        #region 拠点ガイド
        /// <summary>
        /// Button_Click イベント(拠点ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            // ---DEL 2009/05/22 不具合対応[13263] ---------------------------------------------->>>>>
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    SecInfoSet secInfoSet;

            //    int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            //    if (status == 0)
            //    {
            //        // 拠点コード設定
            //        this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
            //        // 拠点名称設定
            //        this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

            //        // フォーカス設定
            //        this.tDateEdit_InventoryDay.Focus();
            //    }
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            // ---DEL 2009/05/22 不具合対応[13263] ----------------------------------------------<<<<<
        }

        #endregion 拠点ガイド

        #endregion 
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2011/01/11 高峰</br>
        /// <br>    
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ---DEL 2009/05/22 不具合対応[13263] --------------------------------------------->>>>>
                //case "tEdit_SectionCode":
                //    if (this.tEdit_SectionCode.DataText.Trim() == "")
                //    {
                //        this.tEdit_SectionName.Clear();
                //        return;
                //    }

                //    string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                //    // 拠点名称設定
                //    this.tEdit_SectionName.DataText = this._inventoryUpdateAcs.GetSectionName(sectionCode);

                //    if (e.ShiftKey == false)
                //    {
                //        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                //        {
                //            // フォーカス設定
                //            if (this.tEdit_SectionName.DataText.Trim() != "")
                //            {
                //                e.NextCtrl = this.tDateEdit_InventoryDay;
                //            }
                //        }
                //    }
                //    break;
                // ---DEL 2009/05/22 不具合対応[13263] --------------------------------------------->>>>>
                case "tEdit_WarehouseCode_St":
                    // 倉庫コード取得
                    string warehouseCodeSt = this.tEdit_WarehouseCode_St.DataText.Trim();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // フォーカス設定
                            //if (warehouseCodeSt != "")
                            //{
                            //    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                            //}
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                    }
                    break;
                case "tEdit_WarehouseCode_Ed":
                    // 倉庫コード取得
                    string warehouseCodeEd = this.tEdit_WarehouseCode_Ed.DataText.Trim();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // フォーカス設定
                            //if (warehouseCodeEd != "")
                            //{
                            //    e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                            //}
                            e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            e.NextCtrl = tEdit_WarehouseCode_St;
                        }
                    }
                    break;
                case "tEdit_WarehouseShelfNo_St":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = tEdit_WarehouseCode_Ed;
                            }
                        }
                        break;
                    }
                case "uGrid_Result":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.uGrid_Result.ActiveRow == null)
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;          //DEL 2009/05/22 不具合対応[13263]
                                    //e.NextCtrl = this.tDateEdit_InventoryDay;       //ADD 2009/05/22 不具合対応[13263] //DEL 2011/01/11
                                    e.NextCtrl = this.ckdDepositAutoColumnSize; //ADD 2011/01/11
                                    return;
                                }

                                int rowIndex = this.uGrid_Result.ActiveRow.Index;

                                if (rowIndex == this.uGrid_Result.Rows.Count - 1)
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;          //DEL 2009/05/22 不具合対応[13263]
                                    //e.NextCtrl = this.tDateEdit_InventoryDay;       //ADD 2009/05/22 不具合対応[13263] //DEL 2011/01/11
                                    e.NextCtrl = this.ckdDepositAutoColumnSize; //ADD 2011/01/11
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Result.Rows[rowIndex].Selected = false;
                                    this.uGrid_Result.Rows[rowIndex + 1].Activate();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Result.ActiveRow == null)
                                {
                                    e.NextCtrl = this.ultraOptionSet_ShelfNoDiv;
                                    return;
                                }

                                int rowIndex = this.uGrid_Result.ActiveRow.Index;

                                if (rowIndex == 0)
                                {
                                    e.NextCtrl = this.ultraOptionSet_ShelfNoDiv;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Result.Rows[rowIndex].Selected = false;
                                    this.uGrid_Result.Rows[rowIndex - 1].Activate();
                                    return;
                                }
                            }
                        }
                        break;
                    }
                // ---------- ADD 2011/01/11 ---------->>>>>
                case "ckdDepositAutoColumnSize":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.uGrid_Result;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.FontSize_tComboEditor;
                            }
                        }
                        break;
                    }
                case "FontSize_tComboEditor":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.ckdDepositAutoColumnSize;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                e.NextCtrl = this.tDateEdit_InventoryDay;
                            }
                        }
                        break;
                    }
                case "tDateEdit_InventoryDay":
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = ultraOptionSet_DifCntExtraDiv;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab || (e.Key == Keys.Enter))
                        {
                            e.NextCtrl = FontSize_tComboEditor;
                        }
                    }
                    break;
                case "ultraOptionSet_ShelfNoDiv":
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.uGrid_Result.Rows.Count == 0)
                            {
                                e.NextCtrl = ckdDepositAutoColumnSize;
                            }
                            else
                            {
                                e.NextCtrl = this.uGrid_Result;
                            }
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            e.NextCtrl = tEdit_WarehouseShelfNo_Ed;
                        }
                    }
                    break;
                // ---------- ADD 2011/01/11 ----------<<<<<
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "uGrid_Result":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (uGrid_Result.Rows.Count == 0)
                                {
                                    //e.NextCtrl = this.tEdit_SectionCode;          //DEL 2009/05/22 不具合対応[13263]
                                    e.NextCtrl = this.tDateEdit_InventoryDay;       //ADD 2009/05/22 不具合対応[13263]
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (uGrid_Result.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.ultraOptionSet_ShelfNoDiv;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        private void uGrid_Result_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveRow == null)
            {
                return;
            }

            this.uGrid_Result.Rows[this.uGrid_Result.ActiveRow.Index].Selected = false;
            this.uGrid_Result.ActiveRow = null;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // ---------- ADD 2011/01/11 ---------->>>>>
        /// <summary>
        /// CheckedChangedイベント(ckdDepositAutoColumnSize)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">KeyPressイベントに使用されるイベントパラメータ</param>
        private void ckdDepositAutoColumnSize_CheckedChanged(object sender, EventArgs e)
        {
            // グリッド列サイズ変更スレッドスタート
            Thread depositGridColumnSizeChangeThread = new Thread(new ParameterizedThreadStart(DepositGridColumnSizeChange));
            depositGridColumnSizeChangeThread.Start((object)this.ckdDepositAutoColumnSize.Checked);
        }

        #region グリッド表示列サイズ変更処理
        /// <summary>
        /// グリッド表示列サイズ変更処理
        /// </summary>
        private void DepositGridColumnSizeChange(object parameter)
        {
            bool check = (bool)parameter;

            // グリッド列幅のオート設定
            if (check == true)
            {
                this.uGrid_Result.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                return;
            }
            else
            {
                this.uGrid_Result.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }

            // 列幅の調整
            try
            {
                this.uGrid_Result.BeginUpdate();

                for (int i = 0; i < this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(PerformAutoSizeType.VisibleRows, true);
                }
            }
            finally
            {
                this.uGrid_Result.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region ValueChangedイベント(FontSize_tComboEditor)
        /// <summary>
        /// FontSize_tComboEditor.ValueChangedイベント(FontSize_tComboEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">ValueChangedイベントに使用されるイベントパラメータ</param>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 文字サイズを変更
            this.uGrid_Result.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.FontSize_tComboEditor.SelectedItem.DataValue;
        }

        #region InitializeRowイベント(PrepareHistory_Grid)

        /// <summary>
        /// InitializeRowイベント(uGrid_Result)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">KeyPressイベントに使用されるイベントパラメータ</param>
        private void UGrid_Result_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            //グリッドの１行高さ
            e.Row.Height = 10;
            e.Row.Appearance.BackGradientStyle = GradientStyle.Vertical;

            e.Row.Activation = Activation.NoEdit;
            e.Row.Appearance.Cursor = Cursors.Arrow;
        }
        #endregion

        #region グリッド描画設定
        /// <summary>
        /// グリッド描画設定
        /// </summary>
        private void ResultGridDisp()
        {
            // この処理は、グリッドにデータをバインドしてプロパティの設定を全て終えた後に行う。
            // グリッドの設定をする前にこの処理を行うと設定が無効化される。
            // グリッド設定情報取得
            GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Result);

            if (gridStateInfo != null)
            {
                // グリッド設定
                this._gridStateController.SetGridStateToGrid(ref this.uGrid_Result);
                this.FontSize_tComboEditor.Value = (int)gridStateInfo.FontSize;
                this.ckdDepositAutoColumnSize.Checked = gridStateInfo.AutoFit;
            }
            else
            {
                this.FontSize_tComboEditor.Value = 11;
                this.ckdDepositAutoColumnSize.Checked = false;
            }
        }
        #endregion

        // ---------- ADD 2011/01/11 ----------<<<<<

        #endregion
    }
}