using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmPopParamDtl
	/// <summary>
	///                      SCMポップアップ条件クラス(明細)
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCMポップアップ条件クラス(明細)ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/4/30</br>
	/// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class ScmPopParamDtl
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

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;


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


		/// <summary>
		/// SCMポップアップ条件クラス(明細)コンストラクタ
		/// </summary>
		/// <returns>ScmPopParamDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmPopParamDtl()
		{
		}

		/// <summary>
		/// SCMポップアップ条件クラス(明細)コンストラクタ
		/// </summary>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <returns>ScmPopParamDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmPopParamDtl(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime)
		{
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;

		}

		/// <summary>
		/// SCMポップアップ条件クラス(明細)複製処理
		/// </summary>
		/// <returns>ScmPopParamDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmPopParamDtlクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmPopParamDtl Clone()
		{
			return new ScmPopParamDtl(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime);
		}

		/// <summary>
		/// SCMポップアップ条件クラス(明細)比較処理
		/// </summary>
		/// <param name="target">比較対象のScmPopParamDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmPopParamDtl target)
		{
			return ((this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime));
		}

		/// <summary>
		/// SCMポップアップ条件クラス(明細)比較処理
		/// </summary>
		/// <param name="scmPopParamDtl1">
		///                    比較するScmPopParamDtlクラスのインスタンス
		/// </param>
		/// <param name="scmPopParamDtl2">比較するScmPopParamDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmPopParamDtl scmPopParamDtl1, ScmPopParamDtl scmPopParamDtl2)
		{
			return ((scmPopParamDtl1.InqOriginalEpCd == scmPopParamDtl2.InqOriginalEpCd)
				 && (scmPopParamDtl1.InqOriginalSecCd == scmPopParamDtl2.InqOriginalSecCd)
				 && (scmPopParamDtl1.InqOtherEpCd == scmPopParamDtl2.InqOtherEpCd)
				 && (scmPopParamDtl1.InqOtherSecCd == scmPopParamDtl2.InqOtherSecCd)
				 && (scmPopParamDtl1.InquiryNumber == scmPopParamDtl2.InquiryNumber)
				 && (scmPopParamDtl1.UpdateDate == scmPopParamDtl2.UpdateDate)
				 && (scmPopParamDtl1.UpdateTime == scmPopParamDtl2.UpdateTime));
		}
		/// <summary>
		/// SCMポップアップ条件クラス(明細)比較処理
		/// </summary>
		/// <param name="target">比較対象のScmPopParamDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmPopParamDtl target)
		{
			ArrayList resList = new ArrayList();
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");

			return resList;
		}

		/// <summary>
		/// SCMポップアップ条件クラス(明細)比較処理
		/// </summary>
		/// <param name="scmPopParamDtl1">比較するScmPopParamDtlクラスのインスタンス</param>
		/// <param name="scmPopParamDtl2">比較するScmPopParamDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmPopParamDtl scmPopParamDtl1, ScmPopParamDtl scmPopParamDtl2)
		{
			ArrayList resList = new ArrayList();
			if (scmPopParamDtl1.InqOriginalEpCd != scmPopParamDtl2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmPopParamDtl1.InqOriginalSecCd != scmPopParamDtl2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmPopParamDtl1.InqOtherEpCd != scmPopParamDtl2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmPopParamDtl1.InqOtherSecCd != scmPopParamDtl2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmPopParamDtl1.InquiryNumber != scmPopParamDtl2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmPopParamDtl1.UpdateDate != scmPopParamDtl2.UpdateDate) resList.Add("UpdateDate");
			if (scmPopParamDtl1.UpdateTime != scmPopParamDtl2.UpdateTime) resList.Add("UpdateTime");

			return resList;
		}
	}
}
