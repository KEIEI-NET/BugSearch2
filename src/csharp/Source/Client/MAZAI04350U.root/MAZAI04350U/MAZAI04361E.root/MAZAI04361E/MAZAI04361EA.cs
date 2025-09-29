using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAdjust
	/// <summary>
	///                      在庫調整データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫調整データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/08/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/20  長内</br>
	/// <br>                 :   受払元伝票区分,受払元取引区分の補足に</br>
	/// <br>                 :   「42:マスタメンテ」追加</br>
	/// <br>Update Note      :   2008/6/30  杉村</br>
	/// <br>                 :   受払元取引区分の補足の</br>
	/// <br>                 :   「42:マスタメンテ」削除</br>
	/// <br>Update Note      :   2008/8/22  長内</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   　入力担当者コード</br>
	/// <br>                 :   　入力担当者名称</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   　仕入拠点コード</br>
	/// <br>                 :   　仕入入力者コード</br>
	/// <br>                 :   　仕入入力者名称</br>
	/// <br>                 :   　仕入担当者コード</br>
	/// <br>                 :   　仕入担当者名称</br>
	/// <br>                 :   　仕入金額小計</br>
	/// </remarks>
	public class StockAdjust
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
		private string _sectionCode = "";

		/// <summary>在庫調整伝票番号</summary>
		private Int32 _stockAdjustSlipNo;

		/// <summary>受払元伝票区分</summary>
		/// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>受払元取引区分</summary>
		/// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</remarks>
		private Int32 _acPayTransCd;

		/// <summary>調整日付</summary>
		private DateTime _adjustDate;

		/// <summary>入力日付</summary>
		private DateTime _inputDay;

		/// <summary>仕入拠点コード</summary>
		private string _stockSectionCd = "";

		/// <summary>仕入入力者コード</summary>
		private string _stockInputCode = "";

		/// <summary>仕入入力者名称</summary>
		private string _stockInputName = "";

		/// <summary>仕入担当者コード</summary>
		private string _stockAgentCode = "";

		/// <summary>仕入担当者名称</summary>
		private string _stockAgentName = "";

		/// <summary>仕入金額小計</summary>
		private Int64 _stockSubttlPrice;

		/// <summary>伝票備考</summary>
		private string _slipNote = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>仕入拠点名称</summary>
		private string _stockSectionNm = "";


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

		/// public propaty name  :  StockAdjustSlipNo
		/// <summary>在庫調整伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫調整伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockAdjustSlipNo
		{
			get{return _stockAdjustSlipNo;}
			set{_stockAdjustSlipNo = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>受払元伝票区分プロパティ</summary>
		/// <value>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>受払元取引区分プロパティ</summary>
		/// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元取引区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AdjustDate
		/// <summary>調整日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AdjustDate
		{
			get{return _adjustDate;}
			set{_adjustDate = value;}
		}

		/// public propaty name  :  AdjustDateJpFormal
		/// <summary>調整日付 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateJpInFormal
		/// <summary>調整日付 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateAdFormal
		/// <summary>調整日付 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateAdInFormal
		/// <summary>調整日付 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  InputDayJpFormal
		/// <summary>入力日付 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayJpInFormal
		/// <summary>入力日付 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdFormal
		/// <summary>入力日付 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdInFormal
		/// <summary>入力日付 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _inputDay);}
			set{}
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

		/// public propaty name  :  StockSubttlPrice
		/// <summary>仕入金額小計プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額小計プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSubttlPrice
		{
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
		}

		/// public propaty name  :  SlipNote
		/// <summary>伝票備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
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

		/// public propaty name  :  StockSectionNm
		/// <summary>仕入拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockSectionNm
		{
			get{return _stockSectionNm;}
			set{_stockSectionNm = value;}
		}


		/// <summary>
		/// 在庫調整データコンストラクタ
		/// </summary>
		/// <returns>StockAdjustクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjust()
		{
		}

		/// <summary>
		/// 在庫調整データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
		/// <param name="acPaySlipCd">受払元伝票区分(10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸)</param>
		/// <param name="acPayTransCd">受払元取引区分(10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消)</param>
		/// <param name="adjustDate">調整日付</param>
		/// <param name="inputDay">入力日付</param>
		/// <param name="stockSectionCd">仕入拠点コード</param>
		/// <param name="stockInputCode">仕入入力者コード</param>
		/// <param name="stockInputName">仕入入力者名称</param>
		/// <param name="stockAgentCode">仕入担当者コード</param>
		/// <param name="stockAgentName">仕入担当者名称</param>
		/// <param name="stockSubttlPrice">仕入金額小計</param>
		/// <param name="slipNote">伝票備考</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="stockSectionNm">仕入拠点名称</param>
		/// <returns>StockAdjustクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjust(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 stockAdjustSlipNo,Int32 acPaySlipCd,Int32 acPayTransCd,DateTime adjustDate,DateTime inputDay,string stockSectionCd,string stockInputCode,string stockInputName,string stockAgentCode,string stockAgentName,Int64 stockSubttlPrice,string slipNote,string enterpriseName,string updEmployeeName,string stockSectionNm)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._stockAdjustSlipNo = stockAdjustSlipNo;
			this._acPaySlipCd = acPaySlipCd;
			this._acPayTransCd = acPayTransCd;
			this.AdjustDate = adjustDate;
			this.InputDay = inputDay;
			this._stockSectionCd = stockSectionCd;
			this._stockInputCode = stockInputCode;
			this._stockInputName = stockInputName;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._stockSubttlPrice = stockSubttlPrice;
			this._slipNote = slipNote;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._stockSectionNm = stockSectionNm;

		}

		/// <summary>
		/// 在庫調整データ複製処理
		/// </summary>
		/// <returns>StockAdjustクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockAdjustクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjust Clone()
		{
			return new StockAdjust(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._stockAdjustSlipNo,this._acPaySlipCd,this._acPayTransCd,this._adjustDate,this._inputDay,this._stockSectionCd,this._stockInputCode,this._stockInputName,this._stockAgentCode,this._stockAgentName,this._stockSubttlPrice,this._slipNote,this._enterpriseName,this._updEmployeeName,this._stockSectionNm);
		}

		/// <summary>
		/// 在庫調整データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockAdjustクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockAdjust target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.StockAdjustSlipNo == target.StockAdjustSlipNo)
				 && (this.AcPaySlipCd == target.AcPaySlipCd)
				 && (this.AcPayTransCd == target.AcPayTransCd)
				 && (this.AdjustDate == target.AdjustDate)
				 && (this.InputDay == target.InputDay)
				 && (this.StockSectionCd == target.StockSectionCd)
				 && (this.StockInputCode == target.StockInputCode)
				 && (this.StockInputName == target.StockInputName)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.StockSubttlPrice == target.StockSubttlPrice)
				 && (this.SlipNote == target.SlipNote)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.StockSectionNm == target.StockSectionNm));
		}

		/// <summary>
		/// 在庫調整データ比較処理
		/// </summary>
		/// <param name="stockAdjust1">
		///                    比較するStockAdjustクラスのインスタンス
		/// </param>
		/// <param name="stockAdjust2">比較するStockAdjustクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockAdjust stockAdjust1, StockAdjust stockAdjust2)
		{
			return ((stockAdjust1.CreateDateTime == stockAdjust2.CreateDateTime)
				 && (stockAdjust1.UpdateDateTime == stockAdjust2.UpdateDateTime)
				 && (stockAdjust1.EnterpriseCode == stockAdjust2.EnterpriseCode)
				 && (stockAdjust1.FileHeaderGuid == stockAdjust2.FileHeaderGuid)
				 && (stockAdjust1.UpdEmployeeCode == stockAdjust2.UpdEmployeeCode)
				 && (stockAdjust1.UpdAssemblyId1 == stockAdjust2.UpdAssemblyId1)
				 && (stockAdjust1.UpdAssemblyId2 == stockAdjust2.UpdAssemblyId2)
				 && (stockAdjust1.LogicalDeleteCode == stockAdjust2.LogicalDeleteCode)
				 && (stockAdjust1.SectionCode == stockAdjust2.SectionCode)
				 && (stockAdjust1.StockAdjustSlipNo == stockAdjust2.StockAdjustSlipNo)
				 && (stockAdjust1.AcPaySlipCd == stockAdjust2.AcPaySlipCd)
				 && (stockAdjust1.AcPayTransCd == stockAdjust2.AcPayTransCd)
				 && (stockAdjust1.AdjustDate == stockAdjust2.AdjustDate)
				 && (stockAdjust1.InputDay == stockAdjust2.InputDay)
				 && (stockAdjust1.StockSectionCd == stockAdjust2.StockSectionCd)
				 && (stockAdjust1.StockInputCode == stockAdjust2.StockInputCode)
				 && (stockAdjust1.StockInputName == stockAdjust2.StockInputName)
				 && (stockAdjust1.StockAgentCode == stockAdjust2.StockAgentCode)
				 && (stockAdjust1.StockAgentName == stockAdjust2.StockAgentName)
				 && (stockAdjust1.StockSubttlPrice == stockAdjust2.StockSubttlPrice)
				 && (stockAdjust1.SlipNote == stockAdjust2.SlipNote)
				 && (stockAdjust1.EnterpriseName == stockAdjust2.EnterpriseName)
				 && (stockAdjust1.UpdEmployeeName == stockAdjust2.UpdEmployeeName)
				 && (stockAdjust1.StockSectionNm == stockAdjust2.StockSectionNm));
		}
		/// <summary>
		/// 在庫調整データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockAdjustクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockAdjust target)
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
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.StockAdjustSlipNo != target.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(this.AcPaySlipCd != target.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(this.AcPayTransCd != target.AcPayTransCd)resList.Add("AcPayTransCd");
			if(this.AdjustDate != target.AdjustDate)resList.Add("AdjustDate");
			if(this.InputDay != target.InputDay)resList.Add("InputDay");
			if(this.StockSectionCd != target.StockSectionCd)resList.Add("StockSectionCd");
			if(this.StockInputCode != target.StockInputCode)resList.Add("StockInputCode");
			if(this.StockInputName != target.StockInputName)resList.Add("StockInputName");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.StockSubttlPrice != target.StockSubttlPrice)resList.Add("StockSubttlPrice");
			if(this.SlipNote != target.SlipNote)resList.Add("SlipNote");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.StockSectionNm != target.StockSectionNm)resList.Add("StockSectionNm");

			return resList;
		}

		/// <summary>
		/// 在庫調整データ比較処理
		/// </summary>
		/// <param name="stockAdjust1">比較するStockAdjustクラスのインスタンス</param>
		/// <param name="stockAdjust2">比較するStockAdjustクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockAdjust stockAdjust1, StockAdjust stockAdjust2)
		{
			ArrayList resList = new ArrayList();
			if(stockAdjust1.CreateDateTime != stockAdjust2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockAdjust1.UpdateDateTime != stockAdjust2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockAdjust1.EnterpriseCode != stockAdjust2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockAdjust1.FileHeaderGuid != stockAdjust2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockAdjust1.UpdEmployeeCode != stockAdjust2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockAdjust1.UpdAssemblyId1 != stockAdjust2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockAdjust1.UpdAssemblyId2 != stockAdjust2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockAdjust1.LogicalDeleteCode != stockAdjust2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockAdjust1.SectionCode != stockAdjust2.SectionCode)resList.Add("SectionCode");
			if(stockAdjust1.StockAdjustSlipNo != stockAdjust2.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(stockAdjust1.AcPaySlipCd != stockAdjust2.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(stockAdjust1.AcPayTransCd != stockAdjust2.AcPayTransCd)resList.Add("AcPayTransCd");
			if(stockAdjust1.AdjustDate != stockAdjust2.AdjustDate)resList.Add("AdjustDate");
			if(stockAdjust1.InputDay != stockAdjust2.InputDay)resList.Add("InputDay");
			if(stockAdjust1.StockSectionCd != stockAdjust2.StockSectionCd)resList.Add("StockSectionCd");
			if(stockAdjust1.StockInputCode != stockAdjust2.StockInputCode)resList.Add("StockInputCode");
			if(stockAdjust1.StockInputName != stockAdjust2.StockInputName)resList.Add("StockInputName");
			if(stockAdjust1.StockAgentCode != stockAdjust2.StockAgentCode)resList.Add("StockAgentCode");
			if(stockAdjust1.StockAgentName != stockAdjust2.StockAgentName)resList.Add("StockAgentName");
			if(stockAdjust1.StockSubttlPrice != stockAdjust2.StockSubttlPrice)resList.Add("StockSubttlPrice");
			if(stockAdjust1.SlipNote != stockAdjust2.SlipNote)resList.Add("SlipNote");
			if(stockAdjust1.EnterpriseName != stockAdjust2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockAdjust1.UpdEmployeeName != stockAdjust2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(stockAdjust1.StockSectionNm != stockAdjust2.StockSectionNm)resList.Add("StockSectionNm");

			return resList;
		}
	}
}
