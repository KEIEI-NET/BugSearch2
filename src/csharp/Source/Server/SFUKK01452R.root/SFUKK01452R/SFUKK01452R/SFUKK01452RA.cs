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
	/// ����/����READDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����/����READ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: 2007.02.02 18322 T.Kimura MA.NS�p�ɕύX</br>
    /// <br>             2007.04.06 18322 T.Kimura SearchProc�֐��̃p�����[�^��ύX</br>
    /// <br>             2007.05.14 18322 T.Kimura 1. �T�[�r�X�`�[�敪������}�X�^�E���������}�X�^�ɒǉ�</br>
    /// <br>                                       2. ���o�����E����/���������p�����[�^�Ɏ��������敪�E�T�[�r�X�`�[�敪��ǉ�</br>
    /// <br>             2007.10.11 980081 A.Yamada DC.NS�p�ɕύX</br>
    /// <br>             2007.12.10 980081 A.Yamada EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX</br>
    /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)</br>
    /// <br>             �������ɂ��i�荞�ݏ����̏C��</br>
    /// <br></br>
	/// </remarks>
	[Serializable]
	//public class DepositReadDB : RemoteDB , IDepositReadDB           //DEL 2008/06/27 M.Kubota
	public class DepositReadDB : RemoteWithAppLockDB , IDepositReadDB  //ADD 2008/06/27 M.Kubota
    {
		/// <summary>
		/// ����/����READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.08.16</br>
		/// </remarks>
		public DepositReadDB() :
		base("SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitDataWork", "DEPSITMAINRF") //���N���X�̃R���X�g���N�^
		{
			//SQL�T�[�o�[�ւ̐ڑ������擾
//			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        }

        #region �萔(���[�J��)
        #region �����}�X�^JOIN���ڃ��X�g

        //--- DEL 2008/06/27 M.Kubota --->>>
        # region �����C�A�E�g(�R�����g�A�E�g)
        // �� 2007.10.11 980081 c
        #region �����C�A�E�g(�R�����g�A�E�g)
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
        // �� 2007.10.11 980081 c
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

        #region ���������}�X�^JOIN���ڃ��X�g
        //--- DEL 2008/06/27 M.Kubota --->>>
        # region �����C�A�E�g(�R�����g�A�E�g)
        // �� 2007.10.11 980081 c
        #region �����C�A�E�g(�R�����g�A�E�g)
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
        // �� 2007.10.11 980081 c
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

        // �����}�X�^��̓��������}�X�^JOIN
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

        // ���������}�X�^�̓����}�X�^�JOIN
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

        #region �m���J�X�^���V���A���C�Y

        // �� 20070124 18322 c MA.NS�p�ɕύX(��SearchProc���P�Ƀ}�[�W)
        #region SF �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�S�ăR�����g�A�E�g�j
        ///// <summary>
        ///// �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j
        ///// </summary>
        ///// <param name="depsitDataWork">��������</param>
        ///// <param name="depositAlwWork">��������</param>
        ///// <param name="searchParaDepositRead">�����p�����[�^</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j</br>
        ///// <br>Programmer : 90027�@�����@��</br>
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
        /// �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="depsitDataWork">��������</param>
        /// <param name="depositAlwWork">��������</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Date: 2007.04.06 T.Kimura SearchProc�p�����[�^��ύX</br>
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
                // �p�����[�^�G���[ -> �_�~�[�f�[�^���쐬���ďI��
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
                // -- 2007.07.05�@SearchProc�̈�����SqlTransaction�ǉ�
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
                    // ����I�������ꍇ

                    // XML�֕ϊ����A������̃o�C�i����
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
        // �� 20070124 18322 c

        // �� 20070124 18322 d MA.NS�p�ɕύX�i�ʂ�SearchProc�֐����g�p����׍폜�j
        #region SF �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�S�ăR�����g�A�E�g�j
        ///// <summary>
        ///// �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂�
        ///// </summary>
        ///// <param name="depsitDataWork">��������</param>
        ///// <param name="depositAlwWork">��������</param>
        ///// <param name="retTotalCnt">�����Ώۑ�����</param>		
        ///// <param name="nextData">���f�[�^�L��</param>
        ///// <param name="searchParaDepositRead">�����p�����[�^</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂�</br>
        ///// <br>Programmer : 90027�@�����@��</br>
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
        //    //��������0�ŏ�����
        //    retTotalCnt = 0;
        //
        //    //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
        //    int _readCnt = readCnt;			
        //    if (_readCnt > 0) _readCnt += 1;
        //    //�����R�[�h�����ŏ�����
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
        //    ArrayList alwk    = new ArrayList();   //�d���f�[�^�����p
        //    ArrayList alwk2   = new ArrayList();   //�d���f�[�^�����p�Q
        //
        //
        //    try
        //    {
        //    try 
        //    {	
        //        //�R�l�N�V����������擾�Ή�����������
        //        //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
        //        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //        if (connectionText == null || connectionText == "") return status;
        //        //�R�l�N�V����������擾�Ή�����������
        //
//      //          // XML�̓ǂݍ���
//      //          depsitmainWork = (DepsitDataWork)XmlByteSerializer.Deserialize(parabyte,typeof(DepsitDataWork));
        //
        //        if (acceptAnOrderNo==0)   //�󒍔ԍ��������Ă��Ȃ���΁A�����}�X�^�����Ƀf�[�^���o�B�����Ă���΁A�����}�X�^�����Ƀf�[�^���o
        //        {
        //           //--- �󒍔ԍ��������Ă��Ȃ��ꍇ ----------//
        //           //SQL������
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
		//           //WHERE���̍쐬
        //           sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
        //
        //           //����/����Ͻ� Read
        //           sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //           int retCnt = 0;
        //
        //           while(sqlDataReader.Read())
        //           {
        //               //�߂�l�J�E���^�J�E���g
        //               retCnt += 1;
        //               if (readCnt > 0)
        //               {
        //                   //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
        //                   if (readCnt < retCnt) 
        //                   {
        //                       nextData = true;
        //                       break;
        //                   }
        //               }
        //
        //               //�����}�X�^
        //               #region �l�Z�b�g
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
        //               //�����}�X�^
        //               #region �l�Z�b�g
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
        //            //--- �󒍔ԍ��������Ă���ꍇ ----------//
        //            //SQL������
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
        //            //WHERE���̍쐬
        //            sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
        //
        //            //����/����Ͻ� Read
        //            sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //            int retCnt = 0;
        //
        //            while(sqlDataReader.Read())
        //            {
        //                //�߂�l�J�E���^�J�E���g
        //                retCnt += 1;
        //                if (readCnt > 0)
        //                {
        //                    //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
        //                    if (readCnt < retCnt) 
        //                    {
        //                        nextData = true;
        //                        break;
        //                    }
        //                }
        //
        //                //�����}�X�^
        //                #region �l�Z�b�g
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
        //                //�����}�X�^
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
        //            //-- ���o�����f�[�^�́u�����`�[�ԍ��v�ōēx���� ------------------------------------------------------------------//
        //            //-------------------------------------------------------------------------------------------------------------//
        //            int wk_DepositSlipNo = 0;
        //            for(int ii = 1 ; ii <= alwk.Count ; ii++)
        //            {
        //                wk_DepositSlipNo = Convert.ToInt32( alwk[ii-1] );
        //
        //                searchParaDepositRead.DepositSlipNo   = wk_DepositSlipNo;  //�����`�[�ԍ��Z�b�g
        //                searchParaDepositRead.AcceptAnOrderNo = 0;                 //�󒍔ԍ��N���A
        //
        //                //SQL������
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
        //                //WHERE���̍쐬
        //                sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
        //
        //                //����/����Ͻ� Read
        //                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //
        //                while(sqlDataReader.Read())
        //                {
        //                    //�����}�X�^
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
        //                    //�����}�X�^
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
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //
        //    if(!sqlDataReader.IsClosed)sqlDataReader.Close();
        //    sqlConnection.Close();
        //
        //
        //    // XML�֕ϊ����A������̃o�C�i����
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

        #region �J�X�^���V���A���C�Y

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="DepsitDataWork">��������</param>
        /// <param name="DepositAlwWork">��������</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 90027�@�����@��</br>
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

            // �� 20070406 18322 a
            if (_searchParaDepositRead == null)
            {
                // �p�����[�^�G���[ -> �_�~�[���쐬���ďI��
                DepsitDataWork = new ArrayList();
                DepositAlwWork = new ArrayList();
                return status;
            }
            // �� 20070406 18322 a

            try
            {
                // �� 20070406 18322 c DB�R�l�N�V������n���悤�ɕύX
                //status =  SearchProc(out DepsitDataWork , out DepositAlwWork , out retTotalCnt , out nextData , _searchParaDepositRead , readMode , logicalMode , 0);
                
                SqlConnection sqlConnection = null;
                // -- 2007.07.05�@SearchProc�̈�����SqlTransaction�ǉ�
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
                // �� 20070406 18322 c
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
        // �폜���R�� SFUKK01454O ���Q��
# if false
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="DepsitDataWork">��������</param>
        /// <param name="DepositAlwWork">��������</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">DB�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂��i�_���폜�����j</br>
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

            // �p�����[�^��ϊ�
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
                // -- 2007.07.05�@SearchProc�̈�����SqlTransaction�ǉ�
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
        /// �w�肳�ꂽ�����œ����}�X�^�E���������}�X�^���������Ė߂��܂�
        /// </summary>
        /// <param name="DepsitDataWork">�����}�X�^</param>
        /// <param name="DepositAlwWork">���������}�X�^</param>
        /// <param name="searchParaDepositRead">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����œ����}�X�^�E���������}�X�^���������Ė߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.07.05</br>
        public int Search(out object DepsitDataWork, out object DepositAlwWork, object searchParaDepositRead, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int retTotalCnt;
            bool nextData;
            return SearchProc(out DepsitDataWork, out DepositAlwWork, out retTotalCnt, out nextData, (SearchParaDepositRead)searchParaDepositRead, readMode, logicalMode, 0, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="depsitDataWork">��������</param>
        /// <param name="depositAlwWork">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <param name="sqlConnection">DB�R�l�N�V����</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 90027�@�����@��</br>
        /// <br>Date       : 2005.08.16</br>
        /// <br></br>
        /// <br>UpdateNote : 2007.07.05�@19026�@���R�@�����@SqlTransaction ���p�����[�^�ɒǉ�</br>
        // �� 20070406 18322 c �p�����[�^��ǉ�
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
        // �� 20070406 18322 c
        {
            SearchParaDepositRead SPTA = (SearchParaDepositRead)searchParaDepositRead;
            string enterpriseCode           = SPTA.EnterpriseCode;
            string addUpSecCode             = SPTA.AddUpSecCode;
            int customerCode                = SPTA.CustomerCode;
            int depositSlipNo               = SPTA.DepositSlipNo;
            // �� 2007.10.11 980081 c
            //int acceptAnOrderNo             = SPTA.AcceptAnOrderNo;
            Int32 acptAnOdrStatus           = SPTA.AcptAnOdrStatus;
            string salesSlipNum             = SPTA.SalesSlipNum; 
            // �� 2007.10.11 980081 c

            // �� 20070124 18322 d MA.NS�p�ɕύX
            //DateTime depositCallMonthsStart = SPTA.DepositCallMonthsStart;
            //DateTime depositCallMonthsEnd   = SPTA.DepositCallMonthsEnd;
            // �� 20070124 18322 d

            int alwcDepositCall             = SPTA.AlwcDepositCall;

            depsitDataWork = null;
            depositAlwWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //SqlConnection sqlConnection = null;  //DEL 2008/06/27 M.Kubota �p�����[�^�Ɠ���
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //--- DEL 2008/06/27 M.Kubota --->>> �g���Ė����c
            //DepsitMainWork depsitmainWork = new DepsitMainWork();
            //DepositAlwWork depositalwWork = new DepositAlwWork();
            //depsitmainWork = null;
            //depositalwWork = null;
            //--- DEL 2008/06/27 M.Kubota ---<<<

            //��������0�ŏ�����
            retTotalCnt = 0;

            //�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
            int _readCnt = readCnt;			
            if (_readCnt > 0) _readCnt += 1;
            //�����R�[�h�����ŏ�����
            nextData = false;

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                // �� 20070124 18322 c MA.NS�p�ɕύX
                //sDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsStart);
                //eDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsEnd);

                sDate = SPTA.DepositCallMonthsStart;
                eDate = SPTA.DepositCallMonthsEnd;
                // �� 20070124 18322 c

            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }

            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();

            ArrayList alwk   = new ArrayList();   //�d���f�[�^�����p
            ArrayList alwk2  = new ArrayList();   //�d���f�[�^�����p�Q

            try
            {
                try
                {
                    # region ---- DEL 2008/06/27 M.Kubota ---
                    //// �� 20070406 18322 a DB�R�l�N�V�����̎擾���@��ύX
                    //if (sqlConnect == null)
                    //{
                    //    //�R�l�N�V����������擾�Ή�����������
                    //    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    //    if (connectionText == null || connectionText == "") return status;

                    //    //SQL������
                    //    sqlConnection = new SqlConnection(connectionText);
                    //    sqlConnection.Open();
                    //}
                    //else
                    //{
                    //    sqlConnection = sqlConnect;
                    //}
                    //// �� 20070406 18322 a

                    //// �� 20070406 18322 d DB�R�l�N�V�����̎擾���@��ύX
                    //////�R�l�N�V����������擾�Ή�����������
                    //////���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    ////SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    ////string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    ////if (connectionText == null || connectionText == "") return status;
                    //////�R�l�N�V����������擾�Ή�����������
                    //// �� 20070406 18322 d
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

                    // �� 2007.10.11 980081 c
                    //if (acceptAnOrderNo == 0)   //�󒍔ԍ��������Ă��Ȃ���΁A�����}�X�^�����Ƀf�[�^���o�B�����Ă���΁A�����}�X�^�����Ƀf�[�^���o
                    if (acptAnOdrStatus == 0 || salesSlipNum == "")   //�󒍃X�e�[�^�X�܂��͔���`�[�ԍ��������Ă��Ȃ���΁A�����}�X�^�����Ƀf�[�^���o�B�����Ă���΁A�����}�X�^�����Ƀf�[�^���o
                    // �� 2007.10.11 980081 c
                    {
                        //--- �󒍔ԍ��������Ă��Ȃ��ꍇ ----------//
                        // �� 20070406 18322 d DB�R�l�N�V�����̎擾���@��ύX
                        ////SQL������
                        //sqlConnection = new SqlConnection(connectionText);
                        //sqlConnection.Open();
                        // �� 20070406 18322 d

                        // �� 20070124 18322 c MA.NS�p�ɕύX
                        #region SF �����}�X�^�{���������}�X�^�����i�R�����g�A�E�g�j
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

                        // -- 2007.07.05�@SqlTransaction��null����ǉ�
                        if (sqlTransaction == null)
                            sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection);
                        else
                            sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection, sqlTransaction);
                        // �� 20070124 18322 c

                        //WHERE���̍쐬
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaDepositRead, logicalMode);

#if DEBUG
                        //--- ADD 2008/06/27 M.Kubota --->>>
                        Console.Clear();
                        Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
                        //--- ADD 2008/06/27 M.Kubota ---<<<
# endif

                        //����/����Ͻ� Read
                        // �� 20070406 18322 c
                        //sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.Default);
                        // �� 20070406 18322 c

                        int retCnt = 0;

                        while (myReader.Read())
                        {
                            //�߂�l�J�E���^�J�E���g
                            retCnt += 1;
                            if (readCnt > 0)
                            {
                                //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                                if (readCnt < retCnt)
                                {
                                    nextData = true;
                                    break;
                                }
                            }

                            //�����}�X�^
                            #region �l�Z�b�g
                            // �� 20070124 18322 c MA.NS�p�ɕύX
                            #region SF �����f�[�^������}�X�^���[�N�փR�s�[�i�S�ăR�����g�A�E�g�j
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

                            // �����f�[�^������}�X�^���[�N�փR�s�[
                            DepsitMainWork wkDepsitMainWork = new DepsitMainWork();
                            CopyToDepsitMainWorkFromSelectData(ref wkDepsitMainWork, myReader);
                            // �� 20070124 18322 c

                            int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                            int myIndex = alwk.IndexOf(myObjectOdd);
                            if (myIndex < 0)
                            {
                                alwk.Add(wkDepsitMainWork.DepositSlipNo);
                                al.Add(wkDepsitMainWork);
                            }
                            #endregion


                            //�����}�X�^
                            #region
                            // �� 20070124 18322 c MA.NS�p�ɕύX
                            #region SF �����f�[�^����������}�X�^���[�N�փR�s�[�i�S�ăR�����g�A�E�g�j
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

                            // �����f�[�^����������}�X�^���[�N�փR�s�[
                            DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                            CopyToDepsitAlwWorkFromSelectData(ref wkDepositAlwWork, myReader);
                            // �� 20070124 18322 c

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
                        //--- �󒍃X�e�[�^�X�Ɣ���`�[�ԍ��������Ă���ꍇ ----------//
                        // �� 20070406 18322 d DB�R�l�N�V�����̎擾���@��ύX
                        ////SQL������
                        //sqlConnection = new SqlConnection(connectionText);
                        //sqlConnection.Open();
                        // �� 20070406 18322 d

                        // �� 20070124 18322 c MA.NS�p�ɕύX
                        #region SF ���������}�X�^�{�����}�X�^�����i�R�����g�A�E�g�j
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

                        // -- 2007.07.05�@SqlTransaction��null����ǉ�
                        if (sqlTransaction == null)
                            sqlCommand = new SqlCommand(DEPOSITALW_BASE, sqlConnection);
                        else
                            sqlCommand = new SqlCommand(DEPOSITALW_BASE, sqlConnection, sqlTransaction);
                        // �� 20070124 18322 c

                        //WHERE���̍쐬
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaDepositRead, logicalMode);

#if DEBUG
                        //--- ADD 2008/06/27 M.Kubota --->>>
                        Console.Clear();
                        Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
                        //--- ADD 2008/06/27 M.Kubota ---<<<
# endif

                        //����/����Ͻ� Read
                        // �� 20070406 18322 c
                        //sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.Default);
                        // �� 20070406 18322 c

                        int retCnt = 0;

                        while (myReader.Read())
                        {
                            //�߂�l�J�E���^�J�E���g
                            retCnt += 1;
                            if (readCnt > 0)
                            {
                                //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
                                if (readCnt < retCnt)
                                {
                                    nextData = true;
                                    break;
                                }
                            }

                            //�����}�X�^
                            #region �l�Z�b�g
                            // �� 20070124 18322 c MA.NS�p�ɕύX
                            #region SF �����f�[�^������}�X�^���[�N�փR�s�[�i�S�ăR�����g�A�E�g�j
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

                            // �����f�[�^������}�X�^���[�N�փR�s�[
                            DepsitMainWork wkDepsitMainWork = new DepsitMainWork();
                            CopyToDepsitMainWorkFromSelectData(ref wkDepsitMainWork, myReader);
                            // �� 20070124 18322 c

                            int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                            int myIndex = alwk.IndexOf(myObjectOdd);
                            if (myIndex < 0)
                            {
                                alwk.Add(wkDepsitMainWork.DepositSlipNo);
                                //             al.Add(wkDepsitMainWork);
                            }
                            #endregion


                            //�����}�X�^
                            #region
                            // �� 20070124 18322 c MA.NS�p�ɕύX
                            #region SF �����f�[�^����������}�X�^���[�N�փR�s�[�i�S�ăR�����g�A�E�g�j
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

                            // �����f�[�^����������}�X�^���[�N�փR�s�[
                            DepositAlwWork wkDepositAlwWork = new DepositAlwWork();
                            CopyToDepsitAlwWorkFromSelectData(ref wkDepositAlwWork, myReader);
                            // �� 20070124 18322 c

                            // �� 20070124 18322 d �폜
                            //if (wkDepositAlwWork.AcceptAnOrderNo>0)
                            //{
                            //       //      al2.Add(wkDepositAlwWork);
                            //}
                            // �� 20070124 18322 d
                            #endregion

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }


                        //-------------------------------------------------------------------------------------------------------------//
                        //-- ���o�����f�[�^�́u�����`�[�ԍ��v�ōēx���� ------------------------------------------------------------------//
                        //-------------------------------------------------------------------------------------------------------------//
                        // �� 20070406 18322 SF(�S�ăR�����g�A�E�g)
                        #region �����E���������f�[�^�Č���
                        //int wk_DepositSlipNo = 0;
                        //for(int ii = 1 ; ii <= alwk.Count ; ii++)
                        //{
                        //    wk_DepositSlipNo = Convert.ToInt32( alwk[ii-1] );
                        //
                        //    searchParaDepositRead.DepositSlipNo   = wk_DepositSlipNo;  //�����`�[�ԍ��Z�b�g
                        //    
                        //    searchParaDepositRead.AcceptAnOrderNo = 0;                 //�󒍔ԍ��N���A
                        //
                        //    //SQL������
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
                        //    //WHERE���̍쐬
                        //    sqlCommand.CommandText += MakeWhereString(ref sqlCommand , searchParaDepositRead , logicalMode);
                        //
                        //    //����/����Ͻ� Read
                        //    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        //
                        //    while(sqlDataReader.Read())
                        //    {
                        //        //�����}�X�^
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
                        //        //�����}�X�^
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
                        // �� 20070406 18322 d

                        // �� 20070406 18322 a

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region �����E���������f�[�^�Č���
                        int wk_DepositSlipNo = 0;
                        for (int ii = 1; ii <= alwk.Count; ii++)
                        {
                            wk_DepositSlipNo = Convert.ToInt32(alwk[ii - 1]);

                            searchParaDepositRead.DepositSlipNo = wk_DepositSlipNo;  //�����`�[�ԍ��Z�b�g

                            // �� 2007.10.11 980081 d
                            //searchParaDepositRead.AcceptAnOrderNo = 0;                 //�󒍔ԍ��N���A
                            // �� 2007.10.11 980081 d

                            // -- 2007.07.05�@SqlTransaction��null����ǉ�
                            if (sqlTransaction == null)
                                sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection);
                            else
                                sqlCommand = new SqlCommand(DEPSITMAIN_BASE, sqlConnection, sqlTransaction);

                            //WHERE���̍쐬
                            sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaDepositRead, logicalMode);

                            //����/����Ͻ� Read
                            myReader = sqlCommand.ExecuteReader(CommandBehavior.Default);

                            while (myReader.Read())
                            {
                                // �����f�[�^������}�X�^���[�N�փR�s�[
                                DepsitMainWork wkDepsitMainWork = new DepsitMainWork();
                                CopyToDepsitMainWorkFromSelectData(ref wkDepsitMainWork, myReader);

                                int myObjectOdd = wkDepsitMainWork.DepositSlipNo;
                                int myIndex = alwk2.IndexOf(myObjectOdd);
                                if (myIndex < 0)
                                {
                                    alwk2.Add(wkDepsitMainWork.DepositSlipNo);
                                    al.Add(wkDepsitMainWork);
                                }

                                // �����f�[�^����������}�X�^���[�N�փR�s�[
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
                        // �� 20070406 18322 a
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

                    // �����}�X�^�f�[�^�ɕR�t���������׃f�[�^�Ǝ擾���A�o���ƌ������������f�[�^���쐬����
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
                    //���N���X�ɗ�O��n���ď������Ă��炤
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

                // �� 20070406 18322 c �p�����[�^�ύX�̑Ή�
                //sqlConnection.Close();
                
                //if (sqlConnect == null)
                //{
                //    sqlConnection.Close();
                //}
                // �� 20070406 18322 c
                
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

        // �� 20070124 18322 a MA.NS�p�ɕύX
        /// <summary>
        /// SQL�f�[�^���[�_�[�������}�X�^���[�N
        /// </summary>
        /// <param name="depsitMainWork">�����}�X�^���[�N</param>
        /// <param name="sqlDataReader">SQL�f�[�^���[�_�[</param>
        /// <returns>�Ȃ�</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e������}�X�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>              (SFUKK01362R��ReadDepsitMainWorkRec�֐��̌����f�[�^�̎擾���@���Q�l)</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        private void CopyToDepsitMainWorkFromSelectData(ref DepsitMainWork depsitMainWork, SqlDataReader sqlDataReader)
        {
            #region �����C�A�E�g(�R�����g�A�E�g)
            //--- DEL 2008/06/27 M.Kubota --->>>
            // �� 2007.10.11 980081 c
            #region �����C�A�E�g(�R�����g�A�E�g)
            //// �쐬����
            //depsitDataWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DM_CREATEDATETIMERF"));
            //// �X�V����
            //depsitDataWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATEDATETIMERF"));
            //// ��ƃR�[�h
            //depsitDataWork.EnterpriseCode        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_ENTERPRISECODERF"));
            //// GUID
            //depsitDataWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(sqlDataReader,sqlDataReader.GetOrdinal("DM_FILEHEADERGUIDRF"));
            //// �X�V�]�ƈ��R�[�h
            //depsitDataWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDEMPLOYEECODERF"));
            //// �X�V�A�Z���u��ID1
            //depsitDataWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID1RF"));
            //// �X�V�A�Z���u��ID2
            //depsitDataWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDASSEMBLYID2RF"));
            //// �_���폜�敪
            //depsitDataWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_LOGICALDELETECODERF"));
            //// �����ԍ��敪
            //depsitDataWork.DepositDebitNoteCd    = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDEBITNOTECDRF"));
            //// �����`�[�ԍ�
            //depsitDataWork.DepositSlipNo         = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITSLIPNORF"));
            //// �󒍔ԍ�
            //depsitDataWork.AcceptAnOrderNo       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_ACCEPTANORDERNORF"));
            //// �T�[�r�X�`�[�敪
            //depsitDataWork.ServiceSlipCd         = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_SERVICESLIPCDRF"));
            //// �������͋��_�R�[�h
            //depsitDataWork.InputDepositSecCd     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_INPUTDEPOSITSECCDRF"));
            //// �v�㋒�_�R�[�h
            //depsitDataWork.AddUpSecCode          = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPSECCODERF"));
            //// �X�V���_�R�[�h
            //depsitDataWork.UpdateSecCd           = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_UPDATESECCDRF"));
            //// �������t
            //depsitDataWork.DepositDate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITDATERF"));
            //// �v����t
            //depsitDataWork.AddUpADate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_ADDUPADATERF"));
            //// ��������R�[�h
            //depsitDataWork.DepositKindCode       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDCODERF"));
            //// �������햼��
            //depsitDataWork.DepositKindName       = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDNAMERF"));
            //// ��������敪
            //depsitDataWork.DepositKindDivCd      = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITKINDDIVCDRF"));
            //// �����v
            //depsitDataWork.DepositTotal          = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITTOTALRF"));
            //// �������z
            //depsitDataWork.Deposit               = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITRF"));
            //// �萔�������z
            //depsitDataWork.FeeDeposit            = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_FEEDEPOSITRF"));
            //// �l�������z
            //depsitDataWork.DiscountDeposit       = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DISCOUNTDEPOSITRF"));
            //// ���x�[�g�����z
            //depsitDataWork.RebateDeposit         = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_REBATEDEPOSITRF"));
            //// ���������敪
            //depsitDataWork.AutoDepositCd         = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_AUTODEPOSITCDRF"));
            //// �a����敪
            //depsitDataWork.DepositCd             = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITCDRF"));
            //// �N���W�b�g�^���[���敪
            //depsitDataWork.CreditOrLoanCd        = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITORLOANCDRF"));
            //// �N���W�b�g��ЃR�[�h
            //depsitDataWork.CreditCompanyCode     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_CREDITCOMPANYCODERF"));
            //// ��`�U�o��
            //depsitDataWork.DraftDrawingDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTDRAWINGDATERF"));
            //// ��`�x������
            //depsitDataWork.DraftPayTimeLimit     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_DRAFTPAYTIMELIMITRF"));
            //// ���������z
            //depsitDataWork.DepositAllowance      = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALLOWANCERF"));
            //// ���������c��
            //depsitDataWork.DepositAlwcBlnce      = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITALWCBLNCERF"));
            //// �ԍ������A���ԍ�
            //depsitDataWork.DebitNoteLinkDepoNo   = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEBITNOTELINKDEPONORF"));
            //// �ŏI�������݌v���
            //depsitDataWork.LastReconcileAddUpDt  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DM_LASTRECONCILEADDUPDTRF"));
            //// �����S���҃R�[�h
            //depsitDataWork.DepositAgentCode      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTCODERF"));
            //// �����S���Җ���
            //depsitDataWork.DepositAgentNm        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_DEPOSITAGENTNMRF"));
            //// ���Ӑ�R�[�h
            //depsitDataWork.CustomerCode          = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERCODERF"));
            //// ���Ӑ於��
            //depsitDataWork.CustomerName          = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERNAMERF"));
            //// ���Ӑ於��2
            //depsitDataWork.CustomerName2         = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DM_CUSTOMERNAME2RF"));
            //// �`�[�E�v
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
            // �� 2007.12.10 980081 c
            //depsitDataWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DM_EDITAKEINDATERF"));
            //depsitDataWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DM_EDITAKEINDATERF"));
            // �� 2007.12.10 980081 c
            // �� 2007.10.11 980081 c
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
        /// SQL�f�[�^���[�_�[�����������}�X�^���[�N
        /// </summary>
        /// <param name="depositAlwWork">���������}�X�^���[�N</param>
        /// <param name="sqlDataReader">SQL�f�[�^���[�_�[</param>
        /// <returns>�Ȃ�</returns>
        /// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e������}�X�^���[�N�ɃR�s�[���܂��B</br>
        /// <br>              (SFUKK01362R��ReadDepositAlwWorkRec�֐��̌����f�[�^�̎擾���@���Q�l)</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        private void CopyToDepsitAlwWorkFromSelectData(ref DepositAlwWork depositAlwWork, SqlDataReader sqlDataReader)
        {
            # region �����C�A�E�g(�R�����g�A�E�g)
            //--- DEL 2008/06/27 M.Kubota --->>> 
            // �� 2007.10.11 980081 c
            #region �����C�A�E�g(�R�����g�A�E�g)
            //// �쐬����
            //depositAlwWork.CreateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DA_CREATEDATETIMERF"));
            //// �X�V����
            //depositAlwWork.UpdateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDATEDATETIMERF"));
            //// ��ƃR�[�h
            //depositAlwWork.EnterpriseCode      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_ENTERPRISECODERF"));
            //// GUID
            //depositAlwWork.FileHeaderGuid      = SqlDataMediator.SqlGetGuid(sqlDataReader,sqlDataReader.GetOrdinal("DA_FILEHEADERGUIDRF"));
            //// �X�V�]�ƈ��R�[�h
            //depositAlwWork.UpdEmployeeCode     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDEMPLOYEECODERF"));
            //// �X�V�A�Z���u��ID1
            //depositAlwWork.UpdAssemblyId1      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID1RF"));
            //// �X�V�A�Z���u��ID2
            //depositAlwWork.UpdAssemblyId2      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_UPDASSEMBLYID2RF"));
            //// �_���폜�敪
            //depositAlwWork.LogicalDeleteCode   = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_LOGICALDELETECODERF"));
            //// �������͋��_�R�[�h
            //depositAlwWork.InputDepositSecCd   = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_INPUTDEPOSITSECCDRF"));
            //// �v�㋒�_�R�[�h
            //depositAlwWork.AddUpSecCode        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_ADDUPSECCODERF"));
            //// �����ݓ�
            //depositAlwWork.ReconcileDate       = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEDATERF"));
            //// �����݌v���
            //depositAlwWork.ReconcileAddUpDate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader,sqlDataReader.GetOrdinal("DA_RECONCILEADDUPDATERF"));
            //// �����`�[�ԍ�
            //depositAlwWork.DepositSlipNo       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITSLIPNORF"));
            //// ��������R�[�h
            //depositAlwWork.DepositKindCode     = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDCODERF"));
            //// �������햼��
            //depositAlwWork.DepositKindName     = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITKINDNAMERF"));
            //// ���������z
            //depositAlwWork.DepositAllowance    = SqlDataMediator.SqlGetInt64(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITALLOWANCERF"));
            //// �����S���҃R�[�h
            //depositAlwWork.DepositAgentCode    = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITAGENTCODERF"));
            //// �����S���Җ���
            //depositAlwWork.DepositAgentNm      = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITAGENTNMRF"));
            //// ���Ӑ�R�[�h
            //depositAlwWork.CustomerCode        = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERCODERF"));
            //// ���Ӑ於��
            //depositAlwWork.CustomerName        = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERNAMERF"));
            //// ���Ӑ於��2
            //depositAlwWork.CustomerName2       = SqlDataMediator.SqlGetString(sqlDataReader,sqlDataReader.GetOrdinal("DA_CUSTOMERNAME2RF"));
            //// �󒍔ԍ�
            //depositAlwWork.AcceptAnOrderNo     = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_ACCEPTANORDERNORF"));
            //// �T�[�r�X�`�[�敪
            //depositAlwWork.ServiceSlipCd       = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_SERVICESLIPCDRF"));
            //// �ԓ`���E�敪
            //depositAlwWork.DebitNoteOffSetCd   = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEBITNOTEOFFSETCDRF"));
            //// �a����敪
            //depositAlwWork.DepositCd           = SqlDataMediator.SqlGetInt32(sqlDataReader,sqlDataReader.GetOrdinal("DA_DEPOSITCDRF"));
            //// �N���W�b�g�^���[���敪
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
            // �� 2007.10.11 980081 c
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
        // �� 20070124 18322 a

        # region  Where���쐬

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="searchParaDepositRead">�����p�����[�^�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchParaDepositRead searchParaDepositRead, ConstantManagement.LogicalMode logicalMode)
        {
            SearchParaDepositRead SPTA = (SearchParaDepositRead)searchParaDepositRead;
            string enterpriseCode      = SPTA.EnterpriseCode;
            string addUpSecCode        = SPTA.AddUpSecCode;
            int customerCode           = SPTA.CustomerCode;
            // �� 2007.10.11 980081 c
            //int acceptAnOrderNo        = SPTA.AcceptAnOrderNo;
            int claimCode              = SPTA.ClaimCode;
            int acptAnOdrStatus        = SPTA.AcptAnOdrStatus;
            string salesSlipNum        = SPTA.SalesSlipNum;
            // �� 2007.10.11 980081 c
            int depositSlipNo          = SPTA.DepositSlipNo;
            int alwcDepositCall        = SPTA.AlwcDepositCall;
            int autoDepositCd          = SPTA.AutoDepositCd;
            // �� 2007.10.11 980081 d
            //int serviceSlipCd          = SPTA.ServiceSlipCd;
            // �� 2007.10.11 980081 d

            // �� 20070124 18322 c MA.NS�p�ɕύX
            //DateTime depositCallMonthsStart = SPTA.DepositCallMonthsStart;
            //DateTime depositCallMonthsEnd   = SPTA.DepositCallMonthsEnd;
            // �� 20070124 18322 c

            int sDate  = 0;
            int eDate  = 0;
            try
            {
                // �� 20070124 18322 c MA.NS�p�ɕύX
                //sDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsStart);
                //eDate  = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMMDD",depositCallMonthsEnd);

                sDate  = SPTA.DepositCallMonthsStart;
                eDate  = SPTA.DepositCallMonthsEnd;
                // �� 20070124 18322 c
            }
            catch(Exception)
            {
                sDate = 0;
                eDate = 0;
            }


            string retstring = " WHERE ";

            //��ƃR�[�h
            retstring += " DM.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(enterpriseCode);

            //�_���폜�敪
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

            #region SF�̕��ŕύX�i�S�ăR�����g�A�E�g�j
//            //�z��ŕ����w�肳���
//            //���_�R�[�h
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

            //�v�㋒�_�R�[�h
            if((addUpSecCode != null)&&(addUpSecCode != ""))
            {
                retstring += " AND DM.ADDUPSECCODERF=@FINDADDUPSECCODE ";
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(addUpSecCode);
            }

            //���Ӑ�R�[�h
            if(customerCode > 0)
            {
                retstring += " AND DM.CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
            }
            // �� 2007.10.11 980081 a
            //������R�[�h
            if (claimCode > 0)
            {
                retstring += " AND DM.CLAIMCODERF=@FINDCLAIMCODE ";
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(claimCode);
            }
            // �� 2007.10.11 980081 a

            // �� 2007.10.11 980081 c
            //if (acceptAnOrderNo == 0)      //�󒍔ԍ��������Ă��Ȃ���΁A�����`�[�ԍ��� Where���쐬
            if (acptAnOdrStatus == 0 || salesSlipNum == "")      //�󒍃X�e�[�^�X�܂��͔���`�[�ԍ��������Ă��Ȃ���΁A�����`�[�ԍ��� Where���쐬
            // �� 2007.10.11 980081 c
            {
               //�����`�[�ԍ�
               if(depositSlipNo > 0)
               {
                   retstring += " AND DM.DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO ";
                   SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                   paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositSlipNo);
               }
            }
            else                         //�󒍃X�e�[�^�X�Ɣ���`�[�ԍ��������Ă���΁A�󒍃X�e�[�^�X�Ɣ���`�[�ԍ��� Where���쐬
            {
                // �� 2007.10.11 980081 c
                ////�󒍔ԍ�
                //retstring += " AND DA.ACCEPTANORDERNORF=@FINDACCEPTANORDERNO ";
                //SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                //paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptAnOrderNo);
                //�󒍃X�e�[�^�X�Ɣ���`�[�ԍ�
                retstring += " AND DA.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ";
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acptAnOdrStatus);
                retstring += " AND DA.SALESSLIPNUMRF=@FINDSALESSLIPNUM ";
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipNum);
                // �� 2007.10.11 980081 c
            }

            // �� 20070514 18322 a MA.NS�p�ɒǉ�
            if (autoDepositCd >= 0)
            {
                // ���������敪
                retstring += " AND DM.AUTODEPOSITCDRF=@FINDAUTODEPOSITCD ";
                SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@FINDAUTODEPOSITCD", SqlDbType.Int);
                paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(autoDepositCd);
            }

            // �� 2007.10.11 980081 d
            //if (serviceSlipCd >= 0)
            //{
            //    // �T�[�r�X�`�[�敪
            //    retstring += " AND DM.SERVICESLIPCDRF=@FINDSERVICESLIPCD ";
            //    SqlParameter paraServiceSlipCd = sqlCommand.Parameters.Add("@FINDSERVICESLIPCD", SqlDbType.Int);
            //    paraServiceSlipCd.Value = SqlDataMediator.SqlSetInt32(serviceSlipCd);
            //}
            // �� 2007.10.11 980081 d
            // �� 20070514 18322 a

            //������(�J�n)
            if(sDate > 0)
            {
                // --- ADD 2010/12/20 ---------->>>>>
                //retstring += " AND DM.DEPOSITDATERF>=@FINDSTARTDATE ";
                retstring += " AND DM.ADDUPADATERF>=@FINDSTARTDATE ";  // �v����t���g�p����
                // --- ADD 2010/12/20  ----------<<<<<
                SqlParameter paraStartDate = sqlCommand.Parameters.Add("@FINDSTARTDATE", SqlDbType.Int);
                paraStartDate.Value = SqlDataMediator.SqlSetInt32(sDate);
            }

            //������(�I��)
            if(eDate > 0)
            {
                // --- ADD 2010/12/20 ---------->>>>>
                //retstring += " AND DM.DEPOSITDATERF<=@FINDENDDATE ";
                retstring += " AND DM.ADDUPADATERF<=@FINDENDDATE ";�@// �v����t���g�p����
                // --- ADD 2010/12/20  ----------<<<<<
                SqlParameter paraEndDate = sqlCommand.Parameters.Add("@FINDENDDATE", SqlDbType.Int);
                paraEndDate.Value = SqlDataMediator.SqlSetInt32(eDate);
            }

            //�����ϓ����`�[�ďo�敪
            if(alwcDepositCall != 0)   //0 �łȂ��ꍇ�́A�����ϕ�(���������c��=0)�͒��o�ΏۊO
            {
                retstring += " AND DM.DEPOSITALWCBLNCERF <> 0 ";
            }

            #region SF�̕��ŕύX�i�S�ăR�����g�A�E�g�j
//            //�\�[�g����
//            if (dmBirthdayCndtnWork.SortingOrder==0)            //�a������
//            {
//                retstring += " ORDER BY FAM.BIRTHDAYRF ";
//            }
//            if (dmBirthdayCndtnWork.SortingOrder==1)            //�����L�O����
//            {
//                retstring += " ORDER BY FAM.WEDDINGANNIVERSARYRF ";
//            }
//            if (dmBirthdayCndtnWork.SortingOrder==2)            //�N�
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
                    # region [SQL��]
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

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    ArrayList depsitDtlList = new ArrayList();

                    foreach (DepsitMainWork depsitMainWrk in depsitMainList)
                    {
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWrk.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.AcptAnOdrStatus);

                        if (depsitMainWrk.DepositDebitNoteCd != 1)
                        {
                            // 0:�� 2:�����̏ꍇ
                            findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.DepositSlipNo);
                        }
                        else
                        {
                            // 1:�� �̏ꍇ
                            findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.DebitNoteLinkDepoNo);
                        }
                        
                        // �����}�X�^�ɕR�t���������׃f�[�^���擾
                        sqlDataReader = sqlCommand.ExecuteReader();

                        depsitDtlList.Clear();

                        while (sqlDataReader.Read())
                        {
                            DepsitDtlWork dtlWork = this.CopyToDepsitDtlWorkFromSelectData(sqlDataReader);

                            if (depsitMainWrk.DepositDebitNoteCd == 1)
                            {
                                // 1:�� �̏ꍇ
                                dtlWork.DepositSlipNo = depsitMainWrk.DepositSlipNo;
                                dtlWork.Deposit = dtlWork.Deposit * -1;
                            }

                            depsitDtlList.Add(dtlWork);
                        }

                        sqlDataReader.Close();
                        sqlDataReader.Dispose();

                        // �������׃f�[�^���P���ȏ㑶�݂��Ă����ꍇ
                        DepsitDtlWork[] DepsitDtlArray = null;

                        if (ListUtils.IsNotEmpty(depsitDtlList))
                        {
                            DepsitDtlArray = (DepsitDtlWork[])depsitDtlList.ToArray(typeof(DepsitDtlWork));
                        }

                        // �����}�X�^�f�[�^�Ɠ������׃f�[�^����������
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

