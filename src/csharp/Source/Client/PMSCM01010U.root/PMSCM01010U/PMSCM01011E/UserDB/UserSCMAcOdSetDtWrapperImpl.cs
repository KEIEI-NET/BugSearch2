//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : qijh  
// 作 成 日  2013/02/27  修正内容 : Redmine#34752
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : SCM障害№10470対応・商品規格・特記事項追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : SCM高速化 PMNS対応 項目追加 メーカー希望小売価格、オープン価格区分
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30746 高川 悟
// 修 正 日  2015/02/20  修正内容 : SCM高速化 C向け種別・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/02/27  修正内容 : SCM高速化 セット品に優良設定詳細コード２、優良設定詳細名称、在庫状況区分追加
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//

using System;
using System.Text;

using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.UIData
{
    using RecordType = Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdSetDt;

    /// <summary>
    /// ユーザーDB SCM受注セット部品データのラッパークラス（実装）
    /// </summary>
    /// <remarks>
    /// お約束の過不足分(主にISCMAcOdSetDtRecordの実装)を実装します。
    /// </remarks>
    public abstract partial class UserSCMAcOdSetDtWrapper
    {
        ///// <summary>
        ///// キーに変換します。
        ///// </summary>
        ///// <returns>キー</returns>
        ///// <see cref="ISCMOrderAnswerRecord"/>
        //public string ToKey()
        //{
        //    return SCMEntityUtil.GetAnswerRecordKey(this);
        //}

        ///// <summary>
        ///// SCM受注データの関連キーに変換します。
        ///// </summary>
        ///// <returns>SCM受注データの関連キー</returns>
        ///// <see cref="ISCMOrderDetailRecord"/>
        //public string ToRelationKey()
        //{
        //    return SCMEntityUtil.GetRelationKey(this);
        //}


        ///// <summary>売上情報との関連GUID</summary>
        //private Guid _salesRelationId = Guid.NewGuid();
        ///// <summary>
        ///// 売上情報との関連GUID(売上情報との関連付けに用います)
        ///// </summary>
        ///// <remarks>テーブルレイアウトには存在しません。</remarks>
        ///// <see cref="ISCMOrderAnswerRecord"/>
        //public Guid SalesRelationId
        //{
        //    get { return _salesRelationId; }
        //    set { _salesRelationId = value; }
        //}

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMAcOdSetDtRecord"/>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
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
                csv.Append(InqOtherEpCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOtherSecCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InquiryNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(SetPartsMkrCd).Append(SCMEntityUtil.COMMA);
                csv.Append(SetPartsNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(SetPartsMainSubNo).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(RecyclePrtKindCode).Append(SCMEntityUtil.COMMA);
                csv.Append(RecyclePrtKindName).Append(SCMEntityUtil.COMMA);
                csv.Append(DeliveredGoodsDiv).Append(SCMEntityUtil.COMMA);
                csv.Append(HandleDivCode).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsShape).Append(SCMEntityUtil.COMMA);
                csv.Append(DelivrdGdsConfCd).Append(SCMEntityUtil.COMMA);
                csv.Append(DeliGdsCmpltDueDate).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerDeliveryDate).Append(SCMEntityUtil.COMMA);
                csv.Append(BLGoodsCode).Append(SCMEntityUtil.COMMA);
                csv.Append(BLGoodsDrCode).Append(SCMEntityUtil.COMMA);
                csv.Append(InqGoodsName).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsGoodsName).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesOrderCount).Append(SCMEntityUtil.COMMA);
                csv.Append(DeliveredGoodsCount).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsNo).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsMakerCd).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsMakerNm).Append(SCMEntityUtil.COMMA);
                csv.Append(PureGoodsMakerCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqPureGoodsNo).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsPureGoodsNo).Append(SCMEntityUtil.COMMA);
                csv.Append(ListPrice).Append(SCMEntityUtil.COMMA);
                csv.Append(UnitPrice).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsAddInfo).Append(SCMEntityUtil.COMMA);
                csv.Append(RoughRrofit).Append(SCMEntityUtil.COMMA);
                csv.Append(RoughRate).Append(SCMEntityUtil.COMMA);
                csv.Append(AnswerLimitDate).Append(SCMEntityUtil.COMMA);
                csv.Append(CommentDtl).Append(SCMEntityUtil.COMMA);
                csv.Append(ShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(PMAcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(PMSalesSlipNum).Append(SCMEntityUtil.COMMA);
                csv.Append(PMSalesRowNo).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                csv.Append(PmMainMngWarehouseCd).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngWarehouseName).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngPrsntCount).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                csv.Append(PmWarehouseCd).Append(SCMEntityUtil.COMMA);
                csv.Append(PmWarehouseName).Append(SCMEntityUtil.COMMA);
                csv.Append(PmShelfNo);
                csv.Append(PmPrsntCount).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
                csv.Append(GoodsSpclInstruction).Append(SCMEntityUtil.COMMA);
                // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
                csv.Append(MkrSuggestRtPric).Append(SCMEntityUtil.COMMA);
                csv.Append(OpenPriceDiv).Append(SCMEntityUtil.COMMA);
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                csv.Append(AnsDeliDateDiv).Append(SCMEntityUtil.COMMA);
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
                csv.Append(GoodsSpecialNtForFac).Append(SCMEntityUtil.COMMA);
                csv.Append(GoodsSpecialNtForCOw).Append(SCMEntityUtil.COMMA);
                csv.Append(PrmSetDtlName2ForFac).Append(SCMEntityUtil.COMMA);
                csv.Append(PrmSetDtlName2ForCOw).Append(SCMEntityUtil.COMMA);
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
                // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
                csv.Append(PrmSetDtlNo2).Append(SCMEntityUtil.COMMA);
                csv.Append(PrmSetDtlName2).Append(SCMEntityUtil.COMMA);
                csv.Append(StockStatusDiv).Append(SCMEntityUtil.COMMA);
                // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                csv.Append(InqBlUtyPtThCd).Append(SCMEntityUtil.COMMA);
                csv.Append(InqBlUtyPtSbCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBlUtyPtThCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBlUtyPtSbCd).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBLGoodsCode).Append(SCMEntityUtil.COMMA);
                csv.Append(AnsBLGoodsDrCode);
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return csv.ToString();
        }
    }
}
