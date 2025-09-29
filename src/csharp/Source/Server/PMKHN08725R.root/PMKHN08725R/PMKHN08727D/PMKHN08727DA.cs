//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）データパラメータ 
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

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceSelectSetCndtnWork
    /// <summary>
    ///                      表示区分マスタ（印刷）検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   表示区分マスタ（印刷）検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceSelectSetCndtnWork
    {
        # region ■ private field

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>標準価格選択設定パターン</summary>
        private Int32 _priceSelectPtn;

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _st_bLGoodsCode;

        /// <summary>終了BL商品コード</summary>
        private Int32 _ed_bLGoodsCode;

        /// <summary>開始得意先コード</summary>
        private Int32 _st_customerCode;

        /// <summary>終了得意先コード</summary>
        private Int32 _ed_customerCode;

        /// <summary>開始得意先掛率グループコード</summary>
        private string _st_bLGroupCode;

        /// <summary>終了得意先掛率グループコード</summary>
        private string _ed_bLGroupCode;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _deleteDateTimeEd;

        # endregion  ■ private field

        # region ■ public propaty
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

        /// public propaty name  :  PriceSelectPtn
        /// <summary>標準価格選択設定パターンプロパティ</summary>
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

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>商品メーカーコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>商品メーカーコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_BLGoodsCodeSt
        /// <summary>BL商品コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_bLGoodsCode; }
            set { _st_bLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCodeSt
        /// <summary>BL商品コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_bLGoodsCode; }
            set { _ed_bLGoodsCode = value; }
        }

        /// public propaty name  :  St_CustomerCodeSt
        /// <summary>得意先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_customerCode; }
            set { _st_customerCode = value; }
        }

        /// public propaty name  :  St_CustomerCodeSt
        /// <summary>得意先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_customerCode; }
            set { _ed_customerCode = value; }
        }

        /// public propaty name  :  St_BLGroupCodeSt
        /// <summary>得意先掛率グループコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_BLGroupCode
        {
            get { return _st_bLGroupCode; }
            set { _st_bLGroupCode = value; }
        }

        /// public propaty name  :  St_BLGroupCodeSt
        /// <summary>得意先掛率グループコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_BLGroupCode
        {
            get { return _ed_bLGroupCode; }
            set { _ed_bLGroupCode = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除指定区分プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>開始削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>終了削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }

        # endregion ■ public propaty

        # region ■ Constructor
        /// <summary>
        /// 表示区分マスタ抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>PriceSelectSetCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceSelectSetCndtnWork()
        {
        }
        # endregion ■ Constructor
    }
}
