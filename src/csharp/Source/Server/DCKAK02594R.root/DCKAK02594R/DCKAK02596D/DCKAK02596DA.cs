using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_AccPayBalanceWork
    /// <summary>
    ///                      買掛残高元帳抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   買掛残高元帳抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/10/02 FSI菅原　要 仕入総括処理対応 仕入総括機能オプション追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_AccPayBalanceWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        /// <remarks>（配列）</remarks>
        private string[] _sectionCodes;

        /// <summary>開始計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _st_AddUpYearMonth;

        /// <summary>終了計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

        /// <summary>開始請求先コード</summary>
        private Int32 _st_PayeeCode;

        /// <summary>終了請求先コード</summary>
        private Int32 _ed_PayeeCode;

        // ---------- ADD 2012/10/02 ---------->>>>>
        /// <summary>仕入総括機能オプション有効／無効 </summary>
        private bool _sumOpt;
        // ---------- ADD 2012/10/02 ----------<<<<<

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
        /// <value>（配列）</value>
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

        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>開始計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>終了計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
        }

        /// public propaty name  :  St_PayeeCode
        /// <summary>開始請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_PayeeCode
        {
            get { return _st_PayeeCode; }
            set { _st_PayeeCode = value; }
        }

        /// public propaty name  :  Ed_PayeeCode
        /// <summary>終了請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_PayeeCode
        {
            get { return _ed_PayeeCode; }
            set { _ed_PayeeCode = value; }
        }

        // ---------- ADD 2012/10/02 ---------->>>>>
        /// public propaty name  :  SumOpt
        /// <summary>仕入総括機能オプション有効／無効プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入総括機能オプション有効／無効プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool SumOpt
        {
            get { return _sumOpt; }
            set { _sumOpt = value; }
        }
        // ---------- ADD 2012/10/02 ----------<<<<<

        /// <summary>
        /// 買掛残高元帳抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_AccPayBalanceWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_AccPayBalanceWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_AccPayBalanceWork()
        {
        }

    }
}
