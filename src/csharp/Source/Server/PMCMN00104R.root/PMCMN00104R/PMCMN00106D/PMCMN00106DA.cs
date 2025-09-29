using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TtlDayCalcParaWork
    /// <summary>
    ///                      締日算出抽出条件ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   締日算出抽出条件ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TtlDayCalcParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        /// <remarks>-1：すべて　０：請求売掛 １：支払買掛</remarks>
        private Int32 _procDiv;

        /// <summary>マスタ同時取得区分</summary>
        /// <remarks>0:マスタ取得しない　1:同時にマスタも取得する</remarks>
        private Int32 _withMasterDiv;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>開始年月日</summary>
        /// <remarks>"YYYYMMDD"</remarks>
        private Int32 _st_Date;

        /// <summary>終了年月日</summary>
        /// <remarks>"YYYYMMDD"</remarks>
        private Int32 _ed_Date;


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

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>０：すべて　１：請求売掛 ２：支払買掛</value>
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

        /// public propaty name  :  WithMasterDiv
        /// <summary>マスタ同時取得区分プロパティ</summary>
        /// <value>0:マスタ取得しない　1:同時にマスタも取得する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ同時取得区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WithMasterDiv
        {
            get { return _withMasterDiv; }
            set { _withMasterDiv = value; }
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  St_Date
        /// <summary>開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_Date
        {
            get { return _st_Date; }
            set { _st_Date = value; }
        }

        /// public propaty name  :  Ed_Date
        /// <summary>終了年月日プロパティ</summary>
        /// <value>"YYYYMMDD"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_Date
        {
            get { return _ed_Date; }
            set { _ed_Date = value; }
        }


        /// <summary>
        /// 締日算出抽出条件ワークワークコンストラクタ
        /// </summary>
        /// <returns>TtlDayCalcParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TtlDayCalcParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TtlDayCalcParaWork()
        {
        }

    }
}

