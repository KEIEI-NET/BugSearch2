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
// --- ADD 2012/10/03 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/10/03 ----------<<<<<
	
namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 支払確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払確認表で使用するデータを取得する。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br>UpdateNote : 2008/08/05 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS用に修正</br>
    /// <br>Update Note: 2009/02/19 30452 上野 俊治</br>
    /// <br>            ・障害対応11459 帳票の「入力日」に作成日付を設定するよう修正。ソート順も合わせて修正。</br>
    /// <br>Update Note: 2009/02/19 30452 上野 俊治</br>
    /// <br>            ・障害対応11459 作成日付を入力日に変更。</br>
    /// <br>Update Note: 2012/10/03 FSI今野 利裕</br>
    /// <br>            ・仕入先総括対応</br>
    /// </remarks>
	public class PaymentMainAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 支払確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
        /// <br>UpdateNote : 2008/11/12 照田 貴志　バグ修正、仕様変更対応  </br>
		/// </remarks>
		public PaymentMainAcs()
		{
            this._iPaymentListWorkDB = (IPaymentListWorkDB)MediationPaymentListWorkDB.GetPaymentListWorkDB();

			this._moneyKindAcs = new MoneyKindAcs();	// 金種設定アクセスクラス

            this._paymentSetAcs = new PaymentSetAcs();  // 支払設定アクセスクラス

            // --- ADD 2012/10/03 ---------->>>>>
            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion
            // --- ADD 2012/10/03 ----------<<<<<
        }

		/// <summary>
		/// 支払確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
		static PaymentMainAcs()
		{
			stc_Employee		    = null;
			stc_PrtOutSet		    = null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	    = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
			stc_paymentKindSortList = new SortedList();	    // 支払金種リスト

            // --- ADD 2008/08/05 支払設定金種リスト -------------------------------->>>>>
            stc_dicPaymentStRowNo = new Dictionary<Int32, Int32>();
            stc_dicPaymentStKindCd = new Dictionary<Int32, Int32>();
            // --- ADD 2008/08/05 ---------------------------------------------------<<<<<
            stc_cndtnKindSortList = new SortedList();       //ADD 2008/11/12

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

        // --- ADD 2008/08/05 支払設定金種リスト -------------------------------->>>>>
        private static Dictionary<Int32, Int32> stc_dicPaymentStRowNo;
        private static Dictionary<Int32, Int32> stc_dicPaymentStKindCd;
        // --- ADD 2008/08/05 ---------------------------------------------------<<<<< 

		#endregion ■ Static Member

		#region ■ Private Member
        IPaymentListWorkDB _iPaymentListWorkDB;

		private MoneyKindAcs _moneyKindAcs;	   // 金種設定アクセスクラス
		private DataSet _payDs;				   // 支払データセット

        private PaymentSetAcs _paymentSetAcs;  // 支払設定アクセスクラス  // ADD 2008/08/05

		private static SortedList stc_paymentKindSortList;	// 支払金種リスト(1～10全て)
        private static SortedList stc_cndtnKindSortList;    // 画面で選択された金種     //ADD 2008/11/12

        // --- ADD 2012/10/03 ---------->>>>>
        // 仕入先総括のオプションコード利用可否設定用フラグ
        // true → 仕入先総括使用する。 false → 仕入先総括使用しない。
        private bool _optSuppEnable = false;
        // --- ADD 2012/10/03 ----------<<<<<
        #endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 支払データセット(読み取り専用)
		/// </summary>
		public DataSet PayDs
		{
			get{ return this._payDs; }
		}
        #endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 支払データ取得
		/// <summary>
        /// 支払データ（支払確認表）取得
		/// </summary>
		/// <param name="paymentmainCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 支払データ（支払確認表）を取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int SearchPaymentMain(PaymentMainCndtn paymentmainCndtn, out string errMsg)
		{
            return this.SearchPaymentMainProc(paymentmainCndtn, out errMsg);
		}
		#endregion

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◎ 支払総合計データ取得
        ///// <summary>
        ///// 支払総合計データ取得
        ///// </summary>
        ///// <param name="paymentmainCndtn">抽出条件</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 総合計用データを取得する。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.09.10</br>
        ///// </remarks>
        //public int SearchPaymentGrandTotal(PaymentMainCndtn paymentmainCndtn, out string errMsg)
        //{
        //    return this.SearchPaymentGrandTotalProc(paymentmainCndtn, out errMsg);
        //}
        //#endregion
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        #region ◎ 支払金種別データ取得
        /// <summary>
        /// 支払データ（支払確認表(集計表)）取得
        /// </summary>
        /// <param name="paymentmainCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 支払データ（支払確認表(集計表)）を取得する。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public int SearchPaymentKindTotal(PaymentMainCndtn paymentmainCndtn, out string errMsg)
        {
            return this.SearchPaymentKindTotalProc(paymentmainCndtn, out errMsg);
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
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public int SearchMoneyKind( int priceStCode, out SortedList retList, out string errMsg )
		{
			return this.SearchMoneyKindProc( priceStCode, out retList, out errMsg );
		}
		#endregion

        /// <summary>
        /// 支払設定マスタ金種名称取得処理
        /// </summary>
        /// <param name="dicKindName">金種名称</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 支払設定マスタから金種コードを取得する。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/08/05</br>
        /// </remarks>
        public int SearchKindName(out Dictionary<int, string> dicKindName)
        {
            return this.GetKindName(out dicKindName);
        }

		#endregion ◆ 帳票設定データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 支払データ取得
		/// <summary>
        /// 支払データ（支払確認表）取得
		/// </summary>
        /// <param name="paymentMainCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 支払データ（支払確認表）を取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private int SearchPaymentMainProc(PaymentMainCndtn paymentMainCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                DCKAK02525EA.CreateDataTablePaymentMain(ref this._payDs);
                PaymentSlpCndtnWork paymentSlpCndtnWork = new PaymentSlpCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevPaymentMainCndtn(paymentMainCndtn, out paymentSlpCndtnWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retPaymentMainList = null;
                status = this._iPaymentListWorkDB.SearchDepsitOnly(
                    out retPaymentMainList, paymentSlpCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
				
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // --- ADD 2008/08/05 -------------------------------->>>>>
                        // データをソートする
                        SortedList wkSort = new SortedList();

                        foreach (PaymentSlpListResultWork wkPaymentMainListResultWork in (ArrayList)retPaymentMainList)
                        {
                            string key = wkPaymentMainListResultWork.AddUpSecCode.Trim();
                            switch (paymentMainCndtn.SortOrderDiv)
                            {
                                case PaymentMainCndtn.SortOrderDivState.PayeeDate:  // 支払日順
                                    {
                                        // 支払日順(拠点－支払日－伝票番号－仕入先ｺｰﾄﾞ)
                                        key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                            + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                            + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                            + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                                case PaymentMainCndtn.SortOrderDivState.InputDate:  // 入力日順
                                    {
                                        // 入力日順(拠点－入力日－伝票番号－仕入先ｺｰﾄﾞ)
                                        //key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.PaymentDate) // DEL 2009/02/19
                                        //key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.CreateDateTime) // ADD 2009/02/19 // DEL 2009/03/26
                                        key = key + this.DateTimeToStringForSortKey(wkPaymentMainListResultWork.InputDay) // ADD 2009/03/26
                                            + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                            + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                            + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                                case PaymentMainCndtn.SortOrderDivState.SlipNo:  // 伝票番号順
                                    {
                                        // 伝票番号順(拠点－伝票番号－支払日－仕入先ｺｰﾄﾞ)
                                        key = key + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                            + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                            + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                            + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                                // --- ADD 2012/10/03 ---------------------------->>>>>
                                case PaymentMainCndtn.SortOrderDivState.SupplSec:  // 仕入先-拠点順
                                    {
                                        // 伝票番号順(仕入先ｺｰﾄﾞ－拠点－支払日－伝票番号)
                                        key = wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                            + wkPaymentMainListResultWork.AddUpSecCode.Trim()
                                            + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                            + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                            + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                                // --- ADD 2012/10/03 ----------------------------<<<<<
                                default:
                                    {
                                        // デフォルトは支払日順とする
                                        key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                            + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                            + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                            + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                            }
                            // 取得した抽出結果をソート
                            wkSort.Add(key, wkPaymentMainListResultWork);
                        }

                        ArrayList wkPaymentMainList = new ArrayList();

                        for (int index = 0; index < wkSort.Count; index++)
                        {
                            wkPaymentMainList.Add(wkSort.GetByIndex(index));
                        }
                        // --- ADD 2008/08/05 --------------------------------<<<<< 

						// データ展開処理
                        //DevPaymentMainData(paymentMainCndtn, this._payDs.Tables[DCKAK02525EA.Col_Tbl_PaymentMain], (ArrayList)retPaymentMainList);  // DEL 2008/08/05
                        DevPaymentMainData(paymentMainCndtn, this._payDs.Tables[DCKAK02525EA.Col_Tbl_PaymentMain], wkPaymentMainList);                // ADD 2008/08/05
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "支払データの取得に失敗しました。";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◎ 支払総合計データ取得
        ///// <summary>
        ///// 支払総合計データ取得
        ///// </summary>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 総合計用データを取得する。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.09.10</br>
        ///// </remarks>
        //private int SearchPaymentGrandTotalProc(PaymentMainCndtn paymentMainCndtn, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //    errMsg = "";

        //    try
        //    {
        //        // DataTable Create ----------------------------------------------------------
        //        DCKAK02525EA.CreateDataTablePaymentMain(ref this._payDs);
	
        //        // 抽出条件展開 ---------------------------------------------------------------
        //        PaymentSlpCndtnWork paymentSlpCndtnWork = new PaymentSlpCndtnWork();
        //        status = this.DevPaymentMainCndtn(paymentMainCndtn, out paymentSlpCndtnWork, out errMsg);
        //        if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
        //        {
        //            return status;
        //        }

        //        // データ取得  ----------------------------------------------------------------
        //        object retPaymentMainList = null;
        //        status = this._iPaymentListWorkDB.SearchAllTotal(
        //            out retPaymentMainList, paymentSlpCndtnWork, 0, 0, ConstantManagement.LogicalMode.GetData0);
				
        //        switch ( status )
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                // データ展開処理
        //                DevGrandTotalPaymentMainData(paymentMainCndtn, this._payDs.Tables[DCKAK02525EA.Col_Tbl_PaymentMain], (ArrayList)retPaymentMainList);
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //                break;
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                break;
        //            default:
        //                errMsg = "支払データの取得に失敗しました。";
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
        //#endregion
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        #region ◎ 支払金種別データ取得
        /// <summary>
        /// 支払データ（支払確認表(集計表)）取得
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 支払データ（支払確認表(集計表)）を取得する。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private int SearchPaymentKindTotalProc(PaymentMainCndtn paymentMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                DCKAK02525EA.CreateDataTablePaymentMain(ref this._payDs);

                // 抽出条件展開 ---------------------------------------------------------------
                PaymentSlpCndtnWork paymentSlpCndtnWork = new PaymentSlpCndtnWork();
                status = this.DevPaymentMainCndtn(paymentMainCndtn, out paymentSlpCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retPaymentMainList = null;
                status = this._iPaymentListWorkDB.SearchDepsitKind(
                    out retPaymentMainList, paymentSlpCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // --- ADD 2008/08/05 -------------------------------->>>>>
                        // データをソートする
                        SortedList wkSort = new SortedList();

                        foreach (PaymentSlpListResultWork wkPaymentMainListResultWork in (ArrayList)retPaymentMainList)
                        {
                            string key = wkPaymentMainListResultWork.AddUpSecCode.Trim();
                            switch (paymentMainCndtn.SortOrderDiv)
                            {
                                case PaymentMainCndtn.SortOrderDivState.PayeeDate:  // 支払日順
                                    {
                                        // DEL 2009/01/28 不具合対応[9701] ---------->>>>>
                                        //// 支払日順(拠点－支払日－伝票番号－仕入先ｺｰﾄﾞ)
                                        //key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                        //    + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                        //    + wkPaymentMainListResultWork.SupplierCd.ToString("d09");
                                        //+wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        // DEL 2009/01/28 不具合対応[9701] ----------<<<<<
                                        // ADD 2009/01/28 不具合対応[9701] ---------->>>>>
                                        // 支払日順(拠点－仕入先ｺｰﾄﾞ－支払日－伝票番号)
                                        key += wkPaymentMainListResultWork.SupplierCd.ToString("d09");
                                        key += TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate);
                                        key += wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09");
                                        key += wkPaymentMainListResultWork.PaymentRowNo.ToString("d02"); ;
                                        // ADD 2008/01/28 不具合対応[9701] ----------<<<<<
                                        break;
                                    }
                                case PaymentMainCndtn.SortOrderDivState.InputDate:  // 入力日順
                                    {
                                        // DEL 2009/01/28 不具合対応[9701] ---------->>>>>
                                        //// 入力日順(拠点－入力日－伝票番号－仕入先ｺｰﾄﾞ)
                                        //key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.PaymentDate)
                                        //    + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                        //    + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                        //    + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        // DEL 2009/01/28 不具合対応[9701] ----------<<<<<
                                        // ADD 2009/01/28 不具合対応[9701] ---------->>>>>
                                        // 入力日順(拠点－仕入先ｺｰﾄﾞ－入力日－伝票番号)
                                        key += wkPaymentMainListResultWork.SupplierCd.ToString("d09");
                                        //key += TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.PaymentDate); // DEL 2009/02/19
                                        //key += TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.CreateDateTime); // ADD 2009/02/19 // DEL 2009/03/26
                                        key += this.DateTimeToStringForSortKey(wkPaymentMainListResultWork.InputDay); // ADD 2009/03/26
                                        key += wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09");
                                        key += wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        // ADD 2008/01/28 不具合対応[9701] ----------<<<<<
                                        break;
                                    }
                                case PaymentMainCndtn.SortOrderDivState.SlipNo:  // 伝票番号順
                                    {
                                        // DEL 2009/01/28 不具合対応[9701] ---------->>>>>
                                        //// 伝票番号順(拠点－伝票番号－支払日－仕入先ｺｰﾄﾞ)
                                        //key = key + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                        //    + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                        //    + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                        //    + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        // DEL 2009/01/28 不具合対応[9701] ----------<<<<<
                                        // ADD 2009/01/28 不具合対応[9701] ---------->>>>>
                                        // 伝票番号順(拠点－仕入先ｺｰﾄﾞ－伝票番号－支払日)
                                        key += wkPaymentMainListResultWork.SupplierCd.ToString("d09");
                                        key += wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09");
                                        key += TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate);
                                        key += wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        // ADD 2008/01/28 不具合対応[9701] ----------<<<<<
                                        break;
                                    }
                                // --- ADD 2012/10/03 ---------------------------->>>>>
                                case PaymentMainCndtn.SortOrderDivState.SupplSec:  // 仕入先-拠点順
                                    {
                                        // 仕入先-拠点順(仕入先ｺｰﾄﾞ－拠点－伝票番号－支払日)
                                        key = wkPaymentMainListResultWork.SupplierCd.ToString("d09");
                                        key += wkPaymentMainListResultWork.AddUpSecCode.Trim();
                                        key += wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09");
                                        key += TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate);
                                        key += wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                                // --- ADD 2012/10/03 ----------------------------<<<<<
                                default:
                                    {
                                        // デフォルトは支払日順とする
                                        key = key + TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, wkPaymentMainListResultWork.AddUpADate)
                                            + wkPaymentMainListResultWork.PaymentSlipNo.ToString("d09")
                                            + wkPaymentMainListResultWork.SupplierCd.ToString("d09")
                                            + wkPaymentMainListResultWork.PaymentRowNo.ToString("d02");
                                        break;
                                    }
                            }
                            // 取得した抽出結果をソート
                            wkSort.Add(key, wkPaymentMainListResultWork);
                        }

                        ArrayList wkPaymentMainList = new ArrayList();

                        for (int index = 0; index < wkSort.Count; index++)
                        {
                            wkPaymentMainList.Add(wkSort.GetByIndex(index));
                        }
                        // --- ADD 2008/08/05 --------------------------------<<<<< 

                        // データ展開処理
                        //DevKindTotalPaymentMainData(paymentMainCndtn, this._payDs.Tables[DCKAK02525EA.Col_Tbl_PaymentMain], (ArrayList)retPaymentMainList);  // DEL 2008/08/05
                        DevKindTotalPaymentMainData(paymentMainCndtn, this._payDs.Tables[DCKAK02525EA.Col_Tbl_PaymentMain], wkPaymentMainList);                // ADD 2008/08/05
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "支払データの取得に失敗しました。";
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
            string dateTimeStr = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, dateTime);

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
		/// <param name="paymentMainCndtn">UI抽出条件クラス</param>
		/// <param name="paymentSlpCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevPaymentMainCndtn(PaymentMainCndtn paymentMainCndtn, out PaymentSlpCndtnWork paymentSlpCndtnWork, out string errMsg)
		{
                                                                               
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			errMsg = string.Empty;
            paymentSlpCndtnWork = new PaymentSlpCndtnWork();

			try
			{
				paymentSlpCndtnWork.EnterpriseCode = paymentMainCndtn.EnterpriseCode;

				// 企業コード
				// 抽出条件パラメータセット
                if (paymentMainCndtn.PaymentAddupSecCodeList.Length != 0)
				{
					if ( paymentMainCndtn.IsSelectAllSection )
					{
						// 全社の時
                        paymentSlpCndtnWork.PaymentAddupSecCodeList = null;
					}
					else
					{
                        paymentSlpCndtnWork.PaymentAddupSecCodeList = paymentMainCndtn.PaymentAddupSecCodeList;
					}
				}
				else
				{
                    paymentSlpCndtnWork.PaymentAddupSecCodeList = null;
				}

                paymentSlpCndtnWork.PaymentKind = new ArrayList(paymentMainCndtn.PaymentKind.Keys);  // 支払金種
				paymentSlpCndtnWork.St_AddUpADate	= paymentMainCndtn.St_AddUpADate;	             // 開始支払計上日
				paymentSlpCndtnWork.Ed_AddUpADate	= paymentMainCndtn.Ed_AddupADate;	             // 終了支払計上日
                paymentSlpCndtnWork.St_InputDate = paymentMainCndtn.St_InputDate;                    // 開始支払入力日
                paymentSlpCndtnWork.Ed_InputDate = paymentMainCndtn.Ed_InputDate;                    // 終了支払入力日
                paymentSlpCndtnWork.PrintDiv = paymentMainCndtn.PrintDiv;                            // タイプ
                //paymentSlpCndtnWork.SortOrderDiv = (int)paymentMainCndtn.SortOrderDiv;               // 出力順  // DEL 2008/08/05
                paymentSlpCndtnWork.St_PayeeCode = paymentMainCndtn.St_PayeeCode;		             // 開始支払先コード
                paymentSlpCndtnWork.Ed_PayeeCode = paymentMainCndtn.Ed_PayeeCode;		             // 終了支払先コード
                paymentSlpCndtnWork.St_PayeeKana = paymentMainCndtn.St_PayeeKana;		             // 開始支払先カナ
                paymentSlpCndtnWork.Ed_PayeeKana = paymentMainCndtn.Ed_PayeeKana;		             // 終了支払先カナ

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //paymentSlpCndtnWork.EmployeeKindDiv = (int)paymentMainCndtn.EmployeeKindDiv;       // 担当者区分
                //paymentSlpCndtnWork.St_EmployeeCode = paymentMainCndtn.St_EmployeeCode;		     // 開始担当者コード
                //paymentSlpCndtnWork.Ed_EmployeeCode = paymentMainCndtn.Ed_EmployeeCode;		     // 終了担当者コード
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                paymentSlpCndtnWork.St_PaymentSlipNo = paymentMainCndtn.St_PaymentSlipNo;		     // 開始支払番号
                paymentSlpCndtnWork.Ed_PaymentSlipNo = paymentMainCndtn.Ed_PaymentSlipNo;		     // 終了支払番号

                // --- ADD 2008/11/12 -------------------------------------------------------------------------->>>>>
                // 金種位置情報クリア
                stc_dicPaymentStRowNo.Clear();
                stc_dicPaymentStKindCd.Clear();

                // 画面で選択された金種情報取得
                if ((paymentMainCndtn.PaymentKind.Count == 1) && ((int)paymentMainCndtn.PaymentKind.GetKey(0) == -1))
                {
                    // 全て
                    stc_cndtnKindSortList = stc_paymentKindSortList;
                }
                else
                {
                    // 全て以外
                    stc_cndtnKindSortList = paymentMainCndtn.PaymentKind;
                }
                // --- ADD 2008/11/12 --------------------------------------------------------------------------<<<<<
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

		private int GetSortOrder( int sumDiv, int sortOrderDiv )
		{
			return sumDiv * 10 + sortOrderDiv;
		}
		#endregion

		#region ◎ 支払データ展開処理
		/// <summary>
        /// 支払データ（支払確認表）展開処理
		/// </summary>
		/// <param name="paymentMainCndtn">UI抽出条件クラス</param>
		/// <param name="paymentMainDt">展開対象DataTable</param>
		/// <param name="paymentMainWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 支払データ（支払確認表）を展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private void DevPaymentMainData(PaymentMainCndtn paymentMainCndtn, DataTable paymentMainDt, ArrayList paymentMainWork)
		{
			string workStr_1 = "";
			string workStr_2 = "";
			DataRow dr = null;

            // --- ADD 2008/08/05 -------------------------------->>>>>
            int paymentSlipNo_Tmp = -1;         // 伝票番号控え
            string validityTerm_Tmp = "";       // 有効期限控え

            if (stc_dicPaymentStRowNo.Count <= 0)
            {
                // 支払設定マスタの金種コードが未取得の場合は取得を行う
                GetPaymentSet();
            }
            // --- ADD 2008/08/05 --------------------------------<<<<< 

            foreach (PaymentSlpListResultWork paymainResWork in paymentMainWork)
			{
                if (paymentSlipNo_Tmp != paymainResWork.PaymentSlipNo)  // ADD 2008/08/05
                {
                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    // 伝票番号が変わったらTableに追加してデータを取得
                    if (paymentSlipNo_Tmp != -1)
                    {
                        // TableにAdd
                        paymentMainDt.Rows.Add(dr);
                    }

                    // 伝票番号控えに取得伝票番号を設定
                    paymentSlipNo_Tmp = paymainResWork.PaymentSlipNo;
                    // --- ADD 2008/08/05 --------------------------------<<<<< 

                    dr = paymentMainDt.NewRow();

                    // 支払基本データ展開
                    #region 支払データ展開

                    GetDebitNoteCdName(paymainResWork.DebitNoteDiv, out workStr_1, out workStr_2);
                    // 支払赤黒区分
                    dr[DCKAK02525EA.Col_PaymentDebitNoteCd] = paymainResWork.DebitNoteDiv;
                    // 支払赤黒区分名称
                    dr[DCKAK02525EA.Col_PaymentDebitNoteCdName] = workStr_1.TrimEnd();
                    // 支払赤黒区分記号
                    dr[DCKAK02525EA.Col_PaymentDebitNoteSign] = workStr_2.TrimEnd();
                    // 支払伝票番号
                    dr[DCKAK02525EA.Col_PaymentSlipNo] = paymainResWork.PaymentSlipNo;
                    // 赤黒支払連結番号
                    dr[DCKAK02525EA.Col_DebitNoteLinkPayNo] = paymainResWork.DebitNoteLinkPayNo;
                    // 支払入力拠点コード
                    dr[DCKAK02525EA.Col_InputPaymentSecCd] = paymainResWork.PaymentInpSectionCd;
                    // 支払入力拠点名称
                    dr[DCKAK02525EA.Col_InputPaymentSecNm] = paymainResWork.PaymentInpSectionNm.TrimEnd();
                    // 計上拠点コード
                    dr[DCKAK02525EA.Col_AddUpSecCode] = paymainResWork.AddUpSecCode;
                    // 計上拠点名称
                    //if ( paymentMainCndtn.IsSelectAllSection)
                    //    dr[DCKAK02525EA.Col_AddUpSecName] = "全社";
                    //else
                    dr[DCKAK02525EA.Col_AddUpSecName] = paymainResWork.AddUpSecName.TrimEnd();
                    // 計上拠点名称(明細)
                    dr[DCKAK02525EA.Col_AddUpSecName_Detail] = paymainResWork.AddUpSecName.TrimEnd();
                    // 支払日(表示用)
                    dr[DCKAK02525EA.Col_PaymentDate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.PaymentDate);
                    // 支払日(ソート用)
                    dr[DCKAK02525EA.Col_Sort_PaymentDate] = TDateTime.DateTimeToLongDate(paymainResWork.PaymentDate);
                    // 計上日付
                    dr[DCKAK02525EA.Col_AddUpADate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.AddUpADate);
                    // 計上日付(ソート用)
                    dr[DCKAK02525EA.Col_Sort_AddUpADate] = TDateTime.DateTimeToLongDate(paymainResWork.AddUpADate);
                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    #region 削除コード
                    //// 支払金種コード
                    //dr[DCKAK02525EA.Col_PaymentKindCode] = paymainResWork.PaymentMoneyKindCode;
                    //// 支払金種名称
                    //dr[DCKAK02525EA.Col_PaymentKindName] = paymainResWork.PaymentMoneyKindName;
                    //// 支払金種区分
                    //dr[DCKAK02525EA.Col_PaymentKindDivCd] = paymainResWork.PaymentMoneyKindDiv;
                    #endregion
                    // --- DEL 2008/08/05 --------------------------------<<<<< 
                    // 支払計
                    dr[DCKAK02525EA.Col_PaymentTotal] = paymainResWork.PaymentTotal;
                    // 支払金額
                    dr[DCKAK02525EA.Col_Payment] = paymainResWork.Payment;
                    // 手数料
                    dr[DCKAK02525EA.Col_FeePayment] = paymainResWork.FeePayment;
                    // 値引
                    dr[DCKAK02525EA.Col_DiscountPayment] = paymainResWork.DiscountPayment;
                    // 自動支払区分
                    dr[DCKAK02525EA.Col_AutoPaymentCd] = paymainResWork.AutoPayment;
                    // 手形振出日	
                    dr[DCKAK02525EA.Col_DraftDrawingDate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.DraftDrawingDate);
                    // 手形支払期日
                    //dr[DCKAK02525EA.Col_DraftPayTimeLimit] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.DraftPayTimeLimit);  // DEL 2008/08/05
                    // 手形種類
                    dr[DCKAK02525EA.Col_DraftKind] = paymainResWork.DraftKind;
                    // 手形種類名称
                    dr[DCKAK02525EA.Col_DraftKindName] = paymainResWork.DraftKindName;
                    // 手形区分
                    dr[DCKAK02525EA.Col_DraftDivide] = paymainResWork.DraftDivide;
                    // 手形区分名称
                    dr[DCKAK02525EA.Col_DraftDivideName] = paymainResWork.DraftDivideName;
                    // 手形番号
                    dr[DCKAK02525EA.Col_DraftNo] = paymainResWork.DraftNo;
                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    #region 削除コード
                    //// 得意先コード
                    //dr[DCKAK02525EA.Col_CustomerCode] = paymainResWork.CustomerCode;
                    //// 得意先名称
                    //dr[DCKAK02525EA.Col_CustomerName] = paymainResWork.CustomerName;
                    //// 得意先名称2
                    //dr[DCKAK02525EA.Col_CustomerName2] = paymainResWork.CustomerName2;
                    #endregion
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    // 仕入先コード
                    dr[DCKAK02525EA.Col_SupplierCd] = paymainResWork.SupplierCd;
                    // 仕入先名1
                    dr[DCKAK02525EA.Col_SupplierNm1] = paymainResWork.SupplierNm1;
                    // 仕入先名2
                    dr[DCKAK02525EA.Col_SupplierNm2] = paymainResWork.SupplierNm2;
                    // 仕入先略称
                    dr[DCKAK02525EA.Col_SupplierSnm] = paymainResWork.SupplierSnm;  // ADD 2008/10/08 不具合対応[5868]

                    // 支払先コード
                    dr[DCKAK02525EA.Col_PayeeCode] = paymainResWork.PayeeCode;
                    // 支払先名称
                    dr[DCKAK02525EA.Col_PayeeName] = paymainResWork.PayeeName;
                    // 支払先名称2
                    dr[DCKAK02525EA.Col_PayeeName2] = paymainResWork.PayeeName2;
                    // 支払先略称
                    dr[DCKAK02525EA.Col_PayeeSnm] = paymainResWork.PayeeSnm;
                    // --- ADD 2008/08/05 --------------------------------<<<<< 

                    // 伝票適用 
                    dr[DCKAK02525EA.Col_Outline] = paymainResWork.Outline;

                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    #region 削除コード
                    //// 担当者コード
                    //// 担当者名称
                    //if (paymentMainCndtn.EmployeeKindDiv == PaymentMainCndtn.EmployeeKindDivState.InPayment)
                    //{
                    //    dr[DCKAK02525EA.Col_AgentCode] = paymainResWork.PaymentInputAgentCd;
                    //    dr[DCKAK02525EA.Col_AgentNm] = paymainResWork.PaymentInputAgentNm;
                    //}
                    //else
                    //{
                    //    dr[DCKAK02525EA.Col_AgentCode] = paymainResWork.PaymentAgentCode;
                    //    dr[DCKAK02525EA.Col_AgentNm] = paymainResWork.PaymentAgentName;
                    //}

                    //// 小計区分を決める
                    //string miniTotal = string.Empty;
                    //switch (paymentMainCndtn.PrintDiv)
                    //{
                    //    case (int)PaymentMainCndtn.PrintDivState.GrandTotal:			// 総合計
                    //    case (int)PaymentMainCndtn.PrintDivState.KindTotal:		        // 金種
                    //    {
                    //        miniTotal = string.Empty;
                    //        break;
                    //    }
                    //    case (int)PaymentMainCndtn.PrintDivState.Details:		        // 詳細
                    //    case (int)PaymentMainCndtn.PrintDivState.Simple:				// 簡易
                    //    {
                    //        // 小計区分で改ページ条件を選択
                    //        switch (paymentMainCndtn.SumDiv)
                    //        {
                    //            case PaymentMainCndtn.SumDivState.Day:				// 日計
                    //                miniTotal = TDateTime.DateTimeToLongDate( paymainResWork.AddUpADate ).ToString();
                    //                break;
                    //            case PaymentMainCndtn.SumDivState.Payee:			// 支払先計
                    //                //miniTotal = paymainResWork.CustomerCode.ToString();  // DEL 2008/08/05
                    //                miniTotal = paymainResWork.SupplierCd.ToString();      // ADD 2008/08/05
                    //                break;
                    //            case PaymentMainCndtn.SumDivState.PaymentKind:		// 金種計
                    //                //miniTotal = paymainResWork.PaymentMoneyKindCode.ToString();  // DEL 2008/08/05
                    //                break;
                    //            case PaymentMainCndtn.SumDivState.PaymentSlipNo:	// 支払番号
                    //                miniTotal = string.Empty;	// 支払番号のときは小計を表示しない。
                    //                break;
                    //            default:
                    //                miniTotal = string.Empty;
                    //                break;
                    //        }
                    //        break;
                    //    }
                    //    default: 
                    //        miniTotal = string.Empty;
                    //        break;
                    //}
                    //dr[DCKAK02525EA.Col_MiniTotal_KeyBleak] = miniTotal;
                    #endregion
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    // --- DEL 2009/03/26 -------------------------------->>>>>
                    // --- ADD 2009/02/19 -------------------------------->>>>>
                    //// 作成日時
                    //dr[DCKAK02525EA.Col_CreateDateTime] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.CreateDateTime);
                    // --- ADD 2009/02/19 --------------------------------<<<<<
                    // --- DEL 2009/03/26 --------------------------------<<<<<
                    // --- ADD 2009/03/26 -------------------------------->>>>>
                    // 入力日
                    dr[DCKAK02525EA.Col_InputDay] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.InputDay);
                    // --- ADD 2009/03/26 --------------------------------<<<<<

                    dr[DCKAK02525EA.Col_MiniTotal_KeyBleak] = string.Empty;  // ADD 2008/08/05

                    // 有効期限
                    if (paymainResWork.MoneyKindDiv == 105)
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        validityTerm_Tmp = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.ValidityTerm);
                        dr[DCKAK02525EA.Col_ValidityTerm] = validityTerm_Tmp;
                    }
                    else
                    {
                        // 金種区分が「手形」以外の場合は空文字を設定
                        validityTerm_Tmp = "";
                    }

                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicPaymentStRowNo.ContainsKey(paymainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int paymentKindRowNo = stc_dicPaymentStRowNo[paymainResWork.MoneyKindCode];
                        switch (paymentKindRowNo)
                        {
                            case 1:  // 金種１
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No1] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 2:  // 金種２
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No2] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 3:  // 金種３
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No3] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 4:  // 金種４
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No4] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 5:  // 金種５
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No5] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 6:  // 金種６
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No6] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 7:  // 金種７
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No7] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 8:  // 金種８
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No8] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 9:  // 金種９
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No9] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 10:  // 金種１０
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No10] = paymainResWork.PaymentMei;
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    // 伝票番号が同じ場合

                    // 有効期限
                    if ((validityTerm_Tmp == "") && (paymainResWork.MoneyKindDiv == 105))
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        validityTerm_Tmp = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.ValidityTerm);
                        dr[DCKAK02525EA.Col_ValidityTerm] = validityTerm_Tmp;
                    }

                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicPaymentStRowNo.ContainsKey(paymainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int depositKindRowNo = stc_dicPaymentStRowNo[paymainResWork.MoneyKindCode];
                        switch (depositKindRowNo)
                        {
                            case 1:  // 金種１
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No1] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 2:  // 金種２
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No2] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 3:  // 金種３
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No3] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 4:  // 金種４
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No4] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 5:  // 金種５
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No5] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 6:  // 金種６
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No6] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 7:  // 金種７
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No7] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 8:  // 金種８
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No8] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 9:  // 金種９
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No9] = paymainResWork.PaymentMei;
                                    break;
                                }
                            case 10:  // 金種１０
                                {
                                    dr[DCKAK02525EA.Col_PaymentKind_No10] = paymainResWork.PaymentMei;
                                    break;
                                }
                        }
                    }
                }

				#endregion
            }   // foreach (PaymentSlpListResultWork paymainResWork in paymentMainWork)

            // TableにAdd
            paymentMainDt.Rows.Add(dr);
		}
		#endregion

        // --- DEL 2008/08/05 -------------------------------->>>>>
        //#region ◎ 支払総合計データ展開処理
        ///// <summary>
        ///// 支払総合計データ展開処理
        ///// </summary>
        ///// <param name="paymentMainCndtn">UI抽出条件クラス</param>
        ///// <param name="paymentMainDt">展開対象DataTable</param>
        ///// <param name="paymentMainWork">取得データ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 支払データを展開する。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.09.10</br>
        ///// </remarks>
        //private void DevGrandTotalPaymentMainData( PaymentMainCndtn paymentMainCndtn, DataTable paymentMainDt, ArrayList paymentMainWork)
        //{
        //    DataRow dr;

        //    //SortedList payKindListWork = (SortedList)stc_paymentKindSortList.Clone();

        //    //// 金種リスト初期化
        //    //foreach ( DictionaryEntry de in stc_paymentKindSortList )
        //    //{
        //    //    dr = paymentMainDt.NewRow();
        //    //    dr[DCKAK02525EA.Col_PaymentKindCode]  = ((MoneyKind)de.Value).MoneyKindCode;	            // 金種コード
        //    //    dr[DCKAK02525EA.Col_PaymentKindName]  = ((MoneyKind)de.Value).MoneyKindName;	            // 金種名称
        //    //    dr[DCKAK02525EA.Col_PaymentKindDivCd] = ((MoneyKind)de.Value).MoneyKindDiv;	                // 金種区分
        //    //    payKindListWork[(int)de.Key] = dr;
        //    //}

        //    foreach (PaymentSlpListResultWork paymainResWork in paymentMainWork)
        //    {
        //        //// 金種リストに指定したキーが格納されているかチェック
        //        //if (payKindListWork.ContainsKey(paymainResWork.PaymentMoneyKindCode))
        //        //{
        //        //    dr = (DataRow)(payKindListWork[paymainResWork.PaymentMoneyKindCode]);
        //        //}
        //        //else
        //        //{
        //        //    dr = paymentMainDt.NewRow();
        //        //    payKindListWork.Add(paymainResWork.PaymentMoneyKindCode, dr);
        //        //}

        //        dr = paymentMainDt.NewRow();
        //        // 支払基本データ展開
        //        #region 支払データ展開
        //        // 計上拠点コード
        //        dr[DCKAK02525EA.Col_AddUpSecCode] = paymainResWork.AddUpSecCode;
        //        //// 計上拠点名称
        //        //if ( paymentMainCndtn.IsSelectAllSection )
        //        //    dr[DCKAK02525EA.Col_AddUpSecName] = "全社";
        //        //else
        //        dr[DCKAK02525EA.Col_AddUpSecName] = paymainResWork.AddUpSecName.TrimEnd();

        //        // --- DEL 2008/08/05 -------------------------------->>>>>
        //        //// 金種コード
        //        //dr[DCKAK02525EA.Col_PaymentKindCode] = paymainResWork.PaymentMoneyKindCode;
        //        //// 金種名称
        //        //dr[DCKAK02525EA.Col_PaymentKindName] = paymainResWork.PaymentMoneyKindName;
        //        //// 金種区分
        //        //dr[DCKAK02525EA.Col_PaymentKindDivCd] = paymainResWork.PaymentMoneyKindDiv;
        //        // --- DEL 2008/08/05 --------------------------------<<<<< 

        //        // 計上日付
        //        dr[DCKAK02525EA.Col_AddUpADate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.AddUpADate);
        //        // 計上日付(ソート用)
        //        dr[DCKAK02525EA.Col_Sort_AddUpADate] = TDateTime.DateTimeToLongDate(paymainResWork.AddUpADate);
        //        // 支払計
        //        dr[DCKAK02525EA.Col_PaymentTotal] = paymainResWork.PaymentTotal + (long)dr[DCKAK02525EA.Col_PaymentTotal];
        //        // 自動支払区分
        //        dr[DCKAK02525EA.Col_AutoPaymentCd] = paymainResWork.AutoPayment;
        //        // 小計区分
        //        dr[DCKAK02525EA.Col_MiniTotal_KeyBleak] = string.Empty;
        //        #endregion
        //        // 通常支払計
        //        dr[DCKAK02525EA.Col_NomalPaymentTotal] = paymainResWork.Payment + (long)dr[DCKAK02525EA.Col_NomalPaymentTotal];
        //        // 手数料計
        //        dr[DCKAK02525EA.Col_FeePaymentTotal] = paymainResWork.FeePayment + (long)dr[DCKAK02525EA.Col_FeePaymentTotal];
        //        // 値引計
        //        dr[DCKAK02525EA.Col_DiscountPaymentTotal] = paymainResWork.DiscountPayment + (long)dr[DCKAK02525EA.Col_DiscountPaymentTotal];
        //        // 金種計
        //        dr[DCKAK02525EA.Col_PayKindTotal] = (long)dr[DCKAK02525EA.Col_NomalPaymentTotal] + (long)dr[DCKAK02525EA.Col_FeePaymentTotal] + (long)dr[DCKAK02525EA.Col_DiscountPaymentTotal];

        //        paymentMainDt.Rows.Add( dr );
        //    }

        //    // TableにAdd
        //    //foreach ( DictionaryEntry de in payKindListWork )
        //    //{
        //    //    paymentMainDt.Rows.Add( (DataRow)de.Value );
        //    //}
        //}
        //#endregion
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        #region ◎ 支払金種別データ展開処理
        /// <summary>
        /// 支払データ（支払確認表(集計表)）展開処理
        /// </summary>
        /// <param name="paymentMainCndtn">UI抽出条件クラス</param>
        /// <param name="paymentMainDt">展開対象DataTable</param>
        /// <param name="paymentMainWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 支払データ（支払確認表(集計表)）を展開する。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private void DevKindTotalPaymentMainData(PaymentMainCndtn paymentMainCndtn, DataTable paymentMainDt, ArrayList paymentMainWork)
        {
            // --- ADD 2008/08/05 -------------------------------->>>>>
            //string workStr_1 = "";
            //string workStr_2 = "";
            int paymentSlipNo_Tmp = -1;         // 伝票番号控え
            int payeeCode_Tmp = -1;             // 支払先コード控え
            // --- ADD 2012/10/03 ---------------------------->>>>>
            string sectionCode_Tmp = "";        // 拠点コード控え
            // --- ADD 2012/10/03 ----------------------------<<<<<
            string validityTerm_Tmp = "";       // 有効期限控え

            // 金額の一時計算プロパティ
            long paymentTotal = 0;
            long payment = 0;
            long feePayment = 0;
            long discountPayment = 0;
            long[] paymentDtl = new long[10];
            // --- ADD 2008/08/05 --------------------------------<<<<< 

            DataRow dr = null;

            // --- ADD 2008/08/05 -------------------------------->>>>>
            if (stc_dicPaymentStRowNo.Count <= 0)
            {
                // 支払設定マスタの金種コードが未取得の場合は取得を行う
                GetPaymentSet();
            }
            // --- ADD 2008/08/05 --------------------------------<<<<< 

            foreach (PaymentSlpListResultWork paymainResWork in paymentMainWork)
            {
                // --- DEL 2012/10/03 ---------------------------->>>>>
                //if (payeeCode_Tmp != paymainResWork.PayeeCode)  // ADD 2008/08/05
                // --- DEL 2012/10/03 ----------------------------<<<<<
                // --- ADD 2012/10/03 ---------------------------->>>>>
                if (payeeCode_Tmp != paymainResWork.PayeeCode || (this._optSuppEnable && sectionCode_Tmp != paymainResWork.AddUpSecCode))
                // --- ADD 2012/10/03 ----------------------------<<<<<
                {
                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    // 支払先コードが変わったらTableに追加してデータを取得
                    if (paymentSlipNo_Tmp != -1)
                    {
                        // 金額の一時計算プロパティの値を設定
                        // 支払計
                        dr[DCKAK02525EA.Col_PaymentTotal] = paymentTotal;
                        // 支払金額
                        dr[DCKAK02525EA.Col_Payment] = payment;
                        // 手数料支払額
                        dr[DCKAK02525EA.Col_FeePayment] = feePayment;
                        // 値引支払額
                        dr[DCKAK02525EA.Col_DiscountPayment] = discountPayment;

                        // 金種毎の金額を設定
                        dr[DCKAK02525EA.Col_PaymentKind_No1] = paymentDtl[0];   // 金種1
                        dr[DCKAK02525EA.Col_PaymentKind_No2] = paymentDtl[1];   // 金種2
                        dr[DCKAK02525EA.Col_PaymentKind_No3] = paymentDtl[2];   // 金種3
                        dr[DCKAK02525EA.Col_PaymentKind_No4] = paymentDtl[3];   // 金種4
                        dr[DCKAK02525EA.Col_PaymentKind_No5] = paymentDtl[4];   // 金種5
                        dr[DCKAK02525EA.Col_PaymentKind_No6] = paymentDtl[5];   // 金種6
                        dr[DCKAK02525EA.Col_PaymentKind_No7] = paymentDtl[6];   // 金種7
                        dr[DCKAK02525EA.Col_PaymentKind_No8] = paymentDtl[7];   // 金種8
                        dr[DCKAK02525EA.Col_PaymentKind_No9] = paymentDtl[8];   // 金種9
                        dr[DCKAK02525EA.Col_PaymentKind_No10] = paymentDtl[9];  // 金種10

                        // 金種計
                        dr[DCKAK02525EA.Col_PayKindTotal] = paymentDtl[0] + paymentDtl[1] + paymentDtl[2] + paymentDtl[3] + paymentDtl[4] +
                                                            paymentDtl[5] + paymentDtl[6] + paymentDtl[7] + paymentDtl[8] + paymentDtl[9];

                        // TableにAdd
                        paymentMainDt.Rows.Add(dr);

                        // 金額の一時計算プロパティの値を初期化
                        paymentTotal = 0;
                        payment = 0;
                        feePayment = 0;
                        discountPayment = 0;
                    }

                    // 支払先コード控えに取得伝票番号を設定
                    payeeCode_Tmp = paymainResWork.PayeeCode;
                    // --- ADD 2012/10/03 ---------------------------->>>>>
                    // 拠点コードの控えを設定
                    sectionCode_Tmp = paymainResWork.AddUpSecCode;
                    // --- ADD 2012/10/03 ----------------------------<<<<<

                    // 支払明細の支払金額を初期化
                    for (int i = 0; i < paymentDtl.Length; i++)
                    {
                        paymentDtl[i] = new long();
                    }
                    // --- ADD 2008/08/05 --------------------------------<<<<< 

                    dr = paymentMainDt.NewRow();
                    // 支払基本データ展開
                    #region 支払データ展開
                    // 支払伝票番号
                    dr[DCKAK02525EA.Col_PaymentSlipNo] = paymainResWork.PaymentSlipNo;
                    // 赤黒支払連結番号
                    dr[DCKAK02525EA.Col_DebitNoteLinkPayNo] = paymainResWork.DebitNoteLinkPayNo;
                    // 支払入力拠点コード
                    dr[DCKAK02525EA.Col_InputPaymentSecCd] = paymainResWork.PaymentInpSectionCd;
                    // 支払入力拠点名称
                    dr[DCKAK02525EA.Col_InputPaymentSecNm] = paymainResWork.PaymentInpSectionNm.TrimEnd();
                    // 計上拠点コード
                    dr[DCKAK02525EA.Col_AddUpSecCode] = paymainResWork.AddUpSecCode;
                    //// 計上拠点名称
                    //if (paymentMainCndtn.IsSelectAllSection)
                    //    dr[DCKAK02525EA.Col_AddUpSecName] = "全社";
                    //else
                    dr[DCKAK02525EA.Col_AddUpSecName] = paymainResWork.AddUpSecName.TrimEnd();
                    // 計上拠点名称(明細)
                    dr[DCKAK02525EA.Col_AddUpSecName_Detail] = paymainResWork.AddUpSecName.TrimEnd();
                    // 支払日(表示用)
                    dr[DCKAK02525EA.Col_PaymentDate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.PaymentDate);
                    // 支払日(ソート用)
                    dr[DCKAK02525EA.Col_Sort_PaymentDate] = TDateTime.DateTimeToLongDate(paymainResWork.PaymentDate);
                    // 計上日付
                    dr[DCKAK02525EA.Col_AddUpADate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.AddUpADate);
                    // 計上日付(ソート用)
                    dr[DCKAK02525EA.Col_Sort_AddUpADate] = TDateTime.DateTimeToLongDate(paymainResWork.AddUpADate);
                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    //// 支払金種コード
                    //dr[DCKAK02525EA.Col_PaymentKindCode] = paymainResWork.PaymentMoneyKindCode;
                    //// 支払金種名称
                    //dr[DCKAK02525EA.Col_PaymentKindName] = paymainResWork.PaymentMoneyKindName;
                    //// 支払金種区分
                    //dr[DCKAK02525EA.Col_PaymentKindDivCd] = paymainResWork.PaymentMoneyKindDiv;
                    // --- DEL 2008/08/05 --------------------------------<<<<< 
                    // 支払計
                    dr[DCKAK02525EA.Col_PaymentTotal] = paymainResWork.PaymentTotal;
                    // 支払金額
                    dr[DCKAK02525EA.Col_Payment] = paymainResWork.Payment;
                    // 手数料
                    dr[DCKAK02525EA.Col_FeePayment] = paymainResWork.FeePayment;
                    // 値引
                    dr[DCKAK02525EA.Col_DiscountPayment] = paymainResWork.DiscountPayment;
                    // 手形振出日	
                    dr[DCKAK02525EA.Col_DraftDrawingDate] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.DraftDrawingDate);
                    // 手形支払期日
                    //dr[DCKAK02525EA.Col_DraftPayTimeLimit] = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.DraftPayTimeLimit);  // DEL 2008/08/05
                    // 手形種類
                    dr[DCKAK02525EA.Col_DraftKind] = paymainResWork.DraftKind;
                    // 手形種類名称
                    dr[DCKAK02525EA.Col_DraftKindName] = paymainResWork.DraftKindName;
                    // 手形区分
                    dr[DCKAK02525EA.Col_DraftDivide] = paymainResWork.DraftDivide;
                    // 手形区分名称
                    dr[DCKAK02525EA.Col_DraftDivideName] = paymainResWork.DraftDivideName;
                    // 手形番号
                    dr[DCKAK02525EA.Col_DraftNo] = paymainResWork.DraftNo;
                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    //// 得意先コード
                    //dr[DCKAK02525EA.Col_CustomerCode] = paymainResWork.CustomerCode;
                    //// 得意先名称
                    //dr[DCKAK02525EA.Col_CustomerName] = paymainResWork.CustomerName;
                    //// 得意先名称2
                    //dr[DCKAK02525EA.Col_CustomerName2] = paymainResWork.CustomerName2;
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    // 仕入先コード
                    dr[DCKAK02525EA.Col_SupplierCd] = paymainResWork.SupplierCd;
                    // 仕入先名1
                    dr[DCKAK02525EA.Col_SupplierNm1] = paymainResWork.SupplierNm1;
                    // 仕入先名2
                    dr[DCKAK02525EA.Col_SupplierNm2] = paymainResWork.SupplierNm2;
                    // 仕入先略称
                    dr[DCKAK02525EA.Col_SupplierSnm] = paymainResWork.SupplierSnm;  // ADD 2008/10/08 不具合対応[5868]

                    // 支払先コード
                    dr[DCKAK02525EA.Col_PayeeCode] = paymainResWork.PayeeCode;
                    // 支払先名称
                    dr[DCKAK02525EA.Col_PayeeName] = paymainResWork.PayeeName;
                    // 支払先名称2
                    dr[DCKAK02525EA.Col_PayeeName2] = paymainResWork.PayeeName2;
                    // 支払先略称
                    dr[DCKAK02525EA.Col_PayeeSnm] = paymainResWork.PayeeSnm;
                    // --- ADD 2008/08/05 --------------------------------<<<<< 

                    // 伝票適用 
                    dr[DCKAK02525EA.Col_Outline] = paymainResWork.Outline;

                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    // 担当者コード
                    // 担当者名称
                    //if (paymentMainCndtn.EmployeeKindDiv == PaymentMainCndtn.EmployeeKindDivState.InPayment)
                    //{
                    //    dr[DCKAK02525EA.Col_AgentCode] = paymainResWork.PaymentInputAgentCd;
                    //    dr[DCKAK02525EA.Col_AgentNm] = paymainResWork.PaymentInputAgentNm;
                    //}
                    //else
                    //{
                    //    dr[DCKAK02525EA.Col_AgentCode] = paymainResWork.PaymentAgentCode;
                    //    dr[DCKAK02525EA.Col_AgentNm] = paymainResWork.PaymentAgentName;
                    //}

                    //// 小計区分を決める
                    //string miniTotal = string.Empty;
                    //switch (paymentMainCndtn.PrintDiv)
                    //{
                    //    case (int)PaymentMainCndtn.PrintDivState.GrandTotal:			// 総合計
                    //    case (int)PaymentMainCndtn.PrintDivState.KindTotal:		        // 金種
                    //    {
                    //        miniTotal = string.Empty;
                    //        break;
                    //    }
                    //    case (int)PaymentMainCndtn.PrintDivState.Details:		        // 詳細

                    //    case (int)PaymentMainCndtn.PrintDivState.Simple:				// 簡易
                    //        {
                    //            // 小計区分で改ページ条件を選択
                    //            switch (paymentMainCndtn.SumDiv)
                    //            {
                    //                case PaymentMainCndtn.SumDivState.Day:				// 日計
                    //                    miniTotal = TDateTime.DateTimeToLongDate(paymainResWork.AddUpADate).ToString();
                    //                    break;
                    //                case PaymentMainCndtn.SumDivState.Payee:			// 支払先計
                    //                    //miniTotal = paymainResWork.CustomerCode.ToString();  // DEL 2008/08/05
                    //                    miniTotal = paymainResWork.SupplierCd.ToString();      // ADD 2008/08/05
                    //                    break;
                    //                case PaymentMainCndtn.SumDivState.PaymentKind:		// 金種計
                    //                    //miniTotal = paymainResWork.PaymentMoneyKindCode.ToString();  // DEL 2008/08/05
                    //                    break;
                    //                case PaymentMainCndtn.SumDivState.PaymentSlipNo:	// 支払番号
                    //                    miniTotal = string.Empty;	// 支払番号のときは小計を表示しない。
                    //                    break;
                    //                default:
                    //                    miniTotal = string.Empty;
                    //                    break;
                    //            }
                    //            break;
                    //        }
                    //    default:
                    //        miniTotal = string.Empty;
                    //        break;
                    //}
                    //dr[DCKAK02525EA.Col_MiniTotal_KeyBleak] = miniTotal;
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    dr[DCKAK02525EA.Col_MiniTotal_KeyBleak] = string.Empty;  // ADD 2008/08/05

                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    //// 現金
                    //dr[DCKAK02525EA.Col_Cash] = paymainResWork.CashPayment;
                    //// 小切手
                    //dr[DCKAK02525EA.Col_Check] = paymainResWork.CheckPayment;
                    //// 振込
                    //dr[DCKAK02525EA.Col_Remittance] = paymainResWork.TransferPayment;
                    //// 手形
                    //dr[DCKAK02525EA.Col_Bill] = paymainResWork.DraftPayment;
                    //// 先付小切手
                    //dr[DCKAK02525EA.Col_ABill] = paymainResWork.FutureCheckPayment;
                    //// 相殺
                    //dr[DCKAK02525EA.Col_Offset] = paymainResWork.OffsetPayment;
                    //// その他
                    //dr[DCKAK02525EA.Col_Others] = paymainResWork.OtherPayment;
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    // 手数料
                    dr[DCKAK02525EA.Col_Fee] = paymainResWork.FeePayment;

                    // 値引
                    dr[DCKAK02525EA.Col_Discount] = paymainResWork.DiscountPayment;

                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    // 有効期限
                    if (paymainResWork.MoneyKindDiv == 105)
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        validityTerm_Tmp = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.ValidityTerm);
                        dr[DCKAK02525EA.Col_ValidityTerm] = validityTerm_Tmp;
                    }
                    else
                    {
                        // 金種区分が「手形」以外の場合は空文字を設定
                        validityTerm_Tmp = "";
                    }

                    // 支払計
                    paymentTotal = paymainResWork.PaymentTotal;
                    // 支払金額
                    payment = paymainResWork.Payment;
                    // 手数料支払額
                    feePayment = paymainResWork.FeePayment;
                    // 値引支払額
                    discountPayment = paymainResWork.DiscountPayment;

                    // 伝票番号控えに取得伝票番号を設定
                    paymentSlipNo_Tmp = paymainResWork.PaymentSlipNo;

                    // 支払設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicPaymentStRowNo.ContainsKey(paymainResWork.MoneyKindCode))
                    {
                        // 金種コードから支払設定マスタの金種コード行番号を取得
                        int paymentKindRowNo = stc_dicPaymentStRowNo[paymainResWork.MoneyKindCode] - 1;
                        paymentDtl[paymentKindRowNo] = paymainResWork.PaymentMei;
                    }
                    // --- ADD 2008/08/05 --------------------------------<<<<< 
                }
                else
                {
                    // 支払先コードが同じ場合

                    // 有効期限
                    if ((validityTerm_Tmp == "") && (paymainResWork.MoneyKindDiv == 105))
                    {
                        // 金種区分が「手形」の場合は、有効期限を設定する
                        validityTerm_Tmp = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, paymainResWork.ValidityTerm);
                        dr[DCKAK02525EA.Col_ValidityTerm] = validityTerm_Tmp;
                    }

                    if (paymentSlipNo_Tmp != paymainResWork.PaymentSlipNo)
                    {
                        // 伝票番号が異なる場合、金額の一時計算プロパティ値に加算
                        // 支払計
                        paymentTotal += paymainResWork.PaymentTotal;
                        // 支払金額
                        payment += paymainResWork.Payment;
                        // 手数料支払額
                        feePayment += paymainResWork.FeePayment;
                        // 値引支払額
                        discountPayment += paymainResWork.DiscountPayment;

                        // 伝票番号控えに取得伝票番号を設定
                        paymentSlipNo_Tmp = paymainResWork.PaymentSlipNo;
                    }

                    // 入金設定マスタの金種コードに一致しない金種コードは設定しない
                    if (stc_dicPaymentStRowNo.ContainsKey(paymainResWork.MoneyKindCode))
                    {
                        // 金種コードから入金設定マスタの金種コード行番号を取得
                        int paymentKindRowNo = stc_dicPaymentStRowNo[paymainResWork.MoneyKindCode] - 1;
                        paymentDtl[paymentKindRowNo] += paymainResWork.PaymentMei;
                    }
                }
            }

            // 最終レコードの金額の一時計算プロパティの値を設定
            // 金額の一時計算プロパティの値を設定
            // 支払計
            dr[DCKAK02525EA.Col_PaymentTotal] = paymentTotal;
            // 支払金額
            dr[DCKAK02525EA.Col_Payment] = payment;
            // 手数料支払額
            dr[DCKAK02525EA.Col_FeePayment] = feePayment;
            // 値引支払額
            dr[DCKAK02525EA.Col_DiscountPayment] = discountPayment;

            // 金種毎の金額を設定
            dr[DCKAK02525EA.Col_PaymentKind_No1] = paymentDtl[0];   // 金種1
            dr[DCKAK02525EA.Col_PaymentKind_No2] = paymentDtl[1];   // 金種2
            dr[DCKAK02525EA.Col_PaymentKind_No3] = paymentDtl[2];   // 金種3
            dr[DCKAK02525EA.Col_PaymentKind_No4] = paymentDtl[3];   // 金種4
            dr[DCKAK02525EA.Col_PaymentKind_No5] = paymentDtl[4];   // 金種5
            dr[DCKAK02525EA.Col_PaymentKind_No6] = paymentDtl[5];   // 金種6
            dr[DCKAK02525EA.Col_PaymentKind_No7] = paymentDtl[6];   // 金種7
            dr[DCKAK02525EA.Col_PaymentKind_No8] = paymentDtl[7];   // 金種8
            dr[DCKAK02525EA.Col_PaymentKind_No9] = paymentDtl[8];   // 金種9
            dr[DCKAK02525EA.Col_PaymentKind_No10] = paymentDtl[9];  // 金種10

            // 金種計
            dr[DCKAK02525EA.Col_PayKindTotal] = paymentDtl[0] + paymentDtl[1] + paymentDtl[2] + paymentDtl[3] + paymentDtl[4] +
                                                paymentDtl[5] + paymentDtl[6] + paymentDtl[7] + paymentDtl[8] + paymentDtl[9];

            // --- DEL 2008/08/05 -------------------------------->>>>>
            // 金種計
            //dr[DCKAK02525EA.Col_PayKindTotal] = paymainResWork.CashPayment + paymainResWork.CheckPayment + paymainResWork.TransferPayment + paymainResWork.DraftPayment +
            //                                    paymainResWork.FutureCheckPayment + paymainResWork.OffsetPayment + paymainResWork.OtherPayment + paymainResWork.FeePayment + paymainResWork.DiscountPayment;
            // --- DEL 2008/08/05 --------------------------------<<<<< 

                    #endregion

            // TableにAdd
            paymentMainDt.Rows.Add(dr);
        }
        #endregion

		#endregion ◆ データ展開処理

		#region ◆ 固定項目名称設定
		#region ◎ 赤黒区分名称取得
		/// <summary>
		/// 赤黒区分名称取得
		/// </summary>
		/// <param name="paymentDebitNoteCd">赤黒区分コード</param>
		/// <param name="dNName">赤黒区分名称</param>
		/// <param name="dNSign">赤黒区分記号</param>
		/// <remarks>
		/// <br>Note       : 赤黒区分名称と記号を取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private void GetDebitNoteCdName ( int paymentDebitNoteCd, out string dNName, out string dNSign )
		{
			dNName = "";
			dNSign = "";

			// 名称と記号をセット
			if ( paymentDebitNoteCd == 0 )
			{
				dNName = "黒伝";
				dNSign = "";
			}
			else if ( paymentDebitNoteCd == 1 )
			{
				dNName = "赤伝";
				dNSign = "▲";
			}
			else if ( paymentDebitNoteCd == 2 )
			{
				dNName = "元黒";
				dNSign = "●";
			}
		}
		#endregion

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

                    // DEL 2008/10/06 不具合対応[5865]---------->>>>>
                    //foreach (MoneyKind moneyKind in workList)
                    //{
                    //    // 指定された金額設定区分のみ格納
                    //    if (moneyKind.PriceStCode == priceStCode)
                    //    {
                    //        retList.Add(moneyKind.MoneyKindCode, moneyKind.Clone());    // HACK:
                    //        stc_paymentKindSortList.Add(moneyKind.MoneyKindCode, moneyKind.Clone());
                    //    }
                    //}
                    // DEL 2008/10/06 不具合対応[5865]----------<<<<<
                    // ADD 2008/10/06 不具合対応[5865]---------->>>>>
                    PaymentSet paymentSet = GetPaymentSet();
                    if (paymentSet != null)
                    {
                        const int INVALID_MONEY_KIND_CODE = 0;

                        // 支払設定金種コード1
                        if (paymentSet.PayStMoneyKindCd1 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd1, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd1).Clone());
                        }
                        // 支払設定金種コード2
                        if (paymentSet.PayStMoneyKindCd2 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd2, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd2).Clone());
                        }
                        // 支払設定金種コード3
                        if (paymentSet.PayStMoneyKindCd3 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd3, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd3).Clone());
                        }
                        // 支払設定金種コード4
                        if (paymentSet.PayStMoneyKindCd4 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd4, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd4).Clone());
                        }
                        // 支払設定金種コード5
                        if (paymentSet.PayStMoneyKindCd5 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd5, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd5).Clone());
                        }
                        // 支払設定金種コード6
                        if (paymentSet.PayStMoneyKindCd6 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd6, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd6).Clone());
                        }
                        // 支払設定金種コード7
                        if (paymentSet.PayStMoneyKindCd7 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd7, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd7).Clone());
                        }
                        // 支払設定金種コード8
                        if (paymentSet.PayStMoneyKindCd8 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd8, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd8).Clone());
                        }
                        // 支払設定金種コード9
                        if (paymentSet.PayStMoneyKindCd9 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd9, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd9).Clone());
                        }
                        // 支払設定金種コード10
                        if (paymentSet.PayStMoneyKindCd10 > INVALID_MONEY_KIND_CODE)
                        {
                            retList.Add(paymentSet.PayStMoneyKindCd10, FindMoneyKind(workList, paymentSet.PayStMoneyKindCd10).Clone());
                        }

                        // 全金種情報を保持(※これが無いと表示されない)
                        stc_paymentKindSortList = retList;        //ADD 2008/11/12
                    }
                    // ADD 2008/10/06 不具合対応[5865]----------<<<<<
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

        /// <summary>
        /// 該当する金種設定を検索します。
        /// </summary>
        /// <remarks>
        /// 該当する金種設定がない場合、nullを返します。
        /// </remarks>
        /// <param name="moneyKindList">金種設定リスト</param>
        /// <param name="moneyKindCode">金種コード</param>
        /// <returns>該当する金種設定</returns>
        private static MoneyKind FindMoneyKind(
            ArrayList moneyKindList,
            int moneyKindCode
        )
        {
            foreach (MoneyKind moneyKind in moneyKindList)
            {
                if (moneyKind.MoneyKindCode.Equals(moneyKindCode)) return moneyKind;
            }
            return null;
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
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.09.10</br>
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
							retPrtOutSet = stc_PrtOutSet.Clone();	
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

        /// <summary>
        /// 支払設定マスタ金種名称取得
        /// </summary>
        /// <param name="dicKindName">金種名称</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 支払設定マスタから金種コードを取得</br>
        /// <br>Programmer	: 30415 柴田 倫幸</br>
        /// <br>Date		: 2008/08/05</br>
        /// </remarks>
        private int GetKindName(out Dictionary<int, string> dicKindName)
        {
            int index = 0;
            dicKindName = new Dictionary<int, string>();

            if (stc_dicPaymentStRowNo.Count == 0)
            {
                GetPaymentSet();
            }

            for (int i = 1; i <= stc_dicPaymentStKindCd.Count; i++)
            {
                if (stc_dicPaymentStKindCd.ContainsKey(i))
                {
                    int key = stc_dicPaymentStKindCd[i];
                    if (stc_paymentKindSortList.ContainsKey(key))
                    {
                        MoneyKind moneyKind = (MoneyKind)stc_paymentKindSortList[key];
                        dicKindName.Add(index, moneyKind.MoneyKindName);
                        index++;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 支払設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払設定マスタを取得します。</br>
        /// <br>Programmer	: 30415 柴田 倫幸</br>
        /// <br>Date		: 2008/08/05</br>
        /// </remarks>
        /// <returns>支払設定マスタのレコード（単一）</returns>
        private PaymentSet GetPaymentSet()  // MOD 2008/10/06 不具合対応[5865] void→PaymentSet
        {
            int status;
            int listIndex = 1;
            PaymentSet paymentSet = new PaymentSet();

            status = this._paymentSetAcs.Read(out paymentSet, LoginInfoAcquisition.EnterpriseCode, 0);
            if (status == 0)
            {
                stc_dicPaymentStRowNo = new Dictionary<int, int>();
                stc_dicPaymentStKindCd = new Dictionary<int, int>();

                if ((paymentSet.PayStMoneyKindCd1 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd1)))
                {
                    // 入金設定金種コード１の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd1, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd1);
                    listIndex++;
                       --- DEL 2008/11/12 ---------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd1))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd1, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd1);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd2 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd2)))
                {
                    // 入金設定金種コード２の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd2, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd2);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd2))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd2, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd2);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd3 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd3)))
                {
                    // 入金設定金種コード３の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd3, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd3);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd3))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd3, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd3);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd4 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd4)))
                {
                    // 入金設定金種コード４の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd4, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd4);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd4))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd4, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd4);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd5 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd5)))
                {
                    // 入金設定金種コード５の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd5, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd5);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd5))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd5, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd5);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd6 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd6)))
                {
                    // 入金設定金種コード６の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd6, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd6);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd6))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd6, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd6);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd7 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd7)))
                {
                    // 入金設定金種コード７の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd7, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd7);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd7))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd7, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd7);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd8 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd8)))
                {
                    // 入金設定金種コード８の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd8, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd8);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd8))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd8, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd8);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd9 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd9)))
                {
                    // 入金設定金種コード９の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd9, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd9);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd9))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd9, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd9);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                if ((paymentSet.PayStMoneyKindCd10 != 0) &&
                    (stc_paymentKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd10)))
                {
                    // 入金設定金種コード１０の追加
                    /* --- DEL 2008/11/12 画面で選択されたものだけ追加する為 ---------->>>>>
                    stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd10, listIndex);
                    stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd10);
                    listIndex++;
                      --- DEL 2008/11/12 ----------------------------------------------<<<<< */
                    // --- ADD 2008/11/12 --------------------------------------------->>>>>
                    if (stc_cndtnKindSortList.ContainsKey(paymentSet.PayStMoneyKindCd10))
                    {
                        stc_dicPaymentStRowNo.Add(paymentSet.PayStMoneyKindCd10, listIndex);
                        stc_dicPaymentStKindCd.Add(listIndex, paymentSet.PayStMoneyKindCd10);
                        listIndex++;
                    }
                    // --- ADD 2008/11/12 ---------------------------------------------<<<<<
                }

                return paymentSet;  // ADD 2008/10/06 不具合対応[5865]
            }

            stc_dicPaymentStRowNo = new Dictionary<int, int>();

            return null;            // ADD 2008/10/06 不具合対応[5865]
        }

		#endregion ◆ 帳票設定データ取得

        // --- ADD 2012/10/03 ---------->>>>>
        #region ■オプション情報制御処理

        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/10/03</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●仕入総括機能（個別）オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optSuppEnable = true;
            }
            else
            {
                this._optSuppEnable = false;
            }
            #endregion
        }
        #endregion ■オプション情報制御処理
        // --- ADD 2012/10/03 ----------<<<<<
        #endregion ■ Private Method
	}
}
