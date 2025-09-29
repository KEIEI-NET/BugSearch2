//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 表示区分マスタ（印刷）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタ（印刷）で使用するデータを取得する。</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>管理番号   : 10801804-00</br>
    /// </remarks>
    public class PartsPosCodePrintReportAcs
    {
        #region ■ Private Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			                // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // 帳票出力設定アクセスクラス
        #endregion

        #region ■ Constructor
        /// <summary>
        /// 表示区分マスタ（印刷）印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示区分マスタ（印刷）印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public PartsPosCodePrintReportAcs()
        {
        }

        /// <summary>
        /// 表示区分マスタ（印刷）印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示区分マスタ（印刷）印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        static PartsPosCodePrintReportAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス


            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }
        #endregion ■ Constructor

        #region ■ Private Method
        #region ◆ 帳票設定データ取得
        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票設定データ取得
        #endregion ■ Private Method
    }
}
