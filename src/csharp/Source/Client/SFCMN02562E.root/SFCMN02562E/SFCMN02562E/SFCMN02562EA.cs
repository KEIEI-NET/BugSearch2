using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmEpCnect
	/// <summary>
	///                      SCM企業連結マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM企業連結マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2009/05/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ScmEpCnect 
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

		/// <summary>連結元企業名称</summary>
		private string _cnectOriginalEpNm = "";

		/// <summary>連結先企業コード</summary>
		private string _cnectOtherEpCd = "";

		/// <summary>連結先企業名称</summary>
		private string _cnectOtherEpNm = "";

		/// <summary>識別区分</summary>
		/// <remarks>0:連結有効 1:連結無効</remarks>
		private Int32 _discDivCd;


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

		/// public propaty name  :  CnectOriginalEpCd
		/// <summary>連結元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOriginalEpCd
		{
			get{return _cnectOriginalEpCd;}
			set{_cnectOriginalEpCd = value;}
		}

		/// public propaty name  :  CnectOriginalEpNm
		/// <summary>連結元企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結元企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOriginalEpNm
		{
			get{return _cnectOriginalEpNm;}
			set{_cnectOriginalEpNm = value;}
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
			get{return _cnectOtherEpCd;}
			set{_cnectOtherEpCd = value;}
		}

		/// public propaty name  :  CnectOtherEpNm
		/// <summary>連結先企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結先企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOtherEpNm
		{
			get{return _cnectOtherEpNm;}
			set{_cnectOtherEpNm = value;}
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
			get{return _discDivCd;}
			set{_discDivCd = value;}
		}


		/// <summary>
		/// SCM企業連結マスタコンストラクタ
		/// </summary>
		/// <returns>ScmEpCnectクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpCnectクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmEpCnect()
		{
		}

		/// <summary>
		/// SCM企業連結マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalEpNm">連結元企業名称</param>
		/// <param name="cnectOtherEpCd">連結先企業コード</param>
		/// <param name="cnectOtherEpNm">連結先企業名称</param>
		/// <param name="discDivCd">識別区分(0:連結有効 1:連結無効)</param>
		/// <returns>ScmEpCnectクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpCnectクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmEpCnect(DateTime createDateTime,DateTime updateDateTime,Int32 logicalDeleteCode,string cnectOriginalEpCd,string cnectOriginalEpNm,string cnectOtherEpCd,string cnectOtherEpNm,Int32 discDivCd)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._cnectOriginalEpCd = cnectOriginalEpCd;
			this._cnectOriginalEpNm = cnectOriginalEpNm;
			this._cnectOtherEpCd = cnectOtherEpCd;
			this._cnectOtherEpNm = cnectOtherEpNm;
			this._discDivCd = discDivCd;

		}

		/// <summary>
		/// SCM企業連結マスタ複製処理
		/// </summary>
		/// <returns>ScmEpCnectクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmEpCnectクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmEpCnect Clone()
		{
			return new ScmEpCnect(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._cnectOriginalEpCd,this._cnectOriginalEpNm,this._cnectOtherEpCd,this._cnectOtherEpNm,this._discDivCd);
		}

		/// <summary>
		/// SCM企業連結マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmEpCnectクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpCnectクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmEpCnect target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
				 && (this.CnectOriginalEpNm == target.CnectOriginalEpNm)
				 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
				 && (this.CnectOtherEpNm == target.CnectOtherEpNm)
				 && (this.DiscDivCd == target.DiscDivCd));
		}

		/// <summary>
		/// SCM企業連結マスタ比較処理
		/// </summary>
		/// <param name="scmEpCnect1">
		///                    比較するScmEpCnectクラスのインスタンス
		/// </param>
		/// <param name="scmEpCnect2">比較するScmEpCnectクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpCnectクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmEpCnect scmEpCnect1, ScmEpCnect scmEpCnect2)
		{
			return ((scmEpCnect1.CreateDateTime == scmEpCnect2.CreateDateTime)
				 && (scmEpCnect1.UpdateDateTime == scmEpCnect2.UpdateDateTime)
				 && (scmEpCnect1.LogicalDeleteCode == scmEpCnect2.LogicalDeleteCode)
				 && (scmEpCnect1.CnectOriginalEpCd == scmEpCnect2.CnectOriginalEpCd)
				 && (scmEpCnect1.CnectOriginalEpNm == scmEpCnect2.CnectOriginalEpNm)
				 && (scmEpCnect1.CnectOtherEpCd == scmEpCnect2.CnectOtherEpCd)
				 && (scmEpCnect1.CnectOtherEpNm == scmEpCnect2.CnectOtherEpNm)
				 && (scmEpCnect1.DiscDivCd == scmEpCnect2.DiscDivCd));
		}
		/// <summary>
		/// SCM企業連結マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmEpCnectクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpCnectクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmEpCnect target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.CnectOriginalEpCd != target.CnectOriginalEpCd)resList.Add("CnectOriginalEpCd");
			if(this.CnectOriginalEpNm != target.CnectOriginalEpNm)resList.Add("CnectOriginalEpNm");
			if(this.CnectOtherEpCd != target.CnectOtherEpCd)resList.Add("CnectOtherEpCd");
			if(this.CnectOtherEpNm != target.CnectOtherEpNm)resList.Add("CnectOtherEpNm");
			if(this.DiscDivCd != target.DiscDivCd)resList.Add("DiscDivCd");

			return resList;
		}

		/// <summary>
		/// SCM企業連結マスタ比較処理
		/// </summary>
		/// <param name="scmEpCnect1">比較するScmEpCnectクラスのインスタンス</param>
		/// <param name="scmEpCnect2">比較するScmEpCnectクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmEpCnectクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmEpCnect scmEpCnect1, ScmEpCnect scmEpCnect2)
		{
			ArrayList resList = new ArrayList();
			if(scmEpCnect1.CreateDateTime != scmEpCnect2.CreateDateTime)resList.Add("CreateDateTime");
			if(scmEpCnect1.UpdateDateTime != scmEpCnect2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(scmEpCnect1.LogicalDeleteCode != scmEpCnect2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(scmEpCnect1.CnectOriginalEpCd != scmEpCnect2.CnectOriginalEpCd)resList.Add("CnectOriginalEpCd");
			if(scmEpCnect1.CnectOriginalEpNm != scmEpCnect2.CnectOriginalEpNm)resList.Add("CnectOriginalEpNm");
			if(scmEpCnect1.CnectOtherEpCd != scmEpCnect2.CnectOtherEpCd)resList.Add("CnectOtherEpCd");
			if(scmEpCnect1.CnectOtherEpNm != scmEpCnect2.CnectOtherEpNm)resList.Add("CnectOtherEpNm");
			if(scmEpCnect1.DiscDivCd != scmEpCnect2.DiscDivCd)resList.Add("DiscDivCd");

			return resList;
		}
	}
}
