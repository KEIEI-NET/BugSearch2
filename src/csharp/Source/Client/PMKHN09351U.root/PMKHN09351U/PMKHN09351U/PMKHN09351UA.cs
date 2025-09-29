//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【13030】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/13     修正内容：Mantis【9494】得意先変動情報の取得処理を修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/14     修正内容：Mantis【9494】与信額と警告与信額のチェックを得意先変動情報に合わせる
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/01/29     修正内容：Mantis【14950】請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/09     修正内容：Mantis【14976】グリッド制御の拡張
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15035】区分名称に区分値が付加されたまま更新している
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15033】伝票印刷区分×5を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15032】請求書出力区分が表示されてしまう
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/03/02     修正内容：Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない)
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/03/23     修正内容：Mantis【14976】グリッド制御の拡張(グリッドヘッダの▼からの↑↓キーでドロップダウン操作ができない)
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：楊明俊
// 修正日    2010/06/08     修正内容：障害・改良対応7月ﾘﾘｰｽ分
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/07/14     修正内容：得意先種別を変更した際の動作不正の修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：田村顕成
// 修正日    2022/03/04     修正内容：電子帳簿連携対応　ラベル項目の変更（DM出力→電子帳簿出力）
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先一括修正UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 得意先一括修正UIフォームクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2008/11/20</br>
    /// <br>Update Note : 2010/06/08 　楊明俊 障害・改良対応7月ﾘﾘｰｽ分</br>    
    /// </remarks>
    public partial class PMKHN09351UA : Form
    {
        # region ■ Struct
        /// <summary>
        /// 売上金額端数処理キー構造体
        /// </summary>
        private struct SalesProcMoneyKey
        {
            private int _fracProcMoneyDiv;
            private int _fractionProcCode;

            /// <summary>端数処理区分</summary>
            public int FracProcMoneyDiv
            {
                get { return _fracProcMoneyDiv; }
                set { _fracProcMoneyDiv = value; }
            }
            /// <summary>端数処理コード</summary>
            public int FractionProcCode
            {
                get { return _fractionProcCode; }
                set { _fractionProcCode = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="fracProcMoneyDiv"></param>
            /// <param name="fractionProcCode"></param>
            public SalesProcMoneyKey(int fracProcMoneyDiv, int fractionProcCode)
            {
                this._fracProcMoneyDiv = fracProcMoneyDiv;
                this._fractionProcCode = fractionProcCode;
            }
        }
        # endregion ■ Struct


        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09351U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09351U.dat";

        #endregion ■ Constants


        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private CustomerCustomerChangeConstructionAcs _customerCustomerChangeConstructionAcs;
        private CustomerCustomerChangeAcs _customerCustomerChangeAcs;   // 得意先一括修正アクセスクラス
        private SecInfoAcs _secInfoAcs;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;                           // 拠点情報設定アクセスクラス
        private EmployeeAcs _employeeAcs;                               // 従業員マスタアクセスクラス
        private WarehouseAcs _warehouseAcs;                             // 倉庫マスタアクセスクラス
        private CustomerSearchAcs _customerSearchAcs;                   // 得意先情報アクセスクラス
        private SalesProcMoneyAcs _salesProcMoneyAcs;                   // 売上金額処理区分アクセスクラス
        private AddressGuide _addressGuide;								// 住所ガイド
        private AllDefSetAcs _allDefSetAcs;                             // 全体初期表示設定マスタアクセスクラス
        private TaxRateSetAcs _taxRateSetAcs;                           // 税率設定マスタアクセスクラス
        private CustomerChangeAcs _customerChangeAcs;                   // 得意先マスタ(変動情報)アクセスクラス

        private GridInitialSetting _gridInitialSetting;

        private CustomerSearchRet _customerSearchRet;
        private AllDefSet _allDefSet;
        private TaxRateSet _taxRateSet;

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        private DataTable _searchTable;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, CustomerCustomerChangeResult> _prevCustomerCustomerChangetResultDic;
        private Dictionary<int, CustomerCustomerChangeResult> _searchListDic;
        private Dictionary<int, CustomerChange> _customerChangeDic;

        private List<SalesProcMoneyKey> _salesProcMoneyKeyList;         // 売上金額処理クラスキーリスト

        private bool _cellUpdateFlg;
        private bool _keyDownFlg;
        private bool _closeFlg;
        private bool _cusotmerGuideSelected;

        private int _cellMove;

        private UltraGridCell _activeCell;

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// 得意先一括修正UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先一括修正UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        public PMKHN09351UA()
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._customerCustomerChangeConstructionAcs = new CustomerCustomerChangeConstructionAcs();
            this._customerCustomerChangeAcs = new CustomerCustomerChangeAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._employeeAcs = new EmployeeAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._addressGuide = new AddressGuide();
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this._allDefSetAcs = new AllDefSetAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._customerChangeAcs = new CustomerChangeAcs();

            this._gridInitialSetting = new GridInitialSetting();
            this._gridStateController = new GridStateController();

            this._prevCustomerCustomerChangetResultDic = new Dictionary<int, CustomerCustomerChangeResult>();

            // マスタ読込
            ReadSecInfoSet();
            ReadEmployee();
            ReadWarehouse();
            ReadCustomerSearchRet();
            ReadAllDefSet();
            ReadTaxRateSet();
            ReadSalesProcMoney();
            ReadCustomerChange();
    
            // 画面クリア
            ClearScreen();

            // 画面初期設定
            SetInitialSetting();
        }

        #endregion ■ Constructor


        #region ■ Private Methods

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Details);
                if (gridStateInfo != null)
                {
                    // フォントサイズ
                    this.tComboEditor_GridFontSize.Value = (int)gridStateInfo.FontSize;
                    // 列の自動調整
                    this.uCheckEditor_AutoFillToColumn.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // フォントサイズ
                this.tComboEditor_GridFontSize.Value = 11;
                // 列の自動調整
                this.uCheckEditor_AutoFillToColumn.Checked = false;
            }

            // ADD 2010/02/24 MANTIS対応[15032]：請求書出力区分が表示されてしまう ---------->>>>>
            // 請求書出力区分が表示されている場合、旧バージョンの設定であるため、
            // FIXME:旧設定ファイルを削除し、グリッドを再構築する
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            if (!columns[GridInitialSetting.column_BillOutputCode].Hidden)
            {
                string initialDataPath = this._gridStateController.GetGridInfoPath(XML_FILE_INITIAL_DATA);
                if (System.IO.File.Exists(initialDataPath))
                {
                    System.IO.File.Delete(initialDataPath);
                    this._gridInitialSetting.SetGridInitialLayout(ref this.uGrid_Details);
                    LoadStateXmlData();
                }
            }
            // ADD 2010/02/24 MANTIS対応[15032]：請求書出力区分が表示されてしまう ----------<<<<<
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion XML操作

        #region マスタ読込
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 従業員マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 従業員マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadEmployee()
        {
            this._employeeDic = new Dictionary<string, Employee>();

            try
            {
                ArrayList retList;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList, out retList2, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Employee employee in retList)
                    {
                        this._employeeDic.Add(employee.EmployeeCode.Trim(), employee);
                    }
                }
            }
            catch
            {
                this._employeeDic = new Dictionary<string, Employee>();
            }
        }

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 倉庫マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadWarehouse()
        {
            this._warehouseDic = new Dictionary<string, Warehouse>();

            try
            {
                ArrayList retList;

                int status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// 得意先マスタ(変動情報)読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先マスタ(変動情報)を読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadCustomerChange()
        {
            this._customerChangeDic = new Dictionary<int, CustomerChange>();

            try
            {
                // DEL 2009/04/13 ------>>>
                //ArrayList retList;
                
                //int status = this._customerChangeAcs.SearchAll(out retList, this._enterpriseCode);
                // DEL 2009/04/13 ------<<<

                // ADD 2009/04/13 ------>>>
                List<CustomerChange> retList;
                int status = this._customerChangeAcs.Search(out retList, this._enterpriseCode);
                // ADD 2009/04/13 ------<<<
                if (status == 0)
                {
                    foreach (CustomerChange ret in retList)
                    {
                        this._customerChangeDic.Add(ret.CustomerCode, ret);
                    }
                }
            }
            catch
            {
                this._customerChangeDic = new Dictionary<int, CustomerChange>();
            }
        }

        /// <summary>
        /// 全体初期表示設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 全体初期表示設定マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadAllDefSet()
        {
            this._allDefSet = new AllDefSet();

            try
            {
                ArrayList retList;

                // 2010/07/14 Add 全社設定を退避しておく >>>
                AllDefSet ads = new AllDefSet();
                bool getSecAds = false;
                // 2010/07/14 Add <<<

                int status = this._allDefSetAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (AllDefSet allDefSet in retList)
                    {
                        // 2010/07/14 Add 全社設定を退避 >>>
                        if ((allDefSet.LogicalDeleteCode == 0) &&
                            (allDefSet.SectionCode.Trim() == "00"))
                        {
                            ads = allDefSet.Clone();
                        }
                        // 2010/07/14 Add <<<
                        if ((allDefSet.LogicalDeleteCode == 0) && 
                            (allDefSet.SectionCode.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                        {
                            this._allDefSet = allDefSet.Clone();
                            getSecAds = true;   // 2010/07/14 Add
                            break;
                        }
                    }
                }
                // 2010/07/14 Add ログイン拠点の全体初期表示設定が無ければ全社設定をセット >>>
                if (!getSecAds)
                {
                    this._allDefSet = ads.Clone();
                }
                // 2010/07/14 Add <<<
            }
            catch
            {
                this._allDefSet = new AllDefSet();
            }
        }

        /// <summary>
        /// 税率設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 税率設定マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ReadTaxRateSet()
        {
            this._taxRateSet = new TaxRateSet();

            try
            {
                int status = this._taxRateSetAcs.Read(out this._taxRateSet, this._enterpriseCode, 0);
                if (status != 0)
                {
                    this._taxRateSet = new TaxRateSet();
                }
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ読込処理
        /// </summary>
        private void ReadSalesProcMoney()
        {
            this._salesProcMoneyKeyList = new List<SalesProcMoneyKey>();

            try
            {
                ArrayList retList;

                int status = this._salesProcMoneyAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SalesProcMoney salesProcMoney in retList)
                    {
                        this._salesProcMoneyKeyList.Add(new SalesProcMoneyKey(salesProcMoney.FracProcMoneyDiv, salesProcMoney.FractionProcCode));
                    }
                }
            }
            catch
            {
                this._salesProcMoneyKeyList = new List<SalesProcMoneyKey>();
            }
        }
        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードに該当する拠点名を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }

        /// <summary>
        /// 従業員名取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="logicalDelete">論理削除区分(True:論理削除データ取得する　False:論理削除データ取得しない)</param>
        /// <returns>従業員名</returns>
        /// <remarks>
        /// <br>Note        : 従業員コードに該当する従業員名を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode, bool logicalDelete)
        {
            employeeCode = employeeCode.Trim().PadLeft(4, '0');

            if (this._employeeDic.ContainsKey(employeeCode))
            {
                if (logicalDelete == true)
                {
                    return this._employeeDic[employeeCode].Name.Trim();
                }
                else
                {
                    if (this._employeeDic[employeeCode].LogicalDeleteCode == 0)
                    {
                        return this._employeeDic[employeeCode].Name.Trim();
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 倉庫名取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名</returns>
        /// <remarks>
        /// <br>Note        : 倉庫コードに該当する倉庫名を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            warehouseCode = warehouseCode.Trim().PadLeft(4, '0');

            if (this._warehouseDic.ContainsKey(warehouseCode))
            {
                return this._warehouseDic[warehouseCode].WarehouseName.Trim();
            }

            return "";
        }

        /// <summary>
        /// 得意先略称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先略称</returns>
        /// <remarks>
        /// <br>Note        : 得意先コードに該当する得意先略称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private string GetCustomerSnm(int customerCode)
        {
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                return this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return "";
        }
        #endregion 名称取得

        /// <summary>
        /// 得意先一括修正検索結果クラス取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先一括修正検索結果クラス</returns>
        /// <remarks>
        /// <br>Note        : 得意先コードに該当する得意先一括修正検索結果クラスを取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeResult GetCustomerCustomerChangeResult(int customerCode)
        {
            // 検索条件格納
            CustomerCustomerChangeParam extrInfo = new CustomerCustomerChangeParam();
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            extrInfo.StCustomerCode = customerCode;
            extrInfo.EdCustomerCode = customerCode;

            try
            {
                List<CustomerCustomerChangeResult> retList;
                // 検索処理
                int status = this._customerCustomerChangeAcs.Search(out retList, extrInfo, ConstantManagement.LogicalMode.GetData0);
                if (status == 0)
                {
                    return retList[0];
                }
            }
            catch
            {
                return new CustomerCustomerChangeResult();
            }

            return new CustomerCustomerChangeResult();
        }

        /// <summary>
        /// 警告与信額取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>警告与信額</returns>
        /// <remarks>
        /// <br>Note        : 得意先コードに該当する警告与信額を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int GetCustomerChange(out CustomerChange customerChange, int customerCode)
        {
            customerChange = new CustomerChange();

            int status = -1;

            try
            {
                //status = this._customerChangeAcs.Read(out customerChange, this._enterpriseCode, customerCode);
                if (this._customerChangeDic.ContainsKey(customerCode))
                {
                    status = 0;
                    customerChange = (CustomerChange)this._customerChangeDic[customerCode];
                }
            }
            catch
            {
                customerChange = new CustomerChange();
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            this.tNedit_CustomerCode_St.Size = new Size(76, 24);
            this.tNedit_CustomerCode_Ed.Size = new Size(76, 24);

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            LabelTool labelTool;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SetUp"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            // 拠点名
            ToolBase sectionName = tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"];
            if (sectionName != null && LoginInfoAcquisition.Employee != null)
            {
                sectionName.SharedProps.Caption = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }

            // ログイン名
            ToolBase loginName = tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.CustomerGuideSt_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuideEd_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------
            this.uGrid_Details.DataSource = this._gridInitialSetting.CreateColumn();
            this._gridInitialSetting.SetGridInitialLayout(ref this.uGrid_Details);
        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ClearScreen()
        {
            this._cellUpdateFlg = true;
            this._keyDownFlg = true;

            // 得意先コード
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();

            // スクロールポジション初期化
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // グリッドクリア
            this.uGrid_Details.DataSource = this._gridInitialSetting.CreateColumn();

            this._searchListDic = null;

            // フォーカス設定
            this.tNedit_CustomerCode_St.Focus();
        }

        /// <summary>
        /// 得意先一括修正検索結果画面表示処理
        /// </summary>
        /// <param name="customerCustomerChangeResultList">得意先一括修正検索結果リスト</param>
        /// <remarks>
        /// <br>Note        : 得意先一括修正検索結果リストを画面表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void CustomerCustomerChangeResultToScreen(List<CustomerCustomerChangeResult> customerCustomerChangeResultList)
        {
            try
            {
                this.uGrid_Details.BeginUpdate();

                // グリッド初期化
                this.uGrid_Details.DataSource = this._gridInitialSetting.CreateColumn();
                this._searchTable = this._gridInitialSetting.CreateColumn();

                this._searchListDic = new Dictionary<int, CustomerCustomerChangeResult>();
                CustomerCustomerChangeResult result = new CustomerCustomerChangeResult();

                for (int index = 0; index < customerCustomerChangeResultList.Count; index++)
                {
                    result = customerCustomerChangeResultList[index].Clone();

                    // 行追加
                    this.uGrid_Details.DisplayLayout.Bands[0].AddNew();
                    
                    this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                    this._cellUpdateFlg = false;

                    // 得意先一括修正検索結果画面表示
                    CustomerCustomerChangeResultToScreen(result, index);

                    if (this._prevCustomerCustomerChangetResultDic.ContainsKey(result.CustomerCode))
                    {
                        this._prevCustomerCustomerChangetResultDic[result.CustomerCode] = result.Clone();
                    }
                    else
                    {
                        this._prevCustomerCustomerChangetResultDic.Add(result.CustomerCode, result.Clone());
                    }

                    if (!this._searchListDic.ContainsKey(result.CustomerCode))
                    {
                        this._searchListDic.Add(result.CustomerCode, result.Clone());
                    }
                }

                // フォーカス設定
                if (this.uGrid_Details.Rows.Count > 0)
                {
                    if (this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activation != Activation.AllowEdit)
                    {
                        this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerName].Activate();
                    }
                    else
                    {
                        this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                    }
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                this._cellUpdateFlg = true;

                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// 得意先一括修正検索結果画面表示処理
        /// </summary>
        /// <param name="result">得意先一括修正検索結果</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <remarks>
        /// <br>Note        : 得意先一括修正検索結果を画面表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// <br>Update Note : 2010/06/08 　楊明俊 得意先担当者が未登録時にログイン担当者を初期表示させないように変更する。</br>
        /// </remarks>
        private void CustomerCustomerChangeResultToScreen(CustomerCustomerChangeResult result, int rowIndex)
        {
            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            // No.
            cells[GridInitialSetting.column_No].Value = rowIndex + 1;
            // 得意先コード
            cells[GridInitialSetting.column_CustomerCode].Value = result.CustomerCode.ToString("00000000");
            // サブコード
            cells[GridInitialSetting.column_CustomerSubCode].Value = result.CustomerSubCode.Trim();
            // 得意先名1
            cells[GridInitialSetting.column_CustomerName].Value = result.Name.Trim();
            // 得意先名2
            cells[GridInitialSetting.column_CustomerName2].Value = result.Name2.Trim();
            // 得意先略称
            cells[GridInitialSetting.column_CustomerSnm].Value = result.CustomerSnm.Trim();
            // 得意先名(カナ)
            cells[GridInitialSetting.column_CustomerKana].Value = result.Kana.Trim();
            // 敬称
            cells[GridInitialSetting.column_HonorificTitle].Value = result.HonorificTitle.Trim();
            // 諸口
            cells[GridInitialSetting.column_OutputName].Value = result.OutputNameCode;
            // 管理拠点
            if (result.MngSectionName.Trim() != "")
            {
                cells[GridInitialSetting.column_MngSectionName].Value = result.MngSectionName.Trim();
                cells[GridInitialSetting.column_MngSectionName].Tag = result.MngSectionCode.Trim();
            }
            else
            {
                cells[GridInitialSetting.column_MngSectionName].Value = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
                cells[GridInitialSetting.column_MngSectionName].Tag = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            }
            // 得意先担当
            if (result.CustomerAgentNm.Trim() != "")
            {
                cells[GridInitialSetting.column_CustomerAgentName].Value = result.CustomerAgentNm.Trim();
                cells[GridInitialSetting.column_CustomerAgentName].Tag = result.CustomerAgentCd.Trim();
            }

            // --- DEL 2010/06/08 ---------->>>>>
            //else
            //{
            //    cells[GridInitialSetting.column_CustomerAgentName].Value = LoginInfoAcquisition.Employee.Name.Trim();
            //    cells[GridInitialSetting.column_CustomerAgentName].Tag = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            //}
            // --- DEL 2010/06/08 ----------<<<<<

            // 旧担当
            cells[GridInitialSetting.column_OldCustomerAgentName].Value = result.OldCustomerAgentNm.Trim();
            cells[GridInitialSetting.column_OldCustomerAgentName].Tag = result.OldCustomerAgentCd.Trim();
            // 担当者変更日
            if (result.CustAgentChgDate == DateTime.MinValue)
            {
                cells[GridInitialSetting.column_CustAgentChgDate].Value = DBNull.Value;
            }
            else
            {
                cells[GridInitialSetting.column_CustAgentChgDate].Value = result.CustAgentChgDate;
            }
            // 取引中止日
            if (result.TransStopDate == DateTime.MinValue)
            {
                cells[GridInitialSetting.column_TransStopDate].Value = DBNull.Value;
            }
            else
            {
                cells[GridInitialSetting.column_TransStopDate].Value = result.TransStopDate;
            }
            // 車輌管理
            cells[GridInitialSetting.column_CarMngDivCd].Value = result.CarMngDivCd;
            // 個人・法人
            cells[GridInitialSetting.column_CorporateDivCode].Value = result.CorporateDivCode;
            // 得意先種別
            cells[GridInitialSetting.column_AcceptWholeSale].Value = result.AcceptWholeSale;
            // 得意先属性
            cells[GridInitialSetting.column_CustomerAttributeDiv].Value = result.CustomerAttributeDiv;
            // 優先倉庫
            cells[GridInitialSetting.column_CustWarehouseName].Value = result.CustWarehouseName.Trim();
            cells[GridInitialSetting.column_CustWarehouseName].Tag = result.CustWarehouseCd.Trim();
            // 業種
            cells[GridInitialSetting.column_BusinessTypeName].Value = result.BusinessTypeCode;
            // 職種
            cells[GridInitialSetting.column_JobTypeName].Value = result.JobTypeCode;
            // 地区
            cells[GridInitialSetting.column_SalesAreaName].Value = result.SalesAreaCode;
            // 分析コード1
            if (result.CustAnalysCode1 != 0)
            {
                cells[GridInitialSetting.column_CustAnalysCode1].Value = result.CustAnalysCode1;
            }
            else
            {
                cells[GridInitialSetting.column_CustAnalysCode1].Value = DBNull.Value;
            }
            // 分析コード2
            if (result.CustAnalysCode2 != 0)
            {
                cells[GridInitialSetting.column_CustAnalysCode2].Value = result.CustAnalysCode2;
            }
            else
            {
                cells[GridInitialSetting.column_CustAnalysCode2].Value = DBNull.Value;
            }
            // 分析コード3
            if (result.CustAnalysCode3 != 0)
            {
                cells[GridInitialSetting.column_CustAnalysCode3].Value = result.CustAnalysCode3;
            }
            else
            {
                cells[GridInitialSetting.column_CustAnalysCode3].Value = DBNull.Value;
            }
            // 分析コード4
            if (result.CustAnalysCode4 != 0)
            {
                cells[GridInitialSetting.column_CustAnalysCode4].Value = result.CustAnalysCode4;
            }
            else
            {
                cells[GridInitialSetting.column_CustAnalysCode4].Value = DBNull.Value;
            }
            // 分析コード5
            if (result.CustAnalysCode5 != 0)
            {
                cells[GridInitialSetting.column_CustAnalysCode5].Value = result.CustAnalysCode5;
            }
            else
            {
                cells[GridInitialSetting.column_CustAnalysCode5].Value = DBNull.Value;
            }
            // 分析コード6
            if (result.CustAnalysCode6 != 0)
            {
                cells[GridInitialSetting.column_CustAnalysCode6].Value = result.CustAnalysCode6;
            }
            else
            {
                cells[GridInitialSetting.column_CustAnalysCode6].Value = DBNull.Value;
            }
            // 請求拠点
            if (result.ClaimSectionName.Trim() != "")
            {
                cells[GridInitialSetting.column_ClaimSectionSnm].Value = result.ClaimSectionName.Trim();
                cells[GridInitialSetting.column_ClaimSectionSnm].Tag = result.ClaimSectionCode.Trim();
            }
            else
            {
                cells[GridInitialSetting.column_ClaimSectionSnm].Value = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
                cells[GridInitialSetting.column_ClaimSectionSnm].Tag = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            }
            // 請求先コード
            if (result.ClaimSnm.Trim() != "")
            {
                cells[GridInitialSetting.column_ClaimSnm].Value = result.ClaimSnm.Trim();
                cells[GridInitialSetting.column_ClaimSnm].Tag = result.ClaimCode;
            }
            else
            {
                cells[GridInitialSetting.column_ClaimSnm].Value = result.CustomerCode.ToString("00000000");
                cells[GridInitialSetting.column_ClaimSnm].Tag = result.CustomerCode;
            }
            // 締日
            if (result.TotalDay != 0)
            {
                cells[GridInitialSetting.column_TotalDay].Value = result.TotalDay;
            }
            else
            {
                cells[GridInitialSetting.column_TotalDay].Value = DBNull.Value;
            }
            // 集金月
            cells[GridInitialSetting.column_CollectMoneyName].Value = result.CollectMoneyCode;
            // 集金日
            if (result.CollectMoneyDay != 0)
            {
                cells[GridInitialSetting.column_CollectMoneyDay].Value = result.CollectMoneyDay;
            }
            else
            {
                cells[GridInitialSetting.column_CollectMoneyDay].Value = DBNull.Value;
            }
            // 回収条件
            Dictionary<int, string> collectCondDic = this._gridInitialSetting.GetCollectCondDic();
            if (collectCondDic.ContainsKey(result.CollectCond))
            {
                cells[GridInitialSetting.column_CollectCond].Value = result.CollectCond;
            }
            else
            {
                // 2010/07/14 >>>
                //cells[GridInitialSetting.column_CollectCond].Value = DBNull.Value;
                cells[GridInitialSetting.column_CollectCond].Value = _gridInitialSetting.depositStKindCd1;
                // 2010/07/14 <<<
            }
            // 回収サイト
            if (result.CollectSight != 0)
            {
                cells[GridInitialSetting.column_CollectSight].Value = result.CollectSight;
            }
            else
            {
                cells[GridInitialSetting.column_CollectSight].Value = DBNull.Value;
            }
            // 次回勘定
            if (result.NTimeCalcStDate != 0)
            {
                cells[GridInitialSetting.column_NTimeCalcStDate].Value = result.NTimeCalcStDate;
            }
            else
            {
                cells[GridInitialSetting.column_NTimeCalcStDate].Value = DBNull.Value;
            }
            // 集金担当
            //cells[GridInitialSetting.column_BillCollecterName].Value = result.BillCollecterNm.Trim();
            cells[GridInitialSetting.column_BillCollecterName].Value = GetEmployeeName(result.BillCollecterCd, true);
            cells[GridInitialSetting.column_BillCollecterName].Tag = result.BillCollecterCd.Trim();
            // 転嫁方式参照
            cells[GridInitialSetting.column_CustCTaXLayRefCd].Value = result.CustCTaXLayRefCd;
            // 消費税転嫁方式
            cells[GridInitialSetting.column_ConsTaxLayMethod].Value = result.ConsTaxLayMethod;
            // 与信管理
            cells[GridInitialSetting.column_CreditMngCode].Value = result.CreditMngCode;
            // ADD 2009/04/13 ------>>>
            // 与信額
            if (result.CreditMoney != 0)
            {
                cells[GridInitialSetting.column_CreditMoney].Value = result.CreditMoney.ToString("###,##0");
            }
            else
            {
                cells[GridInitialSetting.column_CreditMoney].Value = DBNull.Value;
            }
            // ADD 2009/04/13 ------<<<
            // 警告与信額
            if (result.WarningCreditMoney != 0)
            {
                cells[GridInitialSetting.column_WarningCreditMoney].Value = result.WarningCreditMoney.ToString("###,##0");
            }
            else
            {
                cells[GridInitialSetting.column_WarningCreditMoney].Value = DBNull.Value;
            }
            // 入金消込
            cells[GridInitialSetting.column_DepoDelCode].Value = result.DepoDelCode;
            // 売掛区分
            cells[GridInitialSetting.column_AccRecDivCd].Value = result.AccRecDivCd;
            // 単価端数
            cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value = result.SalesUnPrcFrcProcCd;
            // 金額端数
            cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value = result.SalesMoneyFrcProcCd;
            // 税端数
            cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value = result.SalesCnsTaxFrcProcCd;
            // 郵便番号
            cells[GridInitialSetting.column_PostNo].Value = result.PostNo.Trim();
            // 住所1
            cells[GridInitialSetting.column_Address1].Value = result.Address1.Trim();
            // 住所2
            cells[GridInitialSetting.column_Address3].Value = result.Address3.Trim();
            // 住所3
            cells[GridInitialSetting.column_Address4].Value = result.Address4.Trim();
            // 自宅TEL
            cells[GridInitialSetting.column_HomeTelNo].Value = result.HomeTelNo.Trim();
            // 自宅FAX
            cells[GridInitialSetting.column_HomeFaxNo].Value = result.HomeFaxNo.Trim();
            // 勤務先電話
            cells[GridInitialSetting.column_OfficeTelNo].Value = result.OfficeTelNo.Trim();
            // 携帯電話
            cells[GridInitialSetting.column_PortableTelNo].Value = result.PortableTelNo.Trim();
            // 勤務先FAX
            cells[GridInitialSetting.column_OfficeFaxNo].Value = result.OfficeFaxNo.Trim();
            // その他電話
            cells[GridInitialSetting.column_OthersTelNo].Value = result.OthersTelNo.Trim();
            // 検索番号
            cells[GridInitialSetting.column_SearchTelNo].Value = result.SearchTelNo.Trim();
            // 主連絡先
            cells[GridInitialSetting.column_MainContactCode].Value = result.MainContactCode.ToString();
            // 得意先担当者
            cells[GridInitialSetting.column_CustomerAgent].Value = result.CustomerAgent.Trim();
            // 主送信先
            cells[GridInitialSetting.column_MainSendMailAddrCd].Value = result.MainSendMailAddrCd;
            // メールアドレス1
            cells[GridInitialSetting.column_MailAddress1].Value = result.MailAddress1.Trim();
            // メール区分1
            cells[GridInitialSetting.column_MailSendCode1].Value = result.MailSendCode1;
            // メール種別1
            cells[GridInitialSetting.column_MailAddrKindCode1].Value = result.MailAddrKindCode1;
            // メールアドレス2
            cells[GridInitialSetting.column_MailAddress2].Value = result.MailAddress2.Trim();
            // メール区分2
            cells[GridInitialSetting.column_MailSendCode2].Value = result.MailSendCode2;
            // メール種別2
            cells[GridInitialSetting.column_MailAddrKindCode2].Value = result.MailAddrKindCode2;
            // 領収書出力区分
            cells[GridInitialSetting.column_ReceiptOutputCode].Value = result.ReceiptOutputCode;    // ADD 2009/04/07
            // 請求書出力
            cells[GridInitialSetting.column_BillOutputCode].Value = result.BillOutputCode;  // TODO:使用しない…請求書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            // 納品書出力（売上伝票発行区分）
            cells[GridInitialSetting.column_SalesSlipPrtDiv].Value = result.SalesSlipPrtDiv;
            // 受注伝票出力（受注伝票発行区分）
            cells[GridInitialSetting.column_AcpOdrrSlipPrtDiv].Value = result.AcpOdrrSlipPrtDiv;
            // 貸出伝票出力（出荷伝票発行区分）
            cells[GridInitialSetting.column_ShipmSlipPrtDiv].Value = result.ShipmSlipPrtDiv;
            // 見積伝票出力（見積伝票発行区分）
            cells[GridInitialSetting.column_EstimatePrtDiv].Value = result.EstimatePrtDiv;
            // UOE伝票出力（UOE伝票発行区分）
            cells[GridInitialSetting.column_UOESlipPrtDiv].Value = result.UOESlipPrtDiv;
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            // 合計請求書出力
            cells[GridInitialSetting.column_TotalBillOutputDiv].Value = result.TotalBillOutputDiv;
            // 明細請求書出力
            cells[GridInitialSetting.column_DetailBillOutputCode].Value = result.DetailBillOutputCode;
            // 伝票合計請求書出力
            cells[GridInitialSetting.column_SlipTtlBillOutputDiv].Value = result.SlipTtlBillOutputDiv;
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            // DM出力
            cells[GridInitialSetting.column_DmOutCode].Value = result.DmOutCode;
            // 相手伝番管理
            cells[GridInitialSetting.column_CustSlipNoMngCd].Value = result.CustSlipNoMngCd;
            // 伝番区分
            cells[GridInitialSetting.column_CustomerSlipNoDiv].Value = result.CustomerSlipNoDiv;
            // QRコード印刷
            cells[GridInitialSetting.column_QrcodePrtCd].Value = result.QrcodePrtCd;

            // 得意先種別チェック
            if (result.AcceptWholeSale == 2)
            {
                // 得意先種別変更時処理
                ChangeAcceptWholeSale(ref this.uGrid_Details, rowIndex);

                this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                this._cellUpdateFlg = false;
            }

            // 請求先コードチェック
            if (result.AcceptWholeSale == 1)
            {
                if (result.CustomerCode != result.ClaimCode)
                {
                    // 請求先コード変更時処理
                    ChangeClaimCode(ref this.uGrid_Details, rowIndex);
                }

                if (result.CustomerCode == result.ClaimCode)
                {
                    // 転嫁方式参照変更時処理
                    ChangeCustCTaXLayRefCd(ref this.uGrid_Details, rowIndex);
                }

                // 与信管理変更時処理
                ChangeCreditMngCode(ref this.uGrid_Details, rowIndex);
            }

            object[] param = new object[cells.Count];

            for (int index = 0; index < cells.Count; index++)
            {
                param[index] = cells[index].Value;
            }

            this._searchTable.Rows.Add(param);
        }

        /// <summary>
        /// 画面情報取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <remarks>
        /// <br>Note        : 画面情報から保存リストを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ScreenToCustomerCustomerChangeResult(out ArrayList saveList)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this._activeCell = this.uGrid_Details.ActiveCell;

                this.uGrid_Details.ActiveCell = null;
            }

            saveList = new ArrayList();

            int customerCode;
            CustomerCustomerChangeResult result;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                // 得意先コード取得
                customerCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[GridInitialSetting.column_CustomerCode].Value);

                result = (CustomerCustomerChangeResult)this._searchListDic[customerCode];

                // 画面情報取得
                ScreenToCustomerCustomerChangeResult(ref result, index, true);

                saveList.Add(result.Clone());
            }
        }

        /// <summary>
        /// 画面情報取得処理
        /// </summary>
        /// <param name="result">得意先情報</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="saveFlg">保存フラグ(True:保存前　False:前回値取得時)</param>
        /// <remarks>
        /// <br>Note        : 画面情報から得意先情報を作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ScreenToCustomerCustomerChangeResult(ref CustomerCustomerChangeResult result, int rowIndex, bool saveFlg)
        {
            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            // 得意先種別
            int acceptWholeSale;
            if (saveFlg)
            {
                acceptWholeSale = (int)cells[GridInitialSetting.column_AcceptWholeSale].Value;
            }
            else
            {
                acceptWholeSale = 1;
            }

            // 得意先コード
            result.CustomerCode = StrObjToInt(cells[GridInitialSetting.column_CustomerCode].Value);
            // 得意先名1
            result.Name = StrObjToString(cells[GridInitialSetting.column_CustomerName].Value);
            // 得意先名2
            result.Name2 = StrObjToString(cells[GridInitialSetting.column_CustomerName2].Value);
            // 郵便番号
            result.PostNo = StrObjToString(cells[GridInitialSetting.column_PostNo].Value);
            // 住所1
            result.Address1 = StrObjToString(cells[GridInitialSetting.column_Address1].Value);
            // 住所2
            result.Address3 = StrObjToString(cells[GridInitialSetting.column_Address3].Value);
            // 住所3
            result.Address4 = StrObjToString(cells[GridInitialSetting.column_Address4].Value);
            // 勤務先TEL
            result.OfficeTelNo = StrObjToString(cells[GridInitialSetting.column_OfficeTelNo].Value);
            // 勤務先FAX
            result.OfficeFaxNo = StrObjToString(cells[GridInitialSetting.column_OfficeFaxNo].Value);
            // 得意先種別
            result.AcceptWholeSale = IntObjToInt(cells[GridInitialSetting.column_AcceptWholeSale].Value);

            if (acceptWholeSale == 1)
            {
                // サブコード
                result.CustomerSubCode = StrObjToString(cells[GridInitialSetting.column_CustomerSubCode].Value);
                // 得意先略称
                result.CustomerSnm = StrObjToString(cells[GridInitialSetting.column_CustomerSnm].Value);
                // 得意先名(カナ)
                result.Kana = StrObjToString(cells[GridInitialSetting.column_CustomerKana].Value);
                // 敬称
                result.HonorificTitle = StrObjToString(cells[GridInitialSetting.column_HonorificTitle].Value);
                // 諸口コード
                result.OutputNameCode = IntObjToInt(cells[GridInitialSetting.column_OutputName].Value);
                // 諸口名
                // DEL 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ---------->>>>>
                //result.OutputName = cells[GridInitialSetting.column_OutputName].Text.Trim();
                // DEL 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ----------<<<<<
                // ADD 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ---------->>>>>
                result.OutputName = TrimCode(cells[GridInitialSetting.column_OutputName].Text.Trim());
                // ADD 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ----------<<<<<

                // 管理拠点名
                result.MngSectionName = StrObjToString(cells[GridInitialSetting.column_MngSectionName].Value);
                // 管理拠点コード
                result.MngSectionCode = StrObjToString(cells[GridInitialSetting.column_MngSectionName].Tag);
                // 得意先担当者名
                result.CustomerAgentNm = StrObjToString(cells[GridInitialSetting.column_CustomerAgentName].Value);
                // 得意先担当者コード
                if (result.CustomerAgentNm == "")
                {
                    result.CustomerAgentCd = "";
                }
                else
                {
                    result.CustomerAgentCd = StrObjToString(cells[GridInitialSetting.column_CustomerAgentName].Tag);
                }
                // 旧担当者名
                result.OldCustomerAgentNm = StrObjToString(cells[GridInitialSetting.column_OldCustomerAgentName].Value);
                // 旧担当者コード
                if (result.OldCustomerAgentNm == "")
                {
                    result.OldCustomerAgentCd = "";
                }
                else
                {
                    result.OldCustomerAgentCd = StrObjToString(cells[GridInitialSetting.column_OldCustomerAgentName].Tag);
                }
                // 担当者変更日
                result.CustAgentChgDate = DateTimeObjToDateTime(cells[GridInitialSetting.column_CustAgentChgDate].Value);
                // 取引中止日
                result.TransStopDate = DateTimeObjToDateTime(cells[GridInitialSetting.column_TransStopDate].Value);
                // 車輌管理
                result.CarMngDivCd = IntObjToInt(cells[GridInitialSetting.column_CarMngDivCd].Value);
                // 個人・法人
                result.CorporateDivCode = IntObjToInt(cells[GridInitialSetting.column_CorporateDivCode].Value);
                // 得意先属性
                result.CustomerAttributeDiv = IntObjToInt(cells[GridInitialSetting.column_CustomerAttributeDiv].Value);
                // 優先倉庫名
                result.CustWarehouseName = StrObjToString(cells[GridInitialSetting.column_CustWarehouseName].Value);
                // 優先倉庫コード
                if (result.CustWarehouseName == "")
                {
                    result.CustWarehouseCd = "";
                }
                else
                {
                    result.CustWarehouseCd = StrObjToString(cells[GridInitialSetting.column_CustWarehouseName].Tag);
                }
                // 業種
                result.BusinessTypeCode = IntObjToInt(cells[GridInitialSetting.column_BusinessTypeName].Value);
                // 職種
                result.JobTypeCode = IntObjToInt(cells[GridInitialSetting.column_JobTypeName].Value);
                // 地区
                result.SalesAreaCode = IntObjToInt(cells[GridInitialSetting.column_SalesAreaName].Value);
                // 分析コード1
                result.CustAnalysCode1 = IntObjToInt(cells[GridInitialSetting.column_CustAnalysCode1].Value);
                // 分析コード2
                result.CustAnalysCode2 = IntObjToInt(cells[GridInitialSetting.column_CustAnalysCode2].Value);
                // 分析コード3
                result.CustAnalysCode3 = IntObjToInt(cells[GridInitialSetting.column_CustAnalysCode3].Value);
                // 分析コード4
                result.CustAnalysCode4 = IntObjToInt(cells[GridInitialSetting.column_CustAnalysCode4].Value);
                // 分析コード5
                result.CustAnalysCode5 = IntObjToInt(cells[GridInitialSetting.column_CustAnalysCode5].Value);
                // 分析コード6
                result.CustAnalysCode6 = IntObjToInt(cells[GridInitialSetting.column_CustAnalysCode6].Value);
                // 請求拠点コード
                result.ClaimSectionCode = StrObjToString(cells[GridInitialSetting.column_ClaimSectionSnm].Tag);
                // 請求拠点名
                result.ClaimSectionName = StrObjToString(cells[GridInitialSetting.column_ClaimSectionSnm].Value);
                // 請求先コード
                result.ClaimCode = IntObjToInt(cells[GridInitialSetting.column_ClaimSnm].Tag);
                // 請求先名
                if (result.CustomerCode == result.ClaimCode)
                {
                    result.ClaimSnm = result.CustomerSnm;
                }
                else
                {
                    result.ClaimSnm = StrObjToString(cells[GridInitialSetting.column_ClaimSnm].Value);
                }
                // 締日
                result.TotalDay = IntObjToInt(cells[GridInitialSetting.column_TotalDay].Value);
                // 集金月コード
                result.CollectMoneyCode = IntObjToInt(cells[GridInitialSetting.column_CollectMoneyName].Value);
                // 集金月名
                // DEL 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ---------->>>>>
                // result.CollectMoneyName = cells[GridInitialSetting.column_CollectMoneyName].Text.Trim();
                // DEL 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ----------<<<<<
                // ADD 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ---------->>>>>
                result.CollectMoneyName = TrimCode(cells[GridInitialSetting.column_CollectMoneyName].Text.Trim());
                // ADD 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ----------<<<<<
                
                // 集金日
                result.CollectMoneyDay = IntObjToInt(cells[GridInitialSetting.column_CollectMoneyDay].Value);
                // 回収条件
                result.CollectCond = IntObjToInt(cells[GridInitialSetting.column_CollectCond].Value);
                // 回収サイト
                result.CollectSight = IntObjToInt(cells[GridInitialSetting.column_CollectSight].Value);
                // 次回勘定
                result.NTimeCalcStDate = IntObjToInt(cells[GridInitialSetting.column_NTimeCalcStDate].Value);
                // 集金担当者名
                result.BillCollecterNm = StrObjToString(cells[GridInitialSetting.column_BillCollecterName].Value);
                // 集金担当者コード
                if (result.BillCollecterNm == "")
                {
                    result.BillCollecterCd = "";
                }
                else
                {
                    result.BillCollecterCd = StrObjToString(cells[GridInitialSetting.column_BillCollecterName].Tag);
                }
                // 転嫁方式参照
                result.CustCTaXLayRefCd = IntObjToInt(cells[GridInitialSetting.column_CustCTaXLayRefCd].Value);
                // 消費税転嫁方式
                if (result.CustCTaXLayRefCd == 1)
                {
                    result.ConsTaxLayMethod = IntObjToInt(cells[GridInitialSetting.column_ConsTaxLayMethod].Value);
                }
                // 与信管理
                result.CreditMngCode = IntObjToInt(cells[GridInitialSetting.column_CreditMngCode].Value);
                // 与信額
                // 警告与信額
                if (result.CreditMngCode == 1)
                {
                    result.CreditMoney = StrObjToLong(cells[GridInitialSetting.column_CreditMoney].Value);      // ADD 2009/04/13
                    result.WarningCreditMoney = StrObjToLong(cells[GridInitialSetting.column_WarningCreditMoney].Value);
                }
                // 入金消込
                result.DepoDelCode = IntObjToInt(cells[GridInitialSetting.column_DepoDelCode].Value);
                // 売掛区分
                result.AccRecDivCd = IntObjToInt(cells[GridInitialSetting.column_AccRecDivCd].Value);
                // 単価端数
                result.SalesUnPrcFrcProcCd = IntObjToInt(cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value);
                // 金額端数
                result.SalesMoneyFrcProcCd = IntObjToInt(cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value);
                // 税端数
                result.SalesCnsTaxFrcProcCd = IntObjToInt(cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value);
                // 自宅TEL
                result.HomeTelNo = StrObjToString(cells[GridInitialSetting.column_HomeTelNo].Value);
                // 自宅FAX
                result.HomeFaxNo = StrObjToString(cells[GridInitialSetting.column_HomeFaxNo].Value);
                // 携帯電話
                result.PortableTelNo = StrObjToString(cells[GridInitialSetting.column_PortableTelNo].Value);
                // その他電話
                result.OthersTelNo = StrObjToString(cells[GridInitialSetting.column_OthersTelNo].Value);
                // 検索番号
                result.SearchTelNo = StrObjToString(cells[GridInitialSetting.column_SearchTelNo].Value);
                // 主連絡先
                result.MainContactCode = IntObjToInt(cells[GridInitialSetting.column_MainContactCode].Value);
                // 得意先担当者
                result.CustomerAgent = StrObjToString(cells[GridInitialSetting.column_CustomerAgent].Value);
                // 主送信先
                result.MainSendMailAddrCd = IntObjToInt(cells[GridInitialSetting.column_MainSendMailAddrCd].Value);
                // メールアドレス1
                result.MailAddress1 = StrObjToString(cells[GridInitialSetting.column_MailAddress1].Value);
                // メール区分1
                result.MailSendCode1 = IntObjToInt(cells[GridInitialSetting.column_MailSendCode1].Value);
                // メール種別1
                result.MailAddrKindCode1 = IntObjToInt(cells[GridInitialSetting.column_MailAddrKindCode1].Value);
                // メールアドレス2
                result.MailAddress2 = StrObjToString(cells[GridInitialSetting.column_MailAddress2].Value);
                // メール区分2
                result.MailSendCode2 = IntObjToInt(cells[GridInitialSetting.column_MailSendCode2].Value);
                // メール種別2
                result.MailAddrKindCode2 = IntObjToInt(cells[GridInitialSetting.column_MailAddrKindCode2].Value);
                // 領収書出力区分
                result.ReceiptOutputCode = IntObjToInt(cells[GridInitialSetting.column_ReceiptOutputCode].Value);   // ADD 2009/04/07
                // 請求書出力
                result.BillOutputCode = IntObjToInt(cells[GridInitialSetting.column_BillOutputCode].Value); // TODO:使用しない…請求書出力区分コード

                // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
                result.SalesSlipPrtDiv  = IntObjToInt(cells[GridInitialSetting.column_SalesSlipPrtDiv].Value);      // 納品書出力（売上伝票発行区分）
                result.AcpOdrrSlipPrtDiv= IntObjToInt(cells[GridInitialSetting.column_AcpOdrrSlipPrtDiv].Value);    // 受注伝票出力（受注伝票発行区分）
                result.ShipmSlipPrtDiv  = IntObjToInt(cells[GridInitialSetting.column_ShipmSlipPrtDiv].Value);      // 貸出伝票出力（出荷伝票発行区分）
                result.EstimatePrtDiv   = IntObjToInt(cells[GridInitialSetting.column_EstimatePrtDiv].Value);       // 見積伝票出力（見積伝票発行区分）
                result.UOESlipPrtDiv    = IntObjToInt(cells[GridInitialSetting.column_UOESlipPrtDiv].Value); ;      // UOE伝票出力（UOE伝票発行区分）
                // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

                // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
                result.TotalBillOutputDiv   = IntObjToInt(cells[GridInitialSetting.column_TotalBillOutputDiv].Value);   // 合計請求書出力
                result.DetailBillOutputCode = IntObjToInt(cells[GridInitialSetting.column_DetailBillOutputCode].Value); // 明細請求書出力
                result.SlipTtlBillOutputDiv = IntObjToInt(cells[GridInitialSetting.column_SlipTtlBillOutputDiv].Value); // 伝票合計請求書出力
                // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

                // DM出力
                result.DmOutCode = IntObjToInt(cells[GridInitialSetting.column_DmOutCode].Value);
                // 相手伝番管理
                result.CustSlipNoMngCd = IntObjToInt(cells[GridInitialSetting.column_CustSlipNoMngCd].Value);
                // 伝番区分
                result.CustomerSlipNoDiv = IntObjToInt(cells[GridInitialSetting.column_CustomerSlipNoDiv].Value);
                // QRコード印刷
                result.QrcodePrtCd = IntObjToInt(cells[GridInitialSetting.column_QrcodePrtCd].Value);
            }
            else
            {
                // サブコード
                result.CustomerSubCode = "";
                // 得意先略称
                result.CustomerSnm = "";
                // 得意先名(カナ)
                result.Kana = "";
                // 敬称
                result.HonorificTitle = "";
                // 諸口コード
                result.OutputNameCode = 0;
                // 諸口名
                result.OutputName = "";
                // 管理拠点コード
                result.MngSectionCode = "";
                // 管理拠点名
                result.MngSectionName = "";
                // 得意先担当者コード
                result.CustomerAgentCd = "";
                // 得意先担当者名
                result.CustomerAgentNm = "";
                // 旧担当者コード
                result.OldCustomerAgentCd = "";
                // 旧担当者名
                result.OldCustomerAgentNm = "";
                // 担当者変更日
                result.CustAgentChgDate = DateTime.MinValue;
                // 取引中止日
                result.TransStopDate = DateTime.MinValue;
                // 車輌管理
                result.CarMngDivCd = 0;
                // 個人・法人
                result.CorporateDivCode = 0;
                // 得意先属性
                result.CustomerAttributeDiv = 0;
                // 優先倉庫コード
                result.CustWarehouseCd = "";
                // 優先倉庫名
                result.CustWarehouseName = "";
                // 業種
                result.BusinessTypeCode = 0;
                // 職種
                result.JobTypeCode = 0;
                // 地区
                result.SalesAreaCode = 0;
                // 分析コード1
                result.CustAnalysCode1 = 0;
                // 分析コード2
                result.CustAnalysCode2 = 0;
                // 分析コード3
                result.CustAnalysCode3 = 0;
                // 分析コード4
                result.CustAnalysCode4 = 0;
                // 分析コード5
                result.CustAnalysCode5 = 0;
                // 分析コード6
                result.CustAnalysCode6 = 0;
                // 請求拠点コード
                result.ClaimSectionCode = "";
                // 請求拠点名
                result.ClaimSectionName = "";
                // 請求先コード
                result.ClaimCode = 0;
                // 請求先名
                result.ClaimSnm = "";
                // 締日
                result.TotalDay = 0;
                // 集金月コード
                result.CollectMoneyCode = 0;
                // 集金月名
                result.CollectMoneyName = "";
                // 集金日
                result.CollectMoneyDay = 0;
                // 回収条件
                result.CollectCond = 0;
                // 回収サイト
                result.CollectSight = 0;
                // 次回勘定
                result.NTimeCalcStDate = 0;
                // 集金担当者コード
                result.BillCollecterCd = "";
                // 集金担当者名
                result.BillCollecterNm = "";
                // 総額表示参照
                result.TotalAmntDspWayRef = 0;
                // 総額表示方法
                result.TotalAmountDispWayCd = 0;
                // 転嫁方式参照
                result.CustCTaXLayRefCd = 0;
                // 消費税転嫁方式
                result.ConsTaxLayMethod = 0;
                // 与信管理
                result.CreditMngCode = 0;
                // 与信額
                result.CreditMoney = 0;     // ADD 2009/04/13
                // 警告与信額
                result.WarningCreditMoney = 0;
                // 入金消込
                result.DepoDelCode = 0;
                // 売掛区分
                result.AccRecDivCd = 0;
                // 単価端数
                result.SalesUnPrcFrcProcCd = 0;
                // 金額端数
                result.SalesMoneyFrcProcCd = 0;
                // 税端数
                result.SalesCnsTaxFrcProcCd = 0;
                // 自宅TEL
                result.HomeTelNo = "";
                // 自宅FAX
                result.HomeFaxNo = "";
                // 携帯電話
                result.PortableTelNo = "";
                // その他電話
                result.OthersTelNo = "";
                // 検索番号
                result.SearchTelNo = "";
                // 主連絡先
                result.MainContactCode = 0;
                // 得意先担当者
                result.CustomerAgent = "";
                // 主送信先
                result.MainSendMailAddrCd = 0;
                // メールアドレス1
                result.MailAddress1 = "";
                // メール区分1
                result.MailSendCode1 = 0;
                // メール種別1
                result.MailAddrKindCode1 = 0;
                // メールアドレス2
                result.MailAddress2 = "";
                // メール区分2
                result.MailSendCode2 = 0;
                // メール種別2
                result.MailAddrKindCode2 = 0;
                // 領収書出力区分
                result.ReceiptOutputCode = 0;   // ADD 2009/04/07
                // 請求書出力
                result.BillOutputCode = 0;  // TODO:使用しない…請求書出力区分コード

                // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
                // 納品書出力（売上伝票発行区分）
                result.SalesSlipPrtDiv = 0;
                // 受注伝票出力（受注伝票発行区分）
                result.AcpOdrrSlipPrtDiv = 0;
                // 貸出伝票出力（出荷伝票発行区分）
                result.ShipmSlipPrtDiv = 0;
                // 見積伝票出力（見積伝票発行区分）
                result.EstimatePrtDiv = 0;
                // UOE伝票出力（UOE伝票発行区分）
                result.UOESlipPrtDiv = 0;
                // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

                // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
                // 合計請求書出力
                result.TotalBillOutputDiv = 0;
                // 明細請求書出力
                result.DetailBillOutputCode = 0;
                // 伝票合計請求書出力
                result.SlipTtlBillOutputDiv = 0;
                // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

                // DM出力
                result.DmOutCode = 0;
                // 相手伝番管理
                result.CustSlipNoMngCd = 0;
                // 伝番区分
                result.CustomerSlipNoDiv = 0;
                // QRコード印刷
                result.QrcodePrtCd = 0;
            }
        }

        // ADD 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ---------->>>>>
        /// <summary>
        /// "コード(区分):名称"から名称を取得します。
        /// </summary>
        /// <param name="codeWithName">"コード(区分):名称"</param>
        /// <returns>"コード(区分):名称"の名称を返します。</returns>
        private static string TrimCode(string codeWithName)
        {
            if (string.IsNullOrEmpty(codeWithName)) return string.Empty;

            string[] splitedCodeWithName = codeWithName.Split(':');

            return splitedCodeWithName.Length < 2 ? codeWithName : splitedCodeWithName[1];
        }
        // ADD 2010/02/24 MANTIS対応[15035]：区分名称に区分値が付加されたまま更新している ----------<<<<<

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (status);
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 画面情報取得
                ArrayList saveList;
                ScreenToCustomerCustomerChangeResult(out saveList);

                // TODO:更新処理
                status = this._customerCustomerChangeAcs.Write(ref saveList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 得意先変動情報を変更されるので最新情報を取得
                            ReadCustomerChange();   // ADD 2009/04/13

                            // 登録完了ダイアログ表示
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);

                            // 画面初期化
                            ClearScreen();

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            string errMsg;
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                errMsg = "既に他端末より更新されています。";
                            }
                            else
                            {
                                errMsg = "既に他端末より削除されています。";
                            }

                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "Save",
                                       errMsg,
                                       status,
                                       MessageBoxButtons.OK);

                            this.uGrid_Details.ActiveCell = this._activeCell;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (status);
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Save",
                                       "保存処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);
                            this.uGrid_Details.ActiveCell = this._activeCell;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (status);
                        }
                }
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int Search()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 検索前チェック
            if ((this.tNedit_CustomerCode_St.GetInt() != 0) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "得意先の範囲指定が不正です。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    this.tNedit_CustomerCode_St.Focus();
                    return (-1);
                }
            }

            // 検索条件格納
            CustomerCustomerChangeParam extrInfo;
            SetExtrInfo(out extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "得意先マスタの抽出中です。";

            try
            {
                msgForm.Show();

                List<CustomerCustomerChangeResult> retList;

                // 検索処理
                status = this._customerCustomerChangeAcs.Search(out retList, extrInfo, ConstantManagement.LogicalMode.GetData0);
                if (status == 0)
                {
                    // 画面表示
                    CustomerCustomerChangeResultToScreen(retList);
                    return (status);
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "検索条件に該当する得意先マスタは存在しません。",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // グリッドクリア
                        this.uGrid_Details.DataSource = this._gridInitialSetting.CreateColumn();
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "検索処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッドクリア
                        this.uGrid_Details.DataSource = this._gridInitialSetting.CreateColumn();
                        return (status);
                    }
            }
        }

        /// <summary>
        /// ユーザー設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ユーザー設定画面を表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void SetUp()
        {
            PMKHN09351UC pmkhn09351UC = new PMKHN09351UC();
            pmkhn09351UC.ShowDialog();

            this._cellMove = pmkhn09351UC.CellMove;
        }

        #region チェック処理
        /// <summary>
        /// 画面情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報をチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// <br>Update Note : 2010/06/08 　楊明俊 得意先担当者を必須入力としないように変更する。</br>
        /// <br>Programmer  : 田村顕成</br>
        /// <br>Date        : 2022/03/04</br>
        /// <br>Update Note : 電子帳簿連携対応　ラベル項目の変更（DM出力→電子帳簿出力）</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    errMsg = "保存対象データが存在しません。";
                    this.tNedit_CustomerCode_St.Focus();
                    return (false);
                }

                if (this.uGrid_Details.ActiveCell != null)
                {
                    this._activeCell = this.uGrid_Details.ActiveCell;

                    this.uGrid_Details.ActiveCell = null;
                }

                CellsCollection cells;
                bool updateFlg = false;

                for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
                {
                    cells = this.uGrid_Details.Rows[index].Cells;

                    // 変更した得意先のみエラーチェックを行う
                    for (int colIndex = 0; colIndex < cells.Count; colIndex++)
                    {
                        if (cells[colIndex].Appearance.BackColor == Color.Lime)
                        {
                            updateFlg = true;
                            break;
                        }
                    }

                    if (!updateFlg)
                    {
                        continue;
                    }

                    // 得意先種別
                    int acceptWholeSale = (int)cells[GridInitialSetting.column_AcceptWholeSale].Value;

                    if (StrObjToString(cells[GridInitialSetting.column_CustomerName].Value) == "")
                    {
                        errMsg = "得意先名1を入力してください。";
                        cells[GridInitialSetting.column_CustomerName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        return (false);
                    }
                    if (acceptWholeSale == 1)
                    {
                        // 2010/07/14 Del >>>
                        //if (StrObjToString(cells[GridInitialSetting.column_CustomerSnm].Value) == "")
                        //{
                        //    errMsg = "得意先略称を入力してください。";
                        //    cells[GridInitialSetting.column_CustomerSnm].Activate();
                        //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        //    return (false);
                        //}
                        // 2010/07/14 Del <<<
                        if (StrObjToString(cells[GridInitialSetting.column_CustomerKana].Value) == "")
                        {
                            errMsg = "得意先名(ｶﾅ)を入力してください。";
                            cells[GridInitialSetting.column_CustomerKana].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_OutputName].Text.Trim() == "")
                        {
                            errMsg = "諸口を選択してください。";
                            cells[GridInitialSetting.column_OutputName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (StrObjToString(cells[GridInitialSetting.column_MngSectionName].Value) == "")
                        {
                            errMsg = "管理拠点を入力してください。";
                            cells[GridInitialSetting.column_MngSectionName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MngSectionName].Tag != null)
                        {
                            string sectionCode = StrObjToString(cells[GridInitialSetting.column_MngSectionName].Tag);
                            if (GetSectionName(sectionCode) == "")
                            {
                                errMsg = "マスタに登録されてません。";
                                cells[GridInitialSetting.column_MngSectionName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                        }

                        // --- DEL 2010/06/08 ---------->>>>>
                        //if (StrObjToString(cells[GridInitialSetting.column_CustomerAgentName].Value) == "")
                        //{
                        //    errMsg = "得意先担当を入力してください。";
                        //    cells[GridInitialSetting.column_CustomerAgentName].Activate();
                        //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        //    return (false);
                        //}

                        //if (cells[GridInitialSetting.column_CustomerAgentName].Tag != null)
                        //{
                        //    string employeeCode = StrObjToString(cells[GridInitialSetting.column_CustomerAgentName].Tag);
                        //    if (GetEmployeeName(employeeCode, false) == "")
                        //    {
                        //        errMsg = "マスタに登録されてません。";
                        //        cells[GridInitialSetting.column_CustomerAgentName].Activate();
                        //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        //        return (false);
                        //    }
                        //}
                        // --- DEL 2010/06/08 ----------<<<<< 
                        if (cells[GridInitialSetting.column_OldCustomerAgentName].Text.Trim() != "")
                        {
                            if (cells[GridInitialSetting.column_OldCustomerAgentName].Tag != null)
                            {
                                string employeeCode = StrObjToString(cells[GridInitialSetting.column_OldCustomerAgentName].Tag);
                                if (GetEmployeeName(employeeCode, false) == "")
                                {
                                    errMsg = "マスタに登録されてません。";
                                    cells[GridInitialSetting.column_OldCustomerAgentName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return (false);
                                }
                            }
                        }
                        if (cells[GridInitialSetting.column_CarMngDivCd].Text.Trim() == "")
                        {
                            errMsg = "車輌管理を選択してください。";
                            cells[GridInitialSetting.column_CarMngDivCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CorporateDivCode].Text.Trim() == "")
                        {
                            errMsg = "個人・法人を選択してください。";
                            cells[GridInitialSetting.column_CorporateDivCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_AcceptWholeSale].Text.Trim() == "")
                        {
                            errMsg = "得意先種別を選択してください。";
                            cells[GridInitialSetting.column_AcceptWholeSale].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CustomerAttributeDiv].Text.Trim() == "")
                        {
                            errMsg = "得意先属性を選択してください。";
                            cells[GridInitialSetting.column_CustomerAttributeDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CustWarehouseName].Text.Trim() != "")
                        {
                            if (cells[GridInitialSetting.column_CustWarehouseName].Tag != null)
                            {
                                string warehouseCode = StrObjToString(cells[GridInitialSetting.column_CustWarehouseName].Tag);
                                if (GetWarehouseName(warehouseCode) == "")
                                {
                                    errMsg = "マスタに登録されてません。";
                                    cells[GridInitialSetting.column_CustWarehouseName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return (false);
                                }
                            }
                        }
                        if (StrObjToString(cells[GridInitialSetting.column_ClaimSectionSnm].Value) == "")
                        {
                            errMsg = "請求拠点を入力してください。";
                            cells[GridInitialSetting.column_ClaimSectionSnm].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_ClaimSectionSnm].Tag != null)
                        {
                            string sectionCode = StrObjToString(cells[GridInitialSetting.column_ClaimSectionSnm].Tag);
                            if (GetSectionName(sectionCode) == "")
                            {
                                errMsg = "マスタに登録されてません。";
                                cells[GridInitialSetting.column_ClaimSectionSnm].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                        }
                        if (StrObjToString(cells[GridInitialSetting.column_ClaimSnm].Value) == "")
                        {
                            errMsg = "請求先ｺｰﾄﾞを入力してください。";
                            cells[GridInitialSetting.column_ClaimSnm].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_ClaimSnm].Tag != null)
                        {
                            int claimCode = IntObjToInt(cells[GridInitialSetting.column_ClaimSnm].Tag);
                            int customerCode = StrObjToInt(cells[GridInitialSetting.column_CustomerCode].Value);

                            if (claimCode != customerCode)
                            {
                                if (GetCustomerSnm(claimCode) == "")
                                {
                                    errMsg = "マスタに登録されてません。";
                                    cells[GridInitialSetting.column_ClaimSnm].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return (false);
                                }
                            }
                        }
                        if (IntObjToInt(cells[GridInitialSetting.column_TotalDay].Value) == 0)
                        {
                            errMsg = "締日を入力してください。";
                            cells[GridInitialSetting.column_TotalDay].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (IntObjToInt(cells[GridInitialSetting.column_TotalDay].Value) > 31)
                        {
                            errMsg = "締日の値が不正です。";
                            cells[GridInitialSetting.column_TotalDay].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CollectMoneyName].Text.Trim() == "")
                        {
                            errMsg = "集金月を選択してください。";
                            cells[GridInitialSetting.column_CollectMoneyName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (IntObjToInt(cells[GridInitialSetting.column_CollectMoneyDay].Value) == 0)
                        {
                            errMsg = "集金日を入力してください。";
                            cells[GridInitialSetting.column_CollectMoneyDay].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (IntObjToInt(cells[GridInitialSetting.column_CollectMoneyDay].Value) > 31)
                        {
                            errMsg = "集金日の値が不正です。";
                            cells[GridInitialSetting.column_CollectMoneyDay].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CollectCond].Text.Trim() == "")
                        {
                            errMsg = "回収条件を選択してください。";
                            cells[GridInitialSetting.column_CollectCond].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_BillCollecterName].Text.Trim() != "")
                        {
                            if (cells[GridInitialSetting.column_BillCollecterName].Tag != null)
                            {
                                string employeeCode = StrObjToString(cells[GridInitialSetting.column_BillCollecterName].Tag);
                                if (GetEmployeeName(employeeCode, false) == "")
                                {
                                    errMsg = "マスタに登録されてません。";
                                    cells[GridInitialSetting.column_BillCollecterName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return (false);
                                }
                            }
                        }
                        if (cells[GridInitialSetting.column_CustCTaXLayRefCd].Text.Trim() == "")
                        {
                            errMsg = "転嫁方式参照を選択してください。";
                            cells[GridInitialSetting.column_CustCTaXLayRefCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (IntObjToInt(cells[GridInitialSetting.column_CustCTaXLayRefCd].Value) == 1)
                        {
                            if (cells[GridInitialSetting.column_ConsTaxLayMethod].Text.Trim() == "")
                            {
                                errMsg = "消費税転嫁方式を選択してください。";
                                cells[GridInitialSetting.column_ConsTaxLayMethod].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                        }
                        if (cells[GridInitialSetting.column_CreditMngCode].Text.Trim() == "")
                        {
                            errMsg = "与信管理を選択してください。";
                            cells[GridInitialSetting.column_CreditMngCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (IntObjToInt(cells[GridInitialSetting.column_CreditMngCode].Value) == 1)
                        {
                            // ADD 2009/04/13 ------>>>
                            if (cells[GridInitialSetting.column_CreditMoney].Text.Trim() == "")
                            {
                                errMsg = "与信額を入力してください。";
                                cells[GridInitialSetting.column_CreditMoney].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                            // ADD 2009/04/13 ------<<<
                            if (cells[GridInitialSetting.column_WarningCreditMoney].Text.Trim() == "")
                            {
                                errMsg = "警告与信額を入力してください。";
                                cells[GridInitialSetting.column_WarningCreditMoney].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }

                            // DEL 2009/04/13 ------>>>
                            //int customerCode = StrObjToInt(cells[GridInitialSetting.column_CustomerCode].Value);
                            //CustomerChange customerChange;
                            //int status = GetCustomerChange(out customerChange, customerCode);
                            //if (status == 0)
                            //{
                            //    // 警告与信額
                            //    long warningCreditMoney = StrObjToLong(cells[GridInitialSetting.column_WarningCreditMoney].Value);
                            //    if (customerChange.CreditMoney < warningCreditMoney)
                            //    {
                            //        errMsg = "警告与信額が与信額（" + customerChange.CreditMoney.ToString("###,##0") + "）を超えています。";
                            //        cells[GridInitialSetting.column_WarningCreditMoney].Activate();
                            //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            //        return (false);
                            //    }
                            //}
                            // DEL 2009/04/13 ------<<<

                            // ADD 2009/04/13 ------>>>
                            // 警告与信額
                            long creditMoney = StrObjToLong(cells[GridInitialSetting.column_CreditMoney].Value);
                            long warningCreditMoney = StrObjToLong(cells[GridInitialSetting.column_WarningCreditMoney].Value);
                            //if (creditMoney < warningCreditMoney)     // DEL 2009/04/14
                            if ((creditMoney > 0) &&
                                (creditMoney < warningCreditMoney) &&
                                (creditMoney != warningCreditMoney))    // ADD 2009/04/14
                            {
                                errMsg = "警告与信額が与信額（" + creditMoney.ToString("###,##0") + "）を超えています。";
                                cells[GridInitialSetting.column_WarningCreditMoney].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                            // ADD 2009/04/13 ------<<<
                        }
                        if (cells[GridInitialSetting.column_DepoDelCode].Text.Trim() == "")
                        {
                            errMsg = "入金消込を選択してください。";
                            cells[GridInitialSetting.column_DepoDelCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_AccRecDivCd].Text.Trim() == "")
                        {
                            errMsg = "売掛区分を選択してください。";
                            cells[GridInitialSetting.column_AccRecDivCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (ExistsSalesProcMoney(2, IntObjToInt(cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value)) == false)
                        {
                            errMsg = "マスタに登録されていません。";
                            cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (ExistsSalesProcMoney(0, IntObjToInt(cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value)) == false)
                        {
                            errMsg = "マスタに登録されていません。";
                            cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        } 
                        if (ExistsSalesProcMoney(1, IntObjToInt(cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value)) == false)
                        {
                            errMsg = "マスタに登録されていません。";
                            cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MainContactCode].Text.Trim() == "")
                        {
                            errMsg = "主連絡先を選択してください。";
                            cells[GridInitialSetting.column_MainContactCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MainSendMailAddrCd].Text.Trim() == "")
                        {
                            errMsg = "主送信先を選択してください。";
                            cells[GridInitialSetting.column_MainSendMailAddrCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MailSendCode1].Text.Trim() == "")
                        {
                            errMsg = "ﾒｰﾙ区分1を選択してください。";
                            cells[GridInitialSetting.column_MailSendCode1].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MailAddrKindCode1].Text.Trim() == "")
                        {
                            errMsg = "ﾒｰﾙ種別1を選択してください。";
                            cells[GridInitialSetting.column_MailAddrKindCode1].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MailSendCode2].Text.Trim() == "")
                        {
                            errMsg = "ﾒｰﾙ区分2を選択してください。";
                            cells[GridInitialSetting.column_MailSendCode2].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_MailAddrKindCode2].Text.Trim() == "")
                        {
                            errMsg = "ﾒｰﾙ種別2を選択してください。";
                            cells[GridInitialSetting.column_MailAddrKindCode2].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        // ADD 2009/04/07 ------>>>
                        if (cells[GridInitialSetting.column_ReceiptOutputCode].Text.Trim() == "")
                        {
                            errMsg = "領収書出力を選択してください。";
                            cells[GridInitialSetting.column_ReceiptOutputCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        // ADD 2009/04/07 ------<<<
                        if (cells[GridInitialSetting.column_BillOutputCode].Text.Trim() == "")  // TODO:使用しない…請求書出力区分コード
                        {
                            errMsg = "請求書出力を選択してください。";
                            cells[GridInitialSetting.column_BillOutputCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }

                        // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
                        if (cells[GridInitialSetting.column_SalesSlipPrtDiv].Text.Trim() == "")
                        {
                            errMsg = "納品書出力を選択してください。";
                            cells[GridInitialSetting.column_SalesSlipPrtDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_AcpOdrrSlipPrtDiv].Text.Trim() == "")
                        {
                            errMsg = "受注伝票出力を選択してください。";
                            cells[GridInitialSetting.column_AcpOdrrSlipPrtDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_ShipmSlipPrtDiv].Text.Trim() == "")
                        {
                            errMsg = "貸出伝票出力を選択してください。";
                            cells[GridInitialSetting.column_ShipmSlipPrtDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }                
                        if (cells[GridInitialSetting.column_EstimatePrtDiv].Text.Trim() == "")
                        {
                            errMsg = "見積伝票出力を選択してください。";
                            cells[GridInitialSetting.column_EstimatePrtDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        } 
                        if (cells[GridInitialSetting.column_UOESlipPrtDiv].Text.Trim() == "")
                        {
                            errMsg = "UOE伝票出力を選択してください。";
                            cells[GridInitialSetting.column_UOESlipPrtDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        } 
                        // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

                        // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
                        if (cells[GridInitialSetting.column_TotalBillOutputDiv].Text.Trim() == "")
                        {
                            errMsg = "合計請求書出力を選択してください。";
                            cells[GridInitialSetting.column_TotalBillOutputDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_DetailBillOutputCode].Text.Trim() == "")
                        {
                            errMsg = "明細請求書出力を選択してください。";
                            cells[GridInitialSetting.column_DetailBillOutputCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_SlipTtlBillOutputDiv].Text.Trim() == "")
                        {
                            errMsg = "伝票合計請求書出力を選択してください。";
                            cells[GridInitialSetting.column_SlipTtlBillOutputDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

                        if (cells[GridInitialSetting.column_DmOutCode].Text.Trim() == "")
                        {
//                            errMsg = "DM出力を選択してください。"; // DEL 2022/03/04 田村顕成 電子帳簿連携対応
                            errMsg = "電子帳簿出力を選択してください。"; // ADD 2022/03/04 田村顕成 電子帳簿連携対応
                            cells[GridInitialSetting.column_DmOutCode].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CustSlipNoMngCd].Text.Trim() == "")
                        {
                            errMsg = "相手伝番管理を選択してください。";
                            cells[GridInitialSetting.column_CustSlipNoMngCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_CustomerSlipNoDiv].Text.Trim() == "")
                        {
                            errMsg = "伝番区分を選択してください。";
                            cells[GridInitialSetting.column_CustomerSlipNoDiv].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        if (cells[GridInitialSetting.column_QrcodePrtCd].Text.Trim() == "")
                        {
                            errMsg = "QRｺｰﾄﾞ印刷を選択してください。";
                            cells[GridInitialSetting.column_QrcodePrtCd].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 請求先コードチェック処理
        /// </summary>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <param name="msgFlg">メッセージ表示フラグ</param>
        /// <returns>ステータス(True:入力可　False:入力不可)</returns>
        /// <remarks>
        /// <br>Note        : 請求先コードを入力できるかどうかチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private bool CheckClaimCode(int claimCode, int rowIndex, out bool msgFlg)
        {
            // 得意先コード取得
            int customerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerCode].Value);

            if (customerCode == claimCode)
            {
                msgFlg = true;
                return (true);
            }
            else
            {
                // 得意先略称取得
                string claimSnm = GetCustomerSnm(claimCode);

                if (claimSnm == "")
                {
                    msgFlg = false;
                    return (false);
                }
                else
                {
                    // 得意先一括修正結果クラス取得
                    CustomerCustomerChangeResult result = GetCustomerCustomerChangeResult(claimCode);

                    if (result.CustomerCode == result.ClaimCode)
                    {
                        msgFlg = true;
                        return (true);
                    }
                    else
                    {
                        msgFlg = true;
                        return (false);
                    }
                }
            }
        }

        /// <summary>
        /// 売上金額端数処理存在チェック
        /// </summary>
        /// <param name="fracProcMoneyDiv">売上金額端数処理区分(0:金額  1:税  2:単価)</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 売上金額端数処理コードが存在するかどうかします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private bool ExistsSalesProcMoney(int fracProcMoneyDiv, int fractionProcCode)
        {
            return this._salesProcMoneyKeyList.Contains(new SalesProcMoneyKey(fracProcMoneyDiv, fractionProcCode));
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:処理続行　False:処理中断)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        public bool CompareScreen()
        {
            // 画面情報比較
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            int status = Save();
                            if (status != 0)
                            {
                                this.uGrid_Details.ActiveCell = this._activeCell;
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this.uGrid_Details.ActiveCell = this._activeCell;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            if ((this._searchListDic == null) || (this._searchListDic.Count == 0))
            {
                return (true);
            }

            if (this._closeFlg)
            {
                return (true);
            }

            ArrayList retList;

            // 画面情報取得
            ScreenToCustomerCustomerChangeResult(out retList);

            if (retList.Count != this._searchListDic.Count)
            {
                return (false);
            }

            CustomerCustomerChangeResult result;
            CustomerCustomerChangeResult result2;

            for (int index = 0; index < retList.Count; index++)
            {
                result = (CustomerCustomerChangeResult)retList[index];
                result2 = (CustomerCustomerChangeResult)this._searchListDic[result.CustomerCode];

                if (!(result.Equals(result2)))
                {
                    return (false);
                }
            }
            return (true);
        }

        /// <summary>
        /// 得意先種別チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>ステータス(True:得意先  False:納入先)</returns>
        /// <remarks>
        /// <br>Note        : 得意先種別をチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private bool CheckAcceptWholeSale(int customerCode)
        {
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                // 納入先
                if (this._customerSearchRetDic[customerCode].AcceptWholeSale == 2)
                {
                    return (false);
                }
                else
                {
                    return (true);
                }
            }

            return (true);
        }

        #endregion チェック処理

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void SetExtrInfo(out CustomerCustomerChangeParam extrInfo)
        {
            extrInfo = new CustomerCustomerChangeParam();
            
            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 得意先コード(開始)
            if (this.tNedit_CustomerCode_St.GetInt() == 0)
            {
                extrInfo.StCustomerCode = 1;
            }
            else
            {
                extrInfo.StCustomerCode = this.tNedit_CustomerCode_St.GetInt();
            }
            // 得意先コード(終了)
            if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
            {
                extrInfo.EdCustomerCode = 99999999;
            }
            else
            {
                extrInfo.EdCustomerCode = this.tNedit_CustomerCode_Ed.GetInt();
            }
        }

        #region セル値変更
        /// <summary>
        /// 得意先種別変更時処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="rowIndex">対象行</param>
        /// <remarks>
        /// <br>Note        : 得意先種別の値によってセルの入力制御等を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ChangeAcceptWholeSale(ref UltraGrid uGrid, int rowIndex)
        {
            CellsCollection cells = uGrid.Rows[rowIndex].Cells;

            // 得意先コード取得
            int customerCode = StrObjToInt(cells[GridInitialSetting.column_CustomerCode].Value);

            // 得意先種別取得
            int acceptWholeSale = IntObjToInt(cells[GridInitialSetting.column_AcceptWholeSale].Value);
            switch (acceptWholeSale)
            {
                // 得意先
                case 1:
                    {
                        // 2010/07/14 Del >>>
                        //this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        //this._cellUpdateFlg = false;
                        // 2010/07/14 Del <<<

                        // 前回値に戻します

                        CustomerCustomerChangeResult result;
                        if (this._prevCustomerCustomerChangetResultDic.ContainsKey(customerCode))
                        {
                            result = this._prevCustomerCustomerChangetResultDic[customerCode].Clone();
                            result.AcceptWholeSale = 1;
                            result.Name = StrObjToString(cells[GridInitialSetting.column_CustomerName].Value);
                            result.Name2 = StrObjToString(cells[GridInitialSetting.column_CustomerName2].Value);
                            result.PostNo = StrObjToString(cells[GridInitialSetting.column_PostNo].Value);
                            result.Address1 = StrObjToString(cells[GridInitialSetting.column_Address1].Value);
                            result.Address3 = StrObjToString(cells[GridInitialSetting.column_Address3].Value);
                            result.Address4 = StrObjToString(cells[GridInitialSetting.column_Address4].Value);
                            result.OfficeTelNo = StrObjToString(cells[GridInitialSetting.column_OfficeTelNo].Value);
                            result.OfficeFaxNo = StrObjToString(cells[GridInitialSetting.column_OfficeFaxNo].Value);
                            CustomerCustomerChangeResultToScreen(result, rowIndex);
                        }
                        else
                        {
                            result = new CustomerCustomerChangeResult();
                            // 初期表示設定
                            this._gridInitialSetting.SetInitialDisp(ref cells, GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode));
                        }

                        for (int index = 0; index < cells.Count; index++)
                        {
                            switch (cells[index].Column.Key)
                            {
                                case GridInitialSetting.column_No:
                                case GridInitialSetting.column_CustomerCode:
                                case GridInitialSetting.column_CustomerName:
                                case GridInitialSetting.column_CustomerName2:
                                case GridInitialSetting.column_AcceptWholeSale:
                                case GridInitialSetting.column_CreditMoney:     // ADD 2009/04/13
                                case GridInitialSetting.column_WarningCreditMoney:
                                case GridInitialSetting.column_PostNo:
                                case GridInitialSetting.column_Address1:
                                case GridInitialSetting.column_Address3:
                                case GridInitialSetting.column_Address4:
                                case GridInitialSetting.column_OfficeTelNo:
                                case GridInitialSetting.column_OfficeFaxNo:
                                    {
                                        continue;

                                    }
                                default:
                                    {
                                        cells[index].Activation = Activation.AllowEdit;
                                        break;
                                    }
                            }
                        }

                        // 2010/07/14 Del >>>
                        //// 管理拠点
                        //cells[GridInitialSetting.column_MngSectionName].Value = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
                        //cells[GridInitialSetting.column_MngSectionName].Tag = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

                        //// 得意先担当
                        //cells[GridInitialSetting.column_CustomerAgentName].Value = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode, false);
                        //cells[GridInitialSetting.column_CustomerAgentName].Tag = LoginInfoAcquisition.Employee.EmployeeCode.Trim();

                        //// 請求拠点
                        //cells[GridInitialSetting.column_ClaimSectionSnm].Value = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
                        //cells[GridInitialSetting.column_ClaimSectionSnm].Tag = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

                        //// 請求先
                        //if (result.CustomerSnm.Trim() == "")
                        //{
                        //    cells[GridInitialSetting.column_ClaimSnm].Value = customerCode.ToString("00000000");
                        //    cells[GridInitialSetting.column_ClaimSnm].Tag = customerCode;
                        //}

                        //if (IntObjToInt(cells[GridInitialSetting.column_CustCTaXLayRefCd].Value) == 0)
                        //{
                        //    // 消費税転嫁方式(税率設定マスタ参照)
                        //    cells[GridInitialSetting.column_ConsTaxLayMethod].Value = this._taxRateSet.ConsTaxLayMethod;
                        //    cells[GridInitialSetting.column_ConsTaxLayMethod].Activation = Activation.Disabled;
                        //}

                        //// 締日
                        //cells[GridInitialSetting.column_TotalDay].Value = this._allDefSet.DefDspCustTtlDay;
                        //// 集金日
                        //cells[GridInitialSetting.column_CollectMoneyDay].Value = this._allDefSet.DefDspCustClctMnyDay;

                        //this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        //this._cellUpdateFlg = true;
                        // 2010/07/14 Del <<<

                        // 2010/07/14 Add 元が納入先の場合はログイン担当者をセットする >>>
                        if (_searchListDic[result.CustomerCode].AcceptWholeSale == 2)
                        {
                            // 得意先担当
                            cells[GridInitialSetting.column_CustomerAgentName].Value = GetEmployeeName(LoginInfoAcquisition.Employee.EmployeeCode, false);
                            cells[GridInitialSetting.column_CustomerAgentName].Tag = LoginInfoAcquisition.Employee.EmployeeCode.Trim();

                            // 回収条件

                        }
                        // 2010/07/14 Add <<<

                        break;
                    }
                // 納入先
                case 2:
                    {
                        CustomerCustomerChangeResult result;
                        if (this._prevCustomerCustomerChangetResultDic.ContainsKey(customerCode))
                        {
                            result = this._prevCustomerCustomerChangetResultDic[customerCode].Clone();
                        }
                        else
                        {
                            result = new CustomerCustomerChangeResult();
                        }

                        // 画面情報取得
                        ScreenToCustomerCustomerChangeResult(ref result, rowIndex, false);

                        if (this._prevCustomerCustomerChangetResultDic.ContainsKey(customerCode))
                        {
                            this._prevCustomerCustomerChangetResultDic[customerCode] = result.Clone();
                        }
                        else
                        {
                            this._prevCustomerCustomerChangetResultDic.Add(customerCode, result.Clone());
                        }

                        // 2010/07/14 Del >>>
                        //this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        //this._cellUpdateFlg = false;
                        // 2010/07/14 Del <<<

                        for (int index = 0; index < cells.Count; index++)
                        {
                            switch (cells[index].Column.Key)
                            {
                                case GridInitialSetting.column_No:
                                case GridInitialSetting.column_CustomerCode:
                                case GridInitialSetting.column_CustomerName:
                                case GridInitialSetting.column_CustomerName2:
                                case GridInitialSetting.column_AcceptWholeSale:
                                case GridInitialSetting.column_PostNo:
                                case GridInitialSetting.column_PostNoGuide:
                                case GridInitialSetting.column_Address1:
                                case GridInitialSetting.column_Address3:
                                case GridInitialSetting.column_Address4:
                                case GridInitialSetting.column_OfficeTelNo:
                                case GridInitialSetting.column_OfficeFaxNo:
                                    {
                                        continue;
                                        
                                    }
                                default:
                                    {
                                        cells[index].Value = DBNull.Value;
                                        cells[index].Activation = Activation.Disabled;
                                        break;
                                    }
                            }
                        }

                        // 2010/07/14 Del >>>
                        //this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        //this._cellUpdateFlg = true;
                        // 2010/07/14 Del <<<

                        break;
                    }
            }
        }

        /// <summary>
        /// 請求先コード変更時処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="rowIndex">対象行</param>
        /// <remarks>
        /// <br>Note        : 請求先コードの値によってセルの入力制御等を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ChangeClaimCode(ref UltraGrid uGrid, int rowIndex)
        {
            int customerCode = StrObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerCode].Value);
            int claimCode = (int)uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSnm].Tag;

            //------------------------------------------------
            // 入力制御
            //------------------------------------------------
            if (customerCode == claimCode)
            {
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_TotalDay].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyName].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyDay].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectCond].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectSight].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_NTimeCalcStDate].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustCTaXLayRefCd].Activation = Activation.AllowEdit;
                if (IntObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustCTaXLayRefCd].Value) == 1)
                {
                    uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Activation = Activation.AllowEdit;
                }
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_DepoDelCode].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesUnPrcFrcProcGuide].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesMoneyFrcProcGuide].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Activation = Activation.AllowEdit;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcGuide].Activation = Activation.AllowEdit;
            }
            else
            {
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_TotalDay].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyName].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyDay].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectCond].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectSight].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_NTimeCalcStDate].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustCTaXLayRefCd].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_DepoDelCode].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesUnPrcFrcProcGuide].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesMoneyFrcProcGuide].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Activation = Activation.Disabled;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcGuide].Activation = Activation.Disabled;
            }

            //------------------------------------------------
            // 値設定
            //------------------------------------------------
            if (claimCode == customerCode)
            {
                // 締日
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_TotalDay].Value = this._allDefSet.DefDspCustTtlDay;
                // 集金日
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyDay].Value = this._allDefSet.DefDspCustClctMnyDay;
            }
            else
            {
                CustomerCustomerChangeResult result = GetCustomerCustomerChangeResult(claimCode);

                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_TotalDay].Value = result.TotalDay;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyName].Value = result.CollectMoneyCode;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectMoneyDay].Value = result.CollectMoneyDay;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectCond].Value = result.CollectCond;
                if (result.CollectSight != 0)
                {
                    uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectSight].Value = result.CollectSight;
                }
                else
                {
                    uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CollectSight].Value = DBNull.Value;
                }
                if (result.NTimeCalcStDate != 0)
                {
                    uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_NTimeCalcStDate].Value = result.NTimeCalcStDate;
                }
                else
                {
                    uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_NTimeCalcStDate].Value = DBNull.Value;
                }
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustCTaXLayRefCd].Value = result.CustCTaXLayRefCd;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Value = result.ConsTaxLayMethod;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_DepoDelCode].Value = result.DepoDelCode;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value = result.SalesUnPrcFrcProcCd;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value = result.SalesMoneyFrcProcCd;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value = result.SalesCnsTaxFrcProcCd;
            }
        }

        /// <summary>
        /// 転嫁方式参照変更時処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="rowIndex">対象行</param>
        /// <remarks>
        /// <br>Note        : 転嫁方式参照の値によってセルの入力制御等を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ChangeCustCTaXLayRefCd(ref UltraGrid uGrid, int rowIndex)
        {
            // 転嫁方式参照
            int custCTaxLayRefCd = IntObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustCTaXLayRefCd].Value);

            if (custCTaxLayRefCd == 0)
            {
                // 税率設定参照
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Value = this._taxRateSet.ConsTaxLayMethod;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Activation = Activation.Disabled;
            }
            else
            {
                // 得意先参照
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Activation = Activation.AllowEdit;
            }
        }

        /// <summary>
        /// 与信管理変更時処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="rowIndex">対象行</param>
        /// <remarks>
        /// <br>Note        : 与信管理の値によってセルの入力制御等を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ChangeCreditMngCode(ref UltraGrid uGrid, int rowIndex)
        {
            // 与信管理
            int creditMngCode = IntObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CreditMngCode].Value);
            // 得意先コード
            int customerCode = StrObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerCode].Value);

            if (creditMngCode == 0)
            {
                // しない
                // ADD 2009/04/13 ------>>>
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CreditMoney].Value = DBNull.Value;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CreditMoney].Activation = Activation.Disabled;
                // ADD 2009/04/13 ------<<<
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_WarningCreditMoney].Value = DBNull.Value;
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_WarningCreditMoney].Activation = Activation.Disabled;
            }
            else
            {
                // する
                long creditMoney = 0;   // ADD 2009/04/13
                long warningCreditMoney = 0;
                CustomerChange customerChange;
                int status = GetCustomerChange(out customerChange, customerCode);
                if (status == 0)
                {
                    creditMoney = customerChange.CreditMoney;   // ADD 2009/04/13
                    warningCreditMoney = customerChange.WarningCreditMoney;
                }
                // ADD 2009/04/13 ------>>>
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CreditMoney].Value = creditMoney.ToString("###,##0");
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CreditMoney].Activation = Activation.AllowEdit;
                // ADD 2009/04/13 ------<<<
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_WarningCreditMoney].Value = warningCreditMoney.ToString("###,##0");
                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_WarningCreditMoney].Activation = Activation.AllowEdit;
            }
        }

        /// <summary>
        /// 主連絡先値変更時処理
        /// </summary>
        /// <param name="uGrid">対象グリッド</param>
        /// <param name="rowIndex">対象行</param>
        /// <param name="mainContactCode">主連絡先コード</param>
        /// <remarks>
        /// <br>Note        : 主連絡先値の値によってセルの入力制御等を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void ChangeMainContactValue(ref UltraGrid uGrid, int rowIndex, int mainContactCode)
        {
            string targetValue = "";

            switch (mainContactCode)
            {
                case 0:
                    {
                        targetValue = StrObjToString(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_HomeTelNo].Value);
                        break;
                    }
                case 1:
                    {
                        targetValue = StrObjToString(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_HomeFaxNo].Value);
                        break;
                    }
                case 2:
                    {
                        targetValue = StrObjToString(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_OfficeTelNo].Value);
                        break;
                    }
                case 3:
                    {
                        targetValue = StrObjToString(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_PortableTelNo].Value);
                        break;
                    }
                case 4:
                    {
                        targetValue = StrObjToString(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_OfficeFaxNo].Value);
                        break;
                    }
                case 5:
                    {
                        targetValue = StrObjToString(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_OthersTelNo].Value);
                        break;
                    }
            }

            // 検索電話番号設定
            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SearchTelNo].Value = CreateSearchTelNo(targetValue);
        }
        #endregion セル値変更

        #region ガイド表示
        /// <summary>
        /// 拠点ガイド表示処理
        /// </summary>
        /// <param name="secInfoSet">拠点マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 拠点ガイドを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int ShowSectionGuide(out SecInfoSet secInfoSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            secInfoSet = new SecInfoSet();

            try
            {
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 従業員ガイド表示処理
        /// </summary>
        /// <param name="employee">従業員マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 従業員ガイドを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int ShowEmployeeGuide(out Employee employee)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            employee = new Employee();

            try
            {
                status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 倉庫ガイド表示処理
        /// </summary>
        /// <param name="warehouse">倉庫マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 倉庫ガイドを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int ShowWarehouseGuide(out Warehouse warehouse)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            warehouse = new Warehouse();

            try
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 得意先ガイド表示処理
        /// </summary>
        /// <param name="customerSearchRet">得意先マスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 得意先ガイドを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int ShowCustomerGuide(out CustomerSearchRet customerSearchRet, int searchMode)
        {
            customerSearchRet = new CustomerSearchRet();

            this._cusotmerGuideSelected = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._cusotmerGuideSelected == true)
            {
                customerSearchRet = this._customerSearchRet;
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドで得意先を選択した時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 選択した得意先マスタをバッファに保持
            this._customerSearchRet = customerSearchRet.Clone();

            this._cusotmerGuideSelected = true;
        }
        
        /// <summary>
        /// 売上金額端数処理ガイド表示処理
        /// </summary>
        /// <param name="salesProcMoney">売上金額端数処理クラス</param>
        /// <param name="fracProcMoneyDiv">売上金額端数処理区分(0:金額端数 1:税端数 2:単価端数)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 売上金額端数処理ガイドを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int ShowSalesProcMoneyGuide(out SalesProcMoney salesProcMoney, int fracProcMoneyDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            salesProcMoney = new SalesProcMoney();

            try
            {
                status = this._salesProcMoneyAcs.ExecuteGuid(this._enterpriseCode, fracProcMoneyDiv, out salesProcMoney);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }


        /// <summary>
        /// 郵便番号ガイド表示処理
        /// </summary>
        /// <param name="agResult">郵便番号結果データ</param>
        /// <param name="postNo">郵便番号</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 郵便番号ガイドを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int ShowAddressGuide(out AddressGuideResult agResult, string postNo)
        {
            DialogResult result;

            agResult = new AddressGuideResult();

            try
            {
                result = this._addressGuide.ShowPostNoSearchGuide(postNo, out agResult);
                if ((result == DialogResult.OK) || (result == DialogResult.Yes))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        #endregion ガイド表示

        /// <summary>
        /// 住所名称分割処理
        /// </summary>
        /// <param name="length">分割文字数</param>
        /// <param name="addressName">住所名称</param>
        /// <param name="addressName1">住所名称分割結果１</param>
        /// <param name="addressName2">住所名称分割結果２</param>
        /// <remarks>
        /// <br>Note        : 住所名称を分割します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void DivisionAddressName(int length, string addressName, out string addressName1, out string addressName2)
        {
            addressName1 = addressName;
            addressName2 = string.Empty;

            if (addressName.Length > length)
            {
                addressName1 = addressName.Substring(0, length);
                addressName2 = addressName.Substring(length, addressName.Length - length);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 検索電話番号作成処理
        /// </summary>
        /// <param name="telNo">得意先情報クラス</param>
        /// <returns>検索電話番号</returns>
        /// <remarks>
        /// <br>Note        : 検索電話番号を作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        public string CreateSearchTelNo(string telNo)
        {
            if ((telNo == null) || (telNo == "")) return string.Empty;

            StringBuilder telNoBuff = new StringBuilder();

            for (int i = telNo.Length; i > 0; i--)
            {
                string no = telNo.Substring(i - 1, 1);

                // 数値以外の場合は処理終了
                Regex regex = new Regex(@"^[0-9]+$");
                if (!regex.IsMatch(no))
                {
                    break;
                }

                telNoBuff.Insert(0, no);

                // 4文字になった時点で処理終了
                if (telNoBuff.Length == 4)
                {
                    break;
                }
            }

            return telNoBuff.ToString();
        }

        #region タブ移動
        /// <summary>
        /// グリッドタブ移動制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドにフォーカスがある場合のタブ移動を制御します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                e.NextCtrl = null;
                this.uGrid_Details.Focus();
                if (this.uGrid_Details.ActiveRow == null)
                {
                    this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                }
                else
                {
                    if (this.uGrid_Details.ActiveRow.Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                    {
                        this.uGrid_Details.Rows[uGrid_Details.ActiveRow.Index].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                    }
                    else
                    {
                        this.uGrid_Details.Rows[uGrid_Details.ActiveRow.Index].Cells[GridInitialSetting.column_CustomerName].Activate();
                    }
                }
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            e.NextCtrl = null;

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            // セル移動：右
            if (this._cellMove == 0)
            {
                if ((rowIndex == this.uGrid_Details.Rows.Count - 1) &&
                    (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_QrcodePrtCd].Activation == Activation.AllowEdit) &&
                    (columnKey == GridInitialSetting.column_QrcodePrtCd))
                {
                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                }
                else if ((rowIndex == this.uGrid_Details.Rows.Count - 1) &&
                         (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_QrcodePrtCd].Activation != Activation.AllowEdit) &&
                         (columnKey == GridInitialSetting.column_OfficeFaxNo))
                {
                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                }
                else
                {
                    this.uGrid_Details.Focus();

                    // 次セル取得
                    string nextFocusColumn = GetNextFocusColumnKey(columnKey, rowIndex, false);
                    if (nextFocusColumn == "")
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[nextFocusColumn].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            // セル移動：下
            else
            {
                if ((rowIndex == this.uGrid_Details.Rows.Count - 1) &&
                    (columnKey == GridInitialSetting.column_QrcodePrtCd))
                {
                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                }
                else
                {
                    this.uGrid_Details.Focus();

                    for (int targetRowIndex = rowIndex + 1; targetRowIndex < this.uGrid_Details.Rows.Count; targetRowIndex++)
                    {
                        if (this.uGrid_Details.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.Rows[targetRowIndex].Cells[columnIndex].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    for (int index = columnIndex + 1; index < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; index++)
                    {
                        for (int targetRowIndex = 0; targetRowIndex < this.uGrid_Details.Rows.Count; targetRowIndex++)
                        {
                            if (this.uGrid_Details.Rows[targetRowIndex].Cells[index].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[targetRowIndex].Cells[index].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }

                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                }
            }
        }

        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドにフォーカスがある場合のシフトタブ移動を制御します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                e.NextCtrl = null;
                this.uGrid_Details.Focus();
                if (this.uGrid_Details.ActiveRow == null)
                {
                    this.uGrid_Details.Rows[uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_QrcodePrtCd].Activate();
                }
                else
                {
                    if (this.uGrid_Details.ActiveRow.Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                    {
                        this.uGrid_Details.Rows[uGrid_Details.ActiveRow.Index].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                    }
                    else
                    {
                        this.uGrid_Details.Rows[uGrid_Details.ActiveRow.Index].Cells[GridInitialSetting.column_CustomerName].Activate();
                    }
                }
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            e.NextCtrl = null;

            // セル移動：右
            if (this._cellMove == 0)
            {
                if ((rowIndex == 0) &&
                    (columnKey == GridInitialSetting.column_CustomerSubCode))
                {
                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else
                    {
                        e.NextCtrl = this.CustomerGuideEd_Button;
                    }
                }
                else if ((rowIndex == 0) &&
                         (columnKey == GridInitialSetting.column_CustomerName) &&
                         (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerSubCode].Activation != Activation.AllowEdit))
                {
                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else
                    {
                        e.NextCtrl = this.CustomerGuideEd_Button;
                    }
                }
                else
                {
                    this.uGrid_Details.Focus();

                    // 次セル取得
                    string nextFocusColumn = GetNextFocusColumnKey(columnKey, rowIndex, true);
                    if (nextFocusColumn == "")
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[nextFocusColumn].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            // セル移動：下
            else
            {
                if ((rowIndex == 0) &&
                    (columnKey == GridInitialSetting.column_CustomerSubCode))
                {
                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else
                    {
                        e.NextCtrl = this.CustomerGuideEd_Button;
                    }
                }
                else if ((rowIndex == 0) &&
                         (columnKey == GridInitialSetting.column_CustomerName) &&
                         (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerSubCode].Activation != Activation.AllowEdit))
                {
                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else
                    {
                        e.NextCtrl = this.CustomerGuideEd_Button;
                    }
                }
                else
                {
                    this.uGrid_Details.Focus();

                    for (int targetRowIndex = rowIndex -1; targetRowIndex >= 0; targetRowIndex--)
                    {
                        if (this.uGrid_Details.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.Rows[targetRowIndex].Cells[columnIndex].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    for (int index = columnIndex - 1; index > 0; index--)
                    {
                        for (int targetRowIndex = this.uGrid_Details.Rows.Count - 1; targetRowIndex >= 0; targetRowIndex--)
                        {
                            if (this.uGrid_Details.Rows[targetRowIndex].Cells[index].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[targetRowIndex].Cells[index].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }

                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else
                    {
                        e.NextCtrl = this.CustomerGuideEd_Button;
                    }
                }
            }
        }

        /// <summary>
        /// 次セル取得処理
        /// </summary>
        /// <param name="prevColumnKey">現在カラムキー</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="shiftFlg">シフトタブフラグ</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private string GetNextFocusColumnKey(string prevColumnKey, int rowIndex, bool shiftFlg)
        {
            string nextColumnKey;

            if (shiftFlg == false)
            {
                switch (prevColumnKey)
                {
                    // 管理拠点
                    case GridInitialSetting.column_MngSectionName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_CustomerAgentName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 得意先担当
                    case GridInitialSetting.column_CustomerAgentName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_OldCustomerAgentName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 旧担当
                    case GridInitialSetting.column_OldCustomerAgentName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_CustAgentChgDate;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 優先倉庫
                    case GridInitialSetting.column_CustWarehouseName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_BusinessTypeName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 請求拠点
                    case GridInitialSetting.column_ClaimSectionSnm:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_ClaimSnm;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 請求先コード
                    case GridInitialSetting.column_ClaimSnm:
                        {
                            if (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_TotalDay].Activation == Activation.AllowEdit)
                            {
                                nextColumnKey = GridInitialSetting.column_TotalDay;
                            }
                            else
                            {
                                nextColumnKey = GridInitialSetting.column_BillCollecterName;
                            }
                            break;
                        }
                    // 集金担当
                    case GridInitialSetting.column_BillCollecterName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                if (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_CustCTaXLayRefCd].Activation == Activation.AllowEdit)
                                {
                                    nextColumnKey = GridInitialSetting.column_CustCTaXLayRefCd;
                                }
                                else
                                {
                                    nextColumnKey = GridInitialSetting.column_CreditMngCode;
                                }
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 単価端数
                    case GridInitialSetting.column_SalesUnPrcFrcProcCd:
                        {
                            nextColumnKey = GridInitialSetting.column_SalesMoneyFrcProcCd;
                            break;
                        }
                    // 金額端数
                    case GridInitialSetting.column_SalesMoneyFrcProcCd:
                        {
                            nextColumnKey = GridInitialSetting.column_SalesCnsTaxFrcProcCd;
                            break;
                        }
                    // 税端数
                    case GridInitialSetting.column_SalesCnsTaxFrcProcCd:
                        {
                            nextColumnKey = GridInitialSetting.column_PostNo;
                            break;
                        }
                    // 郵便番号
                    case GridInitialSetting.column_PostNo:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[prevColumnKey].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_Address1;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    default:
                        {
                            nextColumnKey = "";
                            break;
                        }
                }
            }
            else
            {
                switch (prevColumnKey)
                {
                    // 得意先担当
                    case GridInitialSetting.column_CustomerAgentName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_MngSectionName].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_MngSectionName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 旧担当
                    case GridInitialSetting.column_OldCustomerAgentName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerAgentName].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_CustomerAgentName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 担当者変更日
                    case GridInitialSetting.column_CustAgentChgDate:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_OldCustomerAgentName].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_OldCustomerAgentName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 業種
                    case GridInitialSetting.column_BusinessTypeName:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_CustWarehouseName].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_CustWarehouseName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 請求先コード
                    case GridInitialSetting.column_ClaimSnm:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSectionSnm].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_ClaimSectionSnm;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 集金担当
                    case GridInitialSetting.column_BillCollecterName:
                        {
                            if (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_NTimeCalcStDate].Activation != Activation.AllowEdit)
                            {
                                nextColumnKey = GridInitialSetting.column_ClaimSnm;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 締日
                    case GridInitialSetting.column_TotalDay:
                        {
                            nextColumnKey = GridInitialSetting.column_ClaimSnm;
                            break;
                        }
                    // 転嫁方式参照
                    case GridInitialSetting.column_CustCTaXLayRefCd:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_BillCollecterName].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_BillCollecterName;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 与信管理
                    case GridInitialSetting.column_CreditMngCode:
                        {
                            if (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_ConsTaxLayMethod].Activation != Activation.AllowEdit)
                            {
                                if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_BillCollecterName].Value) != "")
                                {
                                    nextColumnKey = GridInitialSetting.column_BillCollecterName;
                                }
                                else
                                {
                                    nextColumnKey = "";
                                }
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    // 金額端数
                    case GridInitialSetting.column_SalesMoneyFrcProcCd:
                        {
                            nextColumnKey = GridInitialSetting.column_SalesUnPrcFrcProcCd;
                            break;
                        }
                    // 税端数
                    case GridInitialSetting.column_SalesCnsTaxFrcProcCd:
                        {
                            nextColumnKey = GridInitialSetting.column_SalesMoneyFrcProcCd;
                            break;
                        }
                    // 郵便番号
                    case GridInitialSetting.column_PostNo:
                        {
                            if (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Activation == Activation.AllowEdit)
                            {
                                nextColumnKey = GridInitialSetting.column_SalesCnsTaxFrcProcCd;
                            }
                            else if (this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_AccRecDivCd].Activation == Activation.AllowEdit)
                            {
                                nextColumnKey = GridInitialSetting.column_AccRecDivCd;
                            }
                            else
                            {
                                nextColumnKey = GridInitialSetting.column_AcceptWholeSale;
                            }
                            break;
                        }
                    // 住所1
                    case GridInitialSetting.column_Address1:
                        {
                            if (StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[GridInitialSetting.column_PostNo].Value) != "")
                            {
                                nextColumnKey = GridInitialSetting.column_PostNo;
                            }
                            else
                            {
                                nextColumnKey = "";
                            }
                            break;
                        }
                    default:
                        {
                            nextColumnKey = "";
                            break;
                        }
                }
            }

            return nextColumnKey;
        }

        #endregion タブ移動

        #region セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
            {
                return 0;
            }

            return int.Parse((string)cellValue);
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をLong型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private long StrObjToLong(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
            {
                return 0;
            }

            double dblValue = double.Parse((string)cellValue);
            return (long)dblValue;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private string StrObjToString(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return "";
            }

            return (string)cellValue;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return 0;
            }

            return (int)cellValue;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をDateTime型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private DateTime DateTimeObjToDateTime(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return new DateTime();
            }

            return (DateTime)cellValue;
        }
        #endregion セル値変換

        #region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._customerCustomerChangeAcs,	// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void PMKHN09351UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;

            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…列サイズの自動調整を削除 ---------->>>>>
            this.uCheckEditor_AutoFillToColumn.Visible = false;
            this.uCheckEditor_AutoFillToColumn.Checked = false;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…列サイズの自動調整を削除 ----------<<<<<
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        this._closeFlg = true;

                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        Save();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // 検索処理
                        Search();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // クリア処理
                        ClearScreen();
                        break;
                    }
                case "ButtonTool_SetUp":
                    {
                        // 設定処理
                        SetUp();
                        break;
                    }
                case "ButtonTool_Renewal":
                    {
                        ReadSecInfoSet();
                        ReadEmployee();
                        ReadWarehouse();
                        ReadCustomerSearchRet();
                        ReadAllDefSet();
                        ReadTaxRateSet();
                        ReadSalesProcMoney();
                        ReadCustomerChange();

                        this._gridInitialSetting = new GridInitialSetting();
                        this._gridInitialSetting.SetGridInitialLayout(ref this.uGrid_Details);

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "最新情報を取得しました。",
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        break;
                    }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                CustomerSearchRet customerSearchRet;

                int status = ShowCustomerGuide(out customerSearchRet, PMKHN04005UA.SEARCHMODE_NORMAL);
                if (status == 0)
                {
                    // フォーカス設定
                    if (uButton.Name == "CustomerGuideSt_Button")
                    {
                        // 開始
                        this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                        this.tNedit_CustomerCode_Ed.Focus();
                    }
                    else
                    {
                        // 終了
                        this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                        if (this.uGrid_Details.Rows.Count == 0)
                        {
                            this.uCheckEditor_AutoFillToColumn.Focus();
                        }
                        else
                        {
                            this.uGrid_Details.Focus();
                            if (this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                            }
                            else
                            {
                                this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerName].Activate();
                            }
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 25;

            if (this.Standard_UGroupBox.Expanded == true)
            {
                topSize.Height = 78;
            }
            else
            {
                topSize.Height = 25;
            }

            this.Form1_Top_Panel.Size = topSize;
        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルボタンをクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_ClickCellButton(object sender, CellEventArgs e)
        {
            int status;

            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            switch (e.Cell.Column.Key)
            {
                // 管理拠点ガイド
                case GridInitialSetting.column_MngSectionGuide:
                    {
                        SecInfoSet secInfoSet;

                        status = ShowSectionGuide(out secInfoSet);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_MngSectionName].Value = secInfoSet.SectionGuideNm.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_MngSectionName].Tag = secInfoSet.SectionCode.Trim();

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 得意先担当ガイド
                case GridInitialSetting.column_CustomerAgentGuide:
                    {
                        Employee employee;

                        status = ShowEmployeeGuide(out employee);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerAgentName].Value = employee.Name.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerAgentName].Tag = employee.EmployeeCode.Trim();

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 旧担当ガイド
                case GridInitialSetting.column_OldCustomerAgentGuide:
                    {
                        Employee employee;

                        status = ShowEmployeeGuide(out employee);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_OldCustomerAgentName].Value = employee.Name.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_OldCustomerAgentName].Tag = employee.EmployeeCode.Trim();

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 優先倉庫ガイド
                case GridInitialSetting.column_CustWarehouseGuide:
                    {
                        Warehouse warehouse;

                        status = ShowWarehouseGuide(out warehouse);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustWarehouseName].Value = warehouse.WarehouseName.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustWarehouseName].Tag = warehouse.WarehouseCode.Trim();

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 請求拠点ガイド
                case GridInitialSetting.column_ClaimSectionGuide:
                    {
                        SecInfoSet secInfoSet;

                        status = ShowSectionGuide(out secInfoSet);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSectionSnm].Value = secInfoSet.SectionGuideNm.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSectionSnm].Tag = secInfoSet.SectionCode.Trim();

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 請求先ガイド
                case GridInitialSetting.column_ClaimGuide:
                    {
                        CustomerSearchRet customerSearchRet;

                        status = ShowCustomerGuide(out customerSearchRet, PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY);
                        if (status == 0)
                        {
                            int customerCode = (int)uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSnm].Tag;
                            if (customerCode == customerSearchRet.CustomerCode)
                            {
                                // フォーカス設定
                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                return;
                            }

                            // 請求先チェック
                            bool msgFlg;
                            bool bStatus = CheckClaimCode(customerSearchRet.CustomerCode, rowIndex, out msgFlg);
                            if (bStatus)
                            {
                                if (msgFlg)
                                {
                                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                                      "請求先を変更しようとしています。" + "\r\n" + "\r\n" + "よろしいですか？",
                                                                      0,
                                                                      MessageBoxButtons.YesNo,
                                                                      MessageBoxDefaultButton.Button1);

                                    if (res == DialogResult.No)
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (msgFlg)
                                {
                                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                       "選択された得意先は請求先コードが異なるため、請求先として選択できません。",
                                                       0,
                                                       MessageBoxButtons.OK,
                                                       MessageBoxDefaultButton.Button1);
                                    return;
                                }
                            }

                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSnm].Value = customerSearchRet.Snm.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_ClaimSnm].Tag = customerSearchRet.CustomerCode;

                            // 請求先変更時処理
                            ChangeClaimCode(ref uGrid, rowIndex);

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 集金担当ガイド
                case GridInitialSetting.column_BillCollecterGuide:
                    {
                        Employee employee;

                        status = ShowEmployeeGuide(out employee);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_BillCollecterName].Value = employee.Name.Trim();
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_BillCollecterName].Tag = employee.EmployeeCode.Trim();

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 単価端数ガイド
                case GridInitialSetting.column_SalesUnPrcFrcProcGuide:
                    {
                        SalesProcMoney salesProcMoney;

                        status = ShowSalesProcMoneyGuide(out salesProcMoney, 2);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value = salesProcMoney.FractionProcCode;

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 金額端数ガイド
                case GridInitialSetting.column_SalesMoneyFrcProcGuide:
                    {
                        SalesProcMoney salesProcMoney;

                        status = ShowSalesProcMoneyGuide(out salesProcMoney, 0);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value = salesProcMoney.FractionProcCode;

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 税端数ガイド
                case GridInitialSetting.column_SalesCnsTaxFrcProcGuide:
                    {
                        SalesProcMoney salesProcMoney;

                        status = ShowSalesProcMoneyGuide(out salesProcMoney, 1);
                        if (status == 0)
                        {
                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value = salesProcMoney.FractionProcCode;

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
                // 郵便番号ガイド
                case GridInitialSetting.column_PostNoGuide:
                    {
                        AddressGuideResult agResult;

                        status = ShowAddressGuide(out agResult, "");
                        if (status == 0)
                        {
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_PostNo].Value = agResult.PostNo.Trim();

                            // 住所名称分割処理
                            string address1;
                            string address2;
                            DivisionAddressName(30, agResult.AddressName, out address1, out address2);

                            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = false;

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_Address1].Value = address1;
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_Address3].Value = address2;

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;

                            // フォーカス設定
                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        break;
                    }
            }

            if (uGrid.Rows[rowIndex].Cells[columnIndex - 1].Value.ToString().Trim() == this._searchTable.Rows[rowIndex][columnIndex - 1].ToString().Trim())
            {
                uGrid.Rows[rowIndex].Cells[columnIndex - 1].Appearance.BackColor = Color.Empty;
            }
            else
            {
                uGrid.Rows[rowIndex].Cells[columnIndex - 1].Appearance.BackColor = Color.Lime;
            }
        }

        /// <summary>
        /// CellChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルの値が変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            switch (e.Cell.Column.Key)
            {
                // 得意先種別
                case GridInitialSetting.column_AcceptWholeSale:
                // 転嫁方式参照
                case GridInitialSetting.column_CustCTaXLayRefCd:
                // 与信管理
                case GridInitialSetting.column_CreditMngCode:
                // 主連絡先
                case GridInitialSetting.column_MainContactCode:
                    {
                        if (this._keyDownFlg)
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// AfterCellUpdate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルの値が変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (!this._cellUpdateFlg)
            {
                return;
            }

            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;

            // 得意先コード
            int customerCode = StrObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerCode].Value);

            switch (e.Cell.Column.Key)
            {
                // 管理拠点
                // 請求拠点
                case GridInitialSetting.column_MngSectionName:
                case GridInitialSetting.column_ClaimSectionSnm:
                    {
                        string sectionCode = StrObjToString(e.Cell.Value);
                        sectionCode = sectionCode.PadLeft(2, '0');

                        int result;
                        if (!int.TryParse(sectionCode, out result))
                        {
                            sectionCode = StrObjToString((string)e.Cell.Tag);
                        }

                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        e.Cell.Value = GetSectionName(sectionCode);
                        e.Cell.Tag = sectionCode.PadLeft(2, '0');

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 得意先種別
                case GridInitialSetting.column_AcceptWholeSale:
                    {
                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        // 得意先種別変更時処理
                        ChangeAcceptWholeSale(ref uGrid, rowIndex);

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 得意先担当
                // 旧担当
                // 集金担当
                case GridInitialSetting.column_CustomerAgentName:
                case GridInitialSetting.column_OldCustomerAgentName:
                case GridInitialSetting.column_BillCollecterName:
                    {
                        string employeeCode = StrObjToString(e.Cell.Value);
                        employeeCode = employeeCode.PadLeft(4, '0');

                        int result;
                        if (!int.TryParse(employeeCode, out result))
                        {
                            employeeCode = StrObjToString((string)e.Cell.Tag);
                        }

                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        e.Cell.Value = GetEmployeeName(employeeCode, false);
                        e.Cell.Tag = employeeCode.PadLeft(4, '0');

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 優先倉庫
                case GridInitialSetting.column_CustWarehouseName:
                    {
                        string warehouseCode = StrObjToString(e.Cell.Value);
                        warehouseCode = warehouseCode.PadLeft(4, '0');

                        int result;
                        if (!int.TryParse(warehouseCode, out result))
                        {
                            warehouseCode = StrObjToString((string)e.Cell.Tag);
                        }

                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        e.Cell.Value = GetWarehouseName(warehouseCode);
                        if (warehouseCode == "")
                        {
                            e.Cell.Tag = "";
                        }
                        else
                        {
                            e.Cell.Tag = warehouseCode.PadLeft(4, '0');
                        }

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 請求先
                case GridInitialSetting.column_ClaimSnm:
                    {
                        int claimCode = StrObjToInt(e.Cell.Value);

                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        if (claimCode != customerCode)
                        {
                            // 納入先の場合
                            if (CheckAcceptWholeSale(claimCode) == false)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                               "選択された得意先は納入先の為、請求先として選択できません。",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // 前回値に戻します
                                e.Cell.Value = GetCustomerSnm((int)e.Cell.Tag);

                                this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                                this._cellUpdateFlg = true;
                                return;
                            }
                        }

                        string customerSnm = GetCustomerSnm(claimCode);
                        
                        if ((e.Cell.Tag != null) && (claimCode == (int)e.Cell.Tag))
                        {
                            if (claimCode != customerCode)
                            {
                                e.Cell.Value = customerSnm;
                            }
                            else
                            {
                                if (customerSnm != "")
                                {
                                    e.Cell.Value = customerSnm;
                                }
                            }

                            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                            this._cellUpdateFlg = true;
                            return;
                        }

                        // 請求先チェック
                        bool msgFlg;
                        bool bStatus = CheckClaimCode(claimCode, rowIndex, out msgFlg);
                        if (bStatus)
                        {
                            if (msgFlg)
                            {
                                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                                  "請求先を変更しようとしています。" + "\r\n" + "\r\n" + "よろしいですか？",
                                                                  0,
                                                                  MessageBoxButtons.YesNo,
                                                                  MessageBoxDefaultButton.Button1);

                                if (res == DialogResult.No)
                                {
                                    // 前回値に戻します
                                    e.Cell.Value = GetCustomerSnm((int)e.Cell.Tag);

                                    this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                                    this._cellUpdateFlg = true;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (msgFlg)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                   "選択された得意先は請求先コードが異なるため、請求先として選択できません。",
                                                   0,
                                                   MessageBoxButtons.OK,
                                                   MessageBoxDefaultButton.Button1);

                                // 前回値に戻します
                                e.Cell.Value = GetCustomerSnm((int)e.Cell.Tag);

                                this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                                this._cellUpdateFlg = true;
                                return;
                            }
                            else
                            {
                                e.Cell.Value = GetCustomerSnm(customerCode);
                                e.Cell.Tag = customerCode;

                                // 請求先変更時処理
                                ChangeClaimCode(ref uGrid, rowIndex);

                                this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                                this._cellUpdateFlg = true;
                                return;
                            }
                        }

                        if (claimCode != customerCode)
                        {
                            e.Cell.Value = customerSnm;
                        }
                        else
                        {
                            if (customerSnm != "")
                            {
                                e.Cell.Value = customerSnm;
                            }
                        }

                        e.Cell.Tag = claimCode;

                        // 請求先変更時処理
                        ChangeClaimCode(ref uGrid, rowIndex);

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;
                        break;
                    }
                // 転嫁方式参照
                case GridInitialSetting.column_CustCTaXLayRefCd:
                    {
                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        // 転嫁方式参照変更時処理
                        ChangeCustCTaXLayRefCd(ref uGrid, rowIndex);

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 与信管理
                case GridInitialSetting.column_CreditMngCode:
                    {
                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        // 与信管理変更時処理
                        ChangeCreditMngCode(ref uGrid, rowIndex);

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 単価端数,金額端数,税端数
                case GridInitialSetting.column_SalesUnPrcFrcProcCd:
                case GridInitialSetting.column_SalesMoneyFrcProcCd:
                case GridInitialSetting.column_SalesCnsTaxFrcProcCd:
                    {
                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        if (e.Cell.Text.Trim() == "")
                        {
                            e.Cell.Value = 0;
                        }

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 自宅TEL,自宅FAX,勤務先TEL,携帯電話,勤務先FAX,その他電話,主連絡先
                case GridInitialSetting.column_HomeTelNo:
                case GridInitialSetting.column_HomeFaxNo:
                case GridInitialSetting.column_OfficeTelNo:
                case GridInitialSetting.column_PortableTelNo:
                case GridInitialSetting.column_OfficeFaxNo:
                case GridInitialSetting.column_OthersTelNo:
                case GridInitialSetting.column_MainContactCode:
                    {
                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        int mainContactCd = IntObjToInt(uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_MainContactCode].Value);

                        // 主連絡先項目値変更時処理
                        ChangeMainContactValue(ref uGrid, rowIndex, mainContactCd);

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;

                        break;
                    }
                // 郵便番号
                case GridInitialSetting.column_PostNo:
                    {
                        string postNo = StrObjToString(e.Cell.Value);

                        AddressGuideResult agResult;

                        this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = false;

                        int status = ShowAddressGuide(out agResult, postNo);
                        if (status == 0)
                        {
                            e.Cell.Value = agResult.PostNo.Trim();

                            // 住所名称分割処理
                            string address1;
                            string address2;
                            DivisionAddressName(30, agResult.AddressName, out address1, out address2);

                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_Address1].Value = address1;
                            uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_Address3].Value = address2;
                        }

                        this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                        this._cellUpdateFlg = true;
                        break;
                    }
            }

            for (int index = 0; index < this._searchTable.Rows.Count; index++)
            {
                if (StrObjToInt(this._searchTable.Rows[index][GridInitialSetting.column_CustomerCode]) == customerCode)
                {
                    if (uGrid.ActiveCell.Value.ToString().Trim() == this._searchTable.Rows[index][uGrid.ActiveCell.Column.Index].ToString().Trim())
                    {
                        uGrid.ActiveCell.Appearance.BackColor = Color.Empty;
                    }
                    else
                    {
                        uGrid.ActiveCell.Appearance.BackColor = Color.Lime;
                    }
                    break;
                }
            }
        }

        // ADD 2010/03/23 Mantis対応[14976]：グリッド制御の拡張(グリッドヘッダの▼からの↑↓キーでドロップダウン操作ができない) ---------->>>>>
        /// <summary>
        /// マウスポインタがグリッドのヘッダ上にあるか判断します。
        /// </summary>
        /// <param name="targetGrid">対象グリッド</param>
        /// <returns></returns>
        private static bool IsFocusedOnGridHeader(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null) return false;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            return objHeader != null;
        }
        // ADD 2010/03/23 Mantis対応[14976]：グリッド制御の拡張(グリッドヘッダの▼からの↑↓キーでドロップダウン操作ができない) ----------<<<<<

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            this._keyDownFlg = true;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            this.tNedit_CustomerCode_St.Focus();
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.uCheckEditor_AutoFillToColumn.Focus();
                            break;
                        }
                    case Keys.Left:
                        {
                            this.CustomerGuideEd_Button.Focus();
                            break;
                        }
                }
                return;
            }
            // ADD 2010/03/23 Mantis対応[14976]：グリッド制御の拡張(グリッドヘッダの▼からの↑↓キーでドロップダウン操作ができない) ---------->>>>>
            else
            {   
                if (IsFocusedOnGridHeader((Infragistics.Win.UltraWinGrid.UltraGrid)sender))
                {
                    return;
                }
            }
            // ADD 2010/03/23 Mantis対応[14976]：グリッド制御の拡張(グリッドヘッダの▼からの↑↓キーでドロップダウン操作ができない) ----------<<<<<

            int rowIndex;
            int columnIndex;
            string columnKey;

            if (uGrid.ActiveCell != null)
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
                columnKey = uGrid.ActiveCell.Column.Key;
            }
            else
            {
                rowIndex = uGrid.ActiveRow.Index;
                columnIndex = 2;
                columnKey = uGrid.ActiveRow.Cells[columnIndex].Column.Key;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        // DEL 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ---------->>>>>
                        // if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        // DEL 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ----------<<<<<
                        // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ---------->>>>>
                        if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate)
                        // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ----------<<<<<
                        {
                            if (uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
                            {
                                // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ---------->>>>>
                                e.Handled = true;
                                if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != 0)
                                {
                                    // 選択中のValueListが最小でなければキー遷移しない
                                    uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex - 1;
                                    break;
                                }
                                // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ----------<<<<<
                                return;
                            }
                        }

                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.tNedit_CustomerCode_St.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            for (int index = rowIndex - 1; index >= 0; index--)
                            {
                                if (uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    uGrid.Rows[index].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        // DEL 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ---------->>>>>
                        // if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        // DEL 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ----------<<<<<
                        // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ---------->>>>>
                        if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate)
                        // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ----------<<<<<
                        {
                            if (uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
                            {
                                // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ---------->>>>>
                                e.Handled = true;
                                if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != uGrid.ActiveCell.ValueListResolved.ItemCount - 1)
                                {
                                    // 選択中のValueListが最大でなければキー遷移しない
                                    uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex + 1;
                                    break;
                                }
                                // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(↑↓キーでドロップダウン操作ができない) ----------<<<<<
                                return;
                            }
                        }

                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            this.uCheckEditor_AutoFillToColumn.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            for (int index = rowIndex + 1; index < uGrid_Details.Rows.Count; index++)
                            {
                                if (uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    uGrid.Rows[index].Cells[columnIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            if (uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                            {
                                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerName].Activate();
                            }
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            {
                                if (uGrid.ActiveCell.SelStart == 0)
                                {
                                    e.Handled = true;
                                    uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                            else
                            {
                                e.Handled = true;
                                uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            if (uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                            {
                                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex].Cells[GridInitialSetting.column_CustomerName].Activate();
                            }
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            {
                                if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                                {
                                    e.Handled = true;
                                    uGrid.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                            else
                            {
                                e.Handled = true;
                                uGrid.PerformAction(UltraGridAction.NextCellByTab);
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        uGrid_Details_ClickCellButton(this.uGrid_Details, new CellEventArgs(uGrid_Details.ActiveCell));
                        break;
                    }
            }
        }
        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.IsInEditMode)
            {
                // ADD 2009/04/13 ------>>>
                // 与信額
                if (cell.Column.Key == GridInitialSetting.column_CreditMoney)
                {
                    if (!KeyPressNumCheck(11, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // ADD 2009/04/13 ------<<<
                // 警告与信額
                //if (cell.Column.Key == GridInitialSetting.column_WarningCreditMoney)      // DEL 2009/04/13
                else if (cell.Column.Key == GridInitialSetting.column_WarningCreditMoney)   // ADD 2009/04/13
                {
                    if (!KeyPressNumCheck(11, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    // UI設定を参照
                    if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルがアクティブ化する前に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // 項目に従いIMEモード設定
            this.uGrid_Details.ImeMode = this.uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

            // ゼロ詰め解除実行
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                     this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value = 
                         this.uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key,
                         (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルの編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            //if (uGrid.ActiveCell.Column.Key != GridInitialSetting.column_WarningCreditMoney)      // DEL 2009/04/13
            if ((uGrid.ActiveCell.Column.Key != GridInitialSetting.column_CreditMoney) &&           // ADD 2009/04/13
                (uGrid.ActiveCell.Column.Key != GridInitialSetting.column_WarningCreditMoney))
            {
                return;
            }

            // 入力値取得
            long warningCreditMoney = StrObjToLong(uGrid.ActiveCell.Value);

            this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;
            this._cellUpdateFlg = false;

            //uGrid.ActiveCell.Value = warningCreditMoney.ToString("###,###");  // DEL 2009/04/09
            // ADD 2009/04/13 ------>>>
            // ゼロ入力は、ゼロを表示するように修正
            if (uGrid.ActiveCell.Text == "")
            {
                uGrid.ActiveCell.Value = "";
            }
            else
            {
                uGrid.ActiveCell.Value = warningCreditMoney.ToString("###,##0");
            }
            // ADD 2009/04/13 ------<<<
            
            this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
            this._cellUpdateFlg = true;

        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドが非アクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();
        }

        /// <summary>
        /// CellDataError イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 不正な値が入力された状態でセル値を更新しようとした時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;
            e.StayInEditMode = false;
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tNedit_CustomerCode_St.Focus();

            // XMLデータ読込
            LoadStateXmlData();

            this._cellMove = this._customerCustomerChangeConstructionAcs.CellMove;

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// CheckedChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 列サイズの自動調整チェックボックスのチェックが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void uCheckEditor_AutoFillToColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // 画面ロード時の列幅に戻します
                LoadStateXmlData();
            }
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 得意先コード(開始)
                case "tNedit_CustomerCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() != 0)
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = this.tComboEditor_GridFontSize;
                            }
                        }
                        break;
                    }
                // 得意先コード(終了)
                case "tNedit_CustomerCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                                {
                                    e.NextCtrl = this.uGrid_Details;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() != 0)
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode_St;
                                }
                            }
                        }
                        break;
                    }
                // 得意先ガイド(終了)
                case "CustomerGuideEd_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.uGrid_Details;
                            }
                        }
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (this.uGrid_Details.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // グリッドタブ移動制御
                                SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // グリッドシフトタブ移動制御
                                SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
                // 列サイズ自動調整チェックボックス
                case "uCheckEditor_AutoFillToColumn":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Focus();
                                    if (this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_QrcodePrtCd].Activation == Activation.AllowEdit)
                                    {
                                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_QrcodePrtCd].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_OfficeFaxNo].Activate();
                                    }
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                // 文字サイズコンボボックス
                case "tComboEditor_GridFontSize":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // グリッド
                case "uGrid_Details":
                    {
                        if (this.uGrid_Details.Rows.Count == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode_St;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.tNedit_CustomerCode_Ed.GetInt() != 0)
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.CustomerGuideEd_Button;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Focus();
                                    if (this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                                    {
                                        this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[0].Cells[GridInitialSetting.column_CustomerName].Activate();
                                    }
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Focus();
                                    if (this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_CustomerSubCode].Activation == Activation.AllowEdit)
                                    {
                                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_CustomerSubCode].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_CustomerName].Activate();
                                    }
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Focus();
                                    if (this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_QrcodePrtCd].Activation == Activation.AllowEdit)
                                    {
                                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_QrcodePrtCd].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[GridInitialSetting.column_OfficeFaxNo].Activate();
                                    }
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        #endregion ■ Control Events
    }
}