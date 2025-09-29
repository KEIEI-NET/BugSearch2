//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコードファイルクラスワーク
// プログラム概要   : 商品バーコードファイルデータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsBarCodeRevnFileWork
    /// <summary>
    ///                      商品バーコードファイルクラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品バーコードファイルクラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2017/06/12  (CSharp File Generated Date)</br>
    /// </remarks>
    public class GoodsBarCodeRevnFileWork
    {
        /// <summary>商品メーカーコード</summary>
        private string _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品バーコード</summary>
        private string _goodsBarCode;

        /// <summary>商品バーコード種別</summary>
        private string _goodsBarCodeKind;

        /// <summary>エラーメッセージ</summary>
        private string _errMessage;


        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsBarCode
        /// <summary>商品バーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品バーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
        }

        /// public propaty name  :  GoodsBarCodeKind
        /// <summary>商品バーコード種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品バーコード種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsBarCodeKind
        {
            get { return _goodsBarCodeKind; }
            set { _goodsBarCodeKind = value; }
        }

        /// public propaty name  :  ErrMessage
        /// <summary>エラーメッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrMessage
        {
            get { return _errMessage; }
            set { _errMessage = value; }
        }

        /// <summary>
        /// 商品バーコードエラーログクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsBarCodeRevnFileWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeRevnFileWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsBarCodeRevnFileWork()
        {
        }
    }
}
