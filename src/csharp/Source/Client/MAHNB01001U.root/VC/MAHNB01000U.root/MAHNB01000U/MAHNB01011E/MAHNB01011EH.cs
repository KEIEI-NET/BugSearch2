using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region
    /// <summary>
    /// 車両情報を表示用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両情報を表示用です。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2014/09/01</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CarInfoThreadData
    {
        /// <summary>類別</summary>
        private Int32 _modelDesignationNo;
        /// <summary>番号</summary>
        private Int32 _categoryNo;
        /// <summary>国産／外車区分</summary>
        private Int32 _frameNoKubun;
        /// <summary>年式</summary>
        private Int32 _firstEntryDate;
        /// <summary>年式区分</summary>
        private Int32 _firstEntryDateKubun;
        /// <summary>メーカー</summary>
        private Int32 _makerCode;
        /// <summary>車種コード</summary>
        private Int32 _modelCode;
        /// <summary>車種サブコード</summary>
        private Int32 _modelSubCode;
        /// <summary>車種名</summary>
        private string _modelFullName = string.Empty;
        /// <summary>型式</summary>
        private string _fullModel = string.Empty;
        /// <summary>備考</summary>
        private string _note = string.Empty;
        /// <summary>車台番号</summary>
        private string _frameNo = string.Empty;
        /// <summary>画面元</summary>
        private string _pgid = string.Empty;
        /// <summary>年式(SF)</summary>
        private Int32 _firstEntryDateSF;
        /// <summary>車台番号(SF)</summary>
        private string _frameNoSF = string.Empty;
        /// <summary>シャシー№(SF)</summary>
        private string _chassisNoSF = string.Empty;
        /// <summary>車検証型式(SF)</summary>
        private string _carInspectCertModelSF = string.Empty;
        /// <summary>類別</summary>
        private Int32 _modelDesignationNoSF;
        /// <summary>番号</summary>
        private Int32 _categoryNoSF;
        /// <summary>メーカー</summary>
        private Int32 _makerCodeSF;
        /// <summary>車種コード</summary>
        private Int32 _modelCodeSF;
        /// <summary>車種サブコード</summary>
        private Int32 _modelSubCodeSF;
        /// <summary>車種名</summary>
        private string _modelFullNameSF = string.Empty;

        /// public propaty name  :  ModelDesignationNo
        /// <summary>類別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  FrameNoKubun
        /// <summary>国産／外車区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   国産／外車区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FrameNoKubun
        {
            get { return _frameNoKubun; }
            set { _frameNoKubun = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>年式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  FirstEntryDateKubun
        /// <summary>年式区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年式区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FirstEntryDateKubun
        {
            get { return _firstEntryDateKubun; }
            set { _firstEntryDateKubun = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカープロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカープロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>車種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>車種サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  Note
        /// <summary>備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  Pgid
        /// <summary>画面元プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画面元プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Pgid
        {
            get { return _pgid; }
            set { _pgid = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>年式(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   年式(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FirstEntryDateSF
        {
            get { return _firstEntryDateSF; }
            set { _firstEntryDateSF = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>車台番号(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameNoSF
        {
            get { return _frameNoSF; }
            set { _frameNoSF = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>シャシー№(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シャシー№(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChassisNoSF
        {
            get { return _chassisNoSF; }
            set { _chassisNoSF = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarInspectCertModelSF
        {
            get { return _carInspectCertModelSF; }
            set { _carInspectCertModelSF = value; }
        }

        /// public propaty name  :  ModelDesignationNoSF
        /// <summary>類別(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNoSF
        {
            get { return _modelDesignationNoSF; }
            set { _modelDesignationNoSF = value; }
        }

        /// public propaty name  :  CategoryNoSF
        /// <summary>番号(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNoSF
        {
            get { return _categoryNoSF; }
            set { _categoryNoSF = value; }
        }

        /// public propaty name  :  MakerCodeSF
        /// <summary>メーカー(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCodeSF
        {
            get { return _makerCodeSF; }
            set { _makerCodeSF = value; }
        }

        /// public propaty name  :  ModelCodeSF
        /// <summary>車種コード(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCodeSF
        {
            get { return _modelCodeSF; }
            set { _modelCodeSF = value; }
        }

        /// public propaty name  :  ModelSubCodeSF
        /// <summary>車種サブコード(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコード(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCodeSF
        {
            get { return _modelSubCodeSF; }
            set { _modelSubCodeSF = value; }
        }

        /// public propaty name  :  ModelFullNameSF
        /// <summary>車種名(SF)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名(SF)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullNameSF
        {
            get { return _modelFullNameSF; }
            set { _modelFullNameSF = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CarInfoThreadData()
        {
        }
    }
    # endregion

}
