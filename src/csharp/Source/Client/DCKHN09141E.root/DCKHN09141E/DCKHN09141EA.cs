using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerChange
	/// <summary>
	///                      得意先マスタ（変動情報）
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先マスタ（変動情報）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustomerChange
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

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

        //--- DEL 2008/06/23 --------->>>>>
        ///// <summary>得意先略称</summary>
        //private string _customerSnm = "";
        //--- DEL 2008/06/23 ---------<<<<<

		/// <summary>与信額</summary>
		private Int64 _creditMoney;

		/// <summary>警告与信額</summary>
        private Int64 _warningCreditMoney;

		/// <summary>現在売掛残高</summary>
		/// <remarks>入金データ、売上データ（売掛）を登録する場合にリアルに更新</remarks>
        private Int64 _prsntAccRecBalance;

        //--- DEL 2008/06/23 ---------->>>>>
        ///// <summary>現在得意先伝票番号</summary>
        //private Int64 _presentCustSlipNo;

        ///// <summary>開始得意先伝票番号</summary>
        //private Int64 _startCustSlipNo;

        ///// <summary>終了得意先伝票番号</summary>
        //private Int64 _endCustSlipNo;

        ///// <summary>番号桁数</summary>
        ///// <remarks>番号桁数≧（終了番号桁数＋ヘッダー桁数＋フッター桁数）であること　番号桁数はMAX19桁</remarks>
        //private Int32 _noCharcterCount;

        ///// <summary>得意先伝票番号ヘッダ</summary>
        //private string _custSlipNoHeader = "";

        ///// <summary>得意先伝票番号フッタ</summary>
        //private string _custSlipNoFooter = "";
        //--- DEL 2008/06/23 ----------<<<<<

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

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

        //--- DEL 2008/06/23 ---------->>>>>
        ///// public propaty name  :  CustomerSnm
        ///// <summary>得意先略称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先略称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustomerSnm
        //{
        //    get{return _customerSnm;}
        //    set{_customerSnm = value;}
        //}
        //--- DEL 2008/06/23 ----------<<<<<

		/// public propaty name  :  CreditMoney
		/// <summary>与信額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   与信額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 CreditMoney
		{
			get{return _creditMoney;}
			set{_creditMoney = value;}
		}

		/// public propaty name  :  WarningCreditMoney
		/// <summary>警告与信額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   警告与信額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 WarningCreditMoney
		{
			get{return _warningCreditMoney;}
			set{_warningCreditMoney = value;}
		}

		/// public propaty name  :  PrsntAccRecBalance
		/// <summary>現在売掛残高プロパティ</summary>
		/// <value>入金データ、売上データ（売掛）を登録する場合にリアルに更新</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   現在売掛残高プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 PrsntAccRecBalance
		{
			get{return _prsntAccRecBalance;}
			set{_prsntAccRecBalance = value;}
		}

        //--- DEL 2008/06/23 ---------->>>>>
        ///// public propaty name  :  PresentCustSlipNo
        ///// <summary>現在得意先伝票番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   現在得意先伝票番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 PresentCustSlipNo
        //{
        //    get{return _presentCustSlipNo;}
        //    set{_presentCustSlipNo = value;}
        //}

        ///// public propaty name  :  StartCustSlipNo
        ///// <summary>開始得意先伝票番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始得意先伝票番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 StartCustSlipNo
        //{
        //    get{return _startCustSlipNo;}
        //    set{_startCustSlipNo = value;}
        //}

        ///// public propaty name  :  EndCustSlipNo
        ///// <summary>終了得意先伝票番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了得意先伝票番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int64 EndCustSlipNo
        //{
        //    get{return _endCustSlipNo;}
        //    set{_endCustSlipNo = value;}
        //}

        ///// public propaty name  :  NoCharcterCount
        ///// <summary>番号桁数プロパティ</summary>
        ///// <value>番号桁数≧（終了番号桁数＋ヘッダー桁数＋フッター桁数）であること　番号桁数はMAX19桁</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   番号桁数プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 NoCharcterCount
        //{
        //    get{return _noCharcterCount;}
        //    set{_noCharcterCount = value;}
        //}

        ///// public propaty name  :  CustSlipNoHeader
        ///// <summary>得意先伝票番号ヘッダプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先伝票番号ヘッダプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustSlipNoHeader
        //{
        //    get{return _custSlipNoHeader;}
        //    set{_custSlipNoHeader = value;}
        //}

        ///// public propaty name  :  CustSlipNoFooter
        ///// <summary>得意先伝票番号フッタプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先伝票番号フッタプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CustSlipNoFooter
        //{
        //    get{return _custSlipNoFooter;}
        //    set{_custSlipNoFooter = value;}
        //}
        //--- DEL 2008/06/23 ----------<<<<<

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
		/// 得意先マスタ（変動情報）コンストラクタ
		/// </summary>
		/// <returns>CustomerChangeクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerChangeクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerChange()
		{
		}

		/// <summary>
		/// 得意先マスタ（変動情報）コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerSnm">得意先略称</param>
		/// <param name="creditMoney">与信額</param>
		/// <param name="warningCreditMoney">警告与信額</param>
		/// <param name="prsntAccRecBalance">現在売掛残高(入金データ、売上データ（売掛）を登録する場合にリアルに更新)</param>
		/// <param name="presentCustSlipNo">現在得意先伝票番号</param>
		/// <param name="startCustSlipNo">開始得意先伝票番号</param>
		/// <param name="endCustSlipNo">終了得意先伝票番号</param>
		/// <param name="noCharcterCount">番号桁数(番号桁数≧（終了番号桁数＋ヘッダー桁数＋フッター桁数）であること　番号桁数はMAX19桁)</param>
		/// <param name="custSlipNoHeader">得意先伝票番号ヘッダ</param>
		/// <param name="custSlipNoFooter">得意先伝票番号フッタ</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>CustomerChangeクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerChangeクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public CustomerChange(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSnm, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, Int64 presentCustSlipNo, Int64 startCustSlipNo, Int64 endCustSlipNo, Int32 noCharcterCount, string custSlipNoHeader, string custSlipNoFooter, string enterpriseName, string updEmployeeName)    // DEL 2008/06/23
        public CustomerChange(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, string enterpriseName, string updEmployeeName)      // ADD 2008/06/23
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._customerCode = customerCode;
            //this._customerSnm = customerSnm;      // DEL 2008/06/23
			this._creditMoney = creditMoney;
			this._warningCreditMoney = warningCreditMoney;
			this._prsntAccRecBalance = prsntAccRecBalance;
            //--- DEL 2008/06/23 ---------->>>>>
            //this._presentCustSlipNo = presentCustSlipNo;
            //this._startCustSlipNo = startCustSlipNo;
            //this._endCustSlipNo = endCustSlipNo;
            //this._noCharcterCount = noCharcterCount;
            //this._custSlipNoHeader = custSlipNoHeader;
            //this._custSlipNoFooter = custSlipNoFooter;
            //--- DEL 2008/06/23 ----------<<<<<
            this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 得意先マスタ（変動情報）複製処理
		/// </summary>
		/// <returns>CustomerChangeクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustomerChangeクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerChange Clone()
		{
            //return new CustomerChange(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSnm, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._presentCustSlipNo, this._startCustSlipNo, this._endCustSlipNo, this._noCharcterCount, this._custSlipNoHeader, this._custSlipNoFooter, this._enterpriseName, this._updEmployeeName);     // DEL 2008/06/23
            return new CustomerChange(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._enterpriseName, this._updEmployeeName);       // ADD 2008/06/23
        }

		/// <summary>
		/// 得意先マスタ（変動情報）比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerChangeクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerChangeクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustomerChange target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CustomerCode == target.CustomerCode)
                 //&& (this.CustomerSnm == target.CustomerSnm)              // DEL 2008/06/23
				 && (this.CreditMoney == target.CreditMoney)
				 && (this.WarningCreditMoney == target.WarningCreditMoney)
				 && (this.PrsntAccRecBalance == target.PrsntAccRecBalance)
                 //--- DEL 2008/06/23 ---------->>>>>
                 //&& (this.PresentCustSlipNo == target.PresentCustSlipNo)
                 //&& (this.StartCustSlipNo == target.StartCustSlipNo)
                 //&& (this.EndCustSlipNo == target.EndCustSlipNo)
                 //&& (this.NoCharcterCount == target.NoCharcterCount)
                 //&& (this.CustSlipNoHeader == target.CustSlipNoHeader)
                 //&& (this.CustSlipNoFooter == target.CustSlipNoFooter)
                 //--- DEL 2008/06/23 ----------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 得意先マスタ（変動情報）比較処理
		/// </summary>
		/// <param name="customerChange1">
		///                    比較するCustomerChangeクラスのインスタンス
		/// </param>
		/// <param name="customerChange2">比較するCustomerChangeクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerChangeクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustomerChange customerChange1, CustomerChange customerChange2)
		{
			return ((customerChange1.CreateDateTime == customerChange2.CreateDateTime)
				 && (customerChange1.UpdateDateTime == customerChange2.UpdateDateTime)
				 && (customerChange1.EnterpriseCode == customerChange2.EnterpriseCode)
				 && (customerChange1.FileHeaderGuid == customerChange2.FileHeaderGuid)
				 && (customerChange1.UpdEmployeeCode == customerChange2.UpdEmployeeCode)
				 && (customerChange1.UpdAssemblyId1 == customerChange2.UpdAssemblyId1)
				 && (customerChange1.UpdAssemblyId2 == customerChange2.UpdAssemblyId2)
				 && (customerChange1.LogicalDeleteCode == customerChange2.LogicalDeleteCode)
				 && (customerChange1.CustomerCode == customerChange2.CustomerCode)
                 //&& (customerChange1.CustomerSnm == customerChange2.CustomerSnm)              // DEL 2008/06/23
				 && (customerChange1.CreditMoney == customerChange2.CreditMoney)
				 && (customerChange1.WarningCreditMoney == customerChange2.WarningCreditMoney)
				 && (customerChange1.PrsntAccRecBalance == customerChange2.PrsntAccRecBalance)
                 //--- DEL 2008/06/23 ---------->>>>>
                 //&& (customerChange1.PresentCustSlipNo == customerChange2.PresentCustSlipNo)
                 //&& (customerChange1.StartCustSlipNo == customerChange2.StartCustSlipNo)
                 //&& (customerChange1.EndCustSlipNo == customerChange2.EndCustSlipNo)
                 //&& (customerChange1.NoCharcterCount == customerChange2.NoCharcterCount)
                 //&& (customerChange1.CustSlipNoHeader == customerChange2.CustSlipNoHeader)
                 //&& (customerChange1.CustSlipNoFooter == customerChange2.CustSlipNoFooter)
                 //--- DEL 2008/06/23 ----------<<<<<
                 && (customerChange1.EnterpriseName == customerChange2.EnterpriseName)
				 && (customerChange1.UpdEmployeeName == customerChange2.UpdEmployeeName));
		}
		/// <summary>
		/// 得意先マスタ（変動情報）比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerChangeクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerChangeクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CustomerChange target)
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
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
            //if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");                 // DEL 2008/06/23
			if(this.CreditMoney != target.CreditMoney)resList.Add("CreditMoney");
			if(this.WarningCreditMoney != target.WarningCreditMoney)resList.Add("WarningCreditMoney");
			if(this.PrsntAccRecBalance != target.PrsntAccRecBalance)resList.Add("PrsntAccRecBalance");
            //--- DEL 2008/06/23 ---------->>>>>
            //if(this.PresentCustSlipNo != target.PresentCustSlipNo)resList.Add("PresentCustSlipNo");
            //if(this.StartCustSlipNo != target.StartCustSlipNo)resList.Add("StartCustSlipNo");
            //if(this.EndCustSlipNo != target.EndCustSlipNo)resList.Add("EndCustSlipNo");
            //if(this.NoCharcterCount != target.NoCharcterCount)resList.Add("NoCharcterCount");
            //if(this.CustSlipNoHeader != target.CustSlipNoHeader)resList.Add("CustSlipNoHeader");
            //if(this.CustSlipNoFooter != target.CustSlipNoFooter)resList.Add("CustSlipNoFooter");
            //--- DEL 2008/06/23 ----------<<<<<
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 得意先マスタ（変動情報）比較処理
		/// </summary>
		/// <param name="customerChange1">比較するCustomerChangeクラスのインスタンス</param>
		/// <param name="customerChange2">比較するCustomerChangeクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerChangeクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustomerChange customerChange1, CustomerChange customerChange2)
		{
			ArrayList resList = new ArrayList();
			if(customerChange1.CreateDateTime != customerChange2.CreateDateTime)resList.Add("CreateDateTime");
			if(customerChange1.UpdateDateTime != customerChange2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(customerChange1.EnterpriseCode != customerChange2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(customerChange1.FileHeaderGuid != customerChange2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(customerChange1.UpdEmployeeCode != customerChange2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(customerChange1.UpdAssemblyId1 != customerChange2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(customerChange1.UpdAssemblyId2 != customerChange2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(customerChange1.LogicalDeleteCode != customerChange2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(customerChange1.CustomerCode != customerChange2.CustomerCode)resList.Add("CustomerCode");
            //if(customerChange1.CustomerSnm != customerChange2.CustomerSnm)resList.Add("CustomerSnm");             // DEL 2008/06/23
			if(customerChange1.CreditMoney != customerChange2.CreditMoney)resList.Add("CreditMoney");
			if(customerChange1.WarningCreditMoney != customerChange2.WarningCreditMoney)resList.Add("WarningCreditMoney");
			if(customerChange1.PrsntAccRecBalance != customerChange2.PrsntAccRecBalance)resList.Add("PrsntAccRecBalance");
            //--- DEL 2008/06/23 ---------->>>>>
            //if (customerChange1.PresentCustSlipNo != customerChange2.PresentCustSlipNo) resList.Add("PresentCustSlipNo");
            //if(customerChange1.StartCustSlipNo != customerChange2.StartCustSlipNo)resList.Add("StartCustSlipNo");
            //if(customerChange1.EndCustSlipNo != customerChange2.EndCustSlipNo)resList.Add("EndCustSlipNo");
            //if(customerChange1.NoCharcterCount != customerChange2.NoCharcterCount)resList.Add("NoCharcterCount");
            //if(customerChange1.CustSlipNoHeader != customerChange2.CustSlipNoHeader)resList.Add("CustSlipNoHeader");
            //if(customerChange1.CustSlipNoFooter != customerChange2.CustSlipNoFooter)resList.Add("CustSlipNoFooter");
            //--- DEL 2008/06/23 ----------<<<<<
            if (customerChange1.EnterpriseName != customerChange2.EnterpriseName) resList.Add("EnterpriseName");
			if(customerChange1.UpdEmployeeName != customerChange2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
