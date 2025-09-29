//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM売上回答履歴照会
// プログラム概要   : 画面データを保持する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMAnsHistInquiryInfo
	/// <summary>
	///                      SCM売上回答履歴照会画面情報保持クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   SCM売上回答履歴照会抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :    2009/4/13</br>
	/// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SCMAnsHistInquiryInfo
	{
		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>開始問合せ番号</summary>
		private Int64 _st_InquiryNumber;

		/// <summary>終了問合せ番号</summary>
		private Int64 _ed_InquiryNumber;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32[] _inqOrdDivCd;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private Int32 _judgementDate;

		/// <summary>問合せ・発注備考</summary>
		private string _inqOrdNote;

		/// <summary>問合せ従業員コード</summary>
		/// <remarks>問合せした従業員コード</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>問合せ従業員名称</summary>
		/// <remarks>問合せした従業員名称</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>回答従業員コード</summary>
		private string _ansEmployeeCd = "";

		/// <summary>回答従業員名称</summary>
		private string _ansEmployeeNm = "";

		/// <summary>開始問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InquiryDate;

		/// <summary>終了問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InquiryDate;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>開始売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _st_SalesSlipNum = "";

		/// <summary>終了売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _ed_SalesSlipNum = "";

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32[] _acptAnOdrStatus;

		/// <summary>回答方法</summary>
		private Int32[] _awnserMethod;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>売上伝票合計（税込み）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _numberPlate3;

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _numberPlate4;

        /// <summary>型式（フル型）</summary>
        private string _fullModel;

        /// <summary>メーカーコード(車両情報)</summary>
        private Int32 _carMakerCode;

        /// <summary>車種コード</summary>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        private Int32 _modelSubCode;

        /// <summary>メーカーコード(明細)</summary>
        private Int32 _detailMakerCode;

        /// <summary>BLコード</summary>
        private Int32 _blGoodsCode;

        /// <summary>品番</summary>
        private string _goodsNo;

        /// <summary>純正品番</summary>
        private string _pureGoodsNo;

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>問合せ元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>問合せ先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>問合せ先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  St_InquiryNumber
		/// <summary>開始問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 St_InquiryNumber
		{
			get{return _st_InquiryNumber;}
			set{_st_InquiryNumber = value;}
		}

		/// public propaty name  :  Ed_InquiryNumber
		/// <summary>終了問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Ed_InquiryNumber
		{
			get{return _ed_InquiryNumber;}
			set{_ed_InquiryNumber = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>更新年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>更新年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>更新年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>更新年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>更新年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>更新時分秒ミリ秒プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時分秒ミリ秒プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>確定日プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>問合せ・発注備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>問合せ従業員コードプロパティ</summary>
		/// <value>問合せした従業員コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>問合せ従業員名称プロパティ</summary>
		/// <value>問合せした従業員名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>回答従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>回答従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  St_InquiryDate
		/// <summary>開始問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_InquiryDate
		{
			get{return _st_InquiryDate;}
			set{_st_InquiryDate = value;}
		}

		/// public propaty name  :  Ed_InquiryDate
		/// <summary>終了問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_InquiryDate
		{
			get{return _ed_InquiryDate;}
			set{_ed_InquiryDate = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_SalesSlipNum
		/// <summary>開始売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_SalesSlipNum
		{
			get{return _st_SalesSlipNum;}
			set{_st_SalesSlipNum = value;}
		}

		/// public propaty name  :  Ed_SalesSlipNum
		/// <summary>終了売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_SalesSlipNum
		{
			get{return _ed_SalesSlipNum;}
			set{_ed_SalesSlipNum = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  AwnserMethod
		/// <summary>回答方法プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] AwnserMethod
		{
			get{return _awnserMethod;}
			set{_awnserMethod = value;}
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

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>売上伝票合計（税込み）プロパティ</summary>
		/// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票合計（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
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

        /// public propaty name  :  NumberPlate3
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）ロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）ロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  CarMakerCode
        /// <summary>メーカーコード(車両情報)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(車両情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCode
        {
            get { return _carMakerCode; }
            set { _carMakerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  DetailMakerCode
        /// <summary>メーカーコード(明細)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード(明細)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailMakerCode
        {
            get { return _detailMakerCode; }
            set { _detailMakerCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  PureGoodsNo
        /// <summary>純正品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PureGoodsNo
        {
            get { return _pureGoodsNo; }
            set { _pureGoodsNo = value; }
        }

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>SCMAnsHistInquiryInfoクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistInquiryInfoクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAnsHistInquiryInfo()
		{
		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="st_InquiryNumber">開始問合せ番号</param>
		/// <param name="ed_InquiryNumber">終了問合せ番号</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="answerDivCd">回答区分(0:アクションなし 1:回答中 10:一部回答 20:回答完了 30:承認 99:キャンセル)</param>
		/// <param name="judgementDate">確定日(YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。)</param>
		/// <param name="inqOrdNote">問合せ・発注備考</param>
		/// <param name="inqEmployeeCd">問合せ従業員コード(問合せした従業員コード)</param>
		/// <param name="inqEmployeeNm">問合せ従業員名称(問合せした従業員名称)</param>
		/// <param name="ansEmployeeCd">回答従業員コード</param>
		/// <param name="ansEmployeeNm">回答従業員名称</param>
		/// <param name="st_InquiryDate">開始問合せ日(YYYYMMDD)</param>
		/// <param name="ed_InquiryDate">終了問合せ日(YYYYMMDD)</param>
		/// <param name="st_CustomerCode">開始得意先コード</param>
		/// <param name="ed_CustomerCode">終了得意先コード</param>
		/// <param name="st_SalesSlipNum">開始売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
		/// <param name="ed_SalesSlipNum">終了売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
		/// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
		/// <param name="awnserMethod">回答方法</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="salesTotalTaxInc">売上伝票合計（税込み）(売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>SCMAnsHistInquiryInfoクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistInquiryInfoクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SCMAnsHistInquiryInfo(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string numberPlate3, Int32 numberPlate4, string fullModel, Int32 carMakerCode, Int32 modelCode, Int32 modelSubCode, Int32 detailMakerCode, Int32 blGoodsCode, string goodsNo, string pureGoodsNo)
		{
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._st_InquiryNumber = st_InquiryNumber;
			this._ed_InquiryNumber = ed_InquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqOrdDivCd = inqOrdDivCd;
			this._judgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this._st_InquiryDate = st_InquiryDate;
			this._ed_InquiryDate = ed_InquiryDate;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesSlipNum = st_SalesSlipNum;
			this._ed_SalesSlipNum = ed_SalesSlipNum;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._awnserMethod = awnserMethod;
			this._enterpriseCode = enterpriseCode;
			this._customerCode = customerCode;
			this._salesTotalTaxInc = salesTotalTaxInc;
			this._enterpriseName = enterpriseName;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this._fullModel = fullModel;
            this._carMakerCode = carMakerCode;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._detailMakerCode = detailMakerCode;
            this._blGoodsCode = blGoodsCode;
            this._goodsNo = goodsNo;
            this._pureGoodsNo = pureGoodsNo;

		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス複製処理
		/// </summary>
		/// <returns>SCMAnsHistInquiryInfoクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMAnsHistInquiryInfoクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAnsHistInquiryInfo Clone()
		{
			return new SCMAnsHistInquiryInfo(this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._st_InquiryNumber,this._ed_InquiryNumber,this._updateDate,this._updateTime,this._inqOrdDivCd,this._judgementDate,this._inqOrdNote,this._inqEmployeeCd,this._inqEmployeeNm,this._ansEmployeeCd,this._ansEmployeeNm,this._st_InquiryDate,this._ed_InquiryDate,this._st_CustomerCode,this._ed_CustomerCode,this._st_SalesSlipNum,this._ed_SalesSlipNum,this._acptAnOdrStatus,this._awnserMethod,this._enterpriseCode,this._customerCode,this._salesTotalTaxInc,this._enterpriseName, this._numberPlate3, this._numberPlate4, this._fullModel, this._carMakerCode, this._modelCode, this._modelSubCode, this._detailMakerCode, this._blGoodsCode, this._goodsNo, this._pureGoodsNo);//@@@@20230303
		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAnsHistInquiryInfoクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistInquiryInfoクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public bool Equals(SCMAnsHistInquiryInfo target)
        {
            return ((this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.St_InquiryNumber == target.St_InquiryNumber)
                 && (this.Ed_InquiryNumber == target.Ed_InquiryNumber)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.UpdateTime == target.UpdateTime)
                 && (this.InqOrdDivCd == target.InqOrdDivCd)
                 && (this.JudgementDate == target.JudgementDate)
                 && (this.InqOrdNote == target.InqOrdNote)
                 && (this.InqEmployeeCd == target.InqEmployeeCd)
                 && (this.InqEmployeeNm == target.InqEmployeeNm)
                 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
                 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
                 && (this.St_InquiryDate == target.St_InquiryDate)
                 && (this.Ed_InquiryDate == target.Ed_InquiryDate)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.St_SalesSlipNum == target.St_SalesSlipNum)
                 && (this.Ed_SalesSlipNum == target.Ed_SalesSlipNum)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.AwnserMethod == target.AwnserMethod)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
                 && (this.EnterpriseName == target.EnterpriseName)
                && (this.NumberPlate3 == target.NumberPlate3)
                && (this.NumberPlate4 == target.NumberPlate4)
                && (this.FullModel == target.FullModel)
                && (this.CarMakerCode == target.CarMakerCode)
                && (this.ModelCode == target.ModelCode)
                && (this.ModelSubCode == target.ModelSubCode)
                && (this.DetailMakerCode == target.DetailMakerCode)
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.GoodsNo == target.GoodsNo)
                && (this.PureGoodsNo == target.PureGoodsNo)
                 );
        }

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="SCMAnsHistInquiryInfo1">
		///                    比較するSCMAnsHistInquiryInfoクラスのインスタンス
		/// </param>
		/// <param name="SCMAnsHistInquiryInfo2">比較するSCMAnsHistInquiryInfoクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistInquiryInfoクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static bool Equals(SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo1, SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo2)
        {
            return ((SCMAnsHistInquiryInfo1.InqOriginalEpCd.Trim() == SCMAnsHistInquiryInfo2.InqOriginalEpCd.Trim()) //@@@@20230303
                 && (SCMAnsHistInquiryInfo1.InqOriginalSecCd == SCMAnsHistInquiryInfo2.InqOriginalSecCd)
                 && (SCMAnsHistInquiryInfo1.InqOtherEpCd == SCMAnsHistInquiryInfo2.InqOtherEpCd)
                 && (SCMAnsHistInquiryInfo1.InqOtherSecCd == SCMAnsHistInquiryInfo2.InqOtherSecCd)
                 && (SCMAnsHistInquiryInfo1.St_InquiryNumber == SCMAnsHistInquiryInfo2.St_InquiryNumber)
                 && (SCMAnsHistInquiryInfo1.Ed_InquiryNumber == SCMAnsHistInquiryInfo2.Ed_InquiryNumber)
                 && (SCMAnsHistInquiryInfo1.UpdateDate == SCMAnsHistInquiryInfo2.UpdateDate)
                 && (SCMAnsHistInquiryInfo1.UpdateTime == SCMAnsHistInquiryInfo2.UpdateTime)
                 && (SCMAnsHistInquiryInfo1.InqOrdDivCd == SCMAnsHistInquiryInfo2.InqOrdDivCd)
                 && (SCMAnsHistInquiryInfo1.JudgementDate == SCMAnsHistInquiryInfo2.JudgementDate)
                 && (SCMAnsHistInquiryInfo1.InqOrdNote == SCMAnsHistInquiryInfo2.InqOrdNote)
                 && (SCMAnsHistInquiryInfo1.InqEmployeeCd == SCMAnsHistInquiryInfo2.InqEmployeeCd)
                 && (SCMAnsHistInquiryInfo1.InqEmployeeNm == SCMAnsHistInquiryInfo2.InqEmployeeNm)
                 && (SCMAnsHistInquiryInfo1.AnsEmployeeCd == SCMAnsHistInquiryInfo2.AnsEmployeeCd)
                 && (SCMAnsHistInquiryInfo1.AnsEmployeeNm == SCMAnsHistInquiryInfo2.AnsEmployeeNm)
                 && (SCMAnsHistInquiryInfo1.St_InquiryDate == SCMAnsHistInquiryInfo2.St_InquiryDate)
                 && (SCMAnsHistInquiryInfo1.Ed_InquiryDate == SCMAnsHistInquiryInfo2.Ed_InquiryDate)
                 && (SCMAnsHistInquiryInfo1.St_CustomerCode == SCMAnsHistInquiryInfo2.St_CustomerCode)
                 && (SCMAnsHistInquiryInfo1.Ed_CustomerCode == SCMAnsHistInquiryInfo2.Ed_CustomerCode)
                 && (SCMAnsHistInquiryInfo1.St_SalesSlipNum == SCMAnsHistInquiryInfo2.St_SalesSlipNum)
                 && (SCMAnsHistInquiryInfo1.Ed_SalesSlipNum == SCMAnsHistInquiryInfo2.Ed_SalesSlipNum)
                 && (SCMAnsHistInquiryInfo1.AcptAnOdrStatus == SCMAnsHistInquiryInfo2.AcptAnOdrStatus)
                 && (SCMAnsHistInquiryInfo1.AwnserMethod == SCMAnsHistInquiryInfo2.AwnserMethod)
                 && (SCMAnsHistInquiryInfo1.EnterpriseCode == SCMAnsHistInquiryInfo2.EnterpriseCode)
                 && (SCMAnsHistInquiryInfo1.CustomerCode == SCMAnsHistInquiryInfo2.CustomerCode)
                 && (SCMAnsHistInquiryInfo1.SalesTotalTaxInc == SCMAnsHistInquiryInfo2.SalesTotalTaxInc)
                 && (SCMAnsHistInquiryInfo1.EnterpriseName == SCMAnsHistInquiryInfo2.EnterpriseName)
                && (SCMAnsHistInquiryInfo1.NumberPlate3 == SCMAnsHistInquiryInfo2.NumberPlate3)
                && (SCMAnsHistInquiryInfo1.NumberPlate4 == SCMAnsHistInquiryInfo2.NumberPlate4)
                && (SCMAnsHistInquiryInfo1.FullModel == SCMAnsHistInquiryInfo2.FullModel)
                && (SCMAnsHistInquiryInfo1.CarMakerCode == SCMAnsHistInquiryInfo2.CarMakerCode)
                && (SCMAnsHistInquiryInfo1.ModelCode == SCMAnsHistInquiryInfo2.ModelCode)
                && (SCMAnsHistInquiryInfo1.ModelSubCode == SCMAnsHistInquiryInfo2.ModelSubCode)
                && (SCMAnsHistInquiryInfo1.DetailMakerCode == SCMAnsHistInquiryInfo2.DetailMakerCode)
                && (SCMAnsHistInquiryInfo1.BLGoodsCode == SCMAnsHistInquiryInfo2.BLGoodsCode)
                && (SCMAnsHistInquiryInfo1.GoodsNo == SCMAnsHistInquiryInfo2.GoodsNo)
                && (SCMAnsHistInquiryInfo1.PureGoodsNo == SCMAnsHistInquiryInfo2.PureGoodsNo)
                 );
        }

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAnsHistInquiryInfoクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistInquiryInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SCMAnsHistInquiryInfo target)
		{
			ArrayList resList = new ArrayList();
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.St_InquiryNumber != target.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(this.Ed_InquiryNumber != target.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.JudgementDate != target.JudgementDate)resList.Add("JudgementDate");
			if(this.InqOrdNote != target.InqOrdNote)resList.Add("InqOrdNote");
			if(this.InqEmployeeCd != target.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(this.InqEmployeeNm != target.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(this.AnsEmployeeCd != target.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(this.AnsEmployeeNm != target.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(this.St_InquiryDate != target.St_InquiryDate)resList.Add("St_InquiryDate");
			if(this.Ed_InquiryDate != target.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_SalesSlipNum != target.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(this.Ed_SalesSlipNum != target.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.AwnserMethod != target.AwnserMethod)resList.Add("AwnserMethod");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.SalesTotalTaxInc != target.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.CarMakerCode != target.CarMakerCode) resList.Add("CarMakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.DetailMakerCode != target.DetailMakerCode) resList.Add("DetailMakerCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.PureGoodsNo != target.PureGoodsNo) resList.Add("PureGoodsNo");

			return resList;
		}

		/// <summary>
		/// SCM問い合わせ一覧抽出条件クラス比較処理
		/// </summary>
		/// <param name="SCMAnsHistInquiryInfo1">比較するSCMAnsHistInquiryInfoクラスのインスタンス</param>
		/// <param name="SCMAnsHistInquiryInfo2">比較するSCMAnsHistInquiryInfoクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistInquiryInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo1, SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo2)
		{
			ArrayList resList = new ArrayList();
			if(SCMAnsHistInquiryInfo1.InqOriginalEpCd.Trim() != SCMAnsHistInquiryInfo2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(SCMAnsHistInquiryInfo1.InqOriginalSecCd != SCMAnsHistInquiryInfo2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(SCMAnsHistInquiryInfo1.InqOtherEpCd != SCMAnsHistInquiryInfo2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(SCMAnsHistInquiryInfo1.InqOtherSecCd != SCMAnsHistInquiryInfo2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(SCMAnsHistInquiryInfo1.St_InquiryNumber != SCMAnsHistInquiryInfo2.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(SCMAnsHistInquiryInfo1.Ed_InquiryNumber != SCMAnsHistInquiryInfo2.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(SCMAnsHistInquiryInfo1.UpdateDate != SCMAnsHistInquiryInfo2.UpdateDate)resList.Add("UpdateDate");
			if(SCMAnsHistInquiryInfo1.UpdateTime != SCMAnsHistInquiryInfo2.UpdateTime)resList.Add("UpdateTime");
			if(SCMAnsHistInquiryInfo1.InqOrdDivCd != SCMAnsHistInquiryInfo2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(SCMAnsHistInquiryInfo1.JudgementDate != SCMAnsHistInquiryInfo2.JudgementDate)resList.Add("JudgementDate");
			if(SCMAnsHistInquiryInfo1.InqOrdNote != SCMAnsHistInquiryInfo2.InqOrdNote)resList.Add("InqOrdNote");
			if(SCMAnsHistInquiryInfo1.InqEmployeeCd != SCMAnsHistInquiryInfo2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(SCMAnsHistInquiryInfo1.InqEmployeeNm != SCMAnsHistInquiryInfo2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(SCMAnsHistInquiryInfo1.AnsEmployeeCd != SCMAnsHistInquiryInfo2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(SCMAnsHistInquiryInfo1.AnsEmployeeNm != SCMAnsHistInquiryInfo2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(SCMAnsHistInquiryInfo1.St_InquiryDate != SCMAnsHistInquiryInfo2.St_InquiryDate)resList.Add("St_InquiryDate");
			if(SCMAnsHistInquiryInfo1.Ed_InquiryDate != SCMAnsHistInquiryInfo2.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(SCMAnsHistInquiryInfo1.St_CustomerCode != SCMAnsHistInquiryInfo2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(SCMAnsHistInquiryInfo1.Ed_CustomerCode != SCMAnsHistInquiryInfo2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(SCMAnsHistInquiryInfo1.St_SalesSlipNum != SCMAnsHistInquiryInfo2.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(SCMAnsHistInquiryInfo1.Ed_SalesSlipNum != SCMAnsHistInquiryInfo2.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(SCMAnsHistInquiryInfo1.AcptAnOdrStatus != SCMAnsHistInquiryInfo2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(SCMAnsHistInquiryInfo1.AwnserMethod != SCMAnsHistInquiryInfo2.AwnserMethod)resList.Add("AwnserMethod");
			if(SCMAnsHistInquiryInfo1.EnterpriseCode != SCMAnsHistInquiryInfo2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(SCMAnsHistInquiryInfo1.CustomerCode != SCMAnsHistInquiryInfo2.CustomerCode)resList.Add("CustomerCode");
			if(SCMAnsHistInquiryInfo1.SalesTotalTaxInc != SCMAnsHistInquiryInfo2.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(SCMAnsHistInquiryInfo1.EnterpriseName != SCMAnsHistInquiryInfo2.EnterpriseName)resList.Add("EnterpriseName");
            if (SCMAnsHistInquiryInfo1.NumberPlate3 != SCMAnsHistInquiryInfo2.NumberPlate3) resList.Add("NumberPlate3");
            if (SCMAnsHistInquiryInfo1.NumberPlate4 != SCMAnsHistInquiryInfo2.NumberPlate4) resList.Add("NumberPlate4");
            if (SCMAnsHistInquiryInfo1.FullModel != SCMAnsHistInquiryInfo2.FullModel) resList.Add("FullModel");
            if (SCMAnsHistInquiryInfo1.CarMakerCode != SCMAnsHistInquiryInfo2.CarMakerCode) resList.Add("CarMakerCode");
            if (SCMAnsHistInquiryInfo1.ModelCode != SCMAnsHistInquiryInfo2.ModelCode) resList.Add("ModelCode");
            if (SCMAnsHistInquiryInfo1.ModelSubCode != SCMAnsHistInquiryInfo2.ModelSubCode) resList.Add("ModelSubCode");
            if (SCMAnsHistInquiryInfo1.DetailMakerCode != SCMAnsHistInquiryInfo2.DetailMakerCode) resList.Add("DetailMakerCode");
            if (SCMAnsHistInquiryInfo1.BLGoodsCode != SCMAnsHistInquiryInfo2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (SCMAnsHistInquiryInfo1.GoodsNo != SCMAnsHistInquiryInfo2.GoodsNo) resList.Add("GoodsNo");
            if (SCMAnsHistInquiryInfo1.PureGoodsNo != SCMAnsHistInquiryInfo2.PureGoodsNo) resList.Add("PureGoodsNo");

			return resList;
		}

        /// <summary>
        /// 回答区分
        /// </summary>
        public enum AnswerDivState
        {
            /// <summary>アクションなし(回答中)</summary>
            Non = 0,
            /// <summary>一部回答</summary>
            Part = 10,
            /// <summary>回答完了</summary>
            Complete = 20,
            /// <summary>キャンセル</summary>
            Cancel = 99
        }

        /// <summary>
        /// 回答方法
        /// </summary>
        public enum AnswerMethodState
        {
            /// <summary>自動</summary>
            Auto = 0,
            /// <summary>手動(Web)</summary>
            ManualWeb = 1,
            /// <summary>手動(その他)</summary>
            ManualOther = 2
        }

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public enum AcptAnOdrStatusState
        {
            /// <summary>未設定</summary>
            NotSet = 0,
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>受注</summary>
            Accept = 20,
            /// <summary>売上</summary>
            Sales = 30,
        }

        /// <summary>
        /// 問合せ・発注区分
        /// </summary>
        public enum InqOrdDivState
        {
            /// <summary>問合せ</summary>
            Estimate = 1,
            /// <summary>発注</summary>
            Accept = 2
        }
	}
}
