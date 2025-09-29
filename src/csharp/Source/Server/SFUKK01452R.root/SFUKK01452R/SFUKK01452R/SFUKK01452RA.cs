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
using Broadleaf.Library.Diagnostics;  //ADD 2008/06/27 M.Kubota

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金/引当READDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金/引当READの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: 2007.02.02 18322 T.Kimura MA.NS用に変更</br>
    /// <br>             2007.04.06 18322 T.Kimura SearchProc関数のパラメータを変更</br>
    /// <br>             2007.05.14 18322 T.Kimura 1. サービス伝票区分を入金マスタ・入金引当マスタに追加</br>
    /// <br>                                       2. 抽出条件・入金/引当検索パラメータに自動入金区分・サービス伝票区分を追加</br>
    /// <br>             2007.10.11 980081 A.Yamada DC.NS用に変更</br>
    /// <br>             2007.12.10 980081 A.Yamada EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
    /// <br>Update Note : 2010/12/20 李占川 PM.NS障害改良対応(12月分)</br>
    /// <br>             入金日による絞り込み処理の修正</br>
    /// <br></br>
	/// </remarks>
	[Serializable]
	//public class DepositReadDB : RemoteDB , IDepositReadDB           //DEL 2008/06/27 M.Kubota
	public class DepositReadDB : RemoteWithAppLockDB , IDepositReadDB  //ADD 2008/06/27 M.Kubota
    {
		/// <summary>
		/// 入金/引当READDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 90027　高口　勝</br>
		/// <br>Date       : 2005.08.16</br>
		/// </remarks>
		public DepositReadDB() :
		base("SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitDataWork", "DEPSITMAINRF") //基底クラスのコンストラクタ
		{
			//SQLサーバーへの接続情報を取得
//			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        }

        #region 定数(ローカル)
        #region 入金マスタJOIN項目リスト

        //--- DEL 2008/06/27 M.Kubota --->>>
        # region 旧レイアウト(コメントアウト)
        // ↓ 2007.10.11 980081 c
        #region 旧レイアウト(コメントアウト)
        //private const string DEPSITMAIN_JOIN_COLUMNS =
        //                          " DM.CREATEDATETIMERF        DM_CREATEDATETIMERF"
        //                        + ",DM.UPDATEDATETIMERF        DM_UPDATEDATETIMERF"
        //                        + ",DM.ENTERPRISECODERF        DM_ENTERPRISECODERF"
        //                        + ",DM.FILEHEADERGUIDRF        DM_FILEHEADERGUIDRF"
        //                        + ",DM.UPDEMPLOYEECODERF       DM_UPDEMPLOYEECODERF"
        //                        + ",DM.UPDASSEMBLYID1RF        DM_UPDASSEMBLYID1RF"
        //                        + ",DM.UPDASSEMBLYID2RF        DM_UPDASSEMBLYID2RF"
        //                        + ",DM.LOGICALDELETECODERF     DM_LOGICALDELETECODERF"
        //                        + ",DM.DEPOSITDEBITNOTECDRF    DM_DEPOSITDEBITNOTECDRF"
        //                        + ",DM.DEPOSITSLIPNORF         DM_DEPOSITSLIPNORF"
        //                        + ",DM.ACCEPTANORDERNORF       DM_ACCEPTANORDERNORF"
        //                        + ",DM.SERVICESLIPCDRF         DM_SERVICESLIPCDRF"
        //                        + ",DM.INPUTDEPOSITSECCDRF     DM_INPUTDEPOSITSECCDRF"
        //                        + ",DM.ADDUPSECCODERF          DM_ADDUPSECCODERF"
        //                        + ",DM.UPDATESECCDRF           DM_UPDATESECCDRF"
        //                        + ",DM.DEPOSITDATERF           DM_DEPOSITDATERF"
        //                        + ",DM.ADDUPADATERF            DM_ADDUPADATERF"
        //                        + ",DM.DEPOSITKINDCODERF       DM_DEPOSITKINDCODERF"
        //                        + ",DM.DEPOSITKINDNAMERF       DM_DEPOSITKINDNAMERF"
        //                        + ",DM.DEPOSITKINDDIVCDRF      DM_DEPOSITKINDDIVCDRF"
        //                        + ",DM.DEPOSITTOTALRF          DM_DEPOSITTOTALRF"
        //                        + ",DM.DEPOSITRF               DM_DEPOSITRF"
        //                        + ",DM.FEEDEPOSITRF            DM_FEEDEPOSITRF"
        //                        + ",DM.DISCOUNTDEPOSITRF       DM_DISCOUNTDEPOSITRF"
        //                        + ",DM.REBATEDEPOSITRF         DM_REBATEDEPOSITRF"
        //                        + ",DM.AUTODEPOSITCDRF         DM_AUTODEPOSITCDRF"
        //                        + ",DM.DEPOSITCDRF             DM_DEPOSITCDRF"
        //                        + ",DM.CREDITORLOANCDRF        DM_CREDITORLOANCDRF"
        //                        + ",DM.CREDITCOMPANYCODERF     DM_CREDITCOMPANYCODERF"
        //                        + ",DM.DRAFTDRAWINGDATERF      DM_DRAFTDRAWINGDATERF"
        //                        + ",DM.DRAFTPAYTIMELIMITRF     DM_DRAFTPAYTIMELIMITRF"
        //                        + ",DM.DEPOSITALLOWANCERF      DM_DEPOSITALLOWANCERF"
        //                        + ",DM.DEPOSITALWCBLNCERF      DM_DEPOSITALWCBLNCERF"
        //                        + ",DM.DEBITNOTELINKDEPONORF   DM_DEBITNOTELINKDEPONORF"
        //                        + ",DM.LASTRECONCILEADDUPDTRF  DM_LASTRECONCILEADDUPDTRF"
        //                        + ",DM.DEPOSITAGENTCODERF      DM_DEPOSITAGENTCODERF"
        //                        + ",DM.DEPOSITAGENTNMRF        DM_DEPOSITAGENTNMRF"
        //                        + ",DM.CUSTOMERCODERF          DM_CUSTOMERCODERF"
        //                        + ",DM.CUSTOMERNAMERF          DM_CUSTOMERNAMERF"
        //                        + ",DM.CUSTOMERNAME2RF         DM_CUSTOMERNAME2RF"
        //                        + ",DM.OUTLINERF               DM_OUTLINERF"
        //                        ;
#endregion
        //private const string DEPSITMAIN_JOIN_COLUMNS =
        //                          " DM.CREATEDATETIMERF         DM_CREATEDATETIMERF"
        //                        + ",DM.UPDATEDATETIMERF         DM_UPDATEDATETIMERF"
        //                        + ",DM.ENTERPRISECODERF         DM_ENTERPRISECODERF"
        //                        + ",DM.FILEHEADERGUIDRF         DM_FILEHEADERGUIDRF"
        //                        + ",DM.UPDEMPLOYEECODERF        DM_UPDEMPLOYEECODERF"
        //                        + ",DM.UPDASSEMBLYID1RF         DM_UPDASSEMBLYID1RF"
        //                        + ",DM.UPDASSEMBLYID2RF         DM_UPDASSEMBLYID2RF"
        //                        + ",DM.LOGICALDELETECODERF      DM_LOGICALDELETECODERF"
        //                        + ",DM.ACPTANODRSTATUSRF        DM_ACPTANODRSTATUSRF"
        //                        + ",DM.DEPOSITDEBITNOTECDRF     DM_DEPOSITDEBITNOTECDRF"
        //                        + ",DM.DEPOSITSLIPNORF          DM_DEPOSITSLIPNORF"
        //                        + ",DM.SALESSLIPNUMRF           DM_SALESSLIPNUMRF"
        //                        + ",DM.INPUTDEPOSITSECCDRF      DM_INPUTDEPOSITSECCDRF"
        //                        + ",DM.ADDUPSECCODERF           DM_ADDUPSECCODERF"
        //                        + ",DM.UPDATESECCDRF            DM_UPDATESECCDRF"
        //                        + ",DM.SUBSECTIONCODERF         DM_SUBSECTIONCODERF"
        //                        + ",DM.MINSECTIONCODERF         DM_MINSECTIONCODERF"
        //                        + ",DM.DEPOSITDATERF            DM_DEPOSITDATERF"
        //                        + ",DM.ADDUPADATERF             DM_ADDUPADATERF"
        //                        + ",DM.DEPOSITKINDCODERF        DM_DEPOSITKINDCODERF"
        //                        + ",DM.DEPOSITKINDNAMERF        DM_DEPOSITKINDNAMERF"
        //                        + ",DM.DEPOSITKINDDIVCDRF       DM_DEPOSITKINDDIVCDRF"
        //                        + ",DM.DEPOSITTOTALRF           DM_DEPOSITTOTALRF"
        //                        + ",DM.DEPOSITRF                DM_DEPOSITRF"
        //                        + ",DM.FEEDEPOSITRF             DM_FEEDEPOSITRF"
        //                        + ",DM.DISCOUNTDEPOSITRF        DM_DISCOUNTDEPOSITRF"
        //                        + ",DM.AUTODEPOSITCDRF          DM_AUTODEPOSITCDRF"
        //                        + ",DM.DEPOSITCDRF              DM_DEPOSITCDRF"
        //                        + ",DM.DRAFTDRAWINGDATERF       DM_DRAFTDRAWINGDATERF"
        //                        + ",DM.DRAFTPAYTIMELIMITRF      DM_DRAFTPAYTIMELIMITRF"
        //                        + ",DM.DRAFTKINDRF              DM_DRAFTKINDRF"
        //                        + ",DM.DRAFTKINDNAMERF          DM_DRAFTKINDNAMERF"
        //                        + ",DM.DRAFTDIVIDERF            DM_DRAFTDIVIDERF"
        //                        + ",DM.DRAFTDIVIDENAMERF        DM_DRAFTDIVIDENAMERF"
        //                        + ",DM.DRAFTNORF                DM_DRAFTNORF"
        //                        + ",DM.DEPOSITALLOWANCERF       DM_DEPOSITALLOWANCERF"
        //                        + ",DM.DEPOSITALWCBLNCERF       DM_DEPOSITALWCBLNCERF"
        //                        + ",DM.DEBITNOTELINKDEPONORF    DM_DEBITNOTELINKDEPONORF"
        //                        + ",DM.LASTRECONCILEADDUPDTRF   DM_LASTRECONCILEADDUPDTRF"
        //                        + ",DM.DEPOSITAGENTCODERF       DM_DEPOSITAGENTCODERF"
        //                        + ",DM.DEPOSITAGENTNMRF         DM_DEPOSITAGENTNMRF"
        //                        + ",DM.DEPOSITINPUTAGENTCDRF    DM_DEPOSITINPUTAGENTCDRF"
        //                        + ",DM.DEPOSITINPUTAGENTNMRF    DM_DEPOSITINPUTAGENTNMRF"
        //                        + ",DM.CUSTOMERCODERF           DM_CUSTOMERCODERF"
        //                        + ",DM.CUSTOMERNAMERF           DM_CUSTOMERNAMERF"
        //                        + ",DM.CUSTOMERNAME2RF          DM_CUSTOMERNAME2RF"
        //                        + ",DM.CUSTOMERSNMRF            DM_CUSTOMERSNMRF"
        //                        + ",DM.CLAIMCODERF              DM_CLAIMCODERF"
        //                        + ",DM.CLAIMNAMERF              DM_CLAIMNAMERF"
        //                        + ",DM.CLAIMNAME2RF             DM_CLAIMNAME2RF"
        //                        + ",DM.CLAIMSNMRF               DM_CLAIMSNMRF"
        //                        + ",DM.OUTLINERF                DM_OUTLINERF"
        //                        + ",DM.BANKCODERF               DM_BANKCODERF"
        //                        + ",DM.BANKNAMERF               DM_BANKNAMERF"
        //                        + ",DM.EDISENDDATERF            DM_EDISENDDATERF"
        //                        + ",DM.EDITAKEINDATERF          DM_EDITAKEINDATERF"
        //                        ;
        // ↑ 2007.10.11 980081 c
        #endregion
        //--- DEL 2008/06/27 M.Kubota ---<<<
        //--- ADD 2008/06/27 M.Kubota --->>>
        private const string DEPSITMAIN_JOIN_COLUMNS =
          "  DM.CREATEDATETIMERF AS DM_CREATEDATETIMERF"
        + " ,DM.UPDATEDATETIMERF AS DM_UPDATEDATETIMERF"
        + " ,DM.ENTERPRISECODERF AS DM_ENTERPRISECODERF"
        + " ,DM.FILEHEADERGUIDRF AS DM_FILEHEADERGUIDRF"
        + " ,DM.UPDEMPLOYEECODERF AS DM_UPDEMPLOYEECODERF"
        + " ,DM.UPDASSEMBLYID1RF AS DM_UPDASSEMBLYID1RF"
        + " ,DM.UPDASSEMBLYID2RF AS DM_UPDASSEMBLYID2RF"
        + " ,DM.LOGICALDELETECODERF AS DM_LOGICALDELETECODERF"
        + " ,DM.ACPTANODRSTATUSRF AS DM_ACPTANODRSTATUSRF"
        + " ,DM.DEPOSITDEBITNOTECDRF AS DM_DEPOSITDEBITNOTECDRF"
        + " ,DM.DEPOSITSLIPNORF AS DM_DEPOSITSLIPNORF"
        + " ,DM.SALESSLIPNUMRF AS DM_SALESSLIPNUMRF"
        + " ,DM.INPUTDEPOSITSECCDRF AS DM_INPUTDEPOSITSECCDRF"
        + " ,DM.ADDUPSECCODERF AS DM_ADDUPSECCODERF"
        + " ,DM.UPDATESECCDRF AS DM_UPDATESECCDRF"
        + " ,DM.SUBSECTIONCODERF AS DM_SUBSECTIONCODERF"
        + " ,DM.DEPOSITDATERF AS DM_DEPOSITDATERF"
        + " ,DM.ADDUPADATERF AS DM_ADDUPADATERF"
        + " ,DM.DEPOSITTOTALRF AS DM_DEPOSITTOTALRF"
        + " ,DM.DEPOSITRF AS DM_DEPOSITRF"
        + " ,DM.FEEDEPOSITRF AS DM_FEEDEPOSITRF"
        + " ,DM.DISCOUNTDEPOSITRF AS DM_DISCOUNTDEPOSITRF"
        + " ,DM.AUTODEPOSITCDRF AS DM_AUTODEPOSITCDRF"
        + " ,DM.DRAFTDRAWINGDATERF AS DM_DRAFTDRAWINGDATERF"
        + " ,DM.DRAFTKINDRF AS DM_DRAFTKINDRF"
        + " ,DM.DRAFTKINDNAMERF AS DM_DRAFTKINDNAMERF"
        + " ,DM.DRAFTDIVIDERF AS DM_DRAFTDIVIDERF"
        + " ,DM.DRAFTDIVIDENAMERF AS DM_DRAFTDIVIDENAMERF"
        + " ,DM.DRAFTNORF AS DM_DRAFTNORF"
        + " ,DM.DEPOSITALLOWANCERF AS DM_DEPOSITALLOWANCERF"
        + " ,DM.DEPOSITALWCBLNCERF AS DM_DEPOSITALWCBLNCERF"
        + " ,DM.DEBITNOTELINKDEPONORF AS DM_DEBITNOTELINKDEPONORF"
        + " ,DM.LASTRECONCILEADDUPDTRF AS DM_LASTRECONCILEADDUPDTRF"
        + " ,DM.DEPOSITAGENTCODERF AS DM_DEPOSITAGENTCODERF"
        + " ,DM.DEPOSITAGENTNMRF AS DM_DEPOSITAGENTNMRF"
        + " ,DM.DEPOSITINPUTAGENTCDRF AS DM_DEPOSITINPUTAGENTCDRF"
        + " ,DM.DEPOSITINPUTAGENTNMRF AS DM_DEPOSITINPUTAGENTNMRF"
        + " ,DM.CUSTOMERCODERF AS DM_CUSTOMERCODERF"
        + " ,DM.CUSTOMERNAMERF AS DM_CUSTOMERNAMERF"
        + " ,DM.CUSTOMERNAME2RF AS DM_CUSTOMERNAME2RF"
        + " ,DM.CUSTOMERSNMRF AS DM_CUSTOMERSNMRF"
        + " ,DM.CLAIMCODERF AS DM_CLAIMCODERF"
        + " ,DM.CLAIMNAMERF AS DM_CLAIMNAMERF"
        + " ,DM.CLAIMNAME2RF AS DM_CLAIMNAME2RF"
        + " ,DM.CLAIMSNMRF AS DM_CLAIMSNMRF"
        + " ,DM.OUTLINERF AS DM_OUTLINERF"
        + " ,DM.BANKCODERF AS DM_BANKCODERF"
        + " ,DM.BANKNAMERF AS DM_BANKNAMERF";
        //--- ADD 2008/06/27 M.Kubota ---<<<

        #region 入金引当マスタJOIN項目リスト
        //--- DEL 2008/06/27 M.Kubota --->>>
        # region 旧レイアウト(コメントアウト)
        // ↓ 2007.10.11 980081 c
        #region 旧レイアウト(コメントアウト)
        //private const string DEPOSITALW_JOIN_COLUMNS = 
        //                          " DA.CREATEDATETIMERF      DA_CREATEDATETIMERF"
        //                        + ",DA.UPDATEDATETIMERF      DA_UPDATEDATETIMERF"
        //                        + ",DA.ENTERPRISECODERF      DA_ENTERPRISECODERF"
        //                        + ",DA.FILEHEADERGUIDRF      DA_FILEHEADERGUIDRF"
        //                        + ",DA.UPDEMPLOYEECODERF     DA_UPDEMPLOYEECODERF"
        //                        + ",DA.UPDASSEMBLYID1RF      DA_UPDASSEMBLYID1RF"
        //                        + ",DA.UPDASSEMBLYID2RF      DA_UPDASSEMBLYID2RF"
        //                        + ",DA.LOGICALDELETECODERF   DA_LOGICALDELETECODERF"
        //                        + ",DA.INPUTDEPOSITSECCDRF   DA_INPUTDEPOSITSECCDRF"
        //                        + ",DA.ADDUPSECCODERF        DA_ADDUPSECCODERF"
        //                        + ",DA.RECONCILEDATERF       DA_RECONCILEDATERF"
        //                        + ",DA.RECONCILEADDUPDATERF  DA_RECONCILEADDUPDATERF"
        //                        + ",DA.DEPOSITSLIPNORF       DA_DEPOSITSLIPNORF"
        //                        + ",DA.DEPOSITKINDCODERF     DA_DEPOSITKINDCODERF"
        //                        + ",DA.DEPOSITKINDNAMERF     DA_DEPOSITKINDNAMERF"
        //                        + ",DA.DEPOSITALLOWANCERF    DA_DEPOSITALLOWANCERF"
        //                        + ",DA.DEPOSITAGENTCODERF    DA_DEPOSITAGENTCODERF"
        //                        + ",DA.DEPOSITAGENTNMRF      DA_DEPOSITAGENTNMRF"
        //                        + ",DA.CUSTOMERCODERF        DA_CUSTOMERCODERF"
        //                        + ",DA.CUSTOMERNAMERF        DA_CUSTOMERNAMERF"
        //                        + ",DA.CUSTOMERNAME2RF       DA_CUSTOMERNAME2RF"
        //                        + ",DA.ACCEPTANORDERNORF     DA_ACCEPTANORDERNORF"
        //                        + ",DA.SERVICESLIPCDRF       DA_SERVICESLIPCDRF"
        //                        + ",DA.DEBITNOTEOFFSETCDRF   DA_DEBITNOTEOFFSETCDRF"
        //                        + ",DA.DEPOSITCDRF           DA_DEPOSITCDRF"
        //                        + ",DA.CREDITORLOANCDRF      DA_CREDITORLOANCDRF"
        //                        ;
        #endregion
        //private const string DEPOSITALW_JOIN_COLUMNS =
        //                          " DA.CREATEDATETIMERF       DA_CREATEDATETIMERF"
        //                        + ",DA.UPDATEDATETIMERF       DA_UPDATEDATETIMERF"
        //                        + ",DA.ENTERPRISECODERF       DA_ENTERPRISECODERF"
        //                        + ",DA.FILEHEADERGUIDRF       DA_FILEHEADERGUIDRF"
        //                        + ",DA.UPDEMPLOYEECODERF      DA_UPDEMPLOYEECODERF"
        //                        + ",DA.UPDASSEMBLYID1RF       DA_UPDASSEMBLYID1RF"
        //                        + ",DA.UPDASSEMBLYID2RF       DA_UPDASSEMBLYID2RF"
        //                        + ",DA.LOGICALDELETECODERF    DA_LOGICALDELETECODERF"
        //                        + ",DA.INPUTDEPOSITSECCDRF    DA_INPUTDEPOSITSECCDRF"
        //                        + ",DA.ADDUPSECCODERF         DA_ADDUPSECCODERF"
        //                        + ",DA.RECONCILEDATERF        DA_RECONCILEDATERF"
        //                        + ",DA.RECONCILEADDUPDATERF   DA_RECONCILEADDUPDATERF"
        //                        + ",DA.DEPOSITSLIPNORF        DA_DEPOSITSLIPNORF"
        //                        + ",DA.DEPOSITKINDCODERF      DA_DEPOSITKINDCODERF"
        //                        + ",DA.DEPOSITKINDNAMERF      DA_DEPOSITKINDNAMERF"
        //                        + ",DA.DEPOSITALLOWANCERF     DA_DEPOSITALLOWANCERF"
        //                        + ",DA.DEPOSITAGENTCODERF     DA_DEPOSITAGENTCODERF"
        //                        + ",DA.DEPOSITAGENTNMRF       DA_DEPOSITAGENTNMRF"
        //                        + ",DA.CUSTOMERCODERF         DA_CUSTOMERCODERF"
        //                        + ",DA.CUSTOMERNAMERF         DA_CUSTOMERNAMERF"
        //                        + ",DA.CUSTOMERNAME2RF        DA_CUSTOMERNAME2RF"
        //                        + ",DA.DEBITNOTEOFFSETCDRF    DA_DEBITNOTEOFFSETCDRF"
        //                        + ",DA.DEPOSITCDRF            DA_DEPOSITCDRF"
        //                        + ",DA.ACPTANODRSTATUSRF      DA_ACPTANODRSTATUSRF"
        //                        + ",DA.SALESSLIPNUMRF         DA_SALESSLIPNUMRF"
        //                        ;
        // ↑ 2007.10.11 980081 c
        #endregion
        //--- DEL 2008/06/27 M.Kubota ---<<<
        
        //--- ADD 2008/06/27 M.Kubota --->>>
        private const string DEPOSITALW_JOIN_COLUMNS =
          " ,DA.CREATEDATETIMERF AS DA_CREATEDATETIMERF"
        + " ,DA.UPDATEDATETIMERF AS DA_UPDATEDATETIMERF"
        + " ,DA.ENTERPRISECODERF AS DA_ENTERPRISECODERF"
        + " ,DA.FILEHEADERGUIDRF AS DA_FILEHEADERGUIDRF"
        + " ,DA.UPDEMPLOYEECODERF AS DA_UPDEMPLOYEECODERF"
        + " ,DA.UPDASSEMBLYID1RF AS DA_UPDASSEMBLYID1RF"
        + " ,DA.UPDASSEMBLYID2RF AS DA_UPDASSEMBLYID2RF"
        + " ,DA.LOGICALDELETECODERF AS DA_LOGICALDELETECODERF"
        + " ,DA.INPUTDEPOSITSECCDRF AS DA_INPUTDEPOSITSECCDRF"
        + " ,DA.ADDUPSECCODERF AS DA_ADDUPSECCODERF"
        + " ,DA.ACPTANODRSTATUSRF AS DA_ACPTANODRSTATUSRF"
        + " ,DA.SALESSLIPNUMRF AS DA_SALESSLIPNUMRF"
        + " ,DA.RECONCILEDATERF AS DA_RECONCILEDATERF"
        + " ,DA.RECONCILEADDUPDATERF AS DA_RECONCILEADDUPDATERF"
        + " ,DA.DEPOSITSLIPNORF AS DA_DEPOSITSLIPNORF"
        + " ,DA.DEPOSITALLOWANCERF AS DA_DEPOSITALLOWANCERF"
        + " ,DA.DEPOSITAGENTCODERF AS DA_DEPOSITAGENTCODERF"
        + " ,DA.DEPOSITAGENTNMRF AS DA_DEPOSITAGENTNMRF"
        + " ,DA.CUSTOMERCODERF AS DA_CUSTOMERCODERF"
        + " ,DA.CUSTOMERNAMERF AS DA_CUSTOMERNAMERF"
        + " ,DA.CUSTOMERNAME2RF AS DA_CUSTOMERNAME2RF"
        + " ,DA.DEBITNOTEOFFSETCDRF AS DA_DEBITNOTEOFFSETCDRF";
        //--- ADD 2008/06/27 M.Kubota ---<<<
        #endregion

        // 入金マスタ基準の入金引当マスタJOIN
        private const string DEPSITMAIN_BASE = 
                                  "SELECT" + DEPSITMAIN_JOIN_COLUMNS
                                 //+            ","  //DEL 2008/06/27 M.Kubota
                                 +            DEPOSITALW_JOIN_COLUMNS
                                 + " FROM      DEPSITMAINRF DM"
                                 + " LEFT JOIN DEPOSITALWRF DA"
                                 +          " ON     DM.ENTERPRISECODERF = DA.ENTERPRISECODERF"
                                 +             " AND DM.CUSTOMERCODERF   = DA.CUSTOMERCODERF"
                                 +             " AND DM.ADDUPSECCODERF   = DA.ADDUPSECCODERF"
                                 +             " AND DM.DEPOSITSLIPNORF  = DA.DEPOSITSLIPNORF"
                                 ;

        // 入金引当マスタの入金マスタ基準JOIN
        private const string DEPOSITALW_BASE = 
                                  "SELECT" + DEPSITMAIN_JOIN_COLUMNS
                                 //+             ","  //DEL 2008/06/27 M.Kubota
                                 +            DEPOSITALW_JOIN_COLUMNS
                                 + " FROM      DEPOSITALWRF DA"
                                 + " LEFT JOIN DEPSITMAINRF DM"
                                 +        " ON    DA.ENTERPRISECODERF = DM.ENTERPRISECODERF"
                                 +          " AND DA.CUSTOMERCODERF   = DM.CUSTOMERCODERF"
                                 +          " AND DA.ADDUPSECCODERF   = DM.ADDUPSECCODERF"
                                 +          " AND DA.DEPOSITSLIPNORF  = DM.DEPOSITSLIPNORF"
                                 ;
        #endregion
        #endregion

        #region ノンカスタムシリアライズ

        // ↓ 20070124 18322 c MA.NS用に変更(＆SearchProcを１つにマージ)
        #region SF 指定された企業コードの入金/引当READLISTを全て戻します（全てコメントアウト）
        ///// <summary>
        ///// 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）
        ///// </summary>
        ///// <param name="depsitDataWork">検索結果</param>
        ///// <param name="depositAlwWork">検索結果</param>
        ///// <param name="searchParaDepositRead">検索パラメータ</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）</br>
        ///// <br>Programmer : 90027　高口　勝</br>
        ///// <br>Date       : 2005.08.16</br>
        //public int Search(out byte[] depsitDataWork , out byte[] depositAlwWork , object searchParaDepositRead , int readMode,ConstantManagement.LogicalMode logicalMode)
        //{		
        //    bool nextData;
        //    int retTotalCnt;
        //    SearchParaDepositRead _searchParaDepositRead = searchParaDepositRead as SearchParaDepositRead;
//      //      return SearchProc(out depsitDataWork , out depositAlwWork , out retTotalCnt , out nextData , _searchParaDepositRead , readMode , logicalMode , 0);
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    depsitDataWork = null;
        //    depositAlwWork = null;
        //    try
        //    {
        //        status =  SearchProc(out depsitDataWork , out depositAlwWork , out retTotalCnt , out nextData , _searchParaDepositRead , readMode , logicalMode , 0);
        //    }
        //    catch(Exception ex)
        //    {
        //        base.WriteErrorLog(ex,"DepositReadDB.Search Exception="+ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    return status;
        //}
        #endregion

        /// <summary>
        /// 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="depsitDataWork">検索結果</param>
        /// <param name="depositAlwWork">検索結果</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Date: 2007.04.06 T.Kimura SearchProcパラメータを変更</br>
        public int Search( out byte[]  depsitDataWork
                         , out byte[]  depositAlwWork
                         ,     object  searchParaDepositRead
                         ,     int     readMode
                         ,             ConstantManagement.LogicalMode logicalMode)
        {		
            bool nextData;
            int retTotalCnt;

            depsitDataWork = null;
            depositAlwWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            SearchParaDepositRead _searchParaDepositRead = searchParaDepositRead as SearchParaDepositRead;
            if (_searchParaDepositRead == null)
            {
                // パラメータエラー -> ダミーデータを作成して終了
                ArrayList al = new ArrayList();
                //--- DEL 2008/06/27 M.Kubota --->>>
                //al.Add(new DepsitDataWork());
                //DepsitDataWork[] DepsitDataWorks = (DepsitDataWork[])al.ToArray(typeof(DepsitDataWork));
                //depsitDataWork = XmlByteSerializer.Serialize(DepsitDataWorks);
                //--- DEL 2008/06/27 M.Kubota ---<<<
                //--- ADD 2008/06/27 M.Kubota --->>>
                al.Add(new DepsitDataWork());
                DepsitDataWork[] DepsitDataWorks = (DepsitDataWork[])al.ToArray(typeof(DepsitDataWork));
                depsitDataWork = XmlByteSerializer.Serialize(DepsitDataWorks);
                //--- ADD 2008/06/27 M.Kubota ---<<<

                ArrayList al2 = new ArrayList();
                al2.Add(new DepositAlwWork());
                DepositAlwWork[] DepositAlwWorks = (DepositAlwWork[])al2.ToArray(typeof(DepositAlwWork));
                depositAlwWork = XmlByteSerializer.Serialize(DepositAlwWorks);
                return status;
            }

            try
            {
                //object arrDepsitMainWork;  //DEL 2008/06/27 M.Kubota
                object arrDepsitDataWork;    //ADD 2008/06/27 M.Kubota
                object arrDepositAlwWork;
                
                SqlConnection sqlConnection = null;
                // -- 2007.07.05　SearchProcの引数にSqlTransaction追加
                SqlTransaction sqlTransaction = null;
                status = SearchProc(// out arrDepsitMainWork  //DEL 2008/06/27 M.Kubota
                                     out arrDepsitDataWork    //ADD 2008/06/27 M.Kubota
                                   , out arrDepositAlwWork
                                   , out retTotalCnt
                                   , out nextData
                                   , _searchParaDepositRead
                                   , readMode
                                   , logicalMode
                                   , 0
                                   , ref sqlConnection
                                   , ref sqlTransaction);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 正常終了した場合

                    // XMLへ変換し、文字列のバイナリ化
                    //--- DEL 2008/06/27 M.Kubota --->>>
                    //ArrayList al = (ArrayList)arrDepsitMainWork;
                    //DepsitDataWork[] DepsitMainWorks = (DepsitDataWork[])al.ToArray(typeof(DepsitDataWork));
                    //depsitDataWork = XmlByteSerializer.Serialize(DepsitMainWorks);
                    //--- DEL 2008/06/27 M.Kubota ---<<<
                    //--- ADD 2008/06/27 M.Kubota --->>>
                    ArrayList al = (ArrayList)arrDepsitDataWork;
                    DepsitDataWork[] DepsitDataWorks = (DepsitDataWork[])al.ToArray(typeof(DepsitDataWork));
                    depsitDataWork = XmlByteSerializer.Serialize(DepsitDataWorks);
                    //--- ADD 2008/06/27 M.Kubota ---<<<

                    ArrayList al2 = (ArrayList)arrDepositAlwWork;
                    DepositAlwWork[] DepositAlwWorks = (DepositAlwWork[])al2.ToArray(typeof(DepositAlwWork));
                    depositAlwWork = XmlByteSerializer.Serialize(DepositAlwWorks);
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositReadDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        // ↑ 20070124 18322 c

        // ↓ 20070124 18322 d MA.NS用に変更（別のSearchProc関数を使用する為削除）
        #region SF 指定された企業コードの入金/引当READLISTを全て戻します（全てコメントアウト）
        ///// <summary>
        ///// 指定された企業コードの入金/引当READLISTを全て戻します
        ///// </summary>
        ///// <param name="depsitDataWork">検索結果</param>
        ///// <param name="depositAlwWork">検索結果</param>
        ///// <param name="retTotalCnt">検索対象総件数</param>		
        ///// <param name="nextData">次データ有無</param>
        ///// <param name="searchParaDepositRead">検索パラメータ</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="readCnt">READ件数（0の場合はALL）</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された企業コードの入金/引当READLISTを全て戻します</br>
        ///// <br>Programmer : 90027　高口　勝</br>
        ///// <br>Date       : 2005.08.16</br>
//      //  private int SearchProc(out byte[] depsitDataWork , out byte[] depositAlwWork , out int retTotalCnt , out bool nextData , object searchParaDepositRead , int readMode , ConstantManagement.LogicalMode logicalMode , int readCnt)
        //private int SearchProc(out byte[] depsitDataWork , out byte[] depositAlwWork , out int retTotalCnt , out bool nextData , SearchParaDepositRead searchParaDepositRead , int readMode , ConstantManagement.LogicalMode logicalMode , int readCnt)
        //{
        //    SearchParaDepositRead SPTA = (SearchParaDepositRead)searchParaDepositRead;
        //    string enterpriseCode           = SPTA.EnterpriseCode;
        //    string addUpSecCode             = SPTA.AddUpSecCode;
        //    int customerCode                = SPTA.CustomerCode;
        //    int acceptAnOrderNo             = SPTA.AcceptAnOrderNo;
        //    int depositSlipNo               = SPTA.DepositSlipNo;
        //    DateTime depositCallMonthsStart = SPTA.DepositCallMonthsStart;
        //    DateTime depositCallMonthsEnd   = SPTA.DepositCallMonthsEnd;
        //    int alwcDepositCall             = SPTA.AlwcDepositCall;
        //
        //    depsitDataWork = null;
        //    depositAlwWork = null;
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlConnection sqlConnection = null;
        //    SqlDataReader sqlDataReader = null;
        //    SqlCommand sqlCommand = null;
        //
        //    DepsitDataWork depsitmainWork = new DepsitDataWork();
        //    DepositAlwWork depositalwWork = new DepositAlwWork();
        //
        //    depsitmainWork = null;
        //    depositalwWork = null;
        //
        //    //総件数を0で初期化
        //    retTotalCnt = 0;
        //
        //    //件数指定リードの場合には指定件数＋１件リードする
        //    int _readCnt = readCnt;			
        //    if (_readCnt > 0) _readCnt += 1;
        //    //次レコード無しで初期化
        //    nextData = false;
        //
        //
        //    int sDate  = 0;
        //    int eDate  = 0;
        //    try
        //    {
        //        sDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsStart);
        //        eDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsEnd);
        //    }
        //    catch(Exception)
        //    {
        //        sDate = 0;
        //        eDate = 0;
        //    }
        //
        //
        //
        //
        //    ArrayList al  = new ArrayList();
        //    ArrayList al2 = new ArrayList();
        //
        //    ArrayList alwk    = new ArrayList();   //重複データ検索用
        //    ArrayList alwk2   = new ArrayList();   //重複データ検索用２
        //
        //
        //    try
        //    {
        //    try 
        //    {	
        //        //コネクション文字列取得対応↓↓↓↓↓
        //        //※各publicメソッドの開始時にコネクション文字列を取得
        //        //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //        if (connectionText == null || connectionText == "") return status;
        //        //コネクション文字列取得対応↑↑↑↑↑
        //
//      //          // XMLの読み込み
//      //          depsitmainWork = (DepsitDataWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepsitDataWork));
        //
        //        if (acceptAnOrderNo==0)   //受注番号が入っていなければ、入金マスタを軸にデータ抽出。入っていれば、引当マスタを軸にデータ抽出
        //        {
        //           //--- 受注番号が入っていない場合 ----------//
        //           //SQL文生成
        //           sqlConnection = new SqlConnection(connectionText);
        //           sqlConnection.Open();				
        //
        //           sqlCommand = new SqlCommand("SELECT "
        //               + "DM.CREATEDATETIMERF       DM_CREATEDATETIMERF       , DM.UPDATEDATETIMERF       DM_UPDATEDATETIMERF       , DM.ENTERPRISECODERF     DM_ENTERPRISECODERF ,"
        //               + "DM.FILEHEADERGUIDRF       DM_FILEHEADERGUIDRF       , DM.UPDEMPLOYEECODERF      DM_UPDEMPLOYEECODERF      , DM.UPDASSEMBLYID1RF     DM_UPDASSEMBLYID1RF ,"
        //               + "DM.UPDASSEMBLYID2RF       DM_UPDASSEMBLYID2RF       , DM.LOGICALDELETECODERF    DM_LOGICALDELETECODERF    , DM.DEPOSITDEBITNOTECDRF DM_DEPOSITDEBITNOTECDRF ,"
        //               + "DM.DEPOSITSLIPNORF        DM_DEPOSITSLIPNORF        , DM.DEPOSITKINDCODERF      DM_DEPOSITKINDCODERF      , DM.CUSTOMERCODERF       DM_CUSTOMERCODERF ,"
        //               + "DM.DEPOSITCDRF            DM_DEPOSITCDRF            , DM.DEPOSITTOTALRF         DM_DEPOSITTOTALRF         , DM.OUTLINERF            DM_OUTLINERF,"
        //               + "DM.ACCEPTANORDERSALESNORF DM_ACCEPTANORDERSALESNORF , DM.INPUTDEPOSITSECCDRF    DM_INPUTDEPOSITSECCDRF    , DM.DEPOSITDATERF        DM_DEPOSITDATERF ,"
        //               + "DM.ADDUPSECCODERF         DM_ADDUPSECCODERF         , DM.ADDUPADATERF           DM_ADDUPADATERF           , DM.UPDATESECCDRF        DM_UPDATESECCDRF ,"
        //               + "DM.DEPOSITKINDNAMERF      DM_DEPOSITKINDNAMERF      , DM.DEPOSITALLOWANCERF     DM_DEPOSITALLOWANCERF     , DM.DEPOSITALWCBLNCERF   DM_DEPOSITALWCBLNCERF ,"
        //               + "DM.DEPOSITAGENTCODERF     DM_DEPOSITAGENTCODERF     , DM.DEPOSITKINDDIVCDRF     DM_DEPOSITKINDDIVCDRF     , DM.FEEDEPOSITRF         DM_FEEDEPOSITRF ,"
        //               + "DM.DISCOUNTDEPOSITRF      DM_DISCOUNTDEPOSITRF      , DM.CREDITORLOANCDRF       DM_CREDITORLOANCDRF       , DM.CREDITCOMPANYCODERF  DM_CREDITCOMPANYCODERF ,"
        //               + "DM.DEPOSITRF              DM_DEPOSITRF              , DM.DRAFTDRAWINGDATERF     DM_DRAFTDRAWINGDATERF     , DM.DRAFTPAYTIMELIMITRF  DM_DRAFTPAYTIMELIMITRF ,"
        //               + "DM.DEBITNOTELINKDEPONORF  DM_DEBITNOTELINKDEPONORF  , DM.LASTRECONCILEADDUPDTRF DM_LASTRECONCILEADDUPDTRF , DM.AUTODEPOSITCDRF      DM_AUTODEPOSITCDRF ,"
        //               + "DM.ACPODRDEPOSITRF        DM_ACPODRDEPOSITRF        , DM.ACPODRCHARGEDEPOSITRF  DM_ACPODRCHARGEDEPOSITRF  , DM.ACPODRDISDEPOSITRF   DM_ACPODRDISDEPOSITRF ,"
        //               + "DM.VARIOUSCOSTDEPOSITRF   DM_VARIOUSCOSTDEPOSITRF   , DM.VARCOSTCHARGEDEPOSITRF DM_VARCOSTCHARGEDEPOSITRF , DM.VARCOSTDISDEPOSITRF  DM_VARCOSTDISDEPOSITRF ,"
        //               + "DM.ACPODRDEPOSITALWCRF    DM_ACPODRDEPOSITALWCRF    , DM.ACPODRDEPOALWCBLNCERF  DM_ACPODRDEPOALWCBLNCERF  , DM.VARCOSTDEPOALWCRF    DM_VARCOSTDEPOALWCRF ,"
        //               + "DM.VARCOSTDEPOALWCBLNCERF DM_VARCOSTDEPOALWCBLNCERF ," 
        //
        //               + "DA.CREATEDATETIMERF    DA_CREATEDATETIMERF    , DA.UPDATEDATETIMERF     DA_UPDATEDATETIMERF ,    DA.ENTERPRISECODERF    DA_ENTERPRISECODERF ,"
        //               + "DA.FILEHEADERGUIDRF    DA_FILEHEADERGUIDRF    , DA.UPDEMPLOYEECODERF    DA_UPDEMPLOYEECODERF ,   DA.UPDASSEMBLYID1RF    DA_UPDASSEMBLYID1RF ,"
        //               + "DA.UPDASSEMBLYID2RF    DA_UPDASSEMBLYID2RF    , DA.LOGICALDELETECODERF  DA_LOGICALDELETECODERF , DA.CUSTOMERCODERF      DA_CUSTOMERCODERF ,"
        //               + "DA.ADDUPSECCODERF      DA_ADDUPSECCODERF      , DA.ACCEPTANORDERNORF    DA_ACCEPTANORDERNORF ,   DA.DEPOSITSLIPNORF     DA_DEPOSITSLIPNORF ,"
        //               + "DA.DEPOSITKINDCODERF   DA_DEPOSITKINDCODERF   , DA.DEPOSITINPUTDATERF   DA_DEPOSITINPUTDATERF ,  DA.DEPOSITALLOWANCERF  DA_DEPOSITALLOWANCERF ,"
        //               + "DA.RECONCILEDATERF     DA_RECONCILEDATERF     , DA.RECONCILEADDUPDATERF DA_RECONCILEADDUPDATERF ,DA.DEBITNOTEOFFSETCDRF DA_DEBITNOTEOFFSETCDRF ,"
        //               + "DA.DEPOSITCDRF         DA_DEPOSITCDRF         , DA.CREDITORLOANCDRF     DA_CREDITORLOANCDRF ,"
        //               + "DA.ACPODRDEPOSITALWCRF DA_ACPODRDEPOSITALWCRF , DA.VARCOSTDEPOALWCRF    DA_VARCOSTDEPOALWCRF "
        //
        //               + " FROM DEPSITMAINRF DM "
        //               + "LEFT JOIN DEPOSITALWRF DA   ON  DM.ENTERPRISECODERF  = DA.ENTERPRISECODERF " 
        //               + "AND                             DM.CUSTOMERCODERF    = DA.CUSTOMERCODERF "  
        //               + "AND                             DM.ADDUPSECCODERF    = DA.ADDUPSECCODERF "  
        //               + "AND                             DM.DEPOSITSLIPNORF   = DA.DEPOSITSLIPNORF "  
        //               ,sqlConnection);
        //        
		//           //WHERE文の作成
        //           sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
        //
        //           //入金/引当ﾏｽﾀ Read
        //           sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //           int retCnt = 0;
        //
        //           while(sqlDataReader.Read())
        //           {
        //               //戻り値カウンタカウント
        //               retCnt += 1;
        //               if (readCnt > 0)
        //               {
        //                   //戻り値の件数が取得指示件数を超えた場合終了
        //                   if (readCnt < retCnt) 
        //                   {
        //                       nextData = true;
        //                       break;
        //                   }
        //               }
        //
        //               //入金マスタ
        //               #region 値セット
        //               DepsitDataWork wkDepsitMainWork = new DepsitDataWork();
        //
        //               wkDepsitMainWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
        //               wkDepsitMainWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
        //               wkDepsitMainWork.EnterpriseCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
        //               wkDepsitMainWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
        //               wkDepsitMainWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
        //               wkDepsitMainWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
        //               wkDepsitMainWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
        //               wkDepsitMainWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
        //
        //               wkDepsitMainWork.DepositDebitNoteCd   = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
        //               wkDepsitMainWork.DepositSlipNo        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
        //               wkDepsitMainWork.DepositKindCode      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
        //               wkDepsitMainWork.CustomerCode         = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
        //               wkDepsitMainWork.DepositCd            = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
        //               wkDepsitMainWork.DepositTotal         = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
        //               wkDepsitMainWork.Outline              = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
        //               wkDepsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERSALESNORF"));
        //               wkDepsitMainWork.InputDepositSecCd    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
        //               wkDepsitMainWork.DepositDate          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
        //               wkDepsitMainWork.AddUpSecCode         = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
        //               wkDepsitMainWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
        //               wkDepsitMainWork.UpdateSecCd          = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
        //               wkDepsitMainWork.DepositKindName      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
        //               wkDepsitMainWork.DepositAllowance     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
        //               wkDepsitMainWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
        //               wkDepsitMainWork.DepositAgentCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
        //               wkDepsitMainWork.DepositKindDivCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
        //               wkDepsitMainWork.FeeDeposit           = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
        //               wkDepsitMainWork.DiscountDeposit      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
        //               wkDepsitMainWork.CreditOrLoanCd       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
        //               wkDepsitMainWork.CreditCompanyCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
        //               wkDepsitMainWork.Deposit              = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
        //               wkDepsitMainWork.DraftDrawingDate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
        //               wkDepsitMainWork.DraftPayTimeLimit    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
        //               wkDepsitMainWork.DebitNoteLinkDepoNo  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
        //               wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
        //               wkDepsitMainWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
        //
        //               wkDepsitMainWork.AcpOdrDeposit        = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITRF"));
        //               wkDepsitMainWork.AcpOdrChargeDeposit  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRCHARGEDEPOSITRF"));
        //               wkDepsitMainWork.AcpOdrDisDeposit     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDISDEPOSITRF"));
        //               wkDepsitMainWork.VariousCostDeposit   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARIOUSCOSTDEPOSITRF"));
        //               wkDepsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTCHARGEDEPOSITRF"));
        //               wkDepsitMainWork.VarCostDisDeposit    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDISDEPOSITRF"));
        //               wkDepsitMainWork.AcpOdrDepositAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITALWCRF"));
        //               wkDepsitMainWork.AcpOdrDepoAlwcBlnce  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOALWCBLNCERF"));
        //               wkDepsitMainWork.VarCostDepoAlwc      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCRF"));
        //               wkDepsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCBLNCERF"));
        //
//      //                 al.Add(wkDepsitMainWork);
        //               int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
        //               int myIndex=alwk.IndexOf( myObjectOdd );
        //               if ( myIndex < 0 )
        //               {
        //                  alwk.Add(wkDepsitMainWork.DepositSlipNo);
        //                  al.Add(wkDepsitMainWork);
        //               }
        //               #endregion
        //
        //
        //               //引当マスタ
        //               #region 値セット
        //               DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
        //
        //               wkDepositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
        //               wkDepositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
        //               wkDepositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
        //               wkDepositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
        //               wkDepositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
        //               wkDepositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
        //               wkDepositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
        //               wkDepositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
        //
        //               wkDepositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
        //               wkDepositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
        //               wkDepositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
        //               wkDepositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
        //               wkDepositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
        //               wkDepositAlwWork.DepositInputDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITINPUTDATERF"));
        //               wkDepositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
        //               wkDepositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
        //               wkDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
        //               wkDepositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
        //               wkDepositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
        //               wkDepositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
        //
        //               wkDepositAlwWork.AcpOdrDepositAlwc  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACPODRDEPOSITALWCRF"));
        //               wkDepositAlwWork.VarCostDepoAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_VARCOSTDEPOALWCRF"));
        //
        //               if (wkDepositAlwWork.UpdAssemblyId1 != "")
        //               {
        //                  al2.Add(wkDepositAlwWork);
        //               }
        //               #endregion
        //
        //               status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //           }
        //        }
        //        else
        //        {
        //            //--- 受注番号が入っている場合 ----------//
        //            //SQL文生成
        //            sqlConnection = new SqlConnection(connectionText);
        //            sqlConnection.Open();				
        //
        //            sqlCommand = new SqlCommand("SELECT "
        //                + "DM.CREATEDATETIMERF       DM_CREATEDATETIMERF       , DM.UPDATEDATETIMERF       DM_UPDATEDATETIMERF       , DM.ENTERPRISECODERF     DM_ENTERPRISECODERF ,"
        //                + "DM.FILEHEADERGUIDRF       DM_FILEHEADERGUIDRF       , DM.UPDEMPLOYEECODERF      DM_UPDEMPLOYEECODERF      , DM.UPDASSEMBLYID1RF     DM_UPDASSEMBLYID1RF ,"
        //                + "DM.UPDASSEMBLYID2RF       DM_UPDASSEMBLYID2RF       , DM.LOGICALDELETECODERF    DM_LOGICALDELETECODERF    , DM.DEPOSITDEBITNOTECDRF DM_DEPOSITDEBITNOTECDRF ,"
        //                + "DM.DEPOSITSLIPNORF        DM_DEPOSITSLIPNORF        , DM.DEPOSITKINDCODERF      DM_DEPOSITKINDCODERF      , DM.CUSTOMERCODERF       DM_CUSTOMERCODERF ,"
        //                + "DM.DEPOSITCDRF            DM_DEPOSITCDRF            , DM.DEPOSITTOTALRF         DM_DEPOSITTOTALRF         , DM.OUTLINERF            DM_OUTLINERF,"
        //                + "DM.ACCEPTANORDERSALESNORF DM_ACCEPTANORDERSALESNORF , DM.INPUTDEPOSITSECCDRF    DM_INPUTDEPOSITSECCDRF    , DM.DEPOSITDATERF        DM_DEPOSITDATERF ,"
        //                + "DM.ADDUPSECCODERF         DM_ADDUPSECCODERF         , DM.ADDUPADATERF           DM_ADDUPADATERF           , DM.UPDATESECCDRF        DM_UPDATESECCDRF ,"
        //                + "DM.DEPOSITKINDNAMERF      DM_DEPOSITKINDNAMERF      , DM.DEPOSITALLOWANCERF     DM_DEPOSITALLOWANCERF     , DM.DEPOSITALWCBLNCERF   DM_DEPOSITALWCBLNCERF ,"
        //                + "DM.DEPOSITAGENTCODERF     DM_DEPOSITAGENTCODERF     , DM.DEPOSITKINDDIVCDRF     DM_DEPOSITKINDDIVCDRF     , DM.FEEDEPOSITRF         DM_FEEDEPOSITRF ,"
        //                + "DM.DISCOUNTDEPOSITRF      DM_DISCOUNTDEPOSITRF      , DM.CREDITORLOANCDRF       DM_CREDITORLOANCDRF       , DM.CREDITCOMPANYCODERF  DM_CREDITCOMPANYCODERF ,"
        //                + "DM.DEPOSITRF              DM_DEPOSITRF              , DM.DRAFTDRAWINGDATERF     DM_DRAFTDRAWINGDATERF     , DM.DRAFTPAYTIMELIMITRF  DM_DRAFTPAYTIMELIMITRF ,"
        //                + "DM.DEBITNOTELINKDEPONORF  DM_DEBITNOTELINKDEPONORF  , DM.LASTRECONCILEADDUPDTRF DM_LASTRECONCILEADDUPDTRF , DM.AUTODEPOSITCDRF      DM_AUTODEPOSITCDRF ,"
        //                + "DM.ACPODRDEPOSITRF        DM_ACPODRDEPOSITRF        , DM.ACPODRCHARGEDEPOSITRF  DM_ACPODRCHARGEDEPOSITRF  , DM.ACPODRDISDEPOSITRF   DM_ACPODRDISDEPOSITRF ,"
        //                + "DM.VARIOUSCOSTDEPOSITRF   DM_VARIOUSCOSTDEPOSITRF   , DM.VARCOSTCHARGEDEPOSITRF DM_VARCOSTCHARGEDEPOSITRF , DM.VARCOSTDISDEPOSITRF  DM_VARCOSTDISDEPOSITRF ,"
        //                + "DM.ACPODRDEPOSITALWCRF    DM_ACPODRDEPOSITALWCRF    , DM.ACPODRDEPOALWCBLNCERF  DM_ACPODRDEPOALWCBLNCERF  , DM.VARCOSTDEPOALWCRF    DM_VARCOSTDEPOALWCRF ,"
        //                + "DM.VARCOSTDEPOALWCBLNCERF DM_VARCOSTDEPOALWCBLNCERF ," 
        //
        //                + "DA.CREATEDATETIMERF    DA_CREATEDATETIMERF    , DA.UPDATEDATETIMERF     DA_UPDATEDATETIMERF ,    DA.ENTERPRISECODERF    DA_ENTERPRISECODERF ,"
        //                + "DA.FILEHEADERGUIDRF    DA_FILEHEADERGUIDRF    , DA.UPDEMPLOYEECODERF    DA_UPDEMPLOYEECODERF ,   DA.UPDASSEMBLYID1RF    DA_UPDASSEMBLYID1RF ,"
        //                + "DA.UPDASSEMBLYID2RF    DA_UPDASSEMBLYID2RF    , DA.LOGICALDELETECODERF  DA_LOGICALDELETECODERF , DA.CUSTOMERCODERF      DA_CUSTOMERCODERF ,"
        //                + "DA.ADDUPSECCODERF      DA_ADDUPSECCODERF      , DA.ACCEPTANORDERNORF    DA_ACCEPTANORDERNORF ,   DA.DEPOSITSLIPNORF     DA_DEPOSITSLIPNORF ,"
        //                + "DA.DEPOSITKINDCODERF   DA_DEPOSITKINDCODERF   , DA.DEPOSITINPUTDATERF   DA_DEPOSITINPUTDATERF ,  DA.DEPOSITALLOWANCERF  DA_DEPOSITALLOWANCERF ,"
        //                + "DA.RECONCILEDATERF     DA_RECONCILEDATERF     , DA.RECONCILEADDUPDATERF DA_RECONCILEADDUPDATERF ,DA.DEBITNOTEOFFSETCDRF DA_DEBITNOTEOFFSETCDRF ,"
        //                + "DA.DEPOSITCDRF         DA_DEPOSITCDRF         , DA.CREDITORLOANCDRF     DA_CREDITORLOANCDRF ,"
        //                + "DA.ACPODRDEPOSITALWCRF DA_ACPODRDEPOSITALWCRF , DA.VARCOSTDEPOALWCRF    DA_VARCOSTDEPOALWCRF "
        //
        //                + "FROM DEPOSITALWRF DA "
        //                + "LEFT JOIN DEPSITMAINRF DM   ON  DA.ENTERPRISECODERF  = DM.ENTERPRISECODERF " 
        //                + "AND                             DA.CUSTOMERCODERF    = DM.CUSTOMERCODERF "  
        //                + "AND                             DA.ADDUPSECCODERF    = DM.ADDUPSECCODERF "  
        //                + "AND                             DA.DEPOSITSLIPNORF   = DM.DEPOSITSLIPNORF "  
        //                ,sqlConnection);
        //        
        //            //WHERE文の作成
        //            sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
        //
        //            //入金/引当ﾏｽﾀ Read
        //            sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //            int retCnt = 0;
        //
        //            while(sqlDataReader.Read())
        //            {
        //                //戻り値カウンタカウント
        //                retCnt += 1;
        //                if (readCnt > 0)
        //                {
        //                    //戻り値の件数が取得指示件数を超えた場合終了
        //                    if (readCnt < retCnt) 
        //                    {
        //                        nextData = true;
        //                        break;
        //                    }
        //                }
        //
        //                //入金マスタ
        //                #region 値セット
        //                DepsitDataWork wkDepsitMainWork = new DepsitDataWork();
        //
        //                wkDepsitMainWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
        //                wkDepsitMainWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
        //                wkDepsitMainWork.EnterpriseCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
        //                wkDepsitMainWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
        //                wkDepsitMainWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
        //                wkDepsitMainWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
        //                wkDepsitMainWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
        //                wkDepsitMainWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
        //
        //                wkDepsitMainWork.DepositDebitNoteCd   = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
        //                wkDepsitMainWork.DepositSlipNo        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
        //                wkDepsitMainWork.DepositKindCode      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
        //                wkDepsitMainWork.CustomerCode         = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
        //                wkDepsitMainWork.DepositCd            = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
        //                wkDepsitMainWork.DepositTotal         = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
        //                wkDepsitMainWork.Outline              = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
        //                wkDepsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERSALESNORF"));
        //                wkDepsitMainWork.InputDepositSecCd    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
        //                wkDepsitMainWork.DepositDate          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
        //                wkDepsitMainWork.AddUpSecCode         = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
        //                wkDepsitMainWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
        //                wkDepsitMainWork.UpdateSecCd          = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
        //                wkDepsitMainWork.DepositKindName      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
        //                wkDepsitMainWork.DepositAllowance     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
        //                wkDepsitMainWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
        //                wkDepsitMainWork.DepositAgentCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
        //                wkDepsitMainWork.DepositKindDivCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
        //                wkDepsitMainWork.FeeDeposit           = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
        //                wkDepsitMainWork.DiscountDeposit      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
        //                wkDepsitMainWork.CreditOrLoanCd       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
        //                wkDepsitMainWork.CreditCompanyCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
        //                wkDepsitMainWork.Deposit              = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
        //                wkDepsitMainWork.DraftDrawingDate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
        //                wkDepsitMainWork.DraftPayTimeLimit    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
        //                wkDepsitMainWork.DebitNoteLinkDepoNo  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
        //                wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
        //                wkDepsitMainWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
        //
        //                wkDepsitMainWork.AcpOdrDeposit        = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITRF"));
        //                wkDepsitMainWork.AcpOdrChargeDeposit  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRCHARGEDEPOSITRF"));
        //                wkDepsitMainWork.AcpOdrDisDeposit     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDISDEPOSITRF"));
        //                wkDepsitMainWork.VariousCostDeposit   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARIOUSCOSTDEPOSITRF"));
        //                wkDepsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTCHARGEDEPOSITRF"));
        //                wkDepsitMainWork.VarCostDisDeposit    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDISDEPOSITRF"));
        //                wkDepsitMainWork.AcpOdrDepositAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITALWCRF"));
        //                wkDepsitMainWork.AcpOdrDepoAlwcBlnce  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOALWCBLNCERF"));
        //                wkDepsitMainWork.VarCostDepoAlwc      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCRF"));
        //                wkDepsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCBLNCERF"));
        //
        //                int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
        //                int myIndex=alwk.IndexOf( myObjectOdd );
        //                if ( myIndex < 0 )
        //                {
        //                    alwk.Add(wkDepsitMainWork.DepositSlipNo);
        //       //             al.Add(wkDepsitMainWork);
        //                }
        //                #endregion
        //
        //
        //                //引当マスタ
        //                #region
        //                DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
        //
        //                wkDepositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
        //                wkDepositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
        //                wkDepositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
        //                wkDepositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
        //                wkDepositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
        //                wkDepositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
        //                wkDepositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
        //                wkDepositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
        //
        //                wkDepositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
        //                wkDepositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
        //                wkDepositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
        //                wkDepositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
        //                wkDepositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
        //                wkDepositAlwWork.DepositInputDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITINPUTDATERF"));
        //                wkDepositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
        //                wkDepositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
        //                wkDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
        //                wkDepositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
        //                wkDepositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
        //                wkDepositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
        //
        //                wkDepositAlwWork.AcpOdrDepositAlwc  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACPODRDEPOSITALWCRF"));
        //                wkDepositAlwWork.VarCostDepoAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_VARCOSTDEPOALWCRF"));
        //
        //                if (wkDepositAlwWork.AcceptAnOrderNo>0)
        //                {
        //       //             al2.Add(wkDepositAlwWork);
        //                }
        //                #endregion
        //
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //
        //
        //            //-------------------------------------------------------------------------------------------------------------//
        //            //-- 抽出したデータの「入金伝票番号」で再度検索 ------------------------------------------------------------------//
        //            //-------------------------------------------------------------------------------------------------------------//
        //            int wk_DepositSlipNo = 0;
        //            for(int ii = 1 ; ii <= alwk.Count ; ii++)
        //            {
        //                wk_DepositSlipNo = Convert.ToInt32( alwk[ii-1] );
        //
        //                searchParaDepositRead.DepositSlipNo   = wk_DepositSlipNo;  //入金伝票番号セット
        //                searchParaDepositRead.AcceptAnOrderNo = 0;                 //受注番号クリア
        //
        //                //SQL文生成
        //                sqlConnection = new SqlConnection(connectionText);
        //                sqlConnection.Open();				
        //
        //                sqlCommand = new SqlCommand("SELECT "
        //                    + "DM.CREATEDATETIMERF       DM_CREATEDATETIMERF       , DM.UPDATEDATETIMERF       DM_UPDATEDATETIMERF       , DM.ENTERPRISECODERF     DM_ENTERPRISECODERF ,"
        //                    + "DM.FILEHEADERGUIDRF       DM_FILEHEADERGUIDRF       , DM.UPDEMPLOYEECODERF      DM_UPDEMPLOYEECODERF      , DM.UPDASSEMBLYID1RF     DM_UPDASSEMBLYID1RF ,"
        //                    + "DM.UPDASSEMBLYID2RF       DM_UPDASSEMBLYID2RF       , DM.LOGICALDELETECODERF    DM_LOGICALDELETECODERF    , DM.DEPOSITDEBITNOTECDRF DM_DEPOSITDEBITNOTECDRF ,"
        //                    + "DM.DEPOSITSLIPNORF        DM_DEPOSITSLIPNORF        , DM.DEPOSITKINDCODERF      DM_DEPOSITKINDCODERF      , DM.CUSTOMERCODERF       DM_CUSTOMERCODERF ,"
        //                    + "DM.DEPOSITCDRF            DM_DEPOSITCDRF            , DM.DEPOSITTOTALRF         DM_DEPOSITTOTALRF         , DM.OUTLINERF            DM_OUTLINERF,"
        //                    + "DM.ACCEPTANORDERSALESNORF DM_ACCEPTANORDERSALESNORF , DM.INPUTDEPOSITSECCDRF    DM_INPUTDEPOSITSECCDRF    , DM.DEPOSITDATERF        DM_DEPOSITDATERF ,"
        //                    + "DM.ADDUPSECCODERF         DM_ADDUPSECCODERF         , DM.ADDUPADATERF           DM_ADDUPADATERF           , DM.UPDATESECCDRF        DM_UPDATESECCDRF ,"
        //                    + "DM.DEPOSITKINDNAMERF      DM_DEPOSITKINDNAMERF      , DM.DEPOSITALLOWANCERF     DM_DEPOSITALLOWANCERF     , DM.DEPOSITALWCBLNCERF   DM_DEPOSITALWCBLNCERF ,"
        //                    + "DM.DEPOSITAGENTCODERF     DM_DEPOSITAGENTCODERF     , DM.DEPOSITKINDDIVCDRF     DM_DEPOSITKINDDIVCDRF     , DM.FEEDEPOSITRF         DM_FEEDEPOSITRF ,"
        //                    + "DM.DISCOUNTDEPOSITRF      DM_DISCOUNTDEPOSITRF      , DM.CREDITORLOANCDRF       DM_CREDITORLOANCDRF       , DM.CREDITCOMPANYCODERF  DM_CREDITCOMPANYCODERF ,"
        //                    + "DM.DEPOSITRF              DM_DEPOSITRF              , DM.DRAFTDRAWINGDATERF     DM_DRAFTDRAWINGDATERF     , DM.DRAFTPAYTIMELIMITRF  DM_DRAFTPAYTIMELIMITRF ,"
        //                    + "DM.DEBITNOTELINKDEPONORF  DM_DEBITNOTELINKDEPONORF  , DM.LASTRECONCILEADDUPDTRF DM_LASTRECONCILEADDUPDTRF , DM.AUTODEPOSITCDRF      DM_AUTODEPOSITCDRF ,"
        //                    + "DM.ACPODRDEPOSITRF        DM_ACPODRDEPOSITRF        , DM.ACPODRCHARGEDEPOSITRF  DM_ACPODRCHARGEDEPOSITRF  , DM.ACPODRDISDEPOSITRF   DM_ACPODRDISDEPOSITRF ,"
        //                    + "DM.VARIOUSCOSTDEPOSITRF   DM_VARIOUSCOSTDEPOSITRF   , DM.VARCOSTCHARGEDEPOSITRF DM_VARCOSTCHARGEDEPOSITRF , DM.VARCOSTDISDEPOSITRF  DM_VARCOSTDISDEPOSITRF ,"
        //                    + "DM.ACPODRDEPOSITALWCRF    DM_ACPODRDEPOSITALWCRF    , DM.ACPODRDEPOALWCBLNCERF  DM_ACPODRDEPOALWCBLNCERF  , DM.VARCOSTDEPOALWCRF    DM_VARCOSTDEPOALWCRF ,"
        //                    + "DM.VARCOSTDEPOALWCBLNCERF DM_VARCOSTDEPOALWCBLNCERF ," 
        //
        //                    + "DA.CREATEDATETIMERF    DA_CREATEDATETIMERF    , DA.UPDATEDATETIMERF     DA_UPDATEDATETIMERF ,    DA.ENTERPRISECODERF    DA_ENTERPRISECODERF ,"
        //                    + "DA.FILEHEADERGUIDRF    DA_FILEHEADERGUIDRF    , DA.UPDEMPLOYEECODERF    DA_UPDEMPLOYEECODERF ,   DA.UPDASSEMBLYID1RF    DA_UPDASSEMBLYID1RF ,"
        //                    + "DA.UPDASSEMBLYID2RF    DA_UPDASSEMBLYID2RF    , DA.LOGICALDELETECODERF  DA_LOGICALDELETECODERF , DA.CUSTOMERCODERF      DA_CUSTOMERCODERF ,"
        //                    + "DA.ADDUPSECCODERF      DA_ADDUPSECCODERF      , DA.ACCEPTANORDERNORF    DA_ACCEPTANORDERNORF ,   DA.DEPOSITSLIPNORF     DA_DEPOSITSLIPNORF ,"
        //                    + "DA.DEPOSITKINDCODERF   DA_DEPOSITKINDCODERF   , DA.DEPOSITINPUTDATERF   DA_DEPOSITINPUTDATERF ,  DA.DEPOSITALLOWANCERF  DA_DEPOSITALLOWANCERF ,"
        //                    + "DA.RECONCILEDATERF     DA_RECONCILEDATERF     , DA.RECONCILEADDUPDATERF DA_RECONCILEADDUPDATERF ,DA.DEBITNOTEOFFSETCDRF DA_DEBITNOTEOFFSETCDRF ,"
        //                    + "DA.DEPOSITCDRF         DA_DEPOSITCDRF         , DA.CREDITORLOANCDRF     DA_CREDITORLOANCDRF ,"
        //                    + "DA.ACPODRDEPOSITALWCRF DA_ACPODRDEPOSITALWCRF , DA.VARCOSTDEPOALWCRF    DA_VARCOSTDEPOALWCRF "
        //
        //                    + " FROM DEPSITMAINRF DM "
        //                    + "LEFT JOIN DEPOSITALWRF DA   ON  DM.ENTERPRISECODERF  = DA.ENTERPRISECODERF " 
        //                    + "AND                             DM.CUSTOMERCODERF    = DA.CUSTOMERCODERF "  
        //                    + "AND                             DM.ADDUPSECCODERF    = DA.ADDUPSECCODERF "  
        //                    + "AND                             DM.DEPOSITSLIPNORF   = DA.DEPOSITSLIPNORF "  
        //                    ,sqlConnection);
        //        
        //                //WHERE文の作成
        //                sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
        //
        //                //入金/引当ﾏｽﾀ Read
        //                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //                while(sqlDataReader.Read())
        //                {
        //                    //入金マスタ
        //                    #region
        //                    DepsitDataWork wkDepsitMainWork = new DepsitDataWork();
        //
        //                    wkDepsitMainWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
        //                    wkDepsitMainWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
        //                    wkDepsitMainWork.EnterpriseCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
        //                    wkDepsitMainWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
        //                    wkDepsitMainWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
        //                    wkDepsitMainWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
        //                    wkDepsitMainWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
        //                    wkDepsitMainWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
        //
        //                    wkDepsitMainWork.DepositDebitNoteCd   = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
        //                    wkDepsitMainWork.DepositSlipNo        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
        //                    wkDepsitMainWork.DepositKindCode      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
        //                    wkDepsitMainWork.CustomerCode         = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
        //                    wkDepsitMainWork.DepositCd            = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
        //                    wkDepsitMainWork.DepositTotal         = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
        //                    wkDepsitMainWork.Outline              = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
        //                    wkDepsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERSALESNORF"));
        //                    wkDepsitMainWork.InputDepositSecCd    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
        //                    wkDepsitMainWork.DepositDate          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
        //                    wkDepsitMainWork.AddUpSecCode         = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
        //                    wkDepsitMainWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
        //                    wkDepsitMainWork.UpdateSecCd          = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
        //                    wkDepsitMainWork.DepositKindName      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
        //                    wkDepsitMainWork.DepositAllowance     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
        //                    wkDepsitMainWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
        //                    wkDepsitMainWork.DepositAgentCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
        //                    wkDepsitMainWork.DepositKindDivCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
        //                    wkDepsitMainWork.FeeDeposit           = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
        //                    wkDepsitMainWork.DiscountDeposit      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
        //                    wkDepsitMainWork.CreditOrLoanCd       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
        //                    wkDepsitMainWork.CreditCompanyCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
        //                    wkDepsitMainWork.Deposit              = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
        //                    wkDepsitMainWork.DraftDrawingDate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
        //                    wkDepsitMainWork.DraftPayTimeLimit    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
        //                    wkDepsitMainWork.DebitNoteLinkDepoNo  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
        //                    wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
        //                    wkDepsitMainWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
        //
        //                    wkDepsitMainWork.AcpOdrDeposit        = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITRF"));
        //                    wkDepsitMainWork.AcpOdrChargeDeposit  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRCHARGEDEPOSITRF"));
        //                    wkDepsitMainWork.AcpOdrDisDeposit     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDISDEPOSITRF"));
        //                    wkDepsitMainWork.VariousCostDeposit   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARIOUSCOSTDEPOSITRF"));
        //                    wkDepsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTCHARGEDEPOSITRF"));
        //                    wkDepsitMainWork.VarCostDisDeposit    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDISDEPOSITRF"));
        //                    wkDepsitMainWork.AcpOdrDepositAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITALWCRF"));
        //                    wkDepsitMainWork.AcpOdrDepoAlwcBlnce  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOALWCBLNCERF"));
        //                    wkDepsitMainWork.VarCostDepoAlwc      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCRF"));
        //                    wkDepsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCBLNCERF"));
        //
        //                    int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
        //                    int myIndex=alwk2.IndexOf( myObjectOdd );
        //                    if ( myIndex < 0 )
        //                    {
        //                        alwk2.Add(wkDepsitMainWork.DepositSlipNo);
        //                        al.Add(wkDepsitMainWork);
        //                    }
        //                    #endregion
        //
        //
        //                    //引当マスタ
        //                    #region
        //                    DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
        //
        //                    wkDepositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
        //                    wkDepositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
        //                    wkDepositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
        //                    wkDepositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
        //                    wkDepositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
        //                    wkDepositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
        //                    wkDepositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
        //                    wkDepositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
        //
        //                    wkDepositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
        //                    wkDepositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
        //                    wkDepositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
        //                    wkDepositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
        //                    wkDepositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
        //                    wkDepositAlwWork.DepositInputDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITINPUTDATERF"));
        //                    wkDepositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
        //                    wkDepositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
        //                    wkDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
        //                    wkDepositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
        //                    wkDepositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
        //                    wkDepositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
        //
        //                    wkDepositAlwWork.AcpOdrDepositAlwc  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACPODRDEPOSITALWCRF"));
        //                    wkDepositAlwWork.VarCostDepoAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_VARCOSTDEPOALWCRF"));
        //
        //                    if (wkDepositAlwWork.UpdAssemblyId1 != "")
        //                    {
        //                        al2.Add(wkDepositAlwWork);
        //                    }
        //                    #endregion
        //
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //                }
        //
        //            }
        //            //-------------------------------------------------------------------------------------------------------------//
        //            //-------------------------------------------------------------------------------------------------------------//
        //
        //        }
        //
        //    }
        //    catch (SqlException ex) 
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //
        //    if(!sqlDataReader.IsClosed)sqlDataReader.Close();
        //    sqlConnection.Close();
        //
        //
        //    // XMLへ変換し、文字列のバイナリ化
        //    DepsitDataWork[] DepsitDataWorks = (DepsitDataWork[])al.ToArray(typeof(DepsitDataWork));
        //    depsitDataWork = XmlByteSerializer.Serialize(DepsitDataWorks);
        //
        //    DepositAlwWork[] DepositAlwWorks = (DepositAlwWork[])al2.ToArray(typeof(DepositAlwWork));
        //    depositAlwWork = XmlByteSerializer.Serialize(DepositAlwWorks);
        //
        //
        //    }
        //    catch(Exception ex)
        //    {
        //        base.WriteErrorLog(ex,"DepositReadDB.SearchProc Exception="+ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //
        //    return status;
        //}
        #endregion
        #endregion

        #region カスタムシリアライズ

        /// <summary>
        /// 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="DepsitDataWork">検索結果</param>
        /// <param name="DepositAlwWork">検索結果</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.16</br>
        public int Search(out object DepsitDataWork, out object DepositAlwWork, object searchParaDepositRead, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bool nextData;
            int retTotalCnt;
            SearchParaDepositRead _searchParaDepositRead = searchParaDepositRead as SearchParaDepositRead;
            //return SearchProc(out DepsitDataWork , out DepositAlwWork , out retTotalCnt , out nextData , _searchParaDepositRead , readMode , logicalMode , 0);
            DepsitDataWork = null;
            DepositAlwWork = null;

            // ↓ 20070406 18322 a
            if (_searchParaDepositRead == null)
            {
                // パラメータエラー -> ダミーを作成して終了
                DepsitDataWork = new ArrayList();
                DepositAlwWork = new ArrayList();
                return status;
            }
            // ↑ 20070406 18322 a

            try
            {
                // ↓ 20070406 18322 c DBコネクションを渡すように変更
                //status =  SearchProc(out DepsitDataWork , out DepositAlwWork , out retTotalCnt , out nextData , _searchParaDepositRead , readMode , logicalMode , 0);
                
                SqlConnection sqlConnection = null;
                // -- 2007.07.05　SearchProcの引数にSqlTransaction追加
                SqlTransaction sqlTransaction = null;
                status = SearchProc(out DepsitDataWork
                                   ,out DepositAlwWork
                                   ,out retTotalCnt
                                   ,out nextData
                                   ,    _searchParaDepositRead
                                   ,    readMode
                                   ,    logicalMode
                                   , 0
                                   ,ref sqlConnection
                                   ,ref sqlTransaction);
                // ↑ 20070406 18322 c
            }
            catch(Exception ex)
            {
                //--- DEL 2008/06/27 M.Kubota --->>>
                //base.WriteErrorLog(ex,"DepositReadDB.Search Exception="+ex.Message);
                //status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //--- DEL 2008/06/27 M.Kubota ---<<<
                
                //--- ADD 2008/06/27 M.Kibota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //--- ADD 2008/06/27 M.Kubota
            }

            return status;
        }

        # region --- DEL 2008/06/27 M.Kubota ---
        // 削除理由は SFUKK01454O を参照
# if false
        /// <summary>
        /// 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="DepsitDataWork">検索結果</param>
        /// <param name="DepositAlwWork">検索結果</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">DBコネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金/引当READLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.04.06</br>
        public int Search(out object DepsitDataWork,
                          out object DepositAlwWork,
                              object searchParaDepositRead,
                              int    readMode,
                              ConstantManagement.LogicalMode logicalMode,
                          ref SqlConnection sqlConnection)
        {		
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            bool nextData;
            int retTotalCnt;
            
            DepsitDataWork = null;
            DepositAlwWork = null;

            // パラメータを変換
            SearchParaDepositRead _searchParaDepositRead = searchParaDepositRead as SearchParaDepositRead;
            if (_searchParaDepositRead == null)
            {
                DepsitDataWork = new ArrayList();
                DepositAlwWork = new ArrayList();
                return status;
            }

            if (sqlConnection == null)
            {
                DepsitDataWork = new ArrayList();
                DepositAlwWork = new ArrayList();
                return status;
            }

            try
            {
                // -- 2007.07.05　SearchProcの引数にSqlTransaction追加
                //SqlTransaction sqlTransaction = null;  //DEL 2008/06/27
                status = SearchProc(out DepsitDataWork
                                   ,out DepositAlwWork
                                   ,out retTotalCnt
                                   ,out nextData
                                   ,    _searchParaDepositRead
                                   ,    readMode
                                   ,    logicalMode
                                   , 0
                                   ,ref sqlConnection
                                   ,ref sqlTransaction);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"DepositReadDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
# endif
        # endregion

        /// <summary>
        /// 指定された条件で入金マスタ・入金引当マスタを検索して戻します
        /// </summary>
        /// <param name="DepsitDataWork">入金マスタ</param>
        /// <param name="DepositAlwWork">入金引当マスタ</param>
        /// <param name="searchParaDepositRead">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件で入金マスタ・入金引当マスタを検索して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.07.05</br>
        public int Search(out object DepsitDataWork, out object DepositAlwWork, object searchParaDepositRead, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int retTotalCnt;
            bool nextData;
            return SearchProc(out DepsitDataWork, out DepositAlwWork, out retTotalCnt, out nextData, (SearchParaDepositRead)searchParaDepositRead, readMode, logicalMode, 0, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの入金/引当READLISTを全て戻します
        /// </summary>
        /// <param name="depsitDataWork">検索結果</param>
        /// <param name="depositAlwWork">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <param name="sqlConnection">DBコネクション</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金/引当READLISTを全て戻します</br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.16</br>
        /// <br></br>
        /// <br>UpdateNote : 2007.07.05　19026　湯山　美樹　SqlTransaction をパラメータに追加</br>
        // ↓ 20070406 18322 c パラメータを追加
        //private int SearchProc(out object depsitDataWork , out object depositAlwWork , out int retTotalCnt , out bool nextData , SearchParaDepositRead searchParaDepositRead , int readMode , ConstantManagement.LogicalMode logicalMode , int readCnt)
        
        private int SearchProc(out object depsitDataWork
                              ,out object depositAlwWork
                              ,out int    retTotalCnt
                              ,out bool   nextData
                              ,    SearchParaDepositRead searchParaDepositRead
                              ,    int    readMode
                              ,    ConstantManagement.LogicalMode logicalMode
                              ,    int    readCnt
                              //,ref SqlConnection sqlConnect   //DEL 2008/06/27 M.Kubota
                              ,ref SqlConnection sqlConnection  //ADD 2008/06/27 M.Kubota
                              ,ref SqlTransaction sqlTransaction)
        // ↑ 20070406 18322 c
        {
            SearchParaDepositRead SPTA = (SearchParaDepositRead)searchParaDepositRead;
            string enterpriseCode           = SPTA.EnterpriseCode;
            string addUpSecCode             = SPTA.AddUpSecCode;
            int customerCode                = SPTA.CustomerCode;
            int depositSlipNo               = SPTA.DepositSlipNo;
            // ↓ 2007.10.11 980081 c
            //int acceptAnOrderNo             = SPTA.AcceptAnOrderNo;
            Int32 acptAnOdrStatus           = SPTA.AcptAnOdrStatus;
            string salesSlipNum             = SPTA.SalesSlipNum; 
            // ↑ 2007.10.11 980081 c

            // ↓ 20070124 18322 d MA.NS用に変更
            //DateTime depositCallMonthsStart = SPTA.DepositCallMonthsStart;
            //DateTime depositCallMonthsEnd   = SPTA.DepositCallMonthsEnd;
            // ↑ 20070124 18322 d

            int alwcDepositCall             = SPTA.AlwcDepositCall;

            depsitDataWork = null;
            depositAlwWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //SqlConnection sqlConnection = null;  //DEL 2008/06/27 M.Kubota パラメータと統合
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //--- DEL 2008/06/27 M.Kubota --->>> 使って無い…
            //DepsitMainWork depsitmainWork = new DepsitMainWork();
            //DepositAlwWork depositalwWork = new DepositAlwWork();
            //depsitmainWork = null;
            //depositalwWork = null;
            //--- DEL 2008/06/27 M.Kubota ---<<<

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
                // ↓ 20070124 18322 c MA.NS用に変更
                //sDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsStart);
                //eDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsEnd);

                sDate = SPTA.DepositCallMonthsStart;
                eDate = SPTA.DepositCallMonthsEnd;
                // ↑ 20070124 18322 c

            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }

            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();

            ArrayList alwk   = new ArrayList();   //重複データ検索用
            ArrayList alwk2  = new ArrayList();   //重複データ検索用２

            try
            {
                try
                {
                    # region ---- DEL 2008/06/27 M.Kubota ---
                    //// ↓ 20070406 18322 a DBコネクションの取得方法を変更
                    //if (sqlConnect == null)
                    //{
                    //    //コネクション文字列取得対応↓↓↓↓↓
                    //    //※各publicメソッドの開始時にコネクション文字列を取得
                    //    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    //    if (connectionText == null || connectionText == "") return status;

                    //    //SQL文生成
                    //    sqlConnection = new SqlConnection(connectionText);
                    //    sqlConnection.Open();
                    //}
                    //else
                    //{
                    //    sqlConnection = sqlConnect;
                    //}
                    //// ↑ 20070406 18322 a

                    //// ↓ 20070406 18322 d DBコネクションの取得方法を変更
                    //////コネクション文字列取得対応↓↓↓↓↓
                    //////※各publicメソッドの開始時にコネクション文字列を取得
                    //////メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    ////SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    ////string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    ////if (connectionText == null || connectionText == "") return status;
                    //////コネクション文字列取得対応↑↑↑↑↑
                    //// ↑ 20070406 18322 d
                    # endregion

                    //--- ADD 2008/06/27 M.Kubota --->>>
                    if (sqlConnection == null)
                    {
                        sqlConnection = this.CreateSqlConnection(true);

                        if (sqlConnection == null)
                        {
                            return status;
                        }
                    }

                    if ((sqlConnection.State & ConnectionState.Open) == 0)
                    {
                        sqlConnection.Open();
                    }
                    //--- ADD 2008/06/27 M.Kubota ---<<<

                    // ↓ 2007.10.11 980081 c
                    //if (acceptAnOrderNo == 0)   //受注番号が入っていなければ、入金マスタを軸にデータ抽出。入っていれば、引当マスタを軸にデータ抽出
                    if (acptAnOdrStatus == 0 || salesSlipNum == "")   //受注ステータスまたは売上伝票番号が入っていなければ、入金マスタを軸にデータ抽出。入っていれば、引当マスタを軸にデータ抽出
                    // ↑ 2007.10.11 980081 c
                    {
                        //--- 受注番号が入っていない場合 ----------//
                        // ↓ 20070406 18322 d DBコネクションの取得方法を変更
                        ////SQL文生成
                        //sqlConnection = new SqlConnection(connectionText);
                        //sqlConnection.Open();
                        // ↑ 20070406 18322 d

                        // ↓ 20070124 18322 c MA.NS用に変更
                        #region SF 入金マスタ＋入金引当マスタ検索（コメントアウト）
                        //sqlCommand = new SqlCommand("SELECT "
                        //    + "DM.CREATEDATETIMERF       DM_CREATEDATETIMERF       , DM.UPDATEDATETIMERF       DM_UPDATEDATETIMERF       , DM.ENTERPRISECODERF     DM_ENTERPRISECODERF ,"
                        //    + "DM.FILEHEADERGUIDRF       DM_FILEHEADERGUIDRF       , DM.UPDEMPLOYEECODERF      DM_UPDEMPLOYEECODERF      , DM.UPDASSEMBLYID1RF     DM_UPDASSEMBLYID1RF ,"
                        //    + "DM.UPDASSEMBLYID2RF       DM_UPDASSEMBLYID2RF       , DM.LOGICALDELETECODERF    DM_LOGICALDELETECODERF    , DM.DEPOSITDEBITNOTECDRF DM_DEPOSITDEBITNOTECDRF ,"
                        //    + "DM.DEPOSITSLIPNORF        DM_DEPOSITSLIPNORF        , DM.DEPOSITKINDCODERF      DM_DEPOSITKINDCODERF      , DM.CUSTOMERCODERF       DM_CUSTOMERCODERF ,"
                        //    + "DM.DEPOSITCDRF            DM_DEPOSITCDRF            , DM.DEPOSITTOTALRF         DM_DEPOSITTOTALRF         , DM.OUTLINERF            DM_OUTLINERF,"
                        //    + "DM.ACCEPTANORDERSALESNORF DM_ACCEPTANORDERSALESNORF , DM.INPUTDEPOSITSECCDRF    DM_INPUTDEPOSITSECCDRF    , DM.DEPOSITDATERF        DM_DEPOSITDATERF ,"
                        //    + "DM.ADDUPSECCODERF         DM_ADDUPSECCODERF         , DM.ADDUPADATERF           DM_ADDUPADATERF           , DM.UPDATESECCDRF        DM_UPDATESECCDRF ,"
                        //    + "DM.DEPOSITKINDNAMERF      DM_DEPOSITKINDNAMERF      , DM.DEPOSITALLOWANCERF     DM_DEPOSITALLOWANCERF     , DM.DEPOSITALWCBLNCERF   DM_DEPOSITALWCBLNCERF ,"
                        //    + "DM.DEPOSITAGENTCODERF     DM_DEPOSITAGENTCODERF     , DM.DEPOSITKINDDIVCDRF     DM_DEPOSITKINDDIVCDRF     , DM.FEEDEPOSITRF         DM_FEEDEPOSITRF ,"
                        //    + "DM.DISCOUNTDEPOSITRF      DM_DISCOUNTDEPOSITRF      , DM.CREDITORLOANCDRF       DM_CREDITORLOANCDRF       , DM.CREDITCOMPANYCODERF  DM_CREDITCOMPANYCODERF ,"
                        //    + "DM.DEPOSITRF              DM_DEPOSITRF              , DM.DRAFTDRAWINGDATERF     DM_DRAFTDRAWINGDATERF     , DM.DRAFTPAYTIMELIMITRF  DM_DRAFTPAYTIMELIMITRF ,"
                        //    + "DM.DEBITNOTELINKDEPONORF  DM_DEBITNOTELINKDEPONORF  , DM.LASTRECONCILEADDUPDTRF DM_LASTRECONCILEADDUPDTRF , DM.AUTODEPOSITCDRF      DM_AUTODEPOSITCDRF ,"
                        //    + "DM.ACPODRDEPOSITRF        DM_ACPODRDEPOSITRF        , DM.ACPODRCHARGEDEPOSITRF  DM_ACPODRCHARGEDEPOSITRF  , DM.ACPODRDISDEPOSITRF   DM_ACPODRDISDEPOSITRF ,"
                        //    + "DM.VARIOUSCOSTDEPOSITRF   DM_VARIOUSCOSTDEPOSITRF   , DM.VARCOSTCHARGEDEPOSITRF DM_VARCOSTCHARGEDEPOSITRF , DM.VARCOSTDISDEPOSITRF  DM_VARCOSTDISDEPOSITRF ,"
                        //    + "DM.ACPODRDEPOSITALWCRF    DM_ACPODRDEPOSITALWCRF    , DM.ACPODRDEPOALWCBLNCERF  DM_ACPODRDEPOALWCBLNCERF  , DM.VARCOSTDEPOALWCRF    DM_VARCOSTDEPOALWCRF ,"
                        //    + "DM.VARCOSTDEPOALWCBLNCERF DM_VARCOSTDEPOALWCBLNCERF ," 
                        //
                        //    + "DA.CREATEDATETIMERF    DA_CREATEDATETIMERF    , DA.UPDATEDATETIMERF     DA_UPDATEDATETIMERF ,    DA.ENTERPRISECODERF    DA_ENTERPRISECODERF ,"
                        //    + "DA.FILEHEADERGUIDRF    DA_FILEHEADERGUIDRF    , DA.UPDEMPLOYEECODERF    DA_UPDEMPLOYEECODERF ,   DA.UPDASSEMBLYID1RF    DA_UPDASSEMBLYID1RF ,"
                        //    + "DA.UPDASSEMBLYID2RF    DA_UPDASSEMBLYID2RF    , DA.LOGICALDELETECODERF  DA_LOGICALDELETECODERF , DA.CUSTOMERCODERF      DA_CUSTOMERCODERF ,"
                        //    + "DA.ADDUPSECCODERF      DA_ADDUPSECCODERF      , DA.ACCEPTANORDERNORF    DA_ACCEPTANORDERNORF ,   DA.DEPOSITSLIPNORF     DA_DEPOSITSLIPNORF ,"
                        //    + "DA.DEPOSITKINDCODERF   DA_DEPOSITKINDCODERF   , DA.DEPOSITINPUTDATERF   DA_DEPOSITINPUTDATERF ,  DA.DEPOSITALLOWANCERF  DA_DEPOSITALLOWANCERF ,"
                        //    + "DA.RECONCILEDATERF     DA_RECONCILEDATERF     , DA.RECONCILEADDUPDATERF DA_RECONCILEADDUPDATERF ,DA.DEBITNOTEOFFSETCDRF DA_DEBITNOTEOFFSETCDRF ,"
                        //    + "DA.DEPOSITCDRF         DA_DEPOSITCDRF         , DA.CREDITORLOANCDRF     DA_CREDITORLOANCDRF ,"
                        //    + "DA.ACPODRDEPOSITALWCRF DA_ACPODRDEPOSITALWCRF , DA.VARCOSTDEPOALWCRF    DA_VARCOSTDEPOALWCRF "
                        //
                        //    + " FROM DEPSITMAINRF DM "
                        //    + "LEFT JOIN DEPOSITALWRF DA   ON  DM.ENTERPRISECODERF  = DA.ENTERPRISECODERF " 
                        //    + "AND                             DM.CUSTOMERCODERF    = DA.CUSTOMERCODERF "  
                        //    + "AND                             DM.ADDUPSECCODERF    = DA.ADDUPSECCODERF "  
                        //    + "AND                             DM.DEPOSITSLIPNORF   = DA.DEPOSITSLIPNORF "  
                        //    ,sqlConnection);
                        #endregion

                        // -- 2007.07.05　SqlTransactionのnull判定追加
                        if (sqlTransaction == null)
                            sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection);
                        else
                            sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection, sqlTransaction);
                        // ↑ 20070124 18322 c

                        //WHERE文の作成
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaDepositRead, logicalMode);

#if DEBUG
                        //--- ADD 2008/06/27 M.Kubota --->>>
                        Console.Clear();
                        Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
                        //--- ADD 2008/06/27 M.Kubota ---<<<
# endif

                        //入金/引当ﾏｽﾀ Read
                        // ↓ 20070406 18322 c
                        //sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.Default);
                        // ↑ 20070406 18322 c

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
                                    nextData = true;
                                    break;
                                }
                            }

                            //入金マスタ
                            #region 値セット
                            // ↓ 20070124 18322 c MA.NS用に変更
                            #region SF 検索データを入金マスタワークへコピー（全てコメントアウト）
                            //DepsitDataWork wkDepsitMainWork = new DepsitDataWork();
                            //
                            //wkDepsitMainWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
                            //wkDepsitMainWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
                            //wkDepsitMainWork.EnterpriseCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
                            //wkDepsitMainWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
                            //wkDepsitMainWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
                            //wkDepsitMainWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
                            //wkDepsitMainWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
                            //wkDepsitMainWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
                            //
                            //wkDepsitMainWork.DepositDebitNoteCd   = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
                            //wkDepsitMainWork.DepositSlipNo        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
                            //wkDepsitMainWork.DepositKindCode      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
                            //wkDepsitMainWork.CustomerCode         = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
                            //wkDepsitMainWork.DepositCd            = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
                            //wkDepsitMainWork.DepositTotal         = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
                            //wkDepsitMainWork.Outline              = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
                            //wkDepsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERSALESNORF"));
                            //wkDepsitMainWork.InputDepositSecCd    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
                            //wkDepsitMainWork.DepositDate          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
                            //wkDepsitMainWork.AddUpSecCode         = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
                            //wkDepsitMainWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
                            //wkDepsitMainWork.UpdateSecCd          = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
                            //wkDepsitMainWork.DepositKindName      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
                            //wkDepsitMainWork.DepositAllowance     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
                            //wkDepsitMainWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
                            //wkDepsitMainWork.DepositAgentCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
                            //wkDepsitMainWork.DepositKindDivCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
                            //wkDepsitMainWork.FeeDeposit           = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
                            //wkDepsitMainWork.DiscountDeposit      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
                            //wkDepsitMainWork.CreditOrLoanCd       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
                            //wkDepsitMainWork.CreditCompanyCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
                            //wkDepsitMainWork.Deposit              = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
                            //wkDepsitMainWork.DraftDrawingDate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
                            //wkDepsitMainWork.DraftPayTimeLimit    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
                            //wkDepsitMainWork.DebitNoteLinkDepoNo  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
                            //wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
                            //wkDepsitMainWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
                            //
                            //wkDepsitMainWork.AcpOdrDeposit        = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITRF"));
                            //wkDepsitMainWork.AcpOdrChargeDeposit  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRCHARGEDEPOSITRF"));
                            //wkDepsitMainWork.AcpOdrDisDeposit     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDISDEPOSITRF"));
                            //wkDepsitMainWork.VariousCostDeposit   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARIOUSCOSTDEPOSITRF"));
                            //wkDepsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTCHARGEDEPOSITRF"));
                            //wkDepsitMainWork.VarCostDisDeposit    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDISDEPOSITRF"));
                            //wkDepsitMainWork.AcpOdrDepositAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITALWCRF"));
                            //wkDepsitMainWork.AcpOdrDepoAlwcBlnce  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOALWCBLNCERF"));
                            //wkDepsitMainWork.VarCostDepoAlwc      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCRF"));
                            //wkDepsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCBLNCERF"));
                            #endregion

                            // 検索データを入金マスタワークへコピー
                            DepsitMainWork wkDepsitMainWork = new DepsitMainWork();
                            CopyToDepsitMainWorkFromSelectData(ref wkDepsitMainWork, myReader);
                            // ↑ 20070124 18322 c

                            int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                            int myIndex = alwk.IndexOf(myObjectOdd);
                            if (myIndex < 0)
                            {
                                alwk.Add(wkDepsitMainWork.DepositSlipNo);
                                al.Add(wkDepsitMainWork);
                            }
                            #endregion


                            //引当マスタ
                            #region
                            // ↓ 20070124 18322 c MA.NS用に変更
                            #region SF 検索データを入金引当マスタワークへコピー（全てコメントアウト）
                            //DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                            //
                            //wkDepositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
                            //wkDepositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
                            //wkDepositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
                            //wkDepositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
                            //wkDepositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
                            //wkDepositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
                            //wkDepositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
                            //wkDepositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
                            //
                            //wkDepositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
                            //wkDepositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
                            //wkDepositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
                            //wkDepositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
                            //wkDepositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
                            //wkDepositAlwWork.DepositInputDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITINPUTDATERF"));
                            //wkDepositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
                            //wkDepositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
                            //wkDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
                            //wkDepositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
                            //wkDepositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
                            //wkDepositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
                            //
                            //wkDepositAlwWork.AcpOdrDepositAlwc  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACPODRDEPOSITALWCRF"));
                            //wkDepositAlwWork.VarCostDepoAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_VARCOSTDEPOALWCRF"));
                            #endregion

                            // 検索データを入金引当マスタワークへコピー
                            DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                            CopyToDepsitAlwWorkFromSelectData(ref wkDepositAlwWork, myReader);
                            // ↑ 20070124 18322 c

                            if (wkDepositAlwWork.UpdAssemblyId1 != "")
                            {
                                al2.Add(wkDepositAlwWork);
                            }
                            #endregion

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    else
                    {
                        //--- 受注ステータスと売上伝票番号が入っている場合 ----------//
                        // ↓ 20070406 18322 d DBコネクションの取得方法を変更
                        ////SQL文生成
                        //sqlConnection = new SqlConnection(connectionText);
                        //sqlConnection.Open();
                        // ↑ 20070406 18322 d

                        // ↓ 20070124 18322 c MA.NS用に変更
                        #region SF 入金引当マスタ＋入金マスタ検索（コメントアウト）
                        //sqlCommand = new SqlCommand("SELECT "
                        //    + "DM.CREATEDATETIMERF       DM_CREATEDATETIMERF       , DM.UPDATEDATETIMERF       DM_UPDATEDATETIMERF       , DM.ENTERPRISECODERF     DM_ENTERPRISECODERF ,"
                        //    + "DM.FILEHEADERGUIDRF       DM_FILEHEADERGUIDRF       , DM.UPDEMPLOYEECODERF      DM_UPDEMPLOYEECODERF      , DM.UPDASSEMBLYID1RF     DM_UPDASSEMBLYID1RF ,"
                        //    + "DM.UPDASSEMBLYID2RF       DM_UPDASSEMBLYID2RF       , DM.LOGICALDELETECODERF    DM_LOGICALDELETECODERF    , DM.DEPOSITDEBITNOTECDRF DM_DEPOSITDEBITNOTECDRF ,"
                        //    + "DM.DEPOSITSLIPNORF        DM_DEPOSITSLIPNORF        , DM.DEPOSITKINDCODERF      DM_DEPOSITKINDCODERF      , DM.CUSTOMERCODERF       DM_CUSTOMERCODERF ,"
                        //    + "DM.DEPOSITCDRF            DM_DEPOSITCDRF            , DM.DEPOSITTOTALRF         DM_DEPOSITTOTALRF         , DM.OUTLINERF            DM_OUTLINERF,"
                        //    + "DM.ACCEPTANORDERSALESNORF DM_ACCEPTANORDERSALESNORF , DM.INPUTDEPOSITSECCDRF    DM_INPUTDEPOSITSECCDRF    , DM.DEPOSITDATERF        DM_DEPOSITDATERF ,"
                        //    + "DM.ADDUPSECCODERF         DM_ADDUPSECCODERF         , DM.ADDUPADATERF           DM_ADDUPADATERF           , DM.UPDATESECCDRF        DM_UPDATESECCDRF ,"
                        //    + "DM.DEPOSITKINDNAMERF      DM_DEPOSITKINDNAMERF      , DM.DEPOSITALLOWANCERF     DM_DEPOSITALLOWANCERF     , DM.DEPOSITALWCBLNCERF   DM_DEPOSITALWCBLNCERF ,"
                        //    + "DM.DEPOSITAGENTCODERF     DM_DEPOSITAGENTCODERF     , DM.DEPOSITKINDDIVCDRF     DM_DEPOSITKINDDIVCDRF     , DM.FEEDEPOSITRF         DM_FEEDEPOSITRF ,"
                        //    + "DM.DISCOUNTDEPOSITRF      DM_DISCOUNTDEPOSITRF      , DM.CREDITORLOANCDRF       DM_CREDITORLOANCDRF       , DM.CREDITCOMPANYCODERF  DM_CREDITCOMPANYCODERF ,"
                        //    + "DM.DEPOSITRF              DM_DEPOSITRF              , DM.DRAFTDRAWINGDATERF     DM_DRAFTDRAWINGDATERF     , DM.DRAFTPAYTIMELIMITRF  DM_DRAFTPAYTIMELIMITRF ,"
                        //    + "DM.DEBITNOTELINKDEPONORF  DM_DEBITNOTELINKDEPONORF  , DM.LASTRECONCILEADDUPDTRF DM_LASTRECONCILEADDUPDTRF , DM.AUTODEPOSITCDRF      DM_AUTODEPOSITCDRF ,"
                        //    + "DM.ACPODRDEPOSITRF        DM_ACPODRDEPOSITRF        , DM.ACPODRCHARGEDEPOSITRF  DM_ACPODRCHARGEDEPOSITRF  , DM.ACPODRDISDEPOSITRF   DM_ACPODRDISDEPOSITRF ,"
                        //    + "DM.VARIOUSCOSTDEPOSITRF   DM_VARIOUSCOSTDEPOSITRF   , DM.VARCOSTCHARGEDEPOSITRF DM_VARCOSTCHARGEDEPOSITRF , DM.VARCOSTDISDEPOSITRF  DM_VARCOSTDISDEPOSITRF ,"
                        //    + "DM.ACPODRDEPOSITALWCRF    DM_ACPODRDEPOSITALWCRF    , DM.ACPODRDEPOALWCBLNCERF  DM_ACPODRDEPOALWCBLNCERF  , DM.VARCOSTDEPOALWCRF    DM_VARCOSTDEPOALWCRF ,"
                        //    + "DM.VARCOSTDEPOALWCBLNCERF DM_VARCOSTDEPOALWCBLNCERF ," 
                        //
                        //    + "DA.CREATEDATETIMERF    DA_CREATEDATETIMERF    , DA.UPDATEDATETIMERF     DA_UPDATEDATETIMERF ,    DA.ENTERPRISECODERF    DA_ENTERPRISECODERF ,"
                        //    + "DA.FILEHEADERGUIDRF    DA_FILEHEADERGUIDRF    , DA.UPDEMPLOYEECODERF    DA_UPDEMPLOYEECODERF ,   DA.UPDASSEMBLYID1RF    DA_UPDASSEMBLYID1RF ,"
                        //    + "DA.UPDASSEMBLYID2RF    DA_UPDASSEMBLYID2RF    , DA.LOGICALDELETECODERF  DA_LOGICALDELETECODERF , DA.CUSTOMERCODERF      DA_CUSTOMERCODERF ,"
                        //    + "DA.ADDUPSECCODERF      DA_ADDUPSECCODERF      , DA.ACCEPTANORDERNORF    DA_ACCEPTANORDERNORF ,   DA.DEPOSITSLIPNORF     DA_DEPOSITSLIPNORF ,"
                        //    + "DA.DEPOSITKINDCODERF   DA_DEPOSITKINDCODERF   , DA.DEPOSITINPUTDATERF   DA_DEPOSITINPUTDATERF ,  DA.DEPOSITALLOWANCERF  DA_DEPOSITALLOWANCERF ,"
                        //    + "DA.RECONCILEDATERF     DA_RECONCILEDATERF     , DA.RECONCILEADDUPDATERF DA_RECONCILEADDUPDATERF ,DA.DEBITNOTEOFFSETCDRF DA_DEBITNOTEOFFSETCDRF ,"
                        //    + "DA.DEPOSITCDRF         DA_DEPOSITCDRF         , DA.CREDITORLOANCDRF     DA_CREDITORLOANCDRF ,"
                        //    + "DA.ACPODRDEPOSITALWCRF DA_ACPODRDEPOSITALWCRF , DA.VARCOSTDEPOALWCRF    DA_VARCOSTDEPOALWCRF "
                        //
                        //    + "FROM DEPOSITALWRF DA "
                        //    + "LEFT JOIN DEPSITMAINRF DM   ON  DA.ENTERPRISECODERF  = DM.ENTERPRISECODERF " 
                        //    + "AND                             DA.CUSTOMERCODERF    = DM.CUSTOMERCODERF "  
                        //    + "AND                             DA.ADDUPSECCODERF    = DM.ADDUPSECCODERF "  
                        //    + "AND                             DA.DEPOSITSLIPNORF   = DM.DEPOSITSLIPNORF "  
                        //    ,sqlConnection);
                        #endregion

                        // -- 2007.07.05　SqlTransactionのnull判定追加
                        if (sqlTransaction == null)
                            sqlCommand = new SqlCommand(DEPOSITALW_BASE, sqlConnection);
                        else
                            sqlCommand = new SqlCommand(DEPOSITALW_BASE, sqlConnection, sqlTransaction);
                        // ↑ 20070124 18322 c

                        //WHERE文の作成
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaDepositRead, logicalMode);

#if DEBUG
                        //--- ADD 2008/06/27 M.Kubota --->>>
                        Console.Clear();
                        Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
                        //--- ADD 2008/06/27 M.Kubota ---<<<
# endif

                        //入金/引当ﾏｽﾀ Read
                        // ↓ 20070406 18322 c
                        //sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.Default);
                        // ↑ 20070406 18322 c

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
                                    nextData = true;
                                    break;
                                }
                            }

                            //入金マスタ
                            #region 値セット
                            // ↓ 20070124 18322 c MA.NS用に変更
                            #region SF 検索データを入金マスタワークへコピー（全てコメントアウト）
                            //DepsitDataWork wkDepsitMainWork = new DepsitDataWork();
                            //
                            //wkDepsitMainWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
                            //wkDepsitMainWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
                            //wkDepsitMainWork.EnterpriseCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
                            //wkDepsitMainWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
                            //wkDepsitMainWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
                            //wkDepsitMainWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
                            //wkDepsitMainWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
                            //wkDepsitMainWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
                            //
                            //wkDepsitMainWork.DepositDebitNoteCd   = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
                            //wkDepsitMainWork.DepositSlipNo        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
                            //wkDepsitMainWork.DepositKindCode      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
                            //wkDepsitMainWork.CustomerCode         = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
                            //wkDepsitMainWork.DepositCd            = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
                            //wkDepsitMainWork.DepositTotal         = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
                            //wkDepsitMainWork.Outline              = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
                            //wkDepsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERSALESNORF"));
                            //wkDepsitMainWork.InputDepositSecCd    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
                            //wkDepsitMainWork.DepositDate          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
                            //wkDepsitMainWork.AddUpSecCode         = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
                            //wkDepsitMainWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
                            //wkDepsitMainWork.UpdateSecCd          = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
                            //wkDepsitMainWork.DepositKindName      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
                            //wkDepsitMainWork.DepositAllowance     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
                            //wkDepsitMainWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
                            //wkDepsitMainWork.DepositAgentCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
                            //wkDepsitMainWork.DepositKindDivCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
                            //wkDepsitMainWork.FeeDeposit           = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
                            //wkDepsitMainWork.DiscountDeposit      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
                            //wkDepsitMainWork.CreditOrLoanCd       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
                            //wkDepsitMainWork.CreditCompanyCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
                            //wkDepsitMainWork.Deposit              = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
                            //wkDepsitMainWork.DraftDrawingDate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
                            //wkDepsitMainWork.DraftPayTimeLimit    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
                            //wkDepsitMainWork.DebitNoteLinkDepoNo  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
                            //wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
                            //wkDepsitMainWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
                            //
                            //wkDepsitMainWork.AcpOdrDeposit        = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITRF"));
                            //wkDepsitMainWork.AcpOdrChargeDeposit  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRCHARGEDEPOSITRF"));
                            //wkDepsitMainWork.AcpOdrDisDeposit     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDISDEPOSITRF"));
                            //wkDepsitMainWork.VariousCostDeposit   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARIOUSCOSTDEPOSITRF"));
                            //wkDepsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTCHARGEDEPOSITRF"));
                            //wkDepsitMainWork.VarCostDisDeposit    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDISDEPOSITRF"));
                            //wkDepsitMainWork.AcpOdrDepositAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITALWCRF"));
                            //wkDepsitMainWork.AcpOdrDepoAlwcBlnce  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOALWCBLNCERF"));
                            //wkDepsitMainWork.VarCostDepoAlwc      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCRF"));
                            //wkDepsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCBLNCERF"));
                            #endregion

                            // 検索データを入金マスタワークへコピー
                            DepsitMainWork wkDepsitMainWork = new DepsitMainWork();
                            CopyToDepsitMainWorkFromSelectData(ref wkDepsitMainWork, myReader);
                            // ↑ 20070124 18322 c

                            int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                            int myIndex = alwk.IndexOf(myObjectOdd);
                            if (myIndex < 0)
                            {
                                alwk.Add(wkDepsitMainWork.DepositSlipNo);
                                //             al.Add(wkDepsitMainWork);
                            }
                            #endregion


                            //引当マスタ
                            #region
                            // ↓ 20070124 18322 c MA.NS用に変更
                            #region SF 検索データを入金引当マスタワークへコピー（全てコメントアウト）
                            //DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                            //
                            //wkDepositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
                            //wkDepositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
                            //wkDepositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
                            //wkDepositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
                            //wkDepositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
                            //wkDepositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
                            //wkDepositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
                            //wkDepositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
                            //
                            //wkDepositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
                            //wkDepositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
                            //wkDepositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
                            //wkDepositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
                            //wkDepositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
                            //wkDepositAlwWork.DepositInputDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITINPUTDATERF"));
                            //wkDepositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
                            //wkDepositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
                            //wkDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
                            //wkDepositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
                            //wkDepositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
                            //wkDepositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
                            //
                            //wkDepositAlwWork.AcpOdrDepositAlwc  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACPODRDEPOSITALWCRF"));
                            //wkDepositAlwWork.VarCostDepoAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_VARCOSTDEPOALWCRF"));
                            #endregion

                            // 検索データを入金引当マスタワークへコピー
                            DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                            CopyToDepsitAlwWorkFromSelectData(ref wkDepositAlwWork, myReader);
                            // ↑ 20070124 18322 c

                            // ↓ 20070124 18322 d 削除
                            //if (wkDepositAlwWork.AcceptAnOrderNo>0)
                            //{
                            //       //      al2.Add(wkDepositAlwWork);
                            //}
                            // ↑ 20070124 18322 d
                            #endregion

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }


                        //-------------------------------------------------------------------------------------------------------------//
                        //-- 抽出したデータの「入金伝票番号」で再度検索 ------------------------------------------------------------------//
                        //-------------------------------------------------------------------------------------------------------------//
                        // ↓ 20070406 18322 SF(全てコメントアウト)
                        #region 入金・入金引当データ再検索
                        //int wk_DepositSlipNo = 0;
                        //for(int ii = 1 ; ii <= alwk.Count ; ii++)
                        //{
                        //    wk_DepositSlipNo = Convert.ToInt32( alwk[ii-1] );
                        //
                        //    searchParaDepositRead.DepositSlipNo   = wk_DepositSlipNo;  //入金伝票番号セット
                        //    
                        //    searchParaDepositRead.AcceptAnOrderNo = 0;                 //受注番号クリア
                        //
                        //    //SQL文生成
                        //    sqlConnection = new SqlConnection(connectionText);
                        //    sqlConnection.Open();
                        //
                        //    sqlCommand = new SqlCommand("SELECT "
                        //        + "DM.CREATEDATETIMERF       DM_CREATEDATETIMERF       , DM.UPDATEDATETIMERF       DM_UPDATEDATETIMERF       , DM.ENTERPRISECODERF     DM_ENTERPRISECODERF ,"
                        //        + "DM.FILEHEADERGUIDRF       DM_FILEHEADERGUIDRF       , DM.UPDEMPLOYEECODERF      DM_UPDEMPLOYEECODERF      , DM.UPDASSEMBLYID1RF     DM_UPDASSEMBLYID1RF ,"
                        //        + "DM.UPDASSEMBLYID2RF       DM_UPDASSEMBLYID2RF       , DM.LOGICALDELETECODERF    DM_LOGICALDELETECODERF    , DM.DEPOSITDEBITNOTECDRF DM_DEPOSITDEBITNOTECDRF ,"
                        //        + "DM.DEPOSITSLIPNORF        DM_DEPOSITSLIPNORF        , DM.DEPOSITKINDCODERF      DM_DEPOSITKINDCODERF      , DM.CUSTOMERCODERF       DM_CUSTOMERCODERF ,"
                        //        + "DM.DEPOSITCDRF            DM_DEPOSITCDRF            , DM.DEPOSITTOTALRF         DM_DEPOSITTOTALRF         , DM.OUTLINERF            DM_OUTLINERF,"
                        //        + "DM.ACCEPTANORDERSALESNORF DM_ACCEPTANORDERSALESNORF , DM.INPUTDEPOSITSECCDRF    DM_INPUTDEPOSITSECCDRF    , DM.DEPOSITDATERF        DM_DEPOSITDATERF ,"
                        //        + "DM.ADDUPSECCODERF         DM_ADDUPSECCODERF         , DM.ADDUPADATERF           DM_ADDUPADATERF           , DM.UPDATESECCDRF        DM_UPDATESECCDRF ,"
                        //        + "DM.DEPOSITKINDNAMERF      DM_DEPOSITKINDNAMERF      , DM.DEPOSITALLOWANCERF     DM_DEPOSITALLOWANCERF     , DM.DEPOSITALWCBLNCERF   DM_DEPOSITALWCBLNCERF ,"
                        //        + "DM.DEPOSITAGENTCODERF     DM_DEPOSITAGENTCODERF     , DM.DEPOSITKINDDIVCDRF     DM_DEPOSITKINDDIVCDRF     , DM.FEEDEPOSITRF         DM_FEEDEPOSITRF ,"
                        //        + "DM.DISCOUNTDEPOSITRF      DM_DISCOUNTDEPOSITRF      , DM.CREDITORLOANCDRF       DM_CREDITORLOANCDRF       , DM.CREDITCOMPANYCODERF  DM_CREDITCOMPANYCODERF ,"
                        //        + "DM.DEPOSITRF              DM_DEPOSITRF              , DM.DRAFTDRAWINGDATERF     DM_DRAFTDRAWINGDATERF     , DM.DRAFTPAYTIMELIMITRF  DM_DRAFTPAYTIMELIMITRF ,"
                        //        + "DM.DEBITNOTELINKDEPONORF  DM_DEBITNOTELINKDEPONORF  , DM.LASTRECONCILEADDUPDTRF DM_LASTRECONCILEADDUPDTRF , DM.AUTODEPOSITCDRF      DM_AUTODEPOSITCDRF ,"
                        //        + "DM.ACPODRDEPOSITRF        DM_ACPODRDEPOSITRF        , DM.ACPODRCHARGEDEPOSITRF  DM_ACPODRCHARGEDEPOSITRF  , DM.ACPODRDISDEPOSITRF   DM_ACPODRDISDEPOSITRF ,"
                        //        + "DM.VARIOUSCOSTDEPOSITRF   DM_VARIOUSCOSTDEPOSITRF   , DM.VARCOSTCHARGEDEPOSITRF DM_VARCOSTCHARGEDEPOSITRF , DM.VARCOSTDISDEPOSITRF  DM_VARCOSTDISDEPOSITRF ,"
                        //        + "DM.ACPODRDEPOSITALWCRF    DM_ACPODRDEPOSITALWCRF    , DM.ACPODRDEPOALWCBLNCERF  DM_ACPODRDEPOALWCBLNCERF  , DM.VARCOSTDEPOALWCRF    DM_VARCOSTDEPOALWCRF ,"
                        //        + "DM.VARCOSTDEPOALWCBLNCERF DM_VARCOSTDEPOALWCBLNCERF ," 
                        //    
                        //        + "DA.CREATEDATETIMERF    DA_CREATEDATETIMERF    , DA.UPDATEDATETIMERF     DA_UPDATEDATETIMERF ,    DA.ENTERPRISECODERF    DA_ENTERPRISECODERF ,"
                        //        + "DA.FILEHEADERGUIDRF    DA_FILEHEADERGUIDRF    , DA.UPDEMPLOYEECODERF    DA_UPDEMPLOYEECODERF ,   DA.UPDASSEMBLYID1RF    DA_UPDASSEMBLYID1RF ,"
                        //        + "DA.UPDASSEMBLYID2RF    DA_UPDASSEMBLYID2RF    , DA.LOGICALDELETECODERF  DA_LOGICALDELETECODERF , DA.CUSTOMERCODERF      DA_CUSTOMERCODERF ,"
                        //        + "DA.ADDUPSECCODERF      DA_ADDUPSECCODERF      , DA.ACCEPTANORDERNORF    DA_ACCEPTANORDERNORF ,   DA.DEPOSITSLIPNORF     DA_DEPOSITSLIPNORF ,"
                        //        + "DA.DEPOSITKINDCODERF   DA_DEPOSITKINDCODERF   , DA.DEPOSITINPUTDATERF   DA_DEPOSITINPUTDATERF ,  DA.DEPOSITALLOWANCERF  DA_DEPOSITALLOWANCERF ,"
                        //        + "DA.RECONCILEDATERF     DA_RECONCILEDATERF     , DA.RECONCILEADDUPDATERF DA_RECONCILEADDUPDATERF ,DA.DEBITNOTEOFFSETCDRF DA_DEBITNOTEOFFSETCDRF ,"
                        //        + "DA.DEPOSITCDRF         DA_DEPOSITCDRF         , DA.CREDITORLOANCDRF     DA_CREDITORLOANCDRF ,"
                        //        + "DA.ACPODRDEPOSITALWCRF DA_ACPODRDEPOSITALWCRF , DA.VARCOSTDEPOALWCRF    DA_VARCOSTDEPOALWCRF "
                        //    
                        //        + " FROM DEPSITMAINRF DM "
                        //        + "LEFT JOIN DEPOSITALWRF DA   ON  DM.ENTERPRISECODERF  = DA.ENTERPRISECODERF " 
                        //        + "AND                             DM.CUSTOMERCODERF    = DA.CUSTOMERCODERF "  
                        //        + "AND                             DM.ADDUPSECCODERF    = DA.ADDUPSECCODERF "  
                        //        + "AND                             DM.DEPOSITSLIPNORF   = DA.DEPOSITSLIPNORF "  
                        //        ,sqlConnection);
                        //
                        //    sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection);
                        //
                        //    //WHERE文の作成
                        //    sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
                        //
                        //    //入金/引当ﾏｽﾀ Read
                        //    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        //
                        //    while(sqlDataReader.Read())
                        //    {
                        //        //入金マスタ
                        //        DepsitDataWork wkDepsitMainWork = new DepsitDataWork();
                        //        
                        //        wkDepsitMainWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
                        //        wkDepsitMainWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
                        //        wkDepsitMainWork.EnterpriseCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
                        //        wkDepsitMainWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
                        //        wkDepsitMainWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
                        //        wkDepsitMainWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
                        //        wkDepsitMainWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
                        //        wkDepsitMainWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
                        //        
                        //        wkDepsitMainWork.DepositDebitNoteCd   = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
                        //        wkDepsitMainWork.DepositSlipNo        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
                        //        wkDepsitMainWork.DepositKindCode      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
                        //        wkDepsitMainWork.CustomerCode         = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
                        //        wkDepsitMainWork.DepositCd            = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
                        //        wkDepsitMainWork.DepositTotal         = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
                        //        wkDepsitMainWork.Outline              = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
                        //        wkDepsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERSALESNORF"));
                        //        wkDepsitMainWork.InputDepositSecCd    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
                        //        wkDepsitMainWork.DepositDate          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
                        //        wkDepsitMainWork.AddUpSecCode         = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
                        //        wkDepsitMainWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
                        //        wkDepsitMainWork.UpdateSecCd          = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
                        //        wkDepsitMainWork.DepositKindName      = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
                        //        wkDepsitMainWork.DepositAllowance     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
                        //        wkDepsitMainWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
                        //        wkDepsitMainWork.DepositAgentCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
                        //        wkDepsitMainWork.DepositKindDivCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
                        //        wkDepsitMainWork.FeeDeposit           = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
                        //        wkDepsitMainWork.DiscountDeposit      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
                        //        wkDepsitMainWork.CreditOrLoanCd       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
                        //        wkDepsitMainWork.CreditCompanyCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
                        //        wkDepsitMainWork.Deposit              = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
                        //        wkDepsitMainWork.DraftDrawingDate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
                        //        wkDepsitMainWork.DraftPayTimeLimit    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
                        //        wkDepsitMainWork.DebitNoteLinkDepoNo  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
                        //        wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
                        //        wkDepsitMainWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
                        //        
                        //        wkDepsitMainWork.AcpOdrDeposit        = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITRF"));
                        //        wkDepsitMainWork.AcpOdrChargeDeposit  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRCHARGEDEPOSITRF"));
                        //        wkDepsitMainWork.AcpOdrDisDeposit     = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDISDEPOSITRF"));
                        //        wkDepsitMainWork.VariousCostDeposit   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARIOUSCOSTDEPOSITRF"));
                        //        wkDepsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTCHARGEDEPOSITRF"));
                        //        wkDepsitMainWork.VarCostDisDeposit    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDISDEPOSITRF"));
                        //        wkDepsitMainWork.AcpOdrDepositAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOSITALWCRF"));
                        //        wkDepsitMainWork.AcpOdrDepoAlwcBlnce  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_ACPODRDEPOALWCBLNCERF"));
                        //        wkDepsitMainWork.VarCostDepoAlwc      = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCRF"));
                        //        wkDepsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DM_VARCOSTDEPOALWCBLNCERF"));
                        //
                        //        int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                        //        int myIndex=alwk2.IndexOf( myObjectOdd );
                        //        if ( myIndex < 0 )
                        //        {
                        //            alwk2.Add(wkDepsitMainWork.DepositSlipNo);
                        //            al.Add(wkDepsitMainWork);
                        //        }
                        //
                        //        //引当マスタ
                        //        DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                        //        
                        //        wkDepositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
                        //        wkDepositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(   sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
                        //        wkDepositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
                        //        wkDepositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(                sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
                        //        wkDepositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
                        //        wkDepositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
                        //        wkDepositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
                        //        wkDepositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
                        //        
                        //        wkDepositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
                        //        wkDepositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString(              sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
                        //        wkDepositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
                        //        wkDepositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
                        //        wkDepositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
                        //        wkDepositAlwWork.DepositInputDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITINPUTDATERF"));
                        //        wkDepositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
                        //        wkDepositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
                        //        wkDepositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
                        //        wkDepositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
                        //        wkDepositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
                        //        wkDepositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32(               sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
                        //        
                        //        wkDepositAlwWork.AcpOdrDepositAlwc  = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_ACPODRDEPOSITALWCRF"));
                        //        wkDepositAlwWork.VarCostDepoAlwc    = SqlDataMediator.SqlGetInt64(               sqlDataReader,sqlDataReader.GetOrdinal("DA_VARCOSTDEPOALWCRF"));
                        //
                        //        if (wkDepositAlwWork.UpdAssemblyId1 != "")
                        //        {
                        //            al2.Add(wkDepositAlwWork);
                        //        }
                        //
                        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        //    }
                        //
                        //}
                        #endregion
                        // ↑ 20070406 18322 d

                        // ↓ 20070406 18322 a

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region 入金・入金引当データ再検索
                        int wk_DepositSlipNo = 0;
                        for (int ii = 1; ii <= alwk.Count; ii++)
                        {
                            wk_DepositSlipNo = Convert.ToInt32(alwk[ii - 1]);

                            searchParaDepositRead.DepositSlipNo = wk_DepositSlipNo;  //入金伝票番号セット

                            // ↓ 2007.10.11 980081 d
                            //searchParaDepositRead.AcceptAnOrderNo = 0;                 //受注番号クリア
                            // ↑ 2007.10.11 980081 d

                            // -- 2007.07.05　SqlTransactionのnull判定追加
                            if (sqlTransaction == null)
                                sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection);
                            else
                                sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection, sqlTransaction);

                            //WHERE文の作成
                            sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaDepositRead, logicalMode);

                            //入金/引当ﾏｽﾀ Read
                            myReader = sqlCommand.ExecuteReader(CommandBehavior.Default);

                            while (myReader.Read())
                            {
                                // 検索データを入金マスタワークへコピー
                                DepsitMainWork wkDepsitMainWork = new DepsitMainWork();
                                CopyToDepsitMainWorkFromSelectData(ref wkDepsitMainWork, myReader);

                                int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                                int myIndex = alwk2.IndexOf(myObjectOdd);
                                if (myIndex < 0)
                                {
                                    alwk2.Add(wkDepsitMainWork.DepositSlipNo);
                                    al.Add(wkDepsitMainWork);
                                }

                                // 検索データを入金引当マスタワークへコピー
                                DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                                CopyToDepsitAlwWorkFromSelectData(ref wkDepositAlwWork, myReader);

                                if (wkDepositAlwWork.UpdAssemblyId1 != "")
                                {
                                    al2.Add(wkDepositAlwWork);
                                }

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                        #endregion
                        // ↑ 20070406 18322 a
                        //-------------------------------------------------------------------------------------------------------------//
                        //-------------------------------------------------------------------------------------------------------------//

                    }

                    //--- ADD 2008/06/27 M.Kubota --->>>
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }

                    // 入金マスタデータに紐付く入金明細データと取得し、双方と結合した入金データを作成する
                    ArrayList al3 = null;
                    status = this.SearchDetail(al, out al3, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        al.Clear();
                        al.AddRange(al3);
                    }
                    //--- ADD 2008/06/27 M.Kubota --->>>
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    //status = base.WriteSQLErrorLog(ex);  //DEL 2008/06/27 M.Kubota
                    //--- ADD 2008/06/27 M.Kubota --->>>
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                    //--- ADD 2008/06/27 M.Kubota ---<<<
                }
                //--- ADD 2008/06/27 M.Kubota --->>>
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                            myReader.Close();
                        myReader.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Dispose();
                    }

                    depsitDataWork = al;
                    depositAlwWork = al2;
                }
                //--- ADD 2008/06/27 M.Kubota ---<<<

                # region --- DEL 2008/06/27 M.Kubota ---
                //if (!sqlDataReader.IsClosed) sqlDataReader.Close();

                // ↓ 20070406 18322 c パラメータ変更の対応
                //sqlConnection.Close();
                
                //if (sqlConnect == null)
                //{
                //    sqlConnection.Close();
                //}
                // ↑ 20070406 18322 c
                
                //depsitDataWork = al;
                //depositAlwWork = al2;
                # endregion

            }
            catch(Exception ex)
            {
                //base.WriteErrorLog(ex,"DepositReadDB.SearchProc Exception="+ex.Message);  //DEL 2008/06/27 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //--- ADD 2008/06/27 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //--- ADD 2008/06/27 M.Kubota ---<<<
            }

            return status;
        }

        // ↓ 20070124 18322 a MA.NS用に変更
        /// <summary>
        /// SQLデータリーダー→入金マスタワーク
        /// </summary>
        /// <param name="depsitMainWork">入金マスタワーク</param>
        /// <param name="sqlDataReader">SQLデータリーダー</param>
        /// <returns>なし</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を入金マスタワークにコピーします。</br>
        /// <br>              (SFUKK01362RのReadDepsitMainWorkRec関数の検索データの取得方法を参考)</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        private void CopyToDepsitMainWorkFromSelectData(ref DepsitMainWork depsitMainWork, SqlDataReader sqlDataReader)
        {
            #region 旧レイアウト(コメントアウト)
            //--- DEL 2008/06/27 M.Kubota --->>>
            // ↓ 2007.10.11 980081 c
            #region 旧レイアウト(コメントアウト)
            //// 作成日時
            //depsitDataWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
            //// 更新日時
            //depsitDataWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
            //// 企業コード
            //depsitDataWork.EnterpriseCode        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
            //// GUID
            //depsitDataWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
            //// 更新従業員コード
            //depsitDataWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
            //// 更新アセンブリID1
            //depsitDataWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
            //// 更新アセンブリID2
            //depsitDataWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
            //// 論理削除区分
            //depsitDataWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
            //// 入金赤黒区分
            //depsitDataWork.DepositDebitNoteCd    = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
            //// 入金伝票番号
            //depsitDataWork.DepositSlipNo         = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
            //// 受注番号
            //depsitDataWork.AcceptAnOrderNo       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERNORF"));
            //// サービス伝票区分
            //depsitDataWork.ServiceSlipCd         = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_SERVICESLIPCDRF"));
            //// 入金入力拠点コード
            //depsitDataWork.InputDepositSecCd     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
            //// 計上拠点コード
            //depsitDataWork.AddUpSecCode          = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
            //// 更新拠点コード
            //depsitDataWork.UpdateSecCd           = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
            //// 入金日付
            //depsitDataWork.DepositDate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
            //// 計上日付
            //depsitDataWork.AddUpADate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
            //// 入金金種コード
            //depsitDataWork.DepositKindCode       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
            //// 入金金種名称
            //depsitDataWork.DepositKindName       = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
            //// 入金金種区分
            //depsitDataWork.DepositKindDivCd      = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
            //// 入金計
            //depsitDataWork.DepositTotal          = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
            //// 入金金額
            //depsitDataWork.Deposit               = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
            //// 手数料入金額
            //depsitDataWork.FeeDeposit            = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
            //// 値引入金額
            //depsitDataWork.DiscountDeposit       = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
            //// リベート入金額
            //depsitDataWork.RebateDeposit         = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_REBATEDEPOSITRF"));
            //// 自動入金区分
            //depsitDataWork.AutoDepositCd         = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
            //// 預り金区分
            //depsitDataWork.DepositCd             = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
            //// クレジット／ローン区分
            //depsitDataWork.CreditOrLoanCd        = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
            //// クレジット会社コード
            //depsitDataWork.CreditCompanyCode     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
            //// 手形振出日
            //depsitDataWork.DraftDrawingDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
            //// 手形支払期日
            //depsitDataWork.DraftPayTimeLimit     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
            //// 入金引当額
            //depsitDataWork.DepositAllowance      = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
            //// 入金引当残高
            //depsitDataWork.DepositAlwcBlnce      = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
            //// 赤黒入金連結番号
            //depsitDataWork.DebitNoteLinkDepoNo   = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
            //// 最終消し込み計上日
            //depsitDataWork.LastReconcileAddUpDt  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
            //// 入金担当者コード
            //depsitDataWork.DepositAgentCode      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
            //// 入金担当者名称
            //depsitDataWork.DepositAgentNm        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTNMRF"));
            //// 得意先コード
            //depsitDataWork.CustomerCode          = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
            //// 得意先名称
            //depsitDataWork.CustomerName          = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERNAMERF"));
            //// 得意先名称2
            //depsitDataWork.CustomerName2         = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERNAME2RF"));
            //// 伝票摘要
            //depsitDataWork.Outline               = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_OUTLINERF"));
            #endregion
            //depsitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
            //depsitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
            //depsitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
            //depsitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
            //depsitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
            //depsitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
            //depsitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
            //depsitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
            //depsitDataWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_ACPTANODRSTATUSRF"));
            //depsitDataWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
            //depsitDataWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
            //depsitDataWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_SALESSLIPNUMRF"));
            //depsitDataWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
            //depsitDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
            //depsitDataWork.UpdateSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
            //depsitDataWork.SubSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_SUBSECTIONCODERF"));
            //depsitDataWork.MinSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_MINSECTIONCODERF"));
            //depsitDataWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
            //depsitDataWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
            //depsitDataWork.DepositKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
            //depsitDataWork.DepositKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
            //depsitDataWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
            //depsitDataWork.DepositTotal = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
            //depsitDataWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
            //depsitDataWork.FeeDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
            //depsitDataWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
            //depsitDataWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
            //depsitDataWork.DepositCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
            //depsitDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
            //depsitDataWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
            //depsitDataWork.DraftKind = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTKINDRF"));
            //depsitDataWork.DraftKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTKINDNAMERF"));
            //depsitDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTDIVIDERF"));
            //depsitDataWork.DraftDivideName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTDIVIDENAMERF"));
            //depsitDataWork.DraftNo = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTNORF"));
            //depsitDataWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
            //depsitDataWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
            //depsitDataWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
            //depsitDataWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
            //depsitDataWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
            //depsitDataWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITAGENTNMRF"));
            //depsitDataWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITINPUTAGENTCDRF"));
            //depsitDataWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITINPUTAGENTNMRF"));
            //depsitDataWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
            //depsitDataWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERNAMERF"));
            //depsitDataWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERNAME2RF"));
            //depsitDataWork.CustomerSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERSNMRF"));
            //depsitDataWork.ClaimCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMCODERF"));
            //depsitDataWork.ClaimName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMNAMERF"));
            //depsitDataWork.ClaimName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMNAME2RF"));
            //depsitDataWork.ClaimSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMSNMRF"));
            //depsitDataWork.Outline = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_OUTLINERF"));
            //depsitDataWork.BankCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_BANKCODERF"));
            //depsitDataWork.BankName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_BANKNAMERF"));
            //depsitDataWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_EDISENDDATERF"));
            // ↓ 2007.12.10 980081 c
            //depsitDataWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_EDITAKEINDATERF"));
            //depsitDataWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_EDITAKEINDATERF"));
            // ↑ 2007.12.10 980081 c
            // ↑ 2007.10.11 980081 c
            //--- DEL 2008/06/27 M.Kubota ---<<<
            # endregion

            //--- ADD 2008/06/27 M.Kubota --->>>
            depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
            depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
            depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
            depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
            depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
            depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
            depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
            depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
            depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_ACPTANODRSTATUSRF"));
            depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
            depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
            depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_SALESSLIPNUMRF"));
            depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
            depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
            depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
            depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_SUBSECTIONCODERF"));
            depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
            depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
            depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
            depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
            depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
            depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
            depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
            depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
            depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTKINDRF"));
            depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTKINDNAMERF"));
            depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTDIVIDERF"));
            depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTDIVIDENAMERF"));
            depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DRAFTNORF"));
            depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
            depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
            depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
            depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
            depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
            depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITAGENTNMRF"));
            depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITINPUTAGENTCDRF"));
            depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_DEPOSITINPUTAGENTNMRF"));
            depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
            depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERNAMERF"));
            depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERNAME2RF"));
            depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CUSTOMERSNMRF"));
            depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMCODERF"));
            depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMNAMERF"));
            depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMNAME2RF"));
            depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_CLAIMSNMRF"));
            depsitMainWork.Outline = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_OUTLINERF"));
            depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_BANKCODERF"));
            depsitMainWork.BankName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DM_BANKNAMERF"));
            //--- ADD 2008/06/27 M.Kubota ---<<<
        }

        /// <summary>
        /// SQLデータリーダー→入金引当マスタワーク
        /// </summary>
        /// <param name="depositAlwWork">入金引当マスタワーク</param>
        /// <param name="sqlDataReader">SQLデータリーダー</param>
        /// <returns>なし</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を入金マスタワークにコピーします。</br>
        /// <br>              (SFUKK01362RのReadDepositAlwWorkRec関数の検索データの取得方法を参考)</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        private void CopyToDepsitAlwWorkFromSelectData(ref DepositAlwWork depositAlwWork, SqlDataReader sqlDataReader)
        {
            # region 旧レイアウト(コメントアウト)
            //--- DEL 2008/06/27 M.Kubota --->>> 
            // ↓ 2007.10.11 980081 c
            #region 旧レイアウト(コメントアウト)
            //// 作成日時
            //depositAlwWork.CreateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
            //// 更新日時
            //depositAlwWork.UpdateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
            //// 企業コード
            //depositAlwWork.EnterpriseCode      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
            //// GUID
            //depositAlwWork.FileHeaderGuid      = SqlDataMediator.SqlGetGuid(sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
            //// 更新従業員コード
            //depositAlwWork.UpdEmployeeCode     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
            //// 更新アセンブリID1
            //depositAlwWork.UpdAssemblyId1      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
            //// 更新アセンブリID2
            //depositAlwWork.UpdAssemblyId2      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
            //// 論理削除区分
            //depositAlwWork.LogicalDeleteCode   = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
            //// 入金入力拠点コード
            //depositAlwWork.InputDepositSecCd   = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_INPUTDEPOSITSECCDRF"));
            //// 計上拠点コード
            //depositAlwWork.AddUpSecCode        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
            //// 消込み日
            //depositAlwWork.ReconcileDate       = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
            //// 消込み計上日
            //depositAlwWork.ReconcileAddUpDate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
            //// 入金伝票番号
            //depositAlwWork.DepositSlipNo       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
            //// 入金金種コード
            //depositAlwWork.DepositKindCode     = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
            //// 入金金種名称
            //depositAlwWork.DepositKindName     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDNAMERF"));
            //// 入金引当額
            //depositAlwWork.DepositAllowance    = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
            //// 入金担当者コード
            //depositAlwWork.DepositAgentCode    = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITAGENTCODERF"));
            //// 入金担当者名称
            //depositAlwWork.DepositAgentNm      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITAGENTNMRF"));
            //// 得意先コード
            //depositAlwWork.CustomerCode        = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
            //// 得意先名称
            //depositAlwWork.CustomerName        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERNAMERF"));
            //// 得意先名称2
            //depositAlwWork.CustomerName2       = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERNAME2RF"));
            //// 受注番号
            //depositAlwWork.AcceptAnOrderNo     = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
            //// サービス伝票区分
            //depositAlwWork.ServiceSlipCd       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_SERVICESLIPCDRF"));
            //// 赤伝相殺区分
            //depositAlwWork.DebitNoteOffSetCd   = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
            //// 預り金区分
            //depositAlwWork.DepositCd           = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
            //// クレジット／ローン区分
            //depositAlwWork.CreditOrLoanCd      = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_CREDITORLOANCDRF"));
            #endregion
            //depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
            //depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
            //depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
            //depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
            //depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
            //depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
            //depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
            //depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
            //depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_INPUTDEPOSITSECCDRF"));
            //depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
            //depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
            //depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
            //depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
            //depositAlwWork.DepositKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
            //depositAlwWork.DepositKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITKINDNAMERF"));
            //depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
            //depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITAGENTCODERF"));
            //depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITAGENTNMRF"));
            //depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
            //depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_CUSTOMERNAMERF"));
            //depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_CUSTOMERNAME2RF"));
            //depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
            //depositAlwWork.DepositCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
            //depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_ACPTANODRSTATUSRF"));
            //depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_SALESSLIPNUMRF"));
            // ↑ 2007.10.11 980081 c
            //--- DEL 2008/06/27 M.Kubota ---<<<
            # endregion

            //--- ADD 2008/06/27 M.Kubota --->>>
            depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
            depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
            depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
            depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
            depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
            depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
            depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
            depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
            depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_INPUTDEPOSITSECCDRF"));
            depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
            depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_ACPTANODRSTATUSRF"));
            depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_SALESSLIPNUMRF"));
            depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
            depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
            depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
            depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
            depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITAGENTCODERF"));
            depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEPOSITAGENTNMRF"));
            depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
            depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_CUSTOMERNAMERF"));
            depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DA_CUSTOMERNAME2RF"));
            depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
            //--- ADD 2008/06/27 M.Kubota ---<<<
        }
        // ↑ 20070124 18322 a

        # region  Where文作成

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchParaDepositRead">検索パラメータクラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchParaDepositRead searchParaDepositRead, ConstantManagement.LogicalMode logicalMode)
        {
            SearchParaDepositRead SPTA = (SearchParaDepositRead)searchParaDepositRead;
            string enterpriseCode      = SPTA.EnterpriseCode;
            string addUpSecCode        = SPTA.AddUpSecCode;
            int customerCode           = SPTA.CustomerCode;
            // ↓ 2007.10.11 980081 c
            //int acceptAnOrderNo        = SPTA.AcceptAnOrderNo;
            int claimCode              = SPTA.ClaimCode;
            int acptAnOdrStatus        = SPTA.AcptAnOdrStatus;
            string salesSlipNum        = SPTA.SalesSlipNum;
            // ↑ 2007.10.11 980081 c
            int depositSlipNo          = SPTA.DepositSlipNo;
            int alwcDepositCall        = SPTA.AlwcDepositCall;
            int autoDepositCd          = SPTA.AutoDepositCd;
            // ↓ 2007.10.11 980081 d
            //int serviceSlipCd          = SPTA.ServiceSlipCd;
            // ↑ 2007.10.11 980081 d

            // ↓ 20070124 18322 c MA.NS用に変更
            //DateTime depositCallMonthsStart = SPTA.DepositCallMonthsStart;
            //DateTime depositCallMonthsEnd   = SPTA.DepositCallMonthsEnd;
            // ↑ 20070124 18322 c

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                // ↓ 20070124 18322 c MA.NS用に変更
                //sDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsStart);
                //eDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsEnd);

                sDate  = SPTA.DepositCallMonthsStart;
                eDate  = SPTA.DepositCallMonthsEnd;
                // ↑ 20070124 18322 c
            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }


            string retstring = " WHERE ";

            //企業コード
            retstring += " DM.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            string logidelstr = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                logidelstr = " AND DM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if	((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                logidelstr = " AND DM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if(logidelstr != "")
            {
                retstring += logidelstr;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            #region SFの方で変更（全てコメントアウト）
//            //配列で複数指定される
//            //拠点コード
//            if(dmBirthdayCndtnWork.SelectSecCd != null)
//            {
//                string sectionCodestr = "";
//                foreach(string seccdstr in dmBirthdayCndtnWork.SelectSecCd)
//                {
//                    if(sectionCodestr != "")sectionCodestr += ",";
//                    sectionCodestr += seccdstr;
//                }
//                if(sectionCodestr != "")
//                {
//                    retstring += " AND CST.MNGSECTIONCODERF IN ("+ sectionCodestr +") ";
//                }
//            }
            #endregion

            //計上拠点コード
            if((addUpSecCode != null)&&(addUpSecCode != ""))
            {
                retstring += " AND DM.ADDUPSECCODERF=@FINDADDUPSECCODE ";
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(addUpSecCode);
            }

            //得意先コード
            if(customerCode > 0)
            {
                retstring += " AND DM.CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
            }
            // ↓ 2007.10.11 980081 a
            //請求先コード
            if (claimCode > 0)
            {
                retstring += " AND DM.CLAIMCODERF=@FINDCLAIMCODE ";
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(claimCode);
            }
            // ↑ 2007.10.11 980081 a

            // ↓ 2007.10.11 980081 c
            //if (acceptAnOrderNo == 0)      //受注番号が入っていなければ、入金伝票番号で Where文作成
            if (acptAnOdrStatus == 0 || salesSlipNum == "")      //受注ステータスまたは売上伝票番号が入っていなければ、入金伝票番号で Where文作成
            // ↑ 2007.10.11 980081 c
            {
               //入金伝票番号
               if(depositSlipNo > 0)
               {
                   retstring += " AND DM.DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO ";
                   SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                   paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositSlipNo);
               }
            }
            else                         //受注ステータスと売上伝票番号が入っていれば、受注ステータスと売上伝票番号で Where文作成
            {
                // ↓ 2007.10.11 980081 c
                ////受注番号
                //retstring += " AND DA.ACCEPTANORDERNORF=@FINDACCEPTANORDERNO ";
                //SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                //paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptAnOrderNo);
                //受注ステータスと売上伝票番号
                retstring += " AND DA.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ";
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acptAnOdrStatus);
                retstring += " AND DA.SALESSLIPNUMRF=@FINDSALESSLIPNUM ";
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipNum);
                // ↑ 2007.10.11 980081 c
            }

            // ↓ 20070514 18322 a MA.NS用に追加
            if (autoDepositCd >= 0)
            {
                // 自動入金区分
                retstring += " AND DM.AUTODEPOSITCDRF=@FINDAUTODEPOSITCD ";
                SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@FINDAUTODEPOSITCD", SqlDbType.Int);
                paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(autoDepositCd);
            }

            // ↓ 2007.10.11 980081 d
            //if (serviceSlipCd >= 0)
            //{
            //    // サービス伝票区分
            //    retstring += " AND DM.SERVICESLIPCDRF=@FINDSERVICESLIPCD ";
            //    SqlParameter paraServiceSlipCd = sqlCommand.Parameters.Add("@FINDSERVICESLIPCD", SqlDbType.Int);
            //    paraServiceSlipCd.Value = SqlDataMediator.SqlSetInt32(serviceSlipCd);
            //}
            // ↑ 2007.10.11 980081 d
            // ↑ 20070514 18322 a

            //入金日(開始)
            if(sDate > 0)
            {
                // --- ADD 2010/12/20 ---------->>>>>
                //retstring += " AND DM.DEPOSITDATERF>=@FINDSTARTDATE ";
                retstring += " AND DM.ADDUPADATERF>=@FINDSTARTDATE ";  // 計上日付を使用する
                // --- ADD 2010/12/20  ----------<<<<<
                SqlParameter paraStartDate = sqlCommand.Parameters.Add("@FINDSTARTDATE", SqlDbType.Int);
                paraStartDate.Value = SqlDataMediator.SqlSetInt32(sDate);
            }

            //入金日(終了)
            if(eDate > 0)
            {
                // --- ADD 2010/12/20 ---------->>>>>
                //retstring += " AND DM.DEPOSITDATERF<=@FINDENDDATE ";
                retstring += " AND DM.ADDUPADATERF<=@FINDENDDATE ";　// 計上日付を使用する
                // --- ADD 2010/12/20  ----------<<<<<
                SqlParameter paraEndDate = sqlCommand.Parameters.Add("@FINDENDDATE", SqlDbType.Int);
                paraEndDate.Value = SqlDataMediator.SqlSetInt32(eDate);
            }

            //引当済入金伝票呼出区分
            if(alwcDepositCall != 0)   //0 でない場合は、引当済分(入金引当残高=0)は抽出対象外
            {
                retstring += " AND DM.DEPOSITALWCBLNCERF <> 0 ";
            }

            #region SFの方で変更（全てコメントアウト）
