using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ARCtrlPropertyDispInfo
	/// <summary>
	///                      自由帳票プロパティ表示情報
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票プロパティ表示情報ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/06/04</br>
	/// <br>Genarated Date   :   2007/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ARCtrlPropertyDispInfo
	{
		/// <summary>ActiveReportコントロールタイプ名称</summary>
		private string _aRControlTypeName = "";

		/// <summary>プロパティ名称</summary>
		private string _propertyName = "";

		/// <summary>表示フラグ</summary>
		private Int32 _canDisplay;

		/// <summary>編集区分</summary>
		private Int32 _editDivCode;

		/// <summary>表示名称</summary>
		/// <remarks>ガイド等に表示する名称</remarks>
		private string _displayName = "";

		/// <summary>ユーザー管理者フラグ</summary>
		/// <remarks>0:一般,1:ユーザー管理者</remarks>
		private Int32 _userAdminFlag;


		/// public propaty name  :  ARControlTypeName
		/// <summary>ActiveReportコントロールタイプ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ActiveReportコントロールタイプ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ARControlTypeName
		{
			get { return _aRControlTypeName; }
			set { _aRControlTypeName = value; }
		}

		/// public propaty name  :  PropertyName
		/// <summary>プロパティ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   プロパティ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// public propaty name  :  CanDisplay
		/// <summary>表示フラグプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CanDisplay
		{
			get { return _canDisplay; }
			set { _canDisplay = value; }
		}

		/// public propaty name  :  EditDivCode
		/// <summary>編集区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   編集区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EditDivCode
		{
			get { return _editDivCode; }
			set { _editDivCode = value; }
		}

		/// public propaty name  :  DisplayName
		/// <summary>表示名称プロパティ</summary>
		/// <value>ガイド等に表示する名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; }
		}

		/// public propaty name  :  UserAdminFlag
		/// <summary>ユーザー管理者フラグプロパティ</summary>
		/// <value>0:一般,1:ユーザー管理者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー管理者フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UserAdminFlag
		{
			get { return _userAdminFlag; }
			set { _userAdminFlag = value; }
		}


		/// <summary>
		/// 自由帳票プロパティ表示情報コンストラクタ
		/// </summary>
		/// <returns>ARCtrlPropertyDispInfoクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ARCtrlPropertyDispInfoクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ARCtrlPropertyDispInfo()
		{
		}

	}
}
