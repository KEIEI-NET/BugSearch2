using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 仕入ｱﾝﾏｯﾁﾘｽﾄテーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入ｱﾝﾏｯﾁﾘｽﾄテーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SupplierUnmResult
    {

        /// <summary> テーブル名称 </summary>
        public const string Col_Tbl_Result_SupplierUnm = "Tbl_Result_SupplierUnm";

         /// <summary> 拠点コード </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 拠点ガイド略称 </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先略称 </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> 売上日付 </summary>
        public const string Col_SalesDate = "SalesDate";

        /// <summary> 商品番号 </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> 商品名称 </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> 受注数量 </summary>
        public const string Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";

        /// <summary> BO区分 </summary>
        public const string Col_BoCode = "BoCode";

        /// <summary> 回答定価 </summary>
        public const string Col_AnswerListPrice = "AnswerListPrice";

        /// <summary> 回答原価単価 </summary>
        public const string Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> UOE発注番号 </summary>
        public const string Col_UOESalesOrderNo = "UOESalesOrderNo";

        /// <summary> システム区分 </summary>
        public const string Col_SystemDivCd = "SystemDivCd";

        /// <summary> UOE拠点出庫数 </summary>
        public const string Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";

        /// <summary> BO出庫数1 </summary>
        public const string Col_BOShipmentCnt1 = "BOShipmentCnt1";

        /// <summary> BO出庫数2 </summary>
        public const string Col_BOShipmentCnt2 = "BOShipmentCnt2";

        /// <summary> BO出庫数3 </summary>
        public const string Col_BOShipmentCnt3 = "BOShipmentCnt3";

        /// <summary> メーカーフォロー数 </summary>
        public const string Col_MakerFollowCnt = "MakerFollowCnt";

        /// <summary> UOE拠点伝票番号 </summary>
        public const string Col_UOESectionSlipNo = "UOESectionSlipNo";
        
        /// <summary> BO伝票番号１ </summary>
        public const string Col_BOSlipNo1 = "BOSlipNo1";

        /// <summary> BO伝票番号２ </summary>
        public const string Col_BOSlipNo2 = "BOSlipNo2";

        /// <summary> BO伝票番号３ </summary>
        public const string Col_BOSlipNo3 = "BOSlipNo3";

        /// <summary> EO引当数 </summary>
        public const string Col_EOAlwcCount = "EOAlwcCount";

        // 印刷用
        /// <summary> 受信日付(印刷用) </summary>
        public const string Col_SalesDate_Print = "SalesDate_Print";

        /// <summary> システム区分(印刷用) </summary>
        public const string Col_SystemDivCd_Print = "SystemDivCd_Print";

        /// <summary> 数量 </summary>
        public const string Col_QTY = "QTY";

        /// <summary> 内容 </summary>
        public const string Col_Contents = "Contents";

        /// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄテーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入ｱﾝﾏｯﾁﾘｽﾄテーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.12.17</br>
		/// </remarks>
        public SupplierUnmResult()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        static public void CreateDataTableResultSupplierUnm(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_Result_SupplierUnm))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_Result_SupplierUnm].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_Result_SupplierUnm);

                DataTable dt = ds.Tables[Col_Tbl_Result_SupplierUnm];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_SectionCode, typeof(string));                    // 拠点コード
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));                // 拠点ガイド略称
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // 仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                    // 仕入先略称
                dt.Columns[Col_SupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SalesDate, typeof(DateTime));                    // 売上日付
                dt.Columns[Col_SalesDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                        // 商品番号
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));                      // 商品名称
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcceptAnOrderCnt, typeof(Double));               // 受注数量
                dt.Columns[Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_BoCode, typeof(string));                         // BO区分
                dt.Columns[Col_BoCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AnswerListPrice, typeof(Double));                // 回答定価
                dt.Columns[Col_AnswerListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AnswerSalesUnitCost, typeof(Double));            // 回答原価単価
                dt.Columns[Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UOESalesOrderNo, typeof(Int32));                 // UOE発注番号
                dt.Columns[Col_UOESalesOrderNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SystemDivCd, typeof(Int32));                     // システム区分
                dt.Columns[Col_SystemDivCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESectOutGoodsCnt, typeof(Int32));              // UOE拠点出庫数
                dt.Columns[Col_UOESectOutGoodsCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt1, typeof(Int32));                  // BO出庫数1
                dt.Columns[Col_BOShipmentCnt1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt2, typeof(Int32));                  // BO出庫数2
                dt.Columns[Col_BOShipmentCnt2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt3, typeof(Int32));                  // BO出庫数3
                dt.Columns[Col_BOShipmentCnt3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MakerFollowCnt, typeof(Int32));                  // メーカーフォロー数
                dt.Columns[Col_MakerFollowCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESectionSlipNo, typeof(string));               // UOE拠点伝票番号
                dt.Columns[Col_UOESectionSlipNo].DefaultValue = defValuestring;
                
                dt.Columns.Add(Col_BOSlipNo1, typeof(string));                      // BO伝票番号１
                dt.Columns[Col_BOSlipNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo2, typeof(string));                      // BO伝票番号２
                dt.Columns[Col_BOSlipNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo3, typeof(string));                      // BO伝票番号３
                dt.Columns[Col_BOSlipNo3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EOAlwcCount, typeof(Int32));                     // EO引当数
                dt.Columns[Col_EOAlwcCount].DefaultValue = defValueInt32;
                
                // 印刷用
                dt.Columns.Add(Col_SalesDate_Print, typeof(string));                // 売上日付(印刷用)
                dt.Columns[Col_SalesDate_Print].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SystemDivCd_Print, typeof(string));              // システム区分(印刷用)
                dt.Columns[Col_SystemDivCd_Print].DefaultValue = defValuestring;

                dt.Columns.Add(Col_QTY, typeof(Int32));                             // 数量
                dt.Columns[Col_QTY].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Contents, typeof(string));                       // 内容
                dt.Columns[Col_Contents].DefaultValue = defValuestring;

            }
        }
    }
}
