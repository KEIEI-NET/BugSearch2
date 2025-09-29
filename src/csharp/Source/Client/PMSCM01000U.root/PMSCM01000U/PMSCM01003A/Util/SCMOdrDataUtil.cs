//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 見積・受注データ受信
// プログラム概要   : 見積・受注データの受信処理の操作を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/18  修正内容 : ①Webからデータ取得時に、対象問合せ番号のデータを全件取得する
//                                 ②PM7,自動回答に対して、明細が最新の分のみ対象データとして渡す 
//----------------------------------------------------------------------------//
// 管理番号  11070184-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/10/07  修正内容 : SCM仕掛 №10662　RedMine#43047 2014/10/16配信システムテスト障害№10対応
//                                  伝票番号選択画面で「新規問合せ」で登録後、SF側で取消を行うと、
//                                  PM側に新着通知のポップアップが表示される障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.Common; // 2010/03/30 Add

#if DEBUG
// ダミー参照
//using ScmOdrData = Broadleaf.Application.UIData.StubDB.ScmOdrData;
//using ScmOdDtInq = Broadleaf.Application.UIData.StubDB.ScmOdDtInq;
//using ScmOdDtAns = Broadleaf.Application.UIData.StubDB.ScmOdDtAns;
//using ScmOdDtCar = Broadleaf.Application.UIData.StubDB.ScmOdDtCar;

//using SCMAcOdrData = Broadleaf.Application.UIData.StubDB.SCMAcOdrData;
//using SCMAcOdrDtlIq = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlIq;
//using SCMAcOdrDtlAs = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlAs;
//using SCMAcOdrDtCar = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtCar;

using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
using ScmOdDtInq = Broadleaf.Application.UIData.ScmOdDtInq;
using ScmOdDtAns = Broadleaf.Application.UIData.ScmOdDtAns;
using ScmOdDtCar = Broadleaf.Application.UIData.ScmOdDtCar;

using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;

#else
    using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
    using ScmOdDtInq = Broadleaf.Application.UIData.ScmOdDtInq;
    using ScmOdDtAns = Broadleaf.Application.UIData.ScmOdDtAns;
    using ScmOdDtCar = Broadleaf.Application.UIData.ScmOdDtCar;

    using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
#endif

namespace Broadleaf.Application.Controller.Util
{
    // ADD 2010/06/29 PM7連携時はSCM系データをDBに書かない ---------->>>>>
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ
    // ADD 2010/06/29 PM7連携時はSCM系データをDBに書かない ----------<<<<<

