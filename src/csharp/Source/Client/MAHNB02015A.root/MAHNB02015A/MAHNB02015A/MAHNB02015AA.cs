using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 入金確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金確認表で使用するデータを取得する。</br>
    /// <br>Programmer : 22013 久保 将太</br>
    /// <br>Date       : 2007.03.06</br>
	/// <br>Updatenote	:	・2007.06.27 22013 kubo</br>
	/// <br>			:		初回印刷時、帳票フッターが印刷されない現象を修正</br>
    /// <br>UpdateNote	:   ・2007.11.14 980035 金沢 貞義</br>
    ///					:	    DC.NS対応（「入金一覧表」⇒「入金確認表」に変更）
    /// <br>UpdateNote  :   ・2008.01.30 980035 金沢 貞義</br>
    /// <br>                    DC.NS対応（不具合修正）</br>
    /// <br>UpdateNote  :   ・2008.07.09 30413 犬飼</br>
    /// <br>                    PM.NS対応</br>
    /// <br>Update Note : 2009/03/26 30452 上野 俊治</br>
    /// <br>             ・障害対応11735</br>
    /// <br>Update Note : 2009/11/20 30517 夏野 駿希</br>
    /// <br>             ・1行印字対応修正</br>
    /// <br>Update Note : 2010/05/26 22018 鈴木 正臣</br>
    /// <br>             ・"入金値引"を"その他"に合算する際、入金設定に従うように修正。</br>
    /// <br>Update Note : 2011/10/27 凌小青</br>
    ///  <br>             Redmine#26259の対応</br>　　
    /// </remarks>
	public class DepositMainAcs
	{
		#region ■ Constructor
		/// <summary>
        /// 入金確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入金確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		public DepositMainAcs()
		{
			this._iDepsitListWorkDB = (IDepsitListWorkDB)MediationDepsitListWorkDB.GetDepsitListWorkDB();

			this._moneyKindAcs = new MoneyKindAcs();		// 金種設定アクセスクラス

            // 2008.07.10 30413 犬飼 入金設定アクセスクラス追加 >>>>>>START
            this._depositStAcs = new DepositStAcs();        // 入金設定アクセスクラス
            // 2008.07.10 30413 犬飼 入金設定アクセスクラス追加 <<<<<<END
        }

		/// <summary>
        /// 入金確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 入金確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		static DepositMainAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
			stc_depositKindSortList = new SortedList();	// 入金金種リスト

            // 2008.07.10 30413 犬飼 入金設定金種リスト >>>>>>START
            stc_dicDepositStRowNo = new Dictionary<Int32, Int32>();
            stc_dicDepositStKindCd = new Dictionary<Int32, Int32>();
            // 2008.07.10 30413 犬飼 入金設定金種リスト <<<<<<END

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
		IDepsitListWorkDB _iDepsitListWorkDB;

		private MoneyKindAcs _moneyKindAcs;		// 金種設定アクセスクラス

        // 2008.07.10 30413 犬飼 入金設定アクセスクラス追加 >>>>>>START
        private DepositStAcs _depositStAcs;     // 入金設定アクセスクラス
        // 2008.07.10 30413 犬飼 入金設定アクセスクラス追加 <<<<<<END
        
		private DataSet _depositDs;				// 入金データセット

		private static SortedList stc_depositKindSortList;	// 入金金種リスト

        // 2008.07.10 30413 犬飼 入金設定金種リスト >>>>>>START
        private static Dictionary<Int32, Int32> stc_dicDepositStRowNo;
        private static Dictionary<Int32, Int32> stc_dicDepositStKindCd;
        // 2008.07.10 30413 犬飼 入金設定金種リスト <<<<<<END

        // --- ADD m.suzuki 2010/05/26 ---------->>>>>
        private const int ct_DEPOSIT_OTHERS = 58; // 58:その他
        // --- ADD m.suzuki 2010/05/26 ----------<<<<<

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 入金データセット(読み取り専用)
		/// </summary>
		public DataSet DepositDs
		{
			get{ return this._depositDs; }
		}
		#endregion ■ Public Property

		#region ■ Static Public Method
		#endregion ■ Static Public Method

		#region ■ Static Private Method
		#endregion ■ Static Private Method

		#region ■ Public Method
		#region ◆ 出力データ取得

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 入金データ取得
        ///// <summary>
        ///// 入金データ取得
        ///// </summary>
        ///// <param name="depositmainCndtn">抽出条件</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 印刷する入金データを取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //public int SearchDepositMain( DepositMainCndtn depositmainCndtn, out string errMsg )
        //{
        //    return this.SearchDepositMainProc( depositmainCndtn, out errMsg );
        //}
        #endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END
		

        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 入金・引当データ同時取得
        ///// <summary>
        ///// 入金・引当データ同時取得
        ///// </summary>
        ///// <param name="depositmainCndtn">抽出条件</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 印刷する入金データと引当データを取得する。。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //public int SearchDepositMainAllowance( DepositMainCndtn depositmainCndtn, out string errMsg )
        //{
        //	return this.SearchDepositMainAllowanceProc( depositmainCndtn, out errMsg );
        //}
		#endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 入金総合計データ取得
        ///// <summary>
        ///// 入金総合計データ取得
        ///// </summary>
        ///// <param name="depositmainCndtn">抽出条件</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 総合計用データを取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //public int SearchDepositGrandTotal( DepositMainCndtn depositmainCndtn, out string errMsg )
        //{
        //    return this.SearchDepositGrandTotalProc( depositmainCndtn, out errMsg );
        //}
		#endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 入金金種別集計データ取得
        ///// <summary>
        ///// 入金金種別集計データ取得
        ///// </summary>
        ///// <param name="depositmainCndtn">抽出条件</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 金種別集計用データを取得する。</br>
        ///// <br>Programmer : 980035 金沢 貞義</br>
        ///// <br>Date       : 2007.11.14</br>
        ///// </remarks>
        //public int SearchDepositDepositKind(DepositMainCndtn depositmainCndtn, out string errMsg)
        //{
        //    return this.SearchDepositDepositKindProc(depositmainCndtn, out errMsg);
        //}
        #endregion
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        #region ◎入金データ（入金確認表）取得[Public Method]
        /// <summary>
        /// 入金データ（入金確認表）取得
        /// </summary>
        /// <param name="depositmainCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入金データ（入金確認表）を取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        public int SearchDepositMainList(DepositMainCndtn depositmainCndtn, out string errMsg)
        {
            return this.SearchDepositMainListProc(depositmainCndtn, out errMsg);
        }
        #endregion

        #region ◎ 入金データ（入金確認表(集計表)）取得[Public Method]
        /// <summary>
        /// 入金データ（入金確認表(集計表)）取得
        /// </summary>
        /// <param name="depositmainCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入金データ（入金確認表(集計表)）を取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        public int SearchDepositMainList_Sum(DepositMainCndtn depositmainCndtn, out string errMsg)
        {
            return this.SearchDepositMainList_SumProc(depositmainCndtn, out errMsg);
        }
        #endregion

        #endregion ◆ 出力データ取得

        #region ◆ 帳票設定データ取得
        #region ◎ 金種設定取得
        /// <summary>
		/// 金種設定取得処理
		/// </summary>
		/// <param name="priceStCode">金額設定区分</param>
		/// <param name="retList"></param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 金種設定を取得する。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		public int SearchMoneyKind( int priceStCode, out SortedList retList, out string errMsg )
		{
			return this.SearchMoneyKindProc( priceStCode, out retList, out errMsg );
		}
		#endregion

        #region ◎ 入力設定マスタ金種名称取得
        /// <summary>
        /// 入力設定マスタ金種名称取得処理
        /// </summary>
        /// <param name="dicKindName">金種名称</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 入力設定マスタから金種コードを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.11</br>
        /// </remarks>
        public int SearchKindName(out Dictionary<int, string> dicKindName)
        {
            return this.GetKindName(out dicKindName);
        }
        #endregion

        #endregion ◆ 帳票設定データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 入金データ取得
        ///// <summary>
        ///// 入金データ取得
        ///// </summary>
        ///// <param name="depositMainCndtn"></param>
        ///// <param name="errMsg"></param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 印刷する入金データを取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //private int SearchDepositMainProc( DepositMainCndtn depositMainCndtn, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    errMsg = "";

        //    try
        //    {
        //        // DataTable Create ----------------------------------------------------------
        //        MAHNB02014EA.CreateDataTableDepositMain( ref this._depositDs );
        //        DepsitMainListParamWork depsitMainListCndtnWork = new DepsitMainListParamWork();
        //        // 抽出条件展開  --------------------------------------------------------------
        //        status = this.DevDepositMainCndtn( depositMainCndtn, out depsitMainListCndtnWork, out errMsg );
        //        if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
        //        {
        //            return status;
        //        }

        //        // データ取得  ----------------------------------------------------------------
        //        object retDepositMainList = null;
        //        status = this._iDepsitListWorkDB.SearchDepsitOnly( 
        //            out retDepositMainList, depsitMainListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
				
        //        switch ( status )
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                // データ展開処理
        //                DevDepositMainData( depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], (ArrayList)retDepositMainList );
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //                break;
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                break;
        //            default:
        //                errMsg = "入金データの取得に失敗しました。";
        //                break;
        //        }
        //    }
        //    catch ( Exception ex )
        //    {
        //        errMsg = ex.Message;
        //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    }
        //    return status;
        //}
        #endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 入金・引当データ同時取得
        ///// <summary>
        ///// 入金・引当データ同時取得
        ///// </summary>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 印刷する入金データと引当データを取得する。。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
		//private int SearchDepositMainAllowanceProc( DepositMainCndtn depositMainCndtn, out string errMsg)
		//{
		//	int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
		//	errMsg = "";
		//	try
		//	{
		//		// DataTable Create ----------------------------------------------------------
		//		MAHNB02014EA.CreateDataTableDepositMain( ref this._depositDs );
		//		MAHNB02014EB.CreateDataTableDepositAllowance( ref this._depositDs );
        //
		//		// 抽出条件展開 ---------------------------------------------------------------
        //        DepsitMainListParamWork depsitMainListCndtnWork = new DepsitMainListParamWork();
		//		status = this.DevDepositMainCndtn( depositMainCndtn, out depsitMainListCndtnWork, out errMsg );
		//		if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
		//		{
		//			return status;
		//		}
        //
		//		// データ取得 -----------------------------------------------------------------
		//		object retDepositMainList = null;
		//		object retDepositAlwList = null;
		//		status = this._iDepsitListWorkDB.SearchDepsitAndAllowance( 
		//			out retDepositMainList, out retDepositAlwList, depsitMainListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
		//		
		//		switch ( status )
		//		{
		//			case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//				{
		//					// データ展開処理
		//					DevDepositMainData( depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], (ArrayList)retDepositMainList );
		//					// 引当がない場合も考えられるのでnull以外のときのみ展開
		//					if ( retDepositAlwList != null )
		//					{
		//						DevDepositAllowanceData( this._depositDs.Tables[MAHNB02014EB.ct_Tbl_DepositAlw], (ArrayList)retDepositAlwList );
		//					}
		//					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		//					break;
		//				}
		//			case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//			case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//				status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
		//				break;
		//			default:
		//				errMsg = "引当データの取得に失敗しました。";
		//				break;
		//		}
        //
        //
		//		if ( ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) ||
		//			( status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) )
		//		{
		//			// リレーション作成 ----------------------------------------------------------
		//			DataColumn[] depMainCol = {
		//				this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain].Columns[MAHNB02014EA.ct_Col_AddUpSecCode],
		//				this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain].Columns[MAHNB02014EA.ct_Col_DepositSlipNo]
		//			};
		//			DataColumn[] depAlwCol = {
		//				this._depositDs.Tables[MAHNB02014EB.ct_Tbl_DepositAlw].Columns[MAHNB02014EB.ct_Col_DepositAddupSecCd],
		//				this._depositDs.Tables[MAHNB02014EB.ct_Tbl_DepositAlw].Columns[MAHNB02014EB.ct_Col_DepositSlipNo]
		//			};
        //
		//			// 入金データ.[入金計上拠点コード] ⇔ 引当データ.[入金計上拠点コード]
		//			// 入金データ.[入金伝票番号] ⇔ 引当データ.[入金伝票番号]
		//			DataRelation depRelation = new DataRelation( MAHNB02014EB.ct_Rel_DepositAlw, depMainCol, depAlwCol, false );
		//			this._depositDs.Relations.Add(depRelation);
		//		}
        //	}
        //	catch ( Exception ex )
        //	{
        //		errMsg = ex.Message;
        //		status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //	}
        //	return status;
        //}
        #endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 入金総合計データ取得
        ///// <summary>
        ///// 入金総合計データ取得
        ///// </summary>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 総合計用データを取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //private int SearchDepositGrandTotalProc( DepositMainCndtn depositMainCndtn, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    errMsg = "";

        //    try
        //    {
        //        // DataTable Create ----------------------------------------------------------
        //        MAHNB02014EA.CreateDataTableDepositMain( ref this._depositDs );
	
        //        // 抽出条件展開 ---------------------------------------------------------------
        //        DepsitMainListParamWork depsitMainListCndtnWork = new DepsitMainListParamWork();
        //        status = this.DevDepositMainCndtn( depositMainCndtn, out depsitMainListCndtnWork, out errMsg );
        //        if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
        //        {
        //            return status;
        //        }

        //        // データ取得  ----------------------------------------------------------------
        //        object retDepositMainList = null;
        //        // 2008.07.09 30413 犬飼 メソッドの変更 >>>>>>START
        //        status = this._iDepsitListWorkDB.SearchDepsitOnly( 
        //            out retDepositMainList, depsitMainListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
        //        //status = this._iDepsitListWorkDB.SearchAllTotal( 
        //        //    out retDepositMainList, depsitMainListCndtnWork, 0, 0, ConstantManagement.LogicalMode.GetData0);
        //        // 2008.07.09 30413 犬飼 メソッドの変更 <<<<<<END
				
        //        switch ( status )
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                // データ展開処理
        //                DevGrandTotalDepositMainData( depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], (ArrayList)retDepositMainList );
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //                break;
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                break;
        //            default:
        //                errMsg = "入金データの取得に失敗しました。";
        //                break;
        //        }
        //    }
        //    catch ( Exception ex )
        //    {
        //        errMsg = ex.Message;
        //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    }

        //    return status;
        //}
		#endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 入金金種別集計データ取得
        ///// <summary>
        ///// 入金金種別集計データ取得
        ///// </summary>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 金種別集計用データを取得する。</br>
        ///// <br>Programmer : 980035 金沢 貞義</br>
        ///// <br>Date       : 2007.11.14</br>
        ///// </remarks>
        //private int SearchDepositDepositKindProc(DepositMainCndtn depositMainCndtn, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    errMsg = "";

        //    try
        //    {
        //        // DataTable Create ----------------------------------------------------------
        //        MAHNB02014EA.CreateDataTableDepositMain(ref this._depositDs);

        //        // 抽出条件展開 ---------------------------------------------------------------
        //        DepsitMainListParamWork depsitMainListCndtnWork = new DepsitMainListParamWork();
        //        status = this.DevDepositMainCndtn(depositMainCndtn, out depsitMainListCndtnWork, out errMsg);
        //        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
        //        {
        //            return status;
        //        }

        //        // データ取得  ----------------------------------------------------------------
        //        object retDepositMainList = null;
        //        status = this._iDepsitListWorkDB.SearchAllTotal(
        //            out retDepositMainList, depsitMainListCndtnWork, 0, 0, ConstantManagement.LogicalMode.GetData0);
                
        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                // データ展開処理
        //                DevDepositKindData(depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], (ArrayList)retDepositMainList);
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //                break;
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                break;
        //            default:
        //                errMsg = "入金データの取得に失敗しました。";
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errMsg = ex.Message;
        //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    }

        //    return status;
        //}
        #endregion
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        #region ◎ 入金データ（入金確認表）取得[Private Method]
        /// <summary>
        /// 入金データ（入金確認表）取得
        /// </summary>
        /// <param name="depositMainCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する入金データを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        private int SearchDepositMainListProc(DepositMainCndtn depositMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                MAHNB02014EA.CreateDataTableDepositMain(ref this._depositDs);
                DepsitMainListParamWork depsitMainListCndtnWork = new DepsitMainListParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevDepositMainCndtn(depositMainCndtn, out depsitMainListCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retDepositMainList = null;
                status = this._iDepsitListWorkDB.SearchDepsitOnly(
                    out retDepositMainList, depsitMainListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 2008.07.14 30413 犬飼 ソート処理の追加 >>>>>>START
                        SortedList wkSort = new SortedList();

                        foreach (DepsitMainListResultWork wkDepsitMainListResultWork in (ArrayList)retDepositMainList)
                        {
                            string key = wkDepsitMainListResultWork.AddUpSecCode.Trim();
                            switch (depositMainCndtn.SortOrderDiv)
                            {
                                case DepositMainCndtn.SortOrderDivState.AddUpDate:
                                    {
                                        // 入金日順(計上拠点-入金日-入金伝票番号-入金行番号-請求先)
                                        key = key + TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, wkDepsitMainListResultWork.AddUpADate)
                                            + wkDepsitMainListResultWork.DepositSlipNo.ToString("d09")
                                            + wkDepsitMainListResultWork.DepositRowNo.ToString("d09")
                                            + wkDepsitMainListResultWork.ClaimCode.ToString("d09");
                                        break;
                                    }
                                case DepositMainCndtn.SortOrderDivState.CreateDate:
                                    {
                                        // 入力日順(計上拠点-入力日-入金伝票番号-入金行番号-請求先)
                                        // 2009.02.16 30413 犬飼 入力日を作成日時に修正 >>>>>>START
                                        //key = key + TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, wkDepsitMainListResultWork.DepositDate)
                                        //key = key + TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, wkDepsitMainListResultWork.CreateDateTime) // DEL 2009/03/26
                                        key = key + this.DateTimeToStringForSortKey(wkDepsitMainListResultWork.InputDay) // ADD 2009/03/26
                                            + wkDepsitMainListResultWork.DepositSlipNo.ToString("d09")
                                            + wkDepsitMainListResultWork.DepositRowNo.ToString("d09")
                                            + wkDepsitMainListResultWork.ClaimCode.ToString("d09");
                                        // 2009.02.16 30413 犬飼 入力日を作成日時に修正 <<<<<<END
                                        break;
                                    }
                                case DepositMainCndtn.SortOrderDivState.DepositSlipNo:
                                    {
                                        // 伝票番号順(計上拠点-入金伝票番号-入金行番号-入金日-請求先)
                                        key = key + wkDepsitMainListResultWork.DepositSlipNo.ToString("d09")
                                            + wkDepsitMainListResultWork.DepositRowNo.ToString("d09")
                                            + TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, wkDepsitMainListResultWork.AddUpADate)
                                            + wkDepsitMainListResultWork.ClaimCode.ToString("d09");
                                        break;
                                    }
                                default:
                                    {
                                        // デフォルトは入金日順とする
                                        key = key + TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, wkDepsitMainListResultWork.AddUpADate)
                                            + wkDepsitMainListResultWork.DepositSlipNo.ToString("d09")
                                            + wkDepsitMainListResultWork.DepositRowNo.ToString("d09")
                                            + wkDepsitMainListResultWork.ClaimCode.ToString("d09");
                                        break;
                                    }
                            }
                            // 取得した抽出結果をソート
                            wkSort.Add(key, wkDepsitMainListResultWork);
                        }

                        ArrayList wkDepositMainList = new ArrayList();

                        for (int index = 0; index < wkSort.Count; index++)
                        {
                            wkDepositMainList.Add(wkSort.GetByIndex(index));
                        }
                        // 2008.07.14 30413 犬飼 ソート処理の追加 >>>>>>START
                        
                        // データ展開処理
                        // 2008.07.14 30413 犬飼 ソート済のリストを引数に設定 >>>>>>START
                        //DevDepositMainListData(depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], (ArrayList)retDepositMainList);
                        DevDepositMainListData(depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], wkDepositMainList);
                        // 2008.07.14 30413 犬飼 ソート済のリストを引数に設定 <<<<<<END
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "入金データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 入金データ（入金確認表(集計表)）取得[Private Method]
        /// <summary>
        ///  入金データ（入金確認表(集計表)）取得
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       :  入金データ（入金確認表(集計表)）を取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        private int SearchDepositMainList_SumProc(DepositMainCndtn depositMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                MAHNB02014EA.CreateDataTableDepositMain(ref this._depositDs);

                // 抽出条件展開 ---------------------------------------------------------------
                DepsitMainListParamWork depsitMainListCndtnWork = new DepsitMainListParamWork();
                status = this.DevDepositMainCndtn(depositMainCndtn, out depsitMainListCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retDepositMainList = null;
                // 2008.07.09 30413 犬飼 メソッドの変更 >>>>>>START
                status = this._iDepsitListWorkDB.SearchDepsitOnly(
                    out retDepositMainList, depsitMainListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //status = this._iDepsitListWorkDB.SearchAllTotal(
                //    out retDepositMainList, depsitMainListCndtnWork, 0, 0, ConstantManagement.LogicalMode.GetData0);
                // 2008.07.09 30413 犬飼 メソッドの変更 <<<<<<END

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 2008.07.22 30413 犬飼 ソート処理の追加 >>>>>>START
                        SortedList wkSort = new SortedList();

                        foreach (DepsitMainListResultWork wkDepsitMainListResultWork in (ArrayList)retDepositMainList)
                        {
                            // 入金確認表(集計表)は得意先コード（請求先コード）順とする
                            string key = wkDepsitMainListResultWork.AddUpSecCode.Trim();
                            // 拠点-請求先-入金日-入金伝票番号-入金行番号
                            key = key + wkDepsitMainListResultWork.ClaimCode.ToString("d09")
                                + TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, wkDepsitMainListResultWork.AddUpADate)
                                + wkDepsitMainListResultWork.DepositSlipNo.ToString("d09")
                                + wkDepsitMainListResultWork.DepositRowNo.ToString("d09");

                            // 取得した抽出結果をソート
                            wkSort.Add(key, wkDepsitMainListResultWork);
                        }

                        ArrayList wkDepositMainList = new ArrayList();

                        for (int index = 0; index < wkSort.Count; index++)
                        {
                            wkDepositMainList.Add(wkSort.GetByIndex(index));
                        }
                        // 2008.07.22 30413 犬飼 ソート処理の追加 >>>>>>START

                        // データ展開処理
                        //DevDepositMainListData(depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], (ArrayList)retDepositMainList);
                        DevDepositMainListSumData(depositMainCndtn, this._depositDs.Tables[MAHNB02014EA.ct_Tbl_DepositMain], wkDepositMainList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "入金データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        // --- ADD 2009/03/26 -------------------------------->>>>>
        #region ◎ ソートKey用DateTime⇒String変換
        private string DateTimeToStringForSortKey(DateTime dateTime)
        {
            string dateTimeStr = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, dateTime);

            if (string.IsNullOrEmpty(dateTimeStr))
            {
                return "0000/00/00";
            }
            else
            {
                return dateTimeStr;
            }
        }
        #endregion
        // --- ADD 2009/03/26 -------------------------------->>>>>
        #endregion ◆ 帳票データ取得

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
		/// <param name="depositMainCndtn">UI抽出条件クラス</param>
		/// <param name="depsitMainListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevDepositMainCndtn(DepositMainCndtn depositMainCndtn, out DepsitMainListParamWork depsitMainListCndtnWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // 2008.07.22 30413 犬飼 未使用プロパティのコメント化 >>>>>>START
            //int sortOrder = 0;
            // 2008.07.22 30413 犬飼 未使用プロパティのコメント化 <<<<<<END
            errMsg = string.Empty;
			depsitMainListCndtnWork = new DepsitMainListParamWork();

			try
			{
                // 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
                //depsitMainListCndtnWork.EnterPriseCode = depositMainCndtn.EnterpriseCode;
                depsitMainListCndtnWork.EnterpriseCode = depositMainCndtn.EnterpriseCode;
                // 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<

				// 企業コード
				// 抽出条件パラメータセット
				if ( depositMainCndtn.DepositAddupSecCodeList.Length != 0 )
				{
					if ( depositMainCndtn.IsSelectAllSection )
					{
						// 全社の時
						depsitMainListCndtnWork.DepositAddupSecCodeList = null;
					}
					else
					{
						depsitMainListCndtnWork.DepositAddupSecCodeList = depositMainCndtn.DepositAddupSecCodeList;
					}
				}
				else
				{
					depsitMainListCndtnWork.DepositAddupSecCodeList = null;
				}

                // 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
                //depsitMainListCndtnWork.St_AddUpADate         = depositMainCndtn.St_AddUpADate;           // 開始入金計上日
                //depsitMainListCndtnWork.Ed_AddupADate         = depositMainCndtn.Ed_AddupADate;           // 終了入金計上日
                // 2008.07.18 30413 犬飼 入金計上日の設定方法変更 >>>>>>START
                //depsitMainListCndtnWork.St_AddUpADate = TDateTime.DateTimeToLongDate(depositMainCndtn.St_AddUpADate); // 開始入金計上日
                //depsitMainListCndtnWork.Ed_AddUpADate			= TDateTime.DateTimeToLongDate(depositMainCndtn.Ed_AddupADate); // 終了入金計上日
                // 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<
                if (depositMainCndtn.St_AddUpADate == System.DateTime.MinValue)
                {
                    depsitMainListCndtnWork.St_AddUpADate = 0;                                                              // 開始入金計上日
                }
                else
                {
                    depsitMainListCndtnWork.St_AddUpADate = TDateTime.DateTimeToLongDate(depositMainCndtn.St_AddUpADate);   // 開始入金計上日
                }

                if (depositMainCndtn.Ed_AddupADate == System.DateTime.MinValue)
                {
                    depsitMainListCndtnWork.Ed_AddUpADate = 0;                                                              // 終了入金計上日
                }
                else
                {
                    depsitMainListCndtnWork.Ed_AddUpADate = TDateTime.DateTimeToLongDate(depositMainCndtn.Ed_AddupADate);   // 終了入金計上日
                }
                // 2008.07.18 30413 犬飼 入金計上日の設定方法変更 <<<<<<END


                // 2008.07.18 30413 犬飼 入力日の設定方法変更 >>>>>>START
                // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                //depsitMainListCndtnWork.St_CreateDate = TDateTime.DateTimeToLongDate(depositMainCndtn.St_CreateDate); // 開始入力日
                if (depositMainCndtn.St_CreateDate == System.DateTime.MinValue)
                {
                    depsitMainListCndtnWork.St_CreateDate = 0;                                                              // 開始入力日
                }
                else
                {
                    depsitMainListCndtnWork.St_CreateDate = TDateTime.DateTimeToLongDate(depositMainCndtn.St_CreateDate);   // 開始入力日
                }
                if (depositMainCndtn.Ed_CreateDate == System.DateTime.MinValue)
                {
                    //depsitMainListCndtnWork.Ed_CreateDate = 99999999;                                                       // 終了入力日
                    depsitMainListCndtnWork.Ed_CreateDate = 0;                                                              // 終了入力日
                }
                else
                {
                    depsitMainListCndtnWork.Ed_CreateDate = TDateTime.DateTimeToLongDate(depositMainCndtn.Ed_CreateDate);   // 終了入力日
                }
                // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.07.18 30413 犬飼 入力日の設定方法変更 <<<<<<END

                depsitMainListCndtnWork.St_CustomerCode = depositMainCndtn.St_CustomerCode;			// 開始得意先コード
				depsitMainListCndtnWork.Ed_CustomerCode	= depositMainCndtn.Ed_CustomerCode;			// 終了得意先コード

                // 2008.07.18 30413 犬飼 得意先カナと担当者区分の削除 >>>>>>START
                //depsitMainListCndtnWork.St_CustomerKana = depositMainCndtn.St_CustomerKana;			// 開始得意先カナ
                //depsitMainListCndtnWork.Ed_CustomerKana			= depositMainCndtn.Ed_CustomerKana;			// 終了得意先カナ
                //depsitMainListCndtnWork.EmployeeKind			= (int)depositMainCndtn.EmployeeKindDiv;	// 担当者区分
                //// 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
                ////depsitMainListCndtnWork.St_EmployeeCode       = depositMainCndtn.St_EmployeeCode;			// 開始担当者コード
                ////depsitMainListCndtnWork.Ed_EmployeeCode       = depositMainCndtn.Ed_EmployeeCode;			// 終了担当者コード
                //depsitMainListCndtnWork.St_EmployeeCd           = depositMainCndtn.St_EmployeeCode;			// 開始担当者コード
                //depsitMainListCndtnWork.Ed_EmployeeCd           = depositMainCndtn.Ed_EmployeeCode;			// 終了担当者コード
                //// 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<
                // 2008.07.18 30413 犬飼 得意先カナと担当者区分、担当者コードの削除 >>>>>>START
                
                // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
                //// 個人法人区分
				//ArrayList corpDivWork = new ArrayList();
				//foreach ( DictionaryEntry de in depositMainCndtn.CorporateDivCode )
				//{
				//	corpDivWork.Add( (int)de.Key );
				//}
                //depsitMainListCndtnWork.CorporateDivCode = corpDivWork;
                // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
                //depsitMainListCndtnWork.CorporateDivCode		= new ArrayList( depositMainCndtn.CorporateDivCode.Keys );
				depsitMainListCndtnWork.St_DepositSlipNo		= depositMainCndtn.St_DepositSlipNo;		// 開始入金番号
				depsitMainListCndtnWork.Ed_DepositSlipNo		= depositMainCndtn.Ed_DepositSlipNo;		// 終了入金番号
				// 入金金種
				depsitMainListCndtnWork.DepositCdKind			= new ArrayList( depositMainCndtn.DepositKind.Keys );
                // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
                //depsitMainListCndtnWork.CreditOrLoanCd        = (int)depositMainCndtn.CreditOrLoanCd;		// クレジットローン区分
                // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
                // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
                //depsitMainListCndtnWork.DepositCd = (int)depositMainCndtn.DepositCd;			// 預かり金区分

                // 2008.07.23 30413 犬飼 入金区分の設定を変更 >>>>>>START
                //switch (depositMainCndtn.DepositCd)                                             // 預かり金区分
                //{
                //    case DepositMainCndtn.DepositCdState.All:
                //        {
                //            depsitMainListCndtnWork.DepositCd = 0;
                //            break;
                //        }
                //    case DepositMainCndtn.DepositCdState.Nomal:
                //        {
                //            depsitMainListCndtnWork.DepositCd = 1;
                //            break;
                //        }
                //    case DepositMainCndtn.DepositCdState.Keep:
                //        {
                //            depsitMainListCndtnWork.DepositCd = 2;
                //            break;
                //        }
                //    case DepositMainCndtn.DepositCdState.Auto:
                //        {
                //            // 2008.07.23 30413 犬飼 預り金入金の削除 >>>>>>START
                //            depsitMainListCndtnWork.DepositCd = 3;
                //            break;
                //        }
                //}
                // 2008.09.24 30413 犬飼 入金区分のプロパティを変更 >>>>>>START
                //depsitMainListCndtnWork.DepositCd = (int)depositMainCndtn.DepositCd;            // 入金区分
                depsitMainListCndtnWork.DepositDiv = (int)depositMainCndtn.DepositCd;            // 入金区分
                // 2008.09.24 30413 犬飼 入金区分のプロパティを変更 <<<<<<END
                // 2008.07.23 30413 犬飼 入金区分の設定を変更 <<<<<<END
                
                // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
                depsitMainListCndtnWork.AllowanceDiv = (int)depositMainCndtn.AllowanceDiv;		// 引当区分
                // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
				//depsitMainListCndtnWork.DebitNoteDiv			= 0;										// 赤伝区分
				//depsitMainListCndtnWork.DebitNLnkAcptAnOdr		= 0;										// 赤黒連結受注番号
                // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.22 30413 犬飼 帳票タイプ区分の設定変更 >>>>>>START
                // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                //depsitMainListCndtnWork.PrintDiv                = depositMainCndtn.PrintDiv;                // 帳票タイプ区分
                // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

                switch ((DepositMainCndtn.PrintDivState)depositMainCndtn.PrintDiv)
                {
                    case DepositMainCndtn.PrintDivState.DepsitMainList:         // 入金確認表
                        {
                            depsitMainListCndtnWork.PrintDiv = 2;       // 帳票タイプ区分(簡易)
                            break;
                        }
                    case DepositMainCndtn.PrintDivState.DepositMainList_Sum:    // 入金確認表(集計表)
                        {
                            depsitMainListCndtnWork.PrintDiv = 3;       // 帳票タイプ区分(金種別集計)
                            break;
                        }
                }
                // 2008.07.22 30413 犬飼 帳票タイプ区分の設定変更 <<<<<<END
                
                // 2008.07.09 30413 犬飼 リモートでのソートは無し >>>>>>START
                //// ソート順作成 ソート順 = 小計区分 * 10 + 出力順
                //// 【日計】		0:計上日付-得意先ｺｰﾄﾞ順, 1:計上日付-得意先ｶﾅ順, 2:計上日付-担当者ｺｰﾄﾞ順,
                //// 【伝票番号】	3:入金伝票番号順, 
                //// 【得意先計】	10:得意先ｺｰﾄﾞ-計上日付順, 11:得意先ｶﾅ-得意先ｺｰﾄﾞ順, 12:得意先ｺｰﾄﾞ-担当者ｺｰﾄﾞ順,
                //// 【金種計】	20:入金金種ｺｰﾄﾞ-得意先ｺｰﾄﾞ順, 21:入金金種ｺｰﾄﾞ-得意先ｶﾅ順, 22:入金金種ｺｰﾄﾞ:担当者ｺｰﾄﾞ順
                //if ( (int)depositMainCndtn.SumDiv == (int)DepositMainCndtn.SumDivState.DepositSlipNo )
                //    sortOrder = 3;
                //else
                //    sortOrder = GetSortOrder( (int)depositMainCndtn.SumDiv, (int)depositMainCndtn.SortOrderDiv );

                //depsitMainListCndtnWork.SortOrder = sortOrder;
                // 2008.07.09 30413 犬飼 リモートでのソートは無し <<<<<<END
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        //private int GetSortOrder(int sumDiv, int sortOrderDiv)
        //{
        //    return sumDiv * 10 + sortOrderDiv;
        //}
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END
		#endregion

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 入金データ展開処理
        ///// <summary>
        ///// 入金データ展開処理
        ///// </summary>
        ///// <param name="depositMainCndtn">UI抽出条件クラス</param>
        ///// <param name="depositMainDt">展開対象DataTable</param>
        ///// <param name="depositMainWork">取得データ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 入金データを展開する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //private void DevDepositMainData ( DepositMainCndtn depositMainCndtn, DataTable depositMainDt, ArrayList depositMainWork )
        //{
        //    string workStr_1 = "";
        //    string workStr_2 = "";
        //    DataRow dr;
        //    foreach ( DepsitMainListResultWork depmainResWork in depositMainWork )
        //    {
        //        dr =depositMainDt.NewRow();
        //        // 入金基本データ展開
        //        #region 入金データ展開
        //        GetDebitNoteCdName( depmainResWork.DepositDebitNoteCd, out workStr_1, out workStr_2 );
        //        // 入金赤黒区分
        //        dr[MAHNB02014EA.ct_Col_DepositDebitNoteCd		] = depmainResWork.DepositDebitNoteCd;
        //        // 入金赤黒区分名称
        //        dr[MAHNB02014EA.ct_Col_DepositDebitNoteCdName	] = workStr_1.TrimEnd();
        //        // 入金赤黒区分記号
        //        dr[MAHNB02014EA.ct_Col_DepositDebitNoteSign		] = workStr_2.TrimEnd();
        //        // 入金伝票番号
        //        dr[MAHNB02014EA.ct_Col_DepositSlipNo			] = depmainResWork.DepositSlipNo;
        //        // 赤黒入金連結番号
        //        dr[MAHNB02014EA.ct_Col_DebitNoteLinkDepoNo] = depmainResWork.DebitNoteLinkDepoNo;
        //        // 入金入力拠点コード
        //        dr[MAHNB02014EA.ct_Col_InputDepositSecCd		] = depmainResWork.InputDepositSecCd;
        //        // 入金入力拠点名称
        //        dr[MAHNB02014EA.ct_Col_InputDepositSecNm		] = depmainResWork.InputDepositSecNm.TrimEnd();
        //        // 計上拠点コード
        //        dr[MAHNB02014EA.ct_Col_AddUpSecCode				] = depmainResWork.AddUpSecCode;
        //        // 計上拠点名称
        //        // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
        //        //if (depositMainCndtn.IsSelectAllSection)
        //        //    dr[MAHNB02014EA.ct_Col_AddUpSecName				] = "全社";
        //        //else
        //        //    dr[MAHNB02014EA.ct_Col_AddUpSecName				] = depmainResWork.AddUpSecName.TrimEnd();
        //        dr[MAHNB02014EA.ct_Col_AddUpSecName             ] = depmainResWork.AddUpSecName.TrimEnd();
        //        // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
        //        // 計上拠点名称(明細)
        //        dr[MAHNB02014EA.ct_Col_AddUpSecName_Detail		] = depmainResWork.AddUpSecName.TrimEnd();
        //        // 入金日(表示用)
        //        dr[MAHNB02014EA.ct_Col_DepositDate				] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DepositDate);
        //        // 入金日(ソート用)
        //        dr[MAHNB02014EA.ct_Col_Sort_DepositDate			] = TDateTime.DateTimeToLongDate(depmainResWork.DepositDate);
        //        // 計上日付
        //        dr[MAHNB02014EA.ct_Col_AddUpADate				] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.AddUpADate);
        //        // 計上日付(ソート用)
        //        dr[MAHNB02014EA.ct_Col_Sort_AddUpADate			] = TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate);
        //        // 入金金種コード
        //        dr[MAHNB02014EA.ct_Col_DepositKindCode] = depmainResWork.DepositKindCode;
        //        // 入金金種名称
        //        dr[MAHNB02014EA.ct_Col_DepositKindName] = depmainResWork.DepositKindName;
        //        // 入金金種区分
        //        dr[MAHNB02014EA.ct_Col_DepositKindDivCd] = depmainResWork.DepositKindDivCd;
        //        // 入金計
        //        dr[MAHNB02014EA.ct_Col_DepositTotal				] = depmainResWork.DepositTotal;
        //        // 入金金額
        //        dr[MAHNB02014EA.ct_Col_Deposit					] = depmainResWork.Deposit;
        //        // 手数料入金額
        //        dr[MAHNB02014EA.ct_Col_FeeDeposit				] = depmainResWork.FeeDeposit;
        //        // 値引入金額
        //        dr[MAHNB02014EA.ct_Col_DiscountDeposit			] = depmainResWork.DiscountDeposit;
        //        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //        //// リベート入金額
        //        //dr[MAHNB02014EA.ct_Col_RebateDeposit			] = depmainResWork.RebateDeposit;
        //        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //        // 自動入金区分
        //        dr[MAHNB02014EA.ct_Col_AutoDepositCd			] = depmainResWork.AutoDepositCd;
        //        // 自動入金区分名称
        //        dr[MAHNB02014EA.ct_Col_AutoDepositCdName		] = depmainResWork.AutoDepositCd == 0 ? "通常入金" : "自動入金";
        //        // 預り金区分
        //        dr[MAHNB02014EA.ct_Col_DepositCd				] = depmainResWork.DepositCd;
        //        // 預り金区分名称
        //        dr[MAHNB02014EA.ct_Col_DepositCdName			] = depmainResWork.DepositCd == 0 ? "通常入金" : "預り金入金";
        //        // 預り金記号
        //        if ( depmainResWork.AutoDepositCd == 0 )
        //        {
        //            // 通常入金のとき
        //            dr[MAHNB02014EA.ct_Col_DepositCdSign			] = depmainResWork.DepositCd == 0 ? "" : "預";
        //        }
        //        else
        //        {
        //            // 自動入金のとき
        //            dr[MAHNB02014EA.ct_Col_DepositCdSign			] = "自";
        //        }
        //        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //        //// クレジット/ローン区分
        //        //dr[MAHNB02014EA.ct_Col_CreditOrLoanCd			] = depmainResWork.CreditOrLoanCd;
        //        //// クレジット/ローン区分名称
        //        //if ( depmainResWork.CreditOrLoanCd == 1 )		dr[MAHNB02014EA.ct_Col_CreditOrLoanCdNm] = "クレジット";
        //        //else if ( depmainResWork.CreditOrLoanCd == 2 )	dr[MAHNB02014EA.ct_Col_CreditOrLoanCdNm] = "ローン";
        //        //else											dr[MAHNB02014EA.ct_Col_CreditOrLoanCdNm] = "";
        //        //
        //        //// クレジット会社コード
        //        //dr[MAHNB02014EA.ct_Col_CreditCompanyCode		] = depmainResWork.CreditCompanyCode;
        //        //// クレジット会社名称
        //        //dr[MAHNB02014EA.ct_Col_CreditCompanyName		] = depmainResWork.CreditCompanyName;
        //        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //        // 手形振出日	
        //        dr[MAHNB02014EA.ct_Col_DraftDrawingDate			] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DraftDrawingDate);
        //        // 手形支払期日
        //        dr[MAHNB02014EA.ct_Col_DraftPayTimeLimit] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DraftPayTimeLimit);
        //        // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
        //        // 手形種類
        //        dr[MAHNB02014EA.ct_Col_DraftKind                ] = depmainResWork.DraftKind;
        //        // 手形種類名称
        //        dr[MAHNB02014EA.ct_Col_DraftKindName            ] = depmainResWork.DraftKindName;
        //        // 手形区分
        //        dr[MAHNB02014EA.ct_Col_DraftDivide              ] = depmainResWork.DraftDivide;
        //        // 手形区分名称
        //        dr[MAHNB02014EA.ct_Col_DraftDivideName          ] = depmainResWork.DraftDivideName;
        //        // 手形番号
        //        dr[MAHNB02014EA.ct_Col_DraftNo                  ] = depmainResWork.DraftNo;
        //        // 銀行コード
        //        dr[MAHNB02014EA.ct_Col_BankCode                 ] = depmainResWork.BankCode;
        //        // 銀行名称
        //        dr[MAHNB02014EA.ct_Col_BankName                 ] = depmainResWork.BankName;
        //        // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<
        //        // 手形振出日又はクレジット会社名称など
        //        dr[MAHNB02014EA.ct_Col_DraftOrCreditName		] = GetDraftOrCreditName( depmainResWork );
        //        // 入金引当額
        //        dr[MAHNB02014EA.ct_Col_DepositAllowance] = depmainResWork.DepositAllowance;
        //        // 入金引当残高
        //        dr[MAHNB02014EA.ct_Col_DepositAlwcBlnce] = depmainResWork.DepositAlwcBlnce;
        //        // 最終消し込み計上日
        //        dr[MAHNB02014EA.ct_Col_LastReconcileAddUpDt] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.LastReconcileAddUpDt);
        //        // 得意先コード
        //        dr[MAHNB02014EA.ct_Col_CustomerCode				] = depmainResWork.CustomerCode;
        //        // 得意先名称
        //        // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
        //        //dr[MAHNB02014EA.ct_Col_CustomerName           ] = depmainResWork.CustomerName;
        //        dr[MAHNB02014EA.ct_Col_CustomerName             ] = depmainResWork.CustomerSnm;
        //        // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
        //        // 得意先名称2
        //        dr[MAHNB02014EA.ct_Col_CustomerName2] = depmainResWork.CustomerName2;
        //        // カナ
        //        dr[MAHNB02014EA.ct_Col_Kana] = depmainResWork.CustomerKana;
        //        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //        //// 個人・法人区分
        //        //dr[MAHNB02014EA.ct_Col_CorporateDivCode			] = depmainResWork.CorporateDivCode;
        //        //// 個人・法人区分名称
        //        //dr[MAHNB02014EA.ct_Col_CorporateDivName			] = GetCorporateDivName( depmainResWork.CorporateDivCode );
        //        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //        // 伝票適用 
        //        dr[MAHNB02014EA.ct_Col_Outline					] = depmainResWork.Outline;
        //        // 担当者コード
        //        dr[MAHNB02014EA.ct_Col_AgentCode] = depmainResWork.AgentCode;
        //        // 担当者名称
        //        dr[MAHNB02014EA.ct_Col_AgentNm] = depmainResWork.AgentNm;
                
        //        // 小計区分を決める
        //        string miniTotal = string.Empty;
        //        switch ( depositMainCndtn.PrintDiv )
        //        {
        //            case (int)DepositMainCndtn.PrintDivState.GrandTotal:			// 総合計
        //            // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        //            case (int)DepositMainCndtn.PrintDivState.DepositKind:			// 金種別集計
        //                // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
        //                miniTotal = string.Empty;
        //                break;
        //            // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //            //case (int)DepositMainCndtn.PrintDivState.Details_HaveDraw:		// 詳細引当有
        //            // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //            case (int)DepositMainCndtn.PrintDivState.Details_NotDraw:		// 詳細引当無
        //            case (int)DepositMainCndtn.PrintDivState.Simple:				// 簡易
        //                {
        //                    // 小計区分で改ページ条件を選択
        //                    switch (depositMainCndtn.SumDiv)
        //                    {
        //                        case DepositMainCndtn.SumDivState.Day:				// 日計
        //                            miniTotal = TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate).ToString();
        //                            break;
        //                        case DepositMainCndtn.SumDivState.Customer:			// 得意先計
        //                            miniTotal = depmainResWork.CustomerCode.ToString();
        //                            break;
        //                        case DepositMainCndtn.SumDivState.DepositKind:		// 金種計
        //                            miniTotal = depmainResWork.DepositKindCode.ToString();
        //                            break;
        //                        case DepositMainCndtn.SumDivState.DepositSlipNo:	// 入金番号
        //                            miniTotal = string.Empty;	// 入金番号のときは小計を表示しない。
        //                            break;
        //                        default:
        //                            miniTotal = string.Empty;
        //                            break;
        //                    }
        //                    break;
        //                }
        //        default:
        //            miniTotal = string.Empty;
        //            break;
        //        }
        //        dr[MAHNB02014EA.ct_Col_MiniTotal_KeyBleak			] = miniTotal;
        //        #endregion

        //        // TableにAdd
        //        depositMainDt.Rows.Add( dr );

        //    }
        //}
        #endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 引当データ展開処理
        ///// <summary>
        ///// 引当データ展開処理
        ///// </summary>
        ///// <param name="depositAlwDt">展開対象DataTable</param>
        ///// <param name="depositAlwWork">取得データ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 引当データを展開する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
		//private void DevDepositAllowanceData ( DataTable depositAlwDt, ArrayList depositAlwWork )
		//{
		//	int		workInt		= -1;
		//	string	workStr_1	= "";
		//	string	workStr_2	= "";
		//	DataRow dr;
        //
		//	foreach ( DepsitAlwcListResultWork depAlwcResWork in depositAlwWork )
		//	{
		//		dr = depositAlwDt.NewRow();
        //
		//		#region 引当データ展開
		//		// 消込み計上日
		//		dr[MAHNB02014EB.ct_Col_ReconcileAddUpDate		] = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, depAlwcResWork.ReconcileAddUpDate );
		//		// 受注番号
		//		dr[MAHNB02014EB.ct_Col_AcceptAnOrderNo			] = depAlwcResWork.AcceptAnOrderNo;
		//		// 受注ステータス
		//		dr[MAHNB02014EB.ct_Col_AcptAnOdrStatus			] = depAlwcResWork.AcptAnOdrStatus;
		//		// 受注ステータス名称
		//		dr[MAHNB02014EB.ct_Col_AcptAnOdrStatusName		] = GetAcptAnOdrStatusName( depAlwcResWork.AcptAnOdrStatus, depAlwcResWork.SalesSlipKind );
		//		// 売上伝票番号
		//		dr[MAHNB02014EB.ct_Col_SalesSlipNum				] = depAlwcResWork.SalesSlipNum;
		//		// 承り伝票番号
		//		dr[MAHNB02014EB.ct_Col_AcptAnOdrSlipNum			] = depAlwcResWork.AcptAnOdrSlipNum;
		//		// 見積伝票番号
		//		dr[MAHNB02014EB.ct_Col_EstimateSlipNo			] = depAlwcResWork.EstimateSlipNo;
		//		// 赤伝区分
		//		dr[MAHNB02014EB.ct_Col_DebitNoteDiv				] = depAlwcResWork.DebitNoteDiv;
		//		// 赤伝区分名称
		//		GetDebitNoteCdName( depAlwcResWork.DebitNoteDiv, out workStr_1, out workStr_2 );
		//		dr[MAHNB02014EB.ct_Col_DebitNoteDivName		] =workStr_1.TrimEnd();
		//		// 赤黒連結受注番号
		//		dr[MAHNB02014EB.ct_Col_DebitNLnkAcptAnOdr	] = depAlwcResWork.DebitNLnkAcptAnOdr;
        //
		//		// 売上伝票区分
		//		dr[MAHNB02014EB.ct_Col_SalesSlipCd				] = depAlwcResWork.SalesSlipCd;
		//		// 売上伝票区分名称
		//		if ( depAlwcResWork.SalesSlipCd == 0 )		dr[MAHNB02014EB.ct_Col_SalesSlipCdName] = "売上";
		//		else if ( depAlwcResWork.SalesSlipCd == 1 )	dr[MAHNB02014EB.ct_Col_SalesSlipCdName] = "返品";
		//		else if ( depAlwcResWork.SalesSlipCd == 2 )	dr[MAHNB02014EB.ct_Col_SalesSlipCdName] = "値引";
		//		else										dr[MAHNB02014EB.ct_Col_SalesSlipCdName] = "";
		//		
		//		// 売上形式
		//		dr[MAHNB02014EB.ct_Col_SalesFormal				] = depAlwcResWork.SalesFormal;
		//		// 売上形式名称
		//		if ( depAlwcResWork.SalesFormal == 10 )			dr[MAHNB02014EB.ct_Col_SalesFormalName] = "店頭売上";
		//		else if ( depAlwcResWork.SalesSlipCd == 11 )	dr[MAHNB02014EB.ct_Col_SalesFormalName] = "外販";
		//		else if ( depAlwcResWork.SalesSlipCd == 20 )	dr[MAHNB02014EB.ct_Col_SalesFormalName] = "業務販売(売切)";
		//		else											dr[MAHNB02014EB.ct_Col_SalesFormalName] = "";
        //
		//		// 売上入力拠点コード
		//		dr[MAHNB02014EB.ct_Col_SalesInpSecCd			] = depAlwcResWork.SalesInpSecCd;
		//		// 売上入力拠点名称
		//		dr[MAHNB02014EB.ct_Col_SalesInpSecNm			] = depAlwcResWork.SalesInpSecNm.TrimEnd();
		//		// 請求計上拠点コード
		//		dr[MAHNB02014EB.ct_Col_ResultsAddUpSecCd		] = depAlwcResWork.ResultsAddUpSecCd;
		//		// 請求計上拠点名称
		//		dr[MAHNB02014EB.ct_Col_ResultsAddUpSecNm		] = depAlwcResWork.ResultsAddUpSecNm.TrimEnd();
		//		// 実績計上拠点コード
		//		dr[MAHNB02014EB.ct_Col_UpdateSecCd				] = depAlwcResWork.UpdateSecCd;
		//		// 実績計上拠点名称
		//		dr[MAHNB02014EB.ct_Col_UpdateSecNm				] = depAlwcResWork.UpdateSecNm.TrimEnd();
		//		// 見積日付
		//		dr[MAHNB02014EB.ct_Col_EstimateDate				] = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, depAlwcResWork.EstimateDate );
		//		// ソート用見積日付
		//		dr[MAHNB02014EB.ct_Col_Sort_EstimateDate		] = TDateTime.DateTimeToLongDate( depAlwcResWork.EstimateDate );
		//		// 受注日
		//		dr[MAHNB02014EB.ct_Col_AcceptAnOrderDate		] = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, depAlwcResWork.AcceptAnOrderDate );
		//		// ソート用受注日
		//		dr[MAHNB02014EB.ct_Col_Sort_AcceptAnOrderDate	] = TDateTime.DateTimeToLongDate( depAlwcResWork.AcceptAnOrderDate );
		//		// 売上日付
		//		dr[MAHNB02014EB.ct_Col_SalesDate				] = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, depAlwcResWork.SalesDate );
		//		// ソート用売上日付
		//		dr[MAHNB02014EB.ct_Col_Sort_SalesDate			] = TDateTime.DateTimeToLongDate( depAlwcResWork.SalesDate );
		//		// 売上計上日付
		//		dr[MAHNB02014EB.ct_Col_SalesAddUpADate			] = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, depAlwcResWork.SalesAddUpADate );
		//		// ソート用売上計上日付
		//		dr[MAHNB02014EB.ct_Col_Sort_SalesAddUpADate		] = TDateTime.DateTimeToLongDate( depAlwcResWork.SalesAddUpADate );
		//		// 売掛区分
		//		dr[MAHNB02014EB.ct_Col_AccRecDivCd				] = depAlwcResWork.AccRecDivCd;
		//		// 売掛区分名称
		//		dr[MAHNB02014EB.ct_Col_AccRecDivCdName			] = depAlwcResWork.AccRecDivCd == 0 ? "売掛なし" : "売掛";
		//		// 請求合計額
		//		dr[MAHNB02014EB.ct_Col_DemandableTtl				] = depAlwcResWork.DemandableTtl;
		//		// 入金引当合計額
		//		dr[MAHNB02014EB.ct_Col_DepositAllowanceTtl		] = depAlwcResWork.DepositAllowanceTtl;
		//		// 預り金引当合計額 
		//		dr[MAHNB02014EB.ct_Col_MnyDepoAllowanceTtl		] = depAlwcResWork.MnyDepoAllowanceTtl;
		//		// 入金引当残高
		//		dr[MAHNB02014EB.ct_Col_DepositAlwcBlnce			] = depAlwcResWork.DepositAlwcBlnce;
		//		// 引当状態取得
		//		GetAllowanceState( depAlwcResWork, out workInt, out workStr_1);
		//		// 引当状態
		//		dr[MAHNB02014EB.ct_Col_AllowanceState			] = workInt;
		//		// 引当状態名称
		//		dr[MAHNB02014EB.ct_Col_AllowanceStateName		] = workStr_1.TrimEnd();
        //
		//		// 請求先コード
		//		dr[MAHNB02014EB.ct_Col_ClaimCode				] = depAlwcResWork.ClaimCode;
		//		// 請求先名称1
		//		dr[MAHNB02014EB.ct_Col_ClaimName1				] = depAlwcResWork.ClaimName1.TrimEnd();
		//		// 請求先名称2
		//		dr[MAHNB02014EB.ct_Col_ClaimName2				] = depAlwcResWork.ClaimName2.TrimEnd();
		//		// 得意先コード
		//		dr[MAHNB02014EB.ct_Col_CustomerCode				] = depAlwcResWork.CustomerCode;
		//		// 得意先名称
		//		dr[MAHNB02014EB.ct_Col_CustomerName				] = depAlwcResWork.CustomerName.TrimEnd();
		//		// 得意先名称2
		//		dr[MAHNB02014EB.ct_Col_CustomerName2			] = depAlwcResWork.CustomerName2.TrimEnd();
		//		// 敬称
		//		dr[MAHNB02014EB.ct_Col_HonorificTitle			] = depAlwcResWork.HonorificTitle;
		//		// カナ
		//		dr[MAHNB02014EB.ct_Col_Kana						] = depAlwcResWork.Kana;
        //
		//		// 入金計上拠点コード
		//		dr[MAHNB02014EB.ct_Col_DepositAddupSecCd		] = depAlwcResWork.DepositAddupSecCd;
		//		// 入金計上拠点名称
		//		dr[MAHNB02014EB.ct_Col_DepositAddupSecNm		] = depAlwcResWork.DepositAddupSecNm;
		//		// 入金伝票番号
		//		dr[MAHNB02014EB.ct_Col_DepositSlipNo			] = depAlwcResWork.DepositSlipNo;
		//		#endregion
		//		depositAlwDt.Rows.Add( dr );
		//	}
		//}
		#endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 入金総合計データ展開処理
        ///// <summary>
        ///// 入金総合計データ展開処理
        ///// </summary>
        ///// <param name="depositMainCndtn">UI抽出条件クラス</param>
        ///// <param name="depositMainDt">展開対象DataTable</param>
        ///// <param name="depositMainWork">取得データ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 入金データを展開する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //private void DevGrandTotalDepositMainData ( DepositMainCndtn depositMainCndtn, DataTable depositMainDt, ArrayList depositMainWork )
        //{
        //    DataRow dr;

        //    SortedList depKindListWork = (SortedList)stc_depositKindSortList.Clone();

        //    // 金種リスト初期化
        //    foreach ( DictionaryEntry de in stc_depositKindSortList )
        //    {
        //        dr = depositMainDt.NewRow();
        //        dr[MAHNB02014EA.ct_Col_DepositKindCode] = ((MoneyKind)de.Value).MoneyKindCode;	// 金種コード
        //        dr[MAHNB02014EA.ct_Col_DepositKindName] = ((MoneyKind)de.Value).MoneyKindName;	// 金種名称
        //        dr[MAHNB02014EA.ct_Col_DepositKindDivCd] = ((MoneyKind)de.Value).MoneyKindDiv;	// 金種区分
        //        depKindListWork[(int)de.Key] = dr;
        //    }

        //    foreach ( DepsitMainListResultWork depmainResWork in depositMainWork )
        //    {
        //        // 金種リストに指定したキーが格納されているかチェック
        //        if ( depKindListWork.ContainsKey( depmainResWork.DepositKindCode ) )
        //        {
        //            dr = (DataRow)(depKindListWork[ depmainResWork.DepositKindCode ]);
        //        }
        //        else
        //        {
        //            dr = depositMainDt.NewRow();
        //            depKindListWork.Add( depmainResWork.DepositKindCode, dr );
        //        }

        //        // 入金基本データ展開
        //        #region 入金データ展開
        //        // 計上拠点コード
        //        dr[MAHNB02014EA.ct_Col_AddUpSecCode				] = depmainResWork.AddUpSecCode;
        //        // 計上拠点名称
        //        // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
        //        //if (depositMainCndtn.IsSelectAllSection)
        //        //    dr[MAHNB02014EA.ct_Col_AddUpSecName				] = "全社";
        //        //else
        //        //    dr[MAHNB02014EA.ct_Col_AddUpSecName				] = depmainResWork.AddUpSecName.TrimEnd();
        //        dr[MAHNB02014EA.ct_Col_AddUpSecName			] = depmainResWork.AddUpSecName.TrimEnd();
        //        // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
        //        // 計上日付
        //        dr[MAHNB02014EA.ct_Col_AddUpADate			] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.AddUpADate);
        //        // 計上日付(ソート用)
        //        dr[MAHNB02014EA.ct_Col_Sort_AddUpADate		] = TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate);
        //        // 入金計
        //        dr[MAHNB02014EA.ct_Col_DepositTotal			] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositTotal];
        //        // 入金金額
        //        dr[MAHNB02014EA.ct_Col_Deposit				] = depmainResWork.Deposit + (long)dr[MAHNB02014EA.ct_Col_Deposit];
        //        // 手数料入金額
        //        dr[MAHNB02014EA.ct_Col_FeeDeposit			] = depmainResWork.FeeDeposit + (long)dr[MAHNB02014EA.ct_Col_FeeDeposit];
        //        // 値引入金額
        //        dr[MAHNB02014EA.ct_Col_DiscountDeposit		] = depmainResWork.DiscountDeposit + (long)dr[MAHNB02014EA.ct_Col_DiscountDeposit];
        //        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //        //// リベート入金額
        //        //dr[MAHNB02014EA.ct_Col_RebateDeposit		] = depmainResWork.RebateDeposit + (long)dr[MAHNB02014EA.ct_Col_RebateDeposit];
        //        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //        #region // 未実装
        //        //// 自動入金区分
        //        //dr[MAHNB02014EA.ct_Col_AutoDepositCd] = depmainResWork.AutoDepositCd;
        //        //// 自動入金区分名称
        //        //dr[MAHNB02014EA.ct_Col_AutoDepositCdName] = depmainResWork.AutoDepositCd == 0 ? "通常入金" : "自動入金";
        //        #endregion
        //        // 入金引当額
        //        dr[MAHNB02014EA.ct_Col_DepositAllowance		] = depmainResWork.DepositAllowance + (long)dr[MAHNB02014EA.ct_Col_DepositAllowance];
        //        // 入金引当残高
        //        dr[MAHNB02014EA.ct_Col_DepositAlwcBlnce		] = depmainResWork.DepositAlwcBlnce + (long)dr[MAHNB02014EA.ct_Col_DepositAlwcBlnce];
        //        // 小計区分
        //        dr[MAHNB02014EA.ct_Col_MiniTotal_KeyBleak			] = string.Empty;
        //        #endregion

        //        #region 総合計データ展開
        //        // 自動入金区分を判断
        //        if ( depmainResWork.AutoDepositCd == 0 )
        //        {
        //            // 預り金区分を判断
        //            if ( depmainResWork.DepositCd == (int)DepositMainCndtn.DepositCdState.Nomal )
        //                // 通常入金
        //                dr[MAHNB02014EA.ct_Col_NomalDepositTotal] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_NomalDepositTotal];
        //            else
        //                // 預り金 ct_Col_ChargeDepositTotal
        //                dr[MAHNB02014EA.ct_Col_ChargeDepositTotal] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_ChargeDepositTotal];
        //        }
        //        else
        //        {
        //            // 自動入金
        //            dr[MAHNB02014EA.ct_Col_AutoDepositTotal] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_AutoDepositTotal];
        //        }

        //        #endregion
        //    }

        //    // TableにAdd
        //    foreach ( DictionaryEntry de in depKindListWork )
        //    {
        //        depositMainDt.Rows.Add( (DataRow)de.Value );
        //    }
        //    //(string[])new ArrayList( this._selectedSectionList.Values ).ToArray( typeof ( string ) )
        //    //depositMainDt.Rows.Add( (DataRow[])new ArrayList( depKindListWork.Values ).ToArray( typeof( DataRow ) ) );
        //}
		#endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 金種別集計データ展開処理
        ///// <summary>
        ///// 金種別集計データ展開処理
        ///// </summary>
        ///// <param name="depositMainCndtn">UI抽出条件クラス</param>
        ///// <param name="depositMainDt">展開対象DataTable</param>
        ///// <param name="depositMainWork">取得データ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 入金データを展開する。</br>
        ///// <br>Programmer : 980035 金沢 貞義</br>
        ///// <br>Date       : 2007.11.14</br>
        ///// </remarks>
        //private void DevDepositKindData(DepositMainCndtn depositMainCndtn, DataTable depositMainDt, ArrayList depositMainWork)
        //{
        //    DataRow dr;
        //    string keyData = "";

        //    SortedList depKindListWork = new SortedList();

        //    foreach (DepsitMainListResultWork depmainResWork in depositMainWork)
        //    {
        //        // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
        //        //// 計上日付リストに指定したキーが格納されているかチェック
        //        //if (depKindListWork.ContainsKey(TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate)))
        //        //{
        //        //    dr = (DataRow)(depKindListWork[TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate)]);
        //        //}
        //        //else
        //        //{
        //        //    dr = depositMainDt.NewRow();
        //        //    depKindListWork.Add(TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate), dr);
        //        //}

        //        // キーの作成
        //        keyData = depmainResWork.AddUpSecCode + TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate).ToString("d8");

        //        // 計上日付リストに指定したキーが格納されているかチェック
        //        if (depKindListWork.ContainsKey(keyData))
        //        {
        //            dr = (DataRow)(depKindListWork[keyData]);
        //        }
        //        else
        //        {
        //            dr = depositMainDt.NewRow();
        //            depKindListWork.Add(keyData, dr);
        //        }
        //        // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<

        //        // 入金基本データ展開
        //        #region 入金データ展開
        //        // 計上拠点コード
        //        dr[MAHNB02014EA.ct_Col_AddUpSecCode] = depmainResWork.AddUpSecCode;
        //        // 計上拠点名称
        //        // 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
        //        //if (depositMainCndtn.IsSelectAllSection)
        //        //    dr[MAHNB02014EA.ct_Col_AddUpSecName] = "全社";
        //        //else
        //        //    dr[MAHNB02014EA.ct_Col_AddUpSecName] = depmainResWork.AddUpSecName.TrimEnd();
        //        dr[MAHNB02014EA.ct_Col_AddUpSecName] = depmainResWork.AddUpSecName.TrimEnd();
        //        // 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
        //        // 計上日付
        //        dr[MAHNB02014EA.ct_Col_AddUpADate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.AddUpADate);
        //        // 計上日付(ソート用)
        //        dr[MAHNB02014EA.ct_Col_Sort_AddUpADate] = TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate);
        //        // 入金計
        //        dr[MAHNB02014EA.ct_Col_DepositTotal] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositTotal];
        //        // 入金金額
        //        dr[MAHNB02014EA.ct_Col_Deposit] = depmainResWork.Deposit + (long)dr[MAHNB02014EA.ct_Col_Deposit];
        //        // 手数料入金額
        //        dr[MAHNB02014EA.ct_Col_FeeDeposit] = depmainResWork.FeeDeposit + (long)dr[MAHNB02014EA.ct_Col_FeeDeposit];
        //        // 値引入金額
        //        dr[MAHNB02014EA.ct_Col_DiscountDeposit] = depmainResWork.DiscountDeposit + (long)dr[MAHNB02014EA.ct_Col_DiscountDeposit];
        //        // 入金引当額
        //        dr[MAHNB02014EA.ct_Col_DepositAllowance] = depmainResWork.DepositAllowance + (long)dr[MAHNB02014EA.ct_Col_DepositAllowance];
        //        // 入金引当残高
        //        dr[MAHNB02014EA.ct_Col_DepositAlwcBlnce] = depmainResWork.DepositAlwcBlnce + (long)dr[MAHNB02014EA.ct_Col_DepositAlwcBlnce];
        //        // 小計区分
        //        dr[MAHNB02014EA.ct_Col_MiniTotal_KeyBleak] = string.Empty;
        //        #endregion

        //        #region 総合計データ展開
        //        // 自動入金区分を判断
        //        for (int ix = 0; ix < depositMainCndtn.DepositKindCode.Count; ix++)
        //        {
        //            if (depmainResWork.DepositKindCode == (int)depositMainCndtn.DepositKindCode[ix])
        //            {
        //                switch (ix)
        //                {
        //                    case 0: { dr[MAHNB02014EA.ct_Col_DepositKind_No1] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No1]; break; }
        //                    case 1: { dr[MAHNB02014EA.ct_Col_DepositKind_No2] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No2]; break; }
        //                    case 2: { dr[MAHNB02014EA.ct_Col_DepositKind_No3] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No3]; break; }
        //                    case 3: { dr[MAHNB02014EA.ct_Col_DepositKind_No4] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No4]; break; }
        //                    case 4: { dr[MAHNB02014EA.ct_Col_DepositKind_No5] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No5]; break; }
        //                    case 5: { dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No6]; break; }
        //                    case 6: { dr[MAHNB02014EA.ct_Col_DepositKind_No7] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No7]; break; }
        //                    case 7: { dr[MAHNB02014EA.ct_Col_DepositKind_No8] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No8]; break; }
        //                    case 8: { dr[MAHNB02014EA.ct_Col_DepositKind_No9] = depmainResWork.DepositTotal + (long)dr[MAHNB02014EA.ct_Col_DepositKind_No9]; break; }
        //                }
        //            }
        //        }

        //        #endregion
        //    }

        //    // TableにAdd
        //    foreach (DictionaryEntry de in depKindListWork)
        //    {
        //        depositMainDt.Rows.Add((DataRow)de.Value);
        //    }
        //}
        #endregion
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END

        #region ◎ 入金データ（入金確認表）展開処理
        /// <summary>
        /// 入金データ（入金確認表）展開処理
        /// </summary>
        /// <param name="depositMainCndtn">UI抽出条件クラス</param>
        /// <param name="depositMainDt">展開対象DataTable</param>
        /// <param name="depositMainWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 入金データ（入金確認表）を展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        private void DevDepositMainListData(DepositMainCndtn depositMainCndtn, DataTable depositMainDt, ArrayList depositMainWork)
        {
            string workStr_1 = "";
            string workStr_2 = "";
            int depositSlipNo_Tmp = -1;         // 伝票番号控え
            string validityTerm_Tmp = "";       // 有効期限控え
            DataRow dr = null;

            if (stc_dicDepositStRowNo.Count == 0)
            {
                // 入金設定マスタの金種コードが未取得の場合は取得を行う
                GetDepositSet();
            }

            foreach (DepsitMainListResultWork depmainResWork in depositMainWork)
            {
                if (depositSlipNo_Tmp != depmainResWork.DepositSlipNo)
                {
                    // 伝票番号が変わったらTableに追加してデータを取得
                    if (depositSlipNo_Tmp != -1)
                    {
                        // TableにAdd
                        // --- UPD m.suzuki 2010/05/26 ---------->>>>>
                        //// 2009/11/20 Add >>>
                        //dr[MAHNB02014EA.ct_Col_DepositKind_No6] = Convert.ToInt64(dr[MAHNB02014EA.ct_Col_DepositKind_No6]) + Convert.ToInt64(dr[MAHNB02014EA.ct_Col_DiscountDeposit]);
                        //// 2009/11/20 Add <<<
                        //UpdateDataRow(ref dr);//DEL BY 凌小青 2011/10/27
                        UpdateDataRow(ref dr, depositMainCndtn);//ADD BY 凌小青 2011/10/27
                        // --- UPD m.suzuki 2010/05/26 ----------<<<<<
                        depositMainDt.Rows.Add(dr);
                    }

                    // 伝票番号控えに取得伝票番号を設定
                    depositSlipNo_Tmp = depmainResWork.DepositSlipNo;

                    dr = depositMainDt.NewRow();
                    // 入金基本データ展開
                    // 2009.02.18 30413 犬飼 作成日時の追加 >>>>>>START
                    // 作成日時
                    //dr[MAHNB02014EA.ct_Col_CreateDateTime] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.CreateDateTime); // DEL 2009/03/26
                    // 入力日
                    // 2009/11/20 >>>
                    //dr[MAHNB02014EA.ct_Col_InputDay] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.InputDay); // ADD 2009/03/26
                    dr[MAHNB02014EA.ct_Col_InputDay] = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.InputDay);
                    // 2009/11/20 <<<
                    // 2009.02.18 30413 犬飼 作成日時の追加 <<<<<<END
                    // 赤黒区分名称取得
                    GetDebitNoteCdName(depmainResWork.DepositDebitNoteCd, out workStr_1, out workStr_2);
                    // 入金赤黒区分
                    dr[MAHNB02014EA.ct_Col_DepositDebitNoteCd] = depmainResWork.DepositDebitNoteCd;
                    // 入金赤黒区分名称
                    dr[MAHNB02014EA.ct_Col_DepositDebitNoteCdName] = workStr_1.TrimEnd();
                    // 入金赤黒区分記号
                    dr[MAHNB02014EA.ct_Col_DepositDebitNoteSign] = workStr_2.TrimEnd();
                    // 入金伝票番号
                    dr[MAHNB02014EA.ct_Col_DepositSlipNo] = depmainResWork.DepositSlipNo;
                    // 入金入力拠点コード
                    dr[MAHNB02014EA.ct_Col_InputDepositSecCd] = depmainResWork.InputDepositSecCd;
                    // 入金入力拠点名称
                    dr[MAHNB02014EA.ct_Col_InputDepositSecNm] = depmainResWork.InputDepositSecNm.TrimEnd();
                    // 計上拠点コード
                    dr[MAHNB02014EA.ct_Col_AddUpSecCode] = depmainResWork.AddUpSecCode;
                    // 計上拠点名称
                    dr[MAHNB02014EA.ct_Col_AddUpSecName] = depmainResWork.AddUpSecName.TrimEnd();
                    // 計上拠点名称(明細)
                    dr[MAHNB02014EA.ct_Col_AddUpSecName_Detail] = depmainResWork.AddUpSecName.TrimEnd();
                    // 入金日(表示用)
                    // 2009/11/20 >>>
                    //dr[MAHNB02014EA.ct_Col_DepositDate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DepositDate);
                    dr[MAHNB02014EA.ct_Col_DepositDate] = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.DepositDate);
                    // 2009/11/20 <<<
                    // 入金日(ソート用)
                    dr[MAHNB02014EA.ct_Col_Sort_DepositDate] = TDateTime.DateTimeToLongDate(depmainResWork.DepositDate);
                    // 計上日付
                    // 2009/11/20 >>>
                    //dr[MAHNB02014EA.ct_Col_AddUpADate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.AddUpADate);
                    dr[MAHNB02014EA.ct_Col_AddUpADate] = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.AddUpADate);
                    // 2009/11/20 <<<
                    // 計上日付(ソート用)
                    dr[MAHNB02014EA.ct_Col_Sort_AddUpADate] = TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate);
                    // 2008.07.09 30413 犬飼 項目削除 >>>>>>START
                    // 入金計
                    dr[MAHNB02014EA.ct_Col_DepositTotal] = depmainResWork.DepositTotal;
                    // 入金金額
                    dr[MAHNB02014EA.ct_Col_Deposit] = depmainResWork.Deposit;
                    // 手数料入金額
                    dr[MAHNB02014EA.ct_Col_FeeDeposit] = depmainResWork.FeeDeposit;
                    // 値引入金額
                    dr[MAHNB02014EA.ct_Col_DiscountDeposit] = depmainResWork.DiscountDeposit;
                    // 自動入金区分
                    dr[MAHNB02014EA.ct_Col_AutoDepositCd] = depmainResWork.AutoDepositCd;
                    // 自動入金区分名称
                    dr[MAHNB02014EA.ct_Col_AutoDepositCdName] = depmainResWork.AutoDepositCd == 0 ? "通常入金" : "自動入金";
                    //// 預り金区分
                    //dr[MAHNB02014EA.ct_Col_DepositCd] = depmainResWork.DepositCd;
                    //// 預り金区分名称
                    //dr[MAHNB02014EA.ct_Col_DepositCdName] = depmainResWork.DepositCd == 0 ? "通常入金" : "預り金入金";
                    //// 預り金記号
                    //if (depmainResWork.AutoDepositCd == 0)
                    //{
                    //    // 通常入金のとき
                    //    dr[MAHNB02014EA.ct_Col_DepositCdSign] = depmainResWork.DepositCd == 0 ? "" : "預";
                    //}
                    //else
                    //{
                    //    // 自動入金のとき
                    //    dr[MAHNB02014EA.ct_Col_DepositCdSign] = "自";
                    //}
                    // 手形振出日	
                    dr[MAHNB02014EA.ct_Col_DraftDrawingDate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DraftDrawingDate);
                    // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
                    // 手形種類
                    dr[MAHNB02014EA.ct_Col_DraftKind] = depmainResWork.DraftKind;
                    // 手形種類名称
                    dr[MAHNB02014EA.ct_Col_DraftKindName] = depmainResWork.DraftKindName;
                    // 手形区分
                    dr[MAHNB02014EA.ct_Col_DraftDivide] = depmainResWork.DraftDivide;
                    // 手形区分名称
                    dr[MAHNB02014EA.ct_Col_DraftDivideName] = depmainResWork.DraftDivideName;
                    // 手形番号
                    dr[MAHNB02014EA.ct_Col_DraftNo] = depmainResWork.DraftNo;
                    // 銀行コード
                    dr[MAHNB02014EA.ct_Col_BankCode] = depmainResWork.BankCode;
                    // 銀行名称
                    dr[MAHNB02014EA.ct_Col_BankName] = depmainResWork.BankName;
                    // 得意先コード
                    dr[MAHNB02014EA.ct_Col_CustomerCode] = depmainResWork.CustomerCode;
                    // 得意先名称
                    dr[MAHNB02014EA.ct_Col_CustomerName] = depmainResWork.CustomerSnm;
                    // 請求先コード
                    dr[MAHNB02014EA.ct_Col_ClaimCode] = depmainResWork.ClaimCode;
                    // 請求先略称
                    dr[MAHNB02014EA.ct_Col_ClaimSnm] = depmainResWork.ClaimSnm;
                    // 伝票適用 
                    dr[MAHNB02014EA.ct_Col_Outline] = depmainResWork.Outline;

                    // 有効期限
                    if (depmainResWork.MoneyKindDiv == 105)
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        // 2009/11/20 >>>
                        //validityTerm_Tmp = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.ValidityTerm);
                        validityTerm_Tmp = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.ValidityTerm);
                        // 2009/11/20 <<<
                        dr[MAHNB02014EA.ct_Col_ValidityTerm] = validityTerm_Tmp;
                    }
                    else
                    {
                        // 金種区分が「手形」以外の場合は空文字を設定
                        validityTerm_Tmp = "";
                    }
                    
                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicDepositStRowNo.ContainsKey(depmainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int depositKindRowNo = stc_dicDepositStRowNo[depmainResWork.MoneyKindCode];
                        switch (depositKindRowNo)
                        {
                            case 1:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No1] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 2:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No2] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 3:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No3] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 4:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No4] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 5:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No5] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 6:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 7:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No7] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 8:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No8] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 9:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No9] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 10:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No10] = depmainResWork.DepositDtl;
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    // 伝票番号が同じ場合

                    // 有効期限
                    if ((validityTerm_Tmp == "") && (depmainResWork.MoneyKindDiv == 105))
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        // 2009/11/20 >>>
                        //validityTerm_Tmp = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.ValidityTerm);
                        validityTerm_Tmp = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.ValidityTerm);
                        // 2009/11/20 <<<
                        dr[MAHNB02014EA.ct_Col_ValidityTerm] = validityTerm_Tmp;
                    }

                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicDepositStRowNo.ContainsKey(depmainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int depositKindRowNo = stc_dicDepositStRowNo[depmainResWork.MoneyKindCode];
                        switch (depositKindRowNo)
                        {
                            case 1:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No1] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 2:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No2] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 3:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No3] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 4:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No4] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 5:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No5] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 6:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 7:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No7] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 8:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No8] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 9:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No9] = depmainResWork.DepositDtl;
                                    break;
                                }
                            case 10:
                                {
                                    dr[MAHNB02014EA.ct_Col_DepositKind_No10] = depmainResWork.DepositDtl;
                                    break;
                                }
                        }
                    }
                }
            }

            // 最終レコードをTableにAdd
            // --- UPD m.suzuki 2010/05/26 ---------->>>>>
            //// 2009/11/20 Add >>>
            //dr[MAHNB02014EA.ct_Col_DepositKind_No6] = Convert.ToInt64(dr[MAHNB02014EA.ct_Col_DepositKind_No6]) + Convert.ToInt64(dr[MAHNB02014EA.ct_Col_DiscountDeposit]);
            //// 2009/11/20 Add <<<
            //UpdateDataRow(ref dr);//DEL BY 凌小青 2011/10/27
            UpdateDataRow(ref dr, depositMainCndtn);//ADD BY 凌小青 2011/10/27
            // --- UPD m.suzuki 2010/05/26 ----------<<<<<
            depositMainDt.Rows.Add(dr);
        }

        // --- ADD m.suzuki 2010/05/26 ---------->>>>>
        /// <summary>
        /// DataRow更新処理
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="depositMainCndtn"></param>//ADD BY 凌小青 2011/10/27
        //private void UpdateDataRow(ref DataRow dr)//DEL BY 凌小青 2011/10/27
        private void UpdateDataRow(ref DataRow dr, DepositMainCndtn depositMainCndtn)//ADD BY 凌小青 2011/10/27
        {
            // "入金値引"の金額を"その他"に合算する
            if ( stc_dicDepositStRowNo.ContainsKey( ct_DEPOSIT_OTHERS ) )
            {
                // 対象の列を決定する("その他"を特定する)
                string targetColumnName = string.Empty;
                switch ( stc_dicDepositStRowNo[ct_DEPOSIT_OTHERS] )
                {
                    case 1: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No1; break;
                    case 2: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No2; break;
                    case 3: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No3; break;
                    case 4: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No4; break;
                    case 5: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No5; break;
                    case 6: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No6; break;
                    case 7: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No7; break;
                    case 8: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No8; break;
                    case 9: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No9; break;
                    case 10: targetColumnName = MAHNB02014EA.ct_Col_DepositKind_No10; break;
                    default: break;
                }

                // "その他"の列の値を更新
                if ( !string.IsNullOrEmpty( targetColumnName ) )
                {
                    //入金確認表
                    if (depositMainCndtn.PrintDivName.Trim().Equals("入金確認表"))//ADD BY 凌小青 2011/10/27
                    {
                        dr[targetColumnName] = Convert.ToInt64( dr[targetColumnName] ) + Convert.ToInt64( dr[MAHNB02014EA.ct_Col_DiscountDeposit] );
                    }
                    //-----ADD BY 凌小青 2011/10/27 ---->>>>
                    //入金確認表(集計表)
                    else
                    {
                        dr[targetColumnName] = Convert.ToInt64(dr[targetColumnName]);
                    }
                    //-----ADD BY 凌小青 2011/10/27 ----<<<<
                }
            }
        }
        // --- ADD m.suzuki 2010/05/26 ----------<<<<<
        #endregion

        #region ◎ 入金データ（入金確認表(集計表)）展開処理
        /// <summary>
        /// 入金データ（入金確認表(集計表)）展開処理
        /// </summary>
        /// <param name="depositMainCndtn">UI抽出条件クラス</param>
        /// <param name="depositMainDt">展開対象DataTable</param>
        /// <param name="depositMainWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 入金データ（入金確認表(集計表)）を展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2007.07.22</br>
        /// </remarks>
        private void DevDepositMainListSumData(DepositMainCndtn depositMainCndtn, DataTable depositMainDt, ArrayList depositMainWork)
        {
            string workStr_1 = "";
            string workStr_2 = "";
            int depositSlipNo_Tmp = -1;         // 伝票番号控え
            int claimCode_Tmp = -1;             // 請求先コード控え
            string validityTerm_Tmp = "";       // 有効期限控え
            
            // 金額の一時計算プロパティ
            long depositTotal = 0;
            long deposit = 0;
            long feeDeposit = 0;
            long discountDeposit = 0;
            long[] depositDtl = new long[10];

            DataRow dr = null;

            if (stc_dicDepositStRowNo.Count == 0)
            {
                // 入金設定マスタの金種コードが未取得の場合は取得を行う
                GetDepositSet();
            }

            foreach (DepsitMainListResultWork depmainResWork in depositMainWork)
            {
                if (claimCode_Tmp != depmainResWork.ClaimCode)
                {
                    // 請求先コードが変わったらTableに追加してデータを取得
                    if (depositSlipNo_Tmp != -1)
                    {
                        // 金額の一時計算プロパティの値を設定
                        // 入金計
                        dr[MAHNB02014EA.ct_Col_DepositTotal] = depositTotal;
                        // 入金金額
                        dr[MAHNB02014EA.ct_Col_Deposit] = deposit;
                        // 手数料入金額
                        dr[MAHNB02014EA.ct_Col_FeeDeposit] = feeDeposit;
                        // 値引入金額
                        dr[MAHNB02014EA.ct_Col_DiscountDeposit] = discountDeposit;

                        // 金種毎の金額を設定
                        dr[MAHNB02014EA.ct_Col_DepositKind_No1] = depositDtl[0];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No2] = depositDtl[1];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No3] = depositDtl[2];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No4] = depositDtl[3];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No5] = depositDtl[4];
                        // --- UPD m.suzuki 2010/05/26 ---------->>>>>
                        //// 2009/11/20 >>>
                        ////dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depositDtl[5];
                        //dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depositDtl[5] + discountDeposit;
                        //// 2009/11/20 <<<
                        dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depositDtl[5];
                        // --- UPD m.suzuki 2010/05/26 ----------<<<<<
                        dr[MAHNB02014EA.ct_Col_DepositKind_No7] = depositDtl[6];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No8] = depositDtl[7];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No9] = depositDtl[8];
                        dr[MAHNB02014EA.ct_Col_DepositKind_No10] = depositDtl[9];

                        // --- ADD m.suzuki 2010/05/26 ---------->>>>>
                        //UpdateDataRow(ref dr);//DEL BY 凌小青 2011/10/27
                        UpdateDataRow(ref dr, depositMainCndtn);//ADD BY 凌小青 2011/10/27
                        // --- ADD m.suzuki 2010/05/26 ----------<<<<<

                        // TableにAdd
                        depositMainDt.Rows.Add(dr);

                        // 金額の一時計算プロパティの値を初期化
                        depositTotal = 0;
                        deposit = 0;
                        feeDeposit = 0;
                        discountDeposit = 0;
                    }

                    // 請求先コード控えに取得伝票番号を設定
                    claimCode_Tmp = depmainResWork.ClaimCode;

                    // 入金明細の入金金額を初期化
                    for (int i = 0; i < depositDtl.Length; i++)
                    {
                        depositDtl[i] = new long();
                    }

                    dr = depositMainDt.NewRow();
                    // 入金基本データ展開
                    // 赤黒区分名称取得
                    GetDebitNoteCdName(depmainResWork.DepositDebitNoteCd, out workStr_1, out workStr_2);
                    // 入金赤黒区分
                    dr[MAHNB02014EA.ct_Col_DepositDebitNoteCd] = depmainResWork.DepositDebitNoteCd;
                    // 入金赤黒区分名称
                    dr[MAHNB02014EA.ct_Col_DepositDebitNoteCdName] = workStr_1.TrimEnd();
                    // 入金赤黒区分記号
                    dr[MAHNB02014EA.ct_Col_DepositDebitNoteSign] = workStr_2.TrimEnd();
                    // 入金伝票番号
                    dr[MAHNB02014EA.ct_Col_DepositSlipNo] = depmainResWork.DepositSlipNo;
                    // 入金入力拠点コード
                    dr[MAHNB02014EA.ct_Col_InputDepositSecCd] = depmainResWork.InputDepositSecCd;
                    // 入金入力拠点名称
                    dr[MAHNB02014EA.ct_Col_InputDepositSecNm] = depmainResWork.InputDepositSecNm.TrimEnd();
                    // 計上拠点コード
                    dr[MAHNB02014EA.ct_Col_AddUpSecCode] = depmainResWork.AddUpSecCode;
                    // 計上拠点名称
                    dr[MAHNB02014EA.ct_Col_AddUpSecName] = depmainResWork.AddUpSecName.TrimEnd();
                    // 計上拠点名称(明細)
                    dr[MAHNB02014EA.ct_Col_AddUpSecName_Detail] = depmainResWork.AddUpSecName.TrimEnd();
                    // 入金日(表示用)
                    // 2009/11/20 >>>
                    //dr[MAHNB02014EA.ct_Col_DepositDate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DepositDate);
                    dr[MAHNB02014EA.ct_Col_DepositDate] = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.DepositDate);
                    // 2009/11/20 <<<
                    // 入金日(ソート用)
                    dr[MAHNB02014EA.ct_Col_Sort_DepositDate] = TDateTime.DateTimeToLongDate(depmainResWork.DepositDate);
                    // 計上日付
                    // 2009/11/20 >>>
                    //dr[MAHNB02014EA.ct_Col_AddUpADate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.AddUpADate);
                    dr[MAHNB02014EA.ct_Col_AddUpADate] = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.AddUpADate);
                    // 2009/11/20 <<<
                    // 計上日付(ソート用)
                    dr[MAHNB02014EA.ct_Col_Sort_AddUpADate] = TDateTime.DateTimeToLongDate(depmainResWork.AddUpADate);

                    // 請求先コードが異なる場合、金額の一時計算プロパティ値を設定
                    // 入金計
                    depositTotal = depmainResWork.DepositTotal;
                    // 入金金額
                    deposit = depmainResWork.Deposit;
                    // 手数料入金額
                    feeDeposit = depmainResWork.FeeDeposit;
                    // 値引入金額
                    discountDeposit = depmainResWork.DiscountDeposit;

                    // 伝票番号控えに取得伝票番号を設定
                    depositSlipNo_Tmp = depmainResWork.DepositSlipNo;
                        
                    // 自動入金区分
                    dr[MAHNB02014EA.ct_Col_AutoDepositCd] = depmainResWork.AutoDepositCd;
                    // 自動入金区分名称
                    dr[MAHNB02014EA.ct_Col_AutoDepositCdName] = depmainResWork.AutoDepositCd == 0 ? "通常入金" : "自動入金";
                    //// 預り金区分
                    //dr[MAHNB02014EA.ct_Col_DepositCd] = depmainResWork.DepositCd;
                    //// 預り金区分名称
                    //dr[MAHNB02014EA.ct_Col_DepositCdName] = depmainResWork.DepositCd == 0 ? "通常入金" : "預り金入金";
                    //// 預り金記号
                    //if (depmainResWork.AutoDepositCd == 0)
                    //{
                    //    // 通常入金のとき
                    //    dr[MAHNB02014EA.ct_Col_DepositCdSign] = depmainResWork.DepositCd == 0 ? "" : "預";
                    //}
                    //else
                    //{
                    //    // 自動入金のとき
                    //    dr[MAHNB02014EA.ct_Col_DepositCdSign] = "自";
                    //}
                    // 手形振出日	
                    // 2009/11/20 >>>
                    //dr[MAHNB02014EA.ct_Col_DraftDrawingDate] = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.DraftDrawingDate);
                    dr[MAHNB02014EA.ct_Col_DraftDrawingDate] = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.DraftDrawingDate);
                    // 2009/11/20 <<<
                    // 手形種類
                    dr[MAHNB02014EA.ct_Col_DraftKind] = depmainResWork.DraftKind;
                    // 手形種類名称
                    dr[MAHNB02014EA.ct_Col_DraftKindName] = depmainResWork.DraftKindName;
                    // 手形区分
                    dr[MAHNB02014EA.ct_Col_DraftDivide] = depmainResWork.DraftDivide;
                    // 手形区分名称
                    dr[MAHNB02014EA.ct_Col_DraftDivideName] = depmainResWork.DraftDivideName;
                    // 手形番号
                    dr[MAHNB02014EA.ct_Col_DraftNo] = depmainResWork.DraftNo;
                    // 銀行コード
                    dr[MAHNB02014EA.ct_Col_BankCode] = depmainResWork.BankCode;
                    // 銀行名称
                    dr[MAHNB02014EA.ct_Col_BankName] = depmainResWork.BankName;
                    // 得意先コード
                    dr[MAHNB02014EA.ct_Col_CustomerCode] = depmainResWork.CustomerCode;
                    // 得意先名称
                    dr[MAHNB02014EA.ct_Col_CustomerName] = depmainResWork.CustomerSnm;
                    // 請求先コード
                    dr[MAHNB02014EA.ct_Col_ClaimCode] = depmainResWork.ClaimCode;
                    // 請求先略称
                    dr[MAHNB02014EA.ct_Col_ClaimSnm] = depmainResWork.ClaimSnm;
                    // 伝票適用 
                    dr[MAHNB02014EA.ct_Col_Outline] = depmainResWork.Outline;

                    // 有効期限
                    if (depmainResWork.MoneyKindDiv == 105)
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        // 2009/11/20 >>>
                        //validityTerm_Tmp = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.ValidityTerm);
                        validityTerm_Tmp = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.ValidityTerm);
                        // 2009/11/20 <<<
                        dr[MAHNB02014EA.ct_Col_ValidityTerm] = validityTerm_Tmp;
                    }
                    else
                    {
                        // 金種区分が「手形」以外の場合は空文字を設定
                        validityTerm_Tmp = "";
                    }

                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicDepositStRowNo.ContainsKey(depmainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int depositKindRowNo = stc_dicDepositStRowNo[depmainResWork.MoneyKindCode] - 1;
                        depositDtl[depositKindRowNo] = depmainResWork.DepositDtl;
                    }
                }
                else
                {
                    // 請求先コードが同じ場合

                    // 有効期限
                    if ((validityTerm_Tmp == "") && (depmainResWork.MoneyKindDiv == 105))
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        // 2009/11/20 >>>
                        //validityTerm_Tmp = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depmainResWork.ValidityTerm);
                        validityTerm_Tmp = TDateTime.DateTimeToString("YY/MM/DD", depmainResWork.ValidityTerm);
                        // 2009/11/20 <<<
                        dr[MAHNB02014EA.ct_Col_ValidityTerm] = validityTerm_Tmp;
                    }

                    if (depositSlipNo_Tmp != depmainResWork.DepositSlipNo)
                    {
                        // 伝票番号が異なる場合、金額の一時計算プロパティ値に加算
                        // 入金計
                        depositTotal += depmainResWork.DepositTotal;
                        // 入金金額
                        deposit += depmainResWork.Deposit;
                        // 手数料入金額
                        feeDeposit += depmainResWork.FeeDeposit;
                        // 値引入金額
                        discountDeposit += depmainResWork.DiscountDeposit;

                        // 伝票番号控えに取得伝票番号を設定
                        depositSlipNo_Tmp = depmainResWork.DepositSlipNo;
                    }

                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicDepositStRowNo.ContainsKey(depmainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int depositKindRowNo = stc_dicDepositStRowNo[depmainResWork.MoneyKindCode] - 1;
                        depositDtl[depositKindRowNo] += depmainResWork.DepositDtl;
                    }
                }
            }

            // 最終レコードの金額の一時計算プロパティの値を設定
            // 金額の一時計算プロパティの値を設定
            // 入金計
            dr[MAHNB02014EA.ct_Col_DepositTotal] = depositTotal;
            // 入金金額
            dr[MAHNB02014EA.ct_Col_Deposit] = deposit;
            // 手数料入金額
            dr[MAHNB02014EA.ct_Col_FeeDeposit] = feeDeposit;
            // 値引入金額
            dr[MAHNB02014EA.ct_Col_DiscountDeposit] = discountDeposit;

            // 金種毎の金額を設定
            dr[MAHNB02014EA.ct_Col_DepositKind_No1] = depositDtl[0];
            dr[MAHNB02014EA.ct_Col_DepositKind_No2] = depositDtl[1];
            dr[MAHNB02014EA.ct_Col_DepositKind_No3] = depositDtl[2];
            dr[MAHNB02014EA.ct_Col_DepositKind_No4] = depositDtl[3];
            dr[MAHNB02014EA.ct_Col_DepositKind_No5] = depositDtl[4];
            // --- UPD m.suzuki 2010/05/26 ---------->>>>>
            //// 2009/11/20 >>>
            ////dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depositDtl[5];
            //dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depositDtl[5] + discountDeposit;
            //// 2009/11/20 <<<
            dr[MAHNB02014EA.ct_Col_DepositKind_No6] = depositDtl[5];
            // --- UPD m.suzuki 2010/05/26 ----------<<<<<
            dr[MAHNB02014EA.ct_Col_DepositKind_No7] = depositDtl[6];
            dr[MAHNB02014EA.ct_Col_DepositKind_No8] = depositDtl[7];
            dr[MAHNB02014EA.ct_Col_DepositKind_No9] = depositDtl[8];
            dr[MAHNB02014EA.ct_Col_DepositKind_No10] = depositDtl[9];

            // --- ADD m.suzuki 2010/05/26 ---------->>>>>
            //UpdateDataRow(ref dr);//DEL BY 凌小青 2011/10/27
            UpdateDataRow(ref dr, depositMainCndtn);//ADD BY 凌小青 2011/10/27
            // --- ADD m.suzuki 2010/05/26 ----------<<<<<

            // 最終レコードをTableにAdd
            depositMainDt.Rows.Add(dr);
        }
        #endregion

        #endregion ◆ データ展開処理

		#region ◆ 固定項目名称設定
		#region ◎ 赤黒区分名称取得
		/// <summary>
		/// 赤黒区分名称取得
		/// </summary>
		/// <param name="depositDebitNoteCd">赤黒区分コード</param>
		/// <param name="dNName">赤黒区分名称</param>
		/// <param name="dNSign">赤黒区分記号</param>
		/// <remarks>
		/// <br>Note       : 赤黒区分名称と記号を取得する。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		private void GetDebitNoteCdName ( int depositDebitNoteCd, out string dNName, out string dNSign )
		{
			dNName = "";
			dNSign = "";

			// 名称と記号をセット
			if ( depositDebitNoteCd == 0 )
			{
				dNName = "黒伝";
				dNSign = "";
			}
			else if ( depositDebitNoteCd == 1 )
			{
				dNName = "赤伝";
				dNSign = "▲";
			}
			else if ( depositDebitNoteCd == 2 )
			{
				dNName = "相殺済黒伝";
				dNSign = "●";
			}
		}
		#endregion

        // 2008.07.10 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region ◎ 手形振出日又はクレジット会社名称など取得
        ///// <summary>
        ///// 手形振出日又はクレジット会社名称など取得
        ///// </summary>
        ///// <param name="depMainResWork">取得データ</param>
        ///// <returns>手形振出日又はクレジット会社名称</returns>
        ///// <remarks>
        ///// <br>Note       : 手形振出日又はクレジット会社名称を取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //private string GetDraftOrCreditName ( DepsitMainListResultWork depMainResWork )
        //{
        //    string draftOrCreditName = "";
        //    // 手形振出日又はクレジット会社名称など
        //    // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //    //// クレジットローン区分が立っているかどうか
        //    //if ( depMainResWork.CreditOrLoanCd == 0 )
        //    //{
        //    // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //        // 手形日が入っているかどうか
        //        if ( ( depMainResWork.DraftDrawingDate != DateTime.MinValue ) || ( depMainResWork.DraftPayTimeLimit != DateTime.MinValue ) )
        //        {
        //            draftOrCreditName = 
        //                string.Format(
        //                    "{0} , {1}",
        //                    TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depMainResWork.DraftDrawingDate),
        //                    TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, depMainResWork.DraftPayTimeLimit)
        //                );
        //        }
        //        else
        //        {
        //            draftOrCreditName = string.Empty;
        //        }
        //    // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        //    //}
        //    //else
        //    //{
        //    //	// クレジット又はローンの場合
        //    //    draftOrCreditName = depMainResWork.CreditCompanyName;
        //    //}
        //    // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        //    return draftOrCreditName;
        //}
		#endregion
        // 2008.07.10 30413 犬飼 未使用メソッドの削除 <<<<<<END
        
		#region ◎ 受注ステータス名称取得
		/// <summary>
		/// 受注ステータス名称取得
		/// </summary>
		/// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipKind">売上伝票種別</param>
		/// <returns>受注ステータス名称</returns>
		/// <remarks>
		/// <br>Note       : 受注ステータス名称を取得する。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		private string GetAcptAnOdrStatusName ( int acptAnOdrStatus, int salesSlipKind )
		{
			string acptAnOdrStatusName = "";
			switch ( acptAnOdrStatus )
			{
				case 1:		acptAnOdrStatusName = "予約";			break;
				case 2:		acptAnOdrStatusName = "予約キャンセル";	break;
				case 10:	acptAnOdrStatusName = "見積";			break;
				case 11:	acptAnOdrStatusName = "見積キャンセル";	break;
				case 20:	acptAnOdrStatusName = "受注";			break;
				case 21:	acptAnOdrStatusName = "受注キャンセル";	break;
				case 30:
					{
						switch ( salesSlipKind )
						{
							case 10: acptAnOdrStatusName = "売上";		break;
							case 20: acptAnOdrStatusName = "売切";		break;
							case 21: acptAnOdrStatusName = "売切計上";	break;
							case 30: acptAnOdrStatusName = "委託";		break;
							case 31: acptAnOdrStatusName = "委託計上";	break;
						}
						break;
					}
				default:	acptAnOdrStatusName = "";				break;
			}
			return acptAnOdrStatusName;
		}
		#endregion

        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 引当状態取得
        ///// <summary>
        ///// 引当状態取得
        ///// </summary>
        ///// <param name="depAlwResWork">引当抽出結果クラス</param>
        ///// <param name="alwState">引当状態区分</param>
        ///// <param name="alwStateName">引当状態名称</param>
        ///// <remarks>
        ///// <br>Note       : 引当状態を取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
        //private void GetAllowanceState(DepsitMainListParamWork depAlwResWork, out int alwState, out string alwStateName)
		//{
		//    // 引当状態
		//    alwState = -1;		// 0:引当済, 1:一部引当, 2:未引当
		//    alwStateName = string.Empty;
        //
		//    // 引当状態判定
		//    // 入金引当合計額 >= 請求合計額
		//    if ( depAlwResWork.DepositAllowanceTtl >= depAlwResWork.DemandableTtl )
		//    {
		//        alwState		= 0;
		//        alwStateName	= "引当済";
		//    }
		//    // 請求合計額 > 入金引当合計額 > 0
		//    else if ( ( depAlwResWork.DemandableTtl < depAlwResWork.DepositAllowanceTtl ) && 
		//              ( depAlwResWork.DepositAllowanceTtl > 0 ))
		//    {
		//        alwState		= 1;
		//        alwStateName	= "一部引当";
		//    }
		//    // 入金引当合計額 <= 0
		//    else if ( depAlwResWork.DepositAllowanceTtl <= 0 )
        //    {
        //        alwState		= 2;
        //        alwStateName	= "未引当";
        //    }
        //    else
        //    {
        //        alwState		= -1;
        //        alwStateName	= "";
        //    }
        //}
        #endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<

        // 2007.11.14 削除 >>>>>>>>>>>>>>>>>>>>
        #region ◎ 個人法人区分名称取得
        ///// <summary>
        ///// 個人法人区分名称取得
        ///// </summary>
        ///// <param name="corporateDivCode"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : 個人法人区分名称を取得する。</br>
        ///// <br>Programmer : 22013 久保 将太</br>
        ///// <br>Date       : 2007.03.06</br>
        ///// </remarks>
		//private string GetCorporateDivName( int corporateDivCode )
		//{
		//	string corporateDivName = string.Empty;
        //
		//	switch( corporateDivCode )
		//	{
		//		case (int)DepositMainCndtn.CorporateDivCodeState.Personal:		corporateDivName = "個人"; break;
		//		case (int)DepositMainCndtn.CorporateDivCodeState.Juridical:		corporateDivName = "法人"; break;
		//		case (int)DepositMainCndtn.CorporateDivCodeState.BigJuridical:	corporateDivName = "大口法人"; break;
		//		case (int)DepositMainCndtn.CorporateDivCodeState.Supplier:		corporateDivName = "業者"; break;
        //		case (int)DepositMainCndtn.CorporateDivCodeState.Employee:		corporateDivName = "社員"; break;
        //		default: break;
        //	}
        //
        //	return corporateDivName;
        //}
		#endregion
        // 2007.11.14 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion ◆ 固定項目取得

		#region ◆ 帳票設定データ取得
		#region ◎ 金種設定取得
		/// <summary>
		/// 金種設定取得処理
		/// </summary>
		/// <param name="priceStCode">金額設定区分</param>
		/// <param name="retList"></param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		private int SearchMoneyKindProc( int priceStCode, out SortedList retList, out string errMsg )
		{
			int status		= (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg			= string.Empty;
			retList = new SortedList();

			ArrayList workList = null;
			try
			{
				status = this._moneyKindAcs.Search(out workList, LoginInfoAcquisition.EnterpriseCode);
				if ( ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) && ( workList != null ) )
				{
					retList = new SortedList();
					foreach (MoneyKind moneyKind in workList)
					{
						// 指定された金額設定区分のみ格納
						if (moneyKind.PriceStCode == priceStCode)
						{
							retList.Add(moneyKind.MoneyKindCode, moneyKind.Clone());
							stc_depositKindSortList.Add( moneyKind.MoneyKindCode, moneyKind.Clone() );
						}
					}
				}
				else
				{
					switch( status )
					{
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
						default:
							errMsg = "金額種別設定の読込に失敗しました";
							break;
					}
				}

			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				retList = new SortedList();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

        #region ◎ 入金設定マスタ取得
        /// <summary>
        /// 入金設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入金設定マスタを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008/07/10</br>
        /// </remarks>
        private void GetDepositSet()
        {
            int status;
            int listIndex = 1;
            DepositSt depositSt = new DepositSt();

            status = this._depositStAcs.Read(out depositSt, LoginInfoAcquisition.EnterpriseCode, 0);
            if (status == 0)
            {
                stc_dicDepositStRowNo = new Dictionary<int, int>();
                stc_dicDepositStKindCd = new Dictionary<int, int>();
                
                if ((depositSt.DepositStKindCd1 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd1)))
                {
                    // 入金設定金種コード１の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd1, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd1);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd2 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd2)))
                {
                    // 入金設定金種コード２の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd2, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd2);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd3 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd3)))
                {
                    // 入金設定金種コード３の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd3, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd3);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd4 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd4)))
                {
                    // 入金設定金種コード４の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd4, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd4);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd5 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd5)))
                {
                    // 入金設定金種コード５の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd5, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd5);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd6 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd6)))
                {
                    // 入金設定金種コード６の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd6, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd6);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd7 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd7)))
                {
                    // 入金設定金種コード７の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd7, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd7);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd8 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd8)))
                {
                    // 入金設定金種コード８の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd8, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd8);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd9 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd9)))
                {
                    // 入金設定金種コード９の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd9, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd9);
                    listIndex++;
                }

                if ((depositSt.DepositStKindCd10 != 0) &&
                    (stc_depositKindSortList.ContainsKey(depositSt.DepositStKindCd10)))
                {
                    // 入金設定金種コード１０の追加
                    stc_dicDepositStRowNo.Add(depositSt.DepositStKindCd10, listIndex);
                    stc_dicDepositStKindCd.Add(listIndex, depositSt.DepositStKindCd10);
                    listIndex++;
                }

                return;
            }

            stc_dicDepositStRowNo = new Dictionary<int, int>();
        }
        #endregion

        #region ◎入力設定マスタ金種名称取得
        /// <summary>
		/// 入力設定マスタ金種名称取得
		/// </summary>
        /// <param name="dicKindName">金種名称</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 入力設定マスタから金種コードを取得</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008/07/11</br>
        /// </remarks>
        private int GetKindName(out Dictionary<int, string> dicKindName)
        {
            int index = 0;
            dicKindName = new Dictionary<int,string>();

            if (stc_dicDepositStRowNo.Count == 0)
            {
                GetDepositSet();
            }

            for (int i = 1; i <= stc_dicDepositStKindCd.Count; i++)
            {
                if (stc_dicDepositStKindCd.ContainsKey(i))
                {
                    int key = stc_dicDepositStKindCd[i];
                    if (stc_depositKindSortList.ContainsKey(key))
                    {
                        MoneyKind moneyKind = (MoneyKind)stc_depositKindSortList[key];
                        dicKindName.Add(index, moneyKind.MoneyKindName);
                        index++;
                    }
                }
            }

            //for (int i = 0; i < stc_depositKindSortList.Count; i++)
            //{
            //    MoneyKind moneyKind = (MoneyKind)stc_depositKindSortList.GetByIndex(i);
            //    if (stc_dicDepositStRowNo.ContainsKey(moneyKind.MoneyKindCode))
            //    {
            //        dicKindName.Add(index, moneyKind.MoneyKindName);
            //        index++;
            //    }
            //}

            return 0;
        }
        #endregion

        #region ◎ 帳票出力設定取得処理
        /// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// データは読込済みか？
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();	// 2007.06.27 kubo add
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "帳票出力設定の読込に失敗しました";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票設定データ取得

		#endregion ■ Private Method

	}
}
