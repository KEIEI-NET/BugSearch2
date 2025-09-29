//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸入力商品編集UI画面クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村　仁
// 作 成 日  2007/04/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/14  修正内容 : 棚卸実施日対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/01  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応13109
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 修 正 日  2009/10/08  修正内容 : MANTIS[0014384]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/03  修正内容 : PM.NS　保守対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/01/11  修正内容 : 商品マスタに存在しないデータも新規登録出来る不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/01/30  修正内容 : 障害報告 #18764
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/02/10  修正内容 : 障害報告 #18869
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2012/06/11  修正内容 : 2012/07/25配信分、Redmine#30238の対応。
//----------------------------------------------------------------------------//
// 管理番号  1002677-00  作成担当 : xuyb
// 修 正 日  2014/10/31  修正内容 : 仕掛№2133 Redmine#40336
//                                  障害現象②原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinToolbars;
using System.Collections;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 棚卸入力商品編集UI画面クラス
    /// </summary>
    /// <remarks>
    /// <br>Programer  : 23010 中村　仁</br>
    /// <br>Note       : 商品の新規追加、編集を行うクラスです</br>
    /// <br>Date       : 2007/04/18</br>
    /// <br>Update Note: 2008.02.14 980035 金沢 貞義</br>
    /// <br>			 ・棚卸実施日対応（DC.NS対応）</br>
    /// <br>Update Note: 2008/09/01 30414 忍 幸史</br>
    /// <br>			 ・Partsman用に変更</br>
    /// <br>Update Note: 2009/04/13 30452 上野 俊治</br>
    /// <br>			    ・障害対応13109</br>
    /// <br>           : 2009/05/14       照田 貴志　不具合対応[13260]</br>
    /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>             新規入力時の項目取得方法を変更する</br>
    /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
    /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
    /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
    /// <br>             障害報告 #18764</br>
    /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
    /// <br>             障害報告 #18869</br>
    /// <br>UpdateNote : 2014/10/31 xuyb</br>
    /// <br>             Redmine#40336 障害現象②原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる</br>
    /// </remarks>
    public partial class MAZAI05130UD : Form
    {
        #region Constructor
        /// <summary>
        /// 棚卸入力商品編集画面クラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Programer	: 23010 中村　仁</br>
        /// <br>Note		: 棚卸入力商品編集画面クラスのインスタンスを初期化します</br>
        /// <br>Date		: 2007/04/18</br>
        /// <br>UpdateNote	: 2007.07.25 22013 kubo</br>
        /// <br>			:	・編集モード追加</br>
        /// <br>UpdateNote	: 2007.07.31 22013 kubo</br>
        /// <br>			:	・初期化タイミングを変更。</br>
		/// <br>			:	  Load後のTimer_Tickイベントでは2回目以降に起動した時に</br>
		/// <br>			:	  前回内容が一瞬表示されるのでLoad前に初期化を行うよう変更</br>
        /// <br>UpdateNote :  2011/01/11 鄧潘ハン</br>
        /// <br>              商品マスタに存在しないデータも新規登録出来る不具合修正</br>
        /// </remarks>
        public MAZAI05130UD()
        {
            InitializeComponent();
            //変数をインスタンス化
            //棚卸数入力データパラメータクラス
            this._inventoryDataUpdateWorkBefore = new InventoryDataUpdateWork();
            this._inventoryDataUpdateWorkAfter  = new InventoryDataUpdateWork();
            
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            //商品ガイド
            this._goodsGuide = new MAKHN04110UA();

            //得意先情報アクセスクラス
            this._customerInfoAcs = new CustomerInfoAcs();
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            //倉庫アクセスクラス
            this._warehouseGuideAcs = new WarehouseAcs();

            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            this._goodsAcs = new GoodsAcs();
            string errMsg;
            this._goodsAcs.IsGetSupplier = true;        //ADD 2009/05/14 不具合対応[13260]      ※仕入情報検索の高速化
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out errMsg);

            this._inventInputAcs = new InventInputAcs();

            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>            
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者アクセスクラス
            //this._carrierEpAcs = new CarrierEpAcs();
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //倉庫コード参照用フラグ
            this._changFlagWarehouse = false;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者コード参照用フラグ
            //this._changeFlagCarrierEp = false;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //品番参照用フラグ
            this._changFlagGoods = false;

            //得意先(仕入先)コード参照フラグ
            this._changFlagCustomer = false;
            //出荷先得意先(委託先)コード参照フラグ
            this._changFlagShipCustomer = false;
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        }
        #endregion

        #region Const

        //起動モード
        private const string ctNEW_MODE = "新規";
        private const string ctEDIT_MODE = "更新";
        private const string ctREADONLY_MODE = "参照";
        //クラス名
        private string CT_CLASSID = "MAZAI05130UDA";

        #endregion

        #region PrivateMember

        //企業コード
        private string _enterpriseCode;
        //拠点コード
        private string _loginSectionCode;
        //起動モード
        private int _dispMode;

        //棚卸数入力データパラメータクラス
        private InventoryDataUpdateWork _inventoryDataUpdateWorkBefore;
        private InventoryDataUpdateWork _inventoryDataUpdateWorkAfter;

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        //商品ガイド
        private MAKHN04110UA _goodsGuide;
        //得意先情報アクセスクラス
        private CustomerInfoAcs _customerInfoAcs;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

        //倉庫アクセスクラス
        private WarehouseAcs _warehouseGuideAcs;

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        private GoodsAcs _goodsAcs;
        private InventInputAcs _inventInputAcs;

        private List<InventoryDataUpdateWork> _inventoryDataUpdateWorkList;
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //// 事業者アクセスクラス
        //private CarrierEpAcs _carrierEpAcs = null;
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        //倉庫コード参照用フラグ
        private bool _changFlagWarehouse;
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ////事業者コード参照用フラグ
        //private bool _changeFlagCarrierEp;
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        //品番参照用フラグ
        private bool _changFlagGoods;

        //得意先(仕入先)コード参照フラグ
        private bool _changFlagCustomer;
        //出荷先得意先(委託先)コード参照フラグ
        private bool _changFlagShipCustomer;
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        
        // 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 2007.07.25 kubo add --------------------------->
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //// 製番管理区分　0：管理しない　1:管理する
		//private int _prdNumMngDiv = 0;
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        // グロス区分 -1:関係なし(新規時), 0:製番毎, 1:商品毎
		private int _grossDiv = -1;
		// 2007.07.25 kubo add --------------------------->

        // ---ADD 2009/05/14 不具合対応[13260] ------------------------------->>>>>
        private string beforeWarehouseCode = " ";   //前回入力倉庫
        private string beforeGoodsNo = " ";         //前回入力品番
        // ---ADD 2009/05/14 不具合対応[13260] -------------------------------<<<<<

        private int GoodsNoFlag = 0;  // ADD 2011/01/11

        private double ListPrice = 0; // ADD 2011/01/30
        #endregion

        #region ◆ Public Property
		/// <summary> 企業コードプロパティ </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> 拠点コードプロパティ </summary>
		public string SectionCode
		{
			set { this._loginSectionCode = value; }
		}
		#endregion

        #region ◆ PublicEnum
		/// <summary>
		/// 表示モード
		/// </summary>
		public enum DispModeState
		{
			/// <summary> 新規作成 </summary>
			CreateNew = 0, 
			/// <summary> 新規編集 </summary>
			EditNew = 1,
			/// <summary> 既存編集 </summary>
			EditOld = 2
		}
		#endregion

        #region PublicMethod

        /// <summary>
        /// 画面起動処理
        /// </summary>
		/// <param name="work">結果リスト</param>
		/// <param name="mode">起動モード</param>
        /// <remarks>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Note       : 引数を元に画面の起動を行います</br>
        /// <br>Date       : 2007/04/18</br>
        /// </remarks>
        public DialogResult ShowEditor(ref InventoryDataUpdateWork work,int mode)
        {
            //棚卸検索結果クラス
            this._inventoryDataUpdateWorkBefore = work;
            //起動モード
            this._dispMode = mode;      
			// 2007.07.25 kubo add
			// グロス区分
			this._grossDiv = -1;

			// 2007.07.31 kubo add ----------->
            // 画面初期設定処理
			ScreenInitialSetting();
			// 2007.07.31 kubo add <-----------

            DialogResult ret = this.ShowDialog();

			if ( ret == DialogResult.OK )
			{
				work = this._inventoryDataUpdateWorkAfter;
			}

            return ret;
        }
       
         /// <summary>
        /// 画面起動処理
        /// </summary>
		/// <param name="work">結果リスト</param>
		/// <param name="mode">起動モード</param>
		/// <param name="grossDiv">グロス区分</param>
        /// <remarks>
        /// <br>Note       : 引数を元に画面の起動を行います</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks>
        public DialogResult ShowEditor(ref InventoryDataUpdateWork work, int mode, int grossDiv)
        {
            //棚卸検索結果クラス
            this._inventoryDataUpdateWorkBefore = work;
            //起動モード
            this._dispMode = mode;          
			// 2007.07.25 kubo add
			// グロス区分
			this._grossDiv = grossDiv;

            // 画面初期設定処理
			ScreenInitialSetting();

            DialogResult ret = this.ShowDialog();

			if ( ret == DialogResult.OK )
			{
				work = this._inventoryDataUpdateWorkAfter;
			}

            return ret;
        }
        #endregion

        #region PrivateMethod

        #region 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        private void ClearScreen()
        {
            // 倉庫
            this.tEdit_WarehouseCode.Clear();
            this.tEdit_WarehouseName.Clear();
            // 品番
            this.tEdit_GoodsNo.Clear();
            // 商品関連情報
            ClearGoodsInfo();
            // 棚卸数
            this.tNedit_InventoryStockCnt.Clear();
            // 原単価
            this.tNedit_StockUnitPrice.Clear();
            // 棚番
            this.tEdit_WarehouseShelfNo.Clear();
            // 重複棚番1
            this.tEdit_DuplicationShelfNo1.Clear();
            // 重複棚番2
            this.tEdit_DuplicationShelfNo2.Clear();
            // 棚卸実施日
            this.EnforcementDay_tDateEdit.SetDateTime(new DateTime());
            // 棚卸日
            this.InventoryDay_tDateEdit.SetDateTime(new DateTime());

            //-------------------------------------------
            // 非表示項目
            //-------------------------------------------
            // JANコード
            this.tEdit_Jan.Clear();
            // 自社分類コード
            this.tNedit_EnterpriseGanreCode.Clear();
            // 変更前原単価
            this.BfStockUnitPrice_tNedit.Clear();

            // ---ADD 2009/05/14 不具合対応[13260] --------------------->>>>>
            //調整用計算原価
            this.tNedit_AdjustCalcCost.Clear();
            //在庫区分
            this.tNedit_StockDiv.Clear();
            //最終仕入年月日
            this.LastStockDate_tDateEdit.Clear();
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------<<<<<
        }
        #endregion 画面初期化処理

        #region 画面初期設定処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定処理を行います</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // コントロールサイズ設定
            this.tEdit_WarehouseCode.Size = new Size(60, 24);
            this.tEdit_WarehouseName.Size = new Size(290, 24);
            this.tEdit_GoodsNo.Size = new Size(385, 24);
            this.tEdit_GoodsName.Size = new Size(385, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(60, 24);
            this.tEdit_MakerName.Size = new Size(209, 122);
            this.tEdit_SectionCode.Size = new Size(60, 24);
            this.tEdit_SectionName.Size = new Size(209, 122);
            this.tNedit_SupplierCd.Size = new Size(60, 24);
            this.tEdit_SupplierName.Size = new Size(209, 122);
            this.tNedit_GoodsLGroup.Size = new Size(60, 24);
            this.tEdit_GoodsLGroupName.Size = new Size(209, 122);
            this.tNedit_GoodsMGroup.Size = new Size(60, 24);
            this.tEdit_GoodsMGroupName.Size = new Size(209, 122);
            this.tNedit_BLGloupCode.Size = new Size(60, 24);
            this.tEdit_BLGroupName.Size = new Size(209, 122);
            this.tNedit_BLGoodsCode.Size = new Size(60, 24);
            this.tEdit_BLGoodsName.Size = new Size(209, 122);
            this.tNedit_InventoryStockCnt.Size = new Size(115, 24);
            this.tNedit_StockUnitPrice.Size = new Size(115, 24);
            this.tEdit_WarehouseShelfNo.Size = new Size(74, 24);
            this.tEdit_DuplicationShelfNo1.Size = new Size(74, 24);
            this.tEdit_DuplicationShelfNo2.Size = new Size(74, 24);

            // イメージリストを設定する
            ImageList imageList16 = IconResourceManagement.ImageList16;
			this.Main_ToolbarsManager.ImageListSmall = imageList16;          

			// 終了のアイコン設定
			ButtonTool closeButton = (ButtonTool)Main_ToolbarsManager.Tools["ctCLOSE_BUTTONTOOLKEY"];
            if (closeButton != null)
            {
                closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            }
			// 保存のアイコン設定
            ButtonTool saveButton = (ButtonTool)Main_ToolbarsManager.Tools["ctSAVE_BUTTONTOOLKEY"];
            if (saveButton != null)
            {
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            }

            // 倉庫ガイド
            this.WarehouseGuide_Button.ImageList = imageList16;
            this.WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // 画面初期化
            ClearScreen();

            // 日付バックカラー設定
            this.InventoryDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;
            this.EnforcementDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;

            // 画面に初期データを展開
            SetScreenFromInventoryDataUpdateWork(this._inventoryDataUpdateWorkBefore);

            this._inventInputAcs.SearchAll(out _inventoryDataUpdateWorkList, this._enterpriseCode, this._inventoryDataUpdateWorkBefore.InventoryDate);
            
            // 起動モードによって処理を行う
            switch(this._dispMode)
            {
                // 新規
                case (int)DispModeState.CreateNew:
                {
                    // 棚卸実施日
                    this.EnforcementDay_tDateEdit.SetDateTime(this._inventoryDataUpdateWorkBefore.InventoryDay);

                    // 棚卸日
                    this.InventoryDay_tDateEdit.SetDateTime(this._inventoryDataUpdateWorkBefore.InventoryDate);

                    this.Mode_Title.Text = ctNEW_MODE;
                    break;
                }
                // 新規分編集
                case (int)DispModeState.EditNew:
                {
                    this.Mode_Title.Text = ctEDIT_MODE;
                    break;
                }
                // 編集
                case (int)DispModeState.EditOld:
                {
                    // 保留
                    this.Mode_Title.Text = ctREADONLY_MODE;
                    
                    // 画面をReadOnly状態にする
                    ScreenSettingReadOnly(false);
                    break;
                }
            }

            this.beforeWarehouseCode = " ";         //ADD 2009/05/14 不具合対応[13260]
            this.beforeGoodsNo = " ";               //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Note       : 画面の初期設定処理を行います</br>
        /// <br>Date       : 2007/04/18</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // イメージリストを設定する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Main_ToolbarsManager.ImageListSmall = imageList16;

            // 終了のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["ctCLOSE_BUTTONTOOLKEY"];
            if (closeButton != null)
                closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // 保存のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["ctSAVE_BUTTONTOOLKEY"];
            if (saveButton != null)
                saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

            //倉庫ガイド
            this.WarehouseGuide_Button.ImageList = imageList16;
            this.WarehouseGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者ガイド
            //this.CarrierEpGuide_Button.ImageList = imageList16;         
            //this.CarrierEpGuide_Button.Appearance.Image = Size16_Index.STAR1;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //得意先(仕入先)ガイド
            this.CustomerGuide_Button.ImageList = imageList16;
            this.CustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //出荷先得意先(委託先)ガイド
            this.ShipCustomerGuide_Button.ImageList = imageList16;
            this.ShipCustomerGuide_Button.Appearance.Image = Size16_Index.STAR1;
            //商品ガイド
            this.GoodsGuide_Button.ImageList = imageList16;
            this.GoodsGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            //日付バックカラー設定
            this.InventoryDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;
            this.EnforcementDay_tDateEdit.BackColor = this.ultraGroupBox2.BackColor;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<


            //画面の入力制御
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////製番管理区分が無しの場合は製番、携帯番号を入力できないようにする
            //if(this._inventoryDataUpdateWorkBefore.PrdNumMngDiv == 0)
            //{
            //    //製造番号情報クリア処理
            //    ProductNumberClear();
            //    ScreeParmitionControl(false);
            //
            //	if ( this._grossDiv == (int)InventInputSearchCndtn.GrossDivState.Goods )
            //		this.tNedit_InventoryStockCnt.Enabled = false;
            //
            //}
            //else
            //{
            //    ScreeParmitionControl(true);
            //
            //	if ( this._grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product )
            //	{
            //		if ( this._inventoryDataUpdateWorkBefore.ProductNumber == "" && 
            //			this._inventoryDataUpdateWorkBefore.StockTelNo1 == "" && 
            //			this._inventoryDataUpdateWorkBefore.StockTelNo2 == "" )
            //		{
            //			this.tNedit_InventoryStockCnt.Enabled = true;
            //		}
            //		else
            //		{
            //			this.tNedit_InventoryStockCnt.Enabled = false;
            //		}
            //
            //	}
            //	else
            //	{
            //		if ( this._dispMode == (int)DispModeState.EditNew )
            //			this.tNedit_InventoryStockCnt.Enabled = false;
            //		else
            //			this.tNedit_InventoryStockCnt.Enabled = true;
            //
            //		this.ProductNumber_tEdit.Enabled = false;
            //		this.StockTelNo1_tEdit.Enabled = false;
            //		this.StockTelNo2_tEdit.Enabled = false;
            //	}
            //}
            //
            //// 2007.07.25 kubo add
            //this._prdNumMngDiv = this._inventoryDataUpdateWorkBefore.PrdNumMngDiv;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //画面に初期データを展開
            SetScreenFromInventoryDataUpdateWork(this._inventoryDataUpdateWorkBefore);

            //起動モードによって処理を行う
            switch (this._dispMode)
            {
                //新規
                case (int)DispModeState.CreateNew:
                    {
                        //新規の場合、仕入日、出荷日、棚卸実施日に現在の日付をセット
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////仕入日
                        //this.StockDate_tDateEdit.SetDateTime(DateTime.Now);
                        ////入荷日
                        //this.ArrivalGoodsDay_tDateEdit.SetDateTime(DateTime.Now);
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        ////棚卸日
                        //this.InventoryDay_tDateEdit.SetDateTime(DateTime.Now);
                        //棚卸実施日
                        this.EnforcementDay_tDateEdit.SetDateTime(DateTime.Now);

                        //棚卸日
                        this.InventoryDay_tDateEdit.SetDateTime(this._inventoryDataUpdateWorkBefore.InventoryDay);
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

                        this.Mode_Title.Text = ctNEW_MODE;
                        break;
                    }
                //新規分編集
                case (int)DispModeState.EditNew:
                    {
                        this.Mode_Title.Text = ctEDIT_MODE;
                        break;
                    }
                //編集
                case (int)DispModeState.EditOld:
                    {
                        //保留
                        this.Mode_Title.Text = ctREADONLY_MODE;
                        //画面をReadOnly状態にする
                        ScreenSettingReadOnly(false);
                        break;
                    }
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region 参照モード画面設定処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 参照モード画面設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 参照モード用の画面設定処理を行います</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void ScreenSettingReadOnly(bool para)
        {
            //倉庫
            this.tEdit_WarehouseCode.Enabled = para;
            this.WarehouseGuide_Button.Enabled = para;
            //商品
            this.tEdit_GoodsNo.Enabled = para;
            //仕入先
            this.tNedit_SupplierCd.Enabled = para;
            //原単価
            this.tNedit_StockUnitPrice.Enabled = para;
            //棚卸数
            this.tNedit_InventoryStockCnt.Enabled = para;
            //棚番
            this.tEdit_WarehouseShelfNo.Enabled = para;
            //重複棚番１
            this.tEdit_DuplicationShelfNo1.Enabled = para;
            //重複棚番２
            this.tEdit_DuplicationShelfNo2.Enabled = para;
            //棚卸実施日
            this.InventoryDay_tDateEdit.Enabled = para;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 参照モード画面設定処理
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Note       : 参照モード用の画面設定処理を行います</br>
        /// <br>Date       : 2007/04/24</br>
        /// </remarks>
        private void ScreenSettingReadOnly(bool para)
        {
            //倉庫
            this.tEdit_WarehouseCode.Enabled = para;
            this.WarehouseGuide_Button.Enabled = para;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者
            //this.CarrierCode_tNedit.Enabled = para;
            //this.CarrierEpGuide_Button.Enabled = para;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //商品
            this.tEdit_GoodsNo.Enabled = para;
            this.GoodsGuide_Button.Enabled = para;
            //仕入先
            this.tNedit_SupplierCd.Enabled = para;
            this.CustomerGuide_Button.Enabled = para;
            //委託先
            this.ShipCustomerCode_tNedit.Enabled = para;
            this.ShipCustomerGuide_Button.Enabled = para;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////在庫区分
            //this.StockExtraDiv_ultraOptionSet.Enabled = para;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //原単価
            this.tNedit_StockUnitPrice.Enabled = para;
            //棚卸数
            this.tNedit_InventoryStockCnt.Enabled = para;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////製番
            //this.ProductNumber_tEdit.Enabled = para;
            ////電話番号１
            //this.StockTelNo1_tEdit.Enabled = para;
            ////電話番号１
            //this.StockTelNo2_tEdit.Enabled = para;
            ////仕入日
            //this.StockDate_tDateEdit.Enabled = para;
            ////入荷日
            //this.ArrivalGoodsDay_tDateEdit.Enabled = para;
            //棚番
            this.tEdit_WarehouseShelfNo.Enabled = para;
            //重複棚番１
            this.tEdit_DuplicationShelfNo1.Enabled = para;
            //重複棚番２
            this.tEdit_DuplicationShelfNo2.Enabled = para;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //棚卸実施日
            this.InventoryDay_tDateEdit.Enabled = para;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region 初期データ画面展開処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初期データ画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面への初期データ展開を行います</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void SetScreenFromInventoryDataUpdateWork(InventoryDataUpdateWork work)
        {                                         
            // 倉庫コード
            this.tEdit_WarehouseCode.DataText = work.WarehouseCode.Trim();
            // 倉庫名称
            if (work.WarehouseCode.Trim() == "")
            {
                this.tEdit_WarehouseName.Clear();
            }
            else
            {
                this.tEdit_WarehouseName.DataText = this._inventInputAcs.GetWarehouseName(work.WarehouseCode);
            }
            // 品番
            this.tEdit_GoodsNo.DataText = work.GoodsNo.TrimEnd();
            // 品名
            if ((work.GoodsMakerCd == 0) || (work.GoodsNo.Trim() == ""))
            {
                this.tEdit_GoodsName.Clear();
            }
            else
            {
                this.tEdit_GoodsName.DataText = this._inventInputAcs.GetGoodsName(work.GoodsMakerCd, work.GoodsNo);
            }
            // メーカーコード
            this.tNedit_GoodsMakerCd.SetInt(work.GoodsMakerCd);
            // メーカー名称
            if (work.GoodsMakerCd == 0)
            {
                this.tEdit_MakerName.Clear();
            }
            else
            {
                this.tEdit_MakerName.DataText = this._inventInputAcs.GetMakerName(work.GoodsMakerCd);
            }
            // 管理拠点コード
            this.tEdit_SectionCode.DataText = work.SectionCode;
            // 管理拠点名称
            if (work.SectionCode.Trim() == "")
            {
                this.tEdit_SectionName.Clear();
            }
            else
            {
                this.tEdit_SectionName.DataText = this._inventInputAcs.GetSectionName(work.SectionCode);
            }
            // 商品大分類コード
            this.tNedit_GoodsLGroup.SetInt(work.GoodsLGroup);
            // 商品大分類名称
            if (work.GoodsLGroup == 0)
            {
                this.tEdit_GoodsLGroupName.Clear();
            }
            else
            {
                this.tEdit_GoodsLGroupName.DataText = this._inventInputAcs.GetGoodsLGroupName(work.GoodsLGroup);
            }
            // 商品中分類コード
            this.tNedit_GoodsMGroup.SetInt(work.GoodsMGroup);
            // 商品中分類名称
            if (work.GoodsMGroup == 0)
            {
                this.tEdit_GoodsMGroupName.Clear();
            }
            else
            {
                this.tEdit_GoodsMGroupName.DataText = this._inventInputAcs.GetGoodsMGroupName(work.GoodsMGroup);
            }
            // グループコードコード
            this.tNedit_BLGloupCode.SetInt(work.BLGroupCode);
            // グループコード名称
            if (work.BLGroupCode == 0)
            {
                this.tEdit_BLGroupName.Clear();
            }
            else
            {
                this.tEdit_BLGroupName.DataText = this._inventInputAcs.GetBLGroupName(work.BLGroupCode);
            }
            // BLコード
            this.tNedit_BLGoodsCode.SetInt(work.BLGoodsCode);
            // BLコード名称
            if (work.BLGoodsCode == 0)
            {
                this.tEdit_BLGoodsName.Clear();
            }
            else
            {
                this.tEdit_BLGoodsName.DataText = this._inventInputAcs.GetBLGoodsName(work.BLGoodsCode);
            }
            // 自社分類コード
            this.tNedit_EnterpriseGanreCode.SetInt(work.EnterpriseGanreCode);
            // 仕入先コード
            this.tNedit_SupplierCd.SetInt(work.SupplierCd);
            // 仕入先名称(表示用)
            // 仕入先名称1
            // 仕入先名称2
            if (work.SupplierCd == 0)
            {
                this.tEdit_SupplierName.Clear();
                this.tEdit_SupplierName1.Clear();
                this.tEdit_SupplierName2.Clear();
            }
            else
            {
                int status;
                string supplierName1;
                string supplierName2;
                status = this._inventInputAcs.GetSupplierName(work.SupplierCd, out supplierName1, out supplierName2);
                this.tEdit_SupplierName.DataText = supplierName1 + " " + supplierName2;
                this.tEdit_SupplierName1.DataText = supplierName1;
                this.tEdit_SupplierName2.DataText = supplierName2;
            }
            // 棚番
            this.tEdit_WarehouseShelfNo.DataText = work.WarehouseShelfNo.TrimEnd();
            // 重複棚番1
            this.tEdit_DuplicationShelfNo1.DataText = work.DuplicationShelfNo1.TrimEnd();
            // 重複棚番2
            this.tEdit_DuplicationShelfNo2.DataText = work.DuplicationShelfNo2.TrimEnd();
            // JANコード
            this.tEdit_Jan.DataText = work.Jan.TrimEnd();
            // 原単価
            this.tNedit_StockUnitPrice.SetValue((double)work.StockUnitPriceFl);
            // 変更前原単価
            this.BfStockUnitPrice_tNedit.SetValue((double)work.BfStockUnitPriceFl);
            // 棚卸在庫数
            this.tNedit_InventoryStockCnt.SetValue(work.InventoryStockCnt);
            // 棚卸日
            this.InventoryDay_tDateEdit.SetDateTime(work.InventoryDate);
            // 棚卸実施日
            this.EnforcementDay_tDateEdit.SetDateTime(work.InventoryDay);
            // 調整用計算原価
            this.tNedit_AdjustCalcCost.SetValue(work.AdjstCalcCost);        //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初期データ画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Note       : 画面への初期データ展開を行います</br>
        /// <br>Date       : 2007/04/19</br>
        /// </remarks>
        private void SetScreenFromInventoryDataUpdateWork(InventoryDataUpdateWork work)
        {
            //倉庫コード
            this.tEdit_WarehouseCode.DataText = work.WarehouseCode.TrimEnd();
            //倉庫名称
            this.tEdit_WarehouseName.DataText = work.WarehouseName.TrimEnd();
            //品番
            this.tEdit_GoodsNo.DataText = work.GoodsNo.TrimEnd();
            //品名
            this.tEdit_GoodsName.DataText = work.GoodsName.TrimEnd();
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////キャリアコード
            //this.CarrierCode_tNedit.SetInt(work.CarrierCode);
            ////キャリア名称
            //this.CarrierName_tEdit.DataText = work.CarrierName.TrimEnd();
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //メーカーコード
            this.MakerCode_tNedit.SetInt(work.GoodsMakerCd);
            //メーカー名称
            this.tEdit_MakerName.DataText = work.MakerName.TrimEnd();
            //商品大分類コード
            this.LgGoodsCode_tEdit.DataText = work.LargeGoodsGanreCode;
            //商品大分類名称
            this.LargeGoodsGanreName_tEdit.DataText = work.LargeGoodsGanreName.TrimEnd();
            //商品中分類コード
            this.MdGoodsCode_tEdit.DataText = work.MediumGoodsGanreCode;
            //商品中分類名称
            this.MediumGoodsGanreName_tEdit.DataText = work.MediumGoodsGanreName.TrimEnd();
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////機種コード
            //this.CellphonModelCode_tEdit.DataText = work.CellphoneModelCode.TrimEnd();
            ////機種名称
            //this.CellphonModelName_tEdit.DataText = work.CellphoneModelName.TrimEnd();
            ////系統色コード
            //this.SystematicColorCode_tNedit.SetInt(work.SystematicColorCd);
            ////系統色名称
            //this.SystematicColorName_tEdit.DataText = work.SystematicColorNm.TrimEnd();
            ////事業者コード
            //this.CarrierEpCode_tNedit.SetInt(work.CarrierEpCode);
            ////事業者名称
            //this.CarrierEpName_tEdit.DataText = work.CarrierEpName.TrimEnd();
            //グループコード
            this.DtGoodsGanreCode_tEdit.DataText = work.DetailGoodsGanreCode;
            //グループコード名称
            this.tEdit_BLGroupName.DataText = work.DetailGoodsGanreName.TrimEnd();
            //ＢＬ品番
            this.tNedit_BLGoodsCode.SetInt(work.BLGoodsCode);
            //ＢＬ品名
            //            this.tEdit_BLGoodsName.DataText = work.BLGoodsName.TrimEnd();
            //自社分類コード
            this.tNedit_EnterpriseGanreCode.SetInt(work.EnterpriseGanreCode);
            //自社分類名称
            this.EnterpriseGanreName_tEdit.DataText = work.EnterpriseGanreName.TrimEnd();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //得意先(仕入先)コード
            this.tNedit_SupplierCd.SetInt(work.CustomerCode);
            //得意先(仕入先)名称１
            this.tEdit_SupplierName.DataText = work.CustomerName.TrimEnd();
            //得意先(仕入先)名称２
            this.CustomerName2_tEdit.DataText = work.CustomerName2.TrimEnd();
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////仕入日
            //this.StockDate_tDateEdit.SetDateTime(work.StockDate);
            ////入荷日
            //this.ArrivalGoodsDay_tDateEdit.SetDateTime(work.ArrivalGoodsDay);
            ////製造番号
            //this.ProductNumber_tEdit.DataText = work.ProductNumber.TrimEnd();
            ////商品電話番号1
            //this.StockTelNo1_tEdit.DataText = work.StockTelNo1.TrimEnd();
            ////変更前電話番号1
            //this.BfStockTelNo1_tEdit.DataText = work.BfStockTelNo1.TrimEnd();
            ////商品電話番号2
            //this.StockTelNo2_tEdit.DataText = work.StockTelNo2.TrimEnd();
            ////変更前電話番号2
            //this.BfStockTelNo2_tEdit.DataText = work.BfStockTelNo2.TrimEnd();
            //棚番
            this.tEdit_WarehouseShelfNo.DataText = work.WarehouseShelfNo.TrimEnd();
            //重複棚番1
            this.tEdit_DuplicationShelfNo1.DataText = work.DuplicationShelfNo1.TrimEnd();
            //重複棚番2
            this.tEdit_DuplicationShelfNo2.DataText = work.DuplicationShelfNo2.TrimEnd();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //JANコード
            this.tEdit_Jan.DataText = work.Jan.TrimEnd();
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////仕入単価
            //this.tNedit_StockUnitPrice.SetValue((long)work.StockUnitPrice);
            ////変更前仕入単価
            //this.BfStockUnitPrice_tNedit.SetValue((long)work.BfStockUnitPrice);
            //仕入単価
            this.tNedit_StockUnitPrice.SetValue((double)work.StockUnitPriceFl);
            //変更前仕入単価
            this.BfStockUnitPrice_tNedit.SetValue((double)work.BfStockUnitPriceFl);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////在庫区分           
            //switch(work.StockDiv)
            //{
            //    //自社
            //    case 0:
            //    {
            //        //在庫状態
            //        switch(work.StockState)
            //        {
            //            //自社
            //            case 0:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 0;
            //                break;
            //            }
            //            //委託中
            //            case 20:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 2;
            //                break;
            //            }
            //        }
            //        break;
            //    }
            //    //受託
            //    case 1:
            //    {
            //         //在庫状態
            //        switch(work.StockState)
            //        {
            //            //自社
            //            case 0:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 1;
            //                break;
            //            }
            //            //委託中
            //            case 20:
            //            {
            //                this.StockExtraDiv_ultraOptionSet.CheckedIndex = 3;
            //                break;
            //            }
            //        }
            //        break;   
            //    }
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////製番管理区分
            //this.PrdNumMngDiv_tNedit.SetInt(work.PrdNumMngDiv);
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //出荷先得意先(委託先)コード
            this.ShipCustomerCode_tNedit.SetInt(work.ShipCustomerCode);
            //出荷先得意先(委託先)名称１
            this.ShipCustomerName1_tEdit.DataText = work.ShipCustomerName.TrimEnd();
            //出荷先得意先(委託先)名称２
            this.ShipCustomerName2_tEdit.DataText = work.ShipCustomerName2.TrimEnd();
            //棚卸在庫数
            this.tNedit_InventoryStockCnt.SetValue(work.InventoryStockCnt);
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            ////棚卸実施日
            //this.InventoryDay_tDateEdit.SetDateTime(work.InventoryDay);
            //棚卸日
            this.InventoryDay_tDateEdit.SetDateTime(work.InventoryDate);
            //棚卸実施日
            this.EnforcementDay_tDateEdit.SetDateTime(work.InventoryDay);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<


            // 2007.07.30 kubo del 
            // Enabled設定
            //if ( work.ProductNumber == "" )
            //    this.ProductNumber_tEdit.Enabled = true;
            //else
            //    this.ProductNumber_tEdit.Enabled = false;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region 得意先(仕入先)選択時発生イベント
        /// <summary>
		/// 得意先(仕入先)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        :得意先ガイドで得意先を選択した時に発生します</br>
        /// <br>Programmer  :23010 中村　仁</br>
        /// <br>Date        :2007.04.17</br>
        /// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustSuppli custSuppli;

            //選択された得意先の状態をチェック
			int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //TODO:必要か？？
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                        status,
                        MessageBoxButtons.OK);

                    //画面情報をクリア
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierName.Clear();
                    this.CustomerName2_tEdit.Clear();

                    return;
                }
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した仕入先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

                //画面情報をクリア
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                //画面情報をクリア
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}
         
            //得意先(仕入先)コードをセット          
            this.tNedit_SupplierCd.SetInt(customerSearchRet.CustomerCode);
            this.tEdit_SupplierName.DataText = customerSearchRet.Name.TrimEnd();
            this.CustomerName2_tEdit.DataText = customerSearchRet.Name2.TrimEnd();
		}
        #endregion

        #region 出荷先得意先(委託先)選択時発生イベント

        /// <summary>
		/// 出荷先得意先(委託先)選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        :得意先ガイドで出荷先得意先を選択した時に発生します</br>
        /// <br>Programmer  :23010 中村　仁</br>
        /// <br>Date        :2007.04.17</br>
        /// </remarks>
		private void CustomerSearchForm_ShipCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			
            //選択された得意先の状態をチェック
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{             
                //なにもしない             
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した得意先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

                //クリア
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                //クリア
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}

            //委託先              
            this.ShipCustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
            this.ShipCustomerName1_tEdit.DataText = customerSearchRet.Name.TrimEnd();
            this.ShipCustomerName2_tEdit.DataText = customerSearchRet.Name2.TrimEnd();
	          
		}
    
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region 商品データ画面展開処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品データ画面展開処理(画面←商品)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <remarks>
        /// <br>Note       : 商品ガイドから得た情報を画面に展開します</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             新規入力時の項目取得方法を変更する</br>
        /// <br>UpdateNote : 2012/06/11 凌小青</br>
        /// <br>             Redmine#30238</br>
        /// </remarks>       
        private void SetGoodsUnitForScreen(GoodsUnitData goodsUnitData)
        {
            string sectionCode = string.Empty;

            // --- ADD 2009/12/03 ---------->>>>>
            this.tNedit_StockUnitPrice.Clear();
            this.BfStockUnitPrice_tNedit.Clear();
            this.tNedit_StockTotal.Clear();
            // --- ADD 2009/12/03 ----------<<<<<

            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo.TrimEnd();                                      // 品番
            this.tEdit_GoodsName.DataText = goodsUnitData.GoodsName.TrimEnd();                                  // 品名
            this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);                                        // メーカーコード
            this.tEdit_MakerName.DataText = goodsUnitData.MakerName.TrimEnd();                                  // メーカー名称
            //this.tEdit_SectionCode.DataText = goodsUnitData.SectionCode.Trim();                                 // 管理拠点コード                     //DEL 2009/05/14 不具合対応[13260]
            //this.tEdit_SectionName.DataText = this._inventInputAcs.GetSectionName(goodsUnitData.SectionCode.Trim().PadLeft(2, '0')); // 管理拠点名称  //DEL 2009/05/14 不具合対応[13260]
            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------------------------------>>>>>
            //商品在庫情報から取得
             Stock stock = this.GetSectionCodeFromGoodsUnitData(goodsUnitData);
            if (stock == null)
            {
                //倉庫マスタから取得
                sectionCode = this.GetSectionCodeFromWarehouseInfo();               //拠点コード

                //初期値
                this.tNedit_StockDiv.SetInt(0);                                     //在庫区分
                this.LastStockDate_tDateEdit.SetDateTime(DateTime.MinValue);        //最終仕入年月日
            }
            else
            {
                //在庫マスタから取得
                sectionCode = stock.SectionCode;                                    //拠点コード
                this.tNedit_StockDiv.SetInt(stock.StockDiv);                        //在庫区分
                if (stock.LastStockDate != null)
                {
                    this.LastStockDate_tDateEdit.SetDateTime(stock.LastStockDate);  //最終仕入年月日
                }

                // --- ADD 2009/12/03 ---------->>>>>
                this.tEdit_WarehouseShelfNo.Text = stock.WarehouseShelfNo;
                this.tEdit_DuplicationShelfNo1.Text = stock.DuplicationShelfNo1;
                this.tEdit_DuplicationShelfNo2.Text = stock.DuplicationShelfNo2;
                this.tNedit_StockUnitPrice.SetValue(stock.StockUnitPriceFl);
                this.BfStockUnitPrice_tNedit.SetValue(stock.StockUnitPriceFl);
                this.tNedit_StockTotal.SetValue(this._inventInputAcs.GetStockTotal(stock,
                        this.InventoryDay_tDateEdit.GetDateTime())); // 在庫総数
                // --- ADD 2009/12/03 ----------<<<<<
            }

            this.tEdit_SectionCode.DataText = sectionCode;
            this.tEdit_SectionName.DataText = this._inventInputAcs.GetSectionName(sectionCode.Trim().PadLeft(2, '0'));
            //-----ADD BY 凌小青 on 2012/06/11 for Redmine#30238 ------>>>>>>
            this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode);
            this.tNedit_GoodsMGroup.SetInt(goodsUnitData.GoodsMGroup);
            //-----ADD BY 凌小青 on 2012/06/11 for Redmine#30238 ------<<<<<<
            int supplierCd = 0;
            string supplierNm1 = string.Empty;
            string supplierNm2 = string.Empty;
            this.GetGoodsMngInfo(out supplierCd, out supplierNm1,out supplierNm2);
            this.tNedit_SupplierCd.SetInt(supplierCd);
            this.tEdit_SupplierName.DataText = supplierNm1 + " " + supplierNm2;
            this.tEdit_SupplierName1.DataText = supplierNm1;
            this.tEdit_SupplierName2.DataText = supplierNm2;

            this.tNedit_AdjustCalcCost.SetValue(this._inventInputAcs.GetAdjustCalcCost(goodsUnitData));         // 調整用計算原価

            // --- ADD 2009/12/03 ---------->>>>>
            if (this.tNedit_StockUnitPrice.GetValue() == 0)
            {
                this.tNedit_StockUnitPrice.SetValue(this.tNedit_AdjustCalcCost.GetValue());
                this.BfStockUnitPrice_tNedit.SetValue(this.tNedit_AdjustCalcCost.GetValue());
            }
            // --- ADD 2009/12/03 ----------<<<<<

            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------------------------------<<<<<

            this.tNedit_GoodsLGroup.DataText = goodsUnitData.GoodsLGroup.ToString();                            // 商品大分類コード
            this.tEdit_GoodsLGroupName.DataText = goodsUnitData.GoodsLGroupName.TrimEnd();                      // 商品大分類名称
            this.tNedit_GoodsMGroup.DataText = goodsUnitData.GoodsMGroup.ToString();                            // 商品中分類コード
            this.tEdit_GoodsMGroupName.DataText = goodsUnitData.GoodsMGroupName.TrimEnd();                      // 商品中分類名称
            this.tNedit_BLGloupCode.DataText = goodsUnitData.BLGroupCode.ToString();                            // グループコード
            this.tEdit_BLGroupName.DataText = goodsUnitData.BLGroupName.TrimEnd();                              // グループコード名称
            this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode);                                          // ＢＬ品番
            this.tEdit_BLGoodsName.DataText = goodsUnitData.BLGoodsFullName.TrimEnd();                          // ＢＬ品名
            this.tNedit_EnterpriseGanreCode.SetInt(goodsUnitData.EnterpriseGanreCode);                          // 自社分類コード
            this.tEdit_Jan.DataText = goodsUnitData.Jan.TrimEnd();                                              // JANコード
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // ---ADD 2009/05/14 不具合対応[13260] --------------------------->>>>>
        #region GetSectionCodeFromGoodsUnitData(商品在庫情報から拠点コードを取得)
        /// <summary>
        /// 拠点コード取得(商品在庫情報ベース)
        /// </summary>
        /// <param name="goodsUnitData">商品在庫情報</param>
        /// <returns>在庫情報</returns>
        /// <remarks>
        /// <br>Note       : 商品在庫情報から拠点コードを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks> 
        private Stock GetSectionCodeFromGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            string sectionCode = string.Empty;

            //商品情報なし
            if (goodsUnitData == null)
            {
                return null;
            }
            //在庫情報なし
            if ((goodsUnitData.StockList == null) || (goodsUnitData.StockList.Count == 0))
            {
                return null;
            }

            for (int i = 0; i < goodsUnitData.StockList.Count; i++)
            {
                if (goodsUnitData.StockList[i].WarehouseCode.Trim().PadLeft(4, '0') == this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0'))
                {
                    return goodsUnitData.StockList[i];
                }
            }

            //商品在庫に対象の倉庫が無い
            return null;
        }
        #endregion

        #region GetSectionCodeFromWarehouseInfo(倉庫マスタから拠点コードを取得)
        /// <summary>
        /// 拠点コード取得(倉庫マスタベース)
        /// </summary>
        /// <returns>拠点コード</returns>
        /// <remarks>
        /// <br>Note       : 倉庫マスタから拠点コードを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks> 
        private string GetSectionCodeFromWarehouseInfo()
        {
            string warehouseCode = tEdit_WarehouseCode.Text;

            if (string.IsNullOrEmpty(warehouseCode.Trim()))
            {
                return string.Empty;
            }

            ArrayList arrayList = null;
            int status = this._warehouseGuideAcs.Search(out arrayList, this._enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return string.Empty;
            }

            Warehouse warehouse = null;
            for (int i = 0; i < arrayList.Count; i++)
            {
                warehouse = (Warehouse)arrayList[i];
                if (warehouseCode.Trim().PadLeft(4, '0') == warehouse.WarehouseCode.Trim().PadLeft(4, '0'))
                {
                    return warehouse.SectionCode;
                }
            }

            return string.Empty;
        }
        #endregion

        #region GetGoodsMngInfo(商品管理情報取得)
        /// <summary>
        /// 商品管理情報マスタ取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <remarks>
        /// <br>Note       : 商品管理情報を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2012/06/11 凌小青</br>
        /// <br>             Redmine#30238</br>
        /// </remarks> 
        private void GetGoodsMngInfo(out int supplierCd, out string supplierNm1, out string supplierNm2)
        {
            supplierCd = 0;
            supplierNm1 = string.Empty;
            supplierNm2 = string.Empty;

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = this._enterpriseCode;
            goodsUnitData.SectionCode = this.tEdit_SectionCode.DataText;
            goodsUnitData.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            goodsUnitData.GoodsNo = this.tEdit_GoodsNo.DataText;
            goodsUnitData.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            goodsUnitData.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();//ADD BY 凌小青 on 2012/06/11 for Redmine#30238
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            supplierCd = goodsUnitData.SupplierCd;
            if (supplierCd == 0)
            {
                supplierNm1 = string.Empty;
                supplierNm2 = string.Empty;
            }
            else
            {
                SupplierWork supplierWork = null;
                int status = this._goodsAcs.GetSupplier(LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd, out supplierWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    supplierNm1 = supplierWork.SupplierNm1;
                    supplierNm2 = supplierWork.SupplierNm2;
                }
                else
                {
                    supplierNm1 = string.Empty;
                    supplierNm2 = string.Empty;
                }
            }
        }
        #endregion

        // ---ADD 2009/05/14 不具合対応[13260] ---------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品データ画面展開処理(画面←商品)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <remarks>
        /// <br>Note       : 商品ガイドから得た情報を画面に展開します</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>       
        private void SetGoodsUnitForScreen(GoodsUnitData goodsUnitData)
        {
            //製番、電話番号をクリア

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////製番管理区分が無しの時は製番、電話番号を入力不可にする
            //if(goodsUnitData.PrdNumMngDiv == 0)
            //{
            //    ProductNumberClear();
            //    ScreeParmitionControl(false);
            //    //棚卸数を入力可にする
            //    this.tNedit_InventoryStockCnt.Enabled = true;
            //}
            //else
            //{              
            //    ScreeParmitionControl(true);
            //    //製番or電話番号が入力されているか？
            //    if(this.ProductNumber_tEdit.DataText.TrimEnd() == "" && this.StockTelNo1_tEdit.DataText.TrimEnd() == "" && this.StockTelNo2_tEdit.DataText.TrimEnd() == "")
            //    {
            //        //棚卸数を入力可にする
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //棚卸数を入力可にする
            //		if ( tNedit_InventoryStockCnt.GetInt() > 0 )
            //			this.tNedit_InventoryStockCnt.Enabled = false;
            //		else
            //			this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //}
            //
            //// 2007.07.25 kubo add
            //this._prdNumMngDiv = goodsUnitData.PrdNumMngDiv;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsCode.TrimEnd();
            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo.TrimEnd();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //品名
            this.tEdit_GoodsName.DataText = goodsUnitData.GoodsName.TrimEnd();
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////キャリアコード
            //this.CarrierCode_tNedit.SetInt(goodsUnitData.CarrierCode);
            ////キャリア名称
            //this.CarrierName_tEdit.DataText = goodsUnitData.CarrierName.TrimEnd();
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //メーカーコード
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this.MakerCode_tNedit.SetInt(goodsUnitData.MakerCode);
            this.MakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //メーカー名称
            this.tEdit_MakerName.DataText = goodsUnitData.MakerName.TrimEnd();
            //商品大分類コード
            this.LgGoodsCode_tEdit.DataText = goodsUnitData.LargeGoodsGanreCode;
            //商品大分類名称
            this.LargeGoodsGanreName_tEdit.DataText = goodsUnitData.LargeGoodsGanreName.TrimEnd();
            //商品中分類コード
            this.MdGoodsCode_tEdit.DataText = goodsUnitData.MediumGoodsGanreCode;
            //商品中分類名称
            this.MediumGoodsGanreName_tEdit.DataText = goodsUnitData.MediumGoodsGanreName.TrimEnd();
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////機種コード
            //this.CellphonModelCode_tEdit.DataText = goodsUnitData.CellphoneModelCode.TrimEnd();
            ////機種名称
            //this.CellphonModelName_tEdit.DataText = goodsUnitData.CellphoneModelName.TrimEnd();
            ////系統色コード
            //this.SystematicColorCode_tNedit.SetInt(goodsUnitData.SystematicColorCd);
            ////系統色名称
            //this.SystematicColorName_tEdit.DataText= goodsUnitData.SystematicColorNm.TrimEnd();
            ////製番管理区分
            //this.PrdNumMngDiv_tNedit.SetInt(goodsUnitData.PrdNumMngDiv);
            //グループコード
            this.DtGoodsGanreCode_tEdit.DataText = goodsUnitData.DetailGoodsGanreCode;
            //グループコード名称
            this.tEdit_BLGroupName.DataText = goodsUnitData.DetailGoodsGanreName.TrimEnd();
            //ＢＬ品番
            this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode);
            //ＢＬ品名
            this.tEdit_BLGoodsName.DataText = goodsUnitData.BLGoodsFullName.TrimEnd();
            //自社分類コード
            this.tNedit_EnterpriseGanreCode.SetInt(goodsUnitData.EnterpriseGanreCode);
            //自社分類名称
            this.EnterpriseGanreName_tEdit.DataText = goodsUnitData.EnterpriseGanreName.TrimEnd();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //JANコード
            this.tEdit_Jan.DataText = goodsUnitData.Jan.TrimEnd();
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 画面入力制御処理

        ///// <summary>
        ///// 画面入力制御処理
        ///// </summary>
        ///// <param name="flag"></param>
        ///// <remarks>
        ///// <br>Note       : 画面入力制御処理を行います</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.04.19</br>
        ///// </remarks>       
        //private void ScreeParmitionControl(bool flag)
        //{
        //    //製番
        //    this.ProductNumber_tEdit.Enabled = flag;
        //    //電話番号１
        //    this.StockTelNo1_tEdit.Enabled = flag;
        //    //電話番号１
        //    this.StockTelNo2_tEdit.Enabled = flag;
        //}

        #endregion

        #region 製番関連情報クリア処理

        ///// <summary>
        ///// 製番関連情報クリア処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 製番関連情報をクリアします</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.04.23</br>
        ///// </remarks>       
        //private void ProductNumberClear()
        //{
        //    //製番
        //    this.ProductNumber_tEdit.Clear();
        //    //電話番号１
        //    this.StockTelNo1_tEdit.Clear();
        //    //電話番号１
        //    this.StockTelNo2_tEdit.Clear();
        //}

        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        #endregion

        #region 画面情報格納処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面情報格納処理(結果クラス←画面)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を結果クラスに展開します</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             新規入力時の項目取得方法を変更する</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
        /// <br>             障害報告 #18764</br>
        /// <br>UpdateNote : 2014/10/31 xuyb</br>
        /// <br>             Redmine#40336 障害現象② 原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる</br>
        /// </remarks>       
        private void SetInventResultWorkFromScreen()
        {
            switch(this._dispMode)
            {
                case (int)DispModeState.CreateNew:  // 新規モード
                case (int)DispModeState.EditNew:    // 新規分編集モード
                {   
                    
                    // 企業コード
                    this._inventoryDataUpdateWorkAfter.EnterpriseCode = this._inventoryDataUpdateWorkBefore.EnterpriseCode;
                    // 拠点コード
                    this._inventoryDataUpdateWorkAfter.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                    // 倉庫コード
                    this._inventoryDataUpdateWorkAfter.WarehouseCode = this.tEdit_WarehouseCode.DataText.TrimEnd();
                    // 品番
                    this._inventoryDataUpdateWorkAfter.GoodsNo = this.tEdit_GoodsNo.DataText.TrimEnd();
                    // 品名                                                                                         //ADD 2009/04/21 不具合対応[13075]
                    this._inventoryDataUpdateWorkAfter.GoodsName = this.tEdit_GoodsName.DataText.TrimEnd();         //ADD 2009/04/21 不具合対応[13075]
                    // 定価                                                                //ADD 2011/01/30
                    this._inventoryDataUpdateWorkAfter.ListPrice = this.ListPrice;         //ADD 2011/01/30
                    // メーカーコード
                    this._inventoryDataUpdateWorkAfter.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                    // 商品大分類コード
                    this._inventoryDataUpdateWorkAfter.GoodsLGroup = this.tNedit_GoodsLGroup.GetInt();
                    // 商品中分類コード
                    this._inventoryDataUpdateWorkAfter.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                    // グループコード
                    this._inventoryDataUpdateWorkAfter.BLGroupCode = this.tNedit_BLGloupCode.GetInt();
                    // ＢＬ品番
                    this._inventoryDataUpdateWorkAfter.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                    // 自社分類コード
                    this._inventoryDataUpdateWorkAfter.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                    // 仕入先コード
                    this._inventoryDataUpdateWorkAfter.SupplierCd = this.tNedit_SupplierCd.GetInt();
                    // 棚番
                    this._inventoryDataUpdateWorkAfter.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText.TrimEnd();
                    // 重複棚番1
                    this._inventoryDataUpdateWorkAfter.DuplicationShelfNo1 = this.tEdit_DuplicationShelfNo1.DataText.TrimEnd();
                    // 重複棚番2
                    this._inventoryDataUpdateWorkAfter.DuplicationShelfNo2 = this.tEdit_DuplicationShelfNo2.DataText.TrimEnd();
                    // JANコード
                    this._inventoryDataUpdateWorkAfter.Jan = this.tEdit_Jan.DataText.TrimEnd();
                    // 仕入単価
                    this._inventoryDataUpdateWorkAfter.StockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                    // 棚卸在庫数
                    this._inventoryDataUpdateWorkAfter.InventoryStockCnt = this.tNedit_InventoryStockCnt.GetValue();
                    // 棚卸過不足数(棚卸在庫数と同じものを返す)
                    this._inventoryDataUpdateWorkAfter.InventoryTolerancCnt = this.tNedit_InventoryStockCnt.GetValue();
                    // 棚卸実施日
                    this._inventoryDataUpdateWorkAfter.InventoryDay = this.EnforcementDay_tDateEdit.GetDateTime();
                    // 棚卸日
                    this._inventoryDataUpdateWorkAfter.InventoryDate = this.InventoryDay_tDateEdit.GetDateTime();

                    if (this._dispMode == (int)DispModeState.CreateNew)
                    {
                        // 論理削除区分(新規なので0固定)
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = 0;
                        // 通番(0固定)
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = 0;
                        // 変更前仕入単価
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        // 仕入単価変更フラグ(0:無し、1:有り)
                        this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;
                        // 最終仕入年月日
                        //this._inventoryDataUpdateWorkAfter.LastStockDate = DateTime.MinValue;                         //DEL 2009/05/14 不具合対応[13260]
                        this._inventoryDataUpdateWorkAfter.LastStockDate = this.LastStockDate_tDateEdit.GetDateTime();  //ADD 2009/05/14 不具合対応[13260]
                        // 在庫区分
                        this._inventoryDataUpdateWorkAfter.StockDiv = this.tNedit_StockDiv.GetInt();                    //ADD 2009/05/14 不具合対応[13260]
                        // 在庫総数(0固定)
                        //this._inventoryDataUpdateWorkAfter.StockTotal = 0D;                                           //DEL 2009/05/14 不具合対応[13260]
                        //this._inventoryDataUpdateWorkAfter.StockTotal = this.tNedit_InventoryStockCnt.GetValue();       //ADD 2009/05/14 不具合対応[13260] // 2009/10/08 DEL
                        //this._inventoryDataUpdateWorkAfter.StockTotal = 0;                                              // 2009/10/08 ADD  // DEL 2009/12/03
                        this._inventoryDataUpdateWorkAfter.StockTotal = this.tNedit_StockTotal.GetValue();   // ADD 2009/12/03
                        // マシン在庫額
                        //this._inventoryDataUpdateWorkAfter.StockMashinePrice =
                        //    this._inventInputAcs.GetTotalPriceToLong(this.tNedit_InventoryStockCnt.GetValue(), this.tNedit_StockUnitPrice.GetValue());  //ADD 2009/05/14 不具合対応[13260] // DEL 2009/12/03
                        this._inventoryDataUpdateWorkAfter.StockMashinePrice =
                            this._inventInputAcs.GetTotalPriceToLong(this.tNedit_StockTotal.GetValue(), this.tNedit_StockUnitPrice.GetValue());  // ADD 2009/12/03
                        
                        // 棚卸準備処理日付
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = DateTime.MinValue;
                        // 棚卸準備処理時間
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = 0;
                        // 棚卸更新日
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = DateTime.MinValue;
                        // 棚卸新規追加区分(0:自動作成、1:新規作成)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = 1;

                        // 調整用計算原価
                        // ※棚卸在庫額に関してはマシン在庫額と同様の値となるが、グリッドの値設定時イベントにて取得している為、ここには書かない
                        this._inventoryDataUpdateWorkAfter.AdjstCalcCost = this.tNedit_AdjustCalcCost.GetValue();       //ADD 2009/05/14 不具合対応[13260]
                    }
                    else
                    {
                        // 論理削除区分
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = this._inventoryDataUpdateWorkBefore.LogicalDeleteCode;
                        // 通番
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = this._inventoryDataUpdateWorkBefore.InventorySeqNo;
                        // 変更前仕入単価
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this._inventoryDataUpdateWorkBefore.StockUnitPriceFl;
                        // 仕入単価変更フラグ(0:無し、1:有り)
                        if (this._inventoryDataUpdateWorkBefore.StockUnitPriceFl.Equals(this.tNedit_StockUnitPrice.GetValue()))
                        {
                            // 変更無し
                            // まだフラグが立っていない
                            if (this._inventoryDataUpdateWorkBefore.StkUnitPriceChgFlg == 0)
                            {
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;
                            }
                            else
                            {
                                // 変更有り
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                            }
                        }
                        else
                        {
                            // 変更有り
                            this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                        }
                        // 最終仕入年月日
                        this._inventoryDataUpdateWorkAfter.LastStockDate = this._inventoryDataUpdateWorkBefore.LastStockDate;
                        // 在庫総数(0固定)
                        this._inventoryDataUpdateWorkAfter.StockTotal = this._inventoryDataUpdateWorkBefore.StockTotal;
                        // 棚卸準備処理日付
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = this._inventoryDataUpdateWorkBefore.InventoryPreprDay;
                        // 棚卸準備処理時間
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = this._inventoryDataUpdateWorkBefore.InventoryPreprTim;
                        // 棚卸更新日
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = this._inventoryDataUpdateWorkBefore.LastInventoryUpdate;
                        // 棚卸新規追加区分(0:自動作成、1:新規作成)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = this._inventoryDataUpdateWorkBefore.InventoryNewDiv;
                    }
                    // 棚卸在庫額
                    this._inventoryDataUpdateWorkAfter.InventoryStockPrice = this._inventInputAcs.GetTotalPriceToLong(this._inventoryDataUpdateWorkAfter.InventoryStockCnt, this._inventoryDataUpdateWorkAfter.StockUnitPriceFl); // ADD 2014/10/31 xuyb FOR Redmine#40336 障害現象②対応
                    break;
                }
                case (int)DispModeState.EditOld:
                {
                    //参照
                    this._inventoryDataUpdateWorkAfter = this._inventoryDataUpdateWorkBefore;
                    break;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用にコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面情報格納処理(結果クラス←画面)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を結果クラスに展開します</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>       
        private void SetInventResultWorkFromScreen()
        {
            switch (this._dispMode)
            {
                //新規モード
                case (int)DispModeState.CreateNew:
                    {
                        #region 新規モード
                        //論理削除区分(新規なので0固定)
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = 0;
                        //企業コード
                        this._inventoryDataUpdateWorkAfter.EnterpriseCode = this._inventoryDataUpdateWorkBefore.EnterpriseCode;
                        //拠点コード
                        this._inventoryDataUpdateWorkAfter.SectionCode = this._inventoryDataUpdateWorkBefore.SectionCode;
                        //拠点ガイド名称
                        //                    this._inventoryDataUpdateWorkAfter.SectionGuideNm = this._inventoryDataUpdateWorkBefore.SectionGuideNm;
                        //通番(0固定)
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = 0;
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////製番在庫マスタGuid
                        //this._inventoryDataUpdateWorkAfter.ProductStockGuid = Guid.NewGuid();
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //倉庫コード
                        this._inventoryDataUpdateWorkAfter.WarehouseCode = this.tEdit_WarehouseCode.DataText.TrimEnd();
                        //倉庫名称
                        this._inventoryDataUpdateWorkAfter.WarehouseName = this.tEdit_WarehouseName.DataText.TrimEnd();
                        //品番
                        this._inventoryDataUpdateWorkAfter.GoodsNo = this.tEdit_GoodsNo.DataText.TrimEnd();
                        //品名
                        this._inventoryDataUpdateWorkAfter.GoodsName = this.tEdit_GoodsName.DataText.TrimEnd();
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////キャリアコード
                        //this._inventoryDataUpdateWorkAfter.CarrierCode = this.CarrierCode_tNedit.GetInt();
                        ////キャリア名称
                        //this._inventoryDataUpdateWorkAfter.CarrierName = this.CarrierName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //メーカーコード
                        this._inventoryDataUpdateWorkAfter.GoodsMakerCd = this.MakerCode_tNedit.GetInt();
                        //メーカー名称
                        this._inventoryDataUpdateWorkAfter.MakerName = this.tEdit_MakerName.DataText.TrimEnd();
                        //商品大分類コード
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreCode = this.LgGoodsCode_tEdit.DataText.TrimEnd();
                        //商品大分類名称
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreName = this.LargeGoodsGanreName_tEdit.DataText.TrimEnd();
                        //商品中分類コード
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreCode = this.MdGoodsCode_tEdit.DataText.TrimEnd();
                        //商品中分類名称
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreName = this.MediumGoodsGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        ////機種コード
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelCode = this.CellphonModelCode_tEdit.DataText.TrimEnd();
                        ////機種名称
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelName = this.CellphonModelName_tEdit.DataText.TrimEnd();
                        ////系統色コード
                        //this._inventoryDataUpdateWorkAfter.SystematicColorCd = this.SystematicColorCode_tNedit.GetInt();
                        ////系統色名称
                        //this._inventoryDataUpdateWorkAfter.SystematicColorNm = this.SystematicColorName_tEdit.DataText.TrimEnd();
                        ////事業者コード
                        //this._inventoryDataUpdateWorkAfter.CarrierEpCode = this.CarrierEpCode_tNedit.GetInt();
                        ////事業者名称
                        //this._inventoryDataUpdateWorkAfter.CarrierEpName = this.CarrierEpName_tEdit.DataText.TrimEnd();
                        //グループコード
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreCode = this.DtGoodsGanreCode_tEdit.DataText.TrimEnd();
                        //グループコード名称
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreName = this.tEdit_BLGroupName.DataText.TrimEnd();
                        //ＢＬ品番
                        this._inventoryDataUpdateWorkAfter.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        //ＢＬ品名
                        //this._inventoryDataUpdateWorkAfter.BLGoodsName = this.tEdit_BLGoodsName.DataText.TrimEnd();
                        //自社分類コード
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        //自社分類名称
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreName = this.EnterpriseGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        //得意先(仕入先)コード
                        this._inventoryDataUpdateWorkAfter.CustomerCode = this.tNedit_SupplierCd.GetInt();
                        //得意先(仕入先)名称１
                        this._inventoryDataUpdateWorkAfter.CustomerName = this.tEdit_SupplierName.DataText.TrimEnd();
                        //得意先(仕入先)名称２
                        this._inventoryDataUpdateWorkAfter.CustomerName2 = this.CustomerName2_tEdit.DataText.TrimEnd();
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        ////仕入日
                        //this._inventoryDataUpdateWorkAfter.StockDate = this.StockDate_tDateEdit.GetDateTime();
                        ////入荷日
                        //this._inventoryDataUpdateWorkAfter.ArrivalGoodsDay = this.ArrivalGoodsDay_tDateEdit.GetDateTime();
                        ////製造番号
                        //this._inventoryDataUpdateWorkAfter.ProductNumber = this.ProductNumber_tEdit.DataText.TrimEnd();
                        ////商品電話番号1
                        //this._inventoryDataUpdateWorkAfter.StockTelNo1 = this.StockTelNo1_tEdit.DataText.TrimEnd();
                        ////変更前電話番号1
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo1 = this.StockTelNo1_tEdit.DataText.TrimEnd();
                        ////商品電話番号1変更フラグ(0:無し、1:有り)
                        //this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 0;
                        ////商品電話番号2
                        //this._inventoryDataUpdateWorkAfter.StockTelNo2 = this.StockTelNo2_tEdit.DataText.TrimEnd();
                        ////変更前電話番号2
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo2 = this.StockTelNo2_tEdit.DataText.TrimEnd();
                        ////商品電話番号2変更フラグ(0:無し、1:有り)
                        //this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 0;
                        //棚番
                        this._inventoryDataUpdateWorkAfter.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText.TrimEnd();
                        //重複棚番1
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo1 = this.tEdit_DuplicationShelfNo1.DataText.TrimEnd();
                        //重複棚番2
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo2 = this.tEdit_DuplicationShelfNo2.DataText.TrimEnd();
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        //JANコード
                        this._inventoryDataUpdateWorkAfter.Jan = this.tEdit_Jan.DataText.TrimEnd();
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        ////仕入単価
                        //this._inventoryDataUpdateWorkAfter.StockUnitPrice = (long)this.tNedit_StockUnitPrice.GetValue();
                        ////変更前仕入単価
                        //this._inventoryDataUpdateWorkAfter.BfStockUnitPrice = (long)this.tNedit_StockUnitPrice.GetValue();
                        //仕入単価
                        this._inventoryDataUpdateWorkAfter.StockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        //変更前仕入単価
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        //仕入単価変更フラグ(0:無し、1:有り)
                        this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;

                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////在庫区分
                        //switch(this.StockExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    //自社
                        //    case 0:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 0;
                        //        break;                   
                        //    }
                        //    //受託
                        //    case 1:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 10;
                        //        break;                   
                        //    }
                        //    //委託(自社)
                        //    case 2:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;                   
                        //    }
                        //    //委託(受託)
                        //    case 3:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;
                        //    }
                        //
                        //}
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////移動状態
                        //this._inventoryDataUpdateWorkAfter.MoveStatus = 0;
                        ////商品状態
                        //this._inventoryDataUpdateWorkAfter.GoodsCodeStatus = 0;
                        ////製番管理区分
                        //this._inventoryDataUpdateWorkAfter.PrdNumMngDiv = this.PrdNumMngDiv_tNedit.GetInt();
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //最終仕入年月日
                        this._inventoryDataUpdateWorkAfter.LastStockDate = DateTime.MinValue;
                        //在庫総数(0固定)
                        this._inventoryDataUpdateWorkAfter.StockTotal = 0D;
                        //出荷先得意先(委託先)コード
                        this._inventoryDataUpdateWorkAfter.ShipCustomerCode = this.ShipCustomerCode_tNedit.GetInt();
                        //出荷先得意先(委託先)名称１
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName = this.ShipCustomerName1_tEdit.DataText.TrimEnd();
                        //出荷先得意先(委託先)名称２
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName2 = this.ShipCustomerName2_tEdit.DataText.TrimEnd();
                        //棚卸在庫数
                        this._inventoryDataUpdateWorkAfter.InventoryStockCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //棚卸過不足数(棚卸在庫数と同じものを返す)
                        this._inventoryDataUpdateWorkAfter.InventoryTolerancCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //棚卸準備処理日付
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = DateTime.MinValue;
                        //棚卸準備処理時間
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = 0;
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        ////棚卸実施日
                        //this._inventoryDataUpdateWorkAfter.InventoryDay = this.InventoryDay_tDateEdit.GetDateTime();
                        //棚卸実施日
                        this._inventoryDataUpdateWorkAfter.InventoryDay = this.EnforcementDay_tDateEdit.GetDateTime();
                        //棚卸日
                        this._inventoryDataUpdateWorkAfter.InventoryDate = this.InventoryDay_tDateEdit.GetDateTime();
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        //棚卸更新日
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = DateTime.MinValue;
                        //棚卸新規追加区分(0:自動作成、1:新規作成)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = 1;
                        #endregion
                        break;
                    }
                //新規分編集モード
                case (int)DispModeState.EditNew:
                    {
                        #region 新規分編集モード
                        //論理削除区分
                        this._inventoryDataUpdateWorkAfter.LogicalDeleteCode = this._inventoryDataUpdateWorkBefore.LogicalDeleteCode;
                        //企業コード
                        this._inventoryDataUpdateWorkAfter.EnterpriseCode = this._inventoryDataUpdateWorkBefore.EnterpriseCode;
                        //拠点コード
                        this._inventoryDataUpdateWorkAfter.SectionCode = this._inventoryDataUpdateWorkBefore.SectionCode;
                        //拠点ガイド名称
                        //                    this._inventoryDataUpdateWorkAfter.SectionGuideNm = this._inventoryDataUpdateWorkBefore.SectionGuideNm;
                        //通番(0固定)
                        this._inventoryDataUpdateWorkAfter.InventorySeqNo = this._inventoryDataUpdateWorkBefore.InventorySeqNo;
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////製番在庫マスタGuid
                        //this._inventoryDataUpdateWorkAfter.ProductStockGuid = this._inventoryDataUpdateWorkBefore.ProductStockGuid;
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //倉庫コード
                        this._inventoryDataUpdateWorkAfter.WarehouseCode = this.tEdit_WarehouseCode.DataText.TrimEnd();
                        //倉庫名称
                        this._inventoryDataUpdateWorkAfter.WarehouseName = this.tEdit_WarehouseName.DataText.TrimEnd();
                        //品番
                        this._inventoryDataUpdateWorkAfter.GoodsNo = this.tEdit_GoodsNo.DataText.TrimEnd();
                        //品名
                        this._inventoryDataUpdateWorkAfter.GoodsName = this.tEdit_GoodsName.DataText.TrimEnd();
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////キャリアコード
                        //this._inventoryDataUpdateWorkAfter.CarrierCode = this.CarrierCode_tNedit.GetInt();
                        ////キャリア名称
                        //this._inventoryDataUpdateWorkAfter.CarrierName = this.CarrierName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //メーカーコード
                        this._inventoryDataUpdateWorkAfter.GoodsMakerCd = this.MakerCode_tNedit.GetInt();
                        //メーカー名称
                        this._inventoryDataUpdateWorkAfter.MakerName = this.tEdit_MakerName.DataText.TrimEnd();
                        //商品大分類コード
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreCode = this.LgGoodsCode_tEdit.DataText.TrimEnd();
                        //商品大分類名称
                        this._inventoryDataUpdateWorkAfter.LargeGoodsGanreName = this.LargeGoodsGanreName_tEdit.DataText.TrimEnd();
                        //商品中分類コード
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreCode = this.MdGoodsCode_tEdit.DataText.TrimEnd();
                        //商品中分類名称
                        this._inventoryDataUpdateWorkAfter.MediumGoodsGanreName = this.MediumGoodsGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        ////機種コード
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelCode = this.CellphonModelCode_tEdit.DataText.TrimEnd();
                        ////機種名称
                        //this._inventoryDataUpdateWorkAfter.CellphoneModelName = this.CellphonModelName_tEdit.DataText.TrimEnd();
                        ////系統色コード
                        //this._inventoryDataUpdateWorkAfter.SystematicColorCd = this.SystematicColorCode_tNedit.GetInt();
                        ////系統色名称
                        //this._inventoryDataUpdateWorkAfter.SystematicColorNm = this.SystematicColorName_tEdit.DataText.TrimEnd();
                        ////事業者コード
                        //this._inventoryDataUpdateWorkAfter.CarrierEpCode = this.CarrierEpCode_tNedit.GetInt();
                        ////事業者名称
                        //this._inventoryDataUpdateWorkAfter.CarrierEpName = this.CarrierEpName_tEdit.DataText.TrimEnd();
                        //グループコード
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreCode = this.DtGoodsGanreCode_tEdit.DataText.TrimEnd();
                        //グループコード名称
                        this._inventoryDataUpdateWorkAfter.DetailGoodsGanreName = this.tEdit_BLGroupName.DataText.TrimEnd();
                        //ＢＬ品番
                        this._inventoryDataUpdateWorkAfter.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        //ＢＬ品名
                        //this._inventoryDataUpdateWorkAfter.BLGoodsName = this.tEdit_BLGoodsName.DataText.TrimEnd();
                        //自社分類コード
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        //自社分類名称
                        this._inventoryDataUpdateWorkAfter.EnterpriseGanreName = this.EnterpriseGanreName_tEdit.DataText.TrimEnd();
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        //得意先(仕入先)コード
                        this._inventoryDataUpdateWorkAfter.CustomerCode = this.tNedit_SupplierCd.GetInt();
                        //得意先(仕入先)名称１
                        this._inventoryDataUpdateWorkAfter.CustomerName = this.tEdit_SupplierName.DataText.TrimEnd();
                        //得意先(仕入先)名称２
                        this._inventoryDataUpdateWorkAfter.CustomerName2 = this.CustomerName2_tEdit.DataText.TrimEnd();
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        ////仕入日
                        //this._inventoryDataUpdateWorkAfter.StockDate = this.StockDate_tDateEdit.GetDateTime();
                        ////入荷日
                        //this._inventoryDataUpdateWorkAfter.ArrivalGoodsDay = this.ArrivalGoodsDay_tDateEdit.GetDateTime();
                        ////製造番号
                        //this._inventoryDataUpdateWorkAfter.ProductNumber = this.ProductNumber_tEdit.DataText.TrimEnd();
                        ////商品電話番号1
                        //this._inventoryDataUpdateWorkAfter.StockTelNo1 = this.StockTelNo1_tEdit.DataText.TrimEnd();
                        ////変更前電話番号1
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo1 = this._inventoryDataUpdateWorkBefore.StockTelNo1.TrimEnd();
                        ////商品電話番号1変更フラグ(0:無し、1:有り)
                        //if(this._inventoryDataUpdateWorkBefore.StockTelNo1.Equals(this.StockTelNo1_tEdit.DataText.TrimEnd()))
                        //{
                        //    //変更無し
                        //    //まだフラグが立っていない
                        //    if(this._inventoryDataUpdateWorkBefore.StkTelNo1ChgFlg == 0)
                        //    {
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 0;
                        //    }
                        //    else
                        //    {
                        //        //変更有り
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 1;
                        //    }
                        //}
                        //else
                        //{
                        //    //変更有り
                        //    this._inventoryDataUpdateWorkAfter.StkTelNo1ChgFlg = 1;
                        //}                               
                        ////商品電話番号2
                        //this._inventoryDataUpdateWorkAfter.StockTelNo2 = this.StockTelNo2_tEdit.DataText.TrimEnd();
                        ////変更前電話番号2
                        //this._inventoryDataUpdateWorkAfter.BfStockTelNo2 = this._inventoryDataUpdateWorkBefore.StockTelNo1.TrimEnd();
                        ////商品電話番号2変更フラグ(0:無し、1:有り)
                        //if(this._inventoryDataUpdateWorkBefore.StockTelNo2.Equals(this.StockTelNo2_tEdit.DataText.TrimEnd()))
                        //{
                        //    //変更無し
                        //    //まだフラグが立っていない
                        //    if(this._inventoryDataUpdateWorkBefore.StkTelNo2ChgFlg == 0)
                        //    {
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 0;
                        //    }
                        //    else
                        //    {
                        //        //変更有り
                        //        this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 1;
                        //    }
                        //    
                        //}
                        //else
                        //{
                        //    //変更有り
                        //    this._inventoryDataUpdateWorkAfter.StkTelNo2ChgFlg = 1;
                        //}                           
                        //棚番
                        this._inventoryDataUpdateWorkAfter.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText.TrimEnd();
                        //重複棚番1
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo1 = this.tEdit_DuplicationShelfNo1.DataText.TrimEnd();
                        //重複棚番2
                        this._inventoryDataUpdateWorkAfter.DuplicationShelfNo2 = this.tEdit_DuplicationShelfNo2.DataText.TrimEnd();
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        //JANコード
                        this._inventoryDataUpdateWorkAfter.Jan = this.tEdit_Jan.DataText.TrimEnd();
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        ////仕入単価
                        //this._inventoryDataUpdateWorkAfter.StockUnitPrice = (long)this.tNedit_StockUnitPrice.GetValue();
                        ////変更前仕入単価
                        //this._inventoryDataUpdateWorkAfter.BfStockUnitPrice = this._inventoryDataUpdateWorkBefore.StockUnitPrice;
                        ////仕入単価変更フラグ(0:無し、1:有り)
                        //if(this._inventoryDataUpdateWorkBefore.StockUnitPrice.Equals((long)this.tNedit_StockUnitPrice.GetValue()))
                        //仕入単価
                        this._inventoryDataUpdateWorkAfter.StockUnitPriceFl = this.tNedit_StockUnitPrice.GetValue();
                        //変更前仕入単価
                        this._inventoryDataUpdateWorkAfter.BfStockUnitPriceFl = this._inventoryDataUpdateWorkBefore.StockUnitPriceFl;
                        //仕入単価変更フラグ(0:無し、1:有り)
                        if (this._inventoryDataUpdateWorkBefore.StockUnitPriceFl.Equals(this.tNedit_StockUnitPrice.GetValue()))
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        {
                            //変更無し
                            //まだフラグが立っていない
                            if (this._inventoryDataUpdateWorkBefore.StkUnitPriceChgFlg == 0)
                            {
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 0;
                            }
                            else
                            {
                                //変更有り
                                this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                            }
                        }
                        else
                        {
                            //変更有り
                            this._inventoryDataUpdateWorkAfter.StkUnitPriceChgFlg = 1;
                        }
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////在庫区分
                        //switch(this.StockExtraDiv_ultraOptionSet.CheckedIndex)
                        //{
                        //    //自社
                        //    case 0:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 0;
                        //        break;                   
                        //    }
                        //    //受託
                        //    case 1:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 10;
                        //        break;                   
                        //    }
                        //    //委託(自社)
                        //    case 2:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 0;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;                   
                        //    }
                        //    //委託(受託)
                        //    case 3:
                        //    {
                        //        //在庫区分
                        //        this._inventoryDataUpdateWorkAfter.StockDiv = 1;
                        //        //在庫状態
                        //        this._inventoryDataUpdateWorkAfter.StockState = 20;
                        //        break;                   
                        //    }
                        //}
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        ////移動状態
                        //this._inventoryDataUpdateWorkAfter.MoveStatus = this._inventoryDataUpdateWorkBefore.MoveStatus;
                        ////商品状態
                        //this._inventoryDataUpdateWorkAfter.GoodsCodeStatus = this._inventoryDataUpdateWorkBefore.GoodsCodeStatus;
                        ////製番管理区分
                        //this._inventoryDataUpdateWorkAfter.PrdNumMngDiv = this.PrdNumMngDiv_tNedit.GetInt();
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //最終仕入年月日
                        this._inventoryDataUpdateWorkAfter.LastStockDate = this._inventoryDataUpdateWorkBefore.LastStockDate;
                        //在庫総数(0固定)
                        this._inventoryDataUpdateWorkAfter.StockTotal = this._inventoryDataUpdateWorkBefore.StockTotal;
                        //出荷先得意先(委託先)コード
                        this._inventoryDataUpdateWorkAfter.ShipCustomerCode = this.ShipCustomerCode_tNedit.GetInt();
                        //出荷先得意先(委託先)名称１
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName = this.ShipCustomerName1_tEdit.DataText.TrimEnd();
                        //出荷先得意先(委託先)名称２
                        this._inventoryDataUpdateWorkAfter.ShipCustomerName2 = this.ShipCustomerName2_tEdit.DataText.TrimEnd();
                        //棚卸在庫数
                        this._inventoryDataUpdateWorkAfter.InventoryStockCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //棚卸過不足数(棚卸在庫数と同じものを返す)
                        this._inventoryDataUpdateWorkAfter.InventoryTolerancCnt = this.tNedit_InventoryStockCnt.GetValue();
                        //棚卸準備処理日付
                        this._inventoryDataUpdateWorkAfter.InventoryPreprDay = this._inventoryDataUpdateWorkBefore.InventoryPreprDay;
                        //棚卸準備処理時間
                        this._inventoryDataUpdateWorkAfter.InventoryPreprTim = this._inventoryDataUpdateWorkBefore.InventoryPreprTim;
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        ////棚卸実施日
                        //this._inventoryDataUpdateWorkAfter.InventoryDay = this.InventoryDay_tDateEdit.GetDateTime();
                        //棚卸実施日
                        this._inventoryDataUpdateWorkAfter.InventoryDay = this.EnforcementDay_tDateEdit.GetDateTime();
                        //棚卸日
                        this._inventoryDataUpdateWorkAfter.InventoryDate = this.InventoryDay_tDateEdit.GetDateTime();
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        //棚卸更新日
                        this._inventoryDataUpdateWorkAfter.LastInventoryUpdate = this._inventoryDataUpdateWorkBefore.LastInventoryUpdate;
                        //棚卸新規追加区分(0:自動作成、1:新規作成)
                        this._inventoryDataUpdateWorkAfter.InventoryNewDiv = this._inventoryDataUpdateWorkBefore.InventoryNewDiv;

                        #endregion
                        break;
                    }
                case (int)DispModeState.EditOld:
                    {
                        //参照
                        this._inventoryDataUpdateWorkAfter = this._inventoryDataUpdateWorkBefore;
                        break;
                    }
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用にコメントアウト

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region 倉庫情報取得処理
        /// <summary>
        /// 倉庫情報取得処理
        /// </summary>
        /// <param name="code">倉庫コード</param>
        /// <remarks>
        /// <br>Note       : 倉庫情報の取得を行います</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void GetWarehouseInfo(string code)
        {
            Warehouse warehouseData = null;
            //倉庫情報Read
            int status = this._warehouseGuideAcs.Read(out warehouseData,this._enterpriseCode,this._loginSectionCode,code);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
               //何もしない
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                //コード名称をクリア
                this.tEdit_WarehouseCode.Clear();
                this.tEdit_WarehouseName.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"倉庫情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                //コード名称をクリア
                this.tEdit_WarehouseCode.Clear();
                this.tEdit_WarehouseName.Clear();

				return;
			}

            if(warehouseData != null)
            {
                //倉庫情報をセット
                this.tEdit_WarehouseCode.DataText = warehouseData.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseName.DataText = warehouseData.WarehouseName.TrimEnd();
            }
        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 事業者情報取得処理
		///// <summary>
		///// 事業者情報取得処理
		///// </summary>
		///// <param name="code">事業者コード</param>
		///// <remarks>
		///// <br>Note       : 事業者情報の取得を行います</br>
		///// <br>Programmer : 23001 中村　仁</br>
		///// <br>Date       : 2007.04.19</br>
		///// </remarks>    
		//private void GetCarrierEpInfo(int code)
		//{
		//    CarrierEp carrierEp = null;
		//    //事業者情報Read
		//    int status = this._carrierEpAcs.Read(out carrierEp, this._enterpriseCode, code);
        //
		//    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//    {
		//       //何もしない
		//    }
		//    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
		//    {
		//        //コード名称をクリア
		//        this.CarrierEpCode_tNedit.Clear();
		//        this.CarrierEpName_tEdit.Clear();
        //
		//        return;
		//    }
		//    else
		//    {
		//        TMsgDisp.Show(
		//            this,
		//            emErrorLevel.ERR_LEVEL_STOPDISP,
		//            this.Name,
		//            "事業者情報の取得に失敗しました。",
		//            status,
		//            MessageBoxButtons.OK);
        //
		//        //コード名称をクリア
		//        this.CarrierEpCode_tNedit.Clear();
		//        this.CarrierEpName_tEdit.Clear();
        //
		//        return;
		//    }
        //
		//    if(carrierEp != null)
		//    {
		//        //倉庫情報をセット
		//        this.CarrierEpCode_tNedit.SetInt(carrierEp.CarrierEpCode);
		//        this.CarrierEpName_tEdit.DataText = carrierEp.CarrierEpName.TrimEnd();
		//    }
		//}
        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region 商品情報取得処理

        /// <summary>
        /// 商品情報取得処理
        /// </summary>
        /// <param name="code">事業者コード</param>
        /// <remarks>
        /// <br>Note       : 商品情報取の取得を行います</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void GetGoodsInfo(string code)
        {
            string msg ="";
            List<GoodsUnitData> goodsUnitDataList = null;
            //倉庫情報Read
            int status = this._goodsGuide.ReadGoods(this,false,this._enterpriseCode,0,code,out goodsUnitDataList,out msg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
               //何もしない
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                //商品に紐付くコード、名称をクリア
                GoodsInfoClear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"商品情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                //商品に紐付くコード、名称をクリア
                GoodsInfoClear();
				return;
			}

            if(goodsUnitDataList != null)
            {
                //TODO:要変更
                //同じ品番(メーカー違い)が存在した場合にどちらか一つを選択する
                //仲介画面が必要。今のところないので、Listの最初の商品を戻す。
                GoodsUnitData goods = goodsUnitDataList[0];

                //商品に紐付くコード、名称をセット
                SetGoodsUnitForScreen(goods);
               
            }
        }

        #endregion
        
        #region 仕入先情報取得処理

        /// <summary>
        /// 仕入先情報取得処理
        /// </summary>
        /// <param name="code">得意先コード</param>
        /// <remarks>
        /// <br>Note       : 仕入先情報の取得を行います</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>   
        private void GetCustomerInfo(int code)
        {
            CustomerInfo customerInfo;
			CustSuppli custSuppli;

            //選択された得意先の状態をチェック
			int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo, out custSuppli);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //TODO:必要か？？
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                        status,
                        MessageBoxButtons.OK);

                    //画面情報をクリア
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierName.Clear();
                    this.CustomerName2_tEdit.Clear();

                    return;
                }
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した仕入先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

                //画面情報をクリア
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                //画面情報をクリア
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.CustomerName2_tEdit.Clear();

				return;
			}

            if(customerInfo != null)
            {
                //得意先(仕入先)コードをセット          
                this.tNedit_SupplierCd.SetInt(customerInfo.CustomerCode);
                this.tEdit_SupplierName.DataText = customerInfo.Name.TrimEnd();
                this.CustomerName2_tEdit.DataText = customerInfo.Name2.TrimEnd();
            }
			
        }      

        #endregion

        #region 委託先情報取得処理
        /// <summary>
        /// 委託先情報取得処理
        /// </summary>
        /// <param name="code">得意先コード</param>
        /// <remarks>
        /// <br>Note       : 委託先情報の取得を行います</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>   
        private void GetShipCustomerInfo(int code)
        {
            CustomerInfo customerInfo;
			
            //選択された得意先の状態をチェック
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo);
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{             
                //なにもしない             
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した得意先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

                //クリア
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"得意先情報の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

                //クリア
                this.ShipCustomerCode_tNedit.Clear();
                this.ShipCustomerName1_tEdit.Clear();
                this.ShipCustomerName2_tEdit.Clear();

				return;
			}

            if(customerInfo != null)
            {
                //委託先              
                this.ShipCustomerCode_tNedit.SetInt(customerInfo.CustomerCode);
                this.ShipCustomerName1_tEdit.DataText = customerInfo.Name.TrimEnd();
                this.ShipCustomerName2_tEdit.DataText = customerInfo.Name2.TrimEnd();
            }

        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region 画面入力チェック
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面必須項目入力チェック
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        /// <remarks>
        /// <br>Note       : 必須入力チェックを行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
        /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
        /// <br>             障害報告 #18869</br>
        /// </remarks> 
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // 倉庫
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                control = this.tEdit_WarehouseCode;
                message = "倉庫コードを入力して下さい。";
                return (false);
            }
            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            if (this._inventInputAcs.GetWarehouseName(warehouseCode) == "")
            {
                control = this.tEdit_WarehouseCode;
                message = "マスタに登録されていません。";
                return (false);
            }

            // 商品
            if (this.tEdit_GoodsNo.DataText.Trim() == "")
            {
                control = this.tEdit_GoodsNo;
                message = "品番を入力して下さい。";
                return (false);
            }

            //メーカー
            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                control = this.tEdit_GoodsNo;
                //message = "マスタに登録されていません。";// DEL 2011/01/11
                message = "商品マスタに登録されていません。";// ADD 2011/01/11
                return (false);
            }

            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
            int makerCode = this.tNedit_GoodsMakerCd.GetInt();

         
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = makerCode;
            goodsCndtn.GoodsNo = goodsNo;
            
            List<GoodsUnitData> goodsUnitDataList;
            string msg;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out msg);//DEL 2011/01/11 // ADD 2011/02/10
            //int status = this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out msg);//ADD 2011/01/11 // DEL 2011/02/10
            //---ADD 2011/02/10----------------------------------->>>>>
            if (status == 0 && goodsUnitDataList[0].OfferKubun >= 3)
            {
                    status = -1;
            }
            //---ADD 2011/02/10-----------------------------------<<<<<
            if (status != 0 ) 
            {
                control = this.tEdit_GoodsNo;
                //message = "マスタに登録されていません。";// DEL 2011/01/11
                message = "商品マスタに登録されていません。";// ADD 2011/01/11

                // 商品関連情報初期化
                ClearGoodsInfo();
                
                return (false);
            }

            // 棚卸実施日
            if (IsErrorTDateEdit(this.EnforcementDay_tDateEdit, out message) == false)
            {
                control = this.EnforcementDay_tDateEdit;
                return (false);
            }

            // 棚卸数
            if (this.tNedit_InventoryStockCnt.GetValue() == 0.00)
            {
                control = this.tNedit_InventoryStockCnt;
                message = "棚卸数を入力して下さい。";
                return (false);
            }

            // 棚卸日
            if (IsErrorTDateEdit(this.InventoryDay_tDateEdit, out message) == false)
            {
                control = this.InventoryDay_tDateEdit;
                return (false);
            }

            this._inventInputAcs.SearchAll(out this._inventoryDataUpdateWorkList, this._enterpriseCode, this._inventoryDataUpdateWorkBefore.InventoryDate);
            bool exist = this._inventoryDataUpdateWorkList.Exists(delegate(InventoryDataUpdateWork target)
            {
                if ((target.GoodsMakerCd == this.tNedit_GoodsMakerCd.GetInt()) &&
                    (target.GoodsNo.Trim() == this.tEdit_GoodsNo.DataText.Trim()) &&
                    (target.WarehouseCode.Trim().PadLeft(4, '0') == warehouseCode))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (exist)
            {
                control = this.tEdit_WarehouseCode;
                message = "棚卸データが重複してます。";
                return (false);
            }

            return (true);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面必須項目入力チェック
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        /// <remarks>
        /// <br>Note       : 必須入力チェックを行います</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks> 
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            //必須項目チェック
            //倉庫
            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
            {
                control = this.tEdit_WarehouseCode;
                message = this.Warehouse_Title.Text + "を入力して下さい。";
                result = false;
                return result;
            }
            //事業者
            //if (this.CarrierEpCode_tNedit.GetInt() == 0)
            //{
            //    control = this.CarrierEpCode_tNedit;
            //    message = this.CarrierEp_Title.Text + "を入力して下さい。";
            //    result = false;
            //    return result;
            //}
            //商品
            if (this.tEdit_GoodsNo.DataText.Trim() == "")
            {
                control = this.tEdit_GoodsNo;
                message = this.Goods_Title.Text + "を入力して下さい。";
                result = false;
                return result;
            }
            //仕入先
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                control = this.tNedit_SupplierCd;
                message = this.CustomerCode_Title.Text + "を入力して下さい。";
                result = false;
                return result;
            }

            //委託先
            //委託在庫の時
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (this.StockExtraDiv_ultraOptionSet.CheckedIndex == 2 || this.StockExtraDiv_ultraOptionSet.CheckedIndex == 3)
            //{
            //    //委託先(必須じゃない気がする)
            //    if (this.ShipCustomerCode_tNedit.GetInt() == 0)
            //    {
            //        control = this.ShipCustomerCode_tNedit;
            //        message = this.ShipCustomer_Title.Text + "を入力して下さい。";
            //        result = false;
            //        return result;
            //    }
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //在庫棚卸数
            if (this.tNedit_InventoryStockCnt.GetValue() == 0.00)
            {
                control = this.tNedit_InventoryStockCnt;
                message = this.InventoryStockCnt_Title.Text + "を入力して下さい。";
                result = false;
                return result;
            }

            //日付の妥当性チェック
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////仕入日
            //result = IsErrorTDateEdit(this.StockDate_tDateEdit,true);
            //if(result == false)
            //{
            //    control = this.StockDate_tDateEdit;
            //    message = "日付の入力に誤りがあります。";
            //    return result;
            //}
            ////入荷日
            //result = IsErrorTDateEdit(this.ArrivalGoodsDay_tDateEdit,true);
            //if(result == false)
            //{
            //    control = this.ArrivalGoodsDay_tDateEdit;
            //    message = "日付の入力に誤りがあります。";
            //    return result;
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //棚卸日
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //result = IsErrorTDateEdit(this.InventoryDay_tDateEdit, true);
            result = IsErrorTDateEdit(this.InventoryDay_tDateEdit, false);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            if (result == false)
            {
                control = this.InventoryDay_tDateEdit;
                message = "日付の入力に誤りがあります。";
                return result;
            }

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            //棚卸実施日
            result = IsErrorTDateEdit(this.EnforcementDay_tDateEdit, false);
            if (result == false)
            {
                control = this.EnforcementDay_tDateEdit;
                message = "日付の入力に誤りがあります。";
                return result;
            }
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            return result;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region 日付入力チェック処理

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="canEmpty">未入力フラグ(true:未入力可,false:未入力不可)</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool canEmpty)
        {
            if (tDateEdit.CheckInputData() != null) return false;

            // 日付を数値型で取得
            int date = tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 未入力フラグチェック
            if (canEmpty)
            {
                // 未入力可で未入力の場合は正常
                if (date == 0) return true;
            }

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if ((yy > 0) && (yy < 1900)) return false;

            // 年・月・日別入力チェック
            switch (tDateEdit.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    {
                        if (yy == 0 || mm == 0 || dd == 0) return false;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date);
                        if (TDateTime.IsAvailableDate(dt) == false) return false;
                        break;
                    }
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    {
                        if (yy == 0 || mm == 0) return false;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date / 100 * 100 + 1);
                        if (TDateTime.IsAvailableDate(dt) == false) return false;
                        break;
                    }
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    {
                        if (yy == 0) return false;
                        // 単純日付妥当性チェック
                        DateTime dt = TDateTime.LongDateToDateTime(date / 10000 * 10000 + 101);
                        break;
                    }
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    {
                        if (mm == 0 || dd == 0) return false;
                        break;
                    }
                // 月        表示時
                case emDateFormat.df2M:
                    {
                        if (mm == 0) return false;
                        break;
                    }
                // 日        表示時
                case emDateFormat.df2D:
                    {
                        if (dd == 0) return false;
                        break;
                    }
            }

            return true;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if ((year == 0) || (month == 0) || (day == 0))
            {
                errMsg = "日付を指定してください。";
                return (false);
            }

            if (year < 1900)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            return (true);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region 商品関連情報クリア処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品関連情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品に紐付くコード、名称をクリアします</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void ClearGoodsInfo()
        {
            //商品に紐付くコード、名称をクリア
            this.tEdit_GoodsName.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierName.Clear();
            this.tNedit_GoodsLGroup.Clear();
            this.tEdit_GoodsLGroupName.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tEdit_GoodsMGroupName.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_BLGroupName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            this.tNedit_EnterpriseGanreCode.Clear();
            this.tEdit_Jan.Clear();
            this.tEdit_SupplierName1.Clear();
            this.tEdit_SupplierName2.Clear();
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品関連情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品に紐付くコード、名称をクリアします</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.23</br>
        /// </remarks>
        private void GoodsInfoClear()
        {
            //商品に紐付くコード、名称をクリア
            this.tEdit_GoodsNo.Clear();
            this.tEdit_GoodsName.Clear();
            this.MakerCode_tNedit.Clear();
            this.tEdit_MakerName.Clear();
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //this.CarrierCode_tNedit.Clear();
            //this.CarrierName_tEdit.Clear();
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            this.LgGoodsCode_tEdit.Clear();
            this.LargeGoodsGanreName_tEdit.Clear();
            this.MdGoodsCode_tEdit.Clear();
            this.MediumGoodsGanreName_tEdit.Clear();
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this.CellphonModelCode_tEdit.Clear();
            //this.CellphonModelName_tEdit.Clear();
            //this.SystematicColorCode_tNedit.Clear();
            //this.SystematicColorName_tEdit.Clear();
            this.DtGoodsGanreCode_tEdit.Clear();
            this.tEdit_BLGroupName.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            this.tNedit_EnterpriseGanreCode.Clear();
            this.EnterpriseGanreName_tEdit.Clear();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            this.tEdit_Jan.Clear();
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //this.PrdNumMngDiv_tNedit.Clear();
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #endregion

        #region Event

        #region FormLoad

        /// <summary>
        /// Form.Load イベント (MAZAI05130UDA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが初めて表示される直前に発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void MAZAI05130UDA_Load(object sender, EventArgs e)
        {
			// 画面イメージ統一
            //this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            //this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更
            /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
            //タイマーON
            this.Initial_Timer.Enabled = true;
               --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
            // フォーカス設定
            this.tEdit_WarehouseCode.Focus();
            // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        }

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region Initial_Timer_Tick
        /// <summary>
        /// Initial_Timer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 指定された時間の間隔が経過した時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks> 
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            //タイマーOFF
            this.Initial_Timer.Enabled = false;

			#region // 2007.07.31 kubo del
			//// 画面初期設定処理
			//ScreenInitialSetting();
			#endregion
		}

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ガイド呼び出しイベント

        #region 倉庫ガイド

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>UpdateNote : 2012/06/11 凌小青</br>
        /// <br>             Redmine#30238</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;

            int status = this._warehouseGuideAcs.ExecuteGuid(out warehouseData,this._enterpriseCode,this._loginSectionCode);
            if(status == 0)
            {
                if(warehouseData != null)
                {
                    //コード、名称を展開                                    
                    this.tEdit_WarehouseCode.DataText = warehouseData.WarehouseCode.TrimEnd();
                    this.tEdit_WarehouseName.DataText = warehouseData.WarehouseName.TrimEnd();

                    //-----ADD BY 凌小青 on 2012/06/11 for Redmine#30238 ------>>>>>>
                    GoodsUnitData goodsUnitData;
                    string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
                    int  makerCode = this.tNedit_GoodsMakerCd.GetInt();
                    status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
                    if (status == 0)
                    {
                        // 商品連結データ画面展開
                        SetGoodsUnitForScreen(goodsUnitData);
                    }
                    else
                    {
                        // 商品関連情報初期化
                        ClearGoodsInfo();
                    }
                    //-----ADD BY 凌小青 on 2012/06/11 for Redmine#30238 ------<<<<<<
                    // フォーカス設定
                    this.tEdit_GoodsNo.Focus();
                }
            }
        }

        #endregion

        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region 事業者ガイド
        ///// <summary>
        ///// 事業者ガイドボタンクリックイベント 
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 事業者ガイドボタンがクリックされると発生します。</br>
        ///// <br>Programmer : 23001 中村　仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>    
        //private void CarrierEpGuide_Button_Click(object sender, EventArgs e)
        //{
        //	if ( this._carrierEpAcs == null ) this._carrierEpAcs = new CarrierEpAcs();
        //
        //	CarrierEp carrierEp = null;
        //
        //	int status = this._carrierEpAcs.ExecuteGuid( this._enterpriseCode, out carrierEp );
        //
        //    switch(status)
        //    {
        //        //取得
        //        case 0:
        //        {                  
        //            if(carrierEp != null)
        //            {
        //				this.CarrierEpCode_tNedit.SetInt( carrierEp.CarrierEpCode );
        //				this.CarrierEpName_tEdit.DataText = carrierEp.CarrierEpName.TrimEnd();
        //            }
        //            break;
        //        }
        //        //キャンセル
        //        case 1:
        //        {                  
        //            break;
        //        }
        //    }      
        //}
        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region 商品ガイド

        /// <summary>
        /// 商品ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void GoodsGuide_Button_Click(object sender, EventArgs e)
        {
            GoodsUnitData goodsUnitData = null;

            DialogResult ret = this._goodsGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

            if (ret == DialogResult.OK)
            {
                if (goodsUnitData != null)
                {
                    //商品ガイドから得た情報を画面に展開
                    SetGoodsUnitForScreen(goodsUnitData);
                }
            }
        }

        #endregion

        #region 仕入先ガイド

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
        }

        #endregion

        #region 委託先ガイド

        /// <summary>
        /// 委託先ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void ShipCustomerGuide_Button_Click(object sender, EventArgs e)
        {
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ShipCustomerSelect);
			customerSearchForm.ShowDialog(this);
        }        

        #endregion    

        #region ◎ 数値入力チェック処理
        /// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note       : 数値入力チェック処理。</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks>
		public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key) == true)
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (Char.IsNumber(key) == false)
			{
				return false;
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string	_strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart) 
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));

			// 入力値チェック
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //if (this._prdNumMngDiv == 1 && this._grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product)
            //{
			//	// 製番管理ありで製番毎データの場合は入力は1か0のみ
			//	if ( ( key != '1' ) && ( key != '0' ) )
			//	{
			//		return false;
			//	}
			//	keta = 1;
			//}
			//else
			//{
            //    // 製番管理無し or 製番未入力なら入力制限無し
			//	keta = 9;
			//}
            // 製番管理無し or 製番未入力なら入力制限無し
            keta = 9;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int	_Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region TEdit Leaveイベント
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// WarehouseCode_tEdit_Leave
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫コードエディットがアクティブでなくなった時に発生します</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void WarehouseCode_tEdit_Leave(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            //倉庫の場合
            if(tEdit.Equals(this.tEdit_WarehouseCode))
            {
                // コード参照
			    if( this.tEdit_WarehouseCode.DataText.TrimEnd() == "" ) 
                {
                    //未入力
				    this.tEdit_WarehouseCode.Clear();
                    this.tEdit_WarehouseName.Clear();
			    }
			    else 
                {
				    if( this._changFlagWarehouse == true )
                    {
					    this._changFlagWarehouse = false;
					    //倉庫情報取得処理
                        GetWarehouseInfo(this.tEdit_WarehouseCode.DataText.TrimEnd());
				    }
			    }
            }

            //商品の場合
            if(tEdit.Equals(this.tEdit_GoodsNo))
            {
                // コード参照
			    if( this.tEdit_GoodsNo.DataText.TrimEnd() == "" ) 
                {
                    //未入力
                    //商品情報クリア
				    GoodsInfoClear();
			    }
			    else 
                {
				    if( this._changFlagGoods == true )
                    {
					    this._changFlagGoods = false;
					    //商品情報取得処理
                        GetGoodsInfo(this.tEdit_GoodsNo.DataText.TrimEnd());
				    }
			    }
            }

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////製造番号の場合
            //if(tEdit.Equals(this.tEdit_WarehouseShelfNo))
            //{
            //    //製造番号、商品電話番号１、２がどれも入力されていない
            //    if(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == "")
            //    {
            //        //棚卸在庫数のEnableをTrueに
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //製造番号が入力されている
            //        //棚卸在庫数のEnableをfalseに
            //        this.tNedit_InventoryStockCnt.Enabled = false;
            //        //棚卸在庫数を1に変更
            //        this.tNedit_InventoryStockCnt.SetInt(1);
            //    }
            //}
            //
            ////商品電話番号１の場合
            //if(tEdit.Equals(this.tEdit_DuplicationShelfNo1))
            //{
            //    //製造番号、商品電話番号１、２がどれも入力されていない
            //    if(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == "")
            //    {
            //        //製造番号が入力されていない
            //        //棚卸在庫数のEnableをTrueに
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //製造番号が入力されている
            //        //棚卸在庫数のEnableをfalseに
            //        this.tNedit_InventoryStockCnt.Enabled = false;
            //        //棚卸在庫数を1に変更
            //        this.tNedit_InventoryStockCnt.SetInt(1);
            //    }
            //}
            ////商品電話番号２の場合
            //if(tEdit.Equals(this.tEdit_DuplicationShelfNo2))
            //{
            //    //製造番号、商品電話番号１、２がどれも入力されていない
            //    if(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == "")
            //    {
            //        //製造番号が入力されていない
            //        //棚卸在庫数のEnableをTrueに
            //        this.tNedit_InventoryStockCnt.Enabled = true;
            //    }
            //    else
            //    {
            //        //製造番号が入力されている
            //        //棚卸在庫数のEnableをfalseに
            //        this.tNedit_InventoryStockCnt.Enabled = false;
            //        //棚卸在庫数を1に変更
            //        this.tNedit_InventoryStockCnt.SetInt(1);
            //    }
            //}
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        }     

        #endregion

        #region TEdit Enterイベント

        /// <summary>
        /// tEdit_WarehouseCode.Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 倉庫コードエディットにフォーカスが移ったときに発生します。</br>
        /// <br>Programmer  : 23010 中村　仁</br>
        /// <br>Date        : 2007.04.19</br>
        /// </remarks>
        private void WarehouseCode_tEdit_Enter(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            //倉庫
            if(tEdit.Equals(this.tEdit_WarehouseCode))
            {
                //コード参照用フラグ
                this._changFlagWarehouse = false;
            } 
            //商品の場合
            if(tEdit.Equals(this.tEdit_GoodsNo))
            {
                //コード参照用フラグ
                this._changFlagGoods = false;
            } 
        }

        #endregion

        #region TEdit ValueChangedイベント
        /// <summary>
        /// tEdit_WarehouseCode.ValueChanged イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールのテキストが変更されたときに発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.06.06</br>
        /// </remarks>
        private void WarehouseCode_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            //倉庫
            if(tEdit.Equals(this.tEdit_WarehouseCode))
            {
                //ユーザーの手により変更された
                if (this.tEdit_WarehouseCode.Modified == true)
                {
                    this._changFlagWarehouse = true;
                }
            }
            //商品
            if(tEdit.Equals(this.tEdit_GoodsNo))
            {
                //ユーザーの手により変更された
                if (this.tEdit_GoodsNo.Modified == true)
                {
                    this._changFlagGoods = true;
                }
            }
        }

        #endregion

        #region TNedit Leaveイベント

        /// <summary>
        /// CarrierEpCode_tNedit_Leave
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 事業者コードエディットがアクティブでなくなった時に発生します</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>    
        private void CarrierEpCode_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者の場合
            //if(tNedit.Equals(this.CarrierEpCode_tNedit))
            //{
            //    // コード参照
            //    if( this.CarrierEpCode_tNedit.GetInt() == 0) 
            //    {
            //        //未入力
            //        this.CarrierEpCode_tNedit.Clear();
            //        this.CarrierEpName_tEdit.Clear();
            //    }
            //    else 
            //    {
            //        if( this._changeFlagCarrierEp == true )
            //        {
            //            this._changeFlagCarrierEp = false;
            //            //事業者情報取得処理
            //            GetCarrierEpInfo(this.CarrierEpCode_tNedit.GetInt());
            //        }
            //    }
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //得意先(仕入先)の場合
            if(tNedit.Equals(this.tNedit_SupplierCd))
            {            
                if(this.tNedit_SupplierCd.GetInt() == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                    this.tEdit_SupplierName.Clear();
                    this.CustomerName2_tEdit.Clear();
                }
                else
                {
                    if(this._changFlagCustomer == true)
                    {
                        this._changFlagCustomer = false;
                        //得意先(仕入先)情報取得処理
                        GetCustomerInfo(this.tNedit_SupplierCd.GetInt());
                    }
                }
            }

            //出荷先得意先(委託先)の場合
            if(tNedit.Equals(this.ShipCustomerCode_tNedit))
            {            
                if(this.ShipCustomerCode_tNedit.GetInt() == 0)
                {
                    this.ShipCustomerCode_tNedit.Clear();
                    this.ShipCustomerName1_tEdit.Clear();
                    this.ShipCustomerName2_tEdit.Clear();
                }
                else
                {
                    if(this._changFlagShipCustomer == true)
                    {
                        this._changFlagShipCustomer = false;
                        //得意先(仕入先)情報取得処理
                        GetShipCustomerInfo(this.ShipCustomerCode_tNedit.GetInt());
                    }
                }               
            }

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////棚卸数の場合
            //if(tNedit.Equals(this.tNedit_InventoryStockCnt))
            //{
            //    if(this.tNedit_InventoryStockCnt.GetInt() > 1)
            //    {
            //        //製番と電話番号をクリア
            //        this.tEdit_WarehouseShelfNo.Clear();
            //        this.tEdit_DuplicationShelfNo1.Clear();
            //        this.tEdit_DuplicationShelfNo2.Clear();
            //    }
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        }

        #endregion

        #region TNedit Enterイベント
        /// <summary>
        /// CarrierEpCode_tNedit Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 事業者エディットにフォーカスが移ったときに発生します。</br>
        /// <br>Programmer  : 23010 中村　仁</br>
        /// <br>Date        : 2007.04.19</br>
        /// </remarks>
        private void CarrierEpCode_tNedit_Enter(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者
            //if(tNedit.Equals(this.CarrierEpCode_tNedit))
            //{            
            //    this._changeFlagCarrierEp = false;               
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //得意先(仕入先)の場合
            if(tNedit.Equals(this.tNedit_SupplierCd))
            {            
                this._changFlagCustomer = false;               
            }
            //出荷先得意先(委託先)の場合
            if(tNedit.Equals(this.ShipCustomerCode_tNedit))
            {            
                this._changFlagShipCustomer = false;               
            }
        }
       
        #endregion    

        #region TNedit ValueChangedイベント
        /// <summary>
        /// CarrierEpCode_tNedit_ValueChanged イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールのテキストが変更されたときに発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        private void CarrierEpCode_tNedit_ValueChanged(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////事業者
            //if(tNedit.Equals(this.CarrierEpCode_tNedit))
            //{
            //    //ユーザーの手により変更された
            //    if (this.CarrierEpCode_tNedit.Modified == true)
            //    {
            //        this._changeFlagCarrierEp = true;
            //    }
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //得意先(仕入先)の場合
            if(tNedit.Equals(this.tNedit_SupplierCd))
            {           
                //ユーザーの手により変更された
                if (this.tNedit_SupplierCd.Modified == true)
                {
                    this._changFlagCustomer = true;
                }                         
            }
            //出荷先得意先(委託先)の場合
            if(tNedit.Equals(this.ShipCustomerCode_tNedit))
            {            
                //ユーザーの手により変更された
                if (this.ShipCustomerCode_tNedit.Modified == true)
                {
                    this._changFlagShipCustomer = true;
                }                                          
            }
        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region Main_ToolbarsManager_ToolClickイベント
        /// <summary>
        /// Main_ToolbarsManager_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Main_ToolbarsManagerのToolがクリックされた時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
        /// <br>             障害報告 #18764</br>
        /// </remarks> 
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
			{
                //確定
				case "ctSAVE_BUTTONTOOLKEY":
				{	
					Control activeControl = this.ActiveControl;

					this.ActiveControl = null;

	                //画面入力チェック
				    Control control = null;
                    string message = null;
                    
                    if (!ScreenDataCheck(ref control, ref message))
                    {
                        //メッセージ
                        TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        CT_CLASSID, 						// アセンブリＩＤまたはクラスＩＤ
                        message, 							// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                      
                        control.Focus();
                        return;
                    }

					// --- DEL 2011/02/17 ---------->>>>>
					////---ADD 2011/01/11-------------------------------------------->>>>>
					//GoodsUnitData goodsUnitData;
					//string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
					//int makerCode = 0;
					//int status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
					//if (status != 0)
					//{
					//    GoodsNoFlag = -1;
					//    //メッセージ
					//    TMsgDisp.Show(
					//    this, 								// 親ウィンドウフォーム
					//    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					//    CT_CLASSID, 						// アセンブリＩＤまたはクラスＩＤ
					//    "商品マスタに登録されていません。", 							// 表示するメッセージ
					//    0, 									// ステータス値
					//    MessageBoxButtons.OK);				// 表示するボタン

					//    // 商品関連情報初期化
					//    ClearGoodsInfo();
					//    return;
					//}
					////---ADD 2011/01/30-------------------------------------------->>>>>
					//switch (goodsUnitData.OfferKubun)
					//{
					//    case 0: // ユーザー登録
					//    case 1: // 提供純正編集
					//    case 2: // 提供優良編集
					//        if (goodsUnitData.LogicalDeleteCode == 0)
					//        {
					//            if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
					//            {
					//                if (goodsUnitData.GoodsPriceList.Count > 0)
					//                {
					//                    GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(this.EnforcementDay_tDateEdit.GetDateTime(), goodsUnitData.GoodsPriceList);
					//                    if (goodsPrice != null)
					//                    {
					//                        this.ListPrice = goodsPrice.ListPrice;
					//                    }
					//                }
					//            }
					//        }
					//        break;
					//    default:
					//        break;
					//}
					////---ADD 2011/01/30--------------------------------------------<<<<<
					////---ADD 2011/01/11--------------------------------------------<<<<<
					// --- DEL 2011/02/17 ----------<<<<<

                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    ////棚卸在庫数が1以上で、製番or携帯番号を入れたままマウスで確定を押されると
                    ////同じ製番の商品ができてしまう。Leaveが上手く走らない。
                    ////よってチェックを入れる
                    //if(this.tNedit_InventoryStockCnt.GetInt() > 1)
                    //{
                    //    //製造番号、商品電話番号１、２がどれか一つでも入っている場合
                    //    if(!(this.tEdit_WarehouseShelfNo.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo1.DataText.TrimEnd() == "" && this.tEdit_DuplicationShelfNo2.DataText.TrimEnd() == ""))
                    //    {
                    //        //棚卸数を1にする
                    //        this.tNedit_InventoryStockCnt.SetInt(1);
                    //    }                     
                    //}
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>

                    //画面条件格納処理
                    SetInventResultWorkFromScreen();
					
					this.ActiveControl = activeControl;

					this.DialogResult = DialogResult.OK;

					break;
				}
                //終了
				case "ctCLOSE_BUTTONTOOLKEY":
					{
						this.DialogResult = DialogResult.Cancel;						
						break;
					}			
			}

        }

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region StockExtraDiv_ultraOptionSet_ValueChangedイベント
        /// <summary>
        /// StockExtraDiv_ultraOptionSet_ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : StockExtraDiv_ultraOptionSetの値が変化した時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks> 
        private void StockExtraDiv_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        {
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////在庫区分が委託になる時は委託先のEditを必須入力色に変える
            //if(this.StockExtraDiv_ultraOptionSet.CheckedIndex == 2 || this.StockExtraDiv_ultraOptionSet.CheckedIndex == 3)
            //{
            //    this.ShipCustomerCode_tNedit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            //}
            //else
            //{
            //    this.ShipCustomerCode_tNedit.Appearance.BackColor = Color.White;
            //}
            //
            ////受託在庫の場合は仕入単価の項目を入力不可
            //if(this.StockExtraDiv_ultraOptionSet.CheckedIndex == 1 || this.StockExtraDiv_ultraOptionSet.CheckedIndex == 3)
            //{
            //    this.tNedit_StockUnitPrice.Clear();
            //    this.tNedit_StockUnitPrice.Enabled = false;
            //}
            //else
            //{
            //    this.tNedit_StockUnitPrice.Enabled = true;
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        }

        #endregion

        #region InventoryStockCnt_tNedit_KeyPressイベント
		/// <summary>
		/// InventoryStockCnt_tNedit_KeyPress
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : InventoryStockCnt_tNeditがフォーカスをもっていて、ユーザーがキーを押して話したときに発生する</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks> 
		private void InventoryStockCnt_tNedit_KeyPress ( object sender, KeyPressEventArgs e )
		{
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (this._prdNumMngDiv == 0)
			//	return;
			//if ( this._dispMode == (int)DispModeState.EditNew )
			//{
			//	string prevVal = tNedit_InventoryStockCnt.DataText.TrimEnd();
			//	int selStart = tNedit_InventoryStockCnt.SelectionStart;
			//	int selLength = tNedit_InventoryStockCnt.SelectionLength;
            //
			//	if (KeyPressCheck( 0, 0, prevVal, e.KeyChar, selStart, selLength, false ) == false)
			//	{
			//		e.Handled = true;
			//		return;
			//	}
			//}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品連結データ取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
        /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
        /// <br>             障害報告 #18869</br>
        /// </remarks> 
        private int GetGoodsUnitData(out GoodsUnitData goodsUnitData, int makerCode, string goodsNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            goodsUnitData = new GoodsUnitData();

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = makerCode;
            goodsCndtn.GoodsNo = goodsNo;

            List<GoodsUnitData> goodsUnitDataList;

            string errMsg;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);//DEL 2011/01/11 // ADD 2011/02/10
                //status = this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);//ADD 2011/01/11 // DEL 2011/02/10
                //---ADD 2011/02/10----------------------------------->>>>>
                if (status == 0 && goodsUnitDataList[0].OfferKubun >= 3)
                {
                    status = -1;
                }
                //---ADD 2011/02/10-----------------------------------<<<<<
                if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    goodsUnitData = goodsUnitDataList[0];
                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);         
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    goodsUnitData = new GoodsUnitData();
                }
            }
            catch
            {
                goodsUnitData = new GoodsUnitData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカスが変わったときに発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             商品マスタに存在しないデータも新規登録出来る不具合修正</br>
        /// </remarks> 
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tEdit_WarehouseCode":
                        {
                            if (this.tEdit_WarehouseCode.DataText.Trim() == "")
                            {
                                this.tEdit_WarehouseName.Clear();
                                // ---ADD 2009/05/14 不具合対応[13260] --------------------------------->>>>>
                                //拠点
                                this.tEdit_SectionCode.DataText = string.Empty;
                                this.tEdit_SectionName.DataText = string.Empty;
                                //仕入先
                                this.tNedit_SupplierCd.SetInt(0);
                                this.tEdit_SupplierName.DataText = string.Empty;
                                this.beforeWarehouseCode = this.tEdit_WarehouseCode.DataText;
                                // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------<<<<<
                                return;
                            }

                            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------->>>>>
                            if (this.tEdit_WarehouseCode.DataText == this.beforeWarehouseCode)
                            {
                                return;
                            }
                            this.beforeWarehouseCode = this.tEdit_WarehouseCode.DataText;
                            // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------<<<<<

                            string warehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');

                            // 倉庫名称取得
                            this.tEdit_WarehouseName.DataText = this._inventInputAcs.GetWarehouseName(warehouseCode);

                            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------->>>>>
                            GoodsUnitData goodsUnitData;
                            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
                            int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                            int status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
                            if (status == 0)
                            {
                                // 商品連結データ画面展開
                                SetGoodsUnitForScreen(goodsUnitData);
                            }
                            else
                            {
                                // 商品関連情報初期化
                                ClearGoodsInfo();
                            }
                            // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------<<<<<

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    // フォーカス設定
                                    if (this.tEdit_WarehouseName.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                }
                            }

                            break;
                        }
                    case "tEdit_GoodsNo":
                        {
                            if (this.tEdit_GoodsNo.DataText.Trim() == "")
                            {
                                // 商品関連情報初期化
                                ClearGoodsInfo();
                                this.beforeGoodsNo = this.tEdit_GoodsNo.DataText;       //ADD 2009/05/14 不具合対応[13260]
                                return;
                            }

                            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------->>>>>
                            //if (this.tEdit_GoodsNo.DataText == this.beforeGoodsNo) // DEL 2011/01/11
                            if (this.tEdit_GoodsNo.DataText == this.beforeGoodsNo && GoodsNoFlag == 0) // ADD 2011/01/11
                            {
                                return;
                            }
                            this.beforeGoodsNo = this.tEdit_GoodsNo.DataText;
                            // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------<<<<<

                            GoodsUnitData goodsUnitData;
                            string goodsNo = this.tEdit_GoodsNo.DataText.Trim();
                            //int makerCode = this.tNedit_GoodsMakerCd.GetInt();        //DEL 2009/05/14 不具合対応[13260]
                            int makerCode = 0;

                            int status = GetGoodsUnitData(out goodsUnitData, makerCode, goodsNo);
                            if (status == 0)
                            {
                                // 商品連結データ画面展開
                                SetGoodsUnitForScreen(goodsUnitData);
                            }
                            else
                            {
                                
                                //---ADD 2011/01/11-------------------------------------------->>>>>
                                if (e.NextCtrl is Infragistics.Win.Misc.UltraButton || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TDateEdit)
                                {
                                    GoodsNoFlag = -1;
                                    //メッセージ
                                    TMsgDisp.Show(
                                    this, 								// 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                    CT_CLASSID, 						// アセンブリＩＤまたはクラスＩＤ
                                    "商品マスタに登録されていません。", 							// 表示するメッセージ
                                    0, 									// ステータス値
                                    MessageBoxButtons.OK);				// 表示するボタン
                                    e.NextCtrl = tEdit_GoodsNo;
                                    //---ADD 2011/01/11--------------------------------------------<<<<<
                                    // 商品関連情報初期化
                                    ClearGoodsInfo();
                                } // ADD 2011/01/11
                                return;
                            }

							//---ADD 2011/02/17-------------------------------------------->>>>>
							switch (goodsUnitData.OfferKubun)
							{
								case 0: // ユーザー登録
								case 1: // 提供純正編集
								case 2: // 提供優良編集
									if (goodsUnitData.LogicalDeleteCode == 0)
									{
										if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
										{
											if (goodsUnitData.GoodsPriceList.Count > 0)
											{
												GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(this.EnforcementDay_tDateEdit.GetDateTime(), goodsUnitData.GoodsPriceList);
												if (goodsPrice != null)
												{
													this.ListPrice = goodsPrice.ListPrice;
												}
											}
										}
									}
									break;
								default:
									break;
							}
							//---ADD 2011/02/17--------------------------------------------<<<<<

                            break;
                        }
                    default:
                        break;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo.Text.Length - (this.tEdit_WarehouseShelfNo.SelectionStart + this.tEdit_WarehouseShelfNo.SelectionLength)); // 選択後の部分

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
        /// tEdit_DuplicationShelfNo1_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_DuplicationShelfNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo1.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo1.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo1.Text.Length - (this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength)); // 選択後の部分

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
        /// tEdit_DuplicationShelfNo2_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_DuplicationShelfNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo2.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo2.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo2.Text.Length - (this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength)); // 選択後の部分

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
        #endregion
    }
}