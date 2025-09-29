using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MTtlSalesSlip
    /// <summary>
    ///                      DSPログデータ照会データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   DSPログデータ照会データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/11/17</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class DspRogDataResult
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>日付</summary>
        /// <remarks>YYYY/MM/DD HH:MM:SS</remarks>
        private DateTime _date;

        /// <summary>端末番号</summary>
        private string _terminalNo;

        /// <summary>発注先</summary>
        private Int32　_uOESupplierCd;

        /// <summary>区分</summary>
        private Int32 _dspDiv;

        /// <summary>プログラムID</summary>
        private string _dspPGID;

        /// <summary>ステータス</summary>
        private Int32 _dspStatus;

        /// <summary>メッセージ</summary>
        private string _dspMessage;



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

        /// public propaty name  :  Date
        /// <summary>表示タイププロパティ</summary>
        /// <value>YYYY/MM/DD HH:MM:SS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// public propaty name  :  TerminalNo
        /// <summary>端末番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TerminalNo
        {
            get { return _terminalNo; }
            set { _terminalNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>発注先プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  DspDiv
        /// <summary>区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DspDiv
        {
            get { return _dspDiv; }
            set { _dspDiv = value; }
        }

        /// public propaty name  :  DspPGID
        /// <summary>プログラムIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プログラムIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DspPGID
        {
            get { return _dspPGID; }
            set { _dspPGID = value; }
        }

        /// public propaty name  :  DspStatus
        /// <summary>ステータスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DspStatus
        {
            get { return _dspStatus; }
            set { _dspStatus = value; }
        }

        /// public propaty name  :  DspMessage
        /// <summary>メッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DspMessage
        {
            get { return _dspMessage; }
            set { _dspMessage = value; }
        }

        /// <summary>
        /// 操作履歴ログデータコンストラクタ
        /// </summary>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DspRogDataResult()
        {
        }

        /// <summary>
        /// DSPログデータ照会データコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="rsltTtlDivCd">実績集計区分(0:部品合計 1:在庫 2:純正 3:作業)</param>
        /// <param name="salesTimes">売上回数(出荷回数(売上時のみ）)</param>
        /// <param name="salesMoney">売上金額(税抜き（値引,返品含まず）)</param>
        /// <param name="grossProfit">粗利金額</param>
        /// <returns>ShipmentPartsDspResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DspRogDataResult(string enterpriseCode, DateTime date, string terminalNo, Int32 uOESupplierCd, Int32 dspDiv, string dspPGID, Int32 dspStatus, string dspMessage)
        {
            this._enterpriseCode = enterpriseCode;
            this._date = date;
            this._terminalNo = terminalNo;
            this._uOESupplierCd = uOESupplierCd;
            this._dspDiv = dspDiv;
            this._dspPGID = dspPGID;
            this._dspStatus = dspStatus;
            this._dspMessage = dspMessage;
        }

        /// <summary>
        /// データ複製処理
        /// </summary>
        /// <returns>DspRogDataResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいDspRogDataResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DspRogDataResult Clone()
        {
            return new DspRogDataResult(this._enterpriseCode, this._date, this._terminalNo, this._uOESupplierCd, this._dspDiv, this._dspPGID, this._dspStatus, this._dspMessage);
        }

        /// <summary>
        ///DSPログデータ照会データ比較処理
        /// </summary>
        /// <param name="target">比較対象のInventoryDataDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventoryDataDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(DspRogDataResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.Date == target.Date)
                 && (this.TerminalNo == target.TerminalNo)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.DspDiv == target.DspDiv)
                 && (this.DspPGID == target.DspPGID)
                 && (this.DspStatus == target.DspStatus)
                 && (this.DspMessage == target.DspMessage));
        }

        /// <summary>
        /// 在庫マスタ(棚卸表示)データ比較処理
        /// </summary>
        /// <param name="ShipmentPartsDspResult">
        ///                    比較するShipmentPartsDspResultクラスのインスタンス
        /// </param>
        /// <param name="mTtlSalesSlip2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(DspRogDataResult inventoryData1, DspRogDataResult inventoryData2)
        {
            return ((inventoryData1.EnterpriseCode == inventoryData2.EnterpriseCode)
                 && (inventoryData1.Date == inventoryData2.Date)
                 && (inventoryData1.TerminalNo == inventoryData2.TerminalNo)
                 && (inventoryData1.UOESupplierCd == inventoryData2.UOESupplierCd)
                 && (inventoryData1.DspDiv == inventoryData2.DspDiv)
                 && (inventoryData1.DspPGID == inventoryData2.DspPGID)
                 && (inventoryData1.DspStatus == inventoryData2.DspStatus)
                 && (inventoryData1.DspMessage == inventoryData2.DspMessage));
        }
        /// <summary>
        /// DSPログデータ照会データ比較処理
        /// </summary>
        /// <param name="target">比較対象のShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(DspRogDataResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.Date != target.Date) resList.Add("Date");
            if (this.TerminalNo != target.TerminalNo) resList.Add("TerminalNo");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.DspDiv != target.DspDiv) resList.Add("DspDiv");
            if (this.DspPGID != target.DspPGID) resList.Add("DspPGID");
            if (this.DspStatus != target.DspStatus) resList.Add("DspStatus");
            if (this.DspMessage != target.DspMessage) resList.Add("DspMessage");
            return resList;
        }

        /// <summary>
        /// 操作履歴ログデータ比較処理
        /// </summary>
        /// <param name="shipmentPartsDspResult1">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <param name="shipmentPartsDspResult2">比較するShipmentPartsDspResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSalesSlipクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(DspRogDataResult InventoryDataDsp1, DspRogDataResult InventoryDataDsp2)
        {
            ArrayList resList = new ArrayList();
            if (InventoryDataDsp1.EnterpriseCode != InventoryDataDsp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (InventoryDataDsp1.Date != InventoryDataDsp2.Date) resList.Add("Date");
            if (InventoryDataDsp1.TerminalNo != InventoryDataDsp2.TerminalNo) resList.Add("TerminalNo");
            if (InventoryDataDsp1.UOESupplierCd != InventoryDataDsp2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (InventoryDataDsp1.DspDiv != InventoryDataDsp2.DspDiv) resList.Add("DspDiv");
            if (InventoryDataDsp1.DspPGID != InventoryDataDsp2.DspPGID) resList.Add("DspPGID");
            if (InventoryDataDsp1.DspStatus != InventoryDataDsp2.DspStatus) resList.Add("DspStatus");
            if (InventoryDataDsp1.DspMessage != InventoryDataDsp2.DspMessage) resList.Add("DspMessage");

            return resList;
        }
    }
}
