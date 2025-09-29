using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;

using Broadleaf.Library.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

/// <summary>
/// SCM受発注 サービス
/// </summary>
/// <remarks>
/// <br>Note		: SCM受発注データのIOWriteを行うWebサービスです。</br>
/// <br>Programmer	: 22024 寺坂　誉志</br>
/// <br>Date		: 2009.04.28</br>
/// <br></br>
/// <br>Update Note	: 2010.02.26 22024 寺坂誉志</br>
/// <br>			: １．詳細な情報を返すポップアップ用メソッドを追加</br>
/// <br>			: 2010.05.31 22024 寺坂誉志</br>
/// <br>			: 【10601131-00 整備･鈑金SCM連携】</br>
/// <br>			: １．ファイルレイアウト変更に伴う修正</br>
/// <br>            : 2010.06.17 22011 柏原頼人</br>
/// <br>            : １．FTC対応 SCM[1.01]</br>
/// <br>			: 2011.02.01 22024 寺坂誉志</br>
/// <br>			: 【10700732-00 SCMの改良(2011年2月)】</br>
/// <br>			: １．ファイルレイアウト変更に伴う修正</br>
/// <br>			: ２．明細取込区分更新用メソッドの追加</br>
/// <br>			: ３．明細取込区分判定付き登録メソッドの追加</br>
/// <br>			: 2011.05.19 22024 寺坂誉志</br>
/// <br>			: 【10702938-00 SCMオプション(PM連携 3次改良)】</br>
/// <br>			: １．ファイルレイアウト変更に伴う修正</br>
/// <br>			: ２．リモートPG規約に準じた修正(今回修正メソッドに限る)</br>
/// <br>			: ３．確定日更新用メソッドの追加</br>
/// <br>			: ４．複数条件指定可能なReadメソッドを追加</br>
/// <br>			: ５．明細取込区分更新処理の複数件数指定版を追加</br>
/// <br>			: 2011.06.15 22024 寺坂誉志</br>
/// <br>			: 【10702938-00 SCMオプション(PM連携 3次改良)】</br>
/// <br>			: １．障害№103 ReadWithCar2内でST=4は無視するようにロジック修正</br>
/// <br>			: 2011.08.10 huangqb</br>
/// <br>			: １．ファイルレイアウト変更に伴う修正</br>
/// <br>			: 2011/08/10 劉立</br>
/// <br>			: PCCUOE自動回答対応</br>
/// <br>			: 2011.08.30 huangqb</br>
/// <br>			: １．番号管理に設定が無いの場合997が返されるように修正 RedMine#24142</br>
/// </remarks>
[WebService(Namespace = "http://www.blscm.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SFCMN02501A : System.Web.Services.WebService
{
	#region Const
	// 認証コード
	private const string ctAuthenticateCode = "00cd03ea-b30f-409e-a3df-0abd531648f3";
	#endregion

	#region Constructor
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public SFCMN02501A()
	{
        //デザインされたコンポーネントを使用する場合、次の行をコメントを解除してください 
        //InitializeComponent(); 
	}
	#endregion

	#region Public Method
	/// <summary>
	/// SCM受発注データ登録処理（問合せ・発注）
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWork">SCM受発注データ配列</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの登録処理を行います。</br>
	/// <br>			: SCM受発注データ[Insert]</br>
	/// <br>			: SCM受発注データ(車両情報)[Insert/Update]</br>
	/// <br>			: 受発注明細データ（問合せ・発注）[Insert]</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region WriteInqWithCar
	[WebMethod]
	public int WriteInqWithCar(string authenticateCode, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtCarWork scmOdDtCarWork, ref ScmOdDtInqWork[] scmOdDtInqWorkArray, out bool msgDiv, out string errMsg)
	{
		#region 2011.02.01 TERASAKA DEL STA
//		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
//		msgDiv = false;
//		errMsg = string.Empty;
//
//		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;
//
//		SqlConnection sqlConnection = null;
//		SqlTransaction sqlTransaction = null;
//		try
//		{
//			//コネクション生成
//			sqlConnection = GetSCMConnection();
//			if (sqlConnection == null) return status;
//			sqlConnection.Open();
//
//			// トランザクション開始
//			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
//
//			//番号採番
//			if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0 && scmOdrDataWorkArray[0].InquiryNumber == 0)
//			{
//				int scmNoCode = 1;
//				int newNo;
//				SCMNumberNumbering numberNumbering = new SCMNumberNumbering();
//				status = numberNumbering.Numbering(scmOdrDataWorkArray[0].InqOriginalEpCd
//					, scmOdrDataWorkArray[0].InqOriginalSecCd
//					, scmNoCode
//					, out newNo
//					, out msgDiv
//					, out errMsg
//					, ref sqlConnection
//					, ref sqlTransaction);
//
//				switch (status)
//				{
//					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
//							scmOdrDataWork.InquiryNumber = newNo;
//						scmOdDtCarWork.InquiryNumber = newNo;
//						foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkArray)
//							scmOdDtInqWork.InquiryNumber = newNo;
//						break;
//					}
//					default:
//					{
//						sqlTransaction.Rollback();
//						return status;
//					}
//				}
//			}
//
//			// 更新日付(キー情報にも使用)
//			DateTime updateDate = DateTime.Now;
//			int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;
//
//			// SCM受発注データの登録
//			status = WriteScmOdrDataProc(ref scmOdrDataWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);
//
//			// 受発注明細マスタ（問合せ・発注）の登録
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				List<ScmOdDtInqWork> scmOdDtInqWorkList = new List<ScmOdDtInqWork>(scmOdDtInqWorkArray);
//				status = WriteScmOdDtInqProc(ref scmOdDtInqWorkList, updateDate, updateTime, sqlConnection, sqlTransaction);
//			}
//
//			// SCM受発注データ（車両）の登録
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				status = WriteScmOdDtCarProc(ref scmOdDtCarWork, updateDate, sqlConnection, sqlTransaction);
//			}
//            // 2010.06.17 Kashihara Add ----------------------------------- Start
//            // 課金ログの登録
//            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//            {
//                status = ScmBilLogWrp.Write(scmOdrDataWorkArray, scmOdDtInqWorkArray, null, sqlConnection, sqlTransaction);
//            }
//            // 2010.06.17 Kashihara Add ----------------------------------- End
//
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				// コミット
//				sqlTransaction.Commit();
//			}
//			else
//			{
//				// ロールバック
//				sqlTransaction.Rollback();
//			}
//		}
//		catch (SqlException ex)
//		{
//			msgDiv = true;
//			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
//				errMsg = "受発注データ（問合せ・発注）の登録処理中にタイムアウトが発生しました。";
//			else
//				errMsg = "受発注データ（問合せ・発注）の登録処理に失敗しました。";
//			// ロールバック
//			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
//
//			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
//		}
//		catch (Exception ex)
//		{
//			msgDiv = true;
//			errMsg = "受発注データ（問合せ・発注）の登録処理に失敗しました。";
//			// ロールバック
//			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
//
//			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
//			LogOutPut.WriteErrorLog(ex, errMsg, status);
//		}
//		finally
//		{
//			if (sqlTransaction.Connection != null)
//				sqlTransaction.Dispose();
//
//			if (sqlConnection != null)
//			{
//				sqlConnection.Close();
//				sqlConnection.Dispose();
//			}
//		}
//		
//		return status;
		#endregion
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
		return WriteInqWithCar2(authenticateCode, ref scmOdrDataWorkArray, ref scmOdDtCarWork, ref scmOdDtInqWorkArray, false, out msgDiv, out errMsg);
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
	}
	#endregion

	/// <summary>
	/// 受信日時更新処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの受信日時及び回答区分を更新します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region UpdateRcvDateTime
	[WebMethod]
	public int UpdateRcvDateTime(string authenticateCode, ref ScmOdrDataWork[] scmOdrDataWorkArray, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		SqlTransaction sqlTransaction = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			// トランザクション開始
			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

			// 受信日時の更新
			status = UpdateRcvDateTimeProc(ref scmOdrDataWorkArray, sqlConnection, sqlTransaction);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// コミット
				sqlTransaction.Commit();
			}
			else
			{
				// ロールバック
				sqlTransaction.Rollback();
			}
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			#region 2011.02.01 TERASAKA DEL STA
//			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
//				errMsg = "明細取込区分（問合せ・発注）の更新処理中にタイムアウトが発生しました。";
//			else
//				errMsg = "明細取込区分（問合せ・発注）の更新処理に失敗しました。";
			#endregion
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受信日時の更新処理中にタイムアウトが発生しました。";
			else
				errMsg = "受信日時の更新処理に失敗しました。";
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			#region 2011.02.01 TERASAKA DEL STA
//			errMsg = "明細取込区分（問合せ・発注）の更新処理に失敗しました。";
			#endregion
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
			errMsg = "受信日時の更新処理に失敗しました。";
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
		}
		finally
		{
			if (sqlTransaction.Connection != null)
				sqlTransaction.Dispose();

			if (sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ登録処理（回答）
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWork">SCM受発注データ</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの登録処理を行います。</br>
	/// <br>			: SCM受発注データ[Insert]</br>
	/// <br>			: SCM受発注データ(車両情報)[Insert/Update]</br>
	/// <br>			: 受発注明細データ（回答）[Insert]</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region WriteAnsWithCar
	[WebMethod]
	public int WriteAnsWithCar(string authenticateCode, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtCarWork scmOdDtCarWork, ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, out bool msgDiv, out string errMsg)
	{
		#region 2011.02.01 TERASAKA DEL STA
//		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
//		msgDiv = false;
//		errMsg = string.Empty;
//
//		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;
//
//		SqlConnection sqlConnection = null;
//		SqlTransaction sqlTransaction = null;
//		try
//		{
//			//コネクション生成
//			sqlConnection = GetSCMConnection();
//			if (sqlConnection == null) return status;
//			sqlConnection.Open();
//
//			// トランザクション開始
//			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
//
//			//番号採番
//			if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0 && scmOdrDataWorkArray[0].InquiryNumber == 0)
//			{
//				int scmNoCode = 1;
//				int newNo;
//				SCMNumberNumbering numberNumbering = new SCMNumberNumbering();
//				status = numberNumbering.Numbering(scmOdrDataWorkArray[0].InqOriginalEpCd
//					, scmOdrDataWorkArray[0].InqOriginalSecCd
//					, scmNoCode
//					, out newNo
//					, out msgDiv
//					, out errMsg
//					, ref sqlConnection
//					, ref sqlTransaction);
//
//				switch (status)
//				{
//					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
//							scmOdrDataWork.InquiryNumber = newNo;
//						scmOdDtCarWork.InquiryNumber = newNo;
//						foreach (ScmOdDtAnsWork scmOdDtAnsWork in scmOdDtAnsWorkArray)
//							scmOdDtAnsWork.InquiryNumber = newNo;
//						break;
//					}
//					default:
//					{
//						sqlTransaction.Rollback();
//						return status;
//					}
//				}
//			}
//
//			// 更新日付(キー情報にも使用)
//			DateTime updateDate = DateTime.Now;
//			int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;
//
//			// SCM受発注データの登録
//			status = WriteScmOdrDataProc(ref scmOdrDataWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);
//
//			// 受発注明細マスタ（回答）の登録
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				status = WriteScmOdDtAnsProc(ref scmOdDtAnsWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);
//			}
//
//			// SCM受発注データ（車両）の登録
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				status = WriteScmOdDtCarProc(ref scmOdDtCarWork, updateDate, sqlConnection, sqlTransaction);
//			}
//            // 2010.06.17 Kashihara Add ----------------------------------- Start
//            // 課金ログの登録
//            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//            {
//                status = ScmBilLogWrp.Write(scmOdrDataWorkArray, null, scmOdDtAnsWorkArray, sqlConnection, sqlTransaction);
//            }
//            // 2010.06.17 Kashihara Add ----------------------------------- End
//
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				// コミット
//				sqlTransaction.Commit();
//			}
//			else
//			{
//				// ロールバック
//				sqlTransaction.Rollback();
//			}
//		}
//		catch (SqlException ex)
//		{
//			msgDiv = true;
//			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
//				errMsg = "受発注データ（回答）の登録処理中にタイムアウトが発生しました。";
//			else
//				errMsg = "受発注データ（回答）の登録処理に失敗しました。";
//			// ロールバック
//			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
//
//			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
//		}
//		catch (Exception ex)
//		{
//			msgDiv = true;
//			errMsg = "受発注データ（回答）の登録処理に失敗しました。";
//			// ロールバック
//			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
//
//			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
//			LogOutPut.WriteErrorLog(ex, errMsg, status);
//		}
//		finally
//		{
//			if (sqlTransaction.Connection != null)
//				sqlTransaction.Dispose();
//
//			if (sqlConnection != null)
//			{
//				sqlConnection.Close();
//				sqlConnection.Dispose();
//			}
//		}
//
//		return status;
		#endregion
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
		return WriteAnsWithCar2(authenticateCode, ref scmOdrDataWorkArray, ref scmOdDtCarWork, ref scmOdDtAnsWorkArray, false, out msgDiv, out errMsg);
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
	}
	#endregion

	/// <summary>
	/// SCM受発注データ読込処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="scmOdDtCarWorkArray">SCM受発注データ(車両情報)配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの読込処理を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region ReadWithCar
	[WebMethod]
	public int ReadWithCar(string authenticateCode, ScmOdReadParamWork scmOdReadParamWork, out ScmOdrDataWork[] scmOdrDataWorkArray, out ScmOdDtInqWork[] scmOdDtInqWorkArray, out ScmOdDtAnsWork[] scmOdDtAnsWorkArray, out ScmOdDtCarWork[] scmOdDtCarWorkArray, out bool msgDiv, out string errMsg)
	{
		#region 2011.05.19 TERASAKA DEL STA
//		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
//		msgDiv = false;
//		errMsg = string.Empty;
//
//		scmOdrDataWorkArray = null;
//		scmOdDtInqWorkArray = null;
//		scmOdDtAnsWorkArray = null;
//		scmOdDtCarWorkArray = null;
//
//		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;
//
//		SqlConnection sqlConnection = null;
//		try
//		{
//			//コネクション生成
//			sqlConnection = GetSCMConnection();
//			if (sqlConnection == null) return status;
//			sqlConnection.Open();
//
//			status = ReadScmOdrDataProc(scmOdReadParamWork, out scmOdrDataWorkArray, sqlConnection);
//			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
//
//			// 問発・回答種別(1:問合せ・発注 2:回答)
//			switch (scmOdReadParamWork.InqOrdAnsDivCd)
//			{
//				case 1:
//				{
//					scmOdDtAnsWorkArray = new ScmOdDtAnsWork[0];
//					status = ReadScmOdDtInqProc(scmOdReadParamWork, out scmOdDtInqWorkArray, sqlConnection);
//					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//						return status;
//					break;
//				}
//				case 2:
//				{
//					scmOdDtInqWorkArray = new ScmOdDtInqWork[0];
//					status = ReadScmOdDtAnsProc(scmOdReadParamWork, out scmOdDtAnsWorkArray, sqlConnection);
//					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//						return status;
//					break;
//				}
//				default:
//				{
//					status = ReadScmOdDtInqProc(scmOdReadParamWork, out scmOdDtInqWorkArray, sqlConnection);
//					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
//						status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
//						return status;
//
//					status = ReadScmOdDtAnsProc(scmOdReadParamWork, out scmOdDtAnsWorkArray, sqlConnection);
//					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
//						status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
//						return status;
//					break;
//				}
//			}
//
//			List<ScmOdDtCarWork> scmOdDtCarWorkList = new List<ScmOdDtCarWork>();
//			if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0)
//			{
//				List<ScmOdrDataWork> scmOdrDataWorkList = new List<ScmOdrDataWork>(scmOdrDataWorkArray);
//
//				List<string> inqOriginalEpSecList = new List<string>();
//				foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkList)
//				{
//					// 企業コード+拠点コードで既にSELECT済みかをチェックする
//					string key = string.Format("{0}_{1}", scmOdrDataWork.InqOriginalEpCd, scmOdrDataWork.InqOriginalSecCd);
//					if (!inqOriginalEpSecList.Contains(key))
//					{
//						inqOriginalEpSecList.Add(key);
//
//						// 企業コード+拠点コードでフィルタしたデータを取得
//						List<ScmOdrDataWork> wkList = scmOdrDataWorkList.FindAll(
//							delegate(ScmOdrDataWork wkScmOdrDataWork)
//							{
//								if (wkScmOdrDataWork.InqOriginalEpCd == scmOdrDataWork.InqOriginalEpCd &&
//									wkScmOdrDataWork.InqOriginalSecCd == scmOdrDataWork.InqOriginalSecCd)
//									return true;
//								else
//									return false;
//							}
//						);
//
//						// 取得対象となる問合せ番号を特定
//						List<long> inquiryNumberList = new List<long>();
//						foreach (ScmOdrDataWork wkScmOdrDataWork in wkList)
//						{
//							if (!inquiryNumberList.Contains(wkScmOdrDataWork.InquiryNumber))
//								inquiryNumberList.Add(wkScmOdrDataWork.InquiryNumber);
//						}
//
//						status = ReadScmOdDtCarProc(scmOdrDataWork.InqOriginalEpCd, scmOdrDataWork.InqOriginalSecCd, inquiryNumberList, out scmOdDtCarWorkArray, sqlConnection);
//						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//							scmOdDtCarWorkList.AddRange(scmOdDtCarWorkArray);
//						else
//							return status;
//					}
//				}
//			}
//			scmOdDtCarWorkArray = scmOdDtCarWorkList.ToArray();
//		}
//		catch (SqlException ex)
//		{
//			msgDiv = true;
//			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
//				errMsg = "受発注データの読込処理中にタイムアウトが発生しました。";
//			else
//				errMsg = "受発注データの読込処理に失敗しました。";
//
//			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
//		}
//		catch (Exception ex)
//		{
//			msgDiv = true;
//			errMsg = "受発注データの読込処理に失敗しました。";
//
//			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
//			LogOutPut.WriteErrorLog(ex, errMsg, status);
//		}
//		finally
//		{
//			if (sqlConnection != null)
//			{
//				sqlConnection.Close();
//				sqlConnection.Dispose();
//			}
//		}
//
//		return status;
		#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
		ScmOdReadParamWork[] scmOdReadParamArray = new ScmOdReadParamWork[] { scmOdReadParamWork };

		return ReadWithCar2(authenticateCode, scmOdReadParamArray, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
	}
	#endregion

	/// <summary>
	/// SCM受発注データ検索処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdSrchParam">SCM受発注検索条件クラス</param>
	/// <param name="sCMAnsListSrchRstWorkArray">SCM回答一覧検索結果クラス配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの検索処理を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region SearchWithCar
	[WebMethod]
	public int SearchWithCar(string authenticateCode, ScmOdSrchParamWork scmOdSrchParam, out SCMAnsListSrchRstWork[] sCMAnsListSrchRstWorkArray, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		msgDiv = false;
		errMsg = string.Empty;

		sCMAnsListSrchRstWorkArray = null;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			status = SearchScmOdrDataProc(scmOdSrchParam, out sCMAnsListSrchRstWorkArray, sqlConnection);
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データの検索処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データの検索処理に失敗しました。";

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データの検索処理に失敗しました。";

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
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
	#endregion

	/// <summary>
	/// SCM受発注データ件数取得処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmPopParamWork">SCMポップアップ条件クラス</param>
	/// <param name="scmPopParamDtlWorkArray">SCMポップアップ条件クラス(明細)配列</param>
	/// <param name="count">最新問合せ番号件数</param>
	/// <param name="rowCount">最新レコード件数</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 検索条件クラスの条件に合致する受発注データ件数を取得します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region SearchCntWithCar
	[WebMethod]
	public int SearchCntWithCar(string authenticateCode, ScmPopParamWork scmPopParamWork, ScmPopParamDtlWork[] scmPopParamDtlWorkArray, out int count, out int rowCount, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

		int lateUpdateTime;
		DateTime lateUpdateDate;
		status = SearchCntWithCar2(authenticateCode, scmPopParamWork, scmPopParamDtlWorkArray, out count, out rowCount, out lateUpdateDate, out lateUpdateTime, out msgDiv, out errMsg);

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ件数取得処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmPopParamWork">SCMポップアップ条件クラス</param>
	/// <param name="scmPopParamDtlWorkArray">SCMポップアップ条件クラス(明細)配列</param>
	/// <param name="count">最新問合せ番号件数</param>
	/// <param name="rowCount">最新レコード件数</param>
	/// <param name="lateUpdateDate">最新更新年月日</param>
	/// <param name="lateUpdateTime">最新更新時分秒ミリ秒</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 検索条件クラスの条件に合致する受発注データ件数を取得します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region SearchCntWithCar2
	[WebMethod]
	public int SearchCntWithCar2(string authenticateCode, ScmPopParamWork scmPopParamWork, ScmPopParamDtlWork[] scmPopParamDtlWorkArray, out int count, out int rowCount, out DateTime lateUpdateDate, out int lateUpdateTime, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		msgDiv = false;
		errMsg = string.Empty;

		count = 0;
		rowCount = 0;
		lateUpdateDate = DateTime.MinValue;
		lateUpdateTime = 0;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			status = SearchCntScmOdrDataProc(scmPopParamWork, scmPopParamDtlWorkArray, out count, out rowCount, out lateUpdateDate, out lateUpdateTime, sqlConnection);
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データの件数取得処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データの件数取得処理に失敗しました。";

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データの件数取得処理に失敗しました。";

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
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
	#endregion

////////////////////////////////////////////// 2010.02.26 TERASAKA ADD STA //
	/// <summary>
	/// 最新SCM受発注データ取得処理
	/// </summary>
	/// <param name="scmPopParamWork">SCMポップアップ条件クラス</param>
	/// <param name="scmPopParamDtlWorkArray">SCMポップアップ条件クラス(明細)配列</param>
	/// <param name="retDataList">最新レコード取得結果リスト</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 検索条件より新しいSCM受発注データの取得を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2010.02.26</br>
	/// </remarks>
	#region SearchScmOdrDataForPop
	[WebMethod]
	public int SearchScmOdrDataForPop(string authenticateCode, ScmPopParamWork scmPopParamWork, ScmPopParamDtlWork[] scmPopParamDtlWorkArray, out ScmOdrDataWork[] scmOdrDataWorkArray, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		msgDiv = false;
		errMsg = string.Empty;

		scmOdrDataWorkArray = null;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			status = SearchScmOdrDataForPopProc(scmPopParamWork, scmPopParamDtlWorkArray, out scmOdrDataWorkArray, sqlConnection);
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データの件数取得処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データの件数取得処理に失敗しました。";

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データの件数取得処理に失敗しました。";

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
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
	#endregion
// 2010.02.26 TERASAKA ADD END //////////////////////////////////////////////

////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
	/// <summary>
	/// SCM受発注データ登録処理（問合せ・発注）
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWork">SCM受発注データ配列</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="isCheckDtlTakeinDivCd">データ登録時に明細取込区分のチェック有無[true:チェックする,false:チェックしない]</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの登録処理を行います。</br>
	/// <br>			: SCM受発注データ[Insert]</br>
	/// <br>			: SCM受発注データ(車両情報)[Insert/Update]</br>
	/// <br>			: 受発注明細データ（問合せ・発注）[Insert]</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region WriteInqWithCar2
	[WebMethod]
	public int WriteInqWithCar2(string authenticateCode, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtCarWork scmOdDtCarWork, ref ScmOdDtInqWork[] scmOdDtInqWorkArray, bool isCheckDtlTakeinDivCd, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		SqlTransaction sqlTransaction = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			// トランザクション開始
			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

			//番号採番
			if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0 && scmOdrDataWorkArray[0].InquiryNumber == 0)
			{
				int scmNoCode = 1;
				int newNo;
				SCMNumberNumbering numberNumbering = new SCMNumberNumbering();
				status = numberNumbering.Numbering(scmOdrDataWorkArray[0].InqOriginalEpCd
					, scmOdrDataWorkArray[0].InqOriginalSecCd
					, scmNoCode
					, out newNo
					, out msgDiv
					, out errMsg
					, ref sqlConnection
					, ref sqlTransaction);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
							scmOdrDataWork.InquiryNumber = newNo;
						scmOdDtCarWork.InquiryNumber = newNo;
						foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkArray)
							scmOdDtInqWork.InquiryNumber = newNo;
						break;
					}
                    ////////////////////////////////////////////// 2011.08.30 huangqb ADD STA //
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        sqlTransaction.Rollback();
                        status = 997;
                        return status;
                    }
                    // 2011.08.30 huangqb ADD END //////////////////////////////////////////////
					default:
					{
						sqlTransaction.Rollback();
						return status;
					}
				}
			}

			// 更新日付(キー情報にも使用)
			DateTime updateDate = DateTime.Now;
			int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;

			// SCM受発注データの登録
			status = WriteScmOdrDataProc(ref scmOdrDataWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);

			// 受発注明細マスタ（問合せ・発注）の登録
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //status = WriteScmOdDtInqProc(ref scmOdDtInqWorkArray, updateDate, updateTime, isCheckDtlTakeinDivCd, sqlConnection, sqlTransaction); // Del by zhangw on 2011.08.03 For PCC_UOE
                status = WriteScmOdDtInqProc(ref scmOdDtInqWorkArray, updateDate, updateTime, isCheckDtlTakeinDivCd, scmOdrDataWorkArray[0].AcceptOrOrderKind, sqlConnection, sqlTransaction); // ADD by zhangw on 2011.08.03 For PCC_UOE
			}

			// SCM受発注データ（車両）の登録
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				status = WriteScmOdDtCarProc(ref scmOdDtCarWork, updateDate, sqlConnection, sqlTransaction);
			}
            // 課金ログの登録
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ScmBilLogWrp.Write(scmOdrDataWorkArray, scmOdDtInqWorkArray, null, sqlConnection, sqlTransaction);
            }

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// コミット
				sqlTransaction.Commit();
			}
			else
			{
				// ロールバック
				sqlTransaction.Rollback();
			}
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データ（問合せ・発注）の登録処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データ（問合せ・発注）の登録処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データ（問合せ・発注）の登録処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
		}
		finally
		{
			if (sqlTransaction.Connection != null)
				sqlTransaction.Dispose();

			if (sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}
		
		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ登録処理（回答）
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWork">SCM受発注データ</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="isCheckDtlTakeinDivCd">データ登録時に明細取込区分のチェック有無[true:チェックする,false:チェックしない]</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの登録処理を行います。</br>
	/// <br>			: SCM受発注データ[Insert]</br>
	/// <br>			: SCM受発注データ(車両情報)[Insert/Update]</br>
	/// <br>			: 受発注明細データ（回答）[Insert]</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region WriteAnsWithCar2
	[WebMethod]
	public int WriteAnsWithCar2(string authenticateCode, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtCarWork scmOdDtCarWork, ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, bool isCheckDtlTakeinDivCd, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		SqlTransaction sqlTransaction = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			// トランザクション開始
			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

			//番号採番
			if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0 && scmOdrDataWorkArray[0].InquiryNumber == 0)
			{
				int scmNoCode = 1;
				int newNo;
				SCMNumberNumbering numberNumbering = new SCMNumberNumbering();
				status = numberNumbering.Numbering(scmOdrDataWorkArray[0].InqOriginalEpCd
					, scmOdrDataWorkArray[0].InqOriginalSecCd
					, scmNoCode
					, out newNo
					, out msgDiv
					, out errMsg
					, ref sqlConnection
					, ref sqlTransaction);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
							scmOdrDataWork.InquiryNumber = newNo;
						scmOdDtCarWork.InquiryNumber = newNo;
						foreach (ScmOdDtAnsWork scmOdDtAnsWork in scmOdDtAnsWorkArray)
							scmOdDtAnsWork.InquiryNumber = newNo;
						break;
					}
					default:
					{
						sqlTransaction.Rollback();
						return status;
					}
				}
			}

			// 更新日付(キー情報にも使用)
			DateTime updateDate = DateTime.Now;
			int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;

			// SCM受発注データの登録
			status = WriteScmOdrDataProc(ref scmOdrDataWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);

			// 受発注明細マスタ（回答）の登録
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				status = WriteScmOdDtAnsProc(ref scmOdDtAnsWorkArray, updateDate, updateTime, isCheckDtlTakeinDivCd, sqlConnection, sqlTransaction);
			}

			// SCM受発注データ（車両）の登録
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				status = WriteScmOdDtCarProc(ref scmOdDtCarWork, updateDate, sqlConnection, sqlTransaction);
			}
            // 課金ログの登録
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                # if Release
                status = ScmBilLogWrp.Write(scmOdrDataWorkArray, null, scmOdDtAnsWorkArray, sqlConnection, sqlTransaction);
                # endif
            }

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// コミット
				sqlTransaction.Commit();
			}
			else
			{
				// ロールバック
				sqlTransaction.Rollback();
			}
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データ（回答）の登録処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データ（回答）の登録処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データ（回答）の登録処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
		}
		finally
		{
			if (sqlTransaction.Connection != null)
				sqlTransaction.Dispose();

			if (sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 明細取込区分更新処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 下記データを更新します。</br>
	/// <br>			:  ・SCM受発注データの受信日時及び回答区分</br>
	/// <br>			:  ・受発注明細データ（問合せ・発注）の明細取込区分</br>
	/// <br>			:  ・受発注明細データ（回答）の明細取込区分</br>
	/// <br>			: ※SCM受発注データ(車両情報)を利用した排他チェックが行われます。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region UpdateDtlTakeinDivCd
	[WebMethod]
	public int UpdateDtlTakeinDivCd(string authenticateCode, ScmOdDtCarWork scmOdDtCarWork, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtInqWork[] scmOdDtInqWorkArray, ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, out bool msgDiv, out string errMsg)
	{
		#region 2011.05.19 TERASAKA DEL STA
//		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
//		msgDiv = false;
//		errMsg = string.Empty;
//
//		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;
//
//		SqlConnection sqlConnection = null;
//		SqlTransaction sqlTransaction = null;
//		try
//		{
//			//コネクション生成
//			sqlConnection = GetSCMConnection();
//			if (sqlConnection == null) return status;
//			sqlConnection.Open();
//
//			// トランザクション開始
//			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
//
//			// 排他チェック
//			status = CheckExclusion(scmOdDtCarWork, sqlConnection, sqlTransaction);
//
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				// 受信日時の更新
//				if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0)
//				{
//					status = UpdateRcvDateTimeProc(ref scmOdrDataWorkArray, sqlConnection, sqlTransaction);
//				}
//			}
//
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				// 明細取込区分（問合せ・発注）の更新
//				if (scmOdDtInqWorkArray != null && scmOdDtInqWorkArray.Length > 0)
//				{
//					status = UpdateInqDtlTakeinDivCdProc(ref scmOdDtInqWorkArray, sqlConnection, sqlTransaction);
//				}
//			}
//
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				// 明細取込区分（回答）の更新
//				if (scmOdDtAnsWorkArray != null && scmOdDtAnsWorkArray.Length > 0)
//				{
//					status = UpdateAnsDtlTakeinDivCdProc(ref scmOdDtAnsWorkArray, sqlConnection, sqlTransaction);
//				}
//			}
//
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				// コミット
//				sqlTransaction.Commit();
//			}
//			else
//			{
//				// ロールバック
//				sqlTransaction.Rollback();
//			}
//		}
//		catch (SqlException ex)
//		{
//			msgDiv = true;
//			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
//				errMsg = "明細取込区分の更新処理中にタイムアウトが発生しました。";
//			else
//				errMsg = "明細取込区分の更新処理に失敗しました。";
//			// ロールバック
//			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
//
//			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
//		}
//		catch (Exception ex)
//		{
//			msgDiv = true;
//			errMsg = "明細取込区分の更新処理に失敗しました。";
//			// ロールバック
//			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
//
//			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
//			LogOutPut.WriteErrorLog(ex, errMsg, status);
//		}
//		finally
//		{
//			if (sqlTransaction.Connection != null)
//				sqlTransaction.Dispose();
//
//			if (sqlConnection != null)
//			{
//				sqlConnection.Close();
//				sqlConnection.Dispose();
//			}
//		}
//
//		return status;
		#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
		ScmOdDtCarWork[] scmOdDtCarWorkArray = new ScmOdDtCarWork[] { scmOdDtCarWork };
		return UpdateDtlTakeinDivCd2(authenticateCode, scmOdDtCarWorkArray, ref scmOdrDataWorkArray, ref scmOdDtInqWorkArray, ref scmOdDtAnsWorkArray, out msgDiv, out errMsg);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
	}
	#endregion
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////

////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
	/// <summary>
	/// 確定日更新処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="mode">モード[0:確定日セット,1:確定日削除]</param>
	/// <param name="scmJudgeDtUpdParamWorkArray">SCM確定日更新パラメータ</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 下記データを更新します。</br>
	/// <br>			:  ・SCM受発注データの確定日</br>
	/// <br>			: ※SCM受発注データ(車両情報)を利用した排他チェックが行われます。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region UpdateJudgementDate
	[WebMethod]
	public int UpdateJudgementDate(string authenticateCode, int mode, ref ScmJudgeDtUpdParamWork[] scmJudgeDtUpdParamWorkArray, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		SqlTransaction sqlTransaction = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			// トランザクション開始
			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

			// 確定日の更新
			if (scmJudgeDtUpdParamWorkArray != null && scmJudgeDtUpdParamWorkArray.Length > 0)
			{
				status = UpdateJudgementDateProc(mode, ref scmJudgeDtUpdParamWorkArray, sqlConnection, sqlTransaction);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// コミット
				sqlTransaction.Commit();
			}
			else
			{
				// ロールバック
				sqlTransaction.Rollback();
			}
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "確定日の更新処理中にタイムアウトが発生しました。";
			else
				errMsg = "確定日の更新処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "確定日の更新処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
		}
		finally
		{
			if (sqlTransaction.Connection != null)
				sqlTransaction.Dispose();

			if (sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ読込処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdReadParamWorkArray">SCM受発注読込条件クラス配列</param>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="scmOdDtCarWorkArray">SCM受発注データ(車両情報)配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの読込処理を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region ReadWithCar2
	[WebMethod]
	public int ReadWithCar2(string authenticateCode, ScmOdReadParamWork[] scmOdReadParamWorkArray, out ScmOdrDataWork[] scmOdrDataWorkArray, out ScmOdDtInqWork[] scmOdDtInqWorkArray, out ScmOdDtAnsWork[] scmOdDtAnsWorkArray, out ScmOdDtCarWork[] scmOdDtCarWorkArray, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		scmOdrDataWorkArray = null;
		scmOdDtInqWorkArray = null;
		scmOdDtAnsWorkArray = null;
		scmOdDtCarWorkArray = null;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			if (scmOdReadParamWorkArray == null || scmOdReadParamWorkArray.Length == 0) return status;

			List<ScmOdReadParamWork> scmOdReadParamWorkList = new List<ScmOdReadParamWork>(scmOdReadParamWorkArray);

			// 問合せ番号未指定 且つ 指示書番号指定の検索条件を取得
			List<ScmOdReadParamWork> targetList = scmOdReadParamWorkList.FindAll(
				delegate(ScmOdReadParamWork wkObj)
				{
					if (wkObj.InquiryNumber == 0 && !string.IsNullOrEmpty(wkObj.SfPmCprtInstSlipNo))
						return true;
					else
						return false;
				}
			);

			// 指示書番号より問合せ番号を取得する
			foreach (ScmOdReadParamWork scmOdReadParamWork in targetList)
			{
				List<long> inqNoList;
				int st = SearchInquiryNumberFromInstSlipNo(scmOdReadParamWork, out inqNoList, sqlConnection);
				if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					foreach (long inqNo in inqNoList)
					{
						if (!scmOdReadParamWorkList.Exists(
							delegate(ScmOdReadParamWork wkObj)
							{
								if (wkObj.InquiryNumber == inqNo)
									return true;
								else
									return false;
							}
							))
						{
							ScmOdReadParamWork addObj = new ScmOdReadParamWork();

							addObj.InqOriginalEpCd		= scmOdReadParamWork.InqOriginalEpCd;
							addObj.InqOriginalSecCd		= scmOdReadParamWork.InqOriginalSecCd;
							addObj.InqOtherEpCd			= scmOdReadParamWork.InqOtherEpCd;
							addObj.InqOtherSecCd		= scmOdReadParamWork.InqOtherSecCd;
							addObj.InquiryNumber		= inqNo;
							addObj.LatestDiscCode		= scmOdReadParamWork.LatestDiscCode;
							addObj.UpdateDate			= scmOdReadParamWork.UpdateDate;
							addObj.UpdateTime			= scmOdReadParamWork.UpdateTime;
							addObj.InqOrdAnsDivCd		= scmOdReadParamWork.InqOrdAnsDivCd;
							addObj.SfPmCprtInstSlipNo	= scmOdReadParamWork.SfPmCprtInstSlipNo;

							scmOdReadParamWorkList.Add(addObj);
						}
					}
				}

				scmOdReadParamWorkList.Remove(scmOdReadParamWork);
			}

			List<ScmOdrDataWork> scmOdrDataWorkList = new List<ScmOdrDataWork>();
			List<ScmOdDtInqWork> scmOdDtInqWorkList = new List<ScmOdDtInqWork>();
			List<ScmOdDtAnsWork> scmOdDtAnsWorkList = new List<ScmOdDtAnsWork>();
			List<ScmOdDtCarWork> scmOdDtCarWorkList = new List<ScmOdDtCarWork>();
			foreach (ScmOdReadParamWork scmOdReadParamWork in scmOdReadParamWorkList)
			{
				ScmOdrDataWork[] wkScmOdrDataWorkArray;
				status = ReadScmOdrDataProc(scmOdReadParamWork, out wkScmOdrDataWorkArray, sqlConnection);
				#region 2011.06.15 TERASAKA DEL STA
//				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//					scmOdrDataWorkList.AddRange(wkScmOdrDataWorkArray);
//				else
//					return status;
				#endregion
////////////////////////////////////////////// 2011.06.15 TERASAKA ADD STA //
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						scmOdrDataWorkList.AddRange(wkScmOdrDataWorkArray);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						continue;
					}
					default:
					{
						return status;
					}
				}
// 2011.06.15 TERASAKA ADD END //////////////////////////////////////////////

				// 問発・回答種別(1:問合せ・発注 2:回答)
				switch (scmOdReadParamWork.InqOrdAnsDivCd)
				{
					case 1:
					{
						ScmOdDtInqWork[] wkScmOdDtInqWorkArray;
						status = ReadScmOdDtInqProc(scmOdReadParamWork, out wkScmOdDtInqWorkArray, sqlConnection);
						#region 2011.06.15 TERASAKA DEL STA
//						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//							scmOdDtInqWorkList.AddRange(wkScmOdDtInqWorkArray);
//						else
//							return status;
						#endregion
////////////////////////////////////////////// 2011.06.15 TERASAKA ADD STA //
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								scmOdDtInqWorkList.AddRange(wkScmOdDtInqWorkArray);
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								break;
							}
							default:
							{
								return status;
							}
						}
// 2011.06.15 TERASAKA ADD END //////////////////////////////////////////////
						break;
					}
					case 2:
					{
						ScmOdDtAnsWork[] wkScmOdDtAnsWorkArray;
						status = ReadScmOdDtAnsProc(scmOdReadParamWork, out wkScmOdDtAnsWorkArray, sqlConnection);
						#region 2011.06.15 TERASAKA DEL STA
//						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//							scmOdDtAnsWorkList.AddRange(wkScmOdDtAnsWorkArray);
//						else
//							return status;
						#endregion
////////////////////////////////////////////// 2011.06.15 TERASAKA ADD STA //
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								scmOdDtAnsWorkList.AddRange(wkScmOdDtAnsWorkArray);
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								break;
							}
							default:
							{
								return status;
							}
						}
// 2011.06.15 TERASAKA ADD END //////////////////////////////////////////////
						break;
					}
					default:
					{
						ScmOdDtInqWork[] wkScmOdDtInqWorkArray;
						status = ReadScmOdDtInqProc(scmOdReadParamWork, out wkScmOdDtInqWorkArray, sqlConnection);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								scmOdDtInqWorkList.AddRange(wkScmOdDtInqWorkArray);
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								break;
							}
							default:
							{
								return status;
							}
						}

						ScmOdDtAnsWork[] wkScmOdDtAnsWorkArray;
						status = ReadScmOdDtAnsProc(scmOdReadParamWork, out wkScmOdDtAnsWorkArray, sqlConnection);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								scmOdDtAnsWorkList.AddRange(wkScmOdDtAnsWorkArray);
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
							{
								break;
							}
							default:
							{
								return status;
							}
						}
						break;
					}
				}
			}

			if (scmOdrDataWorkList != null && scmOdrDataWorkList.Count > 0)
			{
				List<string> inqOriginalEpSecList = new List<string>();
				foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkList)
				{
					// 企業コード+拠点コードで既にSELECT済みかをチェックする
					string key = string.Format("{0}_{1}", scmOdrDataWork.InqOriginalEpCd, scmOdrDataWork.InqOriginalSecCd);
					if (!inqOriginalEpSecList.Contains(key))
					{
						inqOriginalEpSecList.Add(key);

						// 企業コード+拠点コードでフィルタしたデータを取得
						List<ScmOdrDataWork> wkList = scmOdrDataWorkList.FindAll(
							delegate(ScmOdrDataWork wkScmOdrDataWork)
							{
								if (wkScmOdrDataWork.InqOriginalEpCd == scmOdrDataWork.InqOriginalEpCd &&
									wkScmOdrDataWork.InqOriginalSecCd == scmOdrDataWork.InqOriginalSecCd)
									return true;
								else
									return false;
							}
						);

						// 取得対象となる問合せ番号を特定
						List<long> inquiryNumberList = new List<long>();
						foreach (ScmOdrDataWork wkScmOdrDataWork in wkList)
						{
							if (!inquiryNumberList.Contains(wkScmOdrDataWork.InquiryNumber))
								inquiryNumberList.Add(wkScmOdrDataWork.InquiryNumber);
						}

						status = ReadScmOdDtCarProc(scmOdrDataWork.InqOriginalEpCd, scmOdrDataWork.InqOriginalSecCd, inquiryNumberList, out scmOdDtCarWorkArray, sqlConnection);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							scmOdDtCarWorkList.AddRange(scmOdDtCarWorkArray);
						else
							return status;
					}
				}
////////////////////////////////////////////// 2011.06.15 TERASAKA ADD STA //
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					scmOdrDataWorkArray	= scmOdrDataWorkList.ToArray();
					scmOdDtInqWorkArray	= scmOdDtInqWorkList.ToArray();
					scmOdDtAnsWorkArray	= scmOdDtAnsWorkList.ToArray();
					scmOdDtCarWorkArray	= scmOdDtCarWorkList.ToArray();
				}
// 2011.06.15 TERASAKA ADD END //////////////////////////////////////////////
			}
////////////////////////////////////////////// 2011.06.15 TERASAKA ADD STA //
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
// 2011.06.15 TERASAKA ADD END //////////////////////////////////////////////

			#region 2011.06.15 TERASAKA DEL STA
//			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				scmOdrDataWorkArray = scmOdrDataWorkList.ToArray();
//				scmOdDtInqWorkArray = scmOdDtInqWorkList.ToArray();
//				scmOdDtAnsWorkArray = scmOdDtAnsWorkList.ToArray();
//				scmOdDtCarWorkArray = scmOdDtCarWorkList.ToArray();
//			}
			#endregion
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データの読込処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データの読込処理に失敗しました。";

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データの読込処理に失敗しました。";

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
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
	#endregion

   // Add zhangw on 2011.08.03 For PCC_UOE STA
    /// <summary>
    /// SCM受発注セット部品データ読込処理
	/// </summary>
    /// <param name="paraScmAcOdSetDtWork">SCM受発注セット部品データ読込条件クラス配列</param>
    /// <param name="scmAcOdSetDtWorkArray">SCM受発注セット部品データ配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
    /// <br>Note		: SCM受注セット部品データの読込処理を行います。</br>
	/// <br>Programmer	: zhangw</br>
	/// <br>Date		: 2011.08.03</br>
    /// </remarks>
    #region ReadScmOdSetDt
    [WebMethod]
    public int ReadScmOdSetDt(ScmOdSetDtWork paraScmOdSetDtWork, out ScmOdSetDtWork[] scmOdSetDtWorkArray, out bool msgDiv, out string errMsg)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        msgDiv = false;
        errMsg = string.Empty;

        scmOdSetDtWorkArray = null;
        SqlConnection sqlConnection = null;

        try
        {
            //コネクション生成
            sqlConnection = GetSCMConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            if (paraScmOdSetDtWork == null) return status;

            // パラメータがある場合
            if (paraScmOdSetDtWork != null)
            {
                status = ReadScmOdSetDtProc(paraScmOdSetDtWork, out scmOdSetDtWorkArray, sqlConnection);
            }
            else
            {
                // 何もしない
            }

        }
        catch (SqlException ex)
        {
            msgDiv = true;
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                errMsg = "SCM受注セット部品データの読込処理中にタイムアウトが発生しました。";
            else
                errMsg = "SCM受注セット部品データの読込処理に失敗しました。";

            status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
        }
        catch (Exception ex)
        {
            msgDiv = true;
            errMsg = "SCM受注セット部品データの読込処理に失敗しました。";

            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            LogOutPut.WriteErrorLog(ex, errMsg, status);
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
    #endregion

    /// <summary>
    /// SCM受発注セット部品データ読込処理
	/// </summary>
    /// <param name="paraScmAcOdSetDtWork">SCM受発注セット部品データ読込条件クラス</param>
    /// <param name="scmAcOdSetDtWorkArray">SCM受発注セット部品データ配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
    /// <br>Note		: SCM受注セット部品データのSelectを行います。</br>
	/// <br>Programmer	: zhangw</br>
	/// <br>Date		: 2011.08.03</br>
    /// </remarks>
    #region ReadScmOdSetDtProc
    private int ReadScmOdSetDtProc(ScmOdSetDtWork paraScmOdSetDtWork, out ScmOdSetDtWork[] scmOdSetDtWorkArray, SqlConnection sqlConnection)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        scmOdSetDtWorkArray = null;

        SqlDataReader myReader = null;
        SqlCommand sqlCommand = null;

        try
        {
            List<ScmOdSetDtWork> scmOdSetDtWorkList = new List<ScmOdSetDtWork>();

            //Selectコマンドの生成
            sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, SETPARTSMKRCDRF, SETPARTSNUMBERRF, SETPARTSMAINSUBNORF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, PMWAREHOUSECDRF, PMWAREHOUSENAMERF, PMSHELFNORF, PMPRSNTCOUNTRF FROM SCMODSETDTRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND SETPARTSMKRCDRF=@FINDSETPARTSMKRCD AND SETPARTSNUMBERRF=@FINDSETPARTSNUMBER", sqlConnection);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaInquiryNumber = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
            SqlParameter findParaSetPartsMkrCd = sqlCommand.Parameters.Add("@FINDSETPARTSMKRCD", SqlDbType.Int);
            SqlParameter findParaSetPartsNumber = sqlCommand.Parameters.Add("@FINDSETPARTSNUMBER", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = paraScmOdSetDtWork.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = paraScmOdSetDtWork.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = paraScmOdSetDtWork.InqOtherEpCd;
            findParaInqOtherSecCd.Value = paraScmOdSetDtWork.InqOtherSecCd;
            findParaInquiryNumber.Value = paraScmOdSetDtWork.InquiryNumber;
            findParaSetPartsMkrCd.Value = paraScmOdSetDtWork.SetPartsMkrCd;
            findParaSetPartsNumber.Value = paraScmOdSetDtWork.SetPartsNumber;

            // タイムアウト時間設定
            sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                ScmOdSetDtWork scmOdSetDtWork = new ScmOdSetDtWork();

                # region データの設定
                scmOdSetDtWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                scmOdSetDtWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                scmOdSetDtWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                scmOdSetDtWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
                scmOdSetDtWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
                scmOdSetDtWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
                scmOdSetDtWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
                scmOdSetDtWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
                scmOdSetDtWork.SetPartsMkrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSMKRCDRF"));
                scmOdSetDtWork.SetPartsNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETPARTSNUMBERRF"));
                scmOdSetDtWork.SetPartsMainSubNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPARTSMAINSUBNORF"));
                scmOdSetDtWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));
                scmOdSetDtWork.RecyclePrtKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));
                scmOdSetDtWork.RecyclePrtKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));
                scmOdSetDtWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                scmOdSetDtWork.HandleDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));
                scmOdSetDtWork.GoodsShape = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));
                scmOdSetDtWork.DelivrdGdsConfCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));
                scmOdSetDtWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
                scmOdSetDtWork.AnswerDeliveryDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));
                scmOdSetDtWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                scmOdSetDtWork.BLGoodsDrCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));
                scmOdSetDtWork.InqGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF"));
                scmOdSetDtWork.AnsGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF"));
                scmOdSetDtWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                scmOdSetDtWork.DeliveredGoodsCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));
                scmOdSetDtWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                scmOdSetDtWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                scmOdSetDtWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
                scmOdSetDtWork.PureGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));
                scmOdSetDtWork.InqPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));
                scmOdSetDtWork.AnsPureGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));
                scmOdSetDtWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
                scmOdSetDtWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
                scmOdSetDtWork.GoodsAddInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));
                scmOdSetDtWork.RoughRrofit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));
                scmOdSetDtWork.RoughRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));
                scmOdSetDtWork.AnswerLimitDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));
                scmOdSetDtWork.CommentDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));
                scmOdSetDtWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
                scmOdSetDtWork.PMAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMACPTANODRSTATUSRF"));
                scmOdSetDtWork.PMSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMSALESSLIPNUMRF"));
                scmOdSetDtWork.PMSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMSALESROWNORF"));
                scmOdSetDtWork.PmWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMWAREHOUSECDRF"));
                scmOdSetDtWork.PmWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMWAREHOUSENAMERF"));
                scmOdSetDtWork.PmShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMSHELFNORF"));
                scmOdSetDtWork.PmPrsntCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMPRSNTCOUNTRF"));

                # endregion

                scmOdSetDtWorkList.Add(scmOdSetDtWork);
            }

            if (!myReader.IsClosed) myReader.Close();

            if (scmOdSetDtWorkList.Count > 0)
            {
                scmOdSetDtWorkArray = scmOdSetDtWorkList.ToArray();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

        }
        finally
        {
            if (myReader != null && !myReader.IsClosed)
                myReader.Close();

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }

        return status;
    }
    #endregion
    // Add zhangw on 2011.08.03 For PCC_UOE END

	/// <summary>
	/// 受発注データ確定済チェック処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWork">受発注データ</param>
	/// <param name="isFixed">チェック結果[true:確定済,false:未確定]</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 受発注データが確定済となっていないかのチェックを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region CheckScmOdrDataFixed
	[WebMethod]
	public int CheckScmOdrDataFixed(string authenticateCode, ScmOdrDataWork scmOdrDataWork, out bool isFixed, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		isFixed = false;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			isFixed = IsScmOdrDataFixed(scmOdrDataWork, true, sqlConnection, null);

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "受発注データ確定済チェック処理中にタイムアウトが発生しました。";
			else
				errMsg = "受発注データ確定済チェック処理に失敗しました。";

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "受発注データ確定済チェック処理に失敗しました。";

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
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
	#endregion

	/// <summary>
	/// 明細取込区分更新処理
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 下記データを更新します。</br>
	/// <br>			:  ・SCM受発注データの受信日時及び回答区分</br>
	/// <br>			:  ・受発注明細データ（問合せ・発注）の明細取込区分</br>
	/// <br>			:  ・受発注明細データ（回答）の明細取込区分</br>
	/// <br>			: ※SCM受発注データ(車両情報)を利用した排他チェックが行われます。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region UpdateDtlTakeinDivCd2
	[WebMethod]
	public int UpdateDtlTakeinDivCd2(string authenticateCode, ScmOdDtCarWork[] scmOdDtCarWorkArray, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtInqWork[] scmOdDtInqWorkArray, ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, out bool msgDiv, out string errMsg)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		msgDiv = false;
		errMsg = string.Empty;

		if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

		SqlConnection sqlConnection = null;
		SqlTransaction sqlTransaction = null;
		try
		{
			//コネクション生成
			sqlConnection = GetSCMConnection();
			if (sqlConnection == null) return status;
			sqlConnection.Open();

			// トランザクション開始
			sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

			foreach (ScmOdDtCarWork scmOdDtCarWork in scmOdDtCarWorkArray)
			{
				// 排他チェック
				status = CheckExclusion(scmOdDtCarWork, sqlConnection, sqlTransaction);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					List<ScmOdrDataWork> scmOdrDataWorkList = new List<ScmOdrDataWork>(scmOdrDataWorkArray);
					List<ScmOdrDataWork> wkList = scmOdrDataWorkList.FindAll(
						delegate(ScmOdrDataWork wkObj)
						{
							if (wkObj.InqOriginalEpCd == scmOdDtCarWork.InqOriginalEpCd &&
								wkObj.InqOriginalSecCd == scmOdDtCarWork.InqOriginalSecCd &&
								wkObj.InquiryNumber == scmOdDtCarWork.InquiryNumber)
								return true;
							else
								return false;
						}
					);

					// 受信日時の更新
					if (wkList != null && wkList.Count > 0)
					{
						ScmOdrDataWork[] wkArray = wkList.ToArray();
						status = UpdateRcvDateTimeProc(ref wkArray, sqlConnection, sqlTransaction);
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					List<ScmOdDtInqWork> scmOdDtInqWorkList = new List<ScmOdDtInqWork>(scmOdDtInqWorkArray);
					List<ScmOdDtInqWork> wkList = scmOdDtInqWorkList.FindAll(
						delegate(ScmOdDtInqWork wkObj)
						{
							if (wkObj.InqOriginalEpCd == scmOdDtCarWork.InqOriginalEpCd &&
								wkObj.InqOriginalSecCd == scmOdDtCarWork.InqOriginalSecCd &&
								wkObj.InquiryNumber == scmOdDtCarWork.InquiryNumber)
								return true;
							else
								return false;
						}
					);

					// 明細取込区分（問合せ・発注）の更新
					if (wkList != null && wkList.Count > 0)
					{
						ScmOdDtInqWork[] wkArray = wkList.ToArray();
						status = UpdateInqDtlTakeinDivCdProc(ref wkArray, sqlConnection, sqlTransaction);
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					List<ScmOdDtAnsWork> scmOdDtAnsWorkList = new List<ScmOdDtAnsWork>(scmOdDtAnsWorkArray);
					List<ScmOdDtAnsWork> wkList = scmOdDtAnsWorkList.FindAll(
						delegate(ScmOdDtAnsWork wkObj)
						{
							if (wkObj.InqOriginalEpCd == scmOdDtCarWork.InqOriginalEpCd &&
								wkObj.InqOriginalSecCd == scmOdDtCarWork.InqOriginalSecCd &&
								wkObj.InquiryNumber == scmOdDtCarWork.InquiryNumber)
								return true;
							else
								return false;
						}
					);

					// 明細取込区分（回答）の更新
					if (wkList != null && wkList.Count > 0)
					{
						ScmOdDtAnsWork[] wkArray = wkList.ToArray();
						status = UpdateAnsDtlTakeinDivCdProc(ref wkArray, sqlConnection, sqlTransaction);
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// コミット
					sqlTransaction.Commit();
				}
				else
				{
					// ロールバック
					sqlTransaction.Rollback();
				}
			}
		}
		catch (SqlException ex)
		{
			msgDiv = true;
			if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				errMsg = "明細取込区分の更新処理中にタイムアウトが発生しました。";
			else
				errMsg = "明細取込区分の更新処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
		}
		catch (Exception ex)
		{
			msgDiv = true;
			errMsg = "明細取込区分の更新処理に失敗しました。";
			// ロールバック
			if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			LogOutPut.WriteErrorLog(ex, errMsg, status);
		}
		finally
		{
			if (sqlTransaction.Connection != null)
				sqlTransaction.Dispose();

			if (sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
		}

		return status;
	}
	#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

    // -- ADD 2011/08/10   ------ >>>>>>
    /// <summary>
    /// SCM受発注データ登録処理（回答）
    /// </summary>
    /// <param name="authenticateCode">認証コード</param>
    /// <param name="scmOdrDataWork">SCM受発注データ</param>
    /// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
    /// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
    /// <param name="scmAcOdSetDtWorkArray">受発注セット部品データ配列</param>
    /// <param name="isCheckDtlTakeinDivCd">データ登録時に明細取込区分のチェック有無[true:チェックする,false:チェックしない]</param>
    /// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
    /// <param name="errMsg">エラーメッセージ</param>
    /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
    /// <remarks>
    /// <br>Note		: SCM受発注データの登録処理を行います。</br>
    /// <br>			: SCM受発注データ[Insert]</br>
    /// <br>			: SCM受発注データ(車両情報)[Insert/Update]</br>
    /// <br>			: 受発注明細データ（回答）[Insert]</br>
    /// <br>			: 受発注セット部品データ[Insert]</br>
    /// <br>Programmer	: 劉立</br>
    /// <br>Date		: 2011/08/10</br>
    /// </remarks>
    #region WriteAnsWithCar3
    [WebMethod]
    public int WriteAnsWithCar3(string authenticateCode, ref ScmOdrDataWork[] scmOdrDataWorkArray, ref ScmOdDtCarWork scmOdDtCarWork, ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, ref ScmOdSetDtWork[] scmOdSetDtWorkArray, bool isCheckDtlTakeinDivCd, out bool msgDiv, out string errMsg)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        msgDiv = false;
        errMsg = string.Empty;

        if (!ctAuthenticateCode.Equals(authenticateCode)) return -1;

        SqlConnection sqlConnection = null;
        SqlTransaction sqlTransaction = null;
        try
        {
            //コネクション生成
            sqlConnection = GetSCMConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // トランザクション開始
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            //番号採番
            if (scmOdrDataWorkArray != null && scmOdrDataWorkArray.Length > 0 && scmOdrDataWorkArray[0].InquiryNumber == 0)
            {
                int scmNoCode = 1;
                int newNo;
                SCMNumberNumbering numberNumbering = new SCMNumberNumbering();
                status = numberNumbering.Numbering(scmOdrDataWorkArray[0].InqOriginalEpCd
                    , scmOdrDataWorkArray[0].InqOriginalSecCd
                    , scmNoCode
                    , out newNo
                    , out msgDiv
                    , out errMsg
                    , ref sqlConnection
                    , ref sqlTransaction);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
                                scmOdrDataWork.InquiryNumber = newNo;
                            scmOdDtCarWork.InquiryNumber = newNo;
                            foreach (ScmOdDtAnsWork scmAcOdSetDtWork in scmOdDtAnsWorkArray)
                                scmAcOdSetDtWork.InquiryNumber = newNo;
                            break;
                        }
                    default:
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                }
            }

            // 更新日付(キー情報にも使用)
            DateTime updateDate = DateTime.Now;
            int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;

            // SCM受発注データの登録
            status = WriteScmOdrDataProc(ref scmOdrDataWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);

            // 受発注明細マスタ（回答）の登録
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = WriteScmOdDtAnsProc(ref scmOdDtAnsWorkArray, updateDate, updateTime, isCheckDtlTakeinDivCd, sqlConnection, sqlTransaction);
            }

            // SCM受発注データ（車両）の登録
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = WriteScmOdDtCarProc(ref scmOdDtCarWork, updateDate, sqlConnection, sqlTransaction);
            }
            // 課金ログの登録
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                # if Release
                status = ScmBilLogWrp.Write(scmOdrDataWorkArray, null, scmOdDtAnsWorkArray, sqlConnection, sqlTransaction);
                # endif
            }
            // セット情報の登録
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = WriteScmOdSetDtProc(ref scmOdSetDtWorkArray, updateDate, updateTime, sqlConnection, sqlTransaction);
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // コミット
                sqlTransaction.Commit();
            }
            else
            {
                // ロールバック
                sqlTransaction.Rollback();
            }
        }
        catch (SqlException ex)
        {
            msgDiv = true;
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                errMsg = "受発注データ（回答）の登録処理中にタイムアウトが発生しました。";
            else
                errMsg = "受発注データ（回答）の登録処理に失敗しました。";
            // ロールバック
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

            status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
        }
        catch (Exception ex)
        {
            msgDiv = true;
            errMsg = "受発注データ（回答）の登録処理に失敗しました。";
            // ロールバック
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            LogOutPut.WriteErrorLog(ex, errMsg, status);
        }
        finally
        {
            if (sqlTransaction.Connection != null)
                sqlTransaction.Dispose();

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        return status;
    }
    #endregion
    // -- ADD 2011/08/10   ------ <<<<<<
	#endregion

	#region Private Method
	/// <summary>
	/// SCM受発注データ登録処理
	/// </summary>
	/// <param name="scmOdrDataWork">SCM受発注データ</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="updateTime">更新時分秒ミリ秒</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データのInsertを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region WriteScmOdrDataProc
	private int WriteScmOdrDataProc(ref ScmOdrDataWork[] scmOdrDataWorkArray, DateTime updateDate, int updateTime, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlCommand sqlCommand = null;

		try
		{
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			// 確定済みかどうかのチェック
			foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
			{
				if (IsScmOdrDataFixed(scmOdrDataWork, false, sqlConnection, sqlTransaction))
				{
					status = 998;
					return status;
				}
			}

			// Insertコマンドの生成
			sqlCommand = new SqlCommand("INSERT INTO SCMODRDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, ANSWERDIVCDRF, JUDGEMENTDATERF, INQORDNOTERF, INQEMPLOYEECDRF, INQEMPLOYEENMRF, ANSEMPLOYEECDRF, ANSEMPLOYEENMRF, INQUIRYDATERF, INQORDDIVCDRF, INQORDANSDIVCDRF, RECEIVEDATETIMERF, LATESTDISCCODERF, CANCELDIVRF, CMTCOOPRTDIVRF, "
				+ "SFPMCPRTINSTSLIPNORF"
                + ", ACCEPTORORDERKINDRF" //2011.08.10 Add
				+ ") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @ANSWERDIVCD, @JUDGEMENTDATE, @INQORDNOTE, @INQEMPLOYEECD, @INQEMPLOYEENM, @ANSEMPLOYEECD, @ANSEMPLOYEENM, @INQUIRYDATE, @INQORDDIVCD, @INQORDANSDIVCD, @RECEIVEDATETIME, @LATESTDISCCODE, @CANCELDIV, @CMTCOOPRTDIV, "
				+ "@SFPMCPRTINSTSLIPNO"
                + ", @ACCEPTORORDERKIND" //2011.08.10 Add
				+ ")"
				, sqlConnection, sqlTransaction);

			#region Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime		= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime		= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraLogicalDeleteCode	= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraInqOriginalEpCd	= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter paraInqOriginalSecCd	= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter paraInqOtherEpCd		= sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
			SqlParameter paraInqOtherSecCd		= sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
			SqlParameter paraInquiryNumber		= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter paraUpdateDate			= sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
			SqlParameter paraUpdateTime			= sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
			SqlParameter paraAnswerDivCd		= sqlCommand.Parameters.Add("@ANSWERDIVCD", SqlDbType.Int);
			SqlParameter paraJudgementDate		= sqlCommand.Parameters.Add("@JUDGEMENTDATE", SqlDbType.Int);
			SqlParameter paraInqOrdNote			= sqlCommand.Parameters.Add("@INQORDNOTE", SqlDbType.NVarChar);
			SqlParameter paraInqEmployeeCd		= sqlCommand.Parameters.Add("@INQEMPLOYEECD", SqlDbType.NChar);
			SqlParameter paraInqEmployeeNm		= sqlCommand.Parameters.Add("@INQEMPLOYEENM", SqlDbType.NVarChar);
			SqlParameter paraAnsEmployeeCd		= sqlCommand.Parameters.Add("@ANSEMPLOYEECD", SqlDbType.NChar);
			SqlParameter paraAnsEmployeeNm		= sqlCommand.Parameters.Add("@ANSEMPLOYEENM", SqlDbType.NVarChar);
			SqlParameter paraInquiryDate		= sqlCommand.Parameters.Add("@INQUIRYDATE", SqlDbType.Int);
			SqlParameter paraInqOrdDivCd		= sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
			SqlParameter paraInqOrdAnsDivCd		= sqlCommand.Parameters.Add("@INQORDANSDIVCD", SqlDbType.Int);
			SqlParameter paraReceiveDateTime	= sqlCommand.Parameters.Add("@RECEIVEDATETIME", SqlDbType.BigInt);
			SqlParameter paraLatestDiscCode		= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
			SqlParameter paraCancelDiv			= sqlCommand.Parameters.Add("@CANCELDIV", SqlDbType.SmallInt);
			SqlParameter paraCMTCooprtDiv		= sqlCommand.Parameters.Add("@CMTCOOPRTDIV", SqlDbType.SmallInt);
			SqlParameter paraSfPmCprtInstSlipNo	= sqlCommand.Parameters.Add("@SFPMCPRTINSTSLIPNO", SqlDbType.NVarChar);
            SqlParameter paraAcceptOrOrderKind  = sqlCommand.Parameters.Add("@ACCEPTORORDERKIND", SqlDbType.SmallInt); //2011.08.10 Add
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
			{
				// 受発注データ最新識別区分更新処理
				status = UpdateLatestDiscCodeProc(scmOdrDataWork, updateDate, sqlConnection, sqlTransaction);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
				
				// 登録ヘッダ情報を設定
				if (updateDate == DateTime.MinValue)
				{
					updateDate = DateTime.Now;
					updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;
				}
				scmOdrDataWork.CreateDateTime	= updateDate;
				scmOdrDataWork.UpdateDateTime	= updateDate;
				scmOdrDataWork.UpdateDate		= updateDate;
				scmOdrDataWork.UpdateTime		= updateTime;

				#region 2011.05.19 TERASAKA DEL STA
				// Insertコマンドの生成
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////				sqlCommand = new SqlCommand("INSERT INTO SCMODRDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, ANSWERDIVCDRF, JUDGEMENTDATERF, INQORDNOTERF, INQEMPLOYEECDRF, INQEMPLOYEENMRF, ANSEMPLOYEECDRF, ANSEMPLOYEENMRF, INQUIRYDATERF, INQORDDIVCDRF, INQORDANSDIVCDRF, RECEIVEDATETIMERF, LATESTDISCCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @ANSWERDIVCD, @JUDGEMENTDATE, @INQORDNOTE, @INQEMPLOYEECD, @INQEMPLOYEENM, @ANSEMPLOYEECD, @ANSEMPLOYEENM, @INQUIRYDATE, @INQORDDIVCD, @INQORDANSDIVCD, @RECEIVEDATETIME, @LATESTDISCCODE)", sqlConnection, sqlTransaction);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				sqlCommand = new SqlCommand("INSERT INTO SCMODRDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, ANSWERDIVCDRF, JUDGEMENTDATERF, INQORDNOTERF, INQEMPLOYEECDRF, INQEMPLOYEENMRF, ANSEMPLOYEECDRF, ANSEMPLOYEENMRF, INQUIRYDATERF, INQORDDIVCDRF, INQORDANSDIVCDRF, RECEIVEDATETIMERF, LATESTDISCCODERF, CANCELDIVRF, CMTCOOPRTDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @ANSWERDIVCD, @JUDGEMENTDATE, @INQORDNOTE, @INQEMPLOYEECD, @INQEMPLOYEENM, @ANSEMPLOYEECD, @ANSEMPLOYEENM, @INQUIRYDATE, @INQORDDIVCD, @INQORDANSDIVCD, @RECEIVEDATETIME, @LATESTDISCCODE, @CANCELDIV, @CMTCOOPRTDIV)", sqlConnection, sqlTransaction);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//
//				#region Prameterオブジェクトの作成
//				SqlParameter paraCreateDateTime		= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraUpdateDateTime		= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraLogicalDeleteCode	= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
//				SqlParameter paraInqOriginalEpCd	= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
//				SqlParameter paraInqOriginalSecCd	= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
//				SqlParameter paraInqOtherEpCd		= sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
//				SqlParameter paraInqOtherSecCd		= sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
//				SqlParameter paraInquiryNumber		= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
//				SqlParameter paraUpdateDate			= sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
//				SqlParameter paraUpdateTime			= sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
//				SqlParameter paraAnswerDivCd		= sqlCommand.Parameters.Add("@ANSWERDIVCD", SqlDbType.Int);
//				SqlParameter paraJudgementDate		= sqlCommand.Parameters.Add("@JUDGEMENTDATE", SqlDbType.Int);
//				SqlParameter paraInqOrdNote			= sqlCommand.Parameters.Add("@INQORDNOTE", SqlDbType.NVarChar);
//				SqlParameter paraInqEmployeeCd		= sqlCommand.Parameters.Add("@INQEMPLOYEECD", SqlDbType.NChar);
//				SqlParameter paraInqEmployeeNm		= sqlCommand.Parameters.Add("@INQEMPLOYEENM", SqlDbType.NVarChar);
//				SqlParameter paraAnsEmployeeCd		= sqlCommand.Parameters.Add("@ANSEMPLOYEECD", SqlDbType.NChar);
//				SqlParameter paraAnsEmployeeNm		= sqlCommand.Parameters.Add("@ANSEMPLOYEENM", SqlDbType.NVarChar);
//				SqlParameter paraInquiryDate		= sqlCommand.Parameters.Add("@INQUIRYDATE", SqlDbType.Int);
//				SqlParameter paraInqOrdDivCd		= sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
//				SqlParameter paraInqOrdAnsDivCd		= sqlCommand.Parameters.Add("@INQORDANSDIVCD", SqlDbType.Int);
//				SqlParameter paraReceiveDateTime	= sqlCommand.Parameters.Add("@RECEIVEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraLatestDiscCode		= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				SqlParameter paraCancelDiv			= sqlCommand.Parameters.Add("@CANCELDIV", SqlDbType.SmallInt);
//				SqlParameter paraCMTCooprtDiv		= sqlCommand.Parameters.Add("@CMTCOOPRTDIV", SqlDbType.SmallInt);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//				#endregion
				#endregion

				#region Parameterオブジェクトへ値設定
				paraCreateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdrDataWork.CreateDateTime);
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdrDataWork.UpdateDateTime);
				paraLogicalDeleteCode.Value	= SqlDataMediator.SqlSetInt32(scmOdrDataWork.LogicalDeleteCode);
				paraInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalEpCd);
				paraInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalSecCd);
				paraInqOtherEpCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherEpCd);
				paraInqOtherSecCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherSecCd);
				paraInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdrDataWork.InquiryNumber);
				paraUpdateDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdrDataWork.UpdateDate);
				paraUpdateTime.Value		= SqlDataMediator.SqlSetInt32(scmOdrDataWork.UpdateTime);
				paraAnswerDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdrDataWork.AnswerDivCd);
				paraJudgementDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdrDataWork.JudgementDate);
				paraInqOrdNote.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOrdNote);
				paraInqEmployeeCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqEmployeeCd);
				paraInqEmployeeNm.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqEmployeeNm);
				paraAnsEmployeeCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.AnsEmployeeCd);
				paraAnsEmployeeNm.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.AnsEmployeeNm);
				paraInquiryDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdrDataWork.InquiryDate);
				paraInqOrdDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdrDataWork.InqOrdDivCd);
				paraInqOrdAnsDivCd.Value	= SqlDataMediator.SqlSetInt32(scmOdrDataWork.InqOrdAnsDivCd);
				paraReceiveDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdrDataWork.ReceiveDateTime);
				paraLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(scmOdrDataWork.LatestDiscCode);
////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
				paraCancelDiv.Value			= SqlDataMediator.SqlSetInt16(scmOdrDataWork.CancelDiv);
				paraCMTCooprtDiv.Value		= SqlDataMediator.SqlSetInt16(scmOdrDataWork.CMTCooprtDiv);
// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				paraSfPmCprtInstSlipNo.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.SfPmCprtInstSlipNo);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
                paraAcceptOrOrderKind.Value     = SqlDataMediator.SqlSetInt16(scmOdrDataWork.AcceptOrOrderKind); //2011.08.10 Add
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ最新識別区分更新処理
	/// </summary>
	/// <param name="scmOdrDataWork">SCM受発注データ</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの最新識別区分を1:旧データにUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region UpdateLatestDiscCodeProc
	private int UpdateLatestDiscCodeProc(ScmOdrDataWork scmOdrDataWork, DateTime updateDate, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// 最新識別フラグ
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODRDATARF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter findParaInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			SqlParameter findParaInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter findParaLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);

			//Parameterオブジェクトへ値設定
			findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalEpCd);
			findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalSecCd);
			findParaInqOtherEpCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherEpCd);
			findParaInqOtherSecCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherSecCd);
			findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdrDataWork.InquiryNumber);
			findParaLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(0);

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				DateTime exclusionUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// 更新日時
				if (exclusionUpdateDateTime > updateDate)
				{
					// 更新日時が新しい場合は排他
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					return status;
				}

				// Updateコマンドの生成
				sqlCommand.CommandText = "UPDATE SCMODRDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , LATESTDISCCODERF=@LATESTDISCCODE";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

				// Keyデータ再設定
				findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalEpCd);
				findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalSecCd);
				findParaInqOtherEpCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherEpCd);
				findParaInqOtherSecCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherSecCd);
				findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdrDataWork.InquiryNumber);
				findParaLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(0);

				if (!myReader.IsClosed) myReader.Close();

				#region Prameterオブジェクトの作成
				SqlParameter paraUpdateDateTime	= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraLatestDiscCode	= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(updateDate);
				paraLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(1);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注明細データ（問合せ・発注）登録処理
	/// </summary>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="updateTime">更新時分秒ミリ秒</param>
	/// <param name="isCheckDtlTakeinDivCd">Insert前に明細取込区分のチェック有無[true:チェックする,false:チェックしない]</param>
    /// <param name="acceptOrOrderKin">受発注種別</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注明細データ（問合せ・発注）のInsertを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region WriteScmOdDtInqProc
	#region 2011.02.01 TERASAKA DEL STA
//	private int WriteScmOdDtInqProc(ref List<ScmOdDtInqWork> scmOdDtInqWorkList, DateTime updateDate, int updateTime, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	#endregion
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
    //private int WriteScmOdDtInqProc(ref ScmOdDtInqWork[] scmOdDtInqWorkArray, DateTime updateDate, int updateTime, bool isCheckDtlTakeinDivCd, SqlConnection sqlConnection, SqlTransaction sqlTransaction) // Del by zhangw on 2011.08.03 For PCC_UOE
    private int WriteScmOdDtInqProc(ref ScmOdDtInqWork[] scmOdDtInqWorkArray, DateTime updateDate, int updateTime, bool isCheckDtlTakeinDivCd, int acceptOrOrderKin, SqlConnection sqlConnection, SqlTransaction sqlTransaction) // ADD by zhangw on 2011.08.03 For PCC_UOE
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlCommand sqlCommand = null;

		try
		{
			List<int> usedRowNumberList = null;
			Dictionary<int, int> rowNumberList = null;
			Dictionary<int, List<int>> derivedNoList = null;
			#region 2011.02.01 TERASAKA DEL STA
//			foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkList)
			#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			//Insertコマンドの生成
			sqlCommand = new SqlCommand("INSERT INTO SCMODDTINQRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF, PMWAREHOUSECDRF, PMWAREHOUSENAMERF, "
				+ "PMSHELFNORF"
                + ", PMPRSNTCOUNTRF, SETPARTSMKRCDRF, SETPARTSNUMBERRF, SETPARTSMAINSUBNORF" //2011.08.10 Add
				+ ") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE, @CANCELCNDTINDIV, @PMACPTANODRSTATUS, @PMSALESSLIPNUM, @PMSALESROWNO, @DTLTAKEINDIVCD, @PMWAREHOUSECD, @PMWAREHOUSENAME, "
				+ "@PMSHELFNO"
                + ", @PMPRSNTCOUNT, @SETPARTSMKRCD, @SETPARTSNUMBER, @SETPARTSMAINSUBNO" //2011.08.10 Add
				+ ")", sqlConnection, sqlTransaction);

			#region Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraInqOriginalEpCd		= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter paraInqOriginalSecCd		= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter paraInqOtherEpCd			= sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
			SqlParameter paraInqOtherSecCd			= sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
			SqlParameter paraInquiryNumber			= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter paraUpdateDate				= sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
			SqlParameter paraUpdateTime				= sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
			SqlParameter paraInqRowNumber			= sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);
			SqlParameter paraInqRowNumDerivedNo		= sqlCommand.Parameters.Add("@INQROWNUMDERIVEDNO", SqlDbType.Int);
			SqlParameter paraInqOrgDtlDiscGuid		= sqlCommand.Parameters.Add("@INQORGDTLDISCGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraInqOthDtlDiscGuid		= sqlCommand.Parameters.Add("@INQOTHDTLDISCGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraGoodsDivCd				= sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
			SqlParameter paraRecyclePrtKindCode		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDCODE", SqlDbType.Int);
			SqlParameter paraRecyclePrtKindName		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDNAME", SqlDbType.NVarChar);
			SqlParameter paraDeliveredGoodsDiv		= sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
			SqlParameter paraHandleDivCode			= sqlCommand.Parameters.Add("@HANDLEDIVCODE", SqlDbType.Int);
			SqlParameter paraGoodsShape				= sqlCommand.Parameters.Add("@GOODSSHAPE", SqlDbType.Int);
			SqlParameter paraDelivrdGdsConfCd		= sqlCommand.Parameters.Add("@DELIVRDGDSCONFCD", SqlDbType.Int);
			SqlParameter paraDeliGdsCmpltDueDate	= sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
			SqlParameter paraAnswerDeliveryDate		= sqlCommand.Parameters.Add("@ANSWERDELIVERYDATE", SqlDbType.NVarChar);
			SqlParameter paraBLGoodsCode			= sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
			SqlParameter paraBLGoodsDrCode			= sqlCommand.Parameters.Add("@BLGOODSDRCODE", SqlDbType.Int);
			SqlParameter paraInqGoodsName			= sqlCommand.Parameters.Add("@INQGOODSNAME", SqlDbType.NVarChar);
			SqlParameter paraAnsGoodsName			= sqlCommand.Parameters.Add("@ANSGOODSNAME", SqlDbType.NVarChar);
			SqlParameter paraSalesOrderCount		= sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
			SqlParameter paraDeliveredGoodsCount	= sqlCommand.Parameters.Add("@DELIVEREDGOODSCOUNT", SqlDbType.Float);
			SqlParameter paraGoodsNo				= sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
			SqlParameter paraGoodsMakerCd			= sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
			SqlParameter paraGoodsMakerNm			= sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
			SqlParameter paraPureGoodsMakerCd		= sqlCommand.Parameters.Add("@PUREGOODSMAKERCD", SqlDbType.Int);
			SqlParameter paraInqPureGoodsNo			= sqlCommand.Parameters.Add("@INQPUREGOODSNO", SqlDbType.NVarChar);
			SqlParameter paraAnsPureGoodsNo			= sqlCommand.Parameters.Add("@ANSPUREGOODSNO", SqlDbType.NVarChar);
			SqlParameter paraListPrice				= sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
			SqlParameter paraUnitPrice				= sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
			SqlParameter paraGoodsAddInfo			= sqlCommand.Parameters.Add("@GOODSADDINFO", SqlDbType.NVarChar);
			SqlParameter paraRoughRrofit			= sqlCommand.Parameters.Add("@ROUGHRROFIT", SqlDbType.BigInt);
			SqlParameter paraRoughRate				= sqlCommand.Parameters.Add("@ROUGHRATE", SqlDbType.Float);
			SqlParameter paraAnswerLimitDate		= sqlCommand.Parameters.Add("@ANSWERLIMITDATE", SqlDbType.Int);
			SqlParameter paraCommentDtl				= sqlCommand.Parameters.Add("@COMMENTDTL", SqlDbType.NVarChar);
			SqlParameter paraShelfNo				= sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
			SqlParameter paraAdditionalDivCd		= sqlCommand.Parameters.Add("@ADDITIONALDIVCD", SqlDbType.Int);
			SqlParameter paraCorrectDivCD			= sqlCommand.Parameters.Add("@CORRECTDIVCD", SqlDbType.Int);
			SqlParameter paraInqOrdDivCd			= sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
			SqlParameter paraDisplayOrder			= sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
			SqlParameter paraLatestDiscCode			= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
			SqlParameter paraCancelCndtinDiv		= sqlCommand.Parameters.Add("@CANCELCNDTINDIV", SqlDbType.SmallInt);
			SqlParameter paraPMAcptAnOdrStatus		= sqlCommand.Parameters.Add("@PMACPTANODRSTATUS", SqlDbType.Int);
			SqlParameter paraPMSalesSlipNum			= sqlCommand.Parameters.Add("@PMSALESSLIPNUM", SqlDbType.Int);
			SqlParameter paraPMSalesRowNo			= sqlCommand.Parameters.Add("@PMSALESROWNO", SqlDbType.Int);
			SqlParameter paraDtlTakeinDivCd			= sqlCommand.Parameters.Add("@DTLTAKEINDIVCD", SqlDbType.Int);
			SqlParameter paraPmWarehouseCd			= sqlCommand.Parameters.Add("@PMWAREHOUSECD", SqlDbType.NVarChar);
			SqlParameter paraPmWarehouseName		= sqlCommand.Parameters.Add("@PMWAREHOUSENAME", SqlDbType.NVarChar);
			SqlParameter paraPmShelfNo				= sqlCommand.Parameters.Add("@PMSHELFNO", SqlDbType.NVarChar);
            ////////////////////////////////////////////// 2011.08.10 huangqb ADD STA //
            SqlParameter paraPmPrsntCount           = sqlCommand.Parameters.Add("@PMPRSNTCOUNT", SqlDbType.Float);
            SqlParameter paraSetPartsMkrCd          = sqlCommand.Parameters.Add("@SETPARTSMKRCD", SqlDbType.Int);
            SqlParameter paraSetPartsNumber         = sqlCommand.Parameters.Add("@SETPARTSNUMBER", SqlDbType.NVarChar);
            SqlParameter paraSetPartsMainSubNo      = sqlCommand.Parameters.Add("@SETPARTSMAINSUBNO", SqlDbType.Int);
            // 2011.08.10 huangqb ADD END //////////////////////////////////////////////
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
            List<ScmOdDtInqWork> scmOdDtInqWorkList = new List<ScmOdDtInqWork>();// ADD by zhangw on 2011.08.03 For PCC_UOE
			foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkArray)
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
			{
                // ADD by zhangw on 2011.08.03 For PCC_UOE STA
                // 親のデータの格納
                if (!string.IsNullOrEmpty(scmOdDtInqWork.SetPartsNumber) && scmOdDtInqWork.SetPartsMainSubNo == 0)
                {
                    scmOdDtInqWorkList.Add(scmOdDtInqWork);
                }
                // ADD by zhangw on 2011.08.03 For PCC_UOE END
				// 問合せ行番号が0未満の場合は採番する
				if (scmOdDtInqWork.InqRowNumber <= 0)
				{
					if (rowNumberList == null) rowNumberList = new Dictionary<int, int>();

					if (rowNumberList.ContainsKey(scmOdDtInqWork.InqRowNumber))
					{
						scmOdDtInqWork.InqRowNumber = rowNumberList[scmOdDtInqWork.InqRowNumber];
					}
					else
					{
						if (usedRowNumberList == null) usedRowNumberList = new List<int>();

						// 新しい行番号を取得する
						int inqRowNumber = GetNewInqRowNumber(ref usedRowNumberList, scmOdDtInqWork.InqOriginalEpCd, scmOdDtInqWork.InqOriginalSecCd, scmOdDtInqWork.InquiryNumber, sqlConnection, sqlTransaction);
						if (inqRowNumber == 0) return status;

						rowNumberList.Add(scmOdDtInqWork.InqRowNumber, inqRowNumber);

						// 行番号を書き換える
						scmOdDtInqWork.InqRowNumber = inqRowNumber;
					}
				}

				// 問合せ行番号枝番が0未満の場合は採番する
				if (scmOdDtInqWork.InqRowNumDerivedNo <= 0)
				{
					if (derivedNoList == null) derivedNoList = new Dictionary<int, List<int>>();

					List<int> usedDerivedNoList = null;
					if (derivedNoList.ContainsKey(scmOdDtInqWork.InqRowNumber))
					{
						usedDerivedNoList = derivedNoList[scmOdDtInqWork.InqRowNumber];
					}
					else
					{
						usedDerivedNoList = new List<int>();
						derivedNoList.Add(scmOdDtInqWork.InqRowNumber, usedDerivedNoList);
					}

					// 新しい行番号枝番を取得する
					int inqRowNumDerivedNo = GetNewInqRowNumDerivedNo(ref usedDerivedNoList, scmOdDtInqWork.InqOriginalEpCd, scmOdDtInqWork.InqOriginalSecCd, scmOdDtInqWork.InquiryNumber, scmOdDtInqWork.InqRowNumber, sqlConnection, sqlTransaction);
					if (inqRowNumDerivedNo == 0) return status;

					// 行番号枝番を書き換える
					scmOdDtInqWork.InqRowNumDerivedNo = inqRowNumDerivedNo;
				}
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
				if (isCheckDtlTakeinDivCd)
				{
					// データが既に問合せ先に取込済かのチェックを行い、取込済の場合は処理を終了する
					if (IsTakeInScmOdDtInq(scmOdDtInqWork, sqlConnection, sqlTransaction))
					{
						status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
						return status;
					}
				}
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////

				// SCM受発注明細データ（問合せ・発注）最新識別区分更新処理
				status = UpdateLatestDiscCodeProc(scmOdDtInqWork, updateDate, sqlConnection, sqlTransaction);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
				
				// 登録ヘッダ情報を設定
				if (updateDate == DateTime.MinValue)
				{
					updateDate = DateTime.Now;
					updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;
				}
				scmOdDtInqWork.CreateDateTime	= updateDate;
				scmOdDtInqWork.UpdateDateTime	= updateDate;
				scmOdDtInqWork.UpdateDate		= updateDate;
				scmOdDtInqWork.UpdateTime		= updateTime;

				#region 2011.05.19 TERASAKA DEL STA
//				//Insertコマンドの生成
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////				sqlCommand = new SqlCommand("INSERT INTO SCMODDTINQRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE)", sqlConnection, sqlTransaction);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//				#region 2011.02.01 TERASAKA DEL STA
////////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
////				sqlCommand = new SqlCommand("INSERT INTO SCMODDTINQRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE, @CANCELCNDTINDIV, @PMACPTANODRSTATUS, @PMSALESSLIPNUM, @PMSALESROWNO)", sqlConnection, sqlTransaction);
////// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//				#endregion
////////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//				sqlCommand = new SqlCommand("INSERT INTO SCMODDTINQRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE, @CANCELCNDTINDIV, @PMACPTANODRSTATUS, @PMSALESSLIPNUM, @PMSALESROWNO, @DTLTAKEINDIVCD)", sqlConnection, sqlTransaction);
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
//				
//				#region Prameterオブジェクトの作成
//				SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
//				SqlParameter paraInqOriginalEpCd		= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
//				SqlParameter paraInqOriginalSecCd		= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
//				SqlParameter paraInqOtherEpCd			= sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
//				SqlParameter paraInqOtherSecCd			= sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
//				SqlParameter paraInquiryNumber			= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
//				SqlParameter paraUpdateDate				= sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
//				SqlParameter paraUpdateTime				= sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
//				SqlParameter paraInqRowNumber			= sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);
//				SqlParameter paraInqRowNumDerivedNo		= sqlCommand.Parameters.Add("@INQROWNUMDERIVEDNO", SqlDbType.Int);
//				SqlParameter paraInqOrgDtlDiscGuid		= sqlCommand.Parameters.Add("@INQORGDTLDISCGUID", SqlDbType.UniqueIdentifier);
//				SqlParameter paraInqOthDtlDiscGuid		= sqlCommand.Parameters.Add("@INQOTHDTLDISCGUID", SqlDbType.UniqueIdentifier);
//				SqlParameter paraGoodsDivCd				= sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
//				SqlParameter paraRecyclePrtKindCode		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDCODE", SqlDbType.Int);
//				SqlParameter paraRecyclePrtKindName		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDNAME", SqlDbType.NVarChar);
//				SqlParameter paraDeliveredGoodsDiv		= sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
//				SqlParameter paraHandleDivCode			= sqlCommand.Parameters.Add("@HANDLEDIVCODE", SqlDbType.Int);
//				SqlParameter paraGoodsShape				= sqlCommand.Parameters.Add("@GOODSSHAPE", SqlDbType.Int);
//				SqlParameter paraDelivrdGdsConfCd		= sqlCommand.Parameters.Add("@DELIVRDGDSCONFCD", SqlDbType.Int);
//				SqlParameter paraDeliGdsCmpltDueDate	= sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
//				SqlParameter paraAnswerDeliveryDate		= sqlCommand.Parameters.Add("@ANSWERDELIVERYDATE", SqlDbType.NVarChar);
//				SqlParameter paraBLGoodsCode			= sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
//				SqlParameter paraBLGoodsDrCode			= sqlCommand.Parameters.Add("@BLGOODSDRCODE", SqlDbType.Int);
//				SqlParameter paraInqGoodsName			= sqlCommand.Parameters.Add("@INQGOODSNAME", SqlDbType.NVarChar);
//				SqlParameter paraAnsGoodsName			= sqlCommand.Parameters.Add("@ANSGOODSNAME", SqlDbType.NVarChar);
//				SqlParameter paraSalesOrderCount		= sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
//				SqlParameter paraDeliveredGoodsCount	= sqlCommand.Parameters.Add("@DELIVEREDGOODSCOUNT", SqlDbType.Float);
//				SqlParameter paraGoodsNo				= sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
//				SqlParameter paraGoodsMakerCd			= sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
//				SqlParameter paraGoodsMakerNm			= sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
//				SqlParameter paraPureGoodsMakerCd		= sqlCommand.Parameters.Add("@PUREGOODSMAKERCD", SqlDbType.Int);
//				SqlParameter paraInqPureGoodsNo			= sqlCommand.Parameters.Add("@INQPUREGOODSNO", SqlDbType.NVarChar);
//				SqlParameter paraAnsPureGoodsNo			= sqlCommand.Parameters.Add("@ANSPUREGOODSNO", SqlDbType.NVarChar);
//				SqlParameter paraListPrice				= sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
//				SqlParameter paraUnitPrice				= sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
//				SqlParameter paraGoodsAddInfo			= sqlCommand.Parameters.Add("@GOODSADDINFO", SqlDbType.NVarChar);
//				SqlParameter paraRoughRrofit			= sqlCommand.Parameters.Add("@ROUGHRROFIT", SqlDbType.BigInt);
//				SqlParameter paraRoughRate				= sqlCommand.Parameters.Add("@ROUGHRATE", SqlDbType.Float);
//				SqlParameter paraAnswerLimitDate		= sqlCommand.Parameters.Add("@ANSWERLIMITDATE", SqlDbType.Int);
//				SqlParameter paraCommentDtl				= sqlCommand.Parameters.Add("@COMMENTDTL", SqlDbType.NVarChar);
//				SqlParameter paraShelfNo				= sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
//				SqlParameter paraAdditionalDivCd		= sqlCommand.Parameters.Add("@ADDITIONALDIVCD", SqlDbType.Int);
//				SqlParameter paraCorrectDivCD			= sqlCommand.Parameters.Add("@CORRECTDIVCD", SqlDbType.Int);
//				SqlParameter paraInqOrdDivCd			= sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
//				SqlParameter paraDisplayOrder			= sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
//				SqlParameter paraLatestDiscCode			= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				SqlParameter paraCancelCndtinDiv		= sqlCommand.Parameters.Add("@CANCELCNDTINDIV", SqlDbType.SmallInt);
//				SqlParameter paraPMAcptAnOdrStatus		= sqlCommand.Parameters.Add("@PMACPTANODRSTATUS", SqlDbType.Int);
//				SqlParameter paraPMSalesSlipNum			= sqlCommand.Parameters.Add("@PMSALESSLIPNUM", SqlDbType.Int);
//				SqlParameter paraPMSalesRowNo			= sqlCommand.Parameters.Add("@PMSALESROWNO", SqlDbType.Int);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//				SqlParameter paraDtlTakeinDivCd			= sqlCommand.Parameters.Add("@DTLTAKEINDIVCD", SqlDbType.Int);
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
//				#endregion
				#endregion

				#region Parameterオブジェクトへ値設定
				paraCreateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtInqWork.CreateDateTime);
				paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtInqWork.UpdateDateTime);
				paraLogicalDeleteCode.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.LogicalDeleteCode);
				paraInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);
				paraInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);
				paraInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);
				paraInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);
				paraInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);
				paraUpdateDate.Value			= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtInqWork.UpdateDate);
				paraUpdateTime.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.UpdateTime);
				paraInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);
				paraInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);
				paraInqOrgDtlDiscGuid.Value		= SqlDataMediator.SqlSetGuid(scmOdDtInqWork.InqOrgDtlDiscGuid);
				paraInqOthDtlDiscGuid.Value		= SqlDataMediator.SqlSetGuid(scmOdDtInqWork.InqOthDtlDiscGuid);
				paraGoodsDivCd.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.GoodsDivCd);
				paraRecyclePrtKindCode.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.RecyclePrtKindCode);
				paraRecyclePrtKindName.Value	= SqlDataMediator.SqlSetString(scmOdDtInqWork.RecyclePrtKindName);
				paraDeliveredGoodsDiv.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.DeliveredGoodsDiv);
				paraHandleDivCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.HandleDivCode);
				paraGoodsShape.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.GoodsShape);
				paraDelivrdGdsConfCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.DelivrdGdsConfCd);
				paraDeliGdsCmpltDueDate.Value	= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtInqWork.DeliGdsCmpltDueDate);
				paraAnswerDeliveryDate.Value	= SqlDataMediator.SqlSetString(scmOdDtInqWork.AnswerDeliveryDate);
				paraBLGoodsCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.BLGoodsCode);
				paraBLGoodsDrCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.BLGoodsDrCode);
				paraInqGoodsName.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqGoodsName);
				paraAnsGoodsName.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.AnsGoodsName);
				paraSalesOrderCount.Value		= SqlDataMediator.SqlSetDouble(scmOdDtInqWork.SalesOrderCount);
				paraDeliveredGoodsCount.Value	= SqlDataMediator.SqlSetDouble(scmOdDtInqWork.DeliveredGoodsCount);
				paraGoodsNo.Value				= SqlDataMediator.SqlSetString(scmOdDtInqWork.GoodsNo);
				paraGoodsMakerCd.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.GoodsMakerCd);
				paraGoodsMakerNm.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.GoodsMakerNm);
				paraPureGoodsMakerCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.PureGoodsMakerCd);
				paraInqPureGoodsNo.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqPureGoodsNo);
				paraAnsPureGoodsNo.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.AnsPureGoodsNo);
				paraListPrice.Value				= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.ListPrice);
				paraUnitPrice.Value				= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.UnitPrice);
				paraGoodsAddInfo.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.GoodsAddInfo);
				paraRoughRrofit.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.RoughRrofit);
				paraRoughRate.Value				= SqlDataMediator.SqlSetDouble(scmOdDtInqWork.RoughRate);
				paraAnswerLimitDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtInqWork.AnswerLimitDate);
				paraCommentDtl.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.CommentDtl);
				paraShelfNo.Value				= SqlDataMediator.SqlSetString(scmOdDtInqWork.ShelfNo);
				paraAdditionalDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.AdditionalDivCd);
				paraCorrectDivCD.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.CorrectDivCD);
				paraInqOrdDivCd.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqOrdDivCd);
				paraDisplayOrder.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.DisplayOrder);
				paraLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(scmOdDtInqWork.LatestDiscCode);
////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
				paraCancelCndtinDiv.Value		= SqlDataMediator.SqlSetInt16(scmOdDtInqWork.CancelCndtinDiv);
				paraPMAcptAnOdrStatus.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.PMAcptAnOdrStatus);
				paraPMSalesSlipNum.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.PMSalesSlipNum);
				paraPMSalesRowNo.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.PMSalesRowNo);
// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
				paraDtlTakeinDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.DtlTakeinDivCd);
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				paraPmWarehouseCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.PmWarehouseCd);
				paraPmWarehouseName.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.PmWarehouseName);
				paraPmShelfNo.Value				= SqlDataMediator.SqlSetString(scmOdDtInqWork.PmShelfNo);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
                ////////////////////////////////////////////// 2011.08.10 huangqb ADD STA //
                paraPmPrsntCount.Value          = SqlDataMediator.SqlSetDouble(scmOdDtInqWork.PmPrsntCount);
                paraSetPartsMkrCd.Value         = SqlDataMediator.SqlSetInt32(scmOdDtInqWork.SetPartsMkrCd);
                paraSetPartsNumber.Value        = SqlDataMediator.SqlSetString(scmOdDtInqWork.SetPartsNumber);
                paraSetPartsMainSubNo.Value     = SqlDataMediator.SqlSetInt32(scmOdDtInqWork.SetPartsMainSubNo);
                // 2011.08.10 huangqb ADD END //////////////////////////////////////////////
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

            // ADD by zhangw on 2011.08.03 For PCC_UOE STA
            // 受発注種別が1:PCC-UOEの場合
            if (acceptOrOrderKin == 1)
            {
            // 更新完了後、親データ関連の子データの削除。
            foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkList)
            {
                status = DeleteLatestDiscCodeProc(scmOdDtInqWork, sqlConnection, sqlTransaction);
            }
            }
            // ADD by zhangw on 2011.08.03 For PCC_UOE END

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注明細データ（問合せ・発注）最新識別区分更新処理
	/// </summary>
	/// <param name="scmOdDtInqWork">受発注明細データ（問合せ・発注）</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注明細データ（問合せ・発注）の最新識別区分を1:旧データにUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region UpdateLatestDiscCodeProc
	private int UpdateLatestDiscCodeProc(ScmOdDtInqWork scmOdDtInqWork, DateTime updateDate, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// 最新識別フラグ
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODDTINQRF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter findParaInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			SqlParameter findParaInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter findParaInqRowNumber		= sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);
			SqlParameter findParaInqRowNumDerivedNo	= sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);
			SqlParameter findParaLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);

			//Parameterオブジェクトへ値設定
			findParaInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);
			findParaInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);
			findParaInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);
			findParaInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);
			findParaInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);
			findParaInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);
			findParaInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);
			findParaLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				DateTime exclusionUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// 更新日時
				if (exclusionUpdateDateTime > updateDate)
				{
					// 更新日時が新しい場合は排他
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					return status;
				}

				// Updateコマンドの生成
				sqlCommand.CommandText = "UPDATE SCMODDTINQRF SET UPDATEDATETIMERF=@UPDATEDATETIME , LATESTDISCCODERF=@LATESTDISCCODE";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

				// Keyデータ再設定
				findParaInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);
				findParaInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);
				findParaInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);
				findParaInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);
				findParaInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);
				findParaInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);
				findParaInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);
				findParaLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);

				if (!myReader.IsClosed) myReader.Close();

				#region Prameterオブジェクトの作成
				SqlParameter paraUpdateDateTime	= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraLatestDiscCode	= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(updateDate);
				paraLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(1);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

    // ADD by zhangw on 2011.08.03 For PCC_UOE STA
    /// <summary>
	/// SCM受発注データ登録処理（問合せ・発注）
	/// </summary>
	/// <param name="authenticateCode">認証コード</param>
	/// <param name="scmOdrDataWork">SCM受発注データ配列</param>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="isCheckDtlTakeinDivCd">データ登録時に明細取込区分のチェック有無[true:チェックする,false:チェックしない]</param>
	/// <param name="msgDiv">メッセージ区分[true:メッセージ有り,false:メッセージ無し]</param>
	/// <param name="errMsg">エラーメッセージ</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの登録処理を行います。</br>
	/// <br>			: SCM受発注データ[Insert]</br>
	/// <br>			: SCM受発注データ(車両情報)[Insert/Update]</br>
	/// <br>			: 受発注明細データ（問合せ・発注）[Insert]</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
    /// </remarks>
    [WebMethod]
    public int UpdateDisplayOrder(ref ScmOdDtInqWork[] scmOdDtInqWorkArray, out bool msgDiv, out string errMsg)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        msgDiv = false;
        errMsg = string.Empty;

        SqlConnection sqlConnection = null;
        SqlTransaction sqlTransaction = null;
        try
        {
            //コネクション生成
            sqlConnection = GetSCMConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // トランザクション開始
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkArray)
            {
                status = UpdateDisplayOrder(scmOdDtInqWork, ref sqlConnection, ref sqlTransaction);
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // コミット
                sqlTransaction.Commit();
            }
            else
            {
                // ロールバック
                sqlTransaction.Rollback();
            }
            
        }
        catch (SqlException ex)
        {
            msgDiv = true;
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                errMsg = "受発注データ（問合せ・発注）の登録処理中にタイムアウトが発生しました。";
            else
                errMsg = "受発注データ（問合せ・発注）の登録処理に失敗しました。";
            // ロールバック
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

            status = LogOutPut.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
        }
        catch (Exception ex)
        {
            msgDiv = true;
            errMsg = "受発注データ（問合せ・発注）の登録処理に失敗しました。";
            // ロールバック
            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            LogOutPut.WriteErrorLog(ex, errMsg, status);
        }
        finally
        {
            if (sqlTransaction.Connection != null)
                sqlTransaction.Dispose();

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        return status;
    }

    /// <summary>
    /// SCM受発注明細データ（問合せ・発注）最新識別区分更新処理
    /// </summary>
    /// <param name="scmOdDtInqWork">受発注明細データ（問合せ・発注）</param>
    /// <param name="sqlConnection">SqlConnectionクラス</param>
    /// <param name="sqlTransaction">SqlTransactionクラス</param>
    /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
    /// <remarks>
    /// <br>Note		: SCM受発注明細データ（問合せ・発注）最新識別区分更新処理を行います。</br>
    /// <br>Programmer	: zhangw</br>
    /// <br>Date		: 2011.08.03</br>
    /// </remarks>
    #region UpdateDisplayOrder
    private int UpdateDisplayOrder(ScmOdDtInqWork scmOdDtInqWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        SqlCommand sqlCommand = null;

        try
        {
            // Updateコマンドの生成
            sqlCommand = new SqlCommand("UPDATE SCMODDTINQRF SET DISPLAYORDERRF=@DISPLAYORDER", sqlConnection, sqlTransaction);
            // Where文の追加
            sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

            // タイムアウト時間設定
            sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaInquiryNumber = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
            SqlParameter findParaInqRowNumber = sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);
            SqlParameter findParaInqRowNumDerivedNo = sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);
            SqlParameter findParaDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
            SqlParameter findParaLatestDiscCode = sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);

            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);
            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);
            findParaInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);
            findParaInqRowNumber.Value = SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);
            findParaInqRowNumDerivedNo.Value = SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);
            findParaDisplayOrder.Value = SqlDataMediator.SqlSetInt32(scmOdDtInqWork.DisplayOrder);
            findParaLatestDiscCode.Value = SqlDataMediator.SqlSetInt16(0);

            sqlCommand.ExecuteNonQuery();


            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        finally
        {

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }

        return status;
    }
    #endregion

    /// <summary>
    /// SCM受発注明細データ（問合せ・発注）削除処理
    /// </summary>
    /// <param name="scmOdDtInqWork">受発注明細データ（問合せ・発注）</param>
    /// <param name="sqlConnection">SqlConnectionクラス</param>
    /// <param name="sqlTransaction">SqlTransactionクラス</param>
    /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
    /// <remarks>
    /// <br>Note		: SCM受発注明細データ（問合せ・発注）削除処理を行います。</br>
    /// <br>Programmer	: zhangw</br>
    /// <br>Date		: 2011.08.03</br>
    /// </remarks>
    #region DeleteLatestDiscCodeProc
    private int DeleteLatestDiscCodeProc(ScmOdDtInqWork scmOdDtInqWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        SqlCommand sqlCommand = null;

        try
        {
            // 最新識別フラグ
            // Selectコマンドの生成
            sqlCommand = sqlCommand = new SqlCommand("DELETE FROM SCMODDTINQRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND SETPARTSMKRCDRF=@FINDSETPARTSMKRCD AND SETPARTSNUMBERRF=@FINDSETPARTSNUMBER AND SETPARTSMAINSUBNORF<>0", sqlConnection, sqlTransaction);
            
            // タイムアウト時間設定
            sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaInquiryNumber = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
            SqlParameter findParaSetPartsMkrCd = sqlCommand.Parameters.Add("@FINDSETPARTSMKRCD", SqlDbType.Int);
            SqlParameter findParaSetPartsNumber = sqlCommand.Parameters.Add("@FINDSETPARTSNUMBER", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = scmOdDtInqWork.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = scmOdDtInqWork.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = scmOdDtInqWork.InqOtherEpCd;
            findParaInqOtherSecCd.Value = scmOdDtInqWork.InqOtherSecCd;
            findParaInquiryNumber.Value = scmOdDtInqWork.InquiryNumber;
            findParaSetPartsMkrCd.Value = scmOdDtInqWork.SetPartsMkrCd;
            findParaSetPartsNumber.Value = scmOdDtInqWork.SetPartsNumber;

            sqlCommand.ExecuteNonQuery();            

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        finally
        {
            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }

        return status;
    }
    #endregion
    // ADD by zhangw on 2011.08.03 For PCC_UOE END

	/// <summary>
	/// SCM受発注明細データ（回答）登録処理
	/// </summary>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="updateTime">更新時分秒ミリ秒</param>
	/// <param name="isCheckDtlTakeinDivCd">Insert前に明細取込区分のチェック有無[true:チェックする,false:チェックしない]</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 受発注明細データ（回答）のInsertを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region WriteScmOdDtAnsProc
	#region 2011.02.01 TERASAKA DEL STA
//	private int WriteScmOdDtAnsProc(ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, DateTime updateDate, int updateTime, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	#endregion
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
	private int WriteScmOdDtAnsProc(ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, DateTime updateDate, int updateTime, bool isCheckDtlTakeinDivCd, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlCommand sqlCommand = null;

		try
		{
			List<int> usedRowNumberList = null;
			Dictionary<int, int> rowNumberList = null;
			Dictionary<int, List<int>> derivedNoList = null;
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			//Insertコマンドの生成
			sqlCommand = new SqlCommand("INSERT INTO SCMODDTANSRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF, PMWAREHOUSECDRF, PMWAREHOUSENAMERF, "
				+ "PMSHELFNORF"
                + ",PMPRSNTCOUNTRF, SETPARTSMKRCDRF, SETPARTSNUMBERRF, SETPARTSMAINSUBNORF"         // ADD 2011/08/10 ------ >>>>>>
				+ ") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE, @CANCELCNDTINDIV, @PMACPTANODRSTATUS, @PMSALESSLIPNUM, @PMSALESROWNO, @DTLTAKEINDIVCD, @PMWAREHOUSECD, @PMWAREHOUSENAME, "
				+ "@PMSHELFNO"
                + ",@PMPRSNTCOUNTRF, @SETPARTSMKRCDRF, @SETPARTSNUMBERRF, @SETPARTSMAINSUBNORF"     // ADD 2011/08/10 ------ <<<<<<
				+ ")", sqlConnection, sqlTransaction);

			#region Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraInqOriginalEpCd		= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter paraInqOriginalSecCd		= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter paraInqOtherEpCd			= sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
			SqlParameter paraInqOtherSecCd			= sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
			SqlParameter paraInquiryNumber			= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter paraUpdateDate				= sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
			SqlParameter paraUpdateTime				= sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
			SqlParameter paraInqRowNumber			= sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);
			SqlParameter paraInqRowNumDerivedNo		= sqlCommand.Parameters.Add("@INQROWNUMDERIVEDNO", SqlDbType.Int);
			SqlParameter paraInqOrgDtlDiscGuid		= sqlCommand.Parameters.Add("@INQORGDTLDISCGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraInqOthDtlDiscGuid		= sqlCommand.Parameters.Add("@INQOTHDTLDISCGUID", SqlDbType.UniqueIdentifier);
			SqlParameter paraGoodsDivCd				= sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
			SqlParameter paraRecyclePrtKindCode		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDCODE", SqlDbType.Int);
			SqlParameter paraRecyclePrtKindName		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDNAME", SqlDbType.NVarChar);
			SqlParameter paraDeliveredGoodsDiv		= sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
			SqlParameter paraHandleDivCode			= sqlCommand.Parameters.Add("@HANDLEDIVCODE", SqlDbType.Int);
			SqlParameter paraGoodsShape				= sqlCommand.Parameters.Add("@GOODSSHAPE", SqlDbType.Int);
			SqlParameter paraDelivrdGdsConfCd		= sqlCommand.Parameters.Add("@DELIVRDGDSCONFCD", SqlDbType.Int);
			SqlParameter paraDeliGdsCmpltDueDate	= sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
			SqlParameter paraAnswerDeliveryDate		= sqlCommand.Parameters.Add("@ANSWERDELIVERYDATE", SqlDbType.NVarChar);
			SqlParameter paraBLGoodsCode			= sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
			SqlParameter paraBLGoodsDrCode			= sqlCommand.Parameters.Add("@BLGOODSDRCODE", SqlDbType.Int);
			SqlParameter paraInqGoodsName			= sqlCommand.Parameters.Add("@INQGOODSNAME", SqlDbType.NVarChar);
			SqlParameter paraAnsGoodsName			= sqlCommand.Parameters.Add("@ANSGOODSNAME", SqlDbType.NVarChar);
			SqlParameter paraSalesOrderCount		= sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
			SqlParameter paraDeliveredGoodsCount	= sqlCommand.Parameters.Add("@DELIVEREDGOODSCOUNT", SqlDbType.Float);
			SqlParameter paraGoodsNo				= sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
			SqlParameter paraGoodsMakerCd			= sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
			SqlParameter paraGoodsMakerNm			= sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
			SqlParameter paraPureGoodsMakerCd		= sqlCommand.Parameters.Add("@PUREGOODSMAKERCD", SqlDbType.Int);
			SqlParameter paraInqPureGoodsNo			= sqlCommand.Parameters.Add("@INQPUREGOODSNO", SqlDbType.NVarChar);
			SqlParameter paraAnsPureGoodsNo			= sqlCommand.Parameters.Add("@ANSPUREGOODSNO", SqlDbType.NVarChar);
			SqlParameter paraListPrice				= sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
			SqlParameter paraUnitPrice				= sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
			SqlParameter paraGoodsAddInfo			= sqlCommand.Parameters.Add("@GOODSADDINFO", SqlDbType.NVarChar);
			SqlParameter paraRoughRrofit			= sqlCommand.Parameters.Add("@ROUGHRROFIT", SqlDbType.BigInt);
			SqlParameter paraRoughRate				= sqlCommand.Parameters.Add("@ROUGHRATE", SqlDbType.Float);
			SqlParameter paraAnswerLimitDate		= sqlCommand.Parameters.Add("@ANSWERLIMITDATE", SqlDbType.Int);
			SqlParameter paraCommentDtl				= sqlCommand.Parameters.Add("@COMMENTDTL", SqlDbType.NVarChar);
			SqlParameter paraShelfNo				= sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
			SqlParameter paraAdditionalDivCd		= sqlCommand.Parameters.Add("@ADDITIONALDIVCD", SqlDbType.Int);
			SqlParameter paraCorrectDivCD			= sqlCommand.Parameters.Add("@CORRECTDIVCD", SqlDbType.Int);
			SqlParameter paraInqOrdDivCd			= sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
			SqlParameter paraDisplayOrder			= sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
			SqlParameter paraLatestDiscCode			= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
			SqlParameter paraCancelCndtinDiv		= sqlCommand.Parameters.Add("@CANCELCNDTINDIV", SqlDbType.SmallInt);
			SqlParameter paraPMAcptAnOdrStatus		= sqlCommand.Parameters.Add("@PMACPTANODRSTATUS", SqlDbType.Int);
			SqlParameter paraPMSalesSlipNum			= sqlCommand.Parameters.Add("@PMSALESSLIPNUM", SqlDbType.Int);
			SqlParameter paraPMSalesRowNo			= sqlCommand.Parameters.Add("@PMSALESROWNO", SqlDbType.Int);
			SqlParameter paraDtlTakeinDivCd			= sqlCommand.Parameters.Add("@DTLTAKEINDIVCD", SqlDbType.Int);
			SqlParameter paraPmWarehouseCd			= sqlCommand.Parameters.Add("@PMWAREHOUSECD", SqlDbType.NVarChar);
			SqlParameter paraPmWarehouseName		= sqlCommand.Parameters.Add("@PMWAREHOUSENAME", SqlDbType.NVarChar);
			SqlParameter paraPmShelfNo				= sqlCommand.Parameters.Add("@PMSHELFNO", SqlDbType.NVarChar);
            //--- ADD 2011/08/10  ------ >>>>>>
            SqlParameter paraPMPrsntCount           = sqlCommand.Parameters.Add("@PMPRSNTCOUNTRF", SqlDbType.NChar);                // PM現在庫数
            SqlParameter paraSetPartsMkrCd          = sqlCommand.Parameters.Add("@SETPARTSMKRCDRF", SqlDbType.NVarChar);            // セット部品メーカーコード
            SqlParameter paraSetPartsNumber         = sqlCommand.Parameters.Add("@SETPARTSNUMBERRF", SqlDbType.NVarChar);           // セット部品番号
            SqlParameter paraSetPartsMainSubNo      = sqlCommand.Parameters.Add("@SETPARTSMAINSUBNORF", SqlDbType.NChar);           // セット部品親子番号
            //--- ADD 2011/08/10  ------ <<<<<<
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			foreach (ScmOdDtAnsWork scmOdDtAnsWork in scmOdDtAnsWorkArray)
			{
				// 問合せ行番号が0未満の場合は採番する
				if (scmOdDtAnsWork.InqRowNumber <= 0)
				{
					if (rowNumberList == null) rowNumberList = new Dictionary<int, int>();

					if (rowNumberList.ContainsKey(scmOdDtAnsWork.InqRowNumber))
					{
						scmOdDtAnsWork.InqRowNumber = rowNumberList[scmOdDtAnsWork.InqRowNumber];
					}
					else
					{
						if (usedRowNumberList == null) usedRowNumberList = new List<int>();

						// 新しい行番号を取得する
						int inqRowNumber = GetNewInqRowNumber(ref usedRowNumberList, scmOdDtAnsWork.InqOriginalEpCd, scmOdDtAnsWork.InqOriginalSecCd, scmOdDtAnsWork.InquiryNumber, sqlConnection, sqlTransaction);
						if (inqRowNumber == 0) return status;

						rowNumberList.Add(scmOdDtAnsWork.InqRowNumber, inqRowNumber);

						// 行番号を書き換える
						scmOdDtAnsWork.InqRowNumber = inqRowNumber;
					}
				}

				// 問合せ行番号枝番が0未満の場合は採番する
				if (scmOdDtAnsWork.InqRowNumDerivedNo <= 0)
				{
					if (derivedNoList == null) derivedNoList = new Dictionary<int, List<int>>();

					List<int> usedDerivedNoList = null;
					if (derivedNoList.ContainsKey(scmOdDtAnsWork.InqRowNumber))
					{
						usedDerivedNoList = derivedNoList[scmOdDtAnsWork.InqRowNumber];
					}
					else
					{
						usedDerivedNoList = new List<int>();
						derivedNoList.Add(scmOdDtAnsWork.InqRowNumber, usedDerivedNoList);
					}

					// 新しい行番号枝番を取得する
					int inqRowNumDerivedNo = GetNewInqRowNumDerivedNo(ref usedDerivedNoList, scmOdDtAnsWork.InqOriginalEpCd, scmOdDtAnsWork.InqOriginalSecCd, scmOdDtAnsWork.InquiryNumber, scmOdDtAnsWork.InqRowNumber, sqlConnection, sqlTransaction);
					if (inqRowNumDerivedNo == 0) return status;

					// 行番号枝番を書き換える
					scmOdDtAnsWork.InqRowNumDerivedNo = inqRowNumDerivedNo;
				}
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
				if (isCheckDtlTakeinDivCd)
				{
					// データが既に問合せ先に取込済かのチェックを行い、取込済の場合は処理を終了する
					if (IsTakeInScmOdDtAns(scmOdDtAnsWork, sqlConnection, sqlTransaction))
					{
						status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
						return status;
					}
				}
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////

				// SCM受発注明細データ（回答）最新識別区分更新処理
				status = UpdateLatestDiscCodeProc(scmOdDtAnsWork, updateDate, sqlConnection, sqlTransaction);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
				
				// 登録ヘッダ情報を設定
				if (updateDate == DateTime.MinValue)
				{
					updateDate = DateTime.Now;
					updateTime = TDateTime.DateTimeToLongDate("HHMMSS", updateDate) * 1000 + updateDate.Millisecond;
				}
				scmOdDtAnsWork.CreateDateTime	= updateDate;
				scmOdDtAnsWork.UpdateDateTime	= updateDate;
				scmOdDtAnsWork.UpdateDate		= updateDate;
				scmOdDtAnsWork.UpdateTime		= updateTime;

				#region 2011.05.19 TERASAKA DEL STA
//				//Insertコマンドの生成
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////				sqlCommand = new SqlCommand("INSERT INTO SCMODDTANSRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE)", sqlConnection, sqlTransaction);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//				#region 2011.02.01 TERASAKA DEL STA
////////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
////				sqlCommand = new SqlCommand("INSERT INTO SCMODDTANSRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE, @CANCELCNDTINDIV, @PMACPTANODRSTATUS, @PMSALESSLIPNUM, @PMSALESROWNO)", sqlConnection, sqlTransaction);
////// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//				#endregion
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//				sqlCommand = new SqlCommand("INSERT INTO SCMODDTANSRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @INQUIRYNUMBER, @UPDATEDATE, @UPDATETIME, @INQROWNUMBER, @INQROWNUMDERIVEDNO, @INQORGDTLDISCGUID, @INQOTHDTLDISCGUID, @GOODSDIVCD, @RECYCLEPRTKINDCODE, @RECYCLEPRTKINDNAME, @DELIVEREDGOODSDIV, @HANDLEDIVCODE, @GOODSSHAPE, @DELIVRDGDSCONFCD, @DELIGDSCMPLTDUEDATE, @ANSWERDELIVERYDATE, @BLGOODSCODE, @BLGOODSDRCODE, @INQGOODSNAME, @ANSGOODSNAME, @SALESORDERCOUNT, @DELIVEREDGOODSCOUNT, @GOODSNO, @GOODSMAKERCD, @GOODSMAKERNM, @PUREGOODSMAKERCD, @INQPUREGOODSNO, @ANSPUREGOODSNO, @LISTPRICE, @UNITPRICE, @GOODSADDINFO, @ROUGHRROFIT, @ROUGHRATE, @ANSWERLIMITDATE, @COMMENTDTL, @SHELFNO, @ADDITIONALDIVCD, @CORRECTDIVCD, @INQORDDIVCD, @DISPLAYORDER, @LATESTDISCCODE, @CANCELCNDTINDIV, @PMACPTANODRSTATUS, @PMSALESSLIPNUM, @PMSALESROWNO, @DTLTAKEINDIVCD)", sqlConnection, sqlTransaction);
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
//				
//				#region Prameterオブジェクトの作成
//				SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
//				SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
//				SqlParameter paraInqOriginalEpCd		= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
//				SqlParameter paraInqOriginalSecCd		= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
//				SqlParameter paraInqOtherEpCd			= sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
//				SqlParameter paraInqOtherSecCd			= sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
//				SqlParameter paraInquiryNumber			= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
//				SqlParameter paraUpdateDate				= sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
//				SqlParameter paraUpdateTime				= sqlCommand.Parameters.Add("@UPDATETIME", SqlDbType.Int);
//				SqlParameter paraInqRowNumber			= sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);
//				SqlParameter paraInqRowNumDerivedNo		= sqlCommand.Parameters.Add("@INQROWNUMDERIVEDNO", SqlDbType.Int);
//				SqlParameter paraInqOrgDtlDiscGuid		= sqlCommand.Parameters.Add("@INQORGDTLDISCGUID", SqlDbType.UniqueIdentifier);
//				SqlParameter paraInqOthDtlDiscGuid		= sqlCommand.Parameters.Add("@INQOTHDTLDISCGUID", SqlDbType.UniqueIdentifier);
//				SqlParameter paraGoodsDivCd				= sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
//				SqlParameter paraRecyclePrtKindCode		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDCODE", SqlDbType.Int);
//				SqlParameter paraRecyclePrtKindName		= sqlCommand.Parameters.Add("@RECYCLEPRTKINDNAME", SqlDbType.NVarChar);
//				SqlParameter paraDeliveredGoodsDiv		= sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
//				SqlParameter paraHandleDivCode			= sqlCommand.Parameters.Add("@HANDLEDIVCODE", SqlDbType.Int);
//				SqlParameter paraGoodsShape				= sqlCommand.Parameters.Add("@GOODSSHAPE", SqlDbType.Int);
//				SqlParameter paraDelivrdGdsConfCd		= sqlCommand.Parameters.Add("@DELIVRDGDSCONFCD", SqlDbType.Int);
//				SqlParameter paraDeliGdsCmpltDueDate	= sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
//				SqlParameter paraAnswerDeliveryDate		= sqlCommand.Parameters.Add("@ANSWERDELIVERYDATE", SqlDbType.NVarChar);
//				SqlParameter paraBLGoodsCode			= sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
//				SqlParameter paraBLGoodsDrCode			= sqlCommand.Parameters.Add("@BLGOODSDRCODE", SqlDbType.Int);
//				SqlParameter paraInqGoodsName			= sqlCommand.Parameters.Add("@INQGOODSNAME", SqlDbType.NVarChar);
//				SqlParameter paraAnsGoodsName			= sqlCommand.Parameters.Add("@ANSGOODSNAME", SqlDbType.NVarChar);
//				SqlParameter paraSalesOrderCount		= sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
//				SqlParameter paraDeliveredGoodsCount	= sqlCommand.Parameters.Add("@DELIVEREDGOODSCOUNT", SqlDbType.Float);
//				SqlParameter paraGoodsNo				= sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
//				SqlParameter paraGoodsMakerCd			= sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
//				SqlParameter paraGoodsMakerNm			= sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
//				SqlParameter paraPureGoodsMakerCd		= sqlCommand.Parameters.Add("@PUREGOODSMAKERCD", SqlDbType.Int);
//				SqlParameter paraInqPureGoodsNo			= sqlCommand.Parameters.Add("@INQPUREGOODSNO", SqlDbType.NVarChar);
//				SqlParameter paraAnsPureGoodsNo			= sqlCommand.Parameters.Add("@ANSPUREGOODSNO", SqlDbType.NVarChar);
//				SqlParameter paraListPrice				= sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
//				SqlParameter paraUnitPrice				= sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
//				SqlParameter paraGoodsAddInfo			= sqlCommand.Parameters.Add("@GOODSADDINFO", SqlDbType.NVarChar);
//				SqlParameter paraRoughRrofit			= sqlCommand.Parameters.Add("@ROUGHRROFIT", SqlDbType.BigInt);
//				SqlParameter paraRoughRate				= sqlCommand.Parameters.Add("@ROUGHRATE", SqlDbType.Float);
//				SqlParameter paraAnswerLimitDate		= sqlCommand.Parameters.Add("@ANSWERLIMITDATE", SqlDbType.Int);
//				SqlParameter paraCommentDtl				= sqlCommand.Parameters.Add("@COMMENTDTL", SqlDbType.NVarChar);
//				SqlParameter paraShelfNo				= sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
//				SqlParameter paraAdditionalDivCd		= sqlCommand.Parameters.Add("@ADDITIONALDIVCD", SqlDbType.Int);
//				SqlParameter paraCorrectDivCD			= sqlCommand.Parameters.Add("@CORRECTDIVCD", SqlDbType.Int);
//				SqlParameter paraInqOrdDivCd			= sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);
//				SqlParameter paraDisplayOrder			= sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
//				SqlParameter paraLatestDiscCode			= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				SqlParameter paraCancelCndtinDiv		= sqlCommand.Parameters.Add("@CANCELCNDTINDIV", SqlDbType.SmallInt);
//				SqlParameter paraPMAcptAnOdrStatus		= sqlCommand.Parameters.Add("@PMACPTANODRSTATUS", SqlDbType.Int);
//				SqlParameter paraPMSalesSlipNum			= sqlCommand.Parameters.Add("@PMSALESSLIPNUM", SqlDbType.Int);
//				SqlParameter paraPMSalesRowNo			= sqlCommand.Parameters.Add("@PMSALESROWNO", SqlDbType.Int);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//				SqlParameter paraDtlTakeinDivCd			= sqlCommand.Parameters.Add("@DTLTAKEINDIVCD", SqlDbType.Int);
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
//				#endregion
				#endregion

				#region Parameterオブジェクトへ値設定
				paraCreateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtAnsWork.CreateDateTime);
				paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtAnsWork.UpdateDateTime);
				paraLogicalDeleteCode.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.LogicalDeleteCode);
				paraInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);
				paraInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);
				paraInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);
				paraInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);
				paraInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);
				paraUpdateDate.Value			= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtAnsWork.UpdateDate);
				paraUpdateTime.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.UpdateTime);
				paraInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);
				paraInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);
				paraInqOrgDtlDiscGuid.Value		= SqlDataMediator.SqlSetGuid(scmOdDtAnsWork.InqOrgDtlDiscGuid);
				paraInqOthDtlDiscGuid.Value		= SqlDataMediator.SqlSetGuid(scmOdDtAnsWork.InqOthDtlDiscGuid);
				paraGoodsDivCd.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.GoodsDivCd);
				paraRecyclePrtKindCode.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.RecyclePrtKindCode);
				paraRecyclePrtKindName.Value	= SqlDataMediator.SqlSetString(scmOdDtAnsWork.RecyclePrtKindName);
				paraDeliveredGoodsDiv.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.DeliveredGoodsDiv);
				paraHandleDivCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.HandleDivCode);
				paraGoodsShape.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.GoodsShape);
				paraDelivrdGdsConfCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.DelivrdGdsConfCd);
				paraDeliGdsCmpltDueDate.Value	= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtAnsWork.DeliGdsCmpltDueDate);
				paraAnswerDeliveryDate.Value	= SqlDataMediator.SqlSetString(scmOdDtAnsWork.AnswerDeliveryDate);
				paraBLGoodsCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.BLGoodsCode);
				paraBLGoodsDrCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.BLGoodsDrCode);
				paraInqGoodsName.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqGoodsName);
				paraAnsGoodsName.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.AnsGoodsName);
				paraSalesOrderCount.Value		= SqlDataMediator.SqlSetDouble(scmOdDtAnsWork.SalesOrderCount);
				paraDeliveredGoodsCount.Value	= SqlDataMediator.SqlSetDouble(scmOdDtAnsWork.DeliveredGoodsCount);
				paraGoodsNo.Value				= SqlDataMediator.SqlSetString(scmOdDtAnsWork.GoodsNo);
				paraGoodsMakerCd.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.GoodsMakerCd);
				paraGoodsMakerNm.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.GoodsMakerNm);
				paraPureGoodsMakerCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.PureGoodsMakerCd);
				paraInqPureGoodsNo.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqPureGoodsNo);
				paraAnsPureGoodsNo.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.AnsPureGoodsNo);
				paraListPrice.Value				= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.ListPrice);
				paraUnitPrice.Value				= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.UnitPrice);
				paraGoodsAddInfo.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.GoodsAddInfo);
				paraRoughRrofit.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.RoughRrofit);
				paraRoughRate.Value				= SqlDataMediator.SqlSetDouble(scmOdDtAnsWork.RoughRate);
				paraAnswerLimitDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtAnsWork.AnswerLimitDate);
				paraCommentDtl.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.CommentDtl);
				paraShelfNo.Value				= SqlDataMediator.SqlSetString(scmOdDtAnsWork.ShelfNo);
				paraAdditionalDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.AdditionalDivCd);
				paraCorrectDivCD.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.CorrectDivCD);
				paraInqOrdDivCd.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqOrdDivCd);
				paraDisplayOrder.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.DisplayOrder);
				paraLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(scmOdDtAnsWork.LatestDiscCode);
////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
				paraCancelCndtinDiv.Value		= SqlDataMediator.SqlSetInt16(scmOdDtAnsWork.CancelCndtinDiv);
				paraPMAcptAnOdrStatus.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.PMAcptAnOdrStatus);
				paraPMSalesSlipNum.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.PMSalesSlipNum);
				paraPMSalesRowNo.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.PMSalesRowNo);
// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
				paraDtlTakeinDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.DtlTakeinDivCd);
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				paraPmWarehouseCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.PmWarehouseCd);
				paraPmWarehouseName.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.PmWarehouseName);
				paraPmShelfNo.Value				= SqlDataMediator.SqlSetString(scmOdDtAnsWork.PmShelfNo);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
                //--- ADD 2011/08/10  ------ >>>>>>
                paraPMPrsntCount.Value          = SqlDataMediator.SqlSetDouble(scmOdDtAnsWork.PmPrsntCount);                    // PM現在庫数
                paraSetPartsMkrCd.Value         = SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.SetPartsMkrCd);                    // セット部品メーカーコード
                paraSetPartsNumber.Value        = SqlDataMediator.SqlSetString(scmOdDtAnsWork.SetPartsNumber);                  // セット部品番号
                paraSetPartsMainSubNo.Value     = SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.SetPartsMainSubNo);                // セット部品親子番号
                //--- ADD 2011/08/10  ------ <<<<<<
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注明細データ（回答）最新識別区分更新処理
	/// </summary>
	/// <param name="scmOdDtAnsWork">受発注明細データ（回答）</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注明細データ（回答）の最新識別区分を1:旧データにUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region UpdateLatestDiscCodeProc
	private int UpdateLatestDiscCodeProc(ScmOdDtAnsWork scmOdDtAnsWork, DateTime updateDate, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// 最新識別フラグ
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODDTANSRF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter findParaInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			SqlParameter findParaInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter findParaInqRowNumber		= sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);
			SqlParameter findParaInqRowNumDerivedNo	= sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);
			SqlParameter findParaLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);

			//Parameterオブジェクトへ値設定
			findParaInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);
			findParaInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);
			findParaInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);
			findParaInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);
			findParaInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);
			findParaInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);
			findParaInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);
			findParaLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				DateTime exclusionUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// 更新日時
				if (exclusionUpdateDateTime > updateDate)
				{
					// 更新日時が新しい場合は排他
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					return status;
				}

				// Updateコマンドの生成
				sqlCommand.CommandText = "UPDATE SCMODDTANSRF SET UPDATEDATETIMERF=@UPDATEDATETIME , LATESTDISCCODERF=@LATESTDISCCODE";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

				// Keyデータ再設定
				findParaInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);
				findParaInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);
				findParaInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);
				findParaInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);
				findParaInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);
				findParaInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);
				findParaInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);
				findParaLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);

				if (!myReader.IsClosed) myReader.Close();

				#region Prameterオブジェクトの作成
				SqlParameter paraUpdateDateTime	= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraLatestDiscCode	= sqlCommand.Parameters.Add("@LATESTDISCCODE", SqlDbType.SmallInt);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(updateDate);
				paraLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(1);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 問合せ行番号取得処理
	/// </summary>
	/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
	/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
	/// <param name="inquiryNumber">問合せ番号</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>問合せ行番号</returns>
	/// <remarks>
	/// <br>Note		: 新しい問合せ行番号を取得します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region GetNewInqRowNumber
	private int GetNewInqRowNumber(ref List<int> rowNumberList, string inqOriginalEpCd, string inqOriginalSecCd, long inquiryNumber, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int inqRowNumber = 0;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			int maxRowNumber = 0;
			if (rowNumberList == null) rowNumberList = new List<int>();

			if (rowNumberList.Count == 0)
			{
				// ----------------------------------------
				// 問合せの行番号を取得
				// ----------------------------------------
				// Selectコマンドの生成
				sqlCommand = new SqlCommand("SELECT INQROWNUMBERRF FROM SCMODDTINQRF", sqlConnection, sqlTransaction);
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER";

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				//Prameterオブジェクトの作成
				SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
				SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
				SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);

				//Parameterオブジェクトへ値設定
				findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(inqOriginalEpCd);
				findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(inqOriginalSecCd);
				findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(inquiryNumber);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					// 問合せ行番号
					int rowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));
					if (!rowNumberList.Contains(rowNumber))
					{
						rowNumberList.Add(rowNumber);
						maxRowNumber = Math.Max(maxRowNumber, rowNumber);
					}
				}
				if (!myReader.IsClosed) myReader.Close();

				// ----------------------------------------
				// 回答の行番号を取得
				// ----------------------------------------
				// Selectコマンドの生成
				sqlCommand.CommandText = "SELECT INQROWNUMBERRF FROM SCMODDTANSRF";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER";

				//Parameterオブジェクトへ値設定
				findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(inqOriginalEpCd);
				findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(inqOriginalSecCd);
				findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(inquiryNumber);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					// 問合せ行番号
					int rowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));
					if (!rowNumberList.Contains(rowNumber))
					{
						rowNumberList.Add(rowNumber);
						maxRowNumber = Math.Max(maxRowNumber, rowNumber);
					}
				}
				if (!myReader.IsClosed) myReader.Close();
			}
			else
			{
				foreach (int rowNumber in rowNumberList)
					maxRowNumber = Math.Max(maxRowNumber, rowNumber);
			}

			// ----------------------------------------
			// 新しい行番号を採番
			// ----------------------------------------
			// 新しい行番号が99以上 且つ 行数は99未満の場合
			if (maxRowNumber >= 99 && rowNumberList.Count < 99)
			{
				// 空番の最小値を取得
				foreach (int ix in rowNumberList)
				{
					if (!rowNumberList.Contains(ix + 1))
						maxRowNumber = Math.Min(maxRowNumber, ix);
				}
			}

			if (maxRowNumber < 99)
			{
				inqRowNumber = maxRowNumber + 1;
				rowNumberList.Add(inqRowNumber);
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return inqRowNumber;
	}
	#endregion

	/// <summary>
	/// 問合せ行番号枝番取得処理
	/// </summary>
	/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
	/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
	/// <param name="inquiryNumber">問合せ番号</param>
	/// <param name="inqRowNumber">問合せ行番号</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>問合せ行番号枝番</returns>
	/// <remarks>
	/// <br>Note		: 新しい問合せ行番号枝番を取得します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region GetNewInqRowNumDerivedNo
	private int GetNewInqRowNumDerivedNo(ref List<int> derivedNoList, string inqOriginalEpCd, string inqOriginalSecCd, long inquiryNumber, int inqRowNumber, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int inqRowNumDerivedNo = 0;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			int maxDerivedNo = 0;
			if (derivedNoList == null) derivedNoList = new List<int>();

			if (derivedNoList.Count == 0)
			{
				// ----------------------------------------
				// 問合せの行番号枝番を取得
				// ----------------------------------------
				// Selectコマンドの生成
				sqlCommand = new SqlCommand("SELECT INQROWNUMDERIVEDNORF FROM SCMODDTINQRF", sqlConnection, sqlTransaction);
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@INQROWNUMBER";

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				//Prameterオブジェクトの作成
				SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
				SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
				SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
				SqlParameter findParaInqRowNumber		= sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(inqOriginalEpCd);
				findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(inqOriginalSecCd);
				findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(inquiryNumber);
				findParaInqRowNumber.Value		= SqlDataMediator.SqlSetInt(inqRowNumber);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					// 問合せ行番号
					int rowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));
					if (!derivedNoList.Contains(rowNumDerivedNo))
					{
						derivedNoList.Add(rowNumDerivedNo);
						maxDerivedNo = Math.Max(maxDerivedNo, rowNumDerivedNo);
					}
				}
				if (!myReader.IsClosed) myReader.Close();

				// ----------------------------------------
				// 回答の行番号枝番を取得
				// ----------------------------------------
				// Selectコマンドの生成
				sqlCommand.CommandText = "SELECT INQROWNUMDERIVEDNORF FROM SCMODDTANSRF";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@INQROWNUMBER";

				//Parameterオブジェクトへ値設定
				findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(inqOriginalEpCd);
				findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(inqOriginalSecCd);
				findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(inquiryNumber);
				findParaInqRowNumber.Value		= SqlDataMediator.SqlSetInt(inqRowNumber);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					// 問合せ行番号
					int rowNumDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));
					if (!derivedNoList.Contains(rowNumDerivedNo))
					{
						derivedNoList.Add(rowNumDerivedNo);
						maxDerivedNo = Math.Max(maxDerivedNo, rowNumDerivedNo);
					}
				}
				if (!myReader.IsClosed) myReader.Close();
			}
			else
			{
				foreach (int derivedNo in derivedNoList)
					maxDerivedNo = Math.Max(maxDerivedNo, derivedNo);
			}

			// ----------------------------------------
			// 新しい行番号枝番を採番
			// ----------------------------------------
			// 新しい行番号が99以上 且つ 行数は99未満の場合
			if (maxDerivedNo >= 99 && derivedNoList.Count < 99)
			{
				// 空番の最小値を取得
				foreach (int ix in derivedNoList)
				{
					if (!derivedNoList.Contains(ix + 1))
						maxDerivedNo = Math.Min(maxDerivedNo, ix);
				}
			}

			if (maxDerivedNo < 99)
			{
				inqRowNumDerivedNo = maxDerivedNo + 1;
				derivedNoList.Add(inqRowNumDerivedNo);
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return inqRowNumDerivedNo;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ(車両情報)登録処理
	/// </summary>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="updateDate">更新年月日</param>
	/// <param name="updateTime">更新時分秒ミリ秒</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データ(車両情報)のInsert/Updateを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region WriteScmOdDtCarProc
	private int WriteScmOdDtCarProc(ref ScmOdDtCarWork scmOdDtCarWork, DateTime updateDate, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODDTCARRF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);

			//Parameterオブジェクトへ値設定
			findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalEpCd);
			findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalSecCd);
			findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdDtCarWork.InquiryNumber);

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				// ☆☆☆ 更新モード ☆☆☆

				// 更新日時が異なる場合は排他エラーで戻す
				DateTime exclusionUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// 更新日時
				if (exclusionUpdateDateTime != scmOdDtCarWork.UpdateDateTime)
				{
					// 新規登録で該当データ有りの場合には重複
					if (scmOdDtCarWork.UpdateDateTime == DateTime.MinValue)
						status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
					// 既存データで更新日時違いの場合には排他
					else
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					return status;
				}

				// Updateコマンドの生成
                //sqlCommand.CommandText = "UPDATE SCMODDTCARRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , LOGICALDELETECODERF=@LOGICALDELETECODE , INQORIGINALEPCDRF=@INQORIGINALEPCD , INQORIGINALSECCDRF=@INQORIGINALSECCD , INQUIRYNUMBERRF=@INQUIRYNUMBER , NUMBERPLATE1CODERF=@NUMBERPLATE1CODE , NUMBERPLATE1NAMERF=@NUMBERPLATE1NAME , NUMBERPLATE2RF=@NUMBERPLATE2 , NUMBERPLATE3RF=@NUMBERPLATE3 , NUMBERPLATE4RF=@NUMBERPLATE4 , MODELDESIGNATIONNORF=@MODELDESIGNATIONNO , CATEGORYNORF=@CATEGORYNO , MAKERCODERF=@MAKERCODE , MODELCODERF=@MODELCODE , MODELSUBCODERF=@MODELSUBCODE , MODELNAMERF=@MODELNAME , CARINSPECTCERTMODELRF=@CARINSPECTCERTMODEL , FULLMODELRF=@FULLMODEL , FRAMENORF=@FRAMENO , FRAMEMODELRF=@FRAMEMODEL , CHASSISNORF=@CHASSISNO , CARPROPERNORF=@CARPROPERNO , PRODUCETYPEOFYEARNUMRF=@PRODUCETYPEOFYEARNUM , COMMENTRF=@COMMENT , RPCOLORCODERF=@RPCOLORCODE , COLORNAME1RF=@COLORNAME1 , TRIMCODERF=@TRIMCODE , TRIMNAMERF=@TRIMNAME , MILEAGERF=@MILEAGE , EQUIPOBJRF=@EQUIPOBJ"; //2011.08.10 Del
                sqlCommand.CommandText = "UPDATE SCMODDTCARRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , LOGICALDELETECODERF=@LOGICALDELETECODE , INQORIGINALEPCDRF=@INQORIGINALEPCD , INQORIGINALSECCDRF=@INQORIGINALSECCD , INQUIRYNUMBERRF=@INQUIRYNUMBER , NUMBERPLATE1CODERF=@NUMBERPLATE1CODE , NUMBERPLATE1NAMERF=@NUMBERPLATE1NAME , NUMBERPLATE2RF=@NUMBERPLATE2 , NUMBERPLATE3RF=@NUMBERPLATE3 , NUMBERPLATE4RF=@NUMBERPLATE4 , MODELDESIGNATIONNORF=@MODELDESIGNATIONNO , CATEGORYNORF=@CATEGORYNO , MAKERCODERF=@MAKERCODE , MODELCODERF=@MODELCODE , MODELSUBCODERF=@MODELSUBCODE , MODELNAMERF=@MODELNAME , CARINSPECTCERTMODELRF=@CARINSPECTCERTMODEL , FULLMODELRF=@FULLMODEL , FRAMENORF=@FRAMENO , FRAMEMODELRF=@FRAMEMODEL , CHASSISNORF=@CHASSISNO , CARPROPERNORF=@CARPROPERNO , PRODUCETYPEOFYEARNUMRF=@PRODUCETYPEOFYEARNUM , COMMENTRF=@COMMENT , RPCOLORCODERF=@RPCOLORCODE , COLORNAME1RF=@COLORNAME1 , TRIMCODERF=@TRIMCODE , TRIMNAMERF=@TRIMNAME , MILEAGERF=@MILEAGE , EQUIPOBJRF=@EQUIPOBJ , CARNORF=@CARNO , MAKERNAMERF=@MAKERNAME , GRADENAMERF=@GRADENAME , BODYNAMERF=@BODYNAME , DOORCOUNTRF=@DOORCOUNT , ENGINEMODELNMRF=@ENGINEMODELNM , CMNNMENGINEDISPLACERF=@CMNNMENGINEDISPLACE , ENGINEMODELRF=@ENGINEMODEL , NUMBEROFGEARRF=@NUMBEROFGEAR , GEARNMRF=@GEARNM , EDIVNMRF=@EDIVNM , TRANSMISSIONNMRF=@TRANSMISSIONNMRF , SHIFTNMRF=@SHIFTNMRF"; //2011.08.10 Add
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER";
				
				// Keyデータ再設定
				findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalEpCd);
				findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalSecCd);
				findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdDtCarWork.InquiryNumber);

				// 更新ヘッダ情報を設定
				scmOdDtCarWork.UpdateDateTime	= updateDate;
			}
			else
			{
				// ☆☆☆ 新規モード ☆☆☆

				// 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
				if (scmOdDtCarWork.UpdateDateTime > DateTime.MinValue)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					return status;
				}

				// Insertコマンドの生成
                //sqlCommand.CommandText = "INSERT INTO SCMODDTCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQUIRYNUMBERRF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MODELDESIGNATIONNORF, CATEGORYNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELNAMERF, CARINSPECTCERTMODELRF, FULLMODELRF, FRAMENORF, FRAMEMODELRF, CHASSISNORF, CARPROPERNORF, PRODUCETYPEOFYEARNUMRF, COMMENTRF, RPCOLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, EQUIPOBJRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQUIRYNUMBER, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @MODELDESIGNATIONNO, @CATEGORYNO, @MAKERCODE, @MODELCODE, @MODELSUBCODE, @MODELNAME, @CARINSPECTCERTMODEL, @FULLMODEL, @FRAMENO, @FRAMEMODEL, @CHASSISNO, @CARPROPERNO, @PRODUCETYPEOFYEARNUM, @COMMENT, @RPCOLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @EQUIPOBJ)"; //2011.08.10 Del
                sqlCommand.CommandText = "INSERT INTO SCMODDTCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQUIRYNUMBERRF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MODELDESIGNATIONNORF, CATEGORYNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELNAMERF, CARINSPECTCERTMODELRF, FULLMODELRF, FRAMENORF, FRAMEMODELRF, CHASSISNORF, CARPROPERNORF, PRODUCETYPEOFYEARNUMRF, COMMENTRF, RPCOLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, EQUIPOBJRF, CARNORF, MAKERNAMERF, GRADENAMERF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, CMNNMENGINEDISPLACERF, ENGINEMODELRF, NUMBEROFGEARRF, GEARNMRF, EDIVNMRF, TRANSMISSIONNMRF, SHIFTNMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQUIRYNUMBER, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @MODELDESIGNATIONNO, @CATEGORYNO, @MAKERCODE, @MODELCODE, @MODELSUBCODE, @MODELNAME, @CARINSPECTCERTMODEL, @FULLMODEL, @FRAMENO, @FRAMEMODEL, @CHASSISNO, @CARPROPERNO, @PRODUCETYPEOFYEARNUM, @COMMENT, @RPCOLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @EQUIPOBJ, @CARNO, @MAKERNAME, @GRADENAME, @BODYNAME, @DOORCOUNT, @ENGINEMODELNM, @CMNNMENGINEDISPLACE, @ENGINEMODEL, @NUMBEROFGEAR, @GEARNM, @EDIVNM, @TRANSMISSIONNMRF, @SHIFTNMRF)"; //2011.08.10 Add

				// 登録ヘッダ情報を設定
				scmOdDtCarWork.CreateDateTime	= updateDate;
				scmOdDtCarWork.UpdateDateTime	= updateDate;
			}
			if (!myReader.IsClosed) myReader.Close();

			#region Prameterオブジェクトの作成
			SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
			SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
			SqlParameter paraInqOriginalEpCd		= sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter paraInqOriginalSecCd		= sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter paraInquiryNumber			= sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter paraNumberPlate1Code		= sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);
			SqlParameter paraNumberPlate1Name		= sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);
			SqlParameter paraNumberPlate2			= sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);
			SqlParameter paraNumberPlate3			= sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);
			SqlParameter paraNumberPlate4			= sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);
			SqlParameter paraModelDesignationNo		= sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);
			SqlParameter paraCategoryNo				= sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);
			SqlParameter paraMakerCode				= sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
			SqlParameter paraModelCode				= sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
			SqlParameter paraModelSubCode			= sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
			SqlParameter paraModelName				= sqlCommand.Parameters.Add("@MODELNAME", SqlDbType.NVarChar);
			SqlParameter paraCarInspectCertModel	= sqlCommand.Parameters.Add("@CARINSPECTCERTMODEL", SqlDbType.NVarChar);
			SqlParameter paraFullModel				= sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);
			SqlParameter paraFrameNo				= sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);
			SqlParameter paraFrameModel				= sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);
			SqlParameter paraChassisNo				= sqlCommand.Parameters.Add("@CHASSISNO", SqlDbType.NVarChar);
			SqlParameter paraCarProperNo			= sqlCommand.Parameters.Add("@CARPROPERNO", SqlDbType.Int);
			SqlParameter paraProduceTypeOfYearNum	= sqlCommand.Parameters.Add("@PRODUCETYPEOFYEARNUM", SqlDbType.Int);
			SqlParameter paraComment				= sqlCommand.Parameters.Add("@COMMENT", SqlDbType.NVarChar);
			SqlParameter paraRpColorCode			= sqlCommand.Parameters.Add("@RPCOLORCODE", SqlDbType.NVarChar);
			SqlParameter paraColorName1				= sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);
			SqlParameter paraTrimCode				= sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);
			SqlParameter paraTrimName				= sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);
			SqlParameter paraMileage				= sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);
			SqlParameter paraEquipObj				= sqlCommand.Parameters.Add("@EQUIPOBJ", SqlDbType.VarBinary);
            ////////////////////////////////////////////// 2011.08.10 huangqb ADD STA //
            SqlParameter paraCarNo                  = sqlCommand.Parameters.Add("@CARNO", SqlDbType.NVarChar);
            SqlParameter paraMakerName              = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
            SqlParameter paraGradeName              = sqlCommand.Parameters.Add("@GRADENAME", SqlDbType.NVarChar);
            SqlParameter paraBodyName               = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);
            SqlParameter paraDoorCount              = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);
            SqlParameter paraEngineModelNm          = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);
            SqlParameter paraCmnNmEngineDisPlace    = sqlCommand.Parameters.Add("@CMNNMENGINEDISPLACE", SqlDbType.Int);
            SqlParameter paraEngineModel            = sqlCommand.Parameters.Add("@ENGINEMODEL", SqlDbType.NVarChar);
            SqlParameter paraNumberOfGear           = sqlCommand.Parameters.Add("@NUMBEROFGEAR", SqlDbType.Int);
            SqlParameter paraGearNm                 = sqlCommand.Parameters.Add("@GEARNM", SqlDbType.NVarChar);
            SqlParameter paraEDivNm                 = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);
            SqlParameter parTransmissionNm          = sqlCommand.Parameters.Add("@TRANSMISSIONNMRF", SqlDbType.NVarChar);  // ミッション名称
            SqlParameter parShiftNm                 = sqlCommand.Parameters.Add("@SHIFTNMRF", SqlDbType.NVarChar);  // シフト名称
            // 2011.08.10 huangqb ADD END //////////////////////////////////////////////
			#endregion

			#region Parameterオブジェクトへ値設定
			paraCreateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtCarWork.CreateDateTime);
			paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtCarWork.UpdateDateTime);
			paraLogicalDeleteCode.Value		= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.LogicalDeleteCode);
			paraInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalEpCd);
			paraInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalSecCd);
			paraInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtCarWork.InquiryNumber);
			paraNumberPlate1Code.Value		= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.NumberPlate1Code);
			paraNumberPlate1Name.Value		= SqlDataMediator.SqlSetString(scmOdDtCarWork.NumberPlate1Name);
			paraNumberPlate2.Value			= SqlDataMediator.SqlSetString(scmOdDtCarWork.NumberPlate2);
			paraNumberPlate3.Value			= SqlDataMediator.SqlSetString(scmOdDtCarWork.NumberPlate3);
			paraNumberPlate4.Value			= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.NumberPlate4);
			paraModelDesignationNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.ModelDesignationNo);
			paraCategoryNo.Value			= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.CategoryNo);
			paraMakerCode.Value				= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.MakerCode);
			paraModelCode.Value				= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.ModelCode);
			paraModelSubCode.Value			= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.ModelSubCode);
			paraModelName.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.ModelName);
			paraCarInspectCertModel.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.CarInspectCertModel);
			paraFullModel.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.FullModel);
			paraFrameNo.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.FrameNo);
			paraFrameModel.Value			= SqlDataMediator.SqlSetString(scmOdDtCarWork.FrameModel);
			paraChassisNo.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.ChassisNo);
			paraCarProperNo.Value			= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.CarProperNo);
			paraProduceTypeOfYearNum.Value	= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.ProduceTypeOfYearNum);
			paraComment.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.Comment);
			paraRpColorCode.Value			= SqlDataMediator.SqlSetString(scmOdDtCarWork.RpColorCode);
			paraColorName1.Value			= SqlDataMediator.SqlSetString(scmOdDtCarWork.ColorName1);
			paraTrimCode.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.TrimCode);
			paraTrimName.Value				= SqlDataMediator.SqlSetString(scmOdDtCarWork.TrimName);
			paraMileage.Value				= SqlDataMediator.SqlSetInt32(scmOdDtCarWork.Mileage);
			paraEquipObj.Value				= SqlDataMediator.SqlSetBinary(scmOdDtCarWork.EquipObj);
            ////////////////////////////////////////////// 2011.08.10 huangqb ADD STA //
            paraCarNo.Value                 = SqlDataMediator.SqlSetString(scmOdDtCarWork.CarNo);
            paraMakerName.Value             = SqlDataMediator.SqlSetString(scmOdDtCarWork.MakerName);
            paraGradeName.Value             = SqlDataMediator.SqlSetString(scmOdDtCarWork.GradeName);
            paraBodyName.Value              = SqlDataMediator.SqlSetString(scmOdDtCarWork.BodyName);
            paraDoorCount.Value             = SqlDataMediator.SqlSetInt32(scmOdDtCarWork.DoorCount);
            paraEngineModelNm.Value         = SqlDataMediator.SqlSetString(scmOdDtCarWork.EngineModelNm);
            paraCmnNmEngineDisPlace.Value   = SqlDataMediator.SqlSetInt32(scmOdDtCarWork.CmnNmEngineDisPlace);
            paraEngineModel.Value           = SqlDataMediator.SqlSetString(scmOdDtCarWork.EngineModel);
            paraNumberOfGear.Value          = SqlDataMediator.SqlSetInt32(scmOdDtCarWork.NumberOfGear);
            paraGearNm.Value                = SqlDataMediator.SqlSetString(scmOdDtCarWork.GearNm);
            paraEDivNm.Value                = SqlDataMediator.SqlSetString(scmOdDtCarWork.EDivNm);
            parTransmissionNm.Value         = SqlDataMediator.SqlSetString(scmOdDtCarWork.TransmissionNm);  // ミッション名称
            parShiftNm.Value                = SqlDataMediator.SqlSetString(scmOdDtCarWork.ShiftNm);  // シフト名称
            // 2011.08.10 huangqb ADD END //////////////////////////////////////////////
			#endregion

			sqlCommand.ExecuteNonQuery();

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 受信日時更新処理
	/// </summary>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データの受信日時及び回答区分をUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region UpdateRcvDateTimeProc
	private int UpdateRcvDateTimeProc(ref ScmOdrDataWork[] scmOdrDataWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			DateTime updateDateTime = DateTime.Now;
			foreach (ScmOdrDataWork scmOdrDataWork in scmOdrDataWorkArray)
			{
				// Selectコマンドの生成
				sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODRDATARF", sqlConnection, sqlTransaction);
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND UPDATEDATERF=@FINDUPDATEDATE AND UPDATETIMERF=@FINDUPDATETIME";

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				//Prameterオブジェクトの作成
				SqlParameter paraInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
				SqlParameter paraInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
				SqlParameter paraInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
				SqlParameter paraInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
				SqlParameter paraInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
				SqlParameter paraUpdateDate			= sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
				SqlParameter paraUpdateTime			= sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);

				//Parameterオブジェクトへ値設定
				paraInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalEpCd);
				paraInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalSecCd);
				paraInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherEpCd);
				paraInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherSecCd);
				paraInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdrDataWork.InquiryNumber);
				paraUpdateDate.Value			= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdrDataWork.UpdateDate);
				paraUpdateTime.Value			= SqlDataMediator.SqlSetInt32(scmOdrDataWork.UpdateTime);

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					// ☆☆☆ 更新モード ☆☆☆

					// Updateコマンドの生成
					sqlCommand.CommandText = "UPDATE SCMODRDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , RECEIVEDATETIMERF=@RECEIVEDATETIME, ANSWERDIVCDRF=@ANSWERDIVCD";
					// Where文の追加
					sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND UPDATEDATERF=@FINDUPDATEDATE AND UPDATETIMERF=@FINDUPDATETIME";
					
					// Keyデータ再設定
					paraInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalEpCd);
					paraInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalSecCd);
					paraInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherEpCd);
					paraInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherSecCd);
					paraInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdrDataWork.InquiryNumber);
					paraUpdateDate.Value			= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdrDataWork.UpdateDate);
					paraUpdateTime.Value			= SqlDataMediator.SqlSetInt32(scmOdrDataWork.UpdateTime);

					// 更新ヘッダ情報を設定
					scmOdrDataWork.UpdateDateTime	= updateDateTime;
					// 受信日時を設定
					scmOdrDataWork.ReceiveDateTime	= updateDateTime;
				}
				else
				{
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
					// 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (scmOdrDataWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				if (!myReader.IsClosed) myReader.Close();

				#region Prameterオブジェクトの作成
				SqlParameter paraUpdateDateTime		= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraReceiveDateTime	= sqlCommand.Parameters.Add("@RECEIVEDATETIME", SqlDbType.BigInt);
				SqlParameter paraAnswerDivCd		= sqlCommand.Parameters.Add("@ANSWERDIVCD", SqlDbType.Int);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdrDataWork.UpdateDateTime);
				paraReceiveDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdrDataWork.ReceiveDateTime);
				paraAnswerDivCd.Value		= SqlDataMediator.SqlSetInt32(scmOdrDataWork.AnswerDivCd);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
	/// <summary>
	/// 排他チェック処理
	/// </summary>
	/// <param name="scmOdDtCarWork">SCM受発注データ(車両情報)</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データ(車両情報)データを使用して排他チェックを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region CheckExclusion
	private int CheckExclusion(ScmOdDtCarWork scmOdDtCarWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODDTCARRF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findParaInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter findParaInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter findParaInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);

			//Parameterオブジェクトへ値設定
			findParaInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalEpCd);
			findParaInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdDtCarWork.InqOriginalSecCd);
			findParaInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdDtCarWork.InquiryNumber);

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				// 更新日時が異なる場合は排他エラーで戻す
				DateTime exclusionUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// 更新日時
				if (exclusionUpdateDateTime != scmOdDtCarWork.UpdateDateTime)
				{
					// 新規登録で該当データ有りの場合には重複
					if (scmOdDtCarWork.UpdateDateTime == DateTime.MinValue)
						status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
					// 既存データで更新日時違いの場合には排他
					else
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
				}
			}
			else
			{
				// データが存在しない場合は排他
				status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 明細取込区分更新処理（問合せ・発注）
	/// </summary>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 受発注明細データ（問合せ・発注）の明細取込区分をUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region UpdateInqDtlTakeinDivCdProc
	private int UpdateInqDtlTakeinDivCdProc(ref ScmOdDtInqWork[] scmOdDtInqWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			DateTime updateDateTime = DateTime.Now;
			foreach (ScmOdDtInqWork scmOdDtInqWork in scmOdDtInqWorkArray)
			{
				// Selectコマンドの生成
				sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODDTINQRF", sqlConnection, sqlTransaction);
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND UPDATEDATERF=@FINDUPDATEDATE AND UPDATETIMERF=@FINDUPDATETIME AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO";

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				//Prameterオブジェクトの作成
				SqlParameter findInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);	// 問合せ元企業コード
				SqlParameter findInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);	// 問合せ元拠点コード
				SqlParameter findInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);		// 問合せ先企業コード
				SqlParameter findInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);		// 問合せ先拠点コード
				SqlParameter findInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);	// 問合せ番号
				SqlParameter findUpdateDate			= sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);			// 更新年月日
				SqlParameter findUpdateTime			= sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);			// 更新時分秒ミリ秒
				SqlParameter findInqRowNumber		= sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);		// 問合せ行番号
				SqlParameter findInqRowNumDerivedNo	= sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);	// 問合せ行番号枝番

				//Parameterオブジェクトへ値設定
				findInqOriginalEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);				// 問合せ元企業コード
				findInqOriginalSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);			// 問合せ元拠点コード
				findInqOtherEpCd.Value				= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);				// 問合せ先企業コード
				findInqOtherSecCd.Value				= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);				// 問合せ先拠点コード
				findInquiryNumber.Value				= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);				// 問合せ番号
				findUpdateDate.Value				= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtInqWork.UpdateDate);	// 更新年月日
				findUpdateTime.Value				= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.UpdateTime);					// 更新時分秒ミリ秒
				findInqRowNumber.Value				= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);					// 問合せ行番号
				findInqRowNumDerivedNo.Value		= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);			// 問合せ行番号枝番

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					// ☆☆☆ 更新モード ☆☆☆

					// Updateコマンドの生成
					sqlCommand.CommandText = "UPDATE SCMODDTINQRF SET UPDATEDATETIMERF = @UPDATEDATETIME , DTLTAKEINDIVCDRF = @DTLTAKEINDIVCD";
					// Where文の追加
					sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF = @FINDINQORIGINALEPCD AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND INQOTHEREPCDRF = @FINDINQOTHEREPCD AND INQOTHERSECCDRF = @FINDINQOTHERSECCD AND INQUIRYNUMBERRF = @FINDINQUIRYNUMBER AND UPDATEDATERF = @FINDUPDATEDATE AND UPDATETIMERF = @FINDUPDATETIME AND INQROWNUMBERRF = @FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF = @FINDINQROWNUMDERIVEDNO";
					
					// Keyデータ再設定
					findInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);				// 問合せ元企業コード
					findInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);			// 問合せ元拠点コード
					findInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);				// 問合せ先企業コード
					findInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);				// 問合せ先拠点コード
					findInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);				// 問合せ番号
					findUpdateDate.Value			= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtInqWork.UpdateDate);	// 更新年月日
					findUpdateTime.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.UpdateTime);					// 更新時分秒ミリ秒
					findInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);					// 問合せ行番号
					findInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);			// 問合せ行番号枝番

					scmOdDtInqWork.UpdateDateTime	= updateDateTime;
				}
				else
				{
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
					// 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (scmOdDtInqWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				if (!myReader.IsClosed) myReader.Close();

				#region Prameterオブジェクトの作成
				SqlParameter paraUpdateDateTime		= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraDtlTakeinDivCd		= sqlCommand.Parameters.Add("@DTLTAKEINDIVCD", SqlDbType.Int);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtInqWork.UpdateDateTime);
				paraDtlTakeinDivCd.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.DtlTakeinDivCd);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 明細取込区分更新処理（回答）
	/// </summary>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 受発注明細データ（回答）の明細取込区分をUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region UpdateAnsDtlTakeinDivCdProc
	private int UpdateAnsDtlTakeinDivCdProc(ref ScmOdDtAnsWork[] scmOdDtAnsWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			DateTime updateDateTime = DateTime.Now;
			foreach (ScmOdDtAnsWork scmOdDtAnsWork in scmOdDtAnsWorkArray)
			{
				// Selectコマンドの生成
				sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODDTANSRF", sqlConnection, sqlTransaction);
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND UPDATEDATERF=@FINDUPDATEDATE AND UPDATETIMERF=@FINDUPDATETIME AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO";

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				//Prameterオブジェクトの作成
				SqlParameter findInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);	// 問合せ元企業コード
				SqlParameter findInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);	// 問合せ元拠点コード
				SqlParameter findInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);		// 問合せ先企業コード
				SqlParameter findInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);		// 問合せ先拠点コード
				SqlParameter findInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);	// 問合せ番号
				SqlParameter findUpdateDate			= sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);			// 更新年月日
				SqlParameter findUpdateTime			= sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);			// 更新時分秒ミリ秒
				SqlParameter findInqRowNumber		= sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);		// 問合せ行番号
				SqlParameter findInqRowNumDerivedNo	= sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);	// 問合せ行番号枝番

				//Parameterオブジェクトへ値設定
				findInqOriginalEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);				// 問合せ元企業コード
				findInqOriginalSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);			// 問合せ元拠点コード
				findInqOtherEpCd.Value				= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);				// 問合せ先企業コード
				findInqOtherSecCd.Value				= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);				// 問合せ先拠点コード
				findInquiryNumber.Value				= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);				// 問合せ番号
				findUpdateDate.Value				= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtAnsWork.UpdateDate);	// 更新年月日
				findUpdateTime.Value				= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.UpdateTime);					// 更新時分秒ミリ秒
				findInqRowNumber.Value				= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);					// 問合せ行番号
				findInqRowNumDerivedNo.Value		= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);			// 問合せ行番号枝番

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					// ☆☆☆ 更新モード ☆☆☆

					// Updateコマンドの生成
					sqlCommand.CommandText = "UPDATE SCMODDTANSRF SET UPDATEDATETIMERF = @UPDATEDATETIME , DTLTAKEINDIVCDRF = @DTLTAKEINDIVCD";
					// Where文の追加
					sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF = @FINDINQORIGINALEPCD AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND INQOTHEREPCDRF = @FINDINQOTHEREPCD AND INQOTHERSECCDRF = @FINDINQOTHERSECCD AND INQUIRYNUMBERRF = @FINDINQUIRYNUMBER AND UPDATEDATERF = @FINDUPDATEDATE AND UPDATETIMERF = @FINDUPDATETIME AND INQROWNUMBERRF = @FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF = @FINDINQROWNUMDERIVEDNO";
					
					// Keyデータ再設定
					findInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);				// 問合せ元企業コード
					findInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);			// 問合せ元拠点コード
					findInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);				// 問合せ先企業コード
					findInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);				// 問合せ先拠点コード
					findInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);				// 問合せ番号
					findUpdateDate.Value			= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdDtAnsWork.UpdateDate);	// 更新年月日
					findUpdateTime.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.UpdateTime);					// 更新時分秒ミリ秒
					findInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);					// 問合せ行番号
					findInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);			// 問合せ行番号枝番

					scmOdDtAnsWork.UpdateDateTime	= updateDateTime;
				}
				else
				{
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
					// 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (scmOdDtAnsWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				if (!myReader.IsClosed) myReader.Close();

				#region Prameterオブジェクトの作成
				SqlParameter paraUpdateDateTime		= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraDtlTakeinDivCd		= sqlCommand.Parameters.Add("@DTLTAKEINDIVCD", SqlDbType.Int);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmOdDtAnsWork.UpdateDateTime);
				paraDtlTakeinDivCd.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.DtlTakeinDivCd);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 受発注明細データ（問合せ・発注）取込済チェック
	/// </summary>
	/// <param name="scmOdDtInqWork">受発注明細データ（問合せ・発注）</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>チェック結果[true:取込済,false:未取込]</returns>
	/// <remarks>
	/// <br>Note		: 受発注明細データ（問合せ・発注）が問合せ先に取込済となっていないかのチェックを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region IsTakeInScmOdDtInq
	private bool IsTakeInScmOdDtInq(ScmOdDtInqWork scmOdDtInqWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		bool isLock = false;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATERF, UPDATETIMERF, DTLTAKEINDIVCDRF FROM SCMODDTINQRF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);	// 問合せ元企業コード
			SqlParameter findInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);	// 問合せ元拠点コード
			SqlParameter findInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);		// 問合せ先企業コード
			SqlParameter findInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);		// 問合せ先拠点コード
			SqlParameter findInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);	// 問合せ番号
			SqlParameter findInqRowNumber		= sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);		// 問合せ行番号
			SqlParameter findInqRowNumDerivedNo	= sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);	// 問合せ行番号枝番
			SqlParameter findLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);	// 最新識別区分

			//Parameterオブジェクトへ値設定
			findInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);		// 問合せ元企業コード
			findInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);	// 問合せ元拠点コード
			findInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);		// 問合せ先企業コード
			findInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);		// 問合せ先拠点コード
			findInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);		// 問合せ番号
			findInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);			// 問合せ行番号
			findInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);	// 問合せ行番号枝番
			findLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);									// 最新識別区分

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				DateTime inqUpdateDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
				int inqUpdateTime		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
				int inqDtlTakeinDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLTAKEINDIVCDRF"));
				if (!myReader.IsClosed) myReader.Close();

				// Selectコマンドの生成
				sqlCommand.CommandText = "SELECT UPDATEDATERF, UPDATETIMERF FROM SCMODDTANSRF";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

				// Keyデータ再設定
				findInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalEpCd);		// 問合せ元企業コード
				findInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOriginalSecCd);	// 問合せ元拠点コード
				findInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherEpCd);		// 問合せ先企業コード
				findInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtInqWork.InqOtherSecCd);		// 問合せ先拠点コード
				findInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtInqWork.InquiryNumber);		// 問合せ番号
				findInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumber);			// 問合せ行番号
				findInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtInqWork.InqRowNumDerivedNo);	// 問合せ行番号枝番
				findLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);									// 最新識別区分

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					DateTime ansUpdateDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
					int ansUpdateTime		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
					// 受発注明細データの最新行が『問合せ・発注』で
					// 明細取込区分が取込済の場合ロックされているとする
					if ((inqUpdateDate > ansUpdateDate) ||
						(inqUpdateDate == ansUpdateDate && inqUpdateTime > ansUpdateTime))
					{
						if (inqDtlTakeinDivCd != 0) isLock = true;
					}
				}
				else
				{
					if (inqDtlTakeinDivCd != 0) isLock = true;
				}
				if (!myReader.IsClosed) myReader.Close();
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return isLock;
	}
	#endregion

	/// <summary>
	/// 受発注明細データ（回答）取込済チェック
	/// </summary>
	/// <param name="scmOdDtAnsWork">受発注明細データ（回答）</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>チェック結果[true:取込済,false:未取込]</returns>
	/// <remarks>
	/// <br>Note		: 受発注明細データ（回答）が問合せ元に取込済となっていないかのチェックを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.02.01</br>
	/// </remarks>
	#region IsTakeInScmOdDtAns
	private bool IsTakeInScmOdDtAns(ScmOdDtAnsWork scmOdDtAnsWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		bool isLock = false;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT UPDATEDATERF, UPDATETIMERF, DTLTAKEINDIVCDRF FROM SCMODDTANSRF", sqlConnection, sqlTransaction);
			// Where文の追加
			sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			//Prameterオブジェクトの作成
			SqlParameter findInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);	// 問合せ元企業コード
			SqlParameter findInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);	// 問合せ元拠点コード
			SqlParameter findInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);		// 問合せ先企業コード
			SqlParameter findInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);		// 問合せ先拠点コード
			SqlParameter findInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);	// 問合せ番号
			SqlParameter findInqRowNumber		= sqlCommand.Parameters.Add("@FINDINQROWNUMBER", SqlDbType.Int);		// 問合せ行番号
			SqlParameter findInqRowNumDerivedNo	= sqlCommand.Parameters.Add("@FINDINQROWNUMDERIVEDNO", SqlDbType.Int);	// 問合せ行番号枝番
			SqlParameter findLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);	// 最新識別区分

			//Parameterオブジェクトへ値設定
			findInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);		// 問合せ元企業コード
			findInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);	// 問合せ元拠点コード
			findInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);		// 問合せ先企業コード
			findInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);		// 問合せ先拠点コード
			findInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);		// 問合せ番号
			findInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);			// 問合せ行番号
			findInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);	// 問合せ行番号枝番
			findLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);									// 最新識別区分

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				DateTime ansUpdateDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
				int ansUpdateTime		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
				int ansDtlTakeinDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLTAKEINDIVCDRF"));
				if (!myReader.IsClosed) myReader.Close();

				// Selectコマンドの生成
				sqlCommand.CommandText = "SELECT UPDATEDATERF, UPDATETIMERF FROM SCMODDTINQRF";
				// Where文の追加
				sqlCommand.CommandText += " WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND INQROWNUMBERRF=@FINDINQROWNUMBER AND INQROWNUMDERIVEDNORF=@FINDINQROWNUMDERIVEDNO AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

				// Keyデータ再設定
				findInqOriginalEpCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalEpCd);		// 問合せ元企業コード
				findInqOriginalSecCd.Value		= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOriginalSecCd);	// 問合せ元拠点コード
				findInqOtherEpCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherEpCd);		// 問合せ先企業コード
				findInqOtherSecCd.Value			= SqlDataMediator.SqlSetString(scmOdDtAnsWork.InqOtherSecCd);		// 問合せ先拠点コード
				findInquiryNumber.Value			= SqlDataMediator.SqlSetInt64(scmOdDtAnsWork.InquiryNumber);		// 問合せ番号
				findInqRowNumber.Value			= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumber);			// 問合せ行番号
				findInqRowNumDerivedNo.Value	= SqlDataMediator.SqlSetInt32(scmOdDtAnsWork.InqRowNumDerivedNo);	// 問合せ行番号枝番
				findLatestDiscCode.Value		= SqlDataMediator.SqlSetInt16(0);									// 最新識別区分

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					DateTime inqUpdateDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
					int inqUpdateTime		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
					// 受発注明細データの最新行が『回答』で
					// 明細取込区分が取込済の場合ロックされているとする
					if ((ansUpdateDate > inqUpdateDate) ||
						(ansUpdateDate == inqUpdateDate && ansUpdateTime > inqUpdateTime))
					{
						if (ansDtlTakeinDivCd != 0) isLock = true;
					}
				}
				else
				{
					if (ansDtlTakeinDivCd != 0) isLock = true;
				}
				if (!myReader.IsClosed) myReader.Close();
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return isLock;
	}
	#endregion
// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////

////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
	/// <summary>
	/// 受発注データ確定済チェック
	/// </summary>
	/// <param name="scmOdrDataWork">受発注データ</param>
	/// <param name="isReadUnCommitted">READUNCOMMITTEDを指定するか[true:指定する,false:指定しない]</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>チェック結果[true:確定済,false:未確定]</returns>
	/// <remarks>
	/// <br>Note		: 受発注データが確定済となっていないかのチェックを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region IsScmOdrDataFixed
	private bool IsScmOdrDataFixed(ScmOdrDataWork scmOdrDataWork, bool isReadUnCommitted, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		bool isFixed = false;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			if (sqlTransaction != null)
				sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);
			else
				sqlCommand = new SqlCommand(string.Empty, sqlConnection);

			// Selectコマンドの生成
			if (isReadUnCommitted)
				sqlCommand.CommandText = "SELECT JUDGEMENTDATERF FROM SCMODRDATARF WITH(READUNCOMMITTED) WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND LATESTDISCCODERF=@FINDLATESTDISCCODE";
			else
				sqlCommand.CommandText = "SELECT JUDGEMENTDATERF FROM SCMODRDATARF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND LATESTDISCCODERF=@FINDLATESTDISCCODE";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			// Prameterオブジェクトの作成
			SqlParameter findInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			SqlParameter findInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			SqlParameter findInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			SqlParameter findInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			SqlParameter findInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
			SqlParameter findLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);

			// Parameterオブジェクトへ値設定
			findInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalEpCd);
			findInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOriginalSecCd);
			findInqOtherEpCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherEpCd);
			findInqOtherSecCd.Value		= SqlDataMediator.SqlSetString(scmOdrDataWork.InqOtherSecCd);
			findInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmOdrDataWork.InquiryNumber);
			findLatestDiscCode.Value	= SqlDataMediator.SqlSetInt16(0);

			myReader = sqlCommand.ExecuteReader();
			if (myReader.Read())
			{
				int judgementDate	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));
				if (judgementDate > 10101)
					isFixed = true;
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return isFixed;
	}
	#endregion

	/// <summary>
	/// 確定日更新処理
	/// </summary>
	/// <param name="mode">モード[0:確定日セット,1:確定日削除]</param>
	/// <param name="scmJudgeDtUpdParamWorkArray">SCM確定日更新パラメータ</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <param name="sqlTransaction">SqlTransactionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 受発注データの確定日をUpdateします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region UpdateJudgementDateProc
	private int UpdateJudgementDateProc(int mode, ref ScmJudgeDtUpdParamWork[] scmJudgeDtUpdParamWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;

		try
		{
			DateTime updateDateTime = DateTime.Now;

			foreach (ScmJudgeDtUpdParamWork scmJudgeDtUpdParamWork in scmJudgeDtUpdParamWorkArray)
			{
				// Selectコマンドの生成
				sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SCMODRDATARF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND UPDATEDATERF=@FINDUPDATEDATE AND UPDATETIMERF=@FINDUPDATETIME AND LATESTDISCCODERF=@FINDLATESTDISCCODE", sqlConnection, sqlTransaction);

				// タイムアウト時間設定
				sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

				// Prameterオブジェクトの作成
				SqlParameter findInqOriginalEpCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
				SqlParameter findInqOriginalSecCd	= sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
				SqlParameter findInqOtherEpCd		= sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
				SqlParameter findInqOtherSecCd		= sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
				SqlParameter findInquiryNumber		= sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
				SqlParameter findUpdateDate			= sqlCommand.Parameters.Add("@FINDUPDATEDATE", SqlDbType.Int);
				SqlParameter findUpdateTime			= sqlCommand.Parameters.Add("@FINDUPDATETIME", SqlDbType.Int);
				SqlParameter findLatestDiscCode		= sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.Int);

				// Parameterオブジェクトへ値設定
				findInqOriginalEpCd.Value	= SqlDataMediator.SqlSetString(scmJudgeDtUpdParamWork.InqOriginalEpCd);
				findInqOriginalSecCd.Value	= SqlDataMediator.SqlSetString(scmJudgeDtUpdParamWork.InqOriginalSecCd);
				findInqOtherEpCd.Value		= SqlDataMediator.SqlSetString(scmJudgeDtUpdParamWork.InqOtherEpCd);
				findInqOtherSecCd.Value		= SqlDataMediator.SqlSetString(scmJudgeDtUpdParamWork.InqOtherSecCd);
				findInquiryNumber.Value		= SqlDataMediator.SqlSetInt64(scmJudgeDtUpdParamWork.InquiryNumber);
				findUpdateDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmJudgeDtUpdParamWork.UpdateDate);
				findUpdateTime.Value		= SqlDataMediator.SqlSetInt32(scmJudgeDtUpdParamWork.UpdateTime);
				findLatestDiscCode.Value	= 0;

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					// ☆☆☆ 更新モード ☆☆☆

					// 更新日時が異なる場合は排他エラーで戻す ※更新日時がMinValueでの更新は許可する
					DateTime exclusionUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// 更新日時
					if (exclusionUpdateDateTime != scmJudgeDtUpdParamWork.UpdateDateTime &&
						scmJudgeDtUpdParamWork.UpdateDateTime > DateTime.MinValue)
					{
						// 既存データで更新日時違いの場合には排他
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

					// Updateコマンドの生成
					sqlCommand.CommandText = "UPDATE SCMODRDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME, JUDGEMENTDATERF=@JUDGEMENTDATE WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND INQUIRYNUMBERRF=@FINDINQUIRYNUMBER AND UPDATEDATERF=@FINDUPDATEDATE AND UPDATETIMERF=@FINDUPDATETIME";

					scmJudgeDtUpdParamWork.UpdateDateTime	= updateDateTime;
					if (mode == 1)
						scmJudgeDtUpdParamWork.JudgementDate = DateTime.MinValue;
					else
						scmJudgeDtUpdParamWork.JudgementDate = updateDateTime;
				}
				else
				{
					// 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
					if (scmJudgeDtUpdParamWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				if (!myReader.IsClosed) myReader.Close();

				#region Parameterオブジェクトの作成
				SqlParameter paraUpdateDateTime	= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraJudgementDate	= sqlCommand.Parameters.Add("@JUDGEMENTDATE", SqlDbType.Int);
				#endregion

				#region Parameterオブジェクトへ値設定
				paraUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(scmJudgeDtUpdParamWork.UpdateDateTime);
				paraJudgementDate.Value		= SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmJudgeDtUpdParamWork.JudgementDate);
				#endregion

				sqlCommand.ExecuteNonQuery();
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// 問合せ番号検索処理(指示書番号指定)
	/// </summary>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="inquiryNumberList">問合せ番号リスト</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 指示書番号より問合せ番号のリストをSELECTします。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2011.05.19</br>
	/// </remarks>
	#region SearchInquiryNumberFromInstSlipNo
	private int SearchInquiryNumberFromInstSlipNo(ScmOdReadParamWork scmOdReadParamWork, out List<long> inquiryNumberList, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			inquiryNumberList = new List<long>();

			sqlCommand = new SqlCommand(string.Empty, sqlConnection);

			sqlCommand.CommandText = "SELECT INQUIRYNUMBERRF FROM SCMODRDATARF"
				+ MakeWhereStringOfScmOdrData(0, scmOdReadParamWork, sqlCommand)
				+ " GROUP BY INQUIRYNUMBERRF";

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

			myReader = sqlCommand.ExecuteReader();
			#region カラムインデックスの取得
			int colIndex_InquiryNumber	= 0;

			if (myReader.HasRows)
			{
				colIndex_InquiryNumber	= myReader.GetOrdinal("INQUIRYNUMBERRF");
			}
			#endregion
			while (myReader.Read())
				inquiryNumberList.Add(SqlDataMediator.SqlGetInt64(myReader, colIndex_InquiryNumber));

			if (!myReader.IsClosed) myReader.Close();

			if (inquiryNumberList.Count > 0)
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

	/// <summary>
	/// SCM受発注データ読込処理
	/// </summary>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="scmOdrDataWorkArray">SCM受発注データ配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データのSelectを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region ReadScmOdrDataProc
	private int ReadScmOdrDataProc(ScmOdReadParamWork scmOdReadParamWork, out ScmOdrDataWork[] scmOdrDataWorkArray, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

		scmOdrDataWorkArray = null;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<ScmOdrDataWork> scmOdrDataWorkList = new List<ScmOdrDataWork>();

			// Selectコマンドの生成
			#region 2011.05.19 TERASAKA DEL STA
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, ANSWERDIVCDRF, JUDGEMENTDATERF, INQORDNOTERF, INQEMPLOYEECDRF, INQEMPLOYEENMRF, ANSEMPLOYEECDRF, ANSEMPLOYEENMRF, INQUIRYDATERF, INQORDDIVCDRF, INQORDANSDIVCDRF, RECEIVEDATETIMERF, LATESTDISCCODERF FROM SCMODRDATARF", sqlConnection);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, ANSWERDIVCDRF, JUDGEMENTDATERF, INQORDNOTERF, INQEMPLOYEECDRF, INQEMPLOYEENMRF, ANSEMPLOYEECDRF, ANSEMPLOYEENMRF, INQUIRYDATERF, INQORDDIVCDRF, INQORDANSDIVCDRF, RECEIVEDATETIMERF, LATESTDISCCODERF, CANCELDIVRF, CMTCOOPRTDIVRF FROM SCMODRDATARF", sqlConnection);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//			// Where文の追加
//			sqlCommand.CommandText += MakeWhereStringOfScmOdrData(0, scmOdReadParamWork, sqlCommand);
			#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			sqlCommand = new SqlCommand(string.Empty, sqlConnection);

			sqlCommand.CommandText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, ANSWERDIVCDRF, JUDGEMENTDATERF, INQORDNOTERF, INQEMPLOYEECDRF, INQEMPLOYEENMRF, ANSEMPLOYEECDRF, ANSEMPLOYEENMRF, INQUIRYDATERF, INQORDDIVCDRF, INQORDANSDIVCDRF, RECEIVEDATETIMERF, LATESTDISCCODERF, CANCELDIVRF, CMTCOOPRTDIVRF, "
				+ "SFPMCPRTINSTSLIPNORF"
                + ", ACCEPTORORDERKINDRF" //2011.08.10 Add
				+ " FROM SCMODRDATARF"
				+ MakeWhereStringOfScmOdrData(0, scmOdReadParamWork, sqlCommand);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
		
			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

			myReader = sqlCommand.ExecuteReader();
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			#region カラムインデックスの取得
			int colIndex_CreateDateTime		= 0;
			int colIndex_UpdateDateTime		= 0;
			int colIndex_LogicalDeleteCode	= 0;
			int colIndex_InqOriginalEpCd	= 0;
			int colIndex_InqOriginalSecCd	= 0;
			int colIndex_InqOtherEpCd		= 0;
			int colIndex_InqOtherSecCd		= 0;
			int colIndex_InquiryNumber		= 0;
			int colIndex_UpdateDate			= 0;
			int colIndex_UpdateTime			= 0;
			int colIndex_AnswerDivCd		= 0;
			int colIndex_JudgementDate		= 0;
			int colIndex_InqOrdNote			= 0;
			int colIndex_InqEmployeeCd		= 0;
			int colIndex_InqEmployeeNm		= 0;
			int colIndex_AnsEmployeeCd		= 0;
			int colIndex_AnsEmployeeNm		= 0;
			int colIndex_InquiryDate		= 0;
			int colIndex_InqOrdDivCd		= 0;
			int colIndex_InqOrdAnsDivCd		= 0;
			int colIndex_ReceiveDateTime	= 0;
			int colIndex_LatestDiscCode		= 0;
			int colIndex_CancelDiv			= 0;
			int colIndex_CMTCooprtDiv		= 0;
			int colIndex_SfPmCprtInstSlipNo	= 0;
            int colIndex_AcceptOrOrderKind  = 0; //2011.08.10 Add

			if (myReader.HasRows)
			{
				colIndex_CreateDateTime		= myReader.GetOrdinal("CREATEDATETIMERF");
				colIndex_UpdateDateTime		= myReader.GetOrdinal("UPDATEDATETIMERF");
				colIndex_LogicalDeleteCode	= myReader.GetOrdinal("LOGICALDELETECODERF");
				colIndex_InqOriginalEpCd	= myReader.GetOrdinal("INQORIGINALEPCDRF");
				colIndex_InqOriginalSecCd	= myReader.GetOrdinal("INQORIGINALSECCDRF");
				colIndex_InqOtherEpCd		= myReader.GetOrdinal("INQOTHEREPCDRF");
				colIndex_InqOtherSecCd		= myReader.GetOrdinal("INQOTHERSECCDRF");
				colIndex_InquiryNumber		= myReader.GetOrdinal("INQUIRYNUMBERRF");
				colIndex_UpdateDate			= myReader.GetOrdinal("UPDATEDATERF");
				colIndex_UpdateTime			= myReader.GetOrdinal("UPDATETIMERF");
				colIndex_AnswerDivCd		= myReader.GetOrdinal("ANSWERDIVCDRF");
				colIndex_JudgementDate		= myReader.GetOrdinal("JUDGEMENTDATERF");
				colIndex_InqOrdNote			= myReader.GetOrdinal("INQORDNOTERF");
				colIndex_InqEmployeeCd		= myReader.GetOrdinal("INQEMPLOYEECDRF");
				colIndex_InqEmployeeNm		= myReader.GetOrdinal("INQEMPLOYEENMRF");
				colIndex_AnsEmployeeCd		= myReader.GetOrdinal("ANSEMPLOYEECDRF");
				colIndex_AnsEmployeeNm		= myReader.GetOrdinal("ANSEMPLOYEENMRF");
				colIndex_InquiryDate		= myReader.GetOrdinal("INQUIRYDATERF");
				colIndex_InqOrdDivCd		= myReader.GetOrdinal("INQORDDIVCDRF");
				colIndex_InqOrdAnsDivCd		= myReader.GetOrdinal("INQORDANSDIVCDRF");
				colIndex_ReceiveDateTime	= myReader.GetOrdinal("RECEIVEDATETIMERF");
				colIndex_LatestDiscCode		= myReader.GetOrdinal("LATESTDISCCODERF");
				colIndex_CancelDiv			= myReader.GetOrdinal("CANCELDIVRF");
				colIndex_CMTCooprtDiv		= myReader.GetOrdinal("CMTCOOPRTDIVRF");
				colIndex_SfPmCprtInstSlipNo = myReader.GetOrdinal("SFPMCPRTINSTSLIPNORF");
                colIndex_AcceptOrOrderKind  = myReader.GetOrdinal("ACCEPTORORDERKINDRF"); //2011.08.10 Add
			}
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			while (myReader.Read())
			{
				ScmOdrDataWork scmOdrDataWork = new ScmOdrDataWork();

				#region データのコピー
				#region 2011.05.19 TERASAKA DEL STA
//				scmOdrDataWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
//				scmOdrDataWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
//				scmOdrDataWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
//				scmOdrDataWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
//				scmOdrDataWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
//				scmOdrDataWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
//				scmOdrDataWork.InqOtherSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
//				scmOdrDataWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
//				scmOdrDataWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
//				scmOdrDataWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
//				scmOdrDataWork.AnswerDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));
//				scmOdrDataWork.JudgementDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("JUDGEMENTDATERF"));
//				scmOdrDataWork.InqOrdNote			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));
//				scmOdrDataWork.InqEmployeeCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));
//				scmOdrDataWork.InqEmployeeNm		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));
//				scmOdrDataWork.AnsEmployeeCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));
//				scmOdrDataWork.AnsEmployeeNm		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));
//				scmOdrDataWork.InquiryDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INQUIRYDATERF"));
//				scmOdrDataWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));
//				scmOdrDataWork.InqOrdAnsDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDANSDIVCDRF"));
//				scmOdrDataWork.ReceiveDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECEIVEDATETIMERF"));
//				scmOdrDataWork.LatestDiscCode		= SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("LATESTDISCCODERF"));
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				scmOdrDataWork.CancelDiv			= SqlDataMediator.SqlGetInt16(myReader,myReader.GetOrdinal("CANCELDIVRF"));
//				scmOdrDataWork.CMTCooprtDiv			= SqlDataMediator.SqlGetInt16(myReader,myReader.GetOrdinal("CMTCOOPRTDIVRF"));
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
				#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				scmOdrDataWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
				scmOdrDataWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
				scmOdrDataWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
				scmOdrDataWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
				scmOdrDataWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
				scmOdrDataWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
				scmOdrDataWork.InqOtherSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
				scmOdrDataWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, colIndex_InquiryNumber);
				scmOdrDataWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_UpdateDate);
				scmOdrDataWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateTime);
				scmOdrDataWork.AnswerDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_AnswerDivCd);
				scmOdrDataWork.JudgementDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_JudgementDate);
				scmOdrDataWork.InqOrdNote			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOrdNote);
				scmOdrDataWork.InqEmployeeCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqEmployeeCd);
				scmOdrDataWork.InqEmployeeNm		= SqlDataMediator.SqlGetString(myReader, colIndex_InqEmployeeNm);
				scmOdrDataWork.AnsEmployeeCd		= SqlDataMediator.SqlGetString(myReader, colIndex_AnsEmployeeCd);
				scmOdrDataWork.AnsEmployeeNm		= SqlDataMediator.SqlGetString(myReader, colIndex_AnsEmployeeNm);
				scmOdrDataWork.InquiryDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_InquiryDate);
				scmOdrDataWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOrdDivCd);
				scmOdrDataWork.InqOrdAnsDivCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOrdAnsDivCd);
				scmOdrDataWork.ReceiveDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_ReceiveDateTime);
				scmOdrDataWork.LatestDiscCode		= SqlDataMediator.SqlGetInt16(myReader, colIndex_LatestDiscCode);
				scmOdrDataWork.CancelDiv			= SqlDataMediator.SqlGetInt16(myReader, colIndex_CancelDiv);
				scmOdrDataWork.CMTCooprtDiv			= SqlDataMediator.SqlGetInt16(myReader, colIndex_CMTCooprtDiv);
				scmOdrDataWork.SfPmCprtInstSlipNo	= SqlDataMediator.SqlGetString(myReader, colIndex_SfPmCprtInstSlipNo);
                scmOdrDataWork.AcceptOrOrderKind    = SqlDataMediator.SqlGetInt16(myReader, colIndex_AcceptOrOrderKind); //2011.08.10 Add
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
				#endregion

				// 検索条件に更新時分秒ミリ秒がある場合は同一日のデータのみ比較対象とする
				if (scmOdReadParamWork.UpdateTime > 0 &&
					scmOdrDataWork.UpdateDate == scmOdReadParamWork.UpdateDate &&
					scmOdrDataWork.UpdateTime <= scmOdReadParamWork.UpdateTime)
					continue;

				scmOdrDataWorkList.Add(scmOdrDataWork);
			}
			if (!myReader.IsClosed) myReader.Close();

			if (scmOdrDataWorkList.Count > 0)
			{
				scmOdrDataWorkArray = scmOdrDataWorkList.ToArray();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注明細データ（問合せ・発注）読込処理
	/// </summary>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="scmOdReadParamDtlArray">SCM受発注読込条件クラス(明細)配列</param>
	/// <param name="scmOdDtInqWorkArray">受発注明細データ（問合せ・発注）配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注明細データ（問合せ・発注）のSelectを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region ReadScmOdDtInqProc
	private int ReadScmOdDtInqProc(ScmOdReadParamWork scmOdReadParamWork, out ScmOdDtInqWork[] scmOdDtInqWorkArray, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

		scmOdDtInqWorkArray = null;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<ScmOdDtInqWork> scmOdDtInqWorkList = new List<ScmOdDtInqWork>();

			// Selectコマンドの生成
			#region 2011.05.19 TERASAKA DEL STA
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF FROM SCMODDTINQRF", sqlConnection);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//			#region 2011.02.01 TERASAKA DEL STA
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
////			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF FROM SCMODDTINQRF", sqlConnection);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//			#endregion
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF FROM SCMODDTINQRF", sqlConnection);
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
//			// Where文の追加
//			sqlCommand.CommandText += MakeWhereStringOfScmOdrData(1, scmOdReadParamWork, sqlCommand);
			#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			sqlCommand = new SqlCommand(string.Empty, sqlConnection);

			sqlCommand.CommandText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF, PMWAREHOUSECDRF, PMWAREHOUSENAMERF, "
				+ "PMSHELFNORF"
                // Add zhangw on 2011.08.03 For PCC_UOE STA
                + ", PMPRSNTCOUNTRF"
                + ", SETPARTSMKRCDRF"
                + ", SETPARTSNUMBERRF"
                + ", SETPARTSMAINSUBNORF"
                // Add zhangw on 2011.08.03 For PCC_UOE END
				+ " FROM SCMODDTINQRF"
				+ MakeWhereStringOfScmOdrData(1, scmOdReadParamWork, sqlCommand);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

			myReader = sqlCommand.ExecuteReader();
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			#region カラムインデックスの取得
			int colIndex_CreateDateTime			= 0;
			int colIndex_UpdateDateTime			= 0;
			int colIndex_LogicalDeleteCode		= 0;
			int colIndex_InqOriginalEpCd		= 0;
			int colIndex_InqOriginalSecCd		= 0;
			int colIndex_InqOtherEpCd			= 0;
			int colIndex_InqOtherSecCd			= 0;
			int colIndex_InquiryNumber			= 0;
			int colIndex_UpdateDate				= 0;
			int colIndex_UpdateTime				= 0;
			int colIndex_InqRowNumber			= 0;
			int colIndex_InqRowNumDerivedNo		= 0;
			int colIndex_InqOrgDtlDiscGuid		= 0;
			int colIndex_InqOthDtlDiscGuid		= 0;
			int colIndex_GoodsDivCd				= 0;
			int colIndex_RecyclePrtKindCode		= 0;
			int colIndex_RecyclePrtKindName		= 0;
			int colIndex_DeliveredGoodsDiv		= 0;
			int colIndex_HandleDivCode			= 0;
			int colIndex_GoodsShape				= 0;
			int colIndex_DelivrdGdsConfCd		= 0;
			int colIndex_DeliGdsCmpltDueDate	= 0;
			int colIndex_AnswerDeliveryDate		= 0;
			int colIndex_BLGoodsCode			= 0;
			int colIndex_BLGoodsDrCode			= 0;
			int colIndex_InqGoodsName			= 0;
			int colIndex_AnsGoodsName			= 0;
			int colIndex_SalesOrderCount		= 0;
			int colIndex_DeliveredGoodsCount	= 0;
			int colIndex_GoodsNo				= 0;
			int colIndex_GoodsMakerCd			= 0;
			int colIndex_GoodsMakerNm			= 0;
			int colIndex_PureGoodsMakerCd		= 0;
			int colIndex_InqPureGoodsNo			= 0;
			int colIndex_AnsPureGoodsNo			= 0;
			int colIndex_ListPrice				= 0;
			int colIndex_UnitPrice				= 0;
			int colIndex_GoodsAddInfo			= 0;
			int colIndex_RoughRrofit			= 0;
			int colIndex_RoughRate				= 0;
			int colIndex_AnswerLimitDate		= 0;
			int colIndex_CommentDtl				= 0;
			int colIndex_ShelfNo				= 0;
			int colIndex_AdditionalDivCd		= 0;
			int colIndex_CorrectDivCD			= 0;
			int colIndex_InqOrdDivCd			= 0;
			int colIndex_DisplayOrder			= 0;
			int colIndex_LatestDiscCode			= 0;
			int colIndex_CancelCndtinDiv		= 0;
			int colIndex_PMAcptAnOdrStatus		= 0;
			int colIndex_PMSalesSlipNum			= 0;
			int colIndex_PMSalesRowNo			= 0;
			int colIndex_DtlTakeinDivCd			= 0;
			int colIndex_PmWarehouseCd			= 0;
			int colIndex_PmWarehouseName		= 0;
			int colIndex_PmShelfNo				= 0;
            // Add zhangw on 2011.08.03 For PCC_UOE STA
            int colIndex_PmPrsntCount = 0;
            int colIndex_SetPartsMkrCd = 0;
            int colIndex_SetPartsNumber = 0;
            int colIndex_SetPartsMainSubNo = 0;
            // Add zhangw on 2011.08.03 For PCC_UOE END

			if (myReader.HasRows)
			{
				colIndex_CreateDateTime			= myReader.GetOrdinal("CREATEDATETIMERF");
				colIndex_UpdateDateTime			= myReader.GetOrdinal("UPDATEDATETIMERF");
				colIndex_LogicalDeleteCode		= myReader.GetOrdinal("LOGICALDELETECODERF");
				colIndex_InqOriginalEpCd		= myReader.GetOrdinal("INQORIGINALEPCDRF");
				colIndex_InqOriginalSecCd		= myReader.GetOrdinal("INQORIGINALSECCDRF");
				colIndex_InqOtherEpCd			= myReader.GetOrdinal("INQOTHEREPCDRF");
				colIndex_InqOtherSecCd			= myReader.GetOrdinal("INQOTHERSECCDRF");
				colIndex_InquiryNumber			= myReader.GetOrdinal("INQUIRYNUMBERRF");
				colIndex_UpdateDate				= myReader.GetOrdinal("UPDATEDATERF");
				colIndex_UpdateTime				= myReader.GetOrdinal("UPDATETIMERF");
				colIndex_InqRowNumber			= myReader.GetOrdinal("INQROWNUMBERRF");
				colIndex_InqRowNumDerivedNo		= myReader.GetOrdinal("INQROWNUMDERIVEDNORF");
				colIndex_InqOrgDtlDiscGuid		= myReader.GetOrdinal("INQORGDTLDISCGUIDRF");
				colIndex_InqOthDtlDiscGuid		= myReader.GetOrdinal("INQOTHDTLDISCGUIDRF");
				colIndex_GoodsDivCd				= myReader.GetOrdinal("GOODSDIVCDRF");
				colIndex_RecyclePrtKindCode		= myReader.GetOrdinal("RECYCLEPRTKINDCODERF");
				colIndex_RecyclePrtKindName		= myReader.GetOrdinal("RECYCLEPRTKINDNAMERF");
				colIndex_DeliveredGoodsDiv		= myReader.GetOrdinal("DELIVEREDGOODSDIVRF");
				colIndex_HandleDivCode			= myReader.GetOrdinal("HANDLEDIVCODERF");
				colIndex_GoodsShape				= myReader.GetOrdinal("GOODSSHAPERF");
				colIndex_DelivrdGdsConfCd		= myReader.GetOrdinal("DELIVRDGDSCONFCDRF");
				colIndex_DeliGdsCmpltDueDate	= myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF");
				colIndex_AnswerDeliveryDate		= myReader.GetOrdinal("ANSWERDELIVERYDATERF");
				colIndex_BLGoodsCode			= myReader.GetOrdinal("BLGOODSCODERF");
				colIndex_BLGoodsDrCode			= myReader.GetOrdinal("BLGOODSDRCODERF");
				colIndex_InqGoodsName			= myReader.GetOrdinal("INQGOODSNAMERF");
				colIndex_AnsGoodsName			= myReader.GetOrdinal("ANSGOODSNAMERF");
				colIndex_SalesOrderCount		= myReader.GetOrdinal("SALESORDERCOUNTRF");
				colIndex_DeliveredGoodsCount	= myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF");
				colIndex_GoodsNo				= myReader.GetOrdinal("GOODSNORF");
				colIndex_GoodsMakerCd			= myReader.GetOrdinal("GOODSMAKERCDRF");
				colIndex_GoodsMakerNm			= myReader.GetOrdinal("GOODSMAKERNMRF");
				colIndex_PureGoodsMakerCd		= myReader.GetOrdinal("PUREGOODSMAKERCDRF");
				colIndex_InqPureGoodsNo			= myReader.GetOrdinal("INQPUREGOODSNORF");
				colIndex_AnsPureGoodsNo			= myReader.GetOrdinal("ANSPUREGOODSNORF");
				colIndex_ListPrice				= myReader.GetOrdinal("LISTPRICERF");
				colIndex_UnitPrice				= myReader.GetOrdinal("UNITPRICERF");
				colIndex_GoodsAddInfo			= myReader.GetOrdinal("GOODSADDINFORF");
				colIndex_RoughRrofit			= myReader.GetOrdinal("ROUGHRROFITRF");
				colIndex_RoughRate				= myReader.GetOrdinal("ROUGHRATERF");
				colIndex_AnswerLimitDate		= myReader.GetOrdinal("ANSWERLIMITDATERF");
				colIndex_CommentDtl				= myReader.GetOrdinal("COMMENTDTLRF");
				colIndex_ShelfNo				= myReader.GetOrdinal("SHELFNORF");
				colIndex_AdditionalDivCd		= myReader.GetOrdinal("ADDITIONALDIVCDRF");
				colIndex_CorrectDivCD			= myReader.GetOrdinal("CORRECTDIVCDRF");
				colIndex_InqOrdDivCd			= myReader.GetOrdinal("INQORDDIVCDRF");
				colIndex_DisplayOrder			= myReader.GetOrdinal("DISPLAYORDERRF");
				colIndex_LatestDiscCode			= myReader.GetOrdinal("LATESTDISCCODERF");
				colIndex_CancelCndtinDiv		= myReader.GetOrdinal("CANCELCNDTINDIVRF");
				colIndex_PMAcptAnOdrStatus		= myReader.GetOrdinal("PMACPTANODRSTATUSRF");
				colIndex_PMSalesSlipNum			= myReader.GetOrdinal("PMSALESSLIPNUMRF");
				colIndex_PMSalesRowNo			= myReader.GetOrdinal("PMSALESROWNORF");
				colIndex_DtlTakeinDivCd			= myReader.GetOrdinal("DTLTAKEINDIVCDRF");
				colIndex_PmWarehouseCd			= myReader.GetOrdinal("PMWAREHOUSECDRF");
				colIndex_PmWarehouseName		= myReader.GetOrdinal("PMWAREHOUSENAMERF");
				colIndex_PmShelfNo				= myReader.GetOrdinal("PMSHELFNORF");
                // Add zhangw on 2011.08.03 For PCC_UOE STA
                colIndex_PmPrsntCount = myReader.GetOrdinal("PMPRSNTCOUNTRF");
                colIndex_SetPartsMkrCd = myReader.GetOrdinal("SETPARTSMKRCDRF");
                colIndex_SetPartsNumber = myReader.GetOrdinal("SETPARTSNUMBERRF");
                colIndex_SetPartsMainSubNo = myReader.GetOrdinal("SETPARTSMAINSUBNORF");
                // Add zhangw on 2011.08.03 For PCC_UOE END
			}
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			while (myReader.Read())
			{
				ScmOdDtInqWork scmOdDtInqWork = new ScmOdDtInqWork();

				#region データのコピー
				#region 2011.05.19 TERASAKA DEL STA
//				scmOdDtInqWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
//				scmOdDtInqWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
//				scmOdDtInqWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
//				scmOdDtInqWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
//				scmOdDtInqWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
//				scmOdDtInqWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
//				scmOdDtInqWork.InqOtherSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
//				scmOdDtInqWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
//				scmOdDtInqWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
//				scmOdDtInqWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
//				scmOdDtInqWork.InqRowNumber			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));
//				scmOdDtInqWork.InqRowNumDerivedNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));
//				scmOdDtInqWork.InqOrgDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQORGDTLDISCGUIDRF"));
//				scmOdDtInqWork.InqOthDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQOTHDTLDISCGUIDRF"));
//				scmOdDtInqWork.GoodsDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));
//				scmOdDtInqWork.RecyclePrtKindCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));
//				scmOdDtInqWork.RecyclePrtKindName	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));
//				scmOdDtInqWork.DeliveredGoodsDiv	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
//				scmOdDtInqWork.HandleDivCode		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));
//				scmOdDtInqWork.GoodsShape			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));
//				scmOdDtInqWork.DelivrdGdsConfCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));
//				scmOdDtInqWork.DeliGdsCmpltDueDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
//				scmOdDtInqWork.AnswerDeliveryDate	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));
//				scmOdDtInqWork.BLGoodsCode			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
//				scmOdDtInqWork.BLGoodsDrCode		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));
//				scmOdDtInqWork.InqGoodsName			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF"));
//				scmOdDtInqWork.AnsGoodsName			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF"));
//				scmOdDtInqWork.SalesOrderCount		= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
//				scmOdDtInqWork.DeliveredGoodsCount	= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));
//				scmOdDtInqWork.GoodsNo				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
//				scmOdDtInqWork.GoodsMakerCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
//				scmOdDtInqWork.GoodsMakerNm			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
//				scmOdDtInqWork.PureGoodsMakerCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));
//				scmOdDtInqWork.InqPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));
//				scmOdDtInqWork.AnsPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));
//				scmOdDtInqWork.ListPrice			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
//				scmOdDtInqWork.UnitPrice			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
//				scmOdDtInqWork.GoodsAddInfo			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));
//				scmOdDtInqWork.RoughRrofit			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));
//				scmOdDtInqWork.RoughRate			= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));
//				scmOdDtInqWork.AnswerLimitDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));
//				scmOdDtInqWork.CommentDtl			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));
//				scmOdDtInqWork.ShelfNo				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
//				scmOdDtInqWork.AdditionalDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));
//				scmOdDtInqWork.CorrectDivCD			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));
//				scmOdDtInqWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));
//				scmOdDtInqWork.DisplayOrder			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
//				scmOdDtInqWork.LatestDiscCode		= SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("LATESTDISCCODERF"));
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				scmOdDtInqWork.CancelCndtinDiv		= SqlDataMediator.SqlGetInt16(myReader,myReader.GetOrdinal("CANCELCNDTINDIVRF"));
//				scmOdDtInqWork.PMAcptAnOdrStatus	= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PMACPTANODRSTATUSRF"));
//				scmOdDtInqWork.PMSalesSlipNum		= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PMSALESSLIPNUMRF"));
//				scmOdDtInqWork.PMSalesRowNo			= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PMSALESROWNORF"));
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//				scmOdDtInqWork.DtlTakeinDivCd		= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DTLTAKEINDIVCDRF"));
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
				#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				scmOdDtInqWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
				scmOdDtInqWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
				scmOdDtInqWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
				scmOdDtInqWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
				scmOdDtInqWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
				scmOdDtInqWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
				scmOdDtInqWork.InqOtherSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
				scmOdDtInqWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, colIndex_InquiryNumber);
				scmOdDtInqWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_UpdateDate);
				scmOdDtInqWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateTime);
				scmOdDtInqWork.InqRowNumber			= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqRowNumber);
				scmOdDtInqWork.InqRowNumDerivedNo	= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqRowNumDerivedNo);
				scmOdDtInqWork.InqOrgDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, colIndex_InqOrgDtlDiscGuid);
				scmOdDtInqWork.InqOthDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, colIndex_InqOthDtlDiscGuid);
				scmOdDtInqWork.GoodsDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsDivCd);
				scmOdDtInqWork.RecyclePrtKindCode	= SqlDataMediator.SqlGetInt32(myReader, colIndex_RecyclePrtKindCode);
				scmOdDtInqWork.RecyclePrtKindName	= SqlDataMediator.SqlGetString(myReader, colIndex_RecyclePrtKindName);
				scmOdDtInqWork.DeliveredGoodsDiv	= SqlDataMediator.SqlGetInt32(myReader, colIndex_DeliveredGoodsDiv);
				scmOdDtInqWork.HandleDivCode		= SqlDataMediator.SqlGetInt32(myReader, colIndex_HandleDivCode);
				scmOdDtInqWork.GoodsShape			= SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsShape);
				scmOdDtInqWork.DelivrdGdsConfCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_DelivrdGdsConfCd);
				scmOdDtInqWork.DeliGdsCmpltDueDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_DeliGdsCmpltDueDate);
				scmOdDtInqWork.AnswerDeliveryDate	= SqlDataMediator.SqlGetString(myReader, colIndex_AnswerDeliveryDate);
				scmOdDtInqWork.BLGoodsCode			= SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
				scmOdDtInqWork.BLGoodsDrCode		= SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsDrCode);
				scmOdDtInqWork.InqGoodsName			= SqlDataMediator.SqlGetString(myReader, colIndex_InqGoodsName);
				scmOdDtInqWork.AnsGoodsName			= SqlDataMediator.SqlGetString(myReader, colIndex_AnsGoodsName);
				scmOdDtInqWork.SalesOrderCount		= SqlDataMediator.SqlGetDouble(myReader, colIndex_SalesOrderCount);
				scmOdDtInqWork.DeliveredGoodsCount	= SqlDataMediator.SqlGetDouble(myReader, colIndex_DeliveredGoodsCount);
				scmOdDtInqWork.GoodsNo				= SqlDataMediator.SqlGetString(myReader, colIndex_GoodsNo);
				scmOdDtInqWork.GoodsMakerCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsMakerCd);
				scmOdDtInqWork.GoodsMakerNm			= SqlDataMediator.SqlGetString(myReader, colIndex_GoodsMakerNm);
				scmOdDtInqWork.PureGoodsMakerCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_PureGoodsMakerCd);
				scmOdDtInqWork.InqPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, colIndex_InqPureGoodsNo);
				scmOdDtInqWork.AnsPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, colIndex_AnsPureGoodsNo);
				scmOdDtInqWork.ListPrice			= SqlDataMediator.SqlGetInt64(myReader, colIndex_ListPrice);
				scmOdDtInqWork.UnitPrice			= SqlDataMediator.SqlGetInt64(myReader, colIndex_UnitPrice);
				scmOdDtInqWork.GoodsAddInfo			= SqlDataMediator.SqlGetString(myReader, colIndex_GoodsAddInfo);
				scmOdDtInqWork.RoughRrofit			= SqlDataMediator.SqlGetInt64(myReader, colIndex_RoughRrofit);
				scmOdDtInqWork.RoughRate			= SqlDataMediator.SqlGetDouble(myReader, colIndex_RoughRate);
				scmOdDtInqWork.AnswerLimitDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_AnswerLimitDate);
				scmOdDtInqWork.CommentDtl			= SqlDataMediator.SqlGetString(myReader, colIndex_CommentDtl);
				scmOdDtInqWork.ShelfNo				= SqlDataMediator.SqlGetString(myReader, colIndex_ShelfNo);
				scmOdDtInqWork.AdditionalDivCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_AdditionalDivCd);
				scmOdDtInqWork.CorrectDivCD			= SqlDataMediator.SqlGetInt32(myReader, colIndex_CorrectDivCD);
				scmOdDtInqWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOrdDivCd);
				scmOdDtInqWork.DisplayOrder			= SqlDataMediator.SqlGetInt32(myReader, colIndex_DisplayOrder);
				scmOdDtInqWork.LatestDiscCode		= SqlDataMediator.SqlGetInt16(myReader, colIndex_LatestDiscCode);
				scmOdDtInqWork.CancelCndtinDiv		= SqlDataMediator.SqlGetInt16(myReader, colIndex_CancelCndtinDiv);
				scmOdDtInqWork.PMAcptAnOdrStatus	= SqlDataMediator.SqlGetInt32(myReader, colIndex_PMAcptAnOdrStatus);
				scmOdDtInqWork.PMSalesSlipNum		= SqlDataMediator.SqlGetInt32(myReader, colIndex_PMSalesSlipNum);
				scmOdDtInqWork.PMSalesRowNo			= SqlDataMediator.SqlGetInt32(myReader, colIndex_PMSalesRowNo);
				scmOdDtInqWork.DtlTakeinDivCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_DtlTakeinDivCd);
				scmOdDtInqWork.PmWarehouseCd		= SqlDataMediator.SqlGetString(myReader, colIndex_PmWarehouseCd);
				scmOdDtInqWork.PmWarehouseName		= SqlDataMediator.SqlGetString(myReader, colIndex_PmWarehouseName);
				scmOdDtInqWork.PmShelfNo			= SqlDataMediator.SqlGetString(myReader, colIndex_PmShelfNo);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
                // Add zhangw on 2011.08.03 For PCC_UOE STA
                scmOdDtInqWork.PmPrsntCount = SqlDataMediator.SqlGetDouble(myReader, colIndex_PmPrsntCount);
                scmOdDtInqWork.SetPartsMkrCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SetPartsMkrCd);
                scmOdDtInqWork.SetPartsNumber = SqlDataMediator.SqlGetString(myReader, colIndex_SetPartsNumber);
                scmOdDtInqWork.SetPartsMainSubNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SetPartsMainSubNo);
                // Add zhangw on 2011.08.03 For PCC_UOE END
                #endregion

				// 検索条件に更新時分秒ミリ秒がある場合は同一日のデータのみ比較対象とする
				if (scmOdReadParamWork.UpdateTime > 0 &&
					scmOdDtInqWork.UpdateDate == scmOdReadParamWork.UpdateDate &&
					scmOdDtInqWork.UpdateTime <= scmOdReadParamWork.UpdateTime)
					continue;

				scmOdDtInqWorkList.Add(scmOdDtInqWork);
			}
			if (!myReader.IsClosed) myReader.Close();

			scmOdDtInqWorkArray = scmOdDtInqWorkList.ToArray();

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注明細データ（回答）読込処理
	/// </summary>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="scmOdReadParamDtlArray">SCM受発注読込条件クラス(明細)配列</param>
	/// <param name="scmOdDtAnsWorkArray">受発注明細データ（回答）配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注明細データ（回答）のSelectを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region ReadScmOdDtAnsProc
	private int ReadScmOdDtAnsProc(ScmOdReadParamWork scmOdReadParamWork, out ScmOdDtAnsWork[] scmOdDtAnsWorkArray, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

		scmOdDtAnsWorkArray = null;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<ScmOdDtAnsWork> scmOdDtAnsWorkList = new List<ScmOdDtAnsWork>();

			// Selectコマンドの生成
			#region 2011.05.19 TERASAKA DEL STA
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF FROM SCMODDTANSRF", sqlConnection);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//			#region 2011.02.01 TERASAKA DEL STA
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
////			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF FROM SCMODDTANSRF", sqlConnection);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//			#endregion
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//			sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF FROM SCMODDTANSRF", sqlConnection);
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
//			// Where文の追加
//			sqlCommand.CommandText += MakeWhereStringOfScmOdrData(1, scmOdReadParamWork, sqlCommand);
			#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			sqlCommand = new SqlCommand(string.Empty, sqlConnection);

			sqlCommand.CommandText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, INQROWNUMBERRF, INQROWNUMDERIVEDNORF, INQORGDTLDISCGUIDRF, INQOTHDTLDISCGUIDRF, GOODSDIVCDRF, RECYCLEPRTKINDCODERF, RECYCLEPRTKINDNAMERF, DELIVEREDGOODSDIVRF, HANDLEDIVCODERF, GOODSSHAPERF, DELIVRDGDSCONFCDRF, DELIGDSCMPLTDUEDATERF, ANSWERDELIVERYDATERF, BLGOODSCODERF, BLGOODSDRCODERF, INQGOODSNAMERF, ANSGOODSNAMERF, SALESORDERCOUNTRF, DELIVEREDGOODSCOUNTRF, GOODSNORF, GOODSMAKERCDRF, GOODSMAKERNMRF, PUREGOODSMAKERCDRF, INQPUREGOODSNORF, ANSPUREGOODSNORF, LISTPRICERF, UNITPRICERF, GOODSADDINFORF, ROUGHRROFITRF, ROUGHRATERF, ANSWERLIMITDATERF, COMMENTDTLRF, SHELFNORF, ADDITIONALDIVCDRF, CORRECTDIVCDRF, INQORDDIVCDRF, DISPLAYORDERRF, LATESTDISCCODERF, CANCELCNDTINDIVRF, PMACPTANODRSTATUSRF, PMSALESSLIPNUMRF, PMSALESROWNORF, DTLTAKEINDIVCDRF, PMWAREHOUSECDRF, PMWAREHOUSENAMERF, "
				+ "PMSHELFNORF"
                // Add zhangw on 2011.08.03 For PCC_UOE STA
                + ", PMPRSNTCOUNTRF"
                + ", SETPARTSMKRCDRF"
                + ", SETPARTSNUMBERRF"
                + ", SETPARTSMAINSUBNORF"
                // Add zhangw on 2011.08.03 For PCC_UOE END
				+ " FROM SCMODDTANSRF"
				+ MakeWhereStringOfScmOdrData(1, scmOdReadParamWork, sqlCommand);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

			myReader = sqlCommand.ExecuteReader();
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			#region カラムインデックスの取得
			int colIndex_CreateDateTime			= 0;
			int colIndex_UpdateDateTime			= 0;
			int colIndex_LogicalDeleteCode		= 0;
			int colIndex_InqOriginalEpCd		= 0;
			int colIndex_InqOriginalSecCd		= 0;
			int colIndex_InqOtherEpCd			= 0;
			int colIndex_InqOtherSecCd			= 0;
			int colIndex_InquiryNumber			= 0;
			int colIndex_UpdateDate				= 0;
			int colIndex_UpdateTime				= 0;
			int colIndex_InqRowNumber			= 0;
			int colIndex_InqRowNumDerivedNo		= 0;
			int colIndex_InqOrgDtlDiscGuid		= 0;
			int colIndex_InqOthDtlDiscGuid		= 0;
			int colIndex_GoodsDivCd				= 0;
			int colIndex_RecyclePrtKindCode		= 0;
			int colIndex_RecyclePrtKindName		= 0;
			int colIndex_DeliveredGoodsDiv		= 0;
			int colIndex_HandleDivCode			= 0;
			int colIndex_GoodsShape				= 0;
			int colIndex_DelivrdGdsConfCd		= 0;
			int colIndex_DeliGdsCmpltDueDate	= 0;
			int colIndex_AnswerDeliveryDate		= 0;
			int colIndex_BLGoodsCode			= 0;
			int colIndex_BLGoodsDrCode			= 0;
			int colIndex_InqGoodsName			= 0;
			int colIndex_AnsGoodsName			= 0;
			int colIndex_SalesOrderCount		= 0;
			int colIndex_DeliveredGoodsCount	= 0;
			int colIndex_GoodsNo				= 0;
			int colIndex_GoodsMakerCd			= 0;
			int colIndex_GoodsMakerNm			= 0;
			int colIndex_PureGoodsMakerCd		= 0;
			int colIndex_InqPureGoodsNo			= 0;
			int colIndex_AnsPureGoodsNo			= 0;
			int colIndex_ListPrice				= 0;
			int colIndex_UnitPrice				= 0;
			int colIndex_GoodsAddInfo			= 0;
			int colIndex_RoughRrofit			= 0;
			int colIndex_RoughRate				= 0;
			int colIndex_AnswerLimitDate		= 0;
			int colIndex_CommentDtl				= 0;
			int colIndex_ShelfNo				= 0;
			int colIndex_AdditionalDivCd		= 0;
			int colIndex_CorrectDivCD			= 0;
			int colIndex_InqOrdDivCd			= 0;
			int colIndex_DisplayOrder			= 0;
			int colIndex_LatestDiscCode			= 0;
			int colIndex_CancelCndtinDiv		= 0;
			int colIndex_PMAcptAnOdrStatus		= 0;
			int colIndex_PMSalesSlipNum			= 0;
			int colIndex_PMSalesRowNo			= 0;
			int colIndex_DtlTakeinDivCd			= 0;
			int colIndex_PmWarehouseCd			= 0;
			int colIndex_PmWarehouseName		= 0;
			int colIndex_PmShelfNo				= 0;
            // Add zhangw on 2011.08.03 For PCC_UOE STA
            int colIndex_PmPrsntCount = 0;
            int colIndex_SetPartsMkrCd = 0;
            int colIndex_SetPartsNumber = 0;
            int colIndex_SetPartsMainSubNo = 0;
            // Add zhangw on 2011.08.03 For PCC_UOE END

			if (myReader.HasRows)
			{
				colIndex_CreateDateTime			= myReader.GetOrdinal("CREATEDATETIMERF");
				colIndex_UpdateDateTime			= myReader.GetOrdinal("UPDATEDATETIMERF");
				colIndex_LogicalDeleteCode		= myReader.GetOrdinal("LOGICALDELETECODERF");
				colIndex_InqOriginalEpCd		= myReader.GetOrdinal("INQORIGINALEPCDRF");
				colIndex_InqOriginalSecCd		= myReader.GetOrdinal("INQORIGINALSECCDRF");
				colIndex_InqOtherEpCd			= myReader.GetOrdinal("INQOTHEREPCDRF");
				colIndex_InqOtherSecCd			= myReader.GetOrdinal("INQOTHERSECCDRF");
				colIndex_InquiryNumber			= myReader.GetOrdinal("INQUIRYNUMBERRF");
				colIndex_UpdateDate				= myReader.GetOrdinal("UPDATEDATERF");
				colIndex_UpdateTime				= myReader.GetOrdinal("UPDATETIMERF");
				colIndex_InqRowNumber			= myReader.GetOrdinal("INQROWNUMBERRF");
				colIndex_InqRowNumDerivedNo		= myReader.GetOrdinal("INQROWNUMDERIVEDNORF");
				colIndex_InqOrgDtlDiscGuid		= myReader.GetOrdinal("INQORGDTLDISCGUIDRF");
				colIndex_InqOthDtlDiscGuid		= myReader.GetOrdinal("INQOTHDTLDISCGUIDRF");
				colIndex_GoodsDivCd				= myReader.GetOrdinal("GOODSDIVCDRF");
				colIndex_RecyclePrtKindCode		= myReader.GetOrdinal("RECYCLEPRTKINDCODERF");
				colIndex_RecyclePrtKindName		= myReader.GetOrdinal("RECYCLEPRTKINDNAMERF");
				colIndex_DeliveredGoodsDiv		= myReader.GetOrdinal("DELIVEREDGOODSDIVRF");
				colIndex_HandleDivCode			= myReader.GetOrdinal("HANDLEDIVCODERF");
				colIndex_GoodsShape				= myReader.GetOrdinal("GOODSSHAPERF");
				colIndex_DelivrdGdsConfCd		= myReader.GetOrdinal("DELIVRDGDSCONFCDRF");
				colIndex_DeliGdsCmpltDueDate	= myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF");
				colIndex_AnswerDeliveryDate		= myReader.GetOrdinal("ANSWERDELIVERYDATERF");
				colIndex_BLGoodsCode			= myReader.GetOrdinal("BLGOODSCODERF");
				colIndex_BLGoodsDrCode			= myReader.GetOrdinal("BLGOODSDRCODERF");
				colIndex_InqGoodsName			= myReader.GetOrdinal("INQGOODSNAMERF");
				colIndex_AnsGoodsName			= myReader.GetOrdinal("ANSGOODSNAMERF");
				colIndex_SalesOrderCount		= myReader.GetOrdinal("SALESORDERCOUNTRF");
				colIndex_DeliveredGoodsCount	= myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF");
				colIndex_GoodsNo				= myReader.GetOrdinal("GOODSNORF");
				colIndex_GoodsMakerCd			= myReader.GetOrdinal("GOODSMAKERCDRF");
				colIndex_GoodsMakerNm			= myReader.GetOrdinal("GOODSMAKERNMRF");
				colIndex_PureGoodsMakerCd		= myReader.GetOrdinal("PUREGOODSMAKERCDRF");
				colIndex_InqPureGoodsNo			= myReader.GetOrdinal("INQPUREGOODSNORF");
				colIndex_AnsPureGoodsNo			= myReader.GetOrdinal("ANSPUREGOODSNORF");
				colIndex_ListPrice				= myReader.GetOrdinal("LISTPRICERF");
				colIndex_UnitPrice				= myReader.GetOrdinal("UNITPRICERF");
				colIndex_GoodsAddInfo			= myReader.GetOrdinal("GOODSADDINFORF");
				colIndex_RoughRrofit			= myReader.GetOrdinal("ROUGHRROFITRF");
				colIndex_RoughRate				= myReader.GetOrdinal("ROUGHRATERF");
				colIndex_AnswerLimitDate		= myReader.GetOrdinal("ANSWERLIMITDATERF");
				colIndex_CommentDtl				= myReader.GetOrdinal("COMMENTDTLRF");
				colIndex_ShelfNo				= myReader.GetOrdinal("SHELFNORF");
				colIndex_AdditionalDivCd		= myReader.GetOrdinal("ADDITIONALDIVCDRF");
				colIndex_CorrectDivCD			= myReader.GetOrdinal("CORRECTDIVCDRF");
				colIndex_InqOrdDivCd			= myReader.GetOrdinal("INQORDDIVCDRF");
				colIndex_DisplayOrder			= myReader.GetOrdinal("DISPLAYORDERRF");
				colIndex_LatestDiscCode			= myReader.GetOrdinal("LATESTDISCCODERF");
				colIndex_CancelCndtinDiv		= myReader.GetOrdinal("CANCELCNDTINDIVRF");
				colIndex_PMAcptAnOdrStatus		= myReader.GetOrdinal("PMACPTANODRSTATUSRF");
				colIndex_PMSalesSlipNum			= myReader.GetOrdinal("PMSALESSLIPNUMRF");
				colIndex_PMSalesRowNo			= myReader.GetOrdinal("PMSALESROWNORF");
				colIndex_DtlTakeinDivCd			= myReader.GetOrdinal("DTLTAKEINDIVCDRF");
				colIndex_PmWarehouseCd			= myReader.GetOrdinal("PMWAREHOUSECDRF");
				colIndex_PmWarehouseName		= myReader.GetOrdinal("PMWAREHOUSENAMERF");
				colIndex_PmShelfNo				= myReader.GetOrdinal("PMSHELFNORF");
                // Add zhangw on 2011.08.03 For PCC_UOE STA
                colIndex_PmPrsntCount = myReader.GetOrdinal("PMPRSNTCOUNTRF");
                colIndex_SetPartsMkrCd = myReader.GetOrdinal("SETPARTSMKRCDRF");
                colIndex_SetPartsNumber = myReader.GetOrdinal("SETPARTSNUMBERRF");
                colIndex_SetPartsMainSubNo = myReader.GetOrdinal("SETPARTSMAINSUBNORF");
                // Add zhangw on 2011.08.03 For PCC_UOE END
			}
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			while (myReader.Read())
			{
				ScmOdDtAnsWork scmOdDtAnsWork = new ScmOdDtAnsWork();

				#region データのコピー
				#region 2011.05.19 TERASAKA DEL STA
//				scmOdDtAnsWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
//				scmOdDtAnsWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
//				scmOdDtAnsWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
//				scmOdDtAnsWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
//				scmOdDtAnsWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
//				scmOdDtAnsWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
//				scmOdDtAnsWork.InqOtherSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
//				scmOdDtAnsWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
//				scmOdDtAnsWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
//				scmOdDtAnsWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
//				scmOdDtAnsWork.InqRowNumber			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));
//				scmOdDtAnsWork.InqRowNumDerivedNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMDERIVEDNORF"));
//				scmOdDtAnsWork.InqOrgDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQORGDTLDISCGUIDRF"));
//				scmOdDtAnsWork.InqOthDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("INQOTHDTLDISCGUIDRF"));
//				scmOdDtAnsWork.GoodsDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));
//				scmOdDtAnsWork.RecyclePrtKindCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEPRTKINDCODERF"));
//				scmOdDtAnsWork.RecyclePrtKindName	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEPRTKINDNAMERF"));
//				scmOdDtAnsWork.DeliveredGoodsDiv	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
//				scmOdDtAnsWork.HandleDivCode		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDLEDIVCODERF"));
//				scmOdDtAnsWork.GoodsShape			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSHAPERF"));
//				scmOdDtAnsWork.DelivrdGdsConfCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVRDGDSCONFCDRF"));
//				scmOdDtAnsWork.DeliGdsCmpltDueDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
//				scmOdDtAnsWork.AnswerDeliveryDate	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVERYDATERF"));
//				scmOdDtAnsWork.BLGoodsCode			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
//				scmOdDtAnsWork.BLGoodsDrCode		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSDRCODERF"));
//				scmOdDtAnsWork.InqGoodsName			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQGOODSNAMERF"));
//				scmOdDtAnsWork.AnsGoodsName			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSGOODSNAMERF"));
//				scmOdDtAnsWork.SalesOrderCount		= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
//				scmOdDtAnsWork.DeliveredGoodsCount	= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DELIVEREDGOODSCOUNTRF"));
//				scmOdDtAnsWork.GoodsNo				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
//				scmOdDtAnsWork.GoodsMakerCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
//				scmOdDtAnsWork.GoodsMakerNm			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
//				scmOdDtAnsWork.PureGoodsMakerCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PUREGOODSMAKERCDRF"));
//				scmOdDtAnsWork.InqPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQPUREGOODSNORF"));
//				scmOdDtAnsWork.AnsPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSPUREGOODSNORF"));
//				scmOdDtAnsWork.ListPrice			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
//				scmOdDtAnsWork.UnitPrice			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
//				scmOdDtAnsWork.GoodsAddInfo			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSADDINFORF"));
//				scmOdDtAnsWork.RoughRrofit			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROUGHRROFITRF"));
//				scmOdDtAnsWork.RoughRate			= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ROUGHRATERF"));
//				scmOdDtAnsWork.AnswerLimitDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ANSWERLIMITDATERF"));
//				scmOdDtAnsWork.CommentDtl			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTDTLRF"));
//				scmOdDtAnsWork.ShelfNo				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
//				scmOdDtAnsWork.AdditionalDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDITIONALDIVCDRF"));
//				scmOdDtAnsWork.CorrectDivCD			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORRECTDIVCDRF"));
//				scmOdDtAnsWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));
//				scmOdDtAnsWork.DisplayOrder			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
//				scmOdDtAnsWork.LatestDiscCode		= SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("LATESTDISCCODERF"));
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				scmOdDtAnsWork.CancelCndtinDiv		= SqlDataMediator.SqlGetInt16(myReader,myReader.GetOrdinal("CANCELCNDTINDIVRF"));
//				scmOdDtAnsWork.PMAcptAnOdrStatus	= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PMACPTANODRSTATUSRF"));
//				scmOdDtAnsWork.PMSalesSlipNum		= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PMSALESSLIPNUMRF"));
//				scmOdDtAnsWork.PMSalesRowNo			= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PMSALESROWNORF"));
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//////////////////////////////////////////////// 2011.02.01 TERASAKA ADD STA //
//				scmOdDtAnsWork.DtlTakeinDivCd		= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DTLTAKEINDIVCDRF"));
//// 2011.02.01 TERASAKA ADD END //////////////////////////////////////////////
				#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				scmOdDtAnsWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
				scmOdDtAnsWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
				scmOdDtAnsWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
				scmOdDtAnsWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
				scmOdDtAnsWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
				scmOdDtAnsWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
				scmOdDtAnsWork.InqOtherSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
				scmOdDtAnsWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, colIndex_InquiryNumber);
				scmOdDtAnsWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_UpdateDate);
				scmOdDtAnsWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateTime);
				scmOdDtAnsWork.InqRowNumber			= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqRowNumber);
				scmOdDtAnsWork.InqRowNumDerivedNo	= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqRowNumDerivedNo);
				scmOdDtAnsWork.InqOrgDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, colIndex_InqOrgDtlDiscGuid);
				scmOdDtAnsWork.InqOthDtlDiscGuid	= SqlDataMediator.SqlGetGuid(myReader, colIndex_InqOthDtlDiscGuid);
				scmOdDtAnsWork.GoodsDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsDivCd);
				scmOdDtAnsWork.RecyclePrtKindCode	= SqlDataMediator.SqlGetInt32(myReader, colIndex_RecyclePrtKindCode);
				scmOdDtAnsWork.RecyclePrtKindName	= SqlDataMediator.SqlGetString(myReader, colIndex_RecyclePrtKindName);
				scmOdDtAnsWork.DeliveredGoodsDiv	= SqlDataMediator.SqlGetInt32(myReader, colIndex_DeliveredGoodsDiv);
				scmOdDtAnsWork.HandleDivCode		= SqlDataMediator.SqlGetInt32(myReader, colIndex_HandleDivCode);
				scmOdDtAnsWork.GoodsShape			= SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsShape);
				scmOdDtAnsWork.DelivrdGdsConfCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_DelivrdGdsConfCd);
				scmOdDtAnsWork.DeliGdsCmpltDueDate	= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_DeliGdsCmpltDueDate);
				scmOdDtAnsWork.AnswerDeliveryDate	= SqlDataMediator.SqlGetString(myReader, colIndex_AnswerDeliveryDate);
				scmOdDtAnsWork.BLGoodsCode			= SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
				scmOdDtAnsWork.BLGoodsDrCode		= SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsDrCode);
				scmOdDtAnsWork.InqGoodsName			= SqlDataMediator.SqlGetString(myReader, colIndex_InqGoodsName);
				scmOdDtAnsWork.AnsGoodsName			= SqlDataMediator.SqlGetString(myReader, colIndex_AnsGoodsName);
				scmOdDtAnsWork.SalesOrderCount		= SqlDataMediator.SqlGetDouble(myReader, colIndex_SalesOrderCount);
				scmOdDtAnsWork.DeliveredGoodsCount	= SqlDataMediator.SqlGetDouble(myReader, colIndex_DeliveredGoodsCount);
				scmOdDtAnsWork.GoodsNo				= SqlDataMediator.SqlGetString(myReader, colIndex_GoodsNo);
				scmOdDtAnsWork.GoodsMakerCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsMakerCd);
				scmOdDtAnsWork.GoodsMakerNm			= SqlDataMediator.SqlGetString(myReader, colIndex_GoodsMakerNm);
				scmOdDtAnsWork.PureGoodsMakerCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_PureGoodsMakerCd);
				scmOdDtAnsWork.InqPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, colIndex_InqPureGoodsNo);
				scmOdDtAnsWork.AnsPureGoodsNo		= SqlDataMediator.SqlGetString(myReader, colIndex_AnsPureGoodsNo);
				scmOdDtAnsWork.ListPrice			= SqlDataMediator.SqlGetInt64(myReader, colIndex_ListPrice);
				scmOdDtAnsWork.UnitPrice			= SqlDataMediator.SqlGetInt64(myReader, colIndex_UnitPrice);
				scmOdDtAnsWork.GoodsAddInfo			= SqlDataMediator.SqlGetString(myReader, colIndex_GoodsAddInfo);
				scmOdDtAnsWork.RoughRrofit			= SqlDataMediator.SqlGetInt64(myReader, colIndex_RoughRrofit);
				scmOdDtAnsWork.RoughRate			= SqlDataMediator.SqlGetDouble(myReader, colIndex_RoughRate);
				scmOdDtAnsWork.AnswerLimitDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_AnswerLimitDate);
				scmOdDtAnsWork.CommentDtl			= SqlDataMediator.SqlGetString(myReader, colIndex_CommentDtl);
				scmOdDtAnsWork.ShelfNo				= SqlDataMediator.SqlGetString(myReader, colIndex_ShelfNo);
				scmOdDtAnsWork.AdditionalDivCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_AdditionalDivCd);
				scmOdDtAnsWork.CorrectDivCD			= SqlDataMediator.SqlGetInt32(myReader, colIndex_CorrectDivCD);
				scmOdDtAnsWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOrdDivCd);
				scmOdDtAnsWork.DisplayOrder			= SqlDataMediator.SqlGetInt32(myReader, colIndex_DisplayOrder);
				scmOdDtAnsWork.LatestDiscCode		= SqlDataMediator.SqlGetInt16(myReader, colIndex_LatestDiscCode);
				scmOdDtAnsWork.CancelCndtinDiv		= SqlDataMediator.SqlGetInt16(myReader, colIndex_CancelCndtinDiv);
				scmOdDtAnsWork.PMAcptAnOdrStatus	= SqlDataMediator.SqlGetInt32(myReader, colIndex_PMAcptAnOdrStatus);
				scmOdDtAnsWork.PMSalesSlipNum		= SqlDataMediator.SqlGetInt32(myReader, colIndex_PMSalesSlipNum);
				scmOdDtAnsWork.PMSalesRowNo			= SqlDataMediator.SqlGetInt32(myReader, colIndex_PMSalesRowNo);
				scmOdDtAnsWork.DtlTakeinDivCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_DtlTakeinDivCd);
				scmOdDtAnsWork.PmWarehouseCd		= SqlDataMediator.SqlGetString(myReader, colIndex_PmWarehouseCd);
				scmOdDtAnsWork.PmWarehouseName		= SqlDataMediator.SqlGetString(myReader, colIndex_PmWarehouseName);
				scmOdDtAnsWork.PmShelfNo			= SqlDataMediator.SqlGetString(myReader, colIndex_PmShelfNo);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
                // Add zhangw on 2011.08.03 For PCC_UOE STA
                scmOdDtAnsWork.PmPrsntCount = SqlDataMediator.SqlGetDouble(myReader, colIndex_PmPrsntCount);
                scmOdDtAnsWork.SetPartsMkrCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SetPartsMkrCd);
                scmOdDtAnsWork.SetPartsNumber = SqlDataMediator.SqlGetString(myReader, colIndex_SetPartsNumber);
                scmOdDtAnsWork.SetPartsMainSubNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SetPartsMainSubNo);
                // Add zhangw on 2011.08.03 For PCC_UOE END
				#endregion

				// 検索条件に更新時分秒ミリ秒がある場合は同一日のデータのみ比較対象とする
				if (scmOdReadParamWork.UpdateTime > 0 &&
					scmOdDtAnsWork.UpdateDate == scmOdReadParamWork.UpdateDate &&
					scmOdDtAnsWork.UpdateTime <= scmOdReadParamWork.UpdateTime)
					continue;

				scmOdDtAnsWorkList.Add(scmOdDtAnsWork);
			}
			if (!myReader.IsClosed) myReader.Close();

			scmOdDtAnsWorkArray = scmOdDtAnsWorkList.ToArray();

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// SCM受発注データ(車両情報)読込処理
	/// </summary>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="scmOdDtCarWorkArray">SCM受発注データ(車両情報)配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データ(車両情報)のSelectを行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region ReadScmOdDtCarProc
	private int ReadScmOdDtCarProc(string inqOriginalEpCd, string inqOriginalSecCd, List<long> inquiryNumberList, out ScmOdDtCarWork[] scmOdDtCarWorkArray, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

		scmOdDtCarWorkArray = null;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<ScmOdDtCarWork> scmOdDtCarWorkList = new List<ScmOdDtCarWork>();

			// Selectコマンドの生成
            //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQUIRYNUMBERRF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MODELDESIGNATIONNORF, CATEGORYNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELNAMERF, CARINSPECTCERTMODELRF, FULLMODELRF, FRAMENORF, FRAMEMODELRF, CHASSISNORF, CARPROPERNORF, PRODUCETYPEOFYEARNUMRF, COMMENTRF, RPCOLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, EQUIPOBJRF FROM SCMODDTCARRF", sqlConnection); //2011.08.10 Del
            sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQUIRYNUMBERRF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MODELDESIGNATIONNORF, CATEGORYNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELNAMERF, CARINSPECTCERTMODELRF, FULLMODELRF, FRAMENORF, FRAMEMODELRF, CHASSISNORF, CARPROPERNORF, PRODUCETYPEOFYEARNUMRF, COMMENTRF, RPCOLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, EQUIPOBJRF, CARNORF, MAKERNAMERF, GRADENAMERF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, CMNNMENGINEDISPLACERF, ENGINEMODELRF, NUMBEROFGEARRF, GEARNMRF, EDIVNMRF FROM SCMODDTCARRF", sqlConnection); //2011.08.10 Add
			// Where文の追加
			sqlCommand.CommandText += MakeWhereStringOfScmOdDtCar(inqOriginalEpCd, inqOriginalSecCd, inquiryNumberList, sqlCommand);

			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

			myReader = sqlCommand.ExecuteReader();
			while (myReader.Read())
			{
				ScmOdDtCarWork scmOdDtCarWork = new ScmOdDtCarWork();

				#region データのコピー
				scmOdDtCarWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				scmOdDtCarWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				scmOdDtCarWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				scmOdDtCarWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
				scmOdDtCarWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
				scmOdDtCarWork.InquiryNumber		= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
				scmOdDtCarWork.NumberPlate1Code		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
				scmOdDtCarWork.NumberPlate1Name		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
				scmOdDtCarWork.NumberPlate2			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
				scmOdDtCarWork.NumberPlate3			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
				scmOdDtCarWork.NumberPlate4			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
				scmOdDtCarWork.ModelDesignationNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
				scmOdDtCarWork.CategoryNo			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
				scmOdDtCarWork.MakerCode			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
				scmOdDtCarWork.ModelCode			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
				scmOdDtCarWork.ModelSubCode			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
				scmOdDtCarWork.ModelName			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));
				scmOdDtCarWork.CarInspectCertModel	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));
				scmOdDtCarWork.FullModel			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
				scmOdDtCarWork.FrameNo				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
				scmOdDtCarWork.FrameModel			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
				scmOdDtCarWork.ChassisNo			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHASSISNORF"));
				scmOdDtCarWork.CarProperNo			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARPROPERNORF"));
				scmOdDtCarWork.ProduceTypeOfYearNum	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRODUCETYPEOFYEARNUMRF"));
				scmOdDtCarWork.Comment				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMENTRF"));
				scmOdDtCarWork.RpColorCode			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RPCOLORCODERF"));
				scmOdDtCarWork.ColorName1			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
				scmOdDtCarWork.TrimCode				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
				scmOdDtCarWork.TrimName				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
				scmOdDtCarWork.Mileage				= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
				scmOdDtCarWork.EquipObj				= SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("EQUIPOBJRF"));
                ////////////////////////////////////////////// 2011.08.10 huangqb ADD STA //
                scmOdDtCarWork.CarNo                = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNORF"));
                scmOdDtCarWork.MakerName            = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                scmOdDtCarWork.GradeName            = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GRADENAMERF"));
                scmOdDtCarWork.BodyName             = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                scmOdDtCarWork.DoorCount            = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                scmOdDtCarWork.EngineModelNm        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                scmOdDtCarWork.CmnNmEngineDisPlace  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMNNMENGINEDISPLACERF"));
                scmOdDtCarWork.EngineModel          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELRF"));
                scmOdDtCarWork.NumberOfGear         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBEROFGEARRF"));
                scmOdDtCarWork.GearNm               = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GEARNMRF"));
                scmOdDtCarWork.EDivNm               = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                // 2011.08.10 huangqb ADD END //////////////////////////////////////////////
				#endregion

				scmOdDtCarWorkList.Add(scmOdDtCarWork);
			}
			if (!myReader.IsClosed) myReader.Close();

			scmOdDtCarWorkArray = scmOdDtCarWorkList.ToArray();

			if (scmOdDtCarWorkArray != null && scmOdDtCarWorkArray.Length > 0)
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// WHERE文作成処理(SCM受発注データ読込用)
	/// </summary>
	/// <param name="mode">作成モード[0:受発注データ,1:受発注明細データ]</param>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="sqlCommand">SqlCommandクラス</param>
	/// <returns>WHERE文</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データ読込用のWHERE文を作成します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region MakeWhereStringOfScmOdrData
	private string MakeWhereStringOfScmOdrData(int mode, ScmOdReadParamWork scmOdReadParamWork, SqlCommand sqlCommand)
	{
		StringBuilder whereString = new StringBuilder();

		// 問合せ元企業コード
		if (scmOdReadParamWork.InqOriginalEpCd != null && scmOdReadParamWork.InqOriginalEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORIGINALEPCDRF=@FINDINQORIGINALEPCD");
			SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmOdReadParamWork.InqOriginalEpCd);
		}

		// 問合せ元拠点コード
		if (scmOdReadParamWork.InqOriginalSecCd != null && scmOdReadParamWork.InqOriginalSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORIGINALSECCDRF=@FINDINQORIGINALSECCD");
			SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmOdReadParamWork.InqOriginalSecCd);
		}

		// 問合せ先企業コード
		if (scmOdReadParamWork.InqOtherEpCd != null && scmOdReadParamWork.InqOtherEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQOTHEREPCDRF=@FINDINQOTHEREPCD");
			SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmOdReadParamWork.InqOtherEpCd);
		}

		// 問合せ先拠点コード
		if (scmOdReadParamWork.InqOtherSecCd != null && scmOdReadParamWork.InqOtherSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQOTHERSECCDRF=@FINDINQOTHERSECCD");
			SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmOdReadParamWork.InqOtherSecCd);
		}

		// 問合せ番号
		if (scmOdReadParamWork.InquiryNumber > 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQUIRYNUMBERRF=@FINDINQUIRYNUMBER");
			SqlParameter findParaInquiryNumber = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
			findParaInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmOdReadParamWork.InquiryNumber);
		}

		// 最新識別区分(-1:指定無し 0:最新データ 1:旧データ)
		if (scmOdReadParamWork.LatestDiscCode >= 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("LATESTDISCCODERF=@FINDLATESTDISCCODE");
			SqlParameter findParaLatestDiscCode = sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);
			findParaLatestDiscCode.Value = SqlDataMediator.SqlSetInt16(scmOdReadParamWork.LatestDiscCode);
		}

		// 更新年月日
		if (scmOdReadParamWork.UpdateDate > DateTime.MinValue)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("UPDATEDATERF>=@FINDUPDATEDATEST");
			SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATEST", SqlDbType.Int);
			findParaUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdReadParamWork.UpdateDate);
		}

		if (mode == 0)
		{
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			// SF-PM連携指示書番号
			if (!string.IsNullOrEmpty(scmOdReadParamWork.SfPmCprtInstSlipNo))
			{
				if (whereString.Length > 0) whereString.Append(" AND ");
				whereString.Append("SFPMCPRTINSTSLIPNORF=@FINDSFPMCPRTINSTSLIPNO");
				SqlParameter findParaSfPmCprtInstSlipNo = sqlCommand.Parameters.Add("@FINDSFPMCPRTINSTSLIPNO", SqlDbType.NVarChar);
				findParaSfPmCprtInstSlipNo.Value = SqlDataMediator.SqlSetString(scmOdReadParamWork.SfPmCprtInstSlipNo);
			}
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			// 問発・回答種別(1:問合せ・発注 2:回答)
			if (scmOdReadParamWork.InqOrdAnsDivCd > 0)
			{
				if (whereString.Length > 0) whereString.Append(" AND ");
				whereString.Append("INQORDANSDIVCDRF=@FINDINQORDANSDIVCD");
				SqlParameter findParaInqOrdAnsDivCd = sqlCommand.Parameters.Add("@FINDINQORDANSDIVCD", SqlDbType.Int);
				findParaInqOrdAnsDivCd.Value = SqlDataMediator.SqlSetInt32(scmOdReadParamWork.InqOrdAnsDivCd);
			}
		}

		if (whereString.Length > 0) whereString.Insert(0, " WHERE ");

		return whereString.ToString();
	}
	#endregion

	/// <summary>
	/// WHERE文作成処理(SCM受発注データ(車両情報)読込用)
	/// </summary>
	/// <param name="scmOdReadParamWork">SCM受発注読込条件クラス</param>
	/// <param name="sqlCommand">SqlCommandクラス</param>
	/// <returns>WHERE文</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データ(車両情報)読込用のWHERE文を作成します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region MakeWhereStringOfScmOdDtCar
	private string MakeWhereStringOfScmOdDtCar(string inqOriginalEpCd, string inqOriginalSecCd, List<long> inquiryNumberList, SqlCommand sqlCommand)
	{
		StringBuilder whereString = new StringBuilder();

		// 問合せ元企業コード
		if (inqOriginalEpCd != null && inqOriginalEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORIGINALEPCDRF=@FINDINQORIGINALEPCD");
			SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(inqOriginalEpCd);
		}

		// 問合せ元拠点コード
		if (inqOriginalSecCd != null && inqOriginalSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORIGINALSECCDRF=@FINDINQORIGINALSECCD");
			SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(inqOriginalSecCd);
		}

		// 問合せ番号
		if (inquiryNumberList != null && inquiryNumberList.Count > 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQUIRYNUMBERRF IN (");
			for (int ix = 0; ix != inquiryNumberList.Count; ix++)
			{
				if (ix == 0) whereString.Append(inquiryNumberList[ix]);
				else whereString.Append(string.Format(",{0}", inquiryNumberList[ix]));
			}
			whereString.Append(")");
		}

		if (whereString.Length > 0) whereString.Insert(0, " WHERE ");

		return whereString.ToString();
	}
	#endregion

	/// <summary>
	/// SCM受発注データ検索処理
	/// </summary>
	/// <param name="scmOdSrchParam">SCM受発注検索条件クラス</param>
	/// <param name="sCMAnsListSrchRstWorkArray">SCM回答一覧検索結果クラス配列</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データのSelectを行います。</br>
	/// <br>			: 分離レベルはREADUNCOMMITTEDです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region SearchScmOdrDataProc
	private int SearchScmOdrDataProc(ScmOdSrchParamWork scmOdSrchParam, out SCMAnsListSrchRstWork[] sCMAnsListSrchRstWorkArray, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

		sCMAnsListSrchRstWorkArray = null;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<SCMAnsListSrchRstWork> sCMAnsListSrchRstWorkList = new List<SCMAnsListSrchRstWork>();

			// Selectコマンドの生成
			#region 2011.05.19 TERASAKA DEL STA
//////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
////			sqlCommand = new SqlCommand("SELECT A1.CREATEDATETIMERF, A1.UPDATEDATETIMERF, A1.LOGICALDELETECODERF, A1.INQORIGINALEPCDRF, A1.INQORIGINALSECCDRF, A1.INQOTHEREPCDRF, A1.INQOTHERSECCDRF, A1.INQUIRYNUMBERRF, A1.UPDATEDATERF, A1.UPDATETIMERF, A1.ANSWERDIVCDRF, A1.INQORDNOTERF, A1.INQEMPLOYEECDRF, A1.INQEMPLOYEENMRF, A1.ANSEMPLOYEECDRF, A1.ANSEMPLOYEENMRF, A1.INQUIRYDATERF, A1.INQORDDIVCDRF, A1.INQORDANSDIVCDRF, A1.RECEIVEDATETIMERF, A2.NUMBERPLATE1CODERF, A2.NUMBERPLATE1NAMERF, A2.NUMBERPLATE2RF, A2.NUMBERPLATE3RF, A2.NUMBERPLATE4RF, A2.MODELDESIGNATIONNORF, A2.CATEGORYNORF, A2.MAKERCODERF, A2.MODELNAMERF, A2.CARINSPECTCERTMODELRF, A2.FRAMENORF, A2.FRAMEMODELRF FROM SCMODRDATARF A1", sqlConnection);
//// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//			sqlCommand = new SqlCommand("SELECT A1.CREATEDATETIMERF, A1.UPDATEDATETIMERF, A1.LOGICALDELETECODERF, A1.INQORIGINALEPCDRF, A1.INQORIGINALSECCDRF, A1.INQOTHEREPCDRF, A1.INQOTHERSECCDRF, A1.INQUIRYNUMBERRF, A1.UPDATEDATERF, A1.UPDATETIMERF, A1.ANSWERDIVCDRF, A1.INQORDNOTERF, A1.INQEMPLOYEECDRF, A1.INQEMPLOYEENMRF, A1.ANSEMPLOYEECDRF, A1.ANSEMPLOYEENMRF, A1.INQUIRYDATERF, A1.INQORDDIVCDRF, A1.INQORDANSDIVCDRF, A1.RECEIVEDATETIMERF, A1.CANCELDIVRF, A2.NUMBERPLATE1CODERF, A2.NUMBERPLATE1NAMERF, A2.NUMBERPLATE2RF, A2.NUMBERPLATE3RF, A2.NUMBERPLATE4RF, A2.MODELDESIGNATIONNORF, A2.CATEGORYNORF, A2.MAKERCODERF, A2.MODELNAMERF, A2.CARINSPECTCERTMODELRF, A2.FRAMENORF, A2.FRAMEMODELRF FROM SCMODRDATARF A1", sqlConnection);
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
//			// 分離レベルの設定
//			sqlCommand.CommandText += " WITH(READUNCOMMITTED)";
//			// Join文の追加
//			sqlCommand.CommandText += " LEFT JOIN SCMODDTCARRF A2 ON A1.INQORIGINALEPCDRF=A2.INQORIGINALEPCDRF AND A1.INQORIGINALSECCDRF=A2.INQORIGINALSECCDRF AND A1.INQUIRYNUMBERRF=A2.INQUIRYNUMBERRF";
//			// Where文の追加
//			sqlCommand.CommandText += MakeSrchWhereStringOfScmOdrData(scmOdSrchParam, sqlCommand);
			#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			sqlCommand = new SqlCommand(string.Empty, sqlConnection);

			sqlCommand.CommandText = "SELECT A1.CREATEDATETIMERF, A1.UPDATEDATETIMERF, A1.LOGICALDELETECODERF, A1.INQORIGINALEPCDRF, A1.INQORIGINALSECCDRF, A1.INQOTHEREPCDRF, A1.INQOTHERSECCDRF, A1.INQUIRYNUMBERRF, A1.UPDATEDATERF, A1.UPDATETIMERF, A1.ANSWERDIVCDRF, A1.INQORDNOTERF, A1.INQEMPLOYEECDRF, A1.INQEMPLOYEENMRF, A1.ANSEMPLOYEECDRF, A1.ANSEMPLOYEENMRF, A1.INQUIRYDATERF, A1.INQORDDIVCDRF, A1.INQORDANSDIVCDRF, A1.RECEIVEDATETIMERF, A1.CANCELDIVRF, A2.NUMBERPLATE1CODERF, A2.NUMBERPLATE1NAMERF, A2.NUMBERPLATE2RF, A2.NUMBERPLATE3RF, A2.NUMBERPLATE4RF, A2.MODELDESIGNATIONNORF, A2.CATEGORYNORF, A2.MAKERCODERF, A2.MODELNAMERF, A2.CARINSPECTCERTMODELRF, A2.FRAMENORF, A2.FRAMEMODELRF, A1.JUDGEMENTDATERF"
                //+ ", A1.SFPMCPRTINSTSLIPNORF"   // 2011.08.10 huangqb DEL
                + ", A1.SFPMCPRTINSTSLIPNORF, A1.ACCEPTORORDERKINDRF " // 2011.08.10 huangqb ADD
				+ " FROM SCMODRDATARF A1"
				+ " WITH(READUNCOMMITTED)"
				+ " LEFT JOIN SCMODDTCARRF A2 ON A1.INQORIGINALEPCDRF=A2.INQORIGINALEPCDRF AND A1.INQORIGINALSECCDRF=A2.INQORIGINALSECCDRF AND A1.INQUIRYNUMBERRF=A2.INQUIRYNUMBERRF"
				+ MakeSrchWhereStringOfScmOdrData(scmOdSrchParam, sqlCommand);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
		
			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);

			myReader = sqlCommand.ExecuteReader();
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
			#region カラムインデックスの取得
			int colIndex_CreateDateTime			= 0;
			int colIndex_UpdateDateTime			= 0;
			int colIndex_LogicalDeleteCode		= 0;
			int colIndex_InqOriginalEpCd		= 0;
			int colIndex_InqOriginalSecCd		= 0;
			int colIndex_InqOtherEpCd			= 0;
			int colIndex_InqOtherSecCd			= 0;
			int colIndex_InquiryNumber			= 0;
			int colIndex_UpdateDate				= 0;
			int colIndex_UpdateTime				= 0;
			int colIndex_AnswerDivCd			= 0;
			int colIndex_InqOrdNote				= 0;
			int colIndex_InqEmployeeCd			= 0;
			int colIndex_InqEmployeeNm			= 0;
			int colIndex_AnsEmployeeCd			= 0;
			int colIndex_AnsEmployeeNm			= 0;
			int colIndex_InquiryDate			= 0;
			int colIndex_InqOrdDivCd			= 0;
			int colIndex_NumberPlate1Code		= 0;
			int colIndex_NumberPlate1Name		= 0;
			int colIndex_NumberPlate2			= 0;
			int colIndex_NumberPlate3			= 0;
			int colIndex_NumberPlate4			= 0;
			int colIndex_ModelDesignationNo		= 0;
			int colIndex_CategoryNo				= 0;
			int colIndex_MakerCode				= 0;
			int colIndex_ModelName				= 0;
			int colIndex_CarInspectCertModel	= 0;
			int colIndex_FrameNo				= 0;
			int colIndex_FrameModel				= 0;
			int colIndex_InqOrdAnsDivCd			= 0;
			int colIndex_ReceiveDateTime		= 0;
			int colIndex_CancelDiv				= 0;
			int colIndex_JudgementDate			= 0;
			int colIndex_SfPmCprtInstSlipNo		= 0;
            int colIndex_AcceptOrOrderKind      = 0;// 2011.08.10 huangqb ADD

			if (myReader.HasRows)
			{
				colIndex_CreateDateTime			= myReader.GetOrdinal("CREATEDATETIMERF");
				colIndex_UpdateDateTime			= myReader.GetOrdinal("UPDATEDATETIMERF");
				colIndex_LogicalDeleteCode		= myReader.GetOrdinal("LOGICALDELETECODERF");
				colIndex_InqOriginalEpCd		= myReader.GetOrdinal("INQORIGINALEPCDRF");
				colIndex_InqOriginalSecCd		= myReader.GetOrdinal("INQORIGINALSECCDRF");
				colIndex_InqOtherEpCd			= myReader.GetOrdinal("INQOTHEREPCDRF");
				colIndex_InqOtherSecCd			= myReader.GetOrdinal("INQOTHERSECCDRF");
				colIndex_InquiryNumber			= myReader.GetOrdinal("INQUIRYNUMBERRF");
				colIndex_UpdateDate				= myReader.GetOrdinal("UPDATEDATERF");
				colIndex_UpdateTime				= myReader.GetOrdinal("UPDATETIMERF");
				colIndex_AnswerDivCd			= myReader.GetOrdinal("ANSWERDIVCDRF");
				colIndex_InqOrdNote				= myReader.GetOrdinal("INQORDNOTERF");
				colIndex_InqEmployeeCd			= myReader.GetOrdinal("INQEMPLOYEECDRF");
				colIndex_InqEmployeeNm			= myReader.GetOrdinal("INQEMPLOYEENMRF");
				colIndex_AnsEmployeeCd			= myReader.GetOrdinal("ANSEMPLOYEECDRF");
				colIndex_AnsEmployeeNm			= myReader.GetOrdinal("ANSEMPLOYEENMRF");
				colIndex_InquiryDate			= myReader.GetOrdinal("INQUIRYDATERF");
				colIndex_InqOrdDivCd			= myReader.GetOrdinal("INQORDDIVCDRF");
				colIndex_NumberPlate1Code		= myReader.GetOrdinal("NUMBERPLATE1CODERF");
				colIndex_NumberPlate1Name		= myReader.GetOrdinal("NUMBERPLATE1NAMERF");
				colIndex_NumberPlate2			= myReader.GetOrdinal("NUMBERPLATE2RF");
				colIndex_NumberPlate3			= myReader.GetOrdinal("NUMBERPLATE3RF");
				colIndex_NumberPlate4			= myReader.GetOrdinal("NUMBERPLATE4RF");
				colIndex_ModelDesignationNo		= myReader.GetOrdinal("MODELDESIGNATIONNORF");
				colIndex_CategoryNo				= myReader.GetOrdinal("CATEGORYNORF");
				colIndex_MakerCode				= myReader.GetOrdinal("MAKERCODERF");
				colIndex_ModelName				= myReader.GetOrdinal("MODELNAMERF");
				colIndex_CarInspectCertModel	= myReader.GetOrdinal("CARINSPECTCERTMODELRF");
				colIndex_FrameNo				= myReader.GetOrdinal("FRAMENORF");
				colIndex_FrameModel				= myReader.GetOrdinal("FRAMEMODELRF");
				colIndex_InqOrdAnsDivCd			= myReader.GetOrdinal("INQORDANSDIVCDRF");
				colIndex_ReceiveDateTime		= myReader.GetOrdinal("RECEIVEDATETIMERF");
				colIndex_CancelDiv				= myReader.GetOrdinal("CANCELDIVRF");
				colIndex_JudgementDate			= myReader.GetOrdinal("JUDGEMENTDATERF");
				colIndex_SfPmCprtInstSlipNo		= myReader.GetOrdinal("SFPMCPRTINSTSLIPNORF");
                colIndex_AcceptOrOrderKind      = myReader.GetOrdinal("ACCEPTORORDERKINDRF"); // 2011.08.10 huangqb ADD
			}
			#endregion
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
			while (myReader.Read())
			{
				SCMAnsListSrchRstWork sCMAnsListSrchRstWork = new SCMAnsListSrchRstWork();

				#region データのコピー
				#region 2011.05.19 TERASAKA DEL STA
//				sCMAnsListSrchRstWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
//				sCMAnsListSrchRstWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
//				sCMAnsListSrchRstWork.LogicalDeleteCode		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
//				sCMAnsListSrchRstWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
//				sCMAnsListSrchRstWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
//				sCMAnsListSrchRstWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
//				sCMAnsListSrchRstWork.InqOtherSecCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
//				sCMAnsListSrchRstWork.InquiryNumber			= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
//				sCMAnsListSrchRstWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
//				sCMAnsListSrchRstWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
//				sCMAnsListSrchRstWork.AnswerDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERDIVCDRF"));
//				sCMAnsListSrchRstWork.InqOrdNote			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORDNOTERF"));
//				sCMAnsListSrchRstWork.InqEmployeeCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEECDRF"));
//				sCMAnsListSrchRstWork.InqEmployeeNm			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQEMPLOYEENMRF"));
//				sCMAnsListSrchRstWork.AnsEmployeeCd			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEECDRF"));
//				sCMAnsListSrchRstWork.AnsEmployeeNm			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSEMPLOYEENMRF"));
//				sCMAnsListSrchRstWork.InquiryDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INQUIRYDATERF"));
//				sCMAnsListSrchRstWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));
//				sCMAnsListSrchRstWork.NumberPlate1Code		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
//				sCMAnsListSrchRstWork.NumberPlate1Name		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
//				sCMAnsListSrchRstWork.NumberPlate2			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
//				sCMAnsListSrchRstWork.NumberPlate3			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
//				sCMAnsListSrchRstWork.NumberPlate4			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
//				sCMAnsListSrchRstWork.ModelDesignationNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
//				sCMAnsListSrchRstWork.CategoryNo			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
//				sCMAnsListSrchRstWork.MakerCode				= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
//				sCMAnsListSrchRstWork.ModelName				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELNAMERF"));
//				sCMAnsListSrchRstWork.CarInspectCertModel	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARINSPECTCERTMODELRF"));
//				sCMAnsListSrchRstWork.FrameNo				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
//				sCMAnsListSrchRstWork.FrameModel			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
//				sCMAnsListSrchRstWork.InqOrdAnsDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDANSDIVCDRF"));
//				sCMAnsListSrchRstWork.ReceiveDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECEIVEDATETIMERF"));
//////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
//				sCMAnsListSrchRstWork.CancelDiv				= SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("CANCELDIVRF"));
//// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
				#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				sCMAnsListSrchRstWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
				sCMAnsListSrchRstWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
				sCMAnsListSrchRstWork.LogicalDeleteCode		= SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
				sCMAnsListSrchRstWork.InqOriginalEpCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
				sCMAnsListSrchRstWork.InqOriginalSecCd		= SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
				sCMAnsListSrchRstWork.InqOtherEpCd			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
				sCMAnsListSrchRstWork.InqOtherSecCd			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
				sCMAnsListSrchRstWork.InquiryNumber			= SqlDataMediator.SqlGetInt64(myReader, colIndex_InquiryNumber);
				sCMAnsListSrchRstWork.UpdateDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_UpdateDate);
				sCMAnsListSrchRstWork.UpdateTime			= SqlDataMediator.SqlGetInt32(myReader, colIndex_UpdateTime);
				sCMAnsListSrchRstWork.AnswerDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_AnswerDivCd);
				sCMAnsListSrchRstWork.InqOrdNote			= SqlDataMediator.SqlGetString(myReader, colIndex_InqOrdNote);
				sCMAnsListSrchRstWork.InqEmployeeCd			= SqlDataMediator.SqlGetString(myReader, colIndex_InqEmployeeCd);
				sCMAnsListSrchRstWork.InqEmployeeNm			= SqlDataMediator.SqlGetString(myReader, colIndex_InqEmployeeNm);
				sCMAnsListSrchRstWork.AnsEmployeeCd			= SqlDataMediator.SqlGetString(myReader, colIndex_AnsEmployeeCd);
				sCMAnsListSrchRstWork.AnsEmployeeNm			= SqlDataMediator.SqlGetString(myReader, colIndex_AnsEmployeeNm);
				sCMAnsListSrchRstWork.InquiryDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_InquiryDate);
				sCMAnsListSrchRstWork.InqOrdDivCd			= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOrdDivCd);
				sCMAnsListSrchRstWork.NumberPlate1Code		= SqlDataMediator.SqlGetInt32(myReader, colIndex_NumberPlate1Code);
				sCMAnsListSrchRstWork.NumberPlate1Name		= SqlDataMediator.SqlGetString(myReader, colIndex_NumberPlate1Name);
				sCMAnsListSrchRstWork.NumberPlate2			= SqlDataMediator.SqlGetString(myReader, colIndex_NumberPlate2);
				sCMAnsListSrchRstWork.NumberPlate3			= SqlDataMediator.SqlGetString(myReader, colIndex_NumberPlate3);
				sCMAnsListSrchRstWork.NumberPlate4			= SqlDataMediator.SqlGetInt32(myReader, colIndex_NumberPlate4);
				sCMAnsListSrchRstWork.ModelDesignationNo	= SqlDataMediator.SqlGetInt32(myReader, colIndex_ModelDesignationNo);
				sCMAnsListSrchRstWork.CategoryNo			= SqlDataMediator.SqlGetInt32(myReader, colIndex_CategoryNo);
				sCMAnsListSrchRstWork.MakerCode				= SqlDataMediator.SqlGetInt32(myReader, colIndex_MakerCode);
				sCMAnsListSrchRstWork.ModelName				= SqlDataMediator.SqlGetString(myReader, colIndex_ModelName);
				sCMAnsListSrchRstWork.CarInspectCertModel	= SqlDataMediator.SqlGetString(myReader, colIndex_CarInspectCertModel);
				sCMAnsListSrchRstWork.FrameNo				= SqlDataMediator.SqlGetString(myReader, colIndex_FrameNo);
				sCMAnsListSrchRstWork.FrameModel			= SqlDataMediator.SqlGetString(myReader, colIndex_FrameModel);
				sCMAnsListSrchRstWork.InqOrdAnsDivCd		= SqlDataMediator.SqlGetInt32(myReader, colIndex_InqOrdAnsDivCd);
				sCMAnsListSrchRstWork.ReceiveDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_ReceiveDateTime);
				sCMAnsListSrchRstWork.CancelDiv				= SqlDataMediator.SqlGetInt16(myReader, colIndex_CancelDiv);
				sCMAnsListSrchRstWork.JudgementDate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, colIndex_JudgementDate);
				sCMAnsListSrchRstWork.SfPmCprtInstSlipNo	= SqlDataMediator.SqlGetString(myReader, colIndex_SfPmCprtInstSlipNo);
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////
                sCMAnsListSrchRstWork.AcceptOrOrderKind     = SqlDataMediator.SqlGetInt16(myReader, colIndex_AcceptOrOrderKind);// 2011.08.10 huangqb ADD
				#endregion

				// 検索条件に更新時分秒ミリ秒がある場合は同一日のデータのみ比較対象とする
				#region 2011.05.19 TERASAKA DEL STA
//				if (scmOdSrchParam.UpdateTime > 0 &&
//					sCMAnsListSrchRstWork.UpdateDate == scmOdSrchParam.UpdateDate &&
//					sCMAnsListSrchRstWork.UpdateTime <= scmOdSrchParam.UpdateTime)
//					continue;
				#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
				if (scmOdSrchParam.UpdateTimeSt > 0 &&
					sCMAnsListSrchRstWork.UpdateDate == scmOdSrchParam.UpdateDateSt &&
					sCMAnsListSrchRstWork.UpdateTime <= scmOdSrchParam.UpdateTimeSt)
					continue;

				if (scmOdSrchParam.UpdateTimeEd > 0 &&
					sCMAnsListSrchRstWork.UpdateDate == scmOdSrchParam.UpdateDateEd &&
					sCMAnsListSrchRstWork.UpdateTime >= scmOdSrchParam.UpdateTimeEd)
					continue;
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

				// 検索条件に問合せ番号(配列)が指定されている場合は
				// クエリで取得したデータが問合せ番号(範囲指定)内のデータかをチェックする
				if (scmOdSrchParam.InquiryNumber != null && scmOdSrchParam.InquiryNumber.Length > 0)
				{
					if (scmOdSrchParam.InquiryNumberSt != 0 &&
						sCMAnsListSrchRstWork.InquiryNumber < scmOdSrchParam.InquiryNumberSt)
						continue;

					if (scmOdSrchParam.InquiryNumberEd != 0 &&
						sCMAnsListSrchRstWork.InquiryNumber > scmOdSrchParam.InquiryNumberEd)
						continue;
				}

				sCMAnsListSrchRstWorkList.Add(sCMAnsListSrchRstWork);
			}
			if (!myReader.IsClosed) myReader.Close();

			if (sCMAnsListSrchRstWorkList.Count > 0)
			{
				sCMAnsListSrchRstWorkArray = sCMAnsListSrchRstWorkList.ToArray();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

	/// <summary>
	/// WHERE文作成処理(SCM受発注データ検索用)
	/// </summary>
	/// <param name="scmOdSrchParam">SCM受発注検索条件クラス</param>
	/// <param name="sqlCommand">SqlCommandクラス</param>
	/// <returns>WHERE文</returns>
	/// <remarks>
	/// <br>Note		: SCM受発注データ検索用のWHERE文を作成します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region MakeSrchWhereStringOfScmOdrData
	private string MakeSrchWhereStringOfScmOdrData(ScmOdSrchParamWork scmOdSrchParam, SqlCommand sqlCommand)
	{
		StringBuilder whereString = new StringBuilder();

		// 問合せ元企業コード
		if (scmOdSrchParam.InqOriginalEpCd != null && scmOdSrchParam.InqOriginalEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQORIGINALEPCDRF=@FINDINQORIGINALEPCD");
			SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.InqOriginalEpCd);
		}

		// 問合せ元拠点コード
		if (scmOdSrchParam.InqOriginalSecCd != null && scmOdSrchParam.InqOriginalSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQORIGINALSECCDRF=@FINDINQORIGINALSECCD");
			SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.InqOriginalSecCd);
		}

		// 問合せ先企業コード
		if (scmOdSrchParam.InqOtherEpCd != null && scmOdSrchParam.InqOtherEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQOTHEREPCDRF=@FINDINQOTHEREPCD");
			SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.InqOtherEpCd);
		}

		// 問合せ先拠点コード
		if (scmOdSrchParam.InqOtherSecCd != null && scmOdSrchParam.InqOtherSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQOTHERSECCDRF=@FINDINQOTHERSECCD");
			SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.InqOtherSecCd);
		}

		// 問合せ番号
		if (scmOdSrchParam.InquiryNumber != null && scmOdSrchParam.InquiryNumber.Length > 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQUIRYNUMBERRF IN (");
			for (int ix = 0; ix != scmOdSrchParam.InquiryNumber.Length; ix++)
			{
				if (ix == 0) whereString.Append(scmOdSrchParam.InquiryNumber[ix]);
				else whereString.Append(string.Format(",{0}", scmOdSrchParam.InquiryNumber[ix]));
			}
			whereString.Append(")");
		}
		else
		{
			// 問合せ番号（開始）
			if (scmOdSrchParam.InquiryNumberSt > 0)
			{
				if (whereString.Length > 0) whereString.Append(" AND ");
				whereString.Append("A1.INQUIRYNUMBERRF>=@FINDINQUIRYNUMBERST");
				SqlParameter findParaInquiryNumberSt = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBERST", SqlDbType.BigInt);
				findParaInquiryNumberSt.Value = SqlDataMediator.SqlSetInt64(scmOdSrchParam.InquiryNumberSt);
			}

			// 問合せ番号（終了）
			if (scmOdSrchParam.InquiryNumberEd > 0)
			{
				if (whereString.Length > 0) whereString.Append(" AND ");
				whereString.Append("A1.INQUIRYNUMBERRF<=@FINDINQUIRYNUMBERED");
				SqlParameter findParaInquiryNumberEd = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBERED", SqlDbType.BigInt);
				findParaInquiryNumberEd.Value = SqlDataMediator.SqlSetInt64(scmOdSrchParam.InquiryNumberEd);
			}
		}

		#region 2011.05.19 TERASAKA DEL STA
//		// 更新年月日
//		if (scmOdSrchParam.UpdateDate > DateTime.MinValue)
//		{
//			if (whereString.Length > 0) whereString.Append(" AND ");
//			whereString.Append("A1.UPDATEDATERF>=@FINDUPDATEDATEST");
//			SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATEST", SqlDbType.Int);
//			findParaUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdSrchParam.UpdateDate);
//		}
		#endregion
////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
		// 更新年月日（開始）
		if (scmOdSrchParam.UpdateDateSt > DateTime.MinValue)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.UPDATEDATERF>=@FINDUPDATEDATEST");
			SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATEST", SqlDbType.Int);
			findParaUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdSrchParam.UpdateDateSt);
		}

		// 更新年月日（終了）
		if (scmOdSrchParam.UpdateDateEd > DateTime.MinValue)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.UPDATEDATERF<=@FINDUPDATEDATEED");
			SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATEED", SqlDbType.Int);
			findParaUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmOdSrchParam.UpdateDateEd);
		}
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

////////////////////////////////////////////// 2011.05.19 TERASAKA ADD STA //
		// SF-PM連携指示書番号
		if (!string.IsNullOrEmpty(scmOdSrchParam.SfPmCprtInstSlipNo))
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("SFPMCPRTINSTSLIPNORF=@FINDSFPMCPRTINSTSLIPNO");
			SqlParameter findParaSfPmCprtInstSlipNo = sqlCommand.Parameters.Add("@FINDSFPMCPRTINSTSLIPNO", SqlDbType.NVarChar);
			findParaSfPmCprtInstSlipNo.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.SfPmCprtInstSlipNo);
		}

		// 取引完了区分(0:未完了,1:完了)
		if (scmOdSrchParam.TransCmpltDivCd == 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("(JUDGEMENTDATERF<=@FINDJUDGEMENTDATE OR JUDGEMENTDATERF IS NULL)");
			SqlParameter findParaJudgementDate = sqlCommand.Parameters.Add("@FINDJUDGEMENTDATE", SqlDbType.Int);
			findParaJudgementDate.Value = 10101;
		}
// 2011.05.19 TERASAKA ADD END //////////////////////////////////////////////

		// 問合せ従業員コード
		if (scmOdSrchParam.InqEmployeeCd != null && scmOdSrchParam.InqEmployeeCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQEMPLOYEECDRF=@FINDINQEMPLOYEECD");
			SqlParameter findParaInqEmployeeCd = sqlCommand.Parameters.Add("@FINDINQEMPLOYEECD", SqlDbType.NChar);
			findParaInqEmployeeCd.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.InqEmployeeCd);
		}

		// 回答従業員コード
		if (scmOdSrchParam.AnsEmployeeCd != null && scmOdSrchParam.AnsEmployeeCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.ANSEMPLOYEECDRF=@FINDANSEMPLOYEECD");
			SqlParameter findParaAnsEmployeeCd = sqlCommand.Parameters.Add("@FINDANSEMPLOYEECD", SqlDbType.NChar);
			findParaAnsEmployeeCd.Value = SqlDataMediator.SqlSetString(scmOdSrchParam.AnsEmployeeCd);
		}

		// 問合せ・発注種別(1:問合せ 2:発注)
		if (scmOdSrchParam.InqOrdDivCd > 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.INQORDDIVCDRF=@FINDINQORDDIVCD");
			SqlParameter findParaInqOrdDivCd = sqlCommand.Parameters.Add("@FINDINQORDDIVCD", SqlDbType.Int);
			findParaInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(scmOdSrchParam.InqOrdDivCd);
		}

		// 最新識別区分(-1:指定無し 0:最新データ 1:旧データ)
		if (scmOdSrchParam.LatestDiscCode >= 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("A1.LATESTDISCCODERF=@FINDLATESTDISCCODE");
			SqlParameter findParaLatestDiscCode = sqlCommand.Parameters.Add("@FINDLATESTDISCCODE", SqlDbType.SmallInt);
			findParaLatestDiscCode.Value = SqlDataMediator.SqlSetInt16(scmOdSrchParam.LatestDiscCode);
		}

		if (whereString.Length > 0) whereString.Insert(0, " WHERE ");

		return whereString.ToString();
	}
	#endregion

	/// <summary>
	/// 最新SCM受発注データ件数取得処理
	/// </summary>
	/// <param name="scmPopParamWork">SCMポップアップ条件クラス</param>
	/// <param name="scmPopParamDtlWorkArray">SCMポップアップ条件クラス(明細)配列</param>
	/// <param name="count">最新問合せ番号件数</param>
	/// <param name="rowCount">最新レコード件数</param>
	/// <param name="lateUpdateDate">最新更新年月日</param>
	/// <param name="lateUpdateTime">最新更新時分秒ミリ秒</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 検索条件より新しいSCM受発注データのCount取得を行います。</br>
	/// <br>			: 分離レベルはREADUNCOMMITTEDです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region SearchCntScmOdrDataProc
	private int SearchCntScmOdrDataProc(ScmPopParamWork scmPopParamWork, ScmPopParamDtlWork[] scmPopParamDtlWorkArray, out int count, out int rowCount, out DateTime lateUpdateDate, out int lateUpdateTime, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

		count = 0;
		rowCount = 0;
		lateUpdateDate = DateTime.MinValue;
		lateUpdateTime = 0;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<long> inquiryNumberList = new List<long>();
			List<ScmOdrDataWork> scmOdrDataWorkList = new List<ScmOdrDataWork>();

			List<ScmPopParamDtlWork> scmPopParamDtlWorkList = new List<ScmPopParamDtlWork>(scmPopParamDtlWorkArray);
			
			// Selectコマンドの生成
			sqlCommand = new SqlCommand("SELECT INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF FROM SCMODRDATARF", sqlConnection);
			// 分離レベルの設定
			sqlCommand.CommandText += " WITH(READUNCOMMITTED)";
			// Where文の追加
			sqlCommand.CommandText += MakePopWhereString(scmPopParamWork, sqlCommand);
		
			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);

			myReader = sqlCommand.ExecuteReader();
			while (myReader.Read())
			{
				ScmOdrDataWork scmOdrDataWork = new ScmOdrDataWork();
				
				#region データのコピー
				scmOdrDataWork.InqOriginalEpCd	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
				scmOdrDataWork.InqOriginalSecCd	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
				scmOdrDataWork.InqOtherEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
				scmOdrDataWork.InqOtherSecCd	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
				scmOdrDataWork.InquiryNumber	= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
				scmOdrDataWork.UpdateDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
				scmOdrDataWork.UpdateTime		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
				#endregion

				// 検索条件に更新時分秒ミリ秒がある場合は同一日のデータのみ比較対象とする
				if (scmPopParamWork.UpdateTime > 0 &&
					scmOdrDataWork.UpdateDate == scmPopParamWork.UpdateDate &&
					scmOdrDataWork.UpdateTime <= scmPopParamWork.UpdateTime)
					continue;

				if (!scmPopParamDtlWorkList.Exists(
					delegate(ScmPopParamDtlWork scmPopParamDtlWork)
					{
						if (scmPopParamDtlWork.InqOriginalEpCd == scmOdrDataWork.InqOriginalEpCd &&
							scmPopParamDtlWork.InqOriginalSecCd == scmOdrDataWork.InqOriginalSecCd &&
							scmPopParamDtlWork.InqOtherEpCd == scmOdrDataWork.InqOtherEpCd &&
							scmPopParamDtlWork.InqOtherSecCd == scmOdrDataWork.InqOtherSecCd &&
							scmPopParamDtlWork.InquiryNumber == scmOdrDataWork.InquiryNumber)
							return true;
						else
							return false;
					}))
				{
					// 問合せ番号が検索条件に含まれていない≒初めて追加されたデータの件数
					rowCount++;
					if (!inquiryNumberList.Contains(scmOdrDataWork.InquiryNumber))
					{
						count++;
						inquiryNumberList.Add(scmOdrDataWork.InquiryNumber);
					}

					// 最新日付を確保する
					if (scmOdrDataWork.UpdateDate > lateUpdateDate)
					{
						lateUpdateDate	= scmOdrDataWork.UpdateDate;
						lateUpdateTime	= scmOdrDataWork.UpdateTime;
					}
					else if (scmOdrDataWork.UpdateDate == lateUpdateDate && scmOdrDataWork.UpdateTime > lateUpdateTime)
					{
						lateUpdateDate	= scmOdrDataWork.UpdateDate;
						lateUpdateTime	= scmOdrDataWork.UpdateTime;
					}
				}
				else
				{
					scmOdrDataWorkList.Add(scmOdrDataWork);
				}
			}
			if (!myReader.IsClosed) myReader.Close();

			foreach (ScmPopParamDtlWork scmPopParamDtlWork in scmPopParamDtlWorkArray)
			{
				List<ScmOdrDataWork> wkList
					= scmOdrDataWorkList.FindAll(
						delegate(ScmOdrDataWork scmOdrDataWork)
						{
							// 問合せ番号が一致
							if (scmOdrDataWork.InqOriginalEpCd == scmPopParamDtlWork.InqOriginalEpCd &&
								scmOdrDataWork.InqOriginalSecCd == scmPopParamDtlWork.InqOriginalSecCd &&
								scmOdrDataWork.InqOtherEpCd == scmPopParamDtlWork.InqOtherEpCd &&
								scmOdrDataWork.InqOtherSecCd == scmPopParamDtlWork.InqOtherSecCd &&
								scmOdrDataWork.InquiryNumber == scmPopParamDtlWork.InquiryNumber)
							{
								// 日付が指定よりも新しいもの
								if (scmOdrDataWork.UpdateDate > scmPopParamDtlWork.UpdateDate)
									return true;
								else if (scmOdrDataWork.UpdateDate == scmPopParamDtlWork.UpdateDate &&
									scmOdrDataWork.UpdateTime > scmPopParamDtlWork.UpdateTime)
									return true;
								else
									return false;
							}
							else
							{
								return false;
							}
						}
					);
				if (wkList != null && wkList.Count > 0)
				{
					// 検索条件よりも新しいデータの件数
					rowCount += wkList.Count;
					if (!inquiryNumberList.Contains(scmPopParamDtlWork.InquiryNumber))
					{
						count++;
						inquiryNumberList.Add(scmPopParamDtlWork.InquiryNumber);
					}

					// 最新日付を確保する
					foreach (ScmOdrDataWork scmOdrDataWork in wkList)
					{
						if (scmOdrDataWork.UpdateDate > lateUpdateDate)
						{
							lateUpdateDate	= scmOdrDataWork.UpdateDate;
							lateUpdateTime	= scmOdrDataWork.UpdateTime;
						}
						else if (scmOdrDataWork.UpdateDate == lateUpdateDate && scmOdrDataWork.UpdateTime > lateUpdateTime)
						{
							lateUpdateDate	= scmOdrDataWork.UpdateDate;
							lateUpdateTime	= scmOdrDataWork.UpdateTime;
						}
					}
				}
			}

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion

////////////////////////////////////////////// 2010.02.26 TERASAKA ADD STA //
	/// <summary>
	/// 最新SCM受発注データ取得処理
	/// </summary>
	/// <param name="scmPopParamWork">SCMポップアップ条件クラス</param>
	/// <param name="scmPopParamDtlWorkArray">SCMポップアップ条件クラス(明細)配列</param>
	/// <param name="retDataList">最新レコード取得結果リスト</param>
	/// <param name="sqlConnection">SqlConnectionクラス</param>
	/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
	/// <remarks>
	/// <br>Note		: 検索条件より新しいSCM受発注データの取得を行います。</br>
	/// <br>			: 分離レベルはREADUNCOMMITTEDです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2010.02.26</br>
	/// </remarks>
	#region SearchScmOdrDataForPopProc
	private int SearchScmOdrDataForPopProc(ScmPopParamWork scmPopParamWork, ScmPopParamDtlWork[] scmPopParamDtlWorkArray, out ScmOdrDataWork[] scmOdrDataWorkArray, SqlConnection sqlConnection)
	{
		int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

		scmOdrDataWorkArray = null;

		SqlDataReader myReader = null;
		SqlCommand sqlCommand = null;
		try
		{
			List<ScmOdrDataWork> retDataList = new List<ScmOdrDataWork>();

			List<long> inquiryNumberList = new List<long>();
			List<ScmOdrDataWork> scmOdrDataWorkList = new List<ScmOdrDataWork>();

			List<ScmPopParamDtlWork> scmPopParamDtlWorkList = new List<ScmPopParamDtlWork>(scmPopParamDtlWorkArray);
			
			// Selectコマンドの生成
////////////////////////////////////////////// 2010.05.31 TERASAKA DEL STA //
//			sqlCommand = new SqlCommand("SELECT INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF FROM SCMODRDATARF", sqlConnection);
// 2010.05.31 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
            //sqlCommand = new SqlCommand("SELECT INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, CANCELDIVRF, CMTCOOPRTDIVRF FROM SCMODRDATARF", sqlConnection); // 2011.08.10 huangqb DEL
// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
            sqlCommand = new SqlCommand("SELECT INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, INQUIRYNUMBERRF, UPDATEDATERF, UPDATETIMERF, CANCELDIVRF, CMTCOOPRTDIVRF, ACCEPTORORDERKINDRF  FROM SCMODRDATARF", sqlConnection); // 2011.08.10 huangqb ADD
			// 分離レベルの設定
			sqlCommand.CommandText += " WITH(READUNCOMMITTED)";
			// Where文の追加
			sqlCommand.CommandText += MakePopWhereString(scmPopParamWork, sqlCommand);
		
			// タイムアウト時間設定
			sqlCommand.CommandTimeout = WebRemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);

			myReader = sqlCommand.ExecuteReader();
			while (myReader.Read())
			{
				ScmOdrDataWork scmOdrDataWork = new ScmOdrDataWork();
				
				#region データのコピー
				scmOdrDataWork.InqOriginalEpCd	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
				scmOdrDataWork.InqOriginalSecCd	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
				scmOdrDataWork.InqOtherEpCd		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
				scmOdrDataWork.InqOtherSecCd	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
				scmOdrDataWork.InquiryNumber	= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
				scmOdrDataWork.UpdateDate		= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
				scmOdrDataWork.UpdateTime		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATETIMERF"));
////////////////////////////////////////////// 2010.05.31 TERASAKA ADD STA //
				scmOdrDataWork.CancelDiv		= SqlDataMediator.SqlGetInt16(myReader,myReader.GetOrdinal("CANCELDIVRF"));
				scmOdrDataWork.CMTCooprtDiv		= SqlDataMediator.SqlGetInt16(myReader,myReader.GetOrdinal("CMTCOOPRTDIVRF"));
// 2010.05.31 TERASAKA ADD END //////////////////////////////////////////////
                scmOdrDataWork.AcceptOrOrderKind = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF")); // 2011.08.10 huangqb ADD
				#endregion

				// 検索条件に更新時分秒ミリ秒がある場合は同一日のデータのみ比較対象とする
				if (scmPopParamWork.UpdateTime > 0 &&
					scmOdrDataWork.UpdateDate == scmPopParamWork.UpdateDate &&
					scmOdrDataWork.UpdateTime <= scmPopParamWork.UpdateTime)
					continue;

				if (!scmPopParamDtlWorkList.Exists(
					delegate(ScmPopParamDtlWork scmPopParamDtlWork)
					{
						if (scmPopParamDtlWork.InqOriginalEpCd == scmOdrDataWork.InqOriginalEpCd &&
							scmPopParamDtlWork.InqOriginalSecCd == scmOdrDataWork.InqOriginalSecCd &&
							scmPopParamDtlWork.InqOtherEpCd == scmOdrDataWork.InqOtherEpCd &&
							scmPopParamDtlWork.InqOtherSecCd == scmOdrDataWork.InqOtherSecCd &&
							scmPopParamDtlWork.InquiryNumber == scmOdrDataWork.InquiryNumber)
							return true;
						else
							return false;
					}))
				{
					// 問合せ番号が検索条件に含まれていない≒初めて追加されたデータの件数
					if (!inquiryNumberList.Contains(scmOdrDataWork.InquiryNumber))
					{
						retDataList.Add(scmOdrDataWork);
						inquiryNumberList.Add(scmOdrDataWork.InquiryNumber);
					}
				}
				else
				{
					scmOdrDataWorkList.Add(scmOdrDataWork);
				}
			}
			if (!myReader.IsClosed) myReader.Close();

			foreach (ScmPopParamDtlWork scmPopParamDtlWork in scmPopParamDtlWorkArray)
			{
				List<ScmOdrDataWork> wkList
					= scmOdrDataWorkList.FindAll(
						delegate(ScmOdrDataWork scmOdrDataWork)
						{
							// 問合せ番号が一致
							if (scmOdrDataWork.InqOriginalEpCd == scmPopParamDtlWork.InqOriginalEpCd &&
								scmOdrDataWork.InqOriginalSecCd == scmPopParamDtlWork.InqOriginalSecCd &&
								scmOdrDataWork.InqOtherEpCd == scmPopParamDtlWork.InqOtherEpCd &&
								scmOdrDataWork.InqOtherSecCd == scmPopParamDtlWork.InqOtherSecCd &&
								scmOdrDataWork.InquiryNumber == scmPopParamDtlWork.InquiryNumber)
							{
								// 日付が指定よりも新しいもの
								if (scmOdrDataWork.UpdateDate > scmPopParamDtlWork.UpdateDate)
									return true;
								else if (scmOdrDataWork.UpdateDate == scmPopParamDtlWork.UpdateDate &&
									scmOdrDataWork.UpdateTime > scmPopParamDtlWork.UpdateTime)
									return true;
								else
									return false;
							}
							else
							{
								return false;
							}
						}
					);
				if (wkList != null && wkList.Count > 0)
				{
					if (!inquiryNumberList.Contains(scmPopParamDtlWork.InquiryNumber))
					{
						// 最新データのみを確保する
						ScmOdrDataWork lastScmOdrDataWork = null;
						foreach (ScmOdrDataWork scmOdrDataWork in wkList)
						{
							if (lastScmOdrDataWork == null)
							{
								lastScmOdrDataWork = scmOdrDataWork;
							}
							else
							{
								if (scmOdrDataWork.UpdateDate > lastScmOdrDataWork.UpdateDate)
									lastScmOdrDataWork = scmOdrDataWork;
								else if (scmOdrDataWork.UpdateDate == lastScmOdrDataWork.UpdateDate && scmOdrDataWork.UpdateTime > lastScmOdrDataWork.UpdateTime)
									lastScmOdrDataWork = scmOdrDataWork;
							}
						}
						retDataList.Add(lastScmOdrDataWork);
						inquiryNumberList.Add(scmPopParamDtlWork.InquiryNumber);
					}
				}
			}

			scmOdrDataWorkArray = retDataList.ToArray();

			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		finally
		{
			if (myReader != null && !myReader.IsClosed)
				myReader.Close();

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
				sqlCommand = null;
			}
		}

		return status;
	}
	#endregion
// 2010.02.26 TERASAKA ADD END //////////////////////////////////////////////

	/// <summary>
	/// WHERE文作成処理(最新SCM受発注データ件数取得用)
	/// </summary>
	/// <param name="scmPopParamWork">SCMポップアップ条件クラス</param>
	/// <param name="sqlCommand">SqlCommandクラス</param>
	/// <returns>WHERE文</returns>
	/// <remarks>
	/// <br>Note		: 最新SCM受発注データ件数取得用のWHERE文を作成します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	#region MakePopWhereString
	private string MakePopWhereString(ScmPopParamWork scmPopParamWork, SqlCommand sqlCommand)
	{
		StringBuilder whereString = new StringBuilder();

		// 問合せ元企業コード
		if (scmPopParamWork.InqOriginalEpCd != null && scmPopParamWork.InqOriginalEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORIGINALEPCDRF=@FINDINQORIGINALEPCD");
			SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
			findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmPopParamWork.InqOriginalEpCd);
		}

		// 問合せ元拠点コード
		if (scmPopParamWork.InqOriginalSecCd != null && scmPopParamWork.InqOriginalSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORIGINALSECCDRF=@FINDINQORIGINALSECCD");
			SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
			findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmPopParamWork.InqOriginalSecCd);
		}

		// 問合せ先企業コード
		if (scmPopParamWork.InqOtherEpCd != null && scmPopParamWork.InqOtherEpCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQOTHEREPCDRF=@FINDINQOTHEREPCD");
			SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
			findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmPopParamWork.InqOtherEpCd);
		}

		// 問合せ先拠点コード
		if (scmPopParamWork.InqOtherSecCd != null && scmPopParamWork.InqOtherSecCd.Trim() != string.Empty)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQOTHERSECCDRF=@FINDINQOTHERSECCD");
			SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
			findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmPopParamWork.InqOtherSecCd);
		}

		// 更新年月日
		if (scmPopParamWork.UpdateDate > DateTime.MinValue)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("UPDATEDATERF>=@FINDUPDATEDATEST");
			SqlParameter findParaUpdateDate = sqlCommand.Parameters.Add("@FINDUPDATEDATEST", SqlDbType.Int);
			findParaUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmPopParamWork.UpdateDate);
		}

		// 問発・回答種別(1:問合せ・発注 2:回答)
		if (scmPopParamWork.InqOrdAnsDivCd > 0)
		{
			if (whereString.Length > 0) whereString.Append(" AND ");
			whereString.Append("INQORDANSDIVCDRF=@FINDINQORDANSDIVCD");
			SqlParameter findParaInqOrdAnsDivCd = sqlCommand.Parameters.Add("@FINDINQORDANSDIVCD", SqlDbType.Int);
			findParaInqOrdAnsDivCd.Value = SqlDataMediator.SqlSetInt32(scmPopParamWork.InqOrdAnsDivCd);
		}

		if (whereString.Length > 0) whereString.Insert(0, " WHERE ");

		return whereString.ToString();
	}
	#endregion

	/// <summary>
	/// SQLサーバー接続情報取得処理
	/// </summary>
	/// <returns>SqlConnectionクラス</returns>
	/// <remarks>
	/// <br>Note		: SQLサーバーへの接続情報を取得します。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2009.04.28</br>
	/// </remarks>
	private SqlConnection GetSCMConnection()
	{
		SCMSqlConnection sqlConnection = new SCMSqlConnection();
		sqlConnection.GetSqlConnection();
		return sqlConnection.GetSqlConnection();
	}


    // -- ADD 2011/08/10 ------ >>>>>>
    /// <summary>
    /// SCM受発注セット部品データ登録処理
    /// </summary>
    /// <param name="scmOdDtCarWork">SCM受発注セット部品データ</param>
    /// <param name="updateDate">更新年月日</param>
    /// <param name="updateTime">最新更新時分秒ミリ秒</param>
    /// <param name="sqlConnection">SqlConnectionクラス</param>
    /// <param name="sqlTransaction">SqlTransactionクラス</param>
    /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
    /// <remarks>
    /// <br>Note		: SCM受発注セット部品データのInsert/Updateを行います。</br>
    /// <br>Programmer	: 劉立</br>
    /// <br>Date		: 2011/08/10</br>
    /// </remarks>
    #region WriteScmOdSetDtProc
    private int WriteScmOdSetDtProc(ref ScmOdSetDtWork[] scmOdSetDtWorkArray, DateTime updateDate, int updateTime, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
    {
        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        SqlDataReader myReader = null;
        SqlCommand sqlCommand = null;

        try
        {
            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            foreach (ScmOdSetDtWork scmAcOdSetDtWork in scmOdSetDtWorkArray)
            {
                if (scmAcOdSetDtWork == null)
                {
                    continue;
                }

                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SCMODSETDTRF " + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "      INQORIGINALEPCDRF=@FINDINQORIGINALEPCD " + Environment.NewLine;
                sqlText += "  AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD" + Environment.NewLine;
                sqlText += "  AND INQOTHEREPCDRF=@FINDINQOTHEREPCD" + Environment.NewLine;
                sqlText += "  AND INQOTHERSECCDRF=@FINDINQOTHERSECCD" + Environment.NewLine;
                sqlText += "  AND INQUIRYNUMBERRF = @FINDINQUIRYNUMBER" + Environment.NewLine;
                sqlText += "  AND SETPARTSMKRCDRF=@FINDSETPARTSMKRCD" + Environment.NewLine;
                sqlText += "  AND SETPARTSNUMBERRF=@FINDSETPARTSNUMBER" + Environment.NewLine;
                sqlText += "  AND SETPARTSMAINSUBNORF=@FINDSETPARTSMAINSUBNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                sqlCommand.Parameters.Clear();

                //Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaInquiryNumber = sqlCommand.Parameters.Add("@FINDINQUIRYNUMBER", SqlDbType.BigInt);
                SqlParameter findParaSetPartsMkrCd = sqlCommand.Parameters.Add("@FINDSETPARTSMKRCD", SqlDbType.Int);
                SqlParameter findParaSetPartsNumber = sqlCommand.Parameters.Add("@FINDSETPARTSNUMBER", SqlDbType.NVarChar);
                SqlParameter findParaSetPartsMainSubNo = sqlCommand.Parameters.Add("@FINDSETPARTSMAINSUBNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOriginalEpCd);     // 問合せ元企業コード
                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOriginalSecCd);   // 問合せ元拠点コード
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOtherEpCd);           // 問合せ先企業コード
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOtherSecCd);         // 問合せ先拠点コード
                findParaInquiryNumber.Value = SqlDataMediator.SqlSetInt64(scmAcOdSetDtWork.InquiryNumber);          // 問合せ番号
                findParaSetPartsMkrCd.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.SetPartsMkrCd);
                findParaSetPartsNumber.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.SetPartsNumber);
                findParaSetPartsMainSubNo.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.SetPartsMainSubNo);

                myReader = sqlCommand.ExecuteReader();

                sqlText = string.Empty;

                if (myReader.Read())
                {
                    // 作成日時再取得
                    scmAcOdSetDtWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    
                    # region [UPDATE文]
                    sqlText = string.Empty;
                    sqlText += "  UPDATE SCMODSETDTRF" + Environment.NewLine;
                    sqlText += "  SET" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
                    sqlText += " ,INQORIGINALSECCDRF=@INQORIGINALSECCD " + Environment.NewLine;
                    sqlText += " ,INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
                    sqlText += " ,INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
                    sqlText += " ,INQUIRYNUMBERRF=@INQUIRYNUMBER" + Environment.NewLine;
                    sqlText += " ,SETPARTSMKRCDRF=@SETPARTSMKRCD" + Environment.NewLine;
                    sqlText += " ,SETPARTSNUMBERRF=@SETPARTSNUMBER" + Environment.NewLine;
                    sqlText += " ,SETPARTSMAINSUBNORF=@SETPARTSMAINSUBNO" + Environment.NewLine;
                    sqlText += " ,GOODSDIVCDRF = @GOODSDIVCD" + Environment.NewLine;
                    sqlText += " ,RECYCLEPRTKINDCODERF = @RECYCLEPRTKINDCODE" + Environment.NewLine;
                    sqlText += " ,RECYCLEPRTKINDNAMERF = @RECYCLEPRTKINDNAME" + Environment.NewLine;
                    sqlText += " ,DELIVEREDGOODSDIVRF = @DELIVEREDGOODSDIV" + Environment.NewLine;
                    sqlText += " ,HANDLEDIVCODERF = @HANDLEDIVCODE" + Environment.NewLine;
                    sqlText += " ,GOODSSHAPERF = @GOODSSHAPE" + Environment.NewLine;
                    sqlText += " ,DELIVRDGDSCONFCDRF = @DELIVRDGDSCONFCD" + Environment.NewLine;
                    sqlText += " ,DELIGDSCMPLTDUEDATERF = @DELIGDSCMPLTDUEDATE" + Environment.NewLine;
                    sqlText += " ,ANSWERDELIVERYDATERF = @ANSWERDELIVERYDATE" + Environment.NewLine;
                    sqlText += " ,BLGOODSCODERF = @BLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,BLGOODSDRCODERF = @BLGOODSDRCODE" + Environment.NewLine;
                    sqlText += " ,INQGOODSNAMERF = @INQGOODSNAME" + Environment.NewLine;
                    sqlText += " ,ANSGOODSNAMERF = @ANSGOODSNAME" + Environment.NewLine;
                    sqlText += " ,SALESORDERCOUNTRF = @SALESORDERCOUNT" + Environment.NewLine;
                    sqlText += " ,DELIVEREDGOODSCOUNTRF = @DELIVEREDGOODSCOUNT" + Environment.NewLine;
                    sqlText += " ,GOODSNORF = @GOODSNO" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERCDRF = @GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERNMRF = @GOODSMAKERNM" + Environment.NewLine;
                    sqlText += " ,PUREGOODSMAKERCDRF = @PUREGOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,INQPUREGOODSNORF = @INQPUREGOODSNO" + Environment.NewLine;
                    sqlText += " ,ANSPUREGOODSNORF = @ANSPUREGOODSNO" + Environment.NewLine;
                    sqlText += " ,LISTPRICERF = @LISTPRICE" + Environment.NewLine;
                    sqlText += " ,UNITPRICERF = @UNITPRICE" + Environment.NewLine;
                    sqlText += " ,GOODSADDINFORF = @GOODSADDINFO" + Environment.NewLine;
                    sqlText += " ,ROUGHRROFITRF = @ROUGHRROFIT" + Environment.NewLine;
                    sqlText += " ,ROUGHRATERF = @ROUGHRATE" + Environment.NewLine;
                    sqlText += " ,ANSWERLIMITDATERF = @ANSWERLIMITDATE" + Environment.NewLine;
                    sqlText += " ,COMMENTDTLRF = @COMMENTDTL" + Environment.NewLine;
                    sqlText += " ,SHELFNORF = @SHELFNO" + Environment.NewLine;
                    sqlText += " ,PMACPTANODRSTATUSRF=@PMACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,PMSALESSLIPNUMRF=@PMSALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,PMSALESROWNORF=@PMSALESROWNO" + Environment.NewLine;
                    sqlText += " ,PMWAREHOUSECDRF=@PMWAREHOUSECD" + Environment.NewLine;
                    sqlText += " ,PMWAREHOUSENAMERF=@PMWAREHOUSENAME" + Environment.NewLine;
                    sqlText += " ,PMSHELFNORF=@PMSHELFNO" + Environment.NewLine;
                    sqlText += " ,PMPRSNTCOUNTRF=@PMPRSNTCOUNT" + Environment.NewLine;
                    sqlText += "  WHERE" + Environment.NewLine;
                    sqlText += "  INQORIGINALEPCDRF=@FINDINQORIGINALEPCD " + Environment.NewLine;
                    sqlText += "  AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD" + Environment.NewLine;
                    sqlText += "  AND INQOTHEREPCDRF=@FINDINQOTHEREPCD" + Environment.NewLine;
                    sqlText += "  AND INQOTHERSECCDRF=@FINDINQOTHERSECCD" + Environment.NewLine;
                    sqlText += "  AND INQUIRYNUMBERRF = @FINDINQUIRYNUMBER" + Environment.NewLine;
                    sqlText += "  AND SETPARTSMKRCDRF=@FINDSETPARTSMKRCD" + Environment.NewLine;
                    sqlText += "  AND SETPARTSNUMBERRF=@FINDSETPARTSNUMBER" + Environment.NewLine;
                    sqlText += "  AND SETPARTSMAINSUBNORF=@FINDSETPARTSMAINSUBNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    #endregion
                }
                else
                {
                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SCMODSETDTRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,INQORIGINALEPCDRF" + Environment.NewLine;
                    sqlText += "  ,INQORIGINALSECCDRF" + Environment.NewLine;
                    sqlText += "  ,INQOTHEREPCDRF" + Environment.NewLine;
                    sqlText += "  ,INQOTHERSECCDRF" + Environment.NewLine;
                    sqlText += "  ,INQUIRYNUMBERRF" + Environment.NewLine;
                    sqlText += "  ,SETPARTSMKRCDRF" + Environment.NewLine;
                    sqlText += "  ,SETPARTSNUMBERRF" + Environment.NewLine;
                    sqlText += "  ,SETPARTSMAINSUBNORF" + Environment.NewLine;
                    sqlText += "  ,GOODSDIVCDRF" + Environment.NewLine;
                    sqlText += "  ,RECYCLEPRTKINDCODERF" + Environment.NewLine;
                    sqlText += "  ,RECYCLEPRTKINDNAMERF" + Environment.NewLine;
                    sqlText += "  ,DELIVEREDGOODSDIVRF" + Environment.NewLine;
                    sqlText += "  ,HANDLEDIVCODERF" + Environment.NewLine;
                    sqlText += "  ,GOODSSHAPERF" + Environment.NewLine;
                    sqlText += "  ,DELIVRDGDSCONFCDRF" + Environment.NewLine;
                    sqlText += "  ,DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                    sqlText += "  ,ANSWERDELIVERYDATERF" + Environment.NewLine;
                    sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                    sqlText += "  ,BLGOODSDRCODERF" + Environment.NewLine;
                    sqlText += "  ,INQGOODSNAMERF" + Environment.NewLine;
                    sqlText += "  ,ANSGOODSNAMERF" + Environment.NewLine;
                    sqlText += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                    sqlText += "  ,DELIVEREDGOODSCOUNTRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNORF" + Environment.NewLine;
                    sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "  ,GOODSMAKERNMRF" + Environment.NewLine;
                    sqlText += "  ,PUREGOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "  ,INQPUREGOODSNORF" + Environment.NewLine;
                    sqlText += "  ,ANSPUREGOODSNORF" + Environment.NewLine;
                    sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                    sqlText += "  ,UNITPRICERF" + Environment.NewLine;
                    sqlText += "  ,GOODSADDINFORF" + Environment.NewLine;
                    sqlText += "  ,ROUGHRROFITRF" + Environment.NewLine;
                    sqlText += "  ,ROUGHRATERF" + Environment.NewLine;
                    sqlText += "  ,ANSWERLIMITDATERF" + Environment.NewLine;
                    sqlText += "  ,COMMENTDTLRF" + Environment.NewLine;
                    sqlText += "  ,SHELFNORF" + Environment.NewLine;
                    sqlText += "  ,PMACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "  ,PMSALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "  ,PMSALESROWNORF" + Environment.NewLine;
                    sqlText += "  ,PMWAREHOUSECDRF" + Environment.NewLine;
                    sqlText += "  ,PMWAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += "  ,PMSHELFNORF" + Environment.NewLine;
                    sqlText += "  ,PMPRSNTCOUNTRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += "  VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@INQORIGINALEPCD" + Environment.NewLine;
                    sqlText += "  ,@INQORIGINALSECCD" + Environment.NewLine;
                    sqlText += "  ,@INQOTHEREPCD" + Environment.NewLine;
                    sqlText += "  ,@INQOTHERSECCD" + Environment.NewLine;
                    sqlText += "  ,@INQUIRYNUMBER" + Environment.NewLine;
                    sqlText += "  ,@SETPARTSMKRCD" + Environment.NewLine;
                    sqlText += "  ,@SETPARTSNUMBER" + Environment.NewLine;
                    sqlText += "  ,@SETPARTSMAINSUBNO" + Environment.NewLine;
                    sqlText += "  ,@GOODSDIVCD" + Environment.NewLine;
                    sqlText += "  ,@RECYCLEPRTKINDCODE" + Environment.NewLine;
                    sqlText += "  ,@RECYCLEPRTKINDNAME" + Environment.NewLine;
                    sqlText += "  ,@DELIVEREDGOODSDIV" + Environment.NewLine;
                    sqlText += "  ,@HANDLEDIVCODE" + Environment.NewLine;
                    sqlText += "  ,@GOODSSHAPE" + Environment.NewLine;
                    sqlText += "  ,@DELIVRDGDSCONFCD" + Environment.NewLine;
                    sqlText += "  ,@DELIGDSCMPLTDUEDATE" + Environment.NewLine;
                    sqlText += "  ,@ANSWERDELIVERYDATE" + Environment.NewLine;
                    sqlText += "  ,@BLGOODSCODE" + Environment.NewLine;
                    sqlText += "  ,@BLGOODSDRCODE" + Environment.NewLine;
                    sqlText += "  ,@INQGOODSNAME" + Environment.NewLine;
                    sqlText += "  ,@ANSGOODSNAME" + Environment.NewLine;
                    sqlText += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                    sqlText += "  ,@DELIVEREDGOODSCOUNT" + Environment.NewLine;
                    sqlText += "  ,@GOODSNO" + Environment.NewLine;
                    sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  ,@GOODSMAKERNM" + Environment.NewLine;
                    sqlText += "  ,@PUREGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  ,@INQPUREGOODSNO" + Environment.NewLine;
                    sqlText += "  ,@ANSPUREGOODSNO" + Environment.NewLine;
                    sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                    sqlText += "  ,@UNITPRICE" + Environment.NewLine;
                    sqlText += "  ,@GOODSADDINFO" + Environment.NewLine;
                    sqlText += "  ,@ROUGHRROFIT" + Environment.NewLine;
                    sqlText += "  ,@ROUGHRATE" + Environment.NewLine;
                    sqlText += "  ,@ANSWERLIMITDATE" + Environment.NewLine;
                    sqlText += "  ,@COMMENTDTL" + Environment.NewLine;
                    sqlText += "  ,@SHELFNO" + Environment.NewLine;
                    sqlText += "  ,@PMACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  ,@PMSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "  ,@PMSALESROWNO" + Environment.NewLine;
                    sqlText += "  ,@PMWAREHOUSECD" + Environment.NewLine;
                    sqlText += "  ,@PMWAREHOUSENAME" + Environment.NewLine;
                    sqlText += "  ,@PMSHELFNO" + Environment.NewLine;
                    sqlText += "  ,@PMPRSNTCOUNT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    #endregion

                    // 作成日時を設定する
                    scmAcOdSetDtWork.CreateDateTime = updateDate;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                // 更新日時を設定する
                scmAcOdSetDtWork.UpdateDateTime = updateDate;
                
                #region Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);
                SqlParameter paraSetPartsMkrCd = sqlCommand.Parameters.Add("@SETPARTSMKRCD", SqlDbType.Int);
                SqlParameter paraSetPartsNumber = sqlCommand.Parameters.Add("@SETPARTSNUMBER", SqlDbType.NVarChar);
                SqlParameter paraSetPartsMainSubNo = sqlCommand.Parameters.Add("@SETPARTSMAINSUBNO", SqlDbType.Int);
                SqlParameter paraGoodsDivCd = sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
                SqlParameter paraRecyclePrtKindCode = sqlCommand.Parameters.Add("@RECYCLEPRTKINDCODE", SqlDbType.Int);
                SqlParameter paraRecyclePrtKindName = sqlCommand.Parameters.Add("@RECYCLEPRTKINDNAME", SqlDbType.NVarChar);
                SqlParameter paraDeliveredGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
                SqlParameter paraHandleDivCode = sqlCommand.Parameters.Add("@HANDLEDIVCODE", SqlDbType.Int);
                SqlParameter paraGoodsShape = sqlCommand.Parameters.Add("@GOODSSHAPE", SqlDbType.Int);
                SqlParameter paraDelivrdGdsConfCd = sqlCommand.Parameters.Add("@DELIVRDGDSCONFCD", SqlDbType.Int);
                SqlParameter paraDeliGdsCmpltDueDate = sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.BigInt);
                SqlParameter paraAnswerDeliveryDate = sqlCommand.Parameters.Add("@ANSWERDELIVERYDATE", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsDrCode = sqlCommand.Parameters.Add("@BLGOODSDRCODE", SqlDbType.Int);
                SqlParameter paraInqGoodsName = sqlCommand.Parameters.Add("@INQGOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraAnsGoodsName = sqlCommand.Parameters.Add("@ANSGOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                SqlParameter paraDeliveredGoodsCount = sqlCommand.Parameters.Add("@DELIVEREDGOODSCOUNT", SqlDbType.Float);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsMakerNm = sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
                SqlParameter paraPureGoodsMakerCd = sqlCommand.Parameters.Add("@PUREGOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraInqPureGoodsNo = sqlCommand.Parameters.Add("@INQPUREGOODSNO", SqlDbType.NVarChar);
                SqlParameter paraAnsPureGoodsNo = sqlCommand.Parameters.Add("@ANSPUREGOODSNO", SqlDbType.NVarChar);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
                SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
                SqlParameter paraGoodsAddInfo = sqlCommand.Parameters.Add("@GOODSADDINFO", SqlDbType.NVarChar);
                SqlParameter paraRoughRrofit = sqlCommand.Parameters.Add("@ROUGHRROFIT", SqlDbType.BigInt);
                SqlParameter paraRoughRate = sqlCommand.Parameters.Add("@ROUGHRATE", SqlDbType.Float);
                SqlParameter paraAnswerLimitDate = sqlCommand.Parameters.Add("@ANSWERLIMITDATE", SqlDbType.BigInt);
                SqlParameter paraCommentDtl = sqlCommand.Parameters.Add("@COMMENTDTL", SqlDbType.NVarChar);
                SqlParameter paraShelfNo = sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
                SqlParameter paraPMAcptAnOdrStatus = sqlCommand.Parameters.Add("@PMACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraPMSalesSlipNum = sqlCommand.Parameters.Add("@PMSALESSLIPNUM", SqlDbType.Int);
                SqlParameter paraPMSalesRowNo = sqlCommand.Parameters.Add("@PMSALESROWNO", SqlDbType.Int);
                SqlParameter paraPmWarehouseCd = sqlCommand.Parameters.Add("@PMWAREHOUSECD", SqlDbType.NVarChar);
                SqlParameter paraPmWarehouseName = sqlCommand.Parameters.Add("@PMWAREHOUSENAME", SqlDbType.NVarChar);
                SqlParameter paraPmShelfNo = sqlCommand.Parameters.Add("@PMSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraPmPrsntCount = sqlCommand.Parameters.Add("@PMPRSNTCOUNT", SqlDbType.Float);
                #endregion
                
                #region Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmAcOdSetDtWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmAcOdSetDtWork.UpdateDateTime);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.LogicalDeleteCode);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOriginalEpCd);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOriginalSecCd);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOtherEpCd);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqOtherSecCd);
                paraInquiryNumber.Value = SqlDataMediator.SqlSetLong(scmAcOdSetDtWork.InquiryNumber);
                paraSetPartsMkrCd.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.SetPartsMkrCd);
                paraSetPartsNumber.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.SetPartsNumber);
                paraSetPartsMainSubNo.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.SetPartsMainSubNo);
                paraGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.GoodsDivCd);
                paraRecyclePrtKindCode.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.RecyclePrtKindCode);
                paraRecyclePrtKindName.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.RecyclePrtKindName);
                paraDeliveredGoodsDiv.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.DeliveredGoodsDiv);
                paraHandleDivCode.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.HandleDivCode);
                paraGoodsShape.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.GoodsShape);
                paraDelivrdGdsConfCd.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.DelivrdGdsConfCd);
                paraDeliGdsCmpltDueDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(scmAcOdSetDtWork.DeliGdsCmpltDueDate);
                paraAnswerDeliveryDate.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.AnswerDeliveryDate);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.BLGoodsCode);
                paraBLGoodsDrCode.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.BLGoodsDrCode);
                paraInqGoodsName.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqGoodsName);
                paraAnsGoodsName.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.AnsGoodsName);
                paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(scmAcOdSetDtWork.SalesOrderCount);
                paraDeliveredGoodsCount.Value = SqlDataMediator.SqlSetDouble(scmAcOdSetDtWork.DeliveredGoodsCount);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.GoodsNo);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.GoodsMakerCd);
                paraGoodsMakerNm.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.GoodsMakerNm);
                paraPureGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.PureGoodsMakerCd);
                paraInqPureGoodsNo.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.InqPureGoodsNo);
                paraAnsPureGoodsNo.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.AnsPureGoodsNo);
                paraListPrice.Value = SqlDataMediator.SqlSetLong(scmAcOdSetDtWork.ListPrice);
                paraUnitPrice.Value = SqlDataMediator.SqlSetLong(scmAcOdSetDtWork.UnitPrice);
                paraGoodsAddInfo.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.GoodsAddInfo);
                paraRoughRrofit.Value = SqlDataMediator.SqlSetLong(scmAcOdSetDtWork.RoughRrofit);
                paraRoughRate.Value = SqlDataMediator.SqlSetDouble(scmAcOdSetDtWork.RoughRate);
                paraAnswerLimitDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(scmAcOdSetDtWork.AnswerLimitDate);
                paraCommentDtl.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.CommentDtl);
                paraShelfNo.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.ShelfNo);
                paraPMAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.PMAcptAnOdrStatus);
                paraPMSalesSlipNum.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.PMSalesSlipNum);
                paraPMSalesRowNo.Value = SqlDataMediator.SqlSetInt32(scmAcOdSetDtWork.PMSalesRowNo);
                paraPmWarehouseCd.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.PmWarehouseCd);
                paraPmWarehouseName.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.PmWarehouseName);
                paraPmShelfNo.Value = SqlDataMediator.SqlSetString(scmAcOdSetDtWork.PmShelfNo);
                paraPmPrsntCount.Value = SqlDataMediator.SqlSetDouble(scmAcOdSetDtWork.PmPrsntCount);

                #endregion

                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        finally
        {
            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }

        return status;
    }
    #endregion
    // -- ADD 2011/08/10 ------ <<<<<<

	#endregion
}
