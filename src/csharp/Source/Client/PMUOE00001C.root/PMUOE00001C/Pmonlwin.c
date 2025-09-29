/************************************************************************/
/*	system			: パーツマン Ⅶシステム								*/
/*	file name		: TRANS_B 共通関数									*/
/*			 		: PMONLWIN.C										*/
/*----------------------------------------------------------------------*/
/* 20081121 立花裕輔 PM.NSに対応                                        */
/* 20091112 工藤恵優 MANTIS対応[14471]									*/
/*----------------------------------------------------------------------*/
/*				Copyright 2000 TSUBASA System Co., Ltd.					*/
/************************************************************************/

/*======================================================================*/
/* ＩＮＣＬＵＤＥ宣言													*/
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
/* ＤＥＦＩＮＥ定義														*/
/*======================================================================*/
#define		TBS_TEXT_MAX		2038	/*送受信可能なテキストの最大長*/

#define		DIS_ANSERTONE		0		/*アンサートーンなし*/
#define		ENA_ANSERTONE		1		/*アンサートーンあり*/

#define		TM_INIT_MODE		0		/*発信･着信初期値*/
#define		TM_CONN_MODE		1		/*自動着信*/
#define		TM_DIAL_MODE		2		/*自動発信*/

#define		TB_MES_FIRST		0		/* メッセージ設定 */
#define		TB_MES_NEXT			1		/* メッセージ取得 */

#define		CN_CONE_ENA			0		/* 回線接続状態 */
#define		CN_CONE_DIS			1		/* 回線切断状態 */

#define		CONNECT_AUTO		0		/* 自動着信 */
#define		CONNECT_MANUAL		1		/* 手動着信 */

#define		ENA_KEY_STOP		0		/*「ESC+CTRL+A」許可 */
#define		DIS_KEY_STOP		1		/*「ESC+CTRL+A」禁止 */

#define		ENA_KEY_CANC		2		/*「ESC+CTRL+A」許可 */

#define		LPOS_NG				-1		/* ＴＢエラー */
#define		LPOS_ESC			-2		/* 中断 */
#define		LPOS_ERR			-3		/* コマンド失敗 */

/*エラー詳細コード------------------------------------------------------*/
#define		ER_SETUP			0x01	/*Setupｺﾏﾝﾄﾞ未完了*/
#define		ER_CONNECT			0x02	/*Connect未完了*/
#define		ER_DISCONNECT		0x03	/*回線切断（ﾓﾃﾞﾑ･ｴﾗｰ）*/
#define		ER_TIME_TXT			0x04	/*ﾀｲﾑｱｳﾄ（応答送信後のﾃｷｽﾄ待ち）*/
#define		ER_TIME_ACK			0x05	/*ﾀｲﾑｱｳﾄ（呼び出しのﾀｲﾑｱｳﾄ又はﾃｷｽﾄ送信後の応答待ち）*/
#define		ER_DATA_CRC			0x06	/*ﾃﾞｰﾀ･ﾁｪｯｸ（CRCｴﾗｰ･再送ｴﾗｰ）*/
#define		ER_CHANGE			0x07	/*交互性ｴﾗｰ*/
#define		ER_CHG_ID			0x08	/*ID交換ｴﾗｰ*/
#define		ER_CD_ON			0x09	/*CD ON検出（送信要求時）*/
#define		ER_TIME_CTS			0x0a	/*CTS監視ﾀｲﾑｱｳﾄ*/
#define		ER_EOT_TXT			0x10	/*EOT受信（テキスト受信待ちの場合）*/
#define		ER_EOT_RES			0x11	/*EOT受信（テキスト送信に対する応答待ちの場合）*/
#define		ER_EOT_ENQ			0x12	/*EOT受信（呼出しENQに対する応答待ちの場合）*/
#define		ER_DLE_EOT			0x13	/*回線切断ﾒｯｾｰｼﾞ（DISC受信）*/
#define		ER_RVI				0x14	/*RVI受信（テキスト送信に対する応答待ちの場合）*/
#define		ER_CONTENTION		0x15	/*呼び出しにおいて、ｺﾝﾃﾝｼｮﾝ発生*/
#define		ER_NO_MESS			0x20	/*テキスト受信に対する未応答ﾒｯｾｰｼﾞなし*/
#define		ER_SND_FULL			0x21	/*送信ﾃｷｽﾄのﾊﾞｯﾌｧ･ﾌﾙ*/
#define		ER_DIAL				0x91	/*自動ダイヤル失敗*/
#define		ER_COMMAND			0x92	/*コマンドエラー*/
#define		ER_MODEM_BUSY		0x95	/*話中*/
#define		ER_MODEM_NO_TONE	0x96	/*無応答*/

