//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先変換ツール
// プログラム概要   : 商品管理情報マスタの最適化の為、不要なレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/07/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 仕入先変換処理
    /// </summary>
    /// <remarks>
    /// Note       : 仕入先変換処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009/07/13<br />
    /// </remarks>
    public class SupplierChangeAcs
    {
        #region ■ Const Memebers
        private const string PROGRAM_ID = "PMKHN01300U";
        private const string PROGRAM_NAME = "仕入先変換ツール";
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SupplierChangeAcs()
        {
            // 変数初期化
            this.supplierChangeProcDB = SupplierChangeToolDB.GetSupplierChangeProcDB();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 仕入先変換アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>仕入先変換設定アクセスクラス インスタンス</returns>
        public static SupplierChangeAcs GetInstance()
        {
            if (_supplierChangeAcs == null)
            {
                _supplierChangeAcs = new SupplierChangeAcs();
            }

            return _supplierChangeAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static SupplierChangeAcs _supplierChangeAcs;
        ISupplierChangeProcDB supplierChangeProcDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods
        /// <summary>
        /// 仕入先変換処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="readCount">検索件数</param>
        /// <param name="delCount">削除件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 仕入先変換処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.07.13</br>
        /// </remarks>
        public int SupplierChangeProc(string enterpriseCode, out int readCount, out int delCount)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            int status = this.supplierChangeProcDB.DeleteGoodsMng(enterpriseCode, out readCount, out delCount);
            // 正常終了の場合：正常終了しました。 抽出件数：リモートからの抽出件数 削除件数：リモートからの削除件数
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                logStr = "正常終了しました。 抽出件数：" + this.IntConvert(readCount) + " 削除件数：" + this.IntConvert(delCount);
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }
            // エラーの場合：エラーが発生しました。
            else
            {
                logStr = "エラーが発生しました。";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }

            return status;
        }

        /// <summary>
        /// 件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.07.13</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            return searchCount.ToString("N0");
        }
        # endregion

    }
}
