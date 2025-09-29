using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventoryDataDspParamWork
    /// <summary>
    ///                      棚卸表示抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸表示抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventoryDataDspParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>倉庫指定区分</summary>
        /// <remarks>0:範囲,1:単独</remarks>
        private Int32 _warehouseDiv;

        /// <summary>開始倉庫コード</summary>
        private string _stWarehouseCode = "";

        /// <summary>終了倉庫コード</summary>
        private string _edWarehouseCode = "";

        /// <summary>倉庫コード01</summary>
        private string _warehouseCd01 = "";

        /// <summary>倉庫コード02</summary>
        private string _warehouseCd02 = "";

        /// <summary>倉庫コード03</summary>
        private string _warehouseCd03 = "";

        /// <summary>倉庫コード04</summary>
        private string _warehouseCd04 = "";

        /// <summary>倉庫コード05</summary>
        private string _warehouseCd05 = "";

        /// <summary>倉庫コード06</summary>
        private string _warehouseCd06 = "";

        /// <summary>倉庫コード07</summary>
        private string _warehouseCd07 = "";

        /// <summary>倉庫コード08</summary>
        private string _warehouseCd08 = "";

        /// <summary>倉庫コード09</summary>
        private string _warehouseCd09 = "";

        /// <summary>倉庫コード10</summary>
        private string _warehouseCd10 = "";

        /// <summary>表示区分</summary>
        /// <remarks>0:全て,1:自社在庫,2:受託在庫</remarks>
        private Int32 _listDiv;

        /// <summary>表示タイプ</summary>
        /// <remarks>0:通常,1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない,2:最大</remarks>
        private Int32 _listTypeDiv;


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

        /// public propaty name  :  WarehouseDiv
        /// <summary>倉庫指定区分プロパティ</summary>
        /// <value>0:範囲,1:単独</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseDiv
        {
            get { return _warehouseDiv; }
            set { _warehouseDiv = value; }
        }

        /// public propaty name  :  StWarehouseCode
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StWarehouseCode
        {
            get { return _stWarehouseCode; }
            set { _stWarehouseCode = value; }
        }

        /// public propaty name  :  EdWarehouseCode
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdWarehouseCode
        {
            get { return _edWarehouseCode; }
            set { _edWarehouseCode = value; }
        }

        /// public propaty name  :  WarehouseCd01
        /// <summary>倉庫コード01プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード01プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd01
        {
            get { return _warehouseCd01; }
            set { _warehouseCd01 = value; }
        }

        /// public propaty name  :  WarehouseCd02
        /// <summary>倉庫コード02プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード02プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd02
        {
            get { return _warehouseCd02; }
            set { _warehouseCd02 = value; }
        }

        /// public propaty name  :  WarehouseCd03
        /// <summary>倉庫コード03プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード03プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd03
        {
            get { return _warehouseCd03; }
            set { _warehouseCd03 = value; }
        }

        /// public propaty name  :  WarehouseCd04
        /// <summary>倉庫コード04プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード04プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd04
        {
            get { return _warehouseCd04; }
            set { _warehouseCd04 = value; }
        }

        /// public propaty name  :  WarehouseCd05
        /// <summary>倉庫コード05プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード05プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd05
        {
            get { return _warehouseCd05; }
            set { _warehouseCd05 = value; }
        }

        /// public propaty name  :  WarehouseCd06
        /// <summary>倉庫コード06プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード06プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd06
        {
            get { return _warehouseCd06; }
            set { _warehouseCd06 = value; }
        }

        /// public propaty name  :  WarehouseCd07
        /// <summary>倉庫コード07プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード07プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd07
        {
            get { return _warehouseCd07; }
            set { _warehouseCd07 = value; }
        }

        /// public propaty name  :  WarehouseCd08
        /// <summary>倉庫コード08プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード08プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd08
        {
            get { return _warehouseCd08; }
            set { _warehouseCd08 = value; }
        }

        /// public propaty name  :  WarehouseCd09
        /// <summary>倉庫コード09プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード09プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd09
        {
            get { return _warehouseCd09; }
            set { _warehouseCd09 = value; }
        }

        /// public propaty name  :  WarehouseCd10
        /// <summary>倉庫コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd10
        {
            get { return _warehouseCd10; }
            set { _warehouseCd10 = value; }
        }

        /// public propaty name  :  ListDiv
        /// <summary>表示区分プロパティ</summary>
        /// <value>0:全て,1:自社在庫,2:受託在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListDiv
        {
            get { return _listDiv; }
            set { _listDiv = value; }
        }

        /// public propaty name  :  ListTypeDiv
        /// <summary>表示タイププロパティ</summary>
        /// <value>0:通常,1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない,2:最大</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListTypeDiv
        {
            get { return _listTypeDiv; }
            set { _listTypeDiv = value; }
        }


        /// <summary>
        /// 棚卸表示抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>InventoryDataDspParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataDspParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventoryDataDspParamWork()
        {
        }

	}
}
