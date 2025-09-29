//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）条件クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 表示区分マスタ印刷結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタ印刷結果クラスワークヘッダファイル</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>管理番号   : 10801614-00</br>
    /// </remarks>
    public class PriceSelectSet
    {
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>得意先コード</summary> 
        private Int32 _customerCode;

        /// <summary>得意先名</summary>
        private string _customerSnm = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名</summary>
        private string _goodsMakerSnm;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>表示区分</summary>
        private Int32 _priceSelectDiv;

        /// <summary>標準価格選択設定パターン</summary>
        private Int32 _priceSelectPtn;

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerSnm
        /// <summary>メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerSnm
        {
            get { return _goodsMakerSnm; }
            set { _goodsMakerSnm = value; }
        }

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

        /// public propaty name  :  PRICESELECTDIV
        /// <summary>表示区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  PriceSelectPtn
        /// <summary>標準価格選択設定パターン</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択設定パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
        }
        /// <summary>
        /// 表示区分マスタデータクラス複製処理
        /// </summary>
        /// <returns>PriceSelectSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　       :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programmer       :   姚学剛</br>
        /// <br>Date             :   2012/06/11</br>
        /// <br>管理番号         :   10801614-00</br>
        /// </remarks>
        public PriceSelectSet Clone()
        {
            return new PriceSelectSet(this._customerCode, this._customerSnm, this._bLGroupCode, this._goodsMakerCd, this._goodsMakerSnm, this._bLGoodsCode, this._bLGoodsHalfName, this._priceSelectDiv, this._priceSelectPtn);
        }

        /// <summary>
        /// 表示区分マスタデータクラス複製処理
        /// </summary>
        /// <returns>PriceSelectSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   新しいインスタンスを生成します</br>
        /// <br>Programmer       :   姚学剛</br>
        /// <br>Date             :   2012/06/11</br>
        /// <br>管理番号         :   10801614-00</br>
        /// </remarks>
        public PriceSelectSet()
        {
        }

        /// <summary>
        /// 表示区分マスタ印刷データクラスワークコンストラクタ
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="BLGroupCode"></param>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="GoodsMakerSnm"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="BLGoodsHalfName"></param>
        /// <param name="PriceSelectDiv"></param>
        /// <param name="PriceSelectPtn"></param>
        public PriceSelectSet(Int32 CustomerCode, string CustomerSnm, Int32 BLGroupCode, Int32 GoodsMakerCd, string GoodsMakerSnm, Int32 BLGoodsCode, string BLGoodsHalfName, Int32 PriceSelectDiv, Int32 PriceSelectPtn)
        {
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._bLGroupCode = BLGroupCode;
            this._goodsMakerCd = GoodsMakerCd;
            this._goodsMakerSnm = GoodsMakerSnm;
            this._bLGoodsCode = BLGoodsCode;
            this._bLGoodsHalfName = BLGoodsHalfName;
            this._priceSelectDiv = PriceSelectDiv;
            this._priceSelectPtn = PriceSelectPtn;
        }

    }
}
