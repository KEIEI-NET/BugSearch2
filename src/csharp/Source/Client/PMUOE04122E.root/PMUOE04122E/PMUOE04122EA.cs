using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 在庫回答情報テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫回答情報テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/11/10</br>
    /// <br>UpdateNote : 2009/02/03 照田 貴志　不具合対応[10841] </br>
    /// <br></br>
    /// <br>UpdateNote : 2012/07/13 30517 夏野 駿希</br>
    /// <br>             仕入原価を小数点以下表示可能に修正</br>
    /// </remarks>
    public class PMUOE04122EA
    {
        #region ■Public定数
        /// <summary> テーブル名称(発注先単位) </summary>
        public const string ct_Tbl_StockAnsSupplier = "Tbl_StockAnsSupplier";
        /// <summary> テーブル名称(明細単位) </summary>
        public const string ct_Tbl_StockAnsDetail = "Tbl_StockAnsDetail";
        /// <summary> テーブル名称(拠点単位) </summary>
        public const string ct_Tbl_StockAnsSection = "Tbl_StockAnsSection";

        // 発注先(明細以外)情報
        /// <summary> UOE発注先名称 </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> UOEリマーク1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOEリマーク2 </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";

        // 明細情報(グリッド用)
        /// <summary> UOE発注先コード </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> UOE発注番号 </summary>
        public const string ct_Col_UOESalesOrder = "UOESalesOrder";
        /// <summary> UOE発注行番号 </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> メーカー </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 標準価格 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> 原単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> 納期 </summary>
        public const string ct_Col_UOEDelivDateCd = "UOEDelivDateCd";
        /// <summary> 代替 </summary>
        public const string ct_Col_UOESubstCode = "UOESubstCode";
        /// <summary> コメント項目 </summary>
        public const string ct_Col_Comment = "Comment";
        #endregion

        // 拠点情報(グリッド用)
        /// <summary>拠点</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>在庫数</summary>
        public const string ct_Col_SectionStock = "SectionStock";

        #region ■ Constructor
        /// <summary>
        /// 在庫回答グリッド用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫回答情報テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        public PMUOE04122EA()
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

            dt = new DataTable(ct_Tbl_StockAnsSupplier);

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

            dt = new DataTable(ct_Tbl_StockAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Int64 defaultValueOfInt64 = 0;

            // 発注先コード
            dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
            dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defaultValueOfInt32;
            // 発注番号
            dt.Columns.Add(ct_Col_UOESalesOrder, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrder].DefaultValue = defaultValueOfInt32;
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
            // 標準価格
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Int64));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defaultValueOfInt64;
            // 原単価
            // upd 2012/07/13 >>>
            //dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Int64));
            //dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defaultValueOfInt64;
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = 0.0;
            // upd 2012/07/13 <<<
            // 納期
            dt.Columns.Add(ct_Col_UOEDelivDateCd, typeof(string));
            dt.Columns[ct_Col_UOEDelivDateCd].DefaultValue = defaultValueOfstring;
            // 代替
            dt.Columns.Add(ct_Col_UOESubstCode, typeof(string));
            dt.Columns[ct_Col_UOESubstCode].DefaultValue = defaultValueOfstring;
            // コメント
            dt.Columns.Add(ct_Col_Comment, typeof(string));
            dt.Columns[ct_Col_Comment].DefaultValue = defaultValueOfstring;
        }

        /// <summary>
        /// DataSetテーブルスキーマ設定(拠点単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        static public void CreateDataTableSection(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーのみ行う。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
                return;
            }

            dt = new DataTable(ct_Tbl_StockAnsSection);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;

            // 拠点
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;

            // 在庫数
            /* ---DEL 2009/02/03 不具合対応[10841] ------------------------------------>>>>>
            dt.Columns.Add(ct_Col_SectionStock, typeof(Int32));
            dt.Columns[ct_Col_SectionStock].DefaultValue = defaultValueOfInt32;
               ---DEL 2009/02/03 不具合対応[10841] ------------------------------------<<<<< */
            // ---ADD 2009/02/03 不具合対応[10841] ------------------------------------>>>>>
            dt.Columns.Add(ct_Col_SectionStock, typeof(string));
            dt.Columns[ct_Col_SectionStock].DefaultValue = defaultValueOfstring;
            // ---ADD 2009/02/03 不具合対応[10841] ------------------------------------<<<<<
        }
        #endregion
    }
}
