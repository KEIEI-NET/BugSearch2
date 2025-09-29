using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
# if false
	/// public class name:   GoodsUnitData
	/// <summary>
	///                      商品連結データクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   商品連結データクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/06/12</br>
	/// <br>Genarated Date   :   2008/10/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class GoodsUnitData
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

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		/// <remarks>メーカマスタより取得</remarks>
		private string _makerName = "";

		/// <summary>メーカー略称</summary>
		/// <remarks>メーカマスタより取得</remarks>
		private string _makerShortName = "";

		/// <summary>メーカーカナ名称</summary>
		/// <remarks>メーカマスタより取得</remarks>
		private string _makerKanaName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品名称カナ</summary>
		/// <remarks>※半角カナ</remarks>
		private string _goodsNameKana = "";

		/// <summary>JANコード</summary>
		/// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
		private string _jan = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		/// <remarks>BL商品コードマスタより取得</remarks>
		private string _bLGoodsFullName = "";

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>商品大分類コード</summary>
		/// <remarks>BLグループマスタより取得</remarks>
		private Int32 _goodsLGroup;

		/// <summary>商品大分類名称</summary>
		/// <remarks>ユーザーガイドより取得</remarks>
		private string _goodsLGroupName = "";

		/// <summary>商品中分類コード</summary>
		/// <remarks>BLグループマスタより取得</remarks>
		private Int32 _goodsMGroup;

		/// <summary>商品中分類名称</summary>
		/// <remarks>商品中分類マスタより取得</remarks>
		private string _goodsMGroupName = "";

		/// <summary>BLグループコード</summary>
		/// <remarks>BLコードマスタより取得</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BLグループコード名称</summary>
		/// <remarks>BLグループマスタより取得</remarks>
		private string _bLGroupName = "";

		/// <summary>商品掛率ランク</summary>
		/// <remarks>層別</remarks>
		private string _goodsRateRank = "";

		/// <summary>課税区分</summary>
		/// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
		private Int32 _taxationDivCd;

		/// <summary>ハイフン無商品番号</summary>
		private string _goodsNoNoneHyphen = "";

		/// <summary>提供日付</summary>
		private DateTime _offerDate;

		/// <summary>商品属性</summary>
		private Int32 _goodsKindCode;

		/// <summary>商品備考１</summary>
		private string _goodsNote1 = "";

		/// <summary>商品備考２</summary>
		private string _goodsNote2 = "";

		/// <summary>商品規格・特記事項</summary>
		private string _goodsSpecialNote = "";

		/// <summary>自社分類コード</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>自社分類名称</summary>
		/// <remarks>ユーザーガイドより取得</remarks>
		private string _enterpriseGanreName = "";

		/// <summary>更新年月日</summary>
		private DateTime _updateDate;

		/// <summary>商品掛率グループコード</summary>
		/// <remarks>BLコードマスタより取得</remarks>
		private Int32 _goodsRateGrpCode;

		/// <summary>商品掛率グループコード名称</summary>
		/// <remarks>商品中分類マスタより取得</remarks>
		private string _goodsRateGrpName = "";

		/// <summary>販売区分コード</summary>
		/// <remarks>BLグループマスタより取得</remarks>
		private Int32 _salesCode;

		/// <summary>販売区分名称</summary>
		/// <remarks>ユーザーガイドより取得</remarks>
		private string _salesCodeName = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>商品管理情報マスタより取得</remarks>
		private Int32 _supplierCd;

		/// <summary>仕入先名1</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private string _supplierNm1 = "";

		/// <summary>仕入先名2</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private string _supplierNm2 = "";

		/// <summary>仕入先敬称</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private string _suppHonorificTitle = "";

		/// <summary>仕入先カナ</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private string _supplierKana = "";

		/// <summary>仕入先略称</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private string _supplierSnm = "";

		/// <summary>仕入単価端数処理コード</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private Int32 _stockUnPrcFrcProcCd;

		/// <summary>仕入消費税端数処理コード</summary>
		/// <remarks>仕入先マスタより取得</remarks>
		private Int32 _stockCnsTaxFrcProcCd;

		/// <summary>発注ロット</summary>
		/// <remarks>商品管理情報マスタより取得</remarks>
		private Int32 _supplierLot;

		/// <summary>シークレット区分</summary>
		/// <remarks>優良設定マスタより取得　0:通常　1:シークレット</remarks>
		private Int32 _secretCode;

		/// <summary>表示順位</summary>
		/// <remarks>優良設定マスタより取得</remarks>
		private Int32 _primePartsDisplayOrder;

		/// <summary>優良設定詳細コード１</summary>
		/// <remarks>優良設定マスタより取得　セレクトコード</remarks>
		private Int32 _prmSetDtlNo1;

		/// <summary>優良設定詳細名称１</summary>
		/// <remarks>優良設定マスタより取得</remarks>
		private string _prmSetDtlName1 = "";

		/// <summary>優良設定詳細コード２</summary>
		/// <remarks>優良設定マスタより取得　種別コード</remarks>
		private Int32 _prmSetDtlNo2;

		/// <summary>優良設定詳細名称２</summary>
		/// <remarks>優良設定マスタより取得</remarks>
		private string _prmSetDtlName2 = "";

		/// <summary>拠点コード</summary>
		/// <remarks>商品管理情報マスタ取得で使用</remarks>
		private string _sectionCode = "";

		/// <summary>価格情報</summary>
		/// <remarks>List<GoodsPrice></remarks>
		private List<GoodsPrice> _goodsPriceList;

		/// <summary>在庫情報</summary>
		/// <remarks>List<Stock></remarks>
		private List<Stock> _stockList;

		/// <summary>提供区分</summary>
		/// <remarks>0:ユーザー登録,1:提供純正編集,2:提供優良編集,3:提供純正,4:提供優良,5:TBO,7:オリジナル部品</remarks>
		private Int32 _offerKubun;

		/// <summary>商品種別(複数あり)</summary>
		/// <remarks>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</remarks>
		private Int32 _goodsKind;

		/// <summary>商品種別(複数なし)</summary>
		/// <remarks>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</remarks>
		private Int32 _goodsKindResolved;

		/// <summary>結合表示順位</summary>
		private Int32 _joinDispOrder;

		/// <summary>結合QTY</summary>
		private Double _joinQty;

		/// <summary>結合規格・特記事項</summary>
		private string _joinSpecialNote = "";

		/// <summary>セット表示順位</summary>
		private Int32 _setDispOrder;

		/// <summary>セットQTY</summary>
		private Double _setQty;

		/// <summary>セット規格・特記事項</summary>
		private string _setSpecialNote = "";

		/// <summary>部品QTY</summary>
		private Double _partsQty;

		/// <summary>提供データ区分</summary>
		/// <remarks>0:ユーザデータ,1:提供データ</remarks>
		private Int32 _offerDataDiv;

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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
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
		/// <value>メーカマスタより取得</value>
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

		/// public propaty name  :  MakerShortName
		/// <summary>メーカー略称プロパティ</summary>
		/// <value>メーカマスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerShortName
		{
			get{return _makerShortName;}
			set{_makerShortName = value;}
		}

		/// public propaty name  :  MakerKanaName
		/// <summary>メーカーカナ名称プロパティ</summary>
		/// <value>メーカマスタより取得</value>
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
		/// <value>※半角カナ</value>
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

		/// public propaty name  :  Jan
		/// <summary>JANコードプロパティ</summary>
		/// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   JANコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Jan
		{
			get{return _jan;}
			set{_jan = value;}
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
		/// <value>BL商品コードマスタより取得</value>
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

		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  GoodsLGroup
		/// <summary>商品大分類コードプロパティ</summary>
		/// <value>BLグループマスタより取得</value>
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
		/// <value>ユーザーガイドより取得</value>
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
		/// <value>BLグループマスタより取得</value>
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
		/// <value>商品中分類マスタより取得</value>
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
		/// <value>BLコードマスタより取得</value>
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
		/// <value>BLグループマスタより取得</value>
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

		/// public propaty name  :  GoodsRateRank
		/// <summary>商品掛率ランクプロパティ</summary>
		/// <value>層別</value>
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

		/// public propaty name  :  TaxationDivCd
		/// <summary>課税区分プロパティ</summary>
		/// <value>0:課税,1:非課税,2:課税（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  GoodsNoNoneHyphen
		/// <summary>ハイフン無商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ハイフン無商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoNoneHyphen
		{
			get{return _goodsNoNoneHyphen;}
			set{_goodsNoNoneHyphen = value;}
		}

		/// public propaty name  :  OfferDate
		/// <summary>提供日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime OfferDate
		{
			get{return _offerDate;}
			set{_offerDate = value;}
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

		/// public propaty name  :  GoodsNote1
		/// <summary>商品備考１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品備考１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNote1
		{
			get{return _goodsNote1;}
			set{_goodsNote1 = value;}
		}

		/// public propaty name  :  GoodsNote2
		/// <summary>商品備考２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品備考２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNote2
		{
			get{return _goodsNote2;}
			set{_goodsNote2 = value;}
		}

		/// public propaty name  :  GoodsSpecialNote
		/// <summary>商品規格・特記事項プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsSpecialNote
		{
			get{return _goodsSpecialNote;}
			set{_goodsSpecialNote = value;}
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
		/// <value>ユーザーガイドより取得</value>
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

		/// public propaty name  :  UpdateDate
		/// <summary>更新年月日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>更新年月日 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>更新年月日 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>更新年月日 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>更新年月日 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  GoodsRateGrpCode
		/// <summary>商品掛率グループコードプロパティ</summary>
		/// <value>BLコードマスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsRateGrpCode
		{
			get{return _goodsRateGrpCode;}
			set{_goodsRateGrpCode = value;}
		}

		/// public propaty name  :  GoodsRateGrpName
		/// <summary>商品掛率グループコード名称プロパティ</summary>
		/// <value>商品中分類マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率グループコード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsRateGrpName
		{
			get{return _goodsRateGrpName;}
			set{_goodsRateGrpName = value;}
		}

		/// public propaty name  :  SalesCode
		/// <summary>販売区分コードプロパティ</summary>
		/// <value>BLグループマスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCode
		{
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCodeName
		/// <summary>販売区分名称プロパティ</summary>
		/// <value>ユーザーガイドより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesCodeName
		{
			get{return _salesCodeName;}
			set{_salesCodeName = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>商品管理情報マスタより取得</value>
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

		/// public propaty name  :  SupplierNm1
		/// <summary>仕入先名1プロパティ</summary>
		/// <value>仕入先マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm1
		{
			get{return _supplierNm1;}
			set{_supplierNm1 = value;}
		}

		/// public propaty name  :  SupplierNm2
		/// <summary>仕入先名2プロパティ</summary>
		/// <value>仕入先マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先名2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierNm2
		{
			get{return _supplierNm2;}
			set{_supplierNm2 = value;}
		}

		/// public propaty name  :  SuppHonorificTitle
		/// <summary>仕入先敬称プロパティ</summary>
		/// <value>仕入先マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先敬称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SuppHonorificTitle
		{
			get{return _suppHonorificTitle;}
			set{_suppHonorificTitle = value;}
		}

		/// public propaty name  :  SupplierKana
		/// <summary>仕入先カナプロパティ</summary>
		/// <value>仕入先マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierKana
		{
			get{return _supplierKana;}
			set{_supplierKana = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>仕入先略称プロパティ</summary>
		/// <value>仕入先マスタより取得</value>
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

		/// public propaty name  :  StockUnPrcFrcProcCd
		/// <summary>仕入単価端数処理コードプロパティ</summary>
		/// <value>仕入先マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockUnPrcFrcProcCd
		{
			get{return _stockUnPrcFrcProcCd;}
			set{_stockUnPrcFrcProcCd = value;}
		}

		/// public propaty name  :  StockCnsTaxFrcProcCd
		/// <summary>仕入消費税端数処理コードプロパティ</summary>
		/// <value>仕入先マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入消費税端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCnsTaxFrcProcCd
		{
			get{return _stockCnsTaxFrcProcCd;}
			set{_stockCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  SupplierLot
		/// <summary>発注ロットプロパティ</summary>
		/// <value>商品管理情報マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注ロットプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierLot
		{
			get{return _supplierLot;}
			set{_supplierLot = value;}
		}

		/// public propaty name  :  SecretCode
		/// <summary>シークレット区分プロパティ</summary>
		/// <value>優良設定マスタより取得　0:通常　1:シークレット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   シークレット区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SecretCode
		{
			get{return _secretCode;}
			set{_secretCode = value;}
		}

		/// public propaty name  :  PrimePartsDisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// <value>優良設定マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrimePartsDisplayOrder
		{
			get{return _primePartsDisplayOrder;}
			set{_primePartsDisplayOrder = value;}
		}

		/// public propaty name  :  PrmSetDtlNo1
		/// <summary>優良設定詳細コード１プロパティ</summary>
		/// <value>優良設定マスタより取得　セレクトコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細コード１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrmSetDtlNo1
		{
			get{return _prmSetDtlNo1;}
			set{_prmSetDtlNo1 = value;}
		}

		/// public propaty name  :  PrmSetDtlName1
		/// <summary>優良設定詳細名称１プロパティ</summary>
		/// <value>優良設定マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細名称１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrmSetDtlName1
		{
			get{return _prmSetDtlName1;}
			set{_prmSetDtlName1 = value;}
		}

		/// public propaty name  :  PrmSetDtlNo2
		/// <summary>優良設定詳細コード２プロパティ</summary>
		/// <value>優良設定マスタより取得　種別コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細コード２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrmSetDtlNo2
		{
			get{return _prmSetDtlNo2;}
			set{_prmSetDtlNo2 = value;}
		}

		/// public propaty name  :  PrmSetDtlName2
		/// <summary>優良設定詳細名称２プロパティ</summary>
		/// <value>優良設定マスタより取得</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良設定詳細名称２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrmSetDtlName2
		{
			get{return _prmSetDtlName2;}
			set{_prmSetDtlName2 = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>商品管理情報マスタ取得で使用</value>
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

		/// public propaty name  :  GoodsPriceList
		/// <summary>価格情報プロパティ</summary>
		/// <value>List<GoodsPrice></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格情報プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<GoodsPrice> GoodsPriceList
		{
			get{return _goodsPriceList;}
			set{_goodsPriceList = value;}
		}

		/// public propaty name  :  StockList
		/// <summary>在庫情報プロパティ</summary>
		/// <value>List<Stock></value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫情報プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<Stock> StockList
		{
			get{return _stockList;}
			set{_stockList = value;}
		}

		/// public propaty name  :  OfferKubun
		/// <summary>提供区分プロパティ</summary>
		/// <value>0:ユーザー登録,1:提供純正編集,2:提供優良編集,3:提供純正,4:提供優良,5:TBO,7:オリジナル部品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferKubun
		{
			get{return _offerKubun;}
			set{_offerKubun = value;}
		}

		/// public propaty name  :  GoodsKind
		/// <summary>商品種別(複数あり)プロパティ</summary>
		/// <value>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品種別(複数あり)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsKind
		{
			get{return _goodsKind;}
			set{_goodsKind = value;}
		}

		/// public propaty name  :  GoodsKindResolved
		/// <summary>商品種別(複数なし)プロパティ</summary>
		/// <value>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品種別(複数なし)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsKindResolved
		{
			get{return _goodsKindResolved;}
			set{_goodsKindResolved = value;}
		}

		/// public propaty name  :  JoinDispOrder
		/// <summary>結合表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinDispOrder
		{
			get{return _joinDispOrder;}
			set{_joinDispOrder = value;}
		}

		/// public propaty name  :  JoinQty
		/// <summary>結合QTYプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合QTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double JoinQty
		{
			get{return _joinQty;}
			set{_joinQty = value;}
		}

		/// public propaty name  :  JoinSpecialNote
		/// <summary>結合規格・特記事項プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinSpecialNote
		{
			get{return _joinSpecialNote;}
			set{_joinSpecialNote = value;}
		}

		/// public propaty name  :  SetDispOrder
		/// <summary>セット表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SetDispOrder
		{
			get{return _setDispOrder;}
			set{_setDispOrder = value;}
		}

		/// public propaty name  :  SetQty
		/// <summary>セットQTYプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セットQTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SetQty
		{
			get{return _setQty;}
			set{_setQty = value;}
		}

		/// public propaty name  :  SetSpecialNote
		/// <summary>セット規格・特記事項プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SetSpecialNote
		{
			get{return _setSpecialNote;}
			set{_setSpecialNote = value;}
		}

		/// public propaty name  :  PartsQty
		/// <summary>部品QTYプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品QTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PartsQty
		{
			get{return _partsQty;}
			set{_partsQty = value;}
		}

		/// public propaty name  :  OfferDataDiv
		/// <summary>提供データ区分プロパティ</summary>
		/// <value>0:ユーザデータ,1:提供データ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提供データ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OfferDataDiv
		{
			get{return _offerDataDiv;}
			set{_offerDataDiv = value;}
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
		/// 商品連結データクラスコンストラクタ
		/// </summary>
		/// <returns>GoodsUnitDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUnitDataクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsUnitData()
		{
		}

		/// <summary>
		/// 商品連結データクラスコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="makerName">メーカー名称(メーカマスタより取得)</param>
		/// <param name="makerShortName">メーカー略称(メーカマスタより取得)</param>
		/// <param name="makerKanaName">メーカーカナ名称(メーカマスタより取得)</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsNameKana">商品名称カナ(※半角カナ)</param>
		/// <param name="jan">JANコード(標準タイプ13桁または短縮タイプ8桁のJANコード)</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）(BL商品コードマスタより取得)</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="goodsLGroup">商品大分類コード(BLグループマスタより取得)</param>
		/// <param name="goodsLGroupName">商品大分類名称(ユーザーガイドより取得)</param>
		/// <param name="goodsMGroup">商品中分類コード(BLグループマスタより取得)</param>
		/// <param name="goodsMGroupName">商品中分類名称(商品中分類マスタより取得)</param>
		/// <param name="bLGroupCode">BLグループコード(BLコードマスタより取得)</param>
		/// <param name="bLGroupName">BLグループコード名称(BLグループマスタより取得)</param>
		/// <param name="goodsRateRank">商品掛率ランク(層別)</param>
		/// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
		/// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
		/// <param name="offerDate">提供日付</param>
		/// <param name="goodsKindCode">商品属性</param>
		/// <param name="goodsNote1">商品備考１</param>
		/// <param name="goodsNote2">商品備考２</param>
		/// <param name="goodsSpecialNote">商品規格・特記事項</param>
		/// <param name="enterpriseGanreCode">自社分類コード</param>
		/// <param name="enterpriseGanreName">自社分類名称(ユーザーガイドより取得)</param>
		/// <param name="updateDate">更新年月日</param>
		/// <param name="goodsRateGrpCode">商品掛率グループコード(BLコードマスタより取得)</param>
		/// <param name="goodsRateGrpName">商品掛率グループコード名称(商品中分類マスタより取得)</param>
		/// <param name="salesCode">販売区分コード(BLグループマスタより取得)</param>
		/// <param name="salesCodeName">販売区分名称(ユーザーガイドより取得)</param>
		/// <param name="supplierCd">仕入先コード(商品管理情報マスタより取得)</param>
		/// <param name="supplierNm1">仕入先名1(仕入先マスタより取得)</param>
		/// <param name="supplierNm2">仕入先名2(仕入先マスタより取得)</param>
		/// <param name="suppHonorificTitle">仕入先敬称(仕入先マスタより取得)</param>
		/// <param name="supplierKana">仕入先カナ(仕入先マスタより取得)</param>
		/// <param name="supplierSnm">仕入先略称(仕入先マスタより取得)</param>
		/// <param name="stockUnPrcFrcProcCd">仕入単価端数処理コード(仕入先マスタより取得)</param>
		/// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード(仕入先マスタより取得)</param>
		/// <param name="supplierLot">発注ロット(商品管理情報マスタより取得)</param>
		/// <param name="secretCode">シークレット区分(優良設定マスタより取得　0:通常　1:シークレット)</param>
		/// <param name="primePartsDisplayOrder">表示順位(優良設定マスタより取得)</param>
		/// <param name="prmSetDtlNo1">優良設定詳細コード１(優良設定マスタより取得　セレクトコード)</param>
		/// <param name="prmSetDtlName1">優良設定詳細名称１(優良設定マスタより取得)</param>
		/// <param name="prmSetDtlNo2">優良設定詳細コード２(優良設定マスタより取得　種別コード)</param>
		/// <param name="prmSetDtlName2">優良設定詳細名称２(優良設定マスタより取得)</param>
		/// <param name="sectionCode">拠点コード(商品管理情報マスタ取得で使用)</param>
		/// <param name="goodsPriceList">価格情報(List<GoodsPrice>)</param>
		/// <param name="stockList">在庫情報(List<Stock>)</param>
		/// <param name="offerKubun">提供区分(0:ユーザー登録,1:提供純正編集,2:提供優良編集,3:提供純正,4:提供優良,5:TBO,7:オリジナル部品)</param>
		/// <param name="goodsKind">商品種別(複数あり)(1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0)</param>
		/// <param name="goodsKindResolved">商品種別(複数なし)(1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0)</param>
		/// <param name="joinDispOrder">結合表示順位</param>
		/// <param name="joinQty">結合QTY</param>
		/// <param name="joinSpecialNote">結合規格・特記事項</param>
		/// <param name="setDispOrder">セット表示順位</param>
		/// <param name="setQty">セットQTY</param>
		/// <param name="setSpecialNote">セット規格・特記事項</param>
		/// <param name="partsQty">部品QTY</param>
		/// <param name="offerDataDiv">提供データ区分(0:ユーザデータ,1:提供データ)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <returns>GoodsUnitDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUnitDataクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsUnitData(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 goodsMakerCd,string makerName,string makerShortName,string makerKanaName,string goodsNo,string goodsName,string goodsNameKana,string jan,Int32 bLGoodsCode,string bLGoodsFullName,Int32 displayOrder,Int32 goodsLGroup,string goodsLGroupName,Int32 goodsMGroup,string goodsMGroupName,Int32 bLGroupCode,string bLGroupName,string goodsRateRank,Int32 taxationDivCd,string goodsNoNoneHyphen,DateTime offerDate,Int32 goodsKindCode,string goodsNote1,string goodsNote2,string goodsSpecialNote,Int32 enterpriseGanreCode,string enterpriseGanreName,DateTime updateDate,Int32 goodsRateGrpCode,string goodsRateGrpName,Int32 salesCode,string salesCodeName,Int32 supplierCd,string supplierNm1,string supplierNm2,string suppHonorificTitle,string supplierKana,string supplierSnm,Int32 stockUnPrcFrcProcCd,Int32 stockCnsTaxFrcProcCd,Int32 supplierLot,Int32 secretCode,Int32 primePartsDisplayOrder,Int32 prmSetDtlNo1,string prmSetDtlName1,Int32 prmSetDtlNo2,string prmSetDtlName2,string sectionCode,List<GoodsPrice> goodsPriceList,List<Stock> stockList,Int32 offerKubun,Int32 goodsKind,Int32 goodsKindResolved,Int32 joinDispOrder,Double joinQty,string joinSpecialNote,Int32 setDispOrder,Double setQty,string setSpecialNote,Double partsQty,Int32 offerDataDiv,string enterpriseName,string updEmployeeName,string bLGoodsName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._makerShortName = makerShortName;
			this._makerKanaName = makerKanaName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._goodsNameKana = goodsNameKana;
			this._jan = jan;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._displayOrder = displayOrder;
			this._goodsLGroup = goodsLGroup;
			this._goodsLGroupName = goodsLGroupName;
			this._goodsMGroup = goodsMGroup;
			this._goodsMGroupName = goodsMGroupName;
			this._bLGroupCode = bLGroupCode;
			this._bLGroupName = bLGroupName;
			this._goodsRateRank = goodsRateRank;
			this._taxationDivCd = taxationDivCd;
			this._goodsNoNoneHyphen = goodsNoNoneHyphen;
			this._offerDate = offerDate;
			this._goodsKindCode = goodsKindCode;
			this._goodsNote1 = goodsNote1;
			this._goodsNote2 = goodsNote2;
			this._goodsSpecialNote = goodsSpecialNote;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this.UpdateDate = updateDate;
			this._goodsRateGrpCode = goodsRateGrpCode;
			this._goodsRateGrpName = goodsRateGrpName;
			this._salesCode = salesCode;
			this._salesCodeName = salesCodeName;
			this._supplierCd = supplierCd;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._suppHonorificTitle = suppHonorificTitle;
			this._supplierKana = supplierKana;
			this._supplierSnm = supplierSnm;
			this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
			this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
			this._supplierLot = supplierLot;
			this._secretCode = secretCode;
			this._primePartsDisplayOrder = primePartsDisplayOrder;
			this._prmSetDtlNo1 = prmSetDtlNo1;
			this._prmSetDtlName1 = prmSetDtlName1;
			this._prmSetDtlNo2 = prmSetDtlNo2;
			this._prmSetDtlName2 = prmSetDtlName2;
			this._sectionCode = sectionCode;
			this._goodsPriceList = goodsPriceList;
			this._stockList = stockList;
			this._offerKubun = offerKubun;
			this._goodsKind = goodsKind;
			this._goodsKindResolved = goodsKindResolved;
			this._joinDispOrder = joinDispOrder;
			this._joinQty = joinQty;
			this._joinSpecialNote = joinSpecialNote;
			this._setDispOrder = setDispOrder;
			this._setQty = setQty;
			this._setSpecialNote = setSpecialNote;
			this._partsQty = partsQty;
			this._offerDataDiv = offerDataDiv;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// 商品連結データクラス複製処理
		/// </summary>
		/// <returns>GoodsUnitDataクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいGoodsUnitDataクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsUnitData Clone()
		{
			return new GoodsUnitData(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._goodsMakerCd,this._makerName,this._makerShortName,this._makerKanaName,this._goodsNo,this._goodsName,this._goodsNameKana,this._jan,this._bLGoodsCode,this._bLGoodsFullName,this._displayOrder,this._goodsLGroup,this._goodsLGroupName,this._goodsMGroup,this._goodsMGroupName,this._bLGroupCode,this._bLGroupName,this._goodsRateRank,this._taxationDivCd,this._goodsNoNoneHyphen,this._offerDate,this._goodsKindCode,this._goodsNote1,this._goodsNote2,this._goodsSpecialNote,this._enterpriseGanreCode,this._enterpriseGanreName,this._updateDate,this._goodsRateGrpCode,this._goodsRateGrpName,this._salesCode,this._salesCodeName,this._supplierCd,this._supplierNm1,this._supplierNm2,this._suppHonorificTitle,this._supplierKana,this._supplierSnm,this._stockUnPrcFrcProcCd,this._stockCnsTaxFrcProcCd,this._supplierLot,this._secretCode,this._primePartsDisplayOrder,this._prmSetDtlNo1,this._prmSetDtlName1,this._prmSetDtlNo2,this._prmSetDtlName2,this._sectionCode,this._goodsPriceList,this._stockList,this._offerKubun,this._goodsKind,this._goodsKindResolved,this._joinDispOrder,this._joinQty,this._joinSpecialNote,this._setDispOrder,this._setQty,this._setSpecialNote,this._partsQty,this._offerDataDiv,this._enterpriseName,this._updEmployeeName,this._bLGoodsName);
		}

		/// <summary>
		/// 商品連結データクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のGoodsUnitDataクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(GoodsUnitData target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.MakerShortName == target.MakerShortName)
				 && (this.MakerKanaName == target.MakerKanaName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.Jan == target.Jan)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.GoodsLGroup == target.GoodsLGroup)
				 && (this.GoodsLGroupName == target.GoodsLGroupName)
				 && (this.GoodsMGroup == target.GoodsMGroup)
				 && (this.GoodsMGroupName == target.GoodsMGroupName)
				 && (this.BLGroupCode == target.BLGroupCode)
				 && (this.BLGroupName == target.BLGroupName)
				 && (this.GoodsRateRank == target.GoodsRateRank)
				 && (this.TaxationDivCd == target.TaxationDivCd)
				 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
				 && (this.OfferDate == target.OfferDate)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsNote1 == target.GoodsNote1)
				 && (this.GoodsNote2 == target.GoodsNote2)
				 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
				 && (this.GoodsRateGrpName == target.GoodsRateGrpName)
				 && (this.SalesCode == target.SalesCode)
				 && (this.SalesCodeName == target.SalesCodeName)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SuppHonorificTitle == target.SuppHonorificTitle)
				 && (this.SupplierKana == target.SupplierKana)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
				 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
				 && (this.SupplierLot == target.SupplierLot)
				 && (this.SecretCode == target.SecretCode)
				 && (this.PrimePartsDisplayOrder == target.PrimePartsDisplayOrder)
				 && (this.PrmSetDtlNo1 == target.PrmSetDtlNo1)
				 && (this.PrmSetDtlName1 == target.PrmSetDtlName1)
				 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
				 && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
				 && (this.SectionCode == target.SectionCode)
                 //&& (this.GoodsPriceList == target.GoodsPriceList)
                 //&& (this.StockList == target.StockList)
				 && (this.OfferKubun == target.OfferKubun)
				 && (this.GoodsKind == target.GoodsKind)
				 && (this.GoodsKindResolved == target.GoodsKindResolved)
				 && (this.JoinDispOrder == target.JoinDispOrder)
				 && (this.JoinQty == target.JoinQty)
				 && (this.JoinSpecialNote == target.JoinSpecialNote)
				 && (this.SetDispOrder == target.SetDispOrder)
				 && (this.SetQty == target.SetQty)
				 && (this.SetSpecialNote == target.SetSpecialNote)
				 && (this.PartsQty == target.PartsQty)
				 && (this.OfferDataDiv == target.OfferDataDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.BLGoodsName == target.BLGoodsName)
                 && (EqualsGoodsPriceList( this.GoodsPriceList, target.GoodsPriceList )));
		}

		/// <summary>
		/// 商品連結データクラス比較処理
		/// </summary>
		/// <param name="goodsUnitData1">
		///                    比較するGoodsUnitDataクラスのインスタンス
		/// </param>
		/// <param name="goodsUnitData2">比較するGoodsUnitDataクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
		{
            return ((goodsUnitData1.CreateDateTime == goodsUnitData2.CreateDateTime)
                 && (goodsUnitData1.UpdateDateTime == goodsUnitData2.UpdateDateTime)
                 && (goodsUnitData1.EnterpriseCode == goodsUnitData2.EnterpriseCode)
                 && (goodsUnitData1.FileHeaderGuid == goodsUnitData2.FileHeaderGuid)
                 && (goodsUnitData1.UpdEmployeeCode == goodsUnitData2.UpdEmployeeCode)
                 && (goodsUnitData1.UpdAssemblyId1 == goodsUnitData2.UpdAssemblyId1)
                 && (goodsUnitData1.UpdAssemblyId2 == goodsUnitData2.UpdAssemblyId2)
                 && (goodsUnitData1.LogicalDeleteCode == goodsUnitData2.LogicalDeleteCode)
                 && (goodsUnitData1.GoodsMakerCd == goodsUnitData2.GoodsMakerCd)
                 && (goodsUnitData1.MakerName == goodsUnitData2.MakerName)
                 && (goodsUnitData1.MakerShortName == goodsUnitData2.MakerShortName)
                 && (goodsUnitData1.MakerKanaName == goodsUnitData2.MakerKanaName)
                 && (goodsUnitData1.GoodsNo == goodsUnitData2.GoodsNo)
                 && (goodsUnitData1.GoodsName == goodsUnitData2.GoodsName)
                 && (goodsUnitData1.GoodsNameKana == goodsUnitData2.GoodsNameKana)
                 && (goodsUnitData1.Jan == goodsUnitData2.Jan)
                 && (goodsUnitData1.BLGoodsCode == goodsUnitData2.BLGoodsCode)
                 && (goodsUnitData1.BLGoodsFullName == goodsUnitData2.BLGoodsFullName)
                 && (goodsUnitData1.DisplayOrder == goodsUnitData2.DisplayOrder)
                 && (goodsUnitData1.GoodsLGroup == goodsUnitData2.GoodsLGroup)
                 && (goodsUnitData1.GoodsLGroupName == goodsUnitData2.GoodsLGroupName)
                 && (goodsUnitData1.GoodsMGroup == goodsUnitData2.GoodsMGroup)
                 && (goodsUnitData1.GoodsMGroupName == goodsUnitData2.GoodsMGroupName)
                 && (goodsUnitData1.BLGroupCode == goodsUnitData2.BLGroupCode)
                 && (goodsUnitData1.BLGroupName == goodsUnitData2.BLGroupName)
                 && (goodsUnitData1.GoodsRateRank == goodsUnitData2.GoodsRateRank)
                 && (goodsUnitData1.TaxationDivCd == goodsUnitData2.TaxationDivCd)
                 && (goodsUnitData1.GoodsNoNoneHyphen == goodsUnitData2.GoodsNoNoneHyphen)
                 && (goodsUnitData1.OfferDate == goodsUnitData2.OfferDate)
                 && (goodsUnitData1.GoodsKindCode == goodsUnitData2.GoodsKindCode)
                 && (goodsUnitData1.GoodsNote1 == goodsUnitData2.GoodsNote1)
                 && (goodsUnitData1.GoodsNote2 == goodsUnitData2.GoodsNote2)
                 && (goodsUnitData1.GoodsSpecialNote == goodsUnitData2.GoodsSpecialNote)
                 && (goodsUnitData1.EnterpriseGanreCode == goodsUnitData2.EnterpriseGanreCode)
                 && (goodsUnitData1.EnterpriseGanreName == goodsUnitData2.EnterpriseGanreName)
                 && (goodsUnitData1.UpdateDate == goodsUnitData2.UpdateDate)
                 && (goodsUnitData1.GoodsRateGrpCode == goodsUnitData2.GoodsRateGrpCode)
                 && (goodsUnitData1.GoodsRateGrpName == goodsUnitData2.GoodsRateGrpName)
                 && (goodsUnitData1.SalesCode == goodsUnitData2.SalesCode)
                 && (goodsUnitData1.SalesCodeName == goodsUnitData2.SalesCodeName)
                 && (goodsUnitData1.SupplierCd == goodsUnitData2.SupplierCd)
                 && (goodsUnitData1.SupplierNm1 == goodsUnitData2.SupplierNm1)
                 && (goodsUnitData1.SupplierNm2 == goodsUnitData2.SupplierNm2)
                 && (goodsUnitData1.SuppHonorificTitle == goodsUnitData2.SuppHonorificTitle)
                 && (goodsUnitData1.SupplierKana == goodsUnitData2.SupplierKana)
                 && (goodsUnitData1.SupplierSnm == goodsUnitData2.SupplierSnm)
                 && (goodsUnitData1.StockUnPrcFrcProcCd == goodsUnitData2.StockUnPrcFrcProcCd)
                 && (goodsUnitData1.StockCnsTaxFrcProcCd == goodsUnitData2.StockCnsTaxFrcProcCd)
                 && (goodsUnitData1.SupplierLot == goodsUnitData2.SupplierLot)
                 && (goodsUnitData1.SecretCode == goodsUnitData2.SecretCode)
                 && (goodsUnitData1.PrimePartsDisplayOrder == goodsUnitData2.PrimePartsDisplayOrder)
                 && (goodsUnitData1.PrmSetDtlNo1 == goodsUnitData2.PrmSetDtlNo1)
                 && (goodsUnitData1.PrmSetDtlName1 == goodsUnitData2.PrmSetDtlName1)
                 && (goodsUnitData1.PrmSetDtlNo2 == goodsUnitData2.PrmSetDtlNo2)
                 && (goodsUnitData1.PrmSetDtlName2 == goodsUnitData2.PrmSetDtlName2)
                 && (goodsUnitData1.SectionCode == goodsUnitData2.SectionCode)
                 //&& (goodsUnitData1.GoodsPriceList == goodsUnitData2.GoodsPriceList)
                 //&& (goodsUnitData1.StockList == goodsUnitData2.StockList)
                 && (goodsUnitData1.OfferKubun == goodsUnitData2.OfferKubun)
                 && (goodsUnitData1.GoodsKind == goodsUnitData2.GoodsKind)
                 && (goodsUnitData1.GoodsKindResolved == goodsUnitData2.GoodsKindResolved)
                 && (goodsUnitData1.JoinDispOrder == goodsUnitData2.JoinDispOrder)
                 && (goodsUnitData1.JoinQty == goodsUnitData2.JoinQty)
                 && (goodsUnitData1.JoinSpecialNote == goodsUnitData2.JoinSpecialNote)
                 && (goodsUnitData1.SetDispOrder == goodsUnitData2.SetDispOrder)
                 && (goodsUnitData1.SetQty == goodsUnitData2.SetQty)
                 && (goodsUnitData1.SetSpecialNote == goodsUnitData2.SetSpecialNote)
                 && (goodsUnitData1.PartsQty == goodsUnitData2.PartsQty)
                 && (goodsUnitData1.OfferDataDiv == goodsUnitData2.OfferDataDiv)
                 && (goodsUnitData1.EnterpriseName == goodsUnitData2.EnterpriseName)
                 && (goodsUnitData1.UpdEmployeeName == goodsUnitData2.UpdEmployeeName)
                 && (goodsUnitData1.BLGoodsName == goodsUnitData2.BLGoodsName)
                 && (EqualsGoodsPriceList( goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList )));
		}
		/// <summary>
		/// 商品連結データクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のGoodsUnitDataクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(GoodsUnitData target)
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
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.MakerShortName != target.MakerShortName)resList.Add("MakerShortName");
			if(this.MakerKanaName != target.MakerKanaName)resList.Add("MakerKanaName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.Jan != target.Jan)resList.Add("Jan");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.GoodsLGroup != target.GoodsLGroup)resList.Add("GoodsLGroup");
			if(this.GoodsLGroupName != target.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(this.GoodsMGroup != target.GoodsMGroup)resList.Add("GoodsMGroup");
			if(this.GoodsMGroupName != target.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(this.BLGroupCode != target.BLGroupCode)resList.Add("BLGroupCode");
			if(this.BLGroupName != target.BLGroupName)resList.Add("BLGroupName");
			if(this.GoodsRateRank != target.GoodsRateRank)resList.Add("GoodsRateRank");
			if(this.TaxationDivCd != target.TaxationDivCd)resList.Add("TaxationDivCd");
			if(this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen)resList.Add("GoodsNoNoneHyphen");
			if(this.OfferDate != target.OfferDate)resList.Add("OfferDate");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsNote1 != target.GoodsNote1)resList.Add("GoodsNote1");
			if(this.GoodsNote2 != target.GoodsNote2)resList.Add("GoodsNote2");
			if(this.GoodsSpecialNote != target.GoodsSpecialNote)resList.Add("GoodsSpecialNote");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.GoodsRateGrpCode != target.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(this.GoodsRateGrpName != target.GoodsRateGrpName)resList.Add("GoodsRateGrpName");
			if(this.SalesCode != target.SalesCode)resList.Add("SalesCode");
			if(this.SalesCodeName != target.SalesCodeName)resList.Add("SalesCodeName");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SuppHonorificTitle != target.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(this.SupplierKana != target.SupplierKana)resList.Add("SupplierKana");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(this.SupplierLot != target.SupplierLot)resList.Add("SupplierLot");
			if(this.SecretCode != target.SecretCode)resList.Add("SecretCode");
			if(this.PrimePartsDisplayOrder != target.PrimePartsDisplayOrder)resList.Add("PrimePartsDisplayOrder");
			if(this.PrmSetDtlNo1 != target.PrmSetDtlNo1)resList.Add("PrmSetDtlNo1");
			if(this.PrmSetDtlName1 != target.PrmSetDtlName1)resList.Add("PrmSetDtlName1");
			if(this.PrmSetDtlNo2 != target.PrmSetDtlNo2)resList.Add("PrmSetDtlNo2");
			if(this.PrmSetDtlName2 != target.PrmSetDtlName2)resList.Add("PrmSetDtlName2");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
            //if(this.GoodsPriceList != target.GoodsPriceList)resList.Add("GoodsPriceList");
            //if(this.StockList != target.StockList)resList.Add("StockList");
			if(this.OfferKubun != target.OfferKubun)resList.Add("OfferKubun");
			if(this.GoodsKind != target.GoodsKind)resList.Add("GoodsKind");
			if(this.GoodsKindResolved != target.GoodsKindResolved)resList.Add("GoodsKindResolved");
			if(this.JoinDispOrder != target.JoinDispOrder)resList.Add("JoinDispOrder");
			if(this.JoinQty != target.JoinQty)resList.Add("JoinQty");
			if(this.JoinSpecialNote != target.JoinSpecialNote)resList.Add("JoinSpecialNote");
			if(this.SetDispOrder != target.SetDispOrder)resList.Add("SetDispOrder");
			if(this.SetQty != target.SetQty)resList.Add("SetQty");
			if(this.SetSpecialNote != target.SetSpecialNote)resList.Add("SetSpecialNote");
			if(this.PartsQty != target.PartsQty)resList.Add("PartsQty");
			if(this.OfferDataDiv != target.OfferDataDiv)resList.Add("OfferDataDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            if ( !EqualsGoodsPriceList( this.GoodsPriceList, target.GoodsPriceList ) ) resList.Add( "GoodsPriceList" );

			return resList;
		}

		/// <summary>
		/// 商品連結データクラス比較処理
		/// </summary>
		/// <param name="goodsUnitData1">比較するGoodsUnitDataクラスのインスタンス</param>
		/// <param name="goodsUnitData2">比較するGoodsUnitDataクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
		{
			ArrayList resList = new ArrayList();
			if(goodsUnitData1.CreateDateTime != goodsUnitData2.CreateDateTime)resList.Add("CreateDateTime");
			if(goodsUnitData1.UpdateDateTime != goodsUnitData2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(goodsUnitData1.EnterpriseCode != goodsUnitData2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(goodsUnitData1.FileHeaderGuid != goodsUnitData2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(goodsUnitData1.UpdEmployeeCode != goodsUnitData2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(goodsUnitData1.UpdAssemblyId1 != goodsUnitData2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(goodsUnitData1.UpdAssemblyId2 != goodsUnitData2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(goodsUnitData1.LogicalDeleteCode != goodsUnitData2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(goodsUnitData1.GoodsMakerCd != goodsUnitData2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(goodsUnitData1.MakerName != goodsUnitData2.MakerName)resList.Add("MakerName");
			if(goodsUnitData1.MakerShortName != goodsUnitData2.MakerShortName)resList.Add("MakerShortName");
			if(goodsUnitData1.MakerKanaName != goodsUnitData2.MakerKanaName)resList.Add("MakerKanaName");
			if(goodsUnitData1.GoodsNo != goodsUnitData2.GoodsNo)resList.Add("GoodsNo");
			if(goodsUnitData1.GoodsName != goodsUnitData2.GoodsName)resList.Add("GoodsName");
			if(goodsUnitData1.GoodsNameKana != goodsUnitData2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(goodsUnitData1.Jan != goodsUnitData2.Jan)resList.Add("Jan");
			if(goodsUnitData1.BLGoodsCode != goodsUnitData2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(goodsUnitData1.BLGoodsFullName != goodsUnitData2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(goodsUnitData1.DisplayOrder != goodsUnitData2.DisplayOrder)resList.Add("DisplayOrder");
			if(goodsUnitData1.GoodsLGroup != goodsUnitData2.GoodsLGroup)resList.Add("GoodsLGroup");
			if(goodsUnitData1.GoodsLGroupName != goodsUnitData2.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(goodsUnitData1.GoodsMGroup != goodsUnitData2.GoodsMGroup)resList.Add("GoodsMGroup");
			if(goodsUnitData1.GoodsMGroupName != goodsUnitData2.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(goodsUnitData1.BLGroupCode != goodsUnitData2.BLGroupCode)resList.Add("BLGroupCode");
			if(goodsUnitData1.BLGroupName != goodsUnitData2.BLGroupName)resList.Add("BLGroupName");
			if(goodsUnitData1.GoodsRateRank != goodsUnitData2.GoodsRateRank)resList.Add("GoodsRateRank");
			if(goodsUnitData1.TaxationDivCd != goodsUnitData2.TaxationDivCd)resList.Add("TaxationDivCd");
			if(goodsUnitData1.GoodsNoNoneHyphen != goodsUnitData2.GoodsNoNoneHyphen)resList.Add("GoodsNoNoneHyphen");
			if(goodsUnitData1.OfferDate != goodsUnitData2.OfferDate)resList.Add("OfferDate");
			if(goodsUnitData1.GoodsKindCode != goodsUnitData2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(goodsUnitData1.GoodsNote1 != goodsUnitData2.GoodsNote1)resList.Add("GoodsNote1");
			if(goodsUnitData1.GoodsNote2 != goodsUnitData2.GoodsNote2)resList.Add("GoodsNote2");
			if(goodsUnitData1.GoodsSpecialNote != goodsUnitData2.GoodsSpecialNote)resList.Add("GoodsSpecialNote");
			if(goodsUnitData1.EnterpriseGanreCode != goodsUnitData2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(goodsUnitData1.EnterpriseGanreName != goodsUnitData2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(goodsUnitData1.UpdateDate != goodsUnitData2.UpdateDate)resList.Add("UpdateDate");
			if(goodsUnitData1.GoodsRateGrpCode != goodsUnitData2.GoodsRateGrpCode)resList.Add("GoodsRateGrpCode");
			if(goodsUnitData1.GoodsRateGrpName != goodsUnitData2.GoodsRateGrpName)resList.Add("GoodsRateGrpName");
			if(goodsUnitData1.SalesCode != goodsUnitData2.SalesCode)resList.Add("SalesCode");
			if(goodsUnitData1.SalesCodeName != goodsUnitData2.SalesCodeName)resList.Add("SalesCodeName");
			if(goodsUnitData1.SupplierCd != goodsUnitData2.SupplierCd)resList.Add("SupplierCd");
			if(goodsUnitData1.SupplierNm1 != goodsUnitData2.SupplierNm1)resList.Add("SupplierNm1");
			if(goodsUnitData1.SupplierNm2 != goodsUnitData2.SupplierNm2)resList.Add("SupplierNm2");
			if(goodsUnitData1.SuppHonorificTitle != goodsUnitData2.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(goodsUnitData1.SupplierKana != goodsUnitData2.SupplierKana)resList.Add("SupplierKana");
			if(goodsUnitData1.SupplierSnm != goodsUnitData2.SupplierSnm)resList.Add("SupplierSnm");
			if(goodsUnitData1.StockUnPrcFrcProcCd != goodsUnitData2.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(goodsUnitData1.StockCnsTaxFrcProcCd != goodsUnitData2.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(goodsUnitData1.SupplierLot != goodsUnitData2.SupplierLot)resList.Add("SupplierLot");
			if(goodsUnitData1.SecretCode != goodsUnitData2.SecretCode)resList.Add("SecretCode");
			if(goodsUnitData1.PrimePartsDisplayOrder != goodsUnitData2.PrimePartsDisplayOrder)resList.Add("PrimePartsDisplayOrder");
			if(goodsUnitData1.PrmSetDtlNo1 != goodsUnitData2.PrmSetDtlNo1)resList.Add("PrmSetDtlNo1");
			if(goodsUnitData1.PrmSetDtlName1 != goodsUnitData2.PrmSetDtlName1)resList.Add("PrmSetDtlName1");
			if(goodsUnitData1.PrmSetDtlNo2 != goodsUnitData2.PrmSetDtlNo2)resList.Add("PrmSetDtlNo2");
			if(goodsUnitData1.PrmSetDtlName2 != goodsUnitData2.PrmSetDtlName2)resList.Add("PrmSetDtlName2");
			if(goodsUnitData1.SectionCode != goodsUnitData2.SectionCode)resList.Add("SectionCode");
            //if(goodsUnitData1.GoodsPriceList != goodsUnitData2.GoodsPriceList)resList.Add("GoodsPriceList");
            //if(goodsUnitData1.StockList != goodsUnitData2.StockList)resList.Add("StockList");
			if(goodsUnitData1.OfferKubun != goodsUnitData2.OfferKubun)resList.Add("OfferKubun");
			if(goodsUnitData1.GoodsKind != goodsUnitData2.GoodsKind)resList.Add("GoodsKind");
			if(goodsUnitData1.GoodsKindResolved != goodsUnitData2.GoodsKindResolved)resList.Add("GoodsKindResolved");
			if(goodsUnitData1.JoinDispOrder != goodsUnitData2.JoinDispOrder)resList.Add("JoinDispOrder");
			if(goodsUnitData1.JoinQty != goodsUnitData2.JoinQty)resList.Add("JoinQty");
			if(goodsUnitData1.JoinSpecialNote != goodsUnitData2.JoinSpecialNote)resList.Add("JoinSpecialNote");
			if(goodsUnitData1.SetDispOrder != goodsUnitData2.SetDispOrder)resList.Add("SetDispOrder");
			if(goodsUnitData1.SetQty != goodsUnitData2.SetQty)resList.Add("SetQty");
			if(goodsUnitData1.SetSpecialNote != goodsUnitData2.SetSpecialNote)resList.Add("SetSpecialNote");
			if(goodsUnitData1.PartsQty != goodsUnitData2.PartsQty)resList.Add("PartsQty");
			if(goodsUnitData1.OfferDataDiv != goodsUnitData2.OfferDataDiv)resList.Add("OfferDataDiv");
			if(goodsUnitData1.EnterpriseName != goodsUnitData2.EnterpriseName)resList.Add("EnterpriseName");
			if(goodsUnitData1.UpdEmployeeName != goodsUnitData2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(goodsUnitData1.BLGoodsName != goodsUnitData2.BLGoodsName)resList.Add("BLGoodsName");
            if ( !EqualsGoodsPriceList( goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList ) ) resList.Add( "GoodsPriceList" );

			return resList;
		}
        /// <summary>
        /// 価格情報比較処理
        /// </summary>
        /// <param name="hashtable"></param>
        /// <param name="hashtable_2"></param>
        /// <returns></returns>
        private static bool EqualsGoodsPriceList(List<GoodsPrice> list, List<GoodsPrice> list2)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
            //if ((list != null) && (list.Count != 0) && (list2 != null) && (list2.Count != 0))
            //{
            //    list.Sort();
            //    foreach (GoodsPrice goodsPrice in list)
            //    {
            //        // Findで品番・メーカー・価格開始日が同じ価格情報を取得する
            //        GoodsPrice goodsPrice2 = list2.Find(
            //            delegate (GoodsPrice data)
            //            {
            //                return ((goodsPrice.GoodsNo == data.GoodsNo) &&
            //                    (goodsPrice.GoodsMakerCd == data.GoodsMakerCd) &&
            //                    (goodsPrice.PriceStartDate == data.PriceStartDate));
            //            }
            //            );

            //        // 取得した価格情報を比較
            //        if (goodsPrice2 == null) break;
            //        if (!goodsPrice.Equals(goodsPrice2)) return false;
            //    }
            //}
            //return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // 両方nullならOK
            if ( list == null && list2 == null ) return true;
            // 片方nullならNG
            if ( list != null && list2 == null ) return false;
            if ( list == null && list2 != null ) return false;
            // 要素数違いはNG
            if ( list.Count != list2.Count ) return false;

            // listベースで該当するlist2のレコードを探す
            foreach ( GoodsPrice price in list )
            {
                GoodsPrice price2 = list2.Find(
                    delegate( GoodsPrice target )
                    {
                        return ((price.GoodsNo == target.GoodsNo) &&
                                (price.GoodsMakerCd == target.GoodsMakerCd) &&
                                (price.PriceStartDate == target.PriceStartDate));
                    } 
                    );
                if ( price2 == null ) return false;

                // 価格クラス比較
                ArrayList priceComparelist = price.Compare( price2 );
                int differCount = priceComparelist.Count;
                if ( priceComparelist.Contains( "CreateDateTime" ) ) differCount--;
                if ( priceComparelist.Contains( "UpdateDateTime" ) ) differCount--;
                if ( priceComparelist.Contains( "UpdateDate" ) ) differCount--;
                if ( differCount > 0 ) return false;
            }

            // 要素数が同じなのでlistベースで全て該当あれば逆の走査をしなくてもOK
            return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
        }
	}
# endif

    /// public class name:   GoodsUnitData
    /// <summary>
    ///                      商品連結データクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品連結データクラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/06/12</br>
    /// <br>Genarated Date   :   2008/11/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// <br>Update Note      :   2009/10/19 呉元嘯</br>
    /// <br>                     PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>                     保守依頼②を追加</br>
    /// <br></br>
    /// <br>Update Note      :   2009/11/24　21024 佐々木 健</br>
    /// <br>                     検索BLコードを追加(MANTIS[0014674])</br>
    /// <br></br>
    /// <br>Update Note      :   2010/03/02　21024 佐々木 健</br>
    /// <br>                     変換BLコードの追加</br>
    /// <br></br>
    /// <br>Update Note      :   2010/06/10　22018 鈴木 正臣</br>
    /// <br>                     自由検索部品固有番号の追加</br>
    /// <br></br>
    /// <br>Update Note      :   2014/01/15 宮本 利明</br>
    /// <br>                     結合元情報の追加</br>
    /// <br>Update Note      :   2014/02/10 高陽</br>
    /// <br>                 :   Redmine#41976 商品マスタⅡの追加</br>
    /// <br></br>
    /// <br>Update Note      :   2015/01/07 30744 湯上 千加子</br>
    /// <br>                     メーカー希望小売価格対応</br>
    /// <br></br>
    /// <br>Update Note      :   2015/02/25 30744 湯上 千加子</br>
    /// <br>                     SCM高速化 C向け種別対応</br>
    /// <br></br>
    /// <br>Update Note      :   2015/03/18 30744 湯上 千加子</br>
    /// <br>                     SCM高速化メーカー希望小売価格対応 2015/01/07対応分除外</br>
    /// <br></br>
    /// </remarks>
    public class GoodsUnitData
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

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>メーカマスタより取得</remarks>
        private string _makerName = "";

        /// <summary>メーカー略称</summary>
        /// <remarks>メーカマスタより取得</remarks>
        private string _makerShortName = "";

        /// <summary>メーカーカナ名称</summary>
        /// <remarks>メーカマスタより取得</remarks>
        private string _makerKanaName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        /// <remarks>※半角カナ</remarks>
        private string _goodsNameKana = "";

        /// <summary>JANコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        /// <remarks>BL商品コードマスタより取得</remarks>
        private string _bLGoodsFullName = "";

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>商品大分類コード</summary>
        /// <remarks>BLグループマスタより取得</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品大分類名称</summary>
        /// <remarks>ユーザーガイドより取得</remarks>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類コード</summary>
        /// <remarks>BLグループマスタより取得</remarks>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類名称</summary>
        /// <remarks>商品中分類マスタより取得</remarks>
        private string _goodsMGroupName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>BLコードマスタより取得</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコード名称</summary>
        /// <remarks>BLグループマスタより取得</remarks>
        private string _bLGroupName = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>提供日付</summary>
        private DateTime _offerDate;

        /// <summary>商品属性</summary>
        private Int32 _goodsKindCode;

        /// <summary>商品備考１</summary>
        private string _goodsNote1 = "";

        /// <summary>商品備考２</summary>
        private string _goodsNote2 = "";

        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpecialNote = "";

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>自社分類名称</summary>
        /// <remarks>ユーザーガイドより取得</remarks>
        private string _enterpriseGanreName = "";

        /// <summary>更新年月日</summary>
        private DateTime _updateDate;

        /// <summary>商品掛率グループコード</summary>
        /// <remarks>BLコードマスタより取得</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率グループコード名称</summary>
        /// <remarks>商品中分類マスタより取得</remarks>
        private string _goodsRateGrpName = "";

        /// <summary>販売区分コード</summary>
        /// <remarks>BLグループマスタより取得</remarks>
        private Int32 _salesCode;

        /// <summary>販売区分名称</summary>
        /// <remarks>ユーザーガイドより取得</remarks>
        private string _salesCodeName = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>商品管理情報マスタより取得</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private string _supplierNm1 = "";

        /// <summary>仕入先名2</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private string _supplierNm2 = "";

        /// <summary>仕入先敬称</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private string _suppHonorificTitle = "";

        /// <summary>仕入先カナ</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private string _supplierKana = "";

        /// <summary>仕入先略称</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private string _supplierSnm = "";

        /// <summary>仕入単価端数処理コード</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>仕入消費税端数処理コード</summary>
        /// <remarks>仕入先マスタより取得</remarks>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>発注ロット</summary>
        /// <remarks>商品管理情報マスタより取得</remarks>
        private Int32 _supplierLot;

        /// <summary>シークレット区分</summary>
        /// <remarks>優良設定マスタより取得　0:通常　1:シークレット</remarks>
        private Int32 _secretCode;

        /// <summary>表示順位</summary>
        /// <remarks>優良設定マスタより取得</remarks>
        private Int32 _primePartsDisplayOrder;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>優良設定マスタより取得　セレクトコード</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>優良設定詳細名称１</summary>
        /// <remarks>優良設定マスタより取得</remarks>
        private string _prmSetDtlName1 = "";

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>優良設定マスタより取得　種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>優良設定詳細名称２</summary>
        /// <remarks>優良設定マスタより取得</remarks>
        private string _prmSetDtlName2 = "";

        /// <summary>拠点コード</summary>
        /// <remarks>商品管理情報マスタ取得で使用</remarks>
        private string _sectionCode = "";

        /// <summary>価格情報</summary>
        /// <remarks></remarks>
        private List<GoodsPrice> _goodsPriceList;

        /// <summary>在庫情報</summary>
        /// <remarks></remarks>
        private List<Stock> _stockList;

        /// <summary>提供区分</summary>
        /// <remarks>0:ユーザー登録,1:提供純正編集,2:提供優良編集,3:提供純正,4:提供優良,5:TBO,7:オリジナル部品</remarks>
        private Int32 _offerKubun;

        /// <summary>商品種別(複数あり)</summary>
        /// <remarks>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</remarks>
        private Int32 _goodsKind;

        /// <summary>商品種別(複数なし)</summary>
        /// <remarks>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</remarks>
        private Int32 _goodsKindResolved;

        /// <summary>結合表示順位</summary>
        private Int32 _joinDispOrder;

        /// <summary>結合QTY</summary>
        private Double _joinQty;

        /// <summary>結合規格・特記事項</summary>
        private string _joinSpecialNote = "";

        /// <summary>セット表示順位</summary>
        private Int32 _setDispOrder;

        /// <summary>セットQTY</summary>
        private Double _setQty;

        /// <summary>セット規格・特記事項</summary>
        private string _setSpecialNote = "";

        /// <summary>部品QTY</summary>
        private Double _partsQty;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:ユーザデータ,1:提供データ</remarks>
        private Int32 _offerDataDiv;

        /// <summary>選択倉庫コード</summary>
        /// <remarks>ＵＩ選択された在庫の倉庫コード（結果）</remarks>
        private string _selectedWarehouseCode = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        //-------ADD 2009/10/19--------->>>>>
        /// <summary>定価(選択)</summary>
        private Double _selectedListPrice;

        /// <summary>標準価格選択有効区分</summary>
        private Int32 _selectedListPriceDiv;

        /// <summary>印刷用品番</summary>
        private string _prtGoodsNo;

        /// <summary>印刷用メーカーコード</summary>
        private Int32 _prtMakerCode;

        /// <summary>印刷用メーカー名称</summary>
        private string _prtMakerName;

        /// <summary>印刷用品番有効区分</summary>
        private Int32 _selectedGoodsNoDiv;
        //-------ADD 2009/10/19---------<<<<<

        // 2009/11/24 Add >>>
        /// <summary>検索BLコード</summary>
        private Int32 _searchBLCode;
        // 2009/11/24 Add <<<

        // 2010/03/02 Add >>>
        /// <summary>変換BLコード</summary>
        /// <remarks>変換後BLコード(SCMで使用)</remarks>
        private Int32 _bLGoodsCodeChange;
        // 2010/03/02 Add <<<

        // --- ADD m.suzuki 2010/06/10 ---------->>>>>
        /// <summary>自由検索部品固有番号</summary>
        private string _freSrchPrtPropNo = "";
        // --- ADD m.suzuki 2010/06/10 ----------<<<<<

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>結合元商品メーカーコード</summary>
        private Int32 _joinSourceMakerCode;
        /// <summary>結合元商品番号</summary>
        private string _joinSrcPartsNoWithH = "";
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        // -------- ADD START 2014/02/10 高陽 -------->>>>>
        /// <summary>商品マスタ表示用オプション</summary>
        private Int32 _optKonmanGoodsMstCtl;

        /// <summary>規格</summary>
        private string _standard = "";

        /// <summary>荷姿</summary>
        private string _packing = "";

        /// <summary>ＰＯＳNo.</summary>
        private string _posNo = "";

        /// <summary>メーカー品番</summary>
        private string _makerGoodsNo = "";

        /// <summary>作成日時Ⅱ</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTimeA;

        /// <summary>更新日時Ⅱ</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTimeA;

        /// <summary>GUIDⅡ</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuidA;
        // -------- ADD END 2014/02/10 高陽 --------<<<<<

        // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        //// ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
        ///// <summary>メーカー希望小売価格情報</summary>
        ///// <remarks></remarks>
        //private List<GoodsPrice> _mkrSuggestRtPricList;
        //// ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
        // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        // ADD 2015/02/25 SCM高速化 C向け種別対応 -------------------------->>>>>
        /// <summary>優良設定詳細名称２(工場向け)</summary>
        private string _prmSetDtlName2ForFac = "";
        /// <summary>優良設定詳細名称２(カーオーナー向け)</summary>
        private string _prmSetDtlName2ForCOw = "";
        // ADD 2015/02/25 SCM高速化 C向け種別対応 --------------------------<<<<<

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _createDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _createDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _createDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _createDateTime ); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDateTime ); }
            set { }
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
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDateTime ); }
            set { }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// <value>メーカマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// <value>メーカマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  MakerKanaName
        /// <summary>メーカーカナ名称プロパティ</summary>
        /// <value>メーカマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerKanaName
        {
            get { return _makerKanaName; }
            set { _makerKanaName = value; }
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
            get { return _goodsNo; }
            set { _goodsNo = value; }
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
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// <value>※半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  Jan
        /// <summary>JANコードプロパティ</summary>
        /// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JANコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
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
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// <value>BL商品コードマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>BLグループマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名称プロパティ</summary>
        /// <value>ユーザーガイドより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>BLグループマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// <value>商品中分類マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>BLコードマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// <value>BLグループマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
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
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>商品備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _goodsNote1; }
            set { _goodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>商品備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _goodsNote2; }
            set { _goodsNote2 = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
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
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>自社分類名称プロパティ</summary>
        /// <value>ユーザーガイドより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateDateJpFormal
        /// <summary>更新年月日 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  UpdateDateJpInFormal
        /// <summary>更新年月日 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdFormal
        /// <summary>更新年月日 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  UpdateDateAdInFormal
        /// <summary>更新年月日 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDate ); }
            set { }
        }

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>BLコードマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpName
        /// <summary>商品掛率グループコード名称プロパティ</summary>
        /// <value>商品中分類マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateGrpName
        {
            get { return _goodsRateGrpName; }
            set { _goodsRateGrpName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// <value>BLグループマスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCodeName
        /// <summary>販売区分名称プロパティ</summary>
        /// <value>ユーザーガイドより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>商品管理情報マスタより取得</value>
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
        /// <value>仕入先マスタより取得</value>
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
        /// <value>仕入先マスタより取得</value>
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

        /// public propaty name  :  SuppHonorificTitle
        /// <summary>仕入先敬称プロパティ</summary>
        /// <value>仕入先マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>仕入先カナプロパティ</summary>
        /// <value>仕入先マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// <value>仕入先マスタより取得</value>
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

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>仕入単価端数処理コードプロパティ</summary>
        /// <value>仕入先マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>仕入消費税端数処理コードプロパティ</summary>
        /// <value>仕入先マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>発注ロットプロパティ</summary>
        /// <value>商品管理情報マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注ロットプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  SecretCode
        /// <summary>シークレット区分プロパティ</summary>
        /// <value>優良設定マスタより取得　0:通常　1:シークレット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シークレット区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecretCode
        {
            get { return _secretCode; }
            set { _secretCode = value; }
        }

        /// public propaty name  :  PrimePartsDisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// <value>優良設定マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrimePartsDisplayOrder
        {
            get { return _primePartsDisplayOrder; }
            set { _primePartsDisplayOrder = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>優良設定マスタより取得　セレクトコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlName1
        /// <summary>優良設定詳細名称１プロパティ</summary>
        /// <value>優良設定マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName1
        {
            get { return _prmSetDtlName1; }
            set { _prmSetDtlName1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>優良設定マスタより取得　種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>優良設定詳細名称２プロパティ</summary>
        /// <value>優良設定マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>商品管理情報マスタ取得で使用</value>
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

        /// public propaty name  :  GoodsPriceList
        /// <summary>価格情報プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<GoodsPrice> GoodsPriceList
        {
            get { return _goodsPriceList; }
            set { _goodsPriceList = value; }
        }

        /// public propaty name  :  StockList
        /// <summary>在庫情報プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Stock> StockList
        {
            get { return _stockList; }
            set { _stockList = value; }
        }

        /// public propaty name  :  OfferKubun
        /// <summary>提供区分プロパティ</summary>
        /// <value>0:ユーザー登録,1:提供純正編集,2:提供優良編集,3:提供純正,4:提供優良,5:TBO,7:オリジナル部品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferKubun
        {
            get { return _offerKubun; }
            set { _offerKubun = value; }
        }

        /// public propaty name  :  GoodsKind
        /// <summary>商品種別(複数あり)プロパティ</summary>
        /// <value>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品種別(複数あり)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKind
        {
            get { return _goodsKind; }
            set { _goodsKind = value; }
        }

        /// public propaty name  :  GoodsKindResolved
        /// <summary>商品種別(複数なし)プロパティ</summary>
        /// <value>1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品種別(複数なし)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindResolved
        {
            get { return _goodsKindResolved; }
            set { _goodsKindResolved = value; }
        }

        /// public propaty name  :  JoinDispOrder
        /// <summary>結合表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>結合QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>結合規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
        }

        /// public propaty name  :  SetDispOrder
        /// <summary>セット表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetDispOrder
        {
            get { return _setDispOrder; }
            set { _setDispOrder = value; }
        }

        /// public propaty name  :  SetQty
        /// <summary>セットQTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セットQTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SetQty
        {
            get { return _setQty; }
            set { _setQty = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>セット規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  PartsQty
        /// <summary>部品QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分プロパティ</summary>
        /// <value>0:ユーザデータ,1:提供データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// public propaty name  :  SelectedWarehouseCode
        /// <summary>選択倉庫コードプロパティ</summary>
        /// <value>ＵＩ選択された在庫の倉庫コード（結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectedWarehouseCode
        {
            get { return _selectedWarehouseCode; }
            set { _selectedWarehouseCode = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        //-------------ADD 2009/10/19--------->>>>>
        /// public propaty name  :  SelectedListPrice
        /// <summary>定価(選択)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価(選択)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SelectedListPrice
        {
            get { return _selectedListPrice; }
            set { _selectedListPrice = value; }
        }

        /// public propaty name  :  SelectedListPriceDiv
        /// <summary>標準価格選択有効区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択有効区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelectedListPriceDiv
        {
            get { return _selectedListPriceDiv; }
            set { _selectedListPriceDiv = value; }
        }

        /// public propaty name  :  PrtGoodsNo
        /// <summary>印刷用品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtGoodsNo
        {
            get { return _prtGoodsNo; }
            set { _prtGoodsNo = value; }
        }

        /// public propaty name  :  PrtMakerCode
        /// <summary>印刷用メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtMakerCode
        {
            get { return _prtMakerCode; }
            set { _prtMakerCode = value; }
        }

        /// public propaty name  :  PrtMakerName
        /// <summary>印刷用メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtMakerName
        {
            get { return _prtMakerName; }
            set { _prtMakerName = value; }
        }

        /// public propaty name  :  SelectedGoodsNoDiv
        /// <summary>印刷用品番有効区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用品番有効区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelectedGoodsNoDiv
        {
            get { return _selectedGoodsNoDiv; }
            set { _selectedGoodsNoDiv = value; }
        }
        //-------------ADD 2009/10/19---------<<<<<

        // 2009/11/24 Add >>>
        /// public propaty name  :  SearchBLCode
        /// <summary>検索BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  検索BLコードプロパティ</br>
        /// </remarks>
        public Int32 SearchBLCode
        {
            get { return _searchBLCode; }
            set { _searchBLCode = value; }
        }
        // 2009/11/24 Add <<<

        // 2010/03/02 Add >>>
        /// public propaty name  :  BLGoodsCodeChange
        /// <summary>変換BLコードプロパティ</summary>
        /// <value>変換後BLコード(SCMで使用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeChange
        {
            get { return _bLGoodsCodeChange; }
            set { _bLGoodsCodeChange = value; }
        }
        // 2010/03/02 Add <<<

        // --- ADD m.suzuki 2010/06/10 ---------->>>>>
        /// public propaty name  :  FreSrchPrtPropNo
        /// <summary>自由検索部品固有番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索部品固有番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FreSrchPrtPropNo
        {
            get { return _freSrchPrtPropNo; }
            set { _freSrchPrtPropNo = value; }
        }
        // --- ADD m.suzuki 2010/06/10 ----------<<<<<

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>結合元商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }
        /// public propaty name  :  JoinSrcPartsNoWithH
        /// <summary>結合元商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSrcPartsNoWithH
        {
            get { return _joinSrcPartsNoWithH; }
            set { _joinSrcPartsNoWithH = value; }
        }
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        // -------- ADD START 2014/02/10 高陽 -------->>>>>
        /// public propaty name  :  OptKonmanGoodsMstCtl
        /// <summary>商品マスタ表示用オプションプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品マスタ表示用オプションロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OptKonmanGoodsMstCtl
        {
            get { return _optKonmanGoodsMstCtl; }
            set { _optKonmanGoodsMstCtl = value; }
        }

        /// public propaty name  :  Standard
        /// <summary>規格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   規格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Standard
        {
            get { return _standard; }
            set { _standard = value; }
        }

        /// public propaty name  :  Packing
        /// <summary>荷姿プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   荷姿プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Packing
        {
            get { return _packing; }
            set { _packing = value; }
        }

        /// public propaty name  :  PosNo
        /// <summary>ＰＯＳNo.プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＰＯＳNo.プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PosNo
        {
            get { return _posNo; }
            set { _posNo = value; }
        }

        /// public propaty name  :  MakerGoodsNo
        /// <summary>メーカー品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerGoodsNo
        {
            get { return _makerGoodsNo; }
            set { _makerGoodsNo = value; }
        }

        /// public propaty name  :  CreateDateTimeA
        /// <summary>作成日時Ⅱプロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時Ⅱプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTimeA
        {
            get { return _createDateTimeA; }
            set { _createDateTimeA = value; }
        }

        /// public propaty name  :  UpdateDateTimeA
        /// <summary>更新日時Ⅱプロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時Ⅱプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTimeA
        {
            get { return _updateDateTimeA; }
            set { _updateDateTimeA = value; }
        }

        /// public propaty name  :  FileHeaderGuidA
        /// <summary>GUIDⅡプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDⅡプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuidA
        {
            get { return _fileHeaderGuidA; }
            set { _fileHeaderGuidA = value; }
        }
        // -------- ADD END 2014/02/10 高陽 --------<<<<<

        // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        //// ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
        ///// public propaty name  :  MkrSuggestRtPricList
        ///// <summary>メーカー希望小売価格情報プロパティ</summary>
        ///// <value></value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   メーカー希望小売価格情報プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public List<GoodsPrice> MkrSuggestRtPricList
        //{
        //    get { return _mkrSuggestRtPricList; }
        //    set { _mkrSuggestRtPricList = value; }
        //}
        //// ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
        // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        // ADD 2015/02/25 SCM高速化 C向け種別対応 -------------------------->>>>>
        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>優良設定詳細名称２(工場向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２(工場向け)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForCOw
        /// <summary>優良設定詳細名称２(カーオーナー向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２(カーオーナー向け)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/25 SCM高速化 C向け種別対応 --------------------------<<<<<


        /// <summary>
        /// 商品連結データクラスコンストラクタ
        /// </summary>
        /// <returns>GoodsUnitDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsUnitData()
        {
        }

        /// <summary>
        /// 商品連結データクラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称(メーカマスタより取得)</param>
        /// <param name="makerShortName">メーカー略称(メーカマスタより取得)</param>
        /// <param name="makerKanaName">メーカーカナ名称(メーカマスタより取得)</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsNameKana">商品名称カナ(※半角カナ)</param>
        /// <param name="jan">JANコード(標準タイプ13桁または短縮タイプ8桁のJANコード)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）(BL商品コードマスタより取得)</param>
        /// <param name="displayOrder">表示順位</param>
        /// <param name="goodsLGroup">商品大分類コード(BLグループマスタより取得)</param>
        /// <param name="goodsLGroupName">商品大分類名称(ユーザーガイドより取得)</param>
        /// <param name="goodsMGroup">商品中分類コード(BLグループマスタより取得)</param>
        /// <param name="goodsMGroupName">商品中分類名称(商品中分類マスタより取得)</param>
        /// <param name="bLGroupCode">BLグループコード(BLコードマスタより取得)</param>
        /// <param name="bLGroupName">BLグループコード名称(BLグループマスタより取得)</param>
        /// <param name="goodsRateRank">商品掛率ランク(層別)</param>
        /// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="offerDate">提供日付</param>
        /// <param name="goodsKindCode">商品属性</param>
        /// <param name="goodsNote1">商品備考１</param>
        /// <param name="goodsNote2">商品備考２</param>
        /// <param name="goodsSpecialNote">商品規格・特記事項</param>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        /// <param name="enterpriseGanreName">自社分類名称(ユーザーガイドより取得)</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード(BLコードマスタより取得)</param>
        /// <param name="goodsRateGrpName">商品掛率グループコード名称(商品中分類マスタより取得)</param>
        /// <param name="salesCode">販売区分コード(BLグループマスタより取得)</param>
        /// <param name="salesCodeName">販売区分名称(ユーザーガイドより取得)</param>
        /// <param name="supplierCd">仕入先コード(商品管理情報マスタより取得)</param>
        /// <param name="supplierNm1">仕入先名1(仕入先マスタより取得)</param>
        /// <param name="supplierNm2">仕入先名2(仕入先マスタより取得)</param>
        /// <param name="suppHonorificTitle">仕入先敬称(仕入先マスタより取得)</param>
        /// <param name="supplierKana">仕入先カナ(仕入先マスタより取得)</param>
        /// <param name="supplierSnm">仕入先略称(仕入先マスタより取得)</param>
        /// <param name="stockUnPrcFrcProcCd">仕入単価端数処理コード(仕入先マスタより取得)</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード(仕入先マスタより取得)</param>
        /// <param name="supplierLot">発注ロット(商品管理情報マスタより取得)</param>
        /// <param name="secretCode">シークレット区分(優良設定マスタより取得　0:通常　1:シークレット)</param>
        /// <param name="primePartsDisplayOrder">表示順位(優良設定マスタより取得)</param>
        /// <param name="prmSetDtlNo1">優良設定詳細コード１(優良設定マスタより取得　セレクトコード)</param>
        /// <param name="prmSetDtlName1">優良設定詳細名称１(優良設定マスタより取得)</param>
        /// <param name="prmSetDtlNo2">優良設定詳細コード２(優良設定マスタより取得　種別コード)</param>
        /// <param name="prmSetDtlName2">優良設定詳細名称２(優良設定マスタより取得)</param>
        /// <param name="sectionCode">拠点コード(商品管理情報マスタ取得で使用)</param>
        /// <param name="goodsPriceList">価格情報(List<GoodsPrice>)</param>
        /// <param name="stockList">在庫情報(List<Stock>)</param>
        /// <param name="offerKubun">提供区分(0:ユーザー登録,1:提供純正編集,2:提供優良編集,3:提供純正,4:提供優良,5:TBO,7:オリジナル部品)</param>
        /// <param name="goodsKind">商品種別(複数あり)(1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0)</param>
        /// <param name="goodsKindResolved">商品種別(複数なし)(1:親 2:結合子 4:セット子 8:代替 16:代替互換　※商品登録時は常に0)</param>
        /// <param name="joinDispOrder">結合表示順位</param>
        /// <param name="joinQty">結合QTY</param>
        /// <param name="joinSpecialNote">結合規格・特記事項</param>
        /// <param name="setDispOrder">セット表示順位</param>
        /// <param name="setQty">セットQTY</param>
        /// <param name="setSpecialNote">セット規格・特記事項</param>
        /// <param name="partsQty">部品QTY</param>
        /// <param name="offerDataDiv">提供データ区分(0:ユーザデータ,1:提供データ)</param>
        /// <param name="selectedWarehouseCode">選択倉庫コード(ＵＩ選択された在庫の倉庫コード（結果）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="selectedListPrice">定価(選択)</param>
        /// <param name="selectedListPriceDiv">標準価格選択有効区分</param>
        /// <param name="prtGoodsNo">印刷用品番</param>
        /// <param name="prtMakerCode">印刷用メーカーコード</param>
        /// <param name="prtMakerName">印刷用メーカー名称</param>
        /// <param name="bLGoodsCodeChange">変換BLコード(変換後BLコード(SCMで使用))</param>
        /// <param name="optKonmanGoodsMstCtl">商品マスタ表示用オプション</param>
        /// <param name="standard">規格</param>
        /// <param name="packing">荷姿</param>
        /// <param name="posNo">ＰＯＳNo.</param>
        /// <param name="makerGoodsNo">メーカー品番</param>
        /// <param name="createDateTimeA">作成日時Ⅱ</param>
        /// <param name="updateDateTimeA">更新日時Ⅱ</param>
        /// <param name="fileHeaderGuidA">GUIDⅡ</param>
        /// <returns>GoodsUnitDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 呉元嘯 保守依頼②を追加</br>
        /// <br>Update Note      :   2009/11/24 21024 佐々木 健 検索BLコードを追加</br>
        /// <br>Update Note      :   2010/06/10 22018 鈴木 正臣 自由検索部品固有番号を追加</br>
        /// <br>Update Note      :   2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        // UPD 2015/02/25 SCM高速化 C向け種別対応 -------------------------->>>>>
        #region 旧ソース
        // --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        //// --- UPD m.suzuki 2010/06/10 ---------->>>>>
        ////// 2010/03/02 >>>
        //////// 2009/11/24 >>>
        ////////public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv)
        //////public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv,Int32 searchBLCode)
        //////// 2009/11/24 <<<
        ////public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange)
        ////// 2010/03/02 <<<
        //public GoodsUnitData( DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo )
        //// --- UPD m.suzuki 2010/06/10 ----------<<<<<
        // UPD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH
        //                    )
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH
        //                    , List<GoodsPrice> mkrSuggestRtPricList 
        //                    )
        // UPD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
        // -------- DEL START 2014/02/10 高陽 -------->>>>>
        ////// --- UPD m.suzuki 2010/06/10 ----------<<<<<
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH
        //                    )
        //// --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        // -------- DEL END 2014/02/10 高陽 --------<<<<<
        //// -------- ADD START 2014/02/10 高陽 -------->>>>>
        //public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
        //                    , Int32 joinSourceMakerCode
        //                    , string joinSrcPartsNoWithH, Int32 optKonmanGoodsMstCtl, string standard, string packing, string posNo, string makerGoodsNo, DateTime createDateTimeA, DateTime updateDateTimeA, Guid fileHeaderGuidA
        //                    )
        //// -------- ADD END 2014/02/10 高陽 --------<<<<<
        #endregion
        public GoodsUnitData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, string bLGoodsFullName, Int32 displayOrder, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, DateTime offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, string enterpriseGanreName, DateTime updateDate, Int32 goodsRateGrpCode, string goodsRateGrpName, Int32 salesCode, string salesCodeName, Int32 supplierCd, string supplierNm1, string supplierNm2, string suppHonorificTitle, string supplierKana, string supplierSnm, Int32 stockUnPrcFrcProcCd, Int32 stockCnsTaxFrcProcCd, Int32 supplierLot, Int32 secretCode, Int32 primePartsDisplayOrder, Int32 prmSetDtlNo1, string prmSetDtlName1, Int32 prmSetDtlNo2, string prmSetDtlName2, string sectionCode, List<GoodsPrice> goodsPriceList, List<Stock> stockList, Int32 offerKubun, Int32 goodsKind, Int32 goodsKindResolved, Int32 joinDispOrder, Double joinQty, string joinSpecialNote, Int32 setDispOrder, Double setQty, string setSpecialNote, Double partsQty, Int32 offerDataDiv, string selectedWarehouseCode, string enterpriseName, string updEmployeeName, string bLGoodsName, Double selectedListPrice, Int32 selectedListPriceDiv, string prtGoodsNo, Int32 prtMakerCode, string prtMakerName, Int32 selectedGoodsNoDiv, Int32 searchBLCode, Int32 bLGoodsCodeChange, string freSrchPrtPropNo
                            , Int32 joinSourceMakerCode
                            , string joinSrcPartsNoWithH, Int32 optKonmanGoodsMstCtl, string standard, string packing, string posNo, string makerGoodsNo, DateTime createDateTimeA, DateTime updateDateTimeA, Guid fileHeaderGuidA
                            //, List<GoodsPrice> mkrSuggestRtPricList  // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応
                            , string prmSetDtlName2ForFac
                            , string prmSetDtlName2ForCOw
                            )
        // UPD 2015/02/25 SCM高速化 C向け種別対応 --------------------------<<<<<
        // --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._makerShortName = makerShortName;
            this._makerKanaName = makerKanaName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._jan = jan;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._displayOrder = displayOrder;
            this._goodsLGroup = goodsLGroup;
            this._goodsLGroupName = goodsLGroupName;
            this._goodsMGroup = goodsMGroup;
            this._goodsMGroupName = goodsMGroupName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._goodsRateRank = goodsRateRank;
            this._taxationDivCd = taxationDivCd;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._offerDate = offerDate;
            this._goodsKindCode = goodsKindCode;
            this._goodsNote1 = goodsNote1;
            this._goodsNote2 = goodsNote2;
            this._goodsSpecialNote = goodsSpecialNote;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._enterpriseGanreName = enterpriseGanreName;
            this.UpdateDate = updateDate;
            this._goodsRateGrpCode = goodsRateGrpCode;
            this._goodsRateGrpName = goodsRateGrpName;
            this._salesCode = salesCode;
            this._salesCodeName = salesCodeName;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._suppHonorificTitle = suppHonorificTitle;
            this._supplierKana = supplierKana;
            this._supplierSnm = supplierSnm;
            this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
            this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
            this._supplierLot = supplierLot;
            this._secretCode = secretCode;
            this._primePartsDisplayOrder = primePartsDisplayOrder;
            this._prmSetDtlNo1 = prmSetDtlNo1;
            this._prmSetDtlName1 = prmSetDtlName1;
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._prmSetDtlName2 = prmSetDtlName2;
            this._sectionCode = sectionCode;
            this._goodsPriceList = goodsPriceList;
            this._stockList = stockList;
            this._offerKubun = offerKubun;
            this._goodsKind = goodsKind;
            this._goodsKindResolved = goodsKindResolved;
            this._joinDispOrder = joinDispOrder;
            this._joinQty = joinQty;
            this._joinSpecialNote = joinSpecialNote;
            this._setDispOrder = setDispOrder;
            this._setQty = setQty;
            this._setSpecialNote = setSpecialNote;
            this._partsQty = partsQty;
            this._offerDataDiv = offerDataDiv;
            this._selectedWarehouseCode = selectedWarehouseCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            //----------------ADD 2009/10/19---------------->>>>>
            this._selectedListPrice = selectedListPrice;
            this._selectedListPriceDiv = selectedListPriceDiv;
            this._prtGoodsNo = prtGoodsNo;
            this._prtMakerCode = prtMakerCode;
            this._prtMakerName = prtMakerName;
            this._selectedGoodsNoDiv = selectedGoodsNoDiv;
            //----------------ADD 2009/10/19----------------<<<<<
            // 2009/11/24 Add >>>
            this._searchBLCode = searchBLCode;
            // 2009/11/24 Add <<<
            // 2010/03/02 Add >>>
            this._bLGoodsCodeChange = bLGoodsCodeChange;
            // 2010/03/02 Add <<<
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            this._freSrchPrtPropNo = freSrchPrtPropNo;
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
            this._joinSourceMakerCode = joinSourceMakerCode;
            this._joinSrcPartsNoWithH = joinSrcPartsNoWithH;
            // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            this._optKonmanGoodsMstCtl = optKonmanGoodsMstCtl;
            this._standard = standard;
            this._packing = packing;
            this._posNo = posNo;
            this._makerGoodsNo = makerGoodsNo;
            this._createDateTimeA = createDateTimeA;
            this._updateDateTimeA = updateDateTimeA;
            this._fileHeaderGuidA = fileHeaderGuidA;
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
            // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            //// ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
            //this._mkrSuggestRtPricList = mkrSuggestRtPricList;
            //// ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
            // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            // ADD 2015/02/25 SCM高速化 C向け種別対応 -------------------------->>>>>
            this._prmSetDtlName2ForFac = prmSetDtlName2ForFac;
            this._prmSetDtlName2ForCOw = prmSetDtlName2ForCOw;
            // ADD 2015/02/25 SCM高速化 C向け種別対応 --------------------------<<<<<
        }

        /// <summary>
        /// 商品連結データクラス複製処理
        /// </summary>
        /// <returns>GoodsUnitDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsUnitDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 呉元嘯 保守依頼②を追加</br>
        /// <br>Update Note      :   2009/11/24 21024 佐々木 健　検索BLコードを追加</br>
        /// <br>Update Note      :   2010/06/10 22018 鈴木 正臣　自由検索部品固有番号を追加</br>
        /// <br>Update Note      :   2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// <br></br>
        /// </remarks>
        public GoodsUnitData Clone()
        {
            // UPD 2015/02/25 SCM高速化 C向け種別対応 -------------------------->>>>>
            #region 旧ソース
            //// --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
            ////// --- UPD m.suzuki 2010/06/10 ---------->>>>>
            //////// 2010/03/02 >>>
            ////////// 2009/11/24 >>>
            //////////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv);
            ////////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode);
            ////////// 2009/11/24 <<<
            //////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange);
            //////// 2010/03/02 <<<
            ////return new GoodsUnitData( this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo );
            ////// --- UPD m.suzuki 2010/06/10 ----------<<<<<
            //// UPD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
            ////return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
            ////                        , this._joinSourceMakerCode
            ////                        , this._joinSrcPartsNoWithH
            ////                        );
            //return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
            //                        , this._joinSourceMakerCode
            //                        , this._joinSrcPartsNoWithH
            //                        , this._mkrSuggestRtPricList
            //                        );
            //// UPD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
            //// --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
            //// -------- ADD START 2014/02/10 高陽 -------->>>>>
            //return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
            //                        , this._joinSourceMakerCode
            //                        , this._joinSrcPartsNoWithH, this._optKonmanGoodsMstCtl, this._standard, this._packing, this._posNo, this._makerGoodsNo, this._createDateTimeA, this._updateDateTimeA, this._fileHeaderGuidA
            //                        );
            //// -------- ADD END 2014/02/10 高陽 --------<<<<<
            #endregion
            return new GoodsUnitData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._bLGoodsFullName, this._displayOrder, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._enterpriseGanreName, this._updateDate, this._goodsRateGrpCode, this._goodsRateGrpName, this._salesCode, this._salesCodeName, this._supplierCd, this._supplierNm1, this._supplierNm2, this._suppHonorificTitle, this._supplierKana, this._supplierSnm, this._stockUnPrcFrcProcCd, this._stockCnsTaxFrcProcCd, this._supplierLot, this._secretCode, this._primePartsDisplayOrder, this._prmSetDtlNo1, this._prmSetDtlName1, this._prmSetDtlNo2, this._prmSetDtlName2, this._sectionCode, this._goodsPriceList, this._stockList, this._offerKubun, this._goodsKind, this._goodsKindResolved, this._joinDispOrder, this._joinQty, this._joinSpecialNote, this._setDispOrder, this._setQty, this._setSpecialNote, this._partsQty, this._offerDataDiv, this._selectedWarehouseCode, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._selectedListPrice, this._selectedListPriceDiv, this._prtGoodsNo, this._prtMakerCode, this._prtMakerName, this._selectedGoodsNoDiv, this._searchBLCode, this._bLGoodsCodeChange, this._freSrchPrtPropNo
                        , this._joinSourceMakerCode
                        , this._joinSrcPartsNoWithH, this._optKonmanGoodsMstCtl, this._standard, this._packing, this._posNo, this._makerGoodsNo, this._createDateTimeA, this._updateDateTimeA, this._fileHeaderGuidA
                        // , this._mkrSuggestRtPricList  // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応
                        , this._prmSetDtlName2ForFac
                        , this._prmSetDtlName2ForCOw
                        );
            // UPD 2015/02/25 SCM高速化 C向け種別対応 --------------------------<<<<<
        }

        /// <summary>
        /// 商品連結データクラス比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsUnitDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 呉元嘯 保守依頼②を追加</br>
        /// <br>Update Note      :   2009/11/24 21024 佐々木 健　検索BLコードを追加</br>
        /// <br>Update Note      :   2010/06/10 22018 鈴木 正臣　自由検索部品固有番号を追加</br>
        /// <br>Update Note      :   2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        public bool Equals(GoodsUnitData target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.MakerShortName == target.MakerShortName)
                 && (this.MakerKanaName == target.MakerKanaName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.Jan == target.Jan)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsLGroupName == target.GoodsLGroupName)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.GoodsMGroupName == target.GoodsMGroupName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.OfferDate == target.OfferDate)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsNote1 == target.GoodsNote1)
                 && (this.GoodsNote2 == target.GoodsNote2)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 && (this.GoodsRateGrpName == target.GoodsRateGrpName)
                 && (this.SalesCode == target.SalesCode)
                 && (this.SalesCodeName == target.SalesCodeName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierNm2 == target.SupplierNm2)
                 && (this.SuppHonorificTitle == target.SuppHonorificTitle)
                 && (this.SupplierKana == target.SupplierKana)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
                 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
                 && (this.SupplierLot == target.SupplierLot)
                 && (this.SecretCode == target.SecretCode)
                 && (this.PrimePartsDisplayOrder == target.PrimePartsDisplayOrder)
                 && (this.PrmSetDtlNo1 == target.PrmSetDtlNo1)
                 && (this.PrmSetDtlName1 == target.PrmSetDtlName1)
                 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                 && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
                 && (this.SectionCode == target.SectionCode)
                //&& (this.GoodsPriceList == target.GoodsPriceList)
                 && (EqualsGoodsPriceList(this.GoodsPriceList, target.GoodsPriceList))
                //&& (this.StockList == target.StockList)
                 && (this.OfferKubun == target.OfferKubun)
                 && (this.GoodsKind == target.GoodsKind)
                 && (this.GoodsKindResolved == target.GoodsKindResolved)
                 && (this.JoinDispOrder == target.JoinDispOrder)
                 && (this.JoinQty == target.JoinQty)
                 && (this.JoinSpecialNote == target.JoinSpecialNote)
                 && (this.SetDispOrder == target.SetDispOrder)
                 && (this.SetQty == target.SetQty)
                 && (this.SetSpecialNote == target.SetSpecialNote)
                 && (this.PartsQty == target.PartsQty)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.SelectedWarehouseCode == target.SelectedWarehouseCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                // 2009/11/24 Add >>>
                 && ( this.SearchBLCode == target.SearchBLCode )
                // 2009/11/24 Add <<<
                // 2010/03/02 Add >>>
                 && ( this.BLGoodsCodeChange == target.BLGoodsCodeChange )
                // 2010/03/02 Add <<<
                // --- ADD m.suzuki 2010/06/10 ---------->>>>>
                 && (this.FreSrchPrtPropNo == target.FreSrchPrtPropNo)
                // --- ADD m.suzuki 2010/06/10 ----------<<<<<
                 //----------------ADD 2009/10/19---------------->>>>>
                 && (this.SelectedListPrice == target.SelectedListPrice)
                 && (this.SelectedListPriceDiv == target.SelectedListPriceDiv)
                 && (this.PrtGoodsNo == target.PrtGoodsNo)
                 && (this.PrtMakerCode == target.PrtMakerCode)
                 && (this.PrtMakerName == target.PrtMakerName)
                 && (this.SelectedGoodsNoDiv == target.SelectedGoodsNoDiv)
                 //----------------ADD 2009/10/19----------------<<<<<
                // -------- ADD START 2014/02/10 高陽 -------->>>>>
                 && (this.OptKonmanGoodsMstCtl == target.OptKonmanGoodsMstCtl)
                 && (this.Standard == target.Standard)
                 && (this.Packing == target.Packing)
                 && (this.PosNo == target.PosNo)
                 && (this.MakerGoodsNo == target.MakerGoodsNo)
                 && (this.CreateDateTimeA == target.CreateDateTimeA)
                 && (this.UpdateDateTimeA == target.UpdateDateTimeA)
                 && (this.FileHeaderGuidA == target.FileHeaderGuidA));
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
        }

        /// <summary>
        /// 商品連結データクラス比較処理
        /// </summary>
        /// <param name="goodsUnitData1">
        ///                    比較するGoodsUnitDataクラスのインスタンス
        /// </param>
        /// <param name="goodsUnitData2">比較するGoodsUnitDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 呉元嘯 保守依頼②を追加</br>
        /// <br>Update Note      :   2009/11/24 21024 佐々木 健　検索BLコードを追加</br>
        /// <br>Update Note      :   2010/06/10 22018 鈴木 正臣 自由検索部品固有番号を追加</br>
        /// <br>Update Note      :   2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        public static bool Equals(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
        {
            return ((goodsUnitData1.CreateDateTime == goodsUnitData2.CreateDateTime)
                 && (goodsUnitData1.UpdateDateTime == goodsUnitData2.UpdateDateTime)
                 && (goodsUnitData1.EnterpriseCode == goodsUnitData2.EnterpriseCode)
                 && (goodsUnitData1.FileHeaderGuid == goodsUnitData2.FileHeaderGuid)
                 && (goodsUnitData1.UpdEmployeeCode == goodsUnitData2.UpdEmployeeCode)
                 && (goodsUnitData1.UpdAssemblyId1 == goodsUnitData2.UpdAssemblyId1)
                 && (goodsUnitData1.UpdAssemblyId2 == goodsUnitData2.UpdAssemblyId2)
                 && (goodsUnitData1.LogicalDeleteCode == goodsUnitData2.LogicalDeleteCode)
                 && (goodsUnitData1.GoodsMakerCd == goodsUnitData2.GoodsMakerCd)
                 && (goodsUnitData1.MakerName == goodsUnitData2.MakerName)
                 && (goodsUnitData1.MakerShortName == goodsUnitData2.MakerShortName)
                 && (goodsUnitData1.MakerKanaName == goodsUnitData2.MakerKanaName)
                 && (goodsUnitData1.GoodsNo == goodsUnitData2.GoodsNo)
                 && (goodsUnitData1.GoodsName == goodsUnitData2.GoodsName)
                 && (goodsUnitData1.GoodsNameKana == goodsUnitData2.GoodsNameKana)
                 && (goodsUnitData1.Jan == goodsUnitData2.Jan)
                 && (goodsUnitData1.BLGoodsCode == goodsUnitData2.BLGoodsCode)
                 && (goodsUnitData1.BLGoodsFullName == goodsUnitData2.BLGoodsFullName)
                 && (goodsUnitData1.DisplayOrder == goodsUnitData2.DisplayOrder)
                 && (goodsUnitData1.GoodsLGroup == goodsUnitData2.GoodsLGroup)
                 && (goodsUnitData1.GoodsLGroupName == goodsUnitData2.GoodsLGroupName)
                 && (goodsUnitData1.GoodsMGroup == goodsUnitData2.GoodsMGroup)
                 && (goodsUnitData1.GoodsMGroupName == goodsUnitData2.GoodsMGroupName)
                 && (goodsUnitData1.BLGroupCode == goodsUnitData2.BLGroupCode)
                 && (goodsUnitData1.BLGroupName == goodsUnitData2.BLGroupName)
                 && (goodsUnitData1.GoodsRateRank == goodsUnitData2.GoodsRateRank)
                 && (goodsUnitData1.TaxationDivCd == goodsUnitData2.TaxationDivCd)
                 && (goodsUnitData1.GoodsNoNoneHyphen == goodsUnitData2.GoodsNoNoneHyphen)
                 && (goodsUnitData1.OfferDate == goodsUnitData2.OfferDate)
                 && (goodsUnitData1.GoodsKindCode == goodsUnitData2.GoodsKindCode)
                 && (goodsUnitData1.GoodsNote1 == goodsUnitData2.GoodsNote1)
                 && (goodsUnitData1.GoodsNote2 == goodsUnitData2.GoodsNote2)
                 && (goodsUnitData1.GoodsSpecialNote == goodsUnitData2.GoodsSpecialNote)
                 && (goodsUnitData1.EnterpriseGanreCode == goodsUnitData2.EnterpriseGanreCode)
                 && (goodsUnitData1.EnterpriseGanreName == goodsUnitData2.EnterpriseGanreName)
                 && (goodsUnitData1.UpdateDate == goodsUnitData2.UpdateDate)
                 && (goodsUnitData1.GoodsRateGrpCode == goodsUnitData2.GoodsRateGrpCode)
                 && (goodsUnitData1.GoodsRateGrpName == goodsUnitData2.GoodsRateGrpName)
                 && (goodsUnitData1.SalesCode == goodsUnitData2.SalesCode)
                 && (goodsUnitData1.SalesCodeName == goodsUnitData2.SalesCodeName)
                 && (goodsUnitData1.SupplierCd == goodsUnitData2.SupplierCd)
                 && (goodsUnitData1.SupplierNm1 == goodsUnitData2.SupplierNm1)
                 && (goodsUnitData1.SupplierNm2 == goodsUnitData2.SupplierNm2)
                 && (goodsUnitData1.SuppHonorificTitle == goodsUnitData2.SuppHonorificTitle)
                 && (goodsUnitData1.SupplierKana == goodsUnitData2.SupplierKana)
                 && (goodsUnitData1.SupplierSnm == goodsUnitData2.SupplierSnm)
                 && (goodsUnitData1.StockUnPrcFrcProcCd == goodsUnitData2.StockUnPrcFrcProcCd)
                 && (goodsUnitData1.StockCnsTaxFrcProcCd == goodsUnitData2.StockCnsTaxFrcProcCd)
                 && (goodsUnitData1.SupplierLot == goodsUnitData2.SupplierLot)
                 && (goodsUnitData1.SecretCode == goodsUnitData2.SecretCode)
                 && (goodsUnitData1.PrimePartsDisplayOrder == goodsUnitData2.PrimePartsDisplayOrder)
                 && (goodsUnitData1.PrmSetDtlNo1 == goodsUnitData2.PrmSetDtlNo1)
                 && (goodsUnitData1.PrmSetDtlName1 == goodsUnitData2.PrmSetDtlName1)
                 && (goodsUnitData1.PrmSetDtlNo2 == goodsUnitData2.PrmSetDtlNo2)
                 && (goodsUnitData1.PrmSetDtlName2 == goodsUnitData2.PrmSetDtlName2)
                 && (goodsUnitData1.SectionCode == goodsUnitData2.SectionCode)
                //&& (goodsUnitData1.GoodsPriceList == goodsUnitData2.GoodsPriceList)
                 && (EqualsGoodsPriceList(goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList))
                //&& (goodsUnitData1.StockList == goodsUnitData2.StockList)
                 && (goodsUnitData1.OfferKubun == goodsUnitData2.OfferKubun)
                 && (goodsUnitData1.GoodsKind == goodsUnitData2.GoodsKind)
                 && (goodsUnitData1.GoodsKindResolved == goodsUnitData2.GoodsKindResolved)
                 && (goodsUnitData1.JoinDispOrder == goodsUnitData2.JoinDispOrder)
                 && (goodsUnitData1.JoinQty == goodsUnitData2.JoinQty)
                 && (goodsUnitData1.JoinSpecialNote == goodsUnitData2.JoinSpecialNote)
                 && (goodsUnitData1.SetDispOrder == goodsUnitData2.SetDispOrder)
                 && (goodsUnitData1.SetQty == goodsUnitData2.SetQty)
                 && (goodsUnitData1.SetSpecialNote == goodsUnitData2.SetSpecialNote)
                 && (goodsUnitData1.PartsQty == goodsUnitData2.PartsQty)
                 && (goodsUnitData1.OfferDataDiv == goodsUnitData2.OfferDataDiv)
                 && (goodsUnitData1.SelectedWarehouseCode == goodsUnitData2.SelectedWarehouseCode)
                 && (goodsUnitData1.EnterpriseName == goodsUnitData2.EnterpriseName)
                 && (goodsUnitData1.UpdEmployeeName == goodsUnitData2.UpdEmployeeName)
                 && (goodsUnitData1.BLGoodsName == goodsUnitData2.BLGoodsName)
                 // 2009/11/24 Add >>>
                 && ( goodsUnitData1.SearchBLCode == goodsUnitData2.SearchBLCode )
                 // 2009/11/24 Add <<<
                 // 2010/03/02 Add >>>
                 && ( goodsUnitData1.BLGoodsCodeChange == goodsUnitData2.BLGoodsCodeChange )
                 // 2010/03/02 Add <<<
                 // --- ADD m.suzuki 2010/06/10 ---------->>>>>
                 && (goodsUnitData1.FreSrchPrtPropNo == goodsUnitData2.FreSrchPrtPropNo)
                 // --- ADD m.suzuki 2010/06/10 ----------<<<<<
                 //----------------ADD 2009/10/19---------------->>>>>
                 && (goodsUnitData1.SelectedListPrice == goodsUnitData2.SelectedListPrice)
                 && (goodsUnitData1.SelectedListPriceDiv == goodsUnitData2.SelectedListPriceDiv)
                 && (goodsUnitData1.PrtGoodsNo == goodsUnitData2.PrtGoodsNo)
                 && (goodsUnitData1.PrtMakerCode == goodsUnitData2.PrtMakerCode)
                 && (goodsUnitData1.PrtMakerName == goodsUnitData2.PrtMakerName)
                 && (goodsUnitData1.SelectedGoodsNoDiv == goodsUnitData2.SelectedGoodsNoDiv)
                 //----------------ADD 2009/10/19----------------<<<<<
                // -------- ADD START 2014/02/10 高陽 -------->>>>>
                 && (goodsUnitData1.OptKonmanGoodsMstCtl == goodsUnitData2.OptKonmanGoodsMstCtl)
                 && (goodsUnitData1.Standard == goodsUnitData2.Standard)
                 && (goodsUnitData1.Packing == goodsUnitData2.Packing)
                 && (goodsUnitData1.PosNo == goodsUnitData2.PosNo)
                 && (goodsUnitData1.MakerGoodsNo == goodsUnitData2.MakerGoodsNo)
                 && (goodsUnitData1.CreateDateTimeA == goodsUnitData2.CreateDateTimeA)
                 && (goodsUnitData1.UpdateDateTimeA == goodsUnitData2.UpdateDateTimeA)
                 && (goodsUnitData1.FileHeaderGuidA == goodsUnitData2.FileHeaderGuidA));
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
        }
        /// <summary>
        /// 商品連結データクラス比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsUnitDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 呉元嘯 保守依頼②を追加</br>
        /// <br>Update Note      :   2009/11/24 21024 佐々木 健　検索BLコードを追加</br>
        /// <br>Update Note      :   2010/06/10 22018 鈴木 正臣 自由検索部品固有番号を追加</br>
        /// <br>Update Note      :   2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        public ArrayList Compare(GoodsUnitData target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.MakerShortName != target.MakerShortName) resList.Add("MakerShortName");
            if (this.MakerKanaName != target.MakerKanaName) resList.Add("MakerKanaName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.Jan != target.Jan) resList.Add("Jan");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsLGroupName != target.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.GoodsMGroupName != target.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsNote1 != target.GoodsNote1) resList.Add("GoodsNote1");
            if (this.GoodsNote2 != target.GoodsNote2) resList.Add("GoodsNote2");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.EnterpriseGanreName != target.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (this.GoodsRateGrpName != target.GoodsRateGrpName) resList.Add("GoodsRateGrpName");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.SalesCodeName != target.SalesCodeName) resList.Add("SalesCodeName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SuppHonorificTitle != target.SuppHonorificTitle) resList.Add("SuppHonorificTitle");
            if (this.SupplierKana != target.SupplierKana) resList.Add("SupplierKana");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (this.SupplierLot != target.SupplierLot) resList.Add("SupplierLot");
            if (this.SecretCode != target.SecretCode) resList.Add("SecretCode");
            if (this.PrimePartsDisplayOrder != target.PrimePartsDisplayOrder) resList.Add("PrimePartsDisplayOrder");
            if (this.PrmSetDtlNo1 != target.PrmSetDtlNo1) resList.Add("PrmSetDtlNo1");
            if (this.PrmSetDtlName1 != target.PrmSetDtlName1) resList.Add("PrmSetDtlName1");
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.PrmSetDtlName2 != target.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            //if ( this.GoodsPriceList != target.GoodsPriceList ) resList.Add( "GoodsPriceList" );
            if (!EqualsGoodsPriceList(this.GoodsPriceList, target.GoodsPriceList)) resList.Add("GoodsPriceList");
            //if ( this.StockList != target.StockList ) resList.Add( "StockList" );
            if (this.OfferKubun != target.OfferKubun) resList.Add("OfferKubun");
            if (this.GoodsKind != target.GoodsKind) resList.Add("GoodsKind");
            if (this.GoodsKindResolved != target.GoodsKindResolved) resList.Add("GoodsKindResolved");
            if (this.JoinDispOrder != target.JoinDispOrder) resList.Add("JoinDispOrder");
            if (this.JoinQty != target.JoinQty) resList.Add("JoinQty");
            if (this.JoinSpecialNote != target.JoinSpecialNote) resList.Add("JoinSpecialNote");
            if (this.SetDispOrder != target.SetDispOrder) resList.Add("SetDispOrder");
            if (this.SetQty != target.SetQty) resList.Add("SetQty");
            if (this.SetSpecialNote != target.SetSpecialNote) resList.Add("SetSpecialNote");
            if (this.PartsQty != target.PartsQty) resList.Add("PartsQty");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.SelectedWarehouseCode != target.SelectedWarehouseCode) resList.Add("SelectedWarehouseCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            //----------------ADD 2009/10/19---------------->>>>>
            if (this.SelectedListPrice != target.SelectedListPrice) resList.Add("SelectedListPrice");
            if (this.SelectedListPriceDiv != target.SelectedListPriceDiv) resList.Add("SelectedListPriceDiv");
            if (this.PrtGoodsNo != target.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (this.PrtMakerCode != target.PrtMakerCode) resList.Add("PrtMakerCode");
            if (this.PrtMakerName != target.PrtMakerName) resList.Add("PrtMakerName");
            if (this.SelectedGoodsNoDiv != target.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            // 2009/11/24 Add >>>
            if (this.SearchBLCode != target.SearchBLCode) resList.Add("SearchBLCode");
            // 2009/11/24 Add <<<
            //----------------ADD 2009/10/19---------------->>>>>
            // 2010/03/02 Add >>>
            if (this.BLGoodsCodeChange != target.BLGoodsCodeChange) resList.Add("BLGoodsCodeChange");
            // 2010/03/02 Add <<<
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            if ( this.FreSrchPrtPropNo != target.FreSrchPrtPropNo ) resList.Add( "FreSrchPrtPropNo" );
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            if (this.OptKonmanGoodsMstCtl != target.OptKonmanGoodsMstCtl) resList.Add("OptKonmanGoodsMstCtl");
            if (this.Standard != target.Standard) resList.Add("Standard");
            if (this.Packing != target.Packing) resList.Add("Packing");
            if (this.PosNo != target.PosNo) resList.Add("PosNo");
            if (this.MakerGoodsNo != target.MakerGoodsNo) resList.Add("MakerGoodsNo");
            if (this.CreateDateTimeA != target.CreateDateTimeA) resList.Add("CreateDateTimeA");
            if (this.UpdateDateTimeA != target.UpdateDateTimeA) resList.Add("UpdateDateTimeA");
            if (this.FileHeaderGuidA != target.FileHeaderGuidA) resList.Add("FileHeaderGuidA");
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
            return resList;
        }

        /// <summary>
        /// 商品連結データクラス比較処理
        /// </summary>
        /// <param name="goodsUnitData1">比較するGoodsUnitDataクラスのインスタンス</param>
        /// <param name="goodsUnitData2">比較するGoodsUnitDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br></br>
        /// <br>Update Note      :   2009/10/19 呉元嘯 保守依頼②を追加</br>
        /// <br>Update Note      :   2009/11/24 21024 佐々木 健　検索BLコードを追加</br>
        /// <br>Update Note      :   2010/06/10 22018 鈴木 正臣 自由検索部品固有番号を追加</br>
        /// <br>Update Note      :   2014/02/10 高陽 Redmine#41976 商品マスタⅡの追加</br>
        /// </remarks>
        public static ArrayList Compare(GoodsUnitData goodsUnitData1, GoodsUnitData goodsUnitData2)
        {
            ArrayList resList = new ArrayList();
            if (goodsUnitData1.CreateDateTime != goodsUnitData2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsUnitData1.UpdateDateTime != goodsUnitData2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsUnitData1.EnterpriseCode != goodsUnitData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsUnitData1.FileHeaderGuid != goodsUnitData2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsUnitData1.UpdEmployeeCode != goodsUnitData2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsUnitData1.UpdAssemblyId1 != goodsUnitData2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsUnitData1.UpdAssemblyId2 != goodsUnitData2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsUnitData1.LogicalDeleteCode != goodsUnitData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsUnitData1.GoodsMakerCd != goodsUnitData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsUnitData1.MakerName != goodsUnitData2.MakerName) resList.Add("MakerName");
            if (goodsUnitData1.MakerShortName != goodsUnitData2.MakerShortName) resList.Add("MakerShortName");
            if (goodsUnitData1.MakerKanaName != goodsUnitData2.MakerKanaName) resList.Add("MakerKanaName");
            if (goodsUnitData1.GoodsNo != goodsUnitData2.GoodsNo) resList.Add("GoodsNo");
            if (goodsUnitData1.GoodsName != goodsUnitData2.GoodsName) resList.Add("GoodsName");
            if (goodsUnitData1.GoodsNameKana != goodsUnitData2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (goodsUnitData1.Jan != goodsUnitData2.Jan) resList.Add("Jan");
            if (goodsUnitData1.BLGoodsCode != goodsUnitData2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsUnitData1.BLGoodsFullName != goodsUnitData2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (goodsUnitData1.DisplayOrder != goodsUnitData2.DisplayOrder) resList.Add("DisplayOrder");
            if (goodsUnitData1.GoodsLGroup != goodsUnitData2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (goodsUnitData1.GoodsLGroupName != goodsUnitData2.GoodsLGroupName) resList.Add("GoodsLGroupName");
            if (goodsUnitData1.GoodsMGroup != goodsUnitData2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (goodsUnitData1.GoodsMGroupName != goodsUnitData2.GoodsMGroupName) resList.Add("GoodsMGroupName");
            if (goodsUnitData1.BLGroupCode != goodsUnitData2.BLGroupCode) resList.Add("BLGroupCode");
            if (goodsUnitData1.BLGroupName != goodsUnitData2.BLGroupName) resList.Add("BLGroupName");
            if (goodsUnitData1.GoodsRateRank != goodsUnitData2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (goodsUnitData1.TaxationDivCd != goodsUnitData2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (goodsUnitData1.GoodsNoNoneHyphen != goodsUnitData2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (goodsUnitData1.OfferDate != goodsUnitData2.OfferDate) resList.Add("OfferDate");
            if (goodsUnitData1.GoodsKindCode != goodsUnitData2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (goodsUnitData1.GoodsNote1 != goodsUnitData2.GoodsNote1) resList.Add("GoodsNote1");
            if (goodsUnitData1.GoodsNote2 != goodsUnitData2.GoodsNote2) resList.Add("GoodsNote2");
            if (goodsUnitData1.GoodsSpecialNote != goodsUnitData2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (goodsUnitData1.EnterpriseGanreCode != goodsUnitData2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (goodsUnitData1.EnterpriseGanreName != goodsUnitData2.EnterpriseGanreName) resList.Add("EnterpriseGanreName");
            if (goodsUnitData1.UpdateDate != goodsUnitData2.UpdateDate) resList.Add("UpdateDate");
            if (goodsUnitData1.GoodsRateGrpCode != goodsUnitData2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            if (goodsUnitData1.GoodsRateGrpName != goodsUnitData2.GoodsRateGrpName) resList.Add("GoodsRateGrpName");
            if (goodsUnitData1.SalesCode != goodsUnitData2.SalesCode) resList.Add("SalesCode");
            if (goodsUnitData1.SalesCodeName != goodsUnitData2.SalesCodeName) resList.Add("SalesCodeName");
            if (goodsUnitData1.SupplierCd != goodsUnitData2.SupplierCd) resList.Add("SupplierCd");
            if (goodsUnitData1.SupplierNm1 != goodsUnitData2.SupplierNm1) resList.Add("SupplierNm1");
            if (goodsUnitData1.SupplierNm2 != goodsUnitData2.SupplierNm2) resList.Add("SupplierNm2");
            if (goodsUnitData1.SuppHonorificTitle != goodsUnitData2.SuppHonorificTitle) resList.Add("SuppHonorificTitle");
            if (goodsUnitData1.SupplierKana != goodsUnitData2.SupplierKana) resList.Add("SupplierKana");
            if (goodsUnitData1.SupplierSnm != goodsUnitData2.SupplierSnm) resList.Add("SupplierSnm");
            if (goodsUnitData1.StockUnPrcFrcProcCd != goodsUnitData2.StockUnPrcFrcProcCd) resList.Add("StockUnPrcFrcProcCd");
            if (goodsUnitData1.StockCnsTaxFrcProcCd != goodsUnitData2.StockCnsTaxFrcProcCd) resList.Add("StockCnsTaxFrcProcCd");
            if (goodsUnitData1.SupplierLot != goodsUnitData2.SupplierLot) resList.Add("SupplierLot");
            if (goodsUnitData1.SecretCode != goodsUnitData2.SecretCode) resList.Add("SecretCode");
            if (goodsUnitData1.PrimePartsDisplayOrder != goodsUnitData2.PrimePartsDisplayOrder) resList.Add("PrimePartsDisplayOrder");
            if (goodsUnitData1.PrmSetDtlNo1 != goodsUnitData2.PrmSetDtlNo1) resList.Add("PrmSetDtlNo1");
            if (goodsUnitData1.PrmSetDtlName1 != goodsUnitData2.PrmSetDtlName1) resList.Add("PrmSetDtlName1");
            if (goodsUnitData1.PrmSetDtlNo2 != goodsUnitData2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (goodsUnitData1.PrmSetDtlName2 != goodsUnitData2.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (goodsUnitData1.SectionCode != goodsUnitData2.SectionCode) resList.Add("SectionCode");
            //if ( goodsUnitData1.GoodsPriceList != goodsUnitData2.GoodsPriceList ) resList.Add( "GoodsPriceList" );
            if (!EqualsGoodsPriceList(goodsUnitData1.GoodsPriceList, goodsUnitData2.GoodsPriceList)) resList.Add("GoodsPriceList");
            //if ( goodsUnitData1.StockList != goodsUnitData2.StockList ) resList.Add( "StockList" );
            if (goodsUnitData1.OfferKubun != goodsUnitData2.OfferKubun) resList.Add("OfferKubun");
            if (goodsUnitData1.GoodsKind != goodsUnitData2.GoodsKind) resList.Add("GoodsKind");
            if (goodsUnitData1.GoodsKindResolved != goodsUnitData2.GoodsKindResolved) resList.Add("GoodsKindResolved");
            if (goodsUnitData1.JoinDispOrder != goodsUnitData2.JoinDispOrder) resList.Add("JoinDispOrder");
            if (goodsUnitData1.JoinQty != goodsUnitData2.JoinQty) resList.Add("JoinQty");
            if (goodsUnitData1.JoinSpecialNote != goodsUnitData2.JoinSpecialNote) resList.Add("JoinSpecialNote");
            if (goodsUnitData1.SetDispOrder != goodsUnitData2.SetDispOrder) resList.Add("SetDispOrder");
            if (goodsUnitData1.SetQty != goodsUnitData2.SetQty) resList.Add("SetQty");
            if (goodsUnitData1.SetSpecialNote != goodsUnitData2.SetSpecialNote) resList.Add("SetSpecialNote");
            if (goodsUnitData1.PartsQty != goodsUnitData2.PartsQty) resList.Add("PartsQty");
            if (goodsUnitData1.OfferDataDiv != goodsUnitData2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (goodsUnitData1.SelectedWarehouseCode != goodsUnitData2.SelectedWarehouseCode) resList.Add("SelectedWarehouseCode");
            if (goodsUnitData1.EnterpriseName != goodsUnitData2.EnterpriseName) resList.Add("EnterpriseName");
            if (goodsUnitData1.UpdEmployeeName != goodsUnitData2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (goodsUnitData1.BLGoodsName != goodsUnitData2.BLGoodsName) resList.Add("BLGoodsName");
            //----------------ADD 2009/10/19---------------->>>>>
            if (goodsUnitData1.SelectedListPrice != goodsUnitData2.SelectedListPrice) resList.Add("SelectedListPrice");
            if (goodsUnitData1.SelectedListPriceDiv != goodsUnitData2.SelectedListPriceDiv) resList.Add("SelectedListPriceDiv");
            if (goodsUnitData1.PrtGoodsNo != goodsUnitData2.PrtGoodsNo) resList.Add("PrtGoodsNo");
            if (goodsUnitData1.PrtMakerCode != goodsUnitData2.PrtMakerCode) resList.Add("PrtMakerCode");
            if (goodsUnitData1.PrtMakerName != goodsUnitData2.PrtMakerName) resList.Add("PrtMakerName");
            if (goodsUnitData1.SelectedGoodsNoDiv != goodsUnitData2.SelectedGoodsNoDiv) resList.Add("SelectedGoodsNoDiv");
            //----------------ADD 2009/10/19----------------<<<<<
            // 2009/11/24 Add >>>
            if (goodsUnitData1.SearchBLCode != goodsUnitData2.SearchBLCode) resList.Add("SearchBLCode");
            // 2009/11/24 Add <<<
            // 2010/03/02 Add >>>
            if (goodsUnitData1.BLGoodsCodeChange != goodsUnitData2.BLGoodsCodeChange) resList.Add("BLGoodsCodeChange");
            // 2010/03/02 Add <<<
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            if ( goodsUnitData1.FreSrchPrtPropNo != goodsUnitData2.FreSrchPrtPropNo ) resList.Add( "FreSrchPrtPropNo" );
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            if (goodsUnitData1.OptKonmanGoodsMstCtl != goodsUnitData2.OptKonmanGoodsMstCtl) resList.Add("OptKonmanGoodsMstCtl");
            if (goodsUnitData1.Standard != goodsUnitData2.Standard) resList.Add("Standard");
            if (goodsUnitData1.Packing != goodsUnitData2.Packing) resList.Add("Packing");
            if (goodsUnitData1.PosNo != goodsUnitData2.PosNo) resList.Add("PosNo");
            if (goodsUnitData1.MakerGoodsNo != goodsUnitData2.MakerGoodsNo) resList.Add("MakerGoodsNo");
            if (goodsUnitData1.CreateDateTimeA != goodsUnitData2.CreateDateTimeA) resList.Add("CreateDateTimeA");
            if (goodsUnitData1.UpdateDateTimeA != goodsUnitData2.UpdateDateTimeA) resList.Add("UpdateDateTimeA");
            if (goodsUnitData1.FileHeaderGuidA != goodsUnitData2.FileHeaderGuidA) resList.Add("FileHeaderGuidA");
            // -------- ADD END 2014/02/10 高陽 --------<<<<<

            return resList;
        }
        /// <summary>
        /// 価格情報比較処理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private static bool EqualsGoodsPriceList(List<GoodsPrice> list, List<GoodsPrice> list2)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // 両方nullならOK
            if (list == null && list2 == null) return true;
            // 片方nullならNG
            if (list != null && list2 == null) return false;
            if (list == null && list2 != null) return false;
            // 要素数違いはNG
            if (list.Count != list2.Count) return false;

            // listベースで該当するlist2のレコードを探す
            foreach (GoodsPrice price in list)
            {
                GoodsPrice price2 = list2.Find(
                    delegate(GoodsPrice target)
                    {
                        return ((price.GoodsNo == target.GoodsNo) &&
                                (price.GoodsMakerCd == target.GoodsMakerCd) &&
                                (price.PriceStartDate == target.PriceStartDate));
                    }
                    );
                if (price2 == null) return false;

                // 価格クラス比較
                ArrayList priceComparelist = price.Compare(price2);
                int differCount = priceComparelist.Count;
                if (priceComparelist.Contains("CreateDateTime")) differCount--;
                if (priceComparelist.Contains("UpdateDateTime")) differCount--;
                if (priceComparelist.Contains("UpdateDate")) differCount--;
                if (differCount > 0) return false;
            }

            // 要素数が同じなのでlistベースで全て該当あれば逆の走査をしなくてもOK
            return true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
        }

    }

}
