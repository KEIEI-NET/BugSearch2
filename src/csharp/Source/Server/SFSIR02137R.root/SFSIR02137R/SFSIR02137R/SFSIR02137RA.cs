//**********************************************************************//
// System           :   ＰＭ．ＮＳ
// Sub System       :
// Program name     :   支払更新処理リモーティング
//                  :   SFSIR02137R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   岩本　勇
// Date             :   2005.08.11
//----------------------------------------------------------------------//
// Update Note      : 20060926 iwa 番号採番の拠点を計上拠点から更新拠点に変更（入金に合わせる）
//                  : 20061018 iwa トランザクション分離レベル対応
//                  : 20061222 18322 T.Kimura MA.NS用に支払伝票マスタを変更
//                    20070213 18322 T.Kimura 赤伝の削除機能を追加
//                    20070327 18322 T.Kimura 仕入先支払(買掛)金額マスタの更新処理を削除
//----------------------------------------------------------------------//
// Update Note      : 20070907 980081 A.Yamada 流通基幹システム対応
//                  : 20071102 980081 A.Yamada レイアウト変更対応(支払先等)
//                  : 20071210 980081 A.Yamada EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更
//                  : 20080111 980081 A.Yamada 論理削除機能を追加(LogicalDelete)
//                  : 20080117 980081 A.Yamada 更新・削除時エラーを修正
//                  : 20080317 980081 A.Yamada 支払日をシステム日付で登録する
//----------------------------------------------------------------------//
// Update Note      : 2008/04/22 21112  M.Kubota PM.NSシステム対応
//----------------------------------------------------------------------//
// Update Note      : 2009/04/28 22008 長内 MANTIS 13208 ＆論理削除対応
//----------------------------------------------------------------------//
// Update Note      : 2010.04.27 gejun M1007A-支払手形データ更新追加            
//----------------------------------------------------------------------//
// Update Note      : 2011/07/29 qijh  送信済みのチェック方法を追加
//----------------------------------------------------------------------//
// Update Note      : 2011/11/10 陳建明  Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------//
// Update Note      : 2011/12/15 tianjw  Redmine#27390 拠点管理/売上日のチェックの対応
//----------------------------------------------------------------------//
// Update Note      : 2012/02/06 田建委
// 管理番号         : 10707327-00 2012/03/28配信分
//                    Redmine#28288 送信済データ修正制御の対応
//----------------------------------------------------------------------//
// Update Note      : 2012/05/10 yangmj 
//                    売上締次集計処理中に伝票発行不可の修正
//----------------------------------------------------------------------//
// Update Note      : 2012/08/10 脇田 靖之 
//                    拠点管理 送信済データチェック不具合対応
//----------------------------------------------------------------------//
// Update Note      : 2012/10/18 宮本 利明
//                    支払伝票・手形(支払･受取)更新処理を追加
//----------------------------------------------------------------------//
// Update Note      : 2012/11/07 FSI斎藤 和宏
//                    値引・手数料のみの赤伝発行不可・削除不可の障害対応
//----------------------------------------------------------------------//
// Update Note      : 2013/01/10 zhuhh
// 管理番号         : 10806793-00 2013/03/13配信分
//                    Redmine#34123 手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------//
// Update Note      : 2013/02/21 脇田 靖之 
//                    支払伝票削除時、手形データ紐付け解除対応
//----------------------------------------------------------------------//
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
//using Broadleaf.Application.Controller;
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/22 M.Kubota
using Broadleaf.Application.Common;  // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 支払更新DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払データの更新操作を行うクラスです。</br>
	/// <br>Programmer : 95089 岩本　勇</br>
	/// <br>Date       : 2005.08.02</br>
	/// <br></br>
	/// <br>Update Note: 2006.12.22 木村 武正</br>
    /// <br>                        携帯.NS用に変更</br>
    /// <br>Update Note: 2011/12/15 tianjw</br>
    /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note: 2012/02/06 田建委</br>
    /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
    /// <br>             Redmine#28288 送信済データ修正制御の対応</br>
    /// <br>Update Note: 2012/05/10  yangmj</br>
    /// <br>           : 売上締次集計処理中に伝票発行不可の修正</br>
    /// <br>Update Note: 2012/08/10  脇田 靖之</br>
    /// <br>           : 拠点管理 送信済データチェック不具合対応</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// <br></br>
    /// </remarks>
	[Serializable]
    //public class PaymentSlpDB : RemoteDB, IPaymentSlpDB           //DEL 2008/04/24 M.Kubota
    public class PaymentSlpDB : RemoteWithAppLockDB, IPaymentSlpDB  //ADD 2008/04/24 M.Kubota
	{
        // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
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
        // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        /// <summary>
		/// 支払更新DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.02</br>
		/// </remarks>
        public PaymentSlpDB():
            base("SFSIR02140D", "Broadleaf.Application.Remoting.ParamData.CreatePaymentSlpWork", "PAYMENTSLPRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("DepsitMainDBコンストラクタ");
        }

        # region [書込処理]

        /// <summary>
        /// 支払更新処理
        /// </summary>
        /// <param name="paymentDataWorkByte">支払情報ワーク</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報・支払引当情報を元にデータ更新を行います</br>
        /// <br>           : 支払番号無しの時、新規支払作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 支払引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Programmer : 95089 岩本　勇</br>
        /// <br>Date       : 2005.08.11</br>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        /// </remarks>
        //public int Write(ref byte[] paymentDataWorkByte, ref byte[] depositAlwWorkListByte)
        public int Write(ref byte[] paymentDataWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/22 M.Kubota

            string resName = string.Empty;  //ADD 2008/04/22 M.Kubota

            try
            {
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                # region --- DEL 2008/04/22 M.Kubota ---
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                //// XMLの読み込み
                //PaymentSlpWork paymentDataWork = (PaymentSlpWork)XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentSlpWork));

                ////SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                ////sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);//20061018 iwa add

                //// 更新時ロック処理
                //int[] SupplierCdList = { paymentDataWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(paymentDataWork.EnterpriseCode, SupplierCdList, null);	// 得意先別ロックをかける
                # endregion

                //--- ADD 2008/04/22 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // XMLの読み込み
                //PaymentSlpWork paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentSlpWork)) as PaymentSlpWork;   //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/22 M.Kubota --->>>
                PaymentDataWork paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentDataWork)) as PaymentDataWork;  //ADD 2008/04/24 M.Kubota

                if (paymentDataWork == null)
                {
                    return status;
                }
                
                PaymentSlpWork paymentSlpWork = null;
                PaymentDtlWork[] paymentDtlWorkArray = null;
                PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);
                //--- ADD 2008/04/22 M.Kubota ---<<<

                if (paymentSlpWork != null)
                {
                    //--- DEL yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                    ////システムロック(拠点) //2009/1/27 Add sakurai
                    //ShareCheckInfo info = new ShareCheckInfo();
                    //info.Keys.Add(paymentSlpWork.EnterpriseCode, ShareCheckType.Section, paymentSlpWork.AddUpSecCode, "");
                    //status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    //if (status != 0) return status;
                    //--- DEL yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<

                    //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
                    // 締次ロック（伝票側）
                    ShareCheckInfo info = new ShareCheckInfo();
                    int supplierTotalDay = GetSupplierTotalDay(paymentSlpWork.EnterpriseCode, paymentSlpWork.SupplierCd, ref sqlConnection, ref sqlTransaction);
                    info.Keys.Add(new ShareCheckKey(paymentSlpWork.EnterpriseCode, ShareCheckType.SupUpSlip, paymentSlpWork.AddUpSecCode, "", supplierTotalDay, ToLongDate(paymentSlpWork.AddUpADate)));
                    // ロック
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;
                    //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<

                    // 支払マスタ更新処理
                    //status = WritePaymentSlpWork(ref paymentDataWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/22 M.Kubota
                    status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/22 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除 //2009/1/27 Add sakurai
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);  //DEL 2008/04/22 M.Kubota

                    //--- ADD 2008/04/22 M.Kubota --->>>
                    PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                    
                    // XMLへ変換し、文字列のバイナリ化
                    paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                    //--- ADD 2008/04/22 M.Kubota ---<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう               
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/22 M.Kubota
                //--- ADD 2008/04/22 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/22 M.Kubota ---<<<
            }
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();              //DEL 2008/04/22 M.Kubota
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }

        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正----->>>>>
        /// <summary>
        /// 仕入先の締日(DD)を取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="supplierCd"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetSupplierTotalDay(string enterpriseCode, int supplierCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int totalDay = 99;

            try
            {
                SupplierDB supplierDB = new SupplierDB();
                SupplierWork supplier = new SupplierWork();
                supplier.EnterpriseCode = enterpriseCode;
                supplier.SupplierCd = supplierCd;
                int ret = supplierDB.Read(ref supplier, 0, ref sqlConnection, ref sqlTransaction);

                if (ret == 0)
                {
                    int supplierTotalDay = 0;
                    supplierTotalDay = supplier.PaymentTotalDay;
                    totalDay = supplierTotalDay;
                }

                // 失敗した場合はロックのキーを追加しない
                if (totalDay == 0)
                {
                    totalDay = 99;
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
        private int ToLongDate(DateTime dateTime)
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
        //--- ADD yangmj 2012/05/10  売上締次集計処理中に伝票発行不可の修正-----<<<<<

        // --------------- ADD START 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        /// <summary>
        /// 支払、手形更新処理
        /// </summary>
        /// <param name="paymentDataWorkByte">支払情報ワーク</param>
        /// <param name="payDraftDataWorkByte">支払手形データワーク</param>
        /// <param name="payDraftDataDelWorkByte">支払手形データワーク(削除用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報・支払引当情報・手形データを元にデータ更新を行います</br>
        /// <br>           : 支払番号無しの時、新規支払・手形データ作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 支払引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Programmer : gejun</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int WriteWithPayDraft(ref byte[] paymentDataWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            bool commitFlg = true;

            string resName = string.Empty;

            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                PaymentDataWork paymentDataWork = new PaymentDataWork();
                if (paymentDataWorkByte != null)
                    paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentDataWork)) as PaymentDataWork;
                else
                    paymentDataWork = null;

                PayDraftDataWork payDraftDataWork = new PayDraftDataWork(); 
                if(payDraftDataWorkByte != null)
                    payDraftDataWork = XmlByteSerializer.Deserialize(payDraftDataWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataWork = null;
                
                PayDraftDataWork payDraftDataDelWork = new PayDraftDataWork();
                if (payDraftDataDelWorkByte != null)
                    payDraftDataDelWork = XmlByteSerializer.Deserialize(payDraftDataDelWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataDelWork = null;
                if (paymentDataWork == null)
                {
                    return status;
                }

                PaymentSlpWork paymentSlpWork = null;
                PaymentDtlWork[] paymentDtlWorkArray = null;
                PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

                //システムロック(拠点)
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(paymentSlpWork.EnterpriseCode, ShareCheckType.Section, paymentSlpWork.AddUpSecCode, "");
                if (paymentSlpWork != null && paymentSlpWork.AddUpADate != DateTime.MinValue)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    // 支払マスタ更新処理
                    status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                    // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
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
                    // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // 支払手形データ更新処理
                if (payDraftDataWork != null)
                {
                    if (payDraftDataWork.PaymentRowNo != 0 && paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        // 支払伝票番号
                        payDraftDataWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
                        // 支払ステータス
                        payDraftDataWork.SupplierFormal = paymentSlpWork.SupplierFormal;
                        // 支払日付
                        payDraftDataWork.PaymentDate = paymentSlpWork.PaymentDate;
                    }
                    
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.WritePayDraft(payDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // 支払手形データ削除処理
                if (payDraftDataDelWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.DeletePayDraft(payDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }


                if (commitFlg)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();
      

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);

                        // XMLへ変換し、文字列のバイナリ化
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう               
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }
        /// <summary>
        /// 支払手形データマスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="payDraftDataWork">支払手形データ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタ情報を登録、更新します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int WritePayDraft(PayDraftDataWork payDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlText = string.Empty;

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<


                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        DateTime comUpDateTime = payDraftDataWork.UpdateDateTime;

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
                        sqlText += "UPDATE PAYDRAFTDATARF " + Environment.NewLine;
                        sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYDRAFTNORF=@PAYDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , PAYMENTRF=@PAYMENT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , SUPPLIERCDRF=@SUPPLIERCD , SUPPLIERNM1RF=@SUPPLIERNM1 , SUPPLIERNM2RF=@SUPPLIERNM2 , SUPPLIERSNMRF=@SUPPLIERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , SUPPLIERFORMALRF=@SUPPLIERFORMAL , PAYMENTSLIPNORF=@PAYMENTSLIPNO , PAYMENTROWNORF=@PAYMENTROWNO , PAYMENTDATERF=@PAYMENTDATE " + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                        findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)payDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (payDraftDataWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //　画面のデータ、insert処理
                        # region [INSERT文]
                        sqlText = string.Empty;
                        sqlText = "INSERT INTO PAYDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @PAYMENT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @SUPPLIERFORMAL, @PAYMENTSLIPNO, @PAYMENTROWNO, @PAYMENTDATE)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)payDraftDataWork;
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
                    SqlParameter paraPayDraftNo = sqlCommand.Parameters.Add("@PAYDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                    SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                    SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
                    SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(payDraftDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.LogicalDeleteCode);
                    paraPayDraftNo.Value = SqlDataMediator.SqlSetString(payDraftDataWork.PayDraftNo);
                    paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftKindCd);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftDivide);
                    paraPayment.Value = SqlDataMediator.SqlSetInt64(payDraftDataWork.Payment);
                    paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.BankAndBranchCd);
                    paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.BankAndBranchNm);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SectionCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.AddUpSecCode);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierSnm);
                    paraProcDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ProcDate);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ValidityTerm);
                    paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftStmntDate);
                    paraOutline1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline1);
                    paraOutline2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline2);
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierFormal);
                    paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentSlipNo);
                    paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentRowNo);
                    paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.PaymentDate);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDatatDB.Write" + status);
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
        /// <summary>
        /// 支払手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="payDraftDataWork">支払手形データマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int DeletePayDraft(PayDraftDataWork payDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = payDraftDataWork.PayDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<


                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != payDraftDataWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    // データは全て削除
                    # region [DELETE文]
                    sqlText = string.Empty;
                    //sqlText += "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
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

        // --- ADD 2012/10/18 -------------------------------------------------->>>>>
        /// <summary>
        /// 支払、手形(支払・受取)更新処理
        /// </summary>
        /// <param name="paymentDataWorkByte">支払情報ワーク</param>
        /// <param name="payDraftDataWorkByte">支払手形データワーク</param>
        /// <param name="payDraftDataDelWorkByte">支払手形データワーク(削除用)</param>
        /// <param name="rcvDraftDataWorkByte">受取手形データワーク</param>
        /// <param name="rcvDraftDataDelWorkByte">受取手形データワーク(削除用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報・支払引当情報・手形データを元にデータ更新を行います</br>
        /// <br>           : 支払番号無しの時、新規支払・手形データ作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 支払引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2012/10/18</br>
        /// </remarks>
        public int WriteWithDraft(ref byte[] paymentDataWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte
                                                                , byte[] rcvDraftDataWorkByte, byte[] rcvDraftDataDelWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            bool commitFlg = true;

            string resName = string.Empty;

            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                PaymentDataWork paymentDataWork = new PaymentDataWork();
                if (paymentDataWorkByte != null)
                    paymentDataWork = XmlByteSerializer.Deserialize(paymentDataWorkByte, typeof(PaymentDataWork)) as PaymentDataWork;
                else
                    paymentDataWork = null;

                PayDraftDataWork payDraftDataWork = new PayDraftDataWork();
                if (payDraftDataWorkByte != null)
                    payDraftDataWork = XmlByteSerializer.Deserialize(payDraftDataWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataWork = null;

                PayDraftDataWork payDraftDataDelWork = new PayDraftDataWork();
                if (payDraftDataDelWorkByte != null)
                    payDraftDataDelWork = XmlByteSerializer.Deserialize(payDraftDataDelWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                else
                    payDraftDataDelWork = null;

                RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
                if (rcvDraftDataWorkByte != null)
                    rcvDraftDataWork = XmlByteSerializer.Deserialize(rcvDraftDataWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataWork = null;

                RcvDraftDataWork rcvDraftDataDelWork = new RcvDraftDataWork();
                if (rcvDraftDataDelWorkByte != null)
                    rcvDraftDataDelWork = XmlByteSerializer.Deserialize(rcvDraftDataDelWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataDelWork = null;

                if (paymentDataWork == null)
                {
                    return status;
                }

                PaymentSlpWork paymentSlpWork = null;
                PaymentDtlWork[] paymentDtlWorkArray = null;
                PaymentDataUtil.Division(paymentDataWork, out paymentSlpWork, out paymentDtlWorkArray);

                //システムロック(拠点)
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(paymentSlpWork.EnterpriseCode, ShareCheckType.Section, paymentSlpWork.AddUpSecCode, "");
                if (paymentSlpWork != null && paymentSlpWork.AddUpADate != DateTime.MinValue)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    // 支払マスタ更新処理
                    status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                    // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
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
                    // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // 支払手形データ更新処理
                if (payDraftDataWork != null)
                {
                    if (payDraftDataWork.PaymentRowNo != 0 && paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        // 支払伝票番号
                        payDraftDataWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
                        // 支払ステータス
                        payDraftDataWork.SupplierFormal = paymentSlpWork.SupplierFormal;
                        // 支払日付
                        payDraftDataWork.PaymentDate = paymentSlpWork.PaymentDate;
                    }

                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.WritePayDraft(payDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // 支払手形データ削除処理
                if (payDraftDataDelWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.DeletePayDraft(payDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }
                // 受取手形データ更新処理
                if (rcvDraftDataWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.WriteRcvDraft(rcvDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                // 受取手形データ削除処理
                if (rcvDraftDataDelWork != null)
                {
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != 0) return status;

                    status = this.DeleteRcvDraft(rcvDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (st == 0 && status == 9) status = 9;
                        else if (st != 0) return st;
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        commitFlg = false;
                }

                if (commitFlg)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                    {
                        PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);

                        // XMLへ変換し、文字列のバイナリ化
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう               
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }
        /// <summary>
        /// 受取手形データマスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="rcvDraftDataWork">受取手形データ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報を登録、更新します</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2012/10/18</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int WriteRcvDraft(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
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
        /// <summary>
        /// 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="rcvDraftDataWork">受取手形データマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 宮本</br>
        /// <br>Date       : 2012/10/18</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int DeleteRcvDraft(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                    //sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmime #34123
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
        // --- ADD 2012/10/18 --------------------------------------------------<<<<<

        // --------------- ADD END 2010.04.27 gejun FOR M1007A-支払手形データ更新追加-------->>>>
        /// <summary>
        /// 支払伝票更新処理メイン
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票情報</param>
        /// <param name="paymentDtlWorkArray">支払明細情報の配列</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int Write(ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [パラメーターチェック]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (paymentSlpWork == null)
            {
                errmsg += "支払伝票データが未設定です.";
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

            // ロック用リソース名称を取得
            string resName = this.GetResourceName(paymentSlpWork.EnterpriseCode);
            status = this.Lock(resName, sqlConnection, sqlTransaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                errmsg += ": ロックに失敗しました.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            try
            {
                status = this.WriteInitial(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WriteProc(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
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
        /// 支払伝票更新準備処理
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票情報</param>
        /// <param name="paymentDtlWorkArray">支払明細情報の配列</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int WriteInitial(ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [パラメータチェック]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (paymentSlpWork == null)
            {
                errmsg += ": 支払伝票データが未設定です.";
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

            # region [支払伝票データ 書込準備処理]
            // 支払伝票番号の採番
            if (paymentSlpWork.PaymentSlipNo == 0)
            {
                // 支払伝票番号の採番
                int paymentSlipNo = 0;
                status = this.CreatePaymentSlipNoProc(paymentSlpWork.EnterpriseCode, paymentSlpWork.UpdateSecCd, out paymentSlipNo, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paymentSlpWork.PaymentSlipNo = paymentSlipNo;
                }
                else
                {
                    // 支払伝票番号の採番に失敗した場合は処理を終了
                    return status;
                }
            }
            # endregion

            # region [支払明細データ 書込準備処理]
            if (paymentDtlWorkArray != null && paymentDtlWorkArray.Length > 0)
            {
                foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                {
                    paymentDtlWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;  // 企業コード 
                    paymentDtlWork.SupplierFormal = paymentSlpWork.SupplierFormal;  // 仕入形式
                    paymentDtlWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;    // 支払伝票番号
                }
            }
            # endregion

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        /// <summary>
        /// 支払伝票更新準備処理
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票情報</param>
        /// <param name="paymentDtlWorkArray">支払明細情報の配列</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (paymentSlpWork != null)
            {
                // 支払データ登録・更新
                status = this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 支払明細データ登録・更新
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WritePaymentDtlWorkRec(paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                }
            }

            return status;
        }

        /// <summary>
        /// 支払マスタ情報を更新します
        /// </summary>
        /// <param name="paymentSlpWork">支払マスタ情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払情報を更新します</br>
        /// <br>Programmer : 95089 岩本　勇</br>
        /// <br>Date       : 2005.08.04</br>
        /// 
        //private int WritePaymentSlpWorkRec(bool mode_new, ref PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/22 M.Kubota
        private int WritePaymentSlpWorkRec(ref PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/22 M.Kubota
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //DEL 2008/04/22 M.Kubota
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;        //ADD 2008/04/22 M.Kubota

            SqlDataReader myReader = null;
            //string updateText; //DEL 2008/04/22 M.Kubota

            // 更新日付を取得
            DateTime Upd_UpdateDateTime = paymentSlpWork.UpdateDateTime;

            bool deleteSql = false;  //ADD 2008/04/22 M.Kubota

            //Selectコマンドの生成
            try
            {
                # region --- DEL 2008/04/22 M.Kubota ---
# if false
                if (mode_new == true)
                {
                    // ↓ 2007.11.02 980081 c
                #region 旧レイアウト(コメントアウト)
                    //// ↓ 20061222 18322 c 携帯.NSのレイアウトにあわせ変更
                    ////updateText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYMENTSLIPNORF, CUSTOMERCODERF, PAYMENTRF, DISCOUNTPAYMENTRF, FEEPAYMENTRF, OUTLINERF, PAYMENTINPSECTIONCDRF, PAYMENTDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, PAYMENTMONEYKINDCODERF, PAYMENTMONEYKINDDIVRF, PAYMENTMONEYKINDNAMERF, PAYMENTDIVNMRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF ,PAYMENTTOTALRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYMENTSLIPNO, @CUSTOMERCODE, @PAYMENT, @DISCOUNTPAYMENT, @FEEPAYMENT, @OUTLINE, @PAYMENTINPSECTIONCD, @PAYMENTDATE, @ADDUPSECCODE, @ADDUPADATE, @UPDATESECCD, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @PAYMENTMONEYKINDCODE, @PAYMENTMONEYKINDDIV, @PAYMENTMONEYKINDNAME, @PAYMENTDIVNM, @CREDITORLOANCD, @CREDITCOMPANYCODE , @PAYMENTTOTAL)";
                    //
                    //#region 支払伝票マスタINSERT文
                    //updateText = "INSERT INTO PAYMENTSLPRF ("
                    //           + "  CREATEDATETIMERF"
                    //           + ", UPDATEDATETIMERF"
                    //           + ", ENTERPRISECODERF"
                    //           + ", FILEHEADERGUIDRF"
                    //           + ", UPDEMPLOYEECODERF"
                    //           + ", UPDASSEMBLYID1RF"
                    //           + ", UPDASSEMBLYID2RF"
                    //           + ", LOGICALDELETECODERF"
                    //           + ", DEBITNOTEDIVRF"
                    //           + ", PAYMENTSLIPNORF"
                    //           + ", CUSTOMERCODERF"
                    //           + ", CUSTOMERNAMERF"
                    //           + ", CUSTOMERNAME2RF"
                    //           + ", PAYMENTINPSECTIONCDRF"
                    //           + ", ADDUPSECCODERF"
                    //           + ", UPDATESECCDRF"
                    //           + ", PAYMENTDATERF"
                    //           + ", ADDUPADATERF"
                    //           + ", PAYMENTMONEYKINDCODERF"
                    //           + ", PAYMENTMONEYKINDNAMERF"
                    //           + ", PAYMENTMONEYKINDDIVRF"
                    //           + ", PAYMENTTOTALRF"
                    //           + ", PAYMENTRF"
                    //           + ", FEEPAYMENTRF"
                    //           + ", DISCOUNTPAYMENTRF"
                    //           + ", REBATEPAYMENTRF"
                    //           + ", AUTOPAYMENTRF"
                    //           + ", CREDITORLOANCDRF"
                    //           + ", CREDITCOMPANYCODERF"
                    //           + ", DRAFTDRAWINGDATERF"
                    //           + ", DRAFTPAYTIMELIMITRF"
                    //           + ", DEBITNOTELINKPAYNORF"
                    //           + ", PAYMENTAGENTCODERF"
                    //           // ↓ 20070907 980081 c
                    //           //+ ", PAYMENTAGENTNMRF"
                    //           + ", PAYMENTAGENTNAMERF"
                    //           // ↑ 20070907 980081 c
                    //           + ", OUTLINERF"
                    //           // ↓ 20070907 980081 a
                    //           + ", CUSTCLAIMCODERF"
                    //           + ", SUBSECTIONCODERF"
                    //           + ", MINSECTIONCODERF"
                    //           + ", DRAFTKINDRF"
                    //           + ", DRAFTKINDNAMERF"
                    //           + ", DRAFTDIVIDERF"
                    //           + ", DRAFTDIVIDENAMERF"
                    //           + ", DRAFTNORF"
                    //           + ", PAYMENTINPUTAGENTCDRF"
                    //           + ", PAYMENTINPUTAGENTNMRF"
                    //           + ", BANKCODERF"
                    //           + ", BANKNAMERF"
                    //           + ", EDISENDDATERF"
                    //           + ", EDITAKEINDATERF"
                    //           + ", TEXTEXTRADATERF"
                    //           // ↑ 20070907 980081 a
                    //           + ") VALUES ("
                    //           + "  @CREATEDATETIME"
                    //           + ", @UPDATEDATETIME"
                    //           + ", @ENTERPRISECODE"
                    //           + ", @FILEHEADERGUID"
                    //           + ", @UPDEMPLOYEECODE"
                    //           + ", @UPDASSEMBLYID1"
                    //           + ", @UPDASSEMBLYID2"
                    //           + ", @LOGICALDELETECODE"
                    //           + ", @DEBITNOTEDIV"
                    //           + ", @PAYMENTSLIPNO"
                    //           + ", @CUSTOMERCODE"
                    //           + ", @CUSTOMERNAME"
                    //           + ", @CUSTOMERNAME2"
                    //           + ", @PAYMENTINPSECTIONCD"
                    //           + ", @ADDUPSECCODE"
                    //           + ", @UPDATESECCD"
                    //           + ", @PAYMENTDATE"
                    //           + ", @ADDUPADATE"
                    //           + ", @PAYMENTMONEYKINDCODE"
                    //           + ", @PAYMENTMONEYKINDNAME"
                    //           + ", @PAYMENTMONEYKINDDIV"
                    //           + ", @PAYMENTTOTAL"
                    //           + ", @PAYMENT"
                    //           + ", @FEEPAYMENT"
                    //           + ", @DISCOUNTPAYMENT"
                    //           + ", @REBATEPAYMENT"
                    //           + ", @AUTOPAYMENT"
                    //           + ", @CREDITORLOANCD"
                    //           + ", @CREDITCOMPANYCODE"
                    //           + ", @DRAFTDRAWINGDATE"
                    //           + ", @DRAFTPAYTIMELIMIT"
                    //           + ", @DEBITNOTELINKPAYNO"
                    //           + ", @PAYMENTAGENTCODE"
                    //           // ↓ 20070907 980081 c
                    //           //+ ", @PAYMENTAGENTNM"
                    //           + ", @PAYMENTAGENTNAME"
                    //           // ↑ 20070907 980081 c
                    //           + ", @OUTLINE"
                    //           // ↓ 20070907 980081 a
                    //           + ", @CUSTCLAIMCODE"
                    //           + ", @SUBSECTIONCODE"
                    //           + ", @MINSECTIONCODE"
                    //           + ", @DRAFTKIND"
                    //           + ", @DRAFTKINDNAME"
                    //           + ", @DRAFTDIVIDE"
                    //           + ", @DRAFTDIVIDENAME"
                    //           + ", @DRAFTNO"
                    //           + ", @PAYMENTINPUTAGENTCD"
                    //           + ", @PAYMENTINPUTAGENTNM"
                    //           + ", @BANKCODE"
                    //           + ", @BANKNAME"
                    //           + ", @EDISENDDATE"
                    //           + ", @EDITAKEINDATE"
                    //           + ", @TEXTEXTRADATE"
                    //           // ↑ 20070907 980081 a
                    //           + ")"
                    //           ;
                    //#endregion
                    // ↑ 20061222 18322 c
                    #endregion
                    updateText = "INSERT INTO PAYMENTSLPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEBITNOTEDIVRF, PAYMENTSLIPNORF, SUPPLIERSLIPNORF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, PAYMENTINPSECTIONCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, MINSECTIONCODERF, PAYMENTDATERF, ADDUPADATERF, PAYMENTMONEYKINDCODERF, PAYMENTMONEYKINDNAMERF, PAYMENTMONEYKINDDIVRF, PAYMENTTOTALRF, PAYMENTRF, FEEPAYMENTRF, DISCOUNTPAYMENTRF, REBATEPAYMENTRF, AUTOPAYMENTRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEBITNOTELINKPAYNORF, PAYMENTAGENTCODERF, PAYMENTAGENTNAMERF, PAYMENTINPUTAGENTCDRF, PAYMENTINPUTAGENTNMRF, OUTLINERF, BANKCODERF, BANKNAMERF, EDISENDDATERF, EDITAKEINDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEBITNOTEDIV, @PAYMENTSLIPNO, @SUPPLIERSLIPNO, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @PAYMENTINPSECTIONCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @MINSECTIONCODE, @PAYMENTDATE, @ADDUPADATE, @PAYMENTMONEYKINDCODE, @PAYMENTMONEYKINDNAME, @PAYMENTMONEYKINDDIV, @PAYMENTTOTAL, @PAYMENT, @FEEPAYMENT, @DISCOUNTPAYMENT, @REBATEPAYMENT, @AUTOPAYMENT, @CREDITORLOANCD, @CREDITCOMPANYCODE, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEBITNOTELINKPAYNO, @PAYMENTAGENTCODE, @PAYMENTAGENTNAME, @PAYMENTINPUTAGENTCD, @PAYMENTINPUTAGENTNM, @OUTLINE, @BANKCODE, @BANKNAME, @EDISENDDATE, @EDITAKEINDATE)";
                    // ↑ 2007.11.02 980081 c

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)paymentSlpWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                else
                {
                    if (paymentSlpWork.LogicalDeleteCode == 0)		// 論理削除区分が立っていない場合は通常更新実行
                    {
                        // ↓ 2007.11.02 980081 c
                #region 旧レイアウト(コメントアウト)
                        //// ↓ 20061222 18322 c 携帯.NSのレイアウトにあわせ変更
                        ////// 更新日を更新検索キーに付加して更新（日付排他処理）
                        ////updateText = "UPDATE PAYMENTSLPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYMENTSLIPNORF=@PAYMENTSLIPNO , CUSTOMERCODERF=@CUSTOMERCODE , PAYMENTRF=@PAYMENT , DISCOUNTPAYMENTRF=@DISCOUNTPAYMENT , FEEPAYMENTRF=@FEEPAYMENT , OUTLINERF=@OUTLINE , PAYMENTINPSECTIONCDRF=@PAYMENTINPSECTIONCD , PAYMENTDATERF=@PAYMENTDATE , ADDUPSECCODERF=@ADDUPSECCODE , ADDUPADATERF=@ADDUPADATE , UPDATESECCDRF=@UPDATESECCD , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , PAYMENTMONEYKINDCODERF=@PAYMENTMONEYKINDCODE , PAYMENTMONEYKINDDIVRF=@PAYMENTMONEYKINDDIV , PAYMENTMONEYKINDNAMERF=@PAYMENTMONEYKINDNAME , PAYMENTDIVNMRF=@PAYMENTDIVNM , CREDITORLOANCDRF=@CREDITORLOANCD , CREDITCOMPANYCODERF=@CREDITCOMPANYCODE , PAYMENTTOTALRF=@PAYMENTTOTAL WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO ";
                        //
                        //#region 支払伝票マスタUPDATE文 更新日を更新検索キーに付加して更新（日付排他処理）
                        //// 更新日を更新検索キーに付加して更新（日付排他処理）
                        //updateText = "UPDATE PAYMENTSLPRF"
                        //           + " SET CREATEDATETIMERF=@CREATEDATETIME"
                        //           + ", UPDATEDATETIMERF=@UPDATEDATETIME"
                        //           + ", ENTERPRISECODERF=@ENTERPRISECODE"
                        //           + ", FILEHEADERGUIDRF=@FILEHEADERGUID"
                        //           + ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                        //           + ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                        //           + ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                        //           + ", LOGICALDELETECODERF=@LOGICALDELETECODE"
                        //
                        //           + ", DEBITNOTEDIVRF=@DEBITNOTEDIV"
                        //           + ", PAYMENTSLIPNORF=@PAYMENTSLIPNO"
                        //           + ", CUSTOMERCODERF=@CUSTOMERCODE"
                        //           + ", CUSTOMERNAMERF=@CUSTOMERNAME"
                        //           + ", CUSTOMERNAME2RF=@CUSTOMERNAME2"
                        //           + ", PAYMENTINPSECTIONCDRF=@PAYMENTINPSECTIONCD"
                        //           + ", ADDUPSECCODERF=@ADDUPSECCODE"
                        //           + ", UPDATESECCDRF=@UPDATESECCD"
                        //           + ", PAYMENTDATERF=@PAYMENTDATE"
                        //           + ", ADDUPADATERF=@ADDUPADATE"
                        //           + ", PAYMENTMONEYKINDCODERF=@PAYMENTMONEYKINDCODE"
                        //           + ", PAYMENTMONEYKINDNAMERF=@PAYMENTMONEYKINDNAME"
                        //           + ", PAYMENTMONEYKINDDIVRF=@PAYMENTMONEYKINDDIV"
                        //           + ", PAYMENTTOTALRF=@PAYMENTTOTAL"
                        //           + ", PAYMENTRF=@PAYMENT"
                        //           + ", FEEPAYMENTRF=@FEEPAYMENT"
                        //           + ", DISCOUNTPAYMENTRF=@DISCOUNTPAYMENT"
                        //           + ", REBATEPAYMENTRF=@REBATEPAYMENT"
                        //           + ", AUTOPAYMENTRF=@AUTOPAYMENT"
                        //           + ", CREDITORLOANCDRF=@CREDITORLOANCD"
                        //           + ", CREDITCOMPANYCODERF=@CREDITCOMPANYCODE"
                        //           + ", DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE"
                        //           + ", DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT"
                        //           + ", DEBITNOTELINKPAYNORF=@DEBITNOTELINKPAYNO"
                        //           + ", PAYMENTAGENTCODERF=@PAYMENTAGENTCODE"
                        //           // ↓ 20070907 980081 c
                        //           //+ ", PAYMENTAGENTNMRF=@PAYMENTAGENTNM"
                        //           + ", PAYMENTAGENTNAMERF=@PAYMENTAGENTNAME"
                        //           // ↑ 20070907 980081 c
                        //           + ", OUTLINERF=@OUTLINE"
                        //           // ↓ 20070907 980081 a
                        //           + ", CUSTCLAIMCODERF=@CUSTCLAIMCODE"
                        //           + ", SUBSECTIONCODERF=@SUBSECTIONCODE"
                        //           + ", MINSECTIONCODERF=@MINSECTIONCODE"
                        //           + ", DRAFTKINDRF=@DRAFTKIND"
                        //           + ", DRAFTKINDNAMERF=@DRAFTKINDNAME"
                        //           + ", DRAFTDIVIDERF=@DRAFTDIVIDE"
                        //           + ", DRAFTDIVIDENAMERF=@DRAFTDIVIDENAME"
                        //           + ", DRAFTNORF=@DRAFTNO"
                        //           + ", PAYMENTINPUTAGENTCDRF=@PAYMENTINPUTAGENTCD"
                        //           + ", PAYMENTINPUTAGENTNMRF=@PAYMENTINPUTAGENTNM"
                        //           + ", BANKCODERF=@BANKCODE"
                        //           + ", BANKNAMERF=@BANKNAME"
                        //           + ", EDISENDDATERF=@EDISENDDATE"
                        //           + ", EDITAKEINDATERF=@EDITAKEINDATE"
                        //           + ", TEXTEXTRADATERF=@TEXTEXTRADATE"
                        //           // ↑ 20070907 980081 a
                        //           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                        //           + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                        //           + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO "
                        //           ;
                        //#endregion
                        //// ↑ 20061222 18322 c
                        #endregion
                        //更新日を更新検索キーに付加して更新（日付排他処理）
                        updateText = "UPDATE PAYMENTSLPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DEBITNOTEDIVRF=@DEBITNOTEDIV , PAYMENTSLIPNORF=@PAYMENTSLIPNO , SUPPLIERSLIPNORF=@SUPPLIERSLIPNO , SUPPLIERCDRF = @SUPPLIERCD, SUPPLIERNM1RF = @SUPPLIERNM1, SUPPLIERNM2RF = @SUPPLIERNM2, SUPPLIERSNMRF = @SUPPLIERSNM , PAYEECODERF=@PAYEECODE , PAYEENAMERF=@PAYEENAME , PAYEENAME2RF=@PAYEENAME2 , PAYEESNMRF=@PAYEESNM , PAYMENTINPSECTIONCDRF=@PAYMENTINPSECTIONCD , ADDUPSECCODERF=@ADDUPSECCODE , UPDATESECCDRF=@UPDATESECCD , SUBSECTIONCODERF=@SUBSECTIONCODE , MINSECTIONCODERF=@MINSECTIONCODE , PAYMENTDATERF=@PAYMENTDATE , ADDUPADATERF=@ADDUPADATE , PAYMENTMONEYKINDCODERF=@PAYMENTMONEYKINDCODE , PAYMENTMONEYKINDNAMERF=@PAYMENTMONEYKINDNAME , PAYMENTMONEYKINDDIVRF=@PAYMENTMONEYKINDDIV , PAYMENTTOTALRF=@PAYMENTTOTAL , PAYMENTRF=@PAYMENT , FEEPAYMENTRF=@FEEPAYMENT , DISCOUNTPAYMENTRF=@DISCOUNTPAYMENT , REBATEPAYMENTRF=@REBATEPAYMENT , AUTOPAYMENTRF=@AUTOPAYMENT , CREDITORLOANCDRF=@CREDITORLOANCD , CREDITCOMPANYCODERF=@CREDITCOMPANYCODE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , DRAFTKINDRF=@DRAFTKIND , DRAFTKINDNAMERF=@DRAFTKINDNAME , DRAFTDIVIDERF=@DRAFTDIVIDE , DRAFTDIVIDENAMERF=@DRAFTDIVIDENAME , DRAFTNORF=@DRAFTNO , DEBITNOTELINKPAYNORF=@DEBITNOTELINKPAYNO , PAYMENTAGENTCODERF=@PAYMENTAGENTCODE , PAYMENTAGENTNAMERF=@PAYMENTAGENTNAME , PAYMENTINPUTAGENTCDRF=@PAYMENTINPUTAGENTCD , PAYMENTINPUTAGENTNMRF=@PAYMENTINPUTAGENTNM , OUTLINERF=@OUTLINE , BANKCODERF=@BANKCODE , BANKNAMERF=@BANKNAME , EDISENDDATERF=@EDISENDDATE , EDITAKEINDATERF=@EDITAKEINDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO AND UPDATEDATETIMERF=@FINDUPDATEDATETIME";
                        // ↑ 2007.11.02 980081 c

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentSlpWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                    }
                    else											// 論理削除区分が立っている場合は削除処理実行
                    {

                        // ↓ 20061222 18322 c 携帯.NSのレイアウトにあわせ変更
                        //// 更新日を更新検索キーに付加して削除（日付排他処理）
                        //updateText = "DELETE FROM PAYMENTSLPRF WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO";

                        // 更新日を更新検索キーに付加して削除（日付排他処理）
                        updateText = "DELETE FROM PAYMENTSLPRF"
                                   + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                                   + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                                   + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"
                                   ;
                        // ↑ 20061222 18322 c

                    }

                }

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {
                    // ↓ 2008.01.17 980081 a
                    //Prameterオブジェクトの作成
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                    //Parameterオブジェクトへ値設定
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                    // ↑ 2008.01.17 a
                    // ↓ 2007.11.02 980081 c
                #region 旧レイアウト(コメントアウト)
                    ////Prameterオブジェクトの作成
                    //SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                    ////Parameterオブジェクトへ値設定
                    //findParaUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.EnterpriseCode);
                    //findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentSlipNo);
                    //
                    //#region Parameterオブジェクトの作成(更新用)
                    ////Parameterオブジェクトの作成(更新用)
                    //
                    //SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    //SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    //SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    //SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    //
                    //// ↓ 20061222 18322 c 携帯.NS用に変更
                    ////SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    ////SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    ////SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    ////SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    ////SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    ////SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    ////SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    ////SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    ////SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    ////SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    ////SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    ////SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    ////SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    ////SqlParameter paraPaymentMoneyKindCode = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDCODE", SqlDbType.Int);
                    ////SqlParameter paraPaymentMoneyKindDiv = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDDIV", SqlDbType.Int);
                    ////SqlParameter paraPaymentMoneyKindName = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDNAME", SqlDbType.NVarChar);
                    //////SqlParameter paraPaymentDivNm = sqlCommand.Parameters.Add("@PAYMENTDIVNM", SqlDbType.NVarChar);
                    ////SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    ////SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    ////SqlParameter paraPaymenttotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    ////SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    //
                    //SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    //SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    //SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    //SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    //SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    //SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    //SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    //SqlParameter paraPaymentMoneyKindCode = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDCODE", SqlDbType.Int);
                    //SqlParameter paraPaymentMoneyKindName = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDNAME", SqlDbType.NVarChar);
                    //SqlParameter paraPaymentMoneyKindDiv = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDDIV", SqlDbType.Int);
                    //SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    //SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraRebatePayment = sqlCommand.Parameters.Add("@REBATEPAYMENT", SqlDbType.BigInt);
                    //SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    //SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    //SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    //SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    //SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    //SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                    //SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    //// ↓ 20070907 980081 c
                    ////SqlParameter paraPaymentAgentNm = sqlCommand.Parameters.Add("@PAYMENTAGENTNM", SqlDbType.NVarChar);
                    //SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                    //// ↑ 20070907 980081 c
                    //SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    //// ↑ 20061222 18322 c
                    //// ↓ 20070907 980081 a
                    //SqlParameter paraCustClaimCode = sqlCommand.Parameters.Add("@CUSTCLAIMCODE", SqlDbType.Int);
                    //SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    //SqlParameter paraMinSectionCode = sqlCommand.Parameters.Add("@MINSECTIONCODE", SqlDbType.Int);
                    //SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    //SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    //SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    //SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    //SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    //SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                    //SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                    //SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    //SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    //SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    //SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    //SqlParameter paraTextExtraDate = sqlCommand.Parameters.Add("@TEXTEXTRADATE", SqlDbType.Int);
                    //// ↑ 20070907 980081 a
                #endregion
                #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                    SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraMinSectionCode = sqlCommand.Parameters.Add("@MINSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraPaymentMoneyKindCode = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDCODE", SqlDbType.Int);
                    SqlParameter paraPaymentMoneyKindName = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDNAME", SqlDbType.NVarChar);
                    SqlParameter paraPaymentMoneyKindDiv = sqlCommand.Parameters.Add("@PAYMENTMONEYKINDDIV", SqlDbType.Int);
                    SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraRebatePayment = sqlCommand.Parameters.Add("@REBATEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                    SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    // ↑ 2007.11.02 980081 c
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                    // ↓ 2007.11.02 980081 c
                #region 旧レイアウト(コメントアウト)
                    //paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDataWork.CreateDateTime);
                    //paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDataWork.UpdateDateTime);
                    //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.EnterpriseCode);
                    //paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentDataWork.FileHeaderGuid);
                    //paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdEmployeeCode);
                    //paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdAssemblyId1);
                    //paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdAssemblyId2);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.LogicalDeleteCode);
                    //
                    //// ↓ 20061222 18322 c 携帯.NS用に変更
                    ////paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentSlipNo);
                    ////paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.SupplierCd);
                    ////paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.Payment);
                    ////paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.DiscountPayment);
                    ////paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.FeePayment);
                    ////paraOutline.Value = SqlDataMediator.SqlSetString(paymentDataWork.Outline);
                    ////paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInpSectionCd);
                    ////paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.PaymentDate);
                    ////paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.AddUpSecCode);
                    ////paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.AddUpADate);
                    ////paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdateSecCd);
                    ////paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftDrawingDate);
                    ////paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftPayTimeLimit);
                    ////paraPaymentMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindCode);
                    ////paraPaymentMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindDiv);
                    ////paraPaymentMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentMoneyKindName);
                    //////paraPaymentDivNm.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentDivNm);
                    ////paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.CreditOrLoanCd);
                    ////paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.CreditCompanyCode);
                    ////paraPaymenttotal.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.PaymentTotal);
                    //
                    //paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DebitNoteDiv);
                    //paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentSlipNo);
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.SupplierCd);
                    //paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentDataWork.SupplierNm1);
                    //paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentDataWork.SupplierNm2);
                    //paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInpSectionCd);
                    //paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.AddUpSecCode);
                    //paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.UpdateSecCd);
                    //paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.PaymentDate);
                    //paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.AddUpADate);
                    //paraPaymentMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindCode);
                    //paraPaymentMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentMoneyKindName);
                    //paraPaymentMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.PaymentMoneyKindDiv);
                    //paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.PaymentTotal);
                    //paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.Payment);
                    //paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.FeePayment);
                    //paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.DiscountPayment);
                    //paraRebatePayment.Value = SqlDataMediator.SqlSetInt64(paymentDataWork.RebatePayment);
                    //paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.AutoPayment);
                    //paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.CreditOrLoanCd);
                    //paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.CreditCompanyCode);
                    //paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftDrawingDate);
                    //paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.DraftPayTimeLimit);
                    //paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DebitNoteLinkPayNo);
                    //paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentAgentCode);
                    //// ↓ 20070907 980081 c
                    ////paraPaymentAgentNm.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentAgentNm);
                    //paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentAgentName);
                    //// ↑ 20070907 980081 c
                    //paraOutline.Value = SqlDataMediator.SqlSetString(paymentDataWork.Outline);
                    //// ↑ 20061222 18322 c
                    //// ↓ 20070907 980081 a
                    //paraCustClaimCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.CustClaimCode);
                    //paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.SubSectionCode);
                    //paraMinSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.MinSectionCode);
                    //paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DraftKind);
                    //paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentDataWork.DraftKindName);
                    //paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.DraftDivide);
                    //paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentDataWork.DraftDivideName);
                    //paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentDataWork.DraftNo);
                    //paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInputAgentCd);
                    //paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentDataWork.PaymentInputAgentNm);
                    //paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.BankCode);
                    //paraBankName.Value = SqlDataMediator.SqlSetString(paymentDataWork.BankName);
                    //paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.EdiSendDate);
                    //paraEdiTakeInDate.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.EdiTakeInDate);
                    //paraTextExtraDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.TextExtraDate);
                    //// ↑ 20070907 980081 a
                #endregion
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteDiv);
                    paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierSlipNo);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierSnm);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PayeeCode);
                    paraPayeeName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName);
                    paraPayeeName2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName2);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeSnm);
                    paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInpSectionCd);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.AddUpSecCode);
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdateSecCd);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SubSectionCode);
                    paraMinSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.MinSectionCode);
                    // ↓ 2008.03.14 980081 c
                    //paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDataWork.PaymentDate);
                    paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                    // ↑ 2008.03.14 980081 c
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.AddUpADate);
                    paraPaymentMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentMoneyKindCode);
                    paraPaymentMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentMoneyKindName);
                    paraPaymentMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentMoneyKindDiv);
                    paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.PaymentTotal);
                    paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.Payment);
                    paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.FeePayment);
                    paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.DiscountPayment);
                    paraRebatePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.RebatePayment);
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.AutoPayment);
                    paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.CreditOrLoanCd);
                    paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.CreditCompanyCode);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftDrawingDate);
                    paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftPayTimeLimit);
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftKind);
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftKindName);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftDivide);
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftDivideName);
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftNo);
                    paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                    paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentCode);
                    paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentName);
                    paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentCd);
                    paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentNm);
                    paraOutline.Value = SqlDataMediator.SqlSetString(paymentSlpWork.Outline);
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.BankCode);
                    paraBankName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.BankName);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.EdiSendDate);
                    // ↓ 2007.12.10 980081 c
                    //paraEdiTakeInDate.Value = SqlDataMediator.SqlSetInt32(paymentDataWork.EdiTakeInDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.EdiTakeInDate);
                    // ↑ 2007.12.10 980081 c
                    // ↑ 2007.11.02 980081 c
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
# endif
                # endregion

                //--- ADD 2008/04/22 M.Kubota --->>>
                # region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  PAY.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PAY.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS PAY" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  PAY.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND PAY.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                    if (_updateDateTime != paymentSlpWork.UpdateDateTime)
                    {
                        if (paymentSlpWork.UpdateDateTime == DateTime.MinValue)
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
                    // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    // 支払データを更新する前に、送信済みのチェックを行う
                    if (!CheckPaymentSlpSending(paymentSlpWork))
                    {
                        // チェックNG
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                                myReader.Close();
                            myReader.Dispose();
                        }
                        return STATUS_CHK_SEND_ERR;
                    }
                    // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                    //if (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1)  // DEL 2009/04/28
                    if (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData3)  // ADD 2009/04/28
                    {
                        // 論理削除区分が 3 の場合は削除処理を行う
                        # region [DELETE文]
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PAYMENTSLPRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                        # endregion

                        deleteSql = true;
                    }
                    else
                    {
                        // 論理削除区分が 0 の場合は更新処理を行う
                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE PAYMENTSLPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEDIVRF = @DEBITNOTEDIV" + Environment.NewLine;
                        sqlText += " ,PAYMENTSLIPNORF = @PAYMENTSLIPNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERFORMALRF = @SUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNORF = @SUPPLIERSLIPNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM1RF = @SUPPLIERNM1" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM2RF = @SUPPLIERNM2" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSNMRF = @SUPPLIERSNM" + Environment.NewLine;
                        sqlText += " ,PAYEECODERF = @PAYEECODE" + Environment.NewLine;
                        sqlText += " ,PAYEENAMERF = @PAYEENAME" + Environment.NewLine;
                        sqlText += " ,PAYEENAME2RF = @PAYEENAME2" + Environment.NewLine;
                        sqlText += " ,PAYEESNMRF = @PAYEESNM" + Environment.NewLine;
                        sqlText += " ,PAYMENTINPSECTIONCDRF = @PAYMENTINPSECTIONCD" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,UPDATESECCDRF = @UPDATESECCD" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,INPUTDAYRF = @INPUTDAY" + Environment.NewLine;         // ADD 2009/03/25
                        sqlText += " ,PAYMENTDATERF = @PAYMENTDATE" + Environment.NewLine;  
                        sqlText += " ,ADDUPADATERF = @ADDUPADATE" + Environment.NewLine;
                        sqlText += " ,PAYMENTTOTALRF = @PAYMENTTOTAL" + Environment.NewLine;
                        sqlText += " ,PAYMENTRF = @PAYMENT" + Environment.NewLine;
                        sqlText += " ,FEEPAYMENTRF = @FEEPAYMENT" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPAYMENTRF = @DISCOUNTPAYMENT" + Environment.NewLine;
                        sqlText += " ,AUTOPAYMENTRF = @AUTOPAYMENT" + Environment.NewLine;
                        sqlText += " ,DRAFTDRAWINGDATERF = @DRAFTDRAWINGDATE" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDRF = @DRAFTKIND" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDNAMERF = @DRAFTKINDNAME" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDERF = @DRAFTDIVIDE" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDENAMERF = @DRAFTDIVIDENAME" + Environment.NewLine;
                        sqlText += " ,DRAFTNORF = @DRAFTNO" + Environment.NewLine;
                        sqlText += " ,DEBITNOTELINKPAYNORF = @DEBITNOTELINKPAYNO" + Environment.NewLine;
                        sqlText += " ,PAYMENTAGENTCODERF = @PAYMENTAGENTCODE" + Environment.NewLine;
                        sqlText += " ,PAYMENTAGENTNAMERF = @PAYMENTAGENTNAME" + Environment.NewLine;
                        sqlText += " ,PAYMENTINPUTAGENTCDRF = @PAYMENTINPUTAGENTCD" + Environment.NewLine;
                        sqlText += " ,PAYMENTINPUTAGENTNMRF = @PAYMENTINPUTAGENTNM" + Environment.NewLine;
                        sqlText += " ,OUTLINERF = @OUTLINE" + Environment.NewLine;
                        sqlText += " ,BANKCODERF = @BANKCODE" + Environment.NewLine;
                        sqlText += " ,BANKNAMERF = @BANKNAME" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                        # endregion

                        //更新ヘッダ情報を設定
                        int logicalDeleteCode = paymentSlpWork.LogicalDeleteCode; // 2009/04/28

                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentSlpWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        paymentSlpWork.LogicalDeleteCode = logicalDeleteCode; // 2009/04/28
                    }

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (paymentSlpWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTSLPRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,PAYEECODERF" + Environment.NewLine;
                    sqlText += " ,PAYEENAMERF" + Environment.NewLine;
                    sqlText += " ,PAYEENAME2RF" + Environment.NewLine;
                    sqlText += " ,PAYEESNMRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,UPDATESECCDRF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;    //ADD 2009/03/25
                    sqlText += " ,PAYMENTDATERF" + Environment.NewLine;
                    sqlText += " ,ADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,PAYMENTTOTALRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTRF" + Environment.NewLine;
                    sqlText += " ,FEEPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,DISCOUNTPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,AUTOPAYMENTRF" + Environment.NewLine;
                    sqlText += " ,DRAFTDRAWINGDATERF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDRF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDENAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTNORF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTELINKPAYNORF" + Environment.NewLine;
                    sqlText += " ,PAYMENTAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,PAYMENTAGENTNAMERF" + Environment.NewLine;
                    sqlText += " ,PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
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
                    sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                    sqlText += " ,@PAYMENTSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM1" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERNM2" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@PAYEECODE" + Environment.NewLine;
                    sqlText += " ,@PAYEENAME" + Environment.NewLine;
                    sqlText += " ,@PAYEENAME2" + Environment.NewLine;
                    sqlText += " ,@PAYEESNM" + Environment.NewLine;
                    sqlText += " ,@PAYMENTINPSECTIONCD" + Environment.NewLine;
                    sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += " ,@UPDATESECCD" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@INPUTDAY" + Environment.NewLine;     //ADD 2009/03/25
                    sqlText += " ,@PAYMENTDATE" + Environment.NewLine;
                    sqlText += " ,@ADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@PAYMENTTOTAL" + Environment.NewLine;
                    sqlText += " ,@PAYMENT" + Environment.NewLine;
                    sqlText += " ,@FEEPAYMENT" + Environment.NewLine;
                    sqlText += " ,@DISCOUNTPAYMENT" + Environment.NewLine;
                    sqlText += " ,@AUTOPAYMENT" + Environment.NewLine;
                    sqlText += " ,@DRAFTDRAWINGDATE" + Environment.NewLine;
                    sqlText += " ,@DRAFTKIND" + Environment.NewLine;
                    sqlText += " ,@DRAFTKINDNAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDE" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDENAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTNO" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTELINKPAYNO" + Environment.NewLine;
                    sqlText += " ,@PAYMENTAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@PAYMENTAGENTNAME" + Environment.NewLine;
                    sqlText += " ,@PAYMENTINPUTAGENTCD" + Environment.NewLine;
                    sqlText += " ,@PAYMENTINPUTAGENTNM" + Environment.NewLine;
                    sqlText += " ,@OUTLINE" + Environment.NewLine;
                    sqlText += " ,@BANKCODE" + Environment.NewLine;
                    sqlText += " ,@BANKNAME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    # endregion

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)paymentSlpWork;
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
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                    SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInpSectionCd = sqlCommand.Parameters.Add("@PAYMENTINPSECTIONCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);      //ADD 2009/03/25
                    SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraPaymentTotal = sqlCommand.Parameters.Add("@PAYMENTTOTAL", SqlDbType.BigInt);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraFeePayment = sqlCommand.Parameters.Add("@FEEPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraDiscountPayment = sqlCommand.Parameters.Add("@DISCOUNTPAYMENT", SqlDbType.BigInt);
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDebitNoteLinkPayNo = sqlCommand.Parameters.Add("@DEBITNOTELINKPAYNO", SqlDbType.Int);
                    SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@PAYMENTAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraPaymentAgentName = sqlCommand.Parameters.Add("@PAYMENTAGENTNAME", SqlDbType.NVarChar);
                    SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraPaymentInputAgentNm = sqlCommand.Parameters.Add("@PAYMENTINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    # endregion

                    # region Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteDiv);
                    paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierSlipNo);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.SupplierSnm);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PayeeCode);
                    paraPayeeName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName);
                    paraPayeeName2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeName2);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PayeeSnm);
                    paraPaymentInpSectionCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInpSectionCd);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.AddUpSecCode);
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdateSecCd);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SubSectionCode);
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.InputDay);      //ADD 2009/03/25
                    paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.PaymentDate);
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.AddUpADate);
                    paraPaymentTotal.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.PaymentTotal);
                    paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.Payment);
                    paraFeePayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.FeePayment);
                    paraDiscountPayment.Value = SqlDataMediator.SqlSetInt64(paymentSlpWork.DiscountPayment);
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.AutoPayment);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentSlpWork.DraftDrawingDate);
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftKind);
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftKindName);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DraftDivide);
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftDivideName);
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(paymentSlpWork.DraftNo);
                    paraDebitNoteLinkPayNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                    paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentCode);
                    paraPaymentAgentName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentAgentName);
                    paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentCd);
                    paraPaymentInputAgentNm.Value = SqlDataMediator.SqlSetString(paymentSlpWork.PaymentInputAgentNm);
                    paraOutline.Value = SqlDataMediator.SqlSetString(paymentSlpWork.Outline);
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.BankCode);
                    paraBankName.Value = SqlDataMediator.SqlSetString(paymentSlpWork.BankName);
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

                //--- ADD 2008/04/22 M.Kubota ---<<<
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

        /// <summary>
        /// 支払明細データを更新します。
        /// </summary>
        /// <param name="paymentSlpWork"></param>
        /// <param name="paymentDtlWorkArray"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int WritePaymentDtlWorkRec(PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  PAYMENTDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);

                sqlCommand.ExecuteNonQuery();

                // 2009/04/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) 
                if ((paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) ||
                     (paymentSlpWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1))
                // 2009/04/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    sqlCommand.Parameters.Clear();

                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTDTLRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTSLIPNORF" + Environment.NewLine;
                    sqlText += " ,PAYMENTROWNORF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += " ,PAYMENTRF" + Environment.NewLine;
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
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@PAYMENTSLIPNO" + Environment.NewLine;
                    sqlText += " ,@PAYMENTROWNO" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += " ,@PAYMENT" + Environment.NewLine;
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
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                    SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
                    SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                    SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                    SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                    SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    # endregion

                    foreach (PaymentDtlWork paymentDtlWork in paymentDtlWorkArray)
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        paymentDtlWork.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode; // 2009/04/28 伝票の論理削除区分をセット

                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.LogicalDeleteCode);
                        paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.SupplierFormal);
                        paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.PaymentSlipNo);
                        paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.PaymentRowNo);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(paymentDtlWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(paymentDtlWork.MoneyKindDiv);
                        paraPayment.Value = SqlDataMediator.SqlSetInt64(paymentDtlWork.Payment);
                        paraValidityTerm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentDtlWork.ValidityTerm);
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
        /// 支払伝票番号を採番して返します
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="AddUpSecCode">計上拠点コード</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払伝票番号を採番して返します</br>
        /// <br>Programmer : 95089 岩本　勇</br>
        /// <br>Date       : 2005.08.03</br>
        /// </remarks>	
        private int CreatePaymentSlipNoProc(string EnterpriseCode, string AddUpSecCode, out int paymentSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            paymentSlipNo = 0;
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
                //status = numberNumbering.Numbering(EnterpriseCode, AddUpSecCode, 52, new string[0], out no, out ptnCd, out retMsg);  //DEL 2008/04/25 M.Kubota
                status = numberingManager.GetSerialNumber(EnterpriseCode, AddUpSecCode, SerialNumberCode.PaymentSlipNo, out no);  //ADD 2008/04/25 M.Kubota
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //番号を数値型に変換
                    Int32 wkDepositSlipNo = System.Convert.ToInt32(no);  // Int32 ← Int64 で変換
                    SqlDataReader myReader = null;
                    
                    //支払空き番チェック
                    try
                    {
                        //Selectコマンドの生成
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT PAYMENTSLIPNORF FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO", sqlConnection, sqlTransaction))
                        {

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                            findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(wkDepositSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //データ無しの場合には戻り値をセット
                            if (!myReader.Read())
                            {
                                paymentSlipNo = wkDepositSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        //基底クラスに例外を渡して処理してもらう
                        //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/22 M.Kubota

                        //--- ADD 2008/04/24 M.Kubota --->>>
                        string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                        //--- ADD 2008/04/24 M.Kubota ---<<<
                    }
                    finally
                    {
                        //if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close();  //DEL 2008/04/24 M.Kubota
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
                //retMsg = "支払番号に空き番号がありません。削除可能な支払伝票を削除してください。";  //DEL 2008/04/25 M.Kubota
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }

        # region --- DEL 2008/04/24 M.Kubota ---
# if false

        /// <summary>
        /// 支払更新処理メイン
        /// </summary>
        /// <param name="paymentDataWork">支払情報ワーク</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報を元にデータ更新を行います</br>
        /// <br>           : 支払番号無しの時、新規支払作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います(引当のみの削除可能)</br>
        /// <br>Programmer : 95089 岩本　勇</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int WritePaymentSlpWork(ref PaymentDataWork paymentDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int paymentSlipNo = 0;
            PaymentSlpWork bf_PaymentSlpWork = null;     // 更新前支払伝票情報
            bool mode_new = false;					     // 新規支払モード

            // 新規支払作成時
            if (paymentDataWork.PaymentSlipNo == 0)
            {
                mode_new = true;							// 新規支払モード

                // 支払伝票番号の採番
                //status = CreatePaymentSlipNoProc(paymentDataWork.EnterpriseCode, paymentDataWork.AddUpSecCode, out paymentSlipNo, ref sqlConnection, ref sqlTransaction);//20060926 iwa del
                status = CreatePaymentSlipNoProc(paymentDataWork.EnterpriseCode, paymentDataWork.UpdateSecCd, out paymentSlipNo, ref sqlConnection, ref sqlTransaction);//20060926 iwa add

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 採番した支払番号を支払情報にセット
                paymentDataWork.PaymentSlipNo = paymentSlipNo;

            }
            // 支払修正時
            else
            {
                // 更新前支払情報取得
                status = ReadPaymentSlpWorkRec(paymentDataWork.EnterpriseCode, paymentDataWork.PaymentSlipNo, out bf_PaymentSlpWork, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }


            // 支払データ更新
            status = WritePaymentSlpWorkRec(mode_new, ref paymentDataWork, ref sqlConnection, ref sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // 支払明細デ－タ更新

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ↓ 20070327 18322 c 仕入先支払（買掛）金額マスタの更新は
            //                     準備処理で行うことになった為、削除
        #region 仕入先支払（買掛）金額マスタの更新（全てコメントアウト）
            //// 金額マスタ更新 >>>>>>>>
            //UpdateSuplAccPayPayRec updateSuplAccPayPayRec = new UpdateSuplAccPayPayRec();
            //
            //SuplAccUpdatePara bf_suplAccUpdatePara = new SuplAccUpdatePara();						// 金額減算レコード
            //SuplAccUpdatePara af_suplAccUpdatePara = new SuplAccUpdatePara();						// 金額加算レコード
            //
            //ArrayList suplAccUpdateParas = new ArrayList();											// 金額マスタ更新部品パラメータ
            //
            //// 追加レコード
            //if (paymentDataWork.LogicalDeleteCode == 0)												// 削除時以外
            //{
            //	af_suplAccUpdatePara.AddDel = 0;													// 追加削除区分:追加０
            //    af_suplAccUpdatePara.AddUpADate         = paymentDataWork.AddUpADate;				// 計上日付
            //
            //    // ↓ 20061222 18322 c 携帯.NS用に変更
            //    #region SF 支払額・支払値引額取得(コメントアウト)
            //    //af_suplAccUpdatePara.AddUpSeccode       = paymentDataWork.AddUpSecCode;				// 請求計上拠点コード
            //
            //    //af_suplAccUpdatePara.Payment            = paymentDataWork.PaymentTotal;                   //支払額
            //    //af_suplAccUpdatePara.DiscountPayment    = paymentDataWork.DiscountPayment;           //支払値引き
            //    #endregion
            //
            //    #region MA.NS 今回支払額等を設定
            //    // 得意先コード
            //    af_suplAccUpdatePara.SupplierCd  = paymentDataWork.SupplierCd ;
            //    // 得意先名
            //    af_suplAccUpdatePara.SupplierNm1  = paymentDataWork.SupplierNm1 ;
            //    // 得意先名2
            //    af_suplAccUpdatePara.SupplierNm2 = paymentDataWork.SupplierNm2;
            //
            //    // 計上拠点コード           <- 請求計上拠点コード
            //    af_suplAccUpdatePara.AddUpSecCode = paymentDataWork.AddUpSecCode;
            //    // 今回支払金額（通常支払） <- 支払額
            //    af_suplAccUpdatePara.ThisTimePayNrml = paymentDataWork.Payment;
            //    // 今回手数料額（通常支払） <- 手数料支払額
            //    af_suplAccUpdatePara.ThisTimeFeePayNrml = paymentDataWork.FeePayment;
            //    // 今回値引額（通常支払）   <- 支払値引き
            //    af_suplAccUpdatePara.ThisTimeDisPayNrml = paymentDataWork.DiscountPayment;
            //    // 今回リベート額（通常支払）<- リベート支払額
            //    af_suplAccUpdatePara.ThisTimeRbtPayNrml = paymentDataWork.RebatePayment;
            //    #endregion
            //    // ↑ 20061222 18322 c
            //
            //    suplAccUpdateParas.Add(af_suplAccUpdatePara);										// パラメータ追加
            //}
            //
            //// 削除レコード
            //if(mode_new == false)																	// 支払修正時＞削除レコードも追加
            //{
            //	bf_suplAccUpdatePara.AddDel = 1;													// 追加削除区分:削除１
            //    bf_suplAccUpdatePara.AddUpADate         = bf_PaymentSlpWork.AddUpADate;				// 計上日付
            //
            //    // ↓ 20061222 18322 c 携帯.NS用に変更
            //    #region SF 支払額・支払値引額取得(コメントアウト)
            //    //bf_suplAccUpdatePara.AddUpSeccode       = bf_PaymentSlpWork.AddUpSecCode;			// 請求計上拠点コード
            //    //
            //    //bf_suplAccUpdatePara.Payment            = bf_PaymentSlpWork.PaymentTotal;                //支払額
            //    //bf_suplAccUpdatePara.DiscountPayment    = bf_PaymentSlpWork.DiscountPayment;        //支払値引き
            //    #endregion
            //
            //    #region MA.NS 今回支払額等を設定
            //    // 得意先コード
            //    bf_suplAccUpdatePara.SupplierCd  = bf_PaymentSlpWork.SupplierCd ;
            //    // 得意先名
            //    bf_suplAccUpdatePara.SupplierNm1  = bf_PaymentSlpWork.SupplierNm1 ;
            //    // 得意先名2
            //    bf_suplAccUpdatePara.SupplierNm2 = bf_PaymentSlpWork.SupplierNm2;
            //    // 計上拠点コード           <- 請求計上拠点コード
            //    bf_suplAccUpdatePara.AddUpSecCode = bf_PaymentSlpWork.AddUpSecCode;
            //    // 今回支払金額（通常支払） <- 支払額
            //    bf_suplAccUpdatePara.ThisTimePayNrml = bf_PaymentSlpWork.Payment;
            //    // 今回手数料額（通常支払） <- 手数料支払額
            //    bf_suplAccUpdatePara.ThisTimeFeePayNrml = bf_PaymentSlpWork.FeePayment;
            //    // 今回値引額（通常支払）   <- 支払値引き
            //    bf_suplAccUpdatePara.ThisTimeDisPayNrml = bf_PaymentSlpWork.DiscountPayment;
            //    // 今回リベート額（通常支払）<- リベート支払額
            //    bf_suplAccUpdatePara.ThisTimeRbtPayNrml = bf_PaymentSlpWork.RebatePayment;
            //    #endregion
            //    // ↑ 20061222 18322 c
            //
            //    suplAccUpdateParas.Add(bf_suplAccUpdatePara);										// パラメータ追加
            //}
            //
            //SuplAccUpdatePara[] SuplAccUpdateParaArray = (SuplAccUpdatePara[])suplAccUpdateParas.ToArray(typeof(SuplAccUpdatePara));
            //
            //// 金額マスタ更新処理
            //status = updateSuplAccPayPayRec.Write(paymentDataWork.EnterpriseCode, paymentDataWork.SupplierCd, SuplAccUpdateParaArray, ref sqlConnection, ref sqlTransaction);
        #endregion
            // ↑ 20070327 18322 c 

            return status;
        }

# endif
        # endregion

        # endregion

        # region [読込処理]

        /// <summary>
		/// 支払読込処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="PaymentSlipNo">支払番号</param>
		/// <param name="paymentDataWorkByte">支払情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 支払情報を支払番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int Read(string EnterpriseCode, int PaymentSlipNo, out byte[] paymentDataWorkByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            //PaymentSlpWork paymentSlpWork = new PaymentSlpWork();  //DEL 2008/04/24 M.Kubota

            paymentDataWorkByte = null;

            //--- ADD 2008/04/24 M.Kubota --->>>
            PaymentDataWork paymentDataWork = null;
            PaymentSlpWork paymentSlpWork = null;
            PaymentDtlWork[] paymentDtlWorkArray = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            //--- ADD 2008/04/24 M.Kubota ---<<<

            try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                //ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                ////SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                ////sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                # endregion

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    errmsg += ": データベースへの接続に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<

                // 支払読込み処理
                //status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/24 M.Kubota
                status = this.Read(EnterpriseCode, PaymentSlipNo, out paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);  //ADD 2008/04/24 M.Kubota

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                }

                # region --- DEL 2008/04/24 M.Kubota ---
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    sqlTransaction.Commit();
                //else
                //    sqlTransaction.Rollback();
                # endregion
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/24 M.Kubota ---<<<
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
            //paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);  //DEL 2008/04/24 M.Kubota
            paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);   //ADD 2008/04/24 M.Kubota

			return status;
        }

        /// <summary>
        /// 支払伝票＋支払明細データ読み込み処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="paymentSlpWork">支払伝票データ</param>
        /// <param name="paymentDtlWorkArray">支払明細データの配列</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int Read(string EnterpriseCode, int paymentSlipNo, out PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            paymentSlpWork = new PaymentSlpWork();
            paymentDtlWorkArray = new PaymentDtlWork[0];

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメータチェック]

                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報が未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (string.IsNullOrEmpty(EnterpriseCode))
                {
                    errmsg += ": 企業コードが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (paymentSlipNo < 1)
                {
                    errmsg += ": 支払伝票番号が未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                // 支払伝票の読み込み
                status = this.ReadPaymentSlpWorkRec(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- ADD 2012/11/07 ---------->>>>>
                    // 値引or手数料のみのデータで赤伝発行する場合は明細が無い為、
                    // 明細データ読込をスキップする
                    if (paymentSlpWork.Payment == 0 &&
                         (paymentSlpWork.FeePayment != 0 || paymentSlpWork.DiscountPayment != 0))
                    {
                    }
                    else
                    {
                        // 既存の明細読込処理
                    // 支払明細の読み込み
                    status = this.ReadPaymentDtlWorkRec(paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);
                    }
                    // --- ADD 2012/11/07 ----------<<<<<
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
                return status;
            }

            return status;
        }
 
        /// <summary>
        /// 支払マスタ情報を取得します
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <param name="paymentSlpWork">支払情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払マスタ情報を支払番号を元にデータ取得を行います</br>
        /// <br>Programmer : 95089 岩本　勇</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        private int ReadPaymentSlpWorkRec(string EnterpriseCode, int paymentSlipNo, out PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            paymentSlpWork = new PaymentSlpWork();

            try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                // ↓ 20061222 18322 c 携帯.NSのレイアウトにあわせ変更
                ////Selectコマンドの生成
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYMENTSLIPNORF, CUSTOMERCODERF, PAYMENTRF, DISCOUNTPAYMENTRF, FEEPAYMENTRF, OUTLINERF, PAYMENTINPSECTIONCDRF, PAYMENTDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, PAYMENTMONEYKINDCODERF, PAYMENTMONEYKINDDIVRF, PAYMENTMONEYKINDNAMERF, PAYMENTDIVNMRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF ,PAYMENTTOTALRF FROM PAYMENTSLPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO", sqlConnection, sqlTransaction))
                //string sqlCmd = "SELECT *"
                //              + " FROM PAYMENTSLPRF"
                //              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //              + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"
                //              ;
                # endregion

                # region [SELECT文]
                string sqlCmd = string.Empty;
                sqlCmd += "SELECT" + Environment.NewLine;
                sqlCmd += "  PAY.CREATEDATETIMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDATEDATETIMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.ENTERPRISECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlCmd += " ,PAY.LOGICALDELETECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERNM1RF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERNM2RF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUPPLIERSNMRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEECODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEENAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEENAME2RF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYEESNMRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.ADDUPSECCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.UPDATESECCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.SUBSECTIONCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.INPUTDAYRF" + Environment.NewLine;    //ADD 2009/03/25
                sqlCmd += " ,PAY.PAYMENTDATERF" + Environment.NewLine;
                sqlCmd += " ,PAY.ADDUPADATERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTTOTALRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.FEEPAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.AUTOPAYMENTRF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTKINDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTDIVIDERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.DRAFTNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlCmd += " ,PAY.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlCmd += " ,PAY.OUTLINERF" + Environment.NewLine;
                sqlCmd += " ,PAY.BANKCODERF" + Environment.NewLine;
                sqlCmd += " ,PAY.BANKNAMERF" + Environment.NewLine;
                sqlCmd += "FROM" + Environment.NewLine;
                sqlCmd += "  PAYMENTSLPRF AS PAY" + Environment.NewLine;
                sqlCmd += "WHERE" + Environment.NewLine;
                sqlCmd += "  PAY.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlCmd += "  AND PAY.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection, sqlTransaction))
                // ↑ 20061222 18322 c
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        # region --- DEL 2008/04/24 M.Kubota ---
                        # if false    
                        #region 支払伝票マスタクラスへ代入
                        // ↓ 2007.11.02 980081 c
                        #region 旧レイアウト(コメントアウト)
                        //paymentDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        //paymentDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //paymentDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        //paymentDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //paymentDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //paymentDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //paymentDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //paymentDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //
                        //// ↓ 20061222 18322 c 携帯.NS用に変更
                        ////paymentDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                        ////paymentDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        ////paymentDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        ////paymentDataWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                        ////paymentDataWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                        ////paymentDataWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        ////paymentDataWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                        ////paymentDataWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                        ////paymentDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        ////paymentDataWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        ////paymentDataWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        ////paymentDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        ////paymentDataWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        ////paymentDataWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                        ////paymentDataWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                        ////paymentDataWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                        ////paymentDataWork.PaymentDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTDIVNMRF"));
                        ////paymentDataWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        ////paymentDataWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        ////paymentDataWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                        //
                        //// 赤伝区分
                        //paymentDataWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                        //// 支払伝票番号
                        //paymentDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                        //// 得意先コード
                        //paymentDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        //// 得意先名称
                        //paymentDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        //// 得意先名称2
                        //paymentDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        //// 支払入力拠点コード
                        //paymentDataWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                        //// 計上拠点コード
                        //paymentDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        //// 更新拠点コード
                        //paymentDataWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        //// 支払日付
                        //paymentDataWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                        //// 計上日付
                        //paymentDataWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        //// 支払金種コード
                        //paymentDataWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                        //// 支払金種名称
                        //paymentDataWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                        //// 支払金種区分
                        //paymentDataWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                        //// 支払計
                        //paymentDataWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                        //// 支払金額
                        //paymentDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        //// 手数料支払額
                        //paymentDataWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                        //// 値引支払額
                        //paymentDataWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                        //// リベート支払額
                        //paymentDataWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                        //// 自動支払区分
                        //paymentDataWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                        //// クレジット／ローン区分
                        //paymentDataWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// クレジット会社コード
                        //paymentDataWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        //// 手形振出日
                        //paymentDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        //// 手形支払期日
                        //paymentDataWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        //// 赤黒支払連結番号
                        //paymentDataWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                        //// 支払担当者コード
                        //paymentDataWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                        //// 支払担当者名称
                        //// ↓ 20070907 980081 c
                        ////paymentDataWork.PaymentAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNMRF"));
                        //paymentDataWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                        //// ↑ 20070907 980081 c
                        //// 伝票摘要
                        //paymentDataWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        //// ↑ 20061222 18322 c
                        //// ↓ 20070907 980081 c
                        //// 得意先請求先コード
                        //paymentDataWork.CustClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCLAIMCODERF"));
                        //// 部門コード
                        //paymentDataWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        //// 課コード
                        //paymentDataWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        //// 手形種類
                        //paymentDataWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        //// 手形種類名称
                        //paymentDataWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        //// 手形区分
                        //paymentDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        //// 手形区分名称
                        //paymentDataWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        //// 手形番号
                        //paymentDataWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        //// 支払入力者コード
                        //paymentDataWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                        //// 支払入力者名称
                        //paymentDataWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                        //// 銀行コード
                        //paymentDataWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        //// 銀行名称
                        //paymentDataWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        //// ＥＤＩ送信日
                        //paymentDataWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        //// ＥＤＩ取込日
                        //paymentDataWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        //// テキスト抽出日
                        //paymentDataWork.TextExtraDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TEXTEXTRADATERF"));
                        //// ↑ 20070907 980081 c
                        #endregion
                        paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                        paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                        paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                        paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                        paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                        paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                        paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                        paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                        paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                        paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                        paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                        paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                        paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        paymentSlpWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                        paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        paymentSlpWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                        paymentSlpWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                        paymentSlpWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                        paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                        paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                        paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                        paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                        paymentSlpWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                        paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                        paymentSlpWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        paymentSlpWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        paymentSlpWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                        paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                        paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                        paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                        paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                        paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        paymentSlpWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        // ↓ 2007.12.10 980081 c
                        //paymentDataWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        paymentSlpWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        // ↑ 2007.12.10 980081 c
                        // ↑ 2007.11.02 980081 c
                        #endregion
                        # endif
                        # endregion
                        
                        this.ReadDataToPaymentSlp(ref paymentSlpWork, myReader);  //ADD 2008/04/24 M.Kubota

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        /// <summary>
        /// 支払明細データを読み込みます
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票データ</param>
        /// <param name="paymentDtlWorkArray">支払明細データの配列</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        private int ReadPaymentDtlWorkRec(PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            paymentDtlWorkArray = new PaymentDtlWork[0];

            ArrayList paymentDtlWorList = new ArrayList();

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                # region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  PDTL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PDTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,PDTL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,PDTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,PDTL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,PDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,PDTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,PDTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,PDTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,PDTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,PDTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,PDTL.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,PDTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTDTLRF AS PDTL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  PDTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND PDTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND PDTL.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);

                if (paymentSlpWork.DebitNoteDiv != 1)
                {
                    // 0:黒, 2:元黒の場合
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);
                }
                else
                {
                    // 1:赤 の場合
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.DebitNoteLinkPayNo);
                }

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    PaymentDtlWork paymentDtlWork = this.ReadDataToPaymentDtl(sqlDataReader);

                    if (paymentSlpWork.DebitNoteDiv == 1)
                    {
                        // 1:赤 の場合
                        paymentDtlWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
                        paymentDtlWork.Payment = paymentDtlWork.Payment * -1;
                    }

                    paymentDtlWorList.Add(paymentDtlWork);
                }

                if (paymentDtlWorList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    paymentDtlWorkArray = (PaymentDtlWork[])paymentDtlWorList.ToArray(typeof(PaymentDtlWork));
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
        /// 支払伝票マスタの読み込み結果を格納します
        /// </summary>
        /// <param name="sqlDataReader">支払伝票マスタの読み込み結果</param>
        /// <returns>支払伝票データ</returns>
        private PaymentSlpWork ReadDataToPaymentSlp(SqlDataReader sqlDataReader)
        {
            PaymentSlpWork paymentSlpWork = new PaymentSlpWork();
            this.ReadDataToPaymentSlp(ref paymentSlpWork, sqlDataReader);
            return paymentSlpWork;
        }

        /// <summary>
        /// 支払伝票マスタの読み込み結果を格納します
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票データ</param>
        /// <param name="sqlDataReader">支払伝票マスタの読込結果</param>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        private void ReadDataToPaymentSlp(ref PaymentSlpWork paymentSlpWork, SqlDataReader sqlDataReader)
        {
            try
            {
                #region [支払伝票マスタ 読込結果格納]
                paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));         // 作成日時
                paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));         // 更新日時
                paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));                    // 企業コード
                paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));                      // GUID
                paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));                  // 更新従業員コード
                paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));                    // 更新アセンブリID1
                paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));                    // 更新アセンブリID2
                paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));               // 論理削除区分
                paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTEDIVRF"));                         // 赤伝区分
                paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTSLIPNORF"));                       // 支払伝票番号
                paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERFORMALRF"));                     // 仕入形式
                paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERSLIPNORF"));                     // 仕入伝票番号
                paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERCDRF"));                             // 仕入先コード
                paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERNM1RF"));                          // 仕入先名1
                paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERNM2RF"));                          // 仕入先名2
                paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERSNMRF"));                          // 仕入先略称
                paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYEECODERF"));                               // 支払先コード
                paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYEENAMERF"));                              // 支払先名称
                paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYEENAME2RF"));                            // 支払先名称2
                paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYEESNMRF"));                                // 支払先略称
                paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));          // 支払入力拠点コード
                paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPSECCODERF"));                        // 計上拠点コード
                paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDATESECCDRF"));                          // 更新拠点コード
                paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUBSECTIONCODERF"));                     // 部門コード
                paymentSlpWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDAYRF"));                  // 入力日付  //ADD 2009/03/25
                paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTDATERF"));            // 支払日付
                paymentSlpWork.PrePaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTDATERF"));            // 支払日付 // ADD 2011/12/21
                paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPADATERF"));              // 計上日付
                paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTTOTALRF"));                         // 支払計
                paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTRF"));                                   // 支払金額
                paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("FEEPAYMENTRF"));                             // 手数料支払額
                paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DISCOUNTPAYMENTRF"));                   // 値引支払額
                paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("AUTOPAYMENTRF"));                           // 自動支払区分
                paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDRAWINGDATERF"));  // 手形振出日
                paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDRF"));                               // 手形種類
                paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDNAMERF"));                      // 手形種類名称
                paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDERF"));                           // 手形区分
                paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDENAMERF"));                  // 手形区分名称
                paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTNORF"));                                  // 手形番号
                paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTELINKPAYNORF"));             // 赤黒支払連結番号
                paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTAGENTCODERF"));                // 支払担当者コード
                paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTAGENTNAMERF"));                // 支払担当者名称
                paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));          // 支払入力者コード
                paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));          // 支払入力者名称
                paymentSlpWork.Outline = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("OUTLINERF"));                                  // 伝票摘要
                paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("BANKCODERF"));                                 // 銀行コード
                paymentSlpWork.BankName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("BANKNAMERF"));                                // 銀行名称
                # endregion
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
        }

        /// <summary>
        /// 支払明細データの読み込み結果を格納します。
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private PaymentDtlWork ReadDataToPaymentDtl(SqlDataReader sqlDataReader)
        {
            PaymentDtlWork paymentDtlWork = new PaymentDtlWork();
            this.ReadDataToPaymentDtl(ref paymentDtlWork, sqlDataReader);
            return paymentDtlWork;
        }

        /// <summary>
        /// 支払明細データの読み込み結果を格納します。
        /// </summary>
        /// <param name="paymentDtlWork">支払明細データ</param>
        /// <param name="sqlDataReader">支払明細データの読込結果</param>
        private void ReadDataToPaymentDtl(ref PaymentDtlWork paymentDtlWork, SqlDataReader sqlDataReader)
        {
            try
            {
                # region [支払明細データ 読込結果格納]
                paymentDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                paymentDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                paymentDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
                paymentDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                paymentDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
                paymentDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
                paymentDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
                paymentDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
                paymentDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUPPLIERFORMALRF"));              // 仕入形式
                paymentDtlWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTSLIPNORF"));                // 支払伝票番号
                paymentDtlWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTROWNORF"));                  // 支払行番号
                paymentDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDCODERF"));                // 金種コード
                paymentDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDNAMERF"));               // 金種名称
                paymentDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDDIVRF"));                  // 金種区分
                paymentDtlWork.Payment = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("PAYMENTRF"));                            // 支払金額
                paymentDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("VALIDITYTERMRF"));   // 有効期限
                # endregion
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
        }

        # region --- DEL 2008/04/24 M.Kubota ---
