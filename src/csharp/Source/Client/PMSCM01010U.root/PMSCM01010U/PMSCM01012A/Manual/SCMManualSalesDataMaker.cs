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
// 作 成 日  2009/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/04/20  修正内容 : 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : 売上明細データ.明細備考のセット仕様を変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangqx
// 作 成 日  2013/02/18  修正内容 : 2013/03/13配信分　 システム障害 管理№267対応
//                                  問合せデータを呼出発注を行った際、発注日に問合日がセットされる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/03/07  修正内容 : SCM障害№10489対応 
//                                  手動回答時で品番検索で該当なしの時、売上伝票入力の明細が正常に表示されない障害の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/08/07  修正内容 : PM-SCM仕掛一覧№10556対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2014/01/16  修正内容 : 純正定価印字対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Manual
{
    /// <summary>
    /// SCM手動回答用売上データ作成処理クラス
    /// </summary>
    public sealed class SCMManualSalesDataMaker : SCMSalesDataMaker
    {
        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="referee">SCM回答判定処理</param>
        public SCMManualSalesDataMaker(SCMReferee referee) : base(referee) { }

        #endregion // </Constructor>

        #region <Override>

        /// <summary>
        /// 売上リストの生成者を生成します。
        /// </summary>
        /// <returns>売上リストの生成者</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override SCMSalesListEssence CreateSCMSalesListEssence()
        {
            return new SCMManualSalesListEssence();
        }

        /// <summary>
        /// 売上データを作成可能か判断します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>
        /// <c>true</c> :作成できます。<br/>
        /// <c>false</c>:作成できません。
        /// </returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override bool CanMakeSalesData(ISCMOrderAnswerRecord answerRecord)
        {
            return true;
        }

        #region <SCM受注データ>

        /// <summary>
        /// SCM受注データを回答用にコピーおよび編集します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>回答用に編集したSCM受注データのレコード</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override Broadleaf.Application.UIData.ISCMOrderHeaderRecord CopyAndEditSCMOrderHeaderRecord(Broadleaf.Application.UIData.ISCMOrderHeaderRecord headerRecord)
        {
            UserSCMOrderHeaderRecord userHeaderRecord = base.CopyAndEditSCMOrderHeaderRecord(
                headerRecord
            ) as UserSCMOrderHeaderRecord;
            {
                // 036.回答作成区分(0:自動, 1:手動(Web), 2:手動(その他))
                if (userHeaderRecord.AnswerCreateDiv.Equals((int)AnswerCreateDivValue.Auto))
                {
                    userHeaderRecord.AnswerCreateDiv = (int)AnswerCreateDivValue.ManualWeb;
                }
            }
            return userHeaderRecord;
        }

        #endregion // </SCM受注データ>

        // ↓品番検索でヒットしなかった場合を含む
        #region <SCM受注明細データ(回答)>

        /// <summary>
        /// SCM受注明細データ(回答)を編集します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <param name="scmGoodsUnitData">付加情報付き商品連結データ</param>
        /// <returns>編集したSCM受注明細データ(回答)のレコード</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override ISCMOrderAnswerRecord EditSCMOrderAnswerRecord(
            ISCMOrderAnswerRecord answerRecord,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // 品番検索でヒットしなかった場合
            {
                // SCM受注明細データ(問合せ・発注)をほぼコピーした状態で返す
                UserSCMOrderAnswerRecord userAnswerRecord = answerRecord as UserSCMOrderAnswerRecord;
                {
                    if (userAnswerRecord == null)
                    {
                        Debug.Assert(false, "User型のSCM受注明細データ(回答)ではありません。");
                        return answerRecord;
                    }

                    // 001.作成日時         …共通ヘッダ リモート取得
                    // 002.更新日時         …共通ヘッダ リモート取得
                    userAnswerRecord.EnterpriseCode = answerRecord.InqOtherEpCd;    // 003.企業コード…共通ヘッダ リモート取得
                    // 004.GUID             …共通ヘッダ リモート取得
                    // 005.更新従業員コード …共通ヘッダ リモート取得
                    // 006.更新アセンブリID1…共通ヘッダ リモート取得
                    // 007.更新アセンブリID2…共通ヘッダ リモート取得
                    // 008.論理削除区分     …共通ヘッダ リモート取得

                    // 009.問合せ元企業コード   …SCM受注明細データ(問合せ・発注)
                    // 010.問合せ元拠点コード   …SCM受注明細データ(問合せ・発注)
                    // 011.問合せ先企業コード   …SCM受注明細データ(問合せ・発注)
                    // 012.問合せ先拠点コード   …SCM受注明細データ(問合せ・発注)
                    // 013.問合せ番号           …SCM受注明細データ(問合せ・発注)

                    userAnswerRecord.UpdateDate = DateTime.MinValue;    // 014.更新年月日       …リモート取得
                    userAnswerRecord.UpdateTime = 0;                    // 015.更新時分秒ミリ秒 …リモート取得

                    // 016.問合せ行番号…SCM受注明細データ(問合せ・発注)

                    // 017.問合せ行番号枝番…連番付番(問合せ行番号単位)
                    userAnswerRecord.InqRowNumDerivedNo = NextRowNumDerivedNo(scmGoodsUnitData.SourceDetailRecord);

                    // 018.問合せ元明細識別GUID…SCM受注明細データ(問合せ・発注)
                    // 019.問合せ先明細識別GUID…SCM受注明細データ(問合せ・発注)

                    // HACK:userAnswerRecord.GoodsDivCd = scmGoodsUnitData.GetGoodsDivCd(true);                 // 020.商品種別                 …商品情報(GoodsUnitData)と相場情報からセット
                    // HACK:userAnswerRecord.RecyclePrtKindCode = scmGoodsUnitData.GetRecyclePrtKindCode(true); // 021.リサイクル部品種別       …商品情報(GoodsUnitData)と相場情報からセット
                    // HACK:userAnswerRecord.RecyclePrtKindName = scmGoodsUnitData.GetRecyclePrtKindName(true); // 022.リサイクル部品種別名称   …商品情報(GoodsUnitData)と相場情報からセット

                    // 023.納品区分     …SCM受注明細データ(問合せ・発注)
                    // 024.取扱区分     …SCM受注明細データ(問合せ・発注)
                    // 025.商品形態     …SCM受注明細データ(問合せ・発注)
                    // 026.納品確認区分 …SCM受注明細データ(問合せ・発注)
                    // 027.納品完了予定日

                    // HACK:userAnswerRecord.AnswerDeliveryDate = scmGoodsUnitData.GetAnswerDeliveryDate(); // 028.回答納期…SCM納期設定マスタ

                    // BLコードはSCM受注明細データ(問合せ・発注)の値のまま
                    //userAnswerRecord.BLGoodsCode = scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode;  // 029.BL商品コード…商品情報(GoodsUnitData)
                    // HACK:030.BL商品コード枝番…商品情報(GoodsUnitData) ※商品情報にない？
                    //userAnswerRecord.BLGoodsDrCode = scmGoodsUnitData.RealGoodsUnitData.BLGoodsDrCode;

                    // FIXME:031.問発商品名…SCM受注明細データ(問合せ・発注)？

                    //userAnswerRecord.AnsGoodsName = scmGoodsUnitData.RealGoodsUnitData.GoodsName;   // 032.回答商品名…商品情報(GoodsUnitData)

                    // 033.発注数…SCM受注明細データ(問合せ・発注)

                    // HACK:userAnswerRecord.DeliveredGoodsCount = userAnswerRecord.SalesOrderCount;    // 034.納品数…SCM受注明細データ(問合せ・発注).発注数

                    // HACK:userAnswerRecord.GoodsNo = scmGoodsUnitData.RealGoodsUnitData.GoodsNo;              // 035.商品番号             …商品情報(GoodsUnitData)
                    // HACK:userAnswerRecord.GoodsMakerCd = scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd;    // 036.商品メーカーコード   …商品情報(GoodsUnitData)
                    // HACK:userAnswerRecord.GoodsMakerNm = scmGoodsUnitData.RealGoodsUnitData.MakerName;       // 037.商品メーカー名称
                    // HACK:userAnswerRecord.PureGoodsMakerCd = scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd;// FIXME:038.純正商品メーカーコード

                    // 039.問発純正商品番号…SCM受注明細データ(問合せ・発注)
                    // HACK:userAnswerRecord.AnsPureGoodsNo = scmGoodsUnitData.RealGoodsUnitData.GoodsNo;   // FIXME:040.回答純正商品番号

                    // HACK:userAnswerRecord.ListPrice = scmGoodsUnitData.GetListPrice();   // 041.定価…算出
                    // HACK:userAnswerRecord.UnitPrice = scmGoodsUnitData.GetUnitPrice();   // 042.単価…算出

                    // 043.商品補足情報…SCM受注明細データ(問合せ・発注)

                    // HACK:userAnswerRecord.RoughRrofit = scmGoodsUnitData.GetRoughRrofit();   // 044.粗利額…算出
                    // HACK:userAnswerRecord.RoughRate = scmGoodsUnitData.GetRoughRate();       // 045.粗利率…算出

                    // 046.回答期限     …SCM受注明細データ(問合せ・発注)
                    // 047.備考(明細)   …SCM受注明細データ(問合せ・発注)
                    // 048.添付ファイル(明細)   …未使用
                    // 049.添付ファイル名(明細) …未使用

                    // HACK:050.棚番…商品情報(GoodsUnitData) ※在庫委託の場合のみセット
                    //if (scmGoodsUnitData.GetStockDiv().Equals((int)StockDiv.Trust))
                    //{
                    //    userAnswerRecord.ShelfNo = scmGoodsUnitData.GetShelfNo();
                    //}

                    // 051.追加区分…SCM受注明細データ(問合せ・発注)
                    // 052.訂正区分…SCM受注明細データ(問合せ・発注)

                    // HACK:userAnswerRecord.AcptAnOdrStatus = scmGoodsUnitData.GetAcptAnOdrStatus();           // 053.受注ステータス…算出
                    userAnswerRecord.AcptAnOdrStatus = SCMDataHelper.GetDefaultAcptAnOdrStatus(userAnswerRecord.InqOrdDivCd);
                    userAnswerRecord.SalesSlipNum = DEFAULT_SALES_SLIP_NUM;                             // 054.売上伝票番号…リモート取得
                    userAnswerRecord.SalesRowNo = userAnswerRecord.InqRowNumDerivedNo;                  // 055.売上行番号…連番付番(売上伝票番号単位)
                    // HACK:userAnswerRecord.CampaignCode = scmGoodsUnitData.CampaignInformation.CampaignCode;  // 056.キャンペーンコード…算出
                    // HACK:userAnswerRecord.StockDiv = scmGoodsUnitData.GetStockDiv();                         // 057.在庫区分…算出
                    userAnswerRecord.StockDiv = (int)StockDiv.None;

                    // 058.問合せ・発注種別 …SCM受注明細データ(問合せ・発注)
                    // 059.表示順位         …SCM受注明細データ(問合せ・発注)
                    // 060.商品管理番号     …SCM受注明細データ(問合せ・発注)
                }
                // ADD 2013/03/07 SCM障害№10489対応 ----------------------------------------------------------->>>>>
                // 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注
                answerRecord.AcptAnOdrStatus = answerRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry)
                    ?
                (int)AcptAnOdrStatus.Estimate : (int)AcptAnOdrStatus.Order;
                // 品名のみで品番検索できなかった時
                if (userAnswerRecord.GoodsNo.Length.Equals(0) && !userAnswerRecord.InqGoodsName.Length.Equals(0))
                {
                    // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // userAnswerRecord.AnswerDeliveryDate = scmGoodsUnitData.GetAnswerDeliveryDate((int)FuwioutAutoAnsDiv.None); // 028.回答納期…SCM納期設定マスタ
                    Int16 ansDeliDateDiv = 0;
                    userAnswerRecord.AnswerDeliveryDate = scmGoodsUnitData.GetAnswerDeliveryDate((int)FuwioutAutoAnsDiv.None,out ansDeliDateDiv); // 028.回答納期…SCM納期設定マスタ
                    userAnswerRecord.AnsDeliDateDiv = ansDeliDateDiv;   // 回答納期区分
                    // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                }
                // ADD 2013/03/07 SCM障害№10489対応 -----------------------------------------------------------<<<<<
                return userAnswerRecord;
            }   // if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // 品番検索でヒットしなかった場合
            // DEL 2010/04/20 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注 ---------->>>>>
            //return base.EditSCMOrderAnswerRecord(answerRecord, scmGoodsUnitData);
            // DEL 2010/04/20 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注 ----------<<<<<
            // ADD 2010/04/20 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注 ---------->>>>>
            base.EditSCMOrderAnswerRecord(answerRecord, scmGoodsUnitData);

            // 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注
            answerRecord.AcptAnOdrStatus = answerRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry)
                ?
            (int)AcptAnOdrStatus.Estimate : (int)AcptAnOdrStatus.Order;
            
            return answerRecord;
            // ADD 2010/04/20 手動回答の場合、受注ステータスは 問合せ・発注種別：問合せ→見積、問合せ・発注種別：発注→受注 ----------<<<<<
        }

        #endregion // <SCM受注明細データ(回答)>

        // ↓品番検索でヒットしなかった場合を含む
        #region <売上明細データ>

        /// <summary>
        /// 売上明細データを生成します。
        /// </summary>
        /// <param name="scmGoodsUnitData">SCM用の情報付商品連結データ</param>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <param name="carRecord">SCM受注データ(車両情報)のレコード</param>
        /// <param name="enmDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>売上明細データ</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override SalesDetail CreateSalesDetail(
            SCMGoodsUnitData scmGoodsUnitData,
            ISCMOrderAnswerRecord answerRecord,
            ISCMOrderHeaderRecord headerRecord,
            ISCMOrderCarRecord carRecord
          , ISCMOrderDetailRecord enmDetailRecord // ADD 2014/01/16 T.Miyamoto
        )
        {
            // ----ADD 2013/02/18 wangqx 管理№267---- >>>>>
            DateTime getServerNowTime;
            SalesSlipInputAcs salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            getServerNowTime = salesSlipInputAcs.GetServerNowTime;
            // ----ADD 2013/02/18 wangqx 管理№267---- <<<<<

            if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // 品番検索でヒットしなかった場合
            {
                UserSCMOrderAnswerRecord userAnswerRecord = answerRecord as UserSCMOrderAnswerRecord;

                // SCM受注系データのみで生成する
                SalesDetail salesDetail = new SalesDetail();
                {
                    // 001.作成日時         …共通ヘッダ　リモート取得
                    // 002.更新日時         …共通ヘッダ　リモート取得
                    salesDetail.EnterpriseCode = userAnswerRecord.InqOtherEpCd; // 003.企業コード…共通ヘッダ　リモート取得
                    // 004.GUID             …共通ヘッダ　リモート取得
                    // 005.更新従業員コード …共通ヘッダ　リモート取得
                    // 006.更新アセンブリID1…共通ヘッダ　リモート取得
                    // 007.更新アセンブリID2…共通ヘッダ　リモート取得
                    // 008.論理削除区分     …共通ヘッダ　リモート取得

                    // 009.受注番号…リモート取得
                    salesDetail.AcptAnOdrStatus = userAnswerRecord.AcptAnOdrStatus; // 010.受注ステータス   …30:売上, 20:受注, 10:見積
                    salesDetail.SalesSlipNum = DEFAULT_SALES_SLIP_NUM;              // 011.売上伝票番号     …リモート取得
                    salesDetail.SalesRowNo = userAnswerRecord.InqRowNumDerivedNo;   // 012.売上行番号       …連番
                    salesDetail.SalesRowDerivNo = 0;                                // 013.売上行番号枝番   …0
                    salesDetail.SectionCode = userAnswerRecord.InqOtherSecCd;       // 014.拠点コード       …ログイン拠点
                    salesDetail.SubSectionCode = GetSubSectionCode(headerRecord);   // 015.部門コード       …SCM受注データの回答従業員の所属部門コード
                    salesDetail.SalesDate = headerRecord.InquiryDate;               // 016.売上日付         …SCM受注データの問合せ日
                    // ----ADD 2013/02/18 wangqx 管理№267---- >>>>>
                    // 受注場合、売上明細データ伝票の売上日付はサーバー日付で設定する
                    if (headerRecord.InqOrdDivCd == (int)InqOrdDivCdValue.Ordering)
                    {
                        salesDetail.SalesDate = getServerNowTime;               // 016.売上日付         …システム日付
                    }
                    // ----ADD 2013/02/18 wangqx 管理№267---- <<<<<
                    // 017.共通通番     …リモート取得
                    // 018.売上明細通番 …リモート取得
                    // 019.受注ステータス(元)
                    // 020.売上明細通番(元)
                    // 021.仕入形式(同時)
                    // 022.仕入明細通番(元)
                    salesDetail.SalesSlipCdDtl = 0; // 023.売上伝票区分(明細)…0:売上
                    // 024.納品完了予定日

                    // 025.商品属性 
                    salesDetail.GoodsSearchDivCd = 2;                           // 026.商品検索区分         …2:手入力
                    salesDetail.GoodsMakerCd = userAnswerRecord.GoodsMakerCd;   // 027.商品メーカーコード   …SCM受注明細データ(問合せ・発注).商品メーカーコード
                    salesDetail.MakerName = userAnswerRecord.GoodsMakerNm;      // 028.メーカー名称         …SCM受注明細データ(問合せ・発注).商品メーカー名称
                    // 029.メーカーカナ名称
                    salesDetail.GoodsNo = userAnswerRecord.GoodsNo;             // 030.商品番号             …SCM受注明細データ(問合せ・発注).商品番号
                    salesDetail.GoodsName = userAnswerRecord.InqGoodsName;      // 031.商品名称             …SCM受注明細データ(問合せ・発注).問発商品名
                    
                    // 032.商品名称カナ
                    // 033.商品大分類コード
                    // 034.商品大分類名称
                    // 035.商品中分類コード
                    // 036.商品中分類名称
                    // 037.BLグループコード
                    // 038.BLグループコード名称
                    salesDetail.BLGoodsCode = userAnswerRecord.BLGoodsCode; // 039.BL商品コード

                    // 040.BL商品コード名称(全角)
                    // 041.自社分類コード
                    // 042.自社分類名称
                    // 043.倉庫コード
                    // 044.倉庫名称
                    // 045.倉庫棚番
                    // 046.売上在庫取寄せ区分
                    // 047.オープン価格区分
                    // 048.商品掛率ランク

                    salesDetail.CustRateGrpCode = GetCustRateGrpCode(headerRecord, userAnswerRecord.GoodsMakerCd);  // 049.得意先掛率グループコード …得意先掛率グループマスタ

                    // 050.定価率
                    // 051.掛率設定拠点(定価)
                    // 052.掛率設定区分(定価)
                    // 053.単価算出区分(定価)
                    // 054.価格区分(定価)
                    // 055.基準単価(定価)
                    // 056.端数処理単位(定価)
                    // 057.端数処理(定価)
                    salesDetail.ListPriceTaxIncFl = userAnswerRecord.ListPrice; // HACK:058.定価(税込,浮動)  …算出
                    salesDetail.ListPriceTaxExcFl = userAnswerRecord.ListPrice; // 059.定価(税抜,浮動)  …SCM受注明細データ(問合せ・発注).定価
                    salesDetail.ListPriceChngCd = 0;                            // 060.定価変更区分     …0:変更なし

                    // 061.売価率
                    // 062.掛率設定拠点(売価)
                    // 063.掛率設定区分(売価)
                    // 064.単価算出区分(売価)
                    // 065.価格区分(売価)
                    // 066.基準単価(売価)
                    // 067.端数処理単位(売価)
                    // 068.端数処理(売価)
                    salesDetail.SalesUnPrcTaxIncFl = userAnswerRecord.UnitPrice;    // HACK:069.売価(税込,浮動)  …算出
                    salesDetail.SalesUnPrcTaxExcFl = userAnswerRecord.UnitPrice;    // 070.売価(税抜,浮動)  …SCM受注明細データ(問合せ・発注).単価
                    salesDetail.SalesUnPrcChngCd = 0;                               // 071.売価変更区分     …0:変更なし

                    // 072.原価率
                    // 073.掛率設定拠点(原価単価)
                    // 074.掛率設定区分(原価単価)
                    // 075.単価算出区分(原価単価)
                    // 076.価格区分(原価単価)
                    // 077.基準単価(原価単価)
                    // 078.端数処理単位(原価単価)
                    // 079.端数処理(原価単価)
                    // 080.原価単価
                    // 081.原価単価変更区分

                    // 082.BL商品コード(掛率)
                    // 083.BL商品コード名称(掛率)
                    // 084.商品掛率グループコード(掛率)
                    // 085.商品掛率グループ名称(掛率)
                    // 086.BLグループコード(掛率)
                    // 087.BLグループ名称(掛率)
                    // 088.BL商品コード(印刷)
                    // 088.BL商品コード(印刷)
                    // 089.BL商品コード名称(印刷)
                    // 090.販売区分コード
                    // 091.販売区分名称
                    // 092.作業工数

                    salesDetail.ShipmentCnt = scmGoodsUnitData.SourceDetailRecord.SalesOrderCount;          // 093.出荷数       …SCM受注明細データ(問合せ・発注)の発注数
                    salesDetail.AcceptAnOrderCnt = scmGoodsUnitData.SourceDetailRecord.SalesOrderCount;     // 094.受注数量     …SCM受注明細データ(問合せ・発注)の発注数
                    salesDetail.AcptAnOdrAdjustCnt = 0;                                                     // 095.受注調整数   …0
                    salesDetail.AcptAnOdrRemainCnt = scmGoodsUnitData.SourceDetailRecord.SalesOrderCount;   // 096.受注残数     …SCM受注明細データ(問合せ・発注)の発注数

                    // 097.残数更新日…リモート取得

                    // --- DEL 2013/08/07 Y.Wakita ---------->>>>>
                    //salesDetail.SalesMoneyTaxInc = (long)(salesDetail.SalesUnPrcTaxIncFl * salesDetail.ShipmentCnt);    // FIXME:098.売上金額(税込み)   …算出
                    //salesDetail.SalesMoneyTaxExc = (long)(salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt);    // FIXME:099.売上金額(税抜き)   …算出
                    // --- DEL 2013/08/07 Y.Wakita ----------<<<<<
                    // --- ADD 2013/08/07 Y.Wakita ---------->>>>>
                    SCMPriceCalculator priceCalculator = new SCMPriceCalculator();

                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                    //priceCalculator.SetCurrentSCMOrderData(headerRecord.CustomerCode, salesDetail);
                    priceCalculator.SetCurrentSCMOrderData(headerRecord.CustomerCode, salesDetail, headerRecord.CancelDiv, headerRecord.InquiryDate);
                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<

                    double salesMoneyTaxInc = 0;
                    double salesMoneyTaxExc = 0;

                    priceCalculator.CalcPrice(salesDetail.TaxationDivCd,
                                              (salesDetail.SalesUnPrcTaxExcFl * salesDetail.ShipmentCnt),
                                              out salesMoneyTaxExc,
                                              out salesMoneyTaxInc);

                    salesDetail.SalesMoneyTaxInc = (long)salesMoneyTaxInc;    // FIXME:098.売上金額(税込み)   …算出
                    salesDetail.SalesMoneyTaxExc = (long)salesMoneyTaxExc;    // FIXME:099.売上金額(税抜き)   …算出
                    // --- ADD 2013/08/07 Y.Wakita ----------<<<<<
                    salesDetail.Cost = (long)(salesDetail.SalesUnitCost * salesDetail.ShipmentCnt);                     // FIXME:100.原価               …算出

                    // 101.粗利チェック区分

                    salesDetail.SalesGoodsCd = 0;   // 102.売上商品区分…0:商品
                    salesDetail.SalesPriceConsTax = salesDetail.SalesMoneyTaxInc - salesDetail.SalesMoneyTaxExc;    // 103.売上金額消費税額…算出
                    salesDetail.TaxationDivCd = 0;   // 104.課税区分…0:課税

                    // 105.相手先伝票番号(明細)
                    // --- UPD m.suzuki 2011/05/23 ---------->>>>>
                    //// 106.明細備考
                    salesDetail.DtlNote = userAnswerRecord.CommentDtl; // 106.明細備考 ← 備考(明細)
                    // --- UPD m.suzuki 2011/05/23 ----------<<<<<
                    // 107.仕入先コード
                    // 108.仕入先名称
                    // 109.発注番号
                    // 110.注文方法
                    // 111.伝票メモ1
                    // 112.伝票メモ2
                    // 113.伝票メモ3
                    // 114.社内メモ1
                    // 115.社内メモ2
                    // 116.社内メモ3

                    salesDetail.BfListPrice = userAnswerRecord.ListPrice;       // 117.変更前定価…SCM受注明細データ(問合せ・発注).定価
                    salesDetail.BfSalesUnitPrice = userAnswerRecord.UnitPrice;  // 118.変更前売価…SCM受注明細データ(問合せ・発注).単価
                    // 119.変更前原価

                    // 120.一式明細番号
                    // 121.メーカーコード(一式)
                    // 122.メーカー名称(一式)
                    // 123.メーカーカナ名称(一式)
                    // 124.商品名称(一式)
                    // 125.数量(一式)
                    // 126.売上単価(一式)
                    // 127.売上金額(一式)
                    // 128.原価単価(一式)
                    // 129.原価金額(一式)
                    // 130.相手先伝票番号(一式)
                    // 131.一式備考

                    salesDetail.PrtGoodsNo = userAnswerRecord.GoodsNo;          // 132.印刷用品番           …SCM受注明細データ(問合せ・発注).品番
                    salesDetail.PrtMakerCode = userAnswerRecord.GoodsMakerCd;   // 133.印刷用メーカーコード …SCM受注明細データ(問合せ・発注).商品メーカーコード
                    salesDetail.PrtMakerName = userAnswerRecord.GoodsMakerNm;   // 134.印刷用メーカー名称   …SCM受注明細データ(問合せ・発注).商品メーカー名称

                    // 明細共通GUID
                    salesDetail.DtlRelationGuid = userAnswerRecord.SalesRelationId;
                    // 車両共通GUID
                    salesDetail.CarRelationGuid = carRecord.SalesRelationId;
                    // ADD 2013/03/07 SCM障害№10489 ---------------------------------------------->>>>>
                    salesDetail.AnswerDelivDate = userAnswerRecord.AnswerDeliveryDate; // 138.回答納期　　　　　　 …SCM受注明細データ(回答)
                    // ADD 2013/03/07 SCM障害№10489 ----------------------------------------------<<<<<
                }
                return salesDetail;
            }   // if (scmGoodsUnitData.RealGoodsUnitData is NullGoodsUnitData)    // 品番検索でヒットしなかった場合
            // UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
            //return base.CreateSalesDetail(scmGoodsUnitData, answerRecord, headerRecord, carRecord);
            return base.CreateSalesDetail(scmGoodsUnitData, answerRecord, headerRecord, carRecord, enmDetailRecord);
            // UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
        }

        #endregion // </売上明細データ>

        #region <リモート参照用パラメータ>

        /// <summary>
        /// リモート参照用パラメータを生成します。
        /// </summary>
        /// <param name="canEntryCarMng">車両管理マスタに登録するフラグ</param>
        /// <returns>リモート参照用パラメータ</returns>
        /// <see cref="SCMSalesDataMaker"/>
        protected override IOWriteCtrlOptWork CreateIOWriteCtrlOptWork(bool canEntryCarMng)
        {
            IOWriteCtrlOptWork ioWriteCtrlOpt = base.CreateIOWriteCtrlOptWork(canEntryCarMng);
            {
                ioWriteCtrlOpt.EnterpriseCode = GetEnterpriseCodeIf(ioWriteCtrlOpt.EnterpriseCode); // 企業コード

                // 売上全体設定を取得
                SalesTtlSt salesTotalSetting = SalesTtlStDB.Find(
                    ioWriteCtrlOpt.EnterpriseCode,
                    GetSectioncodeIf(string.Empty)
                );
                if (salesTotalSetting != null)
                {
                    ioWriteCtrlOpt.AcpOdrrAddUpRemDiv = salesTotalSetting.AcpOdrrAddUpRemDiv;   // 受注データ計上残区分(0:残す/1:残さない)
                    ioWriteCtrlOpt.ShipmAddUpRemDiv = salesTotalSetting.ShipmAddUpRemDiv;       // 出荷データ計上残区分(0:残す/1:残さない)
                    ioWriteCtrlOpt.EstimateAddUpRemDiv = salesTotalSetting.EstmateAddUpRemDiv;  // 見積データ計上残区分(0:残す/1:残さない)
                }
            }
            return ioWriteCtrlOpt;
        }

        #endregion  // </リモート参照用パラメータ>

        // 2011/02/14 Add >>>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool IsAutoAnswer()
        {
            return false;
        }
        // 2011/02/14 Add <<<

        // 2011/02/18 Add >>>
        /// <summary>
        /// 回答作成区分を取得します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <returns>
        /// 受注ステータスが「10:見積」「30:売上」の場合、「0:自動」を返します。<br/>
        /// それ以外（「20:受注」）の場合、「1:手動(Web)」を返します。
        /// </returns>
        protected override int GetAnswerCreateDiv(int acptAnOdrStatus)
        {
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<


        #endregion // </Override>

        /// <summary>
        /// 企業コードが空の場合、ログイン情報から企業コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>企業コード</returns>
        private static string GetEnterpriseCodeIf(string enterpriseCode)
        {
            return string.IsNullOrEmpty(enterpriseCode.Trim()) ? LoginInfoAcquisition.EnterpriseCode : enterpriseCode;
        }

        /// <summary>
        /// 拠点コードが空の場合、ログイン情報から拠点コードを取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点コード</returns>
        private static string GetSectioncodeIf(string sectionCode)
        {
            return string.IsNullOrEmpty(sectionCode) ? LoginInfoAcquisition.Employee.BelongSectionCode : sectionCode;
        }
    }
}
