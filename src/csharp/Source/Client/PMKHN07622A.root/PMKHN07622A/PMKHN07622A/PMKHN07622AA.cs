//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TBO検索マスタ（インポート）
// プログラム概要   : TBO検索マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
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
using System.Text.RegularExpressions;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TBO検索マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// </remarks>
    public class TBOSearchUImportAcs
    {
        #region ■ Constructor
		/// <summary>
        /// TBO検索マスタ（インポート）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : TBO検索マスタ（インポート）アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 劉学智</br>
	    /// <br>Date       : 2009.05.13</br>
		/// </remarks>
		public TBOSearchUImportAcs()
		{
            this._iTBOSearchUImportDB = (ITBOSearchUImportDB)MediationTBOSearchUImportDB.GetTBOSearchUImportDB();
        }

		/// <summary>
        /// TBO検索マスタ（インポート）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : TBO検索マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static TBOSearchUImportAcs()
		{
		}
		#endregion ■ Constructor

        #region ■ Private Member
        // TBO検索マスタ（インポート）のリモートインタフェース
        private ITBOSearchUImportDB _iTBOSearchUImportDB;
        #endregion ■ Private Member

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
        /// <br>Note       : TBO検索マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Import(ExtrInfo_TBOSearchUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ TBO検索マスタ（インポート）のインポート処理
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
        /// <br>Note       : TBO検索マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ImportProc(ExtrInfo_TBOSearchUImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
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
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    Object objImportWorkList = (object)importWorkList;
                    // リモートクラスを呼び出す。
                    status = this._iTBOSearchUImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToImportWorkList(ExtrInfo_TBOSearchUImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            TBOSearchUWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new TBOSearchUWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.EquipGenreCode = ConvertToInt32(csvDataArr, index++);          // 装備分類
                    work.EquipName = ConvertToEmpty(csvDataArr, index++);               // 装備名
                    work.CarInfoJoinDispOrder = ConvertToInt32(csvDataArr, index++);    // 表示順
                    work.JoinDestPartsNo = ConvertToEmpty(csvDataArr, index++);         // 品番
                    work.JoinDestMakerCd = ConvertToInt32(csvDataArr, index++);         // メーカー
                    work.BLGoodsCode = ConvertToInt32(csvDataArr, index++);             // ＢＬコード
                    work.JoinQty = ConvertToDouble(csvDataArr, index++);                // ＱＴＹ
                    work.EquipSpecialNote = ConvertToEmpty(csvDataArr, index++);        // 装備規格・特記事項

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
        /// <br>Programmer : 劉学智</br>
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
        #endregion

        #region ◎ 空白項目へ変換処理
        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
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
