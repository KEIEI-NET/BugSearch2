//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期要求管理 アクセスクラス
// プログラム概要   : 同期要求管理 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/08/01   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 同期要求管理 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 同期要求管理 アクセス制御を行います。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class SynchExecuteAcs
    {
        # region ■Private Member
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ISynchExecuteMngDB _iSynchExecuteMngDB;
        # endregion

        # region ■Constracter
        /// <summary>
        /// 同期要求管理 アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 同期要求管理アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchExecuteAcs()
        {
            try
            {
                // リモートオブジェクト取得
                _iSynchExecuteMngDB = (ISynchExecuteMngDB)MediationSynchExecuteMngDB.GetSynchExecuteMngDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                _iSynchExecuteMngDB = null;
            }
        }

        /// <summary>
        /// 最大再試行回数の取得処理
        /// </summary>
        /// <param name="maxRetryCount">最大再試行回数</param>
        /// <remarks>
        /// <br>Note       : 最大再試行回数の取得処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void GetMaxRetryCount(out int maxRetryCount)
        {
            maxRetryCount = 0;

            try
            {
                _iSynchExecuteMngDB.GetMaxRetryCount(out maxRetryCount);
            }
            catch
            {
                maxRetryCount = 0;
            }
        }

        /// <summary>
        /// 指定テーブル同期要求処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableIDList">テーブル名（複数）</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定テーブル同期要求処理。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqExecuteForTable(string enterpriseCode, ArrayList tableIDList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                object param = (object)tableIDList;

                status = _iSynchExecuteMngDB.SyncReqExecuteForTable(enterpriseCode, param);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 同期要求再開処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 同期要求再開処理。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqReExecute()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                status = _iSynchExecuteMngDB.SyncReqReExecute();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }


        /// <summary>
        /// 変換要求処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public void TranslateExecute()
        {
            _iSynchExecuteMngDB.TranslateExecute();
        }

        /// <summary>
        /// 定期起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クライアントに登録される同期処理起動画面から呼び出されます</br>
        /// <br>             オプションが途中から追加になった場合や、初回同期実行後に</br>
        /// <br>             同期実行クラスをInstance化し、同期処理が動作する様にします。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void RegularStart()
        {
            string url = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_PmKvmAP);
            url += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCM_PmKvmAP, ConstantManagement_SF_PRO.IndexCode_SCM_PmKvm_WebPath);

            _iSynchExecuteMngDB.RegularStart(url);
        }
        # endregion
    }
}
