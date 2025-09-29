//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : セットマスタ（エクスポート）
// プログラム概要   : セットマスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSetExportWork
    /// <summary>
    ///                      セットマスタ条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   セットマスタ条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsSetExportWork
    {
        # region ■ private field ■
        /// <summary>開始商品メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>開始商品番号</summary>
        private string _goodsNoSt = "";

        /// <summary>終了商品番号</summary>
        private string _goodsNoEd = "";

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        # endregion  ■ private field ■

        # region ■ public propaty ■

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// セットマスタ（エクスポート）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsSetExportWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetExportWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSetExportWork()
        {
        }
        # endregion ■ Constructor ■

    }
}
