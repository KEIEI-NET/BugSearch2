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
    /// 掛率マスタ印刷アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 掛率マスタ印刷で使用するデータを取得する。</br>
    /// <br>Programmer   : 30462 行澤 仁美</br>
    /// <br>Date         : 2008.10.15</br>
    /// <br>Note         : MANTIS対応[14974]：拠点00：全社設定を印字</br>
    /// <br>Programmer   : 30434 工藤 恵優</br>
    /// <br>Date         : 2010/02/05</br>
    /// <br>Update Note  :連番 800  zhouyu </br>
    /// <br>Date         : 2011/07/22 </br>
    /// <br>Update Note : 2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
    /// <br>              ユーザー価格指定を追加する</br>
    /// <br>Update Note : 2012/11/19 鄧潘ハン</br>
    /// <br>管理番号    : 10801804-00 2013/01/16配信分</br>
    /// <br>              Redmine#31734　掛率マスタ印刷不具合の修正</br>
    /// </remarks>
	public class RateReportAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 掛率マスタ印刷アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 掛率マスタ印刷アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
		/// </remarks>
		public RateReportAcs()
		{
            this._iRatePrtDB = (IRatePrtDB)MediationRatePrtDB.GetRatePrtDB();

            this._iOfferPartsInfo = (IOfferPartsInfo)MediationOfferPartsInfo.GetOfferPartsInfo(); // ADD 2011/07/22
		}

		/// <summary>
        /// 掛率マスタ印刷アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 掛率マスタ印刷アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
		/// </remarks>
        static RateReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary
            stc_GoodsAcs = new GoodsAcs();              // 商品アクセスクラス
            
            Employee loginWorker = null;
            string ownSectionCode = "";
            string msg;

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }

            stc_GoodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, ownSectionCode, out msg);

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList ) {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey(secInfoSet.SectionCode) ) {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			                // 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	                // 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        private static GoodsAcs stc_GoodsAcs;                           // 商品アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
        IRatePrtDB _iRatePrtDB;

        IOfferPartsInfo _iOfferPartsInfo;  // ADD 2011/07/22

        private DataTable _rateShipmentListDt;			// 印刷DataTable
        private DataView _rateShipmentListDataView;	    // 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView ReatShipmentListDataView
		{
            get { return this._rateShipmentListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
        /// <param name="ratePrtReqCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
		/// </remarks>
        public int SearchMain(RatePrtReqCndtn ratePrtReqCndtn, out string errMsg)
		{
            return this.SearchProc(ratePrtReqCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 在庫移動データ取得
		/// <summary>
		/// 在庫移動データ取得
		/// </summary>
        /// <param name="reatShipmentListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
		/// </remarks>
        private int SearchProc(RatePrtReqCndtn reatShipmentListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMKHN02019EA.CreateDataTable(ref this._rateShipmentListDt);

                RatePrtReqWork ratePrtReqWork = new RatePrtReqWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevReatCndtn(reatShipmentListCndtn, out ratePrtReqWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retReatList = null;

                if(reatShipmentListCndtn.LogicalDeleteCode.Equals(1)){
                    status = this._iRatePrtDB.Search(out retReatList, ratePrtReqWork, ConstantManagement.LogicalMode.GetData0);
                }
                else if (reatShipmentListCndtn.LogicalDeleteCode.Equals(2))
                {
                    status = this._iRatePrtDB.Search(out retReatList, ratePrtReqWork, ConstantManagement.LogicalMode.GetData1);
                }
                else if (reatShipmentListCndtn.LogicalDeleteCode.Equals(3))
                {
                    status = this._iRatePrtDB.Search(out retReatList, ratePrtReqWork, ConstantManagement.LogicalMode.GetData01);
                }
                
                //--- TEST --------->>>>>
                //retReatList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
                        DevReatData(reatShipmentListCndtn, (ArrayList)retReatList);

                        if (this._rateShipmentListDataView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "掛率マスタデータの取得に失敗しました。";
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
		#endregion ◆ 帳票データ取得

        # region テスト用

        private object GetTestData()
        {
            ArrayList list = new ArrayList();

            RatePrtRstWork work = new RatePrtRstWork();

            work.BLGoodsCode = 0;
            work.BLGoodsHalfName = "";
            work.BLGroupCode = 0;
            work.BLGroupKanaName = "";
            work.CstPriceFl = 0;
            work.CstRateVal = 0;
            work.CustomerCode = 0;
            work.CustomerSnm = "";
            work.CustRateGrpCode = 0;
            work.GoodsMakerCd = 0;
            work.GoodsNameKana = "";
            work.GoodsNo = "";
            work.GoodsRateGrpCode = 0; 
            work.GoodsRateRank = "";
            work.LogicalDeleteCode = 0; 
            work.LotCount = 0;
            work.MakerShortName = "";
            work.PrcPriceFl = 0;
            work.PrcUpRate = 0;
            work.RateSettingDivide = "";
            work.SalPriceFl = 0;
            work.SalRateVal = 0;
            work.SalUpRate = 0;
            work.SectionCode = "";
            work.SectionGuideSnm = "";
            work.SupplierCd = 0;
            work.SupplierSnm = "";
            work.UnitPriceKind = "";
            work.UnPrcFracProcDiv = 0; 
            work.UnPrcFracProcUnit = 0; 


            list.Add(work);

            

            

            return (object)list;
        }

        # endregion

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
        /// <param name="ratePrtReqCndtn">UI抽出条件クラス</param>
        /// <param name="ratePrtReqWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevReatCndtn(RatePrtReqCndtn ratePrtReqCndtn, out RatePrtReqWork ratePrtReqWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            ratePrtReqWork = new RatePrtReqWork();
			try
			{
                ratePrtReqWork.EnterpriseCode = ratePrtReqCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
                if (ratePrtReqCndtn.SectionCodes.Length != 0)
				{
                    if (ratePrtReqCndtn.IsSelectAllSection)
				    {
				        // 全社の時
                        ratePrtReqWork.SectionCode = null;
				    }
				    else
				    {
                        ratePrtReqWork.SectionCode = ratePrtReqCndtn.SectionCodes;
				    }
				}
				else
				{
                    ratePrtReqWork.SectionCode = null;
				}

                ratePrtReqWork.BLGoodsCodeEd = ratePrtReqCndtn.BLGoodsCodeEd;
                ratePrtReqWork.BLGoodsCodeSt = ratePrtReqCndtn.BLGoodsCodeSt;
                ratePrtReqWork.BLGroupCodeEd = ratePrtReqCndtn.BLGroupCodeEd;
                ratePrtReqWork.BLGroupCodeSt = ratePrtReqCndtn.BLGroupCodeSt;
                ratePrtReqWork.CustomerCodeEd = ratePrtReqCndtn.CustomerCodeEd;
                ratePrtReqWork.CustomerCodeSt = ratePrtReqCndtn.CustomerCodeSt;
                ratePrtReqWork.CustRateGrpCodeEd = ratePrtReqCndtn.CustRateGrpCodeEd;
                ratePrtReqWork.CustRateGrpCodeSt = ratePrtReqCndtn.CustRateGrpCodeSt;
                ratePrtReqWork.EnterpriseCode = ratePrtReqCndtn.EnterpriseCode;
                ratePrtReqWork.GoodsMakerCdEd = ratePrtReqCndtn.GoodsMakerCdEd;
                ratePrtReqWork.GoodsMakerCdSt = ratePrtReqCndtn.GoodsMakerCdSt;
                ratePrtReqWork.GoodsNoEd = ratePrtReqCndtn.GoodsNoEd;
                ratePrtReqWork.GoodsNoSt = ratePrtReqCndtn.GoodsNoSt;
                ratePrtReqWork.GoodsRateGrpCodeEd = ratePrtReqCndtn.GoodsRateGrpCodeEd;
                ratePrtReqWork.GoodsRateGrpCodeSt = ratePrtReqCndtn.GoodsRateGrpCodeSt;
                ratePrtReqWork.GoodsRateRankEd = ratePrtReqCndtn.GoodsRateRankEd;
                ratePrtReqWork.GoodsRateRankSt = ratePrtReqCndtn.GoodsRateRankSt;
                ratePrtReqWork.RateSettingDivideEd = ratePrtReqCndtn.RateSettingDivideEd;
                ratePrtReqWork.RateSettingDivideSt = ratePrtReqCndtn.RateSettingDivideSt;
                
                ratePrtReqWork.SupplierCdEd = ratePrtReqCndtn.SupplierCdEd;
                ratePrtReqWork.SupplierCdSt = ratePrtReqCndtn.SupplierCdSt;
                ratePrtReqWork.UnitPriceKind = ratePrtReqCndtn.UnitPriceKind;
                ratePrtReqWork.RateMngGoodsCdKind = ratePrtReqCndtn.RateMngGoodsCdKind;

            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
        /// <param name="ratePrtReqCndtn">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.07.17</br>
        /// <br>Update Note: 2011/07/22 李占川 NSユーザー改良要望一覧の連番898の対応</br>
        /// <br>             ユーザー価格指定を追加する</br>
		/// </remarks>
        private void DevReatData(RatePrtReqCndtn ratePrtReqCndtn, ArrayList retaWork)
		{
			DataRow dr;

            // --- ADD 2011/07/22 ---------->>>>>
            if (ratePrtReqCndtn.UnitPriceKind == 3 && ratePrtReqCndtn.RateMngGoodsCdKind == 0)
            {
                this.MergerPrice(ref retaWork);
            }
            // --- ADD 22011/07/22  ----------<<<<<
            foreach (RatePrtRstWork ratePrtRstWork in retaWork)
            {
                // --- ADD 2011/07/22 ---------->>>>>
                double price = 0;
                if (ratePrtReqCndtn.UnitPriceKind == 3 && ratePrtReqCndtn.RateMngGoodsCdKind == 0)
                {
                    // 価格の取得
                    price = ratePrtRstWork.Price;

                    // ユーザー価格指定：商品マスタ価格＞ユーザー価格
                    if (ratePrtReqCndtn.UserPriceAppoint == 2
                        && price <= ratePrtRstWork.PrcPriceFl)
                    {
                        continue;
                    }

                    // ユーザー価格指定：商品マスタ価格＝ユーザー価格
                    if (ratePrtReqCndtn.UserPriceAppoint == 3
                        && price != ratePrtRstWork.PrcPriceFl)
                    {
                        continue;
                    }
                }
                // --- ADD 2011/07/22  ----------<<<<<

                // ADD 2010/02/05 MANTIS対応[14974]：拠点00：全社設定を印字 ---------->>>>>
                // 拠点00：全社設定の補正
                if (ratePrtRstWork.SectionCode.Trim().Equals("00") && string.IsNullOrEmpty(ratePrtRstWork.SectionGuideSnm.Trim()))
                {
                    ratePrtRstWork.SectionGuideSnm = "全社設定";
                }
                // ADD 2010/02/05 MANTIS対応[14974]：拠点00：全社設定を印字 ----------<<<<<

                dr = this._rateShipmentListDt.NewRow();
                // 取得データ展開
                #region 取得データ展開

                dr[PMKHN02019EA.ct_Col_SectionCode] = ratePrtRstWork.SectionCode;	                        // 拠点コード
                dr[PMKHN02019EA.ct_Col_SectionGuideSnm] = ratePrtRstWork.SectionGuideSnm;	                // 拠点ガイド略称
                dr[PMKHN02019EA.ct_Col_RateSettingDivide] = ratePrtRstWork.RateSettingDivide;	            // 掛率設定区分
                dr[PMKHN02019EA.ct_Col_LogicalDeleteCode] = ratePrtRstWork.LogicalDeleteCode;	            // 論理削除区分
                dr[PMKHN02019EA.ct_Col_CustomerCode] = ratePrtRstWork.CustomerCode;	                        // 得意先コード
                dr[PMKHN02019EA.ct_Col_CustomerSnm] = ratePrtRstWork.CustomerSnm;	                        // 得意先略称
                dr[PMKHN02019EA.ct_Col_CustRateGrpCode] = ratePrtRstWork.CustRateGrpCode;	                // 得意先掛率グループコード
                dr[PMKHN02019EA.ct_Col_SupplierCd] = ratePrtRstWork.SupplierCd;	                            // 仕入先コード
                dr[PMKHN02019EA.ct_Col_SupplierSnm] = ratePrtRstWork.SupplierSnm;	                        // 仕入先略称
                dr[PMKHN02019EA.ct_Col_GoodsMakerCd] = ratePrtRstWork.GoodsMakerCd;	                        // 商品メーカーコード
                dr[PMKHN02019EA.ct_Col_MakerShortName] = ratePrtRstWork.MakerShortName;	                    // メーカー略称
                dr[PMKHN02019EA.ct_Col_GoodsRateRank] = ratePrtRstWork.GoodsRateRank;	                    // 商品掛率ランク
                dr[PMKHN02019EA.ct_Col_GoodsRateGrpCode] = ratePrtRstWork.GoodsRateGrpCode;	                // 商品掛率グループコード
                dr[PMKHN02019EA.ct_Col_BLGroupCode] = ratePrtRstWork.BLGroupCode;	                        // BLグループコード
                dr[PMKHN02019EA.ct_Col_BLGroupKanaName] = ratePrtRstWork.BLGroupKanaName;	                // BLグループコードカナ名称
                dr[PMKHN02019EA.ct_Col_BLGoodsCode] = ratePrtRstWork.BLGoodsCode;	                        // BL商品コード
                dr[PMKHN02019EA.ct_Col_BLGoodsHalfName] = ratePrtRstWork.BLGoodsHalfName;	                // BL商品コード名称（半角）
                dr[PMKHN02019EA.ct_Col_GoodsNo] = ratePrtRstWork.GoodsNo;	                                // 商品番号
                dr[PMKHN02019EA.ct_Col_GoodsNameKana] = ratePrtRstWork.GoodsNameKana;	                    // 商品名称カナ
                dr[PMKHN02019EA.ct_Col_LotCount] = ratePrtRstWork.LotCount;	                                // 上限
                dr[PMKHN02019EA.ct_Col_SalRateVal] = ratePrtRstWork.SalRateVal;	                            // 売価率
                dr[PMKHN02019EA.ct_Col_SalPriceFl] = ratePrtRstWork.SalPriceFl;	                            // 売価額
                dr[PMKHN02019EA.ct_Col_SalUpRate] = ratePrtRstWork.SalUpRate;	                            // 原価UP率
                dr[PMKHN02019EA.ct_Col_GrsProfitSecureRate] = ratePrtRstWork.GrsProfitSecureRate;           // 粗利確保率
                dr[PMKHN02019EA.ct_Col_CstRateVal] = ratePrtRstWork.CstRateVal;	                            // 仕入率
                dr[PMKHN02019EA.ct_Col_CstPriceFl] = ratePrtRstWork.CstPriceFl;	                            // 仕入原価
                dr[PMKHN02019EA.ct_Col_PrcPriceFl] = ratePrtRstWork.PrcPriceFl;	                            // ユーザー価格
                dr[PMKHN02019EA.ct_Col_Price] = ratePrtRstWork.Price;	                                    // 価格  // ADD 2011/07/22
                dr[PMKHN02019EA.ct_Col_PrcUpRate] = ratePrtRstWork.PrcUpRate;	                            // 価格UP率
                dr[PMKHN02019EA.ct_Col_UnPrcFracProcUnit] = ratePrtRstWork.UnPrcFracProcUnit;	            // 単価端数処理単位
                dr[PMKHN02019EA.ct_Col_UnPrcFracProcDiv] = ratePrtRstWork.UnPrcFracProcDiv;	                // 単価端数処理区分
                dr[PMKHN02019EA.ct_Col_UnitPriceKind] = ratePrtRstWork.UnitPriceKind;	                    // 単価種類
                dr[PMKHN02019EA.ct_Col_Sort_SectionCode] = ratePrtRstWork.SectionCode;                      // ソート用拠点コード
                dr[PMKHN02019EA.ct_Col_Sort_LogicalDeleteCode] = ratePrtRstWork.LogicalDeleteCode;          // ソート用論理削除区分
                dr[PMKHN02019EA.ct_Col_Sort_ct_Col_RateSettingDivide] = ratePrtRstWork.RateSettingDivide;	// ソート用掛率設定区分
                dr[PMKHN02019EA.ct_Col_Sort_CustomerCode] = ratePrtRstWork.CustomerCode;	                // ソート用得意先コード
                dr[PMKHN02019EA.ct_Col_Sort_CustRateGrpCode] = ratePrtRstWork.CustRateGrpCode;	            // ソート用得意先掛率グループコード
                dr[PMKHN02019EA.ct_Col_Sort_SupplierCd] = ratePrtRstWork.SupplierCd;	                    // ソート用仕入先コード
                dr[PMKHN02019EA.ct_Col_Sort_GoodsMakerCd] = ratePrtRstWork.GoodsMakerCd;	                // ソート用商品メーカーコード
                dr[PMKHN02019EA.ct_Col_Sort_GoodsRateRank] = ratePrtRstWork.GoodsRateRank;	                // ソート用商品掛率ランク
                dr[PMKHN02019EA.ct_Col_Sort_GoodsRateGrpCode] = ratePrtRstWork.GoodsRateGrpCode;	        // ソート用商品掛率グループコード
                dr[PMKHN02019EA.ct_Col_Sort_BLGroupCode] = ratePrtRstWork.BLGroupCode;	                    // ソート用BLグループコード
                dr[PMKHN02019EA.ct_Col_Sort_BLGoodsCode] = ratePrtRstWork.BLGoodsCode;	                    // ソート用BL商品コード
                dr[PMKHN02019EA.ct_Col_Sort_LotCount] = ratePrtRstWork.LotCount;	                        // ソート用上限

                #endregion

                // TableにAdd
                this._rateShipmentListDt.Rows.Add(dr);

            }


			// DataView作成
            this._rateShipmentListDataView = new DataView(this._rateShipmentListDt, "", GetSortOrder(ratePrtReqCndtn), DataViewRowState.CurrentRows);
        }

        // --- ADD 2011/07/22 ---------->>>>>
        # region 商品価格処理
        /// <summary>
        /// 商品価格処理
        /// </summary>
        /// <param name="retaWork">取得データ</param>
        /// <remarks>
        /// <br>Note       : 商品価格処理。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 2012/11/19 鄧潘ハン</br>
        /// <br>管理番号   : 10801804-00 2013/01/16配信分</br>
        /// <br>             Redmine#31734　掛率マスタ印刷不具合の修正</br>
        /// </remarks>
        private void MergerPrice(ref ArrayList retaWork)
        {
            ArrayList lstSrchCond = new ArrayList();
            //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
            int nowDateTime = TDateTime.DateTimeToLongDate(DateTime.Today);
            int stDate = 0;
            bool prmPriceFlag = false;
            //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
            foreach (RatePrtRstWork ratePrtRstWork in retaWork)
            {
                // 価格を取得出来なかった
                if (ratePrtRstWork.Price == 0)
                {
                    OfrPrtsSrchCndWork ofrPrtsSrchCndWork = new OfrPrtsSrchCndWork();
                    ofrPrtsSrchCndWork.MakerCode = ratePrtRstWork.GoodsMakerCd; // メーカーコード
                    ofrPrtsSrchCndWork.PrtsNo = ratePrtRstWork.GoodsNo;         // 品番
                    lstSrchCond.Add(ofrPrtsSrchCndWork);
                }
            }

            if (lstSrchCond.Count > 0)
            {
                ArrayList lstRst;
                //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                List<RetPartsInf> lstRsts = new List<RetPartsInf>();
                List<OfferJoinPriceRetWork> lstPrmPrices = new List<OfferJoinPriceRetWork>();
                //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                ArrayList lstRstPrm;
                ArrayList lstPrmPrice;
                // 提供のリモート処理を使用して価格情報を取得する
                int satus = this._iOfferPartsInfo.GetOfrPartsInf(lstSrchCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                if (lstRst != null && lstRst.Count > 0)
                {
                    foreach (RetPartsInf retPartsInf in lstRst)
                    {
                        lstRsts.Add(retPartsInf);
                    }
                    DataAtoComparer salesAData = new DataAtoComparer();
                    lstRsts.Sort(salesAData);

                }
                else
                { 
                    //該当なし。
                }

                if (lstPrmPrice != null && lstPrmPrice.Count > 0)
                {
                    foreach (OfferJoinPriceRetWork offerJoinPriceRetWork in lstPrmPrice)
                    {
                        lstPrmPrices.Add(offerJoinPriceRetWork);
                    }
                    DataBtoComparer salesBData = new DataBtoComparer();
                    lstPrmPrices.Sort(salesBData);
                }
                else
                {
                    //該当なし。
                }
                //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                foreach (RatePrtRstWork ratePrtRstWork in retaWork)
                {
                    prmPriceFlag = false;//ADD　鄧潘ハン　2012/11/19 Redmine31734
                    int goodsMakeCd = ratePrtRstWork.GoodsMakerCd;
                    string goodsNo = ratePrtRstWork.GoodsNo;

                    //foreach (RetPartsInf retPartsInf in lstRst)//DEL　鄧潘ハン　2012/11/19 Redmine31734
                    foreach (RetPartsInf retPartsInf in lstRsts)//ADD　鄧潘ハン　2012/11/19 Redmine31734
                    {
                        if (retPartsInf.CatalogPartsMakerCd == goodsMakeCd
                            && retPartsInf.NewPrtsNoWithHyphen == goodsNo)
                        {
                            //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                            stDate = TDateTime.DateTimeToLongDate(retPartsInf.PartsPriceStDate);
                            if (stDate <= nowDateTime)
                            {
                                ratePrtRstWork.Price = retPartsInf.PartsPrice;
                                ratePrtRstWork.GoodsNameKana = retPartsInf.PartsNameKana;
                                break;
                            }
                            else
                            {
                                //該当なし。
                            }
                            //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                            //---DEL　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                            //ratePrtRstWork.Price = retPartsInf.PartsPrice;
                            //ratePrtRstWork.GoodsNameKana = retPartsInf.PartsNameKana;
                            //break;
                            //---DEL　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                        }
                    }

                    //---DEL　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                    //foreach (OfferJoinPartsRetWork offerJoinPartsRetWork in lstRstPrm)
                    //{
                    //    if (offerJoinPartsRetWork.JoinDestMakerCd == goodsMakeCd
                    //        && offerJoinPartsRetWork.JoinDestPartsNo == goodsNo)
                    //    {
                    //        ratePrtRstWork.GoodsNameKana = offerJoinPartsRetWork.PrimePartsKanaName;
                    //        break;
                    //    }
                    //}
                    //---DEL　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<

                    //foreach (OfferJoinPriceRetWork offerJoinPriceRetWork in lstPrmPrice)//DEL　鄧潘ハン　2012/11/19 Redmine31734
                    foreach (OfferJoinPriceRetWork offerJoinPriceRetWork in lstPrmPrices)//ADD 鄧潘ハン　2012/11/19 Redmine31734
                    {
                        if (offerJoinPriceRetWork.PartsMakerCd == goodsMakeCd
                            && offerJoinPriceRetWork.PrimePartsNoWithH == goodsNo)
                        {
                            //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                            stDate = TDateTime.DateTimeToLongDate(offerJoinPriceRetWork.PriceStartDate);
                            if (stDate <= nowDateTime)
                            {
                                ratePrtRstWork.Price = offerJoinPriceRetWork.NewPrice;
                                prmPriceFlag = true;
                                break;
                            }
                            else
                            {
                                //該当なし。
                            }
                            //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                            //---DEL　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                            //ratePrtRstWork.Price = offerJoinPriceRetWork.NewPrice;
                            //break;
                            //---DEL　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                        }
                    }

                    //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
                    foreach (OfferJoinPartsRetWork offerJoinPartsRetWork in lstRstPrm)
                    {
                        if (offerJoinPartsRetWork.JoinDestMakerCd == goodsMakeCd
                            && offerJoinPartsRetWork.JoinDestPartsNo == goodsNo
                            && prmPriceFlag)
                        {
                            ratePrtRstWork.GoodsNameKana = offerJoinPartsRetWork.PrimePartsKanaName;
                            break;
                        }
                    }
                    //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<
                }
            }
        }
        # endregion
        // --- ADD 2011/07/22  ----------<<<<<

        //---ADD　鄧潘ハン　2012/11/19 Redmine31734--------------------->>>>>
        /// <summary>
        /// データソート順処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データソート順処理</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2012/11/19</br>
        /// <br>管理番号   : 10801804-00 2013/01/16配信分 Redmine#31734　掛率マスタ印刷不具合の修正</br>
        /// </remarks>
        private class DataAtoComparer : IComparer<RetPartsInf>
        {
            public int Compare(RetPartsInf x, RetPartsInf y)
            {
                int a = TDateTime.DateTimeToLongDate(x.PartsPriceStDate);
                int b = TDateTime.DateTimeToLongDate(y.PartsPriceStDate);
                int ret = ComparerHelper.CompareObject(b, a);
                return ret;
            }
        }

        /// <summary>
        /// データソート順処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データソート順処理</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2012/11/19</br>
        /// <br>管理番号   : 10801804-00 2013/01/16配信分 Redmine#31734　掛率マスタ印刷不具合の修正</br>
        /// </remarks>
        private class DataBtoComparer : IComparer<OfferJoinPriceRetWork>
        {
            public int Compare(OfferJoinPriceRetWork x, OfferJoinPriceRetWork y)
            {
                int a = TDateTime.DateTimeToLongDate(x.PriceStartDate);
                int b = TDateTime.DateTimeToLongDate(y.PriceStartDate);
                int ret = ComparerHelper.CompareObject(b, a);
                return ret;
            }
        }

        /// <summary>
        /// Comparer処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : Comparer処理</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2012/11/19</br>
        /// <br>管理番号   : 10801804-00 2013/01/16配信分 Redmine#31734　掛率マスタ印刷不具合の修正</br>
        /// </remarks>
        private class ComparerHelper
        {
            public static int CompareObject(object val1, object val2)
            {
                if (val1 == null && val2 == null)
                {
                    return 0;
                }
                else if (val1 != null && val2 != null)
                {
                    return val1.ToString().CompareTo(val2.ToString());
                }
                else if (val1 != null && val2 == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        //---ADD　鄧潘ハン　2012/11/19 Redmine31734---------------------<<<<<

        /// <summary>
        /// 拠点ガイド名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点ガイド名称</returns>
        private string GetSectionGuideNm ( string sectionCode )
        {
            if ( stc_SectionDic.ContainsKey(sectionCode) ) {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else {
                return string.Empty;
            }
        }
        #endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
        private string GetSortOrder(RatePrtReqCndtn ReatCndtn)
        {
            StringBuilder strSortOrder = new StringBuilder();

            // 拠点コード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_SectionCode));
            // 論理削除区分
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_LogicalDeleteCode));
            // 掛率設定区分
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_ct_Col_RateSettingDivide));
            // 得意先コード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_CustomerCode));
            // 得意先掛率グループコードコード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_CustRateGrpCode));
            // 仕入先コード
            //strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_GoodsMakerCd));  //DEL zhouyu 2011/07/22
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_SupplierCd));      //ADD zhouyu 2011/07/22
            // 商品メーカーコード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_GoodsMakerCd));
            // 商品掛率ランク
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_GoodsRateRank));
            // 商品掛率グループコード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_GoodsRateGrpCode));
            // BLグループコード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_BLGroupCode));
            // BL商品コード
            strSortOrder.Append(string.Format("{0},", PMKHN02019EA.ct_Col_Sort_BLGoodsCode));
            // 上限
            strSortOrder.Append(string.Format("{0}", PMKHN02019EA.ct_Col_Sort_LotCount));

            return strSortOrder.ToString();
        }
		#endregion

		#endregion ◆ データ展開処理

		#region ◆ 帳票設定データ取得
		#region ◎ 帳票出力設定取得処理
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.07.17</br>
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
		#endregion ◆ 帳票設定データ取得
		#endregion ■ Private Method
	}
}
