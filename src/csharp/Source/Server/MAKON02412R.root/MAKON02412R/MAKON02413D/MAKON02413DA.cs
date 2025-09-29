using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   LedgerPaymentSlpWork
    /// <summary>
    ///                      仕入先元帳（支払）抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先元帳（支払）抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/11/01 FSI斎藤 和宏</br>
    /// <br>                     支払データに値引額・手数料額が反映されていない問題対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class LedgerPaymentSlpWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>支払伝票番号</summary>
        private Int32 _paymentSlipNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        private string _supplierNm2 = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>支払先コード</summary>
        /// <remarks>支払先の親コード</remarks>
        private Int32 _payeeCode;

        /// <summary>支払先名称</summary>
        private string _payeeName = "";

        /// <summary>支払先名称2</summary>
        private string _payeeName2 = "";

        /// <summary>支払先略称</summary>
        private string _payeeSnm = "";

        /// <summary>支払入力拠点コード</summary>
        /// <remarks>文字型 支払入力した拠点コード</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>更新拠点コード</summary>
        /// <remarks>文字型 データの登録更新拠点</remarks>
        private string _updateSecCd = "";

        /// <summary>支払日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

        /// <summary>計上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>支払担当者コード</summary>
        private string _paymentAgentCode = "";

        /// <summary>支払担当者名称</summary>
        private string _paymentAgentName = "";

        /// <summary>支払入力者コード</summary>
        private string _paymentInputAgentCd = "";

        /// <summary>支払入力者名称</summary>
        private string _paymentInputAgentNm = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
        private string _outline = "";

        /// <summary>支払行番号</summary>
        private Int32 _paymentRowNo;

        /// <summary>金種コード</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _moneyKindCode;

        /// <summary>金種名称</summary>
        private string _moneyKindName = "";

        /// <summary>金種区分</summary>
        private Int32 _moneyKindDiv;

        /// <summary>支払金額</summary>
        private Int64 _payment;

        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary>手数料支払額</summary>
        private Int64 _feePayment;

        /// <summary>値引支払額</summary>
        private Int64 _discountPayment;
        // --- ADD 2012/11/01 ----------<<<<<

        /// <summary>有効期限</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm;
        
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
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

        /// public propaty name  :  PaymentSlipNo
        /// <summary>支払伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
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

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>仕入先名2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>支払先コードプロパティ</summary>
        /// <value>支払先の親コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>支払先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>支払先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>支払先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>支払入力拠点コードプロパティ</summary>
        /// <value>文字型 支払入力した拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>更新拠点コードプロパティ</summary>
        /// <value>文字型 データの登録更新拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  PaymentDate
        /// <summary>支払日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>支払担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>支払担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>支払入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>支払入力者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>車販の場合、摘要+注文書№+管理番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  PaymentRowNo
        /// <summary>支払行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PaymentRowNo
        {
            get { return _paymentRowNo; }
            set { _paymentRowNo = value; }
        }

        /// public propaty name  :  MoneyKindCode
        /// <summary>金種コードプロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }

        /// public propaty name  :  MoneyKindName
        /// <summary>金種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }

        /// public propaty name  :  MoneyKindDiv
        /// <summary>金種区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金種区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>支払金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        // --- ADD 2012/11/01 ---------->>>>>
        /// public propaty name  :  FeePayment
        /// <summary>手数料支払額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>値引支払額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引支払額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }
        // --- ADD 2012/11/01 ----------<<<<<

        /// public propaty name  :  ValidityTerm
        /// <summary>有効期限プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }


        /// <summary>
        /// 仕入先元帳（支払）抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>LedgerPaymentSlpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerPaymentSlpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public LedgerPaymentSlpWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>LedgerPaymentSlpWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   LedgerPaymentSlpWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class LedgerPaymentSlpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerPaymentSlpWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  LedgerPaymentSlpWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is LedgerPaymentSlpWork || graph is ArrayList || graph is LedgerPaymentSlpWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(LedgerPaymentSlpWork).FullName));

            if (graph != null && graph is LedgerPaymentSlpWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.LedgerPaymentSlpWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is LedgerPaymentSlpWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((LedgerPaymentSlpWork[])graph).Length;
            }
            else if (graph is LedgerPaymentSlpWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //支払伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先名1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //仕入先名2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //支払先名称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //支払先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //支払先略称
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //支払入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //更新拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //支払日付
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //支払担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //支払担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //支払入力者コード
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //支払入力者名称
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //支払行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo
            //金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode
            //金種名称
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName
            //金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv
            //支払金額
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment

            // --- ADD 2012/11/01 ---------->>>>>
            // 手数料支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //値引支払額
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            // --- ADD 2012/11/01 ----------<<<<<

            //有効期限
            serInfo.MemberInfo.Add(typeof(Int32)); //ValidityTerm


            serInfo.Serialize(writer, serInfo);
            if (graph is LedgerPaymentSlpWork)
            {
                LedgerPaymentSlpWork temp = (LedgerPaymentSlpWork)graph;

                SetLedgerPaymentSlpWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is LedgerPaymentSlpWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((LedgerPaymentSlpWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (LedgerPaymentSlpWork temp in lst)
                {
                    SetLedgerPaymentSlpWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// LedgerPaymentSlpWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- ADD 2012/11/01 ---------->>>>>
        // private const int currentMemberCount = 29;
         private const int currentMemberCount = 31;
        // --- ADD 2012/11/01 ----------<<<<<
        
        /// <summary>
        ///  LedgerPaymentSlpWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerPaymentSlpWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetLedgerPaymentSlpWork(System.IO.BinaryWriter writer, LedgerPaymentSlpWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //支払伝票番号
            writer.Write(temp.PaymentSlipNo);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先名1
            writer.Write(temp.SupplierNm1);
            //仕入先名2
            writer.Write(temp.SupplierNm2);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //支払先名称
            writer.Write(temp.PayeeName);
            //支払先名称2
            writer.Write(temp.PayeeName2);
            //支払先略称
            writer.Write(temp.PayeeSnm);
            //支払入力拠点コード
            writer.Write(temp.PaymentInpSectionCd);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //更新拠点コード
            writer.Write(temp.UpdateSecCd);
            //支払日付
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //計上日付
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //支払担当者コード
            writer.Write(temp.PaymentAgentCode);
            //支払担当者名称
            writer.Write(temp.PaymentAgentName);
            //支払入力者コード
            writer.Write(temp.PaymentInputAgentCd);
            //支払入力者名称
            writer.Write(temp.PaymentInputAgentNm);
            //伝票摘要
            writer.Write(temp.Outline);
            //支払行番号
            writer.Write(temp.PaymentRowNo);
            //金種コード
            writer.Write(temp.MoneyKindCode);
            //金種名称
            writer.Write(temp.MoneyKindName);
            //金種区分
            writer.Write(temp.MoneyKindDiv);
            //支払金額
            writer.Write(temp.Payment);
            // --- ADD 2012/11/01 ---------->>>>>
            //手数料支払額
            writer.Write(temp.FeePayment);
            //値引支払額
            writer.Write(temp.DiscountPayment);
            // --- ADD 2012/11/01 ----------<<<<<
            //有効期限
            writer.Write((Int64)temp.ValidityTerm.Ticks);

        }

        /// <summary>
        ///  LedgerPaymentSlpWorkインスタンス取得
        /// </summary>
        /// <returns>LedgerPaymentSlpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerPaymentSlpWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private LedgerPaymentSlpWork GetLedgerPaymentSlpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            LedgerPaymentSlpWork temp = new LedgerPaymentSlpWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //支払伝票番号
            temp.PaymentSlipNo = reader.ReadInt32();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先名1
            temp.SupplierNm1 = reader.ReadString();
            //仕入先名2
            temp.SupplierNm2 = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //支払先名称
            temp.PayeeName = reader.ReadString();
            //支払先名称2
            temp.PayeeName2 = reader.ReadString();
            //支払先略称
            temp.PayeeSnm = reader.ReadString();
            //支払入力拠点コード
            temp.PaymentInpSectionCd = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //更新拠点コード
            temp.UpdateSecCd = reader.ReadString();
            //支払日付
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //計上日付
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //支払担当者コード
            temp.PaymentAgentCode = reader.ReadString();
            //支払担当者名称
            temp.PaymentAgentName = reader.ReadString();
            //支払入力者コード
            temp.PaymentInputAgentCd = reader.ReadString();
            //支払入力者名称
            temp.PaymentInputAgentNm = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //支払行番号
            temp.PaymentRowNo = reader.ReadInt32();
            //金種コード
            temp.MoneyKindCode = reader.ReadInt32();
            //金種名称
            temp.MoneyKindName = reader.ReadString();
            //金種区分
            temp.MoneyKindDiv = reader.ReadInt32();
            //支払金額
            temp.Payment = reader.ReadInt64();
            // --- ADD 2012/11/01 ---------->>>>>
            //手数料支払額
            temp.FeePayment = reader.ReadInt64();
            //値引支払額
            temp.DiscountPayment = reader.ReadInt64();
            // --- ADD 2012/11/01 ----------<<<<<

            //有効期限
            temp.ValidityTerm = new DateTime(reader.ReadInt64());


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>LedgerPaymentSlpWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   LedgerPaymentSlpWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                LedgerPaymentSlpWork temp = GetLedgerPaymentSlpWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (LedgerPaymentSlpWork[])lst.ToArray(typeof(LedgerPaymentSlpWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
