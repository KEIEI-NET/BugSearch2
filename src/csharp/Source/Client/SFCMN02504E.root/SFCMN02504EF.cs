using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdSrchParam
	/// <summary>
	///                      SCM受発注検索条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受発注検索条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/4/30</br>
	/// <br>Genarated Date   :   2011/05/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2011/5/19  本告　匡啓</br>
	/// <br>                 :   SCMオプション(PM連携 3次改良)対応</br>
	/// <br>                 :   ・SF-PM連携指示書番号</br>
	/// <br>                 :   ・取引完了区分</br>
	/// <br>                 :   項目追加</br>
	/// <br>Update Note      :   2011/5/24  柏原　頼人</br>
	/// <br>                 :   SCMオプション(PM連携 3次改良)対応</br>
	/// <br>                 :   ・更新年月日（終了）</br>
	/// <br>                 :   ・更新時分ミリ秒（終了）</br>
	/// <br>                 :   項目追加</br>
	/// <br>                 :   更新年月日（開始）</br>
	/// <br>                 :   更新時分秒ミリ秒（開始）</br>
	/// <br>                 :   名称変更</br>
	/// </remarks>
	[Serializable]
	public class ScmOdSrchParam
	{
		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>問合せ番号</summary>
		/// <remarks>配列型</remarks>
		private Int64[] _inquiryNumber;

		/// <summary>問合せ番号(開始)</summary>
		private Int64 _inquiryNumberSt;

		/// <summary>問合せ番号(終了)</summary>
		private Int64 _inquiryNumberEd;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDateSt;

		/// <summary>更新時分秒ミリ秒（開始）</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTimeSt;

		/// <summary>問合せ従業員コード</summary>
		/// <remarks>問合せした従業員コード</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>回答従業員コード</summary>
		private string _ansEmployeeCd = "";

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>最新識別区分</summary>
		/// <remarks>0:最新データ 1:旧データ</remarks>
		private Int16 _latestDiscCode;

		/// <summary>SF-PM連携指示書番号</summary>
		private string _sfPmCprtInstSlipNo = "";

		/// <summary>取引完了区分</summary>
		/// <remarks>0:未完了 1:完了</remarks>
		private Int32 _transCmpltDivCd;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDateEd;

		/// <summary>更新時分ミリ秒（終了）</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTimeEd;


		/// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get { return _inqOriginalEpCd; }
			set { _inqOriginalEpCd = value; }
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
			get { return _inqOriginalSecCd; }
			set { _inqOriginalSecCd = value; }
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
			get { return _inqOtherEpCd; }
			set { _inqOtherEpCd = value; }
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
			get { return _inqOtherSecCd; }
			set { _inqOtherSecCd = value; }
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>問合せ番号プロパティ</summary>
		/// <value>配列型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64[] InquiryNumber
		{
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
		}

		/// public propaty name  :  InquiryNumberSt
		/// <summary>問合せ番号(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumberSt
		{
			get { return _inquiryNumberSt; }
			set { _inquiryNumberSt = value; }
		}

		/// public propaty name  :  InquiryNumberEd
		/// <summary>問合せ番号(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumberEd
		{
			get { return _inquiryNumberEd; }
			set { _inquiryNumberEd = value; }
		}

		/// public propaty name  :  UpdateDateSt
		/// <summary>更新年月日（開始）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateSt
		{
			get { return _updateDateSt; }
			set { _updateDateSt = value; }
		}

		/// public propaty name  :  UpdateDateStJpFormal
		/// <summary>更新年月日（開始） 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（開始） 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateStJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateDateStJpInFormal
		/// <summary>更新年月日（開始） 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（開始） 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateStJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateDateStAdFormal
		/// <summary>更新年月日（開始） 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（開始） 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateStAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateDateStAdInFormal
		/// <summary>更新年月日（開始） 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（開始） 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateStAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateTimeSt
		/// <summary>更新時分秒ミリ秒（開始）プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時分秒ミリ秒（開始）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTimeSt
		{
			get { return _updateTimeSt; }
			set { _updateTimeSt = value; }
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
			get { return _inqEmployeeCd; }
			set { _inqEmployeeCd = value; }
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
			get { return _ansEmployeeCd; }
			set { _ansEmployeeCd = value; }
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get { return _inqOrdDivCd; }
			set { _inqOrdDivCd = value; }
		}

		/// public propaty name  :  LatestDiscCode
		/// <summary>最新識別区分プロパティ</summary>
		/// <value>0:最新データ 1:旧データ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最新識別区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 LatestDiscCode
		{
			get { return _latestDiscCode; }
			set { _latestDiscCode = value; }
		}

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM連携指示書番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SF-PM連携指示書番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SfPmCprtInstSlipNo
		{
			get { return _sfPmCprtInstSlipNo; }
			set { _sfPmCprtInstSlipNo = value; }
		}

		/// public propaty name  :  TransCmpltDivCd
		/// <summary>取引完了区分プロパティ</summary>
		/// <value>0:未完了 1:完了</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   取引完了区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TransCmpltDivCd
		{
			get { return _transCmpltDivCd; }
			set { _transCmpltDivCd = value; }
		}

		/// public propaty name  :  UpdateDateEd
		/// <summary>更新年月日（終了）プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateEd
		{
			get { return _updateDateEd; }
			set { _updateDateEd = value; }
		}

		/// public propaty name  :  UpdateDateEdJpFormal
		/// <summary>更新年月日（終了） 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（終了） 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateEdJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateDateEdJpInFormal
		/// <summary>更新年月日（終了） 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（終了） 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateEdJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateDateEdAdFormal
		/// <summary>更新年月日（終了） 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（終了） 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateEdAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateDateEdAdInFormal
		/// <summary>更新年月日（終了） 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日（終了） 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateEdAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateTimeEd
		/// <summary>更新時分ミリ秒（終了）プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時分ミリ秒（終了）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTimeEd
		{
			get { return _updateTimeEd; }
			set { _updateTimeEd = value; }
		}


		/// <summary>
		/// SCM受発注検索条件クラスコンストラクタ
		/// </summary>
		/// <returns>ScmOdSrchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdSrchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdSrchParam()
		{
		}

		/// <summary>
		/// SCM受発注検索条件クラスコンストラクタ
		/// </summary>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号(配列型)</param>
		/// <param name="inquiryNumberSt">問合せ番号(開始)</param>
		/// <param name="inquiryNumberEd">問合せ番号(終了)</param>
		/// <param name="updateDateSt">更新年月日（開始）(YYYYMMDD)</param>
		/// <param name="updateTimeSt">更新時分秒ミリ秒（開始）(HHMMSSXXX)</param>
		/// <param name="inqEmployeeCd">問合せ従業員コード(問合せした従業員コード)</param>
		/// <param name="ansEmployeeCd">回答従業員コード</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="latestDiscCode">最新識別区分(0:最新データ 1:旧データ)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM連携指示書番号</param>
		/// <param name="transCmpltDivCd">取引完了区分(0:未完了 1:完了)</param>
		/// <param name="updateDateEd">更新年月日（終了）(YYYYMMDD)</param>
		/// <param name="updateTimeEd">更新時分ミリ秒（終了）(HHMMSSXXX)</param>
		/// <returns>ScmOdSrchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdSrchParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdSrchParam(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64[] inquiryNumber, Int64 inquiryNumberSt, Int64 inquiryNumberEd, DateTime updateDateSt, Int32 updateTimeSt, string inqEmployeeCd, string ansEmployeeCd, Int32 inqOrdDivCd, Int16 latestDiscCode, string sfPmCprtInstSlipNo, Int32 transCmpltDivCd, DateTime updateDateEd, Int32 updateTimeEd)
		{
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this._inquiryNumberSt = inquiryNumberSt;
			this._inquiryNumberEd = inquiryNumberEd;
			this.UpdateDateSt = updateDateSt;
			this._updateTimeSt = updateTimeSt;
			this._inqEmployeeCd = inqEmployeeCd;
			this._ansEmployeeCd = ansEmployeeCd;
			this._inqOrdDivCd = inqOrdDivCd;
			this._latestDiscCode = latestDiscCode;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;
			this._transCmpltDivCd = transCmpltDivCd;
			this.UpdateDateEd = updateDateEd;
			this._updateTimeEd = updateTimeEd;

		}

		/// <summary>
		/// SCM受発注検索条件クラス複製処理
		/// </summary>
		/// <returns>ScmOdSrchParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmOdSrchParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdSrchParam Clone()
		{
			return new ScmOdSrchParam(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._inquiryNumberSt, this._inquiryNumberEd, this._updateDateSt, this._updateTimeSt, this._inqEmployeeCd, this._ansEmployeeCd, this._inqOrdDivCd, this._latestDiscCode, this._sfPmCprtInstSlipNo, this._transCmpltDivCd, this._updateDateEd, this._updateTimeEd);
		}

		/// <summary>
		/// SCM受発注検索条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdSrchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdSrchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmOdSrchParam target)
		{
			return ((this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.InquiryNumberSt == target.InquiryNumberSt)
				 && (this.InquiryNumberEd == target.InquiryNumberEd)
				 && (this.UpdateDateSt == target.UpdateDateSt)
				 && (this.UpdateTimeSt == target.UpdateTimeSt)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo)
				 && (this.TransCmpltDivCd == target.TransCmpltDivCd)
				 && (this.UpdateDateEd == target.UpdateDateEd)
				 && (this.UpdateTimeEd == target.UpdateTimeEd));
		}

		/// <summary>
		/// SCM受発注検索条件クラス比較処理
		/// </summary>
		/// <param name="scmOdSrchParam1">
		///                    比較するScmOdSrchParamクラスのインスタンス
		/// </param>
		/// <param name="scmOdSrchParam2">比較するScmOdSrchParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdSrchParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmOdSrchParam scmOdSrchParam1, ScmOdSrchParam scmOdSrchParam2)
		{
			return ((scmOdSrchParam1.InqOriginalEpCd == scmOdSrchParam2.InqOriginalEpCd)
				 && (scmOdSrchParam1.InqOriginalSecCd == scmOdSrchParam2.InqOriginalSecCd)
				 && (scmOdSrchParam1.InqOtherEpCd == scmOdSrchParam2.InqOtherEpCd)
				 && (scmOdSrchParam1.InqOtherSecCd == scmOdSrchParam2.InqOtherSecCd)
				 && (scmOdSrchParam1.InquiryNumber == scmOdSrchParam2.InquiryNumber)
				 && (scmOdSrchParam1.InquiryNumberSt == scmOdSrchParam2.InquiryNumberSt)
				 && (scmOdSrchParam1.InquiryNumberEd == scmOdSrchParam2.InquiryNumberEd)
				 && (scmOdSrchParam1.UpdateDateSt == scmOdSrchParam2.UpdateDateSt)
				 && (scmOdSrchParam1.UpdateTimeSt == scmOdSrchParam2.UpdateTimeSt)
				 && (scmOdSrchParam1.InqEmployeeCd == scmOdSrchParam2.InqEmployeeCd)
				 && (scmOdSrchParam1.AnsEmployeeCd == scmOdSrchParam2.AnsEmployeeCd)
				 && (scmOdSrchParam1.InqOrdDivCd == scmOdSrchParam2.InqOrdDivCd)
				 && (scmOdSrchParam1.LatestDiscCode == scmOdSrchParam2.LatestDiscCode)
				 && (scmOdSrchParam1.SfPmCprtInstSlipNo == scmOdSrchParam2.SfPmCprtInstSlipNo)
				 && (scmOdSrchParam1.TransCmpltDivCd == scmOdSrchParam2.TransCmpltDivCd)
				 && (scmOdSrchParam1.UpdateDateEd == scmOdSrchParam2.UpdateDateEd)
				 && (scmOdSrchParam1.UpdateTimeEd == scmOdSrchParam2.UpdateTimeEd));
		}
		/// <summary>
		/// SCM受発注検索条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdSrchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdSrchParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmOdSrchParam target)
		{
			ArrayList resList = new ArrayList();
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.InquiryNumberSt != target.InquiryNumberSt) resList.Add("InquiryNumberSt");
			if (this.InquiryNumberEd != target.InquiryNumberEd) resList.Add("InquiryNumberEd");
			if (this.UpdateDateSt != target.UpdateDateSt) resList.Add("UpdateDateSt");
			if (this.UpdateTimeSt != target.UpdateTimeSt) resList.Add("UpdateTimeSt");
			if (this.InqEmployeeCd != target.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (this.AnsEmployeeCd != target.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
			if (this.TransCmpltDivCd != target.TransCmpltDivCd) resList.Add("TransCmpltDivCd");
			if (this.UpdateDateEd != target.UpdateDateEd) resList.Add("UpdateDateEd");
			if (this.UpdateTimeEd != target.UpdateTimeEd) resList.Add("UpdateTimeEd");

			return resList;
		}

		/// <summary>
		/// SCM受発注検索条件クラス比較処理
		/// </summary>
		/// <param name="scmOdSrchParam1">比較するScmOdSrchParamクラスのインスタンス</param>
		/// <param name="scmOdSrchParam2">比較するScmOdSrchParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdSrchParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdSrchParam scmOdSrchParam1, ScmOdSrchParam scmOdSrchParam2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdSrchParam1.InqOriginalEpCd != scmOdSrchParam2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdSrchParam1.InqOriginalSecCd != scmOdSrchParam2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdSrchParam1.InqOtherEpCd != scmOdSrchParam2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdSrchParam1.InqOtherSecCd != scmOdSrchParam2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdSrchParam1.InquiryNumber != scmOdSrchParam2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdSrchParam1.InquiryNumberSt != scmOdSrchParam2.InquiryNumberSt) resList.Add("InquiryNumberSt");
			if (scmOdSrchParam1.InquiryNumberEd != scmOdSrchParam2.InquiryNumberEd) resList.Add("InquiryNumberEd");
			if (scmOdSrchParam1.UpdateDateSt != scmOdSrchParam2.UpdateDateSt) resList.Add("UpdateDateSt");
			if (scmOdSrchParam1.UpdateTimeSt != scmOdSrchParam2.UpdateTimeSt) resList.Add("UpdateTimeSt");
			if (scmOdSrchParam1.InqEmployeeCd != scmOdSrchParam2.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (scmOdSrchParam1.AnsEmployeeCd != scmOdSrchParam2.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (scmOdSrchParam1.InqOrdDivCd != scmOdSrchParam2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (scmOdSrchParam1.LatestDiscCode != scmOdSrchParam2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdSrchParam1.SfPmCprtInstSlipNo != scmOdSrchParam2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
			if (scmOdSrchParam1.TransCmpltDivCd != scmOdSrchParam2.TransCmpltDivCd) resList.Add("TransCmpltDivCd");
			if (scmOdSrchParam1.UpdateDateEd != scmOdSrchParam2.UpdateDateEd) resList.Add("UpdateDateEd");
			if (scmOdSrchParam1.UpdateTimeEd != scmOdSrchParam2.UpdateTimeEd) resList.Add("UpdateTimeEd");

			return resList;
		}
	}
}
