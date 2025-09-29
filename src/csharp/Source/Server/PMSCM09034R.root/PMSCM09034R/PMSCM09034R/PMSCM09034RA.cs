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
    /// SCM納期設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫管理全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.08.26 20056 對馬 大輔</br>
    /// <br>           : MANTIS 14165 結果に回答納期６をセット</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/01/06 30517 夏野 駿希</br>
    /// <br>           : SCM検証結果対応No.7　納期設定を取寄品・在庫品で別に設定出来る様に修正</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/10/11  呉軍</br>
    /// <br>Note       : Redmine #25765</br>
    /// <br>           : 優先在庫回答納期区分、優先在庫回答納期の追加</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2012/08/30 高川 悟</br>
    /// <br>           : SCM障害対応No.10345　回答納期の設定方法を変更</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/10 吉岡</br>
    /// <br>           : SCM高速化 回答納期区分対応</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/16 豊沢</br>
    /// <br>           : SCM高速化 システム障害No226対応</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    public class SCMDeliDateStDB : RemoteDB, ISCMDeliDateStDB
    {
        /// <summary>
        /// SCM納期設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public SCMDeliDateStDB()
            :
            base("PMSCM09036D", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork", "SCMDELIDATESTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件のSCM納期設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="stockmngttlstWork">検索結果</param>
        /// <param name="parastockmngttlstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM農機設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Search(out object scmDeliDateStWork, object parascmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmDeliDateStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMDeliDateStProc(out scmDeliDateStWork, parascmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Search");
                scmDeliDateStWork = new ArrayList();
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
        /// 指定された条件のSCM納期設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objscmDeliDateStWork">検索結果</param>
        /// <param name="parascmDeliDateStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM納期設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchSCMDeliDateStProc(out object objscmDeliDateStWork, object parascmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMDeliDateStWork scmDeliDateStWork = null; 

            ArrayList scmDeliDateStWorkList = parascmDeliDateStWork as ArrayList;
            if (scmDeliDateStWorkList == null)
            {
                scmDeliDateStWork = parascmDeliDateStWork as SCMDeliDateStWork;
            }
            else
            {
                if (scmDeliDateStWorkList.Count > 0)
                    scmDeliDateStWork = scmDeliDateStWorkList[0] as SCMDeliDateStWork;
            }

            int status = SearchSCMDeliDateStProc(out scmDeliDateStWorkList, scmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
            objscmDeliDateStWork = scmDeliDateStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のSCM納期設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">検索結果</param>
        /// <param name="scmDeliDateStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM納期設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchSCMDeliDateStProc(out ArrayList scmDeliDateStWorkList, SCMDeliDateStWork scmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMDeliDateStProcProc(out scmDeliDateStWorkList, scmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM納期設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">検索結果</param>
        /// <param name="scmDeliDateStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM納期設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchSCMDeliDateStProcProc(out ArrayList scmDeliDateStWorkList, SCMDeliDateStWork scmDeliDateStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                selectTxt += " SELECT SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6RF " + Environment.NewLine;
                // 2011/01/06 Add >>>
                selectTxt += "         ,SCM.ANSWERDEADTIME1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/01/06 Add <<<
                // 2011/10/11 Add >>>
                selectTxt += "         ,SCM.PRISTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/10/11 Add <<<
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDATSHORTOFSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDATWITHOUTSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATWIOUTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATWIOUTRF " + Environment.NewLine;
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDTDIV1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTWIODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTWIODIVRF " + Environment.NewLine;
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "  FROM SCMDELIDATESTRF AS SCM" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmDeliDateStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSCMDeliDateStWorkFromReader(ref myReader));

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

            scmDeliDateStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のSCM納期設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM納期設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();

                // XMLの読み込み
                scmDeliDateStWork = (SCMDeliDateStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMDeliDateStWork));
                if (scmDeliDateStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmDeliDateStWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(scmDeliDateStWork);
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
        /// 指定された条件のSCM農機設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM農機設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int ReadProc(ref SCMDeliDateStWork scmDeliDateStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref scmDeliDateStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM農機設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM農機設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int ReadProcProc(ref SCMDeliDateStWork scmDeliDateStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT SCM.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,SCM.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6RF " + Environment.NewLine;
                // 2011/01/06 Add >>>
                selectTxt += "         ,SCM.ANSWERDEADTIME1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDEADTIME6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSWERDELIVDATE6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/01/06 Add <<<
                // 2011/10/11 Add >>>
                selectTxt += "         ,SCM.PRISTCKANSDELIDTDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCKANSDELIDATERF " + Environment.NewLine;
                // 2011/10/11 Add <<<
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDATSHORTOFSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDATWITHOUTSTCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTSTCANSDELDATWIOUTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATSHORTRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRISTCANSDELDATWIOUTRF " + Environment.NewLine;
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                selectTxt += "         ,SCM.ANSDELDTDIV1RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6RF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV1STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV2STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV3STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV4STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV5STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTDIV6STCRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.ENTANSDELDTWIODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTSHODIVRF " + Environment.NewLine;
                selectTxt += "         ,SCM.PRIANSDELDTWIODIVRF " + Environment.NewLine;
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                selectTxt += "  FROM SCMDELIDATESTRF  AS SCM " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = SCM.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = SCM.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = SCM.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += " WHERE SCM.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SCM.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "         AND SCM.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;


                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                    findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmDeliDateStWork = CopyToSCMDeliDateStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
        /// SCM納期設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM納期設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int Write(ref object stockmngttlstWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockmngttlstWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSCMDeliDateStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMDeliDateStWork paraWork = paraList[0] as SCMDeliDateStWork;
                
                // DEL 2015/02/16 豊沢 SCM高速化 システム障害No226対応 ------------------------------------------>>>>>
                // 全社共通項目更新処理ではデータ更新が行われていなかったため削除
                ////全社設定を更新した場合は、他の項目にも反映させる
                //if (paraWork.SectionCode == _allSecCode)
                //{
                //    UpdateAllSCMDeliDateSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                //}
                // DEL 2015/02/16 豊沢 SCM高速化 システム障害No226対応 ------------------------------------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                stockmngttlstWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMDeliDateStDB.Write(ref object scmDeliDateStWork)");
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
        /// SCM納期設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM納期設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int WriteSCMDeliDateStProc(ref ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMDeliDateStProcProc(ref scmDeliDateStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM納期設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM納期設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int WriteSCMDeliDateStProcProc(ref ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmDeliDateStWorkList != null)
                {
                    for (int i = 0; i < scmDeliDateStWorkList.Count; i++)
                    {
                        SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[i] as SCMDeliDateStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード



                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmDeliDateStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (scmDeliDateStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMDELIDATESTRF SET  " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME1RF = @ANSWERDEADTIME1 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME2RF = @ANSWERDEADTIME2 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME3RF = @ANSWERDEADTIME3 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME4RF = @ANSWERDEADTIME4 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME5RF = @ANSWERDEADTIME5 " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME6RF = @ANSWERDEADTIME6 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE1RF = @ANSWERDELIVDATE1 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE2RF = @ANSWERDELIVDATE2 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE3RF = @ANSWERDELIVDATE3 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE4RF = @ANSWERDELIVDATE4 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE5RF = @ANSWERDELIVDATE5 " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE6RF = @ANSWERDELIVDATE6 " + Environment.NewLine;
                            // 2011/01/06 Add >>>
                            sqlText += "  , ANSWERDEADTIME1STCRF = @ANSWERDEADTIME1STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME2STCRF = @ANSWERDEADTIME2STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME3STCRF = @ANSWERDEADTIME3STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME4STCRF = @ANSWERDEADTIME4STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME5STCRF = @ANSWERDEADTIME5STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDEADTIME6STCRF = @ANSWERDEADTIME6STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE1STCRF = @ANSWERDELIVDATE1STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE2STCRF = @ANSWERDELIVDATE2STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE3STCRF = @ANSWERDELIVDATE3STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE4STCRF = @ANSWERDELIVDATE4STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE5STCRF = @ANSWERDELIVDATE5STC " + Environment.NewLine;
                            sqlText += "  , ANSWERDELIVDATE6STCRF = @ANSWERDELIVDATE6STC " + Environment.NewLine;
                            sqlText += "  , ENTSTCKANSDELIDTDIVRF = @ENTSTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "  , ENTSTCKANSDELIDATERF = @ENTSTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/01/06 Add <<<
                            // 2011/10/11 Add >>>
                            sqlText += "  , PRISTCKANSDELIDTDIVRF = @PRISTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "  , PRISTCKANSDELIDATERF = @PRISTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/10/11 Add <<<
                            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "  , ANSDELDATSHORTOFSTCRF = @ANSDELDATSHORTOFSTC " + Environment.NewLine;
                            sqlText += "  , ANSDELDATWITHOUTSTCRF = @ANSDELDATWITHOUTSTC " + Environment.NewLine;
                            sqlText += "  , ENTSTCANSDELDATSHORTRF = @ENTSTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "  , ENTSTCANSDELDATWIOUTRF = @ENTSTCANSDELDATWIOUT " + Environment.NewLine;
                            sqlText += "  , PRISTCANSDELDATSHORTRF = @PRISTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "  , PRISTCANSDELDATWIOUTRF = @PRISTCANSDELDATWIOUT " + Environment.NewLine;
                            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "  , ANSDELDTDIV1RF = @ANSDELDTDIV1RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV2RF = @ANSDELDTDIV2RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV3RF = @ANSDELDTDIV3RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV4RF = @ANSDELDTDIV4RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV5RF = @ANSDELDTDIV5RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV6RF = @ANSDELDTDIV6RF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV1STCRF = @ANSDELDTDIV1STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV2STCRF = @ANSDELDTDIV2STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV3STCRF = @ANSDELDTDIV3STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV4STCRF = @ANSDELDTDIV4STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV5STCRF = @ANSDELDTDIV5STCRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTDIV6STCRF = @ANSDELDTDIV6STCRF " + Environment.NewLine;
                            sqlText += "  , ENTANSDELDTSTCDIVRF = @ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , PRIANSDELDTSTCDIVRF = @PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTSHOSTCDIVRF = @ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , ANSDELDTWIOSTCDIVRF = @ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                            sqlText += "  , ENTANSDELDTSHODIVRF = @ENTANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "  , ENTANSDELDTWIODIVRF = @ENTANSDELDTWIODIVRF " + Environment.NewLine;
                            sqlText += "  , PRIANSDELDTSHODIVRF = @PRIANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "  , PRIANSDELDTWIODIVRF = @PRIANSDELDTWIODIVRF " + Environment.NewLine;
                            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                            findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (scmDeliDateStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMDELIDATESTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME1RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME2RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME3RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME4RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME5RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME6RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE1RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE2RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE3RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE4RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE5RF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE6RF " + Environment.NewLine;
                            // 2011/01/06 Add >>>
                            sqlText += "         ,ANSWERDEADTIME1STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME2STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME3STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME4STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME5STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDEADTIME6STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE1STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE2STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE3STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE4STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE5STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSWERDELIVDATE6STCRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCKANSDELIDTDIVRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCKANSDELIDATERF " + Environment.NewLine;
                            // 2011/01/06 Add <<<
                            // 2011/10/11 Add >>>
                            sqlText += "         ,PRISTCKANSDELIDTDIVRF " + Environment.NewLine;
                            sqlText += "         ,PRISTCKANSDELIDATERF " + Environment.NewLine;
                            // 2011/10/11 Add <<<
                            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,ANSDELDATSHORTOFSTCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDATWITHOUTSTCRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCANSDELDATSHORTRF " + Environment.NewLine;
                            sqlText += "         ,ENTSTCANSDELDATWIOUTRF " + Environment.NewLine;
                            sqlText += "         ,PRISTCANSDELDATSHORTRF " + Environment.NewLine;
                            sqlText += "         ,PRISTCANSDELDATWIOUTRF " + Environment.NewLine;
                            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,ANSDELDTDIV1RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV2RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV3RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV4RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV5RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV6RF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV1STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV2STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV3STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV4STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV5STCRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTDIV6STCRF " + Environment.NewLine;
                            sqlText += "         ,ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,ENTANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,ENTANSDELDTWIODIVRF " + Environment.NewLine;
                            sqlText += "         ,PRIANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,PRIANSDELDTWIODIVRF " + Environment.NewLine;
                            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
                            sqlText += "         ,@CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME1 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME2 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME3 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME4 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME5 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME6 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE1 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE2 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE3 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE4 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE5 " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE6 " + Environment.NewLine;
                            // 2011/01/06 Add >>>
                            sqlText += "         ,@ANSWERDEADTIME1STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME2STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME3STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME4STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME5STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDEADTIME6STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE1STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE2STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE3STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE4STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE5STC " + Environment.NewLine;
                            sqlText += "         ,@ANSWERDELIVDATE6STC " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/01/06 Add <<<
                            // 2011/10/11 Add >>>
                            sqlText += "         ,@PRISTCKANSDELIDTDIV " + Environment.NewLine;
                            sqlText += "         ,@PRISTCKANSDELIDATE " + Environment.NewLine;
                            // 2011/10/11 Add <<<
                            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,@ANSDELDATSHORTOFSTC " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDATWITHOUTSTC " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "         ,@ENTSTCANSDELDATWIOUT " + Environment.NewLine;
                            sqlText += "         ,@PRISTCANSDELDATSHORT " + Environment.NewLine;
                            sqlText += "         ,@PRISTCANSDELDATWIOUT " + Environment.NewLine;
                            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += "         ,@ANSDELDTDIV1RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV2RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV3RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV4RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV5RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV6RF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV1STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV2STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV3STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV4STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV5STCRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTDIV6STCRF " + Environment.NewLine;
                            sqlText += "         ,@ENTANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@PRIANSDELDTSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
                            sqlText += "         ,@ENTANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,@ENTANSDELDTWIODIVRF " + Environment.NewLine;
                            sqlText += "         ,@PRIANSDELDTSHODIVRF " + Environment.NewLine;
                            sqlText += "         ,@PRIANSDELDTWIODIVRF " + Environment.NewLine;
                            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                        SqlParameter paraAnswerDeadTime1 = sqlCommand.Parameters.Add("@ANSWERDEADTIME1", SqlDbType.Int);  // 回答締切時刻１
                        SqlParameter paraAnswerDeadTime2 = sqlCommand.Parameters.Add("@ANSWERDEADTIME2", SqlDbType.Int);  // 回答締切時刻２
                        SqlParameter paraAnswerDeadTime3 = sqlCommand.Parameters.Add("@ANSWERDEADTIME3", SqlDbType.Int);  // 回答締切時刻３
                        SqlParameter paraAnswerDeadTime4 = sqlCommand.Parameters.Add("@ANSWERDEADTIME4", SqlDbType.Int);  // 回答締切時刻４
                        SqlParameter paraAnswerDeadTime5 = sqlCommand.Parameters.Add("@ANSWERDEADTIME5", SqlDbType.Int);  // 回答締切時刻５
                        SqlParameter paraAnswerDeadTime6 = sqlCommand.Parameters.Add("@ANSWERDEADTIME6", SqlDbType.Int);  // 回答締切時刻６
                        SqlParameter paraAnswerDelivDate1 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1", SqlDbType.NVarChar);  // 回答納期１
                        SqlParameter paraAnswerDelivDate2 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2", SqlDbType.NVarChar);  // 回答納期２
                        SqlParameter paraAnswerDelivDate3 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3", SqlDbType.NVarChar);  // 回答納期３
                        SqlParameter paraAnswerDelivDate4 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4", SqlDbType.NVarChar);  // 回答納期４
                        SqlParameter paraAnswerDelivDate5 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5", SqlDbType.NVarChar);  // 回答納期５
                        SqlParameter paraAnswerDelivDate6 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6", SqlDbType.NVarChar);  // 回答納期6
                        // 2011/01/06 Add >>>
                        SqlParameter paraAnswerDeadTime1Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME1STC", SqlDbType.Int);  // 回答締切時刻１（在庫）
                        SqlParameter paraAnswerDeadTime2Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME2STC", SqlDbType.Int);  // 回答締切時刻２（在庫）
                        SqlParameter paraAnswerDeadTime3Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME3STC", SqlDbType.Int);  // 回答締切時刻３（在庫）
                        SqlParameter paraAnswerDeadTime4Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME4STC", SqlDbType.Int);  // 回答締切時刻４（在庫）
                        SqlParameter paraAnswerDeadTime5Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME5STC", SqlDbType.Int);  // 回答締切時刻５（在庫）
                        SqlParameter paraAnswerDeadTime6Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME6STC", SqlDbType.Int);  // 回答締切時刻６（在庫）
                        SqlParameter paraAnswerDelivDate1Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1STC", SqlDbType.NVarChar);  // 回答納期１（在庫）
                        SqlParameter paraAnswerDelivDate2Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2STC", SqlDbType.NVarChar);  // 回答納期２（在庫）
                        SqlParameter paraAnswerDelivDate3Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3STC", SqlDbType.NVarChar);  // 回答納期３（在庫）
                        SqlParameter paraAnswerDelivDate4Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4STC", SqlDbType.NVarChar);  // 回答納期４（在庫）
                        SqlParameter paraAnswerDelivDate5Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5STC", SqlDbType.NVarChar);  // 回答納期５（在庫）
                        SqlParameter paraAnswerDelivDate6Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6STC", SqlDbType.NVarChar);  // 回答納期6（在庫）
                        SqlParameter paraEntStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDTDIV", SqlDbType.Int);  // 委託在庫回答納期区分
                        SqlParameter paraEntStckAnsDeliDate = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDATE", SqlDbType.NVarChar);  // 委託在庫回答納期
                        // 2011/01/06 Add <<<
                        // 2011/10/11 Add >>>
                        SqlParameter paraPriStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@PRISTCKANSDELIDTDIV", SqlDbType.Int);  // 優先在庫回答納期区分
                        SqlParameter paraPriStckAnsDeliDate = sqlCommand.Parameters.Add("@PRISTCKANSDELIDATE", SqlDbType.NVarChar);  // 優先在庫回答納期
                        // 2011/10/11 Add <<<
                        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraAnsDelDatShortOfStc = sqlCommand.Parameters.Add("@ANSDELDATSHORTOFSTC", SqlDbType.NVarChar);   // 回答納期（在庫不足）
                        SqlParameter paraAnsDelDatWithoutStc = sqlCommand.Parameters.Add("@ANSDELDATWITHOUTSTC", SqlDbType.NVarChar);   // 回答納期（在庫数無し）
                        SqlParameter paraEntStcAnsDelDatShort = sqlCommand.Parameters.Add("@ENTSTCANSDELDATSHORT", SqlDbType.NVarChar); // 委託在庫回答納期（在庫不足）
                        SqlParameter paraEntStcAnsDelDatWiout = sqlCommand.Parameters.Add("@ENTSTCANSDELDATWIOUT", SqlDbType.NVarChar); // 委託在庫回答納期（在庫数無し）
                        SqlParameter paraPriStcAnsDelDatShort = sqlCommand.Parameters.Add("@PRISTCANSDELDATSHORT", SqlDbType.NVarChar); // 参照在庫回答納期（在庫不足）
                        SqlParameter paraPriStcAnsDelDatWiout = sqlCommand.Parameters.Add("@PRISTCANSDELDATWIOUT", SqlDbType.NVarChar); // 参照在庫回答納期（在庫数無し）
                        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraAnsDelDtDiv1 = sqlCommand.Parameters.Add("@ANSDELDTDIV1RF", SqlDbType.SmallInt); // 回答納期区分１
                        SqlParameter paraAnsDelDtDiv2 = sqlCommand.Parameters.Add("@ANSDELDTDIV2RF", SqlDbType.SmallInt); // 回答納期区分２
                        SqlParameter paraAnsDelDtDiv3 = sqlCommand.Parameters.Add("@ANSDELDTDIV3RF", SqlDbType.SmallInt); // 回答納期区分３
                        SqlParameter paraAnsDelDtDiv4 = sqlCommand.Parameters.Add("@ANSDELDTDIV4RF", SqlDbType.SmallInt); // 回答納期区分４
                        SqlParameter paraAnsDelDtDiv5 = sqlCommand.Parameters.Add("@ANSDELDTDIV5RF", SqlDbType.SmallInt); // 回答納期区分５
                        SqlParameter paraAnsDelDtDiv6 = sqlCommand.Parameters.Add("@ANSDELDTDIV6RF", SqlDbType.SmallInt); // 回答納期区分６
                        SqlParameter paraAnsDelDtDiv1Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV1STCRF", SqlDbType.SmallInt); // 回答納期区分１（在庫）
                        SqlParameter paraAnsDelDtDiv2Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV2STCRF", SqlDbType.SmallInt); // 回答納期区分２（在庫）
                        SqlParameter paraAnsDelDtDiv3Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV3STCRF", SqlDbType.SmallInt); // 回答納期区分３（在庫）
                        SqlParameter paraAnsDelDtDiv4Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV4STCRF", SqlDbType.SmallInt); // 回答納期区分４（在庫）
                        SqlParameter paraAnsDelDtDiv5Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV5STCRF", SqlDbType.SmallInt); // 回答納期区分５（在庫）
                        SqlParameter paraAnsDelDtDiv6Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV6STCRF", SqlDbType.SmallInt); // 回答納期区分６（在庫）
                        SqlParameter paraEntAnsDelDtStcDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSTCDIVRF", SqlDbType.SmallInt); // 委託在庫回答納期区分（在庫）
                        SqlParameter paraPriAnsDelDtStcDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSTCDIVRF", SqlDbType.SmallInt); // 優先在庫回答納期区分（在庫）
                        SqlParameter paraAnsDelDtShoStcDiv = sqlCommand.Parameters.Add("@ANSDELDTSHOSTCDIVRF", SqlDbType.SmallInt); // 回答納期区分（在庫不足）
                        SqlParameter paraAnsDelDtWioStcDiv = sqlCommand.Parameters.Add("@ANSDELDTWIOSTCDIVRF", SqlDbType.SmallInt); // 回答納期区分（在庫数無し）
                        SqlParameter paraEntAnsDelDtShoDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSHODIVRF", SqlDbType.SmallInt); // 委託在庫回答納期区分（在庫不足）
                        SqlParameter paraEntAnsDelDtWioDiv = sqlCommand.Parameters.Add("@ENTANSDELDTWIODIVRF", SqlDbType.SmallInt); // 委託在庫回答納期区分（在庫数無し）
                        SqlParameter paraPriAnsDelDtShoDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSHODIVRF", SqlDbType.SmallInt); // 優先在庫回答納期区分（在庫不足）
                        SqlParameter paraPriAnsDelDtWioDiv = sqlCommand.Parameters.Add("@PRIANSDELDTWIODIVRF", SqlDbType.SmallInt); // 優先在庫回答納期区分（在庫数無し）
                        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmDeliDateStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード
                        paraAnswerDeadTime1.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1);  // 回答締切時刻１
                        paraAnswerDeadTime2.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2);  // 回答締切時刻２
                        paraAnswerDeadTime3.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3);  // 回答締切時刻３
                        paraAnswerDeadTime4.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4);  // 回答締切時刻４
                        paraAnswerDeadTime5.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5);  // 回答締切時刻５
                        paraAnswerDeadTime6.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6);  // 回答締切時刻６
                        paraAnswerDelivDate1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1);  // 回答納期１
                        paraAnswerDelivDate2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2);  // 回答納期２
                        paraAnswerDelivDate3.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3);  // 回答納期３
                        paraAnswerDelivDate4.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4);  // 回答納期４
                        paraAnswerDelivDate5.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5);  // 回答納期５
                        paraAnswerDelivDate6.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6);  // 回答納期6
                        // 2011/01/06 Add >>>
                        paraAnswerDeadTime1Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1Stc);  // 回答締切時刻１（在庫）
                        paraAnswerDeadTime2Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2Stc);  // 回答締切時刻２（在庫）
                        paraAnswerDeadTime3Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3Stc);  // 回答締切時刻３（在庫）
                        paraAnswerDeadTime4Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4Stc);  // 回答締切時刻４（在庫）
                        paraAnswerDeadTime5Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5Stc);  // 回答締切時刻５（在庫）
                        paraAnswerDeadTime6Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6Stc);  // 回答締切時刻６（在庫）
                        paraAnswerDelivDate1Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1Stc);  // 回答納期１（在庫）
                        paraAnswerDelivDate2Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2Stc);  // 回答納期２（在庫）
                        paraAnswerDelivDate3Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3Stc);  // 回答納期３（在庫）
                        paraAnswerDelivDate4Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4Stc);  // 回答納期４（在庫）
                        paraAnswerDelivDate5Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5Stc);  // 回答納期５（在庫）
                        paraAnswerDelivDate6Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6Stc);  // 回答納期6（在庫）
                        paraEntStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.EntStckAnsDeliDtDiv);  // 委託在庫回答納期区分
                        paraEntStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStckAnsDeliDate);  // 委託在庫回答納期
                        // 2011/01/06 Add <<<
                        // 2011/10/11 Add >>>
                        paraPriStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.PriStckAnsDeliDtDiv);  // 優先在庫回答納期区分
                        paraPriStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStckAnsDeliDate);  // 優先在庫回答納期
                        // 2011/10/11 Add <<<
                        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        paraAnsDelDatShortOfStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatShortOfStc);    // 回答納期（在庫不足）
                        paraAnsDelDatWithoutStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatWithoutStc);    // 回答納期（在庫数無し）
                        paraEntStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatShort);  // 委託在庫回答納期（在庫不足）
                        paraEntStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatWiout);  // 委託在庫回答納期（在庫数無し）
                        paraPriStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatShort);  // 参照在庫回答納期（在庫不足）
                        paraPriStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatWiout);  // 参照在庫回答納期（在庫数無し）
                        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        paraAnsDelDtDiv1.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1); // 回答納期区分１
                        paraAnsDelDtDiv2.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2); // 回答納期区分２
                        paraAnsDelDtDiv3.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3); // 回答納期区分３
                        paraAnsDelDtDiv4.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4); // 回答納期区分４
                        paraAnsDelDtDiv5.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5); // 回答納期区分５
                        paraAnsDelDtDiv6.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6); // 回答納期区分６
                        paraAnsDelDtDiv1Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1Stc); // 回答納期区分１（在庫）
                        paraAnsDelDtDiv2Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2Stc); // 回答納期区分２（在庫）
                        paraAnsDelDtDiv3Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3Stc); // 回答納期区分３（在庫）
                        paraAnsDelDtDiv4Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4Stc); // 回答納期区分４（在庫）
                        paraAnsDelDtDiv5Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5Stc); // 回答納期区分５（在庫）
                        paraAnsDelDtDiv6Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6Stc); // 回答納期区分６（在庫）
                        paraEntAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtStcDiv); // 委託在庫回答納期区分（在庫）
                        paraPriAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtStcDiv); // 優先在庫回答納期区分（在庫）
                        paraAnsDelDtShoStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtShoStcDiv); // 回答納期区分（在庫不足）
                        paraAnsDelDtWioStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtWioStcDiv); // 回答納期区分（在庫数無し）
                        paraEntAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtShoDiv); // 委託在庫回答納期区分（在庫不足）
                        paraEntAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtWioDiv); // 委託在庫回答納期区分（在庫数無し）
                        paraPriAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtShoDiv); // 優先在庫回答納期区分（在庫不足）
                        paraPriAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtWioDiv); // 優先在庫回答納期区分（在庫数無し）
                        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmDeliDateStWork);
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

            scmDeliDateStWorkList = al;

            return status;
        }

        // DEL 2015/02/16 豊沢 SCM高速化 システム障害No226対応 ------------------------------------------>>>>>
        // 全社共通項目更新処理ではデータ更新が行われていなかったため削除
        ///// <summary>
        ///// 全社共通項目を更新する
        ///// </summary>
        ///// <param name="scmDeliDateStWorkList">StockMngTtlStWorkオブジェクト</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : SCM納期設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        ///// <br>Programmer : 30350　櫻井　亮太</br>
        ///// <br>Date       : 2009.04.28</br>
        //private int UpdateAllSCMDeliDateSt(ref ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    SqlCommand sqlCommand = null;
        //    ArrayList al = new ArrayList();
        //    try
        //    {
        //        if (scmDeliDateStWorkList != null)
        //        {
        //            SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[0] as SCMDeliDateStWork;

        //            sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
        //            # region 更新時のSQL文生成
        //            string sqlText = string.Empty;
        //            sqlText += " UPDATE SCMDELIDATESTRF SET  " + Environment.NewLine;
        //            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
        //            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
        //            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
        //            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
        //            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
        //            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
        //            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
        //            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
        //            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
        //            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME1RF = @ANSWERDEADTIME1 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME2RF = @ANSWERDEADTIME2 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME3RF = @ANSWERDEADTIME3 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME4RF = @ANSWERDEADTIME4 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME5RF = @ANSWERDEADTIME5 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME6RF = @ANSWERDEADTIME6 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE1RF = @ANSWERDELIVDATE1 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE2RF = @ANSWERDELIVDATE2 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE3RF = @ANSWERDELIVDATE3 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE4RF = @ANSWERDELIVDATE4 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE5RF = @ANSWERDELIVDATE5 " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE6RF = @ANSWERDELIVDATE6 " + Environment.NewLine;
        //            // 2011/01/06 Add >>>
        //            sqlText += "  , ANSWERDEADTIME1STCRF = @ANSWERDEADTIME1STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME2STCRF = @ANSWERDEADTIME2STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME3STCRF = @ANSWERDEADTIME3STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME4STCRF = @ANSWERDEADTIME4STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME5STCRF = @ANSWERDEADTIME5STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDEADTIME6STCRF = @ANSWERDEADTIME6STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE1STCRF = @ANSWERDELIVDATE1STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE2STCRF = @ANSWERDELIVDATE2STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE3STCRF = @ANSWERDELIVDATE3STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE4STCRF = @ANSWERDELIVDATE4STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE5STCRF = @ANSWERDELIVDATE5STC " + Environment.NewLine;
        //            sqlText += "  , ANSWERDELIVDATE6STCRF = @ANSWERDELIVDATE6STC " + Environment.NewLine;
        //            sqlText += "  , ENTSTCKANSDELIDTDIVRF = @ENTSTCKANSDELIDTDIV " + Environment.NewLine;
        //            sqlText += "  , ENTSTCKANSDELIDATERF = @ENTSTCKANSDELIDATE " + Environment.NewLine;
        //            // 2011/01/06 Add <<<
        //            // 2011/10/11 Add >>>
        //            sqlText += "  , PRISTCKANSDELIDTDIVRF = @PRISTCKANSDELIDTDIV " + Environment.NewLine;
        //            sqlText += "  , PRISTCKANSDELIDATERF = @PRISTCKANSDELIDATE " + Environment.NewLine;
        //            // 2011/10/11 Add <<<
        //            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            sqlText += "  , ANSDELDATSHORTOFSTCRF = @ANSDELDATSHORTOFSTC " + Environment.NewLine;
        //            sqlText += "  , ANSDELDATWITHOUTSTCRF = @ANSDELDATWITHOUTSTC " + Environment.NewLine;
        //            sqlText += "  , ENTSTCANSDELDATSHORTRF = @ENTSTCANSDELDATSHORT " + Environment.NewLine;
        //            sqlText += "  , ENTSTCANSDELDATWIOUTRF = @ENTSTCANSDELDATWIOUT " + Environment.NewLine;
        //            sqlText += "  , PRISTCANSDELDATSHORTRF = @PRISTCANSDELDATSHORT " + Environment.NewLine;
        //            sqlText += "  , PRISTCANSDELDATWIOUTRF = @PRISTCANSDELDATWIOUT " + Environment.NewLine;
        //            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            sqlText += "  , ANSDELDTDIV1RF = @ANSDELDTDIV1RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV2RF = @ANSDELDTDIV2RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV3RF = @ANSDELDTDIV3RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV4RF = @ANSDELDTDIV4RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV5RF = @ANSDELDTDIV5RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV6RF = @ANSDELDTDIV6RF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV1STCRF = @ANSDELDTDIV1STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV2STCRF = @ANSDELDTDIV2STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV3STCRF = @ANSDELDTDIV3STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV4STCRF = @ANSDELDTDIV4STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV5STCRF = @ANSDELDTDIV5STCRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTDIV6STCRF = @ANSDELDTDIV6STCRF " + Environment.NewLine;
        //            sqlText += "  , ENTANSDELDTSTCDIVRF = @ENTANSDELDTSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , PRIANSDELDTSTCDIVRF = @PRIANSDELDTSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTSHOSTCDIVRF = @ANSDELDTSHOSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , ANSDELDTWIOSTCDIVRF = @ANSDELDTWIOSTCDIVRF " + Environment.NewLine;
        //            sqlText += "  , ENTANSDELDTSHODIVRF = @ENTANSDELDTSHODIVRF " + Environment.NewLine;
        //            sqlText += "  , ENTANSDELDTWIODIVRF = @ENTANSDELDTWIODIVRF " + Environment.NewLine;
        //            sqlText += "  , PRIANSDELDTSHODIVRF = @PRIANSDELDTSHODIVRF " + Environment.NewLine;
        //            sqlText += "  , PRIANSDELDTWIODIVRF = @PRIANSDELDTWIODIVRF " + Environment.NewLine;
        //            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
        //            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
        //            sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
        //            sqlCommand.CommandText = sqlText;

        //            //更新ヘッダ情報を設定
        //            object obj = (object)this;
        //            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
        //            FileHeader fileHeader = new FileHeader(obj);
        //            fileHeader.SetUpdateHeader(ref flhd, obj);
        //            #endregion

        //            #region Parameterオブジェクトの作成(更新用)
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
        //            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
        //            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
        //            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
        //            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
        //            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
        //            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
        //            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
        //            SqlParameter paraAnswerDeadTime1 = sqlCommand.Parameters.Add("@ANSWERDEADTIME1", SqlDbType.Int);  // 回答締切時刻１
        //            SqlParameter paraAnswerDeadTime2 = sqlCommand.Parameters.Add("@ANSWERDEADTIME2", SqlDbType.Int);  // 回答締切時刻２
        //            SqlParameter paraAnswerDeadTime3 = sqlCommand.Parameters.Add("@ANSWERDEADTIME3", SqlDbType.Int);  // 回答締切時刻３
        //            SqlParameter paraAnswerDeadTime4 = sqlCommand.Parameters.Add("@ANSWERDEADTIME4", SqlDbType.Int);  // 回答締切時刻４
        //            SqlParameter paraAnswerDeadTime5 = sqlCommand.Parameters.Add("@ANSWERDEADTIME5", SqlDbType.Int);  // 回答締切時刻５
        //            SqlParameter paraAnswerDeadTime6 = sqlCommand.Parameters.Add("@ANSWERDEADTIME6", SqlDbType.Int);  // 回答締切時刻６
        //            SqlParameter paraAnswerDelivDate1 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1", SqlDbType.NVarChar);  // 回答納期１
        //            SqlParameter paraAnswerDelivDate2 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2", SqlDbType.NVarChar);  // 回答納期２
        //            SqlParameter paraAnswerDelivDate3 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3", SqlDbType.NVarChar);  // 回答納期３
        //            SqlParameter paraAnswerDelivDate4 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4", SqlDbType.NVarChar);  // 回答納期４
        //            SqlParameter paraAnswerDelivDate5 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5", SqlDbType.NVarChar);  // 回答納期５
        //            // 2011/01/06 Add >>>
        //            SqlParameter paraAnswerDelivDate6 = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6", SqlDbType.NVarChar);  // 回答納期６
        //            SqlParameter paraAnswerDeadTime1Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME1STC", SqlDbType.Int);  // 回答締切時刻１（在庫）
        //            SqlParameter paraAnswerDeadTime2Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME2STC", SqlDbType.Int);  // 回答締切時刻２（在庫）
        //            SqlParameter paraAnswerDeadTime3Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME3STC", SqlDbType.Int);  // 回答締切時刻３（在庫）
        //            SqlParameter paraAnswerDeadTime4Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME4STC", SqlDbType.Int);  // 回答締切時刻４（在庫）
        //            SqlParameter paraAnswerDeadTime5Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME5STC", SqlDbType.Int);  // 回答締切時刻５（在庫）
        //            SqlParameter paraAnswerDeadTime6Stc = sqlCommand.Parameters.Add("@ANSWERDEADTIME6STC", SqlDbType.Int);  // 回答締切時刻６（在庫）
        //            SqlParameter paraAnswerDelivDate1Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE1STC", SqlDbType.NVarChar);  // 回答納期１（在庫）
        //            SqlParameter paraAnswerDelivDate2Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE2STC", SqlDbType.NVarChar);  // 回答納期２（在庫）
        //            SqlParameter paraAnswerDelivDate3Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE3STC", SqlDbType.NVarChar);  // 回答納期３（在庫）
        //            SqlParameter paraAnswerDelivDate4Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE4STC", SqlDbType.NVarChar);  // 回答納期４（在庫）
        //            SqlParameter paraAnswerDelivDate5Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE5STC", SqlDbType.NVarChar);  // 回答納期５（在庫）
        //            SqlParameter paraAnswerDelivDate6Stc = sqlCommand.Parameters.Add("@ANSWERDELIVDATE6STC", SqlDbType.NVarChar);  // 回答納期６（在庫）
        //            SqlParameter paraEntStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDTDIV", SqlDbType.Int);  // 委託在庫回答納期区分
        //            SqlParameter paraEntStckAnsDeliDate = sqlCommand.Parameters.Add("@ENTSTCKANSDELIDATE", SqlDbType.NVarChar);  // 委託在庫回答納期
        //            // 2011/01/06 Add <<<
        //            // 2011/10/11 Add >>>
        //            SqlParameter paraPriStckAnsDeliDtDiv = sqlCommand.Parameters.Add("@PRISTCKANSDELIDTDIV", SqlDbType.Int);  // 優先在庫回答納期区分
        //            SqlParameter paraPriStckAnsDeliDate = sqlCommand.Parameters.Add("@PRISTCKANSDELIDATE", SqlDbType.NVarChar);  // 優先在庫回答納期
        //            // 2011/10/11 Add <<<
        //            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            SqlParameter paraAnsDelDatShortOfStc = sqlCommand.Parameters.Add("@ANSDELDATSHORTOFSTC", SqlDbType.NVarChar);   // 回答納期（在庫不足）
        //            SqlParameter paraAnsDelDatWithoutStc = sqlCommand.Parameters.Add("@ANSDELDATWITHOUTSTC", SqlDbType.NVarChar);   // 回答納期（在庫数無し）
        //            SqlParameter paraEntStcAnsDelDatShort = sqlCommand.Parameters.Add("@ENTSTCANSDELDATSHORT", SqlDbType.NVarChar); // 委託在庫回答納期（在庫不足）
        //            SqlParameter paraEntStcAnsDelDatWiout = sqlCommand.Parameters.Add("@ENTSTCANSDELDATWIOUT", SqlDbType.NVarChar); // 委託在庫回答納期（在庫数無し）
        //            SqlParameter paraPriStcAnsDelDatShort = sqlCommand.Parameters.Add("@PRISTCANSDELDATSHORT", SqlDbType.NVarChar); // 参照在庫回答納期（在庫不足）
        //            SqlParameter paraPriStcAnsDelDatWiout = sqlCommand.Parameters.Add("@PRISTCANSDELDATWIOUT", SqlDbType.NVarChar); // 参照在庫回答納期（在庫数無し）
        //            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            SqlParameter paraAnsDelDtDiv1 = sqlCommand.Parameters.Add("@ANSDELDTDIV1RF", SqlDbType.SmallInt); // 回答納期区分１
        //            SqlParameter paraAnsDelDtDiv2 = sqlCommand.Parameters.Add("@ANSDELDTDIV2RF", SqlDbType.SmallInt); // 回答納期区分２
        //            SqlParameter paraAnsDelDtDiv3 = sqlCommand.Parameters.Add("@ANSDELDTDIV3RF", SqlDbType.SmallInt); // 回答納期区分３
        //            SqlParameter paraAnsDelDtDiv4 = sqlCommand.Parameters.Add("@ANSDELDTDIV4RF", SqlDbType.SmallInt); // 回答納期区分４
        //            SqlParameter paraAnsDelDtDiv5 = sqlCommand.Parameters.Add("@ANSDELDTDIV5RF", SqlDbType.SmallInt); // 回答納期区分５
        //            SqlParameter paraAnsDelDtDiv6 = sqlCommand.Parameters.Add("@ANSDELDTDIV6RF", SqlDbType.SmallInt); // 回答納期区分６
        //            SqlParameter paraAnsDelDtDiv1Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV1STCRF", SqlDbType.SmallInt); // 回答納期区分１（在庫）
        //            SqlParameter paraAnsDelDtDiv2Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV2STCRF", SqlDbType.SmallInt); // 回答納期区分２（在庫）
        //            SqlParameter paraAnsDelDtDiv3Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV3STCRF", SqlDbType.SmallInt); // 回答納期区分３（在庫）
        //            SqlParameter paraAnsDelDtDiv4Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV4STCRF", SqlDbType.SmallInt); // 回答納期区分４（在庫）
        //            SqlParameter paraAnsDelDtDiv5Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV5STCRF", SqlDbType.SmallInt); // 回答納期区分５（在庫）
        //            SqlParameter paraAnsDelDtDiv6Stc = sqlCommand.Parameters.Add("@ANSDELDTDIV6STCRF", SqlDbType.SmallInt); // 回答納期区分６（在庫）
        //            SqlParameter paraEntAnsDelDtStcDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSTCDIVRF", SqlDbType.SmallInt); // 委託在庫回答納期区分（在庫）
        //            SqlParameter paraPriAnsDelDtStcDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSTCDIVRF", SqlDbType.SmallInt); // 優先在庫回答納期区分（在庫）
        //            SqlParameter paraAnsDelDtShoStcDiv = sqlCommand.Parameters.Add("@ANSDELDTSHOSTCDIVRF", SqlDbType.SmallInt); // 回答納期区分（在庫不足）
        //            SqlParameter paraAnsDelDtWioStcDiv = sqlCommand.Parameters.Add("@ANSDELDTWIOSTCDIVRF", SqlDbType.SmallInt); // 回答納期区分（在庫数無し）
        //            SqlParameter paraEntAnsDelDtShoDiv = sqlCommand.Parameters.Add("@ENTANSDELDTSHODIVRF", SqlDbType.SmallInt); // 委託在庫回答納期区分（在庫不足）
        //            SqlParameter paraEntAnsDelDtWioDiv = sqlCommand.Parameters.Add("@ENTANSDELDTWIODIVRF", SqlDbType.SmallInt); // 委託在庫回答納期区分（在庫数無し）
        //            SqlParameter paraPriAnsDelDtShoDiv = sqlCommand.Parameters.Add("@PRIANSDELDTSHODIVRF", SqlDbType.SmallInt); // 優先在庫回答納期区分（在庫不足）
        //            SqlParameter paraPriAnsDelDtWioDiv = sqlCommand.Parameters.Add("@PRIANSDELDTWIODIVRF", SqlDbType.SmallInt); // 優先在庫回答納期区分（在庫数無し）
        //            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            #endregion

        //            #region Parameterオブジェクトへ値設定(更新用)
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.CreateDateTime);  // 作成日時
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.UpdateDateTime);  // 更新日時
        //            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
        //            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmDeliDateStWork.FileHeaderGuid);  // GUID
        //            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdEmployeeCode);  // 更新従業員コード
        //            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId1);  // 更新アセンブリID1
        //            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId2);  // 更新アセンブリID2
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.LogicalDeleteCode);  // 論理削除区分
        //            paraSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
        //            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード
        //            paraAnswerDeadTime1.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1);  // 回答締切時刻１
        //            paraAnswerDeadTime2.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2);  // 回答締切時刻２
        //            paraAnswerDeadTime3.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3);  // 回答締切時刻３
        //            paraAnswerDeadTime4.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4);  // 回答締切時刻４
        //            paraAnswerDeadTime5.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5);  // 回答締切時刻５
        //            paraAnswerDeadTime6.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6);  // 回答締切時刻６
        //            paraAnswerDelivDate1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1);  // 回答納期１
        //            paraAnswerDelivDate2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2);  // 回答納期２
        //            paraAnswerDelivDate3.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3);  // 回答納期３
        //            paraAnswerDelivDate4.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4);  // 回答納期４
        //            paraAnswerDelivDate5.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5);  // 回答納期５
        //            // 2011/01/06 Add >>>
        //            paraAnswerDelivDate6.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6);  // 回答納期６
        //            paraAnswerDeadTime1Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime1Stc);  // 回答締切時刻１（在庫）
        //            paraAnswerDeadTime2Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime2Stc);  // 回答締切時刻２（在庫）
        //            paraAnswerDeadTime3Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime3Stc);  // 回答締切時刻３（在庫）
        //            paraAnswerDeadTime4Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime4Stc);  // 回答締切時刻４（在庫）
        //            paraAnswerDeadTime5Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime5Stc);  // 回答締切時刻５（在庫）
        //            paraAnswerDeadTime6Stc.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.AnswerDeadTime6Stc);  // 回答締切時刻６（在庫）
        //            paraAnswerDelivDate1Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate1Stc);  // 回答納期１（在庫）
        //            paraAnswerDelivDate2Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate2Stc);  // 回答納期２（在庫）
        //            paraAnswerDelivDate3Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate3Stc);  // 回答納期３（在庫）
        //            paraAnswerDelivDate4Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate4Stc);  // 回答納期４（在庫）
        //            paraAnswerDelivDate5Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate5Stc);  // 回答納期５（在庫）
        //            paraAnswerDelivDate6Stc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnswerDelivDate6Stc);  // 回答納期６（在庫）
        //            paraEntStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.EntStckAnsDeliDtDiv);  // 委託在庫回答納期区分
        //            paraEntStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStckAnsDeliDate);  // 委託在庫回答納期
        //            // 2011/01/06 Add <<<
        //            // 2011/10/11 Add >>>
        //            paraPriStckAnsDeliDtDiv.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.PriStckAnsDeliDtDiv);  // 優先在庫回答納期区分
        //            paraPriStckAnsDeliDate.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStckAnsDeliDate);  // 優先在庫回答納期
        //            // 2011/10/11 Add <<<
        //            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            paraAnsDelDatShortOfStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatShortOfStc);    // 回答納期（在庫不足）
        //            paraAnsDelDatWithoutStc.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.AnsDelDatWithoutStc);    // 回答納期（在庫数無し）
        //            paraEntStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatShort);  // 委託在庫回答納期（在庫不足）
        //            paraEntStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EntStcAnsDelDatWiout);  // 委託在庫回答納期（在庫数無し）
        //            paraPriStcAnsDelDatShort.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatShort);  // 参照在庫回答納期（在庫不足）
        //            paraPriStcAnsDelDatWiout.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.PriStcAnsDelDatWiout);  // 参照在庫回答納期（在庫数無し）
        //            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //            paraAnsDelDtDiv1.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1); // 回答納期区分１
        //            paraAnsDelDtDiv2.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2); // 回答納期区分２
        //            paraAnsDelDtDiv3.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3); // 回答納期区分３
        //            paraAnsDelDtDiv4.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4); // 回答納期区分４
        //            paraAnsDelDtDiv5.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5); // 回答納期区分５
        //            paraAnsDelDtDiv6.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6); // 回答納期区分６
        //            paraAnsDelDtDiv1Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv1Stc); // 回答納期区分１（在庫）
        //            paraAnsDelDtDiv2Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv2Stc); // 回答納期区分２（在庫）
        //            paraAnsDelDtDiv3Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv3Stc); // 回答納期区分３（在庫）
        //            paraAnsDelDtDiv4Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv4Stc); // 回答納期区分４（在庫）
        //            paraAnsDelDtDiv5Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv5Stc); // 回答納期区分５（在庫）
        //            paraAnsDelDtDiv6Stc.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtDiv6Stc); // 回答納期区分６（在庫）
        //            paraEntAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtStcDiv); // 委託在庫回答納期区分（在庫）
        //            paraPriAnsDelDtStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtStcDiv); // 優先在庫回答納期区分（在庫）
        //            paraAnsDelDtShoStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtShoStcDiv); // 回答納期区分（在庫不足）
        //            paraAnsDelDtWioStcDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.AnsDelDtWioStcDiv); // 回答納期区分（在庫数無し）
        //            paraEntAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtShoDiv); // 委託在庫回答納期区分（在庫不足）
        //            paraEntAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.EntAnsDelDtWioDiv); // 委託在庫回答納期区分（在庫数無し）
        //            paraPriAnsDelDtShoDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtShoDiv); // 優先在庫回答納期区分（在庫不足）
        //            paraPriAnsDelDtWioDiv.Value = SqlDataMediator.SqlSetInt16(scmDeliDateStWork.PriAnsDelDtWioDiv); // 優先在庫回答納期区分（在庫数無し）
        //            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //            #endregion

        //            sqlCommand.ExecuteNonQuery();

        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // DEL 2015/02/16 豊沢 SCM高速化 システム障害No226対応 ------------------------------------------<<<<<

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// SCM納期設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="scmDeliDateStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM納期設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int LogicalDelete(ref object scmDeliDateStWork)
        {
            return LogicalDeleteSCMDeliDateSt(ref scmDeliDateStWork, 0);
        }

        /// <summary>
        /// 論理削除SCM農機設定マスタ情報を復活します
        /// </summary>
        /// <param name="scmDeliDateStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除SCM農機設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int RevivalLogicalDelete(ref object scmDeliDateStWork)
        {
            return LogicalDeleteSCMDeliDateSt(ref scmDeliDateStWork, 1);
        }

        /// <summary>
        /// SCM農機設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM農機設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int LogicalDeleteSCMDeliDateSt(ref object scmDeliDateStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmDeliDateStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMDeliDateStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMDeliDateStDB.LogicalDeleteSCMDeliDateSt :" + procModestr);

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
        /// SCM納期設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM納期設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int LogicalDeleteSCMDeliDateStProc(ref ArrayList scmDeliDateStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMDeliDateStProcProc(ref scmDeliDateStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM農機設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmDeliDateStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM農機設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int LogicalDeleteSCMDeliDateStProcProc(ref ArrayList scmDeliDateStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmDeliDateStWorkList != null)
                {
                    for (int i = 0; i < scmDeliDateStWorkList.Count; i++)
                    {
                        SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[i] as SCMDeliDateStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Parameterオブジェクトの作成(検索用)
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード

                        //Parameterオブジェクトへ値設定(検索用)
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmDeliDateStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMDELIDATESTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE";
                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                            findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmDeliDateStWork;
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
                            else if (logicalDelCd == 0) scmDeliDateStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else scmDeliDateStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmDeliDateStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmDeliDateStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmDeliDateStWork);
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

            scmDeliDateStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM納期設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SCM農機設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : SCM納期設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
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

                status = DeleteSCMDeliDateStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "StockMngTtlStDB.Delete");
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
        /// SCM納期設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">SCM農機設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM納期設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        public int DeleteSCMDeliDateStProc(ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMDeliDateStProcProc(scmDeliDateStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM納期設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">SCM農機設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM納期設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private int DeleteSCMDeliDateStProcProc(ArrayList scmDeliDateStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmDeliDateStWorkList.Count; i++)
                {
                    SCMDeliDateStWork scmDeliDateStWork = scmDeliDateStWorkList[i] as SCMDeliDateStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                    //Parameterオブジェクトの作成(検索用)
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード

                    //Parameterオブジェクトへ値設定(検索用)
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                    findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != scmDeliDateStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMDELIDATESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE";
                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();  // 拠点コード
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);  // 得意先コード
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
	    /// <param name="stockmngttlstWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMDeliDateStWork scmDeliDateStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "SCM.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmDeliDateStWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(scmDeliDateStWork.SectionCode) == false)
            {
                retstring += "AND SCM.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = scmDeliDateStWork.SectionCode.Trim();
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND SCM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // 得意先コード
            if (scmDeliDateStWork.CustomerCode != 0)
            {
                retstring += "AND SCM.CUSTOMERCODERF = @FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(scmDeliDateStWork.CustomerCode);
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        private SCMDeliDateStWork CopyToSCMDeliDateStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMDeliDateStWork wkSCMDeliDateStWork = new SCMDeliDateStWork();

            #region クラスへ格納
            wkSCMDeliDateStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkSCMDeliDateStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkSCMDeliDateStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkSCMDeliDateStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMDeliDateStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkSCMDeliDateStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkSCMDeliDateStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkSCMDeliDateStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkSCMDeliDateStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkSCMDeliDateStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
            wkSCMDeliDateStWork.AnswerDeadTime1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME1RF"));  // 回答締切時刻１
            wkSCMDeliDateStWork.AnswerDeadTime2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME2RF"));  // 回答締切時刻２
            wkSCMDeliDateStWork.AnswerDeadTime3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME3RF"));  // 回答締切時刻３
            wkSCMDeliDateStWork.AnswerDeadTime4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME4RF"));  // 回答締切時刻４
            wkSCMDeliDateStWork.AnswerDeadTime5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME5RF"));  // 回答締切時刻５
            wkSCMDeliDateStWork.AnswerDeadTime6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME6RF"));  // 回答締切時刻６
            wkSCMDeliDateStWork.AnswerDelivDate1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE1RF"));  // 回答納期１
            wkSCMDeliDateStWork.AnswerDelivDate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE2RF"));  // 回答納期２
            wkSCMDeliDateStWork.AnswerDelivDate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE3RF"));  // 回答納期３
            wkSCMDeliDateStWork.AnswerDelivDate4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE4RF"));  // 回答納期４
            wkSCMDeliDateStWork.AnswerDelivDate5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE5RF"));  // 回答納期５
            wkSCMDeliDateStWork.AnswerDelivDate6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE6RF"));  // 回答納期６ // 2009.08.26
            // 2011/01/06 Add >>>
            wkSCMDeliDateStWork.AnswerDeadTime1Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME1STCRF"));  // 回答締切時刻１（在庫）
            wkSCMDeliDateStWork.AnswerDeadTime2Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME2STCRF"));  // 回答締切時刻２（在庫）
            wkSCMDeliDateStWork.AnswerDeadTime3Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME3STCRF"));  // 回答締切時刻３（在庫）
            wkSCMDeliDateStWork.AnswerDeadTime4Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME4STCRF"));  // 回答締切時刻４（在庫）
            wkSCMDeliDateStWork.AnswerDeadTime5Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME5STCRF"));  // 回答締切時刻５（在庫）
            wkSCMDeliDateStWork.AnswerDeadTime6Stc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDEADTIME6STCRF"));  // 回答締切時刻６（在庫）
            wkSCMDeliDateStWork.AnswerDelivDate1Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE1STCRF"));  // 回答納期１（在庫）
            wkSCMDeliDateStWork.AnswerDelivDate2Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE2STCRF"));  // 回答納期２（在庫）
            wkSCMDeliDateStWork.AnswerDelivDate3Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE3STCRF"));  // 回答納期３（在庫）
            wkSCMDeliDateStWork.AnswerDelivDate4Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE4STCRF"));  // 回答納期４（在庫）
            wkSCMDeliDateStWork.AnswerDelivDate5Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE5STCRF"));  // 回答納期５（在庫）
            wkSCMDeliDateStWork.AnswerDelivDate6Stc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATE6STCRF"));  // 回答納期６（在庫）
            wkSCMDeliDateStWork.EntStckAnsDeliDtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTSTCKANSDELIDTDIVRF"));  // 委託在庫回答納期区分
            wkSCMDeliDateStWork.EntStckAnsDeliDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTSTCKANSDELIDATERF"));  // 委託在庫回答納期
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            wkSCMDeliDateStWork.PriStckAnsDeliDtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRISTCKANSDELIDTDIVRF"));  // 優先在庫回答納期区分
            wkSCMDeliDateStWork.PriStckAnsDeliDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRISTCKANSDELIDATERF"));  // 優先在庫回答納期
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            wkSCMDeliDateStWork.AnsDelDatShortOfStc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSDELDATSHORTOFSTCRF"));   // 回答納期（在庫不足）
            wkSCMDeliDateStWork.AnsDelDatWithoutStc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSDELDATWITHOUTSTCRF"));   // 回答納期（在庫数無し）
            wkSCMDeliDateStWork.EntStcAnsDelDatShort = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTSTCANSDELDATSHORTRF")); // 委託在庫回答納期（在庫不足）
            wkSCMDeliDateStWork.EntStcAnsDelDatWiout = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTSTCANSDELDATWIOUTRF")); // 委託在庫回答納期（在庫数無し）
            wkSCMDeliDateStWork.PriStcAnsDelDatShort = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRISTCANSDELDATSHORTRF")); // 参照在庫回答納期（在庫不足）
            wkSCMDeliDateStWork.PriStcAnsDelDatWiout = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRISTCANSDELDATWIOUTRF")); // 参照在庫回答納期（在庫数無し）
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            wkSCMDeliDateStWork.AnsDelDtDiv1 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV1RF")); // 回答納期区分１
            wkSCMDeliDateStWork.AnsDelDtDiv2 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV2RF")); // 回答納期区分２
            wkSCMDeliDateStWork.AnsDelDtDiv3 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV3RF")); // 回答納期区分３
            wkSCMDeliDateStWork.AnsDelDtDiv4 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV4RF")); // 回答納期区分４
            wkSCMDeliDateStWork.AnsDelDtDiv5 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV5RF")); // 回答納期区分５
            wkSCMDeliDateStWork.AnsDelDtDiv6 = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV6RF")); // 回答納期区分６
            wkSCMDeliDateStWork.AnsDelDtDiv1Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV1STCRF")); // 回答納期区分１（在庫）
            wkSCMDeliDateStWork.AnsDelDtDiv2Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV2STCRF")); // 回答納期区分２（在庫）
            wkSCMDeliDateStWork.AnsDelDtDiv3Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV3STCRF")); // 回答納期区分３（在庫）
            wkSCMDeliDateStWork.AnsDelDtDiv4Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV4STCRF")); // 回答納期区分４（在庫）
            wkSCMDeliDateStWork.AnsDelDtDiv5Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV5STCRF")); // 回答納期区分５（在庫）
            wkSCMDeliDateStWork.AnsDelDtDiv6Stc = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTDIV6STCRF")); // 回答納期区分６（在庫）
            wkSCMDeliDateStWork.EntAnsDelDtStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ENTANSDELDTSTCDIVRF")); // 委託在庫回答納期区分（在庫）
            wkSCMDeliDateStWork.PriAnsDelDtStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIANSDELDTSTCDIVRF")); // 優先在庫回答納期区分（在庫）
            wkSCMDeliDateStWork.AnsDelDtShoStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTSHOSTCDIVRF")); // 回答納期区分（在庫不足）
            wkSCMDeliDateStWork.AnsDelDtWioStcDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ANSDELDTWIOSTCDIVRF")); // 回答納期区分（在庫数無し）
            wkSCMDeliDateStWork.EntAnsDelDtShoDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ENTANSDELDTSHODIVRF")); // 委託在庫回答納期区分（在庫不足）
            wkSCMDeliDateStWork.EntAnsDelDtWioDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ENTANSDELDTWIODIVRF")); // 委託在庫回答納期区分（在庫数無し）
            wkSCMDeliDateStWork.PriAnsDelDtShoDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIANSDELDTSHODIVRF")); // 優先在庫回答納期区分（在庫不足）
            wkSCMDeliDateStWork.PriAnsDelDtWioDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIANSDELDTWIODIVRF")); // 優先在庫回答納期区分（在庫数無し）
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            return wkSCMDeliDateStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMDeliDateStWork[] SCMDeliDateStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SCMDeliDateStWork)
                    {
                        SCMDeliDateStWork wkSCMDeliDateStWork = paraobj as SCMDeliDateStWork;
                        if (wkSCMDeliDateStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMDeliDateStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMDeliDateStWorkArray = (SCMDeliDateStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMDeliDateStWork[]));
                        }
                        catch (Exception) { }
                        if (SCMDeliDateStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMDeliDateStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMDeliDateStWork wkSCMDeliDateStWork = (SCMDeliDateStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMDeliDateStWork));
                                if (wkSCMDeliDateStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMDeliDateStWork);
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
        /// <br>Date       : 2009.04.28</br>
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
