using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockConfShWork
    /// <summary>
    ///                      仕入確認表抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入確認表抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/06/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   6/30  田中</br>
    /// <br>                 :   Partsman.NS対応</br>
    /// <br>                 :   ・仕入形式、仕入伝票番号の補足説明をPM.NSの意味合いに変更</br>
    /// <br>                 :   ・得意先コードを仕入先コードに変更（得意先分離対応）</br>
    /// <br>                 :   ・地区コード、出力指定、仕入在庫取寄せ区分の追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockConfShWork
    //public class StockConfShWork : IFileHeader
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>全社選択</summary>
        /// <remarks>true:全社選択　false:各拠点選択</remarks>
        private Boolean _isSelectAllSection;

        /// <summary>全拠点レコード出力</summary>
        /// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
        private Boolean _isOutputAllSecRec;

        /// <summary>仕入拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _stockSectionCd;

        /// <summary>仕入日(開始)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _stockDateSt;

        /// <summary>仕入日(終了)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _stockDateEd;

        /// <summary>入荷日(開始)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _arrivalGoodsDaySt;

        /// <summary>入荷日(終了)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _arrivalGoodsDayEd;

        /// <summary>入力日(開始)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _inputDaySt;

        /// <summary>入力日(終了)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _inputDayEd;

        /// <summary>発行タイプ</summary>
        /// <remarks>0:通常 1:訂正 2:削除 3:訂正+削除</remarks>
        private Int32 _printType;

        /// <summary>赤伝区分</summary>
        /// <remarks>-1:全て 0:黒伝 1:赤伝 2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号(開始)</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　※仕入SEQ</remarks>
        private Int32 _supplierSlipNoSt;

        /// <summary>仕入伝票番号(終了)</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
        private Int32 _supplierSlipNoEd;

        /// <summary>仕入担当者コード(開始)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _stockAgentCodeSt = "";

        /// <summary>仕入担当者コード(終了)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _stockAgentCodeEd = "";

        /// <summary>仕入伝票区分</summary>
        /// <remarks>0:全て 10:仕入 20:返品</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>相手先伝票番号(開始)</summary>
        /// <remarks>未入力時は空文字("") ※仕入先伝票番号</remarks>
        private string _partySaleSlipNumSt = "";

        /// <summary>相手先伝票番号(終了)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _partySaleSlipNumEd = "";

        /// <summary>仕入先コード(開始)</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _supplierCdEd;

        /// <summary>販売エリアコード(開始)</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCodeSt;

        /// <summary>販売エリアコード(終了)</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCodeEd;

        /// <summary>出力指定</summary>
        /// <remarks>0:全て 1:仕入入力 2:UOE分 3:同時入力分 4:UOEアンマッチ</remarks>
        private Int32 _outputDesignated;

        /// <summary>仕入在庫取寄せ区分</summary>
        /// <remarks>-1:全て,0:取寄せ,1:在庫</remarks>
        private Int32 _stockOrderDivCd;


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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// <value>true:全社選択　false:各拠点選択</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsSelectAllSection
        {
            get { return _isSelectAllSection; }
            set { _isSelectAllSection = value; }
        }

        /// public propaty name  :  IsOutputAllSecRec
        /// <summary>全拠点レコード出力プロパティ</summary>
        /// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点レコード出力プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsOutputAllSecRec
        {
            get { return _isOutputAllSecRec; }
            set { _isOutputAllSecRec = value; }
        }

        /// public propaty name  :  StockSectionCd
        /// <summary>仕入拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        /// public propaty name  :  StockDateSt
        /// <summary>仕入日(開始)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateSt
        {
            get { return _stockDateSt; }
            set { _stockDateSt = value; }
        }

        /// public propaty name  :  StockDateEd
        /// <summary>仕入日(終了)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateEd
        {
            get { return _stockDateEd; }
            set { _stockDateEd = value; }
        }

        /// public propaty name  :  ArrivalGoodsDaySt
        /// <summary>入荷日(開始)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ArrivalGoodsDaySt
        {
            get { return _arrivalGoodsDaySt; }
            set { _arrivalGoodsDaySt = value; }
        }

        /// public propaty name  :  ArrivalGoodsDayEd
        /// <summary>入荷日(終了)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ArrivalGoodsDayEd
        {
            get { return _arrivalGoodsDayEd; }
            set { _arrivalGoodsDayEd = value; }
        }

        /// public propaty name  :  InputDaySt
        /// <summary>入力日(開始)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDaySt
        {
            get { return _inputDaySt; }
            set { _inputDaySt = value; }
        }

        /// public propaty name  :  InputDayEd
        /// <summary>入力日(終了)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDayEd
        {
            get { return _inputDayEd; }
            set { _inputDayEd = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>発行タイププロパティ</summary>
        /// <value>0:通常 1:訂正 2:削除 3:訂正+削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>-1:全て 0:黒伝 1:赤伝 2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNoSt
        /// <summary>仕入伝票番号(開始)プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる　※仕入SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoSt
        {
            get { return _supplierSlipNoSt; }
            set { _supplierSlipNoSt = value; }
        }

        /// public propaty name  :  SupplierSlipNoEd
        /// <summary>仕入伝票番号(終了)プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNoEd
        {
            get { return _supplierSlipNoEd; }
            set { _supplierSlipNoEd = value; }
        }

        /// public propaty name  :  StockAgentCodeSt
        /// <summary>仕入担当者コード(開始)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCodeSt
        {
            get { return _stockAgentCodeSt; }
            set { _stockAgentCodeSt = value; }
        }

        /// public propaty name  :  StockAgentCodeEd
        /// <summary>仕入担当者コード(終了)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCodeEd
        {
            get { return _stockAgentCodeEd; }
            set { _stockAgentCodeEd = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>仕入伝票区分プロパティ</summary>
        /// <value>0:全て 10:仕入 20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  PartySaleSlipNumSt
        /// <summary>相手先伝票番号(開始)プロパティ</summary>
        /// <value>未入力時は空文字("") ※仕入先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNumSt
        {
            get { return _partySaleSlipNumSt; }
            set { _partySaleSlipNumSt = value; }
        }

        /// public propaty name  :  PartySaleSlipNumEd
        /// <summary>相手先伝票番号(終了)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNumEd
        {
            get { return _partySaleSlipNumEd; }
            set { _partySaleSlipNumEd = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>販売エリアコード(開始)プロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>販売エリアコード(終了)プロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  OutputDesignated
        /// <summary>出力指定プロパティ</summary>
        /// <value>0:全て 1:仕入入力 2:UOE分 3:同時入力分 4:UOEアンマッチ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputDesignated
        {
            get { return _outputDesignated; }
            set { _outputDesignated = value; }
        }

        /// public propaty name  :  StockOrderDivCd
        /// <summary>仕入在庫取寄せ区分プロパティ</summary>
        /// <value>-1:全て,0:取寄せ,1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCd
        {
            get { return _stockOrderDivCd; }
            set { _stockOrderDivCd = value; }
        }


        /// <summary>
        /// 仕入確認表抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>StockConfShWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockConfShWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockConfShWork()
        {
        }

    }
}
