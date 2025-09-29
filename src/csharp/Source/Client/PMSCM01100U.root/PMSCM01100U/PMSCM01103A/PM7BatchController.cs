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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM7用送信起動モード回答送信処理コントローラクラス
    /// </summary>
    public sealed class PM7BatchController : BatchModeController
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

            // TODO:ゴミ掃除…旧インターフェース(/B ...)の廃止
            #region <ボツ>
            //// 起動パラメータから必要なデータを取得する
            //string salesSlipNum = _commandLineArgs[1];
            //int acptAnOdrStatus = PM7IOAgent.ConvertAcptAnOdrStatus(Convert.ToInt32(_commandLineArgs[2]));
            //int serverNumber    = Convert.ToInt32(_commandLineArgs[3]);
            //int customerCd      = Convert.ToInt32(_commandLineArgs[4]);

            //return new PM7IOAgent(dataPath, salesSlipNum, acptAnOdrStatus, serverNumber, customerCd);
            #endregion // </ボツ>
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

        #region <保存期限切れデータ削除処理>
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

        #region <コマンドライン引数>

        /// <summary>コマンドライン引数</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>コマンドライン引数を取得します。</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </コマンドライン引数>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="path">データパス</param>
        public PM7BatchController(string path) : base(path) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        [Obsolete("PM7用の送信起動モードはコンストラクタ(string)を使用して下さい。")]
        public PM7BatchController(string[] commandLineArgs) : base(string.Empty)
        {
            _commandLineArgs = commandLineArgs;
        }

        #endregion // </Constructor>
    }
}
