using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   UnPrcInfoConfRet
	/// <summary>
	///                      単価情報確認結果
	/// </summary>
	/// <remarks>
	/// <br>note             :   単価情報確認結果ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/06/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class UnPrcInfoConfRet
	{
		/// <summary>単価算出区分</summary>
		/// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
		private Int32 _unitPrcCalcDiv;

		/// <summary>掛率</summary>
		/// <remarks>掛率</remarks>
		private Double _rateVal;

		/// <summary>単価端数処理単位</summary>
		private Double _unPrcFracProcUnit;

		/// <summary>単価端数処理区分</summary>
		private Int32 _unPrcFracProcDiv;

		/// <summary>基準単価</summary>
		private Double _stdUnitPrice;

		/// <summary>単価（税抜，浮動）</summary>
		private Double _unitPriceTaxExcFl;

		/// <summary>単価（税込，浮動）</summary>
		private Double _unitPriceTaxIncFl;


		/// public propaty name  :  UnitPrcCalcDiv
		/// <summary>単価算出区分プロパティ</summary>
		/// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価算出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnitPrcCalcDiv
		{
			get { return _unitPrcCalcDiv; }
			set { _unitPrcCalcDiv = value; }
		}

		/// public propaty name  :  RateVal
		/// <summary>掛率プロパティ</summary>
		/// <value>掛率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double RateVal
		{
			get { return _rateVal; }
			set { _rateVal = value; }
		}

		/// public propaty name  :  UnPrcFracProcUnit
		/// <summary>単価端数処理単位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価端数処理単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double UnPrcFracProcUnit
		{
			get { return _unPrcFracProcUnit; }
			set { _unPrcFracProcUnit = value; }
		}

		/// public propaty name  :  UnPrcFracProcDiv
		/// <summary>単価端数処理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcFracProcDiv
		{
			get { return _unPrcFracProcDiv; }
			set { _unPrcFracProcDiv = value; }
		}

		/// public propaty name  :  StdUnitPrice
		/// <summary>基準単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   基準単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StdUnitPrice
		{
			get { return _stdUnitPrice; }
			set { _stdUnitPrice = value; }
		}

		/// public propaty name  :  UnitPriceTaxExcFl
		/// <summary>単価（税抜，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double UnitPriceTaxExcFl
		{
			get { return _unitPriceTaxExcFl; }
			set { _unitPriceTaxExcFl = value; }
		}

		/// public propaty name  :  UnitPriceTaxIncFl
		/// <summary>単価（税込，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double UnitPriceTaxIncFl
		{
			get { return _unitPriceTaxIncFl; }
			set { _unitPriceTaxIncFl = value; }
		}


		/// <summary>
		/// 単価情報確認結果コンストラクタ
		/// </summary>
		/// <returns>UnPrcInfoConfRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UnPrcInfoConfRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UnPrcInfoConfRet()
		{
		}

		/// <summary>
		/// 単価情報確認結果コンストラクタ
		/// </summary>
		/// <param name="unitPrcCalcDiv">単価算出区分(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
		/// <param name="rateVal">掛率(掛率)</param>
		/// <param name="unPrcFracProcUnit">単価端数処理単位</param>
		/// <param name="unPrcFracProcDiv">単価端数処理区分</param>
		/// <param name="stdUnitPrice">基準単価</param>
		/// <param name="unitPriceTaxExcFl">単価（税抜，浮動）</param>
		/// <param name="unitPriceTaxIncFl">単価（税込，浮動）</param>
		/// <returns>UnPrcInfoConfRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UnPrcInfoConfRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UnPrcInfoConfRet( Int32 unitPrcCalcDiv, Double rateVal, Double unPrcFracProcUnit, Int32 unPrcFracProcDiv, Double stdUnitPrice, Double unitPriceTaxExcFl, Double unitPriceTaxIncFl )
		{
			this._unitPrcCalcDiv = unitPrcCalcDiv;
			this._rateVal = rateVal;
			this._unPrcFracProcUnit = unPrcFracProcUnit;
			this._unPrcFracProcDiv = unPrcFracProcDiv;
			this._stdUnitPrice = stdUnitPrice;
			this._unitPriceTaxExcFl = unitPriceTaxExcFl;
			this._unitPriceTaxIncFl = unitPriceTaxIncFl;

		}

		/// <summary>
		/// 単価情報確認結果複製処理
		/// </summary>
		/// <returns>UnPrcInfoConfRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいUnPrcInfoConfRetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UnPrcInfoConfRet Clone()
		{
			return new UnPrcInfoConfRet(this._unitPrcCalcDiv, this._rateVal, this._unPrcFracProcUnit, this._unPrcFracProcDiv, this._stdUnitPrice, this._unitPriceTaxExcFl, this._unitPriceTaxIncFl);
		}

		/// <summary>
		/// 単価情報確認結果比較処理
		/// </summary>
		/// <param name="target">比較対象のUnPrcInfoConfRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UnPrcInfoConfRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals( UnPrcInfoConfRet target )
		{
			return ( ( this.UnitPrcCalcDiv == target.UnitPrcCalcDiv )
				 && ( this.RateVal == target.RateVal )
				 && ( this.UnPrcFracProcUnit == target.UnPrcFracProcUnit )
				 && ( this.UnPrcFracProcDiv == target.UnPrcFracProcDiv )
				 && ( this.StdUnitPrice == target.StdUnitPrice )
				 && ( this.UnitPriceTaxExcFl == target.UnitPriceTaxExcFl )
				 && ( this.UnitPriceTaxIncFl == target.UnitPriceTaxIncFl ) );
		}

		/// <summary>
		/// 単価情報確認結果比較処理
		/// </summary>
		/// <param name="unPrcInfoConfRet1">
		///                    比較するUnPrcInfoConfRetクラスのインスタンス
		/// </param>
		/// <param name="unPrcInfoConfRet2">比較するUnPrcInfoConfRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UnPrcInfoConfRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals( UnPrcInfoConfRet unPrcInfoConfRet1, UnPrcInfoConfRet unPrcInfoConfRet2 )
		{
			return ( ( unPrcInfoConfRet1.UnitPrcCalcDiv == unPrcInfoConfRet2.UnitPrcCalcDiv )
				 && ( unPrcInfoConfRet1.RateVal == unPrcInfoConfRet2.RateVal )
				 && ( unPrcInfoConfRet1.UnPrcFracProcUnit == unPrcInfoConfRet2.UnPrcFracProcUnit )
				 && ( unPrcInfoConfRet1.UnPrcFracProcDiv == unPrcInfoConfRet2.UnPrcFracProcDiv )
				 && ( unPrcInfoConfRet1.StdUnitPrice == unPrcInfoConfRet2.StdUnitPrice )
				 && ( unPrcInfoConfRet1.UnitPriceTaxExcFl == unPrcInfoConfRet2.UnitPriceTaxExcFl )
				 && ( unPrcInfoConfRet1.UnitPriceTaxIncFl == unPrcInfoConfRet2.UnitPriceTaxIncFl ) );
		}
		/// <summary>
		/// 単価情報確認結果比較処理
		/// </summary>
		/// <param name="target">比較対象のUnPrcInfoConfRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UnPrcInfoConfRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare( UnPrcInfoConfRet target )
		{
			ArrayList resList = new ArrayList();
			if (this.UnitPrcCalcDiv != target.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
			if (this.RateVal != target.RateVal) resList.Add("RateVal");
			if (this.UnPrcFracProcUnit != target.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
			if (this.UnPrcFracProcDiv != target.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
			if (this.StdUnitPrice != target.StdUnitPrice) resList.Add("StdUnitPrice");
			if (this.UnitPriceTaxExcFl != target.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
			if (this.UnitPriceTaxIncFl != target.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");

			return resList;
		}

		/// <summary>
		/// 単価情報確認結果比較処理
		/// </summary>
		/// <param name="unPrcInfoConfRet1">比較するUnPrcInfoConfRetクラスのインスタンス</param>
		/// <param name="unPrcInfoConfRet2">比較するUnPrcInfoConfRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UnPrcInfoConfRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare( UnPrcInfoConfRet unPrcInfoConfRet1, UnPrcInfoConfRet unPrcInfoConfRet2 )
		{
			ArrayList resList = new ArrayList();
			if (unPrcInfoConfRet1.UnitPrcCalcDiv != unPrcInfoConfRet2.UnitPrcCalcDiv) resList.Add("UnitPrcCalcDiv");
			if (unPrcInfoConfRet1.RateVal != unPrcInfoConfRet2.RateVal) resList.Add("RateVal");
			if (unPrcInfoConfRet1.UnPrcFracProcUnit != unPrcInfoConfRet2.UnPrcFracProcUnit) resList.Add("UnPrcFracProcUnit");
			if (unPrcInfoConfRet1.UnPrcFracProcDiv != unPrcInfoConfRet2.UnPrcFracProcDiv) resList.Add("UnPrcFracProcDiv");
			if (unPrcInfoConfRet1.StdUnitPrice != unPrcInfoConfRet2.StdUnitPrice) resList.Add("StdUnitPrice");
			if (unPrcInfoConfRet1.UnitPriceTaxExcFl != unPrcInfoConfRet2.UnitPriceTaxExcFl) resList.Add("UnitPriceTaxExcFl");
			if (unPrcInfoConfRet1.UnitPriceTaxIncFl != unPrcInfoConfRet2.UnitPriceTaxIncFl) resList.Add("UnitPriceTaxIncFl");

			return resList;
		}
	}
}
