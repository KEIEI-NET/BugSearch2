//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷対応表
// プログラム概要   : 型式別出荷対応表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 型式別出荷対応表 テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式別出荷対応表 テーブルスキーマ情報クラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class PMSYA02205EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string Tbl_ModelShipListData = "Tbl_ModelShipListData";
        /// <summary>実績計上拠点コード</summary>
        public const string ct_Col_ResultsAddUpSecCdRF = "ResultsAddUpSecCdRF";
        /// <summary>拠点ガイド略称</summary>
        public const string ct_Col_SectionGuideSnmRF = "SectionGuideSnmRF";
        /// <summary>メーカーコード</summary>
        public const string ct_Col_MakerCodeRF = "MakerCodeRF";
        /// <summary>車種コード</summary>
        public const string ct_Col_ModelCodeRF = "ModelCodeRF";
        /// <summary>車種サブコード</summary>
        public const string ct_Col_ModelSubCodeRF = "ModelSubCodeRF";
        /// <summary>車種半角名称</summary>
        public const string ct_Col_ModelHalfNameRF = "ModelHalfNameRF";
        /// <summary>型式（フル型）</summary>
        public const string ct_Col_FullModelRF = "FullModelRF";
        /// <summary>BL商品コード</summary>
        public const string ct_Col_BLGoodsCodeRF = "BLGoodsCodeRF";
        /// <summary>BL商品コード名称（半角）</summary>
        public const string ct_Col_BLGoodsHalfNameRF = "BLGoodsHalfNameRF";
        /// <summary>商品メーカーコード（純正）</summary>
        public const string ct_Col_GoodsMakerCd1RF = "GoodsMakerCd1RF";
        /// <summary>商品メーカー名称（純正）</summary>
        public const string ct_Col_GoodsMakerName1RF = "GoodsMakerName1RF";
        /// <summary>純正品番</summary>
        public const string ct_Col_GoodsNo1RF = "GoodsNo1RF";
        /// <summary>出荷数</summary>
        public const string ct_Col_ShipmentCntRF = "ShipmentCntRF";
        /// <summary>売上単価（税抜，浮動）</summary>
        public const string ct_Col_SalesUnPrcTaxExcFlRF = "SalesUnPrcTaxExcFlRF";
        /// <summary>売上金額（税抜き）</summary>
        public const string ct_Col_SalesMoneyTaxExcRF = "SalesMoneyTaxExcRF";
        /// <summary>倉庫棚番</summary>
        public const string ct_Col_WarehouseShelfNoRF = "WarehouseShelfNoRF";
        /// <summary>仕入在庫数</summary>
        public const string ct_Col_SupplierStockRF = "SupplierStockRF";
        /// <summary>商品メーカーコード（優良）</summary>
        public const string ct_Col_GoodsMakerCd2RF = "GoodsMakerCd2RF";
        /// <summary>商品メーカー名称（優良）</summary>
        public const string ct_Col_GoodsMakerName2RF = "GoodsMakerName2RF";
        /// <summary>対応品番</summary>
        public const string ct_Col_GoodsNo2RF = "GoodsNo2RF";
        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 型式別出荷対応表 テーブルスキーマ情報クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 型式別出荷対応表 テーブルスキーマ情報クラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 王海立</br>
		/// <br>Date       : 2010/04/22</br>
		/// </remarks>
        public PMSYA02205EA()
		{
		}
		#endregion

        #region ■ Static Public Method
        #region ◆ データDataSetテーブルスキーマ設定
        /// <summary>
        /// データDataSetテーブルスキーマ設定
		/// </summary>
        /// <param name="ds">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : データデータセットのスキーマを設定する。</br>
		/// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/22</br>
		/// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Tbl_ModelShipListData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Tbl_ModelShipListData].Clear();
            }
            else
            {
                // スキーマ設定

                ds.Tables.Add(Tbl_ModelShipListData);

                DataTable dt = ds.Tables[Tbl_ModelShipListData];

                // 実績計上拠点コード
                dt.Columns.Add(ct_Col_ResultsAddUpSecCdRF, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCdRF].DefaultValue = "";
                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnmRF, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnmRF].DefaultValue = "";
                // メーカーコード
                dt.Columns.Add(ct_Col_MakerCodeRF, typeof(string));
                dt.Columns[ct_Col_MakerCodeRF].DefaultValue = "";
                // 車種コード
                dt.Columns.Add(ct_Col_ModelCodeRF, typeof(string));
                dt.Columns[ct_Col_ModelCodeRF].DefaultValue = "";
                // 車種サブコード
                dt.Columns.Add(ct_Col_ModelSubCodeRF, typeof(string));
                dt.Columns[ct_Col_ModelSubCodeRF].DefaultValue = "";
                // 車種半角名称
                dt.Columns.Add(ct_Col_ModelHalfNameRF, typeof(string));
                dt.Columns[ct_Col_ModelHalfNameRF].DefaultValue = "";
                // 型式（フル型）
                dt.Columns.Add(ct_Col_FullModelRF, typeof(string));
                dt.Columns[ct_Col_FullModelRF].DefaultValue = "";
                // BL商品コード
                dt.Columns.Add(ct_Col_BLGoodsCodeRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsCodeRF].DefaultValue = "";
                // BL商品コード名称（半角）
                dt.Columns.Add(ct_Col_BLGoodsHalfNameRF, typeof(string));
                dt.Columns[ct_Col_BLGoodsHalfNameRF].DefaultValue = "";
                // 商品メーカーコード（純正）
                dt.Columns.Add(ct_Col_GoodsMakerCd1RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd1RF].DefaultValue = "";
                // 商品メーカー名称（純正）
                dt.Columns.Add(ct_Col_GoodsMakerName1RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerName1RF].DefaultValue = "";
                // 純正番号
                dt.Columns.Add(ct_Col_GoodsNo1RF, typeof(string));
                dt.Columns[ct_Col_GoodsNo1RF].DefaultValue = "";
                // 出荷数
                dt.Columns.Add(ct_Col_ShipmentCntRF, typeof(string));
                dt.Columns[ct_Col_ShipmentCntRF].DefaultValue = "";
                // 売上単価（税抜，浮動）
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFlRF, typeof(string));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFlRF].DefaultValue = "";
                // 売上金額（税抜き）
                dt.Columns.Add(ct_Col_SalesMoneyTaxExcRF, typeof(string));
                dt.Columns[ct_Col_SalesMoneyTaxExcRF].DefaultValue = "";
                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNoRF, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNoRF].DefaultValue = "";
                // 仕入在庫数
                dt.Columns.Add(ct_Col_SupplierStockRF, typeof(string));
                dt.Columns[ct_Col_SupplierStockRF].DefaultValue = "";
                // 商品メーカーコード（優良）
                dt.Columns.Add(ct_Col_GoodsMakerCd2RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerCd2RF].DefaultValue = "";
                // 商品メーカー名称（優良）
                dt.Columns.Add(ct_Col_GoodsMakerName2RF, typeof(string));
                dt.Columns[ct_Col_GoodsMakerName2RF].DefaultValue = "";
                // 対応番号
                dt.Columns.Add(ct_Col_GoodsNo2RF, typeof(string));
                dt.Columns[ct_Col_GoodsNo2RF].DefaultValue = "";
            }
        }

        #endregion ◆ データDataSetテーブルスキーマ設定

        #endregion ■ Static Public Method

    }
}
