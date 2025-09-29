using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MakerUMnt
	/// <summary>
	///                      メーカーマスタ（ユーザー登録分）
	/// </summary>
	/// <remarks>
	/// <br>note             :   メーカーマスタ（ユーザー登録分）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/08/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class MakerUMnt
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
		/// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>メーカー略称</summary>
		private string _makerShortName = "";

		/// <summary>メーカーカナ名称</summary>
		private string _makerKanaName = "";

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>表示区分</summary>
		private Int32 _division;

		/// <summary>表示区分名称</summary>
		private string _divisionName = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>提供データ区分</summary>
        /// <remarks>0:提供データ,1:ユーザーデータ</remarks>
        private Int32 _offerDataDiv;


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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
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
		/// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

		/// public propaty name  :  Division
		/// <summary>表示区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Division
		{
			get { return _division; }
			set { _division = value; }
		}

		/// public propaty name  :  DivisionName
		/// <summary>表示区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DivisionName
		{
			get { return _divisionName; }
			set { _divisionName = value; }
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

        /// public propaty name  :  OfferDate
        /// <summary>提供日付</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分</summary>
        /// <value>0:提供データ,1:ユーザーデータ</value>
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

		/// <summary>
		/// メーカーマスタ（ユーザー登録分）コンストラクタ
		/// </summary>
		/// <returns>MakerUMntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MakerUMntクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MakerUMnt()
		{
		}

		/// <summary>
		/// メーカーマスタ（ユーザー登録分）コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="goodsMakerCd">商品メーカーコード(ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる)</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="makerShortName">メーカー略称</param>
		/// <param name="makerKanaName">メーカーカナ名称</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="division">表示区分</param>
		/// <param name="divisionName">表示区分名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="offerDate">提供日付</param>
        /// <param name="offerDataDiv">提供データ区分</param>
		/// <returns>MakerUMntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MakerUMntクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MakerUMnt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string makerName, string makerShortName, string makerKanaName, Int32 displayOrder, Int32 division, string divisionName, string enterpriseName, string updEmployeeName, DateTime offerDate, Int32 offerDataDiv)
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
			this._displayOrder = displayOrder;
			this._division = division;
			this._divisionName = divisionName;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
            this.OfferDate = offerDate;
            this._offerDataDiv = offerDataDiv;

		}

		/// <summary>
		/// メーカーマスタ（ユーザー登録分）複製処理
		/// </summary>
		/// <returns>MakerUMntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいMakerUMntクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MakerUMnt Clone()
		{
			return new MakerUMnt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._makerName, this._makerShortName, this._makerKanaName, this._displayOrder, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName, this._offerDate, this._offerDataDiv);
		}

		/// <summary>
		/// メーカーマスタ（ユーザー登録分）比較処理
		/// </summary>
		/// <param name="target">比較対象のMakerUMntクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MakerUMntクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(MakerUMnt target)
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
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.Division == target.Division)
				 && (this.DivisionName == target.DivisionName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.OfferDate == target.OfferDate)
                 && (this.OfferDataDiv == target.OfferDataDiv));
		}

		/// <summary>
		/// メーカーマスタ（ユーザー登録分）比較処理
		/// </summary>
		/// <param name="makerUMnt1">
		///                    比較するMakerUMntクラスのインスタンス
		/// </param>
		/// <param name="makerUMnt2">比較するMakerUMntクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MakerUMntクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(MakerUMnt makerUMnt1, MakerUMnt makerUMnt2)
		{
			return ((makerUMnt1.CreateDateTime == makerUMnt2.CreateDateTime)
				 && (makerUMnt1.UpdateDateTime == makerUMnt2.UpdateDateTime)
				 && (makerUMnt1.EnterpriseCode == makerUMnt2.EnterpriseCode)
				 && (makerUMnt1.FileHeaderGuid == makerUMnt2.FileHeaderGuid)
				 && (makerUMnt1.UpdEmployeeCode == makerUMnt2.UpdEmployeeCode)
				 && (makerUMnt1.UpdAssemblyId1 == makerUMnt2.UpdAssemblyId1)
				 && (makerUMnt1.UpdAssemblyId2 == makerUMnt2.UpdAssemblyId2)
				 && (makerUMnt1.LogicalDeleteCode == makerUMnt2.LogicalDeleteCode)
				 && (makerUMnt1.GoodsMakerCd == makerUMnt2.GoodsMakerCd)
				 && (makerUMnt1.MakerName == makerUMnt2.MakerName)
				 && (makerUMnt1.MakerShortName == makerUMnt2.MakerShortName)
				 && (makerUMnt1.MakerKanaName == makerUMnt2.MakerKanaName)
				 && (makerUMnt1.DisplayOrder == makerUMnt2.DisplayOrder)
				 && (makerUMnt1.Division == makerUMnt2.Division)
				 && (makerUMnt1.DivisionName == makerUMnt2.DivisionName)
				 && (makerUMnt1.EnterpriseName == makerUMnt2.EnterpriseName)
				 && (makerUMnt1.UpdEmployeeName == makerUMnt2.UpdEmployeeName)
                 && (makerUMnt1.OfferDate == makerUMnt2.OfferDate)
                 && (makerUMnt1.OfferDataDiv == makerUMnt2.OfferDataDiv));
		}
		/// <summary>
		/// メーカーマスタ（ユーザー登録分）比較処理
		/// </summary>
		/// <param name="target">比較対象のMakerUMntクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MakerUMntクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(MakerUMnt target)
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
			if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
			if (this.Division != target.Division) resList.Add("Division");
			if (this.DivisionName != target.DivisionName) resList.Add("DivisionName");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");

			return resList;
		}

		/// <summary>
		/// メーカーマスタ（ユーザー登録分）比較処理
		/// </summary>
		/// <param name="makerUMnt1">比較するMakerUMntクラスのインスタンス</param>
		/// <param name="makerUMnt2">比較するMakerUMntクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MakerUMntクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(MakerUMnt makerUMnt1, MakerUMnt makerUMnt2)
		{
			ArrayList resList = new ArrayList();
			if (makerUMnt1.CreateDateTime != makerUMnt2.CreateDateTime) resList.Add("CreateDateTime");
			if (makerUMnt1.UpdateDateTime != makerUMnt2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (makerUMnt1.EnterpriseCode != makerUMnt2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (makerUMnt1.FileHeaderGuid != makerUMnt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (makerUMnt1.UpdEmployeeCode != makerUMnt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (makerUMnt1.UpdAssemblyId1 != makerUMnt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (makerUMnt1.UpdAssemblyId2 != makerUMnt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (makerUMnt1.LogicalDeleteCode != makerUMnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (makerUMnt1.GoodsMakerCd != makerUMnt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
			if (makerUMnt1.MakerName != makerUMnt2.MakerName) resList.Add("MakerName");
			if (makerUMnt1.MakerShortName != makerUMnt2.MakerShortName) resList.Add("MakerShortName");
			if (makerUMnt1.MakerKanaName != makerUMnt2.MakerKanaName) resList.Add("MakerKanaName");
			if (makerUMnt1.DisplayOrder != makerUMnt2.DisplayOrder) resList.Add("DisplayOrder");
			if (makerUMnt1.Division != makerUMnt2.Division) resList.Add("Division");
			if (makerUMnt1.DivisionName != makerUMnt2.DivisionName) resList.Add("DivisionName");
			if (makerUMnt1.EnterpriseName != makerUMnt2.EnterpriseName) resList.Add("EnterpriseName");
			if (makerUMnt1.UpdEmployeeName != makerUMnt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (makerUMnt1.OfferDate != makerUMnt2.OfferDate) resList.Add("OfferDate");
            if (makerUMnt1.OfferDataDiv != makerUMnt2.OfferDataDiv) resList.Add("OfferDataDiv");

			return resList;
		}
	}
}
