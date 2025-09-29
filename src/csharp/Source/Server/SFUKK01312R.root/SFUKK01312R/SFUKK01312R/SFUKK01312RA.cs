using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;  //ADD 2008/07/10 M.Kubota

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ����KINGET���oDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����KINGET���o�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 18023 ����@����</br>
	/// <br>Date       : 2005.07.21</br>
	/// <br></br>
	/// <br>Update Note : 2006.04.21 ����@����</br>
	/// <br>			: �f�[�^�擾���ڂɓ��Ӑ�}�X�^��FAX�ԍ��i����j�AFAX�ԍ��i�Ζ���j�A�d�b�ԍ��i���̑��j�A</br>
	///	<br>			: ��A����敪��ǉ��B</br>
	/// <br></br>
	/// <br>Update Note : 2006.05.31 ����@����</br>
	/// <br>			: �����S�̐ݒ�ɑO����Z��敪���ǉ����ꂽ���Ƃɔ����ύX�BKINSET��CalcMode�v���p�e�B�ւ̐ݒ�ǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2006.08.21 ����@����</br>
	/// <br>				�E�]�ƈ����̂��]�ƈ��}�X�^���擾����悤�ɕύX�B</br>
	///	<br></br>
	/// <br>Update Note : 2006.08.22 ����@����</br>
	/// <br>				�E�e�[�u���Í����Ή��B</br>
	///	<br></br>
	/// <br>Update Note : 2006.08.25 ����@����</br>
	/// <br>				�E�]�ƈ��R�[�h�͈͂̃N�G��������쐬���C���B</br>
	///	<br></br>
	/// <br>Update Note : 2006.09.06 ����@����</br>
	/// <br>				�E���Ӑ敪�̓R�[�h�ɂ�钊�o��ǉ��B</br>
	///	<br></br>
	/// <br>Update Note : 2007.01.17 �ؑ� ����</br>
	/// <br>				�EMA.NS�p�ɕύX</br>
    ///	<br></br>
    /// <br>Update Note : 2007.03.27 �ؑ� ����</br>
    /// <br>				�E���Ӑ搿��(���|)���z�}�X�^�̍X�V�����������ōs��</br>
    /// <br>				  �悤�ɂȂ�A���z�}�X�^�̃��C�A�E�g���ύX���ꂽ���ߏC��</br>
    ///	<br></br>
    /// <br>Update Note : 2007.12.21 �R�c ���F</br>
    /// <br>				�E���ʊ�Ή�</br>
    /// <br>				�E�g�p����Ă��Ȃ��v���C�x�[�g���\�b�h��S�ăR�����g�A�E�g</br>
    ///	<br></br>
    /// <br>Update Note : 2008.04.25 �v�ۓc ��</br>
    /// <br>				�EPM.NS�Ή�</br>
    ///	<br></br>
    /// </remarks>
	[Serializable]
	//public class SeiKingetDB : RemoteDB, IRemoteDB, ISeiKingetDB           //DEL 2008/07/10 M.Kubota
    public class SeiKingetDB : RemoteWithAppLockDB, IRemoteDB, ISeiKingetDB  //ADD 2008/07/10 M.Kubota 
	{
		#region Constructor
		/// <summary>
		/// ����KINGET���oDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public SeiKingetDB()
		{
		}
		#endregion

		#region Private Class
		/// <summary>
		/// ����KINGET�f�[�^�i�[�N���X
		/// </summary>
		private class SeiKingetData
		{
			#region Constructor
			public SeiKingetData()
			{
			}
			#endregion

			#region Private Members
			/// <summary>����������擾�t���O</summary>
			private bool _getDmdSalesFlg = false;

			/// <summary>���������񃊃X�g</summary>
			private ArrayList _dmdSalesWorkList = null;

			/// <summary>������񃊃X�g</summary>
			private ArrayList _depsitMainWorkList = null;

			/// <summary>����p�c�������敪�R�[�h</summary>
			private Int32 _minusVarCstBlAdjstCd = -1;

			/// <summary>����p�c�������t���O</summary>
			private bool _adjustMinusVCst = false;
			
			// 2006.05.31 ADD START ����@����
			/// <summary>�O����Z��敪�R�[�h</summary>
			private Int32 _bfRmonCalcDivCd = 0;
			// 2006.05.31 ADD END ����@����

            // �� 20070417 18322 d ���߃X�P�W���[���E��������E�������o�́AMA.NS�ł͎g�p���Ȃ��̂ō폜
            //                    �i����͐������������̃����[�g���s���j
			///// <summary>���X�P�W���[�����oDB�����[�g�I�u�W�F�N�g</summary>
			//private CAddUpSMngGetInfDB _cAddUpSMngGetInfDB = null;		
            //
			///// <summary>�������㒊�oDB�����[�g�I�u�W�F�N�g</summary>
			//private KingetDmdSalesDB _dmdSalesDB = null;
            //
			///// <summary>�������oDB�����[�g�I�u�W�F�N�g</summary>
			//private KingetDepsitMainDB _depsitMainDB = null;
            // �� 20070417 18322 d
			#endregion

			#region Property
			/// <summary>���������񃊃X�g</summary>
			public ArrayList DmdSalesWorkList
			{
				get{return _dmdSalesWorkList;}
				set{_dmdSalesWorkList = value;}
			}

			/// <summary>������񃊃X�g</summary>
			public ArrayList DepsitMainWorkList
			{
				get{return _depsitMainWorkList;}
				set{_depsitMainWorkList = value;}
			}

			/// <summary>����������擾�t���O</summary>
			public bool GetDmdSalesFlg
			{
				get{return _getDmdSalesFlg;}
				set{_getDmdSalesFlg = value;}
			}

			/// <summary>����p�c�������敪�R�[�h</summary>
			public Int32 MinusVarCstBlAdjstCd
			{
				get{return _minusVarCstBlAdjstCd;}
				set{_minusVarCstBlAdjstCd = value;}
			}

			/// <summary>����p�c�������t���O</summary>
			public bool AdjustMinusVCst
			{
				get{return _adjustMinusVCst;}
				set{_adjustMinusVCst = value;}
			}

			// 2006.05.31 ADD START ����@����
			/// <summary>�O����Z��敪</summary>
			public Int32 BfRmonCalcDivCd
			{
				get{return _bfRmonCalcDivCd;}
				set{_bfRmonCalcDivCd = value;}
			}
			// 2006.05.31 ADD END ����@����

            // �� 20070417 18322 d ���߃X�P�W���[���E��������E�������o�́AMA.NS�ł͎g�p���Ȃ��̂ō폜
			///// <summary>���X�P�W���[�����oDB�����[�g�I�u�W�F�N�g</summary>
			//public CAddUpSMngGetInfDB CAddUpSMngGetInfDB
			//{
			//	get{return _cAddUpSMngGetInfDB;}
			//	set{_cAddUpSMngGetInfDB = value;}
			//}
            //
			///// <summary>�������㒊�oDB�����[�g�I�u�W�F�N�g</summary>
			//public KingetDmdSalesDB DmdSalesDB
			//{
			//	get{return _dmdSalesDB;}
			//	set{_dmdSalesDB = value;}
			//}
            //
			///// <summary>�������oDB�����[�g�I�u�W�F�N�g</summary>
			//public KingetDepsitMainDB DepsitMainDB
			//{
			//	get{return _depsitMainDB;}
			//	set{_depsitMainDB = value;}
			//}
            // �� 20070417 18322 d
			#endregion
		}
		#endregion
		
		#region Private Const
		/// <summary>�S���_�R�[�h</summary>
		private const string ALLSECCODE = "000000";

		/// <summary>�]�ƈ��敪�i�W���S���j</summary>
		private const int EMPLOYEEKIND_BILLCOLLECTER = 1;

        # region --- 2008/04/25 M.Kubota ---
        # if false
        // �� 20070117 18322 c MA.NS�p�ɕύX
        #region SF���Ӑ搿�����z�}�X�^SELECT������(�R�����g�A�E�g)
        ///// <summary>���Ӑ搿�����z�}�X�^SELECT������</summary>
        //private const string SELECT_CUSTDMDPRC = "SELECT"
		//	+" CUSTDMDPRCRF.FILEHEADERGUIDRF,CUSTDMDPRCRF.ENTERPRISECODERF,CUSTDMDPRCRF.ADDUPSECCODERF,CUSTDMDPRCRF.CUSTOMERCODERF"
		//	+",CUSTDMDPRCRF.ADDUPDATERF,CUSTDMDPRCRF.ADDUPYEARMONTHRF,CUSTDMDPRCRF.TLEDMDSLIPLGCTRF,CUSTDMDPRCRF.TLEDMDSLIPGECTRF"
		//	+",CUSTDMDPRCRF.TLEDMDDEBITNOTELGCTRF,CUSTDMDPRCRF.TLEDMDDEBITNOTEGECTRF,CUSTDMDPRCRF.TLEDMDSLIPLGCNTRF,CUSTDMDPRCRF.TLEDMDSLIPGECNTRF"
		//	+",CUSTDMDPRCRF.TLEDMDDEBITNOTELGCNTRF,CUSTDMDPRCRF.TLEDMDDEBITNOTEGECNTRF,CUSTDMDPRCRF.ACPODRTTLSALESDMDRF,CUSTDMDPRCRF.ACPODRDISCTTLDMDRF"
		//	+",CUSTDMDPRCRF.ACPODRTTLCONSTAXDMDRF,CUSTDMDPRCRF.DMDVARCSTRF,CUSTDMDPRCRF.TTLTAXTINDMDVARCSTRF,CUSTDMDPRCRF.TTLTAXFREEDMDVARCSTRF"
		//	+",CUSTDMDPRCRF.VARCST1TOTALDEMANDRF,CUSTDMDPRCRF.VARCST2TOTALDEMANDRF,CUSTDMDPRCRF.VARCST3TOTALDEMANDRF,CUSTDMDPRCRF.VARCST4TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST5TOTALDEMANDRF,CUSTDMDPRCRF.VARCST6TOTALDEMANDRF,CUSTDMDPRCRF.VARCST7TOTALDEMANDRF,CUSTDMDPRCRF.VARCST8TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST9TOTALDEMANDRF,CUSTDMDPRCRF.VARCST10TOTALDEMANDRF,CUSTDMDPRCRF.VARCST11TOTALDEMANDRF,CUSTDMDPRCRF.VARCST12TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST13TOTALDEMANDRF,CUSTDMDPRCRF.VARCST14TOTALDEMANDRF,CUSTDMDPRCRF.VARCST15TOTALDEMANDRF,CUSTDMDPRCRF.VARCST16TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST17TOTALDEMANDRF,CUSTDMDPRCRF.VARCST18TOTALDEMANDRF,CUSTDMDPRCRF.VARCST19TOTALDEMANDRF,CUSTDMDPRCRF.VARCST20TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.TTLDMDVARCSTCONSTAXRF,CUSTDMDPRCRF.ACPODRTTLLMBLDMDRF,CUSTDMDPRCRF.TTLLMVARCSTDMDBLNCERF,CUSTDMDPRCRF.BFCALTTLAODRDEPODMDRF"
		//	+",CUSTDMDPRCRF.BFCALTTLAODRDPDSDMDRF,CUSTDMDPRCRF.BFCALTTLAODRDPDMDRF,CUSTDMDPRCRF.BFCALTTLAODRDSDMDRF,CUSTDMDPRCRF.AFCALTTLAODRDEPODMDRF"
		//	+",CUSTDMDPRCRF.AFCALTTLVCSTDEPODMDRF,CUSTDMDPRCRF.AFCALTTLAODRDPDSDMDRF,CUSTDMDPRCRF.AFCALTTLVCSTDPDSDMDRF,CUSTDMDPRCRF.AFCALTTLAODRRMDMDRF"
		//	+",CUSTDMDPRCRF.AFCALTTLVCSTBFRMDMDRF,CUSTDMDPRCRF.AFCALTTLAODRRMDSDMDRF,CUSTDMDPRCRF.AFCALTTLVCSTRMDSDMDRF,CUSTDMDPRCRF.AFCALTTLAODRBLCFDMDRF"
		//	+",CUSTDMDPRCRF.AFCALTTLVCSTBLCFDMDRF,CUSTDMDPRCRF.AFCALTTLAODRBLDMDRF,CUSTDMDPRCRF.AFCALTTLVCSTBLDMDRF,CUSTDMDPRCRF.AFCALDEMANDPRICERF"
		//	+",CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF,CUSTDMDPRCRF.TTL2TMBFVARCSTDMDBLRF,CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF,CUSTDMDPRCRF.TTL3TMBFVARCSTDMDBLRF"
		//	+",CUSTDMDPRCRF.ADDUPDATELASTRECFLGRF"
		//	#region 2006.08.22 DEL ����@����
		//	//+",CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF"
		//	//+",CUSTOMERRF.OUTPUTNAMECODERF,CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF"
		//	//+",CUSTOMERRF.ADDRESS2RF,CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF"
		//	//+",CUSTOMERRF.PORTABLETELNORF,CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	//// 2006.04.21 ADD START ����@����
		//	//+",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
		//	//// 2006.04.21 ADD END ����@����
		//	#endregion
		//	// 2006.08.22 ADD START ����@����
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS NAME2RF"
		//	+",CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF,CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF, CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF"
		//	+",CUSTOMERRF.MAINCONTACTCODERF,CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	// 2006.08.22 ADD END ����@����
		//	#region 2006.08.21 DEL ����@����
		//	//+",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.CUSTOMERAGENTNMRF,CUSTOMERRF.BILLCOLLECTERCDRF,CUSTOMERRF.BILLCOLLECTERNMRF"
		//	//+" FROM CUSTDMDPRCRF"
		//	//+" LEFT OUTER JOIN CUSTOMERRF ON CUSTOMERRF.ENTERPRISECODERF=CUSTDMDPRCRF.ENTERPRISECODERF AND CUSTOMERRF.CUSTOMERCODERF=CUSTDMDPRCRF.CUSTOMERCODERF";
		//	#endregion
		//	// 2006.08.21 ADD START ����@����
		//	// 2006.09.06 ADD START ����@����
		//	+",CUSTOMERRF.CUSTANALYSCODE1RF,CUSTOMERRF.CUSTANALYSCODE2RF,CUSTOMERRF.CUSTANALYSCODE3RF"
		//	+",CUSTOMERRF.CUSTANALYSCODE4RF,CUSTOMERRF.CUSTANALYSCODE5RF,CUSTOMERRF.CUSTANALYSCODE6RF"
		//	// 2006.09.06 ADD END ����@����
		//	+",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.BILLCOLLECTERCDRF"
		//	+",EMP_CUSTOMERAGENT.NAMERF AS CUSTOMERAGENTNMRF,EMP_BILLCOLLECTER.NAMERF AS BILLCOLLECTERNMRF"
		//	+" FROM CUSTDMDPRCRF"
		//	+" LEFT OUTER JOIN CUSTOMERRF ON CUSTOMERRF.ENTERPRISECODERF=CUSTDMDPRCRF.ENTERPRISECODERF AND CUSTOMERRF.CUSTOMERCODERF=CUSTDMDPRCRF.CUSTOMERCODERF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_CUSTOMERAGENT ON EMP_CUSTOMERAGENT.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_CUSTOMERAGENT.EMPLOYEECODERF=CUSTOMERRF.CUSTOMERAGENTCDRF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_BILLCOLLECTER ON EMP_BILLCOLLECTER.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_BILLCOLLECTER.EMPLOYEECODERF=CUSTOMERRF.BILLCOLLECTERCDRF";
        //    // 2006.08.21 ADD END ����@����
        #endregion

        // �� 2007.12.21 980081 d
        #region MA.NS ���Ӑ搿�����z�}�X�^SELECT������ ���g�p�̂��ߍ폜
        ///// <summary>���Ӑ搿�����z�}�X�^SELECT������</summary>
        //private const string SELECT_CUSTDMDPRC =
        //    "SELECT CUSTDMDPRCRF.FILEHEADERGUIDRF"          // ��ƃR�[�h
        //        + ",CUSTDMDPRCRF.ENTERPRISECODERF"          // GUID
        //        + ",CUSTDMDPRCRF.ADDUPSECCODERF"            // �v�㋒�_�R�[�h
        //        + ",CUSTDMDPRCRF.CUSTOMERCODERF"            // ���Ӑ�R�[�h
        //        + ",CUSTDMDPRCRF.CUSTOMERNAMERF"            // ���Ӑ於��
        //        + ",CUSTDMDPRCRF.CUSTOMERNAME2RF"           // ���Ӑ於��2
        //        + ",CUSTDMDPRCRF.ADDUPDATERF"               // �v��N����
        //        + ",CUSTDMDPRCRF.ADDUPYEARMONTHRF"          // �v��N��
        //        + ",CUSTDMDPRCRF.LASTTIMEDEMANDRF"          // �O�񐿋����z
        //        + ",CUSTDMDPRCRF.THISTIMEDMDNRMLRF"         // ����������z�i�ʏ�����j
        //        + ",CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"      // ����萔���z�i�ʏ�����j
        //        + ",CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"      // ����l���z�i�ʏ�����j
        //        + ",CUSTDMDPRCRF.THISTIMERBTDMDNRMLRF"      // ���񃊃x�[�g�z�i�ʏ�����j
        //        + ",CUSTDMDPRCRF.THISTIMEDMDDEPORF"         // ����������z�i�a����j
        //        + ",CUSTDMDPRCRF.THISTIMEFEEDMDDEPORF"      // ����萔���z�i�a����j
        //        + ",CUSTDMDPRCRF.THISTIMEDISDMDDEPORF"      // ����l���z�i�a����j
        //        + ",CUSTDMDPRCRF.THISTIMERBTDMDDEPORF"      // ���񃊃x�[�g�z�i�a����j
        //        + ",CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"       // ����J�z�c���i�����v�j
        //        + ",CUSTDMDPRCRF.THISTIMESALESRF"           // ���񔄏���z
        //        + ",CUSTDMDPRCRF.THISSALESTAXRF"            // ���񔄏�����
        //        + ",CUSTDMDPRCRF.TTLINCDTBTTAXEXCRF"        // �x���C���Z���e�B�u�z���v�i�Ŕ����j
        //        + ",CUSTDMDPRCRF.TTLINCDTBTTAXRF"           // �x���C���Z���e�B�u�z���v�i�Łj
        //        + ",CUSTDMDPRCRF.OFSTHISTIMESALESRF"        // ���E�㍡�񔄏���z
        //        + ",CUSTDMDPRCRF.OFSTHISSALESTAXRF"         // ���E�㍡�񔄏�����
        //        + ",CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF"       // ���E��O�őΏۊz
        //        + ",CUSTDMDPRCRF.ITDEDOFFSETINTAXRF"        // ���E����őΏۊz
        //        + ",CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF"      // ���E���ېőΏۊz
        //        + ",CUSTDMDPRCRF.OFFSETOUTTAXRF"            // ���E��O�ŏ����
        //        + ",CUSTDMDPRCRF.OFFSETINTAXRF"             // ���E����ŏ����
        //        + ",CUSTDMDPRCRF.ITDEDSALESOUTTAXRF"        // ����O�őΏۊz
        //        + ",CUSTDMDPRCRF.ITDEDSALESINTAXRF"         // ������őΏۊz
        //        + ",CUSTDMDPRCRF.ITDEDSALESTAXFREERF"       // �����ېőΏۊz
        //        + ",CUSTDMDPRCRF.SALESOUTTAXRF"             // ����O�Ŋz
        //        + ",CUSTDMDPRCRF.SALESINTAXRF"              // ������Ŋz
        //        + ",CUSTDMDPRCRF.ITDEDPAYMOUTTAXRF"         // �x���O�őΏۊz
        //        + ",CUSTDMDPRCRF.ITDEDPAYMINTAXRF"          // �x�����őΏۊz
        //        + ",CUSTDMDPRCRF.ITDEDPAYMTAXFREERF"        // �x����ېőΏۊz
        //        + ",CUSTDMDPRCRF.PAYMENTOUTTAXRF"           // �x���O�ŏ����
        //        + ",CUSTDMDPRCRF.PAYMENTINTAXRF"            // �x�����ŏ����
        //        + ",CUSTDMDPRCRF.CONSTAXLAYMETHODRF"        // ����œ]�ŕ���
        //        + ",CUSTDMDPRCRF.CONSTAXRATERF"             // ����ŗ�
        //        + ",CUSTDMDPRCRF.FRACTIONPROCCDRF"          // �[�������敪
        //        + ",CUSTDMDPRCRF.AFCALDEMANDPRICERF"        // �v�Z�㐿�����z
        //        + ",CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"     // ��2��O�c���i�����v�j
        //        + ",CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"     // ��3��O�c���i�����v�j
        //        + ",CUSTDMDPRCRF.CADDUPUPDEXECDATERF"       // �����X�V���s�N����
        //        + ",CUSTDMDPRCRF.DMDPROCNUMRF"              // ���������ʔ�
        //        + ",CUSTDMDPRCRF.STARTCADDUPUPDDATERF"      // �����X�V�J�n�N����
        //        + ",CUSTDMDPRCRF.LASTCADDUPUPDDATERF"       // �O������X�V�N����
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS NAMERF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS NAME2RF"
        //        + ",CUSTOMERRF.HONORIFICTITLERF"
        //        + ",CUSTOMERRF.KANARF"
        //        + ",CUSTOMERRF.OUTPUTNAMECODERF"
        //        + ",CUSTOMERRF.OUTPUTNAMERF"
        //        + ",CUSTOMERRF.CORPORATEDIVCODERF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF"
        //        + ",CUSTOMERRF.ADDRESS2RF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF"
        //        + ",CUSTOMERRF.MAINCONTACTCODERF"
        //        + ",CUSTOMERRF.TOTALDAYRF"
        //        + ",CUSTOMERRF.COLLECTMONEYNAMERF"
        //        + ",CUSTOMERRF.COLLECTMONEYDAYRF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE1RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE2RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE3RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE4RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE5RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE6RF"
        //        + ",CUSTOMERRF.CUSTOMERAGENTCDRF"
        //        + ",CUSTOMERRF.BILLCOLLECTERCDRF"
        //        + ",EMP_CUSTOMERAGENT.NAMERF AS CUSTOMERAGENTNMRF"
        //        + ",EMP_BILLCOLLECTER.NAMERF AS BILLCOLLECTERNMRF"
        //   + " FROM CUSTDMDPRCRF"
        //   + " LEFT OUTER JOIN CUSTOMERRF"
        //   + "              ON CUSTOMERRF.ENTERPRISECODERF=CUSTDMDPRCRF.ENTERPRISECODERF"
        //   + "             AND CUSTOMERRF.CUSTOMERCODERF=CUSTDMDPRCRF.CUSTOMERCODERF"
        //   + " LEFT OUTER JOIN EMPLOYEERF AS EMP_CUSTOMERAGENT"
        //   + "              ON EMP_CUSTOMERAGENT.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF"
        //   + "             AND EMP_CUSTOMERAGENT.EMPLOYEECODERF=CUSTOMERRF.CUSTOMERAGENTCDRF"
        //   + " LEFT OUTER JOIN EMPLOYEERF AS EMP_BILLCOLLECTER"
        //   + "              ON EMP_BILLCOLLECTER.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF"
        //   + "             AND EMP_BILLCOLLECTER.EMPLOYEECODERF=CUSTOMERRF.BILLCOLLECTERCDRF"
        //   ;
        // �� 2007.12.21 980081 d
        #endregion
        // �� 20070117 18322 c MA.NS�p�ɕύX

        // �� 2007.12.21 980081 c
        #region �����C�A�E�g(�R�����g�A�E�g)
        //// 2006.08.21 ADD START ����@����
        ///// <summary>���Ӑ�}�X�^SELECT������</summary>
		//private const string SELECT_CUSTOMER = "SELECT"
		//	#region 2006.08.22 DEL ����@����
		//	//+" CUSTOMERRF.CUSTOMERCODERF,CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF"
		//	//+",CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	//+",CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF,CUSTOMERRF.PORTABLETELNORF"
		//	//+",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
		//	#endregion
		//	// 2006.08.22 ADD START ����@����
		//	+" CUSTOMERRF.CUSTOMERCODERF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS NAME2RF"
		//	+",CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF,CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF, CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF"
		//	+",CUSTOMERRF.MAINCONTACTCODERF,CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	// 2006.08.22 ADD END ����@����
		//	// 2006.09.06 ADD START ����@����
		//	+",CUSTOMERRF.CUSTANALYSCODE1RF,CUSTOMERRF.CUSTANALYSCODE2RF,CUSTOMERRF.CUSTANALYSCODE3RF"
		//	+",CUSTOMERRF.CUSTANALYSCODE4RF,CUSTOMERRF.CUSTANALYSCODE5RF,CUSTOMERRF.CUSTANALYSCODE6RF"
		//	// 2006.09.06 ADD END ����@����
		//	+",CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	+",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.BILLCOLLECTERCDRF"
		//	+",EMP_CUSTOMERAGENT.NAMERF AS CUSTOMERAGENTNMRF,EMP_BILLCOLLECTER.NAMERF AS BILLCOLLECTERNMRF"
		//	+" FROM CUSTOMERRF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_CUSTOMERAGENT ON EMP_CUSTOMERAGENT.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_CUSTOMERAGENT.EMPLOYEECODERF=CUSTOMERRF.CUSTOMERAGENTCDRF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_BILLCOLLECTER ON EMP_BILLCOLLECTER.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_BILLCOLLECTER.EMPLOYEECODERF=CUSTOMERRF.BILLCOLLECTERCDRF";
		//// 2006.08.21 ADD END ����@����
        #endregion
        /// <summary>���Ӑ�}�X�^SELECT������</summary>
        //private const string SELECT_CUSTOMER = "SELECT "
        //                                     + "CUSTOMERRF.CLAIMCODERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF, "
        //                                     + "CUSTOMERRF.CUSTOMERCODERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS CUSTOMERNAMERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS CUSTOMERNAME2RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF, "
        //                                     + "CUSTOMERRF.HONORIFICTITLERF, "
        //                                     + "CUSTOMERRF.KANARF, "
        //                                     + "CUSTOMERRF.OUTPUTNAMECODERF, "
        //                                     + "CUSTOMERRF.OUTPUTNAMERF, "
        //                                     + "CUSTOMERRF.CORPORATEDIVCODERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF, "
        //                                     + "CUSTOMERRF.ADDRESS2RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF, "
        //                                     + "CUSTOMERRF.MAINCONTACTCODERF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE1RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE2RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE3RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE4RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE5RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE6RF, "
        //                                     + "CUSTOMERRF.TOTALDAYRF, "
        //                                     + "CUSTOMERRF.COLLECTMONEYCODERF, "
        //                                     + "CUSTOMERRF.COLLECTMONEYNAMERF, "
        //                                     + "CUSTOMERRF.COLLECTMONEYDAYRF, "
        //                                     + "CUSTOMERRF.CUSTOMERAGENTCDRF, "
        //                                     + "CUSTOMERRF.CUSTOMERAGENTNMRF, "
        //                                     + "CUSTOMERRF.BILLCOLLECTERCDRF, "
        //                                     + "CUSTOMERRF.BILLCOLLECTERNMRF, "
        //                                     + "CUSTOMERRF.OLDCUSTOMERAGENTCDRF, "
        //                                     + "CUSTOMERRF.OLDCUSTOMERAGENTNMRF, "
        //                                     + "CUSTOMERRF.CUSTAGENTCHGDATERF "
        //                                     + "FROM CUSTOMERRF ";
        // �� 2007.12.21 980081 c
        # endif
        # endregion
        #endregion

        #region Public Methods

        #region �������z���擾Read
        /// <summary>
		/// �������z���擾����(�������́E���Ӑ���)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
		/// <param name="enterpriceCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="readDate">�擾���t</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		public int Read(out object objKingetCustDmdPrcWork, string enterpriceCode, string addUpSecCode,
			int customerCode, int readDate)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			return this.ReadProc(out objKingetCustDmdPrcWork, enterpriceCode, addUpSecCode, customerCode, readDate, ref kingetData);
		}
		#endregion
		
		#region �������z���擾Search
		/// <summary>
		/// �������z���擾����[�ӂ̂�](�����ꗗ�\�E���v������)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="objSeiKingetParameter">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		public int Search(out object objKingetCustDmdPrcWorkList, object objSeiKingetParameter)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			SeiKingetParameter parameter = (SeiKingetParameter)objSeiKingetParameter;
			
			return this.SearchProc(out objKingetCustDmdPrcWorkList, parameter, ref kingetData);
		}
		#endregion
		
		#region �������z���擾�i�����j
		/// <summary>
		/// �������z���擾����[�Ӂ{����](���Ӑ挳��)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="objSeiKingetParameter">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		public int Search(out object objKingetCustDmdPrcWorkList, out object objDmdSalesWorkList,
			out object objDepsitMainWorkList, object objSeiKingetParameter)
		{
			objKingetCustDmdPrcWorkList = null;
			objDmdSalesWorkList = null;
			objDepsitMainWorkList = null;
			
			SeiKingetData kingetData = new SeiKingetData();
			kingetData.GetDmdSalesFlg = true;			// ����������擾�t���O
			kingetData.DmdSalesWorkList = new ArrayList();
			kingetData.DepsitMainWorkList = new ArrayList();
			
			SeiKingetParameter parameter = (SeiKingetParameter)objSeiKingetParameter;
			
			int status =  this.SearchProc(out objKingetCustDmdPrcWorkList, parameter, ref kingetData);
			if (status != 0) return status;
			
			objDmdSalesWorkList = kingetData.DmdSalesWorkList;
			objDepsitMainWorkList = kingetData.DepsitMainWorkList;
			
			return status;
		}
		#endregion
		
		#region �������z���擾�i�����ꊇ�j
		/// <summary>
		/// �������z���擾����(�����ꊇ���)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="objSeiKingetParameter">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		public int SearchMotoAll(out object objKingetCustDmdPrcWorkList, out object objDmdSalesWorkList,
			out object objDepsitMainWorkList, object objSeiKingetParameter)
		{
			objKingetCustDmdPrcWorkList = null;
			objDmdSalesWorkList = null;
			objDepsitMainWorkList = null;
			
			SeiKingetData kingetData = new SeiKingetData();
			kingetData.GetDmdSalesFlg = true;			// ����������擾�t���O
			kingetData.DmdSalesWorkList = new ArrayList();
			kingetData.DepsitMainWorkList = new ArrayList();
			
			SeiKingetParameter parameter = (SeiKingetParameter)objSeiKingetParameter;
			
			int status =  this.SearchMotoAllProc(out objKingetCustDmdPrcWorkList, parameter, ref kingetData);
			if (status != 0) return status;
			
			objDmdSalesWorkList = kingetData.DmdSalesWorkList;
			objDepsitMainWorkList = kingetData.DepsitMainWorkList;
			
			return status;
		}
		#endregion
		
		#region �������z���擾�i���ׁj
		/// <summary>
		/// �������z���׏��擾����(���א�����)
		/// </summary>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="objSeiKingetDetailParameterList">���׌����p�����[�^���X�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���׌����p�����[�^���X�g�̏����Ő�������f�[�^�Ɠ����f�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		public int SearchDetails(out object objDmdSalesWorkList, out object objDepsitMainWorkList,	string enterpriseCode,
			object objSeiKingetDetailParameterList)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			return this.SearchDetailsProc(out objDmdSalesWorkList, out objDepsitMainWorkList, enterpriseCode, objSeiKingetDetailParameterList, ref kingetData);
		}
		#endregion
		
		#region ���Ӑ搿�����v�c���`�F�b�N
		/// <summary>
		/// ���Ӑ搿�����v�c���`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>0:�������v�c�����O�~�������͎������, 1:�������v�c�����O�~</returns>
		/// <br>Note       : �w�蓾�Ӑ�R�[�h�̓��Ӑ搿�����z�}�X�^�̍ŏI���R�[�h�̐������v�c�����`�F�b�N���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		public int CheckDemandPrice(string enterpriseCode, int customerCode)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			return this.CheckDemandPriceProc(enterpriseCode, customerCode);
		}
		#endregion

		#endregion

		#region Private Methods

        // �� 20070417 18322 d MA.NS�p�ɏ��������������ߍ폜
        #region �������z���擾�����i�P���擾�j�i��蒼���ׁA�R�����g�A�E�g�j
		///// <summary>
		///// �������z���擾�����i�P���擾�j
		///// </summary>
		///// <param name="objKingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
		///// <param name="enterpriceCode">��ƃR�[�h</param>
		///// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		///// <param name="customerCode">���Ӑ�R�[�h</param>
		///// <param name="readDate">�擾�Ώۓ��t</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : ���Ӑ搿�����z�}�X�^DB���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>
		//private int ReadProc(out object objKingetCustDmdPrcWork, string enterpriceCode, string addUpSecCode, int customerCode, int readDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//
		//	objKingetCustDmdPrcWork = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList customerScheduleSortedList	= null;	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList addSecCodeSortedList			= null;	// �������z���i�[�p�\�[�g���X�g
		//
		//	try
		//	{
		//		// �R�l�N�V����������擾
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		// SQL�ڑ�
		//		SqlConnection sqlConnection = null;
		//		using (sqlConnection = new SqlConnection(connectionText))
		//		{
		//			SqlEncryptInfo sqlEncryptInfo = null;	// 2006.08.22 ADD ����@����
		//
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);	// 2006.08.22 ADD ����@����
		//
		//				KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
		//			
		//				// ���Ӑ���擾
		//				int st = this.ReadCustomer(ref kingetCustDmdPrcWork, sqlConnection, enterpriceCode, customerCode);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)return st;
		//			
		//				totalDayScheduleSortedList = new SortedList();	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//				customerScheduleSortedList = new SortedList();	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//			
		//				DateTime startScheduleDate	= DateTime.Today.AddYears(-10);
		//				DateTime endScheduleDate	= DateTime.Today;
		//				if (readDate != 0)
		//				{
		//					// ����0�̏ꍇ
		//					if ((readDate % 100) == 0)
		//					{
		//						readDate += kingetCustDmdPrcWork.TotalDay;
		//					}
		//					endScheduleDate = TDateTime.LongDateToDateTime("YYYYMMDD", readDate);
		//					endScheduleDate = endScheduleDate.AddMonths(1);
		//				}
		//
        //                // ���Ӑ�X�P�W���[���擾
		//				st = this.GetScheduleByCustomerCode(ref customerScheduleSortedList, enterpriceCode, kingetCustDmdPrcWork.CustomerCode, 0,
		//					startScheduleDate, endScheduleDate, ref kingetData);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)return st;
		//			    
		//				int addUpDate = 0;
		//			    
		//				RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = new RetAddUpDateItemTypeDInf();;
		//			    
		//				// �v����t�擾
		//				foreach (DictionaryEntry schedule in (SortedList)customerScheduleSortedList[kingetCustDmdPrcWork.CustomerCode])
		//				{
		//					if (readDate <= (int)schedule.Key)
		//					{
		//						addUpDate = (int)schedule.Key;
		//						retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)schedule.Value;
		//						break;
		//					}
        //                }
		//			
		//				SeiKingetParameter parameter = new SeiKingetParameter();
		//				parameter.EnterpriseCode = enterpriceCode;
		//				parameter.AddUpSecCodeList.Add(addUpSecCode);
		//				parameter.IsAllCorporateDivCode = true;
		//				parameter.StartCustomerCode	= customerCode;
		//				parameter.EndCustomerCode	= customerCode;
		//				parameter.StartAddUpDate	= TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
		//				parameter.EndAddUpDate		= TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
		//			
		//				// �������z���i�[�p�\�[�g���X�g
		//				addSecCodeSortedList = new SortedList();
		//			
		//				// ���Ӑ搿�����z�}�X�^�����i�P�j
		//				st = this.SelectCustDmdPrc1(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//				}
		//				else
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//				{
		//					// ���Ӑ搿�����z�}�X�^�����i�Q�j
		//					st = this.SelectCustDmdPrc2(ref addSecCodeSortedList, sqlConnection, parameter);
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
		//						// ���z�����Ӑ���
		//						st = this.CreateVirtualCustDmdPrc(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter, ref kingetData);
		//						if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//						{
		//							return st;
		//						}
		//					}
		//					else
		//						if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//					{
		//						// �c���O���R�[�h��ݒ�
		//						addSecCodeSortedList.Add(addUpSecCode, new SortedList());
		//						SortedList customerCodeList = (SortedList)addSecCodeSortedList[addUpSecCode];
		//						customerCodeList.Add(customerCode, new SortedList());
		//						SortedList addUpDateList = (SortedList)customerCodeList[customerCode];
		//					
		//						kingetCustDmdPrcWork.AddUpSecCode	= addUpSecCode;
		//						kingetCustDmdPrcWork.CustomerCode	= customerCode;
		//						kingetCustDmdPrcWork.AddUpDate		= retAddUpDateItemTypeDInf.CAddUpUpdDate;
        //                        // �� 20070117 18322 c MA.NS�p�ɕύX
		//						//kingetCustDmdPrcWork.AddUpYearMonth	= TDateTime.DateTimeToLongDate("YYYYMM", retAddUpDateItemTypeDInf.CAddUpUpdYearMonth);
		//
        //                        kingetCustDmdPrcWork.AddUpYearMonth = retAddUpDateItemTypeDInf.CAddUpUpdYearMonth;
        //                        // �� 20070117 18322 c
		//						kingetCustDmdPrcWork.StartDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//						kingetCustDmdPrcWork.EndDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//					
		//						addUpDateList.Add(addUpDate, kingetCustDmdPrcWork);
		//					}
		//					else
		//					{
		//						return st;
		//					}
		//				
		//				}
		//				else
		//				{
		//					return st;
		//				}
		//			
		//				// �������z���i�[�p�\�[�g���X�g��ArrayList������������׎擾
		//				ArrayList list;
		//				st = this.CopyToArrayListFromSortedList(out list, addSecCodeSortedList, totalDayScheduleSortedList, customerScheduleSortedList, parameter, sqlConnection, ref kingetData);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//			
		//				if (list.Count > 0)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			
		//				objKingetCustDmdPrcWork = (KingetCustDmdPrcWork)list[0];
		//			}
		//			finally
		//			{
		//				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);	// 2006.08.22 ADD ����@����
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//
		//		if (addSecCodeSortedList != null)
		//		{
		//			addSecCodeSortedList.Clear();
		//			addSecCodeSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 a MA.NS�p�ɍ쐬
        /// <summary>
		/// �������z���擾�����i�P���擾�j
		/// </summary>
		/// <param name="objKingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
		/// <param name="enterpriceCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="readDate">�擾�Ώۓ��t</param>
        /// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2007.04.17</br>
		private int ReadProc(out object        objKingetCustDmdPrcWork
                            ,    string        enterpriceCode
                            ,    string        addUpSecCode
                            ,    int           customerCode
                            ,    int           readDate
                            ,ref SeiKingetData kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			objKingetCustDmdPrcWork = null;
            
			try
			{
				// �R�l�N�V����������擾
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL�ڑ�
				SqlConnection sqlConnection = null;
				using (sqlConnection = new SqlConnection(connectionText))
				{
					//SqlEncryptInfo sqlEncryptInfo = null;  //DEL 2008/07/10 M.Kubota

					try
					{
						sqlConnection.Open();

						//sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);  //DEL 2008/07/10 M.Kubota

						KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
					
                        //========================
						// ���Ӑ���擾
                        //========================
						int st = this.ReadCustomer(ref kingetCustDmdPrcWork, sqlConnection, enterpriceCode, customerCode);
						if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return st;
                        }

                        //======================================================
                        // �������ߏ��擾
                        //======================================================
                        CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();

                        //------------------------
                        // �������ߓ��擾
                        //------------------------
                        //DmdCAddUpHisWork dmdCAddUpHisWork = new DmdCAddUpHisWork();
                        //dmdCAddUpHisWork.EnterpriseCode = enterpriceCode;
                        //dmdCAddUpHisWork.AddUpSecCode = addUpSecCode;
                        //dmdCAddUpHisWork.CustomerCode = customerCode;
                        //st = custDmdPrcDB.ReadHis(ref dmdCAddUpHisWork, ref sqlConnection);
                        //if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    // �������ߓ��擾���s
                        //    return st;
                        //}

                        //======================================================
                        // �����f�[�^�擾(�������������Ńf�[�^���쐬����)
                        //======================================================
                        CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();
                        string retMsg = "";

                        custDmdPrcWork.EnterpriseCode = enterpriceCode;
                        custDmdPrcWork.AddUpSecCode = addUpSecCode;
                        custDmdPrcWork.CustomerCode = customerCode;
                        custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(readDate);
                        //try
                        //{
                        //    DateTime _readDate = TDateTime.LongDateToDateTime(readDate);
                        //    if (DateTime.DaysInMonth(_readDate.Year, _readDate.Month) > kingetCustDmdPrcWork.TotalDay)
                        //    {
                        //        // �ڋq�̒��ߓ��������ȑO�̏ꍇ
                        //        custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                _readDate.Month * 100   +
                        //                                                                kingetCustDmdPrcWork.TotalDay);
                        //    }
                        //    else
                        //    {
                        //        // �ڋq�̒��ߓ��������ȍ~�̏ꍇ
                        //        custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                _readDate.Month * 100 +
                        //                                                                DateTime.DaysInMonth(_readDate.Year, _readDate.Month));
                        //    }

                        //    if (TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate) < readDate)
                        //    {
                        //        // �擾�Ώۓ��t�ȑO�ɒ��ߗ\���������ꍇ�͗���
                        //        _readDate = custDmdPrcWork.AddUpDate.AddMonths(1);
                        //        if (DateTime.DaysInMonth(_readDate.Year, _readDate.Month) > kingetCustDmdPrcWork.TotalDay)
                        //        {
                        //            // �ڋq�̒��ߓ��������ȑO�̏ꍇ
                        //            custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                    _readDate.Month * 100   +
                        //                                                                    kingetCustDmdPrcWork.TotalDay);
                        //        }
                        //        else
                        //        {
                        //            // �ڋq�̒��ߓ��������ȍ~�̏ꍇ
                        //            custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                    _readDate.Month * 100 +
                        //                                                                    DateTime.DaysInMonth(_readDate.Year, _readDate.Month));
                        //        }
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //    custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(TDateTime.GetLastDate(readDate));
                        //}

                        object paraObj = custDmdPrcWork;
                        st = custDmdPrcDB.ReadCustDmdPrc(ref paraObj, out retMsg);
                        if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �擾���s
                            return st;
                        }
                        custDmdPrcWork = paraObj as CustDmdPrcWork;

                        //==================================
                        // ���ߏ��E�����f�[�^�ݒ�
                        //==================================
                        this.SetKingetDmdPrcInfo(ref kingetCustDmdPrcWork, ref custDmdPrcWork);

						objKingetCustDmdPrcWork = kingetCustDmdPrcWork;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					finally
					{
                        //--- DEL 2008/07/10 M.Kubota --->>>
                        //if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                        //{
                        //    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //}
                        //--- DEL 2008/07/10 M.Kubota ---<<<
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // �� 20070417 18322 a

        // �� 20070417 18322 d ��蒼���ׁ̈A�폜
        #region �������z���擾�����i���Ӑ挳���E�����ꗗ�\�E���v�������j�i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// �������z���擾�����i���Ӑ挳���E�����ꗗ�\�E���v�������j
		///// </summary>
		///// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		/////					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>
		//private int SearchProc(out object objKingetCustDmdPrcWorkList, SeiKingetParameter parameter, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//
		//	objKingetCustDmdPrcWorkList = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList customerScheduleSortedList	= null;	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList addSecCodeSortedList			= null;	// �������z���i�[�p�\�[�g���X�g
		//
		//	try
		//	{
		//		// �R�l�N�V����������擾
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		// SQL�ڑ�
		//		SqlConnection sqlConnection = null;
		//		using (sqlConnection = new SqlConnection(connectionText))
		//		{
		//			SqlEncryptInfo sqlEncryptInfo = null;	// 2006.08.22 ADD ����@����
		//
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);	// 2006.08.22 ADD ����@����
		//
		//				totalDayScheduleSortedList = new SortedList();	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//				customerScheduleSortedList = new SortedList();	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//		
		//				// �X�P�W���[���擾�p���t�쐬
		//				DateTime startScheduleDate;
		//				DateTime endScheduleDate;
		//				this.MakeGetScheduleDate(out startScheduleDate, out endScheduleDate, parameter);
		//		
		//				int st = 4;
		//		
		//				// ���Ӑ�P���w��̏ꍇ
		//				if ((parameter.StartCustomerCode != 0) && (parameter.StartCustomerCode == parameter.EndCustomerCode))
		//				{
		//					// ���Ӑ�X�P�W���[�����X�g�擾
		//					this.GetScheduleByCustomerCode(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode,
		//						0, startScheduleDate, endScheduleDate, ref kingetData);
		//				}
		//				else
		//				{
		//					// ���Ӑ�X�P�W���[�����X�g�擾
		//					this.GetScheduleByCustomerCodeRange(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode,
		//						parameter.EndCustomerCode, startScheduleDate, endScheduleDate, ref kingetData);
		//		
		//					// �����͈�
		//					if ((parameter.StartTotalDay > 0) || (parameter.EndTotalDay > 0))
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, 0, endScheduleDate, ref kingetData);
		//					}
		//					else
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, parameter.TotalDay, endScheduleDate, ref kingetData);
		//					}
		//					if (st != 0)return st;
		//				}
		//		
		//				// �������z���i�[�p�\�[�g���X�g
		//				addSecCodeSortedList = new SortedList();
		//		
		//				// ���Ӑ搿�����z�}�X�^�����i�P�j
		//				st = this.SelectCustDmdPrc1(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// ���Ӑ搿�����z�}�X�^�����i�Q�j
		//				st = this.SelectCustDmdPrc2(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// ���z�����Ӑ���
		//				st = this.CreateVirtualCustDmdPrc(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter, ref kingetData);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//					return st;
		//				}
		//		
		//				// �c���O�o��
		//				if (parameter.IsOutputZeroBlance)
		//				{
		//					this.MakeZeroCustomer(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter);
		//				}
		//		
		//				// �������z���i�[�p�\�[�g���X�g��ArrayList������������׎擾
		//				ArrayList list;
		//				st = this.CopyToArrayListFromSortedList(out list, addSecCodeSortedList, totalDayScheduleSortedList, customerScheduleSortedList, parameter, sqlConnection, ref kingetData);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				if (list.Count > 0)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//		
		//				objKingetCustDmdPrcWorkList = list;
		//			}
		//			finally
		//			{
		//				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);	// 2006.08.22 ADD ����@����
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//
		//		if (addSecCodeSortedList != null)
		//		{
		//			addSecCodeSortedList.Clear();
		//			addSecCodeSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 a �������z���擾�����i���Ӑ挳���E�����ꗗ�\�E���v�������j
		/// <summary>
		/// �������z���擾�����i���Ӑ挳���E�����ꗗ�\�E���v�������j
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="parameter">�����p�����[�^</param>
        /// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2007.04.17</br>
		private int SearchProc(out object objKingetCustDmdPrcWorkList
                              ,    SeiKingetParameter parameter
                              ,ref SeiKingetData kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			objKingetCustDmdPrcWorkList = null;
			
			try
			{
				// �R�l�N�V����������擾
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL�ڑ�
				SqlConnection sqlConnection = null;
				using (sqlConnection = new SqlConnection(connectionText))
				{
					//SqlEncryptInfo sqlEncryptInfo = null;  //DEL 2008/07/10 M.Kubota

					try
					{
						sqlConnection.Open();
						//sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);  //DEL 2008/07/10 M.Kubota

                        // 
                        objKingetCustDmdPrcWorkList = new ArrayList();
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}
					finally
					{
                        //--- DEL 2008/07/10 M.Kubota --->>>
                        //if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                        //{
                        //    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //}
                        //--- DEL 2008/07/10 M.Kubota ---<<<
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // �� 20070417 18322 a

		
        // �� 20070417 18322 d ��蒼���ׁ̈A�폜
        #region �������z���擾�����i�����ꊇ����p�j�i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// �������z���擾�����i�����ꊇ����p�j
		///// </summary>
		///// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		/////					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>
		//private int SearchMotoAllProc(out object objKingetCustDmdPrcWorkList, SeiKingetParameter parameter, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//
		//	objKingetCustDmdPrcWorkList = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList customerScheduleSortedList	= null;	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList addSecCodeSortedList			= null;	// �������z���i�[�p�\�[�g���X�g
		//
		//	try
		//	{
		//		// �R�l�N�V����������擾
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		// SQL�ڑ�
		//		SqlConnection sqlConnection = null;
		//		using (sqlConnection = new SqlConnection(connectionText))
		//		{
		//			SqlEncryptInfo sqlEncryptInfo = null;	// 2006.08.22 ADD ����@����
		//
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);	// 2006.08.22 ADD ����@����
		//
		//				totalDayScheduleSortedList = new SortedList();	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//				customerScheduleSortedList = new SortedList();	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//		
		//				// ���Ӑ�X�P�W���[���擾
		//				DateTime startScheduleDate;
		//				DateTime endScheduleDate;
		//				this.MakeGetScheduleDate(out startScheduleDate, out endScheduleDate, parameter);
		//		
		//				int st;
		//		
		//				// ���Ӑ悪�P���w��̏ꍇ
		//				if ((parameter.StartCustomerCode != 0) && (parameter.StartCustomerCode == parameter.EndCustomerCode))
		//				{
		//					this.GetScheduleByCustomerCode(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode, 1,
		//						startScheduleDate, endScheduleDate, ref kingetData);
		//				}
		//				else
		//				{
		//					this.GetScheduleByCustomerCodeRange(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode,
		//						parameter.EndCustomerCode, startScheduleDate, endScheduleDate, ref kingetData);
		//				}
		//
		//				bool oneCustomerSchedule = false;
		//		
		//				// ���Ӑ悪�P���w�� ���� ���Ӑ�X�P�W���[���擾�ς̏ꍇ
		//				if ((parameter.StartCustomerCode != 0) && (parameter.StartCustomerCode == parameter.EndCustomerCode))
		//				{
		//					if (customerScheduleSortedList.Count > 0)
		//					{
		//						oneCustomerSchedule = true;
		//					}
		//				}
		//		
		//				if (!oneCustomerSchedule)
		//				{
		//					st = 4;
		//			
		//					// �����X�P�W���[���擾
		//					if ((parameter.StartTotalDay > 0) || (parameter.EndTotalDay > 0))
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, 0, endScheduleDate, ref kingetData);
		//					}
		//					else
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, parameter.TotalDay, endScheduleDate, ref kingetData);
		//					}
		//					if (st != 0)return st;
		//				}
		//		
		//				// �������z���i�[�p�\�[�g���X�g
		//				addSecCodeSortedList = new SortedList();
		//		
		//				// ���Ӑ搿�����z�}�X�^�����i�P�j
		//				st = this.SelectCustDmdPrc1(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// ���Ӑ搿�����z�}�X�^�����i�Q�j
		//				st = this.SelectCustDmdPrc2(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// ���z�����Ӑ���
		//				st = this.CreateVirtualCustDmdPrc(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter, ref kingetData);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//					return st;
		//				}
		//		
		//				// �c���O�o��
		//				if (parameter.IsOutputZeroBlance)
		//				{
		//					this.MakeZeroCustomer(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter);
		//				}
		//		
		//				// �������z���i�[�p�\�[�g���X�g��ArrayList������������׎擾
		//				ArrayList list;
		//				st = this.CopyToArrayListFromSortedList(out list, addSecCodeSortedList, totalDayScheduleSortedList, customerScheduleSortedList, parameter, sqlConnection, ref kingetData);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				if (list.Count > 0)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//		
		//				objKingetCustDmdPrcWorkList = list;
		//			}
		//			finally
		//			{
		//				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);	// 2006.08.22 ADD ����@����
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//
		//		if (addSecCodeSortedList != null)
		//		{
		//			addSecCodeSortedList.Clear();
		//			addSecCodeSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 a �������z���擾�����i�����ꊇ����p�j
		/// <summary>
		/// �������z���擾�����i�����ꊇ����p�j
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="parameter">�����p�����[�^</param>
        /// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2007.04.17</br>
		private int SearchMotoAllProc(out object              objKingetCustDmdPrcWorkList
                                     ,    SeiKingetParameter  parameter
                                     ,ref SeiKingetData       kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			objKingetCustDmdPrcWorkList = null;
			
			try
			{
				// �R�l�N�V����������擾
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL�ڑ�
				SqlConnection sqlConnection = null;
				using (sqlConnection = new SqlConnection(connectionText))
				{
					//SqlEncryptInfo sqlEncryptInfo = null;  //DEL 2008/07/10 M.Kubota

					try
					{
						sqlConnection.Open();

						//sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);  //DEL 2008/07/10 M.Kubota

        				status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				
						objKingetCustDmdPrcWorkList = new ArrayList();
					}
					finally
					{
                        //--- DEL 2008/07/10 M.Kubota --->>>
                        //if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                        //{
                        //    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //}
                        //--- DEL 2008/07/10 M.Kubota ---<<<
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // �� 20070417 18322 a
		
        // �� 20070417 18322 d ��蒼���ׁ̈A�폜
        #region �������z���׏��擾�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �������z���׏��擾����
		///// </summary>
		///// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		///// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="objSeiKingetDetailParameterList">���׌����p�����[�^���X�g</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : ���׌����p�����[�^���X�g�̏����Ő�������f�[�^�Ɠ����f�[�^���擾���Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>
		//private int SearchDetailsProc(out object objDmdSalesWorkList, out object objDepsitMainWorkList,	string enterpriseCode,
		//	object objSeiKingetDetailParameterList, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	objDmdSalesWorkList = null;
		//	objDepsitMainWorkList = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//	SortedList customerScheduleSortedList	= null;	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//
		//	try
		//	{
		//		ArrayList parameterList = (ArrayList)objSeiKingetDetailParameterList;
		//
		//		ArrayList addUpSecCodeList = new ArrayList();
		//
		//		totalDayScheduleSortedList = new SortedList();	// �����X�P�W���[���i�[�p�\�[�g���X�g
		//		customerScheduleSortedList = new SortedList();	// ���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g
		//
		//		// �R�l�N�V����������擾
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		using (SqlConnection sqlConnection = new SqlConnection(connectionText))
		//		{
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				//��������
		//				if (kingetData.DmdSalesDB == null){kingetData.DmdSalesDB = new KingetDmdSalesDB();}
		//				ArrayList allDmdSalesWorkList = new ArrayList();
		//				ArrayList dmdSalesWorkList = new ArrayList();
		//	
		//				foreach (SeiKingetDetailParameter detailParameter in parameterList)
		//				{
		//					int st = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//		
		//					// ���t�͈͂������Ă��Ȃ��ꍇ�A�X�P�W���[�����Q�Ƃ���
		//					if ((detailParameter.StartDateSpan <= 0)||(detailParameter.EndDateSpan <= 0))
		//					{
		//						if (!customerScheduleSortedList.Contains(detailParameter.CustomerCode))
		//						{
		//							// ���Ӑ�X�P�W���[���擾
		//							this.GetScheduleByCustomerCode(ref customerScheduleSortedList, enterpriseCode, detailParameter.CustomerCode, 1,
		//								DateTime.Today.AddYears(-10), TDateTime.LongDateToDateTime("YYYYMMDD", 20991231), ref kingetData);
		//						}
		//			
		//						if (!customerScheduleSortedList.Contains(detailParameter.CustomerCode))
		//						{
		//							// �����X�P�W���[�����擾����Ă��Ȃ��ꍇ�͎擾����
		//							if ((totalDayScheduleSortedList == null) || (totalDayScheduleSortedList.Count == 0))
		//							{
		//								// �X�P�W���[���擾
		//								st = this.GetScheduleForDetail(ref totalDayScheduleSortedList, enterpriseCode, parameterList, ref kingetData);
		//								if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//								{
		//								}
		//								else
		//									if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//								{
		//									continue;
		//								}
		//								else
		//								{
		//									return status;
		//								}
		//							}
		//						}
		//			
		//						// �����������ꍇ�͓��Ӑ�����擾
		//						if (detailParameter.TotalDay <= 0)
		//						{
		//							KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
		//		
		//							// ���Ӑ���擾
		//							st = this.ReadCustomer(ref kingetCustDmdPrcWork, sqlConnection, enterpriseCode, detailParameter.CustomerCode);
		//							if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//							{
		//								detailParameter.TotalDay = kingetCustDmdPrcWork.TotalDay;
		//							}
		//							else
		//								if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//							{
		//								continue;
		//							}
		//							else
		//							{
		//								return st;
		//							}
		//						}
		//			
		//						// ���׎擾�p���o���t�͈͎擾
		//						int startDateSpan;
		//						int endDateSpan;
		//						SeiKingetParameter seiKingetParameter = new SeiKingetParameter();
		//						seiKingetParameter.StartAddUpDate = TDateTime.LongDateToDateTime("YYYYMMDD", detailParameter.AddUpDate);
		//						seiKingetParameter.EndAddUpDate = TDateTime.LongDateToDateTime("YYYYMMDD", detailParameter.AddUpDate);
		//			
		//						// ���Ӑ�X�P�W���[�������݂���ꍇ
		//						if (customerScheduleSortedList.Contains(detailParameter.CustomerCode))
		//						{
		//							if (!this.GetDateSpanForDetailFromCustomerSchedule(out startDateSpan, out endDateSpan, detailParameter.CustomerCode, customerScheduleSortedList, seiKingetParameter))
		//							{
		//								continue;
		//							}
		//						}
		//						else
		//						{
		//							if (!this.GetDateSpanForDetailFromTotalDaySchedule(out startDateSpan, out endDateSpan, detailParameter.TotalDay, totalDayScheduleSortedList, seiKingetParameter))
		//							{
		//								continue;
		//							}
		//						}
		//						detailParameter.StartDateSpan = startDateSpan;
		//						detailParameter.EndDateSpan = endDateSpan;
		//					}
		//		
		//					addUpSecCodeList.Clear();
		//					if ((detailParameter.AddUpSecCode.Trim() != "") && (detailParameter.AddUpSecCode.Trim() != ALLSECCODE))
		//					{
		//						addUpSecCodeList.Add(detailParameter.AddUpSecCode);				
		//					}
		//					st = kingetData.DmdSalesDB.Search(out dmdSalesWorkList, enterpriseCode, addUpSecCodeList, detailParameter.CustomerCode,
		//						detailParameter.StartDateSpan, detailParameter.EndDateSpan, sqlConnection);
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
        //                        // �� 20070123 18322 c MA.NS�p�ɕύX
		//						//foreach (DmdSalesWork dmdSalesWork in dmdSalesWorkList)
		//						//{
		//						//	allDmdSalesWorkList.Add(dmdSalesWork);
		//						//}
		//
		//						foreach (SalesSlipWork salesSalesWork in dmdSalesWorkList)
		//						{
		//							allDmdSalesWorkList.Add(salesSalesWork);
		//						}
        //                        // �� 20070123 18322 c
		//					}
		//					else
		//						if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//					{
		//					}
		//					else
		//					{
		//						return st;
		//					}
		//				}
		//	
		//				//����
		//				if (kingetData.DepsitMainDB == null){kingetData.DepsitMainDB = new KingetDepsitMainDB();}
		//				ArrayList allDepsitMainWorkList = new ArrayList();
		//				ArrayList depsitMainWorkList = new ArrayList();
		//	
		//				foreach (SeiKingetDetailParameter detailParameter in parameterList)
		//				{
		//					// ���t�͈͂������Ă��Ȃ��ꍇ�A���֐i��
		//					if ((detailParameter.StartDateSpan <= 0)||(detailParameter.EndDateSpan <= 0))
		//					{
		//						continue;
		//					}
		//			
		//					addUpSecCodeList.Clear();
		//					if ((detailParameter.AddUpSecCode.Trim() != "") && (detailParameter.AddUpSecCode.Trim() != ALLSECCODE))
		//					{
		//						addUpSecCodeList.Add(detailParameter.AddUpSecCode);
		//					}
		//					int st = kingetData.DepsitMainDB.Search(out depsitMainWorkList, enterpriseCode, addUpSecCodeList, detailParameter.CustomerCode,
		//						detailParameter.StartDateSpan, detailParameter.EndDateSpan, sqlConnection);
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
		//						foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
		//						{
		//							allDepsitMainWorkList.Add(depsitMainWork);
		//						}
		//					}
		//					else
		//						if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//					{
		//					}
		//					else
		//					{
		//						return st;
		//					}
		//				}
		//		
		//				if ((allDmdSalesWorkList.Count > 0) || (allDepsitMainWorkList.Count > 0))
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//				objDmdSalesWorkList = allDmdSalesWorkList;
		//				objDepsitMainWorkList = allDepsitMainWorkList;
		//			}
		//			finally
		//			{
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 a �������z���׏��擾����
        /// <summary>
		/// �������z���׏��擾����
		/// </summary>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="objSeiKingetDetailParameterList">���׌����p�����[�^���X�g</param>
        /// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : ���׌����p�����[�^���X�g�̏����Ő�������f�[�^�Ɠ����f�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18322 �ؑ� ����</br>
		/// <br>Date       : 2007.04.17</br>
		private int SearchDetailsProc(out object        objDmdSalesWorkList
                                     ,out object        objDepsitMainWorkList
                                     ,    string        enterpriseCode
                                     ,    object        objSeiKingetDetailParameterList
                                     ,ref SeiKingetData kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			objDmdSalesWorkList = null;
			objDepsitMainWorkList = null;
			
			try
			{
				// �R�l�N�V����������擾
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				using (SqlConnection sqlConnection = new SqlConnection(connectionText))
				{
					try
					{
						sqlConnection.Open();

						objDmdSalesWorkList = new ArrayList();
						objDepsitMainWorkList = new ArrayList();

                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}
					finally
					{
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // �� 20070417 18322 a
		
		/// <summary>
		/// ���Ӑ搿�����v�c���`�F�b�N����
		/// </summary>
		/// <param name="enterpriceCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>0:�������v�c�����O�~�������͎������, 1:�������v�c�����O�~</returns>
		/// <br>Note       : �w�蓾�Ӑ�R�[�h�̓��Ӑ搿�����z�}�X�^�̍ŏI���R�[�h�̐������v�c�����`�F�b�N���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		private int CheckDemandPriceProc(string enterpriceCode, int customerCode)
		{
			int status = 1;

			try
			{
				// �R�l�N�V����������擾
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL�ڑ�
				using (SqlConnection sqlConnection = new SqlConnection(connectionText))
				{
					try
					{
						sqlConnection.Open();
				
						// ���Ӑ搿�����z�}�X�^�ŏI���R�[�h���z�O�~�`�F�b�N
						int st = this.CheckCustDmdPrc_LastRecord(sqlConnection, enterpriceCode, customerCode);
						if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(st == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							status = 0;
						}
					}
					finally
					{
						if (sqlConnection != null) sqlConnection.Close();
					}

				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}

			return status;
		}
		
		/// <summary>
		/// ���Ӑ���擾����
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ�}�X�^���������AKINGET�p���Ӑ搿�����z���Ɋi�[���ĕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>		
		private int ReadCustomer(ref KingetCustDmdPrcWork kingetCustDmdPrcWork, SqlConnection sqlConnection,
			string enterpriseCode, int customerCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			#region 2006.08.21 DEL ����@����
			//using (SqlCommand sqlCommand = new SqlCommand("SELECT"
			//    +" CUSTOMERRF.CUSTOMERCODERF,CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF"
			//    +",CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
			//    +",CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF,CUSTOMERRF.PORTABLETELNORF"
			//    // 2006.04.21 ADD START ����@����
			//    +",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
			//    // 2006.04.21 ADD END ����@����
			//    +",CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
			//    +",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.CUSTOMERAGENTNMRF,CUSTOMERRF.BILLCOLLECTERCDRF,CUSTOMERRF.BILLCOLLECTERNMRF"
			//    +" FROM CUSTOMERRF"
			//    +" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
			//    +" AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
			#endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());            

            # region [SELECT��]
            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "  CUST.CUSTOMERCODERF" + Environment.NewLine;
            sqlText += " ,CUST.NAMERF AS CUSTOMERNAMERF" + Environment.NewLine;
            sqlText += " ,CUST.NAME2RF AS CUSTOMERNAME2RF" + Environment.NewLine;
            sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
            sqlText += " ,CUST.KANARF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
            sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
            sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
            sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
            sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
            sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
            sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
            sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
            sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
            sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
            sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
            sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
            sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
            sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
            sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
            sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
            sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
            sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
            sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
            sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
            sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
            sqlText += " ,BILL.NAMERF AS BILLCOLLECTERNMRF" + Environment.NewLine;
            sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
            sqlText += " ,CLIM.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
            sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
            sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNMRF" + Environment.NewLine;
            sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNMRF" + Environment.NewLine;
            sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNMRF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS BILL" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = BILL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.BILLCOLLECTERCDRF = BILL.EMPLOYEECODERF" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND CUST.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
            # endregion            
            //--- ADD 2008/04/25 M.Kubota ---<<<
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            // 2006.08.21 ADD START ����@����
            //using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTOMER
            //    +" WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
            //    +" AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
			// 2006.08.21 ADD END ����@����
            //		, sqlConnection))
            //--- DEL 2008/04/25 M.Kubota ---<<<

            try
            {

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))  //ADD 2008/04/25 M.Kubota
                {
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                this.SetKingetCustDmdPrcWorkFromCustomerDataReader(ref kingetCustDmdPrcWork, myReader);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                break;
                            }
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            //--- ADD 2008/07/10 M.Kubota --->>>
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/07/10 M.Kubota ---<<<

			return status;
		}

        // �� 2007.12.21 980081 d
        #region ���Ӑ��񌟍����� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// ���Ӑ��񌟍�����
        ///// </summary>
        ///// <param name="customerTable">���Ӑ���e�[�u��(KINGET�p���Ӑ搿�����z���N���X�Ƃ���)</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ�}�X�^���������AKINGET�p���Ӑ搿�����z���Ɋi�[���ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SearchCustomer(out Hashtable customerTable, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	customerTable = new Hashtable();
		//	
		//	#region 2006.08.21 DEL ����@����
		//	//using (SqlCommand sqlCommand = new SqlCommand("SELECT"
		//	//    +" CUSTOMERRF.CUSTOMERCODERF,CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF"
		//	//    +",CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	//    +",CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF,CUSTOMERRF.PORTABLETELNORF"
		//	//    // 2006.04.21 ADD START ����@����
		//	//    +",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
		//	//    // 2006.04.21 ADD END ����@����
		//	//    +",CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	//    +",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.CUSTOMERAGENTNMRF,CUSTOMERRF.BILLCOLLECTERCDRF,CUSTOMERRF.BILLCOLLECTERNMRF"
		//	//    +" FROM CUSTOMERRF"
		//	//    +" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
		//	#endregion
		//	using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTOMER, sqlConnection))	// 2006.08.21 ADD ����@����
		//	{
		//		// Where���̍쐬
		//		bool result = this.MakeWhereStringForSearchCustomer(sqlCommand, parameter);
		//		if (!result) return status;
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				while (myReader.Read())
		//				{
		//					KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
		//					this.SetKingetCustDmdPrcWorkFromCustomerDataReader(kingetCustDmdPrcWork, myReader);
		//					customerTable.Add(kingetCustDmdPrcWork.CustomerCode, kingetCustDmdPrcWork);
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region Where���쐬�i���Ӑ��񌟍��j ���g�p�̂��ߍ폜
        ///// <summary>
		///// Where���쐬�i���Ӑ��񌟍��j
		///// </summary>
		///// <param name="sqlCommand">SqlCommand</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : ���Ӑ�}�X�^���������邽�߂�Where�����쐬���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringForSearchCustomer(SqlCommand sqlCommand, SeiKingetParameter parameter)
		//{
		//	StringBuilder resultSB = new StringBuilder(" WHERE");
		//	
		//	// ��ƃR�[�h
		//	resultSB.Append(" CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
		//	SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//	paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//	// �_���폜�敪
		//	resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
		//	SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// ���Ӑ�R�[�h
		//	resultSB.Append(this.MakeWhereStringCustomerCode(sqlCommand, parameter.StartCustomerCode, parameter.EndCustomerCode, "CUSTOMERRF"));
		//	
		//	// ����
		//	resultSB.Append(this.MakeWhereStringTotalDay(sqlCommand, parameter.TotalDay, parameter.StartTotalDay, parameter.EndTotalDay, "CUSTOMERRF"));
        //
		//	// ���Ӑ�J�i
		//	resultSB.Append(this.MakeWhereStringKana(sqlCommand, parameter.StartKana, parameter.EndKana, "CUSTOMERRF"));
		//	
		//	// �]�ƈ��R�[�h
		//	resultSB.Append(this.MakeWhereStringEmployeeCode(sqlCommand, parameter.EmployeeKind, parameter.StartEmployeeCode, parameter.EndEmployeeCode, "CUSTOMERRF"));
		//		
		//	// �������o�͋敪�R�[�h
		//	if (parameter.IsJudgeBillOutputCode)
		//	{
		//		resultSB.Append(" AND CUSTOMERRF.BILLOUTPUTCODERF=@FINDBILLOUTPUTCODE");
		//		SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@FINDBILLOUTPUTCODE", SqlDbType.Int);
		//		paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(0);
		//	}
        //
		//	// �l�E�@�l�敪
		//	string whereCorporateDivCode;
		//	if (!this.MakeWhereStringCorporateDivCode(out whereCorporateDivCode, parameter.CorporateDivCodeList, parameter.IsAllCorporateDivCode))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereCorporateDivCode);
		//	
		//	// ���Ӑ敪�̓R�[�h
		//	resultSB.Append(this.MakeWhereStringCustAnalysCode(sqlCommand, parameter, "CUSTOMERRF"));
		//	
		//	sqlCommand.CommandText += resultSB.ToString();
        //
		//	return true;
		//}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region ���_��񌟍����� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// ���_��񌟍�����
        ///// </summary>
        ///// <param name="sectionList">���_���\�[�g���X�g</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���_���ݒ�}�X�^���������A���_�R�[�h�̃��X�g�Ƃ��ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SearchSection(out SortedList sectionList, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	sectionList = new SortedList();
		//	
		//	// ���_�R�[�h
		//	string whereSectionCode;
		//	if (!this.MakeWhereStringSectionCode(out whereSectionCode, parameter.AddUpSecCodeList, parameter.IsSelectAllSection,
		//		parameter.IsOutputAllSecRec, "SECINFOSETRF", "SECTIONCODERF"))
		//	{
		//		return status;
		//	}
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand("SELECT SECTIONCODERF FROM SECINFOSETRF"
		//			   +" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
		//			   + whereSectionCode
		//			   , sqlConnection))
		//	{
		//		SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//		paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//		SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				while (myReader.Read())
		//				{
		//					string sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
		//					sectionList.Add(sectionCode, null);
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 20070417 18322 d ���߃X�P�W���[���́AMA.NS�ł͎g�p���Ȃ��̂ō폜
        #region �����X�P�W���[�����X�g�擾�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �����X�P�W���[�����X�g�擾����
		///// </summary>
		///// <param name="totalDayScheduleSortedList">�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="totalDay">����</param>
		///// <param name="endScheduleDate">�X�P�W���[���擾���t�i�I���j</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : ���X�P�W���[�����X�g���������A�X�P�W���[���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleByTotalDay(ref SortedList totalDayScheduleSortedList, string enterpriseCode, int totalDay, DateTime endScheduleDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
        //    if (kingetData.CAddUpSMngGetInfDB == null)
		//	{
		//		kingetData.CAddUpSMngGetInfDB = new CAddUpSMngGetInfDB();
		//	}
		//	
		//	SearchCAddUpSMngToDateRangeParm para = new SearchCAddUpSMngToDateRangeParm();
		//	para.EnterpriseCode = enterpriseCode;
		//	para.TotalDay		= totalDay;
		//	para.StartAddUpDate	= endScheduleDate.AddYears(-20);
		//	para.EndAddUpDate	= endScheduleDate;
		//	para.ExtraDivision	= SearchCAddUpSMngToDateRangeParm.EXTRADIVISION_OPERATINGYEAR;
		//	
		//	ArrayList schedules = new ArrayList();
		//	
		//	status = kingetData.CAddUpSMngGetInfDB.SearchTotalDayToDmdAddUpDateOnArrayListTypeDInf(para, ref schedules);
		//	if (status == 0)
		//	{
		//		if (schedules != null)
		//		{
		//			foreach (RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf in schedules)
		//			{
		//				// ����
		//				if (!totalDayScheduleSortedList.Contains(retAddUpDateItemTypeDInf.TotalDay))
		//				{
		//					SortedList list = new SortedList();
		//					totalDayScheduleSortedList.Add(retAddUpDateItemTypeDInf.TotalDay, list);
		//				}
		//				
		//				SortedList scheduleDateList = (SortedList)totalDayScheduleSortedList[retAddUpDateItemTypeDInf.TotalDay];
		//				int cAddUpUpdDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//				
		//				// �v����t
		//				if (!scheduleDateList.Contains(cAddUpUpdDate))
		//				{
		//					scheduleDateList.Add(cAddUpUpdDate, retAddUpDateItemTypeDInf);
		//				}
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 d ���߃X�P�W���[���́AMA.NS�ł͎g�p���Ȃ��̂ō폜
        #region ���Ӑ�X�P�W���[�����X�g�擾�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ���Ӑ�X�P�W���[�����X�g�擾����
		///// </summary>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="customerCode">���Ӑ�R�[�h</param>
		///// <param name="selectionMode">�I����@(0:���Ӑ�X�P�W���[�����Ȃ���Β����X�P�W���[�����Q��,1:���Ӑ�X�P�W���[���̂ݎQ��)</param>
		///// <param name="startScheduleDate">�X�P�W���[���擾���t�i�J�n�j</param>
		///// <param name="endScheduleDate">�X�P�W���[���擾���t�i�I���j</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : ���X�P�W���[�����X�g���������A�X�P�W���[���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleByCustomerCode(ref SortedList customerScheduleSortedList, string enterpriseCode, int customerCode,
		//	int selectionMode, DateTime startScheduleDate, DateTime endScheduleDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	if (kingetData.CAddUpSMngGetInfDB == null)
		//	{
		//		kingetData.CAddUpSMngGetInfDB = new CAddUpSMngGetInfDB();
		//	}
		//	
		//	SearchCAddUpSMngToDateRangeParm para = new SearchCAddUpSMngToDateRangeParm();
		//	para.EnterpriseCode = enterpriseCode;
		//	para.TotalDay		= 0;
		//	para.StartAddUpDate	= startScheduleDate;
		//	para.EndAddUpDate	= endScheduleDate;
		//	para.ExtraDivision	= SearchCAddUpSMngToDateRangeParm.EXTRADIVISION_OPERATINGYEAR;
		//	
		//	ArrayList schedules = new ArrayList();
		//
		//	status = kingetData.CAddUpSMngGetInfDB.SearchTotalDayToDmdAddUpDateOnArrayListTypeDInf(para, customerCode, selectionMode, ref schedules);
		//
		//	if (status == 0)
		//	{
		//		if ((schedules != null) && (schedules.Count > 0))
		//		{
		//			// ���Ӑ�R�[�h
		//			if (!customerScheduleSortedList.Contains(customerCode))
		//			{
		//				customerScheduleSortedList.Add(customerCode, new SortedList());
		//			}
		//			SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//	
		//			foreach (RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf in schedules)
		//			{
		//				int cAddUpUpdDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//				// �v����t
		//				if (!scheduleDateList.Contains(cAddUpUpdDate))
		//				{
		//					scheduleDateList.Add(cAddUpUpdDate, retAddUpDateItemTypeDInf);
		//				}
		//			}
		//		}
		//	}
		//	
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 d ���߃X�P�W���[���́AMA.NS�ł͎g�p���Ȃ��̂ō폜
        #region ���Ӑ�X�P�W���[�����X�g�擾�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// ���Ӑ�X�P�W���[�����X�g�擾����
		///// </summary>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
		///// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
		///// <param name="startScheduleDate">�X�P�W���[���擾���t�i�J�n�j</param>
		///// <param name="endScheduleDate">�X�P�W���[���擾���t�i�I���j</param>
		///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : ���X�P�W���[�����X�g���������A�X�P�W���[���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleByCustomerCodeRange(ref SortedList customerScheduleSortedList, string enterpriseCode, int startCustomerCode,
		//	int endCustomerCode, DateTime startScheduleDate, DateTime endScheduleDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	if (kingetData.CAddUpSMngGetInfDB == null)
		//	{
		//		kingetData.CAddUpSMngGetInfDB = new CAddUpSMngGetInfDB();
		//	}
		//	
		//	SearchCAddUpSMngToDateRangeParm para = new SearchCAddUpSMngToDateRangeParm();
		//	para.EnterpriseCode = enterpriseCode;
		//	para.TotalDay		= 0;
		//	para.StartAddUpDate	= startScheduleDate;
		//	para.EndAddUpDate	= endScheduleDate;
		//	para.ExtraDivision	= SearchCAddUpSMngToDateRangeParm.EXTRADIVISION_OPERATINGYEAR;
		//	
		//	Hashtable scheduleTable = new Hashtable();
		//
		//	status = kingetData.CAddUpSMngGetInfDB.SearchCustomerRangeToDmdAddUpDateInf(para, startCustomerCode, endCustomerCode, ref scheduleTable);
		//
		//	if (status == 0)
		//	{
		//		if ((scheduleTable != null) && (scheduleTable.Count > 0))
		//		{
		//			// �擾�����X�P�W���[���́A�uHashtable(KEY:���Ӑ�R�[�h)->ArrayList�v
		//			foreach (DictionaryEntry de in scheduleTable)
		//			{
		//				int customerCode = (int)de.Key;
		//				ArrayList list	 = (ArrayList)de.Value;
		//			
		//				// ���Ӑ�R�[�h
		//				if (!customerScheduleSortedList.Contains(customerCode))
		//				{
		//					customerScheduleSortedList.Add(customerCode, new SortedList());
		//				}
		//				SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//		
		//				foreach (RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf in list)
		//				{
		//					int cAddUpUpdDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//					// �v����t
		//					if (!scheduleDateList.Contains(cAddUpUpdDate))
		//					{
		//						scheduleDateList.Add(cAddUpUpdDate, retAddUpDateItemTypeDInf);
		//					}
		//				}
		//			}
		//		}
		//	}
		//	
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d
		
        // �� 20070417 18322 d ���߃X�P�W���[���́AMA.NS�ł͎g�p���Ȃ��̂ō폜
        #region �����X�P�W���[�����X�g�擾�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// �����X�P�W���[�����X�g�擾����
		///// </summary>
		///// <param name="totalDayScheduleSortedList">�����X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="detailParameterList">���׌����p�����[�^���X�g</param>
		///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : �����X�P�W���[�����X�g���������A�����X�P�W���[���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleForDetail(ref SortedList totalDayScheduleSortedList, string enterpriseCode, ArrayList detailParameterList, ref SeiKingetData kingetData)
		//{
		//	totalDayScheduleSortedList = new SortedList();
		//	
		//	int lastAddUpDate = 0;
		//	
		//	foreach (SeiKingetDetailParameter parameter in detailParameterList)
		//	{
		//		if (lastAddUpDate < parameter.AddUpDate)
		//		{
		//			lastAddUpDate = parameter.AddUpDate;
		//		}
		//	}
		//	
		//	// �����X�P�W���[���擾
		//	DateTime endScheduleDate = DateTime.Today;
		//	if (lastAddUpDate > 0)
		//	{
		//		endScheduleDate = TDateTime.LongDateToDateTime("YYYYMMDD", lastAddUpDate);
		//		endScheduleDate = endScheduleDate.AddMonths(1);
		//	}				
		//	return this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, enterpriseCode, 0, endScheduleDate, ref kingetData);				
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 2007.12.21 980081 d
        #region �X�P�W���[���擾�p���t�쐬���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// �X�P�W���[���擾�p���t�쐬����
        ///// </summary>
        ///// <param name="startScheduleDate">�X�P�W���[���擾�p���t(�J�n)</param>
        ///// <param name="endScheduleDate">�X�P�W���[���擾�p���t(�I��)</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �X�P�W���[���擾�p���t���쐬���܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>
		//private void MakeGetScheduleDate(out DateTime startScheduleDate, out DateTime endScheduleDate, SeiKingetParameter parameter)
		//{
		//	// �J�n
		//	if (parameter.StartAddUpYearMonth != 0)
		//	{
		//		startScheduleDate	= TDateTime.LongDateToDateTime("YYYYMMDD", parameter.StartAddUpYearMonth*100+1);
		//		startScheduleDate = startScheduleDate.AddYears(-10);
		//	}
		//	else
		//	if (parameter.StartAddUpDate != DateTime.MinValue)
		//	{
		//		startScheduleDate	= parameter.StartAddUpDate.AddYears(-10);
		//	}
		//	else
		//	{
		//		startScheduleDate	= DateTime.Today.AddYears(-10);
		//	}
		//	
		//	// �I��
		//	if (parameter.EndAddUpYearMonth != 0)
		//	{
		//		endScheduleDate = TDateTime.LongDateToDateTime("YYYYMMDD", parameter.EndAddUpYearMonth*100+1);
		//		endScheduleDate = endScheduleDate.AddMonths(1);
		//	}
		//	else
		//	if (parameter.EndAddUpDate != DateTime.MinValue)
		//	{
		//		endScheduleDate = parameter.EndAddUpDate.AddMonths(1);
		//	}
		//	else
		//	{
		//		endScheduleDate = DateTime.Today.AddMonths(1);
		//	}
        //}
        #endregion
        // �� 2007.12.21 980081 d

        #region ���Ӑ搿�����z�}�X�^�ǂݍ��݁i�P�j�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ���Ӑ搿�����z�}�X�^�ǂݍ��݁i�P�j����
		///// </summary>
		///// <param name="addSecCodeSortedList">�������z���i�[�p�\�[�g���X�g</param>
		///// <param name="sqlConnection">SQLConnection</param>
		///// <param name="enterpiseCode">��ƃR�[�h</param>
		///// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		///// <param name="customerCode">���Ӑ�R�[�h</param>
		///// <param name="addUpDate">�v����t(YYYYMMDD)</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : ���Ӑ搿�����z�}�X�^���������A�������z���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int ReadCustDmdPrc1(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, string enterpiseCode,
		//    string addUpSecCode, int customerCode, int addUpDate)
		//{
		//    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
		//    using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTDMDPRC
		//               +" WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
		//               +" AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
		//               +" AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE"
		//               , sqlConnection))
		//    {
		//        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpiseCode);

		//        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

		//        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
		//        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(addUpSecCode);

		//        SqlParameter paraCostomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
		//        paraCostomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

		//        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
		//        paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);

		//        using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//        {
		//            try
		//            {
		//                this.SetListFromSQLReader(ref status, ref addSecCodeSortedList, myReader);
		//            }
		//            finally
		//            {
		//                if (myReader != null) myReader.Close();
		//            }
		//        }
		//    }
			
		//    return status;
        //}
        #endregion

        // �� 2007.12.21 980081 d
        #region ���Ӑ搿�����z�}�X�^�����i�P�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// ���Ӑ搿�����z�}�X�^�����i�P�j����
        ///// </summary>
        ///// <param name="addSecCodeSortedList">�������z���i�[�p�\�[�g���X�g</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ搿�����z�}�X�^���������A�������z���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SelectCustDmdPrc1(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTDMDPRC, sqlConnection))
		//	{
		//		// Where���̍쐬
		//		bool result = this.MakeWhereStringForSelectCustDmdPrc1(sqlCommand, parameter);
		//		if (!result) return status;
        //
		//		// OrderBy�ǉ�
		//		sqlCommand.CommandText += " ORDER BY CUSTDMDPRCRF.ADDUPSECCODERF,CUSTDMDPRCRF.CUSTOMERCODERF,CUSTDMDPRCRF.ADDUPDATERF";
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				this.SetListFromSQLReader(ref status, ref addSecCodeSortedList, myReader);
		//			}
		//			finally
        //			{
        //				if (myReader != null) myReader.Close();
        //			}
        //		}
        //	}
        //	
        //	return status;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region ���Ӑ搿�����z�}�X�^�����i�Q�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// ���Ӑ搿�����z�}�X�^�����i�Q�j����
        ///// </summary>
        ///// <param name="addSecCodeSortedList">�������z���i�[�p�\�[�g���X�g</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ搿�����z�}�X�^�̎w����t�ȑO�̍ŏI���R�[�h���������A�������z���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SelectCustDmdPrc2(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTDMDPRC, sqlConnection))
		//	{
		//		// Where���̍쐬
		//		bool result = this.MakeWhereStringForSelectCustDmdPrc2(sqlCommand, parameter);
		//		if (!result) return status;
        //
		//		// OrderBy�ǉ�
		//		sqlCommand.CommandText += " ORDER BY CUSTDMDPRCRF.ADDUPSECCODERF,CUSTDMDPRCRF.CUSTOMERCODERF,CUSTDMDPRCRF.ADDUPDATERF";
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				this.SetListFromSQLReader(ref status, ref addSecCodeSortedList, myReader);
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region Where���쐬�i���Ӑ搿�����z�}�X�^�����P�j ���g�p�̂��ߍ폜
        ///// <summary>
        ///// Where���쐬�i���Ӑ搿�����z�}�X�^�����P�j
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ搿�����z�}�X�^���������邽�߂�Where�����쐬���܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringForSelectCustDmdPrc1(SqlCommand sqlCommand, SeiKingetParameter parameter)
		//{
		//	StringBuilder resultSB = new StringBuilder(" WHERE");
		//	
		//	// ��ƃR�[�h
		//	resultSB.Append(" CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
		//	SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//	paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//	// �_���폜�敪
		//	resultSB.Append(" AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
		//	SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// ���Ӑ�}�X�^�_���폜(�������͓��Ӑ悪�_���폜�敪�̍i���݂��s���I�I)
		//	resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDCUSTOMERLOGICALDELETECODE");
		//	SqlParameter paraCustomerLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDCUSTOMERLOGICALDELETECODE", SqlDbType.Int);
		//	paraCustomerLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// �v���
		//	string whereAddUpdate = "";
		//	if (!this.MakeWhereStringAddUpdateNormal(sqlCommand, out whereAddUpdate, parameter))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddUpdate);
        //
		//	// �v�㋒�_
		//	string whereAddSecCode;
		//	if (!this.MakeWhereStringSectionCode(out whereAddSecCode, parameter.AddUpSecCodeList, parameter.IsSelectAllSection, 
		//		parameter.IsOutputAllSecRec, "CUSTDMDPRCRF", "ADDUPSECCODERF"))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddSecCode);
		//	
		//	// ���Ӑ�R�[�h
		//	resultSB.Append(this.MakeWhereStringCustomerCode(sqlCommand, parameter.StartCustomerCode, parameter.EndCustomerCode, "CUSTOMERRF"));
		//	
		//	// ���Ӑ�J�i
		//	resultSB.Append(this.MakeWhereStringKana(sqlCommand, parameter.StartKana, parameter.EndKana, "CUSTOMERRF"));
		//	
		//	// �]�ƈ��R�[�h
		//	resultSB.Append(this.MakeWhereStringEmployeeCode(sqlCommand, parameter.EmployeeKind, parameter.StartEmployeeCode, parameter.EndEmployeeCode, "CUSTOMERRF"));
        //
		//	// ����
		//	resultSB.Append(this.MakeWhereStringTotalDay(sqlCommand, parameter.TotalDay, parameter.StartTotalDay, parameter.EndTotalDay, "CUSTOMERRF"));
	    //
		//	// �������o�͋敪�R�[�h
		//	if (parameter.IsJudgeBillOutputCode)
		//	{
		//		resultSB.Append(" AND CUSTOMERRF.BILLOUTPUTCODERF=@FINDBILLOUTPUTCODE");
		//		SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@FINDBILLOUTPUTCODE", SqlDbType.Int);
		//		paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(0);
		//	}
        //
		//	// �l�E�@�l�敪
		//	string whereCorporateDivCode;
		//	if (!this.MakeWhereStringCorporateDivCode(out whereCorporateDivCode, parameter.CorporateDivCodeList, parameter.IsAllCorporateDivCode))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereCorporateDivCode);
		//
		//	// ���Ӑ敪�̓R�[�h
		//	resultSB.Append(this.MakeWhereStringCustAnalysCode(sqlCommand, parameter, "CUSTOMERRF"));
		//	
		//	sqlCommand.CommandText += resultSB.ToString();
        //
		//	return true;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region Where���쐬�i���Ӑ搿�����z�}�X�^�����Q�j ���g�p�̂��ߍ폜
        ///// <summary>
        ///// Where���쐬�i���Ӑ搿�����z�}�X�^�����Q�j
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : ���Ӑ搿�����z�}�X�^���������邽�߂�Where�����쐬���܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringForSelectCustDmdPrc2(SqlCommand sqlCommand, SeiKingetParameter parameter)
		//{
		//	StringBuilder resultSB = new StringBuilder(" WHERE");
		//	
		//	// ��ƃR�[�h
		//	resultSB.Append(" CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
		//	SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//	paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//	// �_���폜�敪
		//	resultSB.Append(" AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
		//	SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// ���Ӑ�}�X�^�_���폜(�������͓��Ӑ悪�_���폜�敪�̍i���݂��s���I�I)
		//	resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDCUSTOMERLOGICALDELETECODE");
		//	SqlParameter paraCustomerLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDCUSTOMERLOGICALDELETECODE", SqlDbType.Int);
		//	paraCustomerLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// �v���
		//	string whereAddUpdate = "";
		//	if (!this.MakeWhereStringAddUpdateLastRecord(sqlCommand, out whereAddUpdate, parameter))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddUpdate);
        //
		//	// �v�㋒�_
		//	string whereAddSecCode;
		//	if (!this.MakeWhereStringSectionCode(out whereAddSecCode, parameter.AddUpSecCodeList, parameter.IsSelectAllSection, 
		//		parameter.IsOutputAllSecRec, "CUSTDMDPRCRF", "ADDUPSECCODERF"))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddSecCode);
		//	
		//	// ���Ӑ�R�[�h
		//	resultSB.Append(this.MakeWhereStringCustomerCode(sqlCommand, parameter.StartCustomerCode, parameter.EndCustomerCode, "CUSTOMERRF"));
		//	
		//	// ���Ӑ�J�i
		//	resultSB.Append(this.MakeWhereStringKana(sqlCommand, parameter.StartKana, parameter.EndKana, "CUSTOMERRF"));
		//	
		//	// �]�ƈ��R�[�h
		//	resultSB.Append(this.MakeWhereStringEmployeeCode(sqlCommand, parameter.EmployeeKind, parameter.StartEmployeeCode, parameter.EndEmployeeCode, "CUSTOMERRF"));
        //
		//	// ����
		//	resultSB.Append(this.MakeWhereStringTotalDay(sqlCommand, parameter.TotalDay, parameter.StartTotalDay, parameter.EndTotalDay, "CUSTOMERRF"));
	    //
		//	// �������o�͋敪�R�[�h
		//	if (parameter.IsJudgeBillOutputCode)
		//	{
		//		resultSB.Append(" AND CUSTOMERRF.BILLOUTPUTCODERF=@FINDBILLOUTPUTCODE");
		//		SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@FINDBILLOUTPUTCODE", SqlDbType.Int);
		//		paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(0);
		//	}
        //
		//	// �l�E�@�l�敪
		//	string whereCorporateDivCode;
		//	if (!this.MakeWhereStringCorporateDivCode(out whereCorporateDivCode, parameter.CorporateDivCodeList, parameter.IsAllCorporateDivCode))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereCorporateDivCode);
		//
		//	// ���Ӑ敪�̓R�[�h
		//	resultSB.Append(this.MakeWhereStringCustAnalysCode(sqlCommand, parameter, "CUSTOMERRF"));
		//	
		//	sqlCommand.CommandText += resultSB.ToString();
        //
		//	return true;
        //}
        #endregion
        // �� 2007.12.21 980081 d

		/// <summary>
		/// ���Ӑ搿�����z�}�X�^�ŏI���R�[�h���z�O�~�`�F�b�N����
		/// </summary>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>0:�ŏI���R�[�h�L�{�������z���O�~, 1:�ŏI���R�[�h�L�{�������z���O�~, 9:�ŏI���R�[�h��</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^�̎w����t�ȑO�̍ŏI���R�[�h���������A�������z���i�[�p�\�[�g���X�g��Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>		
		private int CheckCustDmdPrc_LastRecord(SqlConnection sqlConnection, string enterpriseCode, int customerCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // �� 2007.12.21 980081 c
            #region �����C�A�E�g(�R�����g�A�E�g)
            //// �� 20070327 18322 c ���Ӑ搿�����z�}�X�^�̃��C�A�E�g���ύX�ɂȂ����ׁA�C��
			////using (SqlCommand sqlCommand = new SqlCommand("SELECT AFCALDEMANDPRICERF FROM CUSTDMDPRCRF"
			////		   +" WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
			////		   +" AND CUSTDMDPRCRF.ADDUPDATELASTRECFLGRF=@FINDLASTFLG AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
			////		   +" AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDSECCODE"
			////		   , sqlConnection))
            //
            //string selectSql = "SELECT AFCALDEMANDPRICERF"
            //                 +  " FROM CUSTDMDPRCRF"
            //                 + " WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE"
            //                 +   " AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
            //                 +   " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
            //                 +   " AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDSECCODE"
            //                 ;
            //
			//using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection))
            //// �� 20070327 18322 c
            #endregion
            string selectSql = "SELECT AFCALDEMANDPRICERF"
                             +  " FROM CUSTDMDPRCRF"
                             + " WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE"
                             +   " AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
                             +   " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCUSTOMERCODE"
                             +   " AND CUSTDMDPRCRF.CUSTOMERCODERF=0"
                             +   " AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDSECCODE"
                             ;

			using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection))
            // �� 2007.12.21 980081 c
			{
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(enterpriseCode);

				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

				SqlParameter paraLastFlg = sqlCommand.Parameters.Add("@FINDLASTFLG", SqlDbType.Int);
				paraLastFlg.Value = SqlDataMediator.SqlSetInt32(1);

				SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
				paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

				// �S���_���R�[�h�݂̂�ΏۂƂ���
				SqlParameter paraSecCode = sqlCommand.Parameters.Add("@FINDSECCODE", SqlDbType.NChar);
				paraSecCode.Value = SqlDataMediator.SqlSetString(ALLSECCODE);

				using (SqlDataReader myReader = sqlCommand.ExecuteReader())
				{
					try
					{
						while (myReader.Read())
						{
							Int64 demandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
							if (demandPrice == 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
							else
							{
								status = 1;
							}
							break;
						}
					}
					finally
					{
						if (myReader != null) myReader.Close();
					}
				}
			}
			
			return status;
		}

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i���Ӑ�R�[�h�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i���Ӑ�R�[�h�j����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="startCode">���Ӑ�R�[�h�i�J�n�j</param>
        ///// <param name="endCode">���Ӑ�R�[�h�i�I���j</param>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <returns>�쐬����WHERE��</returns>
        ///// <br>Note       : ���Ӑ�R�[�h��WHERE�����쐬���ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private string MakeWhereStringCustomerCode(SqlCommand sqlCommand, int startCode, int endCode, string tableName)
		//{
		//	StringBuilder whereCustomerCode = new StringBuilder();
        //
		//	if ((startCode > 0) || (endCode > 0))
		//	{
		//		if (startCode == endCode)
		//		{
		//			whereCustomerCode.Append(" AND " + tableName + ".CUSTOMERCODERF=@FINDCUSTOMERCODE");
		//			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
		//			paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(startCode);
		//		}
		//		else
		//		{
		//			if (startCode > 0)
		//			{
		//				whereCustomerCode.Append(" AND " + tableName + ".CUSTOMERCODERF>=@FINDSTARTCUSTOMERCODE");
		//				SqlParameter paraStartCustomerCode = sqlCommand.Parameters.Add("@FINDSTARTCUSTOMERCODE", SqlDbType.Int);
		//				paraStartCustomerCode.Value = SqlDataMediator.SqlSetInt32(startCode);
		//			}
        //
		//			if ((endCode > 0) && (endCode != 999999999))
        //			{
        //				whereCustomerCode.Append(" AND " + tableName + ".CUSTOMERCODERF<=@FINDENDCUSTOMERCODE");
        //				SqlParameter paraEndCustomerCode = sqlCommand.Parameters.Add("@FINDENDCUSTOMERCODE", SqlDbType.Int);
        //				paraEndCustomerCode.Value = SqlDataMediator.SqlSetInt32(endCode);
        //			}
        //		}
        //	}
        //
        //	return whereCustomerCode.ToString();
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i���Ӑ�J�i�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i���Ӑ�J�i�j����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="startKana">���Ӑ�J�i�i�J�n�j</param>
        ///// <param name="endKana">���Ӑ�J�i�i�I���j</param>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <returns>�쐬����WHERE��</returns>
        ///// <br>Note       : ���Ӑ�J�i��WHERE�����쐬���ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private string MakeWhereStringKana(SqlCommand sqlCommand, string startKana, string endKana, string tableName)
		//{
		//	StringBuilder whereKana = new StringBuilder();
        //
		//	if ((startKana != string.Empty) && (startKana == endKana))
		//	{
		//		whereKana.Append(" AND " + tableName + ".KANARF LIKE @FINDSTARTKANA");
		//		SqlParameter paraStartKana = sqlCommand.Parameters.Add("@FINDSTARTKANA", SqlDbType.NVarChar);
		//		paraStartKana.Value = SqlDataMediator.SqlSetString(startKana + "%");
		//	}
		//	else
		//	{
		//		if (startKana != string.Empty)
		//		{
		//			//whereKana = " AND CUSTOMERRF.KANARF>='" + startKana + "'";
		//			whereKana.Append(" AND " + tableName + ".KANARF>=@FINDSTARTKANA");
		//			SqlParameter paraStartKana = sqlCommand.Parameters.Add("@FINDSTARTKANA", SqlDbType.NVarChar);
		//			paraStartKana.Value = SqlDataMediator.SqlSetString(startKana);
		//		}
        //
		//		if (endKana != string.Empty)
		//		{
        //			//whereKana += " AND CUSTOMERRF.KANARF<='" + this.StringAppendLength(endKana,'��',30) + "'";
        //			whereKana.Append(" AND " + tableName + ".KANARF<=@FINDENDKANA");
        //			SqlParameter paraEndKana = sqlCommand.Parameters.Add("@FINDENDKANA", SqlDbType.NVarChar);
        //			paraEndKana.Value = SqlDataMediator.SqlSetString(this.StringAppendLength(endKana,'��',30));
        //		}
        //	}
        //
        //	return whereKana.ToString();
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i�]�ƈ��R�[�h�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i�]�ƈ��R�[�h�j����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="employeeKind">�]�ƈ��敪</param>
        ///// <param name="startEmployeeCode">�]�ƈ��R�[�h�i�J�n�j</param>
        ///// <param name="endEmployeeCode">�]�ƈ��R�[�h�i�I���j</param>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <returns>�쐬����WHERE��</returns>
        ///// <br>Note       : �]�ƈ��R�[�h��WHERE�����쐬���ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private string MakeWhereStringEmployeeCode(SqlCommand sqlCommand, int employeeKind, string startEmployeeCode, string endEmployeeCode, string tableName)
		//{
		//	if (employeeKind < 0) return string.Empty;
		//	
		//	StringBuilder whereEmployeeCode = new StringBuilder();
		//	
		//	string employeeKindName = tableName + ".CUSTOMERAGENTCDRF";
		//	// �]�ƈ��敪���W���S���̏ꍇ
		//	if (employeeKind == EMPLOYEEKIND_BILLCOLLECTER)
		//	{
		//		employeeKindName = tableName + ".BILLCOLLECTERCDRF";
		//	}
        //
		//	if (startEmployeeCode != string.Empty)
		//	{
		//		//whereEmployeeCode.Append(" AND " + employeeKindName + ">='" + startEmployeeCode + "'");
		//		whereEmployeeCode.Append(" AND " + employeeKindName + ">=@FINDSTARTEMPLOYEECODE");
		//		SqlParameter paraStartEmployeeCode = sqlCommand.Parameters.Add("@FINDSTARTEMPLOYEECODE", SqlDbType.NChar);
		//		paraStartEmployeeCode.Value = SqlDataMediator.SqlSetString(startEmployeeCode);
		//	}
        //
		//	if (endEmployeeCode != string.Empty)
		//	{
		//		if (startEmployeeCode == string.Empty)
		//		{
		//			whereEmployeeCode.Append(" AND (" + employeeKindName + " IS NULL" +
		//									" OR " + employeeKindName + "<=@FINDENDEMPLOYEECODE)");
		//		}
		//		else
		//		{
		//			whereEmployeeCode.Append(" AND " + employeeKindName + "<=@FINDENDEMPLOYEECODE");
		//		}
		//		SqlParameter paraEndEmployeeCode = sqlCommand.Parameters.Add("@FINDENDEMPLOYEECODE", SqlDbType.NChar);
		//		paraEndEmployeeCode.Value = SqlDataMediator.SqlSetString(this.StringAppendLength(endEmployeeCode,'��',9));
		//	}
        //
		//	return whereEmployeeCode.ToString();
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i�v����j�����@�����ʏ탌�R�[�h�擾���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i�v����j�����@�����ʏ탌�R�[�h�擾����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="whereAddUpdate">�v�����WHERE��</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>true:����擾,false:�ُ�</returns>
        ///// <br>Note       : �v�����WHERE�����쐬���ĕԂ��܂��B�߂�l��false�̏ꍇ��SELECT�Ώۖ����Ƃ݂Ȃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringAddUpdateNormal(SqlCommand sqlCommand, out string whereAddUpdate, SeiKingetParameter parameter)
		//{
		//	whereAddUpdate = string.Empty;
        //
		//	StringBuilder whereAddUpdateBuilder = new StringBuilder();
        //
		//	if (((parameter.StartAddUpYearMonth > 0) || (parameter.EndAddUpYearMonth > 0)) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		if (parameter.StartAddUpYearMonth == parameter.EndAddUpYearMonth)
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH");
		//			SqlParameter paraStartAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
		//			paraStartAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.StartAddUpYearMonth);
		//		}
		//		else
		//		{
		//			if (parameter.StartAddUpYearMonth > 0)
		//			{
		//				whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF>=@FINDSTARTADDUPYEARMONTH");
		//				SqlParameter paraStartAddUpYearMonth = sqlCommand.Parameters.Add("@FINDSTARTADDUPYEARMONTH", SqlDbType.Int);
		//				paraStartAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.StartAddUpYearMonth);
		//			}
        //
		//			if (parameter.EndAddUpYearMonth > 0)
		//			{
		//				whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF<=@FINDENDADDUPYEARMONTH");
		//				SqlParameter paraEndAddUpYearMonth = sqlCommand.Parameters.Add("@FINDENDADDUPYEARMONTH", SqlDbType.Int);
		//				paraEndAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.EndAddUpYearMonth);
		//			}
		//		}
		//	}
		//	else if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		int startDate = TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.StartAddUpDate);
		//		int endDate = TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.EndAddUpDate);
		//		if (startDate == endDate)
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE");
		//			SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
		//			paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startDate);
		//		}
		//		else
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPDATERF>=@FINDSTARTADDUPDATE"
		//										+" AND CUSTDMDPRCRF.ADDUPDATERF<=@FINDENDADDUPDATE");
		//			SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPDATE", SqlDbType.Int);
		//			paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startDate);
		//			SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPDATE", SqlDbType.Int);
		//			paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endDate);
		//		}
		//	}
		//	else
		//	{
		//		return false;
		//	}
        //
		//	whereAddUpdate = whereAddUpdateBuilder.ToString();
        //
		//	return true;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i�v����j�����@�����ŏI���R�[�h�擾���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i�v����j�����@�����ŏI���R�[�h�擾����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="whereAddUpdate">�v�����WHERE��</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <returns>true:����擾,false:�ُ�</returns>
        ///// <br>Note       : �v�����WHERE�����쐬���ĕԂ��܂��B�߂�l��false�̏ꍇ��SELECT�Ώۖ����Ƃ݂Ȃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringAddUpdateLastRecord(SqlCommand sqlCommand, out string whereAddUpdate, SeiKingetParameter parameter)
		//{
		//	whereAddUpdate = string.Empty;
        //
		//	StringBuilder whereAddUpdateBuilder = new StringBuilder();
        //
		//	if (((parameter.StartAddUpYearMonth > 0) || (parameter.EndAddUpYearMonth > 0)) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		if (parameter.StartAddUpYearMonth > 0)
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF<@FINDADDUPYEARMONTH");
		//			SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
		//			paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.StartAddUpYearMonth);
		//		}
		//	}
		//	else if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPDATERF<@FINDADDUPDATE");
		//		SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
		//		paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.StartAddUpDate));
		//	}
		//	else
		//	{
		//		return false;
		//	}
        //
		//	whereAddUpdate = whereAddUpdateBuilder.ToString();
        //
		//	return true;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i�����j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i�����j����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="totalDay">����</param>
        ///// <param name="startTotalDay">�����i�J�n�j</param>
        ///// <param name="endTotalDay">�����i�I���j</param>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <returns>�쐬����WHERE��</returns>
        ///// <br>Note       : ������WHERE�����쐬���ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>
		//private string MakeWhereStringTotalDay(SqlCommand sqlCommand, int totalDay, int startTotalDay, int endTotalDay, string tableName)
		//{
		//	StringBuilder whereTotalDay = new StringBuilder();
        //
		//	if (totalDay > 0)
		//	{
		//		whereTotalDay.Append(" AND " + tableName + ".TOTALDAYRF=@FINDTOTALDAY");
		//		SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
		//		paraTotalDay.Value = SqlDataMediator.SqlSetInt32(totalDay);
		//	}
		//	else
		//	if ((startTotalDay > 0) || (endTotalDay > 0))
		//	{
		//		if (startTotalDay == endTotalDay)
		//		{
		//			whereTotalDay.Append(" AND " + tableName + ".TOTALDAYRF=@FINDTOTALDAY");
		//			SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
		//			paraTotalDay.Value = SqlDataMediator.SqlSetInt32(startTotalDay);
		//		}
		//		else
		//		{
		//			if (startTotalDay > endTotalDay)
		//			{
		//				int workDay = startTotalDay;
		//				startTotalDay = endTotalDay;
		//				endTotalDay = workDay;
		//			}
        //
		//			whereTotalDay.Append(" AND " + tableName + ".TOTALDAYRF>=@FINDSTARTTOTALDAY AND " + tableName + ".TOTALDAYRF<=@FINDENDTOTALDAY");
		//			SqlParameter paraStartTotalDay = sqlCommand.Parameters.Add("@FINDSTARTTOTALDAY", SqlDbType.Int);
		//			paraStartTotalDay.Value = SqlDataMediator.SqlSetInt32(startTotalDay);
		//			SqlParameter paraEndTotalDay = sqlCommand.Parameters.Add("@FINDENDTOTALDAY", SqlDbType.Int);
		//			paraEndTotalDay.Value = SqlDataMediator.SqlSetInt32(endTotalDay);
		//		}
		//	}
        //
		//	return whereTotalDay.ToString();
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i�l�E�@�l�敪�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i�l�E�@�l�敪�j����
        ///// </summary>
        ///// <param name="whereCorporateDivCode">�쐬�����l�E�@�l�敪��WHERE��</param>
        ///// <param name="corporateDivCodeList">�l�E�@�l�敪���X�g</param>
        ///// <param name="isAllCorporateDivCode">�S�l�E�@�l�敪�I��</param>
        ///// <returns>true:SELECT���s��,false:SELECT���s��Ȃ�</returns>
        ///// <br>Note       : �v�㋒�_��WHERE�����쐬���ĕԂ��܂��B�߂�l��false�̏ꍇ��SELECT�Ώۖ����Ƃ݂Ȃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringCorporateDivCode(out string whereCorporateDivCode, ArrayList corporateDivCodeList, bool isAllCorporateDivCode)
		//{
		//	whereCorporateDivCode = "";
		//	
		//	if (!isAllCorporateDivCode)
		//	{
		//		if (corporateDivCodeList.Count == 1)
		//		{
		//			whereCorporateDivCode = " AND CUSTOMERRF.CORPORATEDIVCODERF=" + corporateDivCodeList[0].ToString();
		//		}
		//		else
		//		if (corporateDivCodeList.Count > 0)
		//		{
		//			StringBuilder whereDivCode = new StringBuilder(" AND CUSTOMERRF.CORPORATEDIVCODERF IN (");
		//			for (int ix = 0; ix < corporateDivCodeList.Count; ix++)
		//			{
		//				if (ix != 0)
		//				{
		//					whereDivCode.Append(",");
		//				}
		//				whereDivCode.Append(corporateDivCodeList[ix].ToString());
		//			}					
		//			whereDivCode.Append(")");
		//			whereCorporateDivCode = whereDivCode.ToString();
		//		}
		//		else
		//		{
		//			return false;
		//		}
		//	}			
		//	
		//	return true;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i���Ӑ敪�̓R�[�h�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i���Ӑ敪�̓R�[�h�j����
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <returns>�쐬����WHERE��</returns>
        ///// <br>Note       : ���Ӑ敪�̓R�[�h��WHERE�����쐬���ĕԂ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2006.09.06</br>		
		//private string MakeWhereStringCustAnalysCode(SqlCommand sqlCommand, SeiKingetParameter parameter, string tableName)
		//{
		//	StringBuilder whereCustAnalysCode = new StringBuilder();
        //
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE1RF", parameter.StartCustAnalysCode1, parameter.EndCustAnalysCode1));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE2RF", parameter.StartCustAnalysCode2, parameter.EndCustAnalysCode2));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE3RF", parameter.StartCustAnalysCode3, parameter.EndCustAnalysCode3));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE4RF", parameter.StartCustAnalysCode4, parameter.EndCustAnalysCode4));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE5RF", parameter.StartCustAnalysCode5, parameter.EndCustAnalysCode5));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE6RF", parameter.StartCustAnalysCode6, parameter.EndCustAnalysCode6));
        //
		//	return whereCustAnalysCode.ToString();
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i���Ӑ�E�ԗ����̓R�[�h�͈́j ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i���Ӑ�E�ԗ����̓R�[�h�͈́j
        ///// </summary>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <param name="colName">�Ώۍ��ږ���</param>
        ///// <param name="start">�����J�n�l</param>
        ///// <param name="end">�����I���l</param>
        ///// <returns>�쐬����WHERE��</returns>
		//private string MakeWhereStringAnalysCodeRange(string tableName, string colName, int start, int end)
		//{
		//	string whereString = string.Empty;
		//	if (start == end)
		//	{
		//		whereString = string.Format(" AND {0}.{1}={2}", tableName, colName, start);
		//	}
		//	else
        //	{
        //		if (start != 0)	whereString += string.Format(" AND {0}.{1}>={2}", tableName, colName, start);
        //		if (end != 999)	whereString += string.Format(" AND {0}.{1}<={2}", tableName, colName, end);
        //	}
        //	return whereString;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region WHERE���쐬�i���_�R�[�h�j���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// WHERE���쐬�i���_�R�[�h�j����
        ///// </summary>
        ///// <param name="whereAddSecCode">�쐬�����v�㋒�_��WHERE��</param>
        ///// <param name="addUpSecCodeList">�v�㋒�_�I�����X�g</param>
        ///// <param name="isSelectAllSection">�S�БI��</param>
        ///// <param name="isOutputAllSecRec">�S���_���R�[�h�o��</param>
        ///// <param name="tableName">�e�[�u������</param>
        ///// <param name="ddName">���ږ���</param>
        ///// <returns>true:SELECT���s��,false:SELECT���s��Ȃ�</returns>
        ///// <br>Note       : �v�㋒�_��WHERE�����쐬���ĕԂ��܂��B�߂�l��false�̏ꍇ��SELECT�Ώۖ����Ƃ݂Ȃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringSectionCode(out string whereAddSecCode, ArrayList addUpSecCodeList, bool isSelectAllSection,
		//	bool isOutputAllSecRec, string tableName, string ddName)
		//{
		//	whereAddSecCode = "";
		//	
		//	StringBuilder whereSectionCode = new StringBuilder();
		//	if (isSelectAllSection)			
		//	{
		//		// �S���_���R�[�h���o�͂��Ȃ��ꍇ
		//		if (!isOutputAllSecRec)
		//		{
		//			whereSectionCode.Append(" AND " + tableName + "." + ddName + "<>'" + ALLSECCODE + "'");
		//		}
		//	}
		//	else
		//	{
		//		if (addUpSecCodeList.Count > 0)
		//		{
		//			if (addUpSecCodeList.Count == 1)
		//			{
		//				whereSectionCode.Append(" AND " + tableName + "." + ddName + " = '" + addUpSecCodeList[0] + "'");
		//			}
		//			else
		//			{
		//				whereSectionCode.Append(" AND " + tableName + "." + ddName + " IN (");
		//				for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
		//				{
		//					if (ix == 0)
		//					{
		//						// �S���_���R�[�h���o�͂���ꍇ
		//						if (isOutputAllSecRec)
		//						{
		//							whereSectionCode.Append("'" + ALLSECCODE + "'");
		//							if ((string)addUpSecCodeList[ix] == ALLSECCODE)
		//							{
		//								continue;
		//							}
		//							whereSectionCode.Append(",");
		//						}
		//					}
		//					else
		//					{
		//						// �S���_���R�[�h�o�́�true ���� ���_���X�g�ɑS���_�R�[�h�����݂���ꍇ
		//						if ((isOutputAllSecRec) && ((string)addUpSecCodeList[ix] == ALLSECCODE))
		//						{
		//							continue;
		//						}
		//						whereSectionCode.Append(",");
		//					}
		//					
		//					whereSectionCode.Append("'" + addUpSecCodeList[ix] + "'");
		//				}
		//				whereSectionCode.Append(")");
		//			}
		//		}
		//		else
		//		{
		//			// �S���_���R�[�h���o�͂���ꍇ
		//			if (isOutputAllSecRec)
		//			{
		//				whereSectionCode.Append(" AND " + tableName + "." + ddName + "='" + ALLSECCODE + "'");
		//			}
		//			else
		//			{
		//				return false;
		//			}
		//		}
		//	}
		//	
		//	whereAddSecCode = whereSectionCode.ToString();
		//	return true;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region �������z��񃊃X�g�i�[���� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// �������z��񃊃X�g�i�[����
        ///// </summary>
        ///// <param name="status">�X�e�[�^�X</param>
        ///// <param name="addSecCodeSortedList">�i�[�p�\�[�g���X�g</param>
        ///// <param name="myReader">SQLDataReader</param>
        ///// <br>Note       : SQLDataReader�̏��𐿋����z���i�[�p�\�[�g���X�g�ɃZ�b�g���܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private void SetListFromSQLReader(ref int status, ref SortedList addSecCodeSortedList, SqlDataReader myReader)
		//{
		//	if (addSecCodeSortedList == null)
		//	{
		//		addSecCodeSortedList = new SortedList();
		//	}
		//	
		//	string addUpSecCode;
		//	int customerCode;
		//	int addUpDate;
		//		
		//	while (myReader.Read())
		//	{
		//		addUpSecCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDUPSECCODERF"	));
		//		customerCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"	));
		//		addUpDate		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDUPDATERF"	));
		//			
		//		// �v�㋒�_���X�g�����`�F�b�N
		//		if (!addSecCodeSortedList.Contains(addUpSecCode))
		//		{
		//			SortedList list1 = new SortedList();
		//			addSecCodeSortedList.Add(addUpSecCode, list1);
		//		}
		//			
		//		SortedList customerCodeList = (SortedList)addSecCodeSortedList[addUpSecCode];
        //
		//		// �v�㋒�_->���Ӑ惊�X�g�����`�F�b�N
		//		if (!customerCodeList.Contains(customerCode))
		//		{
		//			SortedList list2 = new SortedList();
		//			customerCodeList.Add(customerCode, list2);
		//		}
		//			
		//		SortedList addUpDateList = (SortedList)customerCodeList[customerCode];
        //
		//		KingetCustDmdPrcWork wkCustDmdPrcWork = null;
		//			
		//		// �v�㋒�_->���Ӑ�->�v����t���X�g�����`�F�b�N
		//		if (!addUpDateList.Contains(addUpDate))
		//		{
		//			wkCustDmdPrcWork = new KingetCustDmdPrcWork();
		//			this.CopyToDataClassFromSelectData(ref wkCustDmdPrcWork, myReader);
		//			addUpDateList.Add(addUpDate, wkCustDmdPrcWork);
		//		}
		//		else
		//		{
        //			wkCustDmdPrcWork = (KingetCustDmdPrcWork)customerCodeList[addUpDate];
        //			this.CopyToDataClassFromSelectData(ref wkCustDmdPrcWork , myReader);
        //		}
        //		status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //	}
        //}
        #endregion
        // �� 2007.12.21 980081 d
        
		/// <summary>
		/// �R�l�N�V����������擾����
		/// </summary>
		/// <returns>�R�l�N�V����������</returns>
		/// <br>Note       : �R�l�N�V������������擾���ĕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		private string GetConnectionText()
		{
			//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
			if (connectionText == null) connectionText = "";
			return connectionText;
		}

        // �� 2007.12.21 980081 d
        #region �I�v�V�����L���m�F���� ���g�p�̂��ߍ폜
        ///// <summary>
		///// �I�v�V�����L���m�F����
		///// </summary>
		///// <param name="softwareCode">�R�[�h</param>
		///// <returns>true:�L��,false:����</returns>
		///// <br>Note       : �w��̃\�t�g�E�F�A�R�[�h�̃I�v�V���������݂��邩�ǂ������m�F���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2006.02.21</br>		
		//private	bool CheckSoftwarePurchased(string softwareCode)
		//{
		//	bool exists = false;
		//	ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
		//	if ((int)loginInfo.SoftwarePurchasedCheckForCompany(softwareCode) > 0) exists = true;
		//	return exists;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 20070417 18322 d ���g�p�̈׍폜
        #region ���z�����Ӑ��������i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ���z�����Ӑ�������
		///// </summary>
		///// <param name="addSecCodeSortedList">�������z���i�[�p�\�[�g���X�g</param>
		///// <param name="sqlConnection">SQLConnection</param>
		///// <param name="totalDayScheduleSortedList">�����X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : �X�P�W���[���i�[�p�\�[�g���X�g�����ɉ��z�����ӂ𐶐����Đ������z���i�[�p�\�[�g���X�g�ɃZ�b�g���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int CreateVirtualCustDmdPrc(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection,
		//	SortedList totalDayScheduleSortedList, SortedList customerScheduleSortedList, SeiKingetParameter parameter, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//	
		//	if (addSecCodeSortedList.Count == 0) return status;
		//
        //    // �� 20070117 18322 d
        //    #region MA.NS�ł�KINSET�N���X���g�p���Ȃ��Ă��悳���Ȃ̂ō폜
        //    //// KINSET�N���X
		//	//Kinset kinset = new Kinset();
		//	//
		//	//// ����p�ʓ����I�v�V�����L���m�F
		//	//if (this.CheckSoftwarePurchased(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SeparatePayment))
		//	//{
		//	//	kinset.SetMode = 1;
        //    //}
        //    #endregion
        //    // �� 20070117 18322 d
		//
		//	int startDate;
		//	int endDate;
		//	
		//	// �v�㋒�_
		//	foreach (DictionaryEntry addSecCode in addSecCodeSortedList)
		//	{
		//		// ���Ӑ�R�[�h
		//		foreach (DictionaryEntry customerCode in (SortedList)addSecCode.Value)
		//		{
		//			SortedList addUpDateList = (SortedList)customerCode.Value;
		//			int addUpDate = (int)addUpDateList.GetKey(addUpDateList.Count-1);
		//			int addUpYearMonth;
		//			
		//			KingetCustDmdPrcWork current = ((KingetCustDmdPrcWork)addUpDateList[addUpDate]).Clone();
		//			
		//			SortedList scheduleDateList;
		//			
		//			// ���Ӑ�X�P�W���[�������݂���ꍇ
		//			if (customerScheduleSortedList.Contains(current.CustomerCode))
		//			{
		//				// ���o���t�͈͎擾(���Ӑ�X�P�W���[���x�[�X)
		//				if (!this.GetDateSpanFromCustomerSchedule(out startDate, out endDate, current.CustomerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// �X�P�W���[���v����t���X�g���擾
		//				scheduleDateList = (SortedList)customerScheduleSortedList[current.CustomerCode];
		//			}
		//			else
		//			{
		//				// ���o���t�͈͎擾(�����X�P�W���[���x�[�X)
		//				if (!this.GetDateSpanFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// �X�P�W���[���v����t���X�g���擾
		//				scheduleDateList = (SortedList)totalDayScheduleSortedList[current.TotalDay];
		//			}
		//			
		//			// �v����t���I�����̏ꍇ�A���z�����ӂ��쐬����
		//			while (addUpDate <= endDate)
		//			{
		//				// �X�P�W���[�����X�g��莟��v����t���擾
		//				int index = scheduleDateList.IndexOfKey(addUpDate);
		//				index++;
		//				if (index >= scheduleDateList.Count)
		//				{
		//					break;
		//				}
		//				addUpDate		= (int)scheduleDateList.GetKey(index);
		//				addUpYearMonth	= TDateTime.DateTimeToLongDate("YYYYMM", ((RetAddUpDateItemTypeDInf)scheduleDateList.GetByIndex(index)).CAddUpUpdYearMonth);
		//				
		//				// ����p�c�������敪���擾����Ă��Ȃ��ꍇ
		//				if (kingetData.MinusVarCstBlAdjstCd == -1)
		//				{
		//					int minusVarCstBlAdjstCd = -1;
		//					int bfRmonCalcDivCd		 = -1;	// 2006.05.31 ADD ����@����
		//
		//					// ����p�c�������敪�擾
		//					#region 2006.05.31 DEL ����@����
		//					//status = ReadBillAllSt(ref minusVarCstBlAdjstCd, sqlConnection, parameter.EnterpriseCode);
		//					#endregion
		//					status = ReadBillAllSt(ref minusVarCstBlAdjstCd, ref bfRmonCalcDivCd, sqlConnection, parameter.EnterpriseCode);	// 2006.05.31 ADD ����@����
		//					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
		//						if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
		//						{
		//							base.WriteErrorLog(null,"�v���O�����G���[�B�����ݒ�}�X�^���o�^����Ă��܂���");
		//						}
		//						return status;
		//					}
		//
		//					kingetData.MinusVarCstBlAdjstCd	= minusVarCstBlAdjstCd;
		//					kingetData.BfRmonCalcDivCd		= bfRmonCalcDivCd;		// 2006.05.31 ADD ����@����
		//					
		//					if (kingetData.MinusVarCstBlAdjstCd != 0){kingetData.AdjustMinusVCst = true;}
		//				}
		//
        //                // �� 20070117 18322 c MA.NS�p�ɕύX
        //                #region SF KINSET��ʂ��Ď���̉��z�ӂ��쐬(�R�����g�A�E�g)
        //                //// KINSET��ʂ��Ď���̉��z�ӂ��쐬
		//				//#region 2006.05.31 DEL ����@����
		//				////current = this.GetVirtualCustDmdPrc(ref kinset, current, addUpDate, addUpYearMonth, kingetData.AdjustMinusVCst);
		//				//#endregion
        //                //current = this.GetVirtualCustDmdPrc(ref kinset, current, addUpDate, addUpYearMonth, kingetData);	// 2006.05.31 ADD ����@����
        //                #endregion
		//
        //                // ����̉��z�ӂ��쐬
        //                current = this.GetVirtualCustDmdPrc(current, addUpDate, addUpYearMonth, kingetData);
        //                // �� 20070117 18322 c 
		//				
		//				// �J�n��������v����t���I�����̏ꍇ�A���z�̐������z�����i�[����
		//				if ((addUpDate >= startDate) && (addUpDate <= endDate))
		//				{
		//					if (!addUpDateList.Contains(addUpDate))
		//					{
		//						addUpDateList.Add(addUpDate, current.Clone());
		//					}
		//				}
		//			}
		//		}
		//	}
		//	return status;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 2007.12.21 980081 d
        #region �����S�̐ݒ�Ǎ��ݏ��� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// �����S�̐ݒ�Ǎ��ݏ���
        ///// </summary>
        ///// <param name="minusVarCstBlAdjstCd">����p�c�������敪</param>
        ///// <param name="bfRmonCalcDivCd">�O����Z��敪</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �w���ƃR�[�h�̐����ݒ��ǂݍ��݁A����p�c�������敪��Ԃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
		//#region 2006.05.31 DEL ����@����
		////private int ReadBillAllSt(ref int minusVarCstBlAdjstCd, SqlConnection sqlConnection, string enterpriseCode)
		//#endregion
		//private int ReadBillAllSt(ref int minusVarCstBlAdjstCd, ref int bfRmonCalcDivCd, SqlConnection sqlConnection, string enterpriseCode)	// 2006.05.31 ADD ����@����
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand("SELECT"
		//		+" MINUSVARCSTBLADJSTCDRF"
		//		+",BFRMONCALCDIVCDRF"		// 2006.05.31 ADD ����@����
		//		+" FROM BILLALLSTRF"
		//		+" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLALLSTCDRF=0"
		//		, sqlConnection))
		//	{
		//		SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//		findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				if (myReader.Read())
		//				{
		//					minusVarCstBlAdjstCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINUSVARCSTBLADJSTCDRF"));
		//					bfRmonCalcDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BFRMONCALCDIVCDRF"		));	// 2006.05.31 ADD ����@����
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
        //
		//	return status;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 20070417 18322 d ���g�p�̈׍폜
        #region �c���O���R�[�h�쐬�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// �c���O���R�[�h�쐬����
		///// </summary>
		///// <param name="addSecCodeSortedList">�������z���i�[�p�\�[�g���X�g</param>
		///// <param name="sqlConnection">SQLConnection</param>
		///// <param name="totalDayScheduleSortedList">�����X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <br>Note       : �c���O�̓��Ӑ��ΏۂƂ��ăX�P�W���[���i�[�p�\�[�g���X�g�����ɉ��z�����ӂ𐶐�����
		/////					 �������z���i�[�p�\�[�g���X�g�ɃZ�b�g���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private void MakeZeroCustomer(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, SortedList totalDayScheduleSortedList,
		//	SortedList customerScheduleSortedList, SeiKingetParameter parameter)
		//{
		//	// ���_���擾
		//	SortedList sectionCodeList;
		//	int status = this.SearchSection(out sectionCodeList, sqlConnection, parameter);
		//	
		//	if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
		//		(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
		//	{
		//		// �S���_���R�[�h�o�́�true�̏ꍇ�́A�S���_�R�[�h�������R�[�h���쐬
		//		if (parameter.IsOutputAllSecRec)
		//		{
		//			if (!sectionCodeList.Contains(ALLSECCODE))
		//			{
		//				sectionCodeList.Add(ALLSECCODE, null);
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//		}
		//	}
		//	
		//	if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//	{
		//		return;
		//	}
		//	
		//	
		//	// ���Ӑ���擾
		//	Hashtable customerTable;
		//	status = this.SearchCustomer(out customerTable, sqlConnection, parameter);
		//	if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//	{
		//		return;
		//	}
		//	
		//	// ���_���Ń��[�v
		//	foreach (DictionaryEntry de1 in sectionCodeList)
		//	{
		//		// ���_�R�[�h�������ꍇ�͒ǉ�
		//		string sectionCode = (string)de1.Key;
		//		if (!addSecCodeSortedList.Contains(sectionCode))
		//		{
		//			addSecCodeSortedList.Add(sectionCode, new SortedList());
		//		}
		//		
		//		SortedList setCustomerList = (SortedList)addSecCodeSortedList[sectionCode];
		//		
		//		// ���Ӑ���Ń��[�v
		//		foreach (DictionaryEntry de2 in customerTable)
		//		{
		//			int customerCode = (int)de2.Key;
		//			KingetCustDmdPrcWork current = ((KingetCustDmdPrcWork)de2.Value).Clone();
		//			
		//			if (current.TotalDay <= 0)
		//			{
		//				continue;
		//			}
		//			
		//			// ���Ӑ�R�[�h�������ꍇ�͒ǉ�
		//			if (!setCustomerList.Contains(customerCode))
		//			{
		//				setCustomerList.Add(customerCode, new SortedList());
		//			}
		//			
		//			SortedList addUpDateList = (SortedList)setCustomerList[customerCode];
		//			
		//			int startDate, endDate;
		//			SortedList scheduleDateList;
		//			
		//			// ���Ӑ�X�P�W���[�������݂���ꍇ
		//			if (customerScheduleSortedList.Contains(customerCode))
		//			{
		//				// ���o���t�͈͎擾(���Ӑ�X�P�W���[���x�[�X)
		//				if (!this.GetDateSpanFromCustomerSchedule(out startDate, out endDate, customerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// �X�P�W���[���v����t���X�g���擾
		//				scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//			}
		//			else
		//			{
		//				// ���o���t�͈͎擾(�����X�P�W���[���x�[�X)
		//				if (!this.GetDateSpanFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// �X�P�W���[���v����t���X�g���擾
		//				scheduleDateList = (SortedList)totalDayScheduleSortedList[current.TotalDay];
		//			}
		//			
		//			int addUpDate = startDate;
		//			
		//			// �v����t���I�����̏ꍇ�A���z�����ӂ��쐬����
		//			while (addUpDate <= endDate)
		//			{
		//				// �J�n��������v����t���I�����̏ꍇ�A���z�̐������z�����i�[����
		//				if ((addUpDate >= startDate) && (addUpDate <= endDate))
		//				{
		//					if (!addUpDateList.Contains(addUpDate))
		//					{
		//						// �X�P�W���[�����X�g���Y���v����t�̃f�[�^���擾
		//						RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)scheduleDateList[addUpDate];
		//						current.AddUpSecCode	= sectionCode;
		//						current.CustomerCode	= customerCode;
		//						current.AddUpDate		= retAddUpDateItemTypeDInf.CAddUpUpdDate;
		//
        //                        // �� 20070117 18322 c MA.NS�p�ɕύX
		//						//current.AddUpYearMonth	= TDateTime.DateTimeToLongDate("YYYYMM", retAddUpDateItemTypeDInf.CAddUpUpdYearMonth);
		//
        //                        current.AddUpYearMonth = retAddUpDateItemTypeDInf.CAddUpUpdYearMonth;
        //                        // �� 20070117 18322 c
		//						
		//						addUpDateList.Add(addUpDate, current.Clone());
		//					}
		//				}
		//				
		//				// �X�P�W���[�����X�g��莟��v����t���擾
		//				int index = scheduleDateList.IndexOfKey(addUpDate);
		//				index++;
		//				if (index >= scheduleDateList.Count)
		//				{
		//					break;
		//				}
		//				addUpDate = (int)scheduleDateList.GetKey(index);
		//			}
		//		}
		//	}
        //}
        #endregion
        // �� 20070417 18322 d


        // �� 20070117 18322 c MA.NS�p�ɕύX
        #region SF ���z�����Ӑ��������C���^�[�t�F�[�X(�R�����g�A�E�g)
        ///// <summary>
		///// ���z�����Ӑ�������
		///// </summary>
		///// <param name="kinset">KINSET�N���X</param>
		///// <param name="wkCustDmdPrcWork">�Z�茳�������z���</param>
		///// <param name="addUpDate">�v����t</param>
		///// <param name="addUpYearMonth">�v��N��</param>
		///// <param name="kingetData">����p�c�������敪</param>
		///// <br>Note       : �X�P�W���[���i�[�p�\�[�g���X�g�����ɉ��z�����ӂ𐶐����Đ������z���i�[�p�\�[�g���X�g�ɃZ�b�g���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>
		//#region 2006.05.31 DEL ����@����
		////private KingetCustDmdPrcWork GetVirtualCustDmdPrc(ref Kinset kinset, KingetCustDmdPrcWork wkCustDmdPrcWork,
		////    Int32 addUpDate, Int32 addUpYearMonth, bool adjustMinusVCst)
		//#endregion
		//private KingetCustDmdPrcWork GetVirtualCustDmdPrc(ref Kinset kinset, KingetCustDmdPrcWork wkCustDmdPrcWork,
		//	Int32 addUpDate, Int32 addUpYearMonth, SeiKingetData kingetData)			// 2006.05.31 ADD ����@����
        #endregion

        // �� 2007.12.21 980081 d
        #region ���z�����Ӑ������� ���g�p�̂��ߍ폜
        ///// <summary>
        ///// ���z�����Ӑ�������
        ///// </summary>
        ///// <param name="wkCustDmdPrcWork">�Z�茳�������z���</param>
        ///// <param name="addUpDate">�v����t</param>
        ///// <param name="addUpYearMonth">�v��N��</param>
        ///// <param name="kingetData">����p�c�������敪</param>
        ///// <br>Note       : �X�P�W���[���i�[�p�\�[�g���X�g�����ɉ��z�����ӂ𐶐����Đ������z���i�[�p�\�[�g���X�g�ɃZ�b�g���܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>
		//private KingetCustDmdPrcWork GetVirtualCustDmdPrc(KingetCustDmdPrcWork wkCustDmdPrcWork,
        //    			                                  Int32 addUpDate,
        //                                                  Int32 addUpYearMonth,
        //                                                  SeiKingetData kingetData)
        //// �� 20070117 18322 c
        //{
        //    // �� 20070117 18322 c MA.NS�p�ɕύX
        //    #region SF ���z�����Ӑ��������i�S�ăR�����g�A�E�g�j
        //    //kinset.Clear();
		//	//kinset.AcpOdrTtlLMBl	= wkCustDmdPrcWork.AfCalTtlAOdrBlDmd;
		//	//kinset.TtlLMVarCstBlnce	= wkCustDmdPrcWork.AfCalTtlVCstBlDmd;
		//	//#region 2006.05.31 DEL ����@����
		//	////kinset.AdjustMinusVCst	= adjustMinusVCst;
		//	//#endregion
		//	//// 2006.05.31 ADD START ����@����
		//	//kinset.AdjustMinusVCst	= kingetData.AdjustMinusVCst;
		//	//kinset.CalcMode			= kingetData.BfRmonCalcDivCd;
		//	//// 2006.05.31 ADD END ����@����
		//	//
		//	//kinset.Calculate();
		//	//
		//	//KingetCustDmdPrcWork kingetCustDmdPrcWork = wkCustDmdPrcWork.Clone();
		//	//
		//	//kingetCustDmdPrcWork.AddUpDate				= TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
        //    //kingetCustDmdPrcWork.AddUpYearMonth         = addUpYearMonth;
		//	//
		//	//kingetCustDmdPrcWork.TleDmdSlipLgCt			= 0;
		//	//kingetCustDmdPrcWork.TleDmdSlipGeCt			= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCt	= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCt	= 0;
		//	//kingetCustDmdPrcWork.TleDmdSlipLgCnt		= 0;
		//	//kingetCustDmdPrcWork.TleDmdSlipGeCnt		= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCnt	= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCnt	= 0;
		//	//kingetCustDmdPrcWork.AcpOdrTtlSalesDmd		= 0;
		//	//kingetCustDmdPrcWork.AcpOdrDiscTtlDmd		= 0;
		//	//kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd	= 0;
		//	//kingetCustDmdPrcWork.DmdVarCst				= 0;
		//	//kingetCustDmdPrcWork.TtlTaxtinDmdVarCst		= 0;
		//	//kingetCustDmdPrcWork.TtlTaxFreeDmdVarCst	= 0;
		//	//kingetCustDmdPrcWork.VarCst1TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst2TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst3TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst4TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst5TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst6TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst7TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst8TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst9TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst10TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst11TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst12TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst13TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst14TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst15TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst16TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst17TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst18TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst19TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst20TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.TtlDmdVarCstConsTax	= 0;
		//	//
		//	//kingetCustDmdPrcWork.AcpOdrTtlLMBlDmd		= kinset.AcpOdrTtlLMBl		;
		//	//kingetCustDmdPrcWork.TtlLMVarCstDmdBlnce	= kinset.TtlLMVarCstBlnce	;
		//	//
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDepoDmd	= 0;
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDsDmd	= 0;
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDmd		= 0;
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDsDmd		= 0;
		//	//
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrDepoDmd	= kinset.AfCalTtlAOdrDepo	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstDepoDmd	= kinset.AfCalTtlVCstDepo	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrDpDsDmd	= kinset.AfCalTtlAOdrDpDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstDpDsDmd	= kinset.AfCalTtlVCstDpDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrBlCFDmd	= kinset.AfCalTtlAOdrBlCF	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstBlCFDmd	= kinset.AfCalTtlVCstBlCF	;
		//	//kingetCustDmdPrcWork.AcpOdrTtlSalesDmd		= kinset.AcpOdrTtlSales		;
		//	//kingetCustDmdPrcWork.DmdVarCst				= kinset.TtlVarCst			;
		//	//kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd	= kinset.AcpOdrTtlConsTax	;
		//	//kingetCustDmdPrcWork.TtlDmdVarCstConsTax	= kinset.TtlVarCstConsTax	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDmd		= kinset.AfCalTtlAOdrRM		;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstBfRMDmd	= kinset.AfCalTtlVCstBfRM	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDsDmd	= kinset.AfCalTtlAOdrRMDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstRMDsDmd	= kinset.AfCalTtlVCstRMDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrBlDmd		= kinset.AfCalTtlAOdrBl		;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstBlDmd		= kinset.AfCalTtlVCstBl		;
		//	//kingetCustDmdPrcWork.AfCalDemandPrice		= kinset.AfCalPrice			;
		//	//
		//	//kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd	= wkCustDmdPrcWork.AcpOdrTtlLMBlDmd		;
		//	//kingetCustDmdPrcWork.Ttl2TmBfVarCstDmdBl	= wkCustDmdPrcWork.TtlLMVarCstDmdBlnce	;
		//	//kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd	= wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd	;
		//	//kingetCustDmdPrcWork.Ttl3TmBfVarCstDmdBl	= wkCustDmdPrcWork.Ttl2TmBfVarCstDmdBl;
        //    #endregion
        ////
        ////    #region MA.NS ���z�����Ӑ�������
        //    KingetCustDmdPrcWork kingetCustDmdPrcWork = wkCustDmdPrcWork.Clone();
        //
        //    // �v��N����
        //    kingetCustDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
        //    // �v��N��
        //    kingetCustDmdPrcWork.AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM", addUpYearMonth); ;
        //    // �O�񐿋����z
        //    kingetCustDmdPrcWork.LastTimeDemand = wkCustDmdPrcWork.AfCalDemandPrice;
        //
        //    // ����������z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeDmdNrml = 0;
        //    // ����萔���z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = 0;
        //    // ����l���z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeDisDmdNrml = 0;
        //    // ���񃊃x�[�g�z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdNrml = 0;
        //    // ����������z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeDmdDepo = 0;
        //    // ����萔���z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdDepo = 0;
        //    // ����l���z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeDisDmdDepo = 0;
        //    // ���񃊃x�[�g�z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdDepo = 0;
        //    // ����J�z�c���i�����v�j
        //    kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = 0;
        //    // ���񔄏���z
        //    kingetCustDmdPrcWork.ThisTimeSales = 0;
        //    // ���񔄏�����
        //    kingetCustDmdPrcWork.ThisSalesTax = 0;
        //    // �x���C���Z���e�B�u�z���v�i�Ŕ����j
        //    kingetCustDmdPrcWork.TtlIncDtbtTaxExc = 0;
        //    // �x���C���Z���e�B�u�z���v�i�Łj
        //    kingetCustDmdPrcWork.TtlIncDtbtTax = 0;
        //    // ���E�㍡�񔄏���z
        //    kingetCustDmdPrcWork.OfsThisTimeSales = 0;
        //    // ���E�㍡�񔄏�����
        //    kingetCustDmdPrcWork.OfsThisSalesTax = 0;
        //    // ���E��O�őΏۊz
        //    kingetCustDmdPrcWork.ItdedOffsetOutTax = 0;
        //    // ���E����őΏۊz
        //    kingetCustDmdPrcWork.ItdedOffsetInTax = 0;
        //    // ���E���ېőΏۊz
        //    kingetCustDmdPrcWork.ItdedOffsetTaxFree = 0;
        //    // ���E��O�ŏ����
        //    kingetCustDmdPrcWork.OffsetOutTax = 0;
        //    // ���E����ŏ����
        //    kingetCustDmdPrcWork.OffsetInTax = 0;
        //    // ����O�őΏۊz
        //    kingetCustDmdPrcWork.ItdedSalesOutTax = 0;
        //    // ������őΏۊz
        //    kingetCustDmdPrcWork.ItdedSalesInTax = 0;
        //    // �����ېőΏۊz
        //    kingetCustDmdPrcWork.ItdedSalesTaxFree = 0;
        //    // ����O�Ŋz
        //    kingetCustDmdPrcWork.SalesOutTax = 0;
        //    // ������Ŋz
        //    kingetCustDmdPrcWork.SalesInTax = 0;
        //    // �x���O�őΏۊz
        //    kingetCustDmdPrcWork.ItdedPaymOutTax = 0;
        //    // �x�����őΏۊz
        //    kingetCustDmdPrcWork.ItdedPaymInTax = 0;
        //    // �x����ېőΏۊz
        //    kingetCustDmdPrcWork.ItdedPaymTaxFree = 0;
        //    // �x���O�ŏ����
        //    kingetCustDmdPrcWork.PaymentOutTax = 0;
        //    // �x�����ŏ����
        //    kingetCustDmdPrcWork.PaymentInTax = 0;
        //    // ����œ]�ŕ���
        //    kingetCustDmdPrcWork.ConsTaxLayMethod = 0;
        //    
        //    // ����ŗ�
        //    kingetCustDmdPrcWork.ConsTaxRate = 0;
        //    // �[�������敪
        //    kingetCustDmdPrcWork.FractionProcCd = 0;
        //    // �v�Z�㐿�����z
        //    kingetCustDmdPrcWork.AfCalDemandPrice = 0;
        //    
        //    // ��2��O�c���i�����v�j
        //    kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = wkCustDmdPrcWork.LastTimeDemand;
        //    // ��3��O�c���i�����v�j
        //    kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
        //    
        //    // ���������ʔ�
        //    kingetCustDmdPrcWork.DmdProcNum = 0;
        //    // �����X�V�J�n�N����
        //    kingetCustDmdPrcWork.StartCAddUpUpdDate = DateTime.MinValue;
        //    // �O������X�V�N����
        //    kingetCustDmdPrcWork.LastCAddUpUpdDate = DateTime.MinValue;
        //    
        //    // ��������v�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl = kingetCustDmdPrcWork.ThisTimeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
        //    // ��������v�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
        //    // ��������v
        //    kingetCustDmdPrcWork.ThisTimeDmdTtl     = kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl
        //                                            + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;
        //    #endregion
        //    // �� 20070117 18322 c
        //
        //    return kingetCustDmdPrcWork;
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 20070417 18322 d MA.NS�ł͂���Ȃ��Ǝv����׍폜
        #region �������z���i�[�p�\�[�g���X�g��ArrayList������������׎擾
        ///// <summary>
		///// �������z���i�[�p�\�[�g���X�g��ArrayList������������׎擾
		///// </summary>
		///// <param name="list">�������z��񃊃X�g</param>
		///// <param name="addSecCodeSortedList">�������z���i�[�p�\�[�g���X�g</param>
		///// <param name="totalDayScheduleSortedList">�����X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="kingetData">����KINGET�f�[�^�i�[�N���X</param>
        ///// <br>Note       : �������z���i�[�p�\�[�g���X�g��ArrayList�ɕϊ����܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int CopyToArrayListFromSortedList(out ArrayList list, SortedList addSecCodeSortedList, SortedList totalDayScheduleSortedList,
		//	SortedList customerScheduleSortedList, SeiKingetParameter parameter, SqlConnection sqlConnection, ref SeiKingetData kingetData)
		//{
		//	list = new ArrayList();
		//	int startDate;
		//	int endDate;
		//	
		//	Hashtable customerCodeTable = new Hashtable();
		//	
		//	// �v�㋒�_
		//	foreach (DictionaryEntry addSecCode in addSecCodeSortedList)
		//	{
		//		// ���Ӑ�R�[�h
		//		foreach (DictionaryEntry customerCode in (SortedList)addSecCode.Value)
		//		{
		//			SortedList addUpDateList = (SortedList)customerCode.Value;
		//			if (addUpDateList.Count == 0)
		//			{
		//				continue;
		//			}
		//			KingetCustDmdPrcWork current = (KingetCustDmdPrcWork)addUpDateList[(int)addUpDateList.GetKey(0)];
		//			
		//			SortedList scheduleDateList;
		//			
		//			// ���Ӑ�X�P�W���[�������݂���ꍇ
		//			if (customerScheduleSortedList.Contains(current.CustomerCode))
		//			{
		//				// ���o���t�͈͎擾(���Ӑ�X�P�W���[���x�[�X)
		//				if (!this.GetDateSpanFromCustomerSchedule(out startDate, out endDate, current.CustomerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// �X�P�W���[���v����t���X�g���擾
		//				scheduleDateList = (SortedList)customerScheduleSortedList[current.CustomerCode];
		//			}
		//			else
		//			{
		//				// ���o���t�͈͎擾(�����X�P�W���[���x�[�X)
		//				if (!this.GetDateSpanFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// �X�P�W���[���v����t���X�g���擾
		//				scheduleDateList = (SortedList)totalDayScheduleSortedList[current.TotalDay];
		//			}
		//			
		//			// �v����t
		//			foreach (DictionaryEntry addUpDate in (SortedList)customerCode.Value)
		//			{
		//				// ���t�͈͓��̂݃Z�b�g����
		//				if (((int)addUpDate.Key >= startDate) && ((int)addUpDate.Key <= endDate))
		//				{
		//					KingetCustDmdPrcWork kingetCustDmdPrcWork = (KingetCustDmdPrcWork)addUpDate.Value;
		//					int keyAddUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
		//					// �v����t�͈͂��Z�b�g����
		//					if (scheduleDateList.Contains(keyAddUpDate))
		//					{
		//						RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)scheduleDateList[keyAddUpDate];
		//						kingetCustDmdPrcWork.StartDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//						kingetCustDmdPrcWork.EndDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//					}
		//					list.Add(kingetCustDmdPrcWork);
		//				}
		//			}
		//			
		//			// ���Ӑ�R�[�h���i�[�i��x�A�������������������擾�������Ӑ�͂����܂Łj
		//			if (customerCodeTable.Contains(customerCode.Key))
		//			{
		//				continue;
		//			}
		//			customerCodeTable.Add(customerCode.Key, null);
		//			
		//			// ���Ӑ�X�P�W���[�������݂���ꍇ
		//			if (customerScheduleSortedList.Contains(current.CustomerCode))
		//			{
		//				// ���׎擾�p���o���t�͈͎擾
		//				if (!this.GetDateSpanForDetailFromCustomerSchedule(out startDate, out endDate, current.CustomerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//			}
		//			else
		//			{
		//				// ���׎擾�p���o���t�͈͎擾
		//				if (!this.GetDateSpanForDetailFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//			}
		//			
		//			// ������������擾����ꍇ
		//			if (kingetData.GetDmdSalesFlg)
		//			{
		//				// ���_���X�g
		//				ArrayList addUpSecCodeList = (ArrayList)parameter.AddUpSecCodeList.Clone();
		//				
		//				// �S���_�R�[�h���o�͂���ꍇ�́A��������E�����̋��_���X�g���N���A�i�S�Е��擾����j
		//				if (parameter.IsOutputAllSecRec)
		//				{
		//					addUpSecCodeList.Clear();
		//				}
		//				else
		//				{
		//					bool hasAllSec = false;
		//					foreach (string secCode in addUpSecCodeList)
		//					{
		//						if (secCode == ALLSECCODE)
		//						{
		//							hasAllSec = true;
		//							break;
		//						}
		//					}
		//					if (hasAllSec)	{addUpSecCodeList.Clear();}
		//				}
		//				
		//				// ���������񒊏o
		//				ArrayList dmdSalesWorkList;
		//				if (kingetData.DmdSalesDB == null)	{kingetData.DmdSalesDB = new KingetDmdSalesDB();}
		//				int code = (int)customerCode.Key;
		//				int status = kingetData.DmdSalesDB.Search(out dmdSalesWorkList, parameter.EnterpriseCode,
		//					addUpSecCodeList, code, startDate, endDate);
		//					
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
        //                    // �� 20070123 18322 c MA.NS�p�ɕύX
		//					//foreach (DmdSalesWork dmdSalesWork in dmdSalesWorkList)
		//					//{
		//					//	kingetData.DmdSalesWorkList.Add(dmdSalesWork);
		//					//}
		//
		//					foreach (SalesSlipWork salesSalesWork in dmdSalesWorkList)
		//					{
		//						kingetData.DmdSalesWorkList.Add(salesSalesWork);
		//					}
        //                    // �� 20070123 18322 c
		//				}
		//				else
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//				{
		//				}
		//				else
		//				{
		//					return status;
		//				}
		//				
		//				// ������񒊏o
		//				ArrayList depsitMainWorkList;
		//				if (kingetData.DepsitMainDB == null) {kingetData.DepsitMainDB = new KingetDepsitMainDB();}
		//				code = (int)customerCode.Key;
		//				status = kingetData.DepsitMainDB.Search(out depsitMainWorkList, parameter.EnterpriseCode,
		//					addUpSecCodeList, code, startDate, endDate);
		//					
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//					foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
		//					{
		//						kingetData.DepsitMainWorkList.Add(depsitMainWork);
		//					}
		//				}
		//				else
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//				{
		//				}
		//				else
		//				{
		//					return status;
		//				}
		//			}
		//		}
		//	}
		//	return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        #endregion

        // �� 2007.12.21 980081 d
        #region ���o���t�͈͎擾(�����X�P�W���[���x�[�X) ���g�p�̂��ߍ폜
        ///// <summary>
		///// ���o���t�͈͎擾(�����X�P�W���[���x�[�X)
		///// </summary>
		///// <param name="startDate">�J�n���t</param>
		///// <param name="endDate">�I�����t</param>
		///// <param name="totalDay">����</param>
		///// <param name="totalDayScheduleSortedList">�����X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <br>Note       : �����X�P�W���[�����X�g���w��͈͂̃X�P�W���[���̊J�n���ƏI������Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanFromTotalDaySchedule(out int startDate, out int endDate, int totalDay, SortedList totalDayScheduleSortedList,
		//	SeiKingetParameter parameter)
		//{
		//	// �X�P�W���[���v����t���X�g���擾
		//	SortedList scheduleDateList = (SortedList)totalDayScheduleSortedList[totalDay];
		//	return this.GetDateSpan(out startDate, out endDate, scheduleDateList, parameter);
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region ���o���t�͈͎擾(���Ӑ�X�P�W���[���x�[�X) ���g�p�̂��ߍ폜
        ///// <summary>
		///// ���o���t�͈͎擾(���Ӑ�X�P�W���[���x�[�X)
		///// </summary>
		///// <param name="startDate">�J�n���t</param>
		///// <param name="endDate">�I�����t</param>
		///// <param name="customerCode">���Ӑ�R�[�h</param>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <br>Note       : ���Ӑ�X�P�W���[�����X�g���w��͈͂̃X�P�W���[���̊J�n���ƏI������Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanFromCustomerSchedule(out int startDate, out int endDate, int customerCode, SortedList customerScheduleSortedList,
		//	SeiKingetParameter parameter)
		//{
		//	// �X�P�W���[���v����t���X�g���擾
		//	SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//	return this.GetDateSpan(out startDate, out endDate, scheduleDateList, parameter);
        //}
        #endregion
        // �� 2007.12.21 980081 d

        // �� 2007.12.21 980081 d
        #region ���o���t�͈͎擾(�X�P�W���[���v����t���X�g) ���g�p�̂��ߍ폜
        ///// <summary>
        ///// ���o���t�͈͎擾(�X�P�W���[���v����t���X�g)
        ///// </summary>
        ///// <param name="startDate">�J�n���t</param>
        ///// <param name="endDate">�I�����t</param>
        ///// <param name="scheduleDateSortedList">�X�P�W���[���v����t�\�[�g���X�g</param>
        ///// <param name="parameter">�����p�����[�^</param>
        ///// <br>Note       : �w��͈͂̃X�P�W���[���̊J�n���ƏI������Ԃ��܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpan(out int startDate, out int endDate, SortedList scheduleDateSortedList, SeiKingetParameter parameter)
		//{
		//	startDate = 0;
		//	endDate   = 0;
		//			
		//	// �v��N��
		//	if ((parameter.StartAddUpYearMonth > 100000) &&
		//		(parameter.EndAddUpYearMonth > 100000) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		int paraStartDate	= parameter.StartAddUpYearMonth	* 100;
		//		int paraEndDate		= parameter.EndAddUpYearMonth	* 100;
		//				
		//		foreach (DictionaryEntry de in scheduleDateSortedList)
		//		{
		//			int totalYYYYMMDD = (int)de.Key;	// �X�P�W���[������
		//					
		//			if (startDate == 0)
		//			{
		//				// �X�P�W���[������(�N��)���p�����[�^�v��N��(�J�n)�̏ꍇ
		//				if (totalYYYYMMDD >= paraStartDate)
		//				{
		//					startDate = totalYYYYMMDD;
		//				}
		//			}
		//					
		//			// �X�P�W���[������(�N��)���p�����[�^�v��N��(�I��)�̏ꍇ
		//			if (totalYYYYMMDD / 100 <= paraEndDate / 100)
		//			{
		//				endDate = totalYYYYMMDD;
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//		// �v����t
		//		if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		int paraStartDate	= TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.StartAddUpDate);
		//		int paraEndDate		= TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.EndAddUpDate);
        //
		//		foreach (DictionaryEntry de in scheduleDateSortedList)
		//		{
		//			int totalYYYYMMDD = (int)de.Key;	// �X�P�W���[������
		//					
		//			if (startDate == 0)
		//			{
		//				// �X�P�W���[���������p�����[�^�v����t(�J�n)�̏ꍇ
		//				if (totalYYYYMMDD >= paraStartDate)
		//				{
		//					startDate = totalYYYYMMDD;
		//				}
		//			}
		//					
		//			// �X�P�W���[���������p�����[�^�v����t(�I��)�̏ꍇ
		//			if (totalYYYYMMDD <= paraEndDate)
		//			{
		//				endDate = totalYYYYMMDD;
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// ���t�͈͎̔w�肪����Ă��Ȃ��ꍇ�͏����I��
		//		return false;
		//	}
		//	
		//	return true;
		//}
        #endregion
        // �� 2007.12.21 980081 d
		
        // �� 20070417 18322 d ���g�p�̈׍폜
        #region ���חp���o���t�͈͎擾�i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// ���חp���o���t�͈͎擾(�����X�P�W���[���x�[�X)
		///// </summary>
		///// <param name="startDate">�J�n���t</param>
		///// <param name="endDate">�I�����t</param>
		///// <param name="totalDay">����</param>
		///// <param name="totalDayScheduleSortedList">�����X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <br>Note       : �w��͈͂̃X�P�W���[���̊J�n���ƏI������Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanForDetailFromTotalDaySchedule(out int startDate, out int endDate, int totalDay,
		//	SortedList totalDayScheduleSortedList, SeiKingetParameter parameter)
		//{
		//	// �X�P�W���[���v����t���X�g���擾
		//	SortedList scheduleDateList = (SortedList)totalDayScheduleSortedList[totalDay];
		//	return this.GetDateSpanForDetail(out startDate, out endDate, scheduleDateList, parameter);
		//}

		///// <summary>
		///// ���חp���o���t�͈͎擾(���Ӑ�X�P�W���[���x�[�X)
		///// </summary>
		///// <param name="startDate">�J�n���t</param>
		///// <param name="endDate">�I�����t</param>
		///// <param name="customerCode">���Ӑ�R�[�h</param>
		///// <param name="customerScheduleSortedList">���Ӑ�X�P�W���[���i�[�p�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <br>Note       : �w��͈͂̃X�P�W���[���̊J�n���ƏI������Ԃ��܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanForDetailFromCustomerSchedule(out int startDate, out int endDate, int customerCode,
		//	SortedList customerScheduleSortedList, SeiKingetParameter parameter)
		//{
		//	// �X�P�W���[���v����t���X�g���擾
		//	SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//	return this.GetDateSpanForDetail(out startDate, out endDate, scheduleDateList, parameter);
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 20070417 18322 d ���g�p�̈׍폜
        #region ���חp���o���t�͈͎擾�i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// ���חp���o���t�͈͎擾
		///// </summary>
		///// <param name="startDate">�J�n���t</param>
		///// <param name="endDate">�I�����t</param>
		///// <param name="scheduleDateList">�X�P�W���[���v����t�\�[�g���X�g</param>
		///// <param name="parameter">�����p�����[�^</param>
		///// <br>Note       : �������z���i�[�p�\�[�g���X�g�ɃZ�b�g���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanForDetail(out int startDate, out int endDate, SortedList scheduleDateList, SeiKingetParameter parameter)
		//{
		//	startDate = 0;
		//	endDate   = 0;
		//			
		//	// �v��N��
		//	if ((parameter.StartAddUpYearMonth > 100000) &&
		//		(parameter.EndAddUpYearMonth > 100000) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		int paraStartDate	= parameter.StartAddUpYearMonth;
		//		int paraEndDate		= parameter.EndAddUpYearMonth;
		//				
		//		foreach (DictionaryEntry de in scheduleDateList)
		//		{
		//			RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)de.Value;
		//			int totalYYYYMM = TDateTime.DateTimeToLongDate("YYYYMM", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//					
		//			if (startDate == 0)
		//			{
		//				// �X�P�W���[������(�N��)���p�����[�^�v��N��(�J�n)�̏ꍇ
		//				if (totalYYYYMM >= paraStartDate)
		//				{
		//					// ���ߔ͈͂̊J�n�����Z�b�g
		//					startDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//				}
		//			}
		//					
		//			// �X�P�W���[������(�N��)���p�����[�^�v��N��(�I��)�̏ꍇ
		//			if (totalYYYYMM <= paraEndDate)
		//			{
		//				// ���ߔ͈͂̏I�������Z�b�g
		//				endDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	// �v����t
		//	if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		foreach (DictionaryEntry de in scheduleDateList)
		//		{
		//			RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)de.Value;
		//					
		//			if (startDate == 0)
		//			{
		//				// �X�P�W���[���������p�����[�^�v����t(�J�n)�̏ꍇ
		//				if (retAddUpDateItemTypeDInf.CAddUpUpdDate >= parameter.StartAddUpDate)
		//				{
		//					// ���ߔ͈͂̊J�n�����Z�b�g
		//					startDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//				}
		//			}
		//					
		//			// �X�P�W���[���������p�����[�^�v����t(�I��)�̏ꍇ
		//			if (retAddUpDateItemTypeDInf.CAddUpUpdDate <= parameter.EndAddUpDate)
		//			{
		//				// ���ߔ͈͂̏I�������Z�b�g
		//				endDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// ���t�͈͎̔w�肪����Ă��Ȃ��ꍇ�͏����I��
		//		return false;
		//	}
		//	
		//	return true;
		//}
        #endregion
        // �� 20070417 18322 d

        // �� 2007.12.21 980081 d
        #region SQL�f�[�^���[�_�[�����Ӑ搿�����z���[�N ���g�p�̂��ߍ폜
        ///// <summary>
		///// SQL�f�[�^���[�_�[�����Ӑ搿�����z���[�N
		///// </summary>
		///// <param name="kingetCustDmdPrcWork">���Ӑ搿�����z���[�N</param>
		///// <param name="myReader">SQL�f�[�^���[�_�[</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e��KINGET�p���Ӑ搿�����z�}�X�^�ɃR�s�[���܂��B</br>
		///// <br>Programmer : 18023 ����@����</br>
		///// <br>Date       : 2005.07.21</br>		
		//private void CopyToDataClassFromSelectData(ref KingetCustDmdPrcWork kingetCustDmdPrcWork, SqlDataReader myReader)
        //{
        //    // �� 20070117 18322 c MA.NS�p�ɕύX
        //    #region SF KINGET�p���Ӑ搿�����z�N���X���[�N�փf�[�^�ݒ�i�R�����g�A�E�g�j
        //    //kingetCustDmdPrcWork.FileHeaderGuid			= SqlDataMediator.SqlGetGuid	(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"		));
        //	//kingetCustDmdPrcWork.EnterpriseCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ENTERPRISECODERF"		));
        //	//kingetCustDmdPrcWork.AddUpSecCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDUPSECCODERF"			));
        //	//kingetCustDmdPrcWork.CustomerCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"			));
        //	//kingetCustDmdPrcWork.AddUpDate				= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
        //	//kingetCustDmdPrcWork.AddUpYearMonth			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"		));
        //	//kingetCustDmdPrcWork.TleDmdSlipLgCt			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPLGCTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdSlipGeCt			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPGECTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTELGCTRF"	));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTEGECTRF"	));
        //	//kingetCustDmdPrcWork.TleDmdSlipLgCnt		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPLGCNTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdSlipGeCnt		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPGECNTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCnt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTELGCNTRF"	));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCnt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTEGECNTRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrTtlSalesDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTLSALESDMDRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrDiscTtlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRDISCTTLDMDRF"		));
        //	//kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTLCONSTAXDMDRF"	));
        //	//kingetCustDmdPrcWork.DmdVarCst				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DMDVARCSTRF"			));
        //	//kingetCustDmdPrcWork.TtlTaxtinDmdVarCst		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLTAXTINDMDVARCSTRF"	));
        //	//kingetCustDmdPrcWork.TtlTaxFreeDmdVarCst	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLTAXFREEDMDVARCSTRF"	));
        //	//kingetCustDmdPrcWork.VarCst1TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST1TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst2TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST2TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst3TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST3TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst4TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST4TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst5TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST5TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst6TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST6TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst7TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST7TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst8TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST8TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst9TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST9TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst10TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST10TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst11TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST11TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst12TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST12TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst13TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST13TOTALDEMANDRF"	));
        //    //kingetCustDmdPrcWork.VarCst14TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST14TOTALDEMANDRF"	));
        //    //kingetCustDmdPrcWork.VarCst15TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST15TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst16TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST16TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst17TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST17TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst18TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST18TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst19TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST19TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst20TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST20TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.TtlDmdVarCstConsTax	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLDMDVARCSTCONSTAXRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrTtlLMBlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTLLMBLDMDRF"		));
        //	//kingetCustDmdPrcWork.TtlLMVarCstDmdBlnce	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLLMVARCSTDMDBLNCERF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDepoDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDEPODMDRF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDPDSDMDRF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDPDMDRF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDsDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrDepoDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRDEPODMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstDepoDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTDEPODMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrDpDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRDPDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstDpDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTDPDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRRMDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstBfRMDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTBFRMDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRRMDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstRMDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTRMDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrBlCFDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRBLCFDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstBlCFDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTBLCFDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrBlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRBLDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstBlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTBLDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalDemandPrice		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"		));
        //	//kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"	));
        //	//kingetCustDmdPrcWork.Ttl2TmBfVarCstDmdBl	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTL2TMBFVARCSTDMDBLRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"	));
        //	//kingetCustDmdPrcWork.Ttl3TmBfVarCstDmdBl	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTL3TMBFVARCSTDMDBLRF"	));
        //	//kingetCustDmdPrcWork.AddUpDateLastRecFlg	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDUPDATELASTRECFLGRF"	));
        //	//kingetCustDmdPrcWork.Name					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAMERF"					));
        //	//kingetCustDmdPrcWork.Name2					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAME2RF"				));
        //	//kingetCustDmdPrcWork.HonorificTitle			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HONORIFICTITLERF"		));
        //	//kingetCustDmdPrcWork.Kana					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("KANARF"					));
        //	//kingetCustDmdPrcWork.OutputNameCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"		));
        //	//kingetCustDmdPrcWork.OutputName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OUTPUTNAMERF"			));
        //	//kingetCustDmdPrcWork.CorporateDivCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"		));
        //	//kingetCustDmdPrcWork.PostNo					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("POSTNORF"				));
        //	//kingetCustDmdPrcWork.Address1				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS1RF"				));
        //	//kingetCustDmdPrcWork.Address2				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDRESS2RF"				));
        //	//kingetCustDmdPrcWork.Address3				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS3RF"				));
        //	//kingetCustDmdPrcWork.Address4				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS4RF"				));
        //	//kingetCustDmdPrcWork.HomeTelNo				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMETELNORF"			));
        //	//kingetCustDmdPrcWork.OfficeTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICETELNORF"			));
        //	//kingetCustDmdPrcWork.PortableTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("PORTABLETELNORF"		));
        //	//// 2006.04.21 ADD START ����@����
        //	//kingetCustDmdPrcWork.HomeFaxNo				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMEFAXNORF"			));
        //	//kingetCustDmdPrcWork.OfficeFaxNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICEFAXNORF"			));
        //	//kingetCustDmdPrcWork.OthersTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OTHERSTELNORF"			));
        //	//kingetCustDmdPrcWork.MainContactCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"		));
        //	//// 2006.04.21 ADD END ����@����
        //	//// 2006.09.06 ADD START ����@����
        //	//kingetCustDmdPrcWork.CustAnalysCode1		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode2		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode3		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode4		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode5		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode6		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"		));
        //	//// 2006.09.06 ADD END ����@����
        //	//kingetCustDmdPrcWork.TotalDay				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TOTALDAYRF"				));
        //	//kingetCustDmdPrcWork.CollectMoneyName		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"		));
        //	//kingetCustDmdPrcWork.CollectMoneyDay		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"		));
        //	//kingetCustDmdPrcWork.CustomerAgentCd		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"		));
        //	//kingetCustDmdPrcWork.CustomerAgentNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"		));
        //	//kingetCustDmdPrcWork.BillCollecterCd		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"		));
        //	//kingetCustDmdPrcWork.BillCollecterNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"		));
        //    #endregion
        //
        //    #region MA.NS KINGET�p���Ӑ搿�����z�N���X���[�N�փf�[�^�ݒ�
        //    // GUID
        //    kingetCustDmdPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    // ��ƃR�[�h
        //    kingetCustDmdPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    // �v�㋒�_�R�[�h
        //    kingetCustDmdPrcWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
        //    // ���Ӑ�R�[�h
        //    kingetCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    // ���Ӑ於��
        //    kingetCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
        //    // ���Ӑ於��2
        //    kingetCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
        //    // �v��N����
        //    kingetCustDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
        //    // �v��N��
        //    kingetCustDmdPrcWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
        //    // �O�񐿋����z
        //    kingetCustDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
        //    // ����������z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
        //    // ����萔���z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
        //    // ����l���z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
        //    // ���񃊃x�[�g�z�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMERBTDMDNRMLRF"));
        //    // ����������z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDDEPORF"));
        //    // ����萔���z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDDEPORF"));
        //    // ����l���z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeDisDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDDEPORF"));
        //    // ���񃊃x�[�g�z�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMERBTDMDDEPORF"));
        //    // ����J�z�c���i�����v�j
        //    kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
        //    // ���񔄏���z
        //    kingetCustDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
        //    // ���񔄏�����
        //    kingetCustDmdPrcWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
        //    // �x���C���Z���e�B�u�z���v�i�Ŕ����j
        //    kingetCustDmdPrcWork.TtlIncDtbtTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLINCDTBTTAXEXCRF"));
        //    // �x���C���Z���e�B�u�z���v�i�Łj
        //    kingetCustDmdPrcWork.TtlIncDtbtTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLINCDTBTTAXRF"));
        //    // ���E�㍡�񔄏���z
        //    kingetCustDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
        //    // ���E�㍡�񔄏�����
        //    kingetCustDmdPrcWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
        //    // ���E��O�őΏۊz
        //    kingetCustDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
        //    // ���E����őΏۊz
        //    kingetCustDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
        //    // ���E���ېőΏۊz
        //    kingetCustDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
        //    // ���E��O�ŏ����
        //    kingetCustDmdPrcWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
        //    // ���E����ŏ����
        //    kingetCustDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
        //    // ����O�őΏۊz
        //    kingetCustDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
        //    // ������őΏۊz
        //    kingetCustDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
        //    // �����ېőΏۊz
        //    kingetCustDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
        //    // ����O�Ŋz
        //    kingetCustDmdPrcWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
        //    // ������Ŋz
        //    kingetCustDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
        //    // �x���O�őΏۊz
        //    kingetCustDmdPrcWork.ItdedPaymOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMOUTTAXRF"));
        //    // �x�����őΏۊz
        //    kingetCustDmdPrcWork.ItdedPaymInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMINTAXRF"));
        //    // �x����ېőΏۊz
        //    kingetCustDmdPrcWork.ItdedPaymTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMTAXFREERF"));
        //    // �x���O�ŏ����
        //    kingetCustDmdPrcWork.PaymentOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTOUTTAXRF"));
        //    // �x�����ŏ����
        //    kingetCustDmdPrcWork.PaymentInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTINTAXRF"));
        //    // ����œ]�ŕ���
        //    kingetCustDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
        //    // ����ŗ�
        //    kingetCustDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
        //    // �[�������敪
        //    kingetCustDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
        //    // �v�Z�㐿�����z
        //    kingetCustDmdPrcWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
        //    // ��2��O�c���i�����v�j
        //    kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
        //    // ��3��O�c���i�����v�j
        //    kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
        //    // �����X�V���s�N����
        //    kingetCustDmdPrcWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
        //    
        //    // ���������ʔ�
        //    kingetCustDmdPrcWork.DmdProcNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDPROCNUMRF"));
        //    // �����X�V�J�n�N����
        //    kingetCustDmdPrcWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
        //    // �O������X�V�N����
        //    kingetCustDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
        //    
        //    // ��������v�i�ʏ�����j
        //    kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl = kingetCustDmdPrcWork.ThisTimeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
        //    // ��������v�i�a����j
        //    kingetCustDmdPrcWork.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
        //    // ��������v
        //    kingetCustDmdPrcWork.ThisTimeDmdTtl     = kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl
        //                                            + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;
        //    
        //    // ����
        //    kingetCustDmdPrcWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
        //    // ���̂Q
        //    kingetCustDmdPrcWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
        //    // �h��
        //    kingetCustDmdPrcWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
        //    // �J�i
        //    kingetCustDmdPrcWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
        //    // �����R�[�h
        //    kingetCustDmdPrcWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
        //    // ��������
        //    kingetCustDmdPrcWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
        //    // �l�E�@�l�敪
        //    kingetCustDmdPrcWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
        //    // �X�֔ԍ�
        //    kingetCustDmdPrcWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
        //    // �Z���P�i�s���{���s��S�E�����E���j
        //    kingetCustDmdPrcWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
        //    // �Z���Q�i���ځj
        //    kingetCustDmdPrcWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));
        //    // �Z���R�i�Ԓn�j
        //    kingetCustDmdPrcWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
        //    // �Z���S�i�A�p�[�g���́j
        //    kingetCustDmdPrcWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
        //    // �d�b�ԍ��i����j
        //    kingetCustDmdPrcWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
        //    // �d�b�ԍ��i�Ζ���j
        //    kingetCustDmdPrcWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
        //    // �d�b�ԍ��i�g�сj
        //    kingetCustDmdPrcWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
        //    // FAX�ԍ��i����j
        //    kingetCustDmdPrcWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
        //    // FAX�ԍ��i�Ζ���j
        //    kingetCustDmdPrcWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
        //    // �d�b�ԍ��i���̑��j
        //    kingetCustDmdPrcWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
        //    // ��A����敪
        //    kingetCustDmdPrcWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
        //    // ���Ӑ敪�̓R�[�h�P
        //    kingetCustDmdPrcWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
        //    // ���Ӑ敪�̓R�[�h�Q
        //    kingetCustDmdPrcWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
        //    // ���Ӑ敪�̓R�[�h�R
        //    kingetCustDmdPrcWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
        //    // ���Ӑ敪�̓R�[�h�S
        //    kingetCustDmdPrcWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
        //    // ���Ӑ敪�̓R�[�h�T
        //    kingetCustDmdPrcWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
        //    // ���Ӑ敪�̓R�[�h�U
        //    kingetCustDmdPrcWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
        //    // ����
        //    kingetCustDmdPrcWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
        //    // �W�����敪����
        //    kingetCustDmdPrcWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
        //    // �W����
        //    kingetCustDmdPrcWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
        //    // �ڋq�S���]�ƈ��R�[�h
        //    kingetCustDmdPrcWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
        //    // �ڋq�S���]�ƈ�����
        //    kingetCustDmdPrcWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
        //    // �W���S���]�ƈ��R�[�h
        //    kingetCustDmdPrcWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
        //    // �W���S���]�ƈ�����
        //    kingetCustDmdPrcWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
        //    #endregion
        //    // �� 20070117 18322 c
        //}
        #endregion
        // �� 2007.12.21 980081 d

		/// <summary>
		/// SQL�f�[�^���[�_�[(���Ӑ���)�����Ӑ搿�����z���[�N
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">���Ӑ搿�����z���[�N</param>
		/// <param name="myReader">SQL�f�[�^���[�_�[</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : SQL�f�[�^���[�_�[�ɕێ����Ă�����e��KINGET�p���Ӑ搿�����z�}�X�^�ɃR�s�[���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>		
		private void SetKingetCustDmdPrcWorkFromCustomerDataReader(ref KingetCustDmdPrcWork kingetCustDmdPrcWork, SqlDataReader myReader)
		{
            // �� 2007.12.21 980081 c
            #region �����C�A�E�g(�R�����g�A�E�g)
            //kingetCustDmdPrcWork.CustomerCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"		));
			//kingetCustDmdPrcWork.Name				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAMERF"				));
			//kingetCustDmdPrcWork.Name2				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAME2RF"			));
			//kingetCustDmdPrcWork.HonorificTitle		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HONORIFICTITLERF"	));
			//kingetCustDmdPrcWork.Kana				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("KANARF"				));
			//kingetCustDmdPrcWork.OutputNameCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"	));
			//kingetCustDmdPrcWork.OutputName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OUTPUTNAMERF"		));
			//kingetCustDmdPrcWork.CorporateDivCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"	));
			//kingetCustDmdPrcWork.PostNo				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("POSTNORF"			));
			//kingetCustDmdPrcWork.Address1			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS1RF"			));
			//kingetCustDmdPrcWork.Address2			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDRESS2RF"			));
			//kingetCustDmdPrcWork.Address3			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS3RF"			));
			//kingetCustDmdPrcWork.Address4			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS4RF"			));
			//kingetCustDmdPrcWork.HomeTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMETELNORF"		));
			//kingetCustDmdPrcWork.OfficeTelNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICETELNORF"		));
			//kingetCustDmdPrcWork.PortableTelNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("PORTABLETELNORF"	));
			//// 2006.04.21 ADD START ����@����
			//kingetCustDmdPrcWork.HomeFaxNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMEFAXNORF"		));
			//kingetCustDmdPrcWork.OfficeFaxNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICEFAXNORF"		));
			//kingetCustDmdPrcWork.OthersTelNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OTHERSTELNORF"		));
			//kingetCustDmdPrcWork.MainContactCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"	));
			//// 2006.04.21 ADD END ����@����
			//// 2006.09.06 ADD START ����@����
			//kingetCustDmdPrcWork.CustAnalysCode1	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode2	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode3	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode4	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode5	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode6	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"	));
			//// 2006.09.06 ADD END ����@����
			//kingetCustDmdPrcWork.TotalDay			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TOTALDAYRF"			));
			//kingetCustDmdPrcWork.CollectMoneyName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"	));
			//kingetCustDmdPrcWork.CollectMoneyDay	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"	));
			//kingetCustDmdPrcWork.CustomerAgentCd	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"	));
			//kingetCustDmdPrcWork.CustomerAgentNm	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"	));
			//kingetCustDmdPrcWork.BillCollecterCd	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"	));
			//kingetCustDmdPrcWork.BillCollecterNm	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"	));
            #endregion
            kingetCustDmdPrcWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            kingetCustDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            kingetCustDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            kingetCustDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            kingetCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            kingetCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            kingetCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            kingetCustDmdPrcWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            kingetCustDmdPrcWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            kingetCustDmdPrcWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            kingetCustDmdPrcWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
            kingetCustDmdPrcWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
            kingetCustDmdPrcWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
            kingetCustDmdPrcWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            kingetCustDmdPrcWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //kingetCustDmdPrcWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));  //DEL 2008/04/25 M.Kubota
            kingetCustDmdPrcWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            kingetCustDmdPrcWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            kingetCustDmdPrcWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
            kingetCustDmdPrcWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
            kingetCustDmdPrcWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
            kingetCustDmdPrcWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
            kingetCustDmdPrcWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
            kingetCustDmdPrcWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
            kingetCustDmdPrcWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
            kingetCustDmdPrcWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
            kingetCustDmdPrcWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
            kingetCustDmdPrcWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
            kingetCustDmdPrcWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
            kingetCustDmdPrcWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
            kingetCustDmdPrcWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
            kingetCustDmdPrcWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            kingetCustDmdPrcWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
            kingetCustDmdPrcWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            kingetCustDmdPrcWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            kingetCustDmdPrcWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
            kingetCustDmdPrcWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
            kingetCustDmdPrcWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            kingetCustDmdPrcWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            kingetCustDmdPrcWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
            kingetCustDmdPrcWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNMRF"));
            kingetCustDmdPrcWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
            // �� 2007.12.21 980081 c
		}


        /// <summary>
        /// �������z���ݒ�
        /// </summary>
        /// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
        /// <param name="custDmdPrcWork">�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������̓��e��KINGET�p���Ӑ搿�����z���ɐݒ肵�܂��B</br>
        /// <br>Programmer : 18322 �ؑ� ����</br>
        /// <br>Date       : 2007.04.17</br>
        private void SetKingetDmdPrcInfo(ref KingetCustDmdPrcWork   kingetCustDmdPrcWork
                                        ,ref CustDmdPrcWork         custDmdPrcWork)
        {
            // �v��N����
            kingetCustDmdPrcWork.AddUpDate      = custDmdPrcWork.AddUpDate;
            // �v��N��
            kingetCustDmdPrcWork.AddUpYearMonth = custDmdPrcWork.AddUpYearMonth;

            // �� 2007.12.21 980081 c
            #region �����C�A�E�g(�R�����g�A�E�g)
            //// �O�񐿋����z
            //kingetCustDmdPrcWork.LastTimeDemand = custDmdPrcWork.LastTimeDemand;
            //// ����������z�i�ʏ�����j
            //kingetCustDmdPrcWork.ThisTimeDmdNrml = custDmdPrcWork.ThisTimeDmdNrml;
            //// ����萔���z�i�ʏ�����j
            //kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = custDmdPrcWork.ThisTimeFeeDmdNrml;
            //// ����l���z�i�ʏ�����j
            //kingetCustDmdPrcWork.ThisTimeDisDmdNrml = custDmdPrcWork.ThisTimeDisDmdNrml;
            //// ���񃊃x�[�g�z�i�ʏ�����j
            //kingetCustDmdPrcWork.ThisTimeRbtDmdNrml = custDmdPrcWork.ThisTimeRbtDmdNrml;
            //// ����������z�i�a����j
            //kingetCustDmdPrcWork.ThisTimeDmdDepo = custDmdPrcWork.ThisTimeDmdDepo;
            //// ����萔���z�i�a����j
            //kingetCustDmdPrcWork.ThisTimeFeeDmdDepo = custDmdPrcWork.ThisTimeFeeDmdDepo;
            //// ����l���z�i�a����j
            //kingetCustDmdPrcWork.ThisTimeDisDmdDepo = custDmdPrcWork.ThisTimeDisDmdDepo;
            //// ���񃊃x�[�g�z�i�a����j
            //kingetCustDmdPrcWork.ThisTimeRbtDmdDepo = custDmdPrcWork.ThisTimeRbtDmdDepo;
            //// ����J�z�c���i�����v�j
            //kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrcWork.ThisTimeTtlBlcDmd;
            //// ���񔄏���z
            //kingetCustDmdPrcWork.ThisTimeSales = custDmdPrcWork.ThisTimeSales;
            //// ���񔄏�����
            //kingetCustDmdPrcWork.ThisSalesTax = custDmdPrcWork.ThisSalesTax;
            //// �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //kingetCustDmdPrcWork.TtlIncDtbtTaxExc = custDmdPrcWork.TtlIncDtbtTaxExc;
            //// �x���C���Z���e�B�u�z���v�i�Łj
            //kingetCustDmdPrcWork.TtlIncDtbtTax = custDmdPrcWork.TtlIncDtbtTax;
            //// ���E�㍡�񔄏���z
            //kingetCustDmdPrcWork.OfsThisTimeSales = custDmdPrcWork.OfsThisTimeSales;
            //// ���E�㍡�񔄏�����
            //kingetCustDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OfsThisSalesTax;
            //// ���E��O�őΏۊz
            //kingetCustDmdPrcWork.ItdedOffsetOutTax = custDmdPrcWork.ItdedOffsetOutTax;
            //// ���E����őΏۊz
            //kingetCustDmdPrcWork.ItdedOffsetInTax = custDmdPrcWork.ItdedOffsetInTax;
            //// ���E���ېőΏۊz
            //kingetCustDmdPrcWork.ItdedOffsetTaxFree = custDmdPrcWork.ItdedOffsetTaxFree;
            //// ���E��O�ŏ����
            //kingetCustDmdPrcWork.OffsetOutTax = custDmdPrcWork.OffsetOutTax;
            //// ���E����ŏ����
            //kingetCustDmdPrcWork.OffsetInTax = custDmdPrcWork.OffsetInTax;
            //// ����O�őΏۊz
            //kingetCustDmdPrcWork.ItdedSalesOutTax = custDmdPrcWork.ItdedSalesOutTax;
            //// ������őΏۊz
            //kingetCustDmdPrcWork.ItdedSalesInTax = custDmdPrcWork.ItdedSalesInTax;
            //// �����ېőΏۊz
            //kingetCustDmdPrcWork.ItdedSalesTaxFree = custDmdPrcWork.ItdedSalesTaxFree;
            //// ����O�Ŋz
            //kingetCustDmdPrcWork.SalesOutTax = custDmdPrcWork.SalesOutTax;
            //// ������Ŋz
            //kingetCustDmdPrcWork.SalesInTax = custDmdPrcWork.SalesInTax;
            //// �x���O�őΏۊz
            //kingetCustDmdPrcWork.ItdedPaymOutTax = custDmdPrcWork.ItdedPaymOutTax;
            //// �x�����őΏۊz
            //kingetCustDmdPrcWork.ItdedPaymInTax = custDmdPrcWork.ItdedPaymInTax;
            //// �x����ېőΏۊz
            //kingetCustDmdPrcWork.ItdedPaymTaxFree = custDmdPrcWork.ItdedPaymTaxFree;
            //// �x���O�ŏ����
            //kingetCustDmdPrcWork.PaymentOutTax = custDmdPrcWork.PaymentOutTax;
            //// �x�����ŏ����
            //kingetCustDmdPrcWork.PaymentInTax = custDmdPrcWork.PaymentInTax;
            //// ����œ]�ŕ���
            //kingetCustDmdPrcWork.ConsTaxLayMethod = custDmdPrcWork.ConsTaxLayMethod;
            //// ����ŗ�
            //kingetCustDmdPrcWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;
            //// �[�������敪
            //kingetCustDmdPrcWork.FractionProcCd = custDmdPrcWork.FractionProcCd;
            //// �v�Z�㐿�����z
            //kingetCustDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.AfCalDemandPrice;
            //// ��2��O�c���i�����v�j
            //kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
            //// ��3��O�c���i�����v�j
            //kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;
            //// �����X�V���s�N����
            //kingetCustDmdPrcWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;
            //
            //// ���������ʔ�
            //kingetCustDmdPrcWork.DmdProcNum = custDmdPrcWork.DmdProcNum;
            //// �����X�V�J�n�N����
            //kingetCustDmdPrcWork.StartCAddUpUpdDate = custDmdPrcWork.StartCAddUpUpdDate;
            //// �O������X�V�N����
            //kingetCustDmdPrcWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;
            //
            //// ��������v�i�ʏ�����j
            //kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl = kingetCustDmdPrcWork.ThisTimeDmdNrml
            //                                        + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml
            //                                        + kingetCustDmdPrcWork.ThisTimeDisDmdNrml
            //                                        + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
            //// ��������v�i�a����j
            //kingetCustDmdPrcWork.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo
            //                                        + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo
            //                                        + kingetCustDmdPrcWork.ThisTimeDisDmdDepo
            //                                        + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
            //// ��������v
            //kingetCustDmdPrcWork.ThisTimeDmdTtl     = kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl
            //                                        + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;
            #endregion
            kingetCustDmdPrcWork.LastTimeDemand = custDmdPrcWork.LastTimeDemand;
            kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = custDmdPrcWork.ThisTimeFeeDmdNrml;
            kingetCustDmdPrcWork.ThisTimeDisDmdNrml = custDmdPrcWork.ThisTimeDisDmdNrml;
            kingetCustDmdPrcWork.ThisTimeDmdNrml = custDmdPrcWork.ThisTimeDmdNrml;
            kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrcWork.ThisTimeTtlBlcDmd;
            kingetCustDmdPrcWork.OfsThisTimeSales = custDmdPrcWork.OfsThisTimeSales;
            kingetCustDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OfsThisSalesTax;
            kingetCustDmdPrcWork.ItdedOffsetOutTax = custDmdPrcWork.ItdedOffsetOutTax;
            kingetCustDmdPrcWork.ItdedOffsetInTax = custDmdPrcWork.ItdedOffsetInTax;
            kingetCustDmdPrcWork.ItdedOffsetTaxFree = custDmdPrcWork.ItdedOffsetTaxFree;
            kingetCustDmdPrcWork.OffsetOutTax = custDmdPrcWork.OffsetOutTax;
            kingetCustDmdPrcWork.OffsetInTax = custDmdPrcWork.OffsetInTax;
            kingetCustDmdPrcWork.ThisTimeSales = custDmdPrcWork.ThisTimeSales;
            kingetCustDmdPrcWork.ThisSalesTax = custDmdPrcWork.ThisSalesTax;
            kingetCustDmdPrcWork.ItdedSalesOutTax = custDmdPrcWork.ItdedSalesOutTax;
            kingetCustDmdPrcWork.ItdedSalesInTax = custDmdPrcWork.ItdedSalesInTax;
            kingetCustDmdPrcWork.ItdedSalesTaxFree = custDmdPrcWork.ItdedSalesTaxFree;
            kingetCustDmdPrcWork.SalesOutTax = custDmdPrcWork.SalesOutTax;
            kingetCustDmdPrcWork.SalesInTax = custDmdPrcWork.SalesInTax;
            kingetCustDmdPrcWork.ThisSalesPricRgds = custDmdPrcWork.ThisSalesPricRgds;
            kingetCustDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.ThisSalesPrcTaxRgds;
            kingetCustDmdPrcWork.TtlItdedRetOutTax = custDmdPrcWork.TtlItdedRetOutTax;
            kingetCustDmdPrcWork.TtlItdedRetInTax = custDmdPrcWork.TtlItdedRetInTax;
            kingetCustDmdPrcWork.TtlItdedRetTaxFree = custDmdPrcWork.TtlItdedRetTaxFree;
            kingetCustDmdPrcWork.TtlRetOuterTax = custDmdPrcWork.TtlRetOuterTax;
            kingetCustDmdPrcWork.TtlRetInnerTax = custDmdPrcWork.TtlRetInnerTax;
            kingetCustDmdPrcWork.ThisSalesPricDis = custDmdPrcWork.ThisSalesPricDis;
            kingetCustDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.ThisSalesPrcTaxDis;
            kingetCustDmdPrcWork.TtlItdedDisOutTax = custDmdPrcWork.TtlItdedDisOutTax;
            kingetCustDmdPrcWork.TtlItdedDisInTax = custDmdPrcWork.TtlItdedDisInTax;
            kingetCustDmdPrcWork.TtlItdedDisTaxFree = custDmdPrcWork.TtlItdedDisTaxFree;
            kingetCustDmdPrcWork.TtlDisOuterTax = custDmdPrcWork.TtlDisOuterTax;
            kingetCustDmdPrcWork.TtlDisInnerTax = custDmdPrcWork.TtlDisInnerTax;
            //--- DEL 2008/04/25 M.Kubota --->>>            
            //kingetCustDmdPrcWork.ThisPayOffset = custDmdPrcWork.ThisPayOffset;
            //kingetCustDmdPrcWork.ThisPayOffsetTax = custDmdPrcWork.ThisPayOffsetTax;
            //kingetCustDmdPrcWork.ItdedPaymOutTax = custDmdPrcWork.ItdedPaymOutTax;
            //kingetCustDmdPrcWork.ItdedPaymInTax = custDmdPrcWork.ItdedPaymInTax;
            //kingetCustDmdPrcWork.ItdedPaymTaxFree = custDmdPrcWork.ItdedPaymTaxFree;
            //kingetCustDmdPrcWork.PaymentOutTax = custDmdPrcWork.PaymentOutTax;
            //kingetCustDmdPrcWork.PaymentInTax = custDmdPrcWork.PaymentInTax;
            //--- DEL 2008/04/25 M.Kubota ---<<<
            kingetCustDmdPrcWork.TaxAdjust = custDmdPrcWork.TaxAdjust;
            kingetCustDmdPrcWork.BalanceAdjust = custDmdPrcWork.BalanceAdjust;
            kingetCustDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.AfCalDemandPrice;
            kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
            kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;
            kingetCustDmdPrcWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;
            kingetCustDmdPrcWork.StartCAddUpUpdDate = custDmdPrcWork.StartCAddUpUpdDate;
            kingetCustDmdPrcWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;
            kingetCustDmdPrcWork.SalesSlipCount = custDmdPrcWork.SalesSlipCount;
            kingetCustDmdPrcWork.BillPrintDate = custDmdPrcWork.BillPrintDate;
            kingetCustDmdPrcWork.ExpectedDepositDate = custDmdPrcWork.ExpectedDepositDate;
            kingetCustDmdPrcWork.CollectCond = custDmdPrcWork.CollectCond;
            kingetCustDmdPrcWork.ConsTaxLayMethod = custDmdPrcWork.ConsTaxLayMethod;
            kingetCustDmdPrcWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;
            kingetCustDmdPrcWork.FractionProcCd = custDmdPrcWork.FractionProcCd;
            // �� 2007.12.21 980081 c

            // ���Ԃ̊J�n�Ɍv��N����(�����̐�������)�̎��̓����Z�b�g
            if (custDmdPrcWork.StartCAddUpUpdDate == DateTime.MinValue)
            {
                // ���߂��P�x���s���Ă��Ȃ��ꍇ
                kingetCustDmdPrcWork.StartDateSpan = TDateTime.DateTimeToLongDate(DateTime.MinValue);

                kingetCustDmdPrcWork.EndDateSpan = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate);
            }
            else
            {
                // �O��ɒ��߂��s���Ă���ꍇ
                kingetCustDmdPrcWork.StartDateSpan = TDateTime.DateTimeToLongDate(custDmdPrcWork.StartCAddUpUpdDate);

                // ���t�͈́i�I���j
                if (DateTime.DaysInMonth(custDmdPrcWork.LastCAddUpUpdDate.Year, custDmdPrcWork.LastCAddUpUpdDate.Month) == custDmdPrcWork.LastCAddUpUpdDate.Day)
                {
                    // �O�񌎖��Œ��ߏ��������Ƃ��́A����������ɂ���B
                    DateTime dt = custDmdPrcWork.LastCAddUpUpdDate.AddMonths(1);
                    kingetCustDmdPrcWork.EndDateSpan  = TDateTime.DateTimeToLongDate(dt);
                    kingetCustDmdPrcWork.EndDateSpan = Convert.ToInt32(Math.Truncate(Convert.ToDouble(kingetCustDmdPrcWork.EndDateSpan / 100)));
                    kingetCustDmdPrcWork.EndDateSpan = kingetCustDmdPrcWork.EndDateSpan * 100;
                    kingetCustDmdPrcWork.EndDateSpan += DateTime.DaysInMonth(dt.Year, dt.Month);
                }
                else
                {
                    // �����ȊO�Œ��ߏ���
                    kingetCustDmdPrcWork.EndDateSpan = TDateTime.DateTimeToLongDate(custDmdPrcWork.LastCAddUpUpdDate.AddMonths(1));
                }
            }
        }


		/// <summary>
		/// ������ǉ�����
		/// </summary>
		/// <param name="target">�Ώە�����</param>
		/// <param name="value">�t������</param>
		/// <param name="length">�Ώە�����̍ő啶����</param>
		/// <returns>�ǉ��㕶����</returns>
		/// <br>Note       : �Ώە�����ɑ΂��čő啶�����ɒB����܂ŕt��������ǉ����܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>		
		private string StringAppendLength(string target, char value, int length)
		{
			System.Text.StringBuilder sb = new StringBuilder(target);
			for (int index = sb.Length; index < length; index++)
			{
				sb.Append(value);
			}
			return sb.ToString();
		}

        //--- DEL 2008/07/10 M.Kubota --->>>
        ///// <summary>
        ///// SQL�Í������N���X�������Í����L�[�n�o�d�m
        ///// </summary>
        ///// <returns></returns>
        ///// <br>Note       : SQL�Í������N���X�𐶐����A�Í����L�[���n�o�d�m���܂��B</br>
        ///// <br>Programmer : 18023 ����@����</br>
        ///// <br>Date       : 2006.08.22</br>
        //private SqlEncryptInfo OpenSqlEncryptInfo(ref SqlConnection sqlConnection)
        //{
        //    SqlEncryptInfo sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] {"CUSTOMERRF"});
        //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
        //    return sqlEncryptInfo;
        //}
        //--- DEL 2008/07/10 M.Kubota ---<<<

		#endregion
	}
}