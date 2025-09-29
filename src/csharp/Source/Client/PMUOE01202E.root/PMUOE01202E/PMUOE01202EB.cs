using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEStockUpdSearch
    /// <summary>
    ///                      UOE入庫更新検索条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE入庫更新検索条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEStockUpdSearch
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>ログイン拠点コードを設定</remarks>
        private string _sectionCode = "";

        /// <summary>処理区分</summary>
        /// <remarks>0:在庫一括 1:在庫一括以外</remarks>
        private Int32 _procDiv;

        /// <summary>UOE発注先コード</summary>
        /// <remarks>画面上の仕入先コードを設定</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>伝票番号</summary>
        /// <remarks>画面上の納品書番号を設定</remarks>
        private string _slipNo = "";

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
        /// <value>ログイン拠点コードを設定</value>
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

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>0:在庫一括 1:在庫一括以外</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// <value>画面上の仕入先コードを設定</value>
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

        /// public propaty name  :  SlipNo
        /// <summary>伝票番号プロパティ</summary>
        /// <value>画面上の納品書番号を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
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
        /// UOE入庫更新検索条件クラスコンストラクタ
        /// </summary>
        /// <returns>UOEStockUpdSearchクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEStockUpdSearch()
        {
        }

        /// <summary>
        /// UOE入庫更新検索条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(ログイン拠点コードを設定)</param>
        /// <param name="procDiv">処理区分(0:在庫一括 1:在庫一括以外)</param>
        /// <param name="uOESupplierCd">UOE発注先コード(画面上の仕入先コードを設定)</param>
        /// <param name="slipNo">伝票番号(画面上の納品書番号を設定)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>UOEStockUpdSearchクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEStockUpdSearch(string enterpriseCode, string sectionCode, Int32 procDiv, Int32 uOESupplierCd, string slipNo, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._procDiv = procDiv;
            this._uOESupplierCd = uOESupplierCd;
            this._slipNo = slipNo;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE入庫更新検索条件クラス複製処理
        /// </summary>
        /// <returns>UOEStockUpdSearchクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOEStockUpdSearchクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEStockUpdSearch Clone()
        {
            return new UOEStockUpdSearch(this._enterpriseCode, this._sectionCode, this._procDiv, this._uOESupplierCd, this._slipNo, this._enterpriseName);
        }

        /// <summary>
        /// UOE入庫更新検索条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEStockUpdSearchクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOEStockUpdSearch target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.ProcDiv == target.ProcDiv)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.SlipNo == target.SlipNo)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE入庫更新検索条件クラス比較処理
        /// </summary>
        /// <param name="uOEStockUpdSearch1">
        ///                    比較するUOEStockUpdSearchクラスのインスタンス
        /// </param>
        /// <param name="uOEStockUpdSearch2">比較するUOEStockUpdSearchクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOEStockUpdSearch uOEStockUpdSearch1, UOEStockUpdSearch uOEStockUpdSearch2)
        {
            return ((uOEStockUpdSearch1.EnterpriseCode == uOEStockUpdSearch2.EnterpriseCode)
                 && (uOEStockUpdSearch1.SectionCode == uOEStockUpdSearch2.SectionCode)
                 && (uOEStockUpdSearch1.ProcDiv == uOEStockUpdSearch2.ProcDiv)
                 && (uOEStockUpdSearch1.UOESupplierCd == uOEStockUpdSearch2.UOESupplierCd)
                 && (uOEStockUpdSearch1.SlipNo == uOEStockUpdSearch2.SlipNo)
                 && (uOEStockUpdSearch1.EnterpriseName == uOEStockUpdSearch2.EnterpriseName));
        }
        /// <summary>
        /// UOE入庫更新検索条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEStockUpdSearchクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOEStockUpdSearch target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.ProcDiv != target.ProcDiv) resList.Add("ProcDiv");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.SlipNo != target.SlipNo) resList.Add("SlipNo");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE入庫更新検索条件クラス比較処理
        /// </summary>
        /// <param name="uOEStockUpdSearch1">比較するUOEStockUpdSearchクラスのインスタンス</param>
        /// <param name="uOEStockUpdSearch2">比較するUOEStockUpdSearchクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOEStockUpdSearch uOEStockUpdSearch1, UOEStockUpdSearch uOEStockUpdSearch2)
        {
            ArrayList resList = new ArrayList();
            if (uOEStockUpdSearch1.EnterpriseCode != uOEStockUpdSearch2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEStockUpdSearch1.SectionCode != uOEStockUpdSearch2.SectionCode) resList.Add("SectionCode");
            if (uOEStockUpdSearch1.ProcDiv != uOEStockUpdSearch2.ProcDiv) resList.Add("ProcDiv");
            if (uOEStockUpdSearch1.UOESupplierCd != uOEStockUpdSearch2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEStockUpdSearch1.SlipNo != uOEStockUpdSearch2.SlipNo) resList.Add("SlipNo");
            if (uOEStockUpdSearch1.EnterpriseName != uOEStockUpdSearch2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 検索条件設定クラス
    /// </summary>
    public class UOEEnterUpdCndtn
    {
        #region ■Private定数
        private string _enterpriseCode;     // 企業コード
        private Int32 _processDiv;          // 処理区分
        private Int32 _supplierCd;          // 仕入先コード
        private string _supplierName;       // 仕入先名称
        private Int32 _slipNo;              // 納品書No.
        #endregion

        #region ■Property
        /// <summary> 企業コード </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode;}
            set { this._enterpriseCode = value;}
        }
        /// <summary> 処理区分 </summary>
        public Int32 ProcessDiv
        {
            get { return this._processDiv;}
            set { this._processDiv = value;}
        }
        /// <summary> 仕入先コード </summary>
        public Int32 SupplierCd
        {
            get { return this._supplierCd;}
            set { this._supplierCd = value;}
        }
        /// <summary> 仕入先名称 </summary>
        public string SupplierName
        {
            get { return this._supplierName; }
            set { this._supplierName = value; }
        }
        /// <summary> 納品No. </summary>
        public Int32 SlipNo
        {
            get { return this._slipNo;}
            set { this._slipNo = value;}
        }
        #endregion
    }
}
*/