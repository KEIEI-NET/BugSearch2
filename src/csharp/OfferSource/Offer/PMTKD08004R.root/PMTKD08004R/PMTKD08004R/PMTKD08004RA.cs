using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票(売上伝票)提供リモートオブジェクト
	/// </summary>
	/// <remarks>
    /// <br>Note         : 自由帳票(売上伝票)に関する提供データの検索を行うクラスです。</br>
	/// <br>Programmer   : 22018 鈴木 正臣</br>
	/// <br>Date         : 2008.06.06</br>
	/// <br></br>
	/// <br>UpdateNote   : </br>
	/// </remarks>
	[Serializable]
    public class FrePSalesSlipOfferDB : RemoteDB, IFrePSalesSlipOfferDB
	{
		#region Constructor
		/// <summary>
		/// 自由帳票(売上伝票)提供リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer	: 22018 鈴木 正臣</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
		public FrePSalesSlipOfferDB()
            : base( "PMTKD08006D", "", "" )
		{
		}
		#endregion

        #region IFrePSalesSlipOfferDB メンバ
        /// <summary>
		/// 自由帳票(売上伝票)提供検索処理
		/// </summary>
		/// <param name="retCustomSerializeArrayList">印字項目情報カスタムシリアライズLIST</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票項目設定マスタ配列を取得します。</br>
		/// <br>Programmer	: 22018 鈴木 正臣</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchFrePSalesSlipOffer( ref object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
        {
            return SearchFrePSalesSlipOfferProc( ref retCustomSerializeArrayList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票(売上伝票)提供検索処理
        /// </summary>
        /// <param name="retCustomSerializeArrayList">印字項目情報カスタムシリアライズLIST</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchFrePSalesSlipOfferProc( ref object retCustomSerializeArrayList, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            msgDiv = false;
            errMsg = string.Empty;

			SqlConnection sqlConnection = null;
			try
			{
                CustomSerializeArrayList retWork = (CustomSerializeArrayList)retCustomSerializeArrayList;

				//SQL文生成
				using (sqlConnection = CreateSqlConnection())
				{
					sqlConnection.Open();

                    status = SearchProc( ref retWork, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        retWork = new CustomSerializeArrayList();
                    }
				}
			}
			catch (SqlException ex)
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex, "PrtItemSetDB.SearchPrtItemSet", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "自由帳票(売上伝票)提供検索中にタイムアウトが発生しました。";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "PrtItemSetDB.SearchPrtItemSet", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}

		#endregion

		#region PrivateMethod
		/// <summary>
		/// 自由帳票(売上伝票)提供検索処理（メイン部）
		/// </summary>
        /// <param name="frePSalesSlipOfferWork"></param>
        /// <param name="sqlConnection">SQLコネクション</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票項目設定マスタLISTを取得します。</br>
		/// <br>Programmer	: 22018 鈴木 正臣</br>
		/// <br>Date		: 2007.05.07</br>
		/// </remarks>
        public int SearchProc( ref CustomSerializeArrayList frePSalesSlipOfferWork, ref SqlConnection sqlConnection )
        {
            return SearchProcProc( ref frePSalesSlipOfferWork, ref sqlConnection );
        }
        /// <summary>
        /// 自由帳票(売上伝票)提供検索処理（メイン部）
        /// </summary>
        /// <param name="frePSalesSlipOfferWork"></param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        private int SearchProcProc( ref CustomSerializeArrayList frePSalesSlipOfferWork, ref SqlConnection sqlConnection )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retWork = new CustomSerializeArrayList();

            foreach ( object obj in frePSalesSlipOfferWork )
            {
                if ( obj is TbsPartsCodeWork[] )
                {
                    //----------------------------------------------------
                    // ＢＬコード（提供）
                    //----------------------------------------------------
                    TbsPartsCodeWork[] retTbsPartsCodeWorks;
                    SearchTbsPartsCode( (obj as TbsPartsCodeWork[]), out retTbsPartsCodeWorks, ref sqlConnection );
                    
                    retWork.Add( retTbsPartsCodeWorks );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if ( obj is PMakerNmWork[] )
                {
                    //----------------------------------------------------
                    // 部品メーカー（提供）
                    //----------------------------------------------------
                    PMakerNmWork[] retPMakerNmWorks;
                    SearchPMakerNm( (obj as PMakerNmWork[]), out retPMakerNmWorks, ref sqlConnection );

                    retWork.Add( retPMakerNmWorks );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            frePSalesSlipOfferWork = retWork;

			return status;
        }

        # region [Search ＢＬコードマスタ提供]
        /// <summary>
        /// Search ＢＬコードマスタ提供
        /// </summary>
        /// <param name="paraWorks"></param>
        /// <param name="retWorks"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchTbsPartsCode( TbsPartsCodeWork[] paraWorks, out TbsPartsCodeWork[] retWorks, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            retWorks = new TbsPartsCodeWork[0];

            try
            {
                List<TbsPartsCodeWork> retList = new List<TbsPartsCodeWork>();

                //Selectコマンドの生成
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand( "SELECT TBSPARTSCODERF, TBSPARTSFULLNAMERF, TBSPARTSHALFNAMERF FROM TBSPARTSCODERF ", sqlConnection );
                sqlCommand.CommandText += MakeWhereStringForTbsPartsCode( ref sqlCommand, paraWorks );

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial );

                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    TbsPartsCodeWork work = new TbsPartsCodeWork();
                    work.TbsPartsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );
                    work.TbsPartsFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TBSPARTSFULLNAMERF" ) );
                    work.TbsPartsHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TBSPARTSHALFNAMERF" ) );
                    retList.Add( work );
                }
                if ( retList.Count > 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retWorks = retList.ToArray();
                }
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
			}

            return status;
        }

        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paraWorks"></param>
        /// <returns></returns>
        private string MakeWhereStringForTbsPartsCode( ref SqlCommand sqlCommand, TbsPartsCodeWork[] paraWorks )
        {
            StringBuilder whereString = new StringBuilder();

            // TbsPartsコード
            List<SqlParameter> paraList = new List<SqlParameter>();

            whereString.Append( " WHERE TBSPARTSCODERF IN ( " );
            for ( int index = 0; index < paraWorks.Length; index++ )
            {
                if ( index != 0 )
                {
                    whereString.Append( "," );
                }
                whereString.Append( string.Format("@FINDTBSPARTSCODE{0}",index));
                SqlParameter newPara = sqlCommand.Parameters.Add( string.Format( "@FINDTBSPARTSCODE{0}", index ), SqlDbType.Int );
                newPara.Value = paraWorks[index].TbsPartsCode;
                paraList.Add( newPara );
            }
            whereString.Append( " ) " );
            return whereString.ToString();
        }
        # endregion

        # region [Search 部品メーカー名称マスタ提供]
        /// <summary>
        /// Search 部品メーカー名称マスタ提供
        /// </summary>
        /// <param name="paraWorks"></param>
        /// <param name="retWorks"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchPMakerNm( PMakerNmWork[] paraWorks, out PMakerNmWork[] retWorks, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            retWorks = new PMakerNmWork[0];

            try
            {
                List<PMakerNmWork> retList = new List<PMakerNmWork>();

                //Selectコマンドの生成
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand( "SELECT PARTSMAKERCODERF, PARTSMAKERFULLNAMERF, PARTSMAKERHALFNAMERF FROM PMAKERNMRF ", sqlConnection );
                sqlCommand.CommandText += MakeWhereStringForPMakerNm( ref sqlCommand, paraWorks );

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial );

                myReader = sqlCommand.ExecuteReader();
                while ( myReader.Read() )
                {
                    PMakerNmWork work = new PMakerNmWork();
                    work.PartsMakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCODERF" ) );
                    work.PartsMakerFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSMAKERFULLNAMERF" ) );
                    work.PartsMakerHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTSMAKERHALFNAMERF" ) );
                    retList.Add( work );
                }
                if ( retList.Count > 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retWorks = retList.ToArray();
                }
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed ) myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paraWorks"></param>
        /// <returns></returns>
        private string MakeWhereStringForPMakerNm( ref SqlCommand sqlCommand, PMakerNmWork[] paraWorks )
        {
            StringBuilder whereString = new StringBuilder();

            // TbsPartsコード
            List<SqlParameter> paraList = new List<SqlParameter>();

            whereString.Append( " WHERE PARTSMAKERCODERF IN ( " );
            for ( int index = 0; index < paraWorks.Length; index++ )
            {
                if ( index != 0 )
                {
                    whereString.Append( "," );
                }
                whereString.Append( string.Format( "@FINDPARTSMAKERCODE{0}", index ) );
                SqlParameter newPara = sqlCommand.Parameters.Add( string.Format( "@FINDPARTSMAKERCODE{0}", index ), SqlDbType.Int );
                newPara.Value = paraWorks[index].PartsMakerCode;
                paraList.Add( newPara );
            }
            whereString.Append( " ) " );
            return whereString.ToString();
        }
        # endregion


        /// <summary>
		/// コネクション情報生成
		/// </summary>
		/// <returns>コネクション情報</returns>
		private SqlConnection CreateSqlConnection()
		{
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
			if (connectionText == null || connectionText == "") return null;

			return new SqlConnection(connectionText);
		}
		#endregion
	}
}
