//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 優良設定マスタ印刷
// プログラム概要   : 優良設定マスタ印刷で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 作 成 日  2008/11/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13068
//----------------------------------------------------------------------------//
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
    /// 優良設定マスタ印刷アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 優良設定マスタ印刷で使用するデータを取得する。</br>
    /// <br>Programmer   : 30462 行澤 仁美</br>
    /// <br>Date         : 2008.11.13</br>
    /// <br>Update Note  : 2009/04/07 30452 上野 俊治</br>
    /// <br>              ・障害対応13068</br>
	/// <br>             : </br>
    /// </remarks>
	public class PrmSettingReportAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 優良設定マスタ印刷アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 優良設定マスタ印刷アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.13</br>
		/// </remarks>
		public PrmSettingReportAcs()
		{
            this._iPrmSettingPrintOrderWorkDB = (IPrmSettingPrintOrderWorkDB)MediationPrmSettingPrintOrderWorkDB.GetPrmSettingPrintOrderWorkDB();
		}

		/// <summary>
        /// 優良設定マスタ印刷アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 優良設定マスタ印刷アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.13</br>
		/// </remarks>
        static PrmSettingReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary
            
            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


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
		#endregion ■ Static Member

		#region ■ Private Member
        IPrmSettingPrintOrderWorkDB _iPrmSettingPrintOrderWorkDB;

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
        /// <param name="prmSettingPrintOrderCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.13</br>
		/// </remarks>
        public int SearchMain(PrmSettingPrintOrderCndtn prmSettingPrintOrderCndtn, out string errMsg)
		{
            return this.SearchProc(prmSettingPrintOrderCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 優良設定データ取得
		/// <summary>
		/// 優良設定データ取得
		/// </summary>
        /// <param name="prmSettingPrintOrderCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する優良設定データを取得する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.13</br>
		/// </remarks>
        private int SearchProc(PrmSettingPrintOrderCndtn prmSettingPrintOrderCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMKEN02015EA.CreateDataTable(ref this._rateShipmentListDt);

                PrmSettingPrintOrderCndtnWork prmSettingPrintOrderCndtnWork = new PrmSettingPrintOrderCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevReatCndtn(prmSettingPrintOrderCndtn, out prmSettingPrintOrderCndtnWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retReatList = null;

                status = this._iPrmSettingPrintOrderWorkDB.Search(out retReatList, prmSettingPrintOrderCndtnWork,0, ConstantManagement.LogicalMode.GetData0);

                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
                        DevReatData(prmSettingPrintOrderCndtn, (ArrayList)retReatList);

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
						errMsg = "優良設定マスタデータの取得に失敗しました。";
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

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
        /// <param name="prmSettingPrintOrderCndtn">UI抽出条件クラス</param>
        /// <param name="prmSettingPrintOrderCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevReatCndtn(PrmSettingPrintOrderCndtn prmSettingPrintOrderCndtn, out PrmSettingPrintOrderCndtnWork prmSettingPrintOrderCndtnWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            prmSettingPrintOrderCndtnWork = new PrmSettingPrintOrderCndtnWork();
			try
			{
                prmSettingPrintOrderCndtnWork.EnterpriseCode = prmSettingPrintOrderCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
                if (prmSettingPrintOrderCndtn.SectionCodes.Length != 0)
				{
                    if (prmSettingPrintOrderCndtn.IsSelectAllSection)
				    {
				        // 全社の時
                        prmSettingPrintOrderCndtnWork.SectionCodes = null;
				    }
				    else
				    {
                        prmSettingPrintOrderCndtnWork.SectionCodes = prmSettingPrintOrderCndtn.SectionCodes;
				    }
				}
				else
				{
                    prmSettingPrintOrderCndtnWork.SectionCodes = null;
				}

                prmSettingPrintOrderCndtnWork.St_GoodsMGroup = prmSettingPrintOrderCndtn.St_GoodsMGroup;
                if (prmSettingPrintOrderCndtn.Ed_GoodsMGroup == 0)
                {
                    prmSettingPrintOrderCndtnWork.Ed_GoodsMGroup = 9999;
                }
                else
                {
                    prmSettingPrintOrderCndtnWork.Ed_GoodsMGroup = prmSettingPrintOrderCndtn.Ed_GoodsMGroup;
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

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
        /// <param name="prmSettingPrintOrderCndtn">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.07.17</br>
		/// </remarks>
        private void DevReatData(PrmSettingPrintOrderCndtn prmSettingPrintOrderCndtn, ArrayList retaWork)
		{
			DataRow dr;

            foreach (PrmSettingPrintResultWork prmSettingPrintResultWork in retaWork)
            {
                if (prmSettingPrintResultWork.TbsPartsCode.Equals(0)) continue; // ADD 2009/02/18 不具合対応[11242]

                dr = this._rateShipmentListDt.NewRow();
                // 取得データ展開
                #region 取得データ展開

                dr[PMKEN02015EA.ct_Col_SectionCode] = prmSettingPrintResultWork.SectionCode.Trim().PadLeft(2,'0');      //拠点コード
                // --- ADD 2009/04/07 -------------------------------->>>>>
                if (prmSettingPrintResultWork.SectionCode.Trim().PadLeft(2, '0') == "00")
                {
                    dr[PMKEN02015EA.ct_Col_SectionGuideSnm] = "全社";
                }
                else
                {
                    dr[PMKEN02015EA.ct_Col_SectionGuideSnm] = prmSettingPrintResultWork.SectionGuideSnm;                    //拠点ガイド略称
                }
                // --- ADD 2009/04/07 --------------------------------<<<<<
                dr[PMKEN02015EA.ct_Col_GoodsMGroup] = prmSettingPrintResultWork.GoodsMGroup;                            //商品中分類コード
                dr[PMKEN02015EA.ct_Col_GoodsMGroupName] = prmSettingPrintResultWork.GoodsMGroupName;                    //商品中分類名称
                dr[PMKEN02015EA.ct_Col_TbsPartsCode] = prmSettingPrintResultWork.TbsPartsCode;                          //BLコード
                dr[PMKEN02015EA.ct_Col_BLGoodsHalfName] = prmSettingPrintResultWork.BLGoodsHalfName;                    //BL商品コード名称（半角）
                dr[PMKEN02015EA.ct_Col_PartsMakerCd] = prmSettingPrintResultWork.PartsMakerCd;                          //部品メーカーコード
                dr[PMKEN02015EA.ct_Col_MakerShortName] = prmSettingPrintResultWork.MakerShortName;                      //メーカー略称
                dr[PMKEN02015EA.ct_Col_SupplierCd] = prmSettingPrintResultWork.SupplierCd;                              //仕入先コード
                dr[PMKEN02015EA.ct_Col_SupplierSnm] = prmSettingPrintResultWork.SupplierSnm;                            //仕入先略称
                dr[PMKEN02015EA.ct_Col_PrmSetDtlName1] = prmSettingPrintResultWork.PrmSetDtlName1;                      //優良設定詳細名称１
                dr[PMKEN02015EA.ct_Col_PrmSetDtlName2] = prmSettingPrintResultWork.PrmSetDtlName2;                      //優良設定詳細名称２
                dr[PMKEN02015EA.ct_Col_MakerDispOrder] = prmSettingPrintResultWork.MakerDispOrder;                      //メーカー表示順位
                dr[PMKEN02015EA.ct_Col_PrimeDisplayCode] = prmSettingPrintResultWork.PrimeDisplayCode;                  //優良表示区分
                dr[PMKEN02015EA.ct_Col_Sort_SectionCode] = prmSettingPrintResultWork.SectionCode;                       //ソート用拠点コード
                dr[PMKEN02015EA.ct_Col_Sort_GoodsMGroup] = prmSettingPrintResultWork.GoodsMGroup;                       //ソート用商品中分類コード
                dr[PMKEN02015EA.ct_Col_Sort_TbsPartsCode] = prmSettingPrintResultWork.TbsPartsCode;                     //ソート用BLコード
                dr[PMKEN02015EA.ct_Col_Sort_PartsMakerCd] = prmSettingPrintResultWork.PartsMakerCd;                     //ソート用部品メーカーコード
                dr[PMKEN02015EA.ct_Col_Sort_MakerDispOrder] = prmSettingPrintResultWork.MakerDispOrder;                 //ソート用メーカー表示順位

                #endregion

                // TableにAdd
                this._rateShipmentListDt.Rows.Add(dr);

            }


			// DataView作成
            this._rateShipmentListDataView = new DataView(this._rateShipmentListDt, "", GetSortOrder(prmSettingPrintOrderCndtn), DataViewRowState.CurrentRows);
        }

       

        
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
        private string GetSortOrder(PrmSettingPrintOrderCndtn prmSettingPrintOrderCndtn)
        {
            StringBuilder strSortOrder = new StringBuilder();

            //ソート用拠点コード
            strSortOrder.Append(string.Format("{0},", PMKEN02015EA.ct_Col_Sort_SectionCode));

            //ソート用商品中分類コード
            strSortOrder.Append(string.Format("{0},", PMKEN02015EA.ct_Col_Sort_GoodsMGroup));

            //ソート用BLコード
            strSortOrder.Append(string.Format("{0},", PMKEN02015EA.ct_Col_Sort_TbsPartsCode));

            //ソート用部品メーカーコード
            strSortOrder.Append(string.Format("{0},", PMKEN02015EA.ct_Col_Sort_PartsMakerCd));

            //ソート用メーカー表示順位
            strSortOrder.Append(string.Format("{0}", PMKEN02015EA.ct_Col_Sort_MakerDispOrder));

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
