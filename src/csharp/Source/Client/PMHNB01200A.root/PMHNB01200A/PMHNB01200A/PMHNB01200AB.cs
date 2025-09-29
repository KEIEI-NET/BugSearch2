using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
//using Broadleaf.Application.Common;
//using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Library.Globarization;

using System.Data;
//using Broadleaf.Application.Remoting;
//using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Library.Resources;
//using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上データ読み込みクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データ読み込みを行うクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// </remarks>
    internal class SalesSlipReader
    {
        private IIOWriteControlDB _iIOWriteControlDB;

        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        private enum OptWorkSettingType : int
        {
            /// <summary>登録</summary>
            Write = 0,
            /// <summary>読込</summary>
            Read = 1,
            /// <summary>削除</summary>
            Delete = 2,
        }

        /// <summary>
        /// 売上データ読み込み処理
        /// </summary>
        /// <param name="logicalMode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <returns></returns>
        public int ReadSalesSlip( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<AcceptOdrCarWork> acceptOdrCarList )
        {
            List<SalesDetailWork> addUpSrcDetailList;
            SearchDepsitMain depsitMain;
            SearchDepositAlw depositAlw; 
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWorkList;
            List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList;
            List<StockWork> stockWorkList;

            return ReadSalesSlip( logicalMode, enterpriseCode, acptAnOdrStatus, salesSlipNum, 
                                  out salesSlip, out salesDetailList, 
                                  out addUpSrcDetailList, 
                                  out depsitMain, out depositAlw, 
                                  out stockSlipWorkList, out stockDetailWorkList, 
                                  out addUpSrcStockDetailWorkList, 
                                  out stockWorkList, 
                                  out acceptOdrCarList );
        }

        /// <summary>
        /// 売上データ読み込み処理
        /// </summary>
        /// <param name="logicalMode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="addUpSrcDetailList"></param>
        /// <param name="depsitMain"></param>
        /// <param name="depositAlw"></param>
        /// <param name="stockSlipWorkList"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="addUpSrcStockDetailWorkList"></param>
        /// <param name="stockWorkList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <returns></returns>
        public int ReadSalesSlip( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<SalesDetailWork> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCarWork> acceptOdrCarList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesSlip = null;
            salesDetailList = null;
            addUpSrcDetailList = null;
            depsitMain = null;
            depositAlw = null;
            stockSlipWorkList = null;
            stockDetailWorkList = null;
            addUpSrcStockDetailWorkList = null;
            stockWorkList = null;
            acceptOdrCarList = null;

            // パラメータ
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBReadWork readPara = new IOWriteMAHNBReadWork();
            readPara.EnterpriseCode = enterpriseCode;
            readPara.AcptAnOdrStatus = acptAnOdrStatus;
            readPara.SalesSlipNum = salesSlipNum;
            paraList.Add( readPara );

            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
            this.SettingIOWriteCtrlOptWork( OptWorkSettingType.Read, out iOWriteCtrlOptWork ); // リモート参照用パラメータ設定処理
            paraList.Add( iOWriteCtrlOptWork );

            object paraObj = (object)paraList;
            object retObj1;
            object retObj2;

            if ( _iIOWriteControlDB == null )
            {
                _iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            }
            status = _iIOWriteControlDB.Read( ref paraObj, out retObj1, out retObj2 );

            CustomSerializeArrayList retList1 = (CustomSerializeArrayList)retObj1;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                SalesSlipWork salesSlipWork;                                // 売上データワークオブジェクト
                SalesDetailWork[] salesDetailWorkArray;                     // 売上明細データワークオブジェクト配列
                AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;     // 計上元明細データワークオブジェクト配列
                //DepsitMainWork depsitMainWork;                              // 入金データワークオブジェクト
                DepsitDataWork depsitDataWork;                              // 入金データワークオブジェクト
                DepositAlwWork depositAlwWork;                              // 入金引当データワークオブジェクト
                StockWork[] stockWorkArray;                                 // 在庫ワークデータオブジェクト配列
                AcceptOdrCarWork[] acceptOdrCarWorkArray;                   // 受注マスタ（車両）ワークオブジェクト配列

                // CustomSerializeArrayList分割処理
                this.DivisionCustomSerializeArrayListForAfterRead( retList1, retList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWorkList, out addUpSrcStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray );

                salesSlip = salesSlipWork;
                if ( salesDetailWorkArray != null )
                {
                    salesDetailList = new List<SalesDetailWork>( salesDetailWorkArray );
                }
                if ( addUpOrgSalesDetailWorkArray != null )
                {
                    addUpSrcDetailList = new List<SalesDetailWork>( addUpOrgSalesDetailWorkArray );
                }
                //depsitMain = (depsitDataWork != null) ? (SearchDepsitMain)DBAndXMLDataMergeParts.CopyPropertyInClass(depsitMainWork, typeof(SearchDepsitMain)) : new SearchDepsitMain();
                depsitMain = ConvertSalesSlip.UIDataFromParamData( depsitDataWork );
                depositAlw = (depositAlwWork != null) ? (SearchDepositAlw)DBAndXMLDataMergeParts.CopyPropertyInClass( depositAlwWork, typeof( SearchDepositAlw ) ) : new SearchDepositAlw();
                acceptOdrCarList = new List<AcceptOdrCarWork>( acceptOdrCarWorkArray );
                if ( (stockWorkArray != null) && (stockWorkArray.Length > 0) )
                {
                    stockWorkList = new List<StockWork>();
                    stockWorkList.AddRange( stockWorkArray );
                }

                if ( stockSlipWorkList == null ) stockSlipWorkList = new List<StockSlipWork>();
                if ( stockDetailWorkList == null ) stockDetailWorkList = new List<StockDetailWork>();
                if ( addUpSrcStockDetailWorkList == null ) addUpSrcStockDetailWorkList = new List<AddUpOrgStockDetailWork>();

            }
            return status;
        }
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        /// <param name="optWorkSettinType"> </param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork( OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork )
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                              // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
            //iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this.SalesTtlSt.AcpOdrrAddUpRemDiv;     // 受注データ計上残区分
            //iOWriteCtrlOptWork.ShipmAddUpRemDiv = this.SalesTtlSt.ShipmAddUpRemDiv;         // 出荷データ計上残区分
            //iOWriteCtrlOptWork.EstimateAddUpRemDiv = this.SalesTtlSt.EstmateAddUpRemDiv;    // 見積データ計上残区分
            //iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this.SalesTtlSt.RetGoodsStockEtyDiv;   // 返品時在庫登録区分
            iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // 残数管理区分(0:する 固定とする)
            //iOWriteCtrlOptWork.SupplierSlipDelDiv = this.SalesTtlSt.SupplierSlipDelDiv;     // 仕入伝票削除区分
            //iOWriteCtrlOptWork.CarMngDivCd = this.CarMngDivCd;                                                   // 車両管理マスタ登録区分(0:登録しない 1:登録する)
            switch ( optWorkSettinType )
            {
                case OptWorkSettingType.Write:
                    break;
                case OptWorkSettingType.Read:
                    break;
                //case OptWorkSettingType.Delete:
                //    if ( this.SalesTtlSt.SupplierSlipDelDiv == 1 )
                //    {
                //        iOWriteCtrlOptWork.SupplierSlipDelDiv = this._supplierSlipDelDiv; // 仕入伝票削除区分
                //    }
                //    break;
            }
        }
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（Read後専用）
        /// </summary>
        /// <param name="paraList1">カスタムシリアライズリストオブジェクト(親データ)</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト(計上元／同時入力データ)</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgSalesDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockSlipWorkList">同時入力データワークオブジェクトリスト</param>
        /// <param name="stockDetailWrokList">同時入力明細データワークオブジェクトリスト</param>
        /// <param name="addUpOrgStockDetailWorkList">同時入力計上元仕入明細データワークリスト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayListForAfterRead( CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray )
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // ParaList構成
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                売上情報リスト(第１パラメータ ParaList1)
            //    --SalesSlipWork                       売上データ                              →親データ
            //    --ArrayList                           売上明細リスト
            //        --SalesDetailWork                 売上明細データ                          →親データ
            //    --ArrayList                           計上元明細リスト
            //        --AddUppOrgSalesDetailWork        計上元明細データ                        →参照のみ(残数チェック)
            //    --DepsitDataWork                      入金データ                              →親データ同時修正可能
            //    --DepositAlwWork                      入金引当データ                          →親データ同時修正可能
            //    --ArrayList                           在庫ワークリスト                        
            //        --StockWork                       在庫ワークデータ                        →参照のみ(現在庫数セット)
            //    --ArrayList                           受注マスタ（車両）リスト
            //        --AcceptOdrCar                    受注マスタ（車両）
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                計上元／同時入力リスト(第２パラメータ ParaList2)
            //    --CustomSerializeArrayList            計上元情報リスト(出荷、受注、見積)
            //      --SalesSlipWork                     計上元データ                            →親データ同時修正可(見積のみ)
            //      --ArrayList                         計上元明細リスト
            //          --SalesDetailWork               計上元明細データ                        →親データ同時修正可(見積のみ)
            //      --ArrayList                         計上元元明細リスト
            //          --AddUppOrgSalesDetailWork      計上元元明細データ                      →未使用(見積時は未セットとなる為)
            //      --DepsitMainWork                    計上元入金データ                        →未使用(見積時は未セットとなる為)
            //      --DepositAlwWork                    計上元入金引当データ                    →未使用(見積時は未セットとなる為)
            //      --ArrayList                         計上元在庫ワークリスト                        
            //          --StockWork                     計上元在庫ワークデータ                  →未使用
            //------------------------------------------
            //    --CustomSerializeArrayList            同時入力リスト(仕入、出荷、発注)
            //      --StockSlipWork                     同時入力データ                          →親データ同時修正可(受発注のみ)
            //      --ArrayList                         同時入力明細リスト
            //          --StockDetailWork               同時入力明細データ                      →親データ同時修正可(受発注のみ)
            //      --ArrayList                         同時入力計上元明細リスト
            //          --AddUpOrgStockDetailWork       同時入力計上元明細データ                →未使用(発注時は未セットとなる為)
            //      --PaymentSlpWork                    同時入力支払データ                      →親データ同時削除可
            //      --ArrayList                         同時入力在庫ワークリスト                        
            //          --StockWork                     同時入力在庫ワークデータ                →未使用
            //------------------------------------------
            //    --CustomSerializeArrayList            同時入力計上元リスト(出荷、発注)
            //      --StockSlipWork                     同時入力計上元データ                    →未使用
            //      --ArrayList                         同時入力計上元明細リスト
            //          --StockDetailWork               同時入力計上元明細データ                →未使用
            //      --ArrayList                         同時入力計上元元明細リスト
            //          --AddUpOrgStockDetailWork       同時入力計上元元明細データ              →未使用
            //      --PaymentSlpWork                    同時入力計上元支払データ                →未使用
            //      --ArrayList                         同時入力計上元在庫ワークリスト                        
            //          --StockWork                     同時入力計上元在庫ワークデータ          →未使用
            //-----------------------------------------------------------------------------------------------------------------------

            salesSlipWork = null;                                                   // 売上データワークオブジェクト
            salesDetailWorkArray = null;                                            // 売上明細データワークオブジェクト配列
            addUpOrgSalesDetailWorkArray = null;                                    // 計上元明細データワークオブジェクト配列
            depsitDataWork = null;                                                  // 入金データワークオブジェクト
            depositAlwWork = null;                                                  // 入金引当データワークオブジェクト
            stockWorkArray = null;                                                  // 在庫ワークオブジェクト配列
            stockSlipWorkList = new List<StockSlipWork>();                          // 同時入力データワークオブジェクトリスト
            stockDetailWrokList = new List<StockDetailWork>();                      // 同時入力明細データワークオブジェクトリスト
            addUpOrgStockDetailWorkList = new List<AddUpOrgStockDetailWork>();     // 同時入力計上元仕入明細データワークオブジェクトリスト
            acceptOdrCarWorkArray = null;                                           // 受注マスタ（車両）ワークオブジェクト配列

            SalesSlipWork tempSalesSlipWork = null;                                 // 売上データワークオブジェクト
            SalesDetailWork[] tempSalesDetailWorkArray = null;                      // 売上明細データワークオブジェクト配列
            AddUpOrgSalesDetailWork[] tempAddUpOrgSalesDetailWorkArray = null;      // 計上元明細データワークオブジェクト配列
            DepsitDataWork tempDepsitDataWork = null;                               // 入金データワークオブジェクト
            DepositAlwWork tempDepositAlwWork = null;                               // 入金引当データワークオブジェクト
            StockWork[] tempStockWorkArray = null;                                  // 在庫ワークオブジェクト配列
            StockSlipWork tempStockSlipWork = null;                                 // 同時入力データワークオブジェクト
            StockDetailWork[] tempStockDetailWorkArray = null;                      // 同時入力明細データワークオブジェクト配列
            AddUpOrgStockDetailWork[] tempAddUpOrgStockDetailWorkArray = null;      // 同時入力計上元明細データワークオブジェクト配列
            AcceptOdrCarWork[] tempAcceptOdrCarWorkArray = null;                    // 受注マスタ（車両）ワークオブジェクト配列

            //---------------------------------------------------
            // 親データ分割（売上情報リスト）
            //---------------------------------------------------
            this.DivisionCustomSerializeArrayList( paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray );
            salesSlipWork = tempSalesSlipWork;
            salesDetailWorkArray = tempSalesDetailWorkArray;
            addUpOrgSalesDetailWorkArray = tempAddUpOrgSalesDetailWorkArray;
            depsitDataWork = tempDepsitDataWork;
            depositAlwWork = tempDepositAlwWork;
            stockWorkArray = tempStockWorkArray;
            acceptOdrCarWorkArray = tempAcceptOdrCarWorkArray;

            //---------------------------------------------------
            // 計上元／同時入力リスト分割
            //---------------------------------------------------
            for ( int i = 0; i < paraList2.Count; i++ )
            {
                if ( paraList2[i] is CustomSerializeArrayList )
                {

                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList2[i];
                    foreach ( object tempObj in tempList )
                    {
                        //---------------------------------------------------
                        // 同時入力データ
                        //---------------------------------------------------
                        if ( tempObj is ArrayList )
                        {
                            ArrayList tempArrayList = (ArrayList)tempObj;
                            foreach ( object detailObj in tempArrayList )
                            {
                                if ( detailObj is StockDetailWork )
                                {
                                    StockDetailWork tempWork = (StockDetailWork)detailObj;
                                    if ( (tempWork.SalesSlipDtlNumSync != 0) && (tempWork.StockSlipDtlNumSrc == 0) )
                                    {
                                        this.DivisionCustomSerializeArrayList( tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray );
                                        if ( tempStockSlipWork != null )
                                        {
                                            stockSlipWorkList.Add( tempStockSlipWork );
                                            stockDetailWrokList.AddRange( tempStockDetailWorkArray );
                                        }
                                        if ( tempAddUpOrgStockDetailWorkArray != null )
                                        {
                                            addUpOrgStockDetailWorkList.AddRange( tempAddUpOrgStockDetailWorkArray );
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（仕入情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元仕入明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayList( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out StockWork[] stockWorkArray )
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            stockWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;

            this.DivisionCustomSerializeArrayListProc( paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray );

            if ( (objStockSlipWork != null) && (objStockSlipWork is StockSlipWork) ) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ( (objStockDetailWorkArray != null) && (objStockDetailWorkArray is StockDetailWork[]) ) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ( (objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[]) ) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayList( CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray )
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;

            this.DivisionCustomSerializeArrayListProc( paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray );

            if ( (objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork) ) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ( (objSalesDetailWorkArray != null) && (objSalesDetailWorkArray is SalesDetailWork[]) ) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ( (objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray is AddUpOrgSalesDetailWork[]) ) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ( (objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork) ) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ( (objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork) ) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ( (objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[]) ) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金／支払データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayListProc( CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray )
        {
            object acceptOdrCarWorkArray = null;
            this.DivisionCustomSerializeArrayListProc( paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray );
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金／支払データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayListProc( CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray )
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;

            for ( int i = 0; i < paraList.Count; i++ )
            {
                if ( (paraList[i] is StockSlipWork) || (paraList[i] is SalesSlipWork) )
                {
                    slipWork = paraList[i];
                }
                else if ( (paraList[i] is PaymentSlpWork) || (paraList[i] is DepsitDataWork) )
                {
                    depsitDataWork = paraList[i];
                }
                else if ( paraList[i] is DepositAlwWork )
                {
                    depositAlwWork = paraList[i];
                }
                else if ( paraList[i] is ArrayList )
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if ( list.Count == 0 ) continue;

                    if ( list[0] is AddUpOrgStockDetailWork )
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray( typeof( AddUpOrgStockDetailWork ) );
                    }
                    else if ( list[0] is AddUpOrgSalesDetailWork )
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray( typeof( AddUpOrgSalesDetailWork ) );
                    }
                    else if ( list[0] is StockDetailWork )
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray( typeof( StockDetailWork ) );
                    }
                    else if ( list[0] is SalesDetailWork )
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray( typeof( SalesDetailWork ) );
                    }
                    else if ( list[0] is StockWork )
                    {
                        stockWorkArray = (StockWork[])list.ToArray( typeof( StockWork ) );
                    }
                    else if ( list[0] is AcceptOdrCarWork )
                    {
                        acceptOdrCarWorkArray = (AcceptOdrCarWork[])list.ToArray( typeof( AcceptOdrCarWork ) );
                    }
                }
            }
        }
    }
}
