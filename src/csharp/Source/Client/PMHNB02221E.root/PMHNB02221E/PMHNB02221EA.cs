//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上不整合確認表
// プログラム概要   : 売上不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/10  修正内容 : 新規作成
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
    /// 売上不整合確認表抽出条件データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note             :   売上不整合確認表抽出条件データクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer       :   汪千来</br>
    /// <br>Date             :   2009.04.13</br>
    /// </remarks>
    public class SalesStockInfoMainCndtn
    {

        #region ■ Public Const
        /// <summary>共通 日付フォーマット yyyyMMdd </summary>
        public const string ct_DateFomat = "yyyyMMdd";
        /// <summary>共通 日付フォーマット yyyy/MM/dd</summary>
        public const string ct_DateFomatWithLine = "yyyy/MM/dd";
        /// <summary>共通 TOP</summary>
        public const string ct_Top = "TOP";
        /// <summary>共通 END</summary>
        public const string ct_End = "END";
        #endregion

        #region ■ Private Member
        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>本社機能プロパティ</summary>
        private bool _isMainOfficeFunc;

        /// <summary>選択計上拠点コード</summary>
        private string[] _collectAddupSecCodeList;


        /// <summary>対象年月</summary>
        private DateTime _yearMonth;

        /// <summary>前回締処理日</summary>
        private DateTime _prevTotalDay;

        /// <summary>今回締処理日</summary>
        private DateTime _currentTotalDay;


        #endregion ■ Private Member

        #region ■ Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   企業コードプロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
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
        /// <br>Programer        :   汪千来</br>
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
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }




        /// public propaty name  :  St_ShipmentFixDay
        /// <summary>対象年月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   対象年月プロパティを行います。</br>
        /// <br>Programer        :   汪千来</br> 
        /// </remarks>
        public DateTime YearMonth
        {
            get { return _yearMonth; }
            set { _yearMonth = value; }
        }

        /// public propaty name  :  PrevTotalDay
        /// <summary>前回締処理日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   前回締処理日プロパティを行います。</br>
        /// <br>Programer        :   汪千来</br> 
        /// </remarks>
        public DateTime PrevTotalDay
        {
            get { return _prevTotalDay; }
            set { _prevTotalDay = value; }
        }

        /// public propaty name  :  CurrentTotalDay
        /// <summary>今回締処理日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   今回締処理日プロパティを行います。</br>
        /// <br>Programer        :   汪千来</br> 
        /// </remarks>
        public DateTime CurrentTotalDay
        {
            get { return _currentTotalDay; }
            set { _currentTotalDay = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   全社選択プロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._collectAddupSecCodeList.Length == 1) && (this._collectAddupSecCodeList[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  CollectAddupSecCodeList
        /// <summary>選択計上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   選択計上拠点コードプロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public string[] CollectAddupSecCodeList
        {
            get { return _collectAddupSecCodeList; }
            set { _collectAddupSecCodeList = value; }
        }


        #endregion ■ Public Property


        #region ■ Constructor
        /// <summary>
        /// ワークコンストラクタ
        /// </summary>
        /// <returns>PaymentMainCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentMainCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public SalesStockInfoMainCndtn()
        {
            this._collectAddupSecCodeList = new string[0];	// 計上拠点コードリスト 
        }
        #endregion ■ Constructor

    }
}
