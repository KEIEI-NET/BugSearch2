using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MngOfMacroSign
	/// <summary>
	///                      自由帳票マクロ文字管理クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票マクロ文字管理クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/11/16</br>
	/// <br>Genarated Date   :   2007/11/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class MngOfMacroSign
	{
		/// <summary>マクロ文字</summary>
		private string _macroSign = "";

		/// <summary>DataField情報</summary>
		private string _infoOfDataField = "";

		/// <summary>Tagの情報</summary>
		private string _infoOfTag = "";


		/// public propaty name  :  MacroSign
		/// <summary>マクロ文字プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   マクロ文字プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MacroSign
		{
			get{return _macroSign;}
			set{_macroSign = value;}
		}

		/// public propaty name  :  InfoOfDataField
		/// <summary>DataField情報プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DataField情報プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InfoOfDataField
		{
			get{return _infoOfDataField;}
			set{_infoOfDataField = value;}
		}

		/// public propaty name  :  InfoOfTag
		/// <summary>Tagの情報プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   Tagの情報プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InfoOfTag
		{
			get{return _infoOfTag;}
			set{_infoOfTag = value;}
		}


		/// <summary>
		/// 自由帳票マクロ文字管理クラスコンストラクタ
		/// </summary>
		/// <returns>MngOfMacroSignクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MngOfMacroSignクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MngOfMacroSign()
		{
		}

		/// <summary>
		/// 自由帳票マクロ文字管理クラスコンストラクタ
		/// </summary>
		/// <param name="macroSign">マクロ文字</param>
		/// <param name="infoOfDataField">DataField情報</param>
		/// <param name="infoOfTag">Tagの情報</param>
		/// <returns>MngOfMacroSignクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MngOfMacroSignクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MngOfMacroSign(string macroSign,string infoOfDataField,string infoOfTag)
		{
			this._macroSign = macroSign;
			this._infoOfDataField = infoOfDataField;
			this._infoOfTag = infoOfTag;

		}

		/// <summary>
		/// 自由帳票マクロ文字管理クラス複製処理
		/// </summary>
		/// <returns>MngOfMacroSignクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいMngOfMacroSignクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MngOfMacroSign Clone()
		{
			return new MngOfMacroSign(this._macroSign,this._infoOfDataField,this._infoOfTag);
		}

		/// <summary>
		/// 自由帳票マクロ文字管理クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のMngOfMacroSignクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MngOfMacroSignクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(MngOfMacroSign target)
		{
			return ((this.MacroSign == target.MacroSign)
				 && (this.InfoOfDataField == target.InfoOfDataField)
				 && (this.InfoOfTag == target.InfoOfTag));
		}

		/// <summary>
		/// 自由帳票マクロ文字管理クラス比較処理
		/// </summary>
		/// <param name="mngOfMacroSign1">
		///                    比較するMngOfMacroSignクラスのインスタンス
		/// </param>
		/// <param name="mngOfMacroSign2">比較するMngOfMacroSignクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MngOfMacroSignクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(MngOfMacroSign mngOfMacroSign1, MngOfMacroSign mngOfMacroSign2)
		{
			return ((mngOfMacroSign1.MacroSign == mngOfMacroSign2.MacroSign)
				 && (mngOfMacroSign1.InfoOfDataField == mngOfMacroSign2.InfoOfDataField)
				 && (mngOfMacroSign1.InfoOfTag == mngOfMacroSign2.InfoOfTag));
		}
		/// <summary>
		/// 自由帳票マクロ文字管理クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のMngOfMacroSignクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MngOfMacroSignクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(MngOfMacroSign target)
		{
			ArrayList resList = new ArrayList();
			if(this.MacroSign != target.MacroSign)resList.Add("MacroSign");
			if(this.InfoOfDataField != target.InfoOfDataField)resList.Add("InfoOfDataField");
			if(this.InfoOfTag != target.InfoOfTag)resList.Add("InfoOfTag");

			return resList;
		}

		/// <summary>
		/// 自由帳票マクロ文字管理クラス比較処理
		/// </summary>
		/// <param name="mngOfMacroSign1">比較するMngOfMacroSignクラスのインスタンス</param>
		/// <param name="mngOfMacroSign2">比較するMngOfMacroSignクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MngOfMacroSignクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(MngOfMacroSign mngOfMacroSign1, MngOfMacroSign mngOfMacroSign2)
		{
			ArrayList resList = new ArrayList();
			if(mngOfMacroSign1.MacroSign != mngOfMacroSign2.MacroSign)resList.Add("MacroSign");
			if(mngOfMacroSign1.InfoOfDataField != mngOfMacroSign2.InfoOfDataField)resList.Add("InfoOfDataField");
			if(mngOfMacroSign1.InfoOfTag != mngOfMacroSign2.InfoOfTag)resList.Add("InfoOfTag");

			return resList;
		}
	}
}
