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
// 作 成 日  2013/04/19  修正内容 : 障害№10521 SCM受注データ(車両情報)の車両管理コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : 障害№10384 SCM受注データ(車両情報)に入庫予定日を追加
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ユーザーDB SCM受注データ(車両情報)のラッパークラス（実装）
    /// </summary>
    /// <remarks>
    /// お約束の過不足分(主にISCMOrderCarRecordの実装)を実装します。
    /// </remarks>
    public abstract partial class UserSCMOrderCarWrapper
    {
        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        /// <see cref="ISCMOrderCarRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetCarRecordKey(this);
        }

        /// <summary>売上情報との関連GUID</summary>
        private Guid _salesRelationId = Guid.NewGuid();
        /// <summary>
        /// 売上情報との関連GUID(売上情報との関連付けに用います)
        /// </summary>
        /// <remarks>テーブルレイアウトには存在しません。</remarks>
        /// <see cref="ISCMOrderCarRecord"/>
        public Guid SalesRelationId
        {
            get { return _salesRelationId; }
            set { _salesRelationId = value; }
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderCarRecord"/>
        public string ToCSV()
        {
            StringBuilder csv = new StringBuilder();
            {
                csv.Append(CreateDateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateDateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(EnterpriseCode).Append(SCMEntityUtil.COMMA);
                csv.Append(FileHeaderGuid).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdEmployeeCode).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdAssemblyId1).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdAssemblyId2).Append(SCMEntityUtil.COMMA);
                csv.Append(LogicalDeleteCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOriginalEpCd.Trim()).Append(SCMEntityUtil.COMMA);//@@@@20230303
                csv.Append(InqOriginalSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate1Code).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate1Name).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate2).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate3).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberPlate4).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelDesignationNo).Append(SCMEntityUtil.COMMA);
                csv.Append(CategoryNo).Append(SCMEntityUtil.COMMA);
                csv.Append(MakerCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelSubCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ModelName).Append(SCMEntityUtil.COMMA);
                csv.Append(CarInspectCertModel).Append(SCMEntityUtil.COMMA);
                csv.Append(FullModel).Append(SCMEntityUtil.COMMA);
                csv.Append(FrameNo).Append(SCMEntityUtil.COMMA);
                csv.Append(FrameModel).Append(SCMEntityUtil.COMMA);
                csv.Append(ChassisNo).Append(SCMEntityUtil.COMMA);
                csv.Append(CarProperNo).Append(SCMEntityUtil.COMMA);
                csv.Append(ProduceTypeOfYearNum).Append(SCMEntityUtil.COMMA);
                csv.Append(Comment).Append(SCMEntityUtil.COMMA);
                csv.Append(RpColorCode).Append(SCMEntityUtil.COMMA);
                csv.Append(ColorName1).Append(SCMEntityUtil.COMMA);
                csv.Append(TrimCode).Append(SCMEntityUtil.COMMA);
                csv.Append(TrimName).Append(SCMEntityUtil.COMMA);
                csv.Append(Mileage).Append(SCMEntityUtil.COMMA);
                csv.Append(EquipObj).Append(SCMEntityUtil.COMMA);
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
                csv.Append(CarNo).Append(SCMEntityUtil.COMMA);
                csv.Append(MakerName).Append(SCMEntityUtil.COMMA);
                csv.Append(GradeName).Append(SCMEntityUtil.COMMA);
                csv.Append(BodyName).Append(SCMEntityUtil.COMMA);
                csv.Append(DoorCount).Append(SCMEntityUtil.COMMA);
                csv.Append(EngineModelNm).Append(SCMEntityUtil.COMMA);
                csv.Append(CmnNmEngineDisPlace).Append(SCMEntityUtil.COMMA);
                csv.Append(EngineModel).Append(SCMEntityUtil.COMMA);
                csv.Append(NumberOfGear).Append(SCMEntityUtil.COMMA);
                csv.Append(GearNm).Append(SCMEntityUtil.COMMA);
                csv.Append(EDivNm).Append(SCMEntityUtil.COMMA);
                csv.Append(TransmissionNm).Append(SCMEntityUtil.COMMA);
                csv.Append(ShiftNm).Append(SCMEntityUtil.COMMA);
                // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
                // ADD 2012/05/31--------------------------->>>>>
                csv.Append(FirstEntryDateNumTyp).Append(SCMEntityUtil.COMMA);
                csv.Append(CarAddInf).Append(SCMEntityUtil.COMMA);
                csv.Append(EquipPrtsObj).Append(SCMEntityUtil.COMMA);
                // ADD 2012/05/31---------------------------<<<<<
                // ADD 2013/04/19 SCM障害№10521対応 ----------------------------------->>>>>
                csv.Append(CarMngCode).Append(SCMEntityUtil.COMMA);
                // ADD 2013/04/19 SCM障害№10521対応 -----------------------------------<<<<<
                // ADD 2013/05/09 SCM障害№10384対応 ----------------------------------->>>>>
                csv.Append(ExpectedCeDate).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/09 SCM障害№10384対応 -----------------------------------<<<<<
                csv.Append(SalesSlipNum);
            }
            return csv.ToString();
        }
    }
}
