//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注処理
// プログラム概要   : 発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/06/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2011/10/26  修正内容 : HTML作成時のエンコードがホンダ側システムとマッチしていない為、修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 修 正 日  2011/11/17  修正内容 :  Readmine 7768ホンダe-Parts発注処理
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/12/02  修正内容 : Readmine 8304対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2012/02/06  修正内容 : 2012/03/28配信分 Redmine#28287の対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハ
// 作 成 日  2012/02/22  修正内容 : 2012/03/28配信分、Redmine#28287 
//                                  システム区分が在庫一括時、数量に０を設定された明細を削除処理についての対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 陳艶丹
// 修 正 日  2022/06/20  修正内容 : PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using Broadleaf.Application.Resources;// ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注処理のアクセス制御を行います。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009/06/10</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// <br>Update Note : 2022/06/20 陳艶丹</br>
    /// <br>管理番号    : 11870080-00</br>
    /// <br>              PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応</br>
    /// </remarks>
    public class SupplierAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        //アクセスクラス
        private static SupplierAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //データーテーブル
        private StockInputDataSet _dataSet;
        private StockInputDataSet.OrderExpansionDataTable _orderDataTable;

        //従業員マスタ
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // 従業員情報 アクセスクラス

        //受注マスタ
        private IAcceptOdrCarDB _iAcceptOdrCarDB;

        //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        //受注マスタ（車両）
        List<AcceptOdrCarWork> _acceptOdrCarWorkList = null;

        static BackgroundWorker bw;

        static private int _time;

        // ---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応--->>>>>
        // ブラウザフラグ「0:ie  1:edg」
        private static int browserUseFlg;
        // ブラウザ制御XMLファイル
        private const string CUSTOMSIZESETTINGSFILE = "PMUOE01504A_BrowserSetting.xml";
        // IEブラウザ
        private const string IELOCATIONSTR = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
        // edgeブラウザ
        private const string MSEDGELOCATIONSTR = @"%ProgramFiles%\Microsoft\Edge\Application\msedge.exe";
        // ---ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応---<<<<<
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private SupplierAcs()
        {
            // 変数初期化
            this._dataSet = new StockInputDataSet();
            this._orderDataTable = this._dataSet.OrderExpansion;

            this.orderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
            this._iAcceptOdrCarDB = (IAcceptOdrCarDB)MediationAcceptOdrCarDB.GetAcceptOdrCarDB();

            this.GetBrowserSettingInfo(); // ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応
        }

        /// <summary>
        /// ＵＯＥ発注処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ発注処理アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注処理アクセスクラス インスタンス取得を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public static SupplierAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public StockInputDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// 有効入力行存在判定
        /// </summary>
        /// <returns>行存在チェック結果（True : 行あり / False : 行なし）</returns>
        /// <remarks>
        /// <br>Note       : 有効入力行存在判定を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this._orderDataTable.Rows.Count > 0)
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public StockInputDataSet.OrderExpansionDataTable orderDataTable
        {
            get { return _orderDataTable; }
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(InpDisplay inpDisplay)
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

        # region ■ ＵＯＥ発注データ 検索処理 ■
        /// <summary>
        /// ＵＯＥ発注データ 検索処理
        /// </summary>
        /// <param name="inpDisplay">検索条件クラス</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ 検索処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        public int SearchDB(InpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {   //グリッド用テーブルのクリア
                this.orderDataTable.Rows.Clear();

                //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                int index = 1;

                //-----------------------------------------------------------
                // ＵＯＥ発注データの格納
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    StockInputDataSet.OrderExpansionRow row = this.orderDataTable.NewOrderExpansionRow();
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
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    this.orderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }

            return status;
        }

        #region ヘッダー部入力値の保存処理
        /// <summary>
        /// ヘッダー部入力値の保存処理
        /// </summary>
        /// <param name="inpHedDisplay"> ヘッダー部入力クラス</param>
        /// <remarks>
        /// <br>Note       : ヘッダー部入力値の保存処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void UpdtHedaerItem(InpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.orderDataTable);

            string rowFilterString = "";

            //オンライン番号
            rowFilterString = String.Format("{0} = {1}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                dataRow[this.orderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１
                dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // 従業員コード
                dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // 従業員名称
            }

        }

        # endregion

        # endregion

        #region ＵＯＥ発注データ削除件数取得
        /// <summary>
        /// ＵＯＥ発注データ削除件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除件数取得を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        # endregion

        #region 発注ブロック数の算出
        /// <summary>
        /// ＵＯＥ発注データ発注ブロック数の算出
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ発注ブロック数の算出を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                //送信明細数
                int detailIndex = 0;
                //前回ｵﾝﾗｲﾝ番号
                int bfOnlineNo = 0;
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];

                    detailIndex++;

                    if (bfOnlineNo == 0 || bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 0;
                    }
                    else
                    {
                        if (detailIndex >= 6)
                        {
                            count++;
                            bfOnlineNo = onlineNo;
                            detailIndex = 0;
                        }
                    }
                }

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
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOESupplier">拠点コード</param>
        /// <param name="message">Message</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note: 2012/02/22 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28287 システム区分が在庫一括時、数量に０を設定された明細を削除処理についての対応</br>
        /// </remarks>
        //public int WriteDB(UOESupplier uOESupplier, out string message)//DEL 鄧潘ハン 2012/02/22 Redmine#28287
        public int WriteDB(int systemDiv, UOESupplier uOESupplier, out string message)//ADD 鄧潘ハン 2012/02/22 Redmine#28287
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            try
            {
                //保存データ取得処理
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;

                //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;
                //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<

                //status = GetUOEOrderDtlWorkFromRowData(1, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);//DEL 鄧潘ハン 2012/02/22 Redmine#28287
                status = GetUOEOrderDtlWorkFromRowData(1, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);//ADD 鄧潘ハン 2012/02/22 Redmine#28287

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                //if (uOEOrderDtlWorkList == null) return (-1);
                //if (uOEOrderDtlWorkList.Count == 0) return (-1);
                //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<

                //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);
                // システム区分が在庫一括時、数量に０を設定された明細を削除処理
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

                    //受注マスタ（車両）を取得
                    GetacceptOdrCarWorkList(stockDetailWorkList);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //認証用HTMLを作成
                        DoLoginHtml(uOESupplier);
                        //発注確認用HTMLの作成
                        DoEpartsHtml(uOEOrderDtlWorkList, stockDetailWorkList, uOESupplier);
                        //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>>>>
                        //ホンダe-Parts bakファイル
                        string tempPath = Path.GetTempPath();
                        string timeFormat = "yyyyMMddHHmmss";
                        DateTime dateTime = DateTime.Now;
                        string bakFileName = "e-Parts_" + dateTime.ToString(timeFormat) + ".html";
                        File.Copy(tempPath + "\\" + "e-Parts.html", uOESupplier.AnswerSaveFolder + "\\" + bakFileName);
                        //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<<<<
                    }
                }//ADD 鄧潘ハン 2012/02/22 Redmine#28287
           
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }        

        /// <summary>
        /// 受注マスタ（車両）を取得処理
        /// </summary>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受注マスタ（車両）を取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public void GetacceptOdrCarWorkList(List<StockDetailWork> stockDetailWorkList)
        {
            ArrayList acceptOdrCarWorkList = new ArrayList();
            List<AcceptOdrCarWork> tempList = new List<AcceptOdrCarWork>();

            _acceptOdrCarWorkList = new List<AcceptOdrCarWork>();

            foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
            {
                AcceptOdrCarWork AcceptOdrCarWork = new AcceptOdrCarWork();
                AcceptOdrCarWork.EnterpriseCode = this._enterpriseCode;
                AcceptOdrCarWork.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo;
                AcceptOdrCarWork.AcptAnOdrStatus = 3;
                AcceptOdrCarWork.DataInputSystem = 10;
                acceptOdrCarWorkList.Add(AcceptOdrCarWork);

            }
            object acceptOdrCarObj = acceptOdrCarWorkList;
            int status = _iAcceptOdrCarDB.ReadAll(ref acceptOdrCarObj);
            if (acceptOdrCarObj is ArrayList)
            {
                acceptOdrCarWorkList = (ArrayList)acceptOdrCarObj;

                for (int i = 0; i < acceptOdrCarWorkList.Count; i++)
                {
                    AcceptOdrCarWork temp = (AcceptOdrCarWork)acceptOdrCarWorkList[i];
                    tempList.Add(temp);
                }
            }

            _acceptOdrCarWorkList = tempList;

        }

        /// <summary>
        /// 受注マスタ（車両）を取得処理
        /// </summary>
        /// <param name="uOEOrderDtlWork">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受注マスタ（車両）を取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        public List<AcceptOdrCarWork> GetacceptOdrCarWork(UOEOrderDtlWork uOEOrderDtlWork, List<StockDetailWork> stockDetailWorkList)
        {
            string key = string.Empty;

            List<StockDetailWork> stockresultList;
            List<AcceptOdrCarWork> acceptOdrCarWorkList = new List<AcceptOdrCarWork>();

            key = MakeStockKey(uOEOrderDtlWork.EnterpriseCode, uOEOrderDtlWork.SupplierFormal, uOEOrderDtlWork.StockSlipDtlNum);
            stockresultList = stockDetailWorkList.FindAll(delegate(StockDetailWork target)
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

            if (stockresultList != null && stockresultList.Count > 0)
            {
                StockDetailWork stockDetailWork = (StockDetailWork)stockresultList[0];

                acceptOdrCarWorkList = this._acceptOdrCarWorkList.FindAll(delegate(AcceptOdrCarWork target)
                {
                    if (stockDetailWork.AcceptAnOrderNo.Equals(target.AcceptAnOrderNo))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });
            }

            return acceptOdrCarWorkList;
        }

        # endregion

        #region 選択データの取得処理
        /// <summary>
        /// 選択データの取得処理
        /// </summary>
        /// <param name="mode">0:全て 1:変更データ 2:選択データ</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細リスト</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注データ削除用リスト</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除用リスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択データの取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note: 2012/02/06 凌小青</br>
        /// <br>管理番号   ：2012/03/28配信分</br>
        /// <br>             Redmine#28287の対応</br>
        /// <br>Update Note: 2012/02/22 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28287 システム区分が在庫一括時、数量に０を設定された明細を削除処理についての対応</br>
        /// </remarks>
        //public int GetUOEOrderDtlWorkFromRowData(int mode, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)//DEL 鄧潘ハン 2012/02/22 Redmine#28287
        public int GetUOEOrderDtlWorkFromRowData(int mode, int systemDiv, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, out string message)//ADD 鄧潘ハン 2012/02/22 Redmine#28287
        {
            // 戻値
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<
            message = "";

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);

                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.orderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.orderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.orderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.orderDataTable.StockSlipDtlNumColumn.ColumnName];

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
                        //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                        //if (mode == 1)
                        //{
                        //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<
                        //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                        if (mode == 1 && (systemDiv != 3
                        || 0 != double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                        //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.orderDataTable.UoeRemark1Column.ColumnName].ToString().Trim();
                            uOEOrderDtlWorktemp.EmployeeCode = dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName].ToString().Trim();
                            uOEOrderDtlWorktemp.EmployeeName = dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName].ToString().Trim();
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = (double)dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName];//ADD BY 凌小青 on 2012/02/06 for Redmine#28287
                            //}//DEL 鄧潘ハン 2012/02/22 Redmine#28287

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
                        //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
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
                        //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// <br>Update Note: 2012/02/22 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28287 システム区分が在庫一括時、数量に０を設定された明細を削除処理についての対応</br>
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

                //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;
                //---ADD 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<

                //status = GetUOEOrderDtlWorkFromRowData(2, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);//DEL 鄧潘ハン 2012/02/22 Redmine#28287
                status = GetUOEOrderDtlWorkFromRowData(2, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);//ADD 鄧潘ハン 2012/02/22 Redmine#28287
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

                //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                //if (uOEOrderDtlWorkList == null) return (-1);
                //if (uOEOrderDtlWorkList.Count == 0) return (-1);
                //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<

                //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------>>>>>
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);
                //---DEL 鄧潘ハン 2012/02/22 Redmine#28287------<<<<<

                //status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkList, out message);//DEL 鄧潘ハン 2012/02/22 Redmine#28287
                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);//ADD 鄧潘ハン 2012/02/22 Redmine#28287
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // 明細・行Primary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key作成

        #region Html作成
        /// <summary>
        /// 認証用Html作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 認証用Html作成処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private void DoLoginHtml(UOESupplier uOESupplier)
        {
            string tempPath = Path.GetTempPath();
            string htmlString = GetLoginHtmlContent();
            //UOE強制終了URL
            htmlString = htmlString.Replace("{%openurl%}", uOESupplier.UOEForcedTermUrl);
            //UOEログインURL
            htmlString = htmlString.Replace("{%formactionurl%}", uOESupplier.UOELoginUrl);
            //e-PartsユーザID
            htmlString = htmlString.Replace("{%username%}", uOESupplier.EPartsUserId);
            //e-Partsパスワード
            htmlString = htmlString.Replace("{%password%}", uOESupplier.EPartsPassWord);
            string loginHtmlPath = tempPath + "login.html";
            // 2011/10/26 >>>
            //using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("UTF-8"))) //保存地址
            using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("Shift_JIS")))
            // 2011/10/26 <<<
            {
                sw.WriteLine(htmlString);
                sw.Flush();
                sw.Close();
            }

            // DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 ----->>>>>
            //string IELocation = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
            //IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);

            //Process.Start(IELocation, loginHtmlPath);

            // DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 -----<<<<<
            // ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 ----->>>>>
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

            Process.Start(IELocation, loginHtmlPath);
            // ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 -----<<<<<
        }

        // --- ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 ----->>>>>
        /// <summary>
        /// ブラウザ設定XMLファイル取得
        /// </summary>
        private void GetBrowserSettingInfo()
        {
            // 0:ie  1:edg
            try
            {
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
        // --- ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 -----<<<<<

        /// <summary>
        /// 発注確認用HTML作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注確認用HTML作成処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private void DoEpartsHtml(List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList, UOESupplier uOESupplier)
        {
            string tempPath = Path.GetTempPath();

            List<List<UOEOrderDtlWork>> tempList = GetList(uOEOrderDtlWorkList);

            string htmlString = GetEpartsHtmlContent(tempList, stockDetailWorkList);

            //UOE強制終了URL
            htmlString = htmlString.Replace("{%openurl%}", uOESupplier.UOEForcedTermUrl);

            //UOEログインURL
            if (uOESupplier.InqOrdDivCd == 0)
            {
                htmlString = htmlString.Replace("{%formactionurl%}", uOESupplier.UOEOrderUrl);
            }
            else
            {
                htmlString = htmlString.Replace("{%formactionurl%}", uOESupplier.UOEStockCheckUrl);
            }

            //dirPath
            htmlString = htmlString.Replace("{%dirPath%}", uOESupplier.AnswerSaveFolder);

            //item
            htmlString = htmlString.Replace("{%item%}", uOESupplier.UOEItemCd.PadLeft(5, '0'));

            //ログインタイムアウトtime
            _time = uOESupplier.LoginTimeoutVal;

            string loginHtmlPath = tempPath + "e-parts.html";
            // 2011/10/26 >>>
            //using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("UTF-8"))) //保存地址
            using (StreamWriter sw = new StreamWriter(loginHtmlPath, false, System.Text.Encoding.GetEncoding("Shift_JIS")))
            // 2011/10/26 <<<
            {
                sw.WriteLine(htmlString);
                sw.Flush();
                sw.Close();
            }

            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync(loginHtmlPath);

        }

        /// <summary>
        /// 発注確認用HTML作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注確認用HTML作成処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 ----->>>>>
            //string IELocation = @"%ProgramFiles%\Internet Explorer\iexplore.exe";
            //IELocation = System.Environment.ExpandEnvironmentVariables(IELocation);
            // DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 -----<<<<<

            // ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 ----->>>>>
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
            // ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 -----<<<<<

            Thread.Sleep(_time * 1000);

            Process.Start(IELocation, e.Argument.ToString());
        }

        /// <summary>
        /// 発注確認用List作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注確認用List作成処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private List<List<UOEOrderDtlWork>> GetList(List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            //uOEOrderDtlWorkList.Sort(delegate(UOEOrderDtlWork x, UOEOrderDtlWork y) { return x.UOESalesOrderNo - y.UOESalesOrderNo; });

            //前回UOE発注番号
            int befUOESalesOrderNo = 0;

            List<List<UOEOrderDtlWork>> tempList = new List<List<UOEOrderDtlWork>>();

            List<UOEOrderDtlWork> temp = new List<UOEOrderDtlWork>();

            for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
            {
                UOEOrderDtlWork uOEOrderDtlWork = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                if (befUOESalesOrderNo == 0 || befUOESalesOrderNo != uOEOrderDtlWork.UOESalesOrderNo)
                {
                    if (befUOESalesOrderNo == 0)
                    {
                        temp.Add(uOEOrderDtlWork);
                    }

                    if (befUOESalesOrderNo != 0 && befUOESalesOrderNo != uOEOrderDtlWork.UOESalesOrderNo)
                    {
                        tempList.Add(temp);

                        temp = new List<UOEOrderDtlWork>();

                        temp.Add(uOEOrderDtlWork);
                    }

                    befUOESalesOrderNo = uOEOrderDtlWork.UOESalesOrderNo;

                }
                else
                {
                    temp.Add(uOEOrderDtlWork);
                }

                if (i == (uOEOrderDtlWorkList.Count - 1))
                {
                    tempList.Add(temp);
                }
            }

            return tempList;
        }

        /// <summary>
        /// 認証用Html作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 認証用Html作成処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private static string GetLoginHtmlContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!-- saved from url=(0022)http://internet.e-mail -->");
            sb.Append("\r\n");
            sb.Append("<html><head><script language=\"javascript\">");
            sb.Append("\r\n");
            sb.Append(@"function beforeOrder(){");
            sb.Append("\r\n");
            sb.Append(@"    document.form1.submit();");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"function closeForce() {");
            sb.Append("\r\n");
            sb.Append(@"    if (!document.all) {");
            sb.Append("\r\n");
            sb.Append(@"        // for Netscape");
            sb.Append("\r\n");
            sb.Append("        window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"        window.close();");
            sb.Append("\r\n");
            sb.Append(@"   } else if ((navigator.userAgent.match(/MSIE (\d\.\d)/), RegExp.$1) >= 5.5) {");
            sb.Append("\r\n");
            sb.Append(@"       // for IE 6.0 or later");
            sb.Append("\r\n");
            sb.Append("       var w = window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"        w.opener = window;");
            sb.Append("\r\n");
            sb.Append(@"        w.close();");
            sb.Append("\r\n");
            sb.Append(@"    } else {");
            sb.Append("\r\n");
            sb.Append(@"        // for IE4, IE5.0");
            sb.Append("\r\n");
            sb.Append(@"        window.close()");
            sb.Append("\r\n");
            sb.Append("        setTimeout(\"closeForce()\", 500);");
            sb.Append("\r\n");
            sb.Append(@"    }");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"</script><body >");
            sb.Append("\r\n");
            sb.Append(@"<!-- 検証 -->");
            sb.Append("\r\n");
            //sb.Append("<form name=\"form1\" action=\"{%formactionurl%}\" method=\"post\" target=\"HONDA_IPO\">"); //DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応
            sb.Append("<form name=\"form1\" action=\"{%formactionurl%}\" method=\"post\" target=\"_self\">"); //ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応
            sb.Append("\r\n");
            sb.Append("    <input type=\"hidden\" name=\"username\" value=\"{%username%}\">");
            sb.Append("\r\n");
            sb.Append("    <input type=\"hidden\" name=\"password\" value=\"{%password%}\">");
            sb.Append("\r\n");
            sb.Append("    <input type=\"hidden\" name=\"login-form-type\" value=\"pwd\">");
            sb.Append("\r\n");
            sb.Append(@"</form>");
            sb.Append("\r\n");
            sb.Append("\r\n");
            sb.Append(@"</form></body>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">beforeOrder()</script>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">closeForce()</script>");
            sb.Append("\r\n");
            sb.Append(@"</html>");
            return sb.ToString();
        }

        /// <summary>
        ///発注確認用HTML作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注確認用HTML作成処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string GetEpartsHtmlContent(List<List<UOEOrderDtlWork>> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!-- saved from url=(0022)http://internet.e-mail -->");
            sb.Append("\r\n");
            sb.Append("<html><head><script language=\"javascript\">");
            sb.Append("\r\n");
            sb.Append(@"function order(){");
            sb.Append("\r\n");
            sb.Append(@"document.form2.submit();");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"function closeForce() {");
            sb.Append("\r\n");
            sb.Append(@"if (!document.all) {");
            sb.Append("\r\n");
            sb.Append(@"// for Netscape");
            sb.Append("\r\n");
            sb.Append("window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"window.close();");
            sb.Append("\r\n");
            sb.Append(@"} else if ((navigator.userAgent.match(/MSIE (\d\.\d)/), RegExp.$1) >= 5.5) {");
            sb.Append("\r\n");
            sb.Append(@"// for IE 6.0 or later");
            sb.Append("\r\n");
            sb.Append("var w = window.open(\"{%openurl%}\", \"_top\");");
            sb.Append("\r\n");
            sb.Append(@"w.opener = window;");
            sb.Append("\r\n");
            sb.Append(@"w.close();");
            sb.Append("\r\n");
            sb.Append(@"} else {");
            sb.Append("\r\n");
            sb.Append(@"// for IE4, IE5.0");
            sb.Append("\r\n");
            sb.Append(@"window.close()");
            sb.Append("\r\n");
            sb.Append("setTimeout(\"closeForce()\", 500);");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"}");
            sb.Append("\r\n");
            sb.Append(@"</script><body>");
            sb.Append("\r\n");
            sb.Append(@"<!-- 検証 -->");
            sb.Append("\r\n");
            //sb.Append("<form name=\"form2\" action=\"{%formactionurl%}\" method=\"post\" target=\"HONDA_IPO\">");//DEL 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応
            sb.Append("<form name=\"form2\" action=\"{%formactionurl%}\" method=\"post\" target=\"_self\">");//ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応
            sb.Append("\r\n");
            sb.Append("<input type=\"hidden\" name=\"interfaceXML\" value=\'<order>");
            sb.Append("\r\n");
            sb.Append("<OrderInfo dirPath=\"{%dirPath%}\" />");
            sb.Append("\r\n");

            foreach (List<UOEOrderDtlWork> UOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                UOEOrderDtlWork uOEOrderDtlWork = (UOEOrderDtlWork)UOEOrderDtlWork[0];
                List<AcceptOdrCarWork> acceptOdrCarWorkList = GetacceptOdrCarWork(uOEOrderDtlWork, stockDetailWorkList);

                sb.Append(@"<hattyu>");
                sb.Append("\r\n");

                sb.Append("<HattyuInfo onlineNo=\"");
                sb.Append(UOEOrderDtlWork[0].UOESalesOrderNo.ToString("d8"));
                sb.Append("\" item=\"{%item%}\"");
                sb.Append(" reMark=\"");
                sb.Append(UOEOrderDtlWork[0].UoeRemark1);
                sb.Append("\" />");

                sb.Append("\r\n");
                sb.Append(@"<model>");
                sb.Append("\r\n");

                string modelDesignationNo = string.Empty;
                string categoryNo = string.Empty;
                string modelFullName = string.Empty;
                string seriesModel = string.Empty;
                string searchFrameNo = string.Empty;

                if (null != acceptOdrCarWorkList && acceptOdrCarWorkList.Count > 0)
                {
                    AcceptOdrCarWork acceptOdrCarWork = (AcceptOdrCarWork)acceptOdrCarWorkList[0];
                    modelDesignationNo = acceptOdrCarWork.ModelDesignationNo.ToString("d5");
                    categoryNo = acceptOdrCarWork.CategoryNo.ToString("d4");
                    //modelFullName = acceptOdrCarWork.ModelFullName; // DEL gezh 2011/11/17
                    modelFullName = acceptOdrCarWork.ModelHalfName; // ADD gezh 2011/11/17
                    seriesModel = acceptOdrCarWork.SeriesModel;
                    searchFrameNo = acceptOdrCarWork.SearchFrameNo.ToString("d8");
                }

                sb.Append("<ModelInfo katashikiShitei=\"");
                sb.Append(modelDesignationNo);
                sb.Append("\" katashikiRuibetsu=\"");
                sb.Append(categoryNo);
                sb.Append("\" name=\"");
                sb.Append(modelFullName);
                sb.Append("\" katashiki=\"");
                sb.Append(seriesModel);
                sb.Append("\" frameNo=\"");
                sb.Append(searchFrameNo);
                sb.Append("\" />");

                sb.Append("\r\n");
                sb.Append(@"<parts>");
                sb.Append("\r\n");

                foreach (UOEOrderDtlWork temp in UOEOrderDtlWork)
                {
                    sb.Append("<PartInfo partno=\"");
                    sb.Append(temp.GoodsNoNoneHyphen);
                    sb.Append("\" odrQty=\"");
                    sb.Append(temp.AcceptAnOrderCnt);
                    sb.Append("\" repQty=\"0\" />");
                    sb.Append("\r\n");
                }

                sb.Append(@"</parts>");
                sb.Append("\r\n");
                sb.Append(@"</model>");
                sb.Append("\r\n");
                sb.Append(@"</hattyu>");
                sb.Append("\r\n");
            }

            sb.Append(@"</order>");
            sb.Append("\r\n");
            sb.Append(@"'>");
            sb.Append("\r\n");
            sb.Append(@"</form></body>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">order()</script>");
            sb.Append("\r\n");
            sb.Append("<script language=\"javascript\">closeForce()</script>");
            sb.Append("\r\n");
            sb.Append(@"</html>");

            return sb.ToString();
        }

        /// <summary>
        /// 型式文字列処理
        /// </summary>
        /// <param name="seriesModel">シリーズ型式</param>
        /// <returns>シリーズ型式</returns>
        /// <remarks>
        /// <br>Note       : 型式文字列処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/10</br>
        /// </remarks>
        private string GetSeriesModel(string seriesModel)
        {
            string temp = string.Empty;
            if (!string.IsNullOrEmpty(seriesModel))
            {
                if (seriesModel.Contains("-"))
                {
                    string[] seriesModelList = seriesModel.Split(new char[] { '-' });

                    if (seriesModelList.Length <= 2)
                    {
                        temp = seriesModelList[0];
                    }
                    else
                    {
                        temp = seriesModelList[1];
                    }
                }
                else
                {
                    temp = seriesModel;
                }
            }

            return temp;
        }

        #endregion Html作成
    }

    // --- ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 --->>>>>
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
    // --- ADD 2022/06/20 陳艶丹 PMKOBETSU-4212 ホンダ e-parts発注処理　Edgi対応 ---<<<<<
}
