//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供データ削除処理アクセスクラス
// プログラム概要   : データセンターに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 提供データ削除処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : 提供データ削除処理です。<br />
    /// Programmer : 呉元嘯<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public class OfferDataDeleteAcs
    {
        # region ■ Constructor ■
        /// <summary>
        /// 提供データ削除処理アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 提供データ削除処理アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public OfferDataDeleteAcs()
        {
        }
        # endregion ■ Constructor ■

        #region ■ Const Memebers ■
        // 画面機能ID
        private const string PROGRAM_ID = "PMKHN01100UA";
        // 画面機能名称
        private const string PROGRAM_NAME = "提供データ削除処理";
        #endregion ■ Const Memebers ■

        # region ■ Private Members ■

        // 提供削除対象定義情報(Remote)
        private OfferDataDeleteWork _offerDataDeleteWork;
        // 提供データ削除処理インタフェース
        private IOfferDataDeleteDB _iOfferDataDeleteDB;
        // データクリア処理インタフェース
        private IDataClearDB _iDataClearDB;
        // 提供削除対象定義情報
        private OfferData _offerDataObj;

        # endregion ■ Private Members ■

        #region ■ Private Method
        #region ■ 提供データ削除処理
        #region ◎ データ削除処理
        /// <summary>
        /// 提供データ削除処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public int Delete(out string errMsg)
        {
            return this.DeleteProc(out errMsg);
        }

        /// <summary>
        ///提供データ削除処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private int DeleteProc(out string errMsg)
        {
            // 全てテーブル処理後の状態
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 変数初期化
            this._offerDataObj = new OfferData();
            this._offerDataDeleteWork = new OfferDataDeleteWork();

            // 提供削除対象定義情報取得
            ArrayList _offerDataList = new ArrayList();
            _offerDataList = _offerDataObj.GetOfferDataList();

            // 操作履歴ログ定義
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            // 提供データ削除処理インタフェース
            _iOfferDataDeleteDB = (IOfferDataDeleteDB)MediationOfferDataDeleteDB.GetOfferDataDeleteDB();

            // データクリア処理インタフェース
            _iDataClearDB = (IDataClearDB)MediationDataClearDB.GetDataClearDB();

            errMsg = string.Empty;
            // Remote削除処理
            // 処理コード＝0：無条件クリア
            try
            {
                object _offerDataListObj = _offerDataList as object;
                int subStatus0 = _iOfferDataDeleteDB.DeleteOfferData(ref _offerDataListObj);
                // 処理コード＝9：データクリア処理対象
                int subStatus9 = _iDataClearDB.ClearDataByCode9(LoginInfoAcquisition.EnterpriseCode);
                // サーバーのレジストリ更新処理
                int regeditStatus = _iOfferDataDeleteDB.ServerRegeditUpdate();

                // 処理コード＝0のテーブル削除処理失敗
                if (subStatus0 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (OfferDataDeleteWork _offerDataDeleteWork in _offerDataListObj as ArrayList)
                    {
                        if (_offerDataDeleteWork.Result.Equals("NG"))
                        {
                            // エラーとなった場合、操作履歴ログ書き込み
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, _offerDataDeleteWork.TableName + " 提供削除処理 エラー", string.Empty);

                        }
                    }
                }

                // 価格改正更新履歴データ更新処理失敗
                if (subStatus9 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // サーバーのレジストリ更新処理失敗、ログを書きこむ。
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "価格改正更新履歴データ 提供削除処理 エラー", string.Empty);
                }

                // サーバーのレジストリ更新処理失敗
                if (regeditStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // サーバーのレジストリ更新処理失敗、ログを書きこむ。
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "現在提供バージョン 初期化 エラー", string.Empty);
                }

                // １テーブルもエラーがなく、かつレジストリ更新もエラーにならなかった場合
                if (subStatus0 == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    subStatus9 == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    regeditStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 正常終了した旨、１件のログを書きこむ。
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "提供削除処理 正常終了", string.Empty);
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        #endregion ◆ 提供データ削除処理
        #endregion ■ Private Method
    }
}
