//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLグループマスタ（エクスポート）
// プログラム概要   : BLグループマスタのｴｸｽﾎﾟｰﾄ処理を行う
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
    /// public class name:   BLGroupExportWork
    /// <summary>
    ///                      グループコードマスタ（エクスポート)条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   グループコードマスタ（エクスポート)条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class BLGroupExportWork
    {
        # region ■ private field ■
        /// <summary>開始ＢＬグループコード</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>終了ＢＬグループコード</summary>
        private Int32 _bLGroupCodeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  BLGroupCodeSt
        /// <summary>開始ＢＬグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ＢＬグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>終了ＢＬグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ＢＬグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// ＢＬグループマスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>BLGroupPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGroupExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
