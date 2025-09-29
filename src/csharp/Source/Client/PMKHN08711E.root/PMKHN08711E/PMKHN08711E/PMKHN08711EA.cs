//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignTargetPrintWork
    /// <summary>
    ///                      キャンペーン目標設定マスタマスタ（印刷）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン目標設定マスタマスタ（印刷）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignTargetPrintWork
    {
        # region ■ private field ■
        /// <summary>印刷パターン</summary>
        /// <remarks>0:拠点 1:拠点-得意先 2:拠点-担当者 3:拠点-受注者 4:拠点-発行者 5:拠点-地区 6:拠点-グループコード 7:拠点-ＢＬコード 8:拠点-販売区分 </remarks>
        private Int32 _printType;

        /// <summary>開始キャンペーンコード</summary>
        private Int32 _campaignCodeSt;

        /// <summary>終了キャンペーンコード</summary>
        private Int32 _campaignCodeEd;

        /// <summary>開始拠点コード</summary>
        private string _sectionCodeSt = "";

        /// <summary>終了拠点コード</summary>
        private string _sectionCodeEd = "";

        /// <summary>開始ＢＬコード</summary>
        private Int32 _blGoodsCdSt;

        /// <summary>終了ＢＬコード</summary>
        private Int32 _blGoodsCdEd;

        /// <summary>開始従業員コード</summary>
        private string _employeeCodeSt = "";

        /// <summary>終了従業員コード</summary>
        private string _employeeCodeEd = "";

        /// <summary>開始販売区分コード</summary>
        private Int32 _salesCodeSt;

        /// <summary>終了販売区分コード</summary>
        private Int32 _salesCodeEd;

        /// <summary>開始グループコード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _blGroupCodeSt;

        /// <summary>終了グループコード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _blGroupCodeEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始販売エリアコード</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>終了販売エリアコード</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        /// <summary>従業員区分</summary>
        /// <remarks>10:販売担当者 20:受付担当者 30:入力担当者</remarks>
        private Int32 _employeeDivCd;

        /// <summary>期首月</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _startMonth;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  PrintType
        /// <summary>印刷パターンプロパティ</summary>
        /// <value>0:拠点 1:拠点-部門 2:拠点-担当者 3:拠点-受注者 4:拠点-発行者 5:拠点-販売区分 6:拠点-商品区分 7:拠点-得意先 8:拠点-業種 9:拠点-地区</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  BlGoodsCdSt
        /// <summary>開始ＢＬコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ＢＬコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGoodsCdSt
        {
            get { return _blGoodsCdSt; }
            set { _blGoodsCdSt = value; }
        }

        /// public propaty name  :  BlGoodsCdEd
        /// <summary>終了ＢＬコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ＢＬコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGoodsCdEd
        {
            get { return _blGoodsCdEd; }
            set { _blGoodsCdEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>開始従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>終了従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>開始販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>終了販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        /// public propaty name  :  BlGroupCodeSt
        /// <summary>開始グループコードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGroupCodeSt
        {
            get { return _blGroupCodeSt; }
            set { _blGroupCodeSt = value; }
        }

        /// public propaty name  :  BlGroupCodeEd
        /// <summary>終了グループコードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BlGroupCodeEd
        {
            get { return _blGroupCodeEd; }
            set { _blGroupCodeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
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
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }


        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>開始販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>終了販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除指定区分プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>開始削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>終了削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }


        /// public propaty name  :  EmployeeDivCd
        /// <summary>従業員区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
        }


        /// public propaty name  :  CampaignCodeSt
        /// <summary>開始キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCodeSt
        {
            get { return _campaignCodeSt; }
            set { _campaignCodeSt = value; }
        }

        /// public propaty name  :  CampaignCodeEd
        /// <summary>終了キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCodeEd
        {
            get { return _campaignCodeEd; }
            set { _campaignCodeEd = value; }
        }

        /// public propaty name  :  StartMonth
        /// <summary>期首月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期首月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartMonth
        {
            get { return _startMonth; }
            set { _startMonth = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// キャンペーン目標設定マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>CampaignTargetPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignTargetPrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignTargetPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
