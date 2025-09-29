//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM7用単体起動モード回答送信処理コントローラクラス
    /// </summary>
    public sealed class PM7NormalController : NormalModeController
    {
        #region <Override>

        #region <SCMIO生成>
        /// <summary>
        /// SCM I/Oを生成します。
        /// </summary>
        /// <param name="dataPath">データパス</param>
        /// <returns>PM7のSCM I/O</returns>
        /// <see cref="SCMSendController"/>
        protected override SCMIOAgent CreateSCMIO(string dataPath)
        {
            return new PM7IOAgent(dataPath);
        }
        #endregion

        #region <送信後更新処理>
        /// <summary>
        /// SCM受注データを更新します。(PMNSNormalと同じ)
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSendController"/>
        protected override int UpdateAfterSend()
        {
            if (((List<ISCMOrderHeaderRecord>)SCMWebDB.WritedResult.First).Count == 0)
            {
                // 対象0件
                WriteLog("更新対象レコードが0件です。");
                return 0;
            }

            List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList = (List<ISCMOrderHeaderRecord>)SCMWebDB.WritedResult.First;
            List<ISCMOrderCarRecord> userSCMOrderCarRecordList = (List<ISCMOrderCarRecord>)SCMWebDB.WritedResult.Second;
            List<ISCMOrderAnswerRecord> userSCMOrderAnswerRecordList = (List<ISCMOrderAnswerRecord>)SCMWebDB.WritedResult.Third;

            // 型変換
            List<SCMAcOdrDataWork> writeHeaderList = new List<SCMAcOdrDataWork>();
            foreach (UserSCMOrderHeaderRecord userSCMOrderHeaderRecord in userSCMOrderHeaderRecordList)
            {
                writeHeaderList.Add(userSCMOrderHeaderRecord.RealRecord);
            }

            List<SCMAcOdrDtCarWork> writeCarList = new List<SCMAcOdrDtCarWork>();
            foreach (UserSCMOrderCarRecord userSCMOrderCarRecord in userSCMOrderCarRecordList)
            {
                writeCarList.Add(userSCMOrderCarRecord.RealRecord);
            }

            List<SCMAcOdrDtlAsWork> writeAnswerList = new List<SCMAcOdrDtlAsWork>();
            foreach (UserSCMOrderAnswerRecord userSCMOrderAnswerRecord in userSCMOrderAnswerRecordList)
            {
                writeAnswerList.Add(userSCMOrderAnswerRecord.RealRecord);
            }

            // IOWriterの引数
            CustomSerializeArrayList writeList = new CustomSerializeArrayList();
            foreach (SCMAcOdrDataWork header in writeHeaderList)
            {
                SCMAcOdrDtCarWork car;
                List<SCMAcOdrDtlAsWork> answerList;

                // ヘッダに紐づくデータを取得
                this.GetRelatedSCMOdrData(header, writeAnswerList, writeCarList,
                                                out answerList, out car);

                ArrayList answerArrayList = new ArrayList();
                answerArrayList.AddRange(answerList);

                // 1更新処理リストに追加
                CustomSerializeArrayList oneWriteList = new CustomSerializeArrayList();

                oneWriteList.Add(header); // 受注データ
                oneWriteList.Add(car); // 受注データ(車両)
                oneWriteList.Add(answerArrayList); // 受注明細データ(回答)

                writeList.Add(oneWriteList);
            }

            // 更新処理実行
            object writePara = writeList;

            // Write実行
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = SCMIO.UpdateData(writePara);

            return status;
        }
        #endregion

        #region <削除ボタン押下時の削除処理>
        /// <summary>
        /// 削除ボタン押下時の削除処理(PMNSNormalと一緒)
        /// </summary>
        /// <returns></returns>
        protected override int ExecuteDelete(DataRowView drv)
        {
            // キーの取得
            string inqOriginalEpCd = drv.Row[SendingHeaderTable.InqOriginalEpCdColumn.ColumnName].ToString().Trim();//@@@@20230303
            string inqOriginalSecCd = drv.Row[SendingHeaderTable.InqOriginalSecCdColumn.ColumnName].ToString();
            string inqOtherEpCd = drv.Row[SendingHeaderTable.InqOtherEpCdColumn.ColumnName].ToString();
            string inqOtherSecCd = drv.Row[SendingHeaderTable.InqOtherSecCdColumn.ColumnName].ToString();
            Int64 inquiryNumber = (Int64)drv.Row[SendingHeaderTable.InquiryNumberColumn.ColumnName];
            Int32 inqOrdDivCd = (Int32)drv.Row[SendingHeaderTable.InqOrdDivCdColumn.ColumnName];
            Int32 acptAnOdrStatus = (Int32)drv.Row[SendingHeaderTable.AcptAnOdrStatusColumn.ColumnName];
            string salesSlipNum = drv.Row[SendingHeaderTable.SalesSlipNumColumn.ColumnName].ToString();

            // 該当データの取得
            List<SCMAcOdrDataWork> allHeader = SCMIO.CreateUserHeaderRecordList();
            List<SCMAcOdrDtCarWork> allCar = SCMIO.CreateUserCarRecordList();
            List<SCMAcOdrDtlAsWork> allAnswer = SCMIO.CreateUserAnswerRecordList();

            SCMAcOdrDataWork header = allHeader.Find(
                delegate(SCMAcOdrDataWork headerWork)
                {
                    if (headerWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && headerWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && headerWork.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && headerWork.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && headerWork.InquiryNumber == inquiryNumber
                        && headerWork.InqOrdDivCd == inqOrdDivCd
                        && headerWork.AcptAnOdrStatus == acptAnOdrStatus
                        && headerWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            SCMAcOdrDtCarWork car = allCar.Find(
                delegate(SCMAcOdrDtCarWork carWork)
                {
                    if (carWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && carWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && carWork.InquiryNumber == inquiryNumber
                        && carWork.AcptAnOdrStatus == acptAnOdrStatus
                        && carWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            List<SCMAcOdrDtlAsWork> answerList = allAnswer.FindAll(
                delegate(SCMAcOdrDtlAsWork answerWork)
                {
                    if (answerWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && answerWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && answerWork.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && answerWork.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && answerWork.InquiryNumber == inquiryNumber
                        && answerWork.InqOrdDivCd == inqOrdDivCd
                        && answerWork.AcptAnOdrStatus == acptAnOdrStatus
                        && answerWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 更新年月日の更新
            DateTime updateDate = DateTime.Now;
            Int32 updateTime = updateDate.Hour * 10000000 + updateDate.Minute * 100000 + updateDate.Second * 1000 + updateDate.Millisecond;

            header.UpdateDate = updateDate;
            header.UpdateTime = updateTime;

            foreach (SCMAcOdrDtlAsWork answer in answerList)
            {
                answer.UpdateDate = updateDate;
                answer.UpdateTime = updateTime;
            }

            ArrayList answerArrayList = new ArrayList();
            answerArrayList.AddRange(answerList);

            // IOWriterの引数
            CustomSerializeArrayList writeList = new CustomSerializeArrayList();

            // 1更新処理リストに追加
            CustomSerializeArrayList oneWriteList = new CustomSerializeArrayList();

            oneWriteList.Add(header); // 受注データ
            if (car != null)
            {
                oneWriteList.Add(car); // 受注データ(車両)
            }
            oneWriteList.Add(answerArrayList); // 受注明細データ(回答)

            writeList.Add(oneWriteList);

            object writePara = writeList;

            int status = SCMIO.UpdateData(writePara);

            return status;
        }
        #endregion

        #region <保存期限切れXMLファイルの削除処理>
        /// <summary>
        /// 保存期間を過ぎたデータの削除処理
        /// </summary>
        /// <returns></returns>
        protected override int DeleteExpiredData(DateTime limitdate)
        {
            SCMIO.DeletePassedPeriodXMLFiles(limitdate);

            return 0;
        }
        #endregion

        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PM7NormalController() : base()
        {
            // SCM全体設定マスタからパスの設定を行う
            SCMTotalSettingAgent scmTotalSettingDB = new SCMTotalSettingAgent();
            {
                SCMTtlSt scmTtlSt = scmTotalSettingDB.Find(
                    LoginInfoAcquisition.EnterpriseCode,
                    LoginInfoAcquisition.Employee.BelongSectionCode
                );
                if (
                    scmTtlSt != null
                        && !string.IsNullOrEmpty(scmTtlSt.EnterpriseCode.Trim())
                        && !string.IsNullOrEmpty(scmTtlSt.SectionCode.Trim())
                        && scmTtlSt.LogicalDeleteCode.Equals(0)
                )
                {
                    // 旧システム連携区分が「1:する(PM7SP)」 ※0:しない(PM.NS)
                    if (scmTtlSt.OldSysCooperatDiv.Equals(1))
                    {
                        SettingInfo.SCMDataPath = SCMConfig.GetSCMSendingDataPath(scmTtlSt);
                        _logFilePath = Path.Combine(SettingInfo.SCMDataPath, LOG_FILE_NAME);
                    }
                }
            }
        }

        #endregion // </Constructor>
    }
}
