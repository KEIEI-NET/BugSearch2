using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustomerCustomerChangeParamWork
	/// <summary>
	///                      得意先一括修正抽出条件クラスワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先一括修正抽出条件クラスワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomerCustomerChangeParamWork 
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


        /// <summary>
        /// 得意先一括修正抽出条件クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>CustomerCustomerChangeParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeParamWork()
        {
        }
    }
}
