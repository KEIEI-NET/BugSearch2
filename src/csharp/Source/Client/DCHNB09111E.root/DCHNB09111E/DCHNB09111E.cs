using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesProcMoney
	/// <summary>
	///                      売上金額処理区分設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上金額処理区分設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/08/20  (CSharp File Generated Date)</br>
    /// </remarks>
	public class SalesProcMoney
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

		/// <summary>端数処理対象金額区分</summary>
		/// <remarks>0:売上金額,1:消費税,2:売上単価,3:売上原価単価,4:売上原価金額 3,4は自社用設定のみ</remarks>
		private Int32 _fracProcMoneyDiv;

		/// <summary>端数処理コード</summary>
		/// <remarks>0の場合は自社用(標準)設定とする。</remarks>
		private Int32 _fractionProcCode;

		/// <summary>上限金額</summary>
		/// <remarks>金額の場合は整数のみ設定</remarks>
		private Double _upperLimitPrice;

		/// <summary>端数処理単位</summary>
		private Double _fractionProcUnit;

		/// <summary>端数処理区分</summary>
		/// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
		private Int32 _fractionProcCd;

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

		/// public propaty name  :  FracProcMoneyDiv
		/// <summary>端数処理対象金額区分プロパティ</summary>
		/// <value>0:売上金額,1:消費税,2:売上単価,3:売上原価単価,4:売上原価金額 3,4は自社用設定のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理対象金額区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FracProcMoneyDiv
		{
			get{return _fracProcMoneyDiv;}
			set{_fracProcMoneyDiv = value;}
		}

		/// public propaty name  :  FractionProcCode
		/// <summary>端数処理コードプロパティ</summary>
		/// <value>0の場合は自社用(標準)設定とする。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCode
		{
			get{return _fractionProcCode;}
			set{_fractionProcCode = value;}
		}

		/// public propaty name  :  UpperLimitPrice
		/// <summary>上限金額プロパティ</summary>
		/// <value>金額の場合は整数のみ設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   上限金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double UpperLimitPrice
		{
			get{return _upperLimitPrice;}
			set{_upperLimitPrice = value;}
		}

		/// public propaty name  :  FractionProcUnit
		/// <summary>端数処理単位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double FractionProcUnit
		{
			get{return _fractionProcUnit;}
			set{_fractionProcUnit = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
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
		/// 売上金額処理区分設定マスタコンストラクタ
		/// </summary>
		/// <returns>SalesProcMoneyクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesProcMoney()
		{
		}

		/// <summary>
		/// 売上金額処理区分設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分(0:売上金額,1:消費税,2:売上単価,3:売上原価単価,4:売上原価金額 3,4は自社用設定のみ)</param>
		/// <param name="fractionProcCode">端数処理コード(0の場合は自社用(標準)設定とする。)</param>
		/// <param name="upperLimitPrice">上限金額(金額の場合は整数のみ設定)</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分(1：切捨て,2：四捨五入,3:切上げ)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="fractionProcCdNm">端数処理区分名称</param>
        /// <returns>SalesProcMoneyクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SalesProcMoney( DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice, Double fractionProcUnit, Int32 fractionProcCd, string enterpriseName, string updEmployeeName, string fractionProcCdNm )
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._fracProcMoneyDiv = fracProcMoneyDiv;
			this._fractionProcCode = fractionProcCode;
			this._upperLimitPrice = upperLimitPrice;
			this._fractionProcUnit = fractionProcUnit;
			this._fractionProcCd = fractionProcCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
            this._fractionProcCdNm = fractionProcCdNm;
        }

		/// <summary>
		/// 売上金額処理区分設定マスタ複製処理
		/// </summary>
		/// <returns>SalesProcMoneyクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesProcMoneyクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesProcMoney Clone()
		{
            return new SalesProcMoney(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._fracProcMoneyDiv, this._fractionProcCode, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._enterpriseName, this._updEmployeeName, this._fractionProcCdNm);
		}

		/// <summary>
		/// 売上金額処理区分設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesProcMoneyクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalesProcMoney target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.FracProcMoneyDiv == target.FracProcMoneyDiv)
				 && (this.FractionProcCode == target.FractionProcCode)
				 && (this.UpperLimitPrice == target.UpperLimitPrice)
				 && (this.FractionProcUnit == target.FractionProcUnit)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 売上金額処理区分設定マスタ比較処理
		/// </summary>
		/// <param name="salesProcMoney1">
		///                    比較するSalesProcMoneyクラスのインスタンス
		/// </param>
		/// <param name="salesProcMoney2">比較するSalesProcMoneyクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalesProcMoney salesProcMoney1, SalesProcMoney salesProcMoney2)
		{
			return ((salesProcMoney1.CreateDateTime == salesProcMoney2.CreateDateTime)
				 && (salesProcMoney1.UpdateDateTime == salesProcMoney2.UpdateDateTime)
				 && (salesProcMoney1.EnterpriseCode == salesProcMoney2.EnterpriseCode)
				 && (salesProcMoney1.FileHeaderGuid == salesProcMoney2.FileHeaderGuid)
				 && (salesProcMoney1.UpdEmployeeCode == salesProcMoney2.UpdEmployeeCode)
				 && (salesProcMoney1.UpdAssemblyId1 == salesProcMoney2.UpdAssemblyId1)
				 && (salesProcMoney1.UpdAssemblyId2 == salesProcMoney2.UpdAssemblyId2)
				 && (salesProcMoney1.LogicalDeleteCode == salesProcMoney2.LogicalDeleteCode)
				 && (salesProcMoney1.FracProcMoneyDiv == salesProcMoney2.FracProcMoneyDiv)
				 && (salesProcMoney1.FractionProcCode == salesProcMoney2.FractionProcCode)
				 && (salesProcMoney1.UpperLimitPrice == salesProcMoney2.UpperLimitPrice)
				 && (salesProcMoney1.FractionProcUnit == salesProcMoney2.FractionProcUnit)
				 && (salesProcMoney1.FractionProcCd == salesProcMoney2.FractionProcCd)
				 && (salesProcMoney1.EnterpriseName == salesProcMoney2.EnterpriseName)
				 && (salesProcMoney1.UpdEmployeeName == salesProcMoney2.UpdEmployeeName));
		}
		/// <summary>
		/// 売上金額処理区分設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesProcMoneyクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalesProcMoney target)
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
			if(this.FracProcMoneyDiv != target.FracProcMoneyDiv)resList.Add("FracProcMoneyDiv");
			if(this.FractionProcCode != target.FractionProcCode)resList.Add("FractionProcCode");
			if(this.UpperLimitPrice != target.UpperLimitPrice)resList.Add("UpperLimitPrice");
			if(this.FractionProcUnit != target.FractionProcUnit)resList.Add("FractionProcUnit");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 売上金額処理区分設定マスタ比較処理
		/// </summary>
		/// <param name="salesProcMoney1">比較するSalesProcMoneyクラスのインスタンス</param>
		/// <param name="salesProcMoney2">比較するSalesProcMoneyクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesProcMoneyクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalesProcMoney salesProcMoney1, SalesProcMoney salesProcMoney2)
		{
			ArrayList resList = new ArrayList();
			if(salesProcMoney1.CreateDateTime != salesProcMoney2.CreateDateTime)resList.Add("CreateDateTime");
			if(salesProcMoney1.UpdateDateTime != salesProcMoney2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(salesProcMoney1.EnterpriseCode != salesProcMoney2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesProcMoney1.FileHeaderGuid != salesProcMoney2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(salesProcMoney1.UpdEmployeeCode != salesProcMoney2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(salesProcMoney1.UpdAssemblyId1 != salesProcMoney2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(salesProcMoney1.UpdAssemblyId2 != salesProcMoney2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(salesProcMoney1.LogicalDeleteCode != salesProcMoney2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(salesProcMoney1.FracProcMoneyDiv != salesProcMoney2.FracProcMoneyDiv)resList.Add("FracProcMoneyDiv");
			if(salesProcMoney1.FractionProcCode != salesProcMoney2.FractionProcCode)resList.Add("FractionProcCode");
			if(salesProcMoney1.UpperLimitPrice != salesProcMoney2.UpperLimitPrice)resList.Add("UpperLimitPrice");
			if(salesProcMoney1.FractionProcUnit != salesProcMoney2.FractionProcUnit)resList.Add("FractionProcUnit");
			if(salesProcMoney1.FractionProcCd != salesProcMoney2.FractionProcCd)resList.Add("FractionProcCd");
			if(salesProcMoney1.EnterpriseName != salesProcMoney2.EnterpriseName)resList.Add("EnterpriseName");
			if(salesProcMoney1.UpdEmployeeName != salesProcMoney2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
        }

        #region 手動で追加分

        /// <summary>更新従業員名称</summary>
        private string _fractionProcCdNm = "";

        /// public propaty name  :  FractionProcCdName
        /// <summary>端数処理区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note       : 端数処理区分名称プロパティ（ガイドで使用)</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public string FractionProcCdNm
        {
            get { return _fractionProcCdNm; }
            set { _fractionProcCdNm = value; }
        }

        /// <summary>端数処理対象金額区分リスト</summary>
        private static ArrayList fracProvMoneyDivList;
        /// <summary>端数処理区分リスト</summary>
        private static SortedList fractionProcCdTable;
        private const int CONST_BASIC = 0;
        private const int CONST_OTHER = 1;

        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static SalesProcMoney()
        {
            SalesProcMoney.fracProvMoneyDivList = MakeFrancProvMoneyDivList();
            SalesProcMoney.fractionProcCdTable = MakeFractionProcCdTable();
        }

        /// <summary>
        /// 端数処理対象金額区分リスト生成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 端数処理対象金額区分のリストを生成します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        private static ArrayList MakeFrancProvMoneyDivList()
        {
            ArrayList retList = new ArrayList();
            retList.Add(MakeFrancProvMoneyDivList(CONST_BASIC));
            retList.Add(MakeFrancProvMoneyDivList(CONST_OTHER));
            return retList;
        }

        /// <summary>
        /// 端数処理対象金額区分リスト取得処理
        /// </summary>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <returns>端数処理対象金額区分リスト</returns>
        /// <remarks>
        /// <br>Note		: 端数処理対象金額区分にて使用するコードのリストを取得します。</br>
        /// <br>			: インデックスはGetFracProcMoneyNmList()にて取得出来る名称と一致します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        private static SortedList MakeFrancProvMoneyDivList( Int32 fractionProcCode )
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, new FracProcMoneyDivInfo(0, "売上金額", false));
            retSortedList.Add(1, new FracProcMoneyDivInfo(1, "消費税", false));
            retSortedList.Add(2, new FracProcMoneyDivInfo(2, "売上単価", true));

            // 売上原価単価、売上原価金額は売上金額と同じ扱いのため fractionProcCode による場合分けを削除
            // DEL 2008/09/29 不具合対応[5504]---------->>>>>
            //if (fractionProcCode == CONST_BASIC) // 自社用設定のみ有効な設定
            //{
            //    retSortedList.Add(3, new FracProcMoneyDivInfo(3, "売上原価単価", true));
            //    retSortedList.Add(4, new FracProcMoneyDivInfo(4, "売上原価金額", false));
            //}
            // DEL 2008/09/29 不具合対応[5504]----------<<<<<

            // --- DEL 2009/01/20 障害ID:9815対応------------------------------------------------------>>>>>
            //// ADD 2008/09/29 不具合対応[5504]---------->>>>>
            //retSortedList.Add(3, new FracProcMoneyDivInfo(3, "売上原価単価", true));
            //retSortedList.Add(4, new FracProcMoneyDivInfo(4, "売上原価金額", false));
            //// ADD 2008/09/29 不具合対応[5504]----------<<<<<
            // --- DEL 2009/01/20 障害ID:9815対応------------------------------------------------------<<<<<

            return retSortedList;
        }

        /// <summary>
        /// 端数処理対象金額区分リスト(選択可能分)取得処理
        /// </summary>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <returns>端数処理対象金額区分リスト</returns>
        /// <remarks>
        /// <br>Note       : 端数処理コードに従って、端数処理対象金額区分に設定可能なリストを取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static SortedList GetFracProcMoneyDivTable( Int32 fractionProcCode )
        {
            // 端数処理コードによって選択できる端数処理対象金額区分が変わる
            switch (fractionProcCode)
            {
                case CONST_BASIC:
                    return fracProvMoneyDivList[CONST_BASIC] as SortedList;
                default:
                    return fracProvMoneyDivList[CONST_OTHER] as SortedList;
            }
        }

        /// <summary>
        /// 端数処理対象金額区分名称取得処理
        /// </summary>
        /// <param name="fracProcMoneyDivCd">端数処理対象金額区分</param>
        /// <param name="fractioinProcCode">端数処理コード</param>
        /// <returns>端数処理対象金額区分名称</returns>
        /// <remarks>
        /// <br>Note       : 端数処理コード,端数処理対象金額区分によって、端数処理対象金額区分名称を取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static string GetFracProcMoneyDivNm( Int32 fracProcMoneyDivCd,Int32 fractioinProcCode )
        {
            // DEL 2008/09/29 不具合対応[5504]↓
            //return (GetFracProcMoneyDivTable(fractioinProcCode)[fracProcMoneyDivCd] as FracProcMoneyDivInfo).FracProcMoneyDivName;

            // ADD 2008/09/29 不具合対応[5504]---------->>>>>
            FracProcMoneyDivInfo fracProcMoneyDivInfo = GetFracProcMoneyDivTable(fractioinProcCode)[fracProcMoneyDivCd] as FracProcMoneyDivInfo;
            if (fracProcMoneyDivInfo != null)
            {
                return fracProcMoneyDivInfo.FracProcMoneyDivName;
            }
            else
            {
                return string.Empty;
            }
            // ADD 2008/09/29 不具合対応[5504]----------<<<<<
        }

        /// <summary>
        /// 端数処理対象金額区分 小数点使用有無取得処理
        /// </summary>
        /// <param name="fracProcMoneyDivCd">端数処理対象金額区分値</param>
        /// <returns>小数点使用有無</returns>
        /// <remarks>
        /// <br>Note       : 端数処理対象金額区分値の小数点使用有無を取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static bool GetFracProcMoneyDivIsUseDecimal( Int32 fracProcMoneyDivCd)
        {
            return ( GetFracProcMoneyDivTable(CONST_BASIC)[fracProcMoneyDivCd] as FracProcMoneyDivInfo ).IsUseDecimal;
        }

        /// <summary>
        /// 端数処理区分リスト生成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : 端端数処理区分のリストを生成します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        private static SortedList MakeFractionProcCdTable()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(1, "切捨て");
            retSortedList.Add(2, "四捨五入");
            retSortedList.Add(3, "切上げ");
            return retSortedList;
        }

        /// <summary>
        /// 端数処理対象金額区分リスト(選択可能分)取得処理
        /// </summary>
        /// <returns>端数処理対象金額区分リスト</returns>
        /// <remarks>
        /// <br>Note       : 端数処理コードに従って、端数処理対象金額区分に設定可能なリストを取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static SortedList GetFractionProcCdTable()
        {
            return fractionProcCdTable;
        }

        /// <summary>
        /// 端数処理区分名称取得処理
        /// </summary>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <returns>端数処理区分名称</returns>
        /// <remarks>
        /// <br>Note       : 端数処理区分によって、端数処理区分名称を取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static string GetFractionProcCdNm( Int32 fractionProcCd)
        {
            return fractionProcCdTable[fractionProcCd].ToString();
        }

        /// <summary>
        /// 端数処理区分取得処理
        /// </summary>
        /// <param name="fractionProcCdNm">端数処理区分名称</param>
        /// <returns>端数処理区分</returns>
        /// <remarks>
        /// <br>Note       : 端数処理区分名称に対応する端数処理区分を取得します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static int GetFractionProcCd( string fractionProcCdNm )
        {
            if (fractionProcCdTable.ContainsValue((object)fractionProcCdNm))
            {
                return (int)fractionProcCdTable.GetKey(fractionProcCdTable.IndexOfValue(fractionProcCdNm));
            }
            return 0;
        }

        #endregion

    }

    #region FracProcMoneyDivInfoクラス
    /// private class name:   FracProcMoneyDivInfo
    /// <summary>
    ///                      端数処理対象金額区分情報クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   端数処理対象金額区分クラス</br>
    /// <br>Programmer       :   21024 佐々木 健</br>
    /// <br>Date             :   2007.08.23</br>
    /// </remarks>
    public class FracProcMoneyDivInfo
    {
        private int _fracProcMoneyDivCode;
        private string _fracProcMoneyDivName;
        private bool _isUseDecimal;
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public FracProcMoneyDivInfo()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fracProcMoneyDivCode">区分値</param>
        /// <param name="fracProcMoneyDivName">区分名称</param>
        /// <param name="isUseDecimal">小数使用有無</param>
        public FracProcMoneyDivInfo( int fracProcMoneyDivCode, string fracProcMoneyDivName, bool isUseDecimal )
        {
            this._fracProcMoneyDivCode = fracProcMoneyDivCode;
            this._fracProcMoneyDivName = fracProcMoneyDivName;
            this._isUseDecimal = isUseDecimal;
        }

        /// public propaty name  :  FracProcMoneyDivCode
        /// <summary>端数処理対象金額区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             : 端数処理対象金額区分名称コードプロパティ</br>
        /// <br>Programmer       : 21024 佐々木 健</br>
        /// <br>Date             : 2007.08.23</br>
        /// </remarks>
        public int FracProcMoneyDivCode
        {
            get { return this._fracProcMoneyDivCode; }
            set { this._fracProcMoneyDivCode = value; }
        }

        /// public propaty name  :  FracProcMoneyDivName
        /// <summary>端数処理対象金額区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             : 端数処理対象金額区分名称プロパティ</br>
        /// <br>Programmer       : 21024 佐々木 健</br>
        /// <br>Date             : 2007.08.23</br>
        /// </remarks>
        public string FracProcMoneyDivName
        {
            get { return this._fracProcMoneyDivName; }
            set { this._fracProcMoneyDivName = value; }
        }

        /// public propaty name  :  IsUseDecimal
        /// <summary>小数使用有無プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             : 小数使用有無プロパティ</br>
        /// <br>Programmer       : 21024 佐々木 健</br>
        /// <br>Date             : 2007.08.23</br>
        /// </remarks>
        public bool IsUseDecimal
        {
            get { return this._isUseDecimal; }
            set { this._isUseDecimal = value; }
        }
    }
    #endregion

}
