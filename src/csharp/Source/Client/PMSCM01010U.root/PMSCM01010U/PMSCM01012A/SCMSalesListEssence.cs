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
// 作 成 日  2009/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/31  修正内容 : 回答区分について、過去の履歴も考慮してセットするように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優 
// 作 成 日  2010/04/21  修正内容 : 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517　夏野 駿希 
// 作 成 日  2010/07/07  修正内容 : 売上金額、売上消費税について自動連携値引きが適用されていない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/14  修正内容 : 自動回答時、取消データも考慮して回答区分をセットする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの朱宝軍
// 作 成 日  2011/09/29  修正内容 : 障害報告 #25633　PM側　再問合せ時の自動回答
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LIUSY
// 作 成 日  2011/10/10  修正内容 : Redmine#25754 25755の対応
//----------------------------------------------------------------------------//
// 管理番号10707327-00   作成担当 : 鄧潘ハン
// 作 成 日  2012/01/12 修正内容 : Redmine#27954
//			                            PMSF連携／PCCforNS BLﾊﾟｰﾂｵｰﾀﾞｰ 障害対応の修正
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良対応・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/09  修正内容 : BL-Pダイレクト発注対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/24  修正内容 : 2012/09/12配信システム障害№16 対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/09/12  修正内容 : 2012/09/12配信システム障害№38 対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸　伸悟
// 作 成 日  2013/04/17  修正内容 : 2013/05/22配信 SCM障害№10520対応 キャンペーン値引き
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/08/07  修正内容 : PM-SCM仕掛一覧№10556対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/08/07  修正内容 : PM-SCM仕掛一覧№10556対応時の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 黄興貴
// 作 成 日  2013/04/17  修正内容 : 配信日なし分  Redmine#35271
//			                        No.184 ＰＭ側エントリー 対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/06/05  修正内容 : 2013/06/18配信 №10385単体テスト障害対応(既存障害)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/08  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 01.商品検索アクセスクラス補正処理プロパティ対応
//                                : 02.得意先掛率グループマスタ取得改良対応（回答判定時）
//                                : 03.変更前単価計算呼出回数改良対応
//                                : 04.キャンペーン売価設定マスタ取得改良対応
//                                : 05.得意先マスタ（伝票管理）取得改良対応
//                                : 06.得意先マスタ取得改良対応（金額計算クラス）
//                                : 07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応）
//                                : 08.売上データ生成時のシステム日付取得対応
//                                : 09.得意先掛率グループマスタ取得改良対応（売上データ生成時）
//                                : 10.単価計算呼出回数改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2014/08/11  修正内容 : 検証／総合テスト障害No.5
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/08/13  修正内容 : 11070147-00 システムテスト障害№5対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/19  修正内容 : リコメンド対応 リコメンド発注時、自動連携値引・キャンペーン値引対応を行わない
//----------------------------------------------------------------------------//

