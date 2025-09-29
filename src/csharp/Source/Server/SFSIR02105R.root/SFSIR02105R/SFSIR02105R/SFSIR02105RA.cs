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
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/24 M.Kubota
using System.Diagnostics;             //ADD 2008/04/24 M.Kubota

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 支払READDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払READの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 99033 岩本　勇</br>
	/// <br>Date       : 2005.08.16</br>
    /// <br>           : 20060904 iwa 検索時の拠点を入力計上拠点に変更</br>
    /// <br></br>
    /// <br>Update Note: 18322 木村 武正</br>
    /// <br>           : 20061222 携帯.NS対応</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>           : 2007.09.07 流通基幹.NS対応</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>           : 2007.12.10 EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>           : 2008.01.30 パラメータクラスに自動支払区分・仕入伝票番号を追加</br>
    /// <br></br>
	/// </remarks>
	[Serializable]
	//public class PaymentReadDB : RemoteDB , IPaymentReadDB          //DEL 2008/04/24 M.Kubota
    public class PaymentReadDB : RemoteWithAppLockDB, IPaymentReadDB  //ADD 2008/04/24 M.Kubota
	{
		/// <summary>
		/// 支払READDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 99033 岩本　勇</br>
		/// <br>Date       : 2005.08.16</br>
		/// </remarks>
        public PaymentReadDB()
            :
        base("SFSIR02105D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpWork", "PAYMENTSLIPRF") //基底クラスのコンストラクタ
        {
        }

		#region カスタムシリアライズ

        /// <summary>
        /// 指定された企業コードの支払READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="paymentMainWork">検索結果</param>
        /// <param name="searchParaPaymentRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの支払READLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 99033 岩本　勇</br>
        /// <br>Date       : 2005.08.16</br>
        public int Search(out object paymentMainWork, object searchParaPaymentRead, int readMode, ConstantManagement.LogicalMode logicalMode)
        {		
            bool nextData;
            int retTotalCnt;
            SearchParaPaymentRead _searchParaPaymentRead = searchParaPaymentRead as SearchParaPaymentRead;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentMainWork = null;
            try
            {
                status = SearchProc(out paymentMainWork, out retTotalCnt, out nextData, _searchParaPaymentRead, readMode, logicalMode, 0);
            }
            catch(Exception ex)
            {
                //base.WriteErrorLog(ex,"PaymentReadDB.Search Exception="+ex.Message);  //DEL 2008/04/24 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //--- ADD 2008/04/24 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //--- ADD 2008/04/24 M.Kubota ---<<<
            }
            return status;
        }


        /// <summary>
        /// 指定された企業コードの支払READLISTを全て戻します
        /// </summary>
        /// <param name="paymentMainWork">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="searchParaPaymentRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの支払READLISTを全て戻します</br>
        /// <br>Programmer : 99033 岩本　勇</br>
        /// <br>Date       : 2005.08.16</br>
        private int SearchProc(out object paymentMainWork, out int retTotalCnt, out bool nextData, SearchParaPaymentRead searchParaPaymentRead, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            SearchParaPaymentRead SPTA = searchParaPaymentRead;
            string enterpriseCode           = SPTA.EnterpriseCode;
            string addUpSecCode             = SPTA.AddUpSecCode;
            int supplierCd                = SPTA.SupplierCd;
            int paymentSlipNo               = SPTA.PaymentSlipNo;
            DateTime paymentCallMonthsStart = SPTA.PaymentCallMonthsStart;
            DateTime paymentCallMonthsEnd = SPTA.PaymentCallMonthsEnd;
            // ↓ 2008.01.30 980081 a
            Int32 autoPayment = SPTA.AutoPayment;
            Int32 supplierSlipNo = SPTA.SupplierSlipNo;
            // ↑ 2008.01.30 980081 a

            paymentMainWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //PaymentSlpWork paymentSlpWork = new PaymentSlpWork();  //DEL 2008/04/24 M.Kubota
            //--- ADD 2008/04/24 M.Kubota --->>>
            PaymentSlpWork paymentSlpWork = null;
            PaymentDtlWork[] paymentDtlWorkArray = null;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            //--- ADD 2008/04/24 M.Kubota ---<<<

            //総件数を0で初期化
            retTotalCnt = 0;

            //件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = readCnt;			
            if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            nextData = false;

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                sDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", paymentCallMonthsStart);
                eDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", paymentCallMonthsEnd);
            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }

            ArrayList al = new ArrayList();
            ArrayList paymentWrkList = new ArrayList();  //ADD 2008/04/24 M.Kubota
            ArrayList paymentDtlList = new ArrayList();  //ADD 2008/04/24 M.Kubota

            try
            {
                # region --- DEL 2008/04/24 M.Kubota --->>>
                //try  //DEL 2008/04/24 M.Kubota
                //{
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //コネクション文字列取得対応↑↑↑↑↑

                //--- 受注番号が入っていない場合 ----------//
                //SQL文生成
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();

                //sqlCommand = new SqlCommand("SELECT * FROM PAYMENTSLPRF ", sqlConnection);
                # endregion --- DEL 2008/04/24 M.Kubota ---<<<

                //--- ADD 2008/04/24 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベースへの接続に失敗しました.";
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region [SELECT文]
                string sqlText = string.Empty;
                if (readCnt <= 0)
                {
                    sqlText += "SELECT" + Environment.NewLine;
                }
                else
                {
                    sqlText += "SELECT TOP " + readCnt.ToString() + Environment.NewLine;
                }
                sqlText += "  PAY.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PAY.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,PAY.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,PAY.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,PAY.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,PAY.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,PAY.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,PAY.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,PAY.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,PAY.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,PAY.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,PAY.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,PAY.UPDATESECCDRF" + Environment.NewLine;
                sqlText += " ,PAY.SUBSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,PAY.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,PAY.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,PAY.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,PAY.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,PAY.OUTLINERF" + Environment.NewLine;
                sqlText += " ,PAY.BANKCODERF" + Environment.NewLine;
                sqlText += " ,PAY.BANKNAMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS PAY" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                SqlParameter paraReadCount = sqlCommand.Parameters.Add("@READCNT", SqlDbType.Int);
                paraReadCount.Value = SqlDataMediator.SqlSetInt(readCnt);
                //--- ADD 2008/04/24 M.Kubota ---<<<

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaPaymentRead, logicalMode);

# if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
# endif

                //支払ﾏｽﾀ Read
                //myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);  //DEL 2008/04/24 M.Kubota
                myReader = sqlCommand.ExecuteReader();  //ADD 2008/04/24 M.Kubota

                //int retCnt = 0;  //DEL 2008/04/24 M.Kubota

                while (myReader.Read())
                {
                    # region --- DEL 2008/04/24 M.Kubota --->>>
                    ////戻り値カウンタカウント
                    //retCnt += 1;
                    //if (readCnt > 0)
                    //{
                    //    //戻り値の件数が取得指示件数を超えた場合終了
                    //    if (readCnt < retCnt)
                    //    {
                    //        nextData = true;
                    //        break;
                    //    }
                    //}
                    # endregion --- DEL 2008/04/24 M.Kubota ---<<<

                    //支払伝票マスタ
                    paymentSlpWork = new PaymentSlpWork();
                    #region 支払伝票マスタクラスへ代入
                    paymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));         // 作成日時
                    paymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));         // 更新日時
                    paymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                    // 企業コード
                    paymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                      // GUID
                    paymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                  // 更新従業員コード
                    paymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                    // 更新アセンブリID1
                    paymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                    // 更新アセンブリID2
                    paymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));               // 論理削除区分
                    paymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                         // 赤伝区分
                    paymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));                       // 支払伝票番号
                    paymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                     // 仕入形式
                    paymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                     // 仕入伝票番号
                    paymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                             // 仕入先コード
                    paymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));                          // 仕入先名1
                    paymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));                          // 仕入先名2
                    paymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                          // 仕入先略称
                    paymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));                               // 支払先コード
                    paymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));                              // 支払先名称
                    paymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));                            // 支払先名称2
                    paymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));                                // 支払先略称
                    paymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));          // 支払入力拠点コード
                    paymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));                        // 計上拠点コード
                    paymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));                          // 更新拠点コード
                    paymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                     // 部門コード
                    paymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));            // 支払日付
                    paymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));              // 計上日付
                    paymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));                         // 支払計
                    paymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));                                   // 支払金額
                    paymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));                             // 手数料支払額
                    paymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));                   // 値引支払額
                    paymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));                           // 自動支払区分
                    paymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));  // 手形振出日
                    paymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));                               // 手形種類
                    paymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));                      // 手形種類名称
                    paymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));                           // 手形区分
                    paymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));                  // 手形区分名称
                    paymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));                                  // 手形番号
                    paymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));             // 赤黒支払連結番号
                    paymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));                // 支払担当者コード
                    paymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));                // 支払担当者名称
                    paymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));          // 支払入力者コード
                    paymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));          // 支払入力者名称
                    paymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));                                  // 伝票摘要
                    paymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));                                 // 銀行コード
                    paymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));                                // 銀行名称

                    # region --- DEL 2008/04/24 M.Kubota --->>>
                    //PaymentSlpWork wkPaymentSlpWork = new PaymentSlpWork();

                    //wkPaymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //wkPaymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //wkPaymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //wkPaymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //wkPaymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //wkPaymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //wkPaymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //wkPaymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // ↓ 20061222 18322 c 携帯.NS用に変更
                    //wkPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    //wkPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    //wkPaymentSlpWork.Payment   = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("PAYMENTRF"));
                    //wkPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    //wkPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    //wkPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    //wkPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    //wkPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    //wkPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    //wkPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    //wkPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    //wkPaymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    //wkPaymentSlpWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                    //wkPaymentSlpWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                    //wkPaymentSlpWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                    //wkPaymentSlpWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                    //wkPaymentSlpWork.PaymentDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTDIVNMRF"));
                    //wkPaymentSlpWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                    //wkPaymentSlpWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                    //wkPaymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));

                    //// 赤伝区分
                    //wkPaymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    //// 支払伝票番号
                    //wkPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    //// 得意先コード
                    //wkPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //// 得意先名称
                    //wkPaymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    //// 得意先名称2
                    //wkPaymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    //// 支払入力拠点コード
                    //wkPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    //// 計上拠点コード
                    //wkPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    //// 更新拠点コード
                    //wkPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    //// 支払日付
                    //wkPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    //// 計上日付
                    //wkPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    //// 支払金種コード
                    //wkPaymentSlpWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                    //// 支払金種名称
                    //wkPaymentSlpWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                    //// 支払金種区分
                    //wkPaymentSlpWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                    //// 支払計
                    //wkPaymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    //// 支払金額
                    //wkPaymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    //// 手数料支払額
                    //wkPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    //// 値引支払額
                    //wkPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    //// リベート支払額
                    //wkPaymentSlpWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                    //// 自動支払区分
                    //wkPaymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    //// クレジット／ローン区分
                    //wkPaymentSlpWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                    //// クレジット会社コード
                    //wkPaymentSlpWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                    //// 手形振出日
                    //wkPaymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    //// 手形支払期日
                    //wkPaymentSlpWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                    //// 赤黒支払連結番号
                    //wkPaymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    //// 支払担当者コード
                    //wkPaymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    //// 支払担当者名称
                    //// ↓ 2007.09.07 980081 c
                    ////wkPaymentSlpWork.PaymentAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNMRF"));
                    //wkPaymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    //// ↑ 2007.09.07 980081 c
                    //// 伝票摘要
                    //wkPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    //// ↑ 20061222 18322 c
                    //// ↓ 2007.09.07 980081 a
                    //// ↓ 2007.12.10 980081 d
                    ////// 得意先請求先コード
                    ////wkPaymentSlpWork.CustClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCLAIMCODERF"));
                    //// ↑ 2007.12.10 980081 d
                    //// 部門コード
                    //wkPaymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    //// 課コード
                    //wkPaymentSlpWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                    //// 手形種類
                    //wkPaymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    //// 手形種類名称
                    //wkPaymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    //// 手形区分
                    //wkPaymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    //// 手形区分名称
                    //wkPaymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    //// 手形番号
                    //wkPaymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    //// 支払入力者コード
                    //wkPaymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    //// 支払入力者名称
                    //wkPaymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    //// 銀行コード
                    //wkPaymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    //// 銀行名称
                    //wkPaymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    //// ＥＤＩ送信日
                    //wkPaymentSlpWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    //// ＥＤＩ取込日
                    //// ↓ 2007.12.10 980081 c
                    ////wkPaymentSlpWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    //wkPaymentSlpWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    //// ↑ 2007.12.10 980081 c
                    //// ↓ 2007.12.10 980081 d
                    ////// テキスト抽出日
                    ////wkPaymentSlpWork.TextExtraDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TEXTEXTRADATERF"));
                    //// ↑ 2007.12.10 980081 d
                    //// ↑ 2007.09.07 980081 a
                    # endregion
                    #endregion
                    //al.Add(paymentSlpWork);  //DEL 2008/04/24 M.Kubota

                    paymentWrkList.Add(paymentSlpWork);

                    //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  //DEL 2008/04/24 M.Kubota
                }

                //--- ADD 2008/04/24 M.Kubota --->>>
                if (paymentWrkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    return status;
                }
                //--- ADD 2008/04/24 M.Kubota ---<<<

                if (!myReader.IsClosed) myReader.Close();
                //sqlConnection.Close();  //DEL 2008/04/24 M.Kubota
                //paymentMainWork = al;  //DEL 2008/04/24 M.Kubota

                //--- ADD 2008/04/24 M.Kubota --->>>

                // 支払明細データ読み込み処理
                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DTL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,DTL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,DTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,DTL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTDTLRF AS DTL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND DTL.PAYMENTSLIPNORF = @FINDPAYMENTSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand.CommandText = sqlText;
                sqlCommand.Parameters.Clear();

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);    // 仕入形式
                SqlParameter findPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);      // 支払伝票番号

                foreach (PaymentSlpWork slip in paymentWrkList)
                {
                    if (myReader != null && !myReader.IsClosed)
                        myReader.Close();
                    
                    paymentDtlList.Clear();
                    
                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(slip.EnterpriseCode);  // 企業コード
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(slip.SupplierFormal);   // 仕入形式

                    if (slip.DebitNoteDiv != 1)
                    {
                        // 支払伝票が黒伝又は元黒の場合
                        findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(slip.PaymentSlipNo);  // 支払伝票番号
                    }
                    else
                    {
                        // 支払伝票が赤伝の場合
                        findPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(slip.DebitNoteLinkPayNo);  // 赤黒支払連結番号
                    }

# if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
# endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        PaymentDtlWork dtl = new PaymentDtlWork();

                        dtl.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                        dtl.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                        dtl.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
                        dtl.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                        dtl.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
                        dtl.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
                        dtl.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
                        dtl.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
                        dtl.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));              // 仕入形式
                        dtl.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));                // 支払伝票番号
                        dtl.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));                  // 支払行番号
                        dtl.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));                // 金種コード
                        dtl.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));               // 金種名称
                        dtl.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));                  // 金種区分
                        dtl.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));                            // 支払金額
                        dtl.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));   // 有効期限

                        // 赤伝の場合
                        if (slip.DebitNoteDiv == 1)
                        {
                            dtl.PaymentSlipNo = slip.PaymentSlipNo;
                            dtl.Payment = dtl.Payment * -1;
                        }

                        paymentDtlList.Add(dtl);
                    }

                    paymentDtlWorkArray = (PaymentDtlWork[])paymentDtlList.ToArray(typeof(PaymentDtlWork));

                    // 支払伝票と支払明細を結合する
                    PaymentDataWork paymentDataWork = null;
                    PaymentDataUtil.Union(out paymentDataWork, slip, paymentDtlWorkArray);

                    if (paymentDataWork != null)
                    {
                        al.Add(paymentDataWork);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && al.Count > 0)
                {
                    paymentMainWork = al;
                }
                
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/24 M.Kubota ---<<<
            # region --- DEL 2008/04/24 M.Kubota --->>>
            //catch (SqlException ex) 
            //{
            //    //基底クラスに例外を渡して処理してもらう
            //    status = base.WriteSQLErrorLog(ex);
            //}
            //if(!myReader.IsClosed)myReader.Close();
            //sqlConnection.Close();

            //paymentMainWork = al;
            //}
            //catch(Exception ex)
            //{
            //    base.WriteErrorLog(ex,"PaymentReadDB.SearchProc Exception="+ex.Message);
            //    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //}
            # endregion --- DEL 2008/04/24 M.Kubota ---<<<

            return status;
        }

		#endregion

        # region  Where文作成

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchParaPaymentRead">検索パラメータクラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchParaPaymentRead searchParaPaymentRead, ConstantManagement.LogicalMode logicalMode)
        {

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                sDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", searchParaPaymentRead.PaymentCallMonthsStart);
                eDate = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD", searchParaPaymentRead.PaymentCallMonthsEnd);
            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }


            string retstring = "WHERE";

            //企業コード
            //retstring += "  ENTERPRISECODERF=@ENTERPRISECODE ";  //DEL 2008/04/24 M.Kubota
            retstring += "  PAY.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchParaPaymentRead.EnterpriseCode);

            //論理削除区分
            string logidelstr = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                //logidelstr = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";  //DEL 2008/04/24 M.Kubota
                logidelstr = "  AND PAY.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
            }
            else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                //logidelstr = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";  //DEL 2008/04/24 M.Kubota
                logidelstr = "  AND PAY.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
            }
            if(logidelstr != "")
            {
                retstring += logidelstr;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //>>>>20060904 iwa add start
            //支払計上拠点コード            
            if ((searchParaPaymentRead.AddUpSecCode != null) && (searchParaPaymentRead.AddUpSecCode != ""))
            {
                //拠点検索
                //retstring += " AND ADDUPSECCODERF=@FINDADDUPSECCODE ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(searchParaPaymentRead.AddUpSecCode);
            }
            //<<<<20060904 iwa add end
            //>>>>20060904 iwa del start
            //計上拠点コード            
            //if ((searchParaPaymentRead.AddUpSecCode != null) && (searchParaPaymentRead.AddUpSecCode != ""))
            //{
            //    retstring += " AND ADDUPSECCODERF=@FINDADDUPSECCODE ";
            //    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
            //    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(searchParaPaymentRead.AddUpSecCode);
            //}
            //<<<<20060904 iwa del end

            //仕入先コード
            if (searchParaPaymentRead.SupplierCd > 0)
            {
                //retstring += " AND SUPPLIERCDRF=@FINDSUPPLIERCDRF ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.SUPPLIERCDRF=@FINDSUPPLIERCDRF" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.SupplierCd);
            }

           //支払伝票番号
            if (searchParaPaymentRead.PaymentSlipNo > 0)
           {
               //retstring += " AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO ";  //DEL 2008/04/24 M.Kubota
               retstring += "  AND PAY.PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
               SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
               paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.PaymentSlipNo);
           }

            //支払日(開始)
            if(sDate > 0)
            {
                //retstring += " AND PAYMENTDATERF>=@FINDSTARTDATE ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.PAYMENTDATERF>=@FINDSTARTDATE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraStartDate = sqlCommand.Parameters.Add("@FINDSTARTDATE", SqlDbType.Int);
                paraStartDate.Value = SqlDataMediator.SqlSetInt32(sDate);
            }

            //支払日(終了)
            if(eDate > 0)
            {
                //retstring += " AND PAYMENTDATERF<=@FINDENDDATE ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.PAYMENTDATERF<=@FINDENDDATE" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraEndDate = sqlCommand.Parameters.Add("@FINDENDDATE", SqlDbType.Int);
                paraEndDate.Value = SqlDataMediator.SqlSetInt32(eDate);
            }
            // ↓ 2008.01.30 980081 a
            //自動支払区分
            if (searchParaPaymentRead.AutoPayment >= 0)
            {
                //retstring += " AND AUTOPAYMENTRF=@FINDAUTOPAYMENT ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.AUTOPAYMENTRF=@FINDAUTOPAYMENT" + Environment.NewLine; //ADD 2008/04/24 M.Kubota
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@FINDAUTOPAYMENT", SqlDbType.Int);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.AutoPayment);
            }

            //仕入伝票番号
            if (searchParaPaymentRead.SupplierSlipNo > 0)
            {
                //retstring += " AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO ";  //DEL 2008/04/24 M.Kubota
                retstring += "  AND PAY.SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO" + Environment.NewLine;  //ADD 2008/04/24 M.Kubota
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(searchParaPaymentRead.SupplierSlipNo);
            }
            // ↑ 2008.01.30 980081 a

            return retstring;
        }

        # endregion
	}

}



