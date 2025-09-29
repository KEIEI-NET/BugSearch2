//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表抽出条件クラスワーク
// プログラム概要   : 返品理由一覧表抽出条件クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderSetMasListParaWork
    /// <summary>
    ///                      返品理由一覧表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   返品理由一覧表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/04/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RetGoodsReasonReportParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _sectionCodes;

        /// <summary>対象年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDate;

        /// <summary>前回締処理日</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _prevTotalDay;

        /// <summary>今回締処理日</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _currentTotalDay;

        /// <summary>年度開始日</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _startYearDate;

        /// <summary>年度終了日</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _endYearDate;

        /// <summary>改頁</summary>
        private Int32 _changePageDiv;

        /// <summary>出力順</summary>
        private Int32 _printType;

        /// <summary>開始得意先コード</summary>
        private string _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private string _customerCodeEd;

        /// <summary>開始返品理由コード</summary>
        private string _retGoodsReasonDivSt;

        /// <summary>終了返品理由コード</summary>
        private string _retGoodsReasonDivEd;

        /// <summary>開始担当者コード</summary>
        private string _salesEmployeeCdRFSt;

        /// <summary>終了担当者コード</summary>
        private string _salesEmployeeCdRFEd;

        /// <summary>開始受注者コード</summary>
        private string _frontEmployeeCdRFSt;

        /// <summary>終了受注者コード</summary>
        private string _frontEmployeeCdRFEd;

        /// <summary>開始発行者コード</summary>
        private string _salesInputCdRFSt;

        /// <summary>終了発行者コード</summary>
        private string _salesInputCdRFEd;

        /// <summary>伝票種別</summary>
        private Int32 _slipKindCd;

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
        /// <summary>拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目</value>
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

        /// public propaty name  :  SalesDate
        /// <summary>対象年月</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  PrevTotalDay
        /// <summary>前回締処理日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PrevTotalDay
        {
            get { return _prevTotalDay; }
            set { _prevTotalDay = value; }
        }

        /// public propaty name  :  EndYearDate
        /// <summary>年度終了日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年度終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EndYearDate
        {
            get { return _endYearDate; }
            set { _endYearDate = value; }
        }

        /// public propaty name  :  CurrentTotalDay
        /// <summary>今回締処理日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回締処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CurrentTotalDay
        {
            get { return _currentTotalDay; }
            set { _currentTotalDay = value; }
        }

        /// public propaty name  :  StartYearDate
        /// <summary>年度開始日</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年度開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartYearDate
        {
            get { return _startYearDate; }
            set { _startYearDate = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>改頁</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>発行タイプ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  RetGoodsReasonDivSt
        /// <summary>開始返品理由コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始返品理由コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RetGoodsReasonDivSt
        {
            get { return _retGoodsReasonDivSt; }
            set { _retGoodsReasonDivSt = value; }
        }

        /// public propaty name  :  RetGoodsReasonDivSt
        /// <summary>終了返品理由コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了返品理由コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RetGoodsReasonDivEd
        {
            get { return _retGoodsReasonDivEd; }
            set { _retGoodsReasonDivEd = value; }
        }

        /// public propaty name  :  SalesEmployeeCdRFSt
        /// <summary>開始担当者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始担当者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCdRFSt
        {
            get { return _salesEmployeeCdRFSt; }
            set { _salesEmployeeCdRFSt = value; }
        }

        /// public propaty name  :  SalesEmployeeCdRFEd
        /// <summary>終了担当者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了担当者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCdRFEd
        {
            get { return _salesEmployeeCdRFEd; }
            set { _salesEmployeeCdRFEd = value; }
        }

        /// public propaty name  :  FrontEmployeeCdRFSt
        /// <summary>開始受注者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始受注者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCdRFSt
        {
            get { return _frontEmployeeCdRFSt; }
            set { _frontEmployeeCdRFSt = value; }
        }

        /// public propaty name  :  FrontEmployeeCdRFEd
        /// <summary>終了受注者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了受注者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCdRFEd
        {
            get { return _frontEmployeeCdRFEd; }
            set { _frontEmployeeCdRFEd = value; }
        }

        /// public propaty name  :  SalesInputCdRFSt
        /// <summary>開始発行者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始発行者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCdRFSt
        {
            get { return _salesInputCdRFSt; }
            set { _salesInputCdRFSt = value; }
        }

        /// public propaty name  :  SalesInputCdRFEd
        /// <summary>終了発行者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了発行者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCdRFEd
        {
            get { return _salesInputCdRFEd; }
            set { _salesInputCdRFEd = value; }
        }


        /// public propaty name  :  SlipKindCd
        /// <summary>発行タイプ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipKindCd
        {
            get { return _slipKindCd; }
            set { _slipKindCd = value; }
        }

        /// <summary>
        /// 返品理由一覧表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>RetGoodsReasonReportParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RetGoodsReasonReportParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RetGoodsReasonReportParaWork()
        {
        }
    }
}
