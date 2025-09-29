//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 結合マスタ（エクスポート）
// プログラム概要   : 結合マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   JoinPartsExpWork
    /// <summary>
    ///                      結合マスタ（エクスポート）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合マスタ（エクスポート）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class JoinPartsExpWork
    {
        # region ■ private field ■
        /// <summary>開始結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCodeSt;

        /// <summary>終了結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCodeEd;

        /// <summary>開始結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithHSt = "";

        /// <summary>終了結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithHEd = "";

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  JoinSourceMakerCodeSt
        /// <summary>開始結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeSt
        {
            get { return _joinSourceMakerCodeSt; }
            set { _joinSourceMakerCodeSt = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeEd
        /// <summary>終了結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeEd
        {
            get { return _joinSourceMakerCodeEd; }
            set { _joinSourceMakerCodeEd = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHSt
        /// <summary>開始結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithHSt
        {
            get { return _joinSourPartsNoWithHSt; }
            set { _joinSourPartsNoWithHSt = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHEd
        /// <summary>終了結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithHEd
        {
            get { return _joinSourPartsNoWithHEd; }
            set { _joinSourPartsNoWithHEd = value; }
        }

        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 結合（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>JoinPartsExpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsExpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsExpWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
