//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送受信履歴ログ参照メンテ画面アクセスクラス
// プログラム概要   : 送受信履歴ログ参照メンテ画面アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李亜博
// 作 成 日  2012/07/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/10/08  修正内容 : 拠点管理ログ参照ツール不具合の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/10/16  修正内容 : 拠点管理ログ参照ツール不具合の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送受信履歴ログ参照メンテ画面アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送受信履歴ログ参照メンテ画面アクセスクラス</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2012/07/25</br>
    /// <br>Update Note: 2012/10/08 李亜博</br>
    ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// <br>Update Note: 2012/10/16 李亜博</br>
    ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// </remarks>
    public partial class SndRcvHisLogAcs
    {
        #region ■ Const Memebers ■
        private const string MST_SECINFOSET = "拠点設定マスタ";
        private const string MST_SUBSECTION = "部門設定マスタ";
        private const string MST_WAREHOUSE = "倉庫設定マスタ";
        private const string MST_EMPLOYEE = "従業員設定マスタ";
        private const string MST_USERGDAREADIVU = "ユーザーガイドマスタ(販売エリア区分）";
        private const string MST_USERGDBUSDIVU = "ユーザーガイドマスタ（業務区分）";
        private const string MST_USERGDCATEU = "ユーザーガイドマスタ（業種）";
        private const string MST_USERGDBUSU = "ユーザーガイドマスタ（職種）";
        private const string MST_USERGDGOODSDIVU = "ユーザーガイドマスタ（商品区分）";
        private const string MST_USERGDCUSGROUPU = "ユーザーガイドマスタ（得意先掛率グループ）";
        private const string MST_USERGDBANKU = "ユーザーガイドマスタ（銀行）";
        private const string MST_USERGDPRIDIVU = "ユーザーガイドマスタ（価格区分）";
        private const string MST_USERGDDELIDIVU = "ユーザーガイドマスタ（納品区分）";
        private const string MST_USERGDGOODSBIGU = "ユーザーガイドマスタ（商品大分類）";
        private const string MST_USERGDBUYDIVU = "ユーザーガイドマスタ（販売区分）";
        private const string MST_USERGDSTOCKDIVOU = "ユーザーガイドマスタ（在庫管理区分１）";
        private const string MST_USERGDSTOCKDIVTU = "ユーザーガイドマスタ（在庫管理区分２）";
        private const string MST_USERGDRETURNREAU = "ユーザーガイドマスタ（返品理由）";
        private const string MST_RATEPROTYMNG = "掛率優先管理マスタ";
        private const string MST_RATE = "掛率マスタ";
        private const string MST_SALESTARGET = "売上目標設定マスタ";
        private const string MST_CUSTOME = "得意先マスタ";
        private const string MST_SUPPLIER = "仕入先マスタ";
        private const string MST_JOINPARTSU = "結合マスタ";
        private const string MST_GOODSSET = "セットマスタ";
        private const string MST_TBOSEARCHU = "ＴＢＯマスタ";
        private const string MST_MODELNAMEU = "車種マスタ";
        private const string MST_BLGOODSCDU = "ＢＬコードマスタ";
        private const string MST_MAKERU = "メーカーマスタ";
        private const string MST_GOODSMGROUPU = "商品中分類マスタ";
        private const string MST_BLGROUPU = "グループコードマスタ";
        private const string MST_BLCODEGUIDE = "BLコードガイドマスタ";
        private const string MST_GOODSU = "商品マスタ";
        private const string MST_STOCK = "在庫マスタ";
        private const string MST_PARTSSUBSTU = "代替マスタ";
        private const string MST_PARTSPOSCODEU = "部位マスタ";

        private const string MST_ID_SECINFOSET = "SecInfoSetRF";
        private const string MST_ID_SUBSECTION = "SubSectionRF";
        private const string MST_ID_WAREHOUSE = "WarehouseRF";
        //private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";//DEL 2012/10/08 李亜博 for redmine#31026 
        private const string MST_ID_EMPLOYEE = "EmployeeRF";//ADD 2012/10/08 李亜博 for redmine#31026
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOME = "CustomerRF";
        private const string MST_ID_CUSTOMEGROUP = "CustRateGroupRF";
        private const string MST_ID_CUSTOMESLIPMNG = "CustSlipMngRF";
        private const string MST_ID_CUSTOMESLIPNO = "CustSlipNoSetRF";
        private const string MST_ID_SUPPLIER = "SupplierRF";
        private const string MST_ID_JOINPARTSU = "JoinPartsURF";
        private const string MST_ID_GOODSSET = "GoodsSetRF";
        private const string MST_ID_TBOSEARCHU = "TBOSearchURF";
        private const string MST_ID_MODELNAMEU = "ModelNameURF";
        private const string MST_ID_BLGOODSCDU = "BLGoodsCdURF";
        private const string MST_ID_MAKERU = "MakerURF";
        private const string MST_ID_GOODSMGROUPU = "GoodsMGroupURF";
        private const string MST_ID_BLGROUPU = "BLGroupURF";
        private const string MST_ID_BLCODEGUIDE = "BLCodeGuideRF";
        private const string MST_ID_GOODSUMNG = "GoodsMngRF";
        private const string MST_ID_GOODSUPRI = "GoodsPriceURF";
        private const string MST_ID_GOODSU = "GoodsURF";
        private const string MST_ID_GOODSUISO = "IsolIslandPrcRF";
        private const string MST_ID_STOCK = "StockRF";
        private const string MST_ID_PARTSSUBSTU = "PartsSubstURF";
        private const string MST_ID_PARTSPOSCODEU = "PartsPosCodeURF";

        private const string FILEID_CUSTOMER = "CustomerRF";
        private const string FILEID_GOODS = "GoodsURF";
        private const string FILEID_STOCK = "StockRF";
        private const string FILEID_SUPPLIER = "SupplierRF";
        private const string FILEID_RATE = "RateRF";
        #endregion ■ Const Memebers ■

        # region ■ Constructor ■

        /// <summary>
        ///  送受信履歴ログ参照メンテ画面アクセスクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタ</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public SndRcvHisLogAcs()
        {

        }
        #endregion ■ Constructor ■

        # region ■ Private Members ■

        private static SndRcvHisLogAcs _sndRcvHisLogAcs;
        private IDCControlDB IDCControlDB = null;
        private IMstDCControlDB IMstDCControlDB = null;
        private ISndRcvHisTableDB ISndRcvHisTableDB = null;
        # endregion ■ Private Members ■

        #region ■ Public Method ■
        /// <summary>
        /// 送受信履歴ログ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="sndRcvHisConWork">送受信履歴ログデータワーク</param>
        /// <param name="searchResult">情報LIST</param>
        /// <param name="searchEtrResult">抽出条件詳細情報LIST</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        public int Search(SndRcvHisConWork sndRcvHisConWork, out object searchResult, out object searchEtrResult)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            searchResult = new object();
            searchEtrResult = new object();

            try
            {
                if (ISndRcvHisTableDB == null)
                {
                    ISndRcvHisTableDB = (ISndRcvHisTableDB)MediationSndRcvHisTableDB.GetSndRcvHisTableDB();
                }

                status = ISndRcvHisTableDB.Search(sndRcvHisConWork, out searchResult, out searchEtrResult);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 送受信履歴ログデータを物理削除します
        /// </summary>
        /// <param name="sndRcvHisTableWorkList">削除する送受信履歴ログデータを含むArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログデータを物理削除します</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        public int Delete(ref object sndRcvHisTableWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                if (ISndRcvHisTableDB == null)
                {
                    ISndRcvHisTableDB = (ISndRcvHisTableDB)MediationSndRcvHisTableDB.GetSndRcvHisTableDB();
                }

                status = ISndRcvHisTableDB.Delete(ref sndRcvHisTableWorkList);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 送受信履歴ログ戻りデータ情報LIST再受信
        /// </summary>
        /// <param name="records">送受信履歴ログデータ情報LIST</param>
        /// <param name="searchEtrResultObj">送受信履歴ログ詳細情報LIST</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        public int ReceiveAgain(object records, object searchEtrResultObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList list = records as ArrayList;
            ArrayList masterDivList = null;
            ArrayList condParamList = null;
            DCReceiveDataWork parareceiveWork = null;
            object receiveList = null;

            try
            {
                foreach (SndRcvHisTableWork sndRcvHisTableWork in list)
                {
                    // 種別0:データ
                    if (sndRcvHisTableWork.Kind == 0)
                    {
                        receiveList = new object();

                        string[] fileIds = sndRcvHisTableWork.SndRcvFileID.Split(',');

                        parareceiveWork = new DCReceiveDataWork();
                        // 企業コード
                        parareceiveWork.PmEnterpriseCode = sndRcvHisTableWork.EnterpriseCode;

                        // 送受信ログ抽出条件区分1:伝票日付
                        if (sndRcvHisTableWork.SndLogExtraCondDiv == 1)
                        {
                            parareceiveWork.StartDateTime =
                            Convert.ToInt32(new DateTime(sndRcvHisTableWork.SndObjStartDate).ToString("yyyyMMdd"));
                            parareceiveWork.EndDateTime = Convert.ToInt32(new DateTime(sndRcvHisTableWork.SndObjEndDate).ToString("yyyyMMdd"));

                            parareceiveWork.EndDateTimeTicks = sndRcvHisTableWork.SndObjEndDate;
                        }
                        else
                        {
                            parareceiveWork.StartDateTime = sndRcvHisTableWork.SndObjStartDate;
                            parareceiveWork.EndDateTime = sndRcvHisTableWork.SndObjEndDate;
                        }
                        // 種別
                        parareceiveWork.Kind = sndRcvHisTableWork.Kind;
                        // シンク実行日付
                        parareceiveWork.SyncExecDate = sndRcvHisTableWork.SyncExecDate;
                        // 拠点コード
                        parareceiveWork.PmSectionCode = sndRcvHisTableWork.SectionCode;
                        // 送受信履歴ログ送信番号
                        parareceiveWork.SndRcvHisConsNo = sndRcvHisTableWork.SndRcvHisConsNo;
                        // 送受信ログ抽出条件区分
                        parareceiveWork.SndLogExtraCondDiv = sndRcvHisTableWork.SndLogExtraCondDiv;
                        // 送信先企業コード
                        parareceiveWork.SendDestEpCode = sndRcvHisTableWork.SendDestEpCode;
                        // 送信先拠点コード
                        parareceiveWork.SendDestSecCode = sndRcvHisTableWork.SendDestSecCode;
                        // 仮受信区分:仮受信
                        parareceiveWork.TempReceiveDiv = 2;
                        //送受信ファイルＩＤ
                        parareceiveWork.SndRcvFileID = sndRcvHisTableWork.SndRcvFileID;

                        if (IDCControlDB == null)
                        {
                            IDCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                        }

                        status = IDCControlDB.SearchSCM(out receiveList, parareceiveWork, sndRcvHisTableWork.SectionCode, fileIds);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                    // 種別1:マスタ
                    else if (sndRcvHisTableWork.Kind == 1)
                    {
                        masterDivList = new ArrayList();
                        condParamList = new ArrayList();

                        string[] fileIds = sndRcvHisTableWork.SndRcvFileID.Split(',');
                        string tempUserGuideDivCd = null;
                        DCSecMngSndRcvWork secMngSndRcvWork = null;

                        for (int i = 0; i < fileIds.Length; i++)
                        {
                            secMngSndRcvWork = new DCSecMngSndRcvWork();
                            // 企業コード
                            //secMngSndRcvWork.EnterpriseCode = sndRcvHisTableWork.EnterpriseCode;//DEL 2012/10/16 李亜博 for redmine#31026
                            secMngSndRcvWork.EnterpriseCode = sndRcvHisTableWork.SendDestEpCode;//ADD 2012/10/16 李亜博 for redmine#31026
                            // 拠点コード
                            secMngSndRcvWork.SectionCode = sndRcvHisTableWork.SectionCode;
                            // 送受信履歴ログ送信番号
                            secMngSndRcvWork.SndRcvHisConsNo = sndRcvHisTableWork.SndRcvHisConsNo;
                            // 送受信ログ抽出条件区分
                            secMngSndRcvWork.SndLogExtraCondDiv = sndRcvHisTableWork.SndLogExtraCondDiv;
                            // 送信先企業コード
                            secMngSndRcvWork.SendDestEpCode = sndRcvHisTableWork.SendDestEpCode;
                            // 送信先拠点コード
                            secMngSndRcvWork.SendDestSecCode = sndRcvHisTableWork.SendDestSecCode;
                            // 仮受信区分:仮受信
                            secMngSndRcvWork.TempReceiveDiv = 2;
                            // 送受信ファイルＩＤ
                            secMngSndRcvWork.SndRcvFileID = fileIds[i];
                            // 送受信ファイルＩＤ
                            secMngSndRcvWork.FileId = fileIds[i];
                            // マスタ名称
                            if (secMngSndRcvWork.SndRcvFileID.Length >= 11 && MST_ID_USERGDU.Equals(secMngSndRcvWork.SndRcvFileID.Substring(0, 11)))
                            {
                                tempUserGuideDivCd = secMngSndRcvWork.SndRcvFileID.Substring(11);

                                // 送受信ファイルＩＤ
                                secMngSndRcvWork.FileId = MST_ID_USERGDU;

                                // ユーザーガイドマスタ(販売エリア区分）
                                if (tempUserGuideDivCd.Equals("21"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDAREADIVU;
                                }
                                // ユーザーガイドマスタ（業務区分）
                                else if (tempUserGuideDivCd.Equals("31"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBUSDIVU;
                                }
                                // ユーザーガイドマスタ（業種）
                                else if (tempUserGuideDivCd.Equals("33"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDCATEU;
                                }
                                // ユーザーガイドマスタ（職種）
                                else if (tempUserGuideDivCd.Equals("34"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBUSU;
                                }
                                // ユーザーガイドマスタ（商品区分）
                                else if (tempUserGuideDivCd.Equals("41"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDGOODSDIVU;
                                }
                                // ユーザーガイドマスタ（得意先掛率グループ）
                                else if (tempUserGuideDivCd.Equals("43"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDCUSGROUPU;
                                }
                                // ユーザーガイドマスタ（銀行）
                                else if (tempUserGuideDivCd.Equals("46"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBANKU;
                                }
                                // ユーザーガイドマスタ（価格区分）
                                else if (tempUserGuideDivCd.Equals("47"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDPRIDIVU;
                                }
                                // ユーザーガイドマスタ（納品区分）
                                else if (tempUserGuideDivCd.Equals("48"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDDELIDIVU;
                                }
                                // ユーザーガイドマスタ（商品大分類）
                                else if (tempUserGuideDivCd.Equals("70"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDGOODSBIGU;
                                }
                                // ユーザーガイドマスタ（販売区分）
                                else if (tempUserGuideDivCd.Equals("71"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDBUYDIVU;
                                }
                                // ユーザーガイドマスタ（在庫管理区分１）
                                else if (tempUserGuideDivCd.Equals("72"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDSTOCKDIVOU;
                                }
                                // ユーザーガイドマスタ（在庫管理区分２）
                                else if (tempUserGuideDivCd.Equals("73"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDSTOCKDIVTU;
                                }
                                // ユーザーガイドマスタ（返品理由）
                                else if (tempUserGuideDivCd.Equals("91"))
                                {
                                    secMngSndRcvWork.MasterName = MST_USERGDRETURNREAU;
                                }
                            }
                            else
                            {
                                secMngSndRcvWork.MasterName = GetFileIdName(secMngSndRcvWork.SndRcvFileID);
                            }
                            // 拠点管理受信区分
                            secMngSndRcvWork.SecMngRecvDiv = 1;

                            masterDivList.Add(secMngSndRcvWork);
                        }

                        // 送受信ログ抽出条件区分1:手動(条件)
                        if (sndRcvHisTableWork.SndLogExtraCondDiv == 1)
                        {
                            ArrayList searchEtrResultList = searchEtrResultObj as ArrayList;
                            int sndRcvHisConsNo = sndRcvHisTableWork.SndRcvHisConsNo;  // 送受信履歴ログ送信番号
                            string sectionCode = sndRcvHisTableWork.SectionCode;       //拠点コード
                            string enterpriseCode = sndRcvHisTableWork.EnterpriseCode; //企業コード

                            foreach (SndRcvEtrWork work in searchEtrResultList)
                            {
                                if (work.SndRcvHisConsNo == sndRcvHisConsNo && work.EnterpriseCode.Trim().Equals(enterpriseCode.Trim()) && work.SectionCode.Trim().Equals(sectionCode.Trim()))
                                {
                                    //得意先マスタ
                                    if (work.FileId.Equals(FILEID_CUSTOMER))
                                    {
                                        CustomerProcParamWork customerProcParamWork = SndRcvEtrWorkToCustomerProcParamWork(work);
                                        customerProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        customerProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(customerProcParamWork);
                                    }
                                    //商品マスタ
                                    else if (work.FileId.Equals(FILEID_GOODS))
                                    {
                                        GoodsProcParamWork goodsProcParamWork = SndRcvEtrWorkToGoodsProcParamWork(work);
                                        goodsProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        goodsProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(goodsProcParamWork);
                                    }
                                    //在庫マスタ
                                    else if (work.FileId.Equals(FILEID_STOCK))
                                    {
                                        StockProcParamWork stockProcParamWork = SndRcvEtrWorkToStockProcParamWork(work);
                                        stockProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        stockProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(stockProcParamWork);
                                    }
                                    //仕入先マスタ
                                    else if (work.FileId.Equals(FILEID_SUPPLIER))
                                    {
                                        SupplierProcParamWork supplierProcParamWork = SndRcvEtrWorkToSupplierProcParamWork(work);
                                        supplierProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        supplierProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(supplierProcParamWork);
                                    }
                                    //掛率マスタ
                                    else if (work.FileId.Equals(FILEID_RATE))
                                    {
                                        RateProcParamWork rateProcParamWork = SndRcvEtrWorkToRateProcParamWork(work);
                                        rateProcParamWork.UpdateDateTimeBegin = sndRcvHisTableWork.SndObjStartDate;
                                        rateProcParamWork.UpdateDateTimeEnd = sndRcvHisTableWork.SndObjEndDate;
                                        condParamList.Add(rateProcParamWork);
                                    }

                                }
                            }
                        }

                        CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
                        string retMessage = null;

                        if (IMstDCControlDB == null)
                        {
                            IMstDCControlDB = (IMstDCControlDB)MediationMstDCControlDB.GetMstDCControlDB();
                        }

                        // 送受信ログ抽出条件区分0:自動(差分)
                        if (sndRcvHisTableWork.SndLogExtraCondDiv == 0)
                        {
                            //status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.SendDestEpCode, sndRcvHisTableWork.SndObjStartDate, sndRcvHisTableWork.SndObjEndDate, ref retCSAList, out retMessage);//DEL 2012/10/16 李亜博 for redmine#31026
                            status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.EnterpriseCode, sndRcvHisTableWork.SndObjStartDate, sndRcvHisTableWork.SndObjEndDate, ref retCSAList, out retMessage);//ADD 2012/10/16 李亜博 for redmine#31026
                        }
                        // 送受信ログ抽出条件区分1:手動(条件)
                        else
                        {
                            //status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.SendDestEpCode, condParamList, ref retCSAList, out retMessage);//DEL 2012/10/16 李亜博 for redmine#31026
                            status = IMstDCControlDB.SearchCustomSerializeArrayList(masterDivList, sndRcvHisTableWork.EnterpriseCode, condParamList, ref retCSAList, out retMessage);//ADD 2012/10/16 李亜博 for redmine#31026
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        ///// <summary>
        ///// 拠点情報を取得
        ///// </summary>
        ///// <param name="sectionCode"></param>
        ///// <returns></returns>
        //public string GetSetctionName(string sectionCode)
        //{
        //    string sectionName = null;

        //    SecInfoAcs secInfoAcs = new SecInfoAcs();
        //    try
        //    {
        //        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
        //        {
        //            if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
        //            {
        //                sectionName = secInfoSet.SectionGuideNm.Trim();
        //                break;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        sectionName = string.Empty;
        //    }

        //    return sectionName;
        //}
        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        /// <summary>
        /// 送受信履歴ログ参照 インスタンス取得処理
        /// </summary>
        /// <returns>送受信履歴ログ参照 インスタンス</returns>
        public static SndRcvHisLogAcs GetInstance()
        {
            if (_sndRcvHisLogAcs == null)
            {
                _sndRcvHisLogAcs = new SndRcvHisLogAcs();
            }

            return _sndRcvHisLogAcs;
        }
        /// <summary>
        /// DateTimeの日時はStringにする
        /// </summary>
        /// <param name="dateTime">DateTimeの日時</param>
        /// <returns>Stringの日時</returns>
        /// <remarks>
        /// <br>Note       : DateTimeの日時はStringにする</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public string DateTimeFormatToString(DateTime dateTime)
        {
            string time = null;
            time += dateTime.Year + "年";
            time += Convert.ToString(dateTime.Month).PadLeft(2, '0') + "月";
            time += Convert.ToString(dateTime.Day).PadLeft(2, '0') + "日";
            time += Convert.ToString(dateTime.Hour).PadLeft(2, '0') + "時";
            time += Convert.ToString(dateTime.Minute).PadLeft(2, '0') + "分";
            time += Convert.ToString(dateTime.Second).PadLeft(2, '0') + "秒";

            return time;
        }
        #endregion ■ Public Method ■

        #region ■ Private Method ■

        /// <summary>
        /// 得意先マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns>得意先マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ抽出条件を取得する</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private CustomerProcParamWork SndRcvEtrWorkToCustomerProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            CustomerProcParamWork customerProcParam = new CustomerProcParamWork();

            customerProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            customerProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            customerProcParam.KanaBeginRF = sndRcvEtrWork.StartCond2;
            customerProcParam.KanaEndRF = sndRcvEtrWork.EndCond2;
            customerProcParam.MngSectionCodeBeginRF = sndRcvEtrWork.StartCond3;
            customerProcParam.MngSectionCodeEndRF = sndRcvEtrWork.EndCond3;
            customerProcParam.CustomerAgentCdBeginRF = sndRcvEtrWork.StartCond4;
            customerProcParam.CustomerAgentCdEndRF = sndRcvEtrWork.EndCond4;
            customerProcParam.SalesAreaCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            customerProcParam.SalesAreaCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            customerProcParam.BusinessTypeCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            customerProcParam.BusinessTypeCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);

            return customerProcParam;
        }

        /// <summary>
        /// 商品マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns>商品マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ抽出条件を取得する</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private GoodsProcParamWork SndRcvEtrWorkToGoodsProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            GoodsProcParamWork goodsProcParam = new GoodsProcParamWork();

            goodsProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            goodsProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            goodsProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
            goodsProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
            goodsProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            goodsProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            goodsProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond4;
            goodsProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond4;

            return goodsProcParam;
        }

        /// <summary>
        /// 在庫マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns>在庫マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ抽出条件を取得する</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private StockProcParamWork SndRcvEtrWorkToStockProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            StockProcParamWork stockProcParam = new StockProcParamWork();

            stockProcParam.WarehouseCodeBeginRF = sndRcvEtrWork.StartCond1;
            stockProcParam.WarehouseCodeEndRF = sndRcvEtrWork.EndCond1;
            stockProcParam.WarehouseShelfNoBeginRF = sndRcvEtrWork.StartCond2;
            stockProcParam.WarehouseShelfNoEndRF = sndRcvEtrWork.EndCond2;
            stockProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            stockProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            stockProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            stockProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            stockProcParam.BLGloupCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            stockProcParam.BLGloupCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            stockProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond6;
            stockProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond6;

            return stockProcParam;
        }

        /// <summary>
        /// 仕入先マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns>仕入先マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ抽出条件を取得する</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private SupplierProcParamWork SndRcvEtrWorkToSupplierProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            SupplierProcParamWork supplierProcParam = new SupplierProcParamWork();

            supplierProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            supplierProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);

            return supplierProcParam;
        }

        /// <summary>
        /// 掛率マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns>掛率マスタワーク</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ抽出条件を取得する</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private RateProcParamWork SndRcvEtrWorkToRateProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            RateProcParamWork rateProcParam = new RateProcParamWork();

            rateProcParam.UnitPriceKindRF = sndRcvEtrWork.StartCond1;
            rateProcParam.SetFunRF = sndRcvEtrWork.EndCond1;
            rateProcParam.RateSettingDivideRF = sndRcvEtrWork.StartCond2;
            rateProcParam.CustRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            rateProcParam.CustRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            rateProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            rateProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            rateProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            rateProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            rateProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            rateProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
            rateProcParam.GoodsRateRankBeginRF = sndRcvEtrWork.StartCond7;
            rateProcParam.GoodsRateRankEndRF = sndRcvEtrWork.EndCond7;
            rateProcParam.GoodsRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond8);
            rateProcParam.GoodsRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond8);
            rateProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond9);
            rateProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond9);
            rateProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond10;
            rateProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond10;

            return rateProcParam;
        }

        /// <summary>
        /// マスタ名を取得する
        /// </summary>
        /// <param name="fileId">マスタID</param>
        /// <returns>マスタ名</returns>
        /// <remarks>
        /// <br>Note       : マスタ名を取得する</br>
        /// <br>Programmer : 李亜博 </br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private string GetFileIdName(string fileId)
        {
            string fileIdName = null;
            // 得意先マスタ
            if (MST_ID_CUSTOME.Equals(fileId))
            {
                fileIdName = MST_CUSTOME;
            }
            // 商品マスタ（ユーザー登録分）
            else if (MST_ID_GOODSU.Equals(fileId))
            {
                fileIdName = MST_GOODSU;
            }
            // 在庫マスタ
            else if (MST_ID_STOCK.Equals(fileId))
            {
                fileIdName = MST_STOCK;
            }
            // 仕入先マスタ
            else if (MST_ID_SUPPLIER.Equals(fileId))
            {
                fileIdName = MST_SUPPLIER;
            }
            // 掛率マスタ
            else if (MST_ID_RATE.Equals(fileId))
            {
                fileIdName = MST_RATE;
            }
            // 拠点設定マスタ
            else if (MST_ID_SECINFOSET.Equals(fileId))
            {
                fileIdName = MST_SECINFOSET;
            }
            // 部門設定マスタ
            else if (MST_ID_SUBSECTION.Equals(fileId))
            {
                fileIdName = MST_SUBSECTION;
            }
            // 倉庫設定マスタ
            else if (MST_ID_WAREHOUSE.Equals(fileId))
            {
                fileIdName = MST_WAREHOUSE;
            }
            // 従業員マスタ、従業員詳細マスタ
            else if (MST_ID_EMPLOYEE.Equals(fileId) || MST_ID_EMPLOYEEDTL.Equals(fileId))
            {
                fileIdName = MST_EMPLOYEE;
            }
            // 得意先マスタ(変動情報)、得意先マスタ（伝票管理）、得意先マスタ（掛率グループ）、得意先マスタ(伝票番号)
            else if (MST_ID_CUSTOMECHA.Equals(fileId) || MST_ID_CUSTOMESLIPMNG.Equals(fileId) || MST_ID_CUSTOMEGROUP.Equals(fileId) || MST_ID_CUSTOMESLIPNO.Equals(fileId))
            {
                fileIdName = MST_CUSTOME;
            }
            // メーカーマスタ（ユーザー登録分）
            else if (MST_ID_MAKERU.Equals(fileId))
            {
                fileIdName = MST_MAKERU;
            }
            // BL商品コードマスタ（ユーザー登録分）
            else if (MST_ID_BLGOODSCDU.Equals(fileId))
            {
                fileIdName = MST_BLGOODSCDU;
            }
            // 価格マスタ（ユーザー登録）、商品管理情報マスタ、離島価格マスタ
            else if (MST_ID_GOODSUPRI.Equals(fileId) || MST_ID_GOODSUMNG.Equals(fileId) || MST_ID_GOODSUISO.Equals(fileId))
            {
                fileIdName = MST_GOODSU;
            }
            // 掛率優先管理マスタ
            else if (MST_ID_RATEPROTYMNG.Equals(fileId))
            {
                fileIdName = MST_RATEPROTYMNG;
            }
            // 商品セットマスタ
            else if (MST_ID_GOODSSET.Equals(fileId))
            {
                fileIdName = MST_GOODSSET;
            }
            // 部品代替マスタ（ユーザー登録分）
            else if (MST_ID_PARTSSUBSTU.Equals(fileId))
            {
                fileIdName = MST_PARTSSUBSTU;
            }
            // 従業員別売上目標設定マスタ得意先別売上目標設定マスタ、得意先別売上目標設定マスタ、商品別売上目標設定マスタ
            else if (MST_ID_EMPSALESTARGET.Equals(fileId) || MST_ID_CUSTSALESTARGET.Equals(fileId) || MST_ID_GCDSALESTARGET.Equals(fileId))
            {
                fileIdName = MST_SALESTARGET;
            }
            // 商品中分類マスタ（ユーザー登録分）
            else if (MST_ID_GOODSMGROUPU.Equals(fileId))
            {
                fileIdName = MST_GOODSMGROUPU;
            }
            // BLグループマスタ（ユーザー登録分）
            else if (MST_ID_BLGROUPU.Equals(fileId))
            {
                fileIdName = MST_BLGROUPU;
            }
            // 結合マスタ（ユーザー登録分）
            else if (MST_ID_JOINPARTSU.Equals(fileId))
            {
                fileIdName = MST_JOINPARTSU;
            }
            // TBO検索マスタ（ユーザー登録）
            else if (MST_ID_TBOSEARCHU.Equals(fileId))
            {
                fileIdName = MST_TBOSEARCHU;
            }
            // 部位コードマスタ（ユーザー登録）
            else if (MST_ID_PARTSPOSCODEU.Equals(fileId))
            {
                fileIdName = MST_PARTSPOSCODEU;
            }
            // BLコードガイドマスタ
            else if (MST_ID_BLCODEGUIDE.Equals(fileId))
            {
                fileIdName = MST_BLCODEGUIDE;
            }
            // 車種名称マスタ
            else if (MST_ID_MODELNAMEU.Equals(fileId))
            {
                fileIdName = MST_MODELNAMEU;
            }
            return fileIdName;
        }
        #endregion ■ Private Method ■
    }
}