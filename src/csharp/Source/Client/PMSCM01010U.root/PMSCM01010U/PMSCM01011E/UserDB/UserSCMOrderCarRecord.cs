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
// 作 成 日  2009/05/20  修正内容 : 新規作成
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
// 作 成 日  2013/04/19  修正内容 : 障害№10521 SCM受注データ(車両情報)に車両管理コードを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 障害№10384 SCM受注データ(車両情報)に入庫予定日を追加
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData.WebDB;
// ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
using Broadleaf.Library.Globarization;
// ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtCar;

    /// <summary>
    /// ユーザーDB SCM受注データ(車両情報)のレコードクラス
    /// </summary>
    public class UserSCMOrderCarRecord : UserSCMOrderCarWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UserSCMOrderCarRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        public UserSCMOrderCarRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="webRecord">SCM受発注データ(車両情報)</param>
        public UserSCMOrderCarRecord(WebSCMOrderCarRecord webRecord) : base(new RecordType())
        {
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // 論理削除区分
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // 問合せ元拠点コード
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // 問合せ番号
            RealRecord.NumberPlate1Code = webRecord.NumberPlate1Code; // 陸運事務所番号
            RealRecord.NumberPlate1Name = webRecord.NumberPlate1Name; // 陸運事務局名称
            RealRecord.NumberPlate2 = webRecord.NumberPlate2; // 車両登録番号(種別)
            RealRecord.NumberPlate3 = webRecord.NumberPlate3; // 車両登録番号(カナ)
            RealRecord.NumberPlate4 = webRecord.NumberPlate4; // 車両登録番号(プレート番号)
            RealRecord.ModelDesignationNo = webRecord.ModelDesignationNo; // 型式指定番号
            RealRecord.CategoryNo = webRecord.CategoryNo; // 類別番号
            RealRecord.MakerCode = webRecord.MakerCode; // メーカーコード
            RealRecord.ModelCode = webRecord.ModelCode; // 車種コード
            RealRecord.ModelSubCode = webRecord.ModelSubCode; // 車種サブコード
            RealRecord.ModelName = webRecord.ModelName; // 車種名
            RealRecord.CarInspectCertModel = webRecord.CarInspectCertModel; // 車検証型式
            RealRecord.FullModel = webRecord.FullModel; // 型式(フル型)
            RealRecord.FrameNo = webRecord.FrameNo; // 車台番号
            RealRecord.FrameModel = webRecord.FrameModel; // 車台型式
            RealRecord.ChassisNo = webRecord.ChassisNo; // シャシーNo
            RealRecord.CarProperNo = webRecord.CarProperNo; // 車両固有番号
            RealRecord.ProduceTypeOfYearNum = webRecord.ProduceTypeOfYearNum; // 生産年式(Numタイプ)
            RealRecord.Comment = webRecord.Comment; // コメント
            RealRecord.RpColorCode = webRecord.RpColorCode; // リペアカラーコード
            RealRecord.ColorName1 = webRecord.ColorName1; // カラー名称1
            RealRecord.TrimCode = webRecord.TrimCode; // トリムコード
            RealRecord.TrimName = webRecord.TrimName; // トリム名称
            RealRecord.Mileage = webRecord.Mileage; // 車両走行距離
            RealRecord.EquipObj = webRecord.EquipObj; // 装備オブジェト
            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
            RealRecord.CarNo = webRecord.CarNo; // 号車
            RealRecord.MakerName = webRecord.MakerName; // メーカー名称
            RealRecord.GradeName = webRecord.GradeName; // グレード名称
            RealRecord.BodyName = webRecord.BodyName; // ボディー名称
            RealRecord.DoorCount = webRecord.DoorCount; // ドア数
            RealRecord.EngineModelNm = webRecord.EngineModelNm; // エンジン型式名称
            RealRecord.CmnNmEngineDisPlace = webRecord.CmnNmEngineDisPlace; // 通称排気量
            RealRecord.EngineModel = webRecord.EngineModel; // 原動機型式（エンジン）
            RealRecord.NumberOfGear = webRecord.NumberOfGear; // 変速段数
            RealRecord.GearNm = webRecord.GearNm; // 変速機名称
            RealRecord.EDivNm = webRecord.EDivNm; // E区分名称
            RealRecord.TransmissionNm = webRecord.TransmissionNm; // ミッション名称
            RealRecord.ShiftNm = webRecord.ShiftNm; // シフト名称
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
            // ADD 2012/05/31 -------------------------->>>>>
            RealRecord.FirstEntryDateNumTyp = webRecord.FirstEntryDateNumTyp; // 初年度（NUMタイプ）
            RealRecord.CarAddInf = webRecord.CarAddInf; // 車両付加情報オブジェクト
            RealRecord.EquipPrtsObj = webRecord.EquipPrtsObj; // 装備部品オブジェクト
            // ADD 2012/05/31 --------------------------<<<<<
            // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
            RealRecord.CarMngCode = webRecord.CarMngCode; // 車両管理コード
            // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            RealRecord.ExpectedCeDate = webRecord.ExpectedCeDate; // 入庫予定日
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="other">コピー元</param>
        public UserSCMOrderCarRecord(UserSCMOrderCarRecord other)
        {
            if (other == null || other == this) return;

            RealRecord.CreateDateTime = other.CreateDateTime; // 作成日時
            RealRecord.UpdateDateTime = other.UpdateDateTime; // 更新日時
            RealRecord.EnterpriseCode = other.EnterpriseCode; // 企業コード
            RealRecord.FileHeaderGuid = other.FileHeaderGuid; // GUID
            RealRecord.UpdEmployeeCode = other.UpdEmployeeCode; // 更新従業員コード
            RealRecord.UpdAssemblyId1 = other.UpdAssemblyId1; // 更新アセンブリ1
            RealRecord.UpdAssemblyId2 = other.UpdAssemblyId2; // 更新アセンブリ2
            RealRecord.LogicalDeleteCode = other.LogicalDeleteCode; // 論理削除区分

            RealRecord.InqOriginalEpCd = other.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            RealRecord.InqOriginalSecCd = other.InqOriginalSecCd; // 問合せ元拠点コード
            RealRecord.InquiryNumber = other.InquiryNumber; // 問合せ番号
            RealRecord.NumberPlate1Code = other.NumberPlate1Code; // 陸運事務所番号
            RealRecord.NumberPlate1Name = other.NumberPlate1Name; // 陸運事務局名称
            RealRecord.NumberPlate2 = other.NumberPlate2; // 車両登録番号(種別)
            RealRecord.NumberPlate3 = other.NumberPlate3; // 車両登録番号(カナ)
            RealRecord.NumberPlate4 = other.NumberPlate4; // 車両登録番号(プレート番号)
            RealRecord.ModelDesignationNo = other.ModelDesignationNo; // 型式指定番号
            RealRecord.CategoryNo = other.CategoryNo; // 類別番号
            RealRecord.MakerCode = other.MakerCode; // メーカーコード
            RealRecord.ModelCode = other.ModelCode; // 車種コード
            RealRecord.ModelSubCode = other.ModelSubCode; // 車種サブコード
            RealRecord.ModelName = other.ModelName; // 車種名
            RealRecord.CarInspectCertModel = other.CarInspectCertModel; // 車検証型式
            RealRecord.FullModel = other.FullModel; // 型式(フル型)
            RealRecord.FrameNo = other.FrameNo; // 車台番号
            RealRecord.FrameModel = other.FrameModel; // 車台型式
            RealRecord.ChassisNo = other.ChassisNo; // シャシーNo
            RealRecord.CarProperNo = other.CarProperNo; // 車両固有番号
            RealRecord.ProduceTypeOfYearNum = other.ProduceTypeOfYearNum; // 生産年式(Numタイプ)
            RealRecord.Comment = other.Comment; // コメント
            RealRecord.RpColorCode = other.RpColorCode; // リペアカラーコード
            RealRecord.ColorName1 = other.ColorName1; // カラー名称1
            RealRecord.TrimCode = other.TrimCode; // トリムコード
            RealRecord.TrimName = other.TrimName; // トリム名称
            RealRecord.Mileage = other.Mileage; // 車両走行距離
            RealRecord.EquipObj = other.EquipObj; // 装備オブジェト
            RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = other.SalesSlipNum; // 売上伝票番号
            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
            RealRecord.CarNo = other.CarNo; // 号車
            RealRecord.MakerName = other.MakerName; // メーカー名称
            RealRecord.GradeName = other.GradeName; // グレード名称
            RealRecord.BodyName = other.BodyName; // ボディー名称
            RealRecord.DoorCount = other.DoorCount; // ドア数
            RealRecord.EngineModelNm = other.EngineModelNm; // エンジン型式名称
            RealRecord.CmnNmEngineDisPlace = other.CmnNmEngineDisPlace; // 通称排気量
            RealRecord.EngineModel = other.EngineModel; // 原動機型式（エンジン）
            RealRecord.NumberOfGear = other.NumberOfGear; // 変速段数
            RealRecord.GearNm = other.GearNm; // 変速機名称
            RealRecord.EDivNm = other.EDivNm; // E区分名称
            RealRecord.TransmissionNm = other.TransmissionNm; // ミッション名称
            RealRecord.ShiftNm = other.ShiftNm; // シフト名称
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
            // ADD 2012/05/31 -------------------------->>>>>
            RealRecord.FirstEntryDateNumTyp = other.FirstEntryDateNumTyp; // 初年度（NUMタイプ）
            RealRecord.CarAddInf = other.CarAddInf; // 車両付加情報オブジェクト
            RealRecord.EquipPrtsObj = other.EquipPrtsObj; // 装備部品オブジェクト
            // ADD 2012/05/31 --------------------------<<<<<
            // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
            RealRecord.CarMngCode = other.CarMngCode; // 車両管理コード
            // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<
            // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
            RealRecord.ExpectedCeDate = other.ExpectedCeDate; // 入庫予定日
            // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
        }

        #region <User⇒WEB変換>
        /// <summary>
        /// UserDBからWebDBへの詰替え処理
        /// </summary>
        /// <returns>SCM受発注データ(車両情報)</returns>
        public WebSCMOrderCarRecord CopyToWebSCMOrderCarRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // 論理削除区分
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // 問合せ元拠点コード
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // 問合せ番号
                webRecord.NumberPlate1Code = RealRecord.NumberPlate1Code; // 陸運事務所番号
                webRecord.NumberPlate1Name = RealRecord.NumberPlate1Name; // 陸運事務局名称
                webRecord.NumberPlate2 = RealRecord.NumberPlate2; // 車両登録番号(種別)
                webRecord.NumberPlate3 = RealRecord.NumberPlate3; // 車両登録番号(カナ)
                webRecord.NumberPlate4 = RealRecord.NumberPlate4; // 車両登録番号(プレート番号)
                webRecord.ModelDesignationNo = RealRecord.ModelDesignationNo; // 型式指定番号
                webRecord.CategoryNo = RealRecord.CategoryNo; // 類別番号
                webRecord.MakerCode = RealRecord.MakerCode; // メーカーコード
                webRecord.ModelCode = RealRecord.ModelCode; // 車種コード
                webRecord.ModelSubCode = RealRecord.ModelSubCode; // 車種サブコード
                webRecord.ModelName = RealRecord.ModelName; // 車種名
                webRecord.CarInspectCertModel = RealRecord.CarInspectCertModel; // 車検証型式
                webRecord.FullModel = RealRecord.FullModel; // 型式(フル型)
                webRecord.FrameNo = RealRecord.FrameNo; // 車台番号
                webRecord.FrameModel = RealRecord.FrameModel; // 車台型式
                webRecord.ChassisNo = RealRecord.ChassisNo; // シャシーNo
                webRecord.CarProperNo = RealRecord.CarProperNo; // 車両固有番号
                webRecord.ProduceTypeOfYearNum = RealRecord.ProduceTypeOfYearNum; // 生産年式(Numタイプ)
                webRecord.Comment = RealRecord.Comment; // コメント
                webRecord.RpColorCode = RealRecord.RpColorCode; // リペアカラーコード
                webRecord.ColorName1 = RealRecord.ColorName1; // カラー名称1
                webRecord.TrimCode = RealRecord.TrimCode; // トリムコード
                webRecord.TrimName = RealRecord.TrimName; // トリム名称
                webRecord.Mileage = RealRecord.Mileage; // 車両走行距離
                webRecord.EquipObj = RealRecord.EquipObj; // 装備オブジェト
                // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
                webRecord.CarNo = RealRecord.CarNo; // 号車
                webRecord.MakerName = RealRecord.MakerName; // メーカー名称
                webRecord.GradeName = RealRecord.GradeName; // グレード名称
                webRecord.BodyName = RealRecord.BodyName; // ボディー名称
                webRecord.DoorCount = RealRecord.DoorCount; // ドア数
                webRecord.EngineModelNm = RealRecord.EngineModelNm; // エンジン型式名称
                webRecord.CmnNmEngineDisPlace = RealRecord.CmnNmEngineDisPlace; // 通称排気量
                webRecord.EngineModel = RealRecord.EngineModel; // 原動機型式（エンジン）
                webRecord.NumberOfGear = RealRecord.NumberOfGear; // 変速段数
                webRecord.GearNm = RealRecord.GearNm; // 変速機名称
                webRecord.EDivNm = RealRecord.EDivNm; // E区分名称
                webRecord.TransmissionNm = RealRecord.TransmissionNm; // ミッション名称
                webRecord.ShiftNm = RealRecord.ShiftNm; // シフト名称
                // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
                // ADD 2012/05/31 -------------------------->>>>>
                webRecord.FirstEntryDateNumTyp = RealRecord.FirstEntryDateNumTyp; // 初年度（NUMタイプ）
                webRecord.CarAddInf = RealRecord.CarAddInf; // 車両付加情報オブジェクト
                webRecord.EquipPrtsObj = RealRecord.EquipPrtsObj; // 装備部品オブジェクト
                // ADD 2012/05/31 --------------------------<<<<<
                // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
                webRecord.CarMngCode = RealRecord.CarMngCode; // 車両管理コード
                // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<
                // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                webRecord.ExpectedCeDate = TDateTime.LongDateToDateTime("YYYYMMDD", RealRecord.ExpectedCeDate); // 入庫予定日
                // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
            }
            return new WebSCMOrderCarRecord(webRecord);
        }
        #endregion
    }
}
