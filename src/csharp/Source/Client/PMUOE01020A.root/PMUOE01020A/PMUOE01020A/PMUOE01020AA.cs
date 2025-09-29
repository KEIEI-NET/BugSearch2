//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集アクセスクラス
// プログラム概要   : ＵＯＥ受信編集を行う
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
// 管理番号  10601191-00 作成担当 : 高峰
// 作 成 日  2010/05/24  修正内容 : redmine#8268の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 作 成 日  2011/10/25  修正内容 : PM1113A 卸NET-WEB対応仕様追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LIUSY
// 作 成 日  2010/11/24  修正内容 : PM1113A 卸NET-WEB対応仕様追加
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ受信編集アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 高峰 PM1008 明治UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpDate</br>
    /// <br>2010/05/24 高峰 PM1008 redmine#8268の対応</br>
    /// <br>2011/10/25 葛中華 PM1113A 卸NET-WEB対応仕様追加</br>
	/// </remarks>
	public partial class UoeRcvEditAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeRcvEditAcs()
		{
			//企業コードを取得する
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//ＵＯＥ受信編集（トヨタＰＤ４）アクセスクラス
			_uoeRecEdit0102Acs = new UoeRecEdit0102Acs();

			//ＵＯＥ受信編集（ニッサンＮパーツ）アクセスクラス
			_uoeRecEdit0202Acs = new UoeRecEdit0202Acs();

			//ＵＯＥ受信編集（三菱）アクセスクラス
			_uoeRecEdit0301Acs = new UoeRecEdit0301Acs();

			//ＵＯＥ受信編集（旧マツダ）アクセスクラス
			_uoeRecEdit0401Acs = new UoeRecEdit0401Acs();

			//ＵＯＥ受信編集（新マツダ）アクセスクラス
			_uoeRecEdit0402Acs = new UoeRecEdit0402Acs();

			//ＵＯＥ受信編集（ホンダ）アクセスクラス
			_uoeRecEdit0501Acs = new UoeRecEdit0501Acs();

			//ＵＯＥ受信編集（優良）アクセスクラス
			_uoeRecEdit1001Acs = new UoeRecEdit1001Acs();
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//企業コード
		private string _enterpriseCode = "";

		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//ＵＯＥ送信結果
		private UoeSndHed _uoeSndHed = null;

		//ＵＯＥ受信結果
		private UoeRecHed _uoeRecHed = null;

		//ＵＯＥ受信編集（トヨタＰＤ４）アクセスクラス
		private UoeRecEdit0102Acs _uoeRecEdit0102Acs = null;

		//ＵＯＥ受信編集（ニッサンＮパーツ）アクセスクラス
		private UoeRecEdit0202Acs _uoeRecEdit0202Acs = null;

		//ＵＯＥ受信編集（三菱）アクセスクラス
		private UoeRecEdit0301Acs _uoeRecEdit0301Acs = null;

		//ＵＯＥ受信編集（旧マツダ）アクセスクラス
		private UoeRecEdit0401Acs _uoeRecEdit0401Acs = null;

		//ＵＯＥ受信編集（新マツダ）アクセスクラス
		private UoeRecEdit0402Acs _uoeRecEdit0402Acs = null;

		//ＵＯＥ受信編集（ホンダ）アクセスクラス
		private UoeRecEdit0501Acs _uoeRecEdit0501Acs = null;

		//ＵＯＥ受信編集（優良）アクセスクラス
		private UoeRecEdit1001Acs _uoeRecEdit1001Acs = null;
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
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
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		# region ＵＯＥ受信編集＜発注＞
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int UoeRecEditOrder(int systemDivCd, UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
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
                status = GetJnlOrder(out message);
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ受信編集＜見積＞
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int UoeRecEditEstmt(int systemDivCd, UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//変数の初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
				status = GetJnlEstmt(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ受信編集＜在庫＞
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int UoeRecEditStock(int systemDivCd, UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//変数の初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                status = GetJnlStock(out message);
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
        # region ＵＯＥ受信編集＜発注＞
        /// <summary>
        /// ＵＯＥ受信編集＜発注＞
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/07 高峰</br>
        /// <br>              PM1008 明治UOE-WEB対応に伴う仕様追加</br>
        /// <br>Update Note : 2011/10/25 葛中華</br>
        /// <br>              PM1113A 卸NET-WEB対応仕様追加</br>
        /// </remarks>
        private int GetJnlOrder(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                switch (_uoeSndHed.CommAssemblyId)
                {
                    //トヨタ
                    case EnumUoeConst.ctCommAssemblyId_0102:
                        {
                            status = _uoeRecEdit0102Acs.uoeRecEditOrder0102(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }

                    //ニッサン
                    case EnumUoeConst.ctCommAssemblyId_0202:
                        {
                            status = _uoeRecEdit0202Acs.uoeRecEditOrder0202(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //ミツビシ
                    case EnumUoeConst.ctCommAssemblyId_0301:
                        {
                            status = _uoeRecEdit0301Acs.uoeRecEditOrder0301(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //旧マツダ
                    case EnumUoeConst.ctCommAssemblyId_0401:
                        {
                            status = _uoeRecEdit0401Acs.uoeRecEditOrder0401(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //新マツダ
                    case EnumUoeConst.ctCommAssemblyId_0402:
                        {
                            status = _uoeRecEdit0402Acs.uoeRecEditOrder0402(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //ホンダ
                    case EnumUoeConst.ctCommAssemblyId_0501:
                        {
                            status = _uoeRecEdit0501Acs.uoeRecEditOrder0501(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    // ---ADD 2010/05/07 ------------------>>>>>
                    // 優良メーカーWebの場合を追加 ※通常の優良メーカーと同じ処理を行う
                    case EnumUoeConst.ctCommAssemblyId_1004:
                    // ---ADD 2010/05/07 ------------------<<<<<
                    // ---ADD 2011/10/25 ------------------>>>>>
                    // 卸NET-WEB対応仕様追加
                    case EnumUoeConst.ctCommAssemblyId_1003:
                    // ---ADD 2011/10/25 ------------------<<<<<
                    //優良メーカー
                    case EnumUoeConst.ctCommAssemblyId_1001:
                        {
                            status = _uoeRecEdit1001Acs.uoeRecEditOrder1001(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
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

        # region ＵＯＥ受信編集＜見積＞
        /// <summary>
        /// ＵＯＥ受信編集＜見積＞
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlEstmt(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                switch (_uoeSndHed.CommAssemblyId)
                {
                    //トヨタ
                    case EnumUoeConst.ctCommAssemblyId_0102:
                        {
                            status = _uoeRecEdit0102Acs.uoeRecEditEstmt0102(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }

                    //ニッサン
                    case EnumUoeConst.ctCommAssemblyId_0202:
                        {
                            status = _uoeRecEdit0202Acs.uoeRecEditEstmt0202(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //ミツビシ
                    case EnumUoeConst.ctCommAssemblyId_0301:
                        {
                            status = _uoeRecEdit0301Acs.uoeRecEditEstmt0301(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //旧マツダ
                    case EnumUoeConst.ctCommAssemblyId_0401:
                        {
                            status = _uoeRecEdit0401Acs.uoeRecEditEstmt0401(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //新マツダ
                    case EnumUoeConst.ctCommAssemblyId_0402:
                        {
                            status = _uoeRecEdit0402Acs.uoeRecEditEstmt0402(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //ホンダ
                    case EnumUoeConst.ctCommAssemblyId_0501:
                        {
                            status = _uoeRecEdit0501Acs.uoeRecEditEstmt0501(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
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

        # region ＵＯＥ受信編集＜在庫＞
        /// <summary>
        /// ＵＯＥ受信編集＜在庫＞
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/24 高峰</br>
        /// <br>              PM1008 redmine#8268の対応</br>
        /// </remarks>
        private int GetJnlStock(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                switch (_uoeSndHed.CommAssemblyId)
                {
                    //トヨタ
                    case EnumUoeConst.ctCommAssemblyId_0102:
                        {
                            status = _uoeRecEdit0102Acs.uoeRecEditStock0102(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }

                    //ニッサン
                    case EnumUoeConst.ctCommAssemblyId_0202:
                        {
                            status = _uoeRecEdit0202Acs.uoeRecEditStock0202(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //ミツビシ
                    case EnumUoeConst.ctCommAssemblyId_0301:
                        {
                            status = _uoeRecEdit0301Acs.uoeRecEditStock0301(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //旧マツダ
                    case EnumUoeConst.ctCommAssemblyId_0401:
                        {
                            status = _uoeRecEdit0401Acs.uoeRecEditStock0401(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //新マツダ
                    case EnumUoeConst.ctCommAssemblyId_0402:
                        {
                            status = _uoeRecEdit0402Acs.uoeRecEditStock0402(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //ホンダ
                    case EnumUoeConst.ctCommAssemblyId_0501:
                        {
                            status = _uoeRecEdit0501Acs.uoeRecEditStock0501(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    // ---ADD 2010/05/24 ------------------>>>>>
                    // 優良メーカーWebの場合を追加 ※通常の優良メーカーと同じ処理を行う
                    case EnumUoeConst.ctCommAssemblyId_1004:
                    // ---ADD 2010/05/24 ------------------<<<<<
                    //優良メーカー
                    case EnumUoeConst.ctCommAssemblyId_1001:
                    // ---ADD 2010/11/24 ------------------<<<<<
                    //卸WEB-NET
                    case EnumUoeConst.ctCommAssemblyId_1003:
                    // ---ADD 2010/11/24 ------------------<<<<<
                        {
                            status = _uoeRecEdit1001Acs.uoeRecEditStock1001(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
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
	}
}
