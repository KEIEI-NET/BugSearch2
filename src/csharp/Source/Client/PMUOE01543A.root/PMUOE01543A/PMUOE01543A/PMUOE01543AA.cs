//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ発注処理
// プログラム概要   : マツダ発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 李占川
// 作 成 日  2011/05/18  修正内容 : 新規作成
//                                  マツダWebUOEとの連携用データとして、UOE発注データからマツダ用システム連携アドレスの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/10/12  修正内容 : マツダWebUOE不具合対応
//                                  URLにセットする品番をハイフン無しに変更する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2011/12/02  修正内容 : Redmine#8304の対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 陳艶丹
// 修 正 日  2022/06/20  修正内容 : PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data;
using System.Diagnostics;
//---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応--->>>>>
using Broadleaf.Application.Resources;
using System.IO;
//---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応---<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// マツダ発注処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : マツダ発注処理のアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// <br>Update Note : 2022/06/20 陳艶丹</br>
    /// <br>管理番号    : 11870080-00</br>
    /// <br>              PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応</br>
    /// </remarks>
    public partial class MazdaOrderProcAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // ADD 2011/12/31

        //アクセスクラス
        private static MazdaOrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //データーテーブル
        private MazdaOrderProcDataSet _dataSet;
        private MazdaOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //従業員マスタ
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // 従業員情報 アクセスクラス

        //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        private UOESupplier _uOESupplier = null;

        // ---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応--->>>>>
        // ブラウザフラグ「0:ie  1:edg」
        private static int browserUseFlg;
        // ブラウザ制御XMLファイル
        private const string CUSTOMSIZESETTINGSFILE = "PMUOE01543A_BrowserSetting.xml";
        // IEブラウザ
        private const string IELOCATIONSTR = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
        // edgeブラウザ
        private const string MSEDGELOCATIONSTR = @"%ProgramFiles%\Microsoft\Edge\Application\msedge.exe";
        // ---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応---<<<<<
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private MazdaOrderProcAcs()
        {
            this.OrderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();

            //ブラウザ設定XMLファイル取得処理
            this.GetBrowserSettingInfo(); // ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応
        }

        /// <summary>
        /// ＵＯＥ発注処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ発注処理アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注処理アクセスクラス インスタンス取得を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public static MazdaOrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new MazdaOrderProcAcs();
            }

            return _supplierAcs;
        }
        # endregion

        #region データ変更フラグ
        /// <summary>データ変更フラグプロパティ（true:変更あり false:変更なし）</summary>
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
            }
        }
        #endregion

        # region 従業員マスタキャッシュ処理
        /// <summary>
        /// 従業員マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタキャッシュ処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheEmployee()
        {
            object returnEmployee;
            _employeeWork = new Dictionary<string, EmployeeWork>();
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = this._enterpriseCode; ;

            try
            {

                int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (returnEmployee is ArrayList)
                    {
                        foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                        {
                            if (employeeWork.LogicalDeleteCode == 0 &&
                                _employeeWork.ContainsKey(employeeWork.EmployeeCode.Trim()) != true)
                            {
                                this._employeeWork.Add(employeeWork.EmployeeCode.Trim(), employeeWork);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                _employeeWork = new Dictionary<string, EmployeeWork>();
            }

        }

        /// <summary>
        /// 従業員存在チェック
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 従業員存在チェックを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public bool GetEmployeeName(string employeeCode, out string employeeName)
        {
            employeeName = string.Empty;

            if (!this._employeeWork.ContainsKey(employeeCode))
            {
                return false;
            }

            employeeName = this._employeeWork[employeeCode].Name.Trim();

            return true;
        }

        # endregion

        # region 発注検索データセット取得処理
        /// <summary>
        /// 発注検索データセット取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注検索データセット取得を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private MazdaOrderProcDataSet DataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new MazdaOrderProcDataSet();
                }
                return _dataSet;
            }
        }
        /// <summary>
        /// 有効入力行存在判定
        /// </summary>
        /// <returns>行存在チェック結果（True : 行あり / False : 行なし）</returns>
        /// <remarks>
        /// <br>Note       : 有効入力行存在判定を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this.OrderDataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        # region 発注検索データテーブル取得処理
        /// <summary>
        /// 発注検索データテーブル取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注検索データテーブル取得を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public MazdaOrderProcDataSet.OrderExpansionDataTable OrderDataTable
        {
            get
            {
                if (_orderDataTable == null)
                {
                    _orderDataTable = this.DataSet.OrderExpansion;
                }
                return _orderDataTable;
            }
        }
        # endregion

        #region 選択・非選択状態処理(指定型)
        /// <summary>
        /// 選択・非選択状態処理(指定型)
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <param name="selected">true:選択,false:非選択</param>
        /// <remarks>
        /// <br>Note       : 選択・非選択状態処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.OrderDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.OrderDataTable.InpSelectColumn.ColumnName] = selected;
                _row.EndEdit();
            }
        }
        # endregion

        # region ■ 画面データクラス→＜検索用＞条件抽出クラス ■
        /// <summary>
        /// 画面データクラス→＜検索用＞条件抽出クラス
        /// </summary>
        /// <param name="inpDisplay">画面データクラス</param>
        /// <remarks>
        /// <br>Note       : 条件抽出を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(MazdaInpDisplay inpDisplay)
        {
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();

            para.EnterpriseCode = inpDisplay.EnterpriseCode;
            para.CashRegisterNo = inpDisplay.CashRegisterNo;
            para.SystemDivCd = inpDisplay.SystemDivCd;
            para.St_OnlineNo = inpDisplay.UOESalesOrderNoSt;
            para.Ed_OnlineNo = inpDisplay.UOESalesOrderNoEd;
            para.St_InputDay = inpDisplay.SalesDateSt;
            para.Ed_InputDay = inpDisplay.SalesDateEd;
            para.CustomerCode = inpDisplay.CustomerCode;
            para.UOESupplierCd = inpDisplay.UOESupplierCd;
            para.DataSendCodes = new int[1];
            para.DataSendCodes[0] = 0;
            return para;
        }
        # endregion

        #region ヘッダー部入力値の保存処理
        /// <summary>
        /// ヘッダー部入力値の保存処理
        /// </summary>
        /// <param name="inpHedDisplay"> ヘッダー部入力クラス</param>
        /// <remarks>
        /// <br>Note       : ヘッダー部入力値の保存処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void UpdtHedaerItem(MazdaInpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.OrderDataTable);

            string rowFilterString = "";

            //オンライン番号
            rowFilterString = String.Format("{0} = {1}",
                                                    this.OrderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                MazdaOrderProcDataSet.OrderExpansionRow dataRow = (MazdaOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                
                dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１

                dataRow[this.OrderDataTable.BoCodeColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // 納品区分
                //dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // 納品区分名称
                
            }

        }
        # endregion

        # region ■ ＵＯＥ発注データ 検索処理 ■
        /// <summary>
        /// ＵＯＥ発注データ 検索処理
        /// </summary>
        /// <param name="inpDisplay">検索条件クラス</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ 検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        public int SearchDB(MazdaInpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            message = "";

            try
            {   //グリッド用テーブルのクリア
                this.OrderDataTable.Rows.Clear();

                //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        return (status);
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        return (status);
                    }
                }

                int index = 1;

                //-----------------------------------------------------------
                // ＵＯＥ発注データの格納
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    MazdaOrderProcDataSet.OrderExpansionRow row = this.OrderDataTable.NewOrderExpansionRow();
                    row.OrderNo = index++;
                    row.OnlineNo = uOEOrderDtlWork.OnlineNo;
                    row.InputDay = uOEOrderDtlWork.InputDay;
                    row.CustomerSnm = uOEOrderDtlWork.CustomerSnm;
                    row.CashRegisterNo = uOEOrderDtlWork.CashRegisterNo;
                    row.GoodsMakerCd = uOEOrderDtlWork.GoodsMakerCd;
                    row.GoodsNo = uOEOrderDtlWork.GoodsNo;
                    row.GoodsName = uOEOrderDtlWork.GoodsName;
                    row.AcceptAnOrderCnt = uOEOrderDtlWork.AcceptAnOrderCnt;
                    row.UoeRemark1 = uOEOrderDtlWork.UoeRemark1;
                    row.EmployeeCode = uOEOrderDtlWork.EmployeeCode;
                    row.EmployeeName = uOEOrderDtlWork.EmployeeName;
                    row.OnlineRowNo = uOEOrderDtlWork.OnlineRowNo;
                    row.UOEKind = uOEOrderDtlWork.UOEKind;
                    row.CommonSeqNo = uOEOrderDtlWork.CommonSeqNo;
                    row.SupplierFormal = uOEOrderDtlWork.SupplierFormal;
                    row.StockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                    row.UOEDeliGoodsDiv = uOEOrderDtlWork.UOEDeliGoodsDiv;
                    row.UOEResvdSection = uOEOrderDtlWork.UOEResvdSection;
                    row.FollowDeliGoodsDiv = uOEOrderDtlWork.FollowDeliGoodsDiv;
                    row.UOEDeliGoodsDivNm = uOEOrderDtlWork.DeliveredGoodsDivNm;
                    row.BoCode = uOEOrderDtlWork.BoCode;
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    this.OrderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        # endregion

        #region ＵＯＥ発注データ削除件数取得
        /// <summary>
        /// ＵＯＥ発注データ削除件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除件数取得を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// ＵＯＥ発注データ選択しないの件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ選択しないの件数取得を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        # endregion

        #region ＵＯＥ発注データ更新処理
        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <param name="uOESupplier">UOE発注先マスタの収得</param>//ADD BY 凌小青 on 2011/12/02 for Redmine#8304
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        //--------DEL BY 凌小青 on 2011/12/02 for Redmine#8304 ---------------->>>>>>>>>>>
        //public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
        //       out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, 
        //       out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList)
        //--------DEL BY 凌小青 on 2011/12/02 for Redmine#8304 ----------------<<<<<<<<<<<
        //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ---------------->>>>>>>>>>>
        public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
              out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
              out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList,
              ref UOESupplier uOESupplier)
        //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ---------------->>>>>>>>>>>
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //保存データ取得処理
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                stockDetailWorkDelList = new List<StockDetailWork>();

                status = GetUOEOrderDtlWorkFromRowData(1, cashRegisterNo, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);

                // システム区分が在庫一括時、数量に０を設定された明細を削除処理
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                // 更新
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

                    // UOE発注データを発注データのソート順でソート
                    uOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());
                    // マツダWebUOE用連携URLを作成します。
                    string url = this.CreatUrl(uOEOrderDtlWorkList);
                    //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                    //マッダ保存url
                    System.IO.StreamWriter sw = null;
                    string timeFormat = "yyyyMMddHHmmss";
                    DateTime dt = DateTime.Now;
                    string startFileName = "MAZDA_";
                    string endFileName = ".SND";
                    try
                    {
                        sw = System.IO.File.CreateText(uOESupplier.AnswerSaveFolder + "\\" + startFileName + dt.ToString(timeFormat) + endFileName);
                        sw.WriteLine(url);
                        sw.Flush();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                    finally
                    {
                        sw.Close();
                    }
                    //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<

                    // URLを作成したのち、そのURLを使用してブラウザを起動します。
                    //--- ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応--->>>>>
                    string IELocation = string.Empty;

                    // 0:ie  1:edg
                    if (browserUseFlg == 0)
                    {
                        IELocation = IELOCATIONSTR;
                        IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                    }
                    else
                    {
                        IELocation = MSEDGELOCATIONSTR;
                        IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                        //起動するブラウザがEdgeの場合、「%ProgramFiles%\Microsoft\Edge\Application\msedge.exe」が存在しなかったらIEで起動する
                        if (!File.Exists(IELocation))
                        {
                            IELocation = IELOCATIONSTR;
                            IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                        }
                    }
                    //--- ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応---<<<<<
                    //--- DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応--->>>>>
                    //string IELocation = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
                    //IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
                    //--- DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応---<<<<<
   
                    Process.Start(IELocation, url);
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                return -1;
            }

            return status;
        }
        # endregion

        #region 選択データの取得処理
        /// <summary>
        /// 選択データの取得処理
        /// </summary>
        /// <param name="mode">0:全て 1:変更データ 2:選択データ</param>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ更新用リスト</param>
        /// <param name="stockDetailWorkList">仕入明細更新用リスト</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注データ削除用リスト</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除用リスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択データの取得処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetUOEOrderDtlWorkFromRowData(int mode, int cashRegisterNo, int systemDiv, 
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, 
                                                                out string message)
        {
            // 戻値
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            message = "";
            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    MazdaOrderProcDataSet.OrderExpansionRow dataRow = (MazdaOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.OrderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.OrderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.OrderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.OrderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.OrderDataTable.StockSlipDtlNumColumn.ColumnName];
                    key = MakeKey(uOEOrderDtlWork);

                    //データ取得処理
                    uOEresultList = this._uOEOrderDtlWorkList.FindAll(delegate(UOEOrderDtlWork target)
                    {
                        if (key.Equals(MakeKey(target)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (uOEresultList.Count != 0)
                    {
                        UOEOrderDtlWork uOEOrderDtlWorktemp = uOEresultList[0];
                        if (mode == 1 && (systemDiv != 3
                              || 0 != double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                            // 受信日付
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // 送信フラグ
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // 復旧フラグ
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // 送信端末番号
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;
                            // UOEリマーク1
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName].ToString();
                            //// 納品区分名称
                            //uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // BO区分
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.OrderDataTable.BoCodeColumn.ColumnName].ToString();
                            // UOEリマーク２
                            uOEOrderDtlWorktemp.UoeRemark2 = this._uOESupplier.HondaSectionCode.Trim().PadRight(3, ' ') + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            // 受注数量
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());
                            // 受注数量
                            uOEOrderDtlWorkList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkList.Add(stockDetailWork);
                            }
                        }
                        else
                        {
                            uOEOrderDtlWorkDelList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkDelList.Add(stockDetailWork);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                status = -1;
            }

            return status;

        }

        #endregion

        #region ＵＯＥ発注データ削除処理
        /// <summary>
        /// ＵＯＥ発注データ削除処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int DeleteDB(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // 削除対象のＵＯＥ発注データの取得
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;

                status = GetUOEOrderDtlWorkFromRowData(2, 0, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);

                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }

        # endregion

        #region Key作成
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="uOEOrderDtlWork">明細・行</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : Key作成処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private string MakeKey(UOEOrderDtlWork uOEOrderDtlWork)
        {
            // 明細・行Primary Key
            string key = uOEOrderDtlWork.OnlineNo.ToString() + uOEOrderDtlWork.OnlineRowNo.ToString() + uOEOrderDtlWork.UOEKind.ToString()
                + uOEOrderDtlWork.CommonSeqNo.ToString() + uOEOrderDtlWork.SupplierFormal.ToString() + uOEOrderDtlWork.StockSlipDtlNum.ToString();

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : 明細・行Key作成処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // 明細・行Primary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }
        #endregion Key作成

        # region 発注連携URLの作成処理
        /// <summary>
        /// マツダWebUOE用発注連携URLの作成
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>url</returns>
        /// <remarks>
        /// <br>Note       : マツダWebUOE用発注連携URLの作成を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private string CreatUrl(List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            string url = string.Empty;
            url += "http://epc2.mazda.co.jp/epc/servlet/OrderInputInit";

            int index = 1;
            foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                // BO区分
                string bo = uOEOrderDtlWork.BoCode;
                // コメント
                string comment = uOEOrderDtlWork.UoeRemark1;
                // 部品番号
                // 2011/10/12 >>>
                //string noParts = uOEOrderDtlWork.GoodsNo;
                string noParts = uOEOrderDtlWork.GoodsNoNoneHyphen;
                // 2011/10/12 <<<
                // 数量
                string suryo = uOEOrderDtlWork.AcceptAnOrderCnt.ToString();
                // 連携№
                string uoeRemark2 = uOEOrderDtlWork.UoeRemark2;

                if (index == 1)
                {
                    url += "?bo=" + bo;
                    url += "&comment=" + comment;
                }

                url += "&no_parts=" + noParts;
                url += "&suryo=" + suryo;

                if (index == uOEOrderDtlWorkList.Count)
                {
                    url += "&no_parts=" + uoeRemark2;
                    url += "&suryo=1";
                }
                else if (index % 5 == 0)
                {
                    url += "&no_parts=" + uoeRemark2;
                    url += "&suryo=1";
                }

                index++;
            }

            return url;
        }
        # endregion

        # region -- リスト順の作成処理 --
        /// <summary>
        /// 対象UOE発注データ比較クラス(オンライン番号(昇順)、インライン行番号(昇順)、UOE発注番号(昇順)、UOE発注行番号(昇順))
        /// </summary>
        /// <remarks>
        /// <br>Note       : 対象UOE発注データ比較クラス。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : Comparer<UOEOrderDtlWork>
        {
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // オンライン番号 
                int result = x.OnlineNo.CompareTo(y.OnlineNo);
                if (result != 0) return result;

                // オンライン行番号
                result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
                if (result != 0) return result;

                // UOE発注番号
                result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
                if (result != 0) return result;

                // UOE発注行番号
                result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
                return result;
            }
        }
        # endregion

        //---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応--->>>>>
        # region ブラウザ設定XMLファイル取得処理
        /// <summary>
        /// ブラウザ設定XMLファイル取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ブラウザ設定XMLファイルを取得する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2022/06/20</br>
        /// </remarks>
        private void GetBrowserSettingInfo()
        {
            try
            {
                // 0:ie  1:edg
                BrowserSettingInfo browserSettingInfo = new BrowserSettingInfo();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CUSTOMSIZESETTINGSFILE)))
                {
                    // XML取得
                    browserSettingInfo = UserSettingController.DeserializeUserSetting<BrowserSettingInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CUSTOMSIZESETTINGSFILE));
                    browserUseFlg = browserSettingInfo.BrowserUseFlg;

                    //値が不正な場合はEdgeで動作する
                    if (browserUseFlg != 0 && browserUseFlg != 1)
                    {
                        browserUseFlg = 1;
                    }
                }
                else
                {
                    //XMLファイルが無かった場合はEdgeで動作するようにする
                    browserUseFlg = 1;
                }
            }
            catch
            {
                browserUseFlg = 1;
            }
        }
        # endregion
        //---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応---<<<<<

        /// <summary>
        /// UOE発注先マスタ設定処理（プログラム：0304のみ用）
        /// </summary>
        /// <param name="uOESupplier">UOE発注先マスタ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ設定処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void SetUOESupplier(UOESupplier uOESupplier)
        {
            this._uOESupplier = uOESupplier;
        }
    }

    //---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応--->>>>>
    # region ブラウザ設定クラス
    /// <summary>
    /// ブラウザ設定クラス
    /// </summary>
    [Serializable]
    public class BrowserSettingInfo
    {
        // ブラウザ使用区分
        private int _browserUseFlg;

        /// <summary>
        /// ブラウザ設定クラス
        /// </summary>
        public BrowserSettingInfo()
        {

        }

        /// <summary>ブラウザ使用区分 0:iexplore 1:msedge</summary>
        public Int32 BrowserUseFlg
        {
            get { return this._browserUseFlg; }
            set { this._browserUseFlg = value; }
        }
    }
    # endregion
    //---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 マツダ e-parts発注処理　Edgi対応---<<<<<
}
