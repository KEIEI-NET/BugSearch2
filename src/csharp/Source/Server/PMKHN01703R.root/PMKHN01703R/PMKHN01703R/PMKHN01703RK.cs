//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業優良設定マスタ変換処理
// プログラム概要   : 条件を満たしたデータを変換する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/16   修正内容 : Redmine#44209 優良設定マスタ変換の仕様変更の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/04/17   修正内容 : Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/27  修正内容 : レビュー結果対応(statusにより判断処理の追加) 
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : リストのNULL、とcountは判断する対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/05/14  修正内容 : メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Data.SqlTypes;
using Microsoft.Win32;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業優良設定マスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 優良設定マスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/02/27</br>
    /// </remarks>
    [Serializable]
    public class MeijiPrmSettingDB : RemoteDB
    {
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        private PrmSettingUDB _iprmSettingUDB;// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応

        #region MeijiPrmSettingDB()
        /// <summary>
        /// 優良設定マスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/02/27</br>
        /// </remarks>
        public MeijiPrmSettingDB()
        {
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
            // 優良設定マスタ既存リモート
            if (this._iprmSettingUDB == null)
            {
                this._iprmSettingUDB = new PrmSettingUDB();
            }
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<
        }
        #endregion

        #region 優良設定マスタの変換処理
        /// <summary>
        /// 優良設定マスタの変換処理
        /// </summary>
        /// <param name="goodsChangeAllCndWorkWork">検索条件</param>
        /// <param name="offerPrmDic">提供分データ</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="loginCnt">更新件数</param>
        /// <param name="sucObjectList">登録したデータ</param>
        /// <param name="errObjectList">エラーデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="csvErr">CSVエラーフラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタの変換処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : Redmine#44209 優良設定マスタ変換の仕様変更の対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/16</br>
        /// </remarks>
        //public int PrmSettingChange(object goodsChangeAllCndWorkWork, out object sucObjectList, out object errObjectList, out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        public int PrmSettingChange(object goodsChangeAllCndWorkWork, Dictionary<string, PrmSettingWork> offerPrmDic, out object sucObjectList, out object errObjectList, // ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応    
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string err = string.Empty;
            string workDir = string.Empty;
            sucObjectList = null;
            errObjectList = null;
            readCnt = 0;
            loginCnt = 0;
            errMsg = string.Empty;
            csvErr = false;

            // ファイルリスト
            List<string[]> csvDataList = new List<string[]>();
            GoodsChangeAllCndWorkWork cndWork = null;

            cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;

            // ファイル名取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // あってはいけないケース
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }
            string fileName = Path.Combine(@workDir, "Log\\Trance_csv\\Cross_Index_PrmSet.csv");

            // ファイルチェック処理
            if (!_iGoodsNoChgCommonDB.CheckInputFile(fileName, out err, 1))
            {
                errMsg = err;
                return status;
            }
            bool isReadErr = false;
            // レコード存在チェック処理
            if (!_iGoodsNoChgCommonDB.CheckInputFileDataExists(fileName, out err, out csvDataList, out isReadErr))
            {
                if (isReadErr)
                {
                    // 読込エラー
                    errMsg = err;
                }
                else
                {
                    if (csvDataList.Count == 0)
                    {
                        // レコードがない
                        errMsg = "該当するデータがありません。";
                    }
                }
                return status;
            }

            List<string[]> csvDataInfoList = (List<string[]>)csvDataList;

            ArrayList prmChangeWorkList = null;

            // CSVレコードリストの作成
            status = ConvertToprmChangeWorkList(cndWork, csvDataInfoList, out prmChangeWorkList, out errMsg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // メーカーで該当レコードがない場合
                if (prmChangeWorkList != null && prmChangeWorkList.Count == 0)
                {
                    return status;
                }

                // 優良設定マスタの変換処理
                //status = this.PrmChange(cndWork, ref prmChangeWorkList, out readCnt, out loginCnt, out sucObjectList, out errObjectList, out errMsg, out csvErr);// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
                status = this.PrmChange(cndWork, offerPrmDic, ref prmChangeWorkList, out readCnt, out loginCnt, out sucObjectList, out errObjectList, out errMsg, out csvErr);// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            }

            return status;
        }


        /// <summary>
        /// 優良設定マスタの変換処理
        /// </summary>
        /// <param name="cndWork">条件ワーク</param>
        /// <param name="offerPrmDic">提供分データ</param>
        /// <param name="prmChangeWorkList">優良設定マスタの変換データリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="loginCnt">更新件数</param>
        /// <param name="errObjectList">エラーテーブル用</param>
        /// <param name="sucObjectList">登録したデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="csvErr"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタの変換処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : Redmine#44209 優良設定マスタ変換の仕様変更の対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/16</br>
        /// <br>Note       : メーカーコード、商品中分類コード、ＢＬコードチェックの削除</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        //private int PrmChange(GoodsChangeAllCndWorkWork cndWork, ref ArrayList prmChangeWorkList, out int readCnt, out int loginCnt, out object sucObjectList, out object errObjectList, out string errMsg, out bool csvErr)// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        private int PrmChange(GoodsChangeAllCndWorkWork cndWork, Dictionary<string, PrmSettingWork> offerPrmDic, ref ArrayList prmChangeWorkList, // ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            out int readCnt, out int loginCnt, out object sucObjectList, out object errObjectList, out string errMsg, out bool csvErr)// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            readCnt = 0;
            loginCnt = 0;
            sucObjectList = null;
            errObjectList = null;
            errMsg = string.Empty;
            csvErr = false;

            // 変換対象リスト
            ArrayList dataTagList = new ArrayList();
            // 登録リスト
            ArrayList dataSucList = new ArrayList();
            // エラーリスト
            ArrayList dataErrList = new ArrayList();
            // ＣＳＶレコードチェック
            //status = PrmChangeListCheck(cndWork, prmChangeWorkList, out dataTagList, ref dataErrList);// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除
            PrmChangeListCheck(cndWork, prmChangeWorkList, out dataTagList, ref dataErrList);// ADD 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除

            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除------>>>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status;
            //}
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除------<<<<<
            // エラーデータがある場合
            //else if (dataErrList.Count > 0)// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除
            if (dataErrList.Count > 0)// ADD 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// ADD 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除
                errObjectList = dataErrList;
                csvErr = true;
                readCnt = prmChangeWorkList.Count;
                return status;
            }

            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                //status = this.ChangePrmSettingProc(dataTagList, out dataSucList, out dataErrList, out readCnt, out loginCnt, ref sqlConnection, ref sqlTransaction);// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
                status = this.ChangePrmSettingProc(dataTagList, offerPrmDic, out dataSucList, out dataErrList, out readCnt, out loginCnt, ref sqlConnection, ref sqlTransaction);// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    sqlTransaction.Rollback();
                    if (dataErrList.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    loginCnt = 0;
                    dataSucList.Clear();
                }

                sucObjectList = dataSucList;
                errObjectList = dataErrList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiPrmSettingDB.PrmChange");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #region CSVレコードリストの作成
        /// <summary>
        /// CSVレコードリストの作成
        /// </summary>
        /// <param name="cndWork">条件クラス</param>
        /// <param name="csvDataInfoList"></param>
        /// <param name="prmChangeWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : CSVレコードリストの作成を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int ConvertToprmChangeWorkList(GoodsChangeAllCndWorkWork cndWork, List<string[]> csvDataInfoList, out ArrayList prmChangeWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            prmChangeWorkList = new ArrayList();
            NewPrmSettingUWork work = null;

            try
            {
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new NewPrmSettingUWork();

                    if (csvDataArr.Length < 6)
                    {
                        work.CountErrLog = true;
                    }

                    int index = 0;
                    work.EnterpriseCode = cndWork.EnterpriseCode;             // 企業コード
                    work.PartsMakerCd = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);  // メーカーコード
                    work.GoodsMGroup = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // 商品中分類コード
                    work.TbsPartsCode = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // BLコード
                    work.PrmSetDtlNo1 = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // セレクトコード
                    work.PrmSetDtlNoAfterOld = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // 旧種別コード
                    work.PrmSetDtlNoAfterNew = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++);   // 新種別コード

                    prmChangeWorkList.Add(work);
                    continue;
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

        #region CSVデータチェック
        /// <summary>
        /// ＣＳＶデータチェックを行う。
        /// </summary>
        /// <param name="cndWork">条件ワーク</param>
        /// <param name="prmChangeWorkList">チェックリスト</param>
        /// <param name="dataTagList">追加リスト</param>
        /// <param name="dataErrList">エラーテーブル用</param>
        /// <remarks>
        /// <br>Note       : ＣＳＶレコードチェックを行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : レビュー結果対応(statusにより判断処理の追加) </br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>Note       : メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        //private int PrmChangeListCheck(GoodsChangeAllCndWorkWork cndWork, ArrayList prmChangeWorkList, out ArrayList dataTagList, ref ArrayList dataErrList)// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除
        private void PrmChangeListCheck(GoodsChangeAllCndWorkWork cndWork, ArrayList prmChangeWorkList, out ArrayList dataTagList, ref ArrayList dataErrList)// ADD 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除    
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_EOF;// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除

            string message = string.Empty;
            dataTagList = new ArrayList();

            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
            //// メーカーDictionary
            //Dictionary<int, string> makerDic = new Dictionary<int, string>();
            //// BLコードDictionary
            //Dictionary<int, string> blCodeDic = new Dictionary<int, string>();
            //// 商品中分類Dictionary
            //Dictionary<int, string> goodsMGroupDic = new Dictionary<int, string>();
            //// メーカー、BLコード、商品中分類の検索
            //status = this.SearchWorkData(out makerDic, out blCodeDic, out goodsMGroupDic, cndWork.EnterpriseCode);

            ////----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //    return status;
            //}
            ////----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<

            // レコード重複チェック用Dictionary
            Dictionary<string, string> repeatOldDic = new Dictionary<string, string>();
            Dictionary<string, string> repeatNewDic = new Dictionary<string, string>();

            foreach (NewPrmSettingUWork newPrmSettingUWork in prmChangeWorkList)
            {
                //bool checkRes = ImportCheck(newPrmSettingUWork, out message, ref repeatOldDic, ref repeatNewDic, makerDic, blCodeDic, goodsMGroupDic);// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除
                bool checkRes = ImportCheck(newPrmSettingUWork, out message, ref repeatOldDic, ref repeatNewDic);// ADD 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除

                if (!checkRes)
                {
                    ConverToNewPrmSettingUWork(newPrmSettingUWork, message, ref dataErrList);
                }
                else
                {
                    dataTagList.Add(newPrmSettingUWork);
                }
            }

            //return status; // DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除
        }

        /// <summary>
        /// データ取込をチェックする(エラーと重複チェック)
        /// </summary>
        /// <param name="prmSettingWork">データ</param>
        /// <param name="errMsg">メッセージ</param>
        /// <param name="repeatOldDic">旧品番の優良設定重複チェック用dictionary</param>
        /// <param name="repeatNewDic">新品番の優良設定重複チェック用dictionary</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// <br>Note       : Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/04/17</br>
        /// <br>Note       : メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
        //private bool ImportCheck(NewPrmSettingUWork prmSettingWork, out string errMsg, ref Dictionary<string, string> repeatOldDic, ref Dictionary<string, string> repeatNewDic,
        //    Dictionary<int, string> makerDic, Dictionary<int, string> blCodeDic, Dictionary<int, string> goodsMGroupDic)
        //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<
        //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
        private bool ImportCheck(NewPrmSettingUWork prmSettingWork, out string errMsg, ref Dictionary<string, string> repeatOldDic, ref Dictionary<string, string> repeatNewDic)
        //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<
        {
            errMsg = string.Empty;
            bool errFlg = false;
            string repeatOldMsg = "";
            string repeatNewMsg = "";
            string repeatDataKey1 = prmSettingWork.PartsMakerCd.Trim().PadLeft(4, '0') + prmSettingWork.GoodsMGroup.Trim().PadLeft(4, '0') +
                prmSettingWork.TbsPartsCode + prmSettingWork.PrmSetDtlNo1 + prmSettingWork.PrmSetDtlNoAfterOld;
            string repeatDataKey2 = prmSettingWork.PartsMakerCd.Trim().PadLeft(4, '0') + prmSettingWork.GoodsMGroup.Trim().PadLeft(4, '0') +
                prmSettingWork.TbsPartsCode + prmSettingWork.PrmSetDtlNo1 + prmSettingWork.PrmSetDtlNoAfterNew;

            // 重複チェックのDictionaryの作成
            if (!repeatOldDic.ContainsKey(repeatDataKey1) && !repeatNewDic.ContainsKey(repeatDataKey1))
            {
                //repeatOldDic.Add(repeatDataKey1, repeatDataKey1); // DEL 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応
            }
            else
            {
                repeatOldMsg = ERRMSG_REPEATOLD;
            }
            if (!repeatNewDic.ContainsKey(repeatDataKey2) && !repeatOldDic.ContainsKey(repeatDataKey2))
            {
                //repeatNewDic.Add(repeatDataKey2, repeatDataKey2); // DEL 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応
            }
            else
            {
                repeatNewMsg = ERRMSG_REPEATNEW;
            }
            //----- ADD 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応------>>>>>
            if (!repeatOldDic.ContainsKey(repeatDataKey1))
            {
                repeatOldDic.Add(repeatDataKey1, repeatDataKey1);
            }
            else
            { 
                // なし
            }
            if (!repeatNewDic.ContainsKey(repeatDataKey2))
            {
                repeatNewDic.Add(repeatDataKey2, repeatDataKey2);
            }
            else
            {
                // なし
            }
            //----- ADD 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応------<<<<<

            //項目数チェック
            if (prmSettingWork.CountErrLog)
            {
                errFlg = true;
                errMsg = GoodsNoChgCommonDB.ERRMSG_COUNTERR;
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }

            //メーカーコードチェック
            string makerMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("メーカー", prmSettingWork.PartsMakerCd.Trim(), out makerMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("メーカー", prmSettingWork.PartsMakerCd.Trim(), 4, out makerMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("メーカー", prmSettingWork.PartsMakerCd.Trim(), out makerMsg))
                errFlg = true;
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
            //else if (!makerDic.ContainsKey(Convert.ToInt32(prmSettingWork.PartsMakerCd.Trim())))
            //{
            //    errFlg = true;
            //    makerMsg = GoodsNoChgCommonDB.ERRMSG_MAKERNOTFOUND;
            //}
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<

            if (errFlg && !string.IsNullOrEmpty(makerMsg))
            {
                errMsg = makerMsg;
            }
            //商品中分類コードチェック
            string goodsMGroupMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("商品中分類", prmSettingWork.GoodsMGroup.Trim(), out goodsMGroupMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("商品中分類", prmSettingWork.GoodsMGroup.Trim(), 4, out goodsMGroupMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("商品中分類", prmSettingWork.GoodsMGroup.Trim(), out goodsMGroupMsg))
                errFlg = true;
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
            //else if (!goodsMGroupDic.ContainsKey(Convert.ToInt32(prmSettingWork.GoodsMGroup.Trim())))
            //{
            //    errFlg = true;
            //    goodsMGroupMsg = ERRMSG_MGROUPNOTFOUND;
            //}
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<
            if (errFlg && !string.IsNullOrEmpty(goodsMGroupMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = goodsMGroupMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + goodsMGroupMsg;
                }
            }
            //ＢＬコードチェック
            string tbsPartsCodeMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("ＢＬコード", prmSettingWork.TbsPartsCode.Trim(), out tbsPartsCodeMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("ＢＬコード", prmSettingWork.TbsPartsCode.Trim(), 5, out tbsPartsCodeMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("ＢＬコード", prmSettingWork.TbsPartsCode.Trim(), out tbsPartsCodeMsg))
                errFlg = true;
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
            //else if (!blCodeDic.ContainsKey(Convert.ToInt32(prmSettingWork.TbsPartsCode.Trim())))
            //{
            //    errFlg = true;
            //    tbsPartsCodeMsg = ERRMSG_BLCODENOTFOUND;
            //}
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<
            if (errFlg && !string.IsNullOrEmpty(tbsPartsCodeMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = tbsPartsCodeMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + tbsPartsCodeMsg;
                }
            }
            //セレクトコードチェック
            string prmSetDtlNoMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("セレクトコード", prmSettingWork.PrmSetDtlNo1.Trim(), out prmSetDtlNoMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("セレクトコード", prmSettingWork.PrmSetDtlNo1.Trim(), 4, out prmSetDtlNoMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAddZero("セレクトコード", prmSettingWork.PrmSetDtlNo1.Trim(), out prmSetDtlNoMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(prmSetDtlNoMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = prmSetDtlNoMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + prmSetDtlNoMsg;
                }
            }
            //旧品番_種別コードチェック
            string prmSetDtlNoOldMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("旧品番の種別コード", prmSettingWork.PrmSetDtlNoAfterOld.Trim(), out prmSetDtlNoOldMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("旧品番の種別コード", prmSettingWork.PrmSetDtlNoAfterOld.Trim(), 4, out prmSetDtlNoOldMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("旧品番の種別コード", prmSettingWork.PrmSetDtlNoAfterOld.Trim(), out prmSetDtlNoOldMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(prmSetDtlNoOldMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = prmSetDtlNoOldMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + prmSetDtlNoOldMsg;
                }
            }
            //新品番_種別コードチェック
            string prmSetDtlNoNewMsg = string.Empty;
            if (!_iGoodsNoChgCommonDB.Check_IsNull("新品番の種別コード", prmSettingWork.PrmSetDtlNoAfterNew.Trim(), out prmSetDtlNoNewMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("新品番の種別コード", prmSettingWork.PrmSetDtlNoAfterNew.Trim(), 4, out prmSetDtlNoNewMsg))
                errFlg = true;
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("新品番の種別コード", prmSettingWork.PrmSetDtlNoAfterNew.Trim(), out prmSetDtlNoNewMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(prmSetDtlNoNewMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = prmSetDtlNoNewMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + prmSetDtlNoNewMsg;
                }
            }

            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }

            // レコードが重複かチェック
            //----- DEL 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応------>>>>>
            //if (!string.IsNullOrEmpty(repeatOldMsg))
            //{
            //    errMsg = repeatOldMsg;
            //    return false;
            //}
            //else if (!string.IsNullOrEmpty(repeatNewMsg))
            //{
            //    errMsg = repeatNewMsg;
            //    return false;
            //}
            //else if (prmSettingWork.PrmSetDtlNoAfterOld.Trim().Equals(prmSettingWork.PrmSetDtlNoAfterNew.Trim()))
            //{
            //    errMsg = ERRMSG_REPEATCODE;
            //    return false;
            //}
            //----- DEL 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応------<<<<<
            //----- ADD 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応------>>>>>
            if (prmSettingWork.PrmSetDtlNoAfterOld.Trim().Equals(prmSettingWork.PrmSetDtlNoAfterNew.Trim()))
            {
                errMsg = ERRMSG_REPEATCODE;
                return false;
            }
            else if (!string.IsNullOrEmpty(repeatOldMsg))
            {
                errMsg = repeatOldMsg;
                return false;
            }
            else if (!string.IsNullOrEmpty(repeatNewMsg))
            {
                errMsg = repeatNewMsg;
                return false;
            }
            //----- ADD 2015/04/17 時シン Redmine#45436 旧品番種別と新品番種別が同一の場合のエラー内容が期待値となっていない対応------<<<<<

            return true;
        }

        #region エラーデータ関する
        //private const string ERRMSG_BLCODENOTFOUND = "ＢＬコードがマスタに登録されていません";// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除
        //private const string ERRMSG_MGROUPNOTFOUND = "商品中分類がマスタに登録されていません";// DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除
        private const string ERRMSG_REPEATOLD = "旧品番の優良設定が重複している行が存在します";
        private const string ERRMSG_REPEATNEW = "新品番の優良設定が重複している行が存在します";
        private const string ERRMSG_REPEATCODE = "旧品番と新品番の優良設定が重複しています";

        /// <summary>
        /// エラーデータの処理
        /// </summary>
        /// <param name="prmSettingWork">商品管理データ</param>
        /// <param name="dataList">テープル結果</param>
        ///<param name="message">えらーメッセージ</param>
        /// <remarks>
        /// <br>Note       : エラーデータの処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void ConverToNewPrmSettingUWork(NewPrmSettingUWork prmSettingWork, string message, ref ArrayList dataList)
        {
            NewPrmSettingUWork tempWork = new NewPrmSettingUWork();

            //部品メーカーコード
            tempWork.PartsMakerCd = prmSettingWork.PartsMakerCd;
            //商品中分類コード
            tempWork.GoodsMGroup = prmSettingWork.GoodsMGroup;
            //ＢＬコード
            tempWork.TbsPartsCode = prmSettingWork.TbsPartsCode;
            //セレクトコード
            tempWork.PrmSetDtlNo1 = prmSettingWork.PrmSetDtlNo1;
            //旧品番_種別コード
            tempWork.PrmSetDtlNoAfterOld = prmSettingWork.PrmSetDtlNoAfterOld;
            //新品番_種別コード
            tempWork.PrmSetDtlNoAfterNew = prmSettingWork.PrmSetDtlNoAfterNew;
            //エラーメッセジー
            tempWork.OutNote = message;

            dataList.Add(tempWork);
        }
        #endregion

        #region 初期Dictionaryの取得
        //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------>>>>>
        ///// <summary>
        ///// 企業コードによって、メーカー、BLコード、商品中分類のDictionary作成
        ///// </summary>
        ///// <param name="makerDic">メーカーのDictionary</param>
        ///// <param name="blCodeDic">ＢＬコードのDictionary</param>
        ///// <param name="goodsMGroupDic">商品中分類のDictionary</param>
        ///// <param name="enterPriseCode">企業コード</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Programmer  : 陳永康</br>
        ///// <br>Date        : 2015/01/26</br>
        ///// <br>Note      　: レビュー結果対応(statusにより判断処理の追加)</br>
        ///// <br>Programmer　: 時シン</br>
        ///// <br>Date        : 2015/04/27</br>
        ///// </remarks>
        //private int SearchWorkData(out Dictionary<int, string> makerDic, out Dictionary<int, string> blCodeDic,
        //    out Dictionary<int, string> goodsMGroupDic, string enterPriseCode)
        //{
        //    // 各マスタのDictionary
        //    makerDic = new Dictionary<int, string>();
        //    blCodeDic = new Dictionary<int, string>();
        //    goodsMGroupDic = new Dictionary<int, string>();

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    // コネクション生成
        //    SqlConnection sqlConnection = null;

        //    try
        //    {
        //        sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

        //        // BLコードマスタ
        //        BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
        //        ArrayList retal = null;
        //        BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
        //        bLGoodsCdUWork.EnterpriseCode = enterPriseCode;
        //        status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
        //        //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            return status;
        //        }
        //        //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
        //        foreach (BLGoodsCdUWork bLGoodsWork in retal)
        //        {
        //            if (!blCodeDic.ContainsKey(bLGoodsWork.BLGoodsCode))
        //            {
        //                blCodeDic.Add(bLGoodsWork.BLGoodsCode, bLGoodsWork.BLGoodsHalfName);
        //            }
        //        }

        //        // メーカーマスタ（ユーザー登録）
        //        MakerUDB makerUDB = new MakerUDB();
        //        retal = null;
        //        MakerUWork makerUWork = new MakerUWork();
        //        makerUWork.EnterpriseCode = enterPriseCode;
        //        status = makerUDB.SearchMakerProc(out retal, makerUWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
        //        //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            return status;
        //        }
        //        //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
        //        foreach (MakerUWork makerWork in retal)
        //        {
        //            if (!makerDic.ContainsKey(makerWork.GoodsMakerCd))
        //            {
        //                makerDic.Add(makerWork.GoodsMakerCd, makerWork.MakerName);
        //            }
        //        }

        //        // 商品中分類マスタ
        //        ArrayList retalRlt = new ArrayList();
        //        GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
        //        retal.Clear();
        //        object retalObj = retal;
        //        GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();
        //        goodsGroupUWork.EnterpriseCode = enterPriseCode;
        //        object goodsGroupUObj = goodsGroupUWork;
        //        status = goodsGroupUDB.Search(ref retalObj, goodsGroupUObj, 0, ConstantManagement.LogicalMode.GetData0);
        //        //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            return status;
        //        }
        //        //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
        //        retalRlt = (ArrayList)retalObj;
        //        foreach (GoodsGroupUWork goodsGroupWork in retalRlt)
        //        {
        //            if (!goodsMGroupDic.ContainsKey(goodsGroupWork.GoodsMGroup))
        //            {
        //                goodsMGroupDic.Add(goodsGroupWork.GoodsMGroup, goodsGroupWork.GoodsMGroupName);
        //            }
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "MeijiGoodsStockDB.SearchWorkDate Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }

        //    return status;
        //}
        //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコード存在チェックの削除------<<<<<
        #endregion

        #endregion

        #region 優良設定マスタ変換処理
        /// <summary>
        /// 優良設定マスタ変換処理(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="prmSettingWorkList">優良設定リスト</param>
        /// <param name="offerPrmDic">提供分データ</param>
        /// <param name="prmSucList">成功リスト</param>
        /// <param name="prmErrList">失敗リスト</param>
        /// <param name="readCntCount">読込件数</param>
        /// <param name="changeCount">更新件数</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : 優良設定マスタ変換処理(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/02/27</br>
        /// <br>Note        : Redmine#44209 優良設定マスタ変換の仕様変更の対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/03/16</br>
        /// <br>Note        : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/17</br>
        //private int ChangePrmSettingProc(ArrayList prmSettingWorkList, out ArrayList prmSucList, out ArrayList prmErrList, out int readCntCount, out int changeCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        private int ChangePrmSettingProc(ArrayList prmSettingWorkList, Dictionary<string, PrmSettingWork> offerPrmDic, out ArrayList prmSucList, // ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            out ArrayList prmErrList, out int readCntCount, out int changeCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection prmConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            // 更新用リスト
            ArrayList prmUWorkSearchList = new ArrayList();
            ArrayList changePrmList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            // 更新結果リスト
            prmSucList = new ArrayList();
            prmErrList = new ArrayList();
            // 読込件数と更新件数
            readCntCount = 0;
            changeCount = 0;

            Dictionary<string, string> csvDic = new Dictionary<string, string>();
            string csvKey = "";
            try
            {
                #region CSVレコードより、更新データの検索処理
                foreach (NewPrmSettingUWork newPrmSettingUWork in prmSettingWorkList)
                {
                    csvKey = newPrmSettingUWork.PartsMakerCd.ToString() + newPrmSettingUWork.GoodsMGroup.ToString() +
                        newPrmSettingUWork.TbsPartsCode.ToString() + newPrmSettingUWork.PrmSetDtlNo1.ToString() + newPrmSettingUWork.PrmSetDtlNoAfterOld.Trim();

                    // 新旧種別コードのDictionary
                    if (!csvDic.ContainsKey(csvKey))
                    {
                        csvDic.Add(csvKey, newPrmSettingUWork.PrmSetDtlNoAfterNew.Trim());
                    }

                    status = SearchProc(newPrmSettingUWork, ref prmUWorkSearchList, prmConnection);

                    // 成功な場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (prmUWorkSearchList != null && prmUWorkSearchList.Count > 0)
                        {
                            //読込件数
                            readCntCount = readCntCount + prmUWorkSearchList.Count;
                            changePrmList.AddRange(prmUWorkSearchList);
                        }
                    }
                    // 異常な場合
                    else
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    prmUWorkSearchList.Clear();
                }
                #endregion

                #region 検索が成功のみの場合、更新処理を実行する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検索されるデータより、優良設定マスタに更新処理
                    foreach (NewPrmSettingUWork prmSetwork in changePrmList)
                    {
                        string message = "";
                        // 優良設定ワークの変換
                        PrmSettingUWork prmSettingUWork;
                        ConvertToPrmSettingUWork(prmSetwork, out prmSettingUWork);

                        // 旧種別の削除
                        deleteWorkList.Add(prmSettingUWork);
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                        try
                        {
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                            status = this._iprmSettingUDB.Delete(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "Delete");
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                        deleteWorkList.Clear();

                        // 削除の場合異常が発生する
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 排他異常が発生する場合
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                message = GoodsNoChgCommonDB.PRMDELETEERR;
                            }
                            // それ以外異常の場合
                            else
                            {
                                message = GoodsNoChgCommonDB.PRMDELETEEX;
                            }
                        }
                        // 削除が正常の場合
                        else
                        {
                            prmSettingUWork.UpdateDateTime = DateTime.MinValue;
                            // 種別コードの変換
                            csvKey = prmSettingUWork.PartsMakerCd.ToString() + prmSettingUWork.GoodsMGroup.ToString() +
                                prmSettingUWork.TbsPartsCode.ToString() + prmSettingUWork.PrmSetDtlNo1.ToString() + prmSetwork.PrmSetDtlNoAfterOld.Trim();

                            if (csvDic.ContainsKey(csvKey))
                            {
                                prmSettingUWork.PrmSetDtlNo2 = Convert.ToInt32(csvDic[csvKey]);
                            }

                            // 種別名称と提供日付の変換
                            csvKey = prmSettingUWork.PartsMakerCd.ToString() + prmSettingUWork.GoodsMGroup.ToString() +
                                prmSettingUWork.TbsPartsCode.ToString() + prmSettingUWork.PrmSetDtlNo1.ToString() + prmSetwork.PrmSetDtlNoAfterNew.Trim();


                            if (offerPrmDic.ContainsKey(csvKey))
                            {
                                prmSettingUWork.PrmSetDtlName2 = offerPrmDic[csvKey].PrmSetDtlName2;
                                prmSettingUWork.OfferDate = offerPrmDic[csvKey].OfferDate;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                message = GoodsNoChgCommonDB.PRMOFFERNOT;
                            }

                            // 提供データが取得する場合、更新を実行する
                            if (string.IsNullOrEmpty(message))
                            {
                                // 優良設定マスタに新品番を追加する
                                insertWorkList.Add(prmSettingUWork);
                                status = WriteProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                insertWorkList.Clear();

                                // 登録時異常が発生する場合
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 排他異常が発生する場合
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                                        || status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                                    {
                                        message = GoodsNoChgCommonDB.PRMINSERTERR;
                                    }
                                    // それ以外異常の場合
                                    else
                                    {
                                        message = GoodsNoChgCommonDB.PRMINSERTEX;
                                    }
                                }
                            }
                        }

                        // ログリストのセット
                        if (string.IsNullOrEmpty(message))
                        {
                            prmSucList.Add(prmSetwork);
                        }
                        else
                        {
                            prmSetwork.OutNote = message;
                            prmErrList.Add(prmSetwork);
                            break;
                        }
                    }

                    // 更新件数
                    if (prmSucList != null && prmSucList.Count > 0)
                    {
                        changeCount = prmSucList.Count;
                    }
                }
                #endregion
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (prmConnection != null)
                {
                    prmConnection.Close();
                    prmConnection.Dispose();
                }
            }

            return status;
        }

        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を追加・更新します。
        /// </summary>
        /// <param name="prmSettingUList">追加・更新する優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を追加・更新します。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/16</br>
        /// <br>Note       : リストのNULL、とcountは判断する対応。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/04/29</br>
        private int WriteProc(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        //PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;// DEL 2015/04/29 時シン リストのNULL、とcountは判断する対応
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        PrmSettingUWork prmSettingUWork = null;
                        if (prmSettingUList != null && prmSettingUList.Count > 0)
                        {
                            prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;
                        }
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                if (prmSettingUWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // 既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PRMSETTINGURF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , MAKERDISPORDERRF=@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += " , PARTSMAKERCDRF=@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += " , PRIMEDISPORDERRF=@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO1RF=@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME1RF=@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO2RF=@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2RF=@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += " , PRIMEDISPLAYCODERF=@PRIMEDISPLAYCODE" + Environment.NewLine;
                            sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2FORFACRF=@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2FORCOWRF=@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (prmSettingUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                            sqlText += "    ,OFFERDATERF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMGROUP" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPLAYCODE" + Environment.NewLine;
                            sqlText += "    ,@OFFERDATE" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraMakerDispOrder = sqlCommand.Parameters.Add("@MAKERDISPORDER", SqlDbType.Int);
                        SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPrimeDispOrder = sqlCommand.Parameters.Add("@PRIMEDISPORDER", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName1 = sqlCommand.Parameters.Add("@PRMSETDTLNAME1", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPrimeDisplayCode = sqlCommand.Parameters.Add("@PRIMEDISPLAYCODE", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2ForFac = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORFACRF", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlName2ForCOw = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORCOWRF", SqlDbType.NVarChar);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(prmSettingUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCdDerivedNo);
                        paraMakerDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.MakerDispOrder);
                        paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        paraPrimeDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDispOrder);
                        paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        paraPrmSetDtlName1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName1);
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
                        paraPrmSetDtlName2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2);
                        if (prmSettingUWork.OfferDate == 0)
                        {
                            paraOfferDate.Value = DBNull.Value;
                        }
                        else
                        {
                            paraOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.OfferDate);
                        }
                        paraPrmSetDtlName2ForFac.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForFac);
                        paraPrmSetDtlName2ForCOw.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForCOw);
                        if (prmSettingUWork.TbsPartsCode == 0)
                        {
                            paraPrimeDisplayCode.Value = 0;
                        }
                        else
                        {
                            paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        }

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            prmSettingUList = al;

            return status;
        }
        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<

        /// <summary>
        /// 優良設定マスタ検索処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="newPrmSettingUWork">条件クラス</param>
        /// <param name="prmUWorkSearchList">検索リスト</param>
        /// <param name="prmConnection">sqlConnection</param>
        /// <returns></returns>
        /// <br>Note        : 優良設定マスタ検索処理</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/02/27</br>
        private int SearchProc(NewPrmSettingUWork newPrmSettingUWork,ref ArrayList prmUWorkSearchList, SqlConnection prmConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = "";

            try
            {
                command += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                command += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                command += "    ,ENTERPRISECODERF" + Environment.NewLine;
                command += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                command += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                command += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                command += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                command += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                command += "    ,SECTIONCODERF" + Environment.NewLine;
                command += "    ,GOODSMGROUPRF" + Environment.NewLine;
                command += "    ,TBSPARTSCODERF" + Environment.NewLine;
                command += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                command += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                command += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                command += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                command += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                command += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                command += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                command += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                command += " FROM PRMSETTINGURF WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += " WHERE" + Environment.NewLine;
                command += " ENTERPRISECODERF   = @FINDENTERPRISECODE" + Environment.NewLine;
                command += " AND LOGICALDELETECODERF  = @FINDLOGICALDELETECODERF" + Environment.NewLine;
                command += " AND GOODSMGROUPRF  = @FINDGOODSMGROUPRF" + Environment.NewLine;
                command += " AND TBSPARTSCODERF = @FINDTBSPARTSCODERF" + Environment.NewLine;
                command += " AND PARTSMAKERCDRF = @FINDPARTSMAKERCDRF" + Environment.NewLine;
                command += " AND PRMSETDTLNO1RF = @FINDPRMSETDTLNO1RF" + Environment.NewLine;
                command += " AND PRMSETDTLNO2RF = @FINDOLDPRMSETDTLNO2RF" + Environment.NewLine;
                command += " ORDER BY SECTIONCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(command, prmConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUPRF", SqlDbType.Int);
                SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODERF", SqlDbType.Int);
                SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCDRF", SqlDbType.Int);
                SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1RF", SqlDbType.Int);
                SqlParameter findParaOldPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDOLDPRMSETDTLNO2RF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(newPrmSettingUWork.EnterpriseCode);
                findParaLogicalDeleteCode.Value = 0;
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.GoodsMGroup.Trim()));
                findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.TbsPartsCode.Trim()));
                findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.PartsMakerCd.Trim()));
                findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.PrmSetDtlNo1.Trim()));
                findParaOldPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newPrmSettingUWork.PrmSetDtlNoAfterOld.Trim()));

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    prmUWorkSearchList.Add(CopyToNewPrmSettingUWork(ref myReader, newPrmSettingUWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            catch (SqlException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → NewPrmSettingUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="newPrmSettingUWork">NewPrmSettingUWork</param>
        /// <returns>NewPrmSettingUWork</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private NewPrmSettingUWork CopyToNewPrmSettingUWork(ref SqlDataReader myReader, NewPrmSettingUWork newPrmSettingUWork)
        {
            NewPrmSettingUWork _newPrmSettingUWork = new NewPrmSettingUWork();

            #region クラスへ格納
            _newPrmSettingUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            _newPrmSettingUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            _newPrmSettingUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _newPrmSettingUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            _newPrmSettingUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            _newPrmSettingUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            _newPrmSettingUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            _newPrmSettingUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            _newPrmSettingUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            _newPrmSettingUWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF")).ToString();
            _newPrmSettingUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF")).ToString();
            _newPrmSettingUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
            _newPrmSettingUWork.MakerDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERDISPORDERRF"));
            _newPrmSettingUWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF")).ToString();
            _newPrmSettingUWork.PrimeDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPORDERRF"));
            _newPrmSettingUWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF")).ToString();
            _newPrmSettingUWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
            _newPrmSettingUWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
            _newPrmSettingUWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
            _newPrmSettingUWork.PrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPLAYCODERF"));
            _newPrmSettingUWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
            _newPrmSettingUWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
            _newPrmSettingUWork.PrmSetDtlNoAfterOld = newPrmSettingUWork.PrmSetDtlNoAfterOld;
            _newPrmSettingUWork.PrmSetDtlNoAfterNew = newPrmSettingUWork.PrmSetDtlNoAfterNew;
            #endregion

            return _newPrmSettingUWork;
        }
        #endregion

        #region ワークの変換
        /// <summary>
        /// クラス格納処理 PrmSettingUWork
        /// </summary>
        /// <param name="newPrmSettingUWork1">優良設定ワーク</param>
        /// <param name="prmSettingUWork">PrmSettingUWorkワーク</param>
        /// <br>Note        : クラス格納処理 PrmSettingUWork</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/02/27</br>
        private void ConvertToPrmSettingUWork(NewPrmSettingUWork newPrmSettingUWork1, out PrmSettingUWork prmSettingUWork)
        {
            prmSettingUWork = new PrmSettingUWork();

            prmSettingUWork.CreateDateTime = newPrmSettingUWork1.CreateDateTime;
            prmSettingUWork.UpdateDateTime = newPrmSettingUWork1.UpdateDateTime;
            prmSettingUWork.EnterpriseCode = newPrmSettingUWork1.EnterpriseCode;
            prmSettingUWork.FileHeaderGuid = newPrmSettingUWork1.FileHeaderGuid;
            prmSettingUWork.UpdEmployeeCode = newPrmSettingUWork1.UpdEmployeeCode;
            prmSettingUWork.UpdAssemblyId1 = newPrmSettingUWork1.UpdAssemblyId1;
            prmSettingUWork.UpdAssemblyId2 = newPrmSettingUWork1.UpdAssemblyId2;
            prmSettingUWork.LogicalDeleteCode = newPrmSettingUWork1.LogicalDeleteCode;
            prmSettingUWork.SectionCode = newPrmSettingUWork1.SectionCode;
            prmSettingUWork.GoodsMGroup = Convert.ToInt32(newPrmSettingUWork1.GoodsMGroup);
            prmSettingUWork.TbsPartsCode = Convert.ToInt32(newPrmSettingUWork1.TbsPartsCode);
            prmSettingUWork.TbsPartsCdDerivedNo = newPrmSettingUWork1.TbsPartsCdDerivedNo;
            prmSettingUWork.MakerDispOrder = newPrmSettingUWork1.MakerDispOrder;
            prmSettingUWork.PartsMakerCd = Convert.ToInt32(newPrmSettingUWork1.PartsMakerCd);
            prmSettingUWork.PrimeDispOrder = newPrmSettingUWork1.PrimeDispOrder;
            prmSettingUWork.PrmSetDtlNo1 = Convert.ToInt32(newPrmSettingUWork1.PrmSetDtlNo1);
            prmSettingUWork.PrmSetDtlName1 = newPrmSettingUWork1.PrmSetDtlName1;
            prmSettingUWork.PrmSetDtlNo2 = newPrmSettingUWork1.PrmSetDtlNo2;
            prmSettingUWork.PrmSetDtlName2 = newPrmSettingUWork1.PrmSetDtlName2;
            prmSettingUWork.PrimeDisplayCode = newPrmSettingUWork1.PrimeDisplayCode;
            prmSettingUWork.PrmSetDtlName2ForFac = newPrmSettingUWork1.PrmSetDtlName2ForFac;
            prmSettingUWork.PrmSetDtlName2ForCOw = newPrmSettingUWork1.PrmSetDtlName2ForCOw;
        }
        #endregion

        #endregion
    }
}