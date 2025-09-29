using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InventoryDataDspParamWork
    /// <summary>
    ///                      棚卸表示抽出条件
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸表示抽出条件ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/03/05 田建委</br>
    /// <br>                 :   Redmine#42247 印刷機能の追加</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InventoryDataDspParam
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

        /// <summary>表示区分1</summary>
        /// <remarks>0:倉庫別,1:全社計</remarks>
        private Int32 _listDiv1;

        /// <summary>表示区分2</summary>
        /// <remarks>0:全て,1:自社在庫,2:受託在庫</remarks>
        private Int32 _listDiv2;

        /// <summary>表示タイプ</summary>
        /// <remarks>0:通常,1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない,2:最大</remarks>
        private Int32 _listTypeDiv;

        //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
        /// <summary>メーカー名称</summary>
        private string _goodsMakerName = "";
        //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<


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

        /// public propaty name  :  ListDiv1
        /// <summary>表示区分プロパティ</summary>
        /// <value>0:倉庫別.,1:全社計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListDiv1
        {
            get { return _listDiv1; }
            set { _listDiv1 = value; }
        }

        /// public propaty name  :  ListDiv2
        /// <summary>表示区分プロパティ</summary>
        /// <value>0:全て,1:自社在庫,2:受託在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListDiv2
        {
            get { return _listDiv2; }
            set { _listDiv2 = value; }
        }

        /// public propaty name  :  ListTypeDiv
        /// <summary>表示タイププロパティ</summary>
        /// <value>0:倉庫別,1:全社計</value>
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

        //----- ADD 2014/03/05 田建委 Redmine#42247 ---------->>>>>
        /// public propaty name  :  GoodsMakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerName
        {
            get { return _goodsMakerName; }
            set { _goodsMakerName = value; }
        }
        //----- ADD 2014/03/05 田建委 Redmine#42247 ----------<<<<<


        /// <summary>
        /// 棚卸表示抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>InventoryDataDspParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataDspParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventoryDataDspParam()
        {
        }

        /// <summary>
        /// 出荷部品表示条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="stAddUpYearMonth">計上年月(開始)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">計上年月(終了)(YYYYMM)</param>
        /// <param name="goodsMakerName">メーカー名称</param>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public InventoryDataDspParam(string enterpriseCode, Int32 GoodsMakerCd, Int32 WarehouseDiv, string StWarehousCode, string EdWarehouseCode,
            string WarehouseCd01, string WarehouseCd02, string WarehouseCd03, string WarehouseCd04, string WarehouseCd05, string WarehouseCd06,
            //string WarehouseCd07, string WarehouseCd08, string WarehouseCd09, string WarehouseCd10, Int32 ListDiv1, Int32 ListDiv2, Int32 ListTypeDiv) // DEL 2014/03/05 田建委 Redmine#42247
             string WarehouseCd07, string WarehouseCd08, string WarehouseCd09, string WarehouseCd10, Int32 ListDiv1, Int32 ListDiv2, Int32 ListTypeDiv, string goodsMakerName) // ADD 2014/03/05 田建委 Redmine#42247
        {
            this._enterpriseCode = enterpriseCode;
            this._goodsMakerCd = GoodsMakerCd;
            this._warehouseDiv = WarehouseDiv;
            this._listDiv1 = ListDiv1;
            this._listDiv2 = ListDiv2;
            this._stWarehouseCode = StWarehouseCode;
            this._edWarehouseCode = EdWarehouseCode;
            this._warehouseCd01 = WarehouseCd01;
            this._warehouseCd02 = WarehouseCd02;
            this._warehouseCd03 = WarehouseCd03;
            this._warehouseCd04 = WarehouseCd04;
            this._warehouseCd05 = WarehouseCd05;
            this._warehouseCd06 = WarehouseCd06;
            this._warehouseCd07 = WarehouseCd07;
            this._warehouseCd08 = WarehouseCd08;
            this._warehouseCd09 = WarehouseCd09;
            this._warehouseCd10 = WarehouseCd10;
            this._goodsMakerName = goodsMakerName; // ADD 2014/03/05 田建委 Redmine#42247
        }

        /// <summary>
        /// 出荷部品表示条件クラス複製処理
        /// </summary>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmentPartsDspParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2014/03/05 田建委</br>
        /// <br>                 :   Redmine#42247 印刷機能の追加</br>
        /// </remarks>
        public InventoryDataDspParam Clone()
        {
            return new InventoryDataDspParam(this._enterpriseCode, this._goodsMakerCd, this._warehouseDiv, this._stWarehouseCode, this._edWarehouseCode,
                this._warehouseCd01, this._warehouseCd02, this._warehouseCd03, this._warehouseCd04, this._warehouseCd05, this._warehouseCd06,
                //this._warehouseCd07, this._warehouseCd08, this._warehouseCd09, this._warehouseCd10, this._listDiv1, this._listDiv2,this._listTypeDiv); // DEL 2014/03/05 田建委 Redmine#42247
                this._warehouseCd07, this._warehouseCd08, this._warehouseCd09, this._warehouseCd10, this._listDiv1, this._listDiv2, this._listTypeDiv, this._goodsMakerName); // ADD 2014/03/05 田建委 Redmine#42247
        }
    }
}