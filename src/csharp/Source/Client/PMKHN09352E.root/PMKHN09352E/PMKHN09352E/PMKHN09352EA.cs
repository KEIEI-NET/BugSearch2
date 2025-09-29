//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerCustomerChangeParam
    /// <summary>
    ///                      得意先一括修正抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先一括修正抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomerCustomerChangeParam
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>開始管理拠点コード</summary>
        private string _stMngSectionCode = "";

        /// <summary>終了管理拠点コード</summary>
        private string _edMngSectionCode = "";

        /// <summary>開始得意先</summary>
        private Int32 _stCustomerCode;

        /// <summary>終了得意先</summary>
        private Int32 _edCustomerCode;

        /// <summary>開始カナ</summary>
        private string _stKana = "";

        /// <summary>終了カナ</summary>
        private string _edKana = "";

        /// <summary>開始顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _stCustomerAgentCd = "";

        /// <summary>終了顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _edCustomerAgentCd = "";

        /// <summary>開始販売エリアコード</summary>
        private Int32 _stSalesAreaCode;

        /// <summary>終了販売エリアコード</summary>
        private Int32 _edSalesAreaCode;

        /// <summary>開始業種コード</summary>
        private Int32 _stBusinessTypeCode;

        /// <summary>終了業種コード</summary>
        private Int32 _edBusinessTypeCode;

        /// <summary>検索区分</summary>
        /// <remarks>0:得意先マスタ＋変動情報　1得意先マスタ+変動情報+掛率G</remarks>
        private Int32 _searchDiv;

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

        /// public propaty name  :  StMngSectionCode
        /// <summary>開始管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StMngSectionCode
        {
            get { return _stMngSectionCode; }
            set { _stMngSectionCode = value; }
        }

        /// public propaty name  :  EdMngSectionCode
        /// <summary>終了管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdMngSectionCode
        {
            get { return _edMngSectionCode; }
            set { _edMngSectionCode = value; }
        }

        /// public propaty name  :  StCustomerCode
        /// <summary>開始得意先プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StCustomerCode
        {
            get { return _stCustomerCode; }
            set { _stCustomerCode = value; }
        }

        /// public propaty name  :  EdCustomerCode
        /// <summary>終了得意先プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdCustomerCode
        {
            get { return _edCustomerCode; }
            set { _edCustomerCode = value; }
        }

        /// public propaty name  :  StKana
        /// <summary>開始カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StKana
        {
            get { return _stKana; }
            set { _stKana = value; }
        }

        /// public propaty name  :  EdKana
        /// <summary>終了カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdKana
        {
            get { return _edKana; }
            set { _edKana = value; }
        }

        /// public propaty name  :  StCustomerAgentCd
        /// <summary>開始顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StCustomerAgentCd
        {
            get { return _stCustomerAgentCd; }
            set { _stCustomerAgentCd = value; }
        }

        /// public propaty name  :  EdCustomerAgentCd
        /// <summary>終了顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdCustomerAgentCd
        {
            get { return _edCustomerAgentCd; }
            set { _edCustomerAgentCd = value; }
        }

        /// public propaty name  :  StSalesAreaCode
        /// <summary>開始販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StSalesAreaCode
        {
            get { return _stSalesAreaCode; }
            set { _stSalesAreaCode = value; }
        }

        /// public propaty name  :  EdSalesAreaCode
        /// <summary>終了販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdSalesAreaCode
        {
            get { return _edSalesAreaCode; }
            set { _edSalesAreaCode = value; }
        }

        /// public propaty name  :  StBusinessTypeCode
        /// <summary>開始業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StBusinessTypeCode
        {
            get { return _stBusinessTypeCode; }
            set { _stBusinessTypeCode = value; }
        }

        /// public propaty name  :  EdBusinessTypeCode
        /// <summary>終了業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdBusinessTypeCode
        {
            get { return _edBusinessTypeCode; }
            set { _edBusinessTypeCode = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// <value>0:得意先マスタ＋変動情報　1得意先マスタ+変動情報+掛率G</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
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
        /// 得意先一括修正抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustomerCustomerChangeParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeParam()
        {
        }

        /// <summary>
        /// 得意先一括修正抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="stMngSectionCode">開始管理拠点コード</param>
        /// <param name="edMngSectionCode">終了管理拠点コード</param>
        /// <param name="stCustomerCode">開始得意先</param>
        /// <param name="edCustomerCode">終了得意先</param>
        /// <param name="stKana">開始カナ</param>
        /// <param name="edKana">終了カナ</param>
        /// <param name="stCustomerAgentCd">開始顧客担当従業員コード(文字型)</param>
        /// <param name="edCustomerAgentCd">終了顧客担当従業員コード(文字型)</param>
        /// <param name="stSalesAreaCode">開始販売エリアコード</param>
        /// <param name="edSalesAreaCode">終了販売エリアコード</param>
        /// <param name="stBusinessTypeCode">開始業種コード</param>
        /// <param name="edBusinessTypeCode">終了業種コード</param>
        /// <param name="searchDiv">検索区分(0:得意先マスタ＋変動情報　1得意先マスタ+変動情報+掛率G)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>CustomerCustomerChangeParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeParam(string enterpriseCode, string stMngSectionCode, string edMngSectionCode, Int32 stCustomerCode, Int32 edCustomerCode, string stKana, string edKana, string stCustomerAgentCd, string edCustomerAgentCd, Int32 stSalesAreaCode, Int32 edSalesAreaCode, Int32 stBusinessTypeCode, Int32 edBusinessTypeCode, Int32 searchDiv, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._stMngSectionCode = stMngSectionCode;
            this._edMngSectionCode = edMngSectionCode;
            this._stCustomerCode = stCustomerCode;
            this._edCustomerCode = edCustomerCode;
            this._stKana = stKana;
            this._edKana = edKana;
            this._stCustomerAgentCd = stCustomerAgentCd;
            this._edCustomerAgentCd = edCustomerAgentCd;
            this._stSalesAreaCode = stSalesAreaCode;
            this._edSalesAreaCode = edSalesAreaCode;
            this._stBusinessTypeCode = stBusinessTypeCode;
            this._edBusinessTypeCode = edBusinessTypeCode;
            this._searchDiv = searchDiv;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 得意先一括修正抽出条件クラスワーク複製処理
        /// </summary>
        /// <returns>CustomerCustomerChangeParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustomerCustomerChangeParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeParam Clone()
        {
            return new CustomerCustomerChangeParam(this._enterpriseCode, this._stMngSectionCode, this._edMngSectionCode, this._stCustomerCode, this._edCustomerCode, this._stKana, this._edKana, this._stCustomerAgentCd, this._edCustomerAgentCd, this._stSalesAreaCode, this._edSalesAreaCode, this._stBusinessTypeCode, this._edBusinessTypeCode, this._searchDiv, this._enterpriseName);
        }

        /// <summary>
        /// 得意先一括修正抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomerCustomerChangeParamクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustomerCustomerChangeParam target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.StMngSectionCode == target.StMngSectionCode)
                 && (this.EdMngSectionCode == target.EdMngSectionCode)
                 && (this.StCustomerCode == target.StCustomerCode)
                 && (this.EdCustomerCode == target.EdCustomerCode)
                 && (this.StKana == target.StKana)
                 && (this.EdKana == target.EdKana)
                 && (this.StCustomerAgentCd == target.StCustomerAgentCd)
                 && (this.EdCustomerAgentCd == target.EdCustomerAgentCd)
                 && (this.StSalesAreaCode == target.StSalesAreaCode)
                 && (this.EdSalesAreaCode == target.EdSalesAreaCode)
                 && (this.StBusinessTypeCode == target.StBusinessTypeCode)
                 && (this.EdBusinessTypeCode == target.EdBusinessTypeCode)
                 && (this.SearchDiv == target.SearchDiv)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 得意先一括修正抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="customerCustomerChangeParam1">
        ///                    比較するCustomerCustomerChangeParamクラスのインスタンス
        /// </param>
        /// <param name="customerCustomerChangeParam2">比較するCustomerCustomerChangeParamクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustomerCustomerChangeParam customerCustomerChangeParam1, CustomerCustomerChangeParam customerCustomerChangeParam2)
        {
            return ((customerCustomerChangeParam1.EnterpriseCode == customerCustomerChangeParam2.EnterpriseCode)
                 && (customerCustomerChangeParam1.StMngSectionCode == customerCustomerChangeParam2.StMngSectionCode)
                 && (customerCustomerChangeParam1.EdMngSectionCode == customerCustomerChangeParam2.EdMngSectionCode)
                 && (customerCustomerChangeParam1.StCustomerCode == customerCustomerChangeParam2.StCustomerCode)
                 && (customerCustomerChangeParam1.EdCustomerCode == customerCustomerChangeParam2.EdCustomerCode)
                 && (customerCustomerChangeParam1.StKana == customerCustomerChangeParam2.StKana)
                 && (customerCustomerChangeParam1.EdKana == customerCustomerChangeParam2.EdKana)
                 && (customerCustomerChangeParam1.StCustomerAgentCd == customerCustomerChangeParam2.StCustomerAgentCd)
                 && (customerCustomerChangeParam1.EdCustomerAgentCd == customerCustomerChangeParam2.EdCustomerAgentCd)
                 && (customerCustomerChangeParam1.StSalesAreaCode == customerCustomerChangeParam2.StSalesAreaCode)
                 && (customerCustomerChangeParam1.EdSalesAreaCode == customerCustomerChangeParam2.EdSalesAreaCode)
                 && (customerCustomerChangeParam1.StBusinessTypeCode == customerCustomerChangeParam2.StBusinessTypeCode)
                 && (customerCustomerChangeParam1.EdBusinessTypeCode == customerCustomerChangeParam2.EdBusinessTypeCode)
                 && (customerCustomerChangeParam1.SearchDiv == customerCustomerChangeParam2.SearchDiv)
                 && (customerCustomerChangeParam1.EnterpriseName == customerCustomerChangeParam2.EnterpriseName));
        }
        /// <summary>
        /// 得意先一括修正抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomerCustomerChangeParamクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustomerCustomerChangeParam target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.StMngSectionCode != target.StMngSectionCode) resList.Add("StMngSectionCode");
            if (this.EdMngSectionCode != target.EdMngSectionCode) resList.Add("EdMngSectionCode");
            if (this.StCustomerCode != target.StCustomerCode) resList.Add("StCustomerCode");
            if (this.EdCustomerCode != target.EdCustomerCode) resList.Add("EdCustomerCode");
            if (this.StKana != target.StKana) resList.Add("StKana");
            if (this.EdKana != target.EdKana) resList.Add("EdKana");
            if (this.StCustomerAgentCd != target.StCustomerAgentCd) resList.Add("StCustomerAgentCd");
            if (this.EdCustomerAgentCd != target.EdCustomerAgentCd) resList.Add("EdCustomerAgentCd");
            if (this.StSalesAreaCode != target.StSalesAreaCode) resList.Add("StSalesAreaCode");
            if (this.EdSalesAreaCode != target.EdSalesAreaCode) resList.Add("EdSalesAreaCode");
            if (this.StBusinessTypeCode != target.StBusinessTypeCode) resList.Add("StBusinessTypeCode");
            if (this.EdBusinessTypeCode != target.EdBusinessTypeCode) resList.Add("EdBusinessTypeCode");
            if (this.SearchDiv != target.SearchDiv) resList.Add("SearchDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 得意先一括修正抽出条件クラスワーク比較処理
        /// </summary>
        /// <param name="customerCustomerChangeParam1">比較するCustomerCustomerChangeParamクラスのインスタンス</param>
        /// <param name="customerCustomerChangeParam2">比較するCustomerCustomerChangeParamクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustomerCustomerChangeParam customerCustomerChangeParam1, CustomerCustomerChangeParam customerCustomerChangeParam2)
        {
            ArrayList resList = new ArrayList();
            if (customerCustomerChangeParam1.EnterpriseCode != customerCustomerChangeParam2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customerCustomerChangeParam1.StMngSectionCode != customerCustomerChangeParam2.StMngSectionCode) resList.Add("StMngSectionCode");
            if (customerCustomerChangeParam1.EdMngSectionCode != customerCustomerChangeParam2.EdMngSectionCode) resList.Add("EdMngSectionCode");
            if (customerCustomerChangeParam1.StCustomerCode != customerCustomerChangeParam2.StCustomerCode) resList.Add("StCustomerCode");
            if (customerCustomerChangeParam1.EdCustomerCode != customerCustomerChangeParam2.EdCustomerCode) resList.Add("EdCustomerCode");
            if (customerCustomerChangeParam1.StKana != customerCustomerChangeParam2.StKana) resList.Add("StKana");
            if (customerCustomerChangeParam1.EdKana != customerCustomerChangeParam2.EdKana) resList.Add("EdKana");
            if (customerCustomerChangeParam1.StCustomerAgentCd != customerCustomerChangeParam2.StCustomerAgentCd) resList.Add("StCustomerAgentCd");
            if (customerCustomerChangeParam1.EdCustomerAgentCd != customerCustomerChangeParam2.EdCustomerAgentCd) resList.Add("EdCustomerAgentCd");
            if (customerCustomerChangeParam1.StSalesAreaCode != customerCustomerChangeParam2.StSalesAreaCode) resList.Add("StSalesAreaCode");
            if (customerCustomerChangeParam1.EdSalesAreaCode != customerCustomerChangeParam2.EdSalesAreaCode) resList.Add("EdSalesAreaCode");
            if (customerCustomerChangeParam1.StBusinessTypeCode != customerCustomerChangeParam2.StBusinessTypeCode) resList.Add("StBusinessTypeCode");
            if (customerCustomerChangeParam1.EdBusinessTypeCode != customerCustomerChangeParam2.EdBusinessTypeCode) resList.Add("EdBusinessTypeCode");
            if (customerCustomerChangeParam1.SearchDiv != customerCustomerChangeParam2.SearchDiv) resList.Add("SearchDiv");
            if (customerCustomerChangeParam1.EnterpriseName != customerCustomerChangeParam2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
