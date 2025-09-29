//****************************************************************************//
// システム         : PMTAB 自動回答処理(データ登録)
// プログラム名称   : PMTAB 自動回答処理(データ登録)アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : zhubj
// 作 成 日  2013/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note     : Redmine#37832 【自動回答処理(データ登録）】
//                   売上明細データ登録時、BLグループ名称（掛率）にBLグループ名称がセットされていません //
// 管理番号        : 10902622-01                                              //
// Programmer      : songg                                                    //
// Date            : 2013/07/04                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#38976  値引きを入力して登録すると、異常なほど重い//
// 管理番号        : 10902622-01                                              //
// Programmer      : wangl2                                                   //
// Date            : 2013/07/23                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39126  入金伝票の摘要が正しくない対応          　//
// 管理番号        : 10902622-01                                              //
// Programmer      : 鄭慕鈞                                                   //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39026 行値引きの売上部品小計(税込)を修正         //
// 管理番号        : 10902622-01                                              //
// Programmer      : qijh                                                     //
// Date            : 2013/07/24                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39486 メーカー名・仕入先名設定　　　　　         //
// 管理番号        : 10902622-01                                              //
// Programmer      : 三戸                                                     //
// Date            : 2013/08/01                                               //
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39637　キャンペーンコードの設定
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/06
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 回答純正商品番号の設定
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/16
//----------------------------------------------------------------------------//
// Update Note     : Redmine#40183 純正商品メーカーコード設定
// 管理番号        : 10902622-01
// Programmer      : 湯上
// Date            : 2013/08/29
//----------------------------------------------------------------------------//
// Update Note     : Redmine#39979 回答純正商品番号の設定
// 管理番号        : 10902622-01
// Programmer      : 吉岡
// Date            : 2013/08/30
//----------------------------------------------------------------------------//
// Update Note     : Tabletでの売上時に売上明細の純正メーカーが未登録になる障害を修正
// 管理番号        : 11070148-00
// Programmer      : 宮本
// Date            : 2014/09/08
//----------------------------------------------------------------------------//

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB 自動回答処理(データ登録)アクセスクラス
    /// </summary>
    public partial class TabSCMSalesDataMaker
    {
        #region Private Members
        // 品番検索アクセス
        private static GoodsAcs _goodsAcs;
        private GoodsAcs GetGoodsAcs
        {
            get
            {
                if (_goodsAcs == null) _goodsAcs = new GoodsAcs();
                return _goodsAcs;
            }
        }

        // 従業員アクセス
        private EmployeeAcs _employeeAcs;
        private EmployeeAcs GetEmployeeAcs
        {
            get
            {
                if (_employeeAcs == null) _employeeAcs = new EmployeeAcs();
                return _employeeAcs;
            }
        }

        // 拠点制御アクセス
        private SecInfoAcs _secInfoAcs;
        private SecInfoAcs GetSecInfoAcs
        {
            get
            {
                if (_secInfoAcs == null) _secInfoAcs = new SecInfoAcs();
                return _secInfoAcs;
            }
        }

        // ユーザーアクセス
        private UserGuideAcs _userGuideAcs;
        private UserGuideAcs GetUserGuideAcs
        {
            get
            {
                if (_userGuideAcs == null) _userGuideAcs = new UserGuideAcs();
                return _userGuideAcs;
            }
        }

        // 自社設定リモート
        IPccCmpnyStDB _iPccCmpnyStDB;
        private IPccCmpnyStDB GetIPccCmpnyStDB
        {
            get
            {
                if (_iPccCmpnyStDB == null) _iPccCmpnyStDB = MediationPccCmpnyStDB.GetPccCmpnyStDB();
                return _iPccCmpnyStDB;
            }
        }
        
        // 得意先情報 
        private CustomerInfo _customerInfo;
        // 前回検索得意先コード
        private int _customerCodeSave;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        private const int ctFracProcMoneyDiv_SalesUnitPrice = 2;// ADD 2013/07/24 qijh Redmine#39026

        // ADD 2013/08/01 三戸 Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private List<MakerUMnt> _makerUMntList = null;          // メーカーマスタリスト
        private SupplierAcs supplierAcs = new SupplierAcs();    // 仕入先
        // ADD 2013/08/01 三戸 Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private List<SCMAcOdrDtlAsWork> sCMAcOdrDtlAsWorkForAnsPureGoodsNo = new List<SCMAcOdrDtlAsWork>();
        // ADD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region Private Method
        /// <summary>
        /// PM現在庫数取得処理
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        /// <returns>PM現在庫数</returns>
        //private double GetPmPrsntCount(SalesSlipWork salesSlip, SalesDetailWork salesDetail) // DEL 2013/07/03 qijh Redmine#37586
        private double GetPmPrsntCount(SalesSlip salesSlip, SalesDetail salesDetail) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetPmPrsntCount";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            List<string> warehouseList = new List<string>();
            // 委託、優先倉庫の取得
            // 通信方式：BLP
            warehouseList = this.CreatePriorWarehouseListForPccuoe(this.GetCustomerInfo(salesSlip).CustomerEpCode, this.GetCustomerInfo(salesSlip).CustomerSecCode, salesSlip.EnterpriseCode, salesSlip.SectionCode);

            // 商品情報
            //GoodsUnitData goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail); // DEL 2013/07/23 wangl2 FOR Redmine#38976
            // --------------- ADD START 2013/07/23 wangl2 FOR Redmine#38976------>>>>
            GoodsUnitData goodsUnitData = null;
            if (salesDetail.SalesSlipCdDtl != 2)
            {
                goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail);
            }
            // --------------- ADD END 2013/07/23 wangl2 FOR Redmine#38976--------<<<<
            Stock retStock = null;
            if (goodsUnitData != null && goodsUnitData.StockList != null)
            {
                foreach (Stock stock in goodsUnitData.StockList)
                {
                    if (retStock == null)
                    {
                        for (int i = 0; i < warehouseList.Count; i++)
                        {
                            retStock = GetGoodsAcs.GetStockFromStockList(warehouseList[i], goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                            if (retStock != null) break;
                        }
                    }
                }
            }

            // タブレットログ対応　--------------------------------->>>>>
            if(retStock != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, 
                    "メーカーコード：" + goodsUnitData.GoodsMakerCd
                    + "　商品番号：" + goodsUnitData.GoodsNo
                    + "　倉庫コード：" + retStock.WarehouseCode
                    + "　在庫数：" + retStock.ShipmentCnt.ToString()
                    );
            }
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<

            if (retStock != null)
                return retStock.ShipmentPosCnt;
            else
                return 0.00d;
        }

        /// <summary>
        /// 売上データ補正処理
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="claim">得意先情報</param>
        //private void ReviseSalesSlip(SalesSlipWork salesSlip, CustomerInfo claim) // DEL 2013/07/03 qijh Redmine#37586
        private void ReviseSalesSlip(SalesSlip salesSlip, CustomerInfo claim) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "ReviseSalesSlip";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            #region 売上データ補正

            #region 部門コード補正
            // 従業員詳細取得
            EmployeeDtl employeeDetail = GetEmployeeDtl(salesSlip.EnterpriseCode, salesSlip.SalesEmployeeCd);
            if (employeeDetail != null)
            {
                salesSlip.SubSectionCode = employeeDetail.BelongSubSectionCode;
            }
            #endregion

            #region 請求計上拠点コード補正
            // 請求計上拠点コード
            string sectionCode;
            // 得意先情報
            CustomerInfo customerInfo = GetCustomerInfo(salesSlip);
            GetOwnSeCtrlCode(customerInfo.ClaimSectionCode, out sectionCode);
            salesSlip.DemandAddUpSecCd = sectionCode; // 請求計上拠点コード
            #endregion

            #region 実績計上拠点コード補正
            // 実績計上拠点コード
            salesSlip.ResultsAddUpSecCd = customerInfo.MngSectionCode;
            #endregion

            #region 計上日付補正、来勘区分補正
            SettingSalesSlipAddUpDate(ref salesSlip, claim);
            //// ADD 2013/08/01 三戸 Redmine#39549 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //if (salesSlip.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) salesSlip.AddUpADate = DateTime.MinValue;
            //// ADD 2013/08/01 三戸 Redmine#39549 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            #region 請求先略称補正
            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
            CustomerInfo claimInfo = null;
            string outErrorMessage = null;
            ConstantManagement.MethodResult methodResult = GetCustomerInfo(salesSlip.EnterpriseCode, salesSlip.ClaimCode, out claimInfo, out outErrorMessage);
            if (ConstantManagement.MethodResult.ctFNC_NORMAL == methodResult)
                salesSlip.ClaimSnm = claimInfo.CustomerSnm; // 請求先略称
            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<
            #endregion

            // 伝票印刷情報を設定
            SetSalesSlipPrintInfo(salesSlip, claim); // ADD 2013/07/18 qijh Redmine#38565

            #endregion
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<

        }

        /// <summary>
        /// 売上明細データ補正処理
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        //private void ReviseSalesDetail(SalesSlipWork salesSlip, SalesDetailWork salesDetail) // DEL 2013/07/03 qijh Redmine#37586
        private void ReviseSalesDetail(SalesSlip salesSlip, SalesDetail salesDetail) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "ReviseSalesDetail";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            #region 売上明細データ補正
            // メーカー
            //GoodsUnitData goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail); // DEL 2013/07/23 wangl2 FOR Redmine#38976
            // --------------- ADD START 2013/07/23 wangl2 FOR Redmine#38976------>>>>
            // DEL 2013/08/01 三戸 Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //GoodsUnitData goodsUnitData = null;
            //if(salesDetail.SalesSlipCdDtl != 2)
            //{
            //    goodsUnitData = GetGoodsUnitData(salesSlip, salesDetail);
            //}
            //// --------------- ADD END 2013/07/23 wangl2 FOR Redmine#38976--------<<<<
            //if (goodsUnitData != null)
            //{
            //    // メーカー名称
            //    salesDetail.MakerName = goodsUnitData.MakerName;
            //    // メーカー名称カナ
            //    salesDetail.MakerKanaName = goodsUnitData.MakerKanaName;
            //    // 仕入先略称
            //    salesDetail.SupplierSnm = goodsUnitData.SupplierSnm;
            //}
            // DEL 2013/08/01 三戸 Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/08/01 三戸 Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (salesDetail.GoodsMakerCd > 0)
            {
                // メーカー名称取得
                salesDetail.MakerName = GetName_FromMaker(salesDetail.GoodsMakerCd);
                // メーカー名称カナ
                salesDetail.MakerKanaName = GetKanaName_FromMaker(salesDetail.GoodsMakerCd);
            }
            if (salesDetail.SupplierCd > 0)
            {
                // 仕入先略称
                Supplier supplier = null;
                supplierAcs.Read(out supplier, salesDetail.EnterpriseCode, salesDetail.SupplierCd);
                if (supplier != null) salesDetail.SupplierSnm = supplier.SupplierSnm;
            }

            // ADD 2013/08/01 三戸 Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // BLコードマスタ
            BLGoodsCdUMnt bLGoodsCdUMnt;
            // グループコードマスタ
            BLGroupU bLGroupU;
            // 商品中分類マスタ
            GoodsGroupU goodsGroupU;
            // 商品大分類マスタ（ユーザーガイド）
            UserGdBdU userGdBdU;
            // BLコードに連結情報取得
            if (GetBLGoodsRelation(salesDetail.BLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU))
            {
                // 商品大分類コード
                salesDetail.GoodsLGroup = bLGroupU.GoodsLGroup;
                // 商品大分類名称
                salesDetail.GoodsLGroupName = GetGuideName(salesDetail.EnterpriseCode, 70, bLGroupU.GoodsLGroup);
                // 商品中分類名称
                salesDetail.GoodsMGroupName = goodsGroupU.GoodsMGroupName;
                // 商品中分類コード
                salesDetail.GoodsMGroup = bLGroupU.GoodsMGroup;

                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
                if (string.IsNullOrEmpty(salesDetail.GoodsMGroupName))
                {
                    GoodsGroupU goodsMGroup = null;
                    GetGoodsAcs.GetGoodsMGroup(salesSlip.EnterpriseCode, bLGoodsCdUMnt.GoodsRateGrpCode, out goodsMGroup);
                    salesDetail.GoodsMGroupName = goodsMGroup.GoodsMGroupName;
                    salesDetail.GoodsMGroup = bLGoodsCdUMnt.GoodsRateGrpCode;
                }
                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<

                // BLグループコード名称
                salesDetail.BLGroupName = bLGroupU.BLGroupName;
                // BL商品コード名称（掛率）
                //salesDetail.RateBLGoodsName = bLGoodsCdUMnt.BLGoodsFullName; // DEL 2013/07/19 qijh Redmine#38510
                salesDetail.RateBLGoodsName = bLGoodsCdUMnt.BLGoodsHalfName; // ADD 2013/07/19 qijh Redmine#38510
                // BLグループ名称（掛率）
                //salesDetail.RateGoodsRateGrpNm = bLGroupU.BLGroupName; // DEL 2013/07/04 songg Redmine#37832
                salesDetail.RateBLGroupName = bLGroupU.BLGroupName;// ADD 2013/07/04 songg Redmine#37832
                // BL商品コード名称（印刷）
                //salesDetail.PrtBLGoodsName = bLGoodsCdUMnt.BLGoodsFullName; // DEL 2013/07/18 qijh Redmine#38565
                salesDetail.PrtBLGoodsName = bLGoodsCdUMnt.BLGoodsHalfName; // ADD 2013/07/18 qijh Redmine#38565
                // 自社分類名称
                salesDetail.EnterpriseGanreName = GetEnterpriseGanreName(salesDetail.EnterpriseCode, 41, salesDetail.EnterpriseGanreCode);
                // 商品掛率グループ名称（掛率） 
                salesDetail.RateGoodsRateGrpNm = goodsGroupU.GoodsMGroupName;
                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
                if (string.IsNullOrEmpty(salesDetail.RateGoodsRateGrpNm))
                    salesDetail.RateGoodsRateGrpNm = salesDetail.GoodsMGroupName;
                // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<
            }
            // タブレットログ対応　--------------------------------->>>>>
            else
            {
                EasyLogger.Write(CLASS_NAME, methodName, "BLコード連結情報の取得に失敗しました　BLコード：" + salesDetail.BLGoodsCode);
            }

            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
            // 印刷用メーカーコード
            if (0 == salesDetail.PrtMakerCode)
                salesDetail.PrtMakerCode = salesDetail.GoodsMakerCd; // 0の場合は、商品メーカーコードを設定
            // 印刷用メーカー名称
            if (null == salesDetail.PrtMakerName || string.IsNullOrEmpty(salesDetail.PrtMakerName.Trim()))
                salesDetail.PrtMakerName = salesDetail.MakerName; // 設定されていない場合は、メーカー名称を設定
            // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<

            #endregion
        }

        // ADD 2013/08/01 三戸 Redmine#39486 --------->>>>>>>>>>>>>>>>>>>>>>>>
        #region ●メーカーマスタ
        private int InitMaker(string enterpriseCode)
        {
            List<MakerUMnt> makerList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = GetGoodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            return status;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        private string GetName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerName;
        }

        /// <summary>
        /// メーカー名称取得処理(半角カナ名称)
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        private string GetKanaName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerKanaName;
        }
        #endregion
        // ADD 2013/08/01 三戸 Redmine#39486 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 自社分類名称取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="userGuideDivCd">ユーザーガイド区分コード</param>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        private string GetEnterpriseGanreName(string enterpriseCode, int userGuideDivCd, int enterpriseGanreCode)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetEnterpriseGanreName";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            string enterpriseGanreName = "";
            ArrayList userGdBdList;
            List<UserGdBd> tmpList = new List<UserGdBd>();

            int status = GetUserGuideAcs.SearchDivCodeBody(out userGdBdList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tmpList = new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));

                UserGdBd findUserGdBd = tmpList.Find(delegate(UserGdBd userGdBd)
                {
                    if (userGdBd.GuideCode == enterpriseGanreCode) return true;
                    else return false;
                });

                if(findUserGdBd != null)
                {
                    enterpriseGanreName = findUserGdBd.GuideName;
                }
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<

            return enterpriseGanreName;
        }

        /// <summary>
        /// 商品大分類名称取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="userGuideDivCd">ユーザーガイド区分コード</param>
        /// <param name="goodsLGroup">商品大分類コード</param>
        private string GetGuideName(string enterpriseCode, int userGuideDivCd, int goodsLGroup)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetGuideName";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            string guideName = "";
            ArrayList userGdBdList;
            List<UserGdBd> tmpList = new List<UserGdBd>();

            int status = GetUserGuideAcs.SearchDivCodeBody(out userGdBdList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tmpList = new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));

                UserGdBd findUserGdBd = tmpList.Find(delegate(UserGdBd userGdBd)
                {
                    if (userGdBd.GuideCode == goodsLGroup) return true;
                    else return false;
                });

                if (findUserGdBd != null)
                {
                    guideName = findUserGdBd.GuideName;
                }
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return guideName;
        }

        /// <summary>
        /// BLコードに連結するBLコードマスタ情報、BLグループコード情報、商品中分類情報、商品大分類情報を取得します。
        /// </summary>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        /// <param name="bLGroupU">グループコードマスタ</param>
        /// <param name="goodsGroupU">商品中分類マスタ</param>
        /// <param name="userGdBdU">商品大分類マスタ（ユーザーガイド）</param>
        /// <returns>True:取得成功</returns>
        private bool GetBLGoodsRelation(int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetBLGoodsRelation";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            EasyLogger.Write(CLASS_NAME, methodName, "BLコードマスタ、グループコードマスタ、商品中分類マスタ、商品大分類マスタ（ユーザーガイド） 検索条件"
                + "　BLコード：" + bLGoodsCode.ToString()
                );
            // タブレットログ対応　---------------------------------<<<<<

            GetGoodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return !((bLGoodsCdUMnt.BLGoodsCode == 0) && (string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName)));
        }

        /// <summary>
        /// 計上日を設定します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="claim">得意先情報</param>
        //private void SettingSalesSlipAddUpDate(ref SalesSlipWork salesSlip, CustomerInfo claim) // DEL 2013/07/03 qijh Redmine#37586
        private void SettingSalesSlipAddUpDate(ref SalesSlip salesSlip, CustomerInfo claim) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SettingSalesSlipAddUpDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            DateTime addUpDate;
            int delayPaymentDiv;
            CalcAddUpDate(salesSlip.SalesDate, claim.TotalDay, claim.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

            salesSlip.AddUpADate = addUpDate;
            salesSlip.DelayPaymentDiv = delayPaymentDiv;

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// 指定日付の次回以降の締日を算出します。
        /// </summary>
        /// <param name="loopCnt">0:当月,1:翌月,2:翌々月...</param>
        /// <param name="targetdate">対象日</param>
        /// <param name="totalDay">締日</param>
        /// <returns>対象月の実際の締日</returns>
        private DateTime GetNextTotalDate(int loopCnt, DateTime targetdate, int totalDay)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetNextTotalDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            DateTime retDate = targetdate;

            // 対象月の実際の締日を取得
            int totalDayR = GetRealTotalDay(retDate, totalDay);

            // 対象日が実際の締日より大きい場合は1ヵ月加算
            if (targetdate.Day > totalDayR)
            {
                retDate = retDate.AddMonths(1);

                totalDayR = GetRealTotalDay(retDate, totalDay);
            }
            retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return (loopCnt == 0) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
        }

        /// <summary>
        /// 対象年月日、締日から、実際に締対象となる日付を算出します。
        /// </summary>
        /// <param name="targetDate">対象年月日</param>
        /// <param name="totalDay">設定上の締日</param>
        /// <returns>対象月の実際の締日</returns>
        private int GetRealTotalDay(DateTime targetDate, int totalDay)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetRealTotalDay";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            int retValue = totalDay;
            // 対象月の末日取得
            int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

            if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return retValue;
        }

        /// <summary>
        /// 計上日計算処理
        /// </summary>
        /// <param name="targetDate">対象日</param>
        /// <param name="totalDay">締日</param>
        /// <param name="nTimeCalcStDate">来月勘定開始日</param>
        /// <param name="addUpADate">計上日(算出結果)</param>
        /// <param name="delayPaymentDiv">来勘区分(算出	結果)</param>
        private void CalcAddUpDate(DateTime targetDate, int totalDay, int nTimeCalcStDate, out DateTime addUpADate, out int delayPaymentDiv)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "CalcAddUpDate";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // 基本的に対象日が計上日で当月請求
            addUpADate = targetDate;
            delayPaymentDiv = 0;

            // 締日、来月勘定開始日が設定されていない場合はそのまま終了
            // タブレットログ対応　--------------------------------->>>>>
            //if ((totalDay == 0) || (nTimeCalcStDate == 0))
            if ((totalDay == 0) || (nTimeCalcStDate == 0))
            {
                EasyLogger.Write(CLASS_NAME, methodName, "締日、来月勘定開始日 未設定");
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return;
            }
            // タブレットログ対応　---------------------------------<<<<<

            DateTime thisTimeAddUpDate = GetNextTotalDate(0, targetDate, totalDay);
            // 来月請求の場合は、今回請求日の翌日が計上日
            DateTime nextTimeAddUpDate = thisTimeAddUpDate.AddDays(1);


            // 来月勘定開始日 ≦ 締日
            if (nTimeCalcStDate <= totalDay)
            {
                // 対象日の日付が来月勘定開始日～締日の場合に来月勘定
                if ((nTimeCalcStDate <= targetDate.Day) && (targetDate.Day <= totalDay))
                {
                    addUpADate = nextTimeAddUpDate;
                    delayPaymentDiv = 1;
                }
            }
            // 来月勘定開始日 ＞ 締日
            else
            {
                // 対象日の日付が1日～締日、来月勘定開始日～末日の場合に来月勘定
                if ((1 <= targetDate.Day) && (targetDate.Day <= totalDay) ||
                    (nTimeCalcStDate <= targetDate.Day))
                {
                    addUpADate = nextTimeAddUpDate;
                    delayPaymentDiv = 1;
                }
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// 制御機能拠点取得処理
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="ctrlSectionCode">対象制御拠点コード</param>
        private void GetOwnSeCtrlCode(string sectionCode, out string ctrlSectionCode)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetOwnSeCtrlCode";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            EasyLogger.Write(CLASS_NAME, methodName, "制御機能拠点　検索条件　拠点コード：" + sectionCode);
            // タブレットログ対応　---------------------------------<<<<<

            SecInfoSet secInfoSet;
            ctrlSectionCode = null;
            int status = GetSecInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (secInfoSet != null)
                {
                    ctrlSectionCode = secInfoSet.SectionCode;
                }
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // タブレットログ対応　---------------------------------<<<<<
        }

        /// <summary>
        /// 従業員検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>該当する従業員</returns>
        private EmployeeDtl GetEmployeeDtl(string enterpriseCode, string employeeCode)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetEmployeeDtl";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            EasyLogger.Write(CLASS_NAME, methodName, "従業員検索処理 検索条件"
                + "　企業コード：" + enterpriseCode
                + "　従業員コード：" + employeeCode
                );
            // タブレットログ対応　---------------------------------<<<<<

            Employee foundEmployee = null;
            EmployeeDtl foundEmployeeDetail = null;
            // 従業員情報取得
            int status = GetEmployeeAcs.Read(out foundEmployee, out foundEmployeeDetail, enterpriseCode, employeeCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // タブレットログ対応　--------------------------------->>>>>

                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // タブレットログ対応　---------------------------------<<<<<
                return foundEmployeeDetail;
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // タブレットログ対応　---------------------------------<<<<<
            return null;
        }

        /// <summary>
        /// 得意先情報の取得
        /// </summary>
        /// <param name="saleSlip">売上情報</param>
        /// <returns>得意先情報</returns>
        //private CustomerInfo GetCustomerInfo(SalesSlipWork saleSlip) // DEL 2013/07/03 qijh Redmine#37586
        private CustomerInfo GetCustomerInfo(SalesSlip saleSlip) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetCustomerInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            // 初回、または得意先が変更された場合
            if (this._customerInfo == null || this._customerCodeSave != saleSlip.CustomerCode)
            {
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "得意先情報　検索条件"
                    + "企業コード：" + saleSlip.EnterpriseCode
                    + "得意先コード：" + saleSlip.CustomerCode.ToString()
                    );
                // タブレットログ対応　---------------------------------<<<<<
                this._customerInfoAcs.ReadDBData(saleSlip.EnterpriseCode, saleSlip.CustomerCode, out this._customerInfo);
            }
            this._customerCodeSave = saleSlip.CustomerCode;
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return _customerInfo;
        }

        /// <summary>
        /// 商品情報の取得
        /// </summary>
        /// <param name="salesSlip">売上情報</param>
        /// <param name="salesDetail">売上明細情報</param>
        /// <returns>商品情報</returns>
        //private GoodsUnitData GetGoodsUnitData(SalesSlipWork salesSlip, SalesDetailWork salesDetail) // DEL 2013/07/03 qijh Redmine#37586
        private GoodsUnitData GetGoodsUnitData(SalesSlip salesSlip, SalesDetail salesDetail) // ADD 2013/07/03 qijh Redmine#37586
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "GetGoodsUnitData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            EasyLogger.Write(CLASS_NAME, methodName, "商品情報　検索条件"
                + "　企業コード：" + salesSlip.EnterpriseCode
                + "　拠点コード：" + salesSlip.SectionCode
                + "　メーカーコード：" + salesDetail.GoodsMakerCd
                + "　商品番号：" + salesDetail.GoodsNo
            );
            // タブレットログ対応　---------------------------------<<<<<

            // 商品情報
            GoodsUnitData goodsUnitData;
            // 在庫情報取得
            GetGoodsAcs.Read(salesSlip.EnterpriseCode, salesSlip.SectionCode, salesDetail.GoodsMakerCd, salesDetail.GoodsNo, ConstantManagement.LogicalMode.GetData0, out goodsUnitData);

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return goodsUnitData;
        }

        /// <summary>
        /// 自社設定マスタデータを取得する
        /// </summary>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <returns>自社設定マスタ</returns>
        private PccCmpnyStWork SearchPccCmpnyStList(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SearchPccCmpnyStList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            EasyLogger.Write(CLASS_NAME, methodName, "自社設定マスタ　検索条件"
                + "問合せ元企業コード：" + inqOriginalEpCd
                + "問合せ元拠点コード：" + inqOriginalSecCd
                + "問合せ先企業コード：" + inqOtherEpCd
                + "問合せ先拠点コード：" + inqOtherSecCd
                );
            // タブレットログ対応　---------------------------------<<<<<

            object pccCmpnyStObj = null;
            // 検索パラメータ
            PccCmpnyStWork parsePccCmpnyStWork = new PccCmpnyStWork();
            // 問合せ元企業コード
            parsePccCmpnyStWork.InqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            // 問合せ元拠点コード
            parsePccCmpnyStWork.InqOriginalSecCd = inqOriginalSecCd;
            // 問合せ先企業コード
            parsePccCmpnyStWork.InqOtherEpCd = inqOtherEpCd;
            // 問合せ先拠点コード
            parsePccCmpnyStWork.InqOtherSecCd = inqOtherSecCd;
            // 検索区分(現在未使用)
            int readMode = 0;
            // 論理削除有無
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            int status = GetIPccCmpnyStDB.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode);

            if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
                // タブレットログ対応　---------------------------------<<<<<
                return (PccCmpnyStWork)((ArrayList)pccCmpnyStObj)[0];
            }

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status："+ status.ToString());
            // タブレットログ対応　---------------------------------<<<<<
            return null;
        }

        /// <summary>
        /// 優先倉庫リスト(PCC自社設定マスタの優先倉庫)を生成します。
        /// </summary>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <returns>優先倉庫リスト</returns>
        private List<string> CreatePriorWarehouseListForPccuoe(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "CreatePriorWarehouseListForPccuoe";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<

            PccCmpnyStWork pccCmpnySt = SearchPccCmpnyStList(inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd);//@@@@20230303

            List<string> sectWarehouseCdList = new List<string>();
            if (pccCmpnySt != null)
            {
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccWarehouseCd) ? "" : pccCmpnySt.PccWarehouseCd.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd1) ? "" : pccCmpnySt.PccPriWarehouseCd1.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd2) ? "" : pccCmpnySt.PccPriWarehouseCd2.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd3) ? "" : pccCmpnySt.PccPriWarehouseCd3.Trim());
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return sectWarehouseCdList;
        }

        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- >>>>>
        /// <summary>
        /// 印刷用品番を設定
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="pmTabSalesDetail">PMTAB売上明細データ</param>
        private void SetPrtGoodsNo(SalesDetail salesDetail, PmTabSaleDetailWork pmTabSalesDetail)
        {
            // UPD 2013/08/16 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// 対象の明細が、 優良メーカー(GoodsMakerCd ≧ 1000) かつ 
            //if (salesDetail.GoodsMakerCd < 1000)
            //    return; // 対象外
            //PmtSalDtlSupTmpWork pmtSalDtlSupTmpWork = null;
            //if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != GetPmtSalDtlSupTmp(pmTabSalesDetail, out pmtSalDtlSupTmpWork) || null == pmtSalDtlSupTmpWork)
            //{
            //    // 対象の売上行番号(SalesRowNoRF)のデータが取得できない場合（通常は有り得ない）は、売上明細データ(PmTabSaleDetailRF)．商品番号(GoodsNoRF)を設定する
            //    salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;
            //    return;
            //}
            #endregion
            // 対象の明細が、 優良メーカー(GoodsMakerCd ≧ 1000) または、BL検索の場合にPmtSalDtlSupTmpWorkを取得する
            if (salesDetail.GoodsMakerCd < 1000 && !salesDetail.GoodsSearchDivCd.Equals(0)) return; // 対象外

            // PMTAB売上明細補足セッション管理トランザクションデータ の取得
            PmtSalDtlSupTmpWork pmtSalDtlSupTmpWork = null;
            int status = GetPmtSalDtlSupTmp(pmTabSalesDetail, out pmtSalDtlSupTmpWork);
            
            // BLコード検索または品番検索で優良メーカーの場合は、純正品番を回答純正商品番号に保持
            // UPD 2013/08/30 吉岡 Redmine#39979 ------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // if (salesDetail.GoodsSearchDivCd.Equals(0))
            if (salesDetail.GoodsSearchDivCd.Equals(0)
                || salesDetail.GoodsSearchDivCd.Equals(1) && salesDetail.GoodsMakerCd >= 1000
                )
            // UPD 2013/08/30 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                SCMAcOdrDtlAsWork wk = new SCMAcOdrDtlAsWork();
                wk.SalesRowNo = salesDetail.SalesRowNo;
                wk.AnsPureGoodsNo = pmtSalDtlSupTmpWork.PmTabPurePartsNo;
                wk.BLGoodsCode = pmtSalDtlSupTmpWork.BLGoodsCode;

                sCMAcOdrDtlAsWorkForAnsPureGoodsNo.Add(wk);
            }

            // 以降の処理は優良メーカーの場合のみ実施
            if (salesDetail.GoodsMakerCd < 1000)  return; 

            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == pmtSalDtlSupTmpWork)
            {
                // 対象の売上行番号(SalesRowNoRF)のデータが取得できない場合（通常は有り得ない）は、売上明細データ(PmTabSaleDetailRF)．商品番号(GoodsNoRF)を設定する
                salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;
                return;
            }
            // UPD 2013/08/16 吉岡 Redmine#39979 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            

            // PMTAB売上明細補足セッション管理トランザクションデータ(PmtSalDtlSupTmpRF)．価格選択区分(PriceSelectDivRF)＝0:純正 の場合、
            if (pmtSalDtlSupTmpWork.PriceSelectDiv != 0)
                return; // 対象外

            // 印刷用品番を設定
            switch (this.PmTabTtlStSec.LiPriSelPrtGdsNoDiv)
            {
                case 0:
                    {
                        // 標準価格選択印刷用品番設定区分＝0:優良品番を印字　の場合
                        // 売上明細データ(PmTabSaleDetailRF)．商品番号(GoodsNoRF)を設定する
                        salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;
                        break;
                    }
                case 1:
                    {
                        // 標準価格選択印刷用品番設定区分＝1:品番印字なしの場合
                        // (空文字)を設定する
                        salesDetail.PrtGoodsNo = string.Empty;
                        break;
                    }
                case 2:
                    {
                        // 標準価格選択印刷用品番設定区分＝2:売上全体設定の自社品番印字区分に従う(印字区分：しない　の場合は優良品番印字)　の場合
                        if (SalesTtlSt.EpPartsNoPrtCd == 0)
                            // 売上全体設定マスタ.自社品番印字区分(EpPartsNoPrtCdRF)＝0：しない　の場合
                            // PMTAB売上明細データ(PmTabSaleDetailRF)．商品番号(GoodsNoRF)を設定する
                            salesDetail.PrtGoodsNo = pmTabSalesDetail.GoodsNo;

                        else if (SalesTtlSt.EpPartsNoPrtCd == 1)
                            // 売上全体設定マスタ.自社品番印字区分(EpPartsNoPrtCdRF)＝1：する　の場合
                            // PMTAB売上明細補足セッション管理トランザクションデータ.純正品番(PmTabPurePartsNoRF) ＋ 売上全体設定マスタ.自社品番付加文字(EpPartsNoAddCharRF)
                            salesDetail.PrtGoodsNo = pmtSalDtlSupTmpWork.PmTabPurePartsNo + SalesTtlSt.EpPartsNoAddChar;
                        
                        break;
                    }
                case 3:
                    {
                        // 標準価格選択印刷用品番設定区分＝3:売上全体設定の自社品番印字区分に従う(印字区分：しない　の場合は品番印字なし)　の場合
                        if (SalesTtlSt.EpPartsNoPrtCd == 0)
                            // 売上全体設定マスタ.自社品番印字区分(EpPartsNoPrtCdRF)＝0：しない　の場合
                            // (空文字)を設定する
                            salesDetail.PrtGoodsNo = string.Empty;

                        else if (SalesTtlSt.EpPartsNoPrtCd == 1)
                            // 売上全体設定マスタ.自社品番印字区分(EpPartsNoPrtCdRF)＝1：する　の場合
                            // PMTAB売上明細補足セッション管理トランザクションデータ.純正品番(PmTabPurePartsNoRF) ＋ 売上全体設定マスタ.自社品番付加文字(EpPartsNoAddCharRF)
                            salesDetail.PrtGoodsNo = pmtSalDtlSupTmpWork.PmTabPurePartsNo + SalesTtlSt.EpPartsNoAddChar;

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// PMTAB売上明細補足セッション管理トランザクションデータを取得
        /// </summary>
        /// <param name="pmTabSalesDetail">PMTAB売上明細データ</param>
        /// <param name="pmtSalDtlSupTmpWork">PMTAB売上明細補足セッション管理トランザクションデータ</param>
        /// <returns>ステータス</returns>
        private int GetPmtSalDtlSupTmp(PmTabSaleDetailWork pmTabSalesDetail, out PmtSalDtlSupTmpWork pmtSalDtlSupTmpWork)
        {
            pmtSalDtlSupTmpWork = null;
            // 検索パラメータ
            PmtSalDtlSupTmpWork paramPmtSalDtlSupTmp = new PmtSalDtlSupTmpWork();
            paramPmtSalDtlSupTmp.EnterpriseCode = pmTabSalesDetail.EnterpriseCode;
            paramPmtSalDtlSupTmp.SearchSectionCode = pmTabSalesDetail.SearchSectionCode;
            paramPmtSalDtlSupTmp.BusinessSessionId = pmTabSalesDetail.BusinessSessionId;
            CustomSerializeArrayList searchParamList = new CustomSerializeArrayList();
            searchParamList.Add(paramPmtSalDtlSupTmp);

            // PMTAB売上明細補足セッション管理トランザクションデータを取得
            object searchResultListObj;
            int status = this.IPmtPartsSearchDB.Search(searchParamList, out searchResultListObj);
            CustomSerializeArrayList searchResultList = searchResultListObj as CustomSerializeArrayList;

            // 検索結果チェック
            if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status || null == searchResultList || searchResultList.Count == 0)
                return status;
            ArrayList searchResultAryList = searchResultList[0] as ArrayList;
            if (null == searchResultAryList || searchResultAryList.Count == 0)
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 売上行番号でフィルタ
            List<PmtSalDtlSupTmpWork> resultList = new List<PmtSalDtlSupTmpWork>((PmtSalDtlSupTmpWork[])searchResultAryList.ToArray(typeof(PmtSalDtlSupTmpWork)));
            pmtSalDtlSupTmpWork = resultList.Find(
                delegate(PmtSalDtlSupTmpWork pmtSalDtlSupTmp)
                {
                    if (pmtSalDtlSupTmp.SalesRowNo == pmTabSalesDetail.SalesRowNo)
                        return true;
                    return false;
                }
            );

            // 結果を戻す
            if (null == pmtSalDtlSupTmpWork)
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return status;
        }
        // -------------- ADD 2013/07/12 qijh Redmine#38166 ----------- <<<<<

        // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- >>>>>
        /// <summary>
        /// 伝票印刷情報を設定
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="customer">得意先情報</param>
        private void SetSalesSlipPrintInfo(SalesSlip salesSlip, CustomerInfo customer)
        {
            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlip.AcptAnOdrStatus)
            {
                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                    switch (customer.AcpOdrrSlipPrtDiv)
                    {
                        // 0:標準 ← 受注全体設定
                        default:
                        case 0:
                            salesSlip.SlipPrintDivCd = this.AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv;
                            break;
                        // 1:未使用 ← 0:しない
                        case 1:
                            salesSlip.SlipPrintDivCd = 0;
                            break;
                        // 2:使用 ← 1:する
                        case 2:
                            salesSlip.SlipPrintDivCd = 1;
                            break;
                    }
                    break;
                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                    switch (customer.SalesSlipPrtDiv)
                    {
                        // 0:標準 ← 売上全体設定
                        default:
                        case 0:
                            salesSlip.SlipPrintDivCd = this.SalesTtlSt.SalesSlipPrtDiv + 1 % 2;
                            break;
                        // 1:未使用 ← 0:しない
                        case 1:
                            salesSlip.SlipPrintDivCd = 0;
                            break;
                        // 2:使用 ← 1:する
                        case 2:
                            salesSlip.SlipPrintDivCd = 1;
                            break;
                    }
                    break;
                default:
                    break;
            }
            salesSlip.SlipPrtSetPaperId = this.GetSlipPrtSetPaperId(salesSlip); // 伝票印刷設定用帳票ＩＤ
            salesSlip.SlipPrintFinishCd = salesSlip.SlipPrintDivCd; // 伝票発行済区分
            salesSlip.SalesSlipPrintDate = (salesSlip.SlipPrintDivCd == (int)SalesSlipInputAcs.SlipPrintDivCd.Print) ? DateTime.Today : DateTime.MinValue; // 売上伝票発行日
        }

        /// <summary>
        /// 伝票印刷設定用帳票ＩＤ取得処理
        /// </summary>
        /// <param name="slipInfo">売上データ</param>
        /// <returns>伝票印刷設定用帳票ＩＤ</returns>
        private string GetSlipPrtSetPaperId(SalesSlip slipInfo)
        {
            string slipPrtSetPaperId = string.Empty;

            SlipPrtSet slipPrtSet = new SlipPrtSet();
            switch ((AcptAnOdrStatusState)slipInfo.AcptAnOdrStatus)
            {
                case AcptAnOdrStatusState.AcceptAnOrder:
                case AcptAnOdrStatusState.Sales:
                    slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, slipInfo);
                    break;
            }
            if (slipPrtSet != null) slipPrtSetPaperId = slipPrtSet.SlipPrtSetPaperId;
            return slipPrtSetPaperId;
        }
        // ------------- ADD 2013/07/18 qijh Redmine#38565 ---------- <<<<<
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- >>>>>
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private int ReadInitDataNinth(string enterpriseCode, string sectionCode, out List<SalesProcMoney> salesProcMoneyList)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●売上金額処理区分設定マスタ
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = false;
            status = salesProcMoneyAcs.Search(out aList, enterpriseCode);
            salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
            #endregion

            return 0;
        }

        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this.SalesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        // -------------- ADD 2013/07/24 qijh Redmine#39026 ----------- <<<<<
        #endregion

        #region Public Method
        // ----------------- ADD 2013/07/03 qijh Redmine#37586 --------------- >>>>>
        #region <リモート用ワークデータ>
        #region <売上データワーク>

        /// <summary>
        /// リモート用売上データを生成します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <returns>リモート用売上データ</returns>
        public static SalesSlipWork CreateSalesSlipWork(SalesSlip salesSlip)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();
            {
                salesSlipWork.CreateDateTime = salesSlip.CreateDateTime; // 作成日時
                salesSlipWork.UpdateDateTime = salesSlip.UpdateDateTime; // 更新日時
                salesSlipWork.EnterpriseCode = salesSlip.EnterpriseCode; // 企業コード
                salesSlipWork.FileHeaderGuid = salesSlip.FileHeaderGuid; // GUID
                salesSlipWork.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // 更新従業員コード
                salesSlipWork.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // 更新アセンブリID1
                salesSlipWork.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // 更新アセンブリID2
                salesSlipWork.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // 論理削除区分
                salesSlipWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // 受注ステータス
                salesSlipWork.SalesSlipNum = salesSlip.SalesSlipNum; // 売上伝票番号
                salesSlipWork.SectionCode = salesSlip.SectionCode; // 拠点コード
                salesSlipWork.SubSectionCode = salesSlip.SubSectionCode; // 部門コード
                salesSlipWork.DebitNoteDiv = salesSlip.DebitNoteDiv; // 赤伝区分
                salesSlipWork.DebitNLnkSalesSlNum = salesSlip.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
                salesSlipWork.SalesSlipCd = salesSlip.SalesSlipCd; // 売上伝票区分
                salesSlipWork.SalesGoodsCd = salesSlip.SalesGoodsCd; // 売上商品区分
                salesSlipWork.AccRecDivCd = salesSlip.AccRecDivCd; // 売掛区分
                salesSlipWork.SalesInpSecCd = salesSlip.SalesInpSecCd; // 売上入力拠点コード
                salesSlipWork.DemandAddUpSecCd = salesSlip.DemandAddUpSecCd; // 請求計上拠点コード
                salesSlipWork.ResultsAddUpSecCd = salesSlip.ResultsAddUpSecCd; // 実績計上拠点コード
                salesSlipWork.UpdateSecCd = salesSlip.UpdateSecCd; // 更新拠点コード
                salesSlipWork.SalesSlipUpdateCd = salesSlip.SalesSlipUpdateCd; // 売上伝票更新区分
                salesSlipWork.SearchSlipDate = salesSlip.SearchSlipDate; // 伝票検索日付
                salesSlipWork.ShipmentDay = salesSlip.ShipmentDay; // 出荷日付
                salesSlipWork.SalesDate = salesSlip.SalesDate; // 売上日付
                salesSlipWork.AddUpADate = salesSlip.AddUpADate; // 計上日付
                // ADD 2013/08/02 三戸 Redmine#39549 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (salesSlipWork.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) salesSlipWork.AddUpADate = DateTime.MinValue;
                // ADD 2013/08/02 三戸 Redmine#39549 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                salesSlipWork.DelayPaymentDiv = salesSlip.DelayPaymentDiv; // 来勘区分
                salesSlipWork.EstimateFormNo = salesSlip.EstimateFormNo; // 見積書番号
                salesSlipWork.EstimateDivide = salesSlip.EstimateDivide; // 見積区分
                salesSlipWork.InputAgenCd = salesSlip.InputAgenCd; // 入力担当者コード
                salesSlipWork.InputAgenNm = salesSlip.InputAgenNm; // 入力担当者名称
                salesSlipWork.SalesInputCode = salesSlip.SalesInputCode; // 売上入力者コード
                salesSlipWork.SalesInputName = salesSlip.SalesInputName; // 売上入力者名称
                salesSlipWork.FrontEmployeeCd = salesSlip.FrontEmployeeCd; // 受付従業員コード
                salesSlipWork.FrontEmployeeNm = salesSlip.FrontEmployeeNm; // 受付従業員名称
                salesSlipWork.SalesEmployeeCd = salesSlip.SalesEmployeeCd; // 販売従業員コード
                salesSlipWork.SalesEmployeeNm = salesSlip.SalesEmployeeNm; // 販売従業員名称
                salesSlipWork.TotalAmountDispWayCd = salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                salesSlipWork.TtlAmntDispRateApy = salesSlip.TtlAmntDispRateApy; // 総額表示掛率適用区分
                salesSlipWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // 売上伝票合計（税込み）
                salesSlipWork.SalesTotalTaxExc = salesSlip.SalesTotalTaxExc; // 売上伝票合計（税抜き）
                salesSlipWork.SalesPrtTotalTaxInc = salesSlip.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
                salesSlipWork.SalesPrtTotalTaxExc = salesSlip.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
                salesSlipWork.SalesWorkTotalTaxInc = salesSlip.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
                salesSlipWork.SalesWorkTotalTaxExc = salesSlip.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
                salesSlipWork.SalesSubtotalTaxInc = salesSlip.SalesSubtotalTaxInc; // 売上小計（税込み）
                salesSlipWork.SalesSubtotalTaxExc = salesSlip.SalesSubtotalTaxExc; // 売上小計（税抜き）
                salesSlipWork.SalesPrtSubttlInc = salesSlip.SalesPrtSubttlInc; // 売上部品小計（税込み）
                salesSlipWork.SalesPrtSubttlExc = salesSlip.SalesPrtSubttlExc; // 売上部品小計（税抜き）
                salesSlipWork.SalesWorkSubttlInc = salesSlip.SalesWorkSubttlInc; // 売上作業小計（税込み）
                salesSlipWork.SalesWorkSubttlExc = salesSlip.SalesWorkSubttlExc; // 売上作業小計（税抜き）
                salesSlipWork.SalesNetPrice = salesSlip.SalesNetPrice; // 売上正価金額
                salesSlipWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // 売上小計（税）
                salesSlipWork.ItdedSalesOutTax = salesSlip.ItdedSalesOutTax; // 売上外税対象額
                salesSlipWork.ItdedSalesInTax = salesSlip.ItdedSalesInTax; // 売上内税対象額
                salesSlipWork.SalSubttlSubToTaxFre = salesSlip.SalSubttlSubToTaxFre; // 売上小計非課税対象額
                salesSlipWork.SalesOutTax = salesSlip.SalesOutTax; // 売上金額消費税額（外税）
                salesSlipWork.SalAmntConsTaxInclu = salesSlip.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
                salesSlipWork.SalesDisTtlTaxExc = salesSlip.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
                salesSlipWork.ItdedSalesDisOutTax = salesSlip.ItdedSalesDisOutTax; // 売上値引外税対象額合計
                salesSlipWork.ItdedSalesDisInTax = salesSlip.ItdedSalesDisInTax; // 売上値引内税対象額合計
                salesSlipWork.ItdedPartsDisOutTax = salesSlip.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
                salesSlipWork.ItdedPartsDisInTax = salesSlip.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
                salesSlipWork.ItdedWorkDisOutTax = salesSlip.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
                salesSlipWork.ItdedWorkDisInTax = salesSlip.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
                salesSlipWork.ItdedSalesDisTaxFre = salesSlip.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
                salesSlipWork.SalesDisOutTax = salesSlip.SalesDisOutTax; // 売上値引消費税額（外税）
                salesSlipWork.SalesDisTtlTaxInclu = salesSlip.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
                salesSlipWork.PartsDiscountRate = salesSlip.PartsDiscountRate; // 部品値引率
                salesSlipWork.RavorDiscountRate = salesSlip.RavorDiscountRate; // 工賃値引率
                salesSlipWork.TotalCost = salesSlip.TotalCost; // 原価金額計
                salesSlipWork.ConsTaxLayMethod = salesSlip.ConsTaxLayMethod; // 消費税転嫁方式
                salesSlipWork.ConsTaxRate = salesSlip.ConsTaxRate; // 消費税税率
                salesSlipWork.FractionProcCd = salesSlip.FractionProcCd; // 端数処理区分
                salesSlipWork.AccRecConsTax = salesSlip.AccRecConsTax; // 売掛消費税
                salesSlipWork.AutoDepositCd = salesSlip.AutoDepositCd; // 自動入金区分
                salesSlipWork.AutoDepositSlipNo = salesSlip.AutoDepositSlipNo; // 自動入金伝票番号
                salesSlipWork.DepositAllowanceTtl = salesSlip.DepositAllowanceTtl; // 入金引当合計額
                salesSlipWork.DepositAlwcBlnce = salesSlip.DepositAlwcBlnce; // 入金引当残高
                salesSlipWork.ClaimCode = salesSlip.ClaimCode; // 請求先コード
                salesSlipWork.ClaimSnm = salesSlip.ClaimSnm; // 請求先略称
                salesSlipWork.CustomerCode = salesSlip.CustomerCode; // 得意先コード
                salesSlipWork.CustomerName = salesSlip.CustomerName; // 得意先名称
                salesSlipWork.CustomerName2 = salesSlip.CustomerName2; // 得意先名称2
                salesSlipWork.CustomerSnm = salesSlip.CustomerSnm; // 得意先略称
                salesSlipWork.HonorificTitle = salesSlip.HonorificTitle; // 敬称
                salesSlipWork.OutputNameCode = salesSlip.OutputNameCode; // 諸口コード
                salesSlipWork.OutputName = salesSlip.OutputName; // 諸口名称
                salesSlipWork.CustSlipNo = salesSlip.CustSlipNo; // 得意先伝票番号
                salesSlipWork.SlipAddressDiv = salesSlip.SlipAddressDiv; // 伝票住所区分
                salesSlipWork.AddresseeCode = salesSlip.AddresseeCode; // 納品先コード
                salesSlipWork.AddresseeName = salesSlip.AddresseeName; // 納品先名称
                salesSlipWork.AddresseeName2 = salesSlip.AddresseeName2; // 納品先名称2
                salesSlipWork.AddresseePostNo = salesSlip.AddresseePostNo; // 納品先郵便番号
                salesSlipWork.AddresseeAddr1 = salesSlip.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
                salesSlipWork.AddresseeAddr3 = salesSlip.AddresseeAddr3; // 納品先住所3(番地)
                salesSlipWork.AddresseeAddr4 = salesSlip.AddresseeAddr4; // 納品先住所4(アパート名称)
                salesSlipWork.AddresseeTelNo = salesSlip.AddresseeTelNo; // 納品先電話番号
                salesSlipWork.AddresseeFaxNo = salesSlip.AddresseeFaxNo; // 納品先FAX番号
                salesSlipWork.PartySaleSlipNum = salesSlip.PartySaleSlipNum; // 相手先伝票番号
                salesSlipWork.SlipNote = salesSlip.SlipNote; // 伝票備考
                salesSlipWork.SlipNote2 = salesSlip.SlipNote2; // 伝票備考２
                salesSlipWork.SlipNote3 = salesSlip.SlipNote3; // 伝票備考３
                salesSlipWork.RetGoodsReasonDiv = salesSlip.RetGoodsReasonDiv; // 返品理由コード
                salesSlipWork.RetGoodsReason = salesSlip.RetGoodsReason; // 返品理由
                salesSlipWork.RegiProcDate = salesSlip.RegiProcDate; // レジ処理日
                salesSlipWork.CashRegisterNo = salesSlip.CashRegisterNo; // レジ番号
                salesSlipWork.PosReceiptNo = salesSlip.PosReceiptNo; // POSレシート番号
                salesSlipWork.DetailRowCount = salesSlip.DetailRowCount; // 明細行数
                salesSlipWork.EdiSendDate = salesSlip.EdiSendDate; // ＥＤＩ送信日
                salesSlipWork.EdiTakeInDate = salesSlip.EdiTakeInDate; // ＥＤＩ取込日
                salesSlipWork.UoeRemark1 = salesSlip.UoeRemark1; // ＵＯＥリマーク１
                salesSlipWork.UoeRemark2 = salesSlip.UoeRemark2; // ＵＯＥリマーク２
                salesSlipWork.SlipPrintDivCd = salesSlip.SlipPrintDivCd; // 伝票発行区分
                salesSlipWork.SlipPrintFinishCd = salesSlip.SlipPrintFinishCd; // 伝票発行済区分
                salesSlipWork.SalesSlipPrintDate = salesSlip.SalesSlipPrintDate; // 売上伝票発行日
                salesSlipWork.BusinessTypeCode = salesSlip.BusinessTypeCode; // 業種コード
                salesSlipWork.BusinessTypeName = salesSlip.BusinessTypeName; // 業種名称
                salesSlipWork.OrderNumber = salesSlip.OrderNumber; // 発注番号
                salesSlipWork.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv; // 納品区分
                salesSlipWork.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm; // 納品区分名称
                salesSlipWork.SalesAreaCode = salesSlip.SalesAreaCode; // 販売エリアコード
                salesSlipWork.SalesAreaName = salesSlip.SalesAreaName; // 販売エリア名称
                salesSlipWork.ReconcileFlag = salesSlip.ReconcileFlag; // 消込フラグ
                salesSlipWork.SlipPrtSetPaperId = salesSlip.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
                salesSlipWork.CompleteCd = salesSlip.CompleteCd; // 一式伝票区分
                salesSlipWork.SalesPriceFracProcCd = salesSlip.SalesPriceFracProcCd; // 売上金額端数処理区分
                salesSlipWork.StockGoodsTtlTaxExc = salesSlip.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
                salesSlipWork.PureGoodsTtlTaxExc = salesSlip.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
                salesSlipWork.ListPricePrintDiv = salesSlip.ListPricePrintDiv; // 定価印刷区分
                salesSlipWork.EraNameDispCd1 = salesSlip.EraNameDispCd1; // 元号表示区分１
                salesSlipWork.EstimaTaxDivCd = salesSlip.EstimaTaxDivCd; // 見積消費税区分
                salesSlipWork.EstimateFormPrtCd = salesSlip.EstimateFormPrtCd; // 見積書印刷区分
                salesSlipWork.EstimateSubject = salesSlip.EstimateSubject; // 見積件名
                salesSlipWork.Footnotes1 = salesSlip.Footnotes1; // 脚注１
                salesSlipWork.Footnotes2 = salesSlip.Footnotes2; // 脚注２
                salesSlipWork.EstimateTitle1 = salesSlip.EstimateTitle1; // 見積タイトル１
                salesSlipWork.EstimateTitle2 = salesSlip.EstimateTitle2; // 見積タイトル２
                salesSlipWork.EstimateTitle3 = salesSlip.EstimateTitle3; // 見積タイトル３
                salesSlipWork.EstimateTitle4 = salesSlip.EstimateTitle4; // 見積タイトル４
                salesSlipWork.EstimateTitle5 = salesSlip.EstimateTitle5; // 見積タイトル５
                salesSlipWork.EstimateNote1 = salesSlip.EstimateNote1; // 見積備考１
                salesSlipWork.EstimateNote2 = salesSlip.EstimateNote2; // 見積備考２
                salesSlipWork.EstimateNote3 = salesSlip.EstimateNote3; // 見積備考３
                salesSlipWork.EstimateNote4 = salesSlip.EstimateNote4; // 見積備考４
                salesSlipWork.EstimateNote5 = salesSlip.EstimateNote5; // 見積備考５
                salesSlipWork.EstimateValidityDate = salesSlip.EstimateValidityDate; // 見積有効期限
                salesSlipWork.PartsNoPrtCd = salesSlip.PartsNoPrtCd; // 品番印字区分
                salesSlipWork.OptionPringDivCd = salesSlip.OptionPringDivCd; // オプション印字区分
                salesSlipWork.RateUseCode = salesSlip.RateUseCode; // 掛率使用区分
                salesSlipWork.AutoDepositNoteDiv = salesSlip.AutoDepositNoteDiv; // 自動入金備考区分 // ADD 鄭慕鈞 Redmine#39126 入金伝票の摘要が正しくない対応
            }
            return salesSlipWork;
        }

        #endregion // </売上データワーク>

        #region <売上明細データワーク>

        /// <summary>
        /// リモート用売上明細データを生成します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <returns>リモート用売上明細データ</returns>
        public static SalesDetailWork CreateSalesDetailWork(SalesDetail salesDetail)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();
            {
                salesDetailWork.CreateDateTime = salesDetail.CreateDateTime; // 作成日時
                salesDetailWork.UpdateDateTime = salesDetail.UpdateDateTime; // 更新日時
                salesDetailWork.EnterpriseCode = salesDetail.EnterpriseCode; // 企業コード
                salesDetailWork.FileHeaderGuid = salesDetail.FileHeaderGuid; // GUID
                salesDetailWork.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // 更新従業員コード
                salesDetailWork.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // 更新アセンブリID1
                salesDetailWork.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // 更新アセンブリID2
                salesDetailWork.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // 論理削除区分
                salesDetailWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // 受注番号
                salesDetailWork.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // 受注ステータス
                salesDetailWork.SalesSlipNum = salesDetail.SalesSlipNum; // 売上伝票番号
                salesDetailWork.SalesRowNo = salesDetail.SalesRowNo; // 売上行番号
                salesDetailWork.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // 売上行番号枝番
                salesDetailWork.SectionCode = salesDetail.SectionCode; // 拠点コード
                salesDetailWork.SubSectionCode = salesDetail.SubSectionCode; // 部門コード
                salesDetailWork.SalesDate = salesDetail.SalesDate; // 売上日付
                salesDetailWork.CommonSeqNo = salesDetail.CommonSeqNo; // 共通通番
                salesDetailWork.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // 売上明細通番
                salesDetailWork.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // 受注ステータス（元）
                salesDetailWork.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // 売上明細通番（元）
                salesDetailWork.SupplierFormalSync = salesDetail.SupplierFormalSync; // 仕入形式（同時）
                salesDetailWork.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // 仕入明細通番（同時）
                salesDetailWork.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // 売上伝票区分（明細）
                salesDetailWork.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // 納品完了予定日
                salesDetailWork.GoodsKindCode = salesDetail.GoodsKindCode; // 商品属性
                salesDetailWork.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // 商品検索区分
                salesDetailWork.GoodsMakerCd = salesDetail.GoodsMakerCd; // 商品メーカーコード
                salesDetailWork.MakerName = salesDetail.MakerName; // メーカー名称
                salesDetailWork.MakerKanaName = salesDetail.MakerKanaName; // メーカーカナ名称
                salesDetailWork.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // メーカーカナ名称（一式）
                salesDetailWork.GoodsNo = salesDetail.GoodsNo; // 商品番号
                salesDetailWork.GoodsName = salesDetail.GoodsName; // 商品名称
                salesDetailWork.GoodsNameKana = salesDetail.GoodsNameKana; // 商品名称カナ
                salesDetailWork.GoodsLGroup = salesDetail.GoodsLGroup; // 商品大分類コード
                salesDetailWork.GoodsLGroupName = salesDetail.GoodsLGroupName; // 商品大分類名称
                salesDetailWork.GoodsMGroup = salesDetail.GoodsMGroup; // 商品中分類コード
                salesDetailWork.GoodsMGroupName = salesDetail.GoodsMGroupName; // 商品中分類名称
                salesDetailWork.BLGroupCode = salesDetail.BLGroupCode; // BLグループコード
                salesDetailWork.BLGroupName = salesDetail.BLGroupName; // BLグループコード名称
                salesDetailWork.BLGoodsCode = salesDetail.BLGoodsCode; // BL商品コード
                salesDetailWork.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL商品コード名称（全角）
                salesDetailWork.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // 自社分類コード
                salesDetailWork.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // 自社分類名称
                salesDetailWork.WarehouseCode = salesDetail.WarehouseCode; // 倉庫コード
                salesDetailWork.WarehouseName = salesDetail.WarehouseName; // 倉庫名称
                salesDetailWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // 倉庫棚番
                salesDetailWork.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // 売上在庫取寄せ区分
                salesDetailWork.OpenPriceDiv = salesDetail.OpenPriceDiv; // オープン価格区分
                salesDetailWork.GoodsRateRank = salesDetail.GoodsRateRank; // 商品掛率ランク
                salesDetailWork.CustRateGrpCode = salesDetail.CustRateGrpCode; // 得意先掛率グループコード
                salesDetailWork.ListPriceRate = salesDetail.ListPriceRate; // 定価率
                salesDetailWork.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // 掛率設定拠点（定価）
                salesDetailWork.RateDivLPrice = salesDetail.RateDivLPrice; // 掛率設定区分（定価）
                salesDetailWork.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // 単価算出区分（定価）
                salesDetailWork.PriceCdLPrice = salesDetail.PriceCdLPrice; // 価格区分（定価）
                salesDetailWork.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // 基準単価（定価）
                salesDetailWork.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // 端数処理単位（定価）
                salesDetailWork.FracProcLPrice = salesDetail.FracProcLPrice; // 端数処理（定価）
                salesDetailWork.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // 定価（税込，浮動）
                salesDetailWork.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // 定価（税抜，浮動）
                salesDetailWork.ListPriceChngCd = salesDetail.ListPriceChngCd; // 定価変更区分
                salesDetailWork.SalesRate = salesDetail.SalesRate; // 売価率
                salesDetailWork.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // 掛率設定拠点（売上単価）
                salesDetailWork.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // 掛率設定区分（売上単価）
                salesDetailWork.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc; // 単価算出区分（売上単価）
                salesDetailWork.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // 価格区分（売上単価）
                salesDetailWork.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // 基準単価（売上単価）
                salesDetailWork.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // 端数処理単位（売上単価）
                salesDetailWork.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // 端数処理（売上単価）
                salesDetailWork.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
                salesDetailWork.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
                salesDetailWork.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // 売上単価変更区分
                salesDetailWork.CostRate = salesDetail.CostRate; // 原価率
                salesDetailWork.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // 掛率設定拠点（原価単価）
                salesDetailWork.RateDivUnCst = salesDetail.RateDivUnCst; // 掛率設定区分（原価単価）
                salesDetailWork.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // 単価算出区分（原価単価）
                salesDetailWork.PriceCdUnCst = salesDetail.PriceCdUnCst; // 価格区分（原価単価）
                salesDetailWork.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // 基準単価（原価単価）
                salesDetailWork.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // 端数処理単位（原価単価）
                salesDetailWork.FracProcUnCst = salesDetail.FracProcUnCst; // 端数処理（原価単価）
                salesDetailWork.SalesUnitCost = salesDetail.SalesUnitCost; // 原価単価
                salesDetailWork.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // 原価単価変更区分
                salesDetailWork.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL商品コード（掛率）
                salesDetailWork.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL商品コード名称（掛率）
                salesDetailWork.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // 商品掛率グループコード（掛率）
                salesDetailWork.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // 商品掛率グループ名称（掛率）
                salesDetailWork.RateBLGroupCode = salesDetail.RateBLGroupCode; // BLグループコード（掛率）
                salesDetailWork.RateBLGroupName = salesDetail.RateBLGroupName; // BLグループ名称（掛率）
                salesDetailWork.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL商品コード（印刷）
                salesDetailWork.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL商品コード名称（印刷）
                salesDetailWork.SalesCode = salesDetail.SalesCode; // 販売区分コード
                salesDetailWork.SalesCdNm = salesDetail.SalesCdNm; // 販売区分名称
                salesDetailWork.WorkManHour = salesDetail.WorkManHour; // 作業工数
                salesDetailWork.ShipmentCnt = salesDetail.ShipmentCnt; // 出荷数
                salesDetailWork.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // 受注数量
                salesDetailWork.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // 受注調整数
                salesDetailWork.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // 受注残数
                salesDetailWork.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // 残数更新日
                salesDetailWork.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // 売上金額（税込み）
                salesDetailWork.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // 売上金額（税抜き）
                salesDetailWork.Cost = salesDetail.Cost; // 原価
                salesDetailWork.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // 粗利チェック区分
                salesDetailWork.SalesGoodsCd = salesDetail.SalesGoodsCd; // 売上商品区分
                salesDetailWork.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // 売上金額消費税額
                salesDetailWork.TaxationDivCd = salesDetail.TaxationDivCd; // 課税区分
                salesDetailWork.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // 相手先伝票番号（明細）
                salesDetailWork.DtlNote = salesDetail.DtlNote; // 明細備考
                salesDetailWork.SupplierCd = salesDetail.SupplierCd; // 仕入先コード
                salesDetailWork.SupplierSnm = salesDetail.SupplierSnm; // 仕入先略称
                salesDetailWork.OrderNumber = salesDetail.OrderNumber; // 発注番号
                salesDetailWork.WayToOrder = salesDetail.WayToOrder; // 注文方法
                salesDetailWork.SlipMemo1 = salesDetail.SlipMemo1; // 伝票メモ１
                salesDetailWork.SlipMemo2 = salesDetail.SlipMemo2; // 伝票メモ２
                salesDetailWork.SlipMemo3 = salesDetail.SlipMemo3; // 伝票メモ３
                salesDetailWork.InsideMemo1 = salesDetail.InsideMemo1; // 社内メモ１
                salesDetailWork.InsideMemo2 = salesDetail.InsideMemo2; // 社内メモ２
                salesDetailWork.InsideMemo3 = salesDetail.InsideMemo3; // 社内メモ３
                salesDetailWork.BfListPrice = salesDetail.BfListPrice; // 変更前定価
                salesDetailWork.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // 変更前売価
                salesDetailWork.BfUnitCost = salesDetail.BfUnitCost; // 変更前原価
                salesDetailWork.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // 一式明細番号
                // UPD 2014/09/08 T.Miyamoto ------------------------------>>>>>
                // Tabletでの売上時に純正メーカーが登録されない為、下記の削除箇所を復活
                //// DEL 2013/08/29 Redmine#40183対応 ------------------------------------>>>>>
                ////salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
                //// DEL 2013/08/29 Redmine#40183対応 ------------------------------------<<<<<
                salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // メーカーコード（一式）
                // UPD 2014/09/08 T.Miyamoto ------------------------------<<<<<
                salesDetailWork.CmpltMakerName = salesDetail.CmpltMakerName; // メーカー名称（一式）
                salesDetailWork.CmpltGoodsName = salesDetail.CmpltGoodsName; // 商品名称（一式）
                salesDetailWork.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // 数量（一式）
                salesDetailWork.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // 売上単価（一式）
                salesDetailWork.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // 売上金額（一式）
                salesDetailWork.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // 原価単価（一式）
                salesDetailWork.CmpltCost = salesDetail.CmpltCost; // 原価金額（一式）
                salesDetailWork.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // 相手先伝票番号（一式）
                salesDetailWork.CmpltNote = salesDetail.CmpltNote; // 一式備考
                salesDetailWork.PrtGoodsNo = salesDetail.PrtGoodsNo; // 印刷用品番
                salesDetailWork.PrtMakerCode = salesDetail.PrtMakerCode; // 印刷用メーカーコード
                salesDetailWork.PrtMakerName = salesDetail.PrtMakerName; // 印刷用メーカー名称
                salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // 共通キー
                salesDetailWork.AcceptOrOrderKind = salesDetail.AcceptOrOrderKind;// 受発注種別
                salesDetailWork.InquiryNumber = salesDetail.InquiryNumber; // 問合せ番号
                salesDetailWork.InqRowNumber = salesDetail.InqRowNumber; // 問合せ行番号
                salesDetailWork.AutoAnswerDivSCM = salesDetail.AutoAnswerDivSCM; // 自動回答区分(SCM)
                salesDetailWork.AnswerDelivDate = salesDetail.AnswerDelivDate; // 回答納期
                salesDetailWork.WayToAcptOdr = salesDetail.WayToAcptOdr; // 受注方法
                salesDetailWork.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // 特記事項
                // ADD 吉岡 2013/08/06 Redmine#39637 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                salesDetailWork.CampaignCode = salesDetail.CampaignCode;    // キャンペーンコード
                // ADD 吉岡 2013/08/06 Redmine#39637 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return salesDetailWork;
        }
        #endregion // </売上明細データワーク>
        #endregion // </リモート用ワークデータ>
        // ----------------- ADD 2013/07/03 qijh Redmine#37586 --------------- <<<<<
        #endregion
    }
}
