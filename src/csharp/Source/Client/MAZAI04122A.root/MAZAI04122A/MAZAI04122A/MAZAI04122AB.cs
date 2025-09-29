//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 移動在庫入力の初期値取得データ制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20008 伊藤 豊
// 作 成 日  2007/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 修 正 日  2007/09/25  修正内容 : 流通.NS用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/04  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/06/10  修正内容 : 移動伝票の[発行する]オプションの初期値を設定
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸 伸悟
// 修 正 日  2012/07/05  修正内容 : 移動時在庫自動登録区分による制御を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Xml.Serialization;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 移動在庫入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 移動在庫入力の初期値取得データ制御を行います。</br>
    /// <br>Programmer : 20008 伊藤 豊</br>
    /// <br>Date       : 2007.01.26</br>
    /// <br>UpDate     : 2007.01.26 伊藤 豊 新規作成</br>
    /// <br>UpDate     : 2007.09.25 鈴木 正臣 流通.NS用に変更</br>
    /// <br>UpDate     : 2008/07/14 忍 幸史 Partsman用に変更</br>
    /// <br>           : 2009/06/04 照田 貴志　移動データ拠点管理対応</br>
    /// </remarks>
    public class StockMoveInputInitDataAcs
    {
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private StockMoveInputInitDataAcs()
        {
            // 変数初期化
            this._stockMoveHeader = new StockMoveHeader();
            this._stockMoveSlipSearchCond = new StockMoveSlipSearchCond();

            // 担当者データ
            this._EmployeeTable = new Hashtable();
            // 拠点データ
            this._SectionTable = new Hashtable();
            // 倉庫データ
            this._WareHouseTable = new Hashtable();

            // 担当者アクセスクラス
            this._employeeAcs = new EmployeeAcs();

            // 得意先(拠点)アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 倉庫アクセスクラス
            this._warehouseAcs = new WarehouseAcs();

            // 在庫全体設定マスタアクセスクラス
            this._stockMngTtlStAcs = new StockMngTtlStAcs();

            //// グロスデータ
            //this._GrossMap = new Hashtable();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
　      }

        /// <summary>
        /// 在庫移動用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>仕入入力用初期値取得アクセスクラス インスタンス</returns>
        public static StockMoveInputInitDataAcs GetInstance()
        {
            if (_stockSlipInputInitDataAcs == null)
            {
                _stockSlipInputInitDataAcs = new StockMoveInputInitDataAcs();
            }

            return _stockSlipInputInitDataAcs;
        }

        private static StockMoveInputInitDataAcs _stockSlipInputInitDataAcs;

        // 移動在庫ヘッダデータ
        private StockMoveHeader _stockMoveHeader;
        // 在庫移動検索条件データ
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;

        // 担当者データ
        private Hashtable _EmployeeTable;
        // 拠点データ
        private Hashtable _SectionTable;
        // 倉庫データ
        private Hashtable _WareHouseTable;

        // グロスデータ
        private Hashtable _GrossMap;

        // 更新モード
        private int registMode = 0;

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // 本社機能フラグ
        private int _MainOfficeFuncFlag;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // 伝票検索から選択された場合にTure
        private Boolean guideSelected = false;

        // 在庫全体設定マスタアクセスクラス
        private StockMngTtlStAcs _stockMngTtlStAcs;

        // 在庫全体設定マスタデータ
        private StockMngTtlSt _stockMngTtlSt;

        /// <summary>端末管理マスタアクセスクラス</summary>
        public PosTerminalMgAcs _posTerminalMgAcs = new PosTerminalMgAcs();

        /// <summary>端末管理マスタデータクラス</summary>
        public PosTerminalMg _posTerminalMg = new PosTerminalMg();

        // 担当者アクセスクラス
        EmployeeAcs _employeeAcs;

        // 得意先(拠点)アクセスクラス
        SecInfoSetAcs _secInfoSetAcs;

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        SecInfoAcs _secInfoAcs;
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        // 倉庫アクセスクラス
        WarehouseAcs _warehouseAcs;

        // 締日算出モジュール
        private TotalDayCalculator _totalDayCalculator;

        // POSPC判別区分
        private int _POSPCTermCd;

        # region Getterメソッド

        /// <summary>
        /// 更新モードかの判別
        /// </summary>
        public int RegistMode
        {
            get { return registMode; }
            set { registMode = value; }
        }

        /// <summary>
        /// ガイドにて選択されたかのフラグ
        /// </summary>
        public Boolean GuideSelected
        {
            get { return guideSelected; }
            set { guideSelected = value; }
        }

        /// <summary>
        /// 移動在庫ヘッダデータプロパティ
        /// </summary>
        public StockMoveHeader StockMoveHeader
        {
            get { return _stockMoveHeader; }
        }

        /// <summary>
        /// 移動在庫検索条件データ
        /// </summary>
        public StockMoveSlipSearchCond StockMoveSlipSearchCond
        {
            get { return _stockMoveSlipSearchCond; }
        }

        /// <summary>
        /// グロスデータの詳細データ一時格納用
        /// </summary>
        public Hashtable GrossMap
        {
            get { return _GrossMap; }
            set { _GrossMap = value; }
        }

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 本社機能利用フラグ
        /// </summary>
        public int MainOfficeFunc
        {
            get { return _MainOfficeFuncFlag; }
            set { _MainOfficeFuncFlag = value; }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        public StockMngTtlSt StockMngTtlSt  // FIXME:
        {
            get { return _stockMngTtlSt; }
        }

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫全体設定マスタ(在庫管理全体設定管理コード)
        /// </summary>
        public int StockMngTtlStCd
        {
            get { return _stockMngTtlSt.StockMngTtlStCd; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(受託在庫拠点間移動区分)
        /// </summary>
        public int TrustStSectMoveCd
        {
            get { return _stockMngTtlSt.TrustStSectMoveCd; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(受託在庫倉庫移動区分)
        /// </summary>
        public int TrustStWhouMoveCd
        {
            get { return _stockMngTtlSt.TrustStWhouMoveCd; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(受託在庫委託許可区分)
        /// </summary>
        public int TrEntrustPermCd
        {
            get { return _stockMngTtlSt.TrEntrustPermCd; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(在庫移動確定区分)
        /// </summary>
        public int StockMoveFixCode
        {
            get { return _stockMngTtlSt.StockMoveFixCode; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(在庫管理有無区分初期表示値)
        /// </summary>
        public int StockMngExistCdDisp
        {
            get { return _stockMngTtlSt.StockMngExistCdDisp; }
        }

        /// <summary>
        /// 在庫自動登録
        /// </summary>
        public int AutoEntryStockCd
        {
            get { return _stockMngTtlSt.AutoEntryStockCd; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(最適在庫条件区分)
        /// </summary>
        public int BeatStockCondCd
        {
            get { return _stockMngTtlSt.BeatStockCondCd; }
        }

        /// <summary>
        /// 在庫全体設定マスタ(在庫評価方法)
        /// </summary>
        public int StockPointWay
        {
            get { return _stockMngTtlSt.StockPointWay; }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        // ---ADD 2009/06/04 ----------------------------->>>>>
        /// <summary>
        /// 在庫全体設定マスタ(在庫移動確定区分)
        /// </summary>
        public int StockMoveFixCode
        {
            get { return _stockMngTtlSt.StockMoveFixCode; }
        }
        // ---ADD 2009/06/04 -----------------------------<<<<<

        // --- ADD 三戸 2012/07/05 ---------->>>>>
        /// <summary>
        /// 在庫全体設定マスタ(移動時在庫自動登録区分)
        /// </summary>
        public int MoveStockAutoInsDiv
        {
            get { return _stockMngTtlSt.MoveStockAutoInsDiv; }
        }
        // --- ADD 三戸 2012/07/05 ----------<<<<<

        /// <summary>
        /// POSPC判別区分
        /// </summary>
        public int POSPCTermCd
        {
            get { return _POSPCTermCd; }
        }

        # endregion

        //private StockTtlSt _stockTtlSt;

        /// <summary>
        /// 初期データ取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        public int ReadInitData(string enterpriseCode)
        {
            // 担当者マスタ
            ArrayList retEmpList;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int statusEmp = _employeeAcs.Search(out retEmpList, LoginInfoAcquisition.EnterpriseCode);

            _EmployeeTable = new Hashtable();
            ArrayList retEmpList2;
            int statusEmp = _employeeAcs.Search( out retEmpList, out retEmpList2, LoginInfoAcquisition.EnterpriseCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            if (statusEmp == 0)
            {
                foreach (Employee retEmp in retEmpList)
                {
                    if (retEmp.LogicalDeleteCode == 0)
                    {
                        _EmployeeTable.Add(retEmp.EmployeeCode.Trim(), retEmp.Name);
                    }
                }
            }

            // 得意先(拠点)マスタ
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            ArrayList retSecList;

            int statusSec = _secInfoSetAcs.Search(out retSecList, LoginInfoAcquisition.EnterpriseCode);

            if (statusSec == 0)
            {
                foreach (SecInfoSet retSec in retSecList)
                {
                    _SectionTable.Add(retSec.SectionCode.Trim(), retSec.SectionGuideNm);
                }
            }
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            _SectionTable = new Hashtable();
            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            // FIXME:this._secInfoAcs.ResetSectionInfo();
            // DEL 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            // ADD 2010/06/10 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._SectionTable.Add(secInfoSet.SectionCode.Trim(), secInfoSet.SectionGuideNm);
                }
            }
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            // 倉庫マスタ
            _WareHouseTable = new Hashtable();
            ArrayList retWarehouseList;

            int statusWarehouse = _warehouseAcs.Search(out retWarehouseList, LoginInfoAcquisition.EnterpriseCode);

            if (statusWarehouse == 0)
            {
                foreach (Warehouse retWare in retWarehouseList)
                {
                    if (retWare.LogicalDeleteCode == 0)
                    {
                        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
                        //_WareHouseTable.Add(retWare.SectionCode.Trim() + "_" + retWare.WarehouseCode.Trim(), retWare.WarehouseName);
                        _WareHouseTable.Add(retWare.WarehouseCode.Trim(), retWare.WarehouseName);
                        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
                    }
                }
            }

            // 在庫管理全体設定マスタ
            StockMngTtlSt retStockMngTtlSt;

            int statusMngTtlSt = _stockMngTtlStAcs.Read(out retStockMngTtlSt, LoginInfoAcquisition.EnterpriseCode, 0);
            if (statusMngTtlSt == 0)
            {
                _stockMngTtlSt = retStockMngTtlSt;
            }

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 本社機能利用フラグ
            SecInfoSet mainSec;

            int statusMain = _secInfoSetAcs.Read(out mainSec, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (statusMain == 0)
            {
                _MainOfficeFuncFlag = mainSec.MainOfficeFuncFlag;
            }
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

#if false //..保留 端末管理データ
            // 端末管理データ取得
            int posTerminalMgStatus = this._posTerminalMgAcs.Search(out this._posTerminalMg, LoginInfoAcquisition.EnterpriseCode);
            if ( posTerminalMgStatus == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL || this._posTerminalMg == null ) {
                _POSPCTermCd = this._posTerminalMg.PosPCTermCd;
            }
#endif
            return 0;
        }

        public bool CheckHisTotalDayMonthly(string sectionCode, DateTime targetDate, out DateTime prevTotalDay)
        {
            int status;
            prevTotalDay = new DateTime();

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();
            
            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCode, out prevTotalDay);
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out prevTotalDay);
            }

            if (status == 0)
            {
                if (prevTotalDay == DateTime.MinValue)
                {
                    return (true);
                }

                if (targetDate > prevTotalDay)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (true);
            }
        }

        public void ReadStockMngTtlSt()
        {

            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        _stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                _stockMngTtlSt = new StockMngTtlSt();
            }
        }

        /// <summary>
        /// 在庫移動ヘッダ情報クリア処理
        /// </summary>
        public void StockMoveHeaderClear()
        {
            _stockMoveHeader.CreateDateTime = new DateTime();
            _stockMoveHeader.UpdateDateTime = new DateTime();
            _stockMoveHeader.EnterpriseCode = "";
            _stockMoveHeader.FileHeaderGuid = new Guid();
            _stockMoveHeader.UpdEmployeeCode = "";
            _stockMoveHeader.UpdAssemblyId1 = "";
            _stockMoveHeader.UpdAssemblyId2 = "";
            _stockMoveHeader.LogicalDeleteCode = 0;
            _stockMoveHeader.StockMvEmpCode = "";
            _stockMoveHeader.StockMvEmpName = "";
            _stockMoveHeader.ShipmentScdlDay = new DateTime();
            _stockMoveHeader.ShipmentFixDay = new DateTime();
            _stockMoveHeader.BfSectionCode = "";
            _stockMoveHeader.BfSectionGuideName = "";
            _stockMoveHeader.BfEnterWarehCode = "";
            _stockMoveHeader.BfEnterWarehName = "";
            _stockMoveHeader.AfSectionCode = "";
            _stockMoveHeader.AfSectionGuideName = "";
            _stockMoveHeader.AfEnterWarehCode = "";
            _stockMoveHeader.AfEnterWarehName = "";
            _stockMoveHeader.MoveSlipPrintDiv = false;
            _stockMoveHeader.ShipAgentCd = "";
            _stockMoveHeader.ShipAgentNm = "";
            _stockMoveHeader.ReceiveAgentCd = "";
            _stockMoveHeader.ReceiveAgentNm = "";
            _stockMoveHeader.ArrivalGoodsDay = new DateTime();
        }

        /// <summary>
        /// 在庫移動検索データ情報クリア処理
        /// </summary>
        public void StockMoveSlipSearchCondClear()
        {
            _stockMoveSlipSearchCond.EnterpriseCode = "";
            _stockMoveSlipSearchCond.SectionCode = "";
            _stockMoveSlipSearchCond.StockMoveSlipNo = 0; 
            _stockMoveSlipSearchCond.StockMvEmpCode = "";
            _stockMoveSlipSearchCond.ShipAgentCd = "";
            _stockMoveSlipSearchCond.ReceiveAgentCd = "";
            _stockMoveSlipSearchCond.ShipmentScdlStDay = new DateTime();
            _stockMoveSlipSearchCond.ShipmentScdlEdDay = new DateTime();
            _stockMoveSlipSearchCond.ShipmentFixStDay = new DateTime();
            _stockMoveSlipSearchCond.ShipmentFixEdDay = new DateTime();
            _stockMoveSlipSearchCond.ArrivalGoodsStDay = new DateTime();
            _stockMoveSlipSearchCond.ArrivalGoodsEdDay = new DateTime();
            _stockMoveSlipSearchCond.BfSectionCode = "";
            _stockMoveSlipSearchCond.BfEnterWarehCode = "";
            _stockMoveSlipSearchCond.AfSectionCode = "";
            _stockMoveSlipSearchCond.AfEnterWarehCode = "";
            _stockMoveSlipSearchCond.MoveStatus = 0;
            _stockMoveSlipSearchCond.CellphoneModelCode = 0;
            _stockMoveSlipSearchCond.ProductNumber = "";
            _stockMoveSlipSearchCond.EnterpriseName = "";
            _stockMoveSlipSearchCond.ReceiveAgentNm = "";
            _stockMoveSlipSearchCond.CellphoneModelName = "";
        }

        # region キャッシュデータ検索

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 担当者名称取得
        /// </summary>
        /// <param name="employeeCode">担当者コード</param>
        /// <returns>担当者名称</returns>
        public string GetEmployeeName(string employeeCode)
        {
            Boolean containsFlg = _EmployeeTable.ContainsKey(employeeCode.Trim());

            if (containsFlg == true)
            {
                return (string)_EmployeeTable[employeeCode.Trim()];
            }
            else
            {
                //return null;
                return "";
            }
        }

        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        public string GetSectionName(string sectionCode)
        {
            Boolean containsFlg = _SectionTable.ContainsKey(sectionCode.Trim());

            if (containsFlg == true)
            {
                return (string)_SectionTable[sectionCode.Trim()];
            }
            else
            {
                //return null;
                return "";
            }
        }

        /// <summary>
        /// 倉庫名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        public string GetWarehouseName(string sectionCode, string warehouseCode)
        {
            Boolean containsFlg = _WareHouseTable.ContainsKey(sectionCode.Trim() + "_" + warehouseCode.Trim());

            if (containsFlg == true)
            {
                return (string)_WareHouseTable[sectionCode.Trim() + "_" + warehouseCode.Trim()];
            }
            else
            {
                //return null;
                return "";
            }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 担当者名称取得
        /// </summary>
        /// <param name="employeeCode">担当者コード</param>
        /// <returns>担当者名称</returns>
        public string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._EmployeeTable.ContainsKey(employeeCode.Trim().PadLeft(4, '0')))
            {
                employeeName = (string)this._EmployeeTable[employeeCode.Trim().PadLeft(4, '0')];
            }

            return employeeName;
        }

        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._SectionTable.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
            {
                sectionName = (string)this._SectionTable[sectionCode.Trim().PadLeft(2, '0')];
            }

            return sectionName;
        }

        /// <summary>
        /// 倉庫名称取得
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._WareHouseTable.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
            {
                warehouseName = (string)this._WareHouseTable[warehouseCode.Trim().PadLeft(4, '0')];
            }

            return warehouseName;
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        # endregion

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Clear()
        {
            this.StockMoveHeaderClear();
            this.StockMoveSlipSearchCondClear();

            this.GrossMap.Clear();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        // ADD 2010/06/09 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
        /// <summary>設定を保存するファイル名</summary>
        private const string FILE_NAME = "UISetting_MAZAI04122A.xml";
        /// <summary>設定を保存するファイル名を取得します。</summary>
        private static string FileName { get { return FILE_NAME; } }

        /// <summary>
        /// 設定を保存するディレクトリパスを取得します。
        /// </summary>
        private static string DirPath
        {
            get
            {
                string dirPath = Path.Combine(Environment.CurrentDirectory, "UISettings");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                return dirPath;
            }
        }

        /// <summary>
        /// ユーザー設定を保存します。
        /// </summary>
        /// <param name="userCustomSetting">ユーザー設定</param>
        public static void SaveUserCustomSetting(UserCustomSetting userCustomSetting)
        {
            #region Guard Phrase

            if (userCustomSetting == null) return;

            #endregion // Guard Phrase

            FileStream fileStream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserCustomSetting));
                fileStream = new FileStream(Path.Combine(DirPath, FileName), FileMode.Create);
                serializer.Serialize(fileStream, userCustomSetting);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }
        }

        /// <summary>
        /// ユーザー設定を取り込みます。
        /// </summary>
        /// <returns>保存されているユーザー設定の内容</returns>
        public static UserCustomSetting LoadUserCustomSetting()
        {
            UserCustomSetting userCustomSetting = null;

            FileStream fileStream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserCustomSetting));
                fileStream = new FileStream(Path.Combine(DirPath, FileName), FileMode.Open);
                userCustomSetting = (UserCustomSetting)serializer.Deserialize(fileStream);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            return userCustomSetting ?? new UserCustomSetting();
        }
        // ADD 2010/06/09 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
    }

    // ADD 2010/06/09 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ---------->>>>>
    /// <summary>
    /// ユーザー設定クラス
    /// </summary>
    [Serializable]
    public sealed class UserCustomSetting
    {
        /// <summary>移動伝票を[発行する]フラグ</summary>
        private bool _printsSlip;
        /// <summary>移動伝票を[発行する]フラグを取得または設定します。</summary>
        public bool PrintsSlip
        {
            get { return _printsSlip; }
            set { _printsSlip = value; }
        }

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UserCustomSetting(): this(true) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="printsSlip">移動伝票を[発行する]フラグ</param>
        public UserCustomSetting(bool printsSlip)
        {
            _printsSlip = printsSlip;
        }

        #endregion // Constructor
    }
    // ADD 2010/06/09 MANTIS対応[15573]：移動伝票の[発行する]オプションの初期値を設定  ----------<<<<<
}
