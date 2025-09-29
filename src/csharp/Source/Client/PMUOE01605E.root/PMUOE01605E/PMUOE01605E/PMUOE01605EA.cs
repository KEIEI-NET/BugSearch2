using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SlipNoAlwcData
    /// <summary>
    ///                      伝票番号引当条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   伝票番号引当条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2009/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/19  杉村</br>
    /// <br>                 :   ○区分変更</br>
    /// <br>                 :   1:売上単価　2:売上原価　3:仕入単価 4:定価 5:作業原価 6:作業売価</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価</br>
    /// </remarks>
    public class SlipNoAlwcData
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>UOE発注先コード</summary>
        private Int32 _supplierCode;

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>回答保存フォルダ</summary>
        private string _answerSaveFolder = "";

        /// <summary>担当者コード</summary>
        private string _employeeCode = "";

        /// <summary>担当者名称</summary>
        private string _employeeName = "";

        /// <summary>原価更新</summary>
        private Int32 _priceUpdateCode;

        /// <summary>仕入データ作成区分</summary>
        private Int32 _stockDataCode;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  AnswerSaveFolder
        /// <summary>回答保存フォルダプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答保存フォルダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerSaveFolder
        {
            get { return _answerSaveFolder; }
            set { _answerSaveFolder = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  PriceUpdateCode
        /// <summary>原価更新プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価更新プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceUpdateCode
        {
            get { return _priceUpdateCode; }
            set { _priceUpdateCode = value; }
        }

        /// public propaty name  :  StockDataCode
        /// <summary>仕入データ作成区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入データ作成区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDataCode
        {
            get { return _stockDataCode; }
            set { _stockDataCode = value; }
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


        /// <summary>
        /// 伝票番号引当条件クラスコンストラクタ
        /// </summary>
        /// <returns>SlipNoAlwcDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipNoAlwcDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipNoAlwcData()
        {
        }

        /// <summary>
        /// 伝票番号引当条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCode">発注先コード</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESupplierName">UOE発注先名称</param>
        /// <param name="answerSaveFolder">回答保存フォルダ</param>
        /// <param name="employeeCode">担当者コード</param>
        /// <param name="employeeName">担当者名称</param>
        /// <param name="priceUpdateCode">原価更新</param>
        /// <param name="stockDataCode">仕入データ作成区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>SlipNoAlwcDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipNoAlwcDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipNoAlwcData(string enterpriseCode, string sectionCode,Int32 supplierCode, Int32 uOESupplierCd, string uOESupplierName, string answerSaveFolder, string employeeCode, string employeeName, Int32 priceUpdateCode, Int32 stockDataCode, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCode = supplierCode;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._answerSaveFolder = answerSaveFolder;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._priceUpdateCode = priceUpdateCode;
            this._stockDataCode = stockDataCode;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 伝票番号引当条件クラス複製処理
        /// </summary>
        /// <returns>SlipNoAlwcDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSlipNoAlwcDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipNoAlwcData Clone()
        {
            return new SlipNoAlwcData(this._enterpriseCode, this._sectionCode, this._supplierCode, this._uOESupplierCd, this._uOESupplierName, this._answerSaveFolder, this._employeeCode, this._employeeName, this._priceUpdateCode, this._stockDataCode, this._enterpriseName);
        }

        /// <summary>
        /// 伝票番号引当条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSlipNoAlwcDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipNoAlwcDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SlipNoAlwcData target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCode == target.SupplierCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.AnswerSaveFolder == target.AnswerSaveFolder)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.PriceUpdateCode == target.PriceUpdateCode)
                 && (this.StockDataCode == target.StockDataCode)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 伝票番号引当条件クラス比較処理
        /// </summary>
        /// <param name="slipNoAlwcData1">
        ///                    比較するSlipNoAlwcDataクラスのインスタンス
        /// </param>
        /// <param name="slipNoAlwcData2">比較するSlipNoAlwcDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipNoAlwcDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SlipNoAlwcData slipNoAlwcData1, SlipNoAlwcData slipNoAlwcData2)
        {
            return ((slipNoAlwcData1.EnterpriseCode == slipNoAlwcData2.EnterpriseCode)
                 && (slipNoAlwcData1.SectionCode == slipNoAlwcData2.SectionCode)
                 && (slipNoAlwcData1.SupplierCode == slipNoAlwcData2.SupplierCode)
                 && (slipNoAlwcData1.UOESupplierCd == slipNoAlwcData2.UOESupplierCd)
                 && (slipNoAlwcData1.UOESupplierName == slipNoAlwcData2.UOESupplierName)
                 && (slipNoAlwcData1.AnswerSaveFolder == slipNoAlwcData2.AnswerSaveFolder)
                 && (slipNoAlwcData1.EmployeeCode == slipNoAlwcData2.EmployeeCode)
                 && (slipNoAlwcData1.EmployeeName == slipNoAlwcData2.EmployeeName)
                 && (slipNoAlwcData1.PriceUpdateCode == slipNoAlwcData2.PriceUpdateCode)
                 && (slipNoAlwcData1.StockDataCode == slipNoAlwcData2.StockDataCode)
                 && (slipNoAlwcData1.EnterpriseName == slipNoAlwcData2.EnterpriseName));
        }
        /// <summary>
        /// 伝票番号引当条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のSlipNoAlwcDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipNoAlwcDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SlipNoAlwcData target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCode != target.SupplierCode) resList.Add("SupplierCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.AnswerSaveFolder != target.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.PriceUpdateCode != target.PriceUpdateCode) resList.Add("PriceUpdateCode");
            if (this.StockDataCode != target.StockDataCode) resList.Add("StockDataCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 伝票番号引当条件クラス比較処理
        /// </summary>
        /// <param name="slipNoAlwcData1">比較するSlipNoAlwcDataクラスのインスタンス</param>
        /// <param name="slipNoAlwcData2">比較するSlipNoAlwcDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipNoAlwcDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SlipNoAlwcData slipNoAlwcData1, SlipNoAlwcData slipNoAlwcData2)
        {
            ArrayList resList = new ArrayList();
            if (slipNoAlwcData1.EnterpriseCode != slipNoAlwcData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (slipNoAlwcData1.SectionCode != slipNoAlwcData2.SectionCode) resList.Add("SectionCode");
            if (slipNoAlwcData1.SupplierCode != slipNoAlwcData2.SupplierCode) resList.Add("SupplierCode");
            if (slipNoAlwcData1.UOESupplierCd != slipNoAlwcData2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (slipNoAlwcData1.UOESupplierName != slipNoAlwcData2.UOESupplierName) resList.Add("UOESupplierName");
            if (slipNoAlwcData1.AnswerSaveFolder != slipNoAlwcData2.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (slipNoAlwcData1.EmployeeCode != slipNoAlwcData2.EmployeeCode) resList.Add("EmployeeCode");
            if (slipNoAlwcData1.EmployeeName != slipNoAlwcData2.EmployeeName) resList.Add("EmployeeName");
            if (slipNoAlwcData1.PriceUpdateCode != slipNoAlwcData2.PriceUpdateCode) resList.Add("PriceUpdateCode");
            if (slipNoAlwcData1.StockDataCode != slipNoAlwcData2.StockDataCode) resList.Add("StockDataCode");
            if (slipNoAlwcData1.EnterpriseName != slipNoAlwcData2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}