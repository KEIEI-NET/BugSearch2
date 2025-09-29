//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先検索
// プログラム概要   ：得意先の検索を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/05/07     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/09/04     修正内容：更新日時を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2009/02/12     修正内容：得意先伝票番号区分を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/08     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/19     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号  10504551-00    作成担当：30517 夏野 駿希
// 修正日    2009/12/02     修正内容：MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加
// ---------------------------------------------------------------------//
// 管理番号  10601193-00    作成担当：21024 佐々木 健
// 修正日    2010/04/06     修正内容：オンライン種別区分 追加
// ---------------------------------------------------------------------//
// 管理番号  10601193-00    作成担当：30434 工藤 恵優
// 修正日    2010/06/26     修正内容：簡単問合せアカウントグループID 追加
// ---------------------------------------------------------------------//
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22024 寺坂 誉志
// 修正日    2012.04.10     修正内容：顧客担当従業員名称 追加
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerSearchRet
	/// <summary>
	///                      得意先検索結果クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先検索結果クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/02/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2008.09.04 30452 上野 俊治</br>
    /// <br>                   更新日時を追加</br>
    /// <br>Update Note      : 2009.02.12 30452 上野 俊治</br>
    /// <br>                   得意先伝票番号区分を追加</br>
    /// <br>Update Note      : 2009/12/02 30517 夏野 駿希</br>
    /// <br>                   MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加</br>
    /// <br>Update Note      : 2010/04/06 21024 佐々木 健</br>
    /// <br>                   オンライン種別区分 追加</br>
    /// <br>Update Note      : 2010/06/26 30434 工藤 恵優</br>
    /// <br>                   簡単問合せアカウントグループID 追加</br>
	/// <br>Update Note      : 2012.04.10 22024 寺坂 誉志</br>
	/// <br>                   顧客担当従業員名称 追加</br>
	/// </remarks>
	[Serializable]	
	public class CustomerSearchRet
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先サブコード</summary>
		private string _customerSubCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>名称２</summary>
		private string _name2 = "";

        /// <summary>略称</summary>
        private string _snm = "";

		/// <summary>カナ</summary>
		private string _kana = "";

		/// <summary>敬称</summary>
		private string _honorificTitle = "";

		/// <summary>電話番号（検索用下4桁）</summary>
		private string _searchTelNo = "";

		/// <summary>電話番号（自宅）</summary>
		/// <remarks>ハイフンを含めた16桁の番号</remarks>
		private string _homeTelNo = "";

		/// <summary>電話番号（勤務先）</summary>
		private string _officeTelNo = "";

		/// <summary>電話番号（携帯）</summary>
		private string _portableTelNo = "";

		/// <summary>郵便番号</summary>
		private string _postNo = "";

		/// <summary>住所１（都道府県市区郡・町村・字）</summary>
		private string _address1 = "";

		/// <summary>住所３（番地）</summary>
		private string _address3 = "";

		/// <summary>住所４（アパート名称）</summary>
		private string _address4 = "";

		/// <summary>締日</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>得意先論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>業販先区分</summary>
		/// <remarks>0:業販先以外,1:業販先</remarks>
		private Int32 _acceptWholeSale;

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>得意先伝票番号区分</summary>
        private Int32 _customerSlipNoDiv;
        // --- ADD 2009/02/12 --------------------------------<<<<<

        // ADD 2009/06/08 ------>>>
        /// <summary>得意先企業コード</summary>
        private string _customerEpCode = string.Empty;

        /// <summary>得意先拠点コード</summary>
        private string _customerSecCode = string.Empty;
        // ADD 2009/06/08 ------<<<

        // --- ADD 2009/06/19 -------------------------------->>>>>
        /// <summary>顧客担当従業員コード</summary>
        private string _customerAgentCd;
        // --- ADD 2009/06/19 --------------------------------<<<<<

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// <summary>顧客担当従業員名称</summary>
        private string _customerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>更新日付</summary>
        private DateTime _updateDate;
        // --- ADD 2008/09/04 --------------------------------<<<<<

        // 2009/12/02 Add >>>
        /// <summary>FAX番号（自宅）</summary>
        /// <remarks>ハイフンを含めた16桁の番号</remarks>
        private string _homeFaxNo = "";

        /// <summary>FAX番号（勤務先）</summary>
        private string _officeFaxNo = "";
        // 2009/12/02 Add <<<

        // 2010/04/06 Add >>>
        /// <summary>オンライン種別区分</summary>
        private int _onlineKindDiv;
        // 2010/04/06 Add <<<

        // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ---------->>>>>
        /// <summary>簡単問合せアカウントグループID</summary>
        /// <remarks>(半角英数)</remarks>
        private string _simplInqAcntAcntGrId;
        // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ----------<<<<<

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

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get { return _customerCode; }
			set { _customerCode = value; }
		}

		/// public propaty name  :  CustomerSubCode
		/// <summary>得意先サブコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSubCode
		{
			get { return _customerSubCode; }
			set { _customerSubCode = value; }
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// public propaty name  :  Name2
		/// <summary>名称２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name2
		{
			get { return _name2; }
			set { _name2 = value; }
		}

        /// public propaty name  :  Snm
        /// <summary>略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Snm
        {
            get { return _snm; }
            set { _snm = value; }
        }

		/// public propaty name  :  Kana
		/// <summary>カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Kana
		{
			get { return _kana; }
			set { _kana = value; }
		}

		/// public propaty name  :  HonorificTitle
		/// <summary>敬称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   敬称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HonorificTitle
		{
			get { return _honorificTitle; }
			set { _honorificTitle = value; }
		}

		/// public propaty name  :  SearchTelNo
		/// <summary>電話番号（検索用下4桁）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（検索用下4桁）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SearchTelNo
		{
			get { return _searchTelNo; }
			set { _searchTelNo = value; }
		}

		/// public propaty name  :  HomeTelNo
		/// <summary>電話番号（自宅）プロパティ</summary>
		/// <value>ハイフンを含めた16桁の番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（自宅）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeTelNo
		{
			get { return _homeTelNo; }
			set { _homeTelNo = value; }
		}

		/// public propaty name  :  OfficeTelNo
		/// <summary>電話番号（勤務先）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（勤務先）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeTelNo
		{
			get { return _officeTelNo; }
			set { _officeTelNo = value; }
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>電話番号（携帯）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   電話番号（携帯）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PortableTelNo
		{
			get { return _portableTelNo; }
			set { _portableTelNo = value; }
		}

		/// public propaty name  :  PostNo
		/// <summary>郵便番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PostNo
		{
			get { return _postNo; }
			set { _postNo = value; }
		}

		/// public propaty name  :  Address1
		/// <summary>住所１（都道府県市区郡・町村・字）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所１（都道府県市区郡・町村・字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address1
		{
			get { return _address1; }
			set { _address1 = value; }
		}

		/// public propaty name  :  Address3
		/// <summary>住所３（番地）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所３（番地）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address3
		{
			get { return _address3; }
			set { _address3 = value; }
		}

		/// public propaty name  :  Address4
		/// <summary>住所４（アパート名称）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所４（アパート名称）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Address4
		{
			get { return _address4; }
			set { _address4 = value; }
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get { return _totalDay; }
			set { _totalDay = value; }
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>得意先論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

        /// public propaty name  :  AcceptWholeSale
		/// <summary>業販先区分プロパティ</summary>
		/// <value>0:業販先以外,1:業販先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業販先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcceptWholeSale
		{
			get { return _acceptWholeSale; }
			set { _acceptWholeSale = value; }
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// public propaty name  :  UpdateDate
        /// <summary>更新日付</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日付</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        // --- ADD 2008/09/04 --------------------------------<<<<<

        // 2009/12/02 Add >>>
        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }
        // 2009/12/02 Add <<<

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>得意先伝票番号区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日付</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<

        // ADD 2009/06/08 ------>>>
        /// public propaty name  :  CustomerEpCode
        /// <summary>得意先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>得意先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }
        // ADD 2009/06/08 ------<<<

        // --- ADD 2009/06/19 -------------------------------->>>>>
        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コード</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }
        // --- ADD 2009/06/19 --------------------------------<<<<<

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2010/04/06 Add >>>
        /// public propaty name  :  OnlineKindDiv
        /// <summary>オンライン種別区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン種別区分プロパティ</br>
        /// <br>Programer        :   21024 佐々木 健</br>
        /// </remarks>
        public int OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
        // 2010/04/06 Add <<<
        // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ---------->>>>>
        /// public propaty name  :  SimplInqAcntAcntGrId
        /// <summary>簡単問合せアカウントグループID</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せアカウントグループIDプロパティ</br>
        /// <br>Programer        :   30434 工藤</br>
        /// </remarks>
        public string SimplInqAcntAcntGrId
        {
            get { return _simplInqAcntAcntGrId; }
            set { _simplInqAcntAcntGrId = value; }
        }
        // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ----------<<<<<

		/// <summary>
		/// 得意先検索結果クラスコンストラクタ
		/// </summary>
		/// <returns>CustomerSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerSearchRet()
		{
		}

		/// <summary>
		/// 得意先検索結果クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerSubCode">得意先サブコード</param>
		/// <param name="name">名称</param>
		/// <param name="name2">名称２</param>
        /// <param name="snm">略称</param>
		/// <param name="kana">カナ</param>
		/// <param name="honorificTitle">敬称</param>
		/// <param name="searchTelNo">電話番号（検索用下4桁）</param>
		/// <param name="homeTelNo">電話番号（自宅）(ハイフンを含めた16桁の番号)</param>
		/// <param name="officeTelNo">電話番号（勤務先）</param>
		/// <param name="portableTelNo">電話番号（携帯）</param>
		/// <param name="postNo">郵便番号</param>
		/// <param name="address1">住所１（都道府県市区郡・町村・字）</param>
		/// <param name="address3">住所３（番地）</param>
		/// <param name="address4">住所４（アパート名称）</param>
		/// <param name="totalDay">締日(DD)</param>
		/// <param name="logicalDeleteCode">得意先論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="acceptWholeSale">業販先区分(0:業販先以外,1:業販先)</param>
		/// <param name="enterpriseName">企業名称</param>
        /// <param name="mngSectionCode">管理拠点コード</param>
        /// <param name="customerEpCode">得意先企業コード</param>
        /// <param name="customerSecCode">得意先拠点コード</param>
		/// <param name="customerAgentCd">顧客担当従業員コード</param>
		/// <param name="customerAgentNm">顧客担当従業員名称</param>
        /// <param name="updateDate">更新日時</param>
		/// <returns>CustomerSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        // 2010/04/06 >>>
        //// 2009/06/19 >>>
        //////public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, DateTime updateDate)
        ////// 2009/12/02 >>>
        //////public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, DateTime updateDate)
        ////public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, DateTime updateDate, string homeFaxNo, string OfficeFaxNo)
        ////// 2009/12/02 <<<
        //public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, string customerAgentCd, DateTime updateDate, string homeFaxNo, string OfficeFaxNo)
        //// 2009/06/19 <<<

		#region 2012.04.10 TERASAKA DEL STA
//        public CustomerSearchRet(
//            string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, string customerAgentCd, DateTime updateDate, string homeFaxNo, string OfficeFaxNo, int onlineKindDiv
//            , string simplInqAcntAcntGrId  // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応
//        )
		#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        public CustomerSearchRet(
			string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, string customerAgentCd, string customerAgentNm, DateTime updateDate, string homeFaxNo, string OfficeFaxNo, int onlineKindDiv
            , string simplInqAcntAcntGrId
        )
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        // 2010/04/06 <<<
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._name = name;
            this._name2 = name2;
            this._snm = snm;
            this._kana = kana;
            this._honorificTitle = honorificTitle;
            this._searchTelNo = searchTelNo;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;

            // 2009/12/02 Add >>>
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = OfficeFaxNo;
            // 2009/12/02 Add <<<

            this._postNo = postNo;
            this._address1 = address1;
            this._address3 = address3;
            this._address4 = address4;
            this._totalDay = totalDay;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acceptWholeSale = acceptWholeSale;
            this._enterpriseName = enterpriseName;
            this._mngSectionCode = mngSectionCode;
            // ADD 2009/06/08 ------>>>
            this._customerEpCode = customerEpCode;
            this._customerSecCode = customerSecCode;
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            this._customerAgentCd = customerAgentCd;
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            this._customerAgentNm = customerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this._updateDate = updateDate;
            // --- ADD 2008/09/04 --------------------------------<<<<<

            this._onlineKindDiv = onlineKindDiv;    // 2010/04/06 Add
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ---------->>>>>
            this._simplInqAcntAcntGrId = simplInqAcntAcntGrId;
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ----------<<<<<
        }

		/// <summary>
		/// 得意先検索結果クラス複製処理
		/// </summary>
		/// <returns>CustomerSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCustomerSearchRetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerSearchRet Clone()
		{
            // 2010/04/06 >>>
            //// 2009/06/19 >>>
            //////return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1,  this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._updateDate);
            ////// 2009/12/02 >>>
            //////return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._updateDate);
            ////return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._updateDate, this._homeFaxNo, this._officeFaxNo);
            ////// 2009/12/02 <<<
            //return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._customerAgentCd, this._updateDate, this._homeFaxNo, this._officeFaxNo);
            //// 2009/06/19 <<<

			#region 2012.04.10 TERASAKA DEL STA
//            return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._customerAgentCd, this._updateDate, this._homeFaxNo, this._officeFaxNo, this._onlineKindDiv
//            , this._simplInqAcntAcntGrId    // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応
//            );
//            // 2010/04/06 <<<
			#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._customerAgentCd, this._customerAgentNm, this._updateDate, this._homeFaxNo, this._officeFaxNo, this._onlineKindDiv
            , this._simplInqAcntAcntGrId
            );
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        }

		/// <summary>
		/// 得意先検索結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerSearchRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(CustomerSearchRet target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerSubCode == target.CustomerSubCode)
				 && (this.Name == target.Name)
				 && (this.Name2 == target.Name2)
                 && (this.Snm == target.Snm)
				 && (this.Kana == target.Kana)
				 && (this.HonorificTitle == target.HonorificTitle)
				 && (this.SearchTelNo == target.SearchTelNo)
				 && (this.HomeTelNo == target.HomeTelNo)
				 && (this.OfficeTelNo == target.OfficeTelNo)
				 && (this.PortableTelNo == target.PortableTelNo)
				 && (this.PostNo == target.PostNo)
				 && (this.Address1 == target.Address1)
				 && (this.Address3 == target.Address3)
				 && (this.Address4 == target.Address4)
				 && (this.TotalDay == target.TotalDay)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AcceptWholeSale == target.AcceptWholeSale)
				 && (this.EnterpriseName == target.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.MngSectionCode == target.MngSectionCode)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 // ADD 2009/06/08 ------>>>
                 && (this.CustomerEpCode == target.CustomerEpCode)
                 && (this.CustomerSecCode == target.CustomerSecCode)
                 // ADD 2009/06/08 ------<<<
                // --- ADD 2009/06/19 -------------------------------->>>>>
                 && ( this.CustomerAgentCd == target.CustomerAgentCd )
                // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
                 && ( this.CustomerAgentNm == target.CustomerAgentNm )
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                // --- ADD 2008/09/04 -------------------------------->>>>>
                 && (this._updateDate == target.UpdateDate)
                 // --- ADD 2008/09/04 --------------------------------<<<<<
                 // 2009/12/02 Add >>>
                 && (this._homeFaxNo == target.HomeFaxNo)
                 && (this._officeFaxNo == target.OfficeFaxNo)
                 // 2009/12/02 Add <<<
                 && ( this._onlineKindDiv == target.OnlineKindDiv )     // 2010/04/06 Add
                 && (this._simplInqAcntAcntGrId == target.SimplInqAcntAcntGrId) // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応
                 );
		}

		/// <summary>
		/// 得意先検索結果クラス比較処理
		/// </summary>
		/// <param name="customerSearchRet1">
		///                    比較するCustomerSearchRetクラスのインスタンス
		/// </param>
		/// <param name="customerSearchRet2">比較するCustomerSearchRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(CustomerSearchRet customerSearchRet1, CustomerSearchRet customerSearchRet2)
		{
			return ((customerSearchRet1.EnterpriseCode == customerSearchRet2.EnterpriseCode)
				 && (customerSearchRet1.CustomerCode == customerSearchRet2.CustomerCode)
				 && (customerSearchRet1.CustomerSubCode == customerSearchRet2.CustomerSubCode)
				 && (customerSearchRet1.Name == customerSearchRet2.Name)
				 && (customerSearchRet1.Name2 == customerSearchRet2.Name2)
                 && (customerSearchRet1.Snm == customerSearchRet2.Snm)
				 && (customerSearchRet1.Kana == customerSearchRet2.Kana)
				 && (customerSearchRet1.HonorificTitle == customerSearchRet2.HonorificTitle)
				 && (customerSearchRet1.SearchTelNo == customerSearchRet2.SearchTelNo)
				 && (customerSearchRet1.HomeTelNo == customerSearchRet2.HomeTelNo)
				 && (customerSearchRet1.OfficeTelNo == customerSearchRet2.OfficeTelNo)
				 && (customerSearchRet1.PortableTelNo == customerSearchRet2.PortableTelNo)
				 && (customerSearchRet1.PostNo == customerSearchRet2.PostNo)
				 && (customerSearchRet1.Address1 == customerSearchRet2.Address1)
				 && (customerSearchRet1.Address3 == customerSearchRet2.Address3)
				 && (customerSearchRet1.Address4 == customerSearchRet2.Address4)
				 && (customerSearchRet1.TotalDay == customerSearchRet2.TotalDay)
				 && (customerSearchRet1.LogicalDeleteCode == customerSearchRet2.LogicalDeleteCode)
				 && (customerSearchRet1.AcceptWholeSale == customerSearchRet2.AcceptWholeSale)
				 && (customerSearchRet1.EnterpriseName == customerSearchRet2.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (customerSearchRet1.MngSectionCode == customerSearchRet2.MngSectionCode)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 // ADD 2009/06/08 ------>>>
                 && (customerSearchRet1.CustomerEpCode == customerSearchRet2.CustomerEpCode)
                 && (customerSearchRet1.CustomerSecCode == customerSearchRet2.CustomerSecCode)
                 // ADD 2009/06/08 ------<<<
                // --- ADD 2009/06/19 -------------------------------->>>>>
                 && ( customerSearchRet1.CustomerAgentCd == customerSearchRet2.CustomerAgentCd )
                // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
                 && ( customerSearchRet1.CustomerAgentNm == customerSearchRet2.CustomerAgentNm )
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                // --- ADD 2008/09/04 -------------------------------->>>>>
                 && (customerSearchRet1.UpdateDate == customerSearchRet2.UpdateDate)
                 // --- ADD 2008/09/04 --------------------------------<<<<<

                 // 2009/12/02 Add >>>
                 && (customerSearchRet1.HomeFaxNo == customerSearchRet2.HomeFaxNo)
                 && (customerSearchRet1.OfficeFaxNo == customerSearchRet2.OfficeFaxNo)
                 // 2009/12/02 Add <<<
                 && ( customerSearchRet1.OnlineKindDiv == customerSearchRet2.OnlineKindDiv )    // 2010/04/06 Add
                 && (customerSearchRet1.SimplInqAcntAcntGrId == customerSearchRet2.SimplInqAcntAcntGrId)    // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応
                 );
		}
		/// <summary>
		/// 得意先検索結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCustomerSearchRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(CustomerSearchRet target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
			if (this.CustomerSubCode != target.CustomerSubCode) resList.Add("CustomerSubCode");
			if (this.Name != target.Name) resList.Add("Name");
			if (this.Name2 != target.Name2) resList.Add("Name2");
            if (this.Snm != target.Snm) resList.Add( "Snm" );
			if (this.Kana != target.Kana) resList.Add("Kana");
			if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
			if (this.SearchTelNo != target.SearchTelNo) resList.Add("SearchTelNo");
			if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
			if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
			if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");

            // 2009/12/02 Add >>>
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            // 2009/12/02 Add <<<

			if (this.PostNo != target.PostNo) resList.Add("PostNo");
			if (this.Address1 != target.Address1) resList.Add("Address1");
			if (this.Address3 != target.Address3) resList.Add("Address3");
			if (this.Address4 != target.Address4) resList.Add("Address4");
			if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.AcceptWholeSale != target.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this.MngSectionCode != target.MngSectionCode ) resList.Add( "MngSectionCode" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ADD 2009/06/08 ------>>>
            if (this.CustomerEpCode != target.CustomerEpCode) resList.Add("CustomerEpCode");
            if (this.CustomerSecCode != target.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2008/09/04 -------------------------------->>>>>
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            // --- ADD 2008/09/04 --------------------------------<<<<<
            if (this.OnlineKindDiv != target.OnlineKindDiv) resList.Add("OnlineKindDiv");    // 2010/04/06 Add
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ---------->>>>>
            if (this.SimplInqAcntAcntGrId != target.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ----------<<<<<

			return resList;
		}

		/// <summary>
		/// 得意先検索結果クラス比較処理
		/// </summary>
		/// <param name="customerSearchRet1">比較するCustomerSearchRetクラスのインスタンス</param>
		/// <param name="customerSearchRet2">比較するCustomerSearchRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CustomerSearchRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustomerSearchRet customerSearchRet1, CustomerSearchRet customerSearchRet2)
		{
			ArrayList resList = new ArrayList();
			if (customerSearchRet1.EnterpriseCode != customerSearchRet2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (customerSearchRet1.CustomerCode != customerSearchRet2.CustomerCode) resList.Add("CustomerCode");
			if (customerSearchRet1.CustomerSubCode != customerSearchRet2.CustomerSubCode) resList.Add("CustomerSubCode");
			if (customerSearchRet1.Name != customerSearchRet2.Name) resList.Add("Name");
			if (customerSearchRet1.Name2 != customerSearchRet2.Name2) resList.Add("Name2");
            if (customerSearchRet1.Snm != customerSearchRet2.Snm) resList.Add( "Snm" );
			if (customerSearchRet1.Kana != customerSearchRet2.Kana) resList.Add("Kana");
			if (customerSearchRet1.HonorificTitle != customerSearchRet2.HonorificTitle) resList.Add("HonorificTitle");
			if (customerSearchRet1.SearchTelNo != customerSearchRet2.SearchTelNo) resList.Add("SearchTelNo");
			if (customerSearchRet1.HomeTelNo != customerSearchRet2.HomeTelNo) resList.Add("HomeTelNo");
			if (customerSearchRet1.OfficeTelNo != customerSearchRet2.OfficeTelNo) resList.Add("OfficeTelNo");

            // 2009/12/02 Add >>>
            if (customerSearchRet1.HomeFaxNo != customerSearchRet2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (customerSearchRet1.OfficeFaxNo != customerSearchRet2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            // 2009/12/02 Add <<<

			if (customerSearchRet1.PortableTelNo != customerSearchRet2.PortableTelNo) resList.Add("PortableTelNo");
			if (customerSearchRet1.PostNo != customerSearchRet2.PostNo) resList.Add("PostNo");
			if (customerSearchRet1.Address1 != customerSearchRet2.Address1) resList.Add("Address1");
			if (customerSearchRet1.Address3 != customerSearchRet2.Address3) resList.Add("Address3");
			if (customerSearchRet1.Address4 != customerSearchRet2.Address4) resList.Add("Address4");
			if (customerSearchRet1.TotalDay != customerSearchRet2.TotalDay) resList.Add("TotalDay");
			if (customerSearchRet1.LogicalDeleteCode != customerSearchRet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (customerSearchRet1.AcceptWholeSale != customerSearchRet2.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (customerSearchRet1.EnterpriseName != customerSearchRet2.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( customerSearchRet1.MngSectionCode != customerSearchRet2.MngSectionCode ) resList.Add( "MngSectionCode" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ADD 2009/06/08 ------>>>
            if (customerSearchRet1.CustomerEpCode != customerSearchRet2.CustomerEpCode) resList.Add("CustomerEpCode");
            if (customerSearchRet1.CustomerSecCode != customerSearchRet2.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            if (customerSearchRet1.CustomerAgentCd != customerSearchRet2.CustomerAgentCd) resList.Add("CustomerAgentCd");
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            if (customerSearchRet1.CustomerAgentNm != customerSearchRet2.CustomerAgentNm) resList.Add("CustomerAgentNm");
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2008/09/04 -------------------------------->>>>>
            if (customerSearchRet1.UpdateDate != customerSearchRet2.UpdateDate) resList.Add("UpdateDate");
            // --- ADD 2008/09/04 --------------------------------<<<<<
            if (customerSearchRet1.OnlineKindDiv != customerSearchRet2.OnlineKindDiv) resList.Add("OnlineKindDiv");  // 2010/04/06 Add
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ---------->>>>>
            if (customerSearchRet1.SimplInqAcntAcntGrId != customerSearchRet2.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ----------<<<<<
            
            return resList;
		}
	}
}
