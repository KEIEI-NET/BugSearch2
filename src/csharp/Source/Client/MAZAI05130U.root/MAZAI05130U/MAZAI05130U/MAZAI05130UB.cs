//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸数入力 抽出結果入力画面クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 作 成 日  2007/04/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/19  修正内容 : 抽出、一括設定、保存時の速度向上
//                                  GridのUpdateDataメソッドを使用しないように変更
//                                  テーブルのプライマリキーを変更下のに伴い、親データの検索はFindメソッドを用いて行うよう変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/24  修正内容 : 製番管理データの製番無グロス行を作成しないよう変更
//                                  削除機能追加（新規行のみ削除可能)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/25  修正内容 : 編集機能追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/26  修正内容 : 製番入力機能 追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/30  修正内容 : 全てのDataViewのフィルタ条件に「論理削除区分=0」を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/09/11  修正内容 : DC.NS対応
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
// 修 正 日  2009/04/21  修正内容 : 不具合対応[13075]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/11  修正内容 : MANTIS対応[13915]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/03  修正内容 : PM.NS　保守対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/01/30  修正内容 : 障害報告 #18764
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/02/10  修正内容 : 障害報告 #18870
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/04/07  修正内容 : Mantis.17206 帳簿数ゼロの在庫に対して棚卸数ゼロを入力すると保存時に警告メッセージが表示される
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 作 成 日  2012/10/29  修正内容 : 2012/11/14配信分 #32868 No.1198 棚卸表 棚卸入力/表示順が違う
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当 : yangyi
// 修 正 日  2013/03/01     修正内容 : 20130326配信分の対応、Redmine#34175
//                                     棚卸業務のサーバー負荷軽減
//----------------------------------------------------------------------------//
// 管理番号  1002677-00     作成担当 : xuyb
// 修 正 日  2014/10/31     修正内容 : 仕掛№2133 Redmine#40336
//                                     障害現象② 原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる
//                                     障害現象③ 棚番を変更すると次行以降の入力分が更新されない障害修正
//                                    「障害現象②」の修正で「障害現象③」の障害も解消できる
//----------------------------------------------------------------------------//
// 管理番号  1002677-00     作成担当 : 脇田 靖之
// 修 正 日  2014/12/04     修正内容 : 仕掛№2133 Redmine#40336 システムテスト障害No.154
//                                     更新エラー発生後に該当行の文字の色を変更するように修正
//----------------------------------------------------------------------------//
// 管理番号  11070149-00     作成担当 : 陳嘯
// 修 正 日  2015/04/27     修正内容 : Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
//                                  　　Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する
//----------------------------------------------------------------------------//
// 棚卸データの構造
// - 製番管理 しない　
//		- グロスデータ(常に表示 棚卸数入力可 棚卸数が変更されたら製番単位データに反映)
//		- 製番単位データ(常に非表示 棚卸マスタに入っている単位 棚卸数は親から反映されることで変更)
// - 製番管理 する
//		- グロスデータ(表示方法:商品毎のとき表示 棚卸数入力可 棚卸数が変更されたら製番単位データに反映)
//		- 製番単位データ(表示方法:製番毎のとき表示 棚卸数入力可 変更されたらグロスデータに反映)
#region // 2007.07.24 kubo del ( データ表示の仕様変更に伴い、製番単位データは常に全て表示 )
//		- 製番単位データ
//			- 製番入力済みデータ(表示方法:製番毎のとき表示 棚卸数入力可 変更されたらグロスデータに反映)
////			- 製番未入力データ
////				- グロスデータ(表示方法:製番毎のとき表示 棚卸数入力可 変更されたら親データと製番未入力 製番単位データに反映)
////				- 製版単位データ(常に非表示 棚卸マスタに入っている単位 棚卸数は親から反映されることで変更)
#endregion

using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using System.Globalization;  //ADD 2012/10/29 yangyi redmine #32868 

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸数入力 抽出結果入力画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸数入力 抽出結果入力画面クラス</br>
	/// <br>Programmer : 22013 kubo</br>
	/// <br>Date       : 2007.04.11</br>
	/// <br>Update Note: 2007.07.19 2007.07.20 22013 kubo</br>
	/// <br>			:	・抽出、一括設定、保存時の速度向上</br>
	/// <br>			:	　　GridのUpdateDataメソッドを使用しないように変更</br>
	/// <br>			:	　　テーブルのプライマリキーを変更下のに伴い、親データの検索はFindメソッドを用いて行うよう変更</br>
	/// <br>Update Note: 2007.07.24 22013 kubo</br>
	/// <br>			:	・製番管理データの製番無グロス行を作成しないよう変更</br>
	/// <br>			:	・削除機能追加（新規行のみ削除可能)</br>
	/// <br>Update Note: 2007.07.25 22013 kubo</br>
	/// <br>			:	・編集機能追加</br>
	/// <br>Update Note: 2007.07.26,27 22013 kubo</br>
	/// <br>			:	・製番入力機能 追加</br>
	/// <br>Update Note: 2007.07.30 22013 kubo</br>
	/// <br>			:	・全てのDataViewのフィルタ条件に「論理削除区分=0」を追加</br>
    /// <br>Update Note : 2007.09.11 980035 金沢 貞義</br>
    /// <br>			    ・DC.NS対応</br>
    /// <br>Update Note : 2008.02.14 980035 金沢 貞義</br>
    /// <br>			    ・棚卸実施日対応（DC.NS対応）</br>
    /// <br>Update Note : 2008/09/01 30414 忍 幸史</br>
    /// <br>			    ・Partsman用に変更</br>
    /// <br>Update Note : 2009/04/13 30452 上野 俊治</br>
    /// <br>			    ・障害対応13109</br>
    /// <br>Update Note : 2009/04/21       照田 貴志</br>
    /// <br>			    ・不具合対応[13075]</br>
    /// <br>Update Note : 2009/05/14       照田 貴志</br>
    /// <br>			    ・不具合対応[13260]</br>
    /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>UpdateNote  : 2011/02/10 鄧潘ハン</br>
    /// <br>                ・障害報告 #18870</br>
    /// </remarks>
	public partial class MAZAI05130UB : Form, IInventInputMdiChild
	{
		#region ■ Constructor
		/// <summary>
		/// 棚卸数入力 抽出結果入力画面クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸数入力 抽出結果入力画面クラスのインスタンスを作成</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public MAZAI05130UB ()
		{
			InitializeComponent();
			this._inventInputAcs = new InventInputAcs();		// 棚卸数入力アクセスクラス

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryMenuForm = new MAZAI05130UA();
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            // グリッド設定ロード
			this._gridStateController = new GridStateController();
			this._gridStateController.LoadGridState(ct_FileName_ColDisplayStatus);
		}
		#endregion ■ Constructor

		#region ■ Private Member
		// IInventInputMdiChild メンバ用 変数 ---------------------------------------
		private string _enterpriseCode				= "";					// 企業コード
		private string _sectionCode					= "";					// 拠点コード
		private string _sectionName					= "";					// 拠点名称
		private bool _isCansel						= true;					// 取消ボタンEnabled
		private bool _isSave						= true;					// 保存ボタンEnabled
		private bool _isExtract						= false;				// 抽出ボタンEnabled
		private bool _isNewInvent					= true;					// 新規ボタンEnabled
		private bool _isDetail						= true;					// 詳細ボタンEnabled
        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
        //private bool _isBarcodeRead               = true;					// バーコード読込ボタンEnabled
        private bool _isBarcodeRead                 = false;				// バーコード読込ボタンEnabled
        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
        // 2007.07.25 kubo add
		private bool _isDataEdit					= false;				// 編集ボタンEnabled
        private bool _isGoodsSearch = true;	　　　　　　　　// 品番検索ボタンEnabled (true:品番検索ボタンクリックができる　false:品番検索ボタンクリックができない)// ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する

		// Private 変数 ---------------------------------------
		private bool _isFirstsetting				= true;					// 初期処理中フラグ
		private InventInputAcs _inventInputAcs		= new InventInputAcs();	// 棚卸数入力アクセスクラス
		private bool _isEventAutoFillColumn			= true;					// 列サイズ調整イベント可能フラグ(T:可,F:不可)
		private bool _isChangeInventStcCnt			= false;				// 棚卸数変更フラグ
        private string _isDownKey = string.Empty;                           // 押下キー(キー押下あり："ANYKEY"、キー押下なし："")           //ADD 2009/05/14 不具合対応[13260]
                                                                            // ※後日、キー毎に判定する必要があった時の為にstringとしておく
		private bool _isChangeInventDate			= false;				// 日付変更フラグ
		//private MAZAI05130UC _productInvInputForm	= null;					// 製番毎棚卸数入力画面
        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
        private bool _isChangeWarehouseShelfNo      = false;				// 棚番変更フラグ
        private bool _isChangeDuplicationShelfNo1   = false;				// 重複棚番1変更フラグ
        private bool _isChangeDuplicationShelfNo2   = false;				// 重複棚番2変更フラグ
        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
        private bool _isChangeStockUnitPrice        = false;				// 原単価変更フラグ
        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
        private bool _addingKey = true;					                    // キーの追加フラグ   //ADD yangyi 2013/03/01 Redmine#34175 

        private MAZAI05140UA _readBarcodeForm = null;					    // バーコード読込画面
		private MAZAI05130UD _createNewInventForm	= null;					// 新規画面
        private MAZAI05130UE _goodsSearchForm = null;					    // 品番検索 // ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する
        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
        //private MAZAI05130UA _inventoryMenuForm = null;                     // 条件入力画面;
        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
	
		private GridStateController _gridStateController = null;			// グリッド設定制御クラス

		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 2007.07.19 kubo add 
		private DataView _inventInputView = null;							// 棚卸DataView

		// 2007.07.26 kubo add --------------->
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //private bool _isChangeInventProductNum = false;				// 製造番号変更フラグ
		//private bool _isChangeInventStockTelNo1		= false;				// 電話番号1変更フラグ
		//private bool _isChangeInventStockTelNo2		= false;				// 電話番号2変更フラグ
		//private string _BfoerStockTelNo1			= "";					// 変更前電話番号1
		//private string _BfoerStockTelNo2			= "";					// 変更前電話番号2
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

		private ProductNumInput _productNumInput	= null;

		private ArrayList _defProdNumList = new ArrayList();

        private InventInputSearchCndtn _extrInfo;

		private string _strNowSort = "";
		// 2007.07.26 kubo add <---------------
		#endregion ■ Private Member

		#region ■ Private Const
		/// <summary> 列表示状態セッティングXMLファイル名 </summary>
		private const string ct_FileName_ColDisplayStatus =  "MAZAI05120U_ColSetting.DAT";

		/// <summary> 棚卸数一括入力コンテナ </summary>
		private const string ct_tool_InventoryAllInput = "tool_InventAllInput";

		/// <summary> 棚卸実施日コンテナ </summary>
		private const string ct_tool_InventoryDate = "tool_InventoryDate";

        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
		/// <summary> 棚卸日コンテナ </summary>
		private const string ct_tool_InventoryExeDate = "tool_InventoryExeDate";
        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

        /// <summary> 表示方法ツールコンテナ </summary>
		private const string ct_tool_ViewStyleContainer = "tool_ViewStyleContainer";

		/// <summary> ソート順ツールコンテナ </summary>
		private const string ct_tool_SortOrderContainer = "tool_SortOrderContainer";

		// 2007.07.24 kubo add
		/// <summary> ソート順ツールコンテナ </summary>
		private const string ct_tool_RowDelete = "tool_RowDelete";

        #region DEL 2009/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		// 列表示切替用ツール
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 電話番号1 </summary>
		//private const string ct_tool_Hidden_TEL1 = InventInputResult.ct_Col_StockTelNo1;
		///// <summary> 電話番号2 </summary>
		//private const string ct_tool_Hidden_TEL2 = InventInputResult.ct_Col_StockTelNo2;
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary> 倉庫 </summary>
		private const string ct_tool_Hidden_Warehouse = InventInputResult.ct_Col_WarehouseName;
        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
		private const string ct_tool_Hidden_WarehouseShelfNo = InventInputResult.ct_Col_WarehouseShelfNo;
		private const string ct_tool_Hidden_DuplicationShelfNo1 = InventInputResult.ct_Col_DuplicationShelfNo1;
		private const string ct_tool_Hidden_DuplicationShelfNo2 = InventInputResult.ct_Col_DuplicationShelfNo2;
        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
		/// <summary> メーカー </summary>
		private const string ct_tool_Hidden_Maker = InventInputResult.ct_Col_MakerName;
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 事業者 </summary>
		//private const string ct_tool_Hidden_CarrierEp = InventInputResult.ct_Col_CarrierEpName;
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary> 仕入先 </summary>
        private const string ct_tool_Hidden_Customer = InventInputResult.ct_Col_CustomerName;
        /// <summary> 委託先 </summary>
		private const string ct_tool_Hidden_ShipCustomer = InventInputResult.ct_Col_ShipCustomerName;
        /// <summary> 在庫区分 </summary>
		private const string ct_tool_Hidden_StockTrtEntDiv = InventInputResult.ct_Col_StockTrtEntDivName;
		/// <summary> 初期表示状態 </summary>
		private const string ct_tool_Hidden_Initialize = "tool_Hidden_Initialize";
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2009/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        //----------------------
        // 列表示切替用ツール
        //----------------------
        /// <summary> 倉庫 </summary>
        private const string ct_tool_Hidden_Warehouse = InventInputResult.ct_Col_WarehouseName;
        /// <summary> 棚番 </summary>
        private const string ct_tool_Hidden_WarehouseShelfNo = InventInputResult.ct_Col_WarehouseShelfNo;
        /// <summary> 重複棚番1 </summary>
        private const string ct_tool_Hidden_DuplicationShelfNo1 = InventInputResult.ct_Col_DuplicationShelfNo1;
        /// <summary> 重複棚番2 </summary>
        private const string ct_tool_Hidden_DuplicationShelfNo2 = InventInputResult.ct_Col_DuplicationShelfNo2;
        /// <summary> メーカー </summary>
        private const string ct_tool_Hidden_Maker = InventInputResult.ct_Col_MakerName;
        /// <summary> 仕入先 </summary>
        private const string ct_tool_Hidden_Supplier = InventInputResult.ct_Col_SupplierName;
        /// <summary> 在庫区分 </summary>
        private const string ct_tool_Hidden_StockTrtEntDiv = InventInputResult.ct_Col_StockTrtEntDivName;
        /// <summary> 初期表示状態 </summary>
        private const string ct_tool_Hidden_Initialize = "tool_Hidden_Initialize";
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		#region // 2007.07.25 kubo del
		///// <summary> ソート順(倉庫-商品-製番) </summary>
		//private const string ct_SortOrder_Goods = 
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_MakerCode + "," +
		//    InventInputResult.ct_Col_GoodsCode			+ "," + InventInputResult.ct_Col_StockTrtEntDiv + "," +
		//    InventInputResult.ct_Col_StockUnitPrice		+ "," + InventInputResult.ct_Col_CustomerCode + "," +
		//    InventInputResult.ct_Col_ShipCustomerCode	+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_ProductNumber;
		///// <summary> ソート順(倉庫-事業者-製番) </summary>
		//private const string ct_SortOrder_CarrierEp = 
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_MakerCode			+ "," + InventInputResult.ct_Col_GoodsCode + "," + 
		//    InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
		//    InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode	+ "," +
		//    InventInputResult.ct_Col_ProductNumber;
		///// <summary> ソート順(倉庫-仕入先-商品-製番) </summary>
		//private const string ct_SortOrder_Customer =
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CustomerCode + "," +
		//    InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
		//    InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
		//    InventInputResult.ct_Col_ShipCustomerCode	+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_ProductNumber;
		///// <summary> ソート順(倉庫-委託先-商品-製番) </summary>
		//private const string ct_SortOrder_ShipCustomer = 
		//    InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode + "," +
		//    InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
		//    InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
		//    InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
		//    InventInputResult.ct_Col_ProductNumber;
		#endregion
        
        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        
        #region // 2007.09.11 削除
        //// 2007.07.27 kubo add (新規区分をソート順に追加)------------------->
		///// <summary> ソート順(倉庫-商品-製番) </summary>
        //private const string ct_SortOrder_Goods =
        //    InventInputResult.ct_Col_WarehouseCode      + "," + InventInputResult.ct_Col_MakerCode + "," +
        //    InventInputResult.ct_Col_GoodsCode          + "," + InventInputResult.ct_Col_StockTrtEntDiv + "," +
        //    InventInputResult.ct_Col_StockUnitPrice     + "," + InventInputResult.ct_Col_CustomerCode + "," +
        //    InventInputResult.ct_Col_ShipCustomerCode   + "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //    InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;
        ///// <summary> ソート順(倉庫-事業者-製番) </summary>
        //private const string ct_SortOrder_CarrierEp = 
        //	InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //	InventInputResult.ct_Col_MakerCode			+ "," + InventInputResult.ct_Col_GoodsCode + "," + 
        //	InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
        //	InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode	+ "," +
        //	InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;
        ///// <summary> ソート順(倉庫-仕入先-商品-製番) </summary>
        //private const string ct_SortOrder_Customer =
        //	InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_CustomerCode + "," +
        //	InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
        //	InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
        //	InventInputResult.ct_Col_ShipCustomerCode	+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //	InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;
        ///// <summary> ソート順(倉庫-委託先-商品-製番) </summary>
        //private const string ct_SortOrder_ShipCustomer = 
        //	InventInputResult.ct_Col_WarehouseCode		+ "," + InventInputResult.ct_Col_ShipCustomerCode + "," +
        //	InventInputResult.ct_Col_MakerCode			+ "," +	InventInputResult.ct_Col_GoodsCode + "," + 
        //	InventInputResult.ct_Col_StockTrtEntDiv		+ "," + InventInputResult.ct_Col_StockUnitPrice	+ "," + 
        //	InventInputResult.ct_Col_CustomerCode		+ "," + InventInputResult.ct_Col_CarrierEpCode + "," +
        //	InventInputResult.ct_Col_InventoryNewDiv    + "," + InventInputResult.ct_Col_SortProductNumber;

        // 2007.07.27 kubo add ------------------->
        #endregion

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary> ソート順(倉庫→棚番) </summary>
        private const string ct_SortOrder_ShelfNo =
            //InventInputResult.ct_Col_WarehouseCode + "," + ct_Col_WarehouseShelfNo + "," +
            //InventInputResult.ct_Col_MakerCode + "," + InventInputResult.ct_Col_GoodsNo;
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo;
        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
        private const string ct_SortOrder_GoodsDiv =
            InventInputResult.ct_Col_WarehouseCode        + "," + InventInputResult.ct_Col_WarehouseShelfNo     + "," +
            InventInputResult.ct_Col_MakerCode            + "," + InventInputResult.ct_Col_LargeGoodsGanreCode  + "," +
            InventInputResult.ct_Col_MediumGoodsGanreCode + "," + InventInputResult.ct_Col_DetailGoodsGanreCode + "," +
            InventInputResult.ct_Col_GoodsNo;
        private const string ct_SortOrder_Goods =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo + "," +
            InventInputResult.ct_Col_MakerCode     + "," + InventInputResult.ct_Col_GoodsNo;
        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary> ソート順(倉庫→仕入先) </summary>
        private const string ct_SortOrder_Customer =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_CustomerCode;
        /// <summary> ソート順(倉庫→ＢＬコード) </summary>
        private const string ct_SortOrder_BLGoods =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGoodsCode;
        /// <summary> ソート順(倉庫→メーカー) </summary>
        private const string ct_SortOrder_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode;
        /// <summary> ソート順(倉庫→仕入先→棚番) </summary>
        private const string ct_SortOrder_Cus_ShelfNo =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_CustomerCode + "," +
            InventInputResult.ct_Col_WarehouseShelfNo;
        /// <summary> ソート順(倉庫→仕入先→メーカー) </summary>
        private const string ct_SortOrder_Cus_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_CustomerCode + "," +
            InventInputResult.ct_Col_MakerCode;
        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        //----------------------
        // ソート順
        //----------------------
        /// <summary>棚番順(倉庫→棚番→品番→メーカー)</summary>
        /// <value></value>
        private const string ct_SortOrder_ShelfNo =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>仕入先順(倉庫→仕入先→品番→メーカー)</summary>
        private const string ct_SortOrder_Supplier =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>ＢＬコード順(倉庫→ＢＬコード→品番→メーカー)</summary>
        private const string ct_SortOrder_BLGoods =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGoodsCode + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>グループコード順(倉庫→グループコード→品番→メーカー)</summary>
        private const string ct_SortOrder_BLGroup =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGroupCode + "," +
            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;

        /// <summary>メーカー順(倉庫→メーカー→品番)</summary>
        private const string ct_SortOrder_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode + "," +
            InventInputResult.ct_Col_GoodsNo;

        /// <summary>仕入先・棚番順(倉庫→仕入先→棚番→品番→メーカー)</summary>
        private const string ct_SortOrder_Sup_ShelfNo =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
            InventInputResult.ct_Col_WarehouseShelfNo + "," + InventInputResult.ct_Col_GoodsNo + "," +
            InventInputResult.ct_Col_MakerCode;

        /// <summary>仕入先・メーカー順(倉庫→仕入先→メーカー→品番)</summary>
        private const string ct_SortOrder_Sup_Maker =
            InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
            InventInputResult.ct_Col_MakerCode + "," + InventInputResult.ct_Col_GoodsNo;
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		#region // 2007.07.25 kubo del
		///// <summary> フィルタ条件(商品毎) </summary>
		//private string ct_Filter_Goods = 
		//    InventInputResult.ct_Col_GrossDiv + "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
		//    InventInputResult.ct_Col_ViewDiv + "= 0";
		///// <summary> フィルタ条件(製番毎) </summary>
		//private string ct_Filter_Product = 
		//    "(("+
		//        InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
		//        InventInputResult.ct_Col_PrdNumMngDiv	+ "=" + ((int)InventInputSearchCndtn.PrdNumMngDivState.NoProduct).ToString() +
		//    ")" +" or "+
		//    "("+
		//        InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Product).ToString() + 
		//    "))" + " and " +
		//    InventInputResult.ct_Col_ViewDiv + "= 0";
		#endregion

        // 2007.07.25 kubo add -------------------------->
		/// <summary> フィルタ条件(商品毎) </summary>
		private string ct_Filter_Goods = 
			InventInputResult.ct_Col_GrossDiv + "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
			InventInputResult.ct_Col_ViewDiv + "=0 and " + InventInputResult.ct_Col_LogicalDeleteCode + "=0";

        #region 2007.09.11 削除
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> フィルタ条件(製番毎) </summary>
		//private string ct_Filter_Product = 
		//    "(("+
		//		InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Goods).ToString() + " and " +
		//		InventInputResult.ct_Col_PrdNumMngDiv	+ "=" + ((int)InventInputSearchCndtn.PrdNumMngDivState.NoProduct).ToString() +
		//	")" +" or "+
		//    "("+
		//		InventInputResult.ct_Col_GrossDiv		+ "=" + ((int)InventInputSearchCndtn.GrossDivState.Product).ToString() + 
		//	"))" + " and " +
		//	InventInputResult.ct_Col_ViewDiv + "= 0 and " + InventInputResult.ct_Col_LogicalDeleteCode + "=0";
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        // 2007.07.25 kubo add <--------------------------
        #endregion 2007.09.11 削除

        #endregion

        #region ■ IInventInputMdiChild メンバ

        #region ◆ Public Property
        /// <summary> 企業コードプロパティ </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> 拠点コードプロパティ </summary>
		public string SectionCode
		{
			set { this._sectionCode = value; }
		}

		/// <summary> 拠点名称プロパティ </summary>
		public string SectionName
		{
			set { this._sectionName = value; }
		}

		/// <summary> 取消ボタンEnabledプロパティ </summary>
		public bool IsCansel
		{
			get { return this._isCansel; }
		}

		/// <summary> 保存ボタンEnabledプロパティ </summary>
		public bool IsSave
		{
			get { return this._isSave; }
		}

		/// <summary> 抽出ボタンEnabledプロパティ </summary>
		public bool IsExtract
		{
			get { return this._isExtract; }
		}

		/// <summary> 新規ボタンEnabledプロパティ </summary>
		public bool IsNewInvent
		{
			get { return this._isNewInvent; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDetail
		{
			get { return this._isDetail; }
		}

		/// <summary> バーコード読込ボタンEnabledプロパティ </summary>
		public bool IsBarcodeRead
		{
			get { return this._isBarcodeRead; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDataEdit
		{
			get { return this._isDataEdit; }
		}

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する ----->>>>>
        /// <summary> 品番検索ボタンEnabledプロパティ(true:品番検索ボタンクリックができる　false:品番検索ボタンクリックができない) </summary>
        public bool IsGoodsSearch
        {
            get { return this._isGoodsSearch; }
        }
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する -----<<<<<
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 画面表示処理
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
        /// <br>UpdateNote : 2009/12/03 李占川 ＰＭ．ＮＳ保守依頼③</br>
        /// <br>             REDMINE:2018　既存障害の修正</br>
		/// </remarks>
		public int ShowData ( object parameter )
		{
			try
			{
				this.uGrid_InventInput.BeginUpdate();
                this._extrInfo = (InventInputSearchCndtn)parameter;

                //this._isFirstsetting = true;        //ADD 2009/05/14 不具合対応[13260]  // DEL 2009/12/03
                this._addingKey = true;               //ADD yangyi 2013/03/01 Redmine#34175 
				ShowDataProc();
			}
			finally
			{
				this.uGrid_InventInput.EndUpdate();
			}
			return 0;
		}
		#endregion

		#region ◎ タブ変更前処理
		/// <summary>
		/// タブ変更前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeTabChange ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 終了前処理
		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 終了前処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeClose ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 取消前処理
		/// <summary>
		/// 取消前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消前処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeCansel ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 取消処理
		/// <summary>
		/// 取消処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int Cansel ( object parameter )
		{
			// メッセージで取消の確認
			string strMsg = "現在編集中のデータが存在します。\n\n初期状態に戻しますか？";

			// Okなら初回抽出時、保存時のデータに戻す
			DialogResult dlgRes = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_INFO,        //エラーレベル
				"MAZAI05130UB",                     //UNIT　ID
				"棚卸入力",                        //プログラム名称
				"取消",		                        //プロセスID
				"",                                 //オペレーション
				strMsg,                             //メッセージ
				0,									//ステータス
				null,								//オブジェクト
				MessageBoxButtons.YesNo,               //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);

			switch( dlgRes )
			{
				case DialogResult.Yes:
					// 現在のテーブルにバッファテーブルをコピー
					try
					{
                        this.uGrid_InventInput.BeginUpdate();
						this._inventInputAcs.Remove();

                        this._isFirstsetting = true;        //ADD 2009/05/14　不具合対応[13260]
                        this.ShowDataProc();                //ADD 2009/05/14　不具合対応[13260]
					}
					finally
					{
						this.uGrid_InventInput.EndUpdate();

                        if (this.uGrid_InventInput.Rows.Count > 0)
                        {
                            this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
					#region //	2007.07.19 kubo del
					//ChangeViewStyle();
					//InitialInventInputGrid( this.uGrid_InventInput.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ] );	// グリッドの設定しなおし
					//this.uGrid_InventInput.Refresh(); // グリッドをいったんクリア
					#endregion
					break;
				case DialogResult.No:
					// 何もしない
					break;
			}
			return 0;
		}
		#endregion

		#region ◎ 抽出前処理
		/// <summary>
		/// 抽出前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出前処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BeforeExtract ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 抽出処理
		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int Extract (ref object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ 新規処理
		/// <summary>
		/// 新規処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 新規処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int NewInvent ( object parameter )
		{
			return NewInventProc();
		}
		#endregion

		#region ◎ 保存処理
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 保存処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int Save ( object parameter )
		{
			string errMsg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			UltraGridRow activeRow = null;

			try
			{
				// エディットモードになっているセルを抜けるための処理
				this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

				this.uGrid_InventInput.BeginUpdate();	// 描画停止

				if ( this.uGrid_InventInput.ActiveRow != null )
					activeRow = this.uGrid_InventInput.ActiveRow;

				this.uGrid_InventInput.ActiveRow = null;
				
                #region // 2007.07.19 kubo del
				// this.uGrid_InventInput.UpdateData();	// 変更のコミット 
				#endregion

				this.uGrid_InventInput.Selected.Rows.Clear();
				this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
				this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

				status = this._inventInputAcs.WriteInvent(out errMsg);

				this.uGrid_InventInput.ActiveRow = activeRow;

				emErrorLevel errLv = emErrorLevel.ERR_LEVEL_INFO;
				switch ( status )
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						// 正常終了
						this.uGrid_InventInput.Refresh();
                        errLv = emErrorLevel.ERR_LEVEL_INFO;
                        break;
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						// 更新エラー発生
						errLv = emErrorLevel.ERR_LEVEL_EXCLAMATION;
						break;
					default:
						// 例外など
						errLv = emErrorLevel.ERR_LEVEL_STOPDISP;
						break;
				}

				#region // 2007.07.19 kubo del
				// データ再描画
				//ChangeViewStyle();
				//this.uGrid_InventInput.DataBind();
				//if ( this.uGrid_InventInput.Rows.Count > 0 )
				//{
				//    this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
				//}
				//this.uGrid_InventInput.PerformAction( UltraGridAction.EnterEditMode );
				#endregion

				// メッセージ表示
				this.MsgDispProc(errMsg, status, "Save", errLv);
			}
			finally
			{
				this.uGrid_InventInput.EndUpdate();	// 描画再開
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // ---ADD 2009/05/14 不具合対応[13260] ------------------------------>>>>>
        /// <summary>
        /// 保存前処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0：正常、0以外：異常</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行う</br>
        /// <br>Programer  : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             「行削除」のみを行った場合でも保存可能に変更する</br>
        /// </remarks>
        public int BeforeSave(object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // セルのエディットモード解除
            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

            int CheckCount = 0;
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                // --- ADD 2009/12/03 ---------->>>>>
                // 「行削除」場合
                if ((int)gridRow.Cells[InventInputResult.ct_Col_DeleteDiv].Value == 1)
                {
                    CheckCount++;
                    continue;
                }
                // --- ADD 2009/12/03 ----------<<<<<

                if ((string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value.ToString())) &&
                    (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString())) &&
                    (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString())) &&
                    (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString())))
                {
                    continue;
                }

                // 棚卸数
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("棚卸数を入力して下さい。", status, InventInputResult.ct_Col_InventoryStockCnt, gridRow);
                    return status;
                }
                // 棚卸実施日
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("棚卸実施日(年)を入力して下さい。", status, InventInputResult.ct_Col_InventoryDay_Year, gridRow);
                    return status;
                }
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("棚卸実施日(月)を入力して下さい。", status, InventInputResult.ct_Col_InventoryDay_Month, gridRow);
                    return status;
                }
                if (string.IsNullOrEmpty(gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString()))
                {
                    this.BeforeSaveErrorProc("棚卸実施日(日)を入力して下さい。",status, InventInputResult.ct_Col_InventoryDay_Day,gridRow);
                    return status;
                }
                CheckCount++;
            }

            // 対象データなし
            if (CheckCount == 0)
            {
                this.BeforeSaveErrorProc("対象データがありません。", status, string.Empty, null);
                return status;
            }

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        /// <summary>
        /// 入力エラー発生時処理
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <param name="status">エラー時のステータス</param>
        /// <param name="cellName">エラー発生列(グリッド以外の場合はstring.Emptyを設定)</param>
        /// <param name="gridRow">エラー発生行(グリッド以外の場合はNullを設定)</param>
        /// <remarks>
        /// <br>Note       : エラー発生時にメッセージ表示する、フォーカスを当てる等の各処理を行う</br>
        /// <br>Programer  : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks>
        private void BeforeSaveErrorProc(string msg, int status, string cellName, UltraGridRow gridRow)
        {
            //エラーメッセージ
            this.MsgDispProc(msg, status, "BeforeSave", emErrorLevel.ERR_LEVEL_EXCLAMATION);

            //フィルタ解除
            this.uGrid_InventInput.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

            if (gridRow != null)
            {
                //フォーカス設定
                gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activated = true;
                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        // ---ADD 2009/05/14 不具合対応[13260] ------------------------------>>>>>

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        public int Save(object parameter)
        {
            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "保存中";
            msgForm.Message = "棚卸データの保存中です。";

            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            string errMsg = "";

            try
            {
                msgForm.Show();

                UltraGridRow activeRow = null;

                try
                {
                    // エディットモードになっているセルを抜けるための処理
                    this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

                    // 描画停止
                    this.uGrid_InventInput.BeginUpdate();	

                    if (this.uGrid_InventInput.ActiveRow != null)
                    {
                        activeRow = this.uGrid_InventInput.ActiveRow;
                    }

                    this.uGrid_InventInput.ActiveRow = null;
                    this.uGrid_InventInput.Selected.Rows.Clear();
                    this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
                    //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

                    // 保存処理
                    status = this._inventInputAcs.WriteInvent(this._extrInfo.DifCntExtraDiv, out errMsg);

                    // --- ADD 2014/12/04 Y.Wakita ---------->>>>>
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 行の文字色を変更
                        RowForeColorChange();
                    }
                    // --- ADD 2014/12/04 Y.Wakita ----------<<<<<

                    this.uGrid_InventInput.ActiveRow = activeRow;

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.uGrid_InventInput.Refresh();
                    }
                }
                finally
                {
                    // 描画再開
                    this.uGrid_InventInput.EndUpdate();	
                }
            }
            finally
            {
                msgForm.Close();
            }

            emErrorLevel errLv = emErrorLevel.ERR_LEVEL_INFO;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    // 正常終了
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);

                    this.MAZAI05130UB_FormClosing(this, null); // ADD 2009/12/03


                    return (status);
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    // 更新エラー発生
                    errLv = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                    break;
                default:
                    // 例外など
                    errLv = emErrorLevel.ERR_LEVEL_STOPDISP;
                    break;
            }

            // メッセージ表示
            this.MsgDispProc(errMsg, status, "Save", errLv);
            
            return (status);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

		#region ◎ 詳細表示処理
		/// <summary>
		/// 詳細表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 詳細表示処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int ShowDetail ( object parameter )
		{
			return 0;
		}
		#endregion

		#region ◎ バーコード読込処理
		/// <summary>
		/// バーコード読込処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : バーコード読込処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public int BarcodeRead ( object parameter )
		{
			ReadBarCodeMain();
			return 0;
		}
		#endregion

		#region ◎ 編集処理
		/// <summary>
		/// 編集処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 編集処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		public int DataEdit ( object parameter )
		{
			return this.DataEditProc();
		}
		#endregion

        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する ----->>>>>
        #region ◎ 品番検索
        /// <summary>
        /// 品番検索処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 品番検索を行う</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 品番検索を追加</br>
        /// </remarks>
        public int GoodsSearch(object parameter)
        {
            return GoodsSearchProc();
        }
        #endregion

        #region ◎ 品番検索メイン
        /// <summary>
        /// 品番検索メイン
        /// </summary>
        /// <returns>検索状態（同じ品番検索した場合、ctFNC_NORMALを戻る）</returns>
        private int GoodsSearchProc()
        {
            // 初期化設定
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                if ((this._goodsSearchForm == null) || (false == this._goodsSearchForm.Visible))
                {
                    this._goodsSearchForm = new MAZAI05130UE();
                }
                else
                {
                    return status;
                }

                // 親画面のGridデータ設定
                _goodsSearchForm.UltraGrid = this.uGrid_InventInput;
                this._goodsSearchForm.ShowEditor();

                _goodsSearchForm.Show(this);

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                this.MsgDispProc("棚卸データの品番検索に失敗しました。", status, "NewInventProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            return status;
        }
        #endregion
        // --- ADD 陳嘯 2015/04/27 Redmine#45746 棚卸入力画面の棚卸入力タブに品番検索ボタンを追加する -----<<<<<

        // --- ADD 陳嘯 2015/04/27 Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する ----->>>>>
        #region ◎ 閉じる前チェック
        /// <summary>
        /// 閉じる前チェック
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>bool(TRUE: 画面閉じる　FALSE:画面閉じらない)</returns>
        /// <remarks>
        /// <br>Note       : 閉じる前チェックを行う</br>
        /// <br>Programer  : 陳嘯</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>管理番号   : 11070149-00 2015/04/27 閉じる前チェックを追加</br>
        /// </remarks>
        public bool ClosingCheck()
        {
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                if ((int)gridRow.Cells[InventInputResult.ct_Col_ChangeDiv].Value == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                {
                    string msg = "現在編集中のデータが存在します。\n\n終了してもよろしいですか？";
                    DialogResult diaLog = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "", msg, 
                        0, MessageBoxButtons.YesNo,MessageBoxDefaultButton.Button2);
                    if (diaLog == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion ◎ 閉じる前チェック
        // --- ADD 陳嘯 2015/04/27 Redmine#45747 棚卸入力画面を×ボタンで閉じる際に未保存の入力データがある場合は警告メッセージを表示する -----<<<<<
		#endregion ◆ Public Method

		#region IInventInputMdiChild メンバ
		/// <summary>
		/// ツールバー設定
		/// </summary>
		public event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;
		#endregion
		#endregion ■ IInventInputMdiChild メンバ

		#region ■ Private Method
		#region ◎ 初期化処理メイン
		/// <summary>
		/// 初期化処理メイン
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: 画面初期化処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private int InitialLoadScreen ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				// 初回起動時のみ画面設定

				// Toolbars Setting
				this.InitialToolBarsSetting();

				// StatusBarsSetting
				this.InitializeStatusBarSetting();

				// コンポーネント初期処理
				this.InitialPrintSetCompornent();

				// 画面イメージ統一
                this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
                this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

				// アイコン設定
				this.ub_RowDelete.ImageList = IconResourceManagement.ImageList16;
				this.ub_RowDelete.Appearance.Image = Size16_Index.ROWDELETE;
			}
			finally
			{
			}

			return status;
		}
		#endregion

		#region ◎ ツールバー設定処理
		/// <summary>
		/// ツールバー設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ツールバーの設定を行う。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialToolBarsSetting ()
		{
			// 一括入力ボタン
			this.utb_InventDataToolBar.Tools[ct_tool_InventoryAllInput].Control = this.ub_InventoryAllInput;
			// 棚卸実施日
            this.utb_InventDataToolBar.Tools[ct_tool_InventoryDate].Control = this.tde_InventoryDate;

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚卸日
            this.utb_InventDataToolBar.Tools[ct_tool_InventoryExeDate].Control = this.tde_InventoryExeDate;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            // 表示方法コンテナに追加
			this.utb_InventDataToolBar.Tools[ct_tool_ViewStyleContainer].Control = this.tce_ViewStyle;

			// ソート順コンテナに追加
			this.utb_InventDataToolBar.Tools[ct_tool_SortOrderContainer].Control = this.tce_SortOrder;

			// 2007.07.24 kubo add
			this.utb_InventDataToolBar.Tools[ct_tool_RowDelete].Control = this.ub_RowDelete;

		}
		#endregion

		#region ◎ ステータスバー初期処理
		/// <summary>
		/// ステータスバー初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ステータスバー初期化を行う</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitializeStatusBarSetting ()
		{
			// フォントサイズ変更コンボボックスの設定
			this.tce_FontSize.MaxDropDownItems = this.tce_FontSize.Items.Count;
			this.tce_FontSize.Value = 10;
		}

		#region ◎ 印刷条件設定コンポーネント初期処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 印刷条件設定コンポーネント初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生する。</br>
		/// <br>Programmer	: 30414 忍 幸史</br>
		/// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote  : 2009/11/23 李占川 PM.NS　保守対応</br>
        /// <br>              棚卸実施日の入力ミスを防ぐ為、棚卸実施日の初期表示を変更する</br>
		/// </remarks>
		private void InitialPrintSetCompornent()
		{
			// 棚卸実施日
			//this.tde_InventoryDate.SetDateTime( DateTime.Now ); // DEL 2009/12/03
			// 表示方法
			this.tce_ViewStyle.Items.Add( (int)InventInputSearchCndtn.ViewStyleState.Product, "製造番号毎");
			this.tce_ViewStyle.Items.Add( (int)InventInputSearchCndtn.ViewStyleState.Goods	, "商品毎");
			this.tce_ViewStyle.MaxDropDownItems = this.tce_ViewStyle.Items.Count;

			// ソート順
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.ShelfNo, "棚番順");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Customer, "仕入先順");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.BLGoods,"BLｺｰﾄﾞ順");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.BLGroup, "ｸﾞﾙｰﾌﾟｺｰﾄﾞ順");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Maker, "メーカー順");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo, "仕入先・棚番順");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_Maker, "仕入先・メーカー順");
			this.tce_SortOrder.MaxDropDownItems = this.tce_SortOrder.Items.Count;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 印刷条件設定コンポーネント初期処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを読み込むときに発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void InitialPrintSetCompornent()
        {
            // 棚卸実施日
            this.tde_InventoryDate.SetDateTime(DateTime.Now);
            // 表示方法
            this.tce_ViewStyle.Items.Add((int)InventInputSearchCndtn.ViewStyleState.Product, "製造番号毎");
            this.tce_ViewStyle.Items.Add((int)InventInputSearchCndtn.ViewStyleState.Goods, "商品毎");
            this.tce_ViewStyle.MaxDropDownItems = this.tce_ViewStyle.Items.Count;

            // ソート順
            // 2007.06.28 22013 kubo Edit ( ハイフンを→矢印に変更　)　------------------------------->
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.Goods, "倉庫→商品");
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.CarrierEP		, "倉庫→事業者→商品");
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.Customer		, "倉庫→仕入先→商品");
            //this.tce_SortOrder.Items.Add( (int)InventInputSearchCndtn.SortOrderState.ShipCustomer	, "倉庫→委託先→商品");
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.ShelfNo, "倉庫→棚番");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.SNo_GoodsDiv, "倉庫→棚番→メーカー→商品区分→商品");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.SNo_Goods, "倉庫→棚番→メーカー→商品");
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Customer, "倉庫→仕入先");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.BLGoods, "倉庫→ＢＬコード");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Maker, "倉庫→メーカー");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo, "倉庫→仕入先→棚番");
            this.tce_SortOrder.Items.Add((int)InventInputSearchCndtn.SortOrderState.Cus_Maker, "倉庫→仕入先→メーカー");
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.06.28 22013 kubo Edit ------------------------------->
            this.tce_SortOrder.MaxDropDownItems = this.tce_SortOrder.Items.Count;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ キーマッピング設定処理
        /// <summary>
		/// グリッドキーマッピング作成処理
		/// </summary>
		/// <param name="grid">対象グリッド</param>
		/// <remarks>
		/// <br>Note       : グリッドに対してキーマッピングを作成します。</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void MakeGridKeyMapping( UltraGrid grid )
		{
			// wkKeyMapping = new GridKeyActionMapping( 
			//		Keys.Enter,							// 対象となるKey。このKeyが指定したときの動作を決める
			//		UltraGridAction.NextCellByTab,		// 対象のKeyが押されたときの動作
			//		UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox,	// Keyが押されても対象外となる場合の指定
			//		UltraGridState.Cell,				// 押された後のグリッドの状態
			//		SpecialKeys.All,					// 同時に押されても無視するKey。(このKeyが押されていると動作を実行しない。)
			//		SpecialKeys.Shift );				// 同時に押されないと動作をしないKey。(このKeyを同時に押したとき動作を実行する。)
			//grid.KeyActionMappings.Add( wkKeyMapping );

			
			GridKeyActionMapping wkKeyMapping = null;

			// Enterキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.NextCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Shift + Enterキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.PrevCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.AltCtrl, 
				SpecialKeys.Shift );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ↑キー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Up, 
				UltraGridAction.AboveCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ↓キー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Down, 
				UltraGridAction.BelowCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageUpキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Prior, 
				UltraGridAction.PageUpCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageDownキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Next, 
				UltraGridAction.PageDownCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Spaceキー
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Space, 
				UltraGridAction.ToggleRowSel, 
				0, 
				0, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

		}
		#endregion

		#endregion ◆ 初期化処理

		#region ◎ データ表示UltraGrid初期処理
        /// <summary>
        /// データ表示UltraGrid初期処理
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid(UltraGridBand band)
        {
            // 一旦すべての列を非表示にし、表示位置を統一させる
            foreach (UltraGridColumn column in band.Columns)
            {
                column.Hidden = true;
                column.CellAppearance.TextHAlign = HAlign.Left;
                column.CellAppearance.ImageHAlign = HAlign.Left;
                column.CellAppearance.ImageVAlign = VAlign.Middle;
                column.TabStop = true;
            }

            InitialInventInputGrid_Hidden(band);			// 表示状態設定
            InitialInventInputGrid_Tag(band);				// Tag
            InitialInventInputGrid_CellActivation(band);    // 入力設定
            InitialInventInputGrid_Width(band);			    // 幅設定
            InitialInventInputGrid_CellAppearance(band);	// テキスト表示位置
            InitialInventInputGrid_CellClickAction(band);	// CellClickAction
            InitialInventInputGrid_Style(band);			    // 列スタイル
            InitialInventInputGrid_Format(band);			// Format
            InitialInventInputGrid_GroupSetting(band);		// グループ設定

            // 列移動設定
            band.Override.AllowColMoving = AllowColMoving.WithinGroup;

            // フィルタ設定
            band.Override.AllowRowFiltering = DefaultableBoolean.True;

            // グリッド設定情報取得
            GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_InventInput);
            if (gridStateInfo != null)
            {
                // グリッド設定
                this._gridStateController.SetGridStateToGrid(ref this.uGrid_InventInput);
                this.tce_FontSize.Value = (int)gridStateInfo.FontSize;
                this.uce_ColSizeAutoSetting.Checked = gridStateInfo.AutoFit;

                // グリッドの設定からツールバーのチェックに反映する
                SettingHiddenToolChecked(ct_tool_Hidden_Warehouse, InventInputResult.ct_Col_WarehouseName);	                // 倉庫
                SettingHiddenToolChecked(ct_tool_Hidden_WarehouseShelfNo, InventInputResult.ct_Col_WarehouseShelfNo);	    // 倉庫棚番
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo1, InventInputResult.ct_Col_DuplicationShelfNo1);	// 重複棚番１
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo2, InventInputResult.ct_Col_DuplicationShelfNo2);	// 重複棚番２
                SettingHiddenToolChecked(ct_tool_Hidden_Maker, InventInputResult.ct_Col_MakerName);	                        // メーカー
                SettingHiddenToolChecked(ct_tool_Hidden_Supplier, InventInputResult.ct_Col_SupplierName);	                // 仕入先
                SettingHiddenToolChecked(ct_tool_Hidden_StockTrtEntDiv, InventInputResult.ct_Col_StockTrtEntDivName);	    // 在庫区分
            }
        }

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// データ表示UltraGrid初期処理
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid( UltraGridBand band )
		{
			// 一旦すべての列を非表示にし、表示位置を統一させる
			foreach( UltraGridColumn column in band.Columns ) {
                column.Hidden = true;
                column.CellAppearance.TextHAlign = HAlign.Left;
                column.CellAppearance.ImageHAlign = HAlign.Left;
                column.CellAppearance.ImageVAlign = VAlign.Middle;
                column.TabStop = true;
			}

            this.InitialInventInputGrid_Hidden(band);				// 表示状態設定
            this.InitialInventInputGrid_Tag(band);				// Tag
            this.InitialInventInputGrid_CellActivation(band);		// 入力設定
            this.InitialInventInputGrid_Width(band);				// 幅設定
            this.InitialInventInputGrid_CellAppearance(band);		// テキスト表示位置
            this.InitialInventInputGrid_CellClickAction(band);	// CellClickAction
            this.InitialInventInputGrid_Style(band);				// 列スタイル
            //this.InitialInventInputGrid_TabStop( band );			// TabStop
            this.InitialInventInputGrid_Format(band);				// Format
			this.InitialInventInputGrid_GroupSetting( band );		// グループ設定

            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 列ヘッダを非表示にする。
            //band.ColHeadersVisible = false;
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 列移動設定
            band.Override.AllowColMoving = AllowColMoving.WithinGroup;

            // フィルタ設定
            band.Override.AllowRowFiltering = DefaultableBoolean.True;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            
            // グリッド設定情報取得
			GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_InventInput);
			if (gridStateInfo != null)
			{
				// グリッド設定
				this._gridStateController.SetGridStateToGrid(ref this.uGrid_InventInput);
				this.tce_FontSize.Value = (int)gridStateInfo.FontSize;
				this.uce_ColSizeAutoSetting.Checked = gridStateInfo.AutoFit;

				// グリッドの設定からツールバーのチェックに反映する
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //SettingHiddenToolChecked( ct_tool_Hidden_TEL1             , InventInputResult.ct_Col_StockTelNo1          );	// TEL1
				//SettingHiddenToolChecked( ct_tool_Hidden_TEL2			    , InventInputResult.ct_Col_StockTelNo2			);	// TEL2
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                SettingHiddenToolChecked( ct_tool_Hidden_Warehouse          , InventInputResult.ct_Col_WarehouseName        );	// 倉庫
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                SettingHiddenToolChecked(ct_tool_Hidden_WarehouseShelfNo    , InventInputResult.ct_Col_WarehouseShelfNo     );	// 倉庫棚番
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo1 , InventInputResult.ct_Col_DuplicationShelfNo1  );	// 重複棚番１
                SettingHiddenToolChecked(ct_tool_Hidden_DuplicationShelfNo2 , InventInputResult.ct_Col_DuplicationShelfNo2  );	// 重複棚番２
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                SettingHiddenToolChecked(ct_tool_Hidden_Maker               , InventInputResult.ct_Col_MakerName            );	// メーカー
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //SettingHiddenToolChecked(ct_tool_Hidden_CarrierEp         , InventInputResult.ct_Col_CarrierEpName        );	// 事業者
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                SettingHiddenToolChecked(ct_tool_Hidden_Customer            , InventInputResult.ct_Col_CustomerName         );	// 仕入先
				SettingHiddenToolChecked( ct_tool_Hidden_ShipCustomer	    , InventInputResult.ct_Col_ShipCustomerName		);	// 委託先
				SettingHiddenToolChecked( ct_tool_Hidden_StockTrtEntDiv	    , InventInputResult.ct_Col_StockTrtEntDivName	);	// 在庫区分
            }
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        /// <summary>
		/// ツールチェック更新処理
		/// </summary>
		/// <param name="toolKey"></param>
		/// <param name="columnKey"></param>
		private void SettingHiddenToolChecked( string toolKey, string columnKey)
		{
			((StateButtonTool)this.utb_InventDataToolBar.Tools[toolKey]).Checked = 
				!this.uGrid_InventInput.Rows.Band.Columns[ columnKey ].Hidden;
		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(Hiddenプロパティ)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(Hiddenプロパティ)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
        /// <br>             障害報告 #18764</br>
        /// </remarks>
        private void InitialInventInputGrid_Hidden(UltraGridBand band)
        {
            band.Columns[InventInputResult.ct_Col_InventoryNewDiv].Hidden = true;           // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Hidden = false;      // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_GoodsNo].Hidden = false;                  // 品番
            band.Columns[InventInputResult.ct_Col_GoodsName].Hidden = false;                // 品名
            band.Columns[InventInputResult.ct_Col_ListPrice].Hidden = true;                // 定価                  //ADD 2011/01/30          
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Hidden = false;           // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockTotal].Hidden = false;               // 在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Hidden = false;        // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Hidden = false;     // 差異数
            band.Columns[InventInputResult.ct_Col_BfChgInventoryToleCnt].Hidden = true;     // 変更前差異数
            band.Columns[InventInputResult.ct_Col_InventoryDay].Hidden = true;              // 棚卸実施日
            band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime].Hidden = true;		// 棚卸実施日(DateTime)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Hidden = false;		// 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Hidden = true;		// 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Hidden = false;		// 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Hidden = true;		// 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Hidden = false;		    // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Hidden = true;			// 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_Button].Hidden = true;                    // ボタン用カラム
            band.Columns[InventInputResult.ct_Col_WarehouseCode].Hidden = true;             // 倉庫コード
            //band.Columns[InventInputResult.ct_Col_WarehouseName].Hidden = true;             // 倉庫名称           //DEL 2009/05/14 不具合対応[13260]
            //band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Hidden = true;          // 棚番               //DEL 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_WarehouseName].Hidden = false;            // 倉庫名称             //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Hidden = false;         // 棚番                 //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Hidden = true;       // 重複棚番1
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Hidden = true;       // 重複棚番2
            band.Columns[InventInputResult.ct_Col_MakerCode].Hidden = true;                 // メーカーコード
            //band.Columns[InventInputResult.ct_Col_MakerName].Hidden = true;                 // メーカー名称       //DEL 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_MakerName].Hidden = false;                // メーカー名称         //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_SupplierCode].Hidden = true;              // 仕入先コード
            band.Columns[InventInputResult.ct_Col_SupplierName].Hidden = true;              // 仕入先名称
            band.Columns[InventInputResult.ct_Col_SupplierName2].Hidden = true;             // 仕入先名称2
            band.Columns[InventInputResult.ct_Col_ShipCustomerCode].Hidden = true;          // 委託先コード
            band.Columns[InventInputResult.ct_Col_StockTrtEntDiv].Hidden = true;            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Hidden = true;        // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_No].Hidden = false;                       // No                   //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Hidden = true;            // 調整用計算原価       //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCntBf].Hidden = true;    // 棚卸過不足数         //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// データ表示UltraGrid初期処理(Hiddenプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Hidden( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 表示状態設定(Hidden)
			// 表示項目 ------------------------------------------------------
			// 棚卸新規追加区分
			band.Columns[ InventInputResult.ct_Col_InventoryNewDiv ].Hidden = true;
			// 棚卸新規追加区分
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].Hidden = false;

			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].Hidden = false;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Hidden = false;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

			// 品名
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Hidden = false;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Hidden = false;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 仕入単価
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].Hidden = false;

			// 在庫数
			band.Columns[ InventInputResult.ct_Col_StockTotal ].Hidden = false;

			// 棚卸在庫数
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Hidden = false;

            // 差異数
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Hidden = false;
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Hidden = true;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 変更前差異数
			band.Columns[ InventInputResult.ct_Col_BfChgInventoryToleCnt ].Hidden = true;

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            // 棚卸日
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Hidden = true;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

			// 棚卸実施日
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Datetime ].Hidden = true;		// 棚卸実施日(DateTime)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Hidden = false;			// 棚卸実施日(年 入力)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Hidden = false;			// 棚卸実施日(年 ラベル)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Hidden = false;			// 棚卸実施日(月 入力)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Hidden = false;		// 棚卸実施日(月 ラベル)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Hidden = false;			// 棚卸実施日(日 入力)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Hidden = false;			// 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Hidden     = false;		// 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Hidden    = true;			// 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Hidden    = false;		// 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Hidden   = true;		    // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Hidden      = false;		// 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Hidden     = true;			// 棚卸実施日(日 ラベル)
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

			// ボタン用カラム
			band.Columns[ InventInputResult.ct_Col_Button ].Hidden = true;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 電話番号1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ].Hidden = true;
            //
			//// 電話番号2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ].Hidden = true;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 倉庫
			band.Columns[ InventInputResult.ct_Col_WarehouseCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Hidden = true;

            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].Hidden = true;
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].Hidden = true;
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].Hidden = true;
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            // メーカー
			band.Columns[ InventInputResult.ct_Col_MakerCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_MakerName ].Hidden = true;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者
			//band.Columns[ InventInputResult.ct_Col_CarrierEpCode ].Hidden = true;
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Hidden = true;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 得意先
			band.Columns[ InventInputResult.ct_Col_CustomerCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_CustomerName2 ].Hidden = true;

			// 委託先
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Hidden = true;

			// 在庫委託受託区分
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ].Hidden = true;
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Hidden = true;

			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ データ表示UltraGrid初期処理(Tagプロパティ)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(Tagプロパティ)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン</br>
        /// <br>             障害報告 #18764</br>
        /// </remarks>
        private void InitialInventInputGrid_Tag(UltraGridBand band)
        {
            // 作成日時
            band.Columns[InventInputResult.ct_Col_CreateDateTime].Tag = InventInputResult.ct_Col_CreateDateTime;
            // 更新日時
            band.Columns[InventInputResult.ct_Col_UpdateDateTime].Tag = InventInputResult.ct_Col_UpdateDateTime;
            // 企業コード
            band.Columns[InventInputResult.ct_Col_EnterpriseCode].Tag = InventInputResult.ct_Col_EnterpriseCode;
            // GUID
            band.Columns[InventInputResult.ct_Col_FileHeaderGuid].Tag = InventInputResult.ct_Col_FileHeaderGuid;
            // 更新従業員コード
            band.Columns[InventInputResult.ct_Col_UpdEmployeeCode].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
            // 更新アセンブリID1
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId1].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
            // 更新アセンブリID2
            band.Columns[InventInputResult.ct_Col_UpdAssemblyId2].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
            // 論理削除区分
            band.Columns[InventInputResult.ct_Col_LogicalDeleteCode].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
            // 拠点コード
            band.Columns[InventInputResult.ct_Col_SectionCode].Tag = InventInputResult.ct_Col_SectionCode;
            // 倉庫コード
            band.Columns[InventInputResult.ct_Col_WarehouseCode].Tag = InventInputResult.ct_Col_WarehouseCode;
            // 倉庫名称
            band.Columns[InventInputResult.ct_Col_WarehouseName].Tag = InventInputResult.ct_Col_WarehouseName;
            // メーカーコード
            band.Columns[InventInputResult.ct_Col_MakerCode].Tag = InventInputResult.ct_Col_MakerCode;
            // メーカー名称
            band.Columns[InventInputResult.ct_Col_MakerName].Tag = InventInputResult.ct_Col_MakerName;
            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].Tag = InventInputResult.ct_Col_GoodsNo;
            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].Tag = InventInputResult.ct_Col_GoodsName;
            // --- ADD 2011/01/30 --------------------------------------------------------------------->>>>>
            // 定価
            band.Columns[InventInputResult.ct_Col_ListPrice].Tag = InventInputResult.ct_Col_ListPrice;
            // --- ADD 2011/01/30 ---------------------------------------------------------------------<<<<<
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // 商品大分類コード
            band.Columns[InventInputResult.ct_Col_LargeGoodsGanreCode].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
            // 商品中分類コード
            band.Columns[InventInputResult.ct_Col_MediumGoodsGanreCode].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
            // グループコード
            band.Columns[InventInputResult.ct_Col_BLGroupCode].Tag = InventInputResult.ct_Col_BLGroupCode;
            // グループコード名称
            band.Columns[InventInputResult.ct_Col_BLGroupName].Tag = InventInputResult.ct_Col_BLGroupName;
            // 自社分類コード
            band.Columns[InventInputResult.ct_Col_EnterpriseGanreCode].Tag = InventInputResult.ct_Col_EnterpriseGanreCode;
            // ＢＬ品番
            band.Columns[InventInputResult.ct_Col_BLGoodsCode].Tag = InventInputResult.ct_Col_BLGoodsCode;
            // ＢＬ品名
            band.Columns[InventInputResult.ct_Col_BLGoodsName].Tag = InventInputResult.ct_Col_BLGoodsName;
            // 仕入先コード
            band.Columns[InventInputResult.ct_Col_SupplierCode].Tag = InventInputResult.ct_Col_SupplierCode;
            // 仕入先名称
            band.Columns[InventInputResult.ct_Col_SupplierName].Tag = InventInputResult.ct_Col_SupplierName;
            // 仕入先名称2
            band.Columns[InventInputResult.ct_Col_SupplierName2].Tag = InventInputResult.ct_Col_SupplierName2;
            // JANコード
            band.Columns[InventInputResult.ct_Col_Jan].Tag = InventInputResult.ct_Col_Jan;
            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Tag = InventInputResult.ct_Col_StockUnitPrice;
            // 変更前仕入単価
            band.Columns[InventInputResult.ct_Col_BfStockUnitPrice].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
            // 仕入単価変更フラグ
            band.Columns[InventInputResult.ct_Col_StkUnitPriceChgFlg].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
            // 在庫区分
            band.Columns[InventInputResult.ct_Col_StockDiv].Tag = InventInputResult.ct_Col_StockDiv;
            // 最終仕入年月日
            band.Columns[InventInputResult.ct_Col_LastStockDate].Tag = InventInputResult.ct_Col_LastStockDate;
            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Tag = InventInputResult.ct_Col_StockTotal;
            // 委託先コード
            band.Columns[InventInputResult.ct_Col_ShipCustomerCode].Tag = InventInputResult.ct_Col_ShipCustomerCode;
            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Tag = InventInputResult.ct_Col_InventoryStockCnt;
            // 棚卸過不足数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            // 棚卸日
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Datetime].Tag = InventInputResult.ct_Col_InventoryExeDay_Datetime;
            // 棚卸準備処理日付
            band.Columns[InventInputResult.ct_Col_InventoryPreprDay_Datetime].Tag = InventInputResult.ct_Col_InventoryPreprDay_Datetime;
            // 棚卸準備処理時間
            band.Columns[InventInputResult.ct_Col_InventoryPreprTim].Tag = InventInputResult.ct_Col_InventoryPreprTim;
            // 棚卸実施日
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // 棚卸実施日
            band.Columns[InventInputResult.ct_Col_InventoryDay].Tag = InventInputResult.ct_Col_InventoryDay;
            // 棚卸実施日(DateTime)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Tag = InventInputResult.ct_Col_InventoryDay_Year;
            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Tag = InventInputResult.ct_Col_InventoryDay_Month;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Tag = InventInputResult.ct_Col_InventoryDay_Day;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Tag = InventInputResult.ct_Col_InventoryDay_DayL;
            // 棚卸更新日
            band.Columns[InventInputResult.ct_Col_LastInventoryUpdate].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDiv].Tag = InventInputResult.ct_Col_InventoryNewDiv;
            // 棚卸新規追加区分名称
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Tag = InventInputResult.ct_Col_InventoryNewDivName;
            // マシン在庫額
            band.Columns[InventInputResult.ct_Col_StockMashinePrice].Tag = InventInputResult.ct_Col_StockMashinePrice;
            // 棚卸在庫額
            band.Columns[InventInputResult.ct_Col_InventoryStockPrice].Tag = InventInputResult.ct_Col_InventoryStockPrice;
            // 棚卸過不足金額
            band.Columns[InventInputResult.ct_Col_InventoryTlrncPrice].Tag = InventInputResult.ct_Col_InventoryTlrncPrice;
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDiv].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
            // 在庫委託受託区分名称
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
            // 集計区分
            band.Columns[InventInputResult.ct_Col_GrossDiv].Tag = InventInputResult.ct_Col_GrossDiv;
            // ボタン用カラム
            band.Columns[InventInputResult.ct_Col_Button].Tag = InventInputResult.ct_Col_Button;
            // 自行
            band.Columns[InventInputResult.ct_Col_RowSelf].Tag = InventInputResult.ct_Col_RowSelf;
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------------------------->>>>>
            // No
            band.Columns[InventInputResult.ct_Col_No].Tag = InventInputResult.ct_Col_No;
            // 調整用計算原価
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Tag = InventInputResult.ct_Col_AdjustCalcCost;
            // 棚卸過不足数(DBの値そのまま)
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCntBf].Tag = InventInputResult.ct_Col_InventoryTolerancCntBf;
            // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------------------------------------<<<<<
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        private DataRow GetBindDataRow(UltraGridRow row)
        {
            Object bindObject = row.ListObject;
            if (bindObject is DataRow)
            {
                return (DataRow)row.ListObject;
            }
            else if (bindObject is DataRowView)
            {
                return ((DataRowView)row.ListObject).Row;
            }
            else
            {
                return null;
            }            
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// データ表示UltraGrid初期処理(Tagプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Tag( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 表示状態設定(Tag)
			// 表示項目 ------------------------------------------------------
			// 作成日時
			band.Columns[ InventInputResult.ct_Col_CreateDateTime ].Tag = InventInputResult.ct_Col_CreateDateTime;
			// 更新日時
			band.Columns[ InventInputResult.ct_Col_UpdateDateTime ].Tag = InventInputResult.ct_Col_UpdateDateTime;
			// 企業コード
			band.Columns[ InventInputResult.ct_Col_EnterpriseCode ].Tag = InventInputResult.ct_Col_EnterpriseCode;
			// GUID
			band.Columns[ InventInputResult.ct_Col_FileHeaderGuid ].Tag = InventInputResult.ct_Col_FileHeaderGuid;
			// 更新従業員コード
			band.Columns[ InventInputResult.ct_Col_UpdEmployeeCode ].Tag = InventInputResult.ct_Col_UpdEmployeeCode;
			// 更新アセンブリID1
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId1 ].Tag = InventInputResult.ct_Col_UpdAssemblyId1;
			// 更新アセンブリID2
			band.Columns[ InventInputResult.ct_Col_UpdAssemblyId2 ].Tag = InventInputResult.ct_Col_UpdAssemblyId2;
			// 論理削除区分
			band.Columns[ InventInputResult.ct_Col_LogicalDeleteCode ].Tag = InventInputResult.ct_Col_LogicalDeleteCode;
			// 拠点コード
			band.Columns[ InventInputResult.ct_Col_SectionCode ].Tag = InventInputResult.ct_Col_SectionCode;
			// 拠点ガイド名称
			band.Columns[ InventInputResult.ct_Col_SectionGuideNm ].Tag = InventInputResult.ct_Col_SectionGuideNm;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番在庫マスタGUID
			//band.Columns[ InventInputResult.ct_Col_ProductStockGuid ].Tag = InventInputResult.ct_Col_ProductStockGuid;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 倉庫コード
			band.Columns[ InventInputResult.ct_Col_WarehouseCode ].Tag = InventInputResult.ct_Col_WarehouseCode;
			// 倉庫名称
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Tag = InventInputResult.ct_Col_WarehouseName;
			// メーカーコード
			band.Columns[ InventInputResult.ct_Col_MakerCode ].Tag = InventInputResult.ct_Col_MakerCode;
			// メーカー名称
			band.Columns[ InventInputResult.ct_Col_MakerName ].Tag = InventInputResult.ct_Col_MakerName;
			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].Tag = InventInputResult.ct_Col_GoodsCode;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Tag = InventInputResult.ct_Col_GoodsNo;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 品名
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Tag = InventInputResult.ct_Col_GoodsName;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
			//band.Columns[ InventInputResult.ct_Col_CellphoneModelCode ].Tag = InventInputResult.ct_Col_CellphoneModelCode;
			//// 機種名称
			//band.Columns[ InventInputResult.ct_Col_CellphoneModelName ].Tag = InventInputResult.ct_Col_CellphoneModelName;
			//// キャリアコード
			//band.Columns[ InventInputResult.ct_Col_CarrierCode ].Tag = InventInputResult.ct_Col_CarrierCode;
			//// キャリア名称
			//band.Columns[ InventInputResult.ct_Col_CarrierName ].Tag = InventInputResult.ct_Col_CarrierName;
			//// 系統色コード
			//band.Columns[ InventInputResult.ct_Col_SystematicColorCd ].Tag = InventInputResult.ct_Col_SystematicColorCd;
			//// 系統色名称
			//band.Columns[ InventInputResult.ct_Col_SystematicColorNm ].Tag = InventInputResult.ct_Col_SystematicColorNm;
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Tag = InventInputResult.ct_Col_WarehouseShelfNo;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Tag = InventInputResult.ct_Col_DuplicationShelfNo1;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品大分類コード
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreCode ].Tag = InventInputResult.ct_Col_LargeGoodsGanreCode;
			// 商品大分類名称
			band.Columns[ InventInputResult.ct_Col_LargeGoodsGanreName ].Tag = InventInputResult.ct_Col_LargeGoodsGanreName;
			// 商品中分類コード
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreCode ].Tag = InventInputResult.ct_Col_MediumGoodsGanreCode;
			// 商品中分類名称
			band.Columns[ InventInputResult.ct_Col_MediumGoodsGanreName ].Tag = InventInputResult.ct_Col_MediumGoodsGanreName;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 事業者コード
			//band.Columns[ InventInputResult.ct_Col_CarrierEpCode ].Tag = InventInputResult.ct_Col_CarrierEpCode;
			//// 事業者名称
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Tag = InventInputResult.ct_Col_CarrierEpName;
            // グループコード
            band.Columns[ InventInputResult.ct_Col_DetailGoodsGanreCode ].Tag = InventInputResult.ct_Col_DetailGoodsGanreCode;
            // グループコード名称
            band.Columns[ InventInputResult.ct_Col_DetailGoodsGanreName ].Tag = InventInputResult.ct_Col_DetailGoodsGanreName;
            // 自社分類コード
            band.Columns[ InventInputResult.ct_Col_EnterpriseGanreCode ].Tag = InventInputResult.ct_Col_EnterpriseGanreCode;
            // 自社分類名称
            band.Columns[ InventInputResult.ct_Col_EnterpriseGanreName ].Tag = InventInputResult.ct_Col_EnterpriseGanreName;
            // ＢＬ品番
            band.Columns[ InventInputResult.ct_Col_BLGoodsCode ].Tag = InventInputResult.ct_Col_BLGoodsCode;
            // ＢＬ品名
            band.Columns[ InventInputResult.ct_Col_BLGoodsName ].Tag = InventInputResult.ct_Col_BLGoodsName;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 得意先コード
			band.Columns[ InventInputResult.ct_Col_CustomerCode ].Tag = InventInputResult.ct_Col_CustomerCode;
			// 得意先名称
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Tag = InventInputResult.ct_Col_CustomerName;
			// 得意先名称2
			band.Columns[ InventInputResult.ct_Col_CustomerName2 ].Tag = InventInputResult.ct_Col_CustomerName2;
			// 委託先コード
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// 委託先名称
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// 委託先名称2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 仕入日
			//band.Columns[ InventInputResult.ct_Col_StockDate ].Tag = InventInputResult.ct_Col_StockDate;
			//// 入荷日
			//band.Columns[ InventInputResult.ct_Col_ArrivalGoodsDay ].Tag = InventInputResult.ct_Col_ArrivalGoodsDay;
            //// 製造番号
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Tag = InventInputResult.ct_Col_ProductNumber;
            //// 商品電話番号1
            //band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Tag = InventInputResult.ct_Col_StockTelNo1;
            //// 変更前商品電話番号1
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ].Tag = InventInputResult.ct_Col_BfStockTelNo1;
            //// 商品電話番号1変更フラグ
            //band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo1ChgFlg;
            //// 商品電話番号2
            //band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Tag = InventInputResult.ct_Col_StockTelNo2;
            //// 変更前商品電話番号2
            //band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ].Tag = InventInputResult.ct_Col_BfStockTelNo2;
            //// 商品電話番号2変更フラグ
            //band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ].Tag = InventInputResult.ct_Col_StkTelNo2ChgFlg;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // JANコード
			band.Columns[ InventInputResult.ct_Col_Jan ].Tag = InventInputResult.ct_Col_Jan;
			// 仕入単価
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].Tag = InventInputResult.ct_Col_StockUnitPrice;
			// 変更前仕入単価
			band.Columns[ InventInputResult.ct_Col_BfStockUnitPrice ].Tag = InventInputResult.ct_Col_BfStockUnitPrice;
			// 仕入単価変更フラグ
			band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ].Tag = InventInputResult.ct_Col_StkUnitPriceChgFlg;
			// 在庫区分
			band.Columns[ InventInputResult.ct_Col_StockDiv ].Tag = InventInputResult.ct_Col_StockDiv;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
            //band.Columns[ InventInputResult.ct_Col_StockState ].Tag = InventInputResult.ct_Col_StockState;
            //// 移動状態
            //band.Columns[ InventInputResult.ct_Col_MoveStatus ].Tag = InventInputResult.ct_Col_MoveStatus;
            //// 商品状態
            //band.Columns[InventInputResult.ct_Col_GoodsCodeStatus].Tag = InventInputResult.ct_Col_GoodsCodeStatus;
            //// 製番管理区分
			//band.Columns[ InventInputResult.ct_Col_PrdNumMngDiv ].Tag = InventInputResult.ct_Col_PrdNumMngDiv;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 最終仕入年月日
			band.Columns[ InventInputResult.ct_Col_LastStockDate ].Tag = InventInputResult.ct_Col_LastStockDate;
			// 在庫数
			band.Columns[ InventInputResult.ct_Col_StockTotal ].Tag = InventInputResult.ct_Col_StockTotal;
			// 委託先コード
			band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ].Tag = InventInputResult.ct_Col_ShipCustomerCode;
			// 委託先名称
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Tag = InventInputResult.ct_Col_ShipCustomerName;
			// 委託先名称2
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ].Tag = InventInputResult.ct_Col_ShipCustomerName2;
			// 棚卸在庫数
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Tag = InventInputResult.ct_Col_InventoryStockCnt;
			// 棚卸過不足数
			band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            // 棚卸日
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Tag = InventInputResult.ct_Col_InventoryExeDay_Str;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 棚卸準備処理日付
			band.Columns[ InventInputResult.ct_Col_InventoryPreprDay ].Tag = InventInputResult.ct_Col_InventoryPreprDay;
			// 棚卸準備処理時間
			band.Columns[ InventInputResult.ct_Col_InventoryPreprTim ].Tag = InventInputResult.ct_Col_InventoryPreprTim;
			// 棚卸実施日
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// 棚卸実施日
			band.Columns[ InventInputResult.ct_Col_InventoryDay ].Tag = InventInputResult.ct_Col_InventoryDay;
			// 棚卸実施日(DateTime)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Datetime ].Tag = InventInputResult.ct_Col_InventoryDay_Datetime;
			// 棚卸実施日(年 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].Tag = InventInputResult.ct_Col_InventoryDay_Year;
			// 棚卸実施日(年 ラベル)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Tag = InventInputResult.ct_Col_InventoryDay_YearL;
			// 棚卸実施日(月 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Tag = InventInputResult.ct_Col_InventoryDay_Month;
			// 棚卸実施日(月 ラベル)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Tag = InventInputResult.ct_Col_InventoryDay_MonthL;
			// 棚卸実施日(日 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Tag = InventInputResult.ct_Col_InventoryDay_Day;
			// 棚卸実施日(日 ラベル)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Tag = InventInputResult.ct_Col_InventoryDay_DayL;

			// 棚卸更新日
			band.Columns[ InventInputResult.ct_Col_LastInventoryUpdate ].Tag = InventInputResult.ct_Col_LastInventoryUpdate;
			// 棚卸新規追加区分
			band.Columns[ InventInputResult.ct_Col_InventoryNewDiv ].Tag = InventInputResult.ct_Col_InventoryNewDiv;
			// 棚卸新規追加区分名称
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].Tag = InventInputResult.ct_Col_InventoryNewDivName;
            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // マシン在庫額
            band.Columns[ InventInputResult.ct_Col_StockMashinePrice ].Tag = InventInputResult.ct_Col_StockMashinePrice;
            // 棚卸在庫額
            band.Columns[ InventInputResult.ct_Col_InventoryStockPrice ].Tag = InventInputResult.ct_Col_InventoryStockPrice;
            // 棚卸過不足金額
            band.Columns[ InventInputResult.ct_Col_InventoryTlrncPrice ].Tag = InventInputResult.ct_Col_InventoryTlrncPrice;
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 在庫委託受託区分
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ].Tag = InventInputResult.ct_Col_StockTrtEntDiv;
			// 在庫委託受託区分名称
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Tag = InventInputResult.ct_Col_StockTrtEntDivName;
			// 集計区分
			band.Columns[ InventInputResult.ct_Col_GrossDiv ].Tag = InventInputResult.ct_Col_GrossDiv;
			// ボタン用カラム
			band.Columns[ InventInputResult.ct_Col_Button ].Tag = InventInputResult.ct_Col_Button;
			// 自行
			band.Columns[ InventInputResult.ct_Col_RowSelf ].Tag = InventInputResult.ct_Col_RowSelf;
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ データ表示UltraGrid初期処理(CellActivationプロパティ)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(CellActivationプロパティ)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_CellActivation(UltraGridBand band)
        {
            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].CellActivation = Activation.NoEdit;
            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].CellActivation = Activation.NoEdit;
            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].CellActivation = Activation.NoEdit;
            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].CellActivation = Activation.NoEdit;
            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].CellActivation = Activation.AllowEdit;
            // 過不足数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].CellActivation = Activation.NoEdit;
            // 棚卸日
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Datetime].CellActivation = Activation.NoEdit;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].CellActivation = Activation.AllowEdit;
            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].CellActivation = Activation.Disabled;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].CellActivation = Activation.AllowEdit;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].CellActivation = Activation.Disabled;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].CellActivation = Activation.AllowEdit;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].CellActivation = Activation.Disabled;
            // ボタン用カラム
            band.Columns[InventInputResult.ct_Col_Button].CellActivation = Activation.ActivateOnly;
            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].CellActivation = Activation.AllowEdit;
            // 倉庫
            band.Columns[InventInputResult.ct_Col_WarehouseName].CellActivation = Activation.NoEdit;
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].CellActivation = Activation.AllowEdit;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].CellActivation = Activation.AllowEdit;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].CellActivation = Activation.AllowEdit;
            // メーカー
            band.Columns[InventInputResult.ct_Col_MakerName].CellActivation = Activation.NoEdit;
            // 仕入先名称
            band.Columns[InventInputResult.ct_Col_SupplierName].CellActivation = Activation.NoEdit;
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].CellActivation = Activation.NoEdit;
            // No                                                                               //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_No].CellActivation = Activation.NoEdit;       //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// データ表示UltraGrid初期処理(CellActivationプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_CellActivation( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 入力設定
			// 入力設定 ------------------------------------------------------
			// 棚卸新規追加区分
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryNewDivName );

			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_GoodsCode);
            SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_GoodsNo);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

			// 品名
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_GoodsName );

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_ProductNumber );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 在庫数
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTotal );

			// 棚卸在庫数
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryStockCnt );

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 差異数
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryTolerancCnt );

            // 棚卸日
            SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryExeDay_Str);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 棚卸実施日(年 入力)
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryDay_Year );
			// 棚卸実施日(年 ラベル)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryDay_YearL);
            SetCellClickAction(band.Columns, Activation.Disabled, InventInputResult.ct_Col_InventoryDay_YearL);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 棚卸実施日(月 入力)
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryDay_Month );
			// 棚卸実施日(月 ラベル)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryDay_MonthL);
            SetCellClickAction(band.Columns, Activation.Disabled, InventInputResult.ct_Col_InventoryDay_MonthL);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 棚卸実施日(日 入力)
			SetCellClickAction( band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_InventoryDay_Day );
			// 棚卸実施日(日 ラベル)
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_InventoryDay_DayL);
            SetCellClickAction(band.Columns, Activation.Disabled, InventInputResult.ct_Col_InventoryDay_DayL);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

			// ボタン用カラム
			SetCellClickAction( band.Columns, Activation.ActivateOnly, InventInputResult.ct_Col_Button );

			// 仕入単価
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //SetCellClickAction(band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockUnitPrice);
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockUnitPrice);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 電話番号1
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo1 );
		    //
			//// 電話番号2
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 倉庫
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_WarehouseName );

            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_WarehouseShelfNo);

            // 重複棚番１
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_DuplicationShelfNo1);

            // 重複棚番２
            SetCellClickAction(band.Columns, Activation.AllowEdit, InventInputResult.ct_Col_DuplicationShelfNo2);
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
            
            // メーカー
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_MakerName );

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者
			//SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_CarrierEpName );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 得意先名称
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_CustomerName );

			// 委託先名称
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_ShipCustomerName );

			// 在庫委託受託区分
			SetCellClickAction( band.Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTrtEntDivName );
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ データ表示UltraGrid初期処理(Widthプロパティ)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(Widthプロパティ)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>              棚卸新規追加区分のWidthの修正</br>
        /// </remarks>
        private void InitialInventInputGrid_Width(UltraGridBand band)
        {
            // 棚卸新規追加区分
            //band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 55; // DEL 2009/12/03
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 90;  // ADD 2009/12/03
            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].Width = 120;
            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].Width = 255;
            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Width = 100;
            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Width = 100;
            // 過不足数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Width = 100;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 90;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 50;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 50;
            // ボタン用カラム
            band.Columns[InventInputResult.ct_Col_Button].Width = 20;
            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Width = 111;
            // 倉庫
            band.Columns[InventInputResult.ct_Col_WarehouseName].Width = 120;
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Width = 120;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Width = 120;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Width = 120;
            // メーカー
            band.Columns[InventInputResult.ct_Col_MakerName].Width = 120;
            // 仕入先名称
            band.Columns[InventInputResult.ct_Col_SupplierName].Width = 120;
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Width = 80;
            // No                                                           //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_No].Width = 60;           //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// データ表示UltraGrid初期処理(Widthプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Width( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// 幅設定

			// Todo:幅設定コメントアウト中 ------------------------------------------------------
			// 棚卸新規追加区分
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 40;
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Width = 55;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].Width = 120;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Width = 120;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

			// 品名
			band.Columns[ InventInputResult.ct_Col_GoodsName ].Width = 255;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].Width = 150;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 在庫数
            //band.Columns[ InventInputResult.ct_Col_StockTotal ].Width = 60;

            //// 棚卸在庫数
            //band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].Width = 60;

            //// 差異数
            //band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Width = 60;

            //// 棚卸実施日(年 入力)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 50;
            //// 棚卸実施日(年 ラベル)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Width = 20;
            //// 棚卸実施日(月 入力)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 30;
            //// 棚卸実施日(月 ラベル)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Width = 20;
            //// 棚卸実施日(日 入力)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 30;
            //// 棚卸実施日(日 ラベル)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Width = 20;

            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Width = 90;

            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Width = 90;

            // 棚卸日
            //band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Width = 120;
            
            //// 棚卸実施日(年 入力)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].Width = 42;
            //// 棚卸実施日(年 ラベル)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_YearL ].Width = 25;
            //// 棚卸実施日(月 入力)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].Width = 26;
            //// 棚卸実施日(月 ラベル)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_MonthL ].Width = 25;
            //// 棚卸実施日(日 入力)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].Width = 26;
            //// 棚卸実施日(日 ラベル)
            //band.Columns[ InventInputResult.ct_Col_InventoryDay_DayL ].Width = 25;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 90;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 50;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 50;
            // 棚卸実施日(年 ラベル)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Width = 25;
            // 棚卸実施日(月 ラベル)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Width = 25;
            // 棚卸実施日(日 ラベル)
            //band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Width = 25;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

			// ボタン用カラム
			band.Columns[ InventInputResult.ct_Col_Button ].Width = 20;

			// 仕入単価
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_StockUnitPrice].Width = 80;
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Width = 111;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 電話番号1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].Width = 120;
		    //
			//// 電話番号2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].Width = 120;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 倉庫
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].Width = 120;

            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].Width = 120;

            // 重複棚番１
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].Width = 120;

            // 重複棚番２
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].Width = 120;
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            // メーカー
			band.Columns[ InventInputResult.ct_Col_MakerName ].Width = 120;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].Width = 120;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 得意先名称
			band.Columns[ InventInputResult.ct_Col_CustomerName ].Width = 120;

			// 委託先名称
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].Width = 120;

			// 在庫委託受託区分
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].Width = 80;
			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ データ表示UltraGrid初期処理(CellAppearanceプロパティ)
        /// <summary>
		/// データ表示UltraGrid初期処理(CellAppearanceプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_CellAppearance( UltraGridBand band )
		{
			#region// テキスト表示位置
			// テキスト表示位置 ------------------------------------------------------
			// 在庫数
			band.Columns[ InventInputResult.ct_Col_StockTotal ].CellAppearance.TextHAlign = HAlign.Right;
			// 棚卸在庫数
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].CellAppearance.TextHAlign = HAlign.Right;
            // 差異数
			band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].CellAppearance.TextHAlign = HAlign.Right;
            // 変更前差異数
			band.Columns[ InventInputResult.ct_Col_BfChgInventoryToleCnt ].CellAppearance.TextHAlign = HAlign.Right;
            // 棚卸実施日
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].CellAppearance.TextHAlign = HAlign.Right;
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].CellAppearance.TextHAlign = HAlign.Right;
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].CellAppearance.TextHAlign = HAlign.Right;
			// ボタン用カラム
			band.Columns[ InventInputResult.ct_Col_Button ].CellAppearance.TextHAlign = HAlign.Center;
			// 仕入単価
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].CellAppearance.TextHAlign = HAlign.Right;
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 棚卸日
            //band.Columns[ InventInputResult.ct_Col_InventoryExeDay_Datetime ].CellAppearance.TextHAlign = HAlign.Center;
            //// 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            band.Columns[InventInputResult.ct_Col_InventoryExeDay_Datetime].CellAppearance.TextHAlign = HAlign.Center;
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
            //No                                                                                    //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_No].CellAppearance.TextHAlign = HAlign.Right;     //ADD 2009/05/14 不具合対応[13260]
            #endregion
		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(CellClickActionプロパティ)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(CellClickActionプロパティ)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_CellClickAction(UltraGridBand band)
        {
            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].CellClickAction = CellClickAction.CellSelect;
            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].CellClickAction = CellClickAction.CellSelect;
            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].CellClickAction = CellClickAction.CellSelect;
            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].CellClickAction = CellClickAction.CellSelect;
            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].CellClickAction = CellClickAction.EditAndSelectText;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].CellClickAction = CellClickAction.EditAndSelectText;
            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].CellClickAction = CellClickAction.CellSelect;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].CellClickAction = CellClickAction.EditAndSelectText;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].CellClickAction = CellClickAction.CellSelect;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].CellClickAction = CellClickAction.EditAndSelectText;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].CellClickAction = CellClickAction.CellSelect;
            // ボタン用カラム
            band.Columns[InventInputResult.ct_Col_Button].CellClickAction = CellClickAction.EditAndSelectText;
            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].CellClickAction = CellClickAction.CellSelect;
            // 倉庫
            band.Columns[InventInputResult.ct_Col_WarehouseName].CellClickAction = CellClickAction.CellSelect;
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].CellClickAction = CellClickAction.CellSelect;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].CellClickAction = CellClickAction.CellSelect;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].CellClickAction = CellClickAction.CellSelect;
            // メーカー
            band.Columns[InventInputResult.ct_Col_MakerName].CellClickAction = CellClickAction.CellSelect;
            // 仕入先名称
            band.Columns[InventInputResult.ct_Col_SupplierName].CellClickAction = CellClickAction.CellSelect;
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].CellClickAction = CellClickAction.CellSelect;
            // No                                                                                       //ADD 2009/05/14 不具合対応[13260]
            band.Columns[InventInputResult.ct_Col_No].CellClickAction = CellClickAction.CellSelect;     //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// データ表示UltraGrid初期処理(CellClickActionプロパティ)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_CellClickAction( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// CellClickAction
			// CellClickAction ------------------------------------------------------
			// 入力設定 ------------------------------------------------------
			// 棚卸新規追加区分
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryNewDivName );

			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //SetCellActivation(band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_GoodsCode);
            SetCellActivation(band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_GoodsNo);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

			// 品名
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_GoodsName );

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_ProductNumber );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 在庫数
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTotal );

			// 棚卸在庫数
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryStockCnt );

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 差異数
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryTolerancCnt );
            // 棚卸日
            //SetCellActivation(band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryExeDay_Str);
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            
            // 棚卸実施日(年 入力)
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryDay_Year );
			// 棚卸実施日(年 ラベル)
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryDay_YearL );
			// 棚卸実施日(月 入力)
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryDay_Month );
			// 棚卸実施日(月 ラベル)
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryDay_MonthL );
			// 棚卸実施日(日 入力)
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_InventoryDay_Day );
			// 棚卸実施日(日 ラベル)
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_InventoryDay_DayL );

			// ボタン用カラム
			SetCellActivation( band.Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_Button );

			// 仕入単価
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockUnitPrice );

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 電話番号1
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo1 );
		    //
			//// 電話番号2
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo2 );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 倉庫
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_WarehouseName );

            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_WarehouseShelfNo );

            // 重複棚番１
            SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_DuplicationShelfNo1 );

            // 重複棚番２
            SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_DuplicationShelfNo2 );
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            // メーカー
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_MakerName );

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者
			//SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_CarrierEpName );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 得意先名称
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_CustomerName );

			// 委託先名称
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_ShipCustomerName );

			// 在庫委託受託区分
			SetCellActivation( band.Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTrtEntDivName );

			#endregion
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ データ表示UltraGrid初期処理(Styleプロパティ関連)
        /// <summary>
		/// データ表示UltraGrid初期処理(Styleプロパティ関連)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Style( UltraGridBand band )
		{
			#region// 列スタイル
 			// ボタン用カラム
            band.Columns[ InventInputResult.ct_Col_Button ].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            band.Columns[ InventInputResult.ct_Col_Button ].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            band.Columns[ InventInputResult.ct_Col_Button ].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            band.Columns[ InventInputResult.ct_Col_Button ].CellButtonAppearance.ImageHAlign = HAlign.Center;
            band.Columns[ InventInputResult.ct_Col_Button ].Header.Caption = "";
			#endregion
		}
		#endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◎ データ表示UltraGrid初期処理(TabStopプロパティ)
		/// <summary>
		/// データ表示UltraGrid初期処理(TabStopプロパティ関連)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_TabStop( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// TabStop

			// 表示項目 ------------------------------------------------------
			// 棚卸新規追加区分
			band.Columns[ InventInputResult.ct_Col_InventoryNewDivName ].TabStop = true;

			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_GoodsCode].TabStop = true;
            band.Columns[InventInputResult.ct_Col_GoodsNo].TabStop = true;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

			// 品名
			band.Columns[ InventInputResult.ct_Col_GoodsName ].TabStop = true;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
			//band.Columns[ InventInputResult.ct_Col_ProductNumber ].TabStop = true;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 在庫数
			band.Columns[ InventInputResult.ct_Col_StockTotal ].TabStop = true;

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 差異数
			//band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ].TabStop = true;
            //// 棚卸日
            //band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].TabStop = true;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

			// 仕入単価
			band.Columns[ InventInputResult.ct_Col_StockUnitPrice ].TabStop = true;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 電話番号1
			//band.Columns[ InventInputResult.ct_Col_StockTelNo1 ].TabStop = true;
            //
			//// 電話番号2
			//band.Columns[ InventInputResult.ct_Col_StockTelNo2 ].TabStop = true;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 倉庫
			band.Columns[ InventInputResult.ct_Col_WarehouseName ].TabStop = true;

            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番
            band.Columns[ InventInputResult.ct_Col_WarehouseShelfNo ].TabStop = true;

            // 重複棚番１
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo1 ].TabStop = true;

            // 重複棚番２
            band.Columns[ InventInputResult.ct_Col_DuplicationShelfNo2 ].TabStop = true;
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            // メーカー
			band.Columns[ InventInputResult.ct_Col_MakerName ].TabStop = true;

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者
			//band.Columns[ InventInputResult.ct_Col_CarrierEpName ].TabStop = true;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			// 得意先
			band.Columns[ InventInputResult.ct_Col_CustomerName ].TabStop = true;

			// 委託先
			band.Columns[ InventInputResult.ct_Col_ShipCustomerName ].TabStop = true;

			// 在庫委託受託区分
			band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ].TabStop = true;

            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].TabStop = true;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].TabStop = true;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].TabStop = true;

			// 棚卸在庫数
			band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ].TabStop = true;
			// 棚卸実施日(年 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Year ].TabStop = true;
			// 棚卸実施日(月 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Month ].TabStop = true;
			// 棚卸実施日(日 入力)
			band.Columns[ InventInputResult.ct_Col_InventoryDay_Day ].TabStop = true;
			#endregion
		}
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ データ表示UltraGrid初期処理(Formatプロパティ)
        /// <summary>
		/// データ表示UltraGrid初期処理(Formatプロパティ関連)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_Format( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
			#region// Format
            // 仕入単価
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //band.Columns[InventInputResult.ct_Col_StockUnitPrice].Format = "#,##0;-#,##0;0";
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Format        = "#,##0.00;-#,##0.00;0.00";

            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Format            = "#,##0.00;-#,##0.00;0.00";

            // 棚卸数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Format     = "#,##0.00;-#,##0.00;0.00";

            // 差異数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Format = "#,##0.00;-#,##0.00;0.00";

            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Format     = "0000年;0000年;''";

            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Format    = "#0月;#0月;''";

            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Format      = "#0日;#0日;''";
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            #endregion
		}
		#endregion

		#region ◎ データ表示UltraGrid初期処理(GroupSettingプロパティ関連)
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データ表示UltraGrid初期処理(GroupSettingプロパティ関連)
        /// </summary>
        /// <param name="band">データ列のセット</param>
        /// <remarks>
        /// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void InitialInventInputGrid_GroupSetting(UltraGridBand band)
        {
            int vPosition = 1;

            // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------------------------->>>>>
            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_No].Header.Caption = "No";
            band.Columns[InventInputResult.ct_Col_No].Header.VisiblePosition = vPosition++;
            // ---ADD 2009/05/14 不具合対応[13260] --------------------------------------------------------<<<<<
            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.Caption = "区分";
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.VisiblePosition = vPosition++;
            // メーカー
            band.Columns[InventInputResult.ct_Col_MakerName].Header.Caption = "メーカー";
            band.Columns[InventInputResult.ct_Col_MakerName].Header.VisiblePosition = vPosition++;
            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.VisiblePosition = vPosition++;
            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsName].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.VisiblePosition = vPosition++;
            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.Caption = band.Columns[InventInputResult.ct_Col_StockTotal].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.VisiblePosition = vPosition++;
            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.Caption = band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.Caption;
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.VisiblePosition = vPosition++;
            // 過不足数
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Header.Caption = band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Header.Caption;
            band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.Caption = "実施日 年";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.Caption = "月";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.Caption = "日";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Header.VisiblePosition = vPosition++;
            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.Caption = band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.VisiblePosition = vPosition++;
            // 倉庫
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.Caption = "倉庫";
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.VisiblePosition = vPosition++;
            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.Caption = "棚番";
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.VisiblePosition = vPosition++;
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.Caption = "重複棚番１";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.VisiblePosition = vPosition++;
            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.Caption = "重複棚番２";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.VisiblePosition = vPosition++;
            // 仕入先
            band.Columns[InventInputResult.ct_Col_SupplierName].Header.Caption = "仕入先";
            band.Columns[InventInputResult.ct_Col_SupplierName].Header.VisiblePosition = vPosition++;
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.Caption = "在庫区分";
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.VisiblePosition = vPosition++;

            // ---ADD 2009/05/14 不具合対応[13260] --------------------------------------------------->>>>>
            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Header.Caption = "調整用計算原価";
            band.Columns[InventInputResult.ct_Col_AdjustCalcCost].Header.VisiblePosition = vPosition++;
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------<<<<<
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// データ表示UltraGrid初期処理(GroupSettingプロパティ関連)
		/// </summary>
		/// <param name="band">データ列のセット</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void InitialInventInputGrid_GroupSetting( Infragistics.Win.UltraWinGrid.UltraGridBand band )
		{
            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            int vPosition = 1;

            // 棚卸新規追加区分
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.Caption = "区分";
            band.Columns[InventInputResult.ct_Col_InventoryNewDivName].Header.VisiblePosition = vPosition++;

            // メーカー
            band.Columns[InventInputResult.ct_Col_MakerName].Header.Caption = "メーカー";
            band.Columns[InventInputResult.ct_Col_MakerName].Header.VisiblePosition = vPosition++;

            // 品番
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsNo].Header.VisiblePosition = vPosition++;

            // 品名
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.Caption = band.Columns[InventInputResult.ct_Col_GoodsName ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_GoodsName].Header.VisiblePosition = vPosition++;

            // 在庫数
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.Caption = band.Columns[InventInputResult.ct_Col_StockTotal ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockTotal].Header.VisiblePosition = vPosition++;

            // 棚卸在庫数
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.Caption = band.Columns[InventInputResult.ct_Col_InventoryStockCnt ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_InventoryStockCnt].Header.VisiblePosition = vPosition++;

            // 棚卸実施日(年 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.Caption = "実施日 年";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Year].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(年 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_YearL].Header.VisiblePosition = vPosition++;

            // 棚卸実施日(月 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.Caption = "月";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Month].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(月 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Header.VisiblePosition = vPosition++;

            // 棚卸実施日(日 入力)
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.Caption = "日";
            band.Columns[InventInputResult.ct_Col_InventoryDay_Day].Header.VisiblePosition = vPosition++;
            // 棚卸実施日(日 ラベル)
            band.Columns[InventInputResult.ct_Col_InventoryDay_DayL].Header.VisiblePosition = vPosition++;

            // 仕入単価
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.Caption = band.Columns[InventInputResult.ct_Col_StockUnitPrice ].Header.Caption;
            band.Columns[InventInputResult.ct_Col_StockUnitPrice].Header.VisiblePosition = vPosition++;

            // 倉庫
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.Caption = "倉庫";
            band.Columns[InventInputResult.ct_Col_WarehouseName].Header.VisiblePosition = vPosition++;

            // 棚番
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.Caption = "棚番";
            band.Columns[InventInputResult.ct_Col_WarehouseShelfNo].Header.VisiblePosition = vPosition++;
           
            // 重複棚番１
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.Caption = "重複棚番１";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1].Header.VisiblePosition = vPosition++;

            // 重複棚番２
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.Caption = "重複棚番２";
            band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2].Header.VisiblePosition = vPosition++;

            // 得意先
            band.Columns[InventInputResult.ct_Col_CustomerName].Header.Caption = "仕入先";
            band.Columns[InventInputResult.ct_Col_CustomerName].Header.VisiblePosition = vPosition++;

            // 委託先
            band.Columns[InventInputResult.ct_Col_ShipCustomerName].Header.Caption = "委託先";
            band.Columns[InventInputResult.ct_Col_ShipCustomerName].Header.VisiblePosition = vPosition++;

            // 在庫委託受託区分
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.Caption = "在庫区分";
            band.Columns[InventInputResult.ct_Col_StockTrtEntDivName].Header.VisiblePosition = vPosition++;
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            #region// GroupSetting
            //Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup;
            //// 新規区分
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_InventoryNewDiv), "区分");
            //ultraGridGroup = band.Groups.Add();
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryNewDiv]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryNewDivName]);
            //ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryNewDiv;

            //// 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            //// メーカー
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_MakerCode), "メーカー");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_MakerCode]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_MakerName]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_MakerCode;
            //// 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            
            //// 品番
            //// 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_GoodsCode), band.Columns[InventInputResult.ct_Col_GoodsCode].Header.Caption);
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_GoodsCode ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_GoodsCode;
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_GoodsNo), band.Columns[InventInputResult.ct_Col_GoodsNo].Header.Caption);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_GoodsNo]);
            //ultraGridGroup.Tag = InventInputResult.ct_Col_GoodsNo;
            //// 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

            //// 品名
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_GoodsName ), band.Columns[InventInputResult.ct_Col_GoodsName ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_GoodsName ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_GoodsName;

            //// 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 製造番号
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_ProductNumber ), band.Columns[InventInputResult.ct_Col_ProductNumber ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ProductNumber ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_ProductNumber;
            //// 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //// 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 単価
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockUnitPrice ), band.Columns[InventInputResult.ct_Col_StockUnitPrice ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockUnitPrice ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_StockUnitPrice;
            //// 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

            //// 帳簿数
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTotal ), band.Columns[InventInputResult.ct_Col_StockTotal ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTotal ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTotal;

            //// 棚卸在庫数
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_InventoryStockCnt ), band.Columns[InventInputResult.ct_Col_InventoryStockCnt ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_InventoryStockCnt ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryStockCnt;

            //// 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 差異数
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_InventoryTolerancCnt ), band.Columns[InventInputResult.ct_Col_InventoryTolerancCnt ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_InventoryTolerancCnt ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfChgInventoryToleCnt ] );
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryTolerancCnt;
            //// 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

            //// 棚卸実施日
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_InventoryDay), band.Columns[InventInputResult.ct_Col_InventoryDay].Header.Caption);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Datetime]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Year]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_YearL]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Month]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_MonthL]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_Day]);
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryDay_DayL]);
            //ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryDay;

            //ultraGridGroup.CellAppearance.BorderColor = Color.FromArgb(1, 68, 208);

            //// 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            //// 単価
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockUnitPrice ), band.Columns[InventInputResult.ct_Col_StockUnitPrice ].Header.Caption );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockUnitPrice ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkUnitPriceChgFlg ] );
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockUnitPrice;

            ////// 棚卸日
            ////ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_InventoryExeDay_Str), band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str].Header.Caption);
            ////ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_InventoryExeDay_Str]);
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_InventoryExeDay_Str;
            //// 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            //// 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 電話番号1
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo1 ), band.Columns[InventInputResult.ct_Col_StockTelNo1 ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo1 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo1 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo1ChgFlg ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo1;
            ////
            ////// 電話番号2
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTelNo2 ), band.Columns[InventInputResult.ct_Col_StockTelNo2 ].Header.Caption );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTelNo2 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_BfStockTelNo2 ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StkTelNo2ChgFlg ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_StockTelNo2;
            //// 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //// 倉庫
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_WarehouseCode ), "倉庫" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_WarehouseCode ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_WarehouseName ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_WarehouseCode;

            //// 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            //// 棚番
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_WarehouseShelfNo), "棚番");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_WarehouseShelfNo]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_WarehouseShelfNo;

            //// 重複棚番１
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_DuplicationShelfNo1), "重複棚番１");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_DuplicationShelfNo1]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_DuplicationShelfNo1;

            //// 重複棚番２
            //ultraGridGroup = band.Groups.Add(string.Format("Group_{0}", InventInputResult.ct_Col_DuplicationShelfNo2), "重複棚番２");
            //ultraGridGroup.Columns.Add(band.Columns[InventInputResult.ct_Col_DuplicationShelfNo2]);
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_DuplicationShelfNo2;
            //// 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            //// 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// メーカー
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_MakerCode ), "メーカー" );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_MakerCode ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_MakerName ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_MakerCode;
            //// 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

            //// 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 事業者
            ////ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_CarrierEpCode ), "事業者" );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CarrierEpCode ] );
            ////ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CarrierEpName ] );
            ////ultraGridGroup.Hidden = true;
            ////ultraGridGroup.Tag = InventInputResult.ct_Col_CarrierEpCode;
            //// 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            //// 仕入先
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_CustomerCode ), "仕入先" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CustomerCode ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CustomerName ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_CustomerName2 ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_CustomerCode;

            //// 委託先
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_ShipCustomerCode ), "委託先" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ShipCustomerCode ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ShipCustomerName ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_ShipCustomerName2 ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_CustomerCode;

            //// 在庫委受託区分
            //ultraGridGroup = band.Groups.Add( string.Format( "Group_{0}", InventInputResult.ct_Col_StockTrtEntDiv ), "在庫区分" );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTrtEntDiv ] );
            //ultraGridGroup.Columns.Add( band.Columns[ InventInputResult.ct_Col_StockTrtEntDivName ] );
            //ultraGridGroup.Hidden = true;
            //ultraGridGroup.Tag = InventInputResult.ct_Col_StockTrtEntDiv;
			#endregion
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region [Grid過不足更新済み行Enable制御]
        // -- ADD 2009/09/11 ------------------------------------>>>
        /// <summary>
        /// Grid過不足更新済み行Enable制御
		/// </summary>
        private void SetGridEnabledTolUpd()
        {
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                // 過不足更新済みのレコードは編集不可とする
                if ((Int32)gridRow.Cells[InventInputResult.ct_Col_ToleranceUpdateCd].Value == 1)
                {
                    gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_StockUnitPrice].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo1].Activation = Activation.NoEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo2].Activation = Activation.NoEdit;
                }
                else
                {
                    gridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_StockUnitPrice].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo1].Activation = Activation.AllowEdit;
                    gridRow.Cells[InventInputResult.ct_Col_DuplicationShelfNo2].Activation = Activation.AllowEdit;
                }
            }
        }
        // -- ADD 2009/09/11 ------------------------------------<<<
        #endregion

        #region ◆ バーコード入力時処理
        #region ◎ バーコード入力メイン処理
        /// <summary>
		/// バーコード入力メイン処理
		/// </summary>
		private int ReadBarCodeMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			try
			{
				// 展開用Dictionaryの作成
				Dictionary<Guid, InventoryStockInputBarCode> barCodeDic = MakeReadBarCodeDictionary();
				// 画面呼び出し
				if ( this._readBarcodeForm == null )
				{
					this._readBarcodeForm = new MAZAI05140UA();
				}

				DialogResult dlgResult = this._readBarcodeForm.ShowDialog( this, ref barCodeDic );
				// データ展開
				if ( dlgResult == DialogResult.OK )
				{
					//this.uGrid_InventInput.BeginUpdate();

					Dictionary<Guid, InventoryStockInputBarCode> newBarCodeDic = new Dictionary<Guid,InventoryStockInputBarCode>();
					// データ展開
					// DataView divDataDv; // 2007.07.19 kubo del
					DataRow divDataDr;
					InventoryStockInputBarCode isiBarCode;
					Guid keyGuid;

					// 2007.07.27 kubo add -------------->
					double addnewRowCnt = 0; 
					double defInventStock = 0; 
					// 2007.07.27 kubo add <--------------

					foreach( KeyValuePair<Guid, InventoryStockInputBarCode> dic in barCodeDic )
					{
						keyGuid = (Guid)dic.Key;
						isiBarCode = (InventoryStockInputBarCode)dic.Value;

						// データが新規行ならば新規行Dictionaryに追加してcontinue。
						if ( isiBarCode.Status == 1 )
						{
							newBarCodeDic.Add( keyGuid, isiBarCode );
							continue;
						}

						// 対象行の取得(Guidは一意のものなので、Guidだけ指定すればOK!)
						#region // 2007.07.19 kubo del
						//divDataDv = new DataView( 
						//    this._inventInputAcs.InventDataTable, 
						//    string.Format("{0}='{1}'", InventInputResult.ct_Col_ProductStockGuid, keyGuid ),
						//    "", DataViewRowState.CurrentRows );

						//// 該当行が見つからないときは終了
						//if ( divDataDv.Count <= 0 )
						//{
						//    continue;
						//}
						#endregion

						// 2007.07.19 kubo add --------------------------->
						#region // 2007.07.30 kubo del
						//this._inventInputView.RowFilter = string.Format("{0}='{1}'", InventInputResult.ct_Col_key, keyGuid );
						#endregion
						// 2007.07.30 kubo add ------>
						this._inventInputView.RowFilter = string.Format("{0}='{1}' and {2}={3}", InventInputResult.ct_Col_key, keyGuid, InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0 );
						// 2007.07.30 kubo add <------
						this._inventInputView.Sort = "";
						this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

						if ( this._inventInputView.Count <= 0 )
							continue;
						// 2007.07.19 kubo add <---------------------------

						// DataRow取得
						#region // 2007.07.19 kubo del
						// divDataDr = divDataDv[0].Row;			
						#endregion
						divDataDr = this._inventInputView[0].Row;	// 2007.07.19 kubo add 

						// 2007.07.27 kubo add ----------->
						if ( divDataDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
							defInventStock = (double)divDataDr[InventInputResult.ct_Col_InventoryStockCnt];
						else
							defInventStock = 0;

						// 棚卸数が帳簿数より小さかったらそのまま、大きかったら新規で追加
						if ( isiBarCode.InventoryStockCnt <= isiBarCode.StockTotal )
						{
							// 棚卸数展開
							divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.InventoryStockCnt;
							addnewRowCnt = 0;
						}
						else
						{
							// 帳簿数=0 (新規データ)の判断
							if ( isiBarCode.StockTotal == 0 )
							{
								// もともとの棚卸数が帰ってきた棚卸数より大きい場合は新規追加
								if ( defInventStock > isiBarCode.InventoryStockCnt )
								{
									// 棚卸数展開
									divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.InventoryStockCnt;
									addnewRowCnt = defInventStock - isiBarCode.InventoryStockCnt - isiBarCode.StockTotal;
								}
								else
								{
									// 棚卸数展開
									divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.InventoryStockCnt;
									addnewRowCnt = 0;
								}
							}
							else
							{
								// 棚卸数展開
								divDataDr[InventInputResult.ct_Col_InventoryStockCnt] = isiBarCode.StockTotal;
								addnewRowCnt = isiBarCode.InventoryStockCnt - isiBarCode.StockTotal;
							}
						}
						// 2007.07.27 kubo add <-----------

						// 棚数を親・子に展開
						bool isShowProduct = false;
						AfterInputInventryToleCnt( ref divDataDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );
						AfterInputInventoryDate( ref divDataDr, this.tde_InventoryDate.GetDateTime() );

						this.uGrid_InventInput.EndUpdate();

						// 2007.07.27 kubo add ----------->
						if ( addnewRowCnt > 0 )
						{
							InventoryDataUpdateWork invUpdateWork = new InventoryDataUpdateWork();
							CreateInventUpdateWorkFromRow( out invUpdateWork, divDataDr );
							invUpdateWork.InventoryStockCnt = addnewRowCnt;
							invUpdateWork.StockTotal = 0;
							NewInventProc( invUpdateWork, false, true );
						}
						// 2007.07.27 kubo add <-----------

					}
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
			}
			catch( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				MsgDispProc( "バーコード読込データの展開に失敗しました。", status, "ReadBarCodeMain",ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
				if ( this.uGrid_InventInput.IsUpdating )
					this.uGrid_InventInput.EndUpdate();
			}

			return status;
		}

		#endregion

		#region ◎ バーコード入力メイン処理
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// バーコード入力メイン処理
		/// </summary>
		/// <returns>バーコード入力用辞書</returns>
		private Dictionary<Guid, InventoryStockInputBarCode> MakeReadBarCodeDictionary()
		{
			Dictionary<Guid, InventoryStockInputBarCode> barCodeDic = new Dictionary<Guid,InventoryStockInputBarCode>();
			// 表示可能データのDataViewを作成
			// 　・表示可能データ
			//   ・製番管理有のグロスデータは渡さない
			string sortOrder = "";
			// ソート順決定
			switch ( (int)this.tce_SortOrder.SelectedItem.DataValue )
			{
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //case (int)InventInputSearchCndtn.SortOrderState.CarrierEP:		// 倉庫-事業者-商品-製番
				//	sortOrder = ct_SortOrder_CarrierEp;
				//	break;
				//case (int)InventInputSearchCndtn.SortOrderState.Customer:		// 倉庫-仕入先-商品-製番
				//	sortOrder = ct_SortOrder_Customer;
				//	break;
				//case (int)InventInputSearchCndtn.SortOrderState.ShipCustomer:	// 倉庫-委託先-商品-製番
				//	sortOrder = ct_SortOrder_ShipCustomer;
				//	break;
				//default:														// 倉庫-商品-製番
				//	sortOrder = ct_SortOrder_Goods;
				//	break;
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:		// 倉庫→棚番
                //    sortOrder = ct_SortOrder_ShelfNo;
                //    break;
                case (int)InventInputSearchCndtn.SortOrderState.SNo_GoodsDiv:	// 倉庫→棚番→メーカー→商品区分→商品
                    sortOrder = ct_SortOrder_GoodsDiv;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.SNo_Goods:		// 倉庫→棚番→メーカー→商品
                    sortOrder = ct_SortOrder_Goods;
                    break;
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                case (int)InventInputSearchCndtn.SortOrderState.Customer:		// 倉庫→仕入先
					sortOrder = ct_SortOrder_Customer;
					break;
				case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// 倉庫→ＢＬコード
					sortOrder = ct_SortOrder_BLGoods;
					break;
				case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // 倉庫→メーカー
					sortOrder = ct_SortOrder_Maker;
					break;
                case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // 倉庫→仕入先→棚番
					sortOrder = ct_SortOrder_Cus_ShelfNo;
					break;
				case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // 倉庫→仕入先→メーカー
					sortOrder = ct_SortOrder_Cus_Maker;
					break;
				default:														// 倉庫→棚番
					sortOrder = ct_SortOrder_ShelfNo;
					break;
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
			}

			#region // 2007.07.19 kubo del
			//DataView barCodeView = new DataView( this._inventInputAcs.InventDataTable, ct_Filter_Product, sortOrder, DataViewRowState.CurrentRows );
			#endregion
			//// 2007.07.19 kubo add ------------------>
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventInputView.RowFilter = ct_Filter_Product;
            this._inventInputView.RowFilter = ct_Filter_Goods;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            this._inventInputView.Sort = sortOrder;
			this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
			//// 2007.07.19 kubo add <------------------

			InventoryStockInputBarCode invStkInpBarCode;
			Guid rowGuid;
			#region // 2007.07.19 kubo del
			//for( int index = 0; index < barCodeView.Count; index++ )
			//{
			//    //rowGuid = (Guid)barCodeView[index][InventInputResult.ct_Col_ProductStockGuid];	// 2007.07.20 kubo del
			//    rowGuid = (Guid)barCodeView[index][InventInputResult.ct_Col_key];		// 2007.07.20 kubo add
			//    invStkInpBarCode = new InventoryStockInputBarCode();
			//    invStkInpBarCode.RowGuid			= rowGuid;// 行識別GUID
			//    invStkInpBarCode.InventorySeqNo		= (Int32)barCodeView[index][InventInputResult.ct_Col_InventorySeqNo];// 棚卸通番
			//    invStkInpBarCode.Jan				= (string)barCodeView[index][InventInputResult.ct_Col_Jan];// JANコード
			//    invStkInpBarCode.ProductNumber		= (string)barCodeView[index][InventInputResult.ct_Col_ProductNumber];// 製造番号
			//    invStkInpBarCode.StockTotal			= (Double)barCodeView[index][InventInputResult.ct_Col_StockTotal];// 在庫総数
			//    if ( barCodeView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value )
			//        invStkInpBarCode.InventoryStockCnt	= 0;// 棚卸在庫数
			//    else
			//        invStkInpBarCode.InventoryStockCnt	= (Double)barCodeView[index][InventInputResult.ct_Col_InventoryStockCnt];// 棚卸在庫数
			//    invStkInpBarCode.MakerCode			= (Int32)barCodeView[index][InventInputResult.ct_Col_MakerCode];// メーカーコード
			//    invStkInpBarCode.MakerName			= (string)barCodeView[index][InventInputResult.ct_Col_MakerName];// メーカー名称
			//    invStkInpBarCode.GoodsCode			= (string)barCodeView[index][InventInputResult.ct_Col_GoodsCode];// 品番
			//    invStkInpBarCode.GoodsName			= (string)barCodeView[index][InventInputResult.ct_Col_GoodsName];// 品名
			//    invStkInpBarCode.WarehouseCode		= (string)barCodeView[index][InventInputResult.ct_Col_WarehouseCode];// 倉庫コード
			//    invStkInpBarCode.WarehouseName		= (string)barCodeView[index][InventInputResult.ct_Col_WarehouseName];// 倉庫名称
			//    invStkInpBarCode.CarrierEpCode		= (Int32)barCodeView[index][InventInputResult.ct_Col_CarrierEpCode];// 事業者コード
			//    invStkInpBarCode.CarrierEpName		= (string)barCodeView[index][InventInputResult.ct_Col_CarrierEpName];// 事業者名称
			//    invStkInpBarCode.CustomerCode		= (Int32)barCodeView[index][InventInputResult.ct_Col_CustomerCode];// 得意先コード
			//    invStkInpBarCode.CustomerName		= (string)barCodeView[index][InventInputResult.ct_Col_CustomerName];// 得意先名称
			//    invStkInpBarCode.CustomerName2		= (string)barCodeView[index][InventInputResult.ct_Col_CustomerName2];// 得意先名称2
			//    invStkInpBarCode.ShipCustomerCode	= (Int32)barCodeView[index][InventInputResult.ct_Col_ShipCustomerCode];// 出荷先得意先コード
			//    invStkInpBarCode.ShipCustomerName	= (string)barCodeView[index][InventInputResult.ct_Col_ShipCustomerName];// 出荷先得意先名称
			//    invStkInpBarCode.ShipCustomerName2	= (string)barCodeView[index][InventInputResult.ct_Col_ShipCustomerName2];// 出荷先得意先名称2
			//    invStkInpBarCode.StockTrtEntDiv		= (Int32)barCodeView[index][InventInputResult.ct_Col_StockTrtEntDiv];// 在庫区分
			//    invStkInpBarCode.StockTrtEntName	= (string)barCodeView[index][InventInputResult.ct_Col_StockTrtEntDivName];// 在庫区分名称
			//    invStkInpBarCode.StockUnitPrice		= (Int64)barCodeView[index][InventInputResult.ct_Col_StockUnitPrice];// 仕入単価
			//    invStkInpBarCode.Status				= 0;// ステータス

			//    barCodeDic.Add( rowGuid, invStkInpBarCode );
			//}
			#endregion

			//// 2007.07.19 kubo add ------------->
			for ( int index = 0; index < _inventInputView.Count; index++ )
			{
			    rowGuid = (Guid)_inventInputView[index][InventInputResult.ct_Col_key];
			    invStkInpBarCode = new InventoryStockInputBarCode();
			    invStkInpBarCode.RowGuid			= rowGuid;// 行識別GUID
			    invStkInpBarCode.InventorySeqNo		= (Int32)this._inventInputView[index][InventInputResult.ct_Col_InventorySeqNo];// 棚卸通番
			    invStkInpBarCode.Jan				= (string)this._inventInputView[index][InventInputResult.ct_Col_Jan];// JANコード
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //invStkInpBarCode.ProductNumber = (string)this._inventInputView[index][InventInputResult.ct_Col_ProductNumber];// 製造番号
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                invStkInpBarCode.StockTotal = (Double)this._inventInputView[index][InventInputResult.ct_Col_StockTotal];// 在庫総数
			    if ( this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value )
			        invStkInpBarCode.InventoryStockCnt	= 0;// 棚卸在庫数
			    else
			        invStkInpBarCode.InventoryStockCnt	= (Double)this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt];// 棚卸在庫数
			    invStkInpBarCode.MakerCode			= (Int32)this._inventInputView[index][InventInputResult.ct_Col_MakerCode];// メーカーコード
			    invStkInpBarCode.MakerName			= (string)this._inventInputView[index][InventInputResult.ct_Col_MakerName];// メーカー名称
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //invStkInpBarCode.GoodsCode        = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsCode];// 品番
                invStkInpBarCode.GoodsCode          = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsNo];// 品番
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                invStkInpBarCode.GoodsName          = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsName];// 品名
			    invStkInpBarCode.WarehouseCode		= (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseCode];// 倉庫コード
			    invStkInpBarCode.WarehouseName		= (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseName];// 倉庫名称
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
//                invStkInpBarCode.WarehouseShelfNo   = (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseShelfNo];// 棚番
//                invStkInpBarCode.DuplicationShelfNo1= (string)this._inventInputView[index][InventInputResult.ct_Col_DuplicationShelfNo1];// 重複棚番１
//                invStkInpBarCode.DuplicationShelfNo2= (string)this._inventInputView[index][InventInputResult.ct_Col_DuplicationShelfNo2];// 重複棚番２
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //invStkInpBarCode.CarrierEpCode        = (Int32)this._inventInputView[index][InventInputResult.ct_Col_CarrierEpCode];// 事業者コード
			    //invStkInpBarCode.CarrierEpName		= (string)this._inventInputView[index][InventInputResult.ct_Col_CarrierEpName];// 事業者名称
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                invStkInpBarCode.CustomerCode       = (Int32)this._inventInputView[index][InventInputResult.ct_Col_CustomerCode];// 得意先コード
			    invStkInpBarCode.CustomerName		= (string)this._inventInputView[index][InventInputResult.ct_Col_CustomerName];// 得意先名称
			    invStkInpBarCode.CustomerName2		= (string)this._inventInputView[index][InventInputResult.ct_Col_CustomerName2];// 得意先名称2
			    invStkInpBarCode.ShipCustomerCode	= (Int32)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerCode];// 出荷先得意先コード
			    invStkInpBarCode.ShipCustomerName	= (string)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerName];// 出荷先得意先名称
			    invStkInpBarCode.ShipCustomerName2	= (string)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerName2];// 出荷先得意先名称2
			    invStkInpBarCode.StockTrtEntDiv		= (Int32)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDiv];// 在庫区分
			    invStkInpBarCode.StockTrtEntName	= (string)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDivName];// 在庫区分名称
                invStkInpBarCode.StockUnitPrice     = (Int64)this._inventInputView[index][InventInputResult.ct_Col_StockUnitPrice];// 仕入単価
			    invStkInpBarCode.Status				= 0;// ステータス

			    barCodeDic.Add( rowGuid, invStkInpBarCode );
			}
			//// 2007.07.19 kubo add <-------------
			return barCodeDic;
			
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// バーコード入力メイン処理
        /// </summary>
        /// <returns>バーコード入力用辞書</returns>
        private Dictionary<Guid, InventoryStockInputBarCode> MakeReadBarCodeDictionary()
        {
            Dictionary<Guid, InventoryStockInputBarCode> barCodeDic = new Dictionary<Guid, InventoryStockInputBarCode>();
            // 表示可能データのDataViewを作成
            // 　・表示可能データ
            //   ・製番管理有のグロスデータは渡さない
            string sortOrder = "";
            // ソート順決定
            switch ((int)this.tce_SortOrder.SelectedItem.DataValue)
            {
                case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:	    // 倉庫→棚番
                    sortOrder = ct_SortOrder_ShelfNo;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Customer:		// 倉庫→仕入先
                    sortOrder = ct_SortOrder_Supplier;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// 倉庫→ＢＬコード
                    sortOrder = ct_SortOrder_BLGoods;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.BLGroup:    	// 倉庫→グループコード
                    sortOrder = ct_SortOrder_BLGroup;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // 倉庫→メーカー
                    sortOrder = ct_SortOrder_Maker;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // 倉庫→仕入先→棚番
                    sortOrder = ct_SortOrder_Sup_ShelfNo;
                    break;
                case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // 倉庫→仕入先→メーカー
                    sortOrder = ct_SortOrder_Sup_Maker;
                    break;
                default:														// 倉庫→棚番
                    sortOrder = ct_SortOrder_ShelfNo;
                    break;
            }

            this._inventInputView.RowFilter = ct_Filter_Goods;
            this._inventInputView.Sort = sortOrder;
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            InventoryStockInputBarCode invStkInpBarCode;
            Guid rowGuid;

            for (int index = 0; index < _inventInputView.Count; index++)
            {
                rowGuid = (Guid)_inventInputView[index][InventInputResult.ct_Col_key];
                invStkInpBarCode = new InventoryStockInputBarCode();
                // 行識別GUID
                invStkInpBarCode.RowGuid = rowGuid;
                // 棚卸通番
                invStkInpBarCode.InventorySeqNo = (Int32)this._inventInputView[index][InventInputResult.ct_Col_InventorySeqNo];
                // JANコード
                invStkInpBarCode.Jan = (string)this._inventInputView[index][InventInputResult.ct_Col_Jan];
                // 在庫総数
                invStkInpBarCode.StockTotal = (Double)this._inventInputView[index][InventInputResult.ct_Col_StockTotal];
                // 棚卸在庫数
                if (this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
                {
                    invStkInpBarCode.InventoryStockCnt = 0;
                }
                else
                {
                    invStkInpBarCode.InventoryStockCnt = (Double)this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt];
                }
                // メーカーコード
                invStkInpBarCode.MakerCode = (Int32)this._inventInputView[index][InventInputResult.ct_Col_MakerCode];
                // メーカー名称
                invStkInpBarCode.MakerName = (string)this._inventInputView[index][InventInputResult.ct_Col_MakerName];
                // 品番
                invStkInpBarCode.GoodsCode = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsNo];
                // 品名
                invStkInpBarCode.GoodsName = (string)this._inventInputView[index][InventInputResult.ct_Col_GoodsName];
                // 倉庫コード
                invStkInpBarCode.WarehouseCode = (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseCode];
                // 倉庫名称
                invStkInpBarCode.WarehouseName = (string)this._inventInputView[index][InventInputResult.ct_Col_WarehouseName];
                // 仕入先コード
                invStkInpBarCode.CustomerCode = (Int32)this._inventInputView[index][InventInputResult.ct_Col_SupplierCode];
                // 仕入先名称
                invStkInpBarCode.CustomerName = (string)this._inventInputView[index][InventInputResult.ct_Col_SupplierName];
                // 仕入先名称2
                invStkInpBarCode.CustomerName2 = (string)this._inventInputView[index][InventInputResult.ct_Col_SupplierName2];
                // 出荷先得意先コード
                invStkInpBarCode.ShipCustomerCode = (Int32)this._inventInputView[index][InventInputResult.ct_Col_ShipCustomerCode];
                // 在庫区分
                invStkInpBarCode.StockTrtEntDiv = (Int32)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDiv];
                // 在庫区分名称
                invStkInpBarCode.StockTrtEntName = (string)this._inventInputView[index][InventInputResult.ct_Col_StockTrtEntDivName];
                // 仕入単価
                invStkInpBarCode.StockUnitPrice = (Int64)this._inventInputView[index][InventInputResult.ct_Col_StockUnitPrice];
                // ステータス
                invStkInpBarCode.Status = 0;

                barCodeDic.Add(rowGuid, invStkInpBarCode);
            }
            return barCodeDic;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		#endregion

		#region ◎ バーコード入力データ展開処理 // 2007.07.20 kubo del 未使用のためコメントアウト
		///// <summary>
		///// 
		///// </summary>
		///// <param name="barcodeDic"></param>
		//private void DivReadBarcodeData( Dictionary<Guid, InventoryStockInputBarCode> barcodeDic )
		//{
		//    // Todo:展開処理を記述
		//    // DataView barCodeView; // 展開対象Row
		//    InventoryStockInputBarCode invStkInpBarCode;
		//    Guid retGuid;
		//    //Guid r
		//    foreach( KeyValuePair<Guid, InventoryStockInputBarCode> retDic in barcodeDic )
		//    {
		//        retGuid = retDic.Key;
		//        invStkInpBarCode = retDic.Value;

		//        if ( invStkInpBarCode.Status != 0 )
		//        {
		//            continue;
		//        }
		//        else
		//        {
		//            // 更新行の取得(Guidで指定するから結果は必ず１行になる)
		//            #region // 2007.07.19 kubo del
		//            //barCodeView = new DataView( 
		//            //    this._inventInputAcs.InventDataTable, 
		//            //    string.Format("{0}={1}", InventInputResult.ct_Col_ProductStockGuid, retGuid),
		//            //    "", 
		//            //    DataViewRowState.CurrentRows );
		//            #endregion

		//            // 2007.07.19 kubo add ------------->
		//            //this._inventInputView.RowFilter = string.Format("{0}={1}", InventInputResult.ct_Col_ProductStockGuid, retGuid);
		//            this._inventInputView.RowFilter = string.Format("{0}={1}", InventInputResult.ct_Col_key, retGuid);
		//            this._inventInputView.Sort = "";
		//            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
		//            // 2007.07.19 kubo add ------------->


		//            #region // 2007.07.19 kubo del
		//            //if ( barCodeView.Count == 1 )
		//            //{
		//            //    // 棚卸在庫数
		//            //    barCodeView[0][InventInputResult.ct_Col_InventoryStockCnt] = invStkInpBarCode.InventoryStockCnt;
		//            //    // 差異数
		//            //    barCodeView[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
		//            //        (double)barCodeView[0][InventInputResult.ct_Col_InventoryStockCnt] - (double)barCodeView[0][InventInputResult.ct_Col_StockTotal];

		//            //    // 製番の親データに差異数を加算
		//            //    // 親に反映するとき差異数と帳簿数は関係ないからゼロ固定
		//            //    DataRow dr = barCodeView[0].Row;
		//            //    ChangeCommitToleranceCnt( ref dr, 0, 0, true );

		//            //}
		//            #endregion
		//            if ( this._inventInputView.Count == 1 )
		//            {
		//                // 棚卸在庫数
		//                this._inventInputView[0][InventInputResult.ct_Col_InventoryStockCnt] = invStkInpBarCode.InventoryStockCnt;
		//                // 差異数
		//                this._inventInputView[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
		//                    (double)this._inventInputView[0][InventInputResult.ct_Col_InventoryStockCnt] - (double)this._inventInputView[0][InventInputResult.ct_Col_StockTotal];

		//                // 製番の親データに差異数を加算
		//                // 親に反映するとき差異数と帳簿数は関係ないからゼロ固定
		//                DataRow dr = this._inventInputView[0].Row;
		//                ChangeCommitToleranceCnt( ref dr, 0, 0, true );

		//            }

		//        }
		//    }
		//}
		#endregion
		#endregion
	
		#region ◎ 新規処理メイン
		/// <summary>
		/// 新規処理メイン
		/// </summary>
		/// <returns></returns>
		private int NewInventProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			try
			{
				if ( this._createNewInventForm == null )
				{
					this._createNewInventForm = new MAZAI05130UD();
					this._createNewInventForm.EnterpriseCode = this._enterpriseCode;
					this._createNewInventForm.SectionCode = this._sectionCode;
				}
				InventoryDataUpdateWork invUpdWork = new InventoryDataUpdateWork();
				invUpdWork.EnterpriseCode = this._enterpriseCode;
				invUpdWork.SectionCode = this._sectionCode;
//				invUpdWork.SectionGuideNm = this._sectionName;
                // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                //// 棚卸日設定
                //invUpdWork.InventoryDay = this.tde_InventoryExeDate.GetDateTime();
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                // 棚卸日設定
                invUpdWork.InventoryDate = this.tde_InventoryExeDate.GetDateTime();
                // 棚卸実施日設定
                invUpdWork.InventoryDay = this.tde_InventoryDate.GetDateTime();
                // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
                
				DialogResult dlgRes = this._createNewInventForm.ShowEditor( ref invUpdWork, (int)MAZAI05130UD.DispModeState.CreateNew );

				switch ( dlgRes )
				{
					case DialogResult.OK:
                        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
                        status = this._inventInputAcs.CheckRecord(invUpdWork);
                        if (status != 0)
                        {
                            this.MsgDispProc("棚卸データが重複してます。", status, "NewInventProc", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                            return status;
                        }
                        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

						this._defProdNumList.Add( invUpdWork );
						status = NewInventProc( invUpdWork, true, true);


						break;
					default :
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
				}
			}
			catch( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "棚卸データの新規作成に失敗しました。", status, "NewInventProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
			}
			return status;
		}
		#endregion

		#region ◎ 新規処理メイン
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 新規処理メイン(新規画面非表示)
		/// </summary>
		/// <param name="invUpdWork">新規データ</param>
		/// <param name="isProductInput">製番入力画面起動区分(true:起動する, false:起動しない)</param>
		/// <param name="isSelectRow">行選択フラグ(true:選択する, false:選択しない</param>
		/// <returns></returns>
		private int NewInventProc( InventoryDataUpdateWork invUpdWork, bool isProductInput, bool isSelectRow )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				ArrayList invUpdWorkList;

                // 新規行作成
				CreateNewInvent( invUpdWork, out invUpdWorkList );

				// 製番設定画面起動
                if (this._productNumInput == null)
                {
                    this._productNumInput = new ProductNumInput();
                }

				this.uGrid_InventInput.BeginUpdate();

                if (invUpdWorkList.Count <= 0)
                {
                    return (status);
                }

                //--------------------------------------
				// 追加が有る場合はテーブルに展開する
                //--------------------------------------

                string errMsg = "";
                string warehouseCode;
                string goodsNo;
                int makerCode;
                int supplierCode;
                int stockDiv;

                status = this._inventInputAcs.DevSearchResult(invUpdWorkList, (int)InventInputSearchCndtn.ChangeFlagState.Change, ref errMsg, true);
                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        if (isSelectRow == false)
                        {
                            break;
                        }

                        invUpdWork = invUpdWorkList[0] as InventoryDataUpdateWork;

                        int rowCount = 0;
                        this.uGrid_InventInput.ActiveRow = null;
                        for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                        {
                            // 倉庫コード
                            warehouseCode = this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd();
                            // 品番
                            goodsNo = this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd();
                            // メーカーコード
                            makerCode = (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value;
                            // 仕入先コード
                            supplierCode = (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_SupplierCode].Value;
                            // 在庫区分
                            stockDiv = (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockDiv].Value;

                            if ((warehouseCode == invUpdWork.WarehouseCode.ToString().TrimEnd()) && (makerCode == invUpdWork.GoodsMakerCd) &&
                                (goodsNo == invUpdWork.GoodsNo.ToString().TrimEnd()) && (supplierCode == invUpdWork.SupplierCd) &&
                                (stockDiv == invUpdWork.StockDiv))
                            {
                                if (rowCount == 0)
                                {
                                    rowCount = gridIndex;
                                    this.uGrid_InventInput.Selected.Rows.Clear();

                                    if (this.uGrid_InventInput.ActiveRow == null)
                                    {
                                        this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                    }

                                    this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                    this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;
                                }

                                this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);
                            }
                        }

                        // スクロール
                        if (this.uGrid_InventInput.Selected.Rows.Count > 0)
                        {
                            this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.Selected.Rows[0];
                        }

                        break;
                    default:
                        this.MsgDispProc(errMsg, status, "NewInventProc", emErrorLevel.ERR_LEVEL_STOPDISP);
                        break;
                }
			}
			finally
			{
				this.uGrid_InventInput.EndUpdate();
			}
			return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 新規処理メイン(新規画面非表示)
        /// </summary>
        /// <param name="invUpdWork">新規データ</param>
        /// <param name="isProductInput">製番入力画面起動区分(true:起動する, false:起動しない)</param>
        /// <param name="isSelectRow">行選択フラグ(true:選択する, false:選択しない</param>
        /// <returns></returns>
        private int NewInventProc(InventoryDataUpdateWork invUpdWork, bool isProductInput, bool isSelectRow)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                ArrayList invUpdWorkList;
                CreateNewInvent(invUpdWork, out invUpdWorkList);

                // 2007.07.26 kubo add --------------->
                // 製番設定画面起動
                if (this._productNumInput == null)
                    this._productNumInput = new ProductNumInput();

                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //ArrayList productNumList = null;
                //
                //int prdStatus = 0;
                //// 製番入力画面起動条件
                //// 製番管理区分：管理する かつ 製番未入力 かつ 棚卸数がゼロより大きく、起動区分：起動するのとき
                //if ( invUpdWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product && 
                //	invUpdWork.ProductNumber.TrimEnd() == "" &&
                //	invUpdWork.InventoryStockCnt > 1 && 
                //	isProductInput)
                //{
                //	this._productNumInput.DefPrdTelList = this._defProdNumList;
                //	prdStatus = this._productNumInput.ShowProductInventInput( out productNumList, invUpdWork.InventoryStockCnt, this );
                //
                //	if ( productNumList != null && prdStatus == 0 )
                //	{
                //		for( int localIndex = 0; localIndex < productNumList.Count; localIndex++ )
                //		{
                //			if ( localIndex < invUpdWorkList.Count )
                //			{
                //                ((InventoryDataUpdateWork)invUpdWorkList[localIndex]).ProductNumber = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo1 = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo2 = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
                //            }
                //		}
                //	}
                //    //if ( prdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL && prdStatus == (int)ConstantManagement.MethodResult.ctFNC_CANCEL )
                //	//    return prdStatus;
                //}
                //else
                //{
                //	if ( this._defProdNumList.Count > 0 && invUpdWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
                //	{
                //		for( int localIndex = 0; localIndex < this._defProdNumList.Count; localIndex++ )
                //		{
                //			if ( localIndex < invUpdWorkList.Count )
                //			{
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).ProductNumber = ((InventoryDataUpdateWork)this._defProdNumList[localIndex]).ProductNumber.TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo1 = ((InventoryDataUpdateWork)this._defProdNumList[localIndex]).StockTelNo1.TrimEnd();
                //				((InventoryDataUpdateWork)invUpdWorkList[localIndex]).StockTelNo2 = ((InventoryDataUpdateWork)this._defProdNumList[localIndex]).StockTelNo2.TrimEnd();
                //			}
                //		}
                //	}
                //}
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

                // 2007.07.26 kubo add --------------->

                this.uGrid_InventInput.BeginUpdate();

                // 追加が有る場合はテーブルに展開する
                if (invUpdWorkList.Count > 0)
                {
                    string errMsg = "";
                    status = this._inventInputAcs.DevSearchResult(invUpdWorkList, (int)InventInputSearchCndtn.ChangeFlagState.Change, ref errMsg, true);

                    invUpdWork = invUpdWorkList[0] as InventoryDataUpdateWork;
                    switch (status)
                    {
                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            if (isSelectRow)
                            {
                                int rowCount = 0;
                                this.uGrid_InventInput.ActiveRow = null;
                                for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                                {
                                    if (
                                        (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd() ==	// 倉庫
                                          invUpdWork.WarehouseCode.ToString().TrimEnd()) &&
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value == // メーカー
                                          invUpdWork.GoodsMakerCd) &&
                                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                                        //( this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsCode].Value.ToString().TrimEnd() == // 品番
                                        (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd() == // 品番
                                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                                          invUpdWork.GoodsNo.ToString().TrimEnd()) &&
                                        // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                                        //( (long)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockUnitPrice].Value == // 原単価
                                        //  invUpdWork.StockUnitPriceFl) &&
                                        // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CustomerCode].Value == // 仕入先コード
                                          invUpdWork.CustomerCode) &&
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_ShipCustomerCode].Value == // 委託先コード
                                          invUpdWork.ShipCustomerCode) &&
                                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                        //((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CarrierEpCode].Value == // 事業者
                                        //  invUpdWork.CarrierEpCode ) &&
                                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                        ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockDiv].Value == // 在庫区分
                                          invUpdWork.StockDiv) //&&
                                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                        //((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockDiv].Value == // 在庫状態
                                        //  invUpdWork.StockState ) //&&
                                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                        //( (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryNewDiv].Value == // 新規区分
                                        //  (int)InventInputSearchCndtn.NewRowState.New )
                                    )
                                    {
                                        if (rowCount == 0)
                                        {
                                            rowCount = gridIndex;
                                            this.uGrid_InventInput.Selected.Rows.Clear();
                                            //this.uGrid_InventInput.ActiveRow = this.uGrid_InventInput.Rows[gridIndex];
                                            //this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                            if (this.uGrid_InventInput.ActiveRow == null)
                                                this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                                            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;
                                        }

                                        this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);
                                    }
                                }

                                //// スクロール
                                if (this.uGrid_InventInput.Selected.Rows.Count > 0)
                                    this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.Selected.Rows[0];

                            }
                            break;
                        default:
                            this.MsgDispProc(errMsg, status, "NewInventProc", emErrorLevel.ERR_LEVEL_STOPDISP);
                            break;
                    }
                }
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
            }
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 新規行作成処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 新規行作成処理
		/// </summary>
		/// <param name="baseInvUpdWork">新規行作成処理</param>
		/// <param name="invUpdWorkList">追加リスト</param>
        /// <br>UpdateNote : 2011/01/30 鄧潘ハン </br>
        /// <br>             障害報告 #18764</br>
        /// <returns>Status</returns>
		private void CreateNewInvent( InventoryDataUpdateWork baseInvUpdWork, out ArrayList invUpdWorkList )
		{
			// ローカルテーブルに追加するために新規作成画面で入力された項目を製番単位で分解する

			invUpdWorkList = new ArrayList();
			InventoryDataUpdateWork invUpdPrd;
            double newRowCounter = 1;	// 新規作成行数

			for ( int index = 0; index < newRowCounter; index++ )
			{
				invUpdPrd = new InventoryDataUpdateWork();
                invUpdPrd.InventoryStockCnt     = baseInvUpdWork.InventoryStockCnt;     // 棚卸数
                invUpdPrd.InventoryTolerancCnt  = baseInvUpdWork.InventoryStockCnt;     // 差異数
				invUpdPrd.CreateDateTime		= baseInvUpdWork.CreateDateTime;        // 作成日時
				invUpdPrd.UpdateDateTime		= baseInvUpdWork.UpdateDateTime;        // 更新日時
				invUpdPrd.EnterpriseCode		= baseInvUpdWork.EnterpriseCode;        // 企業コード
				invUpdPrd.FileHeaderGuid		= baseInvUpdWork.FileHeaderGuid;        // GUID
				invUpdPrd.UpdEmployeeCode		= baseInvUpdWork.UpdEmployeeCode;       // 更新従業員コード
				invUpdPrd.UpdAssemblyId1		= baseInvUpdWork.UpdAssemblyId1;        // 更新アセンブリID1
				invUpdPrd.UpdAssemblyId2		= baseInvUpdWork.UpdAssemblyId2;        // 更新アセンブリID2
				invUpdPrd.LogicalDeleteCode		= baseInvUpdWork.LogicalDeleteCode;     // 論理削除区分
				invUpdPrd.SectionCode			= baseInvUpdWork.SectionCode;           // 拠点コード
				invUpdPrd.InventorySeqNo		= baseInvUpdWork.InventorySeqNo;        // 棚卸通番
				invUpdPrd.WarehouseCode			= baseInvUpdWork.WarehouseCode;         // 倉庫コード
				invUpdPrd.GoodsMakerCd			= baseInvUpdWork.GoodsMakerCd;          // メーカーコード
				invUpdPrd.GoodsNo				= baseInvUpdWork.GoodsNo;               // 品番
                invUpdPrd.GoodsName             = baseInvUpdWork.GoodsName;             // 品名     //ADD 2009/04/21 不具合対応[13075]
                invUpdPrd.WarehouseShelfNo      = baseInvUpdWork.WarehouseShelfNo;      // 倉庫棚番
                invUpdPrd.DuplicationShelfNo1   = baseInvUpdWork.DuplicationShelfNo1;   // 重複棚番2
                invUpdPrd.DuplicationShelfNo2   = baseInvUpdWork.DuplicationShelfNo2;   // 重複棚番1
                invUpdPrd.GoodsLGroup           = baseInvUpdWork.GoodsLGroup;           // 商品大分類コード
				invUpdPrd.GoodsMGroup	        = baseInvUpdWork.GoodsMGroup;           // 商品中分類コード
                invUpdPrd.BLGroupCode           = baseInvUpdWork.BLGroupCode;           // グループコード
                invUpdPrd.EnterpriseGanreCode   = baseInvUpdWork.EnterpriseGanreCode;   // 自社分類コード
                invUpdPrd.BLGoodsCode           = baseInvUpdWork.BLGoodsCode;           // ＢＬ品番
                invUpdPrd.SupplierCd            = baseInvUpdWork.SupplierCd;            // 仕入先コード
                invUpdPrd.Jan                   = baseInvUpdWork.Jan;                   // JANコード
                invUpdPrd.StockUnitPriceFl      = baseInvUpdWork.StockUnitPriceFl;      // 仕入単価
                invUpdPrd.BfStockUnitPriceFl    = baseInvUpdWork.BfStockUnitPriceFl;    // 変更前仕入単価
				invUpdPrd.StkUnitPriceChgFlg	= baseInvUpdWork.StkUnitPriceChgFlg;    // 仕入単価変更フラグ
				invUpdPrd.StockDiv				= baseInvUpdWork.StockDiv;              // 在庫区分
                invUpdPrd.LastStockDate         = baseInvUpdWork.LastStockDate;         // 最終仕入年月日
				invUpdPrd.StockTotal			= baseInvUpdWork.StockTotal;            // 在庫総数
				invUpdPrd.ShipCustomerCode		= baseInvUpdWork.ShipCustomerCode;      // 出荷先得意先コード
				invUpdPrd.InventoryPreprDay		= baseInvUpdWork.InventoryPreprDay;     // 棚卸準備処理日付
				invUpdPrd.InventoryPreprTim		= baseInvUpdWork.InventoryPreprTim;     // 棚卸準備処理時間
				invUpdPrd.InventoryDay			= baseInvUpdWork.InventoryDay;          // 棚卸実施日
				invUpdPrd.LastInventoryUpdate	= baseInvUpdWork.LastInventoryUpdate;   // 最終棚卸更新日
				invUpdPrd.InventoryNewDiv		= baseInvUpdWork.InventoryNewDiv;       // 棚卸新規追加区分
                invUpdPrd.StockMashinePrice     = baseInvUpdWork.StockMashinePrice;     // マシン在庫額
                invUpdPrd.InventoryStockPrice   = baseInvUpdWork.InventoryStockPrice;   // 棚卸在庫額
                invUpdPrd.InventoryTlrncPrice   = baseInvUpdWork.InventoryTlrncPrice;   // 棚卸過不足金額
                invUpdPrd.InventoryDate         = baseInvUpdWork.InventoryDate;         // 棚卸日
                invUpdPrd.Status                = baseInvUpdWork.Status;                // ステータス

                invUpdPrd.AdjstCalcCost         = baseInvUpdWork.AdjstCalcCost;         // 調整用計算原価   //ADD 2009/05/14 不具合対応[13260]

                invUpdPrd.ListPrice = baseInvUpdWork.ListPrice;                         // 定価             //ADD 2011/01/30

				invUpdWorkList.Add( invUpdPrd );	// 追加リストにAdd
			}
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 新規行作成処理
        /// </summary>
        /// <param name="baseInvUpdWork">新規行作成処理</param>
        /// <param name="invUpdWorkList">追加リスト</param>
        /// <returns>Status</returns>
        private void CreateNewInvent(InventoryDataUpdateWork baseInvUpdWork, out ArrayList invUpdWorkList)
        {
            // ローカルテーブルに追加するために新規作成画面で入力された項目を製番単位で分解する

            invUpdWorkList = new ArrayList();
            InventoryDataUpdateWork invUpdPrd;
            double newRowCounter = 1;	// 新規作成行数

            for (int index = 0; index < newRowCounter; index++)
            {
                invUpdPrd = new InventoryDataUpdateWork();
                // 行のコピー
                // Guidはキーになるので新しく振りなおす
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.ProductStockGuid = Guid.NewGuid(); // 製番在庫マスタGUID
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.InventoryStockCnt = baseInvUpdWork.InventoryStockCnt;     // 棚卸数
                invUpdPrd.InventoryTolerancCnt = baseInvUpdWork.InventoryStockCnt;     // 差異数

                #region
                invUpdPrd.CreateDateTime = baseInvUpdWork.CreateDateTime;        // 作成日時
                invUpdPrd.UpdateDateTime = baseInvUpdWork.UpdateDateTime;        // 更新日時
                invUpdPrd.EnterpriseCode = baseInvUpdWork.EnterpriseCode;        // 企業コード
                invUpdPrd.FileHeaderGuid = baseInvUpdWork.FileHeaderGuid;        // GUID
                invUpdPrd.UpdEmployeeCode = baseInvUpdWork.UpdEmployeeCode;       // 更新従業員コード
                invUpdPrd.UpdAssemblyId1 = baseInvUpdWork.UpdAssemblyId1;        // 更新アセンブリID1
                invUpdPrd.UpdAssemblyId2 = baseInvUpdWork.UpdAssemblyId2;        // 更新アセンブリID2
                invUpdPrd.LogicalDeleteCode = baseInvUpdWork.LogicalDeleteCode;     // 論理削除区分
                invUpdPrd.SectionCode = baseInvUpdWork.SectionCode;           // 拠点コード
                //				invUpdPrd.SectionGuideNm		= baseInvUpdWork.SectionGuideNm;        // 拠点ガイド名称
                invUpdPrd.InventorySeqNo = baseInvUpdWork.InventorySeqNo;        // 棚卸通番
                invUpdPrd.WarehouseCode = baseInvUpdWork.WarehouseCode;         // 倉庫コード
                invUpdPrd.WarehouseName = baseInvUpdWork.WarehouseName;         // 倉庫名称
                invUpdPrd.GoodsMakerCd = baseInvUpdWork.GoodsMakerCd;          // メーカーコード
                invUpdPrd.MakerName = baseInvUpdWork.MakerName;             // メーカー名称
                invUpdPrd.GoodsNo = baseInvUpdWork.GoodsNo;               // 品番
                invUpdPrd.GoodsName = baseInvUpdWork.GoodsName;             // 品名
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.CellphoneModelCode  = baseInvUpdWork.CellphoneModelCode;    // 機種コード
                //invUpdPrd.CellphoneModelName	= baseInvUpdWork.CellphoneModelName;    // 機種名称
                //invUpdPrd.CarrierCode			= baseInvUpdWork.CarrierCode; // キャリアコード
                //invUpdPrd.CarrierName			= baseInvUpdWork.CarrierName; // キャリア名称
                //invUpdPrd.SystematicColorCd		= baseInvUpdWork.SystematicColorCd; // 系統色コード
                //invUpdPrd.SystematicColorNm		= baseInvUpdWork.SystematicColorNm; // 系統色名称
                invUpdPrd.WarehouseShelfNo = baseInvUpdWork.WarehouseShelfNo;      // 倉庫棚番
                invUpdPrd.DuplicationShelfNo1 = baseInvUpdWork.DuplicationShelfNo1;   // 重複棚番2
                invUpdPrd.DuplicationShelfNo2 = baseInvUpdWork.DuplicationShelfNo2;   // 重複棚番1
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.LargeGoodsGanreCode = baseInvUpdWork.LargeGoodsGanreCode;   // 商品大分類コード
                invUpdPrd.LargeGoodsGanreName = baseInvUpdWork.LargeGoodsGanreName;   // 商品大分類名称
                invUpdPrd.MediumGoodsGanreCode = baseInvUpdWork.MediumGoodsGanreCode;  // 商品中分類コード
                invUpdPrd.MediumGoodsGanreName = baseInvUpdWork.MediumGoodsGanreName;  // 商品中分類名称
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.CarrierEpCode			= baseInvUpdWork.CarrierEpCode;     // 事業者コード
                //invUpdPrd.CarrierEpName			= baseInvUpdWork.CarrierEpName;     // 事業者名称
                invUpdPrd.DetailGoodsGanreCode = baseInvUpdWork.DetailGoodsGanreCode;  // グループコード
                invUpdPrd.DetailGoodsGanreName = baseInvUpdWork.DetailGoodsGanreName;  // グループコード名称
                invUpdPrd.EnterpriseGanreCode = baseInvUpdWork.EnterpriseGanreCode;   // 自社分類コード
                invUpdPrd.EnterpriseGanreName = baseInvUpdWork.EnterpriseGanreName;   // 自社分類名称
                invUpdPrd.BLGoodsCode = baseInvUpdWork.BLGoodsCode;           // ＢＬ品番
                //                invUpdPrd.BLGoodsName           = baseInvUpdWork.BLGoodsName;         // ＢＬ品名
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.CustomerCode = baseInvUpdWork.CustomerCode;          // 得意先コード
                invUpdPrd.CustomerName = baseInvUpdWork.CustomerName;          // 得意先名称
                invUpdPrd.CustomerName2 = baseInvUpdWork.CustomerName2;         // 得意先名称2
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.StockDate             = baseInvUpdWork.StockDate;           // 仕入日
                //invUpdPrd.ArrivalGoodsDay		= baseInvUpdWork.ArrivalGoodsDay;       // 入荷日
                //invUpdPrd.ProductNumber			= baseInvUpdWork.ProductNumber;     // 製造番号
                //invUpdPrd.StockTelNo1			= baseInvUpdWork.StockTelNo1;           // 商品電話番号1
                //invUpdPrd.BfStockTelNo1			= baseInvUpdWork.BfStockTelNo1;     // 変更前商品電話番号1
                //invUpdPrd.StkTelNo1ChgFlg		= baseInvUpdWork.StkTelNo1ChgFlg;       // 商品電話番号1変更フラグ
                //invUpdPrd.StockTelNo2			= baseInvUpdWork.StockTelNo2;           // 商品電話番号2
                //invUpdPrd.BfStockTelNo2			= baseInvUpdWork.BfStockTelNo2;     // 変更前商品電話番号2
                //invUpdPrd.StkTelNo2ChgFlg		= baseInvUpdWork.StkTelNo2ChgFlg;       // 商品電話番号2変更フラグ
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.Jan = baseInvUpdWork.Jan;                   // JANコード
                invUpdPrd.StockUnitPriceFl = baseInvUpdWork.StockUnitPriceFl;      // 仕入単価
                invUpdPrd.BfStockUnitPriceFl = baseInvUpdWork.BfStockUnitPriceFl;    // 変更前仕入単価
                invUpdPrd.StkUnitPriceChgFlg = baseInvUpdWork.StkUnitPriceChgFlg;    // 仕入単価変更フラグ
                invUpdPrd.StockDiv = baseInvUpdWork.StockDiv;              // 在庫区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //invUpdPrd.StockState            = baseInvUpdWork.StockState;          // 在庫状態
                //invUpdPrd.MoveStatus			= baseInvUpdWork.MoveStatus;            // 移動状態
                //invUpdPrd.GoodsCodeStatus		= baseInvUpdWork.GoodsCodeStatus;       // 商品状態
                //invUpdPrd.PrdNumMngDiv			= baseInvUpdWork.PrdNumMngDiv;      // 製番管理区分
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.LastStockDate = baseInvUpdWork.LastStockDate;         // 最終仕入年月日
                invUpdPrd.StockTotal = baseInvUpdWork.StockTotal;            // 在庫総数
                invUpdPrd.ShipCustomerCode = baseInvUpdWork.ShipCustomerCode;      // 出荷先得意先コード
                invUpdPrd.ShipCustomerName = baseInvUpdWork.ShipCustomerName;      // 出荷先得意先名称
                invUpdPrd.ShipCustomerName2 = baseInvUpdWork.ShipCustomerName2;     // 出荷先得意先名称2
                invUpdPrd.InventoryPreprDay = baseInvUpdWork.InventoryPreprDay;     // 棚卸準備処理日付
                invUpdPrd.InventoryPreprTim = baseInvUpdWork.InventoryPreprTim;     // 棚卸準備処理時間
                invUpdPrd.InventoryDay = baseInvUpdWork.InventoryDay;          // 棚卸実施日
                invUpdPrd.LastInventoryUpdate = baseInvUpdWork.LastInventoryUpdate;   // 最終棚卸更新日
                invUpdPrd.InventoryNewDiv = baseInvUpdWork.InventoryNewDiv;       // 棚卸新規追加区分
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                invUpdPrd.StockMashinePrice = baseInvUpdWork.StockMashinePrice;     // マシン在庫額
                invUpdPrd.InventoryStockPrice = baseInvUpdWork.InventoryStockPrice;   // 棚卸在庫額
                invUpdPrd.InventoryTlrncPrice = baseInvUpdWork.InventoryTlrncPrice;   // 棚卸過不足金額
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                invUpdPrd.InventoryDate = baseInvUpdWork.InventoryDate;         // 棚卸日
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                invUpdPrd.Status = baseInvUpdWork.Status; // ステータス
                #endregion

                invUpdWorkList.Add(invUpdPrd);	// 追加リストにAdd
            }
        }
		   --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◆ カラムプロパティ設定処理
        #region ◎ CellActivationプロパティ設定処理
        /// <summary>
		/// CellActivationプロパティ設定処理
		/// </summary>
		/// <param name="columns">設定対象カラム</param>
		/// <param name="action">設定値</param>
		/// <param name="columnName">カラム名</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void SetCellActivation( ColumnsCollection columns, CellClickAction action, string columnName )
		{
			columns[ columnName ].CellClickAction = action;
		}
		#endregion

		#region ◎ CellClickActionプロパティ設定処理
		/// <summary>
		/// CellClickActionプロパティ設定処理
		/// </summary>
		/// <param name="columns">設定対象カラム</param>
		/// <param name="activation">設定値</param>
		/// <param name="columnName">カラム名</param>
		/// <remarks>
		/// <br>Note		: データ表示用のUltraGridの初期処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void SetCellClickAction( ColumnsCollection columns, Activation activation, string columnName )
		{
			columns[ columnName ].CellActivation = activation;
		}
		#endregion
		#endregion ◆ カラムプロパティ設定処理
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ 画面表示時処理
        /// <summary>
		/// 画面表示時処理
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: 画面表示時処理を実行する。</br>
		/// <br>Programmer	: 22013 kubo</br>
		/// <br>Date        : 2007.04.11</br>
        /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>              棚卸実施日の初期表示を変更する</br>
        /// <br>              REDMINE:2018　既存障害の修正</br>
        /// <br>UpdateNote : 2011/02/10 鄧潘ハン</br>
        /// <br>             障害報告 #18870</br>
        /// </remarks>
		private int ShowDataProc ( )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				if ( this._isFirstsetting )
				{
					this.tce_ViewStyle.SelectedIndex = 0;	// 表示方法(前回表示状態を取得してそれをセットする)
                    //this.tce_SortOrder.SelectedIndex = 0;	// ソート順 // DEL 2009/12/03
                    this.tce_SortOrder.SelectedIndex = this._inventInputAcs.SortOrde;	// ソート順 // ADD 2009/12/03

					// データバインド
					this._isFirstsetting = false;	// データをバインドするために一時的にoff
					ChangeViewStyle();
					this._isFirstsetting = true;	// 元に戻す

					// 初回起動時のみ画面設定
					// グリッドキーマッピング作成
					this.MakeGridKeyMapping( this.uGrid_InventInput);

					// Grid Setting
					this.InitialInventInputGrid( this.uGrid_InventInput.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ] );

					// カラム幅
					// 文字サイズ
					this._isFirstsetting = false;
					this._isEventAutoFillColumn = true;
				}
				else
				{
					//// データバインド
					//ChangeViewStyle();
                    ChangeViewStyle(); // ADD 2009/12/03
                    // ---ADD 2009/05/14 不具合対応[13260] --------------------------------------------->>>>>
                    //Noを割り当て
                    int idx = 1;
                    foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
                    {
                        gridRow.Cells[InventInputResult.ct_Col_No].Value = idx;
                        gridRow.Update();
                        idx++;
                    }
                    // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------<<<<<
				}

                if (this.uGrid_InventInput.Rows.Count > 0)
                {
                    //this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                    // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                    // 棚卸日セット
                    this.tde_InventoryExeDate.SetDateTime((DateTime)this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryExeDay_Datetime].Value);
                    // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

                    // --- ADD 2009/12/03 ---------->>>>>
                    // 棚卸実施日セット
                    this.tde_InventoryDate.SetDateTime(this.tde_InventoryExeDate.GetDateTime());
                    // --- ADD 2009/12/03 ----------<<<<<

                    // -- ADD 2009/09/11 -------------------->>>
                    // 過不足更新済み行のEnabled制御
                    SetGridEnabledTolUpd();
                    // -- ADD 2009/09/11 --------------------<<<
                }

                tde_InventoryDate.Focus();
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "棚卸データの表示に失敗しました。", status, "ShowDataProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
			}
            //---ADD 2011/02/10---------------------------------------------->>>>>
            foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
            {
                if("ｻｷﾀﾞｼ".Equals(gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Value) || ("ｶｼﾀﾞｼ".Equals(gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Value)))
                {
                     gridRow.Cells[InventInputResult.ct_Col_WarehouseShelfNo].Activation = Activation.NoEdit;
                }
            }
            //---ADD 2011/02/10----------------------------------------------<<<<<
			return status;
		}
		#endregion

        #region ◎ セル変更時処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// セル変更時処理
        /// </summary>
        /// <param name="activeCell">アクティブセル</param>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="isChangeInventStcCnt">棚卸数変更フラグ</param>
        /// <param name="isChangeInventDate">棚卸日変更フラグ</param>
        /// <param name="isShowProduct">子画面表示フラグ(未使用)</param>
        /// <br>UpdateNote : 2009/12/03 李占川 ＰＭ．ＮＳ保守依頼③</br>
        /// <br>             帳簿数＝0の行の原単価を変更時にエラーが発生しないように変更する</br>
        public void AfterExitEditModeProc(UltraGridCell activeCell, object sender, bool isChangeInventStcCnt, bool isChangeInventDate, bool isShowProduct)
        {
            string errMsg = "";
            // DataRow targetDr = (DataRow)activeCell.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;  //DEL yangyi 2013/03/01 Redmine#34175
            DataRow targetDr = GetBindDataRow(activeCell.Row);                                            //ADD yangyi 2013/03/01 Redmine#34175 
            try
            {
                errMsg = "棚卸数の入力に失敗しました。\r\n";

                // 棚卸数が入力されたとき
                if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0)
                {
                    // 選択件数設定
                    // 変更されていない場合は未処理
                    if (!isChangeInventStcCnt)
                    {
                        return;
                    }

                    if (activeCell.Text.TrimEnd() == "")
                    {
                        // 帳簿数
                        if (targetDr == null)
                        {
                            return;
                        }

                        double stockTotal = (double)targetDr[InventInputResult.ct_Col_StockTotal];
                        //activeCell.Value = DBNull.Value;
                        activeCell.Value = stockTotal;
                        //return;
                    }

                    // 2011/04/07 Del >>>
                    //// 棚卸数入力後処理
                    //AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    // 2011/04/07 Del <<<

                    // 棚卸日展開処理
                    //AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());      //DEL 2009/05/14 不具合対応[13260]　すでに入力されている値まで変更されてしまう為
                    // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------------------->>>>>
                    if (targetDr[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value)
                    {
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    else if ((DateTime)targetDr[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue)
                    {
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // ---ADD 2009/05/14 不具合対応[13260] -----------------------------------------------------<<<<<

                    // 2011/04/07 Add >>>
                    // 棚卸数入力後処理
                    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    // 2011/04/07 Add <<<

                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 棚卸更新日が入力されたとき( ActiveCellが年・月・日のいずれかの場合 )
                else if ((activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                          (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
                          (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                {
                    errMsg = "棚卸日の入力に失敗しました。\r\n";
                    // 年月日の入力が完了していない場合は処理キャンセル
                    if ((activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value == DBNull.Value) ||
                        (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value == DBNull.Value) ||
                        (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value == DBNull.Value))
                    {
                        return;
                    }
                    // 変更されていない場合は未処理
                    if (!isChangeInventDate)
                    {
                        return;
                    }

                    // 入力が正しい日付か？
                    int inputDate_int =
                        ((int)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value * 10000) +
                        ((int)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value * 100) +
                        ((int)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value);

                    DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);

                    // 2011/04/07 Del >>>
                    //// 棚卸数更新
                    //// 棚卸数未入力の場合のみ棚卸数を展開する
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // 棚卸数入力後処理
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    DateTime devDateTime = DateTime.MinValue;

                    if (inputDate != DateTime.MinValue)
                    {
                        devDateTime = inputDate;
                    }
                    else
                    {
                        devDateTime = this.tde_InventoryDate.GetDateTime();
                    }

                    // 棚卸日展開処理
                    AfterInputInventoryDate(ref targetDr, devDateTime);

                    // 2011/04/07 Add >>>
                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // 棚卸数入力後処理
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 倉庫棚番が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    errMsg = "棚番の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeWarehouseShelfNo)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// 棚卸数更新
                    //// 棚卸数未入力の場合のみ棚卸数を展開する
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // 棚卸数入力後処理
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    // 棚番入力後処理
                    AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_WarehouseShelfNo].ToString(), InventInputResult.ct_Col_WarehouseShelfNo);

                    // 日付更新
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // 棚卸日展開処理
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // 棚卸数入力後処理
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 重複棚番１が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    errMsg = "重複棚番１の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeDuplicationShelfNo1)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// 棚卸数更新
                    //// 棚卸数未入力の場合のみ棚卸数を展開する
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    // 棚番入力後処理
                    AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo1].ToString(), InventInputResult.ct_Col_DuplicationShelfNo1);

                    // 日付更新
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // 棚卸日展開処理
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 重複棚番２が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    errMsg = "重複棚番２の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeDuplicationShelfNo2)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// 棚卸数更新
                    //// 棚卸数未入力の場合のみ棚卸数を展開する
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // 棚卸数入力後処理
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    // 棚番入力後処理
                    AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo2].ToString(), InventInputResult.ct_Col_DuplicationShelfNo2);

                    // 日付更新
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // 棚卸日展開処理
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // 棚卸数入力後処理
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 原単価が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    errMsg = "原単価の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeStockUnitPrice)
                    {
                        return;
                    }

                    // 2011/04/07 Del >>>
                    //// 棚卸数更新
                    //// 棚卸数未入力の場合のみ棚卸数を展開する
                    //if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    //{
                    //    // 棚卸数入力後処理
                    //    AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    //}
                    // 2011/04/07 Del <<<

                    double stockTotal = (double)activeCell.Row.Cells[InventInputResult.ct_Col_StockTotal].Value;
                    // --- UPD 2009/12/03 ---------->>>>>
                    //double invStockCnt = (double)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                    double invStockCnt = 0;
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                    {
                        invStockCnt = (double)activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                    }
                    // --- UPD 2009/12/03 ----------<<<<<

                    double stockUnitPrice = (double)activeCell.Row.Cells[InventInputResult.ct_Col_StockUnitPrice].Value;

                    // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------------------------------------------->>>>>
                    targetDr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = 1;                                                                      //仕入単価変更フラグ
                    targetDr[InventInputResult.ct_Col_StockMashinePrice] = this._inventInputAcs.GetTotalPriceToLong(stockTotal,stockUnitPrice);     //マシン在庫額
                    targetDr[InventInputResult.ct_Col_InventoryStockPrice] = this._inventInputAcs.GetTotalPriceToLong(invStockCnt, stockUnitPrice); //棚卸在庫額
                    // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------------------------------------------------------<<<<<

                    // 原単価更新
                    //this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_StockUnitPrice].ToString(), InventInputResult.ct_Col_StockUnitPrice);     //DEL 2009/05/14 不具合対応[13260]
                    this.AfterInputStockUnitPrice(ref targetDr, (double)targetDr[InventInputResult.ct_Col_StockUnitPrice], InventInputResult.ct_Col_StockUnitPrice);            //ADD 2009/05/14 不具合対応[13260]

                    // 日付更新
                    string year = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        // 棚卸日展開処理
                        AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }

                    // 2011/04/07 Add >>>
                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        // 棚卸数入力後処理
                        AfterInputInventryToleCnt(ref targetDr, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }
                    // 2011/04/07 Add <<<

                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc(errMsg,
                                 (int)ConstantManagement.MethodResult.ctFNC_CANCEL,
                                 "uGrid_InventInput_CellChange",
                                 ex,
                                 emErrorLevel.ERR_LEVEL_STOPDISP);
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// セル変更時処理
		/// </summary>
		/// <param name="activeCell">アクティブセル</param>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="isChangeInventStcCnt">棚卸数変更フラグ</param>
		/// <param name="isChangeInventDate">棚卸日変更フラグ</param>
		/// <param name="isShowProduct">子画面表示フラグ(未使用)</param>
        public void AfterExitEditModeProc(Infragistics.Win.UltraWinGrid.UltraGridCell activeCell, object sender, bool isChangeInventStcCnt, bool isChangeInventDate, bool isShowProduct)
        {
			string errMsg = "";
			DataRow targetDr = (DataRow)activeCell.Row.Cells[ InventInputResult.ct_Col_RowSelf ].Value;
			try
			{
				errMsg = "棚卸数の入力に失敗しました。\r\n";
				// 棚卸数が入力されたとき
				if ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt ) == 0 )
				{
					// 選択件数設定
					// 変更されていない場合は未処理
					if ( !isChangeInventStcCnt ) return;

					if ( activeCell.Text.TrimEnd() == "" )
					{
						activeCell.Value = DBNull.Value;

						return;
					}
					// TODO:
					#region // 2007.07.19 kubo del 
					//((UltraGrid)sender).UpdateMode = UpdateMode.OnUpdate;
					//((UltraGrid)sender).UpdateData();	// グリッドを更新
					#endregion

					// 棚卸数更新
					this.AfterInputInventryToleCnt( 
						ref targetDr,
						(int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );

					// 2007.07.30 kubo add -------->
					//DateTime devData = this.tde_InventoryDate.GetDateTime();
					//if ( targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value && 
					//    (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt] == 0 &&
					//    (int)targetDr[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods &&
					//    (int)targetDr[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
					//{
					//    devData = DateTime.MinValue;
					//}
					//this.AfterInputInventoryDate( ref targetDr, devData );
					// 2007.07.30 kubo add <--------

					// 日付更新
					#region // 2007.07.30 kubo del
					this.AfterInputInventoryDate( ref targetDr, this.tde_InventoryDate.GetDateTime() );
					#endregion
					// 変更区分をセット
					targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				}
				// 棚卸更新日が入力されたとき( ActiveCellが年・月・日のいずれかの場合 )
				else if ( ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
						  ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
						  ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day) == 0 ) )
				{
					errMsg = "棚卸日の入力に失敗しました。\r\n";
					// 年月日の入力が完了していない場合は処理キャンセル
					if ( ( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value == DBNull.Value ) ||
						( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value == DBNull.Value ) ||
						( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value == DBNull.Value ) )
					{
						return;
					}
					// 変更されていない場合は未処理
					if ( !isChangeInventDate ) return;

					#region // 2007.07.19 kubo del -------------------------->
					//((UltraGrid)sender).UpdateMode = UpdateMode.OnUpdate;
					//((UltraGrid)sender).UpdateData();	// グリッドを更新
					#endregion

					// 入力が正しい日付か？
					int inputDate_int = 
						( (int)activeCell.Row.Cells[ InventInputResult.ct_Col_InventoryDay_Year ].Value * 10000 ) +
						( (int)activeCell.Row.Cells[ InventInputResult.ct_Col_InventoryDay_Month ].Value * 100 ) +
						( (int)activeCell.Row.Cells[ InventInputResult.ct_Col_InventoryDay_Day ].Value);

					DateTime inputDate = TDateTime.LongDateToDateTime( inputDate_int );

					// 棚卸数更新
					// 棚卸数未入力の場合のみ棚卸数を展開する
					if ( activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value )
					{
						this.AfterInputInventryToleCnt(
							ref targetDr, 
							(int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );
					}

					DateTime devDateTime = DateTime.MinValue;

					if ( inputDate != DateTime.MinValue )
					{
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
						devDateTime = inputDate;
                        //DateTime workDate = this.tde_InventoryExeDate.GetDateTime();
                        //if (inputDate > workDate.AddMonths(2))
                        //{
                        //    this.MsgDispProc("不正な日付です 棚卸日から２ヵ月以内で入力して下さい", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                        //    //this.tde_InventoryDate.Focus();
                        //    return;
                        //}
                        //else
                        //{
                        //    devDateTime = inputDate;
                        //}
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
					}
					else
					{
						devDateTime = this.tde_InventoryDate.GetDateTime();
					}
					
					// 日付更新
					this.AfterInputInventoryDate( ref targetDr, devDateTime );
					// 変更区分をセット
					targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				}
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                // 倉庫棚番が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    errMsg = "棚番の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeWarehouseShelfNo) return;

                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // 棚番更新
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_WarehouseShelfNo].ToString(), InventInputResult.ct_Col_WarehouseShelfNo);
                    // 日付更新
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 重複棚番１が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    errMsg = "重複棚番１の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeDuplicationShelfNo1) return;

                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // 棚番更新
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo1].ToString(), InventInputResult.ct_Col_DuplicationShelfNo1);
                    // 日付更新
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 重複棚番２が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    errMsg = "重複棚番２の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeDuplicationShelfNo2) return;

                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // 棚番更新
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_DuplicationShelfNo2].ToString(), InventInputResult.ct_Col_DuplicationShelfNo2);
                    // 日付更新
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                // 原単価が入力されたとき
                else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    errMsg = "原単価の入力に失敗しました。\r\n";

                    // 変更されていない場合は未処理
                    if (!_isChangeStockUnitPrice) return;

                    // 棚卸数更新
                    // 棚卸数未入力の場合のみ棚卸数を展開する
                    if (activeCell.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == DBNull.Value)
                    {
                        this.AfterInputInventryToleCnt(
                            ref targetDr,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);
                    }

                    // 原単価更新
                    this.AfterInputWarehouseShelfNo(ref targetDr, targetDr[InventInputResult.ct_Col_StockUnitPrice].ToString(), InventInputResult.ct_Col_StockUnitPrice);

                    // 日付更新
                    string year  = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value.ToString().Trim();
                    string month = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value.ToString().Trim();
                    string day   = activeCell.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value.ToString().Trim();
                    if ((year == "") || (month == "") || (day == ""))
                    {
                        this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());
                    }
                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                // 2007.07.25 kubo add ---------->
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //else if (activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_ProductNumber) == 0)
				//{
				//	errMsg = "製造番号の入力に失敗しました。\r\n";
				//	if ( this._isChangeInventProductNum )
				//		targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//}
				//else if ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo1 ) == 0 )
				//{
				//	errMsg = "電話番号1の入力に失敗しました。\r\n";
				//	if ( this._isChangeInventStockTelNo1 )
				//		targetDr[InventInputResult.ct_Col_BfStockTelNo1] = this._BfoerStockTelNo1;
				//		targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//}
				//else if ( activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo2 ) == 0 )
				//{
				//	errMsg = "電話番号2の入力に失敗しました。\r\n";
				//	if ( this._isChangeInventStockTelNo2 )
				//		targetDr[InventInputResult.ct_Col_BfStockTelNo2] = this._BfoerStockTelNo2;
				//		targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//}
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.07.25 kubo add <----------
			}
			catch ( Exception ex )
			{
				this.MsgDispProc( 
					errMsg,
					(int)ConstantManagement.MethodResult.ctFNC_CANCEL,
					"uGrid_InventInput_CellChange",
					ex,
					emErrorLevel.ERR_LEVEL_STOPDISP);
			}
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 棚卸数入力後処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸数入力後処理
        /// </summary>
        /// <param name="targetDr"></param>
        /// <param name="viewState"></param>
        /// <param name="isShowSelectProduct"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 棚卸数の入力後処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int AfterInputInventryToleCnt(ref DataRow targetDr, int viewState, ref bool isShowSelectProduct)
        {
            double invStcCnt = 0;

            // 棚卸数取得
            if (targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
            {
                invStcCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
            }
            else
            {
                invStcCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];
            }

            // 差異数設定
            //double toleCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal] - invStcCnt;       //DEL 2009/05/14 不具合対応[13260]
            double toleCnt = invStcCnt - (double)targetDr[InventInputResult.ct_Col_StockTotal];         //ADD 2009/05/14 不具合対応[13260]

            // 自行に差異数を展開
            ChangeCommitToleranceCnt(ref targetDr, toleCnt, invStcCnt);

            // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
            //// 親・子行取得Query作成
            //this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
            //            MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
            //            viewState);
            //this._inventInputView.Sort = string.Format("{0} Desc, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal);
            //this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            //DataRow childRow;
            //for (int index = 0; index < this._inventInputView.Count; index++)
            //{
            //    childRow = this._inventInputView[index].Row;
                
            //    // 子行に差異数を展開
            //    ChangeCommitToleranceCnt(ref childRow, toleCnt, invStcCnt);
            //}
            // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
            //---------- ADD 2013/02/25 #34175 yangyi------------------->>>>>
            this._inventInputView.Sort = InventInputResult.ct_Col_SectionCode + "," + InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode
                                        + "," + InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_SupplierCode + "," + InventInputResult.ct_Col_ShipCustomerCode
                                        + "," + InventInputResult.ct_Col_StockDiv + "," + InventInputResult.ct_Col_GrossDiv;
            object[] primaryKeyObjList = new object[]{
				targetDr[InventInputResult.ct_Col_SectionCode].ToString(),			// 拠点コード
				targetDr[InventInputResult.ct_Col_WarehouseCode].ToString(),			// 倉庫コード
				(int)targetDr[InventInputResult.ct_Col_MakerCode],				// メーカーコード
                targetDr[InventInputResult.ct_Col_GoodsNo].ToString(),             // 品番
				(int)targetDr[InventInputResult.ct_Col_SupplierCode],		// 仕入先コード
				(int)targetDr[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
				(int)targetDr[InventInputResult.ct_Col_StockDiv],				// 在庫区分
				(int)InventInputSearchCndtn.GrossDivState.Product// 集計区分
				};

            // フィルタクリア
            this._inventInputView.RowFilter = string.Empty; // ADD by xuyb 2014/10/31 for 障害現象②の対応

            DataRowView[] drv = this._inventInputView.FindRows(primaryKeyObjList);

            DataRow childRow;
            foreach (DataRowView dataRowView in drv)
            {
                childRow = dataRowView.Row;
                // 子行に差異数を展開
                ChangeCommitToleranceCnt(ref childRow, toleCnt, invStcCnt);
            }
            //---------- ADD 2013/02/25 #34175 yangyi-------------------<<<<<

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 棚卸数入力後処理
		/// </summary>
		/// <param name="targetDr"></param>
		/// <param name="viewState"></param>
		/// <param name="isShowSelectProduct"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 棚卸数の入力後処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private int AfterInputInventryToleCnt( ref DataRow targetDr, int viewState, ref bool isShowSelectProduct )
		{
			double invStcCnt = 0;
			// 棚卸数取得
			if ( targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
				invStcCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
			else
				invStcCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];

			// 差異数設定
			double toleCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal] - invStcCnt;

			// 自行に差異数を展開
			ChangeCommitToleranceCnt( ref targetDr, toleCnt, invStcCnt, false );

            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
                        viewState);
            this._inventInputView.Sort = string.Format("{0} Desc, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal);
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            DataRow childRow;
            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                childRow = this._inventInputView[index].Row;
                // 子行に差異数を展開
                ChangeCommitToleranceCnt(ref childRow, toleCnt, invStcCnt, false);
            }
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            #region 2007.09.11 削除
            //// データの集計区分を見る
			//if ( (int)targetDr[ InventInputResult.ct_Col_GrossDiv ] == (int)InventInputSearchCndtn.GrossDivState.Goods )
			//{
            //    // 子行に棚卸数を展開
			//	if ( ((int)targetDr[ InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product) )
			//	{
			//		// 製番未入力データへの展開とか色々あるから別メソッドにする。
			//		DevInventStockCntToProductGoodsChildRow( ref targetDr );
            //    
			//	}
			//	else
			//	{
			//		// 商品の子データを検索
			//		DevInventStockCntToChildRow( ref targetDr, (int)InventInputSearchCndtn.ViewState.NotView );
			//	}
				#region
				//// 子画面表示判断
				//if ( isShowSelectProduct )
				//{
				//    // 製番管理区分を見る
				//    if ( (int)targetDr[ InventInputResult.ct_Col_PrdNumMngDiv ] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
				//    {
				//        // 差異数がゼロ以外のとき表示の可能性がある
				//        if ( (double)targetDr[ InventInputResult.ct_Col_InventoryTolerancCnt] != 0 )
				//        {
				//            isShowSelectProduct = true;
				//        }
				//        else
				//        {
				//            isShowSelectProduct = false;
				//        }
				//    }
				//    else
				//    {
				//        isShowSelectProduct = false;
				//    }
				//}
				#endregion
			//}
			//else
			//{
				// 製番データが選ばれている場合
				#region // 2007.07.24 kubo del
				//// 製番未入力のグロスデータ？
				//if ( targetDr[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
				//{
				//    // 非表示になっている製番未入力データに棚卸数を反映
				//    // 子行に棚卸数を展開
				//    DevInventStockCntToChildRow( ref targetDr, (int)InventInputSearchCndtn.ViewState.NotView );
				//}
				#endregion
			//	// 製番の親データに差異数を加算
			//	ChangeCommitToleranceCnt( ref targetDr, toleCnt, invStcCnt, true );
            //
			//	isShowSelectProduct = false;
			//}
            #endregion
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region 2007.09.11 削除
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 親→子棚卸数展開処理
        /*
		/// <summary>
		/// 親→子棚卸数展開処理
		/// </summary>
		/// <param name="targetDr">対象DataRow</param>
		/// <param name="viewState">表示区分</param>
		private void DevInventStockCntToChildRow( ref DataRow targetDr, int viewState )
		{
			// 子行を取得
			// 新規行から引当てていく
			#region // 2007.07.19 kubo del
			//DataView childDv = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            viewState ),
			//        //string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
			//        string.Format( "{0} Desc, {1} Desc, {2}", InventInputResult.ct_Col_InventoryNewDiv,InventInputResult.ct_Col_StockTotal, InventInputResult.ct_Col_ProductNumber ),
			//        DataViewRowState.CurrentRows);

			//// 子行に差異数を反映
			//double stockCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];				// 帳簿在庫数
			//double inventCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];	// 棚卸在庫数
			//double remInventCnt = inventCnt;
			//for( int index = 0; index < childDv.Count; index++ )
			//{
			//    if ( ChangeChildRowInvent( ref childDv, index, stockCnt, inventCnt ) )
			//    {
			//        remInventCnt--;
			//    }
			//    else
			//    {
			//        break;
			//    }
			//}
		
			//if ( childDv.Count > 0 )
			//{
			//    double addRowCnt = inventCnt - childDv.Count;
			//    bool isView = false;

			//    if ( (int)childDv[0][InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
			//        isView = true;
			//    else
			//        isView = false;

			//    // 帳簿数が棚卸在庫数以上の場合
			//    // 新規行の追加
			//    DataRow childRow;
			//    for ( int localIndex = 0; localIndex < addRowCnt; localIndex++ )
			//    {			
			//        childRow = this._inventInputAcs.InventDataTable.NewRow();

			//        this._inventInputAcs.CopyRowToRow( childDv[0].Row, ref childRow, isView );

			//        childRow[InventInputResult.ct_Col_MoveStatus] = 0;
			//        childRow[InventInputResult.ct_Col_MoveStockCount] = 0;
			//        childRow[InventInputResult.ct_Col_InventoryNewDiv] = (int)targetDr[InventInputResult.ct_Col_InventoryNewDiv];
			//        childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
			//        childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

			//        this._inventInputAcs.InventDataTable.Rows.Add( childRow );
			//    }
			//}
			#endregion	
			// 2007.07.19 kubo add ------------->
			this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						viewState );
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventInputView.Sort = string.Format("{0} Desc, {1} Desc, {2}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal, InventInputResult.ct_Col_ProductNumber);
            this._inventInputView.Sort = string.Format("{0} Desc, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_StockTotal);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
			// 2007.07.19 kubo add <-------------

			// 子行に差異数を反映
			double stockCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];				// 帳簿在庫数
			double inventCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];	// 棚卸在庫数
			double remInventCnt = inventCnt;
			for( int index = 0; index < this._inventInputView.Count; index++ )
			{
				if ( ChangeChildRowInvent( ref this._inventInputView, index, stockCnt, inventCnt ) )
				{
					remInventCnt--;
				}
				else
				{
					break;
				}
			}
		
			double addRowCnt = 0;
			// 2007.07.30 kubo add ------------------>
			bool isProductMng = false;
			DataRow baseRow = null;	

			if ( this._inventInputView.Count > 0 )
			{
				baseRow = this._inventInputView[0].Row;
				addRowCnt = inventCnt - this._inventInputView.Count;
				isProductMng = true;
			}
			else
			{
				baseRow = targetDr;
				addRowCnt = inventCnt;
				isProductMng = false;
			}
			// 2007.07.30 kubo add <------------------

			// if ( this._inventInputView.Count > 0 ) // 2007.07.30 kubo del
			if ( addRowCnt > 0 ) // 2007.07.30 kubo add
			{
				bool isView = false;

				//if ( (int)this._inventInputView[0][InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //if ((int)baseRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
				//	isView = true;
				//else
				//	isView = false;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

				// 帳簿数が棚卸在庫数以上の場合
				// 2007.07.26 kubo add --------------->
				// 製番設定画面起動
				if ( this._productNumInput == null )
					this._productNumInput = new ProductNumInput();
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //ArrayList productNumList = null;
				//int prdStatus = 0;
                //
                //if ((int)targetDr[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
				//	prdStatus = this._productNumInput.ShowProductInventInput( out productNumList, addRowCnt, this );
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

				//if ( prdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				//    return;
				// 2007.07.26 kubo add <---------------

				// 新規行の追加
				DataRow childRow;
				for ( int localIndex = 0; localIndex < addRowCnt; localIndex++ )
				{			
					childRow = this._inventInputAcs.InventDataTable.NewRow();

					this._inventInputAcs.CopyRowToRow( targetDr, ref childRow, isView );

                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //childRow[InventInputResult.ct_Col_MoveStatus] = 0;
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    childRow[InventInputResult.ct_Col_MoveStockCount] = 0;
					childRow[InventInputResult.ct_Col_InventoryNewDiv] = (int)targetDr[InventInputResult.ct_Col_InventoryNewDiv];
					childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
					childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

					// 2007.07.30 kubo add --------->
					if ( !isProductMng )
					{
						childRow[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.NotView;	// 非表示
					}
					// 2007.07.30 kubo add <---------

					// 2007.07.26 kubo add --------------->
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //if (productNumList != null && localIndex < productNumList.Count)
					//{
                    //    if (((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
					//		childRow[InventInputResult.ct_Col_ProductNumber] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_ProductNumber] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = "";
					//}
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.26 kubo add --------------->
					this._inventInputAcs.InventDataTable.Rows.Add( childRow );
				}
			}
		}
        */
        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 親→子棚卸数展開処理(製番管理有-商品毎データ用処理)
        /*
        /// <summary>
		/// 親→子棚卸数展開処理(製番管理有-商品毎データ用処理)
		/// </summary>
		/// <param name="targetDr">対象DataRow</param>
		private void DevInventStockCntToProductGoodsChildRow( ref DataRow targetDr )
		{
			//object sumInvStkCnt;
			//bool isChildChg = false;
			int prd_Old_Count = 0;	// 製番管理有 既存
			int noPrd_Old_Count = 0;	// 製番管理無 既存
			int prd_New_Count = 0;	// 製番管理有 新規
			int noPrd_New_Count = 0;	// 製番管理無 新規
			DataRow childRow;

            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //string sortOrder = string.Format("{0} Desc, {1} Desc, {2}", 
			//	InventInputResult.ct_Col_InventoryNewDiv,
			//	InventInputResult.ct_Col_StockTotal,
			//	InventInputResult.ct_Col_ProductNumber );
            string sortOrder = string.Format("{0} Desc, {1}", 
            	InventInputResult.ct_Col_InventoryNewDiv,
            	InventInputResult.ct_Col_StockTotal );
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<


			// 子行を取得
			// 既存データ取得 --------------------------------------------------
			#region
			// 製番入力済みの行を取得 --------------------------------------------------
			#region // 2007.07.24 kubo del
			//string strFilter_Prd_Old = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.View );
			//if ( strFilter_Prd_Old.CompareTo("") != 0 )
			//{
			//    strFilter_Prd_Old = strFilter_Prd_Old + " and ";
			//}
			//// 製番が入力済みの既存データを取得
			//strFilter_Prd_Old = strFilter_Prd_Old + string.Format("{0}<>''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old);
			//// View取得
			//// ソートは新規区分(降順),棚卸数,製番（新規区分は既存分しかとってないから意味無いけどいちおう。）
			//DataView childDv_Prd_Old = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_Prd_Old,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add ------------------------->
			StringBuilder strFilter_Prd_Old = new StringBuilder(
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ));
			if ( strFilter_Prd_Old.ToString().CompareTo("") != 0 )
			{
				strFilter_Prd_Old.Append(" and " );
			}
			// 製番が入力済みの既存データを取得
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //strFilter_Prd_Old.Append(string.Format("{0}<>''", InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old) );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // View取得
			// ソートは新規区分(降順),棚卸数,製番（新規区分は既存分しかとってないから意味無いけどいちおう。）
			DataView childDv_Prd_Old = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_Prd_Old.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <-------------------------

			prd_Old_Count = childDv_Prd_Old.Count;



			// 製番未入力の行を取得 --------------------------------------------------
			#region // 2007.07.24 kubo del
			//string strFilter_NoPrd_Old = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.NotView );
			//if ( strFilter_NoPrd_Old.CompareTo("") != 0 )
			//{
			//    strFilter_NoPrd_Old = strFilter_NoPrd_Old + " and ";
			//}
			//strFilter_NoPrd_Old = strFilter_NoPrd_Old + string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old);
			//// View取得
			//DataView childDv_NoPrd_Old = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_NoPrd_Old,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add -------------------------->
			StringBuilder strFilter_NoPrd_Old = new StringBuilder( 
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ) );
			if ( strFilter_NoPrd_Old.ToString().CompareTo("") != 0 )
			{
				strFilter_NoPrd_Old.Append( " and " );
			}
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //strFilter_NoPrd_Old.Append(string.Format("{0}=''", InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old));
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // View取得
			DataView childDv_NoPrd_Old = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_NoPrd_Old.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <--------------------------
			noPrd_Old_Count = childDv_NoPrd_Old.Count;
			#endregion

			// 新規データ取得--------------------------------------------------
			#region
			#region // 2007.07.24 kubo del
			// 製番入力済みの行を取得 --------------------------------------------------
			//string strFilter_Prd_New = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.View );
			//if ( strFilter_Prd_New.CompareTo("") != 0 )
			//{
			//    strFilter_Prd_New = strFilter_Prd_New + " and ";
			//}

			//// 製番が入力済みの既存データを取得 --------------------------------------------------
			//strFilter_Prd_New = strFilter_Prd_New + 
			//    string.Format("{0}<>''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New);
			//// View取得
			//DataView childDv_Prd_New = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_Prd_New,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add -------------------------->
			StringBuilder strFilter_Prd_New = new StringBuilder ( 
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ) );
			if ( strFilter_Prd_New.ToString().CompareTo("") != 0 )
			{
				strFilter_Prd_New.Append( " and " );
			}

			// 製番が入力済みの既存データを取得 --------------------------------------------------
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //strFilter_Prd_New.Append(
			//	string.Format("{0}<>''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New) );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // View取得
			DataView childDv_Prd_New = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_Prd_New.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <--------------------------
			prd_New_Count = childDv_Prd_New.Count;



			// 製番未入力の行を取得
			#region // 2007.07.24 kubo del
			//string strFilter_NoPrd_New = MakeParentOrChildRowGetQuery( 
			//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//            (int)InventInputSearchCndtn.ViewState.NotView );
			//if ( strFilter_NoPrd_New.CompareTo("") != 0 )
			//{
			//    strFilter_NoPrd_New = strFilter_NoPrd_New + " and ";
			//}
			//strFilter_NoPrd_New = strFilter_NoPrd_New + string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//    string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New);
			//// View取得
			//DataView childDv_NoPrd_New = 
			//    new DataView( 
			//        this._inventInputAcs.InventDataTable, 
			//        strFilter_NoPrd_New,
			//        sortOrder,
			//        DataViewRowState.CurrentRows);
			#endregion
			// 2007.07.24 kubo add -------------------------->
			StringBuilder strFilter_NoPrd_New = new StringBuilder(
				MakeParentOrChildRowGetQuery( 
						MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
						(int)InventInputSearchCndtn.ViewState.View ));
			if ( strFilter_NoPrd_New.ToString().CompareTo("") != 0 )
			{
				strFilter_NoPrd_New.Append( " and " );
			}
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //strFilter_NoPrd_New.Append(string.Format("{0}=''", InventInputResult.ct_Col_ProductNumber) + " and " +
			//	string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New) );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // View取得
			DataView childDv_NoPrd_New = 
				new DataView( 
					this._inventInputAcs.InventDataTable, 
					strFilter_NoPrd_New.ToString(),
					sortOrder,
					DataViewRowState.CurrentRows);
			// 2007.07.24 kubo add <--------------------------

			noPrd_New_Count = childDv_NoPrd_New.Count;
			#endregion

			// 子行に差異数を反映
			double stockCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal];			// 帳簿在庫数
			double inventCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];	// 棚卸在庫数
			
			// 展開する行の総数を取得
			double remInventCnt = inventCnt;

			// 総RowCount
			double totalRowCnt = prd_Old_Count + noPrd_Old_Count + prd_New_Count + noPrd_New_Count;
			double newInventCnt = inventCnt - totalRowCnt;


			// 製番入力済 既存 -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < prd_Old_Count; index++ )
			{
			    // 子行に反映
				if ( remInventCnt > 0 )
				{
					if ( ChangeChildRowInvent( ref childDv_Prd_Old, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// 展開残数 = 展開残数 - (新規追加行数)
						//remInventCnt = remInventCnt - prd_Old_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_Prd_Old[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
				}
			}
			inventCnt = remInventCnt;
			#endregion

			// 製番未入力 既存 -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < noPrd_Old_Count; index++ )
			{
				
				// まず非表示になっている最小単位のデータに棚卸数を展開する。
				// 展開した後、最後に親データに展開を書ける
			    // 子行に反映
				if ( remInventCnt > 0 )
				{
					//isChildChg = true;
					if ( ChangeChildRowInvent( ref childDv_NoPrd_Old, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// 展開残数 = 展開残数 - (新規追加行数)
						//remInventCnt = remInventCnt - noPrd_Old_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_NoPrd_Old[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
					//isChildChg = true;
				}
			}

			// 新規行作成判断
			// 棚卸数が総行数より多かったら新規行を追加
			if ( ( newInventCnt > 0 ) && ( remInventCnt > 0 ) )
			{
				DataRow parentRow;
				bool isView = false;

				if ( childDv_Prd_Old.Count > 0 )
					parentRow = childDv_Prd_Old[0].Row;
				else if ( childDv_NoPrd_Old.Count > 0 )
					parentRow = childDv_NoPrd_Old[0].Row;
				else
					parentRow = targetDr;


                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //if ((int)parentRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product)
				//	isView = true;
				//else
				//	isView = false;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

				// 帳簿数が棚卸在庫数以上の場合
				// 2007.07.26 kubo add --------------->
				// 製番設定画面起動
				if ( this._productNumInput == null )
					this._productNumInput = new ProductNumInput();
				
				ArrayList productNumList = null;

                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //int prdStatus = 0;
				//if ( (int)parentRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
				//	prdStatus = this._productNumInput.ShowProductInventInput( out productNumList, newInventCnt, this );
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

				//if ( prdStatus != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				//    return;
				// 2007.07.26 kubo add <---------------

				// 新規行の追加
				childRow = null;
				for ( int localIndex = 0; localIndex < newInventCnt; localIndex++ )
				{			
					CreateNewRowToRow( parentRow, ref childRow, (int)InventInputSearchCndtn.NewRowState.New, isView );

					// 2007.07.26 kubo add --------------->
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //if (productNumList != null && localIndex < productNumList.Count)
					//{
                    //    if (((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
					//		childRow[InventInputResult.ct_Col_ProductNumber] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_ProductNumber] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo1] = "";
                    //
					//	if ( ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = ((DataRow)productNumList[localIndex])[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
					//	else
					//		childRow[InventInputResult.ct_Col_StockTelNo2] = "";
					//}
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.26 kubo add --------------->

					//isChildChg = true;

					// グロスデータ作る
					this._inventInputAcs.MakeGrossData( childRow, false );

					remInventCnt--;
				}
			}
			inventCnt = remInventCnt;

			#region // 2007.07.24 kubo del
			//// 親行取得
			//// 製番未入力の行を取得
			//if ( isChildChg )
			//{
			//    string strFilter_parentNoPrd_Old = MakeParentOrChildRowGetQuery( 
			//                MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//                (int)InventInputSearchCndtn.ViewState.View );
			//    if ( strFilter_parentNoPrd_Old.CompareTo("") != 0 )
			//    {
			//        strFilter_parentNoPrd_Old = strFilter_parentNoPrd_Old + " and ";
			//    }
			//    strFilter_parentNoPrd_Old = strFilter_parentNoPrd_Old + 
			//        string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//        string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.Old);
			//    // View取得
			//    DataView parentDv_NoPrd_Old = 
			//        new DataView( 
			//            this._inventInputAcs.InventDataTable, 
			//            strFilter_parentNoPrd_Old,
			//            string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
			//            DataViewRowState.CurrentRows);

			//    if ( parentDv_NoPrd_Old.Count > 0 )
			//    {
			//        // 親行は一行しか入ってこないはずなのでDataViewの要素のIndexは0で固定
			//        // 子行の棚卸数を取得
			//        sumInvStkCnt = this._inventInputAcs.InventDataTable.Compute(
			//            string.Format("Sum({0})",InventInputResult.ct_Col_InventoryStockCnt),strFilter_NoPrd_Old);
						
			//        if ( sumInvStkCnt != DBNull.Value )
			//        {
			//            parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryStockCnt] = (double)sumInvStkCnt;
			//        }
			//        else
			//        {
			//            parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryStockCnt] = 0;
			//        }

			//        // 差異数の展開
			//        parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
			//            (double)parentDv_NoPrd_Old[0][InventInputResult.ct_Col_InventoryStockCnt] -
			//            (double)parentDv_NoPrd_Old[0][InventInputResult.ct_Col_StockTotal];
			//    }
			//    else
			//    {

			//        this.MsgDispProc( "棚卸数の展開に失敗しました", -1, "DevInventStockCntToProductGoodChildRow", emErrorLevel.ERR_LEVEL_STOPDISP );
			//        return;
			//    }
			//}
			#endregion
			//isChildChg = false;
			#endregion

			// 製番入力済 新規 -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < prd_New_Count; index++ )
			{
			    // 子行に反映
				if ( remInventCnt > 0 )
				{
					if ( ChangeChildRowInvent( ref childDv_Prd_New, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// 展開残数 = 展開残数 - (新規追加行数)
						//remInventCnt = remInventCnt - prd_New_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_Prd_New[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
				}
			}
			inventCnt = remInventCnt;
			#endregion

			// 製番未入力 新規 -----------------------------------------------------------------------------------------
			#region
			for ( int index = 0; index < noPrd_New_Count; index++ )
			{
				// まず非表示になっている最小単位のデータに棚卸数を展開する。
				// 展開した後、最後に親データに展開を書ける
			    // 子行に反映
				if ( remInventCnt > 0 )
				{
					//isChildChg = true;
					if ( ChangeChildRowInvent( ref childDv_NoPrd_New, index, stockCnt, inventCnt ) )
					{
						remInventCnt--;
					}
					else
					{
						// 展開残数 = 展開残数 - (新規追加行数)
						//remInventCnt = remInventCnt - noPrd_New_Count - newInventCnt;
						break;
					}
				}
				else
				{
					childRow = childDv_NoPrd_New[index].Row;
					ChangeCommitToleranceCnt( ref childRow, 0, 0, false );
					//isChildChg = true;
				}
			}
			inventCnt = remInventCnt;

			#region // 2007.07.24 kubo del
			//if ( isChildChg )
			//{
			//    // 親行取得
			//    // 製番未入力の行を取得
			//    string strFilter_parentNoPrd_New = MakeParentOrChildRowGetQuery( 
			//                MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetDr ), 
			//                (int)InventInputSearchCndtn.ViewState.View );
			//    if ( strFilter_parentNoPrd_New.CompareTo("") != 0 )
			//    {
			//        strFilter_parentNoPrd_New = strFilter_parentNoPrd_New + " and ";
			//    }
			//    strFilter_parentNoPrd_New = strFilter_parentNoPrd_New + 
			//        string.Format("{0}=''",InventInputResult.ct_Col_ProductNumber) + " and " +
			//        string.Format("{0}={1}",InventInputResult.ct_Col_InventoryNewDiv,(int)InventInputSearchCndtn.NewRowState.New);
			//    // View取得
			//    DataView parentDv_NoPrd_New = 
			//        new DataView( 
			//            this._inventInputAcs.InventDataTable, 
			//            strFilter_parentNoPrd_New,
			//            string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
			//            DataViewRowState.CurrentRows);

			//    if ( parentDv_NoPrd_New.Count > 0 )
			//    {
			//        // 親行は一行しか入ってこないはずなのでDataViewの要素のIndexは0で固定
			//        // 子行の棚卸数を取得
			//        sumInvStkCnt = this._inventInputAcs.InventDataTable.Compute(
			//            string.Format("Sum({0})",InventInputResult.ct_Col_InventoryStockCnt), strFilter_NoPrd_New);
						
			//        if ( sumInvStkCnt != DBNull.Value )
			//        {
			//            parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryStockCnt] = (double)sumInvStkCnt;
			//        }
			//        else
			//        {
			//            parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryStockCnt] = 0;
			//        }

			//        // 差異数の展開
			//        parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
			//            (double)parentDv_NoPrd_New[0][InventInputResult.ct_Col_InventoryStockCnt] -
			//            (double)parentDv_NoPrd_New[0][InventInputResult.ct_Col_StockTotal];
			//    }
			//    else
			//    {
			//        this.MsgDispProc( "棚卸数の展開に失敗しました", -1, "DevInventStockCntToProductGoodChildRow", emErrorLevel.ERR_LEVEL_STOPDISP );
			//        return;
			//    }
			//}
			#endregion
			inventCnt = inventCnt - remInventCnt;
			#endregion
		}
        */
        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 新規行作成処理
        /*
        /// <summary>
		/// 新規行作成処理
		/// </summary>
		/// <param name="parentRow">親行</param>
		/// <param name="childRow">子行</param>
		/// <param name="newRowDiv">新規行区分</param>
		/// <param name="isView">表示区分</param>
		private void CreateNewRowToRow( DataRow parentRow, ref DataRow childRow, int newRowDiv, bool isView )
		{
			childRow = this._inventInputAcs.InventDataTable.NewRow();

			// データのコピー
			this._inventInputAcs.CopyRowToRow(parentRow, ref childRow, isView);

			// ファイルヘッダ初期化
			Guid newRowGuid = Guid.NewGuid();
			// 作成日時
			childRow[InventInputResult.ct_Col_CreateDateTime] = DateTime.MinValue;
			// 更新日時
			childRow[InventInputResult.ct_Col_UpdateDateTime] = DateTime.MinValue;
			// GUID
			childRow[InventInputResult.ct_Col_FileHeaderGuid] = Guid.Empty;
			// 更新従業員コード
			childRow[InventInputResult.ct_Col_UpdEmployeeCode] = "";
			// 更新アセンブリID1
			childRow[InventInputResult.ct_Col_UpdAssemblyId1] = "";
			// 更新アセンブリID2
			childRow[InventInputResult.ct_Col_UpdAssemblyId2] = "";
			// 論理削除区分
			childRow[InventInputResult.ct_Col_LogicalDeleteCode] = 0;

			// 移動状態
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //childRow[InventInputResult.ct_Col_MoveStatus] = 0;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            childRow[InventInputResult.ct_Col_MoveStockCount] = 0;

			// キー項目
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //childRow[InventInputResult.ct_Col_ProductNumber] = "";
            //childRow[InventInputResult.ct_Col_ProductStockGuid] = newRowGuid;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            childRow[InventInputResult.ct_Col_key] = newRowGuid;
			#region // 2007.07.24 kubo del
			//childRow[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.NotView;
			#endregion

			childRow[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 2007.07.24 kubo add

			childRow[InventInputResult.ct_Col_UpdateDiv] = 0; // 更新対象
			childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
			childRow[InventInputResult.ct_Col_InventoryNewDiv] = newRowDiv;
			childRow[InventInputResult.ct_Col_InventoryNewDivName] = "";

			this._inventInputAcs.InventDataTable.Rows.Add(childRow);
		}
        */
        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 親→子棚卸数展開処理(製番管理有-商品毎データ用処理)
        /*
        /// <summary>
		/// 親→子棚卸数展開処理(製番管理有-商品毎データ用処理)
		/// </summary>
		/// <param name="childDv">展開DataView</param>
		/// <param name="index">index</param>
		/// <param name="stockCnt">帳簿数</param>
		/// <param name="inventCnt"></param>
		/// <returns>true:そのまま続行, false:処理終了</returns>
		private bool ChangeChildRowInvent( ref DataView childDv, int index, double stockCnt, double inventCnt )
		{
			
			bool isReturn = true;
			DataRow childRow;
			if ( index >= childDv.Count )
				return false;
		    // 子行に反映
			childRow = childDv[index].Row;
			if ( index < inventCnt )
			{
				// indexが在庫棚卸数より小さい場合
				if ( inventCnt == 0 )
					ChangeCommitToleranceCnt( 
						ref childRow, 
						0 - (double)childRow[InventInputResult.ct_Col_StockTotal], 
						0, 
						false );
				else
					ChangeCommitToleranceCnt( 
						ref childRow, 
						1 - (double)childRow[InventInputResult.ct_Col_StockTotal], 
						1, 
						false );
			}
			else
			{
				// indexが在庫棚卸数より大きい場合
				ChangeCommitToleranceCnt( 
					ref childRow, 
					0 - (double)childRow[InventInputResult.ct_Col_StockTotal], 
					0, 
					false );
			}
			isReturn = true;
			return isReturn;
		}
        */
        #endregion
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region ◎ 差異数反映処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 差異数反映処理
        /// </summary>
        /// <param name="childDr">子行</param>
        /// <param name="toleCnt">差異数</param>
        /// <param name="invStcCnt">棚卸数</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 子→親へ差異数を反映する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int ChangeCommitToleranceCnt(ref DataRow childDr, double toleCnt, double invStcCnt)
        {
            DataRow targetDr;

            // 商品毎のときは引数のDataRowに入力
            targetDr = childDr;

            // 前回差異数に今回差異数をセット
            double bfInvToleCnt = 0;
            if (targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value)
            {
                bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
            }
            else
            {
                bfInvToleCnt = 0;
            }
            // 前回差異数
            targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;
            // 棚卸数
            targetDr[InventInputResult.ct_Col_InventoryStockCnt] = invStcCnt;
            // 変更区分をセット
            targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

            // 差異数
            //targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] =
            //    (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetDr[InventInputResult.ct_Col_StockTotal];
            targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] = toleCnt;

            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------->>>>>
            double stockUnitPrice = (double)targetDr[InventInputResult.ct_Col_StockUnitPrice];
            targetDr[InventInputResult.ct_Col_InventoryStockPrice] = this._inventInputAcs.GetTotalPriceToLong(invStcCnt, stockUnitPrice);
            // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------------<<<<<

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 差異数反映処理
		/// </summary>
		/// <param name="childDr">子行</param>
		/// <param name="toleCnt">差異数</param>
		/// <param name="invStcCnt">棚卸数</param>
		/// <param name="isProductFlg">製番毎行フラグ(true:製番毎, false:商品毎)</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 子→親へ差異数を反映する</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private int ChangeCommitToleranceCnt( ref DataRow childDr, double toleCnt, double invStcCnt, bool isProductFlg )
		{
			DataRow targetDr;
			if ( isProductFlg )
			{
				double parentToleCnt = 0;
				// 製番のときの処理
				// 製番子行が変更されたときは親行を捜す
				// 親行の取得
				#region // 2007.07.19 kubo del
				//DataView parentDv = 
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods, childDr ),
				//            (int)InventInputSearchCndtn.ViewState.View),
				//        "",
				//        DataViewRowState.CurrentRows);
				//if ( parentDv.Count > 0 )
				//{
				//    // 親行は一行しか入ってこないはずなのでDataViewの要素のIndexは0で固定
				//    targetDr = parentDv[0].Row;
				//}
				//else
				//{
				//    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				//}
				#endregion

				// 2007.07.19 kubo add ------------->
				targetDr = this._inventInputAcs.InventDataTable.Rows.Find( 
					this._inventInputAcs.GetPrimaryKeyList(childDr, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));

				if ( targetDr == null )
				{
					// 編集のときとか親行が無いデータができたりするので新規に親行を作る
					this._inventInputAcs.MakeGrossData( childDr, true );
					return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				}
				else
				{
					#region 2007.07.19 kubo del
					//this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
					//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods, childDr ),
					//            (int)InventInputSearchCndtn.ViewState.View );
					//this._inventInputView.Sort = "";
					//this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

					//if ( _inventInputView.Count > 0 )
					//{
					//    // 親行は一行しか入ってこないはずなのでDataViewの要素のIndexは0で固定
					//    targetDr = _inventInputView[0].Row;
					//}
					//else
					//{
					//    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
					//}
					#endregion
					// 2007.07.19 kubo add <-------------

					// 親の差異数を取得するために子行の棚卸数の合計を取得する
					object sumInvStkCnt = this._inventInputAcs.InventDataTable.Compute(
						string.Format("Sum({0})",InventInputResult.ct_Col_InventoryStockCnt),
						MakeParentOrChildRowGetQuery( 
							MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, childDr ),
							(int)InventInputSearchCndtn.ViewState.View)	);
					
					if ( sumInvStkCnt == DBNull.Value )
					{
						parentToleCnt = 0;
					}
					else
					{
						parentToleCnt = (double)sumInvStkCnt;
					}

					double bfInvToleCnt = 0;
					if ( targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value )
					{
						bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
					}
					else
					{
						bfInvToleCnt = 0;
					}
					// 前回差異数
					targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;
					// 棚卸数
					targetDr[InventInputResult.ct_Col_InventoryStockCnt] = parentToleCnt;
					// 変更区分をセット
					targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				}
			}
			else
			{
				// 商品毎のときの処理
				// 商品毎のときは引数のDataRowに入力
				targetDr = childDr;

				// 前回差異数に今回差異数をセット
				double bfInvToleCnt = 0;
				if ( targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value )
				{
					bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
				}
				else
				{
					bfInvToleCnt = 0;
				}
				// 前回差異数
				targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;
				// 棚卸数
				targetDr[InventInputResult.ct_Col_InventoryStockCnt] = invStcCnt;
				// 変更区分をセット
				targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

			}

			// 差異数
			targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] =
				(double)targetDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetDr[InventInputResult.ct_Col_StockTotal];
			
			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 棚卸日展開処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸日展開処理
        /// </summary>
        /// <param name="targetRow">対象Row</param>
        /// <param name="viewDate">設定日付</param>
        /// <returns>Status</returns>
        private int AfterInputInventoryDate(ref DataRow targetRow, DateTime viewDate)
        {
            DateTime invDate = viewDate;

            // 変更が加えられたRow自身の変更
            this._inventInputAcs.DevInventoryDay(targetRow, invDate);

            // 親行か子行かを判断してそれぞれに展開する
            if ((int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods)
            {
                // 商品に入力された場合
                // 子行を取得→棚卸数が入力されている子行の日付を更新する
                // 子行を取得
                // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                //this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                //            MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetRow),
                //            (int)InventInputSearchCndtn.ViewState.Both);
                //this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
                //this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

                //DataRow childRow;
                //for (int index = 0; index < this._inventInputView.Count; index++)
                //{
                //    childRow = this._inventInputView[index].Row;
                //    // 子行の日付の変更
                //    this._inventInputAcs.DevInventoryDay(childRow, invDate);

                //    // 変更区分をセット
                //    childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                //}
                // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                this._inventInputView.Sort = InventInputResult.ct_Col_SectionCode + "," + InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode
                                            + "," + InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_SupplierCode + "," + InventInputResult.ct_Col_ShipCustomerCode
                                            + "," + InventInputResult.ct_Col_StockDiv + "," + InventInputResult.ct_Col_GrossDiv;
                object[] primaryKeyObjList = new object[]{
				targetRow[InventInputResult.ct_Col_SectionCode].ToString(),			// 拠点コード
				targetRow[InventInputResult.ct_Col_WarehouseCode].ToString(),			// 倉庫コード
				(int)targetRow[InventInputResult.ct_Col_MakerCode],				// メーカーコード
                targetRow[InventInputResult.ct_Col_GoodsNo].ToString(),             // 品番
				(int)targetRow[InventInputResult.ct_Col_SupplierCode],		// 仕入先コード
				(int)targetRow[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
				(int)targetRow[InventInputResult.ct_Col_StockDiv],				// 在庫区分
				(int)InventInputSearchCndtn.GrossDivState.Product// 集計区分
				};

                // フィルタクリア
                this._inventInputView.RowFilter = string.Empty; // ADD by xuyb 2014/10/31 for 障害現象②の対応

                DataRowView[] drv = this._inventInputView.FindRows(primaryKeyObjList);

                DataRow childRow;
                foreach (DataRowView dataRowView in drv)
                {
                    childRow = dataRowView.Row;
                    // 子行の日付の変更
                    this._inventInputAcs.DevInventoryDay(childRow, invDate);

                    // 変更区分をセット
                    childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }
                // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
            }
            else
            {
                // 親行を取得→親行の日付と子行の日付を比較→子行の日付が新しいならば親行に反映
                ChangeCommitInventoryDay(ref targetRow, invDate, true);
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 棚卸日展開処理
		/// </summary>
		/// <param name="targetRow">対象Row</param>
		/// <param name="viewDate">設定日付</param>
		/// <returns>Status</returns>
		private int AfterInputInventoryDate( ref DataRow targetRow, DateTime viewDate )
		{
			DateTime invDate = viewDate;

			//if ( invDate == DateTime.MinValue ) invDate = viewDate;
			// 変更が加えられたRow自身の変更
			this._inventInputAcs.DevDate( targetRow, invDate,
				InventInputResult.ct_Col_InventoryDay,
				InventInputResult.ct_Col_InventoryDay_Datetime,
				InventInputResult.ct_Col_InventoryDay_Year,
				InventInputResult.ct_Col_InventoryDay_Month,
				InventInputResult.ct_Col_InventoryDay_Day);

			// 親行か子行かを判断してそれぞれに展開する
			if ( (int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
			{
				// 商品に入力された場合
				// 子行を取得→棚卸数が入力されている子行の日付を更新する
				// 子行を取得
				#region // 2007.07.19 kubo del
				//DataView childDv = 
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
				//            (int)InventInputSearchCndtn.ViewState.Both ),
				//        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//        DataViewRowState.CurrentRows);
				#endregion

				// 2007.07.19 kubo add ------------->
				this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
							MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
							(int)InventInputSearchCndtn.ViewState.Both );
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //this._inventInputView.Sort = string.Format("{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber);
                this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
				// 2007.07.19 kubo add <-------------

				DataRow childRow;
				// for( int index = 0; index < childDv.Count; index++ )	// 2007.07.19 kubo del
				for( int index = 0; index < this._inventInputView.Count; index++ ) // 2007.07.19 kubo add
				{
					// childRow = childDv[index].Row;	// 2007.07.19 kubo del
					childRow = this._inventInputView[index].Row;	// 2007.07.19 kubo add
					// 子行の日付の変更
					this._inventInputAcs.DevDate( childRow, invDate,
						InventInputResult.ct_Col_InventoryDay,
						InventInputResult.ct_Col_InventoryDay_Datetime,
						InventInputResult.ct_Col_InventoryDay_Year,
						InventInputResult.ct_Col_InventoryDay_Month,
						InventInputResult.ct_Col_InventoryDay_Day);
					#region　// 2007.07.19 kubo del
					//if ( ( childRow[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value ) || 
					//     ( (DateTime)childRow[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue) )	// TODO:DBNull.Value との比較が怪しい
					//{
					//    // 子行の日付の変更
					//    this._inventInputAcs.DevDate( childRow, invDate,
					//        InventInputResult.ct_Col_InventoryDay,
					//        InventInputResult.ct_Col_InventoryDay_Datetime,
					//        InventInputResult.ct_Col_InventoryDay_Year,
					//        InventInputResult.ct_Col_InventoryDay_Month,
					//        InventInputResult.ct_Col_InventoryDay_Day);
					//}
					#endregion
					// 変更区分をセット
					childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

				}

			}
			else
			{
				// 製番に入力された場合

				// 製番未入力？
				#region // 2007.07.24 kubo del
				//if ( targetRow[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
				//{
				//    #region // 2007.07.19 kubo del
				//    //DataView childDv = 
				//    //    new DataView( 
				//    //        this._inventInputAcs.InventDataTable, 
				//    //        MakeParentOrChildRowGetQuery( 
				//    //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
				//    //            (int)InventInputSearchCndtn.ViewState.NotView ),
				//    //        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//    //        DataViewRowState.CurrentRows);
				//    #endregion

				//    // 2007.07.19 kubo add ------------->
				//    this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery( 
				//                MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product, targetRow ),
				//                (int)InventInputSearchCndtn.ViewState.NotView );
				//    this._inventInputView.Sort = string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber );
				//    this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
				//    // 2007.07.19 kubo add <-------------

				//    DataRow childRow;
				//    //for( int index = 0; index < childDv.Count; index++ )	// 2007.07.19 kubo del
				//    for( int index = 0; index < this._inventInputView.Count; index++ )	// 2007.07.19 kubo add
				//    {
				//        //childRow = childDv[index].Row;	// 2007.07.19 kubo del
				//        childRow = this._inventInputView[index].Row;		// 2007.07.19 kubo add

				//        // 子行の日付の変更
				//        this._inventInputAcs.DevDate( childRow, invDate,
				//            InventInputResult.ct_Col_InventoryDay,
				//            InventInputResult.ct_Col_InventoryDay_Datetime,
				//            InventInputResult.ct_Col_InventoryDay_Year,
				//            InventInputResult.ct_Col_InventoryDay_Month,
				//            InventInputResult.ct_Col_InventoryDay_Day);
				//        #region
				//        //if ( ( (DateTime)childRow[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue) || 
				//        //     ( childRow[InventInputResult.ct_Col_InventoryDay] == DBNull.Value ) )	// TODO:DBNull.Value との比較が怪しい
				//        //{
				//        //    // 子行の日付の変更
				//        //    this._inventInputAcs.DevDate( childRow, invDate,
				//        //        InventInputResult.ct_Col_InventoryDay,
				//        //        InventInputResult.ct_Col_InventoryDay_Datetime,
				//        //        InventInputResult.ct_Col_InventoryDay_Year,
				//        //        InventInputResult.ct_Col_InventoryDay_Month,
				//        //        InventInputResult.ct_Col_InventoryDay_Day);
				//        //}
				//        #endregion
				//        // 変更区分をセット
				//        childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

				//    }
				//}
				#endregion
				// 親行を取得→親行の日付と子行の日付を比較→子行の日付が新しいならば親行に反映
				ChangeCommitInventoryDay( ref targetRow, invDate, true );
			}
			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 棚番入力後処理
        /// <summary>
        /// 棚番入力後処理
        /// </summary>
        /// <param name="targetDr"></param>
        /// <param name="shelfNo"></param>
        /// <param name="targetCol"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 棚番の入力後処理を行う</br>
        /// <br>Programer  : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.11</br>
        /// </remarks>
        private int AfterInputWarehouseShelfNo(ref DataRow targetDr, string shelfNo, string targetCol)
        {
            // 棚番
            //targetDr[InventInputResult.ct_Col_WarehouseShelfNo] = shelfNo;
            targetDr[targetCol] = shelfNo;

            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
                        (int)InventInputSearchCndtn.ViewState.Both);
            this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            DataRow childRow;
            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                childRow = this._inventInputView[index].Row;
                // 棚番
                //childRow[InventInputResult.ct_Col_WarehouseShelfNo] = shelfNo;
                childRow[targetCol] = shelfNo;

                // 変更区分をセット
                childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion
        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

        // ---ADD 2009/05/14 不具合対応[13260] ----------------------------->>>>>
        #region ◎ 仕入単価(浮動)入力後処理
        /// <summary>
        /// 仕入単価(浮動)入力後処理
        /// </summary>
        /// <param name="targetDr">対象となる行</param>
        /// <param name="stockUnitPrice">仕入単価(浮動)</param>
        /// <param name="targetCol">対象となる列</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 仕入単価(浮動)の入力後処理を行う</br>
        /// <br>Programer  : 照田 貴志</br>
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2009/12/03 李占川 ＰＭ．ＮＳ保守依頼③</br>
        /// <br>             帳簿数＝0の行の原単価を変更時にエラーが発生しないように変更する</br>
        /// </remarks>
        private int AfterInputStockUnitPrice(ref DataRow targetDr, double stockUnitPrice, string targetCol)
        {
            // 仕入単価
            targetDr[targetCol] = stockUnitPrice;

            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetDr),
                        (int)InventInputSearchCndtn.ViewState.Both);
            this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;

            DataRow childRow;
            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                childRow = this._inventInputView[index].Row;
                // 仕入単価
                childRow[targetCol] = stockUnitPrice;

                // 仕入単価変更に伴う更新
                double stockTotal = (double)targetDr[InventInputResult.ct_Col_StockTotal];

                // --- UPD 2009/12/03 ---------->>>>>
                //double invStockCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
                double invStockCnt = 0;
                if (targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
                {
                    invStockCnt = (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
                }
                // --- UPD 2009/12/03 ----------<<<<<

                childRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] = 1;                                                                          //仕入単価変更フラグ
                // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------------------------------------------->>>>>
                childRow[InventInputResult.ct_Col_StockMashinePrice] = this._inventInputAcs.GetTotalPriceToLong(stockTotal, stockUnitPrice);        //マシン在庫額
                childRow[InventInputResult.ct_Col_InventoryStockPrice] = this._inventInputAcs.GetTotalPriceToLong(invStockCnt,  stockUnitPrice);    //棚卸在庫額
                // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------------------------------------------------------<<<<<

                // 変更区分をセット
                childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion
        // ---ADD 2009/05/14 不具合対応[13260] -----------------------------<<<<<

        #region ◎ 棚卸日反映処理
        /// <summary>
        /// 棚卸日反映処理
        /// </summary>
        /// <param name="childDr">元になるRow</param>
        /// <param name="inventoryDay">棚卸日</param>
        /// <param name="isProductFlg">製番毎行フラグ(true:製番毎, false:商品毎)</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 棚卸日反映処理を行う</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private int ChangeCommitInventoryDay(ref DataRow childDr, DateTime inventoryDay, bool isProductFlg)
        {
            DataRow targetDr;
            if (isProductFlg)
            {
                // 製番のときの処理

                // 製番子行が変更されたときは親行を捜す
                // 親行の取得
                #region // 2007.07.19 kubo del
                //DataView targetDv = 
                //    new DataView( 
                //        this._inventInputAcs.InventDataTable, 
                //        MakeParentOrChildRowGetQuery( 
                //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods, childDr ),
                //            (int)InventInputSearchCndtn.ViewState.Both),
                //        "",
                //        DataViewRowState.CurrentRows);
                //if ( targetDv.Count > 0 )
                //{
                //    // 親行は一行しか入ってこないはずなのでDataViewの要素のIndexは0で固定
                //    if ( targetDv[0] == null )
                //    {
                //        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //    }
                //    targetDr = targetDv[0].Row;
                //}
                //else
                //{
                //    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                //}
                #endregion

                // 2007.07.19 kubo add ------------->
                targetDr = this._inventInputAcs.InventDataTable.Rows.Find(
                    this._inventInputAcs.GetPrimaryKeyList(childDr, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty));

                if (targetDr == null)
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                // 2007.07.19 kubo add <-------------

                // 子行の日付が親行の日付より新しかった場合のみ親行の日付を更新
                if ((targetDr[InventInputResult.ct_Col_InventoryDay] == DBNull.Value) ||
                    ((targetDr[InventInputResult.ct_Col_InventoryDay] == null) ||
                      ((int)childDr[InventInputResult.ct_Col_InventoryDay] > (int)targetDr[InventInputResult.ct_Col_InventoryDay])
                    )
                )
                {
                    this._inventInputAcs.DevInventoryDay(targetDr, inventoryDay);
                }
            }
            else
            {
                // 商品毎のときの処理
                // 商品毎のときは引数のDataRowに入力
                targetDr = childDr;

                this._inventInputAcs.DevInventoryDay(targetDr, inventoryDay);
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion

        #region ◎ query作成用Dictionary作成処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// query作成用Dictionary作成処理
        /// </summary>
        /// <param name="grossDiv">グロス区分</param>
        /// <param name="dr">DataRow</param>
        /// <returns>query作成用Dictionary</returns>
        private Dictionary<string, object> MakeDictionary(int grossDiv, DataRow dr)
        {
            Dictionary<string, object> queryDic = new Dictionary<string, object>();

            // 拠点コード
            queryDic.Add(InventInputResult.ct_Col_SectionCode, dr[InventInputResult.ct_Col_SectionCode].ToString());
            // 倉庫コード
            queryDic.Add(InventInputResult.ct_Col_WarehouseCode, dr[InventInputResult.ct_Col_WarehouseCode].ToString());
            // メーカーコード
            queryDic.Add(InventInputResult.ct_Col_MakerCode, (int)dr[InventInputResult.ct_Col_MakerCode]);
            // 品番
            queryDic.Add(InventInputResult.ct_Col_GoodsNo, dr[InventInputResult.ct_Col_GoodsNo].ToString());
            // 仕入先コード
            queryDic.Add(InventInputResult.ct_Col_SupplierCode, (int)dr[InventInputResult.ct_Col_SupplierCode]);
            // 委託先コード
            queryDic.Add(InventInputResult.ct_Col_ShipCustomerCode, (int)dr[InventInputResult.ct_Col_ShipCustomerCode]);
            // 在庫区分
            queryDic.Add(InventInputResult.ct_Col_StockDiv, (int)dr[InventInputResult.ct_Col_StockDiv]);
            // 集計区分
            queryDic.Add(InventInputResult.ct_Col_GrossDiv, grossDiv);

            return queryDic;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// query作成用Dictionary作成処理
        /// </summary>
        /// <param name="grossDiv">グロス区分</param>
        /// <param name="dr">DataRow</param>
        /// <returns>query作成用Dictionary</returns>
        private Dictionary<string, object> MakeDictionary(int grossDiv, DataRow dr)
        {
            Dictionary<string, object> queryDic = new Dictionary<string, object>();

            // 拠点コード
            queryDic.Add(InventInputResult.ct_Col_SectionCode, dr[InventInputResult.ct_Col_SectionCode].ToString());
            // 倉庫コード
            queryDic.Add(InventInputResult.ct_Col_WarehouseCode, dr[InventInputResult.ct_Col_WarehouseCode].ToString());
            // メーカーコード
            queryDic.Add(InventInputResult.ct_Col_MakerCode, (int)dr[InventInputResult.ct_Col_MakerCode]);
            // 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //queryDic.Add( InventInputResult.ct_Col_GoodsCode			, dr[InventInputResult.ct_Col_GoodsCode			].ToString() );
            queryDic.Add(InventInputResult.ct_Col_GoodsNo, dr[InventInputResult.ct_Col_GoodsNo].ToString());
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者コード
            //queryDic.Add( InventInputResult.ct_Col_CarrierEpCode		, (int)dr[InventInputResult.ct_Col_CarrierEpCode		] );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 仕入先コード
            queryDic.Add(InventInputResult.ct_Col_CustomerCode, (int)dr[InventInputResult.ct_Col_CustomerCode]);
            // 委託先コード
            queryDic.Add(InventInputResult.ct_Col_ShipCustomerCode, (int)dr[InventInputResult.ct_Col_ShipCustomerCode]);
            // 仕入単価
            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //queryDic.Add( InventInputResult.ct_Col_StockUnitPrice		, (long)dr[InventInputResult.ct_Col_StockUnitPrice		] );
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 在庫区分
            queryDic.Add(InventInputResult.ct_Col_StockDiv, (int)dr[InventInputResult.ct_Col_StockDiv]);
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
            //queryDic.Add( InventInputResult.ct_Col_StockState			, (int)dr[InventInputResult.ct_Col_StockState			] );
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //// 新規区分
            //queryDic.Add( InventInputResult.ct_Col_InventoryNewDiv		, (int)dr[InventInputResult.ct_Col_InventoryNewDiv		] );
            // 集計区分
            queryDic.Add(InventInputResult.ct_Col_GrossDiv, grossDiv);

            return queryDic;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◎ KeyDownProc処理
		/// <summary>
		/// KeyDownProc処理
		/// </summary>
		/// <param name="sender">対象オブジェクト(Grid KeyDown Eventのsender)</param>
		/// <param name="e">イベントパラメータ</param>
		public void KeyDownProc( object sender, ref KeyEventArgs e )
		{
			// 編集中の場合
			UltraGrid targetGrid = (UltraGrid)sender;
			if( ( targetGrid.ActiveCell != null ) && ( targetGrid.ActiveCell.IsInEditMode == true ) ) 
			{
				// セルスタイルで判定
				switch( e.KeyData ) 
				{
					case Keys.Up	:	// ↑キー
					{								
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell );
						// アクティブになったセルを編集モードにする
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Down:
					{
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell );
						// アクティブになったセルを編集モードにする
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					// ←キー
					case Keys.Left:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// 編集中なら何もしない
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart != 0)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab );
						e.Handled = true;
						break;
					}
					// →キー
					case Keys.Right:
					{
						if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
						{
							// 編集中なら何もしない
							if (targetGrid.ActiveCell.IsInEditMode == true)
							{
								if (targetGrid.ActiveCell.SelStart < targetGrid.ActiveCell.Text.Length)
								{
									return;
								}
							}
						}
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab );
						e.Handled = true;
						break;
					}
					case Keys.Enter:
					{
						// EnterKeyが押されたときはTRetKeyContorolで制御される
						// アクティブになったセルを編集モードにする
						if (targetGrid.ActiveCell != null)
						{
							if (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
							{
								targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );
							}
						}
						e.Handled = true;
						break;
					}
					case Keys.Escape:	// ESCキー
					{
						// 2007.07.30 kubo add ------->
						Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = this.uGrid_InventInput.ActiveCell;
						// 棚卸数、棚卸更新日以外でESCが押されたとき
						if (
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt	) != 0 || 
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryStockCnt	) != 0 ||
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Year	) != 0 ||
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Month ) != 0 ||
							activeCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day	) != 0 )
						{
							this._isChangeInventStcCnt = true;
							this._isChangeInventDate = true;
                            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                            this._isChangeWarehouseShelfNo = true;
                            this._isChangeDuplicationShelfNo1 = true;
                            this._isChangeDuplicationShelfNo2 = true;
                            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                            this._isChangeStockUnitPrice = true;
                            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

							activeCell = this.uGrid_InventInput.ActiveCell;

							if ( targetGrid.ActiveRow != null )
								targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

							targetGrid.PerformAction(UltraGridAction.EnterEditMode);
						}
						// 2007.07.30 kubo add <-------
						this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

						UltraGridRow targetGridRow;
						targetGridRow = targetGrid.ActiveCell.Row;
						double bfInventStkCnt = 0;	// 変更前棚卸数
						// 棚卸数
						if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value )
							bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
						if ( ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value ) )
						{
							targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
							targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}

							// 棚卸数
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value )
								bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
						
							InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );

							e.Handled = true;
							break;
						}

						targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
						// 差異数
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
						// 棚卸日
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
						
						InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );
						
						targetGrid.ActiveCell = activeCell;
						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

						e.Handled = true;
						break;
					}
				}
			}
			else
			{
				switch( e.KeyData )
				{
					case Keys.Escape:	// ESCキー
					{
						this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
						UltraGridRow targetGridRow;
						targetGridRow = targetGrid.ActiveRow;
						if ( targetGrid.ActiveRow != null )
						{
							targetGridRow = targetGrid.ActiveRow;
						}
						else if ( targetGrid.Selected.Rows[0] != null )
						{
							targetGridRow = targetGrid.Selected.Rows[0];
						}
						else
						{
							e.Handled = false;
							break;
						}
						double bfInventStkCnt = 0;	// 変更前棚卸数
						// 棚卸数
						if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value )
							bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
						if ( ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value ) )
						{

							targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
							targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
							if ( targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value )
							{
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
								targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
							}
						
							InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );

							e.Handled = true;
							break;
						}

						// 棚卸数
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
						// 差異数
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
						// 棚卸日
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
						targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;

						InventInitializeForESC( (DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt );


						targetGrid.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

						e.Handled = true;
						break;
					}
				}
			}
		}
		#endregion

		#region ◎ KeyPress処理
		/// <summary>
		/// KeyPress処理
		/// </summary>
		/// <param name="sender">対象オブジェクト(Grid KeyDown Eventのsender)</param>
		/// <param name="e">イベントパラメータ</param>
		public void KeyPressProc( object sender, ref KeyPressEventArgs e )
		{
			//アクティブセル
			Infragistics.Win.UltraWinGrid.UltraGridCell	activeCell = ((UltraGrid)sender).ActiveCell;

			// グロス区分
			//アクティブセルがあったら
			if (activeCell != null)
			{
                // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                //int grossDiv = (int)activeCell.Row.Cells[InventInputResult.ct_Col_GrossDiv].Value;
                // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //string productNum = activeCell.Row.Cells[InventInputResult.ct_Col_ProductNumber].Value.ToString();
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

				if (activeCell.IsInEditMode == false) return;

				switch ( activeCell.Column.Key )
				{
					case InventInputResult.ct_Col_InventoryStockCnt		:	// 棚卸数
						// 2007.07.31 kubo Edit -------------------->
						#region
						// if (KeyPressCheck( 0, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true, grossDiv, productNum ) == false)
						#endregion
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
						//if (KeyPressCheck( 0, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true, grossDiv, productNum, true ) == false)
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(0, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true, grossDiv, true) == false)
                        if (KeyPressCheck(11, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.07.31 kubo Edit <--------------------
						{
							e.Handled = true;
							return;
						}
						break;

					case InventInputResult.ct_Col_InventoryDay_Year		:	//棚卸日付年Edit
						// 2007.07.31 kubo Edit -------------------->
						#region
						//if ( KeyPressCheck( 4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum) == false )
						#endregion
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, true) == false)
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, true) == false)
                        if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.07.31 kubo Edit <--------------------
						{
							e.Handled = true;
							return;
						}
						break;
					case InventInputResult.ct_Col_InventoryDay_Month	:	//棚卸日付月Edit
					case InventInputResult.ct_Col_InventoryDay_Day		:	//棚卸日付日Edit
						// 2007.07.31 kubo Edit -------------------->
						#region
						//if ( KeyPressCheck( 2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum) == false )
						#endregion
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, true) == false)
                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        //if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, true) == false)
                        if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.07.31 kubo Edit <--------------------
						{
							e.Handled = true;
							return;
						}
						break;
                    // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                    case InventInputResult.ct_Col_StockUnitPrice        :   //仕入単価Edit
                        if (KeyPressCheck(11, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.31 kubo Add -------------------->
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //case InventInputResult.ct_Col_ProductNumber:
					//	// 入力文字が小文字か
					//	if ( Char.IsLower( e.KeyChar ) )
					//	{
					//		e.KeyChar = Char.ToUpper( e.KeyChar );
					//	}
					//	if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, false ) == false)
					//	{
					//		e.Handled = true;
					//		return;
					//	}
					//	break;
					//case InventInputResult.ct_Col_StockTelNo1			:	// 電話番号1
					//case InventInputResult.ct_Col_StockTelNo2			:	// 電話番号2
					//	if (KeyPressCheck( 20, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, false, grossDiv, productNum, false ) == false)
					//	{
					//		e.Handled = true;
					//		return;
					//	}
					//	break;
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    // 2007.07.31 kubo Add -------------------->
				}
			}	
		}
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ 数値入力チェック処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
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
        /// <param name="isNumOnly">数値のみ区分(true:数値のみ, false:数値以外可)</param>
        /// <returns>true=入力可,false=入力不可</returns>
        public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isNumOnly)
        {
            // 制御キーが押された？
            if (Char.IsControl(key) == true)
            {
                return true;
            }

            if (isNumOnly)
            {
                // 数値以外は、ＮＧ
                if (Char.IsNumber(key) == false)
                {
                    // 小数点または、マイナス以外
                    if ((key != '.') && (key != '-'))
                    {
                        return false;
                    }
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
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

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

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
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;

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
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
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
        /// <param name="isNumOnly">数値のみ区分(true:数値のみ, false:数値以外可)</param>
		/// <returns>true=入力可,false=入力不可</returns>
        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        //public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isInvStk, int grossDiv, string productNum, bool isNumOnly)
        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
        //public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isInvStk, int grossDiv, bool isNumOnly)
        public Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, bool isNumOnly)
        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        // 2007.07.31 kubo Edit
		{
			// 制御キーが押された？
			if (Char.IsControl(key) == true)
			{
                return true;
            }

			if( isNumOnly )
			{
				// 数値以外は、ＮＧ
				if (Char.IsNumber(key) == false)
				{
                    // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //return false;
                    // 小数点以外
                    if (key != '.')
                    {
                        return false;
                    }
                    // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                }
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

			//// マイナスのチェック
			//if (key == '-')
			//{
			//    if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
			//    {
			//        return false;
			//    }
			//}

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            // キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart) 
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart+sellength));

            // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 棚卸数が入力されたか
            //if ( isInvStk )
            //{
            //    // 入力値チェック
            //    // if ( ( grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product ) && ( productNum.CompareTo("") != 0 ) )
            //    if ( grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product )
            //    {
            //        // 製番管理ありで製番入力済なら入力は1or0のみ
            //        if ( ( key != '1' ) && ( key != '0' ) )
            //        {
            //            return false;
            //        }
            //        keta = 1;
            //    }
            //    else
            //    {
            //        // 製番管理無し or 製番未入力なら入力は0以上
            //        keta = 9;
            //    }
            //}
            // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

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
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 日付入力チェック処理
        #region DEL 2008/0901 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="targetDate">チェック対象コントロール</param>
        /// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
        /// <returns>チェック結果(true/false)</returns>
        /// <remarks>
        /// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.03.06</br>
        /// </remarks>
        private bool DateEditInputCheck(DateTime targetDate, bool allowEmpty)
        {
            bool status = true;

            // 入力日付を数値型で取得
            int date = TDateTime.DateTimeToLongDate(targetDate);
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (targetDate == DateTime.MinValue)
            {
                if (allowEmpty == true)
                {
                    return status;
                }
                else
                {
                    status = false;
                }
            }
            // システムサポートチェック
            else if (yy < 1900)
            {
                status = false;
            }
            // 年月日別入力チェック
            else if ((yy == 0) || (mm == 0) || (dd == 0))
            {
                status = false;
            }
            // 単純日付妥当性チェック
            else if (TDateTime.IsAvailableDate(targetDate) == false)
            {
                status = false;
            }

            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/0901 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="targetDate">チェック対象コントロール</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>チェック結果(true/false)</returns>
        /// <remarks>
        /// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// </remarks>
        private bool DateEditInputCheck(TDateEdit tDateEdit, out string errMsg)
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

        #region ◎ メッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string message, emErrorLevel iLevel)
        {
            // メッセージ表示
            return TMsgDisp.Show(
                this,                            // 親ウィンドウフォーム
                iLevel,                             // エラーレベル
                this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
                message,                            // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OK);             // 表示するボタン
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="msg">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="proc">発生元メソッドID</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <remarks>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, emErrorLevel iLevel)
        {
            return TMsgDisp.Show(
                iLevel,						        //エラーレベル
                "MAZAI05130UB",                       //UNIT　ID
                "棚卸入力",                            //プログラム名称
                proc,                               //プロセスID
                "",                                 //オペレーション
                msg,                                //メッセージ
                status,                             //ステータス
                null,                               //オブジェクト
                MessageBoxButtons.OK,               //ダイアログボタン指定
                MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
                );
        }

        /// <summary>
        /// エラーMSG表示処理(Exception)
        /// </summary>
        /// <param name="msg">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="proc">発生元メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <remarks>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private DialogResult MsgDispProc(string msg, int status, string proc, Exception ex, emErrorLevel iLevel)
        {
            return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
        }
        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◎ 棚卸データ変更有無判定
        /// <summary>
        /// 棚卸データ変更有無判定
        /// </summary>
        /// <param name="dr">対象DataRow</param>
        /// <returns>(int)InventInputSearchCndtn.ChangeFlagState</returns>
        private int CheckChangeData(DataRow dr)
        {
            //// 電話番号1が変わっている場合
            //if ( (int)dr[InventInputResult.ct_Col_StkTelNo1ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //    return (int)InventInputSearchCndtn.ChangeFlagState.Change;
            //// 電話番号2が変わっている場合
            //if ( (int)dr[InventInputResult.ct_Col_StkTelNo2ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //    return (int)InventInputSearchCndtn.ChangeFlagState.Change;
            //// 仕入単価が変更されている場合
            //if ( (int)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //    return (int)InventInputSearchCndtn.ChangeFlagState.Change;
            // 移動在庫がある場合
            if ((int)dr[InventInputResult.ct_Col_MoveStockCount] > 0)
                return (int)InventInputSearchCndtn.ChangeFlagState.Change;

            return (int)InventInputSearchCndtn.ChangeFlagState.NotChange;
        }
        #endregion

        #region ◎ Row表示色変更処理
        /// <summary>
        /// Row表示色変更処理
        /// </summary>
        /// <param name="ugr">UltraGridRow</param>
        private void ChangeRowColor(UltraGridRow ugr)
        {
            DataRow targetRow = (DataRow)ugr.Cells[InventInputResult.ct_Col_RowSelf].Value;
            // エラーステータスを判断して行の色を変更する
            if ((int)targetRow[InventInputResult.ct_Col_Status] != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ChangeRowColor(ugr, Color.Red);
            }
            else if (CheckChangeData(targetRow) == (int)InventInputSearchCndtn.ChangeFlagState.Change)
            {
                ChangeRowColor(ugr, Color.Blue);
            }
            else
            {
                ChangeRowColor(ugr, Color.Black);
            }
        }
        
		/// <summary>
		/// Row表示色変更処理
		/// </summary>
		/// <param name="ugr">UltraGridRow</param>
		/// <param name="setColor">設定色</param>
		private void ChangeRowColor( UltraGridRow ugr, Color setColor )
		{
			ugr.Appearance.ForeColor = setColor;
			ugr.Appearance.ForeColor = setColor;
		}
        
        #endregion

           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ 親・子行取得query作成
        /// <summary>
        /// 親・子行取得query作成
        /// </summary>
        /// <param name="queryDic">クエリー作成用Dictionary</param>
        /// <param name="viewDiv">表示区分</param>
        private string MakeParentOrChildRowGetQuery(Dictionary<string, object> queryDic, int viewDiv)
        {
            // クエリの作成

            StringBuilder strQuery = new StringBuilder();

            foreach (KeyValuePair<string, object> dic in queryDic)
            {
                if (strQuery.ToString() != "")
                {
                    strQuery.Append(" and ");
                }

                if ((dic.Value.GetType() == typeof(string)) || (dic.Value.GetType() == typeof(char)))
                {
                    strQuery.Append(string.Format("{0}='{1}'", dic.Key.ToString(), dic.Value.ToString()));
                }
                else if (dic.Value.GetType() == typeof(int))
                {
                    strQuery.Append(string.Format("{0}={1}", dic.Key.ToString(), (int)dic.Value));
                }
                else if (dic.Value.GetType() == typeof(long))
                {
                    strQuery.Append(string.Format("{0}={1}", dic.Key.ToString(), (long)dic.Value));
                }
                else if (dic.Value.GetType() == typeof(double))
                {
                    strQuery.Append(string.Format("{0}={1}", dic.Key.ToString(), (double)dic.Value));
                }
            }

            // 表示状態
            if (viewDiv != (int)InventInputSearchCndtn.ViewState.Both)
            {
                if (strQuery.ToString() != "")
                {
                    strQuery.Append(" and ");
                }
                strQuery.Append(string.Format("{0}={1}", InventInputResult.ct_Col_ViewDiv, viewDiv));
            }

            // 2007.07.30 kubo add --------------------------->
            if (strQuery.ToString() != "")
            {
                strQuery.Append(" and ");
            }
            strQuery.Append(string.Format("{0}={1}", InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0));
            // 2007.07.30 kubo add <---------------------------


            return strQuery.ToString();
        }
        #endregion

        #region ◎ Grid表示状態変更時処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Grid表示状態変更時処理
        /// </summary>
        /// <br>Update Note: 2012/10/29 yangyi</br>
        /// <br>             redmine#32868  棚卸表 棚卸入力/表示順が違う</br>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
        /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
        private void ChangeViewStyle()
        {
            // 初期処理が終了するまで待つ
            if (this._isFirstsetting)
            {
                return;
            }
            // 表示方法・ソート順が選択されていない場合は処理終了
            if ((this.tce_ViewStyle.SelectedIndex == -1) || (this.tce_SortOrder.SelectedIndex == -1))
            {
                this._inventInputAcs.InventDataTable.CaseSensitive = true;                                      //ADD 2009/05/14 不具合対応[13260]

                this._isFirstsetting = true;
                this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable);
                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);
                // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------->>>>>
                //Noを求める
                int idx = 1;
                foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
                {
                    gridRow.Cells[InventInputResult.ct_Col_No].Value = idx.ToString();
                    gridRow.Update();
                    idx++;
                }
                // ---ADD 2009/05/14 不具合対応[13260] --------------------------------------<<<<<

                this._strNowSort = "";
                return;
            }

            string sortOrder = "";	// ソート順
            string viewStyle = "";	// 表示方法

            try
            {
                // 表示方法決定
                viewStyle = ct_Filter_Goods;	// 商品毎
                // ソート順決定
                switch ((int)this.tce_SortOrder.SelectedItem.DataValue)
                {
                    case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:	    // 倉庫→棚番
                        sortOrder = ct_SortOrder_ShelfNo;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Customer:		// 倉庫→仕入先
                        sortOrder = ct_SortOrder_Supplier;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// 倉庫→ＢＬコード
                        sortOrder = ct_SortOrder_BLGoods;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.BLGroup:    	// 倉庫→グループコード
                        sortOrder = ct_SortOrder_BLGroup;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // 倉庫→メーカー
                        sortOrder = ct_SortOrder_Maker;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // 倉庫→仕入先→棚番
                        sortOrder = ct_SortOrder_Sup_ShelfNo;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // 倉庫→仕入先→メーカー
                        sortOrder = ct_SortOrder_Sup_Maker;
                        break;
                    default:														// 倉庫→棚番
                        sortOrder = ct_SortOrder_ShelfNo;
                        break;
                }

                this._inventInputAcs.InventDataTable.CaseSensitive = true;          //ADD 2009/05/14 不具合対応[13260]
                // 表示方法・ソート順を再指定してグリッド描画
                //this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable, viewStyle, sortOrder, DataViewRowState.CurrentRows); //DEL 2012/10/29 yangyi redmine #32868 
                // ----- ADD 2012/10/29 yangyi redmine #32868 ---------->>>>>
                int printSortIdv = (int)this.tce_SortOrder.SelectedItem.DataValue;

                if (printSortIdv == 0 || printSortIdv == 5)
                {
                    this.uGrid_InventInput.BeginUpdate();
                    List<DataRow> al = new List<DataRow>();
                    foreach (DataRow dr in this._inventInputAcs.InventDataTable.Rows)
                    {
                        al.Add(dr);
                    }
                    Array arr = al.ToArray();
                    MyStringComparer myComp = new MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.Ordinal, printSortIdv);
                    Array.Sort(arr, myComp);

                    DataTable tab = this._inventInputAcs.InventDataTable.Clone();
                    tab.BeginLoadData();   //ADD yangyi 2013/03/01 Redmine#34175 
                    foreach (DataRow dataRo in arr)
                    {
                        tab.ImportRow(dataRo);
                    }
                    tab.EndLoadData();   //ADD yangyi 2013/03/01 Redmine#34175

                    this._inventInputAcs.InventDataTable = tab;

                    //this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable, viewStyle, "", DataViewRowState.CurrentRows);  //DEL yangyi 2013/03/01 Redmine#34175
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    DataView dataView = new DataView(this._inventInputAcs.InventDataTable, viewStyle, "", DataViewRowState.CurrentRows);
                    int idx = 1;
                    this._inventInputAcs.InventDataTable.BeginLoadData();
                    foreach (DataRowView rowView in dataView)
                    {
                        rowView.Row[InventInputResult.ct_Col_No] = idx;
                        idx++;
                    }
                    this._inventInputAcs.InventDataTable.EndLoadData();
                    this.uGrid_InventInput.DataSource = dataView;
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                    // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    // Rowのカラムを自分自身に設定
                    //foreach (DataRow copyRow in _inventInputAcs.InventDataTable.Rows)
                    //{
                    //    copyRow[InventInputResult.ct_Col_RowSelf] = copyRow;
                    //}
                    // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                    //行削除の対応
                    for (int index = 0; index < this.uGrid_InventInput.Rows.Count; index++)
                    {
                        int deleteDiv = (Int32)uGrid_InventInput.Rows[index].Cells[InventInputResult.ct_Col_DeleteDiv].Value;

                        if (deleteDiv == 1)
                        {
                            this.uGrid_InventInput.Rows[index].Appearance.BackColor = Color.Pink;
                        }
                    }
                    this.uGrid_InventInput.EndUpdate();

                }
                else
                {
                    DataView dataView = new DataView(this._inventInputAcs.InventDataTable, viewStyle, sortOrder, DataViewRowState.CurrentRows);
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                    int idx = 1;
                    foreach (DataRowView rowView in dataView)
                    {
                        rowView[InventInputResult.ct_Col_No] = idx;
                        idx++;
                    }
                    // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                    this.uGrid_InventInput.DataSource = dataView;
                }
                // ----- ADD 2012/10/29  yangyi redmine #32868 ----------<<<<<

                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);

                // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                // ---ADD 2009/05/14 不具合対応[13260] --------------------------------------------->>>>>
                //Noを求める
                //int idx = 1;
                //foreach (UltraGridRow gridRow in this.uGrid_InventInput.Rows)
                //{
                //    gridRow.Cells[InventInputResult.ct_Col_No].Value = idx;
                //    gridRow.Update();
                //    idx++;
                //}
                //((DataView)this.uGrid_InventInput.DataSource).Sort = InventInputResult.ct_Col_No;
                // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------<<<<<
                // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                this._strNowSort = sortOrder;

                // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                if (_addingKey)
                {
                    SetTableKey(this._inventInputAcs.InventDataTable);
                    SetTableKey(this._inventInputAcs.InventDataTable_Buf);
                    _addingKey = false;
                }
                // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
            }
            catch (Exception ex)
            {
                this.MsgDispProc("棚卸データ設定時にエラーが発生しました。", -1, "ChangeViewStyle", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        private void SetTableKey(DataTable dt)
        {
            DataColumn[] primaryKeys = new DataColumn[10];

            // 拠点コード
            primaryKeys[0] = dt.Columns[InventInputResult.ct_Col_SectionCode];
            primaryKeys[0].DefaultValue = "";

            // 倉庫コード
            primaryKeys[1] = dt.Columns[InventInputResult.ct_Col_WarehouseCode];
            primaryKeys[1].DefaultValue = "";
            // メーカーコード
            primaryKeys[2] = dt.Columns[InventInputResult.ct_Col_MakerCode];
            primaryKeys[2].DefaultValue = 0;
            // 品番
            primaryKeys[3] = dt.Columns[InventInputResult.ct_Col_GoodsNo];
            primaryKeys[3].DefaultValue = "";
            // 得意先コード
            primaryKeys[4] = dt.Columns[InventInputResult.ct_Col_SupplierCode];
            primaryKeys[4].DefaultValue = 0;
            // 出荷先得意先コード
            primaryKeys[5] = dt.Columns[InventInputResult.ct_Col_ShipCustomerCode];
            primaryKeys[5].DefaultValue = 0;
            // 原単価
            primaryKeys[6] = dt.Columns[InventInputResult.ct_Col_StockUnitPrice];
            primaryKeys[6].DefaultValue = 0;
            // 在庫区分
            primaryKeys[7] = dt.Columns[InventInputResult.ct_Col_StockDiv];
            primaryKeys[7].DefaultValue = 0;
            // 集計区分
            primaryKeys[8] = dt.Columns[InventInputResult.ct_Col_GrossDiv];
            primaryKeys[8].DefaultValue = 0;
            // 棚番
            primaryKeys[9] = dt.Columns[InventInputResult.ct_Col_WarehouseShelfNo];
            primaryKeys[9].DefaultValue = "";

            //DataTableにKeyを追加
            dt.PrimaryKey = primaryKeys;
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        // ----- ADD 2012/10/29 yangyi redmine #32868  ---------->>>>>
        /// <summary>
        /// 棚卸調査表序列用クラス
        /// </summary>
        private class MyStringComparer : IComparer
        {
            private CompareInfo myComp;
            private CompareOptions myOptions = CompareOptions.None;
            private int sortDiv = -1;
            public MyStringComparer(CompareInfo cmpi, CompareOptions options, int sortDiv)
            {
                myComp = cmpi;
                this.myOptions = options;
                this.sortDiv = sortDiv;
            }
            public int Compare(Object a, Object b)
            {
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;
                string stringA = "";
                string stringB = "";
                if (sortDiv == 0)// 棚番順
                {
                    //倉庫
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //棚番
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //品番
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_GoodsNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_GoodsNo].ToString();
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //メーカー
                    int intC = (Int32)((DataRow)a)[InventInputResult.ct_Col_MakerCode];
                    int intD = (Int32)((DataRow)b)[InventInputResult.ct_Col_MakerCode];
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                else if (sortDiv == 5)// 仕入先・棚番順
                {
                    //倉庫
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseCode].ToString();
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //仕入先
                    int intA = (Int32)((DataRow)a)[InventInputResult.ct_Col_SupplierCode];
                    int intB = (Int32)((DataRow)b)[InventInputResult.ct_Col_SupplierCode];
                    int comePareSupplierCd = intA.CompareTo(intB);
                    if (comePareSupplierCd != 0)
                    {
                        return comePareSupplierCd;
                    }
                    //棚番
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //品番
                    stringA = ((DataRow)a)[InventInputResult.ct_Col_GoodsNo].ToString();
                    stringB = ((DataRow)b)[InventInputResult.ct_Col_GoodsNo].ToString();
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //メーカー
                    int intC = (Int32)((DataRow)a)[InventInputResult.ct_Col_MakerCode];
                    int intD = (Int32)((DataRow)b)[InventInputResult.ct_Col_MakerCode];
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                return 0;
            }
            // ----- ADD 2012/10/29 yangyi redmine #32868 ----------<<<<<
        }

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Grid表示状態変更時処理
        /// </summary>
        private void ChangeViewStyle()
        {
            // 初期処理が終了するまで待つ
            if (this._isFirstsetting)
            {
                return;
            }
            // 表示方法・ソート順が選択されていない場合は処理終了
            if ((this.tce_ViewStyle.SelectedIndex == -1) || (this.tce_SortOrder.SelectedIndex == -1))
            {
                this._isFirstsetting = true;
                this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable);
                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);
                this._strNowSort = "";
                return;
            }
            string sortOrder = "";	// ソート順
            string viewStyle = "";	// 表示方法

            try
            {
                // 表示方法決定
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //switch ((int)this.tce_ViewStyle.SelectedItem.DataValue)
                //{
                //	case (int)InventInputSearchCndtn.ViewStyleState.Goods:
                //		viewStyle = ct_Filter_Goods;	// 商品毎
                //		break;
                //	default:
                //		viewStyle = ct_Filter_Product;	// 製番毎
                //		break;
                //}
                viewStyle = ct_Filter_Goods;	// 商品毎
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                // ソート順決定
                switch ((int)this.tce_SortOrder.SelectedItem.DataValue)
                {
                    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //case (int)InventInputSearchCndtn.SortOrderState.CarrierEP:		// 倉庫-事業者-商品-製番
                    //	sortOrder = ct_SortOrder_CarrierEp;
                    //	break;
                    //case (int)InventInputSearchCndtn.SortOrderState.Customer:		// 倉庫-仕入先-商品-製番
                    //	sortOrder = ct_SortOrder_Customer;
                    //	break;
                    //case (int)InventInputSearchCndtn.SortOrderState.ShipCustomer:	// 倉庫-委託先-商品-製番
                    //	sortOrder = ct_SortOrder_ShipCustomer;
                    //	break;
                    ////case (int)InventInputSearchCndtn.SortOrderState.SeqNo:			// 通番
                    ////    sortOrder = ct_SortOrder_SeqNo;
                    ////	break;
                    //default:														// 倉庫-商品-製番
                    //    sortOrder = ct_SortOrder_Goods;// + " , " + InventInputResult.ct_Col_ProductNumber;
                    //    break;
                    // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //case (int)InventInputSearchCndtn.SortOrderState.ShelfNo:		// 倉庫→棚番
                    //    sortOrder = ct_SortOrder_ShelfNo;
                    //    break;
                    case (int)InventInputSearchCndtn.SortOrderState.SNo_GoodsDiv:	// 倉庫→棚番→メーカー→商品区分→商品
                        sortOrder = ct_SortOrder_GoodsDiv;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.SNo_Goods:		// 倉庫→棚番→メーカー→商品
                        sortOrder = ct_SortOrder_Goods;
                        break;
                    // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                    case (int)InventInputSearchCndtn.SortOrderState.Customer:		// 倉庫→仕入先
                        sortOrder = ct_SortOrder_Customer;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.BLGoods:    	// 倉庫→ＢＬコード
                        sortOrder = ct_SortOrder_BLGoods;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Maker:	        // 倉庫→メーカー
                        sortOrder = ct_SortOrder_Maker;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_ShelfNo:    // 倉庫→仕入先→棚番
                        sortOrder = ct_SortOrder_Cus_ShelfNo;
                        break;
                    case (int)InventInputSearchCndtn.SortOrderState.Cus_Maker:	    // 倉庫→仕入先→メーカー
                        sortOrder = ct_SortOrder_Cus_Maker;
                        break;
                    default:														// 倉庫→棚番
                        sortOrder = ct_SortOrder_ShelfNo;
                        break;
                    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                }
                // Todo:
                //this.uGrid_InventInput.UpdateData();	// グリッドの変更をコミット	// 2007.07.19 kubo del
                // 表示方法・ソート順を再指定してグリッド描画
                this.uGrid_InventInput.DataSource = new DataView(this._inventInputAcs.InventDataTable, viewStyle, sortOrder, DataViewRowState.CurrentRows);

                this._inventInputView = new DataView(this._inventInputAcs.InventDataTable);
                this._strNowSort = sortOrder;
            }
            catch (Exception ex)
            {
                this.MsgDispProc("棚卸データ設定時にエラーが発生しました。", -1, "ChangeViewStyle", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                //this.uGrid_InventInput.Refresh();
            }

        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◎ カラム列幅調整
        /// <summary>
        /// カラム列幅調整
        /// </summary>
        /// <remarks>
        /// <br>Note       : カラムの列幅を調整します。</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.24</br>
        /// </remarks>
        private void ColumnPerformAutoResize()
        {
            this._isEventAutoFillColumn = false;

            try
            {
                bool isAutoCol = this.uce_ColSizeAutoSetting.Checked;

                this.uce_ColSizeAutoSetting.Checked = false;

                for (int i = 0; i < this.uGrid_InventInput.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                }

                // 棚卸実施日(年 入力)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_Year].Width = 50;
                // 棚卸実施日(年 ラベル)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_YearL].Width = 20;
                // 棚卸実施日(月 入力)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_Month].Width = 30;
                // 棚卸実施日(月 ラベル)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_MonthL].Width = 20;
                // 棚卸実施日(日 入力)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_Day].Width = 30;
                // 棚卸実施日(日 ラベル)
                this.uGrid_InventInput.DisplayLayout.Bands[0].Columns[InventInputResult.ct_Col_InventoryDay_DayL].Width = 20;


                this.uce_ColSizeAutoSetting.Checked = isAutoCol;
            }
            finally
            {
                this._isEventAutoFillColumn = true;
            }
        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ 列設定の更新
        /// <summary>
        /// 列設定の更新
        /// </summary>
        private void UpdGridColumnSetting(string columKey, bool hidden, int width)
        {
            // バンドを取得
            UltraGridBand band = this.uGrid_InventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput];

            if (band.Columns.Exists(columKey) == true)
            {
                // 列の表示／非表示
                band.Columns[columKey].Hidden = hidden;

                // グループの列が全て非表示ならグループを非表示にする
                UltraGridGroup ugg = band.Columns[columKey].Group;
                if (ugg != null)
                {
                    bool uggHidden = true;
                    foreach (UltraGridColumn col in ugg.Columns)
                    {
                        if (col.Hidden == false)
                        {
                            uggHidden = false;
                            break;
                        }
                    }
                    ugg.Hidden = uggHidden;
                }

                // 列幅 0以下の指定は無効
                if (width > 0)
                {
                    band.Columns[columKey].Width = width;
                }
            }
        }
        #endregion

        #region ◎ 入力初期化メイン
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 入力初期化メイン(ESCキーが押されたときの処理)
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="bfInventStcCnt"></param>
        private void InventInitializeForESC(DataRow targetRow, double bfInventStcCnt)
        {
            // 変更区分をセット
            targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

            // 表示方法を判断
            if ((int)this.tce_ViewStyle.SelectedItem.DataValue == (int)InventInputSearchCndtn.ViewStyleState.Goods)
            {
                InventInitializeParentToChild(targetRow, (int)InventInputSearchCndtn.ViewState.Both);
            }
            else
            {
                DataRow parentDr = this._inventInputAcs.InventDataTable.Rows.Find(
                    this._inventInputAcs.GetPrimaryKeyList(targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty));

                if (parentDr == null) return;

                // 棚卸数
                if (parentDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
                {
                    parentDr[InventInputResult.ct_Col_InventoryStockCnt] =
                        (double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - bfInventStcCnt;
                    // 差異数
                    parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] =
                        (double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentDr[InventInputResult.ct_Col_StockTotal];
                }

                // 子行を取得して、いずれかの行に棚卸数が入力されているかをチェック
                DataView childView =
                    new DataView(
                            this._inventInputAcs.InventDataTable,
                            MakeParentOrChildRowGetQuery(
                            MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, parentDr),
                            (int)InventInputSearchCndtn.ViewState.View),
                            string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv),
                            DataViewRowState.CurrentRows);

                bool isNoInput = true; // true:全子行未入力
                for (int index = 0; index < childView.Count; index++)
                {
                    // 棚卸数、差異数、棚卸日をクリア
                    childView[index][InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
                    childView[index][InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;

                    // 棚卸数、棚卸日のどれかがDBNullなら続行
                    if ((childView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value) ||
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Year] == DBNull.Value) ||
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Month] == DBNull.Value) ||
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Day] == DBNull.Value))
                    {
                        continue;
                    }

                    if ((childView[index][InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value) &&
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Year] != DBNull.Value) &&
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Month] != DBNull.Value) &&
                        (childView[index][InventInputResult.ct_Col_InventoryDay_Day] != DBNull.Value))
                    {
                        isNoInput = false;
                        break;
                    }

                    if (((double)childView[index][InventInputResult.ct_Col_InventoryStockCnt] != 0) &&
                        ((int)childView[index][InventInputResult.ct_Col_InventoryDay_Year] != 0) &&
                        ((int)childView[index][InventInputResult.ct_Col_InventoryDay_Month] != 0) &&
                        ((int)childView[index][InventInputResult.ct_Col_InventoryDay_Day] != 0))
                    {
                        isNoInput = false;
                        break;
                    }
                }

                if (isNoInput)
                {
                    // 棚卸数、差異数、棚卸日をクリア
                    parentDr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
                    parentDr[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
                }

                // 変更区分をセット
                //parentDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;        //DEL 2009/05/14 不具合対応[13260]　ESC押下時の一括更新ができなくなる為
                parentDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.NotChange;       //ADD 2009/05/14 不具合対応[13260]
            }

            this.uGrid_InventInput.Refresh();			// 2007.07.19 kubo del
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入力初期化メイン(ESCキーが押されたときの処理)
		/// </summary>
		/// <param name="targetRow"></param>
		/// <param name="bfInventStcCnt"></param>
		private void InventInitializeForESC( DataRow targetRow, double bfInventStcCnt )
		{
			// 変更区分をセット
			targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

			// 表示方法を判断
			if ( (int)this.tce_ViewStyle.SelectedItem.DataValue == (int)InventInputSearchCndtn.ViewStyleState.Goods )
			{
				InventInitializeParentToChild( targetRow, (int)InventInputSearchCndtn.ViewState.Both );
			}
			else
			{
				// 製番毎
				#region // 2007.07.24 kubo del
				//// 正版入力されているか
				//// 製番未入力？
				//if ( targetRow[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
				//{
				//    InventInitializeParentToChild( targetRow, (int)InventInputSearchCndtn.ViewState.NotView );
				//}
				#endregion
				// 親行に反映
				#region // 2007.07.19 kubo del
				//DataView parentView = 		
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Goods , targetRow ), 
				//            (int)InventInputSearchCndtn.ViewState.View),
				//        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//        DataViewRowState.CurrentRows);
				//if ( parentView == null )
				//{
				//    return;
				//}

				//if ( parentView.Count <= 0 )
				//{
				//    return;
				//}
				//// 棚卸数
				//if ( parentView[0][InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
				//{
				//    parentView[0][InventInputResult.ct_Col_InventoryStockCnt] = 
				//        (double)parentView[0][InventInputResult.ct_Col_InventoryStockCnt] - bfInventStcCnt;
				//    // 差異数
				//    parentView[0][InventInputResult.ct_Col_InventoryTolerancCnt] = 
				//        (double)parentView[0][InventInputResult.ct_Col_InventoryStockCnt] - (double)parentView[0][InventInputResult.ct_Col_StockTotal];
				//}

				//// 子行を取得して、いずれかの行に棚卸数が入力されているかをチェック
				//DataView childView = 
				//    new DataView( 
				//        this._inventInputAcs.InventDataTable, 
				//        MakeParentOrChildRowGetQuery( 
				//            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , parentView[0].Row ), 
				//            (int)InventInputSearchCndtn.ViewState.View),
				//        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
				//        DataViewRowState.CurrentRows);
				#endregion

				// 2007.07.19 kubo add ------------------->
				DataRow parentDr = this._inventInputAcs.InventDataTable.Rows.Find( 
					this._inventInputAcs.GetPrimaryKeyList(targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));

				if ( parentDr == null )
					return ;


				// 棚卸数
				if ( parentDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value )
				{
					parentDr[InventInputResult.ct_Col_InventoryStockCnt] = 
						(double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - bfInventStcCnt;
					// 差異数
					parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] = 
						(double)parentDr[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentDr[InventInputResult.ct_Col_StockTotal];
				}

				// 子行を取得して、いずれかの行に棚卸数が入力されているかをチェック
				DataView childView =
                    new DataView( 
						    this._inventInputAcs.InventDataTable, 
						    MakeParentOrChildRowGetQuery( 
							MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , parentDr ), 
							(int)InventInputSearchCndtn.ViewState.View),
                            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //string.Format("{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber),
                            string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv),
                            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                            DataViewRowState.CurrentRows);
                // 2007.07.19 kubo add <-------------------

				bool isNoInput = true; // true:全子行未入力
				for ( int index = 0; index < childView.Count; index++ )
				{
					// 棚卸数、棚卸日のどれかがDBNullなら続行
					if ( ( childView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value ) ||
						( childView[index][InventInputResult.ct_Col_InventoryDay_Year] == DBNull.Value ) ||
						( childView[index][InventInputResult.ct_Col_InventoryDay_Month] == DBNull.Value ) ||
						( childView[index][InventInputResult.ct_Col_InventoryDay_Day] == DBNull.Value ) )
					{
						continue;
					}

					if ( ( childView[index][InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value ) &&
						( childView[index][InventInputResult.ct_Col_InventoryDay_Year] != DBNull.Value ) &&
						( childView[index][InventInputResult.ct_Col_InventoryDay_Month] != DBNull.Value ) &&
						( childView[index][InventInputResult.ct_Col_InventoryDay_Day] != DBNull.Value ) )
					{
						isNoInput = false;
						break;
					}

					if ( ( (double)childView[index][InventInputResult.ct_Col_InventoryStockCnt] != 0 ) &&
						( (int)childView[index][InventInputResult.ct_Col_InventoryDay_Year] != 0 ) &&
						( (int)childView[index][InventInputResult.ct_Col_InventoryDay_Month] != 0 ) &&
						( (int)childView[index][InventInputResult.ct_Col_InventoryDay_Day] != 0 ) )
					{
						isNoInput = false;
						break;
					}
				}

				// 全て未入力
				#region // 2007.07.19 kubo del
				//if ( isNoInput )
				//{
				//    // 棚卸数、差異数、棚卸日をクリア
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
				//    parentView[0].Row[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
				//}
				//// 変更区分をセット
				//parentView[0][InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				#endregion

				// 2007.07.19 kubo add ------------------->
				if ( isNoInput )
				{
					// 棚卸数、差異数、棚卸日をクリア
					parentDr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Datetime] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
					parentDr[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
				}

				// 変更区分をセット
				parentDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				// 2007.07.19 kubo add <-------------------
			}

			//this.uGrid_InventInput.UpdateData();		// 2007.07.19 kubo del
			this.uGrid_InventInput.Refresh();			// 2007.07.19 kubo del
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 初期化処理(親→子行)
        /// <summary>
        /// 初期化処理(親→子行)
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="viewState"></param>
        private void InventInitializeParentToChild(DataRow targetRow, int viewState)
        {
            // 変更区分をセット
            targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

            // 商品毎
            // 子行に反映
            // 子行を取得
            #region // 2007.07.19 kubo del
            //DataView childDv = 
            //    new DataView( 
            //        this._inventInputAcs.InventDataTable, 
            //        MakeParentOrChildRowGetQuery( 
            //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetRow ), 
            //            viewState),
            //        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
            //        DataViewRowState.CurrentRows);
            //for( int index = 0; index < childDv.Count; index++ )
            //{
            //    // 子行に値を反映(棚卸数、差異数、日付初期化)
            //    // 棚卸数
            //    childDv[index][InventInputResult.ct_Col_InventoryStockCnt] = 0;
            //    // 差異数
            //    childDv[index][InventInputResult.ct_Col_InventoryTolerancCnt] = 0;
            //    // 棚卸日
            //    childDv[index][InventInputResult.ct_Col_InventoryDay] = 0;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Datetime] = DateTime.MinValue;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Month] = 0;
            //    childDv[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
            //    // 変更区分をセット
            //    childDv[index][InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            //}		
            #endregion

            // 2007.07.19 kubo add ------------->
            this._inventInputView.RowFilter = MakeParentOrChildRowGetQuery(
                        MakeDictionary((int)InventInputSearchCndtn.GrossDivState.Product, targetRow),
                        viewState);
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventInputView.Sort = string.Format("{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber);
            this._inventInputView.Sort = string.Format("{0}", InventInputResult.ct_Col_InventoryNewDiv);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            this._inventInputView.RowStateFilter = DataViewRowState.CurrentRows;
            // 2007.07.19 kubo add ------------->

            for (int index = 0; index < this._inventInputView.Count; index++)
            {
                // 子行に値を反映(棚卸数、差異数、日付初期化)
                // 棚卸数
                this._inventInputView[index][InventInputResult.ct_Col_InventoryStockCnt] = 0;
                // 差異数
                this._inventInputView[index][InventInputResult.ct_Col_InventoryTolerancCnt] = 0;
                // 棚卸日
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay] = 0;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Datetime] = DateTime.MinValue;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Month] = 0;
                this._inventInputView[index][InventInputResult.ct_Col_InventoryDay_Year] = 0;
                // 変更区分をセット
                this._inventInputView[index][InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            }
        }
        #endregion

		#region ◆ 行削除処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <param name="targetRow">削除行</param>
        /// <param name="activeRowIndex">行Index</param>
        /// <param name="mode">動作モード</param>
        /// <remarks>
        /// <br>Note       : 行削除処理</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int RowDeleteProc(DataRow targetRow, int activeRowIndex, int mode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                this.uGrid_InventInput.BeginUpdate();

                bool isTargetAfterSave = false;	// 保存済み区分　true:保存済み, false:未保存

                // 登録済みデータか未登録データの判断
                if ((DateTime)targetRow[InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                    isTargetAfterSave = false;
                else
                    isTargetAfterSave = true;

                string rowFilter = "";

                // ActiveRow削除
                this.uGrid_InventInput.ActiveRow = null;

                // 商品区分を判断
                if ((int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods)
                {
                    DataRow[] childRows = null;
                    // 商品毎のとき
                    // 子行を取得
                    rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                        InventInputResult.ct_Col_SectionCode, targetRow[InventInputResult.ct_Col_SectionCode],			// 拠点コード
                        InventInputResult.ct_Col_WarehouseCode, targetRow[InventInputResult.ct_Col_WarehouseCode],		// 倉庫コード
                        InventInputResult.ct_Col_MakerCode, targetRow[InventInputResult.ct_Col_MakerCode],			// メーカーコード
                        InventInputResult.ct_Col_GoodsNo, targetRow[InventInputResult.ct_Col_GoodsNo],			    // 品番
                        InventInputResult.ct_Col_SupplierCode, targetRow[InventInputResult.ct_Col_SupplierCode],			// 仕入先コード
                        InventInputResult.ct_Col_ShipCustomerCode, targetRow[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
                        InventInputResult.ct_Col_StockDiv, targetRow[InventInputResult.ct_Col_StockDiv],				// 在庫区分
                        InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Product,		// グロス区分(製番在庫ごと)
                        InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0				// 論理削除区分
                    );

                    childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);

                    if (childRows != null && childRows.Length > 0)
                    {
                        bool isChildAfterSave = false;
                        // 登録済みデータか未登録データの判断
                        if ((DateTime)childRows[0][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                            isChildAfterSave = false;
                        else
                            isChildAfterSave = true;

                        // 子行を削除
                        foreach (DataRow childRow in childRows)
                        {
                            if ((isChildAfterSave) && (mode == 0))
                            {
                                // 登録済みデータは削除フラグを立てる
                                childRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                                childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                                childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
                                childRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
                            }
                            else
                            {
                                this._inventInputAcs.InventDataTable.Rows.Remove(childRow);
                            }
                        }
                    }
                }
                else
                {
                    // 製番毎のとき
                    // 親行取得
                    DataRow parentRow = this._inventInputAcs.InventDataTable.Rows.Find(this._inventInputAcs.GetPrimaryKeyList(targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty));

                    if (parentRow != null)
                    {
                        // 自行の棚卸数を変更
                        targetRow[InventInputResult.ct_Col_InventoryStockCnt] = 0;	// 棚卸数
                        targetRow[InventInputResult.ct_Col_InventoryTolerancCnt] =	// 差異数
                            (double)targetRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetRow[InventInputResult.ct_Col_StockTotal];

                        // 親行から自行の棚卸数を引く
                        bool isShowProduct = false;
                        AfterInputInventryToleCnt(
                            ref targetRow,
                            (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);

                        if ((double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] == 0 &&
                             (int)parentRow[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
                        {
                            if (isTargetAfterSave)
                            {
                                // 登録済みデータは削除フラグを立てる
                                parentRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                                parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                                parentRow[InventInputResult.ct_Col_UpdateDiv] = 0;
                                parentRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
                            }
                            else
                            {
                                // 親を削除
                                this._inventInputAcs.InventDataTable.Rows.Remove(parentRow);
                            }
                        }
                    }
                }

                if (isTargetAfterSave)
                {
                    // 登録済みデータは削除フラグを立てる
                    targetRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                    targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                    targetRow[InventInputResult.ct_Col_UpdateDiv] = 0;
                    targetRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
                }
                else
                {
                    // 自行を削除
                    this._inventInputAcs.InventDataTable.Rows.Remove(targetRow);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                this.MsgDispProc("棚卸データの削除に失敗しました。", status, "RowDeleteProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                if (this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex)
                    this.uGrid_InventInput.Rows[activeRowIndex].Activate();

                this.uGrid_InventInput.EndUpdate();
            }
            return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 行削除処理
		/// </summary>
		/// <param name="targetRow">削除行</param>
		/// <param name="activeRowIndex">行Index</param>
        /// <param name="mode">動作モード</param>
        /// <remarks>
		/// <br>Note       : 行削除処理</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.07.24</br>
		/// </remarks>
        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
		//private int RowDeleteProc( DataRow targetRow, int activeRowIndex )
		private int RowDeleteProc( DataRow targetRow, int activeRowIndex, int mode )
        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				this.uGrid_InventInput.BeginUpdate();

				bool isTargetAfterSave = false;	// 保存済み区分　true:保存済み, false:未保存

				// 登録済みデータか未登録データの判断
				if ( (DateTime)targetRow[InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue )
					isTargetAfterSave = false;
				else
					isTargetAfterSave = true;

				string rowFilter = "";

				// ActiveRow削除
				this.uGrid_InventInput.ActiveRow = null;

				// 商品区分を判断
				if ( (int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
				{
					DataRow[] childRows = null;
					// 商品毎のとき
					// 子行を取得
                    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19} and {20}={21} and {22}={23}",
                    // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19}",
                    rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                    // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_SectionCode        , targetRow[InventInputResult.ct_Col_SectionCode],			// 拠点コード
						InventInputResult.ct_Col_WarehouseCode		, targetRow[InventInputResult.ct_Col_WarehouseCode],		// 倉庫コード
						InventInputResult.ct_Col_MakerCode			, targetRow[InventInputResult.ct_Col_MakerCode],			// メーカーコード
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
						//InventInputResult.ct_Col_GoodsCode		, targetRow[InventInputResult.ct_Col_GoodsCode],			// 品番
                        InventInputResult.ct_Col_GoodsNo            , targetRow[InventInputResult.ct_Col_GoodsNo],			    // 品番
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_CarrierEpCode    , targetRow[InventInputResult.ct_Col_CarrierEpCode],		// 事業者コード
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_CustomerCode       , targetRow[InventInputResult.ct_Col_CustomerCode],			// 得意先コード
                        InventInputResult.ct_Col_ShipCustomerCode   , targetRow[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
                        // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockUnitPrice     , targetRow[InventInputResult.ct_Col_StockUnitPrice],		// 仕入単価
                        // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_StockDiv           , targetRow[InventInputResult.ct_Col_StockDiv],				// 在庫区分
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockState       , targetRow[InventInputResult.ct_Col_StockState],			// 在庫状態
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //InventInputResult.ct_Col_InventoryNewDiv	, (int)InventInputSearchCndtn.NewRowState.New,				// 新規区分
						InventInputResult.ct_Col_GrossDiv			, (int)InventInputSearchCndtn.GrossDivState.Product,		// グロス区分(製番在庫ごと)
						InventInputResult.ct_Col_LogicalDeleteCode	, (int)ConstantManagement.LogicalMode.GetData0				// 論理削除区分
					);

					// string sortOrder = string.Format( "{0} Asc, {1} Asc", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_SortProductNumber );

					childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);

					if ( childRows != null && childRows.Length > 0 )
					{
                        bool isChildAfterSave = false;
						// 登録済みデータか未登録データの判断
						if ( (DateTime)childRows[0][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue )
							isChildAfterSave = false;
                        else
                        	isChildAfterSave = true;
                        
                        // 子行を削除
						foreach( DataRow childRow in childRows )
                        {
                            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                            //if (isChildAfterSave)
                            if ((isChildAfterSave) && (mode == 0))
                            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                            {
								// 登録済みデータは削除フラグを立てる
								childRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
								childRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
								childRow[InventInputResult.ct_Col_UpdateDiv] = 0;
								childRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
							}
							else
							{
                        		this._inventInputAcs.InventDataTable.Rows.Remove( childRow );
                        	}
                        }
                    }
				}
				else
				{
					// 製番毎のとき
					// 親行取得
					DataRow parentRow = this._inventInputAcs.InventDataTable.Rows.Find( this._inventInputAcs.GetPrimaryKeyList( targetRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty) );

					if ( parentRow != null ) 
					{

						// 自行の棚卸数を変更
						targetRow[InventInputResult.ct_Col_InventoryStockCnt] = 0;	// 棚卸数
						targetRow[InventInputResult.ct_Col_InventoryTolerancCnt] =	// 差異数
							(double)targetRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)targetRow[InventInputResult.ct_Col_StockTotal];

						// 親行から自行の棚卸数を引く
						bool isShowProduct = false;
						this.AfterInputInventryToleCnt( 
							ref targetRow,
							(int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );

						if ( (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] == 0 && 
							 (int)parentRow[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
						{
							if ( isTargetAfterSave )
							{
								// 登録済みデータは削除フラグを立てる
								parentRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
								parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
								parentRow[InventInputResult.ct_Col_UpdateDiv] = 0;
								parentRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
							}
							else
							{
								// 親を削除
								this._inventInputAcs.InventDataTable.Rows.Remove( parentRow );
							}
						}
					}
				}

				if ( isTargetAfterSave )
				{
					// 登録済みデータは削除フラグを立てる
					targetRow[InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
					targetRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
					targetRow[InventInputResult.ct_Col_UpdateDiv] = 0;
					targetRow[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
				}
				else
				{
					// 自行を削除
					this._inventInputAcs.InventDataTable.Rows.Remove( targetRow );
				}
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "棚卸データの削除に失敗しました。", status, "RowDeleteProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
				//if ( this.uGrid_InventInput.Rows.Count > activeRowIndex )
				//    activeRowIndex = this.uGrid_InventInput.Rows.Count - 1;

				if ( this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex )
				    this.uGrid_InventInput.Rows[activeRowIndex].Activate();

				this.uGrid_InventInput.EndUpdate();
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 編集処理メイン
        /// <summary>
        /// 編集処理メイン
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 編集処理を行う</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int DataEditProc()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int activeRowIndex = 0;

            try
            {
                if (this.uGrid_InventInput.ActiveRow != null)
                {
                    activeRowIndex = this.uGrid_InventInput.ActiveRow.Index;
                }

                if (this.uGrid_InventInput.ActiveRow == null)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // 選択行取得
                // DataRow editRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;   //DEL yangyi 2013/03/01 Redmine#34175
                DataRow editRow = GetBindDataRow(this.uGrid_InventInput.ActiveRow);                                             //ADD yangyi 2013/03/01 Redmine#34175 

                // 修正用クラス作成
                InventoryDataUpdateWork invEditWork = null;
                CreateInventUpdateWorkFromRow(out invEditWork, editRow);

                // 別インスタンスの行がほしいのでコピー
                int defGrossDiv = (int)editRow[InventInputResult.ct_Col_GrossDiv];

                if (invEditWork == null)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // 画面起動
                if (this._createNewInventForm == null)
                {
                    this._createNewInventForm = new MAZAI05130UD();
                    this._createNewInventForm.EnterpriseCode = this._enterpriseCode;
                    this._createNewInventForm.SectionCode = this._sectionCode;
                }

                this._defProdNumList.Clear();
                DataRow[] childRows = null;
                // 商品毎のとき
                if ((int)editRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods)
                {
                    // 子行を取得
                    string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                        InventInputResult.ct_Col_SectionCode, editRow[InventInputResult.ct_Col_SectionCode],		// 拠点コード
                        InventInputResult.ct_Col_WarehouseCode, editRow[InventInputResult.ct_Col_WarehouseCode],		// 倉庫コード
                        InventInputResult.ct_Col_MakerCode, editRow[InventInputResult.ct_Col_MakerCode],			// メーカーコード
                        InventInputResult.ct_Col_GoodsNo, editRow[InventInputResult.ct_Col_GoodsNo],			// 品番
                        InventInputResult.ct_Col_SupplierCode, editRow[InventInputResult.ct_Col_SupplierCode],		// 仕入先コード
                        InventInputResult.ct_Col_ShipCustomerCode, editRow[InventInputResult.ct_Col_ShipCustomerCode],	// 委託先コード
                        InventInputResult.ct_Col_StockDiv, editRow[InventInputResult.ct_Col_StockDiv],			// 在庫区分
                        InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Product,	// グロス区分(製番在庫ごと)
                        InventInputResult.ct_Col_LogicalDeleteCode, (int)ConstantManagement.LogicalMode.GetData0			// 論理削除区分
                    );

                    childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);
                }

                DialogResult dlgRes = this._createNewInventForm.ShowEditor(ref invEditWork, (int)MAZAI05130UD.DispModeState.EditNew, defGrossDiv);

                // 画面からの戻り値を判断
                if (dlgRes == DialogResult.OK)
                {
                    InventResetWorkFromRow(invEditWork, ref childRows[0]);
                    InventResetWorkFromRow(invEditWork, ref editRow);
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc("棚卸データの編集に失敗しました。", -1, "DataEditProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                this._defProdNumList.Clear();

                if (this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex)
                {
                    this.uGrid_InventInput.Rows[activeRowIndex].Activate();
                }
            }
            return status;
        }

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 編集処理メイン
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 編集処理を行う</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		private int DataEditProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			int activeRowIndex = 0;
            //bool isNewLine = false;   // 2008.02.14 削除

			try
			{
				if ( this.uGrid_InventInput.ActiveRow != null )
					activeRowIndex = this.uGrid_InventInput.ActiveRow.Index;

				if ( this.uGrid_InventInput.ActiveRow == null )
					return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				// 選択行取得
				DataRow editRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;

				// 修正用クラス作成
				InventoryDataUpdateWork invEditWork = null;
				CreateInventUpdateWorkFromRow( out invEditWork, editRow );

				// 別インスタンスの行がほしいのでコピー
				int defGrossDiv = (int)editRow[InventInputResult.ct_Col_GrossDiv];
				//DataRow defaultRow = this._inventInputAcs.InventDataTable.NewRow();
				//this._inventInputAcs.DevSearchResultProc( invEditWork, defaultRow, true, (int)InventInputSearchCndtn.ChangeFlagState.Change );


				if ( invEditWork == null )
					return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

				// 画面起動
				if ( this._createNewInventForm == null )
				{
					this._createNewInventForm = new MAZAI05130UD();
					this._createNewInventForm.EnterpriseCode = this._enterpriseCode;
					this._createNewInventForm.SectionCode = this._sectionCode;
				}

                this._defProdNumList.Clear();
				DataRow[] childRows = null;
				// 商品毎のとき
				if ( (int)editRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
				{
					// 子行を取得
                    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19} and {20}={21} and {22}={23}",
                    // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19}",
                    string rowFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17}",
                    // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_SectionCode        , editRow[InventInputResult.ct_Col_SectionCode],		// 拠点コード
						InventInputResult.ct_Col_WarehouseCode		, editRow[InventInputResult.ct_Col_WarehouseCode],		// 倉庫コード
						InventInputResult.ct_Col_MakerCode			, editRow[InventInputResult.ct_Col_MakerCode],			// メーカーコード
                        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_GoodsCode        , editRow[InventInputResult.ct_Col_GoodsCode],			// 品番
                        InventInputResult.ct_Col_GoodsNo            , editRow[InventInputResult.ct_Col_GoodsNo],			// 品番
                        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_CarrierEpCode    , editRow[InventInputResult.ct_Col_CarrierEpCode],		// 事業者コード
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_CustomerCode       , editRow[InventInputResult.ct_Col_CustomerCode],		// 得意先コード
						InventInputResult.ct_Col_ShipCustomerCode	, editRow[InventInputResult.ct_Col_ShipCustomerCode],	// 委託先コード
                        // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockUnitPrice   , editRow[InventInputResult.ct_Col_StockUnitPrice],		// 仕入単価
                        // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_StockDiv           , editRow[InventInputResult.ct_Col_StockDiv],			// 在庫区分
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockState       , editRow[InventInputResult.ct_Col_StockState],			// 在庫状態
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //InventInputResult.ct_Col_InventoryNewDiv	, (int)InventInputSearchCndtn.NewRowState.New,			// 新規区分
						InventInputResult.ct_Col_GrossDiv			, (int)InventInputSearchCndtn.GrossDivState.Product,	// グロス区分(製番在庫ごと)
						InventInputResult.ct_Col_LogicalDeleteCode	, (int)ConstantManagement.LogicalMode.GetData0			// 論理削除区分
                
					);
                
					//string sortOrder = string.Format( "{0} Asc, {1} Asc", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_SortProductNumber );
                    
                    childRows = this._inventInputAcs.InventDataTable.Select(rowFilter, this._strNowSort);//, sortOrder);
					if ( childRows != null && childRows.Length > 0 )
					{
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        #region 2007.09.11 削除
                        //string prdNum = "";
                        //string tel1 = "";
                        //string tel2 = "";
                        //
                        //InventoryDataUpdateWork defInv = null;
                        //for( int rowIndex = 0; rowIndex < childRows.Length; rowIndex++ )
                        //{
                        //	defInv = new InventoryDataUpdateWork();
                        //
                        //    if (childRows[rowIndex][InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
                        //		prdNum = childRows[rowIndex][InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
                        //	else
                        //		prdNum = "";
                        //
                        //	if ( childRows[rowIndex][InventInputResult.ct_Col_StockTelNo1] != DBNull.Value )
                        //		tel1 = childRows[rowIndex][InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
                        //	else
                        //		tel1 = "";
                        //
                        //	if ( childRows[rowIndex][InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
                        //		tel2 = childRows[rowIndex][InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
                        //	else
                        //		tel2 = "";
                        //
                        //	//if ( prdNum != "" || tel1 != "" || tel2 != "" )
                        //	//{
                        //		defInv.ProductNumber = prdNum.TrimEnd();
                        //		defInv.StockTelNo1 = tel1.TrimEnd();
                        //		defInv.StockTelNo2 = tel2.TrimEnd();
                        //		this._defProdNumList.Add( defInv );
                        //	//}
                        //}
                        #endregion
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

                        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                        // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                        //// 登録済みデータか未登録データの判断
                        //if ((DateTime)childRows[0][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                        //    isNewLine = true;
                        //else
                        //    isNewLine = false;
                        // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                    }
                }
				
				DialogResult dlgRes = this._createNewInventForm.ShowEditor( ref invEditWork, (int)MAZAI05130UD.DispModeState.EditNew, defGrossDiv );

				//this.uGrid_InventInput.BeginUpdate();
				// 画面からの戻り値を判断
				if ( dlgRes == DialogResult.OK )
				{
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //// OKのとき
                    //if ( this._defProdNumList.Count > 0 )
                    //{
                    //	if ( invEditWork.ProductNumber.TrimEnd() != "" )
                    //		((InventoryDataUpdateWork)this._defProdNumList[0]).ProductNumber = invEditWork.ProductNumber.TrimEnd();
                    //	if ( invEditWork.StockTelNo1.TrimEnd() != "" )
                    //		((InventoryDataUpdateWork)this._defProdNumList[0]).StockTelNo1 = invEditWork.StockTelNo1.TrimEnd();
                    //	if ( invEditWork.StockTelNo2.TrimEnd() != "" )
                    //		((InventoryDataUpdateWork)this._defProdNumList[0]).StockTelNo2 = invEditWork.StockTelNo2.TrimEnd();
                    //}
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //// 今の行を削除
                    //status = RowDeleteProc(editRow, this.uGrid_InventInput.ActiveRow.Index);
                    //
					////if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
					////    return status;
                    //
					//// 新しく行を作成
					//NewInventProc( invEditWork , true, false);

                    // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                    //if (isNewLine == true)
                    //{
                    //    // 今の行を削除
                    //    RowDeleteProc(editRow, this.uGrid_InventInput.ActiveRow.Index, 1);
                    //    // 新しく行を作成
                    //    NewInventProc( invEditWork , true, false);
                    //}
                    //else
                    //{
                    // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                        //foreach (DataRow childRow in childRows)
                        InventResetWorkFromRow(invEditWork, ref childRows[0]);
                        InventResetWorkFromRow(invEditWork, ref editRow);
                    // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                    //}
                    // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<

                    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                }
				#region
				//    this._inventInputAcs.DevSearchResultProc( invEditWork, editRow, true, (int)InventInputSearchCndtn.ChangeFlagState.Change );
				//    editRow[InventInputResult.ct_Col_GrossDiv] = defGrossDiv;

				//    bool isShowProduct = false;

				//    this.AfterInputInventryToleCnt( ref editRow, (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct );
				//    this.AfterInputInventoryDate( ref editRow, this.tde_InventoryDate.GetDateTime() );

				//    if ( defGrossDiv == (int)InventInputSearchCndtn.GrossDivState.Product )
				//    {
						
				//        // PrimaryKeyが下のデータと違ったら親データから棚卸数を削除しなければならない。
				//        // 親行検索
				//        DataRow parentRow = this._inventInputAcs.InventDataTable.Rows.Find( 
				//            this._inventInputAcs.GetPrimaryKeyList(editRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));

				//        // 親業があるか = キーが変わっているか
				//        if ( parentRow != null )
				//        {
				//            // キーが変わっていない場合
				//            // 前回差異数用に差異数を取得
				//            bfchgInvToleCnt = (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt];	

				//            // 棚卸数
				//            // 親行から棚卸数を引く
				//            parentRow[InventInputResult.ct_Col_InventoryStockCnt] = 
				//                (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - 
				//                (double)defaultRow[InventInputResult.ct_Col_InventoryStockCnt];// - (double)editRow[InventInputResult.ct_Col_InventoryStockCnt]);

				//            if ( (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] == 0 )
				//            {
				//                RowDeleteProc( parentRow, this.uGrid_InventInput.ActiveRow.Index );
				//            }
				//            else
				//            {
				//                parentRow[InventInputResult.ct_Col_InventoryTolerancCnt] = 
				//                    (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentRow[InventInputResult.ct_Col_StockTotal];
				//                // 前回差異数
				//                parentRow[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfchgInvToleCnt;
				//                // 変更区分をセット
				//                parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//                // 親行の棚卸更新日を変更
				//                this.AfterInputInventoryDate( ref parentRow, this.tde_InventoryDate.GetDateTime() );
				//            }
				//        }
				//        else
				//        {
				//            // キーが変わっている場合
				//            // 元の親行取得
				//            // PrimaryKeyが下のデータと違ったら親データから棚卸数を削除しなければならない。
				//            // 親行検索
				//            parentRow = this._inventInputAcs.InventDataTable.Rows.Find( 
				//                this._inventInputAcs.GetPrimaryKeyList(defaultRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty ));
				//            bfchgInvToleCnt = (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt];	// 前回差異数

				//            // 元の親行の棚卸数、差異数を変更
				//            if ( parentRow != null )
				//            {
				//                // 前回差異数用に差異数を取得
				//                bfchgInvToleCnt = (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt];	

				//                // 棚卸数
				//                // 親行から棚卸数を引く
				//                parentRow[InventInputResult.ct_Col_InventoryStockCnt] = 
				//                    (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - 
				//                    ((double)defaultRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)editRow[InventInputResult.ct_Col_InventoryStockCnt]);
				//                parentRow[InventInputResult.ct_Col_InventoryTolerancCnt] = 
				//                    (double)parentRow[InventInputResult.ct_Col_InventoryStockCnt] - (double)parentRow[InventInputResult.ct_Col_StockTotal];
				//                // 前回差異数
				//                parentRow[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfchgInvToleCnt;
				//                // 変更区分をセット
				//                parentRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
				//            }

				//            // 新しく親行を作成
				//            this._inventInputAcs.MakeGrossData( editRow, false );
				//        }
				//    }
				//    else
				//    {
				//        // 自行、子行を丸ごと削除。新規の行を作成する
				//    }
				//}
				#endregion
			}
			catch (Exception ex)
			{
				this.MsgDispProc( "棚卸データの編集に失敗しました。", -1, "DataEditProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
				this._defProdNumList.Clear();

				if ( this.uGrid_InventInput.Rows.Count > 0 && this.uGrid_InventInput.Rows.Count > activeRowIndex )
					this.uGrid_InventInput.Rows[activeRowIndex].Activate();

				//this.uGrid_InventInput.EndUpdate();
			}
			return status;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ 棚卸データ再設定
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸データ再設定
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 編集画面からの棚卸データ更新を再セットする</br>
        /// <br>Programer  : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.11</br>
        /// </remarks>
        private void InventResetWorkFromRow(InventoryDataUpdateWork invEditWork, ref DataRow editRow)
        {
            #region
            editRow[InventInputResult.ct_Col_InventorySeqNo] = invEditWork.InventorySeqNo;  // 棚卸通番
            editRow[InventInputResult.ct_Col_WarehouseCode] = invEditWork.WarehouseCode;  // 倉庫コード
            editRow[InventInputResult.ct_Col_WarehouseName] = invEditWork.WarehouseName;  // 倉庫名称

            editRow[InventInputResult.ct_Col_MakerCode] = invEditWork.GoodsMakerCd;  // メーカーコード
            editRow[InventInputResult.ct_Col_MakerName] = invEditWork.MakerName;  // メーカー名称
            editRow[InventInputResult.ct_Col_GoodsNo] = invEditWork.GoodsNo;  // 品番
            editRow[InventInputResult.ct_Col_GoodsName] = invEditWork.GoodsName;  // 品名
            editRow[InventInputResult.ct_Col_WarehouseShelfNo] = invEditWork.WarehouseShelfNo;   // 棚番
            editRow[InventInputResult.ct_Col_DuplicationShelfNo1] = invEditWork.DuplicationShelfNo1;// 重複棚番１
            editRow[InventInputResult.ct_Col_DuplicationShelfNo2] = invEditWork.DuplicationShelfNo2;// 重複棚番２
            editRow[InventInputResult.ct_Col_LargeGoodsGanreCode] = invEditWork.LargeGoodsGanreCode;  // 商品大分類コード
            editRow[InventInputResult.ct_Col_LargeGoodsGanreName] = invEditWork.LargeGoodsGanreName;  // 商品大分類名称
            editRow[InventInputResult.ct_Col_MediumGoodsGanreCode] = invEditWork.MediumGoodsGanreCode;  // 商品中分類コード
            editRow[InventInputResult.ct_Col_MediumGoodsGanreName] = invEditWork.MediumGoodsGanreName;  // 商品中分類名称
            editRow[InventInputResult.ct_Col_DetailGoodsGanreCode] = invEditWork.DetailGoodsGanreCode;   // グループコード
            editRow[InventInputResult.ct_Col_DetailGoodsGanreName] = invEditWork.DetailGoodsGanreName;       // グループコード名称
            editRow[InventInputResult.ct_Col_EnterpriseGanreCode] = invEditWork.EnterpriseGanreCode;    // 自社分類コード
            editRow[InventInputResult.ct_Col_EnterpriseGanreName] = invEditWork.EnterpriseGanreName;    // 自社分類名称
            editRow[InventInputResult.ct_Col_BLGoodsCode] = invEditWork.BLGoodsCode;    // ＢＬ品番
            //          editRow[InventInputResult.ct_Col_BLGoodsName] = invEditWork.BLGoodsName        ;    // ＢＬ品名
            //editRow[InventInputResult.ct_Col_CustomerCode] = invEditWork.CustomerCode;  // 得意先コード
            editRow[InventInputResult.ct_Col_CustomerName] = invEditWork.CustomerName;  // 得意先名称
            editRow[InventInputResult.ct_Col_CustomerName2] = invEditWork.CustomerName2;  // 得意先名称2

            editRow[InventInputResult.ct_Col_Jan] = invEditWork.Jan;  // JANコード
            editRow[InventInputResult.ct_Col_StockUnitPrice] = invEditWork.StockUnitPriceFl;  // 仕入単価
            editRow[InventInputResult.ct_Col_BfStockUnitPrice] = invEditWork.BfStockUnitPriceFl;  // 変更前仕入単価
            editRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] = invEditWork.StkUnitPriceChgFlg;  // 仕入単価変更フラグ
            editRow[InventInputResult.ct_Col_StockDiv] = invEditWork.StockDiv;  // 在庫区分
            editRow[InventInputResult.ct_Col_LastStockDate] = invEditWork.LastStockDate;  // 最終仕入年月日
            editRow[InventInputResult.ct_Col_StockTotal] = invEditWork.StockTotal;  // 在庫総数
            editRow[InventInputResult.ct_Col_ShipCustomerCode] = invEditWork.ShipCustomerCode;  // 出荷先得意先コード
            editRow[InventInputResult.ct_Col_ShipCustomerName] = invEditWork.ShipCustomerName;  // 出荷先得意先名称
            editRow[InventInputResult.ct_Col_ShipCustomerName2] = invEditWork.ShipCustomerName2;  // 出荷先得意先名称2

            editRow[InventInputResult.ct_Col_InventoryStockCnt] = invEditWork.InventoryStockCnt; // 棚卸在庫数
            editRow[InventInputResult.ct_Col_InventoryTolerancCnt] = invEditWork.InventoryTolerancCnt;  // 棚卸過不足数
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            editRow[InventInputResult.ct_Col_InventoryExeDay_Str] = TDateTime.DateTimeToLongDate(invEditWork.InventoryDate).ToString(); // 棚卸日
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            editRow[InventInputResult.ct_Col_InventoryPreprDay] = TDateTime.DateTimeToLongDate(invEditWork.InventoryPreprDay);  // 棚卸準備処理日付
            editRow[InventInputResult.ct_Col_InventoryPreprTim] = invEditWork.InventoryPreprTim;  // 棚卸準備処理時間
            editRow[InventInputResult.ct_Col_InventoryDay] = TDateTime.DateTimeToLongDate(invEditWork.InventoryDay);  // 棚卸実施日
            editRow[InventInputResult.ct_Col_LastInventoryUpdate] = invEditWork.LastInventoryUpdate;  // 最終棚卸更新日
            editRow[InventInputResult.ct_Col_InventoryNewDiv] = invEditWork.InventoryNewDiv;  // 棚卸新規追加区分
            editRow[InventInputResult.ct_Col_StockMashinePrice] = invEditWork.StockMashinePrice;   // マシン在庫額
            editRow[InventInputResult.ct_Col_InventoryStockPrice] = invEditWork.InventoryStockPrice; // 棚卸在庫額
            editRow[InventInputResult.ct_Col_InventoryTlrncPrice] = invEditWork.InventoryTlrncPrice; // 棚卸過不足金額
            editRow[InventInputResult.ct_Col_Status] = invEditWork.Status;  // ステータス	

            editRow[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            editRow[InventInputResult.ct_Col_UpdateDiv] = 0;
            #endregion
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸データ再設定
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 編集画面からの棚卸データ更新を再セットする</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private void InventResetWorkFromRow(InventoryDataUpdateWork invEditWork, ref DataRow dr)
        {
            // 棚卸通番
            dr[InventInputResult.ct_Col_InventorySeqNo] = invEditWork.InventorySeqNo;
            // 倉庫コード                 
            dr[InventInputResult.ct_Col_WarehouseCode] = invEditWork.WarehouseCode;
            // 倉庫名称                
            if (invEditWork.WarehouseCode.Trim() == "")
            {
                dr[InventInputResult.ct_Col_WarehouseName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_WarehouseName] = this._inventInputAcs.GetWarehouseName(invEditWork.WarehouseCode);
            }
            // メーカーコード
            dr[InventInputResult.ct_Col_MakerCode] = invEditWork.GoodsMakerCd;
            // メーカー名称
            if (invEditWork.GoodsMakerCd == 0)
            {
                dr[InventInputResult.ct_Col_MakerName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_MakerName] = this._inventInputAcs.GetMakerName(invEditWork.GoodsMakerCd);
            }
            // 品番
            dr[InventInputResult.ct_Col_GoodsNo] = invEditWork.GoodsNo;
            // 品名
            if ((invEditWork.GoodsMakerCd == 0) || (invEditWork.GoodsNo.Trim() == ""))
            {
                dr[InventInputResult.ct_Col_GoodsName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_GoodsName] = this._inventInputAcs.GetGoodsName(invEditWork.GoodsMakerCd, invEditWork.GoodsNo);
            }
            // 棚番
            dr[InventInputResult.ct_Col_WarehouseShelfNo] = invEditWork.WarehouseShelfNo;
            // 重複棚番１           
            dr[InventInputResult.ct_Col_DuplicationShelfNo1] = invEditWork.DuplicationShelfNo1;
            // 重複棚番２
            dr[InventInputResult.ct_Col_DuplicationShelfNo2] = invEditWork.DuplicationShelfNo2;
            // 商品大分類コード
            dr[InventInputResult.ct_Col_LargeGoodsGanreCode] = invEditWork.GoodsLGroup;
            // 商品中分類コード
            dr[InventInputResult.ct_Col_MediumGoodsGanreCode] = invEditWork.GoodsMGroup;
            // グループコード
            dr[InventInputResult.ct_Col_BLGroupCode] = invEditWork.BLGroupCode;
            // グループコード名称
            if (invEditWork.BLGroupCode == 0)
            {
                dr[InventInputResult.ct_Col_BLGroupName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_BLGroupName] = this._inventInputAcs.GetBLGroupName(invEditWork.BLGroupCode);
            }
            // 自社分類コード
            dr[InventInputResult.ct_Col_EnterpriseGanreCode] = invEditWork.EnterpriseGanreCode;
            // ＢＬコード   
            dr[InventInputResult.ct_Col_BLGoodsCode] = invEditWork.BLGoodsCode;
            // ＢＬコード名称
            if (invEditWork.BLGoodsCode == 0)
            {
                dr[InventInputResult.ct_Col_BLGoodsName] = "";
            }
            else
            {
                dr[InventInputResult.ct_Col_BLGoodsName] = this._inventInputAcs.GetBLGoodsName(invEditWork.BLGoodsCode);
            }
            // 仕入先コード
            dr[InventInputResult.ct_Col_SupplierCode] = invEditWork.SupplierCd;
            // 仕入先名称
            // 仕入先名称2
            if (invEditWork.SupplierCd == 0)
            {
                dr[InventInputResult.ct_Col_SupplierName] = "";
                dr[InventInputResult.ct_Col_SupplierName2] = "";
            }
            else
            {
                int status;
                string supplierName1;
                string supplierName2;
                status = this._inventInputAcs.GetSupplierName(invEditWork.SupplierCd, out supplierName1, out supplierName2);
                if (status == 0)
                {
                    dr[InventInputResult.ct_Col_SupplierName] = supplierName1;
                    dr[InventInputResult.ct_Col_SupplierName2] = supplierName2;
                }
                else
                {
                    dr[InventInputResult.ct_Col_SupplierName] = "";
                    dr[InventInputResult.ct_Col_SupplierName2] = "";
                }
            }
            // JANコード
            dr[InventInputResult.ct_Col_Jan] = invEditWork.Jan;
            // 仕入単価             
            dr[InventInputResult.ct_Col_StockUnitPrice] = invEditWork.StockUnitPriceFl;
            // 変更前仕入単価     
            dr[InventInputResult.ct_Col_BfStockUnitPrice] = invEditWork.BfStockUnitPriceFl;
            // 仕入単価変更フラグ
            dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = invEditWork.StkUnitPriceChgFlg;
            // 在庫区分
            dr[InventInputResult.ct_Col_StockDiv] = invEditWork.StockDiv;
            // 最終仕入年月日
            dr[InventInputResult.ct_Col_LastStockDate] = invEditWork.LastStockDate;
            // 在庫総数
            dr[InventInputResult.ct_Col_StockTotal] = invEditWork.StockTotal;
            // 出荷先得意先コード
            dr[InventInputResult.ct_Col_ShipCustomerCode] = invEditWork.ShipCustomerCode;
            // 棚卸在庫数
            dr[InventInputResult.ct_Col_InventoryStockCnt] = invEditWork.InventoryStockCnt;
            // 棚卸過不足数
            dr[InventInputResult.ct_Col_InventoryTolerancCnt] = invEditWork.InventoryTolerancCnt;
            // 棚卸日
            dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] = invEditWork.InventoryDate;
            // 棚卸準備処理日付
            dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] = invEditWork.InventoryPreprDay;
            // 棚卸準備処理時間
            dr[InventInputResult.ct_Col_InventoryPreprTim] = invEditWork.InventoryPreprTim;
            // 棚卸実施日
            dr[InventInputResult.ct_Col_InventoryDay] = TDateTime.DateTimeToLongDate(invEditWork.InventoryDay);
            // 最終棚卸更新日
            dr[InventInputResult.ct_Col_LastInventoryUpdate] = invEditWork.LastInventoryUpdate;
            // 棚卸新規追加区分
            dr[InventInputResult.ct_Col_InventoryNewDiv] = invEditWork.InventoryNewDiv;
            // マシン在庫額
            dr[InventInputResult.ct_Col_StockMashinePrice] = invEditWork.StockMashinePrice;
            // 棚卸在庫額
            dr[InventInputResult.ct_Col_InventoryStockPrice] = invEditWork.InventoryStockPrice;
            // 棚卸過不足金額
            dr[InventInputResult.ct_Col_InventoryTlrncPrice] = invEditWork.InventoryTlrncPrice;
            // ステータス
            dr[InventInputResult.ct_Col_Status] = invEditWork.Status;  	
            dr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
            dr[InventInputResult.ct_Col_UpdateDiv] = 0;

            // 調整用計算原価
            dr[InventInputResult.ct_Col_AdjustCalcCost] = invEditWork.AdjstCalcCost;        //ADD 2009/05/14 不具合対応[13260]
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region ◎ 編集用棚卸データ更新クラス作成
        /// <summary>
        /// 編集用棚卸データ更新クラス作成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 編集画面に渡す棚卸データ更新クラスを作成する</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private int CreateInventUpdateWorkFromRow(out InventoryDataUpdateWork invEditWork, DataRow dr)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            invEditWork = new InventoryDataUpdateWork();

            // 作成日時
            if (dr[InventInputResult.ct_Col_CreateDateTime] == DBNull.Value)
            {
                invEditWork.CreateDateTime = DateTime.MinValue;
            }
            else
            {
                invEditWork.CreateDateTime = (DateTime)dr[InventInputResult.ct_Col_CreateDateTime];
            }
            // 更新日時
            if (dr[InventInputResult.ct_Col_UpdateDateTime] == DBNull.Value)
            {
                invEditWork.UpdateDateTime = DateTime.MinValue;
            }
            else
            {
                invEditWork.UpdateDateTime = (DateTime)dr[InventInputResult.ct_Col_UpdateDateTime];                 
            }
            // 企業コード
            if (dr[InventInputResult.ct_Col_EnterpriseCode] == DBNull.Value)
            {
                invEditWork.EnterpriseCode = "";
            }
            else
            {
                invEditWork.EnterpriseCode = (string)dr[InventInputResult.ct_Col_EnterpriseCode];                   
            }
            // GUID
            if (dr[InventInputResult.ct_Col_FileHeaderGuid] == DBNull.Value)
            {
                invEditWork.FileHeaderGuid = Guid.Empty;
            }
            else
            {
                invEditWork.FileHeaderGuid = (Guid)dr[InventInputResult.ct_Col_FileHeaderGuid];                     
            }
            // 更新従業員コード
            if (dr[InventInputResult.ct_Col_UpdEmployeeCode] == DBNull.Value)
            {
                invEditWork.UpdEmployeeCode = "";
            }
            else
            {
                invEditWork.UpdEmployeeCode = (string)dr[InventInputResult.ct_Col_UpdEmployeeCode];                 
            }
            // 更新アセンブリID1
            if (dr[InventInputResult.ct_Col_UpdAssemblyId1] == DBNull.Value)
            {
                invEditWork.UpdAssemblyId1 = "";
            }
            else
            {
                invEditWork.UpdAssemblyId1 = (string)dr[InventInputResult.ct_Col_UpdAssemblyId1];                   
            }
            // 更新アセンブリID2
            if (dr[InventInputResult.ct_Col_UpdAssemblyId2] == DBNull.Value)
            {
                invEditWork.UpdAssemblyId2 = "";
            }
            else
            {
                invEditWork.UpdAssemblyId2 = (string)dr[InventInputResult.ct_Col_UpdAssemblyId2];                   
            }
            // 論理削除区分
            if (dr[InventInputResult.ct_Col_LogicalDeleteCode] == DBNull.Value)
            {
                invEditWork.LogicalDeleteCode = 0;
            }
            else
            {
                invEditWork.LogicalDeleteCode = (Int32)dr[InventInputResult.ct_Col_LogicalDeleteCode];              
            }
            // 拠点コード
            if (dr[InventInputResult.ct_Col_SectionCode] == DBNull.Value)
            {
                invEditWork.SectionCode = "";
            }
            else
            {
                invEditWork.SectionCode = (string)dr[InventInputResult.ct_Col_SectionCode];                         
            }
            // 棚卸通番
            if (dr[InventInputResult.ct_Col_InventorySeqNo] == DBNull.Value)
            {
                invEditWork.InventorySeqNo = 0;
            }
            else
            {
                invEditWork.InventorySeqNo = (Int32)dr[InventInputResult.ct_Col_InventorySeqNo];                    
            }
            // 倉庫コード
            if (dr[InventInputResult.ct_Col_WarehouseCode] == DBNull.Value)
            {
                invEditWork.WarehouseCode = "";
            }
            else
            {
                invEditWork.WarehouseCode = (string)dr[InventInputResult.ct_Col_WarehouseCode];                     
            }
            // メーカーコード
            if (dr[InventInputResult.ct_Col_MakerCode] == DBNull.Value)
            {
                invEditWork.GoodsMakerCd = 0;
            }
            else
            {
                invEditWork.GoodsMakerCd = (Int32)dr[InventInputResult.ct_Col_MakerCode];                           
            }
            // 品番
            if (dr[InventInputResult.ct_Col_GoodsNo] == DBNull.Value)
            {
                invEditWork.GoodsNo = "";
            }
            else
            {
                invEditWork.GoodsNo = (string)dr[InventInputResult.ct_Col_GoodsNo];                                 
            }
            // 棚番
            if (dr[InventInputResult.ct_Col_WarehouseShelfNo] == DBNull.Value)
            {
                invEditWork.WarehouseShelfNo = "";
            }
            else
            {
                invEditWork.WarehouseShelfNo = (string)dr[InventInputResult.ct_Col_WarehouseShelfNo];               
            }
            // 重複棚番１
            if (dr[InventInputResult.ct_Col_DuplicationShelfNo1] == DBNull.Value)
            {
                invEditWork.DuplicationShelfNo1 = "";
            }
            else
            {
                invEditWork.DuplicationShelfNo1 = (string)dr[InventInputResult.ct_Col_DuplicationShelfNo1];         
            }
            // 重複棚番２
            if (dr[InventInputResult.ct_Col_DuplicationShelfNo2] == DBNull.Value)
            {
                invEditWork.DuplicationShelfNo2 = "";
            }
            else
            {
                invEditWork.DuplicationShelfNo2 = (string)dr[InventInputResult.ct_Col_DuplicationShelfNo2];         
            }
            // 商品大分類コード
            if (dr[InventInputResult.ct_Col_LargeGoodsGanreCode] == DBNull.Value)
            {
                invEditWork.GoodsLGroup = 0;
            }
            else
            {
                invEditWork.GoodsLGroup = (Int32)dr[InventInputResult.ct_Col_LargeGoodsGanreCode];                    
            }
            // 商品中分類コード
            if (dr[InventInputResult.ct_Col_MediumGoodsGanreCode] == DBNull.Value)
            {
                invEditWork.GoodsMGroup = 0;
            }
            else
            {
                invEditWork.GoodsMGroup = (Int32)dr[InventInputResult.ct_Col_MediumGoodsGanreCode];
            }
            // グループコード
            if (dr[InventInputResult.ct_Col_BLGroupCode] == DBNull.Value)
            {
                invEditWork.BLGroupCode = 0;
            }
            else
            {
                invEditWork.BLGroupCode = (Int32)dr[InventInputResult.ct_Col_BLGroupCode];
            }
            // 自社分類コード
            if (dr[InventInputResult.ct_Col_EnterpriseGanreCode] == DBNull.Value)
            {
                invEditWork.EnterpriseGanreCode = 0;
            }
            else
            {
                invEditWork.EnterpriseGanreCode = (Int32)dr[InventInputResult.ct_Col_EnterpriseGanreCode];
            }
            // ＢＬコード
            if (dr[InventInputResult.ct_Col_BLGoodsCode] == DBNull.Value)
            {
                invEditWork.BLGoodsCode = 0;
            }
            else
            {
                invEditWork.BLGoodsCode = (Int32)dr[InventInputResult.ct_Col_BLGoodsCode];
            }
            // 仕入先コード
            if (dr[InventInputResult.ct_Col_SupplierCode] == DBNull.Value)
            {
                invEditWork.SupplierCd = 0;
            }
            else
            {
                invEditWork.SupplierCd = (Int32)dr[InventInputResult.ct_Col_SupplierCode];
            }
            // JANコード
            if (dr[InventInputResult.ct_Col_Jan] == DBNull.Value)
            {
                invEditWork.Jan = "";
            }
            else
            {
                invEditWork.Jan = (string)dr[InventInputResult.ct_Col_Jan];                                         
            }
            // 仕入単価
            if (dr[InventInputResult.ct_Col_StockUnitPrice] == DBNull.Value)
            {
                invEditWork.StockUnitPriceFl = 0;
            }
            else
            {
                invEditWork.StockUnitPriceFl = (Double)dr[InventInputResult.ct_Col_StockUnitPrice];
            }
            // 変更前仕入単価
            if (dr[InventInputResult.ct_Col_BfStockUnitPrice] == DBNull.Value)
            {
                invEditWork.BfStockUnitPriceFl = 0;
            }
            else
            {
                invEditWork.BfStockUnitPriceFl = (Double)dr[InventInputResult.ct_Col_BfStockUnitPrice];
            }
            // 仕入単価変更フラグ
            if (dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] == DBNull.Value)
            {
                invEditWork.StkUnitPriceChgFlg = 0;
            }
            else
            {
                invEditWork.StkUnitPriceChgFlg = (Int32)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg];
            }
            // 在庫区分
            if (dr[InventInputResult.ct_Col_StockDiv] == DBNull.Value)
            {
                invEditWork.StockDiv = 0;
            }
            else
            {
                invEditWork.StockDiv = (Int32)dr[InventInputResult.ct_Col_StockDiv];
            }
            // 最終仕入年月日
            if (dr[InventInputResult.ct_Col_LastStockDate] == DBNull.Value)
            {
                invEditWork.LastStockDate = DateTime.MinValue;
            }
            else
            {
                invEditWork.LastStockDate = (DateTime)dr[InventInputResult.ct_Col_LastStockDate];
            }
            // 在庫総数
            if (dr[InventInputResult.ct_Col_StockTotal] == DBNull.Value)
            {
                invEditWork.StockTotal = 0;
            }
            else
            {
                invEditWork.StockTotal = (Double)dr[InventInputResult.ct_Col_StockTotal];
            }
            // 出荷先得意先コード
            if (dr[InventInputResult.ct_Col_ShipCustomerCode] == DBNull.Value)
            {
                invEditWork.ShipCustomerCode = 0;
            }
            else
            {
                invEditWork.ShipCustomerCode = (Int32)dr[InventInputResult.ct_Col_ShipCustomerCode];
            }
            // 棚卸在庫数
            if (dr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
            {
                invEditWork.InventoryStockCnt = (Double)dr[InventInputResult.ct_Col_InventoryStockCnt];      
            }
            else
            {
                invEditWork.InventoryStockCnt = 0;
            }
            // 差異数
            if (dr[InventInputResult.ct_Col_InventoryTolerancCnt] == DBNull.Value)
            {
                invEditWork.InventoryTolerancCnt = 0;
            }
            else
            {
                invEditWork.InventoryTolerancCnt = (Double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];
            }
            // 棚卸日
            if (dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] == DBNull.Value)
            {
                invEditWork.InventoryDate = DateTime.MinValue;
            }
            else
            {
                invEditWork.InventoryDate = (DateTime)dr[InventInputResult.ct_Col_InventoryExeDay_Datetime];
            }
            // 棚卸準備処理日付
            if (dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] == DBNull.Value)
            {
                invEditWork.InventoryPreprDay = DateTime.MinValue;
            }
            else
            {
                invEditWork.InventoryPreprDay = (DateTime)dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime];
            }
            // 棚卸準備処理時間
            if (dr[InventInputResult.ct_Col_InventoryPreprTim] == DBNull.Value)
            {
                invEditWork.InventoryPreprTim = 0;
            }
            else
            {
                invEditWork.InventoryPreprTim = (Int32)dr[InventInputResult.ct_Col_InventoryPreprTim];
            }
            // 棚卸実施日
            if (dr[InventInputResult.ct_Col_InventoryDay] == DBNull.Value)
            {
                invEditWork.InventoryDay = DateTime.MinValue;
            }
            else
            {
                invEditWork.InventoryDay = TDateTime.LongDateToDateTime((int)dr[InventInputResult.ct_Col_InventoryDay]);
            }
            // 最終棚卸更新日
            if (dr[InventInputResult.ct_Col_LastInventoryUpdate] == DBNull.Value)
            {
                invEditWork.LastInventoryUpdate = DateTime.MinValue;
            }
            else
            {
                invEditWork.LastInventoryUpdate = (DateTime)dr[InventInputResult.ct_Col_LastInventoryUpdate];
            }
            // 棚卸新規追加区分
            if (dr[InventInputResult.ct_Col_InventoryNewDiv] == DBNull.Value)
            {
                invEditWork.InventoryNewDiv = 0;
            }
            else
            {
                invEditWork.InventoryNewDiv = (Int32)dr[InventInputResult.ct_Col_InventoryNewDiv];
            }
            // マシン在庫額
            if (dr[InventInputResult.ct_Col_StockMashinePrice] == DBNull.Value)
            {
                invEditWork.StockMashinePrice = 0;
            }
            else
            {
                invEditWork.StockMashinePrice = (Int64)dr[InventInputResult.ct_Col_StockMashinePrice];
            }
            // 棚卸在庫額
            if (dr[InventInputResult.ct_Col_InventoryStockPrice] == DBNull.Value)
            {
                invEditWork.InventoryStockPrice = 0;
            }
            else
            {
                invEditWork.InventoryStockPrice = (Int64)dr[InventInputResult.ct_Col_InventoryStockPrice];
            }
            // 棚卸過不足金額
            if (dr[InventInputResult.ct_Col_InventoryTlrncPrice] == DBNull.Value)
            {
                invEditWork.InventoryTlrncPrice = 0;
            }
            else
            {
                invEditWork.InventoryTlrncPrice = (Int64)dr[InventInputResult.ct_Col_InventoryTlrncPrice];
            }
            // ステータス
            if (dr[InventInputResult.ct_Col_Status] == DBNull.Value)
            {
                invEditWork.Status = 0;
            }
            else
            {
                invEditWork.Status = (Int32)dr[InventInputResult.ct_Col_Status];
            }

            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------->>>>>
            // 在庫総数(実施日)
            if (dr[InventInputResult.ct_Col_StockTotalExec] == DBNull.Value)
            {
                invEditWork.StockTotalExec = 0;
            }
            else
            {
                invEditWork.StockTotalExec = (Double)dr[InventInputResult.ct_Col_StockTotalExec];
            }
            // 過不足更新区分
            if (dr[InventInputResult.ct_Col_ToleranceUpdateCd] == DBNull.Value)
            {
                invEditWork.ToleranceUpdateCd = 0;
            }
            else
            {
                invEditWork.ToleranceUpdateCd = (Int32)dr[InventInputResult.ct_Col_ToleranceUpdateCd];
            }
            // 調整用計算原価
            if (dr[InventInputResult.ct_Col_AdjustCalcCost] == DBNull.Value)
            {
                invEditWork.AdjstCalcCost = 0;
            }
            else
            {
                invEditWork.AdjstCalcCost = (Double)dr[InventInputResult.ct_Col_AdjustCalcCost];
            }
            // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------<<<<<
            return status;
        }

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 編集用棚卸データ更新クラス作成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 編集画面に渡す棚卸データ更新クラスを作成する</br>
        /// <br>Programer  : 22013 kubo</br>
        /// <br>Date       : 2007.07.25</br>
        /// </remarks>
        private int CreateInventUpdateWorkFromRow(out InventoryDataUpdateWork invEditWork, DataRow editRow)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            invEditWork = new InventoryDataUpdateWork();

            #region
            invEditWork.CreateDateTime = (DateTime)editRow[InventInputResult.ct_Col_CreateDateTime];  // 作成日時
            invEditWork.UpdateDateTime = (DateTime)editRow[InventInputResult.ct_Col_UpdateDateTime];  // 更新日時
            invEditWork.EnterpriseCode = (string)editRow[InventInputResult.ct_Col_EnterpriseCode];  // 企業コード
            invEditWork.FileHeaderGuid = (Guid)editRow[InventInputResult.ct_Col_FileHeaderGuid];  // GUID
            invEditWork.UpdEmployeeCode = (string)editRow[InventInputResult.ct_Col_UpdEmployeeCode];  // 更新従業員コード
            invEditWork.UpdAssemblyId1 = (string)editRow[InventInputResult.ct_Col_UpdAssemblyId1];  // 更新アセンブリID1
            invEditWork.UpdAssemblyId2 = (string)editRow[InventInputResult.ct_Col_UpdAssemblyId2];  // 更新アセンブリID2
            invEditWork.LogicalDeleteCode = (Int32)editRow[InventInputResult.ct_Col_LogicalDeleteCode];  // 論理削除区分
            invEditWork.SectionCode = (string)editRow[InventInputResult.ct_Col_SectionCode];  // 拠点コード
            //			invEditWork.SectionGuideNm			= (string)editRow[InventInputResult.ct_Col_SectionGuideNm];  // 拠点ガイド名称
            invEditWork.InventorySeqNo = (Int32)editRow[InventInputResult.ct_Col_InventorySeqNo];  // 棚卸通番
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.ProductStockGuid        = (Guid)editRow[InventInputResult.ct_Col_ProductStockGuid];  // 製番在庫マスタGUID
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            invEditWork.WarehouseCode = (string)editRow[InventInputResult.ct_Col_WarehouseCode];  // 倉庫コード
            invEditWork.WarehouseName = (string)editRow[InventInputResult.ct_Col_WarehouseName];  // 倉庫名称

            invEditWork.GoodsMakerCd = (Int32)editRow[InventInputResult.ct_Col_MakerCode];  // メーカーコード
            invEditWork.MakerName = (string)editRow[InventInputResult.ct_Col_MakerName];  // メーカー名称
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.GoodsCode 				= (string)editRow[InventInputResult.ct_Col_GoodsCode];  // 品番
            invEditWork.GoodsNo = (string)editRow[InventInputResult.ct_Col_GoodsNo];  // 品番
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            invEditWork.GoodsName = (string)editRow[InventInputResult.ct_Col_GoodsName];  // 品名
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.CellphoneModelCode      = (string)editRow[InventInputResult.ct_Col_CellphoneModelCode];  // 機種コード
            //invEditWork.CellphoneModelName		= (string)editRow[InventInputResult.ct_Col_CellphoneModelName];  // 機種名称
            //invEditWork.CarrierCode 			= (Int32)editRow[InventInputResult.ct_Col_CarrierCode];  // キャリアコード
            //invEditWork.CarrierName 			= (string)editRow[InventInputResult.ct_Col_CarrierName];  // キャリア名称
            //invEditWork.SystematicColorCd 		= (Int32)editRow[InventInputResult.ct_Col_SystematicColorCd];  // 系統色コード
            //invEditWork.SystematicColorNm 		= (string)editRow[InventInputResult.ct_Col_SystematicColorNm];  // 系統色名称
            invEditWork.WarehouseShelfNo = (string)editRow[InventInputResult.ct_Col_WarehouseShelfNo];   // 棚番
            invEditWork.DuplicationShelfNo1 = (string)editRow[InventInputResult.ct_Col_DuplicationShelfNo1];// 重複棚番１
            invEditWork.DuplicationShelfNo2 = (string)editRow[InventInputResult.ct_Col_DuplicationShelfNo2];// 重複棚番２
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            invEditWork.LargeGoodsGanreCode = (string)editRow[InventInputResult.ct_Col_LargeGoodsGanreCode];  // 商品大分類コード
            invEditWork.LargeGoodsGanreName = (string)editRow[InventInputResult.ct_Col_LargeGoodsGanreName];  // 商品大分類名称
            invEditWork.MediumGoodsGanreCode = (string)editRow[InventInputResult.ct_Col_MediumGoodsGanreCode];  // 商品中分類コード
            invEditWork.MediumGoodsGanreName = (string)editRow[InventInputResult.ct_Col_MediumGoodsGanreName];  // 商品中分類名称
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.CarrierEpCode           = (Int32)editRow[InventInputResult.ct_Col_CarrierEpCode];  // 事業者コード
            //invEditWork.CarrierEpName			= (string)editRow[InventInputResult.ct_Col_CarrierEpName];  // 事業者名称
            invEditWork.DetailGoodsGanreCode = (string)editRow[InventInputResult.ct_Col_DetailGoodsGanreCode];   // グループコード
            invEditWork.DetailGoodsGanreName = (string)editRow[InventInputResult.ct_Col_DetailGoodsGanreName];   // グループコード名称
            invEditWork.EnterpriseGanreCode = (Int32)editRow[InventInputResult.ct_Col_EnterpriseGanreCode];    // 自社分類コード
            invEditWork.EnterpriseGanreName = (string)editRow[InventInputResult.ct_Col_EnterpriseGanreName];    // 自社分類名称
            invEditWork.BLGoodsCode = (Int32)editRow[InventInputResult.ct_Col_BLGoodsCode];    // ＢＬ品番
            //invEditWork.BLGoodsName             = (string)editRow[InventInputResult.ct_Col_BLGoodsName];    // ＢＬ品名
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            invEditWork.CustomerCode = (Int32)editRow[InventInputResult.ct_Col_CustomerCode];  // 得意先コード
            invEditWork.CustomerName = (string)editRow[InventInputResult.ct_Col_CustomerName];  // 得意先名称
            invEditWork.CustomerName2 = (string)editRow[InventInputResult.ct_Col_CustomerName2];  // 得意先名称2
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.StockDate               = (DateTime)editRow[InventInputResult.ct_Col_StockDate];  // 仕入日
            //invEditWork.ArrivalGoodsDay			= (DateTime)editRow[InventInputResult.ct_Col_ArrivalGoodsDay];  // 入荷日
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (editRow[InventInputResult.ct_Col_ProductNumber] != DBNull.Value)
            //	invEditWork.ProductNumber			= (string)editRow[InventInputResult.ct_Col_ProductNumber];  // 製造番号
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if (editRow[InventInputResult.ct_Col_StockTelNo1] != DBNull.Value)
            //	invEditWork.StockTelNo1				= (string)editRow[InventInputResult.ct_Col_StockTelNo1];  // 商品電話番号1
            //
            //if ( editRow[InventInputResult.ct_Col_BfStockTelNo1] != DBNull.Value )
            //	invEditWork.BfStockTelNo1			= (string)editRow[InventInputResult.ct_Col_BfStockTelNo1];  // 変更前商品電話番号1
            //
            //invEditWork.StkTelNo1ChgFlg			= (Int32)editRow[InventInputResult.ct_Col_StkTelNo1ChgFlg];  // 商品電話番号1変更フラグ
            //
            //if ( editRow[InventInputResult.ct_Col_StockTelNo2] != DBNull.Value )
            //	invEditWork.StockTelNo2				= (string)editRow[InventInputResult.ct_Col_StockTelNo2];  // 商品電話番号2
            //
            //if ( editRow[InventInputResult.ct_Col_BfStockTelNo2] != DBNull.Value )
            //	invEditWork.BfStockTelNo2			= (string)editRow[InventInputResult.ct_Col_BfStockTelNo2];  // 変更前商品電話番号2
            //
            //invEditWork.StkTelNo2ChgFlg			= (Int32)editRow[InventInputResult.ct_Col_StkTelNo2ChgFlg];  // 商品電話番号2変更フラグ
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            invEditWork.Jan = (string)editRow[InventInputResult.ct_Col_Jan];  // JANコード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.StockUnitPriceFl      = (Int64)editRow[InventInputResult.ct_Col_StockUnitPrice];      // 仕入単価
            //invEditWork.BfStockUnitPriceFl    = (Int64)editRow[InventInputResult.ct_Col_BfStockUnitPrice];    // 変更前仕入単価
            invEditWork.StockUnitPriceFl = (Double)editRow[InventInputResult.ct_Col_StockUnitPrice];     // 仕入単価
            invEditWork.BfStockUnitPriceFl = (Double)editRow[InventInputResult.ct_Col_BfStockUnitPrice];   // 変更前仕入単価
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            invEditWork.StkUnitPriceChgFlg = (Int32)editRow[InventInputResult.ct_Col_StkUnitPriceChgFlg];  // 仕入単価変更フラグ
            invEditWork.StockDiv = (Int32)editRow[InventInputResult.ct_Col_StockDiv];            // 在庫区分
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.StockState            = (Int32)editRow[InventInputResult.ct_Col_StockState];          // 在庫状態
            //invEditWork.MoveStatus			= (Int32)editRow[InventInputResult.ct_Col_MoveStatus];          // 移動状態
            //invEditWork.GoodsCodeStatus		= (Int32)editRow[InventInputResult.ct_Col_GoodsCodeStatus];     // 商品状態
            //invEditWork.PrdNumMngDiv			= (Int32)editRow[InventInputResult.ct_Col_PrdNumMngDiv];        // 製番管理区分
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            invEditWork.LastStockDate = (DateTime)editRow[InventInputResult.ct_Col_LastStockDate];    // 最終仕入年月日
            invEditWork.StockTotal = (Double)editRow[InventInputResult.ct_Col_StockTotal];         // 在庫総数
            invEditWork.ShipCustomerCode = (Int32)editRow[InventInputResult.ct_Col_ShipCustomerCode];    // 出荷先得意先コード
            invEditWork.ShipCustomerName = (string)editRow[InventInputResult.ct_Col_ShipCustomerName];   // 出荷先得意先名称
            invEditWork.ShipCustomerName2 = (string)editRow[InventInputResult.ct_Col_ShipCustomerName2];  // 出荷先得意先名称2

            if (editRow[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)  // 棚卸在庫数
                invEditWork.InventoryStockCnt = (Double)editRow[InventInputResult.ct_Col_InventoryStockCnt];      // 棚卸在庫数
            else
                invEditWork.InventoryStockCnt = 0;

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //if (editRow[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value)  // 棚卸過不足数
            //    invEditWork.InventoryTolerancCnt	= (Double)editRow[InventInputResult.ct_Col_InventoryTolerancCnt];   // 棚卸過不足数
            //else
            //    invEditWork.InventoryTolerancCnt	= 0;
            invEditWork.InventoryTolerancCnt = 0;
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //invEditWork.InventoryDate           = (Int32)editRow[InventInputResult.ct_Col_InventoryExeDay];         // 棚卸日
            invEditWork.InventoryDate = (DateTime)editRow[InventInputResult.ct_Col_InventoryExeDay_Datetime];         // 棚卸日
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            invEditWork.InventoryPreprDay = TDateTime.LongDateToDateTime((int)editRow[InventInputResult.ct_Col_InventoryPreprDay]);  // 棚卸準備処理日付
            invEditWork.InventoryPreprTim = (Int32)editRow[InventInputResult.ct_Col_InventoryPreprTim];       // 棚卸準備処理時間

            if (editRow[InventInputResult.ct_Col_InventoryDay] != DBNull.Value)
                invEditWork.InventoryDay = TDateTime.LongDateToDateTime((int)editRow[InventInputResult.ct_Col_InventoryDay]);  // 棚卸実施日
            else
                invEditWork.InventoryDay = DateTime.MinValue;

            invEditWork.LastInventoryUpdate = (DateTime)editRow[InventInputResult.ct_Col_LastInventoryUpdate];  // 最終棚卸更新日
            invEditWork.InventoryNewDiv = (Int32)editRow[InventInputResult.ct_Col_InventoryNewDiv];         // 棚卸新規追加区分
            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            invEditWork.StockMashinePrice = (Int64)editRow[InventInputResult.ct_Col_StockMashinePrice];       // マシン在庫額
            invEditWork.InventoryStockPrice = (Int64)editRow[InventInputResult.ct_Col_InventoryStockPrice];     // 棚卸在庫額
            invEditWork.InventoryTlrncPrice = (Int64)editRow[InventInputResult.ct_Col_InventoryTlrncPrice];     // 棚卸過不足金額
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
            invEditWork.Status = (Int32)editRow[InventInputResult.ct_Col_Status];  // ステータス	
            #endregion
            return status;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        // --- ADD 2014/12/04 Y.Wakita ---------->>>>>
        #region ◎ 行の文字色を変更
        /// <summary>
        /// RowForeColorChange
        /// </summary>
        /// <remarks>
        /// <br>Note		: 行が初期化されたときに発生する。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date        : 2014/12/04</br>
        /// </remarks>
        private void RowForeColorChange()
        {
            UltraGridRow activeRow = null;

            for (int index = 0; index < this.uGrid_InventInput.Rows.Count; index++)
            {
                activeRow = this.uGrid_InventInput.Rows[index];

                // 行の文字色を変更
                if ((int)activeRow.Cells[InventInputResult.ct_Col_Status].Value != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    activeRow.Appearance.ForeColor = Color.Red;
                }
                else if ((int)activeRow.Cells[InventInputResult.ct_Col_MoveStockCount].Value > 0)
                {
                    activeRow.Appearance.ForeColor = Color.Blue;
                }
                else
                {
                    activeRow.Appearance.ForeColor = Color.Black;
                }
            }
        }
        #endregion
        // --- ADD 2014/12/04 Y.Wakita ----------<<<<<

        #endregion ■ Private Method

        #region ■ Control Event

        #region ◎ MAZAI05130UB_Load
        /// <summary>
        /// MAZAI05130UB_Load
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがファイルを読み込むときに発生する</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private void MAZAI05130UB_Load(object sender, EventArgs e)
        {
            // 初期設定
            InitialLoadScreen();

            // 日付コントロールの背景色を強制的に変更
            this.tde_InventoryDate.BackColor = Color.Transparent;
            this.tde_InventoryExeDate.BackColor = Color.Transparent;
        }
        #endregion

        #region ◎ MAZAI05130UB_FormClosing
        /// <summary>
        /// MAZAI05130UB_FormClosing
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるときに発生する</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.04.27</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private void MAZAI05130UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            // グリッド設定保存
            if (this._gridStateController != null)
            {
                this._gridStateController.GetGridStateFromGrid(ref this.uGrid_InventInput);
                this._gridStateController.SaveGridState(ct_FileName_ColDisplayStatus);
            }

            if (this._productNumInput != null)
                this._productNumInput.Dispose();

            if (this._readBarcodeForm != null)					// バーコード読込画面
                this._readBarcodeForm.Dispose();

            if (this._createNewInventForm != null)					// 新規画面
                this._createNewInventForm.Dispose();

        }
        #endregion

        #region ◎ uGrid_InventInput_AfterPerformAction
        /// <summary>
        /// uGrid_InventInput_AfterPerformAction
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: AfterPerformActionイベントは、キーアクションのマッピングに関連付けられたアクションが実行された後に発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
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
                        // アクティブセルが有効
                        if (this.uGrid_InventInput.ActiveCell != null)
                        {
                            // 編集モードへ移行
                            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                        }

                        break;
                    }
            }
        }
        #endregion

        #region ◎ uGrid_InventInput_KeyDown
        /// <summary>
        /// uGrid_InventInput_KeyDown
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: コントロールにフォーカスがあるときにキーが押されると発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_KeyDown(object sender, KeyEventArgs e)
        {
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //KeyDownProc(sender, ref e);
            this._isDownKey = "ANYKEY";     //ADD 2009/05/14 不具合対応[13260]
            // 編集中の場合
            UltraGrid targetGrid = (UltraGrid)sender;
            if ((targetGrid.ActiveCell != null) && (targetGrid.ActiveCell.IsInEditMode == true))
            {
                // セルスタイルで判定
                switch (e.KeyData)
                {
                    case Keys.Up:	// ↑キー
                        {
                            targetGrid.PerformAction(UltraGridAction.AboveCell);

                            // アクティブになったセルを編集モードにする
                            if (targetGrid.ActiveCell != null)
                            {
                                if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            e.Handled = true;
                            break;
                        }
                    case Keys.Down:
                        {
                            targetGrid.PerformAction(UltraGridAction.BelowCell);

                            // アクティブになったセルを編集モードにする
                            if (targetGrid.ActiveCell != null)
                            {
                                if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                // 編集中なら何もしない
                                if (targetGrid.ActiveCell.IsInEditMode == true)
                                {
                                    if (targetGrid.ActiveCell.SelStart != 0)
                                    {
                                        return;
                                    }
                                }
                            }
                            targetGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            e.Handled = true;
                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                // 編集中なら何もしない
                                if (targetGrid.ActiveCell.IsInEditMode == true)
                                {
                                    if (targetGrid.ActiveCell.SelStart < targetGrid.ActiveCell.Text.Length)
                                    {
                                        return;
                                    }
                                }
                            }
                            targetGrid.PerformAction(UltraGridAction.NextCellByTab);
                            e.Handled = true;
                            break;
                        }
                    case Keys.Enter:
                        {
                            // EnterKeyが押されたときはTRetKeyContorolで制御される
                            // アクティブになったセルを編集モードにする
                            if (targetGrid.ActiveCell != null)
                            {
                                if (targetGrid.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            e.Handled = true;
                            break;
                        }
                    case Keys.Escape:	// ESCキー
                        {
                            UltraGridCell activeCell = this.uGrid_InventInput.ActiveCell;

                            // 棚卸数、棚卸更新日以外でESCが押されたとき
                            if (
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) != 0 ||
                                activeCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) != 0)
                            {
                                this._isChangeInventStcCnt = true;
                                this._isChangeInventDate = true;
                                this._isChangeWarehouseShelfNo = true;
                                this._isChangeDuplicationShelfNo1 = true;
                                this._isChangeDuplicationShelfNo2 = true;
                                this._isChangeStockUnitPrice = true;

                                activeCell = this.uGrid_InventInput.ActiveCell;

                                if (targetGrid.ActiveRow != null)
                                {
                                    targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                }

                                targetGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                            
                            UltraGridRow targetGridRow;
                            targetGridRow = targetGrid.ActiveCell.Row;
                            double bfInventStkCnt = 0;	// 変更前棚卸数

                            // 棚卸数
                            if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                            {
                                bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                            }
                            if ((targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value))
                            {
                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }

                                // 棚卸数
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                                {
                                    bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                                }

                                // InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt); //DEL yangyi 2013/03/01 Redmine#34175
                                InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                           //ADD yangyi 2013/03/01 Redmine#34175 

                                e.Handled = true;
                                break;
                            }

                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                            // 差異数
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                            // 棚卸日
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;

                            // InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt);      //DEL yangyi 2013/03/01 Redmine#34175
                            InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                                //ADD yangyi 2013/03/01 Redmine#34175 

                            targetGrid.ActiveCell = activeCell;
                            targetGrid.PerformAction(UltraGridAction.EnterEditMode);

                            e.Handled = true;
                            break;
                        }
                }
            }
            else
            {
                switch (e.KeyData)
                {
                    case Keys.Escape:	// ESCキー
                        {
                            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                            UltraGridRow targetGridRow;
                            targetGridRow = targetGrid.ActiveRow;
                            if (targetGrid.ActiveRow != null)
                            {
                                targetGridRow = targetGrid.ActiveRow;
                            }
                            else if (targetGrid.Selected.Rows[0] != null)
                            {
                                targetGridRow = targetGrid.Selected.Rows[0];
                            }
                            else
                            {
                                e.Handled = false;
                                break;
                            }
                            double bfInventStkCnt = 0;	// 変更前棚卸数
                            // 棚卸数
                            if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value)
                                bfInventStkCnt = (double)targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value;
                            if ((targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value))
                            {

                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                                targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;

                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }
                                if (targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value != DBNull.Value)
                                {
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                                    targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                                }

                                //InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt); //DEL yangyi 2013/03/01 Redmine#34175
                                InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                          //ADD yangyi 2013/03/01 Redmine#34175 
    
                                e.Handled = true;
                                break;
                            }

                            // 棚卸数
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                            // 差異数
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                            // 棚卸日
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                            targetGridRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;

                            //InventInitializeForESC((DataRow)targetGridRow.Cells[InventInputResult.ct_Col_RowSelf].Value, bfInventStkCnt);        //DEL yangyi 2013/03/01 Redmine#34175
                            InventInitializeForESC(GetBindDataRow(targetGridRow), bfInventStkCnt);                                                 //ADD yangyi 2013/03/01 Redmine#34175 

                            targetGrid.PerformAction(UltraGridAction.EnterEditMode);

                            e.Handled = true;
                            break;
                        }
                }
            }
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region ◎ uGrid_InventInput_KeyPress
        /// <summary>
        /// uGrid_InventInput_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //KeyPressProc(sender, ref e);

            //アクティブセル
            UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;

            // グロス区分
            //アクティブセルがあったら
            if (activeCell != null)
            {
                if (activeCell.IsInEditMode == false) return;

                switch (activeCell.Column.Key)
                {
                    case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
                        if (KeyPressCheck(9, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, true, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    case InventInputResult.ct_Col_InventoryDay_Year:	//棚卸日付年Edit
                        if (KeyPressCheck(4, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    case InventInputResult.ct_Col_InventoryDay_Month:	//棚卸日付月Edit
                    case InventInputResult.ct_Col_InventoryDay_Day:	    //棚卸日付日Edit
                        if (KeyPressCheck(2, 0, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    case InventInputResult.ct_Col_StockUnitPrice:       //仕入単価Edit
                        if (KeyPressCheck(11, 2, activeCell.Text, e.KeyChar, activeCell.SelStart, activeCell.SelLength, false, true) == false)
                        {
                            e.Handled = true;
                            return;
                        }
                        break;
                    // --- ADD 2009/04/13 -------------------------------->>>>>
                    case InventInputResult.ct_Col_WarehouseShelfNo:       //棚番
                    case InventInputResult.ct_Col_DuplicationShelfNo1:    //重複棚番1
                    case InventInputResult.ct_Col_DuplicationShelfNo2:    //重複棚番2
                        if (!Char.IsControl(e.KeyChar))
                        {
                            string prevStr = activeCell.Text;
                            string resultStr = prevStr.Substring(0, activeCell.SelStart) // 選択前の部分
                                             + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                             + prevStr.Substring(activeCell.SelStart + activeCell.SelLength, prevStr.Length - (activeCell.SelStart + activeCell.SelLength)); // 選択後の部分

                            Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                            int byteLength = sjis.GetByteCount(resultStr);

                            // 8バイト(半角8桁、全角4桁)まで入力可
                            if (byteLength > 8)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    // --- ADD 2009/04/13 --------------------------------<<<<<
                }
            }
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region ◎ uGrid_InventInput_CellDataError
        /// <summary>
        /// uGrid_InventInput_CellDataError
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 不正な値が入力された状態でセルを更新しようとすると発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            // アクティブセルが有効
            if (this.uGrid_InventInput.ActiveCell != null)
            {
                // NetAdvantage 不具合のためのロジック

                // 現在のセルを取得
                UltraGridCell currentCell = this.uGrid_InventInput.ActiveCell;

                // 現在のアクティブセルのスタイルがEditの場合
                if (currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // 変更された結果、Textが空白となった場合
                    if ((currentCell.Text == null) || (currentCell.Text.TrimEnd() == ""))
                    {
                        // 現在のセルの型が、Int32、Int64、double型の場合
                        if ((currentCell.Column.DataType == typeof(Int32)) ||
                            (currentCell.Column.DataType == typeof(Int64)) ||
                            (currentCell.Column.DataType == typeof(double)))
                        {
                            // 値を空白とはせずに、"0"をセットする
                            currentCell.Value = 0;
                            // 値を空白とせずに0をセットする
                            e.RaiseErrorEvent = false;
                            e.RestoreOriginalValue = true;
                            e.StayInEditMode = true;

                        }
                    }
                }
            }
        }
        #endregion

        #region ◎ uGrid_InventInput_Enter
        /// <summary>
        /// uGrid_InventInput_Enter
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: コントロールが入力されると発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_InventInput.ActiveCell == null)
            {
                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion

        #region ◎ uGrid_InventInput_CellChange
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_CellChange
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 編集モードにあるセルの値をユーザーが変更したときに発生する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void uGrid_InventInput_CellChange(object sender, CellEventArgs e)
        {
            // アクティブセルが有効
            if (this.uGrid_InventInput.ActiveCell != null)
            {
                // NetAdvantage 不具合のためのロジック

                // 現在のセルを取得
                UltraGridCell currentCell = this.uGrid_InventInput.ActiveCell;

                // 現在のアクティブセルのスタイルがEditの場合
                if (currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // 変更された結果、Textが空白となった場合
                    if ((currentCell.Text == null) || (currentCell.Text.TrimEnd() == ""))
                    {
                        // 現在のセルの型が、Int32、Int64、double型の場合
                        if ((e.Cell.Column.DataType == typeof(Int32)) ||
                            (e.Cell.Column.DataType == typeof(Int64)) ||
                            (e.Cell.Column.DataType == typeof(double)))
                        {
                            // 値を空白とはせずに、"0"をセットする
                            e.Cell.Value = 0;
                        }
                    }
                }

                // 棚卸数が変更されている場合に変更フラグをTrueにする
                if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0)
                {
                    this._isChangeInventStcCnt = true;
                    //this._isChangeInventDate = false;
                }
                // 棚卸日が変更されている場合には変更フラグをTrueにする
                else if ((currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                         (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
                         (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                {
                    this._isChangeInventDate = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    this._isChangeWarehouseShelfNo = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    this._isChangeDuplicationShelfNo1 = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    this._isChangeDuplicationShelfNo2 = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    this._isChangeStockUnitPrice = true;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_CellChange
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 編集モードにあるセルの値をユーザーが変更したときに発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date       : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_CellChange(object sender, CellEventArgs e)
        {
            // アクティブセルが有効
            if (this.uGrid_InventInput.ActiveCell != null)
            {
                // NetAdvantage 不具合のためのロジック

                // 現在のセルを取得
                UltraGridCell currentCell = this.uGrid_InventInput.ActiveCell;

                // 現在のアクティブセルのスタイルがEditの場合
                if (currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                {
                    // 変更された結果、Textが空白となった場合
                    if ((currentCell.Text == null) || (currentCell.Text.TrimEnd() == ""))
                    {
                        // 現在のセルの型が、Int32、Int64、double型の場合
                        if ((e.Cell.Column.DataType == typeof(Int32)) ||
                            (e.Cell.Column.DataType == typeof(Int64)) ||
                            (e.Cell.Column.DataType == typeof(double)))
                        {
                            // 値を空白とはせずに、"0"をセットする
                            e.Cell.Value = 0;
                        }
                    }
                }

                // 棚卸数が変更されている場合に変更フラグをTrueにする
                if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0)
                {
                    this._isChangeInventStcCnt = true;
                    //this._isChangeInventDate = false;
                }
                // 棚卸日が変更されている場合には変更フラグをTrueにする
                else if ((currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                    (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Month) == 0) ||
                    (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                {
                    this._isChangeInventDate = true;
                    //this._isChangeInventStcCnt = false;
                }
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_ProductNumber) == 0)
                //{
                //	this._isChangeInventProductNum = true;
                //}
                //else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockTelNo1) == 0)
                //{
                //	this._isChangeInventStockTelNo1 = true;
                //}
                //else if ( currentCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo1 ) == 0 )
                //{
                //	this._isChangeInventStockTelNo2 = true;
                //}
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_WarehouseShelfNo) == 0)
                {
                    this._isChangeWarehouseShelfNo = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo1) == 0)
                {
                    this._isChangeDuplicationShelfNo1 = true;
                }
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_DuplicationShelfNo2) == 0)
                {
                    this._isChangeDuplicationShelfNo2 = true;
                }
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                else if (currentCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_StockUnitPrice) == 0)
                {
                    this._isChangeStockUnitPrice = true;
                }
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ uGrid_InventInput_InitializeRow
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_InitializeRow
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 行が初期化されたときに発生する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void uGrid_InventInput_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            //DataRow targetRow = (DataRow)e.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;       //DEL yangyi 2013/03/01 Redmine#34175
            DataRow targetRow = GetBindDataRow(e.Row);                                                //ADD yangyi 2013/03/01 Redmine#34175

            // 文字色設定

            // 初期値表示判断
            if ((e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value != DBNull.Value))
            {
                if (((DateTime)e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value == DateTime.MinValue) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == 0) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value == 0))
                {
                    e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                }
            }

            // 行の文字色を変更
            if ((int)e.Row.Cells[InventInputResult.ct_Col_Status].Value != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                e.Row.Appearance.ForeColor = Color.Red;
            }
            else if ((int)e.Row.Cells[InventInputResult.ct_Col_MoveStockCount].Value > 0)
            {
                e.Row.Appearance.ForeColor = Color.Blue;
            }
            else
            {
                e.Row.Appearance.ForeColor = Color.Black;
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_InitializeRow
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 行が初期化されたときに発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            DataRow targetRow = (DataRow)e.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;

            // 文字色設定

            // TODO
            #region // 2007.07.19 kubo del -------------------------->
            //// 子データ取得
            //DataView childDv = 
            //    new DataView( 
            //        this._inventInputAcs.InventDataTable, 
            //        MakeParentOrChildRowGetQuery(
            //            MakeDictionary( (int)InventInputSearchCndtn.GrossDivState.Product , targetRow ), 
            //            (int)InventInputSearchCndtn.ViewState.View ),
            //        string.Format( "{0}, {1}", InventInputResult.ct_Col_InventoryNewDiv, InventInputResult.ct_Col_ProductNumber ),
            //        DataViewRowState.CurrentRows);


            //// 製番在庫詳細画面表示ボタンのEnabled制御
            //if ( (int)targetRow[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Goods )
            //{
            //    // Rowが商品毎の場合
            //    // 製番管理有無を見る
            //    if ( (int)targetRow[InventInputResult.ct_Col_PrdNumMngDiv] == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
            //    {
            //        // 1レコードしかなかったら非表示(どれに展開するかを選択する必要が無いから)
            //        if ( childDv.Count == 1 )
            //        {
            //            e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.Disabled;
            //        }
            //        else
            //        {
            //            e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.ActivateOnly;
            //        }
            //    }
            //    else
            //    {
            //        e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.Disabled;
            //    }
            //}
            //else
            //{
            //    // Rowが製番毎の場合
            //    e.Row.Cells[InventInputResult.ct_Col_Button].Activation = Activation.Disabled;
            //}
            #endregion // 2007.07.19 kubo del <--------------------------

            // 初期値表示判断
            if ((e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value != DBNull.Value) &&
                (e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value != DBNull.Value))
            {
                if (((DateTime)e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value == DateTime.MinValue) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value == 0) &&
                    ((double)e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value == 0))
                {
                    e.Row.Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryTolerancCnt].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Datetime].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Year].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Month].Value = DBNull.Value;
                    e.Row.Cells[InventInputResult.ct_Col_InventoryDay_Day].Value = DBNull.Value;
                }
            }

            // 行の文字色を変更
            ChangeRowColor(e.Row);
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ uGrid_InventInput_AfterExitEditMode
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterExitEditMode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが編集モードを終了したときに発生する。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date        : 2008/09/01</br>
        /// </remarks>
        private void uGrid_InventInput_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;

            if (activeCell == null) return;

            try
            {
                bool isShowProduct = true;

                // セル変更時処理
                if (activeCell.Text.Trim() == "")
                {
                    this._isChangeInventStcCnt = true;
                }

                // ---ADD 2009/05/14 不具合対応[13260] ----------->>>>>
                // マウスクリックで抜けた時、更新はしない
                if (string.IsNullOrEmpty(this._isDownKey))
                {
                    if (string.IsNullOrEmpty(activeCell.Text.Trim()))
                    {
                        this._isChangeInventStcCnt = false;
                    }
                    else
                    {
                        this._isChangeInventStcCnt = true;
                    }
                }
                // ---ADD 2009/05/14 不具合対応[13260] -----------<<<<<

                AfterExitEditModeProc(activeCell, sender, this._isChangeInventStcCnt, this._isChangeInventDate, isShowProduct);
            }
            finally
            {
                this.uGrid_InventInput.Refresh();

                this._isChangeInventStcCnt = false;
                this._isChangeInventDate = false;
                this._isChangeWarehouseShelfNo = false;
                this._isChangeDuplicationShelfNo1 = false;
                this._isChangeDuplicationShelfNo2 = false;
                this._isChangeStockUnitPrice = false;
                this._isDownKey = string.Empty;      //ADD 2009/05/14 不具合対応[13260]
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterExitEditMode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セルが編集モードを終了したときに発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.04.11</br>
        /// </remarks>
        private void uGrid_InventInput_AfterExitEditMode(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell activeCell = ((UltraGrid)sender).ActiveCell;

            if (activeCell == null) return;

            try
            {
                bool isShowProduct = true;
                AfterExitEditModeProc(activeCell, sender, this._isChangeInventStcCnt, this._isChangeInventDate, isShowProduct);
                //ChangeViewStyle();
            }
            finally
            {
                // todo:
                this.uGrid_InventInput.Refresh();	// 2007.07.19 kubo add
                #region // 2007.07.19 kubo del
                // this.uGrid_InventInput.UpdateData();	// グリッドを更新
                //this.uGrid_InventInput.UpdateMode = UpdateMode.OnCellChange;
                #endregion
                this._isChangeInventStcCnt = false;
                this._isChangeInventDate = false;
                // 2007.07.26 kubo del ------------->
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //this._isChangeInventProductNum = false;
                //this._isChangeInventStockTelNo1 = false;
                //this._isChangeInventStockTelNo2 = false;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.07.26 kubo del <-------------
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                this._isChangeWarehouseShelfNo = false;
                this._isChangeDuplicationShelfNo1 = false;
                this._isChangeDuplicationShelfNo2 = false;
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                this._isChangeStockUnitPrice = false;
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            }

        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◎ uGrid_InventInput_BeforeEnterEditMode
        /// <summary>
        /// uGrid_InventInput_BeforeEnterEditMode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 行がアクティブになる前に発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>Date        : 2007.07.26</br>
        /// </remarks>
        private void uGrid_InventInput_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //UltraGrid targetGrid = (UltraGrid)sender;
            //
            //// セルをアクティブにする
            //if (targetGrid.ActiveCell == null )
            //	targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
            //
            //if ( targetGrid.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo1 ) == 0 )
            //{
            //	if ( targetGrid.ActiveCell.Value != DBNull.Value )
            //		this._BfoerStockTelNo1 = targetGrid.ActiveCell.Value.ToString().TrimEnd();
            //	else
            //		this._BfoerStockTelNo1 = "";
            //}
            //else if ( targetGrid.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_StockTelNo2 ) == 0 )
            //{
            //	if ( targetGrid.ActiveCell.Value != DBNull.Value )
            //		this._BfoerStockTelNo2 = targetGrid.ActiveCell.Value.ToString().TrimEnd();
            //	else
            //		this._BfoerStockTelNo2 = "";
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

        }
        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ uGrid_InventInput_AfterCellActivate
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterCellActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_AfterCellActivate(object sender, EventArgs e)
        {
            UltraGrid targetGrid = (UltraGrid)sender;

            // セルをアクティブにする
            if (targetGrid.ActiveCell == null)
            {
                targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
            }

            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
            //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

            if ((targetGrid.ActiveCell != null) &&
                (targetGrid.ActiveCell.Activation == Activation.AllowEdit))
            {
                // 編集モードにする
                targetGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_AfterCellActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_AfterCellActivate(object sender, EventArgs e)
        {
            UltraGrid targetGrid = (UltraGrid)sender;

            // セルをアクティブにする

            if (targetGrid.ActiveCell == null)
                targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

            // 2007.07.25 kubo add ------------->
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番編集許可判断
            //// 製番毎表示かつ製番管理データかつ新規データか？
            //if ( (int)this.tce_ViewStyle.SelectedItem.DataValue == (int)InventInputSearchCndtn.ViewStyleState.Product &&
            //	 (int)targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_PrdNumMngDiv].Value  == (int)InventInputSearchCndtn.PrdNumMngDivState.Product &&
            //	 (int)targetGrid.ActiveRow.Cells[InventInputResult.ct_Col_InventoryNewDiv].Value  == (int)InventInputSearchCndtn.NewRowState.New )
            //{
            //    // 製造番号
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_ProductNumber );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.AllowEdit, InventInputResult.ct_Col_ProductNumber );
            //	// 電話番号1
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo1 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo1 );
            //	// 電話番号2
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.EditAndSelectText, InventInputResult.ct_Col_StockTelNo2 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.AllowEdit, InventInputResult.ct_Col_StockTelNo2 );
            //}
            //else
            //{
            //	// 製造番号
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_ProductNumber );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.NoEdit, InventInputResult.ct_Col_ProductNumber );
            //	// 電話番号1
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo1 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo1 );
            //	// 電話番号2
            //	SetCellActivation( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, CellClickAction.CellSelect, InventInputResult.ct_Col_StockTelNo2 );
            //	SetCellClickAction( targetGrid.DisplayLayout.Bands[ InventInputResult.ct_Tbl_InventInput ].Columns, Activation.NoEdit, InventInputResult.ct_Col_StockTelNo2 );
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.07.25 kubo add <-------------



            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
            this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            if ((targetGrid.ActiveCell != null) &&
                (targetGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
            {
                // 編集モードにする
                targetGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region ◎ uGrid_InventInput_ClickCellButton Event
        /// <summary>
        /// uGrid_InventInput_ClickCellButton Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_ClickCellButton(object sender, CellEventArgs e)
        {
            // ガイドボタンがクリックされたか
            DataRow targetDr;
            if (e.Cell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_Button) == 0)
            {
                targetDr = (DataRow)e.Cell.Row.Cells[InventInputResult.ct_Col_RowSelf].Value;

                //ShowSelcetProduct( ref targetDr );
            }
        }
        #endregion

        #region ◎ uGrid_InventInput_MouseEnterElement
        /// <summary>
        /// uGrid_InventInput_MouseEnterElement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseEnterElement(object sender, UIElementEventArgs e)
        {
            //// 在庫部品情報をポップアップ表示
            //Infragistics.Win.UIElement element = e.Element;

            //// Rouを取得
            //object objRow = element.GetContext(typeof(UltraGridRow));
            //if (objRow != null)
            //{
            //    // Rowがnullではない場合ツールチップに表示する情報を表示する。
            //    UltraGridRow row = (UltraGridRow)objRow;

            //    StringBuilder tipString = new StringBuilder();

            //    if (row.Cells[ InventInputResult.ct_Col_RowSelf ].Value != null)
            //    {
            //        DataRow targetRow = (DataRow)row.Cells[ InventInputResult.ct_Col_RowSelf ].Value;
            //        // エラーの表示
            //        if ( (int)targetRow[InventInputResult.ct_Col_Status] != 0 )
            //        {
            //            tipString.Append( "エラー --------------------" );
            //            tipString.Append( "\r\n" );
            //            tipString.Append( string.Format( "    {0}", targetRow[InventInputResult.ct_Col_StatusDetail].ToString()) );
            //            tipString.Append("\r\n\r\n");
            //        }


            //        // 変更点の表示
            //        if ( CheckChangeData( targetRow ) == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //        {
            //            tipString.Append( "変更点 --------------------" );
            //            tipString.Append( "\r\n" );
            //            // 電話番号1、2、製番、棚卸数のいずれかが変更されていたら表示
            //            // 電話番号1が変わっている場合
            //            if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo1ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //            {
            //                tipString.Append( string.Format( "    {0}", "電話番号1が変更されています" ) );
            //                tipString.Append("\r\n");
            //            }

            //            // 電話番号2が変わっている場合
            //            if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo2ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //            {
            //                tipString.Append( string.Format( "    {0}", "電話番号2が変更されています" ));
            //                tipString.Append("\r\n");
            //            }
            //            // 仕入単価が変更されている場合
            //            if ( (int)targetRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
            //            {
            //                tipString.Append( string.Format( "    {0}", "電話番号1が変更されています" ));
            //                tipString.Append("\r\n");
            //            }
            //            //// 棚卸数が変わっている場合
            //            //if ( (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt] == (double)dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] )
            //            //{
            //            //    tipString.Append( "棚卸数が変更されています" );
            //            //    tipString.Append("\r\n");
            //            //}
            //        }

            //        // 移動在庫数の表示
            //        if ( (int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0 )
            //        {
            //            tipString.Append( "移動在庫数 --------------------" );
            //            tipString.Append( "\r\n" );
            //            tipString.Append( string.Format( "    移動在庫数 ： {0}", (int)targetRow[InventInputResult.ct_Col_MoveStockCount] ));
            //            tipString.Append("\r\n");
            //        }
            //    }

            //    // 表示する内容があるときだけ
            //    if ( tipString.ToString() != "" )
            //    {
            //        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            //        ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            //        ultraToolTipInfo.ToolTipTitle = "棚卸情報";
            //        ultraToolTipInfo.ToolTipText = tipString.ToString();

            //        this.uttm_ViewGridInfoToolTip.Appearance.FontData.Name = "ＭＳ ゴシック";
            //        this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, ultraToolTipInfo);
            //        this.uttm_ViewGridInfoToolTip.Enabled = true;
            //    }
            //    else
            //    {
            //        this.uttm_ViewGridInfoToolTip.Enabled = false;
            //    }
            //}
        }
        /// <summary>
        /// セル情報取得(String)
        /// </summary>
        /// <param name="row">対象行</param>
        /// <param name="key">Key</param>
        /// <returns>セル情報</returns>
        private string GetStringForTip(UltraGridRow row, string key)
        {
            return string.Format("{0}：{1}",
                this.uGrid_InventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput].Columns[key].Header.Caption.PadRight(9, '　'),
                row.Cells[key].Value.ToString());
        }

        #endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◎ uGrid_InventInput_MouseLeaveElement
        /// <summary>
        /// uGrid_InventInput_MouseLeaveElement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            this.uttm_ViewGridInfoToolTip.Enabled = false;	// ツールチップ非表示
            this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, null);
        }
        #endregion

        #region ◎ uGrid_InventInput_MouseClick
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseClick(object sender, MouseEventArgs e)
        {
            // エレメントを取得
            UIElement uiElement = this.uGrid_InventInput.DisplayLayout.UIElement.ElementFromPoint(e.Location);

            // Rowを取得
            UltraGridRow row = uiElement.GetContext(typeof(UltraGridRow)) as UltraGridRow;

            if (row != null)
            {
                // Rowがnullではない場合ツールチップに表示する情報を表示する。
                StringBuilder tipString = new StringBuilder();

                //if (row.Cells[InventInputResult.ct_Col_RowSelf].Value != null)   //DEL yangyi 2013/03/01 Redmine#34175
                if (GetBindDataRow(row) != null)                                   //ADD yangyi 2013/03/01 Redmine#34175 
                {
                    // DataRow targetRow = (DataRow)row.Cells[InventInputResult.ct_Col_RowSelf].Value;    //DEL yangyi 2013/03/01 Redmine#34175
                    DataRow targetRow = GetBindDataRow(row);                                              //ADD yangyi 2013/03/01 Redmine#34175 
                    // エラーの表示
                    if ((int)targetRow[InventInputResult.ct_Col_Status] != 0)
                    {
                        tipString.Append("エラー --------------------");
                        tipString.Append(string.Format("\r\n    {0}", targetRow[InventInputResult.ct_Col_StatusDetail].ToString()));
                        tipString.Append("\r\n\r\n");
                    }

                    // 変更点の表示
                    if ((int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0)
                    {
                        StringBuilder changeString = new StringBuilder();

                        // 仕入単価が変更されている場合
                        if ((int)targetRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                        {
                            changeString.Append(string.Format("\r\n    {0}", "仕入単価が変更されています"));
                        }

                        if (changeString.ToString().TrimEnd() != "")
                        {
                            tipString.Append("変更点 --------------------");
                            tipString.Append(changeString.ToString());
                            tipString.Append("\r\n\r\n");
                        }
                        // 移動在庫数の表示
                        if ((int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0)
                        {
                            tipString.Append("移動中在庫数 ----------------");
                            tipString.Append(string.Format("\r\n    移動中在庫数 ： {0}", (int)targetRow[InventInputResult.ct_Col_MoveStockCount]));
                        }
                    }
                }

                // 表示する内容があるときだけ
                if (tipString.ToString().TrimEnd() != "")
                {
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
                    ultraToolTipInfo.ToolTipTitle = "棚卸情報";
                    ultraToolTipInfo.ToolTipText = "　\r\n" + tipString.ToString() + "\r\n　";

                    this.uttm_ViewGridInfoToolTip.Appearance.FontData.Name = "ＭＳ ゴシック";
                    this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, ultraToolTipInfo);
                    this.uttm_ViewGridInfoToolTip.Enabled = true;
                }
                else
                {
                    this.uttm_ViewGridInfoToolTip.Enabled = false;
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// uGrid_InventInput_MouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_MouseClick(object sender, MouseEventArgs e)
        {
            //// 在庫部品情報をポップアップ表示

            // エレメントを取得
            UIElement uiElement = this.uGrid_InventInput.DisplayLayout.UIElement.ElementFromPoint(e.Location);

            // Rowを取得
            UltraGridRow row = uiElement.GetContext(typeof(UltraGridRow)) as UltraGridRow;

            if (row != null)
            {
                // Rowがnullではない場合ツールチップに表示する情報を表示する。
                StringBuilder tipString = new StringBuilder();

                if (row.Cells[InventInputResult.ct_Col_RowSelf].Value != null)
                {
                    DataRow targetRow = (DataRow)row.Cells[InventInputResult.ct_Col_RowSelf].Value;
                    // エラーの表示
                    if ((int)targetRow[InventInputResult.ct_Col_Status] != 0)
                    {
                        tipString.Append("エラー --------------------");
                        tipString.Append(string.Format("\r\n    {0}", targetRow[InventInputResult.ct_Col_StatusDetail].ToString()));
                        tipString.Append("\r\n\r\n");
                    }


                    // 変更点の表示
                    if (CheckChangeData(targetRow) == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                    {
                        StringBuilder changeString = new StringBuilder();
                        // 電話番号1、2、製番、棚卸数のいずれかが変更されていたら表示
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //// 電話番号1が変わっている場合
                        //if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo1ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
                        //{
                        //	changeString.Append( string.Format( "\r\n    {0}", "電話番号1が変更されています" ) );
                        //}
                        //	
                        //// 電話番号2が変わっている場合
                        //if ( (int)targetRow[InventInputResult.ct_Col_StkTelNo2ChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change )
                        //{
                        //	changeString.Append( string.Format( "\r\n    {0}", "電話番号2が変更されています" ));
                        //}
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        // 仕入単価が変更されている場合
                        if ((int)targetRow[InventInputResult.ct_Col_StkUnitPriceChgFlg] == (int)InventInputSearchCndtn.ChangeFlagState.Change)
                        {
                            changeString.Append(string.Format("\r\n    {0}", "仕入単価が変更されています"));
                        }

                        if (changeString.ToString().TrimEnd() != "")
                        {
                            tipString.Append("変更点 --------------------");
                            tipString.Append(changeString.ToString());
                            tipString.Append("\r\n\r\n");
                        }
                        // 移動在庫数の表示
                        if ((int)targetRow[InventInputResult.ct_Col_MoveStockCount] > 0)
                        {
                            tipString.Append("移動中在庫数 ----------------");
                            tipString.Append(string.Format("\r\n    移動中在庫数 ： {0}", (int)targetRow[InventInputResult.ct_Col_MoveStockCount]));
                        }
                        //// 棚卸数が変わっている場合
                        //if ( (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt] == (double)dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] )
                        //{
                        //    tipString.Append( "棚卸数が変更されています" );
                        //    tipString.Append("\r\n");
                        //}
                    }
                }

                // 表示する内容があるときだけ
                if (tipString.ToString().TrimEnd() != "")
                {
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
                    ultraToolTipInfo.ToolTipTitle = "棚卸情報";
                    ultraToolTipInfo.ToolTipText = "　\r\n" + tipString.ToString() + "\r\n　";

                    this.uttm_ViewGridInfoToolTip.Appearance.FontData.Name = "ＭＳ ゴシック";
                    this.uttm_ViewGridInfoToolTip.SetUltraToolTip(this.uGrid_InventInput, ultraToolTipInfo);
                    this.uttm_ViewGridInfoToolTip.Enabled = true;
                }
                else
                {
                    this.uttm_ViewGridInfoToolTip.Enabled = false;
                }
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ uGrid_InventInput_AfterRowActivate
        /// <summary>
        /// uGrid_InventInput_AfterRowActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_InventInput_AfterRowActivate(object sender, EventArgs e)
        {
            // 2007.07.25 kubo add ------------------------>
            if (ParentToolbarInventSettingEvent != null)
            {
                // 修正ボタンのEnableを判断
                if (this.uGrid_InventInput.ActiveRow != null)
                {
                    if ((int)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryNewDiv].Value ==
                        (int)InventInputSearchCndtn.NewRowState.New)
                    {
                        this._isDataEdit = true;
                    }
                    else
                    {
                        this._isDataEdit = false;
                    }

                    ParentToolbarInventSettingEvent(this);
                }
            }
            // 2007.07.25 kubo add <------------------------

            // --- DEL 2009/02/06 障害ID:10994対応------------------------------------------------------>>>>>
            //// 2007.07.24 kubo add ------------------------>
            //if (this.uGrid_InventInput.ActiveRow != null)
            //{
            //    // 削除ボタンのEnabled設定
            //    if ((int)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryNewDiv].Value == (int)InventInputSearchCndtn.NewRowState.New)
            //    {
            //        this.ub_RowDelete.Enabled = true;
            //    }
            //    else
            //    {
            //        this.ub_RowDelete.Enabled = false;
            //    }
            //}
            //// 2007.07.24 kubo add <------------------------
            // --- DEL 2009/02/06 障害ID:10994対応------------------------------------------------------<<<<<

            // 文字色設定
            this.uGrid_InventInput.DisplayLayout.Override.ActiveRowAppearance.ForeColor = this.uGrid_InventInput.ActiveRow.Appearance.ForeColor;
        }
        #endregion

        //#region ◎ uGrid_InventInput_AfterSelectChange
        ///// <summary>
        ///// uGrid_InventInput_AfterSelectChange
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uGrid_InventInput_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        //{
        //    if (this.uGrid_InventInput.ActiveRow == null) return;

        //    if (uGrid_InventInput.Selected.Rows.Count > 1)
        //    {
        //        this.uGrid_InventInput.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
        //    }
        //    else
        //    {
        //        this.uGrid_InventInput.DisplayLayout.Override.ActiveRowAppearance.ForeColor = this.uGrid_InventInput.ActiveRow.Appearance.ForeColor;
        //    }
        //}
        //#endregion

        #region ◎ tce_ViewStyle_ValueChanged
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tce_ViewStyle_ValueChanged
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tce_ViewStyle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.uGrid_InventInput.BeginUpdate();

                DataRow lastRow;
                if (this.uGrid_InventInput.ActiveRow != null)
                    lastRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;
                else
                    lastRow = null;

                ChangeViewStyle();
                if (this.uGrid_InventInput.Rows.Count > 0)
                {
                    // 前回表示状態で選択されていた行に関連する行を選択
                    // 倉庫, メーカー, 品番, 在庫区分, 仕入単価, 仕入先コード, 委託先コード, 事業者コードが
                    // 一致していたらその行を選択する

                    //UltraGridRow activeGridRow = null;

                    if (lastRow == null)
                    {
                        this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                        //activeGridRow = this.uGrid_InventInput.Rows[0];
                    }
                    else
                    {
                        for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                        {
                            if (
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd() ==	// 倉庫
                                  lastRow[InventInputResult.ct_Col_WarehouseCode].ToString().TrimEnd()) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value == // メーカー
                                  (int)lastRow[InventInputResult.ct_Col_MakerCode]) &&
                                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                                //( this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsCode].Value.ToString().TrimEnd() == // 品番
                                //  lastRow[InventInputResult.ct_Col_GoodsCode].ToString().TrimEnd()) &&
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd() == // 品番
                                  lastRow[InventInputResult.ct_Col_GoodsNo].ToString().TrimEnd()) &&
                                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockTrtEntDiv].Value == // 委託受託区分
                                  (int)lastRow[InventInputResult.ct_Col_StockTrtEntDiv]) &&
                                // 2008.02.14 削除 >>>>>>>>>>>>>>>>>>>>
                                //( (long)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockUnitPrice].Value == // 原単価
                                //  (long)lastRow[InventInputResult.ct_Col_StockUnitPrice] ) &&
                                // 2008.02.14 削除 <<<<<<<<<<<<<<<<<<<<
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CustomerCode].Value == // 仕入先コード
                                  (int)lastRow[InventInputResult.ct_Col_CustomerCode]) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_ShipCustomerCode].Value == // 委託先コード
                                  (int)lastRow[InventInputResult.ct_Col_ShipCustomerCode]) //&&
                                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                                //((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_CarrierEpCode].Value == // 事業者
                                //  (int)lastRow[InventInputResult.ct_Col_CarrierEpCode] ) //&&
                                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                                //( (int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryNewDiv].Value == // 新規区分
                                //  (int)lastRow[InventInputResult.ct_Col_InventoryNewDiv] )
                            )
                            {
                                if (this.uGrid_InventInput.ActiveRow == null)
                                    this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;

                                this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);

                            }
                        }
                    }
                    //// スクロール
                    this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.ActiveRow;

                    //if ( activeGridRow != null )
                    //    activeGridRow.Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                    //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.None;
                    //this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.None;

                }
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tce_ViewStyle_ValueChanged
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tce_ViewStyle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.uGrid_InventInput.BeginUpdate();

                DataRow lastRow;
                if (this.uGrid_InventInput.ActiveRow != null)
                    //lastRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;  //DEL yangyi 2013/03/01 Redmine#34175
                    lastRow = GetBindDataRow(this.uGrid_InventInput.ActiveRow);                                           //ADD yangyi 2013/03/01 Redmine#34175 
                else
                    lastRow = null;

                ChangeViewStyle();
                if (this.uGrid_InventInput.Rows.Count > 0)
                {
                    // 前回表示状態で選択されていた行に関連する行を選択
                    // 倉庫, メーカー, 品番, 在庫区分, 仕入単価, 仕入先コード, 委託先コード, 事業者コードが
                    // 一致していたらその行を選択する

                    if (lastRow == null)
                    {
                        this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                    }
                    else
                    {
                        for (int gridIndex = 0; gridIndex < this.uGrid_InventInput.Rows.Count; gridIndex++)
                        {
                            if (
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_WarehouseCode].Value.ToString().TrimEnd() ==	// 倉庫
                                  lastRow[InventInputResult.ct_Col_WarehouseCode].ToString().TrimEnd()) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_MakerCode].Value == // メーカー
                                  (int)lastRow[InventInputResult.ct_Col_MakerCode]) &&
                                (this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_GoodsNo].Value.ToString().TrimEnd() == // 品番
                                  lastRow[InventInputResult.ct_Col_GoodsNo].ToString().TrimEnd()) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_StockTrtEntDiv].Value == // 委託受託区分
                                  (int)lastRow[InventInputResult.ct_Col_StockTrtEntDiv]) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_SupplierCode].Value == // 仕入先コード
                                  (int)lastRow[InventInputResult.ct_Col_SupplierCode]) &&
                                ((int)this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_ShipCustomerCode].Value == // 委託先コード
                                  (int)lastRow[InventInputResult.ct_Col_ShipCustomerCode]) //&&
                            )
                            {
                                if (this.uGrid_InventInput.ActiveRow == null)
                                    this.uGrid_InventInput.Rows[gridIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();

                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeCell = SelectType.Extended;
                                this.uGrid_InventInput.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;

                                this.uGrid_InventInput.Selected.Rows.Add(this.uGrid_InventInput.Rows[gridIndex]);

                            }
                        }
                    }
                    // スクロール
                    this.uGrid_InventInput.DisplayLayout.RowScrollRegions[0].FirstRow = this.uGrid_InventInput.ActiveRow;
                }
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

        #region ◎ tce_SortOrder_ValueChanged
        /// <summary>
        /// tce_SortOrder_ValueChanged
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tce_SortOrder_ValueChanged(object sender, EventArgs e)
        {
            // Grid表示状態変更
            ChangeViewStyle();

            if (this.uGrid_InventInput.Rows.Count > 0)
            {
                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
            }
        }
        #endregion

        #region ◎ tRetKeyControl_ChangeFocus
        ///// <summary>
        ///// tRetKeyControl_ChangeFocus Event
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : フォーカスが遷移する場合に発生する。</br>
        ///// <br>Programmer	: 22013 kubo</br>
        ///// <br>date		: 2007.04.17</br>
        ///// </remarks>
        //private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        //{
        //    if ((e.PrevCtrl == null) ||
        //        (e.NextCtrl == null))
        //    {
        //        return;
        //    }

        //    // 抽出結果グリッドの場合
        //    if (e.PrevCtrl.Equals(this.uGrid_InventInput) == true)
        //    {
        //        // アクティブセルが有効
        //        if (this.uGrid_InventInput.ActiveCell != null)
        //        {
        //            int rowIndex = this.uGrid_InventInput.ActiveCell.Row.Index;

        //            // 入力されたキーで判定
        //            // Enterキー
        //            if (((e.Key == Keys.Enter) || (e.Key == Keys.Tab)) &&
        //                ((e.ShiftKey == false) && (e.ControlKey == false) && (e.AltKey == false)))
        //            {
        //                switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                {
        //                    // 棚卸数
        //                    case InventInputResult.ct_Col_InventoryStockCnt:
        //                        this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //                        break;
        //                    // 年
        //                    case InventInputResult.ct_Col_InventoryDay_Year:
        //                        this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //                        break;
        //                    // 月
        //                    case InventInputResult.ct_Col_InventoryDay_Month:
        //                        this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //                        break;
        //                    // 日
        //                    case InventInputResult.ct_Col_InventoryDay_Day:	
        //                        // 年をアクティブにしてから下に移動
        //                        if (this.uGrid_InventInput.ActiveRow != null)
        //                        {
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                        }
        //                        break;
        //                    default:
        //                        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                        break;
        //                }

        //                if (this.uGrid_InventInput.ActiveRow.Index == this.uGrid_InventInput.Rows.Count - 1)
        //                {
        //                    // 最終行の棚卸数か、ボタンだったらカラムサイズコンボボックスに移動
        //                    if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0) ||
        //                        (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
        //                    {
        //                        e.NextCtrl = null;
        //                    }
        //                    else
        //                    {
        //                        //// 次のセルへ移動
        //                        // キーが押されたときのActiveCellによって動作を変える
        //                        switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                        {
        //                            case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// 下に移動
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Year:	// 年
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// 右に移動
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Month:	// 月
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// 右に移動
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Day:	// 日
        //                                // 年をアクティブにしてから下に移動
        //                                if (this.uGrid_InventInput.ActiveRow != null)
        //                                {
        //                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                                    this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                                }
        //                                break;
        //                            default:
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                                break;
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                    //// 次のセルへ移動
        //                    // キーが押されたときのActiveCellによって動作を変える
        //                    switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                    {
        //                        case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// 下に移動
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Year:	// 年
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// 右に移動
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Month:	// 月
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// 右に移動
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Day:	// 日
        //                            // 年をアクティブにしてから下に移動
        //                            if (this.uGrid_InventInput.ActiveRow != null)
        //                            {
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                            }
        //                            break;
        //                        default:
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
        //                            break;
        //                    }
        //                }

        //                e.NextCtrl = null;
        //            }
        //            // Shift + Enterキー
        //            else if ((e.Key == Keys.Enter) &&
        //                ((e.ShiftKey == true) && (e.ControlKey == false) && (e.AltKey == false)))
        //            {
        //                if (this.uGrid_InventInput.ActiveRow.Index == 0)
        //                {
        //                    if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
        //                        (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryTolerancCnt) == 0))
        //                    {
        //                        // 先頭行の場合
        //                        this.tce_SortOrder.Focus();
        //                    }
        //                    else
        //                    {
        //                        //// 前のセルへ移動
        //                        // キーが押されたときのActiveCellによって動作を変える
        //                        switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                        {
        //                            case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// 下に移動
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Year:	// 年
        //                                // 日をアクティブにしてから上に移動
        //                                if (this.uGrid_InventInput.ActiveRow != null)
        //                                {
        //                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
        //                                    this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                                }
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Month:	// 月
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                                break;
        //                            case InventInputResult.ct_Col_InventoryDay_Day:	// 日
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
        //                                break;
        //                            default:
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                                break;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //// 前のセルへ移動
        //                    // キーが押されたときのActiveCellによって動作を変える
        //                    switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
        //                    {
        //                        case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// 下に移動
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Year:	// 年
        //                            // 日をアクティブにしてから上に移動
        //                            if (this.uGrid_InventInput.ActiveRow != null)
        //                            {
        //                                this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
        //                                this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                            }
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Month:	// 月
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
        //                            break;
        //                        case InventInputResult.ct_Col_InventoryDay_Day:	// 日
        //                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
        //                            break;
        //                        default:
        //                            this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
        //                            break;
        //                    }
        //                }
        //                e.NextCtrl = null;
        //            }
        //        }
        //    }
        //    else if (e.NextCtrl.Equals(this.uGrid_InventInput))
        //    {
        //        // 前のコントロールがソート順のとき
        //        if (e.PrevCtrl.Equals(this.tce_SortOrder))
        //        {
        //            // 先頭行の棚卸数
        //            if (this.uGrid_InventInput.ActiveCell == null)
        //            {
        //                this.uGrid_InventInput.ActiveCell =
        //                    this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt];
        //            }
        //            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //        }
        //        else if (e.PrevCtrl.Equals(this.tce_FontSize))
        //        {
        //            // 最終行の棚卸数
        //            if (this.uGrid_InventInput.ActiveCell == null)
        //            {
        //                this.uGrid_InventInput.ActiveCell =
        //                    this.uGrid_InventInput.Rows[this.uGrid_InventInput.Rows.Count - 1].Cells[InventInputResult.ct_Col_InventoryStockCnt];
        //            }
        //            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
        //        }
        //    }
        //}
        /// <summary>
        /// tRetKeyControl_ChangeFocus Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスが遷移する場合に発生する。</br>
        /// <br>Programmer	: 22013 kubo</br>
        /// <br>date		: 2007.04.17</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) ||
                (e.NextCtrl == null))
            {
                return;
            }

            // 抽出結果グリッドの場合
            if (e.PrevCtrl.Equals(this.uGrid_InventInput) == true)
            {
                // アクティブセルが有効
                if (this.uGrid_InventInput.ActiveCell != null)
                {
                    // ---ADD 2009/05/14 不具合対応[13260] -------------------->>>>>
                    if ((e.Key == Keys.LButton) || (e.Key == Keys.RButton))
                    {
                        this._isDownKey = string.Empty;
                    }
                    else
                    {
                        this._isDownKey = "ANYKEY";
                    }
                    // ---ADD 2009/05/14 不具合対応[13260] --------------------<<<<<

                    // 入力されたキーで判定
                    // Enterキー
                    if (((e.Key == Keys.Enter) || (e.Key == Keys.Tab)) &&
                        ((e.ShiftKey == false) && (e.ControlKey == false) && (e.AltKey == false)))
                    {
                        if (this.uGrid_InventInput.ActiveRow.Index == this.uGrid_InventInput.Rows.Count - 1)
                        {
                            // 最終行の棚卸数か、ボタンだったらカラムサイズコンボボックスに移動
                            if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryStockCnt) == 0) ||
                                (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Day) == 0))
                            {
                                //this.uce_ColSizeAutoSetting.Focus();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                            }
                            //if ( this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo( InventInputResult.ct_Col_InventoryDay_Day ) == 0 )
                            //{
                            //    // 最終行の発注数セルの場合
                            //    this.uce_ColSizeAutoSetting.Focus();
                            //}
                            else
                            {
                                this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                                ////// 次のセルへ移動
                                ////this.uGrid_InventInput.PerformAction( UltraGridAction.BelowCell );
                                //// キーが押されたときのActiveCellによって動作を変える
                                //switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                                //{
                                //    case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
                                //        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// 下に移動
                                //        break;
                                //    case InventInputResult.ct_Col_InventoryDay_Year:	// 年
                                //        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// 右に移動
                                //        break;
                                //    case InventInputResult.ct_Col_InventoryDay_Month:	// 月
                                //        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// 右に移動
                                //        break;
                                //    case InventInputResult.ct_Col_InventoryDay_Day:	// 日
                                //        // 年をアクティブにしてから下に移動
                                //        if (this.uGrid_InventInput.ActiveRow != null)
                                //        {
                                //            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                //            this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                //        }
                                //        break;
                                //    default:
                                //        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                //        break;
                                //}

                            }
                        }
                        else
                        {
                            //// 次のセルへ移動
                            //this.uGrid_InventInput.PerformAction( UltraGridAction.BelowCell );
                            // キーが押されたときのActiveCellによって動作を変える
                            switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                            {
                                case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);	// 下に移動
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Year:	// 年
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();	// 右に移動
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Month:	// 月
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();	// 右に移動
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Day:	// 日
                                    // 年をアクティブにしてから下に移動
                                    if (this.uGrid_InventInput.ActiveRow != null)
                                    {
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                    }
                                    break;
                                default:
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.BelowCell);
                                    break;
                            }
                        }

                        e.NextCtrl = null;
                    }
                    // Shift + Enterキー
                    else if ((e.Key == Keys.Enter) &&
                        ((e.ShiftKey == true) && (e.ControlKey == false) && (e.AltKey == false)))
                    {
                        if (this.uGrid_InventInput.ActiveRow.Index == 0)
                        {
                            if ((this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryDay_Year) == 0) ||
                                (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString().CompareTo(InventInputResult.ct_Col_InventoryTolerancCnt) == 0))
                            {
                                // 先頭行の場合
                                this.tce_SortOrder.Focus();
                            }
                            else
                            {
                                //// 前のセルへ移動
                                //this.uGrid_InventInput.PerformAction( UltraGridAction.AboveCell );
                                // キーが押されたときのActiveCellによって動作を変える
                                switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                                {
                                    case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// 下に移動
                                        break;
                                    case InventInputResult.ct_Col_InventoryDay_Year:	// 年
                                        // 日をアクティブにしてから上に移動
                                        if (this.uGrid_InventInput.ActiveRow != null)
                                        {
                                            this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
                                            this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                        }
                                        break;
                                    case InventInputResult.ct_Col_InventoryDay_Month:	// 月
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                        break;
                                    case InventInputResult.ct_Col_InventoryDay_Day:	// 日
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
                                        break;
                                    default:
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            //// 前のセルへ移動
                            //this.uGrid_InventInput.PerformAction( UltraGridAction.AboveCell );
                            // キーが押されたときのActiveCellによって動作を変える
                            switch (this.uGrid_InventInput.ActiveCell.Column.Tag.ToString())
                            {
                                case InventInputResult.ct_Col_InventoryStockCnt:	// 棚卸数
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);	// 下に移動
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Year:	// 年
                                    // 日をアクティブにしてから上に移動
                                    if (this.uGrid_InventInput.ActiveRow != null)
                                    {
                                        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Day].Activate();
                                        this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                    }
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Month:	// 月
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Year].Activate();
                                    break;
                                case InventInputResult.ct_Col_InventoryDay_Day:	// 日
                                    this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_InventoryDay_Month].Activate();
                                    break;
                                default:
                                    this.uGrid_InventInput.PerformAction(UltraGridAction.AboveCell);
                                    break;
                            }
                        }
                        e.NextCtrl = null;
                    }
                }
            }
            // ソート順
            else if (e.PrevCtrl.Equals(this.tce_SortOrder))
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.uGrid_InventInput.Rows.Count > 0)
                        {
                            e.NextCtrl = null;
                            this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                            this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = null;
                        this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                        this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else if (e.NextCtrl.Equals(this.uGrid_InventInput))
            {
                // 前のコントロールがソート順のとき
                if (e.PrevCtrl.Equals(this.tce_SortOrder))
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            if (this.uGrid_InventInput.Rows.Count > 0)
                            {
                                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
                else if (e.PrevCtrl.Equals(this.tce_FontSize))
                {
                    e.NextCtrl = null;
                    // 最終行の棚卸数
                    if (this.uGrid_InventInput.ActiveCell == null)
                    {
                        this.uGrid_InventInput.ActiveCell =
                            this.uGrid_InventInput.Rows[this.uGrid_InventInput.Rows.Count - 1].Cells[InventInputResult.ct_Col_InventoryStockCnt];
                    }
                    //					this.uGrid_InventInput.ActiveCell.Activate();
                    this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                }
                // 棚卸日
                else if (e.PrevCtrl.Equals(this.tde_InventoryDate))
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            if (this.uGrid_InventInput.Rows.Count > 0)
                            {
                                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
                // 一括設定ボタン
                else if (e.PrevCtrl.Equals(this.ub_InventoryAllInput))
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            if (this.uGrid_InventInput.Rows.Count > 0)
                            {
                                this.uGrid_InventInput.Rows[0].Cells[InventInputResult.ct_Col_InventoryStockCnt].Activate();
                                this.uGrid_InventInput.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region ◎ tde_InventoryDate_Leave
        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tde_InventoryDate_Leave(object sender, EventArgs e)
        {
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //// 日付入力チェック
            //if (((TDateEdit)sender).GetDateTime() == DateTime.MinValue)
            //{
            //    this.MsgDispProc("日付を指定して下さい", emErrorLevel.ERR_LEVEL_EXCLAMATION);
            //    this.tde_InventoryDate.Focus();
            //}
            //else if (!DateEditInputCheck(((TDateEdit)sender).GetDateTime(), false))
            //{
            //    this.MsgDispProc("不正な日付です", emErrorLevel.ERR_LEVEL_EXCLAMATION);
            //    this.tde_InventoryDate.Focus();
            //}
            //// 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            //else
            //{
            //    DateTime targetDate = ((TDateEdit)sender).GetDateTime();
            //    DateTime workDate = this.tde_InventoryExeDate.GetDateTime();
            //    if (targetDate > workDate.AddMonths(2))
            //    {
            //        this.MsgDispProc("不正な日付です 棚卸日から２ヵ月以内で入力して下さい", emErrorLevel.ERR_LEVEL_EXCLAMATION);
            //        this.tde_InventoryDate.Focus();
            //    }
            //}
            //// 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
            // 日付入力チェック
            string errMsg;
            if (!DateEditInputCheck((TDateEdit)sender, out errMsg))
            {
                MsgDispProc(errMsg, emErrorLevel.ERR_LEVEL_EXCLAMATION);
                this.tde_InventoryDate.Focus();
                return;
            }

            DateTime targetDate = ((TDateEdit)sender).GetDateTime();
            DateTime workDate = this.tde_InventoryExeDate.GetDateTime();
            if (targetDate > workDate.AddMonths(2))
            {
                this.MsgDispProc("不正な日付です 棚卸日から２ヵ月以内で入力して下さい", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                this.tde_InventoryDate.Focus();
                return;
            }

            this.utb_InventDataToolBar.ActiveTool = null;
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
        }
        #endregion

        #region ◎ ub_InventoryAllInput_Click
        /// <summary>
        /// 一括設定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void ub_InventoryAllInput_Click(object sender, EventArgs e)
        {
            // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------------------->>>>>
            //確認メッセージ
            string strMsg = "棚卸実施日を設定します。よろしいですか？\r\n※すでに設定済の日付も更新されます";
            DialogResult dlgRes = TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_INFO,        //エラーレベル
                "MAZAI05130UB",                     //UNIT　ID
                "棚卸入力",                        //プログラム名称
                "一括設定",		                        //プロセスID
                "",                                 //オペレーション
                strMsg.ToString(),                             //メッセージ
                0,									//ステータス
                null,								//オブジェクト
                MessageBoxButtons.YesNo,               //ダイアログボタン指定
                MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
                );
            if (dlgRes == DialogResult.No)
            {
                return;
            }
            // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------------------<<<<<

            DataView gridView = (DataView)uGrid_InventInput.DataSource;

            DataRow targetDr;
            //bool isShowProduct = false;           //DEL 2009/04/21 不具合対応[13075]
            SFCMN00299CA msgForm = new SFCMN00299CA();
            // 抽出中画面部品のインスタンスを作成
            msgForm.Title = "一括設定中";
            //msgForm.Message = "棚卸数の設定中です。";         //DEL 2009/05/14 不具合対応[13260]
            msgForm.Message = "棚卸実施日の設定中です。";       //ADD 2009/05/14 不具合対応[13260]
            try
            {
                msgForm.Show();	// ダイアログ表示

                this.uGrid_InventInput.BeginUpdate();	// 描画停止

                /* ---DEL 2009/04/21 不具合対応[13075] -------------------------------------------------------------->>>>>
                for (int index = 0; index < gridView.Count; index++)
                {
                    Debug.WriteLine("InventAllInput Start:" + DateTime.Now.TimeOfDay.ToString());
                    targetDr = gridView[index].Row;
                    //// 棚卸数と棚卸日が入力済みなら処理しない
                    //if ((targetDr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value) &&
                    //    targetDr[InventInputResult.ct_Col_InventoryDay_Datetime] != DBNull.Value)
                    //{
                    //    continue;
                    //}

                    // 棚卸数設定(棚卸数=帳簿数)
                    if ((double)targetDr[InventInputResult.ct_Col_StockTotal] == 0)
                    {
                        this.uGrid_InventInput.Rows[index].Cells[InventInputResult.ct_Col_InventoryStockCnt].Value = 0;
                        targetDr[InventInputResult.ct_Col_InventoryStockCnt] = 0;
                    }
                    else
                    {
                        targetDr[InventInputResult.ct_Col_InventoryStockCnt] = (double)targetDr[InventInputResult.ct_Col_StockTotal];
                    }
                    // 変更区分をセット
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;

                    // 棚卸数更新
                    this.AfterInputInventryToleCnt(
                        ref targetDr,
                        (int)InventInputSearchCndtn.ViewState.View, ref isShowProduct);

                    // 日付更新
                    this.AfterInputInventoryDate(ref targetDr, this.tde_InventoryDate.GetDateTime());

                    Debug.WriteLine("InventAllInput End:" + DateTime.Now.TimeOfDay.ToString());

                }
                   ---DEL 2009/04/21 不具合対応[13075] --------------------------------------------------------------<<<<< */
                // ---ADD 2009/04/21 不具合対応[13075] -------------------------------------------------------------->>>>>
                this._inventInputView.RowFilter = string.Empty;         //ADD 2009/05/14 不具合対応[13260]　フォーカスの当たっている所しか更新できない為
                for (int index = 0; index < this._inventInputView.Count; index++)
                {
                    targetDr = this._inventInputView[index].Row;

                    //日付更新
                    this._inventInputAcs.DevInventoryDay(targetDr, this.tde_InventoryDate.GetDateTime());

                    // ---DEL 2009/05/14 不具合対応[13260] -------------------------------------------------->>>>>
                    ////棚卸数
                    //if ((double)targetDr[InventInputResult.ct_Col_StockTotal] == 0)
                    //{
                    //    targetDr[InventInputResult.ct_Col_InventoryStockCnt] = 0;
                    //}
                    //else
                    //{
                    //    targetDr[InventInputResult.ct_Col_InventoryStockCnt] = (double)targetDr[InventInputResult.ct_Col_StockTotal];
                    //}

                    ////前回差異数    ※今回差異数を更新する前にセットしておく
                    //double bfInvToleCnt = 0;
                    //if (targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value)
                    //{
                    //    bfInvToleCnt = (double)targetDr[InventInputResult.ct_Col_InventoryTolerancCnt];
                    //}

                    //targetDr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = bfInvToleCnt;

                    ////今回差異数
                    //double toleCnt = (double)targetDr[InventInputResult.ct_Col_StockTotal] - (double)targetDr[InventInputResult.ct_Col_InventoryStockCnt];
                    //targetDr[InventInputResult.ct_Col_InventoryTolerancCnt] = toleCnt;
                    // ---DEL 2009/05/14 不具合対応[13260] --------------------------------------------------<<<<<

                    //変更区分
                    targetDr[InventInputResult.ct_Col_ChangeDiv] = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                }


                // ---ADD 2009/04/21 不具合対応[13075] --------------------------------------------------------------<<<<<
            }
            catch (Exception ex)
            {
                this.MsgDispProc("棚卸数一括設定に失敗しました。", -1, "ub_InventoryAllInput_Click", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
            }
            finally
            {
                this.uGrid_InventInput.EndUpdate();
                msgForm.Close();
            }
        }
        #endregion

        #region ◎ uce_ColSizeAutoSetting_CheckedChanged
        /// <summary>
        /// uce_ColSizeAutoSetting_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uce_ColSizeAutoSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (!this._isEventAutoFillColumn) return;

            this._isEventAutoFillColumn = false;

            try
            {
                if (this.uce_ColSizeAutoSetting.Checked)
                {
                    // 列幅をオートに設定
                    this.uGrid_InventInput.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                }
                else
                {
                    this.uGrid_InventInput.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                    // カラムサイズ調整
                    this.InitialInventInputGrid_Width(this.uGrid_InventInput.DisplayLayout.Bands[InventInputResult.ct_Tbl_InventInput]);
                    //this.ColumnPerformAutoResize();
                }
            }
            finally
            {
                this._isEventAutoFillColumn = true;
            }
        }
        #endregion ◎ uce_ColSizeAutoSetting_CheckedChanged

        #region ◎ tce_FontSize_ValueChanged
        /// <summary>
        /// tce_FontSize_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tce_FontSize_ValueChanged(object sender, EventArgs e)
        {
            // 文字サイズを変更
            this.uGrid_InventInput.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tce_FontSize.Value;
        }
        #endregion ◎ tce_FontSize_ValueChanged

        #region ◎ utb_InventDataToolBar_ToolClick
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// utb_InventDataToolBar_ToolClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utb_InventDataToolBar_ToolClick(object sender, ToolClickEventArgs e)
        {
            this.uGrid_InventInput.PerformAction(UltraGridAction.ExitEditMode);

            switch (e.Tool.Key)
            {
                // 表示メニュー
                case ct_tool_Hidden_Warehouse:	// 倉庫
                case ct_tool_Hidden_WarehouseShelfNo:   // 棚番
                case ct_tool_Hidden_DuplicationShelfNo1:// 重複棚番1
                case ct_tool_Hidden_DuplicationShelfNo2:// 重複棚番2
                case ct_tool_Hidden_Maker:	// メーカー
                case ct_tool_Hidden_Supplier:	// 仕入先
                case ct_tool_Hidden_StockTrtEntDiv:	// 在庫区分

                    // 列設定（表示／非表示）の更新
                    bool hidden = !(((StateButtonTool)e.Tool).Checked);
                    UpdGridColumnSetting(e.Tool.Key, hidden, 0);
                    break;
                case ct_tool_Hidden_Initialize:	// 初期表示状態
                    // 倉庫
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Warehouse]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Warehouse, true, 0);
                    // 棚番
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_WarehouseShelfNo]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_WarehouseShelfNo, true, 0);
                    // 重複棚番1
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo1]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo1, true, 0);
                    // 重複棚番2
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo2]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo2, true, 0);
                    // メーカー
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Maker]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Maker, true, 0);
                    // 仕入先
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Supplier]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Supplier, true, 0);
                    // 在庫区分
                    ((StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_StockTrtEntDiv]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_StockTrtEntDiv, true, 0);
                    break;
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// utb_InventDataToolBar_ToolClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void utb_InventDataToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.uGrid_InventInput.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);

            switch (e.Tool.Key)
            {
                // 表示メニュー
                // ------------------------------------------------------------------------------------- //
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //case ct_tool_Hidden_TEL1          :	// TEL1
                //case ct_tool_Hidden_TEL2			:	// TEL2
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                case ct_tool_Hidden_Warehouse:	// 倉庫
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                case ct_tool_Hidden_WarehouseShelfNo:   // 棚番
                case ct_tool_Hidden_DuplicationShelfNo1:// 重複棚番1
                case ct_tool_Hidden_DuplicationShelfNo2:// 重複棚番2
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                case ct_tool_Hidden_Maker:	// メーカー
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //case ct_tool_Hidden_CarrierEp     :	// 事業者
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                case ct_tool_Hidden_Customer:	// 仕入先
                case ct_tool_Hidden_ShipCustomer:	// 委託先
                case ct_tool_Hidden_StockTrtEntDiv:	// 在庫区分

                    // 列設定（表示／非表示）の更新
                    bool hidden = !(((Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool).Checked);
                    UpdGridColumnSetting(e.Tool.Key, hidden, 0);
                    break;
                case ct_tool_Hidden_Initialize:	// 初期表示状態
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //// TEL1
                    //( (Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_TEL1]).Checked = false;
                    //UpdGridColumnSetting( ct_tool_Hidden_TEL1, true, 0 );
                    //// TEL2
                    //( (Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_TEL2]).Checked = false;
                    //UpdGridColumnSetting( ct_tool_Hidden_TEL2, true, 0 );
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    // 倉庫
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Warehouse]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Warehouse, true, 0);
                    // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                    // 棚番
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_WarehouseShelfNo]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_WarehouseShelfNo, true, 0);
                    // 重複棚番1
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo1]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo1, true, 0);
                    // 重複棚番2
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_DuplicationShelfNo2]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_DuplicationShelfNo2, true, 0);
                    // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
                    // メーカー
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Maker]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Maker, true, 0);
                    // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //// 事業者
                    //( (Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_CarrierEp]).Checked = false;
                    //UpdGridColumnSetting( ct_tool_Hidden_CarrierEp, true, 0 );
                    // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    // 仕入先
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_Customer]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_Customer, true, 0);
                    // 委託先
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_ShipCustomer]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_ShipCustomer, true, 0);
                    // 在庫区分
                    ((Infragistics.Win.UltraWinToolbars.StateButtonTool)utb_InventDataToolBar.Tools[ct_tool_Hidden_StockTrtEntDiv]).Checked = false;
                    UpdGridColumnSetting(ct_tool_Hidden_StockTrtEntDiv, true, 0);
                    break;
#if false
				case "tool_lb_InventoryDay":
				    if ( this.uGrid_InventInput.ActiveRow != null )
				    {
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_Status].Value = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StatusDetail].Value = "すでに登録されています";
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StkTelNo1ChgFlg].Value = 1;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StkTelNo2ChgFlg].Value = 1;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_StkUnitPriceChgFlg].Value = 1;
				        this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_MoveStockCount].Value = 5;
				    }
					break;
#endif
            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◎ ub_RowDelete_Click
        /// <summary>
        /// ub_RowDelete_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 行削除ボタンがクリックされたときに発生します</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.07.24</br>
        /// </remarks>
        private void ub_RowDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //this.uGrid_InventInput.BeginUpdate();
            //    DialogResult dialogRes = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "行削除", "選択行を削除しますか？", 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);

            //    if (dialogRes == DialogResult.No)
            //        return;

            //    DataRow targetRow = null;
            //    int activeRowIndex = 0;
            //    if (this.uGrid_InventInput.ActiveRow == null)
            //        return;
            //    else
            //    {
            //        targetRow = (DataRow)this.uGrid_InventInput.ActiveRow.Cells[InventInputResult.ct_Col_RowSelf].Value;
            //        activeRowIndex = this.uGrid_InventInput.ActiveRow.Index;
            //    }

            //    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //    //this.RowDeleteProc(targetRow, activeRowIndex);
            //    this.RowDeleteProc(targetRow, activeRowIndex, 0);
            //    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            //}
            //finally
            //{
            //    //this.uGrid_InventInput.EndUpdate();
            //}

            ArrayList deleteIndex = new ArrayList();

            if ((this.uGrid_InventInput.Selected.Rows != null) && (this.uGrid_InventInput.Selected.Rows.Count > 0))
            {
                for (int index = 0; index < this.uGrid_InventInput.Selected.Rows.Count; index++)
                {
                    deleteIndex.Add(this.uGrid_InventInput.Selected.Rows[index].Index);
                }
            }
            else
            {
                if ((this.uGrid_InventInput.ActiveCell == null) && (this.uGrid_InventInput.ActiveRow == null))
                {
                    return;
                }

                if (this.uGrid_InventInput.ActiveCell != null)
                {
                    deleteIndex.Add(this.uGrid_InventInput.ActiveCell.Row.Index);
                }
                else
                {
                    deleteIndex.Add(this.uGrid_InventInput.ActiveRow.Index);
                }
            }

            foreach (int rowIndex in deleteIndex)
            {
                int deleteDiv = (Int32)this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_DeleteDiv].Value;

                if (deleteDiv == 0)
                {
                    this.uGrid_InventInput.Rows[rowIndex].Appearance.BackColor = Color.Pink;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_DeleteDiv].Value = 1;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_ChangeDiv].Value = (int)InventInputSearchCndtn.ChangeFlagState.Change;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_UpdateDiv].Value = 0;
                }
                else
                {
                    this.uGrid_InventInput.Rows[rowIndex].Appearance.BackColor = Color.Empty;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_DeleteDiv].Value = 0;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_ChangeDiv].Value = (int)InventInputSearchCndtn.ChangeFlagState.NotChange;
                    this.uGrid_InventInput.Rows[rowIndex].Cells[InventInputResult.ct_Col_UpdateDiv].Value = 1;
                }
                this.uGrid_InventInput.UpdateData();
            }
        }
        #endregion
		#endregion ■ Control Event
	}
}
