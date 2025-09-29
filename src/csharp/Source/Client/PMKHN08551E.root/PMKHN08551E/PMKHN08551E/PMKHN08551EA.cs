using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerPrintWork
	/// <summary>
	///                      得意先マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class CustomerPrintWork 
    {
        # region ■ private field ■
        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始カナ</summary>
        private string _kanaSt = "";

        /// <summary>終了カナ</summary>
        private string _kanaEd = "";

        /// <summary>開始拠点</summary>
        private string _mngSectionCodeSt = "";

        /// <summary>終了拠点</summary>
        private string _mngSectionCodeEd = "";

        /// <summary>開始担当者</summary>
        private string _customerAgentCdSt = "";

        /// <summary>終了担当者</summary>
        private string _customerAgentCdEd = "";

        /// <summary>開始地区</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>終了地区</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>開始業種</summary>
        private Int32 _businessTypeCodeSt;

        /// <summary>終了業種</summary>
        private Int32 _businessTypeCodeEd;

        /// <summary>発行タイプ</summary>
        private Int32 _printType;

        /// <summary>ソート順</summary>
        private Int32 _sort;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;


        /// <summary>メーカー名1</summary>
        private string _custRateGrpName01;

        /// <summary>メーカー名2</summary>
        private string _custRateGrpName02;

        /// <summary>メーカー名3</summary>
        private string _custRateGrpName03;

        /// <summary>メーカー名4</summary>
        private string _custRateGrpName04;

        /// <summary>メーカー名5</summary>
        private string _custRateGrpName05;

        /// <summary>メーカー名6</summary>
        private string _custRateGrpName06;

        /// <summary>メーカー名7</summary>
        private string _custRateGrpName07;

        /// <summary>メーカー名8</summary>
        private string _custRateGrpName08;

        /// <summary>メーカー名9</summary>
        private string _custRateGrpName09;

        /// <summary>メーカー名10</summary>
        private string _custRateGrpName10;

        /// <summary>メーカー名11</summary>
        private string _custRateGrpName11;

        /// <summary>メーカー名12</summary>
        private string _custRateGrpName12;

        /// <summary>メーカー名13</summary>
        private string _custRateGrpName13;

        /// <summary>メーカー名14</summary>
        private string _custRateGrpName14;

        /// <summary>メーカー名15</summary>
        private string _custRateGrpName15;

        /// <summary>メーカー名16</summary>
        private string _custRateGrpName16;

        /// <summary>メーカー名17</summary>
        private string _custRateGrpName17;

        /// <summary>メーカー名18</summary>
        private string _custRateGrpName18;

        /// <summary>メーカー名19</summary>
        private string _custRateGrpName19;

        /// <summary>メーカー名20</summary>
        private string _custRateGrpName20;

        /// <summary>メーカー名21</summary>
        private string _custRateGrpName21;

        /// <summary>メーカー名22</summary>
        private string _custRateGrpName22;

        /// <summary>メーカー名23</summary>
        private string _custRateGrpName23;

        /// <summary>メーカー名24</summary>
        private string _custRateGrpName24;

        /// <summary>メーカー名25</summary>
        private string _custRateGrpName25;
        # endregion  ■ private field ■

        # region ■ public propaty ■
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

        /// public propaty name  :  KanaSt
        /// <summary>開始カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KanaSt
        {
            get { return _kanaSt; }
            set { _kanaSt = value; }
        }

        /// public propaty name  :  KanaEd
        /// <summary>終了カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KanaEd
        {
            get { return _kanaEd; }
            set { _kanaEd = value; }
        }

        /// public propaty name  :  MngSectionCodeSt
        /// <summary>開始拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCodeSt
        {
            get { return _mngSectionCodeSt; }
            set { _mngSectionCodeSt = value; }
        }

        /// public propaty name  :  MngSectionCodeEd
        /// <summary>終了拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCodeEd
        {
            get { return _mngSectionCodeEd; }
            set { _mngSectionCodeEd = value; }
        }

        /// public propaty name  :  CustomerAgentCdSt
        /// <summary>開始担当者プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCdSt
        {
            get { return _customerAgentCdSt; }
            set { _customerAgentCdSt = value; }
        }

        /// public propaty name  :  CustomerAgentCdEd
        /// <summary>終了担当者プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCdEd
        {
            get { return _customerAgentCdEd; }
            set { _customerAgentCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>開始地区プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始地区プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>終了地区プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了地区プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  BusinessTypeCodeSt
        /// <summary>開始業種プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始業種プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeSt
        {
            get { return _businessTypeCodeSt; }
            set { _businessTypeCodeSt = value; }
        }

        /// public propaty name  :  BusinessTypeCodeEd
        /// <summary>終了業種プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了業種プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeEd
        {
            get { return _businessTypeCodeEd; }
            set { _businessTypeCodeEd = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>発行タイププロパティ</summary>
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

        /// public propaty name  :  Sort
        /// <summary>ソート順プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ソート順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Sort
        {
            get { return _sort; }
            set { _sort = value; }
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



        /// public propaty name  :  CustRateGrpName01					
        /// <summary>メーカー名1</summary>					
        /// ----------------------------------------------------------------------					
        /// <remarks>					
        /// <br>note     :   メーカー名1プロパティ</br>					
        /// <br>Programer:   自動生成</br>					
        /// </remarks>					
        public string CustRateGrpName01
        {
            get { return _custRateGrpName01; }
            set { _custRateGrpName01 = value; }
        }

        /// public propaty name  :  CustRateGrpName02				
        /// <summary>メーカー名2</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名2プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName02
        {
            get { return _custRateGrpName02; }
            set { _custRateGrpName02 = value; }
        }

        /// public propaty name  :  CustRateGrpName03			
        /// <summary>メーカー名3</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名3プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName03
        {
            get { return _custRateGrpName03; }
            set { _custRateGrpName03 = value; }
        }

        /// public propaty name  :  CustRateGrpName04				
        /// <summary>メーカー名4</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名4プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName04
        {
            get { return _custRateGrpName04; }
            set { _custRateGrpName04 = value; }
        }

        /// public propaty name  :  CustRateGrpName05			
        /// <summary>メーカー名5</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名5プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName05
        {
            get { return _custRateGrpName05; }
            set { _custRateGrpName05 = value; }
        }

        /// public propaty name  :  CustRateGrpName06			
        /// <summary>メーカー名6</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名6プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName06
        {
            get { return _custRateGrpName06; }
            set { _custRateGrpName06 = value; }
        }

        /// public propaty name  :  CustRateGrpName07			
        /// <summary>メーカー名7</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名7プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName07
        {
            get { return _custRateGrpName07; }
            set { _custRateGrpName07 = value; }
        }

        /// public propaty name  :  CustRateGrpName08				
        /// <summary>メーカー名8</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名8プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName08
        {
            get { return _custRateGrpName08; }
            set { _custRateGrpName08 = value; }
        }

        /// public propaty name  :  CustRateGrpName09		
        /// <summary>メーカー名9</summary>		
        /// ----------------------------------------------------------------------		
        /// <remarks>		
        /// <br>note     :   メーカー名9プロパティ</br>		
        /// <br>Programer:   自動生成</br>		
        /// </remarks>		
        public string CustRateGrpName09
        {
            get { return _custRateGrpName09; }
            set { _custRateGrpName09 = value; }
        }

        /// public propaty name  :  CustRateGrpName10				
        /// <summary>メーカー名10</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名10プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName10
        {
            get { return _custRateGrpName10; }
            set { _custRateGrpName10 = value; }
        }

        /// public propaty name  :  CustRateGrpName11			
        /// <summary>メーカー名11</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名11プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName11
        {
            get { return _custRateGrpName11; }
            set { _custRateGrpName11 = value; }
        }

        /// public propaty name  :  CustRateGrpName12			
        /// <summary>メーカー名12</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名12プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName12
        {
            get { return _custRateGrpName12; }
            set { _custRateGrpName12 = value; }
        }

        /// public propaty name  :  CustRateGrpName13					
        /// <summary>メーカー名13</summary>					
        /// ----------------------------------------------------------------------					
        /// <remarks>					
        /// <br>note     :   メーカー名13プロパティ</br>					
        /// <br>Programer:   自動生成</br>					
        /// </remarks>					
        public string CustRateGrpName13
        {
            get { return _custRateGrpName13; }
            set { _custRateGrpName13 = value; }
        }

        /// public propaty name  :  CustRateGrpName14			
        /// <summary>メーカー名14</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名14プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName14
        {
            get { return _custRateGrpName14; }
            set { _custRateGrpName14 = value; }
        }

        /// public propaty name  :  CustRateGrpName15			
        /// <summary>メーカー名15</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名15プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName15
        {
            get { return _custRateGrpName15; }
            set { _custRateGrpName15 = value; }
        }

        /// public propaty name  :  CustRateGrpName16			
        /// <summary>メーカー名16</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名16プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName16
        {
            get { return _custRateGrpName16; }
            set { _custRateGrpName16 = value; }
        }

        /// public propaty name  :  CustRateGrpName17				
        /// <summary>メーカー名17</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名17プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName17
        {
            get { return _custRateGrpName17; }
            set { _custRateGrpName17 = value; }
        }

        /// public propaty name  :  CustRateGrpName18			
        /// <summary>メーカー名18</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名18プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName18
        {
            get { return _custRateGrpName18; }
            set { _custRateGrpName18 = value; }
        }

        /// public propaty name  :  CustRateGrpName19		
        /// <summary>メーカー名19</summary>		
        /// ----------------------------------------------------------------------		
        /// <remarks>		
        /// <br>note     :   メーカー名19プロパティ</br>		
        /// <br>Programer:   自動生成</br>		
        /// </remarks>		
        public string CustRateGrpName19
        {
            get { return _custRateGrpName19; }
            set { _custRateGrpName19 = value; }
        }

        /// public propaty name  :  CustRateGrpName20				
        /// <summary>メーカー名20</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名20プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName20
        {
            get { return _custRateGrpName20; }
            set { _custRateGrpName20 = value; }
        }

        /// public propaty name  :  CustRateGrpName21			
        /// <summary>メーカー名21</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名21プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName21
        {
            get { return _custRateGrpName21; }
            set { _custRateGrpName21 = value; }
        }

        /// public propaty name  :  CustRateGrpName22			
        /// <summary>メーカー名22</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名22プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName22
        {
            get { return _custRateGrpName22; }
            set { _custRateGrpName22 = value; }
        }

        /// public propaty name  :  CustRateGrpName23			
        /// <summary>メーカー名23</summary>			
        /// ----------------------------------------------------------------------			
        /// <remarks>			
        /// <br>note     :   メーカー名23プロパティ</br>			
        /// <br>Programer:   自動生成</br>			
        /// </remarks>			
        public string CustRateGrpName23
        {
            get { return _custRateGrpName23; }
            set { _custRateGrpName23 = value; }
        }

        /// public propaty name  :  CustRateGrpName24				
        /// <summary>メーカー名24</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名24プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName24
        {
            get { return _custRateGrpName24; }
            set { _custRateGrpName24 = value; }
        }

        /// public propaty name  :  CustRateGrpName25				
        /// <summary>メーカー名25</summary>				
        /// ----------------------------------------------------------------------				
        /// <remarks>				
        /// <br>note     :   メーカー名25プロパティ</br>				
        /// <br>Programer:   自動生成</br>				
        /// </remarks>				
        public string CustRateGrpName25
        {
            get { return _custRateGrpName25; }
            set { _custRateGrpName25 = value; }
        }	
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 得意先マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>CustomerPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerPrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
