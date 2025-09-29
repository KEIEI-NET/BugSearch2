//****************************************************************************//
// システム         : NS待機処理
// プログラム名称   : NS待機処理コンフィグ
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
//#define _USING_TEST_SENDER_ // テスト用送信処理アプリを使用するフラグ（※通常は無効とすること）

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// NS待機処理のコンフィグクラス
    /// </summary>
    public sealed class SCMSendingDataWatcherConfig
    {
        #region SCM全体設定

        /// <summary>SCM全体設定</summary>
        private SCMTtlSt _scmTotalSetting;
        /// <summary>SCM全体設定を取得します。</summary>
        private SCMTtlSt SCMTotalSetting
        {
            get
            {
                if (_scmTotalSetting == null)
                {
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
                            _scmTotalSetting = scmTtlSt;
                        }
                    }
                }
                return _scmTotalSetting;
            }
        }

        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        public string EnterpriseCode
        {
            get { return SCMTotalSetting.EnterpriseCode; }
        }

        /// <summary>
        /// 拠点コードを取得します。
        /// </summary>
        public string SectionCode
        {
            get { return SCMTotalSetting.SectionCode; }
        }

        #endregion // SCM全体設定

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMSendingDataWatcherConfig() { }

        #endregion // Constructor

        /// <summary>
        /// 監視できるか判断します。
        /// </summary>
        /// <returns>
        /// SCM全体設定マスタ.旧システム連携区分 == 「1:する」
        /// AND
        /// SCM全体設定マスタ.旧システム連携フォルダ != ""
        /// </returns>
        public bool CanWatch()
        {
            // SCM全体設定マスタからパスの設定を行う
            if (SCMTotalSetting != null)
            {
                // 旧システム連携区分が「1:する(PM7SP)」 ※0:しない(PM.NS)
                if (
                    SCMTotalSetting.OldSysCooperatDiv.Equals(1)
                        &&
                    !string.IsNullOrEmpty(SCMTotalSetting.OldSysCoopFolder.Trim())
                )
                {
                    return Directory.Exists(SCMTotalSetting.OldSysCoopFolder);
                }
            }
            return false;
        }

        /// <summary>
        /// 送信データフォルダパスを取得します。
        /// </summary>
        /// <returns>
        /// SCM全体設定マスタ.旧システム連携用フォルダ + "Send"
        /// (※SCM全体設定マスタ.旧システム連携区分が「0:しない」場合、<c>string.Empty</c>を返します)
        /// </returns>
        public string GetSendingDataFolderPath()
        {
            // SCM全体設定マスタからパスの設定を行う
            if (SCMTotalSetting != null)
            {
                // 旧システム連携区分が「1:する(PM7SP)」 ※0:しない(PM.NS)
                if (SCMTotalSetting.OldSysCooperatDiv.Equals(1))
                {
                    return SCMConfig.GetSCMSendingDataPath(SCMTotalSetting);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 監視する名称のフィルタを取得します。
        /// </summary>
        public string WatchingNameFilter
        {
            get
            {
                return "ScmSdRvDt00.xml";   // ∵PM7では、SCM受注データを最後に出力している
            }
        }

        /// <summary>
        /// 送信処理を行うアプリケーション名を取得します。
        /// </summary>
        public string SendingAppName
        {
            get
            {
            #if _USING_TEST_SENDER_
                return "SCMSenderProxy.exe";
            #else
                return "PMSCM01100U.exe";
            #endif
            }
        }

        /// <summary>
        /// コマンドライン引数を取得します。
        /// </summary>
        /// <returns>"/B " + 送信データフォルダパス</returns>
        public string GetCommandLineArg()
        {
            return "/B " + GetSendingDataFolderPath();
        }
    }
}
