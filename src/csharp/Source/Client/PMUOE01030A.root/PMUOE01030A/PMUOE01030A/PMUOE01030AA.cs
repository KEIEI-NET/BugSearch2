////////********************************************************************// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d����M���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : �x�c
// �� �� ��  2010/06/09  �C�����e : WebResponse��Byte�ɃZ�b�g����ہA�i�Ԃ�
//                                  NULL���Z�b�g����Ȃ��悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���X�� �M�p
// �� �� ��  2012/10/03  �C�����e : �^�C���A�E�g�G���[���b�Z�[�W�s���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11001634-00  �쐬�S�� : ���N�n��
// �� �� ��  K2014/05/26  �C�����e : ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading; 
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;// ADD K2014/05/26 ���N�n�� Redmine 42571

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d����M�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d����M�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 ���� PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpDate</br>
    /// <br>2012/10/03 FSI���X�� �M�p �^�C���A�E�g�G���[���b�Z�[�W�s���Ή�</br>
    /// <br>Update Note: K2014/05/26 ���N�n��</br>
    /// <br>             ���������G���[���b�Z�[�W���o���Ȃ��悤�ɏC���ƃG���[���O�̍X�V</br>
    /// </remarks>
	public partial class UoeSndRcvAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeSndRcvAcs()
		{
			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//���엚�����O�A�N�Z�X�N���X
			_uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();

            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
            //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members

		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//���엚�����O�A�N�Z�X�N���X
		private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;

		//�t�n�d���M�w�b�_�[�N���X
		private UoeSndHed _uoeSndHed = new UoeSndHed();

		//�t�n�d���M���׃N���X
		private UoeSndDtl _uoeSndDtl = new UoeSndDtl();

		//�t�n�d��M�w�b�_�[�N���X
		private UoeRecHed _uoeRecHed = new UoeRecHed();

		//�t�n�d������}�X�^�N���X
        private UOESupplier _uOESupplier = new UOESupplier();

        //�d����M���[�h true:�d����M���� false:�ʏ폈��
        private bool _processStockSlipDtRecvDiv = false;

		private int _setid_flg;			//�h�c�����t���O
		private int _businessCode;		//�Ɩ��敪 1:���� 2:���� 3:�݌�
		private Int16 _lengthSndRcvBlk;	//����M�u���b�N��
        // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
        //���b�Z�[�W�Z�b�g�֌W
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

        //��pUSB�p
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<
		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
		# region �Ɩ��敪
		private const int HATSU = (int)EnumUoeConst.TerminalDiv.ct_Order;		// �Ɩ��敪������      		   
		private const int MITSU = (int)EnumUoeConst.TerminalDiv.ct_Estmt;		// �Ɩ��敪������      		   
		private const int ZAIKO = (int)EnumUoeConst.TerminalDiv.ct_Stock;		// �Ɩ��敪���݌�      		   
		# endregion

		# region ����M���R�[�h��`
		private const int SR_BLK = 256;			//����M���R�[�h�u���b�N�����ʁ�
		private const int SR_BLK_HONDA = 255;	//����M���R�[�h�u���b�N���z���_��p��
		private const int KAI_SND = 69;			//���MTXT�� �@�Ɩ��敪���J��
        private const int RECBUF_MAXSIZE = 5120;//��M�o�b�t�@�ő�l

		# endregion

		# region �R���o�[�g�^�C�v
		private const int JIS_EBC_CNV = 1;	// JIS ---> EBC  CNV TYPE	   
		private const int EBC_JIS_CNV = 2;	// EBC ---> JIS  CNV TYPE	   
		# endregion

		# region ���b�Z�[�W���t�h�ɕ\������t�B�[���h����
		private const int P_HED = 0;
		private const int P_MSG = 1;
		private const int P_GUIDE01 = 2;
		# endregion

		# region �ʐM�p�����[�^�萔
		//**************************************************************
		//           COMMON										            
        //**************************************************************
		private const Int16 OK	 = 0;	// �֐��̖߂�l�y�є��ʂɎg�p����  
		private const Int16 NG	 = -1;	// 								   
		private const Int16 NO	 = -1;	// 								   
		private const Int16 OFF	 = 0;	// �t���O�A�ϐ��� ON OFF�Ɏg�p���� 
		private const Int16 ON	 = 1;	// 								   
		private const Int16 RESET= 0;	// �t���O�A�ϐ��� SET RESET�Ɏg�p  
		private const Int16 SET	 = 1;	// 								   

		//**************************************************************
		//          C-Telecom Command No(Time Counter Octet).               
        //**************************************************************
		private const Int16 TCO_WAIT_RECEIVE_ENQ =    13;// 500msec * 60 / 1000 = 30
		private const Int16 TCO_WAIT_AFTER_SEND_WACK =14;//           48 /      = 24
		private const Int16 TCO_WAIT_FOR_ETB_ETX =    15;//           40 /      = 20
		private const Int16 TCO_WAIT_FOR_DIAL =       16;//          360 /      =180
		private const Int16 TCO_WAIT_RESERVE1 =       17;//                         
		private const Int16 TCO_WAIT_AFTER_SEND_ENQ = 18;//            6 /      =  3
		private const Int16 TCO_WAIT_AFTER_SEND_ETX = 19;//            6 /      =  3
		private const Int16 TCO_WAIT_RESERVE2 =       20;//                         
		
		//**************************************************************
		//          Return Code From C-Telecom Function.                    
        //**************************************************************
		private const Int16 R_LOPEN_MODEM_ERROR          = 0x0001; //                     
		private const Int16 R_LOPEN_DUPLICATE_OPEN       = 0x0002; //                     

		private const Int16 R_CONNECT_CANCEL             = 0x0001; //                     
		private const Int16 R_CONNECT_NOT_OPEN           = 0x0002; //                     
		private const Int16 R_CONNECT_TIMEOUT            = 0x0003; //                     

		private const Int16 R_DISCONNECT_CANCEL          = 0x0001; //                     
		private const Int16 R_DISCONNECT_NOT_OPEN        = 0x0002; //                     

		private const Int16 R_DIAL_CANCEL                = 0x0001; //                     
		private const Int16 R_DIAL_NOT_OPEN              = 0x0002; //                     
		private const Int16 R_DIAL_WAIT_DIAL             = 0x0003; //                     
		private const Int16 R_DIAL_DIAL_NO_ERROR         = 0x0004; //                     
		private const Int16 R_DIAL_BSC_CHECK             = 0x0005; //                     
		private const Int16 R_DIAL_BUSY_TALKING          = 0x0006; //                     
		private const Int16 R_DIAL_NO_ANSWER             = 0x0007; //                     

		private const Int16 R_SNDI_OPERATOR_STOP         = 0x0001; //                     
		private const Int16 R_SNDI_NOT_OPEN              = 0x0002; //                     
		private const Int16 R_SNDI_BSC_CHECK             = 0x0003; //                     
		private const Int16 R_SNDI_GET_EOT               = 0x0004; //                     
		private const Int16 R_SNDI_GET_DISK              = 0x0005; //                     
		private const Int16 R_SNDI_TIMEOUT               = 0x0006; //                     
		private const Int16 R_SNDI_DATA_ERROR            = 0x0007; //                     
		private const Int16 R_SNDI_GET_RVI               = 0x0008; //                     
		private const Int16 R_SNDI_CONTENTION            = 0x0009; //                     
		private const Int16 R_SNDI_WACK_COUNT_OVER       = 0x000A; //                     
		private const Int16 R_SNDI_PARAMETER_ERROR       = 0x000B; //                     
		private const Int16 R_SNDI_ID_CHANGE_ERROR       = 0x000E; //                     

		private const Int16 R_SNDIR_OPERATOR_STOP        = 0x0001; //                     
		private const Int16 R_SNDIR_NOT_OPEN             = 0x0002; //                     
		private const Int16 R_SNDIR_BSC_CHECK            = 0x0003; //                     
		private const Int16 R_SNDIR_GET_EOT              = 0x0004; //                     
		private const Int16 R_SNDIR_GET_DISK             = 0x0005; //                     
		private const Int16 R_SNDIR_TIMEOUT              = 0x0006; //                     
		private const Int16 R_SNDIR_DATA_ERROR           = 0x0007; //                     
		private const Int16 R_SNDIR_GET_RVI              = 0x0008; //                     
		private const Int16 R_SNDIR_CONTENTION           = 0x0009; //                     
		private const Int16 R_SNDIR_WACK_COUNT_OVER      = 0x000A; //                     
		private const Int16 R_SNDIR_PARAMETER_ERROR      = 0x000B; //                     
		private const Int16 R_SNDIR_ID_CHANGE_ERROR      = 0x000E; //                     

		private const Int16 R_SNDTEN_OPERATOR_STOP       = 0x0001; //                     
		private const Int16 R_SNDTEN_NOT_OPEN            = 0x0002; //                     
		private const Int16 R_SNDTEN_BSC_CHECK           = 0x0003; //                     
		private const Int16 R_SNDTEN_GET_EOT             = 0x0004; //                     
		private const Int16 R_SNDTEN_GET_DISK            = 0x0005; //                     
		private const Int16 R_SNDTEN_TIMEOUT             = 0x0006; //                     
		private const Int16 R_SNDTEN_DATA_ERROR          = 0x0007; //                     
		private const Int16 R_SNDTEN_GET_RVI             = 0x0008; //                     
		private const Int16 R_SNDTEN_CONTENTION          = 0x0009; //                     
		private const Int16 R_SNDTEN_WACK_COUNT_OVER     = 0x000A; //                     
		private const Int16 R_SNDTEN_PARAMETER_ERROR     = 0x000B; //                     
		private const Int16 R_SNDTEN_ID_CHANGE_ERROR     = 0x000E; //                     

		private const Int16 R_REC_OPERATOR_STOP          = 0x0001; //                     
		private const Int16 R_REC_NOT_OPEN               = 0x0002; //                     
		private const Int16 R_REC_BSC_CHECK              = 0x0003; //                     
		private const Int16 R_REC_GET_EOT                = 0x0004; //                     
		private const Int16 R_REC_GET_DISK               = 0x0005; //                     
		private const Int16 R_REC_TIMEOUT                = 0x0006; //                     
		private const Int16 R_REC_DATA_ERROR             = 0x0007; //                     
		private const Int16 R_REC_PARAMETER_ERROR        = 0x000B; //                     
		private const Int16 R_REC_RECV_LENGTH_OVER       = 0x000C; //                     
		private const Int16 R_REC_ID_CHANGE_ERROR        = 0x000E; //                     

		private const Int16 R_RECTEN_OPERATOR_STOP       = 0x0001; //                     
		private const Int16 R_RECTEN_NOT_OPEN            = 0x0002; //                     
		private const Int16 R_RECTEN_BSC_CHECK           = 0x0003; //                     
		private const Int16 R_RECTEN_GET_EOT             = 0x0004; //                     
		private const Int16 R_RECTEN_GET_DISK            = 0x0005; //                     
		private const Int16 R_RECTEN_TIMEOUT             = 0x0006; //                     
		private const Int16 R_RECTEN_DATA_ERROR          = 0x0007; //                     
		private const Int16 R_RECTEN_PARAMETER_ERROR     = 0x000B; //                     
		private const Int16 R_RECTEN_RECEIVE_LENGTH_OVER = 0x000C; //                     
		private const Int16 R_RECTEN_RECEIVE_BUFFER_FULL = 0x000D; //                     
		private const Int16 R_RECTEN_ID_CHANGE_ERROR     = 0x000E; //                     

		private const Int16 R_RESET_OPERATOR_STOP        = 0x0001; //                     
		private const Int16 R_RESET_NOT_OPEN             = 0x0002; //                     
		private const Int16 R_RESET_BSC_CHECK            = 0x0003; //                     

		private const Int16 R_WACK_OPERATOR_STOP         = 0x0001; //                     
		private const Int16 R_WACK_NOT_OPEN              = 0x0002; //                     
		private const Int16 R_WACK_BSC_CHECK             = 0x0003; //                     
		private const Int16 R_WACK_GET_EOT               = 0x0004; //                     
		private const Int16 R_WACK_GET_DISK              = 0x0005; //                     
		private const Int16 R_WACK_TIMEOUT               = 0x0006; //                     

		private const Int16 R_TTD_OPERATOR_STOP          = 0x0001; //                     
		private const Int16 R_TTD_NOT_OPEN               = 0x0002; //                     
		private const Int16 R_TTD_BSC_CHECK              = 0x0003; //                     
		private const Int16 R_TTD_GET_EOT                = 0x0004; //                     
		private const Int16 R_TTD_GET_DISK               = 0x0005; //                     
		private const Int16 R_TTD_TIMEOUT                = 0x0006; //                     
		private const Int16 R_TTD_DATA_ERROR             = 0x0007; //                     

		private const Int16 R_RVI_OPERATOR_STOP          = 0x0001; //                     
		private const Int16 R_RVI_NOT_OPEN               = 0x0002; //                     
		private const Int16 R_RVI_BSC_CHECK              = 0x0003; //                     
		private const Int16 R_RVI_GET_EOT                = 0x0004; //                     
		private const Int16 R_RVI_GET_DISK               = 0x0005; //                     
		private const Int16 R_RVI_TIMEOUT                = 0x0006; //                     
		private const Int16 R_RVI_DATA_ERROR             = 0x0007; //                     
		private const Int16 R_RVI_PARAMETER_ERROR        = 0x000B; //                     
		private const Int16 R_RVI_RECEIVE_LENGTH_OVER    = 0x000C; //                     

		private const Int16 R_SETID_ID_SET_ERROR         = 0x0001; //                     
		private const Int16 R_SETID_NOT_OPEN             = 0x0002; //                     

		private const Int16 R_JISEBC_CHANGE_LENGTH_OVER  = 0x0001; //                     

		private const Int16 R_EBCJIS_CHANGE_LENGTH_OVER  = 0x0001; //                     

		private const Int16 R_LCBR_REGION_NO_ERROR       =     -1; //                     

		private const Int16 R_LCBW_REGION_NO_ERROR       =     -1; //                     

		private const Int16 R_TCCTL_FILE_OPEN_ERROR      = 0x0001; //                     
		private const Int16 R_TCCTL_FILE_READ_ERROR      = 0x0002; //                     

		private const Int16 R_SNDFLE_FILE_OPEN_ERROR     = 0x0001; //                     
		private const Int16 R_SNDFLE_FILE_READ_ERROR     = 0x0002; //                     

		private const Int16 R_RCVFLE_FILE_OPEN_ERROR     = 0x0001; //                     
		private const Int16 R_RCVFLE_FILE_WRITE_ERROR    = 0x0002; //                     

		private const Int16 R_RSPFLE_FILE_OPEN_ERROR     = 0x0001; //                     
		private const Int16 R_RSPFLE_FILE_WRITE_ERROR    = 0x0002; //                     

		///**************************************************************
		//          Return Code From MSC Function.                          
        //***************************************************************
		private const Int16 R_FILE_OPEN_ERROR               = -1; // MSC Function Error. 
		private const Int16 R_FILE_READ_ERROR               = -1; // MSC Function Error. 
		private const Int16 R_FILE_WRITE_ERROR              = -1; // MSC Function Error. 

		//**************************************************************
		//          Line Open Type.                                         
        //**************************************************************
		private const Int16 BSC1_PRIMARY                = 0; //                          
		private const Int16 BSC2_PRIMARY                = 1; //                          
		private const Int16 BSC1_SECONDARY              = 2; //                          
		private const Int16 BSC2_SECONDARY              = 3; //                          

		//**************************************************************
		//          Telephone(Modem) Type.                                  
        //**************************************************************
		private const Int16 REGULAR_MODEM               = 4; //                          
		private const Int16 IRREGULAR_MODEM             = 9; //                          

		//**************************************************************
		//          Auto Change Code Flag.                                  
        //**************************************************************
		private const Int16 NO_CHANGE_CODE              = 0; //                          
		private const Int16 CHANGE_CODE                 = 1; //                          

		//**************************************************************
		//          Auto Change Code Flag.                                  
        //**************************************************************
		private const Int16 NO_CHANGE_ID                = 0; //                          
		private const Int16 CHANGE_ID                   = 1; //                          

		//**************************************************************
		//          Scope Output Type.                                      
        //**************************************************************
		private const Int16 CRT                         = 0; //                          
		private const Int16 PRINTER                     = 1; //                          
		private const Int16 SCOPE_OFF                   = 2; //                          

		//**************************************************************
		//          Send Text Type ( SENDI & SNDIR ).                       
        //**************************************************************
		private const Int16 S_ETB_CHANGE                = 0; //                          
		private const Int16 S_ETX_CHANGE                = 1; //                          
		private const Int16 S_DLE_ETB                   = 2; //                          
		private const Int16 S_DLE_ETX                   = 3; //                          
		private const Int16 S_ETB_NO_CHANGE             = 4; //                          
		private const Int16 S_ETX_NO_CHANGE             = 5; //                          
		private const Int16 S_SOH_ETB_CHANGE            = 6; //                          
		private const Int16 S_SOH_ETX_CHANGE            = 7; //                          
		private const Int16 S_SOH_DLE_ETB               = 8; //                          
		private const Int16 S_SOH_DLE_ETX               = 9; //                          
		private const Int16 S_SOH_ETB_NO_CHANGE         =10; //                          
		private const Int16 S_SOH_ETX_NO_CHANGE         =11; //                          

		//**************************************************************
		//          Send Text Type ( SNDTEN ).                              
        //**************************************************************
		private const Int16 S_ETB_ETX                   = 0; //                          
		private const Int16 S_ETX_ETX                   = 1; //                          
		private const Int16 S_DLE_ETB_DLE_ETX           = 2; //                          
		private const Int16 S_DLE_ETX_DLE_ETX           = 3; //                          
		private const Int16 S_ETB_ETB                   = 4; //                          
		private const Int16 S_DLE_ETB_DLE_ETB           = 5; //                          

		//**************************************************************
		//          Recive Text Type ( REC ).                               
        //**************************************************************
		private const Int16 R_ETB                       = 0; //                          
		private const Int16 R_ETX                       = 1; //                          
		private const Int16 R_DLE_ETB                   = 2; //                          
		private const Int16 R_DLE_ETX                   = 3; //                          
		private const Int16 R_SOH_ETB                   = 4; //                          
		private const Int16 R_SOH_ETX                   = 5; //                          
		private const Int16 R_SOH_DLE_ETB               = 6; //                          
		private const Int16 R_SOH_DLE_ETX               = 7; //                          

		//**************************************************************
		//          Reqire And Answer Common Headder Size.                  
        //**************************************************************
		private const Int16 SYSTEM_HEADER_SIZ           =24; // System Header Size .     
		private const Int16 USER_HEADER_SIZ             =44; // User Header Size.        

		//**************************************************************
		//          Telecommunication Data Buffer Size.                     
        //**************************************************************
		private const Int16 TEL_NO_SIZ                =  64; // Telephone No Buffer Size.
		private const Int16 TEXT_BUFFER_SIZ           =4096; // Text Buffer Size.        
		private const Int16 BLOCK_BUFFER_SIZ          =1024; // Block Buffer Size.       
		private const Int16 SEND_ID_SIZ               =  15; // Send Id Buffer Size.     
		private const Int16 RECV_ID_SIZ = 15; // Receive Id Buffer Size.  
		# endregion

		# region �G���[���b�Z�[�W
		//�G���[���b�Z�[�W
		private const string MESSAGE_ERROR01 = "���M�ҏW�f�[�^�����݂��܂���B";
		private const string MESSAGE_ERROR02 = "������}�X�^�ɑ��݂��܂���B";
		private const string MESSAGE_ERROR03 = "�_�C�������O���s�I�I�A���_�C�������܂����H";
		private const string MESSAGE_ERROR04 = "����悪�ł܂���I�I�A���_�C�������܂����H";
		private const string MESSAGE_ERROR05 = "DIAL ������̓��f�����ُ�ł�������𒆎~���܂�";
		private const string MESSAGE_ERROR06 = "�����_�C�����@����I���I�I";
		private const string MESSAGE_ERROR07 = "Y�F�Ď��s�@N:�I��";
		# endregion

		# region UoeLoadLibrary()�̐ݒ�E����
		//UoeLoadLibrary()�̐ݒ�E����
		private const int ctUoeLoadLibraryModeSet = 0;	//�ݒ�
		private const int ctUoeLoadLibraryModeRset = 1;	//����
		# endregion

		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate

        # region ��ʊ֌W
        //���b�Z�[�W�N���A
        //internal delegate void msg_psfclrEventHandler(int fld);
        public delegate void msg_psfclrEventHandler(int fld);

        //���b�Z�[�W�\��
        public delegate void msg_pssputEventHandler(int fld, string text);
        # endregion

        # region �a�r�b�ʐM
        // �a�r�b�ʐM
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 LCBW(Int16 icbno, Int16 icbdata);
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 L_LOPEN(Int16 opn_typ);
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 DIAL(Int16 tel_typ, string tel_no);
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 SNDI(byte[] text, Int16 text_len, Int16 snd_typ);
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 LRESET();
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 L_LCLOSE();
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 DISCONNECT();
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 REC(byte[] text_buff, Int16 text_buff_siz, ref Int16 block_len, ref Int16 text_len);
        [DllImport("PMUOE00001C.dll")]
        private static extern Int16 SETID(byte[] send_id, StringBuilder recv_id);
        # endregion
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
        //���b�Z�[�W�N���A
        public event msg_psfclrEventHandler _msg_psfclr;

        //���b�Z�[�W�\��
        public event msg_pssputEventHandler _msg_pssput;
        # endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		# region �t�n�d���M�w�b�_�[�N���X
		/// <summary>
		/// �t�n�d���M�w�b�_�[�N���X
		/// </summary>
		public UoeSndHed uoeSndHed
		{
			get
			{
				return this._uoeSndHed;
			}
			set
			{
				this._uoeSndHed = value;
			}
		}
		# endregion

		# region �t�n�d��M�w�b�_�[�N���X
		/// <summary>
		/// �t�n�d��M�w�b�_�[�N���X
		/// </summary>
		public UoeRecHed uoeRecHed
		{
			get
			{
				return this._uoeRecHed;
			}
			set
			{
				this._uoeRecHed = value;
			}
		}
		# endregion

		# region �t�n�d������}�X�^�N���X
		/// <summary>
		/// �t�n�d������}�X�^�N���X
		/// </summary>
		public UOESupplier uOESupplier
		{
			get
			{
				return this._uOESupplier;
			}
			set
			{
				this._uOESupplier = value;
			}
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods

		# region �t�n�d����M
		/// <summary>
		/// �t�n�d����M
		/// </summary>
		/// <param name="para"></param>
		/// <param name="recHed"></param>
        /// <param name="processStockSlipDtRecvDiv"></param>
        /// <param name="message"></param>
		/// <returns></returns>
        public int UoeSndRcv(UoeSndHed para, out UoeRecHed recHed, bool processStockSlipDtRecvDiv, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			recHed = new UoeRecHed();
            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
            //�t�^�oUSB��p:Option.ON
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                //���b�Z�[�W���擾
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            }
            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

			try
			{
                //�d����M���[�h�̐ݒ�
                _processStockSlipDtRecvDiv = processStockSlipDtRecvDiv;

				//�t�n�d����M�������o�N���X�̕ۑ�
				_uoeSndHed = para;

				//�Ɩ��敪 1:���� 2:���� 3:�݌�
				_businessCode = para.BusinessCode;

				//����M�u���b�N���̎擾
				if (para.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0501)
				{
					_lengthSndRcvBlk = SR_BLK_HONDA;
				}
				else
				{
					_lengthSndRcvBlk = SR_BLK;
				}

				if (_uoeSndHed == null)
				{
					status = (int)EnumUoeConst.Status.ct_NOT_FOUND;
					message = MESSAGE_ERROR01;
				}
				else if (_uoeSndHed.UoeSndDtlList.Count == 0)
				{
					status = (int)EnumUoeConst.Status.ct_NOT_FOUND;
					message = MESSAGE_ERROR01;
				}
				//������}�X�^�̎擾
				else if ((_uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(_uoeSndHed.UOESupplierCd)) == null)
				{
					status = -1;
					message = MESSAGE_ERROR02;
				}
				//�t�n�d����M���C��
				else
				{
					//UoeLoadLibrary�̐ݒ�
					if ((status = UoeLoadLibrary(ctUoeLoadLibraryModeSet, out message)) == (int)EnumUoeConst.Status.ct_NORMAL)
					{
						_uoeRecHed = new UoeRecHed();
						_uoeRecHed.UOESupplierCd = para.UOESupplierCd;
						_uoeRecHed.BusinessCode = para.BusinessCode;
						_uoeRecHed.CommAssemblyId = para.CommAssemblyId;
						_uoeRecHed.UoeRecDtlList = new List<UoeRecDtl>();

                        // ---DEL 2010/05/07 ------------------>>>>>
                        //if ((status = UoeSndRcvMain(out message)) == (int)EnumUoeConst.Status.ct_NORMAL)
                        //{
                        //    message = "";
                        //}
                        // ---DEL 2010/05/07 ------------------<<<<<
                        // ---ADD 2010/05/07 ------------------<<<<<
                        // �ʐM�A�Z���u��ID���D��UOE Web�̏ꍇ�AHTTP�ʐM���s��
                        if (IsOtherMakerUOEWeb(_uOESupplier.CommAssemblyId))
                        {
                            // ���̃��\�b�h�ďo���ňȉ��̏������s��
                            // �@_uoeSndHed(���M�d��)�𑗐MSOAP���b�Z�[�W�ɕϊ�
                            // �A���MSOAP���b�Z�[�W��HTTP�ʐM
                            // �BHTTP�ʐM�̃��X�|���X(��MSOAP���b�Z�[�W)��_uoeRecHed(��M�d��)�ɕϊ�
                            IUOEWebClient webClient = UOEWebClientFactory.Create(_uOESupplier);
                            status = webClient.SendAndReceive(
                                _uoeSndHed,                  // ���M�d���f�[�^
                                processStockSlipDtRecvDiv,   // �d����M�����t���O
                                out _uoeRecHed,              // ��M�d���f�[�^
                                out message                  // �G���[���b�Z�[�W
                            );
                        }
                        // �ʐM�A�Z���u��ID���D��UOE Web�ȊO�̏ꍇ�A�����̏������s��
                        else if ((status = UoeSndRcvMain(out message)) == (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            message = "";
                        }
                        // ---ADD 2010/05/07 ------------------<<<<<

                        recHed = _uoeRecHed;
                        
                        //UoeLoadLibrary�̉���
						//UoeLoadLibrary(ctUoeLoadLibraryModeRset, out message);
					}
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}


			return (status);
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d����M���C�u�����̐ݒ�E����
		/// <summary>
		/// �t�n�d����M���C�u�����̐ݒ�E����
		/// </summary>
		/// <param name="mode"></param>
		/// <returns></returns>
		[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern IntPtr LoadLibrary(string lpFileName);
		[DllImport("kernel32", SetLastError = true)]
		internal static extern bool FreeLibrary(IntPtr hModule);
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = false)]
		internal static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
		private int UoeLoadLibrary(int mode, out string message)
		{
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			return (status);
		}
		# endregion

		# region �t�n�d����M���C��
		/// <summary>
		/// �t�n�d����M���C��
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private int UoeSndRcvMain(out string message)
		{
			//�ϐ��̏�����
			Int16 snrv_flg = NG;
			Int16 status = OK;

			message = "";

			try
			{
				// < �ʐM�f�t�H���g�l�ύX >--------------------------------------------
				if ((status = vctel_lcbw(out message)) != OK)
				{
				}
				// < RS-232C�������^�������� >----------------------------------------
				else if ((status = vctel_lopn(out message)) != OK)
				{
				}
				// < �h�c�����^�h�c�Z�b�g >--------------------------------------------
				else if ((status = ictel_stid(out message)) != OK)
				{
				}
				// < �����_�C�������M >------------------------------------------------
				else if ((status = vctel_dial(out message)) != OK)
				{
				}
				// �f�[�^���M�^��M ---------------------------------------------------
				else
				{
					foreach (UoeSndDtl dtl in _uoeSndHed.UoeSndDtlList)
					{
						_uoeSndDtl = dtl;

						// �f�[�^���M���� ---------------------------------------------
						status = idata_send(out message);
						if ((status != 0) && (!(_setid_flg == ON && status == 8)))
						{
							break;
						}

						// �f�[�^��M���� ---------------------------------------------
						if (status == OK)
						{
							if((status = vdata_recv(out message)) != OK)
							{
								break;
							}
						}
						snrv_flg = OK;
					}
				}

				// < ����ؒf >--------------------------------------------------------
				if (snrv_flg == OK)
				{
					if((status = DISCONNECT()) == 0)
					{
						msg_pssput(P_MSG, "����I��");
						message = "TCO_WAIT_AFTER_SEND_ENQ �װ";
					}
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			// < ����۰�� >-------------------------------------------------------
			finally
			{
				//����ؒf
				L_LCLOSE();
                _uoeOprtnHisLogAcs.log_update();
			}
			return (status);
		}
		# endregion

		# region �ʐM�f�t�H���g�l�ύX
		/// <summary>
		/// �ʐM�f�t�H���g�l�ύX
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 vctel_lcbw(out string message)
		{
			//�ϐ��̏�����
			Int16 status = OK;
			message = "";

			try
			{
				if ((status = LCBW(TCO_WAIT_AFTER_SEND_ENQ, 30)) != OK)
				{
					message = "TCO_WAIT_AFTER_SEND_ENQ �װ";
					return (status);
				}

				if ((status = LCBW(TCO_WAIT_AFTER_SEND_ETX, 30)) != OK)
				{
					message = "TCO_WAIT_AFTER_SEND_ETX �װ";
					return (status);
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}

			return (status);
		}
		# endregion

		# region ��������
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		Int16	vctel_lopn(out string message)
		{
			//�ϐ��̏�����
			Int16 status = OK;
			message = "";

			try
			{
                msg_pssput(P_MSG, "�����������");

                status = L_LOPEN(BSC2_PRIMARY);			// �D���				   

                if (status != 0x00)
				{
                    message = "����̏������Ɏ��s���܂����B";
					return (status);
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}

			return (status);
		}
		# endregion

		# region �h�c�����^�h�c�Z�b�g
        /// <summary>
        /// �h�c�����^�h�c�Z�b�g
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
		private Int16	ictel_stid(out string message)
		{
			//�ϐ��̏�����
			Int16 status = OK;
			byte[] id_str = new byte[20];

			message = "";

			try
			{
				// < �h�c���� >--------------------------------------------------------
				string uOEIDNumString = _uOESupplier.UOEIDNum.Trim();
				//�h�c�@�L��
				if (uOEIDNumString.Length > 0)
				{
					_setid_flg = ON;					
				}
				//�h�c�@�Ȃ�
				else
				{
					_setid_flg = OFF;
				}
				
				// < �h�c�Z�b�g	>------------------------------------------------------
				if ( _setid_flg == ON )
				{
					UoeCommonFnc.MemCopy(ref id_str, uOEIDNumString, uOEIDNumString.Length);

					StringBuilder recv_id = new StringBuilder(1024);
					status = SETID(id_str, recv_id );
					if ( status != 0)
					{
						message = "�h�c�����@�ُ�I�I";
						return (status);
					}
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
        
		# region �����_�C�������M����
		/// <summary>
		/// �����_�C�������M����
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 vctel_dial(out string message)
		{
			//�ϐ��̏�����
			Int16 status = OK;
			Int16	end_flg = 1;
			string wdial = _uOESupplier.TelNo.Trim();			//�d�b�ԍ�
			string w_msg = uOESupplier.UOESupplierName.Trim();	//�����於

			message = "";

			try
			{
				//////***********   < �����_�C�������M >   ***************
                msg_pssput(P_HED, w_msg);

                while (end_flg == 1)
				{
					msg_pssput( P_MSG, "�_�C������" );
                    status = DIAL( REGULAR_MODEM, wdial );
					msg_psfclr( P_MSG );

    				switch( status )
					{
						case OK:							// �_�C�����n�j�I�I	   
							msg_pssput(P_MSG, "�_�C�����@����I��");
							end_flg = 0;				// �_�C��������I��    
							break;

						case R_DIAL_NO_ANSWER:				// ���艞������       	
						case R_DIAL_BSC_CHECK:				// �a�r�b�`�F�b�N�G���[
						case R_DIAL_BUSY_TALKING:			// �b��				   
							Console.Beep();					// �r�[�v��				
							string work = "";

							if (status == R_DIAL_NO_ANSWER)
							{
								work = MESSAGE_ERROR04 + "\r\n" + "\r\n" + MESSAGE_ERROR07;
							}
							else
							{
								work = MESSAGE_ERROR03 + "\r\n" + "\r\n" + MESSAGE_ERROR07;
							}

                            // ---DEL K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                            //DialogResult dialogResult = TMsgDisp.Show(
                            //    //this,
                            //    (IWin32Window)null,
                            //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //    //this.Name,
                            //    "",
                            //    work,
                            //    0,
                            //    MessageBoxButtons.YesNo,
                            //    MessageBoxDefaultButton.Button1);

                            //if (dialogResult != DialogResult.Yes)
                            //{
                            //    message = "�_�C�������M �G���[";
                            //    return (status);
                            //}
                            // ---DEL K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

                            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  --------------------------------------->>>>>
                            if (this._opt_FuTaBa == (int)Option.ON)
                            {
                                //������������(����)�ł͂Ȃ�
                                if (!(Thread.GetData(msgShowSolt) != null
                                    && (Int32)Thread.GetData(msgShowSolt) == 1))
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(
                                        //this,
                                   (IWin32Window)null,
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        //this.Name,
                                   "",
                                   work,
                                   0,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxDefaultButton.Button1);

                                    if (dialogResult != DialogResult.Yes)
                                    {
                                        message = "�_�C�������M �G���[";
                                        return (status);
                                    }

                                }
                                else
                                {
                                    message = "�_�C�������M �G���[";
                                    return (status);
                                }
                            }
                            else
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                    //this,
                                    (IWin32Window)null,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    //this.Name,
                                    "",
                                    work,
                                    0,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxDefaultButton.Button1);

                                if (dialogResult != DialogResult.Yes)
                                {
                                    message = "�_�C�������M �G���[";
                                    return (status);
                                }

                            }
                            // ---ADD K2014/05/26 ���N�n�� Redmine 42571  ---------------------------------------<<<<<

							end_flg = 1;		// ���g���C�@�Z�b�g	   
							break;
						default:							// ���̑��_�C�����G���[
							message = "DIAL ������̓��f�����ُ�ł�������𒆎~���܂�";
							return(status);
					} // switch	

				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �f�[�^���M����
		/// <summary>
		/// �f�[�^���M����
		/// </summary>
		/// <param name="send_text"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 idata_send( out string message )
		{
			//�ϐ��̏�����
			string procNm = "idata_send";
			Int16 status = OK;
			Int16 send_len;
			Int16 send_max = 0;

			byte[] spc_buff = new byte[2048];
			byte[] send_src = new byte[2048];
			byte[] send_dst = new byte[2048];
			byte[] send_txt = new byte[2048];

			message = "";

			try
			{
				msg_pssput( P_MSG, "���M������" );

				//���M�d���ϊ����i�h�r���d�a�b��
				send_src = _uoeSndDtl.SndTelegram;
				vjisebc_cnv(JIS_EBC_CNV, ref send_src, ref send_dst, send_src.Length);

				// ���M�񐔂��Z�o(8=2048/256)--------------------------------------
                send_max = (Int16)(_uoeSndDtl.SndTelegramLen / _lengthSndRcvBlk);
                if((_uoeSndDtl.SndTelegramLen % _lengthSndRcvBlk) != 0)
                {
                    send_max++;
                }

				for (Int16 ix=0; ix<send_max; ix++)
				{
					// �Ɩ��� ���M÷�Ē���o --------------------------------------
                    send_len = isend_tget(ix, _uoeSndDtl.SndTelegramLen);
					UoeCommonFnc.MemCopy(ref send_txt, 0, ref send_dst, ix * _lengthSndRcvBlk, send_len);

					// ���M�f�[�^���O���� -----------------------------------------
                    log_update(procNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_SND, send_txt, send_len);

					// �f�[�^���M -------------------------------------------------
					if (ix == send_max - 1)		// �ŏI�f�[�^���M			   
					{
						status = SNDI(send_txt, send_len, S_DLE_ETX);
					}
					else
					{
						status = SNDI(send_txt, send_len, S_DLE_ETB);
					}

					// SETID�L��(����)�ͤ�Ϗ��v�� �n�j ----------------------------
					if ((status != 0) && (!(_setid_flg == ON && status == 8)))
					{
						SaveRecvText((int)(EnumUoeConst.ctDataSendCode.ct_SndNG));	//���M�t���O �G���[�Z�b�g
						message = "SEND ������ُ�ł�������𒆎~���܂�";
						return(status);
					}
				}

				// �d�n�s���M ----------------------------------------------------
				msg_psfclr( P_MSG );
				if ((status = LRESET()) != 0)
				{
					SaveRecvText((int)(EnumUoeConst.ctDataSendCode.ct_SndNG));	//���M�t���O �G���[�Z�b�g
					message = "RESET ������ُ�ł�������𒆎~���܂�";
					return(status);
				}
				status = OK;
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}

			return (status);
		}
		# endregion

		# region ���M�e�L�X�g����o�������[�J�ʁE�Ɩ��ʁ�
		/// <summary>
		/// ���M�e�L�X�g����o�������[�J�ʁE�Ɩ��ʁ�
		/// </summary>
		/// <param name="blk">���M�u���b�N(0�`)</param>
        /// <param name="sndTelegramLen">���M���T�C�Y</param>
        /// <returns>���M�T�C�Y</returns>
        private Int16 isend_tget(Int16 blk, Int32 sndTelegramLen)
		{
			Int16 send_len = 0;	//���M�e�L�X�g��

			switch (_uOESupplier.CommAssemblyId)
			{
                //�z���_
                case EnumUoeConst.ctCommAssemblyId_0501:
                    Int16 mei_cnt = (Int16)_uoeSndDtl.UOESalesOrderRowNo.Count;

                    //����
                    if (_businessCode == HATSU)
                    {
                        send_len = (Int16)(mei_cnt * 17 + 84);
                    }
                    //���ρE�݌�
                    else
                    {
                        send_len = (Int16)(mei_cnt * 13 + 58);
                    }
                    break;
                //�D�ǃ��[�J�[
                //case EnumUoeConst.ctCommAssemblyId_1001:
                //    send_len = 256;
                //    break;
                default:
                    //���M�u���b�N�T�C�Y�ȉ��̏ꍇ
                    if (((sndTelegramLen - (blk * _lengthSndRcvBlk)) / _lengthSndRcvBlk) > 0)
                    {
                        send_len = _lengthSndRcvBlk;
                    }
                    else
                    {
                        send_len = (Int16)(sndTelegramLen % _lengthSndRcvBlk);
                    }
                    break;
			}
			return (send_len);
		}
		# endregion

		# region �f�[�^��M����
		/// <summary>
		/// �f�[�^��M����
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br></br>
        /// <br></br>
        /// <br>Update Note : 2012/10/03 FSI���X�� �M�p</br>
        /// <br>            : �^�C���A�E�g�G���[���b�Z�[�W�s���Ή�</br>
        /// </remarks>
        private Int16 vdata_recv(out string message)
		{
			//�ϐ��̏�����
			string procNm = "vdata_recv";
			Int16 status = OK;
			message = "";

			Int16	ix = 0;
			Int16	recv_pnt = 0;
			Int16	recv_type = 0;
			Int16	recv_leng = 0;
			Int16	err_flg = OK;
			byte[]	recv_text = new byte[300];
            byte[] recv_work = new byte[RECBUF_MAXSIZE];

			try
			{
				// ���M�@���䕔�Z�b�g----------------------------------------------
				msg_pssput( P_MSG, "��M������" );
				UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length );

                while (true)
				{
					// �f�[�^��M -------------------------------------------------
					UoeCommonFnc.MemSet(ref recv_text, 0x20, _lengthSndRcvBlk);
                    recv_leng = 0;
					status = REC(recv_text, _lengthSndRcvBlk, ref recv_leng, ref recv_type);

					// ��M�擾----------------------------------------------------
					if (status == 0)
					{
						// ��M�f�[�^���O����--------------------------------------
                        log_update(procNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_REC, recv_text, recv_leng);

                        //�z���_��p����
                        if((uoeSndHed.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0501)
                        && (recv_leng < SR_BLK_HONDA))
                        {
                            UoeCommonFnc.MemSet(ref recv_text, recv_leng, 0x40, SR_BLK_HONDA - recv_leng);
                            recv_leng = SR_BLK_HONDA;
                        }
                        //�D�ǂŃ_�~�[�d���̏ꍇ�A�ēx��M���������s����
                        else if (_uoeSndRcvJnlAcs.ChkCommAssemblyId(uoeSndHed.CommAssemblyId) == false)
                        {
                            //�_�~�[�d���̏ꍇ�ēx�A��M���������s����
                            if(SkipDummyTelegram(recv_text, recv_leng) == true)
                            {
                                // ��M�񐔃I�[�o�[
                                if (++ix > 20)
                                {
                                    status = R_REC_TIMEOUT;
                                    err_flg = NG;
                                    break;
                                }
                                continue;
                            }

                            //��M�d���T�C�Y��256�o�C�g�łȂ��ꍇ�A�����I��256�o�C�g�ɕύX����
                            if (recv_leng != SR_BLK)
                            {
                                recv_leng = SR_BLK;

                            }
                        }

                        //���[�N�o�b�t�@�֕ۑ�
                        UoeCommonFnc.MemCopy(ref recv_work, recv_pnt, ref recv_text, 0, recv_leng);
						recv_pnt += recv_leng;
                        ix = 0;

                        //�d����M����̐�p����(�����E�r�o�j)
                        if ((recv_pnt > 0)
                        && (_processStockSlipDtRecvDiv == true)
                        && (_uoeSndRcvJnlAcs.ChkStockSlipDtRecvDiv(uoeSndHed.UOESupplierCd) == true))
                        {
                            //��M�d���i�[����
                            int dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

                            // ��Mͯ�ް�װ����			
                            if ((status = vchek_herr(ref recv_work, out message)) != 0)
                            {
                                dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
                            }

                            SaveRecvText(dataSendCode, ref recv_work, recv_pnt);
            				UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length );
                            recv_pnt = 0;
                        }
					}
					// ��M����I��------------------------------------------------
					else if (status == R_REC_GET_EOT)
					{
						status = OK;
						break;
					}
					// �^�C���A�E�g------------------------------------------------
					else if (status == R_REC_TIMEOUT)
					{
                        // --- ADD 2012/10/03 ----------->>>>>
                        err_flg = NG;
                        // --- ADD 2012/10/03 -----------<<<<<
                        break;
					}
                    // ���̑��G���[------------------------------------------------
                    else
                    {
                        err_flg = NG;
                        break;
                    }
				}

				if ( err_flg == NG ) {
					SaveRecvText((int)(EnumUoeConst.ctDataSendCode.ct_RcvNG));	//���M�t���O �G���[�Z�b�g
					message = "RECV ������ُ�ł�������𒆎~���܂�";
					return(status);
				}

                if(recv_pnt > 0)
                {
                    //��M�d���i�[����
				    int dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

				    // ��Mͯ�ް�װ����			
				    if ((status = vchek_herr(ref recv_work, out message)) != 0)
				    {
					    dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
				    }

				    SaveRecvText(dataSendCode, ref recv_work, recv_pnt);
                }
				msg_psfclr( P_MSG );
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return(status);
		}
		# endregion


        # region �D�ǃ_�~�[�d���X�L�b�v����
        /// <summary>
        /// �D�ǃ_�~�[�d���X�L�b�v����
        /// </summary>
        /// <param name="src">��M�e�L�X�g</param>
        /// <param name="len">��M�e�L�X�g��</param>
        /// <returns>true:�_�~�[�d�� false:�ʏ�d��</returns>
        private bool SkipDummyTelegram(byte[] src, int len)
        {
            bool boolReturn = true;

            try
            {
                if (len > 0)
                {
                    byte[] dst = new byte[len];
                    vjisebc_cnv(EBC_JIS_CNV, ref src, ref dst, len);

                    //�󒍕��i�ԍ� �o�ו��i�ԍ��̋󔒃`�F�b�N
                    for (int i = 0; i < 40; i++)
                    {
                        if ((dst[i+25] == 0x20) || (dst[i+25] == 0x00)) continue;
                        boolReturn = false;
                        break;
                    }

                    //�i���̋󔒃`�F�b�N
                    if (boolReturn == true)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            if ((dst[i + 73] == 0x20) || (dst[i + 73] == 0x00)) continue;
                            boolReturn = false;
                            break;
                        }
                    }
                }
			}
			catch (Exception)
			{
                boolReturn = false;
			}

            return (boolReturn);
        }

        # endregion


        # region ��M�w�b�_�[�G���[�`�F�b�N
        /// <summary>
		/// ��M�w�b�_�[�G���[�`�F�b�N
		/// </summary>
		/// <param name="text"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 vchek_herr(ref byte[] text, out string message )
		{
			//�ϐ��̏�����
			Int16 status = OK;
			string err_msg = "";
			message = "";

			switch (_uOESupplier.CommAssemblyId)
			{
				//���g���^��
				case EnumUoeConst.ctCommAssemblyId_0102:
					# region ���g���^��
					Int16 com_flg = OK;

					if (text[8] == 0x00)
					{
						return (status);			// ����Ԃ�					   
					}

					///////******  ���ʃ`�F�b�N  ***********
					switch (text[8])
					{
						case 0x11: err_msg = "��ݻ޸��� �װ"; break;
						case 0x12: err_msg = "�����Ϻ��� �װ"; break;
						case 0x14: err_msg = "�߽ܰ�� �װ"; break;
						case 0x88: err_msg = "ٽ��� �װ"; break;
						case 0x99: err_msg = "��� �װ"; break;
						default: com_flg = NG; break;
					}

					if (com_flg == NG)
					{
						if (_businessCode == HATSU)	// ����			
						{
							switch (text[8])
							{
								case 0xf1: err_msg = "��ݻ޸��� �װ"; break;
								case 0xf2: err_msg = "�ݼ��ް� ż"; break;
								case 0xf3: err_msg = "ɳ�ݺ��� ż"; break;
								case 0xf4: err_msg = "�ް� ż"; break;
								case 0xf5: err_msg = "�ò���� �װ"; break;
								case 0xf7: err_msg = "�����Ϻ��� �װ"; break;
								case 0xc3: err_msg = "���� �ر�� ̶"; break;
								case 0xc4: err_msg = "ʯ�����ĳ�� �װ"; break;
								case 0xc5: err_msg = "̫۰ɳ�ݺ��� �װ"; break;
								case 0xc6: err_msg = "���� ������ �װ"; break;
								default: break;
							}
						}
						else if (_businessCode == MITSU)	// ����			
						{
							switch (text[8])
							{
								case 0xf1: err_msg = "��ݻ޸��� �װ"; break;
								case 0xf4: err_msg = "�ް� ż"; break;
								case 0xf7: err_msg = "�����Ϻ��� �װ"; break;
								case 0xc1: err_msg = "ڰ� �װ"; break;
								case 0xc2: err_msg = "�������� �װ"; break;
								case 0xc3: err_msg = "���ݷ��� �װ"; break;
								default: break;
							}
						}
						else						// �݌�			
						{
							switch (text[8])
							{
								case 0xf1: err_msg = "��ݻ޸��� �װ"; break;
								case 0xf4: err_msg = "�ް� ż"; break;
								default: break;
							}
						}
					}
					# endregion
					break;
				//�����Y��
				case EnumUoeConst.ctCommAssemblyId_0202:
					# region �����Y��
					if (text[6] == 0x00) return (0);		// ����Ԃ�		   

					///////******  ���ʃ`�F�b�N  ***********
					switch( text[6] )
					{
						case 0x13:	err_msg = "���޽ �޶����װ" ;	break;
						case 0x17:	err_msg = "���޽ ò����"    ;	break;
						case 0x99:	err_msg = "��� �װ"         ;	break;
						default:	err_msg = String.Format("�װ����= 0x%2x",(int)text[6]); break;
					}
					# endregion
					break;
				//���O�H��
				case EnumUoeConst.ctCommAssemblyId_0301:
				//���}�c�_��
				case EnumUoeConst.ctCommAssemblyId_0401:
				case EnumUoeConst.ctCommAssemblyId_0402:
					# region ���O�H�����}�c�_��
					if ((_uoeSndDtl.UOESalesOrderNo == 0) && (_uoeSndDtl.UOESalesOrderRowNo.Count == 0))
					{
						///////*********  �J�ǖ��͕ǁH  **************
						if (UoeCommonFnc.MemCmp(text, 30, "E1 ", 3) == 0) err_msg = "հ�ް���� �װ";
						else if (UoeCommonFnc.MemCmp(text, 30, "E2 ", 3) == 0) err_msg = "�߽ܰ�� �װ";
						else if (text[6] != 0x00) err_msg = "��� �װ";

						// ���ސV�ް�ޮ�
						if (_uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0402)
						{
							if (UoeCommonFnc.MemCmp(text, 30, "E3 ", 3) == 0) err_msg = "νļ���޲���";
							else if (UoeCommonFnc.MemCmp(text, 30, "E4 ", 3) == 0) err_msg = "���� �� ������";
							else if (UoeCommonFnc.MemCmp(text, 30, "E5 ", 3) == 0) err_msg = "�ޮ�� ���خ�";
							else if (UoeCommonFnc.MemCmp(text, 30, "E6 ", 3) == 0) err_msg = "̫�ϯ� �װ";
						}
					}
					else
					{
						switch (text[6])
						{
							case 0x99: err_msg = "��� �װ"; break;
							case 0x88: err_msg = "�޶ݶ޲ �װ"; break;
							default:
								if (_businessCode == HATSU || _businessCode == MITSU)
								{
									if (text[48] != 0x00)
									{
										err_msg = "ͯ�� �װ";
									}
								}
								break;
						}
					}
					# endregion
					break;
				//���z���_��
				case EnumUoeConst.ctCommAssemblyId_0501:
					# region ���z���_��
					if (UoeCommonFnc.MemCmp(text, "TF2101", 6) == 0) err_msg = "ν� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2102", 6) == 0) err_msg = "FENICS ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2103", 6) == 0) err_msg = "ν� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2104", 6) == 0) err_msg = "FENICS ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2105", 6) == 0) err_msg = "���� ���ޮ�� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2106", 6) == 0) err_msg = "�ޭ�� ���ޮ�� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2108", 6) == 0) err_msg = "հ�ް���� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2109", 6) == 0) err_msg = "�߽ܰ�� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF2110", 6) == 0) err_msg = "��ݻ޸��� ��ޮ�";
					else if (UoeCommonFnc.MemCmp(text, "TF21", 4) == 0) err_msg = "FENICS ��ޮ�";

					if (text[8] == 0x31)
					{
						err_msg = "��ع�� �װ";
					}
					else if (text[8] == 0x33)
					{
						err_msg = "�޶ݶ޲ �װ";
					}
					if (_businessCode == HATSU && text[8] == 0x32)
					{
						err_msg = "ͯ�޴װ";
					}
					# endregion
					break;
				//���D�ǁi���̑��j��
				default:
					# region ���D�ǁi���̑��j��
					if (UoeCommonFnc.MemCmp(text, "91", 2) == 0)				//�J�ǋ��� 
					{
						if (istrg_spac(text, 37, 32) != 0)
						{
							err_msg = "����� ���";
						}
						else
						{
							UoeCommonFnc.MemCopy(ref err_msg, ref text, 36, 32);
						}
					}
					else if (UoeCommonFnc.MemCmp(text, "98", 2) == 0)				//�������f 
					{
						if (istrg_spac(text, 37, 32) != 0)
						{
							err_msg = "����� ������";
						}
						else
						{
							UoeCommonFnc.MemCopy(ref err_msg, ref text, 36, 32);
						}
					}
					# endregion
					break;
			}

			if(err_msg != "")
			{
				message = err_msg;
				msg_pssput( P_GUIDE01, message );
				return(status);
			}
			return(status);
		}
		# endregion

		# region ��M�d���ۑ�
		/// <summary>
		/// ��M�d���ۑ�
		/// </summary>
		/// <param name="dataSendCode"></param>
		/// <param name="text"></param>
		private void SaveRecvText(int dataSendCode, ref byte[] src, Int16 len)
		{
            //�������j��΍�
            if (len > RECBUF_MAXSIZE)
            {
                len = RECBUF_MAXSIZE;
            }
            
            UoeRecDtl dtl = new UoeRecDtl();
			dtl.UOESalesOrderRowNo = new List<int>();

			dtl.RecTelegram = new byte[len];

			//��M�d��
			if(len > 0)
			{
				byte[] dst = new byte[len];
				vjisebc_cnv(EBC_JIS_CNV, ref src, ref dst, len);
				dtl.RecTelegram = dst;
                dtl.RecTelegramLen = len;
			}

			//�����ԍ�
			dtl.UOESalesOrderNo = _uoeSndDtl.UOESalesOrderNo;

			//�����s�ԍ�
			dtl.UOESalesOrderRowNo = _uoeSndDtl.UOESalesOrderRowNo;

			//���M�t���O
			dtl.DataSendCode = dataSendCode;

			//�����t���O
			//����
			if (_businessCode == HATSU)
			{
				if (dataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_OK)
				{
					dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	//�����Ȃ�
				}
				else
				{
					dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;	//��������
				}
			}
			//���ρE�݌�
			else
			{
				dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	//�����Ȃ�
			}

			_uoeRecHed.UoeRecDtlList.Add(dtl);
		}
		# endregion

		# region �G���[���F���M�E�����t���O����
		/// <summary>
		/// �G���[���F���M�E�����t���O����
		/// </summary>
		/// <param name="dataSendCode">���M�t���O</param>
		private void SaveRecvText(int dataSendCode)
		{
			byte[] src = new byte[0];
			SaveRecvText(dataSendCode, ref src, 0);
		}
		# endregion

		# region Ұ���� ���ޕϊ�����
		/// <summary>
		/// Ұ���� ���ޕϊ�����
		/// </summary>
		/// <param name="type"></param>
		/// <param name="src"></param>
		/// <param name="dst"></param>
		/// <param name="len"></param>
		private void vjisebc_cnv(Int16 type, ref byte[] src, ref byte[] dst, int len)
		{
			int postStEn = 0;	//�J�Ǔd���敪 0:�ʏ� 1:�J��

			//�J�Ǔd���敪
			if ((_uoeSndDtl.UOESalesOrderNo == 0) && (_uoeSndDtl.UOESalesOrderRowNo.Count == 0))
			{
				postStEn = 1;
			}
			else
			{
				postStEn = 0;
			}

			//���������� --------------------------------------------------------
			UoeCommonFnc.MemSet(ref dst, 0x20, len);
			UoeCommonFnc.MemCopy(ref dst, ref src, len);

			switch (_uOESupplier.CommAssemblyId)
			{
				//���g���^��
				case EnumUoeConst.ctCommAssemblyId_0102:
					# region ���g���^��
					//���M<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i=1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//��M<EBC --> JIS CNV>
					else
					{
						for (int i=1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
					}

					UoeCommonFnc.MemCopy(ref dst, 0, ref src, 0, 5);
					UoeCommonFnc.MemCopy(ref dst, 8, ref src, 8, 1);
					if (_businessCode == HATSU)
					{
						UoeCommonFnc.MemCopy(ref dst, 39, ref src, 39, 4);
					}
					# endregion
					break;

				//�����YN�߰�
				case EnumUoeConst.ctCommAssemblyId_0202:
					# region �����YN�߰�
					//���M<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						// �J�ǁ^�Ǔd��--------------------------------------------------
						if (postStEn == 1)
						{
							// ���M�f�[�^(jis->ebc)�ϊ�------------------------------------
							for (int ix = 0; ix < KAI_SND; ix++)
							{
								dst[ix] = jis_ebc(src[ix]);
							}
							// �o�C�i�����ږ߂�--------------------------------------------
							UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);	//[21]:�ʐMymdhms
						}
						else
						{
							// ���M�f�[�^(jis->ebc)�ϊ�------------------------------------
							// TTC+�Ɩ�H���̂�EBCDIC   
							for (int ix = 0; ix < 48; ix++)
							{
								dst[ix] = jis_ebc(src[ix]);
							}
						}

						// �o�C�i�����ږ߂��i���ʁj----------------------------------------
						UoeCommonFnc.MemCopy(ref dst, ref src, 7);	// [0]:���敪    
						// [1]:÷�ļ��ݽ   
						// [3]:÷�Ē�      
						// [5]:�d���敪    
						// [6]:��������    

					}
					//��M<EBC --> JIS CNV>
					else
					{
						// �J�ǁ^�Ǔd��--------------------------------------------------
						if (postStEn == 1)
						{
							// ��M�f�[�^(ebc->jis)�ϊ�------------------------------------
							for (int ix = 0; ix < KAI_SND; ix++)
							{
								dst[ix] = ebc_jis(src[ix]);
							}

							//�o�C�i�����ږ߂��i[21]:�ʐMymdhms�j 
							UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);
						}
						// ��M�f�[�^(ebc->jis)�ϊ�----------------------------------------
						else
						{
							for (int ix = 0; ix < 48; ix++)
							{
								dst[ix] = ebc_jis(src[ix]);
							}

                            int cpLen = len - 48;
                            UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, cpLen);
                        }

						// �o�C�i�����ږ߂��i���ʁj----------------------------------------
						UoeCommonFnc.MemCopy(ref dst, ref src, 7);	// [0]:���敪    
						// [1]:÷�ļ��ݽ   
						// [3]:÷�Ē�      
						// [5]:�d���敪    
						// [6]:��������    
					}
					# endregion
					break;
				//���O�H��
				case EnumUoeConst.ctCommAssemblyId_0301:
					# region ���O�H��
					//���M<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//��M<EBC --> JIS CNV>
					else
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
					}

                    //����
					UoeCommonFnc.MemCopy(ref dst, 0, ref src, 0, 7);

                    // �J�ǖ��͕�			   
                    if (postStEn == 1)
					{
						UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);
					}
                    //�ʏ�d��
					else
					{
                        int cpLen = len -48;
                        UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, cpLen);
					}
					# endregion
					break;
				//���}�c�_��
				case EnumUoeConst.ctCommAssemblyId_0401:
				case EnumUoeConst.ctCommAssemblyId_0402:
					# region ���}�c�_��
					//���M<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//��M<EBC --> JIS CNV>
					else
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
					}

					UoeCommonFnc.MemCopy(ref dst, 0, ref src, 0, 7);
					if (postStEn == 1)
					{							// �J�ǖ��͕ǁH			   
						UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);
					}
					else
					{
						UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, 1);
						UoeCommonFnc.MemCopy(ref dst, 53, ref src, 53, 4);
					}
					# endregion
					break;
				//���z���_��
				case EnumUoeConst.ctCommAssemblyId_0501:
					# region ���z���_��
					//���M<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
						UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, 9);
					}
					//��M<EBC --> JIS CNV>
					else
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
						UoeCommonFnc.MemCopy(ref dst, 37, ref src, 37, 9);
					}
					# endregion
					break;
				//���D�ǁi���̑��j��
				default:
					# region ���D�ǁi���̑��j��
					//���M<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//��M<EBC --> JIS CNV>
					else
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
					}

					# endregion
					break;
			}
		}
		# endregion

		# region ���b�Z�[�W�N���A
        /// <summary>
        /// ���b�Z�[�W�N���A
        /// </summary>
        /// <param name="fld">�N���A�t�B�[���h</param>
        private void msg_psfclr(int fld)
		{
            this._msg_psfclr(fld);
        }
		# endregion

		# region ���b�Z�[�W�\��
        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="fld">�\���t�B�[���h</param>
        /// <param name="text">�\���e�L�X�g</param>
        private void msg_pssput(int fld, string text)
		{
            this._msg_pssput(fld, text);
		}
		# endregion

		# region �ʐM���O��������
		/// <summary>
		/// �ʐM���O��������
		/// </summary>
		/// <param name="logDataObjProcNm"></param>
		/// <param name="logDataOperationCd"></param>
		/// <param name="logDataMassage"></param>
        /// <param name="len"></param>
        private void log_update(string logDataObjProcNm, Int32 logDataOperationCd, byte[] logDataMassage, int len)
		{
            _uoeOprtnHisLogAcs.log_update(this, logDataObjProcNm, logDataOperationCd, logDataMassage, len, _uoeSndHed.UOESupplierCd, (int)EnumUoeConst.ctOprtnHisLogFlush.ct_OFF);
		}
		# endregion

		# region �������|���������������ϊ�
		/// <summary>
		/// �������|���������������ϊ�
		/// </summary>
		/// <param name="jiscd"></param>
		/// <returns></returns>
		private byte jis_ebc(byte jiscd)
		{

			byte[] jis_ebctb = new byte[256] {0x00, 0x01, 0x02, 0x03, 0x37, 0x2d, 0x2e, 0x2f,
						0x16, 0x05, 0x15, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f,
						0x10, 0x11, 0x12, 0x13, 0x3c, 0x3d, 0x32, 0x26,
						0x18, 0x19, 0x3f, 0x27, 0x22, 0x1d, 0x1e, 0x1f,
						0x40, 0x4f, 0x7f, 0x7b, 0xe0, 0x6c, 0x50, 0x7d,
						0x4d, 0x5d, 0x5c, 0x4e, 0x6b, 0x60, 0x4b, 0x61,
						0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7,
						0xf8, 0xf9, 0x7a, 0x5e, 0x4c, 0x7e, 0x6e, 0x6f,
						0x7c, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7,
						0xc8, 0xc9, 0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6,
						0xd7, 0xd8, 0xd9, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6,
						0xe7, 0xe8, 0xe9, 0x4a, 0x5b, 0x5a, 0x5f, 0x6d,
						0x79, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7,
						0xc8, 0xc9, 0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6,
						0xd7, 0xd8, 0xd9, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6,
						0xe7, 0xe8, 0xe9, 0xc0, 0x6a, 0xd0, 0xa1, 0x07,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
						0x48, 0x49, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56,
						0x58, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87,
						0x88, 0x89, 0x8a, 0x8c, 0x8d, 0x8e, 0x8f, 0x90,
						0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98,
						0x99, 0x9a, 0x9d, 0x9e, 0x9f, 0xa2, 0xa3, 0xa4,
						0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xac, 0xad,
						0xae, 0xaf, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
						0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

			return((byte)jis_ebctb[(int)jiscd]);
		}
		# endregion

		# region �������������|���������ϊ�
		/// <summary>
		/// �������������|���������ϊ�
		/// </summary>
		/// <param name="ebccd"></param>
		/// <returns></returns>
		private byte ebc_jis(byte ebccd)
		{
				byte[] ebc_jistb = new byte[256] {	//P961114
							0x00, 0x01, 0x02, 0x03, 0x00, 0x09, 0x00, 0x7f,
							0x00, 0x00, 0x00, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f,
							0x10, 0x11, 0x12, 0x13, 0x00, 0x0a, 0x08, 0x00,
							0x18, 0x19, 0x00, 0x00, 0x00, 0x1d, 0x1e, 0x1f,
							0x00, 0x00, 0x1c, 0x00, 0x00, 0x0a, 0x17, 0x1b,
							0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x06, 0x07,
							0x00, 0x00, 0x16, 0x00, 0x00, 0x00, 0x00, 0x04,
							0x00, 0x00, 0x00, 0x00, 0x14, 0x15, 0x00, 0x1a,
							0x20, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7,
							0xa8, 0xa9, 0x5b, 0x2e, 0x3c, 0x28, 0x2b, 0x21,
							0x26, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf, 0x00,
							0xb0, 0x00, 0x5d, 0x5c, 0x2a, 0x29, 0x3b, 0x5e,
							0x2d, 0x2f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
							0x00, 0x00, 0x7c, 0x2c, 0x25, 0x5f, 0x3e, 0x3f,
							0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
							0x00, 0x60, 0x3a, 0x23, 0x40, 0x27, 0x3d, 0x22,
                			//ebc(80)->
                            0x00, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7,
							0xb8, 0xb9, 0xba, 0x00, 0xbb, 0xbc, 0xbd, 0xbe,
							0xbf, 0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6,
							0xc7, 0xc8, 0xc9, 0x00, 0x00, 0xca, 0xcb, 0xcc,
							0x00, 0x7e, 0xcd, 0xce, 0xcf, 0xd0, 0xd1, 0xd2,
							0xd3, 0xd4, 0xd5, 0x00, 0xd6, 0xd7, 0xd8, 0xd9,
							0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			                //<-ebc(bf) 	
                            0x00, 0x00, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf,
							0x7b, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
							0x48, 0x49, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
							0x7d, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 0x50,
							0x51, 0x52, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
							0x24, 0x00, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58,
							0x59, 0x5a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
							0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37,
							0x38, 0x39, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

			return ((byte)ebc_jistb[(int)ebccd]);
		}
		# endregion

		# region �w�蕶��������X�y�[�X���ǂ������肷��
		/// <summary>
		/// �w�蕶��������X�y�[�X���ǂ������肷��
		/// </summary>
		/// <param name="str"></param>
		/// <param name="start"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		private Int16 istrg_spac(byte[] str, int start, int len)
		{
			for (int ix = start; ix < start + len; ix++)
			{
				if (str[ix] == 0x20) continue;
				if (str[ix] == 0x00) continue;
				if (str[ix] == 0x81 &&
					 str[ix + 1] == 0x40) { ix++; continue; }
				return (0);
			}
			return (1);
		}

		# endregion

        // ---ADD 2010/05/07 ------------------>>>>>
        /// <summary>
        /// �D�ǃ��[�J�[(Web)�ł��邩���f���܂��B
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>
        /// �ʐM�A�Z���u��ID��
        /// <c>EnumUoeConst.ctCommAssemblyId_1004</c>:�����Y��
        /// �̏ꍇ�A<c>true</c>��Ԃ��܂��B
        /// �ʐM�A�Z���u��ID��
        /// <c>EnumUoeConst.ctCommAssemblyId_1003</c>:��NET
        /// �̏ꍇ�A<c>true</c>��Ԃ��܂��B
        /// </returns>
        public static bool IsOtherMakerUOEWeb(string commAssemblyId)
        {
            switch (commAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_1004:   //�D�ǃ��[�J�[(�����Y��)
                    return true;
                case EnumUoeConst.ctCommAssemblyId_1003:   //�D�ǃ��[�J�[(��NET)
                    return true;
                default:
                    return false;
            }
        }

        // ---ADD 2010/05/07 ------------------<<<<<

		# endregion
	}
}
