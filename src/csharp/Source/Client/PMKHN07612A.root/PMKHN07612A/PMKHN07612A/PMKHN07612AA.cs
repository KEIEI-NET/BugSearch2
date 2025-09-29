//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 結合マスタ（インポート）
// プログラム概要   : 結合マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 結合マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// </remarks>
    public class JoinImportAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 結合マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public JoinImportAcs()
        {
            this._iJoinImportDB = (IJoinImportDB)MediationJoinImportDB.GetJoinImportDB();
        }

        /// <summary>
        /// 結合マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static JoinImportAcs()
        {

        }
        #endregion ■ Constructor

        #region ■ Static Member

        #endregion ■ Static Member

        #region ■ Private Member
        // 結合マスタ（インポート）のリモートインタフェース
        private IJoinImportDB _iJoinImportDB;
        #endregion ■ Private Member

        #region ■ Const Member

        #endregion ■ Const Member

        #region ■ Public Method
        #region ◎ インポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Import(ExtrInfo_JoinImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ 結合マスタ（インポート）のインポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_JoinImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            try
            {
                ArrayList importWorkList = null;
                // インポートワークの変換処理
                status = ConvertToImportWorkList(importWorkTbl, out importWorkList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && importWorkList != null && importWorkList.Count != 0)
                {
                    Object objImportWorkList = (object)importWorkList;
                    // リモートクラスを呼び出す。
                    status = this._iJoinImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    default:
                        break;
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

        #region ◆ データ変換処理
        #region ◎ インポートワークの変換処理
        /// <summary>
        /// インポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : インポートワークの変換処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToImportWorkList(ExtrInfo_JoinImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            JoinPartsUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new JoinPartsUWork();
                    int index = 0;
                    //結合元品番(－付き品番)
                    work.EnterpriseCode = importWorkTbl.EnterpriseCode;

                    //結合元品番(－付き品番)
                    work.JoinSourPartsNoWithH = ConvertToEmpty(csvDataArr, index++);

                    //結合元メーカーコード
                    work.JoinSourceMakerCode = ConvertToInt32(csvDataArr, index++);

                    //結合元品番(－無し品番)
                    work.JoinSourPartsNoNoneH = ConvertToEmpty(csvDataArr, index++);

                    //結合表示順位
                    work.JoinDispOrder = ConvertToInt32(csvDataArr, index++);

                    //結合先品番(－付き品番)
                    work.JoinDestPartsNo = ConvertToEmpty(csvDataArr, index++);

                    //結合先メーカーコード
                    work.JoinDestMakerCd = ConvertToInt32(csvDataArr, index++);

                    //結合QTY
                    work.JoinQty = ConvertToDouble(csvDataArr, index++);

                    //結合規格・特記事項
                    work.JoinSpecialNote = ConvertToEmpty(csvDataArr, index++);

                    importWorkList.Add(work);
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

        #region ◎ 数値項目へ変換処理
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int32 ConvertToInt32(string[] csvDataArr, Int32 index)
        {
            Int32 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt32(csvDataArr[index]);
                }
                catch
                {
                    retNum = 0;
                }
            }
            return retNum;
        }

        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private double ConvertToDouble(string[] csvDataArr, Int32 index)
        {
            double reDouble = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    reDouble = Convert.ToDouble(csvDataArr[index]);
                }
                catch
                {
                    reDouble = 0;
                }
            }

            return reDouble;
        }

        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion
        #endregion

        #endregion ■ Private Method
    }
}
