//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 一括リアル更新
// プログラム概要   : 一括リアル更新アクセスクラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/24  修正内容 : 新規作成
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
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 一括リアル更新処理
    /// </summary>
    /// <remarks>
    /// <br>Note       : 一括リアル更新処理です。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class AllRealUpdToolAcs
    {
        #region ■ Const Memebers
        private const string PROGRAM_ID = "PMKHN09270U";
        private const string PROGRAM_NAME = "一括リアル更新";
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private AllRealUpdToolAcs()
        {
            // 変数初期化
            this._iAllRealUpdToolDB = AllRealUpdToolDB.GetAllRealUpdToolDB();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 一括リアル更新アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>一括リアル更新アクセスクラス インスタンス</returns>
        /// <remarks>		
        /// <br>Note		: 一括リアル更新アクセスクラス インスタンス処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        public static AllRealUpdToolAcs GetInstance()
        {
            if (_allRealUpdToolAcs == null)
            {
                _allRealUpdToolAcs = new AllRealUpdToolAcs();
            }

            return _allRealUpdToolAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static AllRealUpdToolAcs _allRealUpdToolAcs;
        IAllRealUpdToolDB _iAllRealUpdToolDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods
        /// <summary>
        /// 一括リアル更新処理
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">売上ワーク</param>
        /// <param name="mTtlStockUpdParaWork">仕入ワーク</param>
        /// <param name="procDiv">処理区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 一括リアル更新処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        public int AllRealUpdToolProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, MTtlStockUpdParaWork mTtlStockUpdParaWork, int procDiv)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            string procDivStr = string.Empty;
            string sectionSt = string.Empty;
            string sectionEd = string.Empty;
            int status = this._iAllRealUpdToolDB.AllRealUpdProc(mTtlSalesUpdParaWork, mTtlStockUpdParaWork, procDiv);

            // 処理区分
            if (procDiv == 0)
            {
                procDivStr = "売上";
            }
            else if (procDiv == 1)
            {
                procDivStr = "仕入";
            }
            else if (procDiv == 2)
            {
                procDivStr = "売上、仕入";
            }
            else
            {
                // 処理区分不正
            }
            // 拠点
            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt))
            {
                sectionSt = mTtlSalesUpdParaWork.AddUpSecCodeSt;
            }
            else
            {
                sectionSt = "00";
            }

            // 拠点
            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
            {
                sectionEd = mTtlSalesUpdParaWork.AddUpSecCodeEd;
            }
            else
            {
                sectionEd = "99";
            }

            // 正常終了の場合：正常終了しました。
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                logStr = "正常終了しました。 区分：" + procDivStr + " 拠点：" + sectionSt + "～" + sectionEd + " 対象年月："
                    + mTtlSalesUpdParaWork.AddUpYearMonthSt.ToString() + "～" + mTtlSalesUpdParaWork.AddUpYearMonthEd.ToString();

                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }
            // エラーの場合：エラーが発生しました。
            else
            {
                logStr = "エラーが発生しました。（" + status.ToString() + "）  区分：" + procDivStr + " 拠点：" + sectionSt + "～" + sectionEd + " 対象年月："
                    + mTtlSalesUpdParaWork.AddUpYearMonthSt.ToString() + "～" + mTtlSalesUpdParaWork.AddUpYearMonthEd.ToString();
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }

            return status;
        }
        # endregion
    }
}
