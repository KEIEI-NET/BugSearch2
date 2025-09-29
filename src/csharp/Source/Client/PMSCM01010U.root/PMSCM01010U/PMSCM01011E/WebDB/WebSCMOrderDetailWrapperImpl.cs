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
// 管理番号  10801804-00 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/04/12  修正内容 : 障害№170 PS管理番号項目追加
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
using System;
using System.Text;
using Broadleaf.Library.Text;   // 2010/05/26 Add

using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData.WebDB
{
    /// <summary>
    /// Web-DB SCM受注明細データ(問合せ・発注)のラッパークラス（実装）
    /// </summary>
    /// <remarks>
    /// お約束の過不足分(主にISCMOrderDetailRecordの実装)を実装します。
    /// </remarks>
    public abstract partial class WebSCMOrderDetailWrapper
    {
        /// <summary>
        /// 企業コードを取得または設定します。(※Web-DBには存在しません)
        /// </summary>
        /// <remarks>
        /// 問合せ先企業コードを取得または設定します。
        /// </remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string EnterpriseCode
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        // 2010/05/26 Del >>>
        ///// <summary>受注ステータス</summary>
        //private int _acptAnOdrStatus;
        // 2010/05/26 Del <<<

        /// <summary>
        /// 受注ステータスを取得または設定します。(※Web-DB上のPM受注ステータスと同じ)
        /// </summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int AcptAnOdrStatus
        {
            // 2010/05/26 >>>
            //get { return _acptAnOdrStatus; }
            //set { _acptAnOdrStatus = value; }
            get { return RealRecord.PMAcptAnOdrStatus; }
            set { RealRecord.PMAcptAnOdrStatus = value; }
            // 2010/05/26 <<<
        }

        // 2010/05/26 Del >>>
        ///// <summary>売上伝票番号</summary>
        //private string _salesSlipNum;
        // 2010/05/26 Del <<<
        /// <summary>
        /// 売上伝票番号を取得または設定します。(※Web-DB上のPM売上伝票番号をと同じ)
        /// </summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string SalesSlipNum
        {
            // 2010/05/26 >>>
            //get { return _salesSlipNum; }
            //set { _salesSlipNum = value; }
            get { return string.Format("{0:D9}", RealRecord.PMSalesSlipNum); }
            set { RealRecord.PMSalesSlipNum = TStrConv.StrToIntDef(value.Trim(), 0); }
            // 2010/05/26 <<<
        }

        // 2010/05/26 Add >>>
        /// <summary>
        /// 売上行番号を取得または設定します。(※Web-DB上の売上行番号と同じ)
        /// </summary>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int SalesRowNo
        {
            get { return RealRecord.PMSalesRowNo; }
            set { RealRecord.PMSalesRowNo = value; }
        }
        // 2010/05/26 Add <<<
        // --- ADD 吉岡 2012/04/12 №170 ---------->>>>>
        /// <summary>
        /// PS管理番号
        /// </summary>
        /// <see cref="ISCMOrderDetailRecord"/>
        public int PsMngNo
        {
            get { return RealRecord.PSMngNo; }
            set { RealRecord.PSMngNo = value; }
        }
        // --- ADD 吉岡 2012/04/12 №170 ----------<<<<<

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string ToKey()
        {
            return SCMEntityUtil.GetDetailRecordKey(this);
        }

        /// <summary>
        /// SCM受注データ(車両情報)のキーに変換します。
        /// </summary>
        /// <returns>SCM受注データ(車両情報)のキー</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
        public string ToCarKey()
        {
            return SCMEntityUtil.GetCarRecordKey(this);
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

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        /// <see cref="ISCMOrderDetailRecord"/>
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
                csv.Append(ShelfNo).Append(SCMEntityUtil.COMMA);
                csv.Append(AdditionalDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(CorrectDivCD).Append(SCMEntityUtil.COMMA);
                csv.Append(InqOrdDivCd).Append(SCMEntityUtil.COMMA);
                csv.Append(DisplayOrder).Append(SCMEntityUtil.COMMA);
                // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                //csv.Append(LatestDiscCode);
                // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                csv.Append(LatestDiscCode).Append(SCMEntityUtil.COMMA);
                csv.Append(CancelCndtinDiv).Append(SCMEntityUtil.COMMA);
                csv.Append(PMAcptAnOdrStatus).Append(SCMEntityUtil.COMMA);
                csv.Append(PMSalesSlipNum).Append(SCMEntityUtil.COMMA);
                // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                //csv.Append(PMSalesRowNo);
                csv.Append( DtlTakeinDivCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PMSalesRowNo ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseCd ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmWarehouseName ).Append( SCMEntityUtil.COMMA );
                csv.Append( PmShelfNo );
                // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                // --- ADD 2011/10/10 ---------->>>>>
                csv.Append(CampaignCode).Append(SCMEntityUtil.COMMA);
                // --- ADD 2011/10/10 ----------<<<<<
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
