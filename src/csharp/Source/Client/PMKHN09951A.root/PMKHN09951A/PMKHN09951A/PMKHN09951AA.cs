using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// CSVチェックツール　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: main部</br>
    /// <br>Programmer	: 23006  高橋 明子</br>
    /// <br>Date		: 2014.08.27</br>
    /// </remarks>
    public class PMKHN09951A
    {
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 比較処理
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="dispMsg">メッセージ</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        public int CompareFiles(PMKHN09951A_Common.CSVCheckToolPara param, out bool msgDiv, out string dispMsg)
        {
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;

            try
            {
                status = this.CompareFilesProc(param, out msgDiv, out dispMsg);
            }
            catch (Exception ex)
            {
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
                msgDiv = true;
                dispMsg = "ファイル比較に失敗しました。\r\n\r\n" + ex.Message;
            }

            return (int)status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 比較処理
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="dispMsg">メッセージ</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private ConstantManagement.MethodResult CompareFilesProc(PMKHN09951A_Common.CSVCheckToolPara param, out bool msgDiv, out string dispMsg)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            msgDiv = false;
            dispMsg = String.Empty;

            // 処理クラス　インスタンス化
            ProcClass procClass = new ProcClass();

            try
            {
                DataView mainDV;     // メインDataView（比較基準）
                Dictionary<string, DataView> subDic;     // サブデータDictionary（比較対象のDataView保管用）

                #region ---- パラメータチェック ----
                if (param == null)
                    return status;

                if ((param.PrimaryKeyList == null) || (param.PrimaryKeyList.Count <= 0))
                    return status;
                #endregion

                // 各ファイルの存在チェック
                if (!procClass.CheckFilePathsExists(param, out dispMsg))
                {
                    msgDiv = true;
                    return status;
                }

                // メインCSVファイルのデータ取得
                string headerLine;
                mainDV = procClass.GetMainFileData(param, out headerLine, out dispMsg);
                if (mainDV == null)
                {
                    msgDiv = true;
                    return status;
                }

                // サブCSVファイルのデータ取得
                subDic = procClass.GetSubFileData(param, out dispMsg);
                if (subDic == null)
                {
                    msgDiv = true;
                    return status;
                }

                // 項目数チェック
                if (!procClass.CheckItemsCount(mainDV, subDic))
                {
                    msgDiv = true;
                    dispMsg = "CSVファイル内の項目数が違うため、比較できません。";
                    return status;
                }

                // データ比較
                status = procClass.CompareData(param, mainDV, subDic, headerLine, out msgDiv, out dispMsg);
            }
            finally
            {
                // ログを出力
                procClass.WriteLog(param, dispMsg);
            }

            return status;
            #endregion
        }
    }
}
