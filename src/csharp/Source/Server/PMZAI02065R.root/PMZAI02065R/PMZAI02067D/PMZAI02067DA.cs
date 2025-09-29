using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TrustStockOrderCndtnWork
    /// <summary>
    ///                      委託在庫補充処理抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充処理抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TrustStockOrderCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>倉庫コード(開始)</summary>
        private string _st_WarehouseCode = "";

        /// <summary>倉庫コード(終了)</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>商品メーカーコード(開始)</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>商品メーカーコード(終了)</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>商品番号(開始)</summary>
        private string _st_GoodsNo = "";

        /// <summary>商品番号(終了)</summary>
        private string _ed_GoodsNo = "";

        /// <summary>補充元在庫不足時</summary>
        /// <remarks>0:未更新 1:無視して更新 2:ゼロまで更新</remarks>
        private Int32 _replenishLackStock;

        /// <summary>補充元商品無し時</summary>
        /// <remarks>0:未更新 1:無視して更新</remarks>
        private Int32 _replenishNoneGoods;


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

        /// public propaty name  :  St_WarehouseCode
        /// <summary>倉庫コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>倉庫コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
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

        /// public propaty name  :  Ed__GoodsMakerCd
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

        /// public propaty name  :  St_GoodsNo
        /// <summary>商品番号(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>商品番号(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  ReplenishLackStock
        /// <summary>補充元在庫不足時プロパティ</summary>
        /// <value>0:未更新 1:無視して更新 2:ゼロまで更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充元在庫不足時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReplenishLackStock
        {
            get { return _replenishLackStock; }
            set { _replenishLackStock = value; }
        }

        /// public propaty name  :  ReplenishNoneGoods
        /// <summary>補充元商品無し時プロパティ</summary>
        /// <value>0:未更新 1:無視して更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充元商品無し時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReplenishNoneGoods
        {
            get { return _replenishNoneGoods; }
            set { _replenishNoneGoods = value; }
        }


        /// <summary>
        /// 委託在庫補充処理抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>TrustStockOrderCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockOrderCndtnWork()
        {
        }

    }
}




