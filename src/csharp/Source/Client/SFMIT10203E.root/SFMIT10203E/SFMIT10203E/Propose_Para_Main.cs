using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Propose_Para_Main
	/// <summary>
	///                      提案商品起動パラメータクラス（メイン）
	/// </summary>
	/// <remarks>
	/// <br>note             :   提案商品起動パラメータクラス（メイン）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/05/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Propose_Para_Main
	{
		/// <summary>起動モード</summary>
		private Int16 _bootMode;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode  = "";

		/// <summary>従業員コード</summary>
		private string _employeeCode = "";

		/// <summary>従業員名称</summary>
		private string _employeeName = "";

		/// <summary>提案商品連動クラスリスト</summary>
		private List<Propose_Goods> _propose_GoodsList;

		/// <summary>提案商品起動パラメータクラス（SCM企業拠点連結）</summary>
		private List<Propose_Para_SCM> _propose_Para_SCM;

		/// <summary>提案商品起動パラメータクラス（拠点）</summary>
		private List<Propose_Para_Section> _propose_Para_Section;

		/// <summary>提案商品起動パラメータクラス（メーカー）</summary>
		private List<Propose_Para_Maker> _propose_Para_Maker;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";


		/// public propaty name  :  BootMode
		/// <summary>起動モードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   起動モードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 BootMode
		{
			get{return _bootMode;}
			set{_bootMode = value;}
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

		/// public propaty name  :  SectionCode 
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode 
		{
			get{return _sectionCode ;}
			set{_sectionCode  = value;}
		}

		/// public propaty name  :  EmployeeCode
		/// <summary>従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  EmployeeName
		/// <summary>従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeName
		{
			get{return _employeeName;}
			set{_employeeName = value;}
		}

		/// public propaty name  :  Propose_GoodsList
		/// <summary>提案商品連動クラスリストプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提案商品連動クラスリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<Propose_Goods> Propose_GoodsList
		{
			get{return _propose_GoodsList;}
			set{_propose_GoodsList = value;}
		}

		/// public propaty name  :  Propose_Para_SCM
		/// <summary>提案商品起動パラメータクラス（SCM企業拠点連結）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提案商品起動パラメータクラス（SCM企業拠点連結）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<Propose_Para_SCM> Propose_Para_SCM
		{
			get{return _propose_Para_SCM;}
			set{_propose_Para_SCM = value;}
		}

		/// public propaty name  :  Propose_Para_Section
		/// <summary>提案商品起動パラメータクラス（拠点）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提案商品起動パラメータクラス（拠点）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<Propose_Para_Section> Propose_Para_Section
		{
			get{return _propose_Para_Section;}
			set{_propose_Para_Section = value;}
		}

		/// public propaty name  :  Propose_Para_Maker
		/// <summary>提案商品起動パラメータクラス（メーカー）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   提案商品起動パラメータクラス（メーカー）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<Propose_Para_Maker> Propose_Para_Maker
		{
			get{return _propose_Para_Maker;}
			set{_propose_Para_Maker = value;}
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


		/// <summary>
		/// 提案商品起動パラメータクラス（メイン）コンストラクタ
		/// </summary>
		/// <returns>Propose_Para_Mainクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Mainクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Main()
		{
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メイン）コンストラクタ
		/// </summary>
		/// <param name="bootMode">起動モード</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode ">拠点コード</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="employeeName">従業員名称</param>
		/// <param name="propose_GoodsList">提案商品連動クラスリスト</param>
		/// <param name="propose_Para_SCM">提案商品起動パラメータクラス（SCM企業拠点連結）</param>
		/// <param name="propose_Para_Section">提案商品起動パラメータクラス（拠点）</param>
		/// <param name="propose_Para_Maker">提案商品起動パラメータクラス（メーカー）</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>Propose_Para_Mainクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Mainクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Main(Int16 bootMode,string enterpriseCode,string sectionCode ,string employeeCode,string employeeName,List<Propose_Goods> propose_GoodsList,List<Propose_Para_SCM> propose_Para_SCM,List<Propose_Para_Section> propose_Para_Section, List<Propose_Para_Maker> propose_Para_Maker,string enterpriseName)
		{
			this._bootMode = bootMode;
			this._enterpriseCode = enterpriseCode;
			this._sectionCode  = sectionCode ;
			this._employeeCode = employeeCode;
			this._employeeName = employeeName;
			this._propose_GoodsList = propose_GoodsList;
			this._propose_Para_SCM = propose_Para_SCM;
			this._propose_Para_Section = propose_Para_Section;
			this._propose_Para_Maker = propose_Para_Maker;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 提案商品起動パラメータクラス（メイン）複製処理
		/// </summary>
		/// <returns>Propose_Para_Mainクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいPropose_Para_Mainクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Main Clone()
		{
			return new Propose_Para_Main(this._bootMode,this._enterpriseCode,this._sectionCode ,this._employeeCode,this._employeeName,this._propose_GoodsList,this._propose_Para_SCM,this._propose_Para_Section,this._propose_Para_Maker,this._enterpriseName);
        }

        #region 使用しないので削除
        ///// <summary>
        ///// 提案商品起動パラメータクラス（メイン）比較処理
        ///// </summary>
        ///// <param name="target">比較対象のPropose_Para_Mainクラスのインスタンス</param>
        ///// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   Propose_Para_Mainクラスの内容が一致するか比較します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool Equals(Propose_Para_Main target)
        //{
        //    return ((this.BootMode == target.BootMode)
        //         && (this.EnterpriseCode == target.EnterpriseCode)
        //         && (this.SectionCode  == target.SectionCode )
        //         && (this.EmployeeCode == target.EmployeeCode)
        //         && (this.EmployeeName == target.EmployeeName)
        //         && (this.Propose_GoodsList == target.Propose_GoodsList)
        //         && (this.Propose_Para_SCM == target.Propose_Para_SCM)
        //         && (this.Propose_Para_Section == target.Propose_Para_Section)
        //         && (this.Propose_Para_Maker == target.Propose_Para_Maker)
        //         && (this.EnterpriseName == target.EnterpriseName));
        //}

        ///// <summary>
        ///// 提案商品起動パラメータクラス（メイン）比較処理
        ///// </summary>
        ///// <param name="propose_Para_Main1">
        /////                    比較するPropose_Para_Mainクラスのインスタンス
        ///// </param>
        ///// <param name="propose_Para_Main2">比較するPropose_Para_Mainクラスのインスタンス</param>
        ///// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   Propose_Para_Mainクラスの内容が一致するか比較します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public static bool Equals(Propose_Para_Main propose_Para_Main1, Propose_Para_Main propose_Para_Main2)
        //{
        //    return ((propose_Para_Main1.BootMode == propose_Para_Main2.BootMode)
        //         && (propose_Para_Main1.EnterpriseCode == propose_Para_Main2.EnterpriseCode)
        //         && (propose_Para_Main1.SectionCode  == propose_Para_Main2.SectionCode )
        //         && (propose_Para_Main1.EmployeeCode == propose_Para_Main2.EmployeeCode)
        //         && (propose_Para_Main1.EmployeeName == propose_Para_Main2.EmployeeName)
        //         && (propose_Para_Main1.Propose_GoodsList == propose_Para_Main2.Propose_GoodsList)
        //         && (propose_Para_Main1.Propose_Para_SCM == propose_Para_Main2.Propose_Para_SCM)
        //         && (propose_Para_Main1.Propose_Para_Section == propose_Para_Main2.Propose_Para_Section)
        //         && (propose_Para_Main1.Propose_Para_Maker == propose_Para_Main2.Propose_Para_Maker)
        //         && (propose_Para_Main1.EnterpriseName == propose_Para_Main2.EnterpriseName));
        //}
        ///// <summary>
        ///// 提案商品起動パラメータクラス（メイン）比較処理
        ///// </summary>
        ///// <param name="target">比較対象のPropose_Para_Mainクラスのインスタンス</param>
        ///// <returns>一致しない項目のリスト</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   Propose_Para_Mainクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public ArrayList Compare(Propose_Para_Main target)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(this.BootMode != target.BootMode)resList.Add("BootMode");
        //    if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(this.SectionCode  != target.SectionCode )resList.Add("SectionCode ");
        //    if(this.EmployeeCode != target.EmployeeCode)resList.Add("EmployeeCode");
        //    if(this.EmployeeName != target.EmployeeName)resList.Add("EmployeeName");
        //    if(this.Propose_GoodsList != target.Propose_GoodsList)resList.Add("Propose_GoodsList");
        //    if(this.Propose_Para_SCM != target.Propose_Para_SCM)resList.Add("Propose_Para_SCM");
        //    if(this.Propose_Para_Section != target.Propose_Para_Section)resList.Add("Propose_Para_Section");
        //    if(this.Propose_Para_Maker != target.Propose_Para_Maker)resList.Add("Propose_Para_Maker");
        //    if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

        //    return resList;
        //}

        ///// <summary>
        ///// 提案商品起動パラメータクラス（メイン）比較処理
        ///// </summary>
        ///// <param name="propose_Para_Main1">比較するPropose_Para_Mainクラスのインスタンス</param>
        ///// <param name="propose_Para_Main2">比較するPropose_Para_Mainクラスのインスタンス</param>
        ///// <returns>一致しない項目のリスト</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   Propose_Para_Mainクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public static ArrayList Compare(Propose_Para_Main propose_Para_Main1, Propose_Para_Main propose_Para_Main2)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(propose_Para_Main1.BootMode != propose_Para_Main2.BootMode)resList.Add("BootMode");
        //    if(propose_Para_Main1.EnterpriseCode != propose_Para_Main2.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(propose_Para_Main1.SectionCode  != propose_Para_Main2.SectionCode )resList.Add("SectionCode ");
        //    if(propose_Para_Main1.EmployeeCode != propose_Para_Main2.EmployeeCode)resList.Add("EmployeeCode");
        //    if(propose_Para_Main1.EmployeeName != propose_Para_Main2.EmployeeName)resList.Add("EmployeeName");
        //    if(propose_Para_Main1.Propose_GoodsList != propose_Para_Main2.Propose_GoodsList)resList.Add("Propose_GoodsList");
        //    if(propose_Para_Main1.Propose_Para_SCM != propose_Para_Main2.Propose_Para_SCM)resList.Add("Propose_Para_SCM");
        //    if(propose_Para_Main1.Propose_Para_Section != propose_Para_Main2.Propose_Para_Section)resList.Add("Propose_Para_Section");
        //    if(propose_Para_Main1.Propose_Para_Maker != propose_Para_Main2.Propose_Para_Maker)resList.Add("Propose_Para_Maker");
        //    if(propose_Para_Main1.EnterpriseName != propose_Para_Main2.EnterpriseName)resList.Add("EnterpriseName");

        //    return resList;
        //}
        #endregion
    }
}
