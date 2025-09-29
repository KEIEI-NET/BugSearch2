////////********************************************************************// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信アクセスクラス
// プログラム概要   : ＵＯＥ送受信を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : PM1008 明治UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 堀田
// 作 成 日  2010/06/09  修正内容 : WebResponseをByteにセットする際、品番に
//                                  NULLがセットされないように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI佐々木 貴英
// 作 成 日  2012/10/03  修正内容 : タイムアウトエラーメッセージ不正対応
//----------------------------------------------------------------------------//
// 管理番号  11001634-00  作成担当 : 鄧潘ハン
// 作 成 日  K2014/05/26  修正内容 : 自動発注エラーメッセージを出さないように修正とエラーログの更新
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
using Broadleaf.Application.Resources;// ADD K2014/05/26 鄧潘ハン Redmine 42571

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送受信アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送受信アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 高峰 PM1008 明治UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpDate</br>
    /// <br>2012/10/03 FSI佐々木 貴英 タイムアウトエラーメッセージ不正対応</br>
    /// <br>Update Note: K2014/05/26 鄧潘ハン</br>
    /// <br>             自動発注エラーメッセージを出さないように修正とエラーログの更新</br>
    /// </remarks>
	public partial class UoeSndRcvAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndRcvAcs()
		{
			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//操作履歴ログアクセスクラス
			_uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();

            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members

		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//操作履歴ログアクセスクラス
		private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;

		//ＵＯＥ送信ヘッダークラス
		private UoeSndHed _uoeSndHed = new UoeSndHed();

		//ＵＯＥ送信明細クラス
		private UoeSndDtl _uoeSndDtl = new UoeSndDtl();

		//ＵＯＥ受信ヘッダークラス
		private UoeRecHed _uoeRecHed = new UoeRecHed();

		//ＵＯＥ発注先マスタクラス
        private UOESupplier _uOESupplier = new UOESupplier();

        //仕入受信モード true:仕入受信処理 false:通常処理
        private bool _processStockSlipDtRecvDiv = false;

		private int _setid_flg;			//ＩＤ交換フラグ
		private int _businessCode;		//業務区分 1:発注 2:見積 3:在庫
		private Int16 _lengthSndRcvBlk;	//送受信ブロック長
        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
        //メッセージセット関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		# region 業務区分
		private const int HATSU = (int)EnumUoeConst.TerminalDiv.ct_Order;		// 業務区分＝発注      		   
		private const int MITSU = (int)EnumUoeConst.TerminalDiv.ct_Estmt;		// 業務区分＝見積      		   
		private const int ZAIKO = (int)EnumUoeConst.TerminalDiv.ct_Stock;		// 業務区分＝在庫      		   
		# endregion

		# region 送受信レコード定義
		private const int SR_BLK = 256;			//送受信レコードブロック＜共通＞
		private const int SR_BLK_HONDA = 255;	//送受信レコードブロック＜ホンダ専用＞
		private const int KAI_SND = 69;			//送信TXT長 　業務区分＝開局
        private const int RECBUF_MAXSIZE = 5120;//受信バッファ最大値

		# endregion

		# region コンバートタイプ
		private const int JIS_EBC_CNV = 1;	// JIS ---> EBC  CNV TYPE	   
		private const int EBC_JIS_CNV = 2;	// EBC ---> JIS  CNV TYPE	   
		# endregion

		# region メッセージをＵＩに表示するフィールド名称
		private const int P_HED = 0;
		private const int P_MSG = 1;
		private const int P_GUIDE01 = 2;
		# endregion

		# region 通信パラメータ定数
		//**************************************************************
		//           COMMON										            
        //**************************************************************
		private const Int16 OK	 = 0;	// 関数の戻り値及び判別に使用する  
		private const Int16 NG	 = -1;	// 								   
		private const Int16 NO	 = -1;	// 								   
		private const Int16 OFF	 = 0;	// フラグ、変数の ON OFFに使用する 
		private const Int16 ON	 = 1;	// 								   
		private const Int16 RESET= 0;	// フラグ、変数の SET RESETに使用  
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

		# region エラーメッセージ
		//エラーメッセージ
		private const string MESSAGE_ERROR01 = "送信編集データが存在しません。";
		private const string MESSAGE_ERROR02 = "発注先マスタに存在しません。";
		private const string MESSAGE_ERROR03 = "ダイヤリング失敗！！、リダイヤルしますか？";
		private const string MESSAGE_ERROR04 = "相手先がでません！！、リダイヤルしますか？";
		private const string MESSAGE_ERROR05 = "DIAL 回線又はモデムが異常です､処理を中止します";
		private const string MESSAGE_ERROR06 = "自動ダイヤル　正常終了！！";
		private const string MESSAGE_ERROR07 = "Y：再実行　N:終了";
		# endregion

		# region UoeLoadLibrary()の設定・解除
		//UoeLoadLibrary()の設定・解除
		private const int ctUoeLoadLibraryModeSet = 0;	//設定
		private const int ctUoeLoadLibraryModeRset = 1;	//解除
		# endregion

		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate

        # region 画面関係
        //メッセージクリア
        //internal delegate void msg_psfclrEventHandler(int fld);
        public delegate void msg_psfclrEventHandler(int fld);

        //メッセージ表示
        public delegate void msg_pssputEventHandler(int fld, string text);
        # endregion

        # region ＢＳＣ通信
        // ＢＳＣ通信
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
		// イベント
		// ===================================================================================== //
		# region Event
        //メッセージクリア
        public event msg_psfclrEventHandler _msg_psfclr;

        //メッセージ表示
        public event msg_pssputEventHandler _msg_pssput;
        # endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		# region ＵＯＥ送信ヘッダークラス
		/// <summary>
		/// ＵＯＥ送信ヘッダークラス
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

		# region ＵＯＥ受信ヘッダークラス
		/// <summary>
		/// ＵＯＥ受信ヘッダークラス
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

		# region ＵＯＥ発注先マスタクラス
		/// <summary>
		/// ＵＯＥ発注先マスタクラス
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
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region ＵＯＥ送受信
		/// <summary>
		/// ＵＯＥ送受信
		/// </summary>
		/// <param name="para"></param>
		/// <param name="recHed"></param>
        /// <param name="processStockSlipDtRecvDiv"></param>
        /// <param name="message"></param>
		/// <returns></returns>
        public int UoeSndRcv(UoeSndHed para, out UoeRecHed recHed, bool processStockSlipDtRecvDiv, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			recHed = new UoeRecHed();
            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
            //フタバUSB専用:Option.ON
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                //メッセージを取得
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            }
            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

			try
			{
                //仕入受信モードの設定
                _processStockSlipDtRecvDiv = processStockSlipDtRecvDiv;

				//ＵＯＥ送受信条件抽出クラスの保存
				_uoeSndHed = para;

				//業務区分 1:発注 2:見積 3:在庫
				_businessCode = para.BusinessCode;

				//送受信ブロック長の取得
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
				//発注先マスタの取得
				else if ((_uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(_uoeSndHed.UOESupplierCd)) == null)
				{
					status = -1;
					message = MESSAGE_ERROR02;
				}
				//ＵＯＥ送受信メイン
				else
				{
					//UoeLoadLibraryの設定
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
                        // 通信アセンブリIDが優良UOE Webの場合、HTTP通信を行う
                        if (IsOtherMakerUOEWeb(_uOESupplier.CommAssemblyId))
                        {
                            // 次のメソッド呼出しで以下の処理を行う
                            // ①_uoeSndHed(送信電文)を送信SOAPメッセージに変換
                            // ②送信SOAPメッセージをHTTP通信
                            // ③HTTP通信のレスポンス(受信SOAPメッセージ)を_uoeRecHed(受信電文)に変換
                            IUOEWebClient webClient = UOEWebClientFactory.Create(_uOESupplier);
                            status = webClient.SendAndReceive(
                                _uoeSndHed,                  // 送信電文データ
                                processStockSlipDtRecvDiv,   // 仕入受信処理フラグ
                                out _uoeRecHed,              // 受信電文データ
                                out message                  // エラーメッセージ
                            );
                        }
                        // 通信アセンブリIDが優良UOE Web以外の場合、既存の処理を行う
                        else if ((status = UoeSndRcvMain(out message)) == (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            message = "";
                        }
                        // ---ADD 2010/05/07 ------------------<<<<<

                        recHed = _uoeRecHed;
                        
                        //UoeLoadLibraryの解除
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
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送受信ライブラリの設定・解除
		/// <summary>
		/// ＵＯＥ送受信ライブラリの設定・解除
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

		# region ＵＯＥ送受信メイン
		/// <summary>
		/// ＵＯＥ送受信メイン
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private int UoeSndRcvMain(out string message)
		{
			//変数の初期化
			Int16 snrv_flg = NG;
			Int16 status = OK;

			message = "";

			try
			{
				// < 通信デフォルト値変更 >--------------------------------------------
				if ((status = vctel_lcbw(out message)) != OK)
				{
				}
				// < RS-232C初期化／回線ｵｰﾌﾟﾝ >----------------------------------------
				else if ((status = vctel_lopn(out message)) != OK)
				{
				}
				// < ＩＤ交換／ＩＤセット >--------------------------------------------
				else if ((status = ictel_stid(out message)) != OK)
				{
				}
				// < 自動ダイヤル発信 >------------------------------------------------
				else if ((status = vctel_dial(out message)) != OK)
				{
				}
				// データ送信／受信 ---------------------------------------------------
				else
				{
					foreach (UoeSndDtl dtl in _uoeSndHed.UoeSndDtlList)
					{
						_uoeSndDtl = dtl;

						// データ送信処理 ---------------------------------------------
						status = idata_send(out message);
						if ((status != 0) && (!(_setid_flg == ON && status == 8)))
						{
							break;
						}

						// データ受信処理 ---------------------------------------------
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

				// < 回線切断 >--------------------------------------------------------
				if (snrv_flg == OK)
				{
					if((status = DISCONNECT()) == 0)
					{
						msg_pssput(P_MSG, "正常終了");
						message = "TCO_WAIT_AFTER_SEND_ENQ ｴﾗｰ";
					}
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			// < 回線ｸﾛｰｽﾞ >-------------------------------------------------------
			finally
			{
				//回線切断
				L_LCLOSE();
                _uoeOprtnHisLogAcs.log_update();
			}
			return (status);
		}
		# endregion

		# region 通信デフォルト値変更
		/// <summary>
		/// 通信デフォルト値変更
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 vctel_lcbw(out string message)
		{
			//変数の初期化
			Int16 status = OK;
			message = "";

			try
			{
				if ((status = LCBW(TCO_WAIT_AFTER_SEND_ENQ, 30)) != OK)
				{
					message = "TCO_WAIT_AFTER_SEND_ENQ ｴﾗｰ";
					return (status);
				}

				if ((status = LCBW(TCO_WAIT_AFTER_SEND_ETX, 30)) != OK)
				{
					message = "TCO_WAIT_AFTER_SEND_ETX ｴﾗｰ";
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

		# region 回線ｵｰﾌﾟﾝ
		/// <summary>
		/// 回線ｵｰﾌﾟﾝ
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		Int16	vctel_lopn(out string message)
		{
			//変数の初期化
			Int16 status = OK;
			message = "";

			try
			{
                msg_pssput(P_MSG, "回線初期化中");

                status = L_LOPEN(BSC2_PRIMARY);			// 優先局				   

                if (status != 0x00)
				{
                    message = "回線の初期化に失敗しました。";
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

		# region ＩＤ交換／ＩＤセット
        /// <summary>
        /// ＩＤ交換／ＩＤセット
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
		private Int16	ictel_stid(out string message)
		{
			//変数の初期化
			Int16 status = OK;
			byte[] id_str = new byte[20];

			message = "";

			try
			{
				// < ＩＤ交換 >--------------------------------------------------------
				string uOEIDNumString = _uOESupplier.UOEIDNum.Trim();
				//ＩＤ　有り
				if (uOEIDNumString.Length > 0)
				{
					_setid_flg = ON;					
				}
				//ＩＤ　なし
				else
				{
					_setid_flg = OFF;
				}
				
				// < ＩＤセット	>------------------------------------------------------
				if ( _setid_flg == ON )
				{
					UoeCommonFnc.MemCopy(ref id_str, uOEIDNumString, uOEIDNumString.Length);

					StringBuilder recv_id = new StringBuilder(1024);
					status = SETID(id_str, recv_id );
					if ( status != 0)
					{
						message = "ＩＤ交換　異常！！";
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
        
		# region 自動ダイヤル発信処理
		/// <summary>
		/// 自動ダイヤル発信処理
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 vctel_dial(out string message)
		{
			//変数の初期化
			Int16 status = OK;
			Int16	end_flg = 1;
			string wdial = _uOESupplier.TelNo.Trim();			//電話番号
			string w_msg = uOESupplier.UOESupplierName.Trim();	//発注先名

			message = "";

			try
			{
				//////***********   < 自動ダイヤル発信 >   ***************
                msg_pssput(P_HED, w_msg);

                while (end_flg == 1)
				{
					msg_pssput( P_MSG, "ダイヤル中" );
                    status = DIAL( REGULAR_MODEM, wdial );
					msg_psfclr( P_MSG );

    				switch( status )
					{
						case OK:							// ダイヤルＯＫ！！	   
							msg_pssput(P_MSG, "ダイヤル　正常終了");
							end_flg = 0;				// ダイヤル正常終了    
							break;

						case R_DIAL_NO_ANSWER:				// 相手応答無し       	
						case R_DIAL_BSC_CHECK:				// ＢＳＣチェックエラー
						case R_DIAL_BUSY_TALKING:			// 話中				   
							Console.Beep();					// ビープ音				
							string work = "";

							if (status == R_DIAL_NO_ANSWER)
							{
								work = MESSAGE_ERROR04 + "\r\n" + "\r\n" + MESSAGE_ERROR07;
							}
							else
							{
								work = MESSAGE_ERROR03 + "\r\n" + "\r\n" + MESSAGE_ERROR07;
							}

                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
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
                            //    message = "ダイヤル発信 エラー";
                            //    return (status);
                            //}
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  --------------------------------------->>>>>
                            if (this._opt_FuTaBa == (int)Option.ON)
                            {
                                //卸商発注処理(自動)ではない
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
                                        message = "ダイヤル発信 エラー";
                                        return (status);
                                    }

                                }
                                else
                                {
                                    message = "ダイヤル発信 エラー";
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
                                    message = "ダイヤル発信 エラー";
                                    return (status);
                                }

                            }
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571  ---------------------------------------<<<<<

							end_flg = 1;		// リトライ　セット	   
							break;
						default:							// その他ダイヤルエラー
							message = "DIAL 回線又はモデムが異常です､処理を中止します";
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

		# region データ送信処理
		/// <summary>
		/// データ送信処理
		/// </summary>
		/// <param name="send_text"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 idata_send( out string message )
		{
			//変数の初期化
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
				msg_pssput( P_MSG, "送信処理中" );

				//送信電文変換＜ＪＩＳ→ＥＢＣ＞
				send_src = _uoeSndDtl.SndTelegram;
				vjisebc_cnv(JIS_EBC_CNV, ref send_src, ref send_dst, send_src.Length);

				// 送信回数を算出(8=2048/256)--------------------------------------
                send_max = (Int16)(_uoeSndDtl.SndTelegramLen / _lengthSndRcvBlk);
                if((_uoeSndDtl.SndTelegramLen % _lengthSndRcvBlk) != 0)
                {
                    send_max++;
                }

				for (Int16 ix=0; ix<send_max; ix++)
				{
					// 業務別 送信ﾃｷｽﾄ長取出 --------------------------------------
                    send_len = isend_tget(ix, _uoeSndDtl.SndTelegramLen);
					UoeCommonFnc.MemCopy(ref send_txt, 0, ref send_dst, ix * _lengthSndRcvBlk, send_len);

					// 送信データログ書込 -----------------------------------------
                    log_update(procNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_SND, send_txt, send_len);

					// データ送信 -------------------------------------------------
					if (ix == send_max - 1)		// 最終データ送信			   
					{
						status = SNDI(send_txt, send_len, S_DLE_ETX);
					}
					else
					{
						status = SNDI(send_txt, send_len, S_DLE_ETB);
					}

					// SETID有り(ﾎﾝﾀﾞ)は､委譲要求 ＯＫ ----------------------------
					if ((status != 0) && (!(_setid_flg == ON && status == 8)))
					{
						SaveRecvText((int)(EnumUoeConst.ctDataSendCode.ct_SndNG));	//送信フラグ エラーセット
						message = "SEND 回線が異常です､処理を中止します";
						return(status);
					}
				}

				// ＥＯＴ送信 ----------------------------------------------------
				msg_psfclr( P_MSG );
				if ((status = LRESET()) != 0)
				{
					SaveRecvText((int)(EnumUoeConst.ctDataSendCode.ct_SndNG));	//送信フラグ エラーセット
					message = "RESET 回線が異常です､処理を中止します";
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

		# region 送信テキスト長取出し＜メーカ別・業務別＞
		/// <summary>
		/// 送信テキスト長取出し＜メーカ別・業務別＞
		/// </summary>
		/// <param name="blk">送信ブロック(0～)</param>
        /// <param name="sndTelegramLen">送信総サイズ</param>
        /// <returns>送信サイズ</returns>
        private Int16 isend_tget(Int16 blk, Int32 sndTelegramLen)
		{
			Int16 send_len = 0;	//送信テキスト長

			switch (_uOESupplier.CommAssemblyId)
			{
                //ホンダ
                case EnumUoeConst.ctCommAssemblyId_0501:
                    Int16 mei_cnt = (Int16)_uoeSndDtl.UOESalesOrderRowNo.Count;

                    //発注
                    if (_businessCode == HATSU)
                    {
                        send_len = (Int16)(mei_cnt * 17 + 84);
                    }
                    //見積・在庫
                    else
                    {
                        send_len = (Int16)(mei_cnt * 13 + 58);
                    }
                    break;
                //優良メーカー
                //case EnumUoeConst.ctCommAssemblyId_1001:
                //    send_len = 256;
                //    break;
                default:
                    //送信ブロックサイズ以下の場合
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

		# region データ受信処理
		/// <summary>
		/// データ受信処理
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br></br>
        /// <br></br>
        /// <br>Update Note : 2012/10/03 FSI佐々木 貴英</br>
        /// <br>            : タイムアウトエラーメッセージ不正対応</br>
        /// </remarks>
        private Int16 vdata_recv(out string message)
		{
			//変数の初期化
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
				// 送信　制御部セット----------------------------------------------
				msg_pssput( P_MSG, "受信処理中" );
				UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length );

                while (true)
				{
					// データ受信 -------------------------------------------------
					UoeCommonFnc.MemSet(ref recv_text, 0x20, _lengthSndRcvBlk);
                    recv_leng = 0;
					status = REC(recv_text, _lengthSndRcvBlk, ref recv_leng, ref recv_type);

					// 受信取得----------------------------------------------------
					if (status == 0)
					{
						// 受信データログ書込--------------------------------------
                        log_update(procNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_REC, recv_text, recv_leng);

                        //ホンダ専用処理
                        if((uoeSndHed.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0501)
                        && (recv_leng < SR_BLK_HONDA))
                        {
                            UoeCommonFnc.MemSet(ref recv_text, recv_leng, 0x40, SR_BLK_HONDA - recv_leng);
                            recv_leng = SR_BLK_HONDA;
                        }
                        //優良でダミー電文の場合、再度受信処理を実行する
                        else if (_uoeSndRcvJnlAcs.ChkCommAssemblyId(uoeSndHed.CommAssemblyId) == false)
                        {
                            //ダミー電文の場合再度、受信処理を実行する
                            if(SkipDummyTelegram(recv_text, recv_leng) == true)
                            {
                                // 受信回数オーバー
                                if (++ix > 20)
                                {
                                    status = R_REC_TIMEOUT;
                                    err_flg = NG;
                                    break;
                                }
                                continue;
                            }

                            //受信電文サイズが256バイトでない場合、強制的に256バイトに変更する
                            if (recv_leng != SR_BLK)
                            {
                                recv_leng = SR_BLK;

                            }
                        }

                        //ワークバッファへ保存
                        UoeCommonFnc.MemCopy(ref recv_work, recv_pnt, ref recv_text, 0, recv_leng);
						recv_pnt += recv_leng;
                        ix = 0;

                        //仕入受信ありの専用処理(明治・ＳＰＫ)
                        if ((recv_pnt > 0)
                        && (_processStockSlipDtRecvDiv == true)
                        && (_uoeSndRcvJnlAcs.ChkStockSlipDtRecvDiv(uoeSndHed.UOESupplierCd) == true))
                        {
                            //受信電文格納処理
                            int dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

                            // 受信ﾍｯﾀﾞｰｴﾗｰﾁｪｯｸ			
                            if ((status = vchek_herr(ref recv_work, out message)) != 0)
                            {
                                dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
                            }

                            SaveRecvText(dataSendCode, ref recv_work, recv_pnt);
            				UoeCommonFnc.MemSet(ref recv_work, 0x20, recv_work.Length );
                            recv_pnt = 0;
                        }
					}
					// 受信正常終了------------------------------------------------
					else if (status == R_REC_GET_EOT)
					{
						status = OK;
						break;
					}
					// タイムアウト------------------------------------------------
					else if (status == R_REC_TIMEOUT)
					{
                        // --- ADD 2012/10/03 ----------->>>>>
                        err_flg = NG;
                        // --- ADD 2012/10/03 -----------<<<<<
                        break;
					}
                    // その他エラー------------------------------------------------
                    else
                    {
                        err_flg = NG;
                        break;
                    }
				}

				if ( err_flg == NG ) {
					SaveRecvText((int)(EnumUoeConst.ctDataSendCode.ct_RcvNG));	//送信フラグ エラーセット
					message = "RECV 回線が異常です､処理を中止します";
					return(status);
				}

                if(recv_pnt > 0)
                {
                    //受信電文格納処理
				    int dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

				    // 受信ﾍｯﾀﾞｰｴﾗｰﾁｪｯｸ			
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


        # region 優良ダミー電文スキップ処理
        /// <summary>
        /// 優良ダミー電文スキップ処理
        /// </summary>
        /// <param name="src">受信テキスト</param>
        /// <param name="len">受信テキスト長</param>
        /// <returns>true:ダミー電文 false:通常電文</returns>
        private bool SkipDummyTelegram(byte[] src, int len)
        {
            bool boolReturn = true;

            try
            {
                if (len > 0)
                {
                    byte[] dst = new byte[len];
                    vjisebc_cnv(EBC_JIS_CNV, ref src, ref dst, len);

                    //受注部品番号 出荷部品番号の空白チェック
                    for (int i = 0; i < 40; i++)
                    {
                        if ((dst[i+25] == 0x20) || (dst[i+25] == 0x00)) continue;
                        boolReturn = false;
                        break;
                    }

                    //品名の空白チェック
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


        # region 受信ヘッダーエラーチェック
        /// <summary>
		/// 受信ヘッダーエラーチェック
		/// </summary>
		/// <param name="text"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private Int16 vchek_herr(ref byte[] text, out string message )
		{
			//変数の初期化
			Int16 status = OK;
			string err_msg = "";
			message = "";

			switch (_uOESupplier.CommAssemblyId)
			{
				//＜トヨタ＞
				case EnumUoeConst.ctCommAssemblyId_0102:
					# region ＜トヨタ＞
					Int16 com_flg = OK;

					if (text[8] == 0x00)
					{
						return (status);			// 正常返す					   
					}

					///////******  共通チェック  ***********
					switch (text[8])
					{
						case 0x11: err_msg = "ﾄﾗﾝｻﾞｸｼｮﾝ ｴﾗｰ"; break;
						case 0x12: err_msg = "ｵｷｬｸｻﾏｺｰﾄﾞ ｴﾗｰ"; break;
						case 0x14: err_msg = "ﾊﾟｽﾜｰﾄﾞ ｴﾗｰ"; break;
						case 0x88: err_msg = "ﾙｽﾊﾞﾝ ｴﾗｰ"; break;
						case 0x99: err_msg = "ｿﾉﾀ ｴﾗｰ"; break;
						default: com_flg = NG; break;
					}

					if (com_flg == NG)
					{
						if (_businessCode == HATSU)	// 発注			
						{
							switch (text[8])
							{
								case 0xf1: err_msg = "ﾄﾗﾝｻﾞｸｼｮﾝ ｴﾗｰ"; break;
								case 0xf2: err_msg = "ﾍﾝｼﾝﾃﾞｰﾀ ﾅｼ"; break;
								case 0xf3: err_msg = "ﾉｳﾋﾝｺｰﾄﾞ ﾅｼ"; break;
								case 0xf4: err_msg = "ﾃﾞｰﾀ ﾅｼ"; break;
								case 0xf5: err_msg = "ｼﾃｲｷｮﾃﾝ ｴﾗｰ"; break;
								case 0xf7: err_msg = "ｵｷｬｸｻﾏｺｰﾄﾞ ｴﾗｰ"; break;
								case 0xc3: err_msg = "ｶｼｭｳ ｳﾘｱｹﾞ ﾌｶ"; break;
								case 0xc4: err_msg = "ﾊｯﾁｭｳﾀﾝﾄｳｼｬ ｴﾗｰ"; break;
								case 0xc5: err_msg = "ﾌｫﾛｰﾉｳﾋﾝｺｰﾄﾞ ｴﾗｰ"; break;
								case 0xc6: err_msg = "ｶｼｭｳ ｵｷｬｸｻﾏ ｴﾗｰ"; break;
								default: break;
							}
						}
						else if (_businessCode == MITSU)	// 見積			
						{
							switch (text[8])
							{
								case 0xf1: err_msg = "ﾄﾗﾝｻﾞｸｼｮﾝ ｴﾗｰ"; break;
								case 0xf4: err_msg = "ﾃﾞｰﾀ ﾅｼ"; break;
								case 0xf7: err_msg = "ｵｷｬｸｻﾏｺｰﾄﾞ ｴﾗｰ"; break;
								case 0xc1: err_msg = "ﾚｰﾄ ｴﾗｰ"; break;
								case 0xc2: err_msg = "ｾﾝﾀｸｺｰﾄﾞ ｴﾗｰ"; break;
								case 0xc3: err_msg = "ｼｭｶﾝｷｮﾃﾝ ｴﾗｰ"; break;
								default: break;
							}
						}
						else						// 在庫			
						{
							switch (text[8])
							{
								case 0xf1: err_msg = "ﾄﾗﾝｻﾞｸｼｮﾝ ｴﾗｰ"; break;
								case 0xf4: err_msg = "ﾃﾞｰﾀ ﾅｼ"; break;
								default: break;
							}
						}
					}
					# endregion
					break;
				//＜日産＞
				case EnumUoeConst.ctCommAssemblyId_0202:
					# region ＜日産＞
					if (text[6] == 0x00) return (0);		// 正常返す		   

					///////******  共通チェック  ***********
					switch( text[6] )
					{
						case 0x13:	err_msg = "ｻｰﾋﾞｽ ｼﾞｶﾝﾀｲｴﾗｰ" ;	break;
						case 0x17:	err_msg = "ｻｰﾋﾞｽ ﾃｲｼﾁｭｳ"    ;	break;
						case 0x99:	err_msg = "ｿﾉﾀ ｴﾗｰ"         ;	break;
						default:	err_msg = String.Format("ｴﾗｰｺｰﾄﾞ= 0x%2x",(int)text[6]); break;
					}
					# endregion
					break;
				//＜三菱＞
				case EnumUoeConst.ctCommAssemblyId_0301:
				//＜マツダ＞
				case EnumUoeConst.ctCommAssemblyId_0401:
				case EnumUoeConst.ctCommAssemblyId_0402:
					# region ＜三菱＞＜マツダ＞
					if ((_uoeSndDtl.UOESalesOrderNo == 0) && (_uoeSndDtl.UOESalesOrderRowNo.Count == 0))
					{
						///////*********  開局又は閉局？  **************
						if (UoeCommonFnc.MemCmp(text, 30, "E1 ", 3) == 0) err_msg = "ﾕｰｻﾞｰｺｰﾄﾞ ｴﾗｰ";
						else if (UoeCommonFnc.MemCmp(text, 30, "E2 ", 3) == 0) err_msg = "ﾊﾟｽﾜｰﾄﾞ ｴﾗｰ";
						else if (text[6] != 0x00) err_msg = "ｿﾉﾀ ｴﾗｰ";

						// ﾏﾂﾀﾞ新ﾊﾞｰｼﾞｮﾝ
						if (_uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0402)
						{
							if (UoeCommonFnc.MemCmp(text, 30, "E3 ", 3) == 0) err_msg = "ﾎｽﾄｼｮｳｶﾞｲﾁｭｳ";
							else if (UoeCommonFnc.MemCmp(text, 30, "E4 ", 3) == 0) err_msg = "ﾆﾁｼﾞ ｼﾒ ｼｮﾘﾁｭｳ";
							else if (UoeCommonFnc.MemCmp(text, 30, "E5 ", 3) == 0) err_msg = "ｷﾞｮｳﾑ ｼｭｳﾘｮｳ";
							else if (UoeCommonFnc.MemCmp(text, 30, "E6 ", 3) == 0) err_msg = "ﾌｫｰﾏｯﾄ ｴﾗｰ";
						}
					}
					else
					{
						switch (text[6])
						{
							case 0x99: err_msg = "ｿﾉﾀ ｴﾗｰ"; break;
							case 0x88: err_msg = "ｼﾞｶﾝｶﾞｲ ｴﾗｰ"; break;
							default:
								if (_businessCode == HATSU || _businessCode == MITSU)
								{
									if (text[48] != 0x00)
									{
										err_msg = "ﾍｯﾄﾞ ｴﾗｰ";
									}
								}
								break;
						}
					}
					# endregion
					break;
				//＜ホンダ＞
				case EnumUoeConst.ctCommAssemblyId_0501:
					# region ＜ホンダ＞
					if (UoeCommonFnc.MemCmp(text, "TF2101", 6) == 0) err_msg = "ﾎｽﾄ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2102", 6) == 0) err_msg = "FENICS ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2103", 6) == 0) err_msg = "ﾎｽﾄ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2104", 6) == 0) err_msg = "FENICS ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2105", 6) == 0) err_msg = "ｿｳｼﾝ ｾｲｷﾞｮﾌﾞ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2106", 6) == 0) err_msg = "ｼﾞｭｼﾝ ｾｲｷﾞｮﾌﾞ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2108", 6) == 0) err_msg = "ﾕｰｻﾞｰｺｰﾄﾞ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2109", 6) == 0) err_msg = "ﾊﾟｽﾜｰﾄﾞ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF2110", 6) == 0) err_msg = "ﾄﾗﾝｻﾞｸｼｮﾝ ｲｼﾞｮｳ";
					else if (UoeCommonFnc.MemCmp(text, "TF21", 4) == 0) err_msg = "FENICS ｲｼﾞｮｳ";

					if (text[8] == 0x31)
					{
						err_msg = "ｼｮﾘｹｯｶ ｴﾗｰ";
					}
					else if (text[8] == 0x33)
					{
						err_msg = "ｼﾞｶﾝｶﾞｲ ｴﾗｰ";
					}
					if (_businessCode == HATSU && text[8] == 0x32)
					{
						err_msg = "ﾍｯﾄﾞｴﾗｰ";
					}
					# endregion
					break;
				//＜優良（その他）＞
				default:
					# region ＜優良（その他）＞
					if (UoeCommonFnc.MemCmp(text, "91", 2) == 0)				//開局拒否 
					{
						if (istrg_spac(text, 37, 32) != 0)
						{
							err_msg = "ｶｲｷｮｸ ｷｮﾋ";
						}
						else
						{
							UoeCommonFnc.MemCopy(ref err_msg, ref text, 36, 32);
						}
					}
					else if (UoeCommonFnc.MemCmp(text, "98", 2) == 0)				//強制中断 
					{
						if (istrg_spac(text, 37, 32) != 0)
						{
							err_msg = "ｷｮｳｾｲ ﾁｭｳﾀﾞﾝ";
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

		# region 受信電文保存
		/// <summary>
		/// 受信電文保存
		/// </summary>
		/// <param name="dataSendCode"></param>
		/// <param name="text"></param>
		private void SaveRecvText(int dataSendCode, ref byte[] src, Int16 len)
		{
            //メモリ破壊対策
            if (len > RECBUF_MAXSIZE)
            {
                len = RECBUF_MAXSIZE;
            }
            
            UoeRecDtl dtl = new UoeRecDtl();
			dtl.UOESalesOrderRowNo = new List<int>();

			dtl.RecTelegram = new byte[len];

			//受信電文
			if(len > 0)
			{
				byte[] dst = new byte[len];
				vjisebc_cnv(EBC_JIS_CNV, ref src, ref dst, len);
				dtl.RecTelegram = dst;
                dtl.RecTelegramLen = len;
			}

			//発注番号
			dtl.UOESalesOrderNo = _uoeSndDtl.UOESalesOrderNo;

			//発注行番号
			dtl.UOESalesOrderRowNo = _uoeSndDtl.UOESalesOrderRowNo;

			//送信フラグ
			dtl.DataSendCode = dataSendCode;

			//復旧フラグ
			//発注
			if (_businessCode == HATSU)
			{
				if (dataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_OK)
				{
					dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	//復旧なし
				}
				else
				{
					dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;	//復旧あり
				}
			}
			//見積・在庫
			else
			{
				dtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	//復旧なし
			}

			_uoeRecHed.UoeRecDtlList.Add(dtl);
		}
		# endregion

		# region エラー時：送信・復旧フラグ書込
		/// <summary>
		/// エラー時：送信・復旧フラグ書込
		/// </summary>
		/// <param name="dataSendCode">送信フラグ</param>
		private void SaveRecvText(int dataSendCode)
		{
			byte[] src = new byte[0];
			SaveRecvText(dataSendCode, ref src, 0);
		}
		# endregion

		# region ﾒｰｶｰ別 ｺｰﾄﾞ変換処理
		/// <summary>
		/// ﾒｰｶｰ別 ｺｰﾄﾞ変換処理
		/// </summary>
		/// <param name="type"></param>
		/// <param name="src"></param>
		/// <param name="dst"></param>
		/// <param name="len"></param>
		private void vjisebc_cnv(Int16 type, ref byte[] src, ref byte[] dst, int len)
		{
			int postStEn = 0;	//開閉局電文区分 0:通常 1:開閉局

			//開閉局電文区分
			if ((_uoeSndDtl.UOESalesOrderNo == 0) && (_uoeSndDtl.UOESalesOrderRowNo.Count == 0))
			{
				postStEn = 1;
			}
			else
			{
				postStEn = 0;
			}

			//初期化処理 --------------------------------------------------------
			UoeCommonFnc.MemSet(ref dst, 0x20, len);
			UoeCommonFnc.MemCopy(ref dst, ref src, len);

			switch (_uOESupplier.CommAssemblyId)
			{
				//＜トヨタ＞
				case EnumUoeConst.ctCommAssemblyId_0102:
					# region ＜トヨタ＞
					//送信<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i=1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//受信<EBC --> JIS CNV>
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

				//＜日産Nﾊﾟｰﾂ＞
				case EnumUoeConst.ctCommAssemblyId_0202:
					# region ＜日産Nﾊﾟｰﾂ＞
					//送信<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						// 開局／閉局電文--------------------------------------------------
						if (postStEn == 1)
						{
							// 送信データ(jis->ebc)変換------------------------------------
							for (int ix = 0; ix < KAI_SND; ix++)
							{
								dst[ix] = jis_ebc(src[ix]);
							}
							// バイナリ項目戻し--------------------------------------------
							UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);	//[21]:通信ymdhms
						}
						else
						{
							// 送信データ(jis->ebc)変換------------------------------------
							// TTC+業務H部のみEBCDIC   
							for (int ix = 0; ix < 48; ix++)
							{
								dst[ix] = jis_ebc(src[ix]);
							}
						}

						// バイナリ項目戻し（共通）----------------------------------------
						UoeCommonFnc.MemCopy(ref dst, ref src, 7);	// [0]:情報区分    
						// [1]:ﾃｷｽﾄｼｰｹﾝｽ   
						// [3]:ﾃｷｽﾄ長      
						// [5]:電文区分    
						// [6]:処理結果    

					}
					//受信<EBC --> JIS CNV>
					else
					{
						// 開局／閉局電文--------------------------------------------------
						if (postStEn == 1)
						{
							// 受信データ(ebc->jis)変換------------------------------------
							for (int ix = 0; ix < KAI_SND; ix++)
							{
								dst[ix] = ebc_jis(src[ix]);
							}

							//バイナリ項目戻し（[21]:通信ymdhms） 
							UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);
						}
						// 受信データ(ebc->jis)変換----------------------------------------
						else
						{
							for (int ix = 0; ix < 48; ix++)
							{
								dst[ix] = ebc_jis(src[ix]);
							}

                            int cpLen = len - 48;
                            UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, cpLen);
                        }

						// バイナリ項目戻し（共通）----------------------------------------
						UoeCommonFnc.MemCopy(ref dst, ref src, 7);	// [0]:情報区分    
						// [1]:ﾃｷｽﾄｼｰｹﾝｽ   
						// [3]:ﾃｷｽﾄ長      
						// [5]:電文区分    
						// [6]:処理結果    
					}
					# endregion
					break;
				//＜三菱＞
				case EnumUoeConst.ctCommAssemblyId_0301:
					# region ＜三菱＞
					//送信<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//受信<EBC --> JIS CNV>
					else
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
					}

                    //共通
					UoeCommonFnc.MemCopy(ref dst, 0, ref src, 0, 7);

                    // 開局又は閉局			   
                    if (postStEn == 1)
					{
						UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);
					}
                    //通常電文
					else
					{
                        int cpLen = len -48;
                        UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, cpLen);
					}
					# endregion
					break;
				//＜マツダ＞
				case EnumUoeConst.ctCommAssemblyId_0401:
				case EnumUoeConst.ctCommAssemblyId_0402:
					# region ＜マツダ＞
					//送信<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//受信<EBC --> JIS CNV>
					else
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = ebc_jis(src[i - 1]);
						}
					}

					UoeCommonFnc.MemCopy(ref dst, 0, ref src, 0, 7);
					if (postStEn == 1)
					{							// 開局又は閉局？			   
						UoeCommonFnc.MemCopy(ref dst, 21, ref src, 21, 6);
					}
					else
					{
						UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, 1);
						UoeCommonFnc.MemCopy(ref dst, 53, ref src, 53, 4);
					}
					# endregion
					break;
				//＜ホンダ＞
				case EnumUoeConst.ctCommAssemblyId_0501:
					# region ＜ホンダ＞
					//送信<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
						UoeCommonFnc.MemCopy(ref dst, 48, ref src, 48, 9);
					}
					//受信<EBC --> JIS CNV>
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
				//＜優良（その他）＞
				default:
					# region ＜優良（その他）＞
					//送信<JIS --> EBC CNV>
					if (type == JIS_EBC_CNV)
					{
						for (int i = 1; i <= len; i++)
						{
							dst[i - 1] = jis_ebc(src[i - 1]);
						}
					}
					//受信<EBC --> JIS CNV>
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

		# region メッセージクリア
        /// <summary>
        /// メッセージクリア
        /// </summary>
        /// <param name="fld">クリアフィールド</param>
        private void msg_psfclr(int fld)
		{
            this._msg_psfclr(fld);
        }
		# endregion

		# region メッセージ表示
        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="fld">表示フィールド</param>
        /// <param name="text">表示テキスト</param>
        private void msg_pssput(int fld, string text)
		{
            this._msg_pssput(fld, text);
		}
		# endregion

		# region 通信ログ書き込み
		/// <summary>
		/// 通信ログ書き込み
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

		# region ｊｉｓ－＞ｅｂｃｄｉｃ変換
		/// <summary>
		/// ｊｉｓ－＞ｅｂｃｄｉｃ変換
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

		# region ｅｂｃｄｉｃ－＞ｊｉｓ変換
		/// <summary>
		/// ｅｂｃｄｉｃ－＞ｊｉｓ変換
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

		# region 指定文字列内がスペースかどうか判定する
		/// <summary>
		/// 指定文字列内がスペースかどうか判定する
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
        /// 優良メーカー(Web)であるか判断します。
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>
        /// 通信アセンブリIDが
        /// <c>EnumUoeConst.ctCommAssemblyId_1004</c>:明治産業
        /// の場合、<c>true</c>を返します。
        /// 通信アセンブリIDが
        /// <c>EnumUoeConst.ctCommAssemblyId_1003</c>:卸NET
        /// の場合、<c>true</c>を返します。
        /// </returns>
        public static bool IsOtherMakerUOEWeb(string commAssemblyId)
        {
            switch (commAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_1004:   //優良メーカー(明治産業)
                    return true;
                case EnumUoeConst.ctCommAssemblyId_1003:   //優良メーカー(卸NET)
                    return true;
                default:
                    return false;
            }
        }

        // ---ADD 2010/05/07 ------------------<<<<<

		# endregion
	}
}
