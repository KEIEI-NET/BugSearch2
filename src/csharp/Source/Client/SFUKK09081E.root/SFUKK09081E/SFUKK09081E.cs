using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BillPrtSt
	/// <summary>
	///                      請求印刷設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求印刷設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class BillPrtSt
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

		/// <summary>請求印刷設定管理コード</summary>
		/// <remarks>常にゼロ固定</remarks>
		private Int32 _billPrtStMngCd;

		/// <summary>請求一覧表出力区分</summary>
		/// <remarks>0:全て出力,1:0とプラス金額･･･つづきあり</remarks>
		private Int32 _billTableOutCd;

		/// <summary>合計請求書出力区分</summary>
		/// <remarks>0:全て出力,1:0とプラス金額･･･つづきあり(請求書（鑑）出力区分)</remarks>
		private Int32 _totalBillOutputDiv;

		/// <summary>明細請求書出力区分</summary>
		/// <remarks>0:全て出力,1:0とプラス金額･･･つづきあり</remarks>
		private Int32 _detailBillOutputCode;

		/// <summary>請求書末日印字区分</summary>
		/// <remarks>0:数値印字,1:28～31日は末日と印字</remarks>
		private Int32 _billLastDayPrtDiv;

		/// <summary>請求書自社名印字区分</summary>
		/// <remarks>0:印字する,1:印字しない</remarks>
		private Int32 _billCoNmPrintOutCd;

		/// <summary>請求書銀行名印字区分</summary>
		/// <remarks>0:印字する,1:印字しない</remarks>
		private Int32 _billBankNmPrintOut;

		/// <summary>得意先電話番号印字区分</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _custTelNoPrtDivCd;

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>請求書印刷一時中断枚数</summary>
		/// <remarks>1回の印刷にて出力できる枚数</remarks>
		private Int32 _billPrtSuspendCnt;
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
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

		/// public propaty name  :  BillPrtStMngCd
		/// <summary>請求印刷設定管理コードプロパティ</summary>
		/// <value>常にゼロ固定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求印刷設定管理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillPrtStMngCd
		{
			get{return _billPrtStMngCd;}
			set{_billPrtStMngCd = value;}
		}

		/// public propaty name  :  BillTableOutCd
		/// <summary>請求一覧表出力区分プロパティ</summary>
		/// <value>0:全て出力,1:0とプラス金額･･･つづきあり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求一覧表出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillTableOutCd
		{
			get{return _billTableOutCd;}
			set{_billTableOutCd = value;}
		}

		/// public propaty name  :  TotalBillOutputDiv
		/// <summary>合計請求書出力区分プロパティ</summary>
		/// <value>0:全て出力,1:0とプラス金額･･･つづきあり(請求書（鑑）出力区分)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   合計請求書出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalBillOutputDiv
		{
			get{return _totalBillOutputDiv;}
			set{_totalBillOutputDiv = value;}
		}

		/// public propaty name  :  DetailBillOutputCode
		/// <summary>明細請求書出力区分プロパティ</summary>
		/// <value>0:全て出力,1:0とプラス金額･･･つづきあり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細請求書出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DetailBillOutputCode
		{
			get{return _detailBillOutputCode;}
			set{_detailBillOutputCode = value;}
		}

		/// public propaty name  :  BillLastDayPrtDiv
		/// <summary>請求書末日印字区分プロパティ</summary>
		/// <value>0:数値印字,1:28～31日は末日と印字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書末日印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillLastDayPrtDiv
		{
			get{return _billLastDayPrtDiv;}
			set{_billLastDayPrtDiv = value;}
		}

		/// public propaty name  :  BillCoNmPrintOutCd
		/// <summary>請求書自社名印字区分プロパティ</summary>
		/// <value>0:印字する,1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書自社名印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillCoNmPrintOutCd
		{
			get{return _billCoNmPrintOutCd;}
			set{_billCoNmPrintOutCd = value;}
		}

		/// public propaty name  :  BillBankNmPrintOut
		/// <summary>請求書銀行名印字区分プロパティ</summary>
		/// <value>0:印字する,1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書銀行名印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillBankNmPrintOut
		{
			get{return _billBankNmPrintOut;}
			set{_billBankNmPrintOut = value;}
		}

		/// public propaty name  :  CustTelNoPrtDivCd
		/// <summary>得意先電話番号印字区分プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先電話番号印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustTelNoPrtDivCd
		{
			get{return _custTelNoPrtDivCd;}
			set{_custTelNoPrtDivCd = value;}
		}

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  BillPrtSuspendCnt
		/// <summary>請求書印刷一時中断枚数プロパティ</summary>
		/// <value>1回の印刷にて出力できる枚数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書印刷一時中断枚数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillPrtSuspendCnt
		{
			get{return _billPrtSuspendCnt;}
			set{_billPrtSuspendCnt = value;}
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
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
		/// 請求印刷設定マスタコンストラクタ
		/// </summary>
		/// <returns>BillPrtStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillPrtStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BillPrtSt()
		{
		}

		/// <summary>
		/// 請求印刷設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="billPrtStMngCd">請求印刷設定管理コード(常にゼロ固定)</param>
		/// <param name="billTableOutCd">請求一覧表出力区分(0:全て出力,1:0とプラス金額･･･つづきあり)</param>
		/// <param name="totalBillOutputDiv">合計請求書出力区分(0:全て出力,1:0とプラス金額･･･つづきあり(請求書（鑑）出力区分))</param>
		/// <param name="detailBillOutputCode">明細請求書出力区分(0:全て出力,1:0とプラス金額･･･つづきあり)</param>
		/// <param name="billLastDayPrtDiv">請求書末日印字区分(0:数値印字,1:28～31日は末日と印字)</param>
		/// <param name="billCoNmPrintOutCd">請求書自社名印字区分(0:印字する,1:印字しない)</param>
		/// <param name="billBankNmPrintOut">請求書銀行名印字区分(0:印字する,1:印字しない)</param>
		/// <param name="custTelNoPrtDivCd">得意先電話番号印字区分(0:印字しない,1:印字する)</param>
		/// <param name="billPrtSuspendCnt">請求書印刷一時中断枚数(1回の印刷にて出力できる枚数)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>BillPrtStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillPrtStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public BillPrtSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 billPrtStMngCd,Int32 billTableOutCd,Int32 totalBillOutputDiv,Int32 detailBillOutputCode,Int32 billLastDayPrtDiv,Int32 billCoNmPrintOutCd,Int32 billBankNmPrintOut,Int32 custTelNoPrtDivCd,Int32 billPrtSuspendCnt,string enterpriseName,string updEmployeeName)  // DEL 2008/06/13
        public BillPrtSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 billPrtStMngCd, Int32 billTableOutCd, Int32 totalBillOutputDiv, Int32 detailBillOutputCode, Int32 billLastDayPrtDiv, Int32 billCoNmPrintOutCd, Int32 billBankNmPrintOut, Int32 custTelNoPrtDivCd, string enterpriseName, string updEmployeeName)  // ADD 2008/06/13
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._billPrtStMngCd = billPrtStMngCd;
			this._billTableOutCd = billTableOutCd;
			this._totalBillOutputDiv = totalBillOutputDiv;
			this._detailBillOutputCode = detailBillOutputCode;
			this._billLastDayPrtDiv = billLastDayPrtDiv;
			this._billCoNmPrintOutCd = billCoNmPrintOutCd;
			this._billBankNmPrintOut = billBankNmPrintOut;
			this._custTelNoPrtDivCd = custTelNoPrtDivCd;
			//this._billPrtSuspendCnt = billPrtSuspendCnt;  // DEL 2008/06/13 
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 請求印刷設定マスタ複製処理
		/// </summary>
		/// <returns>BillPrtStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいBillPrtStクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BillPrtSt Clone()
		{
			//return new BillPrtSt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._billPrtStMngCd,this._billTableOutCd,this._totalBillOutputDiv,this._detailBillOutputCode,this._billLastDayPrtDiv,this._billCoNmPrintOutCd,this._billBankNmPrintOut,this._custTelNoPrtDivCd,this._billPrtSuspendCnt,this._enterpriseName,this._updEmployeeName);  // DEL 2008/06/13
            return new BillPrtSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._billPrtStMngCd, this._billTableOutCd, this._totalBillOutputDiv, this._detailBillOutputCode, this._billLastDayPrtDiv, this._billCoNmPrintOutCd, this._billBankNmPrintOut, this._custTelNoPrtDivCd, this._enterpriseName, this._updEmployeeName);  // ADD 2008/06/13
        }

		/// <summary>
		/// 請求印刷設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のBillPrtStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillPrtStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(BillPrtSt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.BillPrtStMngCd == target.BillPrtStMngCd)
				 && (this.BillTableOutCd == target.BillTableOutCd)
				 && (this.TotalBillOutputDiv == target.TotalBillOutputDiv)
				 && (this.DetailBillOutputCode == target.DetailBillOutputCode)
				 && (this.BillLastDayPrtDiv == target.BillLastDayPrtDiv)
				 && (this.BillCoNmPrintOutCd == target.BillCoNmPrintOutCd)
				 && (this.BillBankNmPrintOut == target.BillBankNmPrintOut)
				 && (this.CustTelNoPrtDivCd == target.CustTelNoPrtDivCd)
				 //&& (this.BillPrtSuspendCnt == target.BillPrtSuspendCnt)  // DEL 2008/06/13
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 請求印刷設定マスタ比較処理
		/// </summary>
		/// <param name="billPrtSt1">
		///                    比較するBillPrtStクラスのインスタンス
		/// </param>
		/// <param name="billPrtSt2">比較するBillPrtStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillPrtStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(BillPrtSt billPrtSt1, BillPrtSt billPrtSt2)
		{
			return ((billPrtSt1.CreateDateTime == billPrtSt2.CreateDateTime)
				 && (billPrtSt1.UpdateDateTime == billPrtSt2.UpdateDateTime)
				 && (billPrtSt1.EnterpriseCode == billPrtSt2.EnterpriseCode)
				 && (billPrtSt1.FileHeaderGuid == billPrtSt2.FileHeaderGuid)
				 && (billPrtSt1.UpdEmployeeCode == billPrtSt2.UpdEmployeeCode)
				 && (billPrtSt1.UpdAssemblyId1 == billPrtSt2.UpdAssemblyId1)
				 && (billPrtSt1.UpdAssemblyId2 == billPrtSt2.UpdAssemblyId2)
				 && (billPrtSt1.LogicalDeleteCode == billPrtSt2.LogicalDeleteCode)
				 && (billPrtSt1.BillPrtStMngCd == billPrtSt2.BillPrtStMngCd)
				 && (billPrtSt1.BillTableOutCd == billPrtSt2.BillTableOutCd)
				 && (billPrtSt1.TotalBillOutputDiv == billPrtSt2.TotalBillOutputDiv)
				 && (billPrtSt1.DetailBillOutputCode == billPrtSt2.DetailBillOutputCode)
				 && (billPrtSt1.BillLastDayPrtDiv == billPrtSt2.BillLastDayPrtDiv)
				 && (billPrtSt1.BillCoNmPrintOutCd == billPrtSt2.BillCoNmPrintOutCd)
				 && (billPrtSt1.BillBankNmPrintOut == billPrtSt2.BillBankNmPrintOut)
				 && (billPrtSt1.CustTelNoPrtDivCd == billPrtSt2.CustTelNoPrtDivCd)
				 //&& (billPrtSt1.BillPrtSuspendCnt == billPrtSt2.BillPrtSuspendCnt)  // DEL 2008/06/13
				 && (billPrtSt1.EnterpriseName == billPrtSt2.EnterpriseName)
				 && (billPrtSt1.UpdEmployeeName == billPrtSt2.UpdEmployeeName));
		}
		/// <summary>
		/// 請求印刷設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のBillPrtStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillPrtStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(BillPrtSt target)
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
			if(this.BillPrtStMngCd != target.BillPrtStMngCd)resList.Add("BillPrtStMngCd");
			if(this.BillTableOutCd != target.BillTableOutCd)resList.Add("BillTableOutCd");
			if(this.TotalBillOutputDiv != target.TotalBillOutputDiv)resList.Add("TotalBillOutputDiv");
			if(this.DetailBillOutputCode != target.DetailBillOutputCode)resList.Add("DetailBillOutputCode");
			if(this.BillLastDayPrtDiv != target.BillLastDayPrtDiv)resList.Add("BillLastDayPrtDiv");
			if(this.BillCoNmPrintOutCd != target.BillCoNmPrintOutCd)resList.Add("BillCoNmPrintOutCd");
			if(this.BillBankNmPrintOut != target.BillBankNmPrintOut)resList.Add("BillBankNmPrintOut");
			if(this.CustTelNoPrtDivCd != target.CustTelNoPrtDivCd)resList.Add("CustTelNoPrtDivCd");
			//if(this.BillPrtSuspendCnt != target.BillPrtSuspendCnt)resList.Add("BillPrtSuspendCnt");  // DEL 2008/06/13
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 請求印刷設定マスタ比較処理
		/// </summary>
		/// <param name="billPrtSt1">比較するBillPrtStクラスのインスタンス</param>
		/// <param name="billPrtSt2">比較するBillPrtStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillPrtStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(BillPrtSt billPrtSt1, BillPrtSt billPrtSt2)
		{
			ArrayList resList = new ArrayList();
			if(billPrtSt1.CreateDateTime != billPrtSt2.CreateDateTime)resList.Add("CreateDateTime");
			if(billPrtSt1.UpdateDateTime != billPrtSt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(billPrtSt1.EnterpriseCode != billPrtSt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(billPrtSt1.FileHeaderGuid != billPrtSt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(billPrtSt1.UpdEmployeeCode != billPrtSt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(billPrtSt1.UpdAssemblyId1 != billPrtSt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(billPrtSt1.UpdAssemblyId2 != billPrtSt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(billPrtSt1.LogicalDeleteCode != billPrtSt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(billPrtSt1.BillPrtStMngCd != billPrtSt2.BillPrtStMngCd)resList.Add("BillPrtStMngCd");
			if(billPrtSt1.BillTableOutCd != billPrtSt2.BillTableOutCd)resList.Add("BillTableOutCd");
			if(billPrtSt1.TotalBillOutputDiv != billPrtSt2.TotalBillOutputDiv)resList.Add("TotalBillOutputDiv");
			if(billPrtSt1.DetailBillOutputCode != billPrtSt2.DetailBillOutputCode)resList.Add("DetailBillOutputCode");
			if(billPrtSt1.BillLastDayPrtDiv != billPrtSt2.BillLastDayPrtDiv)resList.Add("BillLastDayPrtDiv");
			if(billPrtSt1.BillCoNmPrintOutCd != billPrtSt2.BillCoNmPrintOutCd)resList.Add("BillCoNmPrintOutCd");
			if(billPrtSt1.BillBankNmPrintOut != billPrtSt2.BillBankNmPrintOut)resList.Add("BillBankNmPrintOut");
			if(billPrtSt1.CustTelNoPrtDivCd != billPrtSt2.CustTelNoPrtDivCd)resList.Add("CustTelNoPrtDivCd");
			//if(billPrtSt1.BillPrtSuspendCnt != billPrtSt2.BillPrtSuspendCnt)resList.Add("BillPrtSuspendCnt");  // DEL 2008/06/13
			if(billPrtSt1.EnterpriseName != billPrtSt2.EnterpriseName)resList.Add("EnterpriseName");
			if(billPrtSt1.UpdEmployeeName != billPrtSt2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
