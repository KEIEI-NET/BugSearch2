//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー品番パターン検索履歴データ条件ワーク
// プログラム概要   : メーカー品番パターン検索履歴条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyMakerGoodsPtrnHisCondWork
    /// <summary>
    ///                      メーカー品番パターン検索履歴条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   メーカー品番パターン検索履歴条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyMakerGoodsPtrnHisCondWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>検索日付開始</summary>
        private Int32 _searchDateSt;

        /// <summary>検索日付終了</summary>
        private Int32 _searchDateEd;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>バーコードデータ</summary>
        private string _barCodeData = "";


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SearchDateSt
        /// <summary>検索日付開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索日付開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDateSt
        {
            get { return _searchDateSt; }
            set { _searchDateSt = value; }
        }

        /// public propaty name  :  SearchDateEd
        /// <summary>検索日付終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索日付終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDateEd
        {
            get { return _searchDateEd; }
            set { _searchDateEd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  BarCodeData
        /// <summary>バーコードデータプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バーコードデータプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BarCodeData
        {
            get { return _barCodeData; }
            set { _barCodeData = value; }
        }


        /// <summary>
        /// メーカー品番パターン検索履歴条件ワークコンストラクタ
        /// </summary>
        /// <returns>HandyMakerGoodsPtrnHisCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyMakerGoodsPtrnHisCondWork()
        {
        }

    }
}
