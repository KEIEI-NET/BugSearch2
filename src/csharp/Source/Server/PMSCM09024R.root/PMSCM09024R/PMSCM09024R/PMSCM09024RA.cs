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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.04.27</br>
    /// <br></br>
    /// <br>Update Note      :   2012/08/31  30747 三戸 伸悟</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :   自動回答時表示区分(2012/10月配信予定 SCM障害№76の対応)</br>
    /// <br></br>
    /// <br>Update Note      :   2012/11/09  30744 湯上 千加子</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :     自動回答区分（問合せ）、自動回答区分（発注）、</br>
    /// <br>                 :     受付従業員コード、受付従業員名称、納品区分、納品区分名称</br>
    /// <br>                 :    SCM改良№10337,10338,10341対応</br>
    /// <br>Update Note      :   2013/02/13  30744 湯上 千加子</br>
    /// <br>                 :   ○SCM障害対応 項目追加 </br>
    /// <br>                 :     該当無自動回答区分</br>
    /// <br>Update Note      :   管理番号  10900690-00 作成担当 : qijh</br>
    /// <br>                 :   配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応 </br>
    /// <br>Update Note      :   管理番号  10801804-00 作成担当 : wangl2</br>
    /// <br>                 :   2013/05/15 配信分 Redmine#35269 </br>
    /// </remarks>
    [Serializable]
    public class SCMTtlStDB : RemoteDB, ISCMTtlStDB
    {
        /// <summary>
        /// SCM全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        /// <br>-----------------------------------------------</br>
        /// <br>UpDateNote : 見積書発行区分の追加</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.07.15</br>
        /// </remarks>
        public SCMTtlStDB()
            :
            base("PMSCM09026D", "Broadleaf.Application.Remoting.ParamData.SCMTtlStWork", "SCMTTLSTRF")
        {
        }

        private string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件のSCM全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="scmTtlStWork">検索結果</param>
        /// <param name="paraSCMTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int Search(out object scmTtlStWork, object paraSCMTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            scmTtlStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMTtlStProc(out scmTtlStWork, paraSCMTtlStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMTtlStDB.Search");
                scmTtlStWork = new ArrayList();
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
        /// 指定された条件のSCM全体設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objscmTtlStWork">検索結果</param>
        /// <param name="parascmTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchSCMTtlStProc(out object objscmTtlStWork, object parascmTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMTtlStWork scmTtlStWork = null; 

            ArrayList stockmngttlstWorkList = parascmTtlStWork as ArrayList;
            if (stockmngttlstWorkList == null)
            {
                scmTtlStWork = parascmTtlStWork as SCMTtlStWork;
            }
            else
            {
                if (stockmngttlstWorkList.Count > 0)
                    scmTtlStWork = stockmngttlstWorkList[0] as SCMTtlStWork;
            }

            int status = SearchStockMngTtlStProc(out stockmngttlstWorkList, scmTtlStWork, readMode, logicalMode, ref sqlConnection);
            objscmTtlStWork = stockmngttlstWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のSCM全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">検索結果</param>
        /// <param name="scmTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int SearchStockMngTtlStProc(out ArrayList stockmngttlstWorkList, SCMTtlStWork scmTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchStockMngTtlStProcProc(out stockmngttlstWorkList, scmTtlStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">検索結果</param>
        /// <param name="scmTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int SearchStockMngTtlStProcProc(out ArrayList stockmngttlstWorkList, SCMTtlStWork scmTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                #region SELECT文
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,ACPODRRSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPERATDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPFOLDERRF " + Environment.NewLine;
                selectTxt += "         ,BLCODECHGDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOCOOPERATDISRF " + Environment.NewLine;
                selectTxt += "         ,DISCOUNTAPPLYCDRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ESTIMATEPRTDIVRF " + Environment.NewLine;  //2009/07/15
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,RCVPROCSTINTERVALRF " + Environment.NewLine;
                selectTxt += "         ,SALESCDSTAUTOANSRF " + Environment.NewLine;
                selectTxt += "         ,SALESCODERF " + Environment.NewLine;
                //2012/04/20 ADD T.Nishi <<<<<<<<<<

                // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,AUTOANSHOURDSPDIVRF " + Environment.NewLine;
                // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                selectTxt += "         ,AUTOANSINQUIRYDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSORDERDIVRF " + Environment.NewLine;
                selectTxt += "         ,FRONTEMPLOYEECDRF " + Environment.NewLine;
                selectTxt += "         ,DELIVEREDGOODSDIVRF " + Environment.NewLine;
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                selectTxt += "         ,FUWIOUTAUTOANSDIVRF " + Environment.NewLine;
                // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                selectTxt += "         ,DATAUPDATEWAREHDIVRF " + Environment.NewLine;
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                selectTxt += "         ,SALESINPUTCODERF " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                selectTxt += "  FROM SCMTTLSTRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmTtlStWork, logicalMode);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSCMTtlStWorkFromReader(ref myReader));
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

            stockmngttlstWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のSCM全体設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">SCMTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                SCMTtlStWork scmTtlStWork = new SCMTtlStWork();

                // XMLの読み込み
                scmTtlStWork = (SCMTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMTtlStWork));
                if (scmTtlStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmTtlStWork, readMode, ref sqlConnection);
                
                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(scmTtlStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件のSCM全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmTtlStWork">SCMTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int ReadProc(ref SCMTtlStWork scmTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref scmTtlStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int ReadProcProc(ref SCMTtlStWork scmTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,ACPODRRSLIPPRTDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPERATDIVRF " + Environment.NewLine;
                selectTxt += "         ,OLDSYSCOOPFOLDERRF " + Environment.NewLine;
                selectTxt += "         ,BLCODECHGDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOCOOPERATDISRF " + Environment.NewLine;
                selectTxt += "         ,DISCOUNTAPPLYCDRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ESTIMATEPRTDIVRF " + Environment.NewLine;  //2009/07/15
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,RCVPROCSTINTERVALRF " + Environment.NewLine;
                selectTxt += "         ,SALESCDSTAUTOANSRF " + Environment.NewLine;
                selectTxt += "         ,SALESCODERF " + Environment.NewLine;
                //2012/04/20 ADD T.Nishi <<<<<<<<<<

                // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,AUTOANSHOURDSPDIVRF " + Environment.NewLine;
                // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                selectTxt += "         ,AUTOANSINQUIRYDIVRF " + Environment.NewLine;
                selectTxt += "         ,AUTOANSORDERDIVRF " + Environment.NewLine;
                selectTxt += "         ,FRONTEMPLOYEECDRF " + Environment.NewLine;
                selectTxt += "         ,DELIVEREDGOODSDIVRF " + Environment.NewLine;
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                selectTxt += "         ,FUWIOUTAUTOANSDIVRF " + Environment.NewLine;
                // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                selectTxt += "         ,DATAUPDATEWAREHDIVRF " + Environment.NewLine;
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                selectTxt += "         ,SALESINPUTCODERF " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                selectTxt += "  FROM SCMTTLSTRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;

                #endregion

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);
               
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    scmTtlStWork = CopyToSCMTtlStWorkFromReader(ref myReader);
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
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// SCM全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="scmTtlStWork">SCMTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int Write(ref object scmTtlStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmTtlStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSCMTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMTtlStWork paraWork = paraList[0] as SCMTtlStWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecSCMTtlSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                scmTtlStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMTtlSttDB.Write(ref object scmTtlStWork)");
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
        /// SCM全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmTtlStWorkList">SCMTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int WriteSCMTtlStProc(ref ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMTtlStProcProc(ref scmTtlStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　櫻井  亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int WriteSCMTtlStProcProc(ref ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand　　sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmTtlStWorkList != null)
                {
                    for (int i = 0; i < scmTtlStWorkList.Count; i++)
                    {
                        SCMTtlStWork scmTtlStWork = scmTtlStWorkList[i] as SCMTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmTtlStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (scmTtlStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMTTLSTRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "  , ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "  , OLDSYSCOOPERATDIVRF = @OLDSYSCOOPERATDIV " + Environment.NewLine;
                            sqlText += "  , OLDSYSCOOPFOLDERRF = @OLDSYSCOOPFOLDER " + Environment.NewLine;
                            sqlText += "  , BLCODECHGDIVRF = @BLCODECHGDIV " + Environment.NewLine;
                            sqlText += "  , AUTOCOOPERATDISRF = @AUTOCOOPERATDIS " + Environment.NewLine;
                            sqlText += "  , DISCOUNTAPPLYCDRF = @DISCOUNTAPPLYCD " + Environment.NewLine;
                            sqlText += "  , AUTOANSWERDIVRF = @AUTOANSWERDIV" + Environment.NewLine;
                            sqlText += "  , ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;  //2009/07/15
                            //2012/04/20 ADD T.Nishi >>>>>>>>>>
                            sqlText += "  , CASHREGISTERNORF = @CASHREGISTERNO" + Environment.NewLine;  //2009/07/15
                            sqlText += "  , RCVPROCSTINTERVALRF = @RCVPROCSTINTERVAL" + Environment.NewLine;  //2009/07/15
                            sqlText += "  , SALESCDSTAUTOANSRF = @SALESCDSTAUTOANS" + Environment.NewLine;  //2009/07/15
                            sqlText += "  , SALESCODERF = @SALESCODE" + Environment.NewLine;  //2009/07/15
                            //2012/04/20 ADD T.Nishi <<<<<<<<<<

                            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "  , AUTOANSHOURDSPDIVRF = @AUTOANSHOURDSPDIV" + Environment.NewLine;
                            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                            sqlText += "  , AUTOANSINQUIRYDIVRF = @AUTOANSINQUIRYDIV" + Environment.NewLine;
                            sqlText += "  , AUTOANSORDERDIVRF   = @AUTOANSORDERDIV" + Environment.NewLine;
                            sqlText += "  , FRONTEMPLOYEECDRF   = @FRONTEMPLOYEECD" + Environment.NewLine;
                            sqlText += "  , DELIVEREDGOODSDIVRF = @DELIVEREDGOODSDIV" + Environment.NewLine;
                            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                            sqlText += "  , FUWIOUTAUTOANSDIVRF = @FUWIOUTAUTOANSDIV" + Environment.NewLine;
                            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                            sqlText += "  , DATAUPDATEWAREHDIVRF = @DATAUPDATEWAREHDIV" + Environment.NewLine;
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                            sqlText += "  , SALESINPUTCODERF = @SALESINPUTCODE" + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (scmTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMTTLSTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,SALESSLIPPRTDIVRF " + Environment.NewLine;
                            sqlText += "         ,ACPODRRSLIPPRTDIVRF " + Environment.NewLine;
                            sqlText += "         ,OLDSYSCOOPERATDIVRF " + Environment.NewLine;
                            sqlText += "         ,OLDSYSCOOPFOLDERRF " + Environment.NewLine;
                            sqlText += "         ,BLCODECHGDIVRF " + Environment.NewLine;
                            sqlText += "         ,AUTOCOOPERATDISRF " + Environment.NewLine;
                            sqlText += "         ,DISCOUNTAPPLYCDRF " + Environment.NewLine;
                            sqlText += "         ,AUTOANSWERDIVRF " + Environment.NewLine;  
                            sqlText += "         ,ESTIMATEPRTDIVRF " + Environment.NewLine;  // 2009/07/15
                            //2012/04/20 ADD T.Nishi >>>>>>>>>>
                            sqlText += "         ,CASHREGISTERNORF " + Environment.NewLine;
                            sqlText += "         ,RCVPROCSTINTERVALRF " + Environment.NewLine;
                            sqlText += "         ,SALESCDSTAUTOANSRF " + Environment.NewLine;
                            sqlText += "         ,SALESCODERF " + Environment.NewLine;
                            //2012/04/20 ADD T.Nishi <<<<<<<<<<

                            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,AUTOANSHOURDSPDIVRF " + Environment.NewLine;
                            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                            sqlText += "         ,AUTOANSINQUIRYDIVRF " + Environment.NewLine;
                            sqlText += "         ,AUTOANSORDERDIVRF " + Environment.NewLine;
                            sqlText += "         ,FRONTEMPLOYEECDRF " + Environment.NewLine;
                            sqlText += "         ,DELIVEREDGOODSDIVRF " + Environment.NewLine;
                            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                            sqlText += "         ,FUWIOUTAUTOANSDIVRF " + Environment.NewLine;
                            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                            sqlText += "         ,DATAUPDATEWAREHDIVRF " + Environment.NewLine;
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                            sqlText += "         ,SALESINPUTCODERF " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@SECTIONCODE " + Environment.NewLine;
                            sqlText += "         ,@SALESSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "         ,@ACPODRRSLIPPRTDIV " + Environment.NewLine;
                            sqlText += "         ,@OLDSYSCOOPERATDIV " + Environment.NewLine;
                            sqlText += "         ,@OLDSYSCOOPFOLDER " + Environment.NewLine;
                            sqlText += "         ,@BLCODECHGDIV " + Environment.NewLine;
                            sqlText += "         ,@AUTOCOOPERATDIS " + Environment.NewLine;
                            sqlText += "         ,@DISCOUNTAPPLYCD " + Environment.NewLine;
                            sqlText += "         ,@AUTOANSWERDIV " + Environment.NewLine;  
                            sqlText += "         ,@ESTIMATEPRTDIV " + Environment.NewLine;  //2009/07/15
                            //2012/04/20 ADD T.Nishi >>>>>>>>>>
                            sqlText += "         ,@CASHREGISTERNO " + Environment.NewLine;
                            sqlText += "         ,@RCVPROCSTINTERVAL " + Environment.NewLine;
                            sqlText += "         ,@SALESCDSTAUTOANS " + Environment.NewLine;
                            sqlText += "         ,@SALESCODE " + Environment.NewLine;  
                            //2012/04/20 ADD T.Nishi <<<<<<<<<<

                            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,@AUTOANSHOURDSPDIV " + Environment.NewLine;
                            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                            sqlText += "         ,@AUTOANSINQUIRYDIV " + Environment.NewLine;
                            sqlText += "         ,@AUTOANSORDERDIV " + Environment.NewLine;
                            sqlText += "         ,@FRONTEMPLOYEECD " + Environment.NewLine;
                            sqlText += "         ,@DELIVEREDGOODSDIV " + Environment.NewLine;
                            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                            sqlText += "         ,@FUWIOUTAUTOANSDIV " + Environment.NewLine;
                            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                            sqlText += "         ,@DATAUPDATEWAREHDIV " + Environment.NewLine;
                            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                            sqlText += "         ,@SALESINPUTCODE " + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);  // 売上伝票発行区分
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);  // 受注伝票発行区分
                        SqlParameter paraOldSysCooperatDiv = sqlCommand.Parameters.Add("@OLDSYSCOOPERATDIV", SqlDbType.Int);  // 旧システム連携区分
                        SqlParameter paraOldSysCoopFolder = sqlCommand.Parameters.Add("@OLDSYSCOOPFOLDER", SqlDbType.NVarChar);  // 旧システム連携フォルダ
                        SqlParameter paraBLCodeChgDiv = sqlCommand.Parameters.Add("@BLCODECHGDIV", SqlDbType.Int);  // BLコード変換区分
                        SqlParameter paraAutoCooperatDis = sqlCommand.Parameters.Add("@AUTOCOOPERATDIS", SqlDbType.Float);  // 自動連携値引
                        SqlParameter paraDiscountApplyCd = sqlCommand.Parameters.Add("@DISCOUNTAPPLYCD", SqlDbType.Int);  // 値引適用区分
                        SqlParameter paraAutoAnswerDiv = sqlCommand.Parameters.Add("@AUTOANSWERDIV", SqlDbType.Int);  // 自動回答区分  
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);  // 見積書発行区分  //2009/07/15
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);  // レジ番号
                        SqlParameter paraRcvProcStInterval = sqlCommand.Parameters.Add("@RCVPROCSTINTERVAL", SqlDbType.Int);  // 受信処理起動間隔
                        SqlParameter paraSalesCdStAutoAns = sqlCommand.Parameters.Add("@SALESCDSTAUTOANS", SqlDbType.Int);  // 販売区分設定(自動回答時)
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);  // 販売区分コード
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraAutoAnsHourDspDiv = sqlCommand.Parameters.Add("@AUTOANSHOURDSPDIV", SqlDbType.Int);  //自動回答時表示区分
                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                        SqlParameter paraAutoAnsInquiryDiv = sqlCommand.Parameters.Add("@AUTOANSINQUIRYDIV", SqlDbType.Int);  // 自動回答区分（問合せ）
                        SqlParameter paraAutoAnsOrderDiv = sqlCommand.Parameters.Add("@AUTOANSORDERDIV", SqlDbType.Int);  // 自動回答区分（発注）
                        SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);  // 受付従業員コード
                        SqlParameter paraDeliverGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);  // 納品区分
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                        SqlParameter paraFuwioutAutoAnsDiv = sqlCommand.Parameters.Add("@FUWIOUTAUTOANSDIV", SqlDbType.Int);  // 該当無自動回答区分
                        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                        SqlParameter paraDataUpDateWareHDiv = sqlCommand.Parameters.Add("@DATAUPDATEWAREHDIV", SqlDbType.Int);
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                        SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmTtlStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);  // 拠点コード
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesSlipPrtDiv);  // 売上伝票発行区分
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AcpOdrrSlipPrtDiv);  // 受注伝票発行区分
                        paraOldSysCooperatDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.OldSysCooperatDiv);  // 旧システム連携区分
                        paraOldSysCoopFolder.Value = SqlDataMediator.SqlSetString(scmTtlStWork.OldSysCoopFolder);  // 旧システム連携フォルダ
                        paraBLCodeChgDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.BLCodeChgDiv);  // BLコード変換区分
                        paraAutoCooperatDis.Value = SqlDataMediator.SqlSetDouble(scmTtlStWork.AutoCooperatDis);  // 自動連携値引
                        paraDiscountApplyCd.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DiscountApplyCd);  // 値引適用区分
                        paraAutoAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnswerDiv);  // 自動回答区分
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.EstimatePrtDiv);  // 見積書発行区分  //2009/07/15
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.CashRegisterNo);  // レジ番号
                        paraRcvProcStInterval.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.RcvProcStInterval);  // 受信処理起動間隔
                        paraSalesCdStAutoAns.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCdStAutoAns);  // 販売区分設定(自動回答時)
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCode);  // 販売区分コード
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        paraAutoAnsHourDspDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsHourDspDiv);    //自動回答時表示区分
                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                        paraAutoAnsInquiryDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsInquiryDiv);   // 自動回答区分（問合せ）
                        paraAutoAnsOrderDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsOrderDiv);       // 自動回答区分（発注）
                        paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(scmTtlStWork.FrontEmployeeCd);      // 受付従業員コード
                        paraDeliverGoodsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DeliveredGoodsDiv);     // 納品区分
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                        paraFuwioutAutoAnsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.FuwioutAutoAnsDiv);   // 該当無自動回答区分
                        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                        paraDataUpDateWareHDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DataUpDateWareHDiv);
                        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                        paraSalesInputCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SalesInputCode);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmTtlStWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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

            scmTtlStWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        private int UpdateAllSecSCMTtlSt(ref ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmTtlStWorkList != null)
                {
                    SCMTtlStWork scmTtlStWork = scmTtlStWorkList[0] as SCMTtlStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;
                    sqlText += " UPDATE SCMTTLSTRF SET " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV " + Environment.NewLine;
                    sqlText += "  , ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV " + Environment.NewLine;
                    sqlText += "  , OLDSYSCOOPERATDIVRF = @OLDSYSCOOPERATDIV " + Environment.NewLine;
                    sqlText += "  , OLDSYSCOOPFOLDERRF = @OLDSYSCOOPFOLDER " + Environment.NewLine;
                    sqlText += "  , BLCODECHGDIVRF = @BLCODECHGDIV " + Environment.NewLine;
                    sqlText += "  , AUTOCOOPERATDISRF = @AUTOCOOPERATDIS " + Environment.NewLine;
                    sqlText += "  , DISCOUNTAPPLYCDRF = @DISCOUNTAPPLYCD " + Environment.NewLine;
                    sqlText += "  , AUTOANSWERDIVRF = @AUTOANSWERDIV" + Environment.NewLine;
                    sqlText += "  , ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;  //2009/07/15
                    //2012/04/20 ADD T.Nishi >>>>>>>>>>
                    sqlText += "  , CASHREGISTERNORF = @CASHREGISTERNO" + Environment.NewLine;
                    sqlText += "  , RCVPROCSTINTERVALRF = @RCVPROCSTINTERVAL" + Environment.NewLine;
                    sqlText += "  , SALESCDSTAUTOANSRF = @SALESCDSTAUTOANS" + Environment.NewLine;
                    sqlText += "  , SALESCODERF = @SALESCODE" + Environment.NewLine;
                    //2012/04/20 ADD T.Nishi <<<<<<<<<<

                    // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += "  , AUTOANSHOURDSPDIVRF = @AUTOANSHOURDSPDIV" + Environment.NewLine;
                    // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                    sqlText += "  , AUTOANSINQUIRYDIVRF = @AUTOANSINQUIRYDIV" + Environment.NewLine;
                    sqlText += "  , AUTOANSORDERDIVRF   = @AUTOANSORDERDIV" + Environment.NewLine;
                    sqlText += "  , FRONTEMPLOYEECDRF   = @FRONTEMPLOYEECD" + Environment.NewLine;
                    sqlText += "  , DELIVEREDGOODSDIVRF = @DELIVEREDGOODSDIV" + Environment.NewLine;
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                    // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                    sqlText += "  , FUWIOUTAUTOANSDIVRF = @FUWIOUTAUTOANSDIV" + Environment.NewLine;
                    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    sqlText += "  , DATAUPDATEWAREHDIVRF = @DATAUPDWAREHOUSEDIV" + Environment.NewLine;
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    sqlText += "  , SALESINPUTCODERF = @SALESINPUTCODE" + Environment.NewLine;// ADD 2013.04.11 wangl2 FOR RedMine#35269

                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmTtlStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    #endregion

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);  // 売上伝票発行区分
                    SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);  // 受注伝票発行区分
                    SqlParameter paraOldSysCooperatDiv = sqlCommand.Parameters.Add("@OLDSYSCOOPERATDIV", SqlDbType.Int);  // 旧システム連携区分
                    SqlParameter paraOldSysCoopFolder = sqlCommand.Parameters.Add("@OLDSYSCOOPFOLDER", SqlDbType.NVarChar);  // 旧システム連携フォルダ
                    SqlParameter paraBLCodeChgDiv = sqlCommand.Parameters.Add("@BLCODECHGDIV", SqlDbType.Int);  // BLコード変換区分
                    SqlParameter paraAutoCooperatDis = sqlCommand.Parameters.Add("@AUTOCOOPERATDIS", SqlDbType.Float);  // 自動連携値引
                    SqlParameter paraDiscountApplyCd = sqlCommand.Parameters.Add("@DISCOUNTAPPLYCD", SqlDbType.Int);  // 値引適用区分
                    SqlParameter paraAutoAnswerDiv = sqlCommand.Parameters.Add("@AUTOANSWERDIV", SqlDbType.Int);  // 自動回答区分
                    SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);  // 見積書発行区分  //2009/07/15
                    //2012/04/20 ADD T.Nishi >>>>>>>>>>
                    SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);  // レジ番号
                    SqlParameter paraRcvProcStInterval = sqlCommand.Parameters.Add("@RCVPROCSTINTERVAL", SqlDbType.Int);  // 受信処理起動間隔
                    SqlParameter paraSalesCdStAutoAns = sqlCommand.Parameters.Add("@SALESCDSTAUTOANS", SqlDbType.Int);  // 販売区分設定(自動回答時)
                    SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);  // 販売区分コード
                    //2012/04/20 ADD T.Nishi <<<<<<<<<<

                    // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    SqlParameter paraAutoAnsHourDspDiv = sqlCommand.Parameters.Add("@AUTOANSHOURDSPDIV", SqlDbType.Int);  //自動回答時表示区分
                    // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                    SqlParameter paraAutoAnsInquiryDiv = sqlCommand.Parameters.Add("@AUTOANSINQUIRYDIV", SqlDbType.Int);  // 自動回答区分（問合せ）
                    SqlParameter paraAutoAnsOrderDiv = sqlCommand.Parameters.Add("@AUTOANSORDERDIV", SqlDbType.Int);  // 自動回答区分（発注）
                    SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);  // 受付従業員コード
                    SqlParameter paraDeliverGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);  // 納品区分
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                    // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                    SqlParameter paraFuwioutAutoAnsDiv = sqlCommand.Parameters.Add("@FUWIOUTAUTOANSDIV", SqlDbType.Int);  // 該当無自動回答区分
                    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    SqlParameter paraDataUpDateWareHDiv = sqlCommand.Parameters.Add("@DATAUPDWAREHOUSEDIV", SqlDbType.Int);
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmTtlStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);  // 拠点コード
                    paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesSlipPrtDiv);  // 売上伝票発行区分
                    paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AcpOdrrSlipPrtDiv);  // 受注伝票発行区分
                    paraOldSysCooperatDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.OldSysCooperatDiv);  // 旧システム連携区分
                    paraOldSysCoopFolder.Value = SqlDataMediator.SqlSetString(scmTtlStWork.OldSysCoopFolder);  // 旧システム連携フォルダ
                    paraBLCodeChgDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.BLCodeChgDiv);  // BLコード変換区分
                    paraAutoCooperatDis.Value = SqlDataMediator.SqlSetDouble(scmTtlStWork.AutoCooperatDis);  // 自動連携値引
                    paraDiscountApplyCd.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DiscountApplyCd);  // 値引適用区分
                    paraAutoAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnswerDiv);  // 自動回答区分
                    paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.EstimatePrtDiv);  // 見積書発行区分  //2009/07/15
                    //2012/04/20 ADD T.Nishi >>>>>>>>>>
                    paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.CashRegisterNo);  // レジ番号
                    paraRcvProcStInterval.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.RcvProcStInterval);  // 受信処理起動間隔
                    paraSalesCdStAutoAns.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCdStAutoAns);  // 販売区分設定(自動回答時)
                    paraSalesCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.SalesCode);  // 販売区分コード
                    //2012/04/20 ADD T.Nishi <<<<<<<<<<

                    // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    paraAutoAnsHourDspDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsHourDspDiv);    //自動回答時表示区分
                    // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                    paraAutoAnsInquiryDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsInquiryDiv);   // 自動回答区分（問合せ）
                    paraAutoAnsOrderDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.AutoAnsOrderDiv);       // 自動回答区分（発注）
                    paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(scmTtlStWork.FrontEmployeeCd);      // 受付従業員コード
                    paraDeliverGoodsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DeliveredGoodsDiv);     // 納品区分
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                    // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                    paraFuwioutAutoAnsDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.FuwioutAutoAnsDiv);   // 該当無自動回答区分
                    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                    paraDataUpDateWareHDiv.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.DataUpDateWareHDiv);
                    // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                    paraSalesInputCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SalesInputCode);// ADD 2013.04.11 wangl2 FOR RedMine#35269

                    #endregion

                    sqlCommand.ExecuteNonQuery();

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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

        #region [LogicalDelete]
        /// <summary>
        /// SCM全体設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int LogicalDelete(ref object scmTtlStWork)
        {
            return LogicalDeleteSCMTtlSt(ref scmTtlStWork, 0);
        }

        /// <summary>
        /// 論理削除SCM全体設定マスタ情報を復活します
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫管理全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int RevivalLogicalDelete(ref object scmTtlStWork)
        {
            return LogicalDeleteSCMTtlSt(ref scmTtlStWork, 1);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="scmTtlStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteSCMTtlSt(ref object scmTtlStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmTtlStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "SCMTtlStDB.LogicalDeleteSCMTtlSt :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int LogicalDeleteSCMTtlStProc(ref ArrayList scmTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMTtlStProcProc(ref scmTtlStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmTtlStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteSCMTtlStProcProc(ref ArrayList scmTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmTtlStWorkList != null)
                {
                    for (int i = 0; i < scmTtlStWorkList.Count; i++)
                    {
                        SCMTtlStWork scmTtlStWork = scmTtlStWorkList[i] as SCMTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) scmTtlStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else scmTtlStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmTtlStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmTtlStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmTtlStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmTtlStWork);
                    }

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
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmTtlStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SCM全体設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : SCM全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSCMTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMTtlStDB.Delete");
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
        /// 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmTtlStWorkList">在庫管理全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int DeleteSCMTtlStProc(ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMTtlStProcProc(scmTtlStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmTtlStWorkList">在庫管理全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int DeleteSCMTtlStProcProc(ArrayList scmTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmTtlStWorkList.Count; i++)
                {
                    SCMTtlStWork scmTtlStWork = scmTtlStWorkList[i] as SCMTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != scmTtlStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();                    
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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
        #endregion

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="scmTtlStWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　</br>
        /// <br>Date       : 2007.03.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMTtlStWork scmTtlStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(scmTtlStWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmTtlStWork.SectionCode);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        private SCMTtlStWork CopyToSCMTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMTtlStWork wkSCMTtlStWork = new SCMTtlStWork();

            #region クラスへ格納
            wkSCMTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkSCMTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkSCMTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkSCMTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkSCMTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkSCMTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkSCMTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkSCMTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkSCMTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));  // 売上伝票発行区分
            wkSCMTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));  // 受注伝票発行区分
            wkSCMTtlStWork.OldSysCooperatDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDSYSCOOPERATDIVRF"));  // 旧システム連携区分
            wkSCMTtlStWork.OldSysCoopFolder = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDSYSCOOPFOLDERRF"));  // 旧システム連携フォルダ
            wkSCMTtlStWork.BLCodeChgDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODECHGDIVRF"));  // BLコード変換区分
            wkSCMTtlStWork.AutoCooperatDis = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("AUTOCOOPERATDISRF"));  // 自動連携値引
            wkSCMTtlStWork.DiscountApplyCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISCOUNTAPPLYCDRF"));  // 値引適用区分
            wkSCMTtlStWork.AutoAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVRF"));  // 自動回答区分
            wkSCMTtlStWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));  // 見積書発行区分  //2009/07/15
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            wkSCMTtlStWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));  // レジ番号
            wkSCMTtlStWork.RcvProcStInterval = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RCVPROCSTINTERVALRF"));  // 受信処理起動間隔
            wkSCMTtlStWork.SalesCdStAutoAns = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCDSTAUTOANSRF"));  // 販売区分設定(自動回答時)
            wkSCMTtlStWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));  // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            wkSCMTtlStWork.AutoAnsHourDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSHOURDSPDIVRF")); //自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            wkSCMTtlStWork.AutoAnsInquiryDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSINQUIRYDIVRF"));  // 自動回答区分（問合せ）
            wkSCMTtlStWork.AutoAnsOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSORDERDIVRF"));  // 自動回答区分（発注）
            wkSCMTtlStWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));  // 受付従業員コード
            wkSCMTtlStWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));  // 納品区分
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            wkSCMTtlStWork.FuwioutAutoAnsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FUWIOUTAUTOANSDIVRF"));  // 該当無自動回答区分
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            wkSCMTtlStWork.DataUpDateWareHDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAUPDATEWAREHDIVRF"));
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            wkSCMTtlStWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));// ADD 2013.04.11 wangl2 FOR RedMine#35269

            #endregion

            return wkSCMTtlStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井  亮太</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMTtlStWork[] SCMTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SCMTtlStWork)
                    {
                        SCMTtlStWork wkSCMTtlStWork = paraobj as SCMTtlStWork;
                        if (wkSCMTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMTtlStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMTtlStWorkArray = (SCMTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (SCMTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMTtlStWork wkSCMTtlStWork = (SCMTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMTtlStWork));
                                if (wkSCMTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMTtlStWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
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
