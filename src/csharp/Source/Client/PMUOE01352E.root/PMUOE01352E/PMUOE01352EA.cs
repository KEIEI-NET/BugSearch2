using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 卸商仕入回答情報テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 卸商仕入回答情報テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 渋谷 大輔</br>
    /// <br>Date       : 2008/12/16</br>
    /// <br>Update Note: 2011/08/10 caohh 連番736</br>
    /// <br>           : NSユーザー改良要望一覧連番736の対応</br>
    /// </remarks>
    public class PMUOE01352EA
    {
        #region ■Public定数
        /// <summary> テーブル名称(明細単位) </summary>
        public const string ct_Tbl_OrderAnsDetail = "Tbl_OrderAnsDetail";
        /// <summary> 明細のグループ名称 </summary>
        public const string ct_Grp_OrderAnsDeltail = "Grp_OrderAnsDetail";

        // 明細情報(グリッド用)
        /// <summary> UOE発注行番号 </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> 受信日付 </summary>
        public const string ct_Col_ReceiveDate = "ReceiveDate";
        // ------ ADD 2011/08/10 ------>>>>>
        /// <summary> 受信日付 </summary>
        /// <remarks> YY/MM/DD</remarks>
        public const string ct_Col_ReceiveDateYMD = "ReceiveDateYmd";
        /// <summary> 受信時刻 </summary>
        public const string ct_Col_ReceiveTime = "ReceiveTime";
        // ------ ADD 2011/08/10 ------<<<<<
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> UOE納品区分 </summary>
        public const string ct_Col_DeliGoodsDiv = "DeliGoodsDiv";
        /// <summary> 納品区分名称 </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> 回答品名 </summary>
        public const string ct_Col_AnswerpartsName = "AnswerpartsName";
        /// <summary> 回答原価単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> UOE拠点伝票番号 </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> UOEチェックコード </summary>
        public const string ct_Col_UOECheckCode = "UOECheckCode";
        /// <summary> UOEリマーク1 </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> UOE発注番号 </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> 回答品番 </summary>
        public const string ct_Col_AnswerpartsNo = "AnswerpartsNo";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 回答定価 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> UOE拠点出庫数 </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> 未出庫数 </summary>
        public const string ct_Col_NonShipmentCnt = "NonShipmentCnt";
        /// <summary> ラインエラーメッセージ </summary>
        public const string ct_Col_LineErrorMessage = "LineErrorMessage";
        /// <summary> 前景色 </summary>
        public const string ct_Col_ForeColor = "ForeColor";

        #endregion

        #region ■ Constructor
        /// <summary>
        /// 卸商仕入回答グリッド用テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 卸商仕入回答情報テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 渋谷 大輔</br>
        /// <br>Date       : 2008/12/16</br>
        /// </remarks>
        public PMUOE01352EA()
        {
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// DataSetテーブルスキーマ設定(明細単位)
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 渋谷 大輔</br>
        /// <br>Date       : 2008/12/16</br>
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

            dt = new DataTable(ct_Tbl_OrderAnsDetail);

            string defaultValueOfstring = string.Empty;
            Int32 defaultValueOfInt32 = 0;
            Double defaultValueOfDouble = 0.0;

            // 受信日付
            dt.Columns.Add(ct_Col_ReceiveDate, typeof(string));
            dt.Columns[ct_Col_ReceiveDate].DefaultValue = defaultValueOfstring;
            // ------ ADD 2011/08/10 ------>>>>>
            // 受信日付(YY/MM/DD)
            dt.Columns.Add(ct_Col_ReceiveDateYMD, typeof(string));
            dt.Columns[ct_Col_ReceiveDateYMD].DefaultValue = defaultValueOfstring;
            // 受信時刻
            dt.Columns.Add(ct_Col_ReceiveTime, typeof(string));
            dt.Columns[ct_Col_ReceiveTime].DefaultValue = defaultValueOfstring;
            // 納品区分名称
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defaultValueOfstring;
            // メーカーコード
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(string));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defaultValueOfstring;
            // ------ ADD 2011/08/10 ------<<<<<
            // 品番
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;
            // UOE納品区分
            dt.Columns.Add(ct_Col_DeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_DeliGoodsDiv].DefaultValue = defaultValueOfstring;
            // 回答品名
            dt.Columns.Add(ct_Col_AnswerpartsName, typeof(string));
            dt.Columns[ct_Col_AnswerpartsName].DefaultValue = defaultValueOfstring;
            // 回答原価単価
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defaultValueOfDouble;
            // UOE拠点伝票番号
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defaultValueOfstring;
            // UOEチェックコード
            dt.Columns.Add(ct_Col_UOECheckCode, typeof(string));
            dt.Columns[ct_Col_UOECheckCode].DefaultValue = defaultValueOfstring;
            // UOEリマーク1
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defaultValueOfstring;
            // UOE発注番号
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defaultValueOfInt32;
            // UOE発注行番号
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defaultValueOfInt32;
            // 回答品番
            dt.Columns.Add(ct_Col_AnswerpartsNo, typeof(string));
            dt.Columns[ct_Col_AnswerpartsNo].DefaultValue = defaultValueOfstring;
            // 受注数量
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;
            // メーカー名称
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;
            // 回答定価
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defaultValueOfDouble;
            // UOE拠点出庫数
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defaultValueOfInt32;
            // 未出庫数
            dt.Columns.Add(ct_Col_NonShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_NonShipmentCnt].DefaultValue = defaultValueOfInt32;
            // ラインエラーメッセージ
            dt.Columns.Add(ct_Col_LineErrorMessage, typeof(string));
            dt.Columns[ct_Col_LineErrorMessage].DefaultValue = defaultValueOfstring;
        }
        #endregion
    }
}