    /// <summary>
    /// SCM受注データ、SCM受注明細データ、SCM受注データ(車両情報)操作クラス
    /// </summary>
    public class SCMOdrDataUtil
    {
        #region ヘッダに紐づく明細、車両情報の取得
        /// <summary>
        /// SCM受発注データと同キーの明細リスト、車両情報を取得する。(Web型)
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <param name="scmOdDtInqList"></param>
        /// <param name="scmOdDtCarList"></param>
        /// <param name="relatedSCMOdDtInqList"></param>
        /// <param name="relatedSCMOdDtCar"></param>
        public static void GetRelatedSCMOdrData(
            ScmOdrData scmOdrData, List<ScmOdDtInq> scmOdDtInqList, List<ScmOdDtCar> scmOdDtCarList,
            out List<ScmOdDtInq> relatedSCMOdDtInqList, out ScmOdDtCar relatedSCMOdDtCar)
        {
            relatedSCMOdDtInqList = new List<ScmOdDtInq>();
            relatedSCMOdDtCar = new ScmOdDtCar();

            // キー項目の取得
            string inqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            string inqOriginalSecCd = scmOdrData.InqOriginalSecCd; // 問合せ元拠点コード
            string inqOtherEpCd = scmOdrData.InqOtherEpCd; // 問合せ先企業コード
            string inqOtherSecCd = scmOdrData.InqOtherSecCd; // 問合せ先拠点コード

            Int64 inquiryNumber = scmOdrData.InquiryNumber; // 問合せ番号
            Int32 inqOrdDivCd = scmOdrData.InqOrdDivCd;

            // 明細(問合せ・受注)データ取得
            relatedSCMOdDtInqList = scmOdDtInqList.FindAll(
                delegate(ScmOdDtInq scmOdDtInq)
                {
                    if (scmOdDtInq.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtInq.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtInq.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmOdDtInq.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmOdDtInq.InquiryNumber == inquiryNumber
                        && scmOdDtInq.InqOrdDivCd == inqOrdDivCd
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

             // 車両情報取得
            relatedSCMOdDtCar = scmOdDtCarList.Find(
                delegate(ScmOdDtCar scmOdDtCar)
                {
                    if (scmOdDtCar.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim() //@@@@20230303
                        && scmOdDtCar.InqOriginalSecCd == inqOriginalSecCd
                        && scmOdDtCar.InquiryNumber == inquiryNumber)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }

        /// <summary>
        /// SCM受注データと同キーの明細リスト、車両情報を取得する。(ユーザ型)
        /// </summary>
        /// <param name="mode">0:受信日時チェック無し、1:受信日時チェック有り</param>
        public static void GetRelatedSCMOdrAcData(
            // 2011/02/18 Add >>>
            int mode,
            // 2011/02/18 Add <<<
            ISCMOrderHeaderRecord scmAcOdrData, List<ISCMOrderDetailRecord> scmAcOdrDtlIqList,List<ISCMOrderCarRecord> scmAcOdrDtCarList,
            out List<ISCMOrderDetailRecord> relatedSCMAcOdrDtlIqList, out ISCMOrderCarRecord relatedSCMAcOdrDtCar)
        {
            relatedSCMAcOdrDtlIqList = new List<ISCMOrderDetailRecord>();

            // キー項目の取得
            string inqOriginalEpCd = scmAcOdrData.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            string inqOriginalSecCd = scmAcOdrData.InqOriginalSecCd; // 問合せ元拠点コード
            string inqOtherEpCd = scmAcOdrData.InqOtherEpCd; // 問合せ先企業コード
            string inqOtherSecCd = scmAcOdrData.InqOtherSecCd; // 問合せ先拠点コード

            Int64 inquiryNumber = scmAcOdrData.InquiryNumber; // 問合せ番号

            Int32 acptAnOdrStatus = scmAcOdrData.AcptAnOdrStatus; // 受注ステータス
            string salesSlipNum = scmAcOdrData.SalesSlipNum; // 売上伝票番号

            Int32 inqOrdDivCd = scmAcOdrData.InqOrdDivCd;   // 問合せ・発注種別
            // 2011/02/18 Add >>>
            DateTime updateDate = scmAcOdrData.UpdateDate;
            int updateTime = scmAcOdrData.UpdateTime;
            // 2011/02/18 Add <<<

            // 明細(問合せ・受注)データ取得
            relatedSCMAcOdrDtlIqList = scmAcOdrDtlIqList.FindAll(
                delegate(ISCMOrderDetailRecord userSCMOrderDetailRecord)
                {
                    if (userSCMOrderDetailRecord.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && userSCMOrderDetailRecord.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && userSCMOrderDetailRecord.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && userSCMOrderDetailRecord.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && userSCMOrderDetailRecord.InquiryNumber == inquiryNumber
                        && userSCMOrderDetailRecord.InqOrdDivCd == inqOrdDivCd
                        // 2011/02/18 Add >>>
                        && ( mode == 0 || ( ( mode == 1 ) && ( userSCMOrderDetailRecord.UpdateDate == updateDate && userSCMOrderDetailRecord.UpdateTime == updateTime ) ) )
                        // 2011/02/18 Add <<<
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 車両情報取得
            relatedSCMAcOdrDtCar = scmAcOdrDtCarList.Find(
                delegate(ISCMOrderCarRecord userSCMOrderCarRecord)
                {
                    if (userSCMOrderCarRecord.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && userSCMOrderCarRecord.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && userSCMOrderCarRecord.InquiryNumber == inquiryNumber
                        && userSCMOrderCarRecord.AcptAnOdrStatus == acptAnOdrStatus
                        && userSCMOrderCarRecord.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }
        #endregion

        /// <summary>
        /// 旧システム連携有無によりリストを分ける
        /// </summary>
        public static void FilterByLegacySection(
            // 2010/12/27 >>>
            //Dictionary<string, string> legacySectionList,
            //// 2010/03/30 Add >>>
            //List<SimplInqCnectInfo> simplInqCnectInfoList,
            //// 2010/03/30 Add <<<
            Dictionary<string, int> scmTargetList,
            // 2010/12/27 <<<
            // 2011/02/18 Add >>>
            List<string> newDataKeyList,
            // 2011/02/18 Add <<<
            List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList, List<ISCMOrderDetailRecord> userSCMOrderDetailRecordList, List<ISCMOrderCarRecord> userSCMOrderCarRecordList,
            out List<ISCMOrderHeaderRecord> notLegacySCMAcOdrDataList, out List<ISCMOrderDetailRecord> notLegacySCMAcOdrDtlIqList, out List<ISCMOrderCarRecord> notLegacySCMAcOdrDtCarList,
            out List<ISCMOrderHeaderRecord> legacySCMAcOdrDataList, out List<ISCMOrderDetailRecord> legacySCMAcOdrDtlIqList, out List<ISCMOrderCarRecord> legacySCMAcOdrDtCarList)
        {
            notLegacySCMAcOdrDataList = new List<ISCMOrderHeaderRecord>();
            notLegacySCMAcOdrDtlIqList = new List<ISCMOrderDetailRecord>();
            notLegacySCMAcOdrDtCarList = new List<ISCMOrderCarRecord>();

            legacySCMAcOdrDataList = new List<ISCMOrderHeaderRecord>();
            legacySCMAcOdrDtlIqList = new List<ISCMOrderDetailRecord>();
            legacySCMAcOdrDtCarList = new List<ISCMOrderCarRecord>();

            foreach (UserSCMOrderHeaderWrapper userSCMOrderHeaderWrapper in userSCMOrderHeaderRecordList)
            {
                // 受注データと同キーの各項目を取得
                List<ISCMOrderDetailRecord> tmpUserSCMOrderDetailRecordList = new List<ISCMOrderDetailRecord>();
                ISCMOrderCarRecord tmpUserSCMOrderCarRecord;

                // 2011/02/18 >>>
                //GetRelatedSCMOdrAcData(userSCMOrderHeaderWrapper, userSCMOrderDetailRecordList, userSCMOrderCarRecordList,
                //    out tmpUserSCMOrderDetailRecordList, out tmpUserSCMOrderCarRecord);
                // 2011/02/18 <<<

                // 2010/12/27 >>>
                //if (!legacySectionList.ContainsKey(userSCMOrderHeaderWrapper.InqOtherSecCd.Trim().PadLeft(2, '0')))
                if (IsNsTargetData(scmTargetList, userSCMOrderHeaderWrapper.InqOtherSecCd.Trim()))
                // 2010/12/27 <<<
                {
                    // 2010/12/27 Del >>>
                    //// 2010/03/30 Add >>>
                    //// CMT接続リストから得意先の検索(1件でも一致レコードがあれば自動回答対象外)
                    //SimplInqCnectInfo info = simplInqCnectInfoList.Find(
                    //    delegate(SimplInqCnectInfo rec)
                    //    {
                    //        if (rec.CustomerCode == userSCMOrderHeaderWrapper.CustomerCode) return true;
                    //        return false;
                    //    });

                    //// 接続情報があった場合は処理しない
                    //if (info != null) continue;
                    //// 2010/03/30 Add <<<
                    // 2010/12/27 Del <<<

                    // 旧システム連携なし
                    // 2011/02/18 Add >>>
                    GetRelatedSCMOdrAcData(
                        1,
                        userSCMOrderHeaderWrapper,
                        userSCMOrderDetailRecordList,
                        userSCMOrderCarRecordList,
                        out tmpUserSCMOrderDetailRecordList,
                        out tmpUserSCMOrderCarRecord
                    );
                    // 2011/02/18 Add <<<
                    notLegacySCMAcOdrDataList.Add(userSCMOrderHeaderWrapper);

                    foreach (UserSCMOrderDetailRecord tmpUserSCMOrderDetailRecord in tmpUserSCMOrderDetailRecordList)
                    {
                        notLegacySCMAcOdrDtlIqList.Add(tmpUserSCMOrderDetailRecord);
                    }

                    notLegacySCMAcOdrDtCarList.Add(tmpUserSCMOrderCarRecord);
                }
                else
                {
                    // 旧システム連携あり
                    // 2011/02/18 Add >>>
                    // 最新データでない場合はリストに追加しない
                    if (!newDataKeyList.Contains(SCMOdrDataToKey(userSCMOrderHeaderWrapper))) continue;
                    GetRelatedSCMOdrAcData(
                        0,
                        userSCMOrderHeaderWrapper,
                        userSCMOrderDetailRecordList,
                        userSCMOrderCarRecordList,
                        out tmpUserSCMOrderDetailRecordList,
                        out tmpUserSCMOrderCarRecord
                    );
                    // 2011/02/18 Add <<<

                    legacySCMAcOdrDataList.Add(userSCMOrderHeaderWrapper);

                    foreach (UserSCMOrderDetailRecord tmpUserSCMOrderDetailRecord in tmpUserSCMOrderDetailRecordList)
                    {
                        legacySCMAcOdrDtlIqList.Add(tmpUserSCMOrderDetailRecord);
                    }

                    legacySCMAcOdrDtCarList.Add(tmpUserSCMOrderCarRecord);
                }
            }
        }

        // 2010/12/27 Add >>>
        /// <summary>
        /// NS対象データか判断
        /// </summary>
        /// <param name="scmSettingList">SCM設定リスト(key:拠点,value:SCM全体設定.旧システム連携区分)</param>
        /// <param name="sectionCode">対象拠点</param>
        /// <returns>True:NS対象拠点</returns>
        private static bool IsNsTargetData(Dictionary<string, int> scmSettingList, string sectionCode)
        {
            bool ret = false;

            // 拠点単位の設定がある場合
            if (scmSettingList.ContainsKey(sectionCode.Trim()))
            {
                ret = ( scmSettingList[sectionCode.Trim()] == 0 );

            }
            // 全社設定がある場合
            else if (scmSettingList.ContainsKey("00"))
            {
                ret = ( scmSettingList["00"] == 0 );
            }
            return ret;
        }
        // 2010/12/27 Add <<<

        // ADD 2010/06/16 キャンセルデータ用の補正処理を追加 ---------->>>>>
        /// <summary>
        /// SCM受注明細データ(問合せ・発注)より「回答区分」を取得します。
        /// </summary>
        /// <param name="scmOrderDetailRecordList">SCM受注明細データ(問合せ・発注)</param>
        /// <param name="defaultAnswerDivCd">キャンセルデータではない場合の回答区分の値</param>
        /// <returns>
        /// SCM受注明細データ(問合せ・発注)が以下の場合、「99:キャンセル」を返します。
        /// 1.「キャンセル状態区分」が 10:キャンセル要求
        /// 2.「受注ステータス」 が 30:売上
        /// 3.「売上伝票番号」が 0 以外
        /// </returns>
        public static int GetAnswerDivCdIfCanceling(
            List<ISCMOrderDetailRecord> scmOrderDetailRecordList,
            int defaultAnswerDivCd
        )
        {
            #region Guard Phrase

            if (scmOrderDetailRecordList == null || scmOrderDetailRecordList.Count.Equals(0)) return defaultAnswerDivCd;

            #endregion // Guard Phrase

            // 「キャンセル状態区分」で判定
            List<ISCMOrderDetailRecord> foundDetailList = scmOrderDetailRecordList.FindAll(
                delegate(ISCMOrderDetailRecord item)
                {
                    // 0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定
                    return item.CancelCndtinDiv.Equals(10);
                }
            );
            if (foundDetailList == null || foundDetailList.Count.Equals(0)) return defaultAnswerDivCd;

            // 「受注ステータス」で判定
            foundDetailList = foundDetailList.FindAll(delegate(ISCMOrderDetailRecord item)
            {
                // 10:見積 20:受注 30:売上
                return item.AcptAnOdrStatus.Equals(30);
            });
            if (foundDetailList == null || foundDetailList.Count.Equals(0)) return defaultAnswerDivCd;

            // 「売上伝票番号」で判定
            foundDetailList = foundDetailList.FindAll(delegate(ISCMOrderDetailRecord item)
            {
                long salesSlipNum = -1;
                if (!long.TryParse(item.SalesSlipNum.Trim(), out salesSlipNum))
                {
                    return false;
                }
                return salesSlipNum > 0;
            });
            // 0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル
            return (foundDetailList == null || foundDetailList.Count.Equals(0)) ? defaultAnswerDivCd : 99;
        }
        // ADD 2010/06/16 キャンセルデータ用の補正処理を追加 ----------<<<<<
        // ADD 2010/06/29 PM7連携時はSCM系データをDBに書かない ---------->>>>>
        /// <summary>
        /// 旧システム連携データであるか判断します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データ</param>
        /// <returns>
        /// 該当するSCM全体設定の旧システム連携区分が「1:する(PM7SP)」の場合、<c>true</c>を返します。
        /// </returns>
        public static bool IsLegacyHeaderRecord(ISCMOrderHeaderRecord headerRecord)
        {
            if (headerRecord == null) return false;

            SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                headerRecord.InqOtherEpCd,
                headerRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
            if (foundTotalSetting != null)
            {
                return foundTotalSetting.OldSysCooperatDiv.Equals(1);  // 「0:しない(PM.NS)」「1:する(PM7SP)」
            }

            return false;
        }
        // ADD 2010/06/29 PM7連携時はSCM系データをDBに書かない ----------<<<<<


        // 2011/02/18 Add >>>
        /// <summary>
        /// SCM受注データのキーに変換します
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToKey(ScmOdrData scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                scmOdrData.InqOriginalEpCd.Trim(),
                scmOdrData.InqOriginalSecCd.Trim(),
                scmOdrData.InqOtherEpCd.Trim(),
                scmOdrData.InqOtherSecCd.Trim(),
                scmOdrData.InquiryNumber,
                scmOdrData.UpdateTime,
                scmOdrData.UpdateTime);
        }

        /// <summary>
        /// SCM受注データのキーに変換します
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToKey(UserSCMOrderHeaderWrapper scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                scmOdrData.InqOriginalEpCd.Trim(),
                scmOdrData.InqOriginalSecCd.Trim(),
                scmOdrData.InqOtherEpCd.Trim(),
                scmOdrData.InqOtherSecCd.Trim(),
                scmOdrData.InquiryNumber,
                scmOdrData.UpdateTime,
                scmOdrData.UpdateTime);
        }

        /// <summary>
        /// SCM受注データをユニークキーに変換します
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToUniqueKey(UserSCMOrderHeaderWrapper scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
              scmOdrData.InqOriginalEpCd.Trim(),
              scmOdrData.InqOriginalSecCd.Trim(),
              scmOdrData.InqOtherEpCd.Trim(),
              scmOdrData.InqOtherSecCd.Trim(),
              scmOdrData.InquiryNumber,
              scmOdrData.InqOrdDivCd,
              scmOdrData.CancelDiv);
        }
        /// <summary>
        /// SCM受注データをユニークキーに変換します
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToUniqueKey(ISCMOrderHeaderRecord scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
              scmOdrData.InqOriginalEpCd.Trim(),
              scmOdrData.InqOriginalSecCd.Trim(),
              scmOdrData.InqOtherEpCd.Trim(),
              scmOdrData.InqOtherSecCd.Trim(),
              scmOdrData.InquiryNumber,
              scmOdrData.InqOrdDivCd,
              scmOdrData.CancelDiv);
        }

        // --- ADD 2014/10/07 鄧潘ハン 仕掛№10662 システムテスト障害№10---------->>>>>
        /// <summary>
        /// SCM受注明細データ(回答)比較クラス(売上番号(降順))
        /// </summary>
        ///<remarks>
        /// <br>Update Note: 2014/10/07 鄧潘ハン</br>
        /// <br>管理番号   : 11070184-00　SCM仕掛 №10662　RedMine#43047</br>
        /// <br>　　         2014/10/16配信システムテスト障害№10対応</br>
        /// <br>             伝票番号選択画面で「新規問合せ」で登録後、SF側で取消を行うと、PM側に新着通知のポップアップが表示される障害対応</br>
        ///</remarks>
        private class SCMAcOdrDtlAsComparer : Comparer<SCMAcOdrDtlAs>
        {
            public override int Compare(SCMAcOdrDtlAs x, SCMAcOdrDtlAs y)
            {
                int result = y.SalesSlipNum.CompareTo(x.SalesSlipNum);
                return result;
            }
        }
        // --- ADD 2014/10/07 鄧潘ハン 仕掛№10662 システムテスト障害№10----------<<<<<

        /// <summary>
        /// 行番号、枝番毎で、回答、未回答が判別できるディクショナリを生成します。
        /// </summary>
        /// <param name="detailList"></param>
        /// <param name="answerList"></param>
        /// <returns></returns>
        internal static Dictionary<string, bool> CreateAnswerdCheckDictionary(int cancelDiv, List<SCMAcOdrDtlIq> detailIqList, List<SCMAcOdrDtlAs> detailAsList)
        {
            Dictionary<string, bool> andweredCheckDictionary = new Dictionary<string, bool>();

            // --- ADD 2014/10/07 鄧潘ハン 仕掛№10662 システムテスト障害№10---------->>>>>
            List<SCMAcOdrDtlAs> detailAsList2 = new List<SCMAcOdrDtlAs>();
            // SCM受注明細データ(回答)比較クラス(売上番号(降順))
            detailAsList.Sort(new SCMAcOdrDtlAsComparer());
            Dictionary<string, string> scmAcOdrDtlAsDic = new Dictionary<string, string>();
            // SF画面のSCM受注明細データ(回答)データのフィルター
            foreach (SCMAcOdrDtlAs ans in detailAsList)
            {
                string key = string.Format("{0},{1}", ans.InqRowNumber, ans.InqRowNumDerivedNo);
                if (!scmAcOdrDtlAsDic.ContainsKey(key))
                {
                    detailAsList2.Add(ans);
                    scmAcOdrDtlAsDic.Add(key, key);
                }
            }

            // --- ADD 2014/10/07 鄧潘ハン 仕掛№10662 システムテスト障害№10----------<<<<<

            //foreach (SCMAcOdrDtlAs ans in detailAsList)// DEL 2014/10/07 鄧潘ハン 仕掛№10662 システムテスト障害№10
            foreach (SCMAcOdrDtlAs ans in detailAsList2)// ADD 2014/10/07 鄧潘ハン 仕掛№10662 システムテスト障害№10
            {
                if (cancelDiv == 1 && ans.CancelCndtinDiv == 0) continue;
                if (cancelDiv == 0 && ans.CancelCndtinDiv != 0) continue;
                string key = string.Format("{0},{1}", ans.InqRowNumber, ans.InqRowNumDerivedNo);
                if (!andweredCheckDictionary.ContainsKey(key)) andweredCheckDictionary.Add(key, true);

                SCMAcOdrDtlIq detailInq = detailIqList.Find(
                    delegate(SCMAcOdrDtlIq inq)
                    {
                        return ( ( inq.InqRowNumber == ans.InqRowNumber ) && ( inq.InqRowNumDerivedNo == ans.InqRowNumDerivedNo ) );
                    });

                if (detailInq != null)
                {
                    // キャンセル確定した明細は回答済み扱い
                    if (detailInq.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                    // 問合せ明細の方が新しければ、未回答
                    if (( detailInq.UpdateDate > ans.UpdateDate ) || ( ( detailInq.UpdateDate == ans.UpdateDate ) && ( detailInq.UpdateTime > ans.UpdateTime ) ))
                    {
                        andweredCheckDictionary[key] = false;
                    }
                }
            }

            foreach (SCMAcOdrDtlIq inq in detailIqList)
            {
                string key = string.Format("{0},{1}", inq.InqRowNumber, inq.InqRowNumDerivedNo);
                if (andweredCheckDictionary.ContainsKey(key)) continue;

                andweredCheckDictionary.Add(key, ( inq.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled ));
            }

            return andweredCheckDictionary;
        }
        // 2011/02/18 Add <<<
    }
}
