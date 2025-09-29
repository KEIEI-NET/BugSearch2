//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE送受信ジャーナル抽出条件クラス
// プログラム概要   : UOE送受信ジャーナル抽出条件の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SndRcvJnlSearch
	/// <summary>
	///                      UOE送受信ジャーナル抽出条件
	/// </summary>
	/// <remarks>
	/// <br>note             :   UOE送受信ジャーナル抽出条件ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/06/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SndRcvJnlSearch
	{
		/// <summary>UOE発注先コード</summary>
		/// <remarks>0:全て</remarks>
		private Int32 _uOESupplierCd;

		/// <summary>発注回答番号</summary>
		/// <remarks>0:全て</remarks>
		private Int32 _uOESalesOrderNo;

		/// <summary>発注回答行番号</summary>
		/// <remarks>0:全て</remarks>
		private Int32 _uOESalesOrderRowNo;


		/// public propaty name  :  UOESupplierCd
		/// <summary>UOE発注先コードプロパティ</summary>
		/// <value>0:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UOESupplierCd
		{
			get { return _uOESupplierCd; }
			set { _uOESupplierCd = value; }
		}

		/// public propaty name  :  UOESalesOrderNo
		/// <summary>発注回答番号プロパティ</summary>
		/// <value>0:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注回答番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UOESalesOrderNo
		{
			get { return _uOESalesOrderNo; }
			set { _uOESalesOrderNo = value; }
		}

		/// public propaty name  :  UOESalesOrderRowNo
		/// <summary>発注回答行番号プロパティ</summary>
		/// <value>0:全て</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注回答行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UOESalesOrderRowNo
		{
			get { return _uOESalesOrderRowNo; }
			set { _uOESalesOrderRowNo = value; }
		}


		/// <summary>
		/// UOE送受信ジャーナル抽出条件コンストラクタ
		/// </summary>
		/// <returns>SndRcvJnlSearchクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SndRcvJnlSearchクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SndRcvJnlSearch()
		{
		}

		/// <summary>
		/// UOE送受信ジャーナル抽出条件コンストラクタ
		/// </summary>
		/// <param name="uOESupplierCd">UOE発注先コード(0:全て)</param>
		/// <param name="uOESalesOrderNo">発注回答番号(0:全て)</param>
		/// <param name="uOESalesOrderRowNo">発注回答行番号(0:全て)</param>
		/// <returns>SndRcvJnlSearchクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SndRcvJnlSearchクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SndRcvJnlSearch(Int32 uOESupplierCd, Int32 uOESalesOrderNo, Int32 uOESalesOrderRowNo)
		{
			this._uOESupplierCd = uOESupplierCd;
			this._uOESalesOrderNo = uOESalesOrderNo;
			this._uOESalesOrderRowNo = uOESalesOrderRowNo;

		}

		/// <summary>
		/// UOE送受信ジャーナル抽出条件複製処理
		/// </summary>
		/// <returns>SndRcvJnlSearchクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSndRcvJnlSearchクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SndRcvJnlSearch Clone()
		{
			return new SndRcvJnlSearch(this._uOESupplierCd, this._uOESalesOrderNo, this._uOESalesOrderRowNo);
		}

		/// <summary>
		/// UOE送受信ジャーナル抽出条件比較処理
		/// </summary>
		/// <param name="target">比較対象のSndRcvJnlSearchクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SndRcvJnlSearchクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SndRcvJnlSearch target)
		{
			return ((this.UOESupplierCd == target.UOESupplierCd)
				 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
				 && (this.UOESalesOrderRowNo == target.UOESalesOrderRowNo));
		}

		/// <summary>
		/// UOE送受信ジャーナル抽出条件比較処理
		/// </summary>
		/// <param name="sndRcvJnlSearch1">
		///                    比較するSndRcvJnlSearchクラスのインスタンス
		/// </param>
		/// <param name="sndRcvJnlSearch2">比較するSndRcvJnlSearchクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SndRcvJnlSearchクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SndRcvJnlSearch sndRcvJnlSearch1, SndRcvJnlSearch sndRcvJnlSearch2)
		{
			return ((sndRcvJnlSearch1.UOESupplierCd == sndRcvJnlSearch2.UOESupplierCd)
				 && (sndRcvJnlSearch1.UOESalesOrderNo == sndRcvJnlSearch2.UOESalesOrderNo)
				 && (sndRcvJnlSearch1.UOESalesOrderRowNo == sndRcvJnlSearch2.UOESalesOrderRowNo));
		}
		/// <summary>
		/// UOE送受信ジャーナル抽出条件比較処理
		/// </summary>
		/// <param name="target">比較対象のSndRcvJnlSearchクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SndRcvJnlSearchクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SndRcvJnlSearch target)
		{
			ArrayList resList = new ArrayList();
			if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
			if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
			if (this.UOESalesOrderRowNo != target.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");

			return resList;
		}

		/// <summary>
		/// UOE送受信ジャーナル抽出条件比較処理
		/// </summary>
		/// <param name="sndRcvJnlSearch1">比較するSndRcvJnlSearchクラスのインスタンス</param>
		/// <param name="sndRcvJnlSearch2">比較するSndRcvJnlSearchクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SndRcvJnlSearchクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SndRcvJnlSearch sndRcvJnlSearch1, SndRcvJnlSearch sndRcvJnlSearch2)
		{
			ArrayList resList = new ArrayList();
			if (sndRcvJnlSearch1.UOESupplierCd != sndRcvJnlSearch2.UOESupplierCd) resList.Add("UOESupplierCd");
			if (sndRcvJnlSearch1.UOESalesOrderNo != sndRcvJnlSearch2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
			if (sndRcvJnlSearch1.UOESalesOrderRowNo != sndRcvJnlSearch2.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");

			return resList;
		}
	}
}
