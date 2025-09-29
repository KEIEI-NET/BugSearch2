//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入情報ワーククラス
//                  :   PMKYO07223D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   張莉莉
// Date             :   2011.08.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   APStockInfoWork
	/// <summary>
	/// 仕入情報ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入情報ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   12/11</br>
	/// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class APStockInfoWork
	{
		/// <summary>受信した仕入データ</summary>
		private APStockSlipWork _stockSlipWork = null;

		/// <summary>受信した仕入明細データリスト</summary>
		private List<APStockDetailWork> _stockDetailWorkList = new List<APStockDetailWork>();

		/// public propaty name  :  StockSlipWork
		/// <summary>仕入データプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入データプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public APStockSlipWork StockSlipWork
		{
			get { return _stockSlipWork; }
			set { _stockSlipWork = value; }
		}

		/// public propaty name  :  StockDetailWorkList
		/// <summary>仕入明細データリストプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細データリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<APStockDetailWork> StockDetailWorkList
		{
			get { return _stockDetailWorkList; }
			set { _stockDetailWorkList = value; }
		}

	}
}
