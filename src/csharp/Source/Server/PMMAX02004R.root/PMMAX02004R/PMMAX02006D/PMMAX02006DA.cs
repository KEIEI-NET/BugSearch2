//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品MAX入荷予約
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11270001-00  作成担当 : 陳艶丹
// 作 成 日  2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockArrivalCondt
    /// <summary>
    ///                      部品MAX入荷予約抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品MAX入荷予約抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/01/21</br>
    /// <br>Genarated Date   :   2016/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockArrivalCondt
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>出庫拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>入庫拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>出庫拠点名称</summary>
        private string _bfSectionName = "";

        /// <summary>入庫拠点名称</summary>
        private string _afSectionName = "";

        /// <summary>出荷日付(開始)</summary>
        private DateTime _shipDateSt;

        /// <summary>出荷日付(終了)</summary>
        private DateTime _shipDateEd;

        /// <summary>出庫倉庫コードリスト</summary>
        private string[] _bfWarehouseCodeList;

        /// <summary>入庫倉庫コードリスト</summary>
        private string[] _afWarehouseCodeList;

        /// <summary>発注数</summary>
        private Int32 _salesOrderCount;

        /// <summary>売価率下限値</summary>
        private Int32 _salesRate;

        /// <summary>販売単価下限値</summary>
        private Int64 _salesPrice;

        /// <summary>チェックリスト出力選択</summary>
        private Int32 _moveChecked;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>分割Size</summary>
        private Int32 _dataSize;


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

        /// public propaty name  :  BfSectionCode
        /// <summary>出庫拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>入庫拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  BfSectionName
        /// <summary>出庫拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionName
        {
            get { return _bfSectionName; }
            set { _bfSectionName = value; }
        }

        /// public propaty name  :  AfSectionName
        /// <summary>入庫拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionName
        {
            get { return _afSectionName; }
            set { _afSectionName = value; }
        }

        /// public propaty name  :  ShipDateSt
        /// <summary>出荷日付(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipDateSt
        {
            get { return _shipDateSt; }
            set { _shipDateSt = value; }
        }

        /// public propaty name  :  ShipDateEd
        /// <summary>出荷日付(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipDateEd
        {
            get { return _shipDateEd; }
            set { _shipDateEd = value; }
        }

        /// public propaty name  :  BfWarehouseCodeList
        /// <summary>出庫倉庫コードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出庫倉庫コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] BfWarehouseCodeList
        {
            get { return _bfWarehouseCodeList; }
            set { _bfWarehouseCodeList = value; }
        }

        /// public propaty name  :  AfWarehouseCodeList
        /// <summary>入庫倉庫コードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫倉庫コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] AfWarehouseCodeList
        {
            get { return _afWarehouseCodeList; }
            set { _afWarehouseCodeList = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>発注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>売価率下限値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率下限値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  SalesPrice
        /// <summary>販売単価下限値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売単価下限値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        /// public propaty name  :  MoveChecked
        /// <summary>チェックリスト出力選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェックリスト出力選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveChecked
        {
            get { return _moveChecked; }
            set { _moveChecked = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
        /// 部品MAX出荷予定抽出条件コンストラクタ
        /// </summary>
        /// <returns>PartsMaxStockArrivalCondtクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsMaxStockArrivalCondtクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsMaxStockArrivalCondt()
        {
        }
    }
}