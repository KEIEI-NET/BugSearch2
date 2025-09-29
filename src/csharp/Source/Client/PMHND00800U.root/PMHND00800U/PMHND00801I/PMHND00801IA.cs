//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : HT�v���O������������
// �v���O�����T�v   : HT�v���O�������������C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370104-00 �쐬�S�� : �X�R�@�_
// �� �� ��  2017/12/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#region BTCommLibEx

namespace Broadleaf.Windows.Forms
{
using BTCOMM_HHT = System.Int32;

    //HT���\����
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_HTInfo
    {
        public Int16 wID;               // HT ID	(�w�肵�Ȃ��ꍇ��BTCOMM_ID_NO_CARE������)
        public Int16 wCradleType;       // �ʐM���j�b�g�̎��
        public Int16 wPortNo;           // �|�[�g�ԍ� // �V���A���|�[�g�ԍ�
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] strip;            // IP�A�h���X
    }

    //HT���\����2
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_HTInfo2
    {
        public BTCOMM_HTInfo info;             // HT���\����
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] sSerial;                 // �V���A��No
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sFirmVersionl;           // �t�@�[���E�F�A�̃o�[�W����
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sAppVirsion;            // APP �t�@�C���̃o�[�W����
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sSbVersion;             // �X�N���v�g�o�C�i��(sb3)�t�@�C���̃o�[�W����
    }


    // ����M���\����
    // btcommCreateHTHandle()�Őݒ肷��\���̂ł��B
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_Param
    {
        public IntPtr hWnd;				// �C�x���g�z�M��
        public Int32  dwMsgID;			// �C�x���gID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strSendPath;		// �t�@�C�����M���ibtcommPutFile�j�̃J�����g�t�H���_
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strRecvPath;		// �t�@�C����M���ibtcommGetFile�j�̃J�����g�t�H���_
        public bool bDispDialog;		// �ʐM���̃_�C�A���O��\������/���Ȃ�
        public bool bSetTime;			// �[���̎�����PC�ɍ��킹��/���킹�Ȃ�
    }

    // �t�@�C�����\����
    // btcommFindFileNext()�̌��ʂ��擾����\���̂ł��B
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_FileInfo
    {
        public Int32 dwAttribute;				// ����
        public ulong ullFileSize;				// �t�@�C���T�C�Y
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public char[] strFileName;		        // �t�@�C����
        public Int32 wYear;					    // �X�V���t�i�N�j
        public byte byMonth;					// �X�V���t�i���j
        public byte byDay;						// �X�V���t�i���j
        public byte byHour;					    // �X�V���t�i���j
        public byte byMin;						// �X�V���t�i���j
        public byte bySec;						// �X�V���t�i�b�j
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] reserved;	   			    // �\��
    }

    // ����M�f�[�^�\����
    // btcommFindFileNext()�̌��ʂ��擾����\���̂ł��B
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_TransProgress
    {
        public Int32 dwStatus;                 // ����M��ʁiBTCOMM_TP_SEND/BTCOMM_TP_RECV/...)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] strFileName;             // �t�@�C����
        public ulong ullFileLen;               // �t�@�C����
        public ulong ullTransLen;              // ����M�ς̃f�[�^��
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_TransProgress2
    {
        public Int32 dwStatus;                 // ����M��ʁiBTCOMM_TP_SEND/BTCOMM_TP_RECV/...)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strFileName;             // �t�@�C����
        public Int32 dwFileLen;                // �t�@�C����
        public Int32 dwTransLen;               // ����M�ς̃f�[�^��
    } ;

    // ����M�f�[�^�\����
    // btcommInitializeHT()�Őݒ肷��\���̂ł��B
    public struct BTCOMM_InitInfo
    {
        public Int16 wTermID;                  // �[��ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] reserved;                // �t�@�C����
    } ;

    // �[���A�v���X�V���\����
    public struct BTCOMM_APP_INFO
    {
        public char major_version;             // ���W���[�o�[�W����
        public char minor_version;             // �}�C�i�[�o�[�W����
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] comment;                 // �A�v���P�[�V�����Ɋւ���R�����g�i�^�C�g���j
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] filepath;                // �A�v���P�[�V�����Ɋւ���R�����g�i�^�C�g���j

    } ;

    // �V�X�e���A�b�v�f�[�g�t�@�C�����\����
    public struct BTCOMM_SYSUPFILE_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] filepath;                // �V�X�e���A�b�v�f�[�g�t�@�C����(in)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] version;                 // �A�v���P�[�V��������������t�H���_�i��M�t�H���_����̑��΃p�X�j�B
							            // �擾���ɂ̓A�v���P�[�V�����̃t�@�C�����B

    } ;

    // �t�@�C�����k���\����
    public struct BTCOMM_COMPRESS_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strSrcFileName;          // ���k�Ώۃt�@�C����(in))
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] strDstFileName;          // ���k�t�@�C����(in)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] strCmpFileName;          // �𓀂����t�@�C����(in)(�t�@�C�����̂�)
        public Int16 wOverWrite;               // �㏑������/�֎~(in)(1/0)
        public Int16 wFolderType;              // �t�H���_���(in)(1:��M�t�H���_/2:���M�t�H���_)
        public Int32 dwBeforeFileSize;         // ���k�O�̃t�@�C���T�C�Y(out)
        public Int32 dwAfterFileSize;          // ���k��̃t�@�C���T�C�Y(out)

    } ;

    // �t�@�C���𓀏��\����
    public struct BTCOMM_UNCOMPRESS_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strSrcFileName;          // ���k�t�@�C����(in)
        public Int16 wOverWrite;               // �㏑������/�֎~(in)(1/0)
        public Int16 wFolderType;              // �t�H���_���(in)(1:��M�t�H���_/2:���M�t�H���_)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strDstFileName;          // �𓀃t�@�C����(in)

    } ;
    

    // �ʐM���j�b�g���(BTCOMM_HTInfo�\���̂�wCradleType�Ɏw�肵�܂�
    public enum BTCOMM_CRADLETYPE : int
    {
        BTCOMM_CRADLE_TYPE_COM          = 1,    // COM�ʐM���j�b�g
	    BTCOMM_CRADLE_TYPE_USB,			        // USB�ʐM���j�b�g
	    BTCOMM_CRADLE_TYPE_LAN,			        // LAN�ʐM���j�b�g
	    BTCOMM_CRADLE_TYPE_MODEM        = 6,	// ���f��(9600�ʐM)
	    BTCOMM_CRADLE_TYPE_RF           = 10,	// �����ʐM
	    BTCOMM_CRADLE_TYPE_SOCK_PASSIVE = 11,	// �����ʐM(�T�[�o)
	    BTCOMM_CRADLE_TYPE_MODEM_115K = 12,	    // ���f��(115K�ʐM)

    } ;

    // �߂�l��ʒ�`
    public enum BTCOMM_RESULT : int
    {
	    BTCOMM_INVALID_VALUE	= -320,	// �����g�p
	    BTCOMM_NOTINITIALISED,			// (-319)����������Ă��܂���B�s���ȃn���h���ł��B
	    BTCOMM_INUSE,					// (-318)�|�[�g���g�p���ł��B
	    BTCOMM_NOTCONNECT,				// (-317)Connect�܂���Listen�����Ă��Ȃ���ԂŊ֐����Ă΂�܂����B
	    BTCOMM_WOULDBLOCK,				// (-316)�񓯊��֐����Ă΂�܂����B�����̌��ʂ̓C�x���g�ŕԂ�܂��B
	    BTCOMM_NOTFOUND,				// (-315)�w�肵���[����������܂���ł����B
	    BTCOMM_REFUSED,					// (-314)�[������ڑ������ۂ���܂����B
	    BTCOMM_CANCELED,				// (-313)�L�����Z������܂����B
	    BTCOMM_TIMEOUT,					// (-312)����Ƃ̐ڑ����^�C���A�E�g���ԓ��ɂł��܂���ł����B
	    BTCOMM_NETDOWN,					// (-311)�i�ڑ����́j�ʐM�o�H���_�E�����܂����B
	    BTCOMM_BIGDATA,					// (-310)����̋󂫗e�ʈȏ�̃t�@�C���𑗐M���悤�Ƃ��܂����B
	    BTCOMM_FILENOTFOUND,			// (-309)����M�Ŏw�肵���t�@�C����������܂���B
	    BTCOMM_INCOMPLETE,				// (-308)�������������܂���ł����B
	    BTCOMM_CONVERT_FAILED,			// (-307)�ϊ��������s
	    BTCOMM_OTHER,					// (-306)���̑��̃G���[���������܂����B
	    BTCOMM_CALLBACK,				// (-305)�R�[���o�b�N�֐��Ŗ߂�l���G���[��Ԃ��܂����B
	    BTCOMM_OK				= 0,	// �������������܂����B
    
    }

    // �C�x���g��` wParam�ɑ������܂�
    public enum BTCOMM_EVENTDEF : int
    {
	    EV_SEARCH_FIN,					// (0)�[�������I�����ɑ��M�����C�x���g

	    EV_LISTENING_START,				// (1)Listen�J�n�O�ɑ��M�����C�x���g
	    EV_LISTENING_ACCEPTED,			// (2)Listen��A�[���Ɛڑ��ł����Ƃ��ɑ��M�����C�x���g
	    EV_LISTENING_FIN,				// (3)Listen�I����ɑ��M�����C�x���g

	    EV_CONNECT_FIN,					// (4)Connect��A�[���Ɛڑ��ł����Ƃ��ɑ��M�����C�x���g
	    EV_DISCONNECT_FIN,				// (5)Disconnect��A�[���Ƃ̐ڑ���ؒf�ł����Ƃ��ɑ��M�����C�x���g

	    EV_FILE_TRANSPORTING,			// (6)�t�@�C������M���ɑ��M�����C�x���g
	    EV_PROCEDURE_COMPLETE,			// (7)�����������ɑ��M�����C�x���g
	    EV_FIND_FIN,					// (8)�t�@�C�������������ɑ��M�����C�x���g
	    EV_INVALID_VALUE,				// (9)���ۂɂ͎g�p���Ȃ��l
	    EV_FILE_TRANSPORTING2,			// (10)�t�@�C������M���ɑ��M�����C�x���g�i�����O�t�@�C�����Ή��j
    } ;

    // �߂�l��ʒ�` BTCOMM_TransProgress::dwStatus�Ɏw�肵�܂��B
    public enum BTCOMM_RETVALDEF : int
    {
	    BTCOMM_TP_SEND = 0,				// (0)���M��
	    BTCOMM_TP_RECV,					// (1)��M��
	    BTCOMM_TP_SAVE,					// (2)�f�[�^�ۑ���
	    BTCOMM_TP_COMP,					// (3)�f�[�^�ۑ�����
	    BTCOMM_TP_INCP,					// (4)�f�[�^�ۑ����s
	    BTCOMM_TP_MELT,					// (5)���O�t�@�C����
	    BTCOMM_TP_LOGCOMP,				// (6)���O�t�@�C���ۑ�����
	    BTCOMM_TP_NUM					//    ��`��
    } ;

    /// <summary>
    /// HT�v���O������������ RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : HT�v���O������������ RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �X�R�@�_</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class btcommclass
    {

        // �������� btcommSearchHT()��dwSearchInfo�Ɏw�肵�܂�
        public static uint BTCOMM_CRADLE_COM1 = 2;
        public static uint BTCOMM_CRADLE_COM2 = 4;
        public static uint BTCOMM_CRADLE_COM3 = 8;
        public static uint BTCOMM_CRADLE_COM4 = 16;
        public static uint BTCOMM_CRADLE_COM5 = 32;
        public static uint BTCOMM_CRADLE_COM6 = 64;
        public static uint BTCOMM_CRADLE_COM7 = 128;
        public static uint BTCOMM_CRADLE_COM8 = 256;
        public static uint BTCOMM_CRADLE_COM9 = 512;
        // �������� btcommSearchHT(),btcommSearchCradle()��dwSearchInfo�Ɏw�肵�܂�
        public static uint BTCOMM_CRADLE_COMALL = 1024;
        public static uint BTCOMM_CRADLE_USBALL = 2048;
        public static uint BTCOMM_CRADLE_LANALL = 4096;
        public static uint BTCOMM_TERM_WLANALL = 8192;

        // ���O�f�[�^�J�X�^�}�C�Y����
        public static uint DEL_DATE           = 1;           // ���t�f�[�^�폜
        public static uint DEL_HOURMINUTE     = 2;           // ���t�f�[�^�폜
        public static uint DEL_DADEL_SECONDTE = 4;           // ���t�f�[�^�폜
        public static uint DEL_ID             = 8;           // ���t�f�[�^�폜
        public static uint DEL_SEPARATOR      = 0x80000000;  // ���t�f�[�^�폜

        // �A�v���X�V���
        public static int BTCOMM_APLIUPDATE_SAME = 1;   // ���t�f�[�^�폜
        public static int BTCOMM_APLIUPDATE_NONE = 2;   // ���t�f�[�^�폜
        public static int BTCOMM_APLIUPDATE_NORM = 3;   // ���t�f�[�^�폜

        // ���b�Z�[�W���MID
        public static int ID_MSG_CALLBACK = 1;  // �����t�@�C������M�����R�[���o�b�N�Ăяo��



        //
        // �ʐM���j�b�g�̌���
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommSearchCradle(
                            Int32 dwSearchInfo,		// [in]	 ��������
                            Int32* nResult			// [out] �������ʐ�
                            );

        //
        // �ʐM���j�b�g�������ʂ���HT���̎擾(�[��ID��BTCOMM_ID_NO_CARE�Œ�)
        //
        [DllImport("BTCommLibEx.dll")]
        public�@unsafe extern static bool btcommGetCradleNext(
                            ref BTCOMM_HTInfo info		// [out] �[�����
                            );

        //
        // HT�̌���
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommSearchHT(
                            IntPtr hWnd,			// [in]	 �C�x���g�z�M��BNULL�̏ꍇ�u���b�N�֐��ɂȂ�
                            Int32 Msg,				// [in]	 ���M���b�Z�[�WID
                            uint dwSearchInfo,		// [in]	 ��������
                            Int32* nResult		    // [out] �������ʐ�
                            );

        //
        // HT�̌���2
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommSearchHT2(
                            IntPtr hWnd,			// [in]	 �C�x���g�z�M��BNULL�̏ꍇ�u���b�N�֐��ɂȂ�
                            Int32 Msg,				// [in]	 ���M���b�Z�[�WID
                            uint dwSearchInfo,		// [in]	 ��������
                            Int32* nResult		    // [out] �������ʐ�
                            );

        //
        // HT�̌������ʂ���HT���̎擾
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static bool btcommGetHTNext(
                            out BTCOMM_HTInfo info		// [out] �[�����
                            );

        //
        // HT�̌������ʂ���HT���̎擾
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static bool btcommGetHTNext2(
                            out BTCOMM_HTInfo2 info		// [out] �[�����
                            );

        //
        // HT�n���h���̐���
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_HHT btcommCreateHTHandle(
                              ref BTCOMM_HTInfo info,	    // [in]	 �[�����
                              ref BTCOMM_Param param		// [in]	 ����M���
                              );

        //
        // HT�n���h���̉��
        //
        [DllImport("BTCommLibEx.dll")]
        public  extern static bool btcommCloseHTHandle(
                              BTCOMM_HHT hHT			// [in]	 HT�n���h��
                              );

        //
        // HT�n���h������HT���̎擾
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommGetHTInfo(
                            BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                            ref BTCOMM_HTInfo info,	// [out] �[�����
                            ref BTCOMM_Param param		// [out] ����M���
                            );

        //
        // �[������̐ڑ��҂�
        //
        [DllImport("BTCommLibEx.dll")]
        public  extern static BTCOMM_RESULT btcommListen(
                            BTCOMM_HHT hHT			// [in]	 HT�n���h��
                            );

        //
        // �[������̐ڑ��҂��I��
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommStopListening(
                                BTCOMM_HHT hHT			// [in]	 HT�n���h��
                                );

        //
        // �[���ւ̐ڑ��J�n
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommConnect(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                Int32 dwTimeOut			// [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[���Ƃ̐ڑ������iConnect�̉����BListen�̉����ł͂Ȃ��j
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommDisconnect(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                Int32 dwTimeOut			// [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[��(Server)�̐ڑ��҂��������I��������
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommStopRemoteServer(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                BTCOMM_RESULT retCode,	// [in]	 �I���R�[�h
                                Int32 dwTimeOut			// [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[���ւ̐ڑ��m�F�iConnect��(1)�܂���Listen��(2)�܂��͖��ڑ�(0)���m�F����j
        //
        [DllImport("BTCommLibEx.dll")]
        private extern static int btcommIsConnect(
                                BTCOMM_HHT hHT			// [in]	 HT�n���h��
                                );

        //
        // �[���ւ̃t�@�C�����M�i�A�b�v���[�h�j
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommPutFile(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrLocalFile,	// [in]	 ���[�J���t�@�C����
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrRemoteFile,	// [in]	 �����[�g�t�@�C����
                                Int32 dwTimeOut		    // [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[������̃t�@�C����M�i�_�E�����[�h�j
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommGetFile(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrRemoteFile,	// [in]	 �����[�g�t�@�C����
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrLocalFile,	// [in]	 ���[�J���t�@�C����
                                Int32 dwTimeOut			// [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[���Ƃ̒ʐM�L�����Z��
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommCancel(
                                BTCOMM_HHT hHT			// [in]	 HT�n���h��
                                );

        //
        // �[�����̃t�@�C������
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommFindFile(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrPath,	    // [in]	 �����p�X
                                Int32* nResult,			// [out] �������ʐ�
                                Int32 dwTimeOut			// [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[�����̃t�@�C������
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommFindFileNext(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                ref BTCOMM_FileInfo info	// [out] �t�@�C���\����
                                );

        //
        // �[�����̃t�@�C�����ύX
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommRenameFile(
                                BTCOMM_HHT hHT,			// [in]	 HT�n���h��
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrExistFile,	// [in]	 ���݂̃t�@�C����
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrNewFile,	    // [in]	 �V�����t�@�C����
                                Int32 dwTimeOut			// [in]	 �^�C���A�E�g���ԁi�b�j
                                );

        //
        // �[�����̃t�@�C���폜
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommRemoveFile(
                                BTCOMM_HHT hHT,				// [in]	 HT�n���h��
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrFileName,	// [in]	 �폜����t�@�C����
                                Int32 dwTimeOut				// [in]	 �^�C���A�E�g���ԁi�b�j
                                );
    }

}

#endregion

