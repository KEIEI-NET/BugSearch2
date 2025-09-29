//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷実績表
// プログラム概要   : 型式別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
// Update Note : 2010/05/08 王海立 REDMINE #7109の対応
// 　　　　　　: 型式別出荷対応表の変更
// Update Note : 2010/05/16 王海立 REDMINE #7109の対応
// 　　　　　　: BLコードの印字フォーマット修正
// 　　　　　　: 棚番と現在庫数印字
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhshh
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note : 2010.05.19 zhangsf Redmine #7784の対応
//             : ・型式別出荷対応表／各種修正
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Collections.Specialized;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 型式別出荷実績表 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 型式別出荷実績表で使用するデータを取得する。</br>
    /// <br>Programmer	: zhshh</br>
    /// <br>Date		: 2010.04.21</br>
    /// </remarks>
    public class ModelShipRsltAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 型式別出荷実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 型式別出荷実績表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public ModelShipRsltAcs()
        {
            this._iModelShipResultDB = (IModelShipResultDB)MediationModelShipResultDB.GetModelShipWorkDB();

            // --- ADD 2010/05/13 ---------->>>>>
            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd();
            string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            string msg;

            this._goodsAcs = new GoodsAcs(); // 商品マスタ
            this._goodsAcs.SearchInitial(enterpriseCode, loginSectionCode, out msg);
            // --- ADD 2010/05/13 ----------<<<<<
        }

        /// <summary>
        /// 型式別出荷実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 型式別出荷実績表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        static ModelShipRsltAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス	
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

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
        private static PrtOutSet stc_PrtOutSet;			            // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // 帳票出力設定アクセスクラス

        #endregion ■ Static Member

        #region ■ Private Member
        IModelShipResultDB _iModelShipResultDB;

        private DataSet _carShipListDs;	    		// 印刷DataTable

        private GoodsAcs _goodsAcs; // 商品マスタ ADD 2010/05/13

        #endregion ■ Private Member

        #region ■ Pricate Const
        const string ct_Extr_Top = "最初から";
        const string ct_Extr_End = "最後まで";
        const string ct_Space = "　";
        #endregion ■ Pricate Const

        #region ■ Public Property
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataSet CarShipListDs
        {
            get { return this._carShipListDs; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 入金データ取得
        /// <summary>
        /// 仕入データ取得
        /// </summary>
        /// <param name="modelShip">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入データを取得する。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int SearchCarShipProcMain(ModelShipRsltListCndtn modelShip, out string errMsg)
        {
            return this.SearchModelShipProc(modelShip, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// 仕入データ取得
        /// </summary>
        /// <param name="modelShipCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入データを取得する。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// <br>Update Note: 2010/05/08 王海立 REDMINE #7109の対応</br>
        /// </remarks>
        private int SearchModelShipProc(ModelShipRsltListCndtn modelShipCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSYA02205EA.CreateDataTable(ref this._carShipListDs);

                // 抽出条件展開  --------------------------------------------------------------
                ModelShipRsltCndtnWork modelShipRsltCndtnWork = new ModelShipRsltCndtnWork();
                status = this.DevCarShip(modelShipCndtn, out modelShipRsltCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object ModelShipResultWork = null;
                status = this._iModelShipResultDB.Search(out ModelShipResultWork, (object)modelShipRsltCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList modelShipResultList = ModelShipResultWork as ArrayList;

                        // --- ADD 2010/05/08 ---------->>>>>
                        //結合マスタの結合先品番（優良品番）と結合先メーカー（優良メーカー）の設定
                        SetJoinPartsInfo(modelShipCndtn, ref modelShipResultList, out errMsg);

                        // --- DEL 2010/05/13 ---------->>>>>
                        //object retWork = modelShipResultList as object;
                        //this._iModelShipResultDB.SearchStock(ref retWork, modelShipCndtn.WarehouseCode);
                        //modelShipResultList = retWork as ArrayList;
                        // --- DEL 2010/05/13 ----------<<<<<
                        // --- ADD 2010/05/08 ----------<<<<<

                        //集計単位の中で売上単価(税抜,不動)が異なるものが存在する場合は、０をセットする
                        DifUnPrcSetZeroWithGroupBy(ref modelShipResultList, modelShipCndtn);

                        // データ展開処理
                        DevCarShipMainData(modelShipCndtn, this._carShipListDs.Tables[PMSYA02205EA.Tbl_ModelShipListData], modelShipResultList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "型式別出荷実績表の帳票出力データの取得に失敗しました。";
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

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="modelShipCndtn">UI抽出条件クラス</param>
        /// <param name="modelShipRsltCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevCarShip(ModelShipRsltListCndtn modelShipCndtn, out ModelShipRsltCndtnWork modelShipRsltCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            modelShipRsltCndtnWork = new ModelShipRsltCndtnWork();
            try
            {
                // 企業コード 
                modelShipRsltCndtnWork.EnterpriseCode = modelShipCndtn.EnterpriseCode;
                // 拠点コードリスト
                modelShipRsltCndtnWork.SectionCodeList = modelShipCndtn.SectionCodeList;
                // 集計方法
                modelShipRsltCndtnWork.GroupBySectionDiv = (int)modelShipCndtn.GroupBySectionDiv;
                // 売上日(開始)
                modelShipRsltCndtnWork.SalesDateSt = modelShipCndtn.SalesDateSt;
                // 売上日(終了)
                modelShipRsltCndtnWork.SalesDateEd = modelShipCndtn.SalesDateEd;
                // 入力日(開始)
                modelShipRsltCndtnWork.InputDateSt = modelShipCndtn.InputDateSt;
                // 入力日(終了)
                modelShipRsltCndtnWork.InputDateEd = modelShipCndtn.InputDateEd;
                // 在庫取寄せ区分
                modelShipRsltCndtnWork.RsltTtlDiv = (int)modelShipCndtn.RsltTtlDiv;
                // 改頁
                modelShipRsltCndtnWork.NewPageDiv = (int)modelShipCndtn.NewPageDiv;

                //車種メーカーコード
                modelShipRsltCndtnWork.CarMakerCodeSt = modelShipCndtn.CarMakerCodeSt;
                modelShipRsltCndtnWork.CarMakerCodeEd = modelShipCndtn.CarMakerCodeEd;

                //車種コード
                modelShipRsltCndtnWork.CarModelCodeSt = modelShipCndtn.CarModelCodeSt;
                modelShipRsltCndtnWork.CarModelCodeEd = modelShipCndtn.CarModelCodeEd;

                //車種サブコード
                modelShipRsltCndtnWork.CarModelSubCodeSt = modelShipCndtn.CarModelSubCodeSt;
                modelShipRsltCndtnWork.CarModelSubCodeEd = modelShipCndtn.CarModelSubCodeEd;

                //代表型式
                modelShipRsltCndtnWork.ModelName = modelShipCndtn.ModelName;

                // 代表型式抽出区分
                modelShipRsltCndtnWork.ModelOutDiv = (int)modelShipCndtn.ModelOutDiv;

                //メーカー
                modelShipRsltCndtnWork.MakerCodeSt = modelShipCndtn.MakerCodeSt;
                modelShipRsltCndtnWork.MakerCodeEd = modelShipCndtn.MakerCodeEd;

                //BL商品コード
                modelShipRsltCndtnWork.BLGoodsCodeSt = modelShipCndtn.BLGoodsCodeSt;
                modelShipRsltCndtnWork.BLGoodsCodeEd = modelShipCndtn.BLGoodsCodeEd;

                //倉庫コード
                modelShipRsltCndtnWork.WarehouseCode = modelShipCndtn.WarehouseCode;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        #endregion ◎ 抽出条件展開処理

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
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
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

        /// <summary>
        /// 帳票設定データ取得処理
        /// </summary>
        /// <param name="modelShipResultList">UI抽出条件クラス</param>
        /// <param name="carShipRsltDt">carShipRsltDt</param>
        /// <param name="carShipRsltWork">取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// <br>Update Note: 2010/05/08 王海立 REDMINE #7109の対応</br>
        /// </remarks>
        private void DevCarShipMainData(ModelShipRsltListCndtn modelShipResultList, DataTable carShipRsltDt, ArrayList carShipRsltWork)
        {
            DataRow dr;
            ModelShipResultWork disCarShipResultWork = null;
            ModelShipResultWork nextDisCarShipResultWork = null;
            ModelShipResultWork lastDisCarShipResultWork = null;
            int count = carShipRsltWork.Count;
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                disCarShipResultWork = (ModelShipResultWork)carShipRsltWork[i];
                // --- ADD 2010/05/08 ---------->>>>>
                // 表示フラグ「1:表示しない」の場合、印刷しない
                if (disCarShipResultWork.IsShowFlg == 1)
                {
                    continue;
                }
                // --- ADD 2010/05/08 ----------<<<<<
                if (i + 1 < count)
                {
                    nextDisCarShipResultWork = (ModelShipResultWork)carShipRsltWork[i + 1];
                }
                dr = carShipRsltDt.NewRow();
                //実績計上拠点コード
                dr[PMSYA02205EA.ct_Col_ResultsAddUpSecCdRF] = disCarShipResultWork.ResultsAddUpSecCd;
                //拠点ガイド略称
                if (string.IsNullOrEmpty(disCarShipResultWork.SectionGuideSnm))
                {
                    dr[PMSYA02205EA.ct_Col_SectionGuideSnmRF] = "未登録";
                }
                else
                {
                    dr[PMSYA02205EA.ct_Col_SectionGuideSnmRF] = disCarShipResultWork.SectionGuideSnm;
                }
                //メーカーコード
                dr[PMSYA02205EA.ct_Col_MakerCodeRF] = disCarShipResultWork.MakerCode;
                //車種コード
                dr[PMSYA02205EA.ct_Col_ModelCodeRF] = disCarShipResultWork.ModelCode;
                //車種サブコード
                dr[PMSYA02205EA.ct_Col_ModelSubCodeRF] = disCarShipResultWork.ModelSubCode;
                //車種半角名称
                dr[PMSYA02205EA.ct_Col_ModelHalfNameRF] = disCarShipResultWork.ModelHalfName;
                //型式（フル型）
                dr[PMSYA02205EA.ct_Col_FullModelRF] = disCarShipResultWork.FullModel;
                //BL商品コード
                // --- UPD 2010/05/16 ---------->>>>>
                //dr[PMSYA02205EA.ct_Col_BLGoodsCodeRF] = disCarShipResultWork.BLGoodsCode;
                dr[PMSYA02205EA.ct_Col_BLGoodsCodeRF] = string.Format("{0:D5}", disCarShipResultWork.BLGoodsCode);
                // --- UPD 2010/05/16 ----------<<<<<
                //BL商品コード名称（半角）
                if (string.IsNullOrEmpty(disCarShipResultWork.BLGoodsHalfName))
                {
                    dr[PMSYA02205EA.ct_Col_BLGoodsHalfNameRF] = "未登録";
                }
                else
                {
                    dr[PMSYA02205EA.ct_Col_BLGoodsHalfNameRF] = disCarShipResultWork.BLGoodsHalfName;
                }

                // --- UPD 2010/05/08 ---------->>>>>
                ////商品属性 0:純正 1:その他
                //if (disCarShipResultWork.GoodsKindCode == 0)
                //{
                //    //商品メーカーコード（純正）
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerCd1RF] = disCarShipResultWork.GoodsMakerCd;
                //    //商品メーカー名称（純正）
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerName1RF] = disCarShipResultWork.MakerName;
                //    //純正品番  商品属性が優良の場合は印字しない
                //    if (string.IsNullOrEmpty(disCarShipResultWork.JoinSourPartsNoWithH))
                //    {
                //        dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = disCarShipResultWork.GoodsNo;
                //    }
                //    else
                //    {
                //        dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = string.Empty;
                //    }
                //}
                ////商品メーカーコード（優良）
                //if (disCarShipResultWork.JoinSourceMakerCode != 0)
                //{
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = disCarShipResultWork.JoinDestMakerCd;
                //}
                //else
                //{
                //    dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = DBNull.Value;
                //}
                ////商品メーカー名称（優良）
                //dr[PMSYA02205EA.ct_Col_GoodsMakerName2RF] = disCarShipResultWork.MakerName2;
                ////対応品番
                //dr[PMSYA02205EA.ct_Col_GoodsNo2RF] = disCarShipResultWork.JoinSourPartsNoWithH;

                //商品属性 0:純正 1:その他
                if (disCarShipResultWork.GoodsKindCode == 0)
                {
                    //商品メーカーコード（純正）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerCd1RF] = disCarShipResultWork.GoodsMakerCd;
                    //商品メーカー名称（純正）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName1RF] = disCarShipResultWork.MakerName;
                    // --- UPD 2010/05/13 ---------->>>>>
                    ////純正品番  商品属性が優良の場合は印字しない
                    //if (string.IsNullOrEmpty(disCarShipResultWork.JoinDestPartsNo))
                    //{
                    //    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = disCarShipResultWork.GoodsNo;
                    //}
                    //else
                    //{
                    //    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = string.Empty;
                    //}
                    //純正品番
                    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = disCarShipResultWork.GoodsNo;
                    // --- UPD 2010/05/13 ----------<<<<<
                    //商品メーカーコード（優良）
                    if (disCarShipResultWork.JoinDestMakerCd != 0)
                    {
                        dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = disCarShipResultWork.JoinDestMakerCd;
                    }
                    else
                    {
                        dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = DBNull.Value;
                    }
                    //商品メーカー名称（優良）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName2RF] = disCarShipResultWork.MakerName2;
                    //対応品番
                    dr[PMSYA02205EA.ct_Col_GoodsNo2RF] = disCarShipResultWork.JoinDestPartsNo;
                }
                else
                {
                    //商品メーカーコード（純正）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerCd1RF] = string.Empty;
                    //商品メーカー名称（純正）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName1RF] = string.Empty;
                    //純正品番
                    dr[PMSYA02205EA.ct_Col_GoodsNo1RF] = string.Empty;
                    //商品メーカーコード（優良）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerCd2RF] = disCarShipResultWork.GoodsMakerCd;
                    //商品メーカー名称（優良）
                    dr[PMSYA02205EA.ct_Col_GoodsMakerName2RF] = disCarShipResultWork.MakerName;
                    //対応品番
                    dr[PMSYA02205EA.ct_Col_GoodsNo2RF] = disCarShipResultWork.GoodsNo;
                }
                // --- UPD 2010/05/08 ----------<<<<<

                //出荷数
                dr[PMSYA02205EA.ct_Col_ShipmentCntRF] = disCarShipResultWork.ShipmentCnt;
                //売上単価（税抜，浮動）
                dr[PMSYA02205EA.ct_Col_SalesUnPrcTaxExcFlRF] = disCarShipResultWork.SalesUnPrcTaxExcFl;
                //売上金額（税抜き）
                dr[PMSYA02205EA.ct_Col_SalesMoneyTaxExcRF] = disCarShipResultWork.SalesMoneyTaxExc;
                // --- UPD 2010/05/16 ---------->>>>>
                //// 在庫がない場合は印字しない
                //// --- UPD 2010/05/08 ---------->>>>>
                ////if (disCarShipResultWork.JoinSourceMakerCode != 0 )
                //if (disCarShipResultWork.SalesOrderDivCd != 0)
                //// --- UPD 2010/05/08 ----------<<<<<
                //{
                //    //倉庫棚番
                //    dr[PMSYA02205EA.ct_Col_WarehouseShelfNoRF] = disCarShipResultWork.WarehouseShelfNo;
                //    //仕入在庫数
                //    // --- UPD 2010/05/08 ---------->>>>>
                //    //dr[PMSYA02205EA.ct_Col_SupplierStockRF] = disCarShipResultWork.SupplierStock;
                //    if (disCarShipResultWork.SupplierStock != 0)
                //    {
                //        dr[PMSYA02205EA.ct_Col_SupplierStockRF] = disCarShipResultWork.SupplierStock;
                //    }
                //    else
                //    {
                //        dr[PMSYA02205EA.ct_Col_SupplierStockRF] = string.Empty;
                //    }
                //    // --- UPD 2010/05/08 ----------<<<<<
                //}
                //else
                //{
                //    //倉庫棚番
                //    dr[PMSYA02205EA.ct_Col_WarehouseShelfNoRF] = string.Empty;
                //    //仕入在庫数
                //    dr[PMSYA02205EA.ct_Col_SupplierStockRF] = string.Empty;
                //}

                //倉庫棚番
                dr[PMSYA02205EA.ct_Col_WarehouseShelfNoRF] = disCarShipResultWork.WarehouseShelfNo;
                //仕入在庫数
                dr[PMSYA02205EA.ct_Col_SupplierStockRF] = disCarShipResultWork.SupplierStock;
                // --- UPD 2010/05/16 ----------<<<<<

                //空白を処理する
                if (count > 1)
                {
                    if (i != 0)
                    {
                        lastDisCarShipResultWork = (ModelShipResultWork)carShipRsltWork[i - 1];
                    }

                    //毎ページに、第一行データをセットする
                    if (i == 0)
                    {
                        if ((int)modelShipResultList.GroupBySectionDiv == 0)
                        {
                            k++;
                        }
                    }
                }
                // TableにAdd
                carShipRsltDt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 集計単位の中で売上単価(税抜,不動)が異なるものが存在する場合は、０をセットするの処理
        /// </summary>
        /// <param name="modelShipResultList">抽出結果リスト</param>
        /// <param name="modelShipRsltListCndtn">modelShipRsltListCndtn</param>
        /// <remarks>
        /// <br>Note       : 集計単位の中で売上単価(税抜,不動)が異なるものが存在する場合は、０をセットする。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.04.23</br>
        /// </remarks>
        private void DifUnPrcSetZeroWithGroupBy(ref ArrayList modelShipResultList, ModelShipRsltListCndtn modelShipRsltListCndtn)
        {
            //車種
            string modeCd = string.Empty;
            //品番
            string partsNo = string.Empty;
            //フル型式
            string fullModel = string.Empty;
            //ＢＬコード
            string bLGoodsCode = string.Empty;
            //出荷メーカー
            string goodsMakerCd = string.Empty;

            string key = string.Empty;
            Hashtable hashtableWithGroupBy = new Hashtable();
            ArrayList arrayListWork = null;

            //抽出結果リストから集計単位の中で新しいHashtableを作成する
            foreach (ModelShipResultWork modelShipResultWork in modelShipResultList)
            {
                //車種
                modeCd = modelShipResultWork.MakerCode + "/" + modelShipResultWork.ModelCode + "/" + modelShipResultWork.ModelSubCode;
                //品番
                partsNo = modelShipResultWork.GoodsNo;
                //フル型式
                fullModel = modelShipResultWork.FullModel;
                //ＢＬコード
                bLGoodsCode = modelShipResultWork.BLGoodsCode.ToString();
                //出荷メーカー
                goodsMakerCd = modelShipResultWork.GoodsMakerCd.ToString();
                //車種メーカーコード、車種コード、車種サブコード、フル型式、ＢＬコード、出荷メーカー、出荷品番
                key = modeCd + "/" + partsNo + "/" + fullModel + "/" + bLGoodsCode + "/" + goodsMakerCd;
                if (modelShipRsltListCndtn.GroupBySectionDiv != 0)
                {
                    //実績計上拠点コード
                    key += "/" + modelShipResultWork.ResultsAddUpSecCd;
                }

                if (hashtableWithGroupBy.ContainsKey(key))
                {
                    arrayListWork = (ArrayList)hashtableWithGroupBy[key];
                    arrayListWork.Add(modelShipResultWork);
                }
                else
                {
                    arrayListWork = new ArrayList();
                    arrayListWork.Add(modelShipResultWork);
                    hashtableWithGroupBy.Add(key, arrayListWork);
                }
            }

            //異なるものが存在する場合は、０をセットする
            foreach (ArrayList temp in hashtableWithGroupBy.Values)
            {
                //車輌部品データ.売単価
                double salesUnPrcTaxExcFl = 0;
                bool isZero = false;
                int cnt = 0;
                foreach (ModelShipResultWork tempModelShipResultWork in temp)
                {
                    if (cnt == 0 && salesUnPrcTaxExcFl != tempModelShipResultWork.SalesUnPrcTaxExcFl)
                    {
                        salesUnPrcTaxExcFl = tempModelShipResultWork.SalesUnPrcTaxExcFl;
                    }
                    else if (cnt != 0 && salesUnPrcTaxExcFl != tempModelShipResultWork.SalesUnPrcTaxExcFl)
                    {
                        isZero = true;
                        break;
                    }
                    cnt++;
                }
                // --- UPD 2010/05/08 ---------->>>>>
                //if (isZero)
                //{
                //    foreach (ModelShipResultWork tempModelShipResultWork in temp)
                //    {
                //        tempModelShipResultWork.SalesUnPrcTaxExcFl = 0;
                //    }
                //}

                // 数量合計
                double sumCnt = 0;
                // 金額合計
                long sumMoney = 0;
                // 循環計数
                int cycleNum = 0;

                // 集計単位の中で、一つだけデータを保留する
                foreach (ModelShipResultWork tempModelShipResultWork in temp)
                {
                    sumCnt += tempModelShipResultWork.ShipmentCnt;
                    sumMoney += tempModelShipResultWork.SalesMoneyTaxExc;
                    if (cycleNum != 0)
                    {
                        // 集計単位の中で、一つだけデータを印刷するのため、表示フラグを設定する
                        tempModelShipResultWork.IsShowFlg = 1;
                    }
                    cycleNum++;
                }

                // 数量、売単価と金額の再設定
                ModelShipResultWork newWork = (ModelShipResultWork)temp[0];
                if (isZero)
                {
                    newWork.SalesUnPrcTaxExcFl = 0;
                }
                newWork.ShipmentCnt = sumCnt;
                newWork.SalesMoneyTaxExc = sumMoney;
                // --- UPD 2010/05/08 ----------<<<<<
            }
        }

        // --- ADD 2010/05/08 ---------->>>>>
        /// <summary>
        /// 結合マスタの結合先品番（優良品番）と結合先メーカー（優良メーカー）の設定
        /// </summary>
        /// <param name="modelShipCndtn">UI抽出条件</param>
        /// <param name="workList">抽出結果リスト</param>
        /// <param name="msg">結果メッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタの結合先品番（優良品番）と結合先メーカー（優良メーカー）を設定する。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.05.08</br>
        /// </remarks>
        private void SetJoinPartsInfo(ModelShipRsltListCndtn modelShipCndtn, ref ArrayList workList, out string msg)
        {
            msg = string.Empty;

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            //GoodsAcs _goodsAcs = new GoodsAcs();//DEL 2010/05/13
            goodsCndtn.EnterpriseCode = modelShipCndtn.EnterpriseCode;

            ModelShipResultWork modelShipResultWork = null;
            // 結合表示順位より、結合マスタ
            Hashtable orderJoinPartsMap = null;

            foreach (ModelShipResultWork work in workList)
            {
                // 商品種別が 0:純正、倉庫コードが１以上の場合
                if (work.GoodsKindCode != 0 || modelShipCndtn.WarehouseCode.CompareTo("000001") < 0)
                {
                    continue;
                }
                work.EnterpriseCode = modelShipCndtn.EnterpriseCode;

                orderJoinPartsMap = new Hashtable();

                goodsCndtn.SectionCode = work.ResultsAddUpSecCd;
                goodsCndtn.GoodsNo = work.GoodsNo;
                goodsCndtn.GoodsMakerCd = work.GoodsMakerCd;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;

                goodsCndtn.IsSettingSupplier = 1;
                goodsCndtn.IsSettingVariousMst = 1;

                // 結合マスタ（提供分）の取得
                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> GoodsUnitDataList;

                int status = _goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, false, out partsInfoDataSet, out GoodsUnitDataList, out msg);


                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // --- DEL 2010/05/13 ---------->>>>>
                    //ArrayList partsMakerCdList = new ArrayList();
                    //// 優良設定マスタの取得
                    //foreach (DataRow dr in partsInfoDataSet.OfrPrimeParts.Rows)
                    //{
                    //    partsMakerCdList.Add((int)dr["PartsMakerCd"]);
                    //}

                    //// 結合表示順位より、優良設定マスタに登録されている結合マスタ（提供分）を追加する
                    //if (partsMakerCdList.Count > 0)
                    //{
                    // --- DEL 2010/05/13 ----------<<<<<
                    foreach (DataRow dr in partsInfoDataSet.JoinParts.Rows)
                    {
                        // --- DEL 2010/05/13 ---------->>>>>
                        //if (partsMakerCdList.Contains((int)dr["JoinDestMakerCd"]))
                        //{
                        // --- DEL 2010/05/13 ----------<<<<<
                        modelShipResultWork = new ModelShipResultWork();
                        //結合先メーカーコード
                        modelShipResultWork.JoinDestMakerCd = (int)dr["JoinDestMakerCd"];
                        //結合先品番(－付き品番)
                        modelShipResultWork.JoinDestPartsNo = dr["JoinDestPartsNo"].ToString();
                        if (!orderJoinPartsMap.ContainsKey((int)dr["JoinDispOrder"]))
                        {
                            orderJoinPartsMap.Add((int)dr["JoinDispOrder"], modelShipResultWork);
                        }
                        //}//DEL 2010/05/13
                    }
                    //}//DEL 2010/05/13

                    // 結合マスタ（ユーザー登録分）の取得
                    // 結合表示順位より、結合マスタ（ユーザー登録分）を追加する
                    foreach (DataRow dr in partsInfoDataSet.UsrJoinParts.Rows)
                    {
                        modelShipResultWork = new ModelShipResultWork();
                        // 結合先メーカーコード
                        modelShipResultWork.JoinDestMakerCd = (int)dr["JoinDestMakerCd"];
                        // 結合先品番(－付き品番)
                        modelShipResultWork.JoinDestPartsNo = dr["JoinDestPartsNo"].ToString();
                        if (!orderJoinPartsMap.ContainsKey((int)dr["JoinDispOrder"]))
                        {
                            orderJoinPartsMap.Add((int)dr["JoinDispOrder"], modelShipResultWork);
                        }
                    }
                }

                // 結合表示順位より、結合マスタを抽出結果に設定する
                if (orderJoinPartsMap != null && orderJoinPartsMap.Count > 0)
                {
                    ArrayList keyList = new ArrayList();
                    foreach(int key in orderJoinPartsMap.Keys)
                    {
                        keyList.Add(key);
                    }
                    keyList.Sort();
                    // --- UPD 2010/05/13 ---------->>>>>
                    //ModelShipResultWork newWork = (ModelShipResultWork)orderJoinPartsMap[(int)keyList[0]];
                    //work.JoinDestMakerCd = newWork.JoinDestMakerCd;
                    //work.JoinDestPartsNo = newWork.JoinDestPartsNo;

                    ArrayList newWorkList = new ArrayList();
                    foreach(int key in keyList)
                    {
                        newWorkList.Add((ModelShipResultWork)orderJoinPartsMap[key]);
                    }

                    object retWork = newWorkList as object;
                    this._iModelShipResultDB.SearchStock(ref retWork, modelShipCndtn.EnterpriseCode, modelShipCndtn.WarehouseCode);
                    newWorkList = retWork as ArrayList;

                    if (newWorkList.Count > 0)
                    {
                        ModelShipResultWork newWork = (ModelShipResultWork)newWorkList[0];
                        work.JoinDestMakerCd = newWork.JoinDestMakerCd;
                        work.JoinDestPartsNo = newWork.JoinDestPartsNo;

                        MakerUMnt maker = null;
                        _goodsAcs.GetMaker(modelShipCndtn.EnterpriseCode, work.JoinDestMakerCd, out maker);
                        if (maker != null)
                        {
                            //work.MakerName2 = maker.MakerKanaName;//// DEL 2010.05.19 zhangsf FOR Redmine #7784
                            work.MakerName2 = maker.MakerName;//// ADD 2010.05.19 zhangsf FOR Redmine #7784
                        }
                    }
                    // --- UPD 2010/05/13 ----------<<<<<
                }
            }
        }
        // --- ADD 2010/05/08 ----------<<<<<

        #endregion ■ Private Method

    }
}
