using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   Propose_Para_Section
	/// <summary>
	///                      提案商品起動パラメータクラス（拠点）
	/// </summary>
	/// <remarks>
	/// <br>note             :   提案商品起動パラメータクラス（拠点）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/05/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class Propose_Para_Section
	{
		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>本社機能フラグ</summary>
		/// <remarks>0:拠点 1:本社</remarks>
		private Int32 _mainOfficeFuncFlag;


		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  MainOfficeFuncFlag
		/// <summary>本社機能フラグプロパティ</summary>
		/// <value>0:拠点 1:本社</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   本社機能フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MainOfficeFuncFlag
		{
			get{return _mainOfficeFuncFlag;}
			set{_mainOfficeFuncFlag = value;}
		}


		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）コンストラクタ
		/// </summary>
		/// <returns>Propose_Para_Sectionクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Sectionクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Section()
		{
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）コンストラクタ
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="sectionGuideNm">拠点ガイド名称</param>
		/// <param name="mainOfficeFuncFlag">本社機能フラグ(0:拠点 1:本社)</param>
		/// <returns>Propose_Para_Sectionクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Sectionクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Section(string sectionCode,string sectionGuideNm,Int32 mainOfficeFuncFlag)
		{
			this._sectionCode = sectionCode;
			this._sectionGuideNm = sectionGuideNm;
			this._mainOfficeFuncFlag = mainOfficeFuncFlag;

		}

		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）複製処理
		/// </summary>
		/// <returns>Propose_Para_Sectionクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいPropose_Para_Sectionクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Propose_Para_Section Clone()
		{
			return new Propose_Para_Section(this._sectionCode,this._sectionGuideNm,this._mainOfficeFuncFlag);
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）比較処理
		/// </summary>
		/// <param name="target">比較対象のPropose_Para_Sectionクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Sectionクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(Propose_Para_Section target)
		{
			return ((this.SectionCode == target.SectionCode)
				 && (this.SectionGuideNm == target.SectionGuideNm)
				 && (this.MainOfficeFuncFlag == target.MainOfficeFuncFlag));
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）比較処理
		/// </summary>
		/// <param name="propose_Para_Section1">
		///                    比較するPropose_Para_Sectionクラスのインスタンス
		/// </param>
		/// <param name="propose_Para_Section2">比較するPropose_Para_Sectionクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Sectionクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(Propose_Para_Section propose_Para_Section1, Propose_Para_Section propose_Para_Section2)
		{
			return ((propose_Para_Section1.SectionCode == propose_Para_Section2.SectionCode)
				 && (propose_Para_Section1.SectionGuideNm == propose_Para_Section2.SectionGuideNm)
				 && (propose_Para_Section1.MainOfficeFuncFlag == propose_Para_Section2.MainOfficeFuncFlag));
		}
		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）比較処理
		/// </summary>
		/// <param name="target">比較対象のPropose_Para_Sectionクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Sectionクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(Propose_Para_Section target)
		{
			ArrayList resList = new ArrayList();
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SectionGuideNm != target.SectionGuideNm)resList.Add("SectionGuideNm");
			if(this.MainOfficeFuncFlag != target.MainOfficeFuncFlag)resList.Add("MainOfficeFuncFlag");

			return resList;
		}

		/// <summary>
		/// 提案商品起動パラメータクラス（拠点）比較処理
		/// </summary>
		/// <param name="propose_Para_Section1">比較するPropose_Para_Sectionクラスのインスタンス</param>
		/// <param name="propose_Para_Section2">比較するPropose_Para_Sectionクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Propose_Para_Sectionクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(Propose_Para_Section propose_Para_Section1, Propose_Para_Section propose_Para_Section2)
		{
			ArrayList resList = new ArrayList();
			if(propose_Para_Section1.SectionCode != propose_Para_Section2.SectionCode)resList.Add("SectionCode");
			if(propose_Para_Section1.SectionGuideNm != propose_Para_Section2.SectionGuideNm)resList.Add("SectionGuideNm");
			if(propose_Para_Section1.MainOfficeFuncFlag != propose_Para_Section2.MainOfficeFuncFlag)resList.Add("MainOfficeFuncFlag");

			return resList;
		}
	}
}
