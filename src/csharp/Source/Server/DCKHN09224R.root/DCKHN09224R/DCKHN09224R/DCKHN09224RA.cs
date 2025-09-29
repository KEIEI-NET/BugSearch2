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
using Broadleaf.Application.Common;
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081  山田 明友</br>
    /// <br>Date       : 2007.12.11</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.18 山田 明友</br>
    /// <br>           : 自動入金金種関連を追加</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.26 山田 明友</br>
    /// <br>           : 入出荷区分2・値引名称を追加</br>
    /// <br>Update Note: 2008.06.11 22008 長内 数馬 PM.NS用に修正</br>
    /// <br>Update Note: 2009/10/19 朱俊成</br>
    /// <br>             PM.NS-3-A・保守依頼②</br>
    /// <br>             表示区分プロセスを追加</br>
    /// <br>Update Note: 2010/01/29 李侠</br>
    /// <br>             PM1003・四次改良</br>
    /// <br>             受注数入力を追加</br>
    /// <br>Update Note: 2010/04/30 姜凱</br>
    /// <br>             PM1007D・自由検索</br>
    /// <br>             自由検索部品自動登録区分を追加</br>    
    /// <br>Update Note: 2010/05/04 王海立</br>
    /// <br>             PM1007・6次改良</br>
    /// <br>             発行者チェック区分、入力倉庫チェック区分を追加</br>
    /// <br>Update Note: 2010/05/14 21024 佐々木 健</br>
    /// <br>             ・６次改良</br>
    /// <br>             BLコード検索品名表示区分１～４、品番検索品名表示区分１～４、優良部品検索品名使用区分を追加</br> 
    /// <br>Update Note: 2010/08/04 楊明俊</br>
    /// <br>             PM1012</br>
    /// <br>             小数点表示区分を追加</br>
    /// <br>Update Note: 2011/06/06 長内数馬</br>
    /// <br>             販売区分表示区分追加</br>
    /// <br>Update Note: 2012/04/23 福田康夫</br>
    /// <br>             貸出仕入区分追加</br>
    /// <br>Update Note: 2012/12/27 脇田靖之</br>
    /// <br>             自社品番印字対応</br>
    /// <br>Update Note: 2013/01/15 FSI福原 一樹</br>
    /// <br>             仕入返品予定機能区分を追加</br>
    /// <br>Update Note: 2013/01/21 cheq</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33797 自動入金備考区分を追加</br>
    /// <br>Update Note: 2013/02/05 脇田靖之</br>
    /// <br>             ＢＬコード０対応</br>
    /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
    /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
    /// </remarks>
    [Serializable]

    
    public class SalesTtlStDB : RemoteDB, ISalesTtlStDB, IGetSyncdataList
    {
        /// <summary>
        /// 売上全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// </remarks>
        public SalesTtlStDB()
            :
            base("DCKHN09266D", "Broadleaf.Application.Remoting.ParamData.SalesTtlStWork", "SALESTTLSTRF")
        {
        }

        #region [GetSyncdataList]
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata"></param>
        /// <param name="syncServiceWork"></param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}

		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata"></param>
        /// <param name="syncServiceWork"></param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM SALESTTLSTRF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSalesTtlStWorkFromReader(ref myReader,1));

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
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork"></param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の売上全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="salesTtlStWork">検索結果</param>
        /// <param name="parasalesTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int Search(out object salesTtlStWork, object parasalesTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesTtlStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesTtlStProc(out salesTtlStWork, parasalesTtlStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesTtlStDB.Search");
                salesTtlStWork = new ArrayList();
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
        /// 指定された条件の売上全体設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsalesTtlStWork">検索結果</param>
        /// <param name="searchSalesTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int SearchSalesTtlStProc(out object objsalesTtlStWork, object searchSalesTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SalesTtlStWork salesTtlStParaWork = null;

            ArrayList salesTtlStWorkList = searchSalesTtlStParaWork as ArrayList;
            if (salesTtlStWorkList == null)
            {
                salesTtlStParaWork = searchSalesTtlStParaWork as SalesTtlStWork;
            }
            else
            {
                if (salesTtlStWorkList.Count > 0)
                    salesTtlStParaWork = salesTtlStWorkList[0] as SalesTtlStWork;
            }
            
            int status = SearchSalesTtlStProc(out salesTtlStWorkList, salesTtlStParaWork, readMode, logicalMode, ref sqlConnection);
            objsalesTtlStWork = salesTtlStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">検索結果</param>
        /// <param name="searchSalesTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int SearchSalesTtlStProc(out ArrayList salesTtlStWorkList, SalesTtlStWork searchSalesTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
            SqlTransaction sqlTransaction = null;
            return this.SearchSalesTtlStProcProc(out salesTtlStWorkList, searchSalesTtlStParaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">検索結果</param>
        /// <param name="searchSalesTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int SearchSalesTtlStProc(out ArrayList salesTtlStWorkList, SalesTtlStWork searchSalesTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchSalesTtlStProcProc(out salesTtlStWorkList, searchSalesTtlStParaWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">検索結果</param>
        /// <param name="searchSalesTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int SearchSalesTtlStProcProc(out ArrayList salesTtlStWorkList, SalesTtlStWork searchSalesTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT SAS.*, SEC.SECTIONGUIDENMRF FROM SALESTTLSTRF AS SAS" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     SAS.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SAS.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;

                if (sqlTransaction == null)
                {
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                }
                else
                {
                    //商品構成リモートからの呼び出しに対応
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection,sqlTransaction);
                }

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchSalesTtlStParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSalesTtlStWorkFromReader(ref myReader,0));

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
                    if (!myReader.IsClosed) myReader.Close();
            }

            salesTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の売上全体設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">SalesTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                SalesTtlStWork salesTtlStWork = new SalesTtlStWork();

                // XMLの読み込み
                salesTtlStWork = (SalesTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalesTtlStWork));
                if (salesTtlStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref salesTtlStWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(salesTtlStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesTtlStDB.Read");
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
        /// 指定された条件の売上全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int ReadProc(ref SalesTtlStWork salesTtlStWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref salesTtlStWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の売上全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int ReadProcProc(ref SalesTtlStWork salesTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                SqlDataReader myReader = null;

                try
                {
                    //Selectコマンドの生成
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT SAS.*, SEC.SECTIONGUIDENMRF FROM SALESTTLSTRF AS SAS "
                                                                    + "LEFT JOIN SECINFOSETRF AS SEC "
                                                                    + "ON "
                                                                    + "     SAS.ENTERPRISECODERF=SEC.ENTERPRISECODERF "
                                                                    + " AND SAS.SECTIONCODERF=SEC.SECTIONCODERF "
                                                                    + "WHERE SAS.ENTERPRISECODERF=@FINDENTERPRISECODE AND SAS.SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                    {

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            salesTtlStWork = CopyToSalesTtlStWorkFromReader(ref myReader,0);
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
                        if (!myReader.IsClosed) myReader.Close();
                }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 売上全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int Write(ref object salesTtlStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(salesTtlStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSalesTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                salesTtlStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesTtlStDB.Write(ref object salesTtlStWork)");
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
        /// 売上全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">SalesTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int WriteSalesTtlStProc(ref ArrayList salesTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteSalesTtlStProcProc(ref salesTtlStWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 売上全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">SalesTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/06 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        private int WriteSalesTtlStProcProc(ref ArrayList salesTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (salesTtlStWorkList != null)
                {
                    for (int i = 0; i < salesTtlStWorkList.Count; i++)
                    {
                        SalesTtlStWork salesTtlStWork = salesTtlStWorkList[i] as SalesTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != salesTtlStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (salesTtlStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008/12/09 G.Miyatsu DEL
                            //sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            
                            // 2008/12/09 G.Miyatsu ADD

                            // --- DEL 2012/12/27 Y.Wakita ---------->>>>>
                            //// -- UPD 2012/04/23 -------------------->>>
                            //// -- UPD 2011/06/06 -------------------->>>
                            //////// --- UPD 2010/08/04---------->>>>>
                            //////// 2010/05/14 >>>
                            ////////// --- UPD 2010/05/04 ---------->>>>>
                            ////////// --- UPD 2010/01/29 ---------->>>>>
                            //////////// --- ADD 2009/10/19 ---------->>>>>
                            //////////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //////////// --- ADD 2009/10/19 ----------<<<<<
                            //////////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV ,ACPODRINPUTDIVRF=@ACPODRINPUTDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            ////////// --- UPD 2010/01/29 ----------<<<<<
                            ////////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV ,ACPODRINPUTDIVRF=@ACPODRINPUTDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV ,INPAGENTCHKDIVRF=@INPAGENTCHKDIV ,INPWAREHCHKDIVRF=@INPWAREHCHKDIV , FRSRCHPRTAUTOENTDIVRF = @FRSRCHPRTAUTOENTDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";

                            ////////// --- UPD 2010/05/04 ----------<<<<<
                            //////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV ,ACPODRINPUTDIVRF=@ACPODRINPUTDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV ,INPAGENTCHKDIVRF=@INPAGENTCHKDIV ,INPWAREHCHKDIVRF=@INPWAREHCHKDIV , FRSRCHPRTAUTOENTDIVRF = @FRSRCHPRTAUTOENTDIV ,BLCDPRTSNMDSPDIVCD1RF = @BLCDPRTSNMDSPDIVCD1 , BLCDPRTSNMDSPDIVCD2RF = @BLCDPRTSNMDSPDIVCD2 , BLCDPRTSNMDSPDIVCD3RF = @BLCDPRTSNMDSPDIVCD3 , BLCDPRTSNMDSPDIVCD4RF = @BLCDPRTSNMDSPDIVCD4 , GDNOPRTSNMDSPDIVCD1RF = @GDNOPRTSNMDSPDIVCD1 , GDNOPRTSNMDSPDIVCD2RF = @GDNOPRTSNMDSPDIVCD2 , GDNOPRTSNMDSPDIVCD3RF = @GDNOPRTSNMDSPDIVCD3 , GDNOPRTSNMDSPDIVCD4RF = @GDNOPRTSNMDSPDIVCD4 , PRMPRTSNMUSEDIVCDRF = @PRMPRTSNMUSEDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";

                            //////// 2010/05/14 <<<
                            ////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV ,ACPODRINPUTDIVRF=@ACPODRINPUTDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV ,INPAGENTCHKDIVRF=@INPAGENTCHKDIV ,INPWAREHCHKDIVRF=@INPWAREHCHKDIV , FRSRCHPRTAUTOENTDIVRF = @FRSRCHPRTAUTOENTDIV ,BLCDPRTSNMDSPDIVCD1RF = @BLCDPRTSNMDSPDIVCD1 , BLCDPRTSNMDSPDIVCD2RF = @BLCDPRTSNMDSPDIVCD2 , BLCDPRTSNMDSPDIVCD3RF = @BLCDPRTSNMDSPDIVCD3 , BLCDPRTSNMDSPDIVCD4RF = @BLCDPRTSNMDSPDIVCD4 , GDNOPRTSNMDSPDIVCD1RF = @GDNOPRTSNMDSPDIVCD1 , GDNOPRTSNMDSPDIVCD2RF = @GDNOPRTSNMDSPDIVCD2 , GDNOPRTSNMDSPDIVCD3RF = @GDNOPRTSNMDSPDIVCD3 , GDNOPRTSNMDSPDIVCD4RF = @GDNOPRTSNMDSPDIVCD4 , PRMPRTSNMUSEDIVCDRF = @PRMPRTSNMUSEDIVCD, DWNPLCDSPDIVCDRF = @DWNPLCDSPDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //////// --- UPD 2010/08/04----------<<<<<
                            ////sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV ,ACPODRINPUTDIVRF=@ACPODRINPUTDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV ,INPAGENTCHKDIVRF=@INPAGENTCHKDIV ,INPWAREHCHKDIVRF=@INPWAREHCHKDIV , FRSRCHPRTAUTOENTDIVRF = @FRSRCHPRTAUTOENTDIV ,BLCDPRTSNMDSPDIVCD1RF = @BLCDPRTSNMDSPDIVCD1 , BLCDPRTSNMDSPDIVCD2RF = @BLCDPRTSNMDSPDIVCD2 , BLCDPRTSNMDSPDIVCD3RF = @BLCDPRTSNMDSPDIVCD3 , BLCDPRTSNMDSPDIVCD4RF = @BLCDPRTSNMDSPDIVCD4 , GDNOPRTSNMDSPDIVCD1RF = @GDNOPRTSNMDSPDIVCD1 , GDNOPRTSNMDSPDIVCD2RF = @GDNOPRTSNMDSPDIVCD2 , GDNOPRTSNMDSPDIVCD3RF = @GDNOPRTSNMDSPDIVCD3 , GDNOPRTSNMDSPDIVCD4RF = @GDNOPRTSNMDSPDIVCD4 , PRMPRTSNMUSEDIVCDRF = @PRMPRTSNMUSEDIVCD, DWNPLCDSPDIVCDRF = @DWNPLCDSPDIVCD , SALESCDDSPDIVCDRF = @SALESCDDSPDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            ////// -- UPD 2011/06/06 --------------------<<<
                            //sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SALESSLIPPRTDIVRF=@SALESSLIPPRTDIV , SHIPMSLIPPRTDIVRF=@SHIPMSLIPPRTDIV , SHIPMSLIPUNPRCPRTDIVRF=@SHIPMSLIPUNPRCPRTDIV , GRSPROFITCHECKLOWERRF=@GRSPROFITCHECKLOWER , GRSPROFITCHECKBESTRF=@GRSPROFITCHECKBEST , GRSPROFITCHECKUPPERRF=@GRSPROFITCHECKUPPER , GRSPROFITCHKLOWSIGNRF=@GRSPROFITCHKLOWSIGN , GRSPROFITCHKBESTSIGNRF=@GRSPROFITCHKBESTSIGN , GRSPROFITCHKUPRSIGNRF=@GRSPROFITCHKUPRSIGN , GRSPROFITCHKMAXSIGNRF=@GRSPROFITCHKMAXSIGN , SALESAGENTCHNGDIVRF=@SALESAGENTCHNGDIV , ACPODRAGENTDISPDIVRF=@ACPODRAGENTDISPDIV , BRSLIPNOTE2DISPDIVRF=@BRSLIPNOTE2DISPDIV , DTLNOTEDISPDIVRF=@DTLNOTEDISPDIV , UNPRCNONSETTINGDIVRF=@UNPRCNONSETTINGDIV , ESTMATEADDUPREMDIVRF=@ESTMATEADDUPREMDIV , ACPODRRADDUPREMDIVRF=@ACPODRRADDUPREMDIV , SHIPMADDUPREMDIVRF=@SHIPMADDUPREMDIV , RETGOODSSTOCKETYDIVRF=@RETGOODSSTOCKETYDIV , LISTPRICESELECTDIVRF=@LISTPRICESELECTDIV , MAKERINPDIVRF=@MAKERINPDIV , BLGOODSCDINPDIVRF=@BLGOODSCDINPDIV , SUPPLIERINPDIVRF=@SUPPLIERINPDIV , SUPPLIERSLIPDELDIVRF=@SUPPLIERSLIPDELDIV , CUSTGUIDEDISPDIVRF=@CUSTGUIDEDISPDIV , SLIPCHNGDIVDATERF=@SLIPCHNGDIVDATE , SLIPCHNGDIVCOSTRF=@SLIPCHNGDIVCOST , SLIPCHNGDIVUNPRCRF=@SLIPCHNGDIVUNPRC , SLIPCHNGDIVLPRICERF=@SLIPCHNGDIVLPRICE , RETSLIPCHNGDIVCOSTRF=@RETSLIPCHNGDIVCOST , RETSLIPCHNGDIVUNPRCRF=@RETSLIPCHNGDIVUNPRC , AUTODEPOKINDCODERF=@AUTODEPOKINDCODE , AUTODEPOKINDNAMERF=@AUTODEPOKINDNAME , AUTODEPOKINDDIVCDRF=@AUTODEPOKINDDIVCD , DISCOUNTNAMERF=@DISCOUNTNAME , INPAGENTDISPDIVRF=@INPAGENTDISPDIV , CUSTORDERNODISPDIVRF=@CUSTORDERNODISPDIV , CARMNGNODISPDIVRF=@CARMNGNODISPDIV , PRICESELECTDISPDIVRF=@PRICESELECTDISPDIV ,ACPODRINPUTDIVRF=@ACPODRINPUTDIV , BRSLIPNOTE3DISPDIVRF=@BRSLIPNOTE3DISPDIV , SLIPDATECLRDIVCDRF=@SLIPDATECLRDIVCD , AUTOENTRYGOODSDIVCDRF=@AUTOENTRYGOODSDIVCD , COSTCHECKDIVCDRF=@COSTCHECKDIVCD , JOININITDISPDIVRF=@JOININITDISPDIV , AUTODEPOSITCDRF=@AUTODEPOSITCD , SUBSTCONDDIVCDRF=@SUBSTCONDDIVCD , SLIPCREATEPROCESSRF=@SLIPCREATEPROCESS , WAREHOUSECHKDIVRF=@WAREHOUSECHKDIV , PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD , GRSPROFITDSPCDRF=@GRSPROFITDSPCD , PARTSSEARCHPRIDIVCDRF=@PARTSSEARCHPRIDIVCD , SALESSTOCKDIVRF=@SALESSTOCKDIV , PRTBLGOODSCODEDIVRF=@PRTBLGOODSCODEDIV , SECTDSPDIVCDRF=@SECTDSPDIVCD , GOODSNMREDISPDIVCDRF=@GOODSNMREDISPDIVCD , COSTDSPDIVCDRF=@COSTDSPDIVCD , DEPOSLIPDATECLRDIVRF=@DEPOSLIPDATECLRDIV , DEPOSLIPDATEAMBITRF=@DEPOSLIPDATEAMBIT , INPGRSPROFCHKLOWERRF=@INPGRSPROFCHKLOWER , INPGRSPROFCHKUPPERRF=@INPGRSPROFCHKUPPER , INPGRSPRFCHKLOWDIVRF=@INPGRSPRFCHKLOWDIV , INPGRSPRFCHKUPPDIVRF=@INPGRSPRFCHKUPPDIV , PRMSUBSTCONDDIVCDRF=@PRMSUBSTCONDDIVCD , SUBSTAPPLYDIVCDRF=@SUBSTAPPLYDIVCD , PARTSNAMEDSPDIVCDRF=@PARTSNAMEDSPDIVCD , BLGOODSCDDERIVNODIVRF = @BLGOODSCDDERIVNODIV ,INPAGENTCHKDIVRF=@INPAGENTCHKDIV ,INPWAREHCHKDIVRF=@INPWAREHCHKDIV , FRSRCHPRTAUTOENTDIVRF = @FRSRCHPRTAUTOENTDIV ,BLCDPRTSNMDSPDIVCD1RF = @BLCDPRTSNMDSPDIVCD1 , BLCDPRTSNMDSPDIVCD2RF = @BLCDPRTSNMDSPDIVCD2 , BLCDPRTSNMDSPDIVCD3RF = @BLCDPRTSNMDSPDIVCD3 , BLCDPRTSNMDSPDIVCD4RF = @BLCDPRTSNMDSPDIVCD4 , GDNOPRTSNMDSPDIVCD1RF = @GDNOPRTSNMDSPDIVCD1 , GDNOPRTSNMDSPDIVCD2RF = @GDNOPRTSNMDSPDIVCD2 , GDNOPRTSNMDSPDIVCD3RF = @GDNOPRTSNMDSPDIVCD3 , GDNOPRTSNMDSPDIVCD4RF = @GDNOPRTSNMDSPDIVCD4 , PRMPRTSNMUSEDIVCDRF = @PRMPRTSNMUSEDIVCD, DWNPLCDSPDIVCDRF = @DWNPLCDSPDIVCD, SALESCDDSPDIVCDRF = @SALESCDDSPDIVCD, RENTSTOCKDIVRF = @RENTSTOCKDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //// -- UPD 2012/04/23 --------------------<<<
                            // --- DEL 2012/12/27 Y.Wakita ----------<<<<<
                            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                            string sqlText = "";
                            sqlText += "UPDATE SALESTTLSTRF SET " + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF       = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += ", UPDATEDATETIMERF       = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += ", ENTERPRISECODERF       = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += ", FILEHEADERGUIDRF       = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += ", UPDEMPLOYEECODERF      = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += ", UPDASSEMBLYID1RF       = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += ", UPDASSEMBLYID2RF       = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += ", LOGICALDELETECODERF    = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += ", SECTIONCODERF          = @SECTIONCODE " + Environment.NewLine;
                            sqlText += ", SALESSLIPPRTDIVRF      = @SALESSLIPPRTDIV " + Environment.NewLine;
                            sqlText += ", SHIPMSLIPPRTDIVRF      = @SHIPMSLIPPRTDIV " + Environment.NewLine;
                            sqlText += ", SHIPMSLIPUNPRCPRTDIVRF = @SHIPMSLIPUNPRCPRTDIV " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHECKLOWERRF  = @GRSPROFITCHECKLOWER " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHECKBESTRF   = @GRSPROFITCHECKBEST " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHECKUPPERRF  = @GRSPROFITCHECKUPPER " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHKLOWSIGNRF  = @GRSPROFITCHKLOWSIGN " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHKBESTSIGNRF = @GRSPROFITCHKBESTSIGN " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHKUPRSIGNRF  = @GRSPROFITCHKUPRSIGN " + Environment.NewLine;
                            sqlText += ", GRSPROFITCHKMAXSIGNRF  = @GRSPROFITCHKMAXSIGN " + Environment.NewLine;
                            sqlText += ", SALESAGENTCHNGDIVRF    = @SALESAGENTCHNGDIV " + Environment.NewLine;
                            sqlText += ", ACPODRAGENTDISPDIVRF   = @ACPODRAGENTDISPDIV " + Environment.NewLine;
                            sqlText += ", BRSLIPNOTE2DISPDIVRF   = @BRSLIPNOTE2DISPDIV " + Environment.NewLine;
                            sqlText += ", DTLNOTEDISPDIVRF       = @DTLNOTEDISPDIV " + Environment.NewLine;
                            sqlText += ", UNPRCNONSETTINGDIVRF   = @UNPRCNONSETTINGDIV " + Environment.NewLine;
                            sqlText += ", ESTMATEADDUPREMDIVRF   = @ESTMATEADDUPREMDIV " + Environment.NewLine;
                            sqlText += ", ACPODRRADDUPREMDIVRF   = @ACPODRRADDUPREMDIV " + Environment.NewLine;
                            sqlText += ", SHIPMADDUPREMDIVRF     = @SHIPMADDUPREMDIV " + Environment.NewLine;
                            sqlText += ", RETGOODSSTOCKETYDIVRF  = @RETGOODSSTOCKETYDIV " + Environment.NewLine;
                            sqlText += ", LISTPRICESELECTDIVRF   = @LISTPRICESELECTDIV " + Environment.NewLine;
                            sqlText += ", MAKERINPDIVRF          = @MAKERINPDIV " + Environment.NewLine;
                            sqlText += ", BLGOODSCDINPDIVRF      = @BLGOODSCDINPDIV " + Environment.NewLine;
                            sqlText += ", SUPPLIERINPDIVRF       = @SUPPLIERINPDIV " + Environment.NewLine;
                            sqlText += ", SUPPLIERSLIPDELDIVRF   = @SUPPLIERSLIPDELDIV " + Environment.NewLine;
                            sqlText += ", CUSTGUIDEDISPDIVRF     = @CUSTGUIDEDISPDIV " + Environment.NewLine;
                            sqlText += ", SLIPCHNGDIVDATERF      = @SLIPCHNGDIVDATE " + Environment.NewLine;
                            sqlText += ", SLIPCHNGDIVCOSTRF      = @SLIPCHNGDIVCOST " + Environment.NewLine;
                            sqlText += ", SLIPCHNGDIVUNPRCRF     = @SLIPCHNGDIVUNPRC " + Environment.NewLine;
                            sqlText += ", SLIPCHNGDIVLPRICERF    = @SLIPCHNGDIVLPRICE " + Environment.NewLine;
                            sqlText += ", RETSLIPCHNGDIVCOSTRF   = @RETSLIPCHNGDIVCOST " + Environment.NewLine;
                            sqlText += ", RETSLIPCHNGDIVUNPRCRF  = @RETSLIPCHNGDIVUNPRC " + Environment.NewLine;
                            sqlText += ", AUTODEPOKINDCODERF     = @AUTODEPOKINDCODE " + Environment.NewLine;
                            sqlText += ", AUTODEPOKINDNAMERF     = @AUTODEPOKINDNAME " + Environment.NewLine;
                            sqlText += ", AUTODEPOKINDDIVCDRF    = @AUTODEPOKINDDIVCD " + Environment.NewLine;
                            sqlText += ", DISCOUNTNAMERF         = @DISCOUNTNAME " + Environment.NewLine;
                            sqlText += ", INPAGENTDISPDIVRF      = @INPAGENTDISPDIV " + Environment.NewLine;
                            sqlText += ", CUSTORDERNODISPDIVRF   = @CUSTORDERNODISPDIV " + Environment.NewLine;
                            sqlText += ", CARMNGNODISPDIVRF      = @CARMNGNODISPDIV " + Environment.NewLine;
                            sqlText += ", PRICESELECTDISPDIVRF   = @PRICESELECTDISPDIV " + Environment.NewLine;
                            sqlText += ", ACPODRINPUTDIVRF       = @ACPODRINPUTDIV " + Environment.NewLine;
                            sqlText += ", BRSLIPNOTE3DISPDIVRF   = @BRSLIPNOTE3DISPDIV " + Environment.NewLine;
                            sqlText += ", SLIPDATECLRDIVCDRF     = @SLIPDATECLRDIVCD " + Environment.NewLine;
                            sqlText += ", AUTOENTRYGOODSDIVCDRF  = @AUTOENTRYGOODSDIVCD " + Environment.NewLine;
                            sqlText += ", COSTCHECKDIVCDRF       = @COSTCHECKDIVCD " + Environment.NewLine;
                            sqlText += ", JOININITDISPDIVRF      = @JOININITDISPDIV " + Environment.NewLine;
                            sqlText += ", AUTODEPOSITCDRF        = @AUTODEPOSITCD " + Environment.NewLine;
                            sqlText += ", SUBSTCONDDIVCDRF       = @SUBSTCONDDIVCD " + Environment.NewLine;
                            sqlText += ", SLIPCREATEPROCESSRF    = @SLIPCREATEPROCESS " + Environment.NewLine;
                            sqlText += ", WAREHOUSECHKDIVRF      = @WAREHOUSECHKDIV " + Environment.NewLine;
                            sqlText += ", PARTSSEARCHDIVCDRF     = @PARTSSEARCHDIVCD " + Environment.NewLine;
                            sqlText += ", GRSPROFITDSPCDRF       = @GRSPROFITDSPCD " + Environment.NewLine;
                            sqlText += ", PARTSSEARCHPRIDIVCDRF  = @PARTSSEARCHPRIDIVCD " + Environment.NewLine;
                            sqlText += ", SALESSTOCKDIVRF        = @SALESSTOCKDIV " + Environment.NewLine;
                            sqlText += ", PRTBLGOODSCODEDIVRF    = @PRTBLGOODSCODEDIV " + Environment.NewLine;
                            sqlText += ", SECTDSPDIVCDRF         = @SECTDSPDIVCD " + Environment.NewLine;
                            sqlText += ", GOODSNMREDISPDIVCDRF   = @GOODSNMREDISPDIVCD " + Environment.NewLine;
                            sqlText += ", COSTDSPDIVCDRF         = @COSTDSPDIVCD " + Environment.NewLine;
                            sqlText += ", DEPOSLIPDATECLRDIVRF   = @DEPOSLIPDATECLRDIV " + Environment.NewLine;
                            sqlText += ", DEPOSLIPDATEAMBITRF    = @DEPOSLIPDATEAMBIT " + Environment.NewLine;
                            sqlText += ", INPGRSPROFCHKLOWERRF   = @INPGRSPROFCHKLOWER " + Environment.NewLine;
                            sqlText += ", INPGRSPROFCHKUPPERRF   = @INPGRSPROFCHKUPPER " + Environment.NewLine;
                            sqlText += ", INPGRSPRFCHKLOWDIVRF   = @INPGRSPRFCHKLOWDIV " + Environment.NewLine;
                            sqlText += ", INPGRSPRFCHKUPPDIVRF   = @INPGRSPRFCHKUPPDIV " + Environment.NewLine;
                            sqlText += ", PRMSUBSTCONDDIVCDRF    = @PRMSUBSTCONDDIVCD " + Environment.NewLine;
                            sqlText += ", SUBSTAPPLYDIVCDRF      = @SUBSTAPPLYDIVCD " + Environment.NewLine;
                            sqlText += ", PARTSNAMEDSPDIVCDRF    = @PARTSNAMEDSPDIVCD " + Environment.NewLine;
                            sqlText += ", BLGOODSCDDERIVNODIVRF  = @BLGOODSCDDERIVNODIV " + Environment.NewLine;
                            sqlText += ", INPAGENTCHKDIVRF       = @INPAGENTCHKDIV " + Environment.NewLine;
                            sqlText += ", INPWAREHCHKDIVRF       = @INPWAREHCHKDIV " + Environment.NewLine;
                            sqlText += ", FRSRCHPRTAUTOENTDIVRF  = @FRSRCHPRTAUTOENTDIV " + Environment.NewLine;
                            sqlText += ", BLCDPRTSNMDSPDIVCD1RF  = @BLCDPRTSNMDSPDIVCD1 " + Environment.NewLine;
                            sqlText += ", BLCDPRTSNMDSPDIVCD2RF  = @BLCDPRTSNMDSPDIVCD2 " + Environment.NewLine;
                            sqlText += ", BLCDPRTSNMDSPDIVCD3RF  = @BLCDPRTSNMDSPDIVCD3 " + Environment.NewLine;
                            sqlText += ", BLCDPRTSNMDSPDIVCD4RF  = @BLCDPRTSNMDSPDIVCD4 " + Environment.NewLine;
                            sqlText += ", GDNOPRTSNMDSPDIVCD1RF  = @GDNOPRTSNMDSPDIVCD1 " + Environment.NewLine;
                            sqlText += ", GDNOPRTSNMDSPDIVCD2RF  = @GDNOPRTSNMDSPDIVCD2 " + Environment.NewLine;
                            sqlText += ", GDNOPRTSNMDSPDIVCD3RF  = @GDNOPRTSNMDSPDIVCD3 " + Environment.NewLine;
                            sqlText += ", GDNOPRTSNMDSPDIVCD4RF  = @GDNOPRTSNMDSPDIVCD4 " + Environment.NewLine;
                            sqlText += ", PRMPRTSNMUSEDIVCDRF    = @PRMPRTSNMUSEDIVCD " + Environment.NewLine;
                            sqlText += ", DWNPLCDSPDIVCDRF       = @DWNPLCDSPDIVCD " + Environment.NewLine;
                            sqlText += ", SALESCDDSPDIVCDRF      = @SALESCDDSPDIVCD " + Environment.NewLine;
                            sqlText += ", RENTSTOCKDIVRF         = @RENTSTOCKDIV " + Environment.NewLine;
                            sqlText += ", EPPARTSNOPRTCDRF       = @EPPARTSNOPRTCD " + Environment.NewLine;
                            sqlText += ", EPPARTSNOADDCHARRF     = @EPPARTSNOADDCHAR " + Environment.NewLine;
                            sqlText += ", PRINTGOODSNODEFRF      = @PRINTGOODSNODEF " + Environment.NewLine;     // ADD 2013/01/16 Y.Wakita
							sqlText += ", STOCKRETGOODSPLNDIVRF  = @STOCKRETGOODSPLNDIV " + Environment.NewLine;		// ADD 2013/01/15
                            sqlText += ", AUTODEPOSITNOTEDIVRF   = @AUTODEPOSITNOTEDIV " + Environment.NewLine;  // ADD cheq 2013/01/21 Redmine#33797 
                            sqlText += ", BLGOODSCDZEROSUPRTRF   = @BLGOODSCDZEROSUPRT " + Environment.NewLine;     // ADD 2013/02/05 Y.Wakita
                            sqlText += ", BLGOODSCDCHANGERF      = @BLGOODSCDCHANGE " + Environment.NewLine;     // ADD 2013/02/05 Y.Wakita
                            sqlText += ", STOCKEMPREFDIVRF      = @STOCKEMPREFDIV " + Environment.NewLine;     // ADD 2017/04/13 譚洪 Redmine#49283
                            sqlText += "WHERE ENTERPRISECODERF   = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF      = @FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);
                            
                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)salesTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (salesTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            //新規作成時のSQL文を生成

                            // 2008/12/09 G.Miyatsu DEL
                            //sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF, BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD)";
                            // 2008/12/09 G.Miyatsu ADD

                            // --- DEL 2012/12/27 Y.Wakita ---------->>>>>
                            //// -- UPD 2012/04/23 ------------------------->>>
                            //// -- UPD 2011/06/06 ------------------------->>>
                            //////// --- UPD 2010/08/04---------->>>>>
                            //////// 2010/05/14 >>>
                            ////////// --- UPD 2010/05/04 ---------->>>>>
                            ////////// --- UPD 2010/01/29 ---------->>>>>
                            //////////// --- ADD 2009/10/19 ---------->>>>>
                            //////////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV )";
                            //////////// --- ADD 2009/10/19 ----------<<<<<
                            //////////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,ACPODRINPUTDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@ACPODRINPUTDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV)";
                            ////////// --- UPD 2010/01/29 ----------<<<<<
                            ////////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,ACPODRINPUTDIVRF,INPAGENTCHKDIVRF,INPWAREHCHKDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF  ,FRSRCHPRTAUTOENTDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@ACPODRINPUTDIV,@INPAGENTCHKDIV,@INPWAREHCHKDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV ,@FRSRCHPRTAUTOENTDIV)";
                            ////////// --- UPD 2010/05/04 ----------<<<<<
                            //////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,ACPODRINPUTDIVRF,INPAGENTCHKDIVRF,INPWAREHCHKDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF  ,FRSRCHPRTAUTOENTDIVRF,BLCDPRTSNMDSPDIVCD1RF, BLCDPRTSNMDSPDIVCD2RF, BLCDPRTSNMDSPDIVCD3RF, BLCDPRTSNMDSPDIVCD4RF, GDNOPRTSNMDSPDIVCD1RF, GDNOPRTSNMDSPDIVCD2RF, GDNOPRTSNMDSPDIVCD3RF, GDNOPRTSNMDSPDIVCD4RF, PRMPRTSNMUSEDIVCDRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@ACPODRINPUTDIV,@INPAGENTCHKDIV,@INPWAREHCHKDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV ,@FRSRCHPRTAUTOENTDIV, @BLCDPRTSNMDSPDIVCD1, @BLCDPRTSNMDSPDIVCD2, @BLCDPRTSNMDSPDIVCD3, @BLCDPRTSNMDSPDIVCD4, @GDNOPRTSNMDSPDIVCD1, @GDNOPRTSNMDSPDIVCD2, @GDNOPRTSNMDSPDIVCD3, @GDNOPRTSNMDSPDIVCD4, @PRMPRTSNMUSEDIVCD )";
                            //////// 2010/05/14 <<<
                            ////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,ACPODRINPUTDIVRF,INPAGENTCHKDIVRF,INPWAREHCHKDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF  ,FRSRCHPRTAUTOENTDIVRF,BLCDPRTSNMDSPDIVCD1RF, BLCDPRTSNMDSPDIVCD2RF, BLCDPRTSNMDSPDIVCD3RF, BLCDPRTSNMDSPDIVCD4RF, GDNOPRTSNMDSPDIVCD1RF, GDNOPRTSNMDSPDIVCD2RF, GDNOPRTSNMDSPDIVCD3RF, GDNOPRTSNMDSPDIVCD4RF, PRMPRTSNMUSEDIVCDRF, DWNPLCDSPDIVCDRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@ACPODRINPUTDIV,@INPAGENTCHKDIV,@INPWAREHCHKDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV ,@FRSRCHPRTAUTOENTDIV, @BLCDPRTSNMDSPDIVCD1, @BLCDPRTSNMDSPDIVCD2, @BLCDPRTSNMDSPDIVCD3, @BLCDPRTSNMDSPDIVCD4, @GDNOPRTSNMDSPDIVCD1, @GDNOPRTSNMDSPDIVCD2, @GDNOPRTSNMDSPDIVCD3, @GDNOPRTSNMDSPDIVCD4, @PRMPRTSNMUSEDIVCD, @DWNPLCDSPDIVCD )";
                            //////// --- UPD 2010/08/04----------<<<<<
                            ////sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,ACPODRINPUTDIVRF,INPAGENTCHKDIVRF,INPWAREHCHKDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF  ,FRSRCHPRTAUTOENTDIVRF,BLCDPRTSNMDSPDIVCD1RF, BLCDPRTSNMDSPDIVCD2RF, BLCDPRTSNMDSPDIVCD3RF, BLCDPRTSNMDSPDIVCD4RF, GDNOPRTSNMDSPDIVCD1RF, GDNOPRTSNMDSPDIVCD2RF, GDNOPRTSNMDSPDIVCD3RF, GDNOPRTSNMDSPDIVCD4RF, PRMPRTSNMUSEDIVCDRF, DWNPLCDSPDIVCDRF, SALESCDDSPDIVCDRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@ACPODRINPUTDIV,@INPAGENTCHKDIV,@INPWAREHCHKDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV ,@FRSRCHPRTAUTOENTDIV, @BLCDPRTSNMDSPDIVCD1, @BLCDPRTSNMDSPDIVCD2, @BLCDPRTSNMDSPDIVCD3, @BLCDPRTSNMDSPDIVCD4, @GDNOPRTSNMDSPDIVCD1, @GDNOPRTSNMDSPDIVCD2, @GDNOPRTSNMDSPDIVCD3, @GDNOPRTSNMDSPDIVCD4, @PRMPRTSNMUSEDIVCD, @DWNPLCDSPDIVCD , @SALESCDDSPDIVCD )";
                            ////// -- UPD 2011/06/06 -------------------------<<<
                            //sqlCommand.CommandText = "INSERT INTO SALESTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SALESSLIPPRTDIVRF, SHIPMSLIPPRTDIVRF, SHIPMSLIPUNPRCPRTDIVRF, GRSPROFITCHECKLOWERRF, GRSPROFITCHECKBESTRF, GRSPROFITCHECKUPPERRF, GRSPROFITCHKLOWSIGNRF, GRSPROFITCHKBESTSIGNRF, GRSPROFITCHKUPRSIGNRF, GRSPROFITCHKMAXSIGNRF, SALESAGENTCHNGDIVRF, ACPODRAGENTDISPDIVRF, BRSLIPNOTE2DISPDIVRF, DTLNOTEDISPDIVRF, UNPRCNONSETTINGDIVRF, ESTMATEADDUPREMDIVRF, ACPODRRADDUPREMDIVRF, SHIPMADDUPREMDIVRF, RETGOODSSTOCKETYDIVRF, LISTPRICESELECTDIVRF, MAKERINPDIVRF, BLGOODSCDINPDIVRF, SUPPLIERINPDIVRF, SUPPLIERSLIPDELDIVRF, CUSTGUIDEDISPDIVRF, SLIPCHNGDIVDATERF, SLIPCHNGDIVCOSTRF, SLIPCHNGDIVUNPRCRF, SLIPCHNGDIVLPRICERF, RETSLIPCHNGDIVCOSTRF, RETSLIPCHNGDIVUNPRCRF, AUTODEPOKINDCODERF, AUTODEPOKINDNAMERF, AUTODEPOKINDDIVCDRF, DISCOUNTNAMERF, INPAGENTDISPDIVRF, CUSTORDERNODISPDIVRF, CARMNGNODISPDIVRF,PRICESELECTDISPDIVRF,ACPODRINPUTDIVRF,INPAGENTCHKDIVRF,INPWAREHCHKDIVRF,BRSLIPNOTE3DISPDIVRF, SLIPDATECLRDIVCDRF, AUTOENTRYGOODSDIVCDRF, COSTCHECKDIVCDRF, JOININITDISPDIVRF, AUTODEPOSITCDRF, SUBSTCONDDIVCDRF, SLIPCREATEPROCESSRF, WAREHOUSECHKDIVRF, PARTSSEARCHDIVCDRF, GRSPROFITDSPCDRF, PARTSSEARCHPRIDIVCDRF, SALESSTOCKDIVRF, PRTBLGOODSCODEDIVRF, SECTDSPDIVCDRF, GOODSNMREDISPDIVCDRF, COSTDSPDIVCDRF, DEPOSLIPDATECLRDIVRF, DEPOSLIPDATEAMBITRF, INPGRSPROFCHKLOWERRF, INPGRSPROFCHKUPPERRF, INPGRSPRFCHKLOWDIVRF, INPGRSPRFCHKUPPDIVRF, PRMSUBSTCONDDIVCDRF, SUBSTAPPLYDIVCDRF, PARTSNAMEDSPDIVCDRF ,BLGOODSCDDERIVNODIVRF  ,FRSRCHPRTAUTOENTDIVRF,BLCDPRTSNMDSPDIVCD1RF, BLCDPRTSNMDSPDIVCD2RF, BLCDPRTSNMDSPDIVCD3RF, BLCDPRTSNMDSPDIVCD4RF, GDNOPRTSNMDSPDIVCD1RF, GDNOPRTSNMDSPDIVCD2RF, GDNOPRTSNMDSPDIVCD3RF, GDNOPRTSNMDSPDIVCD4RF, PRMPRTSNMUSEDIVCDRF, DWNPLCDSPDIVCDRF, SALESCDDSPDIVCDRF, RENTSTOCKDIVRF ) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SALESSLIPPRTDIV, @SHIPMSLIPPRTDIV, @SHIPMSLIPUNPRCPRTDIV, @GRSPROFITCHECKLOWER, @GRSPROFITCHECKBEST, @GRSPROFITCHECKUPPER, @GRSPROFITCHKLOWSIGN, @GRSPROFITCHKBESTSIGN, @GRSPROFITCHKUPRSIGN, @GRSPROFITCHKMAXSIGN, @SALESAGENTCHNGDIV, @ACPODRAGENTDISPDIV, @BRSLIPNOTE2DISPDIV, @DTLNOTEDISPDIV, @UNPRCNONSETTINGDIV, @ESTMATEADDUPREMDIV, @ACPODRRADDUPREMDIV, @SHIPMADDUPREMDIV, @RETGOODSSTOCKETYDIV, @LISTPRICESELECTDIV, @MAKERINPDIV, @BLGOODSCDINPDIV, @SUPPLIERINPDIV, @SUPPLIERSLIPDELDIV, @CUSTGUIDEDISPDIV, @SLIPCHNGDIVDATE, @SLIPCHNGDIVCOST, @SLIPCHNGDIVUNPRC, @SLIPCHNGDIVLPRICE, @RETSLIPCHNGDIVCOST, @RETSLIPCHNGDIVUNPRC, @AUTODEPOKINDCODE, @AUTODEPOKINDNAME, @AUTODEPOKINDDIVCD, @DISCOUNTNAME, @INPAGENTDISPDIV, @CUSTORDERNODISPDIV, @CARMNGNODISPDIV,@PRICESELECTDISPDIV,@ACPODRINPUTDIV,@INPAGENTCHKDIV,@INPWAREHCHKDIV, @BRSLIPNOTE3DISPDIV, @SLIPDATECLRDIVCD, @AUTOENTRYGOODSDIVCD, @COSTCHECKDIVCD, @JOININITDISPDIV, @AUTODEPOSITCD, @SUBSTCONDDIVCD, @SLIPCREATEPROCESS, @WAREHOUSECHKDIV, @PARTSSEARCHDIVCD, @GRSPROFITDSPCD, @PARTSSEARCHPRIDIVCD, @SALESSTOCKDIV, @PRTBLGOODSCODEDIV, @SECTDSPDIVCD, @GOODSNMREDISPDIVCD, @COSTDSPDIVCD, @DEPOSLIPDATECLRDIV, @DEPOSLIPDATEAMBIT, @INPGRSPROFCHKLOWER, @INPGRSPROFCHKUPPER, @INPGRSPRFCHKLOWDIV, @INPGRSPRFCHKUPPDIV, @PRMSUBSTCONDDIVCD, @SUBSTAPPLYDIVCD, @PARTSNAMEDSPDIVCD ,@BLGOODSCDDERIVNODIV ,@FRSRCHPRTAUTOENTDIV, @BLCDPRTSNMDSPDIVCD1, @BLCDPRTSNMDSPDIVCD2, @BLCDPRTSNMDSPDIVCD3, @BLCDPRTSNMDSPDIVCD4, @GDNOPRTSNMDSPDIVCD1, @GDNOPRTSNMDSPDIVCD2, @GDNOPRTSNMDSPDIVCD3, @GDNOPRTSNMDSPDIVCD4, @PRMPRTSNMUSEDIVCD, @DWNPLCDSPDIVCD, @SALESCDDSPDIVCD, @RENTSTOCKDIV )";
                            //// -- UPD 2012/04/23 ------------------------->>>
                            // --- DEL 2012/12/27 Y.Wakita ----------<<<<<
                            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                            string sqlText = "";
                            sqlText += "INSERT INTO SALESTTLSTRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  , SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += "  , SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += "  , SHIPMSLIPUNPRCPRTDIVRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHECKLOWERRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHECKBESTRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHECKUPPERRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHKLOWSIGNRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHKBESTSIGNRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHKUPRSIGNRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITCHKMAXSIGNRF" + Environment.NewLine;
                            sqlText += "  , SALESAGENTCHNGDIVRF" + Environment.NewLine;
                            sqlText += "  , ACPODRAGENTDISPDIVRF" + Environment.NewLine;
                            sqlText += "  , BRSLIPNOTE2DISPDIVRF" + Environment.NewLine;
                            sqlText += "  , DTLNOTEDISPDIVRF" + Environment.NewLine;
                            sqlText += "  , UNPRCNONSETTINGDIVRF" + Environment.NewLine;
                            sqlText += "  , ESTMATEADDUPREMDIVRF" + Environment.NewLine;
                            sqlText += "  , ACPODRRADDUPREMDIVRF" + Environment.NewLine;
                            sqlText += "  , SHIPMADDUPREMDIVRF" + Environment.NewLine;
                            sqlText += "  , RETGOODSSTOCKETYDIVRF" + Environment.NewLine;
                            sqlText += "  , LISTPRICESELECTDIVRF" + Environment.NewLine;
                            sqlText += "  , MAKERINPDIVRF" + Environment.NewLine;
                            sqlText += "  , BLGOODSCDINPDIVRF" + Environment.NewLine;
                            sqlText += "  , SUPPLIERINPDIVRF" + Environment.NewLine;
                            sqlText += "  , SUPPLIERSLIPDELDIVRF" + Environment.NewLine;
                            sqlText += "  , CUSTGUIDEDISPDIVRF" + Environment.NewLine;
                            sqlText += "  , SLIPCHNGDIVDATERF" + Environment.NewLine;
                            sqlText += "  , SLIPCHNGDIVCOSTRF" + Environment.NewLine;
                            sqlText += "  , SLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                            sqlText += "  , SLIPCHNGDIVLPRICERF" + Environment.NewLine;
                            sqlText += "  , RETSLIPCHNGDIVCOSTRF" + Environment.NewLine;
                            sqlText += "  , RETSLIPCHNGDIVUNPRCRF" + Environment.NewLine;
                            sqlText += "  , AUTODEPOKINDCODERF" + Environment.NewLine;
                            sqlText += "  , AUTODEPOKINDNAMERF" + Environment.NewLine;
                            sqlText += "  , AUTODEPOKINDDIVCDRF" + Environment.NewLine;
                            sqlText += "  , DISCOUNTNAMERF" + Environment.NewLine;
                            sqlText += "  , INPAGENTDISPDIVRF" + Environment.NewLine;
                            sqlText += "  , CUSTORDERNODISPDIVRF" + Environment.NewLine;
                            sqlText += "  , CARMNGNODISPDIVRF" + Environment.NewLine;
                            sqlText += "  , PRICESELECTDISPDIVRF" + Environment.NewLine;
                            sqlText += "  , ACPODRINPUTDIVRF" + Environment.NewLine;
                            sqlText += "  , INPAGENTCHKDIVRF" + Environment.NewLine;
                            sqlText += "  , INPWAREHCHKDIVRF" + Environment.NewLine;
                            sqlText += "  , BRSLIPNOTE3DISPDIVRF" + Environment.NewLine;
                            sqlText += "  , SLIPDATECLRDIVCDRF" + Environment.NewLine;
                            sqlText += "  , AUTOENTRYGOODSDIVCDRF" + Environment.NewLine;
                            sqlText += "  , COSTCHECKDIVCDRF" + Environment.NewLine;
                            sqlText += "  , JOININITDISPDIVRF" + Environment.NewLine;
                            sqlText += "  , AUTODEPOSITCDRF" + Environment.NewLine;
                            sqlText += "  , SUBSTCONDDIVCDRF" + Environment.NewLine;
                            sqlText += "  , SLIPCREATEPROCESSRF" + Environment.NewLine;
                            sqlText += "  , WAREHOUSECHKDIVRF" + Environment.NewLine;
                            sqlText += "  , PARTSSEARCHDIVCDRF" + Environment.NewLine;
                            sqlText += "  , GRSPROFITDSPCDRF" + Environment.NewLine;
                            sqlText += "  , PARTSSEARCHPRIDIVCDRF" + Environment.NewLine;
                            sqlText += "  , SALESSTOCKDIVRF" + Environment.NewLine;
                            sqlText += "  , PRTBLGOODSCODEDIVRF" + Environment.NewLine;
                            sqlText += "  , SECTDSPDIVCDRF" + Environment.NewLine;
                            sqlText += "  , GOODSNMREDISPDIVCDRF" + Environment.NewLine;
                            sqlText += "  , COSTDSPDIVCDRF" + Environment.NewLine;
                            sqlText += "  , DEPOSLIPDATECLRDIVRF" + Environment.NewLine;
                            sqlText += "  , DEPOSLIPDATEAMBITRF" + Environment.NewLine;
                            sqlText += "  , INPGRSPROFCHKLOWERRF" + Environment.NewLine;
                            sqlText += "  , INPGRSPROFCHKUPPERRF" + Environment.NewLine;
                            sqlText += "  , INPGRSPRFCHKLOWDIVRF" + Environment.NewLine;
                            sqlText += "  , INPGRSPRFCHKUPPDIVRF" + Environment.NewLine;
                            sqlText += "  , PRMSUBSTCONDDIVCDRF" + Environment.NewLine;
                            sqlText += "  , SUBSTAPPLYDIVCDRF" + Environment.NewLine;
                            sqlText += "  , PARTSNAMEDSPDIVCDRF" + Environment.NewLine;
                            sqlText += "  , BLGOODSCDDERIVNODIVRF" + Environment.NewLine;
                            sqlText += "  , FRSRCHPRTAUTOENTDIVRF" + Environment.NewLine;
                            sqlText += "  , BLCDPRTSNMDSPDIVCD1RF" + Environment.NewLine;
                            sqlText += "  , BLCDPRTSNMDSPDIVCD2RF" + Environment.NewLine;
                            sqlText += "  , BLCDPRTSNMDSPDIVCD3RF" + Environment.NewLine;
                            sqlText += "  , BLCDPRTSNMDSPDIVCD4RF" + Environment.NewLine;
                            sqlText += "  , GDNOPRTSNMDSPDIVCD1RF" + Environment.NewLine;
                            sqlText += "  , GDNOPRTSNMDSPDIVCD2RF" + Environment.NewLine;
                            sqlText += "  , GDNOPRTSNMDSPDIVCD3RF" + Environment.NewLine;
                            sqlText += "  , GDNOPRTSNMDSPDIVCD4RF" + Environment.NewLine;
                            sqlText += "  , PRMPRTSNMUSEDIVCDRF" + Environment.NewLine;
                            sqlText += "  , DWNPLCDSPDIVCDRF" + Environment.NewLine;
                            sqlText += "  , SALESCDDSPDIVCDRF" + Environment.NewLine;
                            sqlText += "  , RENTSTOCKDIVRF" + Environment.NewLine;
                            sqlText += "  , EPPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += "  , EPPARTSNOADDCHARRF" + Environment.NewLine;
                            sqlText += "  , PRINTGOODSNODEFRF" + Environment.NewLine;    // ADD 2013/01/16 Y.Wakita
							sqlText += "  , STOCKRETGOODSPLNDIVRF" + Environment.NewLine;  // ADD 2013/01/15
                            sqlText += "  , AUTODEPOSITNOTEDIVRF" + Environment.NewLine; // ADD cheq 2013/01/21 Redmine#33797 
                            sqlText += "  , BLGOODSCDZEROSUPRTRF" + Environment.NewLine;    // ADD 2013/02/05 Y.Wakita
                            sqlText += "  , BLGOODSCDCHANGERF" + Environment.NewLine;    // ADD 2013/02/05 Y.Wakita
                            sqlText += "  , STOCKEMPREFDIVRF" + Environment.NewLine;    // ADD 2017/04/13 譚洪 Redmine#49283
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "    @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  , @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  , @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  , @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  , @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  , @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  , @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  , @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  , @SECTIONCODE" + Environment.NewLine;
                            sqlText += "  , @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += "  , @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += "  , @SHIPMSLIPUNPRCPRTDIV" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHECKLOWER" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHECKBEST" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHECKUPPER" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHKLOWSIGN" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHKBESTSIGN" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHKUPRSIGN" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITCHKMAXSIGN" + Environment.NewLine;
                            sqlText += "  , @SALESAGENTCHNGDIV" + Environment.NewLine;
                            sqlText += "  , @ACPODRAGENTDISPDIV" + Environment.NewLine;
                            sqlText += "  , @BRSLIPNOTE2DISPDIV" + Environment.NewLine;
                            sqlText += "  , @DTLNOTEDISPDIV" + Environment.NewLine;
                            sqlText += "  , @UNPRCNONSETTINGDIV" + Environment.NewLine;
                            sqlText += "  , @ESTMATEADDUPREMDIV" + Environment.NewLine;
                            sqlText += "  , @ACPODRRADDUPREMDIV" + Environment.NewLine;
                            sqlText += "  , @SHIPMADDUPREMDIV" + Environment.NewLine;
                            sqlText += "  , @RETGOODSSTOCKETYDIV" + Environment.NewLine;
                            sqlText += "  , @LISTPRICESELECTDIV" + Environment.NewLine;
                            sqlText += "  , @MAKERINPDIV" + Environment.NewLine;
                            sqlText += "  , @BLGOODSCDINPDIV" + Environment.NewLine;
                            sqlText += "  , @SUPPLIERINPDIV" + Environment.NewLine;
                            sqlText += "  , @SUPPLIERSLIPDELDIV" + Environment.NewLine;
                            sqlText += "  , @CUSTGUIDEDISPDIV" + Environment.NewLine;
                            sqlText += "  , @SLIPCHNGDIVDATE" + Environment.NewLine;
                            sqlText += "  , @SLIPCHNGDIVCOST" + Environment.NewLine;
                            sqlText += "  , @SLIPCHNGDIVUNPRC" + Environment.NewLine;
                            sqlText += "  , @SLIPCHNGDIVLPRICE" + Environment.NewLine;
                            sqlText += "  , @RETSLIPCHNGDIVCOST" + Environment.NewLine;
                            sqlText += "  , @RETSLIPCHNGDIVUNPRC" + Environment.NewLine;
                            sqlText += "  , @AUTODEPOKINDCODE" + Environment.NewLine;
                            sqlText += "  , @AUTODEPOKINDNAME" + Environment.NewLine;
                            sqlText += "  , @AUTODEPOKINDDIVCD" + Environment.NewLine;
                            sqlText += "  , @DISCOUNTNAME" + Environment.NewLine;
                            sqlText += "  , @INPAGENTDISPDIV" + Environment.NewLine;
                            sqlText += "  , @CUSTORDERNODISPDIV" + Environment.NewLine;
                            sqlText += "  , @CARMNGNODISPDIV" + Environment.NewLine;
                            sqlText += "  , @PRICESELECTDISPDIV" + Environment.NewLine;
                            sqlText += "  , @ACPODRINPUTDIV" + Environment.NewLine;
                            sqlText += "  , @INPAGENTCHKDIV" + Environment.NewLine;
                            sqlText += "  , @INPWAREHCHKDIV" + Environment.NewLine;
                            sqlText += "  , @BRSLIPNOTE3DISPDIV" + Environment.NewLine;
                            sqlText += "  , @SLIPDATECLRDIVCD" + Environment.NewLine;
                            sqlText += "  , @AUTOENTRYGOODSDIVCD" + Environment.NewLine;
                            sqlText += "  , @COSTCHECKDIVCD" + Environment.NewLine;
                            sqlText += "  , @JOININITDISPDIV" + Environment.NewLine;
                            sqlText += "  , @AUTODEPOSITCD" + Environment.NewLine;
                            sqlText += "  , @SUBSTCONDDIVCD" + Environment.NewLine;
                            sqlText += "  , @SLIPCREATEPROCESS" + Environment.NewLine;
                            sqlText += "  , @WAREHOUSECHKDIV" + Environment.NewLine;
                            sqlText += "  , @PARTSSEARCHDIVCD" + Environment.NewLine;
                            sqlText += "  , @GRSPROFITDSPCD" + Environment.NewLine;
                            sqlText += "  , @PARTSSEARCHPRIDIVCD" + Environment.NewLine;
                            sqlText += "  , @SALESSTOCKDIV" + Environment.NewLine;
                            sqlText += "  , @PRTBLGOODSCODEDIV" + Environment.NewLine;
                            sqlText += "  , @SECTDSPDIVCD" + Environment.NewLine;
                            sqlText += "  , @GOODSNMREDISPDIVCD" + Environment.NewLine;
                            sqlText += "  , @COSTDSPDIVCD" + Environment.NewLine;
                            sqlText += "  , @DEPOSLIPDATECLRDIV" + Environment.NewLine;
                            sqlText += "  , @DEPOSLIPDATEAMBIT" + Environment.NewLine;
                            sqlText += "  , @INPGRSPROFCHKLOWER" + Environment.NewLine;
                            sqlText += "  , @INPGRSPROFCHKUPPER" + Environment.NewLine;
                            sqlText += "  , @INPGRSPRFCHKLOWDIV" + Environment.NewLine;
                            sqlText += "  , @INPGRSPRFCHKUPPDIV" + Environment.NewLine;
                            sqlText += "  , @PRMSUBSTCONDDIVCD" + Environment.NewLine;
                            sqlText += "  , @SUBSTAPPLYDIVCD" + Environment.NewLine;
                            sqlText += "  , @PARTSNAMEDSPDIVCD" + Environment.NewLine;
                            sqlText += "  , @BLGOODSCDDERIVNODIV" + Environment.NewLine;
                            sqlText += "  , @FRSRCHPRTAUTOENTDIV" + Environment.NewLine;
                            sqlText += "  , @BLCDPRTSNMDSPDIVCD1" + Environment.NewLine;
                            sqlText += "  , @BLCDPRTSNMDSPDIVCD2" + Environment.NewLine;
                            sqlText += "  , @BLCDPRTSNMDSPDIVCD3" + Environment.NewLine;
                            sqlText += "  , @BLCDPRTSNMDSPDIVCD4" + Environment.NewLine;
                            sqlText += "  , @GDNOPRTSNMDSPDIVCD1" + Environment.NewLine;
                            sqlText += "  , @GDNOPRTSNMDSPDIVCD2" + Environment.NewLine;
                            sqlText += "  , @GDNOPRTSNMDSPDIVCD3" + Environment.NewLine;
                            sqlText += "  , @GDNOPRTSNMDSPDIVCD4" + Environment.NewLine;
                            sqlText += "  , @PRMPRTSNMUSEDIVCD" + Environment.NewLine;
                            sqlText += "  , @DWNPLCDSPDIVCD" + Environment.NewLine;
                            sqlText += "  , @SALESCDDSPDIVCD" + Environment.NewLine;
                            sqlText += "  , @RENTSTOCKDIV" + Environment.NewLine;
                            sqlText += "  , @EPPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += "  , @EPPARTSNOADDCHAR" + Environment.NewLine;
                            sqlText += "  , @PRINTGOODSNODEF" + Environment.NewLine;     // ADD 2013/01/16 Y.Wakita
							sqlText += "  , @STOCKRETGOODSPLNDIV" + Environment.NewLine; // ADD 2013/01/15
                            sqlText += "  , @AUTODEPOSITNOTEDIV" + Environment.NewLine; // ADD cheq 2013/01/21 Redmine#33797 
                            sqlText += "  , @BLGOODSCDZEROSUPRT" + Environment.NewLine; // ADD 2013/02/05 Y.Wakita
                            sqlText += "  , @BLGOODSCDCHANGE" + Environment.NewLine;    // ADD 2013/02/05 Y.Wakita
                            sqlText += "  , @STOCKEMPREFDIV" + Environment.NewLine;　　// ADD 2017/04/13 譚洪 Redmine#49283
                            sqlText += ");" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)salesTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipUnPrcPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPUNPRCPRTDIV", SqlDbType.Int);
                        SqlParameter paraGrsProfitCheckLower = sqlCommand.Parameters.Add("@GRSPROFITCHECKLOWER", SqlDbType.Float);
                        SqlParameter paraGrsProfitCheckBest = sqlCommand.Parameters.Add("@GRSPROFITCHECKBEST", SqlDbType.Float);
                        SqlParameter paraGrsProfitCheckUpper = sqlCommand.Parameters.Add("@GRSPROFITCHECKUPPER", SqlDbType.Float);
                        SqlParameter paraGrsProfitChkLowSign = sqlCommand.Parameters.Add("@GRSPROFITCHKLOWSIGN", SqlDbType.NChar);
                        SqlParameter paraGrsProfitChkBestSign = sqlCommand.Parameters.Add("@GRSPROFITCHKBESTSIGN", SqlDbType.NChar);
                        SqlParameter paraGrsProfitChkUprSign = sqlCommand.Parameters.Add("@GRSPROFITCHKUPRSIGN", SqlDbType.NChar);
                        SqlParameter paraGrsProfitChkMaxSign = sqlCommand.Parameters.Add("@GRSPROFITCHKMAXSIGN", SqlDbType.NChar);
                        SqlParameter paraSalesAgentChngDiv = sqlCommand.Parameters.Add("@SALESAGENTCHNGDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrAgentDispDiv = sqlCommand.Parameters.Add("@ACPODRAGENTDISPDIV", SqlDbType.Int);
                        SqlParameter paraBrSlipNote2DispDiv = sqlCommand.Parameters.Add("@BRSLIPNOTE2DISPDIV", SqlDbType.Int);
                        SqlParameter paraDtlNoteDispDiv = sqlCommand.Parameters.Add("@DTLNOTEDISPDIV", SqlDbType.Int);
                        SqlParameter paraUnPrcNonSettingDiv = sqlCommand.Parameters.Add("@UNPRCNONSETTINGDIV", SqlDbType.Int);
                        SqlParameter paraEstmateAddUpRemDiv = sqlCommand.Parameters.Add("@ESTMATEADDUPREMDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrAddUpRemDiv = sqlCommand.Parameters.Add("@ACPODRRADDUPREMDIV", SqlDbType.Int);
                        SqlParameter paraShipmAddUpRemDiv = sqlCommand.Parameters.Add("@SHIPMADDUPREMDIV", SqlDbType.Int);
                        SqlParameter paraRetGoodsStockEtyDiv = sqlCommand.Parameters.Add("@RETGOODSSTOCKETYDIV", SqlDbType.Int);
                        SqlParameter paraListPriceSelectDiv = sqlCommand.Parameters.Add("@LISTPRICESELECTDIV", SqlDbType.Int);
                        SqlParameter paraMakerInpDiv = sqlCommand.Parameters.Add("@MAKERINPDIV", SqlDbType.Int);
                        SqlParameter paraBLGoodsCdInpDiv = sqlCommand.Parameters.Add("@BLGOODSCDINPDIV", SqlDbType.Int);
                        SqlParameter paraSupplierInpDiv = sqlCommand.Parameters.Add("@SUPPLIERINPDIV", SqlDbType.Int);
                        SqlParameter paraSupplierSlipDelDiv = sqlCommand.Parameters.Add("@SUPPLIERSLIPDELDIV", SqlDbType.Int);
                        SqlParameter paraCustGuideDispDiv = sqlCommand.Parameters.Add("@CUSTGUIDEDISPDIV", SqlDbType.Int);
                        SqlParameter paraSlipChngDivDate = sqlCommand.Parameters.Add("@SLIPCHNGDIVDATE", SqlDbType.Int);
                        SqlParameter paraSlipChngDivCost = sqlCommand.Parameters.Add("@SLIPCHNGDIVCOST", SqlDbType.Int);
                        SqlParameter paraSlipChngDivUnPrc = sqlCommand.Parameters.Add("@SLIPCHNGDIVUNPRC", SqlDbType.Int);
                        SqlParameter paraSlipChngDivLPrice = sqlCommand.Parameters.Add("@SLIPCHNGDIVLPRICE", SqlDbType.Int);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
                        SqlParameter paraRetSlipChngDivCost = sqlCommand.Parameters.Add("@RETSLIPCHNGDIVCOST", SqlDbType.Int);
                        SqlParameter paraRetSlipChngDivUnPrc = sqlCommand.Parameters.Add("@RETSLIPCHNGDIVUNPRC", SqlDbType.Int);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD
                        SqlParameter paraAutoDepoKindCode = sqlCommand.Parameters.Add("@AUTODEPOKINDCODE", SqlDbType.Int);
                        SqlParameter paraAutoDepoKindName = sqlCommand.Parameters.Add("@AUTODEPOKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraAutoDepoKindDivCd = sqlCommand.Parameters.Add("@AUTODEPOKINDDIVCD", SqlDbType.Int);
                        SqlParameter paraDiscountName = sqlCommand.Parameters.Add("@DISCOUNTNAME", SqlDbType.NVarChar);
                        SqlParameter paraInpAgentDispDiv = sqlCommand.Parameters.Add("@INPAGENTDISPDIV", SqlDbType.Int);
                        SqlParameter paraCustOrderNoDispDiv = sqlCommand.Parameters.Add("@CUSTORDERNODISPDIV", SqlDbType.Int);
                        SqlParameter paraCarMngNoDispDiv = sqlCommand.Parameters.Add("@CARMNGNODISPDIV", SqlDbType.Int);
                        // --- ADD 2009/10/19 ---------->>>>>
                        SqlParameter paraPriceSelectDispDiv = sqlCommand.Parameters.Add("@PRICESELECTDISPDIV", SqlDbType.Int);
                        // --- ADD 2009/10/19 ----------<<<<<
                        // --- ADD 2010/01/29 ---------->>>>>
                        SqlParameter paraAcpOdrInputDiv = sqlCommand.Parameters.Add("@ACPODRINPUTDIV", SqlDbType.Int);
                        // --- ADD 2010/01/29 ----------<<<<<
                        // --- ADD 2010/05/04 ---------->>>>>
                        SqlParameter paraInpAgentChkDiv = sqlCommand.Parameters.Add("@INPAGENTCHKDIV", SqlDbType.Int);
                        SqlParameter paraInpWarehChkDiv = sqlCommand.Parameters.Add("@INPWAREHCHKDIV", SqlDbType.Int);
                        // --- ADD 2010/05/04 ----------<<<<<
                        SqlParameter paraBrSlipNote3DispDiv = sqlCommand.Parameters.Add("@BRSLIPNOTE3DISPDIV", SqlDbType.Int);
                        SqlParameter paraSlipDateClrDivCd = sqlCommand.Parameters.Add("@SLIPDATECLRDIVCD", SqlDbType.Int);
                        SqlParameter paraAutoEntryGoodsDivCd = sqlCommand.Parameters.Add("@AUTOENTRYGOODSDIVCD", SqlDbType.Int);
                        SqlParameter paraCostCheckDivCd = sqlCommand.Parameters.Add("@COSTCHECKDIVCD", SqlDbType.Int);
                        SqlParameter paraJoinInitDispDiv = sqlCommand.Parameters.Add("@JOININITDISPDIV", SqlDbType.Int);
                        SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                        SqlParameter paraSubstCondDivCd = sqlCommand.Parameters.Add("@SUBSTCONDDIVCD", SqlDbType.Int);
                        SqlParameter paraSlipCreateProcess = sqlCommand.Parameters.Add("@SLIPCREATEPROCESS", SqlDbType.Int);
                        SqlParameter paraWarehouseChkDiv = sqlCommand.Parameters.Add("@WAREHOUSECHKDIV", SqlDbType.Int);
                        SqlParameter paraPartsSearchDivCd = sqlCommand.Parameters.Add("@PARTSSEARCHDIVCD", SqlDbType.Int);
                        SqlParameter paraGrsProfitDspCd = sqlCommand.Parameters.Add("@GRSPROFITDSPCD", SqlDbType.Int);
                        SqlParameter paraPartsSearchPriDivCd = sqlCommand.Parameters.Add("@PARTSSEARCHPRIDIVCD", SqlDbType.Int);
                        SqlParameter paraSalesStockDiv = sqlCommand.Parameters.Add("@SALESSTOCKDIV", SqlDbType.Int);
                        SqlParameter paraPrtBLGoodsCodeDiv = sqlCommand.Parameters.Add("@PRTBLGOODSCODEDIV", SqlDbType.Int);
                        SqlParameter paraSectDspDivCd = sqlCommand.Parameters.Add("@SECTDSPDIVCD", SqlDbType.Int);
                        SqlParameter paraGoodsNmReDispDivCd = sqlCommand.Parameters.Add("@GOODSNMREDISPDIVCD", SqlDbType.Int);
                        SqlParameter paraCostDspDivCd = sqlCommand.Parameters.Add("@COSTDSPDIVCD", SqlDbType.Int);
                        SqlParameter paraDepoSlipDateClrDiv = sqlCommand.Parameters.Add("@DEPOSLIPDATECLRDIV", SqlDbType.Int);
                        SqlParameter paraDepoSlipDateAmbit = sqlCommand.Parameters.Add("@DEPOSLIPDATEAMBIT", SqlDbType.Int);
                        SqlParameter paraInpGrsProfChkLower = sqlCommand.Parameters.Add("@INPGRSPROFCHKLOWER", SqlDbType.Float);
                        SqlParameter paraInpGrsProfChkUpper = sqlCommand.Parameters.Add("@INPGRSPROFCHKUPPER", SqlDbType.Float);
                        SqlParameter paraInpGrsPrfChkLowDiv = sqlCommand.Parameters.Add("@INPGRSPRFCHKLOWDIV", SqlDbType.Int);
                        SqlParameter paraInpGrsPrfChkUppDiv = sqlCommand.Parameters.Add("@INPGRSPRFCHKUPPDIV", SqlDbType.Int);
                        SqlParameter paraPrmSubstCondDivCd = sqlCommand.Parameters.Add("@PRMSUBSTCONDDIVCD", SqlDbType.Int);
                        SqlParameter paraSubstApplyDivCd = sqlCommand.Parameters.Add("@SUBSTAPPLYDIVCD", SqlDbType.Int);
                        SqlParameter paraPartsNameDspDivCd = sqlCommand.Parameters.Add("@PARTSNAMEDSPDIVCD", SqlDbType.Int);
                        SqlParameter paraBLGoodsCdDerivNoDiv = sqlCommand.Parameters.Add("@BLGOODSCDDERIVNODIV", SqlDbType.Int);  // BLコード枝番区分
                        SqlParameter paraFrSrchPrtAutoEntDiv = sqlCommand.Parameters.Add("@FRSRCHPRTAUTOENTDIV", SqlDbType.Int);  // ADD 2010/04/30
                        // 2010/05/14 Add >>>
                        SqlParameter paraBLCdPrtsNmDspDivCd1 = sqlCommand.Parameters.Add("@BLCDPRTSNMDSPDIVCD1", SqlDbType.Int);  // BLコード検索品名表示区分１
                        SqlParameter paraBLCdPrtsNmDspDivCd2 = sqlCommand.Parameters.Add("@BLCDPRTSNMDSPDIVCD2", SqlDbType.Int);  // BLコード検索品名表示区分２
                        SqlParameter paraBLCdPrtsNmDspDivCd3 = sqlCommand.Parameters.Add("@BLCDPRTSNMDSPDIVCD3", SqlDbType.Int);  // BLコード検索品名表示区分３
                        SqlParameter paraBLCdPrtsNmDspDivCd4 = sqlCommand.Parameters.Add("@BLCDPRTSNMDSPDIVCD4", SqlDbType.Int);  // BLコード検索品名表示区分４
                        SqlParameter paraGdNoPrtsNmDspDivCd1 = sqlCommand.Parameters.Add("@GDNOPRTSNMDSPDIVCD1", SqlDbType.Int);  // 品番検索品名表示区分１
                        SqlParameter paraGdNoPrtsNmDspDivCd2 = sqlCommand.Parameters.Add("@GDNOPRTSNMDSPDIVCD2", SqlDbType.Int);  // 品番検索品名表示区分２
                        SqlParameter paraGdNoPrtsNmDspDivCd3 = sqlCommand.Parameters.Add("@GDNOPRTSNMDSPDIVCD3", SqlDbType.Int);  // 品番検索品名表示区分３
                        SqlParameter paraGdNoPrtsNmDspDivCd4 = sqlCommand.Parameters.Add("@GDNOPRTSNMDSPDIVCD4", SqlDbType.Int);  // 品番検索品名表示区分４
                        SqlParameter paraPrmPrtsNmUseDivCd = sqlCommand.Parameters.Add("@PRMPRTSNMUSEDIVCD", SqlDbType.Int);  // 優良部品検索品名使用区分
                        // 2010/05/14 Add <<<

                        // --- ADD 2010/08/04 ---------->>>>>
                        SqlParameter paraDwnPLCdSpDivCd = sqlCommand.Parameters.Add("@DWNPLCDSPDIVCD", SqlDbType.Int);
                        // --- ADD 2010/08/04 ----------<<<<<
                        // --- ADD 2011/06/06 ---------->>>>>
                        SqlParameter paraSalesCdDspDivCd = sqlCommand.Parameters.Add("@SALESCDDSPDIVCD", SqlDbType.Int);
                        // --- ADD 2011/06/06 ----------<<<<<
                        // --- ADD 2012/04/23 ---------->>>>>
                        SqlParameter paraRentStockDiv = sqlCommand.Parameters.Add("@RENTSTOCKDIV", SqlDbType.Int);
                        // --- ADD 2012/04/23 ----------<<<<<
                        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                        SqlParameter paraEpPartsNoPrtCd = sqlCommand.Parameters.Add("@EPPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraEpPartsNoAddChar = sqlCommand.Parameters.Add("@EPPARTSNOADDCHAR", SqlDbType.NVarChar);
                        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                        SqlParameter paraPrintGoodsNoDef = sqlCommand.Parameters.Add("@PRINTGOODSNODEF", SqlDbType.Int);
                        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                        // --- ADD 2013/01/15 ---------->>>>>
                        SqlParameter paraStockRetGoodsPlnDiv = sqlCommand.Parameters.Add("@STOCKRETGOODSPLNDIV", SqlDbType.Int);
                        // --- ADD 2013/01/15 ----------<<<<<
                        SqlParameter paraAutoDepositNoteDiv = sqlCommand.Parameters.Add("@AUTODEPOSITNOTEDIV", SqlDbType.Int); // ADD cheq 2013/01/21 Redmine#33797
                        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                        SqlParameter paraBLGoodsCdZeroSuprt = sqlCommand.Parameters.Add("@BLGOODSCDZEROSUPRT", SqlDbType.Int);
                        SqlParameter paraBLGoodsCdChange = sqlCommand.Parameters.Add("@BLGOODSCDCHANGE", SqlDbType.Int);
                        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

                        SqlParameter paraStockEmpRefDiv = sqlCommand.Parameters.Add("@STOCKEMPREFDIV", SqlDbType.Int);　// ADD 2017/04/13 譚洪 Redmine#49283
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ShipmSlipPrtDiv);
                        paraShipmSlipUnPrcPrtDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ShipmSlipUnPrcPrtDiv);
                        paraGrsProfitCheckLower.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.GrsProfitCheckLower);
                        paraGrsProfitCheckBest.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.GrsProfitCheckBest);
                        paraGrsProfitCheckUpper.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.GrsProfitCheckUpper);
                        paraGrsProfitChkLowSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkLowSign);
                        paraGrsProfitChkBestSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkBestSign);
                        paraGrsProfitChkUprSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkUprSign);
                        paraGrsProfitChkMaxSign.Value = SqlDataMediator.SqlSetString(salesTtlStWork.GrsProfitChkMaxSign);
                        paraSalesAgentChngDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesAgentChngDiv);
                        paraAcpOdrAgentDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AcpOdrAgentDispDiv);
                        paraBrSlipNote2DispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BrSlipNote2DispDiv);
                        paraDtlNoteDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DtlNoteDispDiv);
                        paraUnPrcNonSettingDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.UnPrcNonSettingDiv);
                        paraEstmateAddUpRemDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.EstmateAddUpRemDiv);
                        paraAcpOdrrAddUpRemDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AcpOdrrAddUpRemDiv);
                        paraShipmAddUpRemDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ShipmAddUpRemDiv);
                        paraRetGoodsStockEtyDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.RetGoodsStockEtyDiv);
                        paraListPriceSelectDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.ListPriceSelectDiv);
                        paraMakerInpDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.MakerInpDiv);
                        paraBLGoodsCdInpDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLGoodsCdInpDiv);
                        paraSupplierInpDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SupplierInpDiv);
                        paraSupplierSlipDelDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SupplierSlipDelDiv);
                        paraCustGuideDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CustGuideDispDiv);
                        paraSlipChngDivDate.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivDate);
                        paraSlipChngDivCost.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivCost);
                        paraSlipChngDivUnPrc.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivUnPrc);
                        paraSlipChngDivLPrice.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipChngDivLPrice);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
                        paraRetSlipChngDivCost.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.RetSlipChngDivCost);
                        paraRetSlipChngDivUnPrc.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.RetSlipChngDivUnPrc);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD
                        paraAutoDepoKindCode.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepoKindCode);
                        paraAutoDepoKindName.Value = SqlDataMediator.SqlSetString(salesTtlStWork.AutoDepoKindName);
                        paraAutoDepoKindDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepoKindDivCd);
                        paraDiscountName.Value = SqlDataMediator.SqlSetString(salesTtlStWork.DiscountName);
                        paraInpAgentDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.InpAgentDispDiv);
                        paraCustOrderNoDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CustOrderNoDispDiv);
                        paraCarMngNoDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CarMngNoDispDiv);
                        // --- ADD 2009/10/19 ---------->>>>>
                        paraPriceSelectDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PriceSelectDispDiv);
                        // --- ADD 2009/10/19 ----------<<<<<
                        // --- ADD 2010/01/29 ---------->>>>>
                        paraAcpOdrInputDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AcpOdrInputDiv);
                        // --- ADD 2010/01/29 ----------<<<<<
                        // --- ADD 2010/05/04 ---------->>>>>
                        paraInpAgentChkDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.InpAgentChkDiv);
                        paraInpWarehChkDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.InpWarehChkDiv);
                        // --- ADD 2010/05/04 ----------<<<<<
                        paraBrSlipNote3DispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BrSlipNote3DispDiv);
                        paraSlipDateClrDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipDateClrDivCd);
                        paraAutoEntryGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoEntryGoodsDivCd);
                        paraCostCheckDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CostCheckDivCd);
                        paraJoinInitDispDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.JoinInitDispDiv);
                        paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepositCd);
                        paraSubstCondDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SubstCondDivCd);
                        paraSlipCreateProcess.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SlipCreateProcess);
                        paraWarehouseChkDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.WarehouseChkDiv);
                        paraPartsSearchDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PartsSearchDivCd);
                        paraGrsProfitDspCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GrsProfitDspCd);
                        paraPartsSearchPriDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PartsSearchPriDivCd);
                        paraSalesStockDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesStockDiv);
                        paraPrtBLGoodsCodeDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PrtBLGoodsCodeDiv);
                        paraSectDspDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SectDspDivCd);
                        paraGoodsNmReDispDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GoodsNmReDispDivCd);
                        paraCostDspDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.CostDspDivCd);
                        paraDepoSlipDateClrDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DepoSlipDateClrDiv);
                        paraDepoSlipDateAmbit.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DepoSlipDateAmbit);
                        paraInpGrsProfChkLower.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.InpGrsProfChkLower);
                        paraInpGrsProfChkUpper.Value = SqlDataMediator.SqlSetDouble(salesTtlStWork.InpGrsProfChkUpper);
                        paraInpGrsPrfChkLowDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.InpGrsPrfChkLowDiv);
                        paraInpGrsPrfChkUppDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.InpGrsPrfChkUppDiv);
                        paraPrmSubstCondDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PrmSubstCondDivCd);
                        paraSubstApplyDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SubstApplyDivCd);
                        paraPartsNameDspDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PartsNameDspDivCd);
                        paraBLGoodsCdDerivNoDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLGoodsCdDerivNoDiv);  // BLコード枝番区分
                        paraFrSrchPrtAutoEntDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.FrSrchPrtAutoEntDiv);  // ADD 2010/04/30
                        // 2010/05/14 Add >>>
                        paraBLCdPrtsNmDspDivCd1.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLCdPrtsNmDspDivCd1);  // BLコード検索品名表示区分１
                        paraBLCdPrtsNmDspDivCd2.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLCdPrtsNmDspDivCd2);  // BLコード検索品名表示区分２
                        paraBLCdPrtsNmDspDivCd3.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLCdPrtsNmDspDivCd3);  // BLコード検索品名表示区分３
                        paraBLCdPrtsNmDspDivCd4.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLCdPrtsNmDspDivCd4);  // BLコード検索品名表示区分４
                        paraGdNoPrtsNmDspDivCd1.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GdNoPrtsNmDspDivCd1);  // 品番検索品名表示区分１
                        paraGdNoPrtsNmDspDivCd2.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GdNoPrtsNmDspDivCd2);  // 品番検索品名表示区分２
                        paraGdNoPrtsNmDspDivCd3.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GdNoPrtsNmDspDivCd3);  // 品番検索品名表示区分３
                        paraGdNoPrtsNmDspDivCd4.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.GdNoPrtsNmDspDivCd4);  // 品番検索品名表示区分４
                        paraPrmPrtsNmUseDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PrmPrtsNmUseDivCd);  // 優良部品検索品名使用区分
                        // 2010/05/14 Add <<<

                        // --- ADD 2010/08/04 ---------->>>>>
                        paraDwnPLCdSpDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.DwnPLCdSpDivCd);
                        // --- ADD 2010/08/04 ----------<<<<<
                        // --- ADD 2011/06/06 ---------->>>>>
                        paraSalesCdDspDivCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.SalesCdDspDivCd);
                        // --- ADD 2011/06/06 ----------<<<<<
                        // --- ADD 2012/04/23 ---------->>>>>
                        paraRentStockDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.RentStockDiv);
                        // --- ADD 2012/04/23 ----------<<<<<
                        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                        paraEpPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.EpPartsNoPrtCd);
                        paraEpPartsNoAddChar.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EpPartsNoAddChar);
                        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                        paraPrintGoodsNoDef.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.PrintGoodsNoDef);
                        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                        // --- ADD 2013/01/15 ---------->>>>>
                        paraStockRetGoodsPlnDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.StockRetGoodsPlnDiv);
                        // --- ADD 2013/01/15 ----------<<<<<
                        paraAutoDepositNoteDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.AutoDepositNoteDiv); // ADD cheq 2013/01/21 Redmine#33797
                        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                        paraBLGoodsCdZeroSuprt.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLGoodsCdZeroSuprt);
                        paraBLGoodsCdChange.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.BLGoodsCdChange);
                        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

                        paraStockEmpRefDiv.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.StockEmpRefDiv);  // ADD 2017/04/13 譚洪 Redmine#49283
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(salesTtlStWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            salesTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 売上全体設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int LogicalDelete(ref object salesTtlStWork)
        {
            return LogicalDeleteSalesTtlSt(ref salesTtlStWork, 0);
        }

        /// <summary>
        /// 論理削除売上全体設定マスタ情報を復活します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除売上全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int RevivalLogicalDelete(ref object salesTtlStWork)
        {
            return LogicalDeleteSalesTtlSt(ref salesTtlStWork, 1);
        }

        /// <summary>
        /// 売上全体設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="salesTtlStWork">SalesTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private int LogicalDeleteSalesTtlSt(ref object salesTtlStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(salesTtlStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSalesTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SalesTtlStDB.LogicalDeleteSalesTtlSt :" + procModestr);

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
        /// 売上全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">SalesTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int LogicalDeleteSalesTtlStProc(ref ArrayList salesTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteSalesTtlStProcProc(ref salesTtlStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 売上全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">SalesTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int LogicalDeleteSalesTtlStProcProc(ref ArrayList salesTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (salesTtlStWorkList != null)
                {
                    for (int i = 0; i < salesTtlStWorkList.Count; i++)
                    {
                        SalesTtlStWork salesTtlStWork = salesTtlStWorkList[i] as SalesTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != salesTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SALESTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)salesTtlStWork;
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
                            else if (logicalDelCd == 0) salesTtlStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else salesTtlStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) salesTtlStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //既に復活している場合はそのまま正常を戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesTtlStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesTtlStWork.LogicalDeleteCode);


                        sqlCommand.ExecuteNonQuery();
                        al.Add(salesTtlStWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            salesTtlStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 売上全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">売上全体設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 売上全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
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

                status = DeleteSalesTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SalesTtlStDB.Delete");
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
        /// 売上全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">売上全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 売上全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int DeleteSalesTtlStProc(ArrayList salesTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteSalesTtlStProcProc(salesTtlStWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 売上全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="salesTtlStWorkList">売上全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 売上全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int DeleteSalesTtlStProcProc(ArrayList salesTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < salesTtlStWorkList.Count; i++)
                {
                    SalesTtlStWork salesTtlStWork = salesTtlStWorkList[i] as SalesTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != salesTtlStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SALESTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesTtlStWork.SectionCode);
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
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// <param name="searchSalesTtlStParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesTtlStWork searchSalesTtlStParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "SAS.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchSalesTtlStParaWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(searchSalesTtlStParaWork.SectionCode) == false)
            {
                retstring += "AND SAS.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(searchSalesTtlStParaWork.SectionCode);
            }

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND SAS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if    (    (logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND SAS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
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
        /// クラス格納処理 Reader → SalesTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">シンクの場合には1</param>
        /// <returns>SalesTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// <br>Update Note: 2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note: 2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note: 2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note: 2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note: 2011/06/06 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note: 2012/04/23 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note: 2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
        private SalesTtlStWork CopyToSalesTtlStWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            SalesTtlStWork wkSalesTtlStWork = new SalesTtlStWork();

            #region クラスへ格納
            wkSalesTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSalesTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSalesTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSalesTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSalesTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSalesTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSalesTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSalesTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSalesTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSalesTtlStWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
            wkSalesTtlStWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
            wkSalesTtlStWork.ShipmSlipUnPrcPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPUNPRCPRTDIVRF"));
            wkSalesTtlStWork.GrsProfitCheckLower = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITCHECKLOWERRF"));
            wkSalesTtlStWork.GrsProfitCheckBest = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITCHECKBESTRF"));
            wkSalesTtlStWork.GrsProfitCheckUpper = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITCHECKUPPERRF"));
            wkSalesTtlStWork.GrsProfitChkLowSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKLOWSIGNRF"));
            wkSalesTtlStWork.GrsProfitChkBestSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKBESTSIGNRF"));
            wkSalesTtlStWork.GrsProfitChkUprSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKUPRSIGNRF"));
            wkSalesTtlStWork.GrsProfitChkMaxSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRSPROFITCHKMAXSIGNRF"));
            wkSalesTtlStWork.SalesAgentChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAGENTCHNGDIVRF"));
            wkSalesTtlStWork.AcpOdrAgentDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRAGENTDISPDIVRF"));
            wkSalesTtlStWork.BrSlipNote2DispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BRSLIPNOTE2DISPDIVRF"));
            wkSalesTtlStWork.DtlNoteDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLNOTEDISPDIVRF"));
            wkSalesTtlStWork.UnPrcNonSettingDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCNONSETTINGDIVRF"));
            wkSalesTtlStWork.EstmateAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMATEADDUPREMDIVRF"));
            wkSalesTtlStWork.AcpOdrrAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRADDUPREMDIVRF"));
            wkSalesTtlStWork.ShipmAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMADDUPREMDIVRF"));
            wkSalesTtlStWork.RetGoodsStockEtyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSSTOCKETYDIVRF"));
            wkSalesTtlStWork.ListPriceSelectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICESELECTDIVRF"));
            wkSalesTtlStWork.MakerInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERINPDIVRF"));
            wkSalesTtlStWork.BLGoodsCdInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDINPDIVRF"));
            wkSalesTtlStWork.SupplierInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERINPDIVRF"));
            wkSalesTtlStWork.SupplierSlipDelDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPDELDIVRF"));
            wkSalesTtlStWork.CustGuideDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTGUIDEDISPDIVRF"));
            wkSalesTtlStWork.SlipChngDivDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVDATERF"));
            wkSalesTtlStWork.SlipChngDivCost = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVCOSTRF"));
            wkSalesTtlStWork.SlipChngDivUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVUNPRCRF"));
            wkSalesTtlStWork.SlipChngDivLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCHNGDIVLPRICERF"));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
            wkSalesTtlStWork.RetSlipChngDivCost = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETSLIPCHNGDIVCOSTRF"));
            wkSalesTtlStWork.RetSlipChngDivUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETSLIPCHNGDIVUNPRCRF"));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD
            wkSalesTtlStWork.AutoDepoKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOKINDCODERF"));
            wkSalesTtlStWork.AutoDepoKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTODEPOKINDNAMERF"));
            wkSalesTtlStWork.AutoDepoKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOKINDDIVCDRF"));
            wkSalesTtlStWork.DiscountName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISCOUNTNAMERF"));
            wkSalesTtlStWork.InpAgentDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPAGENTDISPDIVRF"));
            wkSalesTtlStWork.CustOrderNoDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTORDERNODISPDIVRF"));
            wkSalesTtlStWork.CarMngNoDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNODISPDIVRF"));
            // --- ADD 2009/10/19 ---------->>>>>
            wkSalesTtlStWork.PriceSelectDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESELECTDISPDIVRF"));
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            wkSalesTtlStWork.AcpOdrInputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRINPUTDIVRF"));
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            wkSalesTtlStWork.InpAgentChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPAGENTCHKDIVRF"));
            wkSalesTtlStWork.InpWarehChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPWAREHCHKDIVRF"));
            // --- ADD 2010/05/04 ----------<<<<<
            wkSalesTtlStWork.BrSlipNote3DispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BRSLIPNOTE3DISPDIVRF"));
            wkSalesTtlStWork.SlipDateClrDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDATECLRDIVCDRF"));
            wkSalesTtlStWork.AutoEntryGoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOENTRYGOODSDIVCDRF"));
            wkSalesTtlStWork.CostCheckDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COSTCHECKDIVCDRF"));
            wkSalesTtlStWork.JoinInitDispDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOININITDISPDIVRF"));
            wkSalesTtlStWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            wkSalesTtlStWork.SubstCondDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSTCONDDIVCDRF"));
            wkSalesTtlStWork.SlipCreateProcess = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPCREATEPROCESSRF"));
            wkSalesTtlStWork.WarehouseChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAREHOUSECHKDIVRF"));
            wkSalesTtlStWork.PartsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHDIVCDRF"));
            wkSalesTtlStWork.GrsProfitDspCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITDSPCDRF"));
            wkSalesTtlStWork.PartsSearchPriDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHPRIDIVCDRF"));
            wkSalesTtlStWork.SalesStockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSTOCKDIVRF"));
            wkSalesTtlStWork.PrtBLGoodsCodeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODEDIVRF"));
            wkSalesTtlStWork.SectDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTDSPDIVCDRF"));
            wkSalesTtlStWork.GoodsNmReDispDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNMREDISPDIVCDRF"));
            wkSalesTtlStWork.CostDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COSTDSPDIVCDRF"));
            wkSalesTtlStWork.DepoSlipDateClrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSLIPDATECLRDIVRF"));
            wkSalesTtlStWork.DepoSlipDateAmbit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSLIPDATEAMBITRF"));
            wkSalesTtlStWork.InpGrsProfChkLower = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INPGRSPROFCHKLOWERRF"));
            wkSalesTtlStWork.InpGrsProfChkUpper = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INPGRSPROFCHKUPPERRF"));
            wkSalesTtlStWork.InpGrsPrfChkLowDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPGRSPRFCHKLOWDIVRF"));
            wkSalesTtlStWork.InpGrsPrfChkUppDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPGRSPRFCHKUPPDIVRF"));
            wkSalesTtlStWork.PrmSubstCondDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSUBSTCONDDIVCDRF"));
            wkSalesTtlStWork.SubstApplyDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSTAPPLYDIVCDRF"));
            wkSalesTtlStWork.PartsNameDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNAMEDSPDIVCDRF"));
            
            if (mode == 0)
            {
              wkSalesTtlStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            }
            wkSalesTtlStWork.BLGoodsCdDerivNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDDERIVNODIVRF"));  // BLコード枝番区分
            wkSalesTtlStWork.FrSrchPrtAutoEntDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRSRCHPRTAUTOENTDIVRF"));  // ADD 2010/04/30
            // 2010/05/14 Add >>>
            wkSalesTtlStWork.BLCdPrtsNmDspDivCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCDPRTSNMDSPDIVCD1RF"));
            wkSalesTtlStWork.BLCdPrtsNmDspDivCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCDPRTSNMDSPDIVCD2RF"));
            wkSalesTtlStWork.BLCdPrtsNmDspDivCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCDPRTSNMDSPDIVCD3RF"));
            wkSalesTtlStWork.BLCdPrtsNmDspDivCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCDPRTSNMDSPDIVCD4RF"));
            wkSalesTtlStWork.GdNoPrtsNmDspDivCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GDNOPRTSNMDSPDIVCD1RF"));
            wkSalesTtlStWork.GdNoPrtsNmDspDivCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GDNOPRTSNMDSPDIVCD2RF"));
            wkSalesTtlStWork.GdNoPrtsNmDspDivCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GDNOPRTSNMDSPDIVCD3RF"));
            wkSalesTtlStWork.GdNoPrtsNmDspDivCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GDNOPRTSNMDSPDIVCD4RF"));
            wkSalesTtlStWork.PrmPrtsNmUseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMPRTSNMUSEDIVCDRF"));
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            wkSalesTtlStWork.DwnPLCdSpDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DWNPLCDSPDIVCDRF"));
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            wkSalesTtlStWork.SalesCdDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCDDSPDIVCDRF"));
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            wkSalesTtlStWork.RentStockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RENTSTOCKDIVRF"));
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            wkSalesTtlStWork.EpPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EPPARTSNOPRTCDRF"));
            wkSalesTtlStWork.EpPartsNoAddChar = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPPARTSNOADDCHARRF"));
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            wkSalesTtlStWork.PrintGoodsNoDef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTGOODSNODEFRF"));
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            wkSalesTtlStWork.StockRetGoodsPlnDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKRETGOODSPLNDIVRF"));
            // --- ADD 2013/01/15 ----------<<<<<
            wkSalesTtlStWork.AutoDepositNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITNOTEDIVRF"));// ADD cheq 2013/01/21 Redmine#33797
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            wkSalesTtlStWork.BLGoodsCdZeroSuprt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDZEROSUPRTRF"));
            wkSalesTtlStWork.BLGoodsCdChange = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCDCHANGERF"));
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            wkSalesTtlStWork.StockEmpRefDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKEMPREFDIVRF"));
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

            #endregion

            return wkSalesTtlStWork;
        }
        
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SalesTtlStWork[] SalesTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SalesTtlStWork)
                    {
                        SalesTtlStWork wkSalesTtlStWork = paraobj as SalesTtlStWork;
                        if (wkSalesTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSalesTtlStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SalesTtlStWorkArray = (SalesTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SalesTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (SalesTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SalesTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SalesTtlStWork wkSalesTtlStWork = (SalesTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SalesTtlStWork));
                                if (wkSalesTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSalesTtlStWork);
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
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
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
