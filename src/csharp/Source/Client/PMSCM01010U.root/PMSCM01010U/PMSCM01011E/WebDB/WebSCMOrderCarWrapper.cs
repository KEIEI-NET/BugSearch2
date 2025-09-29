//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2010/08/08  修正内容 : 号車、メーカー名称、グレード名称、
//　　　　　　　　　　　　　　　　　ボディー名称、ドア数、エンジン型式名称、
//                                  通称排気量、原動機型式（エンジン）、変速段数、
//                                  変速機名称、E区分名称、ミッション名称、
//                                  シフト名称の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/05/31  修正内容 : 障害№10277 SCM受注データ(車両情報)装備情報の設定方法の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/04/19  修正内容 : 障害№10521対応 SCM受注データ(車両情報)に車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 障害№10384 SCM受注データ(車両情報)に入庫予定日を追加
//----------------------------------------------------------------------------//
using System;
// ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
using Broadleaf.Library.Globarization;
// ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdDtCar;

    /// <summary>
    /// Web-DB SCM受注データ(車両情報)のラッパークラス（お約束）
    /// </summary>
    public abstract partial class WebSCMOrderCarWrapper : ISCMOrderCarRecord
    {
        #region <Override>

        /// <summary>
        /// 等しいか判断します。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns><c>true</c> :等しいです。<br/><c>false</c>:等しくありません。</returns>
        public override bool Equals(object obj)
        {
            return RealRecord.Equals(obj);
        }

        /// <summary>
        /// ハッシュコードを取得します。
        /// </summary>
        /// <returns>ハッシュコード</returns>
        public override int GetHashCode()
        {
            return RealRecord.GetHashCode();
        }

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return RealRecord.ToString();
        }

        #endregion // </Override>

        #region <Adaptee>

        /// <summary>本物のレコード</summary>
        private readonly RecordType _realRecord;
        /// <summary>本物のレコードを取得します。</summary>
        public RecordType RealRecord { get { return _realRecord; } }

        #endregion // </Adaptee>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected WebSCMOrderCarWrapper() : this(new RecordType()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        protected WebSCMOrderCarWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

        /// <summary>
        /// ディープコピーを行います。
        /// </summary>
        /// <returns>コピーインスタンス</returns>
        public object Clone()
        {
            return RealRecord.Clone();
        }

        #region <Automatic Code>

        #region <01.作成日時>

        /// <summary>作成日時を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        public DateTime CreateDateTime
        {
            get { return RealRecord.CreateDateTime; }
            set { RealRecord.CreateDateTime = value; }
        }

        #endregion </01.作成日時>

        #region <02.更新日時>

        /// <summary>更新日時を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        public DateTime UpdateDateTime
        {
            get { return RealRecord.UpdateDateTime; }
            set { RealRecord.UpdateDateTime = value; }
        }

        #endregion </02.更新日時>

        #region <03.論理削除区分>

        /// <summary>論理削除区分を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </03.論理削除区分>

        #region <04.問合せ元企業コード>

        /// <summary>問合せ元企業コードを取得または設定します。</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </04.問合せ元企業コード>

        #region <05.問合せ元拠点コード>

        /// <summary>問合せ元拠点コードを取得または設定します。</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </05.問合せ元拠点コード>

        #region <06.問合せ番号>

        /// <summary>問合せ番号を取得または設定します。</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </06.問合せ番号>

        #region <07.陸運事務所番号>

        /// <summary>陸運事務所番号を取得または設定します。</summary>
        public int NumberPlate1Code
        {
            get { return RealRecord.NumberPlate1Code; }
            set { RealRecord.NumberPlate1Code = value; }
        }

        #endregion </07.陸運事務所番号>

        #region <08.陸運事務局名称>

        /// <summary>陸運事務局名称を取得または設定します。</summary>
        public string NumberPlate1Name
        {
            get { return RealRecord.NumberPlate1Name; }
            set { RealRecord.NumberPlate1Name = value; }
        }

        #endregion </08.陸運事務局名称>

        #region <09.車両登録番号（種別）>

        /// <summary>車両登録番号（種別）を取得または設定します。</summary>
        public string NumberPlate2
        {
            get { return RealRecord.NumberPlate2; }
            set { RealRecord.NumberPlate2 = value; }
        }

        #endregion </09.車両登録番号（種別）>

        #region <10.車両登録番号（カナ）>

        /// <summary>車両登録番号（カナ）を取得または設定します。</summary>
        public string NumberPlate3
        {
            get { return RealRecord.NumberPlate3; }
            set { RealRecord.NumberPlate3 = value; }
        }

        #endregion </10.車両登録番号（カナ）>

        #region <11.車両登録番号（プレート番号）>

        /// <summary>車両登録番号（プレート番号）を取得または設定します。</summary>
        public int NumberPlate4
        {
            get { return RealRecord.NumberPlate4; }
            set { RealRecord.NumberPlate4 = value; }
        }

        #endregion </11.車両登録番号（プレート番号）>

        #region <12.型式指定番号>

        /// <summary>型式指定番号を取得または設定します。</summary>
        public int ModelDesignationNo
        {
            get { return RealRecord.ModelDesignationNo; }
            set { RealRecord.ModelDesignationNo = value; }
        }

        #endregion </12.型式指定番号>

        #region <13.類別番号>

        /// <summary>類別番号を取得または設定します。</summary>
        public int CategoryNo
        {
            get { return RealRecord.CategoryNo; }
            set { RealRecord.CategoryNo = value; }
        }

        #endregion </13.類別番号>

        #region <14.メーカーコード>

        /// <summary>メーカーコードを取得または設定します。</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        public int MakerCode
        {
            get { return RealRecord.MakerCode; }
            set { RealRecord.MakerCode = value; }
        }

        #endregion </14.メーカーコード>

        #region <15.車種コード>

        /// <summary>車種コードを取得または設定します。</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        public int ModelCode
        {
            get { return RealRecord.ModelCode; }
            set { RealRecord.ModelCode = value; }
        }

        #endregion </15.車種コード>

        #region <16.車種サブコード>

        /// <summary>車種サブコードを取得または設定します。</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        public int ModelSubCode
        {
            get { return RealRecord.ModelSubCode; }
            set { RealRecord.ModelSubCode = value; }
        }

        #endregion </16.車種サブコード>

        #region <17.車種名>

        /// <summary>車種名を取得または設定します。</summary>
        public string ModelName
        {
            get { return RealRecord.ModelName; }
            set { RealRecord.ModelName = value; }
        }

        #endregion </17.車種名>

        #region <18.車検証型式>

        /// <summary>車検証型式を取得または設定します。</summary>
        public string CarInspectCertModel
        {
            get { return RealRecord.CarInspectCertModel; }
            set { RealRecord.CarInspectCertModel = value; }
        }

        #endregion </18.車検証型式>

        #region <19.型式（フル型）>

        /// <summary>型式（フル型）を取得または設定します。</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        public string FullModel
        {
            get { return RealRecord.FullModel; }
            set { RealRecord.FullModel = value; }
        }

        #endregion </19.型式（フル型）>

        #region <20.車台番号>

        /// <summary>車台番号を取得または設定します。</summary>
        public string FrameNo
        {
            get { return RealRecord.FrameNo; }
            set { RealRecord.FrameNo = value; }
        }

        #endregion </20.車台番号>

        #region <21.車台型式>

        /// <summary>車台型式を取得または設定します。</summary>
        public string FrameModel
        {
            get { return RealRecord.FrameModel; }
            set { RealRecord.FrameModel = value; }
        }

        #endregion </21.車台型式>

        #region <22.シャシーNo>

        /// <summary>シャシーNoを取得または設定します。</summary>
        public string ChassisNo
        {
            get { return RealRecord.ChassisNo; }
            set { RealRecord.ChassisNo = value; }
        }

        #endregion </22.シャシーNo>

        #region <23.車両固有番号>

        /// <summary>車両固有番号を取得または設定します。</summary>
        /// <remarks>ユニークな固定番号</remarks>
        public int CarProperNo
        {
            get { return RealRecord.CarProperNo; }
            set { RealRecord.CarProperNo = value; }
        }

        #endregion </23.車両固有番号>

        #region <24.生産年式（NUMタイプ）>

        /// <summary>生産年式（NUMタイプ）を取得または設定します。</summary>
        /// <remarks>YYYYMM</remarks>
        public int ProduceTypeOfYearNum
        {
            get { return RealRecord.ProduceTypeOfYearNum; }
            set { RealRecord.ProduceTypeOfYearNum = value; }
        }

        #endregion </24.生産年式（NUMタイプ）>

        #region <25.コメント>

        /// <summary>コメントを取得または設定します。</summary>
        /// <remarks>カタログのコメントや単位・カラーが格納</remarks>
        public string Comment
        {
            get { return RealRecord.Comment; }
            set { RealRecord.Comment = value; }
        }

        #endregion </25.コメント>

        #region <26.リペアカラーコード>

        /// <summary>リペアカラーコードを取得または設定します。</summary>
        /// <remarks>カタログの色コード（リペア用が新車時と異なる場合）</remarks>
        public string RpColorCode
        {
            get { return RealRecord.RpColorCode; }
            set { RealRecord.RpColorCode = value; }
        }

        #endregion </26.リペアカラーコード>

        #region <27.カラー名称1>

        /// <summary>カラー名称1を取得または設定します。</summary>
        /// <remarks>画面表示用正式名称</remarks>
        public string ColorName1
        {
            get { return RealRecord.ColorName1; }
            set { RealRecord.ColorName1 = value; }
        }

        #endregion </27.カラー名称1>

        #region <28.トリムコード>

        /// <summary>トリムコードを取得または設定します。</summary>
        public string TrimCode
        {
            get { return RealRecord.TrimCode; }
            set { RealRecord.TrimCode = value; }
        }

        #endregion </28.トリムコード>

        #region <29.トリム名称>

        /// <summary>トリム名称を取得または設定します。</summary>
        public string TrimName
        {
            get { return RealRecord.TrimName; }
            set { RealRecord.TrimName = value; }
        }

        #endregion </29.トリム名称>

        #region <30.車両走行距離>

        /// <summary>車両走行距離を取得または設定します。</summary>
        public int Mileage
        {
            get { return RealRecord.Mileage; }
            set { RealRecord.Mileage = value; }
        }

        #endregion </30.車両走行距離>

        #region <31.装備オブジェクト>

        /// <summary>装備オブジェクトを取得または設定します。</summary>
        public byte[] EquipObj
        {
            get { return RealRecord.EquipObj; }
            set { RealRecord.EquipObj = value; }
        }

        #endregion </31.装備オブジェクト>
        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        #region <32.号車>

        /// <summary>号車を取得または設定します。</summary>
        public string CarNo
        {
            get { return RealRecord.CarNo; }
            set { RealRecord.CarNo = value; }
        }

        #endregion </32.号車>

        #region <33.メーカー名称>

        /// <summary>メーカー名称を取得または設定します。</summary>
        public string MakerName
        {
            get { return RealRecord.MakerName; }
            set { RealRecord.MakerName = value; }
        }

        #endregion </33.メーカー名称>

        #region <34.グレード名称>

        /// <summary>グレード名称を取得または設定します。</summary>
        public string GradeName
        {
            get { return RealRecord.GradeName; }
            set { RealRecord.GradeName = value; }
        }

        #endregion </34.グレード名称>

        #region <35.ボディー名称>

        /// <summary>ボディー名称を取得または設定します。</summary>
        public string BodyName
        {
            get { return RealRecord.BodyName; }
            set { RealRecord.BodyName = value; }
        }

        #endregion </35.ボディー名称>

        #region <36.ドア数>

        /// <summary>ドア数を取得または設定します。</summary>
        public int DoorCount
        {
            get { return RealRecord.DoorCount; }
            set { RealRecord.DoorCount = value; }
        }

        #endregion </36.ドア数>

        #region <37.エンジン型式名称>

        /// <summary>エンジン型式名称を取得または設定します。</summary>
        public string EngineModelNm
        {
            get { return RealRecord.EngineModelNm; }
            set { RealRecord.EngineModelNm = value; }
        }

        #endregion </37.エンジン型式名称>

        #region <38.通称排気量>

        /// <summary>通称排気量を取得または設定します。</summary>
        public int CmnNmEngineDisPlace
        {
            get { return RealRecord.CmnNmEngineDisPlace; }
            set { RealRecord.CmnNmEngineDisPlace = value; }
        }

        #endregion </38.通称排気量>

        #region <39.原動機型式（エンジン）>

        /// <summary>原動機型式（エンジン）を取得または設定します。</summary>
        public string EngineModel
        {
            get { return RealRecord.EngineModel; }
            set { RealRecord.EngineModel = value; }
        }

        #endregion </39.原動機型式（エンジン）>

        #region <40.変速段数>

        /// <summary>変速段数を取得または設定します。</summary>
        public int NumberOfGear
        {
            get { return RealRecord.NumberOfGear; }
            set { RealRecord.NumberOfGear = value; }
        }

        #endregion </40.変速段数>

        #region <41.変速機名称>

        /// <summary>変速機名称を取得または設定します。</summary>
        public string GearNm
        {
            get { return RealRecord.GearNm; }
            set { RealRecord.GearNm = value; }
        }

        #endregion </41.変速機名称>

        #region <42.E区分名称>

        /// <summary>E区分名称を取得または設定します。</summary>
        public string EDivNm
        {
            get { return RealRecord.EDivNm; }
            set { RealRecord.EDivNm = value; }
        }

        #endregion </42.E区分名称>

        #region <43.ミッション名称>

        /// <summary>ミッション名称を取得または設定します。</summary>
        public string TransmissionNm
        {
            get { return RealRecord.TransmissionNm; }
            set { RealRecord.TransmissionNm = value; }
        }

        #endregion </43.ミッション名称>

        #region <44.シフト名称>

        /// <summary>シフト名称を取得または設定します。</summary>
        public string ShiftNm
        {
            get { return RealRecord.ShiftNm; }
            set { RealRecord.ShiftNm = value; }
        }

        #endregion </44.シフト名称>
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

        // ADD 2012/05/31 -------------------------->>>>>
        #region <45.初年度（NUMタイプ）>

        /// <summary>初年度（NUMタイプ）を取得または設定します。</summary>
        public Int32 FirstEntryDateNumTyp
        {
            get { return RealRecord.FirstEntryDateNumTyp; }
            set { RealRecord.FirstEntryDateNumTyp = value; }
        }

        #endregion </45.初年度（NUMタイプ）>

        #region <46.車両付加情報オブジェクト>

        /// <summary>車両付加情報オブジェクトを取得または設定します。</summary>
        public Byte[] CarAddInf
        {
            get { return RealRecord.CarAddInf; }
            set { RealRecord.CarAddInf = value; }
        }

        #endregion </46.車両付加情報オブジェクト>

        #region <47.装備部品オブジェクト>

        /// <summary>装備部品オブジェクトを取得または設定します。</summary>
        public Byte[] EquipPrtsObj
        {
            get { return RealRecord.EquipPrtsObj; }
            set { RealRecord.EquipPrtsObj = value; }
        }

        #endregion </47.装備部品オブジェクト>

        // ADD 2012/05/31 --------------------------<<<<<

        // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>

        #region <48.車両管理コード>

        /// <summary>車両管理コードを取得または設定します。</summary>
        public string CarMngCode
        {
            get { return RealRecord.CarMngCode; }
            set { RealRecord.CarMngCode = value; }
        }


        #endregion </48.車両管理オブジェクト>

        // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        #region <49.入庫予定日>

        /// <summary>入庫予定日を取得または設定します。</summary>
        public Int32 ExpectedCeDate
        {
            get
            {
                // DateTime型をInt32型に変換する
                return TDateTime.DateTimeToLongDate(RealRecord.ExpectedCeDate);
            }
            set
            {
                // Int32型をDateTime型に変換する
                RealRecord.ExpectedCeDate = TDateTime.LongDateToDateTime("YYYYMMDD", value);
            }
        }
        #endregion </49.入庫予定日>
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

        #endregion // </Automatic Code>
    }
}