# if false
        /// <summary>
        /// 支払読込処理メイン
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="PaymentSlipNo">支払番号</param>
        /// <param name="paymentDataWork">支払情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払情報・支払引当情報を支払番号を元にデータ取得を行います</br>
        /// <br>Programmer : 95089 岩本　勇</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int ReadPaymentSlpWork(string EnterpriseCode, int PaymentSlipNo, out PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            paymentSlpWork = new PaymentSlpWork();

            // 支払マスタ読込処理
            status = ReadPaymentSlpWorkRec(EnterpriseCode, PaymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

            return status;
        }
# endif
        # endregion

        # endregion

        # region [論理削除処理]

        // ↓ 2008.01.11 980081 a
        /// <summary>
        /// 支払論理削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払番号の支払情報論理削除を行います</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string enterpriseCode, int paymentSlipNo)
        {
            byte[] paymentDataWorkByte;

            int status = LogicalDelete(enterpriseCode, paymentSlipNo, out paymentDataWorkByte);

            return status;
        }

        /// <summary>
        /// 支払論理削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払番号の支払情報論理削除を行います</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string enterpriseCode, int paymentSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            byte[] paymentDataWorkByte;

            int status = LogicalDelete(enterpriseCode, paymentSlipNo, out paymentDataWorkByte, ref sqlConnection, ref sqlTransaction);

            return status;
        }

        /// <summary>
        /// 支払論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <param name="paymentDataWorkByte">更新支払データ(赤削除時の元黒レコード)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払番号の支払情報論理削除を行います</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string EnterpriseCode, int paymentSlipNo, out byte[] paymentDataWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region --- DEL 2008/04/24 M.Kubota ---
            # if false
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            PaymentSlpWork paymentSlpWork = null;

            paymentDataWorkByte = null;

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
                //sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);//20061018 iwa add

                // 支払読込み処理
                status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // ↓ 20070213 18322 a MA.NS用に変更
                // 赤伝区分＝２(相殺済み黒)の場合はエラー
                if (paymentSlpWork.DebitNoteDiv == 2)
                {
                    // UI仕様上、同時更新時に発生する可能性があるため、排他エラーで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }
                // ↑ 20070213 18322 a

                // 更新時ロック処理
                int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, SupplierCdList, null);	// 得意先別ロックをかける

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // 論理削除を立てる（更新処理内部で物理削除処理・引当更新処理が実行される）
                if (paymentSlpWork != null)
                    paymentSlpWork.LogicalDeleteCode = 1;

                // 支払マスタ更新処理
                status = LogicalDeletePaymentSlpWork(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                // ↓ 20070213 18322 a MA.NS用に変更
                // 赤入金の削除の場合、元黒の入金・引当情報の更新を行う(赤相殺の区分関連をクリアする)
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                   (paymentSlpWork.DebitNoteDiv == 1))
                {
                    // 赤伝削除

                    // 支払読込み処理(赤相殺されていた支払伝票)
                    status = ReadPaymentSlpWork(EnterpriseCode
                                               , paymentSlpWork.DebitNoteLinkPayNo
                                               , out paymentSlpWork
                                               , ref sqlConnection
                                               , ref sqlTransaction);

                    // 赤伝区分をクリア
                    paymentSlpWork.DebitNoteDiv = 0;

                    // 元黒支払の赤黒連結番号をクリア
                    paymentSlpWork.DebitNoteLinkPayNo = 0;

                    // 元黒支払マスタ更新処理
                    status = LogicalDeletePaymentSlpWork(ref paymentSlpWork
                                                , ref sqlConnection
                                                , ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XMLへ変換し、文字列のバイナリ化
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);
                    }
                }
                // ↑ 20070213 18322 a

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
                controlExclusiveOrderAccess.UnlockDB();
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            # endif
            # endregion

            //--- ADD 2008/04/24 M.Kubota --->>>
            paymentDataWorkByte = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);

            try
            {
                status = this.LogicalDelete(EnterpriseCode, paymentSlipNo, out paymentDataWorkByte, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
                else
                {
                    sqlTransaction.Rollback();
                }
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
            //--- ADD 2008/04/24 M.Kubota ---<<<

            return status;
        }

        /// <summary>
        /// 支払論理削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <param name="paymentDataWorkByte">更新支払データ(赤削除時の元黒レコード)</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払番号の支払情報論理削除を行います</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        public int LogicalDelete(string EnterpriseCode, int paymentSlipNo, out byte[] paymentDataWorkByte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            PaymentSlpWork paymentSlpWork = null;
            PaymentDataWork paymentDataWork = null;       //ADD 2008/04/24 M.Kubota
            PaymentDtlWork[] paymentDtlWorkArray = null;  //ADD 2008/04/24 M.Kubota

            paymentDataWorkByte = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/24 M.Kubota

            try
            {
                // 支払読込み処理
                //status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/24 M.Kubota
                status = this.ReadPaymentSlpWorkRec(EnterpriseCode, paymentSlipNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/24 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // ↓ 20070213 18322 a MA.NS用に変更
                // 赤伝区分＝２(相殺済み黒)の場合はエラー
                if (paymentSlpWork.DebitNoteDiv == 2)
                {
                    // UI仕様上、同時更新時に発生する可能性があるため、排他エラーで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }
                // ↑ 20070213 18322 a

                # region --- DEL 2008/04/24 M.Kubota ---
                // 更新時ロック処理
                //int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, SupplierCdList, null);	// 得意先別ロックをかける

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                # endregion --- DEL 2008/04/24 M.Kubota ---

                // 論理削除を立てる（更新処理内部で物理削除処理・引当更新処理が実行される）
                if (paymentSlpWork != null)
                    paymentSlpWork.LogicalDeleteCode = 1;

                // 支払マスタ更新処理
                status = LogicalDeletePaymentSlpWork(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);
                if (STATUS_CHK_SEND_ERR == status) // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)
                    return status; // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)

                // ↓ 20070213 18322 a MA.NS用に変更
                // 赤入金の削除の場合、元黒の入金・引当情報の更新を行う(赤相殺の区分関連をクリアする)
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                   (paymentSlpWork.DebitNoteDiv == 1))
                {
                    // 赤伝削除

                    // 支払読込み処理(赤相殺されていた支払伝票)
                    # region --- DEL 2008/04/24 M.Kubota ---
                    //status = ReadPaymentSlpWork(EnterpriseCode
                    //                           , paymentSlpWork.DebitNoteLinkPayNo
                    //                           , out paymentSlpWork
                    //                           , ref sqlConnection
                    //                           , ref sqlTransaction);
                    # endregion --- DEL 2008/04/24 M.Kubota ---

                    status = this.ReadPaymentSlpWorkRec(EnterpriseCode, paymentSlpWork.DebitNoteLinkPayNo, out paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                    // 赤伝区分をクリア
                    paymentSlpWork.DebitNoteDiv = 0;

                    // 元黒支払の赤黒連結番号をクリア
                    paymentSlpWork.DebitNoteLinkPayNo = 0;

                    // 元黒支払マスタ更新処理
                    # region --- DEL 2008/04/24 M.Kubota ---
                    //status = LogicalDeletePaymentSlpWork(ref paymentSlpWork
                    //                            , ref sqlConnection
                    //                            , ref sqlTransaction);
                    # endregion --- DEL 2008/04/24 M.Kubota ---

                    //this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/24 M.Kubota //DEL 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)
                    if (STATUS_CHK_SEND_ERR == this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction)) // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)
                        return STATUS_CHK_SEND_ERR; // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)

                    # region --- DEL 2008/04/24 M.Kubota ---
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // XMLへ変換し、文字列のバイナリ化
                    //    paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);
                    //}
                    # endregion --- DEL 2008/04/24 M.Kubota ---
                }
                // ↑ 20070213 18322 a

                //--- ADD 2008/04/24 M.Kubota --->>>
                status = this.LogicalDeletePaymentDtlWork(paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                    paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<

            }
            # region --- DEL 2008/04/24 M.Kubota ---
            //catch (SqlException ex)
            //{
            //    //基底クラスに例外を渡して処理してもらう
            //    status = base.WriteSQLErrorLog(ex);
            //}
            # endregion --- DEL 2008/04/24 M.Kubota ---
            //--- ADD 2008/04/24 M.Kubota --->>>
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                return status;
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/24 M.Kubota
            }

            return status;
        }

        /// <summary>
        /// 支払マスタ情報を論理削除します
        /// </summary>
        /// <param name="paymentSlpWork">支払マスタ情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払情報を更新します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.11</br>
        private int LogicalDeletePaymentSlpWork(ref PaymentSlpWork paymentSlpWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            string updateText;

            // 更新日付を取得
            DateTime Upd_UpdateDateTime = paymentSlpWork.UpdateDateTime;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/24 M.Kubota

            //Selectコマンドの生成
            try
            {
                // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                // 支払データを更新する前に、送信済みのチェックを行う
                if (!CheckPaymentSlpSending(paymentSlpWork))
                {
                    // チェックNG
                    return STATUS_CHK_SEND_ERR;
                }
                // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                #region 支払マスタ UPDATE文
                // 更新日を更新検索キーに付加して更新（日付排他処理）
                updateText = "UPDATE PAYMENTSLPRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE"
                           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                             + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                             + " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO"
                             ;
                #endregion

                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)paymentSlpWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                    //Parameterオブジェクトへ値設定
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findParaPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);


                    #region 支払マスタ Parameterオブジェクトの作成(更新用)
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

                    #region 支払マスタ Parameterオブジェクトへ値設定(更新用)
                    // 作成日時
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.CreateDateTime);
                    // 更新日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    // 企業コード
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentSlpWork.FileHeaderGuid);
                    // 更新従業員コード
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    // 更新アセンブリID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    // 更新アセンブリID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    // 論理削除区分
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);
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
                # region --- DEL 2008/04/24 M.Kubota ---
                //if (myReader != null && !myReader.IsClosed) myReader.Close();
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);
                # endregion --- DEL 2008/04/24 M.Kubota ---

                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/24 M.Kubota
            }
            //--- ADD 2008/04/24 M.Kubota --->>>
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
            //--- ADD 2008/04/24 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/24 M.Kubota

            return status;
        }

        private int LogicalDeletePaymentDtlWork(PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            paymentDtlWorkArray = new PaymentDtlWork[0];

            // 更新日付を取得
            DateTime Upd_UpdateDateTime = paymentSlpWork.UpdateDateTime;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/24 M.Kubota

            try
            {
                # region [UPDATE文]
                string sqlText = string.Empty;
                sqlText += "UPDATE PAYMENTDTLRF" + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);


                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.EnterpriseCode);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.SupplierFormal);
                    findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.PaymentSlipNo);

                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentSlpWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentSlpWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentSlpWork.LogicalDeleteCode);

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

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.ReadPaymentDtlWorkRec(paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);
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
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }

        # endregion

        # region [削除処理]

        // ↑ 2008.01.11 980081 a

		/// <summary>
		/// 支払削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <param name="payDraftDataWorkByte">支払手形情報</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した支払番号の支払情報削除を行います</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int Delete(string EnterpriseCode, int paymentSlipNo)
        public int Delete(string EnterpriseCode, int paymentSlipNo, byte[] payDraftDataWorkByte)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
        {
			byte[] paymentDataWorkByte;

            // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
            //int status = Delete(EnterpriseCode, paymentSlipNo, out paymentDataWorkByte);
            int status = Delete(EnterpriseCode, paymentSlipNo, payDraftDataWorkByte, out paymentDataWorkByte);
            // --- UPD 2013/02/21 Y.Wakita ----------<<<<<

			return status;
		}

		/// <summary>
		/// 支払削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="paymentSlipNo">支払番号</param>
        /// <param name="payDraftDataWorkByte">支払手形情報</param>
        /// <param name="paymentDataWorkByte">更新支払データ(赤削除時の元黒レコード)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した支払番号の支払情報削除を行います</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //public int Delete(string EnterpriseCode, int paymentSlipNo, out byte[] paymentDataWorkByte)
        public int Delete(string EnterpriseCode, int paymentSlipNo, byte[] payDraftDataWorkByte, out byte[] paymentDataWorkByte)
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            PaymentSlpWork paymentSlpWork = null;

            PaymentDataWork paymentDataWork = null;       //ADD 2008/04/24 M.Kubota
            PaymentDtlWork[] paymentDtlWorkArray = null;  //ADD 2008/04/24 M.Kubota

            paymentDataWorkByte = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/24 M.Kubota
            
            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/24 M.Kubota

			try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                ////ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                ////SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                ////sqlTransaction = sqlConnection.BeginTransaction();//20061018 iwa del
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);//20061018 iwa add
                # endregion

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報の作成に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/24 M.Kubota ---<<<

                // 支払読込み処理
                //status = ReadPaymentSlpWork(EnterpriseCode, paymentSlipNo, out paymentSlpWork,  ref sqlConnection, ref sqlTransaction);       //DEL 2008/04/24 M.Kubota
                status = this.Read(EnterpriseCode, paymentSlipNo, out paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);    //ADD 2008/04/24 M.Kubota
                    
				if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					sqlTransaction.Rollback();
					sqlConnection.Close();
					sqlConnection.Dispose();

					return status;
				}

                // ↓ 20070213 18322 a MA.NS用に変更
				// 赤伝区分＝２(相殺済み黒)の場合はエラー
				if(paymentSlpWork.DebitNoteDiv == 2)
				{
					// UI仕様上、同時更新時に発生する可能性があるため、排他エラーで返す
					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					return status;
				}
                // ↑ 20070213 18322 a

                # region --- DEL 2008/04/24 M.Kubota ---
                //// 更新時ロック処理
                //int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, SupplierCdList, null);	// 得意先別ロックをかける

                //if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    sqlTransaction.Rollback();
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();

                //    return status;
                //}
                # endregion

                // 論理削除を立てる（更新処理内部で物理削除処理・引当更新処理が実行される）
                if (paymentSlpWork != null)
                    paymentSlpWork.LogicalDeleteCode = 1;

				// 支払マスタ更新処理
                //status = WritePaymentSlpWork(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);                //DEL 2008/04/24 M.Kubota
                status = this.Write(ref paymentSlpWork, ref paymentDtlWorkArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/24 M.Kubota

                // --- ADD 2013/02/21 Y.Wakita ---------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PayDraftDataWork payDraftDataWork = new PayDraftDataWork();
                    if (payDraftDataWorkByte != null)
                        payDraftDataWork = XmlByteSerializer.Deserialize(payDraftDataWorkByte, typeof(PayDraftDataWork)) as PayDraftDataWork;
                    else
                        payDraftDataWork = null;

                    // 支払手形データ更新処理
                    if (payDraftDataWork != null)
                    {
                        if (payDraftDataWork.PaymentRowNo != 0 && paymentSlpWork != null && paymentSlpWork.PaymentSlipNo != 0)
                        {
                            // 仕入形式
                            payDraftDataWork.SupplierFormal = 0;
                            // 支払伝票番号
                            payDraftDataWork.PaymentSlipNo = 0;
                            // 支払行番号
                            payDraftDataWork.PaymentRowNo = 0;
                            // 支払日付
                            string d, f;
                            DateTime dt;
                            d = payDraftDataWork.ProcDate.ToString();
                            f = "yyyyMMdd";
                            dt = DateTime.ParseExact(d, f, null);

                            payDraftDataWork.PaymentDate = dt;
                        }

                        status = this.WritePayDraft(payDraftDataWork, ref sqlConnection, ref sqlTransaction);

                    }
                }
                // --- ADD 2013/02/21 Y.Wakita ----------<<<<<

                // ↓ 20070213 18322 a MA.NS用に変更
				// 赤入金の削除の場合、元黒の入金・引当情報の更新を行う(赤相殺の区分関連をクリアする)
				if((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                   (paymentSlpWork.DebitNoteDiv == 1)                          )
				{
                    // 赤伝削除

                    // 支払読込み処理(赤相殺されていた支払伝票)
                    //--- DEL 2008/04/24 M.Kubota --->>>
                    //status = ReadPaymentSlpWork( EnterpriseCode
                    //                           , paymentSlpWork.DebitNoteLinkPayNo 
                    //                           , out paymentSlpWork
                    //                           , ref sqlConnection
                    //                           , ref sqlTransaction);
                    //--- DEL 2008/04/24 M.Kubota ---<<<

                    paymentSlipNo = paymentSlpWork.DebitNoteLinkPayNo;
                    status = this.Read(EnterpriseCode, paymentSlipNo, out paymentSlpWork, out paymentDtlWorkArray, sqlConnection, sqlTransaction);    //ADD 2008/04/24 M.Kubota

					// 赤伝区分をクリア
					paymentSlpWork.DebitNoteDiv = 0;

					// 元黒支払の赤黒連結番号をクリア
					paymentSlpWork.DebitNoteLinkPayNo = 0;

                    // 元黒支払マスタ更新処理
                    //--- DEL 2008/04/24 M.Kubota --->>>
                    //status = WritePaymentSlpWork( ref paymentSlpWork
                    //                            , ref sqlConnection
                    //                            , ref sqlTransaction);
                    //--- DEL 2008/04/24 M.Kubota ---<<<
                    status = this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

					if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// XMLへ変換し、文字列のバイナリ化
                        //paymentDataWorkByte = XmlByteSerializer.Serialize(paymentSlpWork);  //DEL 2008/04/24 M.Kubota
                        //--- ADD 2008/04/24 M.Kubota --->>>
                        PaymentDataUtil.Union(out paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
                        paymentDataWorkByte = XmlByteSerializer.Serialize(paymentDataWork);
                        //--- ADD 2008/04/24 M.Kubota ---<<<
					}
				}
                // ↑ 20070213 18322 a

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();
			}
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                //status = base.WriteSQLErrorLog(ex);
                base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //DEL 2008/04/24 M.Kubota
            }
            //--- ADD 2008/04/24 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<
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

        # endregion

        # region [赤伝作成]
        /// <summary>
        /// 支払伝票赤伝処理
        /// </summary>
        /// <param name="Mode">赤伝作成モード 0:赤入金作成</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="UpdateSecCd">更新拠点コード</param>
        /// <param name="PaymentAgentCode">支払担当者コード</param>
        /// <param name="PaymentAgentName">支払担当者名</param>
        /// <param name="AddUpADate">計上日</param>
        /// <param name="paymentSlipNo">支払伝票番号(赤伝を行う黒伝)</param>
        /// <param name="RetPaymentSlpWorkList">支払伝票マスタ(更新結果)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した支払伝票番号の赤支払作成処理を行います</br>    
        /// <br>Programmer : 18322 木村 武正</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        // ↓ 20070907 980081 c
        //public int RedCreate(int Mode, string EnterpriseCode, string UpdateSecCd, string PaymentAgentCode, string PaymentAgentNm, DateTime AddUpADate, int paymentSlipNo, out object RetPaymentSlpWorkList)
        public int RedCreate(int Mode, string EnterpriseCode, string UpdateSecCd, string PaymentAgentCode, string PaymentAgentName, DateTime AddUpADate, int paymentSlipNo, out object RetPaymentSlpWorkList)
        // ↑ 20070907 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            RetPaymentSlpWorkList = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            PaymentSlpWork paymentSlpWork = null;
            
            //--- ADD 2008/04/24 M.Kubota --->>>
            PaymentDtlWork[] paymentDtlArray = null;
            PaymentDataWork blkpaymentDataWork = null;
            PaymentDataWork redPaymentDataWork = null;
            
            // 2009/04/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //string resName = this.GetResourceName(EnterpriseCode);
            //status = this.Lock(resName, sqlConnection, sqlTransaction);

            //string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            // 2009/04/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //--- ADD 2008/04/24 M.Kubota ---<<<

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// 伝票更新排他制御部品  //DEL 2008/04/24 M.Kubota

            string resName = string.Empty; // 2009/04/28

            try
            {
                # region --- DEL 2008/04/24 M.Kubota ---
                ////ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                //if (connectionText == null || connectionText == "") return status;

                ////SQL接続
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();

                //// 初期
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                # endregion --- DEL 2008/04/24 M.Kubota ---

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                
                string errmsg = string.Empty; // 2009/04/28

                if (sqlConnection == null)
                {
                    errmsg += ": データベースへの接続に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/24 M.Kubota ---<<<

                // -- 2009/04/28 -- >>>>>>>>>>>>>
                resName = this.GetResourceName(EnterpriseCode);
                status = this.Lock(resName, sqlConnection, sqlTransaction);

                errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                // -- 2009/04/28 -- <<<<<<<<<<<<<

                // 支払読込み処理
                # region --- DEL 2008/04/24 M.Kubota ---
                //status = ReadPaymentSlpWork(EnterpriseCode,
                //                            PaymentSlipNo,
                //                            out paymentSlpWork,
                //                            ref sqlConnection,
                //                            ref sqlTransaction);
                # endregion --- DEL 2008/04/24 M.Kubota ---

                status = this.Read(EnterpriseCode, paymentSlipNo, out paymentSlpWork, out paymentDtlArray, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー終了
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    return status;
                }

                # region --- DEL 2008/04/24 M.Kubota ---
                //// 更新時ロック処理(得意先別ロック)
                //int[] SupplierCdList = { paymentSlpWork.SupplierCd };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode,
                //                                            SupplierCdList,
                //                                            null);
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    // エラー終了
                //    sqlTransaction.Rollback();
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //    return status;
                //}
                # endregion --- DEL 2008/04/24 M.Kubota ---

                // 赤伝データ作成
                // ↓ 20070907 980081 c
                //PaymentSlpWork redPaymentSlip = CreateRedPaymentSlipProc(UpdateSecCd,
                //                                                         PaymentAgentCode,
                //                                                         PaymentAgentNm,
                //                                                         AddUpADate,
                //                                                         paymentDataWork);
                PaymentSlpWork redPaymentSlip = CreateRedPaymentSlipProc(UpdateSecCd,
                                                                         PaymentAgentCode,
                                                                         PaymentAgentName,
                                                                         AddUpADate,
                                                                         paymentSlpWork);
                // ↑ 20070907 980081 c
                // 赤伝登録処理
                # region --- DEL 2008/04/24 M.Kubota ---
                //status = WritePaymentSlpWork(ref redPaymentSlip,
                //                             ref sqlConnection,
                //                             ref sqlTransaction);
                # endregion --- DEL 2008/04/24 M.Kubota ---
                
                //--- ADD 2008/04/24 M.Kubota --->>>

                // 赤伝用のダミー明細データを作成しておく、しかしこのデータはDBに登録されない
                PaymentDtlWork[] redPaymentDtlArray = this.CreateRedPaymentDtlProc(redPaymentSlip.PaymentSlipNo, paymentDtlArray);

                status = this.WriteInitial(ref redPaymentSlip, ref redPaymentDtlArray, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    errmsg += ": 支払伝票番号の採番に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                status = this.WritePaymentSlpWorkRec(ref redPaymentSlip, ref sqlConnection, ref sqlTransaction);

                //--- ADD 2008/04/24 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー終了
                    sqlTransaction.Rollback();
                    //sqlConnection.Close();    //DEL 2008/04/24 M.Kubota
                    //sqlConnection.Dispose();  //DEL 2008/04/24 M.Kubota
                    return status;
                }

                PaymentDataUtil.Union(out redPaymentDataWork, redPaymentSlip, redPaymentDtlArray);  //ADD 2008/04/24 M.Kubota

                // 相殺済み黒伝更新処理
                paymentSlpWork.DebitNoteDiv = 2;
                paymentSlpWork.DebitNoteLinkPayNo = redPaymentSlip.PaymentSlipNo;
                # region --- DEL 2008/04/24 M.Kubota ---
                //status = WritePaymentSlpWork(ref paymentSlpWork,
                //                             ref sqlConnection,
                //                             ref sqlTransaction);
                #endregion --- DEL 2008/04/24 M.Kubota ---

                status = this.WritePaymentSlpWorkRec(ref paymentSlpWork, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラー終了
                    sqlTransaction.Rollback();
                    //sqlConnection.Close();    //DEL 2008/04/24 M.Kubota
                    //sqlConnection.Dispose();  //DEL 2008/04/24 M.Kubota
                    return status;
                }

                PaymentDataUtil.Union(out blkpaymentDataWork, paymentSlpWork, paymentDtlArray);  //ADD 2008/04/24 M.Kubota

                // 正常終了
                sqlTransaction.Commit();
                //sqlConnection.Close();    //DEL 2008/04/24 M.Kubota
                //sqlConnection.Dispose();  //DEL 2008/04/24 M.Kubota

                //=================================================
                // 相殺済み黒伝・赤伝を戻り用のパラメータに設定
                //=================================================
                ArrayList list = new ArrayList();
                //list.Add(paymentSlpWork);  //DEL 2008/04/24 M.Kubota
                //list.Add(redPaymentSlip);  //DEL 2008/04/24 M.Kubota

                list.Add(redPaymentDataWork);  //ADD 2008/04/24 M.Kubota
                list.Add(blkpaymentDataWork);  //ADD 2008/04/24 M.Kubota

                RetPaymentSlpWorkList = list;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // 更新時ロック解除
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>
                this.Release(resName, sqlConnection, sqlTransaction);
                
                if (sqlTransaction != null)
                {
                    //if (sqlTransaction.Connection != null || status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)
                    if (sqlTransaction.Connection != null && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00)
                    {
                        sqlTransaction.Rollback();
                    }
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<
            }

            # region --- DEL 2008/04/24 M.Kubota ---
            //if (sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            # endregion --- DEL 2008/04/24 M.Kubota ---

            return status;
        }

        /// <summary>
		/// 支払伝票赤伝作成
		/// </summary>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="paymentAgentCode">支払担当者コード</param>
        /// <param name="paymentAgentName">支払担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="paymentSlpWork">支払伝票マスタ(赤伝元)</param>
        /// <returns>赤伝データ</returns>
		/// <remarks>
        /// <br>Note       : 支払伝票の赤伝データを作成します。</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2006.12.22</br>
		/// </remarks>
        // ↓ 20070907 980081 c
        //private PaymentSlpWork CreateRedPaymentSlipProc(string updateSecCd, string paymentAgentCode, string paymentAgentNm, DateTime addUpADate, PaymentSlpWork paymentDataWork)
        private PaymentSlpWork CreateRedPaymentSlipProc(string updateSecCd, string paymentAgentCode, string paymentAgentName, DateTime addUpADate, PaymentSlpWork paymentSlpWork)
        // ↑ 20070907 980081 c
        {
            PaymentSlpWork ret = new PaymentSlpWork();

            # region --- DEL 2008/04/24 M.Kubota ---
            # if false
            // ↓ 2007.11.02 980081 c
            #region 旧レイアウト
            //// 企業コード
            //ret.EnterpriseCode = paymentDataWork.EnterpriseCode;
            //// 更新従業員コード
            //ret.UpdEmployeeCode = paymentAgentCode;
            //// 更新アセンブリID1
            //ret.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;
            //// 更新アセンブリID2
            //ret.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;
            //// 論理削除区分
            //ret.LogicalDeleteCode = 0;
            //// 赤伝区分
            //ret.DebitNoteDiv = 1;
            //// 支払伝票番号
            //ret.paymentSlipNo = 0;
            //// 得意先コード
            //ret.SupplierCd = paymentDataWork.SupplierCd;
            //// 得意先名称
            //ret.SupplierNm1 = paymentDataWork.SupplierNm1;
            //// 得意先名称2
            //ret.SupplierNm2 = paymentDataWork.SupplierNm2;
            //// 支払入力拠点コード
            //ret.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;
            //// 計上拠点コード
            //ret.AddUpSecCode = paymentDataWork.AddUpSecCode;
            //// 更新拠点コード
            //ret.UpdateSecCd = updateSecCd;
            //// 支払日付
            //ret.PaymentDate = addUpADate;
            //// 計上日付
            //ret.AddUpADate = addUpADate;
            //// 支払金種コード
            //ret.PaymentMoneyKindCode = paymentDataWork.PaymentMoneyKindCode;
            //// 支払金種名称
            //ret.PaymentMoneyKindName = paymentDataWork.PaymentMoneyKindName;
            //// 支払金種区分
            //ret.PaymentMoneyKindDiv = paymentDataWork.PaymentMoneyKindDiv;
            //// 支払計
            //ret.PaymentTotal = paymentDataWork.PaymentTotal * -1;
            //// 支払金額
            //ret.Payment = paymentDataWork.Payment * -1;
            //// 手数料支払額
            //ret.FeePayment = paymentDataWork.FeePayment * -1;
            //// 値引支払額
            //ret.DiscountPayment = paymentDataWork.DiscountPayment * -1;
            //// リベート支払額
            //ret.RebatePayment = paymentDataWork.RebatePayment * -1;
            //// 自動支払区分
            //ret.AutoPayment = paymentDataWork.AutoPayment;
            //// クレジット／ローン区分
            //ret.CreditOrLoanCd = paymentDataWork.CreditOrLoanCd;
            //// クレジット会社コード
            //ret.CreditCompanyCode = paymentDataWork.CreditCompanyCode;
            //// 手形振出日
            //ret.DraftDrawingDate = paymentDataWork.DraftDrawingDate;
            //// 手形支払期日
            //ret.DraftPayTimeLimit = paymentDataWork.DraftPayTimeLimit;
            //// 赤黒支払連結番号
            //ret.DebitNoteLinkPayNo = paymentDataWork.paymentSlipNo;
            //// 支払担当者コード
            //ret.PaymentAgentCode = paymentAgentCode;
            //// 支払担当者名称
            //// ↓ 20070907 980081 c
            ////ret.PaymentAgentNm = paymentAgentNm;
            //ret.PaymentAgentName = paymentAgentName;
            //// ↑ 20070907 980081 c
            //// 伝票摘要
            //ret.Outline = paymentDataWork.Outline;
            //// ↓ 20070907 980081 a
            //// 得意先請求先コード
            //ret.CustClaimCode = paymentDataWork.CustClaimCode;
            //// 部門コード
            //ret.SubSectionCode = paymentDataWork.SubSectionCode;
            //// 課コード
            //ret.MinSectionCode = paymentDataWork.MinSectionCode;
            //// 手形種類
            //ret.DraftKind = paymentDataWork.DraftKind;
            //// 手形種類名称
            //ret.DraftKindName = paymentDataWork.DraftKindName;
            //// 手形区分
            //ret.DraftDivide = paymentDataWork.DraftDivide;
            //// 手形区分名称
            //ret.DraftDivideName = paymentDataWork.DraftDivideName;
            //// 手形番号
            //ret.DraftNo = paymentDataWork.DraftNo;
            //// 支払入力者コード
            //ret.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;
            //// 支払入力者名称
            //ret.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;
            //// 銀行コード
            //ret.BankCode = paymentDataWork.BankCode;
            //// 銀行名称
            //ret.BankName = paymentDataWork.BankName;
            //// ＥＤＩ送信日
            //ret.EdiSendDate = paymentDataWork.EdiSendDate;
            //// ＥＤＩ取込日
            //ret.EdiTakeInDate = paymentDataWork.EdiTakeInDate;
            //// テキスト抽出日
            //ret.TextExtraDate = paymentDataWork.TextExtraDate;
            //// ↑ 20070907 980081 a
            #endregion
            //ret.CreateDateTime = paymentDataWork.CreateDateTime;                      //作成日時(不要)
            //ret.UpdateDateTime = paymentDataWork.UpdateDateTime;                      //更新日時(不要)
            ret.EnterpriseCode = paymentSlpWork.EnterpriseCode;                      //企業コード
            //ret.FileHeaderGuid = paymentDataWork.FileHeaderGuid;                      //GUID(不要)
            ret.UpdEmployeeCode = paymentAgentCode;                                  //更新従業員コード(パラメータを使用)
            ret.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;                      //更新アセンブリID1
            ret.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;                      //更新アセンブリID2
            ret.LogicalDeleteCode = 0;                                               //論理削除区分(0固定)
            ret.DebitNoteDiv = 1;                                                    //赤伝区分(1固定)
            ret.PaymentSlipNo = 0;                                                   //支払伝票番号(0固定)
            ret.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;                      //仕入伝票番号
            ret.SupplierCd = paymentSlpWork.SupplierCd;                          //得意先コード
            ret.SupplierNm1 = paymentSlpWork.SupplierNm1;                          //得意先名称
            ret.SupplierNm2 = paymentSlpWork.SupplierNm2;                        //得意先名称2
            ret.SupplierSnm = paymentSlpWork.SupplierSnm;                            //得意先略称
            ret.PayeeCode = paymentSlpWork.PayeeCode;                                //支払先コード
            ret.PayeeName = paymentSlpWork.PayeeName;                                //支払先名称
            ret.PayeeName2 = paymentSlpWork.PayeeName2;                              //支払先名称2
            ret.PayeeSnm = paymentSlpWork.PayeeSnm;                                  //支払先略称
            ret.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;            //支払入力拠点コード
            ret.AddUpSecCode = paymentSlpWork.AddUpSecCode;                          //計上拠点コード
            ret.UpdateSecCd = updateSecCd;                                           //更新拠点コード(パラメータを使用)
            ret.SubSectionCode = paymentSlpWork.SubSectionCode;                      //部門コード
            ret.MinSectionCode = paymentSlpWork.MinSectionCode;                      //課コード
            // ↓ 2008.03.14 980081 c
            //ret.PaymentDate = addUpADate;                                            //支払日付(パラメータを使用)
            ret.PaymentDate = DateTime.Now;
            // ↑ 2008.03.14 980081 c
            ret.AddUpADate = addUpADate;                                             //計上日付(パラメータを使用)
            ret.PaymentMoneyKindCode = paymentSlpWork.PaymentMoneyKindCode;          //支払金種コード
            ret.PaymentMoneyKindName = paymentSlpWork.PaymentMoneyKindName;          //支払金種名称
            ret.PaymentMoneyKindDiv = paymentSlpWork.PaymentMoneyKindDiv;            //支払金種区分
            ret.PaymentTotal = -paymentSlpWork.PaymentTotal;                         //支払計(符号反転)
            ret.Payment = -paymentSlpWork.Payment;                                   //支払金額(符号反転)
            ret.FeePayment = -paymentSlpWork.FeePayment;                             //手数料支払額(符号反転)
            ret.DiscountPayment = -paymentSlpWork.DiscountPayment;                   //値引支払額(符号反転)
            ret.RebatePayment = -paymentSlpWork.RebatePayment;                       //リベート支払額(符号反転)
            ret.AutoPayment = paymentSlpWork.AutoPayment;                            //自動支払区分
            ret.CreditOrLoanCd = paymentSlpWork.CreditOrLoanCd;                      //クレジット／ローン区分
            ret.CreditCompanyCode = paymentSlpWork.CreditCompanyCode;                //クレジット会社コード
            ret.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;                  //手形振出日
            ret.DraftPayTimeLimit = paymentSlpWork.DraftPayTimeLimit;                //手形支払期日
            ret.DraftKind = paymentSlpWork.DraftKind;                                //手形種類
            ret.DraftKindName = paymentSlpWork.DraftKindName;                        //手形種類名称
            ret.DraftDivide = paymentSlpWork.DraftDivide;                            //手形区分
            ret.DraftDivideName = paymentSlpWork.DraftDivideName;                    //手形区分名称
            ret.DraftNo = paymentSlpWork.DraftNo;                                    //手形番号
            ret.DebitNoteLinkPayNo = paymentSlpWork.PaymentSlipNo;                   //赤黒支払連結番号(黒伝の伝票番号をセット)
            ret.PaymentAgentCode = paymentAgentCode;                                 //支払担当者コード(パラメータを使用)
            ret.PaymentAgentName = paymentAgentName;                                 //支払担当者名称(パラメータを使用)
            ret.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;            //支払入力者コード
            ret.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;            //支払入力者名称
            ret.Outline = paymentSlpWork.Outline;                                    //伝票摘要
            ret.BankCode = paymentSlpWork.BankCode;                                  //銀行コード
            ret.BankName = paymentSlpWork.BankName;                                  //銀行名称
            //ret.EdiSendDate = paymentDataWork.EdiSendDate;                            //ＥＤＩ送信日(不要)
            //ret.EdiTakeInDate = paymentDataWork.EdiTakeInDate;                        //ＥＤＩ取込日(不要)
            // ↑ 2007.11.02 980081 c
            # endif
            # endregion

            //--- ADD 2008/04/24 M.Kubota --->>>
            ret.EnterpriseCode = paymentSlpWork.EnterpriseCode;            // 企業コード
            ret.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
            ret.DebitNoteDiv = 1;                                          // 赤伝区分 (1:赤伝)
            ret.PaymentSlipNo = 0;                                         // 支払伝票番号
            ret.SupplierFormal = paymentSlpWork.SupplierFormal;            // 仕入形式
            ret.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;            // 仕入伝票番号
            ret.SupplierCd = paymentSlpWork.SupplierCd;                    // 仕入先コード
            ret.SupplierNm1 = paymentSlpWork.SupplierNm1;                  // 仕入先名1
            ret.SupplierNm2 = paymentSlpWork.SupplierNm2;                  // 仕入先名2
            ret.SupplierSnm = paymentSlpWork.SupplierSnm;                  // 仕入先略称
            ret.PayeeCode = paymentSlpWork.PayeeCode;                      // 支払先コード
            ret.PayeeName = paymentSlpWork.PayeeName;                      // 支払先名称
            ret.PayeeName2 = paymentSlpWork.PayeeName2;                    // 支払先名称2
            ret.PayeeSnm = paymentSlpWork.PayeeSnm;                        // 支払先略称
            ret.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;  // 支払入力拠点コード
            ret.AddUpSecCode = paymentSlpWork.AddUpSecCode;                // 計上拠点コード
            ret.UpdateSecCd = paymentSlpWork.UpdateSecCd;                  // 更新拠点コード
            ret.SubSectionCode = paymentSlpWork.SubSectionCode;            // 部門コード
            ret.InputDay = DateTime.Now;                                  // 入力日付  //ADD 2009/03/25
            ret.PaymentDate = DateTime.Now;                               // 支払日付
            ret.AddUpADate = addUpADate;                                   // 計上日付
            ret.PaymentTotal = -paymentSlpWork.PaymentTotal;               // 支払計
            ret.Payment = -paymentSlpWork.Payment;                         // 支払金額
            ret.FeePayment = -paymentSlpWork.FeePayment;                   // 手数料支払額
            ret.DiscountPayment = -paymentSlpWork.DiscountPayment;         // 値引支払額
            ret.AutoPayment = paymentSlpWork.AutoPayment;                  // 自動支払区分
            ret.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;        // 手形振出日
            ret.DraftKind = paymentSlpWork.DraftKind;                      // 手形種類
            ret.DraftKindName = paymentSlpWork.DraftKindName;              // 手形種類名称
            ret.DraftDivide = paymentSlpWork.DraftDivide;                  // 手形区分
            ret.DraftDivideName = paymentSlpWork.DraftDivideName;          // 手形区分名称
            ret.DraftNo = paymentSlpWork.DraftNo;                          // 手形番号
            ret.DebitNoteLinkPayNo = paymentSlpWork.PaymentSlipNo;         // 赤黒支払連結番号
            ret.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;        // 支払担当者コード
            ret.PaymentAgentName = paymentSlpWork.PaymentAgentName;        // 支払担当者名称
            ret.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;  // 支払入力者コード
            ret.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;  // 支払入力者名称
            ret.Outline = paymentSlpWork.Outline;                          // 伝票摘要
            ret.BankCode = paymentSlpWork.BankCode;                        // 銀行コード
            ret.BankName = paymentSlpWork.BankName;                        // 銀行名称
            //--- ADD 2008/04/24 M.Kubota ---<<<

            return ret;
        }

        private PaymentDtlWork[] CreateRedPaymentDtlProc(int redPaymentSlipNo, PaymentDtlWork[] paymentDtlArray)
        {
            ArrayList redDtlList = new ArrayList();

            foreach(PaymentDtlWork dtl in paymentDtlArray)
            {
                PaymentDtlWork redDtl = new PaymentDtlWork();
                redDtl.CreateDateTime = dtl.CreateDateTime;        // 作成日時
                redDtl.UpdateDateTime = dtl.UpdateDateTime;        // 更新日時
                redDtl.EnterpriseCode = dtl.EnterpriseCode;        // 企業コード
                redDtl.FileHeaderGuid = dtl.FileHeaderGuid;        // GUID
                redDtl.UpdEmployeeCode = dtl.UpdEmployeeCode;      // 更新従業員コード
                redDtl.UpdAssemblyId1 = dtl.UpdAssemblyId1;        // 更新アセンブリID1
                redDtl.UpdAssemblyId2 = dtl.UpdAssemblyId2;        // 更新アセンブリID2
                redDtl.LogicalDeleteCode = dtl.LogicalDeleteCode;  // 論理削除区分
                redDtl.SupplierFormal = dtl.SupplierFormal;        // 仕入形式
                redDtl.PaymentSlipNo = dtl.PaymentSlipNo;          // 支払伝票番号
                redDtl.PaymentRowNo = dtl.PaymentRowNo;            // 支払行番号
                redDtl.MoneyKindCode = dtl.MoneyKindCode;          // 金種コード
                redDtl.MoneyKindName = dtl.MoneyKindName;          // 金種名称
                redDtl.MoneyKindDiv = dtl.MoneyKindDiv;            // 金種区分
                redDtl.Payment = dtl.Payment * -1;                 // 支払金額
                redDtl.ValidityTerm = dtl.ValidityTerm;            // 有効期限

                redDtlList.Add(redDtl);
            }

            return (PaymentDtlWork[])redDtlList.ToArray(typeof(PaymentDtlWork));
        }

        # endregion

        # region --- DEL 2008/04/24 M.Kubota --- [コメントアウトされているソース]

# if false
		/// <summary>
		/// 指定された企業コードの支払伝票番号最大値を戻します
		/// </summary>
		/// <param name="DepositSlipNo">支払伝票番号</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定された企業コードの最大支払伝票番号を戻します</br>
		/// <br>Programmer : 95089 岩本　勇</br>
		/// <br>Date       : 2005.08.03</br>
		/// </remarks>
        private int GetMaxDepositSlipNoProc(out int DepositSlipNo,string EnterpriseCode, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int wkDepositSlipNo = 0;
			SqlDataReader myReader = null;

			try 
			{			
                // ↓ 20061222 18322 c 入金マスタを参照するのは間違い、後で要確認
                //                     支払マスタは無いので、とりあえず支払伝票マスタにする
				//Selectコマンドの生成
                //using(SqlCommand sqlCommand = new SqlCommand("SELECT MAX(DEPOSITSLIPNORF) DEPOSITSLIPNORF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction))

                string sqlCmd = "SELECT MAX(PAYMENTSLIPNORF) DEPOSITSLIPNORF"
                              + " FROM PAYMENTSLPRF"
                              + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                              ;

				using(SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection, sqlTransaction))
                // ↑ 20061222 18322 c
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

        #region 請求売上読込処理（テスト用：仮）全てコメントアウト
        /*
		/// <summary>
		/// 請求売上読込処理（テスト用：仮）
		/// </summary>
		/// <param name="EnterpriseCode"></param>
		/// <param name="DepositSlipNo"></param>
		/// <param name="depsitMainWorkByte"></param>
		/// <param name="depositAlwWorkListByte"></param>
		/// <returns></returns>
		public int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DmdSalesWork[] DmdSalesWorkList = null;


			dmdSalesWorkListByte = null;

			try 
			{	
				//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL接続
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction();

				// 支払読込み処理
				status = ReadDmdSalesWorkRec(EnterpriseCode, ClaimCode, out DmdSalesWorkList, ref sqlConnection, ref sqlTransaction);

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

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

			// XMLへ変換し、文字列のバイナリ化
			dmdSalesWorkListByte = XmlByteSerializer.Serialize(DmdSalesWorkList);

			return status;
		}
        */
        #endregion

        #region 請求売上マスタ情報を取得します(テスト用仮ロジック) 全てコメントアウト
        /*
		/// <summary>
		/// 請求売上マスタ情報を取得します(テスト用仮ロジック)
		/// </summary>
		private int ReadDmdSalesWorkRec(string EnterpriseCode, int ClaimCode, out DmdSalesWork[] DmdSalesWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	
			SqlDataReader myReader = null;

			ArrayList dmdSalesWorkArrayList = new ArrayList();

			try 
			{			
				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SLIPNORF, DEBITNOTEDIVRF, CUSTOMERCODERF, CARMNGNORF, CLAIMCODERF, ADDUPADATERF, ACCEPTANORDERSALESRF, ACPTANODRDISCOUNTTTLRF, ACCEPTANORDERCONSTAXRF, TOTALVARIOUSCOSTRF, VARCSTTAXTOTALRF, VARCSTTAXFREETOTALRF, VARCST1RF, VARCST2RF, VARCST3RF, VARCST4RF, VARCST5RF, VARCST6RF, VARCST7RF, VARCST8RF, VARCST9RF, VARCST10RF, VARCST11RF, VARCST12RF, VARCST13RF, VARCST14RF, VARCST15RF, VARCST16RF, VARCST17RF, VARCST18RF, VARCST19RF, VARCST20RF, VARCSTDIV1RF, VARCSTDIV2RF, VARCSTDIV3RF, VARCSTDIV4RF, VARCSTDIV5RF, VARCSTDIV6RF, VARCSTDIV7RF, VARCSTDIV8RF, VARCSTDIV9RF, VARCSTDIV10RF, VARCSTDIV11RF, VARCSTDIV12RF, VARCSTDIV13RF, VARCSTDIV14RF, VARCSTDIV15RF, VARCSTDIV16RF, VARCSTDIV17RF, VARCSTDIV18RF, VARCSTDIV19RF, VARCSTDIV20RF, VARCSTCONSTAXRF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DATAINPUTSYSTEMRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, ACCEPTANORDERDATERF, CARDELIEXPECTEDDATERF, SALESEMPLOYEECDRF, SALESDIVRF, SALESNAMERF, DEBITNLNKACPTANODRRF, DEMANDPRORATACDRF, LASTRECONCILEDATERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MAKERNAMERF, MODELNAMERF, DEMANDABLESALESNOTERF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, CREDITSALESRF, CREDITALLOWANCERF, CREDITALWCBLNCERF, CORPORATEDIVCODERF, AACOUNTRF, MNYONDEPOALLOWANCERF, ACPTANODRSTATUSRF, LASTRECONCILEADDUPDTRF, CARINSPECTORGECDRF, GRADENAMERF "
						  +"FROM DMDSALESRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCLAIMCODE", sqlConnection, sqlTransaction))
				{

					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
					findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(ClaimCode);

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						DmdSalesWork dmdSalesWork = new DmdSalesWork();


        #region クラスへ代入
						dmdSalesWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						dmdSalesWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						dmdSalesWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						dmdSalesWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						dmdSalesWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						dmdSalesWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						dmdSalesWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						dmdSalesWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						dmdSalesWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
						dmdSalesWork.SlipNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SLIPNORF"));
						dmdSalesWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
						dmdSalesWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
						dmdSalesWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARMNGNORF"));
						dmdSalesWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIMCODERF"));
						dmdSalesWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
						dmdSalesWork.AcceptAnOrderSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESRF"));
						dmdSalesWork.AcptAnOdrDiscountTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPTANODRDISCOUNTTTLRF"));
						dmdSalesWork.AcceptAnOrderConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERCONSTAXRF"));
						dmdSalesWork.TotalVariousCost = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("TOTALVARIOUSCOSTRF"));
						dmdSalesWork.VarCstTaxTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXTOTALRF"));
						dmdSalesWork.VarCstTaxFreeTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXFREETOTALRF"));
						dmdSalesWork.VarCst1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST1RF"));
						dmdSalesWork.VarCst2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST2RF"));
						dmdSalesWork.VarCst3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST3RF"));
						dmdSalesWork.VarCst4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST4RF"));
						dmdSalesWork.VarCst5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST5RF"));
						dmdSalesWork.VarCst6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST6RF"));
						dmdSalesWork.VarCst7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST7RF"));
						dmdSalesWork.VarCst8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST8RF"));
						dmdSalesWork.VarCst9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST9RF"));
						dmdSalesWork.VarCst10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST10RF"));
						dmdSalesWork.VarCst11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST11RF"));
						dmdSalesWork.VarCst12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST12RF"));
						dmdSalesWork.VarCst13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST13RF"));
						dmdSalesWork.VarCst14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST14RF"));
						dmdSalesWork.VarCst15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST15RF"));
						dmdSalesWork.VarCst16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST16RF"));
						dmdSalesWork.VarCst17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST17RF"));
						dmdSalesWork.VarCst18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST18RF"));
						dmdSalesWork.VarCst19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST19RF"));
						dmdSalesWork.VarCst20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST20RF"));
						dmdSalesWork.VarCstDiv1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV1RF"));
						dmdSalesWork.VarCstDiv2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV2RF"));
						dmdSalesWork.VarCstDiv3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV3RF"));
						dmdSalesWork.VarCstDiv4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV4RF"));
						dmdSalesWork.VarCstDiv5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV5RF"));
						dmdSalesWork.VarCstDiv6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV6RF"));
						dmdSalesWork.VarCstDiv7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV7RF"));
						dmdSalesWork.VarCstDiv8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV8RF"));
						dmdSalesWork.VarCstDiv9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV9RF"));
						dmdSalesWork.VarCstDiv10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV10RF"));
						dmdSalesWork.VarCstDiv11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV11RF"));
						dmdSalesWork.VarCstDiv12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV12RF"));
						dmdSalesWork.VarCstDiv13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV13RF"));
						dmdSalesWork.VarCstDiv14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV14RF"));
						dmdSalesWork.VarCstDiv15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV15RF"));
						dmdSalesWork.VarCstDiv16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV16RF"));
						dmdSalesWork.VarCstDiv17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV17RF"));
						dmdSalesWork.VarCstDiv18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV18RF"));
						dmdSalesWork.VarCstDiv19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV19RF"));
						dmdSalesWork.VarCstDiv20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV20RF"));
						dmdSalesWork.VarCstConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTCONSTAXRF"));
						dmdSalesWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
						dmdSalesWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
						dmdSalesWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
						dmdSalesWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
						dmdSalesWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
						dmdSalesWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
						dmdSalesWork.AcceptAnOrderDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
						dmdSalesWork.CarDeliExpectedDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("CARDELIEXPECTEDDATERF"));
						dmdSalesWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
						dmdSalesWork.SalesDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SALESDIVRF"));
						dmdSalesWork.SalesName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESNAMERF"));
						dmdSalesWork.DebitNLnkAcptAnOdr = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
						dmdSalesWork.DemandProRataCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEMANDPRORATACDRF"));
						dmdSalesWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE1CODERF"));
						dmdSalesWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
						dmdSalesWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE2RF"));
						dmdSalesWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE3RF"));
						dmdSalesWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE4RF"));
						dmdSalesWork.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MAKERNAMERF"));
						dmdSalesWork.ModelName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELNAMERF"));
						dmdSalesWork.DemandableSalesNote = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDABLESALESNOTERF"));
						dmdSalesWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
						dmdSalesWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
						dmdSalesWork.CreditSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITSALESRF"));
						dmdSalesWork.CreditAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALLOWANCERF"));
						dmdSalesWork.CreditAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALWCBLNCERF"));
						dmdSalesWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
						dmdSalesWork.AaCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AACOUNTRF"));
						dmdSalesWork.MnyOnDepoAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCERF"));
						dmdSalesWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
						dmdSalesWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
						dmdSalesWork.CarInspectOrGeCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARINSPECTORGECDRF"));
						dmdSalesWork.GradeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GRADENAMERF"));
        #endregion

						dmdSalesWorkArrayList.Add(dmdSalesWork);

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
	
			DmdSalesWorkList =  (DmdSalesWork[])dmdSalesWorkArrayList.ToArray(typeof(DmdSalesWork));

			return status;
		}
        */
        #endregion

# endif

        # endregion

        # region [チェック処理]
        // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 支払データの送信済みのチェック
        /// </summary>
        /// <param name="paymentSlpWork">支払ワーク</param>
        /// <returns>true: チェックOK、false：チェックNG</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note: 2012/02/06 田建委</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28288 送信済データ修正制御の対応</br>
        /// <br>Update Note: 2012/08/10  脇田 靖之</br>
        /// <br>           : 拠点管理 送信済データチェック不具合対応</br>
        /// </remarks>
        private bool CheckPaymentSlpSending(PaymentSlpWork paymentSlpWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // チェックを行うかどうかが下記のように判断する(②～③)
            // ②拠点管理送受信対象マスタに支払データの拠点管理送信区分が「1:送信あり」----------->
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
            secMngSndRcvWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;
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
                if (string.Equals("PaymentSlpRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase)
                    && resultSecMngSndRcvWork.SecMngSendDiv == 1
                    && resultSecMngSndRcvWork.LogicalDeleteCode == 0)
                {
                    isHaveObj = true;
                    break;
                }
            }
            if (!isHaveObj)
                // ０件の場合、チェックOK
                return true;
            // ②拠点管理送受信対象マスタに支払データの拠点管理送信区分が「1:送信あり」-----------<


            // ③拠点管理設定マスタに下記の情報に当たるレコードが存在する ------------------------>>
            // 種別＝0:データ
            // 受信状況＝0:送信
            // 送信対象拠点＝更新する支払データの計上拠点コード
            // 送信済データ修正区分＝修正不可
            object outSecMngSetList = null;
            SecMngSetWork paraSecMngSetWork = new SecMngSetWork();
            paraSecMngSetWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;

            // 拠点管理設定マスタ情報を取得
            status = this.ScMngSetDB.Search(out outSecMngSetList, paraSecMngSetWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSetList = outSecMngSetList as ArrayList;


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSetList || secMngSetList.Count == 0)
                // ０件の場合、チェックOK
                return true;

            isHaveObj = false;
            string addUpSecCode = paymentSlpWork.AddUpSecCode;
            if (null != addUpSecCode)
                addUpSecCode = addUpSecCode.Trim();
            DateTime maxSyncExecDate = DateTime.MinValue; // 拠点管理設定マスタの送信実行日
            int sndFinDataEdDiv = -1; //ADD by 陳建明　2011/11/10
            foreach (SecMngSetWork resultSecMngSetWork in secMngSetList)
            {
                if (resultSecMngSetWork.Kind == 0 && resultSecMngSetWork.ReceiveCondition == 0
                    // 種別＝0:データ && 受信状況＝0:送信
                    && resultSecMngSetWork.SectionCode.Trim() == addUpSecCode
                    // 送信対象拠点＝更新する支払データの計上拠点コード
                    && (resultSecMngSetWork.SndFinDataEdDiv == 1||resultSecMngSetWork.SndFinDataEdDiv == 2) //ADD by 陳建明　2011/11/10
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
            if ((sndFinDataEdDiv==1&&paymentSlpWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)||
                //(sndFinDataEdDiv == 2 && paymentSlpWork.PaymentDate.CompareTo(maxSyncExecDate) <= 0)) // DEL 2011/12/15
                //(sndFinDataEdDiv == 2 && paymentSlpWork.PrePaymentDate.CompareTo(maxSyncExecDate) <= 0)) // ADD 2011/12/15 // DEL 2012/02/06 田建委 Redmine#28288
                //(sndFinDataEdDiv == 2 && paymentSlpWork.PrePaymentDate.CompareTo(maxSyncExecDate) <= 0 && paymentSlpWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)) // ADD 2012/02/06 田建委 Redmine#28288 DEL 2012/08/10 Y.Wakita
                (sndFinDataEdDiv == 2 && paymentSlpWork.PrePaymentDate.CompareTo(maxSyncExecDate) <= 0 && paymentSlpWork.UpdateDateTime.ToString("HHmmss").CompareTo(maxSyncExecDate.ToString("HHmmss")) <= 0)) // ADD 2012/08/10 Y.Wakita
            //ADD by 陳建明　2011/11/10 end  ----<<<<<<
            //if (paymentSlpWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) //DEL by 陳建明　2011/11/10
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
        // ADD 2011/07/29 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
        # endregion
    }
}
