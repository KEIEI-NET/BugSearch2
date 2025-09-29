/************************************************************************/
/*	system			: �p�[�c�}�� �Z�V�X�e��								*/
/*	file name		: TRANS_B ���ʊ֐�									*/
/*			 		: PMONLWIN.C										*/
/*----------------------------------------------------------------------*/
/* 20081121 ���ԗT�� PM.NS�ɑΉ�                                        */
/* 20091112 �H���b�D MANTIS�Ή�[14471]									*/
/*----------------------------------------------------------------------*/
/*				Copyright 2000 TSUBASA System Co., Ltd.					*/
/************************************************************************/

/*======================================================================*/
/* �h�m�b�k�t�c�d�錾													*/
/*======================================================================*/
#include	<windows.h>
#include	<stdio.h>
#include	<math.h>
#include	<stdlib.h>
#include	<memory.h>
#include	<string.h>
#include	"trans_b.h"
#include	"pmonline.h"

/*======================================================================*/
/* �c�d�e�h�m�d��`														*/
/*======================================================================*/
#define		TBS_TEXT_MAX		2038	/*����M�\�ȃe�L�X�g�̍ő咷*/

#define		DIS_ANSERTONE		0		/*�A���T�[�g�[���Ȃ�*/
#define		ENA_ANSERTONE		1		/*�A���T�[�g�[������*/

#define		TM_INIT_MODE		0		/*���M����M�����l*/
#define		TM_CONN_MODE		1		/*�������M*/
#define		TM_DIAL_MODE		2		/*�������M*/

#define		TB_MES_FIRST		0		/* ���b�Z�[�W�ݒ� */
#define		TB_MES_NEXT			1		/* ���b�Z�[�W�擾 */

#define		CN_CONE_ENA			0		/* ����ڑ���� */
#define		CN_CONE_DIS			1		/* ����ؒf��� */

#define		CONNECT_AUTO		0		/* �������M */
#define		CONNECT_MANUAL		1		/* �蓮���M */

#define		ENA_KEY_STOP		0		/*�uESC+CTRL+A�v���� */
#define		DIS_KEY_STOP		1		/*�uESC+CTRL+A�v�֎~ */

#define		ENA_KEY_CANC		2		/*�uESC+CTRL+A�v���� */

#define		LPOS_NG				-1		/* �s�a�G���[ */
#define		LPOS_ESC			-2		/* ���f */
#define		LPOS_ERR			-3		/* �R�}���h���s */

/*�G���[�ڍ׃R�[�h------------------------------------------------------*/
#define		ER_SETUP			0x01	/*Setup����ޖ�����*/
#define		ER_CONNECT			0x02	/*Connect������*/
#define		ER_DISCONNECT		0x03	/*����ؒf�i���ѥ�װ�j*/
#define		ER_TIME_TXT			0x04	/*��ѱ�āi�������M���÷�đ҂��j*/
#define		ER_TIME_ACK			0x05	/*��ѱ�āi�Ăяo������ѱ�Ė���÷�đ��M��̉����҂��j*/
#define		ER_DATA_CRC			0x06	/*�ް�������iCRC�װ��đ��װ�j*/
#define		ER_CHANGE			0x07	/*���ݐ��װ*/
#define		ER_CHG_ID			0x08	/*ID�����װ*/
#define		ER_CD_ON			0x09	/*CD ON���o�i���M�v�����j*/
#define		ER_TIME_CTS			0x0a	/*CTS�Ď���ѱ��*/
#define		ER_EOT_TXT			0x10	/*EOT��M�i�e�L�X�g��M�҂��̏ꍇ�j*/
#define		ER_EOT_RES			0x11	/*EOT��M�i�e�L�X�g���M�ɑ΂��鉞���҂��̏ꍇ�j*/
#define		ER_EOT_ENQ			0x12	/*EOT��M�i�ďo��ENQ�ɑ΂��鉞���҂��̏ꍇ�j*/
#define		ER_DLE_EOT			0x13	/*����ؒfү���ށiDISC��M�j*/
#define		ER_RVI				0x14	/*RVI��M�i�e�L�X�g���M�ɑ΂��鉞���҂��̏ꍇ�j*/
#define		ER_CONTENTION		0x15	/*�Ăяo���ɂ����āA���ݼ�ݔ���*/
#define		ER_NO_MESS			0x20	/*�e�L�X�g��M�ɑ΂��関����ү���ނȂ�*/
#define		ER_SND_FULL			0x21	/*���M÷�Ă��ޯ̧���*/
#define		ER_DIAL				0x91	/*�����_�C�������s*/
#define		ER_COMMAND			0x92	/*�R�}���h�G���[*/
#define		ER_MODEM_BUSY		0x95	/*�b��*/
#define		ER_MODEM_NO_TONE	0x96	/*������*/

/*��ԃR�[�h------------------------------------------------------------*/
#define		ST_SETUP			0x00	/*������ԁASetup����ޑ҂�*/
#define		ST_CONNECT			0x01	/*Setup����ފ������Connect����ޑ҂�*/
#define		ST_CONNECT_END		0x02	/*Connect����ފ���*/
#define		ST_DISCONNECT		0x03	/*����ؒfү���ޑ��o�Disconnect line����ޑ҂�*/
#define		ST_RESET			0x04	/*����ؒf�Reset����ޑ҂�*/
#define		ST_SND_NO_DATA		0x10	/*���M���i�����M�ް��Ȃ��j*/
#define		ST_SND_DATA			0x11	/*���M���i�����M�ް�����j*/
#define		ST_SND_DISABLE		0x12	/*���M���i����װ�����j*/
#define		ST_REC_NO_DATA		0x20	/*��M���i��M�ް��Ȃ��j*/
#define		ST_REC_DATA			0x21	/*��M���i��M�ް�����j*/
#define		ST_REC_FULL			0x22	/*��M���i��M�ޯ̧��٤WACK���o���j*/
#define		ST_REC_DISABLE		0x23	/*��M���i����װ�����j*/

// Windows95�pDLL�̃G�N�X�|�[�g��
#define EXPNAME_95_TBOpen				"TBOpen"
#define EXPNAME_95_TBConfigureDeviceDlg "TBConfigureDeviceDlg"
#define EXPNAME_95_TBConfigureParamDlg	"TBConfigureParamDlg"
#define EXPNAME_95_TBConnectEx			"TBConnectEx"
#define EXPNAME_95_TBIsExistFirmware	"TBIsExistFirmware"
#define EXPNAME_95_TBReceiveData		"TBReceiveData"
#define EXPNAME_95_TBReset				"TBReset"
#define EXPNAME_95_TBSendEOT			"TBSendEOT"
#define EXPNAME_95_TBSendDLEEOT			"TBSendDLEEOT"
#define EXPNAME_95_TBSetupEx			"TBSetupEx"
#define EXPNAME_95_TBSendData			"TBSendData"
#define EXPNAME_95_TBDisconnectLine		"TBDisconnectLine"
#define EXPNAME_95_TBClose				"TBClose"
#define EXPNAME_95_TBConvertData		"TBConvertData"
#define EXPNAME_95_TBConnectCancel		"TBConnectCancel"

// WindowsNT�pDLL�̃G�N�X�|�[�g��
#define EXPNAME_NT_TBOpen				"_TBOpen@8"
#define EXPNAME_NT_TBConfigureDeviceDlg "_TBConfigureDeviceDlg@8"
#define EXPNAME_NT_TBConfigureParamDlg	"_TBConfigureParamDlg@8"
#define EXPNAME_NT_TBConnectEx			"_TBConnectEx@8"
#define EXPNAME_NT_TBIsExistFirmware	"_TBIsExistFirmware@4"
#define EXPNAME_NT_TBReceiveData		"_TBReceiveData@8"
#define EXPNAME_NT_TBReset				"_TBReset@4"
#define EXPNAME_NT_TBSendEOT			"_TBSendEOT@4"
#define EXPNAME_NT_TBSendDLEEOT			"_TBSendDLEEOT@4"
#define EXPNAME_NT_TBSetupEx			"_TBSetupEx@8"
#define EXPNAME_NT_TBSendData			"_TBSendData@20"
#define EXPNAME_NT_TBDisconnectLine		"_TBDisconnectLine@4"
#define EXPNAME_NT_TBClose				"_TBClose@4"
#define EXPNAME_NT_TBConvertData		"_TBConvertData@16"
#define EXPNAME_NT_TBConnectCancel		"_TBConnectCancel@4"

