using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 入庫予定表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入庫予定表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.03</br>
    /// <br>Note       : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/09/14</br>
    /// </remarks>
    public class EnterSchResult
    {

        /// <summary> テーブル名称 </summary>
        public const string Col_Tbl_Result_EnterSch = "Tbl_Result_EnterSch";

        /// <summary> 拠点コード </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 拠点ガイド略称 </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 倉庫コード </summary>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> 倉庫名称 </summary>
        public const string Col_WarehouseName = "WarehouseName";

        /// <summary> 倉庫棚番 </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> 商品番号 </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> 商品メーカーコード </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> 商品名称 </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> 受注数量 </summary>
        public const string Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";

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

        /// <summary> EO引当数 </summary>
        public const string Col_EOAlwcCount = "EOAlwcCount";

        /// <summary> 回答定価 </summary>
        public const string Col_AnswerListPrice = "AnswerListPrice";

        /// <summary> 回答原価単価 </summary>
        public const string Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> BO伝票番号１ </summary>
        public const string Col_BOSlipNo1 = "BOSlipNo1";

        /// <summary> BO伝票番号２ </summary>
        public const string Col_BOSlipNo2 = "BOSlipNo2";

        /// <summary> BO伝票番号３ </summary>
        public const string Col_BOSlipNo3 = "BOSlipNo3";

        /// <summary> UOE拠点伝票番号 </summary>
        public const string Col_UOESectionSlipNo = "UOESectionSlipNo";

        /// <summary> ＵＯＥリマーク１ </summary>
        public const string Col_UoeRemark1 = "UoeRemark1";

        /// <summary> ＵＯＥリマーク２ </summary>
        public const string Col_UoeRemark2 = "UoeRemark2";

        /// <summary> 受信日付 </summary>
        public const string Col_ReceiveDate = "ReceiveDate";

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary> 仕入SEQ番号(バーコード化用) </summary>
        public const string ct_Col_SupplierSeqNoForBarCode = "SupplierSeqNoForBarCode";
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ↓↓印刷用
        /// <summary> 入庫数(印刷用) </summary>
        public const string Col_OutGoodsCnt_Print = "OutGoodsCnt_Print";
        /// <summary> BO数(印刷用) </summary>
        public const string Col_BOCnt_Print = "BOCnt_Print";
        /// <summary> 仕入伝票番号(印刷用) </summary>
        public const string Col_SlipNo_Print = "SlipNo_Print";

        /// <summary>
		/// 入庫予定表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 回収予定表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.12.03</br>
		/// </remarks>
        public EnterSchResult()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.03</br>
        /// </remarks>
        static public void CreateDataTableResultEnterSch(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_Result_EnterSch))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_Result_EnterSch].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_Result_EnterSch);

                DataTable dt = ds.Tables[Col_Tbl_Result_EnterSch];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_SectionCode, typeof(string));                    // 拠点コード
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));                // 拠点ガイド略称
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));                  // 倉庫コード
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));                  // 倉庫名称
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));               // 倉庫棚番
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                        // 商品番号
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));                    // 商品メーカーコード
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsName, typeof(string));                      // 商品名称
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcceptAnOrderCnt, typeof(Double));               // 受注数量
                dt.Columns[Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

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

                dt.Columns.Add(Col_EOAlwcCount, typeof(Int32));                     // EO引当数
                dt.Columns[Col_EOAlwcCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AnswerListPrice, typeof(Double));                // 回答定価
                dt.Columns[Col_AnswerListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AnswerSalesUnitCost, typeof(Double));            // 回答原価単価
                dt.Columns[Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // 仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOSlipNo1, typeof(string));                      // BO伝票番号１
                dt.Columns[Col_BOSlipNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo2, typeof(string));                      // BO伝票番号２
                dt.Columns[Col_BOSlipNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo3, typeof(string));                      // BO伝票番号３
                dt.Columns[Col_BOSlipNo3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOESectionSlipNo, typeof(string));               // UOE拠点伝票番号
                dt.Columns[Col_UOESectionSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark1, typeof(string));                     // ＵＯＥリマーク１
                dt.Columns[Col_UoeRemark1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark2, typeof(string));                     // ＵＯＥリマーク２
                dt.Columns[Col_UoeRemark2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ReceiveDate, typeof(string));                    // 受信日付
                dt.Columns[Col_ReceiveDate].DefaultValue = defValuestring;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                dt.Columns.Add(ct_Col_SupplierSeqNoForBarCode, typeof(string)); // 仕入伝票番号
                dt.Columns[ct_Col_SupplierSeqNoForBarCode].DefaultValue = defValuestring;
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

                // ↓↓印刷用
                dt.Columns.Add(Col_OutGoodsCnt_Print, typeof(Int32));               // 入庫数(印刷用)
                dt.Columns[Col_OutGoodsCnt_Print].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOCnt_Print, typeof(Int32));                     // BO数(印刷用)
                dt.Columns[Col_BOCnt_Print].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SlipNo_Print, typeof(string));                   // 仕入伝票番号(印刷用)
                dt.Columns[Col_SlipNo_Print].DefaultValue = defValuestring;
            }
        }
    }
}
