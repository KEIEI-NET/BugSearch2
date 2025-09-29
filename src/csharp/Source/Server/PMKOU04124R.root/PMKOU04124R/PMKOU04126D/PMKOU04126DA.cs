using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppYearResultCndtnWork
    /// <summary>
    ///                      仕入年間実績照会抽出条件クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入年間実績照会抽出条件クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppYearResultCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コードが未設定時は「全社」</remarks>
        private string _sectionCode = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>拠点コードスタート</summary>
        private string _sectionCodeSt = "";

        /// <summary>拠点コード終了</summary>
        private string _sectionCodeEnd = "";

        /// <summary>仕入先コードスタート</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード終了</summary>
        private Int32 _supplierCdEnd;

        /// <summary>画面区分</summary>
        private string _mainDiv;
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>精算先区分</summary>
        /// <remarks>0:親、1:子　　子の場合には買掛残高照会タブ用の項目は返さない</remarks>
        private Int32 _accDiv;

        /// <summary>仕入先締日(年月日)</summary>
        /// <remarks>YYYYMMDD 仕入先の最終締年月日</remarks>
        private DateTime _suppTotalDay;

        /// <summary>期首年月日</summary>
        /// <remarks>YYYYMMDD 買掛残高照会タブの当期項目用</remarks>
        private DateTime _companyBiginDate;

        /// <summary>当期開始年月度</summary>
        /// <remarks>YYYYMM 実績照会タブで使用</remarks>
        private DateTime _this_YearMonth;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM 現在処理中年月を設定</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>自社締日(年月日)</summary>
        /// <remarks>YYYYMMDD 自社の最終締年月日</remarks>
        private DateTime _secTotalDay;


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
        /// <value>拠点コードが未設定時は「全社」</value>
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

        /// public propaty name  :  AccDiv
        /// <summary>精算先区分プロパティ</summary>
        /// <value>0:親、1:子　　子の場合には買掛残高照会タブ用の項目は返さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   精算先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccDiv
        {
            get { return _accDiv; }
            set { _accDiv = value; }
        }

        /// public propaty name  :  SuppTotalDay
        /// <summary>仕入先締日(年月日)プロパティ</summary>
        /// <value>YYYYMMDD 仕入先の最終締年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日(年月日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SuppTotalDay
        {
            get { return _suppTotalDay; }
            set { _suppTotalDay = value; }
        }

        /// public propaty name  :  CompanyBiginDate
        /// <summary>期首年月日プロパティ</summary>
        /// <value>YYYYMMDD 買掛残高照会タブの当期項目用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CompanyBiginDate
        {
            get { return _companyBiginDate; }
            set { _companyBiginDate = value; }
        }

        /// public propaty name  :  This_YearMonth
        /// <summary>当期開始年月度プロパティ</summary>
        /// <value>YYYYMM 実績照会タブで使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期開始年月度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime This_YearMonth
        {
            get { return _this_YearMonth; }
            set { _this_YearMonth = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM 現在処理中年月を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  SecTotalDay
        /// <summary>自社締日(年月日)プロパティ</summary>
        /// <value>YYYYMMDD 自社の最終締年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社締日(年月日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SecTotalDay
        {
            get { return _secTotalDay; }
            set { _secTotalDay = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>拠点コードスタートプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードスタートプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEnd
        /// <summary>拠点コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEnd
        {
            get { return _sectionCodeEnd; }
            set { _sectionCodeEnd = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コードスタートプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードスタートプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>仕入先コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEnd
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }

        /// public propaty name  :  MainDiv
        /// <summary>画面区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画面区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainDiv
        {
            get { return _mainDiv; }
            set { _mainDiv = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// 仕入年間実績照会抽出条件クラスワークワークコンストラクタ
        /// </summary>
        /// <returns>SuppYearResultCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SuppYearResultCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SuppYearResultCndtnWork()
        {
        }

    }
}
