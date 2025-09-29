using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   DMGuidanceDevelopSelect
	/// <summary>
	///                      DM案内文展開判断クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   DM案内文展開判断クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/11/16</br>
	/// <br>Genarated Date   :   2007/11/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class DMGuidanceDevelopSelect
	{
		/// <summary>プログラムID</summary>
		private string _pgId = "";

		/// <summary>展開区分</summary>
		/// <remarks>0:展開有り,1:展開無し</remarks>
		private Int32 _developCd;


		/// public propaty name  :  PgId
		/// <summary>プログラムIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   プログラムIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PgId
		{
			get{return _pgId;}
			set{_pgId = value;}
		}

		/// public propaty name  :  DevelopCd
		/// <summary>展開区分プロパティ</summary>
		/// <value>0:展開有り,1:展開無し</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   展開区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DevelopCd
		{
			get{return _developCd;}
			set{_developCd = value;}
		}


		/// <summary>
		/// DM案内文展開判断クラスコンストラクタ
		/// </summary>
		/// <returns>DMGuidanceDevelopSelectクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DMGuidanceDevelopSelectクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DMGuidanceDevelopSelect()
		{
		}

		/// <summary>
		/// DM案内文展開判断クラスコンストラクタ
		/// </summary>
		/// <param name="pgId">プログラムID</param>
		/// <param name="developCd">展開区分(0:展開有り,1:展開無し)</param>
		/// <returns>DMGuidanceDevelopSelectクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DMGuidanceDevelopSelectクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DMGuidanceDevelopSelect(string pgId,Int32 developCd)
		{
			this._pgId = pgId;
			this._developCd = developCd;

		}

		/// <summary>
		/// DM案内文展開判断クラス複製処理
		/// </summary>
		/// <returns>DMGuidanceDevelopSelectクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいDMGuidanceDevelopSelectクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DMGuidanceDevelopSelect Clone()
		{
			return new DMGuidanceDevelopSelect(this._pgId,this._developCd);
		}

		/// <summary>
		/// DM案内文展開判断クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のDMGuidanceDevelopSelectクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DMGuidanceDevelopSelectクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(DMGuidanceDevelopSelect target)
		{
			return ((this.PgId == target.PgId)
				 && (this.DevelopCd == target.DevelopCd));
		}

		/// <summary>
		/// DM案内文展開判断クラス比較処理
		/// </summary>
		/// <param name="dMGuidanceDevelopSelect1">
		///                    比較するDMGuidanceDevelopSelectクラスのインスタンス
		/// </param>
		/// <param name="dMGuidanceDevelopSelect2">比較するDMGuidanceDevelopSelectクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DMGuidanceDevelopSelectクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(DMGuidanceDevelopSelect dMGuidanceDevelopSelect1, DMGuidanceDevelopSelect dMGuidanceDevelopSelect2)
		{
			return ((dMGuidanceDevelopSelect1.PgId == dMGuidanceDevelopSelect2.PgId)
				 && (dMGuidanceDevelopSelect1.DevelopCd == dMGuidanceDevelopSelect2.DevelopCd));
		}
		/// <summary>
		/// DM案内文展開判断クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のDMGuidanceDevelopSelectクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DMGuidanceDevelopSelectクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(DMGuidanceDevelopSelect target)
		{
			ArrayList resList = new ArrayList();
			if(this.PgId != target.PgId)resList.Add("PgId");
			if(this.DevelopCd != target.DevelopCd)resList.Add("DevelopCd");

			return resList;
		}

		/// <summary>
		/// DM案内文展開判断クラス比較処理
		/// </summary>
		/// <param name="dMGuidanceDevelopSelect1">比較するDMGuidanceDevelopSelectクラスのインスタンス</param>
		/// <param name="dMGuidanceDevelopSelect2">比較するDMGuidanceDevelopSelectクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DMGuidanceDevelopSelectクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(DMGuidanceDevelopSelect dMGuidanceDevelopSelect1, DMGuidanceDevelopSelect dMGuidanceDevelopSelect2)
		{
			ArrayList resList = new ArrayList();
			if(dMGuidanceDevelopSelect1.PgId != dMGuidanceDevelopSelect2.PgId)resList.Add("PgId");
			if(dMGuidanceDevelopSelect1.DevelopCd != dMGuidanceDevelopSelect2.DevelopCd)resList.Add("DevelopCd");

			return resList;
		}
	}
}