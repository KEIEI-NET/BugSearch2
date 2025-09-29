//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新抽出条件クラスワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockUpdateCndtnWork
    /// <summary>
    ///                      出品一括更新抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   出品一括更新抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Genarated Date   :   2016/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockUpdateCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>倉庫コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string[] _warehouseCodes;

        /// <summary>ログインユーザーの拠点コード</summary>
        private string _loginUserSecCode;

        /// <summary>在庫最終更新日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _lastStockUpdDate;

        /// <summary>仕入先</summary>
        private Int32 _supplierCd;

        /// <summary>BLコード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>メーカー</summary>
        private Int32 _goodsMakerCd;

        /// <summary>中分類</summary>
        private Int32 _goodsMGroup;

        /// <summary>商品掛率G</summary>
        private Int32 _rateGrpCode;

        /// <summary>価格算出日付</summary>
        private Int32 _priceStartDate;

        /// <summary>分割Size</summary>
        private Int32 _dataSize;

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

        /// public propaty name  :  SectionCodes
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>(配列)　全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] WarehouseCodes
        {
            get { return _warehouseCodes; }
            set { _warehouseCodes = value; }
        }

        /// public propaty name  :  LoginUserSecCode
        /// <summary>ログインユーザーの拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ログインユーザーの拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginUserSecCode
        {
            get { return _loginUserSecCode; }
            set { _loginUserSecCode = value; }
        }

        /// public propaty name  :  LastStockUpdDate
        /// <summary>在庫最終更新日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫最終更新日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LastStockUpdDate
        {
            get { return _lastStockUpdDate; }
            set { _lastStockUpdDate = value; }
        }

        /// public propaty name  :  StSupplierCd
        /// <summary>仕入先プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカー開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  RateGrpCode
        /// <summary>商品掛率Gプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率Gプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateGrpCode
        {
            get { return _rateGrpCode; }
            set { _rateGrpCode = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格算出日付</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格算出日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  DataSize
        /// <summary>分割Indexプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   分割Indexプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataSize
        {
            get { return _dataSize; }
            set { _dataSize = value; }
        }

        /// <summary>
        /// 出品一括更新抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>PartsMaxStockUpdateCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockUpdateCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsMaxStockUpdateCndtnWork()
        {
        }

    }
}
