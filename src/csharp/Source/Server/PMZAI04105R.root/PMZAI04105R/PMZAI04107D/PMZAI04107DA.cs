using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryDspSearchParamWork
    /// <summary>
    ///                      在庫実績照会抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫実績照会抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryDspSearchParamWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>BLコード</summary>
        private Int32 _blGoodsCode;
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>開始年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _stAddUpYearMonth;

        /// <summary>終了年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edAddUpYearMonth;

        /// <summary>開始年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stAddUpADate;

        /// <summary>終了年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _edAddUpADate;

        /// <summary>拠点コード</summary>
        private string[] _sectionCodes;

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>倉庫コードリスト</summary>
        private List<string> _warehouseCodeList = new List<string>();

        /// <summary>棚番リスト</summary>
        private List<string> _warehouseShelfNoList = new List<string>();

        /// <summary>メーカーコードリスト</summary>
        private List<Int32> _makerCodeList = new List<Int32>();

        /// <summary>BLコードリスト</summary>
        private List<Int32> _blGoodsCodeList = new List<Int32>();

        /// <summary>品番リスト</summary>
        private List<string> _goodsNoList = new List<string>();
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<


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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// public propaty name  :  WarehouseShelfNo
        /// <summary>棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  BlGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  StAddUpYearMonth
        /// <summary>開始年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StAddUpYearMonth
        {
            get { return _stAddUpYearMonth; }
            set { _stAddUpYearMonth = value; }
        }

        /// public propaty name  :  EdAddUpYearMonth
        /// <summary>終了年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdAddUpYearMonth
        {
            get { return _edAddUpYearMonth; }
            set { _edAddUpYearMonth = value; }
        }

        /// public propaty name  :  StAddUpADate
        /// <summary>開始年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StAddUpADate
        {
            get { return _stAddUpADate; }
            set { _stAddUpADate = value; }
        }

        /// public propaty name  :  EdAddUpADate
        /// <summary>終了年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdAddUpADate
        {
            get { return _edAddUpADate; }
            set { _edAddUpADate = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// public propaty name  :  WarehouseCodeList
        /// <summary>倉庫コードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> WarehouseCodeList
        {
            get { return _warehouseCodeList; }
            set { _warehouseCodeList = value; }
        }

        /// public propaty name  :  WarehouseShelfNoList
        /// <summary>棚番リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> WarehouseShelfNoList
        {
            get { return _warehouseShelfNoList; }
            set { _warehouseShelfNoList = value; }
        }

        /// public propaty name  :  MakerCodeList
        /// <summary>メーカーコードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> MakerCodeList
        {
            get { return _makerCodeList; }
            set { _makerCodeList = value; }
        }

        /// public propaty name  :  BlGoodsCodeList
        /// <summary>BLコードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> BlGoodsCodeList
        {
            get { return _blGoodsCodeList; }
            set { _blGoodsCodeList = value; }
        }

        /// public propaty name  :  GoodsNoList
        /// <summary>品番コードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> GoodsNoList
        {
            get { return _goodsNoList; }
            set { _goodsNoList = value; }
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        /// <summary>
        /// 在庫実績照会抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>StockHistoryDspSearchParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockHistoryDspSearchParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryDspSearchParamWork()
        {
        }

    }
}
