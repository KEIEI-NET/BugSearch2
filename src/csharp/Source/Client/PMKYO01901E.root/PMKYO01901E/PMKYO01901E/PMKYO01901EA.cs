//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : エラー詳細データクラス
// プログラム概要   : エラー詳細表示処理を行い
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宋剛
// 作 成 日  2011/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PMKYO01901EA
    /// <summary>
    ///                      エラー詳細
    /// </summary>
    /// <remarks>
    /// <br>note             :   エラー詳細ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PMKYO01901EA
    {
        ///<summary>テーブル名称</summary>
        public const string Tbl_ErrorInfoTable = "ERRORINFO";

        /// <summary>伝票区分</summary>
        private string _noFlg = "";

        /// <summary>伝票番号</summary>
        private string _no = "";

        /// <summary>日付</summary>
        private string _date = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名</summary>
        private string _sectionNm = "";

        /// <summary>得意先コード</summary>
        private string _customerCode;

        /// <summary>得意先(仕入先)名</summary>
        private string _customerNm = "";

        /// <summary>エラー内容</summary>
        private string _error = "";


        /// public propaty name  :  NoFlg
        /// <summary>伝票区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NoFlg
        {
            get { return _noFlg; }
            set { _noFlg = value; }
        }

        /// public propaty name  :  No
        /// <summary>伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string No
        {
            get { return _no; }
            set { _no = value; }
        }

        /// public propaty name  :  Date
        /// <summary>日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Date
        {
            get { return _date; }
            set { _date = value; }
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

        /// public propaty name  :  SectionNm
        /// <summary>拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionNm
        {
            get { return _sectionNm; }
            set { _sectionNm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerNm
        /// <summary>得意先(仕入先)名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先(仕入先)名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerNm
        {
            get { return _customerNm; }
            set { _customerNm = value; }
        }

        /// public propaty name  :  Error
        /// <summary>エラー内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }


        /// <summary>
        /// エラー詳細コンストラクタ
        /// </summary>
        /// <returns>PMKYO01901EAクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMKYO01901EAクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PMKYO01901EA()
        {
        }

        /// <summary>
        /// エラー詳細コンストラクタ
        /// </summary>
        /// <param name="noFlg">伝票区分</param>
        /// <param name="no">伝票番号</param>
        /// <param name="date">日付</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionNm">拠点名</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerNm">得意先(仕入先)名</param>
        /// <param name="error">エラー内容</param>
        /// <returns>PMKYO01901EAクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMKYO01901EAクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PMKYO01901EA(string noFlg, string no, string date, string sectionCode, string sectionNm, string customerCode, string customerNm, string error)
        {
            this._noFlg = noFlg;
            this._no = no;
            this._date = date;
            this._sectionCode = sectionCode;
            this._sectionNm = sectionNm;
            this._customerCode = customerCode;
            this._customerNm = customerNm;
            this._error = error;

        }

        /// <summary>
        /// エラー詳細複製処理
        /// </summary>
        /// <returns>PMKYO01901EAクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPMKYO01901EAクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PMKYO01901EA Clone()
        {
            return new PMKYO01901EA(this._noFlg, this._no, this._date, this._sectionCode, this._sectionNm, this._customerCode, this._customerNm, this._error);
        }

        /// <summary>
        /// エラー詳細比較処理
        /// </summary>
        /// <param name="target">比較対象のPMKYO01901EAクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMKYO01901EAクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PMKYO01901EA target)
        {
            return ((this.NoFlg == target.NoFlg)
                 && (this.No == target.No)
                 && (this.Date == target.Date)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionNm == target.SectionNm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerNm == target.CustomerNm)
                 && (this.Error == target.Error));
        }

        /// <summary>
        /// エラー詳細比較処理
        /// </summary>
        /// <param name="pMKYO01901EA1">
        ///                    比較するPMKYO01901EAクラスのインスタンス
        /// </param>
        /// <param name="pMKYO01901EA2">比較するPMKYO01901EAクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMKYO01901EAクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PMKYO01901EA pMKYO01901EA1, PMKYO01901EA pMKYO01901EA2)
        {
            return ((pMKYO01901EA1.NoFlg == pMKYO01901EA2.NoFlg)
                 && (pMKYO01901EA1.No == pMKYO01901EA2.No)
                 && (pMKYO01901EA1.Date == pMKYO01901EA2.Date)
                 && (pMKYO01901EA1.SectionCode == pMKYO01901EA2.SectionCode)
                 && (pMKYO01901EA1.SectionNm == pMKYO01901EA2.SectionNm)
                 && (pMKYO01901EA1.CustomerCode == pMKYO01901EA2.CustomerCode)
                 && (pMKYO01901EA1.CustomerNm == pMKYO01901EA2.CustomerNm)
                 && (pMKYO01901EA1.Error == pMKYO01901EA2.Error));
        }
        /// <summary>
        /// エラー詳細比較処理
        /// </summary>
        /// <param name="target">比較対象のPMKYO01901EAクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMKYO01901EAクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PMKYO01901EA target)
        {
            ArrayList resList = new ArrayList();
            if (this.NoFlg != target.NoFlg) resList.Add("NoFlg");
            if (this.No != target.No) resList.Add("No");
            if (this.Date != target.Date) resList.Add("Date");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionNm != target.SectionNm) resList.Add("SectionNm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerNm != target.CustomerNm) resList.Add("CustomerNm");
            if (this.Error != target.Error) resList.Add("Error");

            return resList;
        }

        /// <summary>
        /// エラー詳細比較処理
        /// </summary>
        /// <param name="pMKYO01901EA1">比較するPMKYO01901EAクラスのインスタンス</param>
        /// <param name="pMKYO01901EA2">比較するPMKYO01901EAクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PMKYO01901EAクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PMKYO01901EA pMKYO01901EA1, PMKYO01901EA pMKYO01901EA2)
        {
            ArrayList resList = new ArrayList();
            if (pMKYO01901EA1.NoFlg != pMKYO01901EA2.NoFlg) resList.Add("NoFlg");
            if (pMKYO01901EA1.No != pMKYO01901EA2.No) resList.Add("No");
            if (pMKYO01901EA1.Date != pMKYO01901EA2.Date) resList.Add("Date");
            if (pMKYO01901EA1.SectionCode != pMKYO01901EA2.SectionCode) resList.Add("SectionCode");
            if (pMKYO01901EA1.SectionNm != pMKYO01901EA2.SectionNm) resList.Add("SectionNm");
            if (pMKYO01901EA1.CustomerCode != pMKYO01901EA2.CustomerCode) resList.Add("CustomerCode");
            if (pMKYO01901EA1.CustomerNm != pMKYO01901EA2.CustomerNm) resList.Add("CustomerNm");
            if (pMKYO01901EA1.Error != pMKYO01901EA2.Error) resList.Add("Error");

            return resList;
        }
    }
}
