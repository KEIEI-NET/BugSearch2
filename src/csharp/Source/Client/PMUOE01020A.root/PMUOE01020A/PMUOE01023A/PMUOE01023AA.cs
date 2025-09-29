//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集（三菱）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集（三菱）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ受信編集（三菱）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（三菱）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0301Acs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeRecEdit0301Acs()
		{
			//企業コードを取得する
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//企業コード
		private string _enterpriseCode = "";

		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		//ＵＯＥ送信編集（ヘッダー）
		private UoeSndHed _uoeSndHed = new UoeSndHed();

		//ＵＯＥ受信編集（ヘッダー）
		private UoeRecHed _uoeRecHed = new UoeRecHed();
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//ヘッドエラーメッセージ
																// 共通  発注  見積  在庫
		private const string MSG_TRA = "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ"	   ;	// 						
		private const string MSG_UCD = "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ"     ;	// 
		private const string MSG_PAS = "ﾊﾟｽﾜｰﾄﾞｴﾗｰ"        ;	// 
		private const string MSG_RUS = "ｼﾞｶﾝｶﾞｲ ｴﾗｰ"       ;	//       0x88  
		private const string MSG_ELS = "ｿﾉﾀｴﾗｰ"            ;	// 0x99
		private const string MSG_HEN = "ﾍﾝｼﾝﾃﾞｰﾀﾅｼ"        ;	//       
		private const string MSG_NOU = "ﾉｳﾋﾝｺｰﾄﾞﾅｼ"        ;	//       
		private const string MSG_DAT = "ﾃﾞｰﾀﾅｼ"            ;	//       			
		private const string MSG_STK = "ｼﾃｲｷｮﾃﾝｴﾗｰ"        ;	//       
		private const string MSG_KUF = "ｶｼｭｳｳﾘｱｹﾞﾌｶ"       ;	//       
		private const string MSG_HTA = "ﾊｯﾁｭｳﾀﾝﾄｳｼｬｴﾗｰ"    ;	//       
		private const string MSG_FNC = "ﾌｫﾛｰﾉｰﾋﾝｺｰﾄﾞﾅｼ"    ;	//       
		private const string MSG_KOC = "ｶｼｭｳｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" ;	//       
		private const string MSG_RTE = "ﾚｰﾄｴﾗｰ"            ;	//             
		private const string MSG_SCD = "ｾﾝﾀｸｺｰﾄﾞｴﾗｰ"       ;	//             
		private const string MSG_SKK = "ｼｭｶﾝｷｮﾃﾝｴﾗｰ"       ;	//             

		private const string MSG_TIM = "ｻｰﾋﾞｽ ｼﾞｶﾝﾀｲｴﾗｰ"   ;	//             0x13
		private const string MSG_STP = "ｻｰﾋﾞｽ ﾃｲｼﾁｭｳ"      ;	//             0x17

		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		# region ＵＯＥ受信結果（ヘッダー）
		/// <summary>
		/// ＵＯＥ受信（ヘッダー）
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

		# region ＵＯＥ受信結果（明細）
		/// <summary>
		/// ＵＯＥ受信（明細）
		/// </summary>
		public List<UoeRecDtl> uoeRecDtlList
		{
			get
			{
				return this._uoeRecHed.UoeRecDtlList;
			}
			set
			{
				this._uoeRecHed.UoeRecDtlList = value;
			}
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region ＵＯＥ受信編集＜発注＞（三菱）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（三菱）
		/// </summary>
        /// <param name="uoeSndHed">UOE送信オブジェクト</param>
        /// <param name="uoeRecHed">UOE受信オブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int uoeRecEditOrder0301(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // 編集クラスの保存
                //-----------------------------------------------------------
                //ＵＯＥ送信編集クラスの保存
				_uoeSndHed = uoeSndHed;

				//ＵＯＥ受信編集クラスの保存
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // 受信編集処理
                //-----------------------------------------------------------
                status = GetJnlOrder0301(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ受信編集＜見積＞（三菱）
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞（三菱）
		/// </summary>
        /// <param name="uoeSndHed">UOE送信オブジェクト</param>
        /// <param name="uoeRecHed">UOE受信オブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int uoeRecEditEstmt0301(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // 編集クラスの保存
                //-----------------------------------------------------------
                //ＵＯＥ送信編集クラスの保存
				_uoeSndHed = uoeSndHed;

				//ＵＯＥ受信編集クラスの保存
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // 受信編集処理
                //-----------------------------------------------------------
                status = GetJnlEstmt0301(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}

		# endregion

		# region ＵＯＥ受信編集＜在庫＞（三菱）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（三菱）
		/// </summary>
        /// <param name="uoeSndHed">UOE送信オブジェクト</param>
        /// <param name="uoeRecHed">UOE受信オブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int uoeRecEditStock0301(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // 編集クラスの保存
                //-----------------------------------------------------------
                //ＵＯＥ送信編集クラスの保存
				_uoeSndHed = uoeSndHed;

				//ＵＯＥ受信編集クラスの保存
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // 受信編集処理
                //-----------------------------------------------------------
                status = GetJnlStock0301(out message);
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
		# endregion

	}
}
