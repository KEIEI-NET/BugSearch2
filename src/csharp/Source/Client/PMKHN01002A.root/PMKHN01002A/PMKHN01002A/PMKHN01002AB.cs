//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア対象の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 修 正 日  2011/08/19  修正内容 : Redmine#23791対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// データクリアテーブル定義スクラス
    /// </summary>
    /// <remarks>
    /// Note       : データクリア処理です。<br />
    /// Programmer : 劉学智<br />
    /// Date       : 2009.06.16<br />
    /// Update Note: 2011.08.19 duzg
    ///            : Redmine#23791
    /// </remarks>
    public class DataClear
    {
        private const string TBL_STOCKADJUST_ID = "STOCKADJUSTRF";
        private const string TBL_STOCKADJUSTDTL_ID = "STOCKADJUSTDTLRF";
        private const string TBL_STOCKMOVE_ID = "STOCKMOVERF";
        private const string TBL_STOCKACPAYHIST_ID = "STOCKACPAYHISTRF";
        private const string TBL_STOCKSLIP_ID = "STOCKSLIPRF";
        private const string TBL_STOCKDETAIL_ID = "STOCKDETAILRF";
        private const string TBL_SALESSLIP_ID = "SALESSLIPRF";
        private const string TBL_SALESDETAIL_ID = "SALESDETAILRF";
        private const string TBL_DEPSITMAIN_ID = "DEPSITMAINRF";
        private const string TBL_DMDCADDUPHIS_ID = "DMDCADDUPHISRF";
        private const string TBL_PAYMENTADDUPHIS_ID = "PAYMENTADDUPHISRF";
        private const string TBL_MONTHLYADDUPHIS_ID = "MONTHLYADDUPHISRF";
        private const string TBL_PAYMENTSLP_ID = "PAYMENTSLPRF";
        private const string TBL_ACCEPTODR_ID = "ACCEPTODRRF";
        private const string TBL_DEPOSITALW_ID = "DEPOSITALWRF";
        private const string TBL_SALESHISTORY_ID = "SALESHISTORYRF";
        private const string TBL_SALESHISTDTL_ID = "SALESHISTDTLRF";
        private const string TBL_STOCKSLIPHIST_ID = "STOCKSLIPHISTRF";
        private const string TBL_STOCKSLHISTDTL_ID = "STOCKSLHISTDTLRF";
        private const string TBL_MTTLSALESSLIP_ID = "MTTLSALESSLIPRF";
        private const string TBL_GOODSMTTLSASLIP_ID = "GOODSMTTLSASLIPRF";
        private const string TBL_MTTLSTOCKSLIP_ID = "MTTLSTOCKSLIPRF";
        private const string TBL_MTTLSALESSTOCKSLIP_ID = "MTTLSALESSTOCKSLIPRF";
        private const string TBL_DEPSITDTL_ID = "DEPSITDTLRF";
        private const string TBL_PAYMENTDTL_ID = "PAYMENTDTLRF";
        private const string TBL_ACCEPTODRCAR_ID = "ACCEPTODRCARRF";
        private const string TBL_UOEORDERDTL_ID = "UOEORDERDTLRF";
        private const string TBL_STOCKCHECKDTL_ID = "STOCKCHECKDTLRF";
        private const string TBL_RETURNUPPERST_ID = "RETURNUPPERSTRF";
        private const string TBL_CUSTDMDPRC_ID = "CUSTDMDPRCRF";
        private const string TBL_CUSTACCREC_ID = "CUSTACCRECRF";
        private const string TBL_SUPLIERPAY_ID = "SUPLIERPAYRF";
        private const string TBL_SUPLACCPAY_ID = "SUPLACCPAYRF";
        private const string TBL_DMDDEPOTOTAL_ID = "DMDDEPOTOTALRF";
        private const string TBL_ACCRECDEPOTOTAL_ID = "ACCRECDEPOTOTALRF";
        private const string TBL_ACCPAYTOTAL_ID = "ACCPAYTOTALRF";
        private const string TBL_ACALCPAYTOTAL_ID = "ACALCPAYTOTALRF";
        private const string TBL_STOCKHISTORY_ID = "STOCKHISTORYRF";
        private const string TBL_NOMNGSET_ID = "NOMNGSETRF";
		// ADD 2011.08.26 張莉莉 ---------->>>>>
		private const string TBL_DCDATAINFO_ID = "DCDATAINFO";
        //private const string TBL_DCMUSTINFO_ID = "DCMUSTINFO";//DEL by Liangsd     2011/09/06
		// ADD 2011.08.26 張莉莉 ----------<<<<<

        // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
        // SCM受注データ
        private const string TBL_SCMACODRDATA_ID = "SCMACODRDATARF";
        // SCM受発注データ(車両情報)
        private const string TBL_SCMACODRDTCAR_ID = "SCMACODRDTCARRF";
        // SCM受注明細データ（問合せ・発注）
        private const string TBL_SCMACODRDTLIQ_ID = "SCMACODRDTLIQRF";
        // SCM受注明細データ（回答）
        private const string TBL_SCMODRDATA_ID = "SCMACODRDTLASRF";
        // ---------------------- ADD END 2011.08.19 duzg for Redmine#23791 -----------------<<<<<
        
        private const string TBL_STOCKADJUST_NM = "在庫調整データ";
        private const string TBL_STOCKADJUSTDTL_NM = "在庫調整明細データ";
        private const string TBL_STOCKMOVE_NM = "在庫移動データ";
        private const string TBL_STOCKACPAYHIST_NM = "在庫受払履歴データ";
        private const string TBL_STOCKSLIP_NM = "仕入データ";
        private const string TBL_STOCKDETAIL_NM = "仕入明細データ";
        private const string TBL_SALESSLIP_NM = "売上データ";
        private const string TBL_SALESDETAIL_NM = "売上明細データ";
        private const string TBL_DEPSITMAIN_NM = "入金マスタ";
        private const string TBL_DMDCADDUPHIS_NM = "請求締更新履歴マスタ";
        private const string TBL_PAYMENTADDUPHIS_NM = "支払締更新履歴マスタ";
        private const string TBL_MONTHLYADDUPHIS_NM = "月次締更新履歴データ";
        private const string TBL_PAYMENTSLP_NM = "支払伝票マスタ";
        private const string TBL_ACCEPTODR_NM = "受注マスタ";
        private const string TBL_DEPOSITALW_NM = "入金引当マスタ";
        private const string TBL_SALESHISTORY_NM = "売上履歴データ";
        private const string TBL_SALESHISTDTL_NM = "売上履歴明細データ";
        private const string TBL_STOCKSLIPHIST_NM = "仕入履歴データ";
        private const string TBL_STOCKSLHISTDTL_NM = "仕入履歴明細データ";
        private const string TBL_MTTLSALESSLIP_NM = "売上月次集計データ";
        private const string TBL_GOODSMTTLSASLIP_NM = "商品別売上月次集計データ";
        private const string TBL_MTTLSTOCKSLIP_NM = "仕入月次集計データ";
        private const string TBL_MTTLSALESSTOCKSLIP_NM = "売上仕入月次集計データ";
        private const string TBL_DEPSITDTL_NM = "入金明細データ";
        private const string TBL_PAYMENTDTL_NM = "支払明細データ";
        private const string TBL_ACCEPTODRCAR_NM = "売上データ（車輌）";
        private const string TBL_UOEORDERDTL_NM = "UOE発注データ";
        private const string TBL_STOCKCHECKDTL_NM = "仕入チェックデータ（明細）";
        private const string TBL_RETURNUPPERST_NM = "返品上限設定マスタ";
        private const string TBL_CUSTDMDPRC_NM = "得意先請求金額データ";
        private const string TBL_CUSTACCREC_NM = "得意先売掛金額データ";
        private const string TBL_SUPLIERPAY_NM = "仕入先支払金額データ";
        private const string TBL_SUPLACCPAY_NM = "仕入先買掛金額マスタ";
        private const string TBL_DMDDEPOTOTAL_NM = "請求入金集計データ";
        private const string TBL_ACCRECDEPOTOTAL_NM = "売掛入金集計データ";
        private const string TBL_ACCPAYTOTAL_NM = "精算支払集計データ";
        private const string TBL_ACALCPAYTOTAL_NM = "買掛支払集計データ";
        private const string TBL_STOCKHISTORY_NM = "在庫履歴データ";
        private const string TBL_NOMNGSET_NM = "番号管理設定マスタ";
		// ADD 2011.08.26 張莉莉 ---------->>>>>
		private const string TBL_DCDATAINFO_NM = "拠点管理送受信データ（DC）";
        //private const string TBL_DCMUSTINFO_NM = "拠点管理送受信マスタ（DC）";//DEL by Liangsd     2011/09/06
		// ADD 2011.08.26 張莉莉 ----------<<<<<
        // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
        // SCM受注データ
        private const string TBL_SCMACODRDATA_NM = "SCM受注データ";
        // SCM受発注データ(車両情報)
        private const string TBL_SCMACODRDTCAR_NM = "SCM受発注データ(車両情報)";
        // SCM受注明細データ（問合せ・発注）
        private const string TBL_SCMACODRDTLIQ_NM = "SCM受注明細データ（問合せ・発注）";
        // SCM受注明細データ（回答）
        private const string TBL_SCMODRDATA_NM = "SCM受注明細データ（回答）";
        // ---------------------- ADD END 2011.08.19 duzg for Redmine#23791 -----------------<<<<<

        private const Int32 TBL_STOCKADJUST_Code = 0;
        private const Int32 TBL_STOCKADJUSTDTL_Code = 0;
        private const Int32 TBL_STOCKMOVE_Code = 0;
        private const Int32 TBL_STOCKACPAYHIST_Code = 0;
        private const Int32 TBL_STOCKSLIP_Code = 0;
        private const Int32 TBL_STOCKDETAIL_Code = 0;
        private const Int32 TBL_SALESSLIP_Code = 0;
        private const Int32 TBL_SALESDETAIL_Code = 0;
        private const Int32 TBL_DEPSITMAIN_Code = 0;
        private const Int32 TBL_DMDCADDUPHIS_Code = 0;
        private const Int32 TBL_PAYMENTADDUPHIS_Code = 0;
        private const Int32 TBL_MONTHLYADDUPHIS_Code = 0;
        private const Int32 TBL_PAYMENTSLP_Code = 0;
        private const Int32 TBL_ACCEPTODR_Code = 0;
        private const Int32 TBL_DEPOSITALW_Code = 0;
        private const Int32 TBL_SALESHISTORY_Code = 0;
        private const Int32 TBL_SALESHISTDTL_Code = 0;
        private const Int32 TBL_STOCKSLIPHIST_Code = 0;
        private const Int32 TBL_STOCKSLHISTDTL_Code = 0;
        private const Int32 TBL_MTTLSALESSLIP_Code = 0;
        private const Int32 TBL_GOODSMTTLSASLIP_Code = 0;
        private const Int32 TBL_MTTLSTOCKSLIP_Code = 0;
        private const Int32 TBL_MTTLSALESSTOCKSLIP_Code = 0;
        private const Int32 TBL_DEPSITDTL_Code = 0;
        private const Int32 TBL_PAYMENTDTL_Code = 0;
        private const Int32 TBL_ACCEPTODRCAR_Code = 0;
        private const Int32 TBL_UOEORDERDTL_Code = 0;
        private const Int32 TBL_STOCKCHECKDTL_Code = 0;
        private const Int32 TBL_RETURNUPPERST_Code = 0;
        private const Int32 TBL_CUSTDMDPRC_Code = 1;
        private const Int32 TBL_CUSTACCREC_Code = 1;
        private const Int32 TBL_SUPLIERPAY_Code = 1;
        private const Int32 TBL_SUPLACCPAY_Code = 1;
        private const Int32 TBL_DMDDEPOTOTAL_Code = 2;
        private const Int32 TBL_ACCRECDEPOTOTAL_Code = 2;
        private const Int32 TBL_ACCPAYTOTAL_Code = 2;
        private const Int32 TBL_ACALCPAYTOTAL_Code = 2;
        private const Int32 TBL_STOCKHISTORY_Code = 3;
        private const Int32 TBL_NOMNGSET_Code = 4;
		// ADD 2011.08.26 張莉莉 ---------->>>>>
		private const Int32 TBL_DCDATAINFO_Code = 0;
		private const Int32 TBL_DCMUSTINFO_Code = 0;
		// ADD 2011.08.26 張莉莉 ----------<<<<<
        // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
        // SCM受注データ
        private const Int32 TBL_SCMACODRDATA_Code = 0;
        // SCM受発注データ(車両情報)
        private const Int32 TBL_SCMACODRDTCAR_Code = 0;
        // SCM受注明細データ（問合せ・発注）
        private const Int32 TBL_SCMACODRDTLIQ_Code = 0;
        // SCM受注明細データ（回答）
        private const Int32 TBL_SCMODRDATA_Code = 0;
        // ---------------------- ADD END 2011.08.19 duzg for Redmine#23791 -----------------<<<<<

        private const string TBL_CUSTDMDPRC_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_CUSTACCREC_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_SUPLIERPAY_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_SUPLACCPAY_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_DMDDEPOTOTAL_FileId = "ADDUPDATERF";
        private const string TBL_ACCRECDEPOTOTAL_FileId = "ADDUPDATERF";
        private const string TBL_ACCPAYTOTAL_FileId = "ADDUPDATERF";
        private const string TBL_ACALCPAYTOTAL_FileId = "ADDUPDATERF";

        #region ■ クリア対象データの取得処理 ■
        /// <summary>
        /// クリア対象データの取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クリア対象データの取得処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>クリア対象データリスト</returns>
        public ArrayList GetDataClearList()
        {
            ArrayList dataClearList = new ArrayList();

            // 在庫調整データ
            DataClearWork dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKADJUST_ID;
            dataClearWork.TableNm = TBL_STOCKADJUST_NM;
            dataClearWork.ClearCode = TBL_STOCKADJUST_Code;
            dataClearList.Add(dataClearWork);

            // 在庫調整明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKADJUSTDTL_ID;
            dataClearWork.TableNm = TBL_STOCKADJUSTDTL_NM;
            dataClearWork.ClearCode = TBL_STOCKADJUSTDTL_Code;
            dataClearList.Add(dataClearWork);

            // 在庫移動データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKMOVE_ID;
            dataClearWork.TableNm = TBL_STOCKMOVE_NM;
            dataClearWork.ClearCode = TBL_STOCKMOVE_Code;
            dataClearList.Add(dataClearWork);

            // 在庫受払履歴データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKACPAYHIST_ID;
            dataClearWork.TableNm = TBL_STOCKACPAYHIST_NM;
            dataClearWork.ClearCode = TBL_STOCKACPAYHIST_Code;
            dataClearList.Add(dataClearWork);

            // 仕入データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKSLIP_ID;
            dataClearWork.TableNm = TBL_STOCKSLIP_NM;
            dataClearWork.ClearCode = TBL_STOCKSLIP_Code;
            dataClearList.Add(dataClearWork);

            // 仕入明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKDETAIL_ID;
            dataClearWork.TableNm = TBL_STOCKDETAIL_NM;
            dataClearWork.ClearCode = TBL_STOCKDETAIL_Code;
            dataClearList.Add(dataClearWork);

            // 売上データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESSLIP_ID;
            dataClearWork.TableNm = TBL_SALESSLIP_NM;
            dataClearWork.ClearCode = TBL_SALESSLIP_Code;
            dataClearList.Add(dataClearWork);

            // 売上明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESDETAIL_ID;
            dataClearWork.TableNm = TBL_SALESDETAIL_NM;
            dataClearWork.ClearCode = TBL_SALESDETAIL_Code;
            dataClearList.Add(dataClearWork);

            // 入金マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DEPSITMAIN_ID;
            dataClearWork.TableNm = TBL_DEPSITMAIN_NM;
            dataClearWork.ClearCode = TBL_DEPSITMAIN_Code;
            dataClearList.Add(dataClearWork);

            // 請求締更新履歴マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DMDCADDUPHIS_ID;
            dataClearWork.TableNm = TBL_DMDCADDUPHIS_NM;
            dataClearWork.ClearCode = TBL_DMDCADDUPHIS_Code;
            dataClearList.Add(dataClearWork);

            // 支払締更新履歴マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_PAYMENTADDUPHIS_ID;
            dataClearWork.TableNm = TBL_PAYMENTADDUPHIS_NM;
            dataClearWork.ClearCode = TBL_PAYMENTADDUPHIS_Code;
            dataClearList.Add(dataClearWork);

            // 月次締更新履歴データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MONTHLYADDUPHIS_ID;
            dataClearWork.TableNm = TBL_MONTHLYADDUPHIS_NM;
            dataClearWork.ClearCode = TBL_MONTHLYADDUPHIS_Code;
            dataClearList.Add(dataClearWork);

            // 支払伝票マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_PAYMENTSLP_ID;
            dataClearWork.TableNm = TBL_PAYMENTSLP_NM;
            dataClearWork.ClearCode = TBL_PAYMENTSLP_Code;
            dataClearList.Add(dataClearWork);

            // 受注マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCEPTODR_ID;
            dataClearWork.TableNm = TBL_ACCEPTODR_NM;
            dataClearWork.ClearCode = TBL_ACCEPTODR_Code;
            dataClearList.Add(dataClearWork);

            // 入金引当マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DEPOSITALW_ID;
            dataClearWork.TableNm = TBL_DEPOSITALW_NM;
            dataClearWork.ClearCode = TBL_DEPOSITALW_Code;
            dataClearList.Add(dataClearWork);

            // 売上履歴データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESHISTORY_ID;
            dataClearWork.TableNm = TBL_SALESHISTORY_NM;
            dataClearWork.ClearCode = TBL_SALESHISTORY_Code;
            dataClearList.Add(dataClearWork);

            // 売上履歴明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESHISTDTL_ID;
            dataClearWork.TableNm = TBL_SALESHISTDTL_NM;
            dataClearWork.ClearCode = TBL_SALESHISTDTL_Code;
            dataClearList.Add(dataClearWork);

            // 仕入履歴データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKSLIPHIST_ID;
            dataClearWork.TableNm = TBL_STOCKSLIPHIST_NM;
            dataClearWork.ClearCode = TBL_STOCKSLIPHIST_Code;
            dataClearList.Add(dataClearWork);

            // 仕入履歴明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKSLHISTDTL_ID;
            dataClearWork.TableNm = TBL_STOCKSLHISTDTL_NM;
            dataClearWork.ClearCode = TBL_STOCKSLHISTDTL_Code;
            dataClearList.Add(dataClearWork);

            // 売上月次集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MTTLSALESSLIP_ID;
            dataClearWork.TableNm = TBL_MTTLSALESSLIP_NM;
            dataClearWork.ClearCode = TBL_MTTLSALESSLIP_Code;
            dataClearList.Add(dataClearWork);

            // 商品別売上月次集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_GOODSMTTLSASLIP_ID;
            dataClearWork.TableNm = TBL_GOODSMTTLSASLIP_NM;
            dataClearWork.ClearCode = TBL_GOODSMTTLSASLIP_Code;
            dataClearList.Add(dataClearWork);

            // 仕入月次集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MTTLSTOCKSLIP_ID;
            dataClearWork.TableNm = TBL_MTTLSTOCKSLIP_NM;
            dataClearWork.ClearCode = TBL_MTTLSTOCKSLIP_Code;
            dataClearList.Add(dataClearWork);

            // 売上仕入月次集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MTTLSALESSTOCKSLIP_ID;
            dataClearWork.TableNm = TBL_MTTLSALESSTOCKSLIP_NM;
            dataClearWork.ClearCode = TBL_MTTLSALESSTOCKSLIP_Code;
            dataClearList.Add(dataClearWork);

            // 入金明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DEPSITDTL_ID;
            dataClearWork.TableNm = TBL_DEPSITDTL_NM;
            dataClearWork.ClearCode = TBL_DEPSITDTL_Code;
            dataClearList.Add(dataClearWork);

            // 支払明細データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_PAYMENTDTL_ID;
            dataClearWork.TableNm = TBL_PAYMENTDTL_NM;
            dataClearWork.ClearCode = TBL_PAYMENTDTL_Code;
            dataClearList.Add(dataClearWork);

            // 売上データ（車輌）
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCEPTODRCAR_ID;
            dataClearWork.TableNm = TBL_ACCEPTODRCAR_NM;
            dataClearWork.ClearCode = TBL_ACCEPTODRCAR_Code;
            dataClearList.Add(dataClearWork);

            // UOE発注データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_UOEORDERDTL_ID;
            dataClearWork.TableNm = TBL_UOEORDERDTL_NM;
            dataClearWork.ClearCode = TBL_UOEORDERDTL_Code;
            dataClearList.Add(dataClearWork);

            // 仕入チェックデータ（明細）
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKCHECKDTL_ID;
            dataClearWork.TableNm = TBL_STOCKCHECKDTL_NM;
            dataClearWork.ClearCode = TBL_STOCKCHECKDTL_Code;
            dataClearList.Add(dataClearWork);

            // 返品上限設定マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_RETURNUPPERST_ID;
            dataClearWork.TableNm = TBL_RETURNUPPERST_NM;
            dataClearWork.ClearCode = TBL_RETURNUPPERST_Code;
            dataClearList.Add(dataClearWork);

            // 得意先請求金額データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_CUSTDMDPRC_ID;
            dataClearWork.TableNm = TBL_CUSTDMDPRC_NM;
            dataClearWork.ClearCode = TBL_CUSTDMDPRC_Code;
            dataClearWork.FileId = TBL_CUSTDMDPRC_FileId;
            dataClearList.Add(dataClearWork);

            // 得意先売掛金額データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_CUSTACCREC_ID;
            dataClearWork.TableNm = TBL_CUSTACCREC_NM;
            dataClearWork.ClearCode = TBL_CUSTACCREC_Code;
            dataClearWork.FileId = TBL_CUSTACCREC_FileId;
            dataClearList.Add(dataClearWork);

            // 仕入先支払金額データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SUPLIERPAY_ID;
            dataClearWork.TableNm = TBL_SUPLIERPAY_NM;
            dataClearWork.ClearCode = TBL_SUPLIERPAY_Code;
            dataClearWork.FileId = TBL_SUPLIERPAY_FileId;
            dataClearList.Add(dataClearWork);

            // 仕入先買掛金額マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SUPLACCPAY_ID;
            dataClearWork.TableNm = TBL_SUPLACCPAY_NM;
            dataClearWork.ClearCode = TBL_SUPLACCPAY_Code;
            dataClearWork.FileId = TBL_SUPLACCPAY_FileId;
            dataClearList.Add(dataClearWork);

            // 請求入金集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DMDDEPOTOTAL_ID;
            dataClearWork.TableNm = TBL_DMDDEPOTOTAL_NM;
            dataClearWork.ClearCode = TBL_DMDDEPOTOTAL_Code;
            dataClearWork.FileId = TBL_DMDDEPOTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // 売掛入金集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCRECDEPOTOTAL_ID;
            dataClearWork.TableNm = TBL_ACCRECDEPOTOTAL_NM;
            dataClearWork.ClearCode = TBL_ACCRECDEPOTOTAL_Code;
            dataClearWork.FileId = TBL_ACCRECDEPOTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // 精算支払集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCPAYTOTAL_ID;
            dataClearWork.TableNm = TBL_ACCPAYTOTAL_NM;
            dataClearWork.ClearCode = TBL_ACCPAYTOTAL_Code;
            dataClearWork.FileId = TBL_ACCPAYTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // 買掛支払集計データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACALCPAYTOTAL_ID;
            dataClearWork.TableNm = TBL_ACALCPAYTOTAL_NM;
            dataClearWork.ClearCode = TBL_ACALCPAYTOTAL_Code;
            dataClearWork.FileId = TBL_ACALCPAYTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // 在庫履歴データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKHISTORY_ID;
            dataClearWork.TableNm = TBL_STOCKHISTORY_NM;
            dataClearWork.ClearCode = TBL_STOCKHISTORY_Code;
            dataClearList.Add(dataClearWork);

            // 番号管理設定マスタ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_NOMNGSET_ID;
            dataClearWork.TableNm = TBL_NOMNGSET_NM;
            dataClearWork.ClearCode = TBL_NOMNGSET_Code;
            dataClearList.Add(dataClearWork);

            // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
            // SCM受注データ
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMACODRDATA_ID;
            dataClearWork.TableNm = TBL_SCMACODRDATA_NM;
            dataClearWork.ClearCode = TBL_SCMACODRDATA_Code;
            dataClearList.Add(dataClearWork);

            // SCM受発注データ(車両情報)
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMACODRDTCAR_ID;
            dataClearWork.TableNm = TBL_SCMACODRDTCAR_NM;
            dataClearWork.ClearCode = TBL_SCMACODRDTCAR_Code;
            dataClearList.Add(dataClearWork);

            // SCM受注明細データ（問合せ・発注）
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMACODRDTLIQ_ID;
            dataClearWork.TableNm = TBL_SCMACODRDTLIQ_NM;
            dataClearWork.ClearCode = TBL_SCMACODRDTLIQ_Code;
            dataClearList.Add(dataClearWork);

            // CM受注明細データ（回答）
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMODRDATA_ID;
            dataClearWork.TableNm = TBL_SCMODRDATA_NM;
            dataClearWork.ClearCode = TBL_SCMODRDATA_Code;
            dataClearList.Add(dataClearWork);
            // ---------------------- ADD END   2011.08.19 duzg for Redmine#23791 -----------------<<<<<
			// ADD 2011.08.26 張莉莉 ---------->>>>>
			// 拠点オプション有無チェック
			PurchaseStatus ps;
			ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION);

			if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
			{
				//拠点管理送受信データ（DC）
				dataClearWork = new DataClearWork();
				dataClearWork.TableId = TBL_DCDATAINFO_ID;
				dataClearWork.TableNm = TBL_DCDATAINFO_NM;
				dataClearWork.ClearCode = TBL_DCDATAINFO_Code;
				dataClearList.Add(dataClearWork);

                //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                ////拠点管理送受信マスタ（DC）
                //dataClearWork = new DataClearWork();
                //dataClearWork.TableId = TBL_DCMUSTINFO_ID;
                //dataClearWork.TableNm = TBL_DCMUSTINFO_NM;
                //dataClearWork.ClearCode = TBL_DCMUSTINFO_Code;
                //dataClearList.Add(dataClearWork);
                //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
			}            
		    // ADD 2011.08.26 張莉莉 ----------<<<<<

            return dataClearList;
        }
        #endregion
    }
}
