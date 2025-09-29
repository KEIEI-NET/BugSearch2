//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫仕入入力
// プログラム概要   : 在庫仕入入力で使用するデータの取得・更新を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 渡邉貴裕
// 作 成 日  2007/05/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/03/14  修正内容 : 商品コード桁数変更15桁⇒40桁0
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/07/24  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 修 正 日  2009/02/19  修正内容 : 商品検索の取得ＭＡＸ件数を3200件とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/26  修正内容 : 不具合対応[13376]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/17  修正内容 : 不具合対応[13515]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/23  修正内容 : 不具合対応[13602]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2009/11/16  修正内容 : 在庫登録機能の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 修 正 日  2009/12/16  修正内容 : PM.NS-5
//　　　　　　　　　　　　　　　　　標準価格、原単価、仕入数、仕入後数の
//                                  ディフォルトの改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/07/14  修正内容 : Mantis.15812　商品在庫マスタ呼び出し時のパラメータの変更
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/25  修正内容 : 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 陳建明
// 修 正 日  2011/12/13  修正内容 : redmine#26816 修正呼び出し時には同一品番選択ウィンドウは表示しない
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 修 正 日  2017/08/11  修正内容 : ハンディターミナル在庫仕入登録の対応
//----------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>    
	/// 製番在庫マスタアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 製番在庫マスタのアクセスクラスです。</br>
	/// <br>Programmer : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.05.18</br>
    /// <br>Update Note: 2008.03.14 980035 金沢 貞義</br>
    /// <br>			 ・商品コード桁数変更15桁⇒40桁0</br>
    /// <br>Update Note: 2008/07/24 30414 忍 幸史</br>
    /// <br>			 ・Partsman用に変更</br>
    /// <br>Update Note: 2009.02.19 20056 對馬 大輔</br>
    /// <br>			 ・商品検索の取得ＭＡＸ件数を3200件とする</br>
    /// <br>Update Note: 2009/05/26       照田 貴志</br>
    /// <br>			 ・不具合対応[13376]</br>
    /// <br>Update Note: 2009/06/23       照田 貴志</br>
    /// <br>			 ・不具合対応[13602]</br>
    /// <br>Update Note: 2009/11/16       工藤 恵優</br>
    /// <br>			 ・在庫登録機能の追加</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Note: 2011/12/13 陳建明 redmine#26816 修正呼び出し時には同一品番選択ウィンドウは表示しない</br>
    /// <br>Update Note: 2017/08/11 譚洪  </br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>             ハンディターミナル在庫仕入登録の対応</br> 
    /// </remarks>
	public partial class AdjustStockAcs
	{
        //==================================================================
        //  パブリック列挙型
        //==================================================================
        #region パブリック列挙型
        #endregion

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        public static AdjustStockAcs GetInstance()
        {
            if (myInstance == null)
            {
                myInstance = new AdjustStockAcs();
            }

            return myInstance;
        }

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        public int edtiMode;
        public DateTime editDate;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        //==================================================================
		//  パブリック定数
		//==================================================================
		#region パブリック定数
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>在庫調整明細テーブル名</summary>
        //public const string ctTBL_AdjustStock = "AdjustStockDtlTbl";
        ///// <summary>作成日時</summary>
        //public const string ctCOL_CreateDateTime = "CreateDateTime";
        ///// <summary>更新日時</summary>
        //public const string ctCOL_UpdateDateTime = "UpdateDateTime";
        ///// <summary>企業コード</summary>
        //public const string ctCOL_EnterpriseCode = "EnterpriseCode";
        ///// <summary>GUID</summary>
        //public const string ctCOL_FileHeaderGuid = "FileHeaderGuid";
        ///// <summary>更新従業員コード</summary>
        //public const string ctCOL_UpdEmployeeCode = "UpdEmployeeCode";
        ///// <summary>更新アセンブリID1</summary>
        //public const string ctCOL_UpdAssemblyId1 = "UpdAssemblyId1";
        ///// <summary>更新アセンブリID2</summary>
        //public const string ctCOL_UpdAssemblyId2 = "UpdAssemblyId2";
        ///// <summary>論理削除区分</summary>
        //public const string ctCOL_LogicalDeleteCode = "LogicalDeleteCode";
        ///// <summary>拠点コード</summary>
        //public const string ctCOL_SectionCode = "SectionCode";
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>メーカーコード</summary>
        ////public const string ctCOL_MakerCode = "MakerCode";
        /////// <summary>商品コード</summary>
        ////public const string ctCOL_GoodsCode = "GoodsCode";
        ///// <summary>メーカーコード</summary>
        //public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        ///// <summary>商品コード</summary>
        //public const string ctCOL_GoodsNo = "GoodsNo";
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品名称</summary>
        //public const string ctCOL_GoodsName = "GoodsName";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>製造番号</summary>
        ////public const string ctCOL_ProductNumber = "ProductNumber";
        /////// <summary>製番在庫マスタGUID</summary>
        ////public const string ctCOL_ProductStockGuid = "ProductStockGuid";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>在庫区分</summary>
        //public const string ctCOL_StockDiv = "StockDiv";
        ///// <summary>倉庫コード</summary>
        //public const string ctCOL_WarehouseCode = "WarehouseCode";
        ///// <summary>倉庫名称</summary>
        //public const string ctCOL_WarehouseName = "WarehouseName";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>事業者コード</summary>
        ////public const string ctCOL_CarrierEpCode = "CarrierEpCode";
        /////// <summary>事業者名称</summary>
        ////public const string ctCOL_CarrierEpName = "CarreirEpName";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>得意先コード</summary>
        //public const string ctCOL_CustomerCode = "CustomerCode";
        ///// <summary>得意先名称</summary>
        //public const string ctCOL_CustomerName = "CustomerName";
        ///// <summary>得意先名称2</summary>
        //public const string ctCOL_CustomerName2 = "CustomerName2";
        ///// <summary>仕入日</summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public const string ctCOL_StockDate = "StockDate";
        //public const string ctCOL_LastStockDate = "LastStockDate";
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>入荷日</summary>
        //public const string ctCOL_ArrivalGoodsDay = "ArrivalGoodsDay";
        ///// <summary>仕入単価</summary>
        //public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        ///// <summary>変更前仕入単価</summary>
        //public const string ctCOL_BfStockUnitPrice = "BfStockUnitPrice";
        ///// <summary>仕入金額</summary>
        //public const string ctCOL_StockPrice = "StockPrice";        
        ///// <summary>仕入金額消費税額</summary>
        //public const string ctCOL_StockPriceConsTax = "StockPriceConsTax";
        ///// <summary>仕入外税対象額</summary>
        //public const string ctCOL_ItdedStckOutTax = "ItdedStckOutTax";        
        ///// <summary>仕入内税対象額</summary>
        //public const string ctCOL_ItdedStckInTax = "ItdedStckInTax";
        ///// <summary>仕入非課税対象額</summary>
        //public const string ctCOL_ItdedStckTaxFree = "ItdedStckTaxFree";
        ///// <summary>仕入外税額</summary>
        //public const string ctCOL_StckOuterTax = "StckOuterTax";
        ///// <summary>仕入内税額</summary>
        //public const string ctCOL_StckInnerTax = "StckInnerTax";
        ///// <summary>課税区分</summary>
        //public const string ctCOL_TaxationCode = "TaxationCode";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>在庫状態</summary>
        ////public const string ctCOL_StockState = "StockState";
        /////// <summary>移動状態</summary>
        ////public const string ctCOL_MoveStatus = "MoveStatus";
        /////// <sammary>商品状態</sammary>
        ////public const string ctCOL_GoodsCodeStatus = "GoodsCodeStatus";
        /////// <sammary>修正前商品状態</sammary>
        ////public const string ctCOL_BfGoodsCodeStatus = "BfGoodsCodeStatus";
        /////// <summary>商品電話番号1</summary>
        ////public const string ctCOL_StockTelNo1 = "StockTelNo1";
        /////// <summary>商品電話番号2</summary>
        ////public const string ctCOL_StockTelNo2 = "StockTelNo2";
        /////// <summary>ロム区分</summary>
        ////public const string ctCOL_RomDiv = "RomDiv";
        /////// <summary>機種コード</summary>
        ////public const string ctCOL_CellphoneModelCode = "CellphoneModelCode";
        /////// <summary>機種名称</summary>
        ////public const string ctCOL_CellphoneModelName = "CellphoneModelName";
        /////// <summary>キャリアコード</summary>
        ////public const string ctCOL_CarrierCode = "CarrierCode";
        /////// <summary>キャリア名称</summary>
        ////public const string ctCOL_CarrierName = "CarrierName";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>メーカー名称</summary>
        //public const string ctCOL_MakerName = "MakerName";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>系統色コード</summary>
        ////public const string ctCOL_SystematicColorCd = "SystematicColorCd";
        /////// <summary>系統色名称</summary>
        ////public const string ctCOL_SystematicColorNm = "SystematicColorNm";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品大分類コード</summary>
        //public const string ctCOL_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary>商品中分類コード</summary>
        //public const string ctCOL_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>出荷先得意先コード</summary>
        ////public const string ctCOL_ShipCustomerCode = "ShipCustomerCode";
        /////// <summary>出荷先得意先名称</summary>
        ////public const string ctCOL_ShipCustomerName = "ShipCustomerName";
        /////// <summary>出荷先得意先名称2</summary>
        ////public const string ctCOL_ShipCustomerName2 = "ShipCustomerName2";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>行数</summary>        
        //public const string ctCOL_RowNum = "RowNum";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>変更前電話番号</summary>
        ////public const string ctCOL_BfStockTelNo1 = "BfStockTelNo1";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>現在庫数(仕入在庫数)</summary>
        //public const string ctCOL_SupplierStock = "SupplierStock";
        ///// <summary>調整数</summary>
        //public const string ctCOL_AdjustCount = "AdjustCount";
        ///// <summary>調整金額</summary>
        //public const string ctCOL_AdjustPrice = "AdjustPrice";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>修正前製番</summary>
        ////public const string ctCOL_BfProductNumber = "BfProductNumber";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品ガイド</summary>
        //public const string ctCOL_GoodsGuide = "GoodsGuide";        
        ///// <summary>明細判定</summary>
        //public const string ctCOL_RowType = "RowType";
        ///// <summary>受託在庫数</summary>
        //public const string ctCOL_TrustCount = "TrustCount";
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>製番管理区分</summary>
        ////public const string ctCOL_PrdNumMngDiv = "PrdNumMngDiv";
        //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //// 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>商品区分詳細コード</summary>
        //public const string ctCOL_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary>ＢＬ商品コード</summary>
        //public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        ///// <summary>倉庫棚番</summary>
        //public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        ///// <summary>修正前倉庫棚番</summary>
        //public const string ctCOL_BfWarehouseShelfNo = "BfWarehouseShelfNo";
        //// 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>明細備考</summary>
        //public const string ctCOL_DtlNote = "DtlNote";
        //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>定価（浮動）</summary>
        //public const string ctCOL_ListPriceFl = "ListPriceFl";
        //// 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>初期明細行数</summary>
        //public static readonly int ctCOUNT_RowInit = 50;
        ///// <summary>明細最大行数</summary>
        //public static readonly int ctCOUNT_RowMax = 999;
        ///// <summary>明細行追加単位行数</summary>
        //public static readonly int ctCOUNT_RowAdd = 1;
        //private const int ctMode_StockAdjust = 0;
        //// 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
        ////private const int ctMode_TrustAdjust = 1;
        ////// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //////private const int ctMode_ProductReEdit = 2;
        //////private const int ctMode_GoodsCodeStatus = 3;
        //////private const int ctMode_UnitPriceReEdit = 4;
        ////private const int ctMode_UnitPriceReEdit = 2;
        ////private const int ctMode_ShelfNoReEdit = 3;
        ////// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        //private const int ctMode_UnitPriceReEdit = 1;
        //private const int ctMode_ShelfNoReEdit = 2;
        //// 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>在庫調整明細テーブル名</summary>
        public const string ctTBL_AdjustStock = "AdjustStockDtlTbl";
        /// <summary>作成日時</summary>
        public const string ctCOL_CreateDateTime = "CreateDateTime";
        /// <summary>更新日時</summary>
        public const string ctCOL_UpdateDateTime = "UpdateDateTime";
        /// <summary>企業コード</summary>
        public const string ctCOL_EnterpriseCode = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ctCOL_FileHeaderGuid = "FileHeaderGuid";
        /// <summary>更新従業員コード</summary>
        public const string ctCOL_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary>更新アセンブリID1</summary>
        public const string ctCOL_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary>更新アセンブリID2</summary>
        public const string ctCOL_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary>論理削除区分</summary>
        public const string ctCOL_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary>拠点コード</summary>
        public const string ctCOL_SectionCode = "SectionCode";
        /// <summary>行数</summary>        
        public const string ctCOL_RowNum = "RowNum";
        /// <summary>調整日付</summary>
        public const string ctCOL_AdjustDate = "AdjustDate";
        /// <summary>入力日付</summary>
        public const string ctCOL_InputDay = "InputDay";
        /// <summary>メーカーコード</summary>
        public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>品番</summary>
        public const string ctCOL_GoodsNo = "GoodsNo";
        /// <summary>品名</summary>
        public const string ctCOL_GoodsName = "GoodsName";
        /// <summary>原単価</summary>
        public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        /// <summary>変更前原単価</summary>
        public const string ctCOL_BfStockUnitPrice = "BfStockUnitPrice";
        /// <summary>在庫数(仕入在庫数)</summary>
        public const string ctCOL_SupplierStock = "SupplierStock";
        /// <summary>変更前在庫数(仕入在庫数)</summary>
        public const string ctCOL_BfSupplierStock = "BfSupplierStock";
        /// <summary>明細備考</summary>
        public const string ctCOL_DtlNote = "DtlNote";
        /// <summary>倉庫コード</summary>
        public const string ctCOL_WarehouseCode = "WarehouseCode";
        /// <summary>ＢＬ商品コード</summary>
        public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        /// <summary>倉庫棚番</summary>
        public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>標準価格</summary>
        public const string ctCOL_ListPriceFl = "ListPriceFl";
        /// <summary>仕入先</summary>
        public const string ctCOL_SupplierCd = "SupplierCd";
        /// <summary>仕入数(発注単位)</summary>
        public const string ctCOL_SalesOrderUnit = "SalesOrderUnit";
        /// <summary>変更前仕入数(発注単位)</summary>
        public const string ctCOL_BfSalesOrderUnit = "BfSalesOrderUnit";
        /// <summary>仕入後数</summary>
        public const string ctCOL_AfSalesOrderUnit = "AfSalesOrderUnit";
        /// <summary>発注残</summary>
        public const string ctCOL_SalesOrderCount = "SalesOrderCount";
        /// <summary>仕入形式(元)</summary>
        public const string ctCOL_SupplierFormalSrc = "SupplierFormalSrc";
        /// <summary>仕入明細通番(元)</summary>
        public const string ctCOL_StockSlipDtlNumSrc = "StockSlipDtlNumSrc";
        /// <summary>在庫調整伝票番号</summary>
        public const string ctCOL_StockAdjustSlipNo = "StockAdjustSlipNo";
        /// <summary>在庫マスタ</summary>
        public const string ctCOL_Stock = "Stock";
        /// <summary>在庫調整データ</summary>
        public const string ctCOL_StockAdjust = "StockAdjust";
        /// <summary>在庫調整明細データ</summary>
        public const string ctCOL_StockAdjustDtl = "StockAdjustDtl";
        /// <summary>価格マスタ</summary>
        public const string ctCOL_GoodsPrice = "GoodsPrice";
        /// <summary>仕入金額</summary>
        public const string ctCOL_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary>オープン価格区分</summary>
        public const string ctCOL_OpenPriceDiv = "OpenPriceDiv";
        /// <summary>仕入先略称</summary>
        public const string ctCOL_SupplierSnm = "SupplierSnm";

        /// <summary>初期明細行数</summary>
        public static readonly int ctCOUNT_RowInit = 50;
        /// <summary>明細最大行数</summary>
        public static readonly int ctCOUNT_RowMax = 999;
        /// <summary>明細行追加単位行数</summary>
        public static readonly int ctCOUNT_RowAdd = 1;
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		//==================================================================
		//  パブリックイベント
		//==================================================================
		#region パブリックイベント
		/// <summary>仕入伝票情報が変更された場合に発生します。</summary>
		public static event EventHandler SlipChanged
		{
			add { lock (syncRoot) { _slipChanged += value; } }
			remove { lock (syncRoot) { _slipChanged -= value; } }
		}

		/// <summary>明細テーブル行が変更された場合に発生します。</summary>
		public static event DataRowChangeEventHandler SlipDtlRowChanged
		{
			add { lock (syncRoot) { _mainProductStock.RowChanged += value; } }
			remove { lock (syncRoot) { _mainProductStock.RowChanged -= value; } }
		}

		/// <summary>明細が追加される直前に発生します。</summary>
		public static event EventHandler<SlipDtlRowChangingEventArgs> SlipDtlRowAdding
		{
			add { lock (syncRoot) { _slipDtlRowAdding += value; } }
			remove { lock (syncRoot) { _slipDtlRowAdding -= value; } }
		}

		/// <summary>明細が追加された場合に発生します。</summary>
		public static event EventHandler<SlipDtlRowChangedEventArgs> SlipDtlRowAdded
		{
			add { lock (syncRoot) { _slipDtlRowAdded += value; } }
			remove { lock (syncRoot) { _slipDtlRowAdded -= value; } }
		}

		/// <summary>明細が削除される直前に発生します。</summary>
		public static event EventHandler<SlipDtlRowChangingEventArgs> SlipDtlRowRemoving
		{
			add { lock (syncRoot) { _slipDtlRowRemoving += value; } }
			remove { lock (syncRoot) { _slipDtlRowRemoving -= value; } }
		}

		/// <summary>明細が変更された場合に発生します。</summary>
		public static event EventHandler<SlipDtlRowChangedEventArgs> SlipDtlRowRemoved
		{
			add { lock (syncRoot) { _slipDtlRowRemoved += value; } }
			remove { lock (syncRoot) { _slipDtlRowRemoved -= value; } }
		}

		/// <summary>明細列が変更される直前に発生します。</summary>
		public static event EventHandler<SlipDtlColChangingEventArgs> SlipDtlColChanging
		{
			add { lock (syncRoot) { _slipDtlColChanging += value; } }
			remove { lock (syncRoot) { _slipDtlColChanging -= value; } }
		}

		/// <summary>明細列が変更された場合に発生します。</summary>
		public static event EventHandler<SlipDtlColChangedEventArgs> SlipDtlColChanged
		{
			add { lock (syncRoot) { _slipDtlColChanged += value; } }
			remove { lock (syncRoot) { _slipDtlColChanged -= value; } }
		}

        /// <summary>データ変更後発生イベント</summary>
        // 2008.02.15 削除 >>>>>>>>>>>>>>>>>>>>
        //public event EventHandler DataChanged;
        // 2008.02.15 削除 <<<<<<<<<<<<<<<<<<<<

		#endregion

		//==================================================================
		//  プライベート変数
		//==================================================================
		#region プライベート変数
		/// <summary>スタティックインスタンス</summary>
		private static AdjustStockAcs myInstance = null;

        private IStockAdjustDB _iStockAdjustDB = null; 

		/// <summary>インスタンス化回数</summary>
		private static int instanceCnt = 0;
		/// <summary>ロックオブジェクト</summary>
		private static object syncRoot = new Object();
		/// <summary>明細情報変更イベント制御カウンタ</summary>
		private static int slipDtlChangeEventCounter = 0;

		//--------------------------------------------------------
		//  在庫関連
		//--------------------------------------------------------
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>		
        /// <summary>在庫情報バッファ(Main Static Memory)</summary>
		private static Stock mainStock = null;

        /// <summary>在庫情報バッファ(Original Static Memory)</summary>
        /// <remarks>読込時の情報を保持(変更チェック/取消に使用)</remarks>
        private static Stock orgnPtSuplSlip = null;

        private static ArrayList _stockList = new ArrayList();
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

		/// <summary>製番情報バッファ(Main Static Memory)</summary>
		private static DataTable _mainProductStock = null;

        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <remarks>伝票読込時の情報を保持(変更チェック/取消に使用)</remarks>
		//private static List<ProductStock> orgnAdjustStockDtl = null;
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>明細データビュー(有効分のみ)</summary>
		private static DataView _mainProductStockView = null;
		/// <summary>明細データビュー(全データ)</summary>
		private static DataView mainAdjustStockDtlFullView = null;
		/// <summary>明細データビュー(手入力消費税額調整用)</summary>
		private static DataView adjustSuplSlipDtlPriceView = null;

        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>コピペ用仕入伝票明細クリップボード</summary>
		//private static List<ProductStock> suplSlipDtlClipboard = null;
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

		/// <summary>最大明細行数</summary>
        //private static int maxRowCnt = ctCOUNT_RowInit;  // DEL 2009/12/16
        public static int maxRowCnt = ctCOUNT_RowInit;     // ADD 2009/12/16

        private bool _isDataCanged = false;


        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        private StockProcMoneyAcs _stockProcMoneyAcs;   // 単価算出クラスアクセスクラス
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private SearchStockAcs _searchStockAcs;         // 在庫マスタアクセスクラス
        private GoodsAcs _goodsAcs;                     // 商品マスタアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;             // BL商品コードマスタアクセスクラス
        private WarehouseAcs _warehouseAcs;             // 倉庫マスタアクセスクラス
        private SecInfoAcs _secInfoAcs;                 // 拠点情報マスタアクセスクラス
        private EmployeeAcs _employeeAcs;               // 従業員マスタアクセスクラス
        private MakerAcs _makerAcs;                     // メーカーマスタアクセスクラス
        private StockMngTtlStAcs _stockMngTtlStAcs;
        private SupplierAcs _supplierAcs;

        private StockMngTtlSt _stockMngTtlSt;
        private UnitPriceCalculation _unitPriceCalculation;
        private TaxRateSet _taxRateSet;

        private CompanyInfAcs _companyInfAcs;                // ADD 2011/07/25
        private CompanyInf _companyInf = null;  // 自社情報 // ADD 2011/07/25

        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		#endregion

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼定数（ハンディターミナル用）
        /// <summary>メーカーフォーマット</summary>
        private const string GoodsMakerCdFormat = "0000";
        /// <summary>BL商品コードフォーマット</summary>
        private const string BLGoodsCodeFormat = "00000";
        /// <summary>発注先コードフォーマット</summary>
        private const string SupplierCdFormat = "000000";

        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムID</summary>
        private const string AssemblyIdPmhnd01114d = "PMHND01114D";
        /// <summary>ハンディターミナル在庫仕入（入庫更新）ワークプログラムIDのクラス名</summary>
        private const string AssemblyIdPmhnd01114dClassName = "Broadleaf.Application.Remoting.ParamData.HandyNonUOEInspectParamWork";

        /// <summary>仕入明細通番</summary>
        private const string StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary>検品数</summary>
        private const string InspectCnt = "InspectCnt";
        #endregion

        #region ▼プライベート変数（ハンディターミナル用）
        /// <summary>製番情報バッファ</summary>
        private DataTable MainProductStock = null;
        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

        //==================================================================
		//  プライベートデリゲート変数
		//==================================================================
		#region プライベートデリゲート変数
		// 提供イベント用
		/// <summary>仕入伝票変更イベント用デリゲート</summary>
		private static EventHandler _slipChanged = null;
		/// <summary>仕入伝票明細行追加前イベント用デリゲート</summary>
		private static EventHandler<SlipDtlRowChangingEventArgs> _slipDtlRowAdding = null;
		/// <summary>仕入伝票明細行追加後イベント用デリゲート</summary>
		private static EventHandler<SlipDtlRowChangedEventArgs> _slipDtlRowAdded = null;
		/// <summary>仕入伝票明細行削除前イベント用デリゲート</summary>
		private static EventHandler<SlipDtlRowChangingEventArgs> _slipDtlRowRemoving = null;
		/// <summary>仕入伝票明細行削除後イベント用デリゲート</summary>
		private static EventHandler<SlipDtlRowChangedEventArgs> _slipDtlRowRemoved = null;
		/// <summary>仕入伝票明細列変更前イベント用デリゲート</summary>
		private static EventHandler<SlipDtlColChangingEventArgs> _slipDtlColChanging = null;
		/// <summary>仕入伝票明細列変更後イベント用デリゲート</summary>
		private static EventHandler<SlipDtlColChangedEventArgs> _slipDtlColChanged = null;

		// 内部処理イベント用
		/// <summary>明細情報変更イベントハンドラデリゲート変数</summary>
		private static DataColumnChangeEventHandler _slipDtlChanging = null;
		/// <summary>明細情報変更イベントハンドラデリゲート変数</summary>
		private static DataColumnChangeEventHandler _slipDtlChanged = null;
		#endregion

		//==================================================================
		//  コンストラクタ
		//==================================================================
		#region コンストラクタ
		/// <summary>
		/// 静的コンストラクタ
		/// </summary>
		static AdjustStockAcs()
		{
			// Static変数初期化
			instanceCnt = 0;

			// データテーブル作成
			CreateProductStockTable();
		}

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
        /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
		public AdjustStockAcs()
		{
            try
            {
                if (this._iStockAdjustDB == null)
                {
                    // リモートオブジェクト取得
                    this._iStockAdjustDB = (IStockAdjustDB)MediationStockAdjustDB.GetStockAdjustDB();
                }
            }
            catch (Exception)
            {
                this._iStockAdjustDB = null;
            }

			// 初回インスタンス化時のみ実行
			if (instanceCnt++ == 0)
			{
				// 自分自身
				myInstance = new AdjustStockAcs();

                // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                //ProductStockWorkToDataRow(null);
                // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            }

            // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._goodsAcs = new GoodsAcs();
            this._searchStockAcs = new SearchStockAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._employeeAcs = new EmployeeAcs();
            this._makerAcs = new MakerAcs();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._supplierAcs = new SupplierAcs();

            this._companyInfAcs = new CompanyInfAcs();  // 2011/07/25
            this._companyInf = new CompanyInf(); // 2011/07/25
            
            this._unitPriceCalculation = new UnitPriceCalculation();

            string errMsg;
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out errMsg);

            ReadStockMngTtlSt();
            ReadInitData();         // 単価算出クラス初期データ読込
            ReadTaxRate();          // 税率設定マスタ読込
            ReadBLGoodsCdUMnt();    // BL商品コードマスタ読込
            ReadWarehouse();        // 倉庫マスタ読込
            ReadSecInfoSet();       // 拠点情報設定マスタ読込
            ReadEmployee();         // 従業員マスタ読込
            ReadMakerUMnt();        // メーカーマスタ読込
            ReadSupplier();
            ReadCompanyInf();  //  掛率優先区分に追加   //  ADD 2011/07/25
            // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<
        }
		#endregion

        #region BL商品コードマスタ読込
        /// <summary>
        /// BL商品コードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL商品コードマスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            ArrayList retList;
            int status = this._blGoodsCdAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                {
                    if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                    }
                }
            }
        }
        #endregion BL商品コードマスタ読込

        #region 倉庫マスタ読込
        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadWarehouse()
        {
            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;
                int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim().PadLeft(4, '0'), warehouse);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion 倉庫マスタ読込

        #region 拠点情報設定マスタ読込
        /// <summary>
        /// 拠点情報設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報設定マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion 拠点情報設定マスタ読込

        #region 従業員マスタ読込
        /// <summary>
        /// 従業員マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadEmployee()
        {
            this._employeeDic = new Dictionary<string, Employee>();

            try
            {
                ArrayList retList;
                ArrayList retList2;
                int status = this._employeeAcs.SearchAll(out retList, out retList2, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Employee employee in retList)
                    {
                        if (employee.LogicalDeleteCode == 0)
                        {
                            // ---ADD 2009/05/26 不具合対応[13376] --------------------------------------->>>>>
                            // 管理者データは除く
                            if ((employee.UserAdminFlag == 1) || (employee.UserAdminFlag == 2))
                            {
                                continue;
                            }
                            // すでにAddされているものは除く
                            if (this._employeeDic.ContainsKey(employee.EmployeeCode.Trim().PadLeft(4, '0')))
                            {
                                continue;
                            }
                            // ---ADD 2009/05/26 不具合対応[13376] ---------------------------------------<<<<<

                            this._employeeDic.Add(employee.EmployeeCode.Trim().PadLeft(4, '0'), employee);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion 従業員マスタ読込

        #region メーカーマスタ読込
        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;
                int status = this._makerAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion メーカーマスタ読込

        public void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;
                int status = this._supplierAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        //  -------- ADD 2011/07/25 ---- >>>> 
        public void ReadCompanyInf()
        {
            this._companyInfAcs.Read(out this._companyInf, LoginInfoAcquisition.EnterpriseCode);

            // 掛率優先区分
            if (this._companyInf != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._companyInf.RatePriorityDiv;
            }
        }
        //  -------- ADD 2011/07/25 ---- <<<<


        #region BL商品コード名称取得
        /// <summary>
        /// BL商品コード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <returns>BL商品コード名称</returns>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode) == true)
            {
                blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return blGoodsName;
        }
        #endregion BL商品コード名称取得

        #region 倉庫名称取得
        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim().PadLeft(4, '0')].WarehouseName.Trim();
            }

            return warehouseName;
        }
        #endregion 倉庫名称取得

        #region 拠点名称取得
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')].SectionGuideNm.Trim();
            }

            return sectionName;
        }
        #endregion 拠点名称取得

        #region 従業員名称取得
        /// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 従業員名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._employeeDic.ContainsKey(employeeCode.Trim().PadLeft(4, '0')))
            {
                employeeName = this._employeeDic[employeeCode.Trim().PadLeft(4, '0')].Name.Trim();
            }

            return employeeName;
        }
        #endregion 従業員名称取得

        #region メーカー名称取得
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerDic.ContainsKey(makerCode))
            {
                makerName = this._makerDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }
        #endregion メーカー名称取得

        private string GetSupplierSnm(int supplierCd)
        {
            if (this._supplierDic.ContainsKey(supplierCd))
            {
                return (this._supplierDic[supplierCd].SupplierSnm.Trim());
            }
            else
            {
                return "";
            }
        }
        //==================================================================
		//  パブリックプロパティ
		//==================================================================
		#region パブリックプロパティ
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
/*
                if (this.DataChanged != null)
                {
                    this.DataChanged(this, new EventArgs());
                }
 */ 
            }
        }
		public static DataTable ProductStockDataTable
		{
			get { return _mainProductStock; }
		}

		/// <summary>伝票明細DataView(ダミー行を含む)</summary>
		public static DataView AdjustStockView
		{
			get
			{
				return mainAdjustStockDtlFullView;
			}
		}

		/// <summary>伝票明細件数</summary>
		public static int SlipDtlCount
		{
			get
			{
				if (_mainProductStock != null)
				{
					return _mainProductStockView.Count;
				}
				else
				{
					return 0;
				}
			}
		}

        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>貼り付け用データ有無</summary>
		//public static bool HasClipboardData
		//{
		//	get
		//	{
		//		return ((suplSlipDtlClipboard != null) && (suplSlipDtlClipboard.Count > 0));
		//	}
		//}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

		#endregion

        #region 2007.10.11 削除
        //==================================================================
		//  パブリックメソッド
		//==================================================================
		#region パブリックメソッド
        //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 新規伝票明細初期値クラス取得
        ///// </summary>
		///// <returns>新規伝票クラス</returns>
		//public static ProductStock GetNewSlipDtl()
		//{
		//	ProductStock retData = new ProductStock();
        //	retData.LogicalDeleteCode = 0;
        //
        //	return retData;
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

		#endregion
        #endregion 2007.10.11 削除

        //==================================================================
		//  プライベートメソッド
		//==================================================================
		#region プライベートメソッド
		//--------------------------------------------------------
		//  Main Static Memory I/O
		//--------------------------------------------------------
		#region Main Static Memory I/O

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// (MainStaticMemory)初期化処理
		/// </summary>
		/// <param name="mode">コピーモード[0:両方, 1:リアルのみ]</param>
		private  void InitializeSlipProc(int mode)
		{
			// 企業コード
            mainStock.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番在庫データ生成
			//ProductStockWorkToDataRow(null);
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 単価算出クラス初期データ読込処理
        /// </summary>
        /// <remarks>
        /// Note       : 単価算出クラスに必要な初期データを読み込みます。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>原単価</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ、商品連結データより原単価を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private Double GetStockUnitPrice(Stock stock, GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // 商品連結データから単価算出結果オブジェクトを取得
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // 単価算出結果オブジェクトより原単価取得
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データより単価算出結果オブジェクトを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = GetDate();                                              // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, GetDate());         // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// Note       : 税率設定マスタを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public void ReadTaxRate()
        {
            int status;

            try
            {
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// 商品連結データリスト取得処理
        /// </summary>
        /// <param name="stockList">在庫マスタリスト</param>
        /// <param name="flag">伝票番号で検索するかどうかを判断する用のフラグ</param>
        /// <returns>商品連結データリスト</returns>
        /// <remarks>
        /// Note       : 在庫マスタリストより商品連結データリストを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private List<GoodsUnitData> GetGoodsUnitDataList(List<Stock> stockList, params bool[] flag)//add 2011/12/13 陳建明 Redmine #26816
        //private List<GoodsUnitData> GetGoodsUnitDataList(List<Stock> stockList)//del 2011/12/13 陳建明 Redmine #26816
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            if ((stockList == null) || (stockList.Count == 0))
            {
                return goodsUnitDataList;
            }

            int status;
            string errMsg;
            List<GoodsUnitData> retGoodsUnitDataList;

            foreach (Stock stock in stockList)
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                // 商品連結データ検索条件設定
                GoodsCndtn goodsCndtn;
                SetGoodsCndtn(out goodsCndtn, stock.EnterpriseCode, stock.GoodsMakerCd, stock.GoodsNo, GetStockSectionCode());

                try
                {
                    // 商品検索
                    status = GetGoodsUnitDataList(goodsCndtn, out retGoodsUnitDataList, out errMsg, flag);//add 2011/12/13 陳建明 Redmine #26816
                    //status = GetGoodsUnitDataList(goodsCndtn, out retGoodsUnitDataList, out errMsg);//del 2011/12/13 陳建明 Redmine #26816
                    if (status == 0)
                    {
                        goodsUnitData = retGoodsUnitDataList[0];
                    }
                    else
                    {
                        goodsUnitData = new GoodsUnitData();
                    }
                }
                catch
                {
                    goodsUnitData = new GoodsUnitData();
                }

                goodsUnitDataList.Add(goodsUnitData);
            }

            return goodsUnitDataList;
        }

        /// <summary>
        /// 商品連結データリスト取得処理
        /// </summary>
        /// <param name="goodsCndtn">商品連結データ検索条件</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="flag">伝票番号で検索するかどうかを判断する用のフラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 商品連結データリストを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int GetGoodsUnitDataList(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string errMsg, params bool[] flag)//add 2011/12/13 陳建明 Redmine #26816
        //public int GetGoodsUnitDataList(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string errMsg)//del 2011/12/13 陳建明 Redmine #26816
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            errMsg = "";
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //status = this._goodsAcs.SearchGoods(goodsCndtn, out goodsUnitDataList, out errMsg);
                status = this._goodsAcs.SearchGoods(goodsCndtn, 3200, out goodsUnitDataList, out errMsg, flag);//add 2011/12/13 陳建明 Redmine #26816
                //status = this._goodsAcs.SearchGoods(goodsCndtn, 3200, out goodsUnitDataList, out errMsg);//del 2011/12/13 陳建明 Redmine #26816
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (status == 0)
                {
                    if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        errMsg = "商品情報の取得に失敗しました。";
                        goodsUnitDataList = new List<GoodsUnitData>();

                        return (status);
                    }

                    if ((goodsUnitDataList[0].StockList == null) || (goodsUnitDataList[0].StockList.Count == 0))
                    {
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        //status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //errMsg = "選択した商品は在庫情報に登録されていません。";
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "選択した商品は在庫登録されていません。";
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        // MEMO:在庫なし時でも検索結果を初期化しない
                        //goodsUnitDataList = new List<GoodsUnitData>();
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

                        return (status);
                    }
                }
                else if (status == -1)
                {
                    // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                    // 同一品番選択ウィンドウでキャンセルしたとき
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    errMsg = "";
                    goodsUnitDataList = new List<GoodsUnitData>();
                    // --- ADD m.suzuki 2010/01/14 ----------<<<<<
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    //errMsg = "入力した品番は在庫情報に登録されていません。";
                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                    errMsg = "選択した商品は商品登録されていません。";  // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                    goodsUnitDataList = new List<GoodsUnitData>();

                    return (status);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = "商品情報の取得に失敗しました。";
                goodsUnitDataList = new List<GoodsUnitData>();
            }

            return (status);
        }

        // 2010/07/14 Add >>>
        /// <summary>
        /// 商品連結データリスト取得処理
        /// </summary>
        /// <param name="goodsCndtn">商品連結データ検索条件</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 商品連結データリストを取得します。<br />
        /// Programer  : 30517 夏野 駿希<br />
        /// Date       : 2010/07/14<br />
        /// </remarks>
        public int GetGoodsUnitDataList(GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string errMsg, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            errMsg = "";
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                // 2009.02.19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //status = this._goodsAcs.SearchGoods(goodsCndtn, out goodsUnitDataList, out errMsg);
                status = this._goodsAcs.Search(goodsCndtn, logicalMode, out goodsUnitDataList, out errMsg);
                // 2009.02.19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (status == 0)
                {
                    if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        errMsg = "商品情報の取得に失敗しました。";
                        goodsUnitDataList = new List<GoodsUnitData>();

                        return (status);
                    }

                    if ((goodsUnitDataList[0].StockList == null) || (goodsUnitDataList[0].StockList.Count == 0))
                    {
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        //status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //errMsg = "選択した商品は在庫情報に登録されていません。";
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "選択した商品は在庫登録されていません。";
                        // ADD 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                        // MEMO:在庫なし時でも検索結果を初期化しない
                        //goodsUnitDataList = new List<GoodsUnitData>();
                        // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<

                        return (status);
                    }
                }
                else if (status == -1)
                {
                    // --- ADD m.suzuki 2010/01/14 ---------->>>>>
                    // 同一品番選択ウィンドウでキャンセルしたとき
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    errMsg = "";
                    goodsUnitDataList = new List<GoodsUnitData>();
                    // --- ADD m.suzuki 2010/01/14 ----------<<<<<
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ---------->>>>>
                    //errMsg = "入力した品番は在庫情報に登録されていません。";
                    // DEL 2009/11/16 3次分対応 在庫登録機能を追加 ----------<<<<<
                    errMsg = "選択した商品は商品登録されていません。";  // ADD 2009/11/16 3次分対応 在庫登録機能を追加
                    goodsUnitDataList = new List<GoodsUnitData>();

                    return (status);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = "商品情報の取得に失敗しました。";
                goodsUnitDataList = new List<GoodsUnitData>();
            }

            return (status);
        }
        // 2010/07/14 Add <<<

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索 4:ハイフン無し完全一致</returns>
        /// <remarks>
        /// Note       : 商品検索タイプを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // *が存在しない
                if (searchCode.Contains("-") == true)
                {
                    // ハイフン含む
                    return 0;
                }
                else
                {
                    // ハイフン含まない
                    return 4;
                }
            }
        }

        /// <summary>
        /// 商品連結データ検索条件設定処理
        /// </summary>
        /// <param name="goodsCndtn">商品連結データ検索条件</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <remarks>
        /// Note       : 商品連結データ検索条件を設定します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public void SetGoodsCndtn(out GoodsCndtn goodsCndtn, string enterpriseCode, int makerCode, string goodsNo, string sectionCode)
        {
            string searchCode;

            goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = enterpriseCode;                         // 企業コード
            goodsCndtn.GoodsMakerCd = makerCode;                                // メーカーコード
            goodsCndtn.GoodsNoSrchTyp = GetSearchType(goodsNo, out searchCode); // 商品番号検索区分
            goodsCndtn.GoodsNo = searchCode;                                    // 品番
            goodsCndtn.GoodsKindCode = 9;                                       // 商品属性(全て)
            goodsCndtn.SectionCode = sectionCode;                               // 拠点コード
        }

        /// <summary>
        /// 在庫マスタ取得処理
        /// </summary>
        /// <param name="stockAdjustDtlList">在庫調整データリスト</param>
        /// <returns>在庫マスタリスト</returns>
        /// <remarks>
        /// Note       : 在庫調整明細データリストより在庫マスタリストを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private List<Stock> GetStockList(StockAdjust stockAdjust, List<StockAdjustDtl> stockAdjustDtlList)
        {
            List<Stock> stockList = new List<Stock>();

            string errMsg;
            int status;
            bool stockFlg = false;

            try
            {
                List<Stock> retList;
                StockSearchPara stockSearchPara;

                // 在庫調整明細データの数だけ在庫マスタを取得します
                foreach (StockAdjustDtl stockAdjustDtl in stockAdjustDtlList)
                {
                    stockFlg = false;

                    stockSearchPara = new StockSearchPara();
                    stockSearchPara.EnterpriseCode = stockAdjustDtl.EnterpriseCode;
                    //stockSearchPara.SectionCode = stockAdjust.StockSectionCd;
                    stockSearchPara.GoodsMakerCd = stockAdjustDtl.GoodsMakerCd;
                    stockSearchPara.GoodsNo = stockAdjustDtl.GoodsNo.Trim();
                    stockSearchPara.WarehouseCode = stockAdjustDtl.WarehouseCode;

                    // 在庫マスタ検索
                    status = this._searchStockAcs.Search(stockSearchPara, out retList, out errMsg);
                    if (status == 0)
                    {
                        foreach (Stock stock in retList)
                        {
                            stockList.Add(stock);
                            stockFlg = true;
                            break;
                        }

                        if (!stockFlg)
                        {
                            stockList.Add(new Stock());
                        }
                    }
                    else
                    {
                        stockList.Add(new Stock());
                    }
                }
            }
            catch
            {
                stockList = new List<Stock>();
            }

            return stockList;
        }

        /// <summary>
        /// 在庫マスタ取得処理
        /// </summary>
        /// <param name="orderListResultWorkList">発注残照会リモート抽出結果リスト</param>
        /// <returns>在庫マスタリスト</returns>
        /// <remarks>
        /// Note       : 発注残照会リモート抽出結果リストより在庫マスタリストを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private List<Stock> GetStockList(List<OrderListResultWork> orderListResultWorkList)
        {
            List<Stock> stockList = new List<Stock>();

            string errMsg;
            int status;
            bool stockFlg = false;

            try
            {
                List<Stock> retList;
                StockSearchPara stockSearchPara;

                // 在庫調整明細データの数だけ在庫マスタを取得します
                foreach (OrderListResultWork orderListResultWork in orderListResultWorkList)
                {
                    stockFlg = false;

                    stockSearchPara = new StockSearchPara();
                    stockSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    stockSearchPara.SectionCode = orderListResultWork.SectionCode;
                    stockSearchPara.GoodsMakerCd = orderListResultWork.GoodsMakerCd;
                    stockSearchPara.GoodsNo = orderListResultWork.GoodsNo.Trim();
                    stockSearchPara.WarehouseCode = orderListResultWork.WarehouseCode;

                    // 在庫マスタ検索
                    status = this._searchStockAcs.Search(stockSearchPara, out retList, out errMsg);
                    if (status == 0)
                    {
                        foreach (Stock stock in retList)
                        {
                            stockList.Add(stock);
                            stockFlg = true;
                            break;
                        }

                        if (!stockFlg)
                        {
                            stockList.Add(new Stock());
                        }
                    }
                    else
                    {
                        stockList.Add(new Stock());
                    }
                }
            }
            catch
            {
                stockList = new List<Stock>();
            }

            return stockList;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// 伝票明細データ追加・挿入・更新前処理
		///// </summary>
		///// <param name="data">対象明細データ</param>
		///// <param name="isUpdate">T:更新, F:追加・挿入</param>
		//private static void PreprocessSlipDtlInfoProc(ref ProductStock data, bool isUpdate)
		//{
		//	// 論理削除されていいないこと
		//	if (data.LogicalDeleteCode == 0)
		//	{
		//		if (isUpdate)
		//		{
		//			// 仕入明細別GUIDが未設定の場合
		//			if (data.ProductStockGuid == Guid.Empty)
		//			{
		//				// 仕入明細別GUIDを設定
		//				data.ProductStockGuid = Guid.NewGuid();
		//			}
		//		}
		//		else
		//		{
		//			// 仕入明細別GUIDを設定
		//			data.ProductStockGuid = Guid.NewGuid();
		//		}
		//	}
		//}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion 2007.10.11 削除

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 行フィルター整形処理
		/// </summary>
		/// <param name="rowFilter">行フィルター文字列</param>
		/// <returns>整形後の行フィルター文字列</returns>
		private static string FormRowFilter(string rowFilter)
		{
			string retFilter = rowFilter.Trim();

			// フィルターの設定(論理削除行を対象外とする)
			if (retFilter.Length == 0)
			{
				retFilter = string.Format("{0} = 0", ctCOL_LogicalDeleteCode);
			}
			else
			{
				retFilter = string.Format("({0}) AND {1} = 0", retFilter, ctCOL_LogicalDeleteCode);
			}

			return retFilter;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
        /// 明細行数増加処理
        /// </summary>
        public static int IncrementProductStock()
        {
            return IncrementSlipDtl();
        }

        /// <summary>
        /// 明細初期化処理
        /// </summary>
        public static int RepaintProductStock()
        {
            string msg;
            return CreateDummySlipDtl(out msg);
        }

		/// <summary>
		/// 明細行数増加処理
		/// </summary>
		/// <returns>0:成功, 以外:失敗</returns>
		private static int IncrementSlipDtl()
		{
			int wkCnt = maxRowCnt + ctCOUNT_RowAdd;
			if (wkCnt > ctCOUNT_RowMax)
			{
				if (ctCOUNT_RowMax - maxRowCnt > 0)
				{
					maxRowCnt = ctCOUNT_RowMax;
				}
				else
				{
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}
			}
			else
			{
				maxRowCnt = wkCnt;
			}

			string msg;
			return CreateDummySlipDtl(out msg);       
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 検索結果反映処理
        /// </summary>        
        public int ShowSelectData(out string retMessage)
        {
            int status = 0;
            retMessage = "";
            return status;
        }
        
        public int DbRowCount()
        {
            return _mainProductStockView.Count;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DBデータ読込処理
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="stockAdjust">在庫調整データ</param>
        /// <param name="stockAdjustDtlList">在庫調整明細データのリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// Note       : 在庫調整伝票番号より在庫調整データと在庫調整明細データリストを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int ReadDBData(int stockAdjustSlipNo, out StockAdjust stockAdjust, out List<StockAdjustDtl> stockAdjustDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            stockAdjust = new StockAdjust();
            stockAdjustDtlList = new List<StockAdjustDtl>();

            ArrayList retList = new ArrayList();
            ArrayList retListDtl = new ArrayList();

            try
            {
                status = this._iStockAdjustDB.SearchSlipAndDtl(LoginInfoAcquisition.EnterpriseCode, stockAdjustSlipNo, ref retList, ref retListDtl);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            stockAdjust = CopyToStockAdjustFromStockAdjustWork((StockAdjustWork)retList[0]);

                            foreach (StockAdjustDtlWork stockAdjustDtlWork in retListDtl)
                            {
                                stockAdjustDtlList.Add(CopyToStockAdjustDtlFromStockAdjustDtlWork(stockAdjustDtlWork));
                            }
                            break;
                        }
                    default:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            stockAdjust = new StockAdjust();
                            stockAdjustDtlList = new List<StockAdjustDtl>();
                            break;
                        }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                stockAdjust = new StockAdjust();
                stockAdjustDtlList = new List<StockAdjustDtl>();
            }

            return (status);
        }

        /// <summary>
        /// DB登録処理
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <param name="priceUpdateFlg">価格マスタ更新フラグ(True:更新　False:非更新)</param>
        /// <param name="orderListResultFlg">発注残履歴修正フラグ(True:修正　Fales:非修正)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データを登録します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public int SaveDBData(out int stockAdjustSlipNo, out string retMessage, out bool isNew, bool priceUpdateFlg, bool orderListResultFlg)
        {
            isNew = true;

            CustomSerializeArrayList registList = new CustomSerializeArrayList();

            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList goodsPriceWorkList = new ArrayList();

            StockAdjust stockAdjust;
            StockAdjustDtl stockAdjustDtl;
            GoodsPrice goodsPrice;

            // 保存用データ
            // DEL 2009/06/17 ------>>>
            //Dictionary<string, DataRow> saveStokRowDic = new Dictionary<string, DataRow>();
            //int makerCode;
            //string goodsNo;
            //string key;
            
            //for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            //{
            //    if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
            //        ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
            //    {
            //        continue;
            //    }

            //    // Key作成
            //    makerCode = StringObjToInt(_mainProductStock.Rows[index][ctCOL_GoodsMakerCd]);
            //    goodsNo = (string)_mainProductStock.Rows[index][ctCOL_GoodsNo];
            //    key = makerCode.ToString("0000") + goodsNo.Trim();

            //    if (saveStokRowDic.ContainsKey(key))
            //    {
            //        // 同一品番が存在する場合は、仕入数を合算
            //        saveStokRowDic[key][ctCOL_SalesOrderUnit] = (double)saveStokRowDic[key][ctCOL_SalesOrderUnit] +
            //                                                    (double)_mainProductStock.Rows[index][ctCOL_SalesOrderUnit];
            //        saveStokRowDic[key][ctCOL_BfStockUnitPrice] = (double)_mainProductStock.Rows[index][ctCOL_BfStockUnitPrice];
            //        saveStokRowDic[key][ctCOL_StockUnitPrice] = (double)_mainProductStock.Rows[index][ctCOL_StockUnitPrice];
            //        saveStokRowDic[key][ctCOL_ListPriceFl] = (double)_mainProductStock.Rows[index][ctCOL_ListPriceFl];
            //    }
            //    else
            //    {
            //        // 保存用データに追加
            //        saveStokRowDic.Add(key, _mainProductStock.Rows[index]);
            //    }
            //}
            // DEL 2009/06/17 ------<<<

            // ADD 2009/06/17 ------>>>
            Dictionary<int, DataRow> saveStokRowDic = new Dictionary<int, DataRow>();
            
            for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            {
                if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                if (!saveStokRowDic.ContainsKey(index))
                {
                    // 保存用データに追加
                    saveStokRowDic.Add(index, _mainProductStock.Rows[index]);
                }
            }
            // ADD 2009/06/17 ------<<<
            
            int count = 0;
            foreach (DataRow dataRow in saveStokRowDic.Values)
            {
                // 変更前の在庫調整データを取得
                stockAdjust = (StockAdjust)dataRow[ctCOL_StockAdjust];

                // 変更前の在庫調整明細データを取得
                stockAdjustDtl = (StockAdjustDtl)dataRow[ctCOL_StockAdjustDtl];

                // 画面情報を反映
                GetScreenInfo(ref stockAdjust, ref stockAdjustDtl, dataRow, orderListResultFlg);

                if (stockAdjust.FileHeaderGuid == Guid.Empty)
                {
                    isNew = true;
                }
                else
                {
                    isNew = false;
                }

                // 在庫調整データは１レコードだけ作成
                if (count == 0)
                {
                    // 在庫調整データ追加
                    stockAdjustWorkList.Add(CopyToStockAdjustWorkFromStockAdjust(stockAdjust));
                }

                // 在庫調整明細データ追加
                stockAdjustDtlWorkList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(stockAdjustDtl));

                if (priceUpdateFlg == true)
                {
                    // 更新対象の価格マスタを取得
                    if (dataRow[ctCOL_GoodsPrice] == DBNull.Value)
                    {
                        goodsPrice = new GoodsPrice();
                        goodsPrice.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPrice.PriceStartDate = GetDate();
                        goodsPrice.GoodsMakerCd = StringObjToInt(dataRow[ctCOL_GoodsMakerCd]);
                        goodsPrice.GoodsNo = (string)dataRow[ctCOL_GoodsNo];
                    }
                    else
                    {
                        goodsPrice = (GoodsPrice)dataRow[ctCOL_GoodsPrice];
                    }
                    goodsPrice.ListPrice = (double)dataRow[ctCOL_ListPriceFl]; ;          // 定価
                    goodsPrice.SalesUnitCost = (double)dataRow[ctCOL_StockUnitPrice];     // 原価

                    // 価格マスタ追加
                    goodsPriceWorkList.Add(CopyToGoodsPriceUWorkFromGoodsPrice(goodsPrice));
                }

                count++;
            }

            registList.Add(stockAdjustWorkList);
            registList.Add(stockAdjustDtlWorkList);

            if (priceUpdateFlg == true)
            {
                registList.Add(goodsPriceWorkList);
            }
            
            object paraObj = registList;

            // 登録処理
            int status;
            stockAdjustSlipNo = 0;
            retMessage = "";

            try
            {
                status = this._iStockAdjustDB.Write(ref paraObj, out retMessage);
                if (status == 0)
                {
                    CustomSerializeArrayList retList = (CustomSerializeArrayList)paraObj;
                    stockAdjustWorkList = (ArrayList)retList[0];
                    StockAdjustWork stockAdjustWork = (StockAdjustWork)stockAdjustWorkList[0];
                    
                    // 在庫調整伝票番号取得
                    stockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// DB削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データを削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public int DeleteDBData(out int slipNo)
        {
            slipNo = 0;

            CustomSerializeArrayList deleteList = new CustomSerializeArrayList();

            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();

            StockAdjust stockAdjust;
            StockAdjustDtl stockAdjustDtl;

            // 保存用データ
            Dictionary<string, DataRow> deleteStokRowDic = new Dictionary<string, DataRow>();

            for (int index = 0; index < _mainProductStock.Rows.Count; index++)
            {
                if ((_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                    ((Guid)_mainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                {
                    continue;
                }

                // 変更前の在庫調整データを取得
                stockAdjust = (StockAdjust)_mainProductStock.Rows[index][ctCOL_StockAdjust];
                slipNo = stockAdjust.StockAdjustSlipNo;

                // 変更前の在庫調整明細データを取得
                stockAdjustDtl = (StockAdjustDtl)_mainProductStock.Rows[index][ctCOL_StockAdjustDtl];

                // 在庫調整データは１レコードだけ作成
                if (index == 0)
                {
                    // 在庫調整データ追加
                    stockAdjustWorkList.Add(CopyToStockAdjustWorkFromStockAdjust(stockAdjust));
                }

                // 在庫調整明細データ追加
                stockAdjustDtlWorkList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(stockAdjustDtl));
            }

            deleteList.Add(stockAdjustWorkList);
            deleteList.Add(stockAdjustDtlWorkList);

            object paraObj = deleteList;
            string errMsg;

            // 登録処理
            int status;

            try
            {
                status = this._iStockAdjustDB.Delete(ref paraObj, out errMsg);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DB登録処理
        /// </summary>
        /// <param name="retMessage"></param>
        public int SaveDBData(out string retMessage, int mode, string setMsg, DateTime adjustDate)
        {
            CustomSerializeArrayList registList = new CustomSerializeArrayList();

            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //製番在庫取得
            //ArrayList productArray = this.GetCurrentProductStock(mode);
            ////在庫
            //ArrayList stockArray = this.GetCurrentStock(mode,productArray);
            //在庫
            ArrayList stockArray = this.GetCurrentStock(mode);
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<

            registList.Add(stockArray);

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////製番在庫
            //if ((mode != ctMode_StockAdjust) &&(mode != ctMode_TrustAdjust) && (mode != ctMode_ProductReEdit))
            //{
            //    if (productArray.Count > 0)
            //    {
            //        registList.Add(productArray);
            //    }
            //}
            //else
            //{
            //    if (productArray.Count > 0)
            //    {
            //        //在庫のみ・製番単位入れ子処理
            //        registList.Add(productArray);
            //    }
            //}
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            //調整
            ArrayList stockAdjustArray = this.GetStockAdjust(mode, adjustDate, setMsg);
            registList.Add(stockAdjustArray);
            //調整明細
            ArrayList stockAdjustDtlArray = this.GetStockAdjustDtl(mode);
            registList.Add(stockAdjustDtlArray);
            object setObj = (object)registList;

            int status = 0;
            // 登録
            status = this._iStockAdjustDB.Write(ref setObj, out retMessage);

            return status;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
        /// DB登録用情報クリア(GRIDクリア)
        /// </summary>
        public void DBDataClear()
        {
            _mainProductStock.Clear();
        }

        /*
                /// <summary>
                /// 登録用在庫データ取得処理
                /// </summary>
                private ArrayList GetCurrentStock(int mode,ArrayList productList)
                {
                    ArrayList retList = new ArrayList();
                    ArrayList chkList = new ArrayList();
            
                    //在庫データをセット
                    foreach(Stock stockRet in _stockList)
                    {
                        //製番に存在するかチェックし、余計な在庫を削除
                        retList.Add(CopyToStockWorkFromStock(stockRet, mode));
                    }

                    return retList;
                }
        */

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private ArrayList GetCurrentStock(int mode, ArrayList productList)
        private ArrayList GetCurrentStock(int mode)
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            ArrayList retList = new ArrayList();
            ArrayList chkList = new ArrayList();

            //在庫データをセット
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //foreach (StockEachWarehouse stockRet in _stockList)
            foreach (StockExpansion stockRet in _stockList)
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            {
                retList.Add(CopyToStockWorkFromStock(stockRet, mode));
            }
            return retList;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫存在チェック
        /// </summary>
        private bool ChkStockExist(Stock stock,ArrayList productList)
        {
            bool result = false;
            result = true;

            return result;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 登録用製番在庫データ取得処理
        ///// </summary>
        //private ArrayList GetCurrentProductStock(int mode)
        //{
        //    ArrayList retList = new ArrayList();
        //    if ((mode == ctMode_StockAdjust) || (mode == ctMode_TrustAdjust))
        //    {
        //        //在庫調整
        //	    for (int i = 0; i < _mainProductStockView.Count; i++)
		//	    {
        //            if (_mainProductStockView[i].Row[ctCOL_AdjustCount] == DBNull.Value)
        //            {
        //                continue;
        //            }
        //            if ((double)_mainProductStockView[i].Row[ctCOL_AdjustCount] == 0)
        //            {
        //                continue;
        //            }
        //            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //            //// 製番マスタのみ書込み
        //            //if ((Int32)_mainProductStockView[i].Row[ctCOL_RowType] == 1)
        //            //{
        //            //    // 取得データをWORKへセット(GRID→DATASET→WORK)
        //            //    retList.Add(CopyToProductWorkFromProductStock(DataRowToProductStock(_mainProductStockView[i].Row,mode)));
        //            //}
        //            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        }
        //    }
        //    else if (mode == ctMode_UnitPriceReEdit)
        //    {
        //        //原価調整
        //        for (int i = 0; i < _mainProductStockView.Count; i++)
        //        {
        //            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //            //if ((Int32)_mainProductStockView[i].Row[ctCOL_RowType] == 1)
        //            //{
        //            //    // 取得データをWORKへセット(GRID→DATASET→WORK)
        //            //    retList.Add(CopyToProductWorkFromProductStock(DataRowToProductStock(_mainProductStockView[i].Row, mode)));
        //            //}
        //            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        }
        //    }
        //    else if (mode == ctMode_ProductReEdit || mode == ctMode_GoodsCodeStatus)
        //    {
        //        //製番変更 or 不良品(必ず製番単位)
        //        for (int i = 0; i < _mainProductStockView.Count; i++)
        //        {
        //            if (_mainProductStockView[i].Row[ctCOL_ProductNumber] == System.DBNull.Value)
        //            {
        //                continue;
        //            }
        //
        //            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        //            //// 製番マスタのみ書込み
        //            //if ((Int32)_mainProductStockView[i].Row[ctCOL_RowType] == 1)
        //            //{
        //            //    // 取得データをWORKへセット(GRID→DATASET→WORK)
        //            //    retList.Add(CopyToProductWorkFromProductStock(DataRowToProductStock(_mainProductStockView[i].Row, mode)));
        //            //}
        //            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        }
        //    }
        //    return retList;
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録用在庫調整データ取得処理
        /// </summary>
        private ArrayList GetStockAdjust(int mode, DateTime adjustdate, string setMsg)
        {
            ArrayList retList = new ArrayList();
            // 2008.03.28 修正 >>>>>>>>>>>>>>>>>>>>
            //retList.Add(CopyToStockAdjustWorkFromStockAdjust(DataRowToStockAdjust(_mainProductStockView[0].Row, mode, setMsg)));
            if (_mainProductStockView.Count > 0)
            {
                retList.Add(CopyToStockAdjustWorkFromStockAdjust(DataRowToStockAdjust(_mainProductStockView[0].Row, mode, setMsg)));
            }
            else
            {
                _mainProductStockView = new DataView(_mainProductStock);
                //_mainProductStockView.RowFilter = ctCOL_LogicalDeleteCode + " = 0";
                _mainProductStockView.RowFilter = ctCOL_RowNum + " = 1";
                retList.Add(CopyToStockAdjustWorkFromStockAdjust(DataRowToStockAdjust(_mainProductStockView[0].Row, mode, setMsg)));
            }
            // 2008.03.28 修正 <<<<<<<<<<<<<<<<<<<<
            return retList;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面情報取得処理
        /// </summary>
        /// <param name="stockAdjust">在庫調整データ</param>
        /// <param name="stockAdjustDtl">在庫調整明細データ</param>
        /// <param name="dataRow">対象行</param>
        /// <param name="orderListResultFlg">発注残履歴修正フラグ</param>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private void GetScreenInfo(ref StockAdjust stockAdjust, ref StockAdjustDtl stockAdjustDtl, DataRow dataRow, bool orderListResultFlg)
        {
            //------------------------------------------------------------
            // 在庫調整データ
            //------------------------------------------------------------
            // 企業コード
            stockAdjust.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            stockAdjust.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 在庫調整伝票番号
            stockAdjust.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // 受払元伝票区分(在庫仕入)
            stockAdjust.AcPaySlipCd = 13;
            // 受払元取引区分(在庫数調整)
            if (orderListResultFlg == true)
            {
                stockAdjust.AcPayTransCd = 10;
            }
            else
            {
                stockAdjust.AcPayTransCd = 30;
            }
            // 調整日付
            stockAdjust.AdjustDate = GetDate();
            // 入力日付
            stockAdjust.InputDay = DateTime.Today;
            // 仕入拠点コード
            stockAdjust.StockSectionCd = GetStockSectionCode();
            // 仕入拠点名称
            stockAdjust.StockSectionNm = GetSectionName(stockAdjust.StockSectionCd);
            // 仕入入力者コード
            stockAdjust.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            // 仕入入力者名称
            stockAdjust.StockInputName = LoginInfoAcquisition.Employee.Name.Trim();
            if (stockAdjust.StockInputName.Length > 16)
            {
                stockAdjust.StockInputName = stockAdjust.StockInputName.Substring(0, 16);
            }
            // 仕入担当者コード
            stockAdjust.StockAgentCode = GetInputAgentCode();
            // 仕入担当者名称
            stockAdjust.StockAgentName = GetEmployeeName(stockAdjust.StockAgentCode);
            if (stockAdjust.StockAgentName.Length > 16)
            {
                stockAdjust.StockAgentName = stockAdjust.StockAgentName.Substring(0, 16);
            }
            // 仕入金額小計
            stockAdjust.StockSubttlPrice = GetSubttlPrice();
            // 伝票備考
            stockAdjust.SlipNote = GetSlipNote();

            //------------------------------------------------------------
            // 在庫調整明細データ
            //------------------------------------------------------------
            // 企業コード
            stockAdjustDtl.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            stockAdjustDtl.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 在庫調整伝票番号
            stockAdjustDtl.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // 在庫調整行番号
            stockAdjustDtl.StockAdjustRowNo = (Int32)dataRow[ctCOL_RowNum];
            // 仕入形式(仕入)
            stockAdjustDtl.SupplierFormalSrc = (dataRow[ctCOL_SupplierFormalSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_SupplierFormalSrc] : 0;
            // 仕入明細通番
            stockAdjustDtl.StockSlipDtlNumSrc = (dataRow[ctCOL_StockSlipDtlNumSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockSlipDtlNumSrc] : 0;
            // 受払元伝票区分(在庫仕入)
            stockAdjustDtl.AcPaySlipCd = 13;
            // 受払元取引区分(在庫調整数)
            if (orderListResultFlg == true)
            {
                stockAdjustDtl.AcPayTransCd = 10;
            }
            else
            {
                stockAdjustDtl.AcPayTransCd = 30;
            }
            // 調整日付
            stockAdjustDtl.AdjustDate = GetDate();
            // 入力日付
            stockAdjustDtl.InputDay = DateTime.Today;
            // メーカーコード
            stockAdjustDtl.GoodsMakerCd = StringObjToInt(dataRow[ctCOL_GoodsMakerCd]);
            // メーカー名称
            stockAdjustDtl.MakerName = GetMakerName(stockAdjustDtl.GoodsMakerCd);
            // 品番
            stockAdjustDtl.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // 品名
            stockAdjustDtl.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // 仕入単価
            stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_StockUnitPrice] : 0;
            // 変更前仕入単価
            stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_BfStockUnitPrice] : 0;
            // 調整数(仕入数をセット)
            stockAdjustDtl.AdjustCount = (double)dataRow[ctCOL_SalesOrderUnit];
            // 明細備考
            stockAdjustDtl.DtlNote = (dataRow[ctCOL_DtlNote] != DBNull.Value) ? (string)dataRow[ctCOL_DtlNote] : "";
            // 倉庫コード
            stockAdjustDtl.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // 倉庫名称
            stockAdjustDtl.WarehouseName = GetWarehouseName(stockAdjustDtl.WarehouseCode);
            // BL商品コード
            stockAdjustDtl.BLGoodsCode = StringObjToInt(dataRow[ctCOL_BLGoodsCode]);
            // BL商品名称
            stockAdjustDtl.BLGoodsFullName = GetBLGoodsName(stockAdjustDtl.BLGoodsCode);
            // 倉庫棚番
            stockAdjustDtl.WarehouseShelfNo = (dataRow[ctCOL_WarehouseShelfNo] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseShelfNo] : "";
            // 定価
            stockAdjustDtl.ListPriceFl = (dataRow[ctCOL_ListPriceFl] != DBNull.Value) ? (Double)dataRow[ctCOL_ListPriceFl] : 0;
            
            // オープン価格区分
            stockAdjustDtl.OpenPriceDiv = (dataRow[ctCOL_OpenPriceDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_OpenPriceDiv] : 0;

            // 仕入金額
            if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((double)dataRow[ctCOL_StockUnitPrice] == 0) ||
                (dataRow[ctCOL_SalesOrderUnit] == DBNull.Value) || ((double)dataRow[ctCOL_SalesOrderUnit] == 0))
            {
                stockAdjustDtl.StockPriceTaxExc = 0;
            }
            // ---ADD 2009/06/23 不具合対応[13602] ---------------------------------------------->>>>>
            //新規登録の場合
            else if (stockAdjust.FileHeaderGuid == Guid.Empty)
            {
                stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
            }
            // ---ADD 2009/06/23 不具合対応[13602] ----------------------------------------------<<<<<
            else
            {
                if (((double)dataRow[ctCOL_StockUnitPrice] != (double)dataRow[ctCOL_BfStockUnitPrice]) ||
                    ((double)dataRow[ctCOL_SalesOrderUnit] != (double)dataRow[ctCOL_BfSalesOrderUnit]))
                {
                    stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
                }
                else
                {
                    stockAdjustDtl.StockPriceTaxExc = (long)dataRow[ctCOL_StockPriceTaxExc];
                }
            }

            // 仕入先
            stockAdjustDtl.SupplierCd = (dataRow[ctCOL_SupplierCd] != DBNull.Value) ? int.Parse((string)dataRow[ctCOL_SupplierCd]) : 0;
            // 仕入先略称
            stockAdjustDtl.SupplierSnm = (dataRow[ctCOL_SupplierSnm] != DBNull.Value) ? (string)dataRow[ctCOL_SupplierSnm] : "";
        }

        /// <summary>
        /// クラスメンバコピー処理(在庫調整データ→在庫調整データワーク)
        /// </summary>
        /// <param name="stockAdjust">在庫調整データ</param>
        /// <returns>在庫調整データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データを在庫調整データワーククラスにコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjustWork CopyToStockAdjustWorkFromStockAdjust(StockAdjust stockAdjust)
        {
            StockAdjustWork stockAdjustWork = new StockAdjustWork();

            stockAdjustWork.CreateDateTime = stockAdjust.CreateDateTime;                // 作成日時
            stockAdjustWork.UpdateDateTime = stockAdjust.UpdateDateTime;                // 更新日時
            stockAdjustWork.EnterpriseCode = stockAdjust.EnterpriseCode;                // 企業コード
            stockAdjustWork.FileHeaderGuid = stockAdjust.FileHeaderGuid;                // GUID
            stockAdjustWork.UpdEmployeeCode = stockAdjust.UpdEmployeeCode;              // 更新従業員コード
            stockAdjustWork.UpdAssemblyId1 = stockAdjust.UpdAssemblyId1;                // 更新あ戦ぶりID1
            stockAdjustWork.UpdAssemblyId2 = stockAdjust.UpdAssemblyId2;                // 更新アセンブリID2
            stockAdjustWork.LogicalDeleteCode = stockAdjust.LogicalDeleteCode;          // 論理削除区分
            stockAdjustWork.SectionCode = stockAdjust.SectionCode;                      // 拠点コード
            stockAdjustWork.SectionGuideNm = GetSectionName(stockAdjust.SectionCode);  // 拠点名称
            stockAdjustWork.StockAdjustSlipNo = stockAdjust.StockAdjustSlipNo;          // 在庫調整伝票番号
            stockAdjustWork.AcPaySlipCd = stockAdjust.AcPaySlipCd;                      // 受払元伝票区分
            stockAdjustWork.AcPayTransCd = stockAdjust.AcPayTransCd;                    // 受払元取引区分
            stockAdjustWork.AdjustDate = stockAdjust.AdjustDate;                        // 調整日付
            stockAdjustWork.InputDay = stockAdjust.InputDay;                            // 入力日付
            stockAdjustWork.StockSectionCd = stockAdjust.StockSectionCd;                // 仕入拠点コード
            stockAdjustWork.StockSectionGuideNm = GetSectionName(stockAdjust.StockSectionCd);   // 仕入拠点名称
            stockAdjustWork.StockInputCode = stockAdjust.StockInputCode;                // 仕入入力者コード
            stockAdjustWork.StockInputName = GetEmployeeName(stockAdjust.StockInputCode);       // 仕入入力者名称
            if (stockAdjustWork.StockInputName.Length > 16)
            {
                stockAdjustWork.StockInputName = stockAdjustWork.StockInputName.Substring(0, 16);
            }
            stockAdjustWork.StockAgentCode = stockAdjust.StockAgentCode;                // 仕入担当者コード
            stockAdjustWork.StockAgentName = GetEmployeeName(stockAdjust.StockAgentCode);       // 仕入担当者名称
            if (stockAdjustWork.StockAgentName.Length > 16)
            {
                stockAdjustWork.StockAgentName = stockAdjustWork.StockAgentName.Substring(0, 16);
            }
            stockAdjustWork.StockSubttlPrice = stockAdjust.StockSubttlPrice;            // 仕入金額小計
            stockAdjustWork.SlipNote = stockAdjust.SlipNote;                            // 伝票備考

            return stockAdjustWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(在庫調整明細データ→在庫調整明細データワーク)
        /// </summary>
        /// <param name="stockAdjustDtl">在庫調整明細データ</param>
        /// <returns>在庫調整明細データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データを在庫調整明細データワーククラスにコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjustDtlWork CopyToStockAdjustDtlWorkFromStockAdjustDtl(StockAdjustDtl stockAdjustDtl)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();

            stockAdjustDtlWork.CreateDateTime = stockAdjustDtl.CreateDateTime;                  // 作成日時
            stockAdjustDtlWork.UpdateDateTime = stockAdjustDtl.UpdateDateTime;                  // 更新日時
            stockAdjustDtlWork.EnterpriseCode = stockAdjustDtl.EnterpriseCode;                  // 企業コード
            stockAdjustDtlWork.FileHeaderGuid = stockAdjustDtl.FileHeaderGuid;                  // GUID
            stockAdjustDtlWork.UpdEmployeeCode = stockAdjustDtl.UpdEmployeeCode;                // 更新従業員コード
            stockAdjustDtlWork.UpdAssemblyId1 = stockAdjustDtl.UpdAssemblyId1;                  // 更新アセンブリID1
            stockAdjustDtlWork.UpdAssemblyId2 = stockAdjustDtl.UpdAssemblyId2;                  // 更新アセンブリID2
            stockAdjustDtlWork.LogicalDeleteCode = stockAdjustDtl.LogicalDeleteCode;            // 論理削除区分
            stockAdjustDtlWork.SectionCode = stockAdjustDtl.SectionCode;                        // 拠点コード
            stockAdjustDtlWork.SectionGuideNm = GetSectionName(stockAdjustDtl.SectionCode);     // 拠点名称
            stockAdjustDtlWork.StockAdjustSlipNo = stockAdjustDtl.StockAdjustSlipNo;            // 在庫調整伝票番号
            stockAdjustDtlWork.StockAdjustRowNo = stockAdjustDtl.StockAdjustRowNo;              // 在庫調整行番号
            stockAdjustDtlWork.SupplierFormalSrc = stockAdjustDtl.SupplierFormalSrc;            // 仕入形式(元)
            stockAdjustDtlWork.StockSlipDtlNumSrc = stockAdjustDtl.StockSlipDtlNumSrc;          // 仕入明細通番(元)
            stockAdjustDtlWork.AcPaySlipCd = stockAdjustDtl.AcPaySlipCd;                        // 受払元伝票区分
            stockAdjustDtlWork.AcPayTransCd = stockAdjustDtl.AcPayTransCd;                      // 受払元取引区分
            stockAdjustDtlWork.AdjustDate = stockAdjustDtl.AdjustDate;                          // 調整日付
            stockAdjustDtlWork.InputDay = stockAdjustDtl.InputDay;                              // 入力日付
            stockAdjustDtlWork.GoodsMakerCd = stockAdjustDtl.GoodsMakerCd;                      // メーカーコード
            stockAdjustDtlWork.MakerName = stockAdjustDtl.MakerName;                            // メーカー名称s
            stockAdjustDtlWork.GoodsNo = stockAdjustDtl.GoodsNo;                                // 品番
            stockAdjustDtlWork.GoodsName = stockAdjustDtl.GoodsName;                            // 品名
            stockAdjustDtlWork.StockUnitPriceFl = stockAdjustDtl.StockUnitPriceFl;              // 仕入単価
            stockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtl.BfStockUnitPriceFl;          // 変更前仕入単価
            stockAdjustDtlWork.AdjustCount = stockAdjustDtl.AdjustCount;                        // 調整数
            stockAdjustDtlWork.DtlNote = stockAdjustDtl.DtlNote;                                // 明細備考
            stockAdjustDtlWork.WarehouseCode = stockAdjustDtl.WarehouseCode;                    // 倉庫コード
            stockAdjustDtlWork.WarehouseName = stockAdjustDtl.WarehouseName;                    // 倉庫名称
            stockAdjustDtlWork.BLGoodsCode = stockAdjustDtl.BLGoodsCode;                        // BL商品コード
            stockAdjustDtlWork.BLGoodsFullName = stockAdjustDtl.BLGoodsFullName;                // BL商品名称
            stockAdjustDtlWork.WarehouseShelfNo = stockAdjustDtl.WarehouseShelfNo;              // 倉庫棚番
            stockAdjustDtlWork.ListPriceFl = stockAdjustDtl.ListPriceFl;                        // 定価
            stockAdjustDtlWork.OpenPriceDiv = stockAdjustDtl.OpenPriceDiv;                      // オープン価格区分
            stockAdjustDtlWork.StockPriceTaxExc = stockAdjustDtl.StockPriceTaxExc;              // 仕入金額
            stockAdjustDtlWork.SupplierCd = stockAdjustDtl.SupplierCd;                          // 仕入先コード
            stockAdjustDtlWork.SupplierSnm = stockAdjustDtl.SupplierSnm;                        // 仕入先略称
            
            return stockAdjustDtlWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(価格マスタ→価格マスタワーク)
        /// </summary>
        /// <param name="goodsPrice">価格マスタ</param>
        /// <returns>価格マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 価格マスタを価格マスタワーククラスにコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPrice(GoodsPrice goodsPrice)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;         // 作成日時
            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;         // 更新日時
            goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;         // 企業コード
            goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;         // GUID
            goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;       // 更新従業員コード
            goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;         // 更新アセンブリID1
            goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;         // 更新アセンブリID2
            goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;   // 論理削除区分
            goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;             // メーカーコード
            goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;                       // 品番
            goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;         // 価格開始日
            goodsPriceUWork.ListPrice = goodsPrice.ListPrice;                   // 定価
            goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;           // 原価
            goodsPriceUWork.StockRate = goodsPrice.StockRate;                   // 仕入率
            goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;             // オープン価格区分
            goodsPriceUWork.OfferDate = goodsPrice.OfferDate;                   // 提供日付
            goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;                 // 更新年月日

            return goodsPriceUWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(在庫調整データワーク→在庫調整データ)
        /// </summary>
        /// <param name="stockAdjustWork">在庫調整データワーククラス</param>
        /// <returns>在庫調整データ</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データワークを在庫調整データクラスにコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjust CopyToStockAdjustFromStockAdjustWork(StockAdjustWork stockAdjustWork)
        {
            StockAdjust stockAdjust = new StockAdjust();

            stockAdjust.CreateDateTime = stockAdjustWork.CreateDateTime;        // 作成日時
            stockAdjust.UpdateDateTime = stockAdjustWork.UpdateDateTime;        // 更新日時
            stockAdjust.EnterpriseCode = stockAdjustWork.EnterpriseCode;        // 企業コード
            stockAdjust.FileHeaderGuid = stockAdjustWork.FileHeaderGuid;        // GUID
            stockAdjust.UpdEmployeeCode = stockAdjustWork.UpdEmployeeCode;      // 更新従業員コード
            stockAdjust.UpdAssemblyId1 = stockAdjustWork.UpdAssemblyId1;        // 更新アセンブリID1
            stockAdjust.UpdAssemblyId2 = stockAdjustWork.UpdAssemblyId2;        // 更新アセンブリID2
            stockAdjust.LogicalDeleteCode = stockAdjustWork.LogicalDeleteCode;  // 論理削除区分
            stockAdjust.SectionCode = stockAdjustWork.SectionCode;              // 拠点コード
            stockAdjust.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo;  // 在庫調整伝票番号
            stockAdjust.AcPaySlipCd = stockAdjustWork.AcPaySlipCd;              // 受払元伝票区分
            stockAdjust.AcPayTransCd = stockAdjustWork.AcPayTransCd;            // 受払元取引区分
            stockAdjust.AdjustDate = stockAdjustWork.AdjustDate;                // 調整日付
            stockAdjust.InputDay = stockAdjustWork.InputDay;                    // 入力日付
            stockAdjust.StockSectionCd = stockAdjustWork.StockSectionCd;        // 仕入拠点コード
            stockAdjust.StockSectionNm = stockAdjustWork.StockSectionGuideNm;   // 仕入拠点名称
            stockAdjust.StockInputCode = stockAdjustWork.StockInputCode;        // 仕入入力者コード
            stockAdjust.StockInputName = stockAdjustWork.StockInputName;        // 仕入入力者名称
            stockAdjust.StockAgentCode = stockAdjustWork.StockAgentCode;        // 仕入担当者コード
            stockAdjust.StockAgentName = stockAdjustWork.StockAgentName;        // 仕入担当者名称
            stockAdjust.StockSubttlPrice = stockAdjustWork.StockSubttlPrice;    // 仕入金額小計
            stockAdjust.SlipNote = stockAdjustWork.SlipNote;                    // 伝票備考

            return stockAdjust;
        }

        /// <summary>
        /// クラスメンバコピー処理(在庫調整明細データワーク→在庫調整明細データ)
        /// </summary>
        /// <param name="stockAdjustDtlWork">在庫調整明細データワーククラス</param>
        /// <returns>在庫調整明細データ</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワークを在庫調整明細データクラスにコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private StockAdjustDtl CopyToStockAdjustDtlFromStockAdjustDtlWork(StockAdjustDtlWork stockAdjustDtlWork)
        {
            StockAdjustDtl stockAdjustDtl = new StockAdjustDtl();

            stockAdjustDtl.CreateDateTime = stockAdjustDtlWork.CreateDateTime;          // 作成日時
            stockAdjustDtl.UpdateDateTime = stockAdjustDtlWork.UpdateDateTime;          // 更新日時
            stockAdjustDtl.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;          // 企業コード
            stockAdjustDtl.FileHeaderGuid = stockAdjustDtlWork.FileHeaderGuid;          // GUID
            stockAdjustDtl.UpdEmployeeCode = stockAdjustDtlWork.UpdEmployeeCode;        // 更新従業員コード
            stockAdjustDtl.UpdAssemblyId1 = stockAdjustDtlWork.UpdAssemblyId1;          // 更新アセンブリID1
            stockAdjustDtl.UpdAssemblyId2 = stockAdjustDtlWork.UpdAssemblyId2;          // 更新アセンブリID2
            stockAdjustDtl.LogicalDeleteCode = stockAdjustDtlWork.LogicalDeleteCode;    // 論理削除区分
            stockAdjustDtl.SectionCode = stockAdjustDtlWork.SectionCode;                // 拠点コード
            stockAdjustDtl.StockAdjustSlipNo = stockAdjustDtlWork.StockAdjustSlipNo;    // 在庫調整伝票番号
            stockAdjustDtl.StockAdjustRowNo = stockAdjustDtlWork.StockAdjustRowNo;      // 在庫調整行番号
            stockAdjustDtl.SupplierFormalSrc = stockAdjustDtlWork.SupplierFormalSrc;    // 仕入形式(元)
            stockAdjustDtl.StockSlipDtlNumSrc = stockAdjustDtlWork.StockSlipDtlNumSrc;  // 仕入明細通番(元)
            stockAdjustDtl.AcPaySlipCd = stockAdjustDtlWork.AcPaySlipCd;                // 受払元伝票区分
            stockAdjustDtl.AcPayTransCd = stockAdjustDtlWork.AcPayTransCd;              // 受払元取引区分
            stockAdjustDtl.AdjustDate = stockAdjustDtlWork.AdjustDate;                  // 調整日付
            stockAdjustDtl.InputDay = stockAdjustDtlWork.InputDay;                      // 入力日付
            stockAdjustDtl.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;              // メーカーコード
            stockAdjustDtl.MakerName = stockAdjustDtlWork.MakerName;                    // メーカー名称
            stockAdjustDtl.GoodsNo = stockAdjustDtlWork.GoodsNo;                        // 品番
            stockAdjustDtl.GoodsName = stockAdjustDtlWork.GoodsName;                    // 品名
            stockAdjustDtl.StockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;      // 仕入単価
            stockAdjustDtl.BfStockUnitPriceFl = stockAdjustDtlWork.BfStockUnitPriceFl;  // 変更前仕入単価
            stockAdjustDtl.AdjustCount = stockAdjustDtlWork.AdjustCount;                // 調整数
            stockAdjustDtl.DtlNote = stockAdjustDtlWork.DtlNote;                        // 明細備考
            stockAdjustDtl.WarehouseCode = stockAdjustDtlWork.WarehouseCode;            // 倉庫コード
            stockAdjustDtl.WarehouseName = stockAdjustDtlWork.WarehouseName;            // 倉庫名称
            stockAdjustDtl.BLGoodsCode = stockAdjustDtlWork.BLGoodsCode;                // BL商品コード
            stockAdjustDtl.BLGoodsFullName = stockAdjustDtlWork.BLGoodsFullName;        // BL商品コード名称(全角)
            stockAdjustDtl.WarehouseShelfNo = stockAdjustDtlWork.WarehouseShelfNo;      // 倉庫棚番
            stockAdjustDtl.ListPriceFl = stockAdjustDtlWork.ListPriceFl;                // 定価
            stockAdjustDtl.OpenPriceDiv = stockAdjustDtlWork.OpenPriceDiv;              // オープン価格区分
            stockAdjustDtl.StockPriceTaxExc = stockAdjustDtlWork.StockPriceTaxExc;      // 仕入金額

            return stockAdjustDtl;
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録用在庫調整明細データ取得処理
        /// </summary>
        private ArrayList GetStockAdjustDtl(int mode)
        {
            ArrayList retList = new ArrayList();
            string warehouseCode = "";
            string warehouseName = "";
            for (int i = 0; i < _mainProductStockView.Count; i++)
            {
                warehouseCode = (_mainProductStockView[i].Row[ctCOL_WarehouseCode] != DBNull.Value) ? (string)_mainProductStockView[i].Row[ctCOL_WarehouseCode] : "";
                warehouseName = (_mainProductStockView[i].Row[ctCOL_WarehouseName] != DBNull.Value) ? (string)_mainProductStockView[i].Row[ctCOL_WarehouseName] : "";

                retList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(DataRowToStockAdjustDtl(_mainProductStockView[i].Row, mode, i), warehouseCode, warehouseName, mode));
            }
            return retList;
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #endregion

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		//--------------------------------------------------------
		//  仕入管理アクセスクラスイベントハンドラ関連
		//--------------------------------------------------------
		#region 仕入管理アクセスクラスイベントハンドラ関連
		/// <summary>
		/// 仕入管理アクセスクラス初期化イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="mode">コピーモード[0:両方, 1:リアルのみ]</param>
		private  void InfoInitStockMngEvent(object sender, int mode)
		{
			// 仕入伝票Static初期化処理
			InitializeSlipProc(mode);
		}

		/// <summary>
		/// 仕入管理アクセスクラス読込イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="stockMngList">読込みデータコレクション</param>
		private  void InfoReadStockMngEvent(object sender, CustomSerializeArrayList stockMngList)
		{
			// Static情報クリア
			mainStock = null;
			_mainProductStock.Clear();

			// CustomSerializeArrayListよりデータ取得
			foreach (object wkObj in stockMngList)
			{
				// 仕入伝票データ
				if (wkObj is StockWork)
				{
					mainStock = CopyToStockDataFromStockWork(wkObj as StockWork);
					continue;
				}

				// 仕入伝票明細データ
				if (wkObj is ArrayList)
				{
					ArrayList wkList = wkObj as ArrayList;

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //if ((wkList.Count > 0) && (wkList[0] is ProductStockWork))
					//{
					//	ProductStockWorkToDataRow(wkList);
					//	continue;
					//}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                }

				// 仕入先・支払先情報を取得
				if (wkObj is CustSuppliWork)
				{
				}
			}

		}

		/// <summary>
		/// 仕入管理アクセスクラス参照新規伝票作成イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="mode">コピーモード[0:両方, 1:リアルのみ]</param>
		private static void InfoCopyNewStockMngEvent(object sender, int mode)
		{
			// 仕入伝票データを調整
			// ヘッダ項目
			mainStock.CreateDateTime = DateTime.MinValue;			// 作成日時
			mainStock.UpdateDateTime = DateTime.MinValue;			// 更新日時
			mainStock.FileHeaderGuid = Guid.Empty;					// Guid
			mainStock.UpdEmployeeCode = "";						// 更新従業員コード
			mainStock.UpdAssemblyId1 = "";							// 更新アセンブリID1
			mainStock.UpdAssemblyId2 = "";							// 更新アセンブリID2
			mainStock.LogicalDeleteCode = 0;						// 論理削除区分
			// 企業コード
            mainStock.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		}

		/// <summary>
		/// 仕入管理アクセスクラス新規得意先イベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="workData">読込み得意先データ</param>
		private static void InfoNewEntryStockMngEvent(object sender, CustomSerializeArrayList workData)
		{
		}

		/// <summary>
		/// 仕入管理アクセスクラス更新チェックイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="compareResult">比較結果(0:変更無し, 1:変更有り)</param>
		/// <remarks>
		/// <br>Note       : 仕入伝票情報に変更があったかをチェックします。</br>
		/// </remarks>
		private static void InfoCompareMemoryStockMngEvent(object sender, ref int compareResult)
		{
			// 他のクラスで変更無しの場合のみ
			if (compareResult == 0)
			{
				// 仕入伝票アクセスクラス内での比較結果を戻す
				compareResult = (CompareStaticMemory()) ? 0 : 1;
			}
		}

		/// <summary>
		/// 仕入管理アクセスクラスデータ変換イベントハンドラ
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="workData">変換元ワークデータリスト</param>
		/// <param name="retUidataLst">変換後UIデータリスト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : ワークデータからUIデータに変換します。</br>
		/// </remarks>
		private static void InfoChangeWorkToUidataStockMngEvent(object sender, CustomSerializeArrayList workData, ref ArrayList retUidataLst, out int status)
		{
			status = 0;

			// CustomSerializeArrayListよりデータ取得
			foreach (object wkObj in workData)
			{
				// 仕入伝票データ
				if (wkObj is StockWork)
				{
					retUidataLst.Add(CopyToStockDataFromStockWork(wkObj as StockWork));
					continue;
				}

				// 仕入伝票明細データ
				if (wkObj is ArrayList)
				{
					ArrayList wkList = wkObj as ArrayList;

                    // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                    //if ((wkList.Count > 0) && (wkList[0] is ProductStockWork))
					//{
					//	retUidataLst.Add(CopyToDtlDataFromDtlWork(wkList));
					//}
                    // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                }
			}
		}
		#endregion

		//--------------------------------------------------------
		//  Staticデータ変更イベントハンドラ
		//--------------------------------------------------------
		#region Staticデータ変更イベントハンドラ
		/// <summary>
		/// 行インデックス取得処理
		/// </summary>
		/// <param name="dataRow">インデックス取得データ行</param>
		/// <returns>行インデックス</returns>
		private static int GetRowIndex(DataRow dataRow)
		{
			for (int i = 0; i < _mainProductStockView.Count; i++)
			{
				if (_mainProductStockView[i].Row == dataRow)
				{
					return i;
				}
			}

			return -1;
		}
		#endregion
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト
        
        #endregion

        //--------------------------------------------------------
		//  内部処理
		//--------------------------------------------------------
		#region 内部処理

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ダミーの明細(空行)を作成する。
		/// </summary>
		/// <param name="msg">エラーメッセージ</param>
		/// <returns>0:成功, 5:失敗</returns>
		private static int CreateDummySlipDtl(out string msg)
		{
			msg = "";
			if (_mainProductStockView != null)
			{
				int dispOrder = mainAdjustStockDtlFullView.Count;

				while (mainAdjustStockDtlFullView.Count < maxRowCnt)
				{
					// 変更イベント無効
					DeactivateDtlChangeEventHandler();
					try
					{
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
						//ProductStock data = new ProductStock();
                        StockExpansion data = new StockExpansion();
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                        // 論理削除=1
						data.LogicalDeleteCode = 1;
						// Guidを設定する
						data.FileHeaderGuid = Guid.Empty;
                        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //data.ProductStockGuid = Guid.Empty;
                        //data.GoodsCodeStatus = -1;
                        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
                        // 明細種別 = 未選択
						//data.StockDetailKind = (int)ConstantManagement_SF_AP.DetailKindCode.None;
                        
						// 行追加
                        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                        //_mainProductStock.Rows.Add(ProductStockToDataRow(data));
                        _mainProductStock.Rows.Add(StockToDataRow(data, null));
                        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                    }
					finally
					{
						// 変更イベント有効
						ActivateDtlChangeEventHandler();
					}
				}

				return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			else
			{
				msg = "明細情報が初期化されていません(ダミー明細作成)";
				return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ダミーの明細(空行)を作成する。
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>0:成功, 5:失敗</returns>
        /// <remarks>
        /// <br>Note       : ダミーの明細行を作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private static int CreateDummySlipDtl(out string msg)
        {
            msg = "";
            if (_mainProductStockView != null)
            {
                int dispOrder = mainAdjustStockDtlFullView.Count;

                while (mainAdjustStockDtlFullView.Count < maxRowCnt)
                {
                    // 変更イベント無効
                    DeactivateDtlChangeEventHandler();
                    try
                    {
                        Stock data = new Stock();
                        // 論理削除=1
                        data.LogicalDeleteCode = 1;
                        // Guidを設定する
                        data.FileHeaderGuid = Guid.Empty;

                        // 行追加
                        _mainProductStock.Rows.Add(StockToDataRow(data, null));
                    }
                    finally
                    {
                        // 変更イベント有効
                        ActivateDtlChangeEventHandler();
                    }
                }

                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                msg = "明細情報が初期化されていません(ダミー明細作成)";
                return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
            }
        }

        /// <summary>
        /// 行追加処理
        /// </summary>
        /// <remarks>
        /// Note       : １行だけ行追加します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public static void AddNewRow()
        {
            Stock data = new Stock();
            // 論理削除=1
            data.LogicalDeleteCode = 1;
            // Guidを設定する
            data.FileHeaderGuid = Guid.Empty;

            // 行追加
            _mainProductStock.Rows.Add(StockToDataRow(data, null));
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 伝票情報(MainStaticMemory)変更チェック処理
		/// </summary>
		/// <returns>T:変更無し, F:変更有り</returns>
		private static bool CompareStaticMemory()
		{
			try
			{
				// 仕入伝票情報比較？
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //if ((mainStock.Equals(orgnPtSuplSlip) != true) ||
				//	(_mainProductStockView.Count != orgnAdjustStockDtl.Count))
                if (mainStock.Equals(orgnPtSuplSlip) != true)
                // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                {
					return false;
				}

				// 仕入伝票明細情報比較
				for (int i = 0; i < _mainProductStockView.Count; i++)
				{
				}
			}
			catch
			{
				return false;
			}

			return true;
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        /// <summary>
		/// 明細情報(MainStaticMemory)変更イベントハンドラ有効化処理
		/// </summary>
		private static void ActivateDtlChangeEventHandler()
		{
			lock (syncRoot)
			{
				if (slipDtlChangeEventCounter++ == 0)
				{
					// ハンドラ登録
					_mainProductStock.ColumnChanging += _slipDtlChanging;
					_mainProductStock.ColumnChanged += _slipDtlChanged;
				}
			}
		}

		/// <summary>
		/// 明細情報(MainStaticMemory)変更イベントハンドラ無効化処理
		/// </summary>
		private static void DeactivateDtlChangeEventHandler()
		{
			lock (syncRoot)
			{
				if (--slipDtlChangeEventCounter == 0)
				{
					// ハンドラ削除
					_mainProductStock.ColumnChanging -= _slipDtlChanging;
					_mainProductStock.ColumnChanged -= _slipDtlChanged;
				}
			}
        }

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 提供イベント通知処理
		/// </summary>
		/// <param name="handler">提供イベント元デリゲート</param>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private static void CallEventHandler(EventHandler handler, object sender, EventArgs e)
		{
			// デリゲートに登録メソッド有り？
			if (handler != null)
			{
				// 登録分コールする
				foreach (Delegate wkMethod in handler.GetInvocationList())
				{
					if (wkMethod != null)
					{
						try
						{
							if (sender == null)
								((EventHandler)wkMethod)(myInstance, e);
							else
								((EventHandler)wkMethod)(sender, e);
						}
						catch
						{
							// メソッドコールが失敗した場合は削除
							handler -= (EventHandler)wkMethod;
						}
					}
				}
			}
		}
        
        /// <summary>
		/// 提供イベント通知処理
		/// </summary>
		/// <param name="handler">提供イベント元デリゲート</param>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private static void CallEventHandler<Args>(EventHandler<Args> handler, object sender, Args e) where Args : EventArgs
		{
			// デリゲートに登録メソッド有り？
			if (handler != null)
			{
				// 登録分コールする
				foreach (Delegate wkMethod in handler.GetInvocationList())
				{
					if (wkMethod != null)
					{
						try
						{
							if (sender == null)
								((EventHandler<Args>)wkMethod)(myInstance, e);
							else
								((EventHandler<Args>)wkMethod)(sender, e);
						}
						catch
						{
							// メソッドコールが失敗した場合は削除
							handler -= (EventHandler<Args>)wkMethod;
						}
					}
				}
			}
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// データテーブル作成処理
		/// </summary>
        /// <remarks>
        /// <br>Note       : データテーブルを作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
		private static void CreateProductStockTable()
		{
            _mainProductStock = new DataTable(ctTBL_AdjustStock);

            // No
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_RowNum, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_RowNum].Caption = "No";
            // 品番
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsNo].Caption = "品番";
            // 品名
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsName, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsName].Caption = "品名";
            // ＢＬコード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BLGoodsCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_BLGoodsCode].Caption = "BLｺｰﾄﾞ";
            // メーカー
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsMakerCd, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsMakerCd].Caption = "メーカー";
            // 仕入先
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierCd, typeof(String)));
            _mainProductStock.Columns[ctCOL_SupplierCd].Caption = "仕入先";
            // 標準価格
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ListPriceFl, typeof(Double)));
            _mainProductStock.Columns[ctCOL_ListPriceFl].Caption = "標準価格";
            // 原単価
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "原単価";
            // 仕入数
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderUnit, typeof(Double)));
            _mainProductStock.Columns[ctCOL_SalesOrderUnit].Caption = "仕入数";
            // 変更前仕入数
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfSalesOrderUnit, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfSalesOrderUnit].Caption = "変更前仕入数";
            // 仕入後数
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AfSalesOrderUnit, typeof(Double)));
            _mainProductStock.Columns[ctCOL_AfSalesOrderUnit].Caption = "仕入後数";
            // 倉庫棚番
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseShelfNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseShelfNo].Caption = "棚番";
            // 発注残
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderCount, typeof(String)));
            _mainProductStock.Columns[ctCOL_SalesOrderCount].Caption = "発注残";
            // 在庫数(仕入在庫数)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierStock, typeof(Double)));
            _mainProductStock.Columns[ctCOL_SupplierStock].Caption = "在庫数";
            // 明細備考
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_DtlNote, typeof(String)));
            _mainProductStock.Columns[ctCOL_DtlNote].Caption = "明細備考";
            // 作成日時
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CreateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_CreateDateTime].Caption = "作成日時";
            // 更新日時
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_UpdateDateTime].Caption = "更新日時";
            // 企業コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_EnterpriseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_EnterpriseCode].Caption = "企業コード";
            _mainProductStock.Columns[ctCOL_EnterpriseCode].MaxLength = 16;
            // GUID
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_FileHeaderGuid, typeof(Guid)));
            _mainProductStock.Columns[ctCOL_FileHeaderGuid].Caption = "GUID";
            // 更新従業員コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdEmployeeCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].Caption = "更新従業員コード";
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].MaxLength = 9;
            // 更新アセンブリID1
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId1, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].Caption = "更新アセンブリID1";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // 更新アセンブリID2
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId2, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId2].Caption = "更新アセンブリID2";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // 論理削削除区分
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LogicalDeleteCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_LogicalDeleteCode].Caption = "論理削削除区分";
            // 拠点コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SectionCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_SectionCode].Caption = "拠点コード";
            _mainProductStock.Columns[ctCOL_SectionCode].MaxLength = 6;
            // 修正前原単価
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "修正前原単価";
            // 変更前在庫数(仕入在庫数)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfSupplierStock, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfSupplierStock].Caption = "修正前在庫数";
            // 倉庫コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseCode].Caption = "倉庫コード";
            _mainProductStock.Columns[ctCOL_WarehouseCode].MaxLength = 6;
            // 調整日付
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustDate, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_AdjustDate].Caption = "調整日付";
            // 入力日付
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_InputDay, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_InputDay].Caption = "入力日付";
            // 仕入形式(元)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierFormalSrc, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_SupplierFormalSrc].Caption = "仕入形式(元)";
            // 仕入明細通番(元)
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockSlipDtlNumSrc, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_StockSlipDtlNumSrc].Caption = "仕入明細通番(元)";
            // 在庫調整伝票番号
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustSlipNo, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_StockAdjustSlipNo].Caption = "在庫調整伝票番号";
            // 在庫マスタ
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_Stock, typeof(Stock)));
            _mainProductStock.Columns[ctCOL_Stock].Caption = "在庫マスタ";
            // 在庫調整データ
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjust, typeof(StockAdjust)));
            _mainProductStock.Columns[ctCOL_StockAdjust].Caption = "在庫調整データ";
            // 在庫調整明細データ
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustDtl, typeof(StockAdjustDtl)));
            _mainProductStock.Columns[ctCOL_StockAdjustDtl].Caption = "在庫調整明細データ";
            // 価格マスタ
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsPrice, typeof(GoodsPrice)));
            _mainProductStock.Columns[ctCOL_GoodsPrice].Caption = "価格マスタ";
            // 仕入金額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockPriceTaxExc, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StockPriceTaxExc].Caption = "仕入金額";
            // オープン価格区分
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_OpenPriceDiv, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_OpenPriceDiv].Caption = "オープン価格区分";
            // 仕入先略称
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierSnm, typeof(string)));
            _mainProductStock.Columns[ctCOL_SupplierSnm].Caption = "仕入先略称";

			// データビュー
			_mainProductStockView = new DataView(_mainProductStock);
			_mainProductStockView.RowFilter = ctCOL_LogicalDeleteCode + " = 0";
			_mainProductStockView.Sort = ctCOL_RowNum;
			
            mainAdjustStockDtlFullView = new DataView(_mainProductStock);
            mainAdjustStockDtlFullView.Sort = ctCOL_RowNum;

			adjustSuplSlipDtlPriceView = new DataView(_mainProductStock);
            adjustSuplSlipDtlPriceView.Sort = ctCOL_RowNum;

			// イベントハンドラ登録
			ActivateDtlChangeEventHandler();
			slipDtlChangeEventCounter = 1;		// 1:イベント有効状態
		}
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

		#endregion

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データテーブル作成処理
        /// </summary>
        private static void CreateProductStockTable()
        {
            _mainProductStock = new DataTable(ctTBL_AdjustStock);

            // 行番号
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_RowNum, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_RowNum].Caption = "No";

            // 作成日時
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CreateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_CreateDateTime].Caption = "作成日時";
            // 更新日時
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdateDateTime, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_UpdateDateTime].Caption = "更新日時";
            // 企業コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_EnterpriseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_EnterpriseCode].Caption = "企業コード";
            _mainProductStock.Columns[ctCOL_EnterpriseCode].MaxLength = 16;
            // GUID
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_FileHeaderGuid, typeof(Guid)));
            _mainProductStock.Columns[ctCOL_FileHeaderGuid].Caption = "GUID";
            // 更新従業員コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdEmployeeCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].Caption = "更新従業員コード";
            _mainProductStock.Columns[ctCOL_UpdEmployeeCode].MaxLength = 9;
            // 更新アセンブリID1
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId1, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].Caption = "更新アセンブリID1";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // 更新アセンブリID2
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId2, typeof(String)));
            _mainProductStock.Columns[ctCOL_UpdAssemblyId2].Caption = "更新アセンブリID2";
            _mainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // 論理削削除区分
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LogicalDeleteCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_LogicalDeleteCode].Caption = "論理削削除区分";
            // 拠点コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SectionCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_SectionCode].Caption = "拠点コード";
            _mainProductStock.Columns[ctCOL_SectionCode].MaxLength = 6;
            // メーカーコード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_MakerCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_MakerCode].Caption = "メーカーコード";
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsMakerCd, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_GoodsMakerCd].Caption = "メーカーコード";
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品コード
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsCode, typeof(String)));
            //_mainProductStock.Columns[ctCOL_GoodsCode].Caption = "商品コード";
            //_mainProductStock.Columns[ctCOL_GoodsCode].MaxLength = 15;
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsNo].Caption = "商品コード";
            // 2008.03.14 修正 >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns[ctCOL_GoodsNo].MaxLength = 15;
            _mainProductStock.Columns[ctCOL_GoodsNo].MaxLength = 40;
            // 2008.03.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品名称
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsName, typeof(String)));
            _mainProductStock.Columns[ctCOL_GoodsName].Caption = "商品名称";
            _mainProductStock.Columns[ctCOL_GoodsName].MaxLength = 40;
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製造番号
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ProductNumber, typeof(String)));
            //_mainProductStock.Columns[ctCOL_ProductNumber].Caption = "製造番号";
            //_mainProductStock.Columns[ctCOL_ProductNumber].MaxLength = 20;
            //// 製造在庫マスタGUID
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ProductStockGuid, typeof(Guid)));
            //_mainProductStock.Columns[ctCOL_ProductStockGuid].Caption = "製造在庫マスタGUID";
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 在庫区分
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockDiv, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_StockDiv].Caption = "在庫区分";
            // 倉庫コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseCode].Caption = "倉庫コード";
            _mainProductStock.Columns[ctCOL_WarehouseCode].MaxLength = 6;
            // 倉庫名称
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseName, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseName].Caption = "倉庫名称";
            _mainProductStock.Columns[ctCOL_WarehouseName].MaxLength = 20;
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 事業者コード
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierEpCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_CarrierEpCode].Caption = "事業者コード";            
            //// 事業者名称
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierEpName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CarrierEpName].Caption = "事業者名称";
            //_mainProductStock.Columns[ctCOL_CarrierEpName].MaxLength = 20;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 得意先コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CustomerCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_CustomerCode].Caption = "得意先コード";
            // 得意先名称
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CustomerName, typeof(String)));
            _mainProductStock.Columns[ctCOL_CustomerName].Caption = "得意先名称";
            _mainProductStock.Columns[ctCOL_CustomerName].MaxLength = 40;
            // 得意先名称2
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_CustomerName2, typeof(String)));
            _mainProductStock.Columns[ctCOL_CustomerName2].Caption = "得意先名称2";
            _mainProductStock.Columns[ctCOL_CustomerName2].MaxLength = 40;
            // 仕入日
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockDate, typeof(DateTime)));
            //_mainProductStock.Columns[ctCOL_StockDate].Caption = "仕入日";
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LastStockDate, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_LastStockDate].Caption = "仕入日";
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 入荷日
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ArrivalGoodsDay, typeof(DateTime)));
            _mainProductStock.Columns[ctCOL_ArrivalGoodsDay].Caption = "入荷日";
            // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
            //// 仕入単価
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Int64)));
            //_mainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "仕入単価";
            //// 修正前仕入単価
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Int64)));
            //_mainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "修正前仕入単価";
            // 仕入単価
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "仕入単価";
            // 修正前仕入単価
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Double)));
            _mainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "修正前仕入単価";
            // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
            // 仕入金額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockPrice, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StockPrice].Caption = "仕入金額";
            // 仕入金額消費税額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StockPriceConsTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StockPriceConsTax].Caption = "仕入金額消費税額";
            // 仕入外税対象額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ItdedStckOutTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_ItdedStckOutTax].Caption = "仕入外税対象額";
            // 仕入内税対象額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ItdedStckInTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_ItdedStckInTax].Caption = "仕入内税対象額";
            // 仕入非課税対象額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ItdedStckTaxFree, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_ItdedStckTaxFree].Caption = "仕入非課税対象額";
            // 仕入外税額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StckOuterTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StckOuterTax].Caption = "仕入外税額";
            // 仕入内税額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_StckInnerTax, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_StckInnerTax].Caption = "仕入内税額";
            // 課税区分
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_TaxationCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_TaxationCode].Caption = "課税区分";
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockState, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_StockState].Caption = "在庫状態";
            //// 移動状態
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_MoveStatus, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_MoveStatus].Caption = "移動状態";
            //// 商品状態
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsCodeStatus, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_GoodsCodeStatus].Caption = "商品状態";
            //// 修正前商品状態
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_BfGoodsCodeStatus, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_BfGoodsCodeStatus].Caption = "修正前商品状態";
            //// 商品電話番号1
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockTelNo1, typeof(String)));
            //_mainProductStock.Columns[ctCOL_StockTelNo1].Caption = "商品電話番号1";
            //_mainProductStock.Columns[ctCOL_StockTelNo1].MaxLength = 20;
            //// 商品電話番号2
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_StockTelNo2, typeof(String)));
            //_mainProductStock.Columns[ctCOL_StockTelNo2].Caption = "商品電話番号2";
            //_mainProductStock.Columns[ctCOL_StockTelNo2].MaxLength = 20;
            //// ロム区分
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_RomDiv, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_RomDiv].Caption = "ロム区分";            
            //// 機種コード
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CellphoneModelCode, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CellphoneModelCode].Caption = "機種コード";
            //_mainProductStock.Columns[ctCOL_CellphoneModelCode].MaxLength = 20;
            //// 機種名称
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CellphoneModelName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CellphoneModelName].Caption = "機種名称";
            //_mainProductStock.Columns[ctCOL_CellphoneModelName].MaxLength = 40;
            //// キャリアコード
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_CarrierCode].Caption = "キャリアコード";            
            //// キャリア名称
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_CarrierName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_CarrierName].Caption = "キャリア名称";
            //_mainProductStock.Columns[ctCOL_CarrierName].MaxLength = 20;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // メーカー名称
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_MakerName, typeof(String)));
            _mainProductStock.Columns[ctCOL_MakerName].Caption = "メーカー名称";
            _mainProductStock.Columns[ctCOL_MakerName].MaxLength = 30;
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 系統色コード
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_SystematicColorCd, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_SystematicColorCd].Caption = "系統色コード";            
            //// 系統色名称
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_SystematicColorNm, typeof(String)));
            //_mainProductStock.Columns[ctCOL_SystematicColorNm].Caption = "系統色名称";
            //_mainProductStock.Columns[ctCOL_SystematicColorNm].MaxLength = 20;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 商品大分類コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_LargeGoodsGanreCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_LargeGoodsGanreCode].Caption = "商品大分類コード";
            // 商品中分類コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_MediumGoodsGanreCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_MediumGoodsGanreCode].Caption = "商品中分類コード";
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 出荷先得意先コード
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ShipCustomerCode, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_ShipCustomerCode].Caption = "出荷先得意先コード";            
            //// 出荷先得意先名称
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ShipCustomerName, typeof(String)));
            //_mainProductStock.Columns[ctCOL_ShipCustomerName].Caption = "出荷先得意先名称";
            //_mainProductStock.Columns[ctCOL_ShipCustomerName].MaxLength = 30;
            //// 出荷先得意先名称2
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_ShipCustomerName2, typeof(String)));
            //_mainProductStock.Columns[ctCOL_ShipCustomerName2].Caption = "出荷先得意先名称2";
            //_mainProductStock.Columns[ctCOL_ShipCustomerName2].MaxLength = 30;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 商品区分詳細コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_DetailGoodsGanreCode, typeof(String)));
            _mainProductStock.Columns[ctCOL_DetailGoodsGanreCode].Caption = "商品区分詳細コード";
            // ＢＬ商品コード
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BLGoodsCode, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_BLGoodsCode].Caption = "ＢＬコード";
            // 倉庫棚番
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseShelfNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_WarehouseShelfNo].Caption = "棚番";
            _mainProductStock.Columns[ctCOL_WarehouseShelfNo].MaxLength = 8;
            // 修正前倉庫棚番
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_BfWarehouseShelfNo, typeof(String)));
            _mainProductStock.Columns[ctCOL_BfWarehouseShelfNo].Caption = "修正前棚番";
            // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////製番管理区分
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_PrdNumMngDiv, typeof(Int32)));
            //_mainProductStock.Columns[ctCOL_PrdNumMngDiv].Caption = "製番管理区分";
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 仕入在庫数
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierStock, typeof(Double)));
            _mainProductStock.Columns[ctCOL_SupplierStock].Caption = "仕入在庫数";

            // 受託在庫数
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_TrustCount, typeof(Double)));
            _mainProductStock.Columns[ctCOL_TrustCount].Caption = "受託在庫数";

            // 調整金額
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustPrice, typeof(Int64)));
            _mainProductStock.Columns[ctCOL_AdjustPrice].Caption = "調整金額";

            // 調整数
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustCount, typeof(Double)));
            _mainProductStock.Columns[ctCOL_AdjustCount].Caption = "調整数";

            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 修正前製番
            //_mainProductStock.Columns.Add(new DataColumn(ctCOL_BfProductNumber, typeof(string)));
            //_mainProductStock.Columns[ctCOL_BfProductNumber].Caption = "修正前製番";
            //_mainProductStock.Columns[ctCOL_ShipCustomerName2].MaxLength = 20;
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            /// <summary>明細備考</summary>
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_DtlNote, typeof(String)));
            _mainProductStock.Columns[ctCOL_DtlNote].Caption = "明細備考";
            _mainProductStock.Columns[ctCOL_DtlNote].MaxLength = 40;
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            /// <summary>定価（浮動）</summary>
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_ListPriceFl, typeof(Double)));
            _mainProductStock.Columns[ctCOL_ListPriceFl].Caption = "定価";
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<

            // 商品ガイド
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsGuide, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_GoodsGuide].Caption = "";

            // 明細タイプ
            _mainProductStock.Columns.Add(new DataColumn(ctCOL_RowType, typeof(Int32)));
            _mainProductStock.Columns[ctCOL_RowType].Caption = "明細タイプ";

            // データビュー
            _mainProductStockView = new DataView(_mainProductStock);
            _mainProductStockView.RowFilter = ctCOL_LogicalDeleteCode + " = 0";
            _mainProductStockView.Sort = ctCOL_RowNum;

            mainAdjustStockDtlFullView = new DataView(_mainProductStock);
            mainAdjustStockDtlFullView.Sort = ctCOL_RowNum;

            adjustSuplSlipDtlPriceView = new DataView(_mainProductStock);
            adjustSuplSlipDtlPriceView.Sort = ctCOL_RowNum;

            // イベントハンドラ登録
            ActivateDtlChangeEventHandler();
            slipDtlChangeEventCounter = 1;		// 1:イベント有効状態
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼ハンディターミナル在庫仕入登録の対応
        /// <summary>
        /// コンストラクタ（ハンディターミナル用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="status">初期化ステータス「0：成功  0以外：失敗」</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public AdjustStockAcs(string enterpriseCode, string sectionCode, out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // データテーブル作成
                CreateProductStockTableForHandy();

                this._stockProcMoneyAcs = new StockProcMoneyAcs();
                this._taxRateSetAcs = new TaxRateSetAcs();
                this._goodsAcs = new GoodsAcs();
                this._searchStockAcs = new SearchStockAcs();
                this._blGoodsCdAcs = new BLGoodsCdAcs();
                this._warehouseAcs = new WarehouseAcs();
                this._secInfoAcs = new SecInfoAcs();
                this._employeeAcs = new EmployeeAcs();
                this._makerAcs = new MakerAcs();
                this._stockMngTtlStAcs = new StockMngTtlStAcs();
                this._supplierAcs = new SupplierAcs();

                this._companyInfAcs = new CompanyInfAcs();
                this._companyInf = new CompanyInf();

                this._unitPriceCalculation = new UnitPriceCalculation();

                string errMsg;
                status = this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out errMsg);

                // 商品アクセス初期化失敗場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }

                // マスタデータを取得します。
                ReadStockMngTtlSt();
                ReadInitData();         // 単価算出クラス初期データ読込
                ReadTaxRate();          // 税率設定マスタ読込
                ReadBLGoodsCdUMnt();    // BL商品コードマスタ読込
                ReadWarehouse();        // 倉庫マスタ読込
                ReadSecInfoSet();       // 拠点情報設定マスタ読込
                ReadEmployee();         // 従業員マスタ読込
                ReadMakerUMnt();        // メーカーマスタ読込
                ReadSupplier();
                ReadCompanyInf();  //  掛率優先区分に追加 
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 
            }
            
        }

        /// <summary>
        /// データテーブル作成処理（ハンディターミナル用）
        /// </summary>
        /// <remarks>
        /// <br>Note       : データテーブルを作成します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void CreateProductStockTableForHandy()
        {
            MainProductStock = new DataTable(ctTBL_AdjustStock);

            // No
            MainProductStock.Columns.Add(new DataColumn(ctCOL_RowNum, typeof(Int32)));
            MainProductStock.Columns[ctCOL_RowNum].Caption = "No";
            // 品番
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsNo, typeof(String)));
            MainProductStock.Columns[ctCOL_GoodsNo].Caption = "品番";
            // 品名
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsName, typeof(String)));
            MainProductStock.Columns[ctCOL_GoodsName].Caption = "品名";
            // ＢＬコード
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BLGoodsCode, typeof(String)));
            MainProductStock.Columns[ctCOL_BLGoodsCode].Caption = "BLｺｰﾄﾞ";
            // メーカー
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsMakerCd, typeof(String)));
            MainProductStock.Columns[ctCOL_GoodsMakerCd].Caption = "メーカー";
            // 仕入先
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierCd, typeof(String)));
            MainProductStock.Columns[ctCOL_SupplierCd].Caption = "仕入先";
            // 標準価格
            MainProductStock.Columns.Add(new DataColumn(ctCOL_ListPriceFl, typeof(Double)));
            MainProductStock.Columns[ctCOL_ListPriceFl].Caption = "標準価格";
            // 原単価
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockUnitPrice, typeof(Double)));
            MainProductStock.Columns[ctCOL_StockUnitPrice].Caption = "原単価";
            // 仕入数
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderUnit, typeof(Double)));
            MainProductStock.Columns[ctCOL_SalesOrderUnit].Caption = "仕入数";
            // 変更前仕入数
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BfSalesOrderUnit, typeof(Double)));
            MainProductStock.Columns[ctCOL_BfSalesOrderUnit].Caption = "変更前仕入数";
            // 仕入後数
            MainProductStock.Columns.Add(new DataColumn(ctCOL_AfSalesOrderUnit, typeof(Double)));
            MainProductStock.Columns[ctCOL_AfSalesOrderUnit].Caption = "仕入後数";
            // 倉庫棚番
            MainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseShelfNo, typeof(String)));
            MainProductStock.Columns[ctCOL_WarehouseShelfNo].Caption = "棚番";
            // 発注残
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SalesOrderCount, typeof(String)));
            MainProductStock.Columns[ctCOL_SalesOrderCount].Caption = "発注残";
            // 在庫数(仕入在庫数)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierStock, typeof(Double)));
            MainProductStock.Columns[ctCOL_SupplierStock].Caption = "在庫数";
            // 明細備考
            MainProductStock.Columns.Add(new DataColumn(ctCOL_DtlNote, typeof(String)));
            MainProductStock.Columns[ctCOL_DtlNote].Caption = "明細備考";
            // 作成日時
            MainProductStock.Columns.Add(new DataColumn(ctCOL_CreateDateTime, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_CreateDateTime].Caption = "作成日時";
            // 更新日時
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdateDateTime, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_UpdateDateTime].Caption = "更新日時";
            // 企業コード
            MainProductStock.Columns.Add(new DataColumn(ctCOL_EnterpriseCode, typeof(String)));
            MainProductStock.Columns[ctCOL_EnterpriseCode].Caption = "企業コード";
            MainProductStock.Columns[ctCOL_EnterpriseCode].MaxLength = 16;
            // GUID
            MainProductStock.Columns.Add(new DataColumn(ctCOL_FileHeaderGuid, typeof(Guid)));
            MainProductStock.Columns[ctCOL_FileHeaderGuid].Caption = "GUID";
            // 更新従業員コード
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdEmployeeCode, typeof(String)));
            MainProductStock.Columns[ctCOL_UpdEmployeeCode].Caption = "更新従業員コード";
            MainProductStock.Columns[ctCOL_UpdEmployeeCode].MaxLength = 9;
            // 更新アセンブリID1
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId1, typeof(String)));
            MainProductStock.Columns[ctCOL_UpdAssemblyId1].Caption = "更新アセンブリID1";
            MainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // 更新アセンブリID2
            MainProductStock.Columns.Add(new DataColumn(ctCOL_UpdAssemblyId2, typeof(String)));
            MainProductStock.Columns[ctCOL_UpdAssemblyId2].Caption = "更新アセンブリID2";
            MainProductStock.Columns[ctCOL_UpdAssemblyId1].MaxLength = 30;
            // 論理削削除区分
            MainProductStock.Columns.Add(new DataColumn(ctCOL_LogicalDeleteCode, typeof(Int32)));
            MainProductStock.Columns[ctCOL_LogicalDeleteCode].Caption = "論理削削除区分";
            // 拠点コード
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SectionCode, typeof(String)));
            MainProductStock.Columns[ctCOL_SectionCode].Caption = "拠点コード";
            MainProductStock.Columns[ctCOL_SectionCode].MaxLength = 6;
            // 修正前原単価
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BfStockUnitPrice, typeof(Double)));
            MainProductStock.Columns[ctCOL_BfStockUnitPrice].Caption = "修正前原単価";
            // 変更前在庫数(仕入在庫数)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_BfSupplierStock, typeof(Double)));
            MainProductStock.Columns[ctCOL_BfSupplierStock].Caption = "修正前在庫数";
            // 倉庫コード
            MainProductStock.Columns.Add(new DataColumn(ctCOL_WarehouseCode, typeof(String)));
            MainProductStock.Columns[ctCOL_WarehouseCode].Caption = "倉庫コード";
            MainProductStock.Columns[ctCOL_WarehouseCode].MaxLength = 6;
            // 調整日付
            MainProductStock.Columns.Add(new DataColumn(ctCOL_AdjustDate, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_AdjustDate].Caption = "調整日付";
            // 入力日付
            MainProductStock.Columns.Add(new DataColumn(ctCOL_InputDay, typeof(DateTime)));
            MainProductStock.Columns[ctCOL_InputDay].Caption = "入力日付";
            // 仕入形式(元)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierFormalSrc, typeof(Int32)));
            MainProductStock.Columns[ctCOL_SupplierFormalSrc].Caption = "仕入形式(元)";
            // 仕入明細通番(元)
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockSlipDtlNumSrc, typeof(Int32)));
            MainProductStock.Columns[ctCOL_StockSlipDtlNumSrc].Caption = "仕入明細通番(元)";
            // 在庫調整伝票番号
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustSlipNo, typeof(Int32)));
            MainProductStock.Columns[ctCOL_StockAdjustSlipNo].Caption = "在庫調整伝票番号";
            // 在庫マスタ
            MainProductStock.Columns.Add(new DataColumn(ctCOL_Stock, typeof(Stock)));
            MainProductStock.Columns[ctCOL_Stock].Caption = "在庫マスタ";
            // 在庫調整データ
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjust, typeof(StockAdjust)));
            MainProductStock.Columns[ctCOL_StockAdjust].Caption = "在庫調整データ";
            // 在庫調整明細データ
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockAdjustDtl, typeof(StockAdjustDtl)));
            MainProductStock.Columns[ctCOL_StockAdjustDtl].Caption = "在庫調整明細データ";
            // 価格マスタ
            MainProductStock.Columns.Add(new DataColumn(ctCOL_GoodsPrice, typeof(GoodsPrice)));
            MainProductStock.Columns[ctCOL_GoodsPrice].Caption = "価格マスタ";
            // 仕入金額
            MainProductStock.Columns.Add(new DataColumn(ctCOL_StockPriceTaxExc, typeof(Int64)));
            MainProductStock.Columns[ctCOL_StockPriceTaxExc].Caption = "仕入金額";
            // オープン価格区分
            MainProductStock.Columns.Add(new DataColumn(ctCOL_OpenPriceDiv, typeof(Int32)));
            MainProductStock.Columns[ctCOL_OpenPriceDiv].Caption = "オープン価格区分";
            // 仕入先略称
            MainProductStock.Columns.Add(new DataColumn(ctCOL_SupplierSnm, typeof(string)));
            MainProductStock.Columns[ctCOL_SupplierSnm].Caption = "仕入先略称";
        }

        /// <summary>
        /// 製番情報の補正（ハンディターミナル用）
        /// </summary>
        /// <param name="inspectDataAddList">検品登録データ</param>
        /// <returns>補正ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : 製番情報の仕入数、仕入後数を補正します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SetInspectDataForHandy(ArrayList inspectDataAddList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 検品登録データがない場合
                if (inspectDataAddList == null || inspectDataAddList.Count == 0)
                {
                    return status;
                }

                string errMessage = string.Empty;
                object searchObj = LoadAssembly(AssemblyIdPmhnd01114d, AssemblyIdPmhnd01114dClassName, out errMessage);
                // 検品登録条件オブジェクトがない場合
                if (searchObj == null)
                {
                    return status;
                }

                // 検品登録ワークタイプを取得します。
                Type searchType = searchObj.GetType();

                for (int i = 0; i < inspectDataAddList.Count; i++)
                {
                    // 仕入明細通番
                    long stockSlipDtlNum = (long)searchType.GetProperty(StockSlipDtlNum).GetValue(inspectDataAddList[i], null);
                    // 検品数
                    double inspectCnt = (double)searchType.GetProperty(InspectCnt).GetValue(inspectDataAddList[i], null);
                    // 引数.仕入明細通番により、変数_mainProductStockの仕入明細通番（元）と一致するレコードを検索します。
                    string filter = string.Format("{0}={1}",
                                MainProductStock.Columns[ctCOL_StockSlipDtlNumSrc], stockSlipDtlNum);

                    DataRow[] gridDataRow =
                        (DataRow[])MainProductStock.Select(filter);

                    if (gridDataRow.Length > 0)
                    {
                        // 仕入数
                        gridDataRow[0][ctCOL_SalesOrderUnit] = inspectCnt;
                        // 仕入後数は在庫数+仕入数⇒在庫数+引数.検品数へ変更します。
                        gridDataRow[0][ctCOL_AfSalesOrderUnit] = inspectCnt + (double)gridDataRow[0][ctCOL_SupplierStock];
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// DB登録用データオブジェクトの取得処理（ハンディターミナル用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="paraObj">登録用データオブジェクト</param>
        /// <returns>取得結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : DB登録用データオブジェクトを取得します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int GetSaveDBDataForHandy(string employeeCode, string sectionCode, out object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paraObj = null;

            try
            {
                CustomSerializeArrayList registList = new CustomSerializeArrayList();

                ArrayList stockAdjustWorkList = new ArrayList();
                ArrayList stockAdjustDtlWorkList = new ArrayList();

                StockAdjust stockAdjust;
                StockAdjustDtl stockAdjustDtl;

                Dictionary<int, DataRow> saveStokRowDic = new Dictionary<int, DataRow>();

                for (int index = 0; index < MainProductStock.Rows.Count; index++)
                {
                    if ((MainProductStock.Rows[index][ctCOL_FileHeaderGuid] == DBNull.Value) ||
                        ((Guid)MainProductStock.Rows[index][ctCOL_FileHeaderGuid] == Guid.Empty))
                    {
                        continue;
                    }

                    if (!saveStokRowDic.ContainsKey(index))
                    {
                        // 保存用データに追加
                        saveStokRowDic.Add(index, MainProductStock.Rows[index]);
                    }
                }

                int count = 0;
                foreach (DataRow dataRow in saveStokRowDic.Values)
                {
                    // 変更前の在庫調整データを取得
                    stockAdjust = (StockAdjust)dataRow[ctCOL_StockAdjust];

                    // 変更前の在庫調整明細データを取得
                    stockAdjustDtl = (StockAdjustDtl)dataRow[ctCOL_StockAdjustDtl];

                    // 画面情報を反映
                    this.GetScreenInfoForHandy(sectionCode, employeeCode, ref stockAdjust, ref stockAdjustDtl, dataRow);

                    // 在庫調整データは１レコードだけ作成
                    if (count == 0)
                    {
                        // 在庫調整データ追加
                        stockAdjustWorkList.Add(CopyToStockAdjustWorkFromStockAdjust(stockAdjust));
                    }

                    // 在庫調整明細データ追加
                    stockAdjustDtlWorkList.Add(CopyToStockAdjustDtlWorkFromStockAdjustDtl(stockAdjustDtl));
                    count++;
                }

                registList.Add(stockAdjustWorkList);
                registList.Add(stockAdjustDtlWorkList);

                paraObj = (object)registList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 画面情報取得処理（ハンディターミナル用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockAdjust">在庫調整データ</param>
        /// <param name="stockAdjustDtl">在庫調整明細データ</param>
        /// <param name="dataRow">対象行</param>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void GetScreenInfoForHandy(string employeeCode, string sectionCode, ref StockAdjust stockAdjust, ref StockAdjustDtl stockAdjustDtl, DataRow dataRow)
        {
            //------------------------------------------------------------
            // 在庫調整データ
            //------------------------------------------------------------
            // 企業コード
            stockAdjust.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            stockAdjust.SectionCode = sectionCode;
            // 在庫調整伝票番号
            stockAdjust.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // 受払元伝票区分(在庫仕入)
            stockAdjust.AcPaySlipCd = 13;
            // 受払元取引区分(在庫数調整)
            stockAdjust.AcPayTransCd = 10;
            // 調整日付
            stockAdjust.AdjustDate = DateTime.Today;
            // 入力日付
            stockAdjust.InputDay = DateTime.Today;
            // 仕入拠点コード
            stockAdjust.StockSectionCd = sectionCode;
            // 仕入拠点名称
            stockAdjust.StockSectionNm = GetSectionName(sectionCode);
            // 仕入入力者コード
            stockAdjust.StockInputCode = employeeCode;
            // 仕入入力者名称
            stockAdjust.StockInputName = GetEmployeeName(stockAdjust.StockInputCode);
            if (stockAdjust.StockInputName.Length > 16)
            {
                stockAdjust.StockInputName = stockAdjust.StockInputName.Substring(0, 16);
            }
            // 仕入担当者コード
            stockAdjust.StockAgentCode = employeeCode;
            // 仕入担当者名称
            stockAdjust.StockAgentName = GetEmployeeName(stockAdjust.StockAgentCode);
            if (stockAdjust.StockAgentName.Length > 16)
            {
                stockAdjust.StockAgentName = stockAdjust.StockAgentName.Substring(0, 16);
            }
            // 仕入金額小計
            stockAdjust.StockSubttlPrice = GetTotalPriceForHandy();
            // 伝票備考
            stockAdjust.SlipNote = string.Empty;

            //------------------------------------------------------------
            // 在庫調整明細データ
            //------------------------------------------------------------
            // 企業コード
            stockAdjustDtl.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            stockAdjustDtl.SectionCode = sectionCode;
            // 在庫調整伝票番号
            stockAdjustDtl.StockAdjustSlipNo = (dataRow[ctCOL_StockAdjustSlipNo] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockAdjustSlipNo] : 0;
            // 在庫調整行番号
            stockAdjustDtl.StockAdjustRowNo = (Int32)dataRow[ctCOL_RowNum];
            // 仕入形式(仕入)
            stockAdjustDtl.SupplierFormalSrc = (dataRow[ctCOL_SupplierFormalSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_SupplierFormalSrc] : 0;
            // 仕入明細通番
            stockAdjustDtl.StockSlipDtlNumSrc = (dataRow[ctCOL_StockSlipDtlNumSrc] != DBNull.Value) ? (Int32)dataRow[ctCOL_StockSlipDtlNumSrc] : 0;
            // 受払元伝票区分(在庫仕入)
            stockAdjustDtl.AcPaySlipCd = 13;
            // 受払元取引区分(在庫調整数)
            stockAdjustDtl.AcPayTransCd = 10;
            // 調整日付
            stockAdjustDtl.AdjustDate = DateTime.Today;
            // 入力日付
            stockAdjustDtl.InputDay = DateTime.Today;
            // メーカーコード
            stockAdjustDtl.GoodsMakerCd = StringObjToInt(dataRow[ctCOL_GoodsMakerCd]);
            // メーカー名称
            stockAdjustDtl.MakerName = GetMakerName(stockAdjustDtl.GoodsMakerCd);
            // 品番
            stockAdjustDtl.GoodsNo = (dataRow[ctCOL_GoodsNo] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsNo] : "";
            // 品名
            stockAdjustDtl.GoodsName = (dataRow[ctCOL_GoodsName] != DBNull.Value) ? (string)dataRow[ctCOL_GoodsName] : "";
            // 仕入単価
            stockAdjustDtl.StockUnitPriceFl = (dataRow[ctCOL_StockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_StockUnitPrice] : 0;
            // 変更前仕入単価
            stockAdjustDtl.BfStockUnitPriceFl = (dataRow[ctCOL_BfStockUnitPrice] != DBNull.Value) ? (Double)dataRow[ctCOL_BfStockUnitPrice] : 0;
            // 調整数(仕入数をセット)
            stockAdjustDtl.AdjustCount = (double)dataRow[ctCOL_SalesOrderUnit];
            // 明細備考
            stockAdjustDtl.DtlNote = (dataRow[ctCOL_DtlNote] != DBNull.Value) ? (string)dataRow[ctCOL_DtlNote] : "";
            // 倉庫コード
            stockAdjustDtl.WarehouseCode = (dataRow[ctCOL_WarehouseCode] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseCode] : "";
            // 倉庫名称
            stockAdjustDtl.WarehouseName = GetWarehouseName(stockAdjustDtl.WarehouseCode);
            // BL商品コード
            stockAdjustDtl.BLGoodsCode = StringObjToInt(dataRow[ctCOL_BLGoodsCode]);
            // BL商品名称
            stockAdjustDtl.BLGoodsFullName = GetBLGoodsName(stockAdjustDtl.BLGoodsCode);
            // 倉庫棚番
            stockAdjustDtl.WarehouseShelfNo = (dataRow[ctCOL_WarehouseShelfNo] != DBNull.Value) ? (string)dataRow[ctCOL_WarehouseShelfNo] : "";
            // 定価
            stockAdjustDtl.ListPriceFl = (dataRow[ctCOL_ListPriceFl] != DBNull.Value) ? (Double)dataRow[ctCOL_ListPriceFl] : 0;

            // オープン価格区分
            stockAdjustDtl.OpenPriceDiv = (dataRow[ctCOL_OpenPriceDiv] != DBNull.Value) ? (Int32)dataRow[ctCOL_OpenPriceDiv] : 0;

            // 仕入金額
            if ((dataRow[ctCOL_StockUnitPrice] == DBNull.Value) || ((double)dataRow[ctCOL_StockUnitPrice] == 0) ||
                (dataRow[ctCOL_SalesOrderUnit] == DBNull.Value) || ((double)dataRow[ctCOL_SalesOrderUnit] == 0))
            {
                stockAdjustDtl.StockPriceTaxExc = 0;
            }

            //新規登録の場合
            else if (stockAdjust.FileHeaderGuid == Guid.Empty)
            {
                stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
            }
            else
            {
                if (((double)dataRow[ctCOL_StockUnitPrice] != (double)dataRow[ctCOL_BfStockUnitPrice]) ||
                    ((double)dataRow[ctCOL_SalesOrderUnit] != (double)dataRow[ctCOL_BfSalesOrderUnit]))
                {
                    stockAdjustDtl.StockPriceTaxExc = GetStockPriceTaxExc((double)dataRow[ctCOL_StockUnitPrice], (double)dataRow[ctCOL_SalesOrderUnit]);
                }
                else
                {
                    stockAdjustDtl.StockPriceTaxExc = (long)dataRow[ctCOL_StockPriceTaxExc];
                }
            }

            // 仕入先
            stockAdjustDtl.SupplierCd = (dataRow[ctCOL_SupplierCd] != DBNull.Value) ? int.Parse((string)dataRow[ctCOL_SupplierCd]) : 0;
            // 仕入先略称
            stockAdjustDtl.SupplierSnm = (dataRow[ctCOL_SupplierSnm] != DBNull.Value) ? (string)dataRow[ctCOL_SupplierSnm] : "";
        }

        /// <summary>
        /// 発注残照会リモート抽出結果グリッド表示処理（ハンディターミナル用）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="orderListResultWorkList">発注残照会リモート抽出結果リスト</param>
        /// <returns>取得結果ステータス「0：成功  0以外：失敗」</returns>
        /// <remarks>
        /// <br>Note       : 発注残照会リモート抽出結果をグリッドへ反映します。(発注残照会検索後に使用します)（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int OrderListResultWorkToGridForHandy(string sectionCode, List<OrderListResultWork> orderListResultWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR; 

            try
            {
                if ((orderListResultWorkList == null) || (orderListResultWorkList.Count == 0))
                {
                    return status;
                }

                // 発注残照会リモート抽出結果リストに対応する在庫マスタリストを取得
                List<Stock> stockList = GetStockList(orderListResultWorkList);

                // 在庫マスタリストに対応する商品連結データリストを取得
                List<GoodsUnitData> goodsUnitDataList = GetGoodsUnitDataListForHandy(sectionCode, stockList, true);

                DataRow newRow = null;
                for (int index = 0; index < stockList.Count; index++)
                {
                    newRow = MainProductStock.NewRow();

                    // 在庫情報反映
                    StockChangeRowGrsForHandy(index + 1, ref newRow, stockList[index], goodsUnitDataList[index], orderListResultWorkList[index]);

                    MainProductStock.Rows.Add(newRow);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; 
            }
            catch
            {
                // 処理なし。
            }
            return status;
        }

        /// <summary>
        /// 在庫情報反映処理（ハンディターミナル用）
        /// </summary>
        /// <param name="rowNum">行番号</param>
        /// <param name="newRow">新規行</param>
        /// <param name="stock">在庫マスタ情報</param>
        /// <param name="goodsUnitData">商品連結データ情報</param>
        /// <param name="orderListResultWork">発注データ情報</param>
        /// <remarks>
        /// <br>Note       : 在庫情報を反映します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void StockChangeRowGrsForHandy(int rowNum, ref DataRow newRow, Stock stock, GoodsUnitData goodsUnitData, OrderListResultWork orderListResultWork)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

            newRow[ctCOL_RowNum] = rowNum;

            newRow[ctCOL_CreateDateTime] = orderListResultWork.OrderDataCreateDate;
            newRow[ctCOL_UpdateDateTime] = stock.UpdateDateTime;
            newRow[ctCOL_EnterpriseCode] = stock.EnterpriseCode;
            newRow[ctCOL_FileHeaderGuid] = Guid.NewGuid();
            newRow[ctCOL_UpdEmployeeCode] = stock.UpdEmployeeCode;
            newRow[ctCOL_UpdAssemblyId1] = stock.UpdAssemblyId1;
            newRow[ctCOL_UpdAssemblyId2] = stock.UpdAssemblyId2;
            newRow[ctCOL_LogicalDeleteCode] = stock.LogicalDeleteCode;
            newRow[ctCOL_SectionCode] = stock.SectionCode;                          // 拠点コード

            // 在庫調整行番号

            // メーカーコード
            if (orderListResultWork.GoodsMakerCd == 0)
            {
                newRow[ctCOL_GoodsMakerCd] = "";
            }
            else
            {
                newRow[ctCOL_GoodsMakerCd] = orderListResultWork.GoodsMakerCd.ToString(GoodsMakerCdFormat);
            }
            newRow[ctCOL_GoodsNo] = orderListResultWork.GoodsNo;                            // 品番
            newRow[ctCOL_GoodsName] = orderListResultWork.GoodsName;                        // 品名
            newRow[ctCOL_StockUnitPrice] = orderListResultWork.StockUnitPriceFl;            // 原単価
            newRow[ctCOL_BfStockUnitPrice] = orderListResultWork.StockUnitPriceFl;          // 変更前原単価
            newRow[ctCOL_WarehouseCode] = orderListResultWork.WarehouseCode;                // 倉庫コード
            // BL商品コード
            if (orderListResultWork.BLGoodsCode == 0)
            {
                newRow[ctCOL_BLGoodsCode] = "";
            }
            else
            {
                newRow[ctCOL_BLGoodsCode] = orderListResultWork.BLGoodsCode.ToString(BLGoodsCodeFormat);
            }
            newRow[ctCOL_WarehouseShelfNo] = stock.WarehouseShelfNo;                        // 倉庫棚番
            newRow[ctCOL_ListPriceFl] = orderListResultWork.ListPriceTaxExcFl;              // 標準価格
            newRow[ctCOL_OpenPriceDiv] = 0;                                                 // オープン価格区分
            // 仕入先
            if (orderListResultWork.SupplierCd == 0)
            {
                newRow[ctCOL_SupplierCd] = DBNull.Value;
                newRow[ctCOL_SupplierSnm] = "";
            }
            else
            {
                newRow[ctCOL_SupplierCd] = orderListResultWork.SupplierCd.ToString(SupplierCdFormat);
                newRow[ctCOL_SupplierSnm] = GetSupplierSnm(orderListResultWork.SupplierCd);
            }
            newRow[ctCOL_SalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // 仕入数
            newRow[ctCOL_BfSalesOrderUnit] = orderListResultWork.OrderRemainCnt;                      // 仕入数
            newRow[ctCOL_SupplierStock] = stock.ShipmentPosCnt;                                     // 在庫数
            newRow[ctCOL_BfSupplierStock] = stock.ShipmentPosCnt;                                     // 変更前在庫数
            newRow[ctCOL_AfSalesOrderUnit] = orderListResultWork.OrderRemainCnt + stock.ShipmentPosCnt; // 仕入後数
            newRow[ctCOL_SalesOrderCount] = stock.SalesOrderCount;                                  // 発注残

            // 仕入金額
            newRow[ctCOL_StockPriceTaxExc] = 0;

            newRow[ctCOL_Stock] = stock.Clone();                                                    // 在庫マスタ
            newRow[ctCOL_StockAdjust] = new StockAdjust();                                        // 在庫調整データ
            newRow[ctCOL_StockAdjustDtl] = new StockAdjustDtl();                                  // 在庫調整明細データ

            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);
            newRow[ctCOL_GoodsPrice] = goodsPrice;                                                  // 価格マスタ

            newRow[ctCOL_SupplierFormalSrc] = orderListResultWork.SupplierFormal;                   // 仕入形式
            newRow[ctCOL_StockSlipDtlNumSrc] = orderListResultWork.StockSlipDtlNum;                 // 仕入明細通番
            newRow[ctCOL_DtlNote] = orderListResultWork.StockDtiSlipNote1.Trim();                   // 明細備考
        }

        /// <summary>
        /// 商品連結データリスト取得処理（ハンディターミナル用）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockList">在庫マスタリスト</param>
        /// <param name="flag">伝票番号で検索するかどうかを判断する用のフラグ</param>
        /// <returns>商品連結データリスト</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタリストより商品連結データリストを取得します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private List<GoodsUnitData> GetGoodsUnitDataListForHandy(string sectionCode, List<Stock> stockList, params bool[] flag)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            if ((stockList == null) || (stockList.Count == 0))
            {
                return goodsUnitDataList;
            }

            int status;
            string errMsg;
            List<GoodsUnitData> retGoodsUnitDataList;

            foreach (Stock stock in stockList)
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                // 商品連結データ検索条件設定
                GoodsCndtn goodsCndtn;
                SetGoodsCndtn(out goodsCndtn, stock.EnterpriseCode, stock.GoodsMakerCd, stock.GoodsNo, sectionCode);

                try
                {
                    // 商品検索
                    status = GetGoodsUnitDataList(goodsCndtn, out retGoodsUnitDataList, out errMsg, flag);
                    if (status == 0)
                    {
                        goodsUnitData = retGoodsUnitDataList[0];
                    }
                    else
                    {
                        goodsUnitData = new GoodsUnitData();
                    }
                }
                catch
                {
                    goodsUnitData = new GoodsUnitData();
                }

                goodsUnitDataList.Add(goodsUnitData);
            }

            return goodsUnitDataList;
        }

        /// <summary>
        /// 合計金額取得処理（ハンディターミナル用）
        /// </summary>
        /// <returns>合計金額</returns>
        /// <remarks>
        /// <br>Note       : 合計金額を取得します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public Int64 GetTotalPriceForHandy()
        {
            Int64 totalPrice = 0;
            double dblTotalPrice = 0;

            // (単価×仕入数)の合計を求めます
            for (int i = 0; i < MainProductStock.Rows.Count; i++)
            {
                if (MainProductStock.Rows[i][ctCOL_StockUnitPrice] == DBNull.Value)
                {
                    continue;
                }
                if (MainProductStock.Rows[i][ctCOL_StockUnitPrice].ToString().Trim() == "")
                {
                    continue;
                }
                if (MainProductStock.Rows[i][ctCOL_SalesOrderUnit] == DBNull.Value)
                {
                    continue;
                }
                if (MainProductStock.Rows[i][ctCOL_SalesOrderUnit].ToString().Trim() == "")
                {
                    continue;
                }

                dblTotalPrice = (double)MainProductStock.Rows[i][ctCOL_StockUnitPrice] *
                                (double)MainProductStock.Rows[i][ctCOL_SalesOrderUnit];

                if ((dblTotalPrice % 1) != 0)
                {
                    switch (_stockMngTtlSt.FractionProcCd)
                    {
                        case 1:
                            {
                                // 切り捨て
                                totalPrice += (long)(dblTotalPrice / 1);
                                break;
                            }
                        case 2:
                            {
                                // 四捨五入
                                if (dblTotalPrice >= 0)
                                {
                                    totalPrice += (long)((dblTotalPrice + 0.5) / 1);
                                }
                                else
                                {
                                    totalPrice += (long)((dblTotalPrice - 0.5) / 1);
                                }
                                break;
                            }
                        case 3:
                            {
                                // 切り上げ
                                if (dblTotalPrice % 1 == 0)
                                {
                                    totalPrice += (long)(dblTotalPrice);
                                }
                                else
                                {
                                    if (dblTotalPrice >= 0)
                                    {
                                        totalPrice += (long)((dblTotalPrice + 1) / 1);
                                    }
                                    else
                                    {
                                        totalPrice += (long)((dblTotalPrice - 1) / 1);
                                    }
                                }
                                break;
                            }
                    }
                }
                else
                {
                    totalPrice += (long)dblTotalPrice;
                }
            }

            return totalPrice;
        }

        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                // インスタンスタイプがある場合、インスタンスオブジェクトを生成します。
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return obj;
        }
        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<
    }
}
