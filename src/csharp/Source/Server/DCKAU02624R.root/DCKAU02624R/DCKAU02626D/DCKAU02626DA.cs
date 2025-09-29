using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_AccRecConsTaxDiffWork
    /// <summary>
    ///                      売掛消費税差異表抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売掛消費税差異表抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_AccRecConsTaxDiffWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>出力対象拠点</summary>
        /// <remarks>nullの場合は全拠点</remarks>
        private String[] _secCodeList;

        /// <summary>開始計上日</summary>
        private Int32 _st_SalesDate;

        /// <summary>終了計上日</summary>
        private Int32 _ed_SalesDate;


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

        /// public propaty name  :  SecCodeList
        /// <summary>出力対象拠点プロパティ</summary>
        /// <value>nullの場合は全拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力対象拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] SecCodeList
        {
            get { return _secCodeList; }
            set { _secCodeList = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>開始計上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>終了計上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了計上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }


        /// <summary>
        /// 売掛消費税差異表抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_AccRecConsTaxDiffWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_AccRecConsTaxDiffWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_AccRecConsTaxDiffWork()
        {
        }

    }
}
