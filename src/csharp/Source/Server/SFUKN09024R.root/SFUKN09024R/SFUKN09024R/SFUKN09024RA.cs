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
	/// 自社名称設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自社名称設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 22027　橋本　将樹</br>
	/// <br>Date       : 2005.09.08</br>
	/// <br></br>
	/// <br>Update Note: PM.NS用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.20</br>
    /// </remarks>
	[Serializable]
    public class CompanyNmDB : RemoteDB, ICompanyNmDB, IGetSyncdataList
	{
		/// <summary>
		/// 自社名称設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public CompanyNmDB() :
			base("SFUKN09026D", "Broadleaf.Application.Remoting.ParamData.CompanyNmWork", "CompanyNmRF") //基底クラスのコンストラクタ
		{
		}
		
		/// <summary>
		/// 指定された企業コードの自社名称設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの自社名称設定LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			return SearchProc(out retobj,paraobj ,readMode ,logicalMode);
		}

		/// <summary>
		/// 指定された企業コードの自社名称設定LISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの自社名称設定LISTを全て戻します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		private int SearchProc(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			CompanyNmWork companynmWork = new CompanyNmWork();
			companynmWork = null;

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				companynmWork = paraobj as CompanyNmWork;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                string selectTxt = string.Empty; // 2008.05.20 add  

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.20 upd start -------------------------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY COMPANYNAMECDRF ",sqlConnection);
                    selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                    selectTxt += "    ,POSTNORF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                    selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                    selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                    selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    selectTxt += " ORDER BY COMPANYNAMECDRF" + Environment.NewLine;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                    // 2008.05.20 upd end ----------------------------------------------------------------------------<<
                    
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.20 upd start -------------------------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY COMPANYNAMECDRF ",sqlConnection);
                    selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                    selectTxt += "    ,POSTNORF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                    selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                    selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                    selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    selectTxt += " ORDER BY COMPANYNAMECDRF" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                    // 2008.05.20 upd end ----------------------------------------------------------------------------<<

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.20 upd start -------------------------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY COMPANYNAMECDRF ",sqlConnection);
                    selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                    selectTxt += "    ,POSTNORF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                    selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                    selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                    selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                    selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                    selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                    selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                    selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                    selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " ORDER BY COMPANYNAMECDRF" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                    // 2008.05.20 upd end ----------------------------------------------------------------------------<<
                }
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				while(myReader.Read())
				{
					CompanyNmWork wkCompanyNmWork = new CompanyNmWork();

                    wkCompanyNmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkCompanyNmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkCompanyNmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkCompanyNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkCompanyNmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkCompanyNmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkCompanyNmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkCompanyNmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkCompanyNmWork.CompanyNameCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECDRF"));
                    wkCompanyNmWork.CompanyPr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
                    wkCompanyNmWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                    wkCompanyNmWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                    wkCompanyNmWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                    wkCompanyNmWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                    wkCompanyNmWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                    wkCompanyNmWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                    wkCompanyNmWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                    wkCompanyNmWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                    wkCompanyNmWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                    wkCompanyNmWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                    wkCompanyNmWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                    wkCompanyNmWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                    wkCompanyNmWork.TransferGuidance = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
                    wkCompanyNmWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                    wkCompanyNmWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                    wkCompanyNmWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                    wkCompanyNmWork.CompanySetNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
                    wkCompanyNmWork.CompanySetNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
                    wkCompanyNmWork.ImageInfoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
                    wkCompanyNmWork.ImageInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
                    wkCompanyNmWork.CompanyUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
                    wkCompanyNmWork.CompanyPrSentence2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
                    wkCompanyNmWork.ImageCommentForPrt1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
                    wkCompanyNmWork.ImageCommentForPrt2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));

					al.Add(wkCompanyNmWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"CompanyNmDB.Search Exception="+ex.Message);
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if(sqlCommand != null)sqlCommand.Dispose();
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			retobj = al;
			return status;

		}
		
		/// <summary>
		/// 指定された企業コードの自社名称設定を戻します
		/// </summary>
		/// <param name="parabyte">CompanyNmWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの自社名称設定を戻します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// 指定された企業コードの自社名称設定を戻します
        /// </summary>
        /// <param name="parabyte">CompanyNmWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの自社名称設定を戻します</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2005.09.08</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			CompanyNmWork  companynmWork = null;

			try 
			{			
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				companynmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
                // 2008.05.20 upd start ------------------------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD ", sqlConnection))
                string selectTxt = string.Empty;

                selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                selectTxt += "    ,POSTNORF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection)) 
                // 2008.05.20 upd end ---------------------------------------------------------------<<
                {
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaCompanyNameCd = sqlCommand.Parameters.Add("@FINDCOMPANYNAMECD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
					findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
                        companynmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        companynmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        companynmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        companynmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        companynmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        companynmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        companynmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        companynmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        companynmWork.CompanyNameCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECDRF"));
                        companynmWork.CompanyPr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
                        companynmWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
                        companynmWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
                        companynmWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                        companynmWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                        companynmWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                        companynmWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                        companynmWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
                        companynmWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
                        companynmWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
                        companynmWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
                        companynmWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
                        companynmWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
                        companynmWork.TransferGuidance = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
                        companynmWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                        companynmWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                        companynmWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                        companynmWork.CompanySetNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
                        companynmWork.CompanySetNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
                        companynmWork.ImageInfoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
                        companynmWork.ImageInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
                        companynmWork.CompanyUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
                        companynmWork.CompanyPrSentence2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
                        companynmWork.ImageCommentForPrt1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
                        companynmWork.ImageCommentForPrt2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
				// XMLへ変換し、文字列のバイナリ化
				parabyte = XmlByteSerializer.Serialize(companynmWork);
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"CompanyNmDB.Read Exception="+ex.Message);
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}


			return status;
		}

		/// <summary>
		/// 自社名称設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">CompanyNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自社名称設定情報を登録、更新します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		public int Write(ref byte[] parabyte)
		{
            return this.WriteProc(ref parabyte);
        }
        /// <summary>
        /// 自社名称設定情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">CompanyNmWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自社名称設定情報を登録、更新します</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2005.09.08</br>
        private int WriteProc(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				CompanyNmWork companynmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
                // 2008.05.20 upd start ------------------------------------------------>>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, COMPANYNAMECDRF FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD ", sqlConnection))

                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.20 upd end --------------------------------------------------<<
                {
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaCompanyNameCd = sqlCommand.Parameters.Add("@FINDCOMPANYNAMECD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
					findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);

					myReader = sqlCommand.ExecuteReader();

                    sqlTxt = string.Empty; // 2008.05.20 add

                    if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != companynmWork.UpdateDateTime)
						{
							//新規登録で該当データ有りの場合には重複
							if (companynmWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//既存データで更新日時違いの場合には排他
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
                        
                        // del 2007.05.16 Saitoh >>>>>>>>>>
						//sqlCommand.CommandText = "UPDATE COMPANYNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYNAMECDRF=@COMPANYNAMECD , COMPANYPRRF=@COMPANYPR , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 , POSTNORF=@POSTNO , ADDRESS1RF=@ADDRESS1 , ADDRESS2RF=@ADDRESS2 , ADDRESS3RF=@ADDRESS3 , ADDRESS4RF=@ADDRESS4 , COMPANYTELNO1RF=@COMPANYTELNO1 , COMPANYTELNO2RF=@COMPANYTELNO2 , COMPANYTELNO3RF=@COMPANYTELNO3 , COMPANYTELTITLE1RF=@COMPANYTELTITLE1 , COMPANYTELTITLE2RF=@COMPANYTELTITLE2 , COMPANYTELTITLE3RF=@COMPANYTELTITLE3 , TRANSFERGUIDANCERF=@TRANSFERGUIDANCE , ACCOUNTNOINFO1RF=@ACCOUNTNOINFO1 , ACCOUNTNOINFO2RF=@ACCOUNTNOINFO2 , ACCOUNTNOINFO3RF=@ACCOUNTNOINFO3 , COMPANYSETNOTE1RF=@COMPANYSETNOTE1 , COMPANYSETNOTE2RF=@COMPANYSETNOTE2 , TAKEINIMAGEGROUPCDRF=@TAKEINIMAGEGROUPCD , COMPANYURLRF=@COMPANYURL , COMPANYPRSENTENCE2RF=@COMPANYPRSENTENCE2 , IMAGECOMMENTFORPRT1RF=@IMAGECOMMENTFORPRT1 , IMAGECOMMENTFORPRT2RF=@IMAGECOMMENTFORPRT2 " + 
						//	"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD";
                        // del 2007.05.16 Saitoh <<<<<<<<<<

                        // 2008.05.20 upd start ----------------------------------------------------------------->>
                        // add 2007.05.16 Saitoh >>>>>>>>>>
                        //sqlCommand.CommandText = "UPDATE COMPANYNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYNAMECDRF=@COMPANYNAMECD , COMPANYPRRF=@COMPANYPR , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 , POSTNORF=@POSTNO , ADDRESS1RF=@ADDRESS1 , ADDRESS2RF=@ADDRESS2 , ADDRESS3RF=@ADDRESS3 , ADDRESS4RF=@ADDRESS4 , COMPANYTELNO1RF=@COMPANYTELNO1 , COMPANYTELNO2RF=@COMPANYTELNO2 , COMPANYTELNO3RF=@COMPANYTELNO3 , COMPANYTELTITLE1RF=@COMPANYTELTITLE1 , COMPANYTELTITLE2RF=@COMPANYTELTITLE2 , COMPANYTELTITLE3RF=@COMPANYTELTITLE3 , TRANSFERGUIDANCERF=@TRANSFERGUIDANCE , ACCOUNTNOINFO1RF=@ACCOUNTNOINFO1 , ACCOUNTNOINFO2RF=@ACCOUNTNOINFO2 , ACCOUNTNOINFO3RF=@ACCOUNTNOINFO3 , COMPANYSETNOTE1RF=@COMPANYSETNOTE1 , COMPANYSETNOTE2RF=@COMPANYSETNOTE2 , IMAGEINFODIVRF=@IMAGEINFODIV , IMAGEINFOCODERF=@IMAGEINFOCODE , COMPANYURLRF=@COMPANYURL , COMPANYPRSENTENCE2RF=@COMPANYPRSENTENCE2 , IMAGECOMMENTFORPRT1RF=@IMAGECOMMENTFORPRT1 , IMAGECOMMENTFORPRT2RF=@IMAGECOMMENTFORPRT2 " +
                        //    "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD";
                        // add 2007.05.16 Saitoh <<<<<<<<<<

                        sqlTxt += "UPDATE COMPANYNMRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , COMPANYNAMECDRF=@COMPANYNAMECD" + Environment.NewLine;
                        sqlTxt += " , COMPANYPRRF=@COMPANYPR" + Environment.NewLine;
                        sqlTxt += " , COMPANYNAME1RF=@COMPANYNAME1" + Environment.NewLine;
                        sqlTxt += " , COMPANYNAME2RF=@COMPANYNAME2" + Environment.NewLine;
                        sqlTxt += " , POSTNORF=@POSTNO" + Environment.NewLine;
                        sqlTxt += " , ADDRESS1RF=@ADDRESS1" + Environment.NewLine;
                        sqlTxt += " , ADDRESS3RF=@ADDRESS3" + Environment.NewLine;
                        sqlTxt += " , ADDRESS4RF=@ADDRESS4" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELNO1RF=@COMPANYTELNO1" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELNO2RF=@COMPANYTELNO2" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELNO3RF=@COMPANYTELNO3" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELTITLE1RF=@COMPANYTELTITLE1" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELTITLE2RF=@COMPANYTELTITLE2" + Environment.NewLine;
                        sqlTxt += " , COMPANYTELTITLE3RF=@COMPANYTELTITLE3" + Environment.NewLine;
                        sqlTxt += " , TRANSFERGUIDANCERF=@TRANSFERGUIDANCE" + Environment.NewLine;
                        sqlTxt += " , ACCOUNTNOINFO1RF=@ACCOUNTNOINFO1" + Environment.NewLine;
                        sqlTxt += " , ACCOUNTNOINFO2RF=@ACCOUNTNOINFO2" + Environment.NewLine;
                        sqlTxt += " , ACCOUNTNOINFO3RF=@ACCOUNTNOINFO3" + Environment.NewLine;
                        sqlTxt += " , COMPANYSETNOTE1RF=@COMPANYSETNOTE1" + Environment.NewLine;
                        sqlTxt += " , COMPANYSETNOTE2RF=@COMPANYSETNOTE2" + Environment.NewLine;
                        sqlTxt += " , IMAGEINFODIVRF=@IMAGEINFODIV" + Environment.NewLine;
                        sqlTxt += " , IMAGEINFOCODERF=@IMAGEINFOCODE" + Environment.NewLine;
                        sqlTxt += " , COMPANYURLRF=@COMPANYURL" + Environment.NewLine;
                        sqlTxt += " , COMPANYPRSENTENCE2RF=@COMPANYPRSENTENCE2" + Environment.NewLine;
                        sqlTxt += " , IMAGECOMMENTFORPRT1RF=@IMAGECOMMENTFORPRT1" + Environment.NewLine;
                        sqlTxt += " , IMAGECOMMENTFORPRT2RF=@IMAGECOMMENTFORPRT2" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.20 upd end -------------------------------------------------------------------<<

						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
						findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)companynmWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						if (companynmWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

						//新規作成時のSQL文を生成
                        // del 2007.05.16 Saitoh >>>>>>>>>>
						//sqlCommand.CommandText = "INSERT INTO COMPANYNMRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYNAMECDRF, COMPANYPRRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, TRANSFERGUIDANCERF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, COMPANYSETNOTE1RF, COMPANYSETNOTE2RF, TAKEINIMAGEGROUPCDRF, COMPANYURLRF, COMPANYPRSENTENCE2RF, IMAGECOMMENTFORPRT1RF, IMAGECOMMENTFORPRT2RF) " +
						//	"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYNAMECD, @COMPANYPR, @COMPANYNAME1, @COMPANYNAME2, @POSTNO, @ADDRESS1, @ADDRESS2, @ADDRESS3, @ADDRESS4, @COMPANYTELNO1, @COMPANYTELNO2, @COMPANYTELNO3, @COMPANYTELTITLE1, @COMPANYTELTITLE2, @COMPANYTELTITLE3, @TRANSFERGUIDANCE, @ACCOUNTNOINFO1, @ACCOUNTNOINFO2, @ACCOUNTNOINFO3, @COMPANYSETNOTE1, @COMPANYSETNOTE2, @TAKEINIMAGEGROUPCD, @COMPANYURL, @COMPANYPRSENTENCE2, @IMAGECOMMENTFORPRT1, @IMAGECOMMENTFORPRT2)";
                        // del 2007.05.16 Saitoh <<<<<<<<<<

                        // 2008.05.20 upd start ------------------------------------------------------------------>>
                        // add 2007.05.16 Saitoh >>>>>>>>>>
                        //sqlCommand.CommandText = "INSERT INTO COMPANYNMRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYNAMECDRF, COMPANYPRRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, TRANSFERGUIDANCERF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, COMPANYSETNOTE1RF, COMPANYSETNOTE2RF, IMAGEINFODIVRF, IMAGEINFOCODERF, COMPANYURLRF, COMPANYPRSENTENCE2RF, IMAGECOMMENTFORPRT1RF, IMAGECOMMENTFORPRT2RF) " +
                        //    "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYNAMECD, @COMPANYPR, @COMPANYNAME1, @COMPANYNAME2, @POSTNO, @ADDRESS1, @ADDRESS2, @ADDRESS3, @ADDRESS4, @COMPANYTELNO1, @COMPANYTELNO2, @COMPANYTELNO3, @COMPANYTELTITLE1, @COMPANYTELTITLE2, @COMPANYTELTITLE3, @TRANSFERGUIDANCE, @ACCOUNTNOINFO1, @ACCOUNTNOINFO2, @ACCOUNTNOINFO3, @COMPANYSETNOTE1, @COMPANYSETNOTE2, @IMAGEINFODIV, @IMAGEINFOCODE, @COMPANYURL, @COMPANYPRSENTENCE2, @IMAGECOMMENTFORPRT1, @IMAGECOMMENTFORPRT2)";
                        sqlTxt += "INSERT INTO COMPANYNMRF" + Environment.NewLine;
                        sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                        sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                        sqlTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                        sqlTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                        sqlTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                        sqlTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                        sqlTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                        sqlTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                        sqlTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                        sqlTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                        sqlTxt += " )" + Environment.NewLine;
                        sqlTxt += " VALUES" + Environment.NewLine;
                        sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYNAMECD" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYPR" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYNAME1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYNAME2" + Environment.NewLine;
                        sqlTxt += "    ,@POSTNO" + Environment.NewLine;
                        sqlTxt += "    ,@ADDRESS1" + Environment.NewLine;
                        sqlTxt += "    ,@ADDRESS3" + Environment.NewLine;
                        sqlTxt += "    ,@ADDRESS4" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELNO1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELNO2" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELNO3" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELTITLE1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELTITLE2" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYTELTITLE3" + Environment.NewLine;
                        sqlTxt += "    ,@TRANSFERGUIDANCE" + Environment.NewLine;
                        sqlTxt += "    ,@ACCOUNTNOINFO1" + Environment.NewLine;
                        sqlTxt += "    ,@ACCOUNTNOINFO2" + Environment.NewLine;
                        sqlTxt += "    ,@ACCOUNTNOINFO3" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYSETNOTE1" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYSETNOTE2" + Environment.NewLine;
                        sqlTxt += "    ,@IMAGEINFODIV" + Environment.NewLine;
                        sqlTxt += "    ,@IMAGEINFOCODE" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYURL" + Environment.NewLine;
                        sqlTxt += "    ,@COMPANYPRSENTENCE2" + Environment.NewLine;
                        sqlTxt += "    ,@IMAGECOMMENTFORPRT1" + Environment.NewLine;
                        sqlTxt += "    ,@IMAGECOMMENTFORPRT2" + Environment.NewLine;
                        sqlTxt += " )" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        // add 2007.05.16 Saitoh <<<<<<<<<<
                        // 2008.05.20 upd end --------------------------------------------------------------------<<

						//登録ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)companynmWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetInsertHeader(ref flhd,obj);
					}
					if(!myReader.IsClosed)myReader.Close();
                    
					//Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraCompanyNameCd = sqlCommand.Parameters.Add("@COMPANYNAMECD", SqlDbType.Int);
                    SqlParameter paraCompanyPr = sqlCommand.Parameters.Add("@COMPANYPR", SqlDbType.NVarChar);
                    SqlParameter paraCompanyName1 = sqlCommand.Parameters.Add("@COMPANYNAME1", SqlDbType.NVarChar);
                    SqlParameter paraCompanyName2 = sqlCommand.Parameters.Add("@COMPANYNAME2", SqlDbType.NVarChar);
                    SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                    SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                    SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                    SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelNo1 = sqlCommand.Parameters.Add("@COMPANYTELNO1", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelNo2 = sqlCommand.Parameters.Add("@COMPANYTELNO2", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelNo3 = sqlCommand.Parameters.Add("@COMPANYTELNO3", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelTitle1 = sqlCommand.Parameters.Add("@COMPANYTELTITLE1", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelTitle2 = sqlCommand.Parameters.Add("@COMPANYTELTITLE2", SqlDbType.NVarChar);
                    SqlParameter paraCompanyTelTitle3 = sqlCommand.Parameters.Add("@COMPANYTELTITLE3", SqlDbType.NVarChar);
                    SqlParameter paraTransferGuidance = sqlCommand.Parameters.Add("@TRANSFERGUIDANCE", SqlDbType.NVarChar);
                    SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                    SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                    SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                    SqlParameter paraCompanySetNote1 = sqlCommand.Parameters.Add("@COMPANYSETNOTE1", SqlDbType.NVarChar);
                    SqlParameter paraCompanySetNote2 = sqlCommand.Parameters.Add("@COMPANYSETNOTE2", SqlDbType.NVarChar);
                    SqlParameter paraImageInfoDiv = sqlCommand.Parameters.Add("@IMAGEINFODIV", SqlDbType.Int);
                    SqlParameter paraImageInfoCode = sqlCommand.Parameters.Add("@IMAGEINFOCODE", SqlDbType.Int);
                    SqlParameter paraCompanyUrl = sqlCommand.Parameters.Add("@COMPANYURL", SqlDbType.NVarChar);
                    SqlParameter paraCompanyPrSentence2 = sqlCommand.Parameters.Add("@COMPANYPRSENTENCE2", SqlDbType.NVarChar);
                    SqlParameter paraImageCommentForPrt1 = sqlCommand.Parameters.Add("@IMAGECOMMENTFORPRT1", SqlDbType.NVarChar);
                    SqlParameter paraImageCommentForPrt2 = sqlCommand.Parameters.Add("@IMAGECOMMENTFORPRT2", SqlDbType.NVarChar);

					//Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companynmWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companynmWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(companynmWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(companynmWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(companynmWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(companynmWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(companynmWork.LogicalDeleteCode);
                    paraCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);
                    paraCompanyPr.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyPr);
                    paraCompanyName1.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyName1);
                    paraCompanyName2.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyName2);
                    paraPostNo.Value = SqlDataMediator.SqlSetString(companynmWork.PostNo);
                    paraAddress1.Value = SqlDataMediator.SqlSetString(companynmWork.Address1);
                    paraAddress3.Value = SqlDataMediator.SqlSetString(companynmWork.Address3);
                    paraAddress4.Value = SqlDataMediator.SqlSetString(companynmWork.Address4);
                    paraCompanyTelNo1.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyTelNo1);
                    paraCompanyTelNo2.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyTelNo2);
                    paraCompanyTelNo3.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyTelNo3);
                    paraCompanyTelTitle1.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyTelTitle1);
                    paraCompanyTelTitle2.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyTelTitle2);
                    paraCompanyTelTitle3.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyTelTitle3);
                    paraTransferGuidance.Value = SqlDataMediator.SqlSetString(companynmWork.TransferGuidance);
                    paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(companynmWork.AccountNoInfo1);
                    paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(companynmWork.AccountNoInfo2);
                    paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(companynmWork.AccountNoInfo3);
                    paraCompanySetNote1.Value = SqlDataMediator.SqlSetString(companynmWork.CompanySetNote1);
                    paraCompanySetNote2.Value = SqlDataMediator.SqlSetString(companynmWork.CompanySetNote2);
                    paraImageInfoDiv.Value = SqlDataMediator.SqlSetInt32(companynmWork.ImageInfoDiv);
                    paraImageInfoCode.Value = SqlDataMediator.SqlSetInt32(companynmWork.ImageInfoCode);
                    paraCompanyUrl.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyUrl);
                    paraCompanyPrSentence2.Value = SqlDataMediator.SqlSetString(companynmWork.CompanyPrSentence2);
                    paraImageCommentForPrt1.Value = SqlDataMediator.SqlSetString(companynmWork.ImageCommentForPrt1);
                    paraImageCommentForPrt2.Value = SqlDataMediator.SqlSetString(companynmWork.ImageCommentForPrt2);

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(companynmWork);

				}
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"CompanyNmDB.Write Exception="+ex.Message);
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// 自社名称設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">CompanyNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自社名称設定情報を論理削除します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除自社名称設定情報を復活します
		/// </summary>
		/// <param name="parabyte">CompanyNmWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除自社名称設定情報を復活します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// 自社名称設定情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">CompanyNmWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自社名称設定情報の論理削除を操作します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			try		
			{
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				CompanyNmWork companynmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.20 upd start ----------------------------------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, COMPANYNAMECDRF FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.20 upd end -------------------------------------------------------------------------<<
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaCompanyNameCd = sqlCommand.Parameters.Add("@FINDCOMPANYNAMECD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
					findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);

					myReader = sqlCommand.ExecuteReader();

   					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != companynmWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//現在の論理削除区分を取得
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        
                        // 2008.05.20 upd start ------------------------------------------>>
						//sqlCommand.CommandText = "UPDATE COMPANYNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE COMPANYNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.20 upd end --------------------------------------------<<
                        
                        //KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
						findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)companynmWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					sqlCommand.Cancel();
					if(!myReader.IsClosed)myReader.Close();

					//論理削除モードの場合
					if (procMode == 0)
					{
						if		(logicalDelCd == 3)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						else if	(logicalDelCd == 0)	companynmWork.LogicalDeleteCode = 1;//論理削除フラグをセット
						else						companynmWork.LogicalDeleteCode = 3;//完全削除フラグをセット
					}
					else
					{
						if		(logicalDelCd == 1)	companynmWork.LogicalDeleteCode = 0;//論理削除フラグを解除
						else
						{
							if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
							else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
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
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companynmWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(companynmWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(companynmWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(companynmWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(companynmWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(companynmWork);
				}
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"CompanyNmDB.LogicalDeleteProc Exception="+ex.Message);
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}

			return status;

		}

		/// <summary>
		/// 自社名称設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">自社名称設定オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 自社名称設定情報を物理削除します</br>
		/// <br>Programmer : 22027　橋本　将樹</br>
		/// <br>Date       : 2005.09.08</br>
		public int Delete(byte[] parabyte)
		{
            return DeleteProc(parabyte);
        }
        /// <summary>
        /// 自社名称設定情報を物理削除します
        /// </summary>
        /// <param name="parabyte">自社名称設定オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 自社名称設定情報を物理削除します</br>
        /// <br>Programmer : 22027　橋本　将樹</br>
        /// <br>Date       : 2005.09.08</br>
        private int DeleteProc(byte[] parabyte)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			try 
			{
				//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				CompanyNmWork companynmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.20 upd start -------------------------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, COMPANYNAMECDRF FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD", sqlConnection))
				
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.20 upd end ----------------------------------------------------------------<<
                {
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaCompanyNameCd = sqlCommand.Parameters.Add("@FINDCOMPANYNAMECD", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
					findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);

					myReader = sqlCommand.ExecuteReader();

                    sqlTxt = string.Empty; // 2008.05.20 add
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != companynmWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}

                        // 2008.05.20 upd start ------------------------------------------------------->>
						//sqlCommand.CommandText = "DELETE FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.20 upd end ---------------------------------------------------------<<
                        
                        //KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companynmWork.EnterpriseCode);
						findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companynmWork.CompanyNameCd);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(!myReader.IsClosed)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					if(!myReader.IsClosed)myReader.Close();

					sqlCommand.ExecuteNonQuery();
				}
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"CompanyNmDB.Delete Exception="+ex.Message);
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			return status;

		}

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataList(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.20 upd start --------------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF  ", sqlConnection);
                string selectTxt = string.Empty;

                selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                selectTxt += "    ,POSTNORF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                // 2008.05.20 upd end -----------------------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCompanyNmWorkFromReader(ref myReader));

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
        #endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
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

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CompanyNmWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CompanyNmWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2006.12.06</br>
        /// </remarks>
        private CompanyNmWork CopyToCompanyNmWorkFromReader(ref SqlDataReader myReader)
        {
            CompanyNmWork wkCompanyNmWork = new CompanyNmWork();
            
            #region クラスへ格納
            wkCompanyNmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCompanyNmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCompanyNmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCompanyNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCompanyNmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCompanyNmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCompanyNmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCompanyNmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCompanyNmWork.CompanyNameCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECDRF"));
            wkCompanyNmWork.CompanyPr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
            wkCompanyNmWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
            wkCompanyNmWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
            wkCompanyNmWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            wkCompanyNmWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            wkCompanyNmWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            wkCompanyNmWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            wkCompanyNmWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
            wkCompanyNmWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
            wkCompanyNmWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
            wkCompanyNmWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
            wkCompanyNmWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
            wkCompanyNmWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
            wkCompanyNmWork.TransferGuidance = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
            wkCompanyNmWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
            wkCompanyNmWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
            wkCompanyNmWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
            wkCompanyNmWork.CompanySetNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
            wkCompanyNmWork.CompanySetNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
            wkCompanyNmWork.ImageInfoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
            wkCompanyNmWork.ImageInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
            wkCompanyNmWork.CompanyUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
            wkCompanyNmWork.CompanyPrSentence2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
            wkCompanyNmWork.ImageCommentForPrt1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
            wkCompanyNmWork.ImageCommentForPrt2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
            #endregion

            return wkCompanyNmWork;
        }
        #endregion

    
    
    }
}
