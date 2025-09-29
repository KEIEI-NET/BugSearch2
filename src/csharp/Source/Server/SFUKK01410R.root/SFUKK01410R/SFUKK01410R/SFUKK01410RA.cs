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
    /// 初期設定DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 初期設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 90027　高口　勝</br>
    /// <br>Date       : 2005.08.17</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.25 18322 T.Kimura 1. 99%同じ処理の関数が２つあったのをマージ</br>
    /// <br>           :                           2. 毎回DB接続しているのを１回に変更</br>
    /// </remarks>
    [Serializable]
    public class DepBillMonSecDB : RemoteDB,  IRemoteDB, IDepBillMonSecDB
    {

        /// <summary>
        /// 初期設定DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.17</br>
        /// </remarks>
        public DepBillMonSecDB():
            base("SFUKN09066D", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork", "DEPOSITSTRF")
        {
        }

        #region ノンカスタムシリアライズ
        /// <summary>
        /// 指定された企業コードの初期設定LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retTotalCnt">合計取得件数</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="priseCd">企業コード</param>
        /// <param name="depositStWorkList">検索結果(入金設定)</param>
        /// <param name="billAllStWorkList">検索結果(請求全体設定)</param>
        /// <param name="moneyKindWorkList">検索結果(金額種別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの初期設定LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.17</br>
        public int Search(out int retTotalCnt, int readMode, string priseCd, out byte[] depositStWorkList, out byte[] billAllStWorkList, out byte[] moneyKindWorkList)
        {		
//            return SearchProc(out retTotalCnt, readMode, priseCd, out depositStWorkList, out billAllStWorkList, out moneyKindWorkList);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retTotalCnt = 0;
            depositStWorkList = null;
            billAllStWorkList = null;
            moneyKindWorkList = null;
            try
            {
                // ↓ 20070126 18322 c SearchProc関数をマージする為に変更
                //status =  SearchProc(out retTotalCnt, readMode, priseCd, out depositStWorkList, out billAllStWorkList, out moneyKindWorkList);

                object arrMoneyKindWork = null;
                status = SearchProc( out retTotalCnt
                                   ,     readMode
                                   ,     priseCd
                                   , out depositStWorkList
                                   , out billAllStWorkList
                                   , out arrMoneyKindWork
                                   );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 処理が正常終了した場合は、金額種別マスタをシリアライズ
                    ArrayList al = (ArrayList)arrMoneyKindWork;
                    MoneyKindWork[] MoneyKindWorks = (MoneyKindWork[])al.ToArray(typeof(MoneyKindWork));
                    moneyKindWorkList = XmlByteSerializer.Serialize(MoneyKindWorks);
                }
                // ↑ 20070126 18322 c
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepBillMonSecDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // ↓ 20070126 18322 d SearchProc関数を１つにマージする為、削除
        #region SF 指定された企業コードの初期設定LISTを全て戻します(全てコメントアウト)
        ///// <summary>
        ///// 指定された企業コードの初期設定LISTを全て戻します
        ///// </summary>
        ///// <param name="retTotalCnt">合計取得件数</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="priseCd">企業コード</param>
        ///// <param name="depositStWorkList">検索結果(入金設定)</param>
        ///// <param name="billAllStWorkList">検索結果(請求全体設定)</param>
        ///// <param name="moneyKindWorkList">検索結果(金額種別)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された企業コードの初期設定LISTを全て戻します</br>
        ///// <br>Programmer : 90027　高口　勝</br>
        ///// <br>Date       : 2005.08.17</br>
        //private int SearchProc(out int retTotalCnt, int readMode, string priseCd, out byte[] depositStWorkList, out byte[] billAllStWorkList, out byte[] moneyKindWorkList)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //
        //    //入金マスタ          検索データ割り当て
        //    depositStWorkList  = null;
        //    //請求全体設定マスタ  検索データ割り当て
        //    billAllStWorkList  = null;
        //    //金額種別マスタ      検索データ割り当て
        //    moneyKindWorkList  = null;
        //
        //    //総件数を0で初期化
        //    retTotalCnt = 0;
        //
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //   入金設定マスタ Read                                                                                        //
        //    //-------------------------------------------------------------------------------------------------------------//
//      //      ArrayList al1 = new ArrayList();
        //
        //    SqlConnection sqlConnection1 = null;
        //    SqlDataReader myReader1 = null;
        //
//      //      _connectionText1 = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        //    //コネクション文字列取得対応↓↓↓↓↓
        //    //※各publicメソッドの開始時にコネクション文字列を取得
        //    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //    string _connectionText1 = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    if (_connectionText1 == null || _connectionText1 == "") return status;
        //    //コネクション文字列取得対応↑↑↑↑↑
        //
        //    //SQL文生成
        //    sqlConnection1 = new SqlConnection(_connectionText1);
        //    sqlConnection1.Open();				
        //
        //    SqlCommand sqlCommand1;
        //    sqlCommand1 = new SqlCommand("SELECT * FROM DEPOSITSTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF=0 ",sqlConnection1);
        //
        //    SqlParameter paraLogicalDeleteCode1 = sqlCommand1.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //    paraLogicalDeleteCode1.Value        = SqlDataMediator.SqlSetInt32(0);            //((Int32)logicalMode);
        //
        //    SqlParameter paraEnterpriseCode1    = sqlCommand1.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    paraEnterpriseCode1.Value           = SqlDataMediator.SqlSetString(priseCd);
        //
        //    myReader1 = sqlCommand1.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //    DepositStWork wkDepositStWork = new DepositStWork();
        //
        //    while(myReader1.Read())
        //    {
        //
        //        wkDepositStWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader1,myReader1.GetOrdinal("CREATEDATETIMERF"));
        //        wkDepositStWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader1,myReader1.GetOrdinal("UPDATEDATETIMERF"));
        //        wkDepositStWork.EnterpriseCode        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("ENTERPRISECODERF"));
        //        wkDepositStWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(             myReader1,myReader1.GetOrdinal("FILEHEADERGUIDRF"));
        //        wkDepositStWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDEMPLOYEECODERF"));
        //        wkDepositStWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDASSEMBLYID1RF"));
        //        wkDepositStWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDASSEMBLYID2RF"));
        //        wkDepositStWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("LOGICALDELETECODERF"));
        //
        //        wkDepositStWork.DepositStMngCd        = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTMNGCDRF"));
        //        wkDepositStWork.DepositInitDspNo      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITINITDSPNORF"));
        //        wkDepositStWork.InitSelMoneyKindCd    = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("INITSELMONEYKINDCDRF"));
        //        wkDepositStWork.DepositStKindCd1      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD1RF"));
        //        wkDepositStWork.DepositStKindCd2      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD2RF"));
        //        wkDepositStWork.DepositStKindCd3      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD3RF"));
        //        wkDepositStWork.DepositStKindCd4      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD4RF"));
        //        wkDepositStWork.DepositStKindCd5      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD5RF"));
        //        wkDepositStWork.DepositStKindCd6      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD6RF"));
        //        wkDepositStWork.DepositStKindCd7      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD7RF"));
        //        wkDepositStWork.DepositStKindCd8      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD8RF"));
        //        wkDepositStWork.DepositStKindCd9      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD9RF"));
        //        wkDepositStWork.DepositStKindCd10     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD10RF"));
        //        wkDepositStWork.DepositCallMonths     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITCALLMONTHSRF"));
        //        wkDepositStWork.AlwcDepoCallMonthsCd  = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));
        //
 //     //          //データ追加
 //     //          al1.Add(wkDepositStWork);
        //    }
        //
        //
        //    if(myReader1.IsClosed == false)myReader1.Close();
        //    sqlConnection1.Close();
        //
//      //      DepositStWork[] DepositStWorks = (DepositStWork[])al1.ToArray(typeof(DepositStWork));
//      //      depositStWorkList = XmlByteSerializer.Serialize(DepositStWorks);
        //    depositStWorkList = XmlByteSerializer.Serialize(wkDepositStWork);
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //-------------------------------------------------------------------------------------------------------------//
        //
        //
        //
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //   請求全体設定マスタ Read                                                                                    //
        //    //-------------------------------------------------------------------------------------------------------------//
        //    ArrayList al2 = new ArrayList();
        //
        //    SqlConnection sqlConnection2 = null;
        //    SqlDataReader myReader2 = null;
        //
//      //      _connectionText2 = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        //    //コネクション文字列取得対応↓↓↓↓↓
        //    //※各publicメソッドの開始時にコネクション文字列を取得
        //    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
        //    SqlConnectionInfo sqlConnectionInfo2 = new SqlConnectionInfo();
        //    string _connectionText2 = sqlConnectionInfo2.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    if (_connectionText2 == null || _connectionText2 == "") return status;
        //    //コネクション文字列取得対応↑↑↑↑↑
        //
        //    //SQL文生成
        //    sqlConnection2 = new SqlConnection(_connectionText2);
        //    sqlConnection2.Open();				
        //
        //    SqlCommand sqlCommand2;
        //    sqlCommand2 = new SqlCommand("SELECT * FROM BILLALLSTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND BILLALLSTCDRF=0 ",sqlConnection2);
        //
        //    SqlParameter paraLogicalDeleteCode2 = sqlCommand2.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //    paraLogicalDeleteCode2.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode
        //
        //    SqlParameter paraEnterpriseCode2    = sqlCommand2.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    paraEnterpriseCode2.Value           = SqlDataMediator.SqlSetString(priseCd);
        //
        // 
        //    myReader2 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //    BillAllStWork wkBillAllStWork = new BillAllStWork();
        //
        //    while(myReader2.Read())
        //    {
        //
        //        wkBillAllStWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader2,myReader2.GetOrdinal("CREATEDATETIMERF"));
        //        wkBillAllStWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader2,myReader2.GetOrdinal("UPDATEDATETIMERF"));
        //        wkBillAllStWork.EnterpriseCode       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("ENTERPRISECODERF"));
        //        wkBillAllStWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(             myReader2,myReader2.GetOrdinal("FILEHEADERGUIDRF"));
        //        wkBillAllStWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDEMPLOYEECODERF"));
        //        wkBillAllStWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDASSEMBLYID1RF"));
        //        wkBillAllStWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDASSEMBLYID2RF"));
        //        wkBillAllStWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("LOGICALDELETECODERF"));
        // 
        //        wkBillAllStWork.BillAllStCd          = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("BILLALLSTCDRF"));
        //        wkBillAllStWork.MinusVarCstBlAdjstCd = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("MINUSVARCSTBLADJSTCDRF"));
        //        wkBillAllStWork.AllowanceProcCd      = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("ALLOWANCEPROCCDRF"));
        //        wkBillAllStWork.DepositSlipMntCd     = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("DEPOSITSLIPMNTCDRF"));
        //
//      //          //データ追加
//      //          al2.Add(wkBillAllStWork);
        //    }
        //
        //
        //    if(myReader2.IsClosed == false)myReader2.Close();
        //    sqlConnection2.Close();
        //
//      //      BillAllStWork[] BillAllStWorks = (BillAllStWork[])al2.ToArray(typeof(BillAllStWork));
//      //      billAllStWorkList = XmlByteSerializer.Serialize(BillAllStWorks);
        //    billAllStWorkList = XmlByteSerializer.Serialize(wkBillAllStWork);
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //-------------------------------------------------------------------------------------------------------------//
        //
        //
        //
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //   金額種別マスタ Read                                                                                        //
        //    //-------------------------------------------------------------------------------------------------------------//
        //    ArrayList al3 = new ArrayList();
        //
        //    SqlConnection sqlConnection3 = null;
        //    SqlDataReader myReader3 = null;
        //   
//      //      _connectionText3 = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        //    //コネクション文字列取得対応↓↓↓↓↓
        //    //※各publicメソッドの開始時にコネクション文字列を取得
        //    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
        //    SqlConnectionInfo sqlConnectionInfo3 = new SqlConnectionInfo();
        //    string _connectionText3 = sqlConnectionInfo3.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    if (_connectionText3 == null || _connectionText3 == "") return status;
        //    //コネクション文字列取得対応↑↑↑↑↑
        //
        //    //SQL文生成
        //    sqlConnection3 = new SqlConnection(_connectionText3);
        //    sqlConnection3.Open();				
        //
        //    SqlCommand sqlCommand3;
       ////     sqlCommand3 = new SqlCommand("SELECT * FROM MONEYKINDRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PRICESTCODERF=0 ",sqlConnection3);
        //    sqlCommand3 = new SqlCommand("SELECT * FROM MONEYKINDURF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PRICESTCODERF=0 ",sqlConnection3);
        //
        //    SqlParameter paraLogicalDeleteCode3 = sqlCommand3.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //    paraLogicalDeleteCode3.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode
        //
        //    SqlParameter paraEnterpriseCode3    = sqlCommand3.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    paraEnterpriseCode3.Value           = SqlDataMediator.SqlSetString(priseCd);
        //
        // 
        //    myReader3 = sqlCommand3.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //    while(myReader3.Read())
        //    {
        //        MoneyKindWork wkMoneyKindWork = new MoneyKindWork();
        //
        //        wkMoneyKindWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader3,myReader3.GetOrdinal("CREATEDATETIMERF"));
        //        wkMoneyKindWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader3,myReader3.GetOrdinal("UPDATEDATETIMERF"));
        //        wkMoneyKindWork.EnterpriseCode     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("ENTERPRISECODERF"));
        //        wkMoneyKindWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(             myReader3,myReader3.GetOrdinal("FILEHEADERGUIDRF"));
        //        wkMoneyKindWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDEMPLOYEECODERF"));
        //        wkMoneyKindWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDASSEMBLYID1RF"));
        //        wkMoneyKindWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDASSEMBLYID2RF"));
        //        wkMoneyKindWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("LOGICALDELETECODERF"));
        // 
        //        wkMoneyKindWork.PriceStCode        = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("PRICESTCODERF"));
        //        wkMoneyKindWork.MoneyKindCode      = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("MONEYKINDCODERF"));
        //        wkMoneyKindWork.MoneyKindName      = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("MONEYKINDNAMERF"));
        //        wkMoneyKindWork.MoneyKindDiv       = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("MONEYKINDDIVRF"));
        //
        //        //データ追加
        //        al3.Add(wkMoneyKindWork);
        //    }
        //
        //
        //    if(myReader3.IsClosed == false)myReader3.Close();
        //    sqlConnection3.Close();
        //
        //    MoneyKindWork[] MoneyKindWorks = (MoneyKindWork[])al3.ToArray(typeof(MoneyKindWork));
        //    moneyKindWorkList = XmlByteSerializer.Serialize(MoneyKindWorks);
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //-------------------------------------------------------------------------------------------------------------//
        //    //-------------------------------------------------------------------------------------------------------------//
        //
        //
        //    status = 0;
        //    return status;
        //
        //}
        #endregion
        #endregion



        #region カスタムシリアライズ
        /// <summary>
        /// 指定された企業コードの初期設定LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retTotalCnt">合計取得件数</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="priseCd">企業コード</param>
        /// <param name="depositStWorkList">検索結果(入金設定)</param>
        /// <param name="billAllStWorkList">検索結果(請求全体設定)</param>
        /// <param name="moneyKindWorkList">検索結果(金額種別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの初期設定LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2006.08.30</br>
        public int Search(out int retTotalCnt, int readMode, string priseCd, out byte[] depositStWorkList, out byte[] billAllStWorkList, out object moneyKindWorkList)
        {		
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retTotalCnt = 0;
            depositStWorkList = null;
            billAllStWorkList = null;
            moneyKindWorkList = null;
            try
            {
                status =  SearchProc(out retTotalCnt, readMode, priseCd, out depositStWorkList, out billAllStWorkList, out moneyKindWorkList);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepBillMonSecDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの初期設定LISTを全て戻します
        /// </summary>
        /// <param name="retTotalCnt">合計取得件数</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="priseCd">企業コード</param>
        /// <param name="depositStWorkList">検索結果(入金設定)</param>
        /// <param name="billAllStWorkList">検索結果(請求全体設定)</param>
        /// <param name="moneyKindWorkList">検索結果(金額種別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの初期設定LISTを全て戻します</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2006.08.30</br>
        /// <br>Update Note: 2007.01.26 18322 T.Kimura データベース接続を１回のみに変更</br>
        private int SearchProc(out int retTotalCnt, int readMode, string priseCd, out byte[] depositStWorkList, out byte[] billAllStWorkList, out object moneyKindWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //入金マスタ          検索データ割り当て
            depositStWorkList  = null;
            //請求全体設定マスタ  検索データ割り当て
            billAllStWorkList  = null;
            //金額種別マスタ      検索データ割り当て
            moneyKindWorkList  = null;

            //総件数を0で初期化
            retTotalCnt = 0;

            // ↓ 20070126 18322 c
            #region SF 元処理（全てコメントアウト）
            ////-------------------------------------------------------------------------------------------------------------//
            ////   入金設定マスタ Read                                                                                        //
            ////-------------------------------------------------------------------------------------------------------------//
            //SqlConnection sqlConnection1 = null;
            //SqlDataReader myReader1 = null;
            //
            //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            //string _connectionText1 = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText1 == null || _connectionText1 == "") return status;
            //
            ////SQL文生成
            //sqlConnection1 = new SqlConnection(_connectionText1);
            //sqlConnection1.Open();				
            //
            //SqlCommand sqlCommand1;
            //sqlCommand1 = new SqlCommand("SELECT * FROM DEPOSITSTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF=0 ",sqlConnection1);
            //
            //SqlParameter paraLogicalDeleteCode1 = sqlCommand1.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //paraLogicalDeleteCode1.Value        = SqlDataMediator.SqlSetInt32(0);            //((Int32)logicalMode);
            //
            //SqlParameter paraEnterpriseCode1    = sqlCommand1.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode1.Value           = SqlDataMediator.SqlSetString(priseCd);
            // 
            //myReader1 = sqlCommand1.ExecuteReader(CommandBehavior.CloseConnection);
            //
            //DepositStWork wkDepositStWork = new DepositStWork();
            //
            //while(myReader1.Read())
            //{
            //    #region 値セット
            //    wkDepositStWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader1,myReader1.GetOrdinal("CREATEDATETIMERF"));
            //    wkDepositStWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader1,myReader1.GetOrdinal("UPDATEDATETIMERF"));
            //    wkDepositStWork.EnterpriseCode        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("ENTERPRISECODERF"));
            //    wkDepositStWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(             myReader1,myReader1.GetOrdinal("FILEHEADERGUIDRF"));
            //    wkDepositStWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDEMPLOYEECODERF"));
            //    wkDepositStWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDASSEMBLYID1RF"));
            //    wkDepositStWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDASSEMBLYID2RF"));
            //    wkDepositStWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("LOGICALDELETECODERF"));
            //
            //    wkDepositStWork.DepositStMngCd        = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTMNGCDRF"));
            //    wkDepositStWork.DepositInitDspNo      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITINITDSPNORF"));
            //    wkDepositStWork.InitSelMoneyKindCd    = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("INITSELMONEYKINDCDRF"));
            //    wkDepositStWork.DepositStKindCd1      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD1RF"));
            //    wkDepositStWork.DepositStKindCd2      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD2RF"));
            //    wkDepositStWork.DepositStKindCd3      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD3RF"));
            //    wkDepositStWork.DepositStKindCd4      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD4RF"));
            //    wkDepositStWork.DepositStKindCd5      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD5RF"));
            //    wkDepositStWork.DepositStKindCd6      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD6RF"));
            //    wkDepositStWork.DepositStKindCd7      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD7RF"));
            //    wkDepositStWork.DepositStKindCd8      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD8RF"));
            //    wkDepositStWork.DepositStKindCd9      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD9RF"));
            //    wkDepositStWork.DepositStKindCd10     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD10RF"));
            //    wkDepositStWork.DepositCallMonths     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITCALLMONTHSRF"));
            //    wkDepositStWork.AlwcDepoCallMonthsCd  = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));
            //    #endregion
            //
            //}
            //
            //
            //if(myReader1.IsClosed == false)myReader1.Close();
            //sqlConnection1.Close();
            //
//          //  DepositStWork[] DepositStWorks = (DepositStWork[])al1.ToArray(typeof(DepositStWork));
//          //  depositStWorkList = XmlByteSerializer.Serialize(DepositStWorks);
            //depositStWorkList = XmlByteSerializer.Serialize(wkDepositStWork);
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            //
            //
            //
            ////-------------------------------------------------------------------------------------------------------------//
            ////   請求全体設定マスタ Read                                                                                    //
            ////-------------------------------------------------------------------------------------------------------------//
            //ArrayList al2 = new ArrayList();
            //
            //SqlConnection sqlConnection2 = null;
            //SqlDataReader myReader2 = null;
            //
            //SqlConnectionInfo sqlConnectionInfo2 = new SqlConnectionInfo();
            //string _connectionText2 = sqlConnectionInfo2.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText2 == null || _connectionText2 == "") return status;
            //
            ////SQL文生成
            //sqlConnection2 = new SqlConnection(_connectionText2);
            //sqlConnection2.Open();				
            //
            //SqlCommand sqlCommand2;
            //sqlCommand2 = new SqlCommand("SELECT * FROM BILLALLSTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND BILLALLSTCDRF=0 ",sqlConnection2);
            //
            //SqlParameter paraLogicalDeleteCode2 = sqlCommand2.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //paraLogicalDeleteCode2.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode
            //
            //SqlParameter paraEnterpriseCode2    = sqlCommand2.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode2.Value           = SqlDataMediator.SqlSetString(priseCd);
            //
            //
            //myReader2 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
            //
            //BillAllStWork wkBillAllStWork = new BillAllStWork();
            //
            //while(myReader2.Read())
            //{
            //    #region 値セット
            //    wkBillAllStWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader2,myReader2.GetOrdinal("CREATEDATETIMERF"));
            //    wkBillAllStWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader2,myReader2.GetOrdinal("UPDATEDATETIMERF"));
            //    wkBillAllStWork.EnterpriseCode       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("ENTERPRISECODERF"));
            //    wkBillAllStWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(             myReader2,myReader2.GetOrdinal("FILEHEADERGUIDRF"));
            //    wkBillAllStWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDEMPLOYEECODERF"));
            //    wkBillAllStWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDASSEMBLYID1RF"));
            //    wkBillAllStWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDASSEMBLYID2RF"));
            //    wkBillAllStWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("LOGICALDELETECODERF"));
            //
            //    wkBillAllStWork.BillAllStCd          = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("BILLALLSTCDRF"));
            //    wkBillAllStWork.MinusVarCstBlAdjstCd = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("MINUSVARCSTBLADJSTCDRF"));
            //    wkBillAllStWork.AllowanceProcCd      = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("ALLOWANCEPROCCDRF"));
            //    wkBillAllStWork.DepositSlipMntCd     = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("DEPOSITSLIPMNTCDRF"));
            //    #endregion
            //
            //}
            //
            //
            //if(myReader2.IsClosed == false)myReader2.Close();
            //sqlConnection2.Close();
            //
//          //  BillAllStWork[] BillAllStWorks = (BillAllStWork[])al2.ToArray(typeof(BillAllStWork));
//          //  billAllStWorkList = XmlByteSerializer.Serialize(BillAllStWorks);
            //billAllStWorkList = XmlByteSerializer.Serialize(wkBillAllStWork);
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            //
            //
            //
            ////-------------------------------------------------------------------------------------------------------------//
            //   金額種別マスタ Read                                                                                        //
            //-------------------------------------------------------------------------------------------------------------//
            //ArrayList al3 = new ArrayList();
            //
            //SqlConnection sqlConnection3 = null;
            //SqlDataReader myReader3 = null;
            //
            //
            //SqlConnectionInfo sqlConnectionInfo3 = new SqlConnectionInfo();
            //string _connectionText3 = sqlConnectionInfo3.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText3 == null || _connectionText3 == "") return status;
            //
            ////SQL文生成
            //sqlConnection3 = new SqlConnection(_connectionText3);
            //sqlConnection3.Open();				
            //
            //SqlCommand sqlCommand3;
            //
            //sqlCommand3 = new SqlCommand("SELECT * FROM MONEYKINDURF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PRICESTCODERF=0 ",sqlConnection3);
            //
            //SqlParameter paraLogicalDeleteCode3 = sqlCommand3.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //paraLogicalDeleteCode3.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode
            //
            //SqlParameter paraEnterpriseCode3    = sqlCommand3.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode3.Value           = SqlDataMediator.SqlSetString(priseCd);
            //
            //
            //myReader3 = sqlCommand3.ExecuteReader(CommandBehavior.CloseConnection);
            //
            //while(myReader3.Read())
            //{
            //    MoneyKindWork wkMoneyKindWork = new MoneyKindWork();
            //
            //    #region 値セット
            //    wkMoneyKindWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader3,myReader3.GetOrdinal("CREATEDATETIMERF"));
            //    wkMoneyKindWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader3,myReader3.GetOrdinal("UPDATEDATETIMERF"));
            //    wkMoneyKindWork.EnterpriseCode     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("ENTERPRISECODERF"));
            //    wkMoneyKindWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(             myReader3,myReader3.GetOrdinal("FILEHEADERGUIDRF"));
            //    wkMoneyKindWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDEMPLOYEECODERF"));
            //    wkMoneyKindWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDASSEMBLYID1RF"));
            //    wkMoneyKindWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDASSEMBLYID2RF"));
            //    wkMoneyKindWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("LOGICALDELETECODERF"));
            //
            //    wkMoneyKindWork.PriceStCode        = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("PRICESTCODERF"));
            //    wkMoneyKindWork.MoneyKindCode      = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("MONEYKINDCODERF"));
            //    wkMoneyKindWork.MoneyKindName      = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("MONEYKINDNAMERF"));
            //    wkMoneyKindWork.MoneyKindDiv       = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("MONEYKINDDIVRF"));
            //    #endregion
            //
            //    //データ追加
            //    al3.Add(wkMoneyKindWork);
            //}
            //
            //
            //if(myReader3.IsClosed == false)myReader3.Close();
            //sqlConnection3.Close();
            //
            ////MoneyKindWork[] MoneyKindWorks = (MoneyKindWork[])al3.ToArray(typeof(MoneyKindWork));
            ////moneyKindWorkList = XmlByteSerializer.Serialize(MoneyKindWorks);
            //moneyKindWorkList = al3;
            //
            //
            //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            //
            //
            //status = 0;
            //return status;
            ////-------------------------------------------------------------------------------------------------------------//
            ////   入金設定マスタ Read                                                                                        //
            ////-------------------------------------------------------------------------------------------------------------//
            //SqlConnection sqlConnection1 = null;
            //SqlDataReader myReader1 = null;
            //
            //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            //string _connectionText1 = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText1 == null || _connectionText1 == "") return status;
            //
            ////SQL文生成
            //sqlConnection1 = new SqlConnection(_connectionText1);
            //sqlConnection1.Open();				
            //
            //SqlCommand sqlCommand1;
            //sqlCommand1 = new SqlCommand("SELECT * FROM DEPOSITSTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DEPOSITSTMNGCDRF=0 ",sqlConnection1);
            //
            //SqlParameter paraLogicalDeleteCode1 = sqlCommand1.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //paraLogicalDeleteCode1.Value        = SqlDataMediator.SqlSetInt32(0);            //((Int32)logicalMode);
            //
            //SqlParameter paraEnterpriseCode1    = sqlCommand1.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode1.Value           = SqlDataMediator.SqlSetString(priseCd);
            //
            //myReader1 = sqlCommand1.ExecuteReader(CommandBehavior.CloseConnection);
            //
            //DepositStWork wkDepositStWork = new DepositStWork();
            //
            //while(myReader1.Read())
            //{
            //    #region 値セット
            //    wkDepositStWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader1,myReader1.GetOrdinal("CREATEDATETIMERF"));
            //    wkDepositStWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader1,myReader1.GetOrdinal("UPDATEDATETIMERF"));
            //    wkDepositStWork.EnterpriseCode        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("ENTERPRISECODERF"));
            //    wkDepositStWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(             myReader1,myReader1.GetOrdinal("FILEHEADERGUIDRF"));
            //    wkDepositStWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDEMPLOYEECODERF"));
            //    wkDepositStWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDASSEMBLYID1RF"));
            //    wkDepositStWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(           myReader1,myReader1.GetOrdinal("UPDASSEMBLYID2RF"));
            //    wkDepositStWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("LOGICALDELETECODERF"));
            //
            //    wkDepositStWork.DepositStMngCd        = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTMNGCDRF"));
            //    wkDepositStWork.DepositInitDspNo      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITINITDSPNORF"));
            //    wkDepositStWork.InitSelMoneyKindCd    = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("INITSELMONEYKINDCDRF"));
            //    wkDepositStWork.DepositStKindCd1      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD1RF"));
            //    wkDepositStWork.DepositStKindCd2      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD2RF"));
            //    wkDepositStWork.DepositStKindCd3      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD3RF"));
            //    wkDepositStWork.DepositStKindCd4      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD4RF"));
            //    wkDepositStWork.DepositStKindCd5      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD5RF"));
            //    wkDepositStWork.DepositStKindCd6      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD6RF"));
            //    wkDepositStWork.DepositStKindCd7      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD7RF"));
            //    wkDepositStWork.DepositStKindCd8      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD8RF"));
            //    wkDepositStWork.DepositStKindCd9      = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD9RF"));
            //    wkDepositStWork.DepositStKindCd10     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITSTKINDCD10RF"));
            //    wkDepositStWork.DepositCallMonths     = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("DEPOSITCALLMONTHSRF"));
            //    wkDepositStWork.AlwcDepoCallMonthsCd  = SqlDataMediator.SqlGetInt32(            myReader1,myReader1.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));
            //    #endregion
            //
            //}
            //
            //
            //if(myReader1.IsClosed == false)myReader1.Close();
            //sqlConnection1.Close();
            //
//          //  DepositStWork[] DepositStWorks = (DepositStWork[])al1.ToArray(typeof(DepositStWork));
//          //  depositStWorkList = XmlByteSerializer.Serialize(DepositStWorks);
            //depositStWorkList = XmlByteSerializer.Serialize(wkDepositStWork);
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            //
            //
            //
            ////-------------------------------------------------------------------------------------------------------------//
            ////   請求全体設定マスタ Read                                                                                    //
            ////-------------------------------------------------------------------------------------------------------------//
            //ArrayList al2 = new ArrayList();
            //
            //SqlConnection sqlConnection2 = null;
            //SqlDataReader myReader2 = null;
            //
            //SqlConnectionInfo sqlConnectionInfo2 = new SqlConnectionInfo();
            //string _connectionText2 = sqlConnectionInfo2.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText2 == null || _connectionText2 == "") return status;
            //
            ////SQL文生成
            //sqlConnection2 = new SqlConnection(_connectionText2);
            //sqlConnection2.Open();				
            //
            //SqlCommand sqlCommand2;
            //sqlCommand2 = new SqlCommand("SELECT * FROM BILLALLSTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND BILLALLSTCDRF=0 ",sqlConnection2);
            //
            //SqlParameter paraLogicalDeleteCode2 = sqlCommand2.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //paraLogicalDeleteCode2.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode
            //
            //SqlParameter paraEnterpriseCode2    = sqlCommand2.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode2.Value           = SqlDataMediator.SqlSetString(priseCd);
            //
            //
            //myReader2 = sqlCommand2.ExecuteReader(CommandBehavior.CloseConnection);
            //
            //BillAllStWork wkBillAllStWork = new BillAllStWork();
            //
            //while(myReader2.Read())
            //{
            //    #region 値セット
            //    wkBillAllStWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader2,myReader2.GetOrdinal("CREATEDATETIMERF"));
            //    wkBillAllStWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader2,myReader2.GetOrdinal("UPDATEDATETIMERF"));
            //    wkBillAllStWork.EnterpriseCode       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("ENTERPRISECODERF"));
            //    wkBillAllStWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(             myReader2,myReader2.GetOrdinal("FILEHEADERGUIDRF"));
            //    wkBillAllStWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDEMPLOYEECODERF"));
            //    wkBillAllStWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDASSEMBLYID1RF"));
            //    wkBillAllStWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(           myReader2,myReader2.GetOrdinal("UPDASSEMBLYID2RF"));
            //    wkBillAllStWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("LOGICALDELETECODERF"));
            //
            //    wkBillAllStWork.BillAllStCd          = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("BILLALLSTCDRF"));
            //    wkBillAllStWork.MinusVarCstBlAdjstCd = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("MINUSVARCSTBLADJSTCDRF"));
            //    wkBillAllStWork.AllowanceProcCd      = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("ALLOWANCEPROCCDRF"));
            //    wkBillAllStWork.DepositSlipMntCd     = SqlDataMediator.SqlGetInt32(            myReader2,myReader2.GetOrdinal("DEPOSITSLIPMNTCDRF"));
            //    #endregion
            //
            //}
            //
            //
            //if(myReader2.IsClosed == false)myReader2.Close();
            //sqlConnection2.Close();
            //
//          //  BillAllStWork[] BillAllStWorks = (BillAllStWork[])al2.ToArray(typeof(BillAllStWork));
//          //  billAllStWorkList = XmlByteSerializer.Serialize(BillAllStWorks);
            //billAllStWorkList = XmlByteSerializer.Serialize(wkBillAllStWork);
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            //
            //
            //
            ////-------------------------------------------------------------------------------------------------------------//
            ////   金額種別マスタ Read                                                                                        //
            ////-------------------------------------------------------------------------------------------------------------//
            //ArrayList al3 = new ArrayList();
            //
            //SqlConnection sqlConnection3 = null;
            //SqlDataReader myReader3 = null;
            //
            //
            //SqlConnectionInfo sqlConnectionInfo3 = new SqlConnectionInfo();
            //string _connectionText3 = sqlConnectionInfo3.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText3 == null || _connectionText3 == "") return status;
            //
            ////SQL文生成
            //sqlConnection3 = new SqlConnection(_connectionText3);
            //sqlConnection3.Open();				
            //
            //SqlCommand sqlCommand3;
            //
            //sqlCommand3 = new SqlCommand("SELECT * FROM MONEYKINDURF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND PRICESTCODERF=0 ",sqlConnection3);
            //
            //SqlParameter paraLogicalDeleteCode3 = sqlCommand3.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //paraLogicalDeleteCode3.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode
            //
            //SqlParameter paraEnterpriseCode3    = sqlCommand3.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode3.Value           = SqlDataMediator.SqlSetString(priseCd);
            //
            //
            //myReader3 = sqlCommand3.ExecuteReader(CommandBehavior.CloseConnection);
            //
            //while(myReader3.Read())
            //{
            //    MoneyKindWork wkMoneyKindWork = new MoneyKindWork();
            //
            //    #region 値セット
            //    wkMoneyKindWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader3,myReader3.GetOrdinal("CREATEDATETIMERF"));
            //    wkMoneyKindWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader3,myReader3.GetOrdinal("UPDATEDATETIMERF"));
            //    wkMoneyKindWork.EnterpriseCode     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("ENTERPRISECODERF"));
            //    wkMoneyKindWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(             myReader3,myReader3.GetOrdinal("FILEHEADERGUIDRF"));
            //    wkMoneyKindWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDEMPLOYEECODERF"));
            //    wkMoneyKindWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDASSEMBLYID1RF"));
            //    wkMoneyKindWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("UPDASSEMBLYID2RF"));
            //    wkMoneyKindWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("LOGICALDELETECODERF"));
            //
            //    wkMoneyKindWork.PriceStCode        = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("PRICESTCODERF"));
            //    wkMoneyKindWork.MoneyKindCode      = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("MONEYKINDCODERF"));
            //    wkMoneyKindWork.MoneyKindName      = SqlDataMediator.SqlGetString(           myReader3,myReader3.GetOrdinal("MONEYKINDNAMERF"));
            //    wkMoneyKindWork.MoneyKindDiv       = SqlDataMediator.SqlGetInt32(            myReader3,myReader3.GetOrdinal("MONEYKINDDIVRF"));
            //    #endregion
            //
            //    //データ追加
            //    al3.Add(wkMoneyKindWork);
            //}
            //
            //
            //if(myReader3.IsClosed == false)myReader3.Close();
            //sqlConnection3.Close();
            //
            ////MoneyKindWork[] MoneyKindWorks = (MoneyKindWork[])al3.ToArray(typeof(MoneyKindWork));
            ////moneyKindWorkList = XmlByteSerializer.Serialize(MoneyKindWorks);
            //moneyKindWorkList = al3;
            //
            //
            //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            ////-------------------------------------------------------------------------------------------------------------//
            //
            //
            //status = 0;
            //return status;
            #endregion

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (_connectionText == null || _connectionText == "") return status;

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();
            
            try
            {
                //------------------------------------------------------------//
                //   入金設定マスタ Read                                      //
                //------------------------------------------------------------//
                //SQL文生成
                SqlCommand sqlCommand1;
                using (sqlCommand1 = new SqlCommand("SELECT *"
                                                  + " FROM DEPOSITSTRF"
                                                  + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                                  + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
                                                  + " AND DEPOSITSTMNGCDRF=0 "
                                                  , sqlConnection))
                {
                    SqlParameter paraLogicalDeleteCode1 = sqlCommand1.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode1.Value = SqlDataMediator.SqlSetInt32(0);            //((Int32)logicalMode);

                    SqlParameter paraEnterpriseCode1 = sqlCommand1.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(priseCd);

                    myReader = sqlCommand1.ExecuteReader();

                    DepositStWork wkDepositStWork = new DepositStWork();

                    while (myReader.Read())
                    {
                        #region 値セット
                        # region --- DEL 2008/06/30 M.Kubota ---
                        //wkDepositStWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //wkDepositStWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //wkDepositStWork.EnterpriseCode        = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //wkDepositStWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(             myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //wkDepositStWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //wkDepositStWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //wkDepositStWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //wkDepositStWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //wkDepositStWork.DepositStMngCd        = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                        //wkDepositStWork.DepositInitDspNo      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                        //wkDepositStWork.InitSelMoneyKindCd    = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("INITSELMONEYKINDCDRF"));
                        //wkDepositStWork.DepositStKindCd1      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                        //wkDepositStWork.DepositStKindCd2      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                        //wkDepositStWork.DepositStKindCd3      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                        //wkDepositStWork.DepositStKindCd4      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                        //wkDepositStWork.DepositStKindCd5      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                        //wkDepositStWork.DepositStKindCd6      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                        //wkDepositStWork.DepositStKindCd7      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                        //wkDepositStWork.DepositStKindCd8      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                        //wkDepositStWork.DepositStKindCd9      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                        //wkDepositStWork.DepositStKindCd10     = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                        //wkDepositStWork.DepositCallMonths     = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITCALLMONTHSRF"));
                        //wkDepositStWork.AlwcDepoCallMonthsCd  = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));
                        # endregion
                        //--- ADD 2008/06/30 M.Kubota --->>>
                        wkDepositStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkDepositStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkDepositStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkDepositStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkDepositStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkDepositStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkDepositStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkDepositStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkDepositStWork.DepositStMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTMNGCDRF"));
                        wkDepositStWork.DepositInitDspNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITINITDSPNORF"));
                        wkDepositStWork.DepositStKindCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD1RF"));
                        wkDepositStWork.DepositStKindCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD2RF"));
                        wkDepositStWork.DepositStKindCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD3RF"));
                        wkDepositStWork.DepositStKindCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD4RF"));
                        wkDepositStWork.DepositStKindCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD5RF"));
                        wkDepositStWork.DepositStKindCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD6RF"));
                        wkDepositStWork.DepositStKindCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD7RF"));
                        wkDepositStWork.DepositStKindCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD8RF"));
                        wkDepositStWork.DepositStKindCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD9RF"));
                        wkDepositStWork.DepositStKindCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSTKINDCD10RF"));
                        wkDepositStWork.AlwcDepoCallMonthsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ALWCDEPOCALLMONTHSCDRF"));
                        //--- ADD 2008/06/30 M.Kubota ---<<<
                        #endregion
                    }

                    if (myReader.IsClosed == false)
                    {
                        myReader.Close();
                    }
                
                    // 入金設定マスタシリアライズ
                    depositStWorkList = XmlByteSerializer.Serialize(wkDepositStWork);
                }

                //-------------------------------------------------------------------------------------------------------------//
                //   請求全体設定マスタ Read                                                                                   //
                //-------------------------------------------------------------------------------------------------------------//
                //SQL文生成
                SqlCommand sqlCommand2;
                using (sqlCommand2 = new SqlCommand("SELECT *"
                                                  + " FROM BILLALLSTRF"
                                                  + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                                  + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
                    //+ " AND BILLALLSTCDRF=0 "  //DEL 2008/06/30 M.Kubota
                                                  + " AND SECTIONCODERF=0 "  //ADD 2008/06/30 M.Kubota
                                                  , sqlConnection))
                {
                    SqlParameter paraLogicalDeleteCode2 = sqlCommand2.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode2.Value = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode

                    SqlParameter paraEnterpriseCode2 = sqlCommand2.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(priseCd);

                    myReader = sqlCommand2.ExecuteReader();

                    BillAllStWork wkBillAllStWork = new BillAllStWork();

                    while (myReader.Read())
                    {
                        #region 値セット
                        # region --- DEL 2008/06/30 M.Kubota ---
                        //wkBillAllStWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //wkBillAllStWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //wkBillAllStWork.EnterpriseCode       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //wkBillAllStWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(             myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //wkBillAllStWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //wkBillAllStWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //wkBillAllStWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //wkBillAllStWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        //wkBillAllStWork.BillAllStCd          = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("BILLALLSTCDRF"));
                        //wkBillAllStWork.MinusVarCstBlAdjstCd = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("MINUSVARCSTBLADJSTCDRF"));
                        //wkBillAllStWork.AllowanceProcCd      = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("ALLOWANCEPROCCDRF"));
                        //wkBillAllStWork.DepositSlipMntCd     = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("DEPOSITSLIPMNTCDRF"));
                        # endregion
                        //--- ADD 2008/06/30 M.Kubota --->>>
                        wkBillAllStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkBillAllStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkBillAllStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkBillAllStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkBillAllStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkBillAllStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkBillAllStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkBillAllStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkBillAllStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                        wkBillAllStWork.AllowanceProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ALLOWANCEPROCCDRF"));
                        wkBillAllStWork.DepositSlipMntCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPMNTCDRF"));
                        wkBillAllStWork.CollectPlnDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTPLNDIVRF"));
                        wkBillAllStWork.CustomerTotalDay1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY1RF"));
                        wkBillAllStWork.CustomerTotalDay2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY2RF"));
                        wkBillAllStWork.CustomerTotalDay3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY3RF"));
                        wkBillAllStWork.CustomerTotalDay4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY4RF"));
                        wkBillAllStWork.CustomerTotalDay5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY5RF"));
                        wkBillAllStWork.CustomerTotalDay6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY6RF"));
                        wkBillAllStWork.CustomerTotalDay7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY7RF"));
                        wkBillAllStWork.CustomerTotalDay8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY8RF"));
                        wkBillAllStWork.CustomerTotalDay9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY9RF"));
                        wkBillAllStWork.CustomerTotalDay10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY10RF"));
                        wkBillAllStWork.CustomerTotalDay11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY11RF"));
                        wkBillAllStWork.CustomerTotalDay12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY12RF"));
                        wkBillAllStWork.SupplierTotalDay1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY1RF"));
                        wkBillAllStWork.SupplierTotalDay2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY2RF"));
                        wkBillAllStWork.SupplierTotalDay3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY3RF"));
                        wkBillAllStWork.SupplierTotalDay4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY4RF"));
                        wkBillAllStWork.SupplierTotalDay5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY5RF"));
                        wkBillAllStWork.SupplierTotalDay6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY6RF"));
                        wkBillAllStWork.SupplierTotalDay7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY7RF"));
                        wkBillAllStWork.SupplierTotalDay8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY8RF"));
                        wkBillAllStWork.SupplierTotalDay9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY9RF"));
                        wkBillAllStWork.SupplierTotalDay10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY10RF"));
                        wkBillAllStWork.SupplierTotalDay11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY11RF"));
                        wkBillAllStWork.SupplierTotalDay12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERTOTALDAY12RF"));
                        //--- ADD 2008/06/30 M.Kubota ---<<<
                        #endregion
                    }

                    if (myReader.IsClosed == false)
                    {
                        myReader.Close();
                    }

                    // 請求全体設定マスタシリアライズ
                    billAllStWorkList = XmlByteSerializer.Serialize(wkBillAllStWork);
                }
                
                //------------------------------------------------------------//
                //   金額種別マスタ Read                                      //
                //------------------------------------------------------------//
                ArrayList arrMoneyKindU = new ArrayList();

                //SQL文生成
                SqlCommand sqlCommand3;
                using (sqlCommand3 = new SqlCommand("SELECT *"
                                          + " FROM MONEYKINDURF"
                                          + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                          + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
                                          + " AND PRICESTCODERF=0 "
                                          , sqlConnection))
                {
                    SqlParameter paraLogicalDeleteCode3 = sqlCommand3.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode3.Value = SqlDataMediator.SqlSetInt32(0);   //(Int32)logicalMode

                    SqlParameter paraEnterpriseCode3 = sqlCommand3.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode3.Value = SqlDataMediator.SqlSetString(priseCd);

                    myReader = sqlCommand3.ExecuteReader();

                    while (myReader.Read())
                    {
                        MoneyKindWork wkMoneyKindWork = new MoneyKindWork();

                        #region 値セット
                        wkMoneyKindWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkMoneyKindWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkMoneyKindWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkMoneyKindWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkMoneyKindWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkMoneyKindWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkMoneyKindWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkMoneyKindWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        wkMoneyKindWork.PriceStCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTCODERF"));
                        wkMoneyKindWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                        wkMoneyKindWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                        wkMoneyKindWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                        #endregion

                        //データ追加
                        arrMoneyKindU.Add(wkMoneyKindWork);
                    }
                    if (myReader.IsClosed == false)
                    {
                        myReader.Close();
                    }
                }

                moneyKindWorkList = arrMoneyKindU;
                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                
                // 接続解除
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            
            return status;
            // ↑ 20070126 18322 c
        }
        #endregion


    }

}



