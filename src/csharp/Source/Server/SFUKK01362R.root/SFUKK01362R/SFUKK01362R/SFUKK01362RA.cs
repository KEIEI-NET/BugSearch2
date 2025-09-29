//**********************************************************************//
// System           :   PM.NS
// Sub System       :
// Program name     :   入金更新処理リモーティング
//                  :   SFUKK01362R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   徳永　誠
// Date             :   2005.08.11
//----------------------------------------------------------------------//
// Update Note      :
// 2006.02.20 toku  : 諸費用別入金対応
// 2006.10.18 toku	: トランザクション分離レベルを変更
// =====================================================================
// 2007.01.23 木村  : MA.NS用に変更
// 2007.03.27 木村  : 得意先請求(売掛)金額マスタの更新は準備処理で
//                    行うように変更された為、更新処理を削除
// 2007.05.14 木村  : サービス伝票区分を入金マスタ・入金引当マスタに追加
//----------------------------------------------------------------------//
// 2007.10.12 山田  : DC.NS用に変更
// 2007.12.10 山田  : EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更
// 2008.01.11 山田  : 論理削除機能を追加(LogicalDelete)
// 2008.03.17 山田  : 入金日をシステム日付で登録する
//----------------------------------------------------------------------//
// 2008.04.25 21112 : PM.NS用に変更
//----------------------------------------------------------------------//
// 2009.05.01 22008 : 論理削除データ対応
//----------------------------------------------------------------------//
// 2010/08/18 22018 鈴木正臣 : 締次ロック対応
//----------------------------------------------------------------------//
// 2010/12/20 李占川: PM.NS障害改良対応(12月分)	
//                    ①伝票削除時に特定の条件で発生するエラーを修正する。
//                    ②赤伝の入金明細データを作成する。
//----------------------------------------------------------------------//
// 2011/02/24 22008 長内数馬 : 差分組込漏れの修正（2010/09/28 20056 : 論理削除データ対応）
//----------------------------------------------------------------------//
// 2011/07/28 qijh: 送信済みのチェック方法を追加
//----------------------------------------------------------------------//
// 2011/11/10 陳建明  Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------//
// 2011/12/15 tianjw  Redmine#27390 拠点管理/売上日のチェック
//----------------------------------------------------------------------//
// Update Note      : 2012/02/06 田建委
// 管理番号         : 10707327-00 2012/03/28配信分
//                    Redmine#28288 送信済データ修正制御の対応
//----------------------------------------------------------------------//
// Update Note      : 2012/08/10 脇田 靖之 
//                    拠点管理 送信済データチェック不具合対応
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/10/17  修正内容 : Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの対応。
//                                : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の対応。
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/10/29  修正内容 : Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。
//                                : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/11/06  修正内容 : Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。
//                                : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。
//                                : 入金合計はマイナス値を設定すれば、現在売掛残高の更新の対応。
//----------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/08/28  修正内容 : PMKOBETSU-4076 タイムアウト設定
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/25 M.Kubota
using Broadleaf.Application.Common;  // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00)
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金更新DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金データの更新操作を行うクラスです。</br>
	/// <br>Programmer : 95089 徳永　誠</br>
	/// <br>Date       : 2005.08.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>		   : 2006.02.20 toku 諸費用別入金対応</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>Update Note : 2010/08/18 22018 鈴木 正臣</br>
    /// <br>              締次ロック対応</br>
    /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)</br>
    /// <br>              ①伝票削除時に特定の条件で発生するエラーを修正する。</br>
    /// <br>              ②赤伝の入金明細データを作成する。</br>>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : 2012/02/06 田建委</br>
    /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
    /// <br>              Redmine#28288 送信済データ修正制御の対応</br>
    /// <br>Update Note : 2012/08/10  脇田 靖之</br>
    /// <br>            : 拠点管理 送信済データチェック不具合対応</br>
    /// <br>Update Note : 2012/10/17 wangf</br>
    /// <br>            : 10801804-00、Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの対応。</br>
    /// <br>            : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の対応。</br>
    /// <br>Update Note : 2012/10/29 wangf</br>
    /// <br>            : 10801804-00、Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。</br>
    /// <br>            : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。</br>
    /// <br>Update Note : 2012/11/06 wangf</br>
    /// <br>            : 10801804-00、Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。</br>
    /// <br>            : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。</br>
    /// <br>            : 入金合計はマイナス値を設定すれば、現在売掛残高の更新の対応。</br>
    /// <br>UpdateNote  : 2013/01/10 zhuhh</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>            : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// <br>Update Note : 2020/08/28 田建委</br>
    /// <br>管理番号    : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
    /// </remarks>
	[Serializable]
	//public class DepsitMainDB : RemoteDB, IDepsitMainDB           //DEL 2008/04/25 M.Kubota
    public class DepsitMainDB : RemoteWithAppLockDB, IDepsitMainDB  //ADD 2008/04/25 M.Kubota
	{
//		private string _connectionText;		//コネクション文字列格納用

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

		/// <summary>
		/// 入金更新DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.02</br>
		/// </remarks>
		public DepsitMainDB() :
			base( "SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitMainWork", "DEPSITMAINRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("DepsitMainDBコンストラクタ");
//			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        }

        private CustomerChangeDB _customerChangeDB = null;

        /// <summary>
        /// 得意先マスタ(変動情報)リモート プロパティ
        /// </summary>
        private CustomerChangeDB CustomerChangeDb
        {
            get
            {
                if (this._customerChangeDB == null)
                {
                    this._customerChangeDB = new CustomerChangeDB();
                }

                return this._customerChangeDB;
            }
        }

        // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 送信済チェック失敗のステータス
        /// </summary>
        public const int STATUS_CHK_SEND_ERR = -1001;

        private SecMngSndRcvDB _SecMngSndRcvDB = null;
        /// <summary>
        /// 拠点管理送受信対象設定マスタリモートプロパティ
        /// </summary>
        private SecMngSndRcvDB ScMngSndRcvDB
        {
            get
            {
                if (this._SecMngSndRcvDB == null)
                    this._SecMngSndRcvDB = new SecMngSndRcvDB();
                return this._SecMngSndRcvDB;
            }
        }

        private SecMngSetDB _SecMngSetDB = null;
        /// <summary>
        /// 拠点管理設定マスタリモートプロパティ
        /// </summary>
        private SecMngSetDB ScMngSetDB
        {
            get
            {
                if (this._SecMngSetDB == null)
                    this._SecMngSetDB = new SecMngSetDB();
                return this._SecMngSetDB;
            }
        }
        // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
 
        # region [書込処理]

        /// <summary>
		/// 入金更新処理
		/// </summary>
		/// <param name="depsitDataWorkByte">入金情報ワーク</param>
		/// <param name="depositAlwWorkListByte">入金引当情報ワーク</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金情報・入金引当情報を元にデータ更新を行います</br>
		/// <br>           : 入金番号無しの時、新規入金作成とします</br>
		/// <br>           : 論理削除を立てた場合、削除処理を行います</br>
		/// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int Write(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品

            try
            {
                //--- DEL 2008/04/25 M.Kubota --->>>
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // XMLの読み込み
                //DepsitMainWork depsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitDataWorkByte,typeof(DepsitMainWork));  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                DepsitDataWork depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));

                // 入金データを入金マスタデータと入金明細データに分割
                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlWorkArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);
                //--- ADD 2008/04/25 M.Kubota ---<<<
                
                DepositAlwWork[] depositAlwWorkArray = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));

                //SQL接続
                //--- DEL 2008/04/25 M.Kubota --->>>
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 更新時ロック処理
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(depsitMainWork.EnterpriseCode, CustomerCodeList, null);	// 得意先別ロックをかける
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (sqlConnection != null && sqlTransaction != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                    ////システムロック(拠点) //2009/1/27 Add sakurai
                    //int st = 0; // ロック用ステータス
                    //ShareCheckInfo info = new ShareCheckInfo();
                    //info.Keys.Add(depsitDataWork.EnterpriseCode, ShareCheckType.Section, depsitDataWork.AddUpSecCode, "");
                    //st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    //if (st != 0) return st;

                    // 締次ロック（伝票側）
                    int st = 0; // ロック用ステータス
                    ShareCheckInfo info = new ShareCheckInfo();
                    int customerTotalDay = GetCustomerTotalDay( depsitDataWork.EnterpriseCode, depsitDataWork.CustomerCode, ref sqlConnection, ref sqlTransaction );
                    info.Keys.Add( new ShareCheckKey( depsitDataWork.EnterpriseCode, ShareCheckType.AddUpSlip, depsitDataWork.AddUpSecCode, "", customerTotalDay, ToLongDate( depsitDataWork.AddUpADate ) ) );
                    // ロック
                    st = this.ShareCheck( info, LockControl.Locke, sqlConnection, sqlTransaction );
                    if ( st != 0 ) return st;
                    // --- UPD m.suzuki 2010/08/18 ----------<<<<<

                    // 入金マスタ更新処理
                    //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    status = Write(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //システムロック解除 //2009/1/27 Add sakurai
                        st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if(st != 0) return st;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLへ変換し、文字列のバイナリ化
                    //depsitDataWorkByte = XmlByteSerializer.Serialize(depsitMainWork);  //DEL 2008/04/25 M.Kubota
                    
                    //--- ADD 2008/04/25 M.Kubota --->>>
                    // 入金マスタデータと入金明細データを入金データに合体
                    DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);
                    depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
                    //--- ADD 2008/04/25 M.Kuboat ---<<<
                    
                    depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkArray);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota --->>>
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<
			finally
			{
				// 更新時ロック解除
				//controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
			}

			if(sqlConnection != null)
			{
                sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
        }

        // --- ADD m.suzuki 2010/08/18 ---------->>>>>
        /// <summary>
        /// 得意先の締日(DD)を取得
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCustomerTotalDay( string enterpriseCode, int customerCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int totalDay = 99;

            try
            {
                CustomerDB customerDB = new CustomerDB();
                if ( customerDB != null )
                {
                    int status = customerDB.GetCustomerTotalDay( enterpriseCode, customerCode, ref totalDay, ref sqlConnection, ref sqlTransaction );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        totalDay = 99;
                    }
                }
            }
            catch
            {
                totalDay = 99;
            }

            return totalDay;
        }
        /// <summary>
        /// 日付変換処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate( DateTime dateTime )
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/18 ----------<<<<<

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// 入金、手形更新処理
        /// </summary>
        /// <param name="depsitDataWorkByte">入金情報ワーク</param>
        /// <param name="depositAlwWorkListByte">入金引当情報ワーク</param>
        /// <param name="rcvDraftDataUpdWorkByte">手形データワーク（更新用）</param>
        /// <param name="rcvDraftDataDelWorkByte">手形データワーク（削除用）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報・手形データ元にデータ更新を行います</br>
        /// <br>           : 入金番号無しの時、新規入金・手形データ作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>           : 手形データの更新、削除処理も行う</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.06</br>
        /// </remarks>
        public int WriteWithDraftData(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte, byte[] rcvDraftDataUpdWorkByte, byte[] rcvDraftDataDelWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bool commitFlg = true;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // 伝票更新排他制御部品
            ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();

            try
            {
                DepsitDataWork depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));

                // 入金データを入金マスタデータと入金明細データに分割
                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlWorkArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);

                DepositAlwWork[] depositAlwWorkArray = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));


                RcvDraftDataWork rcvDraftDataUpdWork = new RcvDraftDataWork();
                if (rcvDraftDataUpdWorkByte != null)
                    rcvDraftDataUpdWork = XmlByteSerializer.Deserialize(rcvDraftDataUpdWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataUpdWork = null;

                RcvDraftDataWork rcvDraftDataDelWork = new RcvDraftDataWork();
                if (rcvDraftDataDelWorkByte != null)
                    rcvDraftDataDelWork = XmlByteSerializer.Deserialize(rcvDraftDataDelWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataDelWork = null;

                //SQL接続
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (sqlConnection != null && sqlTransaction != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //システムロック(拠点)
                    int st = 0; // ロック用ステータス
                    ShareCheckInfo info = new ShareCheckInfo();
                    info.Keys.Add(depsitDataWork.EnterpriseCode, ShareCheckType.Section, depsitDataWork.AddUpSecCode, "");

                    if (depsitMainWork != null && depsitMainWork.UpdateSecCd != "")
                    {
                        st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        if (st != 0) return st;

                        // 入金マスタ更新処理
                        status = Write(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);
                        // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                        if (STATUS_CHK_SEND_ERR == status)
                        {
                            sqlTransaction.Rollback();
                            if (sqlConnection != null)
                            {
                                sqlConnection.Close();
                                sqlConnection.Dispose();
                            }
                            return status;
                        }
                        // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //システムロック解除
                            st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            if (st != 0) return st;
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                           commitFlg = false;
                    }

                    if (rcvDraftDataUpdWork != null)
                    {
                        if (rcvDraftDataUpdWork.DepositRowNo != 0 && depsitMainWork != null && depsitMainWork.DepositSlipNo != 0)
                        {
                            // 支払伝票番号
                            rcvDraftDataUpdWork.DepositSlipNo = depsitMainWork.DepositSlipNo;
                            // 支払ステータス
                            rcvDraftDataUpdWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
                            // 支払日付
                            rcvDraftDataUpdWork.DepositDate = depsitMainWork.DepositDate;
                        }

                        st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        if (st != 0) return st;

                        // 手形データ更新処理
                        status = WriteDraftProc(rcvDraftDataUpdWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //システムロック解除
                            st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            if (st != 0) return st;
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            commitFlg = false;
                    }

                    if (rcvDraftDataDelWork != null)
                    {
                        st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        if (st != 0) return st;

                        // 手形データ削除処理
                        status = DeleteDraftProc(rcvDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //システムロック解除
                            st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            if (st != 0) return st;
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            commitFlg = false;
                    }


                    if (commitFlg)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 入金マスタデータと入金明細データを入金データに合体
                    DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);
                    depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);

                    depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkArray);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>

        /// <summary>
        /// 入金一括作成処理（受注指定型）
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="createDepsitMainWorkListByte">入金更新データパラメータ(受注指定型)</param>
        /// <param name="depositSlipNoList">更新した入金データの入金番号配列</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 一括作成用パラメータから指定受注への引当更新・入金新規作成処理を行います</br>
        /// <br>           : 受注指定型専用であり、新規入金・引当のみ行えます</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int Write(string EnterpriseCode, byte[] createDepsitMainWorkListByte, out int[] depositSlipNoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            depositSlipNoList = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/25 M.Kubota

            try
            {
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //--- DEL 2008/04/25 M.Kubota --->>>
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // XMLの読み込み
                CreateDepsitMainWork[] createDepsitMainWorkList = (CreateDepsitMainWork[])XmlByteSerializer.Deserialize(createDepsitMainWorkListByte, typeof(CreateDepsitMainWork[]));

                //SQL接続
                //--- DEL 2008/04/25 M.Kubota --->>>
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                //システムロック(拠点) //2009/1/27 Add sakurai
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(EnterpriseCode, ShareCheckType.Section, createDepsitMainWorkList[0].AddUpSecCode, "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                if (status == 0) return status;
                 // 更新した入金番号格納リストの作成
                ArrayList depositSlipNoListAr = new ArrayList();

                for (int ix = 0; ix < createDepsitMainWorkList.Length; ix++)
                {
                    CreateDepsitMainWork createDepsitMainWork = createDepsitMainWorkList[ix];

                    // ↓ 20070123 18322 c MA.NS用に変更
                    #region SF 入金マスタ・入金引当マスタ生成（全てコメントアウト）
                    //// 入金情報の生成
                    //DepsitMainWork depsitMainWork = new DepsitMainWork();
                    //
                    //depsitMainWork.EnterpriseCode = EnterpriseCode;
                    //depsitMainWork.DepositDebitNoteCd = 0;
                    //depsitMainWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    //depsitMainWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    //depsitMainWork.DepositCd = createDepsitMainWork.DepositCd;
                    //depsitMainWork.DepositTotal = createDepsitMainWork.Deposit + createDepsitMainWork.FeeDeposit + createDepsitMainWork.DiscountDeposit;
                    //depsitMainWork.Outline = createDepsitMainWork.Outline;
                    //depsitMainWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;
                    //depsitMainWork.DepositDate = createDepsitMainWork.DepositDate;
                    //depsitMainWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    //depsitMainWork.AddUpADate = createDepsitMainWork.AddUpADate;
                    //depsitMainWork.UpdateSecCd = createDepsitMainWork.UpdateSecCd;
                    //depsitMainWork.DepositKindName = createDepsitMainWork.DepositKindName;
                    //depsitMainWork.DepositAllowance = createDepsitMainWork.Deposit + createDepsitMainWork.FeeDeposit + createDepsitMainWork.DiscountDeposit;
                    //depsitMainWork.DepositAlwcBlnce = 0;
                    //depsitMainWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;
                    //depsitMainWork.DepositKindDivCd = createDepsitMainWork.DepositKindDivCd;
                    //depsitMainWork.FeeDeposit = createDepsitMainWork.FeeDeposit;
                    //depsitMainWork.DiscountDeposit = createDepsitMainWork.DiscountDeposit;
                    //depsitMainWork.CreditOrLoanCd = createDepsitMainWork.CreditOrLoanCd;
                    //depsitMainWork.CreditCompanyCode = createDepsitMainWork.CreditCompanyCode;
                    //depsitMainWork.Deposit = createDepsitMainWork.Deposit;
                    //depsitMainWork.DraftDrawingDate = createDepsitMainWork.DraftDrawingDate;
                    //depsitMainWork.DraftPayTimeLimit = createDepsitMainWork.DraftPayTimeLimit;
                    //depsitMainWork.LastReconcileAddUpDt = createDepsitMainWork.AddUpADate;			// 消し込み日←入金計上日
                    //
                    //// 20060220 Ins Start >> 諸費用別入金対応 >>>>>>>>>>>>>
                    //depsitMainWork.AcpOdrDeposit = createDepsitMainWork.AcpOdrDeposit;				// 受注入金金額
                    //depsitMainWork.AcpOdrChargeDeposit = createDepsitMainWork.AcpOdrChargeDeposit;	// 受注手数料入金額
                    //depsitMainWork.AcpOdrDisDeposit = createDepsitMainWork.AcpOdrDisDeposit;		// 受注値引入金額
                    //depsitMainWork.VariousCostDeposit = createDepsitMainWork.VariousCostDeposit;	// 諸費用入金金額
                    //depsitMainWork.VarCostChargeDeposit = createDepsitMainWork.VarCostChargeDeposit;// 諸費用手数料入金額
                    //depsitMainWork.VarCostDisDeposit = createDepsitMainWork.VarCostDisDeposit;		// 諸費用値引入金額
                    //depsitMainWork.AcpOdrDepositAlwc = createDepsitMainWork.AcpOdrDeposit + createDepsitMainWork.AcpOdrChargeDeposit + createDepsitMainWork.AcpOdrDisDeposit;// 受注入金引当額
                    //depsitMainWork.AcpOdrDepoAlwcBlnce = 0;											// 受注入金引当残高
                    //depsitMainWork.VarCostDepoAlwc = createDepsitMainWork.VariousCostDeposit + createDepsitMainWork.VarCostChargeDeposit + createDepsitMainWork.VarCostDisDeposit;	// 諸費用入金引当額
                    //depsitMainWork.VarCostDepoAlwcBlnce = 0;										// 諸費用入金引当残高
                    //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //
                    //// 入金引当情報の生成
                    //DepositAlwWork depositAlwWork = new DepositAlwWork();
                    //
                    //depositAlwWork.EnterpriseCode = EnterpriseCode;
                    //depositAlwWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    //depositAlwWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    //depositAlwWork.AcceptAnOrderNo = createDepsitMainWork.AcceptAnOrderNo;
                    //depositAlwWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    //depositAlwWork.DepositInputDate = createDepsitMainWork.DepositDate;				// 入金入力日←入金日
                    //depositAlwWork.DepositAllowance = createDepsitMainWork.Deposit + createDepsitMainWork.FeeDeposit + createDepsitMainWork.DiscountDeposit;
                    //depositAlwWork.ReconcileDate = DateTime.Now;									// 消し込み日←システム日付
                    //depositAlwWork.ReconcileAddUpDate = createDepsitMainWork.AddUpADate;			// 消し込み日計上日←入金計上日
                    //depositAlwWork.DebitNoteOffSetCd = 0;
                    //depositAlwWork.DepositCd = createDepsitMainWork.DepositCd;
                    //depositAlwWork.CreditOrLoanCd = createDepsitMainWork.CreditOrLoanCd;
                    //// 20060220 Ins Start >> 諸費用別入金対応 >>>>>>>>>>>>>
                    //depositAlwWork.AcpOdrDepositAlwc = createDepsitMainWork.AcpOdrDeposit + createDepsitMainWork.AcpOdrChargeDeposit + createDepsitMainWork.AcpOdrDisDeposit;		// 受注入金引当額
                    //depositAlwWork.VarCostDepoAlwc = createDepsitMainWork.VariousCostDeposit + createDepsitMainWork.VarCostChargeDeposit + createDepsitMainWork.VarCostDisDeposit;	// 諸費用入金引当額
                    //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    #endregion

                    # region [入金マスタ]
                    // 入金情報の生成
                    DepsitMainWork depsitMainWork = new DepsitMainWork();
                    # region --- DEL 2008/04/25 M.Kubota ---
# if false
                    // 企業コード
                    depsitMainWork.EnterpriseCode = EnterpriseCode;
                    // 入金赤黒区分(0:黒伝固定)
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // 入金伝票番号
                    depsitMainWork.DepositSlipNo = 0;
                    // ↓ 2007.10.12 980081 d
                    //// 受注番号
                    //depsitMainWork.AcceptAnOrderNo = createDepsitMainWork.AcceptAnOrderNo;
                    //// サービス伝票区分
                    //depsitMainWork.ServiceSlipCd = createDepsitMainWork.ServiceSlipCd;
                    // ↑ 2007.10.12 980081 d
                    // 入金入力拠点コード
                    depsitMainWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;
                    // 計上拠点コード
                    depsitMainWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    // 更新拠点コード
                    depsitMainWork.UpdateSecCd = createDepsitMainWork.UpdateSecCd;
                    // 入金日付
                    // ↓ 2008.03.17 980081 c
                    //depsitMainWork.DepositDate = createDepsitMainWork.DepositDate;
                    depsitMainWork.DepositDate = DateTime.Now;
                    // ↑ 2008.03.17 980081 c
                    // 計上日付
                    depsitMainWork.AddUpADate = createDepsitMainWork.AddUpADate;
                    // 入金金種コード
                    depsitMainWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    // 入金金種名称
                    depsitMainWork.DepositKindName = createDepsitMainWork.DepositKindName;
                    // 入金金種区分
                    depsitMainWork.DepositKindDivCd = createDepsitMainWork.DepositKindDivCd;
                    // 入金計
                    depsitMainWork.DepositTotal = createDepsitMainWork.DepositTotal;
                    // 入金金額
                    depsitMainWork.Deposit = createDepsitMainWork.Deposit;
                    // 手数料入金額
                    depsitMainWork.FeeDeposit = createDepsitMainWork.FeeDeposit;
                    // 値引入金額
                    depsitMainWork.DiscountDeposit = createDepsitMainWork.DiscountDeposit;
                    // ↓ 2007.10.12 980081 d
                    //// リベート入金額
                    //depsitMainWork.RebateDeposit   = createDepsitMainWork.RebateDeposit;
                    // ↑ 2007.10.12 980081 d
                    // 自動入金区分
                    depsitMainWork.AutoDepositCd = createDepsitMainWork.AutoDepositCd;
                    // 預り金区分
                    depsitMainWork.DepositCd = createDepsitMainWork.DepositCd;
                    // ↓ 2007.10.12 980081 d
                    //// クレジット／ローン区分
                    //depsitMainWork.CreditOrLoanCd = createDepsitMainWork.CreditOrLoanCd;
                    //// クレジット会社コード
                    //depsitMainWork.CreditCompanyCode = createDepsitMainWork.CreditCompanyCode;
                    // ↑ 2007.10.12 980081 d
                    // 手形振出日
                    depsitMainWork.DraftDrawingDate = createDepsitMainWork.DraftDrawingDate;
                    // 手形支払期日
                    depsitMainWork.DraftPayTimeLimit = createDepsitMainWork.DraftPayTimeLimit;
                    // 入金引当額
                    depsitMainWork.DepositAllowance = createDepsitMainWork.DepositTotal;
                    // 入金引当残高
                    depsitMainWork.DepositAlwcBlnce = 0;
                    // 赤黒入金連結番号
                    depsitMainWork.DebitNoteLinkDepoNo = 0;
                    // 最終消し込み計上日（消し込み日←入金計上日）
                    depsitMainWork.LastReconcileAddUpDt = createDepsitMainWork.AddUpADate;
                    // 入金担当者コード
                    depsitMainWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;
                    // 入金担当者名称
                    depsitMainWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;
                    // 得意先コード
                    depsitMainWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    // 得意先名称
                    depsitMainWork.CustomerName = createDepsitMainWork.CustomerName;
                    // 得意先名称2
                    depsitMainWork.CustomerName2 = createDepsitMainWork.CustomerName2;
                    // 伝票摘要
                    depsitMainWork.Outline = createDepsitMainWork.Outline;
                    // ↓ 2007.10.12 980081 a
                    depsitMainWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;
                    depsitMainWork.SalesSlipNum = createDepsitMainWork.SalesSlipNum;
                    depsitMainWork.SubSectionCode = createDepsitMainWork.SubSectionCode;
                    depsitMainWork.MinSectionCode = createDepsitMainWork.MinSectionCode;
                    depsitMainWork.DraftKind = createDepsitMainWork.DraftKind;
                    depsitMainWork.DraftKindName = createDepsitMainWork.DraftKindName;
                    depsitMainWork.DraftDivide = createDepsitMainWork.DraftDivide;
                    depsitMainWork.DraftDivideName = createDepsitMainWork.DraftDivideName;
                    depsitMainWork.DraftNo = createDepsitMainWork.DraftNo;
                    depsitMainWork.DepositInputAgentCd = createDepsitMainWork.DepositInputAgentCd;
                    depsitMainWork.DepositInputAgentNm = createDepsitMainWork.DepositInputAgentNm;
                    depsitMainWork.CustomerSnm = createDepsitMainWork.CustomerSnm;
                    depsitMainWork.ClaimCode = createDepsitMainWork.ClaimCode;
                    depsitMainWork.ClaimName = createDepsitMainWork.ClaimName;
                    depsitMainWork.ClaimName2 = createDepsitMainWork.ClaimName2;
                    depsitMainWork.ClaimSnm = createDepsitMainWork.ClaimSnm;
                    depsitMainWork.BankCode = createDepsitMainWork.BankCode;
                    depsitMainWork.BankName = createDepsitMainWork.BankName;
                    depsitMainWork.EdiSendDate = createDepsitMainWork.EdiSendDate;
                    depsitMainWork.EdiTakeInDate = createDepsitMainWork.EdiTakeInDate;
                    // ↑ 2007.10.12 980081 a
# endif
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    depsitMainWork.EnterpriseCode = EnterpriseCode;                                 // 企業コード
                    depsitMainWork.LogicalDeleteCode = 0;                                           // 論理削除区分
                    depsitMainWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;          // 受注ステータス
                    depsitMainWork.DepositDebitNoteCd = 0;                                          // 入金赤黒区分
                    depsitMainWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;      // 入金入力拠点コード
                    depsitMainWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;                // 計上拠点コード
                    depsitMainWork.UpdateSecCd = createDepsitMainWork.UpdateSecCd;                  // 更新拠点コード
                    depsitMainWork.SubSectionCode = createDepsitMainWork.SubSectionCode;            // 部門コード
                    depsitMainWork.InputDay = createDepsitMainWork.InputDay;                        // 入力日付  //ADD 2009/03/25
                    depsitMainWork.DepositDate = createDepsitMainWork.DepositDate;                  // 入金日付
                    depsitMainWork.AddUpADate = createDepsitMainWork.AddUpADate;                    // 計上日付
                    depsitMainWork.DepositTotal = createDepsitMainWork.DepositTotal;                // 入金計
                    depsitMainWork.Deposit = createDepsitMainWork.Deposit;                          // 入金金額
                    depsitMainWork.FeeDeposit = createDepsitMainWork.FeeDeposit;                    // 手数料入金額
                    depsitMainWork.DiscountDeposit = createDepsitMainWork.DiscountDeposit;          // 値引入金額
                    depsitMainWork.AutoDepositCd = createDepsitMainWork.AutoDepositCd;              // 自動入金区分
                    depsitMainWork.DraftDrawingDate = createDepsitMainWork.DraftDrawingDate;        // 手形振出日
                    depsitMainWork.DraftKind = createDepsitMainWork.DraftKind;                      // 手形種類
                    depsitMainWork.DraftKindName = createDepsitMainWork.DraftKindName;              // 手形種類名称
                    depsitMainWork.DraftDivide = createDepsitMainWork.DraftDivide;                  // 手形区分
                    depsitMainWork.DraftDivideName = createDepsitMainWork.DraftDivideName;          // 手形区分名称
                    depsitMainWork.DraftNo = createDepsitMainWork.DraftNo;                          // 手形番号
                    depsitMainWork.DepositAllowance = createDepsitMainWork.DepositTotal;            // 入金引当額
                    depsitMainWork.DepositAlwcBlnce = 0;                                            // 入金引当残高
                    depsitMainWork.DebitNoteLinkDepoNo = 0;                                         // 赤黒入金連結番号
                    depsitMainWork.LastReconcileAddUpDt = createDepsitMainWork.AddUpADate;          // 最終消し込み計上日
                    depsitMainWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;        // 入金担当者コード
                    depsitMainWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;            // 入金担当者名称
                    depsitMainWork.DepositInputAgentCd = createDepsitMainWork.DepositInputAgentCd;  // 入金入力者コード
                    depsitMainWork.DepositInputAgentNm = createDepsitMainWork.DepositInputAgentNm;  // 入金入力者名称
                    depsitMainWork.CustomerCode = createDepsitMainWork.CustomerCode;                // 得意先コード
                    depsitMainWork.CustomerName = createDepsitMainWork.CustomerName;                // 得意先名称
                    depsitMainWork.CustomerName2 = createDepsitMainWork.CustomerName2;              // 得意先名称2
                    depsitMainWork.CustomerSnm = createDepsitMainWork.CustomerSnm;                  // 得意先略称
                    depsitMainWork.ClaimCode = createDepsitMainWork.ClaimCode;                      // 請求先コード
                    depsitMainWork.ClaimName = createDepsitMainWork.ClaimName;                      // 請求先名称
                    depsitMainWork.ClaimName2 = createDepsitMainWork.ClaimName2;                    // 請求先名称2
                    depsitMainWork.ClaimSnm = createDepsitMainWork.ClaimSnm;                        // 請求先略称
                    depsitMainWork.Outline = createDepsitMainWork.Outline;                          // 伝票摘要
                    depsitMainWork.BankCode = createDepsitMainWork.BankCode;                        // 銀行コード
                    depsitMainWork.BankName = createDepsitMainWork.BankName;                        // 銀行名称
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                    # endregion

                    # region [入金明細データ]
                    //--- ADD 2008/04/25 M.Kubota --->>>
                    DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[1];
                    depsitDtlWorkArray[0] = new DepsitDtlWork();
                    depsitDtlWorkArray[0].EnterpriseCode = EnterpriseCode;                         // 企業コード
                    depsitDtlWorkArray[0].LogicalDeleteCode = 0;                                   // 論理削除区分
                    depsitDtlWorkArray[0].AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;  // 受注ステータス
                    depsitDtlWorkArray[0].DepositRowNo = createDepsitMainWork.DepositRowNo;        // 入金行番号
                    depsitDtlWorkArray[0].MoneyKindCode = createDepsitMainWork.MoneyKindCode;      // 金種コード
                    depsitDtlWorkArray[0].MoneyKindName = createDepsitMainWork.MoneyKindName;      // 金種名称
                    depsitDtlWorkArray[0].MoneyKindDiv = createDepsitMainWork.MoneyKindDiv;        // 金種区分
                    depsitDtlWorkArray[0].Deposit = createDepsitMainWork.Deposit;                  // 入金金額
                    depsitDtlWorkArray[0].ValidityTerm = createDepsitMainWork.ValidityTerm;        // 有効期限
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                    # endregion

                    # region [入金引当マスタ]
                    // 入金引当情報の生成
                    DepositAlwWork depositAlwWork = new DepositAlwWork();
                    # region --- DEL 2008/04/25 M.Kubota ---
# if false
                    // 企業コード
                    depositAlwWork.EnterpriseCode = EnterpriseCode;
                    // 入金入力拠点コード
                    depositAlwWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;
                    // 計上拠点コード
                    depositAlwWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    // 消込み日（消し込み日←システム日付）
                    depositAlwWork.ReconcileDate = DateTime.Now;
                    // 消込み計上日（消し込み日計上日←入金計上日）
                    depositAlwWork.ReconcileAddUpDate = createDepsitMainWork.AddUpADate;
                    // 入金伝票番号

                    // 入金金種コード
                    depositAlwWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    // 入金金種名称
                    depositAlwWork.DepositKindName = createDepsitMainWork.DepositKindName;
                    // 入金引当額
                    depositAlwWork.DepositAllowance = createDepsitMainWork.DepositTotal;
                    // 入金担当者コード
                    depositAlwWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;
                    // 入金担当者名称
                    depositAlwWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;
                    // 得意先コード
                    depositAlwWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    // 得意先名称
                    depositAlwWork.CustomerName = createDepsitMainWork.CustomerName;
                    // 得意先名称2
                    depositAlwWork.CustomerName2 = createDepsitMainWork.CustomerName2;
                    // ↓ 2007.10.12 980081 d
                    //// 受注番号
                    //depositAlwWork.AcceptAnOrderNo    = createDepsitMainWork.AcceptAnOrderNo;
                    //// サービス伝票区分
                    //depositAlwWork.ServiceSlipCd      = createDepsitMainWork.ServiceSlipCd;
                    // ↑ 2007.10.12 980081 d
                    // 赤伝相殺区分("0:黒伝"固定)
                    depositAlwWork.DebitNoteOffSetCd = 0;
                    // 預り金区分
                    depositAlwWork.DepositCd = createDepsitMainWork.DepositCd;
                    // ↓ 2007.10.12 980081 d
                    //// クレジット／ローン区分
                    //depositAlwWork.CreditOrLoanCd     = createDepsitMainWork.CreditOrLoanCd;
                    // ↑ 2007.10.12 980081 d
                    // ↓ 2007.10.12 980081
                    depositAlwWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;
                    depositAlwWork.SalesSlipNum = createDepsitMainWork.SalesSlipNum;
                    // ↑ 2007.10.12 980081
# endif
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    depositAlwWork.EnterpriseCode = EnterpriseCode;                             // 企業コード
                    depositAlwWork.LogicalDeleteCode = 0;                                       // 論理削除区分
                    depositAlwWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;  // 入金入力拠点コード
                    depositAlwWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;            // 計上拠点コード
                    depositAlwWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;      // 受注ステータス
                    depositAlwWork.SalesSlipNum = createDepsitMainWork.SalesSlipNum;            // 売上伝票番号
                    depositAlwWork.ReconcileDate = DateTime.Now;                                // 消込み日
                    depositAlwWork.ReconcileAddUpDate = createDepsitMainWork.AddUpADate;        // 消込み計上日
                    depositAlwWork.DepositAllowance = createDepsitMainWork.DepositTotal;        // 入金引当額
                    depositAlwWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;    // 入金担当者コード
                    depositAlwWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;        // 入金担当者名称
                    //depositAlwWork.CustomerCode = createDepsitMainWork.CustomerCode;          // 得意先コード
                    //depositAlwWork.CustomerName = createDepsitMainWork.CustomerName;          // 得意先名称
                    //depositAlwWork.CustomerName2 = createDepsitMainWork.CustomerName2;        // 得意先名称2
                    depositAlwWork.CustomerCode = createDepsitMainWork.ClaimCode;               // 得意先コード(請求先)
                    depositAlwWork.CustomerName = createDepsitMainWork.ClaimName;               // 得意先名称(請求先)
                    depositAlwWork.CustomerName2 = createDepsitMainWork.ClaimName2;             // 得意先名称2(請求先)
                    depositAlwWork.DebitNoteOffSetCd = 0;                                       // 赤伝相殺区分
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                    # endregion
                    // ↑ 20070123 18322 c

                    ArrayList ar = new ArrayList();
                    ar.Add(depositAlwWork);
                    DepositAlwWork[] depositAlwWorkList = (DepositAlwWork[])ar.ToArray(typeof(DepositAlwWork));

                    //--- DEL 2008/04/25 M.Kubota --->>>
                    // 更新時ロック処理(１件毎に排他処理を行う)
                    //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                    //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// 得意先別ロックをかける

                    //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    break;
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    // 入金マスタ更新処理
                    //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    status = this.Write(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                    // 更新時ロック解除
                    //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }

                    // 更新した入金番号を取得
                    depositSlipNoListAr.Add(depsitMainWork.DepositSlipNo);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    depositSlipNoList = (int[])depositSlipNoListAr.ToArray(typeof(int));
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //システムロック解除 //2009/1/27 Add sakurai
                    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            //-- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            //-- ADD 2008/04/25 M.Kubota ---<<<

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }


        /// <summary>
        /// 入金更新処理メイン
        /// </summary>
        /// <param name="depsitMainWork">入金情報ワーク</param>
        /// <param name="depsitDtlWorkArray">入金明細情報ワーク</param>
        /// <param name="depositAlwWorkArray">入金引当情報ワーク</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報を元にデータ更新を行います</br>
        /// <br>           : 入金番号無しの時、新規入金作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います(引当のみの削除可能)</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        # region --- DEL 2008/04/25 M.Kubota --->>>
        # if false
        public int Write(ref DepsitMainWork depsitMainWork, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int depositSlipNo = 0;
            DepsitMainWork bf_depsitMainWork = null;		// 更新前入金伝票情報
            bool mode_new = false;							// 新規入金モード

            Int64 Total_DepositAllowance = 0;
            Int64 Total_bf_DepositAllowance = 0;

            // 新規入金作成時
            if (depsitMainWork.DepositSlipNo == 0)
            {
                mode_new = true;							// 新規入金モード

                // 入金伝票番号の採番(番号管理上は更新拠点から取得する)
                status = CreateDepositSlipNoProc(depsitMainWork.EnterpriseCode, depsitMainWork.UpdateSecCd, out depositSlipNo, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 採番した入金番号を入金情報・引当情報にセット
                depsitMainWork.DepositSlipNo = depositSlipNo;

                foreach (DepositAlwWork depositAlwWork in depositAlwWorkArray)
                {
                    depositAlwWork.DepositSlipNo = depositSlipNo;

                    // ↓ 20070131 18322 a MA.NS用に設定
                    // ↓ 2007.10.12 980081 c
                    //if ((depositAlwWork.AcceptAnOrderNo == depsitMainWork.AcceptAnOrderNo) &&
                    //    (depositAlwWork.CustomerCode == depsitMainWork.CustomerCode))
                    if ((depositAlwWork.AcptAnOdrStatus == depsitMainWork.AcptAnOdrStatus) &&
                        (depositAlwWork.SalesSlipNum == depsitMainWork.SalesSlipNum) &&
                        (depositAlwWork.CustomerCode == depsitMainWork.CustomerCode))
                    // ↑ 2007.10.12 980081 c
                    {
                        depositAlwWork.CustomerName = depsitMainWork.CustomerName;
                        depositAlwWork.CustomerName2 = depsitMainWork.CustomerName2;
                    }
                    // ↑ 20070131 18322 a
                }
            }
            // 入金修正時
            else
            {
                // 更新前入金情報取得
                status = ReadDepsitMainWorkRec(depsitMainWork.EnterpriseCode, depsitMainWork.DepositSlipNo, out bf_depsitMainWork, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }

            ArrayList updAcceptOdrWorkList = new ArrayList();

            // 入金引当情報更新
            for (int ix = 0; ix < depositAlwWorkArray.Length; ix++)
            {
                Int64 bf_DepositAllowance;			// 更新前引当額
                // ↓ 20070124 18322 d MA.NS用に変更
                //Int64 bf_AcpOdrDepositAlwc;			// 更新前受注引当額 20060220 Ins
                //Int64 bf_VarCostDepoAlwc;			// 更新前諸費用引当額 20060220 Ins
                // ↑ 20070124 18322 d
                int bf_DepositCd;					// 更新前預り金区分
                // ↓ 2007.10.12 980081 d
                //int bf_CreditOrLoanCd;				// 更新前クレジット／ローン区分
                // ↑ 2007.10.12 980081 d

                DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkArray[ix];

                // ↓ 20070124 18322 d MA.NS用に変更
                //UpdAcceptOdrWork updAcceptOdrWork = new UpdAcceptOdrWork();
                //updAcceptOdrWork.AcceptAnOrderNo = 0;
                // ↑ 20070124 18322 d

                // ↓ 20070124 18322 d MA.NS用に変更
        #region SF 引当先受注伝票の読込み（全てコメントアウト）
                //// 期首残(受注番号=0)の時以外
                //if(depositAlwWork.AcceptAnOrderNo != 0)
                //{
                //  // 引当先受注伝票の読込み
                //	status = ReadAcceptOdrWorkRec(depositAlwWork.EnterpriseCode, depositAlwWork.AcceptAnOrderNo, ref updAcceptOdrWork, ref sqlConnection, ref sqlTransaction);
                //	if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //	{
                //		if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //		{
                //			return status;
                //		}
                //  
                //		updAcceptOdrWorkList.Add(updAcceptOdrWork);
                //	}
                //	// 受託定額計上データ時等は受注データが無いため、受注が無くても正常とする
                //	else
                //	{
                //		updAcceptOdrWork.AcceptAnOrderNo = 0;
                //	}
                //}
        #endregion
                // ↑ 20070124 18322 d

                // 引当削除指定時(論理削除区分＝１)
                if (depositAlwWork.LogicalDeleteCode == 1)
                {
                    depositAlwWork.DepositAllowance = 0;		// 入金引当額を０にする

                    // ↓ 20070123 18322 d MA.NS用に変更
                    //depositAlwWork.AcpOdrDepositAlwc = 0;		// 受注入金引当額を０にする 20060220 Ins
                    //depositAlwWork.VarCostDepoAlwc   = 0;		// 諸費用入金引当額を０にする 20060220 Ins
                    // ↑ 20070123 18322 d
                }

                // ↓↓↓入金引当ＭＴの更新時に更新前引当金額を取得しておき、請求売上更新時に引当額の差額更新を行う

                // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 処理（全てコメントアウト）
                //// 引当マスタ更新 (削除指定時は物理削除される)
                //status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, out bf_AcpOdrDepositAlwc, out bf_VarCostDepoAlwc, out bf_DepositCd, out bf_CreditOrLoanCd, ref sqlConnection, ref sqlTransaction);	// 20060220 Chg 更新前受注引当・諸費用引き当ての追加
                //if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //	return status;
                //}
                //
                //// 請求売上マスタの引当額更新
                //status = UpdateDmdSalesRec(ref depositAlwWork, bf_DepositAllowance, bf_AcpOdrDepositAlwc, bf_VarCostDepoAlwc, bf_DepositCd, bf_CreditOrLoanCd, depsitMainWork.CreditOrLoanCd , ref sqlConnection, ref sqlTransaction);	// 20060220 Chg 更新前受注引当・諸費用引き当ての追加
                //if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //	return status;
                //}
                //
                //// 期首残(受注番号=0) or 受注データが存在しない(受託定額計上データ等)時以外
                //if (depositAlwWork.AcceptAnOrderNo != 0 && updAcceptOdrWork.AcceptAnOrderNo != 0)
                //{
                //	// 更新用受注ワークへの引当額加減算処理
                //	status = CalcAcceptOdrWorkRec(depositAlwWork.CustomerCode, depositAlwWork, ref updAcceptOdrWork, bf_DepositAllowance, bf_DepositCd, bf_CreditOrLoanCd);
                //	if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //	{
                //		return status;
                //	}
                //
                //	// 受注マスタの引当額更新
                //	status = WriteAcceptOdrWorkRec(ref updAcceptOdrWork, ref sqlConnection, ref sqlTransaction);
                //	if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //	{
                //		return status;
                //	}
                //}
        #endregion

                // 引当マスタ更新 (削除指定時は物理削除される)
                status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, out bf_DepositCd, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 請求売上マスタの引当額更新
                status = UpdateSalesSlipRec(ref depositAlwWork, bf_DepositAllowance, bf_DepositCd, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // ↑ 20070124 18322 c

                // 新引当額
                Total_DepositAllowance += depositAlwWork.DepositAllowance;
                // 旧引当額
                Total_bf_DepositAllowance += bf_DepositAllowance;
            }

            // 引当額加減算
            //			depsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance  + Total_DepositAllowance - Total_bf_DepositAllowance;
            // 入金データ更新
            status = WriteDepsitMainWork(mode_new, ref depsitMainWork, ref sqlConnection, ref sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // ↓ 20070327 18322 d 得意先請求(売掛)金額マスタは準備処理で
            //                     更新するようになった為、削除
        #region 得意先請求(売掛)金額マスタ更新処理（全てコメントアウト）
            //// 金額マスタ更新 >>>>>>>>
            //UpdateCustAccDmdRec updateCustAccDmdRec = new UpdateCustAccDmdRec();
            //
            //CustAccUpdatePara bf_custAccUpdatePara = new CustAccUpdatePara();                        // 金額減算レコード
            //CustAccUpdatePara af_custAccUpdatePara = new CustAccUpdatePara();                        // 金額加算レコード
            //
            //ArrayList custAccUpdateParas = new ArrayList();                                    		// 金額マスタ更新部品パラメータ
            //
            //// 追加レコード
            //if(depsitMainWork.LogicalDeleteCode == 0)                                                	// 削除時以外
            //{
            //	af_custAccUpdatePara.AddDel = 0;                                                		// 追加削除区分:追加０
            //	af_custAccUpdatePara.AddUpADate            = depsitMainWork.AddUpADate;            		// 計上日付
            //	af_custAccUpdatePara.DemandAddUpSecCd	= depsitMainWork.AddUpSecCode;            		// 請求計上拠点コード
            //	if(depsitMainWork.DepositCd == 1)                                                		// 預かり金の場合
            //	{
            //		af_custAccUpdatePara.FeeDeposit2		= depsitMainWork.FeeDeposit;            	// 預り金手数料入金額
            //		af_custAccUpdatePara.DiscountDeposit2	= depsitMainWork.DiscountDeposit;            // 預り金値引入金額
            //		af_custAccUpdatePara.Deposit2            = depsitMainWork.Deposit;            		// 預り金入金金額(値引・手数料を除いた額)
            //        // ↓ 20070124 18322 a MA.NS用に変更
            //        // 預り金リベート入金額
            //        af_custAccUpdatePara.RebateDeposit2     = depsitMainWork.RebateDeposit;
            //        // ↑ 20070124 18322 a
            //
            //        // ↓ 20070123 18322 d MA.NS用に変更
            //        #region SF 諸費用別入金対応（全てコメントアウト）
            //        //// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// 受注入金額
            //		//af_custAccUpdatePara.AcpOdrChargeDeposit2= depsitMainWork.AcpOdrChargeDeposit;		// 預り金手数料入金額
            //		//af_custAccUpdatePara.AcpOdrDisDeposit2	= depsitMainWork.AcpOdrDisDeposit;            // 預り金値引入金額
            //		//af_custAccUpdatePara.AcpOdrDeposit2		= depsitMainWork.AcpOdrDeposit;            	// 預り金入金金額(値引・手数料を除いた額)
            //		//// 諸費用入金額
            //		//af_custAccUpdatePara.VarCostChargeDeposit2= depsitMainWork.VarCostChargeDeposit;	// 預り金諸費用手数料入金額
            //		//af_custAccUpdatePara.VarCostDisDeposit2	= depsitMainWork.VarCostDisDeposit;            // 預り金諸費用値引入金額
            //		//af_custAccUpdatePara.VariousCostDeposit2= depsitMainWork.VariousCostDeposit;		// 預り金諸費用入金金額(値引・手数料を除いた額)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // ↑ 20070123 18322 d
            //	}
            //	else
            //	{
            //		af_custAccUpdatePara.FeeDeposit            = depsitMainWork.FeeDeposit;            	// 手数料入金額
            //		af_custAccUpdatePara.DiscountDeposit	= depsitMainWork.DiscountDeposit;            // 値引入金額
            //		af_custAccUpdatePara.Deposit            = depsitMainWork.Deposit;            		// 入金金額
            //        // ↓ 20070124 18322 a MA.NS用に変更
            //        // リベート入金額
            //        af_custAccUpdatePara.RebateDeposit      = depsitMainWork.RebateDeposit;
            //        // ↑ 20070124 18322 a
            //
            //        // ↓ 20070123 18322 d NA.NS用に変更
            //        #region SF 諸費用別入金対応（全てコメントアウト）
            //        //// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// 受注入金額
            //		//af_custAccUpdatePara.AcpOdrChargeDeposit= depsitMainWork.AcpOdrChargeDeposit;		// 手数料入金額
            //		//af_custAccUpdatePara.AcpOdrDisDeposit	= depsitMainWork.AcpOdrDisDeposit;            // 値引入金額
            //		//af_custAccUpdatePara.AcpOdrDeposit		= depsitMainWork.AcpOdrDeposit;            	// 入金金額(値引・手数料を除いた額)
            //		//// 諸費用入金額
            //		//af_custAccUpdatePara.VarCostChargeDeposit= depsitMainWork.VarCostChargeDeposit;		// 諸費用手数料入金額
            //		//af_custAccUpdatePara.VarCostDisDeposit	= depsitMainWork.VarCostDisDeposit;            // 諸費用値引入金額
            //		//af_custAccUpdatePara.VariousCostDeposit	= depsitMainWork.VariousCostDeposit;		// 諸費用入金金額(値引・手数料を除いた額)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // ↑ 20070123 18322 d
            //	}
            //
            //	custAccUpdateParas.Add(af_custAccUpdatePara);                                    		// パラメータ追加
            //}
            //
            //// 削除レコード
            //if(mode_new == false)                                                            		// 入金修正時＞削除レコードも追加
            //{
            //	bf_custAccUpdatePara.AddDel = 1;                                                	// 追加削除区分:削除１
            //	bf_custAccUpdatePara.AddUpADate            = bf_depsitMainWork.AddUpADate;            	// 計上日付
            //	bf_custAccUpdatePara.DemandAddUpSecCd	= bf_depsitMainWork.AddUpSecCode;            // 請求計上拠点コード
            //	if(bf_depsitMainWork.DepositCd == 1)                                                // 預かり金の場合
            //	{
            //		bf_custAccUpdatePara.FeeDeposit2		= bf_depsitMainWork.FeeDeposit;            // 預り金手数料入金額
            //		bf_custAccUpdatePara.DiscountDeposit2	= bf_depsitMainWork.DiscountDeposit;	// 預り金値引入金額
            //		bf_custAccUpdatePara.Deposit2            = bf_depsitMainWork.Deposit;            // 預り金入金金額(値引・手数料を除いた額)
            //        // ↓ 20070124 18322 a MA.NS用に変更
            //        // 預り金リベート入金額
            //        bf_custAccUpdatePara.RebateDeposit2     = bf_depsitMainWork.RebateDeposit;
            //        // ↑ 20070124 18322 a
            //
            //        // ↓ 20070124 18322 d MA.NS用に変更
            //        #region SF 諸費用別入金対応（全てコメントアウト）
            //        //// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// 受注入金額
            //		//bf_custAccUpdatePara.AcpOdrChargeDeposit2= bf_depsitMainWork.AcpOdrChargeDeposit;	// 預り金手数料入金額
            //		//bf_custAccUpdatePara.AcpOdrDisDeposit2	= bf_depsitMainWork.AcpOdrDisDeposit;		// 預り金値引入金額
            //		//bf_custAccUpdatePara.AcpOdrDeposit2		= bf_depsitMainWork.AcpOdrDeposit;            // 預り金入金金額(値引・手数料を除いた額)
            //		//// 諸費用入金額
            //		//bf_custAccUpdatePara.VarCostChargeDeposit2= bf_depsitMainWork.VarCostChargeDeposit;	// 預り金諸費用手数料入金額
            //		//bf_custAccUpdatePara.VarCostDisDeposit2	= bf_depsitMainWork.VarCostDisDeposit;		// 預り金諸費用値引入金額
            //		//bf_custAccUpdatePara.VariousCostDeposit2= bf_depsitMainWork.VariousCostDeposit;		// 預り金諸費用入金金額(値引・手数料を除いた額)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // ↑ 20070124 18322 d
            //    }
            //	else
            //	{
            //		bf_custAccUpdatePara.FeeDeposit            = bf_depsitMainWork.FeeDeposit;            // 手数料入金額
            //		bf_custAccUpdatePara.DiscountDeposit	= bf_depsitMainWork.DiscountDeposit;	// 値引入金額
            //		bf_custAccUpdatePara.Deposit            = bf_depsitMainWork.Deposit;            // 入金金額
            //
            //        // ↓ 20070124 18322 a MA.NS用に変更
            //        // リベート入金額
            //        bf_custAccUpdatePara.RebateDeposit      = bf_depsitMainWork.RebateDeposit;
            //        // ↑ 20070124 18322 a
            //
            //        // ↓ 20070124 18322 d MA.NS用に変更
            //        #region SF 諸費用別入金対応（全てコメントアウト）
            //        //// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// 受注入金額
            //		//bf_custAccUpdatePara.AcpOdrChargeDeposit= bf_depsitMainWork.AcpOdrChargeDeposit;	// 手数料入金額
            //		//bf_custAccUpdatePara.AcpOdrDisDeposit	= bf_depsitMainWork.AcpOdrDisDeposit;		// 値引入金額
            //		//bf_custAccUpdatePara.AcpOdrDeposit		= bf_depsitMainWork.AcpOdrDeposit;            // 入金金額(値引・手数料を除いた額)
            //		//// 諸費用入金額
            //		//bf_custAccUpdatePara.VarCostChargeDeposit= bf_depsitMainWork.VarCostChargeDeposit;	// 諸費用手数料入金額
            //		//bf_custAccUpdatePara.VarCostDisDeposit	= bf_depsitMainWork.VarCostDisDeposit;		// 諸費用値引入金額
            //		//bf_custAccUpdatePara.VariousCostDeposit	= bf_depsitMainWork.VariousCostDeposit;		// 諸費用入金金額(値引・手数料を除いた額)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // ↑ 20070124 18322 d
            //	}
            //
            //	custAccUpdateParas.Add(bf_custAccUpdatePara);                                    	// パラメータ追加
            //}
            //
            //CustAccUpdatePara[] CustAccUpdateParasArray =  (CustAccUpdatePara[])custAccUpdateParas.ToArray(typeof(CustAccUpdatePara));
            //
            //// ↓ 20070131 18322 c MA.NS用に変更
            ////// 金額マスタ更新処理
            ////status = updateCustAccDmdRec.Write(depsitMainWork.EnterpriseCode, depsitMainWork.CustomerCode, CustAccUpdateParasArray, ref sqlConnection, ref sqlTransaction);
            //
            //// 金額マスタ更新処理(請求先の得意先請求金額・売掛金額マスタを作成)
            //status = updateCustAccDmdRec.Write(     depsitMainWork.EnterpriseCode
            //                                  ,     depsitMainWork.CustomerCode 
            //                                  ,     CustAccUpdateParasArray
            //                                  , ref sqlConnection
            //                                  , ref sqlTransaction);
            //// ↑ 20070131 18322 c
        #endregion
            // ↑ 20070327 18322 d

            return status;
        }
        # endif
        # endregion
        //--- ADD 2008/04/25 M.Kubota --->>>            
        public int Write(ref DepsitMainWork depsitMainWork, ref DepsitDtlWork[] depsitDtlWorkArray, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [パラメータチェック]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (depsitMainWork == null)
            {
                errmsg += ": 入金マスタデータが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += ": DB接続オブジェクトが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += ": トランザクションオブジェクトが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            string resName = this.GetResourceName(depsitMainWork.EnterpriseCode);
            status = this.Lock(resName, sqlConnection, sqlTransaction);

            try
            {
                status = this.WriteInitial(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WriteProc(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                this.Release(resName, sqlConnection, sqlTransaction);
            }

            return status;
        }
        
        /// <summary>
        /// 入金データ書込み準備処理
        /// </summary>
        /// <param name="depsitMainWork">入金マスタデータ</param>
        /// <param name="depsitDtlWorkArray">入金明細データの配列</param>
        /// <param name="depositAlwWorkArray">入金引当マスタデータの配列</param>
        /// <param name="sqlConnection">DB接続オブジェクト</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <returns>STATUS</returns>
        public int WriteInitial(ref DepsitMainWork depsitMainWork, ref DepsitDtlWork[] depsitDtlWorkArray, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [パラメータチェック]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (depsitMainWork == null)
            {
                errmsg += ": 入金マスタデータが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += ": DB接続オブジェクトが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += ": トランザクションオブジェクトが未設定です.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            if (depsitMainWork != null)
            {
                # region [入金マスタ 書込準備処理]
                // 入金伝票番号の採番
                if (depsitMainWork.DepositSlipNo == 0)
                {
                    // 入金伝票番号の採番(番号管理上は更新拠点から取得する)
                    int depositSlipNo = 0;
                    status = this.CreateDepositSlipNoProc(depsitMainWork.EnterpriseCode, depsitMainWork.UpdateSecCd, out depositSlipNo, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        depsitMainWork.DepositSlipNo = depositSlipNo;
                    }
                    else
                    {
                        // 入金伝票番号の採番に失敗した場合は終了
                        return status;
                    }
                }
                # endregion

                # region [入金明細データ 書込準備処理]
                // 入金明細データ
                if (depsitDtlWorkArray != null && depsitDtlWorkArray.Length > 0)
                {
                    foreach (DepsitDtlWork depsitDtlWork in depsitDtlWorkArray)
                    {
                        depsitDtlWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;  // 受注ステータス
                        depsitDtlWork.DepositSlipNo = depsitMainWork.DepositSlipNo;      // 入金伝票番号
                    }
                }
                # endregion

                # region [入金引当マスタデータ 書込準備処理]
                // 入金引当マスタデータ
                if (depositAlwWorkArray != null && depositAlwWorkArray.Length > 0)
                {
                    foreach (DepositAlwWork depositAlwWork in depositAlwWorkArray)
                    {
                        depositAlwWork.DepositSlipNo = depsitMainWork.DepositSlipNo;     // 入金伝票番号

                        if (depositAlwWork.LogicalDeleteCode == 1)
                        {
                            depositAlwWork.DepositAllowance = 0;		// 入金引当額を０にする
                        }

                        if ((depositAlwWork.AcptAnOdrStatus == depsitMainWork.AcptAnOdrStatus) &&
                            (depositAlwWork.SalesSlipNum == depsitMainWork.SalesSlipNum) &&
                            (depositAlwWork.CustomerCode == depsitMainWork.ClaimCode))
                        {
                            depositAlwWork.CustomerName = depsitMainWork.ClaimName;
                            depositAlwWork.CustomerName2 = depsitMainWork.ClaimName2;
                        }
                    }
                }
                # endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                errmsg += ": 入金マスタデータが未設定です.";
                base.WriteErrorLog(errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// 入金データ書込み処理
        /// </summary>
        /// <param name="depsitMainWork">入金マスタデータ</param>
        /// <param name="depsitDtlWorkArray">入金明細データの配列</param>
        /// <param name="depositAlwWorkArray">入金引当マスタデータの配列</param>
        /// <param name="sqlConnection">DB接続オブジェクト</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2012/10/17 wangf </br>
        /// <br>           : 10801804-00、Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの対応。</br>
        /// <br>           : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の対応。</br>
        /// <br>Update Note: 2012/10/29 wangf </br>
        /// <br>           : 10801804-00、Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。</br>
        /// <br>           : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。</br>
        /// <br>Update Note: 2012/11/06 wangf </br>
        /// <br>           : 10801804-00、Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。</br>
        /// <br>           : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。</br>
        /// <br>           : 入金合計はマイナス値を設定すれば、現在売掛残高の更新の対応。</br>
        public int WriteProc(ref DepsitMainWork depsitMainWork, ref DepsitDtlWork[] depsitDtlWorkArray, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (depsitMainWork != null)
            {
                if (depositAlwWorkArray != null)
                {
                    // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
                    int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
                    this.GetXmlInfo(ref dbCommandTimeout);
                    // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
                    // 入金引当情報更新
                    for (int ix = 0; ix < depositAlwWorkArray.Length; ix++)
                    {
                        Int64 bf_DepositAllowance;			// 更新前引当額
                        //int bf_DepositCd;					// 更新前預り金区分  //DEL 2008/04/25 M.Kubota

                        DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkArray[ix];

                        // ↓↓↓入金引当ＭＴの更新時に更新前引当金額を取得しておき、請求売上更新時に引当額の差額更新を行う

                        // 引当マスタ更新 (削除指定時は物理削除される)
                        //status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, out bf_DepositCd, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
                        //status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, ref sqlConnection, ref sqlTransaction);                      //ADD 2008/04/25 M.Kubota
                        status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, ref sqlConnection, ref sqlTransaction, dbCommandTimeout); 
                        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        // 請求売上マスタの引当額更新
                        //status = UpdateSalesSlipRec(ref depositAlwWork, bf_DepositAllowance, bf_DepositCd, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                        status = UpdateSalesSlipRec(ref depositAlwWork, bf_DepositAllowance, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                }
                // ------------ADD wangf 2012/10/17 FOR Redmine#32870--------->>>>
                // 入金データは更新保存か新規保存かの判断FLG
                bool flg = false;
                DepsitMainWork depsitMainWorkTmp;
                status = this.ReadDepsitMain(depsitMainWork.EnterpriseCode, depsitMainWork.DepositSlipNo, depsitMainWork.AcptAnOdrStatus, out depsitMainWorkTmp, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 存在すれば、更新保存
                    flg = true;
                }
                // ------------ADD wangf 2012/10/17 FOR Redmine#32870---------<<<<

                // 入金データ登録・更新
                //status = WriteDepsitMainWork(mode_new, ref depsitMainWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                status = WriteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 入金明細データ登録・更新
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitDtlWorkArray != null)
                {
                    status = this.WriteDepositDtlWork(ref depsitMainWork, ref depsitDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                }

                // 通常入金の場合にのみ、得意先マスタ(変動情報)の売掛残高を更新する、また元黒の更新処理の場合は更新しない
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.AutoDepositCd == 0 && depsitMainWork.DepositDebitNoteCd != 2)
                {
                    if (depsitMainWork.DepositDebitNoteCd == 1 && depsitMainWork.LogicalDeleteCode == 1)
                    {
                        // 赤伝の削除の場合は、この直ぐ後に元黒→黒伝の登録処理が走るので
                        // ２重に減算処理が行われるのを防ぐ目的で売掛残高の更新を行わない
                        // ------------ADD wangf 2012/10/29 FOR Redmine#32870--------->>>>
                        // 元黒と黒伝更新を実行すると、売掛残高の更新を行わないのため
                        // 赤伝の削除の場合は売掛残高は必ず計算します
                        CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                        cstChgWrk.EnterpriseCode = depsitMainWork.EnterpriseCode;
                        cstChgWrk.CustomerCode = depsitMainWork.ClaimCode;

                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        //status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, -(System.Math.Abs(depsitMainWork.DepositTotal)), ref sqlConnection, ref sqlTransaction);
                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        // 赤伝の削除の場合
                        // 売掛残高＝売掛残高+入金合計
                        status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, depsitMainWork.DepositTotal, ref sqlConnection, ref sqlTransaction);
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/10/29 FOR Redmine#32870---------<<<<
                    }
                    else
                    {
                        CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                        cstChgWrk.EnterpriseCode = depsitMainWork.EnterpriseCode;
                        cstChgWrk.CustomerCode = depsitMainWork.ClaimCode;

                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870--------->>>>                        
                        // 入金金額を持って売掛残高を加減算する
                        // 通常・元黒(売掛残高減算)・赤伝(売掛残高加算)で符号をかえる
                        //int sign = (depsitMainWork.DepositDebitNoteCd != 1) ? -1 : 1;

                        // 登録(売掛残高減算)・削除(売掛残高加算)で符号を変える
                        //sign *= (depsitMainWork.LogicalDeleteCode == 0) ? 1 : -1;
                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        // 赤伝登録の場合
                        // 売掛残高＝売掛残高-入金合計
                        // 通常・元黒登録の場合
                        // 売掛残高＝売掛残高-入金合計
                        // 通常・元黒削除の場合
                        // 売掛残高＝売掛残高+入金合計
                        // 入金合計は絶対値を使用しなくなって、自分自身の符号を含みました
                        // 通常・元黒・赤伝は登録すると、売掛残高減算
                        // 通常・元黒削除の場合、売掛残高加算
                        int sign = (depsitMainWork.LogicalDeleteCode == 0) ? -1 : 1;
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870---------<<<<

                        // ------------DEL wangf 2012/10/17 FOR Redmine#32870--------->>>>
                        // depsitMainWork.Depositは値引・手数料を除いた額のせいで、値引・手数料は計算は範囲以外
                        // 「入金計・値引・手数料を含む」としてのdepsitMainWork.DepositTotalを使用したら、問題ないと思います。
                        //Int64 differenceValue = System.Math.Abs(depsitMainWork.Deposit) * sign;
                        // ------------DEL wangf 2012/10/17 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/10/17 FOR Redmine#32870--------->>>>
                        //Int64 depositTotal = System.Math.Abs(depsitMainWork.DepositTotal) * sign; // DEL wangf 2012/11/06 FOR Redmine#32870
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        // 絶対値使用しない、自分自身の符号を含んで計算します
                        Int64 depositTotal = depsitMainWork.DepositTotal * sign;
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // 差額は「入金計・値引・手数料を含む」を初期化される、新規保存なら、この処理だけを行います。
                        Int64 differenceValue = depositTotal;
                        // 更新保存すれば、データベースに存在した指定される得意先の現在売掛残高を更新して
                        // 差額 = 入金計・値引・手数料を含む - 現在売掛残高
                        if (flg && depsitMainWork.LogicalDeleteCode != 1)
                        {
                            differenceValue -= sign * depsitMainWorkTmp.DepositTotal;
                        }
                        // ------------ADD wangf 2012/10/17 FOR Redmine#32870---------<<<<

                        status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, differenceValue, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }

            return status;
        }

        //--- ADD 2008/04/25 M.Kubota ---<<<

        /// <summary>
        /// 入金マスタ情報を更新します
        /// </summary>
        /// <param name="depsitMainWork">入金マスタ情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 入金情報を更新します</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.04</br>
        /// <br>Update Note: 2011/07/28 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        /// 
        //private int WriteDepsitMainWork(bool mode_new, ref DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        private int WriteDepsitMainWork(ref DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;  //ADD 2008/04/25 M.Kubota
            SqlDataReader myReader = null;
            //string updateText;     //DEL 2008/04/25 M.Kubota
            bool deleteSql = false;  //ADD 2008/04/25 M.Kubota

            // 更新日付を取得
            //DateTime Upd_UpdateDateTime = depsitMainWork.UpdateDateTime;  // DEL 2008/04/25 M.Kubota

            //Selectコマンドの生成
            try
            {
                //--- ADD 2008/04/25 M.Kubota --->>>
                # region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DEPMAIN.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DEPMAIN.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  DEPSITMAINRF AS DEPMAIN" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DEPMAIN.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DEPMAIN.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DEPMAIN.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);   // 企業コード
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);  // 受注ステータス
                findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);      // 入金伝票番号

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                    if (_updateDateTime != depsitMainWork.UpdateDateTime)
                    {
                        if (depsitMainWork.UpdateDateTime == DateTime.MinValue)
                        {
                            //新規登録で該当データ有りの場合には重複
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        }
                        else
                        {
                            //既存データで更新日時違いの場合には排他
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        }

                        return status;
                    }
                    // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    // 入金データを更新する前に、送信済みのチェックを行う
                    if (!CheckDepsitMainSending(depsitMainWork))
                    {
                        // チェックNG
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            myReader.Dispose();
                        }
                        return STATUS_CHK_SEND_ERR;
                    }
                    // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                    //if (depsitMainWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1) // DEL 2009/05/01
                    if (depsitMainWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData3) // ADD 2009/05/01
                    {
                        // 論理削除区分が 3 の場合は削除処理を行う
                        # region [DELETE文]
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  DEPSITMAINRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                        # endregion

                        deleteSql = true;
                    }
                    else
                    {
                        // 論理削除区分が 0 の場合は更新処理を行う
                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE DEPSITMAINRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += " ,DEPOSITDEBITNOTECDRF = @DEPOSITDEBITNOTECD" + Environment.NewLine;
                        sqlText += " ,DEPOSITSLIPNORF = @DEPOSITSLIPNO" + Environment.NewLine;
                        sqlText += " ,SALESSLIPNUMRF = @SALESSLIPNUM" + Environment.NewLine;
                        sqlText += " ,INPUTDEPOSITSECCDRF = @INPUTDEPOSITSECCD" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,UPDATESECCDRF = @UPDATESECCD" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,INPUTDAYRF = @INPUTDAY" + Environment.NewLine;
                        sqlText += " ,DEPOSITDATERF = @DEPOSITDATE" + Environment.NewLine;
                        sqlText += " ,ADDUPADATERF = @ADDUPADATE" + Environment.NewLine;
                        sqlText += " ,DEPOSITTOTALRF = @DEPOSITTOTAL" + Environment.NewLine;
                        sqlText += " ,DEPOSITRF = @DEPOSIT" + Environment.NewLine;
                        sqlText += " ,FEEDEPOSITRF = @FEEDEPOSIT" + Environment.NewLine;
                        sqlText += " ,DISCOUNTDEPOSITRF = @DISCOUNTDEPOSIT" + Environment.NewLine;
                        sqlText += " ,AUTODEPOSITCDRF = @AUTODEPOSITCD" + Environment.NewLine;
                        sqlText += " ,DRAFTDRAWINGDATERF = @DRAFTDRAWINGDATE" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDRF = @DRAFTKIND" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDNAMERF = @DRAFTKINDNAME" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDERF = @DRAFTDIVIDE" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDENAMERF = @DRAFTDIVIDENAME" + Environment.NewLine;
                        sqlText += " ,DRAFTNORF = @DRAFTNO" + Environment.NewLine;
                        sqlText += " ,DEPOSITALLOWANCERF = @DEPOSITALLOWANCE" + Environment.NewLine;
                        sqlText += " ,DEPOSITALWCBLNCERF = @DEPOSITALWCBLNCE" + Environment.NewLine;
                        sqlText += " ,DEBITNOTELINKDEPONORF = @DEBITNOTELINKDEPONO" + Environment.NewLine;
                        sqlText += " ,LASTRECONCILEADDUPDTRF = @LASTRECONCILEADDUPDT" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTCODERF = @DEPOSITAGENTCODE" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTNMRF = @DEPOSITAGENTNM" + Environment.NewLine;
                        sqlText += " ,DEPOSITINPUTAGENTCDRF = @DEPOSITINPUTAGENTCD" + Environment.NewLine;
                        sqlText += " ,DEPOSITINPUTAGENTNMRF = @DEPOSITINPUTAGENTNM" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAMERF = @CUSTOMERNAME" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAME2RF = @CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                        sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                        sqlText += " ,CLAIMNAMERF = @CLAIMNAME" + Environment.NewLine;
                        sqlText += " ,CLAIMNAME2RF = @CLAIMNAME2" + Environment.NewLine;
                        sqlText += " ,CLAIMSNMRF = @CLAIMSNM" + Environment.NewLine;
                        sqlText += " ,OUTLINERF = @OUTLINE" + Environment.NewLine;
                        sqlText += " ,BANKCODERF = @BANKCODE" + Environment.NewLine;
                        sqlText += " ,BANKNAMERF = @BANKNAME" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                        # endregion

                        //更新ヘッダ情報を設定
                        int logicalDeleteCode = depsitMainWork.LogicalDeleteCode; // 2009/05/01
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depsitMainWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        depsitMainWork.LogicalDeleteCode = logicalDeleteCode;  // 2009/05/01
                    }

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);   // 企業コード
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);  // 受注ステータス
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);      // 入金伝票番号
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (depsitMainWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DEPSITMAINRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,INPUTDEPOSITSECCDRF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,UPDATESECCDRF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITDATERF" + Environment.NewLine;
                    sqlText += " ,ADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,DEPOSITTOTALRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " ,FEEDEPOSITRF" + Environment.NewLine;
                    sqlText += " ,DISCOUNTDEPOSITRF" + Environment.NewLine;
                    sqlText += " ,AUTODEPOSITCDRF" + Environment.NewLine;
                    sqlText += " ,DRAFTDRAWINGDATERF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDRF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDENAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTNORF" + Environment.NewLine;
                    sqlText += " ,DEPOSITALLOWANCERF" + Environment.NewLine;
                    sqlText += " ,DEPOSITALWCBLNCERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTELINKDEPONORF" + Environment.NewLine;
                    sqlText += " ,LASTRECONCILEADDUPDTRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,DEPOSITAGENTNMRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += " ,CLAIMNAMERF" + Environment.NewLine;
                    sqlText += " ,CLAIMNAME2RF" + Environment.NewLine;
                    sqlText += " ,CLAIMSNMRF" + Environment.NewLine;
                    sqlText += " ,OUTLINERF" + Environment.NewLine;
                    sqlText += " ,BANKCODERF" + Environment.NewLine;
                    sqlText += " ,BANKNAMERF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@DEPOSITDEBITNOTECD" + Environment.NewLine;
                    sqlText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@INPUTDEPOSITSECCD" + Environment.NewLine;
                    sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += " ,@UPDATESECCD" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@INPUTDAY" + Environment.NewLine;
                    sqlText += " ,@DEPOSITDATE" + Environment.NewLine;
                    sqlText += " ,@ADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@DEPOSITTOTAL" + Environment.NewLine;
                    sqlText += " ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " ,@FEEDEPOSIT" + Environment.NewLine;
                    sqlText += " ,@DISCOUNTDEPOSIT" + Environment.NewLine;
                    sqlText += " ,@AUTODEPOSITCD" + Environment.NewLine;
                    sqlText += " ,@DRAFTDRAWINGDATE" + Environment.NewLine;
                    sqlText += " ,@DRAFTKIND" + Environment.NewLine;
                    sqlText += " ,@DRAFTKINDNAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDE" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDENAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTNO" + Environment.NewLine;
                    sqlText += " ,@DEPOSITALLOWANCE" + Environment.NewLine;
                    sqlText += " ,@DEPOSITALWCBLNCE" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTELINKDEPONO" + Environment.NewLine;
                    sqlText += " ,@LASTRECONCILEADDUPDT" + Environment.NewLine;
                    sqlText += " ,@DEPOSITAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@DEPOSITAGENTNM" + Environment.NewLine;
                    sqlText += " ,@DEPOSITINPUTAGENTCD" + Environment.NewLine;
                    sqlText += " ,@DEPOSITINPUTAGENTNM" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERNAME" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                    sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += " ,@CLAIMNAME" + Environment.NewLine;
                    sqlText += " ,@CLAIMNAME2" + Environment.NewLine;
                    sqlText += " ,@CLAIMSNM" + Environment.NewLine;
                    sqlText += " ,@OUTLINE" + Environment.NewLine;
                    sqlText += " ,@BANKCODE" + Environment.NewLine;
                    sqlText += " ,@BANKNAME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    # endregion

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)depsitMainWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                sqlCommand.CommandText = sqlText;

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (!deleteSql)  // 追加・更新の際にのみパラメータを設定する
                {
                    # region Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                    SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraDepositInputAgentCd = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraDepositInputAgentNm = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    # endregion

                    # region Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);                  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);                  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);                             // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);                               // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);                           // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);                             // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);                             // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);                        // 論理削除区分
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);                            // 受注ステータス
                    paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);                      // 入金赤黒区分
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);                                // 入金伝票番号
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depsitMainWork.SalesSlipNum);                                 // 売上伝票番号
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);                       // 入金入力拠点コード
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);                                 // 計上拠点コード
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);                                   // 更新拠点コード
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.SubSectionCode);                              // 部門コード
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.InputDay);                           // 入力日付  //ADD 2009/03/25
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);                     // 入金日付
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);                       // 計上日付
                    paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);                                  // 入金計
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);                                            // 入金金額
                    paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);                                      // 手数料入金額
                    paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);                            // 値引入金額
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);                                // 自動入金区分
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);           // 手形振出日
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftKind);                                        // 手形種類
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftKindName);                               // 手形種類名称
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftDivide);                                    // 手形区分
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftDivideName);                           // 手形区分名称
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftNo);                                           // 手形番号
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);                          // 入金引当額
                    paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);                          // 入金引当残高
                    paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);                    // 赤黒入金連結番号
                    paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);   // 最終消し込み計上日
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);                         // 入金担当者コード
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentNm);                             // 入金担当者名称
                    paraDepositInputAgentCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentCd);                   // 入金入力者コード
                    paraDepositInputAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentNm);                   // 入金入力者名称
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);                                  // 得意先コード
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName);                                 // 得意先名称
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName2);                               // 得意先名称2
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerSnm);                                   // 得意先略称
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ClaimCode);                                        // 請求先コード
                    paraClaimName.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName);                                       // 請求先名称
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName2);                                     // 請求先名称2
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimSnm);                                         // 請求先略称
                    paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);                                           // 伝票摘要
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.BankCode);                                          // 銀行コード
                    paraBankName.Value = SqlDataMediator.SqlSetString(depsitMainWork.BankName);                                         // 銀行名称
                    # endregion
                }

                int count = sqlCommand.ExecuteNonQuery();

                if (count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<

                # region --- DEL 2008/04/25 M.Kubota ---
                # if false
                // 変更箇所が大きすぎるのでがっつり削除
                if (mode_new == true)
                {
                    // ↓ 20070124 18322 c MA.NS用に変更
                    #region SF 入金マスタINSERT文（コメントアウト）
                    ////新規作成時のSQL文を生成
                    //updateText = "INSERT INTO DEPSITMAINRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, CUSTOMERCODERF, DEPOSITCDRF, DEPOSITTOTALRF, OUTLINERF, ACCEPTANORDERSALESNORF, INPUTDEPOSITSECCDRF, DEPOSITDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEPOSITAGENTCODERF, DEPOSITKINDDIVCDRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DEPOSITRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, AUTODEPOSITCDRF"
                    //	+ ", ACPODRDEPOSITRF, ACPODRCHARGEDEPOSITRF, ACPODRDISDEPOSITRF, VARIOUSCOSTDEPOSITRF, VARCOSTCHARGEDEPOSITRF, VARCOSTDISDEPOSITRF, ACPODRDEPOSITALWCRF, ACPODRDEPOALWCBLNCERF, VARCOSTDEPOALWCRF, VARCOSTDEPOALWCBLNCERF" // 20060220 Ins
                    //	+ ") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEPOSITDEBITNOTECD, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @CUSTOMERCODE, @DEPOSITCD, @DEPOSITTOTAL, @OUTLINE, @ACCEPTANORDERSALESNO, @INPUTDEPOSITSECCD, @DEPOSITDATE, @ADDUPSECCODE, @ADDUPADATE, @UPDATESECCD, @DEPOSITKINDNAME, @DEPOSITALLOWANCE, @DEPOSITALWCBLNCE, @DEPOSITAGENTCODE, @DEPOSITKINDDIVCD, @FEEDEPOSIT, @DISCOUNTDEPOSIT, @CREDITORLOANCD, @CREDITCOMPANYCODE, @DEPOSIT, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @DEBITNOTELINKDEPONO, @LASTRECONCILEADDUPDT, @AUTODEPOSITCD"
                    //	+ ", @ACPODRDEPOSIT, @ACPODRCHARGEDEPOSIT, @ACPODRDISDEPOSIT, @VARIOUSCOSTDEPOSIT, @VARCOSTCHARGEDEPOSIT, @VARCOSTDISDEPOSIT, @ACPODRDEPOSITALWC, @ACPODRDEPOALWCBLNCE, @VARCOSTDEPOALWC, @VARCOSTDEPOALWCBLNCE"	// 20060220 Ins
                    //	+ ")";
                    #endregion

                    #region 入金マスタINSERT文
                    // ↓ 2007.10.12 980081 c
                    #region 旧レイアウト(コメントアウト)
                    //updateText = "INSERT INTO DEPSITMAINRF ("
                    //                 + " CREATEDATETIMERF"
                    //                 + ",UPDATEDATETIMERF"
                    //                 + ",ENTERPRISECODERF"
                    //                 + ",FILEHEADERGUIDRF"
                    //                 + ",UPDEMPLOYEECODERF"
                    //                 + ",UPDASSEMBLYID1RF"
                    //                 + ",UPDASSEMBLYID2RF"
                    //                 + ",LOGICALDELETECODERF"
                    //                 + ",DEPOSITDEBITNOTECDRF"
                    //                 + ",DEPOSITSLIPNORF"
                    //                 + ",ACCEPTANORDERNORF"
                    //                 + ",SERVICESLIPCDRF"
                    //                 + ",INPUTDEPOSITSECCDRF"
                    //                 + ",ADDUPSECCODERF"
                    //                 + ",UPDATESECCDRF"
                    //                 + ",DEPOSITDATERF"
                    //                 + ",ADDUPADATERF"
                    //                 + ",DEPOSITKINDCODERF"
                    //                 + ",DEPOSITKINDNAMERF"
                    //                 + ",DEPOSITKINDDIVCDRF"
                    //                 + ",DEPOSITTOTALRF"
                    //                 + ",DEPOSITRF"
                    //                 + ",FEEDEPOSITRF"
                    //                 + ",DISCOUNTDEPOSITRF"
                    //                 + ",REBATEDEPOSITRF"
                    //                 + ",AUTODEPOSITCDRF"
                    //                 + ",DEPOSITCDRF"
                    //                 + ",CREDITORLOANCDRF"
                    //                 + ",CREDITCOMPANYCODERF"
                    //                 + ",DRAFTDRAWINGDATERF"
                    //                 + ",DRAFTPAYTIMELIMITRF"
                    //                 + ",DEPOSITALLOWANCERF"
                    //                 + ",DEPOSITALWCBLNCERF"
                    //                 + ",DEBITNOTELINKDEPONORF"
                    //                 + ",LASTRECONCILEADDUPDTRF"
                    //                 + ",DEPOSITAGENTCODERF"
                    //                 + ",DEPOSITAGENTNMRF"
                    //                 + ",CUSTOMERCODERF"
                    //                 + ",CUSTOMERNAMERF"
                    //                 + ",CUSTOMERNAME2RF"
                    //                 + ",OUTLINERF"
                    //           + ") VALUES ("
                    //                 + " @CREATEDATETIME"
                    //                 + ",@UPDATEDATETIME"
                    //                 + ",@ENTERPRISECODE"
                    //                 + ",@FILEHEADERGUID"
                    //                 + ",@UPDEMPLOYEECODE"
                    //                 + ",@UPDASSEMBLYID1"
                    //                 + ",@UPDASSEMBLYID2"
                    //                 + ",@LOGICALDELETECODE"
                    //                 + ",@DEPOSITDEBITNOTECD"
                    //                 + ",@DEPOSITSLIPNO"
                    //                 + ",@ACCEPTANORDERNO"
                    //                 + ",@SERVICESLIPCD"
                    //                 + ",@INPUTDEPOSITSECCD"
                    //                 + ",@ADDUPSECCODE"
                    //                 + ",@UPDATESECCD"
                    //                 + ",@DEPOSITDATE"
                    //                 + ",@ADDUPADATE"
                    //                 + ",@DEPOSITKINDCODE"
                    //                 + ",@DEPOSITKINDNAME"
                    //                 + ",@DEPOSITKINDDIVCD"
                    //                 + ",@DEPOSITTOTAL"
                    //                 + ",@DEPOSIT"
                    //                 + ",@FEEDEPOSIT"
                    //                 + ",@DISCOUNTDEPOSIT"
                    //                 + ",@REBATEDEPOSIT"
                    //                 + ",@AUTODEPOSITCD"
                    //                 + ",@DEPOSITCD"
                    //                 + ",@CREDITORLOANCD"
                    //                 + ",@CREDITCOMPANYCODE"
                    //                 + ",@DRAFTDRAWINGDATE"
                    //                 + ",@DRAFTPAYTIMELIMIT"
                    //                 + ",@DEPOSITALLOWANCE"
                    //                 + ",@DEPOSITALWCBLNCE"
                    //                 + ",@DEBITNOTELINKDEPONO"
                    //                 + ",@LASTRECONCILEADDUPDT"
                    //                 + ",@DEPOSITAGENTCODE"
                    //                 + ",@DEPOSITAGENTNM"
                    //                 + ",@CUSTOMERCODE"
                    //                 + ",@CUSTOMERNAME"
                    //                 + ",@CUSTOMERNAME2"
                    //                 + ",@OUTLINE"
                    //           + ")";
                    #endregion
                    updateText = "INSERT INTO DEPSITMAINRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, SALESSLIPNUMRF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, MINSECTIONCODERF, DEPOSITDATERF, ADDUPADATERF, DEPOSITKINDCODERF, DEPOSITKINDNAMERF, DEPOSITKINDDIVCDRF, DEPOSITTOTALRF, DEPOSITRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, AUTODEPOSITCDRF, DEPOSITCDRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, DEPOSITINPUTAGENTCDRF, DEPOSITINPUTAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, OUTLINERF, BANKCODERF, BANKNAMERF, EDISENDDATERF, EDITAKEINDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @DEPOSITDEBITNOTECD, @DEPOSITSLIPNO, @SALESSLIPNUM, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @MINSECTIONCODE, @DEPOSITDATE, @ADDUPADATE, @DEPOSITKINDCODE, @DEPOSITKINDNAME, @DEPOSITKINDDIVCD, @DEPOSITTOTAL, @DEPOSIT, @FEEDEPOSIT, @DISCOUNTDEPOSIT, @AUTODEPOSITCD, @DEPOSITCD, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEPOSITALLOWANCE, @DEPOSITALWCBLNCE, @DEBITNOTELINKDEPONO, @LASTRECONCILEADDUPDT, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @DEPOSITINPUTAGENTCD, @DEPOSITINPUTAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @CLAIMCODE, @CLAIMNAME, @CLAIMNAME2, @CLAIMSNM, @OUTLINE, @BANKCODE, @BANKNAME, @EDISENDDATE, @EDITAKEINDATE)";
                    // ↑ 2007.10.12 980081
                    #endregion
                    // ↑ 20070124 18322 c

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)depsitMainWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                else
                {
                    if (depsitMainWork.LogicalDeleteCode == 0)		// 論理削除区分が立っていない場合は通常更新実行
                    {
                        // ↓ 20070124 18322 c MA.NS用に変更
                        #region SF 入金マスタ UPDATE文（全てコメントアウト）
                        //// 更新日を更新検索キーに付加して更新（日付排他処理）
                        //updateText = "UPDATE DEPSITMAINRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DEPOSITDEBITNOTECDRF=@DEPOSITDEBITNOTECD , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITKINDCODERF=@DEPOSITKINDCODE , CUSTOMERCODERF=@CUSTOMERCODE , DEPOSITCDRF=@DEPOSITCD , DEPOSITTOTALRF=@DEPOSITTOTAL , OUTLINERF=@OUTLINE , ACCEPTANORDERSALESNORF=@ACCEPTANORDERSALESNO , INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD , DEPOSITDATERF=@DEPOSITDATE , ADDUPSECCODERF=@ADDUPSECCODE , ADDUPADATERF=@ADDUPADATE , UPDATESECCDRF=@UPDATESECCD , DEPOSITKINDNAMERF=@DEPOSITKINDNAME , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , DEPOSITALWCBLNCERF=@DEPOSITALWCBLNCE , DEPOSITAGENTCODERF=@DEPOSITAGENTCODE , DEPOSITKINDDIVCDRF=@DEPOSITKINDDIVCD , FEEDEPOSITRF=@FEEDEPOSIT , DISCOUNTDEPOSITRF=@DISCOUNTDEPOSIT , CREDITORLOANCDRF=@CREDITORLOANCD , CREDITCOMPANYCODERF=@CREDITCOMPANYCODE , DEPOSITRF=@DEPOSIT , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , DEBITNOTELINKDEPONORF=@DEBITNOTELINKDEPONO , LASTRECONCILEADDUPDTRF=@LASTRECONCILEADDUPDT, AUTODEPOSITCDRF=@AUTODEPOSITCD "
                        //	+", ACPODRDEPOSITRF=@ACPODRDEPOSIT , ACPODRCHARGEDEPOSITRF=@ACPODRCHARGEDEPOSIT , ACPODRDISDEPOSITRF=@ACPODRDISDEPOSIT , VARIOUSCOSTDEPOSITRF=@VARIOUSCOSTDEPOSIT , VARCOSTCHARGEDEPOSITRF=@VARCOSTCHARGEDEPOSIT , VARCOSTDISDEPOSITRF=@VARCOSTDISDEPOSIT , ACPODRDEPOSITALWCRF=@ACPODRDEPOSITALWC , ACPODRDEPOALWCBLNCERF=@ACPODRDEPOALWCBLNCE , VARCOSTDEPOALWCRF=@VARCOSTDEPOALWC , VARCOSTDEPOALWCBLNCERF=@VARCOSTDEPOALWCBLNCE " // 20060220 Ins
                        //	+"WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                        #endregion

                        #region 入金マスタ UPDATE文
                        // 更新日を更新検索キーに付加して更新（日付排他処理）
                        // ↓ 2007.10.12 980081 d
                        #region 旧レイアウト(コメントアウト)
                        //updateText = "UPDATE DEPSITMAINRF"
                        //             + " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                        //             +     ",ENTERPRISECODERF=@ENTERPRISECODE"
                        //             +     ",FILEHEADERGUIDRF=@FILEHEADERGUID"
                        //             +     ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                        //             +     ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                        //             +     ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                        //             +     ",LOGICALDELETECODERF=@LOGICALDELETECODE"
                        //             +     ",DEPOSITDEBITNOTECDRF=@DEPOSITDEBITNOTECD"
                        //             +     ",DEPOSITSLIPNORF=@DEPOSITSLIPNO"
                        //             +     ",ACCEPTANORDERNORF=@ACCEPTANORDERNO"
                        //             +     ",SERVICESLIPCDRF=@SERVICESLIPCD"
                        //             +     ",INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD"
                        //             +     ",ADDUPSECCODERF=@ADDUPSECCODE"
                        //             +     ",UPDATESECCDRF=@UPDATESECCD"
                        //             +     ",DEPOSITDATERF=@DEPOSITDATE"
                        //             +     ",ADDUPADATERF=@ADDUPADATE"
                        //             +     ",DEPOSITKINDCODERF=@DEPOSITKINDCODE"
                        //             +     ",DEPOSITKINDNAMERF=@DEPOSITKINDNAME"
                        //             +     ",DEPOSITKINDDIVCDRF=@DEPOSITKINDDIVCD"
                        //             +     ",DEPOSITTOTALRF=@DEPOSITTOTAL"
                        //             +     ",DEPOSITRF=@DEPOSIT"
                        //             +     ",FEEDEPOSITRF=@FEEDEPOSIT"
                        //             +     ",DISCOUNTDEPOSITRF=@DISCOUNTDEPOSIT"
                        //             +     ",REBATEDEPOSITRF=@REBATEDEPOSIT"
                        //             +     ",AUTODEPOSITCDRF=@AUTODEPOSITCD"
                        //             +     ",DEPOSITCDRF=@DEPOSITCD"
                        //             +     ",CREDITORLOANCDRF=@CREDITORLOANCD"
                        //             +     ",CREDITCOMPANYCODERF=@CREDITCOMPANYCODE"
                        //             +     ",DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE"
                        //             +     ",DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT"
                        //             +     ",DEPOSITALLOWANCERF=@DEPOSITALLOWANCE"
                        //             +     ",DEPOSITALWCBLNCERF=@DEPOSITALWCBLNCE"
                        //             +     ",DEBITNOTELINKDEPONORF=@DEBITNOTELINKDEPONO"
                        //             +     ",LASTRECONCILEADDUPDTRF=@LASTRECONCILEADDUPDT"
                        //             +     ",DEPOSITAGENTCODERF=@DEPOSITAGENTCODE"
                        //             +     ",DEPOSITAGENTNMRF=@DEPOSITAGENTNM"
                        //             +     ",CUSTOMERCODERF=@CUSTOMERCODE"
                        //             +     ",CUSTOMERNAMERF=@CUSTOMERNAME"
                        //             +     ",CUSTOMERNAME2RF=@CUSTOMERNAME2"
                        //             +     ",OUTLINERF=@OUTLINE"
                        //           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                        //             + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                        //             + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                        //             ;
                        #endregion
                        updateText = "UPDATE DEPSITMAINRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , DEPOSITDEBITNOTECDRF=@DEPOSITDEBITNOTECD , DEPOSITSLIPNORF=@DEPOSITSLIPNO , SALESSLIPNUMRF=@SALESSLIPNUM , INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD , ADDUPSECCODERF=@ADDUPSECCODE , UPDATESECCDRF=@UPDATESECCD , SUBSECTIONCODERF=@SUBSECTIONCODE , MINSECTIONCODERF=@MINSECTIONCODE , DEPOSITDATERF=@DEPOSITDATE , ADDUPADATERF=@ADDUPADATE , DEPOSITKINDCODERF=@DEPOSITKINDCODE , DEPOSITKINDNAMERF=@DEPOSITKINDNAME , DEPOSITKINDDIVCDRF=@DEPOSITKINDDIVCD , DEPOSITTOTALRF=@DEPOSITTOTAL , DEPOSITRF=@DEPOSIT , FEEDEPOSITRF=@FEEDEPOSIT , DISCOUNTDEPOSITRF=@DISCOUNTDEPOSIT , AUTODEPOSITCDRF=@AUTODEPOSITCD , DEPOSITCDRF=@DEPOSITCD , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , DRAFTKINDRF=@DRAFTKIND , DRAFTKINDNAMERF=@DRAFTKINDNAME , DRAFTDIVIDERF=@DRAFTDIVIDE , DRAFTDIVIDENAMERF=@DRAFTDIVIDENAME , DRAFTNORF=@DRAFTNO , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , DEPOSITALWCBLNCERF=@DEPOSITALWCBLNCE , DEBITNOTELINKDEPONORF=@DEBITNOTELINKDEPONO , LASTRECONCILEADDUPDTRF=@LASTRECONCILEADDUPDT , DEPOSITAGENTCODERF=@DEPOSITAGENTCODE , DEPOSITAGENTNMRF=@DEPOSITAGENTNM , DEPOSITINPUTAGENTCDRF=@DEPOSITINPUTAGENTCD , DEPOSITINPUTAGENTNMRF=@DEPOSITINPUTAGENTNM , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , CUSTOMERSNMRF=@CUSTOMERSNM , CLAIMCODERF=@CLAIMCODE , CLAIMNAMERF=@CLAIMNAME , CLAIMNAME2RF=@CLAIMNAME2 , CLAIMSNMRF=@CLAIMSNM , OUTLINERF=@OUTLINE , BANKCODERF=@BANKCODE , BANKNAMERF=@BANKNAME , EDISENDDATERF=@EDISENDDATE , EDITAKEINDATERF=@EDITAKEINDATE"
                                   + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                                     + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                                     + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                     ;
                        // ↑ 2007.10.12 980081 d
                        #endregion
                        // ↑ 20070124 18322 c

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depsitMainWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                    }
                    else											// 論理削除区分が立っている場合は削除処理実行
                    {
                        // 更新日を更新検索キーに付加して削除（日付排他処理）
                        updateText = "DELETE DEPSITMAINRF "
                            + "WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                    }

                }

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    //Parameterオブジェクトへ値設定
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);

                    // ↓ 200701224 18322 c MA.NS用に変更
                    #region SF Parameterオブジェクト設定（全てコメントアウト）
                    //#region Parameterオブジェクトの作成(更新用)
                    ////Parameterオブジェクトの作成(更新用)
                    //SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    //SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    //SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    //SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    //SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                    //SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    //SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    //SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    //SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                    //SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    //SqlParameter paraAcceptAnOrderSalesNo = sqlCommand.Parameters.Add("@ACCEPTANORDERSALESNO", SqlDbType.Int);
                    //SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    //SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                    //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    //SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    //SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    //SqlParameter paraDepositKindName = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    //SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    //SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    //SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    //SqlParameter paraDepositKindDivCd = sqlCommand.Parameters.Add("@DEPOSITKINDDIVCD", SqlDbType.Int);
                    //SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    //SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    //SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    //SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    //SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                    //SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                    //SqlParameter parAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    //// 20060217 Ins Start >>>>>>>>>>>>>>>>>
                    //SqlParameter paraAcpOdrDeposit = sqlCommand.Parameters.Add("@ACPODRDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrChargeDeposit = sqlCommand.Parameters.Add("@ACPODRCHARGEDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrDisDeposit = sqlCommand.Parameters.Add("@ACPODRDISDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraVariousCostDeposit = sqlCommand.Parameters.Add("@VARIOUSCOSTDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraVarCostChargeDeposit = sqlCommand.Parameters.Add("@VARCOSTCHARGEDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraVarCostDisDeposit = sqlCommand.Parameters.Add("@VARCOSTDISDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrDepositAlwc = sqlCommand.Parameters.Add("@ACPODRDEPOSITALWC", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrDepoAlwcBlnce = sqlCommand.Parameters.Add("@ACPODRDEPOALWCBLNCE", SqlDbType.BigInt);
                    //SqlParameter paraVarCostDepoAlwc = sqlCommand.Parameters.Add("@VARCOSTDEPOALWC", SqlDbType.BigInt);
                    //SqlParameter paraVarCostDepoAlwcBlnce = sqlCommand.Parameters.Add("@VARCOSTDEPOALWCBLNCE", SqlDbType.BigInt);
                    //// 20060217 Ins End <<<<<<<<<<<<<<<<<<<
                    //#endregion
                    //
                    //#region Parameterオブジェクトへ値設定(更新用)
                    //paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                    //paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                    //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    //paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                    //paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                    //paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                    //paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                    //paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);
                    //paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                    //paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindCode);
                    //paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);
                    //paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositCd);
                    //paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);
                    //paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);
                    //paraAcceptAnOrderSalesNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcceptAnOrderSalesNo);
                    //paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);
                    //paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);
                    //paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);
                    //paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);
                    //paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);
                    //paraDepositKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositKindName);
                    //paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);
                    //paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);
                    //paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);
                    //paraDepositKindDivCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindDivCd);
                    //paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);
                    //paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);
                    //paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CreditOrLoanCd);
                    //paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.CreditCompanyCode);
                    //paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);
                    //paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);
                    //paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftPayTimeLimit);
                    //paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);
                    //paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);
                    //parAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);
                    //// 20060217 Ins Start >>>>>>>>>>>>>>>>>
                    //paraAcpOdrDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDeposit);
                    //paraAcpOdrChargeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrChargeDeposit);
                    //paraAcpOdrDisDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDisDeposit);
                    //paraVariousCostDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VariousCostDeposit);
                    //paraVarCostChargeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostChargeDeposit);
                    //paraVarCostDisDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostDisDeposit);
                    //paraAcpOdrDepositAlwc.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDepositAlwc);
                    //paraAcpOdrDepoAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDepoAlwcBlnce);
                    //paraVarCostDepoAlwc.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostDepoAlwc);
                    //paraVarCostDepoAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostDepoAlwcBlnce);
                    //// 20060217 Ins End <<<<<<<<<<<<<<<<<<<
                    //#endregion
                    #endregion

                    #region 入金マスタ Parameterオブジェクトの作成(更新用)
                    // 作成日時
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // 更新日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // 企業コード
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // 更新従業員コード
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // 更新アセンブリID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // 論理削除区分
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // 入金赤黒区分
                    SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                    // 入金伝票番号
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    // ↓ 2007.10.12 980081 a
                    //// 受注番号
                    //SqlParameter paraAcceptAnOrderNo       = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    //// サービス伝票区分
                    //SqlParameter paraServiceSlipCd         = sqlCommand.Parameters.Add("@SERVICESLIPCD", SqlDbType.Int);
                    // ↑ 2007.10.12 980081 a
                    // 入金入力拠点コード
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    // 計上拠点コード
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    // 更新拠点コード
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    // 入金日付
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                    // 計上日付
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    // 入金金種コード
                    SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    // 入金金種名称
                    SqlParameter paraDepositKindName = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    // 入金金種区分
                    SqlParameter paraDepositKindDivCd = sqlCommand.Parameters.Add("@DEPOSITKINDDIVCD", SqlDbType.Int);
                    // 入金計
                    SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                    // 入金金額
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    // 手数料入金額
                    SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                    // 値引入金額
                    SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                    // ↓ 2007.10.12 980081 d
                    //// リベート入金額
                    //SqlParameter paraRebateDeposit         = sqlCommand.Parameters.Add("@REBATEDEPOSIT", SqlDbType.BigInt);
                    // ↑ 2007.10.12 980081 d
                    // 自動入金区分
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    // 預り金区分
                    SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    // ↓ 2007.10.12 980081 d
                    //// クレジット／ローン区分
                    //SqlParameter paraCreditOrLoanCd        = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    //// クレジット会社コード
                    //SqlParameter paraCreditCompanyCode     = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    // ↑ 2007.10.12 980081 d
                    // 手形振出日
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    // 手形支払期日
                    SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    // 入金引当額
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    // 入金引当残高
                    SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    // 赤黒入金連結番号
                    SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                    // 最終消し込み計上日
                    SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                    // 入金担当者コード
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    // 入金担当者名称
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    // 得意先コード
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // 得意先名称
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    // 得意先名称2
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    // 伝票摘要
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    // ↓ 2007.10.12 980081 a
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraMinSectionCode = sqlCommand.Parameters.Add("@MINSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDepositInputAgentCd = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraDepositInputAgentNm = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    // ↑ 2007.10.12 980081 a
                    #endregion

                    #region 入金マスタ Parameterオブジェクトへ値設定(更新用)
                    // 作成日時
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                    // 更新日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                    // 企業コード
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                    // 更新従業員コード
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                    // 更新アセンブリID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                    // 更新アセンブリID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                    // 論理削除区分
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                    // 入金赤黒区分
                    paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);
                    // 入金伝票番号
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                    // ↓ 2007.10.12 980081 d
                    //// 受注番号
                    //paraAcceptAnOrderNo.Value      = SqlDataMediator.SqlSetInt32(depsitMainWork.AcceptAnOrderNo);
                    //// サービス伝票区分
                    //paraServiceSlipCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ServiceSlipCd);
                    // ↑ 2007.10.12 980081 d
                    // 入金入力拠点コード
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);
                    // 計上拠点コード
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);
                    // 更新拠点コード
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);
                    // 入金日付
                    // ↓ 2008.03.17 980081 c
                    //paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                    // ↑ 2008.03.17 980081 c
                    // 計上日付
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);
                    // 入金金種コード
                    paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindCode);
                    // 入金金種名称
                    paraDepositKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositKindName);
                    // 入金金種区分
                    paraDepositKindDivCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindDivCd);
                    // 入金計
                    paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);
                    // 入金金額
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);
                    // 手数料入金額
                    paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);
                    // 値引入金額
                    paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);
                    // ↓ 2007.10.12 980081 d
                    //// リベート入金額
                    //paraRebateDeposit.Value        = SqlDataMediator.SqlSetInt64(depsitMainWork.RebateDeposit);
                    // ↑ 2007.10.12 980081 d
                    // 自動入金区分
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);
                    // 預り金区分
                    paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositCd);
                    // ↓ 2007.10.12 980081 d
                    //// クレジット／ローン区分
                    //paraCreditOrLoanCd.Value       = SqlDataMediator.SqlSetInt32(depsitMainWork.CreditOrLoanCd);
                    //// クレジット会社コード
                    //paraCreditCompanyCode.Value    = SqlDataMediator.SqlSetString(depsitMainWork.CreditCompanyCode);
                    // ↑ 2007.10.12 980081 d
                    // 手形振出日
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);
                    // 手形支払期日
                    paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftPayTimeLimit);
                    // 入金引当額
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);
                    // 入金引当残高
                    paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);
                    // 赤黒入金連結番号
                    paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);
                    // 最終消し込み計上日
                    paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);
                    // 入金担当者コード
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);
                    // 入金担当者名称
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentNm);
                    // 得意先コード
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);
                    // 得意先名称
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName);
                    // 得意先名称2
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName2);
                    // 伝票摘要
                    paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);
                    // ↓ 2007.10.12 980081 a
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depsitMainWork.SalesSlipNum);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.SubSectionCode);
                    paraMinSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.MinSectionCode);
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftKind);
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftKindName);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftDivide);
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftDivideName);
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftNo);
                    paraDepositInputAgentCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentCd);
                    paraDepositInputAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentNm);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerSnm);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ClaimCode);
                    paraClaimName.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName);
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName2);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimSnm);
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.BankCode);
                    paraBankName.Value = SqlDataMediator.SqlSetString(depsitMainWork.BankName);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.EdiSendDate);
                    // ↓ 2007.12.10 980081 c
                    //paraEdiTakeInDate.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.EdiTakeInDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.EdiTakeInDate);
                    // ↑ 2007.12.10 980081 c
                    // ↑ 2007.10.12 980081 a
                    #endregion
                    // ↑ 20070124 18322 c

                    int count = sqlCommand.ExecuteNonQuery();

                    // 更新件数が無い場合はすでに削除されている意味で排他を戻す
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
                # endif
                # endregion
            }
            catch (SqlException ex)
            {
                //--- DEL 2008/04/258 M.Kubota --- >>>
                //if (myReader != null && !myReader.IsClosed) myReader.Close();
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);
                //--- DEL 2008/04/25 M.Kubota --- <<<
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// 入金引当マスタ情報を更新します
        /// </summary>
        /// <param name="depositAlwWork">入金引当情報</param>
        /// <param name="bf_DepositAllowance">更新前引当額</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="dbCommandTimeout">コマンドタイムアウト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金引当マスタ情報の更新を行います</br>
        /// <br>           : 更新時に更新前情報を読み込み、引当額・預かり金区分・クレジット区分の取得も行います</br>
        /// <br>           : ※更新前情報は売上データ更新時に必要となるため</br>
        /// <br>Programmer : 18322 T.Kimura </br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        /// </remarks>
        //private int WriteDepositAlwWork(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, out int bf_DepositCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        //private int WriteDepositAlwWork(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        private int WriteDepositAlwWork(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int dbCommandTimeout)
        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            bf_DepositAllowance = 0;
            //bf_DepositCd = 0;  //DEL 2008/04/25 M.Kubota
            // ↓ 2007.10.12 980081 d
            //bf_CreditOrLoanCd = 0;
            // ↑ 2007.10.12 980081 d

            bool deleteSql = false;
            //Selectコマンドの生成
            try
            {
                string selectSql = "SELECT UPDATEDATETIMERF"                        // 更新日時
                                 + ", ENTERPRISECODERF"                        // 企業コード
                                 + ", DEPOSITALLOWANCERF"                      // 入金引当額
                    //+ ", DEPOSITCDRF"                             // 預り金区分  //DEL 2008/04/25 M.Kubota
                    // ↓ 2007.10.12 980081 d
                    //+      ", CREDITORLOANCDRF"                        // クレジット／ローン区分
                    // ↑ 2007.10.12 980081 d
                                 + " FROM DEPOSITALWRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"    // 企業コード
                    // ↓ 2007.10.12 980081 c
                    //+ " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"  // 受注番号
                                 + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"  // 受注ステータス
                                 + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"        // 売上伝票番号
                    // ↑ 2007.10.12 980081 c
                                 + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"        // 得意先コード
                                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"      // 入金伝票番号
                                 + " AND ADDUPSECCODERF=@FINDADDUPSECCODE"        // 計上拠点コード
                                 ;
                using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2007.10.12 980081 c
                    //SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2007.10.12 980081 c
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    //                    SqlParameter findParaReconcileDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // ↓ 2007.10.12 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // ↑ 2007.10.12 980081 c
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    //                    findParaReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);

                    sqlCommand.CommandTimeout = dbCommandTimeout; // ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != depositAlwWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (depositAlwWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            sqlCommand.Cancel();
                            if (myReader != null && !myReader.IsClosed) myReader.Close();
                            return status;
                        }

                        // 更新前引当額、更新前預り金区分、クレジット区分取得
                        bf_DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));        // 引当額
                        //bf_DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));                // 預かり金区分
                        // ↓ 2007.10.12 980081 d
                        //bf_CreditOrLoanCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));        // クレジット／ローン区分
                        // ↑ 2007.10.12 980081 d

                        if (depositAlwWork.LogicalDeleteCode == 0)
                        {
                            // 論理削除区分が立っていない場合は通常更新実行
                            # region --- DEL 2008/04/25 M.Kubota --->>>
                            // ↓ 2007.10.12 980081 c
                            #region 旧レイアウト(コメントアウト)
                            //sqlCommand.CommandText =
                            //         "UPDATE DEPOSITALWRF"
                            //         + " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                            //             + ",ENTERPRISECODERF=@ENTERPRISECODE"
                            //             + ",FILEHEADERGUIDRF=@FILEHEADERGUID"
                            //             + ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                            //             + ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                            //             + ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                            //             + ",LOGICALDELETECODERF=@LOGICALDELETECODE"
                            //             + ",INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD"
                            //             + ",ADDUPSECCODERF=@ADDUPSECCODE"
                            //             + ",RECONCILEDATERF=@RECONCILEDATE"
                            //             + ",RECONCILEADDUPDATERF=@RECONCILEADDUPDATE"
                            //             + ",DEPOSITSLIPNORF=@DEPOSITSLIPNO"
                            //             + ",DEPOSITKINDCODERF=@DEPOSITKINDCODE"
                            //             + ",DEPOSITKINDNAMERF=@DEPOSITKINDNAME"
                            //             + ",DEPOSITALLOWANCERF=@DEPOSITALLOWANCE"
                            //             + ",DEPOSITAGENTCODERF=@DEPOSITAGENTCODE"
                            //             + ",DEPOSITAGENTNMRF=@DEPOSITAGENTNM"
                            //             + ",CUSTOMERCODERF=@CUSTOMERCODE"
                            //             + ",CUSTOMERNAMERF=@CUSTOMERNAME"
                            //             + ",CUSTOMERNAME2RF=@CUSTOMERNAME2"
                            //             + ",ACCEPTANORDERNORF=@ACCEPTANORDERNO"
                            //             + ",SERVICESLIPCDRF=@SERVICESLIPCD"
                            //             + ",DEBITNOTEOFFSETCDRF=@DEBITNOTEOFFSETCD"
                            //             + ",DEPOSITCDRF=@DEPOSITCD"
                            //             + ",CREDITORLOANCDRF=@CREDITORLOANCD"
                            //       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //          + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //          + " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                            //          + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //          + " AND ADDUPSECCODERF=@ADDUPSECCODE"
                            //          ;
                            #endregion
                            //sqlCommand.CommandText =
                            //         "UPDATE DEPOSITALWRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD , ADDUPSECCODERF=@ADDUPSECCODE , RECONCILEDATERF=@RECONCILEDATE , RECONCILEADDUPDATERF=@RECONCILEADDUPDATE , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITKINDCODERF=@DEPOSITKINDCODE , DEPOSITKINDNAMERF=@DEPOSITKINDNAME , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , DEPOSITAGENTCODERF=@DEPOSITAGENTCODE , DEPOSITAGENTNMRF=@DEPOSITAGENTNM , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , DEBITNOTEOFFSETCDRF=@DEBITNOTEOFFSETCD , DEPOSITCDRF=@DEPOSITCD , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , SALESSLIPNUMRF=@SALESSLIPNUM"
                            //       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //          + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //          + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                            //          + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                            //          + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //          + " AND ADDUPSECCODERF=@ADDUPSECCODE"
                            //          ;
                            // ↑ 2007.10.12 980081 c
                            # endregion

                            # region [UPDATE文]
                            //--- ADD 2008/04/25 M.Kubota --->>>
                            string sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  DEPOSITALWRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,INPUTDEPOSITSECCDRF = @INPUTDEPOSITSECCD" + Environment.NewLine;
                            sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                            sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += " ,SALESSLIPNUMRF = @SALESSLIPNUM" + Environment.NewLine;
                            sqlText += " ,RECONCILEDATERF = @RECONCILEDATE" + Environment.NewLine;
                            sqlText += " ,RECONCILEADDUPDATERF = @RECONCILEADDUPDATE" + Environment.NewLine;
                            sqlText += " ,DEPOSITSLIPNORF = @DEPOSITSLIPNO" + Environment.NewLine;
                            sqlText += " ,DEPOSITALLOWANCERF = @DEPOSITALLOWANCE" + Environment.NewLine;
                            sqlText += " ,DEPOSITAGENTCODERF = @DEPOSITAGENTCODE" + Environment.NewLine;
                            sqlText += " ,DEPOSITAGENTNMRF = @DEPOSITAGENTNM" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERNAMERF = @CUSTOMERNAME" + Environment.NewLine;
                            sqlText += " ,CUSTOMERNAME2RF = @CUSTOMERNAME2" + Environment.NewLine;
                            sqlText += " ,DEBITNOTEOFFSETCDRF = @DEBITNOTEOFFSETCD" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            //--- ADD 2008/04/25 M.Kubota ---<<<
                            # endregion

                            // 更新ヘッダ情報を設定
                            //--- ADD 2008/04/25 M.Kubota --->>>
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)depositAlwWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            //--- ADD 2008/04/25 M.Kubota ---<<<
                        }
                        else
                        {
                            // 論理削除区分が立っている場合は削除処理実行
                            # region --- DEL 2008/04/25 M.Kubota ---
                            // ↓ 2007.10.12 980081 c
                            //sqlCommand.CommandText = "DELETE DEPOSITALWRF"
                            //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //                       + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //                       + " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                            //                       + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //                       + " AND ADDUPSECCODERF=@ADDUPSECCODE";
                            //sqlCommand.CommandText = "DELETE DEPOSITALWRF"
                            //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //                       + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //                       + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                            //                       + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                            //                       + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //                       + " AND ADDUPSECCODERF=@ADDUPSECCODE";
                            // ↑ 2007.10.12 980081 c
                            # endregion

                            //this.ReadDataToDepositAlw(ref depositAlwWork, myReader);  //ADD 2008/04/25 M.Kubota

                            # region [DELETE文]
                            //--- ADD 2008/04/25 M.Kubota --->>>
                            string sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  DEPOSITALWRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            //--- ADD 2008/04/25 M.Kubota ---<<<
                            # endregion

                            deleteSql = true;  //ADD 2008/04/25 M.Kubota
                        }

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                        // ↓ 2007.10.12 980081 c
                        //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                        findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                        findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                        // ↑ 2007.10.12 980081 c
                        //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);  //DEL 2008/04/25 M.Kubota
                        findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                        // ????消し込み計上日をどうするか？
                        //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode); //DEL 2008/04/25 M.Kubota

                        // 更新ヘッダ情報を設定
                        //--- DEL 2008/04/25 M.Kubota --->>>
                        //object obj = (object)this;
                        //IFileHeader flhd = (IFileHeader)depositAlwWork;
                        //FileHeader fileHeader = new FileHeader(obj);
                        //fileHeader.SetUpdateHeader(ref flhd, obj);
                        //--- DEL 2008/04/25 M.Kubota ---<<<
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている
                        // 場合はすでに削除されている意味で排他を戻す
                        if (depositAlwWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null && !myReader.IsClosed) myReader.Close();
                            return status;
                        }

                        # region --- DEL 2008/04/25 M.Kubota ---
                        // ↓ 2007.10.12 980081 c
                        #region 旧レイアウト(コメントアウト)
                        //sqlCommand.CommandText =
                        //      "INSERT INTO DEPOSITALWRF("
                        //            + " CREATEDATETIMERF"
                        //            + ",UPDATEDATETIMERF"
                        //            + ",ENTERPRISECODERF"
                        //            + ",FILEHEADERGUIDRF"
                        //            + ",UPDEMPLOYEECODERF"
                        //            + ",UPDASSEMBLYID1RF"
                        //            + ",UPDASSEMBLYID2RF"
                        //            + ",LOGICALDELETECODERF"
                        //            + ",INPUTDEPOSITSECCDRF"
                        //            + ",ADDUPSECCODERF"
                        //            + ",RECONCILEDATERF"
                        //            + ",RECONCILEADDUPDATERF"
                        //            + ",DEPOSITSLIPNORF"
                        //            + ",DEPOSITKINDCODERF"
                        //            + ",DEPOSITKINDNAMERF"
                        //            + ",DEPOSITALLOWANCERF"
                        //            + ",DEPOSITAGENTCODERF"
                        //            + ",DEPOSITAGENTNMRF"
                        //            + ",CUSTOMERCODERF"
                        //            + ",CUSTOMERNAMERF"
                        //            + ",CUSTOMERNAME2RF"
                        //            + ",ACCEPTANORDERNORF"
                        //            + ",SERVICESLIPCDRF"
                        //            + ",DEBITNOTEOFFSETCDRF"
                        //            + ",DEPOSITCDRF"
                        //            + ",CREDITORLOANCDRF"
                        //    + ") VALUES ("
                        //            + " @CREATEDATETIME"
                        //            + ",@UPDATEDATETIME"
                        //            + ",@ENTERPRISECODE"
                        //            + ",@FILEHEADERGUID"
                        //            + ",@UPDEMPLOYEECODE"
                        //            + ",@UPDASSEMBLYID1"
                        //            + ",@UPDASSEMBLYID2"
                        //            + ",@LOGICALDELETECODE"
                        //            + ",@INPUTDEPOSITSECCD"
                        //            + ",@ADDUPSECCODE"
                        //            + ",@RECONCILEDATE"
                        //            + ",@RECONCILEADDUPDATE"
                        //            + ",@DEPOSITSLIPNO"
                        //            + ",@DEPOSITKINDCODE"
                        //            + ",@DEPOSITKINDNAME"
                        //            + ",@DEPOSITALLOWANCE"
                        //            + ",@DEPOSITAGENTCODE"
                        //            + ",@DEPOSITAGENTNM"
                        //            + ",@CUSTOMERCODE"
                        //            + ",@CUSTOMERNAME"
                        //            + ",@CUSTOMERNAME2"
                        //            + ",@ACCEPTANORDERNO"
                        //            + ",@SERVICESLIPCD"
                        //            + ",@DEBITNOTEOFFSETCD"
                        //            + ",@DEPOSITCD"
                        //            + ",@CREDITORLOANCD"
                        //    + ")";
                        #endregion
                        //sqlCommand.CommandText =
                        //      "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, ACPTANODRSTATUSRF, SALESSLIPNUMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITKINDNAME, @DEPOSITALLOWANCE, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @DEBITNOTEOFFSETCD, @DEPOSITCD, @ACPTANODRSTATUS, @SALESSLIPNUM)";
                        // ↑ 2007.10.12 980081 c
                        # endregion

                        # region [INSERT文]
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        string sqlText = string.Empty;
                        sqlText += "INSERT INTO DEPOSITALWRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,INPUTDEPOSITSECCDRF" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += " ,RECONCILEDATERF" + Environment.NewLine;
                        sqlText += " ,RECONCILEADDUPDATERF" + Environment.NewLine;
                        sqlText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                        sqlText += " ,DEPOSITALLOWANCERF" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTCODERF" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTNMRF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEOFFSETCDRF" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@INPUTDEPOSITSECCD" + Environment.NewLine;
                        sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                        sqlText += " ,@RECONCILEDATE" + Environment.NewLine;
                        sqlText += " ,@RECONCILEADDUPDATE" + Environment.NewLine;
                        sqlText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                        sqlText += " ,@DEPOSITALLOWANCE" + Environment.NewLine;
                        sqlText += " ,@DEPOSITAGENTCODE" + Environment.NewLine;
                        sqlText += " ,@DEPOSITAGENTNM" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERNAME" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += " ,@DEBITNOTEOFFSETCD" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depositAlwWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader != null && !myReader.IsClosed) myReader.Close();

                    if (!deleteSql)  //ADD 2008/04/25 M.Kubota
                    {
                        #region Parameterオブジェクトの作成(更新用)
                        # region --- DEL 2008/04/25 M.Kubota --->>>
# if false
                    // 作成日時
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // 更新日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // 企業コード
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // 更新従業員コード
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // 更新アセンブリID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // 論理削除区分
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // 入金入力拠点コード
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    // 計上拠点コード
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    // 消込み日
                    SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                    // 消込み計上日
                    SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                    // 入金伝票番号
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    // 入金金種コード
                    SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    // 入金金種名称
                    SqlParameter paraDepositKindName = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    // 入金引当額
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    // 入金担当者コード
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    // 入金担当者名称
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    // 得意先コード
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // 得意先名称
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    // 得意先名称2
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    // ↓ 2007.10.12 980081 d
                    //// 受注番号
                    //SqlParameter paraAcceptAnOrderNo    = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    //// サービス伝票区分
                    //SqlParameter paraServiceSlipCd      = sqlCommand.Parameters.Add("@SERVICESLIPCD", SqlDbType.Int);
                    // ↑ 2007.10.12 980081 d
                    // 赤伝相殺区分
                    SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
                    // 預り金区分
                    SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    // ↓ 2007.10.12 980081 d
                    //// クレジット／ローン区分
                    //SqlParameter paraCreditOrLoanCd     = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    // ↑ 2007.10.12 980081 d
                    // ↓ 2007.10.12 980081 a
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2007.10.12 980081 a
# endif
                    # endregion

                        //--- ADD 2008/04/25 M.Kubota --->>>
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                        SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                        SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                        SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                        SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                        SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                        SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        # region --- DEL 2008/04/25 M.Kubota ---
# if fasle
                    // 作成日時
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
                    // 更新日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
                    // 企業コード
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
                    // 更新従業員コード
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
                    // 更新アセンブリID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
                    // 更新アセンブリID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
                    // 論理削除区分
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
                    // 入金入力拠点コード
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
                    // 計上拠点コード
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                    // 消込み日
                    paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    // 消込み計上日
                    paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
                    // 入金伝票番号
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    // 入金金種コード
                    paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
                    // 入金金種名称
                    paraDepositKindName.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositKindName);
                    // 入金引当額
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
                    // 入金担当者コード
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
                    // 入金担当者名称
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
                    // 得意先コード
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    // 得意先名称
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
                    // 得意先名称2
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
                    // ↓ 2007.10.12 980081 d
                    //// 受注番号
                    //paraAcceptAnOrderNo.Value      = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    //// サービス伝票区分
                    //paraServiceSlipCd.Value        = SqlDataMediator.SqlSetInt32(depositAlwWork.ServiceSlipCd);
                    // ↑ 2007.10.12 980081 d
                    // 赤伝相殺区分
                    paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
                    // 預り金区分
                    paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
                    // ↓ 2007.10.12 980081 d
                    //// クレジット／ローン区分
                    //paraCreditOrLoanCd.Value       = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
                    // ↑ 2007.10.12 980081 d
                    // ↓ 2007.10.12 980081 a
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // ↑ 2007.10.12 980081 a
# endif
                    # endregion

                        //--- ADD 2008/04/25 M.Kubota --->>>
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);              // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);              // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);                         // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);                           // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);                       // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);                         // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);                         // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);                    // 論理削除区分
                        paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);                   // 入金入力拠点コード
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);                             // 計上拠点コード
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);                        // 受注ステータス
                        paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);                             // 売上伝票番号
                        paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);             // 消込み日
                        paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);   // 消込み計上日
                        paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);                            // 入金伝票番号
                        paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);                      // 入金引当額
                        paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);                     // 入金担当者コード
                        paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);                         // 入金担当者名称
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);                              // 得意先コード
                        paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);                             // 得意先名称
                        paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);                           // 得意先名称2
                        paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);                    // 赤伝相殺区分
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        #endregion
                    }

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //--- DEL 2008/04/25 M.Kubota --->>>
                //if (myReader != null && !myReader.IsClosed) myReader.Close();
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota

            return status;
        }
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainWrk"></param>
        /// <param name="depsitDtlWrkArray"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int WriteDepositDtlWork(ref DepsitMainWork depsitMainWrk, ref DepsitDtlWork[] depsitDtlWrkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                # region [DELETE文]
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  DEPSITDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWrk.EnterpriseCode);   // 企業コード
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.AcptAnOdrStatus);  // 受注ステータス
                findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.DepositSlipNo);      // 入金伝票番号

                sqlCommand.ExecuteNonQuery();

                // 2009/05/01 >>>>>>>>>>>>>>>>>>>>>>
                //if (depsitMainWrk.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) 
                if ((depsitMainWrk.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) ||
                    (depsitMainWrk.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1))
                // 2009/05/01 <<<<<<<<<<<<<<<<<<<<<<
                {
                    sqlCommand.Parameters.Clear();

                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DEPSITDTLRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                    sqlText += " ,DEPOSITROWNORF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " ,VALIDITYTERMRF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                    sqlText += " ,@DEPOSITROWNO" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += " ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " ,@VALIDITYTERM" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    # region Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                    SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                    SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                    SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    # endregion

                    foreach (DepsitDtlWork depsitDtlWork in depsitDtlWrkArray)
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depsitDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        depsitDtlWork.LogicalDeleteCode = depsitMainWrk.LogicalDeleteCode;  // ADD 2009/05/01 伝票の論理削除区分をセット
                        
                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitDtlWork.CreateDateTime);   // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitDtlWork.UpdateDateTime);   // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitDtlWork.EnterpriseCode);              // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitDtlWork.FileHeaderGuid);                // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitDtlWork.UpdEmployeeCode);            // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitDtlWork.UpdAssemblyId1);              // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitDtlWork.UpdAssemblyId2);              // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.LogicalDeleteCode);         // 論理削除区分
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.AcptAnOdrStatus);             // 受注ステータス
                        paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.DepositSlipNo);                 // 入金伝票番号
                        paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.DepositRowNo);                   // 入金行番号
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.MoneyKindCode);                 // 金種コード
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(depsitDtlWork.MoneyKindName);                // 金種名称
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.MoneyKindDiv);                   // 金種区分
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitDtlWork.Deposit);                             // 入金金額
                        paraValidityTerm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitDtlWork.ValidityTerm);    // 有効期限
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }
                    sqlDataReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        
        /// <summary>
        /// 入金伝票番号を採番して返します
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="SectionCode">拠点コード(採番基準拠点)</param>
        /// <param name="depositSlipNo">入金伝票番号</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金伝票番号を採番して返します</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.03</br>
        /// </remarks>	
        private int CreateDepositSlipNoProc(string EnterpriseCode, string SectionCode, out int depositSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            /*
                        int status;

                        // 入金伝票番号の最終値を取得
                        status = GetMaxDepositSlipNoProc(out depositSlipNo, EnterpriseCode, ref sqlConnection,ref sqlTransaction);
                        if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // インクリメント
                            depositSlipNo++;
                        }
            */
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            depositSlipNo = 0;
            //string retMsg = "";  //DEL 2008/04/25 M.Kubota

            //NumberNumbering numberNumbering = new NumberNumbering();  //DEL 2008/04/25 M.Kubota
            NumberingManager numberingManager = new NumberingManager(); //ADD 2008/04/25 M.Kubota  

            //番号範囲分ループ
            Int32 loopCnt = 1;
            while (loopCnt <= 999999999)
            {
                //string no;  //DEL 2008/04/25 M.Kubota
                long no;      //ADD 2008/04/25 M.Kubota

                //Int32 ptnCd;  //DEL 2008/04/25 M.Kubota
                //番号採番
                //status = numberNumbering.Numbering(EnterpriseCode, SectionCode, 3, new string[0], out no, out ptnCd, out retMsg);  //DEL 2008/04/25 M.Kubota

                status = numberingManager.GetSerialNumber(EnterpriseCode, SectionCode, SerialNumberCode.DepositSlipNo, out no);  //ADD 2008/04/25 M.Kubota

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //番号を数値型に変換
                    Int32 wkDepositSlipNo = System.Convert.ToInt32(no);  // Int32 ← Int64 で変換
                    SqlDataReader myReader = null;

                    //入金空き番チェック
                    try
                    {
                        # region [SELECT文]
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        string sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  DEP.DEPOSITSLIPNORF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  DEPSITMAINRF AS DEP" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  DEP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DEP.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        # endregion
                        
                        //Selectコマンドの生成
                        //using (SqlCommand sqlCommand = new SqlCommand("SELECT DEPOSITSLIPNORF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))  //DEL 2008/04/25 M.Kubota
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))  //ADD 2008/04/25 M.Kubota
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                            findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(wkDepositSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //データ無しの場合には戻り値をセット
                            if (!myReader.Read())
                            {
                                depositSlipNo = wkDepositSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        //基底クラスに例外を渡して処理してもらう
                        //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                    }
                    finally
                    {
                        //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                                myReader.Close();
                            myReader.Dispose();
                        }
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) break;
                }
                //採番できなかった場合には処理中断。
                else break;

                //同一番号がある場合にはループカウンタをインクリメントし再採番
                loopCnt++;
            }

            //全件ループしても取得出来ない場合
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                //retMsg = "入金番号に空き番号がありません。削除可能な入金伝票を削除してください。";  //DEL 2008/04/25 M.Kubota
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }

        /// <summary>
        /// 売上データ情報の引当額・引当残高を更新します
        /// </summary>
        /// <param name="depositAlwWork">入金引当情報</param>
        /// <param name="bf_DepositAllowance">更新前入金引当額</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金引当情報と、更新前引当情報・クレジットローン区分により売上データを更新します</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        /// </remarks>    
        //private int UpdateSalesSlipRec(ref DepositAlwWork depositAlwWork, Int64 bf_DepositAllowance, int bf_DepositCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        private int UpdateSalesSlipRec(ref DepositAlwWork depositAlwWork, Int64 bf_DepositAllowance, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）//ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 
            // Updateコマンドの生成
            try
            {
                string updateSql = "UPDATE SALESSLIPRF"
                                 + " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                                 + ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                                 + ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                                 + ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                                 + ",DEPOSITALLOWANCETTLRF=DEPOSITALLOWANCETTLRF+@DF_DEPOSITALLOWANCETTL"  // 入金引当合計額
                                 //+ ",MNYDEPOALLOWANCETTLRF=MNYDEPOALLOWANCETTLRF+@DF_MNYDEPOALLOWANCETTL"  // 預り金引当合計額  //DEL 2008/04/25 M.Kubota
                                 + ",DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF-@DF_DEPOSITALLOWANCETTL"        // 入金引当残高
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                    // ↓ 2007.10.12 980081 c
                    //+ " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                                 + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                                 + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                    // ↑ 2007.10.12 980081 c
                                 + " AND CLAIMCODERF=@FINDCLAIMCODE"
                                 ;

                using (SqlCommand sqlCommand = new SqlCommand(updateSql, sqlConnection, sqlTransaction))
                {
                    //--------------------------------
                    // 検索条件のオブジェクト設定
                    //--------------------------------
                    #region 検索条件設定
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2007.10.12 980081 c
                    //SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2007.10.12 980081 c
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // ↓ 2007.10.12 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // ↑ 2007.10.12 980081 c
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    #endregion

                    //--------------------------------
                    // 設定項目のオブジェクト設定
                    //--------------------------------
                    #region Parameterオブジェクトの作成(更新用)
                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);    // 更新日
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                    // 引当差額
                    SqlParameter paraDF_DepositAllowance = sqlCommand.Parameters.Add("@DF_DEPOSITALLOWANCETTL", SqlDbType.BigInt);
                    // 預り金引当差額
                    //SqlParameter paraDF_MnyOnDepoAllowance = sqlCommand.Parameters.Add("@DF_MNYDEPOALLOWANCETTL", SqlDbType.BigInt);  //DEL 2008/04/25 M.Kubota
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    // 入金引当合計額
                    //     入金引当.入金引当額 - 編集前.入金引当合計額
                    Int64 df_DepositAllowanceTtl = depositAlwWork.DepositAllowance - bf_DepositAllowance;

                    //--- DEL 2008/04/25 M.Kubota --->>>
                    // 預り金引当差額
                    //Int64 df_MnyOnDepoAllowance = 0;
                    //if (bf_DepositCd == 1)
                    //{
                    //    // 編集前が預り金の時は、預り金引当合計額から編集前の預り金を引く
                    //    df_MnyOnDepoAllowance -= bf_DepositAllowance;
                    //}

                    //if (depositAlwWork.DepositCd == 1)
                    //{
                    //    // 今回が預り金の時は、預り金引当合計額に今回の預り金を加算
                    //    df_MnyOnDepoAllowance += depositAlwWork.DepositAllowance;
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    // ■更新ヘッダ情報を設定 
                    object obj = (object)this;
                    FileHeader fileHeader = new FileHeader(obj);
                    // 更新日
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(fileHeader.NewFileHeaderDateTime());
                    // 更新従業員コード
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(fileHeader.UpdEmployeeCode);
                    // 更新アセンブリID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(fileHeader.UpdAssemblyId1);
                    // 更新アセンブリID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(fileHeader.GetUpdAssemblyID(this));

                    // ■変更情報を設定 
                    // 引当差額
                    paraDF_DepositAllowance.Value = SqlDataMediator.SqlSetInt64(df_DepositAllowanceTtl);
                    // 預り金引当差額
                    //paraDF_MnyOnDepoAllowance.Value = SqlDataMediator.SqlSetInt64(df_MnyOnDepoAllowance);  //DEL 2008/04/25 M.Kubota

                    #endregion

                    // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
                    this.GetXmlInfo(ref dbCommandTimeout);
                    sqlCommand.CommandTimeout = dbCommandTimeout;
                    // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
                    int count = sqlCommand.ExecuteNonQuery();

                    // 更新件数が無い場合はすでに削除されている意味で排他を戻す
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }

            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 入金データの送信済みのチェック
        /// </summary>
        /// <param name="depsitMainWork">入金情報ワーク</param>
        /// <returns>true: チェックOK、false：チェックNG</returns>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note : 2012/02/06 田建委</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#28288 送信済データ修正制御の対応</br>
        /// <br>Update Note : 2012/08/10  脇田 靖之</br>
        /// <br>            : 拠点管理 送信済データチェック不具合対応</br>
        private bool CheckDepsitMainSending(DepsitMainWork depsitMainWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // チェックを行うかどうかが下記のように判断する(②～③)
            // ②拠点管理送受信対象マスタに入金データの拠点管理送信区分が「1:送信あり」----------->
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
            secMngSndRcvWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
            object outSecMngSndRcvList = null;

            // 拠点管理送受信対象マスタ情報を取得
            status = this.ScMngSndRcvDB.Search(out outSecMngSndRcvList, secMngSndRcvWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSndRcvList = outSecMngSndRcvList as ArrayList;

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSndRcvList || secMngSndRcvList.Count == 0)
                // ０件の場合、チェックOK
                return true;

            bool isHaveObj = false;
            foreach (SecMngSndRcvWork resultSecMngSndRcvWork in secMngSndRcvList)
            {
                if (string.Equals("DepsitMainRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase)
                    && resultSecMngSndRcvWork.SecMngSendDiv == 1
                    && resultSecMngSndRcvWork.LogicalDeleteCode == 0
                    )
                {
                    isHaveObj = true;
                    break;
                }
            }
            if (!isHaveObj)
                // ０件の場合、チェックOK
                return true;
            // ②拠点管理送受信対象マスタに入金データの拠点管理送信区分が「1:送信あり」-----------<


            // ③拠点管理設定マスタに下記の情報に当たるレコードが存在する ------------------------>>
            // 種別＝0:データ
            // 受信状況＝0:送信
            // 送信対象拠点＝更新する入金データの計上拠点コード
            // 送信済データ修正区分＝修正不可
            object outSecMngSetList = null;
            SecMngSetWork paraSecMngSetWork = new SecMngSetWork();
            paraSecMngSetWork.EnterpriseCode = depsitMainWork.EnterpriseCode;

            // 拠点管理設定マスタ情報を取得
            status = this.ScMngSetDB.Search(out outSecMngSetList, paraSecMngSetWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSetList = outSecMngSetList as ArrayList;


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSetList || secMngSetList.Count == 0)
                // ０件の場合、チェックOK
                return true;

            isHaveObj = false;
            // 入金計上拠点コード
            string addUpSecCode = depsitMainWork.AddUpSecCode;
            if (null != addUpSecCode)
                addUpSecCode = addUpSecCode.Trim();
            DateTime maxSyncExecDate = DateTime.MinValue; // 拠点管理設定マスタの送信実行日
            int sndFinDataEdDiv = -1; //ADD by 陳建明　2011/11/10
            foreach (SecMngSetWork resultSecMngSetWork in secMngSetList)
            {
                if (resultSecMngSetWork.Kind == 0 && resultSecMngSetWork.ReceiveCondition == 0
                    // 種別＝0:データ && 受信状況＝0:送信
                    && resultSecMngSetWork.SectionCode.Trim() == addUpSecCode
                    // 送信対象拠点＝更新する入金データの計上拠点コード
                     && (resultSecMngSetWork.SndFinDataEdDiv == 1 || resultSecMngSetWork.SndFinDataEdDiv == 2) //ADD by 陳建明　2011/11/10
                    //&& resultSecMngSetWork.SndFinDataEdDiv == 1 //DEL by 陳建明　2011/11/10
                    // 送信済データ修正区分＝修正不可
                    && resultSecMngSetWork.LogicalDeleteCode == 0
                    )
                {
                    isHaveObj = true;
                    if (resultSecMngSetWork.SyncExecDate.CompareTo(maxSyncExecDate) > 0)
                    //ADD by 陳建明　2011/11/10 start---->>>>>>    
                    {
                        sndFinDataEdDiv = resultSecMngSetWork.SndFinDataEdDiv;
                        //ADD by 陳建明　2011/11/10 end  ----<<<<<<   
                        maxSyncExecDate = resultSecMngSetWork.SyncExecDate;
                    }//ADD by 陳建明　2011/11/10
                }
            }
            if (!isHaveObj)
                // ０件の場合、チェックOK
                return true;
            // ③拠点管理設定マスタに下記の情報に当たるレコードが存在する ------------------------<<


            // チェック処理 -------------------------------------->>>
            //ADD by 陳建明　2011/11/10 start---->>>>>>
            if ((sndFinDataEdDiv == 1 && depsitMainWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) ||
                //(sndFinDataEdDiv == 2 && depsitMainWork.DepositDate.CompareTo(maxSyncExecDate) <= 0)) // DEL 2011/12/15
                //(sndFinDataEdDiv == 2 && depsitMainWork.PreDepositDate.CompareTo(maxSyncExecDate) <= 0)) // ADD 2011/12/15 // DEL 2012/02/06 田建委 Redmine#28288
                //(sndFinDataEdDiv == 2 && depsitMainWork.PreDepositDate.CompareTo(maxSyncExecDate) <= 0 && depsitMainWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)) // ADD 2012/02/06 田建委 Redmine#28288 DEL 2012/08/10 Y.Wakita
                (sndFinDataEdDiv == 2 && depsitMainWork.PreDepositDate.CompareTo(maxSyncExecDate) <= 0 && depsitMainWork.UpdateDateTime.ToString("HHmmss").CompareTo(maxSyncExecDate.ToString("HHmmss")) <= 0)) // ADD 2012/08/10 Y.Wakita
            //ADD by 陳建明　2011/11/10 end  ----<<<<<<
            //if (depsitMainWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) //DEL by 陳建明　2011/11/10
            {
                // チェックNG
                // 送信済みのデータが更新できない、エラーメッセージをログに出力
                System.Text.StringBuilder errMessage = new System.Text.StringBuilder();
                errMessage.Append(NSDebug.GetExecutingMethodName(new StackFrame()));
                errMessage.Append(": 送信済みのデータの為、更新できません。");
                base.WriteErrorLog(errMessage.ToString(), (int)ConstantManagement.DB_Status.ctDB_ERROR);
                return false;
            }
            else
            {
                // チェックOK
                return true;
            }
            // チェック処理 --------------------------------------<<<
        }
        // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        # endregion

        # region [読込処理]

        /// <summary>
		/// 入金読込処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <param name="depsitDataWorkByte">入金情報</param>
		/// <param name="depositAlwWorkListByte">入金引当情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金情報・入金引当情報を入金番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int Read(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] depsitDataWorkByte, out byte[] depositAlwWorkListByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

            DepsitDataWork depsitDataWork = new DepsitDataWork();    //ADD 2008/04/25 M.Kubota  
			//DepsitMainWork depsitMainWork = new DepsitMainWork();  //DEL 2008/04/25 M.Kubota
            DepositAlwWork[] depositAlwWorkList;
			ArrayList depositAlwWorkArrayList = new ArrayList();
			depositAlwWorkList =  (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
		
			depsitDataWorkByte = null;
			depositAlwWorkListByte = null;

            try
            {
                //-- DEL 2008/04/25 M.Kubota --->>>
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                ////SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // 入金読込み処理
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);         //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                //--- DEL 2008/04/25 M.Kubota --->>>
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    sqlTransaction.Commit();
                //else
                //    sqlTransaction.Rollback();
                //--- DEL 2008/04/25 M.Kubota ---<<<

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			// XMLへ変換し、文字列のバイナリ化
			//depsitDataWorkByte = XmlByteSerializer.Serialize(depsitMainWork);  //DEL 2008/04/25 M.Kubota
            depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);    //ADD 2008/04/25 M.Kubota
			depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

			return status;
        }

        /// <summary>
        /// 入金読込処理メイン
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="depsitDataWork">入金情報</param>
        /// <param name="depositAlwWorkList">入金引当情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報を入金番号を元にデータ取得を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// <br>Update Note: 2010/12/20 李占川 PM.NS障害改良対応(12月分)</br>
        /// <br>             入金値引または入金手数料にのみ金額が入力されている伝票を削除時にエラー発生しないよう修正する。</br>
        /// </remarks>
        //public int ReadDepsitMainWork(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int Read(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out DepsitDataWork depsitDataWork, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //depsitMainWork = new DepsitMainWork();  //DEL 2008/04/25 M.Kubota
            depsitDataWork = null;                    //ADD 2008/04/25 M.Kubota
            DepsitMainWork depsitMainWork = new DepsitMainWork();  //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlArray = null;                 //ADD 2008/04/25 M.Kubota

            ArrayList depositAlwWorkArrayList = new ArrayList();
            depositAlwWorkList = (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));

            // 入金マスタ読込処理
            //status = ReadDepsitMainWorkRec(EnterpriseCode, DepositSlipNo, out depsitMainWork, ref sqlConnection, ref sqlTransaction);                 //DEL 2008/04/25 M.Kubota
            status = ReadDepsitMain(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota
            
            //--- ADD 2008/04/25 M.Kubota --->>>
            // 入金明細データ読込処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.ReadDepsitDtl(depsitMainWork, out depsitDtlArray, ref sqlConnection, ref sqlTransaction);

                // --- ADD 2010/12/20 ---------->>>>>
                // 入金明細データは存在しなくてもエラーとしない
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // --- ADD 2010/12/20  ----------<<<<<

                // 入金マスタデータと入金明細データを結合する
                // ※ depsitMainWork の値を depsitDataWork に移す理由で、入金明細の読み込み結果に関わらず結合処理を行う。
                DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlArray);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 入金引当情報読込み処理
                //status = ReadDepositAlwWorkRec(EnterpriseCode, DepositSlipNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);          //DEL 2008/04/25 M.Kubota
                status = ReadDepositAlw(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota
                
                // 引当は存在しなくてもエラーとしない
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }

        /// <summary>
        /// 入金マスタ情報を取得します
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="depsitMainWork">入金情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金マスタ情報を入金番号を元にデータ取得を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        //private int ReadDepsitMainWorkRec(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        private int ReadDepsitMain(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;   //DEL 2008/04/25 M.Kubota
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;         //ADD 2008/04/25 M.Kubota
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

            SqlDataReader myReader = null;

            depsitMainWork = new DepsitMainWork();

            try
            {
                // ↓ 20070124 18322 c MA.NS用に変更
                #region SF 入金マスタ SELECT文（コメントアウト）
                ////Selectコマンドの生成
                //using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, CUSTOMERCODERF, DEPOSITCDRF, DEPOSITTOTALRF, OUTLINERF, ACCEPTANORDERSALESNORF, INPUTDEPOSITSECCDRF, DEPOSITDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEPOSITAGENTCODERF, DEPOSITKINDDIVCDRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DEPOSITRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, AUTODEPOSITCDRF "
                //		  +", ACPODRDEPOSITRF, ACPODRCHARGEDEPOSITRF, ACPODRDISDEPOSITRF, VARIOUSCOSTDEPOSITRF, VARCOSTCHARGEDEPOSITRF, VARCOSTDISDEPOSITRF, ACPODRDEPOSITALWCRF, ACPODRDEPOALWCBLNCERF, VARCOSTDEPOALWCRF, VARCOSTDEPOALWCBLNCERF " // 諸費用別入金項目の追加 20060220 Ins
                //		  +"FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))
                #endregion

                #region 入金マスタ SELECT文
                # region --- DEL 2008/04/25 M.Kubota ---
                // ↓ 2007.10.12 980081 c
                #region 旧レイアウト(コメントアウト)
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                 + ",UPDATEDATETIMERF"
                //                 + ",ENTERPRISECODERF"
                //                 + ",FILEHEADERGUIDRF"
                //                 + ",UPDEMPLOYEECODERF"
                //                 + ",UPDASSEMBLYID1RF"
                //                 + ",UPDASSEMBLYID2RF"
                //                 + ",LOGICALDELETECODERF"
                //                 + ",DEPOSITDEBITNOTECDRF"
                //                 + ",DEPOSITSLIPNORF"
                //                 + ",ACCEPTANORDERNORF"
                //                 + ",SERVICESLIPCDRF"
                //                 + ",INPUTDEPOSITSECCDRF"
                //                 + ",ADDUPSECCODERF"
                //                 + ",UPDATESECCDRF"
                //                 + ",DEPOSITDATERF"
                //                 + ",ADDUPADATERF"
                //                 + ",DEPOSITKINDCODERF"
                //                 + ",DEPOSITKINDNAMERF"
                //                 + ",DEPOSITKINDDIVCDRF"
                //                 + ",DEPOSITTOTALRF"
                //                 + ",DEPOSITRF"
                //                 + ",FEEDEPOSITRF"
                //                 + ",DISCOUNTDEPOSITRF"
                //                 + ",REBATEDEPOSITRF"
                //                 + ",AUTODEPOSITCDRF"
                //                 + ",DEPOSITCDRF"
                //                 + ",CREDITORLOANCDRF"
                //                 + ",CREDITCOMPANYCODERF"
                //                 + ",DRAFTDRAWINGDATERF"
                //                 + ",DRAFTPAYTIMELIMITRF"
                //                 + ",DEPOSITALLOWANCERF"
                //                 + ",DEPOSITALWCBLNCERF"
                //                 + ",DEBITNOTELINKDEPONORF"
                //                 + ",LASTRECONCILEADDUPDTRF"
                //                 + ",DEPOSITAGENTCODERF"
                //                 + ",DEPOSITAGENTNMRF"
                //                 + ",CUSTOMERCODERF"
                //                 + ",CUSTOMERNAMERF"
                //                 + ",CUSTOMERNAME2RF"
                //                 + ",OUTLINERF"
                //                 + " FROM DEPSITMAINRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                #endregion
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                       + ",UPDATEDATETIMERF"
                //                       + ",ENTERPRISECODERF"
                //                       + ",FILEHEADERGUIDRF"
                //                       + ",UPDEMPLOYEECODERF"
                //                       + ",UPDASSEMBLYID1RF"
                //                       + ",UPDASSEMBLYID2RF"
                //                       + ",LOGICALDELETECODERF"
                //                       + ",ACPTANODRSTATUSRF"
                //                       + ",DEPOSITDEBITNOTECDRF"
                //                       + ",DEPOSITSLIPNORF"
                //                       + ",SALESSLIPNUMRF"
                //                       + ",INPUTDEPOSITSECCDRF"
                //                       + ",ADDUPSECCODERF"
                //                       + ",UPDATESECCDRF"
                //                       + ",SUBSECTIONCODERF"
                //                       + ",MINSECTIONCODERF"
                //                       + ",DEPOSITDATERF"
                //                       + ",ADDUPADATERF"
                //                       + ",DEPOSITKINDCODERF"
                //                       + ",DEPOSITKINDNAMERF"
                //                       + ",DEPOSITKINDDIVCDRF"
                //                       + ",DEPOSITTOTALRF"
                //                       + ",DEPOSITRF"
                //                       + ",FEEDEPOSITRF"
                //                       + ",DISCOUNTDEPOSITRF"
                //                       + ",AUTODEPOSITCDRF"
                //                       + ",DEPOSITCDRF"
                //                       + ",DRAFTDRAWINGDATERF"
                //                       + ",DRAFTPAYTIMELIMITRF"
                //                       + ",DRAFTKINDRF"
                //                       + ",DRAFTKINDNAMERF"
                //                       + ",DRAFTDIVIDERF"
                //                       + ",DRAFTDIVIDENAMERF"
                //                       + ",DRAFTNORF"
                //                       + ",DEPOSITALLOWANCERF"
                //                       + ",DEPOSITALWCBLNCERF"
                //                       + ",DEBITNOTELINKDEPONORF"
                //                       + ",LASTRECONCILEADDUPDTRF"
                //                       + ",DEPOSITAGENTCODERF"
                //                       + ",DEPOSITAGENTNMRF"
                //                       + ",DEPOSITINPUTAGENTCDRF"
                //                       + ",DEPOSITINPUTAGENTNMRF"
                //                       + ",CUSTOMERCODERF"
                //                       + ",CUSTOMERNAMERF"
                //                       + ",CUSTOMERNAME2RF"
                //                       + ",CUSTOMERSNMRF"
                //                       + ",CLAIMCODERF"
                //                       + ",CLAIMNAMERF"
                //                       + ",CLAIMNAME2RF"
                //                       + ",CLAIMSNMRF"
                //                       + ",OUTLINERF"
                //                       + ",BANKCODERF"
                //                       + ",BANKNAMERF"
                //                       + ",EDISENDDATERF"
                //                       + ",EDITAKEINDATERF"
                //                 + " FROM DEPSITMAINRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                // ↑ 2007.10.12 980081 c
                #endregion
                //--- ADD 2008/04/25 M.Kubota --->>>
                string selectSql = string.Empty;
                selectSql += "SELECT" + Environment.NewLine;
                selectSql += "  DEP.CREATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,DEP.UPDATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,DEP.ENTERPRISECODERF" + Environment.NewLine;
                selectSql += " ,DEP.FILEHEADERGUIDRF" + Environment.NewLine;
                selectSql += " ,DEP.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectSql += " ,DEP.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectSql += " ,DEP.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectSql += " ,DEP.LOGICALDELETECODERF" + Environment.NewLine;
                selectSql += " ,DEP.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITSLIPNORF" + Environment.NewLine;
                selectSql += " ,DEP.SALESSLIPNUMRF" + Environment.NewLine;
                selectSql += " ,DEP.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectSql += " ,DEP.ADDUPSECCODERF" + Environment.NewLine;
                selectSql += " ,DEP.UPDATESECCDRF" + Environment.NewLine;
                selectSql += " ,DEP.SUBSECTIONCODERF" + Environment.NewLine;
                selectSql += " ,DEP.INPUTDAYRF" + Environment.NewLine;  // ADD 2009/03/25
                selectSql += " ,DEP.DEPOSITDATERF" + Environment.NewLine;
                selectSql += " ,DEP.ADDUPADATERF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITTOTALRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITRF" + Environment.NewLine;
                selectSql += " ,DEP.FEEDEPOSITRF" + Environment.NewLine;
                selectSql += " ,DEP.DISCOUNTDEPOSITRF" + Environment.NewLine;
                selectSql += " ,DEP.AUTODEPOSITCDRF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTKINDRF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTKINDNAMERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTDIVIDERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTNORF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITALLOWANCERF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITALWCBLNCERF" + Environment.NewLine;
                selectSql += " ,DEP.DEBITNOTELINKDEPONORF" + Environment.NewLine;
                selectSql += " ,DEP.LASTRECONCILEADDUPDTRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITAGENTCODERF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITAGENTNMRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERCODERF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERNAMERF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERNAME2RF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERSNMRF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMCODERF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMNAMERF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMNAME2RF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMSNMRF" + Environment.NewLine;
                selectSql += " ,DEP.OUTLINERF" + Environment.NewLine;
                selectSql += " ,DEP.BANKCODERF" + Environment.NewLine;
                selectSql += " ,DEP.BANKNAMERF" + Environment.NewLine;
                selectSql += "FROM" + Environment.NewLine;
                selectSql += "  DEPSITMAINRF AS DEP" + Environment.NewLine;
                selectSql += "WHERE" + Environment.NewLine;
                selectSql += "  DEP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectSql += "  AND DEP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                selectSql += "  AND DEP.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                //--- ADD 2008/04/25 M.Kubota ---<<<
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // ↑ 20070124 18322 c
                {
                    # region --- DEL 2008/04/25 M.Kubota ---
                    //Prameterオブジェクトの作成
                    //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    //findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);

                    #if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
                    #endif
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        # region --- DEL 2008/04/25 M.Kubota ---
# if false
                        // ↓ 20070124 18322 c MA.NS用に変更
                        #region クラスへ代入
                        //depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        //depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        //depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        //depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
                        //depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));
                        //depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITTOTALRF"));
                        //depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OUTLINERF"));
                        //depsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESNORF"));
                        //depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        //depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DEPOSITDATERF"));
                        //depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDUPSECCODERF"));
                        //depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
                        //depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
                        //depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        //depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        //depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        //depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        //depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        //depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("FEEDEPOSITRF"));
                        //depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        //depsitMainWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //depsitMainWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        //depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITRF"));
                        //depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        //depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        //depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        //depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        //depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        //// 20060217 Ins Start >>>>>>>>>
                        //depsitMainWork.AcpOdrDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITRF"));
                        //depsitMainWork.AcpOdrChargeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRCHARGEDEPOSITRF"));
                        //depsitMainWork.AcpOdrDisDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDISDEPOSITRF"));
                        //depsitMainWork.VariousCostDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARIOUSCOSTDEPOSITRF"));
                        //depsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTCHARGEDEPOSITRF"));
                        //depsitMainWork.VarCostDisDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDISDEPOSITRF"));
                        //depsitMainWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
                        //depsitMainWork.AcpOdrDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOALWCBLNCERF"));
                        //depsitMainWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
                        //depsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCBLNCERF"));
                        //// 20060217 Ins End <<<<<<<<<<<
                        #endregion

                        #region SQL検索データを入金マスタワークへ設定
                        // 作成日時
                        depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        // 更新日時
                        depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        // 企業コード
                        depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        // GUID
                        depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        // 更新従業員コード
                        depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        // 更新アセンブリID1
                        depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        // 更新アセンブリID2
                        depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        // 論理削除区分
                        depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // 入金赤黒区分
                        depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        // 入金伝票番号
                        depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        // ↓ 2007.10.12 980081 d
                        //// 受注番号
                        //depsitMainWork.AcceptAnOrderNo       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// サービス伝票区分
                        //depsitMainWork.ServiceSlipCd         = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SERVICESLIPCDRF"));
                        // ↑ 2007.10.12 980081 d
                        // 入金入力拠点コード
                        depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        // 計上拠点コード
                        depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        // 更新拠点コード
                        depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        // 入金日付
                        depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                        // 計上日付
                        depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        // 入金金種コード
                        depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        // 入金金種名称
                        depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        // 入金金種区分
                        depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        // 入金計
                        depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                        // 入金金額
                        depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                        // 手数料入金額
                        depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                        // 値引入金額
                        depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        // ↓ 2007.10.12 980081 d
                        //// リベート入金額
                        //depsitMainWork.RebateDeposit         = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("REBATEDEPOSITRF"));
                        // ↑ 2007.10.12 980081 d
                        // 自動入金区分
                        depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        // 預り金区分
                        depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        // ↓ 2007.10.12 980081 d
                        //// クレジット／ローン区分
                        //depsitMainWork.CreditOrLoanCd        = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// クレジット会社コード
                        //depsitMainWork.CreditCompanyCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        // ↑ 2007.10.12 980081 d
                        // 手形振出日
                        depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        // 手形支払期日
                        depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        // 入金引当額
                        depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        // 入金引当残高
                        depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        // 赤黒入金連結番号
                        depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        // 最終消し込み計上日
                        depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        // 入金担当者コード
                        depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        // 入金担当者名称
                        depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        // 得意先コード
                        depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // 得意先名称
                        depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        // 得意先名称2
                        depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        // 伝票摘要
                        depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        // ↓ 2007.10.12 980081 a
                        depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        depsitMainWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                        depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                        depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        depsitMainWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        // ↓ 2007.12.10 980081 c
                        //depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        // ↑ 2007.12.10 980081 c
                        // ↑ 2007.10.12 980081 a
                        #endregion
                        // ↑ 20070124 18322 c
# endif
                        # endregion

                        this.ReadDataToDepsitMain(ref depsitMainWork, myReader);  //ADD 2008/04/25 M.Kubota
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    //--- ADD 2008/04/25 M.Kubota --->>>
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);                   //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// 入金引当マスタ情報を取得します
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="depositAlwWorkList">入金引当情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金引当マスタ情報を入金番号を元にデータ取得を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        //private int ReadDepositAlwWorkRec(string EnterpriseCode, int DepositSlipNo, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                  //DEL 2008/04/25 M.Kubota
        private int ReadDepositAlw(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //DEL 2008/04/25 M.Kubota
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;        //ADD 2008/04/25 M.Kubota
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame()); //ADD 2008/04/25 M.Kubota
            depositAlwWorkList = new DepositAlwWork[0];                       //ADD 2008/04/25 M.Kubota

            SqlDataReader myReader = null;

            ArrayList depositAlwWorkArrayList = new ArrayList();

            try
            {
                # region --- DEL 2008/04/25 M.Kubota ---
# if false
                // ↓ 20070124 18322 c MA.NS用に変更
                #region SF 入金引当マスタ SELECT文（コメントアウト）
                ////Selectコマンドの生成
                //using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
                //		  +",ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "			// 20060220 Ins
                //		  +"FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))
                #endregion

                #region 入金引当マスタ SELECT文
                // ↓ 2007.10.12 980081 c
                #region 旧レイアウト(コメントアウト)
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                       + ",UPDATEDATETIMERF"
                //                       + ",ENTERPRISECODERF"
                //                       + ",FILEHEADERGUIDRF"
                //                       + ",UPDEMPLOYEECODERF"
                //                       + ",UPDASSEMBLYID1RF"
                //                       + ",UPDASSEMBLYID2RF"
                //                       + ",LOGICALDELETECODERF"
                //                       + ",INPUTDEPOSITSECCDRF"
                //                       + ",ADDUPSECCODERF"
                //                       + ",RECONCILEDATERF"
                //                       + ",RECONCILEADDUPDATERF"
                //                       + ",DEPOSITSLIPNORF"
                //                       + ",DEPOSITKINDCODERF"
                //                       + ",DEPOSITKINDNAMERF"
                //                       + ",DEPOSITALLOWANCERF"
                //                       + ",DEPOSITAGENTCODERF"
                //                       + ",DEPOSITAGENTNMRF"
                //                       + ",CUSTOMERCODERF"
                //                       + ",CUSTOMERNAMERF"
                //                       + ",CUSTOMERNAME2RF"
                //                       + ",ACCEPTANORDERNORF"
                //                       + ",SERVICESLIPCDRF"
                //                       + ",DEBITNOTEOFFSETCDRF"
                //                       + ",DEPOSITCDRF"
                //                       + ",CREDITORLOANCDRF"
                //                 +  " FROM DEPOSITALWRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 +   " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                #endregion
                string selectSql = "SELECT CREATEDATETIMERF"
                                       + ",UPDATEDATETIMERF"
                                       + ",ENTERPRISECODERF"
                                       + ",FILEHEADERGUIDRF"
                                       + ",UPDEMPLOYEECODERF"
                                       + ",UPDASSEMBLYID1RF"
                                       + ",UPDASSEMBLYID2RF"
                                       + ",LOGICALDELETECODERF"
                                       + ",INPUTDEPOSITSECCDRF"
                                       + ",ADDUPSECCODERF"
                                       + ",RECONCILEDATERF"
                                       + ",RECONCILEADDUPDATERF"
                                       + ",DEPOSITSLIPNORF"
                                       + ",DEPOSITKINDCODERF"
                                       + ",DEPOSITKINDNAMERF"
                                       + ",DEPOSITALLOWANCERF"
                                       + ",DEPOSITAGENTCODERF"
                                       + ",DEPOSITAGENTNMRF"
                                       + ",CUSTOMERCODERF"
                                       + ",CUSTOMERNAMERF"
                                       + ",CUSTOMERNAME2RF"
                                       + ",DEBITNOTEOFFSETCDRF"
                                       + ",DEPOSITCDRF"
                                       + ",ACPTANODRSTATUSRF"
                                       + ",SALESSLIPNUMRF"
                                 + " FROM DEPOSITALWRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                 ;
                // ↑ 2007.10.12 980081 c
                #endregion
# endif
                # endregion

                # region [SELECT文]
                //--- ADD 2008/04/25 M.Kubota --->>>
                string selectSql = string.Empty;
                selectSql += "SELECT" + Environment.NewLine;
                selectSql += "  ALW.CREATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,ALW.UPDATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,ALW.ENTERPRISECODERF" + Environment.NewLine;
                selectSql += " ,ALW.FILEHEADERGUIDRF" + Environment.NewLine;
                selectSql += " ,ALW.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectSql += " ,ALW.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectSql += " ,ALW.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectSql += " ,ALW.LOGICALDELETECODERF" + Environment.NewLine;
                selectSql += " ,ALW.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectSql += " ,ALW.ADDUPSECCODERF" + Environment.NewLine;
                selectSql += " ,ALW.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectSql += " ,ALW.SALESSLIPNUMRF" + Environment.NewLine;
                selectSql += " ,ALW.RECONCILEDATERF" + Environment.NewLine;
                selectSql += " ,ALW.RECONCILEADDUPDATERF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITSLIPNORF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITALLOWANCERF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITAGENTCODERF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITAGENTNMRF" + Environment.NewLine;
                selectSql += " ,ALW.CUSTOMERCODERF" + Environment.NewLine;
                selectSql += " ,ALW.CUSTOMERNAMERF" + Environment.NewLine;
                selectSql += " ,ALW.CUSTOMERNAME2RF" + Environment.NewLine;
                selectSql += " ,ALW.DEBITNOTEOFFSETCDRF" + Environment.NewLine;
                selectSql += "FROM" + Environment.NewLine;
                selectSql += "  DEPOSITALWRF AS ALW" + Environment.NewLine;
                selectSql += "WHERE" + Environment.NewLine;
                selectSql += "  ALW.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectSql += "  AND ALW.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;

                // 受注ステータスが設定されている場合にのみ絞込み条件に追加する。
                // ※入金メインにある受注ステータスと入金引当にある受注ステータスでは意味が異なり、
                // 　前者は自動入金時に対となる売伝の受注ステータスのみが設定され、後者は引当対象
                // 　の売伝の受注ステータスが設定されている。
                if (AcptAnOdrStatus != 0)
                {
                    selectSql += "  AND ALW.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                }

                //--- ADD 2008/04/25 M.Kubota ---<<<
                # endregion

                using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // ↑ 20070124 18322 c
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    if (AcptAnOdrStatus != 0)
                    {
                        SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    }
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        # region --- DEL 2008/04/25 M.Kubota ---
# if false
                        DepositAlwWork depositAlwWork = new DepositAlwWork();

                        // ↓ 20070124 18322 c NA.NS用に変更
                        #region SF SQLデータを入金引当マスタワークへ設定（全てコメントアウト）
                        //depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
                        //depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDUPSECCODERF"));
                        //depositAlwWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        //depositAlwWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        //depositAlwWork.DepositInputDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DEPOSITINPUTDATERF"));
                        //depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        //depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RECONCILEDATERF"));
                        //depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        //depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        //depositAlwWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));
                        //depositAlwWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //depositAlwWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
                        //depositAlwWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
                        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        #endregion

                        #region SQLデータを入金引当マスタワークへ設定
                        // 作成日時
                        depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        // 更新日時
                        depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        // 企業コード
                        depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        // GUID
                        depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        // 更新従業員コード
                        depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        // 更新アセンブリID1
                        depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        // 更新アセンブリID2
                        depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        // 論理削除区分
                        depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // 入金入力拠点コード
                        depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        // 計上拠点コード
                        depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        // 消込み日
                        depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEDATERF"));
                        // 消込み計上日
                        depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        // 入金伝票番号
                        depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        // 入金金種コード
                        depositAlwWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        // 入金金種名称
                        depositAlwWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        // 入金引当額
                        depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        // 入金担当者コード
                        depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        // 入金担当者名称
                        depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        // 得意先コード
                        depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // 得意先名称
                        depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        // 得意先名称2
                        depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        // ↓ 2007.10.12 980081 d
                        //// 受注番号
                        //depositAlwWork.AcceptAnOrderNo     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// サービス伝票区分
                        //depositAlwWork.ServiceSlipCd       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SERVICESLIPCDRF"));
                        // ↑ 2007.10.12 980081 
                        // 赤伝相殺区分
                        depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        // 預り金区分
                        depositAlwWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        // ↓ 2007.10.12 980081 d
                        //// クレジット／ローン区分
                        //depositAlwWork.CreditOrLoanCd      = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        // ↑ 2007.10.12 980081 d
                        // ↓ 2007.10.12 980081 a
                        depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        // ↑ 2007.10.12 980081 a
                        #endregion
                        // ↑ 20070124 18322 c
        
                        depositAlwWorkArrayList.Add(depositAlwWork);                        

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
# endif
                        # endregion

                        depositAlwWorkArrayList.Add(this.ReadDataToDepositAlw(myReader));  //ADD 2008/04/25 M.Kubota
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (ListUtils.IsNotEmpty(depositAlwWorkArrayList))
                {
                    depositAlwWorkList = (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //--- DEL 2008/04/25 M.Kubota --->>>
            //if (myReader != null && !myReader.IsClosed) myReader.Close();
            //depositAlwWorkList = (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
            //--- DEL 2008/04/25 M.Kubota ---<<<

            return status;
        }

        //--- ADD 2008/04/25 M.Kubota --->>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainWork"></param>
        /// <param name="depsitDtlArray"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int ReadDepsitDtl(DepsitMainWork depsitMainWork, out DepsitDtlWork[] depsitDtlArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            depsitDtlArray = new DepsitDtlWork[0];

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            ArrayList depsitDtlList = new ArrayList();

            try
            {
                # region [SELECT文]
                //--- ADD 2008/04/25 M.Kubota --->>>
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DTL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,DTL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,DTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,DTL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,DTL.DEPOSITSLIPNORF" + Environment.NewLine;
                sqlText += " ,DTL.DEPOSITROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,DTL.DEPOSITRF" + Environment.NewLine;
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  DEPSITDTLRF AS DTL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DTL.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                //--- ADD 2008/04/25 M.Kubota ---<<<
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);

                if (depsitMainWork.DepositDebitNoteCd != 1)
                {
                    // 0:黒, 2:元黒の場合
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                }
                else
                {
                    // 1:赤 の場合
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo); 
                }
                
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    DepsitDtlWork redDtlWork = this.ReadDataToDepsitDtl(sqlDataReader);

                    if (depsitMainWork.DepositDebitNoteCd == 1)
                    {
                        // 1:赤 の場合
                        redDtlWork.DepositSlipNo = depsitMainWork.DepositSlipNo;
                        redDtlWork.Deposit = redDtlWork.Deposit * -1;
                    }
                    
                    depsitDtlList.Add(redDtlWork);
                }

                if (depsitDtlList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    depsitDtlArray = (DepsitDtlWork[])depsitDtlList.ToArray(typeof(DepsitDtlWork));
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }

                    sqlDataReader.Dispose();
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
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private DepsitMainWork ReadDataToDepsitMain(SqlDataReader sqlDataReader)
        {
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            this.ReadDataToDepsitMain(ref depsitMainWork, sqlDataReader);
            return depsitMainWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainWork"></param>
        /// <param name="sqlDataReader"></param>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        private void ReadDataToDepsitMain(ref DepsitMainWork depsitMainWork, SqlDataReader sqlDataReader)
        {
            # region [入金マスタ 読込結果格納]
            depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));                  // 作成日時
            depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));                  // 更新日時
            depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));                             // 企業コード
            depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));                               // GUID
            depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));                           // 更新従業員コード
            depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));                             // 更新アセンブリID1
            depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));                             // 更新アセンブリID2
            depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));                        // 論理削除区分
            depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));                            // 受注ステータス
            depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));                      // 入金赤黒区分
            depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));                                // 入金伝票番号
            depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SALESSLIPNUMRF"));                                 // 売上伝票番号
            depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDEPOSITSECCDRF"));                       // 入金入力拠点コード
            depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPSECCODERF"));                                 // 計上拠点コード
            depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDATESECCDRF"));                                   // 更新拠点コード
            depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUBSECTIONCODERF"));                              // 部門コード
            depsitMainWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDAYRF"));                           // 入力日付  //ADD 2009/03/25
            depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITDATERF"));                     // 入金日付
            depsitMainWork.PreDepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITDATERF"));                  // 入金日付 // ADD 2011/12/21
            depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPADATERF"));                       // 計上日付
            depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITTOTALRF"));                                  // 入金計
            depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITRF"));                                            // 入金金額
            depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("FEEDEPOSITRF"));                                      // 手数料入金額
            depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DISCOUNTDEPOSITRF"));                            // 値引入金額
            depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("AUTODEPOSITCDRF"));                                // 自動入金区分
            depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDRAWINGDATERF"));           // 手形振出日
            depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDRF"));                                        // 手形種類
            depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDNAMERF"));                               // 手形種類名称
            depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDERF"));                                    // 手形区分
            depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDENAMERF"));                           // 手形区分名称
            depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTNORF"));                                           // 手形番号
            depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITALLOWANCERF"));                          // 入金引当額
            depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITALWCBLNCERF"));                          // 入金引当残高
            depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTELINKDEPONORF"));                    // 赤黒入金連結番号
            depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));   // 最終消し込み計上日
            depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTCODERF"));                         // 入金担当者コード
            depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTNMRF"));                             // 入金担当者名称
            depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));                   // 入金入力者コード
            depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));                   // 入金入力者名称
            depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERCODERF"));                                  // 得意先コード
            depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAMERF"));                                 // 得意先名称
            depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAME2RF"));                               // 得意先名称2
            depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERSNMRF"));                                   // 得意先略称
            depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMCODERF"));                                        // 請求先コード
            depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMNAMERF"));                                       // 請求先名称
            depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMNAME2RF"));                                     // 請求先名称2
            depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMSNMRF"));                                         // 請求先略称
            depsitMainWork.Outline = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("OUTLINERF"));                                           // 伝票摘要
            depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("BANKCODERF"));                                          // 銀行コード
            depsitMainWork.BankName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("BANKNAMERF"));                                         // 銀行名称
            # endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private DepsitDtlWork ReadDataToDepsitDtl(SqlDataReader sqlDataReader)
        {
            DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
            this.ReadDataToDepsitDtl(ref depsitDtlWork, sqlDataReader);
            return depsitDtlWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitDtlWork"></param>
        /// <param name="sqlDataReader"></param>
        private void ReadDataToDepsitDtl(ref DepsitDtlWork depsitDtlWork, SqlDataReader sqlDataReader)
        {
            # region [入金明細データ 読込結果格納]
            depsitDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            depsitDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            depsitDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
            depsitDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
            depsitDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
            depsitDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
            depsitDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
            depsitDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
            depsitDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));            // 受注ステータス
            depsitDtlWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));                // 入金伝票番号
            depsitDtlWork.DepositRowNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITROWNORF"));                  // 入金行番号
            depsitDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDCODERF"));                // 金種コード
            depsitDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDNAMERF"));               // 金種名称
            depsitDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDDIVRF"));                  // 金種区分
            depsitDtlWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITRF"));                            // 入金金額
            depsitDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("VALIDITYTERMRF"));   // 有効期限
            # endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private DepositAlwWork ReadDataToDepositAlw(SqlDataReader sqlDataReader)
        {
            DepositAlwWork depositAlwWork = new DepositAlwWork();
            this.ReadDataToDepositAlw(ref depositAlwWork, sqlDataReader);
            return depositAlwWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depositAlwWork"></param>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private void ReadDataToDepositAlw(ref DepositAlwWork depositAlwWork, SqlDataReader sqlDataReader)
        {
            # region [入金引当マスタ 読込結果格納]
            depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));             // 作成日時
            depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));             // 更新日時
            depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));                        // 企業コード
            depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));                          // GUID
            depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));                      // 更新従業員コード
            depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));                        // 更新アセンブリID1
            depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));                        // 更新アセンブリID2
            depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));                   // 論理削除区分
            depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDEPOSITSECCDRF"));                  // 入金入力拠点コード
            depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPSECCODERF"));                            // 計上拠点コード
            depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));                       // 受注ステータス
            depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SALESSLIPNUMRF"));                            // 売上伝票番号
            depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("RECONCILEDATERF"));            // 消込み日
            depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("RECONCILEADDUPDATERF"));  // 消込み計上日
            depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));                           // 入金伝票番号
            depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITALLOWANCERF"));                     // 入金引当額
            depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTCODERF"));                    // 入金担当者コード
            depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTNMRF"));                        // 入金担当者名称
            depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERCODERF"));                             // 得意先コード
            depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAMERF"));                            // 得意先名称
            depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAME2RF"));                          // 得意先名称2
            depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));                   // 赤伝相殺区分
            # endregion
        }
        //--- ADD 2008/04/25 M.Kubota ---<<<

        # endregion

        # region [論理削除処理]

        // ↓ 2008.01.11 980081 a
        /// <summary>
        /// 入金論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報論理削除を行います</br>
        /// <br>           : 自動入金データの削除に使用します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo)  //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus)  //ADD 2008/04/25 M.Kubota
        {
            byte[] depsitMainWorkByte;
            byte[] depositAlwWorkListByte;

            //int status = LogicalDelete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
            int status = LogicalDelete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWorkByte, out depositAlwWorkListByte);    //ADD 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// 入金論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報論理削除を行います</br>
        /// <br>           : 自動入金データの削除に使用します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                     //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            byte[] depsitMainWorkByte;
            byte[] depositAlwWorkListByte;

            //int status = LogicalDelete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte, ref sqlConnection, ref sqlTransaction);  //DEL 20008/04/25 M.Kubota
            int status = LogicalDelete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWorkByte, out depositAlwWorkListByte, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// 入金論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="RetDepsitMainWorkByte">更新入金データ(赤削除時の元黒レコード)</param>
        /// <param name="RetDepositAlwWorkListByte">更新入金引当データ(赤削除時の元黒引当レコード)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報論理削除を行います</br>
        /// <br>           : 自動入金データの削除に使用します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte)  //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            RetDepsitMainWorkByte = null;
            RetDepositAlwWorkListByte = null;

            ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品

            try
            {
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL接続
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 入金読込み処理
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // 入金相殺区分＝２(相殺済み黒)の場合はエラー
                if (depsitMainWork.DepositDebitNoteCd == 2)
                {
                    // UI仕様上、同時更新時に発生する可能性があるため、排他エラーで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }

                //--- DEL 2008/04/25 M.Kubota --->>>
                // 更新時ロック処理
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// 得意先別ロックをかける
                //--- DEL 2008/04/25 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // 論理削除を立てる
                if (depsitMainWork != null)
                    depsitMainWork.LogicalDeleteCode = 1;
                if (depositAlwWorkList != null)
                {
                    foreach (DepositAlwWork rec in depositAlwWorkList)
                    {
                        rec.LogicalDeleteCode = 1;
                    }
                }

                // 入金マスタ更新処理
                status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                // 赤入金の削除の場合、元黒の入金・引当情報の更新を行う(赤相殺の区分関連をクリアする)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.DepositDebitNoteCd == 1)
                {
                    // 元黒入金読込み処理(赤相殺されていた入金伝票)
                    //status = ReadDepsitMainWork(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                    // 更新従業員コード ???
                    //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                    // 入金赤黒区分をクリア
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // 元黒入金の赤黒連結番号をクリア
                    depsitMainWork.DebitNoteLinkDepoNo = 0;

                    if (depositAlwWorkList != null)
                    {
                        for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                        {
                            // 更新従業員コード ???
                            //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                            // 赤伝相殺区分をクリア
                            depositAlwWorkList[ix].DebitNoteOffSetCd = 0;
                        }
                    }

                    // 元黒入金マスタ更新処理
                    status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XMLへ変換し、文字列のバイナリ化
                        RetDepsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);
                        RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);
                    }
                }


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
# endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            RetDepsitMainWorkByte = null;
            RetDepositAlwWorkListByte = null;

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);

            try
            {
                status = this.LogicalDelete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out RetDepsitMainWorkByte, out RetDepositAlwWorkListByte, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
                else
                {
                    sqlTransaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            return status;
        }

        /// <summary>
        /// 入金論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="RetDepsitMainWorkByte">更新入金データ(赤削除時の元黒レコード)</param>
        /// <param name="RetDepositAlwWorkListByte">更新入金引当データ(赤削除時の元黒引当レコード)</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報論理削除を行います</br>
        /// <br>           : 自動入金データの削除に使用します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            DepsitDataWork depsitDataWork = null;      //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota

            RetDepsitMainWorkByte = null;
            RetDepositAlwWorkListByte = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/25 M.Kubota

            try
            {
                // 入金読込み処理
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2009/05/01

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //>>>2010/09/28
                // 入金データを入金マスタと入金明細に分割する
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);
                //<<<2010/09/28

                // 入金相殺区分＝２(相殺済み黒)の場合はエラー
                if (depsitMainWork.DepositDebitNoteCd == 2)
                {
                    // UI仕様上、同時更新時に発生する可能性があるため、排他エラーで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }

                //--- DEL 2008/04/25 M.Kubota --->>>
                // 更新時ロック処理
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// 得意先別ロックをかける
                //--- DEL 2008/04/25 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 論理削除を立てる
                if (depsitMainWork != null)
                    depsitMainWork.LogicalDeleteCode = 1;
                if (depositAlwWorkList != null)
                {
                    foreach (DepositAlwWork rec in depositAlwWorkList)
                    {
                        rec.LogicalDeleteCode = 1;
                    }
                }

                // 入金マスタ更新処理
                status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                // 赤入金の削除の場合、元黒の入金・引当情報の更新を行う(赤相殺の区分関連をクリアする)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.DepositDebitNoteCd == 1)
                {
                    // 元黒入金読込み処理(赤相殺されていた入金伝票)
                    //status = ReadDepsitMainWork(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                    // 更新従業員コード ???
                    //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                    // 入金赤黒区分をクリア
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // 元黒入金の赤黒連結番号をクリア
                    depsitMainWork.DebitNoteLinkDepoNo = 0;

                    if (depositAlwWorkList != null)
                    {
                        for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                        {
                            // 更新従業員コード ???
                            //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                            // 赤伝相殺区分をクリア
                            depositAlwWorkList[ix].DebitNoteOffSetCd = 0;
                        }
                    }

                    // 元黒入金マスタ更新処理
                    status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XMLへ変換し、文字列のバイナリ化
                        RetDepsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);
                        RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);
                    }
                }

                // 論理削除における得意先マスタ(変動情報)の売掛残高更新処理については…
                // １.論理削除と物理削除をリモート内で判断出来ない
                // ２.論理削除は入金入力からは使用されていない
                // などの理由により、現時点では非対応としておく。

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
            }

            return status;
        }

        /// <summary>
        /// 入金マスタ情報を論理削除します
        /// </summary>
        /// <param name="depsitMainWork">入金マスタ情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 入金情報を更新します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// 
        private int LogicalDeleteDepsitMainWork(ref DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            string updateText;

            // 更新日付を取得
            DateTime Upd_UpdateDateTime = depsitMainWork.UpdateDateTime;

            //Selectコマンドの生成
            try
            {
                // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                // 入金データを更新する前に、送信済みのチェックを行う
                if (!CheckDepsitMainSending(depsitMainWork))
                {
                    // チェックNG
                    return STATUS_CHK_SEND_ERR;
                }
                // ADD 2011/07/28 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                #region 入金マスタ UPDATE文
                // 更新日を更新検索キーに付加して更新（日付排他処理）
                updateText = "UPDATE DEPSITMAINRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE"
                           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                             + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                             + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                             ;
                #endregion

                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)depsitMainWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    //Parameterオブジェクトへ値設定
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);


                    #region 入金マスタ Parameterオブジェクトの作成(更新用)
                    // 作成日時
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // 更新日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // 企業コード
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // 更新従業員コード
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // 更新アセンブリID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // 論理削除区分
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    #endregion

                    #region 入金マスタ Parameterオブジェクトへ値設定(更新用)
                    // 作成日時
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                    // 更新日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                    // 企業コード
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                    // 更新従業員コード
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                    // 更新アセンブリID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                    // 更新アセンブリID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                    // 論理削除区分
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                    #endregion

                    int count = sqlCommand.ExecuteNonQuery();

                    // 更新件数が無い場合はすでに削除されている意味で排他を戻す
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }
        // ↑ 2008.01.11 980081 a

        # endregion

        # region [削除処理]
        /// <summary>
        /// 入金削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        //public int Delete(string EnterpriseCode, int DepositSlipNo)                     //DEL 2008/04/25 M.Kubota
        public int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus)  //ADD 2008/04/25 M.Kubota
        {
            byte[] depsitMainWorkByte;
            byte[] depositAlwWorkListByte;

            //int status = Delete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);                 //DEL 2008/04/25 M.Kubota
            int status = Delete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWorkByte, out depositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// 入金削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="RetDepsitDataWorkByte">更新入金データ(赤削除時の元黒レコード)</param>
        /// <param name="RetDepositAlwWorkListByte">更新入金引当データ(赤削除時の元黒引当レコード)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte)  //ADD 2008/04/25 M.Kubota
        {
            return DeleteProc(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out RetDepsitDataWorkByte, out RetDepositAlwWorkListByte);
        }

        /// <summary>
		/// 入金削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <param name="RetDepsitDataWorkByte">更新入金データ(赤削除時の元黒レコード)</param>
		/// <param name="RetDepositAlwWorkListByte">更新入金引当データ(赤削除時の元黒引当レコード)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//public int Delete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte)                     //DEL 2008/04/25 M.Kubota
        private int DeleteProc(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte)  //ADD 2008/04/25 M.Kubota
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            DepsitDataWork depsitDataWork = null;      //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota

			//RetDepsitMainWorkByte = null;  //DEL 2008/04/25 M.Kubota
            RetDepsitDataWorkByte = null;    //ADD 2008/04/25 M.Kubota
			RetDepositAlwWorkListByte = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

			//ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/25 M.Kubota

            try
            {
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //--- DEL 2008/04/25 M.Kubota --->>>
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                //SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // 入金読込み処理
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);         //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                //システムロック(拠点) //2009/1/27 Add sakurai
                int st = 0;
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(depsitDataWork.EnterpriseCode, ShareCheckType.Section, depsitDataWork.AddUpSecCode, "");
                st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                if (st != 0) return st;

                // 入金データを入金マスタと入金明細に分割する
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);  //ADD 2008/04/25 M.Kubota

                // 入金相殺区分＝２(相殺済み黒)の場合はエラー
                if (depsitMainWork.DepositDebitNoteCd == 2)
                {
                    //					base.WriteErrorLog(null,"プログラムエラー。赤入金された伝票の削除は行えません");
                    // UI仕様上、同時更新時に発生する可能性があるため、排他エラーで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }

                //--- DEL 2008/04/25 M.Kubota --->>>
                // 更新時ロック処理
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// 得意先別ロックをかける

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    sqlTransaction.Rollback();
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();

                //    return status;
                //}
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // 論理削除を立てる（更新処理内部で物理削除処理・引当更新処理が実行される）
                if (depsitMainWork != null)
                    depsitMainWork.LogicalDeleteCode = 1;
                if (depositAlwWorkList != null)
                {
                    foreach (DepositAlwWork rec in depositAlwWorkList)
                    {
                        rec.LogicalDeleteCode = 1;
                    }
                }

                // 入金マスタ更新処理
                //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection,ref sqlTransaction);               //DEL 2008/04/25 M.Kubota
                status = this.Write(ref depsitMainWork, ref depsitDtlWorkList, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                // 赤入金の削除の場合、元黒の入金・引当情報の更新を行う(赤相殺の区分関連をクリアする)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.DepositDebitNoteCd == 1)
                {
                    // 元黒入金読込み処理(赤相殺されていた入金伝票)
                    //status = ReadDepsitMainWork(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    status = this.Read(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, depsitMainWork.AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                    // 入金データを入金マスタと入金明細に分割する
                    DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);  //ADD 2008/04/25 M.Kubota

                    // 更新従業員コード ???
                    //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                    // 入金赤黒区分をクリア
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // 元黒入金の赤黒連結番号をクリア
                    depsitMainWork.DebitNoteLinkDepoNo = 0;

                    if (depositAlwWorkList != null)
                    {
                        for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                        {
                            // 更新従業員コード ???
                            //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                            // 赤伝相殺区分をクリア
                            depositAlwWorkList[ix].DebitNoteOffSetCd = 0;
                        }
                    }

                    // 元黒入金マスタ更新処理
                    //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection,ref sqlTransaction);               //DEL 2008/04/25 M.Kubota
                    status = this.Write(ref depsitMainWork, ref depsitDtlWorkList, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XMLへ変換し、文字列のバイナリ化
                        //RetDepsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);  //DEL 2008/04/25 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkList);
                        RetDepsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //システムロック解除 //2009/1/27 Add sakurai
                    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);
                base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //DEL 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<
			finally
			{
				// 更新時ロック解除
				//controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<
			}

            //--- DEL 2008/04/25 M.Kubota --->>>
            //if(sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            //--- DEL 2008/04/25 M.Kubota ---<<<

			return status;
        }

        /// <summary>
        /// 入金引当マスタ情報を削除します
        /// </summary>
        /// <param name="depositAlwWork">入金引当情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金引当マスタ情報の削除を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int DeleteDepositAlwWorkRec(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteDepositAlwWorkRecProc(ref depositAlwWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 入金引当マスタ情報を削除します
        /// </summary>
        /// <param name="depositAlwWork">入金引当情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金引当マスタ情報の削除を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        private int DeleteDepositAlwWorkRecProc(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            //Selectコマンドの生成
            try
            {
                // ↓ 20070124 18322 c MA.NS用に変更
                #region SF 入金引当マスタ DELETE文（全てコメントアウト）
                //using(SqlCommand sqlCommand = new SqlCommand("DELETE FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO  AND ADDUPSECCODERF=@ADDUPSECCODE", sqlConnection,sqlTransaction))
                //{
                //
                //	//Prameterオブジェクトの作成
                //	SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //	SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                //	SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                //	SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                //	SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                //
                //	//Parameterオブジェクトへ値設定
                //	findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                //	findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                //	findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                //	findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                //	findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                //
                //	sqlCommand.ExecuteNonQuery();
                //}
                #endregion

                string deleteSql = "DELETE FROM DEPOSITALWRF"
                                      + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                    // ↓ 2007.10.12 980081 c
                    //+ " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                                        + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                                        + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                    // ↑ 2007.10.12 980081 c
                                        + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                                        + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                        + " AND ADDUPSECCODERF=@ADDUPSECCODE"
                                 ;
                using (SqlCommand sqlCommand = new SqlCommand(deleteSql, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2007.10.12 980081 c
                    //SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2007.10.12 980081 c
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // ↓ 2007.10.12 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // ↑ 2007.10.12 980081 c
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);

                    sqlCommand.ExecuteNonQuery();
                }
                // ↑ 20070124 18322 c

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        # endregion

        # region [赤伝処理]

        /// <summary>
		/// 赤入金作成処理
		/// </summary>
		/// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="UpdateSecCd">更新拠点コード</param>
		/// <param name="DepositAgentCode">入金担当者コード</param>
		/// <param name="DepositAgentNm">入金担当者名</param>
		/// <param name="AddUpADate">計上日</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
        // ↓ 20070124 18322 c MA.NS用に変更
		//public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo )
		//public int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo )                    //DEL 2008/04/25 M.Kubota
        public int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus)  //ADD 2008/04/25 M.Kubota
        // ↑ 20070124 18322 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            try
            {
                //--- DEL 2008/04/25 M.Kubota --->>>
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                //SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<
                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // ↓ 20070124 18322 c MA.NS用に変更
                // // 赤伝作成処理
                //status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo , ref sqlConnection, ref sqlTransaction);

                // 赤伝作成処理
                //status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, DepositSlipNo, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                status = RedCreateProc(mode, EnterpriseCode, UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, DepositSlipNo, AcptAnOdrStatus, ref sqlConnection, ref sqlTransaction);               //ADD 2008/04/25 M.Kubota
                // ↑ 20070124 18322 c

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<

            //--- DEL 2008/04/2 M.Kubota --->>>
            //if(sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            //--- DEL 2008/04/2 M.Kubota ---<<<

			return status;
		}

		/// <summary>
		/// 赤入金作成処理
		/// </summary>
		/// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="UpdateSecCd">更新拠点コード</param>
		/// <param name="DepositAgentCode">入金担当者コード</param>
		/// <param name="DepositAgentNm">入金担当者名</param>
		/// <param name="AddUpADate">計上日</param>
		/// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
		/// <param name="RetDepsitDataWorkListByte">更新入金MTレコード</param>
		/// <param name="RetDepositAlwWorkListByte">更新入金引当MTレコード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS用に変更</br>
        /// <br></br>
		/// </remarks>
        // ↓ 20070124 18322 c MA.NS用に変更
		//public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte )
		//public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitMainWorkListByte, out byte[] RetDepositAlwWorkListByte )  //DEL 2008/04/25 M.Kubota
        public int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte)                    //ADD 2008/04/25 M.Kubota
        // ↑ 20070124 18322 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			//DepsitMainWork[] RetDepsitMainWorkList = null;  //DEL 2008/04/25 M.Kubota
            DepsitDataWork[] RetDepsitDataWorkList = null;    //ADD 2008/04/25 M.Kubota
			DepositAlwWork[] RetDepositAlwWorkList = null; 

			//RetDepsitMainWorkListByte = null;  //DEL 2008/04/25 M.Kubota
            RetDepsitDataWorkListByte = null;    //ADD 2008/04/25 M.Kubota
            RetDepositAlwWorkListByte = null;

			try 
			{	
				//--- DEL 2008/04/25 M.Kubota --->>>
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

				//SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<
                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // ↓ 20070124 18322 c MA.NS用に変更
				//// 赤伝作成処理
				//status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo ,  out RetDepsitMainWorkList, out RetDepositAlwWorkList ,ref sqlConnection, ref sqlTransaction);

				// 赤伝作成処理
                //--- DEL 2008/04/25 M.Kubota --->>>
                //status = RedCreateProc(     mode
                //                      ,     EnterpriseCode
                //                      ,     DepositCd
                //                      ,     UpdateSecCd
                //                      ,     DepositAgentCode
                //                      ,     DepositAgentNm
                //                      ,     AddUpADate
                //                      ,     DepositSlipNo
                //                      , out RetDepsitMainWorkList
                //                      , out RetDepositAlwWorkList
                //                      , ref sqlConnection
                //                      , ref sqlTransaction);
                // ↑ 20070124 18322 c
                //--- DEL 2008/04/25 M.Kubota ---<<<

                status = RedCreateProc(mode, EnterpriseCode, UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, DepositSlipNo, AcptAnOdrStatus, out RetDepsitDataWorkList, out RetDepositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					sqlTransaction.Commit();

					// XMLへ変換し、文字列のバイナリ化
					//RetDepsitMainWorkListByte = XmlByteSerializer.Serialize(RetDepsitMainWorkList);  //DEL 2008/04/25 M.Kubota
                    RetDepsitDataWorkListByte = XmlByteSerializer.Serialize(RetDepsitDataWorkList);
					RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(RetDepositAlwWorkList);
				}
				else
				{
					sqlTransaction.Rollback();
				}

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
        }

        /// <summary>
        /// 赤入金作成処理
        /// </summary>
        /// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="UpdateSecCd">更新拠点コード</param>
        /// <param name="DepositAgentCode">入金担当者コード</param>
        /// <param name="DepositAgentNm">入金担当者名</param>
        /// <param name="AddUpADate">計上日</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注番号</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS用に変更</br>
        /// <br></br>
        /// </remarks>
        // ↓ 20070124 18322 c MA.NS用に変更
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int RedCreateProc(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                   //ADD 2008/04/25 M.Kubota
        // ↑ 20070124 18322 c
        {
            //DepsitMainWork[] RetDepsitMainWorkList = null;  //DEL 2008/04/25 M.Kubota
            DepsitDataWork[] RetDepsitDataWorkList = null;    //ADD 2008/04/25 M.Kubota
            DepositAlwWork[] RetDepositAlwWorkList = null;

            // ↓ 20070124 18322 c MA.NS用に変更
            //int status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo, out RetDepsitMainWorkList, out RetDepositAlwWorkList, ref sqlConnection,ref sqlTransaction);

            int status = RedCreateProc(mode
                                      , EnterpriseCode
                                      //, DepositCd                  //DEL 2008/04/25 M.Kubota
                                      , UpdateSecCd
                                      , DepositAgentCode
                                      , DepositAgentNm
                                      , AddUpADate
                                      , DepositSlipNo
                                      , AcptAnOdrStatus              //ADD 2008/04/25 M.Kubota
                                      //, out RetDepsitMainWorkList  //DEL 2008/04/25 M.Kubota
                                      , out RetDepsitDataWorkList    //ADD 2008/04/25 M.Kubota
                                      , out RetDepositAlwWorkList
                                      , ref sqlConnection
                                      , ref sqlTransaction);
            // ↑ 20070124 18322 c

            return status;
        }

        // ↓ 20070124 18322 c MA.NS用に変更
        /// <summary>
        /// 赤入金作成処理
        /// </summary>
        /// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="UpdateSecCd">更新拠点コード</param>
        /// <param name="DepositAgentCode">入金担当者コード</param>
        /// <param name="DepositAgentNm">入金担当者名</param>
        /// <param name="AddUpADate">計上日</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="RetDepsitDataWorkList">更新入金MTレコード</param>
        /// <param name="RetDepositAlwWorkList">更新入金引当MTレコード</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定したパラメータで赤入金伝票の作成を行います</br>
        /// <br>Note       : ※赤入金作成時、預り金入金＞通常赤入金の作成が行えます(締黒伝引き当て入金の更新時に使用)</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.26</br>
        /// <br>Update Note: 2010/12/20 李占川 PM.NS障害改良対応(12月分)
        /// <br>             赤伝の入金明細データを作成する。</br>
        /// </remarks>
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int RedCreateProc(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, out DepsitDataWork[] RetDepsitDataWorkList, out DepositAlwWork[] RetDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        // ↑ 20070124 18322 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;
            DepsitDataWork depsitDataWork = null;      //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota
            
            //RetDepsitMainWorkList = null;  //DEL 2008/04/25 M.Kubota
            RetDepsitDataWorkList = null;    //ADD 2008/04/25 M.Kubota
            RetDepositAlwWorkList = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/25 M.Kubota

            try
            {
                // 元黒入金読込み処理
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);        //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);  //ADD 2008/04/25 M.Kubota

                //--- DEL 2008/04/25 M.Kubota --->>>
                // 更新時ロック処理
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(depsitMainWork.EnterpriseCode, CustomerCodeList, null);	// 得意先別ロックをかける
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // ?????????
                // ここで赤伝チェック！！！！！！>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (depsitMainWork.DepositDebitNoteCd != 0)
                {
                    // 読込み入金データの入金赤黒区分が０：黒　以外のとき、排他エラーを返す
                    // (赤入金・相殺済み黒入金の赤入金処理は不可！・・他端末更新可能性があるので排他エラー)
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }
                // <<<<<<<<<<<<<<<<<<<<<

                ArrayList ar = new ArrayList();
                DepositAlwWork[] Red_depositAlwWorkList = (DepositAlwWork[])ar.ToArray(typeof(DepositAlwWork));

                // ↓ 20070124 18322 c MA.NS用に変更
                //// 元黒入金データを元に赤入金情報作成
                //DepsitMainWork Red_depsitMainWork = CreateRedDepsitProc(DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate,  depsitMainWork);

                // 元黒入金データを元に赤入金情報作成
                //--- DEL 2008/04/258 M.Kubota --->>>
                //DepsitMainWork Red_depsitMainWork = CreateRedDepsitProc(DepositCd
                //                                                       , UpdateSecCd
                //                                                       , DepositAgentCode
                //                                                       , DepositAgentNm
                //                                                       , AddUpADate
                //                                                       , depsitMainWork);
                // ↑ 20070124 18322 c
                //--- DEL 2008/04/258 M.Kubota ---<<<

                DepsitMainWork Red_depsitMainWork = CreateRedDepsitProc(UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, depsitMainWork);  //ADD 2008/04/25 M.Kubota

                // 元黒に引当データがある場合
                if (depositAlwWorkList != null && depositAlwWorkList.Length > 0)
                {
                    Red_depsitMainWork.LastReconcileAddUpDt = AddUpADate;							// 最終消し込み計上日←計上日

                    // ↓ 20070124 18322 c MA.NS用に変更
                    //// 元黒入金引当データを元に赤入金引当情報作成
                    //Red_depositAlwWorkList = CreateRedDepositAlwWorkProc(DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, depositAlwWorkArray);

                    // 元黒入金引当データを元に赤入金引当情報作成
                    //--- DEL 2008/04/25 M.Kubota --->>>
                    //Red_depositAlwWorkList = CreateRedDepositAlwWorkProc(DepositCd
                    //                                                    , UpdateSecCd
                    //                                                    , DepositAgentCode
                    //                                                    , DepositAgentNm
                    //                                                    , AddUpADate
                    //                                                    , depositAlwWorkList);
                    // ↑ 20070124 18322 c
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    Red_depositAlwWorkList = CreateRedDepositAlwWorkProc(UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, depositAlwWorkList);  //ADD 2008/04/25 M.Kubota
                }
                else
                {
                    Red_depsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;					// 最終消し込み計上日←無し
                }

                // 赤入金データの更新処理
                //status = WriteDepsitMainWork(ref Red_depsitMainWork, ref Red_depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                DepsitDtlWork[] Red_depsitDtlWorkList = null;

                // --- ADD 2010/12/20 ---------->>>>>
                // 赤伝の入金明細データを作成する。
                Red_depsitDtlWorkList = this.CreateRedDepsitDtlWork(Red_depsitMainWork.DepositSlipNo, depsitDtlWorkList);
                // --- ADD 2010/12/20  ----------<<<<<

                status = this.Write(ref Red_depsitMainWork, ref Red_depsitDtlWorkList, ref Red_depositAlwWorkList, ref sqlConnection, ref sqlTransaction);

                // 赤伝の入金明細をUI側で表示用に使用する為に作成する、DBには赤伝明細は登録しない
                Red_depsitDtlWorkList = this.CreateRedDepsitDtlWork(Red_depsitMainWork.DepositSlipNo, depsitDtlWorkList); 
                //--- ADD 2008/04/25 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                # region --- pending 2008/04/25 M.Kubota ---
                # if false
                DepsitMainWork Black_depsitMainWork = null;
                DepsitDtlWork[] Black_depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota
                DepositAlwWork[] Black_depositAlwWorkList = null;

                // 新黒作成モード時
                if (mode == 1)
                {
                    ArrayList ar2 = new ArrayList();
                    Black_depositAlwWorkList = (DepositAlwWork[])ar2.ToArray(typeof(DepositAlwWork));

                    // ↓ 20070124 18322 c MA.NS用に変更
                    //// 元黒入金データを元に新黒入金情報作成
                    //Black_depsitMainWork = CreateNewBlackDepsitProc(UpdateSecCd, DepositAgentCode, AddUpADate,  depsitMainWork);

                    // 元黒入金データを元に新黒入金情報作成
                    Black_depsitMainWork = CreateNewBlackDepsitProc(UpdateSecCd
                                                                   , DepositAgentCode
                                                                   , DepositAgentNm
                                                                   , AddUpADate
                                                                   , depsitMainWork);
                    // ↑ 20070124 18322 c

                    // 新黒入金データの更新処理
                    //status = WriteDepsitMainWork(ref Black_depsitMainWork, ref Black_depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    //status = this.Write(ref 
                }
                # endif
                # endregion

                // 元黒の入金・引当情報の変更

                // 更新従業員コード ???
                //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                // 入金赤黒区分に2:相殺済み黒をセット
                depsitMainWork.DepositDebitNoteCd = 2;

                // 元黒入金の赤黒連結番号に入金番号を入れる
                depsitMainWork.DebitNoteLinkDepoNo = Red_depsitMainWork.DepositSlipNo;

                if (depositAlwWorkList != null)
                {
                    for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                    {
                        // 更新従業員コード ???
                        //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                        // 赤伝相殺区分に2:相殺済み黒をセット
                        depositAlwWorkList[ix].DebitNoteOffSetCd = 2;
                    }
                }

                // 元黒入金マスタ更新処理
                //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);              //DEL 2008/04/25 M.Kubota
                status = this.Write(ref depsitMainWork, ref depsitDtlWorkList, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 戻り値として更新データを返す
                    //ArrayList RetDepsitMainWorkArrayList = new ArrayList();  //DEL 2008/04/25 M.Kubota
                    ArrayList RetDepsitDataWorkArrayList = new ArrayList();    //ADD 2008/04/25 M.Kubota
                    ArrayList RetDepositAlwWorkArrayList = new ArrayList();

                    //--- DEL 2008/04/25 M.Kubota --->>>
                    //if (depsitMainWork != null && depsitMainWork.DepositSlipNo != 0)
                    //{
                    //    RetDepsitMainWorkArrayList.Add(depsitMainWork);
                    //}
                    //if (Red_depsitMainWork != null && Red_depsitMainWork.DepositSlipNo != 0)
                    //{
                    //    RetDepsitMainWorkArrayList.Add(Red_depsitMainWork);
                    //}
                    //if (Black_depsitMainWork != null && Black_depsitMainWork.DepositSlipNo != 0)
                    //{
                    //    RetDepsitMainWorkArrayList.Add(Black_depsitMainWork);
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkList);

                    if (depsitDataWork != null && depsitDataWork.DepositSlipNo != 0)
                    {
                        RetDepsitDataWorkArrayList.Add(depsitDataWork);
                    }

                    DepsitDataWork Red_depsitDataWork = null;
                    DepsitDataUtil.Union(out Red_depsitDataWork, Red_depsitMainWork, Red_depsitDtlWorkList);

                    if (Red_depsitDataWork != null && Red_depsitDataWork.DepositSlipNo != 0)
                    {
                        RetDepsitDataWorkArrayList.Add(Red_depsitDataWork);
                    }
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    if (depositAlwWorkList != null && depositAlwWorkList.Length != 0)
                    {
                        foreach (DepositAlwWork rec in depositAlwWorkList)
                        {
                            RetDepositAlwWorkArrayList.Add(rec);

                        }
                    }
                    if (Red_depositAlwWorkList != null && Red_depositAlwWorkList.Length != 0)
                    {
                        foreach (DepositAlwWork rec in Red_depositAlwWorkList)
                        {
                            RetDepositAlwWorkArrayList.Add(rec);

                        }
                    }
                    //--- DEL 2008/04/25 M.Kubota --->>>
                    //if (Black_depositAlwWorkList != null && Black_depositAlwWorkList.Length != 0)
                    //{
                    //    foreach (DepositAlwWork rec in Black_depositAlwWorkList)
                    //    {
                    //        RetDepositAlwWorkArrayList.Add(rec);
                    //    }
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    //RetDepsitMainWorkList = (DepsitMainWork[])RetDepsitMainWorkArrayList.ToArray(typeof(DepsitMainWork));  //DEL 2008/04/25 M.Kubota
                    RetDepsitDataWorkList = (DepsitDataWork[])RetDepsitDataWorkArrayList.ToArray(typeof(DepsitDataWork));    //ADD 2008/04/25 M.Kubota
                    RetDepositAlwWorkList = (DepositAlwWork[])RetDepositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
            }

            return status;
        }

        /// <summary>
        /// 赤入金情報生成処理
        /// </summary>
        /// <param name="updateSecCd">更新拠点</param>
        /// <param name="depositAgentCode">赤入金担当者コード</param>
        /// <param name="depositAgentNm">赤入金担当者名称</param>
        /// <param name="addUpADate">赤入金計上日</param>
        /// <param name="depsitMainWork">元黒入金情報</param>
        /// <returns>赤入金情報</returns>
        //--- DEL 2008/04/25 M.Kubota --->>>
        //public DepsitMainWork CreateRedDepsitProc(int depositCd
        //                                         , string updateSecCd
        //                                         , string depositAgentCode
        //                                         , string depositAgentNm
        //                                         , DateTime addUpADate
        //                                         , DepsitMainWork depsitMainWork)
        //--- DEL 2008/04/25 M.Kubota ---<<<
        private DepsitMainWork CreateRedDepsitProc(string updateSecCd, string depositAgentCode, string depositAgentNm, DateTime addUpADate, DepsitMainWork depsitMainWork)  //ADD 2008/04/25 M.Kubota
        {
            DepsitMainWork newDepsitMainWork = new DepsitMainWork();

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false
            // 企業コード
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
            // 更新従業員コード<-入金担当者コード ???
            newDepsitMainWork.UpdEmployeeCode = depositAgentCode;
            // 更新アセンブリID1
            newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
            // 更新アセンブリID2
            newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
            // 論理削除区分
            newDepsitMainWork.LogicalDeleteCode = 0;
            // 赤黒区分＝１：赤
            newDepsitMainWork.DepositDebitNoteCd = 1;
            // 入金番号
            newDepsitMainWork.DepositSlipNo = 0;
            // ↓ 2007.10.12 980081 d
            //// 受注番号
            //newDepsitMainWork.AcceptAnOrderNo = depsitMainWork.AcceptAnOrderNo;
            //// サービス伝票区分
            //newDepsitMainWork.ServiceSlipCd = depsitMainWork.ServiceSlipCd;
            // ↑ 2007.10.12 980081 d
            // 入金入力拠点コード
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;
            // 計上拠点コード
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;
            // 更新拠点コード???
            newDepsitMainWork.UpdateSecCd = updateSecCd;
            // 入金日付???
            // ↓ 2008.03.17 980081 c
            //newDepsitMainWork.DepositDate = addUpADate;
            newDepsitMainWork.DepositDate = DateTime.Now;
            // ↑ 2008.03.17 980081 c
            // 計上日付???
            newDepsitMainWork.AddUpADate = addUpADate;
            // 入金金種コード
            newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;
            // 入金金種名称
            newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;
            // 入金金種区分
            newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;
            // 入金計
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal * -1;
            // 入金金額
            newDepsitMainWork.Deposit = depsitMainWork.Deposit * -1;
            // 手数料入金額
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit * -1;
            // 値引入金額
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit * -1;
            // ↓ 2007.10.12 980081 d
            //// リベート入金額
            //newDepsitMainWork.RebateDeposit = depsitMainWork.RebateDeposit * -1;
            // ↑ 2007.10.12 980081 d
            // 自動入金区分
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;
            // 預り金区分
            newDepsitMainWork.DepositCd = depositCd;
            // ↓ 2007.10.12 980081 d
            //// クレジット／ローン区分
            //newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;
            //// クレジット会社コード
            //newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;
            // ↑ 2007.10.12 980081 d
            // 手形振出日
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;
            // 手形支払期日
            newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;
            // 入金引当額
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance * -1;
            // 入金引当残高
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce * -1;
            // 赤黒入金連結番号（←元黒入金番号をセット）
            newDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DepositSlipNo;
            // 最終消し込み計上日（←一旦無し）
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;
            // 入金担当者コード???
            newDepsitMainWork.DepositAgentCode = depositAgentCode;
            // 入金担当者名称
            newDepsitMainWork.DepositAgentNm = depositAgentNm;
            // 得意先コード
            newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;
            // 得意先名称
            newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;
            // 得意先名称2
            newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;
            // 伝票摘要
            newDepsitMainWork.Outline = depsitMainWork.Outline;
            // ↓ 2007.10.12 980081 a
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;
            newDepsitMainWork.MinSectionCode = depsitMainWork.MinSectionCode;
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;
            newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;
            newDepsitMainWork.BankName = depsitMainWork.BankName;
            newDepsitMainWork.EdiSendDate = depsitMainWork.EdiSendDate;
            newDepsitMainWork.EdiTakeInDate = depsitMainWork.EdiTakeInDate;
            // ↑ 2007.10.12 980081 a
            # endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;                    // 企業コード
            newDepsitMainWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;                  // 受注ステータス
            newDepsitMainWork.DepositDebitNoteCd = 1;                                            // 入金赤黒区分 1:赤伝
            newDepsitMainWork.DepositSlipNo = 0;                                                 // 入金伝票番号 ※後に採番される
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;                        // 売上伝票番号
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;              // 入金入力拠点コード
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;                        // 計上拠点コード
            newDepsitMainWork.UpdateSecCd = updateSecCd;                                         // 更新拠点コード
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;                    // 部門コード
            newDepsitMainWork.InputDay = DateTime.Now;                                          // 入力日付  //ADD 2009/03/25
            // --- UPD 2010/12/20 ---------->>>>>
            //newDepsitMainWork.DepositDate = DateTime.Now;                                        // 入金日付
            newDepsitMainWork.DepositDate = addUpADate;                                        // 入金日付
            // --- UPD 2010/12/20  ----------<<<<<
            newDepsitMainWork.AddUpADate = addUpADate;                                           // 計上日付
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal * -1;                   // 入金計
            newDepsitMainWork.Deposit = depsitMainWork.Deposit * -1;                             // 入金金額
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit * -1;                       // 手数料入金額
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit * -1;             // 値引入金額
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;                      // 自動入金区分
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;                // 手形振出日
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;                              // 手形種類
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;                      // 手形種類名称
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;                          // 手形区分
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;                  // 手形区分名称
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;                                  // 手形番号
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance * -1;           // 入金引当額
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce * -1;           // 入金引当残高
            newDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DepositSlipNo;                // 赤黒入金連結番号
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;                          // 最終消し込み計上日
            newDepsitMainWork.DepositAgentCode = depositAgentCode;                               // 入金担当者コード
            newDepsitMainWork.DepositAgentNm = depositAgentNm;                                   // 入金担当者名称
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;          // 入金入力者コード
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;          // 入金入力者名称
            newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;                        // 得意先コード
            newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;                        // 得意先名称
            newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;                      // 得意先名称2
            newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;                          // 得意先略称
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;                              // 請求先コード
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;                              // 請求先名称
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;                            // 請求先名称2
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;                                // 請求先略称
            newDepsitMainWork.Outline = depsitMainWork.Outline;                                  // 伝票摘要
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;                                // 銀行コード
            newDepsitMainWork.BankName = depsitMainWork.BankName;                                // 銀行名称
            //--- ADD 2008/04/25 M.Kubota ---<<<

            return newDepsitMainWork;
        }

        /// <summary>
        /// 赤入金引当情報生成処理
        /// </summary>
        /// <param name="updateSecCd">更新拠点</param>
        /// <param name="depositAgentCode">赤入金担当者コード</param>
        /// <param name="depositAgentNm">赤入金担当者名称</param>
        /// <param name="addUpADate">赤入金計上日</param>
        /// <param name="depositAlwWorkList">元黒入金引当情報</param>
        /// <returns>赤入金引当情報</returns>
        //--- DEL 2008/04/25 M.Kubota --->>>
        //private DepositAlwWork[] CreateRedDepositAlwWorkProc(int depositCd
        //                                                    , string updateSecCd
        //                                                    , string depositAgentCode
        //                                                    , string depositAgentNm
        //                                                    , DateTime addUpADate
        //                                                    , DepositAlwWork[] depositAlwWorkList)
        //--- DEL 2008/04/25 M.Kubota ---<<<
        private DepositAlwWork[] CreateRedDepositAlwWorkProc(string updateSecCd, string depositAgentCode, string depositAgentNm, DateTime addUpADate, DepositAlwWork[] depositAlwWorkList)  //ADD 2008/04/25 M.Kubota
        {
            ArrayList newDepositAlwWorkList = new ArrayList();

            for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
            {
                DepositAlwWork newDepositAlwWork = new DepositAlwWork();

                # region --- DEL 2008/04/25 M.Kubota ---
                # if false
                // 企業コード
                newDepositAlwWork.EnterpriseCode = depositAlwWorkList[ix].EnterpriseCode;

                // 更新従業員コード<-入金担当者コード ???
                newDepositAlwWork.UpdEmployeeCode = depositAgentCode;

                // 論理削除区分
                newDepositAlwWork.LogicalDeleteCode = 0;

                // 入金入力拠点コード
                newDepositAlwWork.InputDepositSecCd = depositAlwWorkList[ix].InputDepositSecCd;

                // 計上拠点コード
                newDepositAlwWork.AddUpSecCode = depositAlwWorkList[ix].AddUpSecCode;

                // 消込み日←システム日付
                newDepositAlwWork.ReconcileDate = DateTime.Now;

                // 消込み計上日←入金計上日
                newDepositAlwWork.ReconcileAddUpDate = addUpADate;

                // 入金伝票番号
                newDepositAlwWork.DepositSlipNo = 0;

                // 入金金種コード
                newDepositAlwWork.DepositKindCode = depositAlwWorkList[ix].DepositKindCode;

                // 入金金種名称
                newDepositAlwWork.DepositKindName = depositAlwWorkList[ix].DepositKindName;

                // 入金引当額
                newDepositAlwWork.DepositAllowance = depositAlwWorkList[ix].DepositAllowance * -1;

                // 入金担当者コード
                newDepositAlwWork.DepositAgentCode = depositAgentCode;

                // 入金担当者名称
                newDepositAlwWork.DepositAgentNm = depositAgentNm;

                // 得意先コード
                newDepositAlwWork.CustomerCode = depositAlwWorkList[ix].CustomerCode;

                // 得意先名称
                newDepositAlwWork.CustomerName = depositAlwWorkList[ix].CustomerName;

                // 得意先名称2
                newDepositAlwWork.CustomerName2 = depositAlwWorkList[ix].CustomerName2;

                // ↓ 2007.10.12 980081 d
                //// 受注番号
                //newDepositAlwWork.AcceptAnOrderNo = depositAlwWorkArray[ix].AcceptAnOrderNo;
                //
                //// サービス伝票区分
                //newDepositAlwWork.ServiceSlipCd = depositAlwWorkArray[ix].ServiceSlipCd;
                // ↑ 2007.10.12 980081 d

                // 赤伝相殺区分 1:赤
                newDepositAlwWork.DebitNoteOffSetCd = 1;

                // 預り金区分←パラメータ値
                newDepositAlwWork.DepositCd = depositCd;

                // ↓ 2007.10.12 980081 d
                //// クレジット／ローン区分
                //newDepositAlwWork.CreditOrLoanCd = depositAlwWorkArray[ix].CreditOrLoanCd;
                // ↑ 2007.10.12 980081 d
                // ↓ 2007.10.12 980081 a
                newDepositAlwWork.AcptAnOdrStatus = depositAlwWorkList[ix].AcptAnOdrStatus;
                newDepositAlwWork.SalesSlipNum = depositAlwWorkList[ix].SalesSlipNum;
                // ↑ 2007.10.12 980081 a
                # endif
                # endregion

                //--- ADD 2008/04/25 M.Kubota --->>>
                newDepositAlwWork.EnterpriseCode = depositAlwWorkList[ix].EnterpriseCode;            // 企業コード
                newDepositAlwWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
                newDepositAlwWork.InputDepositSecCd = depositAlwWorkList[ix].InputDepositSecCd;      // 入金入力拠点コード
                newDepositAlwWork.AddUpSecCode = depositAlwWorkList[ix].AddUpSecCode;                // 計上拠点コード
                newDepositAlwWork.AcptAnOdrStatus = depositAlwWorkList[ix].AcptAnOdrStatus;          // 受注ステータス
                newDepositAlwWork.SalesSlipNum = depositAlwWorkList[ix].SalesSlipNum;                // 売上伝票番号
                newDepositAlwWork.ReconcileDate = DateTime.Now;                                      // 消込み日
                newDepositAlwWork.ReconcileAddUpDate = addUpADate;                                   // 消込み計上日
                newDepositAlwWork.DepositSlipNo = 0;                                                 // 入金伝票番号
                newDepositAlwWork.DepositAllowance = depositAlwWorkList[ix].DepositAllowance * -1;   // 入金引当額
                newDepositAlwWork.DepositAgentCode = depositAgentCode;                               // 入金担当者コード
                newDepositAlwWork.DepositAgentNm = depositAgentNm;                                   // 入金担当者名称
                newDepositAlwWork.CustomerCode = depositAlwWorkList[ix].CustomerCode;              // 得意先コード
                newDepositAlwWork.CustomerName = depositAlwWorkList[ix].CustomerName;              // 得意先名称
                newDepositAlwWork.CustomerName2 = depositAlwWorkList[ix].CustomerName2;            // 得意先名称2
                newDepositAlwWork.DebitNoteOffSetCd = 1;                                             // 赤伝相殺区分
                //--- ADD 2008/04/25 M.Kubota ---<<<

                newDepositAlwWorkList.Add(newDepositAlwWork);
            }

            return (DepositAlwWork[])newDepositAlwWorkList.ToArray(typeof(DepositAlwWork));
        }

        /// <summary>
        /// 新黒入金情報生成処理
        /// </summary>
        /// <param name="updateSecCd">更新拠点</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="addUpADate">入金計上日</param>
        /// <param name="depsitMainWork">元黒入金情報</param>
        /// <returns>新黒入金情報</returns>
        private DepsitMainWork CreateNewBlackDepsitProc(string updateSecCd
                                                      , string depositAgentCode
                                                      , string depositAgentNm
                                                      , DateTime addUpADate
                                                      , DepsitMainWork depsitMainWork)
        {
            DepsitMainWork newDepsitMainWork = new DepsitMainWork();

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false
            // 企業コード
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;

            // 更新従業員コード<-入金担当者コード ???
            newDepsitMainWork.UpdEmployeeCode = updateSecCd;

            // 更新アセンブリID1
            newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;

            // 更新アセンブリID2
            newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;

            // 論理削除区分
            newDepsitMainWork.LogicalDeleteCode = 0;

            // 入金赤黒区分  ０：黒
            newDepsitMainWork.DepositDebitNoteCd = 0;

            // 入金伝票番号
            newDepsitMainWork.DepositSlipNo = 0;

            // ↓ 2007.10.12 980081 d
            //// 売上伝票番号
            //newDepsitMainWork.AcceptAnOrderNo = depsitMainWork.AcceptAnOrderNo;
            //
            //// サービス伝票区分
            //newDepsitMainWork.ServiceSlipCd = depsitMainWork.ServiceSlipCd;
            // ↑ 2007.10.12 980081 d

            // 入金入力拠点コード
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;

            // 計上拠点コード
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;

            // 更新拠点コード <- 更新拠点コード???
            newDepsitMainWork.UpdateSecCd = updateSecCd;

            // 入金日付 <- 入金日付???
            // ↓ 2008.03.17 980081 c
            //newDepsitMainWork.DepositDate = addUpADate;
            newDepsitMainWork.DepositDate = DateTime.Now;
            // ↑ 2008.03.17 980081 c

            // 計上日付 <- 計上日付???
            newDepsitMainWork.AddUpADate = addUpADate;

            // 入金金種コード
            newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;

            // 入金金種名称
            newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;

            // 入金金種区分
            newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;

            // 入金計
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;

            // 入金金額
            newDepsitMainWork.Deposit = depsitMainWork.Deposit;

            // 手数料入金額
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;

            // 値引入金額
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;

            // ↓ 2007.10.12 980081 d
            //// リベート入金額
            //newDepsitMainWork.RebateDeposit = depsitMainWork.RebateDeposit;
            // ↑ 2007.10.12 980081 d

            // 自動入金区分
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;

            // 預り金区分
            newDepsitMainWork.DepositCd = depsitMainWork.DepositCd;

            // ↓ 2007.10.12 980081 d
            //// クレジット／ローン区分
            //newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;
            //
            //// クレジット会社コード
            //newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;
            // ↑ 2007.10.12 980081 d

            // 手形振出日
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;

            // 手形支払期日
            newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;

            // 入金引当額
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;

            // 入金引当残高
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;

            // 赤黒入金連結番号 (なし)
            newDepsitMainWork.DebitNoteLinkDepoNo = 0;

            // 最終消し込み計上日 ←一旦無し
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;

            // 入金担当者コード??
            newDepsitMainWork.DepositAgentCode = depositAgentCode;

            // 入金担当者名称
            newDepsitMainWork.DepositAgentNm = depositAgentNm;

            // 得意先コード
            newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;

            // 得意先名称
            newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;

            // 得意先名称2
            newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;

            // 伝票摘要
            newDepsitMainWork.Outline = depsitMainWork.Outline;
            // ↓ 2007.10.12 980081 a
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;
            newDepsitMainWork.MinSectionCode = depsitMainWork.MinSectionCode;
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;
            newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;
            newDepsitMainWork.BankName = depsitMainWork.BankName;
            newDepsitMainWork.EdiSendDate = depsitMainWork.EdiSendDate;
            newDepsitMainWork.EdiTakeInDate = depsitMainWork.EdiTakeInDate;
            // ↑ 2007.10.12 980081 a
            # endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;                    // 企業コード
            newDepsitMainWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;                  // 受注ステータス
            newDepsitMainWork.DepositDebitNoteCd = 0;                                            // 入金赤黒区分 0:黒伝
            newDepsitMainWork.DepositSlipNo = 0;                                                 // 入金伝票番号 ※後に採番される
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;                        // 売上伝票番号
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;              // 入金入力拠点コード
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;                        // 計上拠点コード
            newDepsitMainWork.UpdateSecCd = updateSecCd;                                         // 更新拠点コード
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;                    // 部門コード
            newDepsitMainWork.InputDay = DateTime.Now;                                          // 入力日付  //ADD 2009/03/25
            newDepsitMainWork.DepositDate = DateTime.Now;                                       // 入金日付
            newDepsitMainWork.AddUpADate = addUpADate;                                           // 計上日付
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;                        // 入金計
            newDepsitMainWork.Deposit = depsitMainWork.Deposit;                                  // 入金金額
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;                            // 手数料入金額
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;                  // 値引入金額
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;                      // 自動入金区分
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;                // 手形振出日
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;                              // 手形種類
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;                      // 手形種類名称
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;                          // 手形区分
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;                  // 手形区分名称
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;                                  // 手形番号
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;                // 入金引当額
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;                // 入金引当残高
            newDepsitMainWork.DebitNoteLinkDepoNo = 0;                                           // 赤黒入金連結番号
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;                          // 最終消し込み計上日
            newDepsitMainWork.DepositAgentCode = depositAgentCode;                               // 入金担当者コード
            newDepsitMainWork.DepositAgentNm = depositAgentNm;                                   // 入金担当者名称
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;          // 入金入力者コード
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;          // 入金入力者名称
            //newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;                      // 得意先コード
            //newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;                      // 得意先名称
            //newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;                    // 得意先名称2
            //newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;                        // 得意先略称
            newDepsitMainWork.CustomerCode = depsitMainWork.ClaimCode;                           // 得意先コード
            newDepsitMainWork.CustomerName = depsitMainWork.ClaimName;                           // 得意先名称
            newDepsitMainWork.CustomerName2 = depsitMainWork.ClaimName2;                         // 得意先名称2
            newDepsitMainWork.CustomerSnm = depsitMainWork.ClaimSnm;                             // 得意先略称            
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;                              // 請求先コード
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;                              // 請求先名称
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;                            // 請求先名称2
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;                                // 請求先略称
            newDepsitMainWork.Outline = depsitMainWork.Outline;                                  // 伝票摘要
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;                                // 銀行コード
            newDepsitMainWork.BankName = depsitMainWork.BankName;                                // 銀行名称
            //--- ADD 2008/04/25 M.Kubota ---<<<

            return newDepsitMainWork;
        }

        //--- ADD 2008/04/25 M.Kubota --->>>
        private DepsitDtlWork[] CreateRedDepsitDtlWork(int redDepositSlipNo, DepsitDtlWork[] depsitDtlWork)
        {
            ArrayList RedDepsitDtlArray = new ArrayList();

            foreach (DepsitDtlWork dtl in depsitDtlWork)
            {
                DepsitDtlWork addDtl = new DepsitDtlWork();

                addDtl.CreateDateTime = dtl.CreateDateTime;        // 作成日時
                addDtl.UpdateDateTime = dtl.UpdateDateTime;        // 更新日時
                addDtl.EnterpriseCode = dtl.EnterpriseCode;        // 企業コード
                addDtl.FileHeaderGuid = dtl.FileHeaderGuid;        // GUID
                addDtl.UpdEmployeeCode = dtl.UpdEmployeeCode;      // 更新従業員コード
                addDtl.UpdAssemblyId1 = dtl.UpdAssemblyId1;        // 更新アセンブリID1
                addDtl.UpdAssemblyId2 = dtl.UpdAssemblyId2;        // 更新アセンブリID2
                addDtl.LogicalDeleteCode = dtl.LogicalDeleteCode;  // 論理削除区分
                addDtl.AcptAnOdrStatus = dtl.AcptAnOdrStatus;      // 受注ステータス
                addDtl.DepositSlipNo = redDepositSlipNo;           // 入金伝票番号
                addDtl.DepositRowNo = dtl.DepositRowNo;            // 入金行番号
                addDtl.MoneyKindCode = dtl.MoneyKindCode;          // 金種コード
                addDtl.MoneyKindName = dtl.MoneyKindName;          // 金種名称
                addDtl.MoneyKindDiv = dtl.MoneyKindDiv;            // 金種区分
                addDtl.Deposit = dtl.Deposit * -1;                 // 入金金額
                addDtl.ValidityTerm = dtl.ValidityTerm;            // 有効期限

                RedDepsitDtlArray.Add(addDtl);
            }

            return (DepsitDtlWork[])RedDepsitDtlArray.ToArray(typeof(DepsitDtlWork));
        }
        //--- ADD 2008/04/25 M.Kubota ---<<<
        # endregion

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        #region[受取手形]

        #region[削除]

        /// <summary>
        /// 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="rcvDraftDataWork">受取手形データマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.06</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int DeleteDraftProc(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<


                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != rcvDraftDataWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    // データは全て削除
                    # region [DELETE文]
                    sqlText = string.Empty;
                    //sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
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

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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

        #region [更新、登録]
        /// <summary>
        /// 受取手形データマスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="rcvDraftDataWork">受取手形データマスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報を登録、更新します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.06</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int WriteDraftProc(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList ayList = new ArrayList();

            try
            {
                string sqlText = string.Empty;

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        DateTime comUpDateTime = rcvDraftDataWork.UpdateDateTime;

                        // 排他チェック
                        if (_updateDateTime != comUpDateTime)
                        {
                            //既存データで更新日時違いの場合には排他
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            return status;
                        }
                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE RCVDRAFTDATARF " + Environment.NewLine;
                        sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , RCVDRAFTNORF=@RCVDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , DEPOSITRF=@DEPOSIT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , CUSTOMERSNMRF=@CUSTOMERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITROWNORF=@DEPOSITROWNO , DEPOSITDATERF=@DEPOSITDATE " + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                        findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (rcvDraftDataWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //　画面のデータ、insert処理
                        # region [INSERT文]
                        sqlText = string.Empty;
                        sqlText = "INSERT INTO RCVDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @RCVDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @DEPOSIT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @ACPTANODRSTATUS, @DEPOSITSLIPNO, @DEPOSITROWNO, @DEPOSITDATE)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (myReader.IsClosed == false) myReader.Close();

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraRcvDraftNo = sqlCommand.Parameters.Add("@RCVDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                    SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                    SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rcvDraftDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.LogicalDeleteCode);
                    paraRcvDraftNo.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.RcvDraftNo);
                    paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftKindCd);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftDivide);
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(rcvDraftDataWork.Deposit);
                    paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.BankAndBranchCd);
                    paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.BankAndBranchNm);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.SectionCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.AddUpSecCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerSnm);
                    paraProcDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ProcDate);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ValidityTerm);
                    paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftStmntDate);
                    paraOutline1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline1);
                    paraOutline2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline2);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.AcptAnOdrStatus);
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositSlipNo);
                    paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositRowNo);
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DepositDate);

                    sqlCommand.ExecuteNonQuery();

                    ayList.Add(rcvDraftDataWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDatatDB.Write" + status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

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

        #endregion
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        # region ---DEL 2008/04/25 M.Kubota --- [コメントアウトされたソースの為]
# if false
        //--- DEL 2008/04/25 M.Kubota --->>> [未使用の為]
		/// <summary>
		/// 指定された企業コードの入金伝票番号最大値を戻します
		/// </summary>
		/// <param name="DepositSlipNo">入金伝票番号</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定された企業コードの最大入金伝票番号を戻します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.03</br>
		/// </remarks>
		private int GetMaxDepositSlipNoProc(out int DepositSlipNo,string EnterpriseCode, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int wkDepositSlipNo = 0;
			SqlDataReader myReader = null;

			try 
			{			
				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT MAX(DEPOSITSLIPNORF) DEPOSITSLIPNORF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction))
				{

					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						wkDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			DepositSlipNo = wkDepositSlipNo;

			return status;
        }
        //--- DEL 2008/04/25 M.Kubota ---<<<
        
        // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 入金引当マスタ情報を更新します（全てコメントアウト）
        ///// <summary>
		///// 入金引当マスタ情報を更新します
		///// </summary>
		///// <param name="depositAlwWork">入金引当情報</param>
		///// <param name="bf_DepositAllowance">更新前引当額</param>
		///// <param name="bf_AcpOdrDepositAlwc">更新前受注入金引当額</param>
		///// <param name="bf_VarCostDepoAlwc">更新前諸費用入金引当額</param>
		///// <param name="bf_DepositCd">更新前預り金区分</param>
		///// <param name="bf_CreditOrLoanCd">更新前クレジット／ローン区分</param>
		///// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		///// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : 入金引当マスタ情報の更新を行います</br>
		///// <br>           : 更新時に更新前情報を読み込み、引当額・預かり金区分・クレジット区分の取得も行います</br>
		///// <br>           : ※更新前情報は請求売上ＭＴ更新時に必要となるため</br>
		///// <br>Programmer : 95089 徳永　誠</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>
		//private int WriteDepositAlwWorkRec(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, out Int64 bf_AcpOdrDepositAlwc, out Int64 bf_VarCostDepoAlwc, out int bf_DepositCd,  out int bf_CreditOrLoanCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	bf_DepositAllowance = 0;
		//	bf_DepositCd = 0;
		//	bf_CreditOrLoanCd = 0;
		//	bf_AcpOdrDepositAlwc = 0;			// 20060220 Ins
		//	bf_VarCostDepoAlwc = 0;				// 20060220 Ins
		//
		//	//Selectコマンドの生成
		//	try			
		//	{
		//		using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DEPOSITALLOWANCERF, DEPOSITCDRF, CREDITORLOANCDRF, ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND ADDUPSECCODERF=@FINDADDUPSECCODE", sqlConnection,sqlTransaction))	// 20060220 Chg 受注引当・諸費用引当額の追加
		//		{
		//
		//			//Prameterオブジェクトの作成
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
		//			SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
		//			//					SqlParameter findParaReconcileDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);
		//			SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
		//
		//			//Parameterオブジェクトへ値設定
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
		//			findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//			findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
		//			//					findParaReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
		//			findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
		//
		//			myReader = sqlCommand.ExecuteReader();
		//			if(myReader.Read())
		//			{
		//				//既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
		//				DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
		//				if (_updateDateTime != depositAlwWork.UpdateDateTime)
		//				{
		//					//新規登録で該当データ有りの場合には重複
		//					if (depositAlwWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
		//						//既存データで更新日時違いの場合には排他
		//					else												status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
		//					sqlCommand.Cancel();
		//					if(myReader != null && !myReader.IsClosed)myReader.Close();
		//					return status;
		//				}
		//
		//				// 更新前引当額、更新前預り金区分、クレジット区分取得
		//				bf_DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));		// 引当額
		//				bf_DepositCd		= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));				// 預かり金区分
		//				bf_CreditOrLoanCd	= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));		// クレジット／ローン区分
		//				// 20060220 Ins Start >>>>>>>>>>>>>>
		//				bf_AcpOdrDepositAlwc= SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));		// 受注引当額
		//				bf_VarCostDepoAlwc	= SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));		// 諸費用引当額
		//				// 20060220 Ins End <<<<<<<<<<<<<<<
		//
		//
		//				if(depositAlwWork.LogicalDeleteCode == 0)		// 論理削除区分が立っていない場合は通常更新実行
		//				{
        //                    sqlCommand.CommandText = "UPDATE DEPOSITALWRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , CUSTOMERCODERF=@CUSTOMERCODE , ADDUPSECCODERF=@ADDUPSECCODE , ACCEPTANORDERNORF=@ACCEPTANORDERNO , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITKINDCODERF=@DEPOSITKINDCODE , DEPOSITINPUTDATERF=@DEPOSITINPUTDATE , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , RECONCILEDATERF=@RECONCILEDATE , RECONCILEADDUPDATERF=@RECONCILEADDUPDATE , DEBITNOTEOFFSETCDRF=@DEBITNOTEOFFSETCD , DEPOSITCDRF=@DEPOSITCD, CREDITORLOANCDRF=@CREDITORLOANCD "
		//						+", ACPODRDEPOSITALWCRF=@ACPODRDEPOSITALWC , VARCOSTDEPOALWCRF=@VARCOSTDEPOALWC "		// 200960220 Ins
        //                    	+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND ADDUPSECCODERF=@ADDUPSECCODE";
		//				}
		//				else											// 論理削除区分が立っている場合は削除処理実行
		//				{
		//					sqlCommand.CommandText = "DELETE DEPOSITALWRF "
		//						+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND ADDUPSECCODERF=@ADDUPSECCODE";
		//				}
		//
		//				//KEYコマンドを再設定
		//				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//				findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
		//				findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//				findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
		//					// ????消し込み計上日をどうするか？
//		//				SqlParameter findParaReconcileDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);
//		//				findParaReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
		//				findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
		//
		//				//更新ヘッダ情報を設定
		//				object obj = (object)this;
		//				IFileHeader flhd = (IFileHeader)depositAlwWork;
		//				FileHeader fileHeader = new FileHeader(obj);
		//				fileHeader.SetUpdateHeader(ref flhd,obj);
		//			}
		//			else
		//			{
		//				//既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
		//				if (depositAlwWork.UpdateDateTime > DateTime.MinValue)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//					sqlCommand.Cancel();
		//					if(myReader != null && !myReader.IsClosed)myReader.Close();
		//					return status;
		//				}
		//
        //                //新規作成時のSQL文を生成
		//				sqlCommand.CommandText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
		//					+", ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "	// 20060220 Ins
		//					+") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @ADDUPSECCODE, @ACCEPTANORDERNO, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITINPUTDATE, @DEPOSITALLOWANCE, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEBITNOTEOFFSETCD, @DEPOSITCD, @CREDITORLOANCD"
		//					+", @ACPODRDEPOSITALWC, @VARCOSTDEPOALWC"		// 20060220 Ins
		//					+")";
		//				
		//				//登録ヘッダ情報を設定
		//				object obj = (object)this;
		//				IFileHeader flhd = (IFileHeader)depositAlwWork;
		//				FileHeader fileHeader = new FileHeader(obj);
		//				fileHeader.SetInsertHeader(ref flhd,obj);
		//			}
		//			if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
        //            #region SF 入金引当マスタ Parameterオブジェクトの設定（全てコメントアウト）
        //            //Parameterオブジェクトの作成(更新用)
		//			SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
		//			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
		//			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
		//			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
		//			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
		//			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
		//			SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
		//			SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
		//			SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
		//			SqlParameter paraDepositInputDate = sqlCommand.Parameters.Add("@DEPOSITINPUTDATE", SqlDbType.Int);
		//			SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
		//			SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
		//			SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
		//			SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
		//			SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
		//			SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);					
		//			// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		//			SqlParameter paraAcpOdrDepositAlwc = sqlCommand.Parameters.Add("@ACPODRDEPOSITALWC", SqlDbType.BigInt);
		//			SqlParameter paraVarCostDepoAlwc = sqlCommand.Parameters.Add("@VARCOSTDEPOALWC", SqlDbType.BigInt);
		//			// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//			#endregion
		//			
		//			#region Parameterオブジェクトへ値設定(更新用)
		//			paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
		//			paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
		//			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//			paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
		//			paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
		//			paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
		//			paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
		//			paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
		//			paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//			paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
		//			paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
		//			paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
		//			paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
		//			paraDepositInputDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.DepositInputDate);
		//			paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
		//			paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
		//			paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
		//			paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
		//			paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
		//			paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
		//			// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		//			paraAcpOdrDepositAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc);
		//			paraVarCostDepoAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc);
		//			// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//			#endregion
		//
        //            sqlCommand.ExecuteNonQuery();
		//		}
		//
		//		status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//	}
		//	catch (SqlException ex) 
		//	{
		//		if(myReader != null && !myReader.IsClosed)myReader.Close();
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
        //}
        #endregion
        // ↑ 20070124 18322 c

        // ↓ 20070518 18322 d いらないので削除
        #region 請求売上読込処理（テスト用：仮） 削除
        ///// <summary>
		///// 請求売上読込処理（テスト用：仮）
		///// </summary>
		///// <param name="EnterpriseCode"></param>
		///// <param name="DepositSlipNo"></param>
		///// <param name="depsitDataWorkByte"></param>
		///// <param name="depositAlwWorkListByte"></param>
		///// <returns></returns>
		//public int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
		//	SqlConnection sqlConnection = null;
		//	SqlTransaction sqlTransaction = null;
        //
        //    // ↓ 20070123 18322 c MA.NS用に変更
		//	//DmdSalesWork[] DmdSalesWorkList = null;
        //
        //    // 請求売上データ（売上データ）
		//	SalesSlipWork[] DmdSalesWorkList = null;
        //    // ↑ 20070123 18322 c
        //
		//	dmdSalesWorkListByte = null;
        //
		//	try 
		//	{	
		//		//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
		//		SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
		//		string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
		//		if (connectionText == null || connectionText == "") return status;
        //
		//		//SQL接続
		//		sqlConnection = new SqlConnection(connectionText);
		//		sqlConnection.Open();
		//		sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
        //
		//		// 入金読込み処理
		//		status = ReadDmdSalesWorkRec(EnterpriseCode, ClaimCode, out DmdSalesWorkList, ref sqlConnection, ref sqlTransaction);
        //
		//		if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//			sqlTransaction.Commit();
		//		else
		//			sqlTransaction.Rollback();
        //
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
        //
		//	if(sqlConnection != null)
		//	{
		//		sqlConnection.Close();
		//		sqlConnection.Dispose();
		//	}
        //
		//	// XMLへ変換し、文字列のバイナリ化
		//	dmdSalesWorkListByte = XmlByteSerializer.Serialize(DmdSalesWorkList);
        //
		//	return status;
        //}
        #endregion
        // ↑ 20070518 18322 d

        // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 請求売上マスタ情報の引当額を更新（MA.NSでは請求売上は無い為、全てコメントアウト）
        ///// <summary>
		///// 請求売上マスタ情報の引当額を更新します
		///// </summary>
		///// <param name="depositAlwWork">入金引当情報</param>
		///// <param name="bf_DepositAllowance">更新前入金引当額</param>
		///// <param name="bf_AcpOdrDepositAlwc">更新前受注入金引当額</param>
		///// <param name="bf_VarCostDepoAlwc">更新前諸費用入金引当額</param>
		///// <param name="bf_DepositCd">更新前預り金区分</param>
		///// <param name="bf_CreditOrLoanCd">更新前クレジット／ローン区分</param>
		///// <param name="af_CreditOrLoanCd">更新後クレジット／ローン区分</param>
		///// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		///// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : 入金引当情報と、更新前引当情報・クレジットローン区分により請求売上ＭＴを更新します</br>
		///// <br>Programmer : 95089 徳永　誠</br>
		///// <br>Date       : 2005.08.03</br>
		///// </remarks>	
		//private int UpdateDmdSalesRec(ref DepositAlwWork depositAlwWork, Int64 bf_DepositAllowance, Int64 bf_AcpOdrDepositAlwc, Int64 bf_VarCostDepoAlwc , int bf_DepositCd, int bf_CreditOrLoanCd, int af_CreditOrLoanCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	// Updateコマンドの生成
		//	try			
		//	{
        //        //				string updateText = "UPDATE DMDSALESRF  SET UPDATEDATETIMERF=@UPDATEDATETIME , DEPOSITALLOWANCE=DEPOSITALLOWANCE + DF_DEPOSITALLOWANCE "
		//		string updateText = "UPDATE DMDSALESRF  SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2, DEPOSITALLOWANCERF=DEPOSITALLOWANCERF + @DF_DEPOSITALLOWANCE, DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF - @DF_DEPOSITALLOWANCE, MNYONDEPOALLOWANCERF = MNYONDEPOALLOWANCERF + @DF_MNYONDEPOALLOWANCE "
		//			+",CREDITALLOWANCERF=CREDITALLOWANCERF + @DF_CREDITALLOWANCE, CREDITALWCBLNCERF=CREDITALWCBLNCERF - @DF_CREDITALLOWANCE "					// 20060220 Ins クレジット引当
		//			+",ACPODRDEPOSITALWCRF=ACPODRDEPOSITALWCRF + @DF_ACPODRDEPOSITALWC, ACPODRDEPOALWCBLNCERF=ACPODRDEPOALWCBLNCERF - @DF_ACPODRDEPOSITALWC "	// 20060220 Ins 受注引当
		//			+",VARCOSTDEPOALWCRF=VARCOSTDEPOALWCRF + @DF_VARCOSTDEPOALWC, VARCOSTDEPOALWCBLNCERF=VARCOSTDEPOALWCBLNCERF - @DF_VARCOSTDEPOALWC "			// 20060220 Ins 諸費用引当
		//			+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND CLAIMCODERF=@FINDCLAIMCODE";
		//
		//		using(SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection,sqlTransaction))
		//		{
		//			//Prameterオブジェクトの作成
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
		//
		//			//Parameterオブジェクトへ値設定
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);	
		//			findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//
		//			#region Parameterオブジェクトの作成(更新用)
		//			//Parameterオブジェクトの作成(更新用)
		//			SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME",			SqlDbType.BigInt);	// 更新日
		//			SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE",			SqlDbType.NChar);
		//			SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1",			SqlDbType.NVarChar);
		//			SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2",			SqlDbType.NVarChar);
		//
		//			SqlParameter paraDF_DepositAllowance	= sqlCommand.Parameters.Add("@DF_DEPOSITALLOWANCE",		SqlDbType.BigInt);	// 引当差額
		//			SqlParameter paraDF_MnyOnDepoAllowance	= sqlCommand.Parameters.Add("@DF_MNYONDEPOALLOWANCE",	SqlDbType.BigInt);	// 預り金引当差額
		//			SqlParameter paraDF_CreditAllowance		= sqlCommand.Parameters.Add("@DF_CREDITALLOWANCE",		SqlDbType.BigInt);	// クレジット引当差額
		//			// 20020620 Ins Start >> 諸費用別入金対応>>>>>>>>>>>>
		//			SqlParameter paraDF_AcpOdrDepositAlwc	= sqlCommand.Parameters.Add("@DF_ACPODRDEPOSITALWC",	SqlDbType.BigInt);	// 受注引当差額
		//			SqlParameter paraDF_VarCostDepoAlwc		= sqlCommand.Parameters.Add("@DF_VARCOSTDEPOALWC",		SqlDbType.BigInt);	// 諸費用引当差額
		//			// 20020620 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//
		//			#endregion
		//
		//			#region Parameterオブジェクトへ値設定(更新用)
		//
		//			//預り金引当差額
		//			Int64 df_MnyOnDepoAllowance = 0;
		//
		//			if (bf_DepositCd == 1)
		//			{
		//				df_MnyOnDepoAllowance -= bf_DepositAllowance;
		//			}
		//			if(depositAlwWork.DepositCd == 1)
		//			{
		//				df_MnyOnDepoAllowance += depositAlwWork.DepositAllowance;
		//			}
		//
		//			paraDF_MnyOnDepoAllowance.Value = SqlDataMediator.SqlSetInt64(df_MnyOnDepoAllowance);
		//			
		//			// クレジット引当差額
		//			Int64 df_CreditAllowance = 0;
		//
		//			if (bf_CreditOrLoanCd > 0)
		//			{
		//				df_CreditAllowance -= bf_DepositAllowance;
		//			}
		//			if(af_CreditOrLoanCd > 0)
		//			{
		//				df_CreditAllowance += depositAlwWork.DepositAllowance;
		//			}
		//
		//			paraDF_CreditAllowance.Value = SqlDataMediator.SqlSetInt64(df_CreditAllowance);
		//
		//
		//			// ■更新ヘッダ情報を設定 
		//			object obj = (object)this;
		//			FileHeader fileHeader = new FileHeader(obj);
		//			paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(fileHeader.NewFileHeaderDateTime());			// 更新日
		//			paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdEmployeeCode);								// 更新従業員コード
		//			paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdAssemblyId1);								// 更新アセンブリID1
		//			paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(fileHeader.GetUpdAssemblyID(this));						// 更新アセンブリID2
		//			// ■変更情報を設定 
		//			paraDF_DepositAllowance.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance - bf_DepositAllowance);	// 引当差額
		//			paraDF_MnyOnDepoAllowance.Value = SqlDataMediator.SqlSetInt64(df_MnyOnDepoAllowance);									// 預り金引当差額
		//			paraDF_CreditAllowance.Value	= SqlDataMediator.SqlSetInt64(df_CreditAllowance);										// クレジット引当差額
		//			// 20020620 Ins Start >> 諸費用別入金対応>>>>>>>>>>>>
		//			paraDF_AcpOdrDepositAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc - bf_AcpOdrDepositAlwc);	// 受注引当差額
		//			paraDF_VarCostDepoAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc - bf_VarCostDepoAlwc);		// 諸費用引当差額
		//			// 20020620 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//			#endregion
		//
		//			int count = sqlCommand.ExecuteNonQuery();
		//
		//			// 更新件数が無い場合はすでに削除されている意味で排他を戻す
		//			if(count == 0)
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//
		//			}
		//			else
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//
		//		}
		//	
		//	}
		//	catch (SqlException ex) 
		//	{
		//		if(myReader != null && !myReader.IsClosed)myReader.Close();
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
		//}
        #endregion
        // ↑ 20070124 18322 c

        // ↓ 20070123 18322 d MA.NSでは受注マスタは使用しないので削除
        #region SF 受注マスタ情報を取得します（全てコメントアウト）
        ///// <summary>
		///// 受注マスタ情報を取得します
		///// </summary>
		///// <param name="EnterpriseCode">企業コード</param>
		///// <param name="AcceptAnOrderNo">受注番号</param>
		///// <param name="updAcceptOdrWork">受注情報ワーク（更新等に必要情報のみ）</param>
		///// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		///// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : 受注番号から受注情報を取得します（最低限必要な情報のみを専用クラスに取得）</br>
		///// <br>Programmer : 95089 徳永　誠</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>
		//private int ReadAcceptOdrWorkRec(string EnterpriseCode, int AcceptAnOrderNo, ref UpdAcceptOdrWork updAcceptOdrWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	updAcceptOdrWork = new UpdAcceptOdrWork();
		//
		//	try 
		//	{			
		//		//Selectコマンドの生成
		//		using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, DEPOSITALLOWANCETTLRF, MNYDEPOALLOWANCETTLRF, DEMANDPRORATACDRF, CLAIM1CODERF, CLAIM2CODERF, CLAIM3CODERF, CLAIM4CODERF, CLAIM5CODERF, DEPOSITALLOWANCE1RF, MNYONDEPOALLOWANCE1RF, DEPOSITALLOWANCE2RF, MNYONDEPOALLOWANCE2RF, DEPOSITALLOWANCE3RF, MNYONDEPOALLOWANCE3RF, DEPOSITALLOWANCE4RF, MNYONDEPOALLOWANCE4RF, DEPOSITALLOWANCE5RF, MNYONDEPOALLOWANCE5RF "
		//				  +"FROM ACCEPTODRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO", sqlConnection, sqlTransaction))
		//		{
		//
		//			// 必要項目のみ読み込む
		//
		//			//Prameterオブジェクトの作成
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//
		//			//Parameterオブジェクトへ値設定
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(AcceptAnOrderNo);
		//
		//			myReader = sqlCommand.ExecuteReader();
		//			if(myReader.Read())
		//			{
		//
		//				#region クラスへ代入
		//				updAcceptOdrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
		//				updAcceptOdrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
		//				updAcceptOdrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
		//				updAcceptOdrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//				updAcceptOdrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//				updAcceptOdrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//				updAcceptOdrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//				updAcceptOdrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
		//				updAcceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
		//				updAcceptOdrWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
		//				updAcceptOdrWork.MnyDepoAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYDEPOALLOWANCETTLRF"));
		//				updAcceptOdrWork.DemandProRataCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEMANDPRORATACDRF"));
		//				updAcceptOdrWork.Claim1Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM1CODERF"));
		//				updAcceptOdrWork.Claim2Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM2CODERF"));
		//				updAcceptOdrWork.Claim3Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM3CODERF"));
		//				updAcceptOdrWork.Claim4Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM4CODERF"));
		//				updAcceptOdrWork.Claim5Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM5CODERF"));
		//				updAcceptOdrWork.DepositAllowance1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE1RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE1RF"));
		//				updAcceptOdrWork.DepositAllowance2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE2RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE2RF"));
		//				updAcceptOdrWork.DepositAllowance3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE3RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE3RF"));
		//				updAcceptOdrWork.DepositAllowance4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE4RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE4RF"));
		//				updAcceptOdrWork.DepositAllowance5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE5RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE5RF"));
		//				#endregion
		//
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	 if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
        //}
        #endregion
        // ↑ 20070124 18322 d

        // ↓ 20070124 18322 d MA.NSでは受注マスタは使用しないので削除
        #region SF 受注マスタ情報（引当部）を更新・更新用受注ワーク引当額計算処理は、MA.NSでは使用しないので削除（全てコメントアウト）
        ///// <summary>
		///// 受注マスタ情報（引当部）を更新します
		///// </summary>
		///// <param name="updAcceptOdrWork">受注情報ワーク（更新等に必要情報のみ）</param>
		///// <param name="sqlConnection"></param>
		///// <param name="sqlTransaction"></param>
		///// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		///// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : 受注情報中、引当情報のみを更新します）</br>
		///// <br>Programmer : 95089 徳永　誠</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>
		//private int WriteAcceptOdrWorkRec(ref UpdAcceptOdrWork updAcceptOdrWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	// Updateコマンドの生成
		//	try			
		//	{
		//		// 更新日を更新検索キーに付加して更新（日付排他処理）
		//		string updateText = "UPDATE ACCEPTODRRF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , ACCEPTANORDERNORF=@ACCEPTANORDERNO , DEPOSITALLOWANCETTLRF=@DEPOSITALLOWANCETTL , MNYDEPOALLOWANCETTLRF=@MNYDEPOALLOWANCETTL , DEPOSITALLOWANCE1RF=@DEPOSITALLOWANCE1 , MNYONDEPOALLOWANCE1RF=@MNYONDEPOALLOWANCE1 , DEPOSITALLOWANCE2RF=@DEPOSITALLOWANCE2 , MNYONDEPOALLOWANCE2RF=@MNYONDEPOALLOWANCE2 , DEPOSITALLOWANCE3RF=@DEPOSITALLOWANCE3 , MNYONDEPOALLOWANCE3RF=@MNYONDEPOALLOWANCE3 , DEPOSITALLOWANCE4RF=@DEPOSITALLOWANCE4 , MNYONDEPOALLOWANCE4RF=@MNYONDEPOALLOWANCE4 , DEPOSITALLOWANCE5RF=@DEPOSITALLOWANCE5 , MNYONDEPOALLOWANCE5RF=@MNYONDEPOALLOWANCE5, EXCLUSIVEDEPOALWDATERF=@EXCLUSIVEDEPOALWDATE "
		//			+"WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO";
		//
		//		using(SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection,sqlTransaction))
		//		{
		//			//Prameterオブジェクトの作成
		//			//Parameterオブジェクトの作成(検索用)
		//			SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//
		//			//Parameterオブジェクトへ値設定
		//			findParaUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(updAcceptOdrWork.UpdateDateTime);
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(updAcceptOdrWork.AcceptAnOrderNo);	
		//
		//			//更新ヘッダ情報を設定
		//			object obj = (object)this;
		//			IFileHeader flhd = (IFileHeader)updAcceptOdrWork;
		//			FileHeader fileHeader = new FileHeader(obj);
		//			fileHeader.SetUpdateHeader(ref flhd,obj);
		//
		//			// 排他用日付の設定(排他用入金引当更新日 ← 更新日)
		//			updAcceptOdrWork.ExclusiveDepoAlwDate = updAcceptOdrWork.UpdateDateTime;
		//
		//			#region Parameterオブジェクトの作成(更新用)
		//
		//			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
		//			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
		//			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
		//			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
		//			SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter paraDepositAllowanceTtl = sqlCommand.Parameters.Add("@DEPOSITALLOWANCETTL", SqlDbType.BigInt);
		//			SqlParameter paraMnyDepoAllowanceTtl = sqlCommand.Parameters.Add("@MNYDEPOALLOWANCETTL", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance1 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE1", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance1 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE1", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance2 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE2", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance2 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE2", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance3 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE3", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance3 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE3", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance4 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE4", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance4 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE4", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance5 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE5", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance5 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE5", SqlDbType.BigInt);
		//			SqlParameter paraExclusiveDepoAlwDate = sqlCommand.Parameters.Add("@EXCLUSIVEDEPOALWDATE", SqlDbType.BigInt);
		//			#endregion
		//
		//			#region Parameterオブジェクトへ値設定(更新用)
		//			paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updAcceptOdrWork.UpdateDateTime);
		//			paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updAcceptOdrWork.FileHeaderGuid);
		//			paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.UpdEmployeeCode);
		//			paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.UpdAssemblyId1);
		//			paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.UpdAssemblyId2);
		//			paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(updAcceptOdrWork.AcceptAnOrderNo);
		//			paraDepositAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowanceTtl);
		//			paraMnyDepoAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyDepoAllowanceTtl);
		//			paraDepositAllowance1.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance1);
		//			paraMnyOnDepoAllowance1.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance1);
		//			paraDepositAllowance2.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance2);
		//			paraMnyOnDepoAllowance2.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance2);
		//			paraDepositAllowance3.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance3);
		//			paraMnyOnDepoAllowance3.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance3);
		//			paraDepositAllowance4.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance4);
		//			paraMnyOnDepoAllowance4.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance4);
		//			paraDepositAllowance5.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance5);
		//			paraMnyOnDepoAllowance5.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance5);
		//			paraExclusiveDepoAlwDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updAcceptOdrWork.ExclusiveDepoAlwDate);
		//			#endregion
		//
		//			int count = sqlCommand.ExecuteNonQuery();
		//
		//			// 更新時：更新件数が無い場合は他PGでの更新／削除されている意味で排他を戻す
		//			if(count == 0)
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//
		//			}
		//			else
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//
		//		}
		//	
		//	}
		//	catch (SqlException ex) 
		//	{
		//		if(myReader != null && !myReader.IsClosed)myReader.Close();
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
		//}
		//
		///// <summary>
		///// 更新用受注ワーク引当額計算処理
		///// </summary>
		///// <param name="CustomerCode">得意先コード</param>
		///// <param name="depositAlwWork">入金引当情報</param>
		///// <param name="updAcceptOdrWork">受注情報ワーク</param>
		///// <param name="bf_DepositAllowance">更新前引当額</param>
		///// <param name="bf_DepositCd">更新前預り金区分</param>
		///// <param name="bf_CreditOrLoanCd">更新前クレジット／ローン区分</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : 入金引当マスタ情報等から受注情報ワークの引当額を計算します</br>
		///// <br>           : (請求先がどの位置にあるか算定して計算)</br>
		///// <br>Programmer : 95089 徳永　誠</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>	
		//private int CalcAcceptOdrWorkRec(int CustomerCode, DepositAlwWork depositAlwWork, ref UpdAcceptOdrWork updAcceptOdrWork, Int64 bf_DepositAllowance, int bf_DepositCd, int bf_CreditOrLoanCd)
		//{
		//	Int64 DepositAllowance = 0;			// 入金引当額(請求先別)
		//	Int64 MnyOnDepoAllowance = 0;		// 預り金引当額(請求先別)
		//
		//	if(CustomerCode == updAcceptOdrWork.Claim1Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance1;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance1;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim2Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance2;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance2;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim3Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance3;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance3;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim4Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance4;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance4;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim5Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance5;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance5;
		//	}
		//	else
		//	{
		//		// 請求先が無い場合は排他を返す
		//		return (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//	}
		//
		//	// 入金引当額計算
		//	DepositAllowance					 = DepositAllowance - bf_DepositAllowance + depositAlwWork.DepositAllowance;
		//	updAcceptOdrWork.DepositAllowanceTtl = updAcceptOdrWork.DepositAllowanceTtl - bf_DepositAllowance + depositAlwWork.DepositAllowance;
		//
		//	//預り金引当額計算
		//	if (bf_DepositCd == 1)
		//	{
		//		MnyOnDepoAllowance					 -= bf_DepositAllowance;
		//		updAcceptOdrWork.MnyDepoAllowanceTtl -= bf_DepositAllowance;
		//	}
		//	if(depositAlwWork.DepositCd == 1)
		//	{
		//		MnyOnDepoAllowance					 += depositAlwWork.DepositAllowance;
		//		updAcceptOdrWork.MnyDepoAllowanceTtl += depositAlwWork.DepositAllowance;
		//	}
		//
		//	// 請求先別引当額セット
		//	if(CustomerCode == updAcceptOdrWork.Claim1Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance1 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance1 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim2Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance2 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance2 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim3Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance3 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance3 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim4Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance4 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance4 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim5Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance5 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance5 = MnyOnDepoAllowance;
		//	}
		//
		//	return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        #endregion
        // ↑ 20070124 18322 d

        // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 赤入金情報生成処理（全てコメントアウト）
        ///// <summary>
		///// 赤入金情報生成処理
		///// </summary>
		///// <param name="DepositCd">預り金区分</param>
		///// <param name="UpdateSecCd">更新拠点</param>
		///// <param name="DepositAgentCode">赤入金担当者</param>
		///// <param name="AddUpADate">赤入金計上日</param>
		///// <param name="depsitMainWork">元黒入金情報</param>
		///// <returns>赤入金情報</returns>
		//public DepsitMainWork CreateRedDepsitProc(int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, DepsitMainWork depsitMainWork)
		//{
		//	DepsitMainWork newDepsitMainWork = new DepsitMainWork();
		//
        //    //			newDepsitMainWork.CreateDateTime = depsitMainWork.CreateDateTime;
		//	//			newDepsitMainWork.UpdateDateTime = depsitMainWork.UpdateDateTime;
		//	newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
		//	//			newDepsitMainWork.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
		//	newDepsitMainWork.UpdEmployeeCode = DepositAgentCode;							// 更新従業員コード<-入金担当者コード ???
		//	newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
		//	newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
		//	newDepsitMainWork.LogicalDeleteCode = 0;
		//	newDepsitMainWork.DepositDebitNoteCd = 1;										// 赤黒区分＝１：赤
		//	newDepsitMainWork.DepositSlipNo = 0;											// 入金番号
		//	newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;				// 金種コード
		//	newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;					// 得意先コード
		//	newDepsitMainWork.DepositCd = DepositCd;										// 預り金区分
		//	newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal * -1;				// 入金計
		//	newDepsitMainWork.Outline = depsitMainWork.Outline;								// 摘要
		//	newDepsitMainWork.AcceptAnOrderSalesNo = depsitMainWork.AcceptAnOrderSalesNo;	// 売上げ受注番号
		//	newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;			// 入金入力拠点
		//	newDepsitMainWork.DepositDate = AddUpADate;										// 入金日付???
		//	newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;					// 計上拠点コード
		//	newDepsitMainWork.AddUpADate = AddUpADate;										// 計上日付???
		//	newDepsitMainWork.UpdateSecCd = UpdateSecCd;									// 更新拠点コード???
		//	newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;				// 入金金種名称
		//	newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance * -1;		// 入金引当額
		//	newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce * -1;		// 入金引当残額
		//	newDepsitMainWork.DepositAgentCode = DepositAgentCode;							// 入金担当者コード？？
		//	newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;			// 入金金種区分
		//	newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit * -1;					// 手数料入金額
		//	newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit * -1;		// 値引入金額
		//	newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;				// クレジット／ローン区分
		//	newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;			// クレジット会社コード
		//	newDepsitMainWork.Deposit = depsitMainWork.Deposit * -1;						// 入金金額
		//	newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;			// 手形振出日
		//	newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;			// 手形支払期日
		//	newDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DepositSlipNo;			// 赤黒入金連結番号　(元黒入金番号をセット)
		//	newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;						// 最終消し込み形状日←一旦無し
		//	newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;					// 自動入金区分
		//	// 20060220 Ins Start >>>>>>>>>>>>>>>
		//	newDepsitMainWork.AcpOdrDeposit = depsitMainWork.AcpOdrDeposit * -1;			// 受注入金金額
		//	newDepsitMainWork.AcpOdrChargeDeposit = depsitMainWork.AcpOdrChargeDeposit * -1;// 受注手数料入金額
		//	newDepsitMainWork.AcpOdrDisDeposit = depsitMainWork.AcpOdrDisDeposit * -1;		// 受注値引入金額
		//	newDepsitMainWork.VariousCostDeposit = depsitMainWork.VariousCostDeposit * - 1; // 諸費用入金金額
		//	newDepsitMainWork.VarCostChargeDeposit = depsitMainWork.VarCostChargeDeposit * -1;	// 諸費用手数料入金額
		//	newDepsitMainWork.VarCostDisDeposit = depsitMainWork.VarCostDisDeposit * -1;	// 諸費用値引入金額
		//	newDepsitMainWork.AcpOdrDepositAlwc = depsitMainWork.AcpOdrDepositAlwc * -1;	// 受注入金引当額
		//	newDepsitMainWork.AcpOdrDepoAlwcBlnce = depsitMainWork.AcpOdrDepoAlwcBlnce * -1;// 受注入金引当残高
		//	newDepsitMainWork.VarCostDepoAlwc = depsitMainWork.VarCostDepoAlwc * -1;		// 諸費用入金引当額
		//	newDepsitMainWork.VarCostDepoAlwcBlnce = depsitMainWork.VarCostDepoAlwcBlnce * -1; // 諸費用入金引当残高
        //    // 20060220 Ins End <<<<<<<<<<<<<<<<
		//
        //    return newDepsitMainWork;
        //}
        #endregion
        // ↑ 20070124 18322 c

        // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 赤入金引当情報生成処理（全てコメントアウト）
        ///// <summary>
		///// 赤入金引当情報生成処理
		///// </summary>
		///// <param name="DepositCd">預り金区分</param>
		///// <param name="UpdateSecCd">更新拠点</param>
		///// <param name="DepositAgentCode">赤入金担当者</param>
		///// <param name="AddUpADate">赤入金計上日</param>
		///// <param name="depositAlwWorkList">元黒入金引当情報</param>
		///// <returns>赤入金引当情報</returns>
		//DepositAlwWork[] CreateRedDepositAlwWorkProc(int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, DepositAlwWork[] depositAlwWorkList)
		//{
		//	ArrayList newDepositAlwWorkList = new ArrayList();
		//	
		//	for(int ix=0; ix < depositAlwWorkList.Length; ix++)
		//	{
		//		DepositAlwWork newDepositAlwWork = new DepositAlwWork();
		//		//				newDepositAlwWork.CreateDateTime = depositAlwWorkList[ix].CreateDateTime;
		//		//				newDepositAlwWork.UpdateDateTime = depositAlwWorkList[ix].UpdateDateTime;
		//		newDepositAlwWork.EnterpriseCode = depositAlwWorkList[ix].EnterpriseCode;
		//		//				newDepositAlwWork.FileHeaderGuid = depositAlwWorkList[ix].FileHeaderGuid;
		//		newDepositAlwWork.UpdEmployeeCode = DepositAgentCode;										// 更新従業員コード<-入金担当者コード ???
		//		//				newDepositAlwWork.UpdAssemblyId1 = depositAlwWorkList[ix].UpdAssemblyId1;
		//		//				newDepositAlwWork.UpdAssemblyId2 = depositAlwWorkList[ix].UpdAssemblyId2;
		//		newDepositAlwWork.LogicalDeleteCode = 0;
		//		newDepositAlwWork.CustomerCode = depositAlwWorkList[ix].CustomerCode;
		//		newDepositAlwWork.AddUpSecCode = depositAlwWorkList[ix].AddUpSecCode;
		//		newDepositAlwWork.AcceptAnOrderNo = depositAlwWorkList[ix].AcceptAnOrderNo;
		//		newDepositAlwWork.DepositSlipNo = 0;														// 入金伝票番号
		//		newDepositAlwWork.DepositKindCode = depositAlwWorkList[ix].DepositKindCode;
		//		newDepositAlwWork.DepositInputDate = AddUpADate;											// 入金入力日付
		//		newDepositAlwWork.DepositAllowance = depositAlwWorkList[ix].DepositAllowance * -1;			// 引当額
		//		newDepositAlwWork.ReconcileDate = DateTime.Now;												// 消込み日←システム日付
		//		newDepositAlwWork.ReconcileAddUpDate = AddUpADate;											// 消込み計上日←入金計上日
		//		newDepositAlwWork.DebitNoteOffSetCd = 1;													// 赤伝相殺区分 1:赤
		//		newDepositAlwWork.DepositCd = DepositCd;													// 預り金区分←パラメータ値
		//		newDepositAlwWork.CreditOrLoanCd = depositAlwWorkList[ix].CreditOrLoanCd;
		//		// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		//		newDepositAlwWork.AcpOdrDepositAlwc = depositAlwWorkList[ix].AcpOdrDepositAlwc * -1;		// 受注引当額
		//		newDepositAlwWork.VarCostDepoAlwc	= depositAlwWorkList[ix].VarCostDepoAlwc * -1;			// 諸費用引当額
		//		// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//
		//
		//		newDepositAlwWorkList.Add(newDepositAlwWork);
		//	}
		//
		//	return (DepositAlwWork[])newDepositAlwWorkList.ToArray(typeof(DepositAlwWork));
        //}
        #endregion
        // ↑ 20070124 18322 c

        // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 新黒入金情報生成処理（全てコメントアウト）
        ///// <summary>
		///// 新黒入金情報生成処理
		///// </summary>
		///// <param name="UpdateSecCd">更新拠点</param>
		///// <param name="DepositAgentCode">入金担当者</param>
		///// <param name="AddUpADate">入金計上日</param>
		///// <param name="depsitMainWork">元黒入金情報</param>
		///// <returns>新黒入金情報</returns>
		//public DepsitMainWork CreateNewBlackDepsitProc(string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, DepsitMainWork depsitMainWork)
		//{
		//	DepsitMainWork newDepsitMainWork = new DepsitMainWork();
		//
		//	//			newDepsitMainWork.CreateDateTime = depsitMainWork.CreateDateTime;
		//	//			newDepsitMainWork.UpdateDateTime = depsitMainWork.UpdateDateTime;
		//	newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
		//	//			newDepsitMainWork.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
		//	newDepsitMainWork.UpdEmployeeCode = UpdateSecCd;								// 更新従業員コード<-入金担当者コード ???
		//	newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
		//	newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
		//	newDepsitMainWork.LogicalDeleteCode = 0;
		//	newDepsitMainWork.DepositDebitNoteCd = 0;										// 赤黒区分＝０：黒
		//	newDepsitMainWork.DepositSlipNo = 0;											// 入金番号
		//	newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;				// 金種コード
		//	newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;					// 得意先コード
		//	newDepsitMainWork.DepositCd = depsitMainWork.DepositCd;							// 預り金区分
		//	newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;					// 入金計
		//	newDepsitMainWork.Outline = depsitMainWork.Outline;								// 摘要
		//	newDepsitMainWork.AcceptAnOrderSalesNo = depsitMainWork.AcceptAnOrderSalesNo;	// 売上げ受注番号
		//	newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;			// 入金入力拠点
		//	newDepsitMainWork.DepositDate = AddUpADate;										// 入金日付???
		//	newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;					// 計上拠点コード
		//	newDepsitMainWork.AddUpADate = AddUpADate;										// 計上日付???
		//	newDepsitMainWork.UpdateSecCd = UpdateSecCd;									// 更新拠点コード???
		//	newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;				// 入金金種名称
		//	newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;			// 入金引当額
		//	newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;			// 入金引当残額
		//	newDepsitMainWork.DepositAgentCode = DepositAgentCode;							// 入金担当者コード？？
		//	newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;			// 入金金種区分
		//	newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;						// 手数料入金額
		//	newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;				// 値引入金額
		//	newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;				// クレジット／ローン区分
		//	newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;			// クレジット会社コード
		//	newDepsitMainWork.Deposit = depsitMainWork.Deposit;								// 入金金額
		//	newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;			// 手形振出日
		//	newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;			// 手形支払期日
		//	newDepsitMainWork.DebitNoteLinkDepoNo = 0;										// 赤黒入金連結番号　(なし)
		//	newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;						// 最終消し込み形状日 ←一旦無し
		//	newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;					// 自動入金区分
		//	// 20060220 Ins Start >>>>>>>>>>>>>>>
		//	newDepsitMainWork.AcpOdrDeposit = depsitMainWork.AcpOdrDeposit;					// 受注入金金額
		//	newDepsitMainWork.AcpOdrChargeDeposit = depsitMainWork.AcpOdrChargeDeposit;		// 受注手数料入金額
		//	newDepsitMainWork.AcpOdrDisDeposit = depsitMainWork.AcpOdrDisDeposit;			// 受注値引入金額
		//	newDepsitMainWork.VariousCostDeposit = depsitMainWork.VariousCostDeposit;		// 諸費用入金金額
		//	newDepsitMainWork.VarCostChargeDeposit = depsitMainWork.VarCostChargeDeposit;	// 諸費用手数料入金額
		//	newDepsitMainWork.VarCostDisDeposit = depsitMainWork.VarCostDisDeposit;			// 諸費用値引入金額
		//	newDepsitMainWork.AcpOdrDepositAlwc = depsitMainWork.AcpOdrDepositAlwc;			// 受注入金引当額
		//	newDepsitMainWork.AcpOdrDepoAlwcBlnce = depsitMainWork.AcpOdrDepoAlwcBlnce;		// 受注入金引当残高
		//	newDepsitMainWork.VarCostDepoAlwc = depsitMainWork.VarCostDepoAlwc;				// 諸費用入金引当額
		//	newDepsitMainWork.VarCostDepoAlwcBlnce = depsitMainWork.VarCostDepoAlwcBlnce;	// 諸費用入金引当残高
		//	// 20060220 Ins End <<<<<<<<<<<<<<<<
		//
		//
		//	return newDepsitMainWork;
        //}
        #endregion
        // ↑ 20070124 18322 c

        // ↓ 20070518 18322 d いらないので削除
        #region 請求売上マスタ情報を取得します(テスト用仮ロジック) 削除
        ///// <summary>
        ///// 請求売上マスタ情報を取得します(テスト用仮ロジック)
        ///// </summary>
        ///// <param name="EnterpriseCode">企業コード</param>
        ///// <param name="ClaimCode">請求先コード</param>
        ///// <param name="salesSlipWorkList">売上データ（請求売上データ）</param>
        ///// <param name="sqlConnection">コネクション情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <returns>新黒入金情報</returns>
        //// ↓ 20070123 18322 c MA.NS用に変更（MA.NSでは、請求売上データの変わりに売上データを使用）
		////private int ReadDmdSalesWorkRec(string EnterpriseCode, int ClaimCode, out DmdSalesWork[] DmdSalesWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //
		//private int ReadDmdSalesWorkRec(string EnterpriseCode, int ClaimCode, out SalesSlipWork[] salesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //// ↑ 20070123 18322 c
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	    //
		//	SqlDataReader myReader = null;
        //
        //    ArrayList dmdSalesWorkArrayList = new ArrayList();
        //
		//	try 
		//	{
        //        // ↓ 20070126 18322 c MA.NS用に変更
        //        #region SF 請求売上マスタ SELECT文（コメントアウト）
        //        ////Selectコマンドの生成
		//		//using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SLIPNORF, DEBITNOTEDIVRF, CUSTOMERCODERF, CARMNGNORF, CLAIMCODERF, ADDUPADATERF, ACCEPTANORDERSALESRF, ACPTANODRDISCOUNTTTLRF, ACCEPTANORDERCONSTAXRF, TOTALVARIOUSCOSTRF, VARCSTTAXTOTALRF, VARCSTTAXFREETOTALRF, VARCST1RF, VARCST2RF, VARCST3RF, VARCST4RF, VARCST5RF, VARCST6RF, VARCST7RF, VARCST8RF, VARCST9RF, VARCST10RF, VARCST11RF, VARCST12RF, VARCST13RF, VARCST14RF, VARCST15RF, VARCST16RF, VARCST17RF, VARCST18RF, VARCST19RF, VARCST20RF, VARCSTDIV1RF, VARCSTDIV2RF, VARCSTDIV3RF, VARCSTDIV4RF, VARCSTDIV5RF, VARCSTDIV6RF, VARCSTDIV7RF, VARCSTDIV8RF, VARCSTDIV9RF, VARCSTDIV10RF, VARCSTDIV11RF, VARCSTDIV12RF, VARCSTDIV13RF, VARCSTDIV14RF, VARCSTDIV15RF, VARCSTDIV16RF, VARCSTDIV17RF, VARCSTDIV18RF, VARCSTDIV19RF, VARCSTDIV20RF, VARCSTCONSTAXRF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DATAINPUTSYSTEMRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, ACCEPTANORDERDATERF, CARDELIEXPECTEDDATERF, SALESEMPLOYEECDRF, SALESDIVRF, SALESNAMERF, DEBITNLNKACPTANODRRF, DEMANDPRORATACDRF, LASTRECONCILEDATERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MAKERNAMERF, MODELNAMERF, DEMANDABLESALESNOTERF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, CREDITSALESRF, CREDITALLOWANCERF, CREDITALWCBLNCERF, CORPORATEDIVCODERF, AACOUNTRF, MNYONDEPOALLOWANCERF, ACPTANODRSTATUSRF, LASTRECONCILEADDUPDTRF, CARINSPECTORGECDRF, GRADENAMERF "
		//		//		  +"FROM DMDSALESRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCLAIMCODE", sqlConnection, sqlTransaction))
        //        #endregion
        //
        //        #region 売上データ SELECT文
        //        string selectSql = "SELECT CREATEDATETIMERF"
        //                         +       ",UPDATEDATETIMERF"
        //                         +       ",ENTERPRISECODERF"
        //                         +       ",FILEHEADERGUIDRF"
        //                         +       ",UPDEMPLOYEECODERF"
        //                         +       ",UPDASSEMBLYID1RF"
        //                         +       ",UPDASSEMBLYID2RF"
        //                         +       ",LOGICALDELETECODERF"
        //                         +       ",ACCEPTANORDERNORF"
        //                         +       ",ACPTANODRSTATUSRF"
        //                         +       ",SALESSLIPNUMRF"
        //                         +       ",ACPTANODRSLIPNUMRF"
        //                         +       ",ESTIMATESLIPNORF"
        //                         +       ",DEBITNOTEDIVRF"
        //                         +       ",DEBITNLNKACPTANODRRF"
        //                         +       ",SALESSLIPCDRF"
        //                         +       ",SALESFORMALRF"
        //                         +       ",SALESINPSECCDRF"
        //                         +       ",DEMANDADDUPSECCDRF"
        //                         +       ",RESULTSADDUPSECCDRF"
        //                         +       ",UPDATESECCDRF"
        //                         +       ",SEARCHSLIPDATERF"
        //                         +       ",ESTIMATEDATERF"
        //                         +       ",ACCEPTANORDERDATERF"
        //                         +       ",DELIGDSCMPLTDUEDATERF"
        //                         +       ",SHIPMENTDAYRF"
        //                         +       ",SALESDATERF"
        //                         +       ",ADDUPADATERF"
        //                         +       ",FRONTEMPLOYEECDRF"
        //                         +       ",FRONTEMPLOYEENMRF"
        //                         +       ",SALESEMPLOYEECDRF"
        //                         +       ",SALESEMPLOYEENMRF"
        //                         +       ",WAYTOORDERRF"
        //                         +       ",SALESSUBTOTALRF"
        //                         +       ",SALSUBTTLSUBTOOUTTAXRF"
        //                         +       ",SALSUBTTLSUBTOINTAXRF"
        //                         +       ",SALSUBTTLSUBTOTAXFRERF"
        //                         +       ",SALSUBTOTALOUTTAXRF"
        //                         +       ",SALSUBTOTALINTAXRF"
        //                         +       ",TOTALDISCOUNTRF"
        //                         +       ",TOTALDISSUBTOOUTTAXRF"
        //                         +       ",TOTALDISSUBTOINTAXRF"
        //                         +       ",TOTALDISSUBTOTAXFREERF"
        //                         +       ",TOTALDISCOUNTOUTTAXRF"
        //                         +       ",TOTALDISCOUNTINTAXRF"
        //                         +       ",TOTALCARRIERDISCOUNTRF"
        //                         +       ",TTLCDISSUBTOOUTTAXRF"
        //                         +       ",TTLCDISSUBTOINTAXRF"
        //                         +       ",TTLCDISSUBTOTAXFREERF"
        //                         +       ",TTLCDISCOUNTOUTTAXRF"
        //                         +       ",TTLCDISCOUNTINTAXRF"
        //                         +       ",TOTALSTDISCOUNTRF"
        //                         +       ",TTLSTDISSUBTOOUTTAXRF"
        //                         +       ",TTLSTDISSUBTOINTAXRF"
        //                         +       ",TTLSTDISSUBTOTAXFREERF"
        //                         +       ",TTLSTDISCOUNTOUTTAXRF"
        //                         +       ",TTLSTDISCOUNTINTAXRF"
        //                         +       ",TTLSTCARRDISCOUNTRF"
        //                         +       ",TTLSTCDISSUBTOOUTTAXRF"
        //                         +       ",TTLSTCDISSUBTOINTAXRF"
        //                         +       ",TTLSTCDISSUBTOTAXFRERF"
        //                         +       ",TTLSTCDISCOUNTOUTTAXRF"
        //                         +       ",TTLSTCDISCOUNTINTAXRF"
        //                         +       ",TOTALSALESMONEYRF"
        //                         +       ",TTLITDEDSALESOUTTAXRF"
        //                         +       ",TTLITDEDSALESINTAXRF"
        //                         +       ",TTLITDEDSALESTAXFREERF"
        //                         +       ",TOTALSALESOUTTAXRF"
        //                         +       ",TOTALSALESINTAXRF"
        //                         +       ",TOTALCOSTRF"
        //                         +       ",TTLITDEDCOSTOUTTAXRF"
        //                         +       ",TTLITDEDCOSTINTAXRF"
        //                         +       ",TTLITDEDTAXFREERF"
        //                         +       ",TOTALCOSTOUTERTAXRF"
        //                         +       ",TOTALCOSTINNERTAXRF"
        //                         +       ",TTLINCENTIVERECVRF"
        //                         +       ",TTLITDINCRECVOUTTAXRF"
        //                         +       ",TTLITDINCRECVINTAXRF"
        //                         +       ",TTLITDINCRECVTAXFREERF"
        //                         +       ",TOTALINCRECVOUTTAXRF"
        //                         +       ",TOTALINCRECVINTAXRF"
        //                         +       ",TTLINCENTIVEDTBTRF"
        //                         +       ",TTLITDINCDTBTOUTTAXRF"
        //                         +       ",TTLITDINCDTBTINTAXRF"
        //                         +       ",TTLITDINCDTBTTAXFREERF"
        //                         +       ",TOTALINCDTBTOUTTAXRF"
        //                         +       ",TOTALINCDTBTINTAXRF"
        //                         +       ",CONSTAXLAYMETHODRF"
        //                         +       ",CONSTAXRATERF"
        //                         +       ",FRACTIONPROCCDRF"
        //                         +       ",ACCRECDIVCDRF"
        //                         +       ",AUTODEPOSITCDRF"
        //                         +       ",DEMANDABLETTLRF"
        //                         +       ",DEPOSITALLOWANCETTLRF"
        //                         +       ",MNYDEPOALLOWANCETTLRF"
        //                         +       ",DEPOSITALWCBLNCERF"
        //                         +       ",CLAIMCODERF"
        //                         +       ",CLAIMNAME1RF"
        //                         +       ",CLAIMNAME2RF"
        //                         +       ",CUSTOMERCODERF"
        //                         +       ",CUSTOMERNAMERF"
        //                         +       ",CUSTOMERNAME2RF"
        //                         +       ",HONORIFICTITLERF"
        //                         +       ",KANARF"
        //                         +       ",SEXCODERF"
        //                         +       ",CORPORATEDIVCODERF"
        //                         +       ",GENERATIONCODERF"
        //                         +       ",CLIENTELECODERF"
        //                         +       ",RETGOODSREASONRF"
        //                         +       ",ADDRESSEECODERF"
        //                         +       ",ADDRESSEENAMERF"
        //                         +       ",ADDRESSEENAME2RF"
        //                         +       ",ADDRESSEEADDR1RF"
        //                         +       ",ADDRESSEEADDR2RF"
        //                         +       ",ADDRESSEEADDR3RF"
        //                         +       ",ADDRESSEEADDR4RF"
        //                         +       ",ADDRESSEETELNORF"
        //                         +       ",PARTYSALESLIPNUMRF"
        //                         +       ",SLIPNOTERF"
        //                         +  " FROM SALESSLIPRF"
        //                         + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
        //                         +   " AND CLAIMCODERF=@FINDCLAIMCODE"
        //                         ;
        //        #endregion
        //        using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
        //        // ↑ 20070126 18322 c
		//		{
        //
		//			//Prameterオブジェクトの作成
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
        //
		//			//Parameterオブジェクトへ値設定
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
		//			findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(ClaimCode);
        //
		//			myReader = sqlCommand.ExecuteReader();
		//			while(myReader.Read())
		//			{
        //                // ↓ 20070123 18322 c MA.NS用に変更
        //                #region SF 請求売上データへSQLデータを代入（全てコメントアウト）
        //                //DmdSalesWork dmdSalesWork = new DmdSalesWork();
        //                //
		//				//#region クラスへ代入
		//				//dmdSalesWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
		//				//dmdSalesWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
		//				//dmdSalesWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
		//				//dmdSalesWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//				//dmdSalesWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//				//dmdSalesWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//				//dmdSalesWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//				//dmdSalesWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
		//				//dmdSalesWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
		//				//dmdSalesWork.SlipNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SLIPNORF"));
		//				//dmdSalesWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
		//				//dmdSalesWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
		//				//dmdSalesWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARMNGNORF"));
		//				//dmdSalesWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIMCODERF"));
		//				//dmdSalesWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
		//				//dmdSalesWork.AcceptAnOrderSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESRF"));
		//				//dmdSalesWork.AcptAnOdrDiscountTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPTANODRDISCOUNTTTLRF"));
		//				//dmdSalesWork.AcceptAnOrderConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERCONSTAXRF"));
		//				//dmdSalesWork.TotalVariousCost = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("TOTALVARIOUSCOSTRF"));
		//				//dmdSalesWork.VarCstTaxTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXTOTALRF"));
		//				//dmdSalesWork.VarCstTaxFreeTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXFREETOTALRF"));
		//				//dmdSalesWork.VarCst1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST1RF"));
		//				//dmdSalesWork.VarCst2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST2RF"));
		//				//dmdSalesWork.VarCst3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST3RF"));
		//				//dmdSalesWork.VarCst4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST4RF"));
		//				//dmdSalesWork.VarCst5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST5RF"));
		//				//dmdSalesWork.VarCst6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST6RF"));
		//				//dmdSalesWork.VarCst7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST7RF"));
		//				//dmdSalesWork.VarCst8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST8RF"));
		//				//dmdSalesWork.VarCst9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST9RF"));
		//				//dmdSalesWork.VarCst10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST10RF"));
		//				//dmdSalesWork.VarCst11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST11RF"));
		//				//dmdSalesWork.VarCst12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST12RF"));
		//				//dmdSalesWork.VarCst13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST13RF"));
		//				//dmdSalesWork.VarCst14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST14RF"));
		//				//dmdSalesWork.VarCst15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST15RF"));
		//				//dmdSalesWork.VarCst16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST16RF"));
		//				//dmdSalesWork.VarCst17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST17RF"));
		//				//dmdSalesWork.VarCst18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST18RF"));
		//				//dmdSalesWork.VarCst19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST19RF"));
		//				//dmdSalesWork.VarCst20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST20RF"));
		//				//dmdSalesWork.VarCstDiv1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV1RF"));
		//				//dmdSalesWork.VarCstDiv2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV2RF"));
		//				//dmdSalesWork.VarCstDiv3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV3RF"));
		//				//dmdSalesWork.VarCstDiv4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV4RF"));
		//				//dmdSalesWork.VarCstDiv5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV5RF"));
		//				//dmdSalesWork.VarCstDiv6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV6RF"));
		//				//dmdSalesWork.VarCstDiv7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV7RF"));
		//				//dmdSalesWork.VarCstDiv8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV8RF"));
		//				//dmdSalesWork.VarCstDiv9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV9RF"));
		//				//dmdSalesWork.VarCstDiv10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV10RF"));
		//				//dmdSalesWork.VarCstDiv11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV11RF"));
		//				//dmdSalesWork.VarCstDiv12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV12RF"));
		//				//dmdSalesWork.VarCstDiv13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV13RF"));
		//				//dmdSalesWork.VarCstDiv14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV14RF"));
		//				//dmdSalesWork.VarCstDiv15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV15RF"));
		//				//dmdSalesWork.VarCstDiv16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV16RF"));
		//				//dmdSalesWork.VarCstDiv17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV17RF"));
		//				//dmdSalesWork.VarCstDiv18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV18RF"));
		//				//dmdSalesWork.VarCstDiv19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV19RF"));
		//				//dmdSalesWork.VarCstDiv20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV20RF"));
		//				//dmdSalesWork.VarCstConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTCONSTAXRF"));
		//				//dmdSalesWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
		//				//dmdSalesWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
		//				//dmdSalesWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
		//				//dmdSalesWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
		//				//dmdSalesWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
		//				//dmdSalesWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
		//				//dmdSalesWork.AcceptAnOrderDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
		//				//dmdSalesWork.CarDeliExpectedDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("CARDELIEXPECTEDDATERF"));
		//				//dmdSalesWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
		//				//dmdSalesWork.SalesDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SALESDIVRF"));
		//				//dmdSalesWork.SalesName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESNAMERF"));
		//				//dmdSalesWork.DebitNLnkAcptAnOdr = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
		//				//dmdSalesWork.DemandProRataCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEMANDPRORATACDRF"));
		//				//dmdSalesWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE1CODERF"));
		//				//dmdSalesWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
		//				//dmdSalesWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE2RF"));
		//				//dmdSalesWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE3RF"));
		//				//dmdSalesWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE4RF"));
		//				//dmdSalesWork.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MAKERNAMERF"));
		//				//dmdSalesWork.ModelName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELNAMERF"));
		//				//dmdSalesWork.DemandableSalesNote = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDABLESALESNOTERF"));
		//				//dmdSalesWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
		//				//dmdSalesWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
		//				//dmdSalesWork.CreditSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITSALESRF"));
		//				//dmdSalesWork.CreditAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALLOWANCERF"));
		//				//dmdSalesWork.CreditAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALWCBLNCERF"));
		//				//dmdSalesWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
		//				//dmdSalesWork.AaCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AACOUNTRF"));
		//				//dmdSalesWork.MnyOnDepoAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCERF"));
		//				//dmdSalesWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
		//				//dmdSalesWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
		//				//dmdSalesWork.CarInspectOrGeCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARINSPECTORGECDRF"));
		//				//dmdSalesWork.GradeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GRADENAMERF"));
		//				//#endregion
        //                //
		//				//dmdSalesWorkArrayList.Add(dmdSalesWork);
        //                #endregion
        //
        //                #region MA.NS 売上データへSQLデータを設定
        //                SalesSlipWork salesSlipWork = new SalesSlipWork();
        //
        //                // 作成日時
        //                salesSlipWork.CreateDateTime            = SqlDataMediator.SqlGetDateTimeFromTicks   (myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
        //                // 更新日時
        //                salesSlipWork.UpdateDateTime            = SqlDataMediator.SqlGetDateTimeFromTicks   (myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                // 企業コード
        //                salesSlipWork.EnterpriseCode            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ENTERPRISECODERF" ));
        //                // GUID
        //                salesSlipWork.FileHeaderGuid            = SqlDataMediator.SqlGetGuid                (myReader,myReader.GetOrdinal("FILEHEADERGUIDRF" ));
        //                // 更新従業員コード
        //                salesSlipWork.UpdEmployeeCode           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //                // 更新アセンブリID1
        //                salesSlipWork.UpdAssemblyId1            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF" ));
        //                // 更新アセンブリID2
        //                salesSlipWork.UpdAssemblyId2            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF" ));
        //                // 論理削除区分
        //                salesSlipWork.LogicalDeleteCode         = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
        //                // 受注番号
        //                salesSlipWork.AcceptAnOrderNo           = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
        //                // 受注ステータス
        //                salesSlipWork.AcptAnOdrStatus           = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
        //                // 売上伝票番号
        //                salesSlipWork.SalesSlipNum              = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESSLIPNUMRF"));
        //                // 受注伝票番号
        //                salesSlipWork.AcptAnOdrSlipNum          = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACPTANODRSLIPNUMRF"));
        //                // 見積伝票番号
        //                salesSlipWork.EstimateSlipNo            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ESTIMATESLIPNORF"));
        //                // 赤伝区分
        //                salesSlipWork.DebitNoteDiv              = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
        //                // 赤黒連結受注番号
        //                salesSlipWork.DebitNLnkAcptAnOdr        = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
        //                // 売上伝票区分
        //                salesSlipWork.SalesSlipCd               = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("SALESSLIPCDRF"));
        //                // 売上形式
        //                salesSlipWork.SalesFormal               = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("SALESFORMALRF"));
        //                // 売上入力拠点コード
        //                salesSlipWork.SalesInpSecCd             = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESINPSECCDRF"));
        //                // 請求計上拠点コード
        //                salesSlipWork.DemandAddUpSecCd          = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
        //                // 実績計上拠点コード
        //                salesSlipWork.ResultsAddUpSecCd         = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
        //                // 更新拠点コード
        //                salesSlipWork.UpdateSecCd               = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDATESECCDRF"));
        //                // 伝票検索日付
        //                salesSlipWork.SearchSlipDate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SEARCHSLIPDATERF"));
        //                // 見積日付
        //                salesSlipWork.EstimateDate              = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ESTIMATEDATERF"));
        //                // 受注日
        //                salesSlipWork.AcceptAnOrderDate         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
        //                // 納品完了予定日
        //                salesSlipWork.DeliGdsCmpltDueDate       = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
        //                // 出荷日付
        //                salesSlipWork.ShipmentDay               = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SHIPMENTDAYRF"));
        //                // 売上日付
        //                salesSlipWork.SalesDate                 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SALESDATERF"));
        //                // 計上日付
        //                salesSlipWork.AddUpADate                = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
        //                // 受付従業員コード
        //                salesSlipWork.FrontEmployeeCd           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
        //                // 受付従業員名称
        //                salesSlipWork.FrontEmployeeNm           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
        //                // 販売従業員コード
        //                salesSlipWork.SalesEmployeeCd           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
        //                // 販売従業員名称
        //                salesSlipWork.SalesEmployeeNm           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESEMPLOYEENMRF"));
        //                // 注文方法
        //                salesSlipWork.WayToOrder                = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("WAYTOORDERRF"));
        //                // 売上小計
        //                salesSlipWork.SalesSubtotal             = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALESSUBTOTALRF"));
        //                // 売上小計外税対象額
        //                salesSlipWork.SalSubttlSubToOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOOUTTAXRF"));
        //                // 売上小計外税対象額
        //                salesSlipWork.SalSubttlSubToOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOOUTTAXRF"));
        //                // 売上小計内税対象額
        //                salesSlipWork.SalSubttlSubToInTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOINTAXRF"));
        //                // 売上小計非課税対象額
        //                salesSlipWork.SalSubttlSubToTaxFre      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
        //                // 売上小計外税額
        //                salesSlipWork.SalSubtotalOutTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTOTALOUTTAXRF"));
        //                // 売上小計内税額
        //                salesSlipWork.SalSubtotalInTax          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTOTALINTAXRF"));
        //                // 合計自社明細値引額
        //                salesSlipWork.TotalDiscount             = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISCOUNTRF"));
        //                // 合計自社明細値引外税対象額
        //                salesSlipWork.TotalDisSubToOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISSUBTOOUTTAXRF"));
        //                // 合計自社明細値引内税対象額
        //                salesSlipWork.TotalDisSubToInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISSUBTOINTAXRF"));
        //                // 合計自社明細値引非課税対象額
        //                salesSlipWork.TotalDisSubToTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISSUBTOTAXFREERF"));
        //                // 合計自社明細値引外税額
        //                salesSlipWork.TotalDiscountOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISCOUNTOUTTAXRF"));
        //                // 合計自社明細値引内税額
        //                salesSlipWork.TotalDiscountInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISCOUNTINTAXRF"));
        //                // 合計キャリア明細値引額
        //                salesSlipWork.TotalCarrierDiscount      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCARRIERDISCOUNTRF"));
        //                // 合計キャリア明細値引外税対象額
        //                salesSlipWork.TtlCDisSubToOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISSUBTOOUTTAXRF"));
        //                // 合計キャリア明細値引内税対象額
        //                salesSlipWork.TtlCDisSubToInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISSUBTOINTAXRF"));
        //                // 合計キャリア明細値引非課税対象額
        //                salesSlipWork.TtlCDisSubToTaxFree       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISSUBTOTAXFREERF"));
        //                // 合計キャリア明細値引外税額
        //                salesSlipWork.TtlCDiscountOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISCOUNTOUTTAXRF"));
        //                // 合計キャリア明細値引内税額
        //                salesSlipWork.TtlCDiscountInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISCOUNTINTAXRF"));
        //                // 合計自社小計値引
        //                salesSlipWork.TotalStDiscount           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSTDISCOUNTRF"));
        //                // 合計自社小計値引外税対象額
        //                salesSlipWork.TtlStDisSubToOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISSUBTOOUTTAXRF"));
        //                // 合計自社小計値引内税対象額
        //                salesSlipWork.TtlStDisSubToInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISSUBTOINTAXRF"));
        //                // 合計自社小計値引非課税対象額
        //                salesSlipWork.TtlStDisSubToTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISSUBTOINTAXRF"));
        //                // 合計自社小計値引外税額
        //                salesSlipWork.TtlStDiscountOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISCOUNTOUTTAXRF"));
        //                // 合計自社小計値引内税額
        //                salesSlipWork.TtlStDiscountInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISCOUNTINTAXRF"));
        //                // 合計キャリア小計値引
        //                salesSlipWork.TtlStCarrDiscount         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCARRDISCOUNTRF"));
        //                // 合計キャリア小計値引外税対象額
        //                salesSlipWork.TtlStCDisSubToOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISSUBTOOUTTAXRF"));
        //                // 合計キャリア小計値引内税対象額
        //                salesSlipWork.TtlStCDisSubToInTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISSUBTOINTAXRF"));
        //                // 合計キャリア小計値引非課税対象額
        //                salesSlipWork.TtlStCDisSubToTaxFre      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISSUBTOTAXFRERF"));
        //                // 合計キャリア小計値引外税額
        //                salesSlipWork.TtlStCDiscountOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISCOUNTOUTTAXRF"));
        //                // 合計キャリア小計値引内税額
        //                salesSlipWork.TtlStCDiscountInTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISCOUNTINTAXRF"));
        //                // 合計売上金額
        //                salesSlipWork.TotalSalesMoney           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSALESMONEYRF"));
        //                // 合計売上外税対象額
        //                salesSlipWork.TtlItdedSalesOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDSALESOUTTAXRF"));
        //                // 合計売上内税対象額
        //                salesSlipWork.TtlItdedSalesInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDSALESINTAXRF"));
        //                // 合計売上非課税対象額
        //                salesSlipWork.TtlItdedSalesTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDSALESTAXFREERF"));
        //                // 合計売上外税額
        //                salesSlipWork.TotalSalesOutTax          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSALESOUTTAXRF"));
        //                // 合計売上内税額
        //                salesSlipWork.TotalSalesInTax           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSALESINTAXRF"));
        //                // 原価合計
        //                salesSlipWork.TotalCost                 = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCOSTRF"));
        //                // 合計原価外税対象額
        //                salesSlipWork.TtlItdedCostOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDCOSTOUTTAXRF"));
        //                // 合計原価内税対象額
        //                salesSlipWork.TtlItdedCostInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDCOSTINTAXRF"));
        //                // 合計原価非課税対象額
        //                salesSlipWork.TtlItdedTaxFree           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDTAXFREERF"));
        //                // 合計原価外税額
        //                salesSlipWork.TotalCostOuterTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCOSTOUTERTAXRF"));
        //                // 合計原価内税額
        //                salesSlipWork.TotalCostInnerTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCOSTINNERTAXRF"));
        //                // 受取インセンティブ額合計
        //                salesSlipWork.TtlIncentiveRecv          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLINCENTIVERECVRF"));
        //                // 受取インセンティブ外税対象額合計
        //                salesSlipWork.TtlItdIncRecvOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCRECVOUTTAXRF"));
        //                // 受取インセンティブ内税対象額合計
        //                salesSlipWork.TtlItdIncRecvInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCRECVINTAXRF"));
        //                // 受取インセンティブ非課税対象額合計
        //                salesSlipWork.TtlItdIncRecvTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCRECVTAXFREERF"));
        //                // 受取インセンティブ外税額合計
        //                salesSlipWork.TotalIncRecvOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCRECVOUTTAXRF"));
        //                // 受取インセンティブ内税額合計
        //                salesSlipWork.TotalIncRecvInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCRECVINTAXRF"));
        //                // 支払インセンティブ額合計
        //                salesSlipWork.TtlIncentiveDtbt          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLINCENTIVEDTBTRF"));
        //                // 支払インセンティブ外税対象額合計
        //                salesSlipWork.TtlItdIncDtbtOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCDTBTOUTTAXRF"));
        //                // 支払インセンティブ内税対象額合計
        //                salesSlipWork.TtlItdIncDtbtInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCDTBTINTAXRF"));
        //                // 支払インセンティブ非課税対象額合計
        //                salesSlipWork.TtlItdIncDtbtTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCDTBTTAXFREERF"));
        //                // 支払インセンティブ外税額合計
        //                salesSlipWork.TotalIncDtbtOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCDTBTOUTTAXRF"));
        //                // 支払インセンティブ内税額合計
        //                salesSlipWork.TotalIncDtbtInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCDTBTINTAXRF"));
        //                // 消費税転嫁方式
        //                salesSlipWork.ConsTaxLayMethod          = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
        //                // 消費税税率
        //                salesSlipWork.ConsTaxRate               = SqlDataMediator.SqlGetDouble              (myReader,myReader.GetOrdinal("CONSTAXRATERF"));
        //                // 端数処理区分
        //                salesSlipWork.FractionProcCd            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("FRACTIONPROCCDRF"));
        //                // 売掛区分
        //                salesSlipWork.AccRecDivCd               = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACCRECDIVCDRF"));
        //                // 自動入金区分
        //                salesSlipWork.AutoDepositCd             = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("AUTODEPOSITCDRF"));
        //                // 請求合計額
        //                salesSlipWork.DemandableTtl             = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("DEMANDABLETTLRF"));
        //                // 入金引当合計額
        //                salesSlipWork.DepositAllowanceTtl       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
        //                // 預り金引当合計額
        //                salesSlipWork.MnyDepoAllowanceTtl       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("MNYDEPOALLOWANCETTLRF"));
        //                // 入金引当残高
        //                salesSlipWork.DepositAlwcBlnce          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
        //                // 請求先コード
        //                salesSlipWork.ClaimCode                 = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CLAIMCODERF"));
        //                // 請求先名称1
        //                salesSlipWork.ClaimName1                = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CLAIMNAME1RF"));
        //                // 請求先名称2
        //                salesSlipWork.ClaimName2                = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CLAIMNAME2RF"));
        //                // 得意先コード
        //                salesSlipWork.CustomerCode              = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
        //                // 得意先名称
        //                salesSlipWork.CustomerName              = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CUSTOMERNAMERF"));
        //                // 得意先名称2
        //                salesSlipWork.CustomerName2             = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CUSTOMERNAME2RF"));
        //                // 敬称
        //                salesSlipWork.HonorificTitle            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("HONORIFICTITLERF"));
        //                // カナ
        //                salesSlipWork.Kana                      = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("KANARF"));
        //                // 性別コード
        //                salesSlipWork.SexCode                   = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("SEXCODERF"));
        //                // 個人・法人区分
        //                salesSlipWork.CorporateDivCode          = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
        //                // 年代コード
        //                salesSlipWork.GenerationCode            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("GENERATIONCODERF"));
        //                // 客層コード
        //                salesSlipWork.ClienteleCode             = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CLIENTELECODERF"));
        //                // 返品理由
        //                salesSlipWork.RetGoodsReason            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("RETGOODSREASONRF"));
        //                // 納品先コード
        //                salesSlipWork.AddresseeCode             = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ADDRESSEECODERF"));
        //                // 納品先名称
        //                salesSlipWork.AddresseeName             = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEENAMERF"));
        //                // 納品先名称2
        //                salesSlipWork.AddresseeName2            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEENAME2RF"));
        //                // 納品先住所1(都道府県市区郡・町村・字)
        //                salesSlipWork.AddresseeAddr1            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEEADDR1RF"));
        //                // 納品先住所2(丁目)
        //                salesSlipWork.AddresseeAddr2            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ADDRESSEEADDR2RF"));
        //                // 納品先住所3(番地)
        //                salesSlipWork.AddresseeAddr3            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEEADDR3RF"));
        //                // 納品先住所4(アパート名称)
        //                salesSlipWork.AddresseeAddr4            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEEADDR4RF"));
        //                // 納品先電話番号
        //                salesSlipWork.AddresseeTelNo            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEETELNORF"));
        //                // 相手先伝票番号
        //                salesSlipWork.PartySaleSlipNum          = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
        //                // 伝票備考
        //                salesSlipWork.SlipNote                  = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SLIPNOTERF"));
		//
        //                dmdSalesWorkArrayList.Add(salesSlipWork);
        //                #endregion
        //                // ↑ 20070123 18322 c
        //
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//		}
        //
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
        //
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
	    //
        //    // ↓ 20070124 18322 c MA.NS用に変更
		//	//DmdSalesWorkList =  (DmdSalesWork[])dmdSalesWorkArrayList.ToArray(typeof(DmdSalesWork));
		//
		//	salesSlipWorkList =  (SalesSlipWork[])dmdSalesWorkArrayList.ToArray(typeof(SalesSlipWork));
        //    // ↑ 20070124 18322 c
        //
		//	return status;
        //}
        #endregion
        // ↑ 20070518 18322 d

        // ↓ 20070124 18322 c MA.NS用に変更
        #region SF 引当更新用受注ワーククラス（MA.NSでは使用しないので削除）
        ///// public class name:   UpdAcceptOdrWork
	    ///// <summary>
	    /////                      引当更新用受注ワーク
	    ///// </summary>
	    ///// <remarks>
	    ///// <br>note             :   引当更新用受注ワークヘッダファイル</br>
	    ///// <br>Programmer       :   自動生成</br>
	    ///// <br>Date             :   2005/8/8</br>
	    ///// <br>Genarated Date   :   2005/08/06  (CSharp File Generated Date)</br>
	    ///// <br>Update Note      :   </br>
	    ///// </remarks>
	    //public class UpdAcceptOdrWork : IFileHeader
	    //{
	    //	/// <summary>作成日時</summary>
	    //	/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
	    //	private DateTime _createDateTime;
	    //
	    //	/// <summary>更新日時</summary>
	    //	/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
	    //	private DateTime _updateDateTime;
	    //
	    //	/// <summary>企業コード</summary>
	    //	/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
	    //	private string _enterpriseCode = "";
	    //
	    //	/// <summary>GUID</summary>
	    //	/// <remarks>共通ファイルヘッダ</remarks>
	    //	private Guid _fileHeaderGuid;
	    //
	    //	/// <summary>更新従業員コード</summary>
	    //	/// <remarks>共通ファイルヘッダ</remarks>
	    //	private string _updEmployeeCode = "";
	    //
	    //	/// <summary>更新アセンブリID1</summary>
	    //	/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
	    //	private string _updAssemblyId1 = "";
	    //
	    //	/// <summary>更新アセンブリID2</summary>
	    //	/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
	    //	private string _updAssemblyId2 = "";
	    //
	    //	/// <summary>論理削除区分</summary>
	    //	/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
	    //	private Int32 _logicalDeleteCode;
	    //
	    //	/// <summary>受注番号</summary>
	    //	private Int32 _acceptAnOrderNo;
	    //
	    //	/// <summary>入金引当合計額</summary>
	    //	/// <remarks>預り金引当合計額を含む</remarks>
	    //	private Int64 _depositAllowanceTtl;
	    //
	    //	/// <summary>預り金引当合計額</summary>
	    //	private Int64 _mnyDepoAllowanceTtl;
	    //
	    //	/// <summary>請求按分区分</summary>
	    //	/// <remarks>0:按分無し,1:請求按分有り</remarks>
	    //	private Int32 _demandProRataCd;
	    //
	    //	/// <summary>請求先①コード</summary>
	    //	private Int32 _claim1Code;
	    //
	    //	/// <summary>請求先②コード</summary>
	    //	/// <remarks>（SFはｵﾌﾟｼｮﾝ）</remarks>
	    //	private Int32 _claim2Code;
	    //
	    //	/// <summary>請求先③コード</summary>
	    //	/// <remarks>（SFはｵﾌﾟｼｮﾝ）</remarks>
	    //	private Int32 _claim3Code;
	    //
	    //	/// <summary>請求先④コード</summary>
	    //	/// <remarks>（SFはｵﾌﾟｼｮﾝ）</remarks>
	    //	private Int32 _claim4Code;
	    //
	    //	/// <summary>請求先⑤コード</summary>
	    //	/// <remarks>（SFはｵﾌﾟｼｮﾝ）</remarks>
	    //	private Int32 _claim5Code;
	    //
	    //	/// <summary>入金引当額1</summary>
	    //	/// <remarks>預り金引当額1を含む</remarks>
	    //	private Int64 _depositAllowance1;
	    //
	    //	/// <summary>預り金引当額1</summary>
	    //	private Int64 _mnyOnDepoAllowance1;
	    //
	    //	/// <summary>入金引当額2</summary>
	    //	/// <remarks>預り金引当額2を含む</remarks>
	    //	private Int64 _depositAllowance2;
	    //
	    //	/// <summary>預り金引当額2</summary>
	    //	private Int64 _mnyOnDepoAllowance2;
	    //
	    //	/// <summary>入金引当額3</summary>
	    //	/// <remarks>預り金引当額3を含む</remarks>
	    //	private Int64 _depositAllowance3;
	    //
	    //	/// <summary>預り金引当額3</summary>
	    //	private Int64 _mnyOnDepoAllowance3;
	    //
	    //	/// <summary>入金引当額4</summary>
	    //	/// <remarks>預り金引当額4を含む</remarks>
	    //	private Int64 _depositAllowance4;
	    //
	    //	/// <summary>預り金引当額4</summary>
	    //	private Int64 _mnyOnDepoAllowance4;
	    //
	    //	/// <summary>入金引当額5</summary>
	    //	/// <remarks>預り金引当額5を含む</remarks>
	    //	private Int64 _depositAllowance5;
	    //
	    //	/// <summary>預り金引当額5</summary>
	    //	private Int64 _mnyOnDepoAllowance5;
	    //
	    //	/// <summary>排他用入金引当更新日</summary>
	    //	/// <remarks>DateTime:精度は100ナノ秒</remarks>
	    //	private DateTime _exclusiveDepoAlwDate;
	    //
	    //	/// public propaty name  :  CreateDateTime
	    //	/// <summary>作成日時プロパティ</summary>
	    //	/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   作成日時プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public DateTime CreateDateTime
	    //	{
	    //		get{return _createDateTime;}
	    //		set{_createDateTime = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdateDateTime
	    //	/// <summary>更新日時プロパティ</summary>
	    //	/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   更新日時プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public DateTime UpdateDateTime
	    //	{
	    //		get{return _updateDateTime;}
	    //		set{_updateDateTime = value;}
	    //	}
	    //
	    //	/// public propaty name  :  EnterpriseCode
	    //	/// <summary>企業コードプロパティ</summary>
	    //	/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   企業コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public string EnterpriseCode
	    //	{
	    //		get{return _enterpriseCode;}
	    //		set{_enterpriseCode = value;}
	    //	}
	    //
	    //	/// public propaty name  :  FileHeaderGuid
	    //	/// <summary>GUIDプロパティ</summary>
	    //	/// <value>共通ファイルヘッダ</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   GUIDプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Guid FileHeaderGuid
	    //	{
	    //		get{return _fileHeaderGuid;}
	    //		set{_fileHeaderGuid = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdEmployeeCode
	    //	/// <summary>更新従業員コードプロパティ</summary>
	    //	/// <value>共通ファイルヘッダ</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   更新従業員コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public string UpdEmployeeCode
	    //	{
	    //		get{return _updEmployeeCode;}
	    //		set{_updEmployeeCode = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdAssemblyId1
	    //	/// <summary>更新アセンブリID1プロパティ</summary>
	    //	/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   更新アセンブリID1プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public string UpdAssemblyId1
	    //	{
	    //		get{return _updAssemblyId1;}
	    //		set{_updAssemblyId1 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdAssemblyId2
	    //	/// <summary>更新アセンブリID2プロパティ</summary>
	    //	/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   更新アセンブリID2プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public string UpdAssemblyId2
	    //	{
	    //		get{return _updAssemblyId2;}
	    //		set{_updAssemblyId2 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  LogicalDeleteCode
	    //	/// <summary>論理削除区分プロパティ</summary>
	    //	/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   論理削除区分プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 LogicalDeleteCode
	    //	{
	    //		get{return _logicalDeleteCode;}
	    //		set{_logicalDeleteCode = value;}
	    //	}
	    //
	    //	/// public propaty name  :  AcceptAnOrderNo
	    //	/// <summary>受注番号プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   受注番号プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 AcceptAnOrderNo
	    //	{
	    //		get{return _acceptAnOrderNo;}
	    //		set{_acceptAnOrderNo = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowanceTtl
	    //	/// <summary>入金引当合計額プロパティ</summary>
	    //	/// <value>預り金引当合計額を含む</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   入金引当合計額プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowanceTtl
	    //	{
	    //		get{return _depositAllowanceTtl;}
	    //		set{_depositAllowanceTtl = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyDepoAllowanceTtl
	    //	/// <summary>預り金引当合計額プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   預り金引当合計額プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 MnyDepoAllowanceTtl
	    //	{
	    //		get{return _mnyDepoAllowanceTtl;}
	    //		set{_mnyDepoAllowanceTtl = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DemandProRataCd
	    //	/// <summary>請求按分区分プロパティ</summary>
	    //	/// <value>0:按分無し,1:請求按分有り</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   請求按分区分プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 DemandProRataCd
	    //	{
	    //		get{return _demandProRataCd;}
	    //		set{_demandProRataCd = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim1Code
	    //	/// <summary>請求先①コードプロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   請求先①コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 Claim1Code
	    //	{
	    //		get{return _claim1Code;}
	    //		set{_claim1Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim2Code
	    //	/// <summary>請求先②コードプロパティ</summary>
	    //	/// <value>（SFはｵﾌﾟｼｮﾝ）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   請求先②コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 Claim2Code
	    //	{
	    //		get{return _claim2Code;}
	    //		set{_claim2Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim3Code
	    //	/// <summary>請求先③コードプロパティ</summary>
	    //	/// <value>（SFはｵﾌﾟｼｮﾝ）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   請求先③コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 Claim3Code
	    //	{
	    //		get{return _claim3Code;}
	    //		set{_claim3Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim4Code
	    //	/// <summary>請求先④コードプロパティ</summary>
	    //	/// <value>（SFはｵﾌﾟｼｮﾝ）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   請求先④コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 Claim4Code
	    //	{
	    //		get{return _claim4Code;}
	    //		set{_claim4Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim5Code
	    //	/// <summary>請求先⑤コードプロパティ</summary>
	    //	/// <value>（SFはｵﾌﾟｼｮﾝ）</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   請求先⑤コードプロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int32 Claim5Code
	    //	{
	    //		get{return _claim5Code;}
	    //		set{_claim5Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance1
	    //	/// <summary>入金引当額1プロパティ</summary>
	    //	/// <value>預り金引当額1を含む</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   入金引当額1プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance1
	    //	{
	    //		get{return _depositAllowance1;}
	    //		set{_depositAllowance1 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance1
	    //	/// <summary>預り金引当額1プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   預り金引当額1プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance1
	    //	{
	    //		get{return _mnyOnDepoAllowance1;}
	    //		set{_mnyOnDepoAllowance1 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance2
	    //	/// <summary>入金引当額2プロパティ</summary>
	    //	/// <value>預り金引当額2を含む</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   入金引当額2プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance2
	    //	{
	    //		get{return _depositAllowance2;}
	    //		set{_depositAllowance2 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance2
	    //	/// <summary>預り金引当額2プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   預り金引当額2プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance2
	    //	{
	    //		get{return _mnyOnDepoAllowance2;}
	    //		set{_mnyOnDepoAllowance2 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance3
	    //	/// <summary>入金引当額3プロパティ</summary>
	    //	/// <value>預り金引当額3を含む</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   入金引当額3プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance3
	    //	{
	    //		get{return _depositAllowance3;}
	    //		set{_depositAllowance3 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance3
	    //	/// <summary>預り金引当額3プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   預り金引当額3プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance3
	    //	{
	    //		get{return _mnyOnDepoAllowance3;}
	    //		set{_mnyOnDepoAllowance3 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance4
	    //	/// <summary>入金引当額4プロパティ</summary>
	    //	/// <value>預り金引当額4を含む</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   入金引当額4プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance4
	    //	{
	    //		get{return _depositAllowance4;}
	    //		set{_depositAllowance4 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance4
	    //	/// <summary>預り金引当額4プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   預り金引当額4プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance4
	    //	{
	    //		get{return _mnyOnDepoAllowance4;}
	    //		set{_mnyOnDepoAllowance4 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance5
	    //	/// <summary>入金引当額5プロパティ</summary>
	    //	/// <value>預り金引当額5を含む</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   入金引当額5プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance5
	    //	{
	    //		get{return _depositAllowance5;}
	    //		set{_depositAllowance5 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance5
	    //	/// <summary>預り金引当額5プロパティ</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   預り金引当額5プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance5
	    //	{
	    //		get{return _mnyOnDepoAllowance5;}
	    //		set{_mnyOnDepoAllowance5 = value;}
	    //	}
	    //
	    //
	    //	/// public propaty name  :  ExclusiveDepoAlwDate
	    //	/// <summary>排他用入金引当更新日プロパティ</summary>
	    //	/// <value>DateTime:精度は100ナノ秒</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   排他用入金引当更新日プロパティ</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public DateTime ExclusiveDepoAlwDate
	    //	{
	    //		get{return _exclusiveDepoAlwDate;}
	    //		set{_exclusiveDepoAlwDate = value;}
	    //	}
	    //
	    //	/// <summary>
	    //	/// 引当更新用受注ワークコンストラクタ
	    //	/// </summary>
	    //	/// <returns>UpdAcceptOdrWorkクラスのインスタンス</returns>
	    //	/// <remarks>
	    //	/// <br>Note　　　　　　 :   UpdAcceptOdrWorkクラスの新しいインスタンスを生成します</br>
	    //	/// <br>Programer        :   自動生成</br>
	    //	/// </remarks>
	    //	public UpdAcceptOdrWork()
	    //	{
	    //	}
	    //
        //}
        #endregion
        // ↑ 20070124 18322 c

# endif
        # endregion
    }

    #region MA.NS 入金引当更新用売上ワーククラス
    /// public class name:   UpdSalesForPayDrawWork
    /// <summary>
    ///                      入金引当更新用売上クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金引当更新用売上クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   木村 武正</br>
    /// <br>Genarated Date   :   2007/02/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UpdSalesForPayDrawWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>売上伝票種別</summary>
        /// <remarks>10:売上,20:売切,21:売切計上,30:委託,31:委託計上,50:見積,60:受注,70:予約</remarks>
        private Int32 _salesSlipKind;

        /// <summary>売上伝票番号</summary>
        private string _saleSlipNum = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品,2:値引</remarks>
        private Int32 _salesSlipCd;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>請求合計額</summary>
        /// <remarks>伝票全体の請求合計（クレジット手数料は含まない）</remarks>
        private Int64 _demandableTtl;

        /// <summary>入金引当合計額</summary>
        /// <remarks>預り金引当合計額を含む</remarks>
        private Int64 _depositAllowanceTtl;

        /// <summary>預り金引当合計額</summary>
        private Int64 _mnyDepoAllowanceTtl;

        /// <summary>入金引当残高</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SalesSlipKind
        /// <summary>売上伝票種別プロパティ</summary>
        /// <value>10:売上,20:売切,21:売切計上,30:委託,31:委託計上,50:見積,60:受注,70:予約</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipKind
        {
            get { return _salesSlipKind; }
            set { _salesSlipKind = value; }
        }

        /// public propaty name  :  SaleSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SaleSlipNum
        {
            get { return _saleSlipNum; }
            set { _saleSlipNum = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  DemandableTtl
        /// <summary>請求合計額プロパティ</summary>
        /// <value>伝票全体の請求合計（クレジット手数料は含まない）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求合計額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DemandableTtl
        {
            get { return _demandableTtl; }
            set { _demandableTtl = value; }
        }

        /// public propaty name  :  DepositAllowanceTtl
        /// <summary>入金引当合計額プロパティ</summary>
        /// <value>預り金引当合計額を含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当合計額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositAllowanceTtl
        {
            get { return _depositAllowanceTtl; }
            set { _depositAllowanceTtl = value; }
        }

        /// public propaty name  :  MnyDepoAllowanceTtl
        /// <summary>預り金引当合計額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   預り金引当合計額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MnyDepoAllowanceTtl
        {
            get { return _mnyDepoAllowanceTtl; }
            set { _mnyDepoAllowanceTtl = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>入金引当残高プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金引当残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }


        /// <summary>
        /// 入金引当更新用売上クラスワークコンストラクタ
        /// </summary>
        /// <returns>UpdSalesForPayDrawWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UpdSalesForPayDrawWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UpdSalesForPayDrawWork()
        {
        }

    }
    #endregion
}
