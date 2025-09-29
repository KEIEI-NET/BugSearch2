using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockTtlStWork
	/// <summary>
	///                      仕入在庫全体設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入在庫全体設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/17</br>
	/// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockTtlStWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		/// <remarks>オール０は全社</remarks>
		private string _sectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>仕入値引名称</summary>
		private string _stockDiscountName = "";

		/// <summary>返品伝票発行区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _rgdsSlipPrtDiv;

		/// <summary>返品時単価印刷区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _rgdsUnPrcPrtDiv;

		/// <summary>返品時ゼロ円印刷区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _rgdsZeroPrtDiv;

		/// <summary>定価入力区分</summary>
		/// <remarks>0:可能　1:不可  (仕入明細の定価入力）</remarks>
		private Int32 _listPriceInpDiv;

		/// <summary>単価入力区分</summary>
		/// <remarks>0:可能　1:不可  (仕入明細の仕入単価入力）</remarks>
		private Int32 _unitPriceInpDiv;

		/// <summary>明細備考表示区分</summary>
		/// <remarks>0:有り　1:無し　（無しの場合、画面項目を非表示) </remarks>
		private Int32 _dtlNoteDispDiv;

		/// <summary>自動支払金種コード</summary>
		/// <remarks>エントリでの自動支払の金種</remarks>
		private Int32 _autoPayMoneyKindCode;

		/// <summary>自動支払金種名称</summary>
		/// <remarks>エントリでの自動支払の金種</remarks>
		private string _autoPayMoneyKindName = "";

		/// <summary>自動支払金種区分</summary>
		/// <remarks>エントリでの自動支払の金種</remarks>
		private Int32 _autoPayMoneyKindDiv;

		/// <summary>自動支払区分</summary>
		/// <remarks>0:通常支払,1:自動支払（支払伝票入力から発生）</remarks>
		private Int32 _autoPayment;

		/// <summary>定価原価更新区分</summary>
		/// <remarks>0:非更新　1:無条件更新　2:確認更新</remarks>
		private Int32 _priceCostUpdtDiv;

		/// <summary>商品自動登録</summary>
		/// <remarks>0:なし　1:あり</remarks>
		private Int32 _autoEntryGoodsDivCd;

		/// <summary>定価チェック区分</summary>
		/// <remarks>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</remarks>
		private Int32 _priceCheckDivCd;

		/// <summary>仕入単価チェック区分</summary>
		/// <remarks>0:無視　1:再入力　2:警告MSG　（単価≠原価の場合）</remarks>
		private Int32 _stockUnitChgDivCd;

		/// <summary>拠点表示区分</summary>
		/// <remarks>0:標準　1:自社ﾏｽﾀ　2:表示無し</remarks>
		private Int32 _sectDspDivCd;

		/// <summary>伝票日付クリア区分</summary>
		/// <remarks>0:システム日付 1:入力日付</remarks>
		private Int32 _slipDateClrDivCd;

		/// <summary>支払伝票日付クリア区分</summary>
		/// <remarks>0:システム日付に戻す 1:入力日付のまま</remarks>
		private Int32 _paySlipDateClrDiv;

		/// <summary>支払伝票日付範囲区分</summary>
		/// <remarks>0:制限なし 1:システム日付以降入力不可</remarks>
		private Int32 _paySlipDateAmbit;

        /// <summary>在庫検索区分</summary>
        /// <remarks>0:優先倉庫,1:指定倉庫</remarks>
        private Int32 _stockSearchDiv;

        /// <summary>商品名再表示区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _goodsNmReDispDivCd;
        
        /// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>オール０は全社</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  StockDiscountName
		/// <summary>仕入値引名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入値引名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockDiscountName
		{
			get{return _stockDiscountName;}
			set{_stockDiscountName = value;}
		}

		/// public propaty name  :  RgdsSlipPrtDiv
		/// <summary>返品伝票発行区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RgdsSlipPrtDiv
		{
			get{return _rgdsSlipPrtDiv;}
			set{_rgdsSlipPrtDiv = value;}
		}

		/// public propaty name  :  RgdsUnPrcPrtDiv
		/// <summary>返品時単価印刷区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品時単価印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RgdsUnPrcPrtDiv
		{
			get{return _rgdsUnPrcPrtDiv;}
			set{_rgdsUnPrcPrtDiv = value;}
		}

		/// public propaty name  :  RgdsZeroPrtDiv
		/// <summary>返品時ゼロ円印刷区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品時ゼロ円印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RgdsZeroPrtDiv
		{
			get{return _rgdsZeroPrtDiv;}
			set{_rgdsZeroPrtDiv = value;}
		}

		/// public propaty name  :  ListPriceInpDiv
		/// <summary>定価入力区分プロパティ</summary>
		/// <value>0:可能　1:不可  (仕入明細の定価入力）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価入力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListPriceInpDiv
		{
			get{return _listPriceInpDiv;}
			set{_listPriceInpDiv = value;}
		}

		/// public propaty name  :  UnitPriceInpDiv
		/// <summary>単価入力区分プロパティ</summary>
		/// <value>0:可能　1:不可  (仕入明細の仕入単価入力）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価入力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnitPriceInpDiv
		{
			get{return _unitPriceInpDiv;}
			set{_unitPriceInpDiv = value;}
		}

		/// public propaty name  :  DtlNoteDispDiv
		/// <summary>明細備考表示区分プロパティ</summary>
		/// <value>0:有り　1:無し　（無しの場合、画面項目を非表示) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細備考表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DtlNoteDispDiv
		{
			get{return _dtlNoteDispDiv;}
			set{_dtlNoteDispDiv = value;}
		}

		/// public propaty name  :  AutoPayMoneyKindCode
		/// <summary>自動支払金種コードプロパティ</summary>
		/// <value>エントリでの自動支払の金種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動支払金種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoPayMoneyKindCode
		{
			get{return _autoPayMoneyKindCode;}
			set{_autoPayMoneyKindCode = value;}
		}

		/// public propaty name  :  AutoPayMoneyKindName
		/// <summary>自動支払金種名称プロパティ</summary>
		/// <value>エントリでの自動支払の金種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動支払金種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AutoPayMoneyKindName
		{
			get{return _autoPayMoneyKindName;}
			set{_autoPayMoneyKindName = value;}
		}

		/// public propaty name  :  AutoPayMoneyKindDiv
		/// <summary>自動支払金種区分プロパティ</summary>
		/// <value>エントリでの自動支払の金種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動支払金種区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoPayMoneyKindDiv
		{
			get{return _autoPayMoneyKindDiv;}
			set{_autoPayMoneyKindDiv = value;}
		}

		/// public propaty name  :  AutoPayment
		/// <summary>自動支払区分プロパティ</summary>
		/// <value>0:通常支払,1:自動支払（支払伝票入力から発生）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動支払区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoPayment
		{
			get{return _autoPayment;}
			set{_autoPayment = value;}
		}

		/// public propaty name  :  PriceCostUpdtDiv
		/// <summary>定価原価更新区分プロパティ</summary>
		/// <value>0:非更新　1:無条件更新　2:確認更新</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価原価更新区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCostUpdtDiv
		{
			get{return _priceCostUpdtDiv;}
			set{_priceCostUpdtDiv = value;}
		}

		/// public propaty name  :  AutoEntryGoodsDivCd
		/// <summary>商品自動登録プロパティ</summary>
		/// <value>0:なし　1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品自動登録プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoEntryGoodsDivCd
		{
			get{return _autoEntryGoodsDivCd;}
			set{_autoEntryGoodsDivCd = value;}
		}

		/// public propaty name  :  PriceCheckDivCd
		/// <summary>定価チェック区分プロパティ</summary>
		/// <value>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価チェック区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCheckDivCd
		{
			get{return _priceCheckDivCd;}
			set{_priceCheckDivCd = value;}
		}

		/// public propaty name  :  StockUnitChgDivCd
		/// <summary>仕入単価チェック区分プロパティ</summary>
		/// <value>0:無視　1:再入力　2:警告MSG　（単価≠原価の場合）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価チェック区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockUnitChgDivCd
		{
			get{return _stockUnitChgDivCd;}
			set{_stockUnitChgDivCd = value;}
		}

		/// public propaty name  :  SectDspDivCd
		/// <summary>拠点表示区分プロパティ</summary>
		/// <value>0:標準　1:自社ﾏｽﾀ　2:表示無し</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SectDspDivCd
		{
			get{return _sectDspDivCd;}
			set{_sectDspDivCd = value;}
		}

		/// public propaty name  :  SlipDateClrDivCd
		/// <summary>伝票日付クリア区分プロパティ</summary>
		/// <value>0:システム日付 1:入力日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票日付クリア区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipDateClrDivCd
		{
			get{return _slipDateClrDivCd;}
			set{_slipDateClrDivCd = value;}
		}

		/// public propaty name  :  PaySlipDateClrDiv
		/// <summary>支払伝票日付クリア区分プロパティ</summary>
		/// <value>0:システム日付に戻す 1:入力日付のまま</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払伝票日付クリア区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PaySlipDateClrDiv
		{
			get{return _paySlipDateClrDiv;}
			set{_paySlipDateClrDiv = value;}
		}

		/// public propaty name  :  PaySlipDateAmbit
		/// <summary>支払伝票日付範囲区分プロパティ</summary>
		/// <value>0:制限なし 1:システム日付以降入力不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払伝票日付範囲区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PaySlipDateAmbit
		{
			get{return _paySlipDateAmbit;}
			set{_paySlipDateAmbit = value;}
		}

        /// public propaty name  :  PaySlipDateAmbit
        /// <summary>在庫検索区分プロパティ</summary>
        /// <value>0:優先倉庫,1:指定倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockSearchDiv
        {
            get { return _stockSearchDiv; }
            set { _stockSearchDiv = value; }
        }

        /// public propaty name  :  GoodsNmReDispDivCd
        /// <summary>商品名再表示区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名再表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNmReDispDivCd
        {
            get { return _goodsNmReDispDivCd; }
            set { _goodsNmReDispDivCd = value; }
        }
        
        /// <summary>
		/// 仕入在庫全体設定ワークコンストラクタ
		/// </summary>
		/// <returns>StockTtlStWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockTtlStWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockTtlStWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockTtlStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockTtlStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockTtlStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockTtlStWork || graph is ArrayList || graph is StockTtlStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockTtlStWork).FullName));

            if (graph != null && graph is StockTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockTtlStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockTtlStWork[])graph).Length;
            }
            else if (graph is StockTtlStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //仕入値引名称
            serInfo.MemberInfo.Add(typeof(string)); //StockDiscountName
            //返品伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RgdsSlipPrtDiv
            //返品時単価印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RgdsUnPrcPrtDiv
            //返品時ゼロ円印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RgdsZeroPrtDiv
            //定価入力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceInpDiv
            //単価入力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UnitPriceInpDiv
            //明細備考表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlNoteDispDiv
            //自動支払金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayMoneyKindCode
            //自動支払金種名称
            serInfo.MemberInfo.Add(typeof(string)); //AutoPayMoneyKindName
            //自動支払金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayMoneyKindDiv
            //自動支払区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //定価原価更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCostUpdtDiv
            //商品自動登録
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoEntryGoodsDivCd
            //定価チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCheckDivCd
            //仕入単価チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChgDivCd
            //拠点表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SectDspDivCd
            //伝票日付クリア区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDateClrDivCd
            //支払伝票日付クリア区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PaySlipDateClrDiv
            //支払伝票日付範囲区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PaySlipDateAmbit
            //在庫検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSearchDiv
            //商品名再表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNmReDispDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is StockTtlStWork)
            {
                StockTtlStWork temp = (StockTtlStWork)graph;

                SetStockTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockTtlStWork temp in lst)
                {
                    SetStockTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockTtlStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 31;

        /// <summary>
        ///  StockTtlStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockTtlStWork(System.IO.BinaryWriter writer, StockTtlStWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //仕入値引名称
            writer.Write(temp.StockDiscountName);
            //返品伝票発行区分
            writer.Write(temp.RgdsSlipPrtDiv);
            //返品時単価印刷区分
            writer.Write(temp.RgdsUnPrcPrtDiv);
            //返品時ゼロ円印刷区分
            writer.Write(temp.RgdsZeroPrtDiv);
            //定価入力区分
            writer.Write(temp.ListPriceInpDiv);
            //単価入力区分
            writer.Write(temp.UnitPriceInpDiv);
            //明細備考表示区分
            writer.Write(temp.DtlNoteDispDiv);
            //自動支払金種コード
            writer.Write(temp.AutoPayMoneyKindCode);
            //自動支払金種名称
            writer.Write(temp.AutoPayMoneyKindName);
            //自動支払金種区分
            writer.Write(temp.AutoPayMoneyKindDiv);
            //自動支払区分
            writer.Write(temp.AutoPayment);
            //定価原価更新区分
            writer.Write(temp.PriceCostUpdtDiv);
            //商品自動登録
            writer.Write(temp.AutoEntryGoodsDivCd);
            //定価チェック区分
            writer.Write(temp.PriceCheckDivCd);
            //仕入単価チェック区分
            writer.Write(temp.StockUnitChgDivCd);
            //拠点表示区分
            writer.Write(temp.SectDspDivCd);
            //伝票日付クリア区分
            writer.Write(temp.SlipDateClrDivCd);
            //支払伝票日付クリア区分
            writer.Write(temp.PaySlipDateClrDiv);
            //支払伝票日付範囲区分
            writer.Write(temp.PaySlipDateAmbit);
            //在庫検索区分
            writer.Write(temp.StockSearchDiv);
            //商品名再表示区分
            writer.Write(temp.GoodsNmReDispDivCd);

        }

        /// <summary>
        ///  StockTtlStWorkインスタンス取得
        /// </summary>
        /// <returns>StockTtlStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockTtlStWork GetStockTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockTtlStWork temp = new StockTtlStWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //仕入値引名称
            temp.StockDiscountName = reader.ReadString();
            //返品伝票発行区分
            temp.RgdsSlipPrtDiv = reader.ReadInt32();
            //返品時単価印刷区分
            temp.RgdsUnPrcPrtDiv = reader.ReadInt32();
            //返品時ゼロ円印刷区分
            temp.RgdsZeroPrtDiv = reader.ReadInt32();
            //定価入力区分
            temp.ListPriceInpDiv = reader.ReadInt32();
            //単価入力区分
            temp.UnitPriceInpDiv = reader.ReadInt32();
            //明細備考表示区分
            temp.DtlNoteDispDiv = reader.ReadInt32();
            //自動支払金種コード
            temp.AutoPayMoneyKindCode = reader.ReadInt32();
            //自動支払金種名称
            temp.AutoPayMoneyKindName = reader.ReadString();
            //自動支払金種区分
            temp.AutoPayMoneyKindDiv = reader.ReadInt32();
            //自動支払区分
            temp.AutoPayment = reader.ReadInt32();
            //定価原価更新区分
            temp.PriceCostUpdtDiv = reader.ReadInt32();
            //商品自動登録
            temp.AutoEntryGoodsDivCd = reader.ReadInt32();
            //定価チェック区分
            temp.PriceCheckDivCd = reader.ReadInt32();
            //仕入単価チェック区分
            temp.StockUnitChgDivCd = reader.ReadInt32();
            //拠点表示区分
            temp.SectDspDivCd = reader.ReadInt32();
            //伝票日付クリア区分
            temp.SlipDateClrDivCd = reader.ReadInt32();
            //支払伝票日付クリア区分
            temp.PaySlipDateClrDiv = reader.ReadInt32();
            //支払伝票日付範囲区分
            temp.PaySlipDateAmbit = reader.ReadInt32();
            //在庫検索区分
            temp.StockSearchDiv = reader.ReadInt32();
            //商品名再表示区分
            temp.GoodsNmReDispDivCd = reader.ReadInt32();


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
        /// <returns>StockTtlStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockTtlStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockTtlStWork temp = GetStockTtlStWork(reader, serInfo);
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
                    retValue = (StockTtlStWork[])lst.ToArray(typeof(StockTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