/*状態コード------------------------------------------------------------*/
#define		ST_SETUP			0x00	/*初期状態、Setupｺﾏﾝﾄﾞ待ち*/
#define		ST_CONNECT			0x01	/*Setupｺﾏﾝﾄﾞ完了し､Connectｺﾏﾝﾄﾞ待ち*/
#define		ST_CONNECT_END		0x02	/*Connectｺﾏﾝﾄﾞ完了*/
#define		ST_DISCONNECT		0x03	/*回線切断ﾒｯｾｰｼﾞ送出､Disconnect lineｺﾏﾝﾄﾞ待ち*/
#define		ST_RESET			0x04	/*回線切断､Resetｺﾏﾝﾄﾞ待ち*/
#define		ST_SND_NO_DATA		0x10	/*送信中（未送信ﾃﾞｰﾀなし）*/
#define		ST_SND_DATA			0x11	/*送信中（未送信ﾃﾞｰﾀあり）*/
#define		ST_SND_DISABLE		0x12	/*送信中（回線ｴﾗｰ発生）*/
#define		ST_REC_NO_DATA		0x20	/*受信中（受信ﾃﾞｰﾀなし）*/
#define		ST_REC_DATA			0x21	/*受信中（受信ﾃﾞｰﾀあり）*/
#define		ST_REC_FULL			0x22	/*受信中（受信ﾊﾞｯﾌｧ･ﾌﾙ､WACK送出中）*/
#define		ST_REC_DISABLE		0x23	/*受信中（回線ｴﾗｰ発生）*/

// Windows95用DLLのエクスポート名
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

// WindowsNT用DLLのエクスポート名
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

// Windowsのバージョンの判別
#define TBIsWindowsNT() \
	( ( BOOL )( GetVersion( ) < 0x80000000 ) )

// 各APIのプロトタイプ
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

//それぞれの型の関数ポインタの宣言///////////////
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
/* グローバル変数宣言													*/
/*======================================================================*/
HINSTANCE _hinst;
char *rtrim( char * );

static	short	cnnectMode = TM_INIT_MODE;	/* 接続モード（発信･着信） */
static	int		g_nDevId = -1;				/* 通信デバイス識別子 */
static	short	conManual;					/* 自動着信／手動着信設定 */
static	short	atone;						/* アンサートーンの有無設定 */
static	short	awTimerT8;					/* ID交換監視ﾀｲﾏｰ(送信側) */

/*TRANSB.DLLがポストするメッセージのLPARAM値----------------------------*/
static	TBLPARAM*	pTBLPARAM;				/* ステータスレスポンス */
static	TBSTS	FAR*	lpTBSTS;			/* リクエストレスポンス */
static	TBDT	FAR*	lpTBDT;				/* データレスポンス */
static	TBCV	FAR*	lpTBCV;				/* コンバートレスポンス */

static	TBLPARAM		seTBLPARAM;			/* ステータスレスポンス */
static	TBSTS			seTBSTS;			/* リクエストレスポンス */
static	TBDT			seTBDT;				/* データレスポンス */
static	TBCV			seTBCV;				/* コンバートレスポンス */

static	TBSETUP			lpTBSETUP;			/* セットアップ構造体 */
static	TBCONNECT		lpTBCONNECT;		/* 回線接続構造体 */

static	char	g_szDeviceName[128];		/* 通信デバイス名 */
static	char	*g_szAppName = "TBFWSENDI";	/* クラス名 */
static	char	g_szDLLName[257];			/* 通信ＤＬＬ名 */
static	UINT	iTBMessage = 0;				/* メッセージ */
static	HWND	TBhwnd;						/* ウィンドウハンドル */
static	short	TBWndProcMess=TB_MES_NEXT;	/* メッセージ設定 */
static	short	TBWndProcRet;				/* メッセージ戻値 */

static	short	RecRtryLoop;				/* 受信処理のｽﾃｰﾀｽﾚｽﾎﾟﾝｽで０が設定された場合の対策 */
static	HINSTANCE	hInstDLL = (HINSTANCE)NULL;

static	short	DLL_OPEN(void);
static	short	DLL_CLOSE(void);

