using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PaymentSet
    /// <summary>
    ///                      支払設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/03/30</br>
    /// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006.08.01  23006 高橋 明子</br>
    /// <br>			            ・項目追加</br>
    /// <br>Update Note      :   2008.06.18  徳永 俊詞</br>
    /// <br>	　                  ・項目「支払伝票呼出月数」削除</br>
    /// </remarks>
    public class PaymentSet
    {
        /*----------------------------------------------------------------------------------*/
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        private Int32 _logicalDeleteCode;

        /// <summary>支払設定管理No</summary>
        /// <remarks>0固定</remarks>
        private Int32 _payStMngNo;

        ///// <summary>初期選択金種コード</summary>
        //private Int32 _initSelMoneyKindCd;

        /// <summary>支払設定金種コード1</summary>
        private Int32 _payStMoneyKindCd1;

        /// <summary>支払設定金種コード2</summary>
        private Int32 _payStMoneyKindCd2;

        /// <summary>支払設定金種コード3</summary>
        private Int32 _payStMoneyKindCd3;

        /// <summary>支払設定金種コード4</summary>
        private Int32 _payStMoneyKindCd4;

        /// <summary>支払設定金種コード5</summary>
        private Int32 _payStMoneyKindCd5;

        /// <summary>支払設定金種コード6</summary>
        private Int32 _payStMoneyKindCd6;

        /// <summary>支払設定金種コード7</summary>
        private Int32 _payStMoneyKindCd7;

        /// <summary>支払設定金種コード8</summary>
        private Int32 _payStMoneyKindCd8;

        /// <summary>支払設定金種コード9</summary>
        private Int32 _payStMoneyKindCd9;

        /// <summary>支払設定金種コード10</summary>
        private Int32 _payStMoneyKindCd10;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <summary>支払伝票呼出月数</summary>
        //private Int32 _paySlipCallMonths;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
        ///// <summary>初期選択金種名称</summary>
        //private string _initSelMoneyKindNm = "";

        /// <summary>支払設定金種名称1</summary>
        private string _payStMoneyKindNm1 = "";

        /// <summary>支払設定金種名称2</summary>
        private string _payStMoneyKindNm2 = "";

        /// <summary>支払設定金種名称3</summary>
        private string _payStMoneyKindNm3 = "";

        /// <summary>支払設定金種名称4</summary>
        private string _payStMoneyKindNm4 = "";

        /// <summary>支払設定金種名称5</summary>
        private string _payStMoneyKindNm5 = "";

        /// <summary>支払設定金種名称6</summary>
        private string _payStMoneyKindNm6 = "";

        /// <summary>支払設定金種名称7</summary>
        private string _payStMoneyKindNm7 = "";

        /// <summary>支払設定金種名称8</summary>
        private string _payStMoneyKindNm8 = "";

        /// <summary>支払設定金種名称9</summary>
        private string _payStMoneyKindNm9 = "";

        /// <summary>支払設定金種名称10</summary>
        private string _payStMoneyKindNm10 = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

        /*----------------------------------------------------------------------------------*/
        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PayStMngNo
        /// <summary>支払設定管理Noプロパティ</summary>
        /// <value>0固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定管理Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMngNo
        {
            get { return _payStMngNo; }
            set { _payStMngNo = value; }
        }

        ///// public propaty name  :  InitSelMoneyKindCd
        ///// <summary>初期選択金種コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初期選択金種コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 InitSelMoneyKindCd
        //{
        //    get { return _initSelMoneyKindCd; }
        //    set { _initSelMoneyKindCd = value; }
        //}

        /// public propaty name  :  PayStMoneyKindCd1
        /// <summary>支払設定金種コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd1
        {
            get { return _payStMoneyKindCd1; }
            set { _payStMoneyKindCd1 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd2
        /// <summary>支払設定金種コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd2
        {
            get { return _payStMoneyKindCd2; }
            set { _payStMoneyKindCd2 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd3
        /// <summary>支払設定金種コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd3
        {
            get { return _payStMoneyKindCd3; }
            set { _payStMoneyKindCd3 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd4
        /// <summary>支払設定金種コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd4
        {
            get { return _payStMoneyKindCd4; }
            set { _payStMoneyKindCd4 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd5
        /// <summary>支払設定金種コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd5
        {
            get { return _payStMoneyKindCd5; }
            set { _payStMoneyKindCd5 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd6
        /// <summary>支払設定金種コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd6
        {
            get { return _payStMoneyKindCd6; }
            set { _payStMoneyKindCd6 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd7
        /// <summary>支払設定金種コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd7
        {
            get { return _payStMoneyKindCd7; }
            set { _payStMoneyKindCd7 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd8
        /// <summary>支払設定金種コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd8
        {
            get { return _payStMoneyKindCd8; }
            set { _payStMoneyKindCd8 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd9
        /// <summary>支払設定金種コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd9
        {
            get { return _payStMoneyKindCd9; }
            set { _payStMoneyKindCd9 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd10
        /// <summary>支払設定金種コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd10
        {
            get { return _payStMoneyKindCd10; }
            set { _payStMoneyKindCd10 = value; }
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// public propaty name  :  PaySlipCallMonths
        /// <summary>支払伝票呼出月数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払伝票呼出月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public Int32 PaySlipCallMonths
        //{
            //get { return _paySlipCallMonths; }
            //set { _paySlipCallMonths = value; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
        ///// public propaty name  :  InitSelMoneyKindNm
        ///// <summary>初期選択金種名称</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初期選択金種名称プロパティ</br>
        ///// <br>Programer        :   23006  高橋 明子</br>
        ///// </remarks>
        //public string InitSelMoneyKindNm
        //{
        //    get { return _initSelMoneyKindNm; }
        //    set { _initSelMoneyKindNm = value; }
        //}

        /// public propaty name  :  PayStMoneyKindNm1
        /// <summary>支払設定金種名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称1プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm1
        {
            get { return _payStMoneyKindNm1; }
            set { _payStMoneyKindNm1 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm2
        /// <summary>支払設定金種名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称2プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm2
        {
            get { return _payStMoneyKindNm2; }
            set { _payStMoneyKindNm2 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm3
        /// <summary>支払設定金種名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称3プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm3
        {
            get { return _payStMoneyKindNm3; }
            set { _payStMoneyKindNm3 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm4
        /// <summary>支払設定金種名称4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称4プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm4
        {
            get { return _payStMoneyKindNm4; }
            set { _payStMoneyKindNm4 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm5
        /// <summary>支払設定金種名称5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称5プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm5
        {
            get { return _payStMoneyKindNm5; }
            set { _payStMoneyKindNm5 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm6
        /// <summary>支払設定金種名称6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称6プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm6
        {
            get { return _payStMoneyKindNm6; }
            set { _payStMoneyKindNm6 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm7
        /// <summary>支払設定金種名称7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称7プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm7
        {
            get { return _payStMoneyKindNm7; }
            set { _payStMoneyKindNm7 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm8
        /// <summary>支払設定金種名称8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称8プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm8
        {
            get { return _payStMoneyKindNm8; }
            set { _payStMoneyKindNm8 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm9
        /// <summary>支払設定金種名称9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称9プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm9
        {
            get { return _payStMoneyKindNm9; }
            set { _payStMoneyKindNm9 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm10
        /// <summary>支払設定金種名称10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払設定金種名称10プロパティ</br>
        /// <br>Programer        :   23006  高橋 明子</br>
        /// </remarks>
        public string PayStMoneyKindNm10
        {
            get { return _payStMoneyKindNm10; }
            set { _payStMoneyKindNm10 = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタコンストラクタ
        /// </summary>
        /// <returns>PaymentSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentSet()
        {
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="payStMngNo">支払設定管理No(0固定)</param>
        /// <param name="initSelMoneyKindCd">初期選択金種コード</param>
        /// <param name="payStMoneyKindCd1">支払設定金種コード1</param>
        /// <param name="payStMoneyKindCd2">支払設定金種コード2</param>
        /// <param name="payStMoneyKindCd3">支払設定金種コード3</param>
        /// <param name="payStMoneyKindCd4">支払設定金種コード4</param>
        /// <param name="payStMoneyKindCd5">支払設定金種コード5</param>
        /// <param name="payStMoneyKindCd6">支払設定金種コード6</param>
        /// <param name="payStMoneyKindCd7">支払設定金種コード7</param>
        /// <param name="payStMoneyKindCd8">支払設定金種コード8</param>
        /// <param name="payStMoneyKindCd9">支払設定金種コード9</param>
        /// <param name="payStMoneyKindCd10">支払設定金種コード10</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <param name="paySlipCallMonths">支払伝票呼出月数</param>
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="payStMoneyKindNm1">支払設定金種名称1</param>
        /// <param name="payStMoneyKindNm2">支払設定金種名称2</param>
        /// <param name="payStMoneyKindNm3">支払設定金種名称3</param>
        /// <param name="payStMoneyKindNm4">支払設定金種名称4</param>
        /// <param name="payStMoneyKindNm5">支払設定金種名称5</param>
        /// <param name="payStMoneyKindNm6">支払設定金種名称6</param>
        /// <param name="payStMoneyKindNm7">支払設定金種名称7</param>
        /// <param name="payStMoneyKindNm8">支払設定金種名称8</param>
        /// <param name="payStMoneyKindNm9">支払設定金種名称9</param>
        /// <param name="payStMoneyKindNm10">支払設定金種名称10</param>
        /// <param name="initSelMoneyKindNm">初期選択金種名称(1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金)</param>
        /// <returns>PaymentSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
        //public PaymentSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 payStMngNo, Int32 initSelMoneyKindCd, Int32 payStMoneyKindCd1, Int32 payStMoneyKindCd2, Int32 payStMoneyKindCd3, Int32 payStMoneyKindCd4, Int32 payStMoneyKindCd5, Int32 payStMoneyKindCd6, Int32 payStMoneyKindCd7, Int32 payStMoneyKindCd8, Int32 payStMoneyKindCd9, Int32 payStMoneyKindCd10, Int32 paySlipCallMonths, string payStMoneyKindNm1, string payStMoneyKindNm2, string payStMoneyKindNm3, string payStMoneyKindNm4, string payStMoneyKindNm5, string payStMoneyKindNm6, string payStMoneyKindNm7, string payStMoneyKindNm8, string payStMoneyKindNm9, string payStMoneyKindNm10, string updEmployeeName, string enterpriseName, string initSelMoneyKindNm)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        public PaymentSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 payStMngNo, Int32 payStMoneyKindCd1, Int32 payStMoneyKindCd2, Int32 payStMoneyKindCd3, Int32 payStMoneyKindCd4, Int32 payStMoneyKindCd5, Int32 payStMoneyKindCd6, Int32 payStMoneyKindCd7, Int32 payStMoneyKindCd8, Int32 payStMoneyKindCd9, Int32 payStMoneyKindCd10, string payStMoneyKindNm1, string payStMoneyKindNm2, string payStMoneyKindNm3, string payStMoneyKindNm4, string payStMoneyKindNm5, string payStMoneyKindNm6, string payStMoneyKindNm7, string payStMoneyKindNm8, string payStMoneyKindNm9, string payStMoneyKindNm10, string updEmployeeName, string enterpriseName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._payStMngNo = payStMngNo;
            //this._initSelMoneyKindCd = initSelMoneyKindCd;
            this._payStMoneyKindCd1 = payStMoneyKindCd1;
            this._payStMoneyKindCd2 = payStMoneyKindCd2;
            this._payStMoneyKindCd3 = payStMoneyKindCd3;
            this._payStMoneyKindCd4 = payStMoneyKindCd4;
            this._payStMoneyKindCd5 = payStMoneyKindCd5;
            this._payStMoneyKindCd6 = payStMoneyKindCd6;
            this._payStMoneyKindCd7 = payStMoneyKindCd7;
            this._payStMoneyKindCd8 = payStMoneyKindCd8;
            this._payStMoneyKindCd9 = payStMoneyKindCd9;
            this._payStMoneyKindCd10 = payStMoneyKindCd10;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //this._paySlipCallMonths = paySlipCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

            this._updEmployeeName = updEmployeeName;
            this._enterpriseName = enterpriseName;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
            //this._initSelMoneyKindNm = initSelMoneyKindNm;
            this._payStMoneyKindNm1 = payStMoneyKindNm1;
            this._payStMoneyKindNm2 = payStMoneyKindNm2;
            this._payStMoneyKindNm3 = payStMoneyKindNm3;
            this._payStMoneyKindNm4 = payStMoneyKindNm4;
            this._payStMoneyKindNm5 = payStMoneyKindNm5;
            this._payStMoneyKindNm6 = payStMoneyKindNm6;
            this._payStMoneyKindNm7 = payStMoneyKindNm7;
            this._payStMoneyKindNm8 = payStMoneyKindNm8;
            this._payStMoneyKindNm9 = payStMoneyKindNm9;
            this._payStMoneyKindNm10 = payStMoneyKindNm10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタ複製処理
        /// </summary>
        /// <returns>PaymentSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPaymentSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentSet Clone()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
            return new PaymentSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._payStMngNo, this._payStMoneyKindCd1, this._payStMoneyKindCd2, this._payStMoneyKindCd3, this._payStMoneyKindCd4, this._payStMoneyKindCd5, this._payStMoneyKindCd6, this._payStMoneyKindCd7, this._payStMoneyKindCd8, this._payStMoneyKindCd9, this._payStMoneyKindCd10, this._payStMoneyKindNm1, this._payStMoneyKindNm2, this._payStMoneyKindNm3, this._payStMoneyKindNm4, this._payStMoneyKindNm5, this._payStMoneyKindNm6, this._payStMoneyKindNm7, this._payStMoneyKindNm8, this._payStMoneyKindNm9, this._payStMoneyKindNm10, this._updEmployeeName, this._enterpriseName);
            //return new PaymentSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._payStMngNo, this._initSelMoneyKindCd, this._payStMoneyKindCd1, this._payStMoneyKindCd2, this._payStMoneyKindCd3, this._payStMoneyKindCd4, this._payStMoneyKindCd5, this._payStMoneyKindCd6, this._payStMoneyKindCd7, this._payStMoneyKindCd8, this._payStMoneyKindCd9, this._payStMoneyKindCd10, this._paySlipCallMonths, this._payStMoneyKindNm1, this._payStMoneyKindNm2, this._payStMoneyKindNm3, this._payStMoneyKindNm4, this._payStMoneyKindNm5, this._payStMoneyKindNm6, this._payStMoneyKindNm7, this._payStMoneyKindNm8, this._payStMoneyKindNm9, this._payStMoneyKindNm10, this._updEmployeeName, this._enterpriseName, this._initSelMoneyKindNm);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPaymentSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PaymentSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PayStMngNo == target.PayStMngNo)
                 //&& (this.InitSelMoneyKindCd == target.InitSelMoneyKindCd)
                 && (this.PayStMoneyKindCd1 == target.PayStMoneyKindCd1)
                 && (this.PayStMoneyKindCd2 == target.PayStMoneyKindCd2)
                 && (this.PayStMoneyKindCd3 == target.PayStMoneyKindCd3)
                 && (this.PayStMoneyKindCd4 == target.PayStMoneyKindCd4)
                 && (this.PayStMoneyKindCd5 == target.PayStMoneyKindCd5)
                 && (this.PayStMoneyKindCd6 == target.PayStMoneyKindCd6)
                 && (this.PayStMoneyKindCd7 == target.PayStMoneyKindCd7)
                 && (this.PayStMoneyKindCd8 == target.PayStMoneyKindCd8)
                 && (this.PayStMoneyKindCd9 == target.PayStMoneyKindCd9)
                 && (this.PayStMoneyKindCd10 == target.PayStMoneyKindCd10)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                // && (this.PaySlipCallMonths == target.PaySlipCallMonths)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.EnterpriseName == target.EnterpriseName)

                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
                 //&& (this.InitSelMoneyKindNm == target.InitSelMoneyKindNm)
                 && (this.PayStMoneyKindNm1 == target.PayStMoneyKindNm1)
                 && (this.PayStMoneyKindNm2 == target.PayStMoneyKindNm2)
                 && (this.PayStMoneyKindNm3 == target.PayStMoneyKindNm3)
                 && (this.PayStMoneyKindNm4 == target.PayStMoneyKindNm4)
                 && (this.PayStMoneyKindNm5 == target.PayStMoneyKindNm5)
                 && (this.PayStMoneyKindNm6 == target.PayStMoneyKindNm6)
                 && (this.PayStMoneyKindNm7 == target.PayStMoneyKindNm7)
                 && (this.PayStMoneyKindNm8 == target.PayStMoneyKindNm8)
                 && (this.PayStMoneyKindNm9 == target.PayStMoneyKindNm9)
                 && (this.PayStMoneyKindNm10 == target.PayStMoneyKindNm10));
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタ比較処理
        /// </summary>
        /// <param name="paymentSet1">
        ///                    比較するPaymentSetクラスのインスタンス
        /// </param>
        /// <param name="paymentSet2">比較するPaymentSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PaymentSet paymentSet1, PaymentSet paymentSet2)
        {
            return ((paymentSet1.CreateDateTime == paymentSet2.CreateDateTime)
                 && (paymentSet1.UpdateDateTime == paymentSet2.UpdateDateTime)
                 && (paymentSet1.EnterpriseCode == paymentSet2.EnterpriseCode)
                 && (paymentSet1.FileHeaderGuid == paymentSet2.FileHeaderGuid)
                 && (paymentSet1.UpdEmployeeCode == paymentSet2.UpdEmployeeCode)
                 && (paymentSet1.UpdAssemblyId1 == paymentSet2.UpdAssemblyId1)
                 && (paymentSet1.UpdAssemblyId2 == paymentSet2.UpdAssemblyId2)
                 && (paymentSet1.LogicalDeleteCode == paymentSet2.LogicalDeleteCode)
                 && (paymentSet1.PayStMngNo == paymentSet2.PayStMngNo)

                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                 //&& (paymentSet1.PaySlipCallMonths == paymentSet2.PaySlipCallMonths)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

                 && (paymentSet1.EnterpriseName == paymentSet2.EnterpriseName)
                 && (paymentSet1.UpdEmployeeName == paymentSet2.UpdEmployeeName)

                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
                 //&& (paymentSet1.InitSelMoneyKindCd == paymentSet2.InitSelMoneyKindCd)
                 && (paymentSet1.PayStMoneyKindCd1 == paymentSet2.PayStMoneyKindCd1)
                 && (paymentSet1.PayStMoneyKindCd2 == paymentSet2.PayStMoneyKindCd2)
                 && (paymentSet1.PayStMoneyKindCd3 == paymentSet2.PayStMoneyKindCd3)
                 && (paymentSet1.PayStMoneyKindCd4 == paymentSet2.PayStMoneyKindCd4)
                 && (paymentSet1.PayStMoneyKindCd5 == paymentSet2.PayStMoneyKindCd5)
                 && (paymentSet1.PayStMoneyKindCd6 == paymentSet2.PayStMoneyKindCd6)
                 && (paymentSet1.PayStMoneyKindCd7 == paymentSet2.PayStMoneyKindCd7)
                 && (paymentSet1.PayStMoneyKindCd8 == paymentSet2.PayStMoneyKindCd8)
                 && (paymentSet1.PayStMoneyKindCd9 == paymentSet2.PayStMoneyKindCd9)
                 && (paymentSet1.PayStMoneyKindCd10 == paymentSet2.PayStMoneyKindCd10));
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPaymentSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PaymentSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.PayStMngNo != target.PayStMngNo) resList.Add("PayStMngNo");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (this.PaySlipCallMonths != target.PaySlipCallMonths) resList.Add("PaySlipCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
            //if (this.InitSelMoneyKindCd != target.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            if (this.PayStMoneyKindCd1 != target.PayStMoneyKindCd1) resList.Add("PayStMoneyKindCd1");
            if (this.PayStMoneyKindCd2 != target.PayStMoneyKindCd2) resList.Add("PayStMoneyKindCd2");
            if (this.PayStMoneyKindCd3 != target.PayStMoneyKindCd3) resList.Add("PayStMoneyKindCd3");
            if (this.PayStMoneyKindCd4 != target.PayStMoneyKindCd4) resList.Add("PayStMoneyKindCd4");
            if (this.PayStMoneyKindCd5 != target.PayStMoneyKindCd5) resList.Add("PayStMoneyKindCd5");
            if (this.PayStMoneyKindCd6 != target.PayStMoneyKindCd6) resList.Add("PayStMoneyKindCd6");
            if (this.PayStMoneyKindCd7 != target.PayStMoneyKindCd7) resList.Add("PayStMoneyKindCd7");
            if (this.PayStMoneyKindCd8 != target.PayStMoneyKindCd8) resList.Add("PayStMoneyKindCd8");
            if (this.PayStMoneyKindCd9 != target.PayStMoneyKindCd9) resList.Add("PayStMoneyKindCd9");
            if (this.PayStMoneyKindCd10 != target.PayStMoneyKindCd10) resList.Add("PayStMoneyKindCd10");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

            return resList;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 支払設定マスタ比較処理
        /// </summary>
        /// <param name="paymentSet1">比較するPaymentSetクラスのインスタンス</param>
        /// <param name="paymentSet2">比較するPaymentSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PaymentSet paymentSet1, PaymentSet paymentSet2)
        {
            ArrayList resList = new ArrayList();
            if (paymentSet1.CreateDateTime != paymentSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (paymentSet1.UpdateDateTime != paymentSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (paymentSet1.EnterpriseCode != paymentSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (paymentSet1.FileHeaderGuid != paymentSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (paymentSet1.UpdEmployeeCode != paymentSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (paymentSet1.UpdAssemblyId1 != paymentSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (paymentSet1.UpdAssemblyId2 != paymentSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (paymentSet1.LogicalDeleteCode != paymentSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (paymentSet1.PayStMngNo != paymentSet2.PayStMngNo) resList.Add("PayStMngNo");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (paymentSet1.PaySlipCallMonths != paymentSet2.PaySlipCallMonths) resList.Add("PaySlipCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

            if (paymentSet1.EnterpriseName != paymentSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (paymentSet1.UpdEmployeeName != paymentSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
            //if (paymentSet1.InitSelMoneyKindCd != paymentSet2.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            if (paymentSet1.PayStMoneyKindCd1 != paymentSet2.PayStMoneyKindCd1) resList.Add("PayStMoneyKindCd1");
            if (paymentSet1.PayStMoneyKindCd2 != paymentSet2.PayStMoneyKindCd2) resList.Add("PayStMoneyKindCd2");
            if (paymentSet1.PayStMoneyKindCd3 != paymentSet2.PayStMoneyKindCd3) resList.Add("PayStMoneyKindCd3");
            if (paymentSet1.PayStMoneyKindCd4 != paymentSet2.PayStMoneyKindCd4) resList.Add("PayStMoneyKindCd4");
            if (paymentSet1.PayStMoneyKindCd5 != paymentSet2.PayStMoneyKindCd5) resList.Add("PayStMoneyKindCd5");
            if (paymentSet1.PayStMoneyKindCd6 != paymentSet2.PayStMoneyKindCd6) resList.Add("PayStMoneyKindCd6");
            if (paymentSet1.PayStMoneyKindCd7 != paymentSet2.PayStMoneyKindCd7) resList.Add("PayStMoneyKindCd7");
            if (paymentSet1.PayStMoneyKindCd8 != paymentSet2.PayStMoneyKindCd8) resList.Add("PayStMoneyKindCd8");
            if (paymentSet1.PayStMoneyKindCd9 != paymentSet2.PayStMoneyKindCd9) resList.Add("PayStMoneyKindCd9");
            if (paymentSet1.PayStMoneyKindCd10 != paymentSet2.PayStMoneyKindCd10) resList.Add("PayStMoneyKindCd10");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

            return resList;
        }
    }
}
