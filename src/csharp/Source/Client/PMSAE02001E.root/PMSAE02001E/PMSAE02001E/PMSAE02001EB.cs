//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス商品コード変換マスタ（印刷） データクラス
// プログラム概要   : オートバックス商品コード変換マスタ（印刷） データクラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ABGoodsCdChgSet
    /// <summary>
    ///                      AB商品コードﾞ変換マスタ（印刷）結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   AB商品コードﾞ変換マスタ（印刷）結果クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ABGoodsCdChgSet
    {
        # region ■ private field ■
        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>AB商品コード</summary>
        private string _aBGoodsCode = "";
        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  ABGoodsCode
        /// <summary>AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ABGoodsCode
        {
            get { return _aBGoodsCode; }
            set { _aBGoodsCode = value; }
        }
        # endregion ■ public propaty ■

        /// <summary>
        /// AB商品コード（印刷）データクラス複製処理
        /// </summary>
        /// <returns>ABGoodsCdChgSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいABGoodsCdChgSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ABGoodsCdChgSet Clone()
        {
            return new ABGoodsCdChgSet(this._bLGoodsCode, this._bLGoodsHalfName, this._aBGoodsCode);

        }

        # region ■ Constructor ■
        /// <summary>
        /// AB商品コードﾞ変換マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>ABGoodsCdChgPrintクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ABGoodsCdChgPrintクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ABGoodsCdChgSet()
        {
        }

        /// <summary>
        /// BLコード（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="BLGoodsCode"></param>
        /// <param name="BLGoodsHalfName"></param>
        /// <param name="ABGoodsCode"></param>
        public ABGoodsCdChgSet(Int32 BLGoodsCode, string BLGoodsHalfName, string ABGoodsCode)
        {
            this._bLGoodsCode = BLGoodsCode;
            this._bLGoodsHalfName = BLGoodsHalfName;
            this._aBGoodsCode = ABGoodsCode;
        }
        # endregion ■ Constructor ■
    }
}