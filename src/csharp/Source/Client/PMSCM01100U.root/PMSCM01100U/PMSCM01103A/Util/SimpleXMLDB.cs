//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/06/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/06/22  修正内容 : NS待機処理対応
//----------------------------------------------------------------------------//
#define _ENABLED_CODING_DATA_   // 暗号化したXMLデータを使用するフラグ ※通常は有効にしておくこと！
#define _CAN_PRINT_XML_         // インプットXMLデータを出力するフラグ

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller.Util
{
    using HeaderPair = KeyValuePair<SCMAcOdrDataWork, SCMAcOdrData>; // SCM受注データのペア(NS版とPM7版)

    /// <summary>
    /// 簡易XMLデータベースクラス
    /// </summary>
    public class SimpleXMLDB
    {
        const string MY_NAME = "SimpleXMLDB";   // ログ用

        #region <パス>

        /// <summary>XMLファイルのパス</summary>
        private readonly string _xmlPathName;
        /// <summary>XMLファイルのパスを取得します。</summary>
        protected string XMLPathName { get { return _xmlPathName; } }

        #endregion // </パス>

        /// <summary>DB</summary>
        private DataSet _db;
        /// <summary>DBを取得します。</summary>
        public DataSet DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new DataSet();
                    _db.ReadXml(XMLPathName);
                }
                return _db;
            }
        }

        /// <summary>
        /// デフォルトテーブルを取得します。
        /// </summary>
        public DataTable DefaultTable
        {
            get { return DB.Tables[0]; }
        }

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="xmlFilePathName">XMLファイルのパス</param>
        public SimpleXMLDB(string xmlFilePathName)
        {
            _xmlPathName = xmlFilePathName;
        }

        #endregion // </Constructor>

        #region <デシリアライズ>

        #region <SCM受注データ>

        /// <summary>
        /// SCM受注データをデシリアライズします。
        /// </summary>
        /// <param name="scmAcOdrDataStream">SCM受注データXMLファイルを読み込んだストリーム</param>
        /// <returns>SCM受注データワーククラスのインスタンス</returns>
        public static HeaderPair DeserializeHeaderData(FileStream scmAcOdrDataStream)
        {
            const string METHOD_NAME = "DeserializeHeaderData()";   // ログ用

            XmlSerializer scmAcOdrDataSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrData));

            SCMAcOdrData pm7SCMAcOdrData = null;
            {
            #if _ENABLED_CODING_DATA_
                byte[] decryptXML = TSPSendXMLReader.DecryptXML(scmAcOdrDataStream);
                MemoryStream memStr = new MemoryStream(decryptXML);

                #region <Log>

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("SCM受注データをデシリアライズ中..."));

                #endregion // </Log>

                Print(decryptXML);

                pm7SCMAcOdrData = (SCMAcOdrData)scmAcOdrDataSerializer.Deserialize(memStr);

                #region <Log>

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("SCM受注データをデシリアライズ完了"));

                #endregion // </Log>

            #else
                pm7SCMAcOdrData = (SCMAcOdrData)scmAcOdrDataSerializer.Deserialize(scmAcOdrDataStream);
            #endif
            }
            SCMAcOdrDataWork scmAcOdrDataWork = CreateSCMAcOdrDataWork(pm7SCMAcOdrData);

            return new HeaderPair(scmAcOdrDataWork, pm7SCMAcOdrData);
        }

        /// <summary>
        /// SCM受注データ同士の関連キーを取得します。
        /// </summary>
        /// <param name="scmAcOdrDataWork">NS版SCM受注データ</param>
        /// <returns>得意先コード + "_" + 受注ステータス + "_" + 売上伝票番号</returns>
        public static string GetHeaderRelationKey(SCMAcOdrDataWork scmAcOdrDataWork)
        {
            StringBuilder key = new StringBuilder();
            {
                const string DELIM = "_";

                key.Append(scmAcOdrDataWork.CustomerCode.ToString("00000000"));
                key.Append(DELIM);
                key.Append(scmAcOdrDataWork.AcptAnOdrStatus.ToString("00"));
                key.Append(DELIM);
                key.Append(scmAcOdrDataWork.SalesSlipNum.PadLeft(9, '0'));
            }
            return key.ToString();
        }

        /// <summary>
        /// NS版SCM受注データを生成します。
        /// </summary>
        /// <param name="pm7SCMAcOdrData">PM7版SCM受注データ</param>
        /// <returns>NS版SCM受注データ</returns>
        public static SCMAcOdrDataWork CreateSCMAcOdrDataWork(SCMAcOdrData pm7SCMAcOdrData)
        {
            SCMAcOdrDataWork scmAcOdrDataWork = new SCMAcOdrDataWork();
            {
                #region <フィールドをコピー>

                scmAcOdrDataWork.AcptAnOdrStatus = pm7SCMAcOdrData.AcptAnOdrStatus;
                scmAcOdrDataWork.AnsEmployeeCd = pm7SCMAcOdrData.AnsEmployeeCd;
                scmAcOdrDataWork.AnsEmployeeNm = pm7SCMAcOdrData.AnsEmployeeNm;
                scmAcOdrDataWork.AnswerCreateDiv = pm7SCMAcOdrData.AnswerCreateDiv;
                scmAcOdrDataWork.AnswerDivCd = pm7SCMAcOdrData.AnswerDivCd;
                scmAcOdrDataWork.AppendingFile = pm7SCMAcOdrData.AppendingFile;
                scmAcOdrDataWork.AppendingFileNm = pm7SCMAcOdrData.AppendingFileNm;
                scmAcOdrDataWork.CreateDateTime = pm7SCMAcOdrData.CreateDateTime;
                scmAcOdrDataWork.CustomerCode = pm7SCMAcOdrData.CustomerCode;
                scmAcOdrDataWork.EnterpriseCode = pm7SCMAcOdrData.EnterpriseCode;
                scmAcOdrDataWork.FileHeaderGuid = pm7SCMAcOdrData.FileHeaderGuid;
                scmAcOdrDataWork.InqEmployeeCd = pm7SCMAcOdrData.InqEmployeeCd;
                scmAcOdrDataWork.InqEmployeeNm = pm7SCMAcOdrData.InqEmployeeNm;
                scmAcOdrDataWork.InqOrdAnsDivCd = pm7SCMAcOdrData.InqOrdAnsDivCd;
                scmAcOdrDataWork.InqOrdDivCd = pm7SCMAcOdrData.InqOrdDivCd;
                scmAcOdrDataWork.InqOrdNote = pm7SCMAcOdrData.InqOrdNote;
                scmAcOdrDataWork.InqOriginalEpCd = pm7SCMAcOdrData.InqOriginalEpCd.Trim();//@@@@20230303
                scmAcOdrDataWork.InqOriginalSecCd = pm7SCMAcOdrData.InqOriginalSecCd;
                scmAcOdrDataWork.InqOtherEpCd = pm7SCMAcOdrData.InqOtherEpCd;
                scmAcOdrDataWork.InqOtherSecCd = pm7SCMAcOdrData.InqOtherSecCd;
                scmAcOdrDataWork.InquiryDate = pm7SCMAcOdrData.InquiryDate;
                scmAcOdrDataWork.InquiryNumber = pm7SCMAcOdrData.InquiryNumber;
                scmAcOdrDataWork.JudgementDate = pm7SCMAcOdrData.JudgementDate;
                scmAcOdrDataWork.LogicalDeleteCode = pm7SCMAcOdrData.LogicalDeleteCode;
                scmAcOdrDataWork.ReceiveDateTime = pm7SCMAcOdrData.ReceiveDateTime;
                scmAcOdrDataWork.SalesSlipNum = pm7SCMAcOdrData.SalesSlipNum;
                scmAcOdrDataWork.SalesSubtotalTax = pm7SCMAcOdrData.SalesSubtotalTax;
                scmAcOdrDataWork.SalesTotalTaxInc = pm7SCMAcOdrData.SalesTotalTaxInc;
                scmAcOdrDataWork.UpdAssemblyId1 = pm7SCMAcOdrData.UpdAssemblyId1;
                scmAcOdrDataWork.UpdAssemblyId2 = pm7SCMAcOdrData.UpdAssemblyId2;
                scmAcOdrDataWork.UpdateDate = pm7SCMAcOdrData.UpdateDate;
                scmAcOdrDataWork.UpdateDateTime = pm7SCMAcOdrData.UpdateDateTime;
                scmAcOdrDataWork.UpdateTime = pm7SCMAcOdrData.UpdateTime;
                scmAcOdrDataWork.UpdEmployeeCode = pm7SCMAcOdrData.UpdEmployeeCode;

                // ADD 2010/06/22 NS待機処理対応 ---------->>>>>
                scmAcOdrDataWork.CancelDiv = pm7SCMAcOdrData.CancelDiv;
                scmAcOdrDataWork.CMTCooprtDiv = pm7SCMAcOdrData.CMTCooprtDiv;
                // ADD 2010/06/22 NS待機処理対応 ----------<<<<<

                #endregion // </フィールドをコピー>
            }
            return scmAcOdrDataWork;
        }

        /// <summary>
        /// SCM受注データをコピーします。
        /// </summary>
        /// <param name="scmAcOdrDataWork">NS版SCM受注データ</param>
        /// <param name="pm7SCMAcOdrData">PM7版SCM受注データ</param>
        public static void CopyHeaderData(
            SCMAcOdrDataWork scmAcOdrDataWork,
            ref SCMAcOdrData pm7SCMAcOdrData
        )
        {
            #region <フィールドをコピー>

            pm7SCMAcOdrData.AcptAnOdrStatus = scmAcOdrDataWork.AcptAnOdrStatus;
            pm7SCMAcOdrData.AnsEmployeeCd = scmAcOdrDataWork.AnsEmployeeCd;
            pm7SCMAcOdrData.AnsEmployeeNm = scmAcOdrDataWork.AnsEmployeeNm;
            pm7SCMAcOdrData.AnswerCreateDiv = scmAcOdrDataWork.AnswerCreateDiv;
            pm7SCMAcOdrData.AnswerDivCd = scmAcOdrDataWork.AnswerDivCd;
            pm7SCMAcOdrData.AppendingFile = scmAcOdrDataWork.AppendingFile;
            pm7SCMAcOdrData.AppendingFileNm = scmAcOdrDataWork.AppendingFileNm;
            pm7SCMAcOdrData.CreateDateTime = scmAcOdrDataWork.CreateDateTime;
            pm7SCMAcOdrData.CustomerCode = scmAcOdrDataWork.CustomerCode;
            pm7SCMAcOdrData.EnterpriseCode = scmAcOdrDataWork.EnterpriseCode;
            pm7SCMAcOdrData.FileHeaderGuid = scmAcOdrDataWork.FileHeaderGuid;
            pm7SCMAcOdrData.InqEmployeeCd = scmAcOdrDataWork.InqEmployeeCd;
            pm7SCMAcOdrData.InqEmployeeNm = scmAcOdrDataWork.InqEmployeeNm;
            pm7SCMAcOdrData.InqOrdAnsDivCd = scmAcOdrDataWork.InqOrdAnsDivCd;
            pm7SCMAcOdrData.InqOrdDivCd = scmAcOdrDataWork.InqOrdDivCd;
            pm7SCMAcOdrData.InqOrdNote = scmAcOdrDataWork.InqOrdNote;
            pm7SCMAcOdrData.InqOriginalEpCd = scmAcOdrDataWork.InqOriginalEpCd.Trim();//@@@@20230303
            pm7SCMAcOdrData.InqOriginalSecCd = scmAcOdrDataWork.InqOriginalSecCd;
            pm7SCMAcOdrData.InqOtherEpCd = scmAcOdrDataWork.InqOtherEpCd;
            pm7SCMAcOdrData.InqOtherSecCd = scmAcOdrDataWork.InqOtherSecCd;
            pm7SCMAcOdrData.InquiryDate = scmAcOdrDataWork.InquiryDate;
            pm7SCMAcOdrData.InquiryNumber = scmAcOdrDataWork.InquiryNumber;
            pm7SCMAcOdrData.JudgementDate = scmAcOdrDataWork.JudgementDate;
            pm7SCMAcOdrData.LogicalDeleteCode = scmAcOdrDataWork.LogicalDeleteCode;
            pm7SCMAcOdrData.ReceiveDateTime = scmAcOdrDataWork.ReceiveDateTime;
            pm7SCMAcOdrData.SalesSlipNum = scmAcOdrDataWork.SalesSlipNum;
            pm7SCMAcOdrData.SalesSubtotalTax = scmAcOdrDataWork.SalesSubtotalTax;
            pm7SCMAcOdrData.SalesTotalTaxInc = scmAcOdrDataWork.SalesTotalTaxInc;
            pm7SCMAcOdrData.UpdAssemblyId1 = scmAcOdrDataWork.UpdAssemblyId1;
            pm7SCMAcOdrData.UpdAssemblyId2 = scmAcOdrDataWork.UpdAssemblyId2;
            pm7SCMAcOdrData.UpdateDate = scmAcOdrDataWork.UpdateDate;
            pm7SCMAcOdrData.UpdateDateTime = scmAcOdrDataWork.UpdateDateTime;
            pm7SCMAcOdrData.UpdateTime = scmAcOdrDataWork.UpdateTime;
            pm7SCMAcOdrData.UpdEmployeeCode = scmAcOdrDataWork.UpdEmployeeCode;

            // ADD 2010/06/22 NS待機処理対応 ---------->>>>>
            pm7SCMAcOdrData.CancelDiv = scmAcOdrDataWork.CancelDiv;
            pm7SCMAcOdrData.CMTCooprtDiv = scmAcOdrDataWork.CMTCooprtDiv;
            // ADD 2010/06/22 NS待機処理対応 ----------<<<<<

            #endregion // </フィールドをコピー>
        }

        // TODO:ゴミ掃除
        #region <ボツ>

        /// <summary>
        /// SCM受注データをデシリアライズします。
        /// </summary>
        /// <param name="scmAcOdrDataSerializer">SCM受注データXMLファイルストリームのデシリアライザ</param>
        /// <param name="scmAcOdrDataStream">SCM受注データXMLファイルを読み込んだストリーム</param>
        /// <returns>SCM受注データワーククラスのインスタンス</returns>
        private static SCMAcOdrDataWork DeserializeHeaderData(
            XmlSerializer scmAcOdrDataSerializer,
            FileStream scmAcOdrDataStream
        )
        {
            SCMAcOdrDataWork scmAcOdrDataWork = null;
            {
            #if _ENABLED_CODING_DATA_
                byte[] decryptXML = TSPSendXMLReader.DecryptXML(scmAcOdrDataStream);
                MemoryStream memStr = new MemoryStream(decryptXML);

                Print(decryptXML);

                scmAcOdrDataWork = (SCMAcOdrDataWork)scmAcOdrDataSerializer.Deserialize(memStr);
            #else
                scmAcOdrDataWork = (SCMAcOdrDataWork)scmAcOdrDataSerializer.Deserialize(scmAcOdrDataStream);
            #endif
            }
            return scmAcOdrDataWork;
        }

        #endregion // </ボツ>

        #endregion // </SCM受注データ>

        #region <SCM受注明細データ(回答)>

        /// <summary>
        /// SCM受注明細データ(回答)をデシリアライズします。
        /// </summary>
        /// <param name="scmAcOdrDtlAsSerializer">SCM受注明細データ(回答)XMLファイルストリームのデシリアライザ</param>
        /// <param name="scmAcOdrDtlAsStream">SCM受注明細データ(回答)XMLファイルを読み込んだストリーム</param>
        /// <returns>SCM受注明細データ(回答)ワーククラスのインスタンス</returns>
        public static SCMAcOdrDtlAsWork[] DeserializeAnswerData(
            XmlSerializer scmAcOdrDtlAsSerializer,
            FileStream scmAcOdrDtlAsStream
        )
        {
            const string METHOD_NAME = "DeserializeAnswerData()";   // ログ用

            SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWork = null;
            {
            #if _ENABLED_CODING_DATA_
                byte[] decryptXML = Broadleaf.Windows.Forms.TSPSendXMLReader.DecryptXML(scmAcOdrDtlAsStream);
                MemoryStream memStr = new MemoryStream(decryptXML);

                #region <Log>

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("SCM受注明細データ(回答)をデシリアライズ中..."));

                #endregion // </Log>

                Print(decryptXML);

                scmAcOdrDtlAsWork = (SCMAcOdrDtlAsWork[])scmAcOdrDtlAsSerializer.Deserialize(memStr);

                #region <Log>

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("SCM受注明細データ(回答)をデシリアライズ完了"));

                #endregion // </Log>
            #else
                scmAcOdrDtlAsWork = (SCMAcOdrDtlAsWork[])scmAcOdrDtlAsSerializer.Deserialize(scmAcOdrDtlAsStream);
            #endif
            }
            return scmAcOdrDtlAsWork;
        }

        #endregion // </SCM受注明細データ(回答)>

        #region <SCM受注データ(車両情報)>

        /// <summary>
        /// SCM受注データ(車両情報)をデシリアライズします。
        /// </summary>
        /// <param name="scmAcOdrDtCarSerializer">SCM受注データ(車両情報)XMLファイルストリームのデシリアライザ</param>
        /// <param name="scmAcOdrDtCarStream">SCM受注データ(車両情報)XMLファイルを読み込んだストリーム</param>
        /// <returns>SCM受注データ(車両情報)ワーククラスのインスタンス</returns>
        public static SCMAcOdrDtCarWork DeserializeCarData(
            XmlSerializer scmAcOdrDtCarSerializer,
            FileStream scmAcOdrDtCarStream
        )
        {
            const string METHOD_NAME = "DeserializeCarData()";  // ログ用

            SCMAcOdrDtCarWork scmAcOdrDataCarWork = null;
            {
            #if _ENABLED_CODING_DATA_
                byte[] decryptXML = Broadleaf.Windows.Forms.TSPSendXMLReader.DecryptXML(scmAcOdrDtCarStream);
                MemoryStream memStr = new MemoryStream(decryptXML);

                #region <Log>

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("SCM受注データ(車両情報)をデシリアライズ中..."));

                #endregion // </Log>

                Print(decryptXML);

                scmAcOdrDataCarWork = (SCMAcOdrDtCarWork)scmAcOdrDtCarSerializer.Deserialize(memStr);

                #region <Log>

                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg("SCM受注データ(車両情報)をデシリアライズ完了"));

                #endregion // </Log>
            #else
                scmAcOdrDataCarWork = (SCMAcOdrDtCarWork)scmAcOdrDtCarSerializer.Deserialize(scmAcOdrDtCarStream);
            #endif
            }
            return scmAcOdrDataCarWork;
        }

        #endregion // </SCM受注データ(車両情報)>

        #region <デバッグ用>

        /// <summary>
        /// 復号化された文字コード配列を表示します。
        /// </summary>
        /// <param name="codedText">復号化された文字コード配列</param>
        [Conditional("_CAN_PRINT_XML_")]
        private static void Print(byte[] codedText)
        {
            const string METHOD_NAME = "Print()";   // ログ用

            Debug.WriteLine(Broadleaf.Library.Text.TStrConv.SJisToUnicode(codedText).Trim());

            string msg = "[XMLデータ]" + Environment.NewLine;

            if (codedText != null && codedText.Length > 0)
            {
                msg += Broadleaf.Library.Text.TStrConv.SJisToUnicode(codedText).Trim();
            }
            else
            {
                msg += "\t復号化に失敗しています。byte[] == null または byte[].Length = 0";
            }
            SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));
        }

        #endregion // <デバッグ用>

        #endregion // </デシリアライズ>
    }
}
