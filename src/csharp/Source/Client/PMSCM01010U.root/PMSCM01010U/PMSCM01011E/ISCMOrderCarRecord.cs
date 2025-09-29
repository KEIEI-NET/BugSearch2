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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/17  修正内容 : カラー、トリム、年式の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2010/08/08  修正内容 : 号車、メーカー名称、グレード名称、
//　　　　　　　　　　　　　　　　　ボディー名称、ドア数、エンジン型式名称、
//                                  通称排気量、原動機型式（エンジン）、変速段数、
//                                  変速機名称、E区分名称、ミッション名称、
//                                  シフト名称の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/09/01  修正内容 : 自動回答対応、車検証型式を追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/05/31  修正内容 : 障害№10277 SCM受注データ(車両情報)装備情報の設定方法の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/06  修正内容 : 障害№178   車台番号の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/04/19  修正内容 : SCM障害№10521対応 SCM受注データ（車両情報）に車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 障害№10384 SCM受注データ(車両情報)に入庫予定日を追加
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM受注データ(車両情報)のレコードインターフェース
    /// </summary>
    public interface ISCMOrderCarRecord
    {
        /// <summary>
        /// 問合せ元企業コードを取得または設定します。
        /// </summary>
        string InqOriginalEpCd { get; set; }

        /// <summary>
        /// 問合せ元拠点コードを取得または設定します。
        /// </summary>
        string InqOriginalSecCd { get; set; }

        /// <summary>
        /// 問合せ番号を取得または設定します。
        /// </summary>
        long InquiryNumber { get; set; }

        /// <summary>
        /// 類別番号を取得または設定します。
        /// </summary>
        int CategoryNo { get; set; }

        /// <summary>
        /// 車種名を取得または設定します。
        /// </summary>
        string ModelName { get; set; }

        /// <summary>
        /// 型式指定番号を取得または設定します。
        /// </summary>
        int ModelDesignationNo { get; set; }

        /// <summary>
        /// 車両登録番号（プレート番号）を取得または設定します。
        /// </summary>
        int NumberPlate4 { get; set; }

        /// <summary>
        /// メーカーコードを取得または設定します。
        /// </summary>
        int MakerCode { get; set; }

        /// <summary>
        /// 車種コードを取得または設定します。
        /// </summary>
        int ModelCode { get; set; }

        /// <summary>
        /// 車種サブコードを取得または設定します。
        /// </summary>
        int ModelSubCode { get; set; }

        //--- ADD 2011/09/01 -------------------------------------------->>>
        /// <summary>
        /// 車検証型式を取得または設定します。
        /// </summary>
        string CarInspectCertModel { get; set; }
        //--- ADD 2011/09/01 --------------------------------------------<<<

        /// <summary>
        /// 型式(フル型)を取得または設定します。
        /// </summary>
        string FullModel { get; set; }

        // 2010/03/17 Add >>>
        /// <summary>
        /// リペアカラーコードを取得または設定します。
        /// </summary>
        string RpColorCode { get;set;}

        /// <summary>
        /// 生産年式（NUMタイプ）を取得または設定します。
        /// </summary>
        int ProduceTypeOfYearNum { get;set;}

        /// <summary>
        /// トリムコードを取得または設定します。
        /// </summary>
        string TrimCode { get;set;}
        // 2010/03/17 Add <<<

        // 2011/03/08 Add >>>
        /// <summary>
        /// シャシー№を取得または設定します。
        /// </summary>
        string ChassisNo { get;set;}
        // 2011/03/08 Add <<<

        /// <summary>
        /// 受注ステータスを取得または設定します。
        /// </summary>
        int AcptAnOdrStatus { get; set; }

        /// <summary>
        /// 売上伝票番号を取得または設定します。
        /// </summary>
        string SalesSlipNum { get; set; }
        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        /// <summary>
        /// 号車
        /// </summary>
        string CarNo { get; set; }
        /// <summary>
        /// メーカー名称
        /// </summary>
        string MakerName { get; set; }
        /// <summary>
        /// グレード名称
        /// </summary>
        string GradeName { get; set; }
        /// <summary>
        /// ボディー名称
        /// </summary>
        string BodyName { get; set; }
        /// <summary>
        /// ドア数
        /// </summary>
        int DoorCount { get; set; }
        /// <summary>
        /// エンジン型式名称
        /// </summary>
        string EngineModelNm { get; set; }
        /// <summary>
        /// 通称排気量
        /// </summary>
        int CmnNmEngineDisPlace { get; set; }
        /// <summary>
        /// 原動機型式（エンジン）
        /// </summary>
        string EngineModel { get; set; }
        /// <summary>
        /// 変速段数
        /// </summary>
        int NumberOfGear { get; set; }
        /// <summary>
        /// 変速機名称
        /// </summary>
        string GearNm { get; set; }
        /// <summary>
        /// E区分名称
        /// </summary>
        string EDivNm { get; set; }
        
        /// <summary>
        /// ミッション名称
        /// </summary>
        string TransmissionNm { get; set; }
        /// <summary>
        /// シフト名称
        /// </summary>
        string ShiftNm { get; set; }
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

        // ADD 2012/05/31 -------------------------->>>>>
        /// <summary>
        /// 初年度（NUMタイプ）
        /// </summary>
        Int32 FirstEntryDateNumTyp { get; set; }
        /// <summary>
        /// 車両付加情報オブジェクト
        /// </summary>
        Byte[] CarAddInf { get; set; }
        /// <summary>
        /// 装備部品オブジェクト
        /// </summary>
        Byte[] EquipPrtsObj { get; set; }
        // ADD 2012/05/31 --------------------------<<<<<

        // ADD 2012/06/06 -------------------------->>>>>
        /// <summary>
        /// 車台番号
        /// </summary>
        string FrameNo { get; set; }
        // ADD 2012/06/06 --------------------------<<<<<

        // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
        /// <summary>
        /// 車両管理コード
        /// </summary>
        string CarMngCode { get; set; }
        // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<

        // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
        /// <summary>
        /// 入庫予定日
        /// </summary>
        Int32 ExpectedCeDate { get; set; }
        // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        string ToKey();

        /// <summary>
        /// 売上情報との関連GUID(売上情報との関連付けに用います)
        /// </summary>
        /// <remarks>テーブルレイアウトには存在しません。</remarks>
        Guid SalesRelationId { get; set; }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}
