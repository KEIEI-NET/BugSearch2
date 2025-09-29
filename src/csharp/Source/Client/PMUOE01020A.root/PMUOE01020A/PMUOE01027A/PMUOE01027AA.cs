//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集（優良）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集（優良）を行う
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
	/// ＵＯＥ受信編集（優良）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（優良）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit1001Acs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeRecEdit1001Acs()
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

		//ＵＯＥ発注先マスタ
		UOESupplier _uOESupplier = null;

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
		private const string MSG_TRA = "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ"	   ;	// 0x11  0xf1  0xf1  0xf1
		private const string MSG_UCD = "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ"     ;	// 0x12  0xf7  0xf7
		private const string MSG_PAS = "ﾊﾟｽﾜｰﾄﾞｴﾗｰ"        ;	// 0x14
		private const string MSG_RUS = "ﾙｽﾊﾞﾝｴﾗｰ"          ;	// 0x88
		private const string MSG_ELS = "ｿﾉﾀｴﾗｰ"            ;	// 0x99
		private const string MSG_HEN = "ﾍﾝｼﾝﾃﾞｰﾀﾅｼ"        ;	//       0xf2
		private const string MSG_NOU = "ﾉｳﾋﾝｺｰﾄﾞﾅｼ"        ;	//       0xf3
		private const string MSG_DAT = "ﾃﾞｰﾀﾅｼ"            ;	//       0xf4  0xf4  0xf4
		private const string MSG_STK = "ｼﾃｲｷｮﾃﾝｴﾗｰ"        ;	//       0xf5
		private const string MSG_KUF = "ｶｼｭｳｳﾘｱｹﾞﾌｶ"       ;	//       0xc3
		private const string MSG_HTA = "ﾊｯﾁｭｳﾀﾝﾄｳｼｬｴﾗｰ"    ;	//       0xc4
		private const string MSG_FNC = "ﾌｫﾛｰﾉｰﾋﾝｺｰﾄﾞﾅｼ"    ;	//       0xc5
		private const string MSG_KOC = "ｶｼｭｳｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" ;	//       0xc6
		private const string MSG_RTE = "ﾚｰﾄｴﾗｰ"            ;	//             0xc1
		private const string MSG_SCD = "ｾﾝﾀｸｺｰﾄﾞｴﾗｰ"       ;	//             0xc2
		private const string MSG_SKK = "ｼｭｶﾝｷｮﾃﾝｴﾗｰ"       ;	//             0xc3

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

		# region ＵＯＥ受信編集＜発注＞（優良）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（優良）
		/// </summary>
        /// <param name="uoeSndHed">UOE送信オブジェクト</param>
        /// <param name="uoeRecHed">UOE受信オブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		public int uoeRecEditOrder1001(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
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
                status = GetJnlOrder1001(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}

		# endregion

		# region ＵＯＥ受信編集＜在庫＞（優良）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（優良）
		/// </summary>
        /// <param name="uoeSndHed">UOE送信オブジェクト</param>
        /// <param name="uoeRecHed">UOE受信オブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int uoeRecEditStock1001(UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
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
                status = GetJnlStock1001(out message);
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
