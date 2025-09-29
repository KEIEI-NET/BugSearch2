using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using System.Diagnostics;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ユーザーガイドDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザーガイドの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
    /// <br>Update Note	: 2009.06.01 xueqi
    ///					: ユーザーガイド区分名称の登録方法を変更、ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)を追加。</br>
    /// <br></br>
    /// <br>UpdataNote : 2009.06.11 panh</br>
    /// <br>           : 1.PVCS#228対応。</br>
    /// <br>           : 2009.07.22 21015 金巻　芳則</br>
    /// <br>           : 障害対応　サービスジョブのＥＮＤが書き込まれていなかった部分を修正</br>
    /// </remarks>
	[Serializable]
	public class UserGdBdUDB : RemoteDB , IUserGdBdUDB
	{
		/// <summary>
		/// ユーザーガイドDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
        /// <br>Update Note: 2007.05.29 iwa コンストラクタ部不正デバック削除</br>
        /// </remarks>
		public UserGdBdUDB() :
            base("SFCMN09066D", "Broadleaf.Application.Remoting.ParamData.UserGdBdUWork", "USERGDBDURF")          //ADD 2009.06.11 panh FOR PVCS#228
		{
			//Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));//2007.05.29 iwa del
			//Debug.WriteLine(this.ToString() + " Constructer");//2007.05.29 iwa del
		}

		#region 共通化メソッド
		/// <summary>
		/// 指定された企業コードのユーザーガイド情報LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			Debug.WriteLine(this.ToString() + " SearchCnt");

			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retCnt = 0;
			status = SearchCntUserGdBdUProc(out retCnt, parabyte, readMode, logicalMode);
			return status;
		}
		
		/// <summary>
		/// ユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Search(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			Debug.WriteLine(this.ToString() + " Search");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retobj = null;
			status = SearchUserGdBdU(out retobj, paraobj, readMode, logicalMode);
			return status;	
		}

		/// <summary>
		/// 指定されたUserGuideDivCdのユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchGuideDivCode(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			Debug.WriteLine(this.ToString() + " Search");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retobj = null;
			status = SearchUserGdBdUGuideDivCode(out retobj, paraobj, readMode, logicalMode);
			return status;	
		}
		
		/// <summary>
		/// 指定されたユーザーガイドGuidのユーザーガイド情報を戻します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたユーザーガイドGuidのユーザーガイドを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			Debug.WriteLine(this.ToString() + " Read");
		
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = ReadUserGdBdU(ref parabyte, readMode);
			return status;	
		}

		/// <summary>
		/// ユーザーガイド情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Write(ref byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " Write");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = WriteUserGdBdU(ref parabyte);
			return status;	
		}

		/// <summary>
		/// ユーザーガイド情報を物理削除します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int Delete(byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " Delete");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = DeleteUserGdBdU(parabyte);
			return status;	
		}

		/// <summary>
		/// ユーザーガイド情報を論理削除します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " LogicalDelete");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = LogicalDeleteUserGdBdU(ref parabyte);
			return status;			}

		/// <summary>
		/// 論理削除ユーザーガイド情報を復活します
		/// </summary>
		/// <param name="parabyte">OcrDefSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除ユーザーガイド情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			Debug.WriteLine(this.ToString() + " RevivalLogicalDelete");
			
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			status = RevivalLogicalDeleteUserGdBdU(ref parabyte);
			return status;	
		}
		#endregion

  		#region ユーザーガイドマスタ(ユーザー提供分)
		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:UserGdBdUWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchCntUserGdBdU(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCntUserGdBdUProc(out retCnt, parabyte, readMode,logicalMode);
		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ(readMode=0:UserGdBdUWorkクラス：企業コード)</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTの件数を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchCntUserGdBdUProc(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			UserGdBdUWork usergdbduWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();
			try 
			{	
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection))
				{
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommand.CommandText = sqlCommand.CommandText + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommand.CommandText = sqlCommand.CommandText + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						//論理削除区分設定
						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

					//データリード
					retCnt = (int)sqlCommand.ExecuteScalar();
					if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchCntUserGdBdUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}
	
			return status;
		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchUserGdBdU(out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			retobj = null;
			return SearchUserGdBdUProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
		}

//		/// <summary>
//		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを指定件数分全て戻します（論理削除除く）
//		/// </summary>
//		/// <param name="retbyte">検索結果</param>
//		/// <param name="retTotalCnt">検索対象総件数</param>
//		/// <param name="nextData">次データ有無</param>
//		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
//		/// <param name="readMode">検索区分</param>
//		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
//		/// <param name="readCnt">検索件数</param>		
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを指定件数分全て戻します（論理削除除く）</br>
//		/// <br>Programmer : 21015　金巻　芳則</br>
//		/// <br>Date       : 2005.03.24</br>
//		public int SearchSpecificationUserGdBdU(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
//		{		
//			Debug.WriteLine("SearchSpecificationUserGdBdU");
//			return SearchUserGdBdUProc(out retbyte,out retTotalCnt,out nextData,parabyte, readMode,logicalMode,readCnt);
//		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchUserGdBdUGuideDivCode(out object retobj,  object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
			retobj = null;
			return SearchUserGdBdUGuideDivCodeProc(out retobj,out retTotalCnt,out nextData,paraobj ,readMode,logicalMode,0);
		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchUserGdBdUProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();
			usergdbduWork = null;

			retobj = null;

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
				usergdbduWork = paraobj as UserGdBdUWork;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				//件数指定リードで一件目リードの場合データ総件数を取得
				if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
				{
					using(SqlCommand sqlCommandCount = new SqlCommand("",sqlConnection))
					{
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							sqlCommandCount.CommandText = "SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
							//論理削除区分設定
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							sqlCommandCount.CommandText = "SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
							//論理削除区分設定
							SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else 
						{
							sqlCommandCount.CommandText = "SELECT COUNT (*) FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
						}
						//Prameterオブジェクトの作成
						SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						//Parameterオブジェクトへ値設定
						paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

						retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
					}
				}

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//データ読込
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						//件数指定無しの場合
						if (readCnt == 0)
						{	
							sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						else
						{
							//一件目リードの場合
							if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							}
								//Nextリードの場合
							else
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							
								SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
								SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
						
								paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
								paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
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
							sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						else
						{
							//一件目リードの場合
							if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							}
								//Nextリードの場合
							else
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

								SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
								SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
						
								paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
								paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
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
							sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						else
						{
							//一件目リードの場合
							if ((readCnt > 0)&&(usergdbduWork.UserGuideDivCd == 0)&&(usergdbduWork.GuideCode == 0))
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
							}
							else
							{
								sqlCommand.CommandText = "SELECT TOP "+_readCnt.ToString()+" * FROM USERGDBDURF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

								SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
								SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);
						
								paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
								paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
							}
						}
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
							 
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
						UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();

						wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
						wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
						wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
						wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

						al.Add(wkUserGdBdUWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchUserGdBdUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			retobj = al;

			return status;

		}
		
		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを全て戻します
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>		
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">READ件数（0の場合はALL）</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchUserGdBdUGuideDivCodeProc(out object retobj,out int retTotalCnt,out bool nextData,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();
			usergdbduWork = null;

			retobj = null;

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
				usergdbduWork = paraobj as UserGdBdUWork;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();				

				using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
				{
					//データ読込
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
						sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
						sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

						SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
						sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
					}
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

					SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);

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
						UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();

						wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
						wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
						wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
						wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

						al.Add(wkUserGdBdUWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchUserGdBdUGuideDivCodeProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			retobj = al;

			return status;
		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobject">検索結果</param>
		/// <param name="paraobject">検索パラメータ</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します（論理削除除く）</br>
		/// <br>Programmer : 21052 山田　圭</br>
		/// <br>Date       : 2005.03.24</br>
		public int SearchUserGdBdUGuideDivCode(out object retobject,object paraobject, ConstantManagement.LogicalMode logicalMode)
		{		
			ArrayList userGdBdUWorkList = paraobject as ArrayList;
			return SearchUserGdBdUGuideDivCodeProc(out retobject,userGdBdUWorkList ,logicalMode);
		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)LISTを全て戻します
		/// </summary>
		/// <param name="retobject">検索結果</param>
		/// <param name="userGdBdUWorkList">検索パラメータ</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します</br>
		/// <br>Programmer : 21052 山田　圭</br>
		/// <br>Date       : 2005.03.24</br>
		private int SearchUserGdBdUGuideDivCodeProc(out object retobject,ArrayList userGdBdUWorkList, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retobject = null;

			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();
			usergdbduWork = null;

			ArrayList al = new ArrayList();
			try 
			{	
				if((userGdBdUWorkList != null)&&(userGdBdUWorkList.Count > 0))
				{
					string strsql = "";
					for(int iCnt=0; iCnt < userGdBdUWorkList.Count; iCnt++)
					{
						if(iCnt == 0)
						{
							strsql = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}
						else
						{
							strsql = strsql + " UNION SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}

						//データ読込
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						}
					}
		    		SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
	    			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
    				if (connectionText == null || connectionText == "") return status;


					//SQL文生成
					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();				

					usergdbduWork = userGdBdUWorkList[0] as UserGdBdUWork;

					using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
					{
						//データ読込
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

						SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdUWorkList.Count];
						for(int iCnt=0; iCnt < userGdBdUWorkList.Count; iCnt++)
						{
							paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
							paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdUWork)userGdBdUWorkList[iCnt]).UserGuideDivCd);
						}

						myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
						while(myReader.Read())
						{
							UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();

							wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
							wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
							wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
							wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
							wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
							wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
							wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
							wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
							wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
							wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
							wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
							wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

							al.Add(wkUserGdBdUWork);

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.SearchUserGdBdUGuideDivCodeProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			retobject = al;

			return status;

		}

		/// <summary>
		/// 指定された企業コードのユーザーガイドボディ(ユーザー変更分)を戻します
		/// </summary>
		/// <param name="parabyte">UserGdBdUWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された企業コードのユーザーガイドを戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int ReadUserGdBdU(ref byte[] parabyte , int readMode)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			UserGdBdUWork usergdbduWork = new UserGdBdUWork();

			try 
			{			
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
						usergdbduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						usergdbduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						usergdbduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						usergdbduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						usergdbduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						usergdbduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						usergdbduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						usergdbduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						usergdbduWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
						usergdbduWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
						usergdbduWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
						usergdbduWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.ReadUserGdBdU:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			// XMLへ変換し、文字列のバイナリ化
			parabyte = XmlByteSerializer.Serialize(usergdbduWork);

			return status;
		}

		/// <summary>
		/// ユーザーガイドボディ(ユーザー変更分)情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">UserGdBdUWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int WriteUserGdBdU(ref byte[] parabyte)
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
				UserGdBdUWork usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, USERGUIDEDIVCDRF, GUIDECODERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
	
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != usergdbduWork.UpdateDateTime)
						{
							//新規登録で該当データ有りの場合には重複
							if (usergdbduWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								//既存データで更新日時違いの場合には排他
							else													status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}

						sqlCommand.CommandText = "UPDATE USERGDBDURF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , USERGUIDEDIVCDRF=@USERGUIDEDIVCD , GUIDECODERF=@GUIDECODE , GUIDENAMERF=@GUIDENAME , GUIDETYPERF=@GUIDETYPE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
						findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
						findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)usergdbduWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						if (usergdbduWork.UpdateDateTime > DateTime.MinValue)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							return status;
						}

						//新規作成時のSQL文を生成
						sqlCommand.CommandText = "INSERT INTO USERGDBDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, GUIDECODERF, GUIDENAMERF, GUIDETYPERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @USERGUIDEDIVCD, @GUIDECODE, @GUIDENAME, @GUIDETYPE)";
						//登録ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)usergdbduWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetInsertHeader(ref flhd,obj);
					}
					myReader.Close();

					//Prameterオブジェクトの作成
					SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
					SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
					SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@GUIDECODE", SqlDbType.Int);
					SqlParameter paraGuideName = sqlCommand.Parameters.Add("@GUIDENAME", SqlDbType.NVarChar);
					SqlParameter paraGuideType = sqlCommand.Parameters.Add("@GUIDETYPE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdbduWork.CreateDateTime);
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdbduWork.UpdateDateTime);
					paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(usergdbduWork.FileHeaderGuid);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.LogicalDeleteCode);
					paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
					paraGuideName.Value = SqlDataMediator.SqlSetString(usergdbduWork.GuideName);
					paraGuideType.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideType);

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(usergdbduWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.WriteUserGdBdU:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;

		}

		/// <summary>
		/// ユーザーガイドボディ(ユーザー変更分)情報を論理削除します
		/// </summary>
		/// <param name="parabyte">UserGdBdUWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int LogicalDeleteUserGdBdU(ref byte[] parabyte)
		{
			return LogicalDeleteUserGdBdUProc(ref parabyte,0);
		}

		/// <summary>
		/// 論理削除ユーザーガイドボディ(ユーザー変更分)情報を復活します
		/// </summary>
		/// <param name="parabyte">パラメーターWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除ユーザーガイド情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int RevivalLogicalDeleteUserGdBdU(ref byte[] parabyte)
		{
			return LogicalDeleteUserGdBdUProc(ref parabyte,1);
		}

		/// <summary>
		/// ユーザーガイドボディ(ユーザー変更分)情報の論理削除を操作します
		/// </summary>
		/// <param name="parabyte">UserGdBdUWorkオブジェクト</param>
		/// <param name="procMode">関数区分 0:論理削除 1:復活</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報の論理削除を操作します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		private int LogicalDeleteUserGdBdUProc(ref byte[] parabyte,int procMode)
		{
		//	Debug.WriteLine("LogicalDeleteUserGdBdU");

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try		
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XMLの読み込み
				UserGdBdUWork usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, USERGUIDEDIVCDRF, GUIDECODERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
						if (_updateDateTime != usergdbduWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}
						//現在の論理削除区分を取得
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

						sqlCommand.CommandText = "UPDATE USERGDBDURF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
						findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
						findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

						//更新ヘッダ情報を設定
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)usergdbduWork;
						FileHeader fileHeader = new FileHeader(obj);
						fileHeader.SetUpdateHeader(ref flhd,obj);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
					myReader.Close();

					//論理削除モードの場合
					if (procMode == 0)
					{
						if		(logicalDelCd == 3)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
							return status;
						}
						else if	(logicalDelCd == 0)	usergdbduWork.LogicalDeleteCode = 1;//論理削除フラグをセット
						else						usergdbduWork.LogicalDeleteCode = 3;//完全削除フラグをセット
					}
					else
					{
						if		(logicalDelCd == 1)	usergdbduWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdbduWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(usergdbduWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
					parabyte = XmlByteSerializer.Serialize(usergdbduWork);

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.LogicalDeleteUserGdBdUProc:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}
			return status;
		}

		/// <summary>
		/// ユーザーガイドボディ(ユーザー変更分)情報を物理削除します
		/// </summary>
		/// <param name="parabyte">ユーザーガイドオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ユーザーガイド情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		public int DeleteUserGdBdU(byte[] parabyte)
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
				UserGdBdUWork usergdbduWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, USERGUIDEDIVCDRF, GUIDECODERF FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
					SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
					findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
					findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
						if (_updateDateTime != usergdbduWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							return status;
						}

						sqlCommand.CommandText = "DELETE FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE";
						//KEYコマンドを再設定
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);
						findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.UserGuideDivCd);
						findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbduWork.GuideCode);
					}
					else
					{
						//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
					myReader.Close();

					sqlCommand.ExecuteNonQuery();

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog(ex,"UserGdBdUDB.DeleteUserGdBdU:"+ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
				if(sqlConnection != null)
				{
					sqlConnection.Dispose();
					sqlConnection.Close();
				}
			}

			return status;
		}
		#endregion

		#region インターフェースで公開しないメソッド
		/// <summary>
		/// ユーザーガイド情報LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="userGdBdUWorkList">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="sqlConnection">コネクション</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.12.28</br>
		public int Search(out ArrayList retList, UserGdBdUWork[] userGdBdUWorkList, int readMode,ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retList = null;

			SqlDataReader myReader = null;
			UserGdBdUWork usergdbduWork = null;

			ArrayList al = new ArrayList();
			try 
			{	
				if((userGdBdUWorkList != null)&&(userGdBdUWorkList.Length > 0))
				{
					string strsql = "";
					for(int iCnt=0; iCnt < userGdBdUWorkList.Length; iCnt++)
					{
						if(iCnt == 0)
						{
							strsql = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}
						else
						{
							strsql = strsql + " UNION SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
						}

						//データ読込
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
						}
					}
					usergdbduWork = userGdBdUWorkList[0] as UserGdBdUWork;

					using(SqlCommand sqlCommand = new SqlCommand("",sqlConnection))
					{
						//データ読込
						if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
							(logicalMode == ConstantManagement.LogicalMode.GetData1)||
							(logicalMode == ConstantManagement.LogicalMode.GetData2)||
							(logicalMode == ConstantManagement.LogicalMode.GetData3))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
						}
						else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

							SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
							if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
							else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
						}
						else
						{
							sqlCommand.CommandText = "SELECT * FROM (" + strsql + ") AS USERGDBDU ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
						}
						SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(usergdbduWork.EnterpriseCode);

						SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdUWorkList.Length];
						for(int iCnt=0; iCnt < userGdBdUWorkList.Length; iCnt++)
						{
							paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
							paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdUWork)userGdBdUWorkList[iCnt]).UserGuideDivCd);
						}

						UserGdBdUWork wkUserGdBdUWork = new UserGdBdUWork();
						myReader = sqlCommand.ExecuteReader();
						while(myReader.Read())
						{
							wkUserGdBdUWork = new UserGdBdUWork();
							wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
							wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
							wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
							wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
							wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
							wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
							wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
							wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
							wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("USERGUIDEDIVCDRF"));
							wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDECODERF"));
							wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GUIDENAMERF"));
							wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GUIDETYPERF"));

							al.Add(wkUserGdBdUWork);

							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
					}
				}
			}
			catch (SqlException ex) 
			{
				status = base.WriteSQLErrorLog(ex);
			}
			catch(Exception ex)
			{
                base.WriteErrorLog(ex, "UserGdBdUDB.Search:" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if(!myReader.IsClosed)myReader.Close();
			}

			retList = al;

			return status;
		}

        /// <summary>
        /// ユーザーガイド情報LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="userGdBdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.12.28</br>
        public int Search(out ArrayList retList, UserGdBdUWork userGdBdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;

            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand.CommandText = "SELECT * FROM USERGDBDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  ORDER BY USERGUIDEDIVCDRF, GUIDECODERF";
                    }
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(userGdBdUWork.EnterpriseCode);

                    UserGdBdUWork wkUserGdBdUWork = null;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkUserGdBdUWork = new UserGdBdUWork();
                        wkUserGdBdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUserGdBdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUserGdBdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkUserGdBdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkUserGdBdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkUserGdBdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkUserGdBdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkUserGdBdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUserGdBdUWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                        wkUserGdBdUWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                        wkUserGdBdUWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                        wkUserGdBdUWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                        al.Add(wkUserGdBdUWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdUDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
            }

            retList = al;

            return status;
        }
        #endregion


        /// <summary>
        /// ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の取得処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">モード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <br>Note       : ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の取得処理</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        public int SearchHeader(out object retObj, object paraObj, int readMode,
            ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msgDiv = false;
            errMsg = string.Empty;
            UserGdHdUWork userGdHdUWork = null;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //NSServiceJobAccess jobAcs = null;              //ADD 2009.06.11 panh FOR PVCS#228   //2009.07.22 kane DEL
            ArrayList al = new ArrayList();
            try
            {
                sqlConnection = CreateSqlConnection();

                sqlConnection.Open();
                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF, MASTEROFFERCDRF, DIVNAMECHNGDIVCDRF FROM USERGDHDURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF ", sqlConnection);                                       //DEL 2009.06.11 panh FOR PVCS#228
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF, MASTEROFFERCDRF, DIVNAMECHNGDIVCDRF FROM USERGDHDURF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF ", sqlConnection);                  //ADD 2009.06.11 panh FOR PVCS#228
                //Prameterオブジェクトの作成
                SqlParameter enterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter logicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                userGdHdUWork = (UserGdHdUWork)paraObj;
                enterpriseCode.Value = SqlDataMediator.SqlSetString(userGdHdUWork.EnterpriseCode);
                logicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                //2009.07.22 kane DEL START >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ////ADD START 2009.06.11 panh FOR PVCS#228
                //// 開始実行ログ書き込み
                //jobAcs = new NSServiceJobAccess("SFCMN09064R", "UserGdBdUDB.SearchHeader");
                //string paraStr = sqlCommand.CommandText.ToString();
                //jobAcs.StartWriteServiceJob(paraStr, sqlConnection);
                //2009.07.22 kane DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //参照系　初期処理抽出系（60sec）
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);
                //ADD END 2009.06.11 panh FOR PVCS#228

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (myReader.Read())
                {
                    UserGdHdUWork usergdhduWork = new UserGdHdUWork();
                    usergdhduWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    usergdhduWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    usergdhduWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    usergdhduWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    usergdhduWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    usergdhduWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    usergdhduWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    usergdhduWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    usergdhduWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    usergdhduWork.UserGuideDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USERGUIDEDIVNMRF"));
                    usergdhduWork.MasterOfferCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTEROFFERCDRF"));
                    usergdhduWork.DivNameChngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIVNAMECHNGDIVCDRF"));
                    al.Add(usergdhduWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
            //catch (Exception)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //    msgDiv = true;
            //    errMsg = "ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の読込に失敗しました。";
            //}
            ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/

            //ADD START 2009.06.11 panh FOR PVCS#228
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "UserGdHdUDA.SearchHeader:", status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "検索中にタイムアウトが発生しました。\r\n抽出条件を絞って再度検索を行って下さい。";
                }
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(e, "UserGdHdUDA.SearchHeader:", status);
            }
            //ADD END 2009.06.11 panh FOR PVCS#228
            finally
            {
                //if (!myReader.IsClosed) myReader.Close();    //DEL 2009.06.11 panh FOR PVCS#228
                if (myReader != null) myReader.Close();        //ADD 2009.06.11 panh FOR PVCS#228
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
                //2009.07.22 kane DEL START >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //ADD START 2009.06.11 panh FOR PVCS#228
                //if (jobAcs != null)
                //{
                //    jobAcs.EndWriteServiceJob(status, errMsg, "", sqlConnection);
                //}
                //ADD END 2009.06.11 panh FOR PVCS#228
                //2009.07.22 kane DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            retObj = al;
            return status;
        }

        /// <summary>
        /// ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の更新処理
        /// </summary>
        /// <param name="paraObj">更新対象</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の更新処理</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        public int WriteHeader(ref object paraObj, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            msgDiv = false;
            errMsg = string.Empty;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            //NSServiceJobAccess jobAcs = null;     //ADD 2009.06.11 panh FOR PVCS#228 // 2010/04/20 PM対応
            
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;     //DEL 2009.06.11 panh FOR PVCS#228
                if (connectionText == null || connectionText == "")                      //ADD 2009.06.11 panh FOR PVCS#228
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;                 //ADD 2009.06.11 panh FOR PVCS#228

                // XMLの読み込み
                UserGdHdUWork usergdhduWork = (UserGdHdUWork)XmlByteSerializer.Deserialize((byte[])paraObj, typeof(UserGdHdUWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF FROM USERGDHDURF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD", sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter enterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter logicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    enterpriseCode.Value = SqlDataMediator.SqlSetString(usergdhduWork.EnterpriseCode);
                    logicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.LogicalDeleteCode);
                    findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.UserGuideDivCd);

                    //>>>2010/04/20 PM対応
                    ////ADD START 2009.06.11 panh FOR PVCS#228
                    //// 開始実行ログ書き込み
                    //jobAcs = new NSServiceJobAccess("SFCMN09064R", "UserGdBdUDB.WriteHeader");
                    //string paraStr = sqlCommand.CommandText.ToString();
                    //jobAcs.StartWriteServiceJob(paraStr, sqlConnection);
                    ////参照系　初期処理抽出系（60sec）
                    //sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);
                    ////ADD END 2009.06.11 panh FOR PVCS#228
                    //<<<2010/04/20 PM対応

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != usergdhduWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (usergdhduWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        sqlCommand.CommandText = "UPDATE USERGDHDURF SET CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, ENTERPRISECODERF=@ENTERPRISECODE, FILEHEADERGUIDRF=@FILEHEADERGUID, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1, UPDASSEMBLYID2RF=@UPDASSEMBLYID2, LOGICALDELETECODERF=@LOGICALDELETECODE, USERGUIDEDIVCDRF=@USERGUIDEDIVCD, USERGUIDEDIVNMRF=@USERGUIDEDIVNM, MASTEROFFERCDRF=@MASTEROFFERCD, DIVNAMECHNGDIVCDRF=@DIVNAMECHNGDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF=@USERGUIDEDIVCD";
                        //KEYコマンドを再設定
                        findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.UserGuideDivCd);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)usergdhduWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //新規作成時のSQL文を生成
                        sqlCommand.CommandText = "INSERT INTO USERGDHDURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, USERGUIDEDIVCDRF, USERGUIDEDIVNMRF, MASTEROFFERCDRF, DIVNAMECHNGDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @USERGUIDEDIVCD, @USERGUIDEDIVNM, @MASTEROFFERCD, @DIVNAMECHNGDIVCD)";
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)usergdhduWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    myReader.Close();

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                    SqlParameter paraUserGuideDivNm = sqlCommand.Parameters.Add("@USERGUIDEDIVNM", SqlDbType.NVarChar);
                    SqlParameter paraMasterOfferCd = sqlCommand.Parameters.Add("@MASTEROFFERCD", SqlDbType.Int);
                    SqlParameter paraDivNameChngDivCd = sqlCommand.Parameters.Add("@DIVNAMECHNGDIVCD", SqlDbType.Int);

                     
                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdhduWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(usergdhduWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(usergdhduWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(usergdhduWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(usergdhduWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(usergdhduWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(usergdhduWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.LogicalDeleteCode);
                    paraUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.UserGuideDivCd);
                    paraUserGuideDivNm.Value = SqlDataMediator.SqlSetString(usergdhduWork.UserGuideDivNm);
                    paraMasterOfferCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.MasterOfferCd);
                    paraDivNameChngDivCd.Value = SqlDataMediator.SqlSetInt32(usergdhduWork.DivNameChngDivCd);

                    //>>>2010/04/20 PM対応
                    ////ADD START 2009.06.11 panh FOR PVCS#228
                    //// 開始実行ログ書き込み
                    //jobAcs = new NSServiceJobAccess("SFCMN09064R", "UserGdBdUDB.WriteHeader");
                    //paraStr = sqlCommand.CommandText.ToString();
                    //jobAcs.StartWriteServiceJob(paraStr, sqlConnection);
                    ////ADD END 2009.06.11 panh FOR PVCS#228
                    //<<<2010/04/20 PM対応

                    sqlCommand.ExecuteNonQuery();

                    // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                    paraObj = XmlByteSerializer.Serialize(usergdhduWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
                //status = base.WriteSQLErrorLog(ex);
                //msgDiv = true;
                //errMsg = "ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の更新に失敗しました。";
                ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/
                //ADD START 2009.06.11 panh FOR PVCS#228
                status = base.WriteSQLErrorLog(ex, "UserGdHdUDA.WriteHeader:", status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "検索中にタイムアウトが発生しました。\r\n抽出条件を絞って再度検索を行って下さい。";
                }
                //ADD END 2009.06.11 panh FOR PVCS#228
            }
            catch (Exception ex)
            {
               /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
               //base.WriteErrorLog(ex, "UserGdHdUDB.WriteHeader:" + ex.Message);
               //status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
               //msgDiv = true;
               //errMsg = "ユーザーガイドマスタ(ヘッダ)(ユーザ変更分)の更新に失敗しました。";
                ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/
                //ADD START 2009.06.11 panh FOR PVCS#228
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "UserGdHdUDA.WriteHeader:" + ex.Message);
                //ADD END 2009.06.11 panh FOR PVCS#228
            }
            finally
            {
                /* ---------------------- DEL START 2009.06.11 panh FOR PVCS#228----------------->>>>>
                //if (!myReader.IsClosed) myReader.Close();
                //if (sqlConnection != null)
                //{
                //    sqlConnection.Dispose();
                //    sqlConnection.Close();
                //}
                ---------------------- DEL END   2009.06.11 panh FOR PVCS#228-----------------<<<<<*/

                //>>>2010/04/20 PM対応
                ////ADD START 2009.06.11 panh FOR PVCS#228
                //if (myReader != null && !myReader.IsClosed)
                //{
                //    myReader.Close();
                //    myReader.Dispose();
                //}
                //if (sqlConnection != null)
                //{
                //    if (jobAcs != null)
                //    {
                //        jobAcs.EndWriteServiceJob(status, errMsg, "", sqlConnection);
                //    }
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //}
                ////ADD END 2009.06.11 panh FOR PVCS#228

                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                    myReader.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
                //<<<2010/04/20 PM対応
            }
            return status;
        }


        #region[CreateSqlConnection]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnectionを生成する</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // --- MODIFY START 2009.06.08 xueqi FOR PVCS-288 --->>>>
            //if (string.IsNullOrEmpty(connectionText)) return null;
            if (connectionText == null || connectionText == "")
                return null;
            // --- MODIFY END 2009.06.08 xueqi FOR PVCS-288 ---<<<<
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion
	}
}
