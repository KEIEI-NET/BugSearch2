using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// データ入力システム定数
    /// </summary>
    /// <remarks>
    /// 受注マスタのデータ入力システムに登録される値を示します。
    /// </remarks>
    public enum DataInputSystem
    {
        /// <summary>0:共通</summary>
        DC = 0,
        /// <summary>1:整備</summary>
        SF = 1,
        /// <summary>2:板金</summary>
        BK = 2,
        /// <summary>3:車販</summary>
        CS = 3,
        /// <summary>10:ＰＭ</summary>
        PM = 10,
        /// <summary>11:電装</summary>
        DN = 11,
        /// <summary>12:硝子</summary>
        GL = 12,
        /// <summary>13:ＲＣ</summary>
        RC = 13
    }

    /// <summary>
    /// 伝票データ区分定数
    /// </summary>
    /// <remarks>
    /// 受注マスタの受注ステータスや連携元データ区分に登録される値を示します。
    /// </remarks>
    public enum SlipDataDivide
    {
        /// <summary> 1:見積</summary>
        Estimate = 1,
        /// <summary> 2:発注</summary>
        SalesOrder = 2,
        /// <summary> 3:受注</summary>
        AcceptAnOrder = 3,
        /// <summary> 4:入荷</summary>
        ArrivalGoods = 4, 
        /// <summary> 5:出荷</summary>
        Shipment = 5,
        /// <summary> 6:仕入</summary>
        Stock = 6,
        /// <summary> 7:売上</summary>
        Sales = 7,
        /// <summary> 8:入金</summary>
        Deposit = 8,
        /// <summary> 9:支払</summary>
        Payment = 9,
        /*
        /// <summary>10:入荷返品</summary>
        ArrivalReturnedGoods = 10,
        /// <summary>11:出荷返品</summary>
        ShipmentReturnedGoods = 11,
        /// <summary>12:仕入返品</summary>
        StockReturnedGoods = 12,
        /// <summary>13:売上返品</summary>
        SalesReturnedGoods = 13
        */
        // --- ADD 2013/02/13 ---------->>>>>
        // 仕入返品予定用区分を追加
        StockRetPlan = 14,
        // --- ADD 2013/02/13 ----------<<<<<
    }

    /// public class name:   AcceptOdrExtractWork
    /// <summary>
    ///                      受注抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   受注抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AcceptOdrExtractWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>受注番号</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>受注ステータス</summary>
        /// <remarks>1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>伝票番号</summary>
        /// <remarks>それぞれの伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>データ入力システム</summary>
        /// <remarks>0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC </remarks>
        private Int32 _dataInputSystem;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>明細通番</summary>
        private Int64 _slipDtlNum;

        /// <summary>明細通番枝番</summary>
        /// <remarks>0 の場合、同じ明細通番を持つレコードの中で最も大きい明細通番枝番を持つレコードを抽出する。</remarks>
        private Int32 _slipDtlNumDerivNo;

        /// <summary>連携元データ区分</summary>
        /// <remarks>1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払</remarks>
        private Int32 _srcLinkDataCode;

        /// <summary>連携元明細通番</summary>
        private Int64 _srcSlipDtlNum;


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>伝票番号プロパティ</summary>
        /// <value>それぞれの伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>データ入力システムプロパティ</summary>
        /// <value>0:共通,1:整備,2:鈑金,3:車販 10:PM,11:電装,12:硝子,13:RC </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>共通通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  SlipDtlNum
        /// <summary>明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SlipDtlNum
        {
            get { return _slipDtlNum; }
            set { _slipDtlNum = value; }
        }

        /// public propaty name  :  SlipDtlNumDerivNo
        /// <summary>明細通番枝番プロパティ</summary>
        /// <value>0 の場合、同じ明細通番を持つレコードの中で最も大きい明細通番枝番を持つレコードを抽出する。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細通番枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipDtlNumDerivNo
        {
            get { return _slipDtlNumDerivNo; }
            set { _slipDtlNumDerivNo = value; }
        }

        /// public propaty name  :  SrcLinkDataCode
        /// <summary>連携元データ区分プロパティ</summary>
        /// <value>1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携元データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SrcLinkDataCode
        {
            get { return _srcLinkDataCode; }
            set { _srcLinkDataCode = value; }
        }

        /// public propaty name  :  SrcSlipDtlNum
        /// <summary>連携元明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連携元明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SrcSlipDtlNum
        {
            get { return _srcSlipDtlNum; }
            set { _srcSlipDtlNum = value; }
        }

        /// <summary>
        /// 受注抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>AcceptOdrExtractWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AcceptOdrExtractWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AcceptOdrExtractWork()
        {
        }
    }
}
