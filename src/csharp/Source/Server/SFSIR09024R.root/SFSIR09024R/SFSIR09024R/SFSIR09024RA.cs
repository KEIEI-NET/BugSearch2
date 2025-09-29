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
	/// 支払設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class PaymentSetDB : RemoteDB, IRemoteDB, IPaymentSetDB
	{
		/// <summary>
		/// 支払設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		/// </remarks>
		public PaymentSetDB() :
		base("SFSIR09026D", "Broadleaf.Application.Remoting.ParamData.PaymentSetWork", "PAYMENTSETRF")
		{
		}
		#region 基底クラスを継承したメソッド
//		/// <summary>
//		/// 指定された企業コードの自社情報LISTを全て戻します
//		/// </summary>
//		/// <param name="retbyte">検索結果</param>
//		/// <param name="parabyte">検索パラメータ</param>
//		/// <param name="readMode">検索区分</param>
//		/// <param name="readCnt">READ件数（0の場合はALL）</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 指定された企業コードの自社情報LISTを全て戻します</br>
//		/// <br>Programmer : 21015　金巻　芳則</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,int readCnt)
//		{
//			return base.SearchDB(out retbyte, parabyte, readMode);
//		}
//
//		/// <summary>
//		/// 指定された企業コードの自社情報設定を戻します
//		/// </summary>
//		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
//		/// <param name="readMode">検索区分</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 指定された企業コードの自社情報設定を戻します</br>
//		/// <br>Programmer : 21015　金巻　芳則</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Read(ref byte[] parabyte , int readMode)
//		{
//			return base.ReadDB(ref parabyte, readMode);
//		}
//
//		/// <summary>
//		/// 自社情報設定情報を登録、更新します
//		/// </summary>
//		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
//		/// <param name="writeMode">登録、更新モード</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 自社情報設定情報を登録、更新します</br>
//		/// <br>Programmer : 21015　金巻　芳則</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Write(ref byte[] parabyte, int writeMode)
//		{
//			return base.WriteDB(ref parabyte, writeMode);
//		}
//
//		/// <summary>
//		/// 自社情報を論理削除します
//		/// </summary>
//		/// <param name="parabyte">CompanyInfWorkオブジェクト</param>
//		/// <param name="deleteMode">削除モード</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 自社情報を論理削除します</br>
//		/// <br>Programmer : 21015　金巻　芳則</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int LogicalDelete(ref byte[] parabyte, int deleteMode)
//		{
//			return base.LogicalDelete(ref parabyte, deleteMode);
//		}
//		
//		/// <summary>
//		/// 自社情報を物理削除します
//		/// </summary>
//		/// <param name="parabyte">自社情報オブジェクト</param>
//		/// <param name="deleteMode">削除モード</param>
//		/// <returns></returns>
//		/// <br>Note       : 自社情報を物理削除します</br>
//		/// <br>Programmer : 21015　金巻　芳則</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int Delete(byte[] parabyte, int deleteMode)
//		{
//			return base.Delete(ref parabyte, deleteMode);
//		}

		#endregion

		/// <summary>
		/// 指定された企業コードの支払設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:PaymentSetWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの支払設定LISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// 指定された企業コードの支払設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:PaymentSetWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの支払設定LISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		private int SearchCntProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;

			PaymentSetWork paymentsetWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM PAYMENTSETRF " + 
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
						sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM PAYMENTSETRF " + 
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",
						sqlConnection);
					//論理削除区分設定
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else 
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM PAYMENTSETRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

				//データリード
				retCnt = (int)sqlCommand.ExecuteScalar();
				if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"PaymentSetDB.SearchCntProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;
		}

		/// <summary>
		/// 指定された企業コードの支払LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの支払LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte ,readMode,logicalMode,0);
		}

        /// <summary>
        /// 指定された企業コードの支払LISTを全て戻します（論理削除除く）コネクション指定型
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの支払LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.04.13</br>
        public int Search(out PaymentSetWork[] outpaymentSetWork, PaymentSetWork paymentsetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;

            //PaymentSetWork paymentsetWork = new PaymentSetWork();
            outpaymentSetWork = null;

            //retbyte = null;

            //総件数を0で初期化
            retTotalCnt = 0;

            //件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = 0;
            int readCnt = 0;
            if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            //nextData = false;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //件数指定リードで一件目リードの場合データ総件数を取得
                if (readCnt > 0)
                {
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommandCount = new SqlCommand(
                            "SELECT COUNT (*) FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
                            sqlConnection);
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommandCount = new SqlCommand(
                            "SELECT COUNT (*) FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",
                            sqlConnection);
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommandCount = new SqlCommand(
                            "SELECT COUNT (*) FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
                            sqlConnection);
                    }
                    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand(
                            "SELECT * FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PAYSTMNGNORF",
                            sqlConnection);
                    }
                    else
                    {
                        //一件目リードの場合
                        if (paymentsetWork.PayStMngNo == 0)
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                        }
                        //Nextリードの場合
                        else
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                            SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
                            paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand(
                            "SELECT * FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
                            "ORDER BY PAYSTMNGNORF",
                            sqlConnection);
                    }
                    else
                    {
                        //一件目リードの場合
                        if (paymentsetWork.PayStMngNo == 0)
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                        }
                        //Nextリードの場合
                        else
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                            SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
                            paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand(
                            "SELECT * FROM PAYMENTSETRF " +
                            "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            "ORDER BY PAYSTMNGNORF",
                            sqlConnection);
                    }
                    else
                    {
                        //一件目リードの場合
                        if (paymentsetWork.PayStMngNo == 0)
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                        }
                        else
                        {
                            sqlCommand = new SqlCommand(
                                "SELECT TOP " + _readCnt.ToString() + " * FROM PAYMENTSETRF " +
                                "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
                                "ORDER BY PAYSTMNGNORF",
                                sqlConnection);
                            SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
                            paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
                        }
                    }
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

                //myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                myReader = sqlCommand.ExecuteReader();
                int retCnt = 0;
                while (myReader.Read())
                {
                    //戻り値カウンタカウント
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //戻り値の件数が取得指示件数を超えた場合終了
                        if (readCnt < retCnt)
                        {
                            //nextData = true;
                            break;
                        }
                    }
                    PaymentSetWork wkPaymentSetWork = new PaymentSetWork();

                    wkPaymentSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkPaymentSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkPaymentSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkPaymentSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkPaymentSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkPaymentSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkPaymentSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkPaymentSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkPaymentSetWork.PayStMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMNGNORF"));
                    wkPaymentSetWork.PayStMoneyKindCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD1RF"));
                    wkPaymentSetWork.PayStMoneyKindCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD2RF"));
                    wkPaymentSetWork.PayStMoneyKindCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD3RF"));
                    wkPaymentSetWork.PayStMoneyKindCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD4RF"));
                    wkPaymentSetWork.PayStMoneyKindCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD5RF"));
                    wkPaymentSetWork.PayStMoneyKindCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD6RF"));
                    wkPaymentSetWork.PayStMoneyKindCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD7RF"));
                    wkPaymentSetWork.PayStMoneyKindCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD8RF"));
                    wkPaymentSetWork.PayStMoneyKindCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD9RF"));
                    wkPaymentSetWork.PayStMoneyKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD10RF"));

                    al.Add(wkPaymentSetWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentSetDB.SearchProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader.IsClosed == false) myReader.Close();

                if (sqlCommandCount != null)
                {
                    sqlCommandCount.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                /*
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
                 */
            }

            // XMLへ変換し、文字列のバイナリ化
            outpaymentSetWork = (PaymentSetWork[])al.ToArray(typeof(PaymentSetWork));
            
            return status;

        }

		/// <summary>
		/// 指定された企業コードの支払LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの支払LISTを指定件数分全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
			return SearchProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
		}

		/// <summary>
		/// 指定された企業コードの支払LISTを全て戻します
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの支払LISTを全て戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		private int SearchProc(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommandCount = null;
			SqlCommand sqlCommand = null;

			PaymentSetWork paymentsetWork = new PaymentSetWork();
			paymentsetWork = null;

			retbyte = null;

			//総件数を0で初期化
			retTotalCnt = 0;

			//件数指定リードの場合には指定件数＋１件リードする
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//次レコード無しで初期化
			nextData = false;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得
				if (readCnt > 0)
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommandCount = new SqlCommand(
							"SELECT COUNT (*) FROM PAYMENTSETRF " + 
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
							sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommandCount = new SqlCommand(
							"SELECT COUNT (*) FROM PAYMENTSETRF " + 
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE",
							sqlConnection);
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else 
					{
						sqlCommandCount = new SqlCommand(
							"SELECT COUNT (*) FROM PAYMENTSETRF " + 
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
							sqlConnection);
					}
					SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

					retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				}

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand(
							"SELECT * FROM PAYMENTSETRF " +
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PAYSTMNGNORF",
							sqlConnection);
					}
					else
					{	
						//一件目リードの場合
						if (paymentsetWork.PayStMngNo == 0)
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " + 
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
							SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
							paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand(
							"SELECT * FROM PAYMENTSETRF " +
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
							"ORDER BY PAYSTMNGNORF",
							sqlConnection);
					}
					else
					{
						//一件目リードの場合
						if (paymentsetWork.PayStMngNo == 0)
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
						}
							//Nextリードの場合
						else
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
							SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
							paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
						}
					}
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					//件数指定無しの場合
					if (readCnt == 0)
					{
						sqlCommand = new SqlCommand(
							"SELECT * FROM PAYMENTSETRF " +
							"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
							"ORDER BY PAYSTMNGNORF",
							sqlConnection);
					}
					else
					{
						//一件目リードの場合
						if (paymentsetWork.PayStMngNo == 0)
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY PAYSTMNGNORF",
								sqlConnection);
						}
						else
						{
							sqlCommand = new SqlCommand(
								"SELECT TOP "+_readCnt.ToString()+" * FROM PAYMENTSETRF " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF>@FINDPAYSTMNGNO " +
								"ORDER BY PAYSTMNGNORF",
								sqlConnection);
							SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
							paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
						}
					}
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				int retCnt = 0;
				while(myReader.Read())
				{
					//戻り値カウンタカウント
					retCnt += 1;
					if (readCnt > 0)
					{
						//戻り値の件数が取得指示件数を超えた場合終了
						if (readCnt < retCnt) 
						{
							nextData = true;
							break;
						}
					}
					PaymentSetWork wkPaymentSetWork = new PaymentSetWork();

					wkPaymentSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkPaymentSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkPaymentSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkPaymentSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkPaymentSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkPaymentSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkPaymentSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkPaymentSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkPaymentSetWork.PayStMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMNGNORF"));
					wkPaymentSetWork.PayStMoneyKindCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD1RF"));
					wkPaymentSetWork.PayStMoneyKindCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD2RF"));
    				wkPaymentSetWork.PayStMoneyKindCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD3RF"));
					wkPaymentSetWork.PayStMoneyKindCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD4RF"));
					wkPaymentSetWork.PayStMoneyKindCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD5RF"));
					wkPaymentSetWork.PayStMoneyKindCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD6RF"));
					wkPaymentSetWork.PayStMoneyKindCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD7RF"));
					wkPaymentSetWork.PayStMoneyKindCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD8RF"));
					wkPaymentSetWork.PayStMoneyKindCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD9RF"));
                    wkPaymentSetWork.PayStMoneyKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD10RF"));

					al.Add(wkPaymentSetWork);

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
				base.WriteErrorLog(ex,"PaymentSetDB.SearchProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommandCount != null)
				{
					sqlCommandCount.Dispose();
				}
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			// XMLへ変換し、文字列のバイナリ化
			PaymentSetWork[] PaymentSetWorks = (PaymentSetWork[])al.ToArray(typeof(PaymentSetWork));
			retbyte = XmlByteSerializer.Serialize(PaymentSetWorks);

			return status;

		}
		
		/// <summary>
		/// 指定された企業コードの支払設定を戻します
		/// </summary>
		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの支払設定を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int Read(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			PaymentSetWork paymentsetWork = new PaymentSetWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				sqlCommand = new SqlCommand(
					"SELECT * FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO",
					sqlConnection);
				//Parameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					paymentsetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					paymentsetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					paymentsetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					paymentsetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					paymentsetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					paymentsetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					paymentsetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					paymentsetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					paymentsetWork.PayStMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMNGNORF"));
					paymentsetWork.PayStMoneyKindCd1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD1RF"));
					paymentsetWork.PayStMoneyKindCd2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD2RF"));
					paymentsetWork.PayStMoneyKindCd3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD3RF"));
					paymentsetWork.PayStMoneyKindCd4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD4RF"));
					paymentsetWork.PayStMoneyKindCd5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD5RF"));
					paymentsetWork.PayStMoneyKindCd6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD6RF"));
					paymentsetWork.PayStMoneyKindCd7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD7RF"));
					paymentsetWork.PayStMoneyKindCd8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD8RF"));
					paymentsetWork.PayStMoneyKindCd9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PAYSTMONEYKINDCD9RF"));
                    paymentsetWork.PayStMoneyKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYSTMONEYKINDCD10RF"));

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
				base.WriteErrorLog(ex,"PaymentSetDB.Read:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(paymentsetWork);

			return status;
		}

		/// <summary>
		/// 支払設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 支払設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				PaymentSetWork paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, PAYSTMNGNORF FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO", 
					sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);
				
				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
				
				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != paymentsetWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (paymentsetWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

					sqlCommand.CommandText = "UPDATE PAYMENTSETRF SET " +
                        "CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYSTMNGNORF=@PAYSTMNGNO , PAYSTMONEYKINDCD1RF=@PAYSTMONEYKINDCD1 , PAYSTMONEYKINDCD2RF=@PAYSTMONEYKINDCD2 , PAYSTMONEYKINDCD3RF=@PAYSTMONEYKINDCD3 , PAYSTMONEYKINDCD4RF=@PAYSTMONEYKINDCD4 , PAYSTMONEYKINDCD5RF=@PAYSTMONEYKINDCD5 , PAYSTMONEYKINDCD6RF=@PAYSTMONEYKINDCD6 , PAYSTMONEYKINDCD7RF=@PAYSTMONEYKINDCD7 , PAYSTMONEYKINDCD8RF=@PAYSTMONEYKINDCD8 , PAYSTMONEYKINDCD9RF=@PAYSTMONEYKINDCD9 , PAYSTMONEYKINDCD10RF=@PAYSTMONEYKINDCD10 " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
					findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
					
					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)paymentsetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (paymentsetWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}

					//新規作成時のSQL文を生成
					sqlCommand.CommandText = "INSERT INTO PAYMENTSETRF " +
                        "(CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYSTMNGNORF, PAYSTMONEYKINDCD1RF, PAYSTMONEYKINDCD2RF, PAYSTMONEYKINDCD3RF, PAYSTMONEYKINDCD4RF, PAYSTMONEYKINDCD5RF, PAYSTMONEYKINDCD6RF, PAYSTMONEYKINDCD7RF, PAYSTMONEYKINDCD8RF, PAYSTMONEYKINDCD9RF , PAYSTMONEYKINDCD10RF ) " +
                        "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYSTMNGNO, @PAYSTMONEYKINDCD1, @PAYSTMONEYKINDCD2, @PAYSTMONEYKINDCD3, @PAYSTMONEYKINDCD4, @PAYSTMONEYKINDCD5, @PAYSTMONEYKINDCD6, @PAYSTMONEYKINDCD7, @PAYSTMONEYKINDCD8, @PAYSTMONEYKINDCD9, @PAYSTMONEYKINDCD10)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)paymentsetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);
				}
				if(myReader.IsClosed == false)myReader.Close();

				//Prameterオブジェクトの作成
				SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraPayStMngNo = sqlCommand.Parameters.Add("@PAYSTMNGNO", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd1 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD1", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd2 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD2", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd3 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD3", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd4 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD4", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd5 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD5", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd6 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD6", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd7 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD7", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd8 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD8", SqlDbType.Int);
				SqlParameter paraPayStMoneyKindCd9 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD9", SqlDbType.Int);
                SqlParameter paraPayStMoneyKindCd10 = sqlCommand.Parameters.Add("@PAYSTMONEYKINDCD10", SqlDbType.Int);
				
				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentsetWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentsetWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentsetWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.LogicalDeleteCode);
				paraPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
				paraPayStMoneyKindCd1.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd1);
				paraPayStMoneyKindCd2.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd2);
				paraPayStMoneyKindCd3.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd3);
				paraPayStMoneyKindCd4.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd4);
				paraPayStMoneyKindCd5.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd5);
				paraPayStMoneyKindCd6.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd6);
				paraPayStMoneyKindCd7.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd7);
				paraPayStMoneyKindCd8.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd8);
				paraPayStMoneyKindCd9.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd9);
                paraPayStMoneyKindCd10.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMoneyKindCd10);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(paymentsetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"PaymentSetDB.Write:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;

		}

		/// <summary>
		/// 支払情報を論理削除します
		/// </summary>
		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 支払情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除支払情報を復活します
		/// </summary>
		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除支払情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			return LogicalDeleteProc(ref parabyte,1);
		}

		/// <summary>
		/// 支払情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">PaymentSetWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 支払情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				PaymentSetWork paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, PAYSTMNGNORF FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO",
					sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != paymentsetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

					sqlCommand.CommandText = "UPDATE PAYMENTSETRF SET " +
						"UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
					findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)paymentsetWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				//論理削除モードの場合
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						return status;
					}
					else if	(logicalDelCd == 0)	paymentsetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						paymentsetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	paymentsetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentsetWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentsetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(paymentsetWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"PaymentSetDB.LogicalDeleteProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;

		}

		/// <summary>
		/// 支払情報を物理削除します
		/// </summary>
		/// <param name="parabyte">支払オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 支払情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.04.13</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				PaymentSetWork paymentsetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(PaymentSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, PAYSTMNGNORF FROM PAYMENTSETRF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO", 
					sqlConnection);

				//Prameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPayStMngNo = sqlCommand.Parameters.Add("@FINDPAYSTMNGNO", SqlDbType.NChar);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
				findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != paymentsetWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM PAYMENTSETRF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYSTMNGNORF=@FINDPAYSTMNGNO";
					//KEYコマンドを再設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentsetWork.EnterpriseCode);
					findParaPayStMngNo.Value = SqlDataMediator.SqlSetInt32(paymentsetWork.PayStMngNo);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"PaymentSetDB.Delete:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				
				if(sqlCommand != null)
				{
					sqlCommand.Dispose();
				}
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();			
					sqlConnection.Close();			
				}
			}

			return status;
		}
	}
}
