//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日更新
// プログラム概要   : 車検期日更新アクセスクラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
/// Update Note : 2010.05.18 zhangsf Redmine #7772の対応
///             : ・車検期日更新／操作履歴データの更新パターンの追加
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車検期日更新処理
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車検期日更新処理です。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/21</br>
    /// </remarks>
    public class InspectDateUpdAcs
    {
        #region ■ Const Memebers
        private const string PROGRAM_ID = "PMSYA05000U";
        private const string PROGRAM_NAME = "車検期日更新";
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private InspectDateUpdAcs()
        {
            // 変数初期化
            this._iinspectDateUpdDB = MediationInspectDateUpdDB.GetInspectDateUpdDB();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 車検期日更新アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>車検期日更新アクセスクラス インスタンス</returns>
        /// <remarks>		
        /// <br>Note		: 車検期日更新アクセスクラス インスタンス処理を行う。</br>
        /// <br>Programmer	: 王海立</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        public static InspectDateUpdAcs GetInstance()
        {
            if (_inspectDateUpdAcs == null)
            {
                _inspectDateUpdAcs = new InspectDateUpdAcs();
            }

            return _inspectDateUpdAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static InspectDateUpdAcs _inspectDateUpdAcs;
        IInspectDateUpdDB _iinspectDateUpdDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods
        /// <summary>
        /// 車検期日更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateDate">更新年月</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 車検期日更新処理を行う。</br>
        /// <br>Programmer	: 王海立</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        public int InspectDateUpdProc(string enterpriseCode, int updateDate)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            int searchNum;
            int updNum;
            int status = this._iinspectDateUpdDB.InspectDateUpdProc(enterpriseCode, updateDate, out searchNum, out updNum);

            // 正常終了の場合：正常終了しました。
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                // 件数のフォーマットはZZZ,ZZZ,ZZ9
                string searchNumStr = string.Format("{0:N}", searchNum);
                string updNumStr = string.Format("{0:N}", updNum);
                logStr = "正常終了しました。 抽出件数：" + searchNumStr.Substring(0, searchNumStr.Length - 3) + " 更新件数：" + updNumStr.Substring(0, updNumStr.Length - 3);
            }
            // ADD 2010.05.18 zhangsf FOR Redmine #7772 *-------------------->>>
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                logStr = "該当データがありません。";
            }
            // ADD 2010.05.18 zhangsf FOR Redmine #7772 <<<--------------------*
            // エラーの場合：エラーが発生しました。
            else
            {
                logStr = "エラーが発生しました。";
            }

            operationHistoryLog.WriteOperationLog(
                    this,
                    System.DateTime.Now,
                    LogDataKind.SystemLog,
                    PROGRAM_ID,
                    PROGRAM_NAME,
                    string.Empty,
                    0,
                    0,
                    logStr,
                    string.Empty);

            return status;
        }
        # endregion
    }
}
