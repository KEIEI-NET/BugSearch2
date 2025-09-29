//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表(総括)抽出条件クラス
// プログラム概要   : 買掛残高一覧表(総括)抽出条件クラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成 仕入総括機能対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SumAccPaymentListCndtn
    /// <summary>
    ///                      買掛残高一覧表(総括)抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   買掛残高一覧表(総括)抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/04/10</br>
    /// </remarks>
    public class SumAccPaymentListCndtn　　
	{
		#region ■ Private Member
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        /// <remarks>（配列）</remarks>
        private string[] _sectionCodes = new string[0];

        /// <summary>計上年月日</summary>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>開始請求先コード</summary>
        private Int32 _st_PayeeCode;

        /// <summary>終了請求先コード</summary>
        private Int32 _ed_PayeeCode;

        /// <summary>出力金額区分</summary>
        /// <remarks>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</remarks>
        private OutMoneyDivState _outMoneyDiv;

        /// <summary>改頁</summary>
        private Int32 _newPageType;

        /// <summary>総括内訳区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _sumSuppDtlDiv;

        /// <summary>支払内訳区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _payDtlDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        /// <summary>税別内訳印字区分</summary>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        private Double _taxRate2;
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
		#endregion ■ Private Member

        #region ■ Public Property
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

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
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

        /// public propaty name  :  OutMoneyDiv
        /// <summary>出力金額区分プロパティ</summary>
        /// <value>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OutMoneyDivState OutMoneyDiv
        {
            get { return _outMoneyDiv; }
            set { _outMoneyDiv = value; }
        }

        /// public propaty name  :  NewPageType
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }

        /// public propaty name  :  SumSuppDtlDiv
        /// <summary>総括内訳区分プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総括内訳区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SumSuppDtlDiv
        {
            get { return _sumSuppDtlDiv; }
            set { _sumSuppDtlDiv = value; }
        }

        /// public propaty name  :  PayDtlDiv
        /// <summary>支払内訳区分プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支払内訳区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PayDtlDiv
        {
            get { return _payDtlDiv; }
            set { _payDtlDiv = value; }
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
		#endregion ■ Public Property

        #region ■ Private Const (自動生成以外)
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_MonthFomat = "YYYY/MM";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        // 出力金額区分 --------------------------------------------------------------------
        /// <summary>全て</summary>
        public const string ct_OutMoneyDiv_All = "全て出力";
        /// <summary>0+プラス金額</summary>
        public const string ct_OutMoneyDiv_ZeroPlus = "0とプラス金額を出力";
        /// <summary>プラス金額</summary>
        public const string ct_OutMoneyDiv_Plus = "プラス金額のみ出力";
        /// <summary>0出力</summary>
        public const string ct_OutMoneyDiv_Zero = "0のみ出力";
        /// <summary>プラス金額+マイナス金額</summary>
        public const string ct_OutMoneyDiv_PlusMinus = "プラス金額とマイナス金額";
        /// <summary>0+マイナス金額</summary>
        public const string ct_OutMoneyDiv_ZeroMinus = "0とマイナス金額を出力";
        /// <summary>マイナス金額</summary>
        public const string ct_OutMoneyDiv_Minus = "マイナス金額のみ出力";
        #endregion

        #region ■ Public Member (自動生成以外)
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;
        #endregion

        #region ■ Public Property (自動生成以外)
        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }
        /// public propaty name  :  OutMoneyDivName
        /// <summary>出力金額区分名称プロパティ(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutMoneyDivName
        {
            get
            {
                string outMoneyDivName = string.Empty;
                // 出力金額区分から名称を判断
                switch ( this._outMoneyDiv )
                {
                    case OutMoneyDivState.All:		    // 全て
                        outMoneyDivName = ct_OutMoneyDiv_All;
                        break;
                    case OutMoneyDivState.ZeroPlus:	   // 0+プラス金額
                        outMoneyDivName = ct_OutMoneyDiv_ZeroPlus;
                        break;
                    case OutMoneyDivState.Plus:	       // プラス金額
                        outMoneyDivName = ct_OutMoneyDiv_Plus;
                        break;
                    case OutMoneyDivState.Zero:	       // 0出力
                        outMoneyDivName = ct_OutMoneyDiv_Zero;
                        break;
                    case OutMoneyDivState.PlusMinus:   // プラス金額+マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_PlusMinus;
                        break;
                    case OutMoneyDivState.ZeroMinus:   // 0+マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_ZeroMinus;
                        break;
                    case OutMoneyDivState.Minus:       // マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_Minus;
                        break;
                    default:
                        outMoneyDivName = string.Empty;
                        break;
                }
                return outMoneyDivName;
            }
        }

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        /// <summary>税別内訳印字区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税別内訳印字区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>税率1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
        #endregion

        #region ■ Public Enum (自動生成以外)
        #region ◆ 出力金額区分列挙体
        /// <summary> 出力金額区分列挙体 </summary>
        public enum OutMoneyDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>0+プラス金額</summary>
            ZeroPlus = 1,
            /// <summary>プラス金額</summary>
            Plus = 2,
            /// <summary>0出力</summary>
            Zero = 3,
            /// <summary>プラス金額+マイナス金額</summary>
            PlusMinus = 4,
            /// <summary>0+マイナス金額</summary>
            ZeroMinus = 5,
            /// <summary>マイナス金額</summary>
            Minus = 6,
        }
        #endregion ◆
        #endregion

        #region ■ Constructor
        /// <summary>
		/// コンストラクタ
		/// </summary>
        /// <returns>AccPaymentListCndtnクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   AccPaymentListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public SumAccPaymentListCndtn ()
		{
		}
		#endregion ■ Constructor

	}
}
