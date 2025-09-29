//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ検索マスタ（エクスポート）
// プログラム概要   : ＴＢＯ検索マスタのｴｸｽﾎﾟｰﾄ処理を行う
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
    /// public class name:   TBOSearchExportWork
	/// <summary>
    ///                      ＴＢＯ検索マスタ（ｴｸｽﾎﾟｰﾄ）条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   ＴＢＯ検索マスタ（ｴｸｽﾎﾟｰﾄ）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class TBOSearchExportWork 
    {
        # region ■ private field ■
        /// <summary>装備分類</summary>
        private Int32 _equipGenreCodeCd;

        /// <summary>開始結合元メーカーコード</summary>
        private Int32 _joinDestMakerCdSt;

        /// <summary>終了結合元メーカーコード</summary>
        private Int32 _joinDestMakerCdEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  EquipGenreCodeSt
		/// <summary>装備分類プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 EquipGenreCodeCd
		{
            get { return _equipGenreCodeCd; }
            set { _equipGenreCodeCd = value; }
		}

        /// public propaty name  :  JoinDestMakerCdSt
        /// <summary>開始結合先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始結合先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCdSt
        {
            get { return _joinDestMakerCdSt; }
            set { _joinDestMakerCdSt = value; }
        }

        /// public propaty name  :  JoinDestMakerCdEd
        /// <summary>終了結合先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了結合先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCdEd
        {
            get { return _joinDestMakerCdEd; }
            set { _joinDestMakerCdEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 装備分類マスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>TBOSearchExportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchExportWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
