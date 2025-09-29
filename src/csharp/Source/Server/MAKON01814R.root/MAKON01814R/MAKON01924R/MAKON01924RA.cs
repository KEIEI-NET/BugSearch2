using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;  //ADD 2009/01/30
using Broadleaf.Application.Common;
using Broadleaf.Library;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;  //ADD 2008/08/25 M.Kubota
using System.Diagnostics;             //ADD 2008/08/25 M.Kubota

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// IOWrite在庫更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : IOWriteにて在庫系の更新処理をまとめて行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.01.25</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: 売上時自動受託計上処理の追加</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.09</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: 返品時の在庫更新パラメータ作成処理</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.06.06</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS用に修正</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.11</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: PM.NS用に修正</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.08.25</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: 受払の作成処理を修正</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2009/01/30</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: Redmine#44885対応</br>
    /// <br>             商品在庫マスタ登録時にエラーが発生する</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/04/08</br>
    /// <br>------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    //public class IOWriteMASIRStockUpdateDB : RemoteDB//, IFunctionCallTargetWrite
    public class IOWriteMASIRStockUpdateDB : RemoteWithAppLockDB//, IFunctionCallTargetWrite
    {
        private SecInfoSetDB _secInfoSetDB = null;
        private Hashtable _secInfoSeTtable = null;

        //--- ADD 2009/01/30 --->>>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// 売上・仕入制御オプション プロパティ
        /// </summary>
        public IOWriteCtrlOptWork IOWriteCtrlOptWork
        {
            get
            {
                if (this._CtrlOptWork == null)
                {
                    this._CtrlOptWork = new IOWriteCtrlOptWork();
                }

                return this._CtrlOptWork;
            }
        }

        /// <summary>
        /// IOWrite在庫更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="ioWriteCtrlOptWork">売上・仕入制御オプション プロパティ</param>
        /// <remarks>
        /// <br>Note       : 特に無し</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public IOWriteMASIRStockUpdateDB(IOWriteCtrlOptWork ioWriteCtrlOptWork)
            : base()
        {
            this._CtrlOptWork = ioWriteCtrlOptWork;
        }
        //--- ADD 2009/01/30 ---<<<

        # region [--- DEL 2009/01/30 ---]
        ///// <summary>
        ///// IOWrite在庫更新リモートオブジェクトクラスコンストラクタ
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 特に無し</br>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.01.25</br>
        ///// </remarks>
        //public IOWriteMASIRStockUpdateDB()
        //{
        //}
        #endregion

        /// <summary>
        /// 拠点設定マスタ取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="secinfoSetWorkHash"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetSecInfoSetWork(string enterpriseCode, out Hashtable secinfoSetWorkHash, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (this._secInfoSeTtable == null)
            {
                secinfoSetWorkHash = new Hashtable();

                SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    return status;
                }
                else
                {
                    secInfoSetWork.EnterpriseCode = enterpriseCode;
                }

                ArrayList secInfoList = new ArrayList();

                //拠点設定Seach呼び出し
                if (this._secInfoSetDB == null)
                {
                    this._secInfoSetDB = new SecInfoSetDB();
                }

                status = this._secInfoSetDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //拠点名称をHashTableに格納
                    foreach (SecInfoSetWork sec in secInfoList)
                    {
                        //secinfoSetWorkHash.Add(sec.SectionCode, sec.SectionGuideNm);       //DEL 2009/01/13 M.Kubota
                        secinfoSetWorkHash.Add(sec.SectionCode.Trim(), sec.SectionGuideNm);  //ADD 2009/01/13 M.Kubota
                    }
                }
            }
            else
            {
                // 既に拠点名称が取得されている場合は読み込まない
                secinfoSetWorkHash = this._secInfoSeTtable;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;                
            }

            return status;
        }

        # region [取り合えず削除]

        #region [製番在庫ステータスチェック処理]

        ///// <summary>
        ///// 製造番号の状態チェックのための共通クラス作成処理
        ///// </summary>
        ///// <param name="productStockCommonParaList">製番在庫共通クラスList</param>
        ///// <param name="productStockWorkList">製番在庫クラスList</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 製造番号の状態チェックのための共通クラス作成処理</br>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.05.31</br>
        //private int MakeProductCommonPara(out ArrayList productStockCommonParaList, ArrayList productStockWorkList)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    productStockCommonParaList = new ArrayList();

        //    //製番在庫パラメータ
        //    ProductStockWork productStockWork = null;
        //    ProductStockCommonPara productStockCommonPara = null;

        //    //●ProductStockCommonParaの生成
        //    for (int i = 0; i < productStockWorkList.Count; i++)
        //    {
        //        productStockWork = new ProductStockWork();
        //        productStockCommonPara = new ProductStockCommonPara();

        //        productStockWork = productStockWorkList[i] as ProductStockWork;

        //        if (productStockWork.ProductStockGuid.ToString() == null || productStockWork.ProductStockGuid == Guid.Empty) continue;

        //        //製番在庫データ　→　製番在庫書込結果データ
        //        productStockCommonPara.EnterpriseCode = productStockWork.EnterpriseCode;
        //        productStockCommonPara.FileHeaderGuid = productStockWork.FileHeaderGuid;
        //        productStockCommonPara.GoodsCode = productStockWork.GoodsCode;
        //        productStockCommonPara.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
        //        productStockCommonPara.LogicalDeleteCode = productStockWork.LogicalDeleteCode;
        //        productStockCommonPara.MakerCode = productStockWork.MakerCode;
        //        productStockCommonPara.MoveStatus = productStockWork.MoveStatus;
        //        productStockCommonPara.ProcResultState = 0;
        //        productStockCommonPara.ProductNumber = productStockWork.ProductNumber;
        //        productStockCommonPara.ProductStockGuid = productStockWork.ProductStockGuid;
        //        productStockCommonPara.SectionCode = productStockWork.SectionCode;
        //        productStockCommonPara.StockDiv = productStockWork.StockDiv;
        //        productStockCommonPara.StockState = productStockWork.StockState;
        //        productStockCommonPara.StockTelNo1 = productStockWork.StockTelNo1;
        //        productStockCommonPara.StockTelNo2 = productStockWork.StockTelNo2;
        //        productStockCommonPara.UpdateDateTime = productStockWork.UpdateDateTime;
        //        productStockCommonPara.UpdEmployeeCode = productStockWork.UpdEmployeeCode;

        //        productStockCommonParaList.Add(productStockCommonPara);
        //    }

        //    return status;

        //}

        ///// <summary>
        ///// 製造番号の在庫状態をチェックします
        ///// </summary>
        ///// <param name="productStockCommonParaList">製番在庫共通クラスList</param>
        ///// <param name="stockSlipWork">仕入データクラス</param>
        ///// <param name="retMsg">メッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 製造番号の在庫状態をチェックします</br>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.05.31</br>
        //private int CheckProductNumStatus(ArrayList productStockCommonParaList, StockSlipWork stockSlipWork, out string retMsg)
        //{
        //    //●パラメータ初期化
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    ProductStockCommonPara productStockCommon = null;
        //    //ProductStockWork productStockWork = null;
        //    retMsg = null;
        //    string message = "在庫状態が変更されています : ";

        //    #region [param check]
        //    for (int i = 0; i < productStockCommonParaList.Count; i++)
        //    {
        //        productStockCommon = productStockCommonParaList[i] as ProductStockCommonPara;
        //        // 製番が登録されている商品のみチェックする
        //        if (productStockCommon.ProductNumber == "" || productStockCommon.ProductNumber == null) continue;

        //        // 通常仕入
        //        if (stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //        {
        //            //①仕入伝票修正
        //            if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SupplierStock)
        //                {
        //                    // add 2007.07.17 saito
        //                    if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Deletion &&
        //                        productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods &&
        //                        productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SalesAddUp)
        //                    {
        //                        retMsg = message + productStockCommon.ProductNumber.ToString();
        //                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                        break;
        //                    }
        //                }
        //            }
        //            //②仕入の返品作成(新規返品伝票)
        //            else if (stockSlipWork.CreateDateTime == DateTime.MinValue &&
        //                     stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SupplierStock)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //③仕入の赤伝作成
        //            else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SupplierStock)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //④返品の修正
        //            else if (stockSlipWork.CreateDateTime > DateTime.MinValue &&
        //                     stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑤受託修正
        //            else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    // add 2007.07.17 saito
        //                    if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Deletion &&
        //                        productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods &&
        //                        productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SalesAddUp)
        //                    {
        //                        retMsg = message + productStockCommon.ProductNumber.ToString();
        //                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                        break;
        //                    }
        //                }
        //            }
        //            //⑥受託の返品作成(新規返品伝票)
        //            else if (stockSlipWork.CreateDateTime == DateTime.MinValue &&
        //                     stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑦受託の赤伝作成
        //            else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑧受託の返品伝票修正
        //            else if (stockSlipWork.CreateDateTime > DateTime.MinValue &&
        //                     stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //        }
        //        // 受託計上仕入
        //        else if (stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
        //        {
        //            //⑨新規受託計上仕入
        //            if (stockSlipWork.CreateDateTime == DateTime.MinValue &&
        //                stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑩受託計上仕入(修正)
        //            else if (stockSlipWork.CreateDateTime > DateTime.MinValue &&
        //                     stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                     stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SupplierStock)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    #endregion

        //    return status;
        //}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.03.04
        ///// <summary>
        ///// 返品時の在庫パラメータ作成処理（在庫検索からの返品処理に対応）
        ///// </summary>
        ///// <param name="paraList"></param>
        ///// <param name="stockList">在庫ワークList</param>
        ///// <param name="productStockCommonList">製番在庫共通ワークList</param>
        ///// <param name="position">仕入データ位置</param>
        ///// <param name="detailPosition">仕入明細データ位置</param>
        ///// <returns></returns>
        //private int MakeReturnStockPara(CustomSerializeArrayList paraList, out ArrayList stockList, ArrayList productStockCommonList, Int32 position, Int32 detailPosition)
        //{
        //    //出力パラメータList(在庫)
        //    stockList = new ArrayList();

        //    //更新パラメータクラス格納用(在庫)
        //    StockWork stockWork = null;

        //    //仕入データワーク格納用(ヘッダ・明細)
        //    StockSlipWork wkStockSlipWork = paraList[position] as StockSlipWork;
        //    StockDetailWork dtlwork = null;
        //    //StockExplaDataWork wkStockExplaDataWork = null;        //DEL 2007/09/11 M.Kubota
        //    //ProductStockCommonPara productStockCommonPara = null;  //DEL 2007/09/11 M.Kubota
        //    ArrayList wkStockDetailWorkList = paraList[detailPosition] as ArrayList;
        //    //ArrayList wkStockExplaDataWorkList = null;             //DEL 2007/09/11 M.Kubota
            
        //    //--- DEL 2007/09/11 M.Kubota --->>>
        //    //仕入詳細データ
        //    //for (int i = 0; i < paraList.Count; i++)
        //    //{
        //    //    if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockExplaDataWork)
        //    //    {
        //    //        wkStockExplaDataWorkList = paraList[i] as ArrayList;
        //    //    }
        //    //}
        //    //--- DEL 2007/09/11 M.Kubota ---<<<

        //    //データ比較クラス(在庫)
        //    StockWorkSecComparer stockWorkSecComparer = new StockWorkSecComparer();

        //    //●在庫マスタ更新パラメータ格納処理
        //    #region[在庫マスタ更新パラメータ格納]
        //    for (int i = 0; i < wkStockDetailWorkList.Count; i++)
        //    {
        //        dtlwork = wkStockDetailWorkList[i] as StockDetailWork;

        //        stockWork = new StockWork();

        //        //在庫管理有無区分・仕入在庫取寄区分・仕入数のチェック
        //        if (dtlwork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
        //            (dtlwork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && dtlwork.StockOrderDivCd == 0) ||
        //            dtlwork.StockCount == 0) continue;

        //        //--- DEL 2007/09/11 M.Kubota --->>>
        //        //拠点コード
        //        //for (int x = 0; x < wkStockExplaDataWorkList.Count; x++)
        //        //{
        //        //    wkStockExplaDataWork = wkStockExplaDataWorkList[x] as StockExplaDataWork;

        //        //    if (wkAddUppOrgStockDetailWork.StockRowNo == wkStockExplaDataWork.StockRowNo)
        //        //    {
        //        //        for (int y = 0; y < productStockCommonList.Count; y++)
        //        //        {
        //        //            productStockCommonPara = productStockCommonList[y] as ProductStockCommonPara;

        //        //            if (wkStockExplaDataWork.ProductStockGuid == productStockCommonPara.ProductStockGuid)
        //        //            {
        //        //                stockWork.SectionCode = productStockCommonPara.SectionCode; //製番在庫マスタに登録されている拠点コード
        //        //            }
        //        //        }
        //        //    }
        //        //}

        //        //if (stockWork.SectionCode == null || stockWork.SectionCode == "")
        //        //{
        //        //    stockWork.SectionCode = wkStockSlipWork.StockUpdateSecCd;
        //        //}
        //        //--- DEL 2007/09/11 M.Kubota ---<<<

        //        //仕入ヘッダ　→　在庫マスタ
        //        stockWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;     //企業コード
        //        stockWork.SectionCode = wkStockSlipWork.StockUpdateSecCd;      //在庫更新拠点コード
        //        stockWork.LastStockDate = wkStockSlipWork.StockDate;           //最終仕入年月日　←　仕入日

        //        //仕入明細　→　在庫マスタ
        //        stockWork.GoodsMakerCd = dtlwork.GoodsMakerCd;                  // 商品メーカーコード
        //        stockWork.MakerName = dtlwork.MakerName;                        // メーカー名称
        //        stockWork.GoodsNo = dtlwork.GoodsNo;                            // 商品番号
        //        stockWork.GoodsName = dtlwork.GoodsName;                        // 商品名称
        //        stockWork.LargeGoodsGanreCode = dtlwork.LargeGoodsGanreCode;    // 商品区分グループコード
        //        stockWork.LargeGoodsGanreName = dtlwork.LargeGoodsGanreName;    // 商品区分グループ名称
        //        stockWork.MediumGoodsGanreCode = dtlwork.MediumGoodsGanreCode;  // 商品区分コード
        //        stockWork.MediumGoodsGanreName = dtlwork.MediumGoodsGanreName;  // 商品区分名称
        //        stockWork.DetailGoodsGanreCode = dtlwork.DetailGoodsGanreCode;  // 商品区分詳細コード
        //        stockWork.DetailGoodsGanreName = dtlwork.DetailGoodsGanreName;  // 商品区分詳細名称
        //        stockWork.StockUnitPriceFl = dtlwork.StockUnitPriceFl;          // 仕入単価
        //        stockWork.BLGoodsCode = dtlwork.BLGoodsCode;                    // BL商品コード
        //        stockWork.BLGoodsFullName = dtlwork.BLGoodsFullName;            // BL商品コード名称(全角)
        //        stockWork.EnterpriseGanreCode = dtlwork.EnterpriseGanreCode;    // 自社分類コード
        //        stockWork.EnterpriseGanreName = dtlwork.EnterpriseGanreName;    // 自社分類コード名称(全角)
        //        stockWork.WarehouseCode = dtlwork.WarehouseCode;                // 倉庫コード
        //        stockWork.WarehouseName = dtlwork.WarehouseName;                // 倉庫名称
        //        stockWork.WarehouseShelfNo = dtlwork.WarehouseShelfNo;          // 倉庫棚番

        //        /*--- DEL 2007/09/11 M.Kubota --->>>
        //        stockWork.MakerName = wkAddUppOrgStockDetailWork.MakerName;            //メーカー名称
        //        stockWork.GoodsName = wkAddUppOrgStockDetailWork.GoodsName;            //商品名称
        //        //stockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;  //仕入単価
        //        stockWork.CarrierCode = wkAddUppOrgStockDetailWork.CarrierCode;        //キャリアコード
        //        stockWork.CarrierName = wkAddUppOrgStockDetailWork.CarrierName;        //キャリア名称
        //        stockWork.SystematicColorCd = wkAddUppOrgStockDetailWork.SystematicColorCd;    //系統色コード
        //        stockWork.SystematicColorNm = wkAddUppOrgStockDetailWork.SystematicColorNm;    //系統色名称
        //        stockWork.LargeGoodsGanreCode = wkAddUppOrgStockDetailWork.LargeGoodsGanreCode;    //商品大分類コード
        //        stockWork.MediumGoodsGanreCode = wkAddUppOrgStockDetailWork.MediumGoodsGanreCode;  //商品中分類コード
        //        stockWork.PrdNumMngDiv = wkAddUppOrgStockDetailWork.PrdNumMngDiv;        //製番管理区分
        //        stockWork.CellphoneModelCode = wkAddUppOrgStockDetailWork.CellphoneModelCode;    //機種コード
        //        stockWork.CellphoneModelName = wkAddUppOrgStockDetailWork.CellphoneModelName;    //機種名称

        //        stockWork.MakerCode = wkAddUppOrgStockDetailWork.MakerCode;            //メーカーコード
        //        stockWork.GoodsCode = wkAddUppOrgStockDetailWork.GoodsCode;            //商品コード
        //         --- DEL 2007/09/11 M.Kubota ---<<<*/

        //        //仕入在庫数・入荷数の加減算処理
                
        //        //在庫パラメータListにデータがある時
        //        if (stockList.Count > 0)
        //        {
        //            stockList.Sort(stockWorkSecComparer);
        //            int indexCount = stockList.BinarySearch(stockWork, stockWorkSecComparer);

        //            //メーカーコード・商品コード・拠点コードが同一のデータがある時
        //            if (indexCount >= 0 && indexCount <= wkStockDetailWorkList.Count)
        //            {
        //                stockWork = stockList[indexCount] as StockWork;
        //            }
        //        }

        //        // 仕入単価
        //        stockWork.StockUnitPriceFl = dtlwork.StockUnitPriceFl;

        //        //返品
        //        if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
        //        {
        //            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
        //            {
        //                stockWork.SupplierStock += dtlwork.StockCountDifference;
        //            }
        //            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
        //            {
        //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.07
        //                //stockWork.TrustCount += dtlwork.StockCountDifference;
        //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.07
        //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.07
        //                stockWork.ArrivalCnt += dtlwork.StockCountDifference;
        //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.07
        //            }
        //        }
        //        //計上処理  (ここに来ることあるのか？)
        //        else
        //        {
        //            stockWork.SupplierStock += dtlwork.StockCountDifference;
        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.07
        //            //stockWork.TrustCount -= dtlwork.StockCountDifference;
        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.07
        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.07
        //            stockWork.ArrivalCnt -= dtlwork.StockCountDifference;
        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.07
        //        }

        //        stockList.Add(stockWork);

        //        /*--- DEL 2007/09/11 M.Kubota --->>>
        //        //在庫パラメータListにデータがある時
        //        if (stockList.Count > 0)
        //        {
        //            stockList.Sort(stockWorkSecComparer);
        //            indexCount = stockList.BinarySearch(stockWork, stockWorkSecComparer);

        //            //メーカーコード・商品コード・拠点コードが同一のデータがある時
        //            if (indexCount >= 0 && indexCount <= wkStockDetailWorkList.Count)
        //            {
        //                stockWork = stockList[indexCount] as StockWork;

        //                // add 2007.06.08 saito
        //                //stockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;    //仕入単価  //DEL 2007/09/11 M.Kubota
        //                stockWork.StockUnitPriceFl = wkAddUppOrgStockDetailWork.StockUnitPriceFl;  //仕入単価  //ADD 2007/09/11 M.Kubota

        //                //返品
        //                if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
        //                {
        //                    if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
        //                        stockWork.SupplierStock += wkAddUppOrgStockDetailWork.StockCount;
        //                    else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
        //                        stockWork.TrustCount += wkAddUppOrgStockDetailWork.StockCount;
        //                }
        //                //計上処理
        //                else
        //                {
        //                    stockWork.SupplierStock += wkAddUppOrgStockDetailWork.StockCount;
        //                    stockWork.TrustCount += -wkAddUppOrgStockDetailWork.StockCount;
        //                }

        //                stockList.Add(stockWork);
        //            }
        //            else
        //            {
        //                // add 2007.06.08 saito
        //                stockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;      //仕入単価
                        
        //                //返品
        //                if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
        //                {
        //                    if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
        //                        stockWork.SupplierStock += wkAddUppOrgStockDetailWork.StockCount;
        //                    else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
        //                        stockWork.TrustCount += wkAddUppOrgStockDetailWork.StockCount;
        //                }
        //                //計上処理
        //                else
        //                {
        //                    stockWork.SupplierStock += wkAddUppOrgStockDetailWork.StockCount;
        //                    stockWork.TrustCount += -wkAddUppOrgStockDetailWork.StockCount;
        //                }

        //                stockList.Add(stockWork);
        //            }
        //        }
        //        else
        //        {
        //            // add 2007.06.08 saito
        //            stockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;      //仕入単価

        //            //返品
        //            if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
        //            {
        //                if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
        //                    stockWork.SupplierStock += wkAddUppOrgStockDetailWork.StockCount;
        //                else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
        //                    stockWork.TrustCount += wkAddUppOrgStockDetailWork.StockCount;
        //            }
        //            //計上処理
        //            else
        //            {
        //                stockWork.SupplierStock += wkAddUppOrgStockDetailWork.StockCount;
        //                stockWork.TrustCount += -wkAddUppOrgStockDetailWork.StockCount;
        //            }

        //            stockList.Add(stockWork);
        //        }
        //          --- DEL 2007/09/11 M.Kubota --->>>*/
        //    }
        //    #endregion

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.03.04

        ///// <summary>
        ///// 返品時の製番在庫パラメータ作成処理（在庫検索からの返品処理に対応）
        ///// </summary>
        ///// <param name="paraList"></param>
        ///// <param name="productStockWorkList">製番在庫ワークList</param>
        ///// <param name="productStockCommonList">製番在庫共通ワークList</param>
        ///// <param name="position">仕入データ位置</param>
        ///// <param name="explaDataPosition">仕入詳細データ位置</param>
        ///// <returns></returns>
        //private int MakeReturnProductStockPara(CustomSerializeArrayList paraList, out ArrayList productStockWorkList, ArrayList productStockCommonList, Int32 position, Int32 explaDataPosition)
        //{
        //    //出力パラメータList(製番)
        //    productStockWorkList = new ArrayList();

        //    //更新パラメータクラス格納用(製番)
        //    ProductStockWork productStockWork = null;

        //    //仕入データワーク格納用(ヘッダ・明細・詳細)
        //    StockSlipWork wkStockSlipWork = paraList[position] as StockSlipWork;
        //    StockDetailWork wkAddUppOrgStockDetailWork = null;
        //    StockExplaDataWork wkStockExplaDataWork = null;

        //    ProductStockCommonPara productStockCommonPara = null;

        //    //仕入データワーク格納用List(明細・詳細)
        //    ArrayList wkStockDetailWorkList = new ArrayList();
        //    ArrayList wkStockExplaDataWorkList = new ArrayList();

        //    //仕入明細データ格納処理
        //    for (int i = 0; i < paraList.Count; i++)
        //    {
        //        if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
        //        {
        //            for (int x = 0; x < ((ArrayList)paraList[i]).Count; x++)
        //            {
        //                wkAddUppOrgStockDetailWork = (((ArrayList)paraList[i])[x]) as StockDetailWork;
        //                if (wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage) wkStockDetailWorkList.Add(wkAddUppOrgStockDetailWork);
        //            }
        //        }
        //    }
        //    //仕入詳細データ格納処理
        //    wkStockExplaDataWorkList = paraList[explaDataPosition] as ArrayList;

        //    //●製番在庫マスタ更新パラメータ格納処理
        //    #region[製番在庫マスタ更新パラメータ格納]
        //    if (wkStockDetailWorkList.Count > 0)
        //    {
        //        for (int i = 0; i < wkStockDetailWorkList.Count; i++)
        //        {
        //            wkAddUppOrgStockDetailWork = wkStockDetailWorkList[i] as StockDetailWork;

        //            //(在庫管理しない AND 製番管理しない) OR (在庫管理しない AND 製番管理する) ← このパターンはありえない
        //            if ((wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgStockDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Unmanage) ||
        //                (wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgStockDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Manage)) continue;

        //            for (int y = 0; y < wkStockExplaDataWorkList.Count; y++)
        //            {
        //                wkStockExplaDataWork = wkStockExplaDataWorkList[y] as StockExplaDataWork;

        //                //●明細と詳細の行番号が一致したものをパラメータにセットする
        //                if (wkAddUppOrgStockDetailWork.StockRowNo == wkStockExplaDataWork.StockRowNo)
        //                {
        //                    productStockWork = new ProductStockWork();

        //                    int cmnStockState = 0;
        //                    int cmnStockDiv = 0;

        //                    for (int z = 0; z < productStockCommonList.Count; z++)
        //                    {
        //                        productStockCommonPara = productStockCommonList[z] as ProductStockCommonPara;

        //                        if (wkStockExplaDataWork.ProductStockGuid == productStockCommonPara.ProductStockGuid)
        //                        {
        //                            productStockWork.SectionCode = productStockCommonPara.SectionCode;

        //                            if (wkStockExplaDataWork.StockUpdDiscDiv == 1)
        //                            {
        //                                productStockWork.ProductNumber = productStockCommonPara.ProductNumber;
        //                                cmnStockDiv = productStockCommonPara.StockDiv;
        //                                cmnStockState = productStockCommonPara.StockState;
        //                                productStockWork.StockTelNo1 = productStockCommonPara.StockTelNo1;
        //                                productStockWork.StockTelNo2 = productStockCommonPara.StockTelNo2;

        //                                if (String.IsNullOrEmpty(productStockCommonPara.StockTelNo1))
        //                                    productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.White;
        //                                else
        //                                    productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.Black;
        //                            }
        //                        }
        //                    }
        //                    if (String.IsNullOrEmpty(productStockWork.SectionCode))
        //                        productStockWork.SectionCode = wkStockSlipWork.StockUpdateSecCd;        //拠点コード

        //                    //仕入詳細　→　製番在庫マスタ
        //                    productStockWork.ProductStockGuid = wkStockExplaDataWork.ProductStockGuid;  //製番在庫マスタGUID

        //                    if (wkStockExplaDataWork.StockUpdDiscDiv == 0)
        //                    {
        //                        //ロム区分
        //                        if (String.IsNullOrEmpty(wkStockExplaDataWork.StockTelNo1))
        //                            productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.White;
        //                        else
        //                            productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.Black;

        //                        productStockWork.ProductNumber = wkStockExplaDataWork.ProductNumber1;     //製造番号1
        //                        productStockWork.StockTelNo1 = wkStockExplaDataWork.StockTelNo1;      //商品電話番号1
        //                        productStockWork.StockTelNo2 = wkStockExplaDataWork.StockTelNo2;      //商品電話番号2
        //                    }

        //                    //仕入ヘッダ　→　製番在庫マスタ
        //                    productStockWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;     //企業コード
        //                    productStockWork.CarrierEpCode = wkStockSlipWork.CarrierEpCode;       //事業者コード
        //                    productStockWork.CarrierEpName = wkStockSlipWork.CarrierEpName;       //事業者名称
        //                    productStockWork.CustomerCode = wkStockSlipWork.CustomerCode;         //得意先コード
        //                    productStockWork.CustomerName = wkStockSlipWork.CustomerName;         //得意先名称
        //                    productStockWork.CustomerName2 = wkStockSlipWork.CustomerName2;       //得意先名称2
        //                    productStockWork.StockDate = wkStockSlipWork.StockDate;               //仕入日
        //                    productStockWork.ArrivalGoodsDay = wkStockSlipWork.ArrivalGoodsDay;   //入荷日

        //                    //在庫区分
        //                    if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
        //                    {
        //                        if (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                        {
        //                            productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
        //                        }
        //                        else if (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
        //                                 wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
        //                        {
        //                            if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //                            {
        //                                productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
        //                            }
        //                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
        //                            {
        //                                productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
        //                            }
        //                        }
        //                    }
        //                    else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
        //                    {
        //                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
        //                    }
        //                    //●在庫状態
        //                    // add 2007.06.26 saito
        //                    //if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                    //    wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
        //                    //{
        //                    //    productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    //}
        //                    //else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                    //         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
        //                    //{
        //                    //    productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
        //                    //}

        //                    //●在庫状態
        //                    //仕入伝票更新
        //                    if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                        wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                        wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                        wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //在庫
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
        //                    }
        //                    //受託伝票更新
        //                    else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                             wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                             wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                             wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //受託中
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
        //                    }
        //                    //赤伝票更新(仕入)
        //                    else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                             wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
        //                             wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //返品
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    }
        //                    //赤伝票更新(受託)
        //                    else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                             wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
        //                             wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //返品
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    }
        //                    //返品伝票更新(仕入)
        //                    else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                             wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)// && 
        //                    //wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //返品
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    }
        //                    //受託計上伝票更新(通常)
        //                    else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                             (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
        //                              wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
        //                    {
        //                        //在庫
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
        //                    }
        //                    //受託計上伝票更新(赤伝)
        //                    else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
        //                             (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
        //                             wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
        //                    {
        //                        //受託中
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
        //                    }

        //                    if (wkStockExplaDataWork.StockUpdDiscDiv == 1)
        //                    {
        //                        productStockWork.StockDiv = cmnStockDiv;
        //                        productStockWork.StockState = cmnStockState;
        //                    }

        //                    //仕入明細　→　製番在庫マスタ
        //                    productStockWork.MakerCode = wkAddUppOrgStockDetailWork.MakerCode;     //メーカーコード
        //                    productStockWork.MakerName = wkAddUppOrgStockDetailWork.MakerName;     //メーカー名称
        //                    productStockWork.GoodsCode = wkAddUppOrgStockDetailWork.GoodsCode;     //商品コード
        //                    productStockWork.GoodsName = wkAddUppOrgStockDetailWork.GoodsName;     //商品名称
        //                    productStockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;     //仕入単価

        //                    productStockWork.TaxationCode = wkAddUppOrgStockDetailWork.TaxationCode;       //課税区分
        //                    productStockWork.CarrierCode = wkAddUppOrgStockDetailWork.CarrierCode;         //キャリアコード
        //                    productStockWork.CarrierName = wkAddUppOrgStockDetailWork.CarrierName;         //キャリア名称
        //                    productStockWork.SystematicColorCd = wkAddUppOrgStockDetailWork.SystematicColorCd;     //系統色コード
        //                    productStockWork.SystematicColorNm = wkAddUppOrgStockDetailWork.SystematicColorNm;     //系統色名称
        //                    productStockWork.LargeGoodsGanreCode = wkAddUppOrgStockDetailWork.LargeGoodsGanreCode; //商品大分類コード
        //                    productStockWork.MediumGoodsGanreCode = wkAddUppOrgStockDetailWork.MediumGoodsGanreCode;   //商品中分類コード
        //                    productStockWork.WarehouseCode = wkAddUppOrgStockDetailWork.WarehouseCode;       //倉庫コード
        //                    productStockWork.WarehouseName = wkAddUppOrgStockDetailWork.WarehouseName;       //倉庫名称
        //                    productStockWork.CellphoneModelCode = wkAddUppOrgStockDetailWork.CellphoneModelCode;     //機種コード
        //                    productStockWork.CellphoneModelName = wkAddUppOrgStockDetailWork.CellphoneModelName;     //機種名称

        //                    //製番在庫マスタ出力ArrayListに追加
        //                    productStockWorkList.Add(productStockWork);
        //                }
        //            }
        //        }
        //    }
        //    #endregion

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        
        #endregion

        #region [仕入計上日チェック]
        /*
        /// <summary>
        /// 売上計上済み在庫の仕入計上日をチェックする
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <param name="productStockCommonPara">製番在庫共通パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上計上済み在庫の仕入計上日をチェックする</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.07.24</br>
        private int CheckSalesAddUpDate(StockSlipWork stockSlipWork, ProductStockCommonPara productStockCommonPara, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;
                    sqlCommand.CommandText = "SELECT A.ADDUPADATERF,A.SHIPMENTDAYRF FROM SALESSLIPRF AS A INNER JOIN SALESEXPLADATARF AS B ON (A.ENTERPRISECODERF=B.ENTERPRISECODERF AND A.ACCEPTANORDERNORF=B.ACCEPTANORDERNORF) WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND B.PRODUCTSTOCKGUIDRF=@FINDPRODUCTSTOCKGUID ";

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaProductStockGuid = sqlCommand.Parameters.Add("@FINDPRODUCTSTOCKGUID", SqlDbType.UniqueIdentifier);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(productStockCommonPara.EnterpriseCode);
                    findParaProductStockGuid.Value = SqlDataMediator.SqlSetGuid(productStockCommonPara.ProductStockGuid);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            DateTime addUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                            DateTime shipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));

                            if (productStockCommonPara.StockState == (int)ConstantManagement_Mobile.ct_StockState.SalesAddUp || 
                                productStockCommonPara.StockState == (int)ConstantManagement_Mobile.ct_StockState.SellsUp)
                            {
                                if (addUpADate >= stockSlipWork.StockAddUpADate)
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                else
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
                            else if (productStockCommonPara.StockState == (int)ConstantManagement_Mobile.ct_StockState.Consigning)
                            {
                                if (shipmentDay >= stockSlipWork.StockAddUpADate)
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                else
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
                        }
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed) myReader.Close();
                            myReader.Dispose();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "StockSlipDB.CheckSalesAddUpDateにてSQL例外発生。MSG=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "StockSlipDB.CheckSalesAddUpDateにて例外発生。MSG=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        */

        /*
        /// <summary>
        /// 返品済み在庫の仕入計上日をチェックする
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <param name="productStockCommonPara">製番在庫共通パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品済み在庫の仕入計上日をチェックする</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.07.25</br>
        private int CheckReturnDate(StockSlipWork stockSlipWork, ProductStockCommonPara productStockCommonPara, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;
                    sqlCommand.CommandText = "SELECT MAX(ARRIVALGOODSDAYRF) AS ARRIVALGOODSDAYRF,MAX(STOCKDATERF) AS STOCKDATERF FROM STOCKSLIPRF AS A INNER JOIN STOCKEXPLADATARF AS B ON (A.ENTERPRISECODERF=B.ENTERPRISECODERF AND A.SUPPLIERSLIPNORF=B.SUPPLIERSLIPNORF) WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND B.PRODUCTSTOCKGUIDRF=@FINDPRODUCTSTOCKGUID GROUP BY A.ENTERPRISECODERF,B.PRODUCTSTOCKGUIDRF ";

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaProductStockGuid = sqlCommand.Parameters.Add("@FINDPRODUCTSTOCKGUID", SqlDbType.UniqueIdentifier);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(productStockCommonPara.EnterpriseCode);
                    findParaProductStockGuid.Value = SqlDataMediator.SqlSetGuid(productStockCommonPara.ProductStockGuid);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            DateTime stockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                            DateTime arrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));

                            if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                            {
                                if (stockDate >= stockSlipWork.StockDate)
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                else
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
                            else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                            {
                                if (arrivalGoodsDay >= stockSlipWork.ArrivalGoodsDay)
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                else
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
                        }
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed) myReader.Close();
                            myReader.Dispose();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "StockSlipDB.CheckSalesAddUpDateにてSQL例外発生。MSG=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "StockSlipDB.CheckSalesAddUpDateにて例外発生。MSG=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        */
        #endregion
        
        # endregion

        #region[Read]
        /// <summary>
        /// 在庫を読み込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">仕入伝票読込パラメータ</param>
        /// <param name="retList">仕入伝票読込結果</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫を読み込みます</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.04</br>
        public int Read(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //製番在庫共通データクラスList格納用
            //ArrayList productStockCommonParaList = new ArrayList();  //DEL 2007/09/11 M.Kubota

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "プログラムエラー。読込対象オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 読込対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    //base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota

                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入更新オブジェクトの取得(カスタムArray内から検索)
                if (retList != null)
                {
                    status = this.ReadProductCommon(origin, ref paraList, ref retList, position, param, ref freeParam, ref sqlConnection, ref sqlTransaction);
                }

            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMASIRStockUpdateDB.Read:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 製番在庫を読み込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">仕入伝票読込パラメータ</param>
        /// <param name="retList">仕入伝票読込結果</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 製番在庫を読み込みます</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.14</br>
        private int ReadProductCommon(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //--- DEL 2007/09/11 M.Kubota --->>>
            //仕入詳細データクラス格納用
            //StockExplaDataWork stockExplaDataWork = null;
            //ArrayList stockExplaDataWorkList = null;

            //製番在庫共通データクラスList格納用
            //ArrayList productStockCommonParaList = new ArrayList();
            //--- DEL 2007/09/11 M.Kubota ---<<<

            // 仕入明細データクラス格納用
            StockSlipWork stockSlipWork = null;
            StockDetailWork stockDetailWork = null;
            ArrayList stockDetailWorkList = null;

            // 在庫データクラス格納用List
            ArrayList stockWorkParaList = new ArrayList();

            try
            {
                //●仕入更新オブジェクトの取得(カスタムArray内から検索)
                if (retList.Count > 0)
                {
                    // 仕入データを取得
                    foreach (object item in retList)
                    {
                        stockSlipWork = item as StockSlipWork;

                        if (stockSlipWork != null)
                        {
                            break;
                        }
                    }
                    
                    for (int i = 0; i < retList.Count; i++)
                    {
                        //if (retList[i] is ArrayList && ((ArrayList)retList[i]).Count > 0 && ((ArrayList)retList[i])[0] is StockExplaDataWork)  //DEL 2007/09/11 M.Kubota
                        if (retList[i] is ArrayList && ((ArrayList)retList[i]).Count > 0 && ((ArrayList)retList[i])[0] is StockDetailWork)
                        {
                            //stockExplaDataWorkList = retList[i] as ArrayList;  //DEL 2007/09/11 M.Kubota
                            stockDetailWorkList = retList[i] as ArrayList;

                            //製番在庫共通データクラスList生成
                            //for (int x = 0; x < stockExplaDataWorkList.Count; x++)  //DEL 2007/09/11 M.Kubota
                            for (int x = 0; x < stockDetailWorkList.Count; x++)
                            {
                                //製番在庫共通データクラス格納用
                                //ProductStockCommonPara productStockCommonPara = new ProductStockCommonPara();  //DEL 2007/09/11 M.Kubota
                                
                                // 在庫データクラス格納用
                                StockWork stockWork = new StockWork();

                                //仕入詳細データクラス生成
                                //stockExplaDataWork = stockExplaDataWorkList[x] as StockExplaDataWork;  //DEL 2007/09/11 M.Kubota
                                stockDetailWork = stockDetailWorkList[x] as StockDetailWork;

                                //--- ADD 2007/09/11 M.Kubota --->>>
                                stockWork.EnterpriseCode = stockDetailWork.EnterpriseCode;  // 企業コード

                                //--- DEL 2008/08/25 M.Kubota --->>>
                                //if (stockSlipWork != null)
                                //{
                                //    stockWork.SectionCode = stockSlipWork.StockSectionCd;   // 仕入拠点コード
                                //}
                                //else
                                //{
                                //    stockWork.SectionCode = stockDetailWork.SectionCode;    // 拠点コード(有り得ないが…)
                                //}
                                //--- DEL 2008/08/25 M.Kubota ---<<<

                                stockWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;      // 商品メーカーコード
                                stockWork.GoodsNo = stockDetailWork.GoodsNo;                // 商品番号
                                stockWork.WarehouseCode = stockDetailWork.WarehouseCode;    // 倉庫コード
                                stockWorkParaList.Add(stockWork);
                                //--- ADD 2007/09/11 M.Kubota ---<<<

                                //--- DEL 2007/09/11 M.Kubota --->>>
                                //productStockCommonPara.EnterpriseCode = stockExplaDataWork.EnterpriseCode;      
                                //productStockCommonPara.ProductStockGuid = stockExplaDataWork.ProductStockGuid;
                                //productStockCommonParaList.Add(productStockCommonPara);
                                //--- DEL 2007/09/11 M.Kubota ---<<<
                            }
                        }
                    }

                    // 在庫データ読込
                    //if (productStockCommonParaList.Count > 0)  //DEL 2007/09/11 M.Kubota
                    if (stockWorkParaList.Count > 0)
                    {
                        //paraList.Add(productStockCommonParaList);  //DEL 2007/09/11 M.Kubota
                        paraList.Add(stockWorkParaList);

                        CustomSerializeArrayList tempRetList = new CustomSerializeArrayList();
                        StockDB stockDB = new StockDB();
                        status = stockDB.Read(origin, ref paraList, ref tempRetList, position, param, ref freeParam, ref sqlConnection);

                        if (tempRetList.Count > 0 && tempRetList[0] is ArrayList && (tempRetList[0] as ArrayList).Count > 0)
                        {
                            retList.AddRange(tempRetList);
                        }

                        for (int i = 0; i < paraList.Count; i++)
                        {
                            //if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is ProductStockCommonPara)  //DEL 2007/09/11 M.Kubota
                            if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockWork)
                            {
                                paraList.RemoveAt(i);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMASIRStockUpdateDB.Read:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                //--- ADD 2008/08/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //--- ADD 2008/08/25 M.Kubota ---<<<
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region[Write]
        /// <summary>
        /// 在庫更新の準備処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">更新対象オブジェクト</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.25</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int oldPosition = -1;

            //仕入データクラス格納用(新・旧)
            StockSlipWork stockSlipWork = null;
            StockSlipWork oldStockSlipWork = null;
            //仕入明細データクラスList格納用(新・旧)　※在庫パラメータを仕入明細単位で作成するため
            ArrayList stockDetailWorkList = null;
            //ArrayList oldStockDetailWorkList = null;  //DEL 2009/01/30

            //旧在庫パラメータ格納List(在庫・製番)
            ArrayList oldStockWorkList = new ArrayList();
            //ArrayList oldProductStockWorkList = new ArrayList();  //DEL 2007/09/11 M.Kubota

            //新在庫パラメータ格納List(在庫・製番・受払・受払明細)
            ArrayList stockWorkList = new ArrayList();
            //ArrayList productStockWorkList = new ArrayList();    //DEL 2007/09/11 M.Kubota
            ArrayList stockAcPayHistWorkList = new ArrayList();
            //ArrayList stockAcPayHisDtWorkList = new ArrayList(); //DEL 2007/09/11 M.Kubota
            //ArrayList stockExplaDataWorkList = new ArrayList();  //DEL 2007/09/11 M.Kubota

            //在庫パラメータ差分抽出格納用(在庫・製番・受払明細)
            ArrayList stockUpdateWorkList = new ArrayList();
            ArrayList stockAcPayHistWorkUpdateList = new ArrayList();  //ADD 2008/03/13 M.Kubota
            //ArrayList productStockDeleteWorkList = new ArrayList();  //DEL 2007/09/11 M.Kubota

            // add 2007.05.31 saito
            //チェック用製番在庫マスタList 
            //ArrayList productStockCommonParaList = new ArrayList();  //DEL 2007/09/11 M.Kubota
            //ArrayList productStockCommonList = new ArrayList();      //DEL 2007/09/11 M.Kubota
            //ArrayList productStockReturnCheckList = new ArrayList(); //DEL 2007/09/11 M.Kubota
            //ArrayList productStockNonGuidList = new ArrayList();     //DEL 2007/09/11 M.Kubota

            //StockWork stockWork = null;                      //DEL 2007/09/11 M.Kubota
            //ProductStockWork productStockWork = null;        //DEL 2007/09/11 M.Kubota
            //ProductStockWork productStockReturnWork = null;  //DEL 2007/09/11 M.Kubota
            //StockExplaDataWork stockExplaDataWork = null;    //DEL 2007/09/11 M.Kubota

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.WriteInitial:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.WriteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入更新オブジェクトの取得(カスタムArray内から検索)
                if (list == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.WriteInitial:プログラムエラー。更新対象パラメータListが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象パラメータListが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }
                else if (list.Count > 0) stockSlipWork = list[position] as StockSlipWork;
                if (stockSlipWork == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.WriteInitial:プログラムエラー。更新対象オブジェクトパラメータが未指定です");
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●STATUS初期化
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //●既存仕入伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //if (originList[i] is StockSlipWork)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        if ( (originList[i] is StockSlipWork) &&
                             ((originList[i] as StockSlipWork).SupplierSlipCd == stockSlipWork.SupplierSlipCd) )
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        {
                            oldStockSlipWork = originList[i] as StockSlipWork;
                            oldPosition = i;
                        }
                    }
                }

                //●仕入商品区分　消費税調整・残高調整　の場合は更新しない
                if (stockSlipWork.StockGoodsCd != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }

                if (oldStockSlipWork != null)
                {
                    if (oldStockSlipWork.StockGoodsCd != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                }

                # region --- DEL 2007/09/11 M.Kubota ---
                /*--- DEL 2007/09/11 M.Kubota --->>>
                //●GUIDチェックを行うために、製番在庫paraだけ作成する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockExplaDataWork)
                        {
                            stockExplaDataWorkList = list[i] as ArrayList; //返品時引当処理のため追加
                            status = MakeProductStockWork(list, out productStockWorkList, position, i);
                        }
                    }
                }
                
                //●製番在庫マスタ製番チェック処理
                if (productStockWorkList.Count > 0)
                {
                    //製番在庫マスタGUIDが採番されている製番データのみ抽出
                    status = MakeProductCommonPara(out productStockCommonParaList, productStockWorkList);

                    if (productStockCommonParaList.Count > 0)
                    {
                        StockDB stockDB = new StockDB();
                        //該当する製番在庫GUIDが1件も存在しない場合はSTATUS=DB_Status.ctDB_EOF
                        status = stockDB.SearchProductStockGuiRetComdProc(out productStockCommonList, productStockCommonParaList, 0, 0, ref sqlConnection, ref sqlTransaction, out retMsg);
                        //STATUS初期化
                        if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    //※在庫状態が変更されていても更新できるようにする(日付チェックは別途必要)
                    //在庫状態チェック
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (productStockCommonParaList.Count > 0)
                    //        status = CheckProductNumStatus(productStockCommonList, stockSlipWork, out retMsg);
                    //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    //}
                }
                 --- DEL 2007/09/11 M.Kubota ---<<<*/
                # endregion

                //●企業コードに紐付く拠点コード・名称の一覧を取得する
                status = this.GetSecInfoSetWork(stockSlipWork.EnterpriseCode, out this._secInfoSeTtable, ref sqlConnection, ref sqlTransaction);  //ADD 2007/09/11 M.Kubota

                //●更新パラメータ取得
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //ADD 2007/09/11 M.Kubota
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫マスタ・在庫受払履歴データ更新パラメータ取得
                        //if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockDetailWork)  //DEL 2009/01/30
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && (((ArrayList)list[i])[0]).GetType() == typeof(StockDetailWork))  //ADD 2009/01/30 計上元明細と分ける為 厳密な型チェックを行う
                        {
                            stockDetailWorkList = list[i] as ArrayList;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                            //status = MakeStockAndStockAcPayHist(list, out stockWorkList, out stockAcPayHistWorkList, position, i, 0 /* 0:更新 */);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                            status = MakeStockAndStockAcPayHist( originList, list, out stockWorkList, out stockAcPayHistWorkList, position, i, 0 /* 0:更新 */);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                        }

                        # region --- DEL 2007/09/11 M.Kubota ---
                        //--- DEL 2007/09/11 M.Kubota --->>>
                        //製番在庫マスタ・在庫受払履歴明細データ更新パラメータ取得
                        //if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockExplaDataWork)
                        //{
                        //    productStockWorkList = null;
                        //    status = MakeProductStockAndStockAcPayHisDt(list, out productStockWorkList, out stockAcPayHisDtWorkList, productStockCommonList, position, i, 0 /* 0:更新 */, out retMsg, ref sqlConnection, ref sqlTransaction);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING) return status;
                        //}
                        //--- DEL 2007/09/11 M.Kubota ---<<<
                        # endregion
                    }
                }

                # region [DELETE]
                #region 在庫引当処理（返品時・受託計上時）add 2007.06.12
                //引当した製番在庫GUIDを仕入詳細に挿入する
                /*
                if (productStockWorkList.Count > 0)
                {
                    if ((stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                         stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return) ||
                        (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                         stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy))
                    {
                        //明細分だけ
                        for (int i = 0; i < stockWorkList.Count; i++)
                        {
                            int checkCount = 0; //製番なし返品数・受託計上数
                            double stockCount = 0; //明細単位の返品数・受託計上数

                            stockWork = stockWorkList[i] as StockWork;

                            for (int x = 0; x < productStockWorkList.Count; x++)
                            {
                                productStockWork = productStockWorkList[x] as ProductStockWork;
                                if (productStockWork.MakerCode == stockWork.MakerCode && productStockWork.GoodsCode == stockWork.GoodsCode)
                                {
                                    if ((productStockWork.ProductNumber == null || productStockWork.ProductNumber == "") &&
                                        (productStockWork.ProductStockGuid.ToString() == null || productStockWork.ProductStockGuid == Guid.Empty))
                                    {
                                        checkCount++;
                                    }
                                }
                            }

                            if (checkCount > 0)
                            {
                                if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                                {
                                    stockCount = stockWork.SupplierStock; //一時的に格納
                                    stockWork.SupplierStock = (double)checkCount; //引当数を格納
                                }
                                else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                                {
                                    stockCount = stockWork.TrustCount;
                                    stockWork.TrustCount = (double)checkCount;
                                }

                                //在庫リモート呼出
                                StockDB stockDB = new StockDB();
                                status = stockDB.SearchProductStockForDrawingProc(out productStockReturnCheckList, stockWork, 0, 0, ref sqlConnection, ref sqlTransaction, out retMsg);

                                if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                                {
                                    stockWork.SupplierStock = stockCount; //返品数を元に戻す
                                }
                                else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                                {
                                    stockWork.TrustCount = stockCount; //返品数を元に戻す
                                }

                                if (checkCount > productStockReturnCheckList.Count)
                                {
                                    retMsg = "在庫数量が不足しています。引当処理に失敗しました。";
                                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    int temp = 0;
                                    //製番在庫List再作成
                                    for (int y = 0; y < productStockWorkList.Count; y++)
                                    {
                                        productStockWork = productStockWorkList[y] as ProductStockWork;
                                        stockExplaDataWork = stockExplaDataWorkList[y] as StockExplaDataWork;

                                        //製造番号GUIDを製番在庫マスタのGUIDにて置き換える
                                        if (productStockWork.MakerCode == stockWork.MakerCode && productStockWork.GoodsCode == stockWork.GoodsCode)
                                        {
                                            if ((productStockWork.ProductNumber == null || productStockWork.ProductNumber == "") &&
                                                (productStockWork.ProductStockGuid.ToString() == null || productStockWork.ProductStockGuid == Guid.Empty))
                                            {
                                                productStockReturnWork = productStockReturnCheckList[temp] as ProductStockWork;
                                                productStockWork.ProductStockGuid = productStockReturnWork.ProductStockGuid;
                                                //仕入詳細データの製造番号GUIDも置き換える
                                                stockExplaDataWork.ProductStockGuid = productStockReturnWork.ProductStockGuid;

                                                ++temp;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                */
                #endregion

                // MakeReturnStockPara の処理内容を MakeStockAndStockAcPayHist がカバーしてるので削除する -->
                //// add 2007.06.07 saito
                ////●返品用在庫マスタ、製番在庫マスタパラメータの作成
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    //--- DEL 2007/09/11 M.Kubota --->>>
                //    //if ((stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                //    //     stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return) ||
                //    //    (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                //    //     stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy) ||
                //    //    (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                //    //     stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                //    //--- DEL 2007/09/11 M.Kubota ---<<<

                //    //--- ADD 2007/09/11 M.Kubota --->>>
                //    if ((stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                //         stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return))
                //    //--- ADD 2007/09/11 M.Kubota ---<<<
                //    {
                //        for (int i = 0; i < list.Count; i++)
                //        {
                //            if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockDetailWork)
                //            {
                //                stockWorkList = null;
                //                //返品在庫マスタパラメータ作成
                //                //status = this.MakeReturnStockPara(list, out stockWorkList, productStockCommonList, position, i);  //DEL 2007/09/11 M.Kubota
                //                status = this.MakeReturnStockPara(list, out stockWorkList, null, position, i);                      //ADD 2007/09/11 M.Kubota
                //            }

                //            //--- DEL 2007/09/11 M.Kubota --->>>
                //            //if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockExplaDataWork)
                //            //{
                //            //    productStockWorkList = null;
                //            //    //既存製番在庫マスタパラメータ作成
                //            //    status = this.MakeReturnProductStockPara(list, out productStockWorkList, productStockCommonList, position, i);
                //            //}
                //            //--- DEL 2007/09/11 M.Kubota ---<<<
                //        }
                //    }
                //}
                //// add 2007.06.07 saito
                # endregion

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.29
                // ※注意
                //   ↓更新の場合は、ここで在庫の差分のリストを破棄しています。
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.29

                //●listに追加
                if (stockWorkList.Count > 0)
                {
                    if (oldStockSlipWork == null)
                        list.Add(stockWorkList);
                    else if (oldStockSlipWork != null && oldStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack)
                        list.Add(stockWorkList);
                }

                //--- DEL 2008/03/13 M.Kubota --->>>
                //if (stockAcPayHistWorkList.Count > 0) list.Add(stockAcPayHistWorkList);
                //--- DEL 2008/03/13 M.Kubota ---<<<
                //--- ADD 2008/03/13 M.Kubota --->>>
                if (stockAcPayHistWorkList.Count > 0)
                {
                    if (oldStockSlipWork == null)
                        list.Add(stockAcPayHistWorkList);
                    else if (oldStockSlipWork != null && oldStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack)
                        list.Add(stockAcPayHistWorkList);
                }
                //--- ADD 2008/03/13 M.Kubota ---<<<

                # region [--- DEL 2007/09/11 M.Kubota ---]
                //if (productStockWorkList.Count > 0)
                //{
                //    if (oldStockSlipWork == null)
                //        list.Add(productStockWorkList);
                //    else if (oldStockSlipWork != null && oldStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack)
                //        list.Add(productStockWorkList);
                //}

                //if (stockAcPayHisDtWorkList.Count > 0) list.Add(stockAcPayHisDtWorkList);
                # endregion

                //●既に仕入伝票が存在する場合削除パラメータ取得
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (oldStockSlipWork != null)
                    {
                        //元黒伝の場合は赤伝の発行なので既存仕入伝票のチェックは必要なし
                        if ( oldStockSlipWork.DebitNoteDiv != (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack )
                        {
                            # region [--- DEL 2009/01/30 ---]
                            //for (int x = 0; x < originList.Count; x++)
                            //{
                            //    //●旧在庫マスタ更新パラメータ取得
                            //    if (originList[x] is ArrayList && ((ArrayList)originList[x]).Count > 0 && ((ArrayList)originList[x])[0] is StockDetailWork)
                            //    {
                            //        oldStockDetailWorkList = originList[x] as ArrayList;
                            //        //status = MakeStockWork(originList, out oldStockWorkList, oldPosition, x, 0 /* 0:更新 */);
                            //    }

                            //    # region DELETE
                            //    //--- DEL 2007/09/11 M.Kubota --->>>
                            //    //●旧製番在庫マスタ更新パラメータ取得
                            //    //if (originList[x] is ArrayList && ((ArrayList)originList[x]).Count > 0 && ((ArrayList)originList[x])[0] is StockExplaDataWork)
                            //    //{
                            //    //    status = MakeProductStockWork(originList, out oldProductStockWorkList, oldPosition, x);
                            //    //}
                            //    //--- DEL 2007/09/11 M.Kubota ---<<<    
                            //    //在庫受払履歴・明細データは修正不可(必ず新規登録:INSERT)
                            //    # endregion
                            //}
                            #endregion

                            //チェック機能追加
                            //●在庫マスタ仕入数差分抽出
                            //if (oldStockSlipWork.TrustAddUpSpCd == 0)
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //仕入明細データから在庫マスタ仕入数差分を抽出する
                                # region [--- DEL 2008/02/29 M.Suzuki ---]
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.29
                                //status = this.MakeStockDetailWorkAdd( stockSlipWork, oldStockDetailWorkList, stockDetailWorkList, out stockUpdateWorkList );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.29
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.29
                                //status = this.MakeStockDetailWorkAdd(stockSlipWork, stockDetailWorkList, originList, out stockUpdateWorkList);  //DEL 2008/03/13 M.Kubota
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.29
                                # endregion

                                //仕入明細データから在庫マスタ仕入数差分を抽出する
                                //status = this.MakeStockDetailWorkAdd(stockSlipWork, stockDetailWorkList, originList, out stockUpdateWorkList, out stockAcPayHistWorkUpdateList);  //ADD 2008/03/13 M.Kubota //DEL 2009/01/30
                                status = this.MakeStockDetailWorkAdd(stockSlipWork, stockDetailWorkList, originList, list,out stockUpdateWorkList, out stockAcPayHistWorkUpdateList);  //ADD 2009/01/30
                            }
                            # region [--- DEL ---]
                            //else if (oldStockSlipWork.TrustAddUpSpCd == 1 || oldStockSlipWork.TrustAddUpSpCd == 2)
                            //{
                            //status = this.MakeTrustStockDetailWorkAdd(oldStockSlipWork, oldStockDetailWorkList, stockDetailWorkList, out stockUpdateWorkList);
                            //status = MakeTrustAddStockWork(oldStockWorkList, stockWorkParaList, out stockUpdateWorkList); //del 2007.06.09 saito
                            //}
                            # endregion
                            
                            # region DELETE
                            //●製番在庫マスタ削除データ抽出
                            /*--- DEL 2007/09/11 M.Kubota --->>>
                            if (oldStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                            {
                                status = MakeProductStockWorkAdd(oldProductStockWorkList, productStockWorkList, out productStockDeleteWorkList);
                            }
                            else if (oldStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                                     oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                            {
                                status = MakeReturnProductStock(ref oldProductStockWorkList, ref productStockWorkList);
                            }
                            //受託計上伝票修正の場合
                            else if (oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                     oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                            {
                                status = MakeTrustAddProductStock(ref oldProductStockWorkList, ref productStockWorkList);
                            }
                              --- DEL 2007/09/11 M.Kubota ---<<<*/
                            # endregion

                            if (stockUpdateWorkList.Count > 0) list.Add(stockUpdateWorkList);
                            if (stockAcPayHistWorkUpdateList.Count > 0) list.Add(stockAcPayHistWorkUpdateList);  //ADD 2008/03/13 M.Kubota
                            # region [--- DEL 2007/09/11 M.Kubota ---]
                            //if (productStockWorkList.Count > 0) list.Add(productStockWorkList);              //DEL 2007/09/11 M.Kubota
                            //if (productStockDeleteWorkList.Count > 0) list.Add(productStockDeleteWorkList);  //DEL 2007/09/11 M.Kubota
                            # endregion
                        }
                    }
                }

                //重複チェック
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //if (productStockWorkList.Count > 0)  //DEL 2007/09/11 M.Kubota
                    {
                        StockDB stockDB = new StockDB();
                        status = stockDB.WriteInitial(origin, ref originList, ref list, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }

                //削除
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockWork)
                                list.RemoveAt(i);
                        }

                        # region [--- DEL 2007/09/11 M.Kubota ---]
                        //for (int i = 0; i < list.Count; i++)
                        //{
                        //    if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is ProductStockWork)
                        //        list.RemoveAt(i);
                        //}
                        # endregion

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHistWork)
                                list.RemoveAt(i);
                        }
                        
                        # region [--- DEL 2007/09/11 M.Kubota ---]
                        //for (int i = 0; i < list.Count; i++)
                        //{
                        //    if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHisDtWork)
                        //        list.RemoveAt(i);
                        //}
                        # endregion

                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMASIRStockUpdateDB.WriteInitial:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }
            finally                
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }

        /// <summary>
        /// 在庫更新の呼び出しを行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">更新対象オブジェクト</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫更新処理を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.25</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //仕入データクラス格納用(新・旧)
            StockSlipWork stockSlipWork = null;
            StockSlipWork oldStockSlipWork = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.Write:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.Write:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●在庫更新オブジェクトの取得(カスタムArray内から検索)
                if (list == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.Write:プログラムエラー。更新対象パラメータListが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }
                else if (list.Count > 0) stockSlipWork = list[position] as StockSlipWork;

                if (stockSlipWork == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.Write:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●戻り値を正常で初期化
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // --- ADD 2015/04/08 y.wakita ----->>>>>
                // 更新用リスト再設定処理
                status = this.ReMakeStockAndStockAcPayHist(ref list, ref sqlConnection, ref sqlTransaction);
                // --- ADD 2015/04/08 y.wakita -----<<<<<

                //入荷即返品未対応(処理しない)

                //●既存仕入伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (oldStockSlipWork == null)
                        {
                            if (originList[i] is StockSlipWork)
                            {
                                oldStockSlipWork = originList[i] as StockSlipWork;
                            }
                        }
                    }
                }

                //●仕入商品区分　商品以外は更新しない
                if (stockSlipWork.StockGoodsCd != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }

                if (oldStockSlipWork != null)
                {
                    if (oldStockSlipWork.StockGoodsCd != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                }

                //●在庫更新処理
                int stockWriteFlg = 0;
                foreach (object item in list)
                {
                    if (item is ArrayList && (item as ArrayList).Count > 0)
                    {
                        if ((item as ArrayList)[0] is StockWork || (item as ArrayList)[0] is StockAcPayHistWork)
                        {
                            stockWriteFlg++;
                        }
                    }
                }

                if (stockWriteFlg >= 1)
                {
                    //在庫更新処理
                    StockDB stockDB = new StockDB();
                    status = stockDB.Write(origin, ref originList, ref list, position, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    # region DELETE
                    //ProductStockCommonParaの生成
                    //--- DEL 2007/09/11 M.Kubota --->>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    for (int i = 0; i < list.Count; i++)
                    //    {
                    //        //製番在庫マスタ更新パラメータ削除
                    //        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is ProductStockWork)
                    //        {
                    //            status = MakeProductCommon(ref list, i);
                    //        }
                    //    }
                    //}
                    //--- DEL 2007/09/11 M.Kubota ---<<<

                    //--- UI側の要望により、在庫マスタ更新パラメータはリストに残しておく 2008/01/30 --->>>
                    //パラメータを削除
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    //在庫マスタ更新パラメータ削除
                    //    if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockWork)
                    //    {
                    //        list.RemoveAt(i);
                    //    }
                    //}
                    //--- UI側の要望により、在庫マスタ更新パラメータはリストに残しておく 2008/01/30 ---<<<
                    
                    //--- DEL 2007/09/11 M.Kubota --->>>
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    //製番在庫マスタ更新パラメータ削除
                    //    if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is ProductStockWork)
                    //    {
                    //        list.RemoveAt(i);
                    //    }
                    //}
                    //--- DEL 2007/09/11 M.Kubota ---<<<
                    # endregion

                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫受払履歴データ更新パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHistWork)
                        {
                            list.RemoveAt(i);
                        }
                    }

                    # region DELETE
                    //--- DEL 2007/09/11 M.Kubota --->>>
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    //在庫受払履歴明細データ更新パラメータ削除
                    //    if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHisDtWork)
                    //    {
                    //        list.RemoveAt(i);
                    //    }
                    //}
                    
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    //製番在庫マスタ削除パラメータ削除
                    //    if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is DeleteProductStockWork)
                    //    {
                    //        list.RemoveAt(i);
                    //    }
                    //}
                    //--- DEL 2007/09/11 M.Kubota ---<<<
                    # endregion
                }

            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMASIRStockUpdateDB.Write:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }

            return status;
        }

        # region [--- DEL 2009/01/30 ---]
        ///// <summary>
        ///// 在庫数差分反映処理
        ///// </summary>
        ///// <param name="stockWork">(ref)設定対象となる在庫データ(差分)</param>
        ///// <param name="stockSlipWork">今回の仕入データ</param>
        ///// <param name="stockDetailWork">今回の仕入明細データ</param>
        ///// <param name="orgStockDetailWork">作成元の仕入明細データ（返品の元になった仕入伝票）</param>
        ///// <param name="stockCountDefference">数量差分</param>
        //private void ReflectStockCountDefference(ref StockWork stockWork, StockSlipWork stockSlipWork, StockDetailWork stockDetailWork, StockDetailWork orgStockDetailWork, double stockCountDefference)
        //{
        //    switch (stockSlipWork.SupplierFormal)
        //    {
        //        // 仕入形式：仕入
        //        case 0:
        //            {
        //                // 仕入在庫数　←　仕入差分数
        //                stockWork.SupplierStock += stockCountDefference;

        //                // 発注又は入荷より計上された仕入データの場合、該当する項目への加減算を行う
        //                switch (stockDetailWork.SupplierFormalSrc)
        //                {
        //                    case 1:
        //                        {
        //                            // 入荷計上
        //                            stockWork.ArrivalCnt -= stockCountDefference;
        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            // 発注計上
        //                            stockWork.SalesOrderCount -= stockCountDefference;
        //                            break;
        //                        }
        //                }

        //                # region [--- DEL 2009/01/28 M.Kubota ---]
        //                // これを行ってしまうと、発注の仕入明細の発注残数が 0 なのに、在庫マスタの発注数が増加するので
        //                // 結果的に数の合わない発注や入荷が発生してしまうので削除する
        //                //// ↓入荷計上・発注計上伝票の返品対応↓
        //                //if ( orgStockDetailWork != null )
        //                //{
        //                //    // （元の伝票が、）発注又は入荷より計上された仕入データの場合、該当する項目への加減算を行う
        //                //    switch ( orgStockDetailWork.SupplierFormalSrc )
        //                //    {
        //                //        case 1:
        //                //            {
        //                //                // 入荷計上
        //                //                stockWork.ArrivalCnt -= stockCountDefference;
        //                //                break;
        //                //            }
        //                //        case 2:
        //                //            {
        //                //                // 発注計上
        //                //                stockWork.SalesOrderCount -= stockCountDefference;
        //                //                break;
        //                //            }
        //                //    }
        //                //}
        //                # endregion
        //                break;
        //            }
        //        // 仕入形式：入荷
        //        case 1:
        //            {
        //                // 入荷数に仕入差分数を加算する
        //                stockWork.ArrivalCnt += stockCountDefference;

        //                // 発注より計上された入荷データの場合、該当する項目への加減算を行う
        //                if (stockDetailWork.SupplierFormalSrc == 2)
        //                {
        //                    stockWork.SalesOrderCount -= stockCountDefference;
        //                }

        //                break;
        //            }
        //        // 仕入形式：発注
        //        case 2:
        //            {
        //                // 発注数に仕入差分数を加算する
        //                stockWork.SalesOrderCount += stockCountDefference;
        //                break;
        //            }
        //    }
        //}
        #endregion

        #endregion

        #region[Delete]
        /// <summary>
        /// 在庫更新削除初期処理
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList">呼び出し元</param>
        /// <param name="list">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ物理削除初期処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.25</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int oldStockSlip_Position = -1;

            //仕入ヘッダクラス格納用
            StockSlipWork oldStockSlipWork = null;

            //在庫系削除パラメータ格納List
            ArrayList oldStockWorkList = new ArrayList();
            //ArrayList oldProductStockWorkList = new ArrayList();     //DEL 2007/09/11 M.Kubota
            ArrayList oldStockAcPayHistWorkList = new ArrayList();
            //ArrayList oldStockAcPayHisDtWorkList = new ArrayList();  //DEL 2007/09/11 M.Kubota
            //ArrayList deleteProductStockWorkList = new ArrayList();  //DEL 2007/09/11 M.Kubota

            //ArrayList oldProductStockCommonParaList = null; // add 2007.06.07 saito  //DEL 2007/09/11 M.Kubota

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.DeleteInitial:プログラムエラー。更新対象オブジェクトパラメータが未指定です");
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.DeleteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●削除仕入伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (oldStockSlipWork == null)
                        {
                            if (originList[i] is StockSlipWork)
                            {
                                oldStockSlipWork = originList[i] as StockSlipWork;
                                oldStockSlip_Position = i;

                                //--- DEL 2008/03/13 M.Kubota --->>>
                                // 発注書が印刷されていない(仕入形式=2:発注で仕入伝票番号が未採番)場合は
                                // 在庫更新とは無関係なのでスルーする。
                                //if (oldStockSlipWork.SupplierFormal == 2 && oldStockSlipWork.SupplierSlipNo <= 0)
                                //{
                                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                //    return status;
                                //}
                                //--- DEL 2008/03/13 M.Kubota ---<<<

                                break;
                            }
                        }
                    }
                }

                if (oldStockSlipWork == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.DeleteInitial:プログラムエラー。仕入データ削除パラメータが未指定です");
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 仕入データ削除パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }
                else
                {
                    //●企業コードに紐付く拠点コード・名称の一覧を取得する
                    status = this.GetSecInfoSetWork(oldStockSlipWork.EnterpriseCode, out this._secInfoSeTtable, ref sqlConnection, ref sqlTransaction);  //ADD 2007/09/11 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //●削除パラメータ取得
                        for (int i = 0; i < originList.Count; i++)
                        {
                            //●在庫マスタ・在庫受払履歴データ削除パラメータ取得
                            if (originList[i] is ArrayList && ((ArrayList)originList[i]).Count > 0 && ((ArrayList)originList[i])[0] is StockDetailWork)
                            {
                                StockSlipDeleteWork stcDelWrk = ListUtils.Find(list, typeof(StockSlipDeleteWork), ListUtils.FindType.Class) as StockSlipDeleteWork;
                                StockDetailWork stcDtlWrk = ((originList[i] as ArrayList)[0] as StockDetailWork);

                                if (stcDelWrk != null && stcDtlWrk != null &&
                                    stcDelWrk.EnterpriseCode == stcDtlWrk.EnterpriseCode &&
                                    stcDelWrk.SupplierFormal == stcDtlWrk.SupplierFormal &&
                                    stcDelWrk.SupplierSlipNo == stcDtlWrk.SupplierSlipNo)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    //status = MakeStockAndStockAcPayHist(originList, out oldStockWorkList, out oldStockAcPayHistWorkList, oldStockSlip_Position, i, 1 /* 1:削除 */);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    status = MakeStockAndStockAcPayHist(originList, originList, out oldStockWorkList, out oldStockAcPayHistWorkList, oldStockSlip_Position, i, 1 /* 1:削除 */);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        //●listに追加
                                        if (oldStockWorkList.Count > 0)
                                        {
                                            list.Add(oldStockWorkList);
                                        }

                                        if (oldStockAcPayHistWorkList.Count > 0)
                                        {
                                            list.Add(oldStockAcPayHistWorkList);
                                        }
                                    }
                                }
                            }

                            //●製番在庫マスタ・在庫受払履歴明細データ削除パラメータ取得
                            //if (originList[i] is ArrayList && ((ArrayList)originList[i]).Count > 0 && ((ArrayList)originList[i])[0] is StockExplaDataWork)
                            //{
                            //    status = MakeProductStockAndStockAcPayHisDt(originList, out oldProductStockWorkList, out oldStockAcPayHisDtWorkList, oldProductStockCommonParaList, oldStockSlip_Position, i, 1 /* 1:削除 */, out retMsg, ref sqlConnection, ref sqlTransaction);
                            //}
                        }
                    }
                }

                # region DELETE
                //if (oldProductStockWorkList != null) list.Add(oldProductStockWorkList);

                /*--- DEL 2007/09/11 M.Kubota --->>>
                if (oldStockAcPayHisDtWorkList.Count > 0)
                {
                    list.Add(oldStockAcPayHisDtWorkList);
                }
                  
                //●削除製造番号データ作成
                //※仕入伝票・受託伝票の場合は製番削除List生成
                if (oldStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                    oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                {
                    if (oldProductStockWorkList != null && oldProductStockWorkList.Count > 0)
                    {
                        status = MakeDeleteProductStock(oldProductStockWorkList, out deleteProductStockWorkList);

                        if (deleteProductStockWorkList != null && deleteProductStockWorkList.Count > 0)
                        {
                            list.Add(deleteProductStockWorkList);
                        }
                    }
                }
                //※赤伝票・返品伝票・受託計上伝票の場合はUPDATE
                else
                {
                    if (oldProductStockWorkList != null && oldProductStockWorkList.Count > 0)
                    {
                        list.Add(oldProductStockWorkList);
                    }
                }
                  ---DEL 2007/09/11 M.Kubota ---<<<*/
                # endregion
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMASIRStockUpdateDB.DeleteInitial:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }

        /// <summary>
        /// 在庫更新削除します
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList">呼び出し元</param>
        /// <param name="list">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫更新削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.25</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int oldStockSlip_Position = -1;

            //仕入ヘッダクラス格納用
            StockSlipWork oldStockSlipWork = null;

            //在庫系パラメータ格納List
            ArrayList oldStockWorkList = new ArrayList();
            ArrayList oldProductStockWorkList = new ArrayList();
            ArrayList oldStockAcPayHistWorkList = new ArrayList();
            ArrayList oldStockAcPayHisDtWorkList = new ArrayList();

            CustomSerializeArrayList workArray = new CustomSerializeArrayList();

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.Delete:プログラムエラー。削除対象オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 削除対象オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMASIRStockUpdateDB.Delete:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●既存仕入伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (oldStockSlipWork == null)
                        {
                            if (originList[i] is StockSlipWork)
                            {
                                oldStockSlipWork = originList[i] as StockSlipWork;
                                oldStockSlip_Position = i;

                                //--- DEL 2008/03/13 M.Kubota --->>>
                                // 発注書が印刷されていない(仕入形式=2:発注で仕入伝票番号が未採番)場合は
                                // 在庫更新とは無関係なのでスルーする。
                                //if (oldStockSlipWork.SupplierFormal == 2 && oldStockSlipWork.SupplierSlipNo <= 0)
                                //{
                                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                //    return status;
                                //}
                                //--- DEL 2008/03/13 M.Kubota ---<<<
                            }
                        }
                    }
                }

                //●仕入商品区分　商品以外は更新しない
                if (oldStockSlipWork != null)
                {
                    if (oldStockSlipWork.StockGoodsCd != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                }

                //●戻り値を正常で初期化
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // --- ADD 2015/04/08 y.wakita ----->>>>>
                // 更新用リスト再設定処理
                status = this.ReMakeStockAndStockAcPayHist(ref list, ref sqlConnection, ref sqlTransaction);
                // --- ADD 2015/04/08 y.wakita -----<<<<<

                //●在庫削除処理
                int stockWriteFlg = 0;
                foreach (object item in list)
                {
                    if (item is ArrayList && (item as ArrayList).Count > 0)
                    {
                        if ((item as ArrayList)[0] is StockWork || (item as ArrayList)[0] is StockAcPayHistWork)
                        {
                            stockWriteFlg++;
                        }
                    }
                }

                if (stockWriteFlg >= 1)
                {
                    StockDB stockDB = new StockDB();

                    //--- ADD 2007/09/11 M.Kubota --->>>
                    // 仕入・入荷・発注 に関わらず、在庫データは常に更新とする。
                    // ※ 在庫数や入荷数、発注数などの増減を行うため、更新パラメータの適所に増減差分値を設定しておく
                    status = stockDB.Write(origin, ref originList, ref list, position, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //--- ADD 2007/09/11 M.Kubota ---<<<

                    # region DELETE
                    //--- DEL 2007/09/11 M.Kubota --->>>
                    ////通常仕入削除の場合
                    //if (oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    status = stockDB.Delete(origin, ref originList, ref list, position, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //}
                    ////(売上時自動)受託計上仕入削除の場合
                    //else if (oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                    //         oldStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                    //{
                    //    status = stockDB.Write(origin, ref originList, ref list, position, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //}
                    //--- DEL 2007/09/11 M.Kubota ---<<<
                    # endregion

                    //パラメータを削除
                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫マスタ削除パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockWork)
                        {
                            list.RemoveAt(i);
                        }
                    }

                    # region DELETE
                    /*--- DEL 2007/09/11 M.Kubota --->>>
                    for (int i = 0; i < list.Count; i++)
                    {
                        //製番在庫マスタ削除パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is ProductStockWork)
                        {
                            list.RemoveAt(i);
                        }
                    }
                      --- DEL 2007/09/11 M.Kubota ---<<<*/
                    # endregion

                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫受払履歴データ削除パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHistWork)
                        {
                            list.RemoveAt(i);
                        }
                    }

                    # region DELETE
                    /*--- DEL 2007/09/11 M.Kubota --->>>
                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫受払履歴明細データ削除パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHisDtWork)
                        {
                            list.RemoveAt(i);
                        }
                    }
                      --- DEL 2007/09/11 M.Kubota ---<<<*/
                    # endregion
                }

            }
            catch (Exception ex)
            {                 
                //base.WriteErrorLog(ex, "IOWriteMASIRStockUpdateDB.Delete:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }

            return status;
        }
        #endregion



        #region [パラメータ取得処理]
        /// <summary>
        /// 在庫マスタ・在庫受払履歴データ更新データクラス生成
        /// </summary>
        /// <param name="originList">作成元・変更前データリスト</param>
        /// <param name="paraList">更新対象パラメータリスト</param>
        /// <param name="stockList">在庫マスタ更新パラメータ</param>
        /// <param name="stockAcPayHistList">在庫受払履歴データ更新パラメータ</param>
        /// <param name="position">仕入データ格納位置</param>
        /// <param name="detailPosition">仕入明細データ格納位置</param>
        /// <param name="mode">0:加算 1:減算</param>
        /// <returns>STATUS</returns>
        private int MakeStockAndStockAcPayHist( CustomSerializeArrayList originList, CustomSerializeArrayList paraList, out ArrayList stockList, out ArrayList stockAcPayHistList, Int32 position, Int32 detailPosition, Int32 mode )
        {
            //伝票新規作成の場合の受払の処理。（更新はMakeStockDetailWorkAddで処理）

            //出力パラメータList(在庫・受払)
            stockList = new ArrayList();
            stockAcPayHistList = new ArrayList();

            //更新パラメータクラス格納用(在庫・受払)
            StockWork stockWork = null;
            StockAcPayHistWork stockAcPayHistWork = null;

            //仕入データワーク格納用(ヘッダ・明細)
            StockSlipWork wkStockSlipWork = paraList[position] as StockSlipWork;
            StockDetailWork wkStockDetailWork = null;
            ArrayList wkStockDetailWorkList = paraList[detailPosition] as ArrayList;


            # region [--- DEL 2009/01/30 M.Kubota ---]
            //// 元伝票のStockSlipWork, StockDetailWorkリスト
            //StockSlipWork orgStockSlipWork;
            //ArrayList orgStockDetailWorkList;
            //FindOriginalStockSlip( out orgStockSlipWork, out orgStockDetailWorkList, originList, wkStockSlipWork );

            //// 明細セレクタ生成
            //StockDetailsSelector detailsSelector = new StockDetailsSelector(orgStockDetailWorkList);
            #endregion

            StockDetailWork orgStockDetailWork = null;

            //--- ADD 2009/01/30 M.Kubota --->>>
            ArrayList workList = null;

            // ●変更元明細データ格納リスト
            List<StockDetailWork> orgDtlList = new List<StockDetailWork>();

            workList = ListUtils.Find(originList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                orgDtlList.AddRange((StockDetailWork[])workList.ToArray(typeof(StockDetailWork)));
            }

            // ●明細追加情報データ格納リスト
            List<SlipDetailAddInfoWork> slpDtlAddInfList = new List<SlipDetailAddInfoWork>();

            workList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                slpDtlAddInfList.AddRange((SlipDetailAddInfoWork[])workList.ToArray(typeof(SlipDetailAddInfoWork)));
            }

            // ●計上元明細データ格納リスト
            List<AddUpOrgStockDetailWork> addUpOrgDtlList = new List<AddUpOrgStockDetailWork>();

            workList = ListUtils.Find(paraList, typeof(AddUpOrgStockDetailWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                addUpOrgDtlList.AddRange((AddUpOrgStockDetailWork[])workList.ToArray(typeof(AddUpOrgStockDetailWork)));
            }
            //--- ADD 2009/01/30 M.Kubota ---<<<


            # region [--- DEL 2009/01/28 M.Kubota ---]
            //データ比較クラス(在庫・受払)
            //StockAcPayHistWorkComparer stockAcPayHistWorkComparer = new StockAcPayHistWorkComparer();
            # endregion

            //●更新パラメータ格納処理
            for (int i = 0; i < wkStockDetailWorkList.Count; i++)
            {
                wkStockDetailWork = wkStockDetailWorkList[i] as StockDetailWork;
                
                // 対応する元伝票明細を取得
                //orgStockDetailWork = detailsSelector.Find( wkStockDetailWork );  //DEL 2009/01/30

                //--- ADD 2009/01/30 --->>>
                orgStockDetailWork = orgDtlList.Find(delegate(StockDetailWork orgDtl)
                {
                    if (wkStockSlipWork.DebitNoteDiv == 1 && mode == 0)
                    {
                        // 赤伝の新規登録の場合は orgDtlList に元黒の明細データが格納されているが
                        // 赤伝の削除の場合は orgDtlList には削除前の赤伝の明細が格納されている為
                        // 処理を分ける
                        return orgDtl.SupplierFormal == wkStockDetailWork.SupplierFormalSrc &&
                               orgDtl.StockSlipDtlNum == wkStockDetailWork.StockSlipDtlNumSrc;


                    }
                    else
                    {
                        return orgDtl.SupplierFormal == wkStockDetailWork.SupplierFormal &&
                               orgDtl.StockSlipDtlNum == wkStockDetailWork.StockSlipDtlNum;
                    }
                });
                //--- ADD 2009/01/30 ---<<<

                stockWork = new StockWork();
                stockAcPayHistWork = new StockAcPayHistWork();

                if (!wkStockDetailWork.StockUpdateDiv) continue;

                #region[在庫マスタ更新パラメータ格納]
                //--------------------------------------------------------------------------------------------------
                //●在庫マスタ更新パラメータ格納    Start
                //--------------------------------------------------------------------------------------------------
                //仕入ヘッダ　→　在庫マスタ
                stockWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;     // 企業コード
                stockWork.SectionCode = wkStockSlipWork.SectionCode;           // 拠点コード
                stockWork.LastStockDate = wkStockSlipWork.StockDate;           // 最終仕入年月日　←　仕入日

                //仕入明細　→　在庫マスタ
                stockWork.GoodsMakerCd = wkStockDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                stockWork.GoodsNo = wkStockDetailWork.GoodsNo;                            // 商品番号
                // 2009/03/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 在庫単価は棚卸評価単価として使用するため、仕入単価はセットしない
                //stockWork.StockUnitPriceFl = wkStockDetailWork.StockUnitPriceFl;          // 仕入単価
                // 2009/03/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                stockWork.WarehouseCode = wkStockDetailWork.WarehouseCode;                // 倉庫コード
                stockWork.WarehouseShelfNo = wkStockDetailWork.WarehouseShelfNo;          // 倉庫棚番

                //double StockCountDifference = Math.Abs(wkStockDetailWork.StockCountDifference);
                double StockCountDifference = wkStockDetailWork.StockCountDifference;

                StockCountDifference *= ((mode == 0) ? 1 : -1);                             // 加算・減算
                //StockCountDifference *= ((wkStockSlipWork.DebitNoteDiv == 1) ? -1 : 1);     // 黒伝・赤伝
                //StockCountDifference *= ((wkStockSlipWork.SupplierSlipCd == 20) ? -1 : 1);  // 仕入・返品

                // 数量差分適用
                //ReflectStockCountDefference( ref stockWork, wkStockSlipWork, wkStockDetailWork, orgStockDetailWork, StockCountDifference ); //DEL 2009/01/30

                //--- ADD 2009/01/30 --->>>
                ReflectCntDifData refCntDifDat = new ReflectCntDifData(wkStockSlipWork, wkStockDetailWork, null, orgStockDetailWork, null, StockCountDifference, 0, mode);

                // 明細追加情報を検索し、計上残区分を取得する
                refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                // 計上元明細データを検索する
                refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgStockDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                // 計上残区分を設定する
                refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                this.ReflectStockCountDefference(ref stockWork, refCntDifDat);
                //--- ADD 2009/01/30 ---<<<

                stockList.Add(stockWork);
                //--------------------------------------------------------------------------------------------------
                //●在庫マスタ更新パラメータ格納    End
                //--------------------------------------------------------------------------------------------------
                #endregion

                #region[在庫受払履歴データ更新パラメータ格納]
                //--------------------------------------------------------------------------------------------------
                //●在庫受払履歴データ更新パラメータ格納    Start
                //--------------------------------------------------------------------------------------------------
                
                // 0:仕入　1:入荷 のみ在庫受払履歴データを作成・更新する
                if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase ||
                    wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                {
                    //--- ADD 2009/01/28 M.Kubota --->>>
                    this.StockSlipToStockAcPayHist(wkStockSlipWork, wkStockDetailWork, orgStockDetailWork, mode, ref stockAcPayHistWork);
                    stockAcPayHistWork.ArrivalCnt = StockCountDifference;  // 入荷数(差分を設定)  ※不要か？
                    //--- ADD 2009/01/28 M.Kubota ---<<<

                    # region [--- DEL 2009/01/28 M.Kubota --- 修正範囲が大きいので全削除]
# if false                    
                    // 在庫受払履歴データ ← 仕入ヘッダ
                    stockAcPayHistWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;   //企業コード

                    // 仕入形式によって設定値が異なる項目
                    switch (wkStockSlipWork.SupplierFormal)
                    {
                        case (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase:  // 仕入
                            {
                                if (wkStockDetailWork.SupplierFormalSrc == 1 ||                                                                            // 入荷引当した仕入
                                    (wkStockDetailWork.StockSlipCdDtl == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1) ||  // 入荷引当した仕入の返品
                                    (wkStockSlipWork.DebitNoteDiv == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1))        // 入荷引当した仕入の赤伝
                                {
                                    stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                // 入出荷日 ← 未設定(最小値)
                                }
                                else
                                {
                                    stockAcPayHistWork.IoGoodsDay = wkStockSlipWork.ArrivalGoodsDay;  // 入出荷日 ← 入荷日
                                }

                                stockAcPayHistWork.AddUpADate = wkStockSlipWork.StockDate;            // 計上日付 ← 仕入日                                
                                stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Stock;  // 受払元伝票区分 10:仕入
                                break;
                            }
                        case (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust:    // 入荷
                            {
                                stockAcPayHistWork.IoGoodsDay = wkStockSlipWork.ArrivalGoodsDay;  // 入出荷日 ← 入荷日
                                stockAcPayHistWork.AddUpADate = DateTime.MinValue;                // 計上日付 ← 未設定(最小値)
                                stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Trust;  // 受払元伝票区分 11:入荷
                                break;
                            }
                    }

                    stockAcPayHistWork.AcPaySlipNum = wkStockSlipWork.SupplierSlipNo.ToString();  // 受払元伝票番号
                    stockAcPayHistWork.AcPaySlipRowNo = wkStockDetailWork.StockRowNo;             // 受払元行番号
                    stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;                    // 受払履歴作成日時

                    //受払元取引区分
                    # region [--- DEL 2009/01/15 M.Kubota ---]
                    ////仕入伝票更新(受託計上伝票も含む)
                    //if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                    //    wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                    //{
                    //    //通常伝票
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                    //}
                    ////赤伝票更新(受託計上伝票も含む)
                    //else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 0)
                    //{
                    //    //赤伝
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                    //}
                    ////返品伝票更新
                    //else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                    //         wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                    //{
                    //    //返品
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                    //}
                    ////伝票削除
                    //else if (mode == 1)
                    //{
                    //    //削除
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                    //}
                    # endregion
                    //--- ADD 2009/01/15 M.Kubota --->>>
                    if (mode == 0)
                    {
                        if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                        {
                            //返品
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                        }
                        else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                        {
                            //赤伝
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                        }
                        else
                        {
                            //通常伝票
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                        }
                    }
                    else
                    {
                        //削除
                        stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                    }
                    //--- ADD 2009/01/15 M.Kubota ---<<<

                    stockAcPayHistWork.InputSectionCd = wkStockSlipWork.StockSectionCd;   // 入力拠点コード ← 仕入拠点コード

                    // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                    //object objSecNm = this._secInfoSeTtable[wkStockSlipWork.StockSectionCd];       //DEL 2009/01/13 M.Kubota
                    object objSecNm = this._secInfoSeTtable[wkStockSlipWork.StockSectionCd.Trim()];  //ADD 2009/01/13 M.Kubota

                    //入力拠点ガイド名称
                    if (objSecNm is string)
                    {
                        stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }

                    stockAcPayHistWork.InputAgenCd = wkStockSlipWork.StockAgentCode;         // 入力担当者コード ← 仕入担当者コード
                    stockAcPayHistWork.InputAgenNm = wkStockSlipWork.StockAgentName;         // 入力担当者名称 ← 仕入担当者名称
                    stockAcPayHistWork.CustSlipNo = wkStockDetailWork.OrderNumber;           // 相手先伝票番号
                    stockAcPayHistWork.SlipDtlNum = wkStockDetailWork.StockSlipDtlNum;       // 仕入明細通番
                    stockAcPayHistWork.AcPayNote = wkStockDetailWork.StockDtiSlipNote1;      // 仕入伝票明細備考1
                    stockAcPayHistWork.GoodsMakerCd = wkStockDetailWork.GoodsMakerCd;        // 商品メーカーコード
                    stockAcPayHistWork.MakerName = wkStockDetailWork.MakerName;              // メーカー名称
                    stockAcPayHistWork.GoodsNo = wkStockDetailWork.GoodsNo;                  // 商品番号
                    stockAcPayHistWork.GoodsName = wkStockDetailWork.GoodsName;              // 商品名称
                    stockAcPayHistWork.BLGoodsCode = wkStockDetailWork.BLGoodsCode;          // BL商品コード
                    stockAcPayHistWork.BLGoodsFullName = wkStockDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                    stockAcPayHistWork.SectionCode = wkStockSlipWork.SectionCode;            // 拠点コード

                    // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                    //objSecNm = this._secInfoSeTtable[wkStockSlipWork.StockSectionCd];    //DEL 2009/01/13 M.Kubota
                    objSecNm = this._secInfoSeTtable[wkStockSlipWork.SectionCode.Trim()];  //ADD 2009/01/13 M.Kubota

                    // 拠点ガイド名称
                    if (objSecNm is string)
                    {
                        stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }

                    stockAcPayHistWork.WarehouseCode = wkStockDetailWork.WarehouseCode;          // 倉庫コード
                    stockAcPayHistWork.WarehouseName = wkStockDetailWork.WarehouseName;          // 倉庫名称
                    stockAcPayHistWork.ShelfNo = wkStockDetailWork.WarehouseShelfNo;             // 倉庫棚番
                    stockAcPayHistWork.SupplierCd = wkStockSlipWork.SupplierCd;                  // 仕入先コード
                    stockAcPayHistWork.SupplierSnm = wkStockSlipWork.SupplierSnm;                // 仕入先略称
                    stockAcPayHistWork.ArrivalCnt = StockCountDifference;                        // 入荷数 (差分を設定)
                    stockAcPayHistWork.ShipmentCnt = 0;                                          // 出荷数
                    stockAcPayHistWork.OpenPriceDiv = wkStockDetailWork.OpenPriceDiv;            // オープン価格区分
                    stockAcPayHistWork.ListPriceTaxExcFl = wkStockDetailWork.ListPriceTaxExcFl;  // 定価(税抜・浮動)
                    stockAcPayHistWork.StockUnitPriceFl = wkStockDetailWork.StockUnitPriceFl;    // 仕入単価(税抜・浮動)
                    stockAcPayHistWork.StockPrice = wkStockDetailWork.StockPriceTaxExc;          // 仕入金額(税抜)
# endif
                    # endregion
                    stockAcPayHistList.Add(stockAcPayHistWork);

                    //入荷計上で「残さない」の設定が出来るようになった場合はここに追加↓

                }
                //--------------------------------------------------------------------------------------------------
                //●在庫受払履歴データ更新パラメータ格納    End
                //--------------------------------------------------------------------------------------------------
                #endregion
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }

        /// <summary>
        /// 仕入伝票修正時の在庫マスタ更新パラメータ作成
        /// </summary>
        /// <param name="stockSlipWork">旧仕入データ</param>
        /// <param name="stockDetailWorkList">仕入明細データLsit</param>
        /// <param name="originList">変更前リスト</param>
        /// <param name="paraList">計上元リスト</param>
        /// <param name="stockWorkUpdateList">在庫更新パラメータ</param>
        /// <param name="stockAcPayHistWorkUpdateList">在庫受払更新パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票修正時の在庫マスタ更新パラメータ作成</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.06.09</br>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private int MakeStockDetailWorkAdd(StockSlipWork stockSlipWork, ArrayList oldStockDetailWorkList, ArrayList stockDetailWorkList, out ArrayList stockWorkUpdateList)
        //private int MakeStockDetailWorkAdd( StockSlipWork stockSlipWork, ArrayList stockDetailWorkList, CustomSerializeArrayList originList, out ArrayList stockWorkUpdateList )  //DEL 2008/03/13 M.Kubota
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //private int MakeStockDetailWorkAdd(StockSlipWork stockSlipWork, ArrayList stockDetailWorkList, CustomSerializeArrayList originList, out ArrayList stockWorkUpdateList, out ArrayList stockAcPayHistWorkUpdateList)  //ADD 2008/03/13 M.Kubota DEL 2009/01/30
        private int MakeStockDetailWorkAdd(StockSlipWork stockSlipWork, ArrayList stockDetailWorkList, CustomSerializeArrayList originList, CustomSerializeArrayList paraList, out ArrayList stockWorkUpdateList, out ArrayList stockAcPayHistWorkUpdateList)  //ADD 2008/03/13 M.Kubota DEL 2009/01/30
        {
            //伝票更新の場合の受払の処理（新規作成はMakeStockAndStockAcPayHistで処理）

            stockWorkUpdateList = new ArrayList();
            stockAcPayHistWorkUpdateList = new ArrayList();  //ADD 2008/03/13 M.Kubota

            //更新パラメータ格納用(在庫・在庫受払履歴)
            StockWork oldStockWork = null;
            StockWork stockWork = null;
            StockAcPayHistWork stockAcPayHistWork = null;  //ADD 2008/03/13 M.Kubota
            StockAcPayHistWork counterStockAcPayHistWork = null;  //ADD 2009/01/22 M.Kubota
            ReflectCntDifData refCntDifDat = null;  //ADD 2009/01/30

            //仕入明細データ格納用
            StockDetailWork stockDetailWork = null;
            StockDetailWork oldStockDetailWork = null;

            # region [--- DEL 2009/01/30 ---]
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 変更前仕入データ
            //StockSlipWork oldStockSlipWork;
            //ArrayList oldStockDetailWorkList;

            //// 作成元仕入データ
            //StockSlipWork orgStockSlipWork;
            //ArrayList orgStockDetailWorkList;

            //// originListから取得
            //FindOldAndOriginStockSlip(out oldStockSlipWork, out oldStockDetailWorkList, out orgStockSlipWork, out orgStockDetailWorkList, originList, stockSlipWork);

            //// 明細セレクタ生成
            //StockDetailsSelector detailsSelector = new StockDetailsSelector(orgStockDetailWorkList);

            //// 明細セレクタで取得した作成元伝票の明細１レコード
            //StockDetailWork orgStockDetailWork;// = null;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            //--- ADD 2009/01/30 --->>>
            // 変更前仕入データ
            StockSlipWork oldStockSlipWork = ListUtils.Find(originList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
            ArrayList oldStockDetailWorkList = ListUtils.Find(originList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

            ArrayList workList = null;

            // ●明細追加情報データ格納リスト
            List<SlipDetailAddInfoWork> slpDtlAddInfList = new List<SlipDetailAddInfoWork>();

            workList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                slpDtlAddInfList.AddRange((SlipDetailAddInfoWork[])workList.ToArray(typeof(SlipDetailAddInfoWork)));
            }

            // ●計上元明細データ格納リスト
            List<AddUpOrgStockDetailWork> addUpOrgDtlList = new List<AddUpOrgStockDetailWork>();

            workList = ListUtils.Find(paraList, typeof(AddUpOrgStockDetailWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                addUpOrgDtlList.AddRange((AddUpOrgStockDetailWork[])workList.ToArray(typeof(AddUpOrgStockDetailWork)));
            }
            //--- ADD 2009/01/30 ---<<<

            //該当データなしフラグ
            bool flg;

            StockAcPayHistWorkComparer stockAcPayHistWorkComparer = new StockAcPayHistWorkComparer();  //ADD 2008/03/13 M.Kubota

            //●在庫数の差分計算(追加データはそのまま)
            //旧明細リストをベースに読み込み
            for (int i = 0; i < oldStockDetailWorkList.Count; i++)
            {
                oldStockDetailWork = oldStockDetailWorkList[i] as StockDetailWork;

                flg = false;

                for (int x = 0; x < stockDetailWorkList.Count; x++)
                {
                    stockDetailWork = stockDetailWorkList[x] as StockDetailWork;

                    # region [--- DEL 2009/01/28 M.Kubota ---]
                    # region [--- DEL 2008/02/27 M.Suzuki ---]
                    ////--- DEL 2007/09/11 M.Kubota --->>>
                    ////if (oldStockDetailWork.StockRowNo == stockDetailWork.StockRowNo && oldStockDetailWork.MakerCode == stockDetailWork.MakerCode &&
                    ////    oldStockDetailWork.GoodsCode == stockDetailWork.GoodsCode)
                    ////--- DEL 2007/09/11 M.Kubota ---<<<
                    ////--- ADD 2007/09/11 M.Kubota --->>>
                    //if (oldStockDetailWork.StockRowNo == stockDetailWork.StockRowNo && oldStockDetailWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd &&
                    //    oldStockDetailWork.GoodsNo == stockDetailWork.GoodsNo)
                    ////--- ADD 2007/09/11 M.Kubota ---<<<
                    # endregion
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                    // 行№.拠点.倉庫.ﾒｰｶｰ.商品番号が一致するなら変更とみなす
                    //if (oldStockDetailWork.StockRowNo == stockDetailWork.StockRowNo &&
                    //     oldStockDetailWork.SectionCode.TrimEnd() == stockDetailWork.SectionCode.TrimEnd() &&
                    //     oldStockDetailWork.WarehouseCode.TrimEnd() == stockDetailWork.WarehouseCode.TrimEnd() &&
                    //     oldStockDetailWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd &&
                    //     oldStockDetailWork.GoodsNo.TrimEnd() == stockDetailWork.GoodsNo.TrimEnd() &&
                    //     oldStockDetailWork.StockSlipDtlNum == stockDetailWork.StockSlipDtlNum)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    # endregion

                    // 倉庫・メーカー・品番・明細通番が一致する場合は変更明細とみなす
                    if (oldStockDetailWork.WarehouseCode.TrimEnd() == stockDetailWork.WarehouseCode.TrimEnd() &&
                        oldStockDetailWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd &&
                        oldStockDetailWork.GoodsNo.TrimEnd() == stockDetailWork.GoodsNo.TrimEnd() &&
                        oldStockDetailWork.StockSlipDtlNum == stockDetailWork.StockSlipDtlNum)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                        // 同一キーの行が有った時点で「更新」である事は決まるので、flg = true とする。
                        // もし非在庫ならば、この後で判定して迂回する。
                        flg = true;

                        # region [--- DEL 2009/01/30 ---]
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.29
                        //// 作成元伝票の明細データ取得
                        //orgStockDetailWork = detailsSelector.Find(stockDetailWork);
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.29
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.03.07
                        #endregion

                        //在庫管理有無区分・仕入数チェック
                        # region [--- DEL 2008/06/03 M.Kubota ---]
                        //if ( stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                        //    (stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && stockDetailWork.StockOrderDivCd == 0) ||
                        //    stockDetailWork.StockCount == 0 ) continue;
                        # endregion
                        if (!stockDetailWork.StockUpdateDiv) continue; //ADD 2008/06/03 M.Kubota
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.03.07

                        //差分抽出
                        #region[在庫マスタ更新パラメータ格納]

                        stockWork = new StockWork();

                        # region [--- DEL 2008/03/07 m.suzuki ---]
                        ////在庫管理有無区分・仕入数チェック
                        //if (stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                        //    (stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && stockDetailWork.StockOrderDivCd == 0) ||
                        //    stockDetailWork.StockCount == 0) continue;
                        # endregion

                        //仕入ヘッダ　→　在庫マスタ
                        stockWork.EnterpriseCode = stockSlipWork.EnterpriseCode;                //企業コード
                        stockWork.SectionCode = stockSlipWork.StockSectionCd;                   //拠点コード ← 仕入拠点コード
                        stockWork.LastStockDate = stockSlipWork.StockDate;                      //最終仕入年月日　←　仕入日

                        //仕入明細　→　在庫マスタ
                        //--- ADD 2007/09/11 M.Kubota --->>>
                        stockWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                        
                        stockWork.GoodsNo = stockDetailWork.GoodsNo;                            // 商品番号
                        
                        # region [--- DEL 2008/06/03 M.Kubota ---] 
                        //stockWork.MakerName = stockDetailWork.MakerName;                      // メーカー名称
                        //stockWork.GoodsName = stockDetailWork.GoodsName;                      // 商品名称
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                        //stockWork.GoodsShortName = stockDetailWork.GoodsShortName;            // 商品名略称  //DEL 2008/06/03 M.Kubota
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                        //stockWork.BLGoodsCode = stockDetailWork.BLGoodsCode;                  // BL商品コード
                        //stockWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;          // BL商品コード名称(全角)
                        //stockWork.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode;  // 自社分類コード
                        //stockWork.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName;  // 自社分類コード名称(全角)
                        # endregion

                        // 2009/03/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // 在庫単価は棚卸評価単価として使用するため、仕入単価はセットしない
                        //stockWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;          // 仕入単価
                        // 2009/03/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        stockWork.WarehouseCode = stockDetailWork.WarehouseCode;                // 倉庫コード
                        stockWork.WarehouseName = stockDetailWork.WarehouseName;                // 倉庫名称
                        stockWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;          // 倉庫棚番
                        //--- ADD 2007/09/11 M.Kubota ---<<<

                        # region [--- DEL 2007/09/11 M.Kubota ---]
                        /*--- DEL 2007/09/11 M.Kubota --->>>
                        stockWork.MakerName = stockDetailWork.MakerName;            //メーカー名称
                        stockWork.GoodsName = stockDetailWork.GoodsName;            //商品名称
                        stockWork.StockUnitPrice = stockDetailWork.StockUnitPrice;  //仕入単価
                        stockWork.CarrierCode = stockDetailWork.CarrierCode;        //キャリアコード
                        stockWork.CarrierName = stockDetailWork.CarrierName;        //キャリア名称
                        stockWork.SystematicColorCd = stockDetailWork.SystematicColorCd;    //系統色コード
                        stockWork.SystematicColorNm = stockDetailWork.SystematicColorNm;    //系統色名称
                        stockWork.LargeGoodsGanreCode = stockDetailWork.LargeGoodsGanreCode;    //商品大分類コード
                        stockWork.MediumGoodsGanreCode = stockDetailWork.MediumGoodsGanreCode;  //商品中分類コード
                        stockWork.PrdNumMngDiv = stockDetailWork.PrdNumMngDiv;        //製番管理区分
                        stockWork.CellphoneModelCode = stockDetailWork.CellphoneModelCode;    //機種コード
                        stockWork.CellphoneModelName = stockDetailWork.CellphoneModelName;    //機種名称
                        stockWork.MakerCode = stockDetailWork.MakerCode;            //メーカーコード
                        stockWork.GoodsCode = stockDetailWork.GoodsCode;            //商品コード
                         --- DEL 2007/09/11 M.Kubota ---<<<*/
                        # endregion
                        # region [--- DEL 2008/02/29 M.Suzuki ---]
                        ////仕入形式・受託計上仕入区分にて分岐
                        //if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                        //    stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                        //{
                        //    stockWork.SupplierStock = stockDetailWork.StockCount - oldStockDetailWork.StockCount; //仕入在庫数　←　仕入数
                        //}
                        //else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                        //         stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                        //{
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                        //    //stockWork.TrustCount = stockDetailWork.StockCount - oldStockDetailWork.StockCount; //受託数　←　仕入数
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        //    stockWork.ArrivalCnt = stockDetailWork.StockCount - oldStockDetailWork.StockCount; //入荷数　←　仕入数
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                        //}
                        //else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                        //         (stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                        //         stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                        //{
                        //    stockWork.SupplierStock = stockDetailWork.StockCount - oldStockDetailWork.StockCount; //仕入在庫数
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                        //    //stockWork.TrustCount = -(stockDetailWork.StockCount - oldStockDetailWork.StockCount); //受託数
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        //    stockWork.ArrivalCnt = -(stockDetailWork.StockCount - oldStockDetailWork.StockCount); //入荷数
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.29
                        # endregion

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.29
                        double stockCountDifference = stockDetailWork.StockCount - oldStockDetailWork.StockCount;

                        // 在庫数差分反映
                        //this.ReflectStockCountDefference(ref stockWork, stockSlipWork, stockDetailWork, orgStockDetailWork, stockCountDifference); // DEL 2009/01/30
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.29

                        //--- ADD 2009/01/30 --->>>
                        refCntDifDat = new ReflectCntDifData(stockSlipWork, stockDetailWork, null, null, null, stockCountDifference, 0, 0);

                        // 明細追加情報を検索し、計上残区分を取得する
                        refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                        // 計上元明細データを検索する
                        refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgStockDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                        // 計上残区分を設定する
                        refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                        this.ReflectStockCountDefference(ref stockWork, refCntDifDat);
                        //--- ADD 2009/01/30 ---<<<

                        // add 2007.07.12 saito >>>>>>>>>>
                        //(新仕入単価×新在庫数)－(旧仕入単価×旧在庫数)
                        //stockWork.StockTotalPrice = (long)((stockDetailWork.StockUnitPriceFl * stockDetailWork.StockCount) - (oldStockDetailWork.StockUnitPriceFl * oldStockDetailWork.StockCount));
                        // add 2007.07.12 saito <<<<<<<<<<

                        //差分抽出データ格納
                        stockWorkUpdateList.Add(stockWork);
                        #endregion

                        #region[在庫受払履歴データ更新パラメータ格納]
                        //--------------------------------------------------------------------------------------------------
                        //●在庫受払履歴データ更新パラメータ格納    Start
                        //--------------------------------------------------------------------------------------------------

                        // 0:仕入　1:入荷 のみ在庫受払履歴データを作成・更新する
                        if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase ||
                            stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                        {
                            //int mode = 0;  //DEL 2009/01/15 M.Kubota

                            stockAcPayHistWork = new StockAcPayHistWork();
                            counterStockAcPayHistWork = new StockAcPayHistWork();  //相殺用在庫受払履歴データ  //ADD 2009/01/22 M.Kubota

                            # region [--- DEL 2009/01/28 M.Kubota --- 修正範囲が大きいので全削除]
# if false
                            // 在庫受払履歴データ ← 仕入ヘッダ
                            stockAcPayHistWork.EnterpriseCode = stockSlipWork.EnterpriseCode;   //企業コード

                            //stockAcPayHistWork.ValidDivCd = mode;  //DEL 2008/06/06 M.Kubota

                            // 仕入形式によって設定値が異なる項目
                            switch (stockSlipWork.SupplierFormal)
                            {
                                case (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase:
                                    {
                                        // 仕入
                                        if (stockDetailWork.SupplierFormalSrc == 1 ||                                                                            // 入荷引当した仕入
                                            (stockDetailWork.StockSlipCdDtl == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1) ||  // 入荷引当した仕入の返品
                                            (stockSlipWork.DebitNoteDiv == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1))        // 入荷引当した仕入の赤伝
                                        {
                                            stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                                 // 入出荷日 ← 未設定(最小値)
                                        }
                                        else
                                        {
                                            stockAcPayHistWork.IoGoodsDay = stockSlipWork.ArrivalGoodsDay;                     // 入出荷日 ← 入荷日
                                        }

                                        stockAcPayHistWork.AddUpADate = stockSlipWork.StockDate;                               // 計上日付 ← 仕入日                                
                                        stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Stock;  // 受払元伝票区分 10:仕入
                                        break;
                                    }
                                case (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust:
                                    {
                                        // 入荷
                                        stockAcPayHistWork.IoGoodsDay = stockSlipWork.ArrivalGoodsDay;                         // 入出荷日 ← 入荷日
                                        stockAcPayHistWork.AddUpADate = DateTime.MinValue;                                     // 計上日付 ← 未設定(最小値)
                                        stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Trust;  // 受払元伝票区分 11:入荷
                                        break;
                                    }
                            }

                            stockAcPayHistWork.AcPaySlipNum = stockSlipWork.SupplierSlipNo.ToString();  // 受払元伝票番号
                            stockAcPayHistWork.AcPaySlipRowNo = stockDetailWork.StockRowNo;             // 受払元行番号
                            stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;                  // 受払履歴作成日時

                            //受払元取引区分
                            # region [--- DEL 2009/01/15 M.Kubota ---]
                            ////仕入伝票更新(受託計上伝票も含む)
                            //if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                            //    stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                            //{
                            //    //通常伝票
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                            //}
                            ////赤伝票更新(受託計上伝票も含む)
                            //else if (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 0)
                            //{
                            //    //赤伝
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                            //}
                            ////返品伝票更新
                            //else if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                            //    stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                            //{
                            //    //返品
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                            //}
                            ////伝票削除
                            //else if (mode == 1)
                            //{
                            //    //削除
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                            //}
                            # endregion
                            //--- ADD 2009/01/15 M.Kubota --->>>
                            if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                            {
                                //返品
                                stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                            }
                            else if (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                            {
                                //赤伝
                                stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                            }
                            else
                            {
                                //通常伝票
                                stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                            }
                            //--- ADD 2009/01/15 M.Kubota ---<<<

                            stockAcPayHistWork.InputSectionCd = stockSlipWork.StockSectionCd;   // 入力拠点コード ← 仕入拠点コード

                            // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                            //object objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd];       //DEL 2009/01/13 M.Kubota
                            object objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd.Trim()];  //ADD 2009/01/13 M.Kubota

                            //入力拠点ガイド名称
                            if (objSecNm is string)
                            {
                                stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                            }
                            else
                            {
                                stockAcPayHistWork.InputSectionGuidNm = "";
                            }

                            stockAcPayHistWork.InputAgenCd = stockSlipWork.StockAgentCode;         // 入力担当者コード ← 仕入担当者コード
                            stockAcPayHistWork.InputAgenNm = stockSlipWork.StockAgentName;         // 入力担当者名称 ← 仕入担当者名称
                            stockAcPayHistWork.CustSlipNo = stockDetailWork.OrderNumber;           // 相手先伝票番号
                            stockAcPayHistWork.SlipDtlNum = stockDetailWork.StockSlipDtlNum;       // 仕入明細通番
                            stockAcPayHistWork.AcPayNote = stockDetailWork.StockDtiSlipNote1;      // 仕入伝票明細備考1
                            stockAcPayHistWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;        // 商品メーカーコード
                            stockAcPayHistWork.MakerName = stockDetailWork.MakerName;              // メーカー名称
                            stockAcPayHistWork.GoodsNo = stockDetailWork.GoodsNo;                  // 商品番号
                            stockAcPayHistWork.GoodsName = stockDetailWork.GoodsName;              // 商品名称
                            stockAcPayHistWork.BLGoodsCode = stockDetailWork.BLGoodsCode;          // BL商品コード
                            stockAcPayHistWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                            //stockAcPayHistWork.SectionCode = stockSlipWork.StockSectionCd;       // 拠点コード ← 仕入拠点コード  //DEL 2009/01/13 M.Kubota
                            stockAcPayHistWork.SectionCode = stockSlipWork.SectionCode;            // 拠点コード                    //ADD 2009/01/13 M.Kubota

                            // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                            //objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd];    //DEL 2009/01/13 M.Kubota
                            objSecNm = this._secInfoSeTtable[stockSlipWork.SectionCode.Trim()];  //ADD 2009/01/13 M.Kubota

                            // 拠点ガイド名称
                            if (objSecNm is string)
                            {
                                stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                            }
                            else
                            {
                                stockAcPayHistWork.SectionGuideNm = "";
                            }

                            stockAcPayHistWork.WarehouseCode = stockDetailWork.WarehouseCode;          // 倉庫コード
                            stockAcPayHistWork.WarehouseName = stockDetailWork.WarehouseName;          // 倉庫名称
                            stockAcPayHistWork.ShelfNo = stockDetailWork.WarehouseShelfNo;             // 倉庫棚番
                            stockAcPayHistWork.OpenPriceDiv = stockDetailWork.OpenPriceDiv;            // オープン価格区分
                            stockAcPayHistWork.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl;  // 定価(税抜・浮動)
                            stockAcPayHistWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;    // 仕入単価(税抜・浮動)
                            stockAcPayHistWork.StockPrice = stockDetailWork.StockPriceTaxExc;          // 仕入金額(税抜)

                            stockAcPayHistWork.SupplierCd = stockSlipWork.SupplierCd;                  // 仕入先コード  //ADD 2009/01/13 M.Kubota
                            stockAcPayHistWork.SupplierSnm = stockSlipWork.SupplierSnm;                // 仕入先略称    //ADD 2009/01/13 M.Kubota

                            int indexCount = 0;

                            //在庫受払履歴パラメータListにデータがある時
                            if (stockAcPayHistWorkUpdateList.Count > 0)
                            {
                                stockAcPayHistWorkUpdateList.Sort(stockAcPayHistWorkComparer);

                                indexCount = stockAcPayHistWorkUpdateList.BinarySearch(0, stockAcPayHistWorkUpdateList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                                if (indexCount >= 0 && indexCount <= stockDetailWorkList.Count)
                                {
                                    stockAcPayHistWork = stockAcPayHistWorkUpdateList[indexCount] as StockAcPayHistWork;

                                    if (stockAcPayHistWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd && stockAcPayHistWork.GoodsNo == stockDetailWork.GoodsNo)
                                    {
                                        //stockAcPayHistWork.ArrivalCnt += stockDetailWork.StockCount; //入荷数　←　仕入数
                                        stockAcPayHistWork.ArrivalCnt += stockCountDifference; //入荷数　←　仕入数
                                    }
                                }
                                else
                                {
                                    //stockAcPayHistWork.ArrivalCnt = stockDetailWork.StockCount; //入荷数　←　仕入数
                                    stockAcPayHistWork.ArrivalCnt = stockCountDifference; //入荷数　←　仕入数
                                    stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                                }
                            }
                            //初期データ挿入時
                            else
                            {
                                //stockAcPayHistWork.ArrivalCnt = stockDetailWork.StockCount; //入荷数　←　仕入数
                                stockAcPayHistWork.ArrivalCnt = stockCountDifference; //入荷数　←　仕入数
                                stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                            }
                            # endif
                            # endregion

                            //DEL 2009/01/30 >>>>>>>>>>>>>>>>>
                            //// 登録前 仕入データを元に受払履歴データを作成
                            //this.StockSlipToStockAcPayHist(stockSlipWork, stockDetailWork, orgStockDetailWork, 0, ref stockAcPayHistWork);

                            //// 登録済 仕入データを元に受払履歴データを作成
                            //this.StockSlipToStockAcPayHist(oldStockSlipWork, oldStockDetailWork, orgStockDetailWork, 0, ref counterStockAcPayHistWork);
                            //DEL 2009/01/30 <<<<<<<<<<<<<<<<<

                            //ADD 2009/01/30 >>>>>>>>>>>>>>>>>
                            // 登録前 仕入データを元に受払履歴データを作成
                            this.StockSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork);

                            // 登録済 仕入データを元に受払履歴データを作成
                            this.StockSlipToStockAcPayHist(oldStockSlipWork, oldStockDetailWork, refCntDifDat.AddUpOrgDetail, 0, ref counterStockAcPayHistWork);
                            //ADD 2009/01/30 <<<<<<<<<<<<<<<<<

                            if (stockAcPayHistWork.IoGoodsDay != DateTime.MinValue)
                            {
                                counterStockAcPayHistWork.IoGoodsDay = oldStockSlipWork.ArrivalGoodsDay;  // 入出荷日
                            }

                            // 変更前と変更後を比較する
                            int cmpRet = stockAcPayHistWorkComparer.Compare(stockAcPayHistWork, counterStockAcPayHistWork);

                            if (cmpRet != 0)
                            {
                                // 相殺データを追加
                                counterStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.Cancel;  // 取消

                                counterStockAcPayHistWork.ArrivalCnt = oldStockDetailWork.StockCount * -1;        // 入荷数   (符号反転)
                                counterStockAcPayHistWork.StockPrice = oldStockDetailWork.StockPriceTaxExc * -1;  // 仕入金額 (符号反転)
                            }
                            else
                            {
                                counterStockAcPayHistWork = null;  // 相殺データは不要なので破棄する

                                if (stockAcPayHistWorkComparer.DifferenceUpdate)
                                {
                                    // 差分データ(入荷数・仕入金額の差分)を追加

                                    // 仕入金額の差分算出
                                    long stcPriceDif = stockDetailWork.StockPriceTaxExc - oldStockDetailWork.StockPriceTaxExc;

                                    stockAcPayHistWork.ArrivalCnt = stockCountDifference;                         // 入荷数   (差分)
                                    stockAcPayHistWork.StockPrice = stcPriceDif;                                  // 仕入金額 (差分)
                                }
                                else
                                {
                                    stockAcPayHistWork = null;         // 何も変わって無いので破棄する
                                }
                            }

                            // ①相殺データから先に格納(登録)する
                            if (counterStockAcPayHistWork != null)
                            {
                                stockAcPayHistWorkUpdateList.Add(counterStockAcPayHistWork);
                            }

                            // ②追加(変更)分のデータを格納(登録)する
                            if (stockAcPayHistWork != null)
                            {
                                stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                            }
                        }
                        //--------------------------------------------------------------------------------------------------
                        //●在庫受払履歴データ更新パラメータ格納    End
                        //--------------------------------------------------------------------------------------------------
                        #endregion

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.03.07
                        // このタイミングでは遅いので↑に移動
                        //flg = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.03.07

                        break;
                    }
                }

                if (flg == false)
                {
                    // 旧・明細群から見て、新・明細群に該当するデータが存在しない場合は、その旧明細は削除された物をみなす
                    
                    //stockCount = 0;
                    //削除データを作成する
                    //差分抽出
                    //stockCount = -oldStockDetailWork.StockCount; //仕入数
                    #region[在庫マスタ削除パラメータ格納]

                    oldStockWork = new StockWork();

                    # region [--- DEL 2008/06/03 M.Kubota ---]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.03.07
                    ////在庫管理有無区分・仕入数チェック
                    //if (oldStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage || stockDetailWork.StockCount == 0) continue;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.03.07

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                    //在庫管理有無区分・仕入数チェック
                    //--- DEL 2008/06/03 M.Kubota --->>>
                    //if ( oldStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                    //    (oldStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && oldStockDetailWork.StockOrderDivCd == 0) ||
                    //    oldStockDetailWork.StockCount == 0 ) continue;
                    //--- DEL 2008/06/03 M.Kubota ---<<<
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                    # endregion

                    if (!oldStockDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/03 M.Kubota

                    //仕入ヘッダ　→　在庫マスタ
                    oldStockWork.EnterpriseCode = stockSlipWork.EnterpriseCode;                   //企業コード
                    oldStockWork.SectionCode = stockSlipWork.StockSectionCd;                      //拠点コード ← 仕入拠点コード
                    oldStockWork.LastStockDate = stockSlipWork.StockDate;                         //最終仕入年月日　←　仕入日

                    //仕入明細　→　在庫マスタ
                    //--- ADD 2007/09/11 M.Kubota --->>>
                    oldStockWork.GoodsMakerCd = oldStockDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                    oldStockWork.GoodsNo = oldStockDetailWork.GoodsNo;                            // 商品番号
                    // 2009/03/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 在庫単価は棚卸評価単価として使用するため、仕入単価はセットしない
                    //oldStockWork.StockUnitPriceFl = oldStockDetailWork.StockUnitPriceFl;          // 仕入単価
                    // 2009/03/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    oldStockWork.WarehouseCode = oldStockDetailWork.WarehouseCode;                // 倉庫コード
                    oldStockWork.WarehouseName = oldStockDetailWork.WarehouseName;                // 倉庫名称
                    oldStockWork.WarehouseShelfNo = oldStockDetailWork.WarehouseShelfNo;          // 倉庫棚番
                    # region [--- DEL 2008/06/03 M.Kubota ---]
                    //oldStockWork.MakerName = oldStockDetailWork.MakerName;                      // メーカー名称  //DEL 2008/06/03 M.Kubota
                    //oldStockWork.GoodsName = oldStockDetailWork.GoodsName;                      // 商品名称      //DEL 2008/06/03 M.Kubota
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                    //oldStockWork.GoodsShortName = oldStockDetailWork.GoodsShortName;            // 商品名略称    //DEL 2008/06/03 M.Kubota
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                    //oldStockWork.BLGoodsCode = oldStockDetailWork.BLGoodsCode;                  // BL商品コード              //DEL 2008/06/03 M.Kubota
                    //oldStockWork.BLGoodsFullName = oldStockDetailWork.BLGoodsFullName;          // BL商品コード名称(全角)    //DEL 2008/06/03 M.Kubota
                    //oldStockWork.EnterpriseGanreCode = oldStockDetailWork.EnterpriseGanreCode;  // 自社分類コード            //DEL 2008/06/03 M.Kubota
                    //oldStockWork.EnterpriseGanreName = oldStockDetailWork.EnterpriseGanreName;  // 自社分類コード名称(全角)  //DEL 2008/06/03 M.Kubota
                    # endregion
                    //--- ADD 2007/09/11 M.Kubota ---<<<

                    # region [--- DEL 2007/09/11 M.Kubota ---]
                    //oldStockWork.MakerName = oldStockDetailWork.MakerName;            //メーカー名称
                    //oldStockWork.GoodsName = oldStockDetailWork.GoodsName;            //商品名称
                    //oldStockWork.StockUnitPrice = oldStockDetailWork.StockUnitPrice;  //仕入単価
                    //oldStockWork.CarrierCode = oldStockDetailWork.CarrierCode;        //キャリアコード
                    //oldStockWork.CarrierName = oldStockDetailWork.CarrierName;        //キャリア名称
                    //oldStockWork.SystematicColorCd = oldStockDetailWork.SystematicColorCd;    //系統色コード
                    //oldStockWork.SystematicColorNm = oldStockDetailWork.SystematicColorNm;    //系統色名称
                    //oldStockWork.LargeGoodsGanreCode = oldStockDetailWork.LargeGoodsGanreCode;    //商品大分類コード
                    //oldStockWork.MediumGoodsGanreCode = oldStockDetailWork.MediumGoodsGanreCode;  //商品中分類コード
                    //oldStockWork.PrdNumMngDiv = oldStockDetailWork.PrdNumMngDiv;        //製番管理区分
                    //oldStockWork.CellphoneModelCode = oldStockDetailWork.CellphoneModelCode;    //機種コード
                    //oldStockWork.CellphoneModelName = oldStockDetailWork.CellphoneModelName;    //機種名称
                    //oldStockWork.MakerCode = oldStockDetailWork.MakerCode;            //メーカーコード
                    //oldStockWork.GoodsCode = oldStockDetailWork.GoodsCode;            //商品コード
                    # endregion [--- DEL 2007/09/11 M.Kubota ---]
                    # region [--- DEL 2008/02/29 M.Suzuki ---]
                    ////仕入形式・受託計上仕入区分にて分岐
                    //if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //    stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    oldStockWork.SupplierStock = -oldStockDetailWork.StockCount; //仕入在庫数　←　仕入数
                    //}
                    //else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                    //         stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //    //oldStockWork.TrustCount = -oldStockDetailWork.StockCount; //受託数　←　仕入数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                    //    oldStockWork.ArrivalCnt = -oldStockDetailWork.StockCount; //受託数　←　仕入数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    //}
                    //else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //         (stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                    //          stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                    //{
                    //    oldStockWork.SupplierStock = -oldStockDetailWork.StockCount; //仕入在庫数
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //    //oldStockWork.TrustCount = oldStockDetailWork.StockCount; //受託数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                    //    oldStockWork.ArrivalCnt = oldStockDetailWork.StockCount; //入荷数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    //}
                    # endregion

                    // DEL 2009/01/30 >>>>>>>>>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.29
                    //// 数量差分適用
                    //ReflectStockCountDefference(ref oldStockWork, stockSlipWork, oldStockDetailWork, null, -1 * oldStockDetailWork.StockCount);
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.29
                    // DEL 2009/01/30 <<<<<<<<<<<<

                    //--- ADD 2009/01/30 --->>>
                    refCntDifDat = new ReflectCntDifData(stockSlipWork, oldStockDetailWork, null, null, null, oldStockDetailWork.StockCount * -1, 0, 0);

                    // 明細追加情報を検索し、計上残区分を取得する
                    refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上元明細データを検索する
                    refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgStockDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上残区分を設定する
                    refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                    this.ReflectStockCountDefference(ref oldStockWork, refCntDifDat);
                    //--- ADD 2009/01/30 ---<<<

                    #endregion

                    //削除データ格納
                    stockWorkUpdateList.Add(oldStockWork);

                    #region[在庫受払履歴データ更新パラメータ格納]
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    Start
                    //--------------------------------------------------------------------------------------------------

                    // 0:仕入　1:入荷 のみ在庫受払履歴データを作成・更新する
                    if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase ||
                        stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                    {
                        // DEL 2009/01/30 >>>>>>>>>>>>>>>>>>>>>>> 
                        //int mode = 1;  
                        //orgStockDetailWork = detailsSelector.Find(oldStockDetailWork);
                        // DEL 2009/01/30 <<<<<<<<<<<<<<<<<<<<<<<

                        stockAcPayHistWork = new StockAcPayHistWork();

                        //--- ADD 2009/01/28 M.Kubota --->>>
                        //this.StockSlipToStockAcPayHist(oldStockSlipWork, oldStockDetailWork, orgStockDetailWork, 1, ref stockAcPayHistWork); // DEL 2009/01/30
                        this.StockSlipToStockAcPayHist(oldStockSlipWork, oldStockDetailWork, null, 1, ref stockAcPayHistWork); // ADD 2009/01/30
                        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //--- ADD 2009/01/28 M.Kubota ---<<<

                        # region [--- DEL 2009/01/28 M.Kubota --- 修正範囲が大きいので全削除]
# if false
                        // 在庫受払履歴データ ← 仕入ヘッダ
                        stockAcPayHistWork.EnterpriseCode = stockSlipWork.EnterpriseCode;   //企業コード

                        //stockAcPayHistWork.ValidDivCd = mode;  //DEL 2008/06/03 M.Kubota

                        // 仕入形式によって設定値が異なる項目
                        switch (stockSlipWork.SupplierFormal)
                        {
                            case (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase:
                                {
                                    // 仕入
                                    if (oldStockDetailWork.SupplierFormalSrc == 1 ||                                                                            // 入荷引当した仕入
                                        (oldStockDetailWork.StockSlipCdDtl == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1) ||  // 入荷引当した仕入の返品
                                        (stockSlipWork.DebitNoteDiv == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1))        // 入荷引当した仕入の赤伝
                                    {
                                        stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                                 // 入出荷日 ← 未設定(最小値)
                                    }
                                    else
                                    {
                                        stockAcPayHistWork.IoGoodsDay = stockSlipWork.ArrivalGoodsDay;                     // 入出荷日 ← 入荷日
                                    }

                                    stockAcPayHistWork.AddUpADate = stockSlipWork.StockDate;                               // 計上日付 ← 仕入日                                
                                    stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Stock;  // 受払元伝票区分 10:仕入
                                    break;
                                }
                            case (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust:
                                {
                                    // 入荷
                                    stockAcPayHistWork.IoGoodsDay = stockSlipWork.ArrivalGoodsDay;                         // 入出荷日 ← 入荷日
                                    stockAcPayHistWork.AddUpADate = DateTime.MinValue;                                     // 計上日付 ← 未設定(最小値)
                                    stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Trust;  // 受払元伝票区分 11:入荷
                                    break;
                                }
                        }

                        stockAcPayHistWork.AcPaySlipNum = stockSlipWork.SupplierSlipNo.ToString();  // 受払元伝票番号
                        stockAcPayHistWork.AcPaySlipRowNo = oldStockDetailWork.StockRowNo;          // 受払元行番号
                        stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;                  // 受払履歴作成日時

                        //受払元取引区分
                        # region [--- DEL 2009/01/15 M.Kubota ---]
                        ////仕入伝票更新(受託計上伝票も含む)
                        //if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                        //    stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                        //{
                        //    //通常伝票
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                        //}
                        ////赤伝票更新(受託計上伝票も含む)
                        //else if (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 0)
                        //{
                        //    //赤伝
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                        //}
                        ////返品伝票更新
                        //else if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                        //    stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                        //{
                        //    //返品
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                        //}
                        ////伝票削除
                        //else if (mode == 1)
                        //{
                        //    //削除
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                        //}
                        # endregion
                        //--- ADD 2009/01/15 M.Kubota --->>>
                        if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                        {
                            //返品
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                        }
                        else if (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                        {
                            //赤伝
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                        }
                        else
                        {
                            //通常伝票
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                        }
                        //--- ADD 2009/01/15 M.Kubota ---<<<


                        stockAcPayHistWork.InputSectionCd = stockSlipWork.StockSectionCd;   // 入力拠点コード ← 仕入拠点コード

                        // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        //object objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd];       //DEL 2009/01/13 M.Kubota
                        object objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd.Trim()];  //ADD 2009/01/13 M.Kubota

                        //入力拠点ガイド名称
                        if (objSecNm is string)
                        {
                            stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                        }
                        else
                        {
                            stockAcPayHistWork.InputSectionGuidNm = "";
                        }

                        stockAcPayHistWork.InputAgenCd = stockSlipWork.StockAgentCode;            // 入力担当者コード ← 仕入担当者コード
                        stockAcPayHistWork.InputAgenNm = stockSlipWork.StockAgentName;            // 入力担当者名称 ← 仕入担当者名称
                        stockAcPayHistWork.CustSlipNo = oldStockDetailWork.OrderNumber;           // 相手先伝票番号
                        stockAcPayHistWork.SlipDtlNum = oldStockDetailWork.StockSlipDtlNum;       // 仕入明細通番
                        stockAcPayHistWork.AcPayNote = oldStockDetailWork.StockDtiSlipNote1;      // 仕入伝票明細備考1
                        stockAcPayHistWork.GoodsMakerCd = oldStockDetailWork.GoodsMakerCd;        // 商品メーカーコード
                        stockAcPayHistWork.MakerName = oldStockDetailWork.MakerName;              // メーカー名称
                        stockAcPayHistWork.GoodsNo = oldStockDetailWork.GoodsNo;                  // 商品番号
                        stockAcPayHistWork.GoodsName = oldStockDetailWork.GoodsName;              // 商品名称
                        stockAcPayHistWork.BLGoodsCode = oldStockDetailWork.BLGoodsCode;          // BL商品コード
                        stockAcPayHistWork.BLGoodsFullName = oldStockDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                        //stockAcPayHistWork.SectionCode = stockSlipWork.StockSectionCd;          // 拠点コード ← 仕入拠点コード  //DEL 2009/01/13 M.Kubota
                        stockAcPayHistWork.SectionCode = stockSlipWork.SectionCode;               // 拠点コード                    //ADD 2009/01/13 M.Kubota

                        // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        //objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd];    //DEL 2009/01/13 M.Kubota
                        objSecNm = this._secInfoSeTtable[stockSlipWork.SectionCode.Trim()];  //ADD 2009/01/13 M.Kubota

                        // 拠点ガイド名称
                        if (objSecNm is string)
                        {
                            stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                        }
                        else
                        {
                            stockAcPayHistWork.SectionGuideNm = "";
                        }

                        stockAcPayHistWork.WarehouseCode = oldStockDetailWork.WarehouseCode;          // 倉庫コード
                        stockAcPayHistWork.WarehouseName = oldStockDetailWork.WarehouseName;          // 倉庫名称
                        stockAcPayHistWork.ShelfNo = oldStockDetailWork.WarehouseShelfNo;             // 倉庫棚番
                        stockAcPayHistWork.OpenPriceDiv = oldStockDetailWork.OpenPriceDiv;            // オープン価格区分
                        stockAcPayHistWork.ListPriceTaxExcFl = oldStockDetailWork.ListPriceTaxExcFl;  // 定価(税抜・浮動)
                        stockAcPayHistWork.StockUnitPriceFl = oldStockDetailWork.StockUnitPriceFl;    // 仕入単価(税抜・浮動)
                        stockAcPayHistWork.StockPrice = oldStockDetailWork.StockPriceTaxExc;          // 仕入金額(税抜)

                        stockAcPayHistWork.SupplierCd = stockSlipWork.SupplierCd;                     // 仕入先コード  //ADD 2009/01/13 M.Kubota
                        stockAcPayHistWork.SupplierSnm = stockSlipWork.SupplierSnm;                   // 仕入先略称    //ADD 2009/01/13 M.Kubota

                        int indexCount = 0;

                        //在庫受払履歴パラメータListにデータがある時
                        if (stockAcPayHistWorkUpdateList.Count > 0)
                        {
                            stockAcPayHistWorkUpdateList.Sort(stockAcPayHistWorkComparer);

                            indexCount = stockAcPayHistWorkUpdateList.BinarySearch(0, stockAcPayHistWorkUpdateList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                            if (indexCount >= 0 && indexCount <= oldStockDetailWorkList.Count)
                            {
                                stockAcPayHistWork = stockAcPayHistWorkUpdateList[indexCount] as StockAcPayHistWork;

                                if (stockAcPayHistWork.GoodsMakerCd == oldStockDetailWork.GoodsMakerCd && stockAcPayHistWork.GoodsNo == oldStockDetailWork.GoodsNo)
                                {
                                    stockAcPayHistWork.ArrivalCnt += oldStockDetailWork.StockCount * -1; //入荷数　←　仕入数
                                }
                            }
                            else
                            {
                                stockAcPayHistWork.ArrivalCnt = oldStockDetailWork.StockCount * -1; //入荷数　←　仕入数
                                stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                            }
                        }
                        //初期データ挿入時
                        else
                        {
                            stockAcPayHistWork.ArrivalCnt = oldStockDetailWork.StockCount * -1; //入荷数　←　仕入数
                            stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        }
# endif
                        # endregion
                    }
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    End
                    //--------------------------------------------------------------------------------------------------
                    #endregion
                }
            }



            # region [●新規追加データのチェック]
            //●新規追加データのチェック
            //新明細リストをベースに読み込み
            for (int i = 0; i < stockDetailWorkList.Count; i++)
            {
                stockDetailWork = stockDetailWorkList[i] as StockDetailWork;

                flg = false;

                //新明細リストにあって、旧明細リストにない場合は追加明細と判断する
                for (int x = 0; x < oldStockDetailWorkList.Count; x++)
                {
                    oldStockDetailWork = oldStockDetailWorkList[x] as StockDetailWork;

                    # region [--- DEL 2009/01/28 M.Kubota ---]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //if (stockDetailWork.StockRowNo == oldStockDetailWork.StockRowNo && stockDetailWork.GoodsMakerCd == oldStockDetailWork.GoodsMakerCd &&
                    //    stockDetailWork.GoodsNo == oldStockDetailWork.GoodsNo)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                    // 行№.拠点.倉庫.ﾒｰｶｰ.商品番号が一致するなら変更とみなす
                    //if (oldStockDetailWork.StockRowNo == stockDetailWork.StockRowNo &&
                    //     oldStockDetailWork.SectionCode.TrimEnd() == stockDetailWork.SectionCode.TrimEnd() &&
                    //     oldStockDetailWork.WarehouseCode.TrimEnd() == stockDetailWork.WarehouseCode.TrimEnd() &&
                    //     oldStockDetailWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd &&
                    //     oldStockDetailWork.GoodsNo.TrimEnd() == stockDetailWork.GoodsNo.TrimEnd() &&
                    //     oldStockDetailWork.StockSlipDtlNum == stockDetailWork.StockSlipDtlNum)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    # endregion

                    //--- ADD 2009/01/28 M.Kubota --->>>
                    // 倉庫・メーカー・品番・明細通番が一致する場合は変更明細とみなす
                    if (oldStockDetailWork.WarehouseCode.TrimEnd() == stockDetailWork.WarehouseCode.TrimEnd() &&
                        oldStockDetailWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd &&
                        oldStockDetailWork.GoodsNo.TrimEnd() == stockDetailWork.GoodsNo.TrimEnd() &&
                        oldStockDetailWork.StockSlipDtlNum == stockDetailWork.StockSlipDtlNum)
                    //--- ADD 2009/01/28 M.Kubota ---<<<
                    {
                        flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    //新規追加データをそのまま追加
                    #region[在庫マスタ更新パラメータ格納]

                    stockWork = new StockWork();

                    # region [--- DEL 2008/06/03 M.Kubota ---]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.03.07
                    ////在庫管理有無区分・仕入数チェック
                    //if (stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage || stockDetailWork.StockCount == 0) continue;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.03.07
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                    //在庫管理有無区分・仕入数チェック
                    //--- DEL 2008/06/03 M.Kubota --->>>
                    //if ( stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                    //    (stockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && stockDetailWork.StockOrderDivCd == 0) ||
                    //    stockDetailWork.StockCount == 0 ) continue;
                    //--- DEL 2008/06/03 M.Kubota ---<<<
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                    # endregion
                    if (!stockDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/03 M.Kubota

                    //仕入ヘッダ　→　在庫マスタ
                    stockWork.EnterpriseCode = stockSlipWork.EnterpriseCode;                //企業コード
                    stockWork.SectionCode = stockSlipWork.StockSectionCd;                   //拠点コード ← 仕入拠点コード
                    stockWork.LastStockDate = stockSlipWork.StockDate;                      //最終仕入年月日　←　仕入日

                    //仕入明細　→　在庫マスタ
                    //--- ADD 2007/09/11 M.Kubota --->>>
                    stockWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                    stockWork.GoodsNo = stockDetailWork.GoodsNo;                            // 商品番号

                    // 2009/03/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 在庫単価は棚卸評価単価として使用するため、仕入単価はセットしない
                    //stockWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;          // 仕入単価                    
                    // 2009/03/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    stockWork.WarehouseCode = stockDetailWork.WarehouseCode;                // 倉庫コード
                    stockWork.WarehouseName = stockDetailWork.WarehouseName;                // 倉庫名称
                    stockWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;          // 倉庫棚番

                    # region [--- DEL 2008/06/03 M.Kubota ---]
                    //stockWork.MakerName = stockDetailWork.MakerName;                        // メーカー名称  //DEL 2008/06/03 M.Kubota
                    //stockWork.GoodsName = stockDetailWork.GoodsName;                        // 商品名称  //DEL 2008/06/03 M.Kubota
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                    //stockWork.GoodsShortName = stockDetailWork.GoodsShortName;            // 商品名略称  //DEL 2008/06/03 M.Kubota
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                    //stockWork.BLGoodsCode = stockDetailWork.BLGoodsCode;                    // BL商品コード  //DEL 2008/06/03 M.Kubota
                    //stockWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)  //DEL 2008/06/03 M.Kubota
                    //stockWork.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode;    // 自社分類コード  //DEL 2008/06/03 M.Kubota
                    //stockWork.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)  //DEL 2008/06/03 M.Kubota
                    # endregion
                    //--- ADD 2007/09/11 M.Kubota ---<<<

                    # region [--- DEL 2007/09/11 M.Kubota ---]
                    //stockWork.MakerName = stockDetailWork.MakerName;            //メーカー名称
                    //stockWork.GoodsName = stockDetailWork.GoodsName;            //商品名称
                    //stockWork.StockUnitPrice = stockDetailWork.StockUnitPrice;  //仕入単価
                    //stockWork.CarrierCode = stockDetailWork.CarrierCode;        //キャリアコード
                    //stockWork.CarrierName = stockDetailWork.CarrierName;        //キャリア名称
                    //stockWork.SystematicColorCd = stockDetailWork.SystematicColorCd;    //系統色コード
                    //stockWork.SystematicColorNm = stockDetailWork.SystematicColorNm;    //系統色名称
                    //stockWork.LargeGoodsGanreCode = stockDetailWork.LargeGoodsGanreCode;    //商品大分類コード
                    //stockWork.MediumGoodsGanreCode = stockDetailWork.MediumGoodsGanreCode;  //商品中分類コード
                    //stockWork.PrdNumMngDiv = stockDetailWork.PrdNumMngDiv;        //製番管理区分
                    //stockWork.CellphoneModelCode = stockDetailWork.CellphoneModelCode;    //機種コード
                    //stockWork.CellphoneModelName = stockDetailWork.CellphoneModelName;    //機種名称
                    //stockWork.MakerCode = stockDetailWork.MakerCode;            //メーカーコード
                    //stockWork.GoodsCode = stockDetailWork.GoodsCode;            //商品コード
                    # endregion
                    # region [--- DEL 2008/02/29 M.Suzuki ---]
                    ////仕入形式・受託計上仕入区分にて分岐
                    //if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //    stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    stockWork.SupplierStock = stockDetailWork.StockCount; //仕入在庫数　←　仕入数
                    //}
                    //else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                    //         stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //    //stockWork.TrustCount = stockDetailWork.StockCount; //受託数　←　仕入数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                    //    stockWork.ArrivalCnt = stockDetailWork.StockCount; //入荷数　←　仕入数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    //}
                    //else if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //         (stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                    //         stockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                    //{
                    //    stockWork.SupplierStock = stockDetailWork.StockCount; //仕入在庫数
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //    //stockWork.TrustCount = -(stockDetailWork.StockCount); //受託数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //    stockWork.ArrivalCnt = -(stockDetailWork.StockCount); //入荷数
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    //}
                    # endregion

                    // DEL 2009/01/30 >>>>>>>>>>>>>>>>>>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.29
                    //// 数量差分適用
                    //ReflectStockCountDefference(ref stockWork, stockSlipWork, stockDetailWork, null, stockDetailWork.StockCount);
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.29
                    // DEL 2009/01/30 <<<<<<<<<<<<<<<<<<<<<

                    //--- ADD 2009/01/30 --->>>
                    refCntDifDat = new ReflectCntDifData(stockSlipWork, stockDetailWork, null, null, null, stockDetailWork.StockCount, 0, 0);

                    // 明細追加情報を検索し、計上残区分を取得する
                    refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上元明細データを検索する
                    refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgStockDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上残区分を設定する
                    refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                    this.ReflectStockCountDefference(ref stockWork, refCntDifDat);
                    //--- ADD 2009/01/30 ---<<<

                    #endregion

                    stockWorkUpdateList.Add(stockWork);

                    #region[在庫受払履歴データ更新パラメータ格納]
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    Start
                    //--------------------------------------------------------------------------------------------------

                    // 0:仕入　1:入荷 のみ在庫受払履歴データを作成・更新する
                    if (stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase ||
                        stockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                    {
                        // DEL 2009/01/30 >>>>>>>>>>>>>>>>>>>>>>>>>
                        //int mode = 0;
                        //orgStockDetailWork = detailsSelector.Find(stockDetailWork);
                        // DEL 2009/01/30 <<<<<<<<<<<<<<<<<<<<<<<<<

                        stockAcPayHistWork = new StockAcPayHistWork();

                        //--- ADD 2009/01/28 M.Kubota --->>>
                        //this.StockSlipToStockAcPayHist(stockSlipWork, stockDetailWork, orgStockDetailWork, 0, ref stockAcPayHistWork); // DEL 2009/01/30
                        this.StockSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork);

                        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //--- ADD 2009/01/28 M.Kubota ---<<<

                        //入荷計上で「残さない」の設定が出来るようになった場合はここに追加↓


                        # region [--- DEL 2009/01/28 M.Kubota --- 修正範囲が大きいので全削除]
# if false                        
                        // 在庫受払履歴データ ← 仕入ヘッダ
                        stockAcPayHistWork.EnterpriseCode = stockSlipWork.EnterpriseCode;   //企業コード

                        //stockAcPayHistWork.ValidDivCd = mode;  //DEL 2008/06/03 M.Kubota

                        // 仕入形式によって設定値が異なる項目
                        switch (stockSlipWork.SupplierFormal)
                        {
                            case (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase:
                                {
                                    // 仕入
                                    if (stockDetailWork.SupplierFormalSrc == 1 ||                                                                            // 入荷引当した仕入
                                        (stockDetailWork.StockSlipCdDtl == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1) ||  // 入荷引当した仕入の返品
                                        (stockSlipWork.DebitNoteDiv == 1 && orgStockDetailWork != null && orgStockDetailWork.SupplierFormalSrc == 1))        // 入荷引当した仕入の赤伝
                                    {
                                        stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                                 // 入出荷日 ← 未設定(最小値)
                                    }
                                    else
                                    {
                                        stockAcPayHistWork.IoGoodsDay = stockSlipWork.ArrivalGoodsDay;                     // 入出荷日 ← 入荷日
                                    }

                                    stockAcPayHistWork.AddUpADate = stockSlipWork.StockDate;                               // 計上日付 ← 仕入日                                
                                    stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Stock;  // 受払元伝票区分 10:仕入
                                    break;
                                }
                            case (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust:
                                {
                                    // 入荷
                                    stockAcPayHistWork.IoGoodsDay = stockSlipWork.ArrivalGoodsDay;                         // 入出荷日 ← 入荷日
                                    stockAcPayHistWork.AddUpADate = DateTime.MinValue;                                     // 計上日付 ← 未設定(最小値)
                                    stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Trust;  // 受払元伝票区分 11:入荷
                                    break;
                                }
                        }

                        stockAcPayHistWork.AcPaySlipNum = stockSlipWork.SupplierSlipNo.ToString();  // 受払元伝票番号
                        stockAcPayHistWork.AcPaySlipRowNo = stockDetailWork.StockRowNo;             // 受払元行番号
                        stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;                  // 受払履歴作成日時

                        //受払元取引区分
                        # region [--- DEL 2009/01/15 M.Kubota ---]
                        ////仕入伝票更新(受託計上伝票も含む)
                        //if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                        //    stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                        //{
                        //    //通常伝票
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                        //}
                        ////赤伝票更新(受託計上伝票も含む)
                        //else if (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 0)
                        //{
                        //    //赤伝
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                        //}
                        ////返品伝票更新
                        //else if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                        //    stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                        //{
                        //    //返品
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                        //}
                        ////伝票削除
                        //else if (mode == 1)
                        //{
                        //    //削除
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                        //}
                        # endregion
                        //--- ADD 2009/01/15 M.Kubota --->>>
                        if (stockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                        {
                            //返品
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                        }
                        else if (stockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                        {
                            //赤伝
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                        }
                        else
                        {
                            //通常伝票
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                        }
                        //--- ADD 2009/01/15 M.Kubota ---<<<

                        stockAcPayHistWork.InputSectionCd = stockSlipWork.StockSectionCd;   // 入力拠点コード ← 仕入拠点コード

                        // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        //object objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd];       //DEL 2009/01/13 M.Kubota
                        object objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd.Trim()];  //ADD 2009/01/13 M.Kubota

                        //入力拠点ガイド名称
                        if (objSecNm is string)
                        {
                            stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                        }
                        else
                        {
                            stockAcPayHistWork.InputSectionGuidNm = "";
                        }

                        stockAcPayHistWork.InputAgenCd = stockSlipWork.StockAgentCode;         // 入力担当者コード ← 仕入担当者コード
                        stockAcPayHistWork.InputAgenNm = stockSlipWork.StockAgentName;         // 入力担当者名称 ← 仕入担当者名称
                        stockAcPayHistWork.CustSlipNo = stockDetailWork.OrderNumber;           // 相手先伝票番号
                        stockAcPayHistWork.SlipDtlNum = stockDetailWork.StockSlipDtlNum;       // 仕入明細通番
                        stockAcPayHistWork.AcPayNote = stockDetailWork.StockDtiSlipNote1;      // 仕入伝票明細備考1
                        stockAcPayHistWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;        // 商品メーカーコード
                        stockAcPayHistWork.MakerName = stockDetailWork.MakerName;              // メーカー名称
                        stockAcPayHistWork.GoodsNo = stockDetailWork.GoodsNo;                  // 商品番号
                        stockAcPayHistWork.GoodsName = stockDetailWork.GoodsName;              // 商品名称
                        stockAcPayHistWork.BLGoodsCode = stockDetailWork.BLGoodsCode;          // BL商品コード
                        stockAcPayHistWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                        //stockAcPayHistWork.SectionCode = stockSlipWork.StockSectionCd;       // 拠点コード ← 仕入拠点コード  //DEL 2009/01/13 M.Kubota
                        stockAcPayHistWork.SectionCode = stockSlipWork.SectionCode;            // 拠点コード                    //ADD 2009/01/13 M.Kubota

                        // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        //objSecNm = this._secInfoSeTtable[stockSlipWork.StockSectionCd];    //DEL 2009/01/13 M.Kubota
                        objSecNm = this._secInfoSeTtable[stockSlipWork.SectionCode.Trim()];  //ADD 2009/01/13 M.Kubota

                        // 拠点ガイド名称
                        if (objSecNm is string)
                        {
                            stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                        }
                        else
                        {
                            stockAcPayHistWork.SectionGuideNm = "";
                        }

                        stockAcPayHistWork.WarehouseCode = stockDetailWork.WarehouseCode;          // 倉庫コード
                        stockAcPayHistWork.WarehouseName = stockDetailWork.WarehouseName;          // 倉庫名称
                        stockAcPayHistWork.ShelfNo = stockDetailWork.WarehouseShelfNo;             // 倉庫棚番
                        stockAcPayHistWork.OpenPriceDiv = stockDetailWork.OpenPriceDiv;            // オープン価格区分
                        stockAcPayHistWork.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl;  // 定価(税抜・浮動)
                        stockAcPayHistWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;    // 仕入単価(税抜・浮動)
                        stockAcPayHistWork.StockPrice = stockDetailWork.StockPriceTaxExc;          // 仕入金額(税抜)

                        stockAcPayHistWork.SupplierCd = stockSlipWork.SupplierCd;                  // 仕入先コード  //ADD 2009/01/13 M.Kubota
                        stockAcPayHistWork.SupplierSnm = stockSlipWork.SupplierSnm;                // 仕入先略称    //ADD 2009/01/13 M.Kubota

                        int indexCount = 0;

                        //在庫受払履歴パラメータListにデータがある時
                        if (stockAcPayHistWorkUpdateList.Count > 0)
                        {
                            stockAcPayHistWorkUpdateList.Sort(stockAcPayHistWorkComparer);

                            indexCount = stockAcPayHistWorkUpdateList.BinarySearch(0, stockAcPayHistWorkUpdateList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                            if (indexCount >= 0 && indexCount <= stockDetailWorkList.Count)
                            {
                                stockAcPayHistWork = stockAcPayHistWorkUpdateList[indexCount] as StockAcPayHistWork;

                                if (stockAcPayHistWork.GoodsMakerCd == stockDetailWork.GoodsMakerCd && stockAcPayHistWork.GoodsNo == stockDetailWork.GoodsNo)
                                {
                                    stockAcPayHistWork.ArrivalCnt += stockDetailWork.StockCount; //入荷数　←　仕入数
                                }
                            }
                            else
                            {
                                stockAcPayHistWork.ArrivalCnt = stockDetailWork.StockCount; //入荷数　←　仕入数
                                stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                            }
                        }
                        //初期データ挿入時
                        else
                        {
                            stockAcPayHistWork.ArrivalCnt = stockDetailWork.StockCount; //入荷数　←　仕入数
                            stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        }
# endif
                        # endregion
                    }
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    End
                    //--------------------------------------------------------------------------------------------------
                    #endregion
                }
            }
            # endregion

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        # region [変更前伝票・作成元伝票　取得]
        /// <summary>
        /// 変更前伝票　仕入データ・仕入明細データ取得処理
        /// </summary>
        /// <param name="oldStockSlipWork"></param>
        /// <param name="oldStockDetailWorkList"></param>
        /// <param name="orgStockSlipWork"></param>
        /// <param name="orgStockDetailWorkList"></param>
        /// <param name="originList"></param>
        /// <param name="currentStockSlipWork"></param>
        /// <remarks>
        /// <br>originListの中から、今回伝票の変更前伝票データと（今回伝票ではなく）作成元伝票データを取得します</br>
        /// </remarks>
        private void FindOldAndOriginStockSlip( out StockSlipWork oldStockSlipWork, out ArrayList oldStockDetailWorkList, out StockSlipWork orgStockSlipWork,  out ArrayList orgStockDetailWorkList, CustomSerializeArrayList originList, StockSlipWork currentStockSlipWork )
        {
            // 出力パラメータ初期化
            oldStockSlipWork = null;
            oldStockDetailWorkList = new ArrayList();
            orgStockSlipWork = null;
            orgStockDetailWorkList = new ArrayList();

            //-------------------------------------------------
            // 伝票　仕入データ　Find
            //-------------------------------------------------
            foreach ( object obj in originList )
            {
                // 仕入データ
                if ( obj is StockSlipWork )
                {
                    // 今回伝票と　仕入伝票区分(10:仕入/20:返品)が同じ　かつ
                    // 　　　　　　赤伝区分(0:黒伝/1:赤伝/2:元黒)が同じ　ものを変更前伝票とみなす
                    if ( (obj as StockSlipWork).SupplierSlipCd == currentStockSlipWork.SupplierSlipCd &&
                         (obj as StockSlipWork).DebitNoteDiv == currentStockSlipWork.DebitNoteDiv )
                    {
                        // 前
                        oldStockSlipWork = (StockSlipWork)obj;
                    }
                    else
                    {
                        // 元
                        orgStockSlipWork = (StockSlipWork)obj;
                    }
                }
            }
            //-------------------------------------------------
            // 伝票　仕入明細データ　Find
            //-------------------------------------------------
            if ( oldStockSlipWork != null )
            {
                foreach ( object obj in originList )
                {
                    // ArrayListで要素があり、最初の要素がStockDetailWork
                    if ( obj is ArrayList && (obj as ArrayList).Count > 0 && (obj as ArrayList)[0] is StockDetailWork )
                    {
                        // 「変更前伝票仕入データの伝票番号と同じ伝票番号を持つ明細のArrayList」を
                        // 「変更前伝票仕入明細データリスト」とみなす
                        if ( ((obj as ArrayList)[0] as StockDetailWork).SupplierSlipNo == oldStockSlipWork.SupplierSlipNo )
                        {
                            // 前
                            oldStockDetailWorkList = (ArrayList)obj;
                        }
                        else if ( ((obj as ArrayList)[0] as StockDetailWork).SupplierSlipNo == orgStockSlipWork.SupplierSlipNo )
                        {
                            // 元
                            orgStockDetailWorkList = (ArrayList)obj;
                        }
                    }
                }
            }
        }

        //--- ADD 2009/01/28 M.Kubota --->>>
        /// <summary>
        /// 仕入データを元に、在庫受払履歴のデータセットを行います
        /// </summary>
        /// <param name="stcSlip">仕入伝票データ</param>
        /// <param name="stcDtl">仕入明細データ</param>
        /// <param name="orgDtl">計上元仕入明細データ</param>
        /// <param name="mode">動作モード(0:加算 1:減算)</param>
        /// <param name="stcAcPayHist">在庫受払履歴データ</param>
        private void StockSlipToStockAcPayHist(StockSlipWork stcSlip, StockDetailWork stcDtl, StockDetailWork orgDtl, int mode, ref StockAcPayHistWork stcAcPayHist)
        {
            stcAcPayHist.EnterpriseCode = stcSlip.EnterpriseCode;            // 企業コード

            # region [仕入形式によって設定値が異なる項目]
            switch (stcSlip.SupplierFormal)
            {
                case (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase:  // 仕入
                    {
                        if (stcDtl.SupplierFormalSrc == 1 ||                                                    // 入荷計上した仕入
                            (stcDtl.StockSlipCdDtl == 1 && orgDtl != null && orgDtl.SupplierFormalSrc == 1) ||  // 入荷計上した仕入の返品
                            (stcSlip.DebitNoteDiv == 1 && orgDtl != null && orgDtl.SupplierFormalSrc == 1))     // 入荷計上した仕入の赤伝
                        {
                            // 入荷計上仕入伝票の場合
                            stcAcPayHist.IoGoodsDay = DateTime.MinValue;        // 入出荷日 ← 未設定(最小値)
                        }
                        else
                        {
                            // 入荷計上されていない仕入伝票の場合
                            stcAcPayHist.IoGoodsDay = stcSlip.ArrivalGoodsDay;  // 入出荷日 ← 入荷日
                        }

                        stcAcPayHist.AddUpADate = stcSlip.StockDate;            // 計上日付 ← 仕入日                                
                        stcAcPayHist.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Stock;  // 受払元伝票区分 10:仕入
                        break;
                    }
                case (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust:    // 入荷
                    {
                        stcAcPayHist.IoGoodsDay = stcSlip.ArrivalGoodsDay;      // 入出荷日 ← 入荷日
                        stcAcPayHist.AddUpADate = DateTime.MinValue;            // 計上日付 ← 未設定(最小値)
                        stcAcPayHist.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Trust;  // 受払元伝票区分 11:入荷
                        break;
                    }
            }
            # endregion

            stcAcPayHist.AcPaySlipNum = stcSlip.SupplierSlipNo.ToString();   // 受払元伝票番号
            stcAcPayHist.AcPaySlipRowNo = 0;                                 // 受払元行番号      ※受払履歴Ｒで設定
            stcAcPayHist.AcPayHistDateTime = 0;                              // 受払履歴作成日時  ※受払履歴Ｒで設定

            # region [受払元取引区分]
            if (mode == 0)
            {
                if (stcSlip.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                {
                    stcAcPayHist.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;  // 返品
                }
                else if (stcSlip.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                {
                    stcAcPayHist.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;        // 赤伝
                }
                else
                {
                    stcAcPayHist.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;     // 通常伝票
                }
            }
            else
            {
                stcAcPayHist.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;         // 伝票削除
            }
            # endregion

            // -- 2009/04/09 ----->>>>
            //stcAcPayHist.InputSectionCd = stcSlip.StockSectionCd;            // 入力拠点コード
            stcAcPayHist.InputSectionCd = stcSlip.SectionCode;            // 入力拠点コード
            // -- 2009/04/09 -----<<<<

            // 入力拠点ガイド名称
            object objSecNm = this._secInfoSeTtable[stcAcPayHist.InputSectionCd.TrimEnd()];
            stcAcPayHist.InputSectionGuidNm = (objSecNm is string) ? (objSecNm as string) : string.Empty;

            stcAcPayHist.InputAgenCd = stcSlip.StockAgentCode;               // 入力担当者コード　← 仕入担当者コード
            stcAcPayHist.InputAgenNm = stcSlip.StockAgentName;               // 入力担当者名称  　← 仕入担当者名称
            stcAcPayHist.CustSlipNo = stcSlip.PartySaleSlipNum;              // 相手先伝票番号
            stcAcPayHist.SlipDtlNum = stcDtl.StockSlipDtlNum;                // 明細通番
            stcAcPayHist.AcPayNote = stcDtl.StockDtiSlipNote1;               // 受払備考          ← 仕入明細伝票備考１
            stcAcPayHist.GoodsMakerCd = stcDtl.GoodsMakerCd;                 // メーカーコード
            stcAcPayHist.MakerName = stcDtl.MakerName;                       // メーカー名称
            stcAcPayHist.GoodsNo = stcDtl.GoodsNo;                           // 商品番号
            stcAcPayHist.GoodsName = stcDtl.GoodsName;                       // 商品名称
            stcAcPayHist.BLGoodsCode = stcDtl.BLGoodsCode;                   // BL商品コード
            stcAcPayHist.BLGoodsFullName = stcDtl.BLGoodsFullName;           // BL商品コード名称(全角)
            // -- 2009/04/09 ----->>>>
            //stcAcPayHist.SectionCode = stcSlip.SectionCode;                  // 拠点コード
            stcAcPayHist.SectionCode = stcSlip.StockSectionCd;                  // 拠点コード
            // -- 2009/04/09 -----<<<<

            // 拠点ガイド名称
            objSecNm = this._secInfoSeTtable[stcAcPayHist.SectionCode.TrimEnd()];
            stcAcPayHist.SectionGuideNm = (objSecNm is string) ? (objSecNm as string) : string.Empty;

            stcAcPayHist.WarehouseCode = stcDtl.WarehouseCode;               // 倉庫コード
            stcAcPayHist.WarehouseName = stcDtl.WarehouseName;               // 倉庫名称
            stcAcPayHist.ShelfNo = stcDtl.WarehouseShelfNo;                  // 倉庫棚番
            stcAcPayHist.CustomerCode = 0;                                   // 得意先コード
            stcAcPayHist.CustomerSnm = string.Empty;                         // 得意先略称
            stcAcPayHist.SupplierCd = stcSlip.SupplierCd;                    // 仕入先コード
            stcAcPayHist.SupplierSnm = stcSlip.SupplierSnm;                  // 仕入先略称

            int sign = (mode == 0) ? 1 : -1;

            stcAcPayHist.ArrivalCnt = stcDtl.StockCount * sign;              // 入荷数                (★符号操作)
            stcAcPayHist.ShipmentCnt = 0;                                    // 出荷数
            stcAcPayHist.OpenPriceDiv = stcDtl.OpenPriceDiv;                 // オープン価格区分
            stcAcPayHist.ListPriceTaxExcFl = stcDtl.ListPriceTaxExcFl;       // 定価(税抜・浮動)
            stcAcPayHist.StockUnitPriceFl = stcDtl.StockUnitPriceFl;         // 仕入単価(税抜・浮動)
            stcAcPayHist.StockPrice = stcDtl.StockPriceTaxExc * sign;        // 仕入金額(税抜)        (★符号操作)
            stcAcPayHist.SalesUnPrcTaxExcFl = 0;                             // 売上単価(税抜,浮動)
            stcAcPayHist.SalesMoney = 0;                                     // 売上金額
        }
        //--- ADD 2009/01/28 M.Kubota ---<<<
        # endregion

        # region [変更前伝票　取得]
        /// <summary>
        /// 変更前伝票　仕入データ・仕入明細データ取得処理
        /// </summary>
        /// <param name="oldStockSlipWork"></param>
        /// <param name="oldStockDetailWorkList"></param>
        /// <param name="originList"></param>
        /// <param name="currentStockSlipWork"></param>
        /// <remarks>
        /// <br>originListの中から、今回伝票の変更前伝票データを取得します</br>
        /// </remarks>
        private void FindOldStockSlip( out StockSlipWork oldStockSlipWork, out ArrayList oldStockDetailWorkList, CustomSerializeArrayList originList, StockSlipWork currentStockSlipWork )
        {
            // 出力パラメータ初期化
            oldStockSlipWork = null;
            oldStockDetailWorkList = new ArrayList();

            //-------------------------------------------------
            // 変更前伝票　仕入データ　Find
            //-------------------------------------------------
            foreach ( object obj in originList )
            {
                // 仕入データ
                if ( obj is StockSlipWork )
                {
                    // 今回伝票と　仕入伝票区分(10:仕入/20:返品)が同じ　かつ
                    // 　　　　　　赤伝区分(0:黒伝/1:赤伝/2:元黒)が同じ　ものを変更前伝票とみなす
                    if ( (obj as StockSlipWork).SupplierSlipCd == currentStockSlipWork.SupplierSlipCd &&
                         (obj as StockSlipWork).DebitNoteDiv == currentStockSlipWork.DebitNoteDiv )
                    {
                        oldStockSlipWork = (StockSlipWork)obj;
                        break;
                    }
                }
            }
            //-------------------------------------------------
            // 変更前伝票　仕入明細データ　Find
            //-------------------------------------------------
            if ( oldStockSlipWork != null )
            {
                foreach ( object obj in originList )
                {
                    // ArrayListで要素があり、最初の要素がStockDetailWork
                    if ( obj is ArrayList && (obj as ArrayList).Count > 0 && (obj as ArrayList)[0] is StockDetailWork )
                    {
                        // 「変更前伝票仕入データの伝票番号と同じ伝票番号を持つ明細のArrayList」を
                        // 「変更前伝票仕入明細データリスト」とみなす
                        if ( ((obj as ArrayList)[0] as StockDetailWork).SupplierSlipNo == oldStockSlipWork.SupplierSlipNo )
                        {
                            oldStockDetailWorkList = (ArrayList)obj;
                            break;
                        }
                    }
                }
            }
        }
        # endregion

        # region [作成元伝票　取得]
        /// <summary>
        /// 作成元伝票　仕入データ・仕入明細データ取得処理
        /// </summary>
        /// <param name="orgStockSlipWork"></param>
        /// <param name="orgStockDetailWorkList"></param>
        /// <param name="originList"></param>
        /// <param name="currentStockSlipWork"></param>
        /// <remarks>
        /// <br>originListの中から、（今回伝票ではなく、）元伝票データを取得します</br>
        /// <br>（※返品のもとになった仕入）</br>
        /// </remarks>
        private void FindOriginalStockSlip( out StockSlipWork orgStockSlipWork, out ArrayList orgStockDetailWorkList, CustomSerializeArrayList originList, StockSlipWork currentStockSlipWork )
        {
            // 出力パラメータ初期化
            orgStockSlipWork = null;
            orgStockDetailWorkList = new ArrayList();

            //-------------------------------------------------
            // 元伝票　仕入データ　Find
            //-------------------------------------------------
            foreach ( object obj in originList )
            {
                // 仕入データ
                if ( obj is StockSlipWork )
                {
                    // 今回伝票と　仕入伝票区分(10:仕入/20:返品)が異なるもの　または
                    // 　　　　　　赤伝区分(0:黒伝/1:赤伝/2:元黒)が異なるもの　を元伝票とみなす
                    if ( (obj as StockSlipWork).SupplierSlipCd != currentStockSlipWork.SupplierSlipCd ||
                         (obj as StockSlipWork).DebitNoteDiv != currentStockSlipWork.DebitNoteDiv )
                    {
                        orgStockSlipWork = (StockSlipWork)obj;
                        break;
                    }
                }
            }
            //-------------------------------------------------
            // 元伝票　仕入明細データ　Find
            //-------------------------------------------------
            if ( orgStockSlipWork != null )
            {
                foreach ( object obj in originList )
                {
                    // ArrayListで要素があり、最初の要素がStockDetailWork
                    if ( obj is ArrayList && (obj as ArrayList).Count > 0 && (obj as ArrayList)[0] is StockDetailWork )
                    {
                        // 「元伝票仕入データの伝票番号と同じ伝票番号を持つ明細のArrayList」を
                        // 「元伝票仕入明細データリスト」とみなす
                        if ( ((obj as ArrayList)[0] as StockDetailWork).SupplierSlipNo == orgStockSlipWork.SupplierSlipNo )
                        {
                            orgStockDetailWorkList = (ArrayList)obj;
                            break;
                        }
                    }
                }
            }
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        # region [在庫数差分反映処理]
        //--- ADD 2009/01/30 --->>>
        /// <summary>
        /// 差分反映データ
        /// </summary>
        private class ReflectCntDifData
        {
            /// <summary>仕入データ</summary>
            public StockSlipWork Slip;
            /// <summary>仕入明細データ</summary>
            public StockDetailWork Detail;
            /// <summary>伝票明細追加情報データ</summary>
            /// <value>仕入データに紐付く伝票明細追加情報を設定して下さい</value>
            public SlipDetailAddInfoWork AddInfo;
            /// <summary>元黒・返品元仕入明細データ</summary>
            /// <value>修正前明細データでは無く、元黒or返品元明細データを設定して下さい</value>
            public StockDetailWork OrgDetail;
            /// <summary>計上元仕入明細データ</summary>
            public AddUpOrgStockDetailWork AddUpOrgDetail;
            /// <summary>数量差分数</summary>
            public double CntDifference;
            /// <summary>計上残区分</summary>
            /// <value>0:残す　1:残さない</value>
            public Int32 AddUpRemDiv;
            /// <summary>更新区分</summary>
            /// <value>0:Write　1:Delete</value>
            public Int32 WriteDelMode;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="slip">売上データ</param>
            /// <param name="detail">売上明細データ</param>
            /// <param name="addInfo">伝票明細追加情報データ</param>
            /// <param name="orgDetail">元黒・返品元売上明細データ</param>
            /// <param name="addUpOrgDetail">計上元売上明細データ</param>
            /// <param name="cntDifference">数量差分数</param>
            /// <param name="addUpRemDiv">計上残区分</param>
            /// <param name="writeDelMode">更新区分</param>
            public ReflectCntDifData(StockSlipWork slip, StockDetailWork detail,
                                     SlipDetailAddInfoWork addInfo, StockDetailWork orgDetail,
                                     AddUpOrgStockDetailWork addUpOrgDetail,
                                     double cntDifference, Int32 addUpRemDiv, Int32 writeDelMode)
            {
                this.Slip = slip;
                this.Detail = detail;
                this.AddInfo = addInfo;
                this.OrgDetail = orgDetail;
                this.AddUpOrgDetail = addUpOrgDetail;
                this.CntDifference = cntDifference;
                this.AddUpRemDiv = addUpRemDiv;
                this.WriteDelMode = writeDelMode;

            }

            /// <summary>
            /// 計上残区分設定処理
            /// </summary>
            /// <param name="crlOpt">売上・仕入制御オプション プロパティ</param>
            public void SetAddUpRemDiv(IOWriteCtrlOptWork crlOpt)
            {
                //明細追加情報の計上残区分は0:IOWriteCtrlOptWorkの計上残区分に準拠　1:残す　2:残さない

                if ((this.AddInfo == null) ||
                    (this.AddInfo != null && this.AddInfo.AddUpRemDiv == 0))
                {
                    //現状は残す固定
                    this.AddUpRemDiv = 0;
                }
                else
                {
                    if (this.AddInfo.AddUpRemDiv == 1)
                    {
                        // 強制的に"残す"設定
                        this.AddUpRemDiv = 0;
                    }
                    else
                    {
                        // 強制的に"残さない"設定
                        this.AddUpRemDiv = 1;
                    }
                }
            }
        }

        /// <summary>
        /// 在庫数差分反映処理
        /// </summary>
        /// <param name="stockWork">設定対象となる在庫データ</param>
        /// <param name="data">差分反映データ</param>
        private void ReflectStockCountDefference(ref StockWork stockWork, ReflectCntDifData data)
        {
            // 計上残区分が 0:残す の場合は通常通り差分数を、1:残さない の場合は計上元明細データの数を対象とする
            double CntDifferenceEx = data.CntDifference;

            if (data.AddUpRemDiv == 1 && data.AddUpOrgDetail != null && data.WriteDelMode == 0)
            {
                CntDifferenceEx = data.AddUpOrgDetail.StockCount;
            }

            //仕入形式
            switch (data.Slip.SupplierFormal)
            {
                // 仕入形式：仕入
                case 0:
                    {
                        // 仕入在庫数　←　仕入差分数
                        stockWork.SupplierStock += data.CntDifference;

                        if ((data.Slip.DebitNoteDiv == 1 && data.OrgDetail != null && data.OrgDetail.SupplierFormalSrc == 1) ||         // 入荷計上の赤伝の場合
                            (data.Slip.SupplierSlipCd == 20 && data.AddUpOrgDetail != null && data.AddUpOrgDetail.SupplierFormalSrc == 1))  // 入荷計上の返品の場合
                        {
                            // この時は在庫の更新を行わない。

                            // 貸出計上伝票に対する赤伝や返品を行っても、計上元である貸出伝票の
                            // 受注残数を更新していない(仕様)関係上、この時点で在庫マスタに対して
                            // 数量の書き戻しを行ってしまうと、受注残数と在庫マスタの数量に差異が
                            // 発生してしまう。
                        }
                        else
                        {
                            // 発注又は入荷より計上された仕入データの場合、該当する項目への加減算を行う
                            switch (data.Detail.SupplierFormalSrc)
                            {
                                case 1:
                                    {
                                        // 入荷計上
                                        stockWork.ArrivalCnt -= CntDifferenceEx;
                                        break;
                                    }
                                case 2:
                                    {
                                        // 発注計上
                                        // 2009/02/18 入庫更新対応 >>>>>>>>>>>>>>>>>
                                        //stockWork.SalesOrderCount -= CntDifferenceEx;
                                        Double salesOrderCount = CntDifferenceEx;

                                        if (data.AddInfo != null)
                                        {
                                            //発注残調整数がセットされていた場合は発注数から減算する
                                            if (data.AddInfo.OrderRemainAdjustCnt != 0)
                                                salesOrderCount += data.AddInfo.OrderRemainAdjustCnt;
                                        }

                                        stockWork.SalesOrderCount -= salesOrderCount;
                                        // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // 仕入形式：入荷
                case 1:
                    {
                        // 入荷数に仕入差分数を加算する
                        stockWork.ArrivalCnt += data.CntDifference;

                        // 発注より計上された入荷データの場合、該当する項目への加減算を行う
                        if (data.Detail.SupplierFormalSrc == 2)
                        {
                            stockWork.SalesOrderCount -= CntDifferenceEx;
                        }

                        break;
                    }
                // 仕入形式：発注
                case 2:
                    {
                        // 発注数に仕入差分数を加算する
                        stockWork.SalesOrderCount += data.CntDifference;
                        break;
                    }
            }
        }
        //--- ADD 2009/01/30 ---<<<
        #endregion


        # region [DELETE]
        /*
        /// <summary>
        /// 製番在庫マスタ・在庫受払履歴明細データ更新データクラス生成
        /// </summary>
        /// <param name="paraList">更新対象パラメータリスト</param>
        /// <param name="productStockList">製番在庫マスタ更新パラメータ</param>
        /// <param name="stockAcPayHisDtList">在庫受払履歴明細データ更新パラメータ</param>
        /// <param name="productStockCommonList">製番在庫共通クラス</param>
        /// <param name="position">仕入データ格納位置</param>
        /// <param name="explaDataPosition">仕入詳細データ格納位置</param>
        /// <param name="mode">0:更新 1:削除</param>
        /// <returns>STATUS</returns>
        private int MakeProductStockAndStockAcPayHisDt(CustomSerializeArrayList paraList, out ArrayList productStockList, out ArrayList stockAcPayHisDtList, ArrayList productStockCommonList, Int32 position, Int32 explaDataPosition, Int32 mode, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";

            //出力パラメータList(製番・受払明細)
            productStockList = new ArrayList();
            stockAcPayHisDtList = new ArrayList();

            //更新パラメータクラス格納用(製番・受払明細)
            ProductStockWork productStockWork = null;
            StockAcPayHisDtWork stockAcPayHisDtWork = null;

            //仕入データワーク格納用(ヘッダ・明細・詳細)
            StockSlipWork wkStockSlipWork = paraList[position] as StockSlipWork;
            StockDetailWork wkAddUppOrgStockDetailWork = null;
            //StockExplaDataWork wkStockExplaDataWork = null;  //DEL 2007/09/11 M.Kubota

            //製番在庫共通ワーク
            ProductStockCommonPara productStockCommon = null;

            //仕入データワーク格納用List(明細・詳細)
            ArrayList wkStockDetailWorkList = new ArrayList();
            ArrayList wkStockExplaDataWorkList = new ArrayList();

            //●仕入明細データ格納処理
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
                {
                    for (int x = 0; x < ((ArrayList)paraList[i]).Count; x++)
                    {
                        wkAddUppOrgStockDetailWork = (((ArrayList)paraList[i])[x]) as StockDetailWork;
                        if (wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage) wkStockDetailWorkList.Add(wkAddUppOrgStockDetailWork);
                    }
                }
            }
            //●仕入詳細データ格納処理
            wkStockExplaDataWorkList = paraList[explaDataPosition] as ArrayList;

            //●製番在庫マスタ更新パラメータ格納処理
            if (wkStockDetailWorkList.Count > 0)
            {
                for (int i = 0; i < wkStockDetailWorkList.Count; i++)
                {
                    wkAddUppOrgStockDetailWork = wkStockDetailWorkList[i] as StockDetailWork;

                    //在庫管理有無区分・製番管理区分チェック
                    //(在庫管理しない AND 製番管理しない) OR (在庫管理しない AND 製番管理する) ← このパターンはありえない
                    if ((wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgStockDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Unmanage) ||
                        (wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgStockDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Manage)) continue;

                    for (int y = 0; y < wkStockExplaDataWorkList.Count; y++)
                    {
                        wkStockExplaDataWork = wkStockExplaDataWorkList[y] as StockExplaDataWork;

                        //明細と詳細の行番号が一致したものをパラメータにセットする
                        if (wkAddUppOrgStockDetailWork.StockRowNo == wkStockExplaDataWork.StockRowNo)
                        {
                            productStockWork = new ProductStockWork();
                            stockAcPayHisDtWork = new StockAcPayHisDtWork();

                            #region[製番在庫マスタ更新パラメータ格納]
                            //--------------------------------------------------------------------------------------------------
                            //●製番在庫マスタ更新パラメータ格納    Start
                            //--------------------------------------------------------------------------------------------------

                            // add 2007.07.17 saito >>>>>>>>>>
                            int cmnStockState = 0;
                            int cmnStockDiv = 0;

                            if (productStockCommonList != null)
                            {
                                if (productStockCommonList.Count > 0)
                                {
                                    for (int z = 0; z < productStockCommonList.Count; z++)
                                    {
                                        productStockCommon = productStockCommonList[z] as ProductStockCommonPara;

                                        if (wkStockExplaDataWork.ProductStockGuid == productStockCommon.ProductStockGuid)
                                        {
                                            //製番在庫更新日時チェック
                                            if (wkStockExplaDataWork.ProductUpdateDateTime != productStockCommon.UpdateDateTime)
                                            {
                                                retMsg = "他端末で在庫が更新されています。再度伝票を読み込んでください。";
                                                return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            }

                                            //売上計上済み・売切・委託中の場合：計上日チェック
                                            if ((productStockCommon.StockState == (int)ConstantManagement_Mobile.ct_StockState.SalesAddUp ||
                                                 productStockCommon.StockState == (int)ConstantManagement_Mobile.ct_StockState.SellsUp ||
                                                 productStockCommon.StockState == (int)ConstantManagement_Mobile.ct_StockState.Consigning) && mode == 0)
                                            {
                                                status = this.CheckSalesAddUpDate(wkStockSlipWork, productStockCommon, ref sqlConnection, ref sqlTransaction);
                                                if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                                                {
                                                    retMsg = "計上日が不正です。既に売上計上、委託中の在庫があります。";
                                                    return status;
                                                }
                                            }
                                            //返品の場合：計上日チェック
                                            if (productStockCommon.StockState == (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods && mode == 0)
                                            {
                                                status = this.CheckReturnDate(wkStockSlipWork, productStockCommon, ref sqlConnection, ref sqlTransaction);
                                                if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                                                {
                                                    retMsg = "計上日が不正です。既に返品済みの在庫があります。";
                                                    return status;
                                                }
                                            }

                                            //製番在庫マスタのデータが正となる
                                            productStockWork.SectionCode = productStockCommon.SectionCode;
                                            if (wkStockExplaDataWork.StockUpdDiscDiv == 1)
                                            {
                                                productStockWork.ProductNumber = productStockCommon.ProductNumber;
                                                cmnStockDiv = productStockCommon.StockDiv;
                                                cmnStockState = productStockCommon.StockState;
                                                productStockWork.StockTelNo1 = productStockCommon.StockTelNo1;
                                                productStockWork.StockTelNo2 = productStockCommon.StockTelNo2;
                                                if (String.IsNullOrEmpty(productStockCommon.StockTelNo1))
                                                    productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.White;
                                                else
                                                    productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.Black;
                                            }
                                        }
                                    }
                                }
                            }
                            if (String.IsNullOrEmpty(productStockWork.SectionCode))
                            {
                                productStockWork.SectionCode = wkStockSlipWork.StockUpdateSecCd; //拠点コード←在庫更新拠点コード
                            }
                            // add 2007.07.17 saito <<<<<<<<<<

                            //仕入詳細　→　製番在庫マスタ
                            productStockWork.ProductStockGuid = wkStockExplaDataWork.ProductStockGuid;  //製番在庫マスタGUID

                            if (wkStockExplaDataWork.StockUpdDiscDiv == 0)
                            {
                                //ロム区分
                                if (String.IsNullOrEmpty(wkStockExplaDataWork.StockTelNo1))
                                    productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.White;
                                else
                                    productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.Black;

                                productStockWork.ProductNumber = wkStockExplaDataWork.ProductNumber1;     //製造番号1
                                productStockWork.StockTelNo1 = wkStockExplaDataWork.StockTelNo1;      //商品電話番号1
                                productStockWork.StockTelNo2 = wkStockExplaDataWork.StockTelNo2;      //商品電話番号2
                            }

                            //仕入ヘッダ　→　製番在庫マスタ
                            productStockWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;     //企業コード
                            productStockWork.CarrierEpCode = wkStockSlipWork.CarrierEpCode;       //事業者コード
                            productStockWork.CarrierEpName = wkStockSlipWork.CarrierEpName;       //事業者名称
                            productStockWork.CustomerCode = wkStockSlipWork.CustomerCode;         //得意先コード
                            productStockWork.CustomerName = wkStockSlipWork.CustomerName;         //得意先名称
                            productStockWork.CustomerName2 = wkStockSlipWork.CustomerName2;       //得意先名称2
                            productStockWork.StockDate = wkStockSlipWork.StockDate;               //仕入日
                            productStockWork.ArrivalGoodsDay = wkStockSlipWork.ArrivalGoodsDay;   //入荷日
                            //在庫区分
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                            {
                                if (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                                {
                                    productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
                                }
                                else if ((wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy) && mode == 0)
                                {
                                    if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
                                    {
                                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
                                    }
                                    else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                                    {
                                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
                                    }
                                }
                                else if ((wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy) && mode == 1)
                                {
                                    if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
                                    {
                                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
                                    }
                                    else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                                    {
                                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
                                    }
                                }
                            }
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                            {
                                productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
                            }
                            //●在庫状態
                            //仕入伝票更新
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal && mode == 0)
                            {
                                //在庫
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                            }
                            //受託伝票更新
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal && mode == 0)
                            {
                                //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }
                            //赤伝票更新(仕入)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal && mode == 0)
                            {
                                //返品
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
                            }
                            //赤伝票更新(受託)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal && mode == 0)
                            {
                                //返品
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
                            }
                            //返品伝票更新(仕入)
                            else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                            //wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal && mode == 0)
                            {
                                //返品
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
                            }
                            //受託計上伝票更新(通常)
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                     (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                      wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy) && mode == 0)
                            {
                                //在庫
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                            }
                            //受託計上伝票更新(赤伝)
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
                                     (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy) && mode == 0)
                            {
                                //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }
                            //売上時自動受託計上伝票更新(黒伝)
                            //else if (wkStockSlipWork.DebitNoteDiv == 0 && wkStockSlipWork.TrustAddUpSpCd == 2 && mode == 0)
                            //{
                            // Del 2007.04.09 Saitoh >>>>>>>>>>
                            //productStockWork.StockState = 50;    //売上計上済
                            // Del 2007.04.09 Saitoh <<<<<<<<<<

                                // Add 2007.04.09 Saitoh >>>>>>>>>>
                            //productStockWork.StockState = 0;        //在庫
                            // Add 2007.04.09 Saitoh <<<<<<<<<<
                            //}
                            // Add 2007.04.09 Saitoh >>>>>>>>>>
                            //売上時自動受託計上伝票更新(赤伝)
                            //else if (wkStockSlipWork.DebitNoteDiv == 1 && wkStockSlipWork.TrustAddUpSpCd == 2 && mode == 0)
                            //{
                            //    productStockWork.StockState = 10;       //受託中
                            //}
                            // Add 2007.04.09 Saitoh <<<<<<<<<<
                            //伝票削除(仕入・受託)　→　物理削除となるのでDELETE
                            //else if (wkStockSlipWork.TrustAddUpSpCd == 0 && wkStockSlipWork.DebitNoteDiv == 0 && mode == 1)
                            //{
                            //    productStockWork.StockState = 81;   //消去
                            //}
                            //赤伝票削除(仕入)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 1)
                            {
                                //在庫
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                            }
                            //赤伝票削除(受託)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 1)
                            {
                                //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }
                            //返品伝票削除(仕入)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                     wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return && mode == 1)
                            {
                                //在庫
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                            }
                            //返品伝票削除(受託)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return && mode == 1)
                            {
                                //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }
                            //受託計上伝票(通常)
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                     (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy) && mode == 1)
                            {
                                //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }
                            //受託計上伝票(赤伝)
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
                                     (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy) && mode == 1)
                            {
                                //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }

                            if (wkStockExplaDataWork.StockUpdDiscDiv == 1)
                            {
                                productStockWork.StockDiv = cmnStockDiv;
                                productStockWork.StockState = cmnStockState;
                            }


                            //仕入明細　→　製番在庫マスタ
                            productStockWork.MakerCode = wkAddUppOrgStockDetailWork.MakerCode;     //メーカーコード
                            productStockWork.MakerName = wkAddUppOrgStockDetailWork.MakerName;     //メーカー名称
                            productStockWork.GoodsCode = wkAddUppOrgStockDetailWork.GoodsCode;     //商品コード
                            productStockWork.GoodsName = wkAddUppOrgStockDetailWork.GoodsName;     //商品名称
                            productStockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;     //仕入単価

                            productStockWork.TaxationCode = wkAddUppOrgStockDetailWork.TaxationCode;       //課税区分
                            productStockWork.CarrierCode = wkAddUppOrgStockDetailWork.CarrierCode;         //キャリアコード
                            productStockWork.CarrierName = wkAddUppOrgStockDetailWork.CarrierName;         //キャリア名称
                            productStockWork.SystematicColorCd = wkAddUppOrgStockDetailWork.SystematicColorCd;     //系統色コード
                            productStockWork.SystematicColorNm = wkAddUppOrgStockDetailWork.SystematicColorNm;     //系統色名称
                            productStockWork.LargeGoodsGanreCode = wkAddUppOrgStockDetailWork.LargeGoodsGanreCode; //商品大分類コード
                            productStockWork.MediumGoodsGanreCode = wkAddUppOrgStockDetailWork.MediumGoodsGanreCode;   //商品中分類コード
                            productStockWork.WarehouseCode = wkAddUppOrgStockDetailWork.WarehouseCode;       //倉庫コード
                            productStockWork.WarehouseName = wkAddUppOrgStockDetailWork.WarehouseName;       //倉庫名称
                            productStockWork.CellphoneModelCode = wkAddUppOrgStockDetailWork.CellphoneModelCode;     //機種コード
                            productStockWork.CellphoneModelName = wkAddUppOrgStockDetailWork.CellphoneModelName;     //機種名称


                            //製番在庫マスタ出力ArrayListに追加
                            productStockList.Add(productStockWork);
                            //--------------------------------------------------------------------------------------------------
                            //●製番在庫マスタ更新パラメータ格納    End
                            //--------------------------------------------------------------------------------------------------
                            #endregion

                            #region[在庫受払履歴明細データ更新パラメータ格納]
                            //--------------------------------------------------------------------------------------------------
                            //●在庫受払履歴明細データ更新パラメータ格納    Start
                            //--------------------------------------------------------------------------------------------------
                            //仕入明細　→　在庫受払履歴明細データ
                            stockAcPayHisDtWork.MakerCode = wkAddUppOrgStockDetailWork.MakerCode;  //メーカーコード
                            stockAcPayHisDtWork.MakerName = wkAddUppOrgStockDetailWork.MakerName;  //メーカー名称
                            stockAcPayHisDtWork.GoodsCode = wkAddUppOrgStockDetailWork.GoodsCode;  //商品コード
                            stockAcPayHisDtWork.GoodsName = wkAddUppOrgStockDetailWork.GoodsName;  //商品名称
                            stockAcPayHisDtWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;    //仕入単価
                            stockAcPayHisDtWork.CarrierCode = wkAddUppOrgStockDetailWork.CarrierCode;  //キャリアコード
                            stockAcPayHisDtWork.CarrierName = wkAddUppOrgStockDetailWork.CarrierName;  //キャリア名称
                            stockAcPayHisDtWork.CellphoneModelCode = wkAddUppOrgStockDetailWork.CellphoneModelCode;    //機種コード
                            stockAcPayHisDtWork.CellphoneModelName = wkAddUppOrgStockDetailWork.CellphoneModelName;    //機種名称

                            //仕入詳細　→　在庫受払履歴明細データ
                            stockAcPayHisDtWork.AcPaySlipNum = System.Convert.ToString(wkStockExplaDataWork.SupplierSlipNo);   //受払元伝票番号
                            stockAcPayHisDtWork.AcPaySlipRowNo = wkStockExplaDataWork.StockRowNo;   //受払元行番号
                            stockAcPayHisDtWork.AcPaySlipExpNo = wkStockExplaDataWork.StckSlipExpNum; //受払元詳細番号
                            stockAcPayHisDtWork.ProductStockGuid = wkStockExplaDataWork.ProductStockGuid; //製番在庫マスタGUID
                            stockAcPayHisDtWork.AcPayNote = wkStockExplaDataWork.StockExpSlipNote;      //仕入伝票詳細備考

                            //stockAcPayHisDtWork.ProductNumber = wkStockExplaDataWork.ProductNumber1;  //製造番号
                            //stockAcPayHisDtWork.StockTelNo1 = wkStockExplaDataWork.StockTelNo1;       //商品電話番号1
                            //stockAcPayHisDtWork.StockTelNo2 = wkStockExplaDataWork.StockTelNo2;       //商品電話番号2

                            //ロム区分
                            //if (wkStockExplaDataWork.StockTelNo1 == null || wkStockExplaDataWork.StockTelNo1 == "")
                            //{
                            //ロム区分：白ロム
                            //    stockAcPayHisDtWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.White;
                            //}
                            //else
                            //{
                            //    //ロム区分：黒ロム
                            //    stockAcPayHisDtWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.Black;
                            //}

                            //仕入ヘッダ　→　在庫受払履歴明細データ
                            stockAcPayHisDtWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;  //企業コード
                            stockAcPayHisDtWork.CarrierEpCode = wkStockSlipWork.CarrierEpCode;    //事業者コード
                            stockAcPayHisDtWork.CarrierEpName = wkStockSlipWork.CarrierEpName;    //事業者名称
                            stockAcPayHisDtWork.CustomerCode = wkStockSlipWork.CustomerCode;      //得意先コード
                            stockAcPayHisDtWork.CustomerName = wkStockSlipWork.CustomerName;      //得意先名称
                            stockAcPayHisDtWork.CustomerName2 = wkStockSlipWork.CustomerName2;    //得意先名称2
                            stockAcPayHisDtWork.InputAgenCd = wkStockSlipWork.StockAgentCode;     //入力担当者コード　←　仕入担当者コード
                            stockAcPayHisDtWork.InputAgenNm = wkStockSlipWork.StockAgentName;     //入力担当者名称　←　仕入担当者名称
                            stockAcPayHisDtWork.SectionCode = wkStockSlipWork.StockUpdateSecCd;     //拠点コード　←　仕入拠点コード　2007.05.25修正
                            //受払元伝票区分
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                            {
                                //10:仕入
                                stockAcPayHisDtWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Stock;
                            }
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                            {
                                //11:受託
                                stockAcPayHisDtWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Trust;
                            }
                            else if (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                            {
                                //12:受計上
                                stockAcPayHisDtWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.TrustAddUp;
                            }
                            //受払元取引区分
                            if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                            {
                                //通常伝票
                                stockAcPayHisDtWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;
                            }
                            else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black && mode == 0)
                            {
                                //返品
                                stockAcPayHisDtWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                            }
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red && mode == 0)
                            {
                                //赤伝
                                stockAcPayHisDtWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;
                            }
                            else if (mode == 1)
                            {
                                //削除
                                stockAcPayHisDtWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                            }

                            //入荷数・仕入在庫数・受託数
                            //仕入
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                            {
                                //通常仕入
                                if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                    wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                                {
                                    stockAcPayHisDtWork.ArrivalCnt = 1;       //入荷数
                                    stockAcPayHisDtWork.SupplierStock = 1;    //仕入在庫数
                                    stockAcPayHisDtWork.TrustCount = 0;       //受託数
                                }
                                //受託計上
                                else if ((wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy) ||
                                         (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                                {
                                    stockAcPayHisDtWork.ArrivalCnt = 1;       //入荷数
                                    stockAcPayHisDtWork.SupplierStock = 1;    //仕入在庫数
                                    stockAcPayHisDtWork.TrustCount = 0;       //受託数
                                }
                                //返品(赤伝含む)
                                else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                                {
                                    stockAcPayHisDtWork.ArrivalCnt = -1;       //入荷数
                                    stockAcPayHisDtWork.SupplierStock = 0;    //仕入在庫数
                                    stockAcPayHisDtWork.TrustCount = 0;       //受託数
                                }
                                //受託計上の返品
                                else if ((wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy) ||
                                         (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                                {
                                    //返品
                                    if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
                                    {
                                        stockAcPayHisDtWork.ArrivalCnt = -1;       //入荷数
                                        stockAcPayHisDtWork.SupplierStock = 0;    //仕入在庫数
                                        stockAcPayHisDtWork.TrustCount = 0;       //受託数
                                    }
                                    //赤伝
                                    else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                                    {
                                        stockAcPayHisDtWork.ArrivalCnt = -1;       //入荷数
                                        stockAcPayHisDtWork.SupplierStock = 0;    //仕入在庫数
                                        stockAcPayHisDtWork.TrustCount = 1;       //受託数
                                    }
                                }
                            }
                            //受託
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                            {
                                //受託仕入
                                if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase)
                                {
                                    stockAcPayHisDtWork.ArrivalCnt = 1;       //入荷数
                                    stockAcPayHisDtWork.SupplierStock = 0;    //仕入在庫数
                                    stockAcPayHisDtWork.TrustCount = 1;       //受託数
                                }
                                //受託返品(赤伝含む)
                                else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                                {
                                    stockAcPayHisDtWork.ArrivalCnt = -1;      //入荷数
                                    stockAcPayHisDtWork.SupplierStock = 0;    //仕入在庫数
                                    stockAcPayHisDtWork.TrustCount = 0;       //受託数
                                }
                            }

                            //入出荷日(仕入：仕入日　受託：入荷日)
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                            {
                                stockAcPayHisDtWork.IoGoodsDay = wkStockSlipWork.StockDate;           //入出荷日　←　仕入日
                            }
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                            {
                                stockAcPayHisDtWork.IoGoodsDay = wkStockSlipWork.ArrivalGoodsDay;       //入出荷日　←　入荷日
                            }

                            //製番在庫パラメータと整合性をとる
                            stockAcPayHisDtWork.StockState = productStockWork.StockState; //在庫状態
                            stockAcPayHisDtWork.ProductNumber = productStockWork.ProductNumber; //製造番号
                            stockAcPayHisDtWork.StockTelNo1 = productStockWork.StockTelNo1; //商品電話番号１
                            stockAcPayHisDtWork.StockTelNo2 = productStockWork.StockTelNo2; //商品電話番号２
                            stockAcPayHisDtWork.RomDiv = productStockWork.RomDiv; //ロム区分

                            //在庫受払履歴明細データ出力ArrayListに追加
                            stockAcPayHisDtList.Add(stockAcPayHisDtWork);
                            //--------------------------------------------------------------------------------------------------
                            //●在庫受払履歴明細データ更新パラメータ格納    End
                            //--------------------------------------------------------------------------------------------------
                            #endregion
                        }
                    }
                }
            }

            return status;

        }

        /// <summary>
        /// 在庫マスタ更新データクラス生成
        /// </summary>
        /// <param name="paraList">更新対象パラメータリスト</param>
        /// <param name="stockList">在庫マスタ更新パラメータ</param>
        /// <param name="position">仕入データ格納位置</param>
        /// <param name="detailPosition">仕入明細データ格納位置</param>
        /// <param name="mode">0:加算 1:減算</param>
        /// <returns>STATUS</returns>
        private int MakeStockWork(CustomSerializeArrayList paraList, out ArrayList stockList, Int32 position, Int32 detailPosition, Int32 mode)
        {
            //出力パラメータList(在庫)
            stockList = new ArrayList();

            //更新パラメータクラス格納用(在庫)
            StockWork stockWork = null;

            //仕入データワーク格納用(ヘッダ・明細)
            StockSlipWork wkStockSlipWork = paraList[position] as StockSlipWork;
            StockDetailWork dtlwork = null;
            ArrayList wkStockDetailWorkList = paraList[detailPosition] as ArrayList;

            //データ比較クラス(在庫)
            //StockWorkCountComparer stockWorkComparer = new StockWorkCountComparer();

            //●在庫マスタ更新パラメータ格納処理
            #region[在庫マスタ更新パラメータ格納]
            for (int i = 0; i < wkStockDetailWorkList.Count; i++)
            {
                dtlwork = wkStockDetailWorkList[i] as StockDetailWork;

                stockWork = new StockWork();

                //在庫管理有無区分・仕入数チェック
                if (dtlwork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage || dtlwork.StockCount == 0) continue;

                //仕入ヘッダ　→　在庫マスタ
                stockWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;     //企業コード
                stockWork.SectionCode = wkStockSlipWork.StockUpdateSecCd;        //拠点コード　←　仕入拠点コード　2007.05.25修正
                stockWork.LastStockDate = wkStockSlipWork.StockDate;           //最終仕入年月日　←　仕入日

                //仕入明細　→　在庫マスタ
                stockWork.GoodsMakerCd = dtlwork.GoodsMakerCd;                  // 商品メーカーコード
                stockWork.MakerName = dtlwork.MakerName;                        // メーカー名称
                stockWork.GoodsNo = dtlwork.GoodsNo;                            // 商品番号
                stockWork.GoodsName = dtlwork.GoodsName;                        // 商品名称
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.07
                stockWork.GoodsShortName = dtlwork.GoodsShortName;              // 商品名略称
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.07
                stockWork.LargeGoodsGanreCode = dtlwork.LargeGoodsGanreCode;    // 商品区分グループコード
                stockWork.LargeGoodsGanreName = dtlwork.LargeGoodsGanreName;    // 商品区分グループ名称
                stockWork.MediumGoodsGanreCode = dtlwork.MediumGoodsGanreCode;  // 商品区分コード
                stockWork.MediumGoodsGanreName = dtlwork.MediumGoodsGanreName;  // 商品区分名称
                stockWork.DetailGoodsGanreCode = dtlwork.DetailGoodsGanreCode;  // 商品区分詳細コード
                stockWork.DetailGoodsGanreName = dtlwork.DetailGoodsGanreName;  // 商品区分詳細名称
                stockWork.StockUnitPriceFl = dtlwork.StockUnitPriceFl;          // 仕入単価

                // TODO 設定が必要なのか後日 在庫リモ担当者に確認
                stockWork.BLGoodsCode = dtlwork.BLGoodsCode;                    // BL商品コード
                stockWork.BLGoodsFullName = dtlwork.BLGoodsFullName;            // BL商品コード名称(全角)
                stockWork.EnterpriseGanreCode = dtlwork.EnterpriseGanreCode;    // 自社分類コード
                stockWork.EnterpriseGanreName = dtlwork.EnterpriseGanreName;    // 自社分類コード名称(全角)
                stockWork.WarehouseCode = dtlwork.WarehouseCode;                // 倉庫コード
                stockWork.WarehouseName = dtlwork.WarehouseName;                // 倉庫名称
                stockWork.WarehouseShelfNo = dtlwork.WarehouseShelfNo;          // 倉庫棚番
               
                --- DEL 2007/09/11 M.Kubota --->>>
                //stockWork.MakerName = wkAddUppOrgStockDetailWork.MakerName;            //メーカー名称
                //stockWork.GoodsName = wkAddUppOrgStockDetailWork.GoodsName;            //商品名称
                ////stockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;  //仕入単価
                //stockWork.CarrierCode = wkAddUppOrgStockDetailWork.CarrierCode;        //キャリアコード
                //stockWork.CarrierName = wkAddUppOrgStockDetailWork.CarrierName;        //キャリア名称
                //stockWork.SystematicColorCd = wkAddUppOrgStockDetailWork.SystematicColorCd;    //系統色コード
                //stockWork.SystematicColorNm = wkAddUppOrgStockDetailWork.SystematicColorNm;    //系統色名称
                //stockWork.LargeGoodsGanreCode = wkAddUppOrgStockDetailWork.LargeGoodsGanreCode;    //商品大分類コード
                //stockWork.MediumGoodsGanreCode = wkAddUppOrgStockDetailWork.MediumGoodsGanreCode;  //商品中分類コード
                //stockWork.PrdNumMngDiv = wkAddUppOrgStockDetailWork.PrdNumMngDiv;        //製番管理区分
                //stockWork.CellphoneModelCode = wkAddUppOrgStockDetailWork.CellphoneModelCode;    //機種コード
                //stockWork.CellphoneModelName = wkAddUppOrgStockDetailWork.CellphoneModelName;    //機種名称
                //stockWork.MakerCode = wkAddUppOrgStockDetailWork.MakerCode;            //メーカーコード
                //stockWork.GoodsCode = wkAddUppOrgStockDetailWork.GoodsCode;            //商品コード
                //stockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;    //仕入単価
                --- DEL 2007/09/11 M.Kubota ---<<<
                 
                //仕入形式・受託計上仕入区分にて分岐
                if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                {
                    //更新処理・削除処理にて分岐
                    if (mode == 0)
                    {
                        stockWork.SupplierStock += dtlwork.StockCount; //仕入在庫数　←　仕入数
                    }
                    else if (mode == 1)
                    {
                        stockWork.SupplierStock += -dtlwork.StockCount; //仕入在庫数　←　仕入数
                    }
                }
                else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                {
                    if (mode == 0)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                        //stockWork.TrustCount += dtlwork.StockCount; //受託数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        stockWork.ArrivalCnt += dtlwork.StockCount; //入荷数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    }
                    else if (mode == 1)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                        //stockWork.TrustCount += -dtlwork.StockCount; //受託数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        stockWork.ArrivalCnt += -dtlwork.StockCount; //入荷数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    }
                }
                //受託計上仕入の場合
                else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
                {
                    if (mode == 0)
                    {
                        stockWork.SupplierStock += dtlwork.StockCount;    //仕入在庫数　←　仕入数
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                        //stockWork.TrustCount += -dtlwork.StockCount;      //受託数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        stockWork.ArrivalCnt += -dtlwork.StockCount;      //入荷数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    }
                    else if (mode == 1)
                    {
                        stockWork.SupplierStock += -dtlwork.StockCount;   //仕入在庫数　←　仕入数
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                        //stockWork.TrustCount += dtlwork.StockCount;       //受託数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        stockWork.ArrivalCnt += dtlwork.StockCount;       //入荷数　←　仕入数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                    }
                }
                else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                {
                    stockWork.SupplierStock += dtlwork.StockCount;        //仕入在庫数　←　仕入数
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //stockWork.TrustCount += -dtlwork.StockCount;          //受託数　←　仕入数
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                    stockWork.ArrivalCnt += -dtlwork.StockCount;          //入荷数　←　仕入数
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                }

                stockList.Add(stockWork);

            }
            #endregion

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }

        /// <summary>
        /// 製番在庫マスタ更新データクラス生成
        /// </summary>
        /// <param name="paraList">更新対象パラメータリスト</param>
        /// <param name="productStockList">製番在庫マスタ更新パラメータ</param>
        /// <param name="position">仕入データ格納位置</param>
        /// <param name="explaDataPosition">仕入詳細データ格納位置</param>
        /// <returns>STATUS</returns>
        private int MakeProductStockWork(CustomSerializeArrayList paraList, out ArrayList productStockList, Int32 position, Int32 explaDataPosition)
        {
            //出力パラメータList(製番)
            productStockList = new ArrayList();

            //更新パラメータクラス格納用(製番)
            ProductStockWork productStockWork = null;

            //仕入データワーク格納用(ヘッダ・明細・詳細)
            StockSlipWork wkStockSlipWork = paraList[position] as StockSlipWork;
            StockDetailWork wkAddUppOrgStockDetailWork = null;
            //StockExplaDataWork wkStockExplaDataWork = null;  //DEL 2007/09/11 M.Kubota

            //仕入データワーク格納用List(明細・詳細)
            ArrayList wkStockDetailWorkList = new ArrayList();
            ArrayList wkStockExplaDataWorkList = new ArrayList();

            //仕入明細データ格納処理
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
                {
                    for (int x = 0; x < ((ArrayList)paraList[i]).Count; x++)
                    {
                        wkAddUppOrgStockDetailWork = (((ArrayList)paraList[i])[x]) as StockDetailWork;
                        if (wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage) wkStockDetailWorkList.Add(wkAddUppOrgStockDetailWork);
                    }
                }
            }
            //仕入詳細データ格納処理
            wkStockExplaDataWorkList = paraList[explaDataPosition] as ArrayList;

            //●製番在庫マスタ更新パラメータ格納処理
            #region[製番在庫マスタ更新パラメータ格納]
            if (wkStockDetailWorkList.Count > 0)
            {
                for (int i = 0; i < wkStockDetailWorkList.Count; i++)
                {
                    wkAddUppOrgStockDetailWork = wkStockDetailWorkList[i] as StockDetailWork;

                    //(在庫管理しない AND 製番管理しない) OR (在庫管理しない AND 製番管理する) ← このパターンはありえない
                    if ((wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgStockDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Unmanage) ||
                        (wkAddUppOrgStockDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgStockDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Manage)) continue;

                    for (int y = 0; y < wkStockExplaDataWorkList.Count; y++)
                    {
                        wkStockExplaDataWork = wkStockExplaDataWorkList[y] as StockExplaDataWork;

                        //●明細と詳細の行番号が一致したものをパラメータにセットする
                        if (wkAddUppOrgStockDetailWork.StockRowNo == wkStockExplaDataWork.StockRowNo)
                        {
                            productStockWork = new ProductStockWork();

                            //仕入詳細　→　製番在庫マスタ
                            productStockWork.ProductNumber = wkStockExplaDataWork.ProductNumber1;     //製造番号1
                            productStockWork.ProductStockGuid = wkStockExplaDataWork.ProductStockGuid;  //製番在庫マスタGUID
                            productStockWork.StockTelNo1 = wkStockExplaDataWork.StockTelNo1;      //商品電話番号1
                            productStockWork.StockTelNo2 = wkStockExplaDataWork.StockTelNo2;      //商品電話番号2
                            //ロム区分
                            if (wkStockExplaDataWork.StockTelNo1 == null || wkStockExplaDataWork.StockTelNo1 == "")
                            {
                                productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.White;    //ロム区分：白ロム
                            }
                            else
                            {
                                productStockWork.RomDiv = (int)ConstantManagement_Mobile.ct_RomDiv.Black;    //ロム区分：黒ロム
                            }

                            //仕入ヘッダ　→　製番在庫マスタ
                            productStockWork.EnterpriseCode = wkStockSlipWork.EnterpriseCode;     //企業コード
                            productStockWork.SectionCode = wkStockSlipWork.StockUpdateSecCd;        //拠点コード　←　仕入拠点コード　2007.05.25修正
                            productStockWork.CarrierEpCode = wkStockSlipWork.CarrierEpCode;       //事業者コード
                            productStockWork.CarrierEpName = wkStockSlipWork.CarrierEpName;       //事業者名称
                            productStockWork.CustomerCode = wkStockSlipWork.CustomerCode;         //得意先コード
                            productStockWork.CustomerName = wkStockSlipWork.CustomerName;         //得意先名称
                            productStockWork.CustomerName2 = wkStockSlipWork.CustomerName2;       //得意先名称2
                            productStockWork.StockDate = wkStockSlipWork.StockDate;               //仕入日
                            productStockWork.ArrivalGoodsDay = wkStockSlipWork.ArrivalGoodsDay;   //入荷日
                            //在庫区分
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                            {
                                if (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                                {
                                    productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
                                }
                                else if (wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                                         wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                                {
                                    if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
                                    {
                                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
                                    }
                                    else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                                    {
                                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
                                    }
                                }
                            }
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                            {
                                //productStockWork.StockDiv = 1;  //在庫区分：受託
                                productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
                            }

                            //●在庫状態
                            //仕入伝票更新
                            if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                            {
                                //productStockWork.StockState = 0;    //在庫
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                            }
                            //受託伝票更新
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
                            {
                                //productStockWork.StockState = 10;   //受託中
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                            }
                            //赤伝票更新(仕入)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                            {
                                //productStockWork.StockState = 0;     //在庫
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                            }
                            //赤伝票更新(受託)
                            else if (wkStockSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                                     wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                            {
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;   //受託中
                            }
                            //返品伝票更新(仕入)
                            else if (wkStockSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
                            {
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;   //返品
                            }
                            //受託計上伝票更新(通常)
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
                            {
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;    //在庫
                            }
                            //受託計上伝票更新(赤伝)
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
                            {
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;   //受託中
                            }
                            //売上時自動受託計上伝票更新
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                            {
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;    //在庫
                            }
                            else if (wkStockSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
                                     wkStockSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
                            {
                                productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;    //受託中
                            }
                            //仕入明細　→　製番在庫マスタ
                            productStockWork.MakerCode = wkAddUppOrgStockDetailWork.MakerCode;     //メーカーコード
                            productStockWork.MakerName = wkAddUppOrgStockDetailWork.MakerName;     //メーカー名称
                            productStockWork.GoodsCode = wkAddUppOrgStockDetailWork.GoodsCode;     //商品コード
                            productStockWork.GoodsName = wkAddUppOrgStockDetailWork.GoodsName;     //商品名称
                            productStockWork.StockUnitPrice = wkAddUppOrgStockDetailWork.StockUnitPrice;     //仕入単価

                            // Del 2007.03.26 Saitoh
                            //productStockWork.StockPrice = wkAddUppOrgStockDetailWork.PrdNumStockPrice;       //仕入金額　←　製番仕入金額
                            //productStockWork.StockPriceConsTax = wkAddUppOrgStockDetailWork.PrdNumStockConsTax;  //仕入金額消費税額　←　製番仕入消費税額
                            //productStockWork.ItdedStckOutTax = wkAddUppOrgStockDetailWork.ItdPrdNumStckOutTax;   //仕入外税対象額　←　製番仕入外税対象額
                            //productStockWork.ItdedStckInTax = wkAddUppOrgStockDetailWork.ItdPrdNumStckInTax;     //仕入内税対象額　←　製番仕入内税対象額
                            //productStockWork.ItdedStckTaxFree = wkAddUppOrgStockDetailWork.ItdPrdNumStckTaxFree; //仕入非課税対象額　←　製番仕入非課税対象額
                            //productStockWork.StckOuterTax = wkAddUppOrgStockDetailWork.PrdNumStckOuterTax;       //仕入外税額　←　製番仕入外税額
                            //productStockWork.StckInnerTax = wkAddUppOrgStockDetailWork.PrdNumStckInnerTax;       //仕入内税額　←　製番仕入内税額
                            // Del 2007.03.26 Saitoh

                            productStockWork.TaxationCode = wkAddUppOrgStockDetailWork.TaxationCode;       //課税区分
                            productStockWork.CarrierCode = wkAddUppOrgStockDetailWork.CarrierCode;         //キャリアコード
                            productStockWork.CarrierName = wkAddUppOrgStockDetailWork.CarrierName;         //キャリア名称
                            productStockWork.SystematicColorCd = wkAddUppOrgStockDetailWork.SystematicColorCd;     //系統色コード
                            productStockWork.SystematicColorNm = wkAddUppOrgStockDetailWork.SystematicColorNm;     //系統色名称
                            productStockWork.LargeGoodsGanreCode = wkAddUppOrgStockDetailWork.LargeGoodsGanreCode; //商品大分類コード
                            productStockWork.MediumGoodsGanreCode = wkAddUppOrgStockDetailWork.MediumGoodsGanreCode;   //商品中分類コード
                            productStockWork.WarehouseCode = wkAddUppOrgStockDetailWork.WarehouseCode;       //倉庫コード
                            productStockWork.WarehouseName = wkAddUppOrgStockDetailWork.WarehouseName;       //倉庫名称
                            productStockWork.CellphoneModelCode = wkAddUppOrgStockDetailWork.CellphoneModelCode;     //機種コード
                            productStockWork.CellphoneModelName = wkAddUppOrgStockDetailWork.CellphoneModelName;     //機種名称

                            //製番在庫マスタ出力ArrayListに追加
                            productStockList.Add(productStockWork);
                        }
                    }
                }
            }
            #endregion

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
        */
        # endregion



        # region [DELETE]
        /*
        /// <summary>
        /// 在庫マスタの差分を抽出します　※未使用
        /// </summary>
        /// <param name="oldStockWorkList">修正前在庫マスタパラメータ</param>
        /// <param name="stockWorkParaList">修正後在庫マスタ更新パラメータ</param>
        /// <param name="stockWorkUpdateList">更新在庫マスタパラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタの差分を抽出します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.21</br>
        private int MakeStockWorkAdd(ArrayList oldStockWorkList, ArrayList stockWorkList, out ArrayList stockWorkUpdateList)
        {
            //出力パラメータList(在庫)
            stockWorkUpdateList = new ArrayList();

            //更新パラメータ格納用(在庫)
            StockWork oldStockWork = null;
            StockWork stockWork = null;

            //仕入在庫数・受託数
            double supplierStock;
            double trustCount;

            //該当データなしフラグ
            bool flg;

            //●在庫数の差分計算(追加データはそのまま)
            for (int i = 0; i < oldStockWorkList.Count; i++)
            {
                oldStockWork = oldStockWorkList[i] as StockWork;

                flg = false;

                for (int x = 0; x < stockWorkList.Count; x++)
                {
                    stockWork = stockWorkList[x] as StockWork;

                    if (oldStockWork.MakerCode == stockWork.MakerCode && oldStockWork.GoodsCode == stockWork.GoodsCode &&
                        oldStockWork.SectionCode == stockWork.SectionCode && oldStockWork.StockUnitPrice == stockWork.StockUnitPrice)
                    {
                        supplierStock = 0;
                        trustCount = 0;
                        //差分抽出
                        supplierStock = stockWork.SupplierStock - oldStockWork.SupplierStock; //仕入在庫数
                        trustCount = stockWork.TrustCount - oldStockWork.TrustCount;          //受託数

                        stockWork.SupplierStock = supplierStock;
                        stockWork.TrustCount = trustCount;

                        //差分抽出データ格納
                        stockWorkUpdateList.Add(stockWork);

                        flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    supplierStock = 0;
                    trustCount = 0;
                    //削除データをマイナスする
                    supplierStock = -oldStockWork.SupplierStock;
                    trustCount = -oldStockWork.TrustCount;

                    oldStockWork.SupplierStock = supplierStock;
                    oldStockWork.TrustCount = trustCount;

                    //削除データ格納
                    stockWorkUpdateList.Add(oldStockWork);
                }
            }

            //●新規追加データのチェック
            for (int i = 0; i < stockWorkList.Count; i++)
            {
                stockWork = stockWorkList[i] as StockWork;

                flg = false;

                for (int x = 0; x < oldStockWorkList.Count; x++)
                {
                    oldStockWork = oldStockWorkList[x] as StockWork;

                    if (stockWork.MakerCode == oldStockWork.MakerCode && stockWork.GoodsCode == oldStockWork.GoodsCode &&
                        stockWork.SectionCode == oldStockWork.SectionCode && stockWork.StockUnitPrice == oldStockWork.StockUnitPrice)
                    {
                        flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    //新規追加データをそのまま追加
                    stockWorkUpdateList.Add(stockWork);
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        */
        /*
        /// <summary>
        /// 在庫マスタの差分を抽出します(受託計上伝票修正時)　※未使用
        /// </summary>
        /// <param name="oldStockWorkList">修正前在庫マスタパラメータ</param>
        /// <param name="stockWorkParaList">修正後在庫マスタ更新パラメータ</param>
        /// <param name="stockWorkUpdateList">更新在庫マスタパラメータ</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタの差分を抽出します(受託計上伝票修正時)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.26</br>
        private int MakeTrustAddStockWork(ArrayList oldStockWorkList, ArrayList stockWorkList, out ArrayList stockWorkUpdateList)
        {
            //出力パラメータList(在庫)
            stockWorkUpdateList = new ArrayList();

            //更新パラメータ格納用(在庫)
            StockWork oldStockWork = null;
            StockWork stockWork = null;

            //仕入在庫数
            double supplierStock;
            double trustCount;

            //該当データなしフラグ
            bool flg;

            //●在庫数の差分計算(追加データはそのまま)
            for (int i = 0; i < oldStockWorkList.Count; i++)
            {
                oldStockWork = oldStockWorkList[i] as StockWork;

                flg = false;

                for (int x = 0; x < stockWorkList.Count; x++)
                {
                    stockWork = stockWorkList[x] as StockWork;

                    if (oldStockWork.MakerCode == stockWork.MakerCode && oldStockWork.GoodsCode == stockWork.GoodsCode &&
                        oldStockWork.SectionCode == stockWork.SectionCode && oldStockWork.StockUnitPrice == stockWork.StockUnitPrice)
                    {
                        supplierStock = 0;
                        trustCount = 0;
                        //差分抽出
                        supplierStock = stockWork.SupplierStock - oldStockWork.SupplierStock; //仕入在庫数
                        trustCount = -(stockWork.SupplierStock - oldStockWork.SupplierStock);          //受託数

                        stockWork.SupplierStock = supplierStock;
                        stockWork.TrustCount = trustCount;

                        //差分抽出データ格納
                        stockWorkUpdateList.Add(stockWork);

                        flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    supplierStock = 0;
                    trustCount = 0;
                    //削除データをマイナスする
                    supplierStock = -oldStockWork.SupplierStock;
                    trustCount = oldStockWork.SupplierStock;

                    oldStockWork.SupplierStock = supplierStock;
                    oldStockWork.TrustCount = trustCount;

                    //削除データ格納
                    stockWorkUpdateList.Add(oldStockWork);
                }
            }

            //●新規追加データのチェック
            for (int i = 0; i < stockWorkList.Count; i++)
            {
                stockWork = stockWorkList[i] as StockWork;

                flg = false;

                for (int x = 0; x < oldStockWorkList.Count; x++)
                {
                    oldStockWork = oldStockWorkList[x] as StockWork;

                    if (stockWork.MakerCode == oldStockWork.MakerCode && stockWork.GoodsCode == oldStockWork.GoodsCode &&
                        stockWork.SectionCode == oldStockWork.SectionCode && stockWork.StockUnitPrice == oldStockWork.StockUnitPrice)
                    {
                        flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    //新規追加データをそのまま追加
                    stockWorkUpdateList.Add(stockWork);
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        */
        /*
        /// <summary>
        /// 製番在庫マスタの差分を抽出します
        /// </summary>
        /// <param name="oldProductStockWorkList">修正前製番在庫マスタパラメータ</param>
        /// <param name="productStockWorkList">修正後製番在庫マスタ更新パラメータ</param>
        /// <param name="deleteProductStockWorkList"></param>
        /// <returns></returns>
        /// <br>Note       : 製番在庫マスタの差分を抽出します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.21</br>
        private int MakeProductStockWorkAdd(ArrayList oldProductStockWorkList, ArrayList productStockWorkList, out ArrayList deleteProductStockWorkList)
        {
            //製番在庫マスタ更新パラメータ格納用
            ProductStockWork oldProductStockWork = null;
            ProductStockWork productStockWork = null;

            deleteProductStockWorkList = new ArrayList();

            DeleteProductStockWork deleteProductStockWork = null;

            //該当データなしフラグ
            bool flg;

            //●製番在庫の差分計算(追加データはそのまま)
            for (int i = 0; i < oldProductStockWorkList.Count; i++)
            {
                oldProductStockWork = oldProductStockWorkList[i] as ProductStockWork;

                flg = false;

                for (int x = 0; x < productStockWorkList.Count; x++)
                {
                    productStockWork = productStockWorkList[x] as ProductStockWork;

                    if (oldProductStockWork.ProductStockGuid == productStockWork.ProductStockGuid)
                    {
                        flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    deleteProductStockWork = new DeleteProductStockWork();

                    //削除用製番在庫マスタパラメータListにAdd
                    deleteProductStockWork.EnterpriseCode = oldProductStockWork.EnterpriseCode;
                    deleteProductStockWork.FileHeaderGuid = oldProductStockWork.FileHeaderGuid;
                    deleteProductStockWork.GoodsCode = oldProductStockWork.GoodsCode;
                    deleteProductStockWork.GoodsCodeStatus = oldProductStockWork.GoodsCodeStatus;
                    deleteProductStockWork.LogicalDeleteCode = oldProductStockWork.LogicalDeleteCode;
                    deleteProductStockWork.MakerCode = oldProductStockWork.MakerCode;
                    deleteProductStockWork.MoveStatus = oldProductStockWork.MoveStatus;
                    deleteProductStockWork.ProductNumber = oldProductStockWork.ProductNumber;
                    deleteProductStockWork.ProductStockGuid = oldProductStockWork.ProductStockGuid;
                    deleteProductStockWork.SectionCode = oldProductStockWork.SectionCode;
                    deleteProductStockWork.StockDiv = oldProductStockWork.StockDiv;
                    deleteProductStockWork.StockState = oldProductStockWork.StockState; // add 2007.05.29 saito
                    //deleteProductStockWork.StockState = 81; // del 2007.05.28 saito
                    deleteProductStockWork.StockTelNo1 = oldProductStockWork.StockTelNo1;
                    deleteProductStockWork.StockTelNo2 = oldProductStockWork.StockTelNo2;
                    deleteProductStockWork.UpdateDateTime = oldProductStockWork.UpdateDateTime;
                    deleteProductStockWork.UpdEmployeeCode = oldProductStockWork.UpdEmployeeCode;

                    deleteProductStockWorkList.Add(deleteProductStockWork);
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
        */
        /*
        /// <summary>
        /// 製番在庫の書込結果Listを生成します
        /// </summary>
        /// <param name="list">仕入・在庫書込結果List</param>
        /// <param name="product_Position">製番在庫データ格納位置</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 製番在庫の書込結果Listを生成します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.21</br>
        private int MakeProductCommon(ref CustomSerializeArrayList list, int product_Position)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //製番在庫書込結果パラメータList
            ArrayList productStockList = new ArrayList();
            ArrayList productStockCommonList = new ArrayList();

            //製番在庫パラメータ
            ProductStockWork productStockWork = null;
            ProductStockCommonPara productStockCommonPara = null;

            //●ProductStockWorkの取り出し
            productStockList = list[product_Position] as ArrayList;

            //●ProductStockCommonParaの生成
            for (int i = 0; i < productStockList.Count; i++)
            {
                productStockWork = new ProductStockWork();
                productStockCommonPara = new ProductStockCommonPara();

                productStockWork = productStockList[i] as ProductStockWork;

                //製番在庫データ　→　製番在庫書込結果データ
                productStockCommonPara.EnterpriseCode = productStockWork.EnterpriseCode;
                productStockCommonPara.FileHeaderGuid = productStockWork.FileHeaderGuid;
                productStockCommonPara.GoodsCode = productStockWork.GoodsCode;
                productStockCommonPara.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
                productStockCommonPara.LogicalDeleteCode = productStockWork.LogicalDeleteCode;
                productStockCommonPara.MakerCode = productStockWork.MakerCode;
                productStockCommonPara.MoveStatus = productStockWork.MoveStatus;
                productStockCommonPara.ProcResultState = 0;
                productStockCommonPara.ProductNumber = productStockWork.ProductNumber;
                productStockCommonPara.ProductStockGuid = productStockWork.ProductStockGuid;
                productStockCommonPara.SectionCode = productStockWork.SectionCode;
                productStockCommonPara.StockDiv = productStockWork.StockDiv;
                productStockCommonPara.StockState = productStockWork.StockState;
                productStockCommonPara.StockTelNo1 = productStockWork.StockTelNo1;
                productStockCommonPara.StockTelNo2 = productStockWork.StockTelNo2;
                productStockCommonPara.UpdateDateTime = productStockWork.UpdateDateTime;
                productStockCommonPara.UpdEmployeeCode = productStockWork.UpdEmployeeCode;
                productStockCommonPara.WarehouseCode = productStockWork.WarehouseCode;
                productStockCommonPara.StockUnitPrice = productStockWork.StockUnitPrice;

                productStockCommonList.Add(productStockCommonPara);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            //listに追加
            list.Add(productStockCommonList);

            return status;
        }
        */
        /*
        /// <summary>
        /// 製番在庫の削除Listを生成します
        /// </summary>
        /// <param name="productStockWorkList">製番List</param>
        /// <param name="deleteProductStockWorkList">削除製番List</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 製番在庫の削除Listを生成します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.23</br>
        private int MakeDeleteProductStock(ArrayList productStockWorkList, out ArrayList deleteProductStockWorkList)
        {
            //●製番在庫マスタデータ格納用
            ProductStockWork productStockWork = null;
            DeleteProductStockWork deleteProductStockWork = null;

            deleteProductStockWorkList = new ArrayList();

            for (int i = 0; i < productStockWorkList.Count; i++)
            {
                productStockWork = productStockWorkList[i] as ProductStockWork;
                deleteProductStockWork = new DeleteProductStockWork();

                deleteProductStockWork.EnterpriseCode = productStockWork.EnterpriseCode;
                deleteProductStockWork.FileHeaderGuid = productStockWork.FileHeaderGuid;
                deleteProductStockWork.GoodsCode = productStockWork.GoodsCode;
                deleteProductStockWork.GoodsCodeStatus = productStockWork.GoodsCodeStatus;
                deleteProductStockWork.LogicalDeleteCode = productStockWork.LogicalDeleteCode;
                deleteProductStockWork.MakerCode = productStockWork.MakerCode;
                deleteProductStockWork.MoveStatus = productStockWork.MoveStatus;
                deleteProductStockWork.ProductNumber = productStockWork.ProductNumber;
                deleteProductStockWork.ProductStockGuid = productStockWork.ProductStockGuid;
                deleteProductStockWork.SectionCode = productStockWork.SectionCode;
                deleteProductStockWork.StockDiv = productStockWork.StockDiv;
                deleteProductStockWork.StockState = productStockWork.StockState;
                deleteProductStockWork.StockTelNo1 = productStockWork.StockTelNo1;
                deleteProductStockWork.StockTelNo2 = productStockWork.StockTelNo2;
                deleteProductStockWork.UpdateDateTime = productStockWork.UpdateDateTime;
                deleteProductStockWork.UpdEmployeeCode = productStockWork.UpdEmployeeCode;

                deleteProductStockWorkList.Add(deleteProductStockWork);
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        */
        /*
        /// <summary>
        /// 返品伝票修正の場合の製番在庫Listを生成します
        /// </summary>
        /// <param name="oldProductStockWorkList">製番List</param>
        /// <param name="productStockWorkList">製番List結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品伝票修正の場合の製番在庫Listを生成します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.26</br>
        private int MakeReturnProductStock(ref ArrayList oldProductStockWorkList, ref ArrayList productStockWorkList)
        {
            //●製番在庫マスタデータ格納用
            ProductStockWork productStockWork = null;
            ProductStockWork oldProductStockWork = null;

            bool flg;

            for (int i = 0; i < oldProductStockWorkList.Count; i++)
            {
                oldProductStockWork = oldProductStockWorkList[i] as ProductStockWork;

                flg = false;

                for (int x = 0; x < productStockWorkList.Count; x++)
                {
                    productStockWork = productStockWorkList[x] as ProductStockWork;

                    if (oldProductStockWork.ProductStockGuid == productStockWork.ProductStockGuid)
                    {
                        flg = true;
                        break;
                    }
                }

                //在庫状態を「在庫・受託中」に戻す
                if (flg == false)
                {
                    if (oldProductStockWork.StockDiv == (int)ConstantManagement_Mobile.ct_StockDiv.Company)
                    {
                        oldProductStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                    }
                    else if (oldProductStockWork.StockDiv == (int)ConstantManagement_Mobile.ct_StockDiv.Trust)
                    {
                        oldProductStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
                    }

                    productStockWorkList.Add(oldProductStockWork);
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        */
        /*      
        /// <summary>
        /// 受託計上伝票修正の場合の製番在庫Listを生成します
        /// </summary>
        /// <param name="oldProductStockWorkList">製番List</param>
        /// <param name="productStockWorkList">製番List結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受託計上伝票修正の場合の製番在庫Listを生成します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.26</br>
        private int MakeTrustAddProductStock(ref ArrayList oldProductStockWorkList, ref ArrayList productStockWorkList)
        {
            //●製造番号マスタデータ格納用
            ProductStockWork productStockWork = null;
            ProductStockWork oldProductStockWork = null;

            bool flg;

            for (int i = 0; i < oldProductStockWorkList.Count; i++)
            {
                oldProductStockWork = oldProductStockWorkList[i] as ProductStockWork;

                flg = false;

                for (int x = 0; x < productStockWorkList.Count; x++)
                {
                    productStockWork = productStockWorkList[x] as ProductStockWork;

                    if (oldProductStockWork.ProductStockGuid == productStockWork.ProductStockGuid)
                    {
                        flg = true;
                        break;
                    }
                }

                //在庫状態を在庫に戻す
                if (flg == false)
                {
                    oldProductStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
                    productStockWorkList.Add(oldProductStockWork);
                }

            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        */
        # endregion
        #endregion [パラメータ取得処理]

        // --- ADD 2015/04/08 y.wakita ----->>>>>
        # region [パラメータ再設定処理]
        /// <summary>
        /// 在庫マスタ・在庫受払履歴データ更新データクラス生成
        /// </summary>
        /// <param name="paraList">更新対象パラメータリスト</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        private int ReMakeStockAndStockAcPayHist(ref CustomSerializeArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                int listPos = 0;

                ArrayList stockList = new ArrayList();
                ArrayList stockAcPayHistList = new ArrayList();

                ArrayList stockListBK = new ArrayList();
                ArrayList stockAcPayHistListBK = new ArrayList();

                bool goodsFlg = false;
                bool stockListFlg = false;
                bool stockAcPayHistListFlg = false;

                #region[在庫マスタ更新パラメータ格納]
                //--------------------------------------------------------------------------------------------------
                //●在庫マスタ更新パラメータ格納    Start
                //--------------------------------------------------------------------------------------------------
                listPos = -1;
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList item = paraList[i] as ArrayList;
                    if (item != null)
                    {
                        if (item.Count > 0)
                        {
                            //在庫マスタでリストがNULLの場合
                            if (item[0] is StockWork)
                            {
                                stockListBK = item;
                                listPos = i;  //格納されていた位置を退避
                            }
                        }
                    }
                }

                foreach (StockWork stockWork in stockListBK)
                {
                    goodsFlg = false;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        SqlDataReader myReader = null;
                        sqlCommand.Connection = sqlConnection;
                        if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                        string sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  GOODS.*" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      GOODS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  AND GOODS.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODS.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        try
                        {
                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                goodsFlg = true;
                            }
                            else
                            {
                                stockListFlg = true;
                            }
                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                        }
                    }

                    // 商品マスタが存在する
                    if (goodsFlg)
                    {
                        stockList.Add(stockWork);
                    }
                }

                // 在庫マスタ更新パラの商品が商品マスタに存在しない場合
                if (stockListFlg)
                {
                    if (stockList.Count == 0)
                    {
                        // 更新パラメータから削除
                        paraList.RemoveAt(listPos);
                    }
                    else
                    {
                        paraList[listPos] = stockList;
                    }
                }

                //--------------------------------------------------------------------------------------------------
                //●在庫マスタ更新パラメータ格納    End
                //--------------------------------------------------------------------------------------------------
                #endregion

                #region[在庫受払履歴データ更新パラメータ格納]
                //--------------------------------------------------------------------------------------------------
                //●在庫受払履歴データ更新パラメータ格納    Start
                //--------------------------------------------------------------------------------------------------
                listPos = -1;
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList item = paraList[i] as ArrayList;
                    if (item != null)
                    {
                        if (item.Count > 0)
                        {
                            //在庫受払履歴マスタの場合
                            if (item[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistListBK = item;
                                listPos = i; //格納されていた位置を退避
                            }
                        }
                    }
                }

                foreach (StockAcPayHistWork stockAcPayHistWork in stockAcPayHistListBK)
                {
                    goodsFlg = false;

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        SqlDataReader myReader = null;
                        sqlCommand.Connection = sqlConnection;
                        if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                        string sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  GOODS.*" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      GOODS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  AND GOODS.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODS.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.EnterpriseCode);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.GoodsNo);

                        try
                        {
                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                goodsFlg = true;
                            }
                            else
                            {
                                stockAcPayHistListFlg = true;
                            }
                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                        }
                    }

                    // 商品マスタが存在する
                    if (goodsFlg)
                    {
                        stockAcPayHistList.Add(stockAcPayHistWork);
                    }
                }

                // 在庫受払履歴データ更新パラの商品が商品マスタに存在しない場合
                if (stockAcPayHistListFlg)
                {
                    if (stockAcPayHistList.Count == 0)
                    {
                        // 更新パラメータから削除
                        paraList.RemoveAt(listPos);
                    }
                    else
                    {
                        paraList[listPos] = stockAcPayHistList;
                    }
                }
                //--------------------------------------------------------------------------------------------------
                //●在庫受払履歴データ更新パラメータ格納    End
                //--------------------------------------------------------------------------------------------------
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            return status;
        }
        # endregion
        // --- ADD 2015/04/08 y.wakita -----<<<<<
    }

    #region [比較クラス]

    /// <summary>
    /// 在庫受払履歴データ比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫受払履歴データ比較クラス</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.02.05</br>
    /// </remarks>
    public class StockAcPayHistWorkComparer : System.Collections.IComparer
    {
        //--- ADD 2009/01/16 M.Kubota --->>>
        private bool _DifferenceUpdate;

        /// <summary>
        /// 差分更新 false: 無し true: 有り
        /// </summary>
        public bool DifferenceUpdate
        {
            get { return this._DifferenceUpdate; }
        }
        //--- ADD 2009/01/16 M.Kubota ---<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            this._DifferenceUpdate = false;
            int result = 0;

            StockAcPayHistWork cx = (StockAcPayHistWork)x;
            StockAcPayHistWork cy = (StockAcPayHistWork)y;

            # region [--- DEL 2009/01/16 M.Kubota ---]
            //// メーカーコード
            //result = cx.GoodsMakerCd - cy.GoodsMakerCd;

            //// 商品コード
            //if (result == 0)
            //{
            //    result = string.Compare(cx.GoodsNo, cy.GoodsNo);
            //}

            //// 倉庫コード
            //if (result == 0)
            //{
            //    result = string.Compare(cx.WarehouseCode, cy.WarehouseCode);
            //}
            # endregion
            //--- ADD 2009/01/28 M.Kubota --->>>

            # region [ キー項目 ]

            // 企業コード
            string sx = cx.EnterpriseCode.TrimEnd();
            string sy = cy.EnterpriseCode.TrimEnd();
            result = sx.CompareTo(sy);

            // 受払元伝票区分
            if (result == 0)
            {
                result = cx.AcPaySlipCd - cy.AcPaySlipCd;
            }

            // 受払元伝票番号
            if (result == 0)
            {
                result = cx.AcPaySlipCd.CompareTo(cy.AcPaySlipCd);
            }

            // メーカーコード
            if (result == 0)
            {
                result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            }

            // 商品コード
            if (result == 0)
            {
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);
            }

            // 倉庫コード
            if (result == 0)
            {
                sx = cx.WarehouseCode.TrimEnd();
                sy = cy.WarehouseCode.TrimEnd();
                result = sx.CompareTo(sy);
            }

            // 明細通番
            if (result == 0)
            {
                result = cx.SlipDtlNum.CompareTo(cy.SlipDtlNum);
            }
            # endregion

            # region [ その他 ]
            // 入出荷日
            if (result == 0)
            {
                result = cx.IoGoodsDay.CompareTo(cy.IoGoodsDay);
            }

            // 計上日付
            if (result == 0)
            {
                result = cx.AddUpADate.CompareTo(cy.AddUpADate);
            }

            // 入力拠点コード
            if (result == 0)
            {
                sx = cx.InputSectionCd.TrimEnd();
                sy = cy.InputSectionCd.TrimEnd();
                result = sx.CompareTo(sy);
            }

            // 入力担当者コード
            if (result == 0)
            {
                // ※DB上 nchar では無いが、末尾の空白有無による誤処理を防ぐ為にTrimを追加
                sx = cx.InputAgenCd.TrimEnd();
                sy = cy.InputAgenCd.TrimEnd();
                result = sx.CompareTo(sy);
            }

            // 商品名称
            if (result == 0)
            {
                result = cx.GoodsName.CompareTo(cy.GoodsName);
            }

            // 仕入先コード
            if (result == 0)
            {
                result = cx.SupplierCd.CompareTo(cy.SupplierCd);
            }

            // 定価
            if (result == 0)
            {
                result = cx.ListPriceTaxExcFl.CompareTo(cy.ListPriceTaxExcFl);
            }

            // 仕入単価
            if (result == 0)
            {
                result = cx.StockUnitPriceFl.CompareTo(cy.StockUnitPriceFl);
            }

            // 入荷数
            int ArrivalDiff = cx.ArrivalCnt.CompareTo(cy.ArrivalCnt);

            // 仕入金額
            int StockPriceDiff = cx.StockPrice.CompareTo(cy.StockPrice);

            //result += ArrivalDiff + StockPriceDiff;

            if (ArrivalDiff + StockPriceDiff != 0)
            {
                this._DifferenceUpdate = true;
            }
            # endregion
            //--- ADD 2009/01/16 M.Kubota ---<<<

            //結果を返す
            return result;
        }
    }

    # region [DELETE]
    /*
    /// <summary>
    /// 在庫マスタ比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ比較クラス</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.02.09</br>
    /// </remarks>
    public class StockWorkCountComparer : System.Collections.IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockWork cx = (StockWork)x;
            StockWork cy = (StockWork)y;

            //メーカーコード
            result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            //商品コード
            if (result == 0)
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);
            //仕入単価
            if (result == 0)
                result = (int)(cx.StockUnitPriceFl - cy.StockUnitPriceFl);

            //結果を返す
            return result;
        }
    }

    /// <summary>
    /// 在庫マスタ比較クラス(拠点コードあり)
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ比較クラス(拠点コードあり)</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.06.07</br>
    /// </remarks>
    public class StockWorkSecComparer : System.Collections.IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockWork cx = (StockWork)x;
            StockWork cy = (StockWork)y;

            //メーカーコード
            result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            //商品コード
            if (result == 0)
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);
            //仕入単価
            if (result == 0)
                result = (int)(cx.StockUnitPriceFl - cy.StockUnitPriceFl);

            //拠点コード
            if (result == 0)
                result = string.Compare(cx.SectionCode, cy.SectionCode);

            //結果を返す
            return result;
        }
    }
    */
    #endregion
    #endregion

    # region [--- DEL 2009/01/30 ---]
#if false
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
    # region [DetailsSelector クラス]
    /// <summary>
    /// 仕入明細セレクタクラス
    /// </summary>
    /// <remarks>
    /// <br>指定した仕入伝票明細に対応する、同一キーの仕入伝票明細を取得する機能を提供します</br>
    /// </remarks>
    internal class StockDetailsSelector
    {
        // 明細リスト
        private ArrayList _details;
        // 明細ディクショナリ
        private System.Collections.Generic.Dictionary<StockDetailKey, StockDetailWork> _detailDic;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="detailsList"></param>
        public StockDetailsSelector( ArrayList detailsList )
        {
            _details = detailsList;

            if ( _details != null )
            {
                _detailDic = new System.Collections.Generic.Dictionary<StockDetailKey, StockDetailWork>();

                foreach ( object detail in _details )
                {
                    if ( detail is StockDetailWork )
                    {
                        // 仕入明細キー構造体をKeyにして、仕入明細のディクショナリに追加
                        _detailDic.Add( new StockDetailKey( detail as StockDetailWork ), detail as StockDetailWork );
                    }
                }
            }
        }
        /// <summary>
        /// 明細検索処理
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <returns></returns>
        public StockDetailWork Find( StockDetailWork stockDetailWork )
        {
            if ( _details != null )
            {
                StockDetailKey key = new StockDetailKey( stockDetailWork );

                if ( _detailDic.ContainsKey( key ) )
                {
                    // 指定されたStockDetailWorkと同一keyの仕入明細を返す
                    return _detailDic[key];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        # region [仕入明細キー構造体]
        /// <summary>
        /// 仕入明細キー構造体
        /// </summary>
        private struct StockDetailKey
        {
            /// <summary>仕入行番号</summary>
            private int _stockRowNo;
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>倉庫コード</summary>
            private string _warehouseCode;
            /// <summary>メーカーコード</summary>
            private int _goodsMakerCd;
            /// <summary>商品番号</summary>
            private string _goodsNo;

            /// <summary>
            /// 仕入行番号
            /// </summary>
            public int StockRowNo
            {
                get { return _stockRowNo; }
                set { _stockRowNo = value; }
            }
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 倉庫コード
            /// </summary>
            public string WarehouseCode
            {
                get { return _warehouseCode; }
                set { _warehouseCode = value; }
            }
            /// <summary>
            /// メーカーコード
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// 商品番号
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="stockRowNo">仕入行番号</param>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="warehouseCode">倉庫コード</param>
            /// <param name="goodsMakerCd">メーカーコード</param>
            /// <param name="goodsNo">商品番号</param>
            public StockDetailKey( int stockRowNo, string sectionCode, string warehouseCode, int goodsMakerCd, string goodsNo )
            {
                _stockRowNo = stockRowNo;
                _sectionCode = sectionCode;
                _warehouseCode = warehouseCode;
                _goodsMakerCd = goodsMakerCd;
                _goodsNo = goodsNo;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="stockDetailWork">仕入明細データクラス</param>
            public StockDetailKey( StockDetailWork stockDetailWork )
            {
                _stockRowNo = stockDetailWork.StockRowNo;
                _sectionCode = stockDetailWork.SectionCode.TrimEnd();
                _warehouseCode = stockDetailWork.WarehouseCode.TrimEnd();
                _goodsMakerCd = stockDetailWork.GoodsMakerCd;
                _goodsNo = stockDetailWork.GoodsNo.TrimEnd();
            }
        }
        # endregion
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
#endif
    #endregion
}
