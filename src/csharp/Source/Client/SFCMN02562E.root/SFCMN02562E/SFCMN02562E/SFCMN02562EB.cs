using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmEpScCnt
	/// <summary>
	///                      SCM企業拠点連結マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM企業拠点連結マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2011/08/11  (CSharp File Generated Date)</br>
    /// <br>Update Date      :   2013/06/26  </br>
    /// <br>                 :   30744 湯上 千加子</br>
    /// <br>                 :   SCM障害対応 タブレット使用区分追加</br>
    /// </remarks>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : 30745　吉岡
    // 更 新 日  2013/05/24  修正内容 : 2013/06/18配信予定　SCM№10533対応
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : 30973　鹿庭
    // 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応
    //----------------------------------------------------------------------------//
	public class ScmEpScCnt
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>連結元企業コード</summary>
		private string _cnectOriginalEpCd = "";

		/// <summary>連結元拠点コード</summary>
		private string _cnectOriginalSecCd = "";

		/// <summary>連結元拠点ガイド名称</summary>
		private string _cnectOriginalSecNm = "";

		/// <summary>連結先企業コード</summary>
		private string _cnectOtherEpCd = "";

		/// <summary>連結先拠点コード</summary>
		private string _cnectOtherSecCd = "";

		/// <summary>連結先拠点ガイド名称</summary>
		private string _cnectOtherSecNm = "";

		/// <summary>識別区分</summary>
		/// <remarks>0:連結有効 1:連結無効</remarks>
		private Int32 _discDivCd;

		/// <summary>通信方式(SCM)</summary>
		/// <remarks>0:しない,1:する</remarks>
		private Int16 _scmCommMethod;

		/// <summary>通信方式(PCC-UOE)</summary>
		/// <remarks>0:しない,1:する</remarks>
		private Int16 _pccUoeCommMethod;

        // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
        /// <summary>タブレット使用区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _tabUseDiv;
        // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<

        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>通信方式(部品問合せ・発注（RCオプション）)</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int16 _rcScmCommMethod;

        /// <summary>優先表示システム</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int16 _prDispSystem;
        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
        /// <summary>新旧切替ステータス</summary>
        /// <remarks>0:旧,1:真</remarks>
        private Int32 _oldNewStatus;

        /// <summary>通常/手動ステータス</summary>
        /// <remarks>0:通常,1:手動</remarks>
        private Int32 _usualMnalStatus;

        /// <summary>パーツマンDBID</summary>
        /// <remarks>パーツマン拠点DBサーバーのID</remarks>
        private string _pmDBId;

        /// <summary>パーツマンアップロード区分</summary>
        /// <remarks>0:なし,1:アップロード済み</remarks>
        private Int32 _pmUploadDiv;
        // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
        
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

		/// public propaty name  :  CnectOriginalEpCd
		/// <summary>連結元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOriginalEpCd
		{
			get { return _cnectOriginalEpCd; }
			set { _cnectOriginalEpCd = value; }
		}

		/// public propaty name  :  CnectOriginalSecCd
		/// <summary>連結元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOriginalSecCd
		{
			get { return _cnectOriginalSecCd; }
			set { _cnectOriginalSecCd = value; }
		}

		/// public propaty name  :  CnectOriginalSecNm
		/// <summary>連結元拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結元拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOriginalSecNm
		{
			get { return _cnectOriginalSecNm; }
			set { _cnectOriginalSecNm = value; }
		}

		/// public propaty name  :  CnectOtherEpCd
		/// <summary>連結先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOtherEpCd
		{
			get { return _cnectOtherEpCd; }
			set { _cnectOtherEpCd = value; }
		}

		/// public propaty name  :  CnectOtherSecCd
		/// <summary>連結先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOtherSecCd
		{
			get { return _cnectOtherSecCd; }
			set { _cnectOtherSecCd = value; }
		}

		/// public propaty name  :  CnectOtherSecNm
		/// <summary>連結先拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結先拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOtherSecNm
		{
			get { return _cnectOtherSecNm; }
			set { _cnectOtherSecNm = value; }
		}

		/// public propaty name  :  DiscDivCd
		/// <summary>識別区分プロパティ</summary>
		/// <value>0:連結有効 1:連結無効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   識別区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DiscDivCd
		{
			get { return _discDivCd; }
			set { _discDivCd = value; }
		}

		/// public propaty name  :  ScmCommMethod
		/// <summary>通信方式(SCM)プロパティ</summary>
		/// <value>0:しない,1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   通信方式(SCM)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 ScmCommMethod
		{
			get { return _scmCommMethod; }
			set { _scmCommMethod = value; }
		}

		/// public propaty name  :  PccUoeCommMethod
		/// <summary>通信方式(PCC-UOE)プロパティ</summary>
		/// <value>0:しない,1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   通信方式(PCC-UOE)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 PccUoeCommMethod
		{
			get { return _pccUoeCommMethod; }
			set { _pccUoeCommMethod = value; }
		}

        // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
        /// public propaty name  :  TabUseDiv
        /// <summary>タブレット使用区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   タブレット使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TabUseDiv
        {
            get { return _tabUseDiv; }
            set { _tabUseDiv = value; }
        }
        // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<

        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  RCScmCommMethod
        /// <summary>通信方式(部品問合せ・発注（RCオプション）)プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信方式(部品問合せ・発注（RCオプション）)プロパティ</br>
        /// </remarks>
        public Int16 RcScmCommMethod
        {
            get { return _rcScmCommMethod; }
            set { _rcScmCommMethod = value; }
        }

        /// public propaty name  :  PrDispSystem
        /// <summary>優先表示システム</summary>
        /// <value>10：新品部品（PMを優先表示）、11：リサイクル（RCを優先表示）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先表示システムプロパティ</br>
        /// </remarks>
        public Int16 PrDispSystem
        {
            get { return _prDispSystem; }
            set { _prDispSystem = value; }
        }
        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
        /// public propaty name  :  OldNewStatus
        /// <summary>新旧切替ステータス</summary>
        /// <value>0:旧,1:真</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新旧切替ステータスプロパティ</br>
        /// </remarks>
        public Int32 OldNewStatus
        {
            get { return _oldNewStatus; }
            set { _oldNewStatus = value; }
        }

        /// public propaty name  :  UsualMnalStatus
        /// <summary>通常/手動ステータス</summary>
        /// <value>0:通常,1:手動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通常/手動ステータス</br>
        /// </remarks>
        public Int32 UsualMnalStatus
        {
            get { return _usualMnalStatus; }
            set { _usualMnalStatus = value; }
        }

        /// public propaty name  :  PmDBId
        /// <summary>パーツマンDBID</summary>
        /// <value>パーツマン拠点DBサーバーのID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パーツマンDBID</br>
        /// </remarks>
        public string PmDBId
        {
            get { return _pmDBId; }
            set { _pmDBId = value; }
        }

        /// public propaty name  :  PmUploadDiv
        /// <summary>パーツマンアップロード区分</summary>
        /// <value>0:なし,1:アップロード済み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パーツマンアップロード区分</br>
        /// </remarks>
        public Int32 PmUploadDiv
        {
            get { return _pmUploadDiv; }
            set { _pmUploadDiv = value; }
        }
        // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
        
        /// <summary>
		/// SCM企業拠点連結マスタコンストラクタ
		/// </summary>
		/// <returns>ScmEpScCntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpScCntクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmEpScCnt()
		{
		}

        /// <summary>
        /// SCM企業拠点連結マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cnectOriginalSecCd">連結元拠点コード</param>
        /// <param name="cnectOriginalSecNm">連結元拠点ガイド名称</param>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="cnectOtherSecCd">連結先拠点コード</param>
        /// <param name="cnectOtherSecNm">連結先拠点ガイド名称</param>
        /// <param name="discDivCd">識別区分(0:連結有効 1:連結無効)</param>
        /// <param name="scmCommMethod">通信方式(SCM)(0:しない,1:する)</param>
        /// <param name="pccUoeCommMethod">通信方式(PCC-UOE)(0:しない,1:する)</param>
        /// <param name="tabUseDiv">タブレット使用区分(0:しない,1:する)</param>
        ///// <param name="rcUoeCommMethod">通信方式(部品問合せ・発注（RCオプション）)(0:しない,1:する)</param>
        /// <param name="rcScmCommMethod">通信方式(部品問合せ・発注（RCオプション）)プロパティ</param>
        /// <param name="prDispSystem">優先表示システム</param>
        /// <param name="oldNewStatus">新旧切替ステータス</param>
        /// <param name="usualMnalStatus">通常/手動ステータス</param>
        /// <param name="pmDBId">パーツマンDBID</param>
        /// <param name="pmUploadDiv">パーツマンアップロード区分</param>
        /// <returns>ScmEpScCntクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmEpScCntクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // UPD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
        //// UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //// UPD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
        //////public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod)
        ////public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int32 tabUseDiv)
        ////// UPD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
        //public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int32 tabUseDiv, Int16 rcScmCommMethod, Int16 prDispSystem)
        //// UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        public ScmEpScCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecNm, string cnectOtherEpCd, string cnectOtherSecCd, string cnectOtherSecNm, Int32 discDivCd, Int16 scmCommMethod, Int16 pccUoeCommMethod, Int32 tabUseDiv, Int16 rcScmCommMethod, Int16 prDispSystem, Int32 oldNewStatus, Int32 usualMnalStatus, string pmDBId, Int32 pmUploadDiv)
        // UPD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._cnectOriginalEpCd = cnectOriginalEpCd;
			this._cnectOriginalSecCd = cnectOriginalSecCd;
			this._cnectOriginalSecNm = cnectOriginalSecNm;
			this._cnectOtherEpCd = cnectOtherEpCd;
			this._cnectOtherSecCd = cnectOtherSecCd;
			this._cnectOtherSecNm = cnectOtherSecNm;
			this._discDivCd = discDivCd;
			this._scmCommMethod = scmCommMethod;
			this._pccUoeCommMethod = pccUoeCommMethod;
            // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
            this._tabUseDiv = tabUseDiv;
            // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
			// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 以下№10533で追加
            this._rcScmCommMethod = rcScmCommMethod;
            this._prDispSystem = prDispSystem;
			// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
            this.OldNewStatus = oldNewStatus;
            this.UsualMnalStatus = usualMnalStatus;
            this.PmDBId = pmDBId;
            this.PmUploadDiv = pmUploadDiv;
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
        }

		/// <summary>
		/// SCM企業拠点連結マスタ複製処理
		/// </summary>
		/// <returns>ScmEpScCntクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmEpScCntクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmEpScCnt Clone()
		{
            // UPD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
            //// UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            ////// UPD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
            //////return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod);
            ////return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._tabUseDiv);
            //return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._tabUseDiv, this._rcScmCommMethod, this._prDispSystem);
            //// UPD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
            //// UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return new ScmEpScCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecNm, this._cnectOtherEpCd, this._cnectOtherSecCd, this._cnectOtherSecNm, this._discDivCd, this._scmCommMethod, this._pccUoeCommMethod, this._tabUseDiv, this._rcScmCommMethod, this._prDispSystem, this._oldNewStatus, this.UsualMnalStatus, this.PmDBId, this.PmUploadDiv);
            // UPD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
        }

		/// <summary>
		/// SCM企業拠点連結マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmEpScCntクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpScCntクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmEpScCnt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
				 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
				 && (this.CnectOriginalSecNm == target.CnectOriginalSecNm)
				 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
				 && (this.CnectOtherSecCd == target.CnectOtherSecCd)
				 && (this.CnectOtherSecNm == target.CnectOtherSecNm)
				 && (this.DiscDivCd == target.DiscDivCd)
				 && (this.ScmCommMethod == target.ScmCommMethod)
				 && (this.PccUoeCommMethod == target.PccUoeCommMethod)
                // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
                 && (this.TabUseDiv == target.TabUseDiv)
                // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
                // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.RcScmCommMethod == target.RcScmCommMethod)
                 && (this.PrDispSystem == target.PrDispSystem)
                // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
                 && (this.OldNewStatus == target.OldNewStatus)
                 && (this.UsualMnalStatus == target.UsualMnalStatus)
                 && (this.PmDBId == target.PmDBId)
                 && (this.PmUploadDiv == target.PmUploadDiv)
                // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
                );
		}

		/// <summary>
		/// SCM企業拠点連結マスタ比較処理
		/// </summary>
		/// <param name="scmEpScCnt1">
		///                    比較するScmEpScCntクラスのインスタンス
		/// </param>
		/// <param name="scmEpScCnt2">比較するScmEpScCntクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpScCntクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmEpScCnt scmEpScCnt1, ScmEpScCnt scmEpScCnt2)
		{
			return ((scmEpScCnt1.CreateDateTime == scmEpScCnt2.CreateDateTime)
				 && (scmEpScCnt1.UpdateDateTime == scmEpScCnt2.UpdateDateTime)
				 && (scmEpScCnt1.LogicalDeleteCode == scmEpScCnt2.LogicalDeleteCode)
				 && (scmEpScCnt1.CnectOriginalEpCd == scmEpScCnt2.CnectOriginalEpCd)
				 && (scmEpScCnt1.CnectOriginalSecCd == scmEpScCnt2.CnectOriginalSecCd)
				 && (scmEpScCnt1.CnectOriginalSecNm == scmEpScCnt2.CnectOriginalSecNm)
				 && (scmEpScCnt1.CnectOtherEpCd == scmEpScCnt2.CnectOtherEpCd)
				 && (scmEpScCnt1.CnectOtherSecCd == scmEpScCnt2.CnectOtherSecCd)
				 && (scmEpScCnt1.CnectOtherSecNm == scmEpScCnt2.CnectOtherSecNm)
				 && (scmEpScCnt1.DiscDivCd == scmEpScCnt2.DiscDivCd)
				 && (scmEpScCnt1.ScmCommMethod == scmEpScCnt2.ScmCommMethod)
				 && (scmEpScCnt1.PccUoeCommMethod == scmEpScCnt2.PccUoeCommMethod)
                // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
                 && (scmEpScCnt1.TabUseDiv == scmEpScCnt2.TabUseDiv)
                // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
                // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (scmEpScCnt1.RcScmCommMethod == scmEpScCnt2.RcScmCommMethod)
                 && (scmEpScCnt1.PrDispSystem == scmEpScCnt2.PrDispSystem)
                // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
                 && (scmEpScCnt1.OldNewStatus == scmEpScCnt2.OldNewStatus)
                 && (scmEpScCnt1.UsualMnalStatus == scmEpScCnt2.UsualMnalStatus)
                 && (scmEpScCnt1.PmDBId == scmEpScCnt2.PmDBId)
                 && (scmEpScCnt1.PmUploadDiv == scmEpScCnt2.PmUploadDiv)
                // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<
                 );
		}
		/// <summary>
		/// SCM企業拠点連結マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmEpScCntクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpScCntクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmEpScCnt target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
			if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
			if (this.CnectOriginalSecNm != target.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
			if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
			if (this.CnectOtherSecCd != target.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
			if (this.CnectOtherSecNm != target.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
			if (this.DiscDivCd != target.DiscDivCd) resList.Add("DiscDivCd");
			if (this.ScmCommMethod != target.ScmCommMethod) resList.Add("ScmCommMethod");
			if (this.PccUoeCommMethod != target.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
            if (this.TabUseDiv != target.TabUseDiv) resList.Add("TabUseDiv");
            // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.RcScmCommMethod != target.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (this.PrDispSystem != target.PrDispSystem) resList.Add("PrDispSystem");
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
            if (this.OldNewStatus != target.OldNewStatus) resList.Add("OldNewStatus");
            if (this.UsualMnalStatus != target.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (this.PmDBId != target.PmDBId) resList.Add("PmDBId");
            if (this.PmUploadDiv != target.PmUploadDiv) resList.Add("PmUploadDiv");
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// SCM企業拠点連結マスタ比較処理
		/// </summary>
		/// <param name="scmEpScCnt1">比較するScmEpScCntクラスのインスタンス</param>
		/// <param name="scmEpScCnt2">比較するScmEpScCntクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpScCntクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmEpScCnt scmEpScCnt1, ScmEpScCnt scmEpScCnt2)
		{
			ArrayList resList = new ArrayList();
			if (scmEpScCnt1.CreateDateTime != scmEpScCnt2.CreateDateTime) resList.Add("CreateDateTime");
			if (scmEpScCnt1.UpdateDateTime != scmEpScCnt2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (scmEpScCnt1.LogicalDeleteCode != scmEpScCnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (scmEpScCnt1.CnectOriginalEpCd != scmEpScCnt2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
			if (scmEpScCnt1.CnectOriginalSecCd != scmEpScCnt2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
			if (scmEpScCnt1.CnectOriginalSecNm != scmEpScCnt2.CnectOriginalSecNm) resList.Add("CnectOriginalSecNm");
			if (scmEpScCnt1.CnectOtherEpCd != scmEpScCnt2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
			if (scmEpScCnt1.CnectOtherSecCd != scmEpScCnt2.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
			if (scmEpScCnt1.CnectOtherSecNm != scmEpScCnt2.CnectOtherSecNm) resList.Add("CnectOtherSecNm");
			if (scmEpScCnt1.DiscDivCd != scmEpScCnt2.DiscDivCd) resList.Add("DiscDivCd");
			if (scmEpScCnt1.ScmCommMethod != scmEpScCnt2.ScmCommMethod) resList.Add("ScmCommMethod");
			if (scmEpScCnt1.PccUoeCommMethod != scmEpScCnt2.PccUoeCommMethod) resList.Add("PccUoeCommMethod");
            // ADD 2013/06/26 yugami SCM障害対応 ----------------------------------->>>>>
            if (scmEpScCnt1.TabUseDiv != scmEpScCnt2.TabUseDiv) resList.Add("TabUseDiv");
            // ADD 2013/06/26 yugami SCM障害対応 -----------------------------------<<<<<
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmEpScCnt1.RcScmCommMethod != scmEpScCnt2.RcScmCommMethod) resList.Add("RcScmCommMethod");
            if (scmEpScCnt1.PrDispSystem != scmEpScCnt2.PrDispSystem) resList.Add("PrDispSystem");
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 ----------------------------------->>>>>
            if (scmEpScCnt1.OldNewStatus != scmEpScCnt2.OldNewStatus) resList.Add("OldNewStatus");
            if (scmEpScCnt1.UsualMnalStatus != scmEpScCnt2.UsualMnalStatus) resList.Add("UsualMnalStatus");
            if (scmEpScCnt1.PmDBId != scmEpScCnt2.PmDBId) resList.Add("PmDBId");
            if (scmEpScCnt1.PmUploadDiv != scmEpScCnt2.PmUploadDiv) resList.Add("PmUploadDiv");
            // ADD 2014/12/19 鹿庭 SCM高速化 PMNS対応 -----------------------------------<<<<<

			return resList;
		}
	}
}
