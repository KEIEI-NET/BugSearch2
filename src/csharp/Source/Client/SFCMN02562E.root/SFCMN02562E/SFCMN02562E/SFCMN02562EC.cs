using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmCnctSet
	/// <summary>
	///                      SCM連結元拠点別設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM連結元拠点別設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2011/5/25</br>
	/// <br>Genarated Date   :   2011/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ScmCnctSet
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

		/// <summary>PM指示書番号取扱区分</summary>
		/// <remarks>0：伝票番号,1：受注番号,2:プレート番号,3:追加情報2,4：検索補助として使用</remarks>
		private Int16 _pMInstNoHdlDivCd;


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

		/// public propaty name  :  CnectOriginalSecCd
		/// <summary>連結元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   連結元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CnectOriginalSecCd
		{
			get{return _cnectOriginalSecCd;}
			set{_cnectOriginalSecCd = value;}
		}

		/// public propaty name  :  PMInstNoHdlDivCd
		/// <summary>PM指示書番号取扱区分プロパティ</summary>
		/// <value>0：伝票番号,1：受注番号,2:プレート番号,3:追加情報2,4：検索補助として使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM指示書番号取扱区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 PMInstNoHdlDivCd
		{
			get{return _pMInstNoHdlDivCd;}
			set{_pMInstNoHdlDivCd = value;}
		}


		/// <summary>
		/// SCM連結元拠点別設定マスタコンストラクタ
		/// </summary>
		/// <returns>ScmCnctSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmCnctSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmCnctSet()
		{
		}

		/// <summary>
		/// SCM連結元拠点別設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalSecCd">連結元拠点コード</param>
		/// <param name="pMInstNoHdlDivCd">PM指示書番号取扱区分(0：伝票番号,1：受注番号,2:プレート番号,3:追加情報2,4：検索補助として使用)</param>
		/// <returns>ScmCnctSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmCnctSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmCnctSet(DateTime createDateTime,DateTime updateDateTime,Int32 logicalDeleteCode,string cnectOriginalEpCd,string cnectOriginalSecCd,Int16 pMInstNoHdlDivCd)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._cnectOriginalEpCd = cnectOriginalEpCd;
			this._cnectOriginalSecCd = cnectOriginalSecCd;
			this._pMInstNoHdlDivCd = pMInstNoHdlDivCd;

		}

		/// <summary>
		/// SCM連結元拠点別設定マスタ複製処理
		/// </summary>
		/// <returns>ScmCnctSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmCnctSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmCnctSet Clone()
		{
			return new ScmCnctSet(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._cnectOriginalEpCd,this._cnectOriginalSecCd,this._pMInstNoHdlDivCd);
		}

		/// <summary>
		/// SCM連結元拠点別設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmCnctSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmCnctSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmCnctSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
				 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
				 && (this.PMInstNoHdlDivCd == target.PMInstNoHdlDivCd));
		}

		/// <summary>
		/// SCM連結元拠点別設定マスタ比較処理
		/// </summary>
		/// <param name="scmCnctSet1">
		///                    比較するScmCnctSetクラスのインスタンス
		/// </param>
		/// <param name="scmCnctSet2">比較するScmCnctSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmCnctSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmCnctSet scmCnctSet1, ScmCnctSet scmCnctSet2)
		{
			return ((scmCnctSet1.CreateDateTime == scmCnctSet2.CreateDateTime)
				 && (scmCnctSet1.UpdateDateTime == scmCnctSet2.UpdateDateTime)
				 && (scmCnctSet1.LogicalDeleteCode == scmCnctSet2.LogicalDeleteCode)
				 && (scmCnctSet1.CnectOriginalEpCd == scmCnctSet2.CnectOriginalEpCd)
				 && (scmCnctSet1.CnectOriginalSecCd == scmCnctSet2.CnectOriginalSecCd)
				 && (scmCnctSet1.PMInstNoHdlDivCd == scmCnctSet2.PMInstNoHdlDivCd));
		}
		/// <summary>
		/// SCM連結元拠点別設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のScmCnctSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmCnctSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmCnctSet target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.CnectOriginalEpCd != target.CnectOriginalEpCd)resList.Add("CnectOriginalEpCd");
			if(this.CnectOriginalSecCd != target.CnectOriginalSecCd)resList.Add("CnectOriginalSecCd");
			if(this.PMInstNoHdlDivCd != target.PMInstNoHdlDivCd)resList.Add("PMInstNoHdlDivCd");

			return resList;
		}

		/// <summary>
		/// SCM連結元拠点別設定マスタ比較処理
		/// </summary>
		/// <param name="scmCnctSet1">比較するScmCnctSetクラスのインスタンス</param>
		/// <param name="scmCnctSet2">比較するScmCnctSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmCnctSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmCnctSet scmCnctSet1, ScmCnctSet scmCnctSet2)
		{
			ArrayList resList = new ArrayList();
			if(scmCnctSet1.CreateDateTime != scmCnctSet2.CreateDateTime)resList.Add("CreateDateTime");
			if(scmCnctSet1.UpdateDateTime != scmCnctSet2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(scmCnctSet1.LogicalDeleteCode != scmCnctSet2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(scmCnctSet1.CnectOriginalEpCd != scmCnctSet2.CnectOriginalEpCd)resList.Add("CnectOriginalEpCd");
			if(scmCnctSet1.CnectOriginalSecCd != scmCnctSet2.CnectOriginalSecCd)resList.Add("CnectOriginalSecCd");
			if(scmCnctSet1.PMInstNoHdlDivCd != scmCnctSet2.PMInstNoHdlDivCd)resList.Add("PMInstNoHdlDivCd");

			return resList;
		}
	}
}
