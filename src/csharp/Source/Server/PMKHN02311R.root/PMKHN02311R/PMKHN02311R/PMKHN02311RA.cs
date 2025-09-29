//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 陳艶丹
// 修 正 日  2020/06/18  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//---------------------------------------------------------------------------//

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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;// ADD 陳艶丹 2020/06/18 PMKOBETSU-4005の対応

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 卸商商品価格改正処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 卸商商品価格改正処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/06/18</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class GoodsInfoWorkDB : RemoteDB, IGoodsInfoWorkDB
    {
        /// <summary>
        /// 卸商商品価格改正処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public GoodsInfoWorkDB()
            :
        base("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork", "WAREHOUSERF") //基底クラスのコンストラクタ
        {
        }

        /// <summary>
        /// 指定された企業コードの卸商商品価格改正処理のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="countNum">検索結果</param>
        /// <param name="normalGoodsInfoDataWorkLst">ファイルパラメータ正常</param>
        /// <param name="warnGoodsInfoDataWorkLst">ファイルパラメータ警告</param>
        /// <param name="goodsInfoCndtnWork">画面のパラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの卸商商品価格改正処理のLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        public int WriteGoodsInfo(out object countNum, out object writeError, ref object normalGoodsInfoDataWorkLst, ref object warnGoodsInfoDataWorkLst, object goodsInfoCndtnWork)
        {
            writeError = null;
            countNum = new object();
            ArrayList ret = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                if (null == normalGoodsInfoDataWorkLst
                    && null == warnGoodsInfoDataWorkLst)
                {
                    return status;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                ArrayList normalParamGoodsInfoDataWorkLst = normalGoodsInfoDataWorkLst as ArrayList;

                ArrayList warnParamGoodsInfoDataWorkLst = warnGoodsInfoDataWorkLst as ArrayList;

                GoodsInfoCndtnWork goodsInfoParamCndtnWork = goodsInfoCndtnWork as GoodsInfoCndtnWork;

                //write実行
                ArrayList writeErrorList = null;

                status = WriteGoodsPriceProc(out ret, out writeErrorList, ref normalParamGoodsInfoDataWorkLst, ref warnParamGoodsInfoDataWorkLst, goodsInfoParamCndtnWork, ref sqlConnection, ref sqlTransaction);

                countNum = ret;

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                //    status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                //{
                    //コミット
                    sqlTransaction.Commit();
                //}
                //else
                //{
                //    // ロールバック
                //    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //}
                //戻り値セット
                writeError = (object)writeErrorList;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Write(ref object GoodsPriceUWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Write(ref object GoodsPriceUWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 商品価格マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWorkオブジェクト</param>
        /// <param name="writeErrorList">更新エラーリスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br></br>
        public int WriteGoodsPriceProc(out ArrayList ret, out ArrayList writeErrorList, ref ArrayList normalGoodsInfoDataWorkLst, ref ArrayList warnGoodsInfoDataWorkLst, GoodsInfoCndtnWork goodsInfoParamCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ArrayList retList = new ArrayList();
            writeErrorList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //追加数
            int addNum = 0;

            //更新数
            int updateNum = 0;

            ArrayList al = new ArrayList();
            string errorMessage = string.Empty;

            bool normalExistFlg;
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();

            try
            {
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                //正常場合
                for (int i = 0; i < normalGoodsInfoDataWorkLst.Count; i++)
                {
                    normalExistFlg = false;
                    GoodsInfoDataWork goodsInfoDataWork = normalGoodsInfoDataWorkLst[i] as GoodsInfoDataWork;

                    //商品マスタ
                    errorMessage = string.Empty;
                    int writeGoodsStatus;
                    writeGoodsStatus = WriteGoodsUProcProc(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out normalExistFlg, out errorMessage, ref sqlConnection, ref sqlTransaction);
                    if (writeGoodsStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (normalExistFlg)
                        {
                            updateNum++;
                        }
                        else
                        {
                            addNum++;
                        }

                        al.Add(goodsInfoDataWork);

                        //WARNING,ERRORじゃなかったらNORMAL
                        if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                            status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }


                        //商品管理情報マスタ
                        errorMessage = string.Empty;
                        int writeGoodsMngStatus;
                        writeGoodsMngStatus = WriteGoodsMngProcProc(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        if (writeGoodsMngStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERRORじゃなかったらNORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsMngStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                        //価格マスタ
                        errorMessage = string.Empty;
                        int writeGoodsPriceStatus;
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                        //writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                       writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease);
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                        
                        if (writeGoodsPriceStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERRORじゃなかったらNORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsPriceStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                    }
                    else
                    {
                        writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsStatus, errorMessage));
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }
                }

                bool warnExistFlg;
                //警告場合
                for (int i = 0; i < warnGoodsInfoDataWorkLst.Count; i++)
                {
                    warnExistFlg = false;
                    GoodsInfoDataWork goodsInfoDataWork = warnGoodsInfoDataWorkLst[i] as GoodsInfoDataWork;
                    //商品マスタ
                    errorMessage = string.Empty;
                    int writeGoodsStatus;
                    writeGoodsStatus = WriteGoodsUProcProc(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out warnExistFlg, out errorMessage, ref sqlConnection, ref sqlTransaction);
                    if (writeGoodsStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (warnExistFlg)
                        {
                            updateNum++;
                        }
                        else
                        {
                            addNum++;
                        }

                        al.Add(goodsInfoDataWork);

                        //WARNING,ERRORじゃなかったらNORMAL
                        if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                            status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        //商品管理情報マスタ
                        int writeGoodsMngStatus;
                        errorMessage = string.Empty;
                        writeGoodsMngStatus = WriteGoodsMngProcProc(ref  goodsInfoDataWork, goodsInfoParamCndtnWork, out  errorMessage, ref  sqlConnection, ref  sqlTransaction);
                        if (writeGoodsMngStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERRORじゃなかったらNORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsMngStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                        //価格マスタ
                        errorMessage = string.Empty;
                        int writeGoodsPriceStatus;
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                        //writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        writeGoodsPriceStatus = WriteGoodsPrice(ref goodsInfoDataWork, goodsInfoParamCndtnWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease);
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                        
                        if (writeGoodsPriceStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            al.Add(goodsInfoDataWork);

                            //WARNING,ERRORじゃなかったらNORMAL
                            if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                                status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsPriceStatus, errorMessage));
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                        }

                    }
                    else
                    {
                        writeErrorList.Add(SetError(goodsInfoDataWork, writeGoodsStatus, errorMessage));
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }

                }
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            }
            finally
            {
                // 解放
                convertDoubleRelease.Dispose();
            }
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

            retList.Add(updateNum);
            retList.Add(addNum);

            ret = retList;
            //goodsInfoDataWork = al;
            return status;
        }

        /// <summary>
        /// 商品価格マスタ INSERT or UPDATE 処理
        /// </summary>
        /// <param name="GoodsPriceUWork">商品価格マスタ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ INSERT or UPDATE 処理を行う</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br></br>
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
        //private int WriteGoodsPrice(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteGoodsPrice(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
        {
            bool existFlg = false;
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try
            {
                //Selectコマンドの生成
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICEURF.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICEURF.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,GOODSPRICEURF.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(goodsInfoDataWork.PriceStartDate.ToString(), "yyyyMMdd", null));

                DateTime updateCreateDateTime = DateTime.MinValue;
                Guid updateGuid = Guid.Empty;
                //論理削除区分
                Int32 updateDelete = -1;

                myReader = sqlCommand.ExecuteReader();

                if (0 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //insert or update 
                    if (myReader.Read())
                    {
                        ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        //if (_updateDateTime != goodsInfoDataWork.UpdateDateTime)
                        //{
                        //    //新規登録で該当データ有りの場合には重複
                        //    if (goodsInfoDataWork.UpdateDateTime == DateTime.MinValue)
                        //    {
                        //        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //        errorMessage = "重複するデータがあるため更新できません。";
                        //    }
                        //    //既存データで更新日時違いの場合には排他
                        //    else
                        //    {
                        //        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //        errorMessage = "このデータは既に更新されています。";
                        //    }

                        //    sqlCommand.Cancel();
                        //    return status;
                        //}

                        existFlg = true;

                        //作成日時
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //論理削除区分
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //更新用のSQL文を生成
                        sqlText = "";
                        sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                        sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                        sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                        //sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                        //sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        //sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(goodsInfoDataWork.PriceStartDate.ToString(), "yyyyMMdd", null));
                    }
                    else
                    {
                        ////既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        //if (goodsInfoDataWork.UpdateDateTime > DateTime.MinValue)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        //    errorMessage = "このデータは既に削除されています。";
                        //    sqlCommand.Cancel();
                        //    return status;
                        //}

                        existFlg = false;

                        //新規作成時のSQL文を生成
                        sqlText = "";
                        sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "  ,GOODSNORF" + Environment.NewLine;
                        sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                        sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                        sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                        sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                        sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  ,@GOODSNO" + Environment.NewLine;
                        sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                        sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                        sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                        sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                        sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //以下の処理で論理削除区分が０に書き換えられてしまう為、退避しておく
                        //商品在庫マスタからの論理削除時に使用する
                        int logicalDeleteCode = goodsInfoDataWork.LogicalDeleteCode;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        goodsInfoDataWork.LogicalDeleteCode = 0;
                    }

                }
                else if (1 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //update 
                    if (myReader.Read())
                    {
                        existFlg = true;

                        //作成日時
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //論理削除区分
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //更新用のSQL文を生成
                        sqlText = "";
                        sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                        sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                        sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                        //sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                        //sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        //sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(goodsInfoDataWork.PriceStartDate.ToString(), "yyyyMMdd", null));
                    }
                    else
                    {
                        existFlg = false;
                        return -1;
                    }
                }
                else
                {
                    //insert
                    if (myReader.Read())
                    {
                        existFlg = true;
                        return -1;
                    }
                    else
                    {
                        existFlg = false;
                        //新規作成時のSQL文を生成
                        sqlText = "";
                        sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "  ,GOODSNORF" + Environment.NewLine;
                        sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                        sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                        sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                        sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                        sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  ,@GOODSNO" + Environment.NewLine;
                        sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                        sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                        sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                        sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                        sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //以下の処理で論理削除区分が０に書き換えられてしまう為、退避しておく
                        //商品在庫マスタからの論理削除時に使用する
                        int logicalDeleteCode = goodsInfoDataWork.LogicalDeleteCode;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        goodsInfoDataWork.LogicalDeleteCode = 0;
                    }
                }

                //bool flg = myReader.Read();

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                #region Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = null;
                SqlParameter paraOfferDate = null;
                SqlParameter paraUpdateDate = null;
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                    || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                    paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                }
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)

                if (existFlg)
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateCreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateGuid);
                    //if (updateDelete == -1)
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    //}
                    //else
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateDelete);
                    //}
                }
                else
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.CreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsInfoDataWork.FileHeaderGuid);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.LogicalDeleteCode);
                }
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId2);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.ParseExact(Convert.ToString(Convert.ToString(goodsInfoDataWork.PriceStartDate)), "yyyyMMdd", null));
                
                // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsInfoDataWork.Price);
                convertDoubleRelease.EnterpriseCode = goodsInfoDataWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = goodsInfoDataWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = goodsInfoDataWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = goodsInfoDataWork.Price;

                // 変換処理実行
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble((goodsInfoDataWork.SalesUnitCost)/100);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble((goodsInfoDataWork.StockRate)/100);
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                    || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(0);
                    paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                    paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                }
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
                throw ex;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// 商品マスタ（ユーザー登録分）情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsUWorkList">GoodsUWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private int WriteGoodsUProcProc(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out bool existFlg, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            existFlg = false;
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;

                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);

                myReader = sqlCommand.ExecuteReader();

                //作成日時
                DateTime updateCreateDateTime = DateTime.MinValue;
                //企業コード
                Guid updateGuid = Guid.Empty;
                //論理削除区分
                Int32 updateDelete = -1;

                if (0 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //insert or update
                    if (myReader.Read())
                    {
                        existFlg = true;
                        ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        //if (_updateDateTime != goodsInfoDataWork.UpdateDateTime)
                        //{
                        //    //新規登録で該当データ有りの場合には重複
                        //    if (goodsInfoDataWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //    //既存データで更新日時違いの場合には排他
                        //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //    sqlCommand.Cancel();
                        //    if (myReader.IsClosed == false) myReader.Close();
                        //    return status;
                        //}

                        sqlTxt = string.Empty;

                        //作成日時
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //論理削除区分
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                        //sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        sqlTxt += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        existFlg = false;
                        ////既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        //if (goodsInfoDataWork.UpdateDateTime > DateTime.MinValue)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        //    sqlCommand.Cancel();
                        //    if (myReader.IsClosed == false) myReader.Close();
                        //    return status;
                        //}

                        sqlTxt = string.Empty + Environment.NewLine;
                        sqlTxt += "INSERT INTO GOODSURF" + Environment.NewLine;
                        sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        //sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "  ,DISPLAYORDERRF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                        sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSKINDCODERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF" + Environment.NewLine;
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
                        sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += "  ,@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "  )" + Environment.NewLine;

                        //新規作成時のSQL文を生成
                        sqlCommand.CommandText = sqlTxt;
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                }
                else if (1 == goodsInfoParamCndtnWork.UpdateType)
                {
                    //update
                    if (myReader.Read())
                    {
                        existFlg = true;

                        //作成日時
                        updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //GUID
                        updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //論理削除区分
                        updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlTxt = string.Empty;

                        sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                        //sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        sqlTxt += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        existFlg = false;
                        return -1;
                    }
                }
                else
                {
                    //insert
                    if (myReader.Read())
                    {
                        existFlg = true;
                        return -1;
                    }
                    else
                    {
                        sqlTxt = string.Empty + Environment.NewLine;
                        sqlTxt += "INSERT INTO GOODSURF" + Environment.NewLine;
                        sqlTxt += "  (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        //sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                        sqlTxt += "  ,JANRF" + Environment.NewLine;
                        sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "  ,DISPLAYORDERRF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                        sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSKINDCODERF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        //sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE1RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSNOTE2RF" + Environment.NewLine;
                        sqlTxt += "  ,GOODSSPECIALNOTERF" + Environment.NewLine;
                        sqlTxt += "  ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                        sqlTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF" + Environment.NewLine;
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
                        sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAME" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        //sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += "  ,@JAN" + Environment.NewLine;
                        sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += "  ,@DISPLAYORDER" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSKINDCODE" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        //sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += "  ,@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += "  ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += "  ,@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "  )" + Environment.NewLine;

                        //新規作成時のSQL文を生成
                        sqlCommand.CommandText = sqlTxt;
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                }

                //bool flg = myReader.Read();

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                #region Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                //SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                //SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                SqlParameter paraOfferDate = null;
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                    || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                }


                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                //SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                //SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                //SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIVRF", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)

                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);

                if (existFlg)
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateCreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateGuid);
                    //if (updateDelete == -1)
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    //}
                    //else
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateDelete);
                    //}
                }
                else
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.CreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsInfoDataWork.FileHeaderGuid);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                }
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId2);

                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsName);
                //paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNameKana);
                //paraJan.Value = SqlDataMediator.SqlSetString(goodsuWork.Jan);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraJan.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.BLGoodsCode);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(0);
                //paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsRateRank);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                //todo:テキストファイルの品番よりハイフンを消去した品番
                paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo.Replace("-", ""));
                if (((0 == goodsInfoParamCndtnWork.UpdateType) && (!existFlg))
                         || (2 == goodsInfoParamCndtnWork.UpdateType))
                {
                    paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                }
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(1);
                //paraGoodsNote1.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote1);
                //paraGoodsNote2.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote2);
                //paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsSpecialNote);
                paraGoodsNote1.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraGoodsNote2.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(string.Empty);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(0);




                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
                throw ex;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// 商品管理情報マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsMngWorkList">GoodsMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品管理情報マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private int WriteGoodsMngProcProc(ref GoodsInfoDataWork goodsInfoDataWork, GoodsInfoCndtnWork goodsInfoParamCndtnWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            bool existFlg = false;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                DateTime updateCreateDateTime = DateTime.MinValue;
                Guid updateGuid = Guid.Empty;
                //論理削除区分
                Int32 updateDelete = -1;

                string sqlTxt = string.Empty;
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "  GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += " ,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += " ,GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += " ,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += " ,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "     GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " AND GDM.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlTxt += " AND GDM.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += " AND GDM.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                sqlTxt += " AND GDM.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                sqlTxt += " AND GDM.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                findParaSectionCode.Value = "00";
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                //todo:商品中分類コードがない。
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);

                if (SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo) == DBNull.Value)
                {
                    findParaGoodsNo.Value = string.Empty;
                }
                else
                {
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                }

                myReader = sqlCommand.ExecuteReader();


                //insert update
                if (myReader.Read())
                {
                    ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    //if (_updateDateTime != goodsInfoDataWork.UpdateDateTime)
                    //{
                    //    //新規登録で該当データ有りの場合には重複
                    //    if (goodsInfoDataWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //    //既存データで更新日時違いの場合には排他
                    //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    //    sqlCommand.Cancel();
                    //    if (myReader.IsClosed == false) myReader.Close();
                    //    return status;
                    //}
                    existFlg = true;

                    //作成日時
                    updateCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //GUID
                    updateGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //論理削除区分
                    updateDelete = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                    sqlTxt = string.Empty;
                    sqlTxt += "UPDATE GOODSMNGRF SET" + Environment.NewLine;
                    sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                    sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                    sqlTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                    sqlTxt += " , SUPPLIERLOTRF=@SUPPLIERLOT" + Environment.NewLine;
                    sqlTxt += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlTxt += "  AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                    findParaSectionCode.Value = "00";
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                    //todo:商品中分類コード
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);

                    if (SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo) == DBNull.Value)
                    {
                        findParaGoodsNo.Value = string.Empty;
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                    }

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    ////既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    //if (goodsInfoDataWork.UpdateDateTime > DateTime.MinValue)
                    //{
                    //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    //    sqlCommand.Cancel();
                    //    if (myReader.IsClosed == false) myReader.Close();
                    //    return status;
                    //}
                    existFlg = false;
                    sqlTxt = string.Empty;
                    sqlTxt += "INSERT INTO GOODSMNGRF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSNORF" + Environment.NewLine;
                    sqlTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlTxt += "  ,SUPPLIERLOTRF" + Environment.NewLine;
                    sqlTxt += "  ,GOODSMGROUPRF" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;
                    sqlTxt += " VALUES" + Environment.NewLine;
                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSNO" + Environment.NewLine;
                    sqlTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                    sqlTxt += "  ,@SUPPLIERLOT" + Environment.NewLine;
                    sqlTxt += "  ,@GOODSMGROUP" + Environment.NewLine;
                    sqlTxt += " )" + Environment.NewLine;

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = sqlTxt;
                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsInfoDataWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                #region Parameterオブジェクトの作成(更新用)
                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierLot = sqlCommand.Parameters.Add("@SUPPLIERLOT", SqlDbType.Int);
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraSectionCode.Value = "00";

                if (SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo) == DBNull.Value)
                {
                    paraGoodsNo.Value = string.Empty;
                }
                else
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.GoodsNo);
                }

                if (existFlg)
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updateCreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updateGuid);
                    //if (updateDelete == -1)
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    //}
                    //else
                    //{
                    //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updateDelete);
                    //}
                }
                else
                {
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.CreateDateTime);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsInfoDataWork.FileHeaderGuid);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                }
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsInfoDataWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.EnterpriseCode);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsInfoDataWork.UpdAssemblyId2);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsInfoDataWork.GoodsMakerCd);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32((goodsInfoDataWork.SupplierCd) * 100);
                paraSupplierLot.Value = SqlDataMediator.SqlSetInt32(0);
                //todo:notnull 0をセットする。
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(0);



                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
                throw ex;
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 登録エラーオブジェクトの生成
        /// </summary>
        /// <param name="GoodsPriceUWork">商品価格マスタ</param>
        /// <param name="errorCode">エラーコード</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>商品価格登録エラー</returns>
        /// <br>Note       : 登録エラーオブジェクトの生成を行う</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private GoodsInfoDataWork SetError(GoodsInfoDataWork goodsInfoDataWork, int errorCode, string errorMessage)
        {

            GoodsInfoDataWork goodsPriceWriteErrorWork = new GoodsInfoDataWork();

            goodsPriceWriteErrorWork.CreateDateTime = goodsInfoDataWork.CreateDateTime;
            goodsPriceWriteErrorWork.UpdateDateTime = goodsInfoDataWork.UpdateDateTime;
            goodsPriceWriteErrorWork.EnterpriseCode = goodsInfoDataWork.EnterpriseCode;
            goodsPriceWriteErrorWork.FileHeaderGuid = goodsInfoDataWork.FileHeaderGuid;
            goodsPriceWriteErrorWork.UpdEmployeeCode = goodsInfoDataWork.UpdEmployeeCode;
            goodsPriceWriteErrorWork.UpdAssemblyId1 = goodsInfoDataWork.UpdAssemblyId1;
            goodsPriceWriteErrorWork.UpdAssemblyId2 = goodsInfoDataWork.UpdAssemblyId2;
            goodsPriceWriteErrorWork.LogicalDeleteCode = goodsInfoDataWork.LogicalDeleteCode;
            goodsPriceWriteErrorWork.GoodsMakerCd = goodsInfoDataWork.GoodsMakerCd;
            goodsPriceWriteErrorWork.GoodsNo = goodsInfoDataWork.GoodsNo;
            goodsPriceWriteErrorWork.PriceStartDate = goodsInfoDataWork.PriceStartDate;
            goodsPriceWriteErrorWork.Price = goodsInfoDataWork.Price;
            goodsPriceWriteErrorWork.SalesUnitCost = goodsInfoDataWork.SalesUnitCost;
            goodsPriceWriteErrorWork.StockRate = goodsInfoDataWork.StockRate;
            //goodsPriceWriteErrorWork.OpenPriceDiv = goodsInfoDataWork.OpenPriceDiv;
            //goodsPriceWriteErrorWork.OfferDate = goodsInfoDataWork.OfferDate;
            //goodsPriceWriteErrorWork.UpdateDate = goodsInfoDataWork.UpdateDate;
            goodsPriceWriteErrorWork.ErrorCode = errorCode;
            goodsPriceWriteErrorWork.ErrorMessage = errorMessage;
            return goodsPriceWriteErrorWork;
        }


        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection生成処理を行う</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br></br>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

    }
}
