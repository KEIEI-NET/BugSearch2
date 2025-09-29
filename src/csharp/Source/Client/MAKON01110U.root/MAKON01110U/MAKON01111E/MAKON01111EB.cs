using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    #region 仕入明細データクラス
    /// public class name:   StockDetail
	/// <summary>
	///                      仕入明細データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入明細データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockDetail
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

		/// <summary>受注番号</summary>
		private Int32 _acceptAnOrderNo;

		/// <summary>仕入形式</summary>
		/// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		/// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</remarks>
		private Int32 _supplierSlipNo;

		/// <summary>仕入行番号</summary>
		private Int32 _stockRowNo;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

		/// <summary>共通通番</summary>
		private Int64 _commonSeqNo;

		/// <summary>仕入明細通番</summary>
		private Int64 _stockSlipDtlNum;

		/// <summary>仕入形式（元）</summary>
		/// <remarks>0:仕入,1:入荷,2:発注</remarks>
		private Int32 _supplierFormalSrc;

		/// <summary>仕入明細通番（元）</summary>
		/// <remarks>計上時の元データ明細通番をセット</remarks>
		private Int64 _stockSlipDtlNumSrc;

		/// <summary>受注ステータス（同時）</summary>
		/// <remarks>30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatusSync;

		/// <summary>売上明細通番（同時）</summary>
		/// <remarks>同時計上時の仕入明細通番をセット</remarks>
		private Int64 _salesSlipDtlNumSync;

		/// <summary>仕入伝票区分（明細）</summary>
		/// <remarks>0:仕入,1:返品,2:値引</remarks>
		private Int32 _stockSlipCdDtl;

		/// <summary>仕入入力者コード</summary>
		private string _stockInputCode = "";

		/// <summary>仕入入力者名称</summary>
		private string _stockInputName = "";

		/// <summary>仕入担当者コード</summary>
		private string _stockAgentCode = "";

		/// <summary>仕入担当者名称</summary>
		private string _stockAgentName = "";

		/// <summary>商品属性</summary>
		private Int32 _goodsKindCode;

		/// <summary>商品メーカーコード</summary>
		/// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>メーカーカナ名称</summary>
		private string _makerKanaName = "";

		/// <summary>メーカーカナ名称（一式）</summary>
		private string _cmpltMakerKanaName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品名称カナ</summary>
		private string _goodsNameKana = "";

		/// <summary>商品大分類コード</summary>
		/// <remarks>旧大分類（ユーザーガイド）</remarks>
		private Int32 _goodsLGroup;

		/// <summary>商品大分類名称</summary>
		private string _goodsLGroupName = "";

		/// <summary>商品中分類コード</summary>
		/// <remarks>旧中分類コード</remarks>
		private Int32 _goodsMGroup;

		/// <summary>商品中分類名称</summary>
		private string _goodsMGroupName = "";

		/// <summary>BLグループコード</summary>
		/// <remarks>旧グループコード</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BLグループコード名称</summary>
		private string _bLGroupName = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>自社分類コード</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>自社分類名称</summary>
		private string _enterpriseGanreName = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

		/// <summary>仕入在庫取寄せ区分</summary>
		/// <remarks>0:取寄せ,1:在庫</remarks>
		private Int32 _stockOrderDivCd;

		/// <summary>オープン価格区分</summary>
		/// <remarks>0:通常／1:オープン価格</remarks>
		private Int32 _openPriceDiv;

		/// <summary>商品掛率ランク</summary>
		/// <remarks>商品の掛率用ランク</remarks>
		private string _goodsRateRank = "";

		/// <summary>得意先掛率グループコード</summary>
		private Int32 _custRateGrpCode;

		/// <summary>仕入先掛率グループコード</summary>
		private Int32 _suppRateGrpCode;

		/// <summary>定価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>定価（税込，浮動）</summary>
		/// <remarks>税込み</remarks>
		private Double _listPriceTaxIncFl;

		/// <summary>仕入率</summary>
		private Double _stockRate;

		/// <summary>掛率設定拠点（仕入単価）</summary>
		/// <remarks>0:全社設定, その他:拠点コード</remarks>
		private string _rateSectStckUnPrc = "";

		/// <summary>掛率設定区分（仕入単価）</summary>
		/// <remarks>A7,A8,…</remarks>
		private string _rateDivStckUnPrc = "";

		/// <summary>単価算出区分（仕入単価）</summary>
		/// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
		private Int32 _unPrcCalcCdStckUnPrc;

		/// <summary>価格区分（仕入単価）</summary>
		/// <remarks>0:定価,1:登録販売店価格,…</remarks>
		private Int32 _priceCdStckUnPrc;

		/// <summary>基準単価（仕入単価）</summary>
		private Double _stdUnPrcStckUnPrc;

		/// <summary>端数処理単位（仕入単価）</summary>
		private Double _fracProcUnitStcUnPrc;

		/// <summary>端数処理（仕入単価）</summary>
		/// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
		private Int32 _fracProcStckUnPrc;

		/// <summary>仕入単価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>仕入単価（税込，浮動）</summary>
		/// <remarks>税込み</remarks>
		private Double _stockUnitTaxPriceFl;

		/// <summary>仕入単価変更区分</summary>
		/// <remarks>0:変更なし,1:変更あり　（仕入単価手入力）</remarks>
		private Int32 _stockUnitChngDiv;

		/// <summary>変更前仕入単価（浮動）</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfStockUnitPriceFl;

		/// <summary>変更前定価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfListPrice;

		/// <summary>BL商品コード（掛率）</summary>
		/// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
		private Int32 _rateBLGoodsCode;

		/// <summary>BL商品コード名称（掛率）</summary>
		/// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
		private string _rateBLGoodsName = "";

		/// <summary>商品掛率グループコード（掛率）</summary>
		/// <remarks>掛率算出時に使用した商品掛率コード（商品検索結果）</remarks>
		private Int32 _rateGoodsRateGrpCd;

		/// <summary>商品掛率グループ名称（掛率）</summary>
		/// <remarks>掛率算出時に使用した商品掛率名称（商品検索結果）</remarks>
		private string _rateGoodsRateGrpNm = "";

		/// <summary>BLグループコード（掛率）</summary>
		/// <remarks>掛率算出時に使用したBLグループコード（商品検索結果）</remarks>
		private Int32 _rateBLGroupCode;

		/// <summary>BLグループ名称（掛率）</summary>
		/// <remarks>掛率算出時に使用したBLグループ名称（商品検索結果）</remarks>
		private string _rateBLGroupName = "";

		/// <summary>仕入数</summary>
		private Double _stockCount;

		/// <summary>発注数量</summary>
		/// <remarks>発注,入荷で使用</remarks>
		private Double _orderCnt;

		/// <summary>発注調整数</summary>
		/// <remarks>現在の発注数は「発注数量＋発注調整数」で算出</remarks>
		private Double _orderAdjustCnt;

		/// <summary>発注残数</summary>
		/// <remarks>発注数量＋発注調整数－仕入数</remarks>
		private Double _orderRemainCnt;

		/// <summary>残数更新日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _remainCntUpdDate;

		/// <summary>仕入金額（税抜き）</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>仕入金額（税込み）</summary>
		private Int64 _stockPriceTaxInc;

		/// <summary>仕入商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動)</remarks>
		private Int32 _stockGoodsCd;

		/// <summary>仕入金額消費税額</summary>
		/// <remarks>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</remarks>
		private Int64 _stockPriceConsTax;

		/// <summary>課税区分</summary>
		/// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
		private Int32 _taxationCode;

		/// <summary>仕入伝票明細備考1</summary>
		private string _stockDtiSlipNote1 = "";

		/// <summary>販売先コード</summary>
		private Int32 _salesCustomerCode;

		/// <summary>販売先略称</summary>
		private string _salesCustomerSnm = "";

		/// <summary>伝票メモ１</summary>
		private string _slipMemo1 = "";

		/// <summary>伝票メモ２</summary>
		private string _slipMemo2 = "";

		/// <summary>伝票メモ３</summary>
		private string _slipMemo3 = "";

		/// <summary>社内メモ１</summary>
		private string _insideMemo1 = "";

		/// <summary>社内メモ２</summary>
		private string _insideMemo2 = "";

		/// <summary>社内メモ３</summary>
		private string _insideMemo3 = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>発注用</remarks>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		/// <remarks>発注用</remarks>
		private string _supplierSnm = "";

		/// <summary>納品先コード</summary>
		/// <remarks>発注用</remarks>
		private Int32 _addresseeCode;

		/// <summary>納品先名称</summary>
		/// <remarks>発注用</remarks>
		private string _addresseeName = "";

		/// <summary>直送区分</summary>
		/// <remarks>0:直送なし,1:直送あり　（発注書の直送先印字制御）</remarks>
		private Int32 _directSendingCd;

		/// <summary>発注番号</summary>
		/// <remarks>発注用</remarks>
		private string _orderNumber = "";

		/// <summary>注文方法</summary>
		/// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
		private Int32 _wayToOrder;

		/// <summary>納品完了予定日</summary>
		/// <remarks>発注用　（発注回答納期）</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>希望納期</summary>
		/// <remarks>発注用</remarks>
		private DateTime _expectDeliveryDate;

		/// <summary>発注データ作成区分</summary>
		/// <remarks>1:受発注売上入力,2:発注入力,3:在庫補充発注,4:発注点割れ　（発生元）</remarks>
		private Int32 _orderDataCreateDiv;

		/// <summary>発注データ作成日</summary>
		/// <remarks>発注用</remarks>
		private DateTime _orderDataCreateDate;

		/// <summary>発注書発行済区分</summary>
		/// <remarks>0:未発行,1:発行済</remarks>
		private Int32 _orderFormIssuedDiv;

		/// <summary>明細関連付けGUID</summary>
		private Guid _dtlRelationGuid;

		/// <summary>商品提供日付</summary>
		/// <remarks>YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型</remarks>
		private DateTime _goodsOfferDate;

		/// <summary>価格開始日付</summary>
		/// <remarks>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</remarks>
		private DateTime _priceStartDate;

		/// <summary>価格提供日付</summary>
		/// <remarks>YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型</remarks>
		private DateTime _priceOfferDate;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";


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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>受注番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcceptAnOrderNo
		{
			get{return _acceptAnOrderNo;}
			set{_acceptAnOrderNo = value;}
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

		/// public propaty name  :  SupplierSlipNo
		/// <summary>仕入伝票番号プロパティ</summary>
		/// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get{return _supplierSlipNo;}
			set{_supplierSlipNo = value;}
		}

		/// public propaty name  :  StockRowNo
		/// <summary>仕入行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockRowNo
		{
			get{return _stockRowNo;}
			set{_stockRowNo = value;}
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
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _subSectionCode;}
			set{_subSectionCode = value;}
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
			get{return _commonSeqNo;}
			set{_commonSeqNo = value;}
		}

		/// public propaty name  :  StockSlipDtlNum
		/// <summary>仕入明細通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSlipDtlNum
		{
			get{return _stockSlipDtlNum;}
			set{_stockSlipDtlNum = value;}
		}

		/// public propaty name  :  SupplierFormalSrc
		/// <summary>仕入形式（元）プロパティ</summary>
		/// <value>0:仕入,1:入荷,2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入形式（元）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierFormalSrc
		{
			get{return _supplierFormalSrc;}
			set{_supplierFormalSrc = value;}
		}

		/// public propaty name  :  StockSlipDtlNumSrc
		/// <summary>仕入明細通番（元）プロパティ</summary>
		/// <value>計上時の元データ明細通番をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細通番（元）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSlipDtlNumSrc
		{
			get{return _stockSlipDtlNumSrc;}
			set{_stockSlipDtlNumSrc = value;}
		}

		/// public propaty name  :  AcptAnOdrStatusSync
		/// <summary>受注ステータス（同時）プロパティ</summary>
		/// <value>30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータス（同時）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatusSync
		{
			get{return _acptAnOdrStatusSync;}
			set{_acptAnOdrStatusSync = value;}
		}

		/// public propaty name  :  SalesSlipDtlNumSync
		/// <summary>売上明細通番（同時）プロパティ</summary>
		/// <value>同時計上時の仕入明細通番をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上明細通番（同時）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesSlipDtlNumSync
		{
			get{return _salesSlipDtlNumSync;}
			set{_salesSlipDtlNumSync = value;}
		}

		/// public propaty name  :  StockSlipCdDtl
		/// <summary>仕入伝票区分（明細）プロパティ</summary>
		/// <value>0:仕入,1:返品,2:値引</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票区分（明細）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockSlipCdDtl
		{
			get{return _stockSlipCdDtl;}
			set{_stockSlipCdDtl = value;}
		}

		/// public propaty name  :  StockInputCode
		/// <summary>仕入入力者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  StockInputName
		/// <summary>仕入入力者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputName
		{
			get{return _stockInputName;}
			set{_stockInputName = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>仕入担当者コードプロパティ</summary>
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

		/// public propaty name  :  StockAgentName
		/// <summary>仕入担当者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>商品属性プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品属性プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>メーカーカナ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーカナ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerKanaName
		{
			get{return _makerKanaName;}
			set{_makerKanaName = value;}
		}

		/// public propaty name  :  CmpltMakerKanaName
		/// <summary>メーカーカナ名称（一式）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーカナ名称（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmpltMakerKanaName
		{
			get{return _cmpltMakerKanaName;}
			set{_cmpltMakerKanaName = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
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

		/// public propaty name  :  GoodsNameKana
		/// <summary>商品名称カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  GoodsLGroup
		/// <summary>商品大分類コードプロパティ</summary>
		/// <value>旧大分類（ユーザーガイド）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsLGroup
		{
			get{return _goodsLGroup;}
			set{_goodsLGroup = value;}
		}

		/// public propaty name  :  GoodsLGroupName
		/// <summary>商品大分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品大分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsLGroupName
		{
			get{return _goodsLGroupName;}
			set{_goodsLGroupName = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>商品中分類コードプロパティ</summary>
		/// <value>旧中分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>商品中分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

		/// public propaty name  :  BLGroupCode
		/// <summary>BLグループコードプロパティ</summary>
		/// <value>旧グループコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCode
		{
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
		}

		/// public propaty name  :  BLGroupName
		/// <summary>BLグループコード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループコード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGroupName
		{
			get{return _bLGroupName;}
			set{_bLGroupName = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL商品コード名称（全角）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（全角）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreName
		/// <summary>自社分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseGanreName
		{
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  StockOrderDivCd
		/// <summary>仕入在庫取寄せ区分プロパティ</summary>
		/// <value>0:取寄せ,1:在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockOrderDivCd
		{
			get{return _stockOrderDivCd;}
			set{_stockOrderDivCd = value;}
		}

		/// public propaty name  :  OpenPriceDiv
		/// <summary>オープン価格区分プロパティ</summary>
		/// <value>0:通常／1:オープン価格</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv
		{
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  GoodsRateRank
		/// <summary>商品掛率ランクプロパティ</summary>
		/// <value>商品の掛率用ランク</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率ランクプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsRateRank
		{
			get{return _goodsRateRank;}
			set{_goodsRateRank = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>得意先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
		}

		/// public propaty name  :  SuppRateGrpCode
		/// <summary>仕入先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppRateGrpCode
		{
			get{return _suppRateGrpCode;}
			set{_suppRateGrpCode = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>定価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  ListPriceTaxIncFl
		/// <summary>定価（税込，浮動）プロパティ</summary>
		/// <value>税込み</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxIncFl
		{
			get{return _listPriceTaxIncFl;}
			set{_listPriceTaxIncFl = value;}
		}

		/// public propaty name  :  StockRate
		/// <summary>仕入率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockRate
		{
			get{return _stockRate;}
			set{_stockRate = value;}
		}

		/// public propaty name  :  RateSectStckUnPrc
		/// <summary>掛率設定拠点（仕入単価）プロパティ</summary>
		/// <value>0:全社設定, その他:拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定拠点（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSectStckUnPrc
		{
			get{return _rateSectStckUnPrc;}
			set{_rateSectStckUnPrc = value;}
		}

		/// public propaty name  :  RateDivStckUnPrc
		/// <summary>掛率設定区分（仕入単価）プロパティ</summary>
		/// <value>A7,A8,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateDivStckUnPrc
		{
			get{return _rateDivStckUnPrc;}
			set{_rateDivStckUnPrc = value;}
		}

		/// public propaty name  :  UnPrcCalcCdStckUnPrc
		/// <summary>単価算出区分（仕入単価）プロパティ</summary>
		/// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価算出区分（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcCalcCdStckUnPrc
		{
			get{return _unPrcCalcCdStckUnPrc;}
			set{_unPrcCalcCdStckUnPrc = value;}
		}

		/// public propaty name  :  PriceCdStckUnPrc
		/// <summary>価格区分（仕入単価）プロパティ</summary>
		/// <value>0:定価,1:登録販売店価格,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格区分（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCdStckUnPrc
		{
			get{return _priceCdStckUnPrc;}
			set{_priceCdStckUnPrc = value;}
		}

		/// public propaty name  :  StdUnPrcStckUnPrc
		/// <summary>基準単価（仕入単価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   基準単価（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StdUnPrcStckUnPrc
		{
			get{return _stdUnPrcStckUnPrc;}
			set{_stdUnPrcStckUnPrc = value;}
		}

		/// public propaty name  :  FracProcUnitStcUnPrc
		/// <summary>端数処理単位（仕入単価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double FracProcUnitStcUnPrc
		{
			get{return _fracProcUnitStcUnPrc;}
			set{_fracProcUnitStcUnPrc = value;}
		}

		/// public propaty name  :  FracProcStckUnPrc
		/// <summary>端数処理（仕入単価）プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理（仕入単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FracProcStckUnPrc
		{
			get{return _fracProcStckUnPrc;}
			set{_fracProcStckUnPrc = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>仕入単価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  StockUnitTaxPriceFl
		/// <summary>仕入単価（税込，浮動）プロパティ</summary>
		/// <value>税込み</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitTaxPriceFl
		{
			get{return _stockUnitTaxPriceFl;}
			set{_stockUnitTaxPriceFl = value;}
		}

		/// public propaty name  :  StockUnitChngDiv
		/// <summary>仕入単価変更区分プロパティ</summary>
		/// <value>0:変更なし,1:変更あり　（仕入単価手入力）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価変更区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockUnitChngDiv
		{
			get{return _stockUnitChngDiv;}
			set{_stockUnitChngDiv = value;}
		}

		/// public propaty name  :  BfStockUnitPriceFl
		/// <summary>変更前仕入単価（浮動）プロパティ</summary>
		/// <value>税抜き、掛率算出結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfStockUnitPriceFl
		{
			get{return _bfStockUnitPriceFl;}
			set{_bfStockUnitPriceFl = value;}
		}

		/// public propaty name  :  BfListPrice
		/// <summary>変更前定価プロパティ</summary>
		/// <value>税抜き、掛率算出結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfListPrice
		{
			get{return _bfListPrice;}
			set{_bfListPrice = value;}
		}

		/// public propaty name  :  RateBLGoodsCode
		/// <summary>BL商品コード（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RateBLGoodsCode
		{
			get{return _rateBLGoodsCode;}
			set{_rateBLGoodsCode = value;}
		}

		/// public propaty name  :  RateBLGoodsName
		/// <summary>BL商品コード名称（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateBLGoodsName
		{
			get{return _rateBLGoodsName;}
			set{_rateBLGoodsName = value;}
		}

		/// public propaty name  :  RateGoodsRateGrpCd
		/// <summary>商品掛率グループコード（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用した商品掛率コード（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率グループコード（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RateGoodsRateGrpCd
		{
			get{return _rateGoodsRateGrpCd;}
			set{_rateGoodsRateGrpCd = value;}
		}

		/// public propaty name  :  RateGoodsRateGrpNm
		/// <summary>商品掛率グループ名称（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用した商品掛率名称（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率グループ名称（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateGoodsRateGrpNm
		{
			get{return _rateGoodsRateGrpNm;}
			set{_rateGoodsRateGrpNm = value;}
		}

		/// public propaty name  :  RateBLGroupCode
		/// <summary>BLグループコード（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用したBLグループコード（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループコード（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RateBLGroupCode
		{
			get{return _rateBLGroupCode;}
			set{_rateBLGroupCode = value;}
		}

		/// public propaty name  :  RateBLGroupName
		/// <summary>BLグループ名称（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用したBLグループ名称（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループ名称（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateBLGroupName
		{
			get{return _rateBLGroupName;}
			set{_rateBLGroupName = value;}
		}

		/// public propaty name  :  StockCount
		/// <summary>仕入数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockCount
		{
			get{return _stockCount;}
			set{_stockCount = value;}
		}

		/// public propaty name  :  OrderCnt
		/// <summary>発注数量プロパティ</summary>
		/// <value>発注,入荷で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double OrderCnt
		{
			get{return _orderCnt;}
			set{_orderCnt = value;}
		}

		/// public propaty name  :  OrderAdjustCnt
		/// <summary>発注調整数プロパティ</summary>
		/// <value>現在の発注数は「発注数量＋発注調整数」で算出</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注調整数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double OrderAdjustCnt
		{
			get{return _orderAdjustCnt;}
			set{_orderAdjustCnt = value;}
		}

		/// public propaty name  :  OrderRemainCnt
		/// <summary>発注残数プロパティ</summary>
		/// <value>発注数量＋発注調整数－仕入数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注残数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double OrderRemainCnt
		{
			get{return _orderRemainCnt;}
			set{_orderRemainCnt = value;}
		}

		/// public propaty name  :  RemainCntUpdDate
		/// <summary>残数更新日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数更新日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime RemainCntUpdDate
		{
			get{return _remainCntUpdDate;}
			set{_remainCntUpdDate = value;}
		}

		/// public propaty name  :  RemainCntUpdDateJpFormal
		/// <summary>残数更新日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数更新日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RemainCntUpdDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  RemainCntUpdDateJpInFormal
		/// <summary>残数更新日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数更新日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RemainCntUpdDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  RemainCntUpdDateAdFormal
		/// <summary>残数更新日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数更新日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RemainCntUpdDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  RemainCntUpdDateAdInFormal
		/// <summary>残数更新日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数更新日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RemainCntUpdDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _remainCntUpdDate);}
			set{}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>仕入金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
		}

		/// public propaty name  :  StockPriceTaxInc
		/// <summary>仕入金額（税込み）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxInc
		{
			get{return _stockPriceTaxInc;}
			set{_stockPriceTaxInc = value;}
		}

		/// public propaty name  :  StockGoodsCd
		/// <summary>仕入商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動)</value>
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

		/// public propaty name  :  StockPriceConsTax
		/// <summary>仕入金額消費税額プロパティ</summary>
		/// <value>仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceConsTax
		{
			get{return _stockPriceConsTax;}
			set{_stockPriceConsTax = value;}
		}

		/// public propaty name  :  TaxationCode
		/// <summary>課税区分プロパティ</summary>
		/// <value>0:課税,1:非課税,2:課税（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxationCode
		{
			get{return _taxationCode;}
			set{_taxationCode = value;}
		}

		/// public propaty name  :  StockDtiSlipNote1
		/// <summary>仕入伝票明細備考1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票明細備考1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockDtiSlipNote1
		{
			get{return _stockDtiSlipNote1;}
			set{_stockDtiSlipNote1 = value;}
		}

		/// public propaty name  :  SalesCustomerCode
		/// <summary>販売先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCustomerCode
		{
			get{return _salesCustomerCode;}
			set{_salesCustomerCode = value;}
		}

		/// public propaty name  :  SalesCustomerSnm
		/// <summary>販売先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesCustomerSnm
		{
			get{return _salesCustomerSnm;}
			set{_salesCustomerSnm = value;}
		}

		/// public propaty name  :  SlipMemo1
		/// <summary>伝票メモ１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo1
		{
			get{return _slipMemo1;}
			set{_slipMemo1 = value;}
		}

		/// public propaty name  :  SlipMemo2
		/// <summary>伝票メモ２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo2
		{
			get{return _slipMemo2;}
			set{_slipMemo2 = value;}
		}

		/// public propaty name  :  SlipMemo3
		/// <summary>伝票メモ３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo3
		{
			get{return _slipMemo3;}
			set{_slipMemo3 = value;}
		}

		/// public propaty name  :  InsideMemo1
		/// <summary>社内メモ１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo1
		{
			get{return _insideMemo1;}
			set{_insideMemo1 = value;}
		}

		/// public propaty name  :  InsideMemo2
		/// <summary>社内メモ２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo2
		{
			get{return _insideMemo2;}
			set{_insideMemo2 = value;}
		}

		/// public propaty name  :  InsideMemo3
		/// <summary>社内メモ３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo3
		{
			get{return _insideMemo3;}
			set{_insideMemo3 = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>発注用</value>
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

		/// public propaty name  :  SupplierSnm
		/// <summary>仕入先略称プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  AddresseeCode
		/// <summary>納品先コードプロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddresseeCode
		{
			get{return _addresseeCode;}
			set{_addresseeCode = value;}
		}

		/// public propaty name  :  AddresseeName
		/// <summary>納品先名称プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeName
		{
			get{return _addresseeName;}
			set{_addresseeName = value;}
		}

		/// public propaty name  :  DirectSendingCd
		/// <summary>直送区分プロパティ</summary>
		/// <value>0:直送なし,1:直送あり　（発注書の直送先印字制御）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   直送区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DirectSendingCd
		{
			get{return _directSendingCd;}
			set{_directSendingCd = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>発注番号プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  WayToOrder
		/// <summary>注文方法プロパティ</summary>
		/// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>納品完了予定日プロパティ</summary>
		/// <value>発注用　（発注回答納期）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>納品完了予定日 和暦プロパティ</summary>
		/// <value>発注用　（発注回答納期）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>納品完了予定日 和暦(略)プロパティ</summary>
		/// <value>発注用　（発注回答納期）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>納品完了予定日 西暦プロパティ</summary>
		/// <value>発注用　（発注回答納期）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>納品完了予定日 西暦(略)プロパティ</summary>
		/// <value>発注用　（発注回答納期）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDate
		/// <summary>希望納期プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   希望納期プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime ExpectDeliveryDate
		{
			get{return _expectDeliveryDate;}
			set{_expectDeliveryDate = value;}
		}

		/// public propaty name  :  ExpectDeliveryDateJpFormal
		/// <summary>希望納期 和暦プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   希望納期 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExpectDeliveryDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDateJpInFormal
		/// <summary>希望納期 和暦(略)プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   希望納期 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExpectDeliveryDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDateAdFormal
		/// <summary>希望納期 西暦プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   希望納期 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExpectDeliveryDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  ExpectDeliveryDateAdInFormal
		/// <summary>希望納期 西暦(略)プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   希望納期 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExpectDeliveryDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _expectDeliveryDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDiv
		/// <summary>発注データ作成区分プロパティ</summary>
		/// <value>1:受発注売上入力,2:発注入力,3:在庫補充発注,4:発注点割れ　（発生元）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注データ作成区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderDataCreateDiv
		{
			get{return _orderDataCreateDiv;}
			set{_orderDataCreateDiv = value;}
		}

		/// public propaty name  :  OrderDataCreateDate
		/// <summary>発注データ作成日プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注データ作成日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime OrderDataCreateDate
		{
			get{return _orderDataCreateDate;}
			set{_orderDataCreateDate = value;}
		}

		/// public propaty name  :  OrderDataCreateDateJpFormal
		/// <summary>発注データ作成日 和暦プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注データ作成日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderDataCreateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDateJpInFormal
		/// <summary>発注データ作成日 和暦(略)プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注データ作成日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderDataCreateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDateAdFormal
		/// <summary>発注データ作成日 西暦プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注データ作成日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderDataCreateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderDataCreateDateAdInFormal
		/// <summary>発注データ作成日 西暦(略)プロパティ</summary>
		/// <value>発注用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注データ作成日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderDataCreateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _orderDataCreateDate);}
			set{}
		}

		/// public propaty name  :  OrderFormIssuedDiv
		/// <summary>発注書発行済区分プロパティ</summary>
		/// <value>0:未発行,1:発行済</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注書発行済区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderFormIssuedDiv
		{
			get{return _orderFormIssuedDiv;}
			set{_orderFormIssuedDiv = value;}
		}

		/// public propaty name  :  DtlRelationGuid
		/// <summary>明細関連付けGUIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細関連付けGUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid DtlRelationGuid
		{
			get{return _dtlRelationGuid;}
			set{_dtlRelationGuid = value;}
		}

		/// public propaty name  :  GoodsOfferDate
		/// <summary>商品提供日付プロパティ</summary>
		/// <value>YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime GoodsOfferDate
		{
			get{return _goodsOfferDate;}
			set{_goodsOfferDate = value;}
		}

		/// public propaty name  :  PriceStartDate
		/// <summary>価格開始日付プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PriceStartDate
		{
			get{return _priceStartDate;}
			set{_priceStartDate = value;}
		}

		/// public propaty name  :  PriceStartDateJpFormal
		/// <summary>価格開始日付 和暦プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PriceStartDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceStartDateJpInFormal
		/// <summary>価格開始日付 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PriceStartDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceStartDateAdFormal
		/// <summary>価格開始日付 西暦プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PriceStartDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceStartDateAdInFormal
		/// <summary>価格開始日付 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格開始日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PriceStartDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _priceStartDate);}
			set{}
		}

		/// public propaty name  :  PriceOfferDate
		/// <summary>価格提供日付プロパティ</summary>
		/// <value>YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PriceOfferDate
		{
			get{return _priceOfferDate;}
			set{_priceOfferDate = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL商品コード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}


		/// <summary>
		/// 仕入明細データコンストラクタ
		/// </summary>
		/// <returns>StockDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDetailクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockDetail()
		{
		}

		/// <summary>
		/// 仕入明細データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="acceptAnOrderNo">受注番号</param>
		/// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
		/// <param name="supplierSlipNo">仕入伝票番号(仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる。（未発注はゼロ）)</param>
		/// <param name="stockRowNo">仕入行番号</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="commonSeqNo">共通通番</param>
		/// <param name="stockSlipDtlNum">仕入明細通番</param>
		/// <param name="supplierFormalSrc">仕入形式（元）(0:仕入,1:入荷,2:発注)</param>
		/// <param name="stockSlipDtlNumSrc">仕入明細通番（元）(計上時の元データ明細通番をセット)</param>
		/// <param name="acptAnOdrStatusSync">受注ステータス（同時）(30:売上,40:出荷)</param>
		/// <param name="salesSlipDtlNumSync">売上明細通番（同時）(同時計上時の仕入明細通番をセット)</param>
		/// <param name="stockSlipCdDtl">仕入伝票区分（明細）(0:仕入,1:返品,2:値引)</param>
		/// <param name="stockInputCode">仕入入力者コード</param>
		/// <param name="stockInputName">仕入入力者名称</param>
		/// <param name="stockAgentCode">仕入担当者コード</param>
		/// <param name="stockAgentName">仕入担当者名称</param>
		/// <param name="goodsKindCode">商品属性</param>
		/// <param name="goodsMakerCd">商品メーカーコード(ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる)</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="makerKanaName">メーカーカナ名称</param>
		/// <param name="cmpltMakerKanaName">メーカーカナ名称（一式）</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsNameKana">商品名称カナ</param>
		/// <param name="goodsLGroup">商品大分類コード(旧大分類（ユーザーガイド）)</param>
		/// <param name="goodsLGroupName">商品大分類名称</param>
		/// <param name="goodsMGroup">商品中分類コード(旧中分類コード)</param>
		/// <param name="goodsMGroupName">商品中分類名称</param>
		/// <param name="bLGroupCode">BLグループコード(旧グループコード)</param>
		/// <param name="bLGroupName">BLグループコード名称</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="enterpriseGanreCode">自社分類コード</param>
		/// <param name="enterpriseGanreName">自社分類名称</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="warehouseShelfNo">倉庫棚番</param>
		/// <param name="stockOrderDivCd">仕入在庫取寄せ区分(0:取寄せ,1:在庫)</param>
		/// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
		/// <param name="goodsRateRank">商品掛率ランク(商品の掛率用ランク)</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード</param>
		/// <param name="suppRateGrpCode">仕入先掛率グループコード</param>
		/// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税抜き)</param>
		/// <param name="listPriceTaxIncFl">定価（税込，浮動）(税込み)</param>
		/// <param name="stockRate">仕入率</param>
		/// <param name="rateSectStckUnPrc">掛率設定拠点（仕入単価）(0:全社設定, その他:拠点コード)</param>
		/// <param name="rateDivStckUnPrc">掛率設定区分（仕入単価）(A7,A8,…)</param>
		/// <param name="unPrcCalcCdStckUnPrc">単価算出区分（仕入単価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
		/// <param name="priceCdStckUnPrc">価格区分（仕入単価）(0:定価,1:登録販売店価格,…)</param>
		/// <param name="stdUnPrcStckUnPrc">基準単価（仕入単価）</param>
		/// <param name="fracProcUnitStcUnPrc">端数処理単位（仕入単価）</param>
		/// <param name="fracProcStckUnPrc">端数処理（仕入単価）(1：切捨て,2：四捨五入,3:切上げ)</param>
		/// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）(税抜き)</param>
		/// <param name="stockUnitTaxPriceFl">仕入単価（税込，浮動）(税込み)</param>
		/// <param name="stockUnitChngDiv">仕入単価変更区分(0:変更なし,1:変更あり　（仕入単価手入力）)</param>
		/// <param name="bfStockUnitPriceFl">変更前仕入単価（浮動）(税抜き、掛率算出結果)</param>
		/// <param name="bfListPrice">変更前定価(税抜き、掛率算出結果)</param>
		/// <param name="rateBLGoodsCode">BL商品コード（掛率）(掛率算出時に使用したBLコード（商品検索結果）)</param>
		/// <param name="rateBLGoodsName">BL商品コード名称（掛率）(掛率算出時に使用したBLコード名称（商品検索結果）)</param>
		/// <param name="rateGoodsRateGrpCd">商品掛率グループコード（掛率）(掛率算出時に使用した商品掛率コード（商品検索結果）)</param>
		/// <param name="rateGoodsRateGrpNm">商品掛率グループ名称（掛率）(掛率算出時に使用した商品掛率名称（商品検索結果）)</param>
		/// <param name="rateBLGroupCode">BLグループコード（掛率）(掛率算出時に使用したBLグループコード（商品検索結果）)</param>
		/// <param name="rateBLGroupName">BLグループ名称（掛率）(掛率算出時に使用したBLグループ名称（商品検索結果）)</param>
		/// <param name="stockCount">仕入数</param>
		/// <param name="orderCnt">発注数量(発注,入荷で使用)</param>
		/// <param name="orderAdjustCnt">発注調整数(現在の発注数は「発注数量＋発注調整数」で算出)</param>
		/// <param name="orderRemainCnt">発注残数(発注数量＋発注調整数－仕入数)</param>
		/// <param name="remainCntUpdDate">残数更新日(YYYYMMDD)</param>
		/// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
		/// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
		/// <param name="stockGoodsCd">仕入商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動))</param>
		/// <param name="stockPriceConsTax">仕入金額消費税額(仕入金額（税込み）- 仕入金額（税抜き）※消費税調整額も兼ねる)</param>
		/// <param name="taxationCode">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
		/// <param name="stockDtiSlipNote1">仕入伝票明細備考1</param>
		/// <param name="salesCustomerCode">販売先コード</param>
		/// <param name="salesCustomerSnm">販売先略称</param>
		/// <param name="slipMemo1">伝票メモ１</param>
		/// <param name="slipMemo2">伝票メモ２</param>
		/// <param name="slipMemo3">伝票メモ３</param>
		/// <param name="insideMemo1">社内メモ１</param>
		/// <param name="insideMemo2">社内メモ２</param>
		/// <param name="insideMemo3">社内メモ３</param>
		/// <param name="supplierCd">仕入先コード(発注用)</param>
		/// <param name="supplierSnm">仕入先略称(発注用)</param>
		/// <param name="addresseeCode">納品先コード(発注用)</param>
		/// <param name="addresseeName">納品先名称(発注用)</param>
		/// <param name="directSendingCd">直送区分(0:直送なし,1:直送あり　（発注書の直送先印字制御）)</param>
		/// <param name="orderNumber">発注番号(発注用)</param>
		/// <param name="wayToOrder">注文方法(0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録)</param>
		/// <param name="deliGdsCmpltDueDate">納品完了予定日(発注用　（発注回答納期）)</param>
		/// <param name="expectDeliveryDate">希望納期(発注用)</param>
		/// <param name="orderDataCreateDiv">発注データ作成区分(1:受発注売上入力,2:発注入力,3:在庫補充発注,4:発注点割れ　（発生元）)</param>
		/// <param name="orderDataCreateDate">発注データ作成日(発注用)</param>
		/// <param name="orderFormIssuedDiv">発注書発行済区分(0:未発行,1:発行済)</param>
		/// <param name="dtlRelationGuid">明細関連付けGUID</param>
		/// <param name="goodsOfferDate">商品提供日付(YYYYMMDD　商品マスタに登録する提供日付、UI側で設定　※DateTime型)</param>
		/// <param name="priceStartDate">価格開始日付(YYYYMMDD　価格マスタに登録する価格開始日、UI側で設定　※DateTime型)</param>
		/// <param name="priceOfferDate">価格提供日付(YYYYMMDD　価格マスタに登録する提供日付、UI側で設定　※DateTime型)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <returns>StockDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDetailクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockDetail(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 acceptAnOrderNo,Int32 supplierFormal,Int32 supplierSlipNo,Int32 stockRowNo,string sectionCode,Int32 subSectionCode,Int64 commonSeqNo,Int64 stockSlipDtlNum,Int32 supplierFormalSrc,Int64 stockSlipDtlNumSrc,Int32 acptAnOdrStatusSync,Int64 salesSlipDtlNumSync,Int32 stockSlipCdDtl,string stockInputCode,string stockInputName,string stockAgentCode,string stockAgentName,Int32 goodsKindCode,Int32 goodsMakerCd,string makerName,string makerKanaName,string cmpltMakerKanaName,string goodsNo,string goodsName,string goodsNameKana,Int32 goodsLGroup,string goodsLGroupName,Int32 goodsMGroup,string goodsMGroupName,Int32 bLGroupCode,string bLGroupName,Int32 bLGoodsCode,string bLGoodsFullName,Int32 enterpriseGanreCode,string enterpriseGanreName,string warehouseCode,string warehouseName,string warehouseShelfNo,Int32 stockOrderDivCd,Int32 openPriceDiv,string goodsRateRank,Int32 custRateGrpCode,Int32 suppRateGrpCode,Double listPriceTaxExcFl,Double listPriceTaxIncFl,Double stockRate,string rateSectStckUnPrc,string rateDivStckUnPrc,Int32 unPrcCalcCdStckUnPrc,Int32 priceCdStckUnPrc,Double stdUnPrcStckUnPrc,Double fracProcUnitStcUnPrc,Int32 fracProcStckUnPrc,Double stockUnitPriceFl,Double stockUnitTaxPriceFl,Int32 stockUnitChngDiv,Double bfStockUnitPriceFl,Double bfListPrice,Int32 rateBLGoodsCode,string rateBLGoodsName,Int32 rateGoodsRateGrpCd,string rateGoodsRateGrpNm,Int32 rateBLGroupCode,string rateBLGroupName,Double stockCount,Double orderCnt,Double orderAdjustCnt,Double orderRemainCnt,DateTime remainCntUpdDate,Int64 stockPriceTaxExc,Int64 stockPriceTaxInc,Int32 stockGoodsCd,Int64 stockPriceConsTax,Int32 taxationCode,string stockDtiSlipNote1,Int32 salesCustomerCode,string salesCustomerSnm,string slipMemo1,string slipMemo2,string slipMemo3,string insideMemo1,string insideMemo2,string insideMemo3,Int32 supplierCd,string supplierSnm,Int32 addresseeCode,string addresseeName,Int32 directSendingCd,string orderNumber,Int32 wayToOrder,DateTime deliGdsCmpltDueDate,DateTime expectDeliveryDate,Int32 orderDataCreateDiv,DateTime orderDataCreateDate,Int32 orderFormIssuedDiv,Guid dtlRelationGuid,DateTime goodsOfferDate,DateTime priceStartDate,DateTime priceOfferDate,string enterpriseName,string updEmployeeName,string bLGoodsName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._acceptAnOrderNo = acceptAnOrderNo;
			this._supplierFormal = supplierFormal;
			this._supplierSlipNo = supplierSlipNo;
			this._stockRowNo = stockRowNo;
			this._sectionCode = sectionCode;
			this._subSectionCode = subSectionCode;
			this._commonSeqNo = commonSeqNo;
			this._stockSlipDtlNum = stockSlipDtlNum;
			this._supplierFormalSrc = supplierFormalSrc;
			this._stockSlipDtlNumSrc = stockSlipDtlNumSrc;
			this._acptAnOdrStatusSync = acptAnOdrStatusSync;
			this._salesSlipDtlNumSync = salesSlipDtlNumSync;
			this._stockSlipCdDtl = stockSlipCdDtl;
			this._stockInputCode = stockInputCode;
			this._stockInputName = stockInputName;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._goodsKindCode = goodsKindCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._makerKanaName = makerKanaName;
			this._cmpltMakerKanaName = cmpltMakerKanaName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._goodsNameKana = goodsNameKana;
			this._goodsLGroup = goodsLGroup;
			this._goodsLGroupName = goodsLGroupName;
			this._goodsMGroup = goodsMGroup;
			this._goodsMGroupName = goodsMGroupName;
			this._bLGroupCode = bLGroupCode;
			this._bLGroupName = bLGroupName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._stockOrderDivCd = stockOrderDivCd;
			this._openPriceDiv = openPriceDiv;
			this._goodsRateRank = goodsRateRank;
			this._custRateGrpCode = custRateGrpCode;
			this._suppRateGrpCode = suppRateGrpCode;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._listPriceTaxIncFl = listPriceTaxIncFl;
			this._stockRate = stockRate;
			this._rateSectStckUnPrc = rateSectStckUnPrc;
			this._rateDivStckUnPrc = rateDivStckUnPrc;
			this._unPrcCalcCdStckUnPrc = unPrcCalcCdStckUnPrc;
			this._priceCdStckUnPrc = priceCdStckUnPrc;
			this._stdUnPrcStckUnPrc = stdUnPrcStckUnPrc;
			this._fracProcUnitStcUnPrc = fracProcUnitStcUnPrc;
			this._fracProcStckUnPrc = fracProcStckUnPrc;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this._stockUnitTaxPriceFl = stockUnitTaxPriceFl;
			this._stockUnitChngDiv = stockUnitChngDiv;
			this._bfStockUnitPriceFl = bfStockUnitPriceFl;
			this._bfListPrice = bfListPrice;
			this._rateBLGoodsCode = rateBLGoodsCode;
			this._rateBLGoodsName = rateBLGoodsName;
			this._rateGoodsRateGrpCd = rateGoodsRateGrpCd;
			this._rateGoodsRateGrpNm = rateGoodsRateGrpNm;
			this._rateBLGroupCode = rateBLGroupCode;
			this._rateBLGroupName = rateBLGroupName;
			this._stockCount = stockCount;
			this._orderCnt = orderCnt;
			this._orderAdjustCnt = orderAdjustCnt;
			this._orderRemainCnt = orderRemainCnt;
			this.RemainCntUpdDate = remainCntUpdDate;
			this._stockPriceTaxExc = stockPriceTaxExc;
			this._stockPriceTaxInc = stockPriceTaxInc;
			this._stockGoodsCd = stockGoodsCd;
			this._stockPriceConsTax = stockPriceConsTax;
			this._taxationCode = taxationCode;
			this._stockDtiSlipNote1 = stockDtiSlipNote1;
			this._salesCustomerCode = salesCustomerCode;
			this._salesCustomerSnm = salesCustomerSnm;
			this._slipMemo1 = slipMemo1;
			this._slipMemo2 = slipMemo2;
			this._slipMemo3 = slipMemo3;
			this._insideMemo1 = insideMemo1;
			this._insideMemo2 = insideMemo2;
			this._insideMemo3 = insideMemo3;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._addresseeCode = addresseeCode;
			this._addresseeName = addresseeName;
			this._directSendingCd = directSendingCd;
			this._orderNumber = orderNumber;
			this._wayToOrder = wayToOrder;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this.ExpectDeliveryDate = expectDeliveryDate;
			this._orderDataCreateDiv = orderDataCreateDiv;
			this.OrderDataCreateDate = orderDataCreateDate;
			this._orderFormIssuedDiv = orderFormIssuedDiv;
			this._dtlRelationGuid = dtlRelationGuid;
			this._goodsOfferDate = goodsOfferDate;
			this.PriceStartDate = priceStartDate;
			this._priceOfferDate = priceOfferDate;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// 仕入明細データ複製処理
		/// </summary>
		/// <returns>StockDetailクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockDetailクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockDetail Clone()
		{
			return new StockDetail(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._acceptAnOrderNo,this._supplierFormal,this._supplierSlipNo,this._stockRowNo,this._sectionCode,this._subSectionCode,this._commonSeqNo,this._stockSlipDtlNum,this._supplierFormalSrc,this._stockSlipDtlNumSrc,this._acptAnOdrStatusSync,this._salesSlipDtlNumSync,this._stockSlipCdDtl,this._stockInputCode,this._stockInputName,this._stockAgentCode,this._stockAgentName,this._goodsKindCode,this._goodsMakerCd,this._makerName,this._makerKanaName,this._cmpltMakerKanaName,this._goodsNo,this._goodsName,this._goodsNameKana,this._goodsLGroup,this._goodsLGroupName,this._goodsMGroup,this._goodsMGroupName,this._bLGroupCode,this._bLGroupName,this._bLGoodsCode,this._bLGoodsFullName,this._enterpriseGanreCode,this._enterpriseGanreName,this._warehouseCode,this._warehouseName,this._warehouseShelfNo,this._stockOrderDivCd,this._openPriceDiv,this._goodsRateRank,this._custRateGrpCode,this._suppRateGrpCode,this._listPriceTaxExcFl,this._listPriceTaxIncFl,this._stockRate,this._rateSectStckUnPrc,this._rateDivStckUnPrc,this._unPrcCalcCdStckUnPrc,this._priceCdStckUnPrc,this._stdUnPrcStckUnPrc,this._fracProcUnitStcUnPrc,this._fracProcStckUnPrc,this._stockUnitPriceFl,this._stockUnitTaxPriceFl,this._stockUnitChngDiv,this._bfStockUnitPriceFl,this._bfListPrice,this._rateBLGoodsCode,this._rateBLGoodsName,this._rateGoodsRateGrpCd,this._rateGoodsRateGrpNm,this._rateBLGroupCode,this._rateBLGroupName,this._stockCount,this._orderCnt,this._orderAdjustCnt,this._orderRemainCnt,this._remainCntUpdDate,this._stockPriceTaxExc,this._stockPriceTaxInc,this._stockGoodsCd,this._stockPriceConsTax,this._taxationCode,this._stockDtiSlipNote1,this._salesCustomerCode,this._salesCustomerSnm,this._slipMemo1,this._slipMemo2,this._slipMemo3,this._insideMemo1,this._insideMemo2,this._insideMemo3,this._supplierCd,this._supplierSnm,this._addresseeCode,this._addresseeName,this._directSendingCd,this._orderNumber,this._wayToOrder,this._deliGdsCmpltDueDate,this._expectDeliveryDate,this._orderDataCreateDiv,this._orderDataCreateDate,this._orderFormIssuedDiv,this._dtlRelationGuid,this._goodsOfferDate,this._priceStartDate,this._priceOfferDate,this._enterpriseName,this._updEmployeeName,this._bLGoodsName);
		}

		/// <summary>
		/// 仕入明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockDetailクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDetailクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockDetail target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
				 && (this.SupplierFormal == target.SupplierFormal)
				 && (this.SupplierSlipNo == target.SupplierSlipNo)
				 && (this.StockRowNo == target.StockRowNo)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.CommonSeqNo == target.CommonSeqNo)
				 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
				 && (this.SupplierFormalSrc == target.SupplierFormalSrc)
				 && (this.StockSlipDtlNumSrc == target.StockSlipDtlNumSrc)
				 && (this.AcptAnOdrStatusSync == target.AcptAnOdrStatusSync)
				 && (this.SalesSlipDtlNumSync == target.SalesSlipDtlNumSync)
				 && (this.StockSlipCdDtl == target.StockSlipCdDtl)
				 && (this.StockInputCode == target.StockInputCode)
				 && (this.StockInputName == target.StockInputName)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.MakerKanaName == target.MakerKanaName)
				 && (this.CmpltMakerKanaName == target.CmpltMakerKanaName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.GoodsLGroup == target.GoodsLGroup)
				 && (this.GoodsLGroupName == target.GoodsLGroupName)
				 && (this.GoodsMGroup == target.GoodsMGroup)
				 && (this.GoodsMGroupName == target.GoodsMGroupName)
				 && (this.BLGroupCode == target.BLGroupCode)
				 && (this.BLGroupName == target.BLGroupName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.StockOrderDivCd == target.StockOrderDivCd)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.GoodsRateRank == target.GoodsRateRank)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
				 && (this.StockRate == target.StockRate)
				 && (this.RateSectStckUnPrc == target.RateSectStckUnPrc)
				 && (this.RateDivStckUnPrc == target.RateDivStckUnPrc)
				 && (this.UnPrcCalcCdStckUnPrc == target.UnPrcCalcCdStckUnPrc)
				 && (this.PriceCdStckUnPrc == target.PriceCdStckUnPrc)
				 && (this.StdUnPrcStckUnPrc == target.StdUnPrcStckUnPrc)
				 && (this.FracProcUnitStcUnPrc == target.FracProcUnitStcUnPrc)
				 && (this.FracProcStckUnPrc == target.FracProcStckUnPrc)
				 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
				 && (this.StockUnitTaxPriceFl == target.StockUnitTaxPriceFl)
				 && (this.StockUnitChngDiv == target.StockUnitChngDiv)
				 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
				 && (this.BfListPrice == target.BfListPrice)
				 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
				 && (this.RateBLGoodsName == target.RateBLGoodsName)
				 && (this.RateGoodsRateGrpCd == target.RateGoodsRateGrpCd)
				 && (this.RateGoodsRateGrpNm == target.RateGoodsRateGrpNm)
				 && (this.RateBLGroupCode == target.RateBLGroupCode)
				 && (this.RateBLGroupName == target.RateBLGroupName)
				 && (this.StockCount == target.StockCount)
				 && (this.OrderCnt == target.OrderCnt)
				 && (this.OrderAdjustCnt == target.OrderAdjustCnt)
				 && (this.OrderRemainCnt == target.OrderRemainCnt)
				 && (this.RemainCntUpdDate == target.RemainCntUpdDate)
				 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
				 && (this.StockPriceTaxInc == target.StockPriceTaxInc)
				 && (this.StockGoodsCd == target.StockGoodsCd)
				 && (this.StockPriceConsTax == target.StockPriceConsTax)
				 && (this.TaxationCode == target.TaxationCode)
				 && (this.StockDtiSlipNote1 == target.StockDtiSlipNote1)
				 && (this.SalesCustomerCode == target.SalesCustomerCode)
				 && (this.SalesCustomerSnm == target.SalesCustomerSnm)
				 && (this.SlipMemo1 == target.SlipMemo1)
				 && (this.SlipMemo2 == target.SlipMemo2)
				 && (this.SlipMemo3 == target.SlipMemo3)
				 && (this.InsideMemo1 == target.InsideMemo1)
				 && (this.InsideMemo2 == target.InsideMemo2)
				 && (this.InsideMemo3 == target.InsideMemo3)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.AddresseeCode == target.AddresseeCode)
				 && (this.AddresseeName == target.AddresseeName)
				 && (this.DirectSendingCd == target.DirectSendingCd)
				 && (this.OrderNumber == target.OrderNumber)
				 && (this.WayToOrder == target.WayToOrder)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.ExpectDeliveryDate == target.ExpectDeliveryDate)
				 && (this.OrderDataCreateDiv == target.OrderDataCreateDiv)
				 && (this.OrderDataCreateDate == target.OrderDataCreateDate)
				 && (this.OrderFormIssuedDiv == target.OrderFormIssuedDiv)
				 && (this.DtlRelationGuid == target.DtlRelationGuid)
				 && (this.GoodsOfferDate == target.GoodsOfferDate)
				 && (this.PriceStartDate == target.PriceStartDate)
				 && (this.PriceOfferDate == target.PriceOfferDate)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// 仕入明細データ比較処理
		/// </summary>
		/// <param name="stockDetail1">
		///                    比較するStockDetailクラスのインスタンス
		/// </param>
		/// <param name="stockDetail2">比較するStockDetailクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDetailクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockDetail stockDetail1, StockDetail stockDetail2)
		{
			return ((stockDetail1.CreateDateTime == stockDetail2.CreateDateTime)
				 && (stockDetail1.UpdateDateTime == stockDetail2.UpdateDateTime)
				 && (stockDetail1.EnterpriseCode == stockDetail2.EnterpriseCode)
				 && (stockDetail1.FileHeaderGuid == stockDetail2.FileHeaderGuid)
				 && (stockDetail1.UpdEmployeeCode == stockDetail2.UpdEmployeeCode)
				 && (stockDetail1.UpdAssemblyId1 == stockDetail2.UpdAssemblyId1)
				 && (stockDetail1.UpdAssemblyId2 == stockDetail2.UpdAssemblyId2)
				 && (stockDetail1.LogicalDeleteCode == stockDetail2.LogicalDeleteCode)
				 && (stockDetail1.AcceptAnOrderNo == stockDetail2.AcceptAnOrderNo)
				 && (stockDetail1.SupplierFormal == stockDetail2.SupplierFormal)
				 && (stockDetail1.SupplierSlipNo == stockDetail2.SupplierSlipNo)
				 && (stockDetail1.StockRowNo == stockDetail2.StockRowNo)
				 && (stockDetail1.SectionCode == stockDetail2.SectionCode)
				 && (stockDetail1.SubSectionCode == stockDetail2.SubSectionCode)
				 && (stockDetail1.CommonSeqNo == stockDetail2.CommonSeqNo)
				 && (stockDetail1.StockSlipDtlNum == stockDetail2.StockSlipDtlNum)
				 && (stockDetail1.SupplierFormalSrc == stockDetail2.SupplierFormalSrc)
				 && (stockDetail1.StockSlipDtlNumSrc == stockDetail2.StockSlipDtlNumSrc)
				 && (stockDetail1.AcptAnOdrStatusSync == stockDetail2.AcptAnOdrStatusSync)
				 && (stockDetail1.SalesSlipDtlNumSync == stockDetail2.SalesSlipDtlNumSync)
				 && (stockDetail1.StockSlipCdDtl == stockDetail2.StockSlipCdDtl)
				 && (stockDetail1.StockInputCode == stockDetail2.StockInputCode)
				 && (stockDetail1.StockInputName == stockDetail2.StockInputName)
				 && (stockDetail1.StockAgentCode == stockDetail2.StockAgentCode)
				 && (stockDetail1.StockAgentName == stockDetail2.StockAgentName)
				 && (stockDetail1.GoodsKindCode == stockDetail2.GoodsKindCode)
				 && (stockDetail1.GoodsMakerCd == stockDetail2.GoodsMakerCd)
				 && (stockDetail1.MakerName == stockDetail2.MakerName)
				 && (stockDetail1.MakerKanaName == stockDetail2.MakerKanaName)
				 && (stockDetail1.CmpltMakerKanaName == stockDetail2.CmpltMakerKanaName)
				 && (stockDetail1.GoodsNo == stockDetail2.GoodsNo)
				 && (stockDetail1.GoodsName == stockDetail2.GoodsName)
				 && (stockDetail1.GoodsNameKana == stockDetail2.GoodsNameKana)
				 && (stockDetail1.GoodsLGroup == stockDetail2.GoodsLGroup)
				 && (stockDetail1.GoodsLGroupName == stockDetail2.GoodsLGroupName)
				 && (stockDetail1.GoodsMGroup == stockDetail2.GoodsMGroup)
				 && (stockDetail1.GoodsMGroupName == stockDetail2.GoodsMGroupName)
				 && (stockDetail1.BLGroupCode == stockDetail2.BLGroupCode)
				 && (stockDetail1.BLGroupName == stockDetail2.BLGroupName)
				 && (stockDetail1.BLGoodsCode == stockDetail2.BLGoodsCode)
				 && (stockDetail1.BLGoodsFullName == stockDetail2.BLGoodsFullName)
				 && (stockDetail1.EnterpriseGanreCode == stockDetail2.EnterpriseGanreCode)
				 && (stockDetail1.EnterpriseGanreName == stockDetail2.EnterpriseGanreName)
				 && (stockDetail1.WarehouseCode == stockDetail2.WarehouseCode)
				 && (stockDetail1.WarehouseName == stockDetail2.WarehouseName)
				 && (stockDetail1.WarehouseShelfNo == stockDetail2.WarehouseShelfNo)
				 && (stockDetail1.StockOrderDivCd == stockDetail2.StockOrderDivCd)
				 && (stockDetail1.OpenPriceDiv == stockDetail2.OpenPriceDiv)
				 && (stockDetail1.GoodsRateRank == stockDetail2.GoodsRateRank)
				 && (stockDetail1.CustRateGrpCode == stockDetail2.CustRateGrpCode)
				 && (stockDetail1.SuppRateGrpCode == stockDetail2.SuppRateGrpCode)
				 && (stockDetail1.ListPriceTaxExcFl == stockDetail2.ListPriceTaxExcFl)
				 && (stockDetail1.ListPriceTaxIncFl == stockDetail2.ListPriceTaxIncFl)
				 && (stockDetail1.StockRate == stockDetail2.StockRate)
				 && (stockDetail1.RateSectStckUnPrc == stockDetail2.RateSectStckUnPrc)
				 && (stockDetail1.RateDivStckUnPrc == stockDetail2.RateDivStckUnPrc)
				 && (stockDetail1.UnPrcCalcCdStckUnPrc == stockDetail2.UnPrcCalcCdStckUnPrc)
				 && (stockDetail1.PriceCdStckUnPrc == stockDetail2.PriceCdStckUnPrc)
				 && (stockDetail1.StdUnPrcStckUnPrc == stockDetail2.StdUnPrcStckUnPrc)
				 && (stockDetail1.FracProcUnitStcUnPrc == stockDetail2.FracProcUnitStcUnPrc)
				 && (stockDetail1.FracProcStckUnPrc == stockDetail2.FracProcStckUnPrc)
				 && (stockDetail1.StockUnitPriceFl == stockDetail2.StockUnitPriceFl)
				 && (stockDetail1.StockUnitTaxPriceFl == stockDetail2.StockUnitTaxPriceFl)
				 && (stockDetail1.StockUnitChngDiv == stockDetail2.StockUnitChngDiv)
				 && (stockDetail1.BfStockUnitPriceFl == stockDetail2.BfStockUnitPriceFl)
				 && (stockDetail1.BfListPrice == stockDetail2.BfListPrice)
				 && (stockDetail1.RateBLGoodsCode == stockDetail2.RateBLGoodsCode)
				 && (stockDetail1.RateBLGoodsName == stockDetail2.RateBLGoodsName)
				 && (stockDetail1.RateGoodsRateGrpCd == stockDetail2.RateGoodsRateGrpCd)
				 && (stockDetail1.RateGoodsRateGrpNm == stockDetail2.RateGoodsRateGrpNm)
				 && (stockDetail1.RateBLGroupCode == stockDetail2.RateBLGroupCode)
				 && (stockDetail1.RateBLGroupName == stockDetail2.RateBLGroupName)
				 && (stockDetail1.StockCount == stockDetail2.StockCount)
				 && (stockDetail1.OrderCnt == stockDetail2.OrderCnt)
				 && (stockDetail1.OrderAdjustCnt == stockDetail2.OrderAdjustCnt)
				 && (stockDetail1.OrderRemainCnt == stockDetail2.OrderRemainCnt)
				 && (stockDetail1.RemainCntUpdDate == stockDetail2.RemainCntUpdDate)
				 && (stockDetail1.StockPriceTaxExc == stockDetail2.StockPriceTaxExc)
				 && (stockDetail1.StockPriceTaxInc == stockDetail2.StockPriceTaxInc)
				 && (stockDetail1.StockGoodsCd == stockDetail2.StockGoodsCd)
				 && (stockDetail1.StockPriceConsTax == stockDetail2.StockPriceConsTax)
				 && (stockDetail1.TaxationCode == stockDetail2.TaxationCode)
				 && (stockDetail1.StockDtiSlipNote1 == stockDetail2.StockDtiSlipNote1)
				 && (stockDetail1.SalesCustomerCode == stockDetail2.SalesCustomerCode)
				 && (stockDetail1.SalesCustomerSnm == stockDetail2.SalesCustomerSnm)
				 && (stockDetail1.SlipMemo1 == stockDetail2.SlipMemo1)
				 && (stockDetail1.SlipMemo2 == stockDetail2.SlipMemo2)
				 && (stockDetail1.SlipMemo3 == stockDetail2.SlipMemo3)
				 && (stockDetail1.InsideMemo1 == stockDetail2.InsideMemo1)
				 && (stockDetail1.InsideMemo2 == stockDetail2.InsideMemo2)
				 && (stockDetail1.InsideMemo3 == stockDetail2.InsideMemo3)
				 && (stockDetail1.SupplierCd == stockDetail2.SupplierCd)
				 && (stockDetail1.SupplierSnm == stockDetail2.SupplierSnm)
				 && (stockDetail1.AddresseeCode == stockDetail2.AddresseeCode)
				 && (stockDetail1.AddresseeName == stockDetail2.AddresseeName)
				 && (stockDetail1.DirectSendingCd == stockDetail2.DirectSendingCd)
				 && (stockDetail1.OrderNumber == stockDetail2.OrderNumber)
				 && (stockDetail1.WayToOrder == stockDetail2.WayToOrder)
				 && (stockDetail1.DeliGdsCmpltDueDate == stockDetail2.DeliGdsCmpltDueDate)
				 && (stockDetail1.ExpectDeliveryDate == stockDetail2.ExpectDeliveryDate)
				 && (stockDetail1.OrderDataCreateDiv == stockDetail2.OrderDataCreateDiv)
				 && (stockDetail1.OrderDataCreateDate == stockDetail2.OrderDataCreateDate)
				 && (stockDetail1.OrderFormIssuedDiv == stockDetail2.OrderFormIssuedDiv)
				 && (stockDetail1.DtlRelationGuid == stockDetail2.DtlRelationGuid)
				 && (stockDetail1.GoodsOfferDate == stockDetail2.GoodsOfferDate)
				 && (stockDetail1.PriceStartDate == stockDetail2.PriceStartDate)
				 && (stockDetail1.PriceOfferDate == stockDetail2.PriceOfferDate)
				 && (stockDetail1.EnterpriseName == stockDetail2.EnterpriseName)
				 && (stockDetail1.UpdEmployeeName == stockDetail2.UpdEmployeeName)
				 && (stockDetail1.BLGoodsName == stockDetail2.BLGoodsName));
		}
		/// <summary>
		/// 仕入明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockDetailクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDetailクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockDetail target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.AcceptAnOrderNo != target.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(this.SupplierFormal != target.SupplierFormal)resList.Add("SupplierFormal");
			if(this.SupplierSlipNo != target.SupplierSlipNo)resList.Add("SupplierSlipNo");
			if(this.StockRowNo != target.StockRowNo)resList.Add("StockRowNo");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SubSectionCode != target.SubSectionCode)resList.Add("SubSectionCode");
			if(this.CommonSeqNo != target.CommonSeqNo)resList.Add("CommonSeqNo");
			if(this.StockSlipDtlNum != target.StockSlipDtlNum)resList.Add("StockSlipDtlNum");
			if(this.SupplierFormalSrc != target.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(this.StockSlipDtlNumSrc != target.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(this.AcptAnOdrStatusSync != target.AcptAnOdrStatusSync)resList.Add("AcptAnOdrStatusSync");
			if(this.SalesSlipDtlNumSync != target.SalesSlipDtlNumSync)resList.Add("SalesSlipDtlNumSync");
			if(this.StockSlipCdDtl != target.StockSlipCdDtl)resList.Add("StockSlipCdDtl");
			if(this.StockInputCode != target.StockInputCode)resList.Add("StockInputCode");
			if(this.StockInputName != target.StockInputName)resList.Add("StockInputName");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.MakerKanaName != target.MakerKanaName)resList.Add("MakerKanaName");
			if(this.CmpltMakerKanaName != target.CmpltMakerKanaName)resList.Add("CmpltMakerKanaName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.GoodsLGroup != target.GoodsLGroup)resList.Add("GoodsLGroup");
			if(this.GoodsLGroupName != target.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(this.GoodsMGroup != target.GoodsMGroup)resList.Add("GoodsMGroup");
			if(this.GoodsMGroupName != target.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(this.BLGroupCode != target.BLGroupCode)resList.Add("BLGroupCode");
			if(this.BLGroupName != target.BLGroupName)resList.Add("BLGroupName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.StockOrderDivCd != target.StockOrderDivCd)resList.Add("StockOrderDivCd");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.GoodsRateRank != target.GoodsRateRank)resList.Add("GoodsRateRank");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(this.SuppRateGrpCode != target.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.ListPriceTaxIncFl != target.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(this.StockRate != target.StockRate)resList.Add("StockRate");
			if(this.RateSectStckUnPrc != target.RateSectStckUnPrc)resList.Add("RateSectStckUnPrc");
			if(this.RateDivStckUnPrc != target.RateDivStckUnPrc)resList.Add("RateDivStckUnPrc");
			if(this.UnPrcCalcCdStckUnPrc != target.UnPrcCalcCdStckUnPrc)resList.Add("UnPrcCalcCdStckUnPrc");
			if(this.PriceCdStckUnPrc != target.PriceCdStckUnPrc)resList.Add("PriceCdStckUnPrc");
			if(this.StdUnPrcStckUnPrc != target.StdUnPrcStckUnPrc)resList.Add("StdUnPrcStckUnPrc");
			if(this.FracProcUnitStcUnPrc != target.FracProcUnitStcUnPrc)resList.Add("FracProcUnitStcUnPrc");
			if(this.FracProcStckUnPrc != target.FracProcStckUnPrc)resList.Add("FracProcStckUnPrc");
			if(this.StockUnitPriceFl != target.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(this.StockUnitTaxPriceFl != target.StockUnitTaxPriceFl)resList.Add("StockUnitTaxPriceFl");
			if(this.StockUnitChngDiv != target.StockUnitChngDiv)resList.Add("StockUnitChngDiv");
			if(this.BfStockUnitPriceFl != target.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(this.BfListPrice != target.BfListPrice)resList.Add("BfListPrice");
			if(this.RateBLGoodsCode != target.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(this.RateBLGoodsName != target.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(this.RateGoodsRateGrpCd != target.RateGoodsRateGrpCd)resList.Add("RateGoodsRateGrpCd");
			if(this.RateGoodsRateGrpNm != target.RateGoodsRateGrpNm)resList.Add("RateGoodsRateGrpNm");
			if(this.RateBLGroupCode != target.RateBLGroupCode)resList.Add("RateBLGroupCode");
			if(this.RateBLGroupName != target.RateBLGroupName)resList.Add("RateBLGroupName");
			if(this.StockCount != target.StockCount)resList.Add("StockCount");
			if(this.OrderCnt != target.OrderCnt)resList.Add("OrderCnt");
			if(this.OrderAdjustCnt != target.OrderAdjustCnt)resList.Add("OrderAdjustCnt");
			if(this.OrderRemainCnt != target.OrderRemainCnt)resList.Add("OrderRemainCnt");
			if(this.RemainCntUpdDate != target.RemainCntUpdDate)resList.Add("RemainCntUpdDate");
			if(this.StockPriceTaxExc != target.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(this.StockPriceTaxInc != target.StockPriceTaxInc)resList.Add("StockPriceTaxInc");
			if(this.StockGoodsCd != target.StockGoodsCd)resList.Add("StockGoodsCd");
			if(this.StockPriceConsTax != target.StockPriceConsTax)resList.Add("StockPriceConsTax");
			if(this.TaxationCode != target.TaxationCode)resList.Add("TaxationCode");
			if(this.StockDtiSlipNote1 != target.StockDtiSlipNote1)resList.Add("StockDtiSlipNote1");
			if(this.SalesCustomerCode != target.SalesCustomerCode)resList.Add("SalesCustomerCode");
			if(this.SalesCustomerSnm != target.SalesCustomerSnm)resList.Add("SalesCustomerSnm");
			if(this.SlipMemo1 != target.SlipMemo1)resList.Add("SlipMemo1");
			if(this.SlipMemo2 != target.SlipMemo2)resList.Add("SlipMemo2");
			if(this.SlipMemo3 != target.SlipMemo3)resList.Add("SlipMemo3");
			if(this.InsideMemo1 != target.InsideMemo1)resList.Add("InsideMemo1");
			if(this.InsideMemo2 != target.InsideMemo2)resList.Add("InsideMemo2");
			if(this.InsideMemo3 != target.InsideMemo3)resList.Add("InsideMemo3");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.AddresseeCode != target.AddresseeCode)resList.Add("AddresseeCode");
			if(this.AddresseeName != target.AddresseeName)resList.Add("AddresseeName");
			if(this.DirectSendingCd != target.DirectSendingCd)resList.Add("DirectSendingCd");
			if(this.OrderNumber != target.OrderNumber)resList.Add("OrderNumber");
			if(this.WayToOrder != target.WayToOrder)resList.Add("WayToOrder");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.ExpectDeliveryDate != target.ExpectDeliveryDate)resList.Add("ExpectDeliveryDate");
			if(this.OrderDataCreateDiv != target.OrderDataCreateDiv)resList.Add("OrderDataCreateDiv");
			if(this.OrderDataCreateDate != target.OrderDataCreateDate)resList.Add("OrderDataCreateDate");
			if(this.OrderFormIssuedDiv != target.OrderFormIssuedDiv)resList.Add("OrderFormIssuedDiv");
			if(this.DtlRelationGuid != target.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(this.GoodsOfferDate != target.GoodsOfferDate)resList.Add("GoodsOfferDate");
			if(this.PriceStartDate != target.PriceStartDate)resList.Add("PriceStartDate");
			if(this.PriceOfferDate != target.PriceOfferDate)resList.Add("PriceOfferDate");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// 仕入明細データ比較処理
		/// </summary>
		/// <param name="stockDetail1">比較するStockDetailクラスのインスタンス</param>
		/// <param name="stockDetail2">比較するStockDetailクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockDetailクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockDetail stockDetail1, StockDetail stockDetail2)
		{
			ArrayList resList = new ArrayList();
			if(stockDetail1.CreateDateTime != stockDetail2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockDetail1.UpdateDateTime != stockDetail2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockDetail1.EnterpriseCode != stockDetail2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockDetail1.FileHeaderGuid != stockDetail2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockDetail1.UpdEmployeeCode != stockDetail2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockDetail1.UpdAssemblyId1 != stockDetail2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockDetail1.UpdAssemblyId2 != stockDetail2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockDetail1.LogicalDeleteCode != stockDetail2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockDetail1.AcceptAnOrderNo != stockDetail2.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(stockDetail1.SupplierFormal != stockDetail2.SupplierFormal)resList.Add("SupplierFormal");
			if(stockDetail1.SupplierSlipNo != stockDetail2.SupplierSlipNo)resList.Add("SupplierSlipNo");
			if(stockDetail1.StockRowNo != stockDetail2.StockRowNo)resList.Add("StockRowNo");
			if(stockDetail1.SectionCode != stockDetail2.SectionCode)resList.Add("SectionCode");
			if(stockDetail1.SubSectionCode != stockDetail2.SubSectionCode)resList.Add("SubSectionCode");
			if(stockDetail1.CommonSeqNo != stockDetail2.CommonSeqNo)resList.Add("CommonSeqNo");
			if(stockDetail1.StockSlipDtlNum != stockDetail2.StockSlipDtlNum)resList.Add("StockSlipDtlNum");
			if(stockDetail1.SupplierFormalSrc != stockDetail2.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(stockDetail1.StockSlipDtlNumSrc != stockDetail2.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(stockDetail1.AcptAnOdrStatusSync != stockDetail2.AcptAnOdrStatusSync)resList.Add("AcptAnOdrStatusSync");
			if(stockDetail1.SalesSlipDtlNumSync != stockDetail2.SalesSlipDtlNumSync)resList.Add("SalesSlipDtlNumSync");
			if(stockDetail1.StockSlipCdDtl != stockDetail2.StockSlipCdDtl)resList.Add("StockSlipCdDtl");
			if(stockDetail1.StockInputCode != stockDetail2.StockInputCode)resList.Add("StockInputCode");
			if(stockDetail1.StockInputName != stockDetail2.StockInputName)resList.Add("StockInputName");
			if(stockDetail1.StockAgentCode != stockDetail2.StockAgentCode)resList.Add("StockAgentCode");
			if(stockDetail1.StockAgentName != stockDetail2.StockAgentName)resList.Add("StockAgentName");
			if(stockDetail1.GoodsKindCode != stockDetail2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(stockDetail1.GoodsMakerCd != stockDetail2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockDetail1.MakerName != stockDetail2.MakerName)resList.Add("MakerName");
			if(stockDetail1.MakerKanaName != stockDetail2.MakerKanaName)resList.Add("MakerKanaName");
			if(stockDetail1.CmpltMakerKanaName != stockDetail2.CmpltMakerKanaName)resList.Add("CmpltMakerKanaName");
			if(stockDetail1.GoodsNo != stockDetail2.GoodsNo)resList.Add("GoodsNo");
			if(stockDetail1.GoodsName != stockDetail2.GoodsName)resList.Add("GoodsName");
			if(stockDetail1.GoodsNameKana != stockDetail2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(stockDetail1.GoodsLGroup != stockDetail2.GoodsLGroup)resList.Add("GoodsLGroup");
			if(stockDetail1.GoodsLGroupName != stockDetail2.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(stockDetail1.GoodsMGroup != stockDetail2.GoodsMGroup)resList.Add("GoodsMGroup");
			if(stockDetail1.GoodsMGroupName != stockDetail2.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(stockDetail1.BLGroupCode != stockDetail2.BLGroupCode)resList.Add("BLGroupCode");
			if(stockDetail1.BLGroupName != stockDetail2.BLGroupName)resList.Add("BLGroupName");
			if(stockDetail1.BLGoodsCode != stockDetail2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockDetail1.BLGoodsFullName != stockDetail2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(stockDetail1.EnterpriseGanreCode != stockDetail2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(stockDetail1.EnterpriseGanreName != stockDetail2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(stockDetail1.WarehouseCode != stockDetail2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockDetail1.WarehouseName != stockDetail2.WarehouseName)resList.Add("WarehouseName");
			if(stockDetail1.WarehouseShelfNo != stockDetail2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(stockDetail1.StockOrderDivCd != stockDetail2.StockOrderDivCd)resList.Add("StockOrderDivCd");
			if(stockDetail1.OpenPriceDiv != stockDetail2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(stockDetail1.GoodsRateRank != stockDetail2.GoodsRateRank)resList.Add("GoodsRateRank");
			if(stockDetail1.CustRateGrpCode != stockDetail2.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(stockDetail1.SuppRateGrpCode != stockDetail2.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(stockDetail1.ListPriceTaxExcFl != stockDetail2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(stockDetail1.ListPriceTaxIncFl != stockDetail2.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(stockDetail1.StockRate != stockDetail2.StockRate)resList.Add("StockRate");
			if(stockDetail1.RateSectStckUnPrc != stockDetail2.RateSectStckUnPrc)resList.Add("RateSectStckUnPrc");
			if(stockDetail1.RateDivStckUnPrc != stockDetail2.RateDivStckUnPrc)resList.Add("RateDivStckUnPrc");
			if(stockDetail1.UnPrcCalcCdStckUnPrc != stockDetail2.UnPrcCalcCdStckUnPrc)resList.Add("UnPrcCalcCdStckUnPrc");
			if(stockDetail1.PriceCdStckUnPrc != stockDetail2.PriceCdStckUnPrc)resList.Add("PriceCdStckUnPrc");
			if(stockDetail1.StdUnPrcStckUnPrc != stockDetail2.StdUnPrcStckUnPrc)resList.Add("StdUnPrcStckUnPrc");
			if(stockDetail1.FracProcUnitStcUnPrc != stockDetail2.FracProcUnitStcUnPrc)resList.Add("FracProcUnitStcUnPrc");
			if(stockDetail1.FracProcStckUnPrc != stockDetail2.FracProcStckUnPrc)resList.Add("FracProcStckUnPrc");
			if(stockDetail1.StockUnitPriceFl != stockDetail2.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(stockDetail1.StockUnitTaxPriceFl != stockDetail2.StockUnitTaxPriceFl)resList.Add("StockUnitTaxPriceFl");
			if(stockDetail1.StockUnitChngDiv != stockDetail2.StockUnitChngDiv)resList.Add("StockUnitChngDiv");
			if(stockDetail1.BfStockUnitPriceFl != stockDetail2.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(stockDetail1.BfListPrice != stockDetail2.BfListPrice)resList.Add("BfListPrice");
			if(stockDetail1.RateBLGoodsCode != stockDetail2.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(stockDetail1.RateBLGoodsName != stockDetail2.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(stockDetail1.RateGoodsRateGrpCd != stockDetail2.RateGoodsRateGrpCd)resList.Add("RateGoodsRateGrpCd");
			if(stockDetail1.RateGoodsRateGrpNm != stockDetail2.RateGoodsRateGrpNm)resList.Add("RateGoodsRateGrpNm");
			if(stockDetail1.RateBLGroupCode != stockDetail2.RateBLGroupCode)resList.Add("RateBLGroupCode");
			if(stockDetail1.RateBLGroupName != stockDetail2.RateBLGroupName)resList.Add("RateBLGroupName");
			if(stockDetail1.StockCount != stockDetail2.StockCount)resList.Add("StockCount");
			if(stockDetail1.OrderCnt != stockDetail2.OrderCnt)resList.Add("OrderCnt");
			if(stockDetail1.OrderAdjustCnt != stockDetail2.OrderAdjustCnt)resList.Add("OrderAdjustCnt");
			if(stockDetail1.OrderRemainCnt != stockDetail2.OrderRemainCnt)resList.Add("OrderRemainCnt");
			if(stockDetail1.RemainCntUpdDate != stockDetail2.RemainCntUpdDate)resList.Add("RemainCntUpdDate");
			if(stockDetail1.StockPriceTaxExc != stockDetail2.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(stockDetail1.StockPriceTaxInc != stockDetail2.StockPriceTaxInc)resList.Add("StockPriceTaxInc");
			if(stockDetail1.StockGoodsCd != stockDetail2.StockGoodsCd)resList.Add("StockGoodsCd");
			if(stockDetail1.StockPriceConsTax != stockDetail2.StockPriceConsTax)resList.Add("StockPriceConsTax");
			if(stockDetail1.TaxationCode != stockDetail2.TaxationCode)resList.Add("TaxationCode");
			if(stockDetail1.StockDtiSlipNote1 != stockDetail2.StockDtiSlipNote1)resList.Add("StockDtiSlipNote1");
			if(stockDetail1.SalesCustomerCode != stockDetail2.SalesCustomerCode)resList.Add("SalesCustomerCode");
			if(stockDetail1.SalesCustomerSnm != stockDetail2.SalesCustomerSnm)resList.Add("SalesCustomerSnm");
			if(stockDetail1.SlipMemo1 != stockDetail2.SlipMemo1)resList.Add("SlipMemo1");
			if(stockDetail1.SlipMemo2 != stockDetail2.SlipMemo2)resList.Add("SlipMemo2");
			if(stockDetail1.SlipMemo3 != stockDetail2.SlipMemo3)resList.Add("SlipMemo3");
			if(stockDetail1.InsideMemo1 != stockDetail2.InsideMemo1)resList.Add("InsideMemo1");
			if(stockDetail1.InsideMemo2 != stockDetail2.InsideMemo2)resList.Add("InsideMemo2");
			if(stockDetail1.InsideMemo3 != stockDetail2.InsideMemo3)resList.Add("InsideMemo3");
			if(stockDetail1.SupplierCd != stockDetail2.SupplierCd)resList.Add("SupplierCd");
			if(stockDetail1.SupplierSnm != stockDetail2.SupplierSnm)resList.Add("SupplierSnm");
			if(stockDetail1.AddresseeCode != stockDetail2.AddresseeCode)resList.Add("AddresseeCode");
			if(stockDetail1.AddresseeName != stockDetail2.AddresseeName)resList.Add("AddresseeName");
			if(stockDetail1.DirectSendingCd != stockDetail2.DirectSendingCd)resList.Add("DirectSendingCd");
			if(stockDetail1.OrderNumber != stockDetail2.OrderNumber)resList.Add("OrderNumber");
			if(stockDetail1.WayToOrder != stockDetail2.WayToOrder)resList.Add("WayToOrder");
			if(stockDetail1.DeliGdsCmpltDueDate != stockDetail2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(stockDetail1.ExpectDeliveryDate != stockDetail2.ExpectDeliveryDate)resList.Add("ExpectDeliveryDate");
			if(stockDetail1.OrderDataCreateDiv != stockDetail2.OrderDataCreateDiv)resList.Add("OrderDataCreateDiv");
			if(stockDetail1.OrderDataCreateDate != stockDetail2.OrderDataCreateDate)resList.Add("OrderDataCreateDate");
			if(stockDetail1.OrderFormIssuedDiv != stockDetail2.OrderFormIssuedDiv)resList.Add("OrderFormIssuedDiv");
			if(stockDetail1.DtlRelationGuid != stockDetail2.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(stockDetail1.GoodsOfferDate != stockDetail2.GoodsOfferDate)resList.Add("GoodsOfferDate");
			if(stockDetail1.PriceStartDate != stockDetail2.PriceStartDate)resList.Add("PriceStartDate");
			if(stockDetail1.PriceOfferDate != stockDetail2.PriceOfferDate)resList.Add("PriceOfferDate");
			if(stockDetail1.EnterpriseName != stockDetail2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockDetail1.UpdEmployeeName != stockDetail2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockDetail1.BLGoodsName != stockDetail2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

        #region 仕入明細データ比較用のクラス
        /// <summary>
        /// 仕入明細データ比較クラス(仕入伝票番号(昇順)、仕入明細行番号(昇順))
        /// </summary>
        /// <remarks></remarks>
        public class StockDetailComparer : Comparer<StockDetail>
        {
            public override int Compare(StockDetail x, StockDetail y)
            {
                int result = x.SupplierSlipNo.CompareTo(y.SupplierSlipNo);
                if (result != 0) return result;

                result = x.StockRowNo.CompareTo(y.StockRowNo);
                return result;
            }
        }
        #endregion
    }
    #endregion

}
