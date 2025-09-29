using System;
using System.Data;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 入金引当表示アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金引当表示ＵＩクラスを操作するアクセスクラスです。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.19</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS用に変更</br>
	/// <br>                                         1. 受注・諸費用を削除</br>
    /// <br>                                         2. 画面デザイン変更対応</br>
    /// <br>Update Note: 2007.10.05 20081 疋田 勇人 DC.NS用に変更</br>
    /// <br></br>
	/// </remarks>
	public class DepositAlwViewAcs
	{
		# region Constructor
		/// <summary>
		/// 入金引当表示アクセスクラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金引当表示アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		public DepositAlwViewAcs()
		{
			// 入金引当 DataSet
			this._dsDepositAlwInfo = new DataSet();

			// 入金引当操作アクセスクラス
			this.controlDepsitAlwAcs = new ControlDepsitAlwAcs(); 
		}
		# endregion

		# region Private Menbers
		//***************************************************************
		// 画面バインド用 DataSet
		//***************************************************************
		/// <summary>入金引当 DataSet</summary>
		private DataSet _dsDepositAlwInfo;

		//***************************************************************
		// メンバー
		//***************************************************************
		/// <summary>入金引当操作アクセスクラス</summary>
		private ControlDepsitAlwAcs controlDepsitAlwAcs;
		# endregion

		# region public const Menbers
		//***************************************************************
		// 入金引当DataSet用定数宣言
		//***************************************************************
		/// <summary>引当情報Table名称</summary>
		public const string ctDepositAlwDataTable = "DepositAlwDataTable";

		/// <summary>入金伝票番号</summary>
		public const string ctDepositSlipNo = "DepositSlipNo";

		///// <summary>受注伝票番号</summary>
		//public const string ctAcceptAnOrderNo = "AcceptAnOrderNo";  // 2007.10.05 hikita del
        
        // ↓ 20070131 18322 d MA.NS用に変更
		///// <summary>入金引当額 受注</summary>
		//public const string ctAcpOdrDepositAlwc = "AcpOdrDepositAlwc";
        //
		///// <summary>入金引当額 諸費用</summary>
		//public const string ctVarCostDepoAlwc = "VarCostDepoAlwc";
        // ↑ 20070131 18322 d

		/// <summary>入金引当額 共通</summary>
		public const string ctDepositAllowance = "DepositAllowance";

		/// <summary>引当日(表示用)</summary>
		public const string ctReconcileDateDisp = "ReconcileDateDisp";

		/// <summary>引当日</summary>
		public const string ctReconcileDate = "ReconcileDate";

		/// <summary>引当計上日付</summary>
		public const string ctReconcileAddUpADate = "ReconcileAddUpADate";
		# endregion

		# region public Methods
		/// <summary>
		/// 入金引当DataSet初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : DataSetを初期化します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		public void ClearDsDepositAlwInfo()
		{
			// DataSet初期化
			_dsDepositAlwInfo.Clear();
		}

		/// <summary>
		/// 入金引当DataSet取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : DataSetを取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		public DataSet GetDsDepositAlwInfo()
		{
			return _dsDepositAlwInfo;
		}

		/// <summary>
		/// 入金引当 DataSet Table 作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金引当データセットのテーブルを作成します。
		///	               :   ※ Method : GetDsDepositInfo より結果取得</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.26</br>
		/// </remarks>
		public void CreateDepositAlwDataTable()
		{
			// データテーブルの列定義
			DataTable dtDepositAlwTable = new DataTable(ctDepositAlwDataTable);

			// Addを行う順番が、列の表示順位となります。
			dtDepositAlwTable.Columns.Add(ctDepositSlipNo, typeof(int));					// 入金伝票番号
			//dtDepositAlwTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));					// 受注伝票番号    // 2007.10.05 hikita del
            // ↓ 20070131 18322 d MA.NS用に変更
			//dtDepositAlwTable.Columns.Add(ctAcpOdrDepositAlwc, typeof(Int64));				// 入金引当額 受注
			//dtDepositAlwTable.Columns.Add(ctVarCostDepoAlwc, typeof(Int64));				// 入金引当額 諸費用
            // ↑ 20070131 18322 d
			dtDepositAlwTable.Columns.Add(ctDepositAllowance, typeof(Int64));				// 入金引当額 共通
			dtDepositAlwTable.Columns.Add(ctReconcileDateDisp, typeof(string));				// 引当日(表示用)
			dtDepositAlwTable.Columns.Add(ctReconcileDate, typeof(int));					// 引当日
			dtDepositAlwTable.Columns.Add(ctReconcileAddUpADate, typeof(int));				// 引当計上日

			// データセットに追加
			_dsDepositAlwInfo.Tables.Add(dtDepositAlwTable.Clone());
		}

		/// <summary>
		/// 入金引当データ取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 指定された受注番号の入金引当データを取得します。
		///	                :   ※ Method : GetDsDepositAlwInfo より結果取得</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
        public int SearchAllowanceOfAcceptOdrNo(string enterpriseCode, int customerCode, int acptAnOdrStatus, string salesSlipNum, out string message)
		{
			message = "";
			DepositAlwWork[] depositAlwWorkList;

            int st = controlDepsitAlwAcs.ReadDB(enterpriseCode, customerCode, acptAnOdrStatus, salesSlipNum, out depositAlwWorkList, out message);
			switch (st)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

					// 入金引当データテーブル データセット処理
					foreach(DepositAlwWork depositAlwWork in depositAlwWorkList)
					{
						// 入金引当DataSetの行を追加する
						DataRow drNew = this._dsDepositAlwInfo.Tables[ctDepositAlwDataTable].NewRow();
						this._dsDepositAlwInfo.Tables[ctDepositAlwDataTable].Rows.Add(drNew);

						// 入金引当DataRowセット処理
						SetDepositAlw(drNew, depositAlwWork);
					}

					break;

				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    // ↓ 20070131 18322 c MA.NS用に変更
					//message = "指定された受注番号に対する入金引当は存在しませんでした。";

					message = "指定された売上番号に対する入金引当は存在しませんでした。";
                    // ↑ 20070131 18322 c
					break;

				default :

					break;
			}

			return st;
		}

		/// <summary>
		/// 入金引当データ取得処理
		/// </summary>
		/// <returns>入金引当合計額</returns>
		/// <remarks>
		/// <br>Note　　　  : 入金引当合計額を取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		public Int64 GetTotalDepositAllowance()
		{
			Int64 total = 0;

			foreach (System.Data.DataRow dr in _dsDepositAlwInfo.Tables[ctDepositAlwDataTable].Rows)
			{
				total += Convert.ToInt64(dr[ctDepositAllowance]);
			}

			return total;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 入金引当DetaRowセット処理
		/// </summary>
		/// <param name="drNew">入金引当DataRow</param>
		/// <param name="depositAlwWork">入金引当クラス</param>
		/// <remarks>
		/// <br>Note　　　  : 入金引当をDataRowにセットします。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDepositAlw(System.Data.DataRow drNew, DepositAlwWork depositAlwWork)
		{
			// 入金伝票番号
			drNew[ctDepositSlipNo] = depositAlwWork.DepositSlipNo;

			// 受注伝票番号
			// drNew[ctAcceptAnOrderNo] = depositAlwWork.AcceptAnOrderNo;  // 2007.10.05 hikita del

            // ↓ 20070131 18322 d MA.NS用に変更
			//// 入金引当額 受注
			//drNew[ctAcpOdrDepositAlwc] = depositAlwWork.AcpOdrDepositAlwc;
            //
			//// 入金引当額 諸費用
			//drNew[ctVarCostDepoAlwc] = depositAlwWork.VarCostDepoAlwc;
            // ↑ 20070131 18322 d

			// 入金引当額 共通
			drNew[ctDepositAllowance] = depositAlwWork.DepositAllowance;

            // ↓ 20070418 18322 c MA.NS対応
			//// 引当日(表示用)
			//drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", depositAlwWork.ReconcileDate);

			// 引当日(表示用)
			drNew[ctReconcileDateDisp] = depositAlwWork.ReconcileDate.ToString("yyyy/MM/dd");
            // ↑ 20070418 18322 c

			// 引当日
			drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(depositAlwWork.ReconcileDate);

			// 引当計上日付
			drNew[ctReconcileAddUpADate] = TDateTime.DateTimeToLongDate(depositAlwWork.ReconcileAddUpDate);
		}
		# endregion
	}
}
