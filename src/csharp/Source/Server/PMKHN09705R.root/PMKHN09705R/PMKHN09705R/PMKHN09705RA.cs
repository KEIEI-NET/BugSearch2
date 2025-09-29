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
    /// 全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫管理全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30745　吉岡　孝憲</br>
    /// <br>Date       : 2012/10/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : 30745 吉岡　孝憲
    // 作 成 日  2012/11/20  修正内容 : 12/12配信 システムテスト障害№20対応
    //----------------------------------------------------------------------------//
    /// </remarks>
    [Serializable]
    public class AutoAnsItemStDB : RemoteDB, IAutoAnsItemStDB
    {
        /// <summary>
        /// 在庫管理全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// </remarks>
        public AutoAnsItemStDB()
            :
            base("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork", "AutoAnsItemStRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="autoAnsItemStWork">検索結果</param>
        /// <param name="paraAutoAnsItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します</br>
        public int Search(out object autoAnsItemStWork, object paraAutoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoAnsItemStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAutoAnsItemStProc(out autoAnsItemStWork, paraAutoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Search");
                autoAnsItemStWork = new ArrayList();
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
        /// 指定された条件の自動回答品目設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objAutoAnsItemStWork">検索結果</param>
        /// <param name="objAutoAnsItemStOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int SearchAutoAnsItemStProc(out object objAutoAnsItemStWork, object objAutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList AutoAnsItemStWorkList = new ArrayList();

            AutoAnsItemStOrderWork AutoAnsItemStOrderWork = null;

            if (objAutoAnsItemStOrderWork != null)
            {
                AutoAnsItemStOrderWork = objAutoAnsItemStOrderWork as AutoAnsItemStOrderWork;
            }
            else
            {
                AutoAnsItemStOrderWork = new AutoAnsItemStOrderWork();
            }

            int status = SearchAutoAnsItemStProc(out AutoAnsItemStWorkList, AutoAnsItemStOrderWork, readMode, logicalMode, ref sqlConnection);
            objAutoAnsItemStWork = AutoAnsItemStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">検索結果</param>
        /// <param name="autoAnsItemStOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int SearchAutoAnsItemStProc(out ArrayList autoAnsItemStWorkList, AutoAnsItemStOrderWork autoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchAutoAnsItemStProcProc(out autoAnsItemStWorkList, autoAnsItemStOrderWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objAutoAnsItemStWork">検索結果</param>
        /// <param name="objAutoAnsItemStOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc2(out object objAutoAnsItemStWork, object objAutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList autoAnsItemStWorkList = new ArrayList();

            AutoAnsItemStWork autoAnsItemStWork = null;

            if (objAutoAnsItemStOrderWork != null)
            {
                autoAnsItemStWork = objAutoAnsItemStOrderWork as AutoAnsItemStWork;
            }
            else
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            int status = ReadProc2(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            objAutoAnsItemStWork = autoAnsItemStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objAutoAnsItemStWork">検索結果</param>
        /// <param name="objAutoAnsItemStOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc3(out object objAutoAnsItemStWork, object objAutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList autoAnsItemStWorkList = new ArrayList();

            AutoAnsItemStWork autoAnsItemStWork = null;

            if (objAutoAnsItemStOrderWork != null)
            {
                autoAnsItemStWork = objAutoAnsItemStOrderWork as AutoAnsItemStWork;
            }
            else
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            int status = ReadProc3(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            objAutoAnsItemStWork = autoAnsItemStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">検索結果</param>
        /// <param name="autoAnsItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc2(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc2(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">検索結果</param>
        /// <param name="autoAnsItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc3(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc3(out autoAnsItemStWorkList, autoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">検索結果</param>
        /// <param name="AutoAnsItemStOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        private int SearchAutoAnsItemStProcProc(out ArrayList AutoAnsItemStWorkList, AutoAnsItemStOrderWork AutoAnsItemStOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;

                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, AutoAnsItemStOrderWork, logicalMode);

                string orderTxt = string.Empty;

                orderTxt += " ORDER BY    ATA.SECTIONCODERF DESC" + Environment.NewLine;
                orderTxt += "            ,ATA.CUSTOMERCODERF" + Environment.NewLine;
                orderTxt += "            ,ATA.GOODSMGROUPRF" + Environment.NewLine;
                orderTxt += "            ,ATA.BLGOODSCODERF" + Environment.NewLine;
                orderTxt += "            ,ATA.GOODSMAKERCDRF" + Environment.NewLine;
                orderTxt += "            ,ATA.PRMSETDTLNO2RF" + Environment.NewLine;

                sqlCommand.CommandText += orderTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));

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

            AutoAnsItemStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="autoAnsItemStWork">検索結果</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します</br>
        public int Read2(out object autoAnsItemStWork, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoAnsItemStWork = null;
            try
            {
                AutoAnsItemStWork paraAutoAnsItemStWork = new AutoAnsItemStWork();

                // XMLの読み込み
                paraAutoAnsItemStWork = (AutoAnsItemStWork)XmlByteSerializer.Deserialize(parabyte, typeof(AutoAnsItemStWork));
                if (paraAutoAnsItemStWork == null) return status;


                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return ReadProc2(out autoAnsItemStWork, paraAutoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Search");
                autoAnsItemStWork = new ArrayList();
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
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="autoAnsItemStWork">検索結果</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します</br>
        public int Read3(out object autoAnsItemStWork, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            autoAnsItemStWork = null;
            try
            {
                AutoAnsItemStWork paraAutoAnsItemStWork = new AutoAnsItemStWork();

                // XMLの読み込み
                paraAutoAnsItemStWork = (AutoAnsItemStWork)XmlByteSerializer.Deserialize(parabyte, typeof(AutoAnsItemStWork));
                if (paraAutoAnsItemStWork == null) return status;


                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return ReadProc3(out autoAnsItemStWork, paraAutoAnsItemStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Search");
                autoAnsItemStWork = new ArrayList();
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
        /// 指定された条件の自動回答品目設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        public int ReadProc(ref AutoAnsItemStWork autoAnsItemStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref autoAnsItemStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        private int ReadProcProc(ref AutoAnsItemStWork autoAnsItemStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " WHERE ATA.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND ATA.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "   AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;

                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                    findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        autoAnsItemStWork = CopyToAutoAnsItemStWorkFromReader(ref myReader);
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

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">検索結果</param>
        /// <param name="autoAnsItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        private int ReadProcProc2(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = new SqlCommand();
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " WHERE ATA.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND ATA.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "   AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMAKERCDRF = @FINDGOODSMAKERCD ";

                #endregion

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));
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

            autoAnsItemStWorkList = al;

            return status;
        }

        /// <summary>
        /// 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">検索結果</param>
        /// <param name="autoAnsItemStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自動回答品目設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        private int ReadProcProc3(out ArrayList autoAnsItemStWorkList, AutoAnsItemStWork autoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = new SqlCommand();
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = string.Empty;
                #region SELECT
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " WHERE ATA.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND ATA.SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                selectTxt += "   AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                selectTxt += "   AND ATA.AUTOANSWERDIVRF = 2 " + Environment.NewLine;
                selectTxt += " ORDER BY ATA.PRIORITYORDERRF " ;

                #endregion

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));
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

            autoAnsItemStWorkList = al;

            return status;
        }

        #endregion

        #region [Write]
        /// <summary>
        /// 自動回答品目設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を登録、更新します</br>
        public int Write(ref object autoAnsItemStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(autoAnsItemStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteAutoAnsItemStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                AutoAnsItemStWork paraWork = paraList[0] as AutoAnsItemStWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecAutoAnsItemSt(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                autoAnsItemStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Write(ref object AutoAnsItemStWork)");
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
        /// 自動回答品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        public int WriteAutoAnsItemStProc(ref ArrayList AutoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteAutoAnsItemStProcProc(ref AutoAnsItemStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 自動回答品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        private int WriteAutoAnsItemStProcProc(ref ArrayList autoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (autoAnsItemStWorkList != null)
                {
                    for (int i = 0; i < autoAnsItemStWorkList.Count; i++)
                    {
                        AutoAnsItemStWork autoAnsItemStWork = autoAnsItemStWorkList[i] as AutoAnsItemStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF , ENTERPRISECODERF FROM AUTOANSITEMSTRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE  AND SECTIONCODERF = @FINDSECTIONCODE  AND CUSTOMERCODERF = @FINDCUSTOMERCODE   AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                        findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != autoAnsItemStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (autoAnsItemStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE AUTOANSITEMSTRF SET " + Environment.NewLine;
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
                            sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                            sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                            sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "  , PRMSETDTLNO2RF = @PRMSETDTLNO2 " + Environment.NewLine;
                            sqlText += "  , PRMSETDTLNAME2RF = @PRMSETDTLNAME2 " + Environment.NewLine;
                            sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "  , PRIORITYORDERRF = @PRIORITYORDER " + Environment.NewLine;
                            sqlText += "  WHERE " + Environment.NewLine;
                            sqlText += "        ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                            sqlText += "    AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                            sqlText += "    AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2 " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                            findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (autoAnsItemStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO AUTOANSITEMSTRF " + Environment.NewLine;
                            sqlText += "  ( CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "   ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "   ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "   ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "   ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "   ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "   ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "   ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "   ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "   ,CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "   ,GOODSMGROUPRF " + Environment.NewLine;
                            sqlText += "   ,BLGOODSCODERF " + Environment.NewLine;
                            sqlText += "   ,GOODSMAKERCDRF " + Environment.NewLine;
                            sqlText += "   ,PRMSETDTLNO2RF " + Environment.NewLine;
                            sqlText += "   ,PRMSETDTLNAME2RF " + Environment.NewLine;
                            sqlText += "   ,AUTOANSWERDIVRF " + Environment.NewLine;
                            sqlText += "   ,PRIORITYORDERRF " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  ( @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "   ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "   ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "   ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "   ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "   ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "   ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "   ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "   ,@SECTIONCODE " + Environment.NewLine;
                            sqlText += "   ,@CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "   ,@GOODSMGROUP " + Environment.NewLine;
                            sqlText += "   ,@BLGOODSCODE " + Environment.NewLine;
                            sqlText += "   ,@GOODSMAKERCD " + Environment.NewLine;
                            sqlText += "   ,@PRMSETDTLNO2 " + Environment.NewLine;
                            sqlText += "   ,@PRMSETDTLNAME2 " + Environment.NewLine;
                            sqlText += "   ,@AUTOAWNSERDIV " + Environment.NewLine;
                            sqlText += "   ,@PRIORITYORDER " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
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
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL商品コード
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);  // 優良設定詳細コード２（種別コード）
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);  // 優良設定詳細名称
                        SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSERDIV", SqlDbType.Int);  // 自動回答区分
                        SqlParameter paraPriorityOrder = sqlCommand.Parameters.Add("@PRIORITYORDER", SqlDbType.Int);  // 優先順位

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(autoAnsItemStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();  // 拠点コード
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);  // 得意先コード
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);  // 商品中分類コード
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);  // BL商品コード
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);  // 商品メーカーコード
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);  // 優良設定詳細コード２（種別コード）
                        paraPrmSetDtlName2.Value = (object)autoAnsItemStWork.PrmSetDtlName2; // 優良設定詳細名称２（SqlDataMediator.SqlSetStringを使用すると空文字のセットができない）
                        paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.AutoAnswerDiv);  // 自動回答区分
                        paraPriorityOrder.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PriorityOrder); // 優先順位
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(autoAnsItemStWork);
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

            autoAnsItemStWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        private int UpdateAllSecAutoAnsItemSt(ref ArrayList AutoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (AutoAnsItemStWorkList != null)
                {
                    AutoAnsItemStWork autoAnsItemStWork = AutoAnsItemStWorkList[0] as AutoAnsItemStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;

                    sqlText += " UPDATE AUTOANSITEMSTRF SET " + Environment.NewLine;
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
                    sqlText += "  , GOODSMGROUPRF = @GOODSMGROUP " + Environment.NewLine;
                    sqlText += "  , BLGOODSCODERF = @BLGOODSCODE " + Environment.NewLine;
                    sqlText += "  , GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                    sqlText += "  , PRMSETDTLNO2RF = @PRMSETDTLNO2 " + Environment.NewLine;
                    sqlText += "  , PRMSETDTLNAME2RF = @PRMSETDTLNAME2 " + Environment.NewLine;
                    sqlText += "  , AUTOANSWERDIVRF = @AUTOAWNSERDIV " + Environment.NewLine;
                    sqlText += "  , PRIORITYORDERRF = @PRIORITYORDER " + Environment.NewLine;
                    sqlText += "  WHERE " + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "    AND SECTIONCODERF <>'00'" + Environment.NewLine;
                    sqlText += "    AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                    sqlText += "    AND GOODSMGROUPRF = @FINDGOODSMGROUP " + Environment.NewLine;
                    sqlText += "    AND BLGOODSCODERF = @FINDBLGOODSCODE " + Environment.NewLine;
                    sqlText += "    AND GOODSMAKERCDRF = @FINDGOODSMAKERCD " + Environment.NewLine;
                    sqlText += "    AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2 " + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                    findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
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
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);  // 商品中分類コード
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);  // BL商品コード
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);  // 商品メーカーコード
                    SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);  // 優良設定詳細コード２（種別コード）
                    SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);  // 優良設定詳細名称
                    SqlParameter paraAutoAwnser = sqlCommand.Parameters.Add("@AUTOAWNSERDIV", SqlDbType.Int);  // 自動回答区分
                    SqlParameter paraPriorityOrder = sqlCommand.Parameters.Add("@PRIORITYORDER", SqlDbType.Int);  // 優先順位

                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(autoAnsItemStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();  // 拠点コード
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);  // 得意先コード
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);  // 商品中分類コード
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);  // BL商品コード
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);  // 商品メーカーコード
                    paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);  // 優良設定詳細コード２（種別コード）
                    paraPrmSetDtlName2.Value = (object)autoAnsItemStWork.PrmSetDtlName2; // 優良設定詳細名称２（SqlDataMediator.SqlSetStringを使用すると空文字のセットができない）
                    paraAutoAwnser.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.AutoAnswerDiv);  // 自動回答区分
                    paraPriorityOrder.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PriorityOrder); // 優先順位
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
        /// 自動回答品目設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を論理削除します</br>
        public int LogicalDelete(ref object autoAnsItemStWork)
        {
            return LogicalDeleteAutoAnsItemSt(ref autoAnsItemStWork, 0);
        }

        /// <summary>
        /// 論理削除自動回答品目設定マスタ情報を復活します
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除自動回答品目設定マスタ情報を復活します</br>
        public int RevivalLogicalDelete(ref object autoAnsItemStWork)
        {
            return LogicalDeleteAutoAnsItemSt(ref autoAnsItemStWork, 1);
        }

        /// <summary>
        /// 自動回答品目設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="autoAnsItemStWork">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報の論理削除を操作します</br>
        private int LogicalDeleteAutoAnsItemSt(ref object autoAnsItemStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(autoAnsItemStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteAutoAnsItemStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
                // 戻り値の設定
                autoAnsItemStWork = paraList;

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
                base.WriteErrorLog(ex, "AutoAnsItemStDB.LogicalDeleteAutoAnsItemSt :" + procModestr);

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
        /// 自動回答品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="AutoAnsItemStWorkList">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        public int LogicalDeleteAutoAnsItemStProc(ref ArrayList AutoAnsItemStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteAutoAnsItemStProcProc(ref AutoAnsItemStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 自動回答品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">AutoAnsItemStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自動回答品目設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        private int LogicalDeleteAutoAnsItemStProcProc(ref ArrayList autoAnsItemStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (autoAnsItemStWorkList != null)
                {
                    for (int i = 0; i < autoAnsItemStWorkList.Count; i++)
                    {
                        AutoAnsItemStWork autoAnsItemStWork = autoAnsItemStWorkList[i] as AutoAnsItemStWork;

                        //Selectコマンドの生成
                        // UPD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        // sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF,  ENTERPRISECODERF FROM AUTOANSITEMSTRF " + GetWhere(), sqlConnection, sqlTransaction);
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF,  ENTERPRISECODERF FROM AUTOANSITEMSTRF " + GetWhere3(), sqlConnection, sqlTransaction);
                        // UPD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter findPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                        findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        findPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.PrmSetDtlNo2);
                        // ADD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != autoAnsItemStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE AUTOANSITEMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " + GetWhere();
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                            findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)autoAnsItemStWork;
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
                            else if (logicalDelCd == 0) autoAnsItemStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else autoAnsItemStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) autoAnsItemStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(autoAnsItemStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();

                    }

                    // 削除、復活対象となったレコードの取得
                    if (autoAnsItemStWorkList.Count > 0)
                    {
                        GetTargetRcord(myReader, sqlCommand, ref al, autoAnsItemStWorkList[0] as AutoAnsItemStWork);
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

            autoAnsItemStWorkList = al;

            return status;

        }

        /// <summary>
        /// 対象となったレコードの取得
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="al"></param>
        /// <param name="autoAnsItemStWork"></param>
        /// <returns></returns>
        private int GetTargetRcord(SqlDataReader myReader, SqlCommand sqlCommand, ref ArrayList al, AutoAnsItemStWork autoAnsItemStWork)
        {
            al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                // 対象となったレコードの取得
                #region Select
                string selectTxt = string.Empty;
                selectTxt += " SELECT   ATA.CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,ATA.UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "         ,ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "         ,ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNO2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRMSETDTLNAME2RF " + Environment.NewLine;
                selectTxt += "         ,ATA.AUTOANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,ATA.PRIORITYORDERRF " + Environment.NewLine;
                selectTxt += "         ,SEC.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "         ,CUS.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "         ,GOO.GOODSMGROUPNAMERF " + Environment.NewLine;
                selectTxt += "         ,BLG.BLGOODSFULLNAMERF " + Environment.NewLine;
                selectTxt += "         ,MAK.MAKERNAMERF " + Environment.NewLine;
                selectTxt += "  FROM AUTOANSITEMSTRF AS ATA " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
                selectTxt += "   ON  SEC.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND SEC.SECTIONCODERF = ATA.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
                selectTxt += "   ON  CUS.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND CUS.CUSTOMERCODERF = ATA.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLG " + Environment.NewLine;
                selectTxt += "   ON  BLG.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND BLG.BLGOODSCODERF = ATA.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSGROUPURF AS GOO " + Environment.NewLine;
                selectTxt += "   ON  GOO.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND GOO.GOODSMGROUPRF = ATA.GOODSMGROUPRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN MAKERURF AS MAK " + Environment.NewLine;
                selectTxt += "   ON  MAK.ENTERPRISECODERF = ATA.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "   AND MAK.GOODSMAKERCDRF = ATA.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += GetWhere2();

                #endregion

                sqlCommand.CommandText = selectTxt;
                sqlCommand.Parameters.Clear();
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAutoAnsItemStWorkFromReader(ref myReader));
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
    
            return status;
        }

        /// <summary>
        /// 優良設定詳細コード２を除いたキー項目を検索条件にしたWHERE句
        /// GetWhereとGetWhere2は同じ内容にすること
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            return "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD";
        }

        /// <summary>
        /// 優良設定詳細コード２を除いたキー項目を検索条件にしたWHERE句
        /// GetWhereとGetWhere2は同じ内容にすること
        /// </summary>
        /// <returns></returns>
        private string GetWhere2()
        {
            return "WHERE ATA.ENTERPRISECODERF=@FINDENTERPRISECODE AND ATA.SECTIONCODERF=@FINDSECTIONCODE AND ATA.CUSTOMERCODERF = @FINDCUSTOMERCODE AND ATA.GOODSMGROUPRF = @FINDGOODSMGROUP AND ATA.BLGOODSCODERF = @FINDBLGOODSCODE AND ATA.GOODSMAKERCDRF = @FINDGOODSMAKERCD";
        }
        
        // ADD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// キー項目を検索条件にしたWHERE句
        /// </summary>
        /// <returns></returns>
        private string GetWhere3()
        {
            return "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND GOODSMGROUPRF = @FINDGOODSMGROUP AND BLGOODSCODERF = @FINDBLGOODSCODE AND GOODSMAKERCDRF = @FINDGOODSMAKERCD AND PRMSETDTLNO2RF = @PRMSETDTLNO2";
        }
        // ADD 2012/11/20 T.Yoshioka 2012/12/12配信 システムテスト障害№20 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region [Delete]
        /// <summary>
        /// 自動回答品目設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">自動回答品目設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を物理削除します</br>
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

                status = DeleteAutoAnsItemStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "AutoAnsItemStDB.Delete");
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
        /// 自動回答品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">自動回答品目設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        public int DeleteAutoAnsItemStProc(ArrayList autoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteAutoAnsItemStProcProc(autoAnsItemStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 自動回答品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="autoAnsItemStWorkList">自動回答品目設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 自動回答品目設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        private int DeleteAutoAnsItemStProcProc(ArrayList autoAnsItemStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                for (int i = 0; i < autoAnsItemStWorkList.Count; i++)
                {
                    AutoAnsItemStWork autoAnsItemStWork = autoAnsItemStWorkList[i] as AutoAnsItemStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM AUTOANSITEMSTRF " 
                                              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                                              +   " AND SECTIONCODERF  = @FINDSECTIONCODE "
                                              +   " AND CUSTOMERCODERF = @FINDCUSTOMERCODE "
                                              +   " AND GOODSMGROUPRF  = @FINDGOODSMGROUP "
                                              +   " AND BLGOODSCODERF  = @FINDBLGOODSCODE "
                                              +   " AND GOODSMAKERCDRF = @FINDGOODSMAKERCD "
                                              , sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                    findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                    findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != autoAnsItemStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM AUTOANSITEMSTRF "
                                              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                                              + " AND SECTIONCODERF  = @FINDSECTIONCODE "
                                              + " AND CUSTOMERCODERF = @FINDCUSTOMERCODE "
                                              + " AND GOODSMGROUPRF  = @FINDGOODSMGROUP "
                                              + " AND BLGOODSCODERF  = @FINDBLGOODSCODE "
                                              + " AND GOODSMAKERCDRF = @FINDGOODSMAKERCD ";

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(autoAnsItemStWork.EnterpriseCode);
                        findParaSectionCode.Value = autoAnsItemStWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.CustomerCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMGroup);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.BLGoodsCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(autoAnsItemStWork.GoodsMakerCd);
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
        /// <param name="AutoAnsItemStOrderWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30745　吉岡　孝憲</br>
        /// <br>Date       : 2012/10/25</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AutoAnsItemStOrderWork AutoAnsItemStOrderWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ATA.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(AutoAnsItemStOrderWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(AutoAnsItemStOrderWork.SectionCode) == false)
            {
                retstring += "AND ATA.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(AutoAnsItemStOrderWork.SectionCode);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND ATA.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND ATA.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            // 得意先コード
            if (AutoAnsItemStOrderWork.St_CustomerCode != 0)
            {
                retstring += "AND ATA.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_CustomerCode);
            }
            if (AutoAnsItemStOrderWork.Ed_CustomerCode != 0)
            {
                retstring += "AND ATA.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_CustomerCode);
            }

            // 商品中分類コード
            if (AutoAnsItemStOrderWork.St_GoodsMGroup != 0) 
            {
                retstring += "AND ATA.GOODSMGROUPRF >= @FINDSTGOODSMGROUP ";
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@FINDSTGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_GoodsMGroup);
            } 
            if (AutoAnsItemStOrderWork.Ed_GoodsMGroup != 0)
            {
                retstring += "AND ATA.GOODSMGROUPRF <= @FINDEDGOODSMGROUP ";
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@FINDEDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_GoodsMGroup);
            }

            // BL商品コード
            if (AutoAnsItemStOrderWork.St_BLGoodsCode != 0)
            {
                retstring += "AND ATA.BLGOODSCODERF >= @FINDSTBLGOODSCODE ";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@FINDSTBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_BLGoodsCode);
            }
            if (AutoAnsItemStOrderWork.Ed_BLGoodsCode != 0)
            {
                retstring += "AND ATA.BLGOODSCODERF <= @FINDEDBLGOODSCODE ";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@FINDEDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_BLGoodsCode);
            }

            // メーカーコード
            if (AutoAnsItemStOrderWork.St_GoodsMakerCd != 0)
            {
                retstring += "AND ATA.GOODSMAKERCDRF >= @FINDSTGOODSMAKERCD ";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.St_GoodsMakerCd);
            }
            if (AutoAnsItemStOrderWork.Ed_GoodsMakerCd != 0)
            {
                retstring += "AND ATA.GOODSMAKERCDRF <= @FINDEDGOODSMAKERCD ";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@FINDEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(AutoAnsItemStOrderWork.Ed_GoodsMakerCd);
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
        /// </remarks>
        private AutoAnsItemStWork CopyToAutoAnsItemStWorkFromReader(ref SqlDataReader myReader)
        {
            AutoAnsItemStWork wkAutoAnsItemStWork = new AutoAnsItemStWork();
            #region クラスへ格納
            wkAutoAnsItemStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkAutoAnsItemStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkAutoAnsItemStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkAutoAnsItemStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkAutoAnsItemStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkAutoAnsItemStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkAutoAnsItemStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkAutoAnsItemStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkAutoAnsItemStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkAutoAnsItemStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
            wkAutoAnsItemStWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));  // 商品中分類コード
            wkAutoAnsItemStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  // BL商品コード
            wkAutoAnsItemStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  // 商品メーカーコード
            wkAutoAnsItemStWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));  // 優良設定詳細コード２
            wkAutoAnsItemStWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));  // 優良設定詳細名称２
            wkAutoAnsItemStWork.AutoAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVRF"));  // 自動回答区分
            wkAutoAnsItemStWork.PriorityOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYORDERRF"));  // 優先順位
            wkAutoAnsItemStWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  // 拠点名称
            wkAutoAnsItemStWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));  // 得意先名称
            wkAutoAnsItemStWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));  // 商品中分類名称
            wkAutoAnsItemStWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));  // BL商品コード名称
            wkAutoAnsItemStWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // メーカー名称
            #endregion
            return wkAutoAnsItemStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            AutoAnsItemStWork[] autoAnsItemStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is AutoAnsItemStWork)
                    {
                        AutoAnsItemStWork wkAutoAnsItemStWork = paraobj as AutoAnsItemStWork;
                        if (wkAutoAnsItemStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkAutoAnsItemStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            autoAnsItemStWorkArray = (AutoAnsItemStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(AutoAnsItemStWork[]));
                        }
                        catch (Exception) { }
                        if (autoAnsItemStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(autoAnsItemStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                AutoAnsItemStWork wkAutoAnsItemStWork = (AutoAnsItemStWork)XmlByteSerializer.Deserialize(byteArray, typeof(AutoAnsItemStWork));
                                if (wkAutoAnsItemStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkAutoAnsItemStWork);
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
