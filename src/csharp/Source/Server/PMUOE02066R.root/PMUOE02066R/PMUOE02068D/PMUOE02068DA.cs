using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EnterSchOrderCndtnWork
    /// <summary>
    ///                      入庫予定表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入庫予定表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EnterSchOrderCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        private string[] _sectionCodes;

        /// <summary>開始UOE発注先コード</summary>
        private Int32 _st_UOESupplierCd;

        /// <summary>終了UOE発注先コード</summary>
        private Int32 _ed_UOESupplierCd;

        /// <summary>発注先コード指定(複数指定)</summary>
        private Int32[] _uOESupplierCds;

        /// <summary>開始受信日付</summary>
        private DateTime _st_ReceiveDate;

        /// <summary>終了受信日付</summary>
        private DateTime _ed_ReceiveDate;

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:入庫分のみ 1:メーカーフォロー分のみ　2:欠品分のみ</remarks>
        private Int32 _printTypeCndtn;


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

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コード（複数指定）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  St_UOESupplierCd
        /// <summary>開始UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_UOESupplierCd
        {
            get { return _st_UOESupplierCd; }
            set { _st_UOESupplierCd = value; }
        }

        /// public propaty name  :  Ed_UOESupplierCd
        /// <summary>終了UOE発注先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_UOESupplierCd
        {
            get { return _ed_UOESupplierCd; }
            set { _ed_UOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCds
        /// <summary>発注先コード指定(複数指定)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コード指定(複数指定)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] UOESupplierCds
        {
            get { return _uOESupplierCds; }
            set { _uOESupplierCds = value; }
        }

        /// public propaty name  :  St_ReceiveDate
        /// <summary>開始受信日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>終了受信日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  PrintTypeCndtn
        /// <summary>印刷タイププロパティ</summary>
        /// <value>0:入庫分のみ 1:メーカーフォロー分のみ　2:欠品分のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintTypeCndtn
        {
            get { return _printTypeCndtn; }
            set { _printTypeCndtn = value; }
        }


        /// <summary>
        /// 入庫予定表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>EnterSchOrderCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchOrderCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EnterSchOrderCndtnWork()
        {
        }

    }
}




