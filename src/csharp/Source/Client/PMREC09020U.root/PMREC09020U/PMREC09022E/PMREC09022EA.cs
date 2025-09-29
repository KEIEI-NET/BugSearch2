//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : お買得商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RecBgnGdsSearchPara
    /// <summary>
    ///                      お買得商品設定マスタ抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   お買得商品設定マスタ抽出条件クラス</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/02/20</br>
    /// <br>Genarated Date   :   2015/02/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RecBgnGdsSearchPara
    {
        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>メーカー（開始）</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>メーカー（終了）</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>公開日（開始）</summary>
        private Int32 _applyDateSt;

        /// <summary>公開日（終了）</summary>
        private Int32 _applyDateEd;

        /// <summary>品番*</summary>
        private string _goodsNo = "";

        /// <summary>削除指定区分</summary>
        private Int32 _deleteFlag;

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカー（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>メーカー（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番*プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番*プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  OpenDateSt
        /// <summary>公開日（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開日（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int ApplyDateSt
        {
            get { return _applyDateSt; }
            set { _applyDateSt = value; }
        }

        /// public propaty name  :  OpenDateEd
        /// <summary>公開日（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開日（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int ApplyDateEd
        {
            get { return _applyDateEd; }
            set { _applyDateEd = value; }
        }

        /// public propaty name  :  DeleteFlag
        /// <summary>削除指定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }

        /// <summary>
        /// お買得商品設定マスタ抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>RecBgnGdsSearchParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsSearchParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGdsSearchPara()
        {
        }
    }
}
