//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : 決済手形消込処理アクセスクラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
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
    /// 決済手形消込処理
    /// </summary>
    /// <remarks>
    /// <br>Note       : 決済手形消込の処理を行う。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class SettlementBillDelAcs
    {
        #region ■ Const Memebers
        private const string PROGRAM_ID = "PMTEG05103A";
        private const string PROGRAM_NAME = "決済手形消込処理";
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SettlementBillDelAcs()
        {
            // 変数初期化
            this._isettlementBillDelDB = MediationSettlementBillDelDB.GetSettlementBillDelDB();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 決済手形消込処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>決済手形消込処理アクセスクラス インスタンス</returns>
        /// <remarks>		
        /// <br>Note		: 決済手形消込処理アクセスクラス インスタンス処理を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public static SettlementBillDelAcs GetInstance()
        {
            if (_settlementBillDelAcs == null)
            {
                _settlementBillDelAcs = new SettlementBillDelAcs();
            }

            return _settlementBillDelAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static SettlementBillDelAcs _settlementBillDelAcs;
        ISettlementBillDelDB _isettlementBillDelDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods

        /// <summary>
        /// 決済手形消込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="processDate">処理日</param>
        /// <param name="prevTotalMonth">前回締処理月</param>
        /// <param name="billDiv">手形区分0:受取手形;1:支払手形</param>
        /// <param name="pieceDelete">削除件数</param>
        /// <param name="totalpiece">抽出件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 決済手形消込処理を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public int SettlementBillDelProc(string enterpriseCode, int processDate, int prevTotalMonth, int billDiv, out int pieceDelete, out int totalpiece)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            int status = this._isettlementBillDelDB.SettlementBillDelProc(enterpriseCode, processDate, prevTotalMonth, billDiv, out pieceDelete, out totalpiece);

            // 正常終了の場合：正常終了しました。
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                // 件数のフォーマットはZZZ,ZZZ,ZZ9
                string totalpieceStr = string.Format("{0:N}", totalpiece);
                string pieceDeleteStr = string.Format("{0:N}", pieceDelete);
                logStr = "正常終了しました、抽出件数：" + totalpieceStr.Substring(0, totalpieceStr.Length - 3) + " 削除件数：" + pieceDeleteStr.Substring(0, pieceDeleteStr.Length - 3);
            }
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
