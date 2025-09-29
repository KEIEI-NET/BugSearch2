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
// 作 成 日  2011/08/10  修正内容 : Web上のSCM受発注セット情報を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : ZHANGYH
// 作 成 日  2011/07/12  修正内容 : 1分問題対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/06  修正内容 : Websync PCCUOEのチャンネルを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/11  修正内容 : 高速化対応
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/13  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 13.フル型式固定番号からのＢＬコード検索回数改良対応
//                                : 14.明細取込区分の更新方法を改良対応
//                                : 15.SCM受発注データ（車両情報）取得方法改良対応
//                                : 16.純正品検索改良対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SCMSenderParameterType = Tuple<
        List<ISCMOrderHeaderRecord>,    // 1パラ目：SCM受注データ
        List<ISCMOrderCarRecord>,       // 2パラ目：SCM受注データ(車両情報)
        List<ISCMOrderDetailRecord>,    // 3パラ目：SCM受注明細データ(問合せ・発注)
        List<ISCMOrderAnswerRecord>,    // 4パラ目：SCM受注明細データ(回答)
        // -- DELETE 2011/08/10   ------ >>>>>>
        //NullObject,
        // -- DELETE 2011/08/10   ------ <<<<<<
        // -- ADD 2011/08/10   ------ >>>>>>
        List<ISCMAcOdSetDtRecord>,    // 5パラ目：SCM受注セット部品データ
        // -- ADD 2011/08/10   ------ <<<<<<
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;
    
    /// <summary>
    /// SCM回答送信処理クラス
    /// </summary>
    public sealed class SCMAnswerSender
    {
        private const string MY_NAME = "SCMAnswerSender";

        #region <SCM売上データ作成処理>

        /// <summary>SCM売上データ作成者</summary>
        private readonly SCMSalesDataMaker _salesDataMaker;
        /// <summary>SCM売上データ作成者を取得します。</summary>
        private SCMSalesDataMaker SalesDataMaker { get { return _salesDataMaker; } }

        /// <summary>
        /// 回答送信処理用パラメータを生成します。
        /// </summary>
        /// <returns>回答送信処理用パラメータ</returns>
        private SCMSenderParameterType CreateSenderParameter()
        {
            SCMSenderParameterType parameter = new SCMSenderParameterType();
            {
                List<ISCMOrderHeaderRecord> headerRecordList= new List<ISCMOrderHeaderRecord>();
                List<ISCMOrderCarRecord> carRecordList      = new List<ISCMOrderCarRecord>();
                List<ISCMOrderDetailRecord> detailRecordList= new List<ISCMOrderDetailRecord>();
                List<ISCMOrderAnswerRecord> answerRecordList= new List<ISCMOrderAnswerRecord>();
                // -- ADD 2011/08/10   ------ >>>>>>
                List<ISCMAcOdSetDtRecord> setDtRecordList = new List<ISCMAcOdSetDtRecord>();
                // -- ADD 2011/08/10   ------ <<<<<<

                {
                    foreach (string salesKey in SalesDataMaker.SCMSalesListEssenceMap.Keys)
                    {
                        SCMSalesListEssence essence = SalesDataMaker.SCMSalesListEssenceMap[salesKey];

                        ISCMOrderHeaderRecord scmHeaderRecord = essence.SCMHeaderRecord;
                        if (scmHeaderRecord.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                        {
                            continue;  // 受注ステータスが"受注"の場合、回答送信処理を実行しない
                        }

                        headerRecordList.Add(essence.SCMHeaderRecord);  // SCM受注データ
                        carRecordList.Add(essence.SCMCarRecord);        // SCM受注データ(車両情報)

                        ListIterator<ISCMOrderDetailRecord> scmDetailIterator = essence.CreateSCMDetailIterator();
                        while (scmDetailIterator.HasNext())
                        {
                            detailRecordList.Add(scmDetailIterator.GetNext());  // SCM受注明細データ(問合せ・発注)
                        }

                        ListIterator<ISCMOrderAnswerRecord> scmAnswerIterator = essence.CreateSCMAnswerIterator();
                        while (scmAnswerIterator.HasNext())
                        {
                            answerRecordList.Add(scmAnswerIterator.GetNext());  // SCM受注明細データ(回答)
                        }

                        // -- ADD 2011/08/10   ------ >>>>>>
                        ListIterator<ISCMAcOdSetDtRecord> scmSetDtIterator = essence.CreateSCMSetDtIterator();
                        while (scmSetDtIterator.HasNext())
                        {
                            setDtRecordList.Add(scmSetDtIterator.GetNext());
                        }
                        // -- ADD 2011/08/10   ------ <<<<<<
                    }
                }
                parameter.Member01 = headerRecordList;
                parameter.Member02 = carRecordList;
                parameter.Member03 = detailRecordList;
                parameter.Member04 = answerRecordList;
                // -- ADD 2011/08/10   ------ >>>>>>
                parameter.Member05 = setDtRecordList;
                // -- ADD 2011/08/10   ------ <<<<<<
            }
            return parameter;
        }

        #endregion // </SCM売上データ作成処理>

        #region <売伝リモートの書込み結果>

        /// <summary>売伝リモートの書込み結果</summary>
        private SalesSlipWriterParameter _writedSalesSlipParameter;
        /// <summary>売伝リモートの書込み結果を取得または設定します。</summary>
        public SalesSlipWriterParameter WritedSalesSlipParameter
        {
            get { return _writedSalesSlipParameter; }
            set { _writedSalesSlipParameter = value; }
        }

        /// <summary>
        /// 回答送信処理用パラメータに変換します。
        /// </summary>
        /// <returns>回答送信処理用パラメータ</returns>
        private SCMSenderParameterType ConvertSenderParameter()
        {
            const string METHOD_NAME = "ConvertSenderParameter()";  // ログ用

            SCMSenderParameterType parameter = new SCMSenderParameterType();
            {
                List<ISCMOrderHeaderRecord> headerRecordList= new List<ISCMOrderHeaderRecord>();
                List<ISCMOrderCarRecord>    carRecordList   = new List<ISCMOrderCarRecord>();
                List<ISCMOrderDetailRecord> detailRecordList= new List<ISCMOrderDetailRecord>();
                List<ISCMOrderAnswerRecord> answerRecordList= new List<ISCMOrderAnswerRecord>();
                // -- ADD 2011/08/10   ------ >>>>>>
                List<ISCMAcOdSetDtRecord> setDtRecordList = new List<ISCMAcOdSetDtRecord>();
                // -- ADD 2011/08/10   ------ <<<<<<
                {
                    foreach (SalesSlipWriterItem salesSlipItem in WritedSalesSlipParameter.SalesSlipItemList)
                    {
                        if (salesSlipItem.SCMOrderData.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                        {
                            #region <Log>

                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                                "受注ステータスが「20:受注」のため、回答送信データを生成しませんでした。" + Environment.NewLine
                                + SCMDataHelper.GetProfile(salesSlipItem.SCMOrderData)
                            ));

                            #endregion // </Log>

                            continue;  // 受注ステータスが"受注"の場合、回答送信処理を実行しない
                        }

                        // SCM受注データ
                        headerRecordList.Add(new UserSCMOrderHeaderRecord(salesSlipItem.SCMOrderData));

                        // SCM受注データ(車両情報)
                        carRecordList.Add(new UserSCMOrderCarRecord(salesSlipItem.SCMOrderCarData));

                        // SCM受注明細データ(問合せ・発注)
                        foreach (SCMAcOdrDtlIqWork detailData in salesSlipItem.SCMOrderDataDetailList)
                        {
                            detailRecordList.Add(new UserSCMOrderDetailRecord(detailData));
                        }

                        // SCM受注明細データ(回答)
                        foreach (SCMAcOdrDtlAsWork answerData in salesSlipItem.ScmOrderDataAnswerList)
                        {
                            answerRecordList.Add(new UserSCMOrderAnswerRecord(answerData));
                        }
                        // -- ADD 2011/08/10   ------ >>>>>>
                        foreach (SCMAcOdSetDtWork setDt in salesSlipItem.ScmOrderDataSetDtList)
                        {
                            setDtRecordList.Add(new UserSCMAcOdSetDtRecord(setDt));
                        }
                        // -- ADD 2011/08/10   ------ <<<<<<
                    }
                }
                parameter.Member01 = headerRecordList;
                parameter.Member02 = carRecordList;
                parameter.Member03 = detailRecordList;
                parameter.Member04 = answerRecordList;
                // -- ADD 2011/08/10   ------ >>>>>>
                parameter.Member05 = setDtRecordList;
                // -- ADD 2011/08/10   ------ <<<<<<
            }
            return parameter;
        }

        #endregion // </売伝リモートの書込み結果>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="salesDataMaker">SCM売上データ作成者</param>
        public SCMAnswerSender(SCMSalesDataMaker salesDataMaker)
        {
            _salesDataMaker = salesDataMaker;
        }

        #endregion // </Constructor>

        /// <summary>
        /// SCM Webサーバへ送信します。
        /// </summary>
        /// <param name="sendEnterpriceCodeList">企業コードリスト</param>
        /// <param name="sendSectionCodeList">拠点コードリスト</param>
        /// <param name="writeFlg">DB更新フラグ</param>
        /// <returns>結果コード</returns>
        // 2011.07.12 ZHANGYH EDT STA >>>>>>
        //public int SendToWebServer()
        //>>>2012/04/11
        //public int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList)
        public int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, bool writeFlg)
        //<<<2012/04/11
        // 2011.07.12 ZHANGYH EDT END <<<<<<
        {
            // 2011.07.12 ZHANGYH EDT STA >>>>>>
            sendEnterpriceCodeList = null;
            sendSectionCodeList = null;
            // 2011.07.12 ZHANGYH EDT END <<<<<<
            // 2011.09.06 zhouzy ADD STA >>>>>>
            List<SCMAcOdrDataWork> scmAcOdrDataList = null;
            // 2011.09.06 zhouzy ADD END <<<<<<


            SCMSenderParameterType parameter = null;
            {
                if (WritedSalesSlipParameter != null)
                {
                    parameter = ConvertSenderParameter();
                }
                else
                {
                    parameter = CreateSenderParameter();
                }
            }
            // SCM受注明細データ(回答)がない場合、送信せずに終了
            if (parameter.Member04.Count.Equals(0)) return (int)ResultUtil.ResultCode.Normal;

            // -- DEL 2011/08/10   ------ >>>>>>
            //SCMSendController sender = new SCMMethodCalledController(
            //    parameter.Member01,
            //    parameter.Member02,
            //    parameter.Member03,
            //    parameter.Member04
            //);
            // -- DEL 2011/08/10   ------ <<<<<<

            // -- ADD 2011/08/10   ------ >>>>>>
            SCMSendController sender = new SCMMethodCalledController(
                parameter.Member01,
                parameter.Member02,
                parameter.Member04,
                parameter.Member05
            );
            // -- ADD 2011/08/10   ------ <<<<<<
            
            sender.OpenLog();
            // 2011.07.12 ZHANGYH EDT STA >>>>>>
            //int status = sender.Send();
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            //int status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList);

            //>>>2012/04/11
            //int status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            int status = 0;
            if (writeFlg)
            {
                status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            }
            //<<<2012/04/11

            // 2011.09.06 zhouzy UPDATE END <<<<<<
            // 2011.07.12 ZHANGYH EDT END <<<<<<
            sender.CloseLog();

            return status;
        }

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ---------------------------------->>>>>
        /// <summary>
        /// SCM Webサーバへ送信します。（SCM受発注データ（車両情報）付）
        /// </summary>
        /// <param name="sendEnterpriceCodeList">企業コードリスト</param>
        /// <param name="sendSectionCodeList">拠点コードリスト</param>
        /// <param name="writeFlg">DB更新フラグ</param>
        /// <param name="scmOdDtCarList">SCM受注データ（車両情報）</param>
        /// <returns>結果コード</returns>
        public int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, bool writeFlg, List<ScmOdDtCar> scmOdDtCarList)
        {
            sendEnterpriceCodeList = null;
            sendSectionCodeList = null;
            List<SCMAcOdrDataWork> scmAcOdrDataList = null;

            SCMSenderParameterType parameter = null;
            {
                if (WritedSalesSlipParameter != null)
                {
                    parameter = ConvertSenderParameter();
                }
                else
                {
                    parameter = CreateSenderParameter();
                }
            }
            // SCM受注明細データ(回答)がない場合、送信せずに終了
            if (parameter.Member04.Count.Equals(0)) return (int)ResultUtil.ResultCode.Normal;

            SCMSendController sender = new SCMMethodCalledController(
                parameter.Member01,
                parameter.Member02,
                parameter.Member04,
                parameter.Member05,
                scmOdDtCarList
            );

            sender.OpenLog();

            int status = 0;
            if (writeFlg)
            {
                status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            }
            sender.CloseLog();

            return status;
        }
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№15.SCM受発注データ（車両情報）取得方法改良対応 ----------------------------------<<<<<

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// SCM Webサーバへ送信します。
        /// </summary>
        /// <returns>結果コード</returns>
        public int SendToWebServer()
        {
            List<string> sendEnterpriceCodeList;
            List<string> sendSectionCodeList;
            //>>>2012/04/11
            //return SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList);
            return SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList, true);
            //<<<2012/04/11
        }
        // 2011.07.12 ZHANGYH ADD END <<<<<<
    }
}
