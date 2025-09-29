using System;
using System.Data;
using System.Diagnostics;  //ADD 2008/06/06 M.Kubota
using System.Collections;
using System.Collections.Generic;  //ADD 2009/01/30 M.Kubota
using System.Data.SqlClient;
using Broadleaf.Application.Common;
using Broadleaf.Library;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources; // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// IOWrite在庫更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : IOWriteにて在庫系の更新処理をまとめて行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: 受払履歴の拠点コードセット方法の修正</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: ５次改良 計上残残さないで一部計上時の計上元伝票削除対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/03/18</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note: 障害改良対応　貸出計上した売上伝票を更新時にエラー発生する件の修正</br>
    /// <br>             　　　　　　　(貸出計上残区分＝残さない、の場合)</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2011/04/21</br>
    /// <br></br>
    /// <br>Update Note: 障害改良対応</br>
    /// <br>               2011/04/21の内容について修正。受注売上同時入力で在庫数が不正になる件の対応。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br></br>
    /// <br>Update Note: 障害対応(計上残区分：残さないで同時入力(受注売上)を行うと2重で在庫が更新される)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2011/12/08</br>
    /// <br></br>
    /// <br>Update Note: 障害対応(在庫品の貸出返品伝票を削除しても在庫マスタの貸出数が更新されない)</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2013/04/04</br>
    /// <br></br>
    /// <br>Update Note: 仕掛一覧№1752(1866) 貸出計上した貸出伝票が論理削除されない障害の修正</br>
    /// <br>Programmer : 西 毅</br>
    /// <br>Date       : 2013/05/08</br>
    /// <br></br>
    /// <br>Update Note: 仕掛一覧№1752(1866) 対応時の障害の修正</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2013/06/07</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/01 宮本 利明</br>
    /// <br>管理番号   : 11070071-00　仕掛一覧 №2257</br>
    /// <br>             計上を含む貸出データの伝票削除を可能にする</br>
    /// <br></br>
    /// <br>Update Note: フタバ個別対応</br>
    /// <br>             赤伝･返品･削除時在庫引当処理対応</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : K2014/06/12</br>
    /// <br></br>
    /// <br>Update Note: Redmine#44885対応</br>
    /// <br>             商品在庫マスタ登録時にエラーが発生する</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/04/08</br>
    /// <br></br>
    /// <br>Update Note: Redmine#47400対応</br>
    /// <br>             紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2015/09/17</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class IOWriteMAHNBStockUpdateDB : RemoteWithAppLockDB//, IFunctionCallTargetWrite
    {
        private SecInfoSetDB _secInfoSetDB = null;
        // --- DEL 2013/05/08 T.Nishi ----->>>>>
        //private Hashtable _secInfoSeTtable = null;
        // --- DEL 2013/05/08 T.Nishi -----<<<<<
        private StockDB stockDB = new StockDB();

        //--- ADD 2009/01/30 M.Kubota --->>>
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

        //>>>2011/12/08
        private ArrayList _sameInputAcptList = null; // 受注売上同時入力時の計上元情報
        /// <summary>
        /// 受注売上同時入力時の計上元情報プロパティ
        /// </summary>
        public ArrayList SameInputAcptList
        {
            get
            {
                return this._sameInputAcptList;
            }

            set
            {
                this._sameInputAcptList = value;
            }
        }
        //<<<2011/12/08

        /// <summary>
        /// IOWrite在庫更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="ioWriteCtrlOptWork">売上・仕入制御オプション プロパティ</param>
        /// <remarks>
        /// <br>Note       : 特に無し</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public IOWriteMAHNBStockUpdateDB(IOWriteCtrlOptWork ioWriteCtrlOptWork)
            : base()
        {
            this._CtrlOptWork = ioWriteCtrlOptWork;
        }
        //--- ADD 2009/01/30 M.Kubota ---<<<

        # region [--- DEL 2009/01/30 M.Kubota ---]
        ///// <summary>
        ///// IOWrite在庫更新リモートオブジェクトクラスコンストラクタ
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 特に無し</br>
        ///// <br>Programmer : 21112　久保田　誠</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public IOWriteMAHNBStockUpdateDB()
        //{

        //}
        # endregion

        # region [取り合えず削除]

        #region [製番在庫ステータスチェック処理]
        ///// <summary>
        ///// 製造番号の在庫状態をチェックします
        ///// </summary>
        ///// <param name="productStockCommonParaList">製番在庫共通クラスList</param>
        ///// <param name="salesSlipWork">売上データクラス</param>
        ///// <param name="retMsg">メッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 製造番号の在庫状態をチェックします</br>
        ///// <br>Programmer : 21112　久保田　誠</br>
        ///// <br>Date       : 2007.05.31</br>
        //private int CheckProductNumStatus(ArrayList productStockCommonParaList, StockSlipWork salesSlipWork, out string retMsg)
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

        //        // 通常売上
        //        if (salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //        {
        //            //①売上伝票修正
        //            if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
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
        //            //②売上の返品作成(新規返品伝票)
        //            else if (salesSlipWork.CreateDateTime == DateTime.MinValue &&
        //                     salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SupplierStock)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //③売上の赤伝作成
        //            else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.SupplierStock)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //④返品の修正
        //            else if (salesSlipWork.CreateDateTime > DateTime.MinValue &&
        //                     salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑤受託修正
        //            else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
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
        //            else if (salesSlipWork.CreateDateTime == DateTime.MinValue &&
        //                     salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑦受託の赤伝作成
        //            else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑧受託の返品伝票修正
        //            else if (salesSlipWork.CreateDateTime > DateTime.MinValue &&
        //                     salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //        }
        //        // 受託計上売上
        //        else if (salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
        //        {
        //            //⑨新規受託計上売上
        //            if (salesSlipWork.CreateDateTime == DateTime.MinValue &&
        //                salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //            {
        //                if (productStockCommon.StockState != (int)ConstantManagement_Mobile.ct_StockState.Entrusting)
        //                {
        //                    retMsg = message + productStockCommon.ProductNumber.ToString();
        //                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //                    break;
        //                }
        //            }
        //            //⑩受託計上売上(修正)
        //            else if (salesSlipWork.CreateDateTime > DateTime.MinValue &&
        //                     salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                     salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                     salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
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


        # region [仮削除]
        ///// <summary>
        ///// 返品時の製番在庫パラメータ作成処理（在庫検索からの返品処理に対応）
        ///// </summary>
        ///// <param name="paraList"></param>
        ///// <param name="productStockWorkList">製番在庫ワークList</param>
        ///// <param name="productStockCommonList">製番在庫共通ワークList</param>
        ///// <param name="position">売上データ位置</param>
        ///// <param name="explaDataPosition">売上詳細データ位置</param>
        ///// <returns></returns>
        //private int MakeReturnProductStockPara(CustomSerializeArrayList paraList, out ArrayList productStockWorkList, ArrayList productStockCommonList, Int32 position, Int32 explaDataPosition)
        //{
        //    //出力パラメータList(製番)
        //    productStockWorkList = new ArrayList();

        //    //更新パラメータクラス格納用(製番)
        //    ProductStockWork productStockWork = null;

        //    //売上データワーク格納用(ヘッダ・明細・詳細)
        //    StockSlipWork wkSalesSlipWork = paraList[position] as StockSlipWork;
        //    StockDetailWork wkAddUppOrgSalesDetailWork = null;
        //    StockExplaDataWork wkStockExplaDataWork = null;

        //    ProductStockCommonPara productStockCommonPara = null;

        //    //売上データワーク格納用List(明細・詳細)
        //    ArrayList wkSalesDetailWorkList = new ArrayList();
        //    ArrayList wkStockExplaDataWorkList = new ArrayList();

        //    //売上明細データ格納処理
        //    for (int i = 0; i < paraList.Count; i++)
        //    {
        //        if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
        //        {
        //            for (int x = 0; x < ((ArrayList)paraList[i]).Count; x++)
        //            {
        //                wkAddUppOrgSalesDetailWork = (((ArrayList)paraList[i])[x]) as StockDetailWork;
        //                if (wkAddUppOrgSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage) wkSalesDetailWorkList.Add(wkAddUppOrgSalesDetailWork);
        //            }
        //        }
        //    }
        //    //売上詳細データ格納処理
        //    wkStockExplaDataWorkList = paraList[explaDataPosition] as ArrayList;

        //    //●製番在庫マスタ更新パラメータ格納処理
        //    #region[製番在庫マスタ更新パラメータ格納]
        //    if (wkSalesDetailWorkList.Count > 0)
        //    {
        //        for (int i = 0; i < wkSalesDetailWorkList.Count; i++)
        //        {
        //            wkAddUppOrgSalesDetailWork = wkSalesDetailWorkList[i] as StockDetailWork;

        //            //(在庫管理しない AND 製番管理しない) OR (在庫管理しない AND 製番管理する) ← このパターンはありえない
        //            if ((wkAddUppOrgSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgSalesDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Unmanage) ||
        //                (wkAddUppOrgSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage && wkAddUppOrgSalesDetailWork.PrdNumMngDiv == (int)ConstantManagement_Mobile.ct_PrdNumMngDiv.Manage)) continue;

        //            for (int y = 0; y < wkStockExplaDataWorkList.Count; y++)
        //            {
        //                wkStockExplaDataWork = wkStockExplaDataWorkList[y] as StockExplaDataWork;

        //                //●明細と詳細の行番号が一致したものをパラメータにセットする
        //                if (wkAddUppOrgSalesDetailWork.SalesRowNo == wkStockExplaDataWork.SalesRowNo)
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
        //                        productStockWork.SectionCode = wkSalesSlipWork.StockUpdateSecCd;        //拠点コード

        //                    //売上詳細　→　製番在庫マスタ
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

        //                    //売上ヘッダ　→　製番在庫マスタ
        //                    productStockWork.EnterpriseCode = wkSalesSlipWork.EnterpriseCode;     //企業コード
        //                    productStockWork.CarrierEpCode = wkSalesSlipWork.CarrierEpCode;       //事業者コード
        //                    productStockWork.CarrierEpName = wkSalesSlipWork.CarrierEpName;       //事業者名称
        //                    productStockWork.CustomerCode = wkSalesSlipWork.CustomerCode;         //得意先コード
        //                    productStockWork.CustomerName = wkSalesSlipWork.CustomerName;         //得意先名称
        //                    productStockWork.CustomerName2 = wkSalesSlipWork.CustomerName2;       //得意先名称2
        //                    productStockWork.StockDate = wkSalesSlipWork.StockDate;               //売上日
        //                    productStockWork.ArrivalGoodsDay = wkSalesSlipWork.ArrivalGoodsDay;   //入荷日

        //                    //在庫区分
        //                    if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
        //                    {
        //                        if (wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                        {
        //                            productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
        //                        }
        //                        else if (wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
        //                                 wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
        //                        {
        //                            if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)
        //                            {
        //                                productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Company;  //在庫区分：自社
        //                            }
        //                            else if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
        //                            {
        //                                productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
        //                            }
        //                        }
        //                    }
        //                    else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
        //                    {
        //                        productStockWork.StockDiv = (int)ConstantManagement_Mobile.ct_StockDiv.Trust;  //在庫区分：受託
        //                    }
        //                    //●在庫状態
        //                    // add 2007.06.26 saito
        //                    //if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                    //    wkSalesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return)
        //                    //{
        //                    //    productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    //}
        //                    //else if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                    //         wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
        //                    //{
        //                    //    productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
        //                    //}

        //                    //●在庫状態
        //                    //売上伝票更新
        //                    if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                        wkSalesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                        wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                        wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //在庫
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
        //                    }
        //                    //受託伝票更新
        //                    else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                             wkSalesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Purchase &&
        //                             wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                             wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //受託中
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
        //                    }
        //                    //赤伝票更新(売上)
        //                    else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                             wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
        //                             wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //返品
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    }
        //                    //赤伝票更新(受託)
        //                    else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                             wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
        //                             wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //返品
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    }
        //                    //返品伝票更新(売上)
        //                    else if (wkSalesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return &&
        //                             wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black)// && 
        //                    //wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //                    {
        //                        //返品
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.ReturnedGoods;
        //                    }
        //                    //受託計上伝票更新(通常)
        //                    else if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
        //                             (wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
        //                              wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
        //                    {
        //                        //在庫
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.SupplierStock;
        //                    }
        //                    //受託計上伝票更新(赤伝)
        //                    else if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red &&
        //                             (wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
        //                             wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
        //                    {
        //                        //受託中
        //                        productStockWork.StockState = (int)ConstantManagement_Mobile.ct_StockState.Entrusting;
        //                    }

        //                    if (wkStockExplaDataWork.StockUpdDiscDiv == 1)
        //                    {
        //                        productStockWork.StockDiv = cmnStockDiv;
        //                        productStockWork.StockState = cmnStockState;
        //                    }

        //                    //売上明細　→　製番在庫マスタ
        //                    productStockWork.MakerCode = wkAddUppOrgSalesDetailWork.MakerCode;     //メーカーコード
        //                    productStockWork.MakerName = wkAddUppOrgSalesDetailWork.MakerName;     //メーカー名称
        //                    productStockWork.GoodsCode = wkAddUppOrgSalesDetailWork.GoodsCode;     //商品コード
        //                    productStockWork.GoodsName = wkAddUppOrgSalesDetailWork.GoodsName;     //商品名称
        //                    productStockWork.StockUnitPrice = wkAddUppOrgSalesDetailWork.StockUnitPrice;     //売上単価

        //                    productStockWork.TaxationCode = wkAddUppOrgSalesDetailWork.TaxationCode;       //課税区分
        //                    productStockWork.CarrierCode = wkAddUppOrgSalesDetailWork.CarrierCode;         //キャリアコード
        //                    productStockWork.CarrierName = wkAddUppOrgSalesDetailWork.CarrierName;         //キャリア名称
        //                    productStockWork.SystematicColorCd = wkAddUppOrgSalesDetailWork.SystematicColorCd;     //系統色コード
        //                    productStockWork.SystematicColorNm = wkAddUppOrgSalesDetailWork.SystematicColorNm;     //系統色名称
        //                    productStockWork.LargeGoodsGanreCode = wkAddUppOrgSalesDetailWork.LargeGoodsGanreCode; //商品大分類コード
        //                    productStockWork.MediumGoodsGanreCode = wkAddUppOrgSalesDetailWork.MediumGoodsGanreCode;   //商品中分類コード
        //                    productStockWork.WarehouseCode = wkAddUppOrgSalesDetailWork.WarehouseCode;       //倉庫コード
        //                    productStockWork.WarehouseName = wkAddUppOrgSalesDetailWork.WarehouseName;       //倉庫名称
        //                    productStockWork.CellphoneModelCode = wkAddUppOrgSalesDetailWork.CellphoneModelCode;     //機種コード
        //                    productStockWork.CellphoneModelName = wkAddUppOrgSalesDetailWork.CellphoneModelName;     //機種名称

        //                    //製番在庫マスタ出力ArrayListに追加
        //                    productStockWorkList.Add(productStockWork);
        //                }
        //            }
        //        }
        //    }
        //    #endregion

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        # endregion

        #endregion

        #region [売上計上日チェック]
        /*
        /// <summary>
        /// 売上計上済み在庫の売上計上日をチェックする
        /// </summary>
        /// <param name="salesSlipWork">売上データ</param>
        /// <param name="productStockCommonPara">製番在庫共通パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上計上済み在庫の売上計上日をチェックする</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.07.24</br>
        private int CheckSalesAddUpDate(StockSlipWork salesSlipWork, ProductStockCommonPara productStockCommonPara, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaProductStockGuid = sqlCommand.Parameters.Add("@FINDPRODUCTSTOCKGUID", SqlDbType.UniqueIdentifier);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(productStockCommonPara.EnterpriseCode);
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
                                if (addUpADate >= salesSlipWork.StockAddUpADate)
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                else
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
                            else if (productStockCommonPara.StockState == (int)ConstantManagement_Mobile.ct_StockState.Consigning)
                            {
                                if (shipmentDay >= salesSlipWork.StockAddUpADate)
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
                status = base.WriteSQLErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDateにてSQL例外発生。MSG=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDateにて例外発生。MSG=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        */

        /*
        /// <summary>
        /// 返品済み在庫の売上計上日をチェックする
        /// </summary>
        /// <param name="salesSlipWork">売上データ</param>
        /// <param name="productStockCommonPara">製番在庫共通パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品済み在庫の売上計上日をチェックする</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.07.25</br>
        private int CheckReturnDate(StockSlipWork salesSlipWork, ProductStockCommonPara productStockCommonPara, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaProductStockGuid = sqlCommand.Parameters.Add("@FINDPRODUCTSTOCKGUID", SqlDbType.UniqueIdentifier);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(productStockCommonPara.EnterpriseCode);
                    findParaProductStockGuid.Value = SqlDataMediator.SqlSetGuid(productStockCommonPara.ProductStockGuid);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            DateTime stockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                            DateTime arrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));

                            if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                            {
                                if (stockDate >= salesSlipWork.StockDate)
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                else
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
                            else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                            {
                                if (arrivalGoodsDay >= salesSlipWork.ArrivalGoodsDay)
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
                status = base.WriteSQLErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDateにてSQL例外発生。MSG=" + ex.Message, 0);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDateにて例外発生。MSG=" + ex.Message, 0);
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
        /// <param name="paraList">売上伝票読込パラメータ</param>
        /// <param name="retList">売上伝票読込結果</param>
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

            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。読込対象オブジェクトパラメータが未指定です");
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                    return status;
                }

                //●売上更新オブジェクトの取得(カスタムArray内から検索)
                if (retList != null)
                {
                    status = this.ReadProductCommon(origin, ref paraList, ref retList, position, param, ref freeParam, ref sqlConnection, ref sqlTransaction);
                }

            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBStockUpdateDB.Read:" + ex.Message);  //DEL 2008/06/06 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //-- ADD 2008/06/06 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //-- ADD 2008/06/06 M.Kubota ---<<<
            }

            return status;
        }

        /// <summary>
        /// 製番在庫を読み込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">売上伝票読込パラメータ</param>
        /// <param name="retList">売上伝票読込結果</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 製番在庫を読み込みます</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.02.14</br>
        private int ReadProductCommon(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 売上明細データクラス格納用
            SalesSlipWork salesSlipWork = null;
            SalesDetailWork salesDetailWork = null;
            ArrayList salesDetailWorkList = null;

            // 在庫データクラス格納用List
            ArrayList stockWorkParaList = new ArrayList();

            try
            {
                //●売上更新オブジェクトの取得(カスタムArray内から検索)
                if (retList.Count > 0)
                {
                    // 売上データを取得
                    foreach (object item in retList)
                    {
                        salesSlipWork = item as SalesSlipWork;

                        if (salesSlipWork != null)
                        {
                            break;
                        }
                    }
                    
                    for (int i = 0; i < retList.Count; i++)
                    {
                        if (retList[i] is ArrayList && ((ArrayList)retList[i]).Count > 0 && ((ArrayList)retList[i])[0] is SalesDetailWork)
                        {
                            salesDetailWorkList = retList[i] as ArrayList;

                            for (int x = 0; x < salesDetailWorkList.Count; x++)
                            {
                                // 在庫データクラス格納用
                                StockWork stockWork = new StockWork();

                                //売上明細データクラス生成
                                salesDetailWork = salesDetailWorkList[x] as SalesDetailWork;

                                stockWork.EnterpriseCode = salesDetailWork.EnterpriseCode;  // 企業コード

                                //--- DEL 2008/06/06 M.Kubota --->>>
                                //if (salesSlipWork != null)
                                //{
                                //    stockWork.SectionCode = salesSlipWork.StockUpdateSecCd;  // 在庫更新拠点コード(正常)
                                //}
                                //else
                                //{
                                //    stockWork.SectionCode = salesDetailWork.SectionCode;     // 拠点コード(有り得ないが…)
                                //}
                                //--- DEL 2008/06/06 M.Kubota ---<<<

                                stockWork.GoodsMakerCd = salesDetailWork.GoodsMakerCd;      // 商品メーカーコード
                                stockWork.GoodsNo = salesDetailWork.GoodsNo;                // 商品番号
                                stockWork.WarehouseCode = salesDetailWork.WarehouseCode;    // 倉庫コード
                                stockWorkParaList.Add(stockWork);
                            }
                        }
                    }

                    // 在庫データ読込
                    if (stockWorkParaList.Count > 0)
                    {
                        paraList.Add(stockWorkParaList);

                        CustomSerializeArrayList tempRetList = new CustomSerializeArrayList();
                        status = stockDB.Read(origin, ref paraList, ref tempRetList, position, param, ref freeParam, ref sqlConnection);

                        if (tempRetList.Count > 0 && tempRetList[0] is ArrayList && (tempRetList[0] as ArrayList).Count > 0)
                        {
                            retList.AddRange(tempRetList);
                        }

                        for (int i = 0; i < paraList.Count; i++)
                        {
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
                //base.WriteErrorLog(ex, "IOWriteMAHNBStockUpdateDB.Read:" + ex.Message);  //DEL 2008/06/06 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //--- ADD 2008/06/06 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                //--- ADD 2008/06/06 M.Kubota ---<<<
            }

            return status;
        }
        #endregion

        #region[Write]
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
                    //secinfoSetWorkHash.Add(sec.SectionCode, sec.SectionGuideNm);          //DEL 2009/01/13 M.Kubota
                    secinfoSetWorkHash.Add(sec.SectionCode.TrimEnd(), sec.SectionGuideNm);  //ADD 2009/01/13 M.Kubota
                }
            }

            return status;
        }
        
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
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int oldPosition = -1;

            //売上データクラス格納用(新・旧)
            SalesSlipWork salesSlipWork = null;
            SalesSlipWork oldSalesSlipWork = null;

            //売上明細データクラスList格納用(新・旧)　※在庫パラメータを売上明細単位で作成するため
            ArrayList salesDetailWorkList = null;
            //ArrayList oldSalesDetailWorkList = null;  //DEL 2009/01/30 M.Kubota

            //旧在庫パラメータ格納List(在庫・製番)
            ArrayList oldStockWorkList = new ArrayList();

            //新在庫パラメータ格納List(在庫・製番・受払・受払明細)
            ArrayList stockWorkList = new ArrayList();
            ArrayList stockAcPayHistWorkList = new ArrayList();

            //在庫パラメータ差分抽出格納用(在庫・受払明細)
            ArrayList stockUpdateWorkList = new ArrayList();
            ArrayList stockAcPayHistWorkUpdateList = new ArrayList();

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/06/06 M.Kubota

            try
            {
                # region [パラメーターチェック]
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.WriteInitial:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象オブジェクトパラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.WriteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":データベース接続情報パラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●売上更新オブジェクトの取得(カスタムArray内から検索)
                if (list == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.WriteInitial:プログラムエラー。更新対象パラメータListが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象パラメータListが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }
                else if (list.Count > 0) salesSlipWork = list[position] as SalesSlipWork;
                if (salesSlipWork == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.WriteInitial:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象オブジェクトパラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }
                # endregion

                //●STATUS初期化
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //●既存売上伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (originList[i] is SalesSlipWork &&
                            (originList[i] as SalesSlipWork).SalesSlipCd == salesSlipWork.SalesSlipCd)
                        {
                            oldSalesSlipWork = originList[i] as SalesSlipWork;
                            oldPosition = i;
                        }
                    }
                }

                //●売上商品区分　消費税調整・残高調整　の場合は更新しない
                if (salesSlipWork.SalesGoodsCd != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }

                if (oldSalesSlipWork != null)
                {
                    if (oldSalesSlipWork.SalesGoodsCd != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                }

                //●企業コードに紐付く拠点コード・名称の一覧を取得する
                // --- DEL 2013/05/08 T.Nishi ----->>>>>
                //status = this.GetSecInfoSetWork(salesSlipWork.EnterpriseCode, out this._secInfoSeTtable, ref sqlConnection, ref sqlTransaction);
                // --- DEL 2013/05/08 T.Nishi -----<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●更新パラメータ取得
                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫マスタ・在庫受払履歴データ更新パラメータ取得
                        //if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is SalesDetailWork)  //DEL 2009/01/30 M.Kubota
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && (((ArrayList)list[i])[0]).GetType() == typeof(SalesDetailWork))  //ADD 2009/01/30 M.Kubota  計上元明細と分ける為 厳密な型チェックを行う
                        {
                            salesDetailWorkList = list[i] as ArrayList;
                            // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                            ////status = MakeStockAndStockAcPayHist(list, out stockWorkList, out stockAcPayHistWorkList, position, i, 0 /* 0:更新 */);
                            //status = MakeStockAndStockAcPayHist(originList, list, out stockWorkList, out stockAcPayHistWorkList, position, i, 0 /* 0:更新 */);
                            status = MakeStockAndStockAcPayHist(originList, list, out stockWorkList, out stockAcPayHistWorkList, position, i, 0 /* 0:更新 */, ref sqlConnection, ref sqlTransaction);
                            // --- UPD 2013/06/07 Y.Wakita -----<<<<<
                        }
                    }
                }

                #region 在庫引当処理（返品時・受託計上時）add 2007.06.12
                //引当した製番在庫GUIDを売上詳細に挿入する
                /*
                if (productStockWorkList.Count > 0)
                {
                    if ((salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                         salesSlipWork.SupplierSlipCd == (int)ConstantManagement_Mobile.ct_SupplierSlipCd.Return) ||
                        (salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                         salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy))
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
                                if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                                {
                                    stockCount = stockWork.SupplierStock; //一時的に格納
                                    stockWork.SupplierStock = (double)checkCount; //引当数を格納
                                }
                                else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
                                {
                                    stockCount = stockWork.TrustCount;
                                    stockWork.TrustCount = (double)checkCount;
                                }

                                //在庫リモート呼出
                                status = stockDB.SearchProductStockForDrawingProc(out productStockReturnCheckList, stockWork, 0, 0, ref sqlConnection, ref sqlTransaction, out retMsg);

                                if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase)
                                {
                                    stockWork.SupplierStock = stockCount; //返品数を元に戻す
                                }
                                else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust)
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
                                                //売上詳細データの製造番号GUIDも置き換える
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

                # region [仮削除 (MakeReturnStockPara の機能は MakeStockAndStockAcPayHist に実装済み)]
                // add 2007.06.07 saito
                //●返品用在庫マスタ、製番在庫マスタパラメータの作成
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    if ((salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black &&
                //         salesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return))
                //    {
                //        for (int i = 0; i < list.Count; i++)
                //        {
                //            if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is SalesDetailWork)
                //            {
                //                stockWorkList = null;
                //                //返品在庫マスタパラメータ作成
                //                status = this.MakeReturnStockPara(list, out stockWorkList, null, position, i);
                //            }
                //        }
                //    }
                //}
                // add 2007.06.07 saito
                # endregion

                //●listに追加
                if (stockWorkList.Count > 0)
                {
                    if (oldSalesSlipWork == null)
                    {
                        list.Add(stockWorkList);
                    }
                    else if (oldSalesSlipWork != null && oldSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack)
                    {
                        list.Add(stockWorkList);
                    }
                }

                if (stockAcPayHistWorkList.Count > 0)
                {
                    if (oldSalesSlipWork == null)
                    {
                        list.Add(stockAcPayHistWorkList);
                    }
                    else if (oldSalesSlipWork != null && oldSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack)
                    {
                        list.Add(stockAcPayHistWorkList);
                    }
                }
                
                //●既に売上伝票が存在する場合削除パラメータ取得
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (oldSalesSlipWork != null)
                    {
                        //元黒伝の場合は赤伝の発行なので既存売上伝票のチェックは必要なし
                        if (oldSalesSlipWork.DebitNoteDiv != (int)ConstantManagement_Mobile.ct_DebitNoteDiv.OriginalBlack)
                        {
                            # region [--- DEL 2009/01/30 M.Kubota ---]
                            //for (int x = 0; x < originList.Count; x++)
                            //{
                            //    //●旧在庫マスタ更新パラメータ取得
                            //    if (originList[x] is ArrayList && ((ArrayList)originList[x]).Count > 0 && ((ArrayList)originList[x])[0] is SalesDetailWork)
                            //    {
                            //        oldSalesDetailWorkList = originList[x] as ArrayList;
                            //        //status = MakeStockWork(originList, out oldSalesWorkList, oldPosition, x, 0 /* 0:更新 */);
                            //    }
                            //    //在庫受払履歴・明細データは修正不可(必ず新規登録:INSERT)
                            //}
                            # endregion

                            //チェック機能追加
                            //●在庫マスタ売上数差分抽出
                            # region [--- DEL 見難いので削除 ---]
                            ////if (oldSalesSlipWork.TrustAddUpSpCd == 0)
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //{
                            //   //売上明細データから在庫マスタ売上数差分を抽出する
                            //   //status = this.MakeSalesDetailWorkAdd(salesSlipWork, salesDetailWorkList, originList, out stockUpdateWorkList);
                            //    status = this.MakeSalesDetailWorkAdd(salesSlipWork, salesDetailWorkList, originList, out stockUpdateWorkList, out stockAcPayHistWorkUpdateList);
                            //}
                            ////else if (oldSalesSlipWork.TrustAddUpSpCd == 1 || oldSalesSlipWork.TrustAddUpSpCd == 2)
                            ////{
                            ////status = this.MakeTrustStockDetailWorkAdd(oldSalesSlipWork, oldSalesDetailWorkList, salesDetailWorkList, out stockUpdateWorkList);
                            ////status = MakeTrustAddStockWork(oldSalesWorkList, stockWorkParaList, out stockUpdateWorkList); //del 2007.06.09 saito
                            ////}
                            # endregion

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //売上明細データから在庫マスタ売上数差分を抽出する
                                // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                                ////status = this.MakeSalesDetailWorkAdd(salesSlipWork, salesDetailWorkList, originList, out stockUpdateWorkList, out stockAcPayHistWorkUpdateList);  //DEL 2009/01/30 M.Kubota
                                //status = this.MakeSalesDetailWorkAdd(salesSlipWork, salesDetailWorkList, originList, list, out stockUpdateWorkList, out stockAcPayHistWorkUpdateList);  //ADD 2009/01/30 M.Kubota
                                status = this.MakeSalesDetailWorkAdd(salesSlipWork, salesDetailWorkList, originList, list, out stockUpdateWorkList, out stockAcPayHistWorkUpdateList, ref sqlConnection, ref sqlTransaction);
                                // --- UPD 2013/06/07 Y.Wakita -----<<<<<
                            }

                            if (stockUpdateWorkList.Count > 0) list.Add(stockUpdateWorkList);
                            if (stockAcPayHistWorkUpdateList.Count > 0) list.Add(stockAcPayHistWorkUpdateList);
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
                    status = stockDB.WriteInitial(origin, ref originList, ref list, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
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

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHistWork)
                                list.RemoveAt(i);
                        }
                        
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBStockUpdateDB.WriteInitial:" + ex.Message);  //DEL 2008/06/06 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/06/06 M.Kubota
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
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //売上データクラス格納用(新・旧)
            SalesSlipWork stockSlipWork = null;
            SalesSlipWork oldStockSlipWork = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/06/06 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.Write:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象オブジェクトパラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.Write:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":データベース接続情報パラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●在庫更新オブジェクトの取得(カスタムArray内から検索)
                if (list == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.Write:プログラムエラー。更新対象パラメータListが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象パラメータListが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }
                else if (list.Count > 0) stockSlipWork = list[position] as SalesSlipWork;

                if (stockSlipWork == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.Write:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象オブジェクトパラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●戻り値を正常で初期化
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //入荷即返品未対応(処理しない)

                //●既存売上伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (oldStockSlipWork == null)
                        {
                            if (originList[i] is SalesSlipWork)
                            {
                                oldStockSlipWork = originList[i] as SalesSlipWork;
                            }
                        }
                    }
                }

                //●売上商品区分　商品以外は更新しない
                if (stockSlipWork.SalesGoodsCd != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }

                if (oldStockSlipWork != null)
                {
                    if (oldStockSlipWork.SalesGoodsCd != 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                }

                // --- ADD 2015/04/08 y.wakita ----->>>>>
                // 更新用リスト再設定処理
                status = this.ReMakeStockAndStockAcPayHist(ref list, ref sqlConnection, ref sqlTransaction);
                // --- ADD 2015/04/08 y.wakita -----<<<<<

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
                    status = stockDB.Write(origin, ref originList, ref list, position, "", ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    /*--- UI側に更新後の在庫データを返すように変更
                    //パラメータを削除
                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫マスタ更新パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockWork)
                        {
                            list.RemoveAt(i);
                        }
                    }
                    */

                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫受払履歴データ更新パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHistWork)
                        {
                            list.RemoveAt(i);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBStockUpdateDB.Write:" + ex.Message);  //DEL 2008/06/06 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/06/06 M.Kubota
            }

            return status;
        }
        #endregion

        // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
        #region オプション有無確認処理
        /// オプション有無確認処理
        /// </summary>
        /// <param name="softwareCode">コード</param>
        /// <returns>true:有り,false:無し</returns>
        /// <br>Note       : 指定のソフトウェアコードのオプションが存在するかどうかを確認します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2015/09/17</br>		
        private bool CheckSoftwarePurchased(string softwareCode)
        {
            bool exists = false;
            ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
            if ((int)loginInfo.SoftwarePurchasedCheckForUSB(softwareCode) > 0) exists = true;
            return exists;
        }
        #endregion
        // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<

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
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Note       : 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信エラー対応。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2015/09/17</br>	
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int oldSalesSlip_Position = -1;

            //売上ヘッダクラス格納用
            SalesSlipWork oldSalesSlipWork = null;

            //在庫系削除パラメータ格納List
            ArrayList oldSalesWorkList = new ArrayList();
            ArrayList oldSalesAcPayHistWorkList = new ArrayList();

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/06/06 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.DeleteInitial:プログラムエラー。更新対象オブジェクトパラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":更新対象オブジェクトパラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.DeleteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":データベース接続情報パラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<

                    return status;
                }

                //●削除売上伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (oldSalesSlipWork == null)
                        {
                            if (originList[i] is SalesSlipWork)
                            {
                                oldSalesSlipWork = originList[i] as SalesSlipWork;
                                oldSalesSlip_Position = i;
                                break;
                            }
                        }
                    }
                }

                if (oldSalesSlipWork == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.DeleteInitial:プログラムエラー。売上データ削除パラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":売上データ削除パラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                // --- ADD 2013/06/07 Y.Wakita ----->>>>>
                //●STATUS初期化
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // --- ADD 2013/06/07 Y.Wakita -----<<<<<

                //●企業コードに紐付く拠点コード・名称の一覧を取得する
                // --- DEL 2013/05/08 T.Nishi ----->>>>>
                //status = this.GetSecInfoSetWork(oldSalesSlipWork.EnterpriseCode, out this._secInfoSeTtable, ref sqlConnection, ref sqlTransaction);
                // --- DEL 2013/05/08 T.Nishi -----<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●削除パラメータ取得
                    for (int i = 0; i < originList.Count; i++)
                    {
                        //●在庫マスタ・在庫受払履歴データ削除パラメータ取得
                        if (originList[i] is ArrayList && ((ArrayList)originList[i]).Count > 0 && ((ArrayList)originList[i])[0] is SalesDetailWork)
                        {
                            SalesSlipDeleteWork slsDelWrk = ListUtils.Find(list, typeof(SalesSlipDeleteWork), ListUtils.FindType.Class) as SalesSlipDeleteWork;
                            SalesDetailWork slsDtlWrk = (originList[i] as ArrayList)[0] as SalesDetailWork;

                            if (slsDelWrk != null && slsDtlWrk != null &&
                                slsDelWrk.EnterpriseCode == slsDtlWrk.EnterpriseCode &&
                                slsDelWrk.AcptAnOdrStatus == slsDtlWrk.AcptAnOdrStatus &&
                                slsDelWrk.SalesSlipNum == slsDtlWrk.SalesSlipNum)
                            {

                                // --- ADD K2014/06/12 Y.Wakita ----->>>>>
                                // DEL BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
                                //// ●明細追加情報データ格納リスト
                                //List<SlipDetailAddInfoWork> slpDtlAddInfList = new List<SlipDetailAddInfoWork>();

                                //ArrayList workList = null;
                                //workList = ListUtils.Find(list, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                                //if (ListUtils.IsNotEmpty(workList))
                                //{
                                //    originList.Add(workList);
                                //    for (int index = 0; index < ((ArrayList)originList[i]).Count; index++)
                                //    {
                                //        if ((((ArrayList)originList[i])[index] is SalesDetailWork) &&
                                //            (((ArrayList)list[i])[index] is SalesDetailWork))
                                //        {
                                //            SalesDetailWork slsDtlWrkF = (list[i] as ArrayList)[index] as SalesDetailWork;          // INパラメータ
                                //            SalesDetailWork slsDtlWrkT = (originList[i] as ArrayList)[index] as SalesDetailWork;    // 削除パラメータ
                                //            slsDtlWrkT.DtlRelationGuid = slsDtlWrkF.DtlRelationGuid;    // 共通キー
                                //        }
                                //    }
                                //}
                                // DEL BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<
                                // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
                                if (this.CheckSoftwarePurchased(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl))
                                {
                                    // ●明細追加情報データ格納リスト
                                    List<SlipDetailAddInfoWork> slpDtlAddInfList = new List<SlipDetailAddInfoWork>();

                                    ArrayList workList = null;
                                    workList = ListUtils.Find(list, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                                    if (ListUtils.IsNotEmpty(workList))
                                    {
                                        originList.Add(workList);
                                        for (int index = 0; index < ((ArrayList)originList[i]).Count; index++)
                                        {
                                            if ((((ArrayList)originList[i])[index] is SalesDetailWork) &&
                                                (((ArrayList)list[i])[index] is SalesDetailWork))
                                            {
                                                SalesDetailWork slsDtlWrkF = (list[i] as ArrayList)[index] as SalesDetailWork;          // INパラメータ
                                                SalesDetailWork slsDtlWrkT = (originList[i] as ArrayList)[index] as SalesDetailWork;    // 削除パラメータ
                                                slsDtlWrkT.DtlRelationGuid = slsDtlWrkF.DtlRelationGuid;    // 共通キー
                                            }
                                        }
                                    }
                                }
                                // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<
                                // --- ADD K2014/06/12 Y.Wakita -----<<<<<

                                // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                                //status = MakeStockAndStockAcPayHist(originList, originList, out oldSalesWorkList, out oldSalesAcPayHistWorkList, oldSalesSlip_Position, i, 1 /* 1:削除 */);
                                status = MakeStockAndStockAcPayHist(originList, originList, out oldSalesWorkList, out oldSalesAcPayHistWorkList, oldSalesSlip_Position, i, 1 /* 1:削除 */, ref sqlConnection, ref sqlTransaction);
                                // --- UPD 2013/06/07 Y.Wakita -----<<<<<

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //●listに追加
                                    if (oldSalesWorkList.Count > 0)
                                    {
                                        list.Add(oldSalesWorkList);
                                    }

                                    if (oldSalesAcPayHistWorkList.Count > 0)
                                    {
                                        list.Add(oldSalesAcPayHistWorkList);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBStockUpdateDB.DeleteInitial:" + ex.Message);  //DEL 2008/06/06 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/06/06 M.Kubota
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
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int oldSalesSlip_Position = -1;

            //売上ヘッダクラス格納用
            SalesSlipWork oldSalesSlipWork = null;

            //在庫系パラメータ格納List
            ArrayList oldSalesWorkList = new ArrayList();

            CustomSerializeArrayList workArray = new CustomSerializeArrayList();

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/06/06 M.Kubota

            try
            {
                //●更新対象クラス位置チェック
                if (position < 0)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.Delete:プログラムエラー。削除対象オブジェクトパラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":削除対象オブジェクトパラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteMAHNBStockUpdateDB.Delete:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/06/06 M.Kubota
                    //--- ADD 2008/06/06 M.Kubota --->>>
                    errmsg += ":データベース接続情報パラメータが未指定です";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    return status;
                }

                //●既存売上伝票オブジェクトの取得(カスタムArray内から検索)
                if (originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (oldSalesSlipWork == null)
                        {
                            if (originList[i] is SalesSlipWork)
                            {
                                oldSalesSlipWork = originList[i] as SalesSlipWork;
                                oldSalesSlip_Position = i;
                                break;
                            }
                        }
                    }
                }

                //●売上商品区分　商品以外は更新しない
                if (oldSalesSlipWork != null)
                {
                    if (oldSalesSlipWork.SalesGoodsCd != 0)
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
                    status = stockDB.Write(origin, ref originList, ref list, position, ""/*構成ﾌｧｲﾙﾊﾟﾗﾒｰﾀ無し*/, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //パラメータを削除
                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫マスタ削除パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockWork)
                        {
                            list.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        //在庫受払履歴データ削除パラメータ削除
                        if (list[i] is ArrayList && ((ArrayList)list[i]).Count > 0 && ((ArrayList)list[i])[0] is StockAcPayHistWork)
                        {
                            list.RemoveAt(i);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBStockUpdateDB.Delete:" + ex.Message);  //DEL 2008/06/06 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/06/06 M.Kubota
            }

            return status;
        }
        #endregion

        # region [パラメータ取得処理]
        /// <summary>
        /// 在庫マスタ・在庫受払履歴データ更新データクラス生成
        /// </summary>
        /// <param name="originList">更新前パラメータリスト</param>
        /// <param name="paraList">更新対象パラメータリスト</param>
        /// <param name="stockList">在庫マスタ更新パラメータ</param>
        /// <param name="stockAcPayHistList">在庫受払履歴データ更新パラメータ</param>
        /// <param name="position">売上データ格納位置</param>
        /// <param name="detailPosition">売上明細データ格納位置</param>
        /// <param name="mode">0:加算 1:減算</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信エラー対応。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2015/09/17</br>
        //private int MakeStockAndStockAcPayHist(CustomSerializeArrayList paraList, out ArrayList stockList, out ArrayList stockAcPayHistList, Int32 position, Int32 detailPosition, Int32 mode)
        //private int MakeStockAndStockAcPayHist(CustomSerializeArrayList originList, CustomSerializeArrayList paraList, out ArrayList stockList, out ArrayList stockAcPayHistList, Int32 position, Int32 detailPosition, Int32 mode)   // DEL 2013/06/07 Y.Wakita
        private int MakeStockAndStockAcPayHist(CustomSerializeArrayList originList, CustomSerializeArrayList paraList, out ArrayList stockList, out ArrayList stockAcPayHistList, Int32 position, Int32 detailPosition, Int32 mode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) // ADD 2013/06/07 Y.Wakita
        {
            //出力パラメータList(在庫・受払)
            stockList = new ArrayList();
            stockAcPayHistList = new ArrayList();

            //更新パラメータクラス格納用(在庫・受払)
            StockWork stockWork = null;
            StockAcPayHistWork stockAcPayHistWork = null;

            //売上データワーク格納用(ヘッダ・明細)
            SalesSlipWork wkSalesSlipWork = paraList[position] as SalesSlipWork;
            SalesDetailWork wkSalesDetailWork = null;
            ArrayList wkSalesDetailWorkList = paraList[detailPosition] as ArrayList;

            # region [--- DEL 2009/01/30 M.Kubota ---]
            //元伝票データワーク格納用(ヘッダ・明細)
            //SalesSlipWork orgSalesSlipWork;
            //ArrayList orgSalesDetailWorkList;
            # endregion
            SalesDetailWork orgSalesDetailWork = null;

            //--- ADD 2009/01/30 M.Kubota --->>>
            ArrayList workList = null;

            // ●変更元明細データ格納リスト
            List<SalesDetailWork> orgDtlList = new List<SalesDetailWork>();

            workList = ListUtils.Find(originList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                orgDtlList.AddRange((SalesDetailWork[])workList.ToArray(typeof(SalesDetailWork)));
            }

            // ●明細追加情報データ格納リスト
            List<SlipDetailAddInfoWork> slpDtlAddInfList = new List<SlipDetailAddInfoWork>();

            workList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                slpDtlAddInfList.AddRange((SlipDetailAddInfoWork[])workList.ToArray(typeof(SlipDetailAddInfoWork)));
            }

            // ●計上元明細データ格納リスト
            List<AddUpOrgSalesDetailWork> addUpOrgDtlList = new List<AddUpOrgSalesDetailWork>();

            workList = ListUtils.Find(paraList, typeof(AddUpOrgSalesDetailWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                addUpOrgDtlList.AddRange((AddUpOrgSalesDetailWork[])workList.ToArray(typeof(AddUpOrgSalesDetailWork)));
            }
            //--- ADD 2009/01/30 M.Kubota ---<<<

            # region [--- DEL 2009/01/30 M.Kubota ---]
            //this.FindOriginalSalesSlip(out orgSalesSlipWork, out orgSalesDetailWorkList, originList, wkSalesSlipWork);

            ////明細セレクタ生成
            //SalesDetailsSelector detailsSelector = new SalesDetailsSelector(orgSalesDetailWorkList);
            # endregion

            # region [---DEL 2009/01/22 M.Kubota --- 使って無いので削除]
            //データ比較クラス(在庫・受払)
            //StockWorkCountComparer stockWorkComparer = new StockWorkCountComparer();
            //StockAcPayHistWorkComparer stockAcPayHistWorkComparer = new StockAcPayHistWorkComparer();
            # endregion

            //●更新パラメータ格納処理
            for (int i = 0; i < wkSalesDetailWorkList.Count; i++)
            {
                wkSalesDetailWork = wkSalesDetailWorkList[i] as SalesDetailWork;

                // 在庫更新対象の明細のみ処理対象とする
                if (!wkSalesDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/06 M.Kubota

                // -- ADD 2010/03/18 ----------------------------->>>
                //計上残残さないで、一部計上した場合の、計上元伝票の削除対応
                if ((mode == 1) && (wkSalesDetailWork.AcptAnOdrRemainCnt <= 0)
                    && ((wkSalesDetailWork.AcptAnOdrStatus == 10) || (wkSalesDetailWork.AcptAnOdrStatus == 20) || (wkSalesDetailWork.AcptAnOdrStatus == 40)))
                {
                    // --- ADD 2013/04/04 Y.Wakita ----->>>>>
                    // 返品の場合、continueしない
                    if (!(wkSalesDetailWork.SalesSlipCdDtl == 1))
                    // --- ADD 2013/04/04 Y.Wakita -----<<<<<
                        continue;
                }
                // -- ADD 2010/03/18 -----------------------------<<<

                // 対応する元伝票明細を取得
                //orgSalesDetailWork = detailsSelector.Find(wkSalesDetailWork);  //DEL 2009/01/30 M.Kubota

                //--- ADD 2009/01/30 M.Kubota --->>>
                orgSalesDetailWork = orgDtlList.Find(delegate(SalesDetailWork orgDtl)
                {
                    if (wkSalesSlipWork.DebitNoteDiv == 1 && mode == 0)
                    {
                        // 赤伝の新規登録の場合は orgDtlList に元黒の明細データが格納されているが
                        // 赤伝の削除の場合は orgDtlList には削除前の赤伝の明細が格納されている為
                        // 処理を分ける
                        return orgDtl.AcptAnOdrStatus == wkSalesDetailWork.AcptAnOdrStatusSrc &&
                               orgDtl.SalesSlipDtlNum == wkSalesDetailWork.SalesSlipDtlNumSrc;


                    }
                    else
                    {
                        return orgDtl.AcptAnOdrStatus == wkSalesDetailWork.AcptAnOdrStatus &&
                               orgDtl.SalesSlipDtlNum == wkSalesDetailWork.SalesSlipDtlNum;
                    }
                });
                //--- ADD 2009/01/30 M.Kubota ---<<<

                stockWork = new StockWork();
                stockAcPayHistWork = new StockAcPayHistWork();

                # region --- DEL 2008/06/06 M.Kubota ---
                //在庫管理有無区分・売上在庫取寄せ区分・出荷数のチェック
                //--- DEL 2008/06/06 M.Kubota --->>>
                //if (wkSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                //    (wkSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && wkSalesDetailWork.SalesOrderDivCd == 0) ||
                //    wkSalesDetailWork.ShipmentCnt == 0) continue;
                //--- DEL 2008/06/06 M.Kubota ---<<<
                # endregion

                #region[在庫マスタ更新パラメータ格納]
                //--------------------------------------------------------------------------------------------------
                //●在庫マスタ更新パラメータ格納    Start
                //--------------------------------------------------------------------------------------------------
                //在庫マスタ ← 売上ヘッダ
                stockWork.EnterpriseCode = wkSalesSlipWork.EnterpriseCode;                // 企業コード
                //stockWork.SectionCode = wkSalesSlipWork.StockUpdateSecCd;               // 在庫更新拠点コード  //DEL 2008/06/06 M.Kubota
                stockWork.SectionCode = wkSalesSlipWork.SectionCode;                      // 拠点コード          //ADD 2008/06/06 M.Kubota
                stockWork.LastSalesDate = wkSalesSlipWork.SalesDate;                      // 最終売上年月日

                //在庫マスタ ← 売上明細
                stockWork.GoodsMakerCd = wkSalesDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                stockWork.GoodsNo = wkSalesDetailWork.GoodsNo;                            // 商品番号
                # region [--- DEL 2008/06/06 M.Kubota ---]
                //stockWork.GoodsName = wkSalesDetailWork.GoodsName;                        // 商品名称
                //stockWork.GoodsShortName = wkSalesDetailWork.GoodsShortName;              // 商品名略称
                //stockWork.LargeGoodsGanreCode = wkSalesDetailWork.LargeGoodsGanreCode;    // 商品区分グループコード
                //stockWork.LargeGoodsGanreName = wkSalesDetailWork.LargeGoodsGanreName;    // 商品区分グループ名称
                //stockWork.MediumGoodsGanreCode = wkSalesDetailWork.MediumGoodsGanreCode;  // 商品区分コード
                //stockWork.MediumGoodsGanreName = wkSalesDetailWork.MediumGoodsGanreName;  // 商品区分名称
                //stockWork.DetailGoodsGanreCode = wkSalesDetailWork.DetailGoodsGanreCode;  // 商品区分詳細コード
                //stockWork.DetailGoodsGanreName = wkSalesDetailWork.DetailGoodsGanreName;  // 商品区分詳細名称
                //stockWork.BLGoodsCode = wkSalesDetailWork.BLGoodsCode;                    // BL商品コード
                //stockWork.BLGoodsFullName = wkSalesDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)
                //stockWork.EnterpriseGanreCode = wkSalesDetailWork.EnterpriseGanreCode;    // 自社分類コード
                //stockWork.EnterpriseGanreName = wkSalesDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)
                //stockWork.WarehouseName = wkSalesDetailWork.WarehouseName;                // 倉庫名称
                # endregion
                stockWork.WarehouseCode = wkSalesDetailWork.WarehouseCode;                // 倉庫コード
                stockWork.WarehouseShelfNo = wkSalesDetailWork.WarehouseShelfNo;          // 倉庫棚番

                // --- UPD 2014/05/01 T.Miyamoto 仕掛一覧№2257 ------------------------------>>>>>
                // 残数を使用するように修正
                //double ShipmCntDifference = wkSalesDetailWork.ShipmCntDifference;
                double ShipmCntDifference = wkSalesDetailWork.AcptAnOdrRemainCnt;
                // --- UPD 2014/05/01 T.Miyamoto 仕掛一覧№2257 ------------------------------<<<<<

                # region [DELETE]
                //double ShipmCntDifference = Math.Abs(wkSalesDetailWork.ShipmCntDifference);

                //double ShipmCntDifference = 0;

                //// 返品や赤伝の場合は差分数の絶対値を使用する
                //if (wkSalesSlipWork.DebitNoteDiv == 1 || wkSalesSlipWork.SalesSlipCd == 1)
                //{
                //    ShipmCntDifference = Math.Abs(wkSalesDetailWork.ShipmCntDifference);
                //}
                //else
                //{
                //    ShipmCntDifference = wkSalesDetailWork.ShipmCntDifference;
                //}
                # endregion

                ShipmCntDifference *= ((mode == 0) ? 1 : -1);                             // 加算・減算
                //ShipmCntDifference *= ((wkSalesSlipWork.DebitNoteDiv == 1) ? -1 : 1);   // 黒伝・赤伝
                //ShipmCntDifference *= ((wkSalesSlipWork.SalesSlipCd == 1) ? -1 : 1);    // 売上・返品

                //this.ReflectShipmCntDifference(ref stockWork, wkSalesSlipWork, wkSalesDetailWork, orgSalesDetailWork, ShipmCntDifference);  //DEL 2009/01/30 M.Kubota

                //--- ADD 2009/01/30 M.Kubota --->>>
                ReflectCntDifData refCntDifDat = new ReflectCntDifData(wkSalesSlipWork, wkSalesDetailWork, null, orgSalesDetailWork, null, ShipmCntDifference, 0, mode);
                
                // 明細追加情報を検索し、計上残区分を取得する
                refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                // --- ADD K2014/06/12 Y.Wakita ----->>>>>
                // DEL BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
                //if (refCntDifDat.AddInfo != null)
                //{
                //    // 在庫更新有無区分がON（true）の場合、在庫更新を行わない
                //    if (refCntDifDat.AddInfo.ZaiUpdFlg) continue;
                //}
                // DEL BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<
                // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
                if (this.CheckSoftwarePurchased(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl))
                {
                    if (refCntDifDat.AddInfo != null)
                    {
                        // 在庫更新有無区分がON（true）の場合、在庫更新を行わない
                        if (refCntDifDat.AddInfo.ZaiUpdFlg) continue;
                    }
                }
                // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<
                // --- ADD K2014/06/12 Y.Wakita -----<<<<<

                // 計上元明細データを検索する
                refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgSalesDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                // 計上残区分を設定する
                refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                // --- ADD K2014/06/12 Y.Wakita ----->>>>>
                // DEL BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
                //if (refCntDifDat.AddInfo != null)
                //{
                //    // 計上残区分（フタバ個別）がON（true）の場合、「残す」に設定
                //    if (refCntDifDat.AddInfo.AddUpRemFlg)
                //        refCntDifDat.AddUpRemDiv = 0;
                //}
                // DEL BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<
                // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する---->>>>>
                if (this.CheckSoftwarePurchased(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl))
                {
                    if (refCntDifDat.AddInfo != null)
                    {
                        // 計上残区分（フタバ個別）がON（true）の場合、「残す」に設定
                        if (refCntDifDat.AddInfo.AddUpRemFlg)
                            refCntDifDat.AddUpRemDiv = 0;
                    }
                }
                // ADD BY 宋剛 2015/09/17 FOR 47400 紀泉商会/拠点管理処理調査（仕掛2785）、データ受信時にエラーが発生する----<<<<<
                // --- ADD K2014/06/12 Y.Wakita -----<<<<<

                this.ReflectShipmCntDifference(ref stockWork, refCntDifDat);
                //--- ADD 2009/01/30 M.Kubota ---<<<

                # region [削除]
                //switch (wkSalesSlipWork.AcptAnOdrStatus)
                //{
                //    case 20:  // 受注
                //        {
                //            // 受注数量に受注差分数(出荷差分数)を加算する
                //            stockWork.AcpOdrCount += ShipmCntDifference;
                //            break;
                //        }
                //    case 30:  // 売上
                //        {
                //            // 売上の場合 仕入在庫数から売上差分数(出荷差分数)を減算する
                //            stockWork.SupplierStock -= ShipmCntDifference;

                //            // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
                //            switch (wkSalesDetailWork.AcptAnOdrStatusSrc)
                //            {
                //                case 20:
                //                    {
                //                        // 受注計上
                //                        stockWork.AcpOdrCount -= ShipmCntDifference;
                //                        break;
                //                    }
                //                case 40:
                //                    {
                //                        // 出荷計上
                //                        stockWork.ShipmentCnt -= ShipmCntDifference;
                //                        break;
                //                    }
                //            }
                //            break;
                //        }
                //    case 40:  // 出荷
                //        {
                //            // 出荷数に出荷差分数を加算する
                //            stockWork.ShipmentCnt += ShipmCntDifference;
                //            break;
                //        }
                //}
                # endregion

                stockList.Add(stockWork);
                //--------------------------------------------------------------------------------------------------
                //●在庫マスタ更新パラメータ格納    End
                //--------------------------------------------------------------------------------------------------
                #endregion

                #region[在庫受払履歴データ更新パラメータ格納]
                //--------------------------------------------------------------------------------------------------
                //●在庫受払履歴データ更新パラメータ格納    Start
                //--------------------------------------------------------------------------------------------------
                
                // 30:売上　40:出荷(貸出) のみ在庫受払履歴データを作成・更新する
                if (wkSalesSlipWork.AcptAnOdrStatus == 30 || wkSalesSlipWork.AcptAnOdrStatus == 40)
                {
                    //--- ADD 2009/01/22 M.Kubota --->>>
                    if (refCntDifDat.Slip.DebitNoteDiv == 1)
                    {
                        // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                        //// -- UPD 2009/12/28 ----------------------->>>
                        ////this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.OrgDetail, mode, ref stockAcPayHistWork);
                        //this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.OrgDetail, mode, ref stockAcPayHistWork, refCntDifDat);
                        //// -- UPD 2009/12/28 -----------------------<<<
                        this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.OrgDetail, mode, ref stockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                        // --- UPD 2013/06/07 Y.Wakita -----<<<<<
                    }
                    else
                    {
                        // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                        //// -- UPD 2009/12/28 ----------------------->>>
                        ////this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, mode, ref stockAcPayHistWork);
                        //this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, mode, ref stockAcPayHistWork, refCntDifDat);
                        //// -- UPD 2009/12/28 -----------------------<<<
                        this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, mode, ref stockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                        // --- UPD 2013/06/07 Y.Wakita -----<<<<<
                    }
                    
                    stockAcPayHistWork.ShipmentCnt = ShipmCntDifference;  // 出荷数(差分を設定)  ※不要か？
                    //--- ADD 2009/01/22 M.Kubota ---<<<

                    # region [--- DEL 2009/01/22 M.Kubota --- 修正範囲が大きいので全削除]
                    # if false
                    //在庫受払履歴データ ← 売上ヘッダ
                    stockAcPayHistWork.EnterpriseCode = wkSalesSlipWork.EnterpriseCode;   //企業コード                    

                    //stockAcPayHistWork.ValidDivCd = 0;  //有効区分(0:有効 1:無効)  //DEL 2008/03/03 M.Kubota

                    # region [--- DEL 2008/06/06 M.Kubota ---]
                    //--- ADD 2008/03/03 M.Kubota --->>>
                    //加算・減算のモードに応じて有効区分(0:有効 1:無効)を設定する
                    //stockAcPayHistWork.ValidDivCd = (mode == 0) ? 0 : 1;
                    //--- ADD 2008/03/03 M.Kubota ---<<<
                    # endregion

                    // 受注ステータスによって設定値が異なる項目
                    switch (wkSalesSlipWork.AcptAnOdrStatus)
                    {
                        case 30:  // 売上
                            {
                                # region [--- DEL 2008/03/12 M.Kubota ---]
                                //if (wkSalesDetailWork.AcptAnOdrStatusSrc == 0 || wkSalesDetailWork.AcptAnOdrStatusSrc == 10 ||
                                //    (wkSalesDetailWork.SalesSlipCdDtl == 1 && orgSalesDetailWork == null) ||
                                //    (wkSalesDetailWork.SalesSlipCdDtl == 1 && orgSalesDetailWork != null && (orgSalesDetailWork.AcptAnOdrStatusSrc == 0 || orgSalesDetailWork.AcptAnOdrStatusSrc == 10)) ||
                                //    (wkSalesSlipWork.DebitNoteDiv == 1 && orgSalesDetailWork != null && (orgSalesDetailWork.AcptAnOdrStatusSrc == 0 || orgSalesDetailWork.AcptAnOdrStatusSrc == 10)))
                                //{
                                //    // 非計上(見積引当含む)及び返品、赤伝の売上伝票の場合
                                //    stockAcPayHistWork.IoGoodsDay = wkSalesSlipWork.ShipmentDay;  //入出荷日 ← 出荷日
                                //}
                                //else
                                //{
                                //    // 計上売上伝票の場合
                                //    stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;            //入出荷日 ← 未設定(最小値)
                                //}
                                # endregion
                                
                                if ( wkSalesDetailWork.AcptAnOdrStatusSrc == 40 ||                                                                            // 出荷引当した売上
                                    (wkSalesDetailWork.SalesSlipCdDtl == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40) ||  // 出荷引当した売上の返品
                                    (wkSalesSlipWork.DebitNoteDiv == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40))        // 出荷引当した売上の赤伝
                                {
                                    // 入荷引当売上伝票の場合
                                    stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;            //入出荷日 ← 未設定(最小値)
                                }
                                else
                                {
                                    // 入荷引当されていない売上伝票の場合
                                    stockAcPayHistWork.IoGoodsDay = wkSalesSlipWork.ShipmentDay;  //入出荷日 ← 出荷日
                                }
                                
                                stockAcPayHistWork.AddUpADate = wkSalesSlipWork.SalesDate;        //計上日付 ← 売上日
                                stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Sales;  //受払元伝票区分
                                break;
                            }
                        case 40:  // 出荷
                            {
                                stockAcPayHistWork.IoGoodsDay = wkSalesSlipWork.ShipmentDay;      //入出荷日 ← 出荷日
                                stockAcPayHistWork.AddUpADate = DateTime.MinValue;                //計上日付 ← 未設定(最小値)
                                stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Consignment;  //受払元伝票区分
                                break;
                            }
                    }

                    stockAcPayHistWork.AcPaySlipNum = wkSalesSlipWork.SalesSlipNum;      //受払元伝票番号
                    stockAcPayHistWork.AcPaySlipRowNo = wkSalesDetailWork.SalesRowNo;    //受払元行番号
                    stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;           //受払履歴作成日時

                    // 受払元取引区分
                    # region [--- DEL 2009/01/15 M.Kubota ---]
                    //if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
                    //{
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;  // 返品
                    //}
                    //else if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                    //{
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;        // 赤伝
                    //}
                    //else
                    //{
                    //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;     // 通常伝票
                    //}
                    # endregion
                    //--- ADD 2009/01/15 M.Kubota --->>>
                    if (mode == 0)
                    {
                        //返品伝票更新
                        if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
                        {
                            //返品
                            stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;
                        }
                        else if (wkSalesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
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
                        //伝票削除
                        stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;
                    }
                    //--- ADD 2009/01/15 M.Kubota ---<<<

                    stockAcPayHistWork.InputSectionCd = wkSalesSlipWork.SalesInpSecCd;  //入力拠点コード
                    
                    // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                    //object objSecNm = this._secInfoSeTtable[wkSalesSlipWork.SalesInpSecCd];          //DEL 2009/01/13 M.Kubota
                    object objSecNm = this._secInfoSeTtable[wkSalesSlipWork.SalesInpSecCd.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                    //入力拠点ガイド名称
                    if (objSecNm is string)
                    {
                        stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    
                    stockAcPayHistWork.InputAgenCd = wkSalesSlipWork.SalesInputCode;         // 入力担当者コード　←　売上入力者コード
                    stockAcPayHistWork.InputAgenNm = wkSalesSlipWork.SalesInputName;         // 入力担当者名称　←　売上入力者名称
                    stockAcPayHistWork.CustSlipNo = wkSalesSlipWork.PartySaleSlipNum;        // 相手先伝票番号
                    stockAcPayHistWork.SlipDtlNum = wkSalesDetailWork.SalesSlipDtlNum;       // 明細通番
                    stockAcPayHistWork.AcPayNote = wkSalesDetailWork.DtlNote;                // 受払備考
                    stockAcPayHistWork.GoodsMakerCd = wkSalesDetailWork.GoodsMakerCd;        // 商品メーカーコード
                    stockAcPayHistWork.MakerName = wkSalesDetailWork.MakerName;              // メーカー名称
                    stockAcPayHistWork.GoodsNo = wkSalesDetailWork.GoodsNo;                  // 商品番号
                    stockAcPayHistWork.GoodsName = wkSalesDetailWork.GoodsName;              // 商品名称
                    stockAcPayHistWork.BLGoodsCode = wkSalesDetailWork.BLGoodsCode;          // BL商品コード
                    stockAcPayHistWork.BLGoodsFullName = wkSalesDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                    //stockAcPayHistWork.SectionCode = wkSalesSlipWork.StockUpdateSecCd;     // 拠点コード ← 在庫更新拠点コード  //DEL 2008/06/06 M.Kubota
                    stockAcPayHistWork.SectionCode = wkSalesSlipWork.SectionCode;            // 拠点コード

                    // 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                    //objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode];          //DEL 2009/01/13 M.Kubota
                    objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                    //入力拠点ガイド名称
                    if (objSecNm is string)
                    {
                        stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }

                    # region [--- DEL 2008/03/03 M.Kubota ---]
                    //stockAcPayHistWork.BfEnterWarehCode = wkSalesDetailWork.WarehouseCode;   // 倉庫コード
                    //stockAcPayHistWork.BfEnterWarehName = wkSalesDetailWork.WarehouseName;   // 倉庫名称
                    //stockAcPayHistWork.BfShelfNo = wkSalesDetailWork.WarehouseShelfNo;       // 倉庫棚番
                    # endregion

                    //--- ADD 2008/03/03 M.Kubota --->>>
                    stockAcPayHistWork.WarehouseCode = wkSalesDetailWork.WarehouseCode;   // 倉庫コード
                    stockAcPayHistWork.WarehouseName = wkSalesDetailWork.WarehouseName;   // 倉庫名称
                    stockAcPayHistWork.ShelfNo = wkSalesDetailWork.WarehouseShelfNo;      // 棚番
                    //--- ADD 2008/03/03 M.Kubota ---<<<

                    stockAcPayHistWork.CustomerCode = wkSalesSlipWork.CustomerCode;          // 得意先コード
                    //stockAcPayHistWork.CustomerName = wkSalesSlipWork.CustomerName;        // 得意先名称
                    //stockAcPayHistWork.CustomerName2 = wkSalesSlipWork.CustomerName2;      // 得意先名称2
                    stockAcPayHistWork.CustomerSnm = wkSalesSlipWork.CustomerSnm;            // 得意先略称
                    stockAcPayHistWork.ArrivalCnt = 0;                                       // 入荷数
                    stockAcPayHistWork.ShipmentCnt = ShipmCntDifference;                     // 出荷数(差分を設定)

                    stockAcPayHistWork.OpenPriceDiv = wkSalesDetailWork.OpenPriceDiv;              // オープン価格区分
                    stockAcPayHistWork.ListPriceTaxExcFl = wkSalesDetailWork.ListPriceTaxExcFl;    // 定価(税抜,浮動)
                    stockAcPayHistWork.StockUnitPriceFl = wkSalesDetailWork.SalesUnitCost;         // 仕入単価(税抜,浮動) ← 原価単価
                    stockAcPayHistWork.StockPrice = wkSalesDetailWork.Cost;                        // 仕入金額 ← 原価金額
                    stockAcPayHistWork.SalesUnPrcTaxExcFl = wkSalesDetailWork.SalesUnPrcTaxExcFl;  // 売上単価(税抜,浮動)
                    stockAcPayHistWork.SalesMoney = wkSalesDetailWork.SalesMoneyTaxExc;            // 売上金額

                    # region [--- DEL 2009/01/16 M.Kubota ---]
                    //int indexCount = 0;

                    ////在庫受払履歴パラメータListにデータがある時
                    //# region --- DEL 2008/06/06 M.Kubota ---
                    ////if (stockAcPayHistList.Count > 0)
                    ////{
                    ////    stockAcPayHistList.Sort(stockAcPayHistWorkComparer);

                    ////    indexCount = stockAcPayHistList.BinarySearch(0, stockAcPayHistList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                    ////    if (indexCount >= 0 && indexCount <= wkSalesDetailWorkList.Count)
                    ////    {
                    ////        StockAcPayHistWork oldItem = stockAcPayHistList[indexCount] as StockAcPayHistWork;

                    ////        if (oldItem.GoodsMakerCd == wkSalesDetailWork.GoodsMakerCd && oldItem.GoodsNo == wkSalesDetailWork.GoodsNo)
                    ////        {
                    ////            stockAcPayHistWork.ShipmentCnt += oldItem.ShipmentCnt;

                    ////        }
                    ////    }
                    ////    else
                    ////    {
                    ////        stockAcPayHistWork.ShipmentCnt = wkSalesDetailWork.ShipmentCnt;  // 出荷数
                    ////        stockAcPayHistList.Add(stockAcPayHistWork);
                    ////    }
                    ////}
                    ////else
                    ////{
                    ////    stockAcPayHistWork.ShipmentCnt = wkSalesDetailWork.ShipmentCnt;  // 出荷数
                    ////    stockAcPayHistList.Add(stockAcPayHistWork);
                    ////}
                    //# endregion

                    ////--- ADD 2008/06/06 M.Kubota --->>>
                    //stockAcPayHistList.Sort(stockAcPayHistWorkComparer);

                    //indexCount = stockAcPayHistList.BinarySearch(stockAcPayHistWork, stockAcPayHistWorkComparer);

                    //if (indexCount >= 0)
                    //{
                    //    StockAcPayHistWork oldItem = stockAcPayHistList[indexCount] as StockAcPayHistWork;
                    //    oldItem.ShipmentCnt += ShipmCntDifference;
                    //}
                    //else
                    //{
                    //    stockAcPayHistWork.ShipmentCnt = ShipmCntDifference;
                    //    stockAcPayHistList.Add(stockAcPayHistWork);
                    //}
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                    # endregion
                    # endif
                    # endregion
                    stockAcPayHistList.Add(stockAcPayHistWork);

                    //--- ADD 2009/01/30 M.Kubota --->>>
                    // 貸出計上伝票の場合で、且つ貸出計上残区分が"残さない"設定になっている場合
                    // 貸出数を相殺する受払履歴データを追加作成する。
                    // --- UPD m.suzuki 2011/04/21 ---------->>>>>
                    //if (mode == 0 && refCntDifDat.Detail.AcptAnOdrStatus == 30 && refCntDifDat.Detail.AcptAnOdrStatusSrc == 40 && refCntDifDat.AddUpRemDiv == 1)
                    if ( mode == 0 && refCntDifDat.Detail.AcptAnOdrStatus == 30 && refCntDifDat.Detail.AcptAnOdrStatusSrc == 40 && refCntDifDat.AddUpRemDiv == 1 &&
                         refCntDifDat.AddUpOrgDetail != null && refCntDifDat.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0 )
                    // --- UPD m.suzuki 2011/04/21 ----------<<<<<
                    {
                        StockAcPayHistWork counterStockAcPayHistWork = new StockAcPayHistWork();
                        SalesDetailWork counterDtlWork = refCntDifDat.AddUpOrgDetail.Clone();

                        counterDtlWork.ShipmentCnt = refCntDifDat.Detail.ShipmentCnt - refCntDifDat.AddUpOrgDetail.ShipmentCnt;                 // 出荷数   (差分)

                        // 2009/03/26 >>>>>>>>>>>>>>>>>>>>>>
                        //差分の数量が０以外の場合のみ相殺レコードを作成するように修正
                        if (counterDtlWork.ShipmentCnt != 0)
                        {
                        // 2009/03/26 <<<<<<<<<<<<<<<<<<<<<<
                            counterDtlWork.Cost = refCntDifDat.Detail.Cost - refCntDifDat.AddUpOrgDetail.Cost;                                      // 原価金額 (差分)
                            counterDtlWork.SalesMoneyTaxExc = refCntDifDat.Detail.SalesMoneyTaxExc - refCntDifDat.AddUpOrgDetail.SalesMoneyTaxExc;  // 売上金額 (差分)

                            // 売上データは"売上"で、売上明細データは"貸出(計上元)"の差分値
                            // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                            //// -- UPD 2009/12/28 -------------------------->>>
                            ////this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, counterDtlWork, null, 0, ref counterStockAcPayHistWork);
                            //this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, counterDtlWork, null, 0, ref counterStockAcPayHistWork, refCntDifDat);
                            //// -- UPD 2009/12/28 --------------------------<<<
                            this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, counterDtlWork, null, 0, ref counterStockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                            // --- UPD 2013/06/07 Y.Wakita -----<<<<<

                            counterStockAcPayHistWork.AddUpADate = counterStockAcPayHistWork.IoGoodsDay;                                            // 計上日付 ← 入出荷日
                            counterStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;                  // 受払元取引区分(返品)

                            stockAcPayHistList.Add(counterStockAcPayHistWork);

                        }  // ADD 2009/03/26
                    }
                    //--- ADD 2009/01/30 M.Kubota ---<<<
                }
                //--------------------------------------------------------------------------------------------------
                //●在庫受払履歴データ更新パラメータ格納    End
                //--------------------------------------------------------------------------------------------------
                #endregion
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
      
        /// <summary>
        /// 売上伝票修正時の在庫マスタ更新パラメータ作成
        /// </summary>
        /// <param name="salesSlipWork">登録対象の売上データ</param>
        /// <param name="salesDetailWorkList">登録対象の売上明細データリスト</param>
        /// <param name="originList">変更前の売上データが格納されているリスト</param>
        /// <param name="paraList">登録対象の売上データが格納されているリスト</param>
        /// <param name="stockWorkUpdateList">在庫データのリスト</param>
        /// <param name="stockAcPayHistWorkUpdateList">在庫受払履歴データのリスト</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票修正時の在庫マスタ更新パラメータ作成</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        //private int MakeSalesDetailWorkAdd(SalesSlipWork salesSlipWork, ArrayList oldSalesDetailWorkList, ArrayList salesDetailWorkList, out ArrayList stockWorkUpdateList)
        //private int MakeSalesDetailWorkAdd(SalesSlipWork salesSlipWork, ArrayList salesDetailWorkList, CustomSerializeArrayList originList, out ArrayList stockWorkUpdateList)
        //private int MakeSalesDetailWorkAdd(SalesSlipWork salesSlipWork, ArrayList salesDetailWorkList, CustomSerializeArrayList originList, out ArrayList stockWorkUpdateList, out ArrayList stockAcPayHistWorkUpdateList)  //DEL 2009/01/30 M.Kubota
        //private int MakeSalesDetailWorkAdd(SalesSlipWork salesSlipWork, ArrayList salesDetailWorkList, CustomSerializeArrayList originList, CustomSerializeArrayList paraList, out ArrayList stockWorkUpdateList, out ArrayList stockAcPayHistWorkUpdateList)  //ADD 2009/01/30 M.Kubota DEL 2013/06/07 Y.Wakita
        private int MakeSalesDetailWorkAdd(SalesSlipWork salesSlipWork, ArrayList salesDetailWorkList, CustomSerializeArrayList originList, CustomSerializeArrayList paraList, out ArrayList stockWorkUpdateList, out ArrayList stockAcPayHistWorkUpdateList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2013/06/07 Y.Wakita
        {
            stockWorkUpdateList = new ArrayList();
            stockAcPayHistWorkUpdateList = new ArrayList();

            //更新パラメータ格納用(在庫)
            StockWork oldStockWork = null;
            StockWork stockWork = null;
            StockAcPayHistWork stockAcPayHistWork = null;
            StockAcPayHistWork counterStockAcPayHistWork = null;  //ADD 2009/01/22 M.Kubota
            ReflectCntDifData refCntDifDat = null;  //ADD 2009/01/30 M.Kubota

            //売上明細データ格納用
            SalesDetailWork salesDetailWork = null;
            SalesDetailWork oldSalesDetailWork = null;

            # region [--- DEL 2009/01/30 M.Kubota ---]
            // 変更前売上データ
            //SalesSlipWork oldSalesSlipWork;
            //ArrayList oldSalesDetailWorkList;
            
            // 作成元売上データ
            //SalesSlipWork orgSalesSlipWork;
            //ArrayList orgSalesDetailWorkList;
            # endregion

            //--- ADD 2009/01/30 M.Kubota --->>>
            // 変更前売上データ
            SalesSlipWork oldSalesSlipWork = ListUtils.Find(originList, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
            ArrayList oldSalesDetailWorkList = ListUtils.Find(originList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;
            
            ArrayList workList = null;

            // ●明細追加情報データ格納リスト
            List<SlipDetailAddInfoWork> slpDtlAddInfList = new List<SlipDetailAddInfoWork>();

            workList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                slpDtlAddInfList.AddRange((SlipDetailAddInfoWork[])workList.ToArray(typeof(SlipDetailAddInfoWork)));
            }

            // ●計上元明細データ格納リスト
            List<AddUpOrgSalesDetailWork> addUpOrgDtlList = new List<AddUpOrgSalesDetailWork>();

            workList = ListUtils.Find(paraList, typeof(AddUpOrgSalesDetailWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(workList))
            {
                addUpOrgDtlList.AddRange((AddUpOrgSalesDetailWork[])workList.ToArray(typeof(AddUpOrgSalesDetailWork)));
            }
            //--- ADD 2009/01/30 M.Kubota ---<<<

            # region [--- DEL 2009/01/30 M.Kubota ---]
            //FindOldAndOriginSalesSlip(out oldSalesSlipWork, out oldSalesDetailWorkList, out orgSalesSlipWork, out orgSalesDetailWorkList, originList, salesSlipWork);
            
            //// 明細セレクタ生成
            //SalesDetailsSelector detailsSelector = new SalesDetailsSelector(orgSalesDetailWorkList);

            //// 明細セレクタで取得した作成元伝票の明細１レコード
            //SalesDetailWork orgSalesDetailWork;
            # endregion

            //該当データなしフラグ
            bool flg;

            StockAcPayHistWorkComparer stockAcPayHistWorkComparer = new StockAcPayHistWorkComparer();  //ADD 2008/03/13 M.Kubota

            // 旧明細をベースに、新明細と突き合わせる事で、更新された明細及び削除された明細についてのデータセットを作成する

            //●在庫数の差分計算(追加データはそのまま)
            for (int i = 0; i < oldSalesDetailWorkList.Count; i++)
            {
                oldSalesDetailWork = oldSalesDetailWorkList[i] as SalesDetailWork;

                flg = false;

                for (int x = 0; x < salesDetailWorkList.Count; x++)
                {
                    salesDetailWork = salesDetailWorkList[x] as SalesDetailWork;

                    # region [--- DEL 2009/01/22 M.Kubota ---]
                    //// 行№.拠点.倉庫.ﾒｰｶｰ.商品番号が一致するなら変更とみなす
                    //if (oldSalesDetailWork.SalesRowNo == salesDetailWork.SalesRowNo &&
                    //    oldSalesDetailWork.SectionCode.TrimEnd() == salesDetailWork.SectionCode.TrimEnd() &&
                    //    oldSalesDetailWork.WarehouseCode.TrimEnd() == salesDetailWork.WarehouseCode.TrimEnd() &&
                    //    oldSalesDetailWork.GoodsMakerCd == salesDetailWork.GoodsMakerCd &&
                    //    oldSalesDetailWork.GoodsNo.TrimEnd() == salesDetailWork.GoodsNo.TrimEnd() &&
                    //    oldSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNum)
                    # endregion
                    //--- ADD 2009/01/22 M.Kubota --->>>
                    // 倉庫・メーカー・品番・明細通番が一致する場合は変更明細とみなす
                    if (oldSalesDetailWork.WarehouseCode.TrimEnd() == salesDetailWork.WarehouseCode.TrimEnd() &&
                        oldSalesDetailWork.GoodsMakerCd == salesDetailWork.GoodsMakerCd &&
                        oldSalesDetailWork.GoodsNo.TrimEnd() == salesDetailWork.GoodsNo.TrimEnd() &&
                        oldSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNum)
                    //--- ADD 2009/01/22 M.Kubota ---<<<
                    {
                        // 同一キーの行が有った時点で「更新」である事は決まるので、flg = true とする。
                        // もし非在庫ならば、この後で判定して迂回する。
                        flg = true;

                        # region [--- DEL 2009/01/30 M.Kubota ---]
                        // 作成元伝票の明細データ取得
                        //orgSalesDetailWork = detailsSelector.Find(salesDetailWork);
                        # endregion

                        # region [--- DEL 2008/06/06 M.Kubota ---]
                        //在庫管理有無区分・仕入数チェック
                        //if (salesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                        //    (salesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && salesDetailWork.SalesOrderDivCd == 0) ||
                        //    salesDetailWork.ShipmentCnt == 0) continue;
                        # endregion

                        if (!salesDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/06/ M.Kubota

                        //差分抽出
                        #region[在庫マスタ更新パラメータ格納]
                        stockWork = new StockWork();

                        //在庫管理有無区分・売上数チェック
                        //if (salesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage || salesDetailWork.StockCount == 0) continue;

                        //売上ヘッダ　→　在庫マスタ
                        stockWork.EnterpriseCode = salesSlipWork.EnterpriseCode;                //企業コード
                        //stockWork.SectionCode = salesSlipWork.StockUpdateSecCd;               //拠点コード  //DEL 2008/06/06 M.Kubota
                        stockWork.SectionCode = salesSlipWork.SectionCode;                      //拠点コード  //ADD 2008/06/06 M.Kubota
                        stockWork.LastSalesDate = salesSlipWork.SalesDate;                      //最終売上年月日　←　売上日

                        //売上明細　→　在庫マスタ
                        stockWork.GoodsMakerCd = salesDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                        stockWork.GoodsNo = salesDetailWork.GoodsNo;                            // 商品番号
                        # region [--- DEL 2008/06/06 M.Kubota ---]
                        //stockWork.MakerName = salesDetailWork.MakerName;                        // メーカー名称
                        //stockWork.GoodsName = salesDetailWork.GoodsName;                        // 商品名称
                        //stockWork.GoodsShortName = salesDetailWork.GoodsShortName;              // 商品名略称
                        //stockWork.LargeGoodsGanreCode = salesDetailWork.LargeGoodsGanreCode;    // 商品区分グループコード
                        //stockWork.LargeGoodsGanreName = salesDetailWork.LargeGoodsGanreName;    // 商品区分グループ名称
                        //stockWork.MediumGoodsGanreCode = salesDetailWork.MediumGoodsGanreCode;  // 商品区分コード
                        //stockWork.MediumGoodsGanreName = salesDetailWork.MediumGoodsGanreName;  // 商品区分名称
                        //stockWork.DetailGoodsGanreCode = salesDetailWork.DetailGoodsGanreCode;  // 商品区分詳細コード
                        //stockWork.DetailGoodsGanreName = salesDetailWork.DetailGoodsGanreName;  // 商品区分詳細名称
                        //stockWork.BLGoodsCode = salesDetailWork.BLGoodsCode;                    // BL商品コード
                        //stockWork.BLGoodsFullName = salesDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)
                        //stockWork.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode;    // 自社分類コード
                        //stockWork.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)
                        # endregion
                        stockWork.WarehouseCode = salesDetailWork.WarehouseCode;                // 倉庫コード
                        stockWork.WarehouseName = salesDetailWork.WarehouseName;                // 倉庫名称
                        stockWork.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo;          // 倉庫棚番
                        # region [DELETE]
                        //売上形式・受託計上売上区分にて分岐
                        //if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                        //    salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                        //{
                        //    stockWork.SupplierStock = salesDetailWork.StockCount - oldSalesDetailWork.StockCount; //売上在庫数　←　売上数
                        //}
                        //else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                        //         salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                        //{
                        //    stockWork.TrustCount = salesDetailWork.StockCount - oldSalesDetailWork.StockCount; //受託数　←　売上数
                        //}
                        //else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                        //         (salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                        //         salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                        //{
                        //    stockWork.SupplierStock = salesDetailWork.StockCount - oldSalesDetailWork.StockCount; //売上在庫数
                        //    stockWork.TrustCount = -(salesDetailWork.StockCount - oldSalesDetailWork.StockCount); //受託数
                        //}
                        # endregion

                        // 出荷差分数の算出
                        double shipmCntDifference = salesDetailWork.ShipmentCnt - oldSalesDetailWork.ShipmentCnt;

                        // 出荷数差分反映
                        //this.ReflectShipmCntDifference(ref stockWork, salesSlipWork, salesDetailWork, orgSalesDetailWork, shipmCntDifference);  //DEL 2009/01/30 M.Kubota

                        //--- ADD 2009/01/30 M.Kubota --->>>
                        refCntDifDat = new ReflectCntDifData(salesSlipWork, salesDetailWork, null, null, null, shipmCntDifference, 0, 0);
                        
                        // 明細追加情報を検索し、計上残区分を取得する
                        refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                        // 計上元明細データを検索する
                        refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgSalesDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                        // 計上残区分を設定する
                        refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                        this.ReflectShipmCntDifference(ref stockWork, refCntDifDat);
                        //--- ADD 2009/01/30 M.Kubota ---<<<

                        // add 2007.07.12 saito >>>>>>>>>>
                        //(新売上単価×新在庫数)－(旧売上単価×旧在庫数)
                        stockWork.StockTotalPrice = (long)((salesDetailWork.SalesUnPrcTaxExcFl * salesDetailWork.ShipmentCnt) - (oldSalesDetailWork.SalesUnPrcTaxExcFl * oldSalesDetailWork.ShipmentCnt));
                        // add 2007.07.12 saito <<<<<<<<<<

                        //差分抽出データ格納
                        stockWorkUpdateList.Add(stockWork);
                        #endregion

                        #region[在庫受払履歴データ更新パラメータ格納]
                        //--------------------------------------------------------------------------------------------------
                        //●在庫受払履歴データ更新パラメータ格納    Start
                        //--------------------------------------------------------------------------------------------------

                        // 30:売上　40:出荷 のみ在庫受払履歴データを作成・更新する
                        if (salesSlipWork.AcptAnOdrStatus == 30 || salesSlipWork.AcptAnOdrStatus == 40)
                        {
                            //int mode = 0;
                            stockAcPayHistWork = new StockAcPayHistWork();
                            counterStockAcPayHistWork = new StockAcPayHistWork();  //相殺用在庫受払履歴データ  //ADD 2009/01/22 M.Kubota

                            # region [--- DEL 2009/01/22 M.Kubota --- 修正範囲が大きいので全削除]
                            ////在庫受払履歴データ ← 売上ヘッダ
                            //stockAcPayHistWork.EnterpriseCode = salesSlipWork.EnterpriseCode;   //企業コード                    

                            ////stockAcPayHistWork.ValidDivCd = mode;  //DEL 2008/06/06 M.Kubota
                            
                            //// 受注ステータスによって設定値が異なる項目
                            //switch (salesSlipWork.AcptAnOdrStatus)
                            //{
                            //    case 30:  // 売上
                            //        {
                            //            if (salesDetailWork.AcptAnOdrStatusSrc == 40 ||                                                                            // 出荷引当した売上
                            //                (salesDetailWork.SalesSlipCdDtl == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40) ||  // 出荷引当した売上の返品
                            //                (salesSlipWork.DebitNoteDiv == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40))        // 出荷引当した売上の赤伝
                            //            {
                            //                // 入荷引当売上伝票の場合
                            //                stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                                       //入出荷日 ← 未設定(最小値)
                            //            }
                            //            else
                            //            {
                            //                // 入荷引当されていない売上伝票の場合
                            //                stockAcPayHistWork.IoGoodsDay = salesSlipWork.ShipmentDay;                               //入出荷日 ← 出荷日
                            //            }

                            //            stockAcPayHistWork.AddUpADate = salesSlipWork.SalesDate;                                     //計上日付 ← 売上日
                            //            stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Sales;        //受払元伝票区分
                            //            break;
                            //        }
                            //    case 40:  // 出荷
                            //        {
                            //            stockAcPayHistWork.IoGoodsDay = salesSlipWork.ShipmentDay;                                   //入出荷日 ← 出荷日
                            //            stockAcPayHistWork.AddUpADate = DateTime.MinValue;                                           //計上日付 ← 未設定(最小値)
                            //            stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Consignment;  //受払元伝票区分
                            //            break;
                            //        }
                            //}

                            //stockAcPayHistWork.AcPaySlipNum = salesSlipWork.SalesSlipNum;      //受払元伝票番号
                            //stockAcPayHistWork.AcPaySlipRowNo = salesDetailWork.SalesRowNo;    //受払元行番号
                            //stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;         //受払履歴作成日時

                            //// 受払元取引区分
                            //if (salesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
                            //{
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;  // 返品
                            //}
                            //else if (salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                            //{
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;        // 赤伝
                            //}
                            //else
                            //{
                            //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;     // 通常伝票
                            //}

                            //stockAcPayHistWork.InputSectionCd = salesSlipWork.SalesInpSecCd;  //入力拠点コード

                            //// 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                            ////object objSecNm = this._secInfoSeTtable[salesSlipWork.SalesInpSecCd];          //DEL 2009/01/13 M.Kubota
                            //object objSecNm = this._secInfoSeTtable[salesSlipWork.SalesInpSecCd.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                            ////入力拠点ガイド名称
                            //if (objSecNm is string)
                            //{
                            //    stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                            //}
                            //else
                            //{
                            //    stockAcPayHistWork.InputSectionGuidNm = "";
                            //}

                            //stockAcPayHistWork.InputAgenCd = salesSlipWork.SalesInputCode;         // 入力担当者コード　←　売上入力者コード
                            //stockAcPayHistWork.InputAgenNm = salesSlipWork.SalesInputName;         // 入力担当者名称  　←　売上入力者名称
                            //stockAcPayHistWork.CustSlipNo = salesSlipWork.PartySaleSlipNum;        // 相手先伝票番号
                            //stockAcPayHistWork.SlipDtlNum = salesDetailWork.SalesSlipDtlNum;       // 明細通番
                            //stockAcPayHistWork.AcPayNote = salesDetailWork.DtlNote;                // 受払備考
                            //stockAcPayHistWork.GoodsMakerCd = salesDetailWork.GoodsMakerCd;        // メーカーコード
                            //stockAcPayHistWork.MakerName = salesDetailWork.MakerName;              // メーカー名称
                            //stockAcPayHistWork.GoodsNo = salesDetailWork.GoodsNo;                  // 商品番号
                            //stockAcPayHistWork.GoodsName = salesDetailWork.GoodsName;              // 商品名称
                            //stockAcPayHistWork.BLGoodsCode = salesDetailWork.BLGoodsCode;          // BL商品コード
                            //stockAcPayHistWork.BLGoodsFullName = salesDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                            ////stockAcPayHistWork.SectionCode = salesSlipWork.StockUpdateSecCd;     // 拠点コード ← 在庫更新拠点コード  //DEL 2008/06/06 M.Kubota
                            //stockAcPayHistWork.SectionCode = salesSlipWork.SectionCode;            // 拠点コード                        //ADD 2008/06/06 M.Kubota

                            //// 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                            ////objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode];          //DEL 2009/01/13 M.Kubota
                            //objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                            ////入力拠点ガイド名称
                            //if (objSecNm is string)
                            //{
                            //    stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                            //}
                            //else
                            //{
                            //    stockAcPayHistWork.SectionGuideNm = "";
                            //}

                            //stockAcPayHistWork.WarehouseCode = salesDetailWork.WarehouseCode;   // 倉庫コード
                            //stockAcPayHistWork.WarehouseName = salesDetailWork.WarehouseName;   // 倉庫名称
                            //stockAcPayHistWork.ShelfNo = salesDetailWork.WarehouseShelfNo;      // 倉庫棚番
                            //stockAcPayHistWork.CustomerCode = salesSlipWork.CustomerCode;       // 得意先コード
                            ////stockAcPayHistWork.CustomerName = salesSlipWork.CustomerName;     // 得意先名称
                            ////stockAcPayHistWork.CustomerName2 = salesSlipWork.CustomerName2;   // 得意先名称2
                            //stockAcPayHistWork.CustomerSnm = salesSlipWork.CustomerSnm;         // 得意先略称
                            //stockAcPayHistWork.ArrivalCnt = 0;                                  // 入荷数

                            //stockAcPayHistWork.OpenPriceDiv = salesDetailWork.OpenPriceDiv;              // オープン価格区分
                            //stockAcPayHistWork.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl;    // 定価(税抜,浮動)
                            //stockAcPayHistWork.StockUnitPriceFl = salesDetailWork.SalesUnitCost;         // 仕入単価(税抜,浮動) ← 原価単価
                            //stockAcPayHistWork.StockPrice = salesDetailWork.Cost;                        // 仕入金額 ← 原価金額
                            //stockAcPayHistWork.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl;  // 売上単価(税抜,浮動)
                            //stockAcPayHistWork.SalesMoney = salesDetailWork.SalesMoneyTaxExc;            // 売上金額

                            //int indexCount = 0;

                            ////在庫受払履歴パラメータListにデータがある時
                            //if (stockAcPayHistWorkUpdateList.Count > 0)
                            //{
                            //    stockAcPayHistWorkUpdateList.Sort(stockAcPayHistWorkComparer);

                            //    indexCount = stockAcPayHistWorkUpdateList.BinarySearch(0, stockAcPayHistWorkUpdateList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                            //    if (indexCount >= 0 && indexCount <= salesDetailWorkList.Count)
                            //    {
                            //        StockAcPayHistWork oldItem = stockAcPayHistWorkUpdateList[indexCount] as StockAcPayHistWork;

                            //        if (oldItem.GoodsMakerCd == salesDetailWork.GoodsMakerCd && oldItem.GoodsNo == salesDetailWork.GoodsNo)
                            //        {
                            //            //stockAcPayHistWork.ShipmentCnt += oldItem.ShipmentCnt;
                            //            stockAcPayHistWork.ShipmentCnt += shipmCntDifference;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        //stockAcPayHistWork.ShipmentCnt = salesDetailWork.ShipmentCnt;  // 出荷数
                            //        stockAcPayHistWork.ShipmentCnt = shipmCntDifference;
                            //        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                            //    }
                            //}
                            //else
                            //{
                            //    //stockAcPayHistWork.ShipmentCnt = salesDetailWork.ShipmentCnt;  // 出荷数
                            //    stockAcPayHistWork.ShipmentCnt = shipmCntDifference;
                            //    stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                            //}
                            # endregion

                            //--- ADD 2009/01/22 M.Kubota --->>>
                            // 登録前 売上データを元に受払履歴データを作成
                            // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                            //// -- UPD 2009/12/28 -------------------------->>>
                            ////this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork);
                            //this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork, refCntDifDat);
                            //// -- UPD 2009/12/28 --------------------------<<<
                            this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                            // --- UPD 2013/06/07 Y.Wakita -----<<<<<
                            
                            // 登録済 売上データを元に受払履歴データを作成
                            // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                            //// -- UPD 2009/12/28 -------------------------->>>
                            ////this.SalesSlipToStockAcPayHist(oldSalesSlipWork, oldSalesDetailWork, refCntDifDat.AddUpOrgDetail, 0, ref counterStockAcPayHistWork);
                            //this.SalesSlipToStockAcPayHist(oldSalesSlipWork, oldSalesDetailWork, refCntDifDat.AddUpOrgDetail, 0, ref counterStockAcPayHistWork, refCntDifDat);
                            //// -- UPD 2009/12/28 --------------------------<<<
                            this.SalesSlipToStockAcPayHist(oldSalesSlipWork, oldSalesDetailWork, refCntDifDat.AddUpOrgDetail, 0, ref counterStockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                            // --- UPD 2013/06/07 Y.Wakita -----<<<<<

                            if (stockAcPayHistWork.IoGoodsDay != DateTime.MinValue)
                            {
                                counterStockAcPayHistWork.IoGoodsDay = oldSalesSlipWork.ShipmentDay;  // 入出荷日
                            }

                            // 変更前と変更後を比較する
                            int cmpRet = stockAcPayHistWorkComparer.Compare(stockAcPayHistWork, counterStockAcPayHistWork);

                            if (cmpRet != 0)
                            {
                                // 相殺データを追加
                                counterStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.Cancel;  // 取消

                                counterStockAcPayHistWork.ShipmentCnt = oldSalesDetailWork.ShipmentCnt * -1;      // 出荷数   (符号反転)
                                counterStockAcPayHistWork.StockPrice = oldSalesDetailWork.Cost * -1;              // 仕入金額 (符号反転)
                                counterStockAcPayHistWork.SalesMoney = oldSalesDetailWork.SalesMoneyTaxExc * -1;  // 売上金額 (符号反転)
                            }
                            else
                            {
                                counterStockAcPayHistWork = null;  // 相殺データは不要なので破棄する

                                if (stockAcPayHistWorkComparer.DifferenceUpdate)
                                {
                                    // 差分データ(出荷数・仕入金額・売上金額の差分)を追加

                                    // 仕入金額の差分算出
                                    long stcPriceDif = salesDetailWork.Cost - oldSalesDetailWork.Cost;

                                    // 売上金額の差分算出
                                    long slsMnyTaxExcDif = salesDetailWork.SalesMoneyTaxExc - oldSalesDetailWork.SalesMoneyTaxExc;

                                    stockAcPayHistWork.ShipmentCnt = shipmCntDifference;                              // 出荷数   (差分)
                                    stockAcPayHistWork.StockPrice = stcPriceDif;                                      // 仕入金額 (差分)
                                    stockAcPayHistWork.SalesMoney = slsMnyTaxExcDif;                                  // 売上金額 (差分)
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
                            //--- ADD 2009/01/22 M.Kubota ---<<<
                        }
                        //--------------------------------------------------------------------------------------------------
                        //●在庫受払履歴データ更新パラメータ格納    End
                        //--------------------------------------------------------------------------------------------------
                        #endregion

                        //flg = true;
                        break;
                    }
                }

                if (flg == false)
                {
                    // 旧・明細群から見て、新・明細群に該当するデータが存在しない場合は、その旧明細は削除された物をみなす
                    
                    //stockCount = 0;
                    //削除データを作成する
                    //差分抽出
                    //stockCount = -oldSalesDetailWork.StockCount; //売上数
                    #region[在庫マスタ削除パラメータ格納]

                    oldStockWork = new StockWork();

                    //在庫管理有無区分・売上数チェック
                    # region [--- DEL 2008/06/06 M.Kubota ---]
                    //if (oldSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage || salesDetailWork.StockCount == 0) continue;

                    //if (oldSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                    //    (oldSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && oldSalesDetailWork.SalesOrderDivCd == 0) ||
                    //    salesDetailWork.ShipmentCnt == 0) continue;
                    # endregion

                    if (!oldSalesDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/06 M.Kubota

                    //売上ヘッダ　→　在庫マスタ
                    oldStockWork.EnterpriseCode = salesSlipWork.EnterpriseCode;                   //企業コード
                    //oldStockWork.SectionCode = salesSlipWork.StockUpdateSecCd;                  //拠点コード    //DEL 2008/06/06 M.Kubota  
                    oldStockWork.SectionCode = salesSlipWork.SectionCode;                         //拠点コード    //ADD 2008/06/06 M.Kubota
                    oldStockWork.LastSalesDate = salesSlipWork.SalesDate;                         //最終売上年月日　←　売上日

                    //売上明細　→　在庫マスタ
                    oldStockWork.GoodsMakerCd = oldSalesDetailWork.GoodsMakerCd;                  // 商品メーカーコード
                    oldStockWork.GoodsNo = oldSalesDetailWork.GoodsNo;                            // 商品番号
                    # region [--- DEL 2008/06/06 M.Kubota ---]
                    //--- DEL 2008/06/06 M.Kubota --->>>
                    //oldStockWork.MakerName = oldSalesDetailWork.MakerName;                        // メーカー名称
                    //oldStockWork.GoodsName = oldSalesDetailWork.GoodsName;                        // 商品名称
                    //oldStockWork.GoodsShortName = oldSalesDetailWork.GoodsShortName;              // 商品名略称
                    //oldStockWork.LargeGoodsGanreCode = oldSalesDetailWork.LargeGoodsGanreCode;    // 商品区分グループコード
                    //oldStockWork.LargeGoodsGanreName = oldSalesDetailWork.LargeGoodsGanreName;    // 商品区分グループ名称
                    //oldStockWork.MediumGoodsGanreCode = oldSalesDetailWork.MediumGoodsGanreCode;  // 商品区分コード
                    //oldStockWork.MediumGoodsGanreName = oldSalesDetailWork.MediumGoodsGanreName;  // 商品区分名称
                    //oldStockWork.DetailGoodsGanreCode = oldSalesDetailWork.DetailGoodsGanreCode;  // 商品区分詳細コード
                    //oldStockWork.DetailGoodsGanreName = oldSalesDetailWork.DetailGoodsGanreName;  // 商品区分詳細名称
                    //oldStockWork.BLGoodsCode = oldSalesDetailWork.BLGoodsCode;                    // BL商品コード
                    //oldStockWork.BLGoodsFullName = oldSalesDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)
                    //oldStockWork.EnterpriseGanreCode = oldSalesDetailWork.EnterpriseGanreCode;    // 自社分類コード
                    //oldStockWork.EnterpriseGanreName = oldSalesDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)
                    //-- DEL 2008/06/06 M.Kubota ---<<<
                    # endregion
                    // 2009/03/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //在庫単価は棚卸単価として使用するため、売上の単価はセットしない
                    //oldStockWork.StockUnitPriceFl = oldSalesDetailWork.SalesUnPrcTaxExcFl;        // 売上単価
                    // 2009/03/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<
                    oldStockWork.WarehouseCode = oldSalesDetailWork.WarehouseCode;                // 倉庫コード
                    oldStockWork.WarehouseName = oldSalesDetailWork.WarehouseName;                // 倉庫名称
                    oldStockWork.WarehouseShelfNo = oldSalesDetailWork.WarehouseShelfNo;          // 倉庫棚番

                    # region [--- DEL ---]
                    //売上形式・受託計上売上区分にて分岐
                    //if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //    salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    oldStockWork.SupplierStock = -oldSalesDetailWork.StockCount; //売上在庫数　←　売上数
                    //}
                    //else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                    //         salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    oldStockWork.TrustCount = -oldSalesDetailWork.StockCount; //受託数　←　売上数
                    //}
                    //else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //         (salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                    //          salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                    //{
                    //    oldStockWork.SupplierStock = -oldSalesDetailWork.StockCount; //売上在庫数
                    //    oldStockWork.TrustCount = oldSalesDetailWork.StockCount; //受託数
                    //}
                    # endregion

                    // 数量差分反映
                    //this.ReflectShipmCntDifference(ref oldStockWork, salesSlipWork, oldSalesDetailWork, null, oldSalesDetailWork.ShipmentCnt * -1);  //DEL 2009/01/30 M.Kubota

                    //--- ADD 2009/01/30 M.Kubota --->>>
                    refCntDifDat = new ReflectCntDifData(salesSlipWork, oldSalesDetailWork, null, null, null, oldSalesDetailWork.ShipmentCnt * -1, 0, 0);

                    // 明細追加情報を検索し、計上残区分を取得する
                    refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上元明細データを検索する
                    refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgSalesDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上残区分を設定する
                    refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                    this.ReflectShipmCntDifference(ref oldStockWork, refCntDifDat);
                    //--- ADD 2009/01/30 M.Kubota ---<<<
                    #endregion

                    //削除データ格納
                    stockWorkUpdateList.Add(oldStockWork);

                    #region[在庫受払履歴データ更新パラメータ格納]
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    Start
                    //--------------------------------------------------------------------------------------------------

                    // 30:売上　40:出荷 のみ在庫受払履歴データを作成・更新する
                    if (salesSlipWork.AcptAnOdrStatus == 30 || salesSlipWork.AcptAnOdrStatus == 40)
                    {
                        //int mode = 1;
                        stockAcPayHistWork = new StockAcPayHistWork();

                        //orgSalesDetailWork = detailsSelector.Find(oldSalesDetailWork);  //DEL 2009/01/30 M.Kubota

                        //--- ADD 2009/01/22 M.Kubota --->>>
                        // 登録前 売上データを元に受払履歴データを作成
                        // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                        //// -- UPD 2009/12/28 -------------------------------->>>
                        ////this.SalesSlipToStockAcPayHist(oldSalesSlipWork, oldSalesDetailWork, null, 1, ref stockAcPayHistWork);
                        //this.SalesSlipToStockAcPayHist(oldSalesSlipWork, oldSalesDetailWork, null, 1, ref stockAcPayHistWork, refCntDifDat);
                        //// -- UPD 2009/12/28 -------------------------------->>>
                        this.SalesSlipToStockAcPayHist(oldSalesSlipWork, oldSalesDetailWork, null, 1, ref stockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                        // --- UPD 2013/06/07 Y.Wakita -----<<<<<
                        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //--- ADD 2009/01/22 M.Kubota ---<<<

                        # region [--- DEL 2009/01/22 M.Kubota --- 修正範囲が大きいので全削除] 
                        ////在庫受払履歴データ ← 売上ヘッダ
                        //stockAcPayHistWork.EnterpriseCode = salesSlipWork.EnterpriseCode;   //企業コード                    

                        ////stockAcPayHistWork.ValidDivCd = mode;  //DEL 2008/06/06 M.Kubota

                        //// 受注ステータスによって設定値が異なる項目
                        //switch (salesSlipWork.AcptAnOdrStatus)
                        //{
                        //    case 30:  // 売上
                        //        {
                        //            if (oldSalesDetailWork.AcptAnOdrStatusSrc == 40 ||                                                                            // 出荷引当した売上
                        //                (oldSalesDetailWork.SalesSlipCdDtl == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40) ||  // 出荷引当した売上の返品
                        //                (salesSlipWork.DebitNoteDiv == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40))        // 出荷引当した売上の赤伝
                        //            {
                        //                // 入荷引当売上伝票の場合
                        //                stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                                       //入出荷日 ← 未設定(最小値)
                        //            }
                        //            else
                        //            {
                        //                // 入荷引当されていない売上伝票の場合
                        //                stockAcPayHistWork.IoGoodsDay = salesSlipWork.ShipmentDay;                               //入出荷日 ← 出荷日
                        //            }

                        //            stockAcPayHistWork.AddUpADate = salesSlipWork.SalesDate;                                     //計上日付 ← 売上日
                        //            stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Sales;        //受払元伝票区分
                        //            break;
                        //        }
                        //    case 40:  // 出荷
                        //        {
                        //            stockAcPayHistWork.IoGoodsDay = salesSlipWork.ShipmentDay;                                   //入出荷日 ← 出荷日
                        //            stockAcPayHistWork.AddUpADate = DateTime.MinValue;                                           //計上日付 ← 未設定(最小値)
                        //            stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Consignment;  //受払元伝票区分
                        //            break;
                        //        }
                        //}

                        //stockAcPayHistWork.AcPaySlipNum = salesSlipWork.SalesSlipNum;         //受払元伝票番号
                        //stockAcPayHistWork.AcPaySlipRowNo = oldSalesDetailWork.SalesRowNo;    //受払元行番号
                        //stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;            //受払履歴作成日時

                        //// 受払元取引区分
                        //if (salesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
                        //{
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;  // 返品
                        //}
                        //else if (salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                        //{
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;        // 赤伝
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;     // 通常伝票
                        //}

                        //stockAcPayHistWork.InputSectionCd = salesSlipWork.SalesInpSecCd;  //入力拠点コード

                        //// 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        ////object objSecNm = this._secInfoSeTtable[salesSlipWork.SalesInpSecCd];          //DEL 2009/01/13 M.Kubota
                        //object objSecNm = this._secInfoSeTtable[salesSlipWork.SalesInpSecCd.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                        ////入力拠点ガイド名称
                        //if (objSecNm is string)
                        //{
                        //    stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.InputSectionGuidNm = "";
                        //}

                        //stockAcPayHistWork.InputAgenCd = salesSlipWork.SalesInputCode;            //入力担当者コード　←　売上入力者コード
                        //stockAcPayHistWork.InputAgenNm = salesSlipWork.SalesInputName;            //入力担当者名称　←　売上入力者名称
                        //stockAcPayHistWork.CustSlipNo = salesSlipWork.PartySaleSlipNum;           //相手先伝票番号
                        //stockAcPayHistWork.SlipDtlNum = oldSalesDetailWork.SalesSlipDtlNum;       //明細通番
                        //stockAcPayHistWork.AcPayNote = oldSalesDetailWork.DtlNote;                //受払備考
                        //stockAcPayHistWork.GoodsMakerCd = oldSalesDetailWork.GoodsMakerCd;        // メーカーコード
                        //stockAcPayHistWork.MakerName = oldSalesDetailWork.MakerName;              // メーカー名称
                        //stockAcPayHistWork.GoodsNo = oldSalesDetailWork.GoodsNo;                  // 商品番号
                        //stockAcPayHistWork.GoodsName = oldSalesDetailWork.GoodsName;              // 商品名称
                        //stockAcPayHistWork.BLGoodsCode = oldSalesDetailWork.BLGoodsCode;          // BL商品コード
                        //stockAcPayHistWork.BLGoodsFullName = oldSalesDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                        ////stockAcPayHistWork.SectionCode = salesSlipWork.StockUpdateSecCd;          // 拠点コード ← 在庫更新拠点コード  //DEL 2008/06/06 M.Kubota
                        //stockAcPayHistWork.SectionCode = salesSlipWork.SectionCode;               // 拠点コード  //ADD 2008/06/06 M.Kubota

                        //// 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        ////objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode];          //DEL 2009/01/13 M.Kubota
                        //objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                        ////入力拠点ガイド名称
                        //if (objSecNm is string)
                        //{
                        //    stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.SectionGuideNm = "";
                        //}

                        //stockAcPayHistWork.WarehouseCode = oldSalesDetailWork.WarehouseCode;   // 倉庫コード
                        //stockAcPayHistWork.WarehouseName = oldSalesDetailWork.WarehouseName;   // 倉庫名称
                        //stockAcPayHistWork.ShelfNo = oldSalesDetailWork.WarehouseShelfNo;      // 倉庫棚番
                        //stockAcPayHistWork.CustomerCode = salesSlipWork.CustomerCode;          // 得意先コード
                        ////stockAcPayHistWork.CustomerName = salesSlipWork.CustomerName;          // 得意先名称
                        ////stockAcPayHistWork.CustomerName2 = salesSlipWork.CustomerName2;        // 得意先名称2
                        //stockAcPayHistWork.CustomerSnm = salesSlipWork.CustomerSnm;            // 得意先略称
                        //stockAcPayHistWork.ArrivalCnt = 0;                                     // 入荷数

                        //stockAcPayHistWork.OpenPriceDiv = oldSalesDetailWork.OpenPriceDiv;              // オープン価格区分
                        //stockAcPayHistWork.ListPriceTaxExcFl = oldSalesDetailWork.ListPriceTaxExcFl;    // 定価(税抜,浮動)
                        //stockAcPayHistWork.StockUnitPriceFl = oldSalesDetailWork.SalesUnitCost;         // 仕入単価(税抜,浮動) ← 原価単価
                        //stockAcPayHistWork.StockPrice = oldSalesDetailWork.Cost;                        // 仕入金額 ← 原価金額
                        //stockAcPayHistWork.SalesUnPrcTaxExcFl = oldSalesDetailWork.SalesUnPrcTaxExcFl;  // 売上単価(税抜,浮動)
                        //stockAcPayHistWork.SalesMoney = oldSalesDetailWork.SalesMoneyTaxExc;            // 売上金額

                        //int indexCount = 0;

                        ////在庫受払履歴パラメータListにデータがある時
                        //if (stockAcPayHistWorkUpdateList.Count > 0)
                        //{
                        //    stockAcPayHistWorkUpdateList.Sort(stockAcPayHistWorkComparer);

                        //    indexCount = stockAcPayHistWorkUpdateList.BinarySearch(0, stockAcPayHistWorkUpdateList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                        //    if (indexCount >= 0 && indexCount <= oldSalesDetailWorkList.Count)
                        //    {
                        //        StockAcPayHistWork oldItem = stockAcPayHistWorkUpdateList[indexCount] as StockAcPayHistWork;

                        //        if (oldItem.GoodsMakerCd == oldSalesDetailWork.GoodsMakerCd && oldItem.GoodsNo == oldSalesDetailWork.GoodsNo)
                        //        {
                        //            stockAcPayHistWork.ShipmentCnt += oldItem.ShipmentCnt * -1;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        stockAcPayHistWork.ShipmentCnt = oldSalesDetailWork.ShipmentCnt * -1;  // 出荷数
                        //        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //    }
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.ShipmentCnt = oldSalesDetailWork.ShipmentCnt * -1;  // 出荷数
                        //    stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //}
                        # endregion
                    }
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    End
                    //--------------------------------------------------------------------------------------------------
                    #endregion

                }
            }

            //●新規追加データのチェック
            for (int i = 0; i < salesDetailWorkList.Count; i++)
            {
                salesDetailWork = salesDetailWorkList[i] as SalesDetailWork; ;

                flg = false;

                for (int x = 0; x < oldSalesDetailWorkList.Count; x++)
                {
                    oldSalesDetailWork = oldSalesDetailWorkList[x] as SalesDetailWork;

                    # region [--- DEL 2009/01/22 M.Kubota ---]
                    //// 行№.拠点.倉庫.ﾒｰｶｰ.商品番号が一致するなら変更とみなす
                    //if (oldSalesDetailWork.SalesRowNo == salesDetailWork.SalesRowNo &&
                    //     oldSalesDetailWork.SectionCode.TrimEnd() == salesDetailWork.SectionCode.TrimEnd() &&
                    //     oldSalesDetailWork.WarehouseCode.TrimEnd() == salesDetailWork.WarehouseCode.TrimEnd() &&
                    //     oldSalesDetailWork.GoodsMakerCd == salesDetailWork.GoodsMakerCd &&
                    //     oldSalesDetailWork.GoodsNo.TrimEnd() == salesDetailWork.GoodsNo.TrimEnd() &&
                    //     oldSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNum)
                    # endregion
                    // 倉庫・メーカー・品番・明細通番が一致する場合は変更明細とみなす
                    if (oldSalesDetailWork.WarehouseCode.TrimEnd() == salesDetailWork.WarehouseCode.TrimEnd() &&
                        oldSalesDetailWork.GoodsMakerCd == salesDetailWork.GoodsMakerCd &&
                        oldSalesDetailWork.GoodsNo.TrimEnd() == salesDetailWork.GoodsNo.TrimEnd() &&
                        oldSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNum)
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

                    # region [--- DEL 2008/06/06 M.Kubota ---]
                    //在庫管理有無区分・売上数チェック
                    //if (salesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage || salesDetailWork.StockCount == 0) continue;
                    //--- DEL 2008/06/06 M.Kubota --->>>
                    //if (salesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
                    //    (salesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && salesDetailWork.SalesOrderDivCd == 0) ||
                    //    salesDetailWork.ShipmentCnt == 0) continue;
                    //--- DEL 2008/06/06 M.Kubota ---<<<
                    # endregion

                    if (!salesDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/06 M.Kubota

                    //売上ヘッダ　→　在庫マスタ
                    stockWork.EnterpriseCode = salesSlipWork.EnterpriseCode;                //企業コード
                    //stockWork.SectionCode = salesSlipWork.StockUpdateSecCd;               //拠点コード    //DEL 2008/06/06 M.Kubota
                    stockWork.SectionCode = salesSlipWork.SectionCode;                      //拠点コード    //ADD 2008/06/06 M.Kubota
                    stockWork.LastSalesDate = salesSlipWork.SalesDate;                      //最終売上年月日　←　売上日

                    //売上明細　→　在庫マスタ
                    //--- ADD 2007/09/11 M.Kubota --->>>
                    stockWork.GoodsMakerCd = salesDetailWork.GoodsMakerCd;                  // 商品メーカーコード

                    stockWork.GoodsNo = salesDetailWork.GoodsNo;                            // 商品番号
                    # region [--- DEL 2008/06/06 M.Kubota ---]
                    //--- DEL 2008/06/06 M.Kubota --->>>
                    //stockWork.MakerName = salesDetailWork.MakerName;                        // メーカー名称
                    //stockWork.GoodsName = salesDetailWork.GoodsName;                        // 商品名称
                    //stockWork.GoodsShortName = salesDetailWork.GoodsShortName;              // 商品名略称
                    //stockWork.LargeGoodsGanreCode = salesDetailWork.LargeGoodsGanreCode;    // 商品区分グループコード
                    //stockWork.LargeGoodsGanreName = salesDetailWork.LargeGoodsGanreName;    // 商品区分グループ名称
                    //stockWork.MediumGoodsGanreCode = salesDetailWork.MediumGoodsGanreCode;  // 商品区分コード
                    //stockWork.MediumGoodsGanreName = salesDetailWork.MediumGoodsGanreName;  // 商品区分名称
                    //stockWork.DetailGoodsGanreCode = salesDetailWork.DetailGoodsGanreCode;  // 商品区分詳細コード
                    //stockWork.DetailGoodsGanreName = salesDetailWork.DetailGoodsGanreName;  // 商品区分詳細名称
                    //stockWork.BLGoodsCode = salesDetailWork.BLGoodsCode;                    // BL商品コード
                    //stockWork.BLGoodsFullName = salesDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)
                    //stockWork.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode;    // 自社分類コード
                    //stockWork.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)
                    //--- DEL 2008/06/06 M.Kubota ---<<<
                    # endregion
                    // 2009/03/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 在庫単価は棚卸評価単価として使用するため、売上単価はセットしない。
                    //stockWork.StockUnitPriceFl = salesDetailWork.SalesUnPrcTaxExcFl;        // 売上単価
                    // 2009/03/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    stockWork.WarehouseCode = salesDetailWork.WarehouseCode;                // 倉庫コード
                    stockWork.WarehouseName = salesDetailWork.WarehouseName;                // 倉庫名称
                    stockWork.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo;          // 倉庫棚番

                    # region [--- DEL ---]
                    //売上形式・受託計上売上区分にて分岐
                    //if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //    salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    stockWork.SupplierStock = salesDetailWork.StockCount; //売上在庫数　←　売上数
                    //}
                    //else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
                    //         salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
                    //{
                    //    stockWork.TrustCount = salesDetailWork.StockCount; //受託数　←　売上数
                    //}
                    //else if (salesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
                    //         (salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy ||
                    //         salesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy))
                    //{
                    //    stockWork.SupplierStock = salesDetailWork.StockCount; //売上在庫数
                    //    stockWork.TrustCount = -(salesDetailWork.StockCount); //受託数
                    //}
                    # endregion

                    // 数量差分反映
                    //this.ReflectShipmCntDifference(ref stockWork, salesSlipWork, salesDetailWork, null, salesDetailWork.ShipmentCnt);  //DEL 2009/01/30 M.Kubota

                    //--- ADD 2009/01/30 M.Kubota --->>>
                    refCntDifDat = new ReflectCntDifData(salesSlipWork, salesDetailWork, null, null, null, salesDetailWork.ShipmentCnt, 0, 0);

                    // 明細追加情報を検索し、計上残区分を取得する
                    refCntDifDat.AddInfo = slpDtlAddInfList.Find(delegate(SlipDetailAddInfoWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上元明細データを検索する
                    refCntDifDat.AddUpOrgDetail = addUpOrgDtlList.Find(delegate(AddUpOrgSalesDetailWork item) { return item.DtlRelationGuid == refCntDifDat.Detail.DtlRelationGuid; });

                    // 計上残区分を設定する
                    refCntDifDat.SetAddUpRemDiv(this.IOWriteCtrlOptWork);

                    this.ReflectShipmCntDifference(ref stockWork, refCntDifDat);
                    //--- ADD 2009/01/30 M.Kubota ---<<<

                    #endregion

                    stockWorkUpdateList.Add(stockWork);

                    #region[在庫受払履歴データ更新パラメータ格納]
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    Start
                    //--------------------------------------------------------------------------------------------------

                    // 30:売上　40:出荷 のみ在庫受払履歴データを作成・更新する
                    if (salesSlipWork.AcptAnOdrStatus == 30 || salesSlipWork.AcptAnOdrStatus == 40)
                    {
                        //int mode = 0;
                        stockAcPayHistWork = new StockAcPayHistWork();

                        //orgSalesDetailWork = detailsSelector.Find(salesDetailWork);  //DEL 2009/01/30 M.Kubota

                        //--- ADD 2009/01/22 M.Kubota --->>>
                        // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                        //// -- UPD 2009/12/28 ------------------->>>
                        ////this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork);
                        //this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork, refCntDifDat);
                        //// -- UPD 2009/12/28 -------------------<<<
                        this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, refCntDifDat.Detail, refCntDifDat.AddUpOrgDetail, 0, ref stockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                        // --- UPD 2013/06/07 Y.Wakita -----<<<<<

                        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //--- ADD 2009/01/22 M.Kubota ---<<<

                        //--- ADD 2009/01/30 M.Kubota --->>>
                        // 貸出計上伝票の場合で、且つ貸出計上残区分が"残さない"設定になっている場合
                        // 貸出数を相殺する受払履歴データを追加作成する。
                        if (refCntDifDat.Detail.AcptAnOdrStatus == 30 && refCntDifDat.Detail.AcptAnOdrStatusSrc == 40 && refCntDifDat.AddUpRemDiv == 1)
                        {
                            counterStockAcPayHistWork = new StockAcPayHistWork();
                            SalesDetailWork counterDtlWork = refCntDifDat.AddUpOrgDetail.Clone();

                            counterDtlWork.ShipmentCnt = refCntDifDat.Detail.ShipmentCnt - refCntDifDat.AddUpOrgDetail.ShipmentCnt;                 // 出荷数   (差分)
                            counterDtlWork.Cost = refCntDifDat.Detail.Cost - refCntDifDat.AddUpOrgDetail.Cost;                                      // 原価金額 (差分)
                            counterDtlWork.SalesMoneyTaxExc = refCntDifDat.Detail.SalesMoneyTaxExc - refCntDifDat.AddUpOrgDetail.SalesMoneyTaxExc;  // 売上金額 (差分)

                            // 売上データは"売上"で、売上明細データは"貸出(計上元)"の差分値
                            // --- UPD 2013/06/07 Y.Wakita ----->>>>>
                            //// -- UPD 2009/12/28 -------------------->>>
                            ////this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, counterDtlWork, null, 0, ref counterStockAcPayHistWork);
                            //this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, counterDtlWork, null, 0, ref counterStockAcPayHistWork, refCntDifDat);
                            //// -- UPD 2009/12/28 --------------------<<<
                            this.SalesSlipToStockAcPayHist(refCntDifDat.Slip, counterDtlWork, null, 0, ref counterStockAcPayHistWork, refCntDifDat, ref sqlConnection, ref sqlTransaction);
                            // --- UPD 2013/06/07 Y.Wakita -----<<<<<

                            counterStockAcPayHistWork.AddUpADate = counterStockAcPayHistWork.IoGoodsDay;                                            // 計上日付 ← 入出荷日
                            counterStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;                  // 受払元取引区分(返品)

                            stockAcPayHistWorkUpdateList.Add(counterStockAcPayHistWork);
                        }
                        //--- ADD 2009/01/30 M.Kubota ---<<<

                        # region [--- DEL 2009/01/22 M.Kubota --- 修正範囲が大きいので全削除]
                        ////在庫受払履歴データ ← 売上ヘッダ
                        //stockAcPayHistWork.EnterpriseCode = salesSlipWork.EnterpriseCode;   //企業コード                    

                        ////stockAcPayHistWork.ValidDivCd = mode;  //DEL 2008/06/06 M.Kubota

                        //// 受注ステータスによって設定値が異なる項目
                        //switch (salesSlipWork.AcptAnOdrStatus)
                        //{
                        //    case 30:  // 売上
                        //        {
                        //            if (salesDetailWork.AcptAnOdrStatusSrc == 40 ||                                                                            // 出荷引当した売上
                        //                (salesDetailWork.SalesSlipCdDtl == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40) ||  // 出荷引当した売上の返品
                        //                (salesSlipWork.DebitNoteDiv == 1 && orgSalesDetailWork != null && orgSalesDetailWork.AcptAnOdrStatusSrc == 40))        // 出荷引当した売上の赤伝
                        //            {
                        //                // 入荷引当売上伝票の場合
                        //                stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;                                       //入出荷日 ← 未設定(最小値)
                        //            }
                        //            else
                        //            {
                        //                // 入荷引当されていない売上伝票の場合
                        //                stockAcPayHistWork.IoGoodsDay = salesSlipWork.ShipmentDay;                               //入出荷日 ← 出荷日
                        //            }

                        //            stockAcPayHistWork.AddUpADate = salesSlipWork.SalesDate;                                     //計上日付 ← 売上日
                        //            stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Sales;        //受払元伝票区分
                        //            break;
                        //        }
                        //    case 40:  // 出荷
                        //        {
                        //            stockAcPayHistWork.IoGoodsDay = salesSlipWork.ShipmentDay;                                   //入出荷日 ← 出荷日
                        //            stockAcPayHistWork.AddUpADate = DateTime.MinValue;                                           //計上日付 ← 未設定(最小値)
                        //            stockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Consignment;  //受払元伝票区分
                        //            break;
                        //        }
                        //}

                        //stockAcPayHistWork.AcPaySlipNum = salesSlipWork.SalesSlipNum;      //受払元伝票番号
                        //stockAcPayHistWork.AcPaySlipRowNo = salesDetailWork.SalesRowNo;    //受払元行番号
                        //stockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks;         //受払履歴作成日時

                        //// 受払元取引区分
                        //if (salesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
                        //{
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;  // 返品
                        //}
                        //else if (salesSlipWork.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
                        //{
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.RedSlip;        // 赤伝
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip;     // 通常伝票
                        //}

                        //stockAcPayHistWork.InputSectionCd = salesSlipWork.SalesInpSecCd;  //入力拠点コード

                        //// 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        ////object objSecNm = this._secInfoSeTtable[salesSlipWork.SalesInpSecCd];          //DEL 2009/01/13 M.Kubota
                        //object objSecNm = this._secInfoSeTtable[salesSlipWork.SalesInpSecCd.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                        ////入力拠点ガイド名称
                        //if (objSecNm is string)
                        //{
                        //    stockAcPayHistWork.InputSectionGuidNm = (objSecNm as string);
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.InputSectionGuidNm = "";
                        //}

                        //stockAcPayHistWork.InputAgenCd = salesSlipWork.SalesInputCode;         //入力担当者コード　←　売上入力者コード
                        //stockAcPayHistWork.InputAgenNm = salesSlipWork.SalesInputName;         //入力担当者名称　←　売上入力者名称
                        //stockAcPayHistWork.CustSlipNo = salesSlipWork.PartySaleSlipNum;        //相手先伝票番号
                        //stockAcPayHistWork.SlipDtlNum = salesDetailWork.SalesSlipDtlNum;       //明細通番
                        //stockAcPayHistWork.AcPayNote = salesDetailWork.DtlNote;                //受払備考
                        //stockAcPayHistWork.GoodsMakerCd = salesDetailWork.GoodsMakerCd;        // メーカーコード
                        //stockAcPayHistWork.MakerName = salesDetailWork.MakerName;              // メーカー名称
                        //stockAcPayHistWork.GoodsNo = salesDetailWork.GoodsNo;                  // 商品番号
                        //stockAcPayHistWork.GoodsName = salesDetailWork.GoodsName;              // 商品名称
                        //stockAcPayHistWork.BLGoodsCode = salesDetailWork.BLGoodsCode;          // BL商品コード
                        //stockAcPayHistWork.BLGoodsFullName = salesDetailWork.BLGoodsFullName;  // BL商品コード名称(全角)
                        ////stockAcPayHistWork.SectionCode = salesSlipWork.StockUpdateSecCd;       // 拠点コード ← 在庫更新拠点コード  //DEL 2008/06/06 M.Kubota
                        //stockAcPayHistWork.SectionCode = salesSlipWork.SectionCode;            // 拠点コード  //ADD 2008/06/06 M.Kubota

                        //// 拠点コードに紐付く拠点名称をハッシュテーブルより取得する
                        ////objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode];          //DEL 2009/01/13 M.Kubota
                        //objSecNm = this._secInfoSeTtable[stockAcPayHistWork.SectionCode.TrimEnd()];  //ADD 2009/01/13 M.Kubota

                        ////入力拠点ガイド名称
                        //if (objSecNm is string)
                        //{
                        //    stockAcPayHistWork.SectionGuideNm = (objSecNm as string);
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.SectionGuideNm = "";
                        //}

                        //stockAcPayHistWork.WarehouseCode = salesDetailWork.WarehouseCode;   // 倉庫コード
                        //stockAcPayHistWork.WarehouseName = salesDetailWork.WarehouseName;   // 倉庫名称
                        //stockAcPayHistWork.ShelfNo = salesDetailWork.WarehouseShelfNo;      // 倉庫棚番
                        //stockAcPayHistWork.CustomerCode = salesSlipWork.CustomerCode;       // 得意先コード
                        ////stockAcPayHistWork.CustomerName = salesSlipWork.CustomerName;       // 得意先名称
                        ////stockAcPayHistWork.CustomerName2 = salesSlipWork.CustomerName2;     // 得意先名称2
                        //stockAcPayHistWork.CustomerSnm = salesSlipWork.CustomerSnm;         // 得意先略称
                        //stockAcPayHistWork.ArrivalCnt = 0;                                  // 入荷数

                        //stockAcPayHistWork.OpenPriceDiv = salesDetailWork.OpenPriceDiv;              // オープン価格区分
                        //stockAcPayHistWork.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl;    // 定価(税抜,浮動)
                        //stockAcPayHistWork.StockUnitPriceFl = salesDetailWork.SalesUnitCost;         // 仕入単価(税抜,浮動) ← 原価単価
                        //stockAcPayHistWork.StockPrice = salesDetailWork.Cost;                        // 仕入金額 ← 原価金額
                        //stockAcPayHistWork.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl;  // 売上単価(税抜,浮動)
                        //stockAcPayHistWork.SalesMoney = salesDetailWork.SalesMoneyTaxExc;            // 売上金額

                        //int indexCount = 0;

                        ////在庫受払履歴パラメータListにデータがある時
                        //if (stockAcPayHistWorkUpdateList.Count > 0)
                        //{
                        //    stockAcPayHistWorkUpdateList.Sort(stockAcPayHistWorkComparer);

                        //    indexCount = stockAcPayHistWorkUpdateList.BinarySearch(0, stockAcPayHistWorkUpdateList.Count, stockAcPayHistWork, stockAcPayHistWorkComparer);

                        //    if (indexCount >= 0 && indexCount <= salesDetailWorkList.Count)
                        //    {
                        //        StockAcPayHistWork oldItem = stockAcPayHistWorkUpdateList[indexCount] as StockAcPayHistWork;

                        //        if (oldItem.GoodsMakerCd == salesDetailWork.GoodsMakerCd && oldItem.GoodsNo == salesDetailWork.GoodsNo)
                        //        {
                        //            stockAcPayHistWork.ShipmentCnt += oldItem.ShipmentCnt;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        stockAcPayHistWork.ShipmentCnt = salesDetailWork.ShipmentCnt;  // 出荷数
                        //        stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //    }
                        //}
                        //else
                        //{
                        //    stockAcPayHistWork.ShipmentCnt = salesDetailWork.ShipmentCnt;  // 出荷数
                        //    stockAcPayHistWorkUpdateList.Add(stockAcPayHistWork);
                        //}
                        # endregion
                    }
                    //--------------------------------------------------------------------------------------------------
                    //●在庫受払履歴データ更新パラメータ格納    End
                    //--------------------------------------------------------------------------------------------------
                    #endregion
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        //--- ADD 2009/01/22 M.Kubota --->>>
        /// <summary>
        /// 売上データを元に、在庫受払履歴のデータセットを行います
        /// </summary>
        /// <param name="slsSlip">売上伝票データ</param>
        /// <param name="slsDtl">売上明細データ</param>
        /// <param name="orgDtl">元黒・返品元明細データ</param>
        /// <param name="mode">動作モード(0:加算 1:減算)</param>
        /// <param name="stcAcPayHist">在庫受払履歴データ</param>
        /// <param name="data">パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        // --- UPD 2013/06/07 Y.Wakita ----->>>>>
        //private void SalesSlipToStockAcPayHist(SalesSlipWork slsSlip, SalesDetailWork slsDtl, SalesDetailWork orgDtl, int mode, ref StockAcPayHistWork stcAcPayHist, ReflectCntDifData data)
        private void SalesSlipToStockAcPayHist(SalesSlipWork slsSlip, SalesDetailWork slsDtl, SalesDetailWork orgDtl, int mode, ref StockAcPayHistWork stcAcPayHist, ReflectCntDifData data, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // --- UPD 2013/06/07 Y.Wakita -----<<<<<
        {
            stcAcPayHist.EnterpriseCode = slsDtl.EnterpriseCode;             // 企業コード

            // -- UPD 2009/12/28 ------------------------>>>
            int addUpRemDiv = 0;
            if (data != null)
            {
                //計上残区分を取得
                addUpRemDiv = data.AddUpRemDiv;

                //貸出計上の赤伝 ＯＲ 返品では売上全体設定の計上区分が取得出来ないため、ここで取得
                if ((slsDtl.SalesSlipCdDtl == 1 && orgDtl != null && orgDtl.AcptAnOdrStatusSrc == 40) ||  // 貸出計上した売上の返品
                    (slsSlip.DebitNoteDiv == 1 && orgDtl != null && orgDtl.AcptAnOdrStatusSrc == 40))     // 貸出計上した売上の赤伝
                {
                    addUpRemDiv = this.IOWriteCtrlOptWork.ShipmAddUpRemDiv;
                }
            }
            // -- UPD 2009/12/28 ------------------------<<<

            # region [受注ステータスによって設定値が異なる項目]
            switch (slsDtl.AcptAnOdrStatus)
            {
                case 30:  // 売上
                    {

                        if (slsDtl.AcptAnOdrStatusSrc == 40 ||                                                    // 貸出計上した売上
                            (slsDtl.SalesSlipCdDtl == 1 && orgDtl != null && orgDtl.AcptAnOdrStatusSrc == 40) ||  // 貸出計上した売上の返品
                            (slsSlip.DebitNoteDiv == 1 && orgDtl != null && orgDtl.AcptAnOdrStatusSrc == 40))     // 貸出計上した売上の赤伝
                        {

    　　                    // -- UPD 2009/12/28 ---------------------->>>
　　                        //// 入荷引当売上伝票の場合
                            //stcAcPayHist.IoGoodsDay = DateTime.MinValue;                                       // 入出荷日 ← 未設定(最小値)

                            if (
                                ((addUpRemDiv == 1 && 
                                  ((mode == 1) ||                                                                                   // 計上伝票削除
                                   ((mode == 0) && (data.Detail != null) && (data.Detail.ShipmentCnt != data.CntDifference))))     // 計上伝票の更新の場合
                                )  ||
                                ((slsDtl.SalesSlipCdDtl == 1 && orgDtl != null && orgDtl.AcptAnOdrStatusSrc == 40) ||            // 貸出計上した売上の返品
                                (slsSlip.DebitNoteDiv == 1 && orgDtl != null && orgDtl.AcptAnOdrStatusSrc == 40))                // 貸出計上した売上の赤伝
                                
                               )
                            {
                                //計上残残さないで、貸出計上の削除、更新
                                //計上残残す場合、残さない場合ともに貸出計上の返品、赤伝は
                                //入出荷日をセットする必要がある(入出庫照会で繰越数算出対象とするため)
                                stcAcPayHist.IoGoodsDay = slsSlip.ShipmentDay;                                     // 入出荷日 ← 出荷日
                            }
                            else
                            {
                                // 入荷引当売上伝票の場合
                                stcAcPayHist.IoGoodsDay = DateTime.MinValue;                                       // 入出荷日 ← 未設定(最小値)
                            }
                            // -- UPD 2009/12/28 ----------------------<<<

                        }
                        else
                        {
                            // 入荷引当されていない売上伝票の場合
                            stcAcPayHist.IoGoodsDay = slsSlip.ShipmentDay;                                     // 入出荷日 ← 出荷日
                        }

                        stcAcPayHist.AddUpADate = slsSlip.SalesDate;                                           // 計上日付 ← 売上日
                        stcAcPayHist.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Sales;        // 受払元伝票区分
                        break;
                    }
                case 40:  // 出荷(貸出)
                    {
                        stcAcPayHist.IoGoodsDay = slsSlip.ShipmentDay;                                         // 入出荷日 ← 出荷日
                        stcAcPayHist.AddUpADate = DateTime.MinValue;                                           // 計上日付 ← 未設定(最小値)
                        stcAcPayHist.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.Consignment;  // 受払元伝票区分
                        break;
                    }
            }
            # endregion

            stcAcPayHist.AcPaySlipNum = slsDtl.SalesSlipNum;                 // 受払元伝票番号

            # region [受払元取引区分]
            if (mode == 0)
            {
                if (slsSlip.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
                {
                    stcAcPayHist.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.ReturnedGoods;  // 返品
                }
                else if (slsSlip.DebitNoteDiv == (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Red)
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

            // -- 2009/04/09 ---->>>>>
            //stcAcPayHist.InputSectionCd = slsSlip.ResultsAddUpSecCd;         // 入力拠点コード
            stcAcPayHist.InputSectionCd = slsSlip.SectionCode;         // 入力拠点コード
            // -- 2009/04/09 ----<<<<<
            // --- ADD 2013/05/08 T.Nishi ----->>>>>
            // --- DEL 2013/06/07 Y.Wakita ----->>>>>
            //SqlConnection lsqlConnection = null;
            //SqlTransaction lsqlTransaction = null;
            // --- DEL 2013/06/07 Y.Wakita -----<<<<<
            Hashtable _secInfoSeTtable = null;
            int status = 0;
            // --- UPD 2013/06/07 Y.Wakita ----->>>>>
            //status = this.GetSecInfoSetWork(slsSlip.EnterpriseCode, out _secInfoSeTtable, ref lsqlConnection, ref lsqlTransaction);
            status = this.GetSecInfoSetWork(slsSlip.EnterpriseCode, out _secInfoSeTtable, ref sqlConnection, ref sqlTransaction);
            // --- UPD 2013/06/07 Y.Wakita -----<<<<<
            // --- ADD 2013/05/08 T.Nishi -----<<<<<
            
            // 入力拠点ガイド名称
            // --- UPD 2013/05/08 T.Nishi ----->>>>>
            //object objSecNm = this._secInfoSeTtable[slsSlip.SalesInpSecCd.TrimEnd()];
            object objSecNm = _secInfoSeTtable[slsSlip.SalesInpSecCd.TrimEnd()];
            // --- UPD 2013/05/08 T.Nishi -----<<<<<
            stcAcPayHist.InputSectionGuidNm = (objSecNm is string) ? (objSecNm as string) : string.Empty;

            stcAcPayHist.InputAgenCd = slsSlip.SalesEmployeeCd;              // 入力担当者コード
            stcAcPayHist.InputAgenNm = slsSlip.SalesEmployeeNm;              // 入力担当者名称
            stcAcPayHist.CustSlipNo = slsSlip.PartySaleSlipNum;              // 相手先伝票番号
            stcAcPayHist.SlipDtlNum = slsDtl.SalesSlipDtlNum;                // 明細通番
            stcAcPayHist.AcPayNote = slsDtl.DtlNote;                         // 受払備考
            stcAcPayHist.GoodsMakerCd = slsDtl.GoodsMakerCd;                 // メーカーコード
            stcAcPayHist.MakerName = slsDtl.MakerName;                       // メーカー名称
            stcAcPayHist.GoodsNo = slsDtl.GoodsNo;                           // 商品番号
            stcAcPayHist.GoodsName = slsDtl.GoodsName;                       // 商品名称
            stcAcPayHist.BLGoodsCode = slsDtl.BLGoodsCode;                   // BL商品コード
            stcAcPayHist.BLGoodsFullName = slsDtl.BLGoodsFullName;           // BL商品コード名称(全角)
            // -- 2009/04/09 ---->>>>>
            //stcAcPayHist.SectionCode = slsSlip.SectionCode;                  // 拠点コード
            stcAcPayHist.SectionCode = slsSlip.ResultsAddUpSecCd;                  // 拠点コード
            // -- 2009/04/09 ----<<<<<

            // 拠点ガイド名称
            // --- UPD 2013/05/08 T.Nishi ----->>>>>
            //objSecNm = this._secInfoSeTtable[stcAcPayHist.SectionCode.TrimEnd()];
            objSecNm = _secInfoSeTtable[stcAcPayHist.SectionCode.TrimEnd()];
            // --- UPD 2013/05/08 T.Nishi -----<<<<<
            stcAcPayHist.SectionGuideNm = (objSecNm is string) ? (objSecNm as string) : string.Empty;  

            stcAcPayHist.WarehouseCode = slsDtl.WarehouseCode;               // 倉庫コード
            stcAcPayHist.WarehouseName = slsDtl.WarehouseName;               // 倉庫名称
            stcAcPayHist.ShelfNo = slsDtl.WarehouseShelfNo;                  // 倉庫棚番
            stcAcPayHist.CustomerCode = slsSlip.CustomerCode;                // 得意先コード
            stcAcPayHist.CustomerSnm = slsSlip.CustomerSnm;                  // 得意先略称

            int sign = (mode == 0) ? 1 : -1;

            stcAcPayHist.ArrivalCnt = 0;                                     // 入荷数
            stcAcPayHist.ShipmentCnt = slsDtl.ShipmentCnt * sign;            // 出荷数                 (★符号操作)
            stcAcPayHist.OpenPriceDiv = slsDtl.OpenPriceDiv;                 // オープン価格区分
            stcAcPayHist.ListPriceTaxExcFl = slsDtl.ListPriceTaxExcFl;       // 定価(税抜,浮動)
            stcAcPayHist.StockUnitPriceFl = slsDtl.SalesUnitCost;            // 仕入単価(税抜,浮動) ← 原価単価
            stcAcPayHist.StockPrice = slsDtl.Cost * sign;                    // 仕入金額 ← 原価金額   (★符号操作)
            stcAcPayHist.SalesUnPrcTaxExcFl = slsDtl.SalesUnPrcTaxExcFl;     // 売上単価(税抜,浮動)
            stcAcPayHist.SalesMoney = slsDtl.SalesMoneyTaxExc * sign;        // 売上金額               (★符号操作)
        }
        //--- ADD 2009/01/22 M.Kubota ---<<<
        # endregion

        # region [変更前伝票・作成元伝票　取得]
        /// <summary>
        /// 変更前伝票　売上データ・売上明細データ取得処理
        /// </summary>
        /// <param name="oldSalesSlipWork"></param>
        /// <param name="oldSalesDetailWorkList"></param>
        /// <param name="orgSalesSlipWork"></param>
        /// <param name="orgSalesDetailWorkList"></param>
        /// <param name="originList"></param>
        /// <param name="currentSalesSlipWork"></param>
        /// <remarks>
        /// <br>originListの中から、今回伝票の変更前伝票データと（今回伝票ではなく）作成元伝票データを取得します</br>
        /// </remarks>
        private void FindOldAndOriginSalesSlip(out SalesSlipWork oldSalesSlipWork, out ArrayList oldSalesDetailWorkList, out SalesSlipWork orgSalesSlipWork, out ArrayList orgSalesDetailWorkList, CustomSerializeArrayList originList, SalesSlipWork currentSalesSlipWork)
        {
            // 出力パラメータ初期化
            oldSalesSlipWork = null;
            oldSalesDetailWorkList = new ArrayList();
            orgSalesSlipWork = null;
            orgSalesDetailWorkList = new ArrayList();

            //-------------------------------------------------
            // 伝票　売上データ　Find
            //-------------------------------------------------
            foreach (object obj in originList)
            {
                // 売上データ
                if (obj is SalesSlipWork)
                {
                    // 今回伝票と　売上伝票区分(0:売上/1:返品)が同じ　かつ
                    // 　　　　　　赤伝区分(0:黒伝/1:赤伝/2:元黒)が同じ　ものを変更前伝票とみなす
                    if ((obj as SalesSlipWork).SalesSlipCd == currentSalesSlipWork.SalesSlipCd &&
                         (obj as SalesSlipWork).DebitNoteDiv == currentSalesSlipWork.DebitNoteDiv)
                    {
                        // 前
                        oldSalesSlipWork = (SalesSlipWork)obj;
                    }
                    else
                    {
                        // 元
                        orgSalesSlipWork = (SalesSlipWork)obj;
                    }
                }
            }
            //-------------------------------------------------
            // 伝票　売上明細データ　Find
            //-------------------------------------------------
            if (oldSalesSlipWork != null)
            {
                foreach (object obj in originList)
                {
                    // ArrayListで要素があり、最初の要素がSalesDetailWork
                    if (obj is ArrayList && (obj as ArrayList).Count > 0 && (obj as ArrayList)[0] is SalesDetailWork)
                    {
                        // 「変更前伝票売上データの伝票番号と同じ伝票番号を持つ明細のArrayList」を
                        // 「変更前伝票売上明細データリスト」とみなす
                        if (((obj as ArrayList)[0] as SalesDetailWork).SalesSlipNum == oldSalesSlipWork.SalesSlipNum)
                        {
                            // 前
                            oldSalesDetailWorkList = (ArrayList)obj;
                        }
                        //else if (((obj as ArrayList)[0] as SalesDetailWork).SalesSlipNum == orgSalesSlipWork.SalesSlipNum)  //DEL 2009/01/30 M.Kubota
                        else if (orgSalesSlipWork != null && ((obj as ArrayList)[0] as SalesDetailWork).SalesSlipNum == orgSalesSlipWork.SalesSlipNum)  //ADD 2009/01/30 M.Kubota
                        {
                            // 元
                            orgSalesDetailWorkList = (ArrayList)obj;
                        }
                    }
                }
            }
        }

        # endregion

        # region [変更前伝票　取得]
        /// <summary>
        /// 変更前伝票　売上データ・売上明細データ取得処理
        /// </summary>
        /// <param name="oldSalesSlipWork"></param>
        /// <param name="oldSalesDetailWorkList"></param>
        /// <param name="originList"></param>
        /// <param name="currentSalesSlipWork"></param>
        /// <remarks>
        /// <br>originListの中から、今回伝票の変更前伝票データを取得します</br>
        /// </remarks>
        private void FindOldSalesSlip(out SalesSlipWork oldSalesSlipWork, out ArrayList oldSalesDetailWorkList, CustomSerializeArrayList originList, SalesSlipWork currentSalesSlipWork)
        {
            // 出力パラメータ初期化
            oldSalesSlipWork = null;
            oldSalesDetailWorkList = new ArrayList();

            //-------------------------------------------------
            // 変更前伝票　売上データ　Find
            //-------------------------------------------------
            foreach (object obj in originList)
            {
                // 売上データ
                if (obj is SalesSlipWork)
                {
                    // 今回伝票と　売上伝票区分(0:売上/1:返品)が同じ　かつ
                    // 　　　　　　赤伝区分(0:黒伝/1:赤伝/2:元黒)が同じ　ものを変更前伝票とみなす
                    if ((obj as SalesSlipWork).SalesSlipCd == currentSalesSlipWork.SalesSlipCd &&
                         (obj as SalesSlipWork).DebitNoteDiv == currentSalesSlipWork.DebitNoteDiv)
                    {
                        oldSalesSlipWork = (SalesSlipWork)obj;
                        break;
                    }
                }
            }
            //-------------------------------------------------
            // 変更前伝票　売上明細データ　Find
            //-------------------------------------------------
            if (oldSalesSlipWork != null)
            {
                foreach (object obj in originList)
                {
                    // ArrayListで要素があり、最初の要素がSalesDetailWork
                    if (obj is ArrayList && (obj as ArrayList).Count > 0 && (obj as ArrayList)[0] is SalesDetailWork)
                    {
                        // 「変更前伝票売上データの伝票番号と同じ伝票番号を持つ明細のArrayList」を
                        // 「変更前伝票売上明細データリスト」とみなす
                        if (((obj as ArrayList)[0] as SalesDetailWork).SalesSlipNum == oldSalesSlipWork.SalesSlipNum)
                        {
                            oldSalesDetailWorkList = (ArrayList)obj;
                            break;
                        }
                    }
                }
            }
        }
        # endregion

        # region [作成元伝票　取得]
        /// <summary>
        /// 作成元伝票　売上データ・売上明細データ取得処理
        /// </summary>
        /// <param name="orgSalesSlipWork"></param>
        /// <param name="orgSalesDetailWorkList"></param>
        /// <param name="originList"></param>
        /// <param name="currentSalesSlipWork"></param>
        /// <remarks>
        /// <br>originListの中から、（今回伝票ではなく、）元伝票データを取得します</br>
        /// <br>（※返品のもとになった売上）</br>
        /// </remarks>
        private void FindOriginalSalesSlip(out SalesSlipWork orgSalesSlipWork, out ArrayList orgSalesDetailWorkList, CustomSerializeArrayList originList, SalesSlipWork currentSalesSlipWork)
        {
            // 出力パラメータ初期化
            orgSalesSlipWork = null;
            orgSalesDetailWorkList = new ArrayList();

            //-------------------------------------------------
            // 元伝票　売上データ　Find
            //-------------------------------------------------
            foreach (object obj in originList)
            {
                // 売上データ
                if (obj is SalesSlipWork)
                {
                    // 今回伝票と　売上伝票区分(0:売上/1:返品)が異なるもの　または
                    // 　　　　　　赤伝区分(0:黒伝/1:赤伝/2:元黒)が異なるもの　を元伝票とみなす
                    if ((obj as SalesSlipWork).SalesSlipNum != currentSalesSlipWork.SalesSlipNum ||
                         (obj as SalesSlipWork).DebitNoteDiv != currentSalesSlipWork.DebitNoteDiv)
                    {
                        orgSalesSlipWork = (SalesSlipWork)obj;
                        break;
                    }
                }
            }
            //-------------------------------------------------
            // 元伝票　売上明細データ　Find
            //-------------------------------------------------
            if (orgSalesSlipWork != null)
            {
                foreach (object obj in originList)
                {
                    // ArrayListで要素があり、最初の要素がSalesDetailWork
                    if (obj is ArrayList && (obj as ArrayList).Count > 0 && (obj as ArrayList)[0] is SalesDetailWork)
                    {
                        // 「元伝票売上入データの伝票番号と同じ伝票番号を持つ明細のArrayList」を
                        // 「元伝票売上明細データリスト」とみなす
                        if (((obj as ArrayList)[0] as SalesDetailWork).SalesSlipNum == orgSalesSlipWork.SalesSlipNum)
                        {
                            orgSalesDetailWorkList = (ArrayList)obj;
                            break;
                        }
                    }
                }
            }
        }
        # endregion

        # region [在庫数差分反映処理]

        //--- ADD 2009/01/30 M.Kubota --->>>
        /// <summary>
        /// 差分反映データ
        /// </summary>
        private class ReflectCntDifData
        {
            /// <summary>売上データ</summary>
            public SalesSlipWork Slip;
            /// <summary>売上明細データ</summary>
            public SalesDetailWork Detail;
            /// <summary>伝票明細追加情報データ</summary>
            /// <value>売上データに紐付く伝票明細追加情報を設定して下さい</value>
            public SlipDetailAddInfoWork AddInfo;
            /// <summary>元黒・返品元売上明細データ</summary>
            /// <value>修正前明細データでは無く、元黒or返品元明細データを設定して下さい</value>
            public SalesDetailWork OrgDetail;
            /// <summary>計上元売上明細データ</summary>
            public AddUpOrgSalesDetailWork AddUpOrgDetail;
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
            public ReflectCntDifData(SalesSlipWork slip, SalesDetailWork detail,
                                     SlipDetailAddInfoWork addInfo, SalesDetailWork orgDetail,
                                     AddUpOrgSalesDetailWork addUpOrgDetail,
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
                if ((this.AddInfo == null) ||
                    (this.AddInfo != null && this.AddInfo.AddUpRemDiv == 0))
                {
                    // IOWriteCtrlOptWorkの計上残区分に準拠
                    switch (this.Detail.AcptAnOdrStatusSrc)
                    {
                        case 10:  // 見積
                            {
                                this.AddUpRemDiv = crlOpt.EstimateAddUpRemDiv;
                                break;
                            }
                        case 20:  // 受注
                            {
                                this.AddUpRemDiv = crlOpt.AcpOdrrAddUpRemDiv;
                                break;
                            }
                        case 40:  // 出荷
                            {
                                this.AddUpRemDiv = crlOpt.ShipmAddUpRemDiv;
                                break;
                            }
                        default:  // その他…
                            {
                                this.AddUpRemDiv = 0;
                                break;
                            }
                    }
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
        private void ReflectShipmCntDifference(ref StockWork stockWork, ReflectCntDifData data)
        {
            // 計上残区分が 0:残す の場合は通常通り差分数を、1:残さない の場合は計上元明細データの数を対象とする
            double CntDifferenceEx = data.CntDifference;

            // 2009/02/11 MANTIS対応 11389>>>>>>
            //if (data.AddUpRemDiv == 1 && data.AddUpOrgDetail != null)

            //計上残区分が1:残さないで計上売上伝票の削除時は、
            //計上元明細の数量ではなく、計上した明細の数量で在庫マスタの残数を更新する
            // -- UPD 2009/12/28 ---------------------->>>
            //if (data.AddUpRemDiv == 1 && data.AddUpOrgDetail != null && data.WriteDelMode == 0)
            //// 2009/02/11 <<<<<<<<<<<<<<<<<<<<<<
            //{
            //    CntDifferenceEx = data.AddUpOrgDetail.ShipmentCnt;
            //}

            //計上残区分が1:残さないで計上売上伝票の更新時は、
            //計上元明細の数量ではなく、計上した明細の数量で在庫マスタの残数を更新する
            if (data.AddUpRemDiv == 1 && data.AddUpOrgDetail != null)
            {
                //新規作成の場合のみ、在庫マスタの残数を更新する。
                if (data.WriteDelMode == 0 && (data.Detail.ShipmentCnt == data.CntDifference))
                {
                    CntDifferenceEx = data.AddUpOrgDetail.ShipmentCnt;
                }
                else
                {
                    //削除時は在庫マスタの残数の更新は行わない
                    CntDifferenceEx = 0;
                }

            }
            // -- UPD 2009/12/28 ----------------------<<<

            switch (data.Slip.AcptAnOdrStatus)
            {
                case 20:  // 受注
                    {
                        // 受注数量に受注差分数(出荷差分数)を加算する
                        stockWork.AcpOdrCount += data.CntDifference;
                        break;
                    }
                case 30:  // 売上
                    {
                        // 売上の場合 仕入在庫数から売上差分数(出荷差分数)を減算する
                        stockWork.SupplierStock -= data.CntDifference;

                        if ((data.Slip.DebitNoteDiv == 1 && data.OrgDetail != null && data.OrgDetail.AcptAnOdrStatusSrc == 40) ||         // 貸出計上の赤伝の場合(RedWriteメソッド使用時はOrgDetailに元黒がセットされている)
                            (data.Slip.SalesSlipCd == 1 && data.AddUpOrgDetail != null && data.AddUpOrgDetail.AcptAnOdrStatusSrc == 40))  // 貸出計上の返品の場合
                        {
                            // この時は在庫の更新を行わない。

                            // 貸出計上伝票に対する赤伝や返品を行っても、計上元である貸出伝票の
                            // 受注残数を更新していない(仕様)関係上、この時点で在庫マスタに対して
                            // 数量の書き戻しを行ってしまうと、受注残数と在庫マスタの数量に差異が
                            // 発生してしまう。
                        }
                        else
                        {
                            // 受注又は貸出より計上された売上データの場合、該当する項目への加減算を行う
                            switch (data.Detail.AcptAnOdrStatusSrc)
                            {
                                case 20:
                                    {
                                        // 受注計上
                                        //>>>2011/12/08
                                        //// --- UPD m.suzuki 2011/05/20 ---------->>>>>
                                        ////// --- UPD m.suzuki 2011/04/21 ---------->>>>>
                                        //////stockWork.AcpOdrCount -= CntDifferenceEx;
                                        ////// 計上元伝票が削除されていない場合のみ、受注数に加算する
                                        ////if ( data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0 )
                                        ////{
                                        ////stockWork.AcpOdrCount -= CntDifferenceEx;
                                        ////}
                                        ////// --- UPD m.suzuki 2011/04/21 ----------<<<<<
                                        //// 同時入力で0:残すの場合、または計上元伝票が削除されていない場合のみ、受注数に加算する
                                        //if ( (data.AddUpOrgDetail == null && this.IOWriteCtrlOptWork.AcpOdrrAddUpRemDiv == 0) ||
                                        //     (data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) )
                                        //{
                                        //    stockWork.AcpOdrCount -= CntDifferenceEx;
                                        //}
                                        //// --- UPD m.suzuki 2011/05/20 ----------<<<<<

                                        // 受注売上同時入力の場合、または計上元伝票が削除されていない場合のみ、受注数に加算する
                                        if ((data.AddUpOrgDetail == null) ||
                                             (data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) )
                                        {
                                            if (this.IOWriteCtrlOptWork.AcpOdrrAddUpRemDiv == 0)
                                            {
                                                //-------------------------------------------
                                                //-------------------------------------------
                                                // 受注データ計上残区分：残す
                                                //-------------------------------------------
                                            stockWork.AcpOdrCount -= CntDifferenceEx;
                                        }
                                            else
                                            {
                                                //-------------------------------------------
                                                //-------------------------------------------
                                                // 受注データ計上残区分：残さない
                                                //-------------------------------------------

                                                if (data.AddUpOrgDetail == null)
                                                {
                                                    //-------------------------------------------
                                                    // 受注売上同時入力からの計上
                                                    //-------------------------------------------
                                                    #region 計上元情報取得
                                                    SalesDetailWork acptDetail = null;
                                                    if ((this._sameInputAcptList != null) && (this._sameInputAcptList.Count != 0))
                                                    {

                                                        // 計上元情報取得
                                                        ArrayList targetDetailList = new ArrayList();
                                                        if (this._sameInputAcptList != null && this._sameInputAcptList.Count > 0)
                                                        {
                                                            for (int i = 0; i < this._sameInputAcptList.Count; i++)
                                                            {
                                                                ArrayList tempList = new ArrayList();
                                                                tempList = (ArrayList)this._sameInputAcptList[i];

                                                                for (int j = 0; j < tempList.Count; j++)
                                                                {
                                                                    if (tempList[j] is ArrayList &&
                                                                        ((ArrayList)tempList[j]).Count > 0 &&
                                                                        ((ArrayList)tempList[j])[0] is SalesDetailWork)
                                                                    {
                                                                        targetDetailList.AddRange(tempList[j] as ArrayList);
                                                                        if (targetDetailList != null) break;
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        // 対象計上元明細取得
                                                        List<SalesDetailWork> list = new List<SalesDetailWork>((SalesDetailWork[])targetDetailList.ToArray(typeof(SalesDetailWork)));
                                                        acptDetail = list.Find(
                                                            delegate(SalesDetailWork detail)
                                                            {
                                                                if (detail.DtlRelationGuid == data.Detail.DtlRelationGuid)
                                                                {
                                                                    return true;
                                                                }
                                                                else
                                                                {
                                                                    return false;
                                                                }
                                                            }
                                                        );
                                                    }
                                                    #endregion

                                                    // 受注売上同時入力　計上元数量と計上先数量が一致する場合
                                                    if (acptDetail != null)
                                                    {
                                                        if ((data.AddUpOrgDetail == null) && (acptDetail != null) && (CntDifferenceEx == acptDetail.ShipmentCnt))
                                                        {
                                                            stockWork.AcpOdrCount -= data.Detail.ShipmentCnt;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //-------------------------------------------
                                                    // 受注単発入力からの計上
                                                    //-------------------------------------------
                                                    stockWork.AcpOdrCount -= CntDifferenceEx;
                                                }
                                            }
                                        }
                                        //<<<2011/12/08
                                        break;
                                    }
                                case 40:
                                    {
                                        // 貸出計上
                                        // --- UPD m.suzuki 2011/05/20 ---------->>>>>
                                        //// --- UPD m.suzuki 2011/04/21 ---------->>>>>
                                        ////stockWork.ShipmentCnt -= CntDifferenceEx;
                                        //// 計上元伝票が削除されていない場合のみ、貸出数(未計上)に加算する
                                        //if ( data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0 )
                                        //{
                                        //    stockWork.ShipmentCnt -= CntDifferenceEx;
                                        //}
                                        //// --- UPD m.suzuki 2011/04/21 ----------<<<<<
                                        // 同時入力で0:残すの場合、または計上元伝票が削除されていない場合のみ、貸出数(未計上)に加算する
                                        if ( (data.AddUpOrgDetail == null && this.IOWriteCtrlOptWork.ShipmAddUpRemDiv == 0) ||
                                             (data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) )
                                        {
                                            stockWork.ShipmentCnt -= CntDifferenceEx;
                                        }
                                        // --- UPD m.suzuki 2011/05/20 ----------<<<<<
                                        break;
                                    }
                            }
                        }
                            break;
                    }
                case 40:  // 出荷
                    {
                        // 出荷数に出荷差分数を加算する
                        stockWork.ShipmentCnt += data.CntDifference;

                        // 受注より計上された出荷データの場合、該当する項目への加減算を行う
                        // --- UPD m.suzuki 2011/05/20 ---------->>>>>
                        //// --- UPD m.suzuki 2011/04/21 ---------->>>>>
                        ////if (data.Detail.AcptAnOdrStatusSrc == 20)
                        //if ( data.Detail.AcptAnOdrStatusSrc == 20 && data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0 )
                        //// --- UPD m.suzuki 2011/04/21 ----------<<<<<
                        // 同時入力で0:残すの場合、または計上元伝票が削除されていない場合のみ、受注数に加算する
                        if ( (data.Detail.AcptAnOdrStatusSrc == 20) &&
                             ((data.AddUpOrgDetail == null && this.IOWriteCtrlOptWork.AcpOdrrAddUpRemDiv == 0) ||
                               (data.AddUpOrgDetail != null && data.AddUpOrgDetail.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0)) )
                        // --- UPD m.suzuki 2011/05/20 ----------<<<<<
                        {
                            stockWork.AcpOdrCount -= CntDifferenceEx;
                        }
                        break;
                    }
            }
        }
        //--- ADD 2009/01/30 M.Kubota ---<<<

        # region [--- DEL 2009/01/30 M.Kubota ---]
        //private void ReflectShipmCntDifference(ref StockWork stockWork, SalesSlipWork salesSlipWork, SalesDetailWork salesDetailWork, SalesDetailWork orgSalesDetailWork, double shipmCntDifference)
        //{
        //    switch (salesSlipWork.AcptAnOdrStatus)
        //    {
        //        case 20:  // 受注
        //            {
        //                // 受注数量に受注差分数(出荷差分数)を加算する
        //                stockWork.AcpOdrCount += shipmCntDifference;
        //                break;
        //            }
        //        case 30:  // 売上
        //            {
        //                // 売上の場合 仕入在庫数から売上差分数(出荷差分数)を減算する
        //                stockWork.SupplierStock -= shipmCntDifference;

        //                // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
        //                switch (salesDetailWork.AcptAnOdrStatusSrc)
        //                {
        //                    case 20:
        //                        {
        //                            // 受注計上
        //                            stockWork.AcpOdrCount -= shipmCntDifference;
        //                            break;
        //                        }
        //                    case 40:
        //                        {
        //                            // 出荷計上
        //                            stockWork.ShipmentCnt -= shipmCntDifference;
        //                            break;
        //                        }
        //                }

        //                # region [--- DEL 2009/01/19 M.Kubota ---]
        //                // これを行ってしまうと、受注の売上明細の受注残数が 0 なのに、在庫マスタの受注数が増加するので
        //                // 結果的に数の合わない受注や出荷が発生してしまうので削除する
        //                //// 受注計上・出荷計上伝票を元にした返品伝票を作成する場合
        //                //if (orgSalesDetailWork != null && 
        //                //    orgSalesDetailWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatusSrc &&
        //                //    orgSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNumSrc)
        //                //{
        //                //    // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
        //                //    switch (orgSalesDetailWork.AcptAnOdrStatusSrc)
        //                //    {
        //                //        case 20:
        //                //            {
        //                //                // 受注計上
        //                //                stockWork.AcpOdrCount -= shipmCntDifference;
        //                //                break;
        //                //            }
        //                //        case 40:
        //                //            {
        //                //                // 出荷計上
        //                //                stockWork.ShipmentCnt -= shipmCntDifference;
        //                //                break;
        //                //            }
        //                //    }
        //                //}
        //                # endregion
        //                break;
        //            }
        //        case 40:  // 出荷
        //            {
        //                // 出荷数に出荷差分数を加算する
        //                stockWork.ShipmentCnt += shipmCntDifference;

        //                // 受注より計上された出荷データの場合、該当する項目への加減算を行う
        //                if (salesDetailWork.AcptAnOdrStatusSrc == 20)
        //                {
        //                    stockWork.AcpOdrCount -= shipmCntDifference;
        //                }
        //                break;
        //            }
        //    }
        //}
        # endregion
        # endregion

        # region [仮削除]
        ///// <summary>
        ///// 返品時の在庫パラメータ作成処理（在庫検索からの返品処理に対応）
        ///// </summary>
        ///// <param name="paraList"></param>
        ///// <param name="stockList">在庫ワークList</param>
        ///// <param name="productStockCommonList">製番在庫共通ワークList</param>
        ///// <param name="position">売上データ位置</param>
        ///// <param name="detailPosition">売上明細データ位置</param>
        ///// <returns></returns>
        //private int MakeReturnStockPara(CustomSerializeArrayList paraList, out ArrayList stockList, ArrayList productStockCommonList, Int32 position, Int32 detailPosition)
        //{
        //    //出力パラメータList(在庫)
        //    stockList = new ArrayList();

        //    //更新パラメータクラス格納用(在庫)
        //    StockWork stockWork = null;

        //    //売上データワーク格納用(ヘッダ・明細)
        //    SalesSlipWork wkSalesSlipWork = paraList[position] as SalesSlipWork;
        //    SalesDetailWork wkSalesDetailWork = null;

        //    ArrayList wkSalesDetailWorkList = paraList[detailPosition] as ArrayList;

        //    //データ比較クラス(在庫)
        //    StockWorkSecComparer stockWorkSecComparer = new StockWorkSecComparer();

        //    //●在庫マスタ更新パラメータ格納処理
        //    #region[在庫マスタ更新パラメータ格納]
        //    for (int i = 0; i < wkSalesDetailWorkList.Count; i++)
        //    {
        //        wkSalesDetailWork = wkSalesDetailWorkList[i] as SalesDetailWork;

        //        stockWork = new StockWork();

        //        //在庫管理有無区分・売上在庫取寄区分・出荷数チェック
        //        if (wkSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
        //            (wkSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && wkSalesDetailWork.SalesOrderDivCd == 0) ||
        //            wkSalesDetailWork.ShipmentCnt == 0) continue;

        //        //在庫マスタ ← 売上ヘッダ
        //        stockWork.EnterpriseCode = wkSalesSlipWork.EnterpriseCode;     //企業コード
        //        stockWork.SectionCode = wkSalesSlipWork.StockUpdateSecCd;      //在庫更新拠点コード
        //        stockWork.LastSalesDate = wkSalesSlipWork.SalesDate;           //最終売上年月日　←　売上日

        //        //在庫マスタ ← 売上明細
        //        stockWork.GoodsMakerCd = wkSalesDetailWork.GoodsMakerCd;                  // 商品メーカーコード
        //        stockWork.MakerName = wkSalesDetailWork.MakerName;                        // メーカー名称
        //        stockWork.GoodsNo = wkSalesDetailWork.GoodsNo;                            // 商品番号
        //        stockWork.GoodsName = wkSalesDetailWork.GoodsName;                        // 商品名称
        //        stockWork.LargeGoodsGanreCode = wkSalesDetailWork.LargeGoodsGanreCode;    // 商品区分グループコード
        //        stockWork.LargeGoodsGanreName = wkSalesDetailWork.LargeGoodsGanreName;    // 商品区分グループ名称
        //        stockWork.MediumGoodsGanreCode = wkSalesDetailWork.MediumGoodsGanreCode;  // 商品区分コード
        //        stockWork.MediumGoodsGanreName = wkSalesDetailWork.MediumGoodsGanreName;  // 商品区分名称
        //        stockWork.DetailGoodsGanreCode = wkSalesDetailWork.DetailGoodsGanreCode;  // 商品区分詳細コード
        //        stockWork.DetailGoodsGanreName = wkSalesDetailWork.DetailGoodsGanreName;  // 商品区分詳細名称
        //        stockWork.BLGoodsCode = wkSalesDetailWork.BLGoodsCode;                    // BL商品コード
        //        stockWork.BLGoodsFullName = wkSalesDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)
        //        stockWork.EnterpriseGanreCode = wkSalesDetailWork.EnterpriseGanreCode;    // 自社分類コード
        //        stockWork.EnterpriseGanreName = wkSalesDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)
        //        stockWork.WarehouseCode = wkSalesDetailWork.WarehouseCode;                // 倉庫コード
        //        stockWork.WarehouseName = wkSalesDetailWork.WarehouseName;                // 倉庫名称
        //        stockWork.WarehouseShelfNo = wkSalesDetailWork.WarehouseShelfNo;          // 倉庫棚番

        //        //仕入在庫数・出荷数・受注数の加減算処理

        //        //在庫パラメータListにデータがある時
        //        if (stockList.Count > 0)
        //        {
        //            stockList.Sort(stockWorkSecComparer);
        //            int indexCount = stockList.BinarySearch(stockWork, stockWorkSecComparer);

        //            //メーカーコード・商品コード・拠点コードが同一のデータがある時
        //            if (indexCount >= 0 && indexCount <= wkSalesDetailWorkList.Count)
        //            {
        //                stockWork = stockList[indexCount] as StockWork;
        //            }
        //        }

        //        switch (wkSalesSlipWork.AcptAnOdrStatus)
        //        {
        //            case 20:  // 受注
        //                {
        //                    if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Sales)
        //                    {
        //                        // 受注数量に受注差分数(出荷差分数)を加算する
        //                        stockWork.AcpOdrCount += wkSalesDetailWork.ShipmCntDifference;
        //                    }
        //                    else if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
        //                    {
        //                        //※ 受注取消し＝削除なので設定される事は無い…
        //                    }
        //                }
        //            case 30:  // 売上
        //                {
        //                    if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Sales)
        //                    {
        //                        // 売上の場合 仕入在庫数から売上差分数(出荷差分数)を減算する
        //                        stockWork.SupplierStock -= wkSalesDetailWork.ShipmCntDifference;

        //                        // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
        //                        switch (wkSalesDetailWork.AcptAnOdrStatusSrc)
        //                        {
        //                            case 20:
        //                                {
        //                                    // 受注計上
        //                                    stockWork.AcpOdrCount -= wkSalesDetailWork.ShipmCntDifference;
        //                                }
        //                            case 40:
        //                                {
        //                                    // 出荷計上
        //                                    stockWork.ShipmentCnt -= wkSalesDetailWork.ShipmCntDifference;
        //                                }
        //                        }
        //                    }
        //                    else if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
        //                    {
        //                        // 返品の場合 仕入在庫数へ売上差分数(出荷差分数)を加算する
        //                        stockWork.SupplierStock += wkSalesDetailWork.ShipmCntDifference;

        //                        // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
        //                        switch (wkSalesDetailWork.AcptAnOdrStatusSrc)
        //                        {
        //                            case 20:
        //                                {
        //                                    // 受注計上
        //                                    stockWork.AcpOdrCount += wkSalesDetailWork.ShipmCntDifference;
        //                                }
        //                            case 40:
        //                                {
        //                                    // 出荷計上
        //                                    stockWork.ShipmentCnt += wkSalesDetailWork.ShipmCntDifference;
        //                                }
        //                        }
        //                    }
        //                }
        //            case 40:  // 出荷
        //                {
        //                    if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Sales)
        //                    {
        //                        // 出荷数に出荷差分数を加算する
        //                        stockWork.ShipmentCnt += wkSalesDetailWork.ShipmCntDifference;
        //                    }
        //                    else if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
        //                    {
        //                        //※ 出荷取消し＝削除なので設定される事は無い…
        //                    }
        //                }
        //        }

        //        stockList.Add(stockWork);
        //    }
        //    #endregion

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}

        ///// <summary>
        ///// 在庫マスタ更新データクラス生成
        ///// </summary>
        ///// <param name="paraList">更新対象パラメータリスト</param>
        ///// <param name="stockList">在庫マスタ更新パラメータ</param>
        ///// <param name="position">売上データ格納位置</param>
        ///// <param name="detailPosition">売上明細データ格納位置</param>
        ///// <param name="mode">0:加算 1:減算</param>
        ///// <returns>STATUS</returns>
        //private int MakeStockWork(CustomSerializeArrayList paraList, out ArrayList stockList, Int32 position, Int32 detailPosition, Int32 mode)
        //{
        //    //出力パラメータList(在庫)
        //    stockList = new ArrayList();

        //    //更新パラメータクラス格納用(在庫)
        //    StockWork stockWork = null;

        //    //売上データワーク格納用(ヘッダ・明細)
        //    SalesSlipWork wkSalesSlipWork = paraList[position] as SalesSlipWork;
        //    SalesDetailWork wkSalesDetailWork = null;
        //    ArrayList wkSalesDetailWorkList = paraList[detailPosition] as ArrayList;

        //    //●在庫マスタ更新パラメータ格納処理
        //    #region[在庫マスタ更新パラメータ格納]
        //    for (int i = 0; i < wkSalesDetailWorkList.Count; i++)
        //    {
        //        wkSalesDetailWork = wkSalesDetailWorkList[i] as SalesDetailWork;

        //        stockWork = new StockWork();

        //        //在庫管理有無区分・売上数チェック
        //        //--- DEL 2008/06/06 M.Kubota --->>>
        //        //if (wkSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Unmanage ||
        //        //    (wkSalesDetailWork.StockMngExistCd == (int)ConstantManagement_Mobile.ct_StockMngExistCd.Manage && wkSalesDetailWork.SalesOrderDivCd == 0) ||
        //        //    wkSalesDetailWork.ShipmentCnt == 0) continue;
        //        //--- DEL 2008/06/06 M.Kubota ---<<<

        //        if (!wkSalesDetailWork.StockUpdateDiv) continue;  //ADD 2008/06/06 M.Kubota

        //        // 在庫マスタ ← 売上データ
        //        stockWork.EnterpriseCode = wkSalesSlipWork.EnterpriseCode;     //企業コード
        //        //stockWork.SectionCode = wkSalesSlipWork.StockUpdateSecCd;      //在庫更新拠点コード  //DEL 2008/06/06 M.Kubota
        //        stockWork.SectionCode = wkSalesSlipWork.SectionCode;           //拠点コード            //ADD 2008/06/06 M.Kubota
        //        stockWork.LastSalesDate = wkSalesSlipWork.SalesDate;           //最終売上年月日　←　売上日

        //        // 在庫マスタ ← 売上明細データ
        //        stockWork.GoodsMakerCd = wkSalesDetailWork.GoodsMakerCd;                  // 商品メーカーコード
        //        stockWork.GoodsNo = wkSalesDetailWork.GoodsNo;                            // 商品番号
                
        //        //--- DEL 2008/06/06 M.Kubota --->>>
        //        //stockWork.MakerName = wkSalesDetailWork.MakerName;                        // メーカー名称
        //        //stockWork.GoodsName = wkSalesDetailWork.GoodsName;                        // 商品名称
        //        //stockWork.LargeGoodsGanreCode = wkSalesDetailWork.LargeGoodsGanreCode;    // 商品区分グループコード
        //        //stockWork.LargeGoodsGanreName = wkSalesDetailWork.LargeGoodsGanreName;    // 商品区分グループ名称
        //        //stockWork.MediumGoodsGanreCode = wkSalesDetailWork.MediumGoodsGanreCode;  // 商品区分コード
        //        //stockWork.MediumGoodsGanreName = wkSalesDetailWork.MediumGoodsGanreName;  // 商品区分名称
        //        //stockWork.GoodsShortName = wkSalesDetailWork.GoodsShortName;              // 商品名略称
        //        //stockWork.DetailGoodsGanreCode = wkSalesDetailWork.DetailGoodsGanreCode;  // 商品区分詳細コード
        //        //stockWork.DetailGoodsGanreName = wkSalesDetailWork.DetailGoodsGanreName;  // 商品区分詳細名称
        //        //stockWork.BLGoodsCode = wkSalesDetailWork.BLGoodsCode;                    // BL商品コード
        //        //stockWork.BLGoodsFullName = wkSalesDetailWork.BLGoodsFullName;            // BL商品コード名称(全角)
        //        //stockWork.EnterpriseGanreCode = wkSalesDetailWork.EnterpriseGanreCode;    // 自社分類コード
        //        //stockWork.EnterpriseGanreName = wkSalesDetailWork.EnterpriseGanreName;    // 自社分類コード名称(全角)
        //        //--- DEL 2008/06/06 M.Kubota ---<<<
        //        stockWork.WarehouseCode = wkSalesDetailWork.WarehouseCode;                // 倉庫コード
        //        stockWork.WarehouseName = wkSalesDetailWork.WarehouseName;                // 倉庫名称
        //        stockWork.WarehouseShelfNo = wkSalesDetailWork.WarehouseShelfNo;          // 倉庫棚番

        //        double shipmCntDifference = wkSalesDetailWork.ShipmCntDifference * ((mode == 0) ? 1 : -1);

        //        // 受注ステータスにて分岐
        //        switch (wkSalesSlipWork.AcptAnOdrStatus)
        //        {
        //            case 20:  // 受注
        //                {
        //                    // 受注数量に受注差分数(出荷差分数)を加算(減算)する
        //                    stockWork.AcpOdrCount += shipmCntDifference;

        //                    //if (mode == 0)
        //                    //{
        //                    //    // 受注数量に受注差分数(出荷差分数)を加算する
        //                    //    stockWork.AcpOdrCount += wkSalesDetailWork.ShipmCntDifference;
        //                    //}
        //                    //else if (mode == 1)
        //                    //{
        //                    //    // 受注数量に受注差分数(出荷差分数)を減算する
        //                    //    stockWork.AcpOdrCount -= wkSalesDetailWork.ShipmCntDifference;
        //                    //}

        //                    break;
        //                }
        //            case 30:  // 売上
        //                {
        //                    if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Sales)
        //                    {
        //                        // 売上の場合 仕入在庫数から売上差分数(出荷差分数)を減算する
        //                        stockWork.SupplierStock -= shipmCntDifference;

        //                        // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
        //                        switch (wkSalesDetailWork.AcptAnOdrStatusSrc)
        //                        {
        //                            case 20:
        //                                {
        //                                    // 受注計上
        //                                    stockWork.AcpOdrCount -= shipmCntDifference;
        //                                    break;
        //                                }
        //                            case 40:
        //                                {
        //                                    // 出荷計上
        //                                    stockWork.ShipmentCnt -= shipmCntDifference;
        //                                    break;
        //                                }
        //                        }                                
        //                    }
        //                    else if (wkSalesSlipWork.SalesSlipCd == (int)ConstantManagement_Mobile.ct_SalesSlipCd.Return)
        //                    {
        //                        // 返品の場合 仕入在庫数へ売上差分数(出荷差分数)を加算する
        //                        stockWork.SupplierStock += shipmCntDifference;

        //                        // 受注又は出荷より計上された売上データの場合、該当する項目への加減算を行う
        //                        switch (wkSalesDetailWork.AcptAnOdrStatusSrc)
        //                        {
        //                            case 20:
        //                                {
        //                                    // 受注計上
        //                                    stockWork.AcpOdrCount += shipmCntDifference;
        //                                    break;
        //                                }
        //                            case 40:
        //                                {
        //                                    // 出荷計上
        //                                    stockWork.ShipmentCnt += shipmCntDifference;
        //                                    break;
        //                                }
        //                        }
        //                    }

        //                    break;
        //                }
        //            case 40:  // 出荷
        //                {
        //                    // 出荷数に出荷差分数を加算(減算)する
        //                    stockWork.ShipmentCnt += shipmCntDifference;

        //                    //if (mode == 0)
        //                    //{
        //                    //    // 出荷数に出荷差分数を加算する
        //                    //    stockWork.ShipmentCnt += wkSalesDetailWork.ShipmCntDifference;
        //                    //}
        //                    //else if (mode == 1)
        //                    //{
        //                    //    // 出荷数に出荷差分数を加算する
        //                    //    stockWork.ShipmentCnt -= wkSalesDetailWork.ShipmCntDifference;
        //                    //}

        //                    break;
        //                }
        //        }

        //        /*
        //        if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //            wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //        {
        //            //更新処理・削除処理にて分岐
        //            if (mode == 0)
        //            {
        //                stockWork.SupplierStock += wkSalesDetailWork.StockCount; //売上在庫数　←　売上数
        //            }
        //            else if (mode == 1)
        //            {
        //                stockWork.SupplierStock += -wkSalesDetailWork.StockCount; //売上在庫数　←　売上数
        //            }
        //        }
        //        else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Trust &&
        //                 wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.Normal)
        //        {
        //            if (mode == 0)
        //            {
        //                stockWork.TrustCount += wkSalesDetailWork.StockCount; //受託数　←　売上数
        //            }
        //            else if (mode == 1)
        //            {
        //                stockWork.TrustCount += -wkSalesDetailWork.StockCount; //受託数　←　売上数
        //            }
        //        }
        //        //受託計上売上の場合
        //        else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                 wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.TrustBuy)
        //        {
        //            if (mode == 0)
        //            {
        //                stockWork.SupplierStock += wkSalesDetailWork.StockCount;    //売上在庫数　←　売上数
        //                stockWork.TrustCount += -wkSalesDetailWork.StockCount;      //受託数　←　売上数
        //            }
        //            else if (mode == 1)
        //            {
        //                stockWork.SupplierStock += -wkSalesDetailWork.StockCount;   //売上在庫数　←　売上数
        //                stockWork.TrustCount += wkSalesDetailWork.StockCount;       //受託数　←　売上数
        //            }
        //        }
        //        else if (wkSalesSlipWork.SupplierFormal == (int)ConstantManagement_Mobile.ct_SupplierFormal.Purchase &&
        //                 wkSalesSlipWork.TrustAddUpSpCd == (int)ConstantManagement_Mobile.ct_TrustAddUpSpCd.AutoTrustBuy)
        //        {
        //            stockWork.SupplierStock += wkSalesDetailWork.StockCount;        //売上在庫数　←　売上数
        //            stockWork.TrustCount += -wkSalesDetailWork.StockCount;          //受託数　←　売上数
        //        }
        //        */

        //        stockList.Add(stockWork);

        //    }
        //    #endregion

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //}

        ///// <summary>
        ///// 在庫マスタの差分を抽出します　※未使用
        ///// </summary>
        ///// <param name="oldSalesWorkList">修正前在庫マスタパラメータ</param>
        ///// <param name="stockWorkParaList">修正後在庫マスタ更新パラメータ</param>
        ///// <param name="stockWorkUpdateList">更新在庫マスタパラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 在庫マスタの差分を抽出します</br>
        ///// <br>Programmer : 21112　久保田　誠</br>
        ///// <br>Date       : 2007.02.21</br>
        //private int MakeStockWorkAdd(ArrayList oldSalesWorkList, ArrayList stockWorkList, out ArrayList stockWorkUpdateList)
        //{
        //    //出力パラメータList(在庫)
        //    stockWorkUpdateList = new ArrayList();

        //    //更新パラメータ格納用(在庫)
        //    StockWork oldStockWork = null;
        //    StockWork stockWork = null;

        //    //売上在庫数・受託数
        //    double supplierStock;
        //    double trustCount;

        //    //該当データなしフラグ
        //    bool flg;

        //    //●在庫数の差分計算(追加データはそのまま)
        //    for (int i = 0; i < oldSalesWorkList.Count; i++)
        //    {
        //        oldStockWork = oldSalesWorkList[i] as StockWork;

        //        flg = false;

        //        for (int x = 0; x < stockWorkList.Count; x++)
        //        {
        //            stockWork = stockWorkList[x] as StockWork;

        //            if (oldStockWork.MakerCode == stockWork.MakerCode && oldStockWork.GoodsCode == stockWork.GoodsCode &&
        //                oldStockWork.SectionCode == stockWork.SectionCode && oldStockWork.StockUnitPrice == stockWork.StockUnitPrice)
        //            {
        //                supplierStock = 0;
        //                trustCount = 0;
        //                //差分抽出
        //                supplierStock = stockWork.SupplierStock - oldStockWork.SupplierStock; //売上在庫数
        //                trustCount = stockWork.TrustCount - oldStockWork.TrustCount;          //受託数

        //                stockWork.SupplierStock = supplierStock;
        //                stockWork.TrustCount = trustCount;

        //                //差分抽出データ格納
        //                stockWorkUpdateList.Add(stockWork);

        //                flg = true;
        //                break;
        //            }
        //        }

        //        if (flg == false)
        //        {
        //            supplierStock = 0;
        //            trustCount = 0;
        //            //削除データをマイナスする
        //            supplierStock = -oldStockWork.SupplierStock;
        //            trustCount = -oldStockWork.TrustCount;

        //            oldStockWork.SupplierStock = supplierStock;
        //            oldStockWork.TrustCount = trustCount;

        //            //削除データ格納
        //            stockWorkUpdateList.Add(oldStockWork);
        //        }
        //    }

        //    //●新規追加データのチェック
        //    for (int i = 0; i < stockWorkList.Count; i++)
        //    {
        //        stockWork = stockWorkList[i] as StockWork;

        //        flg = false;

        //        for (int x = 0; x < oldSalesWorkList.Count; x++)
        //        {
        //            oldStockWork = oldSalesWorkList[x] as StockWork;

        //            if (stockWork.MakerCode == oldStockWork.MakerCode && stockWork.GoodsCode == oldStockWork.GoodsCode &&
        //                stockWork.SectionCode == oldStockWork.SectionCode && stockWork.StockUnitPrice == oldStockWork.StockUnitPrice)
        //            {
        //                flg = true;
        //                break;
        //            }
        //        }

        //        if (flg == false)
        //        {
        //            //新規追加データをそのまま追加
        //            stockWorkUpdateList.Add(stockWork);
        //        }
        //    }

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}

        ///// <summary>
        ///// 在庫マスタの差分を抽出します(受託計上伝票修正時)　※未使用
        ///// </summary>
        ///// <param name="oldSalesWorkList">修正前在庫マスタパラメータ</param>
        ///// <param name="stockWorkParaList">修正後在庫マスタ更新パラメータ</param>
        ///// <param name="stockWorkUpdateList">更新在庫マスタパラメータ</param>
        ///// <returns></returns>
        ///// <br>Note       : 在庫マスタの差分を抽出します(受託計上伝票修正時)</br>
        ///// <br>Programmer : 21112　久保田　誠</br>
        ///// <br>Date       : 2007.02.26</br>
        /*
        private int MakeTrustAddStockWork(ArrayList oldSalesWorkList, ArrayList stockWorkList, out ArrayList stockWorkUpdateList)
        {
            //出力パラメータList(在庫)
            stockWorkUpdateList = new ArrayList();

            //更新パラメータ格納用(在庫)
            StockWork oldStockWork = null;
            StockWork stockWork = null;

            //売上在庫数
            double supplierStock;
            double trustCount;

            //該当データなしフラグ
            bool flg;

            //●在庫数の差分計算(追加データはそのまま)
            for (int i = 0; i < oldSalesWorkList.Count; i++)
            {
                oldStockWork = oldSalesWorkList[i] as StockWork;

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
                        supplierStock = stockWork.SupplierStock - oldStockWork.SupplierStock; //売上在庫数
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

                for (int x = 0; x < oldSalesWorkList.Count; x++)
                {
                    oldStockWork = oldSalesWorkList[x] as StockWork;

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
        /// <br>Programmer : 21112　久保田　誠</br>
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
        /// <param name="list">売上・在庫書込結果List</param>
        /// <param name="product_Position">製番在庫データ格納位置</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 製番在庫の書込結果Listを生成します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
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
        /// <br>Programmer : 21112　久保田　誠</br>
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
        /// <br>Programmer : 21112　久保田　誠</br>
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
        /// <br>Programmer : 21112　久保田　誠</br>
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
    /// <br>Programmer : 21112　久保田　誠</br>
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
            get { return this._DifferenceUpdate;}
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
            //--- ADD 2009/01/16 M.Kubota --->>>
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

            // 受払元行番号
            //if (result == 0)
            //{
            //    result = cx.AcPaySlipRowNo.CompareTo(cy.AcPaySlipRowNo);
            //}

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

            // 売上単価
            if (result == 0)
            {
                result = cx.SalesUnPrcTaxExcFl.CompareTo(cy.SalesUnPrcTaxExcFl);
            }

            // 出荷数
            int ShipmentCntDiff = cx.ShipmentCnt.CompareTo(cy.ShipmentCnt);

            // 仕入金額
            int StockPriceDiff = cx.StockPrice.CompareTo(cy.StockPrice);

            // 売上金額
            int SalesMoneyDiff = cx.SalesMoney.CompareTo(cy.SalesMoney);

            //result += ShipmentCntDiff + StockPriceDiff + SalesMoneyDiff;

            if (ShipmentCntDiff + StockPriceDiff + SalesMoneyDiff != 0)
            {
                this._DifferenceUpdate = true;
            }
            # endregion
            //--- ADD 2009/01/16 M.Kubota ---<<<

            //結果を返す
            return result;
        }
    }

    #region [DELETE]
    /*
    /// <summary>
    /// 在庫マスタ比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ比較クラス</br>
    /// <br>Programmer : 21112　久保田　誠</br>
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
            //売上単価
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
    /// <br>Programmer : 21112　久保田　誠</br>
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
            //売上単価
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

    # region [--- DEL 2009/01/30 M.Kubota ---]
# if false
    # region [DetailsSelector クラス]
    /// <summary>
    /// 売上明細セレクタクラス
    /// </summary>
    /// <remarks>
    /// <br>指定した売上伝票明細に対応する、同一キーの売上伝票明細を取得する機能を提供します</br>
    /// </remarks>
    internal class SalesDetailsSelector
    {
        // 明細リスト
        private ArrayList _details;
        // 明細ディクショナリ
        private System.Collections.Generic.Dictionary<SalesDetailKey, SalesDetailWork> _detailDic;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="detailsList"></param>
        public SalesDetailsSelector(ArrayList detailsList)
        {
            _details = detailsList;

            if (_details != null)
            {
                _detailDic = new System.Collections.Generic.Dictionary<SalesDetailKey, SalesDetailWork>();

                foreach (object detail in _details)
                {
                    if (detail is SalesDetailWork)
                    {
                        // 売上明細キー構造体をKeyにして、仕入明細のディクショナリに追加
                        _detailDic.Add(new SalesDetailKey(detail as SalesDetailWork), detail as SalesDetailWork);
                    }
                }
            }
        }
        /// <summary>
        /// 明細検索処理
        /// </summary>
        /// <param name="salesDetailWork"></param>
        /// <returns></returns>
        public SalesDetailWork Find(SalesDetailWork salesDetailWork)
        {
            if (_details != null)
            {
                SalesDetailKey key = new SalesDetailKey(salesDetailWork);

                if (_detailDic.ContainsKey(key))
                {
                    // 指定されたSalesDetailWorkと同一keyの売上明細を返す
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

        # region [売上明細キー構造体]
        /// <summary>
        /// 売上明細キー構造体
        /// </summary>
        private struct SalesDetailKey
        {
            /// <summary>売上行番号</summary>
            private int _salesRowNo;
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>倉庫コード</summary>
            private string _warehouseCode;
            /// <summary>メーカーコード</summary>
            private int _goodsMakerCd;
            /// <summary>商品番号</summary>
            private string _goodsNo;

            /// <summary>
            /// 売上行番号
            /// </summary>
            public int SalesRowNo
            {
                get { return _salesRowNo; }
                set { _salesRowNo = value; }
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
            /// <param name="salesRowNo">売上行番号</param>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="warehouseCode">倉庫コード</param>
            /// <param name="goodsMakerCd">メーカーコード</param>
            /// <param name="goodsNo">商品番号</param>
            public SalesDetailKey(int salesRowNo, string sectionCode, string warehouseCode, int goodsMakerCd, string goodsNo)
            {
                _salesRowNo = salesRowNo;
                _sectionCode = sectionCode;
                _warehouseCode = warehouseCode;
                _goodsMakerCd = goodsMakerCd;
                _goodsNo = goodsNo;
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="salesDetailWork">売上明細データクラス</param>
            public SalesDetailKey(SalesDetailWork salesDetailWork)
            {
                _salesRowNo = salesDetailWork.SalesRowNo;
                _sectionCode = salesDetailWork.SectionCode.TrimEnd();
                _warehouseCode = salesDetailWork.WarehouseCode.TrimEnd();
                _goodsMakerCd = salesDetailWork.GoodsMakerCd;
                _goodsNo = salesDetailWork.GoodsNo.TrimEnd();
            }
        }
        # endregion
    }
    # endregion
# endif    
    # endregion
}
