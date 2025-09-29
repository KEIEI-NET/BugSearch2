using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockDayTotalExtractWork
    /// <summary>
    ///                      仕入日計累計表抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入日計累計表抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockDayTotalExtractWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>全社選択</summary>
        /// <remarks>true:全社選択　false:各拠点選択</remarks>
        private Boolean _isSelectAllSection;

        /// <summary>全拠点レコード出力</summary>
        /// <remarks>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</remarks>
        private Boolean _isOutputAllSecRec;

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _sectionCd;

        /// <summary>仕入日(開始)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _stockDateSt;

        /// <summary>仕入日(終了)</summary>
        /// <remarks>YYYYMMDD 未入力時は 0</remarks>
        private Int32 _stockDateEd;

        /// <summary>仕入担当者コード(開始)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _stockAgentCodeSt = "";

        /// <summary>仕入担当者コード(終了)</summary>
        /// <remarks>未入力時は空文字("")</remarks>
        private string _stockAgentCodeEd = "";


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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// <value>true:全社選択　false:各拠点選択</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsSelectAllSection
        {
            get { return _isSelectAllSection; }
            set { _isSelectAllSection = value; }
        }

        /// public propaty name  :  IsOutputAllSecRec
        /// <summary>全拠点レコード出力プロパティ</summary>
        /// <value>true:全拠点レコードを出力する。false:全拠点レコードを出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点レコード出力プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsOutputAllSecRec
        {
            get { return _isOutputAllSecRec; }
            set { _isOutputAllSecRec = value; }
        }

        /// public propaty name  :  SectionCd
        /// <summary>拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCd
        {
            get { return _sectionCd; }
            set { _sectionCd = value; }
        }

        /// public propaty name  :  StockDateSt
        /// <summary>仕入日(開始)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateSt
        {
            get { return _stockDateSt; }
            set { _stockDateSt = value; }
        }

        /// public propaty name  :  StockDateEd
        /// <summary>仕入日(終了)プロパティ</summary>
        /// <value>YYYYMMDD 未入力時は 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDateEd
        {
            get { return _stockDateEd; }
            set { _stockDateEd = value; }
        }

        /// public propaty name  :  StockAgentCodeSt
        /// <summary>仕入担当者コード(開始)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCodeSt
        {
            get { return _stockAgentCodeSt; }
            set { _stockAgentCodeSt = value; }
        }

        /// public propaty name  :  StockAgentCodeEd
        /// <summary>仕入担当者コード(終了)プロパティ</summary>
        /// <value>未入力時は空文字("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCodeEd
        {
            get { return _stockAgentCodeEd; }
            set { _stockAgentCodeEd = value; }
        }

        /// <summary>
        /// 仕入日計累計表抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>StockDayTotalExtractWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockDayTotalExtractWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockDayTotalExtractWork()
        {
        }
    }
}
