using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ExtrInfo_UpdHisDspWork
	/// <summary>
	///                      更新履歴表示抽出条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   更新履歴表示抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ExtrInfo_UpdHisDspWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _addupSecCodeList;

		/// <summary>開始締次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  締次更新対象となった年月日</remarks>
		private Int32 _st_CAddUpUpdDate;

		/// <summary>終了締次更新年月日</summary>
		/// <remarks>"YYYYMMDD"  締次更新対象となった年月日</remarks>
		private Int32 _ed_CAddUpUpdDate;

		/// <summary>開始締次更新実行年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_CAddUpUpdExecDate;

		/// <summary>終了締次更新実行年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_CAddUpUpdExecDate;

		/// <summary>表示区分</summary>
		/// <remarks>0:請求、1:支払、2:売上月次、3:仕入月次</remarks>
		private Int32 _dispDiv;

		/// <summary>処理種別</summary>
		/// <remarks>-1全て、0:更新処理、1:解除処理</remarks>
		private Int32 _procKnd;

		/// <summary>結果種別</summary>
		/// <remarks>-1：全て、0：正常終了、1：異常終了</remarks>
		private Int32 _rsltKnd;


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

		/// public propaty name  :  AddupSecCodeList
		/// <summary>出力対象拠点プロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] AddupSecCodeList
		{
			get{return _addupSecCodeList;}
			set{_addupSecCodeList = value;}
		}

		/// public propaty name  :  St_CAddUpUpdDate
		/// <summary>開始締次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CAddUpUpdDate
		{
			get{return _st_CAddUpUpdDate;}
			set{_st_CAddUpUpdDate = value;}
		}

		/// public propaty name  :  Ed_CAddUpUpdDate
		/// <summary>終了締次更新年月日プロパティ</summary>
		/// <value>"YYYYMMDD"  締次更新対象となった年月日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了締次更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CAddUpUpdDate
		{
			get{return _ed_CAddUpUpdDate;}
			set{_ed_CAddUpUpdDate = value;}
		}

		/// public propaty name  :  St_CAddUpUpdExecDate
		/// <summary>開始締次更新実行年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始締次更新実行年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CAddUpUpdExecDate
		{
			get{return _st_CAddUpUpdExecDate;}
			set{_st_CAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  Ed_CAddUpUpdExecDate
		/// <summary>終了締次更新実行年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了締次更新実行年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CAddUpUpdExecDate
		{
			get{return _ed_CAddUpUpdExecDate;}
			set{_ed_CAddUpUpdExecDate = value;}
		}

		/// public propaty name  :  DispDiv
		/// <summary>表示区分プロパティ</summary>
		/// <value>0:請求、1:支払、2:売上月次、3:仕入月次</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DispDiv
		{
			get{return _dispDiv;}
			set{_dispDiv = value;}
		}

		/// public propaty name  :  ProcKnd
		/// <summary>処理種別プロパティ</summary>
		/// <value>-1全て、0:更新処理、1:解除処理</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ProcKnd
		{
			get{return _procKnd;}
			set{_procKnd = value;}
		}

		/// public propaty name  :  RsltKnd
		/// <summary>結果種別プロパティ</summary>
		/// <value>-1：全て、0：正常終了、1：異常終了</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結果種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RsltKnd
		{
			get{return _rsltKnd;}
			set{_rsltKnd = value;}
		}


		/// <summary>
		/// 更新履歴表示抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_UpdHisDspWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_UpdHisDspWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_UpdHisDspWork()
		{
		}

	}
}
