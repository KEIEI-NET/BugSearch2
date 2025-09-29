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
using System.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 金額種別設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 金額種別設定の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.05.09</br>
	/// <br></br>
	/// <br>Update Note: 2007.05.09　村瀬　シンク処理追加</br>
    /// <br>---------------------------------------------------------</br>
    /// <br>Update Note: ファイルレイアウト変更</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.17</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 PM.NS用に修正</br>
    /// </remarks>
	[Serializable]
	public class MoneyKindDB : RemoteDB, IRemoteDB, IMoneyKindDB, IGetSyncdataList
	{
		/// <summary>
		/// 金額種別設定DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		/// </remarks>
		public MoneyKindDB() :																		  
		base("SFUKK09046D", "Broadleaf.Application.Remoting.ParamData.MoneyKindWork", "MONEYKINDURF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));				 
			Debug.WriteLine("MoneyKindDBコンストラクタ");
		}
	
		#region 共通化メソッド
		/// <summary>
		/// 指定された企業コードの金額種別設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:MoneyKindWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別設定LISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " SearchCnt" + "(" + getdatatype.ToString() + ")");
			retCnt = 0;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retCnt = 0;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = SearchCntMoneyKindUProc(out retCnt, parabyte, readMode, logicalMode);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;
		}                           

		/// <summary>
		/// 指定された企業コードの金額種別LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別LISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype)
		{		
			Debug.WriteLine(this.ToString() + " Search" + "(" + getdatatype.ToString() + ")");
			retbyte = null;


            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
                case GetMoneyKindDataType.UserMoneyKindData:
                    {
                        // XMLの読み込み
                        MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
                        ArrayList retList = null;

                        status = SearchMoneyKindUProc(out retList, moneykinduWork, readMode, logicalMode, 0);

                        // XMLへ変換し、文字列のバイナリ化
                        MoneyKindWork[] MoneyKinduWorks = (MoneyKindWork[])retList.ToArray(typeof(MoneyKindWork));
                        retbyte = XmlByteSerializer.Serialize(MoneyKinduWorks);
                            
                        break;
                    }
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}


			return status;	
		}

        /// <summary>
        /// 指定された企業コードの金額種別LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="getdatatype">取得対象データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの金額種別LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.05.09</br>
        public int Search(out object retList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype)
        {
            Debug.WriteLine(this.ToString() + " Search" + "(" + getdatatype.ToString() + ")");

            ArrayList moneykinduList = new ArrayList();
            retList = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            switch (getdatatype)
            {
                case GetMoneyKindDataType.UserMoneyKindData:
                    {
                        // XMLの読み込み
                        MoneyKindWork moneykinduWork = paraWork as MoneyKindWork;

                        status = SearchMoneyKindUProc(out moneykinduList, moneykinduWork, readMode, logicalMode, 0);

                        retList = moneykinduList;

                        break;
                    }
                case GetMoneyKindDataType.OfferMoneyKindData:
                    break;
            }

            return status;
        }

		/// <summary>
		/// 指定された企業コードの金額種別LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別LISTを指定件数分全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, GetMoneyKindDataType getdatatype)
		{		
			retbyte = null;
			retTotalCnt = 0;
			nextData = false;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			return status;	
		}
		
		/// <summary>
		/// 指定された企業コードの金額種別を戻します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int Read(ref byte[] parabyte , int readMode, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Read" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = ReadMoneyKindUProc(ref parabyte, readMode);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// 金額種別設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int Write(ref byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Write" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = WriteMoneyKindUProc(ref parabyte);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// 金額種別設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public 	int Delete(byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Delete" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = DeleteMoneyKindUProc(parabyte);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// 金額種別設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を論理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public 	int LogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " LogicalDelete" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = LogicalDeleteMoneyKindUProc(ref parabyte, 0);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		/// <summary>
		/// 論理削除金額種別設定情報を復活します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="getdatatype">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除金額種別設定情報を復活します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public 	int RevivalLogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype)
		{
			Debug.WriteLine(this.ToString() + " Write" + "(" + getdatatype.ToString() + ")");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			switch(getdatatype)
			{
				case GetMoneyKindDataType.UserMoneyKindData :
					status = LogicalDeleteMoneyKindUProc(ref parabyte, 1);
					break;
				case GetMoneyKindDataType.OfferMoneyKindData :
					break;
			}
			return status;	
		}

		#endregion

		#region 金額種別(ユーザー登録)メソッド
		/// <summary>
		/// 指定された企業コードの金額種別(ユーザー登録)LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:MoneyKindWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別(ユーザー登録)LISTの件数を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		private int SearchCntMoneyKindUProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			MoneyKindWork moneykinduWork = null;

			retCnt = 0;														   

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT COUNT (*) FROM MONEYKINDURF " + 
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
						"SELECT COUNT (*) FROM MONEYKINDURF " + 
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
						"SELECT COUNT (*) FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);

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
				base.WriteErrorLog(ex,"MoneyKindDB.SearchCntMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			
			sqlConnection.Close();			

			return status;
		}

		/// <summary>
		/// 指定された企業コードの金額種別LISTを全て戻します
		/// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="moneykinduWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別LISTを全て戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
        private int SearchMoneyKindUProc(out ArrayList retList, MoneyKindWork moneykinduWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			//件数指定リードの場合には指定件数＋１件リードする
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;

			ArrayList al = new ArrayList();
            retList = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				SqlCommand sqlCommand;

				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);

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
							break;
						}
					}
					MoneyKindWork wkMoneyKinduWork = new MoneyKindWork();

					wkMoneyKinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkMoneyKinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkMoneyKinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkMoneyKinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkMoneyKinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkMoneyKinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkMoneyKinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkMoneyKinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkMoneyKinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PRICESTCODERF"));
					wkMoneyKinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDCODERF"));
					wkMoneyKinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MONEYKINDNAMERF"));
					wkMoneyKinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDDIVRF"));

					al.Add(wkMoneyKinduWork);

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
				base.WriteErrorLog(ex,"MoneyKindDB.SearchMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

            retList = al;

			return status;
		}

		/// <summary>
		/// 指定された企業コードの金額種別LISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="moneykinduWork">検索パラメータ</param>
		/// <param name="sqlConnection"></param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別LISTを全て戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int SearchMoneyKindUProc(out ArrayList retList, MoneyKindWork moneykinduWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			retList = null;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			ArrayList al = new ArrayList();
			try 
			{	
				//データ読込
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand(
						"SELECT * FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " +
						"ORDER BY PRICESTCODERF, MONEYKINDCODERF",
						sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader();
				while(myReader.Read())
				{
					MoneyKindWork wkMoneyKinduWork = new MoneyKindWork();

					wkMoneyKinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					wkMoneyKinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					wkMoneyKinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					wkMoneyKinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					wkMoneyKinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					wkMoneyKinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					wkMoneyKinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					wkMoneyKinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					wkMoneyKinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PRICESTCODERF"));
					wkMoneyKinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDCODERF"));
					wkMoneyKinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MONEYKINDNAMERF"));
					wkMoneyKinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDDIVRF"));

					al.Add(wkMoneyKinduWork);

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
				base.WriteErrorLog(ex,"MoneyKindDB.SearchMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(myReader.IsClosed == false)myReader.Close();
				if(sqlCommand != null)sqlCommand.Dispose();
			}
			retList = al;

			return status;
		}

		/// <summary>
		/// 指定された企業コードの金額種別(ユーザー登録)を戻します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードの金額種別(ユーザー登録)を戻します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		private int ReadMoneyKindUProc(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			MoneyKindWork moneykinduWork = new MoneyKindWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT * FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);
				//Parameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);
				
				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				if(myReader.Read())
				{
					moneykinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
					moneykinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
					moneykinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
					moneykinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
					moneykinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					moneykinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					moneykinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					moneykinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
					moneykinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PRICESTCODERF"));
					moneykinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDCODERF"));
					moneykinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MONEYKINDNAMERF"));
					moneykinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MONEYKINDDIVRF"));

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
				base.WriteErrorLog(ex,"MoneyKindDB.ReadMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(moneykinduWork);

			return status;
		}

		/// <summary>
		/// 金額種別設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別設定情報を登録、更新します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		public int WriteMoneyKindUProc(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);

				//Parameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != moneykinduWork.UpdateDateTime)
					{
						//新規登録で該当データ有りの場合には重複
						if (moneykinduWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						//既存データで更新日時違いの場合には排他
						else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "UPDATE MONEYKINDURF SET " +
						"CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , " +
						"PRICESTCODERF=@PRICESTCODE , MONEYKINDCODERF=@MONEYKINDCODE , MONEYKINDNAMERF=@MONEYKINDNAME , MONEYKINDDIVRF=@MONEYKINDDIV " +
                        "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE ";
					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
					findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
					findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)moneykinduWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (moneykinduWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					//新規作成時のSQL文を生成
					sqlCommand.CommandText = "INSERT INTO MONEYKINDURF " +
						"(CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, " +
                        "PRICESTCODERF, MONEYKINDCODERF, MONEYKINDNAMERF, MONEYKINDDIVRF) " +
						"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, " +
                        "@PRICESTCODE, @MONEYKINDCODE, @MONEYKINDNAME, @MONEYKINDDIV)";
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)moneykinduWork;
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
				SqlParameter paraPriceStCode = sqlCommand.Parameters.Add("@PRICESTCODE", SqlDbType.Int);
				SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
				SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
				SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
				
				//Parameterオブジェクトへ値設定
				paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(moneykinduWork.CreateDateTime);
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(moneykinduWork.UpdateDateTime);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(moneykinduWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.LogicalDeleteCode);
				paraPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);
				paraMoneyKindName.Value = SqlDataMediator.SqlSetString(moneykinduWork.MoneyKindName);
				paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindDiv);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(moneykinduWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"MoneyKindDB.WriteMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 金額種別情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">MoneyKindWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 金額種別情報の論理削除を操作します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		private int LogicalDeleteMoneyKindUProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);

				//Parameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
					if (_updateDateTime != moneykinduWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					//現在の論理削除区分を取得
					logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                    
					sqlCommand.CommandText = "UPDATE MONEYKINDURF SET " +
						"UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE ";

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
					findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
					findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

					//更新ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)moneykinduWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd,obj);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					sqlConnection.Close();
					return status;
				}
				if(myReader.IsClosed == false)myReader.Close();

				//論理削除モードの場合
				if (procMode == 0)
				{
					if		(logicalDelCd == 3)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}
					else if	(logicalDelCd == 0)	moneykinduWork.LogicalDeleteCode = 1;//論理削除フラグをセット
					else						moneykinduWork.LogicalDeleteCode = 3;//完全削除フラグをセット
				}
				else
				{
					if		(logicalDelCd == 1)	moneykinduWork.LogicalDeleteCode = 0;//論理削除フラグを解除
					else
					{
						if  (logicalDelCd == 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
						else					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
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
				paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(moneykinduWork.UpdateDateTime);
				paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(moneykinduWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.LogicalDeleteCode);

				sqlCommand.ExecuteNonQuery();

				// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
				parabyte = XmlByteSerializer.Serialize(moneykinduWork);

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"MoneyKindDB.LogicalDeleteMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}

		/// <summary>
		/// 金額種別情報を物理削除します
		/// </summary>
		/// <param name="parabyte">金額種別オブジェクト</param>
		/// <returns></returns>
		/// <br>Note       : 金額種別情報を物理削除します</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.05.09</br>
		///	<remark>インターフェイス側未実装の為、戻り値NORMALのみ</remark>
		public int DeleteMoneyKindUProc(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try 
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				MoneyKindWork moneykinduWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte,typeof(MoneyKindWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand(
					"SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MONEYKINDURF " +
					"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE",
					sqlConnection);

				//Parameterオブジェクトの作成
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaPriceStCode = sqlCommand.Parameters.Add("@FINDPRICESTCODE", SqlDbType.Int);
				SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
				findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
				findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);

				myReader = sqlCommand.ExecuteReader();
				if(myReader.Read())
				{
					//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
					DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
					if (_updateDateTime != moneykinduWork.UpdateDateTime)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						sqlCommand.Cancel();
						if(myReader.IsClosed == false)myReader.Close();
						sqlConnection.Close();
						return status;
					}

					sqlCommand.CommandText = "DELETE FROM MONEYKINDURF " +
						"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PRICESTCODERF=@FINDPRICESTCODE AND MONEYKINDCODERF=@FINDMONEYKINDCODE";

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(moneykinduWork.EnterpriseCode);
					findParaPriceStCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.PriceStCode);
					findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(moneykinduWork.MoneyKindCode);
				}
				else
				{
					//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					sqlCommand.Cancel();
					if(myReader.IsClosed == false)myReader.Close();
					sqlConnection.Close();
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
				base.WriteErrorLog(ex,"MoneyKindDB.DeleteMoneyKindUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;
		}
		#endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の金額種別マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        public int GetSyncdataList(out ArrayList arraylistdata,SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM MONEYKINDURF  ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMoneyKindWorkFromReader(ref myReader));

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
        /// クラス格納処理 Reader → MoneyKindWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MoneyKindWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.09</br>
        /// </remarks>
        private MoneyKindWork CopyToMoneyKindWorkFromReader(ref SqlDataReader myReader)
        {
            MoneyKindWork wkMoneykinduWork = new MoneyKindWork();

            #region クラスへ格納
            wkMoneykinduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMoneykinduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMoneykinduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMoneykinduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMoneykinduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMoneykinduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMoneykinduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMoneykinduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkMoneykinduWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTCODERF"));
            wkMoneykinduWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkMoneykinduWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkMoneykinduWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            #endregion

            return wkMoneykinduWork;
        }
        #endregion


    }
}
