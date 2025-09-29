//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表　テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//


using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 入荷差異表　テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷差異表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    public class PMKOU02354EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_ArrGoodsDiffReportData = "Tbl_ArrGoodsDiffReportData";

        /// <summary> 発注先コード </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> 発注先名 </summary>
        public const string ct_Col_UOESupplierNm = "UOESupplierNm";
        /// <summary> 伝票番号 </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> メーカー </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 発注数 </summary>
        public const string ct_Col_OrderCnt = "OrderCnt";
        /// <summary> 発注残 </summary>
        public const string ct_Col_OrderRemainCnt = "OrderRemainCnt";
        /// <summary> 検品数 </summary>
        public const string ct_Col_InspectCnt = "InspectCnt";
        /// <summary> 差異 </summary>
        public const string ct_Col_DiffCnt = "DiffCnt";
        /// <summary> 倉庫 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 発注者 </summary>
        public const string ct_Col_StockAgentName = "StockAgentName";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 入荷差異表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷差異表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        public PMKOU02354EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 入荷差異表DataSetテーブルスキーマ設定
        /// <summary>
        /// 入荷差異表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 入荷差異表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : K2019/08/14</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_ArrGoodsDiffReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_ArrGoodsDiffReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_ArrGoodsDiffReportData);

                DataTable dt = ds.Tables[ct_Tbl_ArrGoodsDiffReportData];


                // 発注先コード
                dt.Columns.Add(ct_Col_UOESupplierCd, typeof(string));
                dt.Columns[ct_Col_UOESupplierCd].DefaultValue = string.Empty;

                // 発注先名
                dt.Columns.Add(ct_Col_UOESupplierNm, typeof(string));
                dt.Columns[ct_Col_UOESupplierNm].DefaultValue = string.Empty;

                // 伝票番号
                dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(string));
                dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = string.Empty;

                // 品番
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = string.Empty;

                // 品名
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = string.Empty;

                // メーカー
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = string.Empty;

                // 発注数
                dt.Columns.Add(ct_Col_OrderCnt, typeof(Double));
                dt.Columns[ct_Col_OrderCnt].DefaultValue = 0.0;

                // 発注残
                dt.Columns.Add(ct_Col_OrderRemainCnt, typeof(Double));
                dt.Columns[ct_Col_OrderRemainCnt].DefaultValue = 0.0;

                // 検品数
                dt.Columns.Add(ct_Col_InspectCnt, typeof(Double));
                dt.Columns[ct_Col_InspectCnt].DefaultValue = 0.0;

                // 差異
                dt.Columns.Add(ct_Col_DiffCnt, typeof(Double));
                dt.Columns[ct_Col_DiffCnt].DefaultValue = 0.0;

                // 倉庫
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = string.Empty;

                // 発注者
                dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
                dt.Columns[ct_Col_StockAgentName].DefaultValue = string.Empty;

            }
        }
        #endregion ◆ 入荷差異表DataSetテーブルスキーマ設定
        #endregion ■ Static Public Method
    }
}