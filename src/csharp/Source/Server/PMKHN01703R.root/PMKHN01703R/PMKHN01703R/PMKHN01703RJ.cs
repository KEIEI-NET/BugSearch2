//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換処理共通
// プログラム概要   : 品番変換エラーデータの追加と削除
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
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/03/20  修正内容 : Redmine#44209 ファイルチェックの対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/07  修正内容 : Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/29  修正内容 : Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応
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
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Collections;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業品番変換処理共通DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 品番変換処理共通の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class GoodsNoChgCommonDB : RemoteDB
    {
        # region Const Member
        /// <summary>
        ///  商品在庫マスタ
        /// </summary>
        public static int GOODSMST = 1;
        /// <summary>
        ///  商品管理情報マスタ
        /// </summary>
        public static int GOODSMNGMST = 2;
        /// <summary>
        ///  掛率マスタ
        /// </summary>
        public static int RATEMST = 3;
        /// <summary>
        ///  結合マスタ
        /// </summary>
        public static int JOINMST = 4;
        /// <summary>
        ///  代替マスタ
        /// </summary>
        public static int PARTSMST = 5;
        /// <summary>
        ///  セットマスタ
        /// </summary>
        public static int SETMST = 6;
        # endregion

        //----- ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応----->>>>>
        #region メッセージ
        /// <summary>
        /// 論理削除チェックメッセージ
        /// </summary>
        public static string DELETEMSG = "論理削除データ";
        /// <summary>
        /// 排他チェックメッセージ
        /// </summary>
        public static string EXISTMSG = "変換先品番が既に{0}に登録されています";
        /// <summary>
        /// 変換元異常エラーの場合
        /// </summary>
        public static string OLDEXCEPTIONMSG = "変換元品番の削除に失敗しました";
        /// <summary>
        /// 変換先異常エラーの場合
        /// </summary>
        public static string NEWEXCEPTIONMSG = "変換先品番の登録に失敗しました";
        /// <summary>
        /// 不整合データがある場合
        /// </summary>
        public static string UNNORMALDATA = "商品マスタが存在しない為、当該品番処理できませんでした";
        /// <summary>
        /// 同じ品番、価格マスタ、在庫マスタエラーが発生する場合
        /// </summary>
        public static string GOODSMSTERRMSG2 = "同一品番の{0}で変換エラーが発生した為、処理できませんでした";
        /// <summary>
        /// 更新失敗の場合
        /// </summary>
        public static string UPDATEFAIL = "他のユーザーにより変換元品番の{0}が更新された為、変換元品番を削除できませんでした";
        /// <summary>
        /// 商品マスタ、価格マスタ、在庫マスタエラーが発生する場合
        /// </summary>
        public static string GOODSMSTERRMSG = "{0}変換でエラーが発生した為、処理できませんでした。{0}のエラーログを確認して下さい";
        /// <summary>
        /// 貸出変換異常エラーの場合
        /// </summary>
        public static string RENTEXCEPTIONMSG = "未計上貸出データの品番変換に失敗しました";
        /// <summary>
        /// 貸出変換排他エラーの場合
        /// </summary>
        public static string RENTUPDATEFAIL = "他のユーザーにより未計上貸出データが更新された為、未計上貸出データの品番を変換できませんでした";
        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
        /// <summary>
        /// 旧品番の優良設定マスタ削除に排他エラーの場合
        /// </summary>
        public static string PRMDELETEERR = "他のユーザーにより旧品番の優良設定マスタが更新された為、優良設定マスタを変換できませんでした";
        /// <summary>
        /// 旧品番の優良設定マスタ登録に排他以外エラーの場合
        /// </summary>
        public static string PRMDELETEEX = "旧品番の優良設定マスタ削除に失敗しました";
        /// <summary>
        /// 新品番の優良設定マスタ登録に排他エラーの場合
        /// </summary>
        public static string PRMINSERTERR = "新品番の優良設定マスタが既に優良設定マスタに登録されています";
        /// <summary>
        /// 新品番の優良設定マスタ更新登録に排他以外エラーの場合
        /// </summary>
        public static string PRMINSERTEX = "新品番の優良設定マスタ登録に失敗しました";
        /// <summary>
        /// 提供情報が存在しない場合
        /// </summary>
        public static string PRMOFFERNOT = "提供情報が存在しなかった為、処理できませんでした";
        //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------>>>>>
        /// <summary>
        /// 結合マスタ変換時、結合元と結合先の品番が同一の場合
        /// </summary>
        public static string REPEATJOINMSG = "変換後の結合元品番と結合先品番が同一です";
        /// <summary>
        /// 代替マスタ変換時、代替元と代替先の品番が同一の場合
        /// </summary>
        public static string REPEATPARTSMSG = "変換後の代替元品番と代替先品番が同一です";
        /// <summary>
        /// セットマスタ変換時、親品番と子品番が同一の場合
        /// </summary>
        public static string REPEATSETMSG = "変換後の親品番と子品番が同一です";
        //----- ADD 2015/04/07 時シン Redmine#44209 変換後の元品番と先品番が同一の場合はエラーとする対応------<<<<<
        //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------>>>>>
        /// <summary>
        /// 表示順位採番後、番号が50超える場合
        /// </summary>
        public static string DISPORDEROVERNUMBER = "表示順位の採番に失敗しました。順位が50を超えています";
        //----- ADD 2015/04/29 時シン Redmine#45436 表示順位採番後、番号が50超える場合、エラーとして、ログに出力する対応------<<<<<
        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<
        #endregion
        //----- ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応-----<<<<<

        #region GoodsNoChgCommonDB
        /// <summary>
        /// 売上データテキストコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public GoodsNoChgCommonDB()
        {

        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection返す
            return retSqlConnection;
        }
        #endregion  //コネクション生成処理

        #region [SqlTransaction生成処理]
        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        #endregion  //SqlTransaction生成処理

        #region 品番変換エラーデータを物理削除
        /// <summary>
        /// 品番変換エラーデータを物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="deleteDiv">削除区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : 品番変換エラーデータを物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        public int DeleteGoodsNoChangeErrorDataProc(string enterPriseCode, int deleteDiv, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                sqlTxt = "";
                sqlTxt += "DELETE" + Environment.NewLine;
                sqlTxt += "FROM GOODSNOCHANGEERRDTRF" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " AND MASTERDIVCDRF=@FINDMASTERDIVCDRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlTxt;

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMasterDivCd = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);

                //KEYコマンドを再設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(deleteDiv);

                //if (deleteDiv == GOODSMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(GOODSMST);
                //}
                //else if (deleteDiv == GOODSMNGMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(GOODSMNGMST);
                //}
                //else if (deleteDiv == STOCKMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(STOCKMST);
                //}
                //else if (deleteDiv == RATEMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(RATEMST);
                //}
                //else if (deleteDiv == JOINMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(JOINMST);
                //}
                //else if (deleteDiv == PARTSMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(PARTSMST);
                //}
                //else if (deleteDiv == SETMST)
                //{
                //    findParaMasterDivCd.Value = SqlDataMediator.SqlSetInt32(SETMST);
                //}
                //else
                //{ 
                //    // なし
                //}

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region 品番変換エラーデータを登録
        /// <summary>
        /// 品番変換エラーデータを登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeErrorDataWorkDic">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 品番変換エラーデータを登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        public int WriteGoodsNoChangeErrorDataProc(Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChangeErrorDataWorkDic, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";
                foreach (string goodsNoChgKey in goodsNoChangeErrorDataWorkDic.Keys)
                {
                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = goodsNoChangeErrorDataWorkDic[goodsNoChgKey];
                    sqlTxt = "" + Environment.NewLine;
                    sqlTxt += "INSERT INTO GOODSNOCHANGEERRDTRF" + Environment.NewLine;
                    sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "  ,MASTERDIVCDRF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "  ,CHGSRCGOODSNORF" + Environment.NewLine;
                    sqlTxt += "  ,CHGDESTGOODSNORF" + Environment.NewLine;
                    sqlTxt += "  )" + Environment.NewLine;
                    sqlTxt += "VALUES" + Environment.NewLine;
                    sqlTxt += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "  ,@MASTERDIVCD" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  ,@CHGSRCGOODSNO" + Environment.NewLine;
                    sqlTxt += "  ,@CHGDESTGOODSNO" + Environment.NewLine;
                    sqlTxt += "  )" + Environment.NewLine;

                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = sqlTxt;
                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsNoChangeErrorDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraMasterDivCd = sqlCommand.Parameters.Add("@MASTERDIVCD", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraChgDestGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeErrorDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeErrorDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsNoChangeErrorDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeErrorDataWork.LogicalDeleteCode);
                    paraMasterDivCd.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeErrorDataWork.MasterDivCd);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeErrorDataWork.GoodsMakerCd);
                    paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.ChgSrcGoodsNo);
                    paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeErrorDataWork.ChgDestGoodsNo);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        #region ファイルチェック処理関する
        #region エラーメッセージ
        private const string ct_FILE_MSG = "品番変換マスタ取込用のクロスインデックスファイルがありません。" + "\r\n" + "APサーバーにクロスインデックスファイルが配置されているか確認してください。";
        private const string ct_FILE_MSG2 = "優良設定マスタ変換用のクロスインデックスファイルがありません。" + "\r\n" + "APサーバーにクロスインデックスファイルが配置されているか確認してください。";
        private const string ct_FILE_NODATA = "該当するデータがありません。";
        // --- DEL 陳永康 2015/03/20 ファイルチェックの対応 ----->>>>>
        //private const int OF_READWRITE = 2;
        //private const int OF_SHARE_DENY_NONE = 0x40;
        //private readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        // --- DEL 陳永康 2015/03/20 ファイルチェックの対応 -----<<<<<

        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}が設定されていません";
        private const string FORMAT_ERRMSG_LENTH = "{0}({2})の桁数が{1}桁を超えています";
        /// <summary>
        /// 不正な文字が含まれている場合
        /// </summary>
        public static string FORMAT_ERRMSG_TYPE = "{0}に不正な文字が含まれています";
        /// <summary>
        /// 項目数が不正の場合
        /// </summary>
        public static string ERRMSG_COUNTERR = "項目数が不正です";
        /// <summary>
        /// メーカーがマスタに登録されていません
        /// </summary>
        public static string ERRMSG_MAKERNOTFOUND = "メーカーがマスタに登録されていません";

        #endregion

        /// <summary>
        /// ﾃｷｽﾄﾌｧｲﾙ名チェック処理
        /// </summary>
        /// <param name="filePath">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="mode">mode 0:品番変換マスタ変換用　1:優良設定マスタ変換用</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名チェック処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        public bool CheckInputFile(string filePath, out string errMsg, int mode)
        {
            bool status = true;
            errMsg = string.Empty;
            string fileName = filePath.Trim();
            string message = string.Empty;
            if (mode == 0)
            {
                message = ct_FILE_MSG;
            }
            if (mode == 1)
            {
                message = ct_FILE_MSG2;
            }

            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
                {
                    errMsg = message;
                    status = false;
                    return status;
                }

                if (!File.Exists(fileName))
                {
                    errMsg = message;
                    status = false;
                    return status;
                }

                // --- DEL 陳永康 2015/03/20 ファイルチェックの対応 ----->>>>>
                //IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);
                //if (vHandle == HFILE_ERROR)
                //{
                //    errMsg = message;
                //    status = false;
                //    return status;
                //}
                //CloseHandle(vHandle);
                // --- DEL 陳永康 2015/03/20 ファイルチェックの対応 -----<<<<<
            }
            catch
            {
                errMsg = message;
                status = false;
                return status;
            }

            return true;
        }

        /// <summary>
        /// ﾃｷｽﾄﾌｧｲﾙ名のレコード存在チェック処理
        /// </summary>
        /// <param name="fileName">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="dataList">データリスト</param>
        /// <param name="isReadErr">読込エラーかどうか</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ﾃｷｽﾄﾌｧｲﾙ名のレコード存在チェック処理を行う。(入力チェックなど)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        public bool CheckInputFileDataExists(string fileName, out string errMsg, out List<string[]> dataList, out bool isReadErr)
        {
            errMsg = string.Empty;
            isReadErr = false;
            bool bStatus = true;
            dataList = GetCsvData(fileName, out errMsg);
            // 読込時にエラーが発生した場合
            if (!string.IsNullOrEmpty(errMsg))
            {
                isReadErr = true;
                bStatus = false;
            }
            return bStatus;
        }

        /// <summary>
        /// CSV情報取得処理
        /// </summary>
        /// <param name="fileName">ファイル名前</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>CSV情報</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private List<String[]> GetCsvData(String fileName, out string errMsg)
        {
            errMsg = string.Empty;
            List<string[]> csvDataList = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            try
            {
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // 区切り文字はコンマ
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1行読み込み
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                // なし
            }
            return csvDataList;

        }

        // --- DEL 陳永康 2015/03/20 ファイルチェックの対応 ----->>>>>
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
        // --- DEL 陳永康 2015/03/20 ファイルチェックの対応 -----<<<<<

        /// <summary>
        /// NULL判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        public bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 正整数字判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        public bool IsDigitAdd(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regex1 = "^[0-9]*[1-9][0-9]*$";
            Regex objRegex = new Regex(regex1);
            if (!objRegex.IsMatch(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 正整数+0判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>True:数字; False:非数字</returns>
        /// <remarks>
        /// <br>Note       : 正整数+0判断処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/12/30</br>
        /// </remarks>
        public bool IsDigitAddZero(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regex1 = "^\\d+$";
            Regex objRegex = new Regex(regex1);
            if (!objRegex.IsMatch(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 長さを指定しないの文字列チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        public bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            if (val.Trim().Length > len)
            {
                msg = string.Format(FORMAT_ERRMSG_LENTH, fieldNm, len.ToString(), val);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 半角英数字、符号のチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">えらーメッセージ</param>
        /// <returns>メッセージ</returns>
        public bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;

            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
                return false;
            }

        }

        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        public string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
    }
}
