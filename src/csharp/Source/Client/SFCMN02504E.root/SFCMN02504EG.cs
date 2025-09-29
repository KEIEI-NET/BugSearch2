using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmPopParam
	/// <summary>
	///                      SCMポップアップ条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCMポップアップ条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/4/30</br>
	/// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class ScmPopParam
	{
		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;


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


		/// <summary>
		/// SCMポップアップ条件クラスコンストラクタ
		/// </summary>
		/// <returns>ScmPopParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmPopParam()
		{
		}

		/// <summary>
		/// SCMポップアップ条件クラスコンストラクタ
		/// </summary>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="inqOrdAnsDivCd">問発・回答種別(1:問合せ・発注 2:回答)</param>
		/// <returns>ScmPopParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmPopParam(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, DateTime updateDate, Int32 updateTime, Int32 inqOrdAnsDivCd)
		{
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;

		}

		/// <summary>
		/// SCMポップアップ条件クラス複製処理
		/// </summary>
		/// <returns>ScmPopParamクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmPopParamクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmPopParam Clone()
		{
			return new ScmPopParam(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._updateDate, this._updateTime, this._inqOrdAnsDivCd);
		}

		/// <summary>
		/// SCMポップアップ条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のScmPopParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmPopParam target)
		{
			return ((this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd));
		}

		/// <summary>
		/// SCMポップアップ条件クラス比較処理
		/// </summary>
		/// <param name="scmPopParam1">
		///                    比較するScmPopParamクラスのインスタンス
		/// </param>
		/// <param name="scmPopParam2">比較するScmPopParamクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmPopParam scmPopParam1, ScmPopParam scmPopParam2)
		{
			return ((scmPopParam1.InqOriginalEpCd == scmPopParam2.InqOriginalEpCd)
				 && (scmPopParam1.InqOriginalSecCd == scmPopParam2.InqOriginalSecCd)
				 && (scmPopParam1.InqOtherEpCd == scmPopParam2.InqOtherEpCd)
				 && (scmPopParam1.InqOtherSecCd == scmPopParam2.InqOtherSecCd)
				 && (scmPopParam1.UpdateDate == scmPopParam2.UpdateDate)
				 && (scmPopParam1.UpdateTime == scmPopParam2.UpdateTime)
				 && (scmPopParam1.InqOrdAnsDivCd == scmPopParam2.InqOrdAnsDivCd));
		}
		/// <summary>
		/// SCMポップアップ条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のScmPopParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmPopParam target)
		{
			ArrayList resList = new ArrayList();
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
			if (this.InqOrdAnsDivCd != target.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");

			return resList;
		}

		/// <summary>
		/// SCMポップアップ条件クラス比較処理
		/// </summary>
		/// <param name="scmPopParam1">比較するScmPopParamクラスのインスタンス</param>
		/// <param name="scmPopParam2">比較するScmPopParamクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmPopParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmPopParam scmPopParam1, ScmPopParam scmPopParam2)
		{
			ArrayList resList = new ArrayList();
			if (scmPopParam1.InqOriginalEpCd != scmPopParam2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmPopParam1.InqOriginalSecCd != scmPopParam2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmPopParam1.InqOtherEpCd != scmPopParam2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmPopParam1.InqOtherSecCd != scmPopParam2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmPopParam1.UpdateDate != scmPopParam2.UpdateDate) resList.Add("UpdateDate");
			if (scmPopParam1.UpdateTime != scmPopParam2.UpdateTime) resList.Add("UpdateTime");
			if (scmPopParam1.InqOrdAnsDivCd != scmPopParam2.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");

			return resList;
		}
	}
}