#define IMPORT_FUNCTION( hModule, FuncName, fWinNT ) \
	( x##FuncName = (LPFN_##FuncName)GetProcAddress( \
		hModule, ( fWinNT ? EXPNAME_NT_##FuncName : EXPNAME_95_##FuncName ) ) )

// Windows�̃o�[�W�����̔���
#define TBIsWindowsNT() \
	( ( BOOL )( GetVersion( ) < 0x80000000 ) )

// �eAPI�̃v���g�^�C�v
typedef int  ( WINAPI *LPFN_TBConfigureDeviceDlg )( HWND hWnd, LPCSTR lpszDeviceName );
typedef int  ( WINAPI *LPFN_TBConfigureParamDlg )( HWND hWnd, LPCSTR lpszDeviceName );
typedef int  ( WINAPI *LPFN_TBOpen )( HWND hWnd, LPCSTR lpszDevControl );
typedef WORD ( WINAPI *LPFN_TBIsExistFirmware )( int nDevId );
typedef WORD ( WINAPI *LPFN_TBSetupEx )( int nDevId, LPTBSETUP lpTBSETUP );
typedef WORD ( WINAPI *LPFN_TBConnectEx )( int nDevId, LPTBCONNECT lpTBCONNECT );
typedef WORD ( WINAPI *LPFN_TBSendEOT )( int nDevId );
typedef WORD ( WINAPI *LPFN_TBSendDLEEOT )( int nDevId );
typedef WORD ( WINAPI *LPFN_TBDisconnectLine )( int nDevId );
typedef WORD ( WINAPI *LPFN_TBReset )( int nDevId );
typedef WORD ( WINAPI *LPFN_TBSendData )( int nDevId, UINT nType, UINT nConvert, UINT nLength, LPCSTR lpData );
typedef WORD ( WINAPI *LPFN_TBReceiveData )( int nDevId, UINT nConvert );
typedef int  ( WINAPI *LPFN_TBClose )( int nDevId );

typedef int  ( WINAPI *LPFN_TBConvertData )( int nDevId, UINT nConvert, UINT nLength, LPCSTR lpData );
typedef int  ( WINAPI *LPFN_TBConnectCancel )( int nDevId );

//���ꂼ��̌^�̊֐��|�C���^�̐錾///////////////
LPFN_TBOpen	xTBOpen;
LPFN_TBConfigureDeviceDlg xTBConfigureDeviceDlg;
LPFN_TBConfigureParamDlg xTBConfigureParamDlg;
LPFN_TBIsExistFirmware xTBIsExistFirmware;
LPFN_TBSetupEx xTBSetupEx;
LPFN_TBConnectEx xTBConnectEx;
LPFN_TBSendEOT xTBSendEOT;
LPFN_TBSendDLEEOT xTBSendDLEEOT;
LPFN_TBDisconnectLine xTBDisconnectLine;
LPFN_TBReset xTBReset;
LPFN_TBSendData xTBSendData;
LPFN_TBReceiveData xTBReceiveData;
LPFN_TBClose xTBClose;
LPFN_TBConvertData xTBConvertData;
LPFN_TBConnectCancel xTBConnectCancel;

/*======================================================================*/
/* �O���[�o���ϐ��錾													*/
/*======================================================================*/
HINSTANCE _hinst;
char *rtrim( char * );

static	short	cnnectMode = TM_INIT_MODE;	/* �ڑ����[�h�i���M����M�j */
static	int		g_nDevId = -1;				/* �ʐM�f�o�C�X���ʎq */
static	short	conManual;					/* �������M�^�蓮���M�ݒ� */
static	short	atone;						/* �A���T�[�g�[���̗L���ݒ� */
static	short	awTimerT8;					/* ID�����Ď���ϰ(���M��) */

/*TRANSB.DLL���|�X�g���郁�b�Z�[�W��LPARAM�l----------------------------*/
static	TBLPARAM*	pTBLPARAM;				/* �X�e�[�^�X���X�|���X */
static	TBSTS	FAR*	lpTBSTS;			/* ���N�G�X�g���X�|���X */
static	TBDT	FAR*	lpTBDT;				/* �f�[�^���X�|���X */
static	TBCV	FAR*	lpTBCV;				/* �R���o�[�g���X�|���X */

static	TBLPARAM		seTBLPARAM;			/* �X�e�[�^�X���X�|���X */
static	TBSTS			seTBSTS;			/* ���N�G�X�g���X�|���X */
static	TBDT			seTBDT;				/* �f�[�^���X�|���X */
static	TBCV			seTBCV;				/* �R���o�[�g���X�|���X */

static	TBSETUP			lpTBSETUP;			/* �Z�b�g�A�b�v�\���� */
static	TBCONNECT		lpTBCONNECT;		/* ����ڑ��\���� */

static	char	g_szDeviceName[128];		/* �ʐM�f�o�C�X�� */
static	char	*g_szAppName = "TBFWSENDI";	/* �N���X�� */
static	char	g_szDLLName[257];			/* �ʐM�c�k�k�� */
static	UINT	iTBMessage = 0;				/* ���b�Z�[�W */
static	HWND	TBhwnd;						/* �E�B���h�E�n���h�� */
static	short	TBWndProcMess=TB_MES_NEXT;	/* ���b�Z�[�W�ݒ� */
static	short	TBWndProcRet;				/* ���b�Z�[�W�ߒl */

static	short	RecRtryLoop;				/* ��M�����̽ð��ڽ��ݽ�łO���ݒ肳�ꂽ�ꍇ�̑΍� */
static	HINSTANCE	hInstDLL = (HINSTANCE)NULL;

static	short	DLL_OPEN(void);
static	short	DLL_CLOSE(void);

/************************************************************************/
/*	module name 	:	�X�e�[�^�X�̎擾								*/
/*					:	WndProc 										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	WndProc(HWND, UINT, WPARAM, LPARAM)		*/
/*	parameter		:	nothing											*/
/*	return value	:	nothing											*/
/************************************************************************/
LRESULT __declspec(dllexport) CALLBACK WndProc( HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam )
{

	if( msg == iTBMessage ){
		switch(wParam){
			/*�X�e�[�^�X���X�|���X--------------------------------------*/
			case	ST_RESPONSE:
				pTBLPARAM = ( TBLPARAM* )&lParam;
				seTBLPARAM = *pTBLPARAM;
				TBWndProcMess = TB_MES_NEXT;
				if ( pTBLPARAM->nResult != 0 )	TBWndProcRet = LPOS_NG;
				else							TBWndProcRet = 0;
				if( pTBLPARAM->wCommand == 0x5244 && TBWndProcRet == 0 ){
					RecRtryLoop = 1;
				}
				break;
			/*�f�[�^���X�|���X------------------------------------------*/
			case	DT_RESPONSE:
				lpTBDT = ( TBDT FAR* )GlobalLock( (HWND)lParam );
				seTBDT.bType   = lpTBDT->bType;
				seTBDT.nLength = lpTBDT->nLength;
				memcpy( seTBDT.abRecvData, lpTBDT->abRecvData, seTBDT.nLength );
				GlobalUnlock( (HWND)lParam );
				TBWndProcMess = TB_MES_NEXT;
				TBWndProcRet = 0;
				break;
			/*�R���o�[�g���X�|���X--------------------------------------*/
			case	CV_RESPONSE:
				lpTBCV = ( TBCV FAR* )GlobalLock( (HWND)lParam );
				seTBCV = *lpTBCV;
				GlobalUnlock( (HWND)lParam );
				TBWndProcMess = TB_MES_NEXT;
				TBWndProcRet = 0;
				break;
		}
		return(0L);
	}
	switch(msg){
		case	WM_CREATE:
			/*TBFW���b�Z�[�W�̓o�^*/
			if( (iTBMessage = RegisterWindowMessage( TB_MESSAGE )) == 0 ){
				return -1L;
			}
			return 0L;
	}
	return( DefWindowProc( hwnd, msg, wParam, lParam ) );
}
/************************************************************************/
/*	module name 	:	�C�x���g�ݒ�									*/
/*					:	LSetMess										*/
/*----------------------------------------------------------------------*/
/*	style			:	void	LSetMess(void)							*/
/*	parameter		:	nothing											*/
/*	return value	:	nothing											*/
/************************************************************************/
void	LSetMess( void )
{
	TBWndProcMess = TB_MES_FIRST;
}
/************************************************************************/
/*	module name 	:	�C�x���g�J�n									*/
/*					:	LPostMess										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LPostMess(short)						*/
/*	parameter		:	short	ENA_KEY_STOP		�uESC+CTRL+A�v����	*/
/*					:			DIS_KEY_STOP		�uESC+CTRL+A�v�֎~	*/
/*					:			�� ENA_KEY_CANC		�uESC+CTRL+A�v����	*/
/*					:				(����ڑ��r���ł̏������f���߰�) 	*/
/*	return value	:	short	0					����				*/
/*					:			LPOS_NG				���s				*/
/*					:			LPOS_ESC			���f				*/
/************************************************************************/
short	LPostMess( short mode )
{
	MSG		msg;
	int		nCnt=0;
	DWORD	dwTime;
	short	escMode = 0;

	while( TBWndProcMess == TB_MES_FIRST ){
		while(PeekMessage(&msg, NULL, 0, 0, PM_REMOVE)){
			DispatchMessage(&msg);
			if( ( (mode == ENA_KEY_STOP) || (mode == ENA_KEY_CANC) )
			&& (escMode == 0) ){
				switch(nCnt){
				case 0:
					if(GetAsyncKeyState(VK_ESCAPE)&0x8000){
						dwTime=GetTickCount()+3000;
						nCnt++;
					}
					break;
				case 1:
					if(GetTickCount()>dwTime){
						nCnt=0;
						break;
					}
					if(GetAsyncKeyState(VK_CONTROL)&GetAsyncKeyState('A')&0x8000){
						escMode = 1;
						if( mode == ENA_KEY_CANC ){
							xTBConnectCancel(g_nDevId);
						}
					}
					break;
				}
			}
		}
	}
	if( escMode != 0 )	TBWndProcRet = LPOS_ESC;
	return( TBWndProcRet );
}
/************************************************************************/
/*	module name 	:	�s�a�r�d�s�t�o�\���̂̏�����					*/
/*					:	LSetUpIni										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LSetupIni()								*/
/*	parameter		:	nothing											*/
/*	return value	:	short	0					����				*/
/*					:			LPOS_NG				���s				*/
/************************************************************************/
short	LSetUpIni( void )
{
	char	WindowDir[256];
	// 20081121 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	char	defaultDir[256];
	char	dllTemp[256];
	char drive[_MAX_DRIVE], dir[_MAX_DIR], fname[_MAX_FNAME], ext[_MAX_EXT];
	// 20081121 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	char	tbfwSet[128];
	char	tbname[10];
	short	cnt;

	/*�ʐM�f�o�C�X���̎擾----------------------------------------------*/
	memset(g_szDeviceName, 0, sizeof(g_szDeviceName));

	// 20081121 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	//GetWindowsDirectory(WindowDir, sizeof(WindowDir));
	//strcat(WindowDir, "\\rsbsc.ini");

	memset(defaultDir, 0, sizeof(defaultDir));

	GetModuleFileName(hInstDLL, defaultDir, sizeof(defaultDir));
	_splitpath(defaultDir, drive, dir, fname, ext); 

	strcpy(defaultDir, drive);
	strcat(defaultDir, dir);

	if(defaultDir[strlen(defaultDir) - 1] != '\\')
	{
		strcat(defaultDir, "\\");
	}

	strcpy(WindowDir, defaultDir);
	strcat(WindowDir, "rsbsc.ini");
	// 20081121 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

	if( GetPrivateProfileString("OASIS", "TBFW", "", g_szDeviceName,
				sizeof(g_szDeviceName), WindowDir) == 0){
		return(LPOS_NG);
	}


 	/*�c�k�k���̎擾----------------------------------------------------*/
	// 20081121 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 	//if( GetPrivateProfileString("OASIS",
 	//			(TBIsWindowsNT() ? "DLL_PATH_NT": "DLL_PATH_95"),
 	//			"", g_szDLLName,
 	//			sizeof(g_szDLLName), WindowDir) == 0){
 	//	return(LPOS_NG);
 	//}

	if( GetPrivateProfileString("OASIS",
				"DLL_PATH_NT",
				"", dllTemp,
				sizeof(dllTemp), WindowDir) == 0)
	{
		return(LPOS_NG);
 	}

	memset(g_szDLLName, 0, sizeof(g_szDLLName));
	strcpy(g_szDLLName, defaultDir);
	strcat(g_szDLLName, dllTemp);
	// 20081121 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

	/*�����ʂ̎擾----------------------------------------------------*/
	if( GetPrivateProfileString("OASIS", "LINE_TYPE", "",
				tbfwSet, sizeof(tbfwSet), WindowDir) == 0){
		strcpy( tbfwSet, "PB" );
	}
	if( strcmp(tbfwSet, "DP10") == 0 )		lpTBSETUP.fLineType=TBS_DP10;
	else if(strcmp(tbfwSet, "DP20") == 0)	lpTBSETUP.fLineType=TBS_DP20;
	else 									lpTBSETUP.fLineType=TBS_PB;

	/*�A���T�|�g�[�����o�̗L��------------------------------------------*/
	atone = DIS_ANSERTONE;
	if( GetPrivateProfileString("OASIS", "ANSERTONE", "",
				tbfwSet, sizeof(tbfwSet), WindowDir) != 0){
		if( atoi(tbfwSet) == 1 )	atone = ENA_ANSERTONE;
	}

	/*�������M�^�蓮���M�̐ݒ�------------------------------------------*/
	if( GetPrivateProfileString("OASIS", "NCU_TYPE", "",
				tbfwSet, sizeof(tbfwSet), WindowDir) == 0){
		strcpy( tbfwSet, "AUTO" );
	}
	if( strcmp( tbfwSet, "MANUAL" ) == 0 )	conManual = CONNECT_MANUAL;
	else									conManual = CONNECT_AUTO;

	/*�^�C�}�[�l�ݒ�----------------------------------------------------*/
	lpTBSETUP.awTimer[0]	= 6;
	lpTBSETUP.awTimer[1]	= 6;
	lpTBSETUP.awTimer[2]	= 30;
	lpTBSETUP.awTimer[3]	= 20;
	lpTBSETUP.awTimer[4]	= 30;
	lpTBSETUP.awTimer[5]	= 30;
	lpTBSETUP.awTimer[6]	= 120;
			  awTimerT8 	= 5;
	for(cnt=0; cnt<8; cnt++){
		sprintf( tbname, "TB_T%d", cnt+1 );
		if( GetPrivateProfileString("OASIS", tbname, "",
					tbfwSet, sizeof(tbfwSet), WindowDir) != 0){
			if( cnt == 7 )	awTimerT8 = (BYTE)atoi(tbfwSet);
			else			lpTBSETUP.awTimer[cnt] = atoi(tbfwSet);

		}
	}

	/*�J�E���^�l�ݒ�----------------------------------------------------*/
	lpTBSETUP.awCount[0]	= 7;
	lpTBSETUP.awCount[1]	= 7;
	lpTBSETUP.awCount[2]	= 7;
	lpTBSETUP.awCount[3]	= 7;
	lpTBSETUP.awCount[4]	= 8;
	lpTBSETUP.awCount[5]	= 8;
	lpTBSETUP.awCount[6]	= 0;
	for(cnt=0; cnt<7; cnt++){
		sprintf( tbname, "TB_N%d", cnt+1 );
		if( GetPrivateProfileString("OASIS", tbname, "",
					tbfwSet, sizeof(tbfwSet), WindowDir) != 0){
			lpTBSETUP.awCount[cnt] = atoi(tbfwSet);
		}
	}

	/*TBSETUP�\���̂̏�����---------------------------------------------*/
	lpTBSETUP.fLine			= TBS_SWITCHED;
	lpTBSETUP.fDuplex		= TBS_HALF;
	lpTBSETUP.fCode			= TBS_EBSDIC;
	lpTBSETUP.fControl		= TBS_AUTO;
	lpTBSETUP.fTxClock		= TBS_EXTERNAL;
	lpTBSETUP.fRxClock		= TBS_EXTERNAL;
	lpTBSETUP.fSpeed		= TBS_BPS2400;
	lpTBSETUP.fPadCount		= 1;
	lpTBSETUP.bPadChar		= 0x32;
	lpTBSETUP.fSyncCount	= 4;
	lpTBSETUP.bSyncChar		= 0x32;
	lpTBSETUP.fRsCsCdDelay	= TBS_RSCS_MSEC70_10;
	lpTBSETUP.fRsAckDelay	= TBS_RSACK_MSEC50;
	lpTBSETUP.fSukeruti		= TBS_SUKE_MSEC40;
	lpTBSETUP.fCarrier		= TBS_DB_43;
	lpTBSETUP.fScramble		= TBS_SCRAMBLEOFF;
	lpTBSETUP.fAnserTone	= TBS_HZ2100;
	lpTBSETUP.fAttlevel		= TBS_DBM_15;
	return(0);
}
/************************************************************************/
/*	module name 	:	����I�[�v��									*/
/*					:	L_LOPEN 										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	L_LOPEN(short)							*/
/*	parameter		:	short	BSC1_PRIMARY		��p���/�D���		*/
/*					:			BSC2_PRIMARY		���O���/�D���		*/
/*					:			BSC1_SECONDARY		��p���/��D���	*/
/*					:			BSC2_SECONDARY		���O���/��D���	*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_LOPEN_MODEM_ERROR		���f���G���[	*/
/*					:			R_LOPEN_DUPLICATE_OPEN	��d�I�[�v��	*/
/************************************************************************/
short	WINAPI L_LOPEN( short opn_typ )
{
	WNDCLASS	wc;			/* Window Class */
	short	opn_cnt;

	/*��d�I�[�v���`�F�b�N----------------------------------------------*/
	if( g_nDevId >= 0 ){
		return(R_LOPEN_DUPLICATE_OPEN);
	}

	/*�E�B���h�E�n���h���̍쐬------------------------------------------*/
	wc.style		= CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS;
	wc.lpfnWndProc	= (WNDPROC)WndProc;			/* Window Procedure */
	wc.cbClsExtra	= 0;
	wc.cbWndExtra	= 0;
	wc.hInstance	= _hinst;
	wc.hIcon		= NULL;
	wc.hCursor		= NULL;
	wc.hbrBackground= NULL;
	wc.lpszMenuName = NULL;
	wc.lpszClassName= g_szAppName;
	RegisterClass(&wc);

	TBhwnd = CreateWindow(
		g_szAppName,	"PM_BSC_BAR",		/* Window Class, Title Bar */
		WS_POPUP,							/* Window Style */
		0, 0, 								/* X-Position, Y-Position */
		0, 0, 								/* Window Width, Height */
		NULL, NULL,							/* Parent, menu */
		_hinst, NULL);						/* Instance, Xtra-Data */

	if( TBhwnd == NULL ){
		return(R_LOPEN_DUPLICATE_OPEN);
	}
	if( LSetUpIni() != 0 ){
		return(R_LOPEN_DUPLICATE_OPEN);
	}

	/*�c�k�k�I�[�v��----------------------------------------------------*/
	if(DLL_OPEN() != 0){
		DLL_CLOSE();
		return(R_LOPEN_MODEM_ERROR);
	}

	/*�I�[�v��----------------------------------------------------------*/
	for( opn_cnt=0; opn_cnt<10; opn_cnt++ ){
		if( (g_nDevId = xTBOpen( TBhwnd, g_szDeviceName )) >= 0 )	break;
	}
	if( g_nDevId < 0 )	return(R_LOPEN_MODEM_ERROR);

	/*�a�r�b����v���O�����̑��݌���------------------------------------*/
	// 20081121 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	//if(xTBIsExistFirmware(g_nDevId) != 1)	return(R_LOPEN_MODEM_ERROR);
	// 20081121 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

	/*�ċǐݒ�----------------------------------------------------------*/
	cnnectMode = TM_CONN_MODE;
	if( opn_typ == BSC1_PRIMARY || opn_typ == BSC2_PRIMARY ){
		lpTBSETUP.fPriority = TBS_PRIMARY;
	}else{
		lpTBSETUP.fPriority = TBS_SECONDARY;
	}
	if( opn_typ == BSC1_PRIMARY || opn_typ == BSC1_SECONDARY ){
		lpTBSETUP.fBsc		= TBS_BSC1;
	}else{
		lpTBSETUP.fBsc		= TBS_BSC2;
	}
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	����N���[�Y									*/
/*					:	L_LCLOSE										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LCLOSE()								*/
/*	parameter		:	nothing											*/
/*	return value	:	short	R_NORMAL			����I��			*/
/************************************************************************/
short  WINAPI L_LCLOSE( void )
{
	short	ret;

	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )	return(R_NORMAL);
	DestroyWindow(TBhwnd);
	cnnectMode = TM_INIT_MODE;
	ret = xTBClose(g_nDevId);
	g_nDevId = -1;

	/*�c�k�k�N���[�Y----------------------------------------------------*/
	DLL_CLOSE();
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	�h�c�����ݒ�									*/
/*					:	SETID											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	SETID(char *, char *)					*/
/*	parameter		:	char *	���M�p�h�c								*/
/*					:	char *	��M�p�h�c								*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_SETID_ID_SET_ERROR	�h�c�ݒ���	*/
/*					:			R_SETID_NOT_OPEN		���I�[�v���G���[*/
/************************************************************************/
short	WINAPI	SETID( char *send_id, char *recv_id )
{
	char	snd_ebc[50];
	char	rec_ebc[50];

	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )	return(R_SETID_NOT_OPEN);

	/*�h�c�̐ݒ�--------------------------------------------------------*/
	lpTBCONNECT.bSelfIDLength  = strlen(send_id);
	lpTBCONNECT.bCheckIDLength = strlen(recv_id);
	if(lpTBCONNECT.bSelfIDLength > 15 || lpTBCONNECT.bCheckIDLength > 15){
		return(R_SETID_ID_SET_ERROR);
	}
	if(JISEBC(send_id, snd_ebc, lpTBCONNECT.bSelfIDLength) != R_NORMAL){
		return(R_SETID_ID_SET_ERROR);
	}
	lpTBCONNECT.bSelfIDLength  = (BYTE)seTBCV.nLength;

	if(JISEBC(recv_id, rec_ebc, lpTBCONNECT.bCheckIDLength) != R_NORMAL){
		return(R_SETID_ID_SET_ERROR);
	}
	lpTBCONNECT.bCheckIDLength	= (BYTE)seTBCV.nLength;

	if(lpTBCONNECT.bSelfIDLength > 15 || lpTBCONNECT.bCheckIDLength > 15){
		return(R_SETID_ID_SET_ERROR);
	}

	memset( lpTBCONNECT.abSelfID,  0x00, 15 );
	memset( lpTBCONNECT.abCheckID, 0x00, 15 );

	memcpy( lpTBCONNECT.abSelfID,  snd_ebc, lpTBCONNECT.bSelfIDLength );
	memcpy( lpTBCONNECT.abCheckID, rec_ebc, lpTBCONNECT.bCheckIDLength );
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	�d�n�s���o��A����ؒf�i���O����̂݁j			*/
/*					:	DISCONNECT										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DISCONNECT()							*/
/*	parameter		:	nothing											*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_DISCONNECT_CANCEL		�h�c�ݒ���	*/
/*					:			R_DISCONNECT_NOT_OPEN	���I�[�v���G���[*/
/************************************************************************/
short	WINAPI	DISCONNECT( void )
{
	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )					return(R_DISCONNECT_NOT_OPEN);

	/*�c�h�r�b�̔��s----------------------------------------------------*/
	LSetMess();
	if( xTBSendDLEEOT(g_nDevId) == 0 )	LPostMess( DIS_KEY_STOP );

	/*����̐ؒf--------------------------------------------------------*/
	LSetMess();
	if(xTBDisconnectLine(g_nDevId) == 0)	LPostMess( DIS_KEY_STOP );
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	�f�[�^�����N�̊m��								*/
/*					:	CONCT											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	CONCT(short)							*/
/*	parameter		:	short	TM_DIAL_MODE			�������M		*/
/*					:			TM_CONN_MODE			�������M		*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			LPOS_NG					���s			*/
/*					:			LPOS_ESC				���f			*/
/*					:			LPOS_ERR				�R�}���h�G���[	*/
/************************************************************************/
short	CONCT(short mode)
{
	/*���Z�b�g----------------------------------------------------------*/
	LSetMess();
	if( xTBReset(g_nDevId) != 0 )			return(R_LOPEN_MODEM_ERROR);
	if( LPostMess( DIS_KEY_STOP ) != 0 )	return(R_LOPEN_MODEM_ERROR);

	/*�Z�b�g�A�b�v------------------------------------------------------*/
	LSetMess();
	if( xTBSetupEx( g_nDevId, &lpTBSETUP ) != 0 )	return(LPOS_ERR);
	if( LPostMess( DIS_KEY_STOP ) != 0 )			return(LPOS_NG);

	/*�������M�ݒ�------------------------------------------------------*/
	if( (cnnectMode = mode) == TM_DIAL_MODE ){
		lpTBCONNECT.fNcuType = TBC_NCU_CALL;
		lpTBCONNECT.fCaller = TBC_CALLER;
	/*�蓮���M�ݒ�------------------------------------------------------*/
	}else{
		lpTBCONNECT.bTelNoLength = 0;
		memset( lpTBCONNECT.abTelNo, 0x00, sizeof(lpTBCONNECT.abTelNo) );
		if( conManual == CONNECT_MANUAL ){
			lpTBCONNECT.fNcuType = TBC_NCU_CALL;
			lpTBCONNECT.fCaller = TBC_ANSER;
		}else{
	/*�������M�ݒ�------------------------------------------------------*/
			lpTBCONNECT.fNcuType = TBC_NCU_ANSER;
			lpTBCONNECT.fCaller = TBC_ANSER;
		}
	}

	/*�ڑ�����----------------------------------------------------------*/
	LSetMess();
	if(xTBConnectEx( g_nDevId, &lpTBCONNECT ) != 0)	return(LPOS_ERR);
	return( LPostMess( ENA_KEY_CANC ) );
}
/************************************************************************/
/*	module name 	:	�����_�C�������O								*/
/*					:	DIAL											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DIAL(short, char *)						*/
/*	parameter		:	short	REGULAR_MODEM		�m�t�����f��		*/
/*					:			IRREGULAR_MODEM		�m�������f��		*/
/*					:													*/
/*					:	char *	�_�C�����ԍ��i�[�i�U�R���ȓ��j			*/
/*					:													*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_DIAL_CANCEL			�L�����Z��		*/
/*					:			R_DIAL_NOT_OPEN			���I�[�v���G���[*/
/*					:			R_DIAL_WAIT_DIAL		�_�C�����s�\	*/
/*					:			R_DIAL_DIAL_NO_ERROR	�_�C�����ԍ��װ	*/
/*					:			R_DIAL_BSC_CHECK		���f����Q		*/
/*					:			R_DIAL_BUSY_TALKING		�b��			*/
/*					:			R_DIAL_NO_ANSWER		���肪�o�Ȃ�	*/
/************************************************************************/
short	WINAPI	DIAL( short tel_typ, char  *tel_no )
{
	short	ret;

	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )	return(R_DIAL_NOT_OPEN);

	/*�_�C�����ԍ��̊i�[------------------------------------------------*/
	lpTBCONNECT.bTelNoLength = strlen(tel_no);
	if( lpTBCONNECT.bTelNoLength > 63 )	return(R_DIAL_DIAL_NO_ERROR);
	memset( lpTBCONNECT.abTelNo, 0x00, sizeof(lpTBCONNECT.abTelNo) );	// ADD 20091112 MANTIS�Ή�[14471] �_�C�����ԍ��̊i�[�o�b�t�@���N���A����Ă��Ȃ�
	memcpy( lpTBCONNECT.abTelNo, tel_no, lpTBCONNECT.bTelNoLength );
	rtrim( lpTBCONNECT.abTelNo );
	if( atone == ENA_ANSERTONE )	strcat( lpTBCONNECT.abTelNo, "F" );
	lpTBCONNECT.bTelNoLength = strlen(lpTBCONNECT.abTelNo);
	lpTBSETUP.awTimer[6] = awTimerT8;

	/*�f�[�^�����N�̊m��------------------------------------------------*/
	switch( ret = CONCT( TM_DIAL_MODE ) ){
		case	LPOS_NG:
			switch( seTBLPARAM.nDetail ){
				case	ER_MODEM_BUSY:
					ret = R_DIAL_BUSY_TALKING;
					break;
				case	ER_SND_FULL:
				case	ER_COMMAND:
				case	ER_DISCONNECT:
					ret = R_DIAL_BSC_CHECK;
					break;
				default:
					ret = R_DIAL_NO_ANSWER;
					break;
			}
			break;
		case	LPOS_ESC:
			ret = R_DIAL_CANCEL;
			break;
		case	LPOS_ERR:
			ret = R_DIAL_BSC_CHECK;
			break;
	}
	return(ret);
}
/************************************************************************/
/*	module name 	:	�e�L�X�g�𑗐M									*/
/*					:	SNDI											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	SNDI(char *, short, short)				*/
/*	parameter		:	char *	���M�e�L�X�g�f�[�^						*/
/*					:	short	���M�e�L�X�g���i�O�`�Q�O�R�W�j			*/
/*					:	short	S_ETB_CHANGE		STX-ETB				*/
/*					:			S_ETX_CHANGE		STX-ETX				*/
/*					:			S_DLE_ETB			DLE,STX-DLE,ETB		*/
/*					:			S_DLE_ETX			DLE,STX-DLE,ETX		*/
/*					:			S_ETB_NO_CHANGE		STX-ETB				*/
/*					:			S_ETX_NO_CHANGE		STX-ETX				*/
/*					:			S_SOH_ETB_CHANGE	SOH-STX-ETB			*/
/*					:			S_SOH_ETX_CHANGE	SOH-STX-ETX			*/
/*					:			S_SOH_DLE_ETB		SOH-DLE,STX-DLE,ETB	*/
/*					:			S_SOH_DLE_ETX		SOH-DLE,STX-DLE,ETX	*/
/*					:			S_SOH_ETB_NO_CHANGE	SOH-STX-ETB			*/
/*					:			S_SOH_ETX_NO_CHANGE	SOH-STX-ETX			*/
/*					:													*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_SNDI_OPERATOR_STOP	�I�y���[�^���f	*/
/*					:			R_SNDI_NOT_OPEN 		���I�[�v���G���[*/
/*					:			R_SNDI_BSC_CHECK		�ʐM�A�_�v�^��Q*/
/*					:			R_SNDI_GET_EOT			�d�n�s��M		*/
/*					:			R_SNDI_GET_DISK 		�c�h�r�b��M	*/
/*					:			R_SNDI_TIMEOUT			�^�C���A�E�g	*/
/*					:			R_SNDI_DATA_ERROR		ACK���ݐ��G���[	*/
/*					:			R_SNDI_GET_RVI			�q�u�h��M�G���[*/
/*					:			R_SNDI_CONTENTION		�R���e���V����	*/
/*					:			R_SNDI_WACK_COUNT_OVER	WACK���ĥ���ް	*/
/*					:			R_SNDI_PARAMETER_ERROR	���Ұ��ݒ�װ	*/
/*					:			R_SNDI_ID_CHANGE_ERROR	ID�����װ		*/
/************************************************************************/
short	WINAPI	SNDI( char *text, short text_len, short snd_typ  )
{
	short	ret;
	UINT	type;
	UINT	cvt = 0;

	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )					return(R_SNDI_NOT_OPEN);

	/*���M�T�C�Y��`�F�b�N-----------------------------------------------*/
	if( text_len > TBS_TEXT_MAX )		return(R_SNDI_PARAMETER_ERROR);

	/*����M�e�L�X�g�`���̐錾------------------------------------------*/
	switch( snd_typ ){
		case	S_ETB_CHANGE:
			cvt = 1;	/*JIS��EBCDIC*/
			type = TB_STXETB;
			break;
		case	S_ETX_CHANGE:
			cvt = 1;	/*JIS��EBCDIC*/
			type = TB_STXETX;
			break;
		case	S_DLE_ETB:
			type = TB_DSTXDETB;
			break;
		case	S_DLE_ETX:
			type = TB_DSTXDETX;
			break;
		case	S_ETB_NO_CHANGE:
			type = TB_STXETB;
			break;
		case	S_ETX_NO_CHANGE:
			type = TB_STXETX;
			break;
		case	S_SOH_ETB_CHANGE:
			cvt = 1;	/*JIS��EBCDIC*/
			type = TB_SOHETB;
			break;
		case	S_SOH_ETX_CHANGE:
			cvt = 1;	/*JIS��EBCDIC*/
			type = TB_SOHETX;
			break;
		case	S_SOH_DLE_ETB:
			type = TB_SOHDETB;
			break;
		case	S_SOH_DLE_ETX:
			type = TB_SOHDETX;
			break;
		case	S_SOH_ETB_NO_CHANGE:
		case	S_SOH_ETX_NO_CHANGE:
			return(R_SNDI_PARAMETER_ERROR);
	}

	/*���M�������s------------------------------------------------------*/
	while(1){
		LSetMess();
		if( xTBSendData( g_nDevId, type, cvt, text_len, text ) != 0 ){
			return(R_SNDI_TIMEOUT);
		}
		if( (ret = LPostMess( ENA_KEY_STOP )) == LPOS_NG ){
			switch( seTBLPARAM.nDetail ){
				case	ER_SND_FULL:
					continue;
				case	ER_EOT_TXT:
				case	ER_EOT_RES:
				case	ER_EOT_ENQ:
					ret = R_SNDI_GET_EOT;			/* �d�n�s��M */
					break;
				case	ER_DLE_EOT:
					ret = R_SNDI_GET_DISK;			/* �c�h�r�b��M */
					break;
				case	ER_TIME_TXT:
				case	ER_TIME_ACK:
				case	ER_TIME_CTS:
					ret = R_SNDI_TIMEOUT;			/* �^�C���A�E�g */
					break;
				case	ER_CHANGE:
					ret = R_SNDI_DATA_ERROR;		/* ACK���ݐ��G���[ */
					break;
				case	ER_RVI:
					ret = R_SNDI_GET_RVI;			/* �q�u�h��M�G���[ */
					LSetMess();
					if( xTBReceiveData( g_nDevId, 0 ) != 0 )	break;
					if( (ret = LPostMess( ENA_KEY_STOP )) != 0 )	break;
					ret = R_NORMAL;
					break;
				case	ER_CONTENTION:
					ret = R_SNDI_CONTENTION;		/* �R���e���V���� */
					break;
				case	ER_COMMAND:
					ret = R_SNDI_PARAMETER_ERROR;	/* ���Ұ��ݒ�װ */
					break;
				case	ER_CHG_ID:
					ret = R_SNDI_ID_CHANGE_ERROR;	/* ID�����װ */
					break;
				default:
					ret = R_SNDI_BSC_CHECK;			/* �ʐM�A�_�v�^��Q */
					break;
			}
		}else if( ret == LPOS_ESC ){
			ret = R_SNDI_OPERATOR_STOP;				/* �I�y���[�^���f */
		}
		break;
	}
	return(ret);
}
/************************************************************************/
/*	module name 	:	�e�L�X�g�𑗐M��A�d�n�s���o					*/
/*					:	SNDIR											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	SNDIR(char *, short, short)				*/
/*	parameter		:	char *	���M�e�L�X�g�f�[�^						*/
/*					:	short	���M�e�L�X�g���i�O�`�Q�O�S�W�j			*/
/*					:	short	S_ETB_CHANGE		STX-ETB				*/
/*					:			S_ETX_CHANGE		STX-ETX				*/
/*					:			S_DLE_ETB			DLE,STX-DLE,ETB		*/
/*					:			S_DLE_ETX			DLE,STX-DLE,ETX		*/
/*					:			S_ETB_NO_CHANGE		STX-ETB				*/
/*					:			S_ETX_NO_CHANGE		STX-ETX				*/
/*					:			S_SOH_ETB_CHANGE	SOH-STX-ETB			*/
/*					:			S_SOH_ETX_CHANGE	SOH-STX-ETX			*/
/*					:			S_SOH_DLE_ETB		SOH-DLE,STX-DLE,ETB	*/
/*					:			S_SOH_DLE_ETX		SOH-DLE,STX-DLE,ETX	*/
/*					:			S_SOH_ETB_NO_CHANGE	SOH-STX-ETB			*/
/*					:			S_SOH_ETX_NO_CHANGE	SOH-STX-ETX			*/
/*					:													*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_SNDIR_OPERATOR_STOP	�I�y���[�^���f	*/
/*					:			R_SNDIR_NOT_OPEN		���I�[�v���G���[*/
/*					:			R_SNDIR_BSC_CHECK		�ʐM�A�_�v�^��Q*/
/*					:			R_SNDIR_GET_EOT 		�d�n�s��M		*/
/*					:			R_SNDIR_GET_DISK		�c�h�r�b��M	*/
/*					:			R_SNDIR_TIMEOUT 		�^�C���A�E�g	*/
/*					:			R_SNDIR_DATA_ERROR		ACK���ݐ��G���[	*/
/*					:			R_SNDIR_GET_RVI 		�q�u�h��M�G���[*/
/*					:			R_SNDIR_CONTENTION		�R���e���V����	*/
/*					:			R_SNDIR_WACK_COUNT_OVER WACK���ĥ���ް	*/
/*					:			R_SNDIR_PARAMETER_ERROR ���Ұ��ݒ�װ	*/
/*					:			R_SNDIR_ID_CHANGE_ERROR	ID�����װ		*/
/************************************************************************/
short	WINAPI	SNDIR( char *text, short text_len, short snd_typ )
{
	short	ret;

	/*���M�������s------------------------------------------------------*/
	if( (ret = SNDI( text, text_len, snd_typ)) !=  R_NORMAL ){
		return(ret);
	}

	/*�d�n�s�̔��s------------------------------------------------------*/
	return(LRESET());
}
/************************************************************************/
/*	module name 	:	����V�X�e���ւd�n�s�𑗐M						*/
/*					:	LRESET											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LRESET()								*/
/*	parameter		:	nothing											*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_RESET_OPERATOR_STOP	�I�y���[�^���f	*/
/*					:			R_RESET_NOT_OPEN		���I�[�v���G���[*/
/*					:			R_RESET_BSC_CHECK		�ʐM�A�_�v�^��Q*/
/************************************************************************/
short	WINAPI	LRESET( void )
{
short	ret;

	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )						return(R_RESET_NOT_OPEN);

	/*�d�n�s�̔��s------------------------------------------------------*/
	LSetMess();
	if( xTBSendEOT(g_nDevId) != 0 )			return(R_RESET_BSC_CHECK);
	if( (ret = LPostMess( ENA_KEY_STOP )) == LPOS_NG ){
		if( seTBLPARAM.nDetail == ER_RVI ){
			LSetMess();
			if( xTBReceiveData( g_nDevId, 0 ) == 0 ){
				if( LPostMess( ENA_KEY_STOP ) == 0 )	return(R_NORMAL);
			}
		}
		return(R_RESET_BSC_CHECK);
	}else if(ret == LPOS_ESC){
		return(R_RESET_OPERATOR_STOP);
	}
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	��M�X�e�[�^�X�ݒ�								*/
/*					:	REC_ERRMES										*/
/*----------------------------------------------------------------------*/
/*	style			:	void	REC_ERRMES(void)						*/
/*	parameter		:	nothing											*/
/*	return value	:	nothing											*/
/************************************************************************/
short	REC_ERRMES( void )
{
	short	ret;

	switch( seTBLPARAM.nDetail ){
		case	ER_EOT_TXT:
		case	ER_EOT_RES:
		case	ER_EOT_ENQ:
			ret = R_REC_GET_EOT;
			break;
		case	ER_DLE_EOT:
			ret = R_REC_GET_DISK;
			break;
		case	ER_MODEM_BUSY:
		case	ER_MODEM_NO_TONE:
		case	ER_DIAL:
		case	ER_TIME_TXT:
		case	ER_TIME_ACK:
		case	ER_TIME_CTS:
			ret = R_REC_TIMEOUT;
			break;
		case	ER_DATA_CRC:
			ret = R_REC_DATA_ERROR;
			break;
		case	ER_COMMAND:
			ret = R_REC_PARAMETER_ERROR;
			break;
		case	ER_CHG_ID:
			ret = R_REC_ID_CHANGE_ERROR;
			break;
		default:
			ret = R_REC_BSC_CHECK;
			break;
	}
	return(ret);
}
/************************************************************************/
/*	module name 	:	�e�L�X�g����M									*/
/*					:	REC												*/
/*----------------------------------------------------------------------*/
/*	style			:	short	REC(char *, short, short *, short *)	*/
/*	parameter		:	char *	��M�o�b�t�@							*/
/*					:	short	��M�o�b�t�@��							*/
/*					:	short *	��M�����e�L�X�g�̒���					*/
/*					:	short *	��M�����e�L�X�g�̌`��					*/
/*					:			R_ETB				STX-ETB				*/
/*					:			R_ETX				STX-ETX				*/
/*					:			R_DLE_ETB			DLE,STX-DLE,ETB		*/
/*					:			R_DLE_ETX			DLE,STX-DLE,ETX		*/
/*					:			R_SOH_ETB			SOH-STX-ETB			*/
/*					:			R_SOH_ETX			SOH-STX-ETX			*/
/*					:			R_SOH_DLE_ETB		SOH-DLE,STX-DLE,ETB	*/
/*					:			R_SOH_DLE_ETX		SOH-DLE,STX-DLE,ETX	*/
/*					:													*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_REC_OPERATOR_STOP		�I�y���[�^���f	*/
/*					:			R_REC_NOT_OPEN		  	���I�[�v���G���[*/
/*					:			R_REC_BSC_CHECK 	  	�ʐM�A�_�v�^��Q*/
/*					:			R_REC_GET_EOT		  	�d�n�s��M		*/
/*					:			R_REC_GET_DISK		  	�c�h�r�b��M	*/
/*					:			R_REC_TIMEOUT		  	�^�C���A�E�g	*/
/*					:			R_REC_DATA_ERROR	  	BCC�đ��G���[	*/
/*					:			R_REC_PARAMETER_ERROR 	���Ұ��ݒ�װ	*/
/*					:			R_REC_RECV_LENGTH_OVER	��M÷�ĵ��ް	*/
/*					:			R_REC_ID_CHANGE_ERROR	ID�����װ		*/
/************************************************************************/
short	WINAPI	REC( char *text_buff, short text_buff_siz,
								short *block_len, short *text_len )
{
	short	size;
	short	ret;
	short	recFlg = 0;

	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 )						return(R_REC_NOT_OPEN);

	/*�������M----------------------------------------------------------*/
	if( cnnectMode == TM_CONN_MODE ){
		switch( CONCT( TM_CONN_MODE ) ){
			case	LPOS_NG:	return( REC_ERRMES() );
			case	LPOS_ESC:	return(R_REC_OPERATOR_STOP);
			case	LPOS_ERR:	return(R_REC_BSC_CHECK);
		}
		cnnectMode = TM_INIT_MODE;
		recFlg = 1;
	}

	/*��M����----------------------------------------------------------*/
	do{
		RecRtryLoop = 0;
		LSetMess();
		if( xTBReceiveData( g_nDevId, 0 ) != 0 )
			return(R_REC_BSC_CHECK);
		if( (ret = LPostMess( ENA_KEY_STOP )) == LPOS_NG ){
			if( recFlg == 1 )	return(R_REC_BSC_CHECK);
			else				return( REC_ERRMES() );
		}else if( ret == LPOS_ESC ){
			return(R_REC_OPERATOR_STOP);
		}
	}while( RecRtryLoop != 0 );
	cnnectMode = TM_INIT_MODE;

	if( seTBDT.nLength > (unsigned short)text_buff_siz ){
		size = text_buff_siz;
	}else{
		size = seTBDT.nLength;
	}
	memcpy( text_buff, seTBDT.abRecvData, size );
	*block_len = seTBDT.nLength;
	*text_len  = seTBDT.bType;	/*����M�e�L�X�g�`���̐ݒ�*/
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	�������u���b�N�̓��e�ǂݎ��					*/
/*					:	LCBR											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LCBR(short)								*/
/*	parameter		:	short	�̈�ԍ��i0�`20�j						*/
/*	return value	:	short	0�`32767				�Q�ƒl			*/
/*					:			R_LCBR_REGION_NO_ERROR	�Q�Ǝ��s		*/
/************************************************************************/
short	WINAPI	LCBR( short lcbno )
{
	short	ret;

	switch( lcbno ){
		/*C-Telecom Command No(Communication Count Octet)---------------*/
		case	0:							/*0*/
			ret = lpTBSETUP.fSpeed - 4;
			break;
		/*C-Telecom Command No(Retry Count Octet)-----------------------*/
		case	RCO_NO_ANSWER_FOR_ENQ:		/*1*/
			ret = lpTBSETUP.awCount[0];
			break;
		case	RCO_NO_ANSWER_FOR_ETX:		/*3*/
			ret = lpTBSETUP.awCount[3];
			break;
		case	RCO_NAK_FOR_ENQ:			/*4*/
			ret = lpTBSETUP.awCount[2];
			break;
		case	RCO_MISTAKE_SEQUENCE_ACK:	/*6*/
			ret = lpTBSETUP.awCount[1];
			break;
		case	RCO_NO_MUTCH_BCC:			/*7*/
			ret = lpTBSETUP.awCount[4];
			break;
		case	RCO_ENQ_FOR_REPLY:			/*8*/
			ret = lpTBSETUP.awCount[5];
			break;
		/*C-Telecom Command No(Time Counter Octet)----------------------*/
		case	TCO_WAIT_RECEIVE_ENQ:		/*13*/
			ret = lpTBSETUP.awTimer[5];
			break;
		case	TCO_WAIT_AFTER_SEND_WACK:	/*14*/
			ret = lpTBSETUP.awTimer[2];
			break;
		case	TCO_WAIT_FOR_ETB_ETX:		/*15*/
			ret = lpTBSETUP.awTimer[3];
			break;
		case	TCO_WAIT_FOR_DIAL:			/*16*/
			ret = lpTBSETUP.awTimer[4];
			break;
		case	TCO_WAIT_AFTER_SEND_ENQ:	/*18*/
			ret = lpTBSETUP.awTimer[0];
			break;
		case	TCO_WAIT_AFTER_SEND_ETX:	/*19*/
			ret = lpTBSETUP.awTimer[1];
			break;
		/*C-Telecom Command No(REGION_NO_ERROR)-------------------------*/
		case	RCO_WACK_FOR_ENQ:			/*2*/
		case	RCO_WACK_FOR_ETX:			/*5*/
		case	RCO_RESERVE1:				/*9*/
		case	RCO_RESERVE2:				/*10*/
		case	RCO_COMMUNICATION_TEXT:		/*11*/
		case	RCO_CHANGE_CODE:			/*12*/
		case	TCO_WAIT_RESERVE1:			/*17*/
		case	TCO_WAIT_RESERVE2:			/*20*/
		default:
			ret = R_LCBR_REGION_NO_ERROR;
			break;
	}
	return(ret);
}
/************************************************************************/
/*	module name 	:	�������u���b�N�̓��e���X�V					*/
/*					:	LCBW											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LCBW(short, short)						*/
/*	parameter		:	short	�̈�ԍ��i0�`20�j						*/
/*					:	short	�w��l									*/
/*	return value	:	short	R_NORMAL				����I��		*/
/*					:			R_LCBW_REGION_NO_ERROR	�X�V���s		*/
/************************************************************************/
short	WINAPI	LCBW( short lcbno, short lcbdata )
{
	short	ret = R_NORMAL;

	switch( lcbno ){
		/*C-Telecom Command No(Communication Count Octet)---------------*/
		case	0:							/*0*/
			lpTBSETUP.fSpeed = lcbdata + 4;
			break;
		/*C-Telecom Command No(Retry Count Octet)-----------------------*/
		case	RCO_NO_ANSWER_FOR_ENQ:		/*1*/
			lpTBSETUP.awCount[0] = lcbdata;
			break;
		case	RCO_NO_ANSWER_FOR_ETX:		/*3*/
			lpTBSETUP.awCount[3] = lcbdata;
			break;
		case	RCO_NAK_FOR_ENQ:			/*4*/
			lpTBSETUP.awCount[2] = lcbdata;
			break;
		case	RCO_MISTAKE_SEQUENCE_ACK:	/*6*/
			lpTBSETUP.awCount[1] = lcbdata;
			break;
		case	RCO_NO_MUTCH_BCC:			/*7*/
			lpTBSETUP.awCount[4] = lcbdata;
			break;
		case	RCO_ENQ_FOR_REPLY:			/*8*/
			lpTBSETUP.awCount[5] = lcbdata;
			break;
		/*C-Telecom Command No(Time Counter Octet)----------------------*/
		case	TCO_WAIT_RECEIVE_ENQ:		/*13*/
			lpTBSETUP.awTimer[5] = lcbdata / 2;
			break;
		case	TCO_WAIT_AFTER_SEND_WACK:	/*14*/
			lpTBSETUP.awTimer[2] = lcbdata / 2;
			break;
		case	TCO_WAIT_FOR_ETB_ETX:		/*15*/
			lpTBSETUP.awTimer[3] = lcbdata / 2;
			break;
		case	TCO_WAIT_FOR_DIAL:			/*16*/
			lpTBSETUP.awTimer[4] = lcbdata / 2;
			break;
		case	TCO_WAIT_AFTER_SEND_ENQ:	/*18*/
			lpTBSETUP.awTimer[0] = lcbdata / 2;
			break;
		case	TCO_WAIT_AFTER_SEND_ETX:	/*19*/
			lpTBSETUP.awTimer[1] = lcbdata / 2;
			break;
		/*C-Telecom Command No(REGION_NO_ERROR)-------------------------*/
		case	RCO_WACK_FOR_ENQ:			/*2*/
		case	RCO_WACK_FOR_ETX:			/*5*/
		case	RCO_RESERVE1:				/*9*/
		case	RCO_RESERVE2:				/*10*/
		case	RCO_COMMUNICATION_TEXT:		/*11*/
		case	RCO_CHANGE_CODE:			/*12*/
		case	TCO_WAIT_RESERVE1:			/*17*/
		case	TCO_WAIT_RESERVE2:			/*20*/
		default:
			ret = R_LCBW_REGION_NO_ERROR;
			break;
	}
	return(ret);
}
/************************************************************************/
/*	module name 	:	��M÷�Ă̺��ޕϊ��w��							*/
/*					:	STCGCD											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	STCGCD(short)							*/
/*	parameter		:	short	�w��l									*/
/*	return value	:	nothing											*/
/************************************************************************/
void  WINAPI	STCGCD( short chg_flg )
{
	LCBW( RCO_CHANGE_CODE, chg_flg );
}
/************************************************************************/
/*	module name 	:	�i�h�r�|���d�a�b�R�[�h�ϊ�						*/
/*					:	JISEBC											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	JISEBC(char *, char *, short)			*/
/*	parameter		:	char *	�i�h�r�R�[�h�i�[�̈�					*/
/*					:	char *	�d�a�b�c�h�b�R�[�h�i�[�̈�				*/
/*					:	short	�ϊ��f�[�^�̒����i�ő�Q�T�U�o�C�g�j	*/
/*	return value	:	short	R_NORMAL					����I��	*/
/*					:			R_JISEBC_CHANGE_LENGTH_OVER	�ϊ����s	*/
/************************************************************************/
short	JISEBC( char  *jis_code, char *ebc_code, short jis_code_len )
{
	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 || jis_code_len > 256 ){
		return(R_JISEBC_CHANGE_LENGTH_OVER);
	}

	/*�R�[���o�[�g���s--------------------------------------------------*/
	LSetMess();
	if( xTBConvertData( g_nDevId, 0, jis_code_len, jis_code ) != 0 ){
		return(R_JISEBC_CHANGE_LENGTH_OVER);
	}
	if( LPostMess( DIS_KEY_STOP ) != 0 ){
		return(R_JISEBC_CHANGE_LENGTH_OVER);
	}
	memcpy( ebc_code, seTBCV.abCnvData, seTBCV.nLength );
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	�i�h�r�|���d�a�b�R�[�h�ϊ�						*/
/*					:	JISEBC											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	JISEBC(char *, char *, short)			*/
/*	parameter		:	char *	�d�a�b�c�h�b�R�[�h�i�[�̈�				*/
/*					:	char *	�i�h�r�R�[�h�i�[�̈�					*/
/*					:	short	�ϊ��f�[�^�̒����i�ő�Q�T�U�o�C�g�j	*/
/*	return value	:	short	R_NORMAL					����I��	*/
/*					:			R_EBCJIS_CHANGE_LENGTH_OVER	�ϊ����s	*/
/************************************************************************/
short	EBCJIS( char  *ebc_code, char  *jis_code, short ebc_code_len )
{
	/*�I�[�v���`�F�b�N--------------------------------------------------*/
	if( g_nDevId < 0 || ebc_code_len > 256 ){
		return(R_EBCJIS_CHANGE_LENGTH_OVER);
	}

	/*�R�[���o�[�g���s--------------------------------------------------*/
	LSetMess();
	if( xTBConvertData( g_nDevId, 1, ebc_code_len, ebc_code ) ){
		return(R_EBCJIS_CHANGE_LENGTH_OVER);
	}
	if( LPostMess( DIS_KEY_STOP ) != 0 ){
		return(R_JISEBC_CHANGE_LENGTH_OVER);
	}
	memcpy( jis_code, seTBCV.abCnvData, seTBCV.nLength );
	return(R_NORMAL);
}

short	WINAPI	LSCOPE( short out_typ )
{
	return(R_NORMAL);
}
short	WINAPI	SNDTEN( char *text, short text_len,
							short block_len, short snd_typ )
{
	return(R_SNDTEN_PARAMETER_ERROR);
}
short	WINAPI	RECTEN( char *text_buff, short text_buff_siz,
							short block_len, short *text_len )
{
	return(R_RECTEN_PARAMETER_ERROR);
}

/************************************************************************/
/*	module name 	:	TRANS_B.DLL�̊J�n								*/
/*					:	DLL_OPEN										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DLL_OPEN()								*/
/*	parameter		:	nothing											*/
/*	return value	:	0:���� -1:�ُ�									*/
/************************************************************************/
short	DLL_OPEN( void )
{
	BOOL fWinNT;

	if(hInstDLL)  return(0);

	hInstDLL = LoadLibrary(g_szDLLName);


	fWinNT = TBIsWindowsNT();

	// ����M�ɍŒ���K�v�Ȋ֐�
	if( ! IMPORT_FUNCTION( hInstDLL, TBOpen, fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBOpen>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBIsExistFirmware , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBIsExistFirmware>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSetupEx , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBSetupEx>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConnectEx , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBConnectEx>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSendEOT , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBSendEOT>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSendDLEEOT , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBSendDLEEOT>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSendData , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBSendData>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBReset , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBReset>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBDisconnectLine , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBDisconnectLine>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if(	! IMPORT_FUNCTION( hInstDLL, TBReceiveData , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBReceiveData>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBClose , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBClose>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConvertData , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBConvertData>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConnectCancel , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBConnectCancel>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	// TRANS_B�̓������𗘗p����ꍇ�ɕK�v�Ȋ֐�
	if( ! IMPORT_FUNCTION( hInstDLL, TBConfigureDeviceDlg , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBConfigureDeviceDlg>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConfigureParamDlg , fWinNT ) ){
		MessageBox(GetFocus(), "�݂���Ȃ��֐�������܂��B",
				   "<TBConfigureParamDlg>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	return(0);
}

/************************************************************************/
/*	module name 	:	TRANS_B.DLL�̏I��								*/
/*					:	DLL_CLOSE										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DLL_CLOSE()								*/
/*	parameter		:	nothing											*/
/*	return value	:	nothing											*/
/************************************************************************/
short	DLL_CLOSE( void )
{

	if(hInstDLL != NULL)  FreeLibrary(hInstDLL);
	hInstDLL = (HINSTANCE)NULL;
	return(0);

}


