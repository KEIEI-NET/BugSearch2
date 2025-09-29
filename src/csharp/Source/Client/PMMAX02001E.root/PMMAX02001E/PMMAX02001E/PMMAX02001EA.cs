//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品・入荷予約
// プログラム概要   : 出品・入荷予約
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 陳艶丹
// 作 成 日 : 2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 移動データテーブル
    /// </summary>
    /// <remarks>
    /// <br>Note       : 移動データテーブル用カラムクラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/22</br>
    /// </remarks>
    public class ExportMoveDataItems
    {
        #region ■ 移動データ用テーブル
        /// <summary>入荷予約データ用テーブル名称</summary>
        public const string ct_Tbl_Arrival = "Tbl_Arrival";
        /// <summary>入荷予約警告用テーブル名称</summary>
        public const string ct_Tbl_ArrivalWarning = "Tbl_ArrivalWarning";
        /// <summary>企業コード</summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>出荷日</summary>
        public const string ct_Col_StockMoveDate = "ShipDate";
        /// <summary>伝票番号</summary>
        public const string ct_Col_StockMoveSlipNo = "StockMoveSlipNo";
        /// <summary>行No</summary>
        public const string ct_Col_StockMoveRowNo = "StockMoveSlipRowNo";
        /// <summary>品名</summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary>品番</summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary>メーカーコード</summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>メーカー名</summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary>仕入先コード</summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary>仕入先名</summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary>BLｺｰﾄﾞ</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>出庫拠点コード</summary>
        public const string ct_Col_BfSectionCode = "BfSectionCode";
        /// <summary>出庫拠点名</summary>
        public const string ct_Col_BfSectionGuideSnm = "BfSectionGuideSnm";
        /// <summary>出庫倉庫</summary>
        public const string ct_Col_BfEnterWarehCode = "BfEnterWarehCode";
        /// <summary>出庫倉庫名</summary>
        public const string ct_Col_BfEnterWarehName = "BfEnterWarehName";
        /// <summary>入庫拠点コード</summary>
        public const string ct_Col_AfSectionCod = "AfSectionCod";
        /// <summary>入庫拠点名</summary>
        public const string ct_Col_AfSectionGuideSnm = "AfSectionGuideSnm";
        /// <summary>入庫倉庫</summary>
        public const string ct_Col_AfEnterWarehCode = "AfEnterWarehCode";
        /// <summary>入庫倉庫名</summary>
        public const string ct_Col_AfEnterWarehName = "AfEnterWarehName";
        /// <summary>売価率</summary>
        public const string ct_Col_SalesRate = "SalesRate";
        /// <summary>販売単価</summary>
        public const string ct_Col_SalesPrice = "SalesPrice";
        /// <summary>警告理由</summary>
        public const string ct_Col_AlertReason = "AlertReason";
        /// <summary>作成日時</summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary>更新日時</summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary>オープン価格区分</summary>
        public const string ct_Col_OpenPriceDiv = "OpenPriceDiv";
        /// <summary>出荷数</summary>
        public const string ct_Col_ShipmentCount = "ShipmentCount";
        /// <summary>入荷予約日</summary>
        public const string ct_Col_StockArrivalDate = "StockArrivalDate";

        #endregion
    }
}
