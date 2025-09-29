using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SearchParaStockSlip
	/// <summary>
	///                      仕入伝票検索条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入伝票検索条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/14  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SearchParaStockSlip
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>仕入形式</summary>
		/// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒,99:全て</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>仕入伝票区分</summary>
		/// <remarks>10:仕入,20:返品</remarks>
		private Int32 _supplierSlipCd;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動),99:全て</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>買掛区分</summary>
		/// <remarks>0:買掛なし,1:買掛,99全て</remarks>
		private Int32 _accPayDivCd;

		/// <summary>仕入担当者コード</summary>
		/// <remarks>発注者をセット</remarks>
		private string _stockAgentCode = "";

		/// <summary>相手先伝票番号</summary>
		/// <remarks>仕入先伝票番号に使用する</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>相手先伝票番号検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _partySaleSlipNumSrchTyp;

		/// <summary>仕入拠点コード</summary>
		private string _stockSectionCd = "";

		/// <summary>支払先コード</summary>
		/// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
		private Int32 _payeeCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>入力日（開始）</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private Int32 _inputDaySt;

		/// <summary>入力日（終了）</summary>
		/// <remarks>YYYYMMDD　（更新年月日）</remarks>
		private Int32 _inputDayEd;

		/// <summary>入荷日（開始）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _arrivalGoodsDaySt;

		/// <summary>入荷日（終了）</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _arrivalGoodsDayEd;

		/// <summary>仕入日（開始）</summary>
		private Int32 _stockDateSt;

		/// <summary>仕入日（終了）</summary>
		private Int32 _stockDateEd;

		/// <summary>仕入計上日付（開始）</summary>
		private Int32 _stockAddUpADateSt;

		/// <summary>仕入計上日付（終了）</summary>
		/// <remarks>仕入計上日</remarks>
		private Int32 _stockAddUpADateEd;

		/// <summary>商品メーカーコード</summary>
		/// <remarks>仕入計上日</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>品番</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品名称曖昧検索フラグ</summary>
		/// <remarks>True:前方一致の曖昧検索　False:通常検索</remarks>
		private Boolean _goodsNmVagueSrch;

		/// <summary>仕入伝票番号(開始)</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
		private Int32 _supplierSlipNoSt;

		/// <summary>仕入伝票番号(終了)</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
		private Int32 _supplierSlipNoEd;

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _supplierFormal;}
			set{_supplierFormal = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒,99:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>仕入伝票区分プロパティ</summary>
		/// <value>10:仕入,20:返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>仕入商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動),99:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockGoodsCd
		{
			get{return _stockGoodsCd;}
			set{_stockGoodsCd = value;}
		}

		/// public propaty name  :  AccPayDivCd
		/// <summary>買掛区分プロパティ</summary>
		/// <value>0:買掛なし,1:買掛,99全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   買掛区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AccPayDivCd
		{
			get{return _accPayDivCd;}
			set{_accPayDivCd = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>仕入担当者コードプロパティ</summary>
		/// <value>発注者をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  PartySaleSlipNum
		/// <summary>相手先伝票番号プロパティ</summary>
		/// <value>仕入先伝票番号に使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySaleSlipNum
		{
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
		}

		/// public propaty name  :  PartySaleSlipNumSrchTyp
		/// <summary>相手先伝票番号検索タイププロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartySaleSlipNumSrchTyp
		{
			get{return _partySaleSlipNumSrchTyp;}
			set{_partySaleSlipNumSrchTyp = value;}
		}

		/// public propaty name  :  StockSectionCd
		/// <summary>仕入拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSectionCd
		{
			get{return _stockSectionCd;}
			set{_stockSectionCd = value;}
		}

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
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
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  InputDaySt
		/// <summary>入力日（開始）プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get{return _inputDaySt;}
			set{_inputDaySt = value;}
		}

		/// public propaty name  :  InputDayEd
		/// <summary>入力日（終了）プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get{return _inputDayEd;}
			set{_inputDayEd = value;}
		}

		/// public propaty name  :  ArrivalGoodsDaySt
		/// <summary>入荷日（開始）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDaySt
		{
			get{return _arrivalGoodsDaySt;}
			set{_arrivalGoodsDaySt = value;}
		}

		/// public propaty name  :  ArrivalGoodsDayEd
		/// <summary>入荷日（終了）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsDayEd
		{
			get{return _arrivalGoodsDayEd;}
			set{_arrivalGoodsDayEd = value;}
		}

		/// public propaty name  :  StockDateSt
		/// <summary>仕入日（開始）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateSt
		{
			get{return _stockDateSt;}
			set{_stockDateSt = value;}
		}

		/// public propaty name  :  StockDateEd
		/// <summary>仕入日（終了）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDateEd
		{
			get{return _stockDateEd;}
			set{_stockDateEd = value;}
		}

		/// public propaty name  :  StockAddUpADateSt
		/// <summary>仕入計上日付（開始）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockAddUpADateSt
		{
			get{return _stockAddUpADateSt;}
			set{_stockAddUpADateSt = value;}
		}

		/// public propaty name  :  StockAddUpADateEd
		/// <summary>仕入計上日付（終了）プロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入計上日付（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockAddUpADateEd
		{
			get{return _stockAddUpADateEd;}
			set{_stockAddUpADateEd = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>仕入計上日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>品番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  GoodsNmVagueSrch
		/// <summary>商品名称曖昧検索フラグプロパティ</summary>
		/// <value>True:前方一致の曖昧検索　False:通常検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称曖昧検索フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean GoodsNmVagueSrch
		{
			get{return _goodsNmVagueSrch;}
			set{_goodsNmVagueSrch = value;}
		}

		/// public propaty name  :  SupplierSlipNoSt
		/// <summary>仕入伝票番号(開始)プロパティ</summary>
		/// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNoSt
		{
			get{return _supplierSlipNoSt;}
			set{_supplierSlipNoSt = value;}
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
			get{return _supplierSlipNoEd;}
			set{_supplierSlipNoEd = value;}
		}

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

		/// <summary>
		/// 仕入伝票検索条件ワークコンストラクタ
		/// </summary>
		/// <returns>SearchParaStockSlipクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SearchParaStockSlipクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SearchParaStockSlip()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SearchParaStockSlipクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SearchParaStockSlipクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SearchParaStockSlip_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchParaStockSlipクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SearchParaStockSlip_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SearchParaStockSlip || graph is ArrayList || graph is SearchParaStockSlip[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SearchParaStockSlip).FullName));

            if (graph != null && graph is SearchParaStockSlip)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SearchParaStockSlip");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SearchParaStockSlip[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SearchParaStockSlip[])graph).Length;
            }
            else if (graph is SearchParaStockSlip)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //仕入伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //仕入商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //買掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //相手先伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //相手先伝票番号検索タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //PartySaleSlipNumSrchTyp
            //仕入拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //支払先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //入力日（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDaySt
            //入力日（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDayEd
            //入荷日（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDaySt
            //入荷日（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDayEd
            //仕入日（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateSt
            //仕入日（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateEd
            //仕入計上日付（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADateSt
            //仕入計上日付（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADateEd
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称曖昧検索フラグ
            serInfo.MemberInfo.Add(typeof(Boolean)); //GoodsNmVagueSrch
            //仕入伝票番号(開始)
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNoSt
            //仕入伝票番号(終了)
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNoEd
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode


            serInfo.Serialize(writer, serInfo);
            if (graph is SearchParaStockSlip)
            {
                SearchParaStockSlip temp = (SearchParaStockSlip)graph;

                SetSearchParaStockSlip(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SearchParaStockSlip[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SearchParaStockSlip[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SearchParaStockSlip temp in lst)
                {
                    SetSearchParaStockSlip(writer, temp);
                }

            }


        }


        /// <summary>
        /// SearchParaStockSlipメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  SearchParaStockSlipインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchParaStockSlipのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSearchParaStockSlip(System.IO.BinaryWriter writer, SearchParaStockSlip temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //仕入伝票区分
            writer.Write(temp.SupplierSlipCd);
            //仕入商品区分
            writer.Write(temp.StockGoodsCd);
            //買掛区分
            writer.Write(temp.AccPayDivCd);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //相手先伝票番号
            writer.Write(temp.PartySaleSlipNum);
            //相手先伝票番号検索タイプ
            writer.Write(temp.PartySaleSlipNumSrchTyp);
            //仕入拠点コード
            writer.Write(temp.StockSectionCd);
            //支払先コード
            writer.Write(temp.PayeeCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //入力日（開始）
            writer.Write(temp.InputDaySt);
            //入力日（終了）
            writer.Write(temp.InputDayEd);
            //入荷日（開始）
            writer.Write(temp.ArrivalGoodsDaySt);
            //入荷日（終了）
            writer.Write(temp.ArrivalGoodsDayEd);
            //仕入日（開始）
            writer.Write(temp.StockDateSt);
            //仕入日（終了）
            writer.Write(temp.StockDateEd);
            //仕入計上日付（開始）
            writer.Write(temp.StockAddUpADateSt);
            //仕入計上日付（終了）
            writer.Write(temp.StockAddUpADateEd);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //品番
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称曖昧検索フラグ
            writer.Write(temp.GoodsNmVagueSrch);
            //仕入伝票番号(開始)
            writer.Write(temp.SupplierSlipNoSt);
            //仕入伝票番号(終了)
            writer.Write(temp.SupplierSlipNoEd);
            //部門コード
            writer.Write(temp.SubSectionCode);

        }

        /// <summary>
        ///  SearchParaStockSlipインスタンス取得
        /// </summary>
        /// <returns>SearchParaStockSlipクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchParaStockSlipのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SearchParaStockSlip GetSearchParaStockSlip(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SearchParaStockSlip temp = new SearchParaStockSlip();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //仕入伝票区分
            temp.SupplierSlipCd = reader.ReadInt32();
            //仕入商品区分
            temp.StockGoodsCd = reader.ReadInt32();
            //買掛区分
            temp.AccPayDivCd = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //相手先伝票番号検索タイプ
            temp.PartySaleSlipNumSrchTyp = reader.ReadInt32();
            //仕入拠点コード
            temp.StockSectionCd = reader.ReadString();
            //支払先コード
            temp.PayeeCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //入力日（開始）
            temp.InputDaySt = reader.ReadInt32();
            //入力日（終了）
            temp.InputDayEd = reader.ReadInt32();
            //入荷日（開始）
            temp.ArrivalGoodsDaySt = reader.ReadInt32();
            //入荷日（終了）
            temp.ArrivalGoodsDayEd = reader.ReadInt32();
            //仕入日（開始）
            temp.StockDateSt = reader.ReadInt32();
            //仕入日（終了）
            temp.StockDateEd = reader.ReadInt32();
            //仕入計上日付（開始）
            temp.StockAddUpADateSt = reader.ReadInt32();
            //仕入計上日付（終了）
            temp.StockAddUpADateEd = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //品番
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称曖昧検索フラグ
            //仕入伝票番号(開始)
            temp.SupplierSlipNoSt = reader.ReadInt32();
            //仕入伝票番号(終了)
            temp.SupplierSlipNoEd = reader.ReadInt32();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();


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
        /// <returns>SearchParaStockSlipクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchParaStockSlipクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SearchParaStockSlip temp = GetSearchParaStockSlip(reader, serInfo);
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
                    retValue = (SearchParaStockSlip[])lst.ToArray(typeof(SearchParaStockSlip));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
