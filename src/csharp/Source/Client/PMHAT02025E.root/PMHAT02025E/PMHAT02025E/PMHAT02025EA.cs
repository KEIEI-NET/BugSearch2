//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリストテーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 発注点設定マスタリストテーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタリストテーブルスキーマ定義クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.03.26</br>
    /// </remarks>
    public class PMHAT02025EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string Tbl_OrderSetMasListReportData = "Tbl_OrderSetMasListReportData";

        /// <summary> 拠点コード </summary>
        public const string Col_SectionCodeRF = "SectionCodeRF";
        /// <summary> 拠点名称 </summary>
        public const string Col_CompanyName1 = "CompanyName1";
        /// <summary> 削除区分 </summary>
        public const string Col_DeleteCodeRF = "DeleteCodeRF";
        /// <summary> 設定コード </summary>
        public const string Col_SetCode = "PatterNoRF";
        /// <summary> パターン番号枝番 </summary>
        public const string Col_PatternNoDerivedNoRF = "PatternNoDerivedNoRF";
        /// <summary> 倉庫コード </summary>
        public const string Col_WarehouseCodeRF = "WarehouseCodeRF";
        /// <summary> 倉庫名称 </summary>
        public const string Col_WarehouseNameRF = "WarehouseNameRF";
        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCdRF = "SupplierCdRF";
        /// <summary> 仕入先名称 </summary>
        public const string Col_SupplierNameRF = "SupplierSnmRF";
        /// <summary> メーカーコード </summary>
        public const string Col_GoodsMakerCdRF = "GoodsMakerCdRF";
        /// <summary> メーカー名称 </summary>
        public const string Col_GoodsMakerNameRF = "MakerNameRF";
        /// <summary> 中分類コード </summary>
        public const string Col_GoodsMGroupCdRF = "GoodsMGroupRF";
        /// <summary> 中分類名称 </summary>
        public const string Col_GoodsMGroupNameRF = "GoodsMGroupNameRF";
        /// <summary> BLグループコード </summary>
        public const string Col_BLGroupCodeRF = "BLGroupCodeRF";
        /// <summary> BLグループ名称 </summary>
        public const string Col_BLGroupNameRF = "BLGroupNameRF";
        /// <summary> BL商品コード </summary>
        public const string Col_BLGoodsCodeRF = "BLGoodsCodeRF";
        /// <summary> BL商品名称 </summary>
        public const string Col_BLGoodsNameRF = "BLGoodsNameRF";
        /// <summary> 在庫出荷対象開始月 </summary>
        public const string Col_StckShipMonthStRF = "StckShipMonthStRF";
        /// <summary> 在庫出荷対象終了月 </summary>
        public const string Col_StckShipMonthEdRF = "StckShipMonthEdRF";
        /// <summary> 在庫登録日 </summary>
        public const string Col_StockCreateDateRF = "StockCreateDateRF";
        /// <summary> 出荷数範囲(以上) </summary>
        public const string Col_ShipScopeMoreRF = "ShipScopeMoreRF";
        /// <summary> 出荷数範囲(以下) </summary>
        public const string Col_ShipScopeLessRF = "ShipScopeLessRF";
        /// <summary> 最低在庫数 </summary>
        public const string Col_MinimumStockCntRF = "MinimumStockCntRF";
        /// <summary> 最高在庫数</summary>
        public const string Col_MaximumStockCntRF = "MaximumStockCntRF";
        /// <summary> ロット数</summary>
        public const string Col_SalesOrderUnitRF = "SalesOrderUnitRF";
        /// <summary> 発注点処理更新フラグ</summary>
        public const string Col_OrderPProcUpdFlgRF = "OrderPProcUpdFlgRF";
        /// <summary> 発注適用区分</summary>
        public const string Col_OrderApplyDivRF = "OrderApplyDivRF";


        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 発注点設定マスタリスト 帳票データ用テーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタリスト 帳票データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public PMHAT02025EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆  発注点設定マスタリストDataSetテーブルスキーマ設定
        /// <summary>
        ///  発注点設定マスタリストDataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタリストデータセットのスキーマを設定する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_OrderSetMasListReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_OrderSetMasListReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Tbl_OrderSetMasListReportData);

                DataTable dt = ds.Tables[Tbl_OrderSetMasListReportData];

                dt.Columns.Add(Col_SectionCodeRF, typeof(string));//拠点コード
                dt.Columns[Col_SectionCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_CompanyName1, typeof(string));//拠点名称
                dt.Columns[Col_CompanyName1].DefaultValue = string.Empty;

                dt.Columns.Add(Col_DeleteCodeRF, typeof(string));//削除区分
                dt.Columns[Col_DeleteCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SetCode, typeof(string));//設定コード
                dt.Columns[Col_SetCode].DefaultValue = string.Empty;

                dt.Columns.Add(Col_PatternNoDerivedNoRF, typeof(string));//パターン番号枝番
                dt.Columns[Col_PatternNoDerivedNoRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseCodeRF, typeof(string));//倉庫コード
                dt.Columns[Col_WarehouseCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_WarehouseNameRF, typeof(string));//倉庫名称
                dt.Columns[Col_WarehouseNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierCdRF, typeof(string));//仕入先コード
                dt.Columns[Col_SupplierCdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SupplierNameRF, typeof(string));//仕入名称
                dt.Columns[Col_SupplierNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMakerCdRF, typeof(string));//メーカーコード
                dt.Columns[Col_GoodsMakerCdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMakerNameRF, typeof(string));//メーカー名称
                dt.Columns[Col_GoodsMakerNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMGroupCdRF, typeof(string));//中分類コード
                dt.Columns[Col_GoodsMGroupCdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_GoodsMGroupNameRF, typeof(string));//中分類名称
                dt.Columns[Col_GoodsMGroupNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupCodeRF, typeof(string));// BLグループコード
                dt.Columns[Col_BLGroupCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGroupNameRF, typeof(string));// BLグループ名称
                dt.Columns[Col_BLGroupNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsCodeRF, typeof(string));// BL商品コード
                dt.Columns[Col_BLGoodsCodeRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_BLGoodsNameRF, typeof(string));// BL商品名称
                dt.Columns[Col_BLGoodsNameRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StckShipMonthStRF, typeof(string));// 在庫出荷対象開始月
                dt.Columns[Col_StckShipMonthStRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StckShipMonthEdRF, typeof(string));// 在庫出荷対象終了月
                dt.Columns[Col_StckShipMonthEdRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_StockCreateDateRF, typeof(string));// 在庫登録日
                dt.Columns[Col_StockCreateDateRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_ShipScopeMoreRF, typeof(string));// 出荷数範囲(以上)
                dt.Columns[Col_ShipScopeMoreRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_ShipScopeLessRF, typeof(string));// 出荷数範囲(以下)
                dt.Columns[Col_ShipScopeLessRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_MinimumStockCntRF, typeof(string));// 最低在庫数
                dt.Columns[Col_MinimumStockCntRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_MaximumStockCntRF, typeof(string));// 最高在庫数
                dt.Columns[Col_MaximumStockCntRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_SalesOrderUnitRF, typeof(string));// ロット数
                dt.Columns[Col_SalesOrderUnitRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_OrderPProcUpdFlgRF, typeof(string));// 発注点処理更新フラグ
                dt.Columns[Col_OrderPProcUpdFlgRF].DefaultValue = string.Empty;

                dt.Columns.Add(Col_OrderApplyDivRF, typeof(string));// 発注適用区分
                dt.Columns[Col_OrderApplyDivRF].DefaultValue = string.Empty;
                
            }
        }
        #endregion
        #endregion
    }
}

