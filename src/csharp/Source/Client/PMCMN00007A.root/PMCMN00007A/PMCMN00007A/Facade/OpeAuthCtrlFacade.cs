//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : マスタメンテナンス
// プログラム概要   : マスタメンテナンスの制御全般を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2008/09/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller.Facade
{
    /// <summary>
    /// 操作権限の制御の窓口クラス
    /// </summary>
    public static class OpeAuthCtrlFacade
    {
        /// <summary>メッセージ用の名称</summary>
        private const string MY_NAME = "セキュリティ管理";  // LITERAL:
        /// <summary>起動不可時のメッセージ</summary>
        private const string CANNOT_RUN_BY_SECURITY_AUTHORITY = "操作権限の制限により、本機能はご使用できません。"; // LITERAL:

        #region <Obsolete/>

        /// <summary>
        /// 初期化を行い、起動できるか判定します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="opeAuthCtrlform">操作権限の制御を行うフォーム</param>
        /// <param name="assemblyId">アセンブリID(プログラムID)</param>
        /// <returns>
        /// <c>true</c> :初期化に成功および起動可能<br/>
        /// <c>false</c>:初期化に失敗または起動不可
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">対象外のカテゴリーです。</exception>
        [Obsolete("CanRunWithInitializing(EntityUtil.CategoryCode, IOperationAuthorityControllable, string, string) を使用して下さい。")]
        public static bool CanRunWithInitializing(
            EntityUtil.CategoryCode categoryCode,
            IOperationAuthorityControllable opeAuthCtrlform,
            string assemblyId
        )
        {
            return CanRunWithInitializing(categoryCode, opeAuthCtrlform, assemblyId, string.Empty);
        }

        #endregion  // <Obsolete/>

        /// <summary>
        /// 初期化を行い、起動できるか判定します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="opeAuthCtrlform">操作権限の制御を行うフォーム</param>
        /// <param name="assemblyId">アセンブリID(プログラムID)</param>
        /// <param name="programName">機能名称</param>
        /// <returns>
        /// <c>true</c> :初期化に成功および起動可能<br/>
        /// <c>false</c>:初期化に失敗または起動不可
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">対象外のカテゴリーです。</exception>
        public static bool CanRunWithInitializing(
            EntityUtil.CategoryCode categoryCode,
            IOperationAuthorityControllable opeAuthCtrlform,
            string assemblyId,
            string programName
        )
        {
            bool canRun = false;
            try
            {
                switch (categoryCode)
                {
                    case EntityUtil.CategoryCode.MasterMaintenance:
                    {
                        opeAuthCtrlform.OperationController = new MasMainController(assemblyId);
                        canRun = ((MasMainController)opeAuthCtrlform.OperationController).CanRun();
                        break;
                    }
                    case EntityUtil.CategoryCode.Report:
                    {
                        opeAuthCtrlform.OperationController = new ReportController(assemblyId);
                        canRun = ((ReportController)opeAuthCtrlform.OperationController).CanRun();
                        break;
                    }
                    case EntityUtil.CategoryCode.Entry:
                    {
                        opeAuthCtrlform.OperationController = new EntryController(assemblyId);
                        canRun = ((EntryController)opeAuthCtrlform.OperationController).CanRun();
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(
                            "対象外のカテゴリーです。：" + categoryCode.ToString()  // LITERAL:
                        );
                }
            }
            catch (InvalidCastException e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }

            if (!canRun) ShowDefaultSecurityAlert();

            opeAuthCtrlform.OperationController.ProgramName = programName;
            return canRun;
        }

        /// <summary>
        /// 指定した機能が起動可能か判定します。
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <returns>
        /// <c>true</c> :起動可能<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        public static bool CanRun(
            EntityUtil.CategoryCode categoryCode,
            string programId
        )
        {
            IOperationAuthority opeAuth = new OperationAuthorityImpl(categoryCode, programId);
            bool canRun = opeAuth.CanRun();
            if (!canRun) ShowDefaultSecurityAlert();
            return canRun;
        }

        #region <アラートメッセージ/>

        /// <summary>
        /// デフォルトのセキュリティアラートメッセージを表示します。
        /// </summary>
        /// <param name="caption">メッセージボックスのキャプション(text)</param>
        public static void ShowDefaultSecurityAlert(string caption)
        {
            MessageBox.Show(CANNOT_RUN_BY_SECURITY_AUTHORITY, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// デフォルトのセキュリティアラートメッセージを表示します。
        /// </summary>
        public static void ShowDefaultSecurityAlert()
        {
            ShowDefaultSecurityAlert(MY_NAME);
        }

        #endregion  // <アラートメッセージ/>

        #region <マスメン/>

        /// <summary>
        /// マスメンの操作権限を生成します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <param name="owner">マスメン機能自身（通常は<c>this</c>を渡して下さい）</param>
        /// <returns>マスメンの操作権限</returns>
        /// <exception cref="ArgumentNullException">プログラムIDが<c>null</c>または空です。</exception>
        public static IOperationAuthority CreateMasterMaintenanceOperationAuthority(
            string programId,
            object owner
        )
        {
            return new OperationAuthorityImpl(EntityUtil.CategoryCode.MasterMaintenance, programId, owner);
        }

        #endregion  // <マスメン/>

        #region <エントリ/>

        /// <summary>
        /// エントリの操作権限を生成します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <param name="owner">エントリ機能自身（通常は<c>this</c>を渡して下さい）</param>
        /// <returns>エントリの操作権限</returns>
        /// <exception cref="ArgumentNullException">プログラムIDが<c>null</c>または空です。</exception>
        public static IOperationAuthority CreateEntryOperationAuthority(
            string programId,
            object owner
        )
        {
            return new OperationAuthorityImpl(EntityUtil.CategoryCode.Entry, programId, owner);
        }

        /// <summary>
        /// 指定したエントリ機能が起動可能か判定します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <returns>
        /// <c>true</c> :起動可能<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        public static bool CanRunEntry(string programId)
        {
            return CanRunEntry(programId, false);
        }

        /// <summary>
        /// 指定したエントリ機能が起動可能か判定します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <param name="withLog">起動したログを出力するフラグ</param>
        /// <returns>
        /// <c>true</c> :起動可能<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        public static bool CanRunEntry(
            string programId,
            bool withLog
        )
        {
            IOperationAuthority opeAuth = CreateEntryOperationAuthority(programId, null);

            if (!opeAuth.CanRun())
            {
                ShowDefaultSecurityAlert();
                return false;
            }

            if (withLog)
            {
                const string METHOD_NAME = "Main";  // LITERAL:
                opeAuth.Logger.WriteOperationLog(METHOD_NAME, (int)EntryFrameOpeCode.Run);
            }

            return true;
        }

        #endregion  // <エントリ/>

        #region <照会/>

        /// <summary>
        /// 照会の操作権限を生成します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <param name="owner">照会機能自身（通常は<c>this</c>を渡して下さい）</param>
        /// <returns>照会の操作権限</returns>
        /// <exception cref="ArgumentNullException">プログラムIDが<c>null</c>または空です。</exception>
        public static IOperationAuthority CreateReferenceOperationAuthority(
            string programId,
            object owner
        )
        {
            return new OperationAuthorityImpl(EntityUtil.CategoryCode.Reference, programId, owner);
        }

        /// <summary>
        /// 指定した照会機能が起動可能か判定します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <returns>
        /// <c>true</c> :起動可能<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        public static bool CanRunReference(string programId)
        {
            return CanRunReference(programId, false);
        }

        /// <summary>
        /// 指定した照会機能が起動可能か判定します。
        /// </summary>
        /// <param name="programId">プログラムID(またはアセンブリID)</param>
        /// <param name="withLog">起動したログを出力するフラグ</param>
        /// <returns>
        /// <c>true</c> :起動可能<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        public static bool CanRunReference(
            string programId,
            bool withLog
        )
        {
            IOperationAuthority opeAuth = CreateReferenceOperationAuthority(programId, null);

            if (!opeAuth.CanRun())
            {
                ShowDefaultSecurityAlert();
                return false;
            }

            if (withLog)
            {
                const string METHOD_NAME = "Main";  // LITERAL:
                opeAuth.Logger.WriteOperationLog(METHOD_NAME, OperationAuthorityImpl.DEFAULT_RUN_OPERATION_CODE);
            }

            return true;
        }

        #endregion  // <照会/>
    }
}
