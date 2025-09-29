using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   IsolIslandPrcSet
    /// <summary>
    ///                      離島価格マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   離島価格マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class IsolIslandPrcSet 
    {

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>上限金額</summary>
        private Double _upperLimitPrice;

        /// <summary>端数処理単位</summary>
        private Double _fractionProcUnit;

        /// <summary>端数処理区分</summary>
        private Int32 _fractionProcCd;

        /// <summary>UP率</summary>
        private Double _upRate;


        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  UpperLimitPrice
        /// <summary>上限金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上限金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpperLimitPrice
        {
            get { return _upperLimitPrice; }
            set { _upperLimitPrice = value; }
        }

        /// public propaty name  :  FractionProcUnit
        /// <summary>端数処理単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double FractionProcUnit
        {
            get { return _fractionProcUnit; }
            set { _fractionProcUnit = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  UpRate
        /// <summary>UP率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UP率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double UpRate
        {
            get { return _upRate; }
            set { _upRate = value; }
        }

        /// <summary>
        /// 離島価格（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IsolIslandPrcSet Clone()
        {
            return new IsolIslandPrcSet(this._sectionCode, this._sectionGuideSnm, this._makerCode, this._makerShortName, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._upRate);

        }

        /// <summary>
		/// 離島価格（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public IsolIslandPrcSet()
		{
		}
        
        /// <summary>
        /// 離島価格（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="MakerCode"></param>
        /// <param name="MakerShortName"></param>
        /// <param name="UpperLimitPrice"></param>
        /// <param name="FractionProcUnit"></param>
        /// <param name="FractionProcCd"></param>
        /// <param name="UpRate"></param>
        public IsolIslandPrcSet(string SectionCode, string SectionGuideSnm, Int32 MakerCode, string MakerShortName, Double UpperLimitPrice, Double FractionProcUnit, Int32 FractionProcCd, Double UpRate)
        {

            this._sectionCode = SectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._makerCode = MakerCode;
            this._makerShortName = MakerShortName;
            this._upperLimitPrice = UpperLimitPrice;
            this._fractionProcUnit = FractionProcUnit;
            this._fractionProcCd = FractionProcCd;
            this._upRate = UpRate;

        }
    }
}
