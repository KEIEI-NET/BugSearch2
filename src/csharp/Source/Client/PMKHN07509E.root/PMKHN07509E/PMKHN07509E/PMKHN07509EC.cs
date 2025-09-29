using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MailDefaultCar
    /// <summary>
    ///                      メール初期値車両データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   メール初期値車両データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailDefaultCar
    {
        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _carMngCode = "";

        /// <summary>陸運事務所番号</summary>
        private Int32 _numberPlate1Code;

        /// <summary>陸運事務局名称</summary>
        private string _numberPlate1Name = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _numberPlate2 = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _numberPlate3 = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _numberPlate4;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _firstEntryDate;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _makerFullName = "";

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>排ガス記号</summary>
        private string _exhaustGasSign = "";

        /// <summary>シリーズ型式</summary>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        private string _categorySignModel = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>車台型式</summary>
        private string _frameModel = "";

        /// <summary>車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _frameNo = "";

        /// <summary>エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _engineModelNm = "";

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;

        /// <summary>車輌備考</summary>
        private string _carNote = "";


        /// public propaty name  :  CarMngCode
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  NumberPlate1Code
        /// <summary>陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// public propaty name  :  NumberPlate1Name
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// public propaty name  :  NumberPlate2
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// public propaty name  :  NumberPlate3
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
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

        /// public propaty name  :  MakerFullName
        /// <summary>メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerFullName
        {
            get { return _makerFullName; }
            set { _makerFullName = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
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

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
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
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ExhaustGasSign
        /// <summary>排ガス記号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }

        /// public propaty name  :  SeriesModel
        /// <summary>シリーズ型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }

        /// public propaty name  :  CategorySignModel
        /// <summary>型式（類別記号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  FrameModel
        /// <summary>車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameModel
        {
            get { return _frameModel; }
            set { _frameModel = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>車台番号プロパティ</summary>
        /// <value>車検証記載フォーマット対応（ HCR32-100251584 等）</value>
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

        /// public propaty name  :  EngineModelNm
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>エンジン検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>車輌備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }


        /// <summary>
        /// メール初期値車両データコンストラクタ
        /// </summary>
        /// <returns>MailDefaultCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultCarクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailDefaultCar()
        {
        }

        /// <summary>
        /// メール初期値車両データコンストラクタ
        /// </summary>
        /// <param name="carMngCode">車輌管理コード(※PM7での車両管理番号)</param>
        /// <param name="numberPlate1Code">陸運事務所番号</param>
        /// <param name="numberPlate1Name">陸運事務局名称</param>
        /// <param name="numberPlate2">車両登録番号（種別）</param>
        /// <param name="numberPlate3">車両登録番号（カナ）</param>
        /// <param name="numberPlate4">車両登録番号（プレート番号）</param>
        /// <param name="firstEntryDate">初年度(YYYYMM)</param>
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="makerFullName">メーカー全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="modelCode">車種コード(車名コード(翼) 1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="exhaustGasSign">排ガス記号</param>
        /// <param name="seriesModel">シリーズ型式</param>
        /// <param name="categorySignModel">型式（類別記号）</param>
        /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別番号</param>
        /// <param name="frameModel">車台型式</param>
        /// <param name="frameNo">車台番号(車検証記載フォーマット対応（ HCR32-100251584 等）)</param>
        /// <param name="engineModelNm">エンジン型式名称(エンジン検索)</param>
        /// <param name="mileage">車両走行距離</param>
        /// <param name="carNote">車輌備考</param>
        /// <returns>MailDefaultCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultCarクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailDefaultCar(string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, string engineModelNm, Int32 mileage, string carNote)
        {
            this._carMngCode = carMngCode;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this.FirstEntryDate = firstEntryDate;
            this._makerCode = makerCode;
            this._makerFullName = makerFullName;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._modelFullName = modelFullName;
            this._exhaustGasSign = exhaustGasSign;
            this._seriesModel = seriesModel;
            this._categorySignModel = categorySignModel;
            this._fullModel = fullModel;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._frameModel = frameModel;
            this._frameNo = frameNo;
            this._engineModelNm = engineModelNm;
            this._mileage = mileage;
            this._carNote = carNote;

        }

        /// <summary>
        /// メール初期値車両データ複製処理
        /// </summary>
        /// <returns>MailDefaultCarクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいMailDefaultCarクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailDefaultCar Clone()
        {
            return new MailDefaultCar(this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._modelCode, this._modelSubCode, this._modelFullName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._engineModelNm, this._mileage, this._carNote);
        }

        /// <summary>
        /// メール初期値車両データ比較処理
        /// </summary>
        /// <param name="target">比較対象のMailDefaultCarクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultCarクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(MailDefaultCar target)
        {
            return ( ( this.CarMngCode == target.CarMngCode )
                 && ( this.NumberPlate1Code == target.NumberPlate1Code )
                 && ( this.NumberPlate1Name == target.NumberPlate1Name )
                 && ( this.NumberPlate2 == target.NumberPlate2 )
                 && ( this.NumberPlate3 == target.NumberPlate3 )
                 && ( this.NumberPlate4 == target.NumberPlate4 )
                 && ( this.FirstEntryDate == target.FirstEntryDate )
                 && ( this.MakerCode == target.MakerCode )
                 && ( this.MakerFullName == target.MakerFullName )
                 && ( this.ModelCode == target.ModelCode )
                 && ( this.ModelSubCode == target.ModelSubCode )
                 && ( this.ModelFullName == target.ModelFullName )
                 && ( this.ExhaustGasSign == target.ExhaustGasSign )
                 && ( this.SeriesModel == target.SeriesModel )
                 && ( this.CategorySignModel == target.CategorySignModel )
                 && ( this.FullModel == target.FullModel )
                 && ( this.ModelDesignationNo == target.ModelDesignationNo )
                 && ( this.CategoryNo == target.CategoryNo )
                 && ( this.FrameModel == target.FrameModel )
                 && ( this.FrameNo == target.FrameNo )
                 && ( this.EngineModelNm == target.EngineModelNm )
                 && ( this.Mileage == target.Mileage )
                 && ( this.CarNote == target.CarNote ) );
        }

        /// <summary>
        /// メール初期値車両データ比較処理
        /// </summary>
        /// <param name="mailDefaultCar1">
        ///                    比較するMailDefaultCarクラスのインスタンス
        /// </param>
        /// <param name="mailDefaultCar2">比較するMailDefaultCarクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultCarクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(MailDefaultCar mailDefaultCar1, MailDefaultCar mailDefaultCar2)
        {
            return ( ( mailDefaultCar1.CarMngCode == mailDefaultCar2.CarMngCode )
                 && ( mailDefaultCar1.NumberPlate1Code == mailDefaultCar2.NumberPlate1Code )
                 && ( mailDefaultCar1.NumberPlate1Name == mailDefaultCar2.NumberPlate1Name )
                 && ( mailDefaultCar1.NumberPlate2 == mailDefaultCar2.NumberPlate2 )
                 && ( mailDefaultCar1.NumberPlate3 == mailDefaultCar2.NumberPlate3 )
                 && ( mailDefaultCar1.NumberPlate4 == mailDefaultCar2.NumberPlate4 )
                 && ( mailDefaultCar1.FirstEntryDate == mailDefaultCar2.FirstEntryDate )
                 && ( mailDefaultCar1.MakerCode == mailDefaultCar2.MakerCode )
                 && ( mailDefaultCar1.MakerFullName == mailDefaultCar2.MakerFullName )
                 && ( mailDefaultCar1.ModelCode == mailDefaultCar2.ModelCode )
                 && ( mailDefaultCar1.ModelSubCode == mailDefaultCar2.ModelSubCode )
                 && ( mailDefaultCar1.ModelFullName == mailDefaultCar2.ModelFullName )
                 && ( mailDefaultCar1.ExhaustGasSign == mailDefaultCar2.ExhaustGasSign )
                 && ( mailDefaultCar1.SeriesModel == mailDefaultCar2.SeriesModel )
                 && ( mailDefaultCar1.CategorySignModel == mailDefaultCar2.CategorySignModel )
                 && ( mailDefaultCar1.FullModel == mailDefaultCar2.FullModel )
                 && ( mailDefaultCar1.ModelDesignationNo == mailDefaultCar2.ModelDesignationNo )
                 && ( mailDefaultCar1.CategoryNo == mailDefaultCar2.CategoryNo )
                 && ( mailDefaultCar1.FrameModel == mailDefaultCar2.FrameModel )
                 && ( mailDefaultCar1.FrameNo == mailDefaultCar2.FrameNo )
                 && ( mailDefaultCar1.EngineModelNm == mailDefaultCar2.EngineModelNm )
                 && ( mailDefaultCar1.Mileage == mailDefaultCar2.Mileage )
                 && ( mailDefaultCar1.CarNote == mailDefaultCar2.CarNote ) );
        }
        /// <summary>
        /// メール初期値車両データ比較処理
        /// </summary>
        /// <param name="target">比較対象のMailDefaultCarクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultCarクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(MailDefaultCar target)
        {
            ArrayList resList = new ArrayList();
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.FirstEntryDate != target.FirstEntryDate) resList.Add("FirstEntryDate");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.CarNote != target.CarNote) resList.Add("CarNote");

            return resList;
        }

        /// <summary>
        /// メール初期値車両データ比較処理
        /// </summary>
        /// <param name="mailDefaultCar1">比較するMailDefaultCarクラスのインスタンス</param>
        /// <param name="mailDefaultCar2">比較するMailDefaultCarクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailDefaultCarクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(MailDefaultCar mailDefaultCar1, MailDefaultCar mailDefaultCar2)
        {
            ArrayList resList = new ArrayList();
            if (mailDefaultCar1.CarMngCode != mailDefaultCar2.CarMngCode) resList.Add("CarMngCode");
            if (mailDefaultCar1.NumberPlate1Code != mailDefaultCar2.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (mailDefaultCar1.NumberPlate1Name != mailDefaultCar2.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (mailDefaultCar1.NumberPlate2 != mailDefaultCar2.NumberPlate2) resList.Add("NumberPlate2");
            if (mailDefaultCar1.NumberPlate3 != mailDefaultCar2.NumberPlate3) resList.Add("NumberPlate3");
            if (mailDefaultCar1.NumberPlate4 != mailDefaultCar2.NumberPlate4) resList.Add("NumberPlate4");
            if (mailDefaultCar1.FirstEntryDate != mailDefaultCar2.FirstEntryDate) resList.Add("FirstEntryDate");
            if (mailDefaultCar1.MakerCode != mailDefaultCar2.MakerCode) resList.Add("MakerCode");
            if (mailDefaultCar1.MakerFullName != mailDefaultCar2.MakerFullName) resList.Add("MakerFullName");
            if (mailDefaultCar1.ModelCode != mailDefaultCar2.ModelCode) resList.Add("ModelCode");
            if (mailDefaultCar1.ModelSubCode != mailDefaultCar2.ModelSubCode) resList.Add("ModelSubCode");
            if (mailDefaultCar1.ModelFullName != mailDefaultCar2.ModelFullName) resList.Add("ModelFullName");
            if (mailDefaultCar1.ExhaustGasSign != mailDefaultCar2.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (mailDefaultCar1.SeriesModel != mailDefaultCar2.SeriesModel) resList.Add("SeriesModel");
            if (mailDefaultCar1.CategorySignModel != mailDefaultCar2.CategorySignModel) resList.Add("CategorySignModel");
            if (mailDefaultCar1.FullModel != mailDefaultCar2.FullModel) resList.Add("FullModel");
            if (mailDefaultCar1.ModelDesignationNo != mailDefaultCar2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (mailDefaultCar1.CategoryNo != mailDefaultCar2.CategoryNo) resList.Add("CategoryNo");
            if (mailDefaultCar1.FrameModel != mailDefaultCar2.FrameModel) resList.Add("FrameModel");
            if (mailDefaultCar1.FrameNo != mailDefaultCar2.FrameNo) resList.Add("FrameNo");
            if (mailDefaultCar1.EngineModelNm != mailDefaultCar2.EngineModelNm) resList.Add("EngineModelNm");
            if (mailDefaultCar1.Mileage != mailDefaultCar2.Mileage) resList.Add("Mileage");
            if (mailDefaultCar1.CarNote != mailDefaultCar2.CarNote) resList.Add("CarNote");

            return resList;
        }
    }
}
