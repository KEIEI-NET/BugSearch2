using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdReadParam
	/// <summary>
	///                      SCM受発注読込条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受発注読込条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/4/30</br>
	/// <br>Genarated Date   :   2011/05/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2011/5/19  本告　匡啓</br>
	/// <br>                 :   SCMオプション(PM連携 3次改良)対応</br>
	/// <br>                 :   ・SF-PM連携指示書番号</br>
	/// <br>                 :   項目追加</br>
	/// </remarks>
	[Serializable]
	public class ScmOdReadParam
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
		private Int64 _inquiryNumber;

		/// <summary>最新識別区分</summary>
		/// <remarks>0:最新データ 1:旧データ</remarks>
		private Int16 _latestDiscCode;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>SF-PM連携指示書番号</summary>
		private string _sfPmCprtInstSlipNo = "";


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
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
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
			get { return _updateDate; }
			set { _updateDate = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
			set { }
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
			get { return _updateTime; }
			set { _updateTime = value; }
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>問発・回答種別プロパティ</summary>
		/// <value>1:問合せ・発注 2:回答</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発・回答種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get { return _inqOrdAnsDivCd; }
			set { _inqOrdAnsDivCd = value; }
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


		/// <summary>
		/// SCM受発注読込条件クラスコンストラクタ
		/// </summary>
		/// <returns>ScmOdReadParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdReadParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdReadParam()
		{
		}

		/// <summary>
		/// SCM受発注読込条件クラスコンストラクタ
		/// </summary>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号</param>
		/// <param name="latestDiscCode">最新識別区分(0:最新データ 1:旧データ)</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="inqOrdAnsDivCd">問発・回答種別(1:問合せ・発注 2:回答)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM連携指示書番号</param>
		/// <returns>ScmOdReadParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdReadParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdReadParam(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int16 latestDiscCode, DateTime updateDate, Int32 updateTime, Int32 inqOrdAnsDivCd, string sfPmCprtInstSlipNo)
		{
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this._latestDiscCode = latestDiscCode;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;

		}

		/// <summary>
		/// SCM受発注読込条件クラス複製処理
		/// </summary>
		/// <returns>ScmOdReadParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmOdReadParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdReadParam Clone()
		{
			return new ScmOdReadParam(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._latestDiscCode, this._updateDate, this._updateTime, this._inqOrdAnsDivCd, this._sfPmCprtInstSlipNo);
		}

		/// <summary>
		/// SCM受発注読込条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdReadParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdReadParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmOdReadParam target)
		{
			return ((this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo));
		}

		/// <summary>
		/// SCM受発注読込条件クラス比較処理
		/// </summary>
		/// <param name="scmOdReadParam1">
		///                    比較するScmOdReadParamクラスのインスタンス
		/// </param>
		/// <param name="scmOdReadParam2">比較するScmOdReadParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdReadParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmOdReadParam scmOdReadParam1, ScmOdReadParam scmOdReadParam2)
		{
			return ((scmOdReadParam1.InqOriginalEpCd == scmOdReadParam2.InqOriginalEpCd)
				 && (scmOdReadParam1.InqOriginalSecCd == scmOdReadParam2.InqOriginalSecCd)
				 && (scmOdReadParam1.InqOtherEpCd == scmOdReadParam2.InqOtherEpCd)
				 && (scmOdReadParam1.InqOtherSecCd == scmOdReadParam2.InqOtherSecCd)
				 && (scmOdReadParam1.InquiryNumber == scmOdReadParam2.InquiryNumber)
				 && (scmOdReadParam1.LatestDiscCode == scmOdReadParam2.LatestDiscCode)
				 && (scmOdReadParam1.UpdateDate == scmOdReadParam2.UpdateDate)
				 && (scmOdReadParam1.UpdateTime == scmOdReadParam2.UpdateTime)
				 && (scmOdReadParam1.InqOrdAnsDivCd == scmOdReadParam2.InqOrdAnsDivCd)
				 && (scmOdReadParam1.SfPmCprtInstSlipNo == scmOdReadParam2.SfPmCprtInstSlipNo));
		}
		/// <summary>
		/// SCM受発注読込条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdReadParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdReadParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmOdReadParam target)
		{
			ArrayList resList = new ArrayList();
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
			if (this.InqOrdAnsDivCd != target.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");

			return resList;
		}

		/// <summary>
		/// SCM受発注読込条件クラス比較処理
		/// </summary>
		/// <param name="scmOdReadParam1">比較するScmOdReadParamクラスのインスタンス</param>
		/// <param name="scmOdReadParam2">比較するScmOdReadParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdReadParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdReadParam scmOdReadParam1, ScmOdReadParam scmOdReadParam2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdReadParam1.InqOriginalEpCd != scmOdReadParam2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdReadParam1.InqOriginalSecCd != scmOdReadParam2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdReadParam1.InqOtherEpCd != scmOdReadParam2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdReadParam1.InqOtherSecCd != scmOdReadParam2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdReadParam1.InquiryNumber != scmOdReadParam2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdReadParam1.LatestDiscCode != scmOdReadParam2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdReadParam1.UpdateDate != scmOdReadParam2.UpdateDate) resList.Add("UpdateDate");
			if (scmOdReadParam1.UpdateTime != scmOdReadParam2.UpdateTime) resList.Add("UpdateTime");
			if (scmOdReadParam1.InqOrdAnsDivCd != scmOdReadParam2.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (scmOdReadParam1.SfPmCprtInstSlipNo != scmOdReadParam2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");

			return resList;
		}
	}
}
