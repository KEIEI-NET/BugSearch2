using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockQuoteData
    /// <summary>
    ///                      掛率マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/8  杉村</br>
    /// <br>                 :   出荷可能数の補足修正</br>
    /// </remarks>
    public class StockQuoteData
    {
        /// <summary>引用先拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>引用先拠点コード名称</summary>
        private string _bfSectionName = "";

        /// <summary>引用先得意先掛率グループコード</summary>
        private Int32 _bfCustRateGrpCode;

        /// <summary>引用先得意先掛率グループ名称</summary>
        private string _bfCustRateGrpName = "";

        /// <summary>引用先得意先コード</summary>
        private Int32 _bfCustomerCode;

        /// <summary>引用先得意先名称</summary>
        private string _bfCustomerName = "";

        /// <summary>引用元拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>引用元拠点コード名称</summary>
        private string _afSectionName = "";

        /// <summary>引用元得意先掛率グループコード</summary>
        private Int32 _afCustRateGrpCode;

        /// <summary>引用元得意先掛率グループ名称</summary>
        private string _afCustRateGrpName = "";

        /// <summary>引用元得意先コード</summary>
        private Int32 _afCustomerCode;

        /// <summary>引用元得意先名称</summary>
        private string _afCustomerName = "";

        /// <summary>対象区分</summary>
        private Int32 _updateDistinctionCode;

        /// <summary>更新区分</summary>
        private Int32 _objectDistinctionCode;

        /// <summary>読込件数</summary>
        private Int32 _readCount;

        /// <summary>処理件数</summary>
        private Int32 _processCount;


        /// public propaty name  :  BfSectionCode
        /// <summary>引用先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionName
        /// <summary>引用先拠点コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用先拠点コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionName
        {
            get { return _bfSectionName; }
            set { _bfSectionName = value; }
        }

        /// public propaty name  :  BfCustRateGrpCode
        /// <summary>引用先得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用先得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BfCustRateGrpCode
        {
            get { return _bfCustRateGrpCode; }
            set { _bfCustRateGrpCode = value; }
        }

        /// public propaty name  :  BfCustRateGrpName
        /// <summary>引用先得意先掛率グループ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用先得意先掛率グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfCustRateGrpName
        {
            get { return _bfCustRateGrpName; }
            set { _bfCustRateGrpName = value; }
        }

        /// public propaty name  :  BfCustomerCode
        /// <summary>引用先得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用先得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BfCustomerCode
        {
            get { return _bfCustomerCode; }
            set { _bfCustomerCode = value; }
        }

        /// public propaty name  :  BfCustomerName
        /// <summary>引用先得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用先得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfCustomerName
        {
            get { return _bfCustomerName; }
            set { _bfCustomerName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>引用元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionName
        /// <summary>引用元拠点コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用元拠点コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionName
        {
            get { return _afSectionName; }
            set { _afSectionName = value; }
        }

        /// public propaty name  :  AfCustRateGrpCode
        /// <summary>引用元得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用元得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AfCustRateGrpCode
        {
            get { return _afCustRateGrpCode; }
            set { _afCustRateGrpCode = value; }
        }

        /// public propaty name  :  AfCustRateGrpName
        /// <summary>引用元得意先掛率グループ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用元得意先掛率グループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfCustRateGrpName
        {
            get { return _afCustRateGrpName; }
            set { _afCustRateGrpName = value; }
        }

        /// public propaty name  :  AfCustomerCode
        /// <summary>引用元得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用元得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AfCustomerCode
        {
            get { return _afCustomerCode; }
            set { _afCustomerCode = value; }
        }

        /// public propaty name  :  AfCustomerName
        /// <summary>引用元得意先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引用元得意先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfCustomerName
        {
            get { return _afCustomerName; }
            set { _afCustomerName = value; }
        }

        /// public propaty name  :  UpdateDistinctionCode
        /// <summary>対象区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDistinctionCode
        {
            get { return _updateDistinctionCode; }
            set { _updateDistinctionCode = value; }
        }

        /// public propaty name  :  ObjectDistinctionCode
        /// <summary>更新区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ObjectDistinctionCode
        {
            get { return _objectDistinctionCode; }
            set { _objectDistinctionCode = value; }
        }

        /// public propaty name  :  ReadCount
        /// <summary>読込件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   読込件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReadCount
        {
            get { return _readCount; }
            set { _readCount = value; }
        }

        /// public propaty name  :  ProcessCount
        /// <summary>処理件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcessCount
        {
            get { return _processCount; }
            set { _processCount = value; }
        }


        /// <summary>
        /// 掛率マスタコンストラクタ
        /// </summary>
        /// <returns>StockQuoteDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockQuoteDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockQuoteData()
        {
        }

        /// <summary>
        /// 掛率マスタコンストラクタ
        /// </summary>
        /// <param name="bfSectionCode">引用先拠点コード</param>
        /// <param name="bfSectionName">引用先拠点コード名称</param>
        /// <param name="bfCustRateGrpCode">引用先得意先掛率グループコード</param>
        /// <param name="bfCustRateGrpName">引用先得意先掛率グループ名称</param>
        /// <param name="bfCustomerCode">引用先得意先コード</param>
        /// <param name="bfCustomerName">引用先得意先名称</param>
        /// <param name="afSectionCode">引用元拠点コード</param>
        /// <param name="afSectionName">引用元拠点コード名称</param>
        /// <param name="afCustRateGrpCode">引用元得意先掛率グループコード</param>
        /// <param name="afCustRateGrpName">引用元得意先掛率グループ名称</param>
        /// <param name="afCustomerCode">引用元得意先コード</param>
        /// <param name="afCustomerName">引用元得意先名称</param>
        /// <param name="updateDistinctionCode">対象区分</param>
        /// <param name="objectDistinctionCode">更新区分</param>
        /// <param name="readCount">読込件数</param>
        /// <param name="processCount">処理件数</param>
        /// <returns>StockQuoteDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockQuoteDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockQuoteData(string bfSectionCode, string bfSectionName, Int32 bfCustRateGrpCode, string bfCustRateGrpName, Int32 bfCustomerCode, string bfCustomerName, string afSectionCode, string afSectionName, Int32 afCustRateGrpCode, string afCustRateGrpName, Int32 afCustomerCode, string afCustomerName, Int32 updateDistinctionCode, Int32 objectDistinctionCode, Int32 readCount, Int32 processCount)
        {
            this._bfSectionCode = bfSectionCode;
            this._bfSectionName = bfSectionName;
            this._bfCustRateGrpCode = bfCustRateGrpCode;
            this._bfCustRateGrpName = bfCustRateGrpName;
            this._bfCustomerCode = bfCustomerCode;
            this._bfCustomerName = bfCustomerName;
            this._afSectionCode = afSectionCode;
            this._afSectionName = afSectionName;
            this._afCustRateGrpCode = afCustRateGrpCode;
            this._afCustRateGrpName = afCustRateGrpName;
            this._afCustomerCode = afCustomerCode;
            this._afCustomerName = afCustomerName;
            this._updateDistinctionCode = updateDistinctionCode;
            this._objectDistinctionCode = objectDistinctionCode;
            this._readCount = readCount;
            this._processCount = processCount;

        }

        /// <summary>
        /// 掛率マスタ複製処理
        /// </summary>
        /// <returns>StockQuoteDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockQuoteDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockQuoteData Clone()
        {
            return new StockQuoteData(this._bfSectionCode, this._bfSectionName, this._bfCustRateGrpCode, this._bfCustRateGrpName, this._bfCustomerCode, this._bfCustomerName, this._afSectionCode, this._afSectionName, this._afCustRateGrpCode, this._afCustRateGrpName, this._afCustomerCode, this._afCustomerName, this._updateDistinctionCode, this._objectDistinctionCode, this._readCount, this._processCount);
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockQuoteDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockQuoteDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockQuoteData target)
        {
            return ((this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionName == target.BfSectionName)
                 && (this.BfCustRateGrpCode == target.BfCustRateGrpCode)
                 && (this.BfCustRateGrpName == target.BfCustRateGrpName)
                 && (this.BfCustomerCode == target.BfCustomerCode)
                 && (this.BfCustomerName == target.BfCustomerName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionName == target.AfSectionName)
                 && (this.AfCustRateGrpCode == target.AfCustRateGrpCode)
                 && (this.AfCustRateGrpName == target.AfCustRateGrpName)
                 && (this.AfCustomerCode == target.AfCustomerCode)
                 && (this.AfCustomerName == target.AfCustomerName)
                 && (this.UpdateDistinctionCode == target.UpdateDistinctionCode)
                 && (this.ObjectDistinctionCode == target.ObjectDistinctionCode)
                 && (this.ReadCount == target.ReadCount)
                 && (this.ProcessCount == target.ProcessCount));
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="stockQuoteData1">
        ///                    比較するStockQuoteDataクラスのインスタンス
        /// </param>
        /// <param name="stockQuoteData2">比較するStockQuoteDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockQuoteDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockQuoteData stockQuoteData1, StockQuoteData stockQuoteData2)
        {
            return ((stockQuoteData1.BfSectionCode == stockQuoteData2.BfSectionCode)
                 && (stockQuoteData1.BfSectionName == stockQuoteData2.BfSectionName)
                 && (stockQuoteData1.BfCustRateGrpCode == stockQuoteData2.BfCustRateGrpCode)
                 && (stockQuoteData1.BfCustRateGrpName == stockQuoteData2.BfCustRateGrpName)
                 && (stockQuoteData1.BfCustomerCode == stockQuoteData2.BfCustomerCode)
                 && (stockQuoteData1.BfCustomerName == stockQuoteData2.BfCustomerName)
                 && (stockQuoteData1.AfSectionCode == stockQuoteData2.AfSectionCode)
                 && (stockQuoteData1.AfSectionName == stockQuoteData2.AfSectionName)
                 && (stockQuoteData1.AfCustRateGrpCode == stockQuoteData2.AfCustRateGrpCode)
                 && (stockQuoteData1.AfCustRateGrpName == stockQuoteData2.AfCustRateGrpName)
                 && (stockQuoteData1.AfCustomerCode == stockQuoteData2.AfCustomerCode)
                 && (stockQuoteData1.AfCustomerName == stockQuoteData2.AfCustomerName)
                 && (stockQuoteData1.UpdateDistinctionCode == stockQuoteData2.UpdateDistinctionCode)
                 && (stockQuoteData1.ObjectDistinctionCode == stockQuoteData2.ObjectDistinctionCode)
                 && (stockQuoteData1.ReadCount == stockQuoteData2.ReadCount)
                 && (stockQuoteData1.ProcessCount == stockQuoteData2.ProcessCount));
        }
        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockQuoteDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockQuoteDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockQuoteData target)
        {
            ArrayList resList = new ArrayList();
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionName != target.BfSectionName) resList.Add("BfSectionName");
            if (this.BfCustRateGrpCode != target.BfCustRateGrpCode) resList.Add("BfCustRateGrpCode");
            if (this.BfCustRateGrpName != target.BfCustRateGrpName) resList.Add("BfCustRateGrpName");
            if (this.BfCustomerCode != target.BfCustomerCode) resList.Add("BfCustomerCode");
            if (this.BfCustomerName != target.BfCustomerName) resList.Add("BfCustomerName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionName != target.AfSectionName) resList.Add("AfSectionName");
            if (this.AfCustRateGrpCode != target.AfCustRateGrpCode) resList.Add("AfCustRateGrpCode");
            if (this.AfCustRateGrpName != target.AfCustRateGrpName) resList.Add("AfCustRateGrpName");
            if (this.AfCustomerCode != target.AfCustomerCode) resList.Add("AfCustomerCode");
            if (this.AfCustomerName != target.AfCustomerName) resList.Add("AfCustomerName");
            if (this.UpdateDistinctionCode != target.UpdateDistinctionCode) resList.Add("UpdateDistinctionCode");
            if (this.ObjectDistinctionCode != target.ObjectDistinctionCode) resList.Add("ObjectDistinctionCode");
            if (this.ReadCount != target.ReadCount) resList.Add("ReadCount");
            if (this.ProcessCount != target.ProcessCount) resList.Add("ProcessCount");

            return resList;
        }

        /// <summary>
        /// 掛率マスタ比較処理
        /// </summary>
        /// <param name="stockQuoteData1">比較するStockQuoteDataクラスのインスタンス</param>
        /// <param name="stockQuoteData2">比較するStockQuoteDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockQuoteDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockQuoteData stockQuoteData1, StockQuoteData stockQuoteData2)
        {
            ArrayList resList = new ArrayList();
            if (stockQuoteData1.BfSectionCode != stockQuoteData2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockQuoteData1.BfSectionName != stockQuoteData2.BfSectionName) resList.Add("BfSectionName");
            if (stockQuoteData1.BfCustRateGrpCode != stockQuoteData2.BfCustRateGrpCode) resList.Add("BfCustRateGrpCode");
            if (stockQuoteData1.BfCustRateGrpName != stockQuoteData2.BfCustRateGrpName) resList.Add("BfCustRateGrpName");
            if (stockQuoteData1.BfCustomerCode != stockQuoteData2.BfCustomerCode) resList.Add("BfCustomerCode");
            if (stockQuoteData1.BfCustomerName != stockQuoteData2.BfCustomerName) resList.Add("BfCustomerName");
            if (stockQuoteData1.AfSectionCode != stockQuoteData2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockQuoteData1.AfSectionName != stockQuoteData2.AfSectionName) resList.Add("AfSectionName");
            if (stockQuoteData1.AfCustRateGrpCode != stockQuoteData2.AfCustRateGrpCode) resList.Add("AfCustRateGrpCode");
            if (stockQuoteData1.AfCustRateGrpName != stockQuoteData2.AfCustRateGrpName) resList.Add("AfCustRateGrpName");
            if (stockQuoteData1.AfCustomerCode != stockQuoteData2.AfCustomerCode) resList.Add("AfCustomerCode");
            if (stockQuoteData1.AfCustomerName != stockQuoteData2.AfCustomerName) resList.Add("AfCustomerName");
            if (stockQuoteData1.UpdateDistinctionCode != stockQuoteData2.UpdateDistinctionCode) resList.Add("UpdateDistinctionCode");
            if (stockQuoteData1.ObjectDistinctionCode != stockQuoteData2.ObjectDistinctionCode) resList.Add("ObjectDistinctionCode");
            if (stockQuoteData1.ReadCount != stockQuoteData2.ReadCount) resList.Add("ReadCount");
            if (stockQuoteData1.ProcessCount != stockQuoteData2.ProcessCount) resList.Add("ProcessCount");

            return resList;
        }
    }
}
