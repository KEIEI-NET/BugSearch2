// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 卸商商品価格改正アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 卸商商品価格改正のアクセスクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public class GoodsInfoAcs
    {
        #region ■ Private Members


        /// <summary> 帳票出力設定アクセスクラス </summary>
        private PrtOutSetAcs _prtOutSetAcs;

        /// <summary> 卸商商品価格改正アクセスクラス </summary>
        private IGoodsInfoWorkDB _iGoodsInfoWorkDB;

        #endregion ■ Private Members


        # region ■ Constractor
        /// <summary>
        /// 卸商商品価格改正アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正のアクセスクラスのコンストラクタです。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public GoodsInfoAcs()
        {
            this._prtOutSetAcs = new PrtOutSetAcs();

            string errMsg=string.Empty;
            this._iGoodsInfoWorkDB = (IGoodsInfoWorkDB)MediationGoodsInfoWorkDB.GetGoodsInfoWorkDB();
        }
        # endregion ■ Constractor


        #region ■ Public Methods
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            prtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                status = this._prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
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
            catch (Exception ex)
            {
                errMsg = ex.Message;
                prtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return (status);
        }


        /// <summary>
        /// 卸商商品価格改正更新処理
        /// </summary>
        /// <param name="trustStockResultList">卸商商品価格改正データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正を更新します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public int WriteGoodsInfo(out object countNum, out object writeError, GoodsInfoCndtn goodsInfoCndtn, List<GoodsInfoData> normalGoodsInfoLst, List<GoodsInfoData> warnGoodsInfoLst, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            countNum = null;
            writeError = null;
            ArrayList normalGoodsInfoDataWorkLst = new ArrayList();

            ArrayList warnGoodsInfoDataWorkLst = new ArrayList();

            if (((null != normalGoodsInfoLst) && (normalGoodsInfoLst.Count > 0))
                || ((null != warnGoodsInfoLst) && (warnGoodsInfoLst.Count > 0)))
            {
                if ((null != normalGoodsInfoLst) && (normalGoodsInfoLst.Count > 0))
                {
                    status = this.DevGoodsInfoData(normalGoodsInfoLst, out normalGoodsInfoDataWorkLst, out errMsg);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return status;
                    }
                }

                if ((null != warnGoodsInfoLst) && (warnGoodsInfoLst.Count > 0))
                {
                    status = this.DevGoodsInfoData(warnGoodsInfoLst, out warnGoodsInfoDataWorkLst, out errMsg);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return status;
                    }
                }
            }

            GoodsInfoCndtnWork goodsInfoCndtnWork = new GoodsInfoCndtnWork();

            
            // 抽出条件展開  --------------------------------------------------------------
            status = this.DevGoodsInfoMainCndtn(goodsInfoCndtn, out goodsInfoCndtnWork, out errMsg);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            object normalGoodsInfoData = normalGoodsInfoDataWorkLst;
            object warnGoodsInfoData = warnGoodsInfoDataWorkLst;
            status = this._iGoodsInfoWorkDB.WriteGoodsInfo(out countNum, out writeError, ref normalGoodsInfoData, ref warnGoodsInfoData, goodsInfoCndtnWork);
            return status;
        }

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="AcceptAnOrderReportCndtn">UI抽出条件クラス</param>
        /// <param name="extrInfo_AcceptAnOrderReportWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行います。</br>		
        /// <br>Programmer : 汪千来</br>		
        /// <br>Date       : 2009/04/28</br>		
        /// </remarks>		
        private int DevGoodsInfoData(List<GoodsInfoData> goodsInfoDataLst, out ArrayList goodsInfoDataWorkLst, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            GoodsInfoDataWork tempGoodsInfoDataWork = null;
            goodsInfoDataWorkLst = new ArrayList();
            try
            {
                foreach (GoodsInfoData tempGoodsInfoData in goodsInfoDataLst)
                {
                    tempGoodsInfoDataWork = new GoodsInfoDataWork();
                    tempGoodsInfoDataWork.BLGoodsCode = tempGoodsInfoData.BLGoodsCode;
                    tempGoodsInfoDataWork.FileCreateDateTime = tempGoodsInfoData.FileCreateDateTime;
                    tempGoodsInfoDataWork.EnterpriseCode = tempGoodsInfoData.EnterpriseCode;
                    tempGoodsInfoDataWork.GoodsMakerCd = tempGoodsInfoData.GoodsMakerCd;
                    tempGoodsInfoDataWork.GoodsName = tempGoodsInfoData.GoodsName;
                    tempGoodsInfoDataWork.GoodsNo = tempGoodsInfoData.GoodsNo;
                    tempGoodsInfoDataWork.GoodsTraderCd = tempGoodsInfoData.GoodsTraderCd;
                    tempGoodsInfoDataWork.KindCd = tempGoodsInfoData.KindCd;
                    tempGoodsInfoDataWork.LoginFlg = tempGoodsInfoData.LoginFlg;
                    tempGoodsInfoDataWork.PdfStatus = tempGoodsInfoData.PdfStatus;
                    tempGoodsInfoDataWork.Price = tempGoodsInfoData.Price;
                    tempGoodsInfoDataWork.Price1 = tempGoodsInfoData.Price1;
                    tempGoodsInfoDataWork.Price2 = tempGoodsInfoData.Price2;
                    tempGoodsInfoDataWork.Price3 = tempGoodsInfoData.Price3;
                    tempGoodsInfoDataWork.PriceStartDate = tempGoodsInfoData.PriceStartDate;
                    tempGoodsInfoDataWork.SalesUnitCost = tempGoodsInfoData.SalesUnitCost;
                    tempGoodsInfoDataWork.StockRate = tempGoodsInfoData.StockRate;
                    tempGoodsInfoDataWork.SupplierCd = tempGoodsInfoData.SupplierCd;

                    goodsInfoDataWorkLst.Add(tempGoodsInfoDataWork);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="AcceptAnOrderReportCndtn">UI抽出条件クラス</param>
        /// <param name="extrInfo_AcceptAnOrderReportWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行います。</br>		
        /// <br>Programmer : 汪千来</br>		
        /// <br>Date       : 2009/04/28</br>		
        /// </remarks>		
        private int DevGoodsInfoMainCndtn(GoodsInfoCndtn goodsInfoCndtn, out GoodsInfoCndtnWork goodsInfoCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            goodsInfoCndtnWork = new GoodsInfoCndtnWork();

            try
            {
                goodsInfoCndtnWork.EnterpriseCode = goodsInfoCndtn.EnterpriseCode;

                goodsInfoCndtnWork.UpdateType = goodsInfoCndtn.UpdateType;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }



        #endregion



        #endregion ■ Public Methods


        #region ■ Private Methods


        #endregion ■ Private Methods
    }
}