/************************************************************************/
/*	module name 	:	ステータスの取得								*/
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
			/*ステータスレスポンス--------------------------------------*/
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
			/*データレスポンス------------------------------------------*/
			case	DT_RESPONSE:
				lpTBDT = ( TBDT FAR* )GlobalLock( (HWND)lParam );
				seTBDT.bType   = lpTBDT->bType;
				seTBDT.nLength = lpTBDT->nLength;
				memcpy( seTBDT.abRecvData, lpTBDT->abRecvData, seTBDT.nLength );
				GlobalUnlock( (HWND)lParam );
				TBWndProcMess = TB_MES_NEXT;
				TBWndProcRet = 0;
				break;
			/*コンバートレスポンス--------------------------------------*/
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
			/*TBFWメッセージの登録*/
			if( (iTBMessage = RegisterWindowMessage( TB_MESSAGE )) == 0 ){
				return -1L;
			}
			return 0L;
	}
	return( DefWindowProc( hwnd, msg, wParam, lParam ) );
}
/************************************************************************/
/*	module name 	:	イベント設定									*/
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
/*	module name 	:	イベント開始									*/
/*					:	LPostMess										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LPostMess(short)						*/
/*	parameter		:	short	ENA_KEY_STOP		「ESC+CTRL+A」許可	*/
/*					:			DIS_KEY_STOP		「ESC+CTRL+A」禁止	*/
/*					:			※ ENA_KEY_CANC		「ESC+CTRL+A」許可	*/
/*					:				(回線接続途中での処理中断をｻﾎﾟｰﾄ) 	*/
/*	return value	:	short	0					成功				*/
/*					:			LPOS_NG				失敗				*/
/*					:			LPOS_ESC			中断				*/
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
/*	module name 	:	ＴＢＳＥＴＵＰ構造体の初期化					*/
/*					:	LSetUpIni										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LSetupIni()								*/
/*	parameter		:	nothing											*/
/*	return value	:	short	0					成功				*/
/*					:			LPOS_NG				失敗				*/
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

	/*通信デバイス名の取得----------------------------------------------*/
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


 	/*ＤＬＬ名の取得----------------------------------------------------*/
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

	/*回線種別の取得----------------------------------------------------*/
	if( GetPrivateProfileString("OASIS", "LINE_TYPE", "",
				tbfwSet, sizeof(tbfwSet), WindowDir) == 0){
		strcpy( tbfwSet, "PB" );
	}
	if( strcmp(tbfwSet, "DP10") == 0 )		lpTBSETUP.fLineType=TBS_DP10;
	else if(strcmp(tbfwSet, "DP20") == 0)	lpTBSETUP.fLineType=TBS_DP20;
	else 									lpTBSETUP.fLineType=TBS_PB;

	/*アンサ－トーン検出の有無------------------------------------------*/
	atone = DIS_ANSERTONE;
	if( GetPrivateProfileString("OASIS", "ANSERTONE", "",
				tbfwSet, sizeof(tbfwSet), WindowDir) != 0){
		if( atoi(tbfwSet) == 1 )	atone = ENA_ANSERTONE;
	}

	/*自動着信／手動着信の設定------------------------------------------*/
	if( GetPrivateProfileString("OASIS", "NCU_TYPE", "",
				tbfwSet, sizeof(tbfwSet), WindowDir) == 0){
		strcpy( tbfwSet, "AUTO" );
	}
	if( strcmp( tbfwSet, "MANUAL" ) == 0 )	conManual = CONNECT_MANUAL;
	else									conManual = CONNECT_AUTO;

	/*タイマー値設定----------------------------------------------------*/
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

	/*カウンタ値設定----------------------------------------------------*/
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

	/*TBSETUP構造体の初期化---------------------------------------------*/
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
/*	module name 	:	回線オープン									*/
/*					:	L_LOPEN 										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	L_LOPEN(short)							*/
/*	parameter		:	short	BSC1_PRIMARY		専用回線/優先局		*/
/*					:			BSC2_PRIMARY		公衆回線/優先局		*/
/*					:			BSC1_SECONDARY		専用回線/非優先局	*/
/*					:			BSC2_SECONDARY		公衆回線/非優先局	*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_LOPEN_MODEM_ERROR		モデムエラー	*/
/*					:			R_LOPEN_DUPLICATE_OPEN	二重オープン	*/
/************************************************************************/
short	WINAPI L_LOPEN( short opn_typ )
{
	WNDCLASS	wc;			/* Window Class */
	short	opn_cnt;

	/*二重オープンチェック----------------------------------------------*/
	if( g_nDevId >= 0 ){
		return(R_LOPEN_DUPLICATE_OPEN);
	}

	/*ウィンドウハンドルの作成------------------------------------------*/
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

	/*ＤＬＬオープン----------------------------------------------------*/
	if(DLL_OPEN() != 0){
		DLL_CLOSE();
		return(R_LOPEN_MODEM_ERROR);
	}

	/*オープン----------------------------------------------------------*/
	for( opn_cnt=0; opn_cnt<10; opn_cnt++ ){
		if( (g_nDevId = xTBOpen( TBhwnd, g_szDeviceName )) >= 0 )	break;
	}
	if( g_nDevId < 0 )	return(R_LOPEN_MODEM_ERROR);

	/*ＢＳＣ制御プログラムの存在検査------------------------------------*/
	// 20081121 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	//if(xTBIsExistFirmware(g_nDevId) != 1)	return(R_LOPEN_MODEM_ERROR);
	// 20081121 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

	/*呼局設定----------------------------------------------------------*/
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
/*	module name 	:	回線クローズ									*/
/*					:	L_LCLOSE										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LCLOSE()								*/
/*	parameter		:	nothing											*/
/*	return value	:	short	R_NORMAL			正常終了			*/
/************************************************************************/
short  WINAPI L_LCLOSE( void )
{
	short	ret;

	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )	return(R_NORMAL);
	DestroyWindow(TBhwnd);
	cnnectMode = TM_INIT_MODE;
	ret = xTBClose(g_nDevId);
	g_nDevId = -1;

	/*ＤＬＬクローズ----------------------------------------------------*/
	DLL_CLOSE();
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	ＩＤ交換設定									*/
/*					:	SETID											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	SETID(char *, char *)					*/
/*	parameter		:	char *	送信用ＩＤ								*/
/*					:	char *	受信用ＩＤ								*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_SETID_ID_SET_ERROR	ＩＤ設定誤り	*/
/*					:			R_SETID_NOT_OPEN		未オープンエラー*/
/************************************************************************/
short	WINAPI	SETID( char *send_id, char *recv_id )
{
	char	snd_ebc[50];
	char	rec_ebc[50];

	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )	return(R_SETID_NOT_OPEN);

	/*ＩＤの設定--------------------------------------------------------*/
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
/*	module name 	:	ＥＯＴ送出後、回線切断（公衆回線のみ）			*/
/*					:	DISCONNECT										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DISCONNECT()							*/
/*	parameter		:	nothing											*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_DISCONNECT_CANCEL		ＩＤ設定誤り	*/
/*					:			R_DISCONNECT_NOT_OPEN	未オープンエラー*/
/************************************************************************/
short	WINAPI	DISCONNECT( void )
{
	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )					return(R_DISCONNECT_NOT_OPEN);

	/*ＤＩＳＣの発行----------------------------------------------------*/
	LSetMess();
	if( xTBSendDLEEOT(g_nDevId) == 0 )	LPostMess( DIS_KEY_STOP );

	/*回線の切断--------------------------------------------------------*/
	LSetMess();
	if(xTBDisconnectLine(g_nDevId) == 0)	LPostMess( DIS_KEY_STOP );
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	データリンクの確立								*/
/*					:	CONCT											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	CONCT(short)							*/
/*	parameter		:	short	TM_DIAL_MODE			自動発信		*/
/*					:			TM_CONN_MODE			自動着信		*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			LPOS_NG					失敗			*/
/*					:			LPOS_ESC				中断			*/
/*					:			LPOS_ERR				コマンドエラー	*/
/************************************************************************/
short	CONCT(short mode)
{
	/*リセット----------------------------------------------------------*/
	LSetMess();
	if( xTBReset(g_nDevId) != 0 )			return(R_LOPEN_MODEM_ERROR);
	if( LPostMess( DIS_KEY_STOP ) != 0 )	return(R_LOPEN_MODEM_ERROR);

	/*セットアップ------------------------------------------------------*/
	LSetMess();
	if( xTBSetupEx( g_nDevId, &lpTBSETUP ) != 0 )	return(LPOS_ERR);
	if( LPostMess( DIS_KEY_STOP ) != 0 )			return(LPOS_NG);

	/*自動発信設定------------------------------------------------------*/
	if( (cnnectMode = mode) == TM_DIAL_MODE ){
		lpTBCONNECT.fNcuType = TBC_NCU_CALL;
		lpTBCONNECT.fCaller = TBC_CALLER;
	/*手動着信設定------------------------------------------------------*/
	}else{
		lpTBCONNECT.bTelNoLength = 0;
		memset( lpTBCONNECT.abTelNo, 0x00, sizeof(lpTBCONNECT.abTelNo) );
		if( conManual == CONNECT_MANUAL ){
			lpTBCONNECT.fNcuType = TBC_NCU_CALL;
			lpTBCONNECT.fCaller = TBC_ANSER;
		}else{
	/*自動着信設定------------------------------------------------------*/
			lpTBCONNECT.fNcuType = TBC_NCU_ANSER;
			lpTBCONNECT.fCaller = TBC_ANSER;
		}
	}

	/*接続処理----------------------------------------------------------*/
	LSetMess();
	if(xTBConnectEx( g_nDevId, &lpTBCONNECT ) != 0)	return(LPOS_ERR);
	return( LPostMess( ENA_KEY_CANC ) );
}
/************************************************************************/
/*	module name 	:	自動ダイヤリング								*/
/*					:	DIAL											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DIAL(short, char *)						*/
/*	parameter		:	short	REGULAR_MODEM		Ｎ付きモデム		*/
/*					:			IRREGULAR_MODEM		Ｎ無しモデム		*/
/*					:													*/
/*					:	char *	ダイヤル番号格納（６３桁以内）			*/
/*					:													*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_DIAL_CANCEL			キャンセル		*/
/*					:			R_DIAL_NOT_OPEN			未オープンエラー*/
/*					:			R_DIAL_WAIT_DIAL		ダイヤル不可能	*/
/*					:			R_DIAL_DIAL_NO_ERROR	ダイヤル番号ｴﾗｰ	*/
/*					:			R_DIAL_BSC_CHECK		モデム障害		*/
/*					:			R_DIAL_BUSY_TALKING		話中			*/
/*					:			R_DIAL_NO_ANSWER		相手が出ない	*/
/************************************************************************/
short	WINAPI	DIAL( short tel_typ, char  *tel_no )
{
	short	ret;

	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )	return(R_DIAL_NOT_OPEN);

	/*ダイヤル番号の格納------------------------------------------------*/
	lpTBCONNECT.bTelNoLength = strlen(tel_no);
	if( lpTBCONNECT.bTelNoLength > 63 )	return(R_DIAL_DIAL_NO_ERROR);
	memset( lpTBCONNECT.abTelNo, 0x00, sizeof(lpTBCONNECT.abTelNo) );	// ADD 20091112 MANTIS対応[14471] ダイヤル番号の格納バッファがクリアされていない
	memcpy( lpTBCONNECT.abTelNo, tel_no, lpTBCONNECT.bTelNoLength );
	rtrim( lpTBCONNECT.abTelNo );
	if( atone == ENA_ANSERTONE )	strcat( lpTBCONNECT.abTelNo, "F" );
	lpTBCONNECT.bTelNoLength = strlen(lpTBCONNECT.abTelNo);
	lpTBSETUP.awTimer[6] = awTimerT8;

	/*データリンクの確立------------------------------------------------*/
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
/*	module name 	:	テキストを送信									*/
/*					:	SNDI											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	SNDI(char *, short, short)				*/
/*	parameter		:	char *	送信テキストデータ						*/
/*					:	short	送信テキスト長（０～２０３８）			*/
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
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_SNDI_OPERATOR_STOP	オペレータ中断	*/
/*					:			R_SNDI_NOT_OPEN 		未オープンエラー*/
/*					:			R_SNDI_BSC_CHECK		通信アダプタ障害*/
/*					:			R_SNDI_GET_EOT			ＥＯＴ受信		*/
/*					:			R_SNDI_GET_DISK 		ＤＩＳＣ受信	*/
/*					:			R_SNDI_TIMEOUT			タイムアウト	*/
/*					:			R_SNDI_DATA_ERROR		ACK交互性エラー	*/
/*					:			R_SNDI_GET_RVI			ＲＶＩ受信エラー*/
/*					:			R_SNDI_CONTENTION		コンテンション	*/
/*					:			R_SNDI_WACK_COUNT_OVER	WACKｶｳﾝﾄ･ｵｰﾊﾞｰ	*/
/*					:			R_SNDI_PARAMETER_ERROR	ﾊﾟﾗﾒｰﾀ設定ｴﾗｰ	*/
/*					:			R_SNDI_ID_CHANGE_ERROR	ID交換ｴﾗｰ		*/
/************************************************************************/
short	WINAPI	SNDI( char *text, short text_len, short snd_typ  )
{
	short	ret;
	UINT	type;
	UINT	cvt = 0;

	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )					return(R_SNDI_NOT_OPEN);

	/*送信サイズ･チェック-----------------------------------------------*/
	if( text_len > TBS_TEXT_MAX )		return(R_SNDI_PARAMETER_ERROR);

	/*送受信テキスト形式の宣言------------------------------------------*/
	switch( snd_typ ){
		case	S_ETB_CHANGE:
			cvt = 1;	/*JIS→EBCDIC*/
			type = TB_STXETB;
			break;
		case	S_ETX_CHANGE:
			cvt = 1;	/*JIS→EBCDIC*/
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
			cvt = 1;	/*JIS→EBCDIC*/
			type = TB_SOHETB;
			break;
		case	S_SOH_ETX_CHANGE:
			cvt = 1;	/*JIS→EBCDIC*/
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

	/*送信処理実行------------------------------------------------------*/
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
					ret = R_SNDI_GET_EOT;			/* ＥＯＴ受信 */
					break;
				case	ER_DLE_EOT:
					ret = R_SNDI_GET_DISK;			/* ＤＩＳＣ受信 */
					break;
				case	ER_TIME_TXT:
				case	ER_TIME_ACK:
				case	ER_TIME_CTS:
					ret = R_SNDI_TIMEOUT;			/* タイムアウト */
					break;
				case	ER_CHANGE:
					ret = R_SNDI_DATA_ERROR;		/* ACK交互性エラー */
					break;
				case	ER_RVI:
					ret = R_SNDI_GET_RVI;			/* ＲＶＩ受信エラー */
					LSetMess();
					if( xTBReceiveData( g_nDevId, 0 ) != 0 )	break;
					if( (ret = LPostMess( ENA_KEY_STOP )) != 0 )	break;
					ret = R_NORMAL;
					break;
				case	ER_CONTENTION:
					ret = R_SNDI_CONTENTION;		/* コンテンション */
					break;
				case	ER_COMMAND:
					ret = R_SNDI_PARAMETER_ERROR;	/* ﾊﾟﾗﾒｰﾀ設定ｴﾗｰ */
					break;
				case	ER_CHG_ID:
					ret = R_SNDI_ID_CHANGE_ERROR;	/* ID交換ｴﾗｰ */
					break;
				default:
					ret = R_SNDI_BSC_CHECK;			/* 通信アダプタ障害 */
					break;
			}
		}else if( ret == LPOS_ESC ){
			ret = R_SNDI_OPERATOR_STOP;				/* オペレータ中断 */
		}
		break;
	}
	return(ret);
}
/************************************************************************/
/*	module name 	:	テキストを送信後、ＥＯＴ送出					*/
/*					:	SNDIR											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	SNDIR(char *, short, short)				*/
/*	parameter		:	char *	送信テキストデータ						*/
/*					:	short	送信テキスト長（０～２０４８）			*/
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
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_SNDIR_OPERATOR_STOP	オペレータ中断	*/
/*					:			R_SNDIR_NOT_OPEN		未オープンエラー*/
/*					:			R_SNDIR_BSC_CHECK		通信アダプタ障害*/
/*					:			R_SNDIR_GET_EOT 		ＥＯＴ受信		*/
/*					:			R_SNDIR_GET_DISK		ＤＩＳＣ受信	*/
/*					:			R_SNDIR_TIMEOUT 		タイムアウト	*/
/*					:			R_SNDIR_DATA_ERROR		ACK交互性エラー	*/
/*					:			R_SNDIR_GET_RVI 		ＲＶＩ受信エラー*/
/*					:			R_SNDIR_CONTENTION		コンテンション	*/
/*					:			R_SNDIR_WACK_COUNT_OVER WACKｶｳﾝﾄ･ｵｰﾊﾞｰ	*/
/*					:			R_SNDIR_PARAMETER_ERROR ﾊﾟﾗﾒｰﾀ設定ｴﾗｰ	*/
/*					:			R_SNDIR_ID_CHANGE_ERROR	ID交換ｴﾗｰ		*/
/************************************************************************/
short	WINAPI	SNDIR( char *text, short text_len, short snd_typ )
{
	short	ret;

	/*送信処理実行------------------------------------------------------*/
	if( (ret = SNDI( text, text_len, snd_typ)) !=  R_NORMAL ){
		return(ret);
	}

	/*ＥＯＴの発行------------------------------------------------------*/
	return(LRESET());
}
/************************************************************************/
/*	module name 	:	相手システムへＥＯＴを送信						*/
/*					:	LRESET											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LRESET()								*/
/*	parameter		:	nothing											*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_RESET_OPERATOR_STOP	オペレータ中断	*/
/*					:			R_RESET_NOT_OPEN		未オープンエラー*/
/*					:			R_RESET_BSC_CHECK		通信アダプタ障害*/
/************************************************************************/
short	WINAPI	LRESET( void )
{
short	ret;

	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )						return(R_RESET_NOT_OPEN);

	/*ＥＯＴの発行------------------------------------------------------*/
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
/*	module name 	:	受信ステータス設定								*/
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
/*	module name 	:	テキストを受信									*/
/*					:	REC												*/
/*----------------------------------------------------------------------*/
/*	style			:	short	REC(char *, short, short *, short *)	*/
/*	parameter		:	char *	受信バッファ							*/
/*					:	short	受信バッファ長							*/
/*					:	short *	受信したテキストの長さ					*/
/*					:	short *	受信したテキストの形式					*/
/*					:			R_ETB				STX-ETB				*/
/*					:			R_ETX				STX-ETX				*/
/*					:			R_DLE_ETB			DLE,STX-DLE,ETB		*/
/*					:			R_DLE_ETX			DLE,STX-DLE,ETX		*/
/*					:			R_SOH_ETB			SOH-STX-ETB			*/
/*					:			R_SOH_ETX			SOH-STX-ETX			*/
/*					:			R_SOH_DLE_ETB		SOH-DLE,STX-DLE,ETB	*/
/*					:			R_SOH_DLE_ETX		SOH-DLE,STX-DLE,ETX	*/
/*					:													*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_REC_OPERATOR_STOP		オペレータ中断	*/
/*					:			R_REC_NOT_OPEN		  	未オープンエラー*/
/*					:			R_REC_BSC_CHECK 	  	通信アダプタ障害*/
/*					:			R_REC_GET_EOT		  	ＥＯＴ受信		*/
/*					:			R_REC_GET_DISK		  	ＤＩＳＣ受信	*/
/*					:			R_REC_TIMEOUT		  	タイムアウト	*/
/*					:			R_REC_DATA_ERROR	  	BCC再送エラー	*/
/*					:			R_REC_PARAMETER_ERROR 	ﾊﾟﾗﾒｰﾀ設定ｴﾗｰ	*/
/*					:			R_REC_RECV_LENGTH_OVER	受信ﾃｷｽﾄｵｰﾊﾞｰ	*/
/*					:			R_REC_ID_CHANGE_ERROR	ID交換ｴﾗｰ		*/
/************************************************************************/
short	WINAPI	REC( char *text_buff, short text_buff_siz,
								short *block_len, short *text_len )
{
	short	size;
	short	ret;
	short	recFlg = 0;

	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 )						return(R_REC_NOT_OPEN);

	/*自動着信----------------------------------------------------------*/
	if( cnnectMode == TM_CONN_MODE ){
		switch( CONCT( TM_CONN_MODE ) ){
			case	LPOS_NG:	return( REC_ERRMES() );
			case	LPOS_ESC:	return(R_REC_OPERATOR_STOP);
			case	LPOS_ERR:	return(R_REC_BSC_CHECK);
		}
		cnnectMode = TM_INIT_MODE;
		recFlg = 1;
	}

	/*受信処理----------------------------------------------------------*/
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
	*text_len  = seTBDT.bType;	/*送受信テキスト形式の設定*/
	return(R_NORMAL);
}
/************************************************************************/
/*	module name 	:	回線制御ブロックの内容読み取り					*/
/*					:	LCBR											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LCBR(short)								*/
/*	parameter		:	short	領域番号（0～20）						*/
/*	return value	:	short	0～32767				参照値			*/
/*					:			R_LCBR_REGION_NO_ERROR	参照失敗		*/
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
/*	module name 	:	回線制御ブロックの内容を更新					*/
/*					:	LCBW											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	LCBW(short, short)						*/
/*	parameter		:	short	領域番号（0～20）						*/
/*					:	short	指定値									*/
/*	return value	:	short	R_NORMAL				正常終了		*/
/*					:			R_LCBW_REGION_NO_ERROR	更新失敗		*/
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
/*	module name 	:	受信ﾃｷｽﾄのｺｰﾄﾞ変換指定							*/
/*					:	STCGCD											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	STCGCD(short)							*/
/*	parameter		:	short	指定値									*/
/*	return value	:	nothing											*/
/************************************************************************/
void  WINAPI	STCGCD( short chg_flg )
{
	LCBW( RCO_CHANGE_CODE, chg_flg );
}
/************************************************************************/
/*	module name 	:	ＪＩＳ－＞ＥＢＣコード変換						*/
/*					:	JISEBC											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	JISEBC(char *, char *, short)			*/
/*	parameter		:	char *	ＪＩＳコード格納領域					*/
/*					:	char *	ＥＢＣＤＩＣコード格納領域				*/
/*					:	short	変換データの長さ（最大２５６バイト）	*/
/*	return value	:	short	R_NORMAL					正常終了	*/
/*					:			R_JISEBC_CHANGE_LENGTH_OVER	変換失敗	*/
/************************************************************************/
short	JISEBC( char  *jis_code, char *ebc_code, short jis_code_len )
{
	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 || jis_code_len > 256 ){
		return(R_JISEBC_CHANGE_LENGTH_OVER);
	}

	/*コーンバート実行--------------------------------------------------*/
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
/*	module name 	:	ＪＩＳ－＞ＥＢＣコード変換						*/
/*					:	JISEBC											*/
/*----------------------------------------------------------------------*/
/*	style			:	short	JISEBC(char *, char *, short)			*/
/*	parameter		:	char *	ＥＢＣＤＩＣコード格納領域				*/
/*					:	char *	ＪＩＳコード格納領域					*/
/*					:	short	変換データの長さ（最大２５６バイト）	*/
/*	return value	:	short	R_NORMAL					正常終了	*/
/*					:			R_EBCJIS_CHANGE_LENGTH_OVER	変換失敗	*/
/************************************************************************/
short	EBCJIS( char  *ebc_code, char  *jis_code, short ebc_code_len )
{
	/*オープンチェック--------------------------------------------------*/
	if( g_nDevId < 0 || ebc_code_len > 256 ){
		return(R_EBCJIS_CHANGE_LENGTH_OVER);
	}

	/*コーンバート実行--------------------------------------------------*/
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
/*	module name 	:	TRANS_B.DLLの開始								*/
/*					:	DLL_OPEN										*/
/*----------------------------------------------------------------------*/
/*	style			:	short	DLL_OPEN()								*/
/*	parameter		:	nothing											*/
/*	return value	:	0:正常 -1:異常									*/
/************************************************************************/
short	DLL_OPEN( void )
{
	BOOL fWinNT;

	if(hInstDLL)  return(0);

	hInstDLL = LoadLibrary(g_szDLLName);


	fWinNT = TBIsWindowsNT();

	// 送受信に最低限必要な関数
	if( ! IMPORT_FUNCTION( hInstDLL, TBOpen, fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBOpen>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBIsExistFirmware , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBIsExistFirmware>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSetupEx , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBSetupEx>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConnectEx , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBConnectEx>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSendEOT , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBSendEOT>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSendDLEEOT , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBSendDLEEOT>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBSendData , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBSendData>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBReset , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBReset>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBDisconnectLine , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBDisconnectLine>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if(	! IMPORT_FUNCTION( hInstDLL, TBReceiveData , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBReceiveData>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBClose , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBClose>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConvertData , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBConvertData>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConnectCancel , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBConnectCancel>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	// TRANS_Bの内部情報を利用する場合に必要な関数
	if( ! IMPORT_FUNCTION( hInstDLL, TBConfigureDeviceDlg , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBConfigureDeviceDlg>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	if( ! IMPORT_FUNCTION( hInstDLL, TBConfigureParamDlg , fWinNT ) ){
		MessageBox(GetFocus(), "みつからない関数があります。",
				   "<TBConfigureParamDlg>", MB_OK | MB_ICONHAND);
		return(-1);
	}
	return(0);
}

/************************************************************************/
/*	module name 	:	TRANS_B.DLLの終了								*/
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


