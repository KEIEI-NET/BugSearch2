//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換マスタ変換処理
// プログラム概要   : 条件を満たしたデータをテキストファイルへ出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/02/26  修正内容 : Redmine#44209 メッセージの文言対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 呉軍
// 作 成 日  2015/04/27  修正内容 : レビュー結果対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : リストのNULL、とcountは判断する対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/05/14  修正内容 : メーカーコード、商品中分類コード、ＢＬコードチェックの削除
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 品番変換マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 品番変換マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsChgMstDB : RemoteDB
    {
        #region ■ private Memebers
        //エラー条件メッセージ
        private const string ct_FILE_MSG = "品番変換マスタ取込用のクロスインデックスファイルがありません。" + "\r\n" + "APサーバーにクロスインデックスファイルが配置されているか確認してください。";
        private const string ct_FILE_NODATA = "該当するデータがありません。";
        private const int OF_READWRITE = 2;
        private const int OF_SHARE_DENY_NONE = 0x40;
        private readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        private GoodsNoChangeDB _goodsNoChangeDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        /// <summary>
        /// 品番変換マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsChgMstDB()
            :
            base("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork", "GOODSNOCHANGERF")
        {
            this._goodsNoChangeDB = new GoodsNoChangeDB();
            // --- ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
            // --- ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<
        }


        /// <summary>
        /// 品番変換マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="goodsChangeAllCndWorkWork">検索条件</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="loadCnt">追加件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="dataObjectList">エラーデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int ImportFile(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out Int32 readCnt, out Int32 loadCnt, out Int32 errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string err = string.Empty;
            string workDir = string.Empty;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;
            loadCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;
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
            string fileName = Path.Combine(@workDir, "Log\\Trance_csv\\Cross_Index.csv");

            // ファイルチェック処理
            //if (!CheckInputFile(fileName, out err)) // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            if (!_iGoodsNoChgCommonDB.CheckInputFile(fileName, out err, 0)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            {
                errMsg = err;
                return status;
            }
            bool isReadErr = false;
            // レコード存在チェック処理
            //if (!CheckInputFileDataExists(fileName, out err, out csvDataList, out isReadErr)) // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            if (!_iGoodsNoChgCommonDB.CheckInputFileDataExists(fileName, out err, out csvDataList, out isReadErr)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
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
                        errMsg = ct_FILE_NODATA;
                    }
                }
                return status;
            }

            List<string[]> csvDataInfoList = (List<string[]>)csvDataList;

            ArrayList importGoodsMngWorkList = null;
            // 品番変換マスタのインポートワークの変換処理
            status = ConvertToGoodsMngImportWorkList(cndWork, csvDataInfoList, out importGoodsMngWorkList, out errMsg);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 該当レコードがない場合
                if (importGoodsMngWorkList != null && importGoodsMngWorkList.Count == 0)
                {
                    loadCnt = 0;
                    return status;
                }
                Object objGoodsMngImportWorkList = (object)importGoodsMngWorkList;

                status = this.Import(ref objGoodsMngImportWorkList, out readCnt, out loadCnt, out errCnt, out dataObjectList, out addUpdWorkObj, out errMsg);
            }

            return status;
        }

        #region ファイルチェック処理関する
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
        #region DEL
        ///// <summary>
        ///// ﾃｷｽﾄﾌｧｲﾙ名チェック処理
        ///// </summary>
        ///// <param name="filePath">ファイル名前</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>status</returns>
        ///// <remarks>
        ///// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名チェック処理を行う。(入力チェックなど)</br>
        ///// <br>Programmer : 陳永康</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private bool CheckInputFile(string filePath, out string errMsg)
        //{
        //    bool status = true;
        //    errMsg = string.Empty;
        //    string fileName = filePath.Trim();

        //    try
        //    {
        //        if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
        //        {
        //            errMsg = ct_FILE_MSG;
        //            status = false;
        //            return status;
        //        }

        //        if (!File.Exists(fileName))
        //        {
        //            errMsg = ct_FILE_MSG;
        //            status = false;
        //            return status;
        //        }

        //        IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);
        //        if (vHandle == HFILE_ERROR)
        //        {
        //            errMsg = ct_FILE_MSG;
        //            status = false;
        //            return status;
        //        }
        //        CloseHandle(vHandle);
        //    }
        //    catch
        //    {
        //        errMsg = ct_FILE_MSG;
        //        status = false;
        //        return status;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// ﾃｷｽﾄﾌｧｲﾙ名のレコード存在チェック処理
        ///// </summary>
        ///// <param name="fileName">ファイル名前</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <param name="dataList">データリスト</param>
        ///// <param name="isReadErr">読込エラーかどうか</param>
        ///// <returns>status</returns>
        ///// <remarks>
        ///// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名のレコード存在チェック処理を行う。(入力チェックなど)</br>
        ///// <br>Programmer : 陳永康</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private bool CheckInputFileDataExists(string fileName, out string errMsg, out List<string[]> dataList, out bool isReadErr)
        //{
        //    errMsg = string.Empty;
        //    isReadErr = false;
        //    bool bStatus = true;
        //    dataList = GetCsvData(fileName, out errMsg);
        //    // 読込時にエラーが発生した場合
        //    if (!string.IsNullOrEmpty(errMsg))
        //    {
        //        isReadErr = true;
        //        bStatus = false;
        //    }
        //    return bStatus;
        //}

        ///// <summary>
        ///// CSV情報取得処理
        ///// </summary>
        ///// <param name="fileName">ファイル名前</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>CSV情報</returns>
        ///// <remarks>
        ///// <br>Note       : CSV情報を取得処理する。</br>
        ///// <br>Programmer : 陳永康</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private List<String[]> GetCsvData(String fileName, out string errMsg)
        //{
        //    errMsg = string.Empty;
        //    List<string[]> csvDataList = new List<string[]>();
        //    TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
        //    try
        //    {
        //        using (parser)
        //        {
        //            parser.TextFieldType = FieldType.Delimited;
        //            parser.SetDelimiters(","); // 区切り文字はコンマ
        //            while (!parser.EndOfData)
        //            {
        //                string[] row = parser.ReadFields(); // 1行読み込み
        //                csvDataList.Add(row);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        // なし
        //    }
        //    return csvDataList;

        //}

        ///// <summary>
        ///// _lopen
        ///// </summary>
        ///// <param name="lpPathName"></param>
        ///// <param name="iReadWrite"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        ///// <summary>
        ///// CloseHandle
        ///// </summary>
        ///// <param name="hObject"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //public static extern bool CloseHandle(IntPtr hObject);
        #endregion
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<

        /// <summary>
        /// 品番変換マスタのインポートワークの変換処理
        /// </summary>
        /// <param name="cndWork">条件クラス</param>
        /// <param name="csvDataInfoList"></param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 品番変換マスタのインポートワークの変換処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int ConvertToGoodsMngImportWorkList(GoodsChangeAllCndWorkWork cndWork, List<string[]> csvDataInfoList, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // メーカーリストの取得
            ArrayList makerList = new ArrayList();
            ArrayList makerCodeList = new ArrayList();
            status = this.SearchMakerAll(out makerList, cndWork);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // メーカーコードリストの作成
                if (makerList != null && makerList.Count > 0)
                {
                    makerCodeList = makerList;
                }
            }

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsNoChangeWork work = null;
            try
            {
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsNoChangeWork();

                    if (csvDataArr.Length < 3)
                    {
                        work.CountErrLog = true;
                        int index = 0;
                        work.EnterpriseCode = cndWork.EnterpriseCode;                    // 企業コード
                        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
                        //work.OldGoodsNo = ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // 旧品番
                        //work.NewGoodsNo = ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // 新品番
                        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<
                        // --- ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
                        work.OldGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // 旧品番
                        work.NewGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // 新品番
                        // --- ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<
                        importWorkList.Add(work);
                        continue;
                    }

                    int index2 = 0;
                    int a = 0;
                    work.EnterpriseCode = cndWork.EnterpriseCode;                                 // 企業コード
                    // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
                    //work.OldGoodsNo = ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // 旧品番
                    //work.NewGoodsNo = ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // 新品番
                    //string goodsMakerCd = ConvertToEmpty(csvDataArr, index2++); 　                               // メーカー
                    // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<
                    // --- ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
                    work.OldGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // 旧品番
                    work.NewGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // 新品番
                    string goodsMakerCd = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index2++);
                    // --- ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<
                    if (makerCodeList != null && makerCodeList.Count > 0 && !string.IsNullOrEmpty(goodsMakerCd))
                    {
                        if (int.TryParse(goodsMakerCd.Trim(), out a))
                        {
                            if (makerCodeList.IndexOf(a) < 0)
                            {
                                work.MakerErrLog = true;
                            }
                            work.GoodsMakerCd = a;
                        }
                        work.MakerCdCheck = goodsMakerCd;
                    }
                    else
                    {
                        work.MakerErrLog = true;
                    }

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

        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
        #region DEL
        ///// <summary>
        ///// 空白項目へ変換処理
        ///// </summary>
        ///// <param name="csvDataArr">CSV項目配列</param>
        ///// <param name="index">インデックス</param>
        ///// <returns>変更した項目</returns>
        ///// <remarks>
        ///// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        ///// <br>Programmer : 陳永康</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        //{
        //    string retContent = string.Empty;

        //    if (index < csvDataArr.Length)
        //    {
        //        retContent = csvDataArr[index];
        //    }

        //    return retContent;
        //}
        #endregion
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<

        /// <summary>
        /// 指定された条件のメーカーマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="makerList">検索結果</param>
        /// <param name="cndWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        private int SearchMakerAll( out ArrayList makerList, GoodsChangeAllCndWorkWork cndWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            makerList = null;
             try
            {
                //コネクション生成
                //sqlConnection = CreateSqlConnection(); //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true); //ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                if (sqlConnection == null) return status;
                //sqlConnection.Open(); //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加

                return SearchMakerProc(out makerList, cndWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsChgMstDB.SearchMakerAll");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件のメーカーマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="makerUWorkList">検索結果</param>
        /// <param name="cndWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int SearchMakerProc(out ArrayList makerUWorkList, GoodsChangeAllCndWorkWork cndWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlText = "";
                sqlText += "SELECT " + Environment.NewLine;
                sqlText += " MAKER.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " ,MAKER.LOGICALDELETECODERF " + Environment.NewLine;
                sqlText += " ,MAKER.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += "FROM " + Environment.NewLine;
                sqlText += "  MAKERURF AS MAKER WITH (READUNCOMMITTED)" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                string wkstring = "";
                string retstring = "WHERE " + Environment.NewLine;

                //企業コード
                retstring += "  ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndWork.EnterpriseCode);

                //論理削除区分
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
                if (wkstring != "")
                {
                    retstring += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = 0;
                }

                sqlCommand.CommandText += retstring;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            makerUWorkList = al;

            return status;
        }
        #endregion

        # region [Import]
        /// <summary>
        /// 品番変換マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataList">エラーテーブル用</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int Import(ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 errCnt, out object dataList, out object addUpdWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;
            dataList = null;
            addUpdWorkObj = null;

            try
            {
                //this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB(); //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                // コネクション生成              
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
                if (sqlConnection == null) return status;
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // インポート処理
                status = this.ImportProc(ref importGoodsWorkList, out readCnt, out addCnt, out errCnt, out dataList, out addUpdWorkObj, out errMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    sqlTransaction.Rollback();
                    addCnt = 0;// 追加件数が0になる
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 品番変換マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="importGoodsWorkList">品番変換マスタインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataObjectList">エラーテーブル用</param>
        /// <param name="addUpdWorkObj">登録したデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">コレクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : リストのNULL、とcountは判断する対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/04/29</br>
        /// </remarks>
        private int ImportProc(ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 errCnt, out object dataObjectList, out object addUpdWorkObj, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            readCnt = 0;
            addCnt = 0;
            errCnt = 0;
            dataObjectList = null;
            addUpdWorkObj = null;
            errMsg = string.Empty;

            ArrayList GoodsNoChangeList = new ArrayList();
            GoodsNoChangeWork paraGoodsNoChangeWork = new GoodsNoChangeWork();

            string enterpriseCode = string.Empty;

            try
            {
                // パラメータの設定
                // 品番変換マスタのパラメータの設定
                ArrayList importGoodsWorkArray = importGoodsWorkList as ArrayList;
                if (importGoodsWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    enterpriseCode = ((GoodsNoChangeWork)importGoodsWorkArray[0]).EnterpriseCode;
                    paraGoodsNoChangeWork.EnterpriseCode = enterpriseCode;
                }

                // 全件検索処理を行う
                // 全て品番変換マスタのデータの検索処理
                status = _goodsNoChangeDB.SearchGoodsNoChange(out GoodsNoChangeList, paraGoodsNoChangeWork, 0, ConstantManagement.LogicalMode.GetData01);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status;
                }

                ArrayList secList = new ArrayList();
                // 全件検索結果をDictionaryに格納する
                // 品番変換マスタのDictionaryの作成
                Dictionary<string, GoodsNoChangeWork> OldGoodsNoChangeDict = new Dictionary<string, GoodsNoChangeWork>();
                Dictionary<string, GoodsNoChangeWork> NewGoodsNoChangeDict = new Dictionary<string, GoodsNoChangeWork>();
                foreach (GoodsNoChangeWork work in GoodsNoChangeList)
                {
                    // 旧品番Dictionaryセット
                    string key = work.EnterpriseCode + "-" + work.OldGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!OldGoodsNoChangeDict.ContainsKey(key))
                    {
                        OldGoodsNoChangeDict.Add(key, work);
                    }

                    // 新品番Dictionaryセット
                    string key2 = work.EnterpriseCode + "-" + work.NewGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!NewGoodsNoChangeDict.ContainsKey(key2))
                    {
                        NewGoodsNoChangeDict.Add(key2, work);
                    }

                }

                // 追加と更新データの作成
                // 品番変換マスタの追加リスト
                ArrayList addGoodsNoChangeList = new ArrayList();
                // 品番変換マスタの更新リスト
                ArrayList updGoodsNoChangeList = new ArrayList();

                // 品番変換マスタのエラーtable 
                ArrayList dataErrList = new ArrayList();

                // 品番変換マスタチェック
                ArrayList importCheckWorkList = importGoodsWorkList as ArrayList;
                foreach (GoodsNoChangeWork importWork in importGoodsWorkArray)
                {
                    addGoodsNoChangeList.Add(importWork);
                }

                // 読込件数
                readCnt = importGoodsWorkArray.Count;

                ArrayList addUpdList = new ArrayList();

                if (addGoodsNoChangeList != null && addGoodsNoChangeList.Count > 0)
                {
                    // ＣＳＶレコードチェックOKであれば、追加リストへ追加する。
                    AddUpdListCheck(addGoodsNoChangeList, out addUpdList, ref errCnt, ref dataErrList, OldGoodsNoChangeDict, NewGoodsNoChangeDict);

                    // エラーデータがある場合
                    if (errCnt > 0)
                    {
                        dataObjectList = dataErrList;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }

                    // 品番変換マスタの登録処理
                    for (int i = 0; i < addUpdList.Count; i++ )                 
                    {
                        //GoodsNoChangeWork newGoodsNoChangeWork = (GoodsNoChangeWork)addUpdList[i];// DEL 2015/04/29 時シン リストのNULL、とcountは判断する対応
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------>>>>>
                        GoodsNoChangeWork newGoodsNoChangeWork = null;
                        if (addUpdList != null && addUpdList.Count > 0)
                        {
                            newGoodsNoChangeWork = (GoodsNoChangeWork)addUpdList[i];
                        }
                        //----- ADD 2015/04/29 時シン リストのNULL、とcountは判断する対応------<<<<<
                        status = _goodsNoChangeDB.WriteGoodsNoChangeProc(ref newGoodsNoChangeWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 登録異常が発生する場合、追加件数が0になる
                            addCnt = 0;
                            // 登録異常が発生する場合、エラー件数＋１、ＤＢ登録異常のエラーログセット
                            errCnt = errCnt + 1;
                            SetErrLog(UPDATEERR, newGoodsNoChangeWork, ref dataErrList);
                            break;
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    addCnt = addUpdList.Count;
                    addUpdWorkObj = (object)addUpdList;
                }
                dataObjectList = dataErrList;
          

            }
            catch (SqlException ex)
            {
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region データ取込チェック
        /// <summary>
        /// データ取込をチェックする(エラーと重複チェック)
        /// </summary>
        /// <param name="importWork">データ</param>
        /// <param name="errMsg">メッセージ</param>
        /// <param name="OldGoodsNoChangeDict">変換元品番dictionary</param>
        /// <param name="NewGoodsNoChangeDict">変換先品番dictionary</param>
        /// <param name="oldGoodsNoDic">変換元品番チェック用dictionary</param>
        /// <param name="newGoodsNoDic">変換先品番チェック用dictionary</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : メーカーコード、商品中分類コード、ＢＬコードチェックの削除</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        private bool ImportCheck(GoodsNoChangeWork importWork, out string errMsg, Dictionary<string, GoodsNoChangeWork> OldGoodsNoChangeDict,
             Dictionary<string, GoodsNoChangeWork> NewGoodsNoChangeDict, ref Dictionary<string, string> oldGoodsNoDic, ref Dictionary<string, string> newGoodsNoDic)
        {
            errMsg = string.Empty;
            bool errFlg = false;
            string oldGoodsRepeat = "";
            string newGoodsRepeat = "";
            string oldGoodsNoKey = importWork.OldGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim();
            string newGoodsNoKey = importWork.NewGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim();

            // 重複チェックのDictionaryの作成
            if (!oldGoodsNoDic.ContainsKey(oldGoodsNoKey) && !newGoodsNoDic.ContainsKey(oldGoodsNoKey))
            {
                oldGoodsNoDic.Add(oldGoodsNoKey, oldGoodsNoKey);
            }
            else
            {
                oldGoodsRepeat = ERRMSG_OLDREPEAT;
            }
            if (!newGoodsNoDic.ContainsKey(newGoodsNoKey) && !oldGoodsNoDic.ContainsKey(newGoodsNoKey))
            {
                newGoodsNoDic.Add(newGoodsNoKey, newGoodsNoKey);
            }
            else
            {
                newGoodsRepeat = ERRMSG_NEWREPEAT;
            }

            //項目数チェック
            if (importWork.CountErrLog)
            {
                errFlg = true;
                //errMsg = ERRMSG_COUNTERR; //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errMsg = GoodsNoChgCommonDB.ERRMSG_COUNTERR; //ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }
            
            //旧品番チェック
            string oldGoodsMsg = string.Empty;
            //if (!Check_IsNull("変換元品番", importWork.OldGoodsNo.Trim(), out oldGoodsMsg)) // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            if (!_iGoodsNoChgCommonDB.Check_IsNull("変換元品番", importWork.OldGoodsNo.Trim(), out oldGoodsMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            //else if (!Check_StrUnFixedLen("変換元品番", importWork.OldGoodsNo.Trim(), 24, out oldGoodsMsg))  // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
            //else if (!Check_StrUnFixedLen("変換元品番", importWork.OldGoodsNo.Trim(), 24, out oldGoodsMsg, GOODSNOMODE))  // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応 // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("変換元品番", importWork.OldGoodsNo.Trim(), 24, out oldGoodsMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            else if (!Check_HalfEngNumFixedLength("変換元品番", importWork.OldGoodsNo.Trim(), out oldGoodsMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(oldGoodsMsg))
            {
                errMsg = oldGoodsMsg;
            }

            //新品番チェック
            string newGoodsMsg = string.Empty;
            //if (!Check_IsNull("変換先品番", importWork.NewGoodsNo.Trim(), out newGoodsMsg)) // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            if (!_iGoodsNoChgCommonDB.Check_IsNull("変換先品番", importWork.NewGoodsNo.Trim(), out newGoodsMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            //else if (!Check_StrUnFixedLen("変換先品番", importWork.NewGoodsNo.Trim(), 24, out newGoodsMsg))  // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
            //else if (!Check_StrUnFixedLen("変換先品番", importWork.NewGoodsNo.Trim(), 24, out newGoodsMsg, GOODSNOMODE))  // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応 // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("変換先品番", importWork.NewGoodsNo.Trim(), 24, out newGoodsMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            else if (!Check_HalfEngNumFixedLength("変換先品番", importWork.NewGoodsNo.Trim(), out newGoodsMsg))
                errFlg = true;
            else if (importWork.OldGoodsNo.Trim().Equals(importWork.NewGoodsNo.Trim()))            // 新旧品番が同一のチェック
            {
                newGoodsMsg = ERRMSG_OLDCHGDESTGOODSNO;
                errFlg = true;
            }

            if (errFlg && !string.IsNullOrEmpty(newGoodsMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = newGoodsMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + newGoodsMsg;
                }
            }

            //メーカーチェック
            string makerMsg = string.Empty;
            //if (!Check_IsNull("メーカー", importWork.MakerCdCheck.Trim(), out makerMsg)) // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            if (!_iGoodsNoChgCommonDB.Check_IsNull("メーカー", importWork.MakerCdCheck.Trim(), out makerMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            //else if (!Check_StrUnFixedLen("メーカー", importWork.MakerCdCheck.Trim(), 5, out makerMsg))  // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
            //else if (!Check_StrUnFixedLen("メーカー", importWork.MakerCdCheck.Trim(), 4, out makerMsg, MAKERMODE))  // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応 // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("メーカー", importWork.MakerCdCheck.Trim(), 4, out makerMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            //else if (!IsDigitAdd("メーカー", importWork.MakerCdCheck.Trim(), out makerMsg)) // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("メーカー", importWork.MakerCdCheck.Trim(), out makerMsg)) // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                errFlg = true;
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除------>>>>>
            //else if (importWork.MakerErrLog)
            //{
            //    errFlg = true;
            //    //makerMsg = "メーカー未登録"; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
            //    //makerMsg = ERRMSG_NOTFOUND; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応 //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            //    makerMsg = GoodsNoChgCommonDB.ERRMSG_MAKERNOTFOUND; //ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            //}
            //----- DEL 2015/05/14 時シン メーカーコード、商品中分類コード、ＢＬコードチェックの削除------<<<<<
            else
            {
                importWork.GoodsMakerCd = Convert.ToInt32(importWork.MakerCdCheck);
            }

            if (errFlg && !string.IsNullOrEmpty(makerMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = makerMsg;
                }
                else
                {
                    errMsg = errMsg + "、" + makerMsg;
                }
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }

            // レコードが重複かチェック
            if (!string.IsNullOrEmpty(oldGoodsRepeat))
            {
                errMsg = oldGoodsRepeat;
                return false;
            }
            else if (!string.IsNullOrEmpty(newGoodsRepeat))
            {
                errMsg = newGoodsRepeat;
                return false;
            }

            // 存在チェック
            string key1 = importWork.EnterpriseCode + "-" + importWork.OldGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim().PadLeft(4, '0');
            string key2 = importWork.EnterpriseCode + "-" + importWork.NewGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim().PadLeft(4, '0');
            if (OldGoodsNoChangeDict.ContainsKey(key1) || NewGoodsNoChangeDict.ContainsKey(key1))
            {
                errMsg = ERRMSG_OLDEXISTREPEAT;
                return false;
            }
            else if (OldGoodsNoChangeDict.ContainsKey(key2) || NewGoodsNoChangeDict.ContainsKey(key2))
            {
                errMsg = ERRMSG_NEWEXISTREPEAT;
                return false;
            }

            return true;
        }

        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
        #region DEL
        ///// <summary>
        ///// 整数、長さをチェックする
        ///// </summary>
        ///// <param name="fieldNm">項目名</param>
        ///// <param name="val">値</param>
        ///// <param name="numLen"></param>
        ///// <param name="msg">えらーメッセージ</param>
        ///// <returns></returns>
        //private bool Check_IntAndLen(string fieldNm, string val, int numLen, out string msg)
        //{
        //    msg = string.Empty;
        //    string regex1 = "^[0-9]*[1-9][0-9]*$";
        //    Regex objRegex = new Regex(regex1);
        //    if (!objRegex.IsMatch(val))
        //    {
        //        msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// NULL判断
        ///// </summary>
        ///// <param name="fieldNm">項目名</param>
        ///// <param name="val">値</param>
        ///// <param name="msg">えらーメッセージ</param>
        ///// <returns>メッセージ</returns>
        //private bool Check_IsNull(string fieldNm, string val, out string msg)
        //{
        //    msg = string.Empty;
        //    if (string.IsNullOrEmpty(val.ToString().Trim()))
        //    {
        //        msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 正整数字判断
        ///// </summary>
        ///// <param name="fieldNm">項目名</param>
        ///// <param name="val">値</param>
        ///// <param name="msg">えらーメッセージ</param>
        ///// <returns>メッセージ</returns>
        //private bool IsDigitAdd(string fieldNm, string val, out string msg)
        //{
        //    msg = string.Empty;
        //    string regex1 = "^[0-9]*[1-9][0-9]*$";
        //    Regex objRegex = new Regex(regex1);
        //    if (!objRegex.IsMatch(val))
        //    {
        //        msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 長さを指定しないの文字列チェック
        ///// </summary>
        ///// <param name="fieldNm">項目名</param>
        ///// <param name="val">値</param>
        ///// <param name="len">長さ</param>
        ///// <param name="msg">えらーメッセージ</param>
        ///// <param name="mode">品番又はメーカーのチェック</param>
        ///// <returns>メッセージ</returns>
        ////private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
        //private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg, int mode)// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
        //{
        //    msg = string.Empty;
        //    if (val.Trim().Length > len)
        //    {
        //        //msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm); // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
        //        //----- ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応----->>>>>
        //        if (mode == GOODSNOMODE)
        //        {
        //            msg = string.Format(FORMAT_ERRMSG_LENGOODSNO, fieldNm);
        //        }
        //        else
        //        {
        //            msg = string.Format(FORMAT_ERRMSG_LENMAKER, fieldNm);
        //        }
        //        //----- ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応-----<<<<<
        //        return false;
        //    }
        //    return true;
        //}
        #endregion
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<

        /// <summary>
        /// 半角英数字、符号のチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;

            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm); // DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                msg = string.Format(GoodsNoChgCommonDB.FORMAT_ERRMSG_TYPE, fieldNm); // ADD chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                return false;
            }

        }

        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
        ///// <summary>
        ///// 数値項目へ変換処理
        ///// </summary>
        ///// <param name="str">CSV項目配列</param>
        ///// <returns>変更した数値</returns>
        ///// <remarks>
        ///// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        ///// <br>Programmer : 陳永康</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private Int32 ConvertToInt32(string str)
        //{
        //    Int32 retNum = 0;
        //    try
        //    {
        //        retNum = Convert.ToInt32(str);
        //    }
        //    catch
        //    {
        //        retNum = 0;
        //    }
        //    return retNum;
        //}
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<


        /// <summary>
        /// 品番変換マスタの追加リスト該当のデータが存在するかチェックを行います。
        /// </summary>
        /// <param name="ImportAddUpdList">チェックリスト</param>
        /// <param name="addUpdList">追加リスト</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="dataList">エラーテーブル用</param>
        /// <param name="OldGoodsNoChangeDict">変換元品番dictionary</param>
        /// <param name="NewGoodsNoChangeDict">変換先品番dictionary</param>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref ArrayList dataList, Dictionary<string, GoodsNoChangeWork> OldGoodsNoChangeDict, Dictionary<string, GoodsNoChangeWork> NewGoodsNoChangeDict)
        {
            string message = string.Empty;
            addUpdList = new ArrayList();
            Dictionary<string, string> oldGoodsNoDic = new Dictionary<string, string>();
            Dictionary<string, string> newGoodsNoDic = new Dictionary<string, string>();
            foreach (GoodsNoChangeWork addUpdwork in ImportAddUpdList)
            {
                bool checkRes = ImportCheck(addUpdwork, out message, OldGoodsNoChangeDict, NewGoodsNoChangeDict, ref oldGoodsNoDic, ref newGoodsNoDic);

                if (!checkRes)
                {
                    ConverToDataSetCustomerInf(addUpdwork, message, ref dataList);
                    errCnt++;
                }
                else
                {
                    addUpdList.Add(addUpdwork);
                }
            }
        }
        # endregion

        # region メッセージ
        //----- DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応----->>>>>
        //private const string FORMAT_ERRMSG_LEN = "{0}桁数不正";

        //private const string FORMAT_ERRMSG_TYPE = "{0}不正";

        //private const string FORMAT_ERRMSG_MUSTINPUT = "{0}未設定";

        //private const string ERRMSG_OLDCHGDESTGOODSNO = "変換元変換先品番重複";

        //private const string ERRMSG_COUNTERR = "項目数不正";

        //private const string ERRMSG_NOTFOUND = "未登録";

        //private const string ERRMSG_OLDREPEAT = "変換元品番重複";

        //private const string ERRMSG_NEWREPEAT = "変換先品番重複";

        //private const string ERRMSG_OLDEXISTREPEAT = "変換元品番が既に登録済";

        //private const string ERRMSG_NEWEXISTREPEAT = "変換先品番が既に登録済";

        //private const string UPDATEERR = "品番変換マスタの登録にエラー発生しました";
        //----- DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応-----<<<<<

        //----- ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応----->>>>>
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<
        //private const int MAKERMODE = 0;

        //private const int GOODSNOMODE = 1;

        //private const string FORMAT_ERRMSG_LENGOODSNO = "{0}の桁数が24桁を超えています";

        //private const string FORMAT_ERRMSG_LENMAKER = "{0}の桁数が4桁を超えています";

        //private const string FORMAT_ERRMSG_TYPE = "{0}に不正な文字が含まれています";

        //private const string FORMAT_ERRMSG_MUSTINPUT = "{0}が設定されていません";
        // --- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<

        private const string ERRMSG_OLDCHGDESTGOODSNO = "変換元品番と変換先品番が重複しています";

        //private const string ERRMSG_COUNTERR = "項目数が不正です"; //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加

        //private const string ERRMSG_NOTFOUND = "メーカーがマスタに登録されていません"; //DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加

        private const string ERRMSG_OLDREPEAT = "メーカー＋変換元品番が重複している行が存在します";

        private const string ERRMSG_NEWREPEAT = "メーカー＋変換先品番が重複している行が存在します";

        private const string ERRMSG_OLDEXISTREPEAT = "メーカー＋変換元品番が既に品番変換マスタに登録されています";

        private const string ERRMSG_NEWEXISTREPEAT = "メーカー＋変換先品番が既に品番変換マスタに登録されています";

        //private const string UPDATEERR = "品番変換マスタの登録にエラー発生しました"; // DEL 呉軍 2015/04/27 レビュー結果対応
        private const string UPDATEERR = "品番変換マスタの登録に失敗しました";  // ADD 呉軍 2015/04/27 レビュー結果対応
        //----- ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応-----<<<<<
        # endregion

        #region エラーデータテーブル関する
        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsMng">商品管理データ</param>
        /// <param name="dataList">テープル結果</param>
        ///<param name="message">えらーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsNoChangeWork goodsMng, string message, ref ArrayList dataList)
        {
            GoodsNoChangeWork tempWork = new GoodsNoChangeWork();

            // 旧品番
            tempWork.OldGoodsNo = goodsMng.OldGoodsNo;
            // 新品番
            tempWork.NewGoodsNo = goodsMng.NewGoodsNo;
            // 商品メーカーコード
            tempWork.GoodsMakerCd = goodsMng.GoodsMakerCd;
            tempWork.MakerCdCheck = goodsMng.MakerCdCheck;
            // エラーメッセージ
            tempWork.ErroLogMessage = message;
            dataList.Add(tempWork);
        }
        # endregion

        //--- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 ----->>>>>
        //#region [コネクション生成処理]
        ///// <summary>
        ///// SqlConnection生成処理
        ///// </summary>
        ///// <returns>SqlConnection</returns>
        ///// <remarks>
        ///// <br>Programmer : 陳永康</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private SqlConnection CreateSqlConnection()
        //{
        //    SqlConnection retSqlConnection = null;

        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    if (connectionText == null || connectionText == "") return null;

        //    retSqlConnection = new SqlConnection(connectionText);

        //    return retSqlConnection;
        //}
        //#endregion
        //--- DEL chenyk 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 -----<<<<<

        /// <summary>
        /// エラーログ設定処理
        /// </summary>
        /// <param name="erroLogMessage">エラーメッセージ</param>
        /// <param name="goodsNoChangeWork">商品品番変換情報</param>
        /// <param name="dataErrList">エラーデータリスト</param>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void SetErrLog(string erroLogMessage, GoodsNoChangeWork goodsNoChangeWork, ref ArrayList dataErrList)
        {
            GoodsNoChangeWork tempImportWork = new GoodsNoChangeWork();
            // 旧品番
            tempImportWork.OldGoodsNo = goodsNoChangeWork.OldGoodsNo;
            // 新品番
            tempImportWork.NewGoodsNo = goodsNoChangeWork.NewGoodsNo;
            // 商品メーカーコード
            tempImportWork.GoodsMakerCd = goodsNoChangeWork.GoodsMakerCd;
            // エラーメッセージ
            tempImportWork.ErroLogMessage = erroLogMessage;

            dataErrList.Add(tempImportWork);
        }
    }

        

}
