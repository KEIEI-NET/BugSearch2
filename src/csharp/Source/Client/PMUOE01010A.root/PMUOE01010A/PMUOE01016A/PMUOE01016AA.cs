//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集（ホンダ）アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10501071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送信編集（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集（ホンダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0501Acs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndEdit0501Acs()
		{
			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		//ＵＯＥ送信編集結果
		private List<UoeSndDtl> _uoeSndDtlList = new List<UoeSndDtl>();

		//発注先情報クラス
		private UOESupplier	_uOESupplier;

		//システム区分 0:手入力 1:伝発 2:検索 3：一括 4：補充
		private int _systemDivCd;

		//ＵＯＥ送受信ＪＮＬ（発注）ＶＩＥＷ
		private DataView _orderView = new DataView();

		//ＵＯＥ送受信ＪＮＬ（見積）ＶＩＥＷ
		private DataView _estmtView = new DataView();

		//ＵＯＥ送受信ＪＮＬ（在確）ＶＩＥＷ
		private DataView _stockView = new DataView();

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//Sort
		public const string ctSortUpper = " ASC";   // 昇順出力
		public const string ctSortDownO = " DESC";  // 降順出力

		//企業コード 発注先コード 発注番号 発注行番号
		public const string ctSortOrder = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";
		public const string ctSortEstmt = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";
		public const string ctSortStock = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";

		//エラーメッセージ
		private const string MESSAGE_ERROR01 = "業務区分のパラメータが違います。";
		private const string MESSAGE_ERROR02 = "送受信ＪＮＬ＜発注＞（ホンダ）が見つかりません。";
		private const string MESSAGE_ERROR03 = "送受信ＪＮＬ＜見積＞（ホンダ）が見つかりません。";
		private const string MESSAGE_ERROR04 = "送受信ＪＮＬ＜在庫＞（ホンダ）が見つかりません。";

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
		# region ＵＯＥ発注先情報クラス
		/// <summary>
		/// ＵＯＥ発注先情報クラス
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

		# region ＜DataSet＞
		/// <summary>
		/// ＵＯＥ送受信ＪＮＬデータセット
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get
			{
				return this._uoeSndRcvJnlAcs.UoeJnlDataSet;
			}
		}
		# endregion

		# region ＜DataTable＞
		# region 発注＜DataTable＞
		/// <summary>
		/// 発注＜DataTable＞
		/// </summary>
		public DataTable OrderTable
		{
			get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
		}
		# endregion

		# region 見積＜DataTable＞
		/// <summary>
		/// 見積＜DataTable＞
		/// </summary>
		public DataTable EstmtTable
		{
			get { return UoeJnlDataSet.Tables[EstmtSndRcvJnlSchema.CT_EstmtSndRcvJnlDataTable]; }
		}
		# endregion

		# region 在庫＜DataTable＞
		/// <summary>
		/// 在庫＜DataTable＞
		/// </summary>
		public DataTable StockTable
		{
			get { return UoeJnlDataSet.Tables[StockSndRcvJnlSchema.CT_StockSndRcvJnlDataTable]; }
		}
		# endregion
		# endregion

		# region ＜DataView＞
		# region 発注＜DataView＞
		/// <summary>
		/// 発注＜DataTable＞
		/// </summary>
		public DataView OrderView
		{
			get { return this._orderView; }
		}
		# endregion

		# region 見積＜DataView＞
		/// <summary>
		/// 見積＜DataTable＞
		/// </summary>
		public DataView EstmtView
		{
			get { return this._estmtView; }
		}
		# endregion

		# region 在庫＜DataView＞
		/// <summary>
		/// 在庫＜DataTable＞
		/// </summary>
		public DataView StockView
		{
			get { return this._stockView; }
		}
		# endregion
		# endregion
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region ＵＯＥ送信編集（ホンダ）
		/// <summary>
		/// ＵＯＥ送信編集（ホンダ）
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int writeUOESNDEdit0501(Int32 businessCode, int systemDivCd, UOESupplier uOESupplier, out List<UoeSndDtl> list, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			//ＵＯＥ送信編集結果クラスの初期化
			list = new List<UoeSndDtl>();
			_uoeSndDtlList = new List<UoeSndDtl>();

			try
			{
				//発注先情報の保存
				_uOESupplier = uOESupplier;

				//システム区分の保存
				_systemDivCd = systemDivCd;

				//リモート処理の呼び出し、データーテーブルへの格納
				switch (businessCode)
				{
					//発注
					case (int)EnumUoeConst.TerminalDiv.ct_Order:
						{
							status = writeUOESNDEditOrder0501(out _uoeSndDtlList, out message);
							break;
						}
					//見積
					case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
						{
							status = writeUOESNDEditEstm0501(out _uoeSndDtlList, out message);
							break;
						}
					//在庫
					case (int)EnumUoeConst.TerminalDiv.ct_Stock:
						{
							status = writeUOESNDEditAlloc0501(out _uoeSndDtlList, out message);
							break;
						}
					//その他
					default:
						{
							message = MESSAGE_ERROR01;
							break;
						}
				}
				if ((status == (int)EnumUoeConst.Status.ct_NORMAL)
				&& (_uoeSndDtlList.Count > 0))
				{
					list = _uoeSndDtlList;
				}
			}
			catch (Exception ex)
			{
				status = (int)EnumUoeConst.Status.ct_ERROR;
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
		# region ソートクエリ作成処理
		/// <summary>
		/// ソートクエリ作成処理
		/// </summary>
		/// <param name="para"></param>
		/// <returns></returns>
		private string GetSortQuerry(int businessCode)
		{
			string sortQuerry = "";

			switch (businessCode)
			{
				//発注
				case (int)EnumUoeConst.TerminalDiv.ct_Order:
					{
						sortQuerry = ctSortOrder;
						break;
					}
				//見積
				case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
					{
						sortQuerry = ctSortEstmt;
						break;
					}
				//在庫
				case (int)EnumUoeConst.TerminalDiv.ct_Stock:
					{
						sortQuerry = ctSortStock;
						break;
					}
			}
			sortQuerry += ctSortUpper;
			return (sortQuerry);
		}
		# endregion

		# region フィルタークエリ作成処理
        /// <summary>
        /// フィルタークエリ作成処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        /// <param name="cd">発注先コード</param>
        /// <returns>フィルタークエリ</returns>
        private string GetRowFilterQuerry(int businessCode, Int32 cd)
        {
            string rowFilterQuerry = "";

            switch (businessCode)
            {
                //発注
                case (int)EnumUoeConst.TerminalDiv.ct_Order:
                    {
                        rowFilterQuerry = string.Format("{0} = {1} AND {2} = {3}",
                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, cd,
                            OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process);
                        break;
                    }
                //見積
                case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
                    {
                        rowFilterQuerry = "UOESupplierCd = " + cd;
                        break;
                    }
                //在庫
                case (int)EnumUoeConst.TerminalDiv.ct_Stock:
                    {
                        rowFilterQuerry = "UOESupplierCd = " + cd;
                        break;
                    }
            }
            return (rowFilterQuerry);
        }
        # endregion
		# endregion

	}
}
