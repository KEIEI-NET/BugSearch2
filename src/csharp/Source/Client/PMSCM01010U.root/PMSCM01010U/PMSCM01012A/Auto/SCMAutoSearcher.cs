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
// 作 成 日  2010/03/17  修正内容 : BLコード検索の不具合対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/31  修正内容 : 回答区分について、同一データの過去の回答も参照して判断するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/15  修正内容 : 回答区分がキャンセルの場合、自動回答しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/17  修正内容 : キャンセル区分が「1:キャンセルあり」の場合、自動回答しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/25  修正内容 : コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018  鈴木 正臣
// 作 成 日  2010/06/28  修正内容 : 成果物統合 品名表示に対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/01/11  修正内容 : ・BLコード検索時の在庫引当処理を追加
//                                 ・自動回答の品番検索で、同一品番選択画面を表示しないように修正
//                                 ・提供データ・商品に未登録の部品も売上伝票入力に展開されるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/02/14  修正内容 : ・取消明細を自動回答しないように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/08  修正内容 : 車輌検索の修正（車台番号での絞込みを追加、年式、カラー、トリムの絞り込みを修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : BLコード枝番追加等の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : PCCUOEの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/09/19  修正内容 : Readmine#25209対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/09/29  修正内容 : Readmine#25646対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/04/17  修正内容 : 障害№166 発注時に在庫の確認を行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2012/04/19  修正内容 : RC-SCM速度改良の修正
//                               ：（※検索結果が不正にならないようキャッシュクリアする）
//                               ：（※検索結果が不正にならないようキャッシュクリアする⇒不要なSearchInitialをやめて高速化）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/20  修正内容 : SCM障害№166、システム障害№98の戻し
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/25  修正内容 : SCM障害№10281 自動回答対象の倉庫は委託倉庫、優先（自拠点）倉庫のみ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/04  修正内容 : SCM障害№10281対応時の不具合対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/06  修正内容 : システム障害№53　同一商品の判断条件変更（SCM障害№10281対応時の不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/18  修正内容 : SCM障害№222　自動回答されない純正品に結合する優良品を回答しないよう修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/08/22  修正内容 : 9/12配信 システムテスト障害№13対応（SCM障害№222対応時のバグ）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/09/05  修正内容 : 9/12配信 システムテスト障害№30対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上 千加子
// 作 成 日  2012/11/07  修正内容 : 2012/11/14配信 システムテスト障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定システムテスト障害№31対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/12  修正内容 : SCM改良№10423対応 PCCforNS、BLPの委託在庫・参照在庫の判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/26  修正内容 : 2013/03/13配信 SCM改良№10468対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/14  修正内容 : SCM障害№10354対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/19  修正内容 : 2013/03/06配信 SCM障害№253対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/01  修正内容 : 2013/03/06配信予定 SCM障害№92　車両情報の装備情報を考慮した部品絞込みを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/26  修正内容 : 2013/03/06配信予定 システムテスト障害№63対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/03/01  修正内容 : 2013/03/06配信予定 サポート課検証結果№95対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/17  修正内容 : SCM障害№10355対応 2013/04/10配信
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2013/08/06  修正内容 : 2013/08/09配信システムテスト障害 №27対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/08/19  修正内容 : SCM仕掛一覧 №10552対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2014/01/16  修正内容 : 純正定価印字対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/05  修正内容 : SCM仕掛一覧№10627対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/06  修正内容 : SCM仕掛一覧№10632対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/16  修正内容 : SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№74対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/05/09  修正内容 : 速度改善フェーズ２№11,№12 絞込タイミング変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/05/27  修正内容 : SCM仕掛一覧№10658対応 ｼｽﾃﾑﾃｽﾄ障害№1対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/05/30  修正内容 : 商品保証課Redmine#1581対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/06/19  修正内容 : SCM仕一覧№10665対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2014/07/10  修正内容 : SCM仕一覧№10665対応(LDNS #42928)
//----------------------------------------------------------------------------//
// 管理番号 11070148-00  作成担当 : 杜志剛
// 作 成 日  2014/07/28  修正内容 : BLPの部品検索障害(№10370)
//----------------------------------------------------------------------------//
// 管理番号 11070148-00  作成担当 : 杜志剛
// 作 成 日  2014/08/08  修正内容 : 検証／総合テスト障害対応No.3
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/02/06  修正内容 : SCM高速化システムテスト障害154対応
//                                  特定の類別、BLコードにて問合せすると、自動回答されない対応
//----------------------------------------------------------------------------//
// 管理番号  11170206-00 作成担当 : 顧棟
// 作 成 日  2016/01/13  修正内容 : Redmine#48055 2016年2月配信分
//                                : TBO対応 SFからTBOを含む品目を問合せした場合、TBO品目のBLコード検索異常が発生した為、
//                                : 他の品目も含めて全て手動回答となってしまう対応
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/05/15  修正内容 : PMKOBETSU-3932 BLP障害（ログ強化）
//                                : 既存コードのログ出力強化を行う
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources; // ADD 2010/08/10
using System.Data; // ADD 2010/08/10

namespace Broadleaf.Application.Controller.Auto
{
    using SCMOrderHeaderRecordType = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ

    /// <summary>
    /// SCM自動用検索処理クラス
    /// </summary>
    public sealed class SCMAutoSearcher : SCMSearcher
    {
        private const string MY_NAME = "SCMAutoSearcher";   // ログ用
        private const string LinkBreak = "\r\n";  //改行

        #region <倉庫マスタ>
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>倉庫マスタ</summary>
        private static WarehouseAgent _warehouseDB;

