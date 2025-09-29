//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   当月車検車両一覧表 データクラス
//                  :   PMSYA02101E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   薛祺
// Date             :   2010.04.21
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MonthCarInspectListPara
    /// <summary>
    ///                      当月車検車両一覧表データクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   当月車検車両一覧表データクラス</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/04/21</br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// </remarks>
    public class MonthCarInspectListPara
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;

        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>開始得意先コード</summary>
        private string _stCustomerCode;

        /// <summary>終了得意先コード</summary>
        private string _edCustomerCode;

        /// <summary>拠点コード</summary>
        private string[] _sectionCodes;

        /// <summary>車検満期日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inspectMaturityDate;

        /// <summary>開始管理番号</summary>
        private string _stCarMngCode;

        /// <summary>終了管理番号</summary>
        private string _edCarMngCode;

        /// <summary>改行</summary>
        /// <remarks>0:べた打ち 1:1行空行</remarks>
        private ChangeRowDivState _changeRowDiv;

        /// <summary>改頁</summary>
        /// <remarks>0:しない 1:得意先</remarks>
        private ChangePageDivState _changePageDiv;

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

        /// public propaty name  :  StCustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StCustomerCode
        {
            get { return _stCustomerCode; }
            set { _stCustomerCode = value; }
        }

        /// public propaty name  :  EdCustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdCustomerCode
        {
            get { return _edCustomerCode; }
            set { _edCustomerCode = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  InspectMaturityDate
        /// <summary>車検満期日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検満期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }

        /// public propaty name  :  InspectMaturityDateJpFormal
        /// <summary>車検満期日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検満期日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InspectMaturityDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  InspectMaturityDateJpInFormal
        /// <summary>車検満期日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検満期日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InspectMaturityDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  InspectMaturityDateAdFormal
        /// <summary>車検満期日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検満期日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InspectMaturityDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  InspectMaturityDateAdInFormal
        /// <summary>車検満期日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検満期日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InspectMaturityDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inspectMaturityDate); }
            set { }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全拠点選択区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }


        /// public propaty name  :  StCarMngCode
        /// <summary>開始管理番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StCarMngCode
        {
            get { return _stCarMngCode; }
            set { _stCarMngCode = value; }
        }

        /// public propaty name  :  EdCarMngCode
        /// <summary>終了管理番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdCarMngCode
        {
            get { return _edCarMngCode; }
            set { _edCarMngCode = value; }
        }

        /// public propaty name  :  ChangeRowDiv
        /// <summary>改行</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改行プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ChangeRowDivState ChangeRowDiv
        {
            get { return _changeRowDiv; }
            set { _changeRowDiv = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>改頁</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ChangePageDivState ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// <summary>
        /// 改頁　列挙型
        /// </summary>
        public enum ChangePageDivState
        {
            /// <summary>べた打ち</summary>
            NotBlankLine = 0,
            /// <summary>1行空行</summary>
            BlankLine = 1,
        }

        /// <summary>
        /// 改行　列挙型
        /// </summary>
        public enum ChangeRowDivState
        {
            /// <summary>しない</summary>
            No = 0,
            /// <summary>得意先</summary>
            Customer = 1,
        }

        /// <summary>なし</summary>
        public const string ct_comm_No = "なし";
        /// <summary>得意先</summary>
        public const string ct_comm_Customer = "得意先";
        /// <summary>べた打ち</summary>
        public const string ct_comm_NotBlankLine = "べた打ち";
        /// <summary>1行空行</summary>
        public const string ct_comm_BlankLine = "1行空行";

        /// <summary>
        /// 改頁　名称取得
        /// </summary>
        public string ChangePageDivName
        {
            get
            {
                switch (this._changePageDiv)
                {
                    case ChangePageDivState.NotBlankLine:
                        return ct_comm_NotBlankLine;
                    case ChangePageDivState.BlankLine:
                        return ct_comm_BlankLine;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 改行　名称取得
        /// </summary>
        public string ChangeRowDivName
        {
            get
            {
                switch (this._changeRowDiv)
                {
                    case ChangeRowDivState.No:
                        return ct_comm_No;
                    case ChangeRowDivState.Customer:
                        return ct_comm_Customer;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
