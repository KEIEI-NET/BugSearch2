using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockCheckDtl
    /// <summary>
    ///                      仕入チェックデータ（明細）
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入チェックデータ（明細）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/9/19</br>
    /// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockCheckDtl
    {
        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>仕入チェック区分（締次）</summary>
        /// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
        private Int32 _stockCheckDivCAddUp;

        /// <summary>仕入チェック区分（日次）</summary>
        /// <remarks>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</remarks>
        private Int32 _stockCheckDivDaily;

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  StockCheckDivCAddUp
        /// <summary>仕入チェック区分（締次）プロパティ</summary>
        /// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入チェック区分（締次）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCheckDivCAddUp
        {
            get { return _stockCheckDivCAddUp; }
            set { _stockCheckDivCAddUp = value; }
        }

        /// public propaty name  :  StockCheckDivDaily
        /// <summary>仕入チェック区分（日次）プロパティ</summary>
        /// <value>0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入チェック区分（日次）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCheckDivDaily
        {
            get { return _stockCheckDivDaily; }
            set { _stockCheckDivDaily = value; }
        }


        /// <summary>
        /// 仕入チェックデータ（明細）コンストラクタ
        /// </summary>
        /// <returns>StockCheckDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCheckDtl()
        {
        }

        /// <summary>
        /// 仕入チェックデータ（明細）コンストラクタ
        /// </summary>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="supplierFormal">仕入形式(0:仕入　（受注ステータス）)</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <param name="stockCheckDivCAddUp">仕入チェック区分（締次）(0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）)</param>
        /// <param name="stockCheckDivDaily">仕入チェック区分（日次）(0:未ﾁｪｯｸ,1:ﾁｪｯｸ済　（明細データと仕入先伝票明細の比較）)</param>
        /// <returns>StockCheckDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCheckDtl(Int32 logicalDeleteCode, Int32 supplierFormal, Int64 stockSlipDtlNum, Int32 stockCheckDivCAddUp, Int32 stockCheckDivDaily)
        {
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierFormal = supplierFormal;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._stockCheckDivCAddUp = stockCheckDivCAddUp;
            this._stockCheckDivDaily = stockCheckDivDaily;
        }

        /// <summary>
        /// 仕入チェックデータ（明細）複製処理
        /// </summary>
        /// <returns>StockCheckDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockCheckDtlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCheckDtl Clone()
        {
            return new StockCheckDtl(this._logicalDeleteCode, this._supplierFormal, this._stockSlipDtlNum, this._stockCheckDivCAddUp, this._stockCheckDivDaily);
        }

        /// <summary>
        /// 仕入チェックデータ（明細）比較処理
        /// </summary>
        /// <param name="target">比較対象のStockCheckDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockCheckDtl target)
        {
            return ((this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.StockCheckDivCAddUp == target.StockCheckDivCAddUp)
                 && (this.StockCheckDivDaily == target.StockCheckDivDaily));
        }

        /// <summary>
        /// 仕入チェックデータ（明細）比較処理
        /// </summary>
        /// <param name="stockCheckDtl1">
        ///                    比較するStockCheckDtlクラスのインスタンス
        /// </param>
        /// <param name="stockCheckDtl2">比較するStockCheckDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockCheckDtl stockCheckDtl1, StockCheckDtl stockCheckDtl2)
        {
            return ((stockCheckDtl1.LogicalDeleteCode == stockCheckDtl2.LogicalDeleteCode)
                 && (stockCheckDtl1.SupplierFormal == stockCheckDtl2.SupplierFormal)
                 && (stockCheckDtl1.StockSlipDtlNum == stockCheckDtl2.StockSlipDtlNum)
                 && (stockCheckDtl1.StockCheckDivCAddUp == stockCheckDtl2.StockCheckDivCAddUp)
                 && (stockCheckDtl1.StockCheckDivDaily == stockCheckDtl2.StockCheckDivDaily));
        }
        /// <summary>
        /// 仕入チェックデータ（明細）比較処理
        /// </summary>
        /// <param name="target">比較対象のStockCheckDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockCheckDtl target)
        {
            ArrayList resList = new ArrayList();
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.StockCheckDivCAddUp != target.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (this.StockCheckDivDaily != target.StockCheckDivDaily) resList.Add("StockCheckDivDaily");

            return resList;
        }

        /// <summary>
        /// 仕入チェックデータ（明細）比較処理
        /// </summary>
        /// <param name="stockCheckDtl1">比較するStockCheckDtlクラスのインスタンス</param>
        /// <param name="stockCheckDtl2">比較するStockCheckDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockCheckDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockCheckDtl stockCheckDtl1, StockCheckDtl stockCheckDtl2)
        {
            ArrayList resList = new ArrayList();
            if (stockCheckDtl1.LogicalDeleteCode != stockCheckDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockCheckDtl1.SupplierFormal != stockCheckDtl2.SupplierFormal) resList.Add("SupplierFormal");
            if (stockCheckDtl1.StockSlipDtlNum != stockCheckDtl2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (stockCheckDtl1.StockCheckDivCAddUp != stockCheckDtl2.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (stockCheckDtl1.StockCheckDivDaily != stockCheckDtl2.StockCheckDivDaily) resList.Add("StockCheckDivDaily");

            return resList;
        }
    }
}
