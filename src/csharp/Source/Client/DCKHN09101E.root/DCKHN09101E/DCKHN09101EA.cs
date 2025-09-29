using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	///                      掛率優先管理設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   掛率優先管理設定マスタヘッダファイル</br>
	/// <br>Programmer       :   30167 上野　弘貴</br>
	/// <br>Date             :   2007.09.12</br>
    /// <br>UpdateNote       :   30414 忍　幸史</br>
    /// <br>                     単価種類に「5:作業原価」「6:作業単価」追加</br>
    /// <br>UpdateDate       :   2008/06/16</br>
	/// </remarks>
	public class RateProtyMng
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

		/// <summary>単価種類</summary>
		private Int32 _unitPriceKind;

		/// <summary>掛率設定区分</summary>
		private string _rateSettingDivide = "";

		/// <summary>掛率優先順位</summary>
		private Int32 _ratePriorityOrder;

		/// <summary>掛率設定区分（商品）</summary>
		private string _rateMngGoodsCd = "";

		/// <summary>掛率設定名称（商品）</summary>
		private string _rateMngGoodsNm = "";

		/// <summary>掛率設定区分（得意先）</summary>
		private string _rateMngCustCd = "";

		/// <summary>掛率設定名称（得意先）</summary>
		private string _rateMngCustNm = "";

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

		/// public propaty name  :  UnitPriceKind
		/// <summary>単価種類プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価種類プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public Int32 UnitPriceKind
		{
			get { return _unitPriceKind; }
			set { _unitPriceKind = value; }
		}

		/// public propaty name  :  RateSettingDivide
		/// <summary>掛率設定区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public string RateSettingDivide
		{
			get { return _rateSettingDivide; }
			set { _rateSettingDivide = value; }
		}

		/// public propaty name  :  RatePriorityOrder
		/// <summary>掛率優先順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率優先順位プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public Int32 RatePriorityOrder
		{
			get { return _ratePriorityOrder; }
			set { _ratePriorityOrder = value; }
		}

		/// public propaty name  :  RateMngGoodsCd
		/// <summary>掛率設定区分（商品）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（商品）プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public string RateMngGoodsCd
		{
			get { return _rateMngGoodsCd; }
			set { _rateMngGoodsCd = value; }
		}

		/// public propaty name  :  RateMngGoodsNm
		/// <summary>掛率設定名称（商品）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定名称（商品）プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public string RateMngGoodsNm
		{
			get { return _rateMngGoodsNm; }
			set { _rateMngGoodsNm = value; }
		}

		/// public propaty name  :  RateMngCustCd
		/// <summary>掛率設定区分（得意先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（得意先）プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public string RateMngCustCd
		{
			get { return _rateMngCustCd; }
			set { _rateMngCustCd = value; }
		}

		/// public propaty name  :  RateMngCustNm
		/// <summary>掛率設定名称（得意先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定名称（得意先）プロパティ</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public string RateMngCustNm
		{
			get { return _rateMngCustNm; }
			set { _rateMngCustNm = value; }
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
		/// 掛率優先管理設定マスタコンストラクタ
		/// </summary>
		/// <returns>RateProtyMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateProtyMngクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public RateProtyMng()
		{
		}

		/// <summary>
		/// 掛率優先管理設定マスタコンストラクタ
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
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="rateSettingDivide">掛率設定区分</param>
		/// <param name="ratePriorityOrder">掛率優先順位</param>
		/// <param name="rateMngGoodsCd">掛率設定区分（商品）</param>
		/// <param name="rateMngGoodsNm">掛率設定名称（商品）</param>
		/// <param name="rateMngCustCd">掛率設定区分（得意先）</param>
		/// <param name="rateMngCustNm">掛率設定名称（得意先）</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>RateProtyMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateProtyMngクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public RateProtyMng(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 unitPriceKind, string rateSettingDivide, Int32 ratePriorityOrder, string rateMngGoodsCd, string rateMngGoodsNm, string rateMngCustCd, string rateMngCustNm, string enterpriseName, string updEmployeeName)
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
			this._unitPriceKind = unitPriceKind;
			this._rateSettingDivide = rateSettingDivide;
			this._ratePriorityOrder = ratePriorityOrder;
			this._rateMngGoodsCd = rateMngGoodsCd;
			this._rateMngGoodsNm = rateMngGoodsNm;
			this._rateMngCustCd = rateMngCustCd;
			this._rateMngCustNm = rateMngCustNm;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
		}

		/// <summary>
		/// 掛率優先管理設定マスタ複製処理
		/// </summary>
		/// <returns>RateProtyMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいRateProtyMngクラスのインスタンスを返します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public RateProtyMng Clone()
		{
			return new RateProtyMng(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._unitPriceKind, this._rateSettingDivide, this._ratePriorityOrder, this._rateMngGoodsCd, this._rateMngGoodsNm, this._rateMngCustCd, this._rateMngCustNm, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// 掛率優先管理設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のRateProtyMngクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateProtyMngクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public bool Equals(RateProtyMng target)
		{
			return ((this.CreateDateTime	== target.CreateDateTime)
				 && (this.UpdateDateTime	== target.UpdateDateTime)
				 && (this.EnterpriseCode	== target.EnterpriseCode)
				 && (this.FileHeaderGuid	== target.FileHeaderGuid)
				 && (this.UpdEmployeeCode	== target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1	== target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2	== target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode		== target.SectionCode)
				 && (this.UnitPriceKind		== target.UnitPriceKind)
				 && (this.RateSettingDivide == target.RateSettingDivide)
				 && (this.RatePriorityOrder == target.RatePriorityOrder)
				 && (this.RateMngGoodsCd	== target.RateMngGoodsCd)				 
				 && (this.RateMngGoodsNm	== target.RateMngGoodsNm)				 
				 && (this.RateMngCustCd		== target.RateMngCustNm)				 
				 && (this.RateMngCustNm		== target.RateMngCustNm)				 
				 && (this.EnterpriseName	== target.EnterpriseName)
				 && (this.UpdEmployeeName	== target.UpdEmployeeName));
		}

		/// <summary>
		/// 掛率優先管理設定マスタ比較処理
		/// </summary>
		/// <param name="rateProtyMng1">
		///                    比較するRateProtyMngクラスのインスタンス
		/// </param>
		/// <param name="rateProtyMng2">比較するRateProtyMngクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateProtyMngクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public static bool Equals(RateProtyMng rateProtyMng1, RateProtyMng rateProtyMng2)
		{
			return ((rateProtyMng1.CreateDateTime		== rateProtyMng2.CreateDateTime)
				 && (rateProtyMng1.UpdateDateTime		== rateProtyMng2.UpdateDateTime)
				 && (rateProtyMng1.EnterpriseCode		== rateProtyMng2.EnterpriseCode)
				 && (rateProtyMng1.FileHeaderGuid		== rateProtyMng2.FileHeaderGuid)
				 && (rateProtyMng1.UpdEmployeeCode		== rateProtyMng2.UpdEmployeeCode)
				 && (rateProtyMng1.UpdAssemblyId1		== rateProtyMng2.UpdAssemblyId1)
				 && (rateProtyMng1.UpdAssemblyId2		== rateProtyMng2.UpdAssemblyId2)
				 && (rateProtyMng1.LogicalDeleteCode	== rateProtyMng2.LogicalDeleteCode)
				 && (rateProtyMng1.SectionCode			== rateProtyMng2.SectionCode)
				 && (rateProtyMng1.UnitPriceKind		== rateProtyMng2.UnitPriceKind)
				 && (rateProtyMng1.RateSettingDivide	== rateProtyMng2.RateSettingDivide)
				 && (rateProtyMng1.RatePriorityOrder	== rateProtyMng2.RatePriorityOrder)
				 && (rateProtyMng1.RateMngGoodsCd		== rateProtyMng2.RateMngGoodsCd)
				 && (rateProtyMng1.RateMngGoodsNm		== rateProtyMng2.RateMngGoodsNm)
				 && (rateProtyMng1.RateMngCustCd		== rateProtyMng2.RateMngCustCd)
				 && (rateProtyMng1.RateMngCustNm		== rateProtyMng2.RateMngCustNm)
				 && (rateProtyMng1.EnterpriseName		== rateProtyMng2.EnterpriseName)
				 && (rateProtyMng1.UpdEmployeeName		== rateProtyMng2.UpdEmployeeName));
		}
		/// <summary>
		/// 掛率優先管理設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のRateProtyMngクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RateProtyMngクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public ArrayList Compare(RateProtyMng target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime		!= target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime		!= target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode		!= target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid		!= target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode		!= target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1		!= target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2		!= target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode	!= target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SectionCode			!= target.SectionCode)resList.Add("SectionCode");
			if(this.UnitPriceKind		!= target.UnitPriceKind) resList.Add("UnitPriceKind");
			if(this.RateSettingDivide	!= target.RateSettingDivide) resList.Add("RateSettingDivide");
			if(this.RatePriorityOrder	!= target.RatePriorityOrder) resList.Add("RatePriorityOrder");
			if(this.RateMngGoodsCd		!= target.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
			if(this.RateMngGoodsNm		!= target.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
			if(this.RateMngCustCd		!= target.RateMngCustCd) resList.Add("RateMngCustCd");
			if(this.RateMngCustNm		!= target.RateMngCustNm) resList.Add("RateMngCustNm");
			if(this.EnterpriseName		!= target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName		!= target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 掛率優先管理設定マスタ比較処理
		/// </summary>
		/// <param name="rateProtyMng1">比較するRateProtyMngクラスのインスタンス</param>
		/// <param name="rateProtyMng2">比較するRateProtyMngクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShopDailySetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   30167 上野　弘貴</br>
		/// </remarks>
		public static ArrayList Compare(RateProtyMng rateProtyMng1, RateProtyMng rateProtyMng2)
		{
			ArrayList resList = new ArrayList();
			if(rateProtyMng1.CreateDateTime		!= rateProtyMng2.CreateDateTime)resList.Add("CreateDateTime");
			if(rateProtyMng1.UpdateDateTime		!= rateProtyMng2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(rateProtyMng1.EnterpriseCode		!= rateProtyMng2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(rateProtyMng1.FileHeaderGuid		!= rateProtyMng2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(rateProtyMng1.UpdEmployeeCode	!= rateProtyMng2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(rateProtyMng1.UpdAssemblyId1		!= rateProtyMng2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(rateProtyMng1.UpdAssemblyId2		!= rateProtyMng2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(rateProtyMng1.LogicalDeleteCode	!= rateProtyMng2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(rateProtyMng1.SectionCode		!= rateProtyMng2.SectionCode)resList.Add("SectionCode");
			if(rateProtyMng1.UnitPriceKind		!= rateProtyMng2.UnitPriceKind) resList.Add("UnitPriceKind");
			if(rateProtyMng1.RateSettingDivide	!= rateProtyMng2.RateSettingDivide) resList.Add("RateSettingDivide");
			if(rateProtyMng1.RatePriorityOrder	!= rateProtyMng2.RatePriorityOrder) resList.Add("RatePriorityOrder");
			if(rateProtyMng1.RateMngGoodsCd		!= rateProtyMng2.RateMngGoodsCd) resList.Add("RateMngGoodsCd");
			if(rateProtyMng1.RateMngGoodsNm		!= rateProtyMng2.RateMngGoodsNm) resList.Add("RateMngGoodsNm");
			if(rateProtyMng1.RateMngCustCd		!= rateProtyMng2.RateMngCustCd) resList.Add("RateMngCustCd");
			if(rateProtyMng1.RateMngCustNm		!= rateProtyMng2.RateMngCustNm) resList.Add("RateMngCustNm");
			if(rateProtyMng1.EnterpriseName		!= rateProtyMng2.EnterpriseName)resList.Add("EnterpriseName");
			if(rateProtyMng1.UpdEmployeeName	!= rateProtyMng2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 拠点コードリスト
		/// </summary>
		public static SortedList _sectionCodeTable;

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 使用区分リスト
		/// </summary>
		public static SortedList _utilityDivTable;
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
		/// 単価種類リスト
		/// </summary>
		public static SortedList _unitPriceKindTable;

		/// <summary>
		/// 掛率設定管理（商品）リスト
		/// </summary>
		public static SortedList _rateSettingDivideGoodsTable;

		/// <summary>
		/// 掛率設定管理（得意先）リスト
		/// </summary>
		public static SortedList _rateSettingDivideCustTable;

        public static Dictionary<string, int> _ratePriorityOrderDic;

		/// <summary>
		/// 単価種類名称取得処理
		/// </summary>
		/// <param name="unitPriceKindCd"></param>
		/// <remarks>
		/// <br>Note       : 単価種類コードから単価種類名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.26</br>
		/// </remarks>
		public static string GetUnitPriceKindNm(int unitPriceKindCd)
		{
			string retStr = "";

			if (_unitPriceKindTable.ContainsKey((object)unitPriceKindCd))
			{
				retStr = _unitPriceKindTable[unitPriceKindCd].ToString();
			}
			return retStr;
		}
		
        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
		static RateProtyMng()
        {
            /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
			_utilityDivTable = MakeUtilityDivTable();
               --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
            _unitPriceKindTable = MakeUnitPriceKindTable();

            _ratePriorityOrderDic = MakeRatePriorityOrderDic();
		}

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 使用区分リスト生成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : 使用区分のリストを生成します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.12.25</br>
        /// </remarks>
        private static SortedList MakeUtilityDivTable()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "全社共通");
            retSortedList.Add(1, "拠点利用");
            return retSortedList;
        }
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
		/// 単価種類リスト生成
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note	   : 単価種類のリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.26</br>
		/// </remarks>
		private static SortedList MakeUnitPriceKindTable()
		{
			SortedList retSortedList = new SortedList();
            // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
            //retSortedList.Add(1, "売上単価");
            //retSortedList.Add(2, "売上原価");
            //retSortedList.Add(3, "仕入単価");
            //retSortedList.Add(4, "定価");

            retSortedList.Add(1, "売価設定");
            retSortedList.Add(2, "原価設定");
            retSortedList.Add(3, "価格設定");
            // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
			return retSortedList;
		}

        private static Dictionary<string, int> MakeRatePriorityOrderDic()
        {
            Dictionary<string, int> ratePriorityOrderDic = new Dictionary<string, int>();

            ratePriorityOrderDic.Add("1A", 1);
            ratePriorityOrderDic.Add("2A", 2);
            ratePriorityOrderDic.Add("3A", 3);
            ratePriorityOrderDic.Add("4A", 4);
            ratePriorityOrderDic.Add("5A", 5);
            ratePriorityOrderDic.Add("6A", 6);
            ratePriorityOrderDic.Add("1B", 7);
            ratePriorityOrderDic.Add("1C", 8);
            ratePriorityOrderDic.Add("1D", 9);
            ratePriorityOrderDic.Add("1E", 10);
            ratePriorityOrderDic.Add("1F", 11);
            ratePriorityOrderDic.Add("1G", 12);
            ratePriorityOrderDic.Add("1H", 13);
            ratePriorityOrderDic.Add("1I", 14);
            ratePriorityOrderDic.Add("1J", 15);
            ratePriorityOrderDic.Add("1K", 16);
            ratePriorityOrderDic.Add("1L", 17);
            ratePriorityOrderDic.Add("2B", 18);
            ratePriorityOrderDic.Add("2C", 19);
            ratePriorityOrderDic.Add("2D", 20);
            ratePriorityOrderDic.Add("2E", 21);
            ratePriorityOrderDic.Add("2F", 22);
            ratePriorityOrderDic.Add("2G", 23);
            ratePriorityOrderDic.Add("2H", 24);
            ratePriorityOrderDic.Add("2I", 25);
            ratePriorityOrderDic.Add("2J", 26);
            ratePriorityOrderDic.Add("2K", 27);
            ratePriorityOrderDic.Add("2L", 28);
            ratePriorityOrderDic.Add("3B", 29);
            ratePriorityOrderDic.Add("3C", 30);
            ratePriorityOrderDic.Add("3D", 31);
            ratePriorityOrderDic.Add("3E", 32);
            ratePriorityOrderDic.Add("3F", 33);
            ratePriorityOrderDic.Add("3G", 34);
            ratePriorityOrderDic.Add("3H", 35);
            ratePriorityOrderDic.Add("3I", 36);
            ratePriorityOrderDic.Add("3J", 37);
            ratePriorityOrderDic.Add("3K", 38);
            ratePriorityOrderDic.Add("3L", 39);
            ratePriorityOrderDic.Add("4B", 40);
            ratePriorityOrderDic.Add("4C", 41);
            ratePriorityOrderDic.Add("4D", 42);
            ratePriorityOrderDic.Add("4E", 43);
            ratePriorityOrderDic.Add("4F", 44);
            ratePriorityOrderDic.Add("4G", 45);
            ratePriorityOrderDic.Add("4H", 46);
            ratePriorityOrderDic.Add("4I", 47);
            ratePriorityOrderDic.Add("4J", 48);
            ratePriorityOrderDic.Add("4K", 49);
            ratePriorityOrderDic.Add("4L", 50);
            ratePriorityOrderDic.Add("5B", 51);
            ratePriorityOrderDic.Add("5C", 52);
            ratePriorityOrderDic.Add("5D", 53);
            ratePriorityOrderDic.Add("5E", 54);
            ratePriorityOrderDic.Add("5F", 55);
            ratePriorityOrderDic.Add("5G", 56);
            ratePriorityOrderDic.Add("5H", 57);
            ratePriorityOrderDic.Add("5I", 58);
            ratePriorityOrderDic.Add("5J", 59);
            ratePriorityOrderDic.Add("5K", 60);
            ratePriorityOrderDic.Add("5L", 61);
            ratePriorityOrderDic.Add("6B", 62);
            ratePriorityOrderDic.Add("6C", 63);
            ratePriorityOrderDic.Add("6D", 64);
            ratePriorityOrderDic.Add("6E", 65);
            ratePriorityOrderDic.Add("6F", 66);
            ratePriorityOrderDic.Add("6G", 67);
            ratePriorityOrderDic.Add("6H", 68);
            ratePriorityOrderDic.Add("6I", 69);
            ratePriorityOrderDic.Add("6J", 70);
            ratePriorityOrderDic.Add("6K", 71);
            ratePriorityOrderDic.Add("6L", 72);

            return ratePriorityOrderDic;
        }
	}
}
