using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 見積回答情報テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見積回答情報テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/10</br>
    /// </remarks>
    public class PMUOE04112EA
    {
        #region ■Public定数
        /// <summary> テーブル名称(発注先単位) </summary>
        public const string ct_Tbl_EstmtAnsSupplier = "Tbl_EstmtAnsSupplier";
        /// <summary> テーブル名称(明細単位) </summary>
        public const string ct_Tbl_EstmtAnsDetail = "Tbl_EstmtAnsDetail";

        // 発注先(明細以外)情報
        /// <summary> UOE発注先名称 </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOEリマーク1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOEリマーク2 </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> グリッド可変項目ヘッダー名称1 </summary>
        public const string ct_Col_GridHeadVariableName1 = "GridHeadVariableName1";
        /// <summary> グリッド可変項目ヘッダー名称2 </summary>
        public const string ct_Col_GridHeadVariableName2 = "GridHeadVariableName2";
        /// <summary> グリッド可変項目ヘッダー名称3 </summary>
        public const string ct_Col_GridHeadVariableName3 = "GridHeadVariableName3";
        /// <summary> グリッド可変項目ヘッダー名称4 </summary>
        public const string ct_Col_GridHeadVariableName4 = "GridHeadVariableName4";
        /// <summary> 標準価格合計 </summary>
        public const string ct_Col_AnswerListPriceTotal = "AnswerListPriceTotal";
        /// <summary> 原単価合計 </summary>
        public const string ct_Col_AnswerSalesUnitCostTotal = "AnswerSalesUnitCostTotal";

        // 明細情報(グリッド用)
        /// <summary> UOE発注行番号 </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> メーカー </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 標準価格 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> 原単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> コメント項目 </summary>
        public const string ct_Col_Comment = "Comment";
        /// <summary> 可変項目1 </summary>
        public const string ct_Col_Variable1 = "Variable1";
        /// <summary> 可変項目2 </summary>
        public const string ct_Col_Variable2 = "Variable2";
        /// <summary> 可変項目3 </summary>
        public const string ct_Col_Variable3 = "Variable3";
        /// <summary> 可変項目4 </summary>
        public const string ct_Col_Variable4 = "Variable4";
        #endregion

        #region ■ Constructor
        /// <summary>
        /// 見積回答グリッド用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 見積回答情報テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04112EA()
        {
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// DataSetテーブルスキーマ設定(発注先単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        static public void CreateDataTableSupplier(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーのみ行う。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_EstmtAnsSupplier);

            string defaultValueOfstring = string.Empty;

            // UOE発注先名称
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defaultValueOfstring;
            // UOEリマーク1
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defaultValueOfstring;
            // UOEリマーク2
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defaultValueOfstring;
            // グリッド可変項目ヘッダー名称1
            dt.Columns.Add(ct_Col_GridHeadVariableName1, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName1].DefaultValue = defaultValueOfstring;
            // グリッド可変項目ヘッダー名称2
            dt.Columns.Add(ct_Col_GridHeadVariableName2, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName2].DefaultValue = defaultValueOfstring;
            // グリッド可変項目ヘッダー名称3
            dt.Columns.Add(ct_Col_GridHeadVariableName3, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName3].DefaultValue = defaultValueOfstring;
            // グリッド可変項目ヘッダー名称4
            dt.Columns.Add(ct_Col_GridHeadVariableName4, typeof(string));
            dt.Columns[ct_Col_GridHeadVariableName4].DefaultValue = defaultValueOfstring;
            // 標準価格合計
            dt.Columns.Add(ct_Col_AnswerListPriceTotal, typeof(string));
            dt.Columns[ct_Col_AnswerListPriceTotal].DefaultValue = defaultValueOfstring;
            // 原単価合計
            dt.Columns.Add(ct_Col_AnswerSalesUnitCostTotal, typeof(string));
            dt.Columns[ct_Col_AnswerSalesUnitCostTotal].DefaultValue = defaultValueOfstring;
        }

        /// <summary>
        /// DataSetテーブルスキーマ設定(明細単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        static public void CreateDataTableDetail(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーのみ行う。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_EstmtAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Int64 defaultValueOfInt64 = 0;

            // 発注行番号
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // 品番
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // メーカー
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // 品名
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;
            // 数量
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Int64));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfInt64;
            // 標準価格
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Int64));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defaultValueOfInt64;
            // 原単価
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Int64));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defaultValueOfInt64;
            // コメント
            dt.Columns.Add(ct_Col_Comment, typeof(string));
            dt.Columns[ct_Col_Comment].DefaultValue = defaultValueOfstring;
            // 可変項目1
            dt.Columns.Add(ct_Col_Variable1, typeof(string));
            dt.Columns[ct_Col_Variable1].DefaultValue = defaultValueOfstring;
            // 可変項目2
            dt.Columns.Add(ct_Col_Variable2, typeof(string));
            dt.Columns[ct_Col_Variable2].DefaultValue = defaultValueOfstring;
            // 可変項目3
            dt.Columns.Add(ct_Col_Variable3, typeof(string));
            dt.Columns[ct_Col_Variable3].DefaultValue = defaultValueOfstring;
            // 可変項目4
            dt.Columns.Add(ct_Col_Variable4, typeof(string));
            dt.Columns[ct_Col_Variable4].DefaultValue = defaultValueOfstring;
        }
        #endregion
    }
}
