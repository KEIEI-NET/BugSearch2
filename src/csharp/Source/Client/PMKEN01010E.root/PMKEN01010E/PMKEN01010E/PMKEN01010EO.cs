using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CEquipInfoWork
	/// <summary>
	///                      装備抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   装備抽出結果クラスワークファイル</br>
	/// <br>Programmer       :   30290</br>
	/// <br>Date             :   2008/06/04</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CEquipInfoWork
	{
		/// <summary>装備表示順位</summary>
		private Int32 _equipmentDispOrder;

		/// <summary>装備分類コード</summary>
		private Int32 _equipmentGenreCd;

		/// <summary>装備分類名称</summary>
		private string _equipmentGenreNm = "";

		/// <summary>装備コード</summary>
		private Int32 _equipmentCode;

		/// <summary>装備名称</summary>
		private string _equipmentName = "";

		/// <summary>装備略称</summary>
		private string _equipmentShortName = "";

		/// <summary>装備ICONコード</summary>
		private Int32 _equipmentIconCode;

		/// public propaty name  :  EquipmentDispOrder
		/// <summary>装備表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備表示順位プロパティ</br>
		/// </remarks>
		public Int32 EquipmentDispOrder
		{
			get { return _equipmentDispOrder; }
			set { _equipmentDispOrder = value; }
		}

		/// public propaty name  :  EquipmentGenreCd
		/// <summary>装備分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類コードプロパティ</br>
		/// </remarks>
		public Int32 EquipmentGenreCd
		{
			get { return _equipmentGenreCd; }
			set { _equipmentGenreCd = value; }
		}

		/// public propaty name  :  EquipmentGenreNm
		/// <summary>装備分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類名称プロパティ</br>
		/// </remarks>
		public string EquipmentGenreNm
		{
			get { return _equipmentGenreNm; }
			set { _equipmentGenreNm = value; }
		}

		/// public propaty name  :  EquipmentCode
		/// <summary>装備コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備コードプロパティ</br>
		/// </remarks>
		public Int32 EquipmentCode
		{
			get { return _equipmentCode; }
			set { _equipmentCode = value; }
		}

		/// public propaty name  :  EquipmentName
		/// <summary>装備名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備名称プロパティ</br>
		/// </remarks>
		public string EquipmentName
		{
			get { return _equipmentName; }
			set { _equipmentName = value; }
		}

		/// public propaty name  :  EquipmentShortName
		/// <summary>装備略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備略称プロパティ</br>
		/// </remarks>
		public string EquipmentShortName
		{
			get { return _equipmentShortName; }
			set { _equipmentShortName = value; }
		}

		/// public propaty name  :  EquipmentIconCode
		/// <summary>装備ICONコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備ICONコードプロパティ</br>
		/// </remarks>
		public Int32 EquipmentIconCode
		{
			get { return _equipmentIconCode; }
			set { _equipmentIconCode = value; }
		}


		/// <summary>
		/// 装備抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>CEqpDefDspRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CEqpDefDspRetWorkクラスの新しいインスタンスを生成します</br>
		/// </remarks>
		public CEquipInfoWork()
		{
		}

	}
}
