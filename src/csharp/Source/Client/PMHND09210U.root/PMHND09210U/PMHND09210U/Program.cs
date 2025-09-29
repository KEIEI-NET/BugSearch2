//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   商品バーコード一括登録用起動クラス              //
//                  :   PMHND09210U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms　　　                   //
// Programmer       :   3H 張小磊                                       //
// Date             :   2017/06/12                                      //
//----------------------------------------------------------------------//
//                 Copyright(c)2017 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード一括登録 起動クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品バーコード一括登録 起動クラス</br>
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new PMHND09210UA());
		}
	}
}