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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/26  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/17  修正内容 : テーブルのレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 配信日なし分 Redmine#34752 PM主管倉庫情報を追加
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
using System;
using System.Text;

using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;   // 2010/05/26 Add

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// ユーザーDB SCM受注明細データ(回答)のラッパークラス（実装）
    /// </summary>
    /// <remarks>
    /// お約束の過不足分(主にISCMOrderAnswerRecordの実装)を実装します。
    /// </remarks>
    public abstract partial class UserSCMOrderAnswerWrapper
    {
        // 2010/05/26 Add >>>
        /// <summary>
        /// PM受注ステータスを取得または設定します。(※USER-DB上の受注ステータスと同じ)
        /// </summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PMAcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        /// <summary>
        /// PM売上伝票番号を取得または設定します。(※USER-DB上の売上伝票番号をと同じ)
        /// </summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PMSalesSlipNum
        {
            get { return TStrConv.StrToIntDef(RealRecord.SalesSlipNum.Trim(), 0); }
            set { RealRecord.SalesSlipNum = string.Format("{0:D9}", value); }
        }

        /// <summary>
        /// PM売上行番号を取得または設定します。(※USER-DB上の売上行番号と同じ)
        /// </summary>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PMSalesRowNo
        {
            get { return RealRecord.SalesRowNo; }
            set { RealRecord.SalesRowNo = value; }
        }
        // 2010/05/26 Add <<<

        /// <summary>回答期限を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime AnswerLimitDate
        {
            get { return RealRecord.AnswerLimitDate; }
            set { RealRecord.AnswerLimitDate = value; }
        }

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        /// <see cref="ISCMOrderAnswerRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetAnswerRecordKey(this);
        }

        /// <summary>
        /// SCM受注データの関連キーに変換します。
        /// </summary>
        /// <returns>SCM受注データの関連キー</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string ToRelationKey()
        {
            return SCMEntityUtil.GetRelationKey(this);
        }

        /// <summary>売上情報との関連GUID</summary>
        private Guid _salesRelationId = Guid.NewGuid();
        /// <summary>
        /// 売上情報との関連GUID(売上情報との関連付けに用います)
        /// </summary>
        /// <remarks>テーブルレイアウトには存在しません。</remarks>
        /// <see cref="ISCMOrderAnswerRecord"/>
        public Guid SalesRelationId
        {
            get { return _salesRelationId; }
            set { _salesRelationId = value; }
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderAnswerRecord"/>
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
                csv.Append(UpdateDate).Append(SCMEntityUtil.COMMA);
                csv.Append(UpdateTime).Append(SCMEntityUtil.COMMA);
                csv.Append(InqRowNumber).Append(SCMEntityUtil.COMMA);
                csv.Append(InqRowNumDerivedNo).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrgDtlDiscGuid).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOthDtlDiscGuid).Append(SCMEntityUtil.COMMA);
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
                csv.Append(AppendingFileDtl).Append(SCMEntityUtil.COMMA);
                csv.Append(AppendingFileNmDtl).Append(SCMEntityUtil.COMMA);
                csv.Append(ShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(AdditionalDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(CorrectDivCD).Append(SCMEntityUtil.COMMA);
                csv.Append(AcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesSlipNum).Append(SCMEntityUtil.COMMA);
                csv.Append(SalesRowNo).Append(SCMEntityUtil.COMMA);
                csv.Append(CampaignCode).Append(SCMEntityUtil.COMMA);
                csv.Append(StockDiv).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                csv.Append(PmMainMngWarehouseCd).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngWarehouseName).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(PmMainMngPrsntCount).Append(SCMEntityUtil.COMMA);
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(DisplayOrder).Append(SCMEntityUtil.COMMA);
                // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                //csv.Append(GoodsMngNo);
                // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                csv.Append(GoodsMngNo).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                //csv.Append(CancelCndtinDiv);
                csv.Append( CancelCndtinDiv ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMAcptAnOdrStatus ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMSalesSlipNum ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMSalesRowNo ).Append( SCMEntityUtil.COMMA );
                csv.Append( DtlTakeinDivCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseName ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmShelfNo );
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                csv.Append(CampaignCode).Append(SCMEntityUtil.COMMA); // ADD 2011/10/10
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
