//*************************************************************************************//
// System			:	Partsman									                   //
// Sub System       :				     								               //
// Program name     :	画面入力クラス					　　　　　　                   //
//					:	PMSCM01211E.DLL									               //
// Name Space		:	Broadleaf.Application.UIData							       //
// Programmer		:	高影										                   //
// Date				:	2011.07.31	                                                   //
//                                                                                     //
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpDisplay
    /// <summary>
    ///                      画面入力クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   画面入力クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/12</br>
    /// <br>Genarated Date   :   2011/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpDisplay
    {
        /// <summary>売上日From</summary>
        private DateTime _salesDateSt;

        /// <summary>売上日To</summary>
        private DateTime _salesDateEd;

        /// <summary>入力日From</summary>
        private DateTime _inpDateSt;

        /// <summary>入力日To</summary>
        private DateTime _inpDateEd;

        /// <summary>拠点From</summary>
        private string _sectionCodeSt = "";

        /// <summary>拠点From名称</summary>
        private string _sectionNameSt = "";

        /// <summary>拠点To</summary>
        private string _sectionCodeEd = "";

        /// <summary>拠点To名称</summary>
        private string _sectionNameEd = "";

        /// <summary>得意先From</summary>
        private Int32 _customerCodeSt;

        /// <summary>得意先From名称</summary>
        private string _customerNameSt = "";

        /// <summary>得意先To</summary>
        private Int32 _customerCodeEd;

        /// <summary>得意先To名称</summary>
        private string _customerNameEd = "";

        /// <summary>伝票番号From</summary>
        private Int32 _slipNoSt;

        /// <summary>伝票番号To</summary>
        private Int32 _slipNoEd;

        /// <summary>テキスト格納フォルダ</summary>
        private string _textSaveFolder = "";

        /// <summary>出力件数</summary>
        private Int32 _outpCount;


        /// public propaty name  :  SalesDateSt
        /// <summary>売上日Fromプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日Fromプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>売上日Toプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日Toプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  InpDateSt
        /// <summary>入力日Fromプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日Fromプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InpDateSt
        {
            get { return _inpDateSt; }
            set { _inpDateSt = value; }
        }

        /// public propaty name  :  InpDateEd
        /// <summary>入力日Toプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日Toプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InpDateEd
        {
            get { return _inpDateEd; }
            set { _inpDateEd = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>拠点Fromプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点Fromプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionNameSt
        /// <summary>拠点From名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点From名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionNameSt
        {
            get { return _sectionNameSt; }
            set { _sectionNameSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>拠点Toプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点Toプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SectionNameEd
        /// <summary>拠点To名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点To名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionNameEd
        {
            get { return _sectionNameEd; }
            set { _sectionNameEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>得意先Fromプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先Fromプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerNameSt
        /// <summary>得意先From名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先From名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerNameSt
        {
            get { return _customerNameSt; }
            set { _customerNameSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>得意先Toプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先Toプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  CustomerNameEd
        /// <summary>得意先To名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先To名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerNameEd
        {
            get { return _customerNameEd; }
            set { _customerNameEd = value; }
        }

        /// public propaty name  :  SlipNoSt
        /// <summary>伝票番号Fromプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号Fromプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNoSt
        {
            get { return _slipNoSt; }
            set { _slipNoSt = value; }
        }

        /// public propaty name  :  SlipNoEd
        /// <summary>伝票番号Toプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号Toプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNoEd
        {
            get { return _slipNoEd; }
            set { _slipNoEd = value; }
        }

        /// public propaty name  :  TextSaveFolder
        /// <summary>テキスト格納フォルダプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   テキスト格納フォルダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TextSaveFolder
        {
            get { return _textSaveFolder; }
            set { _textSaveFolder = value; }
        }

        /// public propaty name  :  OutpCount
        /// <summary>出力件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutpCount
        {
            get { return _outpCount; }
            set { _outpCount = value; }
        }


        /// <summary>
        /// 画面入力クラスコンストラクタ
        /// </summary>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay()
        {
        }

        /// <summary>
        /// 画面入力クラスコンストラクタ
        /// </summary>
        /// <param name="salesDateSt">売上日From</param>
        /// <param name="salesDateEd">売上日To</param>
        /// <param name="inpDateSt">入力日From</param>
        /// <param name="inpDateEd">入力日To</param>
        /// <param name="sectionCodeSt">拠点From</param>
        /// <param name="sectionNameSt">拠点From名称</param>
        /// <param name="sectionCodeEd">拠点To</param>
        /// <param name="sectionNameEd">拠点To名称</param>
        /// <param name="customerCodeSt">得意先From</param>
        /// <param name="customerNameSt">得意先From名称</param>
        /// <param name="customerCodeEd">得意先To</param>
        /// <param name="customerNameEd">得意先To名称</param>
        /// <param name="slipNoSt">伝票番号From</param>
        /// <param name="slipNoEd">伝票番号To</param>
        /// <param name="textSaveFolder">テキスト格納フォルダ</param>
        /// <param name="outpCount">出力件数</param>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay(DateTime salesDateSt, DateTime salesDateEd, DateTime inpDateSt, DateTime inpDateEd, string sectionCodeSt, string sectionNameSt, string sectionCodeEd, string sectionNameEd, Int32 customerCodeSt, string customerNameSt, Int32 customerCodeEd, string customerNameEd, Int32 slipNoSt, Int32 slipNoEd, string textSaveFolder, Int32 outpCount)
        {
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._inpDateSt = inpDateSt;
            this._inpDateEd = inpDateEd;
            this._sectionCodeSt = sectionCodeSt;
            this._sectionNameSt = sectionNameSt;
            this._sectionCodeEd = sectionCodeEd;
            this._sectionNameEd = sectionNameEd;
            this._customerCodeSt = customerCodeSt;
            this._customerNameSt = customerNameSt;
            this._customerCodeEd = customerCodeEd;
            this._customerNameEd = customerNameEd;
            this._slipNoSt = slipNoSt;
            this._slipNoEd = slipNoEd;
            this._textSaveFolder = textSaveFolder;
            this._outpCount = outpCount;

        }

        /// <summary>
        /// 画面入力クラス複製処理
        /// </summary>
        /// <returns>InpDisplayクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいInpDisplayクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InpDisplay Clone()
        {
            return new InpDisplay(this._salesDateSt, this._salesDateEd, this._inpDateSt, this._inpDateEd, this._sectionCodeSt, this._sectionNameSt, this._sectionCodeEd, this._sectionNameEd, this._customerCodeSt, this._customerNameSt, this._customerCodeEd, this._customerNameEd, this._slipNoSt, this._slipNoEd, this._textSaveFolder, this._outpCount);
        }

        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のInpDisplayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(InpDisplay target)
        {
            return ((this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.InpDateSt == target.InpDateSt)
                 && (this.InpDateEd == target.InpDateEd)
                 && (this.SectionCodeSt == target.SectionCodeSt)
                 && (this.SectionNameSt == target.SectionNameSt)
                 && (this.SectionCodeEd == target.SectionCodeEd)
                 && (this.SectionNameEd == target.SectionNameEd)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
                 && (this.CustomerNameSt == target.CustomerNameSt)
                 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.CustomerNameEd == target.CustomerNameEd)
                 && (this.SlipNoSt == target.SlipNoSt)
                 && (this.SlipNoEd == target.SlipNoEd)
                 && (this.TextSaveFolder == target.TextSaveFolder)
                 && (this.OutpCount == target.OutpCount));
        }

        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="inpDisplay1">
        ///                    比較するInpDisplayクラスのインスタンス
        /// </param>
        /// <param name="inpDisplay2">比較するInpDisplayクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            return ((inpDisplay1.SalesDateSt == inpDisplay2.SalesDateSt)
                 && (inpDisplay1.SalesDateEd == inpDisplay2.SalesDateEd)
                 && (inpDisplay1.InpDateSt == inpDisplay2.InpDateSt)
                 && (inpDisplay1.InpDateEd == inpDisplay2.InpDateEd)
                 && (inpDisplay1.SectionCodeSt == inpDisplay2.SectionCodeSt)
                 && (inpDisplay1.SectionNameSt == inpDisplay2.SectionNameSt)
                 && (inpDisplay1.SectionCodeEd == inpDisplay2.SectionCodeEd)
                 && (inpDisplay1.SectionNameEd == inpDisplay2.SectionNameEd)
                 && (inpDisplay1.CustomerCodeSt == inpDisplay2.CustomerCodeSt)
                 && (inpDisplay1.CustomerNameSt == inpDisplay2.CustomerNameSt)
                 && (inpDisplay1.CustomerCodeEd == inpDisplay2.CustomerCodeEd)
                 && (inpDisplay1.CustomerNameEd == inpDisplay2.CustomerNameEd)
                 && (inpDisplay1.SlipNoSt == inpDisplay2.SlipNoSt)
                 && (inpDisplay1.SlipNoEd == inpDisplay2.SlipNoEd)
                 && (inpDisplay1.TextSaveFolder == inpDisplay2.TextSaveFolder)
                 && (inpDisplay1.OutpCount == inpDisplay2.OutpCount));
        }
        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のInpDisplayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(InpDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.InpDateSt != target.InpDateSt) resList.Add("InpDateSt");
            if (this.InpDateEd != target.InpDateEd) resList.Add("InpDateEd");
            if (this.SectionCodeSt != target.SectionCodeSt) resList.Add("SectionCodeSt");
            if (this.SectionNameSt != target.SectionNameSt) resList.Add("SectionNameSt");
            if (this.SectionCodeEd != target.SectionCodeEd) resList.Add("SectionCodeEd");
            if (this.SectionNameEd != target.SectionNameEd) resList.Add("SectionNameEd");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (this.CustomerNameSt != target.CustomerNameSt) resList.Add("CustomerNameSt");
            if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (this.CustomerNameEd != target.CustomerNameEd) resList.Add("CustomerNameEd");
            if (this.SlipNoSt != target.SlipNoSt) resList.Add("SlipNoSt");
            if (this.SlipNoEd != target.SlipNoEd) resList.Add("SlipNoEd");
            if (this.TextSaveFolder != target.TextSaveFolder) resList.Add("TextSaveFolder");
            if (this.OutpCount != target.OutpCount) resList.Add("OutpCount");

            return resList;
        }

        /// <summary>
        /// 画面入力クラス比較処理
        /// </summary>
        /// <param name="inpDisplay1">比較するInpDisplayクラスのインスタンス</param>
        /// <param name="inpDisplay2">比較するInpDisplayクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InpDisplayクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpDisplay1.SalesDateSt != inpDisplay2.SalesDateSt) resList.Add("SalesDateSt");
            if (inpDisplay1.SalesDateEd != inpDisplay2.SalesDateEd) resList.Add("SalesDateEd");
            if (inpDisplay1.InpDateSt != inpDisplay2.InpDateSt) resList.Add("InpDateSt");
            if (inpDisplay1.InpDateEd != inpDisplay2.InpDateEd) resList.Add("InpDateEd");
            if (inpDisplay1.SectionCodeSt != inpDisplay2.SectionCodeSt) resList.Add("SectionCodeSt");
            if (inpDisplay1.SectionNameSt != inpDisplay2.SectionNameSt) resList.Add("SectionNameSt");
            if (inpDisplay1.SectionCodeEd != inpDisplay2.SectionCodeEd) resList.Add("SectionCodeEd");
            if (inpDisplay1.SectionNameEd != inpDisplay2.SectionNameEd) resList.Add("SectionNameEd");
            if (inpDisplay1.CustomerCodeSt != inpDisplay2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (inpDisplay1.CustomerNameSt != inpDisplay2.CustomerNameSt) resList.Add("CustomerNameSt");
            if (inpDisplay1.CustomerCodeEd != inpDisplay2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (inpDisplay1.CustomerNameEd != inpDisplay2.CustomerNameEd) resList.Add("CustomerNameEd");
            if (inpDisplay1.SlipNoSt != inpDisplay2.SlipNoSt) resList.Add("SlipNoSt");
            if (inpDisplay1.SlipNoEd != inpDisplay2.SlipNoEd) resList.Add("SlipNoEd");
            if (inpDisplay1.TextSaveFolder != inpDisplay2.TextSaveFolder) resList.Add("TextSaveFolder");
            if (inpDisplay1.OutpCount != inpDisplay2.OutpCount) resList.Add("OutpCount");

            return resList;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                