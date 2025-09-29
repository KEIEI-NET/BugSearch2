//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＢＬコードマスタ（エクスポート）
// プログラム概要   : ＢＬコードマスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGoodsCdExportWork
	/// <summary>
    ///                      BLコードマスタ（ｴｸｽﾎﾟｰﾄ）条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   BLコードマスタ（ｴｸｽﾎﾟｰﾄ）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class BLGoodsCdExportWork 
    {
        # region ■ private field ■
        /// <summary>開始BLコード</summary>
		private Int32 _bLGoodsCodeSt;

		/// <summary>終了BLコード</summary>
		private Int32 _bLGoodsCodeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  BLGoodsCodeSt
		/// <summary>開始BLコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BLコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeSt
		{
			get{return _bLGoodsCodeSt;}
			set{_bLGoodsCodeSt = value;}
		}

		/// public propaty name  :  BLGoodsCodeEd
		/// <summary>終了BLコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BLコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeEd
		{
			get{return _bLGoodsCodeEd;}
			set{_bLGoodsCodeEd = value;}
		}
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// BLコードマスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>BLGoodsCdPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
