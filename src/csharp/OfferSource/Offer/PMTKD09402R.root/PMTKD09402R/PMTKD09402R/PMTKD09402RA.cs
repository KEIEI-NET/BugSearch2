//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良部品バーコード情報抽出リモートオブジェクト
// プログラム概要   : 優良部品バーコード情報抽出リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 優良部品バーコード情報抽出リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良部品バーコード情報抽出処理の実データ操作を行うクラスの定義と実装</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    [Serializable]
    public class OfferPrmPartsBrcdInfoDB : RemoteDB, IOfferPrmPartsBrcdInfo
    {
        #region 定数定義

        /// <summary>
        /// 抽出件数取得SELECT句
        /// </summary>
        private static readonly string SelectCountQuery = "SELECT \n    COUNT(*) \n";

        /// <summary>
        /// 情報抽出SELECT句
        /// </summary>
        private static readonly string SelectQuery =
              "SELECT \n"
            + "         OFFERDATERF \n"
            + "        ,PARTSMAKERCODERF \n"
            + "        ,TBSPARTSCODERF \n"
            + "        ,PRIMEPARTSNOWITHHRF \n"
            + "        ,PRIMEPRTSBARCDKNDDIVRF \n"
            + "        ,PRIMEPARTSBARCODERF ";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通FROM句
        /// </summary>
        private static readonly string FromQuery = "FROM dbo.PRMPRTBRCDRF WITH (READUNCOMMITTED) ";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通WHERE句(優良部品バーコード情報抽出条件パラメータが存在しない場合)
        /// </summary>
        private static readonly string WhereSymbol = "WHERE ";

        /// <summary>
        /// WHERE句先頭条件書式
        /// </summary>
        private static readonly string WhereFormatTop = "       (PARTSMAKERCODERF = {0} AND TBSPARTSCODERF = {1})";

        /// <summary>
        /// WHERE句先頭以降条件書式
        /// </summary>
        private static readonly string WhereFormat = "    OR (PARTSMAKERCODERF = {0} AND TBSPARTSCODERF = {1})";

        /// <summary>
        /// SQL実行時タイムアウト規定値(3600秒)
        /// </summary>
        private const int SqlCommandTimeoutDefault = 3600;

        /// <summary>
        /// エラーメッセージ：優良部品バーコード情報抽出件数取得で例外発生
        /// </summary>
        private static readonly string ErrorTextGetSearchCountFaild = "優良部品バーコード情報抽出件数取得で例外が発生しました。";

        /// <summary>
        /// エラーメッセージ：優良部品バーコード情報抽出で例外発生
        /// </summary>
        private static readonly string ErrorTextSearchFaild = "優良部品バーコード情報抽出処理で例外が発生しました。";

        #endregion //定数定義


        #region コンストラクタ
        /// <summary>
        /// 優良部品バーコード情報抽出リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出リモートオブジェクトクラスのインスタンスを生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public OfferPrmPartsBrcdInfoDB()
            :
            base( "PMTKD09404D", "Broadleaf.Application.Remoting.OfferPrmPartsBrcdInfoDB", "PRMPRTBRCDRF" )
        {
        }
        #endregion //コンストラクタ

        #region IOfferPrmPartsBrcdInfo メンバ
        /// <summary>
        /// 優良部品バーコード情報抽出件数取得
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="retCnt">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良部品バーコード情報を取得した場合の件数を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int GetSearchCount( ref object selectParam, out int retCnt )
        {
            return this.GetSearchCountProc( selectParam, out retCnt );
        }

        /// <summary>
        /// 優良部品バーコード情報抽出
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="prmPartsBrcdInfoList">抽出結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良部品バーコード情報を取得取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int Search( ref object selectParam, out object prmPartsBrcdInfoList )
        {
            return this.SearchProc( selectParam, out prmPartsBrcdInfoList );
        }

        #endregion //IOfferPrmPartsBrcdInfo メンバ

        #region プライベートメソッド

        /// <summary>
        /// 優良部品バーコード情報抽出件数取得実体
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="retCnt">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良部品バーコード情報を取得した場合の件数を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchCountProc( object selectParam, out int retCnt )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = null;

            retCnt = -1;

            try
            {
                using(SqlConnection sqlConnection = this.CreateSqlConnection())
                {
                    if (sqlConnection == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    }
                    sqlConnection.Open();
                    
                    try
                    {
                        using( SqlCommand sqlCommand = new SqlCommand(string.Empty, sqlConnection) )
                        {
                            try
                            {
                                //クエリ文字列の生成
                                int funcResult = this.CreateGetSearchCountQuery( ref selectParam, sqlCommand , out queryText);
                                if ( funcResult != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    return funcResult;
                                }
                                sqlCommand.CommandText = queryText;
                                sqlCommand.CommandTimeout = OfferPrmPartsBrcdInfoDB.SqlCommandTimeoutDefault;
                                
                                object ret = sqlCommand.ExecuteScalar();
                                int count = int.MinValue;
                                if (ret != null )
                                {
                                    int.TryParse( ret.ToString(), out count);
                                    retCnt = count;
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                            }
                            finally
                            {
                                if (sqlCommand != null)
                                    sqlCommand.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }

            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, OfferPrmPartsBrcdInfoDB.ErrorTextGetSearchCountFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }


            return (int)status;
        }

        /// <summary>
        /// 優良部品バーコード情報抽出実体
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="prmPartsBrcdInfoList">抽出結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良部品バーコード情報を取得取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc( object selectParam, out object prmPartsBrcdInfoList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = null;
            ArrayList execResultList = new ArrayList();

            prmPartsBrcdInfoList = null;

            try
            {
                using (SqlConnection sqlConnection = this.CreateSqlConnection())
                {
                    if (sqlConnection == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    }
                    sqlConnection.Open();

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand( string.Empty, sqlConnection ))
                        {
                            try
                            {
                                //クエリ文字列の生成
                                int funcResult = this.CreateSearchQuery( ref selectParam, sqlCommand, out queryText );
                                if (funcResult != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    return funcResult;
                                }
                                sqlCommand.CommandText = queryText;
                                sqlCommand.CommandTimeout = OfferPrmPartsBrcdInfoDB.SqlCommandTimeoutDefault;

                                SqlDataReader myReader = null;
                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    while (myReader.Read())
                                    {
                                        RettPrmPartsBrcdInfoWork prmPartsBrcdInfoWork = this.CopyToPrmPartsBrcdInfoWorkFromDataReader( ref myReader );
                                        execResultList.Add( prmPartsBrcdInfoWork );
                                    }

                                    if (execResultList.Count <= 0)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    }
                                    else
                                    {
                                        prmPartsBrcdInfoList = (object)execResultList;
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    }
                                }
                                finally
                                {
                                    if ( myReader != null )
                                        myReader.Close();
                                }


                            }
                            finally
                            {
                                if (sqlCommand != null)
                                    sqlCommand.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }

            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, OfferPrmPartsBrcdInfoDB.ErrorTextSearchFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (int)status;
        }

        /// <summary>
        /// 優良部品バーコード情報抽出件数取得クエリ生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">優良部品バーコード情報抽出件数クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出件数取得を行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateGetSearchCountQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

             //Select句、From句のセット
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.SelectCountQuery );
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.FromQuery );

            //Where句のセット
            this.AddWhereQuery( ref selectParam, sqlCommand, ref queryStrings );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// 優良部品バーコード情報抽出クエリ生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">優良部品バーコード情報抽出クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出を行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateSearchQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //Select句、From句のセット
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.SelectQuery );
            queryStrings.Append( OfferPrmPartsBrcdInfoDB.FromQuery );

            //Where句のセット
            this.AddWhereQuery( ref selectParam, sqlCommand, ref queryStrings );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// WHERE句生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出用及び優良部品バーコード情報抽出件数取得用クエリ中、WHERE句の生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private void AddWhereQuery( ref object selectParam, SqlCommand sqlCommand, ref StringBuilder queryText )
        {
            string whereString = OfferPrmPartsBrcdInfoDB.WhereSymbol;
            ArrayList paramList = selectParam as ArrayList;

            // パラメータが空の場合、WHERE句は作らない
            if ( paramList == null || paramList.Count <= 0 )
            {
                return;
            }

            foreach (object param in paramList)
            {
                GetPrmPartsBrcdParaWork paramWork = null;

                if (param == null || !( param is GetPrmPartsBrcdParaWork ))
                {
                    continue;
                }
                paramWork = param as GetPrmPartsBrcdParaWork;

                if (!string.IsNullOrEmpty( whereString ))
                {
                    //whereStringに文字列が含まれている場合、先頭の条件なのでWHERE文字列を追加
                    queryText.AppendLine( whereString );
                    whereString = string.Empty;

                    //先頭の抽出条件を追加
                    queryText.AppendFormat( OfferPrmPartsBrcdInfoDB.WhereFormatTop, paramWork.MakerCode, paramWork.BLGoodsCode );
                    queryText.AppendLine();
                }
                else
                {
                    //whereStringに文字列が含まれていない場合、先頭以降の抽出条件を追加
                    queryText.AppendFormat( OfferPrmPartsBrcdInfoDB.WhereFormat, paramWork.MakerCode, paramWork.BLGoodsCode );
                    queryText.AppendLine();
                }
            }
        }

        /// <summary>
        /// 優良部品バーコード情報抽出結果ワークオブジェクトの生成
        /// </summary>
        /// <param name="myReader">優良部品バーコード情報抽出結果のデータストリーム</param>
        /// <returns>優良部品バーコード情報抽出結果ワーク</returns>
        /// <remarks>
        /// <br>Note       : 優良部品バーコード情報抽出クエリを実行して得たデータストリームの現在位置のレコードから結果ワークオブジェクトを生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private RettPrmPartsBrcdInfoWork CopyToPrmPartsBrcdInfoWorkFromDataReader( ref SqlDataReader myReader )
        {
            RettPrmPartsBrcdInfoWork prmPartsBrcdInfoWork = new RettPrmPartsBrcdInfoWork();
            prmPartsBrcdInfoWork.OfferDate = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );  // 提供日付
            prmPartsBrcdInfoWork.PartsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );  // 部品メーカーコード
            prmPartsBrcdInfoWork.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );  // BL部品コード
            prmPartsBrcdInfoWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSNOWITHHRF" ) );  // 優良品番(－付き品番)
            prmPartsBrcdInfoWork.PrimePrtsBarCdKndDiv = SqlDataMediator.SqlGetInt16( myReader, myReader.GetOrdinal( "PRIMEPRTSBARCDKNDDIVRF" ) );  // 部品バーコード種別
            prmPartsBrcdInfoWork.PrimePartsBarCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRIMEPARTSBARCODERF" ) );  // 部品バーコード情報
            return prmPartsBrcdInfoWork;
        }

        /// <summary>
        /// SQL Serverデータベース接続情報処理
        /// </summary>
        /// <returns>SQL Serverデータベースとの接続情報</returns>
        /// <remarks>
        /// <br>Note       : SQL Serverデータベースへの開いた接続情報を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_OfferDB );
            if (string.IsNullOrEmpty( connectionText ))
                return null;

            retSqlConnection = new SqlConnection( connectionText );

            return retSqlConnection;
        }

        #endregion プライベートメソッド

    }
}
