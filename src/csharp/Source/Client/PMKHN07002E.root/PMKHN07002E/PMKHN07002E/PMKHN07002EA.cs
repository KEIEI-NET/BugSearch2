//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 葉書・封筒・ＤＭテキスト出力
// プログラム概要   : 葉書・封筒・ＤＭテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 葉書・封筒・ＤＭテキスト出力クラス検索条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 葉書・封筒・ＤＭテキスト出力検索条件クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class PostcardEnvelopeDMTextCndtn
    {
        #region ■ Public Const

        // 出力区分 --------------------------------------------------------------------
        /// <summary>全て</summary>
        public const string ct_OutShipDiv_All = "全て";
        /// <summary>請求有り</summary>
        public const string ct_OutShipDiv_Claim = "請求有り";
        /// <summary>伝票有り</summary>
        public const string ct_OutShipDiv_Slip = "伝票有り";

        //使用マスタ --------------------------------------------------------------------
        /// <summary>得意先マスタ</summary>
        public const string ct_UseMasterDiv_Customer = "得意先マスタ";
        /// <summary>仕入先マスタ</summary>
        public const string ct_UseMasterDiv_Supplier = "仕入先マスタ";
        /// <summary>自社マスタ</summary>
        public const string ct_UseMasterDiv_Company = "自社マスタ";
        /// <summary>拠点マスタ</summary>
        public const string ct_UseMasterDiv_SecInfo = "拠点マスタ";
        #endregion

        #region ■ Private Member
        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>本社機能プロパティ</summary>
        private bool _isMainOfficeFunc;

        /// <summary>拠点コード開始</summary>
        private string _st_SectionCode;

        /// <summary>拠点コード終了</summary>
        private string _ed_SectionCode;

        /// <summary>使用マスタ</summary>
        private int _useMast;

        /// <summary>出力区分</summary>
        private int _outShipDiv;

        /// <summary>締日</summary>
        private DateTime _totalDay;

        /// <summary>対象日付開始日</summary>
        private DateTime _st_AddUpDay;

        /// <summary>対象日付終了日</summary>
        private DateTime _ed_AddUpDay;

        /// <summary>得意先コード開始</summary>
        private Int32 _st_CustomerCode;

        /// <summary>得意先コード終了</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>仕入先コード開始</summary>
        private Int32 _st_SupplierCode;

        /// <summary>仕入先コード終了</summary>
        private Int32 _ed_SupplierCode;

        #endregion ■ Private Member

        #region ■ Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパテ ィ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   企業コードプロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点オプション導入区分プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   本社機能プロパティプロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  St_SectionCode
        /// <summary>拠点コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点コード開始プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public string St_SectionCode
        {
            get { return _st_SectionCode; }
            set { _st_SectionCode = value; }
        }


        /// public propaty name  :  Ed_SectionCode
        /// <summary>拠点コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点コード終了プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public string Ed_SectionCode
        {
            get { return _ed_SectionCode; }
            set { _ed_SectionCode = value; }
        }

        /// public propaty name  :  UseMast
        /// <summary>使用マスタ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   使用マスタプロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public int UseMast
        {
            get { return _useMast; }
            set { _useMast = value; }
        }

        /// public propaty name  :  OutShipDiv
        /// <summary>出力区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   出力区分プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public int OutShipDiv
        {
            get { return _outShipDiv; }
            set { _outShipDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   締日プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public DateTime TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  St_AddUpDay
        /// <summary>対象日付開始日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   対象日付開始日プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public DateTime St_AddUpDay
        {
            get { return _st_AddUpDay; }
            set { _st_AddUpDay = value; }
        }

        /// public propaty name  :  Ed_AddUpDay
        /// <summary>対象日付終了日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   対象日付終了日プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public DateTime Ed_AddUpDay
        {
            get { return _ed_AddUpDay; }
            set { _ed_AddUpDay = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>得意先コード開始</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   得意先コード開始プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  : Ed_CustomerCode
        /// <summary>得意先コード終了</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   得意先コード終了プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  : St_SupplierCode
        /// <summary>仕入先コード開始</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   仕入先コード開始プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public Int32 St_SupplierCode
        {
            get { return _st_SupplierCode; }
            set { _st_SupplierCode = value; }
        }

        /// public propaty name  : Ed_SupplierCode
        /// <summary>仕入先コード終了</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   仕入先コード終了プロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public Int32 Ed_SupplierCode
        {
            get { return _ed_SupplierCode; }
            set { _ed_SupplierCode = value; }
        }

        #endregion ■ Private Property

        #region ■ Public Enum
        #region ◆ 出力区分列挙体
        /// <summary> 出力区分列挙体 </summary>
        public enum OutShipDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>請求有り</summary>
            Claim = 1,
            /// <summary>伝票有り</summary>
            Slip = 2,
        }
        #endregion ◆

        #region ◆ 使用マスタ列挙体
        /// <summary> 使用マスタ列挙体 </summary>
        public enum UseMastDivState
        {
            /// <summary>得意先マスタ</summary>
            Customer = 0,
            /// <summary>仕入先マスタ</summary>
            Supplier = 1,
            /// <summary>自社マスタ</summary>
            Company = 2,
            /// <summary>拠点マスタ</summary>
            SecInfo = 3,
        }
        #endregion ◆
        #endregion ■ Public Enum
    }
}
