//****************************************************************************//
// システム         : PM-Tablet
// プログラム名称   : 部品詳細情報検索HTTPハンドラ
// プログラム概要   : 部品詳細情報検索の処理を制御します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00  作成担当 : chenyk
// 作 成 日  2017.11.02   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Runtime.Serialization.Json;
using Broadleaf.Application.Controller;

namespace Broadleaf.Web
{
    /// <summary>
    /// 部品詳細情報検索HTTPハンドラ
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品詳細情報検索の処理を制御します。</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2017.11.02</br>
    /// </remarks>
    public class PartsDetailInfoSearchHTTPHandler : NSJsonHandler
    {
        #region << Private Const >>
        /// <summary>PGID</summary>
        private const string Pgid = "PMTAB08041A";
        /// <summary>HTTPリクエスト処理メソッド名称</summary>
        private const string RequestProcName = "HTTPリクエスト処理";
        /// <summary>HTTPリクエスト処理エラーメッセージ</summary>
        private const string RequestProcErrorMsg = "HTTPリクエスト処理はセットされていません。";
        /// <summary>部品詳細情報有無チェック処理メソッドID</summary>
        private const string CheckProcID = "CheckPartsDetailInfoList";
        /// <summary>部品詳細情報有無チェック処理メソッド名称</summary>
        private const string CheckProcName = "部品詳細情報有無チェック処理";
        /// <summary>部品詳細情報取得処理メソッドID</summary>
        private const string GetProcID = "GetPartsDetailInfoList";
        /// <summary>部品詳細情報取得処理メソッド名称</summary>
        private const string GetProcName = "部品詳細情報取得処理";
        /// <summary>例外エラーメッセージ</summary>
        private const string ExceptionMsg = "{0}にて例外が発生しました。";
        /// <summary>パラメータ不正メッセージ</summary>
        private const string ParamErrorMsg = "パラメータ情報が不正なため、処理を中断します";
        #endregion

        #region << NSJsonHnadler 実装 >>
        /// <summary>
        /// HTTPリクエスト処理
        /// </summary>
        /// <param name="data">パラメータ</param>
        /// <returns>処理結果(true：リクエストを処理した, false：リクエストを処理しなかった)</returns>
        /// <remarks>
        /// <br>Note       : 要求されたHTTPリクエストに対する処理を行います</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        ///</remarks>
        protected override bool ProcessRequest(NSJsonProcessRequestData data)
        {
            // リクエスト処理フラグ
            // 処理結果に関わらず、MethodPathが正しい場合はTrueを返す
            bool isProcessed = true;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errMsg = string.Empty;
            JsonValue resultValue = null;  // 検索結果格納用JsonValue

            string methodPath = string.Empty;

            if (data == null)
            {
                throw new MobileWebException(
                    Pgid
                    ,RequestProcName
                    ,RequestProcErrorMsg
                    ,-1
                    ,null);
            }

            if (!string.IsNullOrEmpty(data.MethodPath))
            {
                methodPath = data.MethodPath;
            }

            try
            {
                JsonObject jsonObject = data.JsonParameter as JsonObject;

                // パラメータチェック処理
                if (!CheckJsonParameterObject(jsonObject, ref data))
                {
                    if (methodPath == CheckProcID || methodPath == GetProcID)
                    {
                        // 処理結果に関わらず、MethodPathが正しい場合はTrueを返す
                        isProcessed = true;
                        return isProcessed;
                    }
                    else
                    {
                        isProcessed = false;
                        return isProcessed;
                    }
                }

                // メソッド名の定義
                #region  MethodPathによる処理分岐
                switch (methodPath)
                {
                    case CheckProcID:　// 部品詳細情報有無チェック処理
                        {
                            #region
                            // 部品詳細情報有無チェック処理
                            isProcessed = true;
                            status = this.CheckPartsDetailInfoListProc(jsonObject, out resultValue, out errMsg);
                            #endregion
                            break;
                        }
                    case GetProcID:　// 部品詳細情報取得処理
                        {
                            #region
                            // 部品詳細情報取得処理
                            isProcessed = true;
                            status = this.GetPartsDetailInfoListProc(jsonObject, out resultValue, out errMsg);
                            #endregion
                            break;
                        }
                    default:
                        isProcessed = false;
                        break;
                }
                #endregion

                if (isProcessed)
                {
                    data.ResponseStatus = status;
                    data.ResponseMessage = errMsg;
                    data.JsonResponse = resultValue;
                }
            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(Pgid, RequestProcName + "(" + methodPath + ")", 
                    string.Format(ExceptionMsg, RequestProcName + "(" + methodPath + ")") + Environment.NewLine + ex.ToString(), -1, ex);
            }

            return isProcessed;
        }

        #endregion

        #region ■JsonObjectチェック処理
        /// <summary>
        /// JsonObjectチェック処理
        /// </summary>
        /// <param name="jsonObject">検索用パラメータ</param>
        /// <param name="data">パラメータ</param>
        /// <returns>チェック結果(True:パラメータ情報あり, False:パラメータ情報なし)</returns>
        /// <remarks>
        /// <br>Note       : JsonObjectチェック処理を行います</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        ///</remarks>
        private bool CheckJsonParameterObject(JsonObject jsonObject, ref NSJsonProcessRequestData data)
        {
            bool isProcess = true;

            if(jsonObject == null)
            {
                data.ResponseStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                data.ResponseMessage = ParamErrorMsg;
                isProcess = false;
            }
            return isProcess;
        }
        #endregion

        #region ■部品詳細情報有無チェック処理(CheckPartsDetailInfoListProc)
        /// <summary>
        /// 部品詳細情報有無チェック処理
        /// </summary>
        /// <param name="jsonObject">検索用パラメータ</param>
        /// <param name="retObj">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note        : 部品詳細情報有無チェック処理を行います</br>
        /// <br>Programmer  : chenyk</br>
        /// <br>Date        : 2017.11.02</br>
        ///</remarks>
        private int CheckPartsDetailInfoListProc(JsonObject jsonObject, out JsonValue retObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            errMsg = string.Empty;

            try
            {
                status = new PartsDetailInfoSearchWebAcs().CheckPartsDetailInfoList(jsonObject, out retObj, out errMsg);
            }
            catch (MobileWebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                throw new MobileWebException(Pgid, CheckProcName, string.Format(ExceptionMsg, CheckProcName), -1, ex);
            }
            return status;
        }
        #endregion

        #region ■部品詳細情報取得処理(GetPartsDetailInfoList)
        /// <summary>
        /// 部品詳細情報取得処理
        /// </summary>
        /// <param name="jsonObject">検索用パラメータ</param>
        /// <param name="retObj">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note        : 部品詳細情報取得処理を行います</br>
        /// <br>Programmer  : chenyk</br>
        /// <br>Date        : 2017.11.02</br>
        ///</remarks>
        private int GetPartsDetailInfoListProc(JsonObject jsonObject, out JsonValue retObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;
            errMsg = string.Empty;

            try
            {
                status = new PartsDetailInfoSearchWebAcs().GetPartsDetailInfoList(jsonObject, out retObj, out errMsg);
            }
            catch (MobileWebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                throw new MobileWebException(Pgid, GetProcName, string.Format(ExceptionMsg, GetProcName), -1, ex);
            }
            return status;
        }
        #endregion
    }
}