//            //ソート順位
//            if (dmBirthdayCndtnWork.SortingOrder==0)            //誕生日順
//            {
//                retstring += " ORDER BY FAM.BIRTHDAYRF ";
//            }
//            if (dmBirthdayCndtnWork.SortingOrder==1)            //結婚記念日順
//            {
//                retstring += " ORDER BY FAM.WEDDINGANNIVERSARYRF ";
//            }
//            if (dmBirthdayCndtnWork.SortingOrder==2)            //年齢順
//            {
//                retstring += " ORDER BY FAM.BIRTHDAYRF ";
//            }
            #endregion

            return retstring;
        }

        # endregion

        //--- ADD 2008/06/27 M.Kubota --->>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainList"></param>
        /// <param name="depsitDataList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int SearchDetail(ArrayList depsitMainList, out ArrayList depsitDataList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            depsitDataList = new ArrayList();

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            if (ListUtils.IsNotEmpty(depsitMainList) && ListUtils.Find(depsitMainList, typeof(DepsitMainWork), ListUtils.FindType.Class) != null)
            {
                try
                {
                    # region [SQL文]
                    //--- ADD 2008/06/27 M.Kubota --->>>
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DEPDTL.CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.DEPOSITSLIPNORF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.DEPOSITROWNORF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.DEPOSITRF" + Environment.NewLine;
                    sqlText += " ,DEPDTL.VALIDITYTERMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  DEPSITDTLRF AS DEPDTL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DEPDTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DEPDTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND DEPDTL.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                    //--- ADD 2008/06/27 M.Kubota ---<<<
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    ArrayList depsitDtlList = new ArrayList();

                    foreach (DepsitMainWork depsitMainWrk in depsitMainList)
                    {
                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWrk.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.AcptAnOdrStatus);

                        if (depsitMainWrk.DepositDebitNoteCd != 1)
                        {
                            // 0:黒 2:元黒の場合
                            findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.DepositSlipNo);
                        }
                        else
                        {
                            // 1:赤 の場合
                            findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.DebitNoteLinkDepoNo);
                        }
                        
                        // 入金マスタに紐付く入金明細データを取得
                        sqlDataReader = sqlCommand.ExecuteReader();

                        depsitDtlList.Clear();

                        while (sqlDataReader.Read())
                        {
                            DepsitDtlWork dtlWork = this.CopyToDepsitDtlWorkFromSelectData(sqlDataReader);

                            if (depsitMainWrk.DepositDebitNoteCd == 1)
                            {
                                // 1:赤 の場合
                                dtlWork.DepositSlipNo = depsitMainWrk.DepositSlipNo;
                                dtlWork.Deposit = dtlWork.Deposit * -1;
                            }

                            depsitDtlList.Add(dtlWork);
                        }

                        sqlDataReader.Close();
                        sqlDataReader.Dispose();

                        // 入金明細データが１件以上存在していた場合
                        DepsitDtlWork[] DepsitDtlArray = null;

                        if (ListUtils.IsNotEmpty(depsitDtlList))
                        {
                            DepsitDtlArray = (DepsitDtlWork[])depsitDtlList.ToArray(typeof(DepsitDtlWork));
                        }

                        // 入金マスタデータと入金明細データを結合する
                        DepsitDataWork depsitDataWrk = null;
                        DepsitDataUtil.Union(out depsitDataWrk, depsitMainWrk, DepsitDtlArray);
                        depsitDataList.Add(depsitDataWrk);
                    }

                    if (ListUtils.IsNotEmpty(depsitDataList))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
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
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        public DepsitDtlWork CopyToDepsitDtlWorkFromSelectData(SqlDataReader sqlDataReader)
        {
            DepsitDtlWork result = new DepsitDtlWork();
            this.CopyToDepsitDtlWorkFromSelectData(ref result, sqlDataReader);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitDtlWork"></param>
        /// <param name="sqlDataReader"></param>
        public void CopyToDepsitDtlWorkFromSelectData(ref DepsitDtlWork depsitDtlWork, SqlDataReader sqlDataReader)
        {
            if (depsitDtlWork != null)
            {
                depsitDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));
                depsitDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));
                depsitDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));
                depsitDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));
                depsitDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));
                depsitDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));
                depsitDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));
                depsitDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));
                depsitDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));
                depsitDtlWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));
                depsitDtlWork.DepositRowNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITROWNORF"));
                depsitDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDCODERF"));
                depsitDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDNAMERF"));
                depsitDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDDIVRF"));
                depsitDtlWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITRF"));
                depsitDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("VALIDITYTERMRF"));
            }
        }
        //--- ADD 2008/06/27 M.Kubota ---<<<

        #endregion
    }
}

