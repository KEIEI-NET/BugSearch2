using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferPrimeBlSearchCondWork
    /// <summary>
    ///                      優良ＢＬコード検索条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良ＢＬコード検索条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/06/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferPrimeBlSearchCondWork
    {
        /// <summary>BLコード</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>車メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>シリーズ型式</summary>
        /// <remarks>型式１</remarks>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        private List<string> _categorySignModel = new List<string>();

        /// <summary>開始生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private List<Int32> _stProduceTypeOfYear = new List<int>();

        /// <summary>終了生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private List<Int32> _edProduceTypeOfYear = new List<int>();

        /// <summary>生産年式</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _ProduceTypeOfYear = 0;

        /// <summary>生産車台番号開始</summary>
        private List<Int32> _stProduceFrameNo = new List<int>();

        /// <summary>生産車台番号終了</summary>
        private List<Int32> _edProduceFrameNo = new List<int>();

        /// <summary>生産車台番号</summary>
        private Int32 _ProduceFrameNo = 0;

        /// <summary>型式グレード名称</summary>
        private List<string> _modelGradeNm = new List<string>();

        /// <summary>ボディー名称</summary>
        private List<string> _bodyName = new List<string>();

        /// <summary>ドア数</summary>
        private List<Int32> _doorCount = new List<int>();

        /// <summary>エンジン型式名称</summary>
        /// <remarks>型式により変動</remarks>
        private List<string> _engineModelNm = new List<string>();

        /// <summary>排気量名称</summary>
        /// <remarks>型式により変動</remarks>
        private List<string> _engineDisplaceNm = new List<string>();

        /// <summary>E区分名称</summary>
        /// <remarks>型式により変動</remarks>
        private List<string> _eDivNm = new List<string>();

        /// <summary>ミッション名称</summary>
        private List<string> _transmissionNm = new List<string>();

        /// <summary>シフト名称</summary>
        private List<string> _shiftNm = new List<string>();

        /// <summary>駆動方式名称</summary>
        private List<string> _wheelDriveMethodNm = new List<string>();


        /// public property name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>曖昧検索で優良設定マスタをチェック</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public property name  :  MakerCode
        /// <summary>車メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public property name  :  ModelCode
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

        /// public property name  :  ModelSubCode
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

        /// public property name  :  SeriesModel
        /// <summary>シリーズ型式プロパティ</summary>
        /// <value>型式１</value>
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

        /// public property name  :  CategorySignModel
        /// <summary>型式（類別記号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }

        /// public property name  :  StProduceTypeOfYear
        /// <summary>開始生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> StProduceTypeOfYear
        {
            get { return _stProduceTypeOfYear; }
            set { _stProduceTypeOfYear = value; }
        }

        /// public property name  :  EdProduceTypeOfYear
        /// <summary>終了生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
        }

        /// public property name  :  ProduceTypeOfYear
        /// <summary>生産年式プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産年式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProduceTypeOfYear
        {
            get { return _ProduceTypeOfYear; }
            set { _ProduceTypeOfYear = value; }
        }

        /// public property name  :  StProduceFrameNo
        /// <summary>生産車台番号開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> StProduceFrameNo
        {
            get { return _stProduceFrameNo; }
            set { _stProduceFrameNo = value; }
        }

        /// public property name  :  EdProduceFrameNo
        /// <summary>生産車台番号終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> EdProduceFrameNo
        {
            get { return _edProduceFrameNo; }
            set { _edProduceFrameNo = value; }
        }

        /// public property name  :  ProduceFrameNo
        /// <summary>生産車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProduceFrameNo
        {
            get { return _ProduceFrameNo; }
            set { _ProduceFrameNo = value; }
        }

        /// public property name  :  ModelGradeNm
        /// <summary>型式グレード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
        }

        /// public property name  :  BodyName
        /// <summary>ボディー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ボディー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> BodyName
        {
            get { return _bodyName; }
            set { _bodyName = value; }
        }

        /// public property name  :  DoorCount
        /// <summary>ドア数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ドア数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        /// public property name  :  EngineModelNm
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public property name  :  EngineDisplaceNm
        /// <summary>排気量名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排気量名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
        }

        /// public property name  :  EDivNm
        /// <summary>E区分名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> EDivNm
        {
            get { return _eDivNm; }
            set { _eDivNm = value; }
        }

        /// public property name  :  TransmissionNm
        /// <summary>ミッション名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ミッション名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> TransmissionNm
        {
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
        }

        /// public property name  :  ShiftNm
        /// <summary>シフト名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シフト名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> ShiftNm
        {
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }

        /// public property name  :  WheelDriveMethodNm
        /// <summary>駆動方式名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   駆動方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
        }


        /// <summary>
        /// 優良ＢＬコード検索条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfferPrimeBlSearchCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferPrimeBlSearchCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfferPrimeBlSearchCondWork()
        {
        }

    }
}
