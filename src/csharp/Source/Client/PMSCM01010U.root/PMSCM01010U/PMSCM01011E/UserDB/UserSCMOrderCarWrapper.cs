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
// 作 成 日  2013/04/19  修正内容 : 障害№1521 SCM受注データ(車両情報)の車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 障害№10384 SCM受注データ(車両情報)に入庫予定日を追加
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtCar;

    /// <summary>
    /// ユーザーDB SCM受注データ(車両情報)のラッパークラス（お約束）
    /// </summary>
    public abstract partial class UserSCMOrderCarWrapper : ISCMOrderCarRecord
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
        protected UserSCMOrderCarWrapper() : this(new RecordType()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        protected UserSCMOrderCarWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

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

        #region <03.企業コード>

        /// <summary>企業コードを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string EnterpriseCode
        {
            get { return RealRecord.EnterpriseCode; }
            set { RealRecord.EnterpriseCode = value; }
        }

        #endregion </03.企業コード>

        #region <04.GUID>

        /// <summary>GUIDを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        public Guid FileHeaderGuid
        {
            get { return RealRecord.FileHeaderGuid; }
            set { RealRecord.FileHeaderGuid = value; }
        }

        #endregion </04.GUID>

        #region <05.更新従業員コード>

        /// <summary>更新従業員コードを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        public string UpdEmployeeCode
        {
            get { return RealRecord.UpdEmployeeCode; }
            set { RealRecord.UpdEmployeeCode = value; }
        }

        #endregion </05.更新従業員コード>

        #region <06.更新アセンブリID1>

        /// <summary>更新アセンブリID1を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        public string UpdAssemblyId1
        {
            get { return RealRecord.UpdAssemblyId1; }
            set { RealRecord.UpdAssemblyId1 = value; }
        }

        #endregion </06.更新アセンブリID1>

        #region <07.更新アセンブリID2>

        /// <summary>更新アセンブリID2を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        public string UpdAssemblyId2
        {
            get { return RealRecord.UpdAssemblyId2; }
            set { RealRecord.UpdAssemblyId2 = value; }
        }

        #endregion </07.更新アセンブリID2>

        #region <08.論理削除区分>

        /// <summary>論理削除区分を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </08.論理削除区分>

        #region <09.問合せ元企業コード>

        /// <summary>問合せ元企業コードを取得または設定します。</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </09.問合せ元企業コード>

        #region <10.問合せ元拠点コード>

        /// <summary>問合せ元拠点コードを取得または設定します。</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </10.問合せ元拠点コード>

        #region <11.問合せ番号>

        /// <summary>問合せ番号を取得または設定します。</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </11.問合せ番号>

        #region <12.陸運事務所番号>

        /// <summary>陸運事務所番号を取得または設定します。</summary>
        public int NumberPlate1Code
        {
            get { return RealRecord.NumberPlate1Code; }
            set { RealRecord.NumberPlate1Code = value; }
        }

        #endregion </12.陸運事務所番号>

        #region <13.陸運事務局名称>

        /// <summary>陸運事務局名称を取得または設定します。</summary>
        public string NumberPlate1Name
        {
            get { return RealRecord.NumberPlate1Name; }
            set { RealRecord.NumberPlate1Name = value; }
        }

        #endregion </13.陸運事務局名称>

        #region <14.車両登録番号（種別）>

        /// <summary>車両登録番号（種別）を取得または設定します。</summary>
        public string NumberPlate2
        {
            get { return RealRecord.NumberPlate2; }
            set { RealRecord.NumberPlate2 = value; }
        }

        #endregion </14.車両登録番号（種別）>

        #region <15.車両登録番号（カナ）>

        /// <summary>車両登録番号（カナ）を取得または設定します。</summary>
        public string NumberPlate3
        {
            get { return RealRecord.NumberPlate3; }
            set { RealRecord.NumberPlate3 = value; }
        }

        #endregion </15.車両登録番号（カナ）>

        #region <16.車両登録番号（プレート番号）>

        /// <summary>車両登録番号（プレート番号）を取得または設定します。</summary>
        public int NumberPlate4
        {
            get { return RealRecord.NumberPlate4; }
            set { RealRecord.NumberPlate4 = value; }
        }

        #endregion </16.車両登録番号（プレート番号）>

        #region <17.型式指定番号>

        /// <summary>型式指定番号を取得または設定します。</summary>
        public int ModelDesignationNo
        {
            get { return RealRecord.ModelDesignationNo; }
            set { RealRecord.ModelDesignationNo = value; }
        }

        #endregion </17.型式指定番号>

        #region <18.類別番号>

        /// <summary>類別番号を取得または設定します。</summary>
        public int CategoryNo
        {
            get { return RealRecord.CategoryNo; }
            set { RealRecord.CategoryNo = value; }
        }

        #endregion </18.類別番号>

        #region <19.メーカーコード>

        /// <summary>メーカーコードを取得または設定します。</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        public int MakerCode
        {
            get { return RealRecord.MakerCode; }
            set { RealRecord.MakerCode = value; }
        }

        #endregion </19.メーカーコード>

        #region <20.車種コード>

        /// <summary>車種コードを取得または設定します。</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        public int ModelCode
        {
            get { return RealRecord.ModelCode; }
            set { RealRecord.ModelCode = value; }
        }

        #endregion </20.車種コード>

        #region <21.車種サブコード>

        /// <summary>車種サブコードを取得または設定します。</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        public int ModelSubCode
        {
            get { return RealRecord.ModelSubCode; }
            set { RealRecord.ModelSubCode = value; }
        }

        #endregion </21.車種サブコード>

        #region <22.車種名>

        /// <summary>車種名を取得または設定します。</summary>
        public string ModelName
        {
            get { return RealRecord.ModelName; }
            set { RealRecord.ModelName = value; }
        }

        #endregion </22.車種名>

        #region <23.車検証型式>

        /// <summary>車検証型式を取得または設定します。</summary>
        public string CarInspectCertModel
        {
            get { return RealRecord.CarInspectCertModel; }
            set { RealRecord.CarInspectCertModel = value; }
        }

        #endregion </23.車検証型式>

        #region <24.型式（フル型）>

        /// <summary>型式（フル型）を取得または設定します。</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        public string FullModel
        {
            get { return RealRecord.FullModel; }
            set { RealRecord.FullModel = value; }
        }

        #endregion </24.型式（フル型）>

        #region <25.車台番号>

        /// <summary>車台番号を取得または設定します。</summary>
        public string FrameNo
        {
            get { return RealRecord.FrameNo; }
            set { RealRecord.FrameNo = value; }
        }

        #endregion </25.車台番号>

        #region <26.車台型式>

        /// <summary>車台型式を取得または設定します。</summary>
        public string FrameModel
        {
            get { return RealRecord.FrameModel; }
            set { RealRecord.FrameModel = value; }
        }

        #endregion </26.車台型式>

        #region <27.シャシーNo>

        /// <summary>シャシーNoを取得または設定します。</summary>
        public string ChassisNo
        {
            get { return RealRecord.ChassisNo; }
            set { RealRecord.ChassisNo = value; }
        }

        #endregion </27.シャシーNo>

        #region <28.車両固有番号>

        /// <summary>車両固有番号を取得または設定します。</summary>
        /// <remarks>ユニークな固定番号</remarks>
        public int CarProperNo
        {
            get { return RealRecord.CarProperNo; }
            set { RealRecord.CarProperNo = value; }
        }

        #endregion </28.車両固有番号>

        #region <29.生産年式（NUMタイプ）>

        /// <summary>生産年式（NUMタイプ）を取得または設定します。</summary>
        /// <remarks>YYYYMM</remarks>
        public int ProduceTypeOfYearNum
        {
            get { return RealRecord.ProduceTypeOfYearNum; }
            set { RealRecord.ProduceTypeOfYearNum = value; }
        }

        #endregion </29.生産年式（NUMタイプ）>

        #region <30.コメント>

        /// <summary>コメントを取得または設定します。</summary>
        /// <remarks>カタログのコメントや単位・カラーが格納</remarks>
        public string Comment
        {
            get { return RealRecord.Comment; }
            set { RealRecord.Comment = value; }
        }

        #endregion </30.コメント>

        #region <31.リペアカラーコード>

        /// <summary>リペアカラーコードを取得または設定します。</summary>
        /// <remarks>カタログの色コード（リペア用が新車時と異なる場合）</remarks>
        public string RpColorCode
        {
            get { return RealRecord.RpColorCode; }
            set { RealRecord.RpColorCode = value; }
        }

        #endregion </31.リペアカラーコード>

        #region <32.カラー名称1>

        /// <summary>カラー名称1を取得または設定します。</summary>
        /// <remarks>画面表示用正式名称</remarks>
        public string ColorName1
        {
            get { return RealRecord.ColorName1; }
            set { RealRecord.ColorName1 = value; }
        }

        #endregion </32.カラー名称1>

        #region <33.トリムコード>

        /// <summary>トリムコードを取得または設定します。</summary>
        public string TrimCode
        {
            get { return RealRecord.TrimCode; }
            set { RealRecord.TrimCode = value; }
        }

        #endregion </33.トリムコード>

        #region <34.トリム名称>

        /// <summary>トリム名称を取得または設定します。</summary>
        public string TrimName
        {
            get { return RealRecord.TrimName; }
            set { RealRecord.TrimName = value; }
        }

        #endregion </34.トリム名称>

        #region <35.車両走行距離>

        /// <summary>車両走行距離を取得または設定します。</summary>
        public int Mileage
        {
            get { return RealRecord.Mileage; }
            set { RealRecord.Mileage = value; }
        }

        #endregion </35.車両走行距離>

        #region <36.装備オブジェクト>

        /// <summary>装備オブジェクトを取得または設定します。</summary>
        public byte[] EquipObj
        {
            get { return RealRecord.EquipObj; }
            set { RealRecord.EquipObj = value; }
        }

        #endregion </36.装備オブジェクト>

        #region <37.受注ステータス>

        /// <summary>受注ステータスを取得または設定します。</summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        public int AcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        #endregion </37.受注ステータス>

        #region <38.売上伝票番号>

        /// <summary>売上伝票番号を取得または設定します。</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        public string SalesSlipNum
        {
            get { return RealRecord.SalesSlipNum; }
            set { RealRecord.SalesSlipNum = value; }
        }

        #endregion </38.売上伝票番号>
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

        #endregion </48.車両管理コード>
        // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        #region <49.入庫予定日>

        /// <summary>入庫予定日を取得または設定します。</summary>
        public Int32 ExpectedCeDate
        {
            get
            {
                return RealRecord.ExpectedCeDate;
            }
            set
            {
                RealRecord.ExpectedCeDate = value;
            }
        }

        #endregion </49.入庫予定日>
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

        #endregion // </Automatic Code>
    }
}
