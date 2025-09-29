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
    /// 仕入ｱﾝﾏｯﾁﾘｽﾄアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入ｱﾝﾏｯﾁﾘｽﾄで使用するデータを取得する。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.17</br>
    /// <br></br>
    /// </remarks>
    public class SupplierUnmAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入ｱﾝﾏｯﾁﾘｽﾄアクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30413 犬飼</br>
	    /// <br>Date       : 2008.12.17</br>
		/// </remarks>
		public SupplierUnmAcs()
		{
            this._iSupplierUnmOrderWorkDB = (ISupplierUnmOrderWorkDB)MediationSupplierUnmOrderWorkDB.GetSupplierUnmOrderWorkDB();
		}

		/// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄ表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入ｱﾝﾏｯﾁﾘｽﾄ表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        static SupplierUnmAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
			
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
        ISupplierUnmOrderWorkDB _iSupplierUnmOrderWorkDB;         // 仕入ｱﾝﾏｯﾁﾘｽﾄリモート

        private DataSet _supplierUnmDs;				        // 仕入ｱﾝﾏｯﾁﾘｽﾄデータセット
        
        #endregion ■ Private Member

        #region ■ Private Const
        private const string ct_Contents_UOE_BO = "伝票番号未設定";
        private const string ct_Contents_Maker = "伝票番号未設定(ﾒｰｶｰﾌｫﾛｰ)";
        private const string ct_Contents_EO = "伝票番号未設定(EO)";
        #endregion ■ Private Const

        #region ■ Public Property
        /// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄデータセット(読み取り専用)
        /// </summary>
        public DataSet SupplierUnmDs
        {
            get { return this._supplierUnmDs; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 請求データ取得
        /// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄデータ取得
        /// </summary>
        /// <param name="enterSchOrderCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入ｱﾝﾏｯﾁﾘｽﾄデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        public int SearchSupplierUnm(SupplierUnmOrderCndtn supplierUnmOrderCndtn, out string errMsg)
        {
            return this.SearchSupplierUnmProc(supplierUnmOrderCndtn, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 仕入ｱﾝﾏｯﾁﾘｽﾄデータ取得
        /// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄデータ取得
        /// </summary>
        /// <param name="supplierUnmOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入ｱﾝﾏｯﾁﾘｽﾄデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        private int SearchSupplierUnmProc(SupplierUnmOrderCndtn supplierUnmOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                SupplierUnmResult.CreateDataTableResultSupplierUnm(ref this._supplierUnmDs);
                SupplierUnmOrderCndtnWork supplierUnmOrderCndtnWork = new SupplierUnmOrderCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevSupplierUnm(supplierUnmOrderCndtn, out supplierUnmOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                status = this._iSupplierUnmOrderWorkDB.Search(out retList, (object)supplierUnmOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevSupplierUnmData(supplierUnmOrderCndtn, this._supplierUnmDs.Tables[SupplierUnmResult.Col_Tbl_Result_SupplierUnm], (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "仕入ｱﾝﾏｯﾁﾘｽﾄデータの取得に失敗しました。";
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
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="supplierUnmOrderCndtn">UI抽出条件クラス</param>
        /// <param name="supplierUnmOrderCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevSupplierUnm(SupplierUnmOrderCndtn supplierUnmOrderCndtn, out SupplierUnmOrderCndtnWork supplierUnmOrderCndtnWork, out string errMsg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            supplierUnmOrderCndtnWork = new SupplierUnmOrderCndtnWork();

            try
            {
                // 企業コード
                supplierUnmOrderCndtnWork.EnterpriseCode = supplierUnmOrderCndtn.EnterpriseCode;

                // 抽出条件パラメータセット
                if (supplierUnmOrderCndtn.SectionCodes.Length != 0)
                {
                    if (supplierUnmOrderCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        supplierUnmOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        supplierUnmOrderCndtnWork.SectionCodes = supplierUnmOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    supplierUnmOrderCndtnWork.SectionCodes = null;
                }


                supplierUnmOrderCndtnWork.St_SupplierCd = supplierUnmOrderCndtn.St_SupplierCd;              // 開始仕入先コード
                supplierUnmOrderCndtnWork.Ed_SupplierCd = supplierUnmOrderCndtn.Ed_SupplierCd;              // 終了仕入先コード
                
                supplierUnmOrderCndtnWork.St_ReceiveDate = supplierUnmOrderCndtn.St_ReceiveDate;	        // 開始受信日付
                supplierUnmOrderCndtnWork.Ed_ReceiveDate = supplierUnmOrderCndtn.Ed_ReceiveDate;	        // 終了受信日付
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 仕入ｱﾝﾏｯﾁﾘｽﾄデータ展開処理
        /// <summary>
        /// 仕入ｱﾝﾏｯﾁﾘｽﾄデータ展開処理
        /// </summary>
        /// <param name="supplierUnmOrderCndtn">UI抽出条件クラス</param>
        /// <param name="supplierUnmDt">展開対象DataTable</param>
        /// <param name="supplierUnmResultWorkList">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 仕入ｱﾝﾏｯﾁﾘｽﾄデータを展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        private void DevSupplierUnmData(SupplierUnmOrderCndtn supplierUnmOrderCndtn, DataTable supplierUnmDt, ArrayList supplierUnmResultWorkList)
        {
            foreach (SupplierUnmResultWork supplierUnmResultWork in supplierUnmResultWorkList)
            {
                // 2009.02.18 30413 犬飼 伝票番号が空白の場合に印字するように修正 >>>>>>START
                //if (supplierUnmResultWork.UOESectOutGoodsCnt != 0)
                if ((supplierUnmResultWork.UOESectOutGoodsCnt != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.UOESectionSlipNo)))
                {
                    // UOE拠点出庫数
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 0);
                }
                //if (supplierUnmResultWork.BOShipmentCnt1 != 0)
                if ((supplierUnmResultWork.BOShipmentCnt1 != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.BOSlipNo1)))
                {
                    // BO出庫数1
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 1);
                }
                //if (supplierUnmResultWork.BOShipmentCnt2 != 0)
                if ((supplierUnmResultWork.BOShipmentCnt2 != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.BOSlipNo2)))
                {
                    // BO出庫数2
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 2);
                }
                //if (supplierUnmResultWork.BOShipmentCnt3 != 0)
                if ((supplierUnmResultWork.BOShipmentCnt3 != 0) && (string.IsNullOrEmpty(supplierUnmResultWork.BOSlipNo3)))
                {
                    // BO出庫数3
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 3);
                }
                // 2009.02.18 30413 犬飼 伝票番号が空白の場合に印字するように修正 <<<<<<END
                if (supplierUnmResultWork.MakerFollowCnt != 0)
                {
                    // メーカーフォロー数
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 4);
                }
                if (supplierUnmResultWork.EOAlwcCount != 0)
                {
                    // EO引当数
                    DataSetSupplierUnm(supplierUnmDt, supplierUnmResultWork, 5);
                }
            }
        }
        #endregion


        /// <summary>
        /// 取得データ設定処理
        /// </summary>
        /// <param name="supplierUnmDt">展開対象DataTable</param>
        /// <param name="supplierUnmResultWork">取得データ</param>
        /// <param name="addFlg">データ設定フラグ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
        /// </remarks>
        private void DataSetSupplierUnm(DataTable supplierUnmDt, SupplierUnmResultWork supplierUnmResultWork, int addFlg)
        {
            DataRow dr;

            dr = supplierUnmDt.NewRow();

            // 仕入ｱﾝﾏｯﾁﾘｽﾄデータ展開
            #region 仕入ｱﾝﾏｯﾁﾘｽﾄデータ展開
            // 拠点コード
            dr[SupplierUnmResult.Col_SectionCode] = supplierUnmResultWork.SectionCode;
            // 拠点ガイド略称
            dr[SupplierUnmResult.Col_SectionGuideSnm] = supplierUnmResultWork.SectionGuideSnm;
            // 仕入先コード
            dr[SupplierUnmResult.Col_SupplierCd] = supplierUnmResultWork.SupplierCd;
            // 仕入先略称
            dr[SupplierUnmResult.Col_SupplierSnm] = supplierUnmResultWork.SupplierSnm;            
            // 売上日付(受注日付)
            dr[SupplierUnmResult.Col_SalesDate] = supplierUnmResultWork.SalesDate;
            // 商品番号
            dr[SupplierUnmResult.Col_GoodsNo] = supplierUnmResultWork.GoodsNo;
            // 商品名称
            dr[SupplierUnmResult.Col_GoodsName] = supplierUnmResultWork.GoodsName;
            // 受注数量
            dr[SupplierUnmResult.Col_AcceptAnOrderCnt] = supplierUnmResultWork.AcceptAnOrderCnt;
            // BO区分
            dr[SupplierUnmResult.Col_BoCode] = supplierUnmResultWork.BoCode;
            // 回答定価
            dr[SupplierUnmResult.Col_AnswerListPrice] = supplierUnmResultWork.AnswerListPrice;
            // 回答原価単価
            dr[SupplierUnmResult.Col_AnswerSalesUnitCost] = supplierUnmResultWork.AnswerSalesUnitCost;
            // UOE発注番号
            dr[SupplierUnmResult.Col_UOESalesOrderNo] = supplierUnmResultWork.UOESalesOrderNo;
            // システム区分
            dr[SupplierUnmResult.Col_SystemDivCd] = supplierUnmResultWork.SystemDivCd;
            // UOE拠点出庫数
            dr[SupplierUnmResult.Col_UOESectOutGoodsCnt] = supplierUnmResultWork.UOESectOutGoodsCnt;
            // BO出庫数1
            dr[SupplierUnmResult.Col_BOShipmentCnt1] = supplierUnmResultWork.BOShipmentCnt1;
            // BO出庫数2
            dr[SupplierUnmResult.Col_BOShipmentCnt2] = supplierUnmResultWork.BOShipmentCnt2;
            // BO出庫数3
            dr[SupplierUnmResult.Col_BOShipmentCnt3] = supplierUnmResultWork.BOShipmentCnt3;
            // メーカーフォロー数
            dr[SupplierUnmResult.Col_MakerFollowCnt] = supplierUnmResultWork.MakerFollowCnt;
            // UOE拠点伝票番号
            dr[SupplierUnmResult.Col_UOESectionSlipNo] = supplierUnmResultWork.UOESectionSlipNo;
            // BO伝票番号１
            dr[SupplierUnmResult.Col_BOSlipNo1] = supplierUnmResultWork.BOSlipNo1;
            // BO伝票番号２
            dr[SupplierUnmResult.Col_BOSlipNo2] = supplierUnmResultWork.BOSlipNo2;
            // BO伝票番号３
            dr[SupplierUnmResult.Col_BOSlipNo3] = supplierUnmResultWork.BOSlipNo3;
            // EO引当数
            dr[SupplierUnmResult.Col_EOAlwcCount] = supplierUnmResultWork.EOAlwcCount;
            
            // 印刷用
            // 売上日付(受注日付)(印刷用)
            dr[SupplierUnmResult.Col_SalesDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", supplierUnmResultWork.SalesDate);            
            // システム区分(印刷用)
            switch (supplierUnmResultWork.SystemDivCd)
            {
                case 0:
                    {
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "手入力";
                        break;
                    }
                case 1:
                    {
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "伝発";
                        break;
                    }
                case 2:
                    {
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "検索";
                        break;
                    }
                default:
                    {
                        // その他
                        dr[SupplierUnmResult.Col_SystemDivCd_Print] = "";
                        break;
                    }
            }

            if (addFlg == 0)
            {
                // UOE拠点出庫数
                // 数量
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.UOESectOutGoodsCnt;
                // 内容
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 1)
            {
                // BO出庫数1
                // 数量
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.BOShipmentCnt1;
                // 内容
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 2)
            {
                // BO出庫数2
                // 数量
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.BOShipmentCnt2;
                // 内容
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 3)
            {
                // BO出庫数3
                // 数量
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.BOShipmentCnt3;
                // 内容
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_UOE_BO;
            }
            else if (addFlg == 4)
            {
                // ﾒｰｶｰﾌｫﾛｰ分
                // 数量
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.MakerFollowCnt;
                // 内容
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_Maker;
            }
            else
            {
                // EO引当数
                // 数量
                dr[SupplierUnmResult.Col_QTY] = supplierUnmResultWork.EOAlwcCount;
                // 内容
                dr[SupplierUnmResult.Col_Contents] = ct_Contents_EO;
            }

            // TableにAdd
            supplierUnmDt.Rows.Add(dr);
        }

        #endregion ◆ データ展開処理
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.17</br>
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
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
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
