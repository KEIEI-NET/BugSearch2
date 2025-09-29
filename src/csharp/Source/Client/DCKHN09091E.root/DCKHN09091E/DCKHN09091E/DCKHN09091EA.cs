using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BLGoodsCdUMnt
	/// <summary>
	///                      ＢＬ商品コードマスタ(ユーザー)
	/// </summary>
	/// <remarks>
	/// <br>note             :   ＢＬ商品コードマスタ(ユーザー)ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :    </br>
	/// <br>Genarated Date   :   2007/11/01  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       : 2008/06/10 30414　忍　幸史</br>
    /// <br>                 : 「BLグループコード」「BLグループコード名称」「商品掛率グループコード」「商品掛率グループ名称」追加</br>
    /// <br>                 : 「商品区分グループコード」「商品区分グループコード名称」「商品区分コード」「商品区分コード名称」「商品区分詳細」「商品区分詳細名称」削除</br>
	/// </remarks>
	public class BLGoodsCdUMnt
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

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		/// <summary>商品区分グループコード</summary>
		/// <remarks>掛率設定で使用する</remarks>
		private string _largeGoodsGanreCode = "";

		/// <summary>商品区分グループ名称</summary>
		/// <remarks>旧：商品大分類名称</remarks>
		private string _largeGoodsGanreName = "";

		/// <summary>商品区分コード</summary>
		/// <remarks>掛率設定で使用する</remarks>
		private string _mediumGoodsGanreCode = "";

		/// <summary>商品区分名称</summary>
		/// <remarks>旧：商品中分類名称</remarks>
		private string _mediumGoodsGanreName = "";

		/// <summary>商品区分詳細コード</summary>
		private string _detailGoodsGanreCode = "";

		/// <summary>商品区分詳細名称</summary>
		private string _detailGoodsGanreName = "";
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>BL商品コード</summary>
		/// <remarks>提供:1～9999 ユーザー:10000～</remarks>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>BL商品コード名称（半角）</summary>
		private string _bLGoodsHalfName = "";

		/// <summary>BL商品分類</summary>
		/// <remarks>例）1001：バッテリ</remarks>
		private Int32 _bLGoodsGenreCode;

		/// <summary>表示区分</summary>
		private Int32 _division;

		/// <summary>表示区分名称</summary>
		private string _divisionName = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>BLグループコード</summary>
        private Int32 _bLGloupCode;

        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

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

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  LargeGoodsGanreCode
		/// <summary>商品区分グループコードプロパティ</summary>
		/// <value>掛率設定で使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreCode
		{
			get { return _largeGoodsGanreCode; }
			set { _largeGoodsGanreCode = value; }
		}

		/// public propaty name  :  LargeGoodsGanreName
		/// <summary>商品区分グループ名称プロパティ</summary>
		/// <value>旧：商品大分類名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreName
		{
			get { return _largeGoodsGanreName; }
			set { _largeGoodsGanreName = value; }
		}

		/// public propaty name  :  MediumGoodsGanreCode
		/// <summary>商品区分コードプロパティ</summary>
		/// <value>掛率設定で使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreCode
		{
			get { return _mediumGoodsGanreCode; }
			set { _mediumGoodsGanreCode = value; }
		}

		/// public propaty name  :  MediumGoodsGanreName
		/// <summary>商品区分名称プロパティ</summary>
		/// <value>旧：商品中分類名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreName
		{
			get { return _mediumGoodsGanreName; }
			set { _mediumGoodsGanreName = value; }
		}

		/// public propaty name  :  DetailGoodsGanreCode
		/// <summary>商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DetailGoodsGanreCode
		{
			get { return _detailGoodsGanreCode; }
			set { _detailGoodsGanreCode = value; }
		}

		/// public propaty name  :  DetailGoodsGanreName
		/// <summary>商品区分詳細名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分詳細名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DetailGoodsGanreName
		{
			get { return _detailGoodsGanreName; }
			set { _detailGoodsGanreName = value; }
		}
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
        /// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// <value>提供:1～9999 ユーザー:10000～</value>
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

		/// public propaty name  :  BLGoodsHalfName
		/// <summary>BL商品コード名称（半角）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（半角）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsHalfName
		{
			get { return _bLGoodsHalfName; }
			set { _bLGoodsHalfName = value; }
		}

		/// public propaty name  :  BLGoodsGenreCode
		/// <summary>BL商品分類プロパティ</summary>
		/// <value>例）1001：バッテリ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品分類プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsGenreCode
		{
			get { return _bLGoodsGenreCode; }
			set { _bLGoodsGenreCode = value; }
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

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// public property name  :  BLGloupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   30414 忍　幸史</br>
        /// </remarks>
        public Int32 BLGloupCode
        {
            get { return _bLGloupCode; }
            set { _bLGloupCode = value; }
        }

        /// public property name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// <value>中分類をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   30414　忍　幸史</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

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
		/// ＢＬ商品コードマスタ(ユーザー)コンストラクタ
		/// </summary>
		/// <returns>BLGoodsCdUMntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BLGoodsCdUMntクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BLGoodsCdUMnt()
		{
		}

		/// <summary>
		/// ＢＬ商品コードマスタ(ユーザー)コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="bLGoodsCode">BL商品コード(提供:1～9999 ユーザー:10000～)</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
		/// <param name="bLGoodsGenreCode">BL商品分類(例）1001：バッテリ)</param>
		/// <param name="division">表示区分</param>
		/// <param name="divisionName">表示区分名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="bLGloupCode">BLグループコード</param>
        /// <param name="goodsRateGrpCode">商品掛率グループコード</param>
        /// <param name="offerDate">提供日付</param>
        /// <param name="offerDataDiv">提供データ区分</param>
		/// <returns>BLGoodsCdUMntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BLGoodsCdUMntクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		public BLGoodsCdUMnt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string largeGoodsGanreCode, string largeGoodsGanreName, string mediumGoodsGanreCode, string mediumGoodsGanreName, string detailGoodsGanreCode, string detailGoodsGanreName, Int32 bLGoodsCode, string bLGoodsFullName, string bLGoodsHalfName, Int32 bLGoodsGenreCode, Int32 division, string divisionName, string enterpriseName, string updEmployeeName, string bLGoodsName)
		   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        public BLGoodsCdUMnt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 bLGoodsCode, string bLGoodsFullName, string bLGoodsHalfName, Int32 bLGoodsGenreCode, Int32 division, string divisionName, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 bLGloupCode, Int32 goodsRateGrpCode, DateTime offerDate, Int32 offerDataDiv)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			this._largeGoodsGanreCode = largeGoodsGanreCode;
			this._largeGoodsGanreName = largeGoodsGanreName;
			this._mediumGoodsGanreCode = mediumGoodsGanreCode;
			this._mediumGoodsGanreName = mediumGoodsGanreName;
			this._detailGoodsGanreCode = detailGoodsGanreCode;
			this._detailGoodsGanreName = detailGoodsGanreName
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._bLGoodsHalfName = bLGoodsHalfName;
			this._bLGoodsGenreCode = bLGoodsGenreCode;
			this._division = division;
			this._divisionName = divisionName;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            this._bLGloupCode = bLGloupCode;
            this._goodsRateGrpCode = goodsRateGrpCode;
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
            this.OfferDate = offerDate;
            this._offerDataDiv = offerDataDiv;
		}

		/// <summary>
		/// ＢＬ商品コードマスタ(ユーザー)複製処理
		/// </summary>
		/// <returns>BLGoodsCdUMntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいBLGoodsCdUMntクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BLGoodsCdUMnt Clone()
		{
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
            return new BLGoodsCdUMnt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._largeGoodsGanreCode, this._largeGoodsGanreName, this._mediumGoodsGanreCode, this._mediumGoodsGanreName, this._detailGoodsGanreCode, this._detailGoodsGanreName, this._bLGoodsCode, this._bLGoodsFullName, this._bLGoodsHalfName, this._bLGoodsGenreCode, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            return new BLGoodsCdUMnt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._bLGoodsCode, this._bLGoodsFullName, this._bLGoodsHalfName, this._bLGoodsGenreCode, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._bLGloupCode, this._goodsRateGrpCode, this._offerDate, this._offerDataDiv);
		}

		/// <summary>
		/// ＢＬ商品コードマスタ(ユーザー)比較処理
		/// </summary>
		/// <param name="target">比較対象のBLGoodsCdUMntクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BLGoodsCdUMntクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(BLGoodsCdUMnt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
                && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
                && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
                && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
                && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
                && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
                && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
                   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
				 && (this.BLGoodsGenreCode == target.BLGoodsGenreCode)
				 && (this.Division == target.Division)
				 && (this.DivisionName == target.DivisionName)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                 && (this.BLGloupCode == target.BLGloupCode)
                 && (this.GoodsRateGrpCode == target.GoodsRateGrpCode)
                 // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
				 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.OfferDate == target.OfferDate)
                 && (this.OfferDataDiv == target.OfferDataDiv));
		}

		/// <summary>
		/// ＢＬ商品コードマスタ(ユーザー)比較処理
		/// </summary>
		/// <param name="bLGoodsCdUMnt1">
		///                    比較するBLGoodsCdUMntクラスのインスタンス
		/// </param>
		/// <param name="bLGoodsCdUMnt2">比較するBLGoodsCdUMntクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BLGoodsCdUMntクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(BLGoodsCdUMnt bLGoodsCdUMnt1, BLGoodsCdUMnt bLGoodsCdUMnt2)
		{
			return ((bLGoodsCdUMnt1.CreateDateTime == bLGoodsCdUMnt2.CreateDateTime)
				 && (bLGoodsCdUMnt1.UpdateDateTime == bLGoodsCdUMnt2.UpdateDateTime)
				 && (bLGoodsCdUMnt1.EnterpriseCode == bLGoodsCdUMnt2.EnterpriseCode)
				 && (bLGoodsCdUMnt1.FileHeaderGuid == bLGoodsCdUMnt2.FileHeaderGuid)
				 && (bLGoodsCdUMnt1.UpdEmployeeCode == bLGoodsCdUMnt2.UpdEmployeeCode)
				 && (bLGoodsCdUMnt1.UpdAssemblyId1 == bLGoodsCdUMnt2.UpdAssemblyId1)
				 && (bLGoodsCdUMnt1.UpdAssemblyId2 == bLGoodsCdUMnt2.UpdAssemblyId2)
				 && (bLGoodsCdUMnt1.LogicalDeleteCode == bLGoodsCdUMnt2.LogicalDeleteCode)
                /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
                && (bLGoodsCdUMnt1.LargeGoodsGanreCode == bLGoodsCdUMnt2.LargeGoodsGanreCode)
                && (bLGoodsCdUMnt1.LargeGoodsGanreName == bLGoodsCdUMnt2.LargeGoodsGanreName)
                && (bLGoodsCdUMnt1.MediumGoodsGanreCode == bLGoodsCdUMnt2.MediumGoodsGanreCode)
                && (bLGoodsCdUMnt1.MediumGoodsGanreName == bLGoodsCdUMnt2.MediumGoodsGanreName)
                && (bLGoodsCdUMnt1.DetailGoodsGanreCode == bLGoodsCdUMnt2.DetailGoodsGanreCode)
                && (bLGoodsCdUMnt1.DetailGoodsGanreName == bLGoodsCdUMnt2.DetailGoodsGanreName)
                   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                 && (bLGoodsCdUMnt1.BLGoodsCode == bLGoodsCdUMnt2.BLGoodsCode)
				 && (bLGoodsCdUMnt1.BLGoodsFullName == bLGoodsCdUMnt2.BLGoodsFullName)
				 && (bLGoodsCdUMnt1.BLGoodsHalfName == bLGoodsCdUMnt2.BLGoodsHalfName)
				 && (bLGoodsCdUMnt1.BLGoodsGenreCode == bLGoodsCdUMnt2.BLGoodsGenreCode)
				 && (bLGoodsCdUMnt1.Division == bLGoodsCdUMnt2.Division)
				 && (bLGoodsCdUMnt1.DivisionName == bLGoodsCdUMnt2.DivisionName)
				 && (bLGoodsCdUMnt1.EnterpriseName == bLGoodsCdUMnt2.EnterpriseName)
				 && (bLGoodsCdUMnt1.UpdEmployeeName == bLGoodsCdUMnt2.UpdEmployeeName)
                 // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                 && (bLGoodsCdUMnt1.BLGloupCode == bLGoodsCdUMnt2.BLGloupCode)
                 && (bLGoodsCdUMnt1.GoodsRateGrpCode == bLGoodsCdUMnt2.GoodsRateGrpCode)
                 // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
				 && (bLGoodsCdUMnt1.BLGoodsName == bLGoodsCdUMnt2.BLGoodsName)
                 && (bLGoodsCdUMnt1.OfferDate == bLGoodsCdUMnt2.OfferDate)
                 && (bLGoodsCdUMnt1.OfferDataDiv == bLGoodsCdUMnt2.OfferDataDiv));
		}
		/// <summary>
		/// ＢＬ商品コードマスタ(ユーザー)比較処理
		/// </summary>
		/// <param name="target">比較対象のBLGoodsCdUMntクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BLGoodsCdUMntクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(BLGoodsCdUMnt target)
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
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			if (this.LargeGoodsGanreCode != target.LargeGoodsGanreCode) resList.Add("LargeGoodsGanreCode");
			if (this.LargeGoodsGanreName != target.LargeGoodsGanreName) resList.Add("LargeGoodsGanreName");
			if (this.MediumGoodsGanreCode != target.MediumGoodsGanreCode) resList.Add("MediumGoodsGanreCode");
			if (this.MediumGoodsGanreName != target.MediumGoodsGanreName) resList.Add("MediumGoodsGanreName");
			if (this.DetailGoodsGanreCode != target.DetailGoodsGanreCode) resList.Add("DetailGoodsGanreCode");
			if (this.DetailGoodsGanreName != target.DetailGoodsGanreName) resList.Add("DetailGoodsGanreName");
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
			if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
			if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
			if (this.BLGoodsGenreCode != target.BLGoodsGenreCode) resList.Add("BLGoodsGenreCode");
			if (this.Division != target.Division) resList.Add("Division");
			if (this.DivisionName != target.DivisionName) resList.Add("DivisionName");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
			if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            if (this.BLGloupCode != target.BLGloupCode) resList.Add("BLGloupCode");
            if (this.GoodsRateGrpCode != target.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");

			return resList;
		}

		/// <summary>
		/// ＢＬ商品コードマスタ(ユーザー)比較処理
		/// </summary>
		/// <param name="bLGoodsCdUMnt1">比較するBLGoodsCdUMntクラスのインスタンス</param>
		/// <param name="bLGoodsCdUMnt2">比較するBLGoodsCdUMntクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BLGoodsCdUMntクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(BLGoodsCdUMnt bLGoodsCdUMnt1, BLGoodsCdUMnt bLGoodsCdUMnt2)
		{
			ArrayList resList = new ArrayList();
			if (bLGoodsCdUMnt1.CreateDateTime != bLGoodsCdUMnt2.CreateDateTime) resList.Add("CreateDateTime");
			if (bLGoodsCdUMnt1.UpdateDateTime != bLGoodsCdUMnt2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (bLGoodsCdUMnt1.EnterpriseCode != bLGoodsCdUMnt2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (bLGoodsCdUMnt1.FileHeaderGuid != bLGoodsCdUMnt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (bLGoodsCdUMnt1.UpdEmployeeCode != bLGoodsCdUMnt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (bLGoodsCdUMnt1.UpdAssemblyId1 != bLGoodsCdUMnt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (bLGoodsCdUMnt1.UpdAssemblyId2 != bLGoodsCdUMnt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (bLGoodsCdUMnt1.LogicalDeleteCode != bLGoodsCdUMnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			if (bLGoodsCdUMnt1.LargeGoodsGanreCode != bLGoodsCdUMnt2.LargeGoodsGanreCode) resList.Add("LargeGoodsGanreCode");
			if (bLGoodsCdUMnt1.LargeGoodsGanreName != bLGoodsCdUMnt2.LargeGoodsGanreName) resList.Add("LargeGoodsGanreName");
			if (bLGoodsCdUMnt1.MediumGoodsGanreCode != bLGoodsCdUMnt2.MediumGoodsGanreCode) resList.Add("MediumGoodsGanreCode");
			if (bLGoodsCdUMnt1.MediumGoodsGanreName != bLGoodsCdUMnt2.MediumGoodsGanreName) resList.Add("MediumGoodsGanreName");
			if (bLGoodsCdUMnt1.DetailGoodsGanreCode != bLGoodsCdUMnt2.DetailGoodsGanreCode) resList.Add("DetailGoodsGanreCode");
			if (bLGoodsCdUMnt1.DetailGoodsGanreName != bLGoodsCdUMnt2.DetailGoodsGanreName) resList.Add("DetailGoodsGanreName");
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            if (bLGoodsCdUMnt1.BLGoodsCode != bLGoodsCdUMnt2.BLGoodsCode) resList.Add("BLGoodsCode");
			if (bLGoodsCdUMnt1.BLGoodsFullName != bLGoodsCdUMnt2.BLGoodsFullName) resList.Add("BLGoodsFullName");
			if (bLGoodsCdUMnt1.BLGoodsHalfName != bLGoodsCdUMnt2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
			if (bLGoodsCdUMnt1.BLGoodsGenreCode != bLGoodsCdUMnt2.BLGoodsGenreCode) resList.Add("BLGoodsGenreCode");
			if (bLGoodsCdUMnt1.Division != bLGoodsCdUMnt2.Division) resList.Add("Division");
			if (bLGoodsCdUMnt1.DivisionName != bLGoodsCdUMnt2.DivisionName) resList.Add("DivisionName");
			if (bLGoodsCdUMnt1.EnterpriseName != bLGoodsCdUMnt2.EnterpriseName) resList.Add("EnterpriseName");
			if (bLGoodsCdUMnt1.UpdEmployeeName != bLGoodsCdUMnt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
			if (bLGoodsCdUMnt1.BLGoodsName != bLGoodsCdUMnt2.BLGoodsName) resList.Add("BLGoodsName");
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            if (bLGoodsCdUMnt1.BLGloupCode != bLGoodsCdUMnt2.BLGloupCode) resList.Add("BLGloupCode");
            if (bLGoodsCdUMnt1.GoodsRateGrpCode != bLGoodsCdUMnt2.GoodsRateGrpCode) resList.Add("GoodsRateGrpCode");
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
            if (bLGoodsCdUMnt1.OfferDate != bLGoodsCdUMnt2.OfferDate) resList.Add("OfferDate");
            if (bLGoodsCdUMnt1.OfferDataDiv != bLGoodsCdUMnt2.OfferDataDiv) resList.Add("OfferDataDiv");

			return resList;
		}
	}
}