#define _ENABLED_SCM_           // SCMデータ有効フラグ ※通常は有効！
//#define _ENABLED_SCM_DETAIL_    // SCM受注明細データ(問合せ・発注)有効フラグ ※通常は無効！

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    using USBOptionServer   = SingletonInstance<USBOptionAgent>;    // USBのオプション
    using SlipPrtSetServer  = SingletonInstance<SlipPrtSetAgent>;   // 伝票印刷設定マスタ

    /// <summary>
    /// 売上リストの生成クラス
    /// </summary>
    public class SCMSalesListEssence
    {
        #region <ログ用定数>

        /// <summary>クラス名称</summary>
        private const string MY_NAME = "SCMSalesListEssence";

        #endregion // </ログ用定数>

        #region <売上データ>

        /// <summary>売上データ</summary>
        private SalesSlip _salesSlipData;
        /// <summary>売上データを取得します。</summary>
        public SalesSlip SalesSlipData
        {
            get { return _salesSlipData; }
            set
            {
                _salesSlipData = value;

                if (_salesSlipData != null)
                {
                    // 明細行数のデフォルト値を設定
                    _salesSlipData.DetailRowCount = SalesDetailDataList.Count;
                }
            }
        }

        #endregion // </売上データ>

        #region <売上明細データ>

        /// <summary>売上明細データのリスト</summary>
        private IList<SalesDetail> _salesDetailDataList;
        /// <summary>売上明細データのリストを取得します。</summary>
        private IList<SalesDetail> SalesDetailDataList
        {
            get
            {
                if (_salesDetailDataList == null)
                {
                    _salesDetailDataList = new List<SalesDetail>();
                }
                return _salesDetailDataList;
            }
        }

        /// <summary>内部制御用の売上明細通番のカウンタ</summary>
        private long _localSalesSlipDtlNumCount = 0;

        /// <summary>
        /// 売上明細データを追加します。
        /// </summary>
        /// <param name="salesDetailData">売上明細データ</param>
        /// <param name="answerRecord">元となったSCM受注明細データ(回答)のレコード</param>
        public void AddSalesDetailData(
            SalesDetail salesDetailData,
            ISCMOrderAnswerRecord answerRecord
        )
        {
            // 内部制御用に一時的に売上明細通番を設定
            salesDetailData.SalesSlipDtlNum = ++_localSalesSlipDtlNumCount;

            SalesDetailDataList.Add(salesDetailData);

            // SCM受注明細データ(回答)との関連マップに追加
            string key = SCMDataHelper.GetSalesDetailKey(salesDetailData);
            if (!SalesDetailAnswerMap.ContainsKey(key))
            {
                SalesDetailAnswerMap.Add(key, answerRecord);
            }
        }

        /// <summary>売上明細データとSCM受注明細データ(回答)の関連マップ</summary>
        private IDictionary<string, ISCMOrderAnswerRecord> _salesDetailAnswerMap;
        /// <summary>売上明細データとSCM受注明細データ(回答)の関連マップを取得します。</summary>
        /// <remarks>キー：売上明細データキー</remarks>
        private IDictionary<string, ISCMOrderAnswerRecord> SalesDetailAnswerMap
        {
            get
            {
                if (_salesDetailAnswerMap == null)
                {
                    _salesDetailAnswerMap = new Dictionary<string, ISCMOrderAnswerRecord>();
                }
                return _salesDetailAnswerMap;
            }
        }

        /// <summary>
        /// SCM受注明細データ(回答)のレコードを取得します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <returns>対応するSCM受注明細データ(回答)のレコード</returns>
        protected ISCMOrderAnswerRecord GetSCMAnswerRecord(SalesDetail salesDetail)
        {
            string salesDetailKey = SCMDataHelper.GetSalesDetailKey(salesDetail);
            return SalesDetailAnswerMap[salesDetailKey];
        }

        #endregion // </売上明細データ>

        #region <車両管理データ>

        /// <summary>車両管理データのリスト</summary>
        private IList<CarManagementWork> _carManagementList;
        /// <summary>車両管理データのリストを取得します。</summary>
        private IList<CarManagementWork> CarManagementList
        {
            get
            {
                if (_carManagementList == null)
                {
                    _carManagementList = new List<CarManagementWork>();
                }
                return _carManagementList;
            }
        }

        /// <summary>
        /// 車両管理データを追加します。
        /// </summary>
        /// <param name="carManagementData">車両管理データ</param>
        public void AddCarManagementData(CarManagementWork carManagementData)
        {
            CarManagementList.Add(carManagementData);
        }

        #endregion // </車両管理データ>

        #region <リモート参照用明細パラメータ>

        /// <summary>リモート参照用明細パラメータのリスト</summary>
        private IList<SlipDetailAddInfoWork> _slipDetailAddInfoList;
        /// <summary>リモート参照用明細パラメータのリストを取得します。</summary>
        private IList<SlipDetailAddInfoWork> SlipDetailAddInfoList
        {
            get
            {
                if (_slipDetailAddInfoList == null)
                {
                    _slipDetailAddInfoList = new List<SlipDetailAddInfoWork>();
                }
                return _slipDetailAddInfoList;
            }
        }

        /// <summary>
        /// リモート参照用明細パラメータを追加します。
        /// </summary>
        /// <param name="slipDetailAddInfo">リモート参照用明細パラメータ</param>
        /// <param name="answerRecord">元となったSCM受注明細データ(回答)のレコード</param>
        public void AddSlipDetailAddInfo(
            SlipDetailAddInfoWork slipDetailAddInfo,
            ISCMOrderAnswerRecord answerRecord
        )
        {
            SlipDetailAddInfoList.Add(slipDetailAddInfo);

            // SCM受注明細データ(回答)とリモート参照用パラメータの関連マップに追加
            if (!AnswerSlipDetailAddInfoMap.ContainsKey(answerRecord.SalesRelationId))
            {
                AnswerSlipDetailAddInfoMap.Add(answerRecord.SalesRelationId, slipDetailAddInfo);
            }
        }

        /// <summary>SCM受注明細データ(回答)とリモート参照用パラメータの関連マップ</summary>
        private IDictionary<Guid, SlipDetailAddInfoWork> _answerSlipDetailAddInfoMap;
        /// <summary>SCM受注明細データ(回答)とリモート参照用パラメータの関連マップを取得します。</summary>
        private IDictionary<Guid, SlipDetailAddInfoWork> AnswerSlipDetailAddInfoMap
        {
            get
            {
                if (_answerSlipDetailAddInfoMap == null)
                {
                    _answerSlipDetailAddInfoMap = new Dictionary<Guid, SlipDetailAddInfoWork>();
                }
                return _answerSlipDetailAddInfoMap;
            }
        }

        /// <summary>
        /// リモート参照用パラメータを取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>対応するリモート参照用パラメータ</returns>
        private SlipDetailAddInfoWork GetSlipDetailAddInfo(ISCMOrderAnswerRecord answerRecord)
        {
            if (AnswerSlipDetailAddInfoMap.ContainsKey(answerRecord.SalesRelationId))
            {
                return AnswerSlipDetailAddInfoMap[answerRecord.SalesRelationId];
            }
            return null;
        }

        #endregion // </リモート参照用明細パラメータ>

        #region <SCM受注データ>

        /// <summary>SCM受注データのレコード</summary>
        private ISCMOrderHeaderRecord _scmHeaderRecord;
        /// <summary>SCM受注データのレコードを取得または設定します。</summary>
        public ISCMOrderHeaderRecord SCMHeaderRecord
        {
            get { return _scmHeaderRecord; }
            set { _scmHeaderRecord = value; }
        }

        /// <summary>
        /// SCM受注データの回答区分を設定します。
        /// </summary>
        // 2010/03/31 >>>
        //public void SetAnswerDivCdOfSCMHeader()
        public void SetAnswerDivCdOfSCMHeader(List<ISCMOrderAnswerRecord> answerlist, List<ISCMOrderDetailRecord> detailList)
        // 2010/03/31 <<<
        {
            #region <Guard Phrase>

            if (SCMHeaderRecord == null) return;
            if (SCMAnswerRecordList.Count.Equals(0)) return;

            #endregion // </Guard Phrase>

            // 2010/03/31 >>>
            //// 明細データ数と回答データを持つ明細データ数が同じ場合、20:回答完了
            //// それ以外は 10:一部回答
            //if (SCMAnswerRecordList.Count >= SCMDetailRecordMax)
            //{
            //    SCMHeaderRecord.AnswerDivCd = (int)AnswerDivCd.AnswerCompletion;
            //}
            //else
            //{
            //    SCMHeaderRecord.AnswerDivCd = (int)AnswerDivCd.PartAnswer;
            //}

            bool insufficiency = false;

            foreach (ISCMOrderDetailRecord detail in detailList)
            {
                // 2011/02/14 Add >>>
                // キャンセル確定は、回答済み扱い
                if (detail.CancelCndtinDiv == (short)CancelCndtinDiv.Cancelled) continue;
                // 2011/02/14 Add <<<

                // 今回データからの検索
                List<ISCMOrderAnswerRecord> newAnswers = ( (List<ISCMOrderAnswerRecord>)SCMAnswerRecordList ).FindAll(
                    delegate(ISCMOrderAnswerRecord target)
                    {
                        // 問合せ元企業コード違い
                        if (!target.InqOriginalEpCd.Trim().Equals(detail.InqOriginalEpCd.Trim())) return false;
                        // 問合せ元拠点違い
                        if (!target.InqOriginalSecCd.Trim().Equals(detail.InqOriginalSecCd.Trim())) return false;
                        // 問合せ先企業コード違い
                        if (!target.InqOtherEpCd.Trim().Equals(detail.InqOtherEpCd.Trim())) return false;
                        // 問合せ先拠点違い
                        if (!target.InqOtherSecCd.Trim().Equals(detail.InqOtherSecCd.Trim())) return false;
                        // 問合せ番号違い
                        if (!target.InquiryNumber.Equals(detail.InquiryNumber)) return false;
                        // 問合せ・発注種別違い
                        if (!target.InqOrdDivCd.Equals(detail.InqOrdDivCd)) return false;

                        // 問合せ行番号違い
                        if (!target.InqRowNumber.Equals(detail.InqRowNumber)) return false;

                        // 行枝番がある場合は、行枝番違い
                        if (detail.InqRowNumDerivedNo != 0)
                        {
                            if (!target.InqRowNumDerivedNo.Equals(detail.InqRowNumDerivedNo)) return false;
                        }

                        return true;
                    });
                // 今回回答データに含まれる場合は回答済み扱い
                if (newAnswers != null && newAnswers.Count > 0) continue;

                // 過去の回答データからの検索
                List<ISCMOrderAnswerRecord> oldAnswers = ( (List<ISCMOrderAnswerRecord>)answerlist ).FindAll(
                    delegate(ISCMOrderAnswerRecord target)
                    {
                        // 問合せ元企業コード違い
                        if (!target.InqOriginalEpCd.Trim().Equals(detail.InqOriginalEpCd.Trim())) return false;
                        // 問合せ元拠点違い
                        if (!target.InqOriginalSecCd.Trim().Equals(detail.InqOriginalSecCd.Trim())) return false;
                        // 問合せ先企業コード違い
                        if (!target.InqOtherEpCd.Trim().Equals(detail.InqOtherEpCd.Trim())) return false;
                        // 問合せ先拠点違い
                        if (!target.InqOtherSecCd.Trim().Equals(detail.InqOtherSecCd.Trim())) return false;
                        // 問合せ番号違い
                        if (!target.InquiryNumber.Equals(detail.InquiryNumber)) return false;
                        // 問合せ・発注種別違い
                        if (!target.InqOrdDivCd.Equals(detail.InqOrdDivCd)) return false;

                        // 問合せ行番号違い
                        if (!target.InqRowNumber.Equals(detail.InqRowNumber)) return false;

                        // 行枝番がある場合は、行枝番違い
                        if (detail.InqRowNumDerivedNo != 0)
                        {
                            if (!target.InqRowNumDerivedNo.Equals(detail.InqRowNumDerivedNo)) return false;
                        }

                        // 再問合せのチェック
                        // ①受信日が 過去の回答 < 今回問合せ
                        // ②受信日が同じ場合は、受信日時が 過去の回答 < 今回問合せ
                        if (target.UpdateDate < detail.UpdateDate) return false;
                        if (target.UpdateDate == detail.UpdateDate && target.UpdateTime < detail.UpdateTime) return false;

                        return true;
                    });
                // 過去の回答に、明細に対応する回答が存在した場合は回答済み扱い
                if (oldAnswers != null && oldAnswers.Count > 0) continue;

                insufficiency = true;
                break;
            }

            // 未回答データが含まれる場合は一部回答とする
            SCMHeaderRecord.AnswerDivCd = ( insufficiency ) ? (int)AnswerDivCd.PartAnswer : (int)AnswerDivCd.AnswerCompletion;
            // 2010/03/31 <<<
        }

        #endregion // </SCM受注データ>

        #region <SCM受注データ(車両情報)>

        /// <summary>SCM受注データ(車両情報)のレコード</summary>
        private ISCMOrderCarRecord _scmCarRecord;
        /// <summary>SCM受注データ(車両情報)のレコードを取得または設定します。</summary>
        public ISCMOrderCarRecord SCMCarRecord
        {
            get { return _scmCarRecord; }
            set { _scmCarRecord = value; }
        }

        #endregion // </SCM受注データ(車両情報)>

        #region <SCM受注明細データ(問合せ・発注)>

        /// <summary>SCM受注明細データ(問合せ・発注)の最大レコード数</summary>
        private int _scmDetailRecordMax = int.MaxValue;
        /// <summary>SCM受注明細データ(問合せ・発注)の最大レコード数を取得または設定します。</summary>
        /// <remarks><c>SCMSalesDataMaker.MakeAnswerDataAndSalesData()</c>より設定されます。</remarks>
        public int SCMDetailRecordMax
        {
            get { return _scmDetailRecordMax; }
            set
            {
                _scmDetailRecordMax = value;
                // 2010/03/31 >>>
                //SetAnswerDivCdOfSCMHeader();    // SCM受注データの回答区分を設定
                // 2010/03/31 <<<
            }
        }

        /// <summary>SCM受注明細データ(問合せ・発注)のレコードのリスト</summary>
        private IList<ISCMOrderDetailRecord> _scmDetailRecordList;
        /// <summary>SCM受注明細データ(問合せ・発注)のレコードのリストを取得します。</summary>
        private IList<ISCMOrderDetailRecord> SCMDetailRecordList
        {
            get
            {
                if (_scmDetailRecordList == null)
                {
                    _scmDetailRecordList = new List<ISCMOrderDetailRecord>();
                }
                return _scmDetailRecordList;
            }
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)のレコードを追加します。
        /// </summary>
        /// <param name="scmDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <exception cref="ArgumentNullException">追加するSCM受注明細データ(問合せ・発注)のレコードがnullです。</exception>
        public void AddSCMDetailRecord(ISCMOrderDetailRecord scmDetailRecord)
        {
            #region <Guard Phrase>

            if (scmDetailRecord == null)
            {
                throw new ArgumentNullException("scmDetailRecord", "追加するSCM受注明細データ(問合せ・発注)のレコードがnullです。");
            }

            #endregion // </Guard Phrase>

            string scmDetailKey = SCMEntityUtil.GetDetailRecordKey(scmDetailRecord);
            if (!EntrySCMDetailRecordMap.ContainsKey(scmDetailKey))
            {
                SCMDetailRecordList.Add(scmDetailRecord);
                EntrySCMDetailRecordMap.Add(scmDetailKey, scmDetailRecord);
            }
        }

        /// <summary>登録されているSCM受注明細データ(問合せ・発注)のマップ</summary>
        private IDictionary<string, ISCMOrderDetailRecord> _entrySCMDetailRecordMap;
        /// <summary>登録されているSCM受注明細データ(問合せ・発注)のマップを取得します。</summary>
        /// <remarks>キー：SCM受注明細データ(問合せ・発注)のキー</remarks>
        private IDictionary<string, ISCMOrderDetailRecord> EntrySCMDetailRecordMap
        {
            get
            {
                if (_entrySCMDetailRecordMap == null)
                {
                    _entrySCMDetailRecordMap = new Dictionary<string, ISCMOrderDetailRecord>();
                }
                return _entrySCMDetailRecordMap;
            }
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)の反復子を生成します。
        /// </summary>
        /// <returns>SCM受注明細データ(問合せ・発注)の反復子</returns>
        public ListIterator<ISCMOrderDetailRecord> CreateSCMDetailIterator()
        {
            return new ListIterator<ISCMOrderDetailRecord>(SCMDetailRecordList);
        }

        #endregion // </SCM受注明細データ(問合せ・発注)>

        #region <SCM受注明細データ(回答)>

        /// <summary>SCM受注明細データ(回答)のレコードのリスト</summary>
        private IList<ISCMOrderAnswerRecord> _scmAnswerRecordList;
        /// <summary>SCM受注明細データ(回答)のレコードのリストを取得します。</summary>
        private IList<ISCMOrderAnswerRecord> SCMAnswerRecordList
        {
            get
            {
                if (_scmAnswerRecordList == null)
                {
                    _scmAnswerRecordList = new List<ISCMOrderAnswerRecord>();
                }
                return _scmAnswerRecordList;
            }
        }

        /// <summary>SCM受注明細データ(回答)とSCM受注明細データ(問合せ・発注)の関連マップ</summary>
        private IDictionary<Guid, ISCMOrderDetailRecord> _answerDetailMap;
        /// <summary>SCM受注明細データ(回答)とSCM受注明細データ(問合せ・発注)の関連マップを取得します。</summary>
        /// <remarks>キー：回答データの関連GUID</remarks>
        private IDictionary<Guid, ISCMOrderDetailRecord> AnswerDetailMap
        {
            get
            {
                if (_answerDetailMap == null)
                {
                    _answerDetailMap = new Dictionary<Guid, ISCMOrderDetailRecord>();
                }
                return _answerDetailMap;
            }
        }

        /// <summary>
        /// SCM受注明細データ(回答)のレコードを追加します。
        /// </summary>
        /// <param name="scmAnswerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)のレコード</param>
        /// <exception cref="ArgumentNullException">
        /// 追加するSCM受注明細データ(回答)のレコードがnullです。<br/>
        /// 元となったSCM受注明細データ(問合せ・発注)のレコードがnullです。
        /// </exception>
        public void AddSCMAnswerRecord(
            ISCMOrderAnswerRecord scmAnswerRecord,
            ISCMOrderDetailRecord sourceDetailRecord
        )
        {
            #region <Guard Phrase>

            if (scmAnswerRecord == null)
            {
                throw new ArgumentNullException("scmAnswerRecord", "追加するSCM受注明細データ(回答)のレコードがnullです。");
            }
            if (sourceDetailRecord == null)
            {
                throw new ArgumentNullException("sourceDetailRecord", "元となったSCM受注明細データ(問合せ・発注)のレコードがnullです。");
            }

            #endregion // </Guard Phrase>

            SCMAnswerRecordList.Add(scmAnswerRecord);

            // SCM受注明細データ(回答)とSCM受注明細データ(問合せ・発注)のマップに追加
            if (!AnswerDetailMap.ContainsKey(scmAnswerRecord.SalesRelationId))
            {
                AnswerDetailMap.Add(scmAnswerRecord.SalesRelationId, sourceDetailRecord);
            }
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)のレコードを取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>対応するSCM受注明細データ(問合せ・発注)のレコード</returns>
        private ISCMOrderDetailRecord GetSCMDetailRecord(ISCMOrderAnswerRecord answerRecord)
        {
            if (AnswerDetailMap.ContainsKey(answerRecord.SalesRelationId))
            {
                return AnswerDetailMap[answerRecord.SalesRelationId];
            }
            return null;
        }

        /// <summary>
        /// SCM受注明細データ(回答)の反復子を生成します。
        /// </summary>
        /// <returns>SCM受注明細データ(回答)の反復子</returns>
        public ListIterator<ISCMOrderAnswerRecord> CreateSCMAnswerIterator()
        {
            return new ListIterator<ISCMOrderAnswerRecord>(SCMAnswerRecordList);
        }

        #endregion // <SCM受注明細データ(回答)>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCMセット部品データ>

        /// <summary>
        /// SCMセット部品データのレコードのリスト
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> _scmSetDtRecordList;

        /// <summary>
        /// SCMセット部品データのレコードのリストを取得します。
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> SCMSetDtRecordList
        {
            get
            {
                if (_scmSetDtRecordList == null)
                {
                    _scmSetDtRecordList = new List<ISCMAcOdSetDtRecord>();
                }
                return _scmSetDtRecordList;
            }
        }

        /// <summary>
        /// SCMセット部品データのレコードを追加します。
        /// </summary>
        /// <param name="scmSetDtRecord">SCMセット部品データのレコード</param>
        /// <exception cref="ArgumentNullException">
        /// 追加するSCMセット部品データのレコードがnullです。<br/>
        /// </exception>
        public void AddSCMSetRecord(ISCMAcOdSetDtRecord scmSetDtRecord)
        {
            #region <Guard Phrase>

            if (scmSetDtRecord == null)
            {
                throw new ArgumentNullException("scmSetDtRecord", "追加するセット部品データのレコードがnullです。");
            }
                
            #endregion // </Guard Phrase>

            SCMSetDtRecordList.Add(scmSetDtRecord);
        }

        /// <summary>
        /// SCMセット部品データの反復子を生成します。
        /// </summary>
        /// <returns>セット部品データの反復子</returns>
        public ListIterator<ISCMAcOdSetDtRecord> CreateSCMSetDtIterator()
        {
            return new ListIterator<ISCMAcOdSetDtRecord>(SCMSetDtRecordList);
        }

        /// <summary>
        /// SCM受注セット部品データのレコードを取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)</param>
        /// <returns>対応するSCM受注セットデータ(回答)のレコード</returns>
        protected List<ISCMAcOdSetDtRecord> GetSCMSetRecord(ISCMOrderAnswerRecord answerRecord)
        {
            return SetDetailMap[answerRecord.SalesRelationId];
        }
        #endregion // <SCMセット部品データ>
        // -- ADD 2011/08/10   ------ <<<<<<

        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ---------------------------------->>>>>
        #region <価格算出クラス>
        private SCMPriceCalculator _priceCalculator;

        /// <summary>
        /// 価格算出クラス
        /// </summary>
        public SCMPriceCalculator PriceCalculator
        {
            get
            {
                if (this._priceCalculator == null)
                {
                    this._priceCalculator = new SCMPriceCalculator();
                }
                return this._priceCalculator;
            }
            set
            {
                this._priceCalculator = value;
            }
        }
        #endregion // <SCMセット部品データ>
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№06.得意先マスタ取得改良対応（金額計算クラス） ----------------------------------<<<<<

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected SCMSalesListEssence() { }

        #endregion // </Constructor>

        #region <USBのオプション>

        /// <summary>
        /// USBのオプションを取得します。
        /// </summary>
        private static USBOptionAgent USBOption
        {
            get { return USBOptionServer.Singleton.Instance; }
        }

        #endregion // </USBのオプション>

        #region <伝票印刷設定マスタ>

        /// <summary>
        /// 伝票印刷設定マスタを取得します。
        /// </summary>
        private static SlipPrtSetAgent SlipPrtSetDB
        {
            get { return SlipPrtSetServer.Singleton.Instance; }
        }

        #endregion // </伝票印刷設定マスタ>

        #region <リモート用ワークデータ>

        #region <売上データワーク>

        /// <summary>
        /// リモート用売上データを生成します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>リモート用売上データ</returns>
        protected static SalesSlipWork CreateSalesSlipWork(SalesSlip salesSlip)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();
            {
                salesSlipWork.CreateDateTime = salesSlip.CreateDateTime; // 作成日時
                salesSlipWork.UpdateDateTime = salesSlip.UpdateDateTime; // 更新日時
                salesSlipWork.EnterpriseCode = salesSlip.EnterpriseCode; // 企業コード
                salesSlipWork.FileHeaderGuid = salesSlip.FileHeaderGuid; // GUID
                salesSlipWork.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // 更新従業員コード
                salesSlipWork.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // 更新アセンブリID1
                salesSlipWork.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // 更新アセンブリID2
                salesSlipWork.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // 論理削除区分
                salesSlipWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // 受注ステータス
                salesSlipWork.SalesSlipNum = salesSlip.SalesSlipNum; // 売上伝票番号
                salesSlipWork.SectionCode = salesSlip.SectionCode; // 拠点コード
                salesSlipWork.SubSectionCode = salesSlip.SubSectionCode; // 部門コード
                salesSlipWork.DebitNoteDiv = salesSlip.DebitNoteDiv; // 赤伝区分
                salesSlipWork.DebitNLnkSalesSlNum = salesSlip.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
                salesSlipWork.SalesSlipCd = salesSlip.SalesSlipCd; // 売上伝票区分
                salesSlipWork.SalesGoodsCd = salesSlip.SalesGoodsCd; // 売上商品区分
                salesSlipWork.AccRecDivCd = salesSlip.AccRecDivCd; // 売掛区分
                salesSlipWork.SalesInpSecCd = salesSlip.SalesInpSecCd; // 売上入力拠点コード
                salesSlipWork.DemandAddUpSecCd = salesSlip.DemandAddUpSecCd; // 請求計上拠点コード
                salesSlipWork.ResultsAddUpSecCd = salesSlip.ResultsAddUpSecCd; // 実績計上拠点コード
                salesSlipWork.UpdateSecCd = salesSlip.UpdateSecCd; // 更新拠点コード
                salesSlipWork.SalesSlipUpdateCd = salesSlip.SalesSlipUpdateCd; // 売上伝票更新区分
                salesSlipWork.SearchSlipDate = salesSlip.SearchSlipDate; // 伝票検索日付
                salesSlipWork.ShipmentDay = salesSlip.ShipmentDay; // 出荷日付
                salesSlipWork.SalesDate = salesSlip.SalesDate; // 売上日付
                salesSlipWork.AddUpADate = salesSlip.AddUpADate; // 計上日付
                salesSlipWork.DelayPaymentDiv = salesSlip.DelayPaymentDiv; // 来勘区分
                salesSlipWork.EstimateFormNo = salesSlip.EstimateFormNo; // 見積書番号
                salesSlipWork.EstimateDivide = salesSlip.EstimateDivide; // 見積区分
                salesSlipWork.InputAgenCd = salesSlip.InputAgenCd; // 入力担当者コード
                salesSlipWork.InputAgenNm = salesSlip.InputAgenNm; // 入力担当者名称
                salesSlipWork.SalesInputCode = salesSlip.SalesInputCode; // 売上入力者コード
                salesSlipWork.SalesInputName = salesSlip.SalesInputName; // 売上入力者名称
                salesSlipWork.FrontEmployeeCd = salesSlip.FrontEmployeeCd; // 受付従業員コード
                salesSlipWork.FrontEmployeeNm = salesSlip.FrontEmployeeNm; // 受付従業員名称
                salesSlipWork.SalesEmployeeCd = salesSlip.SalesEmployeeCd; // 販売従業員コード
                salesSlipWork.SalesEmployeeNm = salesSlip.SalesEmployeeNm; // 販売従業員名称
                salesSlipWork.TotalAmountDispWayCd = salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                salesSlipWork.TtlAmntDispRateApy = salesSlip.TtlAmntDispRateApy; // 総額表示掛率適用区分
                salesSlipWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // 売上伝票合計（税込み）
                salesSlipWork.SalesTotalTaxExc = salesSlip.SalesTotalTaxExc; // 売上伝票合計（税抜き）
                salesSlipWork.SalesPrtTotalTaxInc = salesSlip.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
                salesSlipWork.SalesPrtTotalTaxExc = salesSlip.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
                salesSlipWork.SalesWorkTotalTaxInc = salesSlip.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
                salesSlipWork.SalesWorkTotalTaxExc = salesSlip.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
                salesSlipWork.SalesSubtotalTaxInc = salesSlip.SalesSubtotalTaxInc; // 売上小計（税込み）
                salesSlipWork.SalesSubtotalTaxExc = salesSlip.SalesSubtotalTaxExc; // 売上小計（税抜き）
                salesSlipWork.SalesPrtSubttlInc = salesSlip.SalesPrtSubttlInc; // 売上部品小計（税込み）
                salesSlipWork.SalesPrtSubttlExc = salesSlip.SalesPrtSubttlExc; // 売上部品小計（税抜き）
                salesSlipWork.SalesWorkSubttlInc = salesSlip.SalesWorkSubttlInc; // 売上作業小計（税込み）
                salesSlipWork.SalesWorkSubttlExc = salesSlip.SalesWorkSubttlExc; // 売上作業小計（税抜き）
                salesSlipWork.SalesNetPrice = salesSlip.SalesNetPrice; // 売上正価金額
                salesSlipWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // 売上小計（税）
                salesSlipWork.ItdedSalesOutTax = salesSlip.ItdedSalesOutTax; // 売上外税対象額
                salesSlipWork.ItdedSalesInTax = salesSlip.ItdedSalesInTax; // 売上内税対象額
                salesSlipWork.SalSubttlSubToTaxFre = salesSlip.SalSubttlSubToTaxFre; // 売上小計非課税対象額
                salesSlipWork.SalesOutTax = salesSlip.SalesOutTax; // 売上金額消費税額（外税）
                salesSlipWork.SalAmntConsTaxInclu = salesSlip.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
                salesSlipWork.SalesDisTtlTaxExc = salesSlip.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
                salesSlipWork.ItdedSalesDisOutTax = salesSlip.ItdedSalesDisOutTax; // 売上値引外税対象額合計
                salesSlipWork.ItdedSalesDisInTax = salesSlip.ItdedSalesDisInTax; // 売上値引内税対象額合計
                salesSlipWork.ItdedPartsDisOutTax = salesSlip.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
                salesSlipWork.ItdedPartsDisInTax = salesSlip.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
                salesSlipWork.ItdedWorkDisOutTax = salesSlip.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
                salesSlipWork.ItdedWorkDisInTax = salesSlip.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
                salesSlipWork.ItdedSalesDisTaxFre = salesSlip.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
                salesSlipWork.SalesDisOutTax = salesSlip.SalesDisOutTax; // 売上値引消費税額（外税）
                salesSlipWork.SalesDisTtlTaxInclu = salesSlip.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
                salesSlipWork.PartsDiscountRate = salesSlip.PartsDiscountRate; // 部品値引率
                salesSlipWork.RavorDiscountRate = salesSlip.RavorDiscountRate; // 工賃値引率
                salesSlipWork.TotalCost = salesSlip.TotalCost; // 原価金額計
                salesSlipWork.ConsTaxLayMethod = salesSlip.ConsTaxLayMethod; // 消費税転嫁方式
                salesSlipWork.ConsTaxRate = salesSlip.ConsTaxRate; // 消費税税率
                salesSlipWork.FractionProcCd = salesSlip.FractionProcCd; // 端数処理区分
                salesSlipWork.AccRecConsTax = salesSlip.AccRecConsTax; // 売掛消費税
                salesSlipWork.AutoDepositCd = salesSlip.AutoDepositCd; // 自動入金区分
                salesSlipWork.AutoDepositSlipNo = salesSlip.AutoDepositSlipNo; // 自動入金伝票番号
                salesSlipWork.DepositAllowanceTtl = salesSlip.DepositAllowanceTtl; // 入金引当合計額
                salesSlipWork.DepositAlwcBlnce = salesSlip.DepositAlwcBlnce; // 入金引当残高
                salesSlipWork.ClaimCode = salesSlip.ClaimCode; // 請求先コード
                salesSlipWork.ClaimSnm = salesSlip.ClaimSnm; // 請求先略称
                salesSlipWork.CustomerCode = salesSlip.CustomerCode; // 得意先コード
                salesSlipWork.CustomerName = salesSlip.CustomerName; // 得意先名称
                salesSlipWork.CustomerName2 = salesSlip.CustomerName2; // 得意先名称2
                salesSlipWork.CustomerSnm = salesSlip.CustomerSnm; // 得意先略称
                salesSlipWork.HonorificTitle = salesSlip.HonorificTitle; // 敬称
                salesSlipWork.OutputNameCode = salesSlip.OutputNameCode; // 諸口コード
                salesSlipWork.OutputName = salesSlip.OutputName; // 諸口名称
                salesSlipWork.CustSlipNo = salesSlip.CustSlipNo; // 得意先伝票番号
                salesSlipWork.SlipAddressDiv = salesSlip.SlipAddressDiv; // 伝票住所区分
                salesSlipWork.AddresseeCode = salesSlip.AddresseeCode; // 納品先コード
                salesSlipWork.AddresseeName = salesSlip.AddresseeName; // 納品先名称
                salesSlipWork.AddresseeName2 = salesSlip.AddresseeName2; // 納品先名称2
                salesSlipWork.AddresseePostNo = salesSlip.AddresseePostNo; // 納品先郵便番号
                salesSlipWork.AddresseeAddr1 = salesSlip.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
                salesSlipWork.AddresseeAddr3 = salesSlip.AddresseeAddr3; // 納品先住所3(番地)
                salesSlipWork.AddresseeAddr4 = salesSlip.AddresseeAddr4; // 納品先住所4(アパート名称)
                salesSlipWork.AddresseeTelNo = salesSlip.AddresseeTelNo; // 納品先電話番号
                salesSlipWork.AddresseeFaxNo = salesSlip.AddresseeFaxNo; // 納品先FAX番号
                salesSlipWork.PartySaleSlipNum = salesSlip.PartySaleSlipNum; // 相手先伝票番号
                salesSlipWork.SlipNote = salesSlip.SlipNote; // 伝票備考
                salesSlipWork.SlipNote2 = salesSlip.SlipNote2; // 伝票備考２
                salesSlipWork.SlipNote3 = salesSlip.SlipNote3; // 伝票備考３
                salesSlipWork.RetGoodsReasonDiv = salesSlip.RetGoodsReasonDiv; // 返品理由コード
                salesSlipWork.RetGoodsReason = salesSlip.RetGoodsReason; // 返品理由
                salesSlipWork.RegiProcDate = salesSlip.RegiProcDate; // レジ処理日
                salesSlipWork.CashRegisterNo = salesSlip.CashRegisterNo; // レジ番号
                salesSlipWork.PosReceiptNo = salesSlip.PosReceiptNo; // POSレシート番号
                salesSlipWork.DetailRowCount = salesSlip.DetailRowCount; // 明細行数
                salesSlipWork.EdiSendDate = salesSlip.EdiSendDate; // ＥＤＩ送信日
                salesSlipWork.EdiTakeInDate = salesSlip.EdiTakeInDate; // ＥＤＩ取込日
                salesSlipWork.UoeRemark1 = salesSlip.UoeRemark1; // ＵＯＥリマーク１
                salesSlipWork.UoeRemark2 = salesSlip.UoeRemark2; // ＵＯＥリマーク２
                salesSlipWork.SlipPrintDivCd = salesSlip.SlipPrintDivCd; // 伝票発行区分
                salesSlipWork.SlipPrintFinishCd = salesSlip.SlipPrintFinishCd; // 伝票発行済区分
                salesSlipWork.SalesSlipPrintDate = salesSlip.SalesSlipPrintDate; // 売上伝票発行日
                salesSlipWork.BusinessTypeCode = salesSlip.BusinessTypeCode; // 業種コード
                salesSlipWork.BusinessTypeName = salesSlip.BusinessTypeName; // 業種名称
                salesSlipWork.OrderNumber = salesSlip.OrderNumber; // 発注番号
                salesSlipWork.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv; // 納品区分
                salesSlipWork.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm; // 納品区分名称
                salesSlipWork.SalesAreaCode = salesSlip.SalesAreaCode; // 販売エリアコード
                salesSlipWork.SalesAreaName = salesSlip.SalesAreaName; // 販売エリア名称
                salesSlipWork.ReconcileFlag = salesSlip.ReconcileFlag; // 消込フラグ
                salesSlipWork.SlipPrtSetPaperId = salesSlip.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
                salesSlipWork.CompleteCd = salesSlip.CompleteCd; // 一式伝票区分
                salesSlipWork.SalesPriceFracProcCd = salesSlip.SalesPriceFracProcCd; // 売上金額端数処理区分
                salesSlipWork.StockGoodsTtlTaxExc = salesSlip.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
                salesSlipWork.PureGoodsTtlTaxExc = salesSlip.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
                salesSlipWork.ListPricePrintDiv = salesSlip.ListPricePrintDiv; // 定価印刷区分
                salesSlipWork.EraNameDispCd1 = salesSlip.EraNameDispCd1; // 元号表示区分１
                salesSlipWork.EstimaTaxDivCd = salesSlip.EstimaTaxDivCd; // 見積消費税区分
                salesSlipWork.EstimateFormPrtCd = salesSlip.EstimateFormPrtCd; // 見積書印刷区分
                salesSlipWork.EstimateSubject = salesSlip.EstimateSubject; // 見積件名
                salesSlipWork.Footnotes1 = salesSlip.Footnotes1; // 脚注１
                salesSlipWork.Footnotes2 = salesSlip.Footnotes2; // 脚注２
                salesSlipWork.EstimateTitle1 = salesSlip.EstimateTitle1; // 見積タイトル１
                salesSlipWork.EstimateTitle2 = salesSlip.EstimateTitle2; // 見積タイトル２
                salesSlipWork.EstimateTitle3 = salesSlip.EstimateTitle3; // 見積タイトル３
                salesSlipWork.EstimateTitle4 = salesSlip.EstimateTitle4; // 見積タイトル４
                salesSlipWork.EstimateTitle5 = salesSlip.EstimateTitle5; // 見積タイトル５
                salesSlipWork.EstimateNote1 = salesSlip.EstimateNote1; // 見積備考１
                salesSlipWork.EstimateNote2 = salesSlip.EstimateNote2; // 見積備考２
                salesSlipWork.EstimateNote3 = salesSlip.EstimateNote3; // 見積備考３
                salesSlipWork.EstimateNote4 = salesSlip.EstimateNote4; // 見積備考４
                salesSlipWork.EstimateNote5 = salesSlip.EstimateNote5; // 見積備考５
                salesSlipWork.EstimateValidityDate = salesSlip.EstimateValidityDate; // 見積有効期限
                salesSlipWork.PartsNoPrtCd = salesSlip.PartsNoPrtCd; // 品番印字区分
                salesSlipWork.OptionPringDivCd = salesSlip.OptionPringDivCd; // オプション印字区分
                salesSlipWork.RateUseCode = salesSlip.RateUseCode; // 掛率使用区分
            }
            return salesSlipWork;
        }

        #endregion // </売上データワーク>

        #region <売上明細データワーク>

        /// <summary>
        /// リモート用売上明細データを生成します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <returns>リモート用売上明細データ</returns>
        protected static SalesDetailWork CreateSalesDetailWork(SalesDetail salesDetail)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();
            {
                salesDetailWork.CreateDateTime = salesDetail.CreateDateTime; // 作成日時
                salesDetailWork.UpdateDateTime = salesDetail.UpdateDateTime; // 更新日時
                salesDetailWork.EnterpriseCode = salesDetail.EnterpriseCode; // 企業コード
                salesDetailWork.FileHeaderGuid = salesDetail.FileHeaderGuid; // GUID
                salesDetailWork.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // 更新従業員コード
                salesDetailWork.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // 更新アセンブリID1
                salesDetailWork.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // 更新アセンブリID2
                salesDetailWork.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // 論理削除区分
                salesDetailWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // 受注番号
                salesDetailWork.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // 受注ステータス
                salesDetailWork.SalesSlipNum = salesDetail.SalesSlipNum; // 売上伝票番号
                salesDetailWork.SalesRowNo = salesDetail.SalesRowNo; // 売上行番号
                salesDetailWork.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // 売上行番号枝番
                salesDetailWork.SectionCode = salesDetail.SectionCode; // 拠点コード
                salesDetailWork.SubSectionCode = salesDetail.SubSectionCode; // 部門コード
                salesDetailWork.SalesDate = salesDetail.SalesDate; // 売上日付
                salesDetailWork.CommonSeqNo = salesDetail.CommonSeqNo; // 共通通番
                salesDetailWork.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // 売上明細通番
                salesDetailWork.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // 受注ステータス（元）
                salesDetailWork.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // 売上明細通番（元）
                salesDetailWork.SupplierFormalSync = salesDetail.SupplierFormalSync; // 仕入形式（同時）
                salesDetailWork.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // 仕入明細通番（同時）
                salesDetailWork.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // 売上伝票区分（明細）
                salesDetailWork.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // 納品完了予定日
                salesDetailWork.GoodsKindCode = salesDetail.GoodsKindCode; // 商品属性
                salesDetailWork.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // 商品検索区分
                salesDetailWork.GoodsMakerCd = salesDetail.GoodsMakerCd; // 商品メーカーコード
                salesDetailWork.MakerName = salesDetail.MakerName; // メーカー名称
                salesDetailWork.MakerKanaName = salesDetail.MakerKanaName; // メーカーカナ名称
                salesDetailWork.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // メーカーカナ名称（一式）
                salesDetailWork.GoodsNo = salesDetail.GoodsNo; // 商品番号
                salesDetailWork.GoodsName = salesDetail.GoodsName; // 商品名称
                salesDetailWork.GoodsNameKana = salesDetail.GoodsNameKana; // 商品名称カナ
                salesDetailWork.GoodsLGroup = salesDetail.GoodsLGroup; // 商品大分類コード
                salesDetailWork.GoodsLGroupName = salesDetail.GoodsLGroupName; // 商品大分類名称
                salesDetailWork.GoodsMGroup = salesDetail.GoodsMGroup; // 商品中分類コード
                salesDetailWork.GoodsMGroupName = salesDetail.GoodsMGroupName; // 商品中分類名称
                salesDetailWork.BLGroupCode = salesDetail.BLGroupCode; // BLグループコード
                salesDetailWork.BLGroupName = salesDetail.BLGroupName; // BLグループコード名称
                salesDetailWork.BLGoodsCode = salesDetail.BLGoodsCode; // BL商品コード
                salesDetailWork.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL商品コード名称（全角）
                salesDetailWork.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // 自社分類コード
                salesDetailWork.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // 自社分類名称
                salesDetailWork.WarehouseCode = salesDetail.WarehouseCode; // 倉庫コード
                salesDetailWork.WarehouseName = salesDetail.WarehouseName; // 倉庫名称
                salesDetailWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // 倉庫棚番
                salesDetailWork.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // 売上在庫取寄せ区分
                salesDetailWork.OpenPriceDiv = salesDetail.OpenPriceDiv; // オープン価格区分
                salesDetailWork.GoodsRateRank = salesDetail.GoodsRateRank; // 商品掛率ランク
                salesDetailWork.CustRateGrpCode = salesDetail.CustRateGrpCode; // 得意先掛率グループコード
                salesDetailWork.ListPriceRate = salesDetail.ListPriceRate; // 定価率
                salesDetailWork.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // 掛率設定拠点（定価）
                salesDetailWork.RateDivLPrice = salesDetail.RateDivLPrice; // 掛率設定区分（定価）
                salesDetailWork.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // 単価算出区分（定価）
                salesDetailWork.PriceCdLPrice = salesDetail.PriceCdLPrice; // 価格区分（定価）
                salesDetailWork.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // 基準単価（定価）
                salesDetailWork.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // 端数処理単位（定価）
                salesDetailWork.FracProcLPrice = salesDetail.FracProcLPrice; // 端数処理（定価）
                salesDetailWork.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // 定価（税込，浮動）
                salesDetailWork.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // 定価（税抜，浮動）
                salesDetailWork.ListPriceChngCd = salesDetail.ListPriceChngCd; // 定価変更区分
                salesDetailWork.SalesRate = salesDetail.SalesRate; // 売価率
                salesDetailWork.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
                salesDetailWork.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // 掛率設定区分（売上単価）
                salesDetailWork.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
                salesDetailWork.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // 価格区分（売上単価）
                salesDetailWork.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // 基準単価（売上単価）
                salesDetailWork.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
                salesDetailWork.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // 端数処理（売上単価）
                salesDetailWork.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
                salesDetailWork.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
                salesDetailWork.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // 売上単価変更区分
                salesDetailWork.CostRate = salesDetail.CostRate; // 原価率
                salesDetailWork.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
                salesDetailWork.RateDivUnCst = salesDetail.RateDivUnCst; // 掛率設定区分（原価単価）
                salesDetailWork.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
                salesDetailWork.PriceCdUnCst = salesDetail.PriceCdUnCst; // 価格区分（原価単価）
                salesDetailWork.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // 基準単価（原価単価）
                salesDetailWork.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // 端数処理単位（原価単価）
                salesDetailWork.FracProcUnCst = salesDetail.FracProcUnCst; // 端数処理（原価単価）
                salesDetailWork.SalesUnitCost = salesDetail.SalesUnitCost; // 原価単価
                salesDetailWork.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // 原価単価変更区分
                salesDetailWork.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL商品コード（掛率）
                salesDetailWork.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL商品コード名称（掛率）
                salesDetailWork.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
                salesDetailWork.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
                salesDetailWork.RateBLGroupCode = salesDetail.RateBLGroupCode; // BLグループコード（掛率）
                salesDetailWork.RateBLGroupName = salesDetail.RateBLGroupName; // BLグループ名称（掛率）
                salesDetailWork.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL商品コード（印刷）
                salesDetailWork.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL商品コード名称（印刷）
                salesDetailWork.SalesCode = salesDetail.SalesCode; // 販売区分コード
                salesDetailWork.SalesCdNm = salesDetail.SalesCdNm; // 販売区分名称
                salesDetailWork.WorkManHour = salesDetail.WorkManHour; // 作業工数
                salesDetailWork.ShipmentCnt = salesDetail.ShipmentCnt; // 出荷数
                salesDetailWork.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // 受注数量
                salesDetailWork.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // 受注調整数
                salesDetailWork.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // 受注残数
                salesDetailWork.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // 残数更新日
                salesDetailWork.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // 売上金額（税込み）
                salesDetailWork.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // 売上金額（税抜き）
                salesDetailWork.Cost = salesDetail.Cost; // 原価
                salesDetailWork.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // 粗利チェック区分
                salesDetailWork.SalesGoodsCd = salesDetail.SalesGoodsCd; // 売上商品区分
                salesDetailWork.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // 売上金額消費税額
                salesDetailWork.TaxationDivCd = salesDetail.TaxationDivCd; // 課税区分
                salesDetailWork.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // 相手先伝票番号（明細）
                salesDetailWork.DtlNote = salesDetail.DtlNote; // 明細備考
                salesDetailWork.SupplierCd = salesDetail.SupplierCd; // 仕入先コード
                salesDetailWork.SupplierSnm = salesDetail.SupplierSnm; // 仕入先略称
                salesDetailWork.OrderNumber = salesDetail.OrderNumber; // 発注番号
                salesDetailWork.WayToOrder = salesDetail.WayToOrder; // 注文方法
                salesDetailWork.SlipMemo1 = salesDetail.SlipMemo1; // 伝票メモ１
                salesDetailWork.SlipMemo2 = salesDetail.SlipMemo2; // 伝票メモ２
                salesDetailWork.SlipMemo3 = salesDetail.SlipMemo3; // 伝票メモ３
                salesDetailWork.InsideMemo1 = salesDetail.InsideMemo1; // 社内メモ１
                salesDetailWork.InsideMemo2 = salesDetail.InsideMemo2; // 社内メモ２
                salesDetailWork.InsideMemo3 = salesDetail.InsideMemo3; // 社内メモ３
                salesDetailWork.BfListPrice = salesDetail.BfListPrice; // 変更前定価
                salesDetailWork.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // 変更前売価
                salesDetailWork.BfUnitCost = salesDetail.BfUnitCost; // 変更前原価
                salesDetailWork.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // 一式明細番号
                salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
                salesDetailWork.CmpltMakerName = salesDetail.CmpltMakerName; // メーカー名称（一式）
                salesDetailWork.CmpltGoodsName = salesDetail.CmpltGoodsName; // 商品名称（一式）
                salesDetailWork.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // 数量（一式）
                salesDetailWork.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // 売上単価（一式）
                salesDetailWork.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // 売上金額（一式）
                salesDetailWork.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // 原価単価（一式）
                salesDetailWork.CmpltCost = salesDetail.CmpltCost; // 原価金額（一式）
                salesDetailWork.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // 相手先伝票番号（一式）
                salesDetailWork.CmpltNote = salesDetail.CmpltNote; // 一式備考
                salesDetailWork.PrtGoodsNo = salesDetail.PrtGoodsNo; // 印刷用品番
                salesDetailWork.PrtMakerCode = salesDetail.PrtMakerCode; // 印刷用メーカーコード
                salesDetailWork.PrtMakerName = salesDetail.PrtMakerName; // 印刷用メーカー名称
                salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // 共通キー
                // --- ADD 2011/08/10 ---------->>>>>
                salesDetailWork.AcceptOrOrderKind = salesDetail.AcceptOrOrderKind;// 受発注種別
                salesDetailWork.InquiryNumber = salesDetail.InquiryNumber; // 問合せ番号
                salesDetailWork.InqRowNumber = salesDetail.InqRowNumber; // 問合せ行番号
                salesDetailWork.AutoAnswerDivSCM = salesDetail.AutoAnswerDivSCM; // 自動回答区分(SCM)
                // --- ADD 2011/08/10 ----------<<<<<
                salesDetailWork.AnswerDelivDate = salesDetail.AnswerDelivDate; // 回答納期// ADD 2011/09/29 
                salesDetailWork.WayToAcptOdr = salesDetail.WayToAcptOdr; //ADD  鄧潘ハン 2012/01/12   Redmine#27954
                // 2012/01/16 Add >>>
                salesDetailWork.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // 特記事項
                // 2012/01/16 Add <<<
                // ADD 2013/06/05 吉岡 2013/06/18配信 SCM障害№10385単体テスト時障害(既存) --------->>>>>>>>>>>>>>>>>>>>>>>>>
                salesDetailWork.CampaignCode = salesDetail.CampaignCode; // キャンペーンコード
                // ADD 2013/06/05 吉岡 2013/06/18配信 SCM障害№10385単体テスト時障害(既存) ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            return salesDetailWork;
        }

        #endregion // </売上明細データワーク>

        #endregion // </リモート用ワークデータ>

        /// <summary>
        /// 売上リストを生成します。
        /// </summary>
        /// <param name="canEntryCarMng">車両管理マスタに登録するフラグ</param>
        /// <returns>売上リスト</returns>
        public CustomSerializeArrayList CreateSalesList(out bool canEntryCarMng)
        {
            const string METHOD_NAME = "CreateSalesList(out bool)"; // ログ用

            // 回答してよいかの判定
            if (!CanCreateSalesList(SCMHeaderRecord))
            {
                #region <Log>

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                    "SCM全体設定マスタ.自動回答区分が「2:全て回答可能な場合」のため、回答を行いません。"
                ));

                #endregion // </Log>

                canEntryCarMng = false;
                return new CustomSerializeArrayList();
            }

            // 売上リスト
            CustomSerializeArrayList salesList = new CustomSerializeArrayList();
            {
                #region <売上データ>

                // 売上明細データを集計
                AddItUpSalesDetailData();

                // 売上データを補正
                canEntryCarMng = ReviseSalesSlip();

                //>>>2010/07/07 del
                //// 売上データ
                //AddSalesSlipDataToSalesList(salesList, SalesSlipData);
                //<<<2010/07/07 del

                #endregion // </売上データ>

                #region <売上明細リスト>

                // 売上明細リスト
                AddSalesDetailToSalesList(salesList, SalesDetailDataList);

                #endregion // </売上明細リスト>

                //>>>2010/07/07 add
                // 売上明細データを集計
                AddItUpSalesDetailData();

                // 売上データ
                AddSalesSlipDataToSalesList(salesList, SalesSlipData);
                //<<<2010/07/07 add

                #region <入金データと入金引当データ>

                // 受注ステータスが売上 && 売掛区分が商品 の場合に設定
                if (
                    SalesSlipData.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
                        &&
                    SalesSlipData.AccRecDivCd.Equals(0) // 0:商品 ※自動回答処理ではこの値で固定
                )
                {
                    // 入金データ
                    DepsitMainWork depsitMainWork = null;
                    // 入金引当データ
                    DepositAlwWork depositAlwWork = null;
                    // 同時に取得
                    TakeDepositParameter(ref _salesSlipData, out depsitMainWork, out depositAlwWork);

                    salesList.Add(depsitMainWork);  // 入金データ
                    salesList.Add(depositAlwWork);  // 入金引当データ
                }

                #endregion // </入金データと入金引当データ>

                #region <車両管理リスト>

                // 車両管理リスト
                ArrayList carManagementWorkList = new ArrayList();
                foreach (CarManagementWork carManagementWork in CarManagementList)
                {
                    carManagementWorkList.Add(carManagementWork);
                }
                salesList.Add(carManagementWorkList);

                #endregion // </車両管理リスト>

                #region <リモート参照用明細リスト>

                // リモート参照用明細リスト
                ArrayList slipDetailAddInfoWorkList = new ArrayList();
                foreach (SlipDetailAddInfoWork slipDetailAddInfoWork in SlipDetailAddInfoList)
                {
                    slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                }
                salesList.Add(slipDetailAddInfoWorkList);

                #endregion // </リモート参照用明細リスト>

            #if _ENABLED_SCM_

                // 受注ステータスが「20:受注」の場合、SCM受注系データは送信しない。
                // ただし、売上データは作成するので、
                // SCM受注系データの更新年月日、更新時分秒ミリ秒は設定しておく。
                DateTime updateDate = DateTime.Now;                         // 更新年月日
                int updateTime = SCMDataHelper.GetUpdateTime(updateDate);   // 更新時分秒ミリ秒

                #region <SCM受注データ>

                UserSCMOrderHeaderRecord userHeader = SCMHeaderRecord as UserSCMOrderHeaderRecord;
                if (userHeader != null)
                {
                    // 受注ステータスは在庫の状態で変化するので、最終的な結果で依存するフィールドを再設定
                    // 「20:受注」の場合、更新年月日、更新時分秒ミリ秒を設定
                    if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                    {
                        userHeader.UpdateDate = updateDate; // 017.更新年月日
                        userHeader.UpdateTime = updateTime; // 018.更新時分秒ミリ秒
                    }
                    // 036.回答作成区分
                    // 2011/02/18 >>>
                    //userHeader.AnswerCreateDiv = SCMSalesDataMaker.GetAnswerCreateDiv(userHeader.AcptAnOdrStatus);
                    userHeader.AnswerCreateDiv = GetAnswerCreateDiv(userHeader.AcptAnOdrStatus);
                    // 2011/02/18 <<<

                    userHeader.SalesTotalTaxInc = SalesSlipData.SalesTotalTaxInc;   // 031.売上伝票合計(税込み)
                    userHeader.SalesSubtotalTax = SalesSlipData.SalesSubtotalTax;   // 032.売上小計(税)

                    salesList.Add(userHeader.RealRecord);   
                }
                else
                {
                    Debug.Assert(false, "User型のSCM受注データではありません。");
                }

                #endregion // </SCM受注データ>

                #region <SCM受注データ(車両情報)>

                // SCM受注データ(車両情報)
                UserSCMOrderCarRecord userCar = SCMCarRecord as UserSCMOrderCarRecord;
                if (userCar != null)
                {
                    salesList.Add(userCar.RealRecord);
                }
                else
                {
                    Debug.Assert(false, "User型のSCM受注データ(車両情報)ではありません。");
                }

                #endregion // </SCM受注データ(車両情報)>

                #region <SCM受注明細データ(問合せ・発注)>

                #if _ENABLED_SCM_DETAIL_

                // 「20:受注」の場合、SCM受注明細データ(問合せ・発注)も書込む
                if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                {
                    // SCM受注明細データ(問合せ・発注)
                    ArrayList userDetailList = new ArrayList();
                    foreach (ISCMOrderDetailRecord detailRecord in SCMDetailRecordList)
                    {
                        UserSCMOrderDetailRecord userDetail = detailRecord as UserSCMOrderDetailRecord;
                        if (userDetail != null)
                        {
                            userDetail.UpdateDate = updateDate; // 更新年月日
                            userDetail.UpdateTime = updateTime; // 更新時分秒ミリ秒

                            userDetailList.Add(userDetail.RealRecord);
                        }
                        else
                        {
                            Debug.Assert(false, "User型のSCM受注明細データ(問合せ・発注)ではありません。");
                        }
                    }
                    salesList.Add(userDetailList);
                }

                #endif

                #endregion // </SCM受注明細データ(問合せ・発注)>

                #region <SCM受注明細データ(回答)>

                // SCM受注明細データ(回答)
                int salesRowNoCount = 0;
                ArrayList userAnswerList = new ArrayList();
                foreach (ISCMOrderAnswerRecord answerRecord in SCMAnswerRecordList)
                {
                    UserSCMOrderAnswerRecord userAnswer = answerRecord as UserSCMOrderAnswerRecord;
                    if (userAnswer != null)
                    {
                        // 「20:受注」の場合、更新年月日、更新時分秒ミリ秒を設定
                        if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                        {
                            userAnswer.UpdateDate = updateDate;
                            userAnswer.UpdateTime = updateTime;
                        }
                        userAnswer.SalesRowNo = ++salesRowNoCount;  // 055.売上行番号…連番付番(売上伝票番号単位)
                        userAnswerList.Add(userAnswer.RealRecord);
                    }
                    else
                    {
                        Debug.Assert(false, "User型のSCM受注明細データ(回答)ではありません。");
                    }
                }

                // DEL 2014/08/13 11070147-00 システムテスト障害№5対応 ----------------------------------->>>>>
                // Add 2014/08/11 duzg For 検証／総合テスト障害No.5 -------------------->>>>>>>>>>>>>>>>>>>
                // 品番入力検索の時、種別コード、名称は、空白で設定しています
                //if (SalesDetailDataList != null && SalesDetailDataList.Count != 0)
                //{
                //    for (int i = 0; i < SalesDetailDataList.Count; i++ )
                //    {
                //        SalesDetail detail = SalesDetailDataList[i];
                //        SCMAcOdrDtlAsWork userAnswer = null;
                //        if (userAnswerList.Count > i)
                //        {
                //            userAnswer = userAnswerList[i] as SCMAcOdrDtlAsWork;
                //        }
                //        if (userAnswer != null)
                //        {
                //            if (detail.GoodsSearchDivCd == 1
                //                && detail.GoodsNo == userAnswer.GoodsNo)
                //            {
                //                userAnswer.PrmSetDtlName2 = string.Empty;
                //                userAnswer.PrmSetDtlNo2 = 0;
                //            }
                //        }
                //    }
                //}
                // Add 2014/08/11 duzg For 検証／総合テスト障害No.5 --------------------<<<<<<<<<<<<<<<<<<<
                // DEL 2014/08/13 11070147-00 システムテスト障害№5対応 -----------------------------------<<<<<

                salesList.Add(userAnswerList);
                #endregion // </SCM受注明細データ(回答)>

                // -- ADD 2011/08/10   ------ >>>>>>
                // 在庫確認の場合
                if (userHeader.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry))
                {
                    #region <SCM受注セットデータ>
                    // SCM受注明細データ(回答)
                    int setRowNoCount = 0;
                    ArrayList userSetList = new ArrayList();

                    foreach (ISCMAcOdSetDtRecord setRecord in SCMSetDtRecordList)
                    {
                        UserSCMAcOdSetDtRecord userSet = setRecord as UserSCMAcOdSetDtRecord;
                        if (userSet != null)
                        {
                            // 「20:受注」の場合、更新年月日、更新時分秒ミリ秒を設定
                            if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                            {
                                userSet.UpdateDateTime = updateDate;
                            }
                            userSet.PMSalesRowNo = ++setRowNoCount;  // 055.売上行番号…連番付番(売上伝票番号単位)
                            userSetList.Add(userSet.RealRecord);
                        }
                        else
                        {
                            Debug.Assert(false, "User型のSCM受注セットデータではありません。");
                        }
                    }
                    salesList.Add(userSetList);
                    #endregion // </SCM受注セットデータ>
                }
                // -- ADD 2011/08/10   ------ <<<<<<
            #endif
            }
            return salesList;
        }

        // 2011/02/18 Add >>>
        /// <summary>
        /// 回答作成区分を取得します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <returns>
        /// 受注ステータスが「10:見積」「30:売上」の場合、「0:自動」を返します。<br/>
        /// それ以外（「20:受注」）の場合、「1:手動(Web)」を返します。
        /// </returns>
        protected virtual int GetAnswerCreateDiv(int acptAnOdrStatus)
        {
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// 売上リストを生成できるか判断します。
        /// </summary>
        /// <param name="scmHeaderRecord">SCM受注データのレコード</param>
        /// <returns>
        /// <c>true</c> :売上リストを生成できます。<br/>
        /// <c>false</c>:売上リストを生成できません。
        /// </returns>
        protected virtual bool CanCreateSalesList(ISCMOrderHeaderRecord scmHeaderRecord)
        {
            return true;
        }

        /// <summary>
        /// 売上データを売上リストに追加します。
        /// </summary>
        /// <param name="salesList">売上リスト</param>
        /// <param name="salesSlip">売上データ</param>
        protected virtual void AddSalesSlipDataToSalesList(
            CustomSerializeArrayList salesList,
            SalesSlip salesSlip
        )
        {
            salesList.Add(salesSlip);
        }

        /// <summary>
        /// 売上明細データを売上リストに追加します。
        /// </summary>
        /// <remarks>
        /// 自動連携値引きとキャンペーンを反映し、SCM受注明細データ(回答)への展開も行います。
        /// </remarks>
        /// <param name="salesList">売上リスト</param>
        /// <param name="salesDetailDataList">売上明細データのリスト</param>
        protected virtual void AddSalesDetailToSalesList(
            CustomSerializeArrayList salesList,
            IList<SalesDetail> salesDetailDataList
        )
        {
            const string METHOD_NAME = "AddSalesDetailToSalesList()";   // ログ用

            int salesRowNoCount = 0;
            ArrayList salesDetailWorkList = new ArrayList();
            foreach (SalesDetail salesDetail in salesDetailDataList)
            {
                bool isDiscountApply = false; // ADD 黄興貴 2013/04/17 for Redmine#35271
                // DEL 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ---------->>>>>
                #region 削除コード

                //// 自動連携値引きとキャンペーンを反映
                //SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                //{
                //    priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                //    PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                //    if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                //    {
                //        salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.売上単価(税込, 浮動)
                //        salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.売上単価(税抜, 浮動)
                //    }
                //}

                #endregion // 削除コード
                // DEL 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ----------<<<<<
                // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ---------->>>>>
                // 2011/01/11 >>>
                // UPD 2015/01/19 リコメンド対応 --------------------------------------------------->>>>>
                #region 削除
                //// 見積計上と返品は自動連携値引、キャンペーン値引対象外
                ////if (!IsEstimateAddingUp(salesDetail))
                //// SCM品目設定で価格を回答しないケースがあるので、単価がある場合のみ
                //ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                //if (!IsEstimateAddingUp(salesDetail) &&
                //    !IsRetuanSlip(salesDetail))
                //    // 2011/01/11 <<<
                #endregion // 削除
                // SCM品目設定で価格を回答しないケースがあるので、単価がある場合のみ
                ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                // 見積計上と返品、リコメンド発注時は自動連携値引、キャンペーン値引対象外
                if (!IsEstimateAddingUp(salesDetail) &&
                    !IsRetuanSlip(salesDetail) &&
                    !IsRecommend(salesDetail, answerRecord))
                // UPD 2015/01/19 リコメンド対応 ---------------------------------------------------<<<<<
                if (!IsEstimateAddingUp(salesDetail))
                {
                    // 自動連携値引きとキャンペーンを反映
                    SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                    {
                        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                        //priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                        priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail,
                            (answerRecord.CancelCndtinDiv != 0) ? (short)1 : (short)0,
                            salesDetail.SalesDate);
                        // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                        PriceValue priceValue;
                        //>>>2012/04/09
                        //if (salesDetail.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&answerRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
                        //{
                        //    priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail.TaxationDivCd, SalesSlipData.TotalAmountDispWayCd, salesDetail.SalesUnPrcTaxExcFl);

                        //}
                        //else
                        //{
                        //    priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                        //}

                        priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                        //<<<2012/04/09

                        if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                        {
                            // UPD 2012/08/24 三戸 2012/09/12配信システム障害№16 対応 ---------->>>>>>>>>>>>>>>>>>>>>>>
                            //salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.売上単価(税込, 浮動)
                            //salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.売上単価(税抜, 浮動)
                            // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            //if (answerRecord.UnitPrice > 0)
                            //{
                            // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // UPD 2012/09/12 湯上 障害対応--------------------->>>>>
                            //salesDetail.SalesUnPrcTaxIncFl = salesDetail.ListPriceTaxIncFl; // 069.売価(税込,浮動)
                            //salesDetail.SalesUnPrcTaxExcFl = salesDetail.ListPriceTaxExcFl; // 070.売価(税抜,浮動)
                            salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.売価(税込,浮動)
                            salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.売価(税抜,浮動)
                            // UPD 2012/09/12 湯上 障害対応---------------------<<<<<
                            isDiscountApply = priceCalculator.IsDiscountApply; // ADD 黄興貴 2013/04/17 for Redmine#35271
                            // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            //}
                            // --- DEL 2013/04/17 三戸 2013/05/22配信分 SCM障害№10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // UPD 2012/08/24 三戸 2012/09/12配信システム障害№16 対応 ----------<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
                else
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("自動連携値引きとキャンペーンは反映しません。∵見積で回答済み商品です"));

                    #endregion // </Log>
                }
                // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ----------<<<<<
                SalesDetail salesDetailWork = salesDetail;
                {
                    salesDetailWork.SalesRowNo = ++salesRowNoCount; // 012.売上行番号
                    salesDetailWork.SalesSlipDtlNum = 0;            // 018.売上明細通番
                }
                // --- ADD 黄興貴 2013/04/17 for Redmine#35271 --------->>>>>
                if (isDiscountApply)
                {
                    salesDetailWork.SalesRate = 0.0;
                }
                // --- ADD 黄興貴 2013/04/17 for Redmine#35271 ---------<<<<<
                salesDetailWorkList.Add(salesDetailWork);

                // TODO:SCM受注明細データ(回答)へ展開…売伝側ではSCM受注系データは利用してないので、何もしないでおく
                //ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                //answerRecord.UnitPrice = (long)salesDetail.SalesUnPrcTaxIncFl;
                // 処理を行う場合、売上データがあるSCM受注系データがインプットデータのときに例外が発生するので、それを改修すること
                // ヒント：GetSCMAnswerRecord()でマップに登録されているキーとsalesDetailから生成するキーが合わない
            }
            salesList.Add(salesDetailWorkList);
        }

        // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ---------->>>>>
        /// <summary>
        /// 見積計上の売上明細データであるか判断します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <returns>
        /// <c>true</c> :見積計上の売上明細データです。<br/>
        /// <c>false</c>:見積計上の売上明細データではありません。
        /// </returns>
        protected static bool IsEstimateAddingUp(SalesDetail salesDetail)
        {
            // 計上元受注ステータスが見積で、計上元明細通番に値がある
            return salesDetail.AcptAnOdrStatusSrc.Equals((int)AcptAnOdrStatus.Estimate) && salesDetail.SalesSlipDtlNumSrc > 0;
        }
        // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ----------<<<<<

        // 2011/01/11 Add >>>
        /// <summary>
        /// 返品明細であるか判断します。
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns>
        /// <c>true</c> :返品の売上明細データです。<br/>
        /// <c>false</c>:返品の売上明細データではありません。
        /// </returns>
        protected static bool IsRetuanSlip(SalesDetail salesDetail)
        {
            // 計上元受注ステータスが見積で、計上元明細通番に値がある
            return salesDetail.AcptAnOdrStatusSrc.Equals((int)AcptAnOdrStatus.Sales) && salesDetail.SalesSlipDtlNumSrc > 0;
        }
        // 2011/01/11 Add <<<
        
        // 2015/01/19 リコメンド対応 ------------------------------------->>>>>
        /// <summary>
        /// リコメンド発注であるか判断します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="answerRecord">SCM受注明細データ(回答)データ</param>
        /// <returns>
        /// <c>true</c> :リコメンド発注の売上明細データです。<br/>
        /// <c>false</c>:リコメンド発注の売上明細データではありません。
        /// </returns>
        protected static bool IsRecommend(SalesDetail salesDetail, ISCMOrderAnswerRecord answerRecord)
        {
            // 前回回答データがなく、お買い得商品選択区分が「1:お買い得商品」の時
            return salesDetail.AcptAnOdrStatusSrc.Equals(0) && answerRecord.BgnGoodsDiv == (short)BgnGoodsDiv.BargainItem;
        }
        // 2015/01/19 リコメンド対応 -------------------------------------<<<<<

        #region <集計処理>

        /// <summary>
        /// 売上明細データを集計します。
        /// </summary>
        private void AddItUpSalesDetailData()
        {
            SalesSlipData.DetailRowCount = SalesDetailDataList.Count;   // 109.明細行数

            OtherAppComponent otherComponent = new OtherAppComponent(
                SalesSlipData.EnterpriseCode,
                SalesSlipData.SectionCode
            );

            #region <戻り値の宣言>

            long salesTotalTaxInc;      // 売上伝票合計（税込）
            long salesTotalTaxExc;      // 売上伝票合計（税抜）
            long salesSubtotalTax;      // 売上小計（税）
            long itdedSalesOutTax;      // 売上外税対象額
            long itdedSalesInTax;       // 売上内税対象額
            long salSubttlSubToTaxFre;  // 売上小計非課税対象額
            long salesOutTax;           // 売上金額消費税額（外税）
            long salAmntConsTaxInclu;   // 売上金額消費税額（内税）
            long salesDisTtlTaxExc;     // 売上値引金額計（税抜）
            long itdedSalesDisOutTax;   // 売上値引外税対象額合計
            long itdedSalesDisInTax;    // 売上値引内税対象額合計
            long itdedSalesDisTaxFre;   // 売上値引非課税対象額合計
            long salesDisOutTax;        // 売上値引消費税額（外税）
            long salesDisTtlTaxInclu;   // 売上値引消費税額（内税）
            long totalCost;             // 原価金額計

            long stockGoodsTtlTaxExc;   // 在庫商品合計金額(税抜)   …売上データに無い？
            long pureGoodsTtlTaxExc;    // 純正商品合計金額(税抜)   …売上データに無い？
            long balanceAdjust;         // 消費税調整額             …売上データに無い？
            long taxAdjust;             // 残高調整額               …売上データに無い？

            long salesPrtSubttlInc;     // 売上部品小計（税込）
            long salesPrtSubttlExc;     // 売上部品小計（税抜）
            long salesWorkSubttlInc;    // 売上作業小計（税込）
            long salesWorkSubttlExc;    // 売上作業小計（税抜）
            long itdedPartsDisInTax;    // 部品値引対象額合計（税込）
            long itdedPartsDisOutTax;   // 部品値引対象額合計（税抜）
            long itdedWorkDisInTax;     // 作業値引対象額合計（税込）
            long itdedWorkDisOutTax;    // 作業値引対象額合計（税抜）

            long totalMoneyForGrossProfit;  // 粗利計算用売上金額   …売上データに無い？

            #endregion // </戻り値の宣言>

            // --- DEL 2013/08/07 T.Yoshioka №10556 ---------->>>>>
            #region 旧ソース
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //int taxFracProcCd;
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka №10556 ----------<<<<<
            // --- ADD 2013/08/07 T.Yoshioka №10556 ---------->>>>>
            // 消費税端数処理コード を得意先情報から取得
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            SalesSlipData.FractionProcCd = customerInfoAcs.GetSalesFractionProcCd(SalesSlipData.EnterpriseCode, SalesSlipData.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // --- ADD 2013/08/07 T.Yoshioka №10556 ----------<<<<<
            #region <呼出し>

            otherComponent.CalculationSalesTotalPrice(
                (List<SalesDetail>)SalesDetailDataList, // 売上明細データリスト
                SalesSlipData.ConsTaxRate,              // 消費税税率
                SalesSlipData.FractionProcCd,           // 消費税端数処理コード
                SalesSlipData.TotalAmountDispWayCd,     // 総額表示方法区分
                SalesSlipData.ConsTaxLayMethod,         // 消費税転嫁方式
                // --- DEL 2013/08/07 T.Yoshioka №10556 ---------->>>>>
                #region 旧ソース
                //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
                //SalesSlipData.EnterpriseCode,           // 企業コード
                //SalesSlipData.CustomerCode,             // 得意先コード

                //out taxFracProcCd,                      // 端数処理区分
                //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
                #endregion
                // --- DEL 2013/08/07 T.Yoshioka №10556 ----------<<<<<

                out salesTotalTaxInc,       // 売上伝票合計（税込）
                out salesTotalTaxExc,       // 売上伝票合計（税抜）
                out salesSubtotalTax,       // 売上小計（税）
                out itdedSalesOutTax,       // 売上外税対象額
                out itdedSalesInTax,        // 売上内税対象額
                out salSubttlSubToTaxFre,   // 売上小計非課税対象額
                out salesOutTax,            // 売上金額消費税額（外税）
                out salAmntConsTaxInclu,    // 売上金額消費税額（内税）
                out salesDisTtlTaxExc,      // 売上値引金額計（税抜）
                out itdedSalesDisOutTax,    // 売上値引外税対象額合計
                out itdedSalesDisInTax,     // 売上値引内税対象額合計
                out itdedSalesDisTaxFre,    // 売上値引非課税対象額合計
                out salesDisOutTax,         // 売上値引消費税額（外税）
                out salesDisTtlTaxInclu,    // 売上値引消費税額（内税）
                out totalCost,              // 原価金額計

                out stockGoodsTtlTaxExc,    // 在庫商品合計金額(税抜)   …売上データに無い？
                out pureGoodsTtlTaxExc,     // 純正商品合計金額(税抜)   …売上データに無い？
                out balanceAdjust,          // 消費税調整額             …売上データに無い？
                out taxAdjust,              // 残高調整額               …売上データに無い？

                out salesPrtSubttlInc,      // 売上部品小計（税込）
                out salesPrtSubttlExc,      // 売上部品小計（税抜）
                out salesWorkSubttlInc,     // 売上作業小計（税込）
                out salesWorkSubttlExc,     // 売上作業小計（税抜）
                out itdedPartsDisInTax,     // 部品値引対象額合計（税込）
                out itdedPartsDisOutTax,    // 部品値引対象額合計（税抜）
                out itdedWorkDisInTax,      // 作業値引対象額合計（税込）
                out itdedWorkDisOutTax,     // 作業値引対象額合計（税抜）

                out totalMoneyForGrossProfit    // 粗利計算用売上金額   …売上データに無い？
            );

            #endregion // </呼出し>

            #region <戻り値を代入>
            // --- DEL 2013/08/07 T.Yoshioka №10556 ---------->>>>>
            #region 旧ソース
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //SalesSlipData.FractionProcCd = taxFracProcCd;
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka №10556 ----------<<<<<

            // --- UPD 2013/08/07 Y.Wakita ---------->>>>>
            //SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc;          // 040.売上伝票合計（税込）
            //SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc;          // 041.売上伝票合計（税抜）
            SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;          // 040.売上伝票合計（税込）
            SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;          // 041.売上伝票合計（税抜）
            // --- UPD 2013/08/07 Y.Wakita ----------<<<<<
            SalesSlipData.SalesSubtotalTax = salesSubtotalTax;          // 046.売上小計（税）
            SalesSlipData.ItdedSalesOutTax = itdedSalesOutTax;          // 054.売上外税対象額
            SalesSlipData.ItdedSalesInTax = itdedSalesInTax;            // 055.売上内税対象額
            SalesSlipData.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 056.売上小計非課税対象額
            SalesSlipData.SalesOutTax = salesOutTax;                    // 057.売上金額消費税額（外税）
            SalesSlipData.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 058.売上金額消費税額（内税）
            SalesSlipData.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 059.売上値引金額計（税抜）
            SalesSlipData.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 060.売上値引外税対象額合計
            SalesSlipData.ItdedSalesDisInTax = itdedSalesDisInTax;      // 061.売上値引内税対象額合計
            SalesSlipData.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 066.売上値引非課税対象額合計
            SalesSlipData.SalesDisOutTax = salesDisOutTax;              // 067.売上値引消費税額（外税）
            SalesSlipData.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 068.売上値引消費税額（内税）
            SalesSlipData.TotalCost = totalCost;                        // 071.原価金額計
            SalesSlipData.SalesPrtSubttlInc = salesPrtSubttlInc;        // 048.売上部品小計（税込）
            SalesSlipData.SalesPrtSubttlExc = salesPrtSubttlExc;        // 049.売上部品小計（税抜）
            SalesSlipData.SalesWorkSubttlInc = salesWorkSubttlInc;      // 050.売上作業小計（税込）
            SalesSlipData.SalesWorkSubttlExc = salesWorkSubttlExc;      // 051.売上作業小計（税抜）
            SalesSlipData.ItdedPartsDisInTax = itdedPartsDisInTax;      // 063.部品値引対象額合計（税込）
            SalesSlipData.ItdedPartsDisOutTax = itdedPartsDisOutTax;    // 062.部品値引対象額合計（税抜）
            SalesSlipData.ItdedWorkDisInTax = itdedWorkDisInTax;        // 065.作業値引対象額合計（税込）
            SalesSlipData.ItdedWorkDisOutTax = itdedWorkDisOutTax;      // 064.作業値引対象額合計（税抜）

            #endregion // </戻り値を代入>

            // 042.売上部品合計(税込み)…売上部品小計(税込み) + 部品値引対象額合計(税込み)
            SalesSlipData.SalesPrtTotalTaxInc = SCMSlipDataFactory.GetSalesPrtTotalTaxInc(SalesSlipData);
            // 043.売上部品合計(税抜き)…売上部品小計(税抜き) + 部品値引対象額合計(税抜き)
            SalesSlipData.SalesPrtTotalTaxExc = SCMSlipDataFactory.GetSalesPrtTotalTaxExc(SalesSlipData);
            // 044.売上作業合計(税込み)…売上作業小計(税込み) + 作業値引対象額合計(税込み)
            SalesSlipData.SalesWorkTotalTaxInc = SCMSlipDataFactory.GetSalesWorkTotalTaxInc(SalesSlipData);
            // 045.売上作業合計(税抜き)…売上作業小計(税抜き) + 作業値引対象額合計(税抜き)
            SalesSlipData.SalesWorkTotalTaxExc = SCMSlipDataFactory.GetSalesWorkTotalTaxExc(SalesSlipData);

            // 046.売上小計(税込み)…値引き後の明細金額の合計(非課税含まず)
            // ∴売上伝票合計(税込み) - 売上小計非課税対象額 + 売上値引非課税対象額合計
            SalesSlipData.SalesSubtotalTaxInc = SCMSlipDataFactory.GetSalesSubtotalTaxInc(SalesSlipData);
            // 047.売上小計(税抜き)…値引き後の明細金額の合計(非課税含まず)
            // ∴売上伝票合計(税抜き) - 売上小計非課税対象額 + 売上値引非課税対象額合計
            SalesSlipData.SalesSubtotalTaxExc = SCMSlipDataFactory.GetSalesSubtotalTaxExc(SalesSlipData);

            // 052.売上正価金額…売上伝票合計(税抜き) - 売上値引金額計(税抜き)
            SalesSlipData.SalesNetPrice = SCMSlipDataFactory.GetSalesNetPrice(SalesSlipData);

            // 069.部品値引率…小計に対しての部品値引率
            // ∴部品値引対象額合計(税込み) / 売上部品小計(税込み)
            SalesSlipData.PartsDiscountRate = SCMSlipDataFactory.GetPartsDiscountRate(SalesSlipData);

            // UNDONE:070.工賃値引率…小計に対しての工賃値引率
            // ∴作業値引対象額合計(税込み) / 売上作業小計(税込み)
            SalesSlipData.RavorDiscountRate = SCMSlipDataFactory.GetRavorDiscountRate(SalesSlipData);

            // UNDONE:075.売掛消費税…算出

            // 079.入金引当残高…売上伝票合計(税込) 消費税転嫁方式が「請求転嫁、非課税」の場合は税抜金額
            SalesSlipData.DepositAlwcBlnce = SCMSlipDataFactory.GetConsTaxLayMethod(SalesSlipData);

            // 128.在庫商品合計金額(税抜)…算出
            SalesSlipData.StockGoodsTtlTaxExc = SCMSlipDataFactory.GetStockGoodsTtlTaxExc(SalesDetailDataList);
            // 129.在庫商品合計金額(税込)…算出
            SalesSlipData.PureGoodsTtlTaxExc = SCMSlipDataFactory.GetPureGoodsTtlTaxExc(SalesDetailDataList);

            // 2010/07/07 Add >>>
            SalesSlipData.AccRecConsTax = salesSubtotalTax;
            // 2010/07/07 Add <<<
        }

        #endregion // </集計処理>

        #region <補正処理>

        /// <summary>
        /// 売上データを補正します。
        /// </summary>
        /// <remarks>MAHNB01010UA.cs MAHNB01010UA.ReviseSalesSlip() 3028行目より移植</remarks>
        /// <returns>車両管理マスタに登録するフラグ</returns>
        private bool ReviseSalesSlip()
        {
            #region <車両管理オプション>

            if (USBOption.EnabledCarManagementOption())
            {
                #region <車両管理区分(0:しない 1:登録(確認) 2:登録(自動) 3:登録無)>

                if (CarManagementList.Count > 0)
                {
                    switch (SalesSlipData.CarMngDivCd)
                    {
                        case 0: // しない
                            SalesSlipData.CarMngDivCd = 0;  // しない
                            break;
                        case 1: // HACK:登録(確認) ※自動回答処理では必要？
                            SalesSlipData.CarMngDivCd = 1;  // する
                            break;
                        case 2: // 登録(自動)
                            SalesSlipData.CarMngDivCd = 1;  // する
                            break;
                        case 3: // 登録無
                            SalesSlipData.CarMngDivCd = 0;  // しない
                            break;
                    }
                }
                else
                {
                    SalesSlipData.CarMngDivCd = 0;  // しない
                }

                #endregion // </車両管理区分(0:しない 1:登録(確認) 2:登録(自動) 3:登録無)>
            }
            else
            {
                SalesSlipData.CarMngDivCd = 0;  // しない
            }

            #endregion // </車両管理オプション>

            return SalesSlipData.CarMngDivCd.Equals(1);
        }

        #endregion // </補正処理>

        #region <入金データ/入金引当データ>

        /// <summary>
        /// 入金系パラメータ(入金データ/入金引当データ)を取得します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="depsitMainWork">入金データ</param>
        /// <param name="depositAlwWork">入金引当データ</param>
        private static void TakeDepositParameter(
            ref SalesSlip salesSlip,
            out DepsitMainWork depsitMainWork,
            out DepositAlwWork depositAlwWork
        )
        {
            OtherAppComponent otherComponent = new OtherAppComponent(
                salesSlip.EnterpriseCode,
                salesSlip.SectionCode
            );

            SearchDepsitMain searchDepsitMain = null;   // 入金データ
            SearchDepositAlw searchDepositAlw = null;   // 入金引当データ

            otherComponent.GetCurrentDepsitMain(ref salesSlip, out searchDepsitMain, out searchDepositAlw);

            // ワーク型に変換
            OtherAppComponent.ParamDataFromUIDataProc(searchDepsitMain, out depsitMainWork);
            depositAlwWork = OtherAppComponent.ConvertWork(searchDepositAlw);
        }

        #endregion // </入金データ/入金引当データ>

        #region <分割処理>

        /// <summary>
        /// 分割用のインスタンスを生成します。
        /// </summary>
        /// <returns>分割用のインスタンス</returns>
        protected virtual SCMSalesListEssence CreateSplitedEssence()
        {
            return new SCMSalesListEssence();
        }

        /// <summary>
        /// 売上データを分割します。
        /// </summary>
        /// <returns>分割された売上データ</returns>
        public IList<SCMSalesListEssence> Split()
        {
            // 売上明細データの最大数
            int salesDetailMax = GetMaxRowCount(SalesSlipData);

            // ソート済み売上明細データリスト
            IList<SalesDetail> sortedSalesDetailList = SortedSalesDetailListFactory.CreateSortedSalesDetailList(
                SalesSlipData,
                SalesDetailDataList
            );

            IList<SCMSalesListEssence> splitedEssenceList = new List<SCMSalesListEssence>();
            {
                int salesDetailCount = salesDetailMax;

                int currentEssenceIndex = -1;
                foreach (SalesDetail salesDetail in sortedSalesDetailList)
                {
                    // 売上明細データが最大数になったら、別伝票(売上データ)
                    if (salesDetailCount >= salesDetailMax)
                    {
                        splitedEssenceList.Add(CreateSplitedEssence());
                        currentEssenceIndex++;
                        salesDetailCount = 0;
                    }

                    // 売上明細データに対応するSCM受注明細データ(回答)を取得
                    ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);

                    // SCM受注明細データ(回答)に対応するSCM受注明細データ(問合せ・発注)を取得
                    ISCMOrderDetailRecord detailRecord = GetSCMDetailRecord(answerRecord);

                    // SCM受注明細データ(回答)を追加
                    splitedEssenceList[currentEssenceIndex].AddSCMAnswerRecord(answerRecord, detailRecord);

                    // 売上明細データを追加
                    splitedEssenceList[currentEssenceIndex].AddSalesDetailData(salesDetail.Clone(), answerRecord);

                    // リモート参照用明細パラメータを追加
                    SlipDetailAddInfoWork slipDetailAddInfo = GetSlipDetailAddInfo(answerRecord);
                    splitedEssenceList[currentEssenceIndex].AddSlipDetailAddInfo(slipDetailAddInfo, answerRecord);

                    // SCM受注明細データ(問合せ・発注)を追加
                    splitedEssenceList[currentEssenceIndex].AddSCMDetailRecord(detailRecord);

                    // ----- ADD 2011/08/10 ----- >>>>>
                    // SCM受注セットデータを追加
                    // 売上セットデータに対応するSCM受注セットデータを取得
                    List<ISCMAcOdSetDtRecord> setRecordList = GetSCMSetRecord(answerRecord);
                    if (setRecordList != null && setRecordList.Count > 0)
                    {
                        foreach (ISCMAcOdSetDtRecord SetDtRecord in setRecordList)
                        {
                            splitedEssenceList[currentEssenceIndex].AddSCMSetRecord(SetDtRecord);
                        }
                    }
                    // ----- ADD 2011/08/10 ----- <<<<<

                    salesDetailCount++; // 売上明細データをカウント
                }   // foreach (SalesDetail salesDetail in SalesDetailDataList)

                // 分割した伝票(売上データ)で共通の情報を設定
                foreach (SCMSalesListEssence salesListEssence in splitedEssenceList)
                {
                    // SCM受注データを追加
                    // SCM受注データ : 売上データ = n : 1 になるので、コピーを設定する
                    salesListEssence.SCMHeaderRecord = new UserSCMOrderHeaderRecord(
                        SCMHeaderRecord as UserSCMOrderHeaderRecord
                    );

                    // SCM受注データ(車両情報)を追加
                    // SCM受注データ(車両情報) : 売上データ = n : 1になるので、コピーを設定する
                    salesListEssence.SCMCarRecord = new UserSCMOrderCarRecord(
                        SCMCarRecord as UserSCMOrderCarRecord
                    );

                    // 売上データを追加
                    salesListEssence.SalesSlipData = SalesSlipData.Clone();
                    
                    // 車両管理データを追加
                    foreach (CarManagementWork carMng in CarManagementList)
                    {
                        salesListEssence.AddCarManagementData(carMng);
                    }
                }   // foreach (SCMSalesListEssence salesListEssence in splitedEssenceList)
            }

            // 相場回答分を追加する（空の場合、相場回答のみの処理が動作するので無視）
            if (!ListUtil.IsNullOrEmpty(splitedEssenceList))
            {
                int lastEssenceIndex = splitedEssenceList.Count - 1;
                foreach (ISCMOrderAnswerRecord answerRecord in SCMAnswerRecordList)
                {
                    if (!IsSobaAnswer(answerRecord)) continue;

                    // SCM受注明細データ(回答)に対応するSCM受注明細データ(問合せ・発注)を取得
                    ISCMOrderDetailRecord detailRecord = GetSCMDetailRecord(answerRecord);

                    // SCM受注明細データ(回答)を追加
                    splitedEssenceList[lastEssenceIndex].AddSCMAnswerRecord(answerRecord, detailRecord);
                }
            }
            return splitedEssenceList;
        }

        /// <summary>
        /// 相場回答であるか判断します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>
        /// <c>true</c> :相場回答です。<br/>
        /// <c>false</c>:相場回答ではありません。
        /// </returns>
        private static bool IsSobaAnswer(ISCMOrderAnswerRecord answerRecord)
        {
            if (
                answerRecord.GoodsDivCd.Equals((int)GoodsDivCd.MarketPrice)
                    ||
                answerRecord.GoodsDivCd.Equals((int)GoodsDivCd.Recycle)
            )
            {
                return true;
            }
            return false;
        }

        #endregion // </分割処理>

        #region <売上明細の最大行数>

        /// <summary>デフォルト最大明細行数</summary>
        public static readonly int DEFAULT_MAX_ROW_COUNT = 9999;

        /// <summary>
        /// 明細最大行数を取得します。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.GetMaxRowCount() 14110行目より移植
        /// </remarks>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>明細最大行数</returns>
        private static int GetMaxRowCount(SalesSlip salesSlip)
        {
            int maxRowCount = DEFAULT_MAX_ROW_COUNT;
            {
                SlipPrtSet slipPrtSet = null;
                // FIXME:switch ((AcptAnOdrStatus)salesSlip.AcptAnOdrStatusDisplay)
                switch ((AcptAnOdrStatus)salesSlip.AcptAnOdrStatus)
                {
                    case AcptAnOdrStatus.Estimate:  // 見積
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.EstimateSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Order:     // 受注
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.AcceptSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Sales:     // 売上
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, salesSlip);
                        break;
                }
                if ((slipPrtSet != null) && (slipPrtSet.DetailRowCount > 0)) maxRowCount = slipPrtSet.DetailRowCount;
            }
            return maxRowCount;
        }

        #endregion // </売上明細の最大行数>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCM受注セットデータ>

        /// <summary>SCM受注セットデータとSCM受注明細データ(問合せ・発注)の関連マップ</summary>
        private IDictionary<Guid, List<ISCMAcOdSetDtRecord>> _SetDetailMap;
        /// <summary>SCM受注セットデータとSCM受注明細データ(問合せ・発注)の関連マップを取得します。</summary>
        /// <remarks>キー：回答データの関連GUID</remarks>
        private IDictionary<Guid, List<ISCMAcOdSetDtRecord>> SetDetailMap
        {
            get
            {
                if (_SetDetailMap == null)
                {
                    _SetDetailMap = new Dictionary<Guid, List<ISCMAcOdSetDtRecord>>();
                }
                return _SetDetailMap;
            }
        }

        /// <summary>
        /// SCM受注セットデータのレコードを追加します。
        /// </summary>
        /// <param name="scmAnswerRecord">CM受注明細データ(回答)のレコード</param>
        /// <param name="OdSetDtRecordList">SCM受注セットデータのレコードリスト</param>
        /// <exception cref="ArgumentNullException">
        /// 追加するSCM受注セットデータのレコードがnullです。<br/>
        /// 元となったSCM受注明細データ(問合せ・発注)のレコードがnullです。
        /// </exception>
        public void AddSCMSetRecord(
            ISCMOrderAnswerRecord scmAnswerRecord,
            List<ISCMAcOdSetDtRecord> OdSetDtRecordList
        )
        {
            #region <Guard Phrase>

            if (scmAnswerRecord == null)
            {
                throw new ArgumentNullException("scmAnswerRecord", "追加するSCM受注セットデータのレコードがnullです。");
            }
            if (OdSetDtRecordList == null)
            {
                throw new ArgumentNullException("OdSetDtRecordList", "受注セットデータのレコードがnullです。");
            }

            #endregion // </Guard Phrase>
            for (int i = 0; i < OdSetDtRecordList.Count; i++)
            {
                AddSCMSetRecord(OdSetDtRecordList[i]);
            }
            // SCM受注セットデータとSCM受注明細データ(問合せ・発注)のマップに追加
            if (!SetDetailMap.ContainsKey(scmAnswerRecord.SalesRelationId))
            {
                SetDetailMap.Add(scmAnswerRecord.SalesRelationId, OdSetDtRecordList);
            }
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)のレコードを取得します。
        /// </summary>
        /// <param name="scmAnswerRecord">SCM受注セットデータのレコード</param>
        /// <returns>対応するSCM受注明細データ(問合せ・発注)のレコード</returns>
        public  List<ISCMAcOdSetDtRecord> GetSCMSetRecordList(ISCMOrderAnswerRecord scmAnswerRecord)
        {
            if (SetDetailMap.ContainsKey(scmAnswerRecord.SalesRelationId))
            {
                return SetDetailMap[scmAnswerRecord.SalesRelationId];
            }
            return null;
        }

        #endregion // <SCM受注セットデータ>
        // -- ADD 2011/08/10   ------ <<<<<<
    }
}
