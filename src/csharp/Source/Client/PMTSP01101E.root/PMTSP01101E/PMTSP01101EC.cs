using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   TspSdRvDtl
	/// <summary>
	///                      TSP送受信明細データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   TSP送受信明細データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2020/12/01</br>
	/// <br>Genarated Date   :   2020/12/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class TspSdRvDtl
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

		/// <summary>PM企業コード</summary>
		/// <remarks>部品商の企業コード</remarks>
		private string _pmEnterpriseCode = "";

		/// <summary>TSP通信番号</summary>
		/// <remarks>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</remarks>
		private Int32 _tspCommNo;

		/// <summary>TSP通信回数</summary>
		/// <remarks>PM側が１発注に対して回答を行う回数</remarks>
		private Int32 _tspCommCount;

		/// <summary>TSP通信行番号</summary>
		private Int32 _tspCommRowNo;

		/// <summary>納品区分</summary>
		/// <remarks>0:配送,1:引取</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>取扱区分</summary>
		/// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
		private Int32 _handleDivCode;

		/// <summary>部品形態</summary>
		/// <remarks>1:部品,2:用品</remarks>
		private Int32 _partsShape;

		/// <summary>納品確認区分</summary>
		/// <remarks>0:未確認,1:確認</remarks>
		private Int32 _delivrdGdsConfCd;

		/// <summary>納品完了予定日</summary>
		/// <remarks>納品予定日付 YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>翼部品コード</summary>
		/// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
		private Int32 _tbsPartsCode;

		/// <summary>PM部品名（カナ）</summary>
		/// <remarks>PM側の品名</remarks>
		private string _pmPartsNameKana = "";

		/// <summary>発注数</summary>
		private Double _salesOrderCount;

		/// <summary>納品数</summary>
		private Double _deliveredGoodsCount;

		/// <summary>ハイフン付品番</summary>
		private string _partsNoWithHyphen = "";

		/// <summary>PM部品メーカーコード</summary>
		/// <remarks>PM側の部品メーカーコード</remarks>
		private Int32 _pmPartsMakerCode;

		/// <summary>純正部品メーカーコード</summary>
		private Int32 _purePartsMakerCode;

		/// <summary>純正ハイフン付品番</summary>
		/// <remarks>SF・BK引当時は、伝票明細のハイフン付品番となる</remarks>
		private string _purePrtsNoWithHyphen = "";

		/// <summary>定価</summary>
		private Int64 _listPrice;

		/// <summary>単価</summary>
		private Int64 _unitPrice;

		/// <summary>PM明細取込区分</summary>
		/// <remarks>0:取込可,1:取込不可</remarks>
		private Int32 _pmDtlTakeinDivCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";


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

		/// public propaty name  :  PmEnterpriseCode
		/// <summary>PM企業コードプロパティ</summary>
		/// <value>部品商の企業コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmEnterpriseCode
		{
			get{return _pmEnterpriseCode;}
			set{_pmEnterpriseCode = value;}
		}

		/// public propaty name  :  TspCommNo
		/// <summary>TSP通信番号プロパティ</summary>
		/// <value>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP通信番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspCommNo
		{
			get{return _tspCommNo;}
			set{_tspCommNo = value;}
		}

		/// public propaty name  :  TspCommCount
		/// <summary>TSP通信回数プロパティ</summary>
		/// <value>PM側が１発注に対して回答を行う回数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP通信回数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspCommCount
		{
			get{return _tspCommCount;}
			set{_tspCommCount = value;}
		}

		/// public propaty name  :  TspCommRowNo
		/// <summary>TSP通信行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP通信行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspCommRowNo
		{
			get{return _tspCommRowNo;}
			set{_tspCommRowNo = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>納品区分プロパティ</summary>
		/// <value>0:配送,1:引取</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DeliveredGoodsDiv
		{
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
		}

		/// public propaty name  :  HandleDivCode
		/// <summary>取扱区分プロパティ</summary>
		/// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   取扱区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 HandleDivCode
		{
			get{return _handleDivCode;}
			set{_handleDivCode = value;}
		}

		/// public propaty name  :  PartsShape
		/// <summary>部品形態プロパティ</summary>
		/// <value>1:部品,2:用品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品形態プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsShape
		{
			get{return _partsShape;}
			set{_partsShape = value;}
		}

		/// public propaty name  :  DelivrdGdsConfCd
		/// <summary>納品確認区分プロパティ</summary>
		/// <value>0:未確認,1:確認</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品確認区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DelivrdGdsConfCd
		{
			get{return _delivrdGdsConfCd;}
			set{_delivrdGdsConfCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>納品完了予定日プロパティ</summary>
		/// <value>納品予定日付 YYYYMMDD</value>
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
		/// <value>納品予定日付 YYYYMMDD</value>
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
		/// <value>納品予定日付 YYYYMMDD</value>
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
		/// <value>納品予定日付 YYYYMMDD</value>
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
		/// <value>納品予定日付 YYYYMMDD</value>
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

		/// public propaty name  :  TbsPartsCode
		/// <summary>翼部品コードプロパティ</summary>
		/// <value>1～99999:提供分,100000～ユーザー登録用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   翼部品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get{return _tbsPartsCode;}
			set{_tbsPartsCode = value;}
		}

		/// public propaty name  :  PmPartsNameKana
		/// <summary>PM部品名（カナ）プロパティ</summary>
		/// <value>PM側の品名</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM部品名（カナ）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmPartsNameKana
		{
			get{return _pmPartsNameKana;}
			set{_pmPartsNameKana = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>発注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  DeliveredGoodsCount
		/// <summary>納品数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double DeliveredGoodsCount
		{
			get{return _deliveredGoodsCount;}
			set{_deliveredGoodsCount = value;}
		}

		/// public propaty name  :  PartsNoWithHyphen
		/// <summary>ハイフン付品番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ハイフン付品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartsNoWithHyphen
		{
			get{return _partsNoWithHyphen;}
			set{_partsNoWithHyphen = value;}
		}

		/// public propaty name  :  PmPartsMakerCode
		/// <summary>PM部品メーカーコードプロパティ</summary>
		/// <value>PM側の部品メーカーコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM部品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PmPartsMakerCode
		{
			get{return _pmPartsMakerCode;}
			set{_pmPartsMakerCode = value;}
		}

		/// public propaty name  :  PurePartsMakerCode
		/// <summary>純正部品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正部品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PurePartsMakerCode
		{
			get{return _purePartsMakerCode;}
			set{_purePartsMakerCode = value;}
		}

		/// public propaty name  :  PurePrtsNoWithHyphen
		/// <summary>純正ハイフン付品番プロパティ</summary>
		/// <value>SF・BK引当時は、伝票明細のハイフン付品番となる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正ハイフン付品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PurePrtsNoWithHyphen
		{
			get{return _purePrtsNoWithHyphen;}
			set{_purePrtsNoWithHyphen = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>定価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  PmDtlTakeinDivCd
		/// <summary>PM明細取込区分プロパティ</summary>
		/// <value>0:取込可,1:取込不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM明細取込区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PmDtlTakeinDivCd
		{
			get{return _pmDtlTakeinDivCd;}
			set{_pmDtlTakeinDivCd = value;}
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


		/// <summary>
		/// TSP送受信明細データコンストラクタ
		/// </summary>
		/// <returns>TspSdRvDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TspSdRvDtl()
		{
		}

		/// <summary>
		/// TSP送受信明細データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="pmEnterpriseCode">PM企業コード(部品商の企業コード)</param>
		/// <param name="tspCommNo">TSP通信番号(１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番))</param>
		/// <param name="tspCommCount">TSP通信回数(PM側が１発注に対して回答を行う回数)</param>
		/// <param name="tspCommRowNo">TSP通信行番号</param>
		/// <param name="deliveredGoodsDiv">納品区分(0:配送,1:引取)</param>
		/// <param name="handleDivCode">取扱区分(0:取り扱い品,1:納期確認中,2:未取り扱い品)</param>
		/// <param name="partsShape">部品形態(1:部品,2:用品)</param>
		/// <param name="delivrdGdsConfCd">納品確認区分(0:未確認,1:確認)</param>
		/// <param name="deliGdsCmpltDueDate">納品完了予定日(納品予定日付 YYYYMMDD)</param>
		/// <param name="tbsPartsCode">翼部品コード(1～99999:提供分,100000～ユーザー登録用)</param>
		/// <param name="pmPartsNameKana">PM部品名（カナ）(PM側の品名)</param>
		/// <param name="salesOrderCount">発注数</param>
		/// <param name="deliveredGoodsCount">納品数</param>
		/// <param name="partsNoWithHyphen">ハイフン付品番</param>
		/// <param name="pmPartsMakerCode">PM部品メーカーコード(PM側の部品メーカーコード)</param>
		/// <param name="purePartsMakerCode">純正部品メーカーコード</param>
		/// <param name="purePrtsNoWithHyphen">純正ハイフン付品番(SF・BK引当時は、伝票明細のハイフン付品番となる)</param>
		/// <param name="listPrice">定価</param>
		/// <param name="unitPrice">単価</param>
		/// <param name="pmDtlTakeinDivCd">PM明細取込区分(0:取込可,1:取込不可)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>TspSdRvDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TspSdRvDtl(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string pmEnterpriseCode,Int32 tspCommNo,Int32 tspCommCount,Int32 tspCommRowNo,Int32 deliveredGoodsDiv,Int32 handleDivCode,Int32 partsShape,Int32 delivrdGdsConfCd,DateTime deliGdsCmpltDueDate,Int32 tbsPartsCode,string pmPartsNameKana,Double salesOrderCount,Double deliveredGoodsCount,string partsNoWithHyphen,Int32 pmPartsMakerCode,Int32 purePartsMakerCode,string purePrtsNoWithHyphen,Int64 listPrice,Int64 unitPrice,Int32 pmDtlTakeinDivCd,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._pmEnterpriseCode = pmEnterpriseCode;
			this._tspCommNo = tspCommNo;
			this._tspCommCount = tspCommCount;
			this._tspCommRowNo = tspCommRowNo;
			this._deliveredGoodsDiv = deliveredGoodsDiv;
			this._handleDivCode = handleDivCode;
			this._partsShape = partsShape;
			this._delivrdGdsConfCd = delivrdGdsConfCd;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._tbsPartsCode = tbsPartsCode;
			this._pmPartsNameKana = pmPartsNameKana;
			this._salesOrderCount = salesOrderCount;
			this._deliveredGoodsCount = deliveredGoodsCount;
			this._partsNoWithHyphen = partsNoWithHyphen;
			this._pmPartsMakerCode = pmPartsMakerCode;
			this._purePartsMakerCode = purePartsMakerCode;
			this._purePrtsNoWithHyphen = purePrtsNoWithHyphen;
			this._listPrice = listPrice;
			this._unitPrice = unitPrice;
			this._pmDtlTakeinDivCd = pmDtlTakeinDivCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// TSP送受信明細データ複製処理
		/// </summary>
		/// <returns>TspSdRvDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいTspSdRvDtlクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TspSdRvDtl Clone()
		{
			return new TspSdRvDtl(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._pmEnterpriseCode,this._tspCommNo,this._tspCommCount,this._tspCommRowNo,this._deliveredGoodsDiv,this._handleDivCode,this._partsShape,this._delivrdGdsConfCd,this._deliGdsCmpltDueDate,this._tbsPartsCode,this._pmPartsNameKana,this._salesOrderCount,this._deliveredGoodsCount,this._partsNoWithHyphen,this._pmPartsMakerCode,this._purePartsMakerCode,this._purePrtsNoWithHyphen,this._listPrice,this._unitPrice,this._pmDtlTakeinDivCd,this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// TSP送受信明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のTspSdRvDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(TspSdRvDtl target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.PmEnterpriseCode == target.PmEnterpriseCode)
				 && (this.TspCommNo == target.TspCommNo)
				 && (this.TspCommCount == target.TspCommCount)
				 && (this.TspCommRowNo == target.TspCommRowNo)
				 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
				 && (this.HandleDivCode == target.HandleDivCode)
				 && (this.PartsShape == target.PartsShape)
				 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.TbsPartsCode == target.TbsPartsCode)
				 && (this.PmPartsNameKana == target.PmPartsNameKana)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
				 && (this.PartsNoWithHyphen == target.PartsNoWithHyphen)
				 && (this.PmPartsMakerCode == target.PmPartsMakerCode)
				 && (this.PurePartsMakerCode == target.PurePartsMakerCode)
				 && (this.PurePrtsNoWithHyphen == target.PurePrtsNoWithHyphen)
				 && (this.ListPrice == target.ListPrice)
				 && (this.UnitPrice == target.UnitPrice)
				 && (this.PmDtlTakeinDivCd == target.PmDtlTakeinDivCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// TSP送受信明細データ比較処理
		/// </summary>
		/// <param name="tspSdRvDtl1">
		///                    比較するTspSdRvDtlクラスのインスタンス
		/// </param>
		/// <param name="tspSdRvDtl2">比較するTspSdRvDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(TspSdRvDtl tspSdRvDtl1, TspSdRvDtl tspSdRvDtl2)
		{
			return ((tspSdRvDtl1.CreateDateTime == tspSdRvDtl2.CreateDateTime)
				 && (tspSdRvDtl1.UpdateDateTime == tspSdRvDtl2.UpdateDateTime)
				 && (tspSdRvDtl1.EnterpriseCode == tspSdRvDtl2.EnterpriseCode)
				 && (tspSdRvDtl1.FileHeaderGuid == tspSdRvDtl2.FileHeaderGuid)
				 && (tspSdRvDtl1.UpdEmployeeCode == tspSdRvDtl2.UpdEmployeeCode)
				 && (tspSdRvDtl1.UpdAssemblyId1 == tspSdRvDtl2.UpdAssemblyId1)
				 && (tspSdRvDtl1.UpdAssemblyId2 == tspSdRvDtl2.UpdAssemblyId2)
				 && (tspSdRvDtl1.LogicalDeleteCode == tspSdRvDtl2.LogicalDeleteCode)
				 && (tspSdRvDtl1.PmEnterpriseCode == tspSdRvDtl2.PmEnterpriseCode)
				 && (tspSdRvDtl1.TspCommNo == tspSdRvDtl2.TspCommNo)
				 && (tspSdRvDtl1.TspCommCount == tspSdRvDtl2.TspCommCount)
				 && (tspSdRvDtl1.TspCommRowNo == tspSdRvDtl2.TspCommRowNo)
				 && (tspSdRvDtl1.DeliveredGoodsDiv == tspSdRvDtl2.DeliveredGoodsDiv)
				 && (tspSdRvDtl1.HandleDivCode == tspSdRvDtl2.HandleDivCode)
				 && (tspSdRvDtl1.PartsShape == tspSdRvDtl2.PartsShape)
				 && (tspSdRvDtl1.DelivrdGdsConfCd == tspSdRvDtl2.DelivrdGdsConfCd)
				 && (tspSdRvDtl1.DeliGdsCmpltDueDate == tspSdRvDtl2.DeliGdsCmpltDueDate)
				 && (tspSdRvDtl1.TbsPartsCode == tspSdRvDtl2.TbsPartsCode)
				 && (tspSdRvDtl1.PmPartsNameKana == tspSdRvDtl2.PmPartsNameKana)
				 && (tspSdRvDtl1.SalesOrderCount == tspSdRvDtl2.SalesOrderCount)
				 && (tspSdRvDtl1.DeliveredGoodsCount == tspSdRvDtl2.DeliveredGoodsCount)
				 && (tspSdRvDtl1.PartsNoWithHyphen == tspSdRvDtl2.PartsNoWithHyphen)
				 && (tspSdRvDtl1.PmPartsMakerCode == tspSdRvDtl2.PmPartsMakerCode)
				 && (tspSdRvDtl1.PurePartsMakerCode == tspSdRvDtl2.PurePartsMakerCode)
				 && (tspSdRvDtl1.PurePrtsNoWithHyphen == tspSdRvDtl2.PurePrtsNoWithHyphen)
				 && (tspSdRvDtl1.ListPrice == tspSdRvDtl2.ListPrice)
				 && (tspSdRvDtl1.UnitPrice == tspSdRvDtl2.UnitPrice)
				 && (tspSdRvDtl1.PmDtlTakeinDivCd == tspSdRvDtl2.PmDtlTakeinDivCd)
				 && (tspSdRvDtl1.EnterpriseName == tspSdRvDtl2.EnterpriseName)
				 && (tspSdRvDtl1.UpdEmployeeName == tspSdRvDtl2.UpdEmployeeName));
		}
		/// <summary>
		/// TSP送受信明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のTspSdRvDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(TspSdRvDtl target)
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
			if(this.PmEnterpriseCode != target.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(this.TspCommNo != target.TspCommNo)resList.Add("TspCommNo");
			if(this.TspCommCount != target.TspCommCount)resList.Add("TspCommCount");
			if(this.TspCommRowNo != target.TspCommRowNo)resList.Add("TspCommRowNo");
			if(this.DeliveredGoodsDiv != target.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(this.HandleDivCode != target.HandleDivCode)resList.Add("HandleDivCode");
			if(this.PartsShape != target.PartsShape)resList.Add("PartsShape");
			if(this.DelivrdGdsConfCd != target.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.TbsPartsCode != target.TbsPartsCode)resList.Add("TbsPartsCode");
			if(this.PmPartsNameKana != target.PmPartsNameKana)resList.Add("PmPartsNameKana");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.DeliveredGoodsCount != target.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(this.PartsNoWithHyphen != target.PartsNoWithHyphen)resList.Add("PartsNoWithHyphen");
			if(this.PmPartsMakerCode != target.PmPartsMakerCode)resList.Add("PmPartsMakerCode");
			if(this.PurePartsMakerCode != target.PurePartsMakerCode)resList.Add("PurePartsMakerCode");
			if(this.PurePrtsNoWithHyphen != target.PurePrtsNoWithHyphen)resList.Add("PurePrtsNoWithHyphen");
			if(this.ListPrice != target.ListPrice)resList.Add("ListPrice");
			if(this.UnitPrice != target.UnitPrice)resList.Add("UnitPrice");
			if(this.PmDtlTakeinDivCd != target.PmDtlTakeinDivCd)resList.Add("PmDtlTakeinDivCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// TSP送受信明細データ比較処理
		/// </summary>
		/// <param name="tspSdRvDtl1">比較するTspSdRvDtlクラスのインスタンス</param>
		/// <param name="tspSdRvDtl2">比較するTspSdRvDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(TspSdRvDtl tspSdRvDtl1, TspSdRvDtl tspSdRvDtl2)
		{
			ArrayList resList = new ArrayList();
			if(tspSdRvDtl1.CreateDateTime != tspSdRvDtl2.CreateDateTime)resList.Add("CreateDateTime");
			if(tspSdRvDtl1.UpdateDateTime != tspSdRvDtl2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(tspSdRvDtl1.EnterpriseCode != tspSdRvDtl2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(tspSdRvDtl1.FileHeaderGuid != tspSdRvDtl2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(tspSdRvDtl1.UpdEmployeeCode != tspSdRvDtl2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(tspSdRvDtl1.UpdAssemblyId1 != tspSdRvDtl2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(tspSdRvDtl1.UpdAssemblyId2 != tspSdRvDtl2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(tspSdRvDtl1.LogicalDeleteCode != tspSdRvDtl2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(tspSdRvDtl1.PmEnterpriseCode != tspSdRvDtl2.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(tspSdRvDtl1.TspCommNo != tspSdRvDtl2.TspCommNo)resList.Add("TspCommNo");
			if(tspSdRvDtl1.TspCommCount != tspSdRvDtl2.TspCommCount)resList.Add("TspCommCount");
			if(tspSdRvDtl1.TspCommRowNo != tspSdRvDtl2.TspCommRowNo)resList.Add("TspCommRowNo");
			if(tspSdRvDtl1.DeliveredGoodsDiv != tspSdRvDtl2.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(tspSdRvDtl1.HandleDivCode != tspSdRvDtl2.HandleDivCode)resList.Add("HandleDivCode");
			if(tspSdRvDtl1.PartsShape != tspSdRvDtl2.PartsShape)resList.Add("PartsShape");
			if(tspSdRvDtl1.DelivrdGdsConfCd != tspSdRvDtl2.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(tspSdRvDtl1.DeliGdsCmpltDueDate != tspSdRvDtl2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(tspSdRvDtl1.TbsPartsCode != tspSdRvDtl2.TbsPartsCode)resList.Add("TbsPartsCode");
			if(tspSdRvDtl1.PmPartsNameKana != tspSdRvDtl2.PmPartsNameKana)resList.Add("PmPartsNameKana");
			if(tspSdRvDtl1.SalesOrderCount != tspSdRvDtl2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(tspSdRvDtl1.DeliveredGoodsCount != tspSdRvDtl2.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(tspSdRvDtl1.PartsNoWithHyphen != tspSdRvDtl2.PartsNoWithHyphen)resList.Add("PartsNoWithHyphen");
			if(tspSdRvDtl1.PmPartsMakerCode != tspSdRvDtl2.PmPartsMakerCode)resList.Add("PmPartsMakerCode");
			if(tspSdRvDtl1.PurePartsMakerCode != tspSdRvDtl2.PurePartsMakerCode)resList.Add("PurePartsMakerCode");
			if(tspSdRvDtl1.PurePrtsNoWithHyphen != tspSdRvDtl2.PurePrtsNoWithHyphen)resList.Add("PurePrtsNoWithHyphen");
			if(tspSdRvDtl1.ListPrice != tspSdRvDtl2.ListPrice)resList.Add("ListPrice");
			if(tspSdRvDtl1.UnitPrice != tspSdRvDtl2.UnitPrice)resList.Add("UnitPrice");
			if(tspSdRvDtl1.PmDtlTakeinDivCd != tspSdRvDtl2.PmDtlTakeinDivCd)resList.Add("PmDtlTakeinDivCd");
			if(tspSdRvDtl1.EnterpriseName != tspSdRvDtl2.EnterpriseName)resList.Add("EnterpriseName");
			if(tspSdRvDtl1.UpdEmployeeName != tspSdRvDtl2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
