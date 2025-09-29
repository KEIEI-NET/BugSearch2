//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカーマスタ（エクスポート）（エクスポート）
// プログラム概要   : メーカーマスタ（エクスポート）のｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MakerExportWork
	/// <summary>
    ///                      メーカーマスタ（エクスポート）（ｴｸｽﾎﾟｰﾄ）条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   メーカーマスタ（エクスポート）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class MakerExportWork 
    {
        # region ■ private field ■
        /// <summary>開始メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>開始メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>終了メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// メーカーマスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>MakerPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MakerExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MakerExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