        /// <summary>倉庫マスタを取得します。</summary>
        private static WarehouseAgent WarehouseDB
        {
            get
            {
                if (_warehouseDB == null)
                {
                    _warehouseDB = new WarehouseAgent();
                }
                return _warehouseDB;
            }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
        #endregion // </倉庫マスタ>

        /// <summary>品番検索の自動モード定数(1:自動)</summary>
        public const int MODE_OF_SEARCHING_GOODS_NO_IS_AUTO = 1;

        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 汎用構造体
        /// </summary>
        struct gpStruct
        {
            public string EquipmentGenreNm;
            public string EquipmentName;
        }
        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="orgAnswerRecordList"></param>
        /// <param name="orgDetailRecordList"></param>
        // 2010/03/31 >>>
        //public SCMAutoSearcher(
        //    IList<SCMOrderHeaderRecordType> headerRecordList,
        //    IList<SCMOrderCarRecordType> carRecordList,
        //    IList<SCMOrderDetailRecordType> detailRecordList
        //) : base(headerRecordList, carRecordList, detailRecordList)
        //{ }

        public SCMAutoSearcher(
            IList<SCMOrderHeaderRecordType> headerRecordList,
            IList<SCMOrderCarRecordType> carRecordList,
            IList<SCMOrderDetailRecordType> detailRecordList,
            IList<SCMOrderAnswerRecordType> orgAnswerRecordList,
            IList<SCMOrderDetailRecordType> orgDetailRecordList
            )
            : base(headerRecordList, carRecordList, detailRecordList, orgAnswerRecordList, orgDetailRecordList)
        { }
        // 2010/03/31 <<<

        #endregion // </Constructor>

        #region <Override>

        #region <検索を行えるかの判定>

        /// <summary>
        /// 検索を行えるか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="answerList">SCM受注明細データ(回答)のレコード</param>
        /// <returns>
        /// <c>true</c> :検索を行えます。<br/>
        /// <c>false</c>:検索を行えません。
        /// </returns>
        /// <see cref="SCMSearcher"/>
        // 2011/02/14 >>>
        //protected override bool CanSearch(SCMOrderDetailRecordType scmOrderDetailRecord)
        protected override bool CanSearch(SCMOrderDetailRecordType scmOrderDetailRecord, List<ISCMOrderAnswerRecord> answerList)
        // 2011/02/14 <<<
        {
            // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
            const string METHOD_NAME = "CanSearch()";
            // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<

            SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                scmOrderDetailRecord.InqOtherEpCd,
                scmOrderDetailRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
            if (foundTotalSetting != null)
            {
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //// DEL 2010/04/15 回答区分がキャンセルの場合、自動回答しない ---------->>>>>
                ////return !foundTotalSetting.AutoAnswerDiv.Equals((int)AutoAnswerDiv.None);
                //// DEL 2010/04/15 回答区分がキャンセルの場合、自動回答しない ----------<<<<<
                //// ADD 2010/04/15 回答区分がキャンセルの場合、自動回答しない ---------->>>>>
                //bool canSearch = !foundTotalSetting.AutoAnswerDiv.Equals((int)AutoAnswerDiv.None);
                //// ADD 2011/08/10 gaofeng >>>
                //// SCMの場合(PCCUOEの場合不要)
                //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
                //{
                //// ADD 2011/08/10 gaofeng <<<
                //    if (!canSearch)
                //    {
                //        // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
                //        #region <Log>

                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("SCM全体設定が「自動回答しない」です。"));

                //        #endregion // </Log>
                //        // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<
                //        return false;
                //    }
                //// ADD 2011/08/10 gaofeng >>>
                //}
                //// ADD 2011/08/10 gaofeng <<<
                #endregion

                bool canSearch = false;
                //問合せ時に自動回答区分（問合せ）が「しない（手動）」の時、自動回答しない
                if (scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry))
                {
                    canSearch = !foundTotalSetting.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.None);
                }
                //発注時に自動回答区分（発注）が「しない（手動）」の時、自動回答しない
                else if (scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Order))
                {
                    canSearch = !foundTotalSetting.AutoAnsOrderDiv.Equals((int)AutoAnsOrderDiv.None);
                }
                // SCMの場合(PCCUOEの場合不要)
                if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
                {
                    if (!canSearch)
                    {
                        // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
                        #region <Log>

                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("SCM全体設定の自動回答区分が「しない（手動）」です。"));

                        #endregion // </Log>
                        // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<
                        return false;
                    }
                }

                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

                // 2011/02/14 >>>
                //// DEL 2010/06/17 キャンセル区分が「1:キャンセルあり」の場合、自動回答しない ---------->>>>>
                ////// 回答区分がキャンセルの場合、自動回答しない
                ////return !CurrentHeaderRecord.AnswerDivCd.Equals((int)AnswerDivCd.Cancel);
                //// ADD 2010/04/15 回答区分がキャンセルの場合、自動回答しない ----------<<<<<
                //// DEL 2010/06/17 キャンセル区分が「1:キャンセルあり」の場合、自動回答しない ----------<<<<<
                //// ADD 2010/06/17 キャンセル区分が「1:キャンセルあり」の場合、自動回答しない ---------->>>>>
                //// キャンセル区分が「1:キャンセルあり」の場合、自動回答しない
                //canSearch = !CurrentHeaderRecord.CancelDiv.Equals((short)CancelDiv.ExistsCancel);
                //if (!canSearch)
                //{
                //    // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
                //    #region <Log>

                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("キャンセル区分が「1:キャンセルあり」です。"));

                //    #endregion // </Log>
                //    // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<
                //    return false;
                //}
                //// ADD 2010/06/17 キャンセル区分が「1:キャンセルあり」の場合、自動回答しない ----------<<<<<


                canSearch = !( scmOrderDetailRecord.CancelCndtinDiv == (short)CancelCndtinDiv.Cancelling || scmOrderDetailRecord.CancelCndtinDiv == (short)CancelCndtinDiv.Cancelled );
                if (!canSearch)
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("キャンセル状態区分が「30:キャンセル確定」か「10:キャンセル要求」です。"));

                    #endregion // </Log>
                    return false;
                }

                // 2011/02/14 <<<

                // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
                // CMT連携区分が「1:連携あり」の場合、自動回答しない
                canSearch = !CurrentHeaderRecord.CMTCooprtDiv.Equals(1);
                if (!canSearch)
                {
                    // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ---------->>>>>
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("CMT連携区分が「1:連携あり」です。"));

                    #endregion // </Log>
                    // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<
                    return false;
                }
                // ADD 2010/06/25 コミュニケーションツールがオンライン時における受信処理の自動回答フィルタリングを廃止 ----------<<<<<

                // --- DEL 2013/08/06 T.Miyamoto ------------------------------>>>>>
                //if (CurrentHeaderRecord.AcceptOrOrderKind != (int)EnumAcceptOrOrderKind.PCCUOE)
                //{
                //    // 2011/02/14 Add >>>
                //    if (( scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry ) && ( answerList != null )) // ADD 2011/09/29
                //    { // ADD 2011/09/29
                //        ISCMOrderAnswerRecord answerRecord = answerList.Find(
                //                delegate(ISCMOrderAnswerRecord answer)
                //                {
                //                    if (( scmOrderDetailRecord.InqOriginalEpCd.Equals(answer.InqOriginalEpCd) ) &&
                //                        ( scmOrderDetailRecord.InqOriginalSecCd.Equals(answer.InqOriginalSecCd) ) &&
                //                        ( scmOrderDetailRecord.InqOtherEpCd.Equals(answer.InqOtherEpCd) ) &&
                //                        ( scmOrderDetailRecord.InqOtherSecCd.Equals(answer.InqOtherSecCd) ) &&
                //                        ( scmOrderDetailRecord.InquiryNumber.Equals(answer.InquiryNumber) ) &&
                //                        ( scmOrderDetailRecord.InqOrdDivCd.Equals(answer.InqOrdDivCd) ) &&
                //                        ( scmOrderDetailRecord.InqRowNumber.Equals(answer.InqRowNumber) ) &&
                //                        ( scmOrderDetailRecord.InqRowNumDerivedNo.Equals(answer.InqRowNumDerivedNo) ))
                //                        return true;
                //                    return false;
                //                }
                //            );

                //        if (answerRecord != null)
                //        {
                //            #region <Log>

                //            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("再問合せ明細です"));

                //            #endregion // </Log>

                //            return false;
                //        }
                //    }
                //    // 2011/02/14 Add <<<
                //} // ADD 2011/09/29
                // --- DEL 2013/08/06 T.Miyamoto ------------------------------<<<<<
                return true;
            }

            return false; ;
        }

        #endregion // </検索を行えるかの判定>

        #region <品番検索>
        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromGoodsNo(
            GoodsCndtn searchingCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            const string METHOD_NAME = "SearchPartsFromGoodsNo()";  // ログ用

            Debug.WriteLine("\t自動回答処理：GoodsAccesser.SearchPartsFromGoodsNoWholeWord()");
            // ----- ADD 2011/09/19 ----- >>>>>
            int status = (int)ResultUtil.ResultCode.NotFound;
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            #region 削除(SCM改良の為)
            //// PCCUOE場合
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //{
            //    // 品番検索(結合検索有り)
            //    status = GoodsAccesser.SearchPartsFromGoodsNo(
            //        searchingCondition,
            //        out partsInfoDB,
            //        out goodsUnitDataList,
            //        out msg
            //    );
            //}
            //else
            //{
            #endregion
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            // 品番検索(結合検索有り完全一致)
            EasyLogger.Write(MY_NAME, METHOD_NAME, "品番検索(結合検索有り完全一致) 開始" + "パラメータ:" + GetGoodsSearchCondition(searchingCondition));// ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            status = GoodsAccesser.SearchPartsFromGoodsNoWholeWord(
                searchingCondition,
                // 2011/01/11 >>>
                false,
                // 2011/01/11 <<<
                out partsInfoDB,
                out goodsUnitDataList,
                out msg
            );
            EasyLogger.Write(MY_NAME, METHOD_NAME, "品番検索(結合検索有り完全一致) 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //}
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            // ----- ADD 2011/09/19 ----- <<<<<
            // ----- DELETE 2011/09/19 ----- >>>>>
            // 品番検索(結合検索有り完全一致)
            //int status = GoodsAccesser.SearchPartsFromGoodsNoWholeWord(
            //    searchingCondition,
            //    // 2011/01/11 >>>
            //    false,
            //    // 2011/01/11 <<<
            //    out partsInfoDB,
            //    out goodsUnitDataList,
            //    out msg
            //);
            // ----- DELETE 2011/09/19 ----- <<<<<
            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                // ----- ADD 2011/08/10 ----- >>>>>
                if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM
                    || (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && !status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)))
                {
                // ----- ADD 2011/08/10 ----- <<<<<
                    #region <Log>

                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg(msg, status));

                    string message = "品番検索(結合検索有り完全一致)…品番=" + searchingCondition.GoodsNo;
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

                    #endregion // </Log>
                // ----- ADD 2011/08/10 ----- >>>>>
                }
                else
                {
                    #region <Log>

                    string message = "PCCUOEの場合、品番検索結果はないため、用品入力として回答する。";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

                    #endregion // </Log>
                }
                // ----- ADD 2011/08/10 ----- <<<<<
            }
            if (partsInfoDB != null)
            {
                // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                //// ----- UPD 2011/08/10 ----->>>>>
                ////// 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                ////partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
                //{
                //    // 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                //    partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                //}
                //else{
                //    // 優先倉庫リスト(PCCUOE)を設定
                //    partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                //}
                //// ----- UPD 2011/08/10 -----<<<<<
                // 優先倉庫リスト(PCCUOE)を設定
                EasyLogger.Write(MY_NAME, METHOD_NAME, "優先倉庫リスト(PCCUOE)を設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "優先倉庫リスト(PCCUOE)を設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                // --- ADD m.suzuki 2010/06/28 ---------->>>>>
                SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                    searchingCondition.EnterpriseCode,
                    searchingCondition.SectionCode
                );
                if (foundSsalesTtlSt != null)
                {
                    partsInfoDB.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                }
                // --- ADD m.suzuki 2010/06/28 ----------<<<<<

                partsInfoDB.Mode = MODE_OF_SEARCHING_GOODS_NO_IS_AUTO;  // 1:自動回答モード
                // ADD 2011/08/10 gaofeng >>>
                partsInfoDB.AcceptOrOrderKind = CurrentHeaderRecord.AcceptOrOrderKind; // 受発注種別
                // ADD 2011/08/10 gaofeng <<<

                // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                EasyLogger.Write(MY_NAME, METHOD_NAME, "部品選択UIを表示 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                TakePartsInfoByAutoOperation(partsInfoDB, null);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "部品選択UIを表示 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

                //// ADD 2011/08/10 gaofeng >>>
                //if (CurrentHeaderRecord.AcceptOrOrderKind = EnumAcceptOrOrderKind.PCCUOE 
                //    && goodsUnitDataList != null && goodsUnitDataList.Count > 0 
                //    && partsInfoDB.ListPriorWarehouse != null && partsInfoDB.ListPriorWarehouse.Count > 0)
                //{
                //    // 商品データに紐づく優先倉庫情報をセットする
                //    this.AttachStock(ref goodsUnitDataList, partsInfoDB.ListPriorWarehouse);
                //}
                //// ADD 2011/08/10 gaofeng <<<

                // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ---------->>>>>
                // --- ADD 三戸 2012/04/17 №166 ---------->>>>>
                // 倉庫情報をセット
                //this.AttachStock(ref goodsUnitDataList, partsInfoDB.ListPriorWarehouse);
                // --- ADD 三戸 2012/04/17 №166 ----------<<<<<
                // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ----------<<<<<
            }

            // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 在庫リストの編集
            EasyLogger.Write(MY_NAME, METHOD_NAME, "在庫リストの編集 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            EditStockList(ref goodsUnitDataList, partsInfoDB.ListPriorWarehouse);
            EasyLogger.Write(MY_NAME, METHOD_NAME, "在庫リストの編集 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <param name="searchingConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromGoodsNo(
            List<GoodsCndtn> searchingConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            out string msg
        )
        {
            const string METHOD_NAME = "SearchPartsFromGoodsNo()";  // ログ用

            Debug.WriteLine("\t自動回答処理：GoodsAccesser.SearchPartsFromGoodsNoWholeWord()");
            int status = (int)ResultUtil.ResultCode.NotFound;
            // 品番検索(結合検索有り完全一致)
            status = GoodsAccesser.SearchPartsFromGoodsNoWholeWord(
                searchingConditionList,
                false,
                out partsInfoDBList,
                out goodsUnitDataList,
                out msg
            );
            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM
                    || (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && !status.Equals((int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)))
                {
                    #region <Log>

                    EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetErrorMsg(msg, status));

                    string message = "品番検索(結合検索有り完全一致)…品番=" + searchingConditionList[0].GoodsNo;
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

                    #endregion // </Log>
                }
                else
                {
                    #region <Log>

                    string message = "PCCUOEの場合、品番検索結果はないため、用品入力として回答する。";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

                    #endregion // </Log>
                }

            }
            if (partsInfoDBList != null && partsInfoDBList.Count != 0)
            {
                // 優先倉庫リスト(PCCUOE)を設定
                List<string> priorWarehouse = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
                SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                    searchingConditionList[0].EnterpriseCode,
                    searchingConditionList[0].SectionCode
                );

                for (int i = 0; i < partsInfoDBList.Count; i++)
                {
                    PartsInfoDataSet partsInfoDBTemp = partsInfoDBList[i];
                    // UPD 2014/04/16 SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№74対応 ------------------------------->>>>>
                    //List<GoodsUnitData> goodsUnitDataListTemp = goodsUnitDataList[i];
                    List<GoodsUnitData> goodsUnitDataListTemp;
                    if (goodsUnitDataList != null && goodsUnitDataList.Count != 0)
                    {
                        goodsUnitDataListTemp = goodsUnitDataList[i];
                    }
                    else
                    {
                        goodsUnitDataListTemp = new List<GoodsUnitData>();
                    }
                    // UPD 2014/04/16 SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№74対応 -------------------------------<<<<<

                    // 優先倉庫リスト(PCCUOE)を設定
                    partsInfoDBTemp.ListPriorWarehouse = priorWarehouse;

                    if (foundSsalesTtlSt != null)
                    {
                        partsInfoDBTemp.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                    }

                    partsInfoDBTemp.Mode = MODE_OF_SEARCHING_GOODS_NO_IS_AUTO;  // 1:自動回答モード
                    partsInfoDBTemp.AcceptOrOrderKind = CurrentHeaderRecord.AcceptOrOrderKind; // 受発注種別

                    // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                    TakePartsInfoByAutoOperation(partsInfoDBTemp, null);
                    // 在庫リストの編集
                    EditStockList(ref goodsUnitDataListTemp, partsInfoDBTemp.ListPriorWarehouse);
                }
            }

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        #endregion // </品番検索>

        #region <車両検索>

        /// <summary>
        /// 車両を検索します。
        /// </summary>
        /// <remarks>
        /// MAHNB01010UA.cs::MAHNB01010UA.CarSearch() l.10346 を参考
        /// </remarks>
        /// <param name="searchingCarCondition">検索条件</param>
        /// <param name="carRecord">SCM受注データ(車両情報)のレコード</param>
        /// <param name="searchedCarInfo">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <see cref="SCMSearcher"/>
        protected override CarSearchResultReport SearchCar(
            CarSearchCondition searchingCarCondition,
            // 2011/03/08 >>>
            ISCMOrderCarRecord carRecord,
            // 2011/03/08 <<<
            ref PMKEN01010E searchedCarInfo
        )
        {
            // 検索結果が複数あった場合、選択ウィンドウは表示しない
            // 2011/03/08 >>>
            //CarSearchResultReport resultReport = base.SearchCar(searchingCarCondition, ref searchedCarInfo);
            CarSearchResultReport resultReport = base.SearchCar(searchingCarCondition, carRecord, ref searchedCarInfo);
            // 2011/03/08 <<<

            // 車種選択
            if (resultReport.Equals(CarSearchResultReport.retMultipleCarKind))
            {
                return resultReport;    // 手動回答とする。
            }

            // 2011/03/08 Add >>>

            // UPD 2013/02/26 T.Yoshioka 2013/03/06配信予定 システムテスト障害№63 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// UPD 2013/02/14 SCM障害№10354対応 ------------------------------------->>>>>
            ////int searchFrameNo = TStrConv.StrToIntDef(carRecord.ChassisNo, 0);
            //int searchFrameNo = TStrConv.StrToIntDef(carRecord.FrameNo, 0);
            //// UPD 2013/02/14 SCM障害№10354対応 -------------------------------------<<<<<
            #endregion
            string frameModel = string.Empty;
            string chassisNo = string.Empty;
            int status = -1;
            int searchFrameNo = 0;
            if (!String.IsNullOrEmpty(carRecord.FrameNo))
            {
                status = SCMSalesDataMaker.GenerateChassisNoFrameFromFrameNo(carRecord.FrameNo, out frameModel, out chassisNo);
                if (status.Equals(0))
                {
                    searchFrameNo = TStrConv.StrToIntDef(chassisNo, 0);
                }
                else
                {
                    searchFrameNo = 0;
                }
            }
            // UPD 2013/02/26 T.Yoshioka 2013/03/06配信予定 システムテスト障害№63 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            int produceTypeOfYearNum = (carRecord.ProduceTypeOfYearNum == 0) ? searchedCarInfo.GetProduceTypeOfYear(searchFrameNo) : carRecord.ProduceTypeOfYearNum;
            // 2011/03/08 Add <<<

            // Add 2014/07/28 duzg For BLPの部品検索障害(№10370) --------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // SCM受注データ(車両情報)に、取得した生産年式を返す（ただし、SFで未設定のときだけ）
            //if (carRecord.ProduceTypeOfYearNum.Equals(0) && !produceTypeOfYearNum.Equals(0))// Del 2014/08/08 duzg For 検証／総合テスト障害対応
            if (carRecord.ProduceTypeOfYearNum.Equals(0) && produceTypeOfYearNum > 0)// Add 2014/08/08 duzg For 検証／総合テスト障害対応
            {
                carRecord.ProduceTypeOfYearNum = produceTypeOfYearNum;
            }
            // Add 2014/07/28 duzg For BLPの部品検索障害(№10370) ---------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 型式選択…型式選択ウィンドウ表示対象となった場合、型式選択ウィンドウ表示を行わず、
            // 全選択として処理結果を戻す
            if (resultReport.Equals(CarSearchResultReport.retMultipleCarModel))
            {
                // 2011/03/08 >>>
                //searchedCarInfo.AllSelect();

                // 年式、車台番号で絞り込み
                int selectedCnt = 0;
                if (produceTypeOfYearNum > 0)
                {
                    selectedCnt = searchedCarInfo.SelectCarModelProduceTypeOfYear(produceTypeOfYearNum);
                }
                else if (searchFrameNo > 0)
                {
                    selectedCnt = searchedCarInfo.SelectCarModelSearchFrameNo(searchFrameNo);
                }

                if (selectedCnt == 0)
                {
                    searchedCarInfo.AllSelect();
                }
                // 2011/03/08 <<<
                CarAccesser.Search(searchingCarCondition, ref searchedCarInfo);
            }

            // 2011/03/08 Add >>>
            if (searchedCarInfo.CarModelInfoSummarized != null && searchedCarInfo.CarModelInfoSummarized.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow row = searchedCarInfo.CarModelInfoSummarized[0];

                // 年式の絞込み
                if (produceTypeOfYearNum != 0)
                {
                    int stDate = ( ( ( row.StProduceTypeOfYear / 100 ) == 9999 ) || ( ( row.StProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : row.StProduceTypeOfYear;
                    int edDate = ( ( ( row.EdProduceTypeOfYear / 100 ) == 9999 ) || ( ( row.EdProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : row.EdProduceTypeOfYear;

                    if (stDate != 0 || edDate != 0)
                    {
                        edDate = ( edDate == 0 ) ? 999999 : edDate;

                        if (stDate <= produceTypeOfYearNum && produceTypeOfYearNum <= edDate)
                        {
                            searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = produceTypeOfYearNum;
                        }
                    }
                }

                if (searchFrameNo != 0)
                {
                    if (( row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo ) ||
                        ( row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo ))
                    {
                    }
                    else
                    {
                        searchedCarInfo.CarModelUIData[0].FrameNo = searchFrameNo.ToString();
                        searchedCarInfo.CarModelUIData[0].SearchFrameNo = searchFrameNo;
                    }
                }
            }
            
            // カラーの絞込み
            if (!string.IsNullOrEmpty(carRecord.RpColorCode))
            {
                PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, carRecord.RpColorCode));
                if (colorRows.Length > 0)
                {
                    colorRows[0].SelectionState = true;
                }
            }

            // トリムの絞込み
            if (!string.IsNullOrEmpty(carRecord.TrimCode))
            {
                PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, carRecord.TrimCode));
                if (trimRows.Length > 0)
                {
                    trimRows[0].SelectionState = true;
                }
            }
            // 2011/03/08 Add <<<

            return resultReport;
        }

        #endregion // </車両検索>

        #region <BL検索>
        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCodeCarInfo(
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
            , PMKEN01010E carInfo
        )
        {
            Debug.WriteLine("\t自動回答処理：SCMAutoSearcher.SearchPartsFromBLCodeCarInfo()");

            List<string> priorWarehouseList = null;

            // 優先倉庫リスト(PCCUOE)を設定
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "優先倉庫リスト(PCCUOE)を設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            priorWarehouseList = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "優先倉庫リスト(PCCUOE)を設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

            int status = (int)ResultUtil.ResultCode.Normal;
            partsInfoDB = null;
            goodsUnitDataList = null;
            msg = string.Empty;
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "部品検索データセットと商品連結データリストの情報取得 開始 " + "パラメータ：" + GetGoodsSearchCondition(searchingGoodsCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
               searchingGoodsCondition,
               out partsInfoDB,
               out goodsUnitDataList,
               out msg
            );
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "部品検索データセットと商品連結データリストの情報取得 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (partsInfoDB != null)
                {
                    // 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                    partsInfoDB.ListPriorWarehouse = priorWarehouseList;

                    SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                        searchingGoodsCondition.EnterpriseCode,
                        searchingGoodsCondition.SectionCode
                    );
                    if (foundSsalesTtlSt != null)
                    {
                        partsInfoDB.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                    }

                    // HACK:BLコード枝番

                    partsInfoDB.Mode = MODE_OF_SEARCHING_GOODS_NO_IS_AUTO;  // 1:自動回答モード
                }

                DialogResult ret = DialogResult.None;

                // 自動回答対象抽出フラグ
                bool autoAnswerSelcectFlag = false;
                // SCM全体設定マスタ取得
                SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                    CurrentHeaderRecord.InqOtherEpCd,
                    CurrentHeaderRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                if (foundTotalSetting != null)
                {
                    // 問合せで自動回答区分（問合せ）が「する」の時、自動回答対象の抽出を行う
                    if (CurrentHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry &&
                        foundTotalSetting.AutoAnsInquiryDiv != (int)AutoAnsInquiryDiv.None)
                    {
                        autoAnswerSelcectFlag = true;
                    }
                    // 発注で自動回答区分（発注）が「する」の時、自動回答対象の抽出を行う
                    else if (CurrentHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Order &&
                        foundTotalSetting.AutoAnsOrderDiv != (int)AutoAnsOrderDiv.None)
                    {
                        autoAnswerSelcectFlag = true;
                    }
                }
                // 自動回答対象の抽出を行う場合
                if (autoAnswerSelcectFlag)
                {
                    int index = 0;
                    List<GoodsUnitData> goodsUnitDataListByIndex = new List<GoodsUnitData>();
                    if (partsInfoDB != null)
                    {
                        // 編集後商品リストの作成(商品中分類等、SCM品目設定を抽出するのに必要な情報取得のため)
                        List<GoodsUnitData> revisedGoodsUnitDataList = new List<GoodsUnitData>();
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                        {
                            GoodsUnitData revisedGoodsUnitData = goodsUnitData.Clone();
                            revisedGoodsUnitData.EnterpriseCode = CurrentHeaderRecord.InqOtherEpCd;
                            revisedGoodsUnitData.SectionCode = CurrentHeaderRecord.InqOtherSecCd;

                            GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref revisedGoodsUnitData);
                            if (revisedGoodsUnitData != null)
                            {
                                revisedGoodsUnitData.SectionCode = CurrentHeaderRecord.InqOtherSecCd;
                                revisedGoodsUnitDataList.Add(revisedGoodsUnitData);
                            }
                        }

                        #region 装備情報による絞込み
                        List<int> equipmentGenreCdList = new List<int>();
                        List<gpStruct> strctList = new List<gpStruct>();

                        foreach (PartsInfoDataSet.OfrEquipInfoRow row in partsInfoDB.OfrEquipInfo)
                        {
                            // 作成済みの装備は飛ばす
                            if (equipmentGenreCdList.Contains(row.EquipmentGenreCd)) continue;

                            // EquipmentGenreCd で絞込
                            string filter = string.Format("{0}={1}",
                                carInfo.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, row.EquipmentGenreCd);
                            carInfo.CEqpDefDspInfo.DefaultView.RowFilter = filter;

                            // 車両情報から、選択状態＝trueの装備情報を保管
                            for (int i = 0; i < carInfo.CEqpDefDspInfo.DefaultView.Count; i++)
                            {
                                PMKEN01010E.CEqpDefDspInfoRow carRow = (PMKEN01010E.CEqpDefDspInfoRow)carInfo.CEqpDefDspInfo.DefaultView[i].Row;
                                // --- UPD 2013/08/19 T.Miyamoto ------------------------------>>>>>
                                //if (carRow.SelectionState)
                                if ((carRow.SelectionState) && (carRow.EquipmentCode != 0))
                                // --- UPD 2013/08/19 T.Miyamoto ------------------------------<<<<<
                                {
                                    gpStruct w = new gpStruct();
                                    w.EquipmentGenreNm = carRow.EquipmentGenreNm;
                                    w.EquipmentName = carRow.EquipmentName;
                                    strctList.Add(w);
                                }
                            }

                            equipmentGenreCdList.Add(row.EquipmentGenreCd);
                        }

                        // 装備情報で絞り込むための検索条件を作成
                        string innerFilter = string.Empty;
                        // ADD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                        Dictionary<long, PartsInfoDataSet.PartsInfoRow> dPRows = new Dictionary<long,PartsInfoDataSet.PartsInfoRow>();
                        // ADD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                        foreach (gpStruct w in strctList)
                        {
                            innerFilter = string.Format("{0} = '{1}' AND ({2}='{3}' OR {4}='')",
                                partsInfoDB.OfrEquipInfo.EquipmentGenreNmColumn.ColumnName, w.EquipmentGenreNm,
                                partsInfoDB.OfrEquipInfo.EquipmentNameColumn.ColumnName, w.EquipmentName,
                                partsInfoDB.OfrEquipInfo.EquipmentNameColumn.ColumnName);

                            // 不要な装備情報、partsInfoを削除
                            PartsInfoDataSet.OfrEquipInfoRow[] dEQRows = (PartsInfoDataSet.OfrEquipInfoRow[])partsInfoDB.OfrEquipInfo.Select("NOT(" + innerFilter + ")");
                            // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                            //List<PartsInfoDataSet.PartsInfoRow> dPRows = new List<PartsInfoDataSet.PartsInfoRow>();
                            dPRows.Clear();
                            // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<

                            foreach (PartsInfoDataSet.OfrEquipInfoRow row in dEQRows)
                            {
                                foreach (PartsInfoDataSet.PartsInfoRow prow in partsInfoDB.PartsInfo)
                                {
                                    if (row.PartsProperNo.Equals(prow.PartsUniqueNo))
                                    {
                                        // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                                        //dPRows.Add(prow);
                                        if (!dPRows.ContainsKey(prow.PartsUniqueNo))
                                        {
                                            // 未登録ののPartsInfoのみ削除対象とする
                                            dPRows.Add(prow.PartsUniqueNo, prow);
                                        }
                                        // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                                    }
                                }

                                // 装備情報から削除
                                partsInfoDB.OfrEquipInfo.RemoveOfrEquipInfoRow(row);
                            }
                            // PartsInfoから削除
                            // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                            //foreach (PartsInfoDataSet.PartsInfoRow dprow in dPRows)
                            //{
                            //    partsInfoDB.PartsInfo.RemovePartsInfoRow(dprow);
                            //}
                            foreach (long key in dPRows.Keys)
                            {
                                partsInfoDB.PartsInfo.RemovePartsInfoRow(dPRows[key]);
                            }
                            // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                        }
                        #endregion 装備情報による絞込み

                        DataView partsInfoDafaultView = new DataView();
                        partsInfoDB.PartsInfo.DefaultView.Sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                        partsInfoDB.PartsInfo.SeriesModelColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.CategorySignModelColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.ExhaustGasSignColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.FullModelFixedNoColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.PartsQtyColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.PartsOpNmColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                        );
                        partsInfoDafaultView = partsInfoDB.PartsInfo.DefaultView;

                        List<PartsInfoDataSet.PartsInfoRow> partsInfoRowList = new List<PartsInfoDataSet.PartsInfoRow>();
                        for (int i = 0; i < partsInfoDafaultView.Count; i++)
                        {
                            DataRow dataRow = partsInfoDafaultView[i].Row;

                            partsInfoDB.SelectIndex = index;
                            index = index + 1;

                            // --- ADD 2013/03/01 三戸 2013/03/06配信分 サポート課検証結果№95 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            partsInfoDB.ListSelectionInfo = new Dictionary<int, SelectionInfo>();
                            // --- ADD 2013/03/01 三戸 2013/03/06配信分 サポート課検証結果№95 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "自動操作による部品選択 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            ret = TakePartsInfoByAutoOperation(partsInfoDB, CurrentCarInfo);
                            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "自動操作による部品選択 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            // --- ADD 2013/03/01 三戸 2013/03/06配信分 サポート課検証結果№95 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            if (ret.Equals(DialogResult.None)) continue;
                            // --- ADD 2013/03/01 三戸 2013/03/06配信分 サポート課検証結果№95 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                            // 同じ部品が複数ある場合は処理しない
                            PartsInfoDataSet.PartsInfoRow trow = (PartsInfoDataSet.PartsInfoRow)dataRow;
                            if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                                                        {
                                                            return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                                                                pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen &&
                                                                pirow.ClgPrtsNoWithHyphen != trow.ClgPrtsNoWithHyphen);
                                                        }
                                                        ))
                            {
                                // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDB.UsrJoinParts.Rows)
                                {
                                    // 自動回答しない対象の優良部品情報を保管
                                    if (prow.JoinSourceMakerCode == trow.CatalogPartsMakerCd
                                     && prow.JoinSrcPartsNoWithH == trow.ClgPrtsNoWithHyphen)
                                    {
                                        delRows.Add(prow);
                                    }
                                }
                                // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                {
                                    partsInfoDB.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                }
                                continue;
                            }
                            // 旧品番・新品番が同一の時は何も処理しない
                            if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                                                        {
                                                            return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                                                                pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen &&
                                                                pirow.ClgPrtsNoWithHyphen == trow.ClgPrtsNoWithHyphen);
                                                        }
                                                        ))
                            {
                                continue;
                            }
                            partsInfoRowList.Add(trow);
                            // DEL 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
                            //AutoAnsItemStAgent autoAnsItemStDB = new AutoAnsItemStAgent();
                            // DEL 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
                            List<AutoAnsItemSt> foundAutoAnsItemStList = null;
                            PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDB.ListSelectionInfo[0].RowGoods;   // 選択中の商品

                            // 自動回答品目設定マスタ取得
                            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "自動回答品目設定マスタ取得 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            foundAutoAnsItemStList = autoAnsItemStDB.Search(revisedGoodsUnitDataList, CurrentHeaderRecord.CustomerCode);
                            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "自動回答品目設定マスタ取得 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

                            bool existNewGoodsNo = false;
                            AutoAnsItemSt selectAutoAnsItemSt = new AutoAnsItemSt();

                            foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                            {
                                if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                    goods.GoodsNo == row.NewGoodsNo)
                                {
                                    existNewGoodsNo = true;
                                    // 自動回答品目設定マスタを検索
                                    selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                    break;
                                }
                            }
                            // 新品番で見つからない場合、旧品番で検索
                            if (!existNewGoodsNo)
                            {
                                foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                                {
                                    if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                        goods.GoodsNo == row.GoodsNo)
                                    {
                                        // 自動回答品目設定マスタを検索
                                        selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                        break;
                                    }
                                }
                            }

                            // 自動回答品目設定マスタに登録がない場合、次の品目へ
                            if (selectAutoAnsItemSt == null)
                            {
                                continue;
                            }

                            // 自動回答品目設定マスタ.自動回答区分の判定
                            bool autoAnswer = false;
                            if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None))
                            {
                                // UPD 2013/02/17 2013/04/10配信 SCM障害№10355対応 ------------------------------------->>>>>
                                //autoAnswer = true;
                                // ダミー品番でなければ自動回答する
                                if (trow.PrimeJoinLnkFlg.Equals(0))
                                {
                                    autoAnswer = true;
                                }
                                // UPD 2013/02/17 2013/04/10配信 SCM障害№10355対応 -------------------------------------<<<<<
                            }

                            // 自動回答する設定では無い場合、partsInfoDB.UsrJoinPartsを編集し、次の品目へ
                            if (!autoAnswer)
                            {
                                // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDB.UsrJoinParts.Rows)
                                {
                                    // 自動回答しない対象の優良部品情報を保管
                                    if (prow.JoinSourceMakerCode == row.GoodsMakerCd
                                        && prow.JoinSrcPartsNoWithH == row.GoodsNo)
                                    {
                                        delRows.Add(prow);
                                    }
                                }
                                // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                {
                                    partsInfoDB.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                }

                                // 次の品目へ
                                continue;
                            }

                            if (ret == DialogResult.OK)
                            {
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                                //goodsUnitDataListByIndex.AddRange(new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData))));
                                goodsUnitDataListByIndex.AddRange(new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsListWithSrc(true, 0).ToArray(typeof(GoodsUnitData))));
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                    }
                    if (!ListUtil.IsNullOrEmpty(goodsUnitDataListByIndex))
                    {
                        goodsUnitDataList = goodsUnitDataListByIndex;
                    }
                    else
                    {
                        status = (int)ResultUtil.ResultCode.NotFound;
                    }
                }
                // 自動回答対象の抽出を行わない場合
                else
                {
                    // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                    EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "部品選択UIを表示 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                    ret = TakePartsInfoByAutoOperation(partsInfoDB, CurrentCarInfo);
                    EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "部品選択UIを表示 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

                    if (ret == DialogResult.OK)
                    {
                        // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                        //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData)));
                        goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsListWithSrc(true, 0).ToArray(typeof(GoodsUnitData)));
                        // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                    }
                    else
                    {
                        this.AttachStock(ref goodsUnitDataList, priorWarehouseList);
                    }
                }
            }

            EasyLogger.Dump(partsInfoDB, "【自動部品情報取得結果】PartsInfoDataSet");

            // 在庫リストの編集
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "在庫リストの編集 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            EditStockList(ref goodsUnitDataList, priorWarehouseList);
            EasyLogger.Write(MY_NAME, "SearchPartsFromBLCodeCarInfo", "在庫リストの編集 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            return status;
        }
        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="statusList">各明細の検索結果リスト</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCodeCarInfo(
            List<GoodsCndtn> searchingGoodsConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            out List<int> statusList,
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
            out string msg
            , PMKEN01010E carInfo
        )
        {
            Debug.WriteLine("\t自動回答処理：SCMAutoSearcher.SearchPartsFromBLCodeCarInfo()");

            List<string> priorWarehouseList = null;

            // 優先倉庫リスト(PCCUOE)を設定
            priorWarehouseList = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);

            int status = (int)ResultUtil.ResultCode.Normal;
            partsInfoDBList = null;
            goodsUnitDataList = null;
            msg = string.Empty;
            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            statusList = new List<int>();
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<

            // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 部品検索アクセスクラスに、自動回答品目設定マスタ、拠点コード、得意先コード
            GoodsAccesser.FoundAutoAnsItemStList = autoAnsItemStDB.Search(CurrentHeaderRecord.InqOtherEpCd, CurrentHeaderRecord.InqOtherSecCd, CurrentHeaderRecord.CustomerCode);
            GoodsAccesser.SectionCode = CurrentHeaderRecord.InqOtherSecCd.Trim();
            GoodsAccesser.CustomerCode = CurrentHeaderRecord.CustomerCode;
            // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/05/27 SCM仕掛一覧№10658対応システムテスト障害№1対応 -------------------------------------------->>>>>
            // 純正品番の自動回答品目設定検索のためマスタデータを退避
            List<AutoAnsItemSt> foundAutoAnsItemStList = null;
            foundAutoAnsItemStList = autoAnsItemStDB.Search(CurrentHeaderRecord.InqOtherEpCd, CurrentHeaderRecord.InqOtherSecCd, CurrentHeaderRecord.CustomerCode);
            // ADD 2014/05/27 SCM仕掛一覧№10658対応システムテスト障害№1対応 --------------------------------------------<<<<<
            
            // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 ----->>>>>
            //自動回答の場合、TBO品目のBLコード検索異常の障害解除：TBO品目のBLコードは「100000」をプラスさせ、
            //存在しないBLコードを生成し、BLコード検索に0件データを戻し、エラーが発生しない。
            //検索条件の一時変更用（TBO品目のBLコードは「100000」をプラス）
            List<GoodsCndtn> tempGoodsConditionList = new List<GoodsCndtn>();
            GoodsCndtn tempGoodsCondition = new GoodsCndtn();
            foreach (GoodsCndtn cnd in searchingGoodsConditionList)
            {
                tempGoodsCondition = cnd.Clone();
                //TBOの判定：装備分類が「0」以外
                if (BLCodeDic.ContainsKey(tempGoodsCondition.BLGoodsCode) && BLCodeDic[tempGoodsCondition.BLGoodsCode] != 0)
                {
                    //TBO品目のBLコードは「100000」をプラスする
                    tempGoodsCondition.BLGoodsCode = tempGoodsCondition.BLGoodsCode + 100000;
                }
                tempGoodsConditionList.Add(tempGoodsCondition);
            }
            // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 -----<<<<<

            status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
               //searchingGoodsConditionList,// DEL 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応
               tempGoodsConditionList,// ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応
               out partsInfoDBList,
               out goodsUnitDataList,
               out msg
            );

            // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 部品検索アクセスクラス　設定内容クリア
            GoodsAccesser.FoundAutoAnsItemStList = null;
            GoodsAccesser.SectionCode = string.Empty;
            GoodsAccesser.CustomerCode = 0;
            // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                // 自動回答対象抽出フラグ
                bool autoAnswerSelcectFlag = false;
                // SCM全体設定マスタ取得
                SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                    CurrentHeaderRecord.InqOtherEpCd,
                    CurrentHeaderRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                if (foundTotalSetting != null)
                {
                    // 問合せで自動回答区分（問合せ）が「する」の時、自動回答対象の抽出を行う
                    if (CurrentHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry &&
                        foundTotalSetting.AutoAnsInquiryDiv != (int)AutoAnsInquiryDiv.None)
                    {
                        autoAnswerSelcectFlag = true;
                    }
                    // 発注で自動回答区分（発注）が「する」の時、自動回答対象の抽出を行う
                    else if (CurrentHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Order &&
                        foundTotalSetting.AutoAnsOrderDiv != (int)AutoAnsOrderDiv.None)
                    {
                        autoAnswerSelcectFlag = true;
                    }
                }

                if (partsInfoDBList != null && partsInfoDBList.Count != 0)
                {
                    List<List<GoodsUnitData>> goodsUnitDataListLump = new List<List<GoodsUnitData>>();

                    // ADD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                    Dictionary<long, PartsInfoDataSet.PartsInfoRow> dPRows = new Dictionary<long, PartsInfoDataSet.PartsInfoRow>();
                    // ADD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                    for (int j = 0; j < partsInfoDBList.Count; j++)
                    {
                        PartsInfoDataSet partsInfoDBTemp = partsInfoDBList[j];
                        List<GoodsUnitData> goodsUnitDataListTemp = goodsUnitDataList[j];

                        // 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                        partsInfoDBTemp.ListPriorWarehouse = priorWarehouseList;

                        SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                            searchingGoodsConditionList[0].EnterpriseCode,
                            searchingGoodsConditionList[0].SectionCode
                        );
                        if (foundSsalesTtlSt != null)
                        {
                            partsInfoDBTemp.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                        }

                        partsInfoDBTemp.Mode = MODE_OF_SEARCHING_GOODS_NO_IS_AUTO;  // 1:自動回答モード

                        DialogResult ret = DialogResult.None;
                        // 自動回答対象の抽出を行う場合
                        if (autoAnswerSelcectFlag)
                        {
                            int index = 0;
                            List<GoodsUnitData> goodsUnitDataListByIndex = new List<GoodsUnitData>();
                            if (partsInfoDBTemp != null)
                            {
                                // 編集後商品リストの作成(商品中分類等、SCM品目設定を抽出するのに必要な情報取得のため)
                                List<GoodsUnitData> revisedGoodsUnitDataList = new List<GoodsUnitData>();
                                foreach (GoodsUnitData goodsUnitData in goodsUnitDataListTemp)
                                {
                                    GoodsUnitData revisedGoodsUnitData = goodsUnitData.Clone();
                                    revisedGoodsUnitData.EnterpriseCode = CurrentHeaderRecord.InqOtherEpCd;
                                    revisedGoodsUnitData.SectionCode = CurrentHeaderRecord.InqOtherSecCd;

                                    GoodsAccesser.SettingGoodsUnitDataFromVariousMstForAutoSearch(ref revisedGoodsUnitData);
                                    if (revisedGoodsUnitData != null)
                                    {
                                        revisedGoodsUnitData.SectionCode = CurrentHeaderRecord.InqOtherSecCd;
                                        revisedGoodsUnitDataList.Add(revisedGoodsUnitData);
                                    }
                                }

                                #region 装備情報による絞込み
                                List<int> equipmentGenreCdList = new List<int>();
                                List<gpStruct> strctList = new List<gpStruct>();

                                foreach (PartsInfoDataSet.OfrEquipInfoRow row in partsInfoDBTemp.OfrEquipInfo)
                                {
                                    // 作成済みの装備は飛ばす
                                    if (equipmentGenreCdList.Contains(row.EquipmentGenreCd)) continue;

                                    // EquipmentGenreCd で絞込
                                    string filter = string.Format("{0}={1}",
                                        carInfo.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, row.EquipmentGenreCd);
                                    carInfo.CEqpDefDspInfo.DefaultView.RowFilter = filter;

                                    // 車両情報から、選択状態＝trueの装備情報を保管
                                    for (int i = 0; i < carInfo.CEqpDefDspInfo.DefaultView.Count; i++)
                                    {
                                        PMKEN01010E.CEqpDefDspInfoRow carRow = (PMKEN01010E.CEqpDefDspInfoRow)carInfo.CEqpDefDspInfo.DefaultView[i].Row;
                                        if ((carRow.SelectionState) && (carRow.EquipmentCode != 0))
                                        {
                                            gpStruct w = new gpStruct();
                                            w.EquipmentGenreNm = carRow.EquipmentGenreNm;
                                            w.EquipmentName = carRow.EquipmentName;
                                            strctList.Add(w);
                                        }
                                    }

                                    equipmentGenreCdList.Add(row.EquipmentGenreCd);
                                }

                                // 装備情報で絞り込むための検索条件を作成
                                string innerFilter = string.Empty;
                                foreach (gpStruct w in strctList)
                                {
                                    innerFilter = string.Format("{0} = '{1}' AND ({2}='{3}' OR {4}='')",
                                        partsInfoDBTemp.OfrEquipInfo.EquipmentGenreNmColumn.ColumnName, w.EquipmentGenreNm,
                                        partsInfoDBTemp.OfrEquipInfo.EquipmentNameColumn.ColumnName, w.EquipmentName,
                                        partsInfoDBTemp.OfrEquipInfo.EquipmentNameColumn.ColumnName);

                                    // 不要な装備情報、partsInfoを削除
                                    PartsInfoDataSet.OfrEquipInfoRow[] dEQRows = (PartsInfoDataSet.OfrEquipInfoRow[])partsInfoDBTemp.OfrEquipInfo.Select("NOT(" + innerFilter + ")");
                                    // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                                    //List<PartsInfoDataSet.PartsInfoRow> dPRows = new List<PartsInfoDataSet.PartsInfoRow>();
                                    dPRows.Clear();
                                    // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                                    foreach (PartsInfoDataSet.OfrEquipInfoRow row in dEQRows)
                                    {
                                        foreach (PartsInfoDataSet.PartsInfoRow prow in partsInfoDBTemp.PartsInfo)
                                        {
                                            if (row.PartsProperNo.Equals(prow.PartsUniqueNo))
                                            {
                                                // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                                                //dPRows.Add(prow);
                                                if (!dPRows.ContainsKey(prow.PartsUniqueNo))
                                                {
                                                    // 未登録ののPartsInfoのみ削除対象とする
                                                    dPRows.Add(prow.PartsUniqueNo, prow);
                                                }
                                                // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                                            }
                                        }

                                        // 装備情報から削除
                                        partsInfoDBTemp.OfrEquipInfo.RemoveOfrEquipInfoRow(row);
                                    }
                                    // PartsInfoから削除
                                    // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------>>>>>
                                    //foreach (PartsInfoDataSet.PartsInfoRow dprow in dPRows)
                                    //{
                                    //    partsInfoDBTemp.PartsInfo.RemovePartsInfoRow(dprow);
                                    //}
                                    foreach (long key in dPRows.Keys)
                                    {
                                        partsInfoDBTemp.PartsInfo.RemovePartsInfoRow(dPRows[key]);
                                    }
                                    // UPD 2015/02/06 豊沢 SCM高速化システムテスト障害154対応 ------------------------------------------<<<<<
                                }
                                #endregion 装備情報による絞込み

                                DataView partsInfoDafaultView = new DataView();
                                partsInfoDBTemp.PartsInfo.DefaultView.Sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                                partsInfoDBTemp.PartsInfo.SeriesModelColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.CategorySignModelColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.ExhaustGasSignColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.FullModelFixedNoColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.PartsQtyColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.PartsOpNmColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                                partsInfoDBTemp.PartsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                                );
                                partsInfoDafaultView = partsInfoDBTemp.PartsInfo.DefaultView;

                                // --- ADD 2014/07/10 T.Miyamoto SCM仕掛一覧№10665対応 -------------------->>>>>
                                // 結合情報を退避
                                PartsInfoDataSet.UsrJoinPartsDataTable usrJoinPartsDtTemp = new PartsInfoDataSet.UsrJoinPartsDataTable();
                                usrJoinPartsDtTemp = (PartsInfoDataSet.UsrJoinPartsDataTable)partsInfoDBTemp.UsrJoinParts.Copy();
                                partsInfoDBTemp.UsrJoinParts.Clear();
                                // --- ADD 2014/07/10 T.Miyamoto SCM仕掛一覧№10665対応 --------------------<<<<<
                                List<PartsInfoDataSet.PartsInfoRow> partsInfoRowList = new List<PartsInfoDataSet.PartsInfoRow>();
                                for (int i = 0; i < partsInfoDafaultView.Count; i++)
                                {
                                    DataRow dataRow = partsInfoDafaultView[i].Row;

                                    partsInfoDBTemp.SelectIndex = index;
                                    index = index + 1;

                                    partsInfoDBTemp.ListSelectionInfo = new Dictionary<int, SelectionInfo>();

                                    // 結合情報を結合元品番＞結合表示順に並び替え
                                    // --- UPD 2014/07/10 T.Miyamoto SCM仕掛一覧№10665対応 -------------------->>>>>
                                    //if (partsInfoDBTemp.UsrJoinParts != null && partsInfoDBTemp.UsrJoinParts.Count != 0)
                                    //{
                                    //    PartsInfoDataSet.UsrJoinPartsDataTable usrJoinPartsDtTemp = new PartsInfoDataSet.UsrJoinPartsDataTable();
                                    //    usrJoinPartsDtTemp = (PartsInfoDataSet.UsrJoinPartsDataTable)partsInfoDBTemp.UsrJoinParts.Copy();
                                    //    partsInfoDBTemp.UsrJoinParts.Clear();
                                    if (usrJoinPartsDtTemp != null && usrJoinPartsDtTemp.Count != 0)
                                    {
                                    // --- UPD 2014/07/10 T.Miyamoto SCM仕掛一覧№10665対応 --------------------<<<<<
                                        // 部品情報より結合元品番を取得し、結合情報を抽出する
                                        foreach (PartsInfoDataSet.PartsInfoRow partsInfoRow in partsInfoDBTemp.PartsInfo)
                                        {
                                            string filter = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                                                            partsInfoDBTemp.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, partsInfoRow.CatalogPartsMakerCd,
                                                            partsInfoDBTemp.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, partsInfoRow.ClgPrtsNoWithHyphen,
                                                            partsInfoDBTemp.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, partsInfoRow.NewPrtsNoWithHyphen);
                                            PartsInfoDataSet.UsrJoinPartsRow[] usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDtTemp.Select(filter, partsInfoDBTemp.UsrJoinParts.JoinDispOrderColumn.ColumnName);
                                            foreach (PartsInfoDataSet.UsrJoinPartsRow usrJoinPartsRow in usrJoinPartsRows)
                                            {
                                                // UPD 2014/06/19 SCM仕掛一覧№10665対応 ---------------------------------->>>>>
                                                //PartsInfoDataSet.UsrJoinPartsRow rowTemp = partsInfoDBTemp.UsrJoinParts.NewUsrJoinPartsRow();
                                                //rowTemp = usrJoinPartsRow;
                                                //partsInfoDBTemp.UsrJoinParts.ImportRow(rowTemp);
                                                string usrJOinFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                                    partsInfoDBTemp.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, usrJoinPartsRow.JoinDestPartsNo,
                                                    partsInfoDBTemp.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, usrJoinPartsRow.JoinDestMakerCd,
                                                    partsInfoDBTemp.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, usrJoinPartsRow.JoinSrcPartsNoWithH,
                                                    partsInfoDBTemp.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, usrJoinPartsRow.JoinSourceMakerCode);
                                                if (partsInfoDBTemp.UsrJoinParts.Select(usrJOinFilter).Length == 0)
                                                {
                                                    PartsInfoDataSet.UsrJoinPartsRow rowTemp = partsInfoDBTemp.UsrJoinParts.NewUsrJoinPartsRow();
                                                    rowTemp = usrJoinPartsRow;
                                                    partsInfoDBTemp.UsrJoinParts.ImportRow(rowTemp);
                                                }
                                                // UPD 2014/06/19 SCM仕掛一覧№10665対応 ----------------------------------<<<<<
                                            }
                                        }
                                        // 代替情報よりユーザー登録の代替先品番より結合元品番を取得し、結合情報を抽出する
                                        string substFilter = string.Format("{0}=False", partsInfoDBTemp.UsrSubstParts.OfferKubunColumn.ColumnName);
                                        PartsInfoDataSet.UsrSubstPartsRow[] usrSubstPartsRows = (PartsInfoDataSet.UsrSubstPartsRow[])partsInfoDBTemp.UsrSubstParts.Select(substFilter);
                                        if (usrSubstPartsRows.Length != 0)
                                        {
                                            foreach (PartsInfoDataSet.UsrSubstPartsRow usrSubstPartsRow in usrSubstPartsRows)
                                            {
                                                string filter2 = string.Format("{0}={1} AND {2}='{3}'",
                                                                partsInfoDBTemp.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, usrSubstPartsRow.ChgDestMakerCd,
                                                                partsInfoDBTemp.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, usrSubstPartsRow.ChgDestGoodsNo);
                                                PartsInfoDataSet.UsrJoinPartsRow[] usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDtTemp.Select(filter2, partsInfoDBTemp.UsrJoinParts.JoinDispOrderColumn.ColumnName);
                                                foreach (PartsInfoDataSet.UsrJoinPartsRow usrJoinPartsRow in usrJoinPartsRows)
                                                {
                                                    // UPD 2014/06/19 SCM仕掛一覧№10665対応 ---------------------------------->>>>>
                                                    //PartsInfoDataSet.UsrJoinPartsRow rowTemp = partsInfoDBTemp.UsrJoinParts.NewUsrJoinPartsRow();
                                                    //rowTemp = usrJoinPartsRow;
                                                    //partsInfoDBTemp.UsrJoinParts.ImportRow(rowTemp);
                                                    string usrJOinFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                                        partsInfoDBTemp.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, usrJoinPartsRow.JoinDestPartsNo,
                                                        partsInfoDBTemp.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, usrJoinPartsRow.JoinDestMakerCd,
                                                        partsInfoDBTemp.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, usrJoinPartsRow.JoinSrcPartsNoWithH,
                                                        partsInfoDBTemp.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, usrJoinPartsRow.JoinSourceMakerCode);
                                                    if (partsInfoDBTemp.UsrJoinParts.Select(usrJOinFilter).Length == 0)
                                                    {
                                                        PartsInfoDataSet.UsrJoinPartsRow rowTemp = partsInfoDBTemp.UsrJoinParts.NewUsrJoinPartsRow();
                                                        rowTemp = usrJoinPartsRow;
                                                        partsInfoDBTemp.UsrJoinParts.ImportRow(rowTemp);
                                                    }
                                                    // UPD 2014/06/19 SCM仕掛一覧№10665対応 ----------------------------------<<<<<
                                                }
                                            }
                                        }
                                    }

                                    // 自動操作による部品選択
                                    ret = TakePartsInfoByAutoOperation(partsInfoDBTemp, CurrentCarInfo);


                                    if (ret.Equals(DialogResult.None)) continue;

                                    // 同じ部品が複数ある場合は処理しない
                                    PartsInfoDataSet.PartsInfoRow trow = (PartsInfoDataSet.PartsInfoRow)dataRow;
                                    if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                                                                {
                                                                    return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                                                                        pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen &&
                                                                        pirow.ClgPrtsNoWithHyphen != trow.ClgPrtsNoWithHyphen);
                                                                }
                                                                ))
                                    {
                                        // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                        // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                        List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                        foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDBTemp.UsrJoinParts.Rows)
                                        {
                                            // 自動回答しない対象の優良部品情報を保管
                                            if (prow.JoinSourceMakerCode == trow.CatalogPartsMakerCd
                                             && prow.JoinSrcPartsNoWithH == trow.ClgPrtsNoWithHyphen)
                                            {
                                                delRows.Add(prow);
                                            }
                                        }
                                        // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                        foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                        {
                                            partsInfoDBTemp.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                        }
                                        continue;
                                    }
                                    // 旧品番・新品番が同一の時は何も処理しない
                                    if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                                                                {
                                                                    return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                                                                        pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen &&
                                                                        pirow.ClgPrtsNoWithHyphen == trow.ClgPrtsNoWithHyphen);
                                                                }
                                                                ))
                                    {
                                        continue;
                                    }
                                    partsInfoRowList.Add(trow);

                                    // DEL 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    #region 旧ソース
                                    //List<AutoAnsItemSt> foundAutoAnsItemStList = null;
                                    //PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDBTemp.ListSelectionInfo[0].RowGoods;   // 選択中の商品


                                    //// 自動回答品目設定マスタ取得
                                    //foundAutoAnsItemStList = autoAnsItemStDB.Search(revisedGoodsUnitDataList, CurrentHeaderRecord.CustomerCode);

                                    //bool existNewGoodsNo = false;
                                    //AutoAnsItemSt selectAutoAnsItemSt = new AutoAnsItemSt();

                                    //foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                                    //{
                                    //    if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                    //        goods.GoodsNo == row.NewGoodsNo)
                                    //    {
                                    //        existNewGoodsNo = true;
                                    //        // 自動回答品目設定マスタを検索
                                    //        selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                    //        break;
                                    //    }
                                    //}
                                    //// 新品番で見つからない場合、旧品番で検索
                                    //if (!existNewGoodsNo)
                                    //{
                                    //    foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                                    //    {
                                    //        if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                    //            goods.GoodsNo == row.GoodsNo)
                                    //        {
                                    //            // 自動回答品目設定マスタを検索
                                    //            selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                    //            break;
                                    //        }
                                    //    }
                                    //}

                                    //// 自動回答品目設定マスタに登録がない場合、次の品目へ
                                    //if (selectAutoAnsItemSt == null)
                                    //{
                                    //    continue;
                                    //}

                                    //// 自動回答品目設定マスタ.自動回答区分の判定
                                    //bool autoAnswer = false;
                                    //if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None))
                                    //{
                                    //    // ダミー品番でなければ自動回答する
                                    //    if (trow.PrimeJoinLnkFlg.Equals(0))
                                    //    {
                                    //        autoAnswer = true;
                                    //    }
                                    //}

                                    //// 自動回答する設定では無い場合、partsInfoDB.UsrJoinPartsを編集し、次の品目へ
                                    //if (!autoAnswer)
                                    //{
                                    //    // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                    //    // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                    //    List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                    //    foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDBTemp.UsrJoinParts.Rows)
                                    //    {
                                    //        // 自動回答しない対象の優良部品情報を保管
                                    //        if (prow.JoinSourceMakerCode == row.GoodsMakerCd
                                    //            && prow.JoinSrcPartsNoWithH == row.GoodsNo)
                                    //        {
                                    //            delRows.Add(prow);
                                    //        }
                                    //    }
                                    //    // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                    //    foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                    //    {
                                    //        partsInfoDBTemp.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                    //    }

                                    //    // 次の品目へ
                                    //    continue;
                                    //}
                                    #endregion
                                    // DEL 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    // ADD 2014/05/27 SCM仕掛一覧№10658対応システムテスト障害№1対応 -------------------------------------------->>>>>
                                    PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDBTemp.ListSelectionInfo[0].RowGoods;   // 選択中の商品

                                    bool existNewGoodsNo = false;
                                    AutoAnsItemSt selectAutoAnsItemSt = new AutoAnsItemSt();

                                    foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                                    {
                                        if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                            goods.GoodsNo == row.NewGoodsNo)
                                        {
                                            existNewGoodsNo = true;
                                            // 自動回答品目設定マスタを検索
                                            selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                            break;
                                        }
                                    }
                                    // 新品番で見つからない場合、旧品番で検索
                                    if (!existNewGoodsNo)
                                    {
                                        foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                                        {
                                            if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                                goods.GoodsNo == row.GoodsNo)
                                            {
                                                // 自動回答品目設定マスタを検索
                                                selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                                break;
                                            }
                                        }
                                    }

                                    // 自動回答品目設定マスタに登録がない場合、次の品目へ
                                    if (selectAutoAnsItemSt == null)
                                    {
                                        continue;
                                    }

                                    // 自動回答品目設定マスタ.自動回答区分の判定
                                    bool autoAnswer = false;
                                    if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None))
                                    {
                                        // ダミー品番でなければ自動回答する
                                        if (trow.PrimeJoinLnkFlg.Equals(0))
                                        {
                                            autoAnswer = true;
                                        }
                                    }

                                    // 自動回答する設定では無い場合、partsInfoDB.UsrJoinPartsを編集し、次の品目へ
                                    if (!autoAnswer)
                                    {
                                        // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                        // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                        List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                        foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDBTemp.UsrJoinParts.Rows)
                                        {
                                            // 自動回答しない対象の優良部品情報を保管
                                            if (prow.JoinSourceMakerCode == row.GoodsMakerCd
                                                && prow.JoinSrcPartsNoWithH == row.GoodsNo)
                                            {
                                                delRows.Add(prow);
                                            }
                                        }
                                        // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                        foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                        {
                                            partsInfoDBTemp.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                        }

                                        // 次の品目へ
                                        continue;
                                    }
                                    // ADD 2014/05/27 SCM仕掛一覧№10658対応システムテスト障害№1対応 --------------------------------------------<<<<<

                                    if (ret == DialogResult.OK)
                                    {
                                        goodsUnitDataListByIndex.AddRange(new List<GoodsUnitData>((GoodsUnitData[])partsInfoDBTemp.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData))));
                                    }
                                }
                            }
                            // UPD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                            //if (!ListUtil.IsNullOrEmpty(goodsUnitDataListByIndex))
                            //{
                            //    goodsUnitDataListTemp = goodsUnitDataListByIndex;
                            //}
                            if (!ListUtil.IsNullOrEmpty(goodsUnitDataListByIndex))
                            {
                                goodsUnitDataListTemp = goodsUnitDataListByIndex;
                                statusList.Add((int)ConstantManagement.DB_Status.ctDB_NORMAL);
                            }
                            else
                            {
                                statusList.Add((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                            }
                            // UPD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                        }
                        // 自動回答対象の抽出を行わない場合
                        else
                        {
                            // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                            ret = TakePartsInfoByAutoOperation(partsInfoDBTemp, CurrentCarInfo);

                            if (ret == DialogResult.OK)
                            {
                                goodsUnitDataListTemp = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDBTemp.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData)));
                                // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
                                statusList.Add((int)ConstantManagement.DB_Status.ctDB_NORMAL);
                                // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                            }
                            else
                            {
                                this.AttachStock(ref goodsUnitDataListTemp, priorWarehouseList);
                                // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
                                statusList.Add((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                                // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                            }
                        }

                        // 在庫リストの編集
                        EditStockList(ref goodsUnitDataListTemp, priorWarehouseList);

                        goodsUnitDataListLump.Add(goodsUnitDataListTemp);
                    }

                    goodsUnitDataList = goodsUnitDataListLump;
                }
            }
            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            else
            {
                for (int i = 0; i < goodsUnitDataList.Count; i++)
                {
                    if (goodsUnitDataList[i].Count == 0)
                    {
                        statusList.Add((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                    }
                }
            }
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<

            EasyLogger.Dump(partsInfoDBList[0], "【自動部品情報取得結果】PartsInfoDataSet");

            if (goodsUnitDataList != null && goodsUnitDataList.Count != 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCode(
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            Debug.WriteLine("\t自動回答処理：GoodsAccesser.SearchPartsFromBLCode()");

            // ----- UPD 2011/08/10 ----->>>>>
            // 2011/01/11 Add >>>
            //List<string> priorWarehouseList = CreatePriorWarehouseList(CurrentHeaderRecord);
            List<string> priorWarehouseList = null;
            // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //{
            //    // 優先倉庫リスト(PCCUOE)を設定
            //    priorWarehouseList = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
            //}
            //else
            //{
            //    // 優先倉庫リストを設定
            //    priorWarehouseList = CreatePriorWarehouseList(CurrentHeaderRecord);
            //}

            // 優先倉庫リスト(PCCUOE)を設定
            priorWarehouseList = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
            // UPD 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
            // ----- UPD 2011/08/10 -----<<<<<
            // 2011/01/11 Add <<<
            // --- UPD m.suzuki 2011/05/23 ---------->>>>> // BLｺｰﾄﾞ枝番を使用するメソッドに変更
            //int status = GoodsAccesser.SearchPartsFromBLCode(
            //    searchingGoodsCondition,
            //    out partsInfoDB,
            //    out goodsUnitDataList,
            //    out msg
            //);

            // ----- UPD 2011/08/10 ----- >>>>>
            //int status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
            //    searchingGoodsCondition,
            //    out partsInfoDB,
            //    out goodsUnitDataList,
            //    out msg
            //);
            int status = (int)ResultUtil.ResultCode.Normal;
            partsInfoDB = null;
            goodsUnitDataList = null;
            msg = string.Empty;

            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            #region 削除(SCM改良の為)
            //// PCCUOEの場合
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //{
            //    // 車両情報がある場合、BLコード検索を行う
            //    if (searchingGoodsCondition.SearchCarInfo.CarModelUIData != null
            //        && searchingGoodsCondition.SearchCarInfo.CarModelUIData.Rows.Count > 0)
            //    {
            //        status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
            //                           searchingGoodsCondition,
            //                           out partsInfoDB,
            //                           out goodsUnitDataList,
            //                           out msg
            //                       );
            //    }
            //    else
            //    {
            //        partsInfoDB = new PartsInfoDataSet();
            //        goodsUnitDataList = new List<GoodsUnitData>();
            //    }
            //}
            //// SCMの場合
            //else
            //{
            #endregion
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            status = GoodsAccesser.SearchPartsFromBLCodeForAutoSearch(
               searchingGoodsCondition,
               out partsInfoDB,
               out goodsUnitDataList,
               out msg
            );
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //}
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            // ----- UPD 2011/08/10 ----- <<<<<
            // --- UPD m.suzuki 2011/05/23 ----------<<<<<

            if (status.Equals((int)ResultUtil.ResultCode.Normal))   // 2011/01/11 Add
            {                                                       // 2011/01/11 Add
                if (partsInfoDB != null)
                {
                    // 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を設定
                    // 2011/01/11 >>>
                    //partsInfoDB.ListPriorWarehouse = CreatePriorWarehouseList(CurrentHeaderRecord);
                    partsInfoDB.ListPriorWarehouse = priorWarehouseList;
                    // 2011/01/11 <<<

                    // --- ADD m.suzuki 2010/06/28 ---------->>>>>
                    SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                        searchingGoodsCondition.EnterpriseCode,
                        searchingGoodsCondition.SectionCode
                    );
                    if (foundSsalesTtlSt != null)
                    {
                        partsInfoDB.SetPartsNameDisplayPattern(foundSsalesTtlSt);
                    }
                    // --- ADD m.suzuki 2010/06/28 ----------<<<<<

                    // HACK:BLコード枝番

                    partsInfoDB.Mode = MODE_OF_SEARCHING_GOODS_NO_IS_AUTO;  // 1:自動回答モード
                }

                // ----- ADD 2011/08/10 ----- >>>>>
                //// 部品選択UIを表示(処理モードを自動回答モードとして起動)
                //// 2010/03/17 >>>
                ////TakePartsInfoByAutoOperation(partsInfoDB, CurrentCarInfo);
                //DialogResult ret = TakePartsInfoByAutoOperation(partsInfoDB, CurrentCarInfo);
                //// 2010/03/17 <<<

                DialogResult ret = DialogResult.None;
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //// PCCUOEの場合
                //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                //{

                // 自動回答対象抽出フラグ
                bool autoAnswerSelcectFlag = false;
                // SCM全体設定マスタ取得
                SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                    CurrentHeaderRecord.InqOtherEpCd,
                    CurrentHeaderRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                if (foundTotalSetting != null)
                {
                    // 問合せで自動回答区分（問合せ）が「する」の時、自動回答対象の抽出を行う
                    if (CurrentHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry &&
                        foundTotalSetting.AutoAnsInquiryDiv != (int)AutoAnsInquiryDiv.None)
                    {
                        autoAnswerSelcectFlag = true;
                    }
                    // 発注で自動回答区分（発注）が「する」の時、自動回答対象の抽出を行う
                    else if (CurrentHeaderRecord.InqOrdDivCd == (int)InqOrdDivCd.Order &&
                        foundTotalSetting.AutoAnsOrderDiv != (int)AutoAnsOrderDiv.None)
                    {
                        autoAnswerSelcectFlag = true;
                    }
                }
                // 自動回答対象の抽出を行う場合
                if (autoAnswerSelcectFlag)
                {
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                    int index = 0;
                    List<GoodsUnitData> goodsUnitDataListByIndex = new List<GoodsUnitData>();
                    if (partsInfoDB != null)
                    {
                        // ADD №222 2012/07/18 2012/09/11配信予定 T.Yoshioka ---------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // 編集後商品リストの作成(商品中分類等、SCM品目設定を抽出するのに必要な情報取得のため)
                        List<GoodsUnitData> revisedGoodsUnitDataList = new List<GoodsUnitData>();
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                        {
                            GoodsUnitData revisedGoodsUnitData = goodsUnitData.Clone();
                            revisedGoodsUnitData.EnterpriseCode = CurrentHeaderRecord.InqOtherEpCd;
                            revisedGoodsUnitData.SectionCode = CurrentHeaderRecord.InqOtherSecCd;

                            GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref revisedGoodsUnitData);
                            if (revisedGoodsUnitData != null)
                            {
                                revisedGoodsUnitData.SectionCode = CurrentHeaderRecord.InqOtherSecCd;
                                revisedGoodsUnitDataList.Add(revisedGoodsUnitData);
                            }
                        }
                        // ADD №222 2012/07/18 2012/09/11配信予定 T.Yoshioka ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                        DataView partsInfoDafaultView = new DataView();
                        partsInfoDB.PartsInfo.DefaultView.Sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                        partsInfoDB.PartsInfo.SeriesModelColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.CategorySignModelColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.ExhaustGasSignColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.FullModelFixedNoColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.PartsQtyColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.PartsOpNmColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                        partsInfoDB.PartsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                        );
                        partsInfoDafaultView = partsInfoDB.PartsInfo.DefaultView;
                        // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<

                        // ADD 2012/09/05 T.Yoshioka 2012/09/12配信システムテスト障害№30---------------->>>>>>>>>>>>>>>
                        List<PartsInfoDataSet.PartsInfoRow> partsInfoRowList = new List<PartsInfoDataSet.PartsInfoRow>();
                        // ADD 2012/09/05 T.Yoshioka 2012/09/12配信システムテスト障害№30----------------<<<<<<<<<<<<<<<
                        // UPD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                        //foreach (DataRow dataRow in partsInfoDB.PartsInfo.DefaultView.Table.Rows)
                        for (int i = 0; i < partsInfoDafaultView.Count; i++)
                        {
                            DataRow dataRow = partsInfoDafaultView[i].Row;
                        // UPD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<

                            // DEL 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                            #region 削除
                            //// ADD 2012/09/05 T.Yoshioka 2012/09/12配信システムテスト障害№30---------------->>>>>>>>>>>>>>>
                            //// 同じ部品が複数ある場合は処理しない
                            //PartsInfoDataSet.PartsInfoRow trow = (PartsInfoDataSet.PartsInfoRow)dataRow;
                            //if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                            //                            {
                            //                                return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                            //                                    pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen);
                            //                            }
                            //                            ))
                            //{
                            //    continue;
                            //}
                            //partsInfoRowList.Add(trow);
                            //// ADD 2012/09/05 T.Yoshioka 2012/09/12配信システムテスト障害№30----------------<<<<<<<<<<<<<<<<<
                            #endregion
                            // DEL 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<

                            partsInfoDB.SelectIndex = index;
                            index = index + 1;

                            // ADD 2012/12/26 2013/03/13配信 SCM障害№10468対応 ------------------------------------->>>>>
                            partsInfoDB.ListSelectionInfo = new Dictionary<int, SelectionInfo>();
                            // ADD 2012/12/26 2013/03/13配信 SCM障害№10468対応 -------------------------------------<<<<<

                            ret = TakePartsInfoByAutoOperation(partsInfoDB, CurrentCarInfo);
                            // ADD 2013/02/19 T.Yoshioka 2013/03/06配信予定 SCM障害№253 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            if (ret.Equals(DialogResult.None)) continue;
                            // ADD 2013/02/19 T.Yoshioka 2013/03/06配信予定 SCM障害№253 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ---------------------------------->>>>>
                            // 同じ部品が複数ある場合は処理しない
                            PartsInfoDataSet.PartsInfoRow trow = (PartsInfoDataSet.PartsInfoRow)dataRow;
                            if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                                                        {
                                                            return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                                                                pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen &&
                                                                pirow.ClgPrtsNoWithHyphen != trow.ClgPrtsNoWithHyphen);
                                                        }
                                                        ))
                            {
                                // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDB.UsrJoinParts.Rows)
                                {
                                    // 自動回答しない対象の優良部品情報を保管
                                    if (prow.JoinSourceMakerCode == trow.CatalogPartsMakerCd
                                     && prow.JoinSrcPartsNoWithH == trow.ClgPrtsNoWithHyphen)
                                    {
                                        delRows.Add(prow);
                                    }
                                }
                                // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                {
                                    partsInfoDB.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                }
                                continue;
                            }
                            // 旧品番・新品番が同一の時は何も処理しない
                            if (partsInfoRowList.Exists(delegate(PartsInfoDataSet.PartsInfoRow pirow)
                                                        {
                                                            return (pirow.CatalogPartsMakerCd == trow.CatalogPartsMakerCd &&
                                                                pirow.NewPrtsNoWithHyphen == trow.NewPrtsNoWithHyphen &&
                                                                pirow.ClgPrtsNoWithHyphen == trow.ClgPrtsNoWithHyphen);
                                                        }
                                                        ))
                            {
                                continue;
                            }
                            partsInfoRowList.Add(trow);
                            // ADD 2012/11/07 2012/11/14配信 システムテスト障害対応 ----------------------------------<<<<<

                            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                            #region 削除(SCM改良の為)
                            //SCMPrtSettingAgent scmPrtSettingDB = new SCMPrtSettingAgent();
                            //PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDB.ListSelectionInfo[0].RowGoods;   // 選択中の商品
                            //IList<SCMPrtSetting> foundSCMPrtSettingList = null;

                            //// ADD 2012/08/22 システムテスト障害№13 2012/09/12配信予定 T.Yoshioka ---------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //bool existNewGoodsNo = false;
                            //foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                            //{
                            //    if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                            //        goods.GoodsNo == row.NewGoodsNo)
                            //    {
                            //        existNewGoodsNo = true;
                            //        // SCM品目設定マスタを検索
                            //        foundSCMPrtSettingList = scmPrtSettingDB.Find(goods, CurrentHeaderRecord.CustomerCode);
                            //        break;
                            //    }
                            //}
                            //// ADD 2012/08/22 システムテスト障害№13 2012/09/12配信予定 T.Yoshioka ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //// UPD 2012/08/22 システムテスト障害№13 2012/09/12配信予定 T.Yoshioka ---------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (!existNewGoodsNo)
                            //{
                            //    foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                            //    {
                            //        if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                            //            goods.GoodsNo == row.GoodsNo)
                            //        {
                            //            // SCM品目設定マスタを検索
                            //            foundSCMPrtSettingList = scmPrtSettingDB.Find(goods, CurrentHeaderRecord.CustomerCode);
                            //            break;
                            //        }
                            //    }
                            //}
                            ////foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                            ////{
                            ////    if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                            ////        goods.GoodsNo == row.GoodsNo)
                            ////    {
                            ////        // SCM品目設定マスタを検索
                            ////        foundSCMPrtSettingList = scmPrtSettingDB.Find(goods, CurrentHeaderRecord.CustomerCode);
                            ////        break;
                            ////    }
                            ////}
                            //// UPD 2012/08/22 システムテスト障害№13 2012/09/12配信予定 T.Yoshioka ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //// SCM品目設定マスタに登録がない場合、次の品目へ
                            //if (ListUtil.IsNullOrEmpty(foundSCMPrtSettingList))
                            //{
                            //    continue;
                            //}

                            //// SCM品目設定マスタ.自動回答区分の判定
                            //bool autoAnswer = false;
                            //foreach (SCMPrtSetting scmPrtSettingRecord in foundSCMPrtSettingList)
                            //{
                            //    if (scmPrtSettingRecord.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.None))
                            //    {
                            //        continue;
                            //    }
                            //    autoAnswer = true;
                            //    break;
                            //}
                            #endregion

                            AutoAnsItemStAgent autoAnsItemStDB = new AutoAnsItemStAgent();
                            List<AutoAnsItemSt> foundAutoAnsItemStList = null;
                            PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDB.ListSelectionInfo[0].RowGoods;   // 選択中の商品

                            // 自動回答品目設定マスタ取得
                            foundAutoAnsItemStList = autoAnsItemStDB.Search(revisedGoodsUnitDataList, CurrentHeaderRecord.CustomerCode);

                            bool existNewGoodsNo = false;
                            AutoAnsItemSt selectAutoAnsItemSt = new AutoAnsItemSt();

                            foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                            {
                                if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                    goods.GoodsNo == row.NewGoodsNo)
                                {
                                    existNewGoodsNo = true;
                                    // 自動回答品目設定マスタを検索
                                    selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                    break;
                                }
                            }
                            // 新品番で見つからない場合、旧品番で検索
                            if (!existNewGoodsNo)
                            {
                                foreach (GoodsUnitData goods in revisedGoodsUnitDataList)
                                {
                                    if (goods.GoodsMakerCd == row.GoodsMakerCd &&
                                        goods.GoodsNo == row.GoodsNo)
                                    {
                                        // 自動回答品目設定マスタを検索
                                        selectAutoAnsItemSt = autoAnsItemStDB.Find(foundAutoAnsItemStList, goods, CurrentHeaderRecord.CustomerCode);
                                        break;
                                    }
                                }
                            }

                            // 自動回答品目設定マスタに登録がない場合、次の品目へ
                            if (selectAutoAnsItemSt == null)
                            {
                                continue;
                            }

                            // 自動回答品目設定マスタ.自動回答区分の判定
                            bool autoAnswer = false;
                            if (!selectAutoAnsItemSt.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None))
                            {
                                // UPD 2013/02/17 2013/04/10配信 SCM障害№10355対応 ------------------------------------->>>>>
                                //autoAnswer = true;
                                // ダミー品番でなければ自動回答する
                                if (trow.PrimeJoinLnkFlg.Equals(0))
                                {
                                    autoAnswer = true;
                                }
                                // UPD 2013/02/17 2013/04/10配信 SCM障害№10355対応 -------------------------------------<<<<<
                            }
                            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

                            // 自動回答する設定では無い場合、partsInfoDB.UsrJoinPartsを編集し、次の品目へ
                            if (!autoAnswer)
                            {
                                // partsInfoDB.UsrJoinPartsから不要なレコードを削除する
                                // （後のSCMRespondent.GetPureInfoで不正なansPureGoodsNoを取得する可能性がある為）
                                List<PartsInfoDataSet.UsrJoinPartsRow> delRows = new List<PartsInfoDataSet.UsrJoinPartsRow>();
                                foreach (PartsInfoDataSet.UsrJoinPartsRow prow in partsInfoDB.UsrJoinParts.Rows)
                                {
                                    // 自動回答しない対象の優良部品情報を保管
                                    if (prow.JoinSourceMakerCode == row.GoodsMakerCd
                                        && prow.JoinSrcPartsNoWithH == row.GoodsNo)
                                    {
                                        delRows.Add(prow);
                                    }
                                }
                                // 自動回答しない対象の優良部品情報をpartsInfoDB.UsrJoinPartsから削除
                                foreach (PartsInfoDataSet.UsrJoinPartsRow delRow in delRows)
                                {
                                    partsInfoDB.UsrJoinParts.RemoveUsrJoinPartsRow(delRow);
                                }

                                // 次の品目へ
                                continue;
                            }
                            // ADD №222 2012/07/18 2012/09/11配信予定 T.Yoshioka ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            if (ret == DialogResult.OK)
                            {
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                                //goodsUnitDataListByIndex.AddRange(new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData))));
                                goodsUnitDataListByIndex.AddRange(new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsListWithSrc(true, 0).ToArray(typeof(GoodsUnitData))));
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                            }
                        }
                    }
                    if (!ListUtil.IsNullOrEmpty(goodsUnitDataListByIndex))
                    {
                        goodsUnitDataList = goodsUnitDataListByIndex;
                    }
                    else
                    {
                        // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№31対応 ------------------------------->>>>>
                        //this.AttachStock(ref goodsUnitDataList, priorWarehouseList);
                        status = (int)ResultUtil.ResultCode.NotFound;
                        // UPD 2012/11/20 2012/12/12配信予定 システムテスト障害№31対応 -------------------------------<<<<<
                    }
                }
                // 自動回答対象の抽出を行わない場合
                else
                {
                    // 部品選択UIを表示(処理モードを自動回答モードとして起動)
                    ret = TakePartsInfoByAutoOperation(partsInfoDB, CurrentCarInfo);

                    if (ret == DialogResult.OK)
                    {
                        // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                        //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData)));
                        goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsListWithSrc(true, 0).ToArray(typeof(GoodsUnitData)));
                        // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                    }
                    else
                    {
                        this.AttachStock(ref goodsUnitDataList, priorWarehouseList);
                    }
                }
                // ----- ADD 2011/08/10 ----- <<<<<
                // ----- DEL 2011/08/10 ----- >>>>>
                //// 2010/03/17 >>>
                //if (ret == DialogResult.OK)
                //{
                //    goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDB.GetGoodsList(true, 0).ToArray(typeof(GoodsUnitData)));
                //}
                //// 2010/03/17 <<<
                // 2011/01/11 Add >>>
                //else
                //{
                //    this.AttachStock(ref goodsUnitDataList, priorWarehouseList);
                //}
                // 2011/01/11 Add <<<
                // ----- DEL 2011/08/10 ----- <<<<<
            }   // 2011/01/11 Add

            EasyLogger.Dump(partsInfoDB, "【自動部品情報取得結果】PartsInfoDataSet");

            // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 在庫リストの編集
            EditStockList(ref goodsUnitDataList, priorWarehouseList);
            // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromBLCode(
            List<GoodsCndtn> searchingGoodsConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            out string msg
        )
        {
            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            List<int> statusList = new List<int>();
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
            return SearchPartsFromBLCodeCarInfo(
                searchingGoodsConditionList,
                out partsInfoDBList,
                out goodsUnitDataList,
                // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
                out statusList,
                // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                out msg,
                null
                );
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>
        /// <summary>
        /// BLコード検索条件を編集する。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="condition">BLコード検索条件</param>
        /// <returns>編集したBLコード検索条件</returns>
        /// <remarks>
        /// <br>Note 　　　 : 2018/04/16 田建委</br>
        /// <br>管理番号    : 11470007-00</br>
        /// <br>            : BLコード検索条件を編集する。</br>
        /// </remarks>
        protected override void AddSearchingGoodsCondition(ISCMOrderDetailRecord detailRecord, ref GoodsCndtn condition)
        {
            // 新BLコード
            condition.BlUtyPtThCd = detailRecord.InqBlUtyPtThCd;
            // 新BLサブコード
            condition.BlUtyPtSbCd = detailRecord.InqBlUtyPtSbCd;

        }
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<

        #endregion // </BL検索>

        // ----- 2011/08/10 ----- >>>>>
        #region <用品処理>

        /// <summary>
        /// 用品入力を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">検索条件</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected override int SearchPartsFromGoodsName(
            SCMOrderDetailRecordType scmOrderDetailRecord,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            partsInfoDB = new PartsInfoDataSet();
            goodsUnitDataList = new List<GoodsUnitData>();
            msg = string.Empty;

            // 優先倉庫リスト(PCCUOE)を設定
            EasyLogger.Write(MY_NAME, "SearchPartsFromGoodsName", "優先倉庫リスト(PCCUOE)を設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            List<string> priorWarehouseList = CreatePriorWarehouseListForPccuoe(CurrentHeaderRecord);
            EasyLogger.Write(MY_NAME, "SearchPartsFromGoodsName", "優先倉庫リスト(PCCUOE)を設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            partsInfoDB.ListPriorWarehouse = priorWarehouseList;

            // goodsUnitDataを構成する
            goodsUnitDataList.Add(AnsweredSCMSearchedResult.CreateAnsweredGoodsUnitDataForPccuoe(scmOrderDetailRecord, searchedType));

            SalesTtlSt foundSsalesTtlSt = SalesTtlStDB.Find(
                scmOrderDetailRecord.EnterpriseCode,
                scmOrderDetailRecord.InqOtherSecCd
            );
            if (foundSsalesTtlSt != null)
            {
                partsInfoDB.SetPartsNameDisplayPattern(foundSsalesTtlSt);
            }

            partsInfoDB.Mode = MODE_OF_SEARCHING_GOODS_NO_IS_AUTO;  // 1:自動回答モード
            partsInfoDB.AcceptOrOrderKind = (int)EnumAcceptOrOrderKind.PCCUOE; // 受発注種別

            return (int)ResultUtil.ResultCode.Normal;
        }

        #endregion // </用品処理>
        // ----- 2011/08/10 ----- <<<<<



        // 2011/01/11 Add >>>
        /// <summary>
        /// 商品連結情報リストの取得
        /// </summary>
        /// <param name="searchStatus">検索ステータス</param>
        /// <param name="scmOrderDetailRecord"></param>
        /// <param name="goodsUnitDataList"></param>
        protected override void GetGoodsUnitDataList(int searchStatus, SCMOrderDetailRecordType scmOrderDetailRecord, ref List<GoodsUnitData> goodsUnitDataList)
        {
            if (goodsUnitDataList == null)
                goodsUnitDataList = new List<GoodsUnitData>();
        }
        // 2011/01/11 Add <<<



        #endregion // </Override>

        /// <summary>
        /// 自動操作で部品情報を取得します。
        /// </summary>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="carInfo">車両情報</param>
        // 2010/03/17 >>>
        //private void TakePartsInfoByAutoOperation(
        //    PartsInfoDataSet partsInfoDB,
        //    PMKEN01010E carInfo
        //)
        private DialogResult TakePartsInfoByAutoOperation(
            PartsInfoDataSet partsInfoDB,
            PMKEN01010E carInfo
            )
        // 2010/03/17 <<<
        {
            EasyLogger.Dump(carInfo, "【自動部品情報取得窓】PMKEN01010E");
            EasyLogger.Dump(partsInfoDB, "【自動部品情報取得窓】PartsInfoDataSet");

            // 2010/03/17 >>>
            //DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(null, carInfo, partsInfoDB);
            return UIDisplayControl.ProcessPartsSearch(null, carInfo, partsInfoDB);
            // 2010/03/17 <<<
        }

        // 2011/01/11 Add >>>
        /// <summary>
        /// 商品連結データの選択倉庫に、優先倉庫を引当ます
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="priorWarehouseList"></param>
        private void AttachStock(ref List<GoodsUnitData> goodsUnitDataList, List<string> priorWarehouseList)
        {
            if (goodsUnitDataList != null)
            {
                foreach (GoodsUnitData data in goodsUnitDataList)
                {
                    if (!string.IsNullOrEmpty(data.SelectedWarehouseCode)) continue;
                    if (data.StockList == null) continue;

                    foreach (string warehouseCode in priorWarehouseList)
                    {
                        if (string.IsNullOrEmpty(warehouseCode)) continue;
                        Stock findStock = data.StockList.Find(
                            delegate(Stock stockInfo)
                            {
                                return ( stockInfo.WarehouseCode.Trim().Equals(warehouseCode.Trim()) );
                            }
                            );
                        if (findStock != null)
                        {
                            data.SelectedWarehouseCode = findStock.WarehouseCode;
                            break;
                        }
                    }
                }
            }
        }
        // 2011/01/11 Add <<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>
        /// 倉庫の主管倉庫を判定します。
        /// </summary>
        /// <param name="paramEnterpriseCode">企業コード</param>
        /// <param name="paramWarehouseCd">判定要の倉庫コード</param>
        /// <param name="paramMainMngWarehouseCd">判定用主管倉庫コード</param>
        /// <returns>true:主管倉庫 false:非主管倉庫</returns>
        private bool IsMainMngWarehouse(string paramEnterpriseCode, string paramWarehouseCd, string paramMainMngWarehouseCd)
        {
            if (string.IsNullOrEmpty(paramEnterpriseCode) || string.IsNullOrEmpty(paramWarehouseCd) || string.IsNullOrEmpty(paramMainMngWarehouseCd))
                return false;

            // 判定要の倉庫情報を取得
            GoodsUnitData tempGoodsUnitData = new GoodsUnitData();
            tempGoodsUnitData.EnterpriseCode = paramEnterpriseCode;
            tempGoodsUnitData.SelectedWarehouseCode = paramWarehouseCd.Trim();
            Warehouse foundWarehouse = WarehouseDB.Find(tempGoodsUnitData);

            if (null == foundWarehouse || string.IsNullOrEmpty(foundWarehouse.MainMngWarehouseCd) || string.IsNullOrEmpty(foundWarehouse.MainMngWarehouseCd.Trim()))
                // 倉庫または主管倉庫情報がない場合
                return false;

            return paramMainMngWarehouseCd.Trim().Equals(foundWarehouse.MainMngWarehouseCd.Trim());
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void EditStockList(ref List<GoodsUnitData> goodsUnitDataList, List<string> priorWarehouseList)
        {
            // 商品情報分ループ
            foreach (GoodsUnitData goods in goodsUnitDataList)
            {
                // 在庫リスト分ループ
                List<Stock> wrkStockList = new List<Stock>();
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                List<Stock> wrkTempStockList = new List<Stock>();
                string trustWarehouseCode = string.Empty;
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                foreach (Stock stock in goods.StockList)
                {
                    // 在庫リストの倉庫コードが、優先倉庫リストに含まれていたら
                    if (priorWarehouseList.Contains(stock.WarehouseCode))
                    {
                        wrkStockList.Add(stock);
                        if (priorWarehouseList.Count > 0 && stock.WarehouseCode.Equals(priorWarehouseList[0])) trustWarehouseCode = priorWarehouseList[0]; // ADD 2013/02/27 qijh #34752
                    }
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    else
                    {
                        wrkTempStockList.Add(stock);
                    }
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                }

                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                // 委託倉庫の主管倉庫の在庫を追加
                if (!string.IsNullOrEmpty(trustWarehouseCode))
                    foreach (Stock stock in wrkTempStockList)
                        if (IsMainMngWarehouse(stock.EnterpriseCode, trustWarehouseCode, stock.WarehouseCode))
                        {
                            wrkStockList.Add(stock);
                            break;
                }
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

                SCMSearcher.WarehouseInfo warehouseInfo = new WarehouseInfo();
                warehouseInfo.Initialize();
                // 対象商品番号を設定
                warehouseInfo.GoodsNo = goods.GoodsNo;
                // ADD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 対象商品メーカーコードを設定
                warehouseInfo.MakerCd = goods.GoodsMakerCd;
                // ADD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                #region 削除(SCM改良のため)
                //// PCC for NSの場合
                //// 上記で作成されたpriorWarehouseListには、得意先倉庫が含まれている場合があるので、
                //// 得意先倉庫か委託倉庫かの判定を実施し、
                //// 得意先倉庫であれば、wrkStockListから削除する
                //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
                //{
                //    WarehouseAgent wha = new WarehouseAgent();
                //    List<Warehouse> Warehousewhl = null;
                //    List<string> whlTrust = new List<string>();
                //    List<Stock> removeStock = new List<Stock>();
                //    List<Stock> priorityStock = new List<Stock>();

                //    // 得意先マスタに設定されている、優先倉庫の取得
                //    string custWarehouseCd = GetCustWarehouseCd(CurrentHeaderRecord);

                //    foreach (Stock stock in wrkStockList)
                //    {
                //        // 得意先マスタに設定されている、優先倉庫と一致した場合、得意先倉庫か委託倉庫かの判定を実施
                //        if (stock.WarehouseCode.Trim() == custWarehouseCd.Trim())
                //        {
                //            // 倉庫マスタを全件取得
                //            Warehousewhl = wha.GetWarehouseList(goods.EnterpriseCode);
                //            if (Warehousewhl != null)
                //            {
                //                foreach (Warehouse wh in Warehousewhl)
                //                {
                //                    // 倉庫マスタに設定されている得意先が問合せ元と一致する場合
                //                    if (wh.CustomerCode == CurrentHeaderRecord.CustomerCode)
                //                    {
                //                        // 得意先が設定されている倉庫コードをリストに保管
                //                        whlTrust.Add(wh.WarehouseCode.Trim());
                //                    }
                //                }
                //            }

                //            // 委託倉庫：得意先マスタにの優先倉庫に設定されている倉庫に、得意先が設定されている場合
                //            if (whlTrust.Contains(stock.WarehouseCode.Trim()))
                //            {
                //                // 委託倉庫の設定
                //                warehouseInfo.Trust = stock;
                //            }
                //            // 得意先倉庫：得意先マスタにの優先倉庫に設定されている倉庫に、得意先が設定されていない場合
                //            else
                //            {
                //                // 削除対象となる得意先倉庫を保存
                //                removeStock.Add(stock);
                //            }
                //        }
                //        else
                //        {
                //            // 一旦ワークに優先倉庫を設定（拠点設定に登録されている優先順位を考慮していない）
                //            priorityStock.Add(stock);
                //        }
                //    }

                //    // 在庫リストから得意先倉庫を削除
                //    foreach (Stock stock in removeStock)
                //    {
                //        wrkStockList.Remove(stock);
                //    }

                //    // 優先倉庫設定（拠点設定に登録されている優先順位考慮）
                //    if (priorityStock.Count > 0)
                //    {
                //        foreach (string cd in priorWarehouseList)
                //        {
                //            foreach (Stock st in wrkStockList)
                //            {
                //                if (cd.Trim() == st.WarehouseCode.Trim())
                //                {
                //                    warehouseInfo.Priority.Add(st);
                //                    break;
                //                }
                //            }
                //        }
                //    }

                //    // 選択倉庫設定
                //    if (warehouseInfo.IsExistTrust())
                //    {
                //        warehouseInfo.Selected = warehouseInfo.Trust.WarehouseCode;
                //    }
                //    else if (warehouseInfo.IsExistPriority())
                //    {
                //        warehouseInfo.Selected = warehouseInfo.Priority[0].WarehouseCode;
                //    }
                //    else
                //    {
                //        warehouseInfo.Selected = string.Empty;
                //    }
                //}
                //else
                //{
                #endregion
                // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<
                    // BLパーツオーダーシステムの場合
                    // 選択倉庫設定
                    // UPD 2012/07/04 T.Yoshioka №10281 ---------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>
                    warehouseInfo.Selected = string.Empty;
                    if (wrkStockList.Count > 0)
                    {
                        foreach (string cd in priorWarehouseList)
                        {
                            foreach (Stock st in wrkStockList)
                            {
                                if (cd.Trim() == st.WarehouseCode.Trim())
                                {
                                    warehouseInfo.Selected = cd;
                                    break;
                                }
                            }
                            // 選択倉庫が設定されていればブレーク
                            if (warehouseInfo.Selected != string.Empty)
                            {
                                break;
                            }
                        }
                    }
                    //if (wrkStockList.Count > 0)
                    //{
                    //    foreach (string cd in priorWarehouseList)
                    //    {
                    //        foreach (Stock st in wrkStockList)
                    //        {
                    //            if (cd.Trim() == st.WarehouseCode.Trim())
                    //            {
                    //                warehouseInfo.Selected = cd;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    // 在庫が存在しない場合
                    //    warehouseInfo.Selected = string.Empty;
                    //}
                    // UPD 2012/07/04 T.Yoshioka №10281 ----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
                //}
                // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ----------------------------------<<<<<

                // 在庫リストを設定
                warehouseInfo.StockList = wrkStockList;
                // 委託倉庫、優先倉庫等の情報を保管
                SCMSearcher.warehouseInfoList.Add(warehouseInfo);

                goods.StockList = null;         // 念のためクリア
                goods.StockList = wrkStockList; // 委託、優先（自拠点）のみの倉庫リスト
            }
        }
        // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） --------->>>>>
        /// <summary>
        /// 商品情報検索条件文字列生成
        /// </summary>
        /// <param name="searchingCondition">商品情報検索条件</param>
        /// <returns>商品情報検索条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 商品情報検索条件文字列生成処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/05/15</br>
        /// </remarks>
        public string GetGoodsSearchCondition(GoodsCndtn searchingCondition)
        {
            string carString = string.Empty;
            try
            {
                carString = LinkBreak + "BLGoodsCode:" + searchingCondition.BLGoodsCode.ToString() + LinkBreak
                + "BLGoodsDrCode:" + searchingCondition.BLGoodsDrCode.ToString() + LinkBreak
                + "BLGoodsName:" + searchingCondition.BLGoodsName.ToString() + LinkBreak
                + "BLGroupCode:" + searchingCondition.BLGroupCode.ToString() + LinkBreak
                + "BLGroupName:" + searchingCondition.BLGroupName.ToString() + LinkBreak
                + "EnterpriseCode:" + searchingCondition.EnterpriseCode.ToString() + LinkBreak
                + "GoodsMakerCd:" + searchingCondition.GoodsMakerCd.ToString() + LinkBreak
                + "GoodsNo:" + searchingCondition.GoodsNo.ToString() + LinkBreak
                + "WarehouseCode:" + searchingCondition.WarehouseCode.ToString();
            }
            catch(Exception ex)
            {
                carString = LinkBreak + "＃＃＃例外＃＃＃" + LinkBreak + ex.ToString();
            }
            return carString;
        }
        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） ---------<<<<<
    }
}
