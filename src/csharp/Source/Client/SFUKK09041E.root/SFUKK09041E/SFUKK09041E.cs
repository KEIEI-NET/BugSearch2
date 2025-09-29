using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MoneyKind
	/// <summary>
	///                      金額種別マスタ（ユーザー登録）
	/// </summary>
	/// <remarks>
	/// <br>note             :   金額種別マスタ（ユーザー登録）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Programmer       :   30415 柴田 倫幸</br>
    /// <br>Date             :   2008/06/12</br>
    /// </remarks>
	public class MoneyKind
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

		/// <summary>金額設定区分</summary>
		/// <remarks>0:入金,1:サービス,2:売掛</remarks>
		private Int32 _priceStCode;

		/// <summary>金種コード</summary>
		/// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
		private Int32 _moneyKindCode;

		/// <summary>金種名称</summary>
		private string _moneyKindName = "";

		/// <summary>金種区分</summary>
		private Int32 _moneyKindDiv;

        /* --- DEL 2008/06/12 -------------------------------->>>>>
		/// <summary>レジ管理区分</summary>
		/// <remarks>0:レジ管理しない, 1:レジ管理する</remarks>
		private Int32 _regiMgCd;
           --- DEL 2008/06/12 --------------------------------<<<<< */
        
        /// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>金種区分名称</summary>
		private string _moneyKindDivName = "";


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

		/// public propaty name  :  PriceStCode
		/// <summary>金額設定区分プロパティ</summary>
		/// <value>0:入金,1:サービス,2:売掛</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   金額設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceStCode
		{
			get{return _priceStCode;}
			set{_priceStCode = value;}
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
			get{return _moneyKindCode;}
			set{_moneyKindCode = value;}
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
			get{return _moneyKindName;}
			set{_moneyKindName = value;}
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
			get{return _moneyKindDiv;}
			set{_moneyKindDiv = value;}
		}

        /* --- DEL 2008/06/12 -------------------------------->>>>>
		/// public propaty name  :  RegiMgCd
		/// <summary>レジ管理区分プロパティ</summary>
		/// <value>0:レジ管理しない, 1:レジ管理する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レジ管理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RegiMgCd
		{
			get{return _regiMgCd;}
			set{_regiMgCd = value;}
		}
           --- DEL 2008/06/12 --------------------------------<<<<< */

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

		/// public propaty name  :  MoneyKindDivName
		/// <summary>金種区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   金種区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MoneyKindDivName
		{
			get{return _moneyKindDivName;}
			set{_moneyKindDivName = value;}
		}


		/// <summary>
		/// 金額種別マスタ（ユーザー登録）コンストラクタ
		/// </summary>
		/// <returns>MoneyKindクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MoneyKindクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MoneyKind()
		{
		}

		/// <summary>
		/// 金額種別マスタ（ユーザー登録）コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="priceStCode">金額設定区分(0:入金,1:サービス,2:売掛)</param>
		/// <param name="moneyKindCode">金種コード(1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金)</param>
		/// <param name="moneyKindName">金種名称</param>
		/// <param name="moneyKindDiv">金種区分</param>
		/// <param name="regiMgCd">レジ管理区分(0:レジ管理しない, 1:レジ管理する)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="moneyKindDivName">金種区分名称</param>
		/// <returns>MoneyKindクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MoneyKindクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public MoneyKind(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 priceStCode,Int32 moneyKindCode,string moneyKindName,Int32 moneyKindDiv,Int32 regiMgCd,string enterpriseName,string updEmployeeName,string moneyKindDivName)
		public MoneyKind(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 priceStCode,Int32 moneyKindCode,string moneyKindName,Int32 moneyKindDiv,string enterpriseName,string updEmployeeName,string moneyKindDivName)
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._priceStCode = priceStCode;
			this._moneyKindCode = moneyKindCode;
			this._moneyKindName = moneyKindName;
			this._moneyKindDiv = moneyKindDiv;
			//this._regiMgCd = regiMgCd;  // DEL 2008/06/12
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._moneyKindDivName = moneyKindDivName;

		}

		/// <summary>
		/// 金額種別マスタ（ユーザー登録）複製処理
		/// </summary>
		/// <returns>MoneyKindクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいMoneyKindクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MoneyKind Clone()
		{
			//return new MoneyKind(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._priceStCode,this._moneyKindCode,this._moneyKindName,this._moneyKindDiv,this._regiMgCd,this._enterpriseName,this._updEmployeeName,this._moneyKindDivName);  // DEL 2008/06/12
            return new MoneyKind(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._priceStCode, this._moneyKindCode, this._moneyKindName, this._moneyKindDiv, this._enterpriseName, this._updEmployeeName, this._moneyKindDivName);  // ADD 2008/06/12
        }

		/// <summary>
		/// 金額種別マスタ（ユーザー登録）比較処理
		/// </summary>
		/// <param name="target">比較対象のMoneyKindクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MoneyKindクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(MoneyKind target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.PriceStCode == target.PriceStCode)
				 && (this.MoneyKindCode == target.MoneyKindCode)
				 && (this.MoneyKindName == target.MoneyKindName)
				 && (this.MoneyKindDiv == target.MoneyKindDiv)
				 //&& (this.RegiMgCd == target.RegiMgCd)  // DEL 2008/06/12
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.MoneyKindDivName == target.MoneyKindDivName));
		}

		/// <summary>
		/// 金額種別マスタ（ユーザー登録）比較処理
		/// </summary>
		/// <param name="moneyKindU1">
		///                    比較するMoneyKindクラスのインスタンス
		/// </param>
		/// <param name="moneyKindU2">比較するMoneyKindクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MoneyKindクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(MoneyKind moneyKindU1, MoneyKind moneyKindU2)
		{
			return ((moneyKindU1.CreateDateTime == moneyKindU2.CreateDateTime)
				 && (moneyKindU1.UpdateDateTime == moneyKindU2.UpdateDateTime)
				 && (moneyKindU1.EnterpriseCode == moneyKindU2.EnterpriseCode)
				 && (moneyKindU1.FileHeaderGuid == moneyKindU2.FileHeaderGuid)
				 && (moneyKindU1.UpdEmployeeCode == moneyKindU2.UpdEmployeeCode)
				 && (moneyKindU1.UpdAssemblyId1 == moneyKindU2.UpdAssemblyId1)
				 && (moneyKindU1.UpdAssemblyId2 == moneyKindU2.UpdAssemblyId2)
				 && (moneyKindU1.LogicalDeleteCode == moneyKindU2.LogicalDeleteCode)
				 && (moneyKindU1.PriceStCode == moneyKindU2.PriceStCode)
				 && (moneyKindU1.MoneyKindCode == moneyKindU2.MoneyKindCode)
				 && (moneyKindU1.MoneyKindName == moneyKindU2.MoneyKindName)
				 && (moneyKindU1.MoneyKindDiv == moneyKindU2.MoneyKindDiv)
				 //&& (moneyKindU1.RegiMgCd == moneyKindU2.RegiMgCd)  // DEL 2008/06/12
				 && (moneyKindU1.EnterpriseName == moneyKindU2.EnterpriseName)
				 && (moneyKindU1.UpdEmployeeName == moneyKindU2.UpdEmployeeName)
				 && (moneyKindU1.MoneyKindDivName == moneyKindU2.MoneyKindDivName));
		}
		/// <summary>
		/// 金額種別マスタ（ユーザー登録）比較処理
		/// </summary>
		/// <param name="target">比較対象のMoneyKindクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MoneyKindクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(MoneyKind target)
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
			if(this.PriceStCode != target.PriceStCode)resList.Add("PriceStCode");
			if(this.MoneyKindCode != target.MoneyKindCode)resList.Add("MoneyKindCode");
			if(this.MoneyKindName != target.MoneyKindName)resList.Add("MoneyKindName");
			if(this.MoneyKindDiv != target.MoneyKindDiv)resList.Add("MoneyKindDiv");
			//if(this.RegiMgCd != target.RegiMgCd)resList.Add("RegiMgCd");  // DEL 2008/06/12
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.MoneyKindDivName != target.MoneyKindDivName)resList.Add("MoneyKindDivName");

			return resList;
		}

		/// <summary>
		/// 金額種別マスタ（ユーザー登録）比較処理
		/// </summary>
		/// <param name="moneyKindU1">比較するMoneyKindクラスのインスタンス</param>
		/// <param name="moneyKindU2">比較するMoneyKindクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MoneyKindクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(MoneyKind moneyKindU1, MoneyKind moneyKindU2)
		{
			ArrayList resList = new ArrayList();
			if(moneyKindU1.CreateDateTime != moneyKindU2.CreateDateTime)resList.Add("CreateDateTime");
			if(moneyKindU1.UpdateDateTime != moneyKindU2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(moneyKindU1.EnterpriseCode != moneyKindU2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(moneyKindU1.FileHeaderGuid != moneyKindU2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(moneyKindU1.UpdEmployeeCode != moneyKindU2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(moneyKindU1.UpdAssemblyId1 != moneyKindU2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(moneyKindU1.UpdAssemblyId2 != moneyKindU2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(moneyKindU1.LogicalDeleteCode != moneyKindU2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(moneyKindU1.PriceStCode != moneyKindU2.PriceStCode)resList.Add("PriceStCode");
			if(moneyKindU1.MoneyKindCode != moneyKindU2.MoneyKindCode)resList.Add("MoneyKindCode");
			if(moneyKindU1.MoneyKindName != moneyKindU2.MoneyKindName)resList.Add("MoneyKindName");
			if(moneyKindU1.MoneyKindDiv != moneyKindU2.MoneyKindDiv)resList.Add("MoneyKindDiv");
			//if(moneyKindU1.RegiMgCd != moneyKindU2.RegiMgCd)resList.Add("RegiMgCd");  // DEL 2008/06/12
			if(moneyKindU1.EnterpriseName != moneyKindU2.EnterpriseName)resList.Add("EnterpriseName");
			if(moneyKindU1.UpdEmployeeName != moneyKindU2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(moneyKindU1.MoneyKindDivName != moneyKindU2.MoneyKindDivName)resList.Add("MoneyKindDivName");

			return resList;
		}
	}
}
